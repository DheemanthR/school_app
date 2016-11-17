Imports System.Drawing.Printing
Imports System.IO
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports MySql.Data.MySqlClient
Imports DocumentFormat.OpenXml.Drawing

Public Class NewReceipt

    Public particulars As New DataTable
    Dim db As New DBOperations.Connection
    Dim conn As New MySqlConnection
    Dim cmd As New MySqlCommand
    Dim dadapter As New MySqlDataAdapter
    Dim datardr As MySqlDataReader

    Dim NoPayment As Boolean = False
    Public manEntry As Boolean = False

    Private Sub NewReceipt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Prajwal_school_appDataSet.classes' table. You can move, or remove it, as needed.
        Me.ClassesTableAdapter.Fill(Me.Prajwal_school_appDataSet.classes)
        particulars.Columns.Add("Sl", GetType(Integer))
        particulars.Columns.Add("Particulars", GetType(String))
        particulars.Columns.Add("Amount", GetType(String))
        Me.GroupBox2.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If form_valid() Then

            Try
                conn = db.connect()
                Dim result As Integer
                Dim Sql As String = "INSERT INTO receipt_details (STUD_ID,AMOUNT,BALANCE) VALUES('" & txtREGN.Text & "', '" & txtAmount.Text & "','" & txtBalance.Text & "')"
                cmd = New MySqlCommand(Sql, conn)
                result = cmd.ExecuteNonQuery()

                Sql = "SELECT MAX(ID) FROM receipt_details"
                cmd.CommandText = Sql
                cmd.Connection = conn
                dadapter.SelectCommand = cmd
                Dim receipt_id As Integer
                datardr = cmd.ExecuteReader
                If datardr.HasRows Then
                    datardr.Read()

                    receipt_id = datardr("MAX(ID)")
                End If

                datardr.Close()
                generateBill(receipt_id)
                Sql = "UPDATE fee_details SET BILL_GEN = 1 WHERE STUD_ID = '" & txtREGN.Text & "'"
                cmd = New MySqlCommand(Sql, conn)
                result = cmd.ExecuteNonQuery()

                If result > 0 Then
                    stsLabel.Text = "Receipt details saved successfully"
                End If


            Catch ex As Exception
                MsgBox("An error occured while saving receipt details to database. Please try again")
            Finally
                db.disconnect(conn)
            End Try

        Else
            MsgBox("Please fill all fields correctly")
        End If

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
            conn = db.connect()
            Dim Sql As String = "Select FIRST_NAME, LAST_NAME, SECTION, CLASS from `prajwal_school_app`.`student` where REGN = '" & ID & "';"
            cmd.CommandText = Sql
            cmd.Connection = conn
            dadapter.SelectCommand = cmd
            datardr = cmd.ExecuteReader
            If datardr.HasRows Then
                datardr.Read()

                txtFName.Text = datardr("FIRST_NAME")

                txtLName.Text = datardr("LAST_NAME")

                txtSection.Text = datardr("SECTION")

                cmbClass.SelectedIndex = datardr("CLASS")

            Else
                MsgBox("Student Data Not Found")
            End If
            datardr.Close()

            Sql = "Select * FROM fee_details where STUD_ID = '" & ID & "'AND BILL_GEN = 0 ORDER BY FEES_BAL ASC;"
            Dim amount As Integer
            cmd.CommandText = Sql
            cmd.Connection = conn
            dadapter.SelectCommand = cmd

            datardr = cmd.ExecuteReader
            If datardr.HasRows Then
                datardr.Read()
                amount = datardr("FEES_RECV")
                txtAmount.Text = amount
                txtBalance.Text = datardr("FEES_BAL")
                dtReceipt.Text = datardr("DATE")
                If amount < 99999 Then
                    txtAIW.Text = amount_in_words(amount)
                Else
                    txtAIW.Text = ""
                    MsgBox("Cannot convert amount to words!")
                End If
            Else
                NoPayment = True
                MsgBox("No payments pending for this student")
            End If
            stsLabel.Text = "Student and payment data loaded successfully"
            GroupBox2.Enabled = True
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
        ElseIf thousands = 0 Or flag2 = True Then
            aiw += "Thousand "
        End If

        If hundreds > 0 Then
            aiw += "and " + return_words(hundreds) + " Hundred"
        End If

        If tens > 1 Then
            aiw += " and " + return_tens(tens) + " "
        ElseIf tens = 1 Then
            aiw += " and " + return_tens_one(units)
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

        If cmbClass.SelectedIndex = 0 Then
            Return False
        End If

        If manEntry = True AndAlso NoPayment = True Then

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

        Dim orderDate As String = DateTime.Now.ToString("dd/MM/yyyy")
        Dim totalAmt As Integer
        Dim space As iTextSharp.text.Paragraph = New iTextSharp.text.Paragraph(vbCrLf)
        Dim doc As New iTextSharp.text.Document(PageSize.A4, 36, 36, 36, 36)
        Dim pdfWrite As PdfWriter = PdfWriter.GetInstance(doc, New FileStream("Receipt.pdf", FileMode.Create))
        doc.Open()
        Dim image As System.Drawing.Image = System.Drawing.Image.FromHbitmap(My.Resources.Thums_Education_Center1.GetHbitmap())
        Dim logo As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(image, System.Drawing.Imaging.ImageFormat.Png)
        logo.Alignment = Element.ALIGN_CENTER
        logo.ScaleToFit(2300.0F, 125.0F)
        doc.Add(logo)
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

        'Adding first row as fees by default
        If Integer.Parse(txtAmount.Text) > 0 Then
            Cell = New PdfPCell(New Phrase("1"))
            Cell.HorizontalAlignment = 1
            Table.AddCell(Cell)
            Table.AddCell("Fees")
            Cell = New PdfPCell(New Phrase(txtAmount.Text))
            Cell.HorizontalAlignment = 1
            Table.AddCell(Cell)
        End If

        If Integer.TryParse(txtAmount.Text, totalAmt) Then

        Else
            txtAmount.Text = 0
            totalAmt = 0
            stsLabel.Text = "No pending payments for this student"
        End If
        totalAmt = Integer.Parse(txtAmount.Text)

        'Now adding other particulars
        If particulars.Rows.Count > 0 Then
            For Each row As DataRow In particulars.Rows
                If Table.Rows.Count = 1 Then
                    Cell = New PdfPCell(New Phrase((row.Item(0) + 1).ToString))
                Else
                    Cell = New PdfPCell(New Phrase((row.Item(0)).ToString))
                End If
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
        ViewPDF.src = "C:\Users\Dheemanth\Documents\Visual Studio 2015\Projects\School_App\School_App\bin\Debug\Receipt.pdf"

    End Sub
End Class