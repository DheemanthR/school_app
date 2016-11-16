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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
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
        Me.ViewPDF = New AxAcroPDFLib.AxAcroPDF()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Prajwal_school_appDataSet = New Receipts.prajwal_school_appDataSet()
        Me.ClassesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ClassesTableAdapter = New Receipts.prajwal_school_appDataSetTableAdapters.classesTableAdapter()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.ViewPDF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Prajwal_school_appDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClassesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 28)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "REGN:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(173, 28)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "First Name:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(507, 28)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Last Name:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(821, 29)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Class:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(1039, 29)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Section:"
        '
        'txtREGN
        '
        Me.txtREGN.Location = New System.Drawing.Point(12, 49)
        Me.txtREGN.Margin = New System.Windows.Forms.Padding(4)
        Me.txtREGN.Name = "txtREGN"
        Me.txtREGN.Size = New System.Drawing.Size(147, 22)
        Me.txtREGN.TabIndex = 5
        '
        'txtFName
        '
        Me.txtFName.Location = New System.Drawing.Point(177, 49)
        Me.txtFName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFName.Name = "txtFName"
        Me.txtFName.Size = New System.Drawing.Size(313, 22)
        Me.txtFName.TabIndex = 6
        '
        'txtLName
        '
        Me.txtLName.Location = New System.Drawing.Point(511, 49)
        Me.txtLName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLName.Name = "txtLName"
        Me.txtLName.Size = New System.Drawing.Size(293, 22)
        Me.txtLName.TabIndex = 7
        '
        'txtSection
        '
        Me.txtSection.Location = New System.Drawing.Point(1043, 50)
        Me.txtSection.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSection.Name = "txtSection"
        Me.txtSection.Size = New System.Drawing.Size(188, 22)
        Me.txtSection.TabIndex = 8
        '
        'cmbClass
        '
        Me.cmbClass.DataSource = Me.ClassesBindingSource
        Me.cmbClass.DisplayMember = "CLASS"
        Me.cmbClass.FormattingEnabled = True
        Me.cmbClass.Location = New System.Drawing.Point(825, 49)
        Me.cmbClass.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbClass.Name = "cmbClass"
        Me.cmbClass.Size = New System.Drawing.Size(195, 24)
        Me.cmbClass.TabIndex = 9
        Me.cmbClass.ValueMember = "CLASS"
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
        Me.GroupBox1.Location = New System.Drawing.Point(17, 16)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(1241, 134)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Student Details"
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(12, 54)
        Me.txtAmount.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(239, 22)
        Me.txtAmount.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 33)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 16)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Amount:"
        '
        'txtBalance
        '
        Me.txtBalance.Location = New System.Drawing.Point(12, 132)
        Me.txtBalance.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.Size = New System.Drawing.Size(239, 22)
        Me.txtBalance.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 111)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 16)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Balance:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 186)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 16)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Date:"
        '
        'dtReceipt
        '
        Me.dtReceipt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtReceipt.Location = New System.Drawing.Point(12, 207)
        Me.dtReceipt.Margin = New System.Windows.Forms.Padding(4)
        Me.dtReceipt.Name = "dtReceipt"
        Me.dtReceipt.Size = New System.Drawing.Size(239, 22)
        Me.dtReceipt.TabIndex = 15
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 262)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 16)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Amount In Words:"
        '
        'txtAIW
        '
        Me.txtAIW.Location = New System.Drawing.Point(12, 283)
        Me.txtAIW.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAIW.Multiline = True
        Me.txtAIW.Name = "txtAIW"
        Me.txtAIW.Size = New System.Drawing.Size(239, 105)
        Me.txtAIW.TabIndex = 17
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 510)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(240, 126)
        Me.Button1.TabIndex = 20
        Me.Button1.Text = "Generate"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 416)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(240, 74)
        Me.Button2.TabIndex = 21
        Me.Button2.Text = "Manual Entry"
        Me.Button2.UseVisualStyleBackColor = True
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
        Me.GroupBox2.Location = New System.Drawing.Point(17, 158)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(260, 642)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Payment Details"
        '
        'ViewPDF
        '
        Me.ViewPDF.Enabled = True
        Me.ViewPDF.Location = New System.Drawing.Point(285, 158)
        Me.ViewPDF.Name = "ViewPDF"
        Me.ViewPDF.OcxState = CType(resources.GetObject("ViewPDF.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ViewPDF.Size = New System.Drawing.Size(973, 642)
        Me.ViewPDF.TabIndex = 12
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 808)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1275, 22)
        Me.StatusStrip1.TabIndex = 13
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Prajwal_school_appDataSet
        '
        Me.Prajwal_school_appDataSet.DataSetName = "prajwal_school_appDataSet"
        Me.Prajwal_school_appDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ClassesBindingSource
        '
        Me.ClassesBindingSource.DataMember = "classes"
        Me.ClassesBindingSource.DataSource = Me.Prajwal_school_appDataSet
        '
        'ClassesTableAdapter
        '
        Me.ClassesTableAdapter.ClearBeforeFill = True
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(12, 84)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(147, 38)
        Me.btnSearch.TabIndex = 10
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'NewReceipt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1275, 830)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ViewPDF)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "NewReceipt"
        Me.Text = "New Receipt"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.ViewPDF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Prajwal_school_appDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClassesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtREGN As TextBox
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
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents ViewPDF As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents Prajwal_school_appDataSet As prajwal_school_appDataSet
    Friend WithEvents ClassesBindingSource As BindingSource
    Friend WithEvents ClassesTableAdapter As prajwal_school_appDataSetTableAdapters.classesTableAdapter
    Friend WithEvents btnSearch As Button
End Class
