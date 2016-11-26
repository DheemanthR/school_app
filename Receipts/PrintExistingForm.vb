Imports MySql.Data.MySqlClient

Public Class Print_Existing_Form

    Dim dr() As System.Data.DataRow
    Dim db As New DBOperations.Connection
    Dim conn As New MySqlConnection
    Dim cmd As New MySqlCommand
    Dim dadapter As New MySqlDataAdapter
    Dim datardr As MySqlDataReader
    Dim ds As DataTable
    Dim cl As DataTable

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            ListView1.Items.Clear()
            conn = db.connect()
            Dim param As Boolean = False
            Dim Sql As String = "Select ID, STUD_ID, AMOUNT, BALANCE, DATE, SUPPLIES From `prajwal_school_app`.`receipt_details` WHERE 1"
            If txtReceiptNum.Text.Length > 0 Then
                param = True
                Sql += " AND ID = '" & txtReceiptNum.Text & "'"
            End If
            If txtREGN.Text.Length > 0 Then
                param = True
                Sql += " AND STUD_ID = '" & txtREGN.Text & "'"
            End If
            If cmbClass.SelectedIndex > 0 Then
                param = True
                Sql += " AND CLASS = '" & cmbClass.SelectedIndex & "'"
            End If

            If Not dtReceipt.Text = " " Then
                param = True
                Dim dt As Date
                dt = dtReceipt.Value
                Dim dta As String
                dta = dt.ToString("yyyy-MM-dd")
                Sql += " AND DATE LIKE '" & dta & "%'"
            End If

            If txtFirstName.TextLength > 0 Then
                param = True
                Sql += " AND STUD_ID IN (SELECT REGN FROM student WHERE FIRST_NAME LIKE '" & txtFirstName.Text & "') "
            End If

            If txtLastName.TextLength > 0 Then
                param = True
                Sql += " AND STUD_ID IN (SELECT REGN FROM student WHERE LAST_NAME LIKE " & txtLastName.Text & ") "
            End If

            If cmbClass.SelectedIndex > 0 Then
                param = True
                Sql += " AND STUD_ID IN (SELECT REGN FROM student WHERE CLASS = " & cmbClass.SelectedIndex & ") "
            End If

            If param = False Then
                MsgBox("Please enter at least one parameter to search")
            Else

                cmd = New MySqlCommand(Sql, conn)
                dadapter = New MySqlDataAdapter(cmd)

                ds = New DataTable
                dadapter.Fill(ds)
                If ds.Rows.Count = 0 Then
                    stsLabel.Text = "No results matching the search criteria"
                Else
                    Sql = "Select ID, CLASS From `prajwal_school_app`.`classes` "

                    cl = New DataTable
                    cmd = New MySqlCommand(Sql, conn)
                    dadapter = New MySqlDataAdapter(cmd)
                    dadapter.Fill(cl)
                    Dim newRow As DataRow
                    For Each newRow In ds.Rows
                        ListView1.Items.Add(newRow.Item(0).ToString)
                        Sql = "Select FIRST_NAME, LAST_NAME, CLASS From `prajwal_school_app`.`student` WHERE REGN = " & newRow.Item(1)
                        cmd = New MySqlCommand(Sql, conn)
                        dadapter = New MySqlDataAdapter(cmd)
                        datardr = cmd.ExecuteReader
                        If datardr.HasRows Then
                            datardr.Read()
                            ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(datardr("FIRST_NAME"))
                            ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(datardr("LAST_NAME"))
                            dr = cl.Select("ID = '" & datardr("CLASS") & "'")
                            If dr.Length > 0 Then
                                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(dr(0)("CLASS").ToString)
                            End If

                        End If
                        ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(newRow.Item(2).ToString)
                        ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(newRow.Item(4).ToString)
                        datardr.Close()
                    Next

                    stsLabel.Text = "Search query executed successfully"
                End If
            End If
        Catch ex As Exception
            stsLabel.Text = "Error Retrieving Data"
        Finally
            db.disconnect(conn)
        End Try

    End Sub

    Private Sub Print_Existing_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath)
        dtReceipt.Format = DateTimePickerFormat.Custom
        dtReceipt.CustomFormat = " "
        txtReceiptNum.Focus()
    End Sub

    Private Sub dtReceipt_ValueChanged(sender As Object, e As EventArgs) Handles dtReceipt.ValueChanged
        dtReceipt.Format = DateTimePickerFormat.Short
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        Dim REGN As String
        Dim frm As New NewReceipt
        Dim feesAmt As Integer = 0
        Dim suppliesAmt As Integer = 0
        frm.GroupBox1.Enabled = False
        frm.GroupBox2.Enabled = False
        frm.ClassesTableAdapter.Fill(frm.Prajwal_school_appDataSet.classes)
        dr = ds.Select("ID = '" & ListView1.SelectedItems.Item(0).Text & "'")
        If dr.Length > 0 Then
            REGN = dr(0)("STUD_ID").ToString
            feesAmt = Integer.Parse(dr(0)("AMOUNT").ToString)
            frm.txtREGN.Text = REGN
            frm.dtReceipt.Value = dr(0)("DATE")
            frm.populateStudentDetails(REGN)
            If dr(0)("SUPPLIES") = 1 Then
                Dim sql As String = "SELECT ID, PARTICULARS,AMOUNT FROM particulars WHERE RECEIPT_ID = '" & dr(0)("ID") & "'"
                cmd = New MySqlCommand(sql, conn)
                dadapter = New MySqlDataAdapter(cmd)
                frm.particulars = New DataTable
                dadapter.Fill(frm.particulars)
            End If
            Dim i As Integer = 1
            For Each row As DataRow In frm.particulars.Rows
                row.Item(0) = i
                i += 1
                suppliesAmt += row.Item(2)
            Next
            feesAmt -= suppliesAmt
            frm.txtAmount.Text = feesAmt
            If feesAmt > 0 Then
                For Each row As DataRow In frm.particulars.Rows
                    row.Item(0) += 1
                Next
            End If
            frm.generateBill(dr(0)("ID"))
            frm.Show()
        End If

        Me.Close()
    End Sub
End Class