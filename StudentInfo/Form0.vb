Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
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
    Dim picAvailable As Boolean
    Dim strPictureFileLocation As String
    Dim filename As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath)
        Me.ClassesTableAdapter.Fill(Me.Prajwal_school_appDataSet.classes)
        cmbClass.SelectedIndex = 0
        changes = False
        studFound = False
        supplyNoREGN = False
        picAvailable = False
        init(0)
        Cursor.Current = Cursors.Default
        BackgroundWorker1.WorkerReportsProgress = True
        BackgroundWorker1.WorkerSupportsCancellation = True
        'AddHandler BackgroundWorker1.DoWork, AddressOf Me.BackgroundFileDownload
        'AddHandler BackgroundWorker1.ProgressChanged, AddressOf Me.ProgressChanged
        'AddHandler BackgroundWorker1.RunWorkerCompleted, AddressOf Me.JobCompleted
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim resultMain As Integer
        Dim resultSupplies As Integer

        If validate_Form() = True Then

            If studFound = True Then

                Try
                    conn = db.connect(GlobalSettings.My.MySettings.Default.Branch)
                    Dim Sql As String
                    Dim dt As Date
                    dt = dtDOB.Value
                    Dim dta As String = dt.ToString("yyyy-MM-dd")
                    Sql = "UPDATE `student` SET `FIRST_NAME` = '" & txtFirstName.Text & "', `LAST_NAME` = '" & txtLastName.Text & "', `CLASS` = '" & cmbClass.SelectedIndex & "', `SECTION` = '" & txtSection.Text.ToUpper & "', `DOB` = '" & dta & "', `ADDRESS` = '" & txtAddress.Text & "' WHERE REGN = '" & txtStudentID.Text & "'"
                    cmd = New MySqlCommand(Sql, conn)
                    resultMain = cmd.ExecuteNonQuery

                    If resultMain > 0 Then
                        If MsgBox("Student Data Updated Successfully!") = DialogResult.OK Then
                            changes = False
                            stsMessage.Text = "Data Saved"
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
                    conn = db.connect(GlobalSettings.My.MySettings.Default.Branch)
                    Dim Sql As String
                    Dim REGN As Integer
                    Dim noSupplies As Boolean = True

                    Sql = "Select MAX(REGN) from `student`"
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

                    If picAvailable Then
                        Sql = "INSERT INTO `student` (`REGN`, `FIRST_NAME`, `LAST_NAME`, `CLASS`, `SECTION`, `DOB`, `ADDRESS`, `IMAGE`) " &
                                    "VALUES ('" & REGN & "', '" & txtFirstName.Text & "', '" & txtLastName.Text & "', '" & cmbClass.SelectedIndex & "', '" & txtSection.Text.ToUpper & "', '" & dta & "', '" & txtAddress.Text & "', '" & filename & "');"
                    Else
                        Sql = "INSERT INTO `student` (`REGN`, `FIRST_NAME`, `LAST_NAME`, `CLASS`, `SECTION`, `DOB`, `ADDRESS`) " &
                                    "VALUES ('" & REGN & "', '" & txtFirstName.Text & "', '" & txtLastName.Text & "', '" & cmbClass.SelectedIndex & "', '" & txtSection.Text.ToUpper & "', '" & dta & "', '" & txtAddress.Text & "');"
                    End If

                    cmd = New MySqlCommand(Sql, conn)
                    resultMain = cmd.ExecuteNonQuery

                    If supplyNoREGN = True AndAlso listSupplies.Items.Count > 0 Then
                        Sql = "INSERT INTO `supply_details` (`SUPPLY`, `FEES`, `REGN`) " &
                                   "VALUES "
                        Sql += " ('" & listSupplies.Items(0).SubItems(0).Text & "', '" & listSupplies.Items(0).SubItems(1).Text & "', '" & txtStudentID.Text & "') "

                        For i As Integer = 1 To listSupplies.Items.Count - 1
                            Sql += ", ('" & listSupplies.Items(0).SubItems(0).Text & "', '" & listSupplies.Items(0).SubItems(1).Text & "', '" & txtStudentID.Text & "') "
                        Next

                        cmd = New MySqlCommand(Sql, conn)
                        resultSupplies = cmd.ExecuteNonQuery
                        noSupplies = False

                        'Sql = "INSERT INTO stock VALUES CLOSING_STOCK = CLOSING_STOCK-1 WHERE "

                    End If


                    If resultMain = 1 AndAlso (resultSupplies > 0 Or noSupplies = True) Then
                        MsgBox("Student Data Saved Successfully! " & vbCrLf & vbCrLf & "REGN = " + REGN.ToString)
                        btnPrevPay.Enabled = True
                        btnFeeDetails.Enabled = True
                        Reset_Form()
                        stsMessage.Text = "Data Saved"
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
        Try
            txtStudentID.Text = ""
            txtFirstName.Text = ""
            txtLastName.Text = ""
            dtDOB.Text = ""
            txtAddress.Text = ""
            Me.ClassesTableAdapter.Fill(Me.Prajwal_school_appDataSet.classes)
            cmbClass.SelectedIndex = 0
            txtSection.Text = ""
            studFound = False
            dataChanged = False
            listSupplies.Items.Clear()
            PictureBox1.Image = Nothing
            lblPicBoxTap.Visible = True
            init(0)
            changes = False
            stsMessage.Text = "Form Reset Successfully"
        Catch ex As Exception
            MsgBox("An error occured while resetting the form. Please try again")
        End Try
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
            ElseIf txtFirstName.Text.Length > 0 AndAlso Not Regex.Match(txtFirstName.Text, "^[a-zA-Z\s]+$", RegexOptions.None).Success Then
                lblErrFirstName.Visible = True
                lblErrFirstName.Text = "Only alphabets and spaces allowed"
                result = False
            Else
                lblErrFirstName.Visible = False
            End If

            If txtLastName.Text.Length = 0 Then
                lblErrLastName.Visible = True
                lblErrLastName.Text = "Cannot be empty"
                result = False
            ElseIf txtLastName.Text.Length > 0 AndAlso Not Regex.Match(txtLastName.Text, "^[a-zA-Z.\s]+$", RegexOptions.None).Success Then
                lblErrLastName.Visible = True
                lblErrLastName.Text = "Only alphabets, dots and spaces allowed"
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
            PictureBox1.Enabled = False
            lblPicBoxTap.Enabled = False

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
            PictureBox1.Enabled = True
            lblPicBoxTap.Enabled = True

        End If

    End Sub

    Private Sub btnNewStudent_Click(sender As Object, e As EventArgs) Handles btnNewStudent.Click

        If changes = False Then
            Reset_Form()
            init(1)
            stsMessage.Text = "New Student Mode: Active"
        Else
            If MessageBox.Show("Unsaved data will be lost. Save Changes?", "Warning", MessageBoxButtons.YesNo) = DialogResult.No Then

            Else
                btnSave.PerformClick()
                Reset_Form()
                init(1)
                stsMessage.Text = "New Student Mode: Active"
            End If
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.DoubleClick, lblPicBoxTap.DoubleClick

        Try
            Dim fd As OpenFileDialog = New OpenFileDialog()

            fd.Title = "Select An Image"
            fd.InitialDirectory = "C:\"
            fd.Filter = "JPEG (*.jpg)|*.*"
            fd.FilterIndex = 0
            fd.RestoreDirectory = True

            If fd.ShowDialog() = DialogResult.OK Then
                Cursor = Cursors.WaitCursor
                strPictureFileLocation = fd.FileName
                PictureBox1.ImageLocation = strPictureFileLocation
                ProgressBar1.Visible = True
                lblPercentage.Visible = True
                lblPicBoxTap.Visible = False
                BackgroundWorker1.RunWorkerAsync()
                picAvailable = True
                Cursor = Cursors.Default
            End If
        Catch ex As Exception
            MsgBox("Error loading image. Please try only with JPG format.")
        End Try

    End Sub

    Private Sub btnFeeDetails_Click(sender As Object, e As EventArgs) Handles btnFeeDetails.Click

        If txtStudentID.TextLength > 0 Then
            If Not cmbClass.SelectedIndex = 0 Then
                Dim frm As New StudentInfo.FeeDetailsvb
                If Not Application.OpenForms().OfType(Of FeeDetailsvb).Any Then
                    frm.Owner = Me
                    frm.lblPresFees.Text = Me.lblFees.Text
                    frm.lblStudName.Text = Me.txtFirstName.Text + " " + Me.txtLastName.Text
                    frm.lblREGN.Text = Me.txtStudentID.Text
                    frm.totalFeeReceived = Integer.Parse(lblTotalFeeReceived.Text)
                    frm.Show()
                Else
                    frm.BringToFront()
                End If
            Else
                MsgBox("Please fill out other details first")
            End If
        Else
            MsgBox("Cannot enter fee details without saving student. Please save student data before entering fee details!")
        End If


    End Sub

    Private Sub cmbClass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClass.SelectedIndexChanged

        Try
            changes = True
            If cmbClass.SelectedIndex = 0 Then
                lblFees.Visible = False

            Else
                Cursor = Cursors.WaitCursor
                lblFees.Visible = True
                conn = db.connect(GlobalSettings.My.MySettings.Default.Branch)
                Dim Sql As String = "Select * from `fee_structure` where CLASS = '" & cmbClass.SelectedIndex & "';"
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
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        If Not studFound = True Then
            MsgBox("Please save student data and reload student profile to add supplies.")
        Else

            Try
                changes = True
                Dim frm As New StudentInfo.AddSupplies
                If Not Application.OpenForms().OfType(Of AddSupplies).Any Then
                    frm.Owner = Me
                    frm.REGN = txtStudentID.Text
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
                Else
                    frm.BringToFront()
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Public Sub populate_listview(ByVal dt As DataTable)

        'listSupplies.Items.Clear()
        supplyNoREGN = True
        Dim newRow As DataRow
        'For Each newRow In dt.Rows
        '    If listSupplies.FindItemWithText(newRow(0)) = Then

        '    End If
        '    listSupplies.Items.Add(newRow.Item(0))
        '    listSupplies.Items(listSupplies.Items.Count - 1).SubItems.Add(newRow.Item(2))
        'Next

        Dim Sql As String

        If dt.Rows.Count > 0 AndAlso txtStudentID.TextLength > 0 Then
            conn = db.connect(GlobalSettings.My.MySettings.Default.Branch)
            supplyNoREGN = False
            newRow = dt.Rows(0)
            Sql = "INSERT INTO supply_details (`SUPPLY`, `QUANTITY`, `FEES`, `REGN`) " &
                       "VALUES "
            Sql += " ('" & newRow.Item(0) & "', '" & newRow.Item(2) & "', '" & newRow.Item(1) & "', '" & txtStudentID.Text & "') "

            If dt.Rows.Count > 1 Then
                For i As Integer = 1 To dt.Rows.Count - 1
                    newRow = dt.Rows(i)
                    Sql += ", ('" & newRow.Item(0) & "', '" & newRow.Item(2) & "', '" & newRow.Item(1) & "', '" & txtStudentID.Text & "') "
                Next
            End If

            cmd = New MySqlCommand(Sql, conn)
            cmd.ExecuteNonQuery()
            db.disconnect(conn)

        End If

        listSupplies.Items.Clear()

        Sql = "Select SUPPLY, SUM(QUANTITY) from supply_details where REGN = '" & txtStudentID.Text & "' GROUP BY SUPPLY;"

        Try
            supplyNoREGN = False
            cmd = New MySqlCommand(Sql, conn)
            dadapter = New MySqlDataAdapter(cmd)
            Dim ds As DataTable
            ds = New DataTable
            dadapter.Fill(ds)

            For Each newRow In ds.Rows
                Dim item As New ListViewItem(newRow.Item(0).ToString)
                item.SubItems.Add(newRow.Item(1).ToString)
                listSupplies.Items.Add(item)
            Next
            datardr.Close()

        Catch ex As Exception
            MsgBox("Failed to reload student supplies list. Please try resetting form and reloading student profile")
            stsMessage.Text = "Failed to retrieve student supplies"
        End Try

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Try
            changes = True
            If txtStudentID.TextLength > 0 AndAlso listSupplies.SelectedItems.Count > 0 Then
                Dim Sql As String
                conn = db.connect(GlobalSettings.My.MySettings.Default.Branch)
                Sql = "DELETE FROM supply_details where "
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
        If Not Application.OpenForms().OfType(Of StudentSearch).Any Then
            frm.Owner = Me
            frm.Show()
        Else
            frm.BringToFront()
        End If

    End Sub

    Private Sub btnPrevPay_Click(sender As Object, e As EventArgs) Handles btnPrevPay.Click

        Try
            Dim frm As New StudentInfo.PreviousPayments
            If Not Application.OpenForms().OfType(Of PreviousPayments).Any Then
                conn = db.connect(GlobalSettings.My.MySettings.Default.Branch)
                Dim Sql = "Select SUM(FEES_RECV) from fee_details where STUD_ID = '" & txtStudentID.Text & "';"
                cmd.CommandText = Sql
                cmd.Connection = conn
                dadapter.SelectCommand = cmd

                If IsDBNull(cmd.ExecuteScalar) Then
                    MsgBox("No Previous Payment Records Found")
                Else
                    frm.lblPresFees.Text = Me.lblFees.Text
                    frm.lblStudName.Text = Me.txtFirstName.Text + " " + Me.txtLastName.Text
                    frm.lblREGN.Text = Me.txtStudentID.Text
                    frm.Show()
                End If
            Else
                frm.BringToFront()
            End If

        Catch ex As Exception
            MsgBox("Error loading previous payments")
        Finally
            db.disconnect(conn)
        End Try

    End Sub

    Public Sub UpdatePaymentDetails()
        conn = db.connect(GlobalSettings.My.MySettings.Default.Branch)
        Dim Sql As String
        Sql = "Select SUM(FEES_RECV) from fee_details where STUD_ID = '" & txtStudentID.Text & "';"
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
            conn = db.connect(GlobalSettings.My.MySettings.Default.Branch)
            Dim Sql As String = "Select FIRST_NAME, LAST_NAME, DOB, SECTION, CLASS, ADDRESS, IMAGE from student where REGN = '" & ID & "';"
            Dim dt As New DataTable
            cmd = New MySqlCommand(Sql, conn)
            dadapter = New MySqlDataAdapter(cmd)
            dadapter.Fill(dt)
            If dt.Rows.Count = 0 Then
                MsgBox("Student Data Not Found")
                stsMessage.Text = "Student Data Not Found"
                studFound = False
            Else
                txtFirstName.Text = dt.Rows(0).Item("FIRST_NAME")
                txtAddress.Text = dt.Rows(0).Item("ADDRESS")
                txtLastName.Text = dt.Rows(0).Item("LAST_NAME")
                dtDOB.Text = dt.Rows(0).Item("DOB")
                txtSection.Text = dt.Rows(0).Item("SECTION")
                cmbClass.SelectedIndex = Integer.Parse(dt.Rows(0).Item("CLASS"))
                strPictureFileLocation = dt.Rows(0).Item("IMAGE")
                studFound = True
            End If

            If studFound = True Then
                conn = db.connect(GlobalSettings.My.MySettings.Default.Branch)
                Sql = "Select * from fee_structure where CLASS = '" & cmbClass.SelectedIndex - 1 & "';"
                cmd.CommandText = Sql
                cmd.Connection = conn
                dadapter.SelectCommand = cmd

                datardr = cmd.ExecuteReader
                If datardr.HasRows Then
                    datardr.Read()

                    lblFees.Text = datardr("FEES")

                End If
                datardr.Close()

                conn = db.connect(GlobalSettings.My.MySettings.Default.Branch)
                Sql = "Select SUM(FEES_RECV) from fee_details where STUD_ID = '" & txtStudentID.Text & "';"
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
                End Try
                datardr.Close()

                Sql = "Select SUPPLY, SUM(QUANTITY) from supply_details where REGN = '" & txtStudentID.Text & "' GROUP BY SUPPLY;"

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
                    stsMessage.Text = "Failed to retrieve student supplies"
                End Try

                'Load image

                BackgroundWorker2.RunWorkerAsync()
                changes = False
                lblPicBoxTap.Visible = False
                init(1)
                stsMessage.Text = "Student Data Retrieved Successfully"
            End If
        Catch ex As Exception
            MsgBox("Error loading student details. Please Try again")
            stsMessage.Text = "Could not retreive student details"
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

    Private Sub txtAddress_ValueChanged(sender As Object, e As EventArgs) Handles txtAddress.TextChanged
        changes = True
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        'Uploading the picture to server via FTP

        filename = DateTime.Now.ToString("yyyyMMddHHmmss")
        Dim request As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create("ftp://www.jyloke.com/" + filename + ".jpg"), System.Net.FtpWebRequest)
        request.Credentials = New System.Net.NetworkCredential("thams@jyloke.com", "3.FF}k5r`kPw")
        request.Method = System.Net.WebRequestMethods.Ftp.UploadFile
        Dim strz As System.IO.Stream

        Try
            stsMessage.Text = "Uploading student image..."
            Dim file() As Byte = System.IO.File.ReadAllBytes(strPictureFileLocation)
            strz = request.GetRequestStream()
            For offset As Integer = 0 To file.Length Step 1024
                BackgroundWorker1.ReportProgress(CType(offset * ProgressBar1.Maximum / file.Length, Integer))
                Dim chunkSize As Integer = file.Length - offset
                If chunkSize > 1024 Then chunkSize = 1024
                strz.Write(file, offset, chunkSize)
            Next
        Catch ex As Exception
            MsgBox("Uploading student image failed. Please try again.")
            stsMessage.Text = "Error uploading student image"
        Finally
            strz.Close()
            strz.Dispose()
        End Try

    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
        lblPercentage.Text = ProgressBar1.Value & " %"
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        ProgressBar1.Value = ProgressBar1.Maximum
        stsMessage.Text = "Image Uploaded. Ready to save student details."
        ProgressBar1.Visible = False
        lblPercentage.Visible = False
    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        'Downloading the picture to server via FTP
        Dim request As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create("ftp://www.jyloke.com/" + strPictureFileLocation + ".jpg"), System.Net.FtpWebRequest)
        request.Credentials = New System.Net.NetworkCredential("thams@jyloke.com", "3.FF}k5r`kPw")
        request.Method = System.Net.WebRequestMethods.Ftp.DownloadFile

        Dim response As System.Net.FtpWebResponse
        Dim reader As System.IO.StreamReader
        Try
            response = request.GetResponse()
            Dim responseStream As System.IO.Stream
            responseStream = response.GetResponseStream()
            reader = New System.IO.StreamReader(responseStream)
            Dim image As Image
            image = System.Drawing.Image.FromStream(responseStream)
            PictureBox1.Image = image
        Catch ex As Exception
            MsgBox("Failed to download image. Please try again.")
        Finally
            reader.Close()
            response.Close()
        End Try

    End Sub
End Class
