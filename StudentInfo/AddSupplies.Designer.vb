<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddSupplies
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAddSupplies = New System.Windows.Forms.Button()
        Me.btnCheckAll = New System.Windows.Forms.Button()
        Me.btnUncheckAll = New System.Windows.Forms.Button()
        Me.dgvSupplies = New System.Windows.Forms.DataGridView()
        Me.Selected = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Stock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvSupplies, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
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
        'dgvSupplies
        '
        Me.dgvSupplies.AllowUserToAddRows = False
        Me.dgvSupplies.AllowUserToDeleteRows = False
        Me.dgvSupplies.AllowUserToResizeRows = False
        Me.dgvSupplies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSupplies.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Selected, Me.Item, Me.Price, Me.Stock, Me.Quantity})
        Me.dgvSupplies.Location = New System.Drawing.Point(12, 29)
        Me.dgvSupplies.Name = "dgvSupplies"
        Me.dgvSupplies.RowHeadersVisible = False
        Me.dgvSupplies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSupplies.Size = New System.Drawing.Size(406, 322)
        Me.dgvSupplies.TabIndex = 5
        '
        'Selected
        '
        Me.Selected.Frozen = True
        Me.Selected.HeaderText = ""
        Me.Selected.Name = "Selected"
        Me.Selected.Width = 35
        '
        'Item
        '
        Me.Item.HeaderText = "Item"
        Me.Item.Name = "Item"
        Me.Item.ReadOnly = True
        Me.Item.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Item.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Item.Width = 208
        '
        'Price
        '
        Me.Price.HeaderText = "Price"
        Me.Price.Name = "Price"
        Me.Price.ReadOnly = True
        Me.Price.Width = 50
        '
        'Stock
        '
        Me.Stock.HeaderText = "Stock"
        Me.Stock.Name = "Stock"
        Me.Stock.ReadOnly = True
        Me.Stock.Width = 50
        '
        'Quantity
        '
        Me.Quantity.HeaderText = "Quantity"
        Me.Quantity.Name = "Quantity"
        Me.Quantity.Width = 60
        '
        'AddSupplies
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(430, 417)
        Me.Controls.Add(Me.dgvSupplies)
        Me.Controls.Add(Me.btnUncheckAll)
        Me.Controls.Add(Me.btnCheckAll)
        Me.Controls.Add(Me.btnAddSupplies)
        Me.Controls.Add(Me.Label1)
        Me.Name = "AddSupplies"
        Me.Text = "Add Supplies"
        CType(Me.dgvSupplies, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents btnAddSupplies As Button
    Friend WithEvents btnCheckAll As Button
    Friend WithEvents btnUncheckAll As Button
    Friend WithEvents dgvSupplies As DataGridView
    Friend WithEvents Selected As DataGridViewCheckBoxColumn
    Friend WithEvents Item As DataGridViewTextBoxColumn
    Friend WithEvents Price As DataGridViewTextBoxColumn
    Friend WithEvents Stock As DataGridViewTextBoxColumn
    Friend WithEvents Quantity As DataGridViewTextBoxColumn
End Class
