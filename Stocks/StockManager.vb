Imports MySql.Data.MySqlClient

Public Class StockManager
    Dim db As New DBOperations.Connection
    Dim conn As New MySqlConnection
    Dim cmd As New MySqlCommand
    Dim dadapter As New MySqlDataAdapter
    Private Sub StockManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath)
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub btnAddNewItem_Click(sender As Object, e As EventArgs) Handles btnAddNewItem.Click
        Dim frm As New AddItem
        frm.Show()
    End Sub

    Private Sub btnAddExisting_Click(sender As Object, e As EventArgs) Handles btnAddExisting.Click
        Dim frm As New AddStock
        frm.Owner = Me
        If ListView1.SelectedIndices.Count = 1 Then
            frm.getID(ListView1.SelectedItems.Item(0).SubItems(0).Text)
            frm.txtItemID.Enabled = False
            frm.txtIncomingStock.Focus()
            frm.BackgroundWorker1.RunWorkerAsync()
        End If
        frm.Show()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        populateStock()
    End Sub

    Public Sub populateStock()
        Try
            conn = db.connect(GlobalSettings.My.MySettings.Default.Branch)
            Dim sql As String
            'sql = "SELECT SS.ITEM, S.OPENING_STOCK, S.CLOSING_STOCK FROM stock S, student_supplies SS WHERE S.ITEM_ID = SS.ID" ' AND S.ID IN (SELECT MAX(ID) FROM stock WHERE ITEM_ID = '101')"
            sql = "SELECT SS.ITEM, s1.OPENING_STOCK, s1.CLOSING_STOCK
                   FROM student_supplies SS, stock s1 LEFT JOIN stock s2
                   ON (s1.ITEM_ID = s2.ITEM_ID AND s1.ID < s2.ID)
                   WHERE s2.ID IS NULL AND s1.ITEM_ID = SS.ID"
            Dim dt As New DataTable
            cmd = New MySqlCommand(sql, conn)
            dadapter = New MySqlDataAdapter(cmd)
            dadapter.Fill(dt)

            ListView1.Items.Clear()

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

    Private Sub ListView1_ItemActivate(sender As Object, e As EventArgs) Handles ListView1.ItemActivate
        btnViewTxn.Enabled = True
    End Sub

    Private Sub ListView1_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles ListView1.ItemSelectionChanged
        If ListView1.SelectedItems.Count = 1 Then
            btnViewTxn.Enabled = True
        Else
            btnViewTxn.Enabled = False
        End If
    End Sub

    Private Sub btnViewTxn_Click(sender As Object, e As EventArgs) Handles btnViewTxn.Click
        Dim frm As New PreviousTransactions
        frm.getID(ListView1.SelectedItems.Item(0).SubItems(0).Text)
        frm.Show()
    End Sub
End Class
