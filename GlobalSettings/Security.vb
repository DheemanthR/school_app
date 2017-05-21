Public Class Security
    Private Sub btnUnlock_Click(sender As Object, e As EventArgs) Handles btnUnlock.Click
        Dim flag As Boolean = True

        If txtUserName.TextLength > 0 Then
            If txtUserName.Text = "prajwal_admin" Then

            Else
                flag = False
            End If
        Else
            flag = False
        End If

        If txtPassword.TextLength > 0 Then
            If txtPassword.Text = "Pbp080692" Then

            Else
                flag = False
            End If
        Else
            flag = False
        End If

        If flag Then
            Dim frm As New Settings
            frm.Show()
            Me.Close()
        Else
            MsgBox("Wrong username and password combination. Please try again.")
        End If
    End Sub

    Private Sub Security_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath)
    End Sub

    Private Sub txtUserName_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtUserName.PreviewKeyDown
        If e.KeyData = Keys.Enter Then

            Try
                If txtUserName.TextLength > 0 AndAlso txtPassword.TextLength > 0 Then
                    btnUnlock.PerformClick()
                ElseIf txtUserName.TextLength > 0 AndAlso Not txtPassword.TextLength > 0 Then
                    txtPassword.Focus()
                ElseIf Not txtUserName.TextLength > 0 AndAlso txtPassword.TextLength > 0 Then
                    txtUserName.Focus()
                End If

            Catch ex As Exception
                MsgBox(ex.Message)

            End Try

        End If
    End Sub

    Private Sub txtPassword_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtPassword.PreviewKeyDown
        If e.KeyData = Keys.Enter Then

            Try
                If txtUserName.TextLength > 0 AndAlso txtPassword.TextLength > 0 Then
                    btnUnlock.PerformClick()
                ElseIf txtUserName.TextLength > 0 AndAlso Not txtPassword.TextLength > 0 Then
                    txtPassword.Focus()
                ElseIf Not txtUserName.TextLength > 0 AndAlso txtPassword.TextLength > 0 Then
                    txtUserName.Focus()
                End If

            Catch ex As Exception
                MsgBox(ex.Message)

            End Try

        End If
    End Sub
End Class