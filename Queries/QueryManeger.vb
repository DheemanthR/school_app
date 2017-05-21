Imports MySql.Data.MySqlClient

Public Class QueryManeger
    Dim db As New DBOperations.Connection
    Dim conn As New MySqlConnection
    Dim cmd As New MySqlCommand
    Dim da As New MySqlDataAdapter
    Dim dqt As DataTable
    Dim dqs As DataTable
    Dim ds As DataTable
    Dim sql As String

    Private Sub btnRaiseQuery_Click(sender As Object, e As EventArgs) Handles btnRaiseQuery.Click
        Dim frm As New New_Query
        frm.Owner = Me
        frm.Show()
    End Sub

    Private Sub QueryManeger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath)
        Try
            Dim row As DataRow
            conn = db.connect(GlobalSettings.My.MySettings.Default.Branch)
            sql = "SELECT * FROM query_types"
            da = New MySqlDataAdapter(sql, conn)
            dqt = New DataTable
            da.Fill(dqt)
            row = dqt.NewRow
            row.Item(0) = 0
            row.Item(1) = "All"
            dqt.Rows.InsertAt(row, 0)
            cmbQueryType.DataSource = dqt
            cmbQueryType.ValueMember = "ID"
            cmbQueryType.DisplayMember = "QUERY_TYPE"

            sql = "SELECT * FROM query_statuses"
            da = New MySqlDataAdapter(sql, conn)
            dqs = New DataTable
            da.Fill(dqs)
            row = dqs.NewRow
            row.Item(0) = 0
            row.Item(1) = "All"
            dqs.Rows.InsertAt(row, 0)
            cmbStatus.DataSource = dqs
            cmbStatus.ValueMember = "ID"
            cmbStatus.DisplayMember = "STATUS"
            populateForm()
        Catch ex As Exception
            MsgBox("Error loading query types. Please close this window and try reopening it.")
        Finally
            db.disconnect(conn)
        End Try
    End Sub

    Public Sub populateForm()
        Try
            conn = db.connect(GlobalSettings.My.MySettings.Default.Branch)
            Dim sql As String = "Select TITLE,DESCRIPTION,STATUS,QUERY_TYPE from queries WHERE IS_DELETED = 0"
            cmd = New MySqlCommand(sql, conn)
            da = New MySqlDataAdapter(cmd)
            ds = New DataTable
            da.Fill(ds)
            Dim newRow As DataRow
            Dim row As DataRow
            ListView1.Items.Clear()

            For Each newRow In ds.Rows
                Dim item As New ListViewItem(newRow.Item(0).ToString)
                item.SubItems.Add(newRow.Item(1).ToString)
                row = dqt.Select("ID = " & newRow.Item(3)).FirstOrDefault
                item.SubItems.Add(row.Item(1))
                row = dqs.Select("ID = " & newRow.Item(2)).FirstOrDefault
                item.SubItems.Add(row.Item(1))
                ListView1.Items.Add(item)

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            db.disconnect(conn)
        End Try
    End Sub

    Private Sub cmbQueryType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbQueryType.SelectionChangeCommitted
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub filterResults()
        Try

            conn = db.connect(GlobalSettings.My.MySettings.Default.Branch)
            Dim sql As String = "Select TITLE,DESCRIPTION,STATUS,QUERY_TYPE from queries WHERE IS_DELETED = 0 "
            If Not cmbQueryType.SelectedIndex = 0 Then
                sql += " AND QUERY_TYPE = " & (cmbQueryType.SelectedIndex - 1)
            End If
            If Not cmbStatus.SelectedIndex = 0 Then
                sql += " AND STATUS = " & (cmbStatus.SelectedIndex - 1)
            End If

            cmd = New MySqlCommand(sql, conn)
            da = New MySqlDataAdapter(cmd)
            ds = New DataTable
            da.Fill(ds)
            Dim newRow As DataRow
            Dim row As DataRow
            ListView1.Items.Clear()

            For Each newRow In ds.Rows
                Dim item As New ListViewItem(newRow.Item(0).ToString)
                item.SubItems.Add(newRow.Item(1).ToString)
                row = dqt.Select("ID = " & newRow.Item(3)).FirstOrDefault
                item.SubItems.Add(row.Item(1))
                row = dqs.Select("ID = " & newRow.Item(2)).FirstOrDefault
                item.SubItems.Add(row.Item(1))
                ListView1.Items.Add(item)

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            db.disconnect(conn)
        End Try
    End Sub

    Private Sub cmbStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStatus.SelectionChangeCommitted
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Me.Cursor = Cursors.WaitCursor
        filterResults()
        Me.Cursor = Cursors.Default
    End Sub
End Class
