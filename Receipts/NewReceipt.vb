Imports System.Drawing.Printing
Imports System.IO
Imports System.Text
Imports System.Web.UI
Imports DocumentFormat.OpenXml.Wordprocessing

Imports Microsoft.Reporting.WinForms
Imports MySql.Data.MySqlClient


Public Class NewReceipt

    Private printPreviewDialog As New PrintPreviewDialog()
    Private WithEvents printDocument1 As New PrintDocument()

    Dim db As New DBOperations.Connection
    Dim conn As New MySqlConnection
    Dim cmd As New MySqlCommand
    Dim dadapter As New MySqlDataAdapter
    Dim datardr As MySqlDataReader
    ' Declare a string to hold the entire document contents.
    Private documentContents As String

    ' Declare a variable to hold the portion of the document that
    ' is not printed.
    Private stringToPrint As String
    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub NewReceipt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Prajwal_school_appDataSet.classes' table. You can move, or remove it, as needed.
        Me.ClassesTableAdapter.Fill(Me.Prajwal_school_appDataSet.classes)
        Me.Button1.Enabled = False

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

                'Sql = "INSERT INTO particulars ('PARTICULARS','AMOUNT','STUD_ID','RECEIPT_ID') VALUES('" & txtREGN.Text & "', '" & txtAmount.Text & "','" & txtBalance.Text & "')"
                'cmd = New MySqlCommand(Sql, conn)
                'cmd.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox("An error occured while saving receipt details to database. Please try again")
            Finally
                db.disconnect(conn)
            End Try

        Else
            MsgBox("Please fill all fields correctly")
        End If


        'Else
        'save receipt data

        'End If
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
        conn = db.connect()
        Dim Sql As String = "Select FIRST_NAME, LAST_NAME, SECTION, CLASS from `prajwal_school_app`.`student` where REGN = '" & ID & "';"
        cmd.CommandText = Sql
        cmd.Connection = conn
        dadapter.SelectCommand = cmd
        Try
            datardr = cmd.ExecuteReader
            If datardr.HasRows Then
                datardr.Read()

                txtFName.Text = datardr("FIRST_NAME")

                txtLName.Text = datardr("LAST_NAME")

                txtSection.Text = datardr("SECTION")

                'cmbClass.SelectedIndex = 2 'datardr("CLASS")
                Me.ViewPDF.Enabled = True

            Else
                MsgBox("Student Data Not Found")
            End If
            datardr.Close()

            Sql = "Select * FROM fee_details where STUD_ID = '" & ID & "' ORDER BY FEES_BAL ASC;"
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

            End If
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
        Button1.Enabled = True
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

        If txtAmount.TextLength = 0 Then
            Return False
        End If

        If txtBalance.TextLength = 0 Then
            Return False
        End If

        If txtAIW.TextLength = 0 Then
            Return False
        End If

        Return True

    End Function

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim frm As New Receipts.StudentSearch
        frm.Owner = Me
        frm.Show()
    End Sub
End Class