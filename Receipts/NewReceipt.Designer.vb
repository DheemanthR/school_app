<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class NewReceipt
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewReceipt))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtREGN = New System.Windows.Forms.TextBox()
        Me.txtFName = New System.Windows.Forms.TextBox()
        Me.txtLName = New System.Windows.Forms.TextBox()
        Me.txtSection = New System.Windows.Forms.TextBox()
        Me.cmbClass = New System.Windows.Forms.ComboBox()
        Me.ClassesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Prajwal_school_appDataSet = New Receipts.prajwal_school_appDataSet()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtBalance = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtReceipt = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtAIW = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.stsLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ClassesTableAdapter = New Receipts.prajwal_school_appDataSetTableAdapters.classesTableAdapter()
        Me.ViewPDF = New AxAcroPDFLib.AxAcroPDF()
        CType(Me.ClassesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Prajwal_school_appDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.ViewPDF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "REGN:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(130, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "First Name:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(380, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Last Name:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(616, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Class:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(779, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Section:"
        '
        'txtREGN
        '
        Me.txtREGN.Location = New System.Drawing.Point(9, 40)
        Me.txtREGN.Name = "txtREGN"
        Me.txtREGN.Size = New System.Drawing.Size(111, 20)
        Me.txtREGN.TabIndex = 5
        '
        'txtFName
        '
        Me.txtFName.Location = New System.Drawing.Point(133, 40)
        Me.txtFName.Name = "txtFName"
        Me.txtFName.Size = New System.Drawing.Size(236, 20)
        Me.txtFName.TabIndex = 6
        '
        'txtLName
        '
        Me.txtLName.Location = New System.Drawing.Point(383, 40)
        Me.txtLName.Name = "txtLName"
        Me.txtLName.Size = New System.Drawing.Size(221, 20)
        Me.txtLName.TabIndex = 7
        '
        'txtSection
        '
        Me.txtSection.Location = New System.Drawing.Point(782, 41)
        Me.txtSection.Name = "txtSection"
        Me.txtSection.Size = New System.Drawing.Size(142, 20)
        Me.txtSection.TabIndex = 8
        '
        'cmbClass
        '
        Me.cmbClass.DataSource = Me.ClassesBindingSource
        Me.cmbClass.DisplayMember = "CLASS"
        Me.cmbClass.FormattingEnabled = True
        Me.cmbClass.Location = New System.Drawing.Point(619, 40)
        Me.cmbClass.Name = "cmbClass"
        Me.cmbClass.Size = New System.Drawing.Size(147, 21)
        Me.cmbClass.TabIndex = 9
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSearch)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmbClass)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtSection)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtLName)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtFName)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtREGN)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(931, 109)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Student Details"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(9, 68)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(110, 31)
        Me.btnSearch.TabIndex = 10
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(9, 44)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(180, 20)
        Me.txtAmount.TabIndex = 11
        Me.txtAmount.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Amount:"
        '
        'txtBalance
        '
        Me.txtBalance.Location = New System.Drawing.Point(9, 107)
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.Size = New System.Drawing.Size(180, 20)
        Me.txtBalance.TabIndex = 13
        Me.txtBalance.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 90)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Balance:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 151)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(33, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Date:"
        '
        'dtReceipt
        '
        Me.dtReceipt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtReceipt.Location = New System.Drawing.Point(9, 168)
        Me.dtReceipt.Name = "dtReceipt"
        Me.dtReceipt.Size = New System.Drawing.Size(180, 20)
        Me.dtReceipt.TabIndex = 15
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 213)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(92, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Amount In Words:"
        '
        'txtAIW
        '
        Me.txtAIW.Location = New System.Drawing.Point(9, 230)
        Me.txtAIW.Multiline = True
        Me.txtAIW.Name = "txtAIW"
        Me.txtAIW.Size = New System.Drawing.Size(180, 86)
        Me.txtAIW.TabIndex = 17
        Me.txtAIW.Text = "Zero"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(9, 414)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(180, 102)
        Me.Button1.TabIndex = 20
        Me.Button1.Text = "Generate"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button2.Location = New System.Drawing.Point(9, 338)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(180, 60)
        Me.Button2.TabIndex = 21
        Me.Button2.Text = "Manual Entry"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.txtAIW)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.dtReceipt)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtBalance)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtAmount)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 128)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(195, 522)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Payment Details"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 652)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 10, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(956, 22)
        Me.StatusStrip1.TabIndex = 13
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'stsLabel
        '
        Me.stsLabel.Name = "stsLabel"
        Me.stsLabel.Size = New System.Drawing.Size(39, 17)
        Me.stsLabel.Text = "Ready"
        '
        'ClassesTableAdapter
        '
        Me.ClassesTableAdapter.ClearBeforeFill = True
        '
        'ViewPDF
        '
        Me.ViewPDF.Enabled = True
        Me.ViewPDF.Location = New System.Drawing.Point(214, 128)
        Me.ViewPDF.Name = "ViewPDF"
        Me.ViewPDF.OcxState = CType(resources.GetObject("ViewPDF.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ViewPDF.Size = New System.Drawing.Size(730, 521)
        Me.ViewPDF.TabIndex = 14
        '
        'NewReceipt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(956, 674)
        Me.Controls.Add(Me.ViewPDF)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "NewReceipt"
        Me.Text = "New Receipt"
        CType(Me.ClassesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Prajwal_school_appDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.ViewPDF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtFName As TextBox
    Friend WithEvents txtLName As TextBox
    Friend WithEvents txtSection As TextBox
    Friend WithEvents cmbClass As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DataSet1 As DataSet1
    Friend WithEvents DataSet11 As DataSet1

    Friend WithEvents txtAmount As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtBalance As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents dtReceipt As DateTimePicker
    Friend WithEvents Label9 As Label
    Friend WithEvents txtAIW As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    'Friend WithEvents ViewPDF As AcroPDFLib.AcroPDF
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ClassesBindingSource As BindingSource
    Friend WithEvents btnSearch As Button
    Friend WithEvents stsLabel As ToolStripStatusLabel
    Public WithEvents txtREGN As TextBox
    Public WithEvents ClassesTableAdapter As prajwal_school_appDataSetTableAdapters.classesTableAdapter
    Public WithEvents Prajwal_school_appDataSet As prajwal_school_appDataSet
    Public WithEvents GroupBox2 As GroupBox
    Friend WithEvents ViewPDF As AxAcroPDFLib.AxAcroPDF
End Class
