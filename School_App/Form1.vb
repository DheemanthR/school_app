
Imports MySql.Data.MySqlClient

Public Class Form1
    Dim db As New DBOperations.Connection
    Dim conn As New MySqlConnection
    Dim attempt As Integer = 0

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim studForm As New StudentInfo.Form0
        If Not Application.OpenForms().OfType(Of StudentInfo.Form0).Any Then
            Cursor.Current = Cursors.WaitCursor
            studForm.Show()
        Else
            studForm.BringToFront()
        End If
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim frm As New Receipts.PrintReceipts
        If Not Application.OpenForms().OfType(Of Receipts.PrintReceipts).Any Then
            Cursor.Current = Cursors.WaitCursor
            frm.Show()
        Else
            frm.BringToFront()
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Dim frm As New About
        frm.Show()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath)
        Control.CheckForIllegalCrossThreadCalls = False
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub mnuSettings_Click(sender As Object, e As EventArgs) Handles mnuSettings.Click
        Dim frm As New GlobalSettings.Security
        frm.Show()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            While attempt < 5
                conn = db.connect(GlobalSettings.My.MySettings.Default.Branch)
                If Not conn Is Nothing Then
                    stsDBConn.Text = "Database: Connected"
                    stsDBConn.ForeColor = Color.Green
                    attempt = 5
                Else
                    If attempt = 4 Then
                        stsDBConn.Text = "Database: Disonnected (Failed to Establish Connection)"
                    Else
                        stsDBConn.Text = "Database: Disonnected (Attempting to Reconnect)"
                    End If
                    stsDBConn.ForeColor = Color.Red
                    System.Threading.Thread.Sleep(5000)
                    attempt += 1
                End If

            End While

        Catch ex As Exception
            MsgBox("An error occured while connecting to database. Restarting the application might solve the problem. For more information, contact the administrator")
        Finally
            db.disconnect(conn)
        End Try
    End Sub

    Private Sub Queries_Click(sender As Object, e As EventArgs) Handles btnQueries.Click
        Dim frm As New Queries.QueryManeger
        Cursor.Current = Cursors.WaitCursor
        frm.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim frm As New Stocks.StockManager
        Cursor.Current = Cursors.WaitCursor
        frm.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim frm As New ApprovalCenter.Approvals
        Cursor.Current = Cursors.WaitCursor
        frm.Show()
    End Sub
End Class
