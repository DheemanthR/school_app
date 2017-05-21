Public Class Settings
    Dim db As New DBOperations.Connection
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim newServer, newUser, newPass, newDB As String

    Private Sub cmbBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBranch.SelectionChangeCommitted
        If MsgBox("Sure to change branch to " & cmbBranch.SelectedItem.ToString & "?", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            My.Settings.Branch = cmbBranch.SelectedIndex
        Else
            cmbBranch.SelectedIndex = My.Settings.Branch
        End If
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        If MsgBox("Revert to default credentials?", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            txtServerName.Text = My.Settings.ServerName
            txtUserName.Text = My.Settings.UserName
            txtPassword.Text = My.Settings.Password
            txtDbName.Text = My.Settings.DatabaseName
        Else

        End If
    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath)
        txtServerName.Text = My.Settings.ServerName
        txtUserName.Text = My.Settings.UserName
        txtPassword.Text = My.Settings.Password
        txtDbName.Text = My.Settings.DatabaseName
        cmbBranch.SelectedIndex = My.Settings.Branch

    End Sub

    Private Sub btnTestConn_Click(sender As Object, e As EventArgs) Handles btnTestConn.Click
        newServer = txtServerName.Text
        newUser = txtUserName.Text
        newPass = txtPassword.Text
        newDB = txtDbName.Text
        Try
            If Not conn Is Nothing Then conn.Close()
            conn.ConnectionString = String.Format("server={0}; user id={1}; password={2}; database={3}; pooling=false", newServer, newUser, newPass, newDB)
            conn.Open()
            If conn Is Nothing Then
                If MsgBox("Connection failed with new database credentials. Revert to default credentials?", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    txtServerName.Text = My.Settings.ServerName
                    txtUserName.Text = My.Settings.UserName
                    txtPassword.Text = My.Settings.Password
                    txtDbName.Text = My.Settings.DatabaseName
                Else
                    My.Settings.ServerName = txtServerName.Text
                    My.Settings.UserName = txtUserName.Text
                    My.Settings.Password = txtPassword.Text
                    My.Settings.DatabaseName = txtDbName.Text
                End If
            Else
                MsgBox("Database connection successful! New credentials saved.")
            End If
        Catch ex As Exception
            If MsgBox("Connection failed with new database credentials. Revert to default credentials?", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                txtServerName.Text = My.Settings.ServerName
                txtUserName.Text = My.Settings.UserName
                txtPassword.Text = My.Settings.Password
                txtDbName.Text = My.Settings.DatabaseName
            Else
                My.Settings.ServerName = txtServerName.Text
                My.Settings.UserName = txtUserName.Text
                My.Settings.Password = txtPassword.Text
                My.Settings.DatabaseName = txtDbName.Text
            End If
        Finally
            db.disconnect(conn)
        End Try

    End Sub

    Private Sub Settings_Close(sender As Object, e As EventArgs) Handles MyBase.FormClosing
        My.Settings.Save()
    End Sub
End Class