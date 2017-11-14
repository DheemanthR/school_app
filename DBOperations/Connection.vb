Imports MySql.Data.MySqlClient

Public Class Connection
    Dim conn As New MySqlConnection

    Public Function connect(ByVal database As Integer) As MySqlConnection
        Dim DatabaseName As String
        Dim server As String
        Dim userName As String
        Dim password As String
        'conn = Nothing

        If database = 0 Then
            DatabaseName = "thams_byalya"
            server = "www.jyloke.com"
            userName = "prajwal_admin"
            password = "Pbp080692"
        Else
            DatabaseName = "prajwal_school_app"
            server = "www.jyloke.com"
            userName = "prajwal_admin"
            password = "Pbp080692"
        End If

        If Not conn Is Nothing Then
            conn.Close()
        End If

        Try
            conn.ConnectionString = String.Format("server={0}; user id={1}; password={2}; database={3}; pooling=false", server, userName, password, DatabaseName)
            conn.Open()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
        Return conn
    End Function

    Public Sub disconnect(ByRef conn As MySqlConnection)
        If Not conn Is Nothing Then
            conn.Close()
        End If
    End Sub
End Class
