<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FeeDetailsvb
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
        Me.lblStudName = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblPresFees = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFeeReceived = New System.Windows.Forms.TextBox()
        Me.txtFeeBalance = New System.Windows.Forms.TextBox()
        Me.txtBankDepAmt = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblREGN = New System.Windows.Forms.Label()
        Me.dtFeeReceived = New System.Windows.Forms.DateTimePicker()
        Me.dtBankDeposit = New System.Windows.Forms.DateTimePicker()
        Me.lblErrFeesReceived = New System.Windows.Forms.Label()
        Me.lblErrBankDepAmt = New System.Windows.Forms.Label()
        Me.lblErrDate = New System.Windows.Forms.Label()
        Me.lblErrBankDepDate = New System.Windows.Forms.Label()
        Me.lblErrRemarks = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.lblStudName.Location = New System.Drawing.Point(85, 23)
        Me.lblStudName.MaximumSize = New System.Drawing.Size(0, 40)
        Me.lblStudName.Name = "lblStudName"
        Me.lblStudName.Size = New System.Drawing.Size(32, 13)
        Me.lblStudName.TabIndex = 1
        Me.lblStudName.Text = "Test"
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
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 87)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Fees Received:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(258, 87)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Fees Balance:"
        '
        'txtFeeReceived
        '
        Me.txtFeeReceived.Location = New System.Drawing.Point(19, 112)
        Me.txtFeeReceived.Name = "txtFeeReceived"
        Me.txtFeeReceived.Size = New System.Drawing.Size(176, 20)
        Me.txtFeeReceived.TabIndex = 6
        '
        'txtFeeBalance
        '
        Me.txtFeeBalance.Location = New System.Drawing.Point(261, 112)
        Me.txtFeeBalance.Name = "txtFeeBalance"
        Me.txtFeeBalance.Size = New System.Drawing.Size(200, 20)
        Me.txtFeeBalance.TabIndex = 7
        '
        'txtBankDepAmt
        '
        Me.txtBankDepAmt.Location = New System.Drawing.Point(19, 186)
        Me.txtBankDepAmt.Name = "txtBankDepAmt"
        Me.txtBankDepAmt.Size = New System.Drawing.Size(176, 20)
        Me.txtBankDepAmt.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 161)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(113, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Bank Deposit Amount:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(258, 161)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 13)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Bank Deposit Date:"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(18, 260)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(684, 20)
        Me.txtRemarks.TabIndex = 13
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(15, 235)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 13)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Remarks:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(499, 87)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(33, 13)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Date:"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(330, 291)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(178, 39)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(527, 291)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(176, 39)
        Me.btnSave.TabIndex = 17
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblREGN)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblStudName)
        Me.GroupBox1.Controls.Add(Me.lblPresFees)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(689, 49)
        Me.GroupBox1.TabIndex = 18
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
        'dtFeeReceived
        '
        Me.dtFeeReceived.Location = New System.Drawing.Point(502, 112)
        Me.dtFeeReceived.Name = "dtFeeReceived"
        Me.dtFeeReceived.Size = New System.Drawing.Size(200, 20)
        Me.dtFeeReceived.TabIndex = 19
        '
        'dtBankDeposit
        '
        Me.dtBankDeposit.Location = New System.Drawing.Point(261, 186)
        Me.dtBankDeposit.Name = "dtBankDeposit"
        Me.dtBankDeposit.Size = New System.Drawing.Size(200, 20)
        Me.dtBankDeposit.TabIndex = 20
        '
        'lblErrFeesReceived
        '
        Me.lblErrFeesReceived.AutoSize = True
        Me.lblErrFeesReceived.ForeColor = System.Drawing.Color.Red
        Me.lblErrFeesReceived.Location = New System.Drawing.Point(17, 136)
        Me.lblErrFeesReceived.Name = "lblErrFeesReceived"
        Me.lblErrFeesReceived.Size = New System.Drawing.Size(192, 13)
        Me.lblErrFeesReceived.TabIndex = 39
        Me.lblErrFeesReceived.Text = "Amount cannot exceed prescribed fees"
        Me.lblErrFeesReceived.Visible = False
        '
        'lblErrBankDepAmt
        '
        Me.lblErrBankDepAmt.AutoSize = True
        Me.lblErrBankDepAmt.ForeColor = System.Drawing.Color.Red
        Me.lblErrBankDepAmt.Location = New System.Drawing.Point(17, 210)
        Me.lblErrBankDepAmt.Name = "lblErrBankDepAmt"
        Me.lblErrBankDepAmt.Size = New System.Drawing.Size(192, 13)
        Me.lblErrBankDepAmt.TabIndex = 40
        Me.lblErrBankDepAmt.Text = "Amount cannot exceed prescribed fees"
        Me.lblErrBankDepAmt.Visible = False
        '
        'lblErrDate
        '
        Me.lblErrDate.AutoSize = True
        Me.lblErrDate.ForeColor = System.Drawing.Color.Red
        Me.lblErrDate.Location = New System.Drawing.Point(502, 136)
        Me.lblErrDate.Name = "lblErrDate"
        Me.lblErrDate.Size = New System.Drawing.Size(201, 13)
        Me.lblErrDate.TabIndex = 41
        Me.lblErrDate.Text = "Date cannot be greater than current date"
        Me.lblErrDate.Visible = False
        '
        'lblErrBankDepDate
        '
        Me.lblErrBankDepDate.AutoSize = True
        Me.lblErrBankDepDate.ForeColor = System.Drawing.Color.Red
        Me.lblErrBankDepDate.Location = New System.Drawing.Point(260, 210)
        Me.lblErrBankDepDate.Name = "lblErrBankDepDate"
        Me.lblErrBankDepDate.Size = New System.Drawing.Size(201, 13)
        Me.lblErrBankDepDate.TabIndex = 42
        Me.lblErrBankDepDate.Text = "Date cannot be greater than current date"
        Me.lblErrBankDepDate.Visible = False
        '
        'lblErrRemarks
        '
        Me.lblErrRemarks.AutoSize = True
        Me.lblErrRemarks.ForeColor = System.Drawing.Color.Red
        Me.lblErrRemarks.Location = New System.Drawing.Point(16, 283)
        Me.lblErrRemarks.Name = "lblErrRemarks"
        Me.lblErrRemarks.Size = New System.Drawing.Size(130, 13)
        Me.lblErrRemarks.TabIndex = 43
        Me.lblErrRemarks.Text = "Character Not Allowed -> '"
        Me.lblErrRemarks.Visible = False
        '
        'FeeDetailsvb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(715, 343)
        Me.Controls.Add(Me.lblErrRemarks)
        Me.Controls.Add(Me.lblErrBankDepDate)
        Me.Controls.Add(Me.lblErrDate)
        Me.Controls.Add(Me.lblErrBankDepAmt)
        Me.Controls.Add(Me.lblErrFeesReceived)
        Me.Controls.Add(Me.dtBankDeposit)
        Me.Controls.Add(Me.dtFeeReceived)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtBankDepAmt)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtFeeBalance)
        Me.Controls.Add(Me.txtFeeReceived)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Name = "FeeDetailsvb"
        Me.Text = "Fee Details"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents lblStudName As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblPresFees As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtFeeReceived As TextBox
    Friend WithEvents txtFeeBalance As TextBox
    Friend WithEvents txtBankDepAmt As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblREGN As Label
    Friend WithEvents dtFeeReceived As DateTimePicker
    Friend WithEvents dtBankDeposit As DateTimePicker
    Friend WithEvents lblErrFeesReceived As Label
    Friend WithEvents lblErrBankDepAmt As Label
    Friend WithEvents lblErrDate As Label
    Friend WithEvents lblErrBankDepDate As Label
    Friend WithEvents lblErrRemarks As Label
End Class
