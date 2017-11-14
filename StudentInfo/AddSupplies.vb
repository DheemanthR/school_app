Imports MySql.Data.MySqlClient

Public Class AddSupplies

    Dim frm As New Form0
    Dim db As New DBOperations.Connection
    Dim conn As New MySqlConnection
    Dim cmd As New MySqlCommand
    Dim dadapter As New MySqlDataAdapter
    Dim ds As DataTable
    Public REGN As String
    Public dt As New DataTable

    Private Sub AddSupplies_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath)
        frm = CType(Owner, Form0)

    End Sub

    Private Sub btnAddSupplies_Click(sender As Object, e As EventArgs) Handles btnAddSupplies.Click

        Dim Sql As String
        Dim selected As Boolean = False
        dt.Columns.Add("Item", GetType(String))
        dt.Columns.Add("Price", GetType(String))
        dt.Columns.Add("Quantity", GetType(String))
        Dim row As DataRow

        conn = db.connect(GlobalSettings.My.MySettings.Default.Branch)

        For Each item As DataGridViewRow In dgvSupplies.Rows
            row = dt.NewRow
            If item.Cells(0).Value = True And Integer.Parse(item.Cells(4).Value) > 0 Then
                selected = True
                row("Item") = item.Cells(1).Value
                row("Price") = item.Cells(2).Value
                row("Quantity") = item.Cells(4).Value
                dt.Rows.Add(row)

                Sql = "UPDATE student_supplies SET CLOSING_STOCK = CLOSING_STOCK - " & item.Cells(4).Value & " WHERE ITEM LIKE '" & item.Cells(1).Value & "'"
                cmd = New MySqlCommand(Sql, conn)
                cmd.ExecuteNonQuery()

                Dim itemID As Integer
                Dim foundRows() As DataRow
                foundRows = ds.Select("ITEM = '" & item.Cells(1).Value & "'")
                itemID = foundRows.ElementAt(0).Item(0)

                Sql = "INSERT INTO stock (`ITEM_ID`, `OUTFLOW`) VALUES ('" & itemID & "','" & item.Cells(4).Value & "')"
                cmd = New MySqlCommand(Sql, conn)
                cmd.ExecuteNonQuery()
            End If
        Next

        db.disconnect(conn)

        Dim frm2 As New Receipts.NewReceipt
        If MsgBox("New Supplies successfully added. Would you like to print receipt?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            frm2.dtsupplies = dt.Copy
            frm2.Show()
            frm2.suppliesReceiptGen(REGN)
        End If

        If selected = False Then
            MsgBox("Select at least one item to add.")
        Else
            frm.populate_listview(dt)
            Me.Close()
        End If
    End Sub

    Private Sub btnCheckAll_Click(sender As Object, e As EventArgs) Handles btnCheckAll.Click
        For Each item As DataGridViewRow In dgvSupplies.Rows
            If item.Cells(0).Value = False Then
                item.Cells(0).Value = True
            End If
        Next
    End Sub

    Private Sub btnUncheckAll_Click(sender As Object, e As EventArgs) Handles btnUncheckAll.Click
        For Each item As DataGridViewRow In dgvSupplies.Rows
            If item.Cells(0).Value = True Then
                item.Cells(0).Value = False
            End If
        Next
    End Sub

    Public Sub populate_list(ByVal dt As DataTable)
        Dim item() As String
        Try
            conn = db.connect(GlobalSettings.My.MySettings.Default.Branch)
            Dim Sql As String = "SELECT ID, ITEM, PRICE, CLOSING_STOCK
                                 FROM student_supplies WHERE CLOSING_STOCK > 0"
            cmd = New MySqlCommand(Sql, conn)
            dadapter = New MySqlDataAdapter(cmd)

            ds = New DataTable
            dadapter.Fill(ds)
            Dim newRow As DataRow
            For Each newRow In ds.Rows
                item = New String() {False, newRow.Item(1).ToString, newRow.Item(2).ToString, newRow.Item(3).ToString, "0"}
                dgvSupplies.Rows.Add(item)
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            db.disconnect(conn)
        End Try
    End Sub

    Private Sub EndEditMode(sender As System.Object,
                        e As EventArgs) _
            Handles dgvSupplies.CurrentCellDirtyStateChanged
        'if current cell of grid is dirty, commits edit
        If dgvSupplies.IsCurrentCellDirty Then
            dgvSupplies.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvSupplies.CellValueChanged

        If e.ColumnIndex = 0 AndAlso dgvSupplies.Rows.Item(e.RowIndex).Cells(0).Value = True Then
            dgvSupplies.Rows.Item(e.RowIndex).Cells(4).Value = 1
        End If

        If e.ColumnIndex = 0 AndAlso dgvSupplies.Rows.Item(e.RowIndex).Cells(0).Value = False Then
            dgvSupplies.Rows.Item(e.RowIndex).Cells(4).Value = 0
        End If

    End Sub

End Class