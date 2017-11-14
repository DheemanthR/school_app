<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddItem
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtItemName = New System.Windows.Forms.TextBox()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.txtOpeningStock = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblErrStock = New System.Windows.Forms.Label()
        Me.lblErrPrice = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Item Name:"
        '
        'txtItemName
        '
        Me.txtItemName.Location = New System.Drawing.Point(16, 30)
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.Size = New System.Drawing.Size(455, 20)
        Me.txtItemName.TabIndex = 1
        '
        'txtPrice
        '
        Me.txtPrice.Location = New System.Drawing.Point(16, 91)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(455, 20)
        Me.txtPrice.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Price:"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(13, 209)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(223, 44)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "Add Item"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(248, 209)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(223, 44)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'txtOpeningStock
        '
        Me.txtOpeningStock.Location = New System.Drawing.Point(16, 152)
        Me.txtOpeningStock.Name = "txtOpeningStock"
        Me.txtOpeningStock.Size = New System.Drawing.Size(455, 20)
        Me.txtOpeningStock.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Opening Stock:"
        '
        'lblErrStock
        '
        Me.lblErrStock.AutoSize = True
        Me.lblErrStock.ForeColor = System.Drawing.Color.Red
        Me.lblErrStock.Location = New System.Drawing.Point(16, 176)
        Me.lblErrStock.Name = "lblErrStock"
        Me.lblErrStock.Size = New System.Drawing.Size(122, 13)
        Me.lblErrStock.TabIndex = 8
        Me.lblErrStock.Text = "Only Numbers Accepted"
        Me.lblErrStock.Visible = False
        '
        'lblErrPrice
        '
        Me.lblErrPrice.AutoSize = True
        Me.lblErrPrice.ForeColor = System.Drawing.Color.Red
        Me.lblErrPrice.Location = New System.Drawing.Point(16, 114)
        Me.lblErrPrice.Name = "lblErrPrice"
        Me.lblErrPrice.Size = New System.Drawing.Size(122, 13)
        Me.lblErrPrice.TabIndex = 9
        Me.lblErrPrice.Text = "Only Numbers Accepted"
        Me.lblErrPrice.Visible = False
        '
        'AddItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(483, 265)
        Me.Controls.Add(Me.lblErrPrice)
        Me.Controls.Add(Me.lblErrStock)
        Me.Controls.Add(Me.txtOpeningStock)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.txtPrice)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtItemName)
        Me.Controls.Add(Me.Label1)
        Me.Name = "AddItem"
        Me.Text = "Add Item"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtItemName As TextBox
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents txtOpeningStock As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents lblErrStock As Label
    Friend WithEvents lblErrPrice As Label
End Class
