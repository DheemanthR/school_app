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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.SchoolFees = New System.Windows.Forms.TabPage()
        Me.lblErrRemarks = New System.Windows.Forms.Label()
        Me.lblErrDate = New System.Windows.Forms.Label()
        Me.lblErrBankDepAmt = New System.Windows.Forms.Label()
        Me.lblErrFeesReceived = New System.Windows.Forms.Label()
        Me.dtBankDeposit = New System.Windows.Forms.DateTimePicker()
        Me.dtFeeReceived = New System.Windows.Forms.DateTimePicker()
        Me.lblErrBankDepDate = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtBankDepAmt = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFeeBalance = New System.Windows.Forms.TextBox()
        Me.txtFeeReceived = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.VanFees = New System.Windows.Forms.TabPage()
        Me.lblVanErrRemarks = New System.Windows.Forms.Label()
        Me.lblVanErrFeeDate = New System.Windows.Forms.Label()
        Me.lblVanErrBankDepAmt = New System.Windows.Forms.Label()
        Me.lblVanErrFeeReceived = New System.Windows.Forms.Label()
        Me.dtVanFeeBankDeposit = New System.Windows.Forms.DateTimePicker()
        Me.dtVanfeeReceived = New System.Windows.Forms.DateTimePicker()
        Me.lblVanErrBankDepDate = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtVanFeeRemarks = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtVanFeeBankDepAmt = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtVanFeeBalance = New System.Windows.Forms.TextBox()
        Me.txtVanFeeReceived = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblREGN = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblStudName = New System.Windows.Forms.Label()
        Me.lblPresFees = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.SchoolFees.SuspendLayout()
        Me.VanFees.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.SchoolFees)
        Me.TabControl1.Controls.Add(Me.VanFees)
        Me.TabControl1.Location = New System.Drawing.Point(7, 67)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(720, 279)
        Me.TabControl1.TabIndex = 0
        '
        'SchoolFees
        '
        Me.SchoolFees.Controls.Add(Me.lblErrRemarks)
        Me.SchoolFees.Controls.Add(Me.lblErrDate)
        Me.SchoolFees.Controls.Add(Me.lblErrBankDepAmt)
        Me.SchoolFees.Controls.Add(Me.lblErrFeesReceived)
        Me.SchoolFees.Controls.Add(Me.dtBankDeposit)
        Me.SchoolFees.Controls.Add(Me.dtFeeReceived)
        Me.SchoolFees.Controls.Add(Me.lblErrBankDepDate)
        Me.SchoolFees.Controls.Add(Me.Label10)
        Me.SchoolFees.Controls.Add(Me.txtRemarks)
        Me.SchoolFees.Controls.Add(Me.Label9)
        Me.SchoolFees.Controls.Add(Me.txtBankDepAmt)
        Me.SchoolFees.Controls.Add(Me.Label7)
        Me.SchoolFees.Controls.Add(Me.txtFeeBalance)
        Me.SchoolFees.Controls.Add(Me.txtFeeReceived)
        Me.SchoolFees.Controls.Add(Me.Label6)
        Me.SchoolFees.Controls.Add(Me.Label5)
        Me.SchoolFees.Controls.Add(Me.Label8)
        Me.SchoolFees.Location = New System.Drawing.Point(4, 22)
        Me.SchoolFees.Name = "SchoolFees"
        Me.SchoolFees.Padding = New System.Windows.Forms.Padding(3)
        Me.SchoolFees.Size = New System.Drawing.Size(712, 253)
        Me.SchoolFees.TabIndex = 0
        Me.SchoolFees.Text = "School Fees"
        Me.SchoolFees.UseVisualStyleBackColor = True
        '
        'lblErrRemarks
        '
        Me.lblErrRemarks.AutoSize = True
        Me.lblErrRemarks.ForeColor = System.Drawing.Color.Red
        Me.lblErrRemarks.Location = New System.Drawing.Point(13, 217)
        Me.lblErrRemarks.Name = "lblErrRemarks"
        Me.lblErrRemarks.Size = New System.Drawing.Size(130, 13)
        Me.lblErrRemarks.TabIndex = 63
        Me.lblErrRemarks.Text = "Character Not Allowed -> '"
        Me.lblErrRemarks.Visible = False
        '
        'lblErrDate
        '
        Me.lblErrDate.AutoSize = True
        Me.lblErrDate.ForeColor = System.Drawing.Color.Red
        Me.lblErrDate.Location = New System.Drawing.Point(499, 70)
        Me.lblErrDate.Name = "lblErrDate"
        Me.lblErrDate.Size = New System.Drawing.Size(201, 13)
        Me.lblErrDate.TabIndex = 61
        Me.lblErrDate.Text = "Date cannot be greater than current date"
        Me.lblErrDate.Visible = False
        '
        'lblErrBankDepAmt
        '
        Me.lblErrBankDepAmt.AutoSize = True
        Me.lblErrBankDepAmt.ForeColor = System.Drawing.Color.Red
        Me.lblErrBankDepAmt.Location = New System.Drawing.Point(14, 144)
        Me.lblErrBankDepAmt.Name = "lblErrBankDepAmt"
        Me.lblErrBankDepAmt.Size = New System.Drawing.Size(192, 13)
        Me.lblErrBankDepAmt.TabIndex = 60
        Me.lblErrBankDepAmt.Text = "Amount cannot exceed prescribed fees"
        Me.lblErrBankDepAmt.Visible = False
        '
        'lblErrFeesReceived
        '
        Me.lblErrFeesReceived.AutoSize = True
        Me.lblErrFeesReceived.ForeColor = System.Drawing.Color.Red
        Me.lblErrFeesReceived.Location = New System.Drawing.Point(14, 70)
        Me.lblErrFeesReceived.Name = "lblErrFeesReceived"
        Me.lblErrFeesReceived.Size = New System.Drawing.Size(192, 13)
        Me.lblErrFeesReceived.TabIndex = 59
        Me.lblErrFeesReceived.Text = "Amount cannot exceed prescribed fees"
        Me.lblErrFeesReceived.Visible = False
        '
        'dtBankDeposit
        '
        Me.dtBankDeposit.Location = New System.Drawing.Point(258, 120)
        Me.dtBankDeposit.Name = "dtBankDeposit"
        Me.dtBankDeposit.Size = New System.Drawing.Size(200, 20)
        Me.dtBankDeposit.TabIndex = 58
        '
        'dtFeeReceived
        '
        Me.dtFeeReceived.Location = New System.Drawing.Point(499, 46)
        Me.dtFeeReceived.Name = "dtFeeReceived"
        Me.dtFeeReceived.Size = New System.Drawing.Size(200, 20)
        Me.dtFeeReceived.TabIndex = 57
        '
        'lblErrBankDepDate
        '
        Me.lblErrBankDepDate.AutoSize = True
        Me.lblErrBankDepDate.ForeColor = System.Drawing.Color.Red
        Me.lblErrBankDepDate.Location = New System.Drawing.Point(257, 144)
        Me.lblErrBankDepDate.Name = "lblErrBankDepDate"
        Me.lblErrBankDepDate.Size = New System.Drawing.Size(201, 13)
        Me.lblErrBankDepDate.TabIndex = 62
        Me.lblErrBankDepDate.Text = "Date cannot be greater than current date"
        Me.lblErrBankDepDate.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(496, 21)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(33, 13)
        Me.Label10.TabIndex = 53
        Me.Label10.Text = "Date:"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(15, 194)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(684, 20)
        Me.txtRemarks.TabIndex = 52
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 169)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 13)
        Me.Label9.TabIndex = 51
        Me.Label9.Text = "Remarks:"
        '
        'txtBankDepAmt
        '
        Me.txtBankDepAmt.Location = New System.Drawing.Point(16, 120)
        Me.txtBankDepAmt.Name = "txtBankDepAmt"
        Me.txtBankDepAmt.Size = New System.Drawing.Size(176, 20)
        Me.txtBankDepAmt.TabIndex = 49
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 95)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(113, 13)
        Me.Label7.TabIndex = 48
        Me.Label7.Text = "Bank Deposit Amount:"
        '
        'txtFeeBalance
        '
        Me.txtFeeBalance.Location = New System.Drawing.Point(258, 46)
        Me.txtFeeBalance.Name = "txtFeeBalance"
        Me.txtFeeBalance.Size = New System.Drawing.Size(200, 20)
        Me.txtFeeBalance.TabIndex = 47
        '
        'txtFeeReceived
        '
        Me.txtFeeReceived.Location = New System.Drawing.Point(16, 46)
        Me.txtFeeReceived.Name = "txtFeeReceived"
        Me.txtFeeReceived.Size = New System.Drawing.Size(176, 20)
        Me.txtFeeReceived.TabIndex = 46
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(255, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 13)
        Me.Label6.TabIndex = 45
        Me.Label6.Text = "Fees Balance:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 13)
        Me.Label5.TabIndex = 44
        Me.Label5.Text = "Fees Received:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(255, 95)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 13)
        Me.Label8.TabIndex = 50
        Me.Label8.Text = "Bank Deposit Date:"
        '
        'VanFees
        '
        Me.VanFees.Controls.Add(Me.lblVanErrRemarks)
        Me.VanFees.Controls.Add(Me.lblVanErrFeeDate)
        Me.VanFees.Controls.Add(Me.lblVanErrBankDepAmt)
        Me.VanFees.Controls.Add(Me.lblVanErrFeeReceived)
        Me.VanFees.Controls.Add(Me.dtVanFeeBankDeposit)
        Me.VanFees.Controls.Add(Me.dtVanfeeReceived)
        Me.VanFees.Controls.Add(Me.lblVanErrBankDepDate)
        Me.VanFees.Controls.Add(Me.Label21)
        Me.VanFees.Controls.Add(Me.txtVanFeeRemarks)
        Me.VanFees.Controls.Add(Me.Label22)
        Me.VanFees.Controls.Add(Me.txtVanFeeBankDepAmt)
        Me.VanFees.Controls.Add(Me.Label23)
        Me.VanFees.Controls.Add(Me.txtVanFeeBalance)
        Me.VanFees.Controls.Add(Me.txtVanFeeReceived)
        Me.VanFees.Controls.Add(Me.Label24)
        Me.VanFees.Controls.Add(Me.Label25)
        Me.VanFees.Controls.Add(Me.Label26)
        Me.VanFees.Location = New System.Drawing.Point(4, 22)
        Me.VanFees.Name = "VanFees"
        Me.VanFees.Padding = New System.Windows.Forms.Padding(3)
        Me.VanFees.Size = New System.Drawing.Size(712, 253)
        Me.VanFees.TabIndex = 1
        Me.VanFees.Text = "Van Fees"
        Me.VanFees.UseVisualStyleBackColor = True
        '
        'lblVanErrRemarks
        '
        Me.lblVanErrRemarks.AutoSize = True
        Me.lblVanErrRemarks.ForeColor = System.Drawing.Color.Red
        Me.lblVanErrRemarks.Location = New System.Drawing.Point(13, 217)
        Me.lblVanErrRemarks.Name = "lblVanErrRemarks"
        Me.lblVanErrRemarks.Size = New System.Drawing.Size(130, 13)
        Me.lblVanErrRemarks.TabIndex = 83
        Me.lblVanErrRemarks.Text = "Character Not Allowed -> '"
        Me.lblVanErrRemarks.Visible = False
        '
        'lblVanErrFeeDate
        '
        Me.lblVanErrFeeDate.AutoSize = True
        Me.lblVanErrFeeDate.ForeColor = System.Drawing.Color.Red
        Me.lblVanErrFeeDate.Location = New System.Drawing.Point(499, 70)
        Me.lblVanErrFeeDate.Name = "lblVanErrFeeDate"
        Me.lblVanErrFeeDate.Size = New System.Drawing.Size(201, 13)
        Me.lblVanErrFeeDate.TabIndex = 81
        Me.lblVanErrFeeDate.Text = "Date cannot be greater than current date"
        Me.lblVanErrFeeDate.Visible = False
        '
        'lblVanErrBankDepAmt
        '
        Me.lblVanErrBankDepAmt.AutoSize = True
        Me.lblVanErrBankDepAmt.ForeColor = System.Drawing.Color.Red
        Me.lblVanErrBankDepAmt.Location = New System.Drawing.Point(14, 144)
        Me.lblVanErrBankDepAmt.Name = "lblVanErrBankDepAmt"
        Me.lblVanErrBankDepAmt.Size = New System.Drawing.Size(192, 13)
        Me.lblVanErrBankDepAmt.TabIndex = 80
        Me.lblVanErrBankDepAmt.Text = "Amount cannot exceed prescribed fees"
        Me.lblVanErrBankDepAmt.Visible = False
        '
        'lblVanErrFeeReceived
        '
        Me.lblVanErrFeeReceived.AutoSize = True
        Me.lblVanErrFeeReceived.ForeColor = System.Drawing.Color.Red
        Me.lblVanErrFeeReceived.Location = New System.Drawing.Point(14, 70)
        Me.lblVanErrFeeReceived.Name = "lblVanErrFeeReceived"
        Me.lblVanErrFeeReceived.Size = New System.Drawing.Size(192, 13)
        Me.lblVanErrFeeReceived.TabIndex = 79
        Me.lblVanErrFeeReceived.Text = "Amount cannot exceed prescribed fees"
        Me.lblVanErrFeeReceived.Visible = False
        '
        'dtVanFeeBankDeposit
        '
        Me.dtVanFeeBankDeposit.Location = New System.Drawing.Point(258, 120)
        Me.dtVanFeeBankDeposit.Name = "dtVanFeeBankDeposit"
        Me.dtVanFeeBankDeposit.Size = New System.Drawing.Size(200, 20)
        Me.dtVanFeeBankDeposit.TabIndex = 78
        '
        'dtVanfeeReceived
        '
        Me.dtVanfeeReceived.Location = New System.Drawing.Point(499, 46)
        Me.dtVanfeeReceived.Name = "dtVanfeeReceived"
        Me.dtVanfeeReceived.Size = New System.Drawing.Size(200, 20)
        Me.dtVanfeeReceived.TabIndex = 77
        '
        'lblVanErrBankDepDate
        '
        Me.lblVanErrBankDepDate.AutoSize = True
        Me.lblVanErrBankDepDate.ForeColor = System.Drawing.Color.Red
        Me.lblVanErrBankDepDate.Location = New System.Drawing.Point(257, 144)
        Me.lblVanErrBankDepDate.Name = "lblVanErrBankDepDate"
        Me.lblVanErrBankDepDate.Size = New System.Drawing.Size(201, 13)
        Me.lblVanErrBankDepDate.TabIndex = 82
        Me.lblVanErrBankDepDate.Text = "Date cannot be greater than current date"
        Me.lblVanErrBankDepDate.Visible = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(496, 21)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(33, 13)
        Me.Label21.TabIndex = 73
        Me.Label21.Text = "Date:"
        '
        'txtVanFeeRemarks
        '
        Me.txtVanFeeRemarks.Location = New System.Drawing.Point(15, 194)
        Me.txtVanFeeRemarks.Name = "txtVanFeeRemarks"
        Me.txtVanFeeRemarks.Size = New System.Drawing.Size(684, 20)
        Me.txtVanFeeRemarks.TabIndex = 72
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(12, 169)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(52, 13)
        Me.Label22.TabIndex = 71
        Me.Label22.Text = "Remarks:"
        '
        'txtVanFeeBankDepAmt
        '
        Me.txtVanFeeBankDepAmt.Location = New System.Drawing.Point(16, 120)
        Me.txtVanFeeBankDepAmt.Name = "txtVanFeeBankDepAmt"
        Me.txtVanFeeBankDepAmt.Size = New System.Drawing.Size(176, 20)
        Me.txtVanFeeBankDepAmt.TabIndex = 69
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(13, 95)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(113, 13)
        Me.Label23.TabIndex = 68
        Me.Label23.Text = "Bank Deposit Amount:"
        '
        'txtVanFeeBalance
        '
        Me.txtVanFeeBalance.Location = New System.Drawing.Point(258, 46)
        Me.txtVanFeeBalance.Name = "txtVanFeeBalance"
        Me.txtVanFeeBalance.Size = New System.Drawing.Size(200, 20)
        Me.txtVanFeeBalance.TabIndex = 67
        '
        'txtVanFeeReceived
        '
        Me.txtVanFeeReceived.Location = New System.Drawing.Point(16, 46)
        Me.txtVanFeeReceived.Name = "txtVanFeeReceived"
        Me.txtVanFeeReceived.Size = New System.Drawing.Size(176, 20)
        Me.txtVanFeeReceived.TabIndex = 66
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(255, 21)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(75, 13)
        Me.Label24.TabIndex = 65
        Me.Label24.Text = "Fees Balance:"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(13, 21)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(82, 13)
        Me.Label25.TabIndex = 64
        Me.Label25.Text = "Fees Received:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(255, 95)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(100, 13)
        Me.Label26.TabIndex = 70
        Me.Label26.Text = "Bank Deposit Date:"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(547, 352)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(176, 39)
        Me.btnSave.TabIndex = 57
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(350, 352)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(178, 39)
        Me.btnCancel.TabIndex = 56
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblREGN)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblStudName)
        Me.GroupBox1.Controls.Add(Me.lblPresFees)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(716, 49)
        Me.GroupBox1.TabIndex = 58
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
        Me.lblStudName.Location = New System.Drawing.Point(85, 23)
        Me.lblStudName.MaximumSize = New System.Drawing.Size(0, 40)
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
        'FeeDetailsvb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(732, 403)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "FeeDetailsvb"
        Me.Text = "Fee Details"
        Me.TabControl1.ResumeLayout(False)
        Me.SchoolFees.ResumeLayout(False)
        Me.SchoolFees.PerformLayout()
        Me.VanFees.ResumeLayout(False)
        Me.VanFees.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents SchoolFees As TabPage
    Friend WithEvents lblErrRemarks As Label
    Friend WithEvents lblErrDate As Label
    Friend WithEvents lblErrBankDepAmt As Label
    Friend WithEvents lblErrFeesReceived As Label
    Friend WithEvents dtBankDeposit As DateTimePicker
    Friend WithEvents dtFeeReceived As DateTimePicker
    Friend WithEvents lblErrBankDepDate As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtBankDepAmt As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtFeeBalance As TextBox
    Friend WithEvents txtFeeReceived As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents VanFees As TabPage
    Friend WithEvents lblVanErrRemarks As Label
    Friend WithEvents lblVanErrFeeDate As Label
    Friend WithEvents lblVanErrBankDepAmt As Label
    Friend WithEvents lblVanErrFeeReceived As Label
    Friend WithEvents dtVanFeeBankDeposit As DateTimePicker
    Friend WithEvents dtVanfeeReceived As DateTimePicker
    Friend WithEvents lblVanErrBankDepDate As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents txtVanFeeRemarks As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents txtVanFeeBankDepAmt As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents txtVanFeeBalance As TextBox
    Friend WithEvents txtVanFeeReceived As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblREGN As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblStudName As Label
    Friend WithEvents lblPresFees As Label
    Friend WithEvents Label3 As Label
End Class
