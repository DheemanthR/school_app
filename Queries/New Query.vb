Imports MySql.Data.MySqlClient

Public Class New_Query

    Dim db As New DBOperations.Connection
    Dim conn As New MySqlConnection
    Dim da As MySqlDataAdapter
    Dim dt As New DataTable
    Dim cmd As New MySqlCommand
    Dim sql As String
    Private Sub New_Query_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath)

        Try
            conn = db.connect(GlobalSettings.My.MySettings.Default.Branch)
            sql = "SELECT * FROM query_types"
            da = New MySqlDataAdapter(sql, conn)
            da.Fill(dt)
            cmbQueryType.DataSource = dt
            cmbQueryType.ValueMember = "ID"
            cmbQueryType.DisplayMember = "QUERY_TYPE"
        Catch ex As Exception
            MsgBox("Error loading query types. Please close this window and try reopening it.")
        Finally
            db.disconnect(conn)
        End Try

    End Sub

    Private Function validateForm() As Boolean
        Dim flag As Boolean = True

        If Not txtDesc.TextLength > 0 Then
            ErrorProvider1.SetError(txtDesc, "Description cannot be empty")
            flag = False
        End If

        If Not txtTitle.TextLength > 0 Then
            ErrorProvider1.SetError(txtTitle, "Query Title cannot be empty")
            flag = False
        End If
        Return flag
    End Function

    Private Sub btnRaise_Click(sender As Object, e As EventArgs) Handles btnRaise.Click
        Try
            If validateForm() Then
                conn = db.connect(GlobalSettings.My.MySettings.Default.Branch)
                sql = "INSERT INTO `queries`(`TITLE`, `DESCRIPTION`, `STATUS`, `URGENT_APPROVAL`, `QUERY_TYPE`, `IS_DELETED`) VALUES ('" & txtTitle.Text & "','" & txtDesc.Text & "','1','"
                If chkUrgentApproval.Checked = False Then
                    sql += "0','"
                Else
                    sql += "1','"
                End If
                sql += cmbQueryType.SelectedIndex & "','0')"
                cmd = New MySqlCommand(sql, conn)
                cmd.ExecuteNonQuery()
                If MsgBox("Query submitted successfully.") = DialogResult.OK Then
                    Dim frm As New QueryManeger
                    frm = CType(Owner, QueryManeger)
                    frm.populateForm()
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            db.disconnect(conn)
        End Try


    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class