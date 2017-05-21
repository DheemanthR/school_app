Imports MySql.Data.MySqlClient

Public Class AddItem
    Dim db As New DBOperations.Connection
    Dim conn As New MySqlConnection
    Dim cmd As New MySqlCommand
    Dim dadapter As New MySqlDataAdapter

    Private Sub AddItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            conn = db.connect(GlobalSettings.My.MySettings.Default.Branch)
            Dim sql As String = "INSERT INTO `student_supplies`(`ITEM`, `PRICE`) VALUES ('" & txtItemName.Text & "','" & txtPrice.Text & "')"
            cmd = New MySqlCommand(sql, conn)
            Dim result As Integer = cmd.ExecuteNonQuery()
            If Not result > 0 Then
                Throw New Exception
            Else
                sql = "SELECT ID FROM student_supplies WHERE ITEM LIKE '" & txtItemName.Text & "'"
                cmd = New MySqlCommand(sql, conn)
                dadapter.SelectCommand = cmd
                Dim id As Object = cmd.ExecuteScalar()
                If MsgBox("Item successfully added to database. Item ID is : '" & id & "'") = DialogResult.OK Then
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            db.disconnect(conn)
        End Try
    End Sub
End Class