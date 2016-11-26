Public Class ManualEntry
    Dim slno As Integer
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If txtparticulars.TextLength > 0 AndAlso txtAmount.TextLength > 0 Then
            ListView1.Items.Add(slno)
            slno += 1
            ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(txtparticulars.Text)
            ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(txtAmount.Text)
            txtAmount.Clear()
            txtparticulars.Clear()
        End If
    End Sub

    Public Sub populateListView(ByVal dt As DataTable)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                ListView1.Items.Add(row.Item(0).ToString)
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(row.Item(1).ToString)
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(row.Item(2).ToString)
            Next
        End If

    End Sub

    Private Sub ManualEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath)
        If ListView1.Items.Count > 0 Then
            slno = Integer.Parse(ListView1.Items(ListView1.Items.Count - 1).SubItems(0).Text) + 1
        Else
            slno = 1
        End If
    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        For Each item As ListViewItem In ListView1.SelectedItems
            item.Remove()
        Next
        updateSlNo()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim dt As New DataTable
        dt.Columns.Add("Sl", GetType(Integer))
        dt.Columns.Add("Particulars", GetType(String))
        dt.Columns.Add("Amount", GetType(String))
        Dim newRow As DataRow
        For Each item As ListViewItem In ListView1.Items
            newRow = dt.NewRow
            newRow.Item("Sl") = item.SubItems(0).Text
            newRow.Item("Particulars") = item.SubItems(1).Text
            newRow.Item("Amount") = item.SubItems(2).Text
            dt.Rows.Add(newRow)
        Next
        Dim frm As New NewReceipt
        frm = CType(Owner, NewReceipt)
        frm.particulars = dt.Copy
        If frm.particulars.Rows.Count > 0 Then
            frm.manEntry = True
        End If
        Me.Close()

    End Sub

    Private Sub updateSlNo()
        slno = 1
        For Each item As ListViewItem In ListView1.Items
            item.SubItems(0).Text = slno
            slno += 1
        Next
    End Sub

End Class