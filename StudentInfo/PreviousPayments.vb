Imports MySql.Data.MySqlClient

Public Class PreviousPayments
    Private Sub PreviousPayments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim db As New DBOperations.Connection
        Dim conn As New MySqlConnection
        Dim cmd As New MySqlCommand
        Dim dadapter As New MySqlDataAdapter
        Dim ds As DataTable

        Try
            Dim Sql = "Select * from `prajwal_school_app`.`fee_details` where STUD_ID = '" & lblREGN.Text & "';"
            conn = db.connect()
            cmd = New MySqlCommand(Sql, conn)
            dadapter = New MySqlDataAdapter(cmd)

            ds = New DataTable
            dadapter.Fill(ds)
            Dim newRow As DataRow
            Dim i As Integer = 1
            For Each newRow In ds.Rows
                lvPayments.Items.Add(i)
                lvPayments.Items(lvPayments.Items.Count - 1).SubItems.Add(newRow.Item(1).ToString)
                lvPayments.Items(lvPayments.Items.Count - 1).SubItems.Add(newRow.Item(2).ToString)
                lvPayments.Items(lvPayments.Items.Count - 1).SubItems.Add(newRow.Item(3).ToString)
                lvPayments.Items(lvPayments.Items.Count - 1).SubItems.Add(newRow.Item(4).ToString)
                lvPayments.Items(lvPayments.Items.Count - 1).SubItems.Add(newRow.Item(5).ToString)
                i += 1
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            db.disconnect(conn)
        End Try
    End Sub
End Class