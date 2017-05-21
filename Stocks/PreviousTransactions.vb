Imports MySql.Data.MySqlClient

Public Class PreviousTransactions
    Dim db As New DBOperations.Connection
    Dim conn As New MySqlConnection
    Dim cmd As New MySqlCommand
    Dim dadapter As New MySqlDataAdapter
    Dim itemName As String

    Friend Sub getID(ByVal name As String)
        itemName = name
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub PreviousTransactions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath)
        lblItemName.Text = itemName
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        populateStock()
    End Sub

    Private Sub populateStock()
        Try
            conn = db.connect(GlobalSettings.My.MySettings.Default.Branch)
            Dim sql As String
            sql = "SELECT ID FROM student_supplies WHERE ITEM LIKE '" & itemName & "'"
            cmd = New MySqlCommand(sql, conn)
            dadapter.SelectCommand = cmd
            Dim id As Object = cmd.ExecuteScalar()
            sql = "SELECT CASE WHEN INFLOW > 0 AND OUTFLOW = 0 THEN 'Incoming' WHEN INFLOW = 0 AND OUTFLOW > 0 THEN 'Outgoing' END AS Transaction , CASE WHEN INFLOW > 0 AND OUTFLOW = 0 THEN INFLOW WHEN INFLOW = 0 AND OUTFLOW > 0 THEN OUTFLOW END AS Units, DATE from stock WHERE ITEM_ID = " & id
            Dim dt As New DataTable
            cmd = New MySqlCommand(sql, conn)
            dadapter = New MySqlDataAdapter(cmd)
            dadapter.Fill(dt)

            For Each newRow As DataRow In dt.Rows
                ListView1.Items.Add(newRow.Item(0))
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(newRow.Item(1))
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(newRow.Item(2))

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            db.disconnect(conn)
        End Try
    End Sub

End Class