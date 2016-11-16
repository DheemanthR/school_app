Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient

Public Class Form0
    Dim db As New DBOperations.Connection
    Dim conn As New MySqlConnection
    Dim cmd As New MySqlCommand
    Dim dadapter As New MySqlDataAdapter
    Dim datardr As MySqlDataReader

    Dim changes As Boolean
    Dim newStud As Boolean
    Dim studFound As Boolean
    Dim dataChanged As Boolean
    Dim supplyNoREGN As Boolean

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Prajwal_school_appDataSet.classes' table. You can move, or remove it, as needed.
        Me.ClassesTableAdapter.Fill(Me.Prajwal_school_appDataSet.classes)
        cmbClass.SelectedIndex = 0
        changes = False
        studFound = False
        supplyNoREGN = False
        init(0)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim resultMain As Integer
        Dim resultSupplies As Integer

        If validate_Form() = True Then

            If studFound = True Then

                Try
                    conn = db.connect()
                    Dim Sql As String
                    Dim dt As Date
                    dt = dtDOB.Value
                    Dim dta As String = dt.ToString("yyyy-MM-dd")
                    Sql = "UPDATE `prajwal_school_app`.`student` SET `FIRST_NAME` = '" & txtFirstName.Text & "', `LAST_NAME` = '" & txtLastName.Text & "', `CLASS` = '" & cmbClass.SelectedIndex & "', `SECTION` = '" & txtSection.Text.ToUpper & "', `DOB` = '" & dta & "', `ADDRESS` = '" & txtAddress.Text & "' WHERE REGN = '" & txtStudentID.Text & "'"
                    cmd = New MySqlCommand(Sql, conn)
                    resultMain = cmd.ExecuteNonQuery

                    If resultMain > 0 Then
                        If MsgBox("Student Data Updated Successfully!") = DialogResult.OK Then
                            changes = False
                            Me.Close()
                        End If
                    Else
                        MsgBox("Student Not Saved. An Error occured!")
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    db.disconnect(conn)
                End Try

            Else
                Try
                    conn = db.connect()
                    Dim Sql As String
                    Dim REGN As Integer
                    Dim noSupplies As Boolean = True

                    Sql = "Select MAX(REGN) from `prajwal_school_app`.`student`"
                    cmd = New MySqlCommand(Sql, conn)
                    dadapter.SelectCommand = cmd

                    Try
                        REGN = cmd.ExecuteScalar
                        REGN += 1
                    Catch ex As Exception
                        REGN = 1001
                    End Try

                    Dim dt As Date
                    dt = dtDOB.Value
                    Dim dta As String = dt.ToString("yyyy-MM-dd")

                    Sql = "INSERT INTO `prajwal_school_app`.`student` (`REGN`, `FIRST_NAME`, `LAST_NAME`, `CLASS`, `SECTION`, `DOB`, `ADDRESS`) " &
                                    "VALUES ('" & REGN & "', '" & txtFirstName.Text & "', '" & txtLastName.Text & "', '" & cmbClass.SelectedIndex & "', '" & txtSection.Text.ToUpper & "', '" & dta & "', '" & txtAddress.Text & "');"

                    cmd = New MySqlCommand(Sql, conn)
                    resultMain = cmd.ExecuteNonQuery

                    If supplyNoREGN = True AndAlso listSupplies.Items.Count > 0 Then
                        Sql = "INSERT INTO `prajwal_school_app`.`supply_details` (`SUPPLY`, `FEES`, `REGN`) " &
                                   "VALUES "
                        Sql += " ('" & listSupplies.Items(0).SubItems(0).Text & "', '" & listSupplies.Items(0).SubItems(1).Text & "', '" & txtStudentID.Text & "') "

                        For i As Integer = 1 To listSupplies.Items.Count - 1
                            Sql += ", ('" & listSupplies.Items(0).SubItems(0).Text & "', '" & listSupplies.Items(0).SubItems(1).Text & "', '" & txtStudentID.Text & "') "
                        Next

                        cmd = New MySqlCommand(Sql, conn)
                        resultSupplies = cmd.ExecuteNonQuery
                        noSupplies = False

                    End If

                    'If Integer.Parse(lblTotalFeeReceived.Text) > 0 Then
                    '    Sql = "INSERT INTO `prajwal_school_app`.`fee_details` (`SUPPLY`, `FEES`, `REGN`) " &
                    '               "VALUES "
                    '    Sql += " ('" & listSupplies.Items(0).SubItems(0).Text & "', '" & listSupplies.Items(0).SubItems(1).Text & "', '" & txtStudentID.Text & "') "

                    '    For i As Integer = 1 To listSupplies.Items.Count - 1
                    '        Sql += ", ('" & listSupplies.Items(0).SubItems(0).Text & "', '" & listSupplies.Items(0).SubItems(1).Text & "', '" & txtStudentID.Text & "') "
                    '    Next

                    '    cmd = New MySqlCommand(Sql, conn)
                    '    resultSupplies = cmd.ExecuteNonQuery
                    'End If

                    If resultMain = 1 AndAlso (resultSupplies > 0 Or noSupplies = True) Then
                        MsgBox("Student Data Saved Successfully! " & vbCrLf & vbCrLf & "REGN = " + REGN.ToString)
                        Reset_Form()
                    Else
                        MsgBox("Student Not Saved. An Error occured!")
                    End If

                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    db.disconnect(conn)
                End Try
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub txtStudentID_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles txtStudentID.PreviewKeyDown
        If e.KeyData = Keys.Tab Or e.KeyData = Keys.Enter Then

            Try
                populateStudentDetails(txtStudentID.Text)

            Catch ex As Exception
                MsgBox("Student data could not be retrieved. An Error Occured.")
            Finally
                conn.Close()
            End Try

        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnResetForm.Click
        Dim res As DialogResult
        res = MessageBox.Show("All fields will be reset. Continue?", "Warning!", MessageBoxButtons.YesNo)
        If res = DialogResult.Yes Then
            Reset_Form()
        Else

        End If

    End Sub

    Private Sub Reset_Form()
        txtStudentID.Text = ""
        txtFirstName.Text = ""
        txtLastName.Text = ""
        dtDOB.Text = ""
        cmbClass.SelectedIndex = 0
        txtSection.Text = ""
        studFound = False
        dataChanged = False
        listSupplies.Items.Clear()
        init(0)
    End Sub

    Private Function validate_Form() As Boolean

        Dim result As Boolean
        result = True

        If newStud = False Then
            If Not Regex.Match(txtStudentID.Text, "^[0-9]+$", RegexOptions.None).Success Then
                lblErrREGN.Visible = True
                result = False
            Else
                lblErrREGN.Visible = False
            End If

        Else

            If txtFirstName.Text.Length = 0 Then
                lblErrFirstName.Visible = True
                lblErrFirstName.Text = "Cannot be empty"
                result = False
            ElseIf txtFirstName.Text.Length > 0 AndAlso Not Regex.Match(txtFirstName.Text, "^[a-zA-Z]+$", RegexOptions.None).Success Then
                lblErrFirstName.Visible = True
                lblErrFirstName.Text = "Only alphabets allowed"
                result = False
            Else
                lblErrFirstName.Visible = False
            End If

            If txtLastName.Text.Length = 0 Then
                lblErrLastName.Visible = True
                lblErrLastName.Text = "Cannot be empty"
                result = False
            ElseIf txtLastName.Text.Length > 0 AndAlso Not Regex.Match(txtLastName.Text, "^[a-zA-Z]+$", RegexOptions.None).Success Then
                lblErrLastName.Visible = True
                lblErrLastName.Text = "Only alphabets allowed"
                result = False
            Else
                lblErrLastName.Visible = False
            End If

            If Not dtDOB.Value < DateTime.Now Then
                lblErrDOB.Visible = True
                result = False
            Else
                lblErrDOB.Visible = False
            End If

            If txtSection.Text.Length > 1 AndAlso Regex.Match(txtSection.Text, "^[a-zA-Z]+$", RegexOptions.None).Success Then
                lblErrSection.Visible = True
                lblErrSection.Text = "Section can only be represented by one letter"
                result = False
            ElseIf txtSection.Text.Length >= 1 AndAlso Not Regex.Match(txtSection.Text, "^[a-zA-Z]+$", RegexOptions.None).Success Then
                lblErrSection.Visible = True
                lblErrSection.Text = "Only alphabets allowed"
                result = False
            ElseIf txtSection.Text.Length = 0 Then
                lblErrSection.Visible = True
                lblErrSection.Text = "Cannot be empty"
            Else
                lblErrSection.Visible = False
            End If

            If txtAddress.Text.Length = 0 Then
                lblErrAddress.Visible = True
                lblErrAddress.Text = "Cannot be empty"
                result = False
            ElseIf txtAddress.Text.Contains("'") Then
                lblErrAddress.Visible = True
                lblErrAddress.Text = "Character not allowed -> '"
                result = False
            Else
                lblErrAddress.Visible = False
            End If

            If cmbClass.SelectedIndex = 0 Then
                lblErrClass.Visible = True
                result = False
            Else
                lblErrClass.Visible = False
            End If

        End If

            Return result

    End Function

    Public Sub init(ByVal state As Integer)

        If state = 0 Then

            txtFirstName.Enabled = False
            txtLastName.Enabled = False
            txtSection.Enabled = False
            dtDOB.Enabled = False
            cmbClass.Enabled = False
            lblTotalFeeBalance.Visible = False
            lblTotalFeeReceived.Visible = False
            lblFees.Visible = False
            txtAddress.Enabled = False
            listSupplies.Enabled = False
            btnAdd.Enabled = False
            btnDelete.Enabled = False
            btnFeeDetails.Enabled = False
            btnPrevPay.Enabled = False
            txtStudentID.Enabled = True
            newStud = False

        Else

            txtFirstName.Enabled = True
            txtLastName.Enabled = True
            txtSection.Enabled = True
            dtDOB.Enabled = True
            cmbClass.Enabled = True
            txtAddress.Enabled = True
            listSupplies.Enabled = True
            btnAdd.Enabled = True
            btnDelete.Enabled = True
            txtStudentID.Enabled = False
            btnFeeDetails.Enabled = True
            btnPrevPay.Enabled = True
            newStud = True

        End If

    End Sub

    Private Sub btnNewStudent_Click(sender As Object, e As EventArgs) Handles btnNewStudent.Click
        init(1)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.DoubleClick

        Try
            Dim fd As OpenFileDialog = New OpenFileDialog()
            Dim strFileName As String

            fd.Title = "Select An Image"
            fd.InitialDirectory = "C:\"
            fd.Filter = "JPEG (*.jpg)|*.*"
            fd.FilterIndex = 0
            fd.RestoreDirectory = True

            If fd.ShowDialog() = DialogResult.OK Then
                strFileName = fd.FileName
                PictureBox1.ImageLocation = strFileName
                PictureBox1.Load()
            End If
        Catch ex As Exception
            MsgBox("Error loading image")
        End Try

    End Sub

    Private Sub btnFeeDetails_Click(sender As Object, e As EventArgs) Handles btnFeeDetails.Click

        If Not cmbClass.SelectedIndex = 0 Then
            Dim frm As New StudentInfo.FeeDetailsvb
            frm.Owner = Me
            frm.lblPresFees.Text = Me.lblFees.Text
            frm.lblStudName.Text = Me.txtFirstName.Text + " " + Me.txtLastName.Text
            frm.lblREGN.Text = Me.txtStudentID.Text
            frm.totalFeeReceived = Integer.Parse(lblTotalFeeReceived.Text)
            frm.Show()
        Else
            MsgBox("Please fill out other details first")
        End If

    End Sub

    Private Sub cmbClass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClass.SelectedIndexChanged

        Try
            changes = True
            If cmbClass.SelectedIndex = 0 Then
                lblFees.Visible = False

            Else
                lblFees.Visible = True
                conn = db.connect()
                Dim Sql As String = "Select * from `prajwal_school_app`.`fee_structure` where CLASS = '" & cmbClass.SelectedIndex - 1 & "';"
                cmd.CommandText = Sql
                cmd.Connection = conn
                dadapter.SelectCommand = cmd

                datardr = cmd.ExecuteReader
                If datardr.HasRows Then
                    datardr.Read()

                    lblFees.Text = datardr("FEES")
                    lblTotalFeeBalance.Text = Integer.Parse(lblFees.Text) - Integer.Parse(lblTotalFeeReceived.Text)
                End If

            End If
        Catch ex As Exception
            MsgBox("Error retrieving fee details for selected class. Please try again")
        Finally
            db.disconnect(conn)
        End Try

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Try
            changes = True
            Dim frm As New StudentInfo.AddSupplies
            frm.Owner = Me
            Dim dt As New DataTable
            dt.Columns.Add("Item", GetType(String))
            dt.PrimaryKey = New DataColumn() {dt.Columns("Item")}
            Dim row As DataRow
            For Each item As ListViewItem In listSupplies.Items
                row = dt.NewRow
                row("Item") = item.SubItems(0).Text

                dt.Rows.Add(row)

            Next
            frm.populate_list(dt)
            frm.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub populate_listview(ByVal dt As DataTable)

        'listSupplies.Items.Clear()
        supplyNoREGN = True
        Dim newRow As DataRow
        For Each newRow In dt.Rows
            listSupplies.Items.Add(newRow.Item(0))
            listSupplies.Items(listSupplies.Items.Count - 1).SubItems.Add(newRow.Item(1))
        Next

        Dim Sql As String

        If dt.Rows.Count > 0 AndAlso txtStudentID.TextLength > 0 Then
            conn = db.connect()
            supplyNoREGN = False
            newRow = dt.Rows(0)
            Sql = "INSERT INTO `prajwal_school_app`.`supply_details` (`SUPPLY`, `FEES`, `REGN`) " &
                       "VALUES "
            Sql += " ('" & newRow.Item(0) & "', '" & newRow.Item(1) & "', '" & txtStudentID.Text & "') "

            If dt.Rows.Count > 1 Then
                For i As Integer = 1 To listSupplies.Items.Count - 1
                    newRow = dt.Rows(i)
                    Sql += ", ('" & newRow.Item(0) & "', '" & newRow.Item(1) & "', '" & txtStudentID.Text & "') "
                Next
            End If

            cmd = New MySqlCommand(Sql, conn)
            cmd.ExecuteNonQuery()
            db.disconnect(conn)

        End If

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Try
            changes = True
            If txtStudentID.TextLength > 0 AndAlso listSupplies.SelectedItems.Count > 0 Then
                Dim Sql As String
                conn = db.connect()
                Sql = "DELETE FROM `prajwal_school_app`.`supply_details` where "
                Sql += " (SUPPLY = '" & listSupplies.SelectedItems(0).SubItems(0).Text & "'"
                listSupplies.SelectedItems(0).Remove()
                If listSupplies.SelectedItems.Count > 0 Then
                    For Each item As ListViewItem In listSupplies.SelectedItems
                        Sql += " OR SUPPLY = '" & item.SubItems(0).Text & "'"
                        item.Remove()
                    Next
                End If
                Sql += ") AND REGN = '" & txtStudentID.Text & "'"
                cmd = New MySqlCommand(Sql, conn)
                cmd.ExecuteNonQuery()

            Else
                For Each item As ListViewItem In listSupplies.SelectedItems
                    item.Remove()

                Next
            End If

        Catch ex As Exception
            MsgBox("Error Deleting items. Please Try again")
        Finally
            db.disconnect(conn)
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim frm As New StudentInfo.StudentSearch
        frm.Owner = Me
        frm.Show()
    End Sub

    Private Sub btnPrevPay_Click(sender As Object, e As EventArgs) Handles btnPrevPay.Click

        Try
            conn = db.connect()
            Dim Sql = "Select SUM(FEES_RECV) from `prajwal_school_app`.`fee_details` where STUD_ID = '" & txtStudentID.Text & "';"
            cmd.CommandText = Sql
            cmd.Connection = conn
            dadapter.SelectCommand = cmd

            If IsDBNull(cmd.ExecuteScalar) Then
                MsgBox("No Previous Payment Records Found")
            Else
                Dim frm As New StudentInfo.PreviousPayments
                frm.lblPresFees.Text = Me.lblFees.Text
                frm.lblStudName.Text = Me.txtFirstName.Text + " " + Me.txtLastName.Text
                frm.lblREGN.Text = Me.txtStudentID.Text
                frm.Show()
            End If
        Catch ex As Exception
            MsgBox("Error loading previous payments")
        Finally
            db.disconnect(conn)
        End Try

    End Sub

    Public Sub UpdatePaymentDetails()
        conn = db.connect()
        Dim Sql As String
        Sql = "Select SUM(FEES_RECV) from `prajwal_school_app`.`fee_details` where STUD_ID = '" & txtStudentID.Text & "';"
        cmd.CommandText = Sql
        cmd.Connection = conn
        dadapter.SelectCommand = cmd

        Try
            datardr = cmd.ExecuteReader
            If datardr.HasRows Then
                datardr.Read()
                lblTotalFeeReceived.Text = datardr("SUM(FEES_RECV)")
                lblTotalFeeBalance.Text = Integer.Parse(lblFees.Text) - Integer.Parse(lblTotalFeeReceived.Text)
                lblTotalFeeBalance.Visible = True
                lblTotalFeeReceived.Visible = True
            End If

        Catch ex As Exception
            lblTotalFeeBalance.Visible = True
            lblTotalFeeReceived.Visible = True
            lblTotalFeeReceived.Text = 0
            lblTotalFeeBalance.Text = lblFees.Text
        Finally
            db.disconnect(conn)
        End Try
    End Sub

    Public Sub populateStudentDetails(ByVal ID As String)

        Try
            conn = db.connect()
            Dim Sql As String = "Select FIRST_NAME, LAST_NAME, DOB, SECTION, CLASS, ADDRESS from `prajwal_school_app`.`student` where REGN = '" & ID & "';"
            cmd.CommandText = Sql
            cmd.Connection = conn
            dadapter.SelectCommand = cmd

            datardr = cmd.ExecuteReader
            If datardr.HasRows Then
                datardr.Read()

                txtFirstName.Text = datardr("FIRST_NAME")
                txtAddress.Text = datardr("ADDRESS")
                txtLastName.Text = datardr("LAST_NAME")
                dtDOB.Text = datardr("DOB")
                txtSection.Text = datardr("SECTION")
                cmbClass.SelectedIndex = datardr("CLASS")
                studFound = True
            Else
                MsgBox("Student Data Not Found")
                studFound = False
            End If
            datardr.Close()

            If studFound = True Then
                Sql = "Select * from `prajwal_school_app`.`fee_structure` where CLASS = '" & cmbClass.SelectedIndex - 1 & "';"
                cmd.CommandText = Sql
                'cmd.Connection = conn
                dadapter.SelectCommand = cmd

                datardr = cmd.ExecuteReader
                If datardr.HasRows Then
                    datardr.Read()

                    lblFees.Text = datardr("FEES")

                End If
                datardr.Close()

                Sql = "Select SUM(FEES_RECV) from `prajwal_school_app`.`fee_details` where STUD_ID = '" & txtStudentID.Text & "';"
                cmd.CommandText = Sql
                'cmd.Connection = conn
                dadapter.SelectCommand = cmd

                Try
                    datardr = cmd.ExecuteReader
                    If datardr.HasRows Then
                        datardr.Read()
                        lblTotalFeeReceived.Text = datardr("SUM(FEES_RECV)")
                        lblTotalFeeBalance.Text = Integer.Parse(lblFees.Text) - Integer.Parse(lblTotalFeeReceived.Text)
                        lblTotalFeeBalance.Visible = True
                        lblTotalFeeReceived.Visible = True
                    End If

                Catch ex As Exception
                    lblTotalFeeBalance.Visible = True
                    lblTotalFeeReceived.Visible = True
                    lblTotalFeeReceived.Text = 0
                    lblTotalFeeBalance.Text = lblFees.Text
                End Try
                datardr.Close()

                Sql = "Select SUPPLY, FEES from `prajwal_school_app`.`supply_details` where REGN = '" & txtStudentID.Text & "';"

                Try
                    supplyNoREGN = False
                    cmd = New MySqlCommand(Sql, conn)
                    dadapter = New MySqlDataAdapter(cmd)
                    Dim ds As DataTable
                    ds = New DataTable
                    dadapter.Fill(ds)
                    Dim newRow As DataRow
                    For Each newRow In ds.Rows
                        Dim item As New ListViewItem(newRow.Item(0).ToString)
                        item.SubItems.Add(newRow.Item(1).ToString)
                        listSupplies.Items.Add(item)
                    Next
                    datardr.Close()

                Catch ex As Exception
                    MsgBox("Failed to retrieve student supplies")
                End Try
                changes = False
                init(1)
            End If
        Catch ex As Exception
            MsgBox("Error loading student details. Please Try again")
        Finally
            db.disconnect(conn)
        End Try

    End Sub

    Private Sub Form0_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If changes = False Then

        Else
            If MessageBox.Show("Unsaved data will be lost. Save Changes?", "Warning", MessageBoxButtons.YesNo) = DialogResult.No Then

            Else
                btnSave.PerformClick()
            End If
        End If
    End Sub

    Private Sub txtFirstName_TextChanged(sender As Object, e As EventArgs) Handles txtFirstName.TextChanged
        changes = True
    End Sub

    Private Sub txtLastName_TextChanged(sender As Object, e As EventArgs) Handles txtLastName.TextChanged
        changes = True
    End Sub

    Private Sub txtSection_TextChanged(sender As Object, e As EventArgs) Handles txtSection.TextChanged
        changes = True
    End Sub

    Private Sub dtDOB_ValueChanged(sender As Object, e As EventArgs) Handles dtDOB.ValueChanged
        changes = True
    End Sub
End Class
