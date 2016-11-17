<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form0
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form0))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnNewStudent = New System.Windows.Forms.Button()
        Me.txtStudentID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtSection = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnResetForm = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnPrevPay = New System.Windows.Forms.Button()
        Me.lblTotalFeeBalance = New System.Windows.Forms.Label()
        Me.lblTotalFeeReceived = New System.Windows.Forms.Label()
        Me.btnFeeDetails = New System.Windows.Forms.Button()
        Me.lblFees = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.cmbClass = New System.Windows.Forms.ComboBox()
        Me.ClassesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Prajwal_school_appDataSet = New StudentInfo.prajwal_school_appDataSet()
        Me.dtDOB = New System.Windows.Forms.DateTimePicker()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblErrREGN = New System.Windows.Forms.Label()
        Me.lblErrFirstName = New System.Windows.Forms.Label()
        Me.lblErrLastName = New System.Windows.Forms.Label()
        Me.lblErrClass = New System.Windows.Forms.Label()
        Me.lblErrSection = New System.Windows.Forms.Label()
        Me.lblErrDOB = New System.Windows.Forms.Label()
        Me.lblErrAddress = New System.Windows.Forms.Label()
        Me.listSupplies = New System.Windows.Forms.ListView()
        Me.Item = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Price = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ClassesTableAdapter = New StudentInfo.prajwal_school_appDataSetTableAdapters.classesTableAdapter()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ClassesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Prajwal_school_appDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SettingsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1527, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'btnNewStudent
        '
        Me.btnNewStudent.Location = New System.Drawing.Point(16, 49)
        Me.btnNewStudent.Margin = New System.Windows.Forms.Padding(4)
        Me.btnNewStudent.Name = "btnNewStudent"
        Me.btnNewStudent.Size = New System.Drawing.Size(215, 44)
        Me.btnNewStudent.TabIndex = 2
        Me.btnNewStudent.Text = "+ New Student"
        Me.btnNewStudent.UseVisualStyleBackColor = True
        '
        'txtStudentID
        '
        Me.txtStudentID.Location = New System.Drawing.Point(260, 133)
        Me.txtStudentID.Margin = New System.Windows.Forms.Padding(4)
        Me.txtStudentID.Name = "txtStudentID"
        Me.txtStudentID.Size = New System.Drawing.Size(312, 22)
        Me.txtStudentID.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(256, 106)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "REGN Number:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(256, 198)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "First Name:"
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(260, 228)
        Me.txtFirstName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(312, 22)
        Me.txtFirstName.TabIndex = 6
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(260, 324)
        Me.txtLastName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(312, 22)
        Me.txtLastName.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(256, 293)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 16)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Last Name:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(660, 106)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 16)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Date of Birth:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(660, 198)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 16)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Class:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(660, 293)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 16)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Section:"
        '
        'txtSection
        '
        Me.txtSection.Location = New System.Drawing.Point(664, 324)
        Me.txtSection.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSection.Name = "txtSection"
        Me.txtSection.Size = New System.Drawing.Size(312, 22)
        Me.txtSection.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 379)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 16)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Address:"
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(16, 402)
        Me.txtAddress.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(1493, 22)
        Me.txtAddress.TabIndex = 16
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(932, 668)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(275, 58)
        Me.btnCancel.TabIndex = 18
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnResetForm
        '
        Me.btnResetForm.Location = New System.Drawing.Point(16, 668)
        Me.btnResetForm.Margin = New System.Windows.Forms.Padding(4)
        Me.btnResetForm.Name = "btnResetForm"
        Me.btnResetForm.Size = New System.Drawing.Size(275, 58)
        Me.btnResetForm.TabIndex = 19
        Me.btnResetForm.Text = "Reset Form"
        Me.btnResetForm.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(23, 43)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 16)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Fees:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(23, 95)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(160, 16)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Total Payment Received:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(23, 140)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(166, 16)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "Total Payment Remaining:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnPrevPay)
        Me.GroupBox1.Controls.Add(Me.lblTotalFeeBalance)
        Me.GroupBox1.Controls.Add(Me.lblTotalFeeReceived)
        Me.GroupBox1.Controls.Add(Me.btnFeeDetails)
        Me.GroupBox1.Controls.Add(Me.lblFees)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Location = New System.Drawing.Point(1072, 106)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(421, 250)
        Me.GroupBox1.TabIndex = 26
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fee Details"
        '
        'btnPrevPay
        '
        Me.btnPrevPay.Enabled = False
        Me.btnPrevPay.Location = New System.Drawing.Point(24, 190)
        Me.btnPrevPay.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPrevPay.Name = "btnPrevPay"
        Me.btnPrevPay.Size = New System.Drawing.Size(372, 38)
        Me.btnPrevPay.TabIndex = 30
        Me.btnPrevPay.Text = "Previous Payments"
        Me.btnPrevPay.UseVisualStyleBackColor = False
        '
        'lblTotalFeeBalance
        '
        Me.lblTotalFeeBalance.AutoSize = True
        Me.lblTotalFeeBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalFeeBalance.ForeColor = System.Drawing.Color.Red
        Me.lblTotalFeeBalance.Location = New System.Drawing.Point(199, 135)
        Me.lblTotalFeeBalance.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalFeeBalance.Name = "lblTotalFeeBalance"
        Me.lblTotalFeeBalance.Size = New System.Drawing.Size(54, 24)
        Me.lblTotalFeeBalance.TabIndex = 29
        Me.lblTotalFeeBalance.Text = "6000"
        '
        'lblTotalFeeReceived
        '
        Me.lblTotalFeeReceived.AutoSize = True
        Me.lblTotalFeeReceived.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalFeeReceived.ForeColor = System.Drawing.Color.Green
        Me.lblTotalFeeReceived.Location = New System.Drawing.Point(199, 87)
        Me.lblTotalFeeReceived.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalFeeReceived.Name = "lblTotalFeeReceived"
        Me.lblTotalFeeReceived.Size = New System.Drawing.Size(54, 24)
        Me.lblTotalFeeReceived.TabIndex = 28
        Me.lblTotalFeeReceived.Text = "6000"
        '
        'btnFeeDetails
        '
        Me.btnFeeDetails.Enabled = False
        Me.btnFeeDetails.Location = New System.Drawing.Point(152, 32)
        Me.btnFeeDetails.Margin = New System.Windows.Forms.Padding(4)
        Me.btnFeeDetails.Name = "btnFeeDetails"
        Me.btnFeeDetails.Size = New System.Drawing.Size(247, 38)
        Me.btnFeeDetails.TabIndex = 27
        Me.btnFeeDetails.Text = "More Details"
        Me.btnFeeDetails.UseVisualStyleBackColor = False
        '
        'lblFees
        '
        Me.lblFees.AutoSize = True
        Me.lblFees.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFees.ForeColor = System.Drawing.Color.Black
        Me.lblFees.Location = New System.Drawing.Point(63, 37)
        Me.lblFees.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFees.Name = "lblFees"
        Me.lblFees.Size = New System.Drawing.Size(54, 24)
        Me.lblFees.TabIndex = 26
        Me.lblFees.Text = "6000"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(15, 471)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 16)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "Supplies:"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(1300, 458)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(100, 28)
        Me.btnAdd.TabIndex = 29
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(1411, 458)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(100, 28)
        Me.btnDelete.TabIndex = 30
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'cmbClass
        '
        Me.cmbClass.DataSource = Me.ClassesBindingSource
        Me.cmbClass.DisplayMember = "CLASS"
        Me.cmbClass.FormattingEnabled = True
        Me.cmbClass.Location = New System.Drawing.Point(664, 228)
        Me.cmbClass.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbClass.Name = "cmbClass"
        Me.cmbClass.Size = New System.Drawing.Size(312, 24)
        Me.cmbClass.TabIndex = 31
        Me.cmbClass.ValueMember = "CLASS"
        '
        'ClassesBindingSource
        '
        Me.ClassesBindingSource.DataMember = "classes"
        Me.ClassesBindingSource.DataSource = Me.Prajwal_school_appDataSet
        '
        'Prajwal_school_appDataSet
        '
        Me.Prajwal_school_appDataSet.DataSetName = "prajwal_school_appDataSet"
        Me.Prajwal_school_appDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dtDOB
        '
        Me.dtDOB.Location = New System.Drawing.Point(664, 133)
        Me.dtDOB.Margin = New System.Windows.Forms.Padding(4)
        Me.dtDOB.Name = "dtDOB"
        Me.dtDOB.Size = New System.Drawing.Size(312, 22)
        Me.dtDOB.TabIndex = 32
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(260, 49)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(215, 44)
        Me.btnSearch.TabIndex = 33
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(1236, 668)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(275, 58)
        Me.btnSave.TabIndex = 17
        Me.btnSave.Text = "Save Student"
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lblErrREGN
        '
        Me.lblErrREGN.AutoSize = True
        Me.lblErrREGN.ForeColor = System.Drawing.Color.Red
        Me.lblErrREGN.Location = New System.Drawing.Point(260, 161)
        Me.lblErrREGN.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblErrREGN.Name = "lblErrREGN"
        Me.lblErrREGN.Size = New System.Drawing.Size(140, 16)
        Me.lblErrREGN.TabIndex = 34
        Me.lblErrREGN.Text = "Only numbers allowed"
        Me.lblErrREGN.Visible = False
        '
        'lblErrFirstName
        '
        Me.lblErrFirstName.AutoSize = True
        Me.lblErrFirstName.ForeColor = System.Drawing.Color.Red
        Me.lblErrFirstName.Location = New System.Drawing.Point(260, 256)
        Me.lblErrFirstName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblErrFirstName.Name = "lblErrFirstName"
        Me.lblErrFirstName.Size = New System.Drawing.Size(148, 16)
        Me.lblErrFirstName.TabIndex = 35
        Me.lblErrFirstName.Text = "Only alphabets allowed"
        Me.lblErrFirstName.Visible = False
        '
        'lblErrLastName
        '
        Me.lblErrLastName.AutoSize = True
        Me.lblErrLastName.ForeColor = System.Drawing.Color.Red
        Me.lblErrLastName.Location = New System.Drawing.Point(260, 353)
        Me.lblErrLastName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblErrLastName.Name = "lblErrLastName"
        Me.lblErrLastName.Size = New System.Drawing.Size(148, 16)
        Me.lblErrLastName.TabIndex = 36
        Me.lblErrLastName.Text = "Only alphabets allowed"
        Me.lblErrLastName.Visible = False
        '
        'lblErrClass
        '
        Me.lblErrClass.AutoSize = True
        Me.lblErrClass.ForeColor = System.Drawing.Color.Red
        Me.lblErrClass.Location = New System.Drawing.Point(665, 258)
        Me.lblErrClass.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblErrClass.Name = "lblErrClass"
        Me.lblErrClass.Size = New System.Drawing.Size(109, 16)
        Me.lblErrClass.TabIndex = 37
        Me.lblErrClass.Text = "Cannot be empty"
        Me.lblErrClass.Visible = False
        '
        'lblErrSection
        '
        Me.lblErrSection.AutoSize = True
        Me.lblErrSection.ForeColor = System.Drawing.Color.Red
        Me.lblErrSection.Location = New System.Drawing.Point(665, 353)
        Me.lblErrSection.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblErrSection.Name = "lblErrSection"
        Me.lblErrSection.Size = New System.Drawing.Size(148, 16)
        Me.lblErrSection.TabIndex = 38
        Me.lblErrSection.Text = "Only alphabets allowed"
        Me.lblErrSection.Visible = False
        '
        'lblErrDOB
        '
        Me.lblErrDOB.AutoSize = True
        Me.lblErrDOB.ForeColor = System.Drawing.Color.Red
        Me.lblErrDOB.Location = New System.Drawing.Point(665, 161)
        Me.lblErrDOB.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblErrDOB.Name = "lblErrDOB"
        Me.lblErrDOB.Size = New System.Drawing.Size(246, 16)
        Me.lblErrDOB.TabIndex = 39
        Me.lblErrDOB.Text = "Date cannot be greater than current date"
        Me.lblErrDOB.Visible = False
        '
        'lblErrAddress
        '
        Me.lblErrAddress.AutoSize = True
        Me.lblErrAddress.ForeColor = System.Drawing.Color.Red
        Me.lblErrAddress.Location = New System.Drawing.Point(16, 431)
        Me.lblErrAddress.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblErrAddress.Name = "lblErrAddress"
        Me.lblErrAddress.Size = New System.Drawing.Size(109, 16)
        Me.lblErrAddress.TabIndex = 41
        Me.lblErrAddress.Text = "Cannot be empty"
        Me.lblErrAddress.Visible = False
        '
        'listSupplies
        '
        Me.listSupplies.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Item, Me.Price})
        Me.listSupplies.FullRowSelect = True
        Me.listSupplies.GridLines = True
        Me.listSupplies.Location = New System.Drawing.Point(16, 503)
        Me.listSupplies.Margin = New System.Windows.Forms.Padding(4)
        Me.listSupplies.Name = "listSupplies"
        Me.listSupplies.Size = New System.Drawing.Size(1493, 157)
        Me.listSupplies.TabIndex = 42
        Me.listSupplies.UseCompatibleStateImageBehavior = False
        Me.listSupplies.View = System.Windows.Forms.View.Details
        '
        'Item
        '
        Me.Item.Text = "Item"
        Me.Item.Width = 951
        '
        'Price
        '
        Me.Price.Text = "Price"
        Me.Price.Width = 163
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Default
        Me.PictureBox1.InitialImage = CType(resources.GetObject("PictureBox1.InitialImage"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(16, 101)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(214, 254)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'ClassesTableAdapter
        '
        Me.ClassesTableAdapter.ClearBeforeFill = True
        '
        'Form0
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1527, 741)
        Me.Controls.Add(Me.listSupplies)
        Me.Controls.Add(Me.lblErrAddress)
        Me.Controls.Add(Me.lblErrDOB)
        Me.Controls.Add(Me.lblErrSection)
        Me.Controls.Add(Me.lblErrClass)
        Me.Controls.Add(Me.lblErrLastName)
        Me.Controls.Add(Me.lblErrFirstName)
        Me.Controls.Add(Me.lblErrREGN)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.dtDOB)
        Me.Controls.Add(Me.cmbClass)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnResetForm)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtSection)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtLastName)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtStudentID)
        Me.Controls.Add(Me.btnNewStudent)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form0"
        Me.Text = "Student Information"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ClassesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Prajwal_school_appDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnNewStudent As Button
    Friend WithEvents txtStudentID As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtSection As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnResetForm As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblFees As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents cmbClass As ComboBox
    Friend WithEvents btnFeeDetails As Button
    Friend WithEvents dtDOB As DateTimePicker
    Friend WithEvents btnSearch As Button
    Friend WithEvents lblErrREGN As Label
    Friend WithEvents lblErrFirstName As Label
    Friend WithEvents lblErrLastName As Label
    Friend WithEvents lblErrClass As Label
    Friend WithEvents lblErrSection As Label
    Friend WithEvents lblErrDOB As Label
    Friend WithEvents lblErrAddress As Label
    Friend WithEvents lblTotalFeeBalance As Label
    Friend WithEvents lblTotalFeeReceived As Label
    Friend WithEvents listSupplies As ListView
    Friend WithEvents Item As ColumnHeader
    Friend WithEvents Price As ColumnHeader
    Friend WithEvents btnPrevPay As Button
    Friend WithEvents Prajwal_school_appDataSet As prajwal_school_appDataSet
    Friend WithEvents ClassesBindingSource As BindingSource
    Friend WithEvents ClassesTableAdapter As prajwal_school_appDataSetTableAdapters.classesTableAdapter
End Class
