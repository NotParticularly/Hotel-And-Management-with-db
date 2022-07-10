Imports MySql.Data.MySqlClient

Public Class Form1

    Public conn As New MySqlConnection
    Public cmd As New MySqlCommand
    Public adapter As New MySqlDataAdapter
    Public ds As New DataSet
    Public itemColl(999) As String
    Private SrchParameter As String = ""
    Private NxtStrtRow As Integer = 0
    Dim roomReference As String
    Dim roomRefBind As String
    Private addText As New List(Of String)
    Dim lvGhost As ListView


    Private Sub txtSearchBar_TextChanged(sender As Object, e As EventArgs) Handles txtSearchBar.TextChanged
        'adapter = New MySqlDataAdapter("Select * from tblcustomertwo where CustomerID like '" & txtCustomerID.Text & "%'", conn)
        ' ds = New DataSet
        ' adapter.Fill(ds, "tblcustomertwo")
        'ListView1.DataBindings = ds.Tables("tblcustomertwo").DefaultView

        If txtSearchBar.Text = "" Then
            loadList()
        End If




    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If txtFirstname.Text = "" Or txtFirstname.Text = "" Or txtLastname.Text = "" Or txtNoOfRooms.Text = "" Or txtPhone.Text = "" Or txtAddress.Text = "" Then
            MessageBox.Show("Please specify the blank inputs", "Hotel And Management")
        Else
            Try
                openConn()
                cmd.Connection = conn
                cmd.CommandText = "insert into tblcustomertwo (`Firstname`,`Lastname`, `NoOfRooms`, `Phone`, `CheckinDate`, `CheckoutDate`, `RoomReference`, `Address`) values ('" & txtFirstname.Text & "', '" & txtLastname.Text & "', '" & txtNoOfRooms.Text & "', '" & txtPhone.Text & "', '" & dtCheckIn.Text & "', '" & dtCheckOut.Text & "',  '" & roomReference & "','" & txtAddress.Text & "')"
                cmd.ExecuteNonQuery()
                MessageBox.Show("Successfuly Saved", "Hotel And Management")
                conn.Close()
                loadList()
                clearInputs()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Hotel And Management")
            End Try
        End If

    End Sub

    Sub openConn()
        conn.ConnectionString = "server=localhost; username=root; password=; database=dbhotelmanagement; port=3308"
        conn.Open()
    End Sub

    Private Sub rbStandard_CheckedChanged(sender As Object, e As EventArgs) Handles rbStandard.CheckedChanged
        roomReference = "Standard"
    End Sub

    Private Sub rbDeluxe_CheckedChanged(sender As Object, e As EventArgs) Handles rbDeluxe.CheckedChanged
        roomReference = "Deluxe"
    End Sub

    Private Sub rbSuite_CheckedChanged(sender As Object, e As EventArgs) Handles rbSuite.CheckedChanged
        roomReference = "Suite"
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

        If ListView1.SelectedItems.Count > 0 Then
            txtCustomerID.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(0).Text
            txtFirstname.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(1).Text
            txtLastname.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(2).Text
            txtNoOfRooms.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(3).Text
            txtPhone.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(4).Text
            dtCheckIn.Value = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(5).Text
            dtCheckOut.Value = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(6).Text
            roomReference = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(7).Text
            roomRefBind = roomReference

            If roomRefBind = "Standard" Then
                rbStandard.Checked = True
            ElseIf roomRefBind = "Deluxe" Then
                rbDeluxe.Checked = True
            ElseIf roomRefBind = "Suite" Then
                rbSuite.Checked = True
            End If
            txtAddress.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(8).Text
        End If
    End Sub


    Sub loadList()
        Try
            ListView1.Items.Clear()
            openConn()
            ds.Clear()
            cmd.Connection = conn
            cmd.CommandText = "Select * from tblcustomertwo"
            adapter.SelectCommand = cmd
            adapter.Fill(ds, "table")
            For r = 0 To ds.Tables(0).Rows.Count - 1
                For c = 0 To ds.Tables(0).Columns.Count - 1
                    itemColl(c) = ds.Tables(0).Rows(r)(c).ToString
                Next
                Dim listItems As New ListViewItem(itemColl)
                ListView1.Items.Add(listItems)
            Next
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadList
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        If txtFirstname.Text = "" Then
            MessageBox.Show("Please specify the blank inputs", "Hotel And Management")
        Else
            Try
                openConn()
                cmd.Connection = conn
                cmd.CommandText = "update tblcustomertwo set Firstname='" & txtFirstname.Text & "', Lastname ='" & txtLastname.Text & "', NoOfRooms='" & txtNoOfRooms.Text & "', Phone='" & txtPhone.Text & "', CheckinDate='" & dtCheckIn.Text & "', CheckoutDate='" & dtCheckOut.Text & "', Address='" & txtAddress.Text & "' where CustomerID='" & txtCustomerID.Text & "'"
                cmd.ExecuteNonQuery()
                MessageBox.Show("Successfuly Updated", "Hotel And Management")
                conn.Close()
                loadList()
                clearInputs()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Hotel And Management")
            End Try
        End If
    End Sub

    Sub clearInputs()
        txtCustomerID.Clear()
        txtFirstname.Clear()
        txtLastname.Clear()
        txtNoOfRooms.Clear()
        txtPhone.Clear()
        txtAddress.Clear()
        rbStandard.Checked = False
        rbDeluxe.Checked = False
        rbSuite.Checked = False
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        If txtFirstname.Text = "" Then
            MessageBox.Show("Please specify the blank inputs", "Hotel And Management")
        Else
            Try
                openConn()
                cmd.Connection = conn
                cmd.CommandText = "delete from tblcustomertwo where CustomerID='" & txtCustomerID.Text & "'"
                cmd.ExecuteNonQuery()
                MessageBox.Show("Successfuly Deleted", "Hotel And Management")
                conn.Close()
                loadList()
                clearInputs()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Hotel And Management")
            End Try
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clearInputs()

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        'ListView1.SelectedItems.Clear()

        ' For i = 0 To ListView1.Items.Count - 1
        '   If ListView1.Items(i).SubItems(0).Text = txtSearchBar.Text Then
        '       ListView1.Items(i).Selected = True
        '       ListView1.Focus()
        '    End If
        'Next

        ' Dim searchstring As String = txtSearchBar.Text
        ' ListView1.SelectedIndices.Clear()
        'For Each lvi As ListViewItem In ListView1.Items
        ' For Each lvisub As ListViewItem.ListViewSubItem In lvi.SubItems
        ' If lvisub.Text = searchstring Then
        'ListView1.SelectedIndices.Add(lvi.Index)
        'Exit For
        'End If
        'Next
        'Next
        'ListView1.Focus()
        If Not String.IsNullOrWhiteSpace(txtSearchBar.Text) Then
            SrchParameter = txtSearchBar.Text
            NxtStrtRow = 0
            SearchListView()
        End If
    End Sub
    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView1.KeyDown
        If e.KeyCode = Keys.F3 Then
            SearchListView()
        End If
    End Sub

    Private Sub SearchListView()
        ' selects the row containing data matching the text parameter
        ' sets NxtStrtRow (a form level variable) value for a "find next match" scenario (press F3 key)
        If ListView1.Items.Count > 0 Then
            If SrchParameter <> "" Then
                Dim thisRow As Integer = -1
                For x As Integer = NxtStrtRow To ListView1.Items.Count - 1          ' each row
                    For y As Integer = 0 To ListView1.Columns.Count - 1             ' each column  
                        If InStr(1, ListView1.Items(x).SubItems(y).Text.ToLower, SrchParameter.ToLower) > 0 Then
                            thisRow = x
                            NxtStrtRow = x + 1
                            Exit For
                        End If
                    Next
                    If thisRow > -1 Then Exit For
                Next
                If thisRow = -1 Then
                    MsgBox("Not found.")
                    NxtStrtRow = 0
                    txtSearchBar.SelectAll()
                    txtSearchBar.Select()
                Else
                    ' select the row, ensure its visible and set focus into the listview
                    ListView1.Items(thisRow).Selected = True
                    ListView1.Items(thisRow).EnsureVisible()
                    ListView1.Select()
                End If
            End If
        End If
    End Sub
End Class
