<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddSupplies
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
        Me.lvSupplies = New System.Windows.Forms.ListView()
        Me.Items = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Price = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAddSupplies = New System.Windows.Forms.Button()
        Me.btnCheckAll = New System.Windows.Forms.Button()
        Me.btnUncheckAll = New System.Windows.Forms.Button()
        Me.Stock = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'lvSupplies
        '
        Me.lvSupplies.BackColor = System.Drawing.SystemColors.Window
        Me.lvSupplies.CheckBoxes = True
        Me.lvSupplies.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Items, Me.Price, Me.Stock})
        Me.lvSupplies.FullRowSelect = True
        Me.lvSupplies.GridLines = True
        Me.lvSupplies.Location = New System.Drawing.Point(13, 43)
        Me.lvSupplies.Name = "lvSupplies"
        Me.lvSupplies.Size = New System.Drawing.Size(403, 308)
        Me.lvSupplies.TabIndex = 0
        Me.lvSupplies.UseCompatibleStateImageBehavior = False
        Me.lvSupplies.View = System.Windows.Forms.View.Details
        '
        'Items
        '
        Me.Items.Text = "Items"
        Me.Items.Width = 256
        '
        'Price
        '
        Me.Price.Text = "Price"
        Me.Price.Width = 83
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Available Supplies:"
        '
        'btnAddSupplies
        '
        Me.btnAddSupplies.Location = New System.Drawing.Point(198, 357)
        Me.btnAddSupplies.Name = "btnAddSupplies"
        Me.btnAddSupplies.Size = New System.Drawing.Size(219, 50)
        Me.btnAddSupplies.TabIndex = 2
        Me.btnAddSupplies.Text = "Add"
        Me.btnAddSupplies.UseVisualStyleBackColor = True
        '
        'btnCheckAll
        '
        Me.btnCheckAll.Location = New System.Drawing.Point(13, 357)
        Me.btnCheckAll.Name = "btnCheckAll"
        Me.btnCheckAll.Size = New System.Drawing.Size(179, 23)
        Me.btnCheckAll.TabIndex = 3
        Me.btnCheckAll.Text = "Check All"
        Me.btnCheckAll.UseVisualStyleBackColor = True
        '
        'btnUncheckAll
        '
        Me.btnUncheckAll.Location = New System.Drawing.Point(13, 384)
        Me.btnUncheckAll.Name = "btnUncheckAll"
        Me.btnUncheckAll.Size = New System.Drawing.Size(179, 23)
        Me.btnUncheckAll.TabIndex = 4
        Me.btnUncheckAll.Text = "Uncheck All"
        Me.btnUncheckAll.UseVisualStyleBackColor = True
        '
        'Stock
        '
        Me.Stock.Text = "Stock"
        '
        'AddSupplies
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(430, 417)
        Me.Controls.Add(Me.btnUncheckAll)
        Me.Controls.Add(Me.btnCheckAll)
        Me.Controls.Add(Me.btnAddSupplies)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lvSupplies)
        Me.Name = "AddSupplies"
        Me.Text = "Add Supplies"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lvSupplies As ListView
    Friend WithEvents Label1 As Label
    Friend WithEvents btnAddSupplies As Button
    Friend WithEvents Items As ColumnHeader
    Friend WithEvents Price As ColumnHeader
    Friend WithEvents btnCheckAll As Button
    Friend WithEvents btnUncheckAll As Button
    Friend WithEvents Stock As ColumnHeader
End Class
