Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient

Public Class FeeDetailsvb

    Dim db As New DBOperations.Connection
    Dim conn As New MySqlConnection
    Dim cmd As New MySqlCommand
    Dim dadapter As New MySqlDataAdapter
    Dim datardr As MySqlDataReader
    Public totalFeeReceived As Integer
    Dim vanFeeExists As Boolean = False
    Dim schoolFeeSaved As Boolean = False
    Dim vanFeeSaved As Boolean = False

    Private Sub FeeDetailsvb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub txtFeeReceived_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles txtFeeReceived.PreviewKeyDown

        If e.KeyData = Keys.Tab Or e.KeyData = Keys.Enter Then
            If Not txtFeeReceived.Text.Length = 0 Then
                Dim recv As Integer = Integer.Parse(txtFeeReceived.Text)
                Dim fees As Integer = Integer.Parse(lblPresFees.Text)
                If recv > fees Then
                    MsgBox("Fees Received cannot be greater than prescribed fees.")
                    txtFeeReceived.Focus()
                    txtFeeReceived.Text = ""
                    txtFeeBalance.Text = ""
                Else
                    Me.txtFeeBalance.Text = Integer.Parse(lblPresFees.Text) - Integer.Parse(txtFeeReceived.Text) - totalFeeReceived
                End If
            End If

        End If

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If validate_Form() Then
            Try
                Dim result As Integer
                conn = db.connect(GlobalSettings.My.MySettings.Default.Branch)
                Dim dt As Date
                dt = dtFeeReceived.Value
                Dim dta As String
                Dim dtb As String
                dta = dt.ToString("yyyy-MM-dd")
                dt = dtBankDeposit.Value
                dtb = dt.ToString("yyyy-MM-dd")

                Dim Sql As String = "INSERT INTO fee_details (`FEES_RECV`, `FEES_BAL`, `DATE`, `BANK_DEP_AMT`, `BANK_DEP_DATE`, `REMARKS`, `STUD_ID`) " &
                                        "VALUES ('" & txtFeeReceived.Text & "', '" & txtFeeBalance.Text & "', '" & dta & "', '" & txtBankDepAmt.Text & "', '" & dtb & "', '" & txtRemarks.Text & "', '" & lblREGN.Text & "');"

                cmd = New MySqlCommand(Sql, conn)
                result = cmd.ExecuteNonQuery

                If result = 0 Then
                    MsgBox("School Fee Details Not Saved. An Error occured!")
                Else
                    schoolFeeSaved = True
                End If
            Catch ex As Exception
                MsgBox("Could not save fee details. An error occured. Please try again later")
            Finally
                db.disconnect(conn)
            End Try

        End If


        If txtVanFeeReceived.Text.Length > 0 Or txtVanFeeBankDepAmt.Text.Length > 0 Then
            vanFeeExists = True

            If validate_Form_vanFees() Then
                Try
                    Dim result As Integer
                    conn = db.connect(GlobalSettings.My.MySettings.Default.Branch)
                    Dim dt As Date
                    dt = dtFeeReceived.Value
                    Dim dta As String
                    Dim dtb As String
                    dta = dt.ToString("yyyy-MM-dd")
                    dt = dtBankDeposit.Value
                    dtb = dt.ToString("yyyy-MM-dd")

                    Dim Sql As String = "INSERT INTO van_fee_details (`FEES_RECV`, `FEES_BAL`, `DATE`, `BANK_DEP_AMT`, `BANK_DEP_DATE`, `REMARKS`, `STUD_ID`) " &
                                            "VALUES ('" & txtVanFeeReceived.Text & "', '" & txtVanFeeBalance.Text & "', '" & dta & "', '" & txtVanFeeBankDepAmt.Text & "', '" & dtb & "', '" & txtVanFeeRemarks.Text & "', '" & lblREGN.Text & "');"

                    cmd = New MySqlCommand(Sql, conn)
                    result = cmd.ExecuteNonQuery

                    If result = 0 Then
                        MsgBox("Fee Details Not Saved. An Error occured!")
                    Else
                        vanFeeSaved = True
                    End If
                Catch ex As Exception
                    MsgBox("Could not save fee details. An error occured. Please try again later")
                Finally
                    db.disconnect(conn)
                End Try

            End If

        Else
            vanFeeExists = False
        End If

        If schoolFeeSaved = True Or vanFeeSaved = True Then
            If MsgBox("Fee Details Saved Successfully! Would you like to print a receipt?", MsgBoxStyle.YesNo) = DialogResult.Yes Then
                Dim frm As New Receipts.NewReceipt
                frm.txtREGN.Text = lblREGN.Text
                frm.ClassesTableAdapter.Fill(frm.Prajwal_school_appDataSet.classes)
                frm.populateStudentDetails(lblREGN.Text)
                'frm.GroupBox2.Enabled = True
                frm.Button1_Click(Nothing, Nothing)
                frm.Show()
                Me.Close()
            Else
                Me.Close()
            End If
        End If


    End Sub


    Private Function validate_Form() As Boolean

        Dim result As Boolean
        result = True

        If txtRemarks.Text.Contains("'") Then
            lblErrRemarks.Visible = True
            lblErrRemarks.Text = "Character not allowed -> '"
            result = False
        Else
            lblErrRemarks.Visible = False
        End If

        If Not dtFeeReceived.Value < DateTime.Now Then
            lblErrDate.Visible = True
            result = False
        Else
            lblErrDate.Visible = False
        End If

        If Not dtBankDeposit.Value < DateTime.Now Then
            lblErrBankDepDate.Visible = True
            result = False
        Else
            lblErrBankDepDate.Visible = False
        End If

        If txtFeeReceived.Text.Length = 0 Then
            lblErrFeesReceived.Visible = True
            lblErrFeesReceived.Text = "Cannot be empty"
            result = False
        ElseIf txtFeeReceived.Text.Length > 0 AndAlso Not Regex.Match(txtFeeReceived.Text, "^[0-9]+$", RegexOptions.None).Success Then
            lblErrFeesReceived.Visible = True
            lblErrFeesReceived.Text = "Only numbers allowed"
            result = False
        ElseIf Integer.Parse(txtFeeReceived.Text) > Integer.Parse(lblPresFees.Text) Then
            lblErrFeesReceived.Visible = True
            lblErrFeesReceived.Text = "Amount cannot exceed prescribed fees"
            result = False
        Else
            lblErrFeesReceived.Visible = False
        End If

        If txtBankDepAmt.Text.Length = 0 Then
            lblErrBankDepAmt.Visible = True
            lblErrBankDepAmt.Text = "Cannot be empty"
            result = False
        ElseIf txtBankDepAmt.Text.Length > 0 AndAlso Not Regex.Match(txtBankDepAmt.Text, "^[0-9]+$", RegexOptions.None).Success Then
            lblErrBankDepAmt.Visible = True
            lblErrBankDepAmt.Text = "Only numbers allowed"
            result = False
        ElseIf Integer.Parse(txtBankDepAmt.Text) > Integer.Parse(lblPresFees.Text) Then
            lblErrBankDepAmt.Visible = True
            lblErrBankDepAmt.Text = "Amount cannot exceed prescribed fees"
            result = False
        Else
            lblErrBankDepAmt.Visible = False
        End If

        Return result

    End Function

    Private Function validate_Form_vanFees() As Boolean

        Dim result As Boolean
        result = True

        If txtVanFeeRemarks.Text.Contains("'") Then
            lblVanErrRemarks.Visible = True
            lblVanErrRemarks.Text = "Character not allowed -> '"
            result = False
        Else
            lblVanErrRemarks.Visible = False
        End If

        If Not dtVanfeeReceived.Value < DateTime.Now Then
            lblVanErrFeeDate.Visible = True
            result = False
        Else
            lblVanErrFeeDate.Visible = False
        End If

        If Not dtVanFeeBankDeposit.Value < DateTime.Now Then
            lblVanErrBankDepDate.Visible = True
            result = False
        Else
            lblVanErrBankDepDate.Visible = False
        End If

        'If txtFeeReceived.Text.Length = 0 Then
        '    lblErrFeesReceived.Visible = True
        '    lblErrFeesReceived.Text = "Cannot be empty"
        '    result = False
        'ElseIf txtFeeReceived.Text.Length > 0 AndAlso Not Regex.Match(txtFeeReceived.Text, "^[0-9]+$", RegexOptions.None).Success Then
        '    lblErrFeesReceived.Visible = True
        '    lblErrFeesReceived.Text = "Only numbers allowed"
        '    result = False
        'ElseIf Integer.Parse(txtFeeReceived.Text) > Integer.Parse(lblPresFees.Text) Then
        '    lblErrFeesReceived.Visible = True
        '    lblErrFeesReceived.Text = "Amount cannot exceed prescribed fees"
        '    result = False
        'Else
        '    lblErrFeesReceived.Visible = False
        'End If

        'If txtBankDepAmt.Text.Length = 0 Then
        '    lblErrBankDepAmt.Visible = True
        '    lblErrBankDepAmt.Text = "Cannot be empty"
        '    result = False
        'ElseIf txtBankDepAmt.Text.Length > 0 AndAlso Not Regex.Match(txtBankDepAmt.Text, "^[0-9]+$", RegexOptions.None).Success Then
        '    lblErrBankDepAmt.Visible = True
        '    lblErrBankDepAmt.Text = "Only numbers allowed"
        '    result = False
        'ElseIf Integer.Parse(txtBankDepAmt.Text) > Integer.Parse(lblPresFees.Text) Then
        '    lblErrBankDepAmt.Visible = True
        '    lblErrBankDepAmt.Text = "Amount cannot exceed prescribed fees"
        '    result = False
        'Else
        '    lblErrBankDepAmt.Visible = False
        'End If

        Return result

    End Function

    Private Sub FeeDetailsvb_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim frm As New Form0
        frm = CType(Owner, Form0)
        frm.UpdatePaymentDetails()

    End Sub

End Class