Imports MySql.Data.MySqlClient

Public Class Connection
    Dim conn As New MySqlConnection

    Public Function connect() As MySqlConnection
        Dim DatabaseName As String = "prajwal_school_app"
        Dim server As String = "www.jyloke.com"
        Dim userName As String = "prajwal_admin"
        Dim password As String = "Pbp080692"
        If Not conn Is Nothing Then conn.Close()
        conn.ConnectionString = String.Format("server={0}; user id={1}; password={2}; database={3}; pooling=false", server, userName, password, DatabaseName)
        Try
            conn.Open()
            Return conn
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Sub disconnect(ByRef conn As MySqlConnection)
        conn.Close()
    End Sub
End Class
