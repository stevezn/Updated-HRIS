Imports System.IO
Imports DevExpress.Utils.Menu
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.EasyTest.Framework

Public Class Reports

    Dim connectionString As String
    Dim SQLConnection As MySqlConnection = New MySqlConnection
    Dim oDt_sched As New DataTable()
    Dim tbl_par As New DataTable

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call.
        Dim host As String
        Dim id As String
        Dim password As String
        Dim db As String
        If File.Exists("settinghost.txt") Then
            host = File.ReadAllText("settinghost.txt")
        Else
            host = "localhost"
        End If
        If File.Exists("settingid.txt") Then
            id = File.ReadAllText("settingid.txt")
        Else
            id = "root"
        End If
        If File.Exists("settingpass.txt") Then
            password = File.ReadAllText("settingpass.txt")
        Else
            password = ""
        End If

        If File.Exists("settingdb.txt") Then
            db = File.ReadAllText("settingdb.txt")
        Else
            db = "db_hris"
        End If
        connectionString = "Server=" + host + "; User Id=" + id + "; Password=" + password + "; Database=" + db + ""
    End Sub

    Sub ShowGridPreview(ByVal grid As GridControl)
        If Not grid.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' library is not found", "Error")
            Return
        End If
        grid.ShowPrintPreview()
    End Sub

    Sub PrintGrid(ByVal grid As GridControl)
        If Not grid.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' library is not found", "Error")
            Return
        End If
        grid.Print()
    End Sub

    Private Sub GridView1_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs)
        Dim view As GridView = CType(sender, GridView)
        If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Row Then
            Dim rowHandle As Integer = e.HitInfo.RowHandle
            e.Menu.Items.Clear()
            Dim item As DXMenuItem = CreateMergingEnabledMenuItem(view, rowHandle)
            item.BeginGroup = True
            e.Menu.Items.Add(item)
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        ShowGridPreview(GridControl1)
    End Sub

    Dim crit As New Criteria

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        If crit Is Nothing OrElse crit.IsDisposed OrElse crit.MinimizeBox Then
            crit.Close()
            crit = New Criteria
        End If
        crit.Show()
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "truncate db_tmpname"
        query.ExecuteNonQuery()

        query.CommandText = "insert into db_tmpname (status) values (@status)"
        query.Parameters.AddWithValue("@status", "Candidates List")
        query.ExecuteNonQuery()

        If crit Is Nothing OrElse crit.IsDisposed OrElse crit.MinimizeBox Then
            crit.Close()
            crit = New Criteria
        End If
        crit.Show()
        Close()
    End Sub

    Private Sub Reports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        Dim gridView As GridView = CType(GridControl1.FocusedView, GridView)
        gridView.SortInfo.ClearAndAddRange(New GridColumnSortInfo() {
   New GridColumnSortInfo(gridView.Columns("EmployeeCode"), DevExpress.Data.ColumnSortOrder.Ascending),
   New GridColumnSortInfo(gridView.Columns("IdRec"), DevExpress.Data.ColumnSortOrder.Ascending),
   New GridColumnSortInfo(gridView.Columns("WarningLevel"), DevExpress.Data.ColumnSortOrder.Ascending)}, 2)
        GridView1.BestFitColumns()
        Try
            Dim query As MySqlCommand = SQLConnection.CreateCommand
            query.CommandText = "select status from db_tmpname"
            Dim quer As String = CStr(query.ExecuteScalar)
            LabelControl2.Text = quer.ToString
        Catch ex As Exception
        End Try
        'GridColumn.SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Count, "{0:n0} rows")
    End Sub

    Private Sub SimpleButton18_Click(sender As Object, e As EventArgs) Handles SimpleButton18.Click
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "truncate db_tmpname"
        query.ExecuteNonQuery()

        query.CommandText = "insert into db_tmpname (status) values (@status)"
        query.Parameters.AddWithValue("@status", "Employee List")
        query.ExecuteNonQuery()

        If crit Is Nothing OrElse crit.IsDisposed OrElse crit.MinimizeBox Then
            crit.Close()
            crit = New Criteria
        End If
        crit.Show()
        Close()
    End Sub

    Private Sub SimpleButton19_Click(sender As Object, e As EventArgs) Handles SimpleButton19.Click
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "truncate db_tmpname"
        query.ExecuteNonQuery()

        query.CommandText = "insert into db_tmpname (status) values (@status)"
        query.Parameters.AddWithValue("@status", "Attendance List")
        query.ExecuteNonQuery()

        If crit Is Nothing OrElse crit.IsDisposed OrElse crit.MinimizeBox Then
            crit.Close()
            crit = New Criteria
        End If
        crit.Show()
        Close()
    End Sub

    Private Sub SimpleButton20_Click(sender As Object, e As EventArgs) Handles SimpleButton20.Click
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "truncate db_tmpname"
        query.ExecuteNonQuery()

        query.CommandText = "insert into db_tmpname (status) values (@status)"
        query.Parameters.AddWithValue("@status", "Overtime List")
        query.ExecuteNonQuery()

        If crit Is Nothing OrElse crit.IsDisposed OrElse crit.MinimizeBox Then
            crit.Close()
            crit = New Criteria
        End If
        crit.Show()
        Close()
    End Sub

    Private Sub SimpleButton21_Click(sender As Object, e As EventArgs) Handles SimpleButton21.Click
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "truncate db_tmpname"
        query.ExecuteNonQuery()

        query.CommandText = "insert into db_tmpname (status) values (@status)"
        query.Parameters.AddWithValue("@status", "Warning Notice")
        query.ExecuteNonQuery()

        If crit Is Nothing OrElse crit.IsDisposed OrElse crit.MinimizeBox Then
            crit.Close()
            crit = New Criteria
        End If
        crit.Show()
        Close()
    End Sub

    Private Sub SimpleButton23_Click(sender As Object, e As EventArgs) Handles SimpleButton23.Click
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "truncate db_tmpname"
        query.ExecuteNonQuery()

        query.CommandText = "insert into db_tmpname (status) values (@status)"
        query.Parameters.AddWithValue("@status", "Leave Request")
        query.ExecuteNonQuery()

        If crit Is Nothing OrElse crit.IsDisposed OrElse crit.MinimizeBox Then
            crit.Close()
            crit = New Criteria
        End If
        crit.Show()
        Close()
    End Sub

    Private Sub SimpleButton22_Click(sender As Object, e As EventArgs) Handles SimpleButton22.Click
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "truncate db_tmpname"
        query.ExecuteNonQuery()

        query.CommandText = "insert into db_tmpname (status) values (@status)"
        query.Parameters.AddWithValue("@status", "Others Income / Deductions")
        query.ExecuteNonQuery()

        If crit Is Nothing OrElse crit.IsDisposed OrElse crit.MinimizeBox Then
            crit.Close()
            crit = New Criteria
        End If
        crit.Show()
        Close()
    End Sub

    Private Sub SimpleButton24_Click(sender As Object, e As EventArgs) Handles SimpleButton24.Click
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "truncate db_tmpname"
        query.ExecuteNonQuery()

        query.CommandText = "insert into db_tmpname (status) values (@status)"
        query.Parameters.AddWithValue("@status", "Loan Lists")
        query.ExecuteNonQuery()

        If crit Is Nothing OrElse crit.IsDisposed OrElse crit.MinimizeBox Then
            crit.Close()
            crit = New Criteria
        End If
        crit.Show()
        Close()
    End Sub

    Private Sub SimpleButton25_Click(sender As Object, e As EventArgs) Handles SimpleButton25.Click
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "truncate db_tmpname"
        query.ExecuteNonQuery()

        query.CommandText = "insert into db_tmpname (status) values (@status)"
        query.Parameters.AddWithValue("@status", "Loan Summary")
        query.ExecuteNonQuery()

        If crit Is Nothing OrElse crit.IsDisposed OrElse crit.MinimizeBox Then
            crit.Close()
            crit = New Criteria
        End If
        crit.Show()
        Close()
    End Sub

    Private Sub SimpleButton26_Click(sender As Object, e As EventArgs) Handles SimpleButton26.Click
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "truncate db_tmpname"
        query.ExecuteNonQuery()

        query.CommandText = "insert into db_tmpname (status) values (@status)"
        query.Parameters.AddWithValue("@status", "Payroll Sheet")
        query.ExecuteNonQuery()

        If crit Is Nothing OrElse crit.IsDisposed OrElse crit.MinimizeBox Then
            crit.Close()
            crit = New Criteria
        End If
        crit.Show()
        Close()
    End Sub

    Private Sub SimpleButton27_Click(sender As Object, e As EventArgs) Handles SimpleButton27.Click
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "truncate db_tmpname"
        query.ExecuteNonQuery()

        query.CommandText = "insert into db_tmpname (status) values (@status)"
        query.Parameters.AddWithValue("@status", "Premi")
        query.ExecuteNonQuery()

        If crit Is Nothing OrElse crit.IsDisposed OrElse crit.MinimizeBox Then
            crit.Close()
            crit = New Criteria
        End If
        crit.Show()
        Close()
    End Sub

    Private Sub SimpleButton28_Click(sender As Object, e As EventArgs) Handles SimpleButton28.Click
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "truncate db_tmpname"
        query.ExecuteNonQuery()

        query.CommandText = "insert into db_tmpname (status) values (@status)"
        query.Parameters.AddWithValue("@status", "Lates Or Early Sign In/Out")
        query.ExecuteNonQuery()

        If crit Is Nothing OrElse crit.IsDisposed OrElse crit.MinimizeBox Then
            crit.Close()
            crit = New Criteria
        End If
        crit.Show()
        Close()
    End Sub

    Private Sub SimpleButton29_Click(sender As Object, e As EventArgs) Handles SimpleButton29.Click
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "truncate db_tmpname"
        query.ExecuteNonQuery()

        query.CommandText = "insert into db_tmpname (status) values (@status)"
        query.Parameters.AddWithValue("@status", "Absences List")
        query.ExecuteNonQuery()

        If crit Is Nothing OrElse crit.IsDisposed OrElse crit.MinimizeBox Then
            crit.Close()
            crit = New Criteria
        End If
        crit.Show()
        Close()
    End Sub

    Private Sub SimpleButton30_Click(sender As Object, e As EventArgs) Handles SimpleButton30.Click
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "truncate db_tmpname"
        query.ExecuteNonQuery()

        query.CommandText = "insert into db_tmpname (status) values (@status)"
        query.Parameters.AddWithValue("@status", "Terminate Lists")
        query.ExecuteNonQuery()

        If crit Is Nothing OrElse crit.IsDisposed OrElse crit.MinimizeBox Then
            crit.Close()
            crit = New Criteria
        End If
        crit.Show()
        Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Close()
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "truncate db_tmpname"
        query.ExecuteNonQuery()

        query.CommandText = "insert into db_tmpname (status) values (@status)"
        query.Parameters.AddWithValue("@status", "Pajak")
        query.ExecuteNonQuery()

        If crit Is Nothing OrElse crit.IsDisposed OrElse crit.MinimizeBox Then
            crit.Close()
            crit = New Criteria
        End If
        crit.Show()
        Close()
    End Sub

    Private Sub Reports_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        'Tile_Control.Close()
        'Tile_Control.Show()
    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "truncate db_tmpname"
        query.ExecuteNonQuery()

        query.CommandText = "insert into db_tmpname (status) values(@status)"
        query.Parameters.AddWithValue("@status", "Status Change")
        query.ExecuteNonQuery()

        If crit Is Nothing OrElse crit.IsDisposed OrElse crit.MinimizeBox Then
            crit.Close()
            crit = New Criteria
        End If
        crit.Show()
        Close()
    End Sub
End Class