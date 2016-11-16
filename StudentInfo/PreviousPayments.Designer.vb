<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PreviousPayments
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblREGN = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblStudName = New System.Windows.Forms.Label()
        Me.lblPresFees = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lvPayments = New System.Windows.Forms.ListView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Sl = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Amount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Balance = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.dtPaid = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BankDeposit = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BankDepDate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.remark = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblREGN)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblStudName)
        Me.GroupBox1.Controls.Add(Me.lblPresFees)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(689, 49)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Student Info"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(245, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "REGN No: "
        '
        'lblREGN
        '
        Me.lblREGN.AutoSize = True
        Me.lblREGN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblREGN.Location = New System.Drawing.Point(302, 23)
        Me.lblREGN.Name = "lblREGN"
        Me.lblREGN.Size = New System.Drawing.Size(32, 13)
        Me.lblREGN.TabIndex = 3
        Me.lblREGN.Text = "Test"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Student Name: "
        '
        'lblStudName
        '
        Me.lblStudName.AutoSize = True
        Me.lblStudName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStudName.Location = New System.Drawing.Point(87, 23)
        Me.lblStudName.Name = "lblStudName"
        Me.lblStudName.Size = New System.Drawing.Size(32, 13)
        Me.lblStudName.TabIndex = 1
        Me.lblStudName.Text = "Test"
        '
        'lblPresFees
        '
        Me.lblPresFees.AutoSize = True
        Me.lblPresFees.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPresFees.Location = New System.Drawing.Point(568, 18)
        Me.lblPresFees.Name = "lblPresFees"
        Me.lblPresFees.Size = New System.Drawing.Size(49, 20)
        Me.lblPresFees.TabIndex = 3
        Me.lblPresFees.Text = "6000"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(486, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Prescribed Fees:"
        '
        'lvPayments
        '
        Me.lvPayments.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Sl, Me.Amount, Me.Balance, Me.dtPaid, Me.BankDeposit, Me.BankDepDate, Me.remark})
        Me.lvPayments.FullRowSelect = True
        Me.lvPayments.GridLines = True
        Me.lvPayments.Location = New System.Drawing.Point(12, 100)
        Me.lvPayments.Name = "lvPayments"
        Me.lvPayments.Size = New System.Drawing.Size(691, 200)
        Me.lvPayments.TabIndex = 20
        Me.lvPayments.UseCompatibleStateImageBehavior = False
        Me.lvPayments.View = System.Windows.Forms.View.Details
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Payments: "
        '
        'Sl
        '
        Me.Sl.Text = "Sl. No"
        '
        'Amount
        '
        Me.Amount.Text = "Amount"
        Me.Amount.Width = 86
        '
        'Balance
        '
        Me.Balance.Text = "Balance"
        Me.Balance.Width = 91
        '
        'dtPaid
        '
        Me.dtPaid.Text = "Date"
        Me.dtPaid.Width = 83
        '
        'BankDeposit
        '
        Me.BankDeposit.Text = "Bank Deposit Amount"
        Me.BankDeposit.Width = 89
        '
        'BankDepDate
        '
        Me.BankDepDate.Text = "Bank Deposit Date"
        Me.BankDepDate.Width = 87
        '
        'remark
        '
        Me.remark.Text = "Remarks"
        Me.remark.Width = 191
        '
        'PreviousPayments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(715, 314)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lvPayments)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "PreviousPayments"
        Me.Text = "Previous Payments"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblREGN As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblStudName As Label
    Friend WithEvents lblPresFees As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lvPayments As ListView
    Friend WithEvents Sl As ColumnHeader
    Friend WithEvents Amount As ColumnHeader
    Friend WithEvents Balance As ColumnHeader
    Friend WithEvents dtPaid As ColumnHeader
    Friend WithEvents BankDeposit As ColumnHeader
    Friend WithEvents Label4 As Label
    Friend WithEvents BankDepDate As ColumnHeader
    Friend WithEvents remark As ColumnHeader
End Class
