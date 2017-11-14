Imports System.Text.RegularExpressions
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

        If formValid() Then

            Try
                conn = db.connect(GlobalSettings.My.MySettings.Default.Branch)
                Dim sql As String = "INSERT INTO `student_supplies`(`ITEM`, `PRICE`, `OPENING_STOCK`, `CLOSING_STOCK`) VALUES ('" & txtItemName.Text & "','" & txtPrice.Text & "','" & txtOpeningStock.Text & "','" & txtOpeningStock.Text & "')"
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

        End If

    End Sub

    Private Function formValid() As Boolean
        Dim result As Boolean = True

        If txtOpeningStock.Text.Length >= 1 AndAlso Not Regex.Match(txtOpeningStock.Text, "^[0-9]+$", RegexOptions.None).Success Then
            lblErrStock.Visible = True
            result = False
        End If

        If txtPrice.Text.Length >= 1 AndAlso Not Regex.Match(txtPrice.Text, "^[0-9]+$", RegexOptions.None).Success Then
            lblErrPrice.Visible = True
            result = False
        End If

        Return result

    End Function

End Class