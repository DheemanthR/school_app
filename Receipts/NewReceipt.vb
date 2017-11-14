Imports System.IO
Imports System.Reflection
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports MySql.Data.MySqlClient
Imports System.ComponentModel
Imports System.Net

Public Class NewReceipt

    Public particulars As New DataTable
    Public dtsupplies As New DataTable
    Dim ds As New DataTable
    Dim db As New DBOperations.Connection
    Dim conn As New MySqlConnection
    Dim cmd As New MySqlCommand
    Dim dadapter As New MySqlDataAdapter
    Dim datardr As MySqlDataReader
    Dim receipt_id As Integer
    Dim oldReceiptfilePath As String

    Dim amount As Integer = 0
    Dim vanAmount As Integer = 0
    Dim suppliesAmount As Integer = 0
    Dim suppliesItem As String
    Dim totalFeesAmt As Integer = 0

    Dim _assembly As Assembly
    Dim TheStream As System.IO.Stream
    Dim _textStreamReader As StreamReader

    Dim NoSchoolPayment As Boolean = False
    Dim NoVanPayment As Boolean = False
    Dim NoSupplies As Boolean = False

    Dim dir As String = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents") & "\Thams School Management System\"

    Public manEntry As Boolean = False

    Public Sub NewReceipt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath)
        Me.ClassesTableAdapter.Fill(Me.Prajwal_school_appDataSet.classes)
        particulars.Columns.Add("Sl", GetType(Integer))
        particulars.Columns.Add("Particulars", GetType(String))
        particulars.Columns.Add("Amount", GetType(String))
        Me.GroupBox2.Enabled = False
        BackgroundWorker1.WorkerReportsProgress = True
        BackgroundWorker1.WorkerSupportsCancellation = True
    End Sub

    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim result As Integer
        Dim supplies As Integer = 0
        Dim totalAmount As Integer = 0

        If form_valid() Then

            Try
                If NoSchoolPayment = True AndAlso NoVanPayment = True AndAlso particulars.Rows.Count = 0 Then
                    MsgBox("No entries to generate bill")
                    Return
                End If
                conn = db.connect(GlobalSettings.My.MySettings.Default.Branch)

                If particulars.Rows.Count > 0 Then
                    supplies = 1
                    For Each row As DataRow In particulars.Rows
                        totalAmount += row.Item(2)
                    Next
                End If
                totalAmount += Integer.Parse(txtAmount.Text)
                Dim Sql As String = "INSERT INTO receipt_details (STUD_ID,AMOUNT,BALANCE,SUPPLIES) VALUES('" & txtREGN.Text & "', '" & totalAmount & "','" & txtBalance.Text & "','" & supplies & "')"
                cmd = New MySqlCommand(Sql, conn)
                result = cmd.ExecuteNonQuery()

                Sql = "SELECT MAX(ID) FROM receipt_details"
                cmd.CommandText = Sql
                cmd.Connection = conn
                dadapter.SelectCommand = cmd
                datardr = cmd.ExecuteReader
                If datardr.HasRows Then
                    datardr.Read()

                    receipt_id = datardr("MAX(ID)")
                End If

                datardr.Close()
                generateBill(receipt_id)
                GroupBox2.Enabled = False
                GroupBox1.Enabled = False
                If NoSchoolPayment = False AndAlso NoVanPayment = True Then
                    Sql = "UPDATE fee_details SET BILL_GEN = 1 WHERE STUD_ID = '" & txtREGN.Text & "'"
                    cmd = New MySqlCommand(Sql, conn)
                    cmd.ExecuteNonQuery()
                ElseIf NoSchoolPayment = True AndAlso NoVanPayment = False Then
                    Sql = "UPDATE van_fee_details SET BILL_GEN = 1 WHERE STUD_ID = '" & txtREGN.Text & "'"
                    cmd = New MySqlCommand(Sql, conn)
                    cmd.ExecuteNonQuery()
                Else
                    Sql = "UPDATE fee_details SET BILL_GEN = 1 WHERE STUD_ID = '" & txtREGN.Text & "'"
                    cmd = New MySqlCommand(Sql, conn)
                    cmd.ExecuteNonQuery()

                    Sql = "UPDATE van_fee_details SET BILL_GEN = 1 WHERE STUD_ID = '" & txtREGN.Text & "'"
                    cmd = New MySqlCommand(Sql, conn)
                    cmd.ExecuteNonQuery()
                End If


                If particulars.Rows.Count > 0 Then
                    Sql = "INSERT INTO particulars (PARTICULARS,AMOUNT,STUD_ID,RECEIPT_ID) VALUES "
                    For Each row As DataRow In particulars.Rows
                        Sql += "('" & row.Item(1) & "','" & row.Item(2) & "','" & txtREGN.Text & "','" & receipt_id & "'),"

                    Next
                    Sql = Sql.TrimEnd(",")

                    cmd = New MySqlCommand(Sql, conn)
                    cmd.ExecuteNonQuery()

                    Sql = "UPDATE supply_details SET BILL_GEN = 1 WHERE REGN = '" & txtREGN.Text & "';"
                    cmd = New MySqlCommand(Sql, conn)
                    cmd.ExecuteNonQuery()

                End If

                If result > 0 Then
                    stsLabel.Text = "Receipt details saved successfully"
                End If


            Catch ex As Exception
                stsLabel.Text = "An error occured while saving receipt details to database. Please try again"
                MsgBox(ex.Message)
            Finally
                db.disconnect(conn)
            End Try

        Else
            MsgBox("Please fill all fields correctly")
        End If

    End Sub

    Public Sub suppliesReceiptGen(ByVal REGN As String)

        Dim result As Integer
        Dim totalAmount As Integer = 0
        Dim supplies As Integer = 0
        txtREGN.Text = REGN
        populateStudentDetails(REGN)
        GroupBox1.Enabled = False

        Dim lineNum As Integer = 1
        Dim newRow As DataRow

        If dtsupplies.Rows.Count > 0 Then
            supplies = 1
            For Each row As DataRow In dtsupplies.Rows
                newRow = particulars.NewRow
                newRow.Item(0) = lineNum
                newRow.Item(1) = row.Item(0)
                newRow.Item(2) = row.Item(1) * row.Item(2)
                totalAmount += row.Item(1) * row.Item(2)
                particulars.Rows.Add(newRow)
                lineNum += 1
            Next
        End If

        Try
            conn = db.connect(GlobalSettings.My.MySettings.Default.Branch)

            Dim Sql As String = "INSERT INTO receipt_details (STUD_ID,AMOUNT,BALANCE,SUPPLIES) VALUES('" & txtREGN.Text & "', '" & totalAmount & "','" & txtBalance.Text & "','" & supplies & "')"
            cmd = New MySqlCommand(Sql, conn)
            result = cmd.ExecuteNonQuery()

            Sql = "SELECT MAX(ID) FROM receipt_details"
            cmd.CommandText = Sql
            cmd.Connection = conn
            dadapter.SelectCommand = cmd
            datardr = cmd.ExecuteReader

            If datardr.HasRows Then
                datardr.Read()
                receipt_id = datardr("MAX(ID)")
            End If

            datardr.Close()


            generateBill(receipt_id)
            GroupBox2.Enabled = False
            GroupBox1.Enabled = False

            Sql = "UPDATE supply_details SET BILL_GEN = 1 WHERE REGN = '" & REGN & "';"
            cmd = New MySqlCommand(Sql, conn)
            cmd.ExecuteNonQuery()

            If dtsupplies.Rows.Count > 0 Then
                Sql = "INSERT INTO particulars (PARTICULARS,AMOUNT,STUD_ID,RECEIPT_ID) VALUES "
                For Each row As DataRow In dtsupplies.Rows
                    Sql += "('" & row.Item(0) & "','" & row.Item(1) & "','" & REGN & "','" & receipt_id & "'),"

                Next
                Sql = Sql.TrimEnd(",")

                cmd = New MySqlCommand(Sql, conn)
                cmd.ExecuteNonQuery()
            End If

            If result > 0 Then
                stsLabel.Text = "Receipt details saved successfully"
            End If


        Catch ex As Exception
            stsLabel.Text = "An error occured while saving receipt details to database. Please try again"
            MsgBox(ex.Message)
        Finally
            db.disconnect(conn)
        End Try

    End Sub

    Private Sub txtREGN_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles txtREGN.PreviewKeyDown
        If e.KeyData = Keys.Tab Or e.KeyData = Keys.Enter Then

            Try
                populateStudentDetails(txtREGN.Text)

            Catch ex As Exception
                MsgBox("Student data could not be retrieved. An Error Occured.")
            Finally
                conn.Close()
            End Try

        End If
    End Sub

    Private Sub txtAmount_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles txtAmount.PreviewKeyDown
        If e.KeyData = Keys.Tab Or e.KeyData = Keys.Enter Then

            Try
                Dim amount As Integer
                amount = Integer.Parse(txtAmount.Text)
                If amount < 99999 Then
                    txtAIW.Text = amount_in_words(amount)
                Else
                    txtAIW.Text = ""
                    MsgBox("Cannot convert amount to words!")
                End If
                txtAIW.Text = amount_in_words(amount)

            Catch ex As Exception
                MsgBox("Student data could not be retrieved. An Error Occured.")
            Finally
                conn.Close()
            End Try

        End If
    End Sub

    Public Sub populateStudentDetails(ByVal ID As String)

        Try
            conn = db.connect(GlobalSettings.My.MySettings.Default.Branch)
            Dim Sql As String = "Select FIRST_NAME, LAST_NAME, SECTION, CLASS from student where REGN = '" & ID & "';"
            cmd = New MySqlCommand(Sql, conn)
            dadapter = New MySqlDataAdapter(cmd)

            ds = New DataTable
            dadapter.Fill(ds)
            If ds.Rows.Count = 0 Then
                stsLabel.Text = "Student Data Not Found"
            Else
                txtFName.Text = ds.Rows(0).Item("FIRST_NAME")

                txtLName.Text = ds.Rows(0).Item("LAST_NAME")

                txtSection.Text = ds.Rows(0).Item("SECTION")

                cmbClass.SelectedIndex = Integer.Parse(ds.Rows(0).Item("CLASS"))
            End If

            Sql = "Select * FROM fee_details where STUD_ID = '" & ID & "'AND BILL_GEN = 0 ORDER BY FEES_BAL ASC;"

            cmd.CommandText = Sql
            cmd.Connection = conn
            dadapter.SelectCommand = cmd

            Dim schoolFeeBalance As Integer = 0
            Dim vanFeeBalance As Integer = 0

            datardr = cmd.ExecuteReader
            If datardr.HasRows Then
                datardr.Read()
                amount = datardr("FEES_RECV")
                schoolFeeBalance = datardr("FEES_BAL")
                dtReceipt.Text = datardr("DATE")

            Else
                NoSchoolPayment = True
                MsgBox("No school fee payments pending for this student")
            End If

            datardr.Close()

            Sql = "Select * FROM van_fee_details where STUD_ID = '" & ID & "'AND BILL_GEN = 0 ORDER BY FEES_BAL ASC;"

            cmd.CommandText = Sql
            cmd.Connection = conn
            dadapter.SelectCommand = cmd

            datardr = cmd.ExecuteReader
            If datardr.HasRows Then
                datardr.Read()
                vanAmount = datardr("FEES_RECV")
                vanFeeBalance = datardr("FEES_BAL")

            Else
                NoVanPayment = True
                MsgBox("No van fee payments pending for this student")
            End If

            datardr.Close()

            Sql = "Select SUPPLY, SUM(FEES) AS FEES FROM supply_details where REGN = '" & ID & "'AND BILL_GEN = 0 GROUP BY SUPPLY;"

            cmd = New MySqlCommand(Sql, conn)
            dadapter = New MySqlDataAdapter(cmd)
            Dim data As DataTable
            data = New DataTable
            dadapter.Fill(data)

            Dim lineNum As Integer = 1
            Dim dr As DataRow

            If data.Rows.Count > 0 Then
                For Each newRow In data.Rows
                    dr = particulars.NewRow
                    dr.Item(0) = lineNum
                    dr.Item(1) = newRow.Item(0).ToString
                    dr.Item(2) = newRow.Item(1)
                    particulars.Rows.Add(dr)
                    lineNum += 1
                Next
            Else
                NoSupplies = True
                MsgBox("No payments for supplies pending for this student")
            End If

            datardr.Close()

            totalFeesAmt = amount + vanAmount + suppliesAmount
            txtAmount.Text = totalFeesAmt
            txtBalance.Text = schoolFeeBalance + vanFeeBalance

            If totalFeesAmt = 0 Then
                txtAIW.Text = "Zero"
            ElseIf totalFeesAmt > 0 AndAlso totalFeesAmt < 99999 Then
                txtAIW.Text = amount_in_words(totalFeesAmt)
            Else
                txtAIW.Text = ""
                MsgBox("Cannot convert amount to words!")
            End If

            Me.stsLabel.Text = "Student And payment data loaded successfully"
            Me.GroupBox2.Enabled = True

        Catch ex As Exception
            MsgBox("Error loading Student Data")
        Finally
            db.disconnect(conn)
        End Try
    End Sub

    Private Function return_words(ByVal number As Integer) As String
        Select Case number
            Case 1 : Return "One"
            Case 2 : Return "Two"
            Case 3 : Return "Three"
            Case 4 : Return "Four"
            Case 5 : Return "Five"
            Case 6 : Return "Six"
            Case 7 : Return "Seven"
            Case 8 : Return "Eight"
            Case 9 : Return "Nine"
            Case Else : Return Nothing
        End Select
    End Function

    Private Function amount_in_words(ByVal amount As Integer) As String
        Dim aiw As String = ""
        Dim units, tens, hundreds, thousands, ten_thousands As Integer
        units = tens = hundreds = thousands = ten_thousands = 0
        Dim flag As Boolean = False
        Dim flag2 As Boolean = False
        units = amount Mod 10
        If units >= 5 Then
            amount -= 5
        End If
        If amount > 0 Then
            amount /= 10
        End If
        tens = amount Mod 10
        If tens >= 5 Then
            amount -= 5
        End If
        If amount > 0 Then
            amount /= 10
        End If
        hundreds = amount Mod 10
        If hundreds >= 5 Then
            amount -= 5
        End If
        If amount > 0 Then
            amount /= 10
        End If
        thousands = amount Mod 10
        If thousands >= 5 Then
            amount -= 5
        End If
        If amount > 0 Then
            amount /= 10
        End If
        ten_thousands = amount Mod 10

        If ten_thousands > 1 Then
            aiw += return_tens(ten_thousands) + " "
        ElseIf ten_thousands = 1 Then
            aiw += return_tens_one(thousands) + " "
            flag2 = True
        End If

        If thousands > 0 And flag2 = False Then
            aiw += return_words(thousands) + " Thousand "
        ElseIf thousands = 0 And flag2 = True Then
            aiw += "Thousand "
        ElseIf thousands = 0 And flag2 = False Then
        End If

        If hundreds > 0 Then
            If thousands = 0 Then
                aiw += return_words(hundreds) + " Hundred"
            Else
                aiw += "And " + return_words(hundreds) + " Hundred"
            End If

        End If

        If tens > 1 Then
            If thousands = 0 AndAlso hundreds = 0 Then
                aiw += return_tens(tens) + " "
            Else
                aiw += " And " + return_tens(tens) + " "
            End If

        ElseIf tens = 1 Then
            If thousands = 0 AndAlso hundreds = 0 Then
                aiw += return_tens_one(units)
            Else
                aiw += " And " + return_tens_one(units)
            End If
            flag = True
        End If

        If flag = False Then
            If units > 0 Then
                aiw += return_words(units)
            End If

        End If

        Return aiw
    End Function

    Private Function return_tens(ByVal tens As Integer) As String
        Select Case tens
            Case 1 : Return "Ten"
            Case 2 : Return "Twenty"
            Case 3 : Return "Thirty"
            Case 4 : Return "Forty"
            Case 5 : Return "Fifty"
            Case 6 : Return "Sixty"
            Case 7 : Return "Seventy"
            Case 8 : Return "Eighty"
            Case 9 : Return "Ninety"
            Case Else : Return Nothing
        End Select
    End Function

    Private Function return_tens_one(ByVal units As Integer) As String
        Select Case units
            Case 1 : Return "Eleven"
            Case 2 : Return "Twelve"
            Case 2 : Return "Thirteen"
            Case 2 : Return "Fourteen"
            Case 2 : Return "Fifteen"
            Case 2 : Return "Sixteen"
            Case 2 : Return "Seventeen"
            Case 2 : Return "Eighteen"
            Case 2 : Return "Nineteen"
            Case Else : Return Nothing
        End Select
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim frm As New ManualEntry
        frm.Owner = Me
        frm.populateListView(particulars)
        frm.Show()

    End Sub

    Private Function form_valid() As Boolean

        If txtREGN.TextLength = 0 Then
            Return False
        End If

        If txtFName.TextLength = 0 Then
            Return False
        End If

        If txtLName.TextLength = 0 Then
            Return False
        End If

        If txtSection.TextLength = 0 Then
            Return False
        End If

        'If cmbClass.SelectedIndex = 0 Then
        '    Return False
        'End If

        If manEntry = True AndAlso NoSchoolPayment = True AndAlso NoVanPayment = True Then

        Else
            If txtAmount.TextLength = 0 Then
                Return False
            End If

            If txtBalance.TextLength = 0 Then
                Return False
            End If

            If txtAIW.TextLength = 0 Then
                Return False
            End If
        End If

        Return True

    End Function

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim frm As New Receipts.StudentSearch
        frm.Owner = Me
        frm.Show()
    End Sub

    Public Sub generateBill(ByVal receipt_id As Integer)

        Dim orderDate As String = dtReceipt.Value.ToString("dd/MM/yyyy") 'DateTime.Now.ToString("dd/MM/yyyy")
        Dim totalAmt As Integer
        Dim space As iTextSharp.text.Paragraph = New iTextSharp.text.Paragraph(vbCrLf)
        Dim doc As New iTextSharp.text.Document(PageSize.A4, 36, 36, 36, 36)
        If Not Directory.Exists(dir) Then
            Directory.CreateDirectory(dir)
        End If
        Dim pdfWrite As PdfWriter = PdfWriter.GetInstance(doc, New FileStream(dir & "Receipt.pdf", FileMode.Create))
        doc.Open()
        Try
            _assembly = Assembly.GetExecutingAssembly()

            If GlobalSettings.My.MySettings.Default.Branch = 1 Then
                TheStream = _assembly.GetManifestResourceStream("Receipts.logo.jpg")
            Else
                TheStream = _assembly.GetManifestResourceStream("Receipts.byalya.jpg")
            End If

            Dim image As New Bitmap(TheStream)
            Dim logo As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(image, System.Drawing.Imaging.ImageFormat.Jpeg)
            logo.Alignment = Element.ALIGN_CENTER
            logo.ScaleToFit(2300.0F, 125.0F)
            doc.Add(logo)
        Catch ex As Exception
            stsLabel.Text = "Failed to load logo"
            Dim school_name As iTextSharp.text.Paragraph = New iTextSharp.text.Paragraph("THAM'S EDUCATION CENTER (R)")
            school_name.Alignment = Element.ALIGN_CENTER
            Dim school_reg As iTextSharp.text.Paragraph = New iTextSharp.text.Paragraph("(Recognized by Govt. Of Karnataka)")
            school_reg.Alignment = Element.ALIGN_CENTER
            Dim school_addr As iTextSharp.text.Paragraph
            If GlobalSettings.My.MySettings.Default.Branch = 1 Then
                school_addr = New iTextSharp.text.Paragraph("Byrenahalli, Madhugiri Road, Koratagere Taluk")
            Else
                school_addr = New iTextSharp.text.Paragraph("Byalya, Madhugiri Taluk")
            End If

            school_addr.Alignment = Element.ALIGN_CENTER
            doc.Add(school_name)
            doc.Add(school_reg)
            doc.Add(school_addr)
        End Try

        Dim line1 As New iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_CENTER, 1)
        doc.Add(space)
        doc.Add(New Chunk(line1))
        Dim title As iTextSharp.text.Paragraph = New iTextSharp.text.Paragraph("FEES RECEIPT")
        title.Alignment = Element.ALIGN_CENTER
        doc.Add(title)
        doc.Add(space)
        doc.Add(line1)
        Dim receiptNo As iTextSharp.text.Paragraph = New iTextSharp.text.Paragraph("Receipt Number: " & receipt_id & "                                                                                        " & " Date: " & orderDate)
        receiptNo.Alignment = Element.ALIGN_JUSTIFIED
        Dim studREGN As iTextSharp.text.Paragraph = New iTextSharp.text.Paragraph("Student REGN: " & txtREGN.Text)
        Dim studName As iTextSharp.text.Paragraph = New iTextSharp.text.Paragraph("Student Name: " & txtFName.Text & " " & txtLName.Text)
        Dim studClass As iTextSharp.text.Paragraph = New iTextSharp.text.Paragraph("Class: " & cmbClass.Text & " - '" & txtSection.Text & "'")
        doc.Add(receiptNo)
        doc.Add(studREGN)
        doc.Add(studName)
        doc.Add(studClass)
        doc.Add(space)
        doc.Add(line1)
        doc.Add(space)
        Dim Table As PdfPTable = New PdfPTable(3)
        Table.TotalWidth = PageSize.A4.Width - 73
        Table.LockedWidth = True
        Dim widths As Integer() = New Integer() {1, 10, 3}
        Table.SetWidths(widths)
        Table.HorizontalAlignment = 0
        Table.SpacingBefore = 20.0F
        Table.SpacingAfter = 30.0F
        Dim Cell As PdfPCell
        Cell = New PdfPCell(New Phrase("Sl"))
        Cell.HorizontalAlignment = 1
        Table.AddCell(Cell)
        Cell = New PdfPCell(New Phrase("Particulars"))
        Cell.HorizontalAlignment = 1
        Table.AddCell(Cell)
        Cell = New PdfPCell(New Phrase("Amount"))
        Cell.HorizontalAlignment = 1
        Table.AddCell(Cell)

        If Integer.TryParse(txtAmount.Text, totalAmt) Then

        Else
            txtAmount.Text = 0
            txtBalance.Text = 0
            totalAmt = 0
            stsLabel.Text = "No pending payments for this student"
        End If
        totalAmt = Integer.Parse(txtAmount.Text)

        'Adding first row as fees by default
        If totalAmt > 0 Then
            If amount > 0 AndAlso vanAmount = 0 Then
                Cell = New PdfPCell(New Phrase("1"))
                Cell.HorizontalAlignment = 1
                Table.AddCell(Cell)
                Table.AddCell("School Fees")
                Cell = New PdfPCell(New Phrase(amount.ToString))
                Cell.HorizontalAlignment = 1
                Table.AddCell(Cell)
            ElseIf amount = 0 AndAlso vanAmount > 0 Then
                Cell = New PdfPCell(New Phrase("1"))
                Cell.HorizontalAlignment = 1
                Table.AddCell(Cell)
                Table.AddCell("Van Fees")
                Cell = New PdfPCell(New Phrase(vanAmount.ToString))
                Cell.HorizontalAlignment = 1
                Table.AddCell(Cell)
            Else
                Cell = New PdfPCell(New Phrase("1"))
                Cell.HorizontalAlignment = 1
                Table.AddCell(Cell)
                Table.AddCell("School Fees")
                Cell = New PdfPCell(New Phrase(amount.ToString))
                Cell.HorizontalAlignment = 1
                Table.AddCell(Cell)

                Cell = New PdfPCell(New Phrase("2"))
                Cell.HorizontalAlignment = 1
                Table.AddCell(Cell)
                Table.AddCell("Van Fees")
                Cell = New PdfPCell(New Phrase(vanAmount.ToString))
                Cell.HorizontalAlignment = 1
                Table.AddCell(Cell)
            End If

        End If

        'Now adding other particulars
        If particulars.Rows.Count > 0 Then
            For Each row As DataRow In particulars.Rows
                'If Table.Rows Then
                '    Cell = New PdfPCell(New Phrase((row.Item(0) + 1).ToString))
                'Else
                If (NoSchoolPayment = True AndAlso NoVanPayment = True) Then
                    Cell = New PdfPCell(New Phrase((row.Item(0)).ToString))
                ElseIf (NoSchoolPayment = True AndAlso NoVanPayment = False) Or (NoSchoolPayment = False AndAlso NoVanPayment = True) Then
                    Cell = New PdfPCell(New Phrase((row.Item(0) + 1).ToString))
                Else
                    Cell = New PdfPCell(New Phrase((row.Item(0) + 2).ToString))
                End If
                'End If
                Cell.HorizontalAlignment = 1
                Table.AddCell(Cell)
                Table.AddCell(row.Item(1).ToString)
                Cell = New PdfPCell(New Phrase(row.Item(2).ToString))
                Cell.HorizontalAlignment = 1
                Table.AddCell(Cell)
                totalAmt += Integer.Parse(row.Item(2).ToString)
            Next

        End If

        Cell = New PdfPCell(New Phrase("Total:"))
        Cell.Colspan = 2

        Cell.HorizontalAlignment = 0
        Table.AddCell(Cell)
        Cell = New PdfPCell(New Phrase(totalAmt.ToString))
        Cell.Colspan = 1

        Cell.HorizontalAlignment = 1
        Table.AddCell(Cell)
        doc.Add(Table)

        Dim totalAmount As iTextSharp.text.Paragraph = New iTextSharp.text.Paragraph("Total Amount: " & totalAmt & "/-")
        doc.Add(totalAmount)
        Dim balance As iTextSharp.text.Paragraph = New iTextSharp.text.Paragraph("Balance Amount: " & txtBalance.Text & "/-")
        doc.Add(balance)
        Dim aiw As iTextSharp.text.Paragraph = New iTextSharp.text.Paragraph("Amount in words: " & amount_in_words(totalAmt) & " Only.")
        doc.Add(aiw)
        Dim authSig As iTextSharp.text.Paragraph = New iTextSharp.text.Paragraph("Authorized Signatory")
        authSig.Alignment = Element.ALIGN_RIGHT
        doc.Add(space)
        doc.Add(space)
        doc.Add(space)
        doc.Add(authSig)
        doc.Close()
        'ViewPDF.LoadFile("Receipt.pdf")
        ViewPDF.src = dir & "Receipt.pdf"
        BackgroundWorker1.RunWorkerAsync()
        'ViewPDF.Show()

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        'Uploading the receipt to server via FTP

        Dim url As String = "ftp://www.jyloke.com/" & receipt_id & ".pdf"
        Dim request As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create(url), System.Net.FtpWebRequest)
        request.Credentials = New System.Net.NetworkCredential("receipts@jyloke.com", "rq4m8k]hGL<G")
        request.Method = System.Net.WebRequestMethods.Ftp.UploadFile
        Dim strz As System.IO.Stream

        Try
            stsLabel.Text = "Uploading receipt..."
            Dim file() As Byte = System.IO.File.ReadAllBytes(dir & "Receipt.pdf")
            strz = request.GetRequestStream()
            For offset As Integer = 0 To file.Length Step 1024
                BackgroundWorker1.ReportProgress(CType(offset * ProgressBar1.Maximum / file.Length, Integer))
                Dim chunkSize As Integer = file.Length - offset
                If chunkSize > 1024 Then chunkSize = 1024
                strz.Write(file, offset, chunkSize)
            Next
        Catch ex As Exception
            MsgBox("Uploading receipt failed. Please try again.")
            stsLabel.Text = "Error uploading receipt"
        Finally
            strz.Close()
            strz.Dispose()
        End Try

    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        ProgressBar1.Value = ProgressBar1.Maximum
        stsLabel.Text = "Receipt Uploaded."
        ProgressBar1.Visible = False
    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        'Downloading the receipt from server via FTP
        Dim url As String = "ftp://www.jyloke.com/" & receipt_id & ".pdf"
        Dim request As New WebClient()
        request.Credentials = New System.Net.NetworkCredential("receipts@jyloke.com", "rq4m8k]hGL<G")
        Dim DownloadStream As FileStream = New FileStream(dir & receipt_id & ".pdf", FileMode.Create)
        Try
            Dim bytes() As Byte = request.DownloadData(url)

            Try
                DownloadStream.Write(bytes, 0, bytes.Length)
                '  Close the FileStream
                DownloadStream.Close()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Exit Sub
            End Try

            oldReceiptfilePath = dir & receipt_id & ".pdf"

        Catch ex As Exception
            MsgBox("Failed to download receipt. Please try again.")
        Finally
            DownloadStream.Close()
        End Try

    End Sub

    Private Sub BackgroundWorker2_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted
        ViewPDF.src = oldReceiptfilePath
    End Sub

    Public Sub printOldReceipt(ByVal receiptId As Integer)
        receipt_id = receiptId
        BackgroundWorker2.RunWorkerAsync()
    End Sub

    Private Sub cmbClass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClass.SelectedIndexChanged

    End Sub
End Class