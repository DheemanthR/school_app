Imports MySql.Data.MySqlClient

Public Class AddSupplies

    Dim frm As New Form0
    Dim db As New DBOperations.Connection
    Dim conn As New MySqlConnection
    Dim cmd As New MySqlCommand
    Dim dadapter As New MySqlDataAdapter
    Dim ds As DataTable

    Private Sub AddSupplies_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath)
        frm = CType(Owner, Form0)

    End Sub

    Private Sub btnAddSupplies_Click(sender As Object, e As EventArgs) Handles btnAddSupplies.Click


        Dim selected As Boolean = False
        Dim dt As New DataTable
        dt.Columns.Add("Item", GetType(String))
        dt.Columns.Add("Price", GetType(String))
        'dt.Columns.Add("Stock", GetType(String))
        Dim row As DataRow
        For Each item As ListViewItem In lvSupplies.Items
            row = dt.NewRow
            If item.Checked Then
                selected = True
                row("Item") = item.SubItems(0).Text
                row("Price") = item.SubItems(1).Text
                'row("Stock") = item.SubItems(1).Text
                dt.Rows.Add(row)
                item.Remove()
                'frm.listSupplies.Items.Add(item)
            End If
        Next
        If selected = False Then
            MsgBox("Select at least one item to add.")
        Else
            frm.populate_listview(dt)
            Me.Close()
        End If
    End Sub

    Private Sub btnCheckAll_Click(sender As Object, e As EventArgs) Handles btnCheckAll.Click
        For Each item As ListViewItem In lvSupplies.Items
            If item.Checked = False Then
                item.Checked = True
            End If
        Next
    End Sub

    Private Sub btnUncheckAll_Click(sender As Object, e As EventArgs) Handles btnUncheckAll.Click
        For Each item As ListViewItem In lvSupplies.Items
            If item.Checked = True Then
                item.Checked = False
            End If
        Next
    End Sub

    Public Sub populate_list(ByVal dt As DataTable)
        Try
            conn = db.connect(GlobalSettings.My.MySettings.Default.Branch)
            Dim Sql As String = "SELECT SS.ITEM, SS.PRICE, s1.CLOSING_STOCK
                                 FROM student_supplies SS, stock s1 LEFT JOIN stock s2
                                 ON (s1.ITEM_ID = s2.ITEM_ID AND s1.ID < s2.ID)
                                 WHERE s2.ID IS NULL AND s1.ITEM_ID = SS.ID"
            cmd = New MySqlCommand(Sql, conn)
            dadapter = New MySqlDataAdapter(cmd)

            ds = New DataTable
            dadapter.Fill(ds)
            Dim newRow As DataRow
            For Each newRow In ds.Rows
                If Not dt.Rows.Contains(newRow.Item(0)) Then
                    Dim item As New ListViewItem(newRow.Item(0).ToString)
                    item.SubItems.Add(newRow.Item(1).ToString)
                    item.SubItems.Add(newRow.Item(2).ToString)
                    lvSupplies.Items.Add(item)
                End If

            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            db.disconnect(conn)
        End Try
    End Sub

End Class