Imports MySql.Data.MySqlClient

Public Class StudentSearch

    Private Sub StudentSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath)
        dtDOB.Format = DateTimePickerFormat.Custom
        dtDOB.CustomFormat = " "
        'dtDOB.Value = Date.FromOADate(0)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim db As New DBOperations.Connection
        Dim conn As New MySqlConnection
        Dim cmd As New MySqlCommand
        Dim dadapter As New MySqlDataAdapter
        Dim ds As DataTable
        Dim cl As DataTable

        Try
            ListView1.Items.Clear()
            conn = db.connect()
            Dim param As Boolean = False
            Dim Sql As String = "Select REGN, FIRST_NAME, LAST_NAME, CLASS, SECTION, DOB, ADDRESS From `prajwal_school_app`.`student` WHERE 1"
            If txtFirstName.Text.Length > 0 Then
                param = True
                Sql += " AND FIRST_NAME LIKE '" & txtFirstName.Text & "'"
            End If
            If txtLastName.Text.Length > 0 Then
                param = True
                Sql += " AND LAST_NAME LIKE '" & txtLastName.Text & "'"
            End If
            If cmbClass.SelectedIndex > 0 Then
                param = True
                Sql += " AND CLASS = '" & cmbClass.SelectedIndex & "'"
            End If
            If txtSection.Text.Length > 0 Then
                param = True
                Sql += " AND SECTION LIKE '" & txtSection.Text & "'"
            End If
            If Not dtDOB.Text = " " Then
                param = True
                Dim dt As Date
                dt = dtDOB.Value
                Dim dta As String
                dta = dt.ToString("yyyy-MM-dd")
                Sql += " AND DOB LIKE '" & dta & "%'"
            End If

            Sql += " ORDER BY FIRST_NAME"
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
                    Dim dr() As System.Data.DataRow
                    cl = New DataTable
                    cmd = New MySqlCommand(Sql, conn)
                    dadapter = New MySqlDataAdapter(cmd)
                    dadapter.Fill(cl)
                    Dim newRow As DataRow
                    For Each newRow In ds.Rows
                        ListView1.Items.Add(newRow.Item(0).ToString)
                        ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(newRow.Item(1).ToString)
                        ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(newRow.Item(2).ToString)
                        dr = cl.Select("ID = '" & newRow.Item(3) & "'")
                        If dr.Length > 0 Then
                            ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(dr(0)("CLASS").ToString)
                        End If
                        ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(newRow.Item(4).ToString)
                        ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(newRow.Item(5).ToString)
                        ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(newRow.Item(6).ToString)
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

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        If ListView1.SelectedItems.Count = 0 Or ListView1.SelectedItems.Count > 1 Then
            'nothing
        Else
            Dim frm As New NewReceipt
            Dim REGN As String = ListView1.SelectedItems(0).SubItems(0).Text
            frm = CType(Owner, NewReceipt)
            frm.txtREGN.Text = REGN
            frm.populateStudentDetails(REGN)
            Me.Close()
        End If
    End Sub

    Private Sub dtDOB_ValueChanged(sender As Object, e As EventArgs) Handles dtDOB.ValueChanged
        dtDOB.Format = DateTimePickerFormat.Long
    End Sub
End Class