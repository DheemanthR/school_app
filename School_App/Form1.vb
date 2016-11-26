
Imports MySql.Data.MySqlClient

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim studForm As New StudentInfo.Form0
        If Not Application.OpenForms().OfType(Of StudentInfo.Form0).Any Then
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
        Dim db As New DBOperations.Connection
        Dim conn As New MySqlConnection
        conn = db.connect()
        If Not conn Is Nothing Then
            stsDBConn.Text = "Database: Connected"
            stsDBConn.ForeColor = Color.Green
        Else
            stsDBConn.Text = "Database: Disonnected"
            stsDBConn.ForeColor = Color.Red
        End If
    End Sub
End Class
