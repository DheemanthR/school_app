<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockManager
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
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.items = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.openStock = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.closeStock = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnViewTxn = New System.Windows.Forms.Button()
        Me.btnAddExisting = New System.Windows.Forms.Button()
        Me.btnAddNewItem = New System.Windows.Forms.Button()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "List of available items:"
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.items, Me.openStock, Me.closeStock})
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(13, 30)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(583, 552)
        Me.ListView1.TabIndex = 1
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'items
        '
        Me.items.Text = "Item"
        Me.items.Width = 349
        '
        'openStock
        '
        Me.openStock.Text = "Opening Stock"
        Me.openStock.Width = 115
        '
        'closeStock
        '
        Me.closeStock.Text = "Closing Stock"
        Me.closeStock.Width = 115
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnViewTxn)
        Me.GroupBox1.Controls.Add(Me.btnAddExisting)
        Me.GroupBox1.Controls.Add(Me.btnAddNewItem)
        Me.GroupBox1.Location = New System.Drawing.Point(603, 30)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(179, 552)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Manage Stock"
        '
        'btnViewTxn
        '
        Me.btnViewTxn.Enabled = False
        Me.btnViewTxn.Location = New System.Drawing.Point(7, 183)
        Me.btnViewTxn.Name = "btnViewTxn"
        Me.btnViewTxn.Size = New System.Drawing.Size(166, 54)
        Me.btnViewTxn.TabIndex = 2
        Me.btnViewTxn.Text = "View previous transactions"
        Me.btnViewTxn.UseVisualStyleBackColor = True
        '
        'btnAddExisting
        '
        Me.btnAddExisting.Location = New System.Drawing.Point(7, 112)
        Me.btnAddExisting.Name = "btnAddExisting"
        Me.btnAddExisting.Size = New System.Drawing.Size(166, 54)
        Me.btnAddExisting.TabIndex = 1
        Me.btnAddExisting.Text = "Add to existing stock"
        Me.btnAddExisting.UseVisualStyleBackColor = True
        '
        'btnAddNewItem
        '
        Me.btnAddNewItem.Location = New System.Drawing.Point(7, 42)
        Me.btnAddNewItem.Name = "btnAddNewItem"
        Me.btnAddNewItem.Size = New System.Drawing.Size(166, 54)
        Me.btnAddNewItem.TabIndex = 0
        Me.btnAddNewItem.Text = "Add New Item"
        Me.btnAddNewItem.UseVisualStyleBackColor = True
        '
        'BackgroundWorker1
        '
        '
        'StockManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(794, 594)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "StockManager"
        Me.Text = "Stock Manager"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents ListView1 As ListView
    Friend WithEvents items As ColumnHeader
    Friend WithEvents openStock As ColumnHeader
    Friend WithEvents closeStock As ColumnHeader
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnViewTxn As Button
    Friend WithEvents btnAddExisting As Button
    Friend WithEvents btnAddNewItem As Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
End Class
