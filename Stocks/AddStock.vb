Imports MySql.Data.MySqlClient

Public Class AddStock
    Dim db As New DBOperations.Connection
    Dim conn As New MySqlConnection
    Dim cmd As New MySqlCommand
    Dim dadapter As New MySqlDataAdapter
    Dim itemLoaded As Boolean = False
    Dim prevStock As Integer = 0
    Dim itemName As String
    Dim id As Object

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath)
    End Sub

    Friend Sub getID(ByVal name As String)
        itemName = name
        Try
            conn = db.connect(GlobalSettings.My.MySettings.Default.Branch)
            Dim sql As String
            sql = "SELECT ID FROM student_supplies WHERE ITEM LIKE '" & itemName & "'"
            cmd = New MySqlCommand(sql, conn)
            dadapter.SelectCommand = cmd
            id = cmd.ExecuteScalar()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            db.disconnect(conn)
        End Try
    End Sub

    Private Sub txtItemID_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtItemID.PreviewKeyDown
        If e.KeyData = Keys.Tab Or e.KeyData = Keys.Enter Then

            Try
                id = txtItemID.Text
                BackgroundWorker1.RunWorkerAsync()
            Catch ex As Exception
                MsgBox("Item data could not be retrieved. An Error Occured.")
            Finally
                conn.Close()
            End Try

        End If
    End Sub

    Private Sub populateItemDetails(ByVal itemID As String)

        Try
            conn = db.connect(GlobalSettings.My.MySettings.Default.Branch)
            Dim sql As String = "SELECT CLOSING_STOCK FROM stock WHERE ITEM_ID = '" & itemID & "' AND ID IN (SELECT MAX(ID) FROM stock WHERE ITEM_ID = '" & itemID & "')"
            cmd = New MySqlCommand(sql, conn)
            dadapter.SelectCommand = cmd
            prevStock = cmd.ExecuteScalar
            lblPrevStock.Text = prevStock & " Units"
            sql = "SELECT * FROM student_supplies WHERE ID = '" & itemID & "'"
            Dim dt As New DataTable
            cmd = New MySqlCommand(sql, conn)
            dadapter = New MySqlDataAdapter(cmd)
            dadapter.Fill(dt)
            If dt.Rows.Count = 0 Then
                MsgBox("Item Not Found. Please verify that the Item ID has been entered correctly")
            Else
                lblItemName.Text = dt.Rows(0).Item("ITEM")
                lblPrice.Text = dt.Rows(0).Item("PRICE")
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
        populateItemDetails(id)
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
            Dim sql As String = "INSERT INTO `stock`(`ITEM_ID`, `OPENING_STOCK`, `CLOSING_STOCK`, `INFLOW`) VALUES ('" & txtItemID.Text & "','" & openStock.ToString & "','" & closeStock.ToString & "','" & txtIncomingStock.Text & "')"
            cmd = New MySqlCommand(sql, conn)
            Dim result As Integer = cmd.ExecuteNonQuery()
            If Not result > 0 Then
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