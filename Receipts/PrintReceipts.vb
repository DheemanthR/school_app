Public Class PrintReceipts
    Private Sub btnPrintOldReceipt_Click(sender As Object, e As EventArgs) Handles btnPrintOldReceipt.Click
        Dim frm As New Print_Existing_Form
        frm.Show()
        Me.Close()
    End Sub

    Private Sub btnPrintNewReceipt_Click(sender As Object, e As EventArgs) Handles btnPrintNewReceipt.Click
        Dim frm As New NewReceipt
        frm.Show()
        Me.Close()
    End Sub
End Class
