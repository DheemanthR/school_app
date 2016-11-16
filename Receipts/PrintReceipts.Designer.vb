<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintReceipts
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnPrintOldReceipt = New System.Windows.Forms.Button()
        Me.btnPrintNewReceipt = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnPrintOldReceipt
        '
        Me.btnPrintOldReceipt.Location = New System.Drawing.Point(40, 45)
        Me.btnPrintOldReceipt.Name = "btnPrintOldReceipt"
        Me.btnPrintOldReceipt.Size = New System.Drawing.Size(409, 92)
        Me.btnPrintOldReceipt.TabIndex = 0
        Me.btnPrintOldReceipt.Text = "Print old receipt"
        Me.btnPrintOldReceipt.UseVisualStyleBackColor = True
        '
        'btnPrintNewReceipt
        '
        Me.btnPrintNewReceipt.Location = New System.Drawing.Point(40, 179)
        Me.btnPrintNewReceipt.Name = "btnPrintNewReceipt"
        Me.btnPrintNewReceipt.Size = New System.Drawing.Size(409, 93)
        Me.btnPrintNewReceipt.TabIndex = 1
        Me.btnPrintNewReceipt.Text = "Print new receipt"
        Me.btnPrintNewReceipt.UseVisualStyleBackColor = True
        '
        'PrintReceipts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(488, 324)
        Me.Controls.Add(Me.btnPrintNewReceipt)
        Me.Controls.Add(Me.btnPrintOldReceipt)
        Me.Name = "PrintReceipts"
        Me.Text = "Print Receipt"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnPrintOldReceipt As Button
    Friend WithEvents btnPrintNewReceipt As Button
End Class
