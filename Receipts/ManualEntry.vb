Public Class ManualEntry
    Dim slno As Integer
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ListView1.Items.Add(slno)
        slno += 1
        ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(txtparticulars.Text)
        ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(txtAmount.Text)
    End Sub

    Private Sub ManualEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        slno = 1
    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        For Each item As ListViewItem In ListView1.SelectedItems
            item.Remove()

        Next
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        'Dim dt As New DataSet1.BillDetailsDataTable
        'Dim newRow As DataRow
        'For Each item As ListViewItem In ListView1.Items
        '    newRow = dt.NewRow
        '    newRow.Item("Sl") = slno.ToString
        '    newRow.Item("Particulars") = txtparticulars.Text
        '    newRow.Item("Amount") = txtAmount.Text
        '    dt.Rows.Add(newRow)
        'Next


        Me.Close()

    End Sub
End Class