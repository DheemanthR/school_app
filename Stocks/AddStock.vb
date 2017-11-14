Imports MySql.Data.MySqlClient

Public Class AddStock
    Dim db As New DBOperations.Connection
    Dim conn As New MySqlConnection
    Dim cmd As New MySqlCommand
    Dim dadapter As New MySqlDataAdapter
    Dim itemLoaded As Boolean = False
    Dim prevStock As Integer = 0
    Dim itemID As Integer
    'Dim id As Object

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath)
    End Sub

    Friend Sub getID(ByVal ID As Integer)
        itemID = ID
    End Sub

    Private Sub txtItemID_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtItemID.PreviewKeyDown
        If e.KeyData = Keys.Tab Or e.KeyData = Keys.Enter Then

            Try
                itemID = Integer.Parse(txtItemID.Text)
                BackgroundWorker1.RunWorkerAsync()
            Catch ex As Exception
                MsgBox("Item data could not be retrieved. An Error Occured.")
            Finally
                conn.Close()
            End Try

        End If
    End Sub

    Private Sub populateItemDetails()

        Try
            conn = db.connect(GlobalSettings.My.MySettings.Default.Branch)

            Dim sql As String = "SELECT * FROM student_supplies WHERE ID = '" & itemID & "'"
            Dim dt As New DataTable
            cmd = New MySqlCommand(sql, conn)
            dadapter = New MySqlDataAdapter(cmd)
            dadapter.Fill(dt)
            If dt.Rows.Count = 0 Then
                MsgBox("Item Not Found. Please verify that the Item ID has been entered correctly")
            Else
                lblItemName.Text = dt.Rows(0).Item("ITEM")
                lblPrice.Text = dt.Rows(0).Item("PRICE")
                prevStock = dt.Rows(0).Item("CLOSING_STOCK")
                lblPrevStock.Text = prevStock & " Units"
                itemLoaded = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            db.disconnect(conn)
        End Try
    End Sub

    Public Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Me.Cursor = Cursors.WaitCursor
        populateItemDetails()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        If txtIncomingStock.TextLength = 0 Then
            ErrorProvider1.SetError(txtIncomingStock, "Incoming Stock cannot be empty")
        ElseIf txtIncomingStock.TextLength > 0 Then
            If Integer.Parse(txtIncomingStock.Text) < 1 Then
                ErrorProvider1.SetError(txtIncomingStock, "Invalid Incoming Stock.")
            End If
        End If

        If itemLoaded = False Then
            MsgBox("Please load an item by entering a valid Item ID")
        End If

        Try
            conn = db.connect(GlobalSettings.My.MySettings.Default.Branch)
            Dim openStock, closeStock As Integer
            openStock = closeStock = 0
            openStock = prevStock + Integer.Parse(txtIncomingStock.Text)
            closeStock = prevStock + Integer.Parse(txtIncomingStock.Text)
            Dim sql As String = "INSERT INTO `stock`(`ITEM_ID`, `INFLOW`) VALUES ('" & itemID & "','" & txtIncomingStock.Text & "')"
            cmd = New MySqlCommand(sql, conn)
            Dim result1 As Integer = cmd.ExecuteNonQuery()
            sql = "UPDATE `student_supplies` SET CLOSING_STOCK = CLOSING_STOCK + " & txtIncomingStock.Text & " WHERE ID = '" & itemID & "'"
            cmd = New MySqlCommand(sql, conn)
            Dim result2 As Integer = cmd.ExecuteNonQuery()
            If Not result1 > 0 AndAlso Not result2 > 0 Then
                Throw New Exception
            Else
                If MsgBox("Stock successfully updated for Item ID '" & txtItemID.Text & "'") = DialogResult.OK Then
                    Dim frm As StockManager
                    frm = CType(Owner, StockManager)
                    frm.populateStock()
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            db.disconnect(conn)
        End Try
    End Sub
End Class