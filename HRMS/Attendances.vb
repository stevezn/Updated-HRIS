Imports System.IO
Imports DevExpress.Utils.Menu
Imports DevExpress.XtraGrid.Views.Grid

Public Class Attendances
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


    Sub loadhari()
        Dim sqlcommand As New MySqlCommand
        sqlcommand.CommandText = "select a.EmployeeCode, a.FullName, a.Tanggal, a.Shift, Date_Format(a.JamMulai, '%H:%i:%s') as SignIn, DATE_FORMAT(a.JamSelesai, '%H:%i:%s') as SignOut, b.EmployeeType from db_absensi a, db_pegawai b where a.tanggal between @date1 and @date2 and a.EmployeeCode = b.EmployeeCode and b.EmployeeType = 'Harian'"
        Dim p1, p2 As New MySqlParameter
        p1.ParameterName = "@date1"
        p2.ParameterName = "@date2"
        p1.Value = date1.Value.Date
        p2.Value = date2.Value
        sqlcommand.Parameters.Add(p1)
        sqlcommand.Parameters.Add(p2)
        sqlcommand.Connection = SQLConnection
        Dim dt As New DataTable
        dt.Load(sqlcommand.ExecuteReader)
        GridControl1.DataSource = dt
    End Sub

    Sub loadbulan()
        Dim sqlcommand As New MySqlCommand
        sqlcommand.CommandText = "select a.EmployeeCode, a.FullName, a.Tanggal, a.Shift, Date_Format(a.JamMulai, '%H:%i:%s') as SignIn, DATE_FORMAT(a.JamSelesai, '%H:%i:%s') as SignOut, b.EmployeeType from db_absensi a, db_pegawai b where a.tanggal between @date1 and @date2 and a.EmployeeCode = b.EmployeeCode and b.EmployeeType = 'Bulanan'"
        Dim p1, p2 As New MySqlParameter
        p1.ParameterName = "@date1"
        p2.ParameterName = "@date2"
        p1.Value = date1.Value.Date
        p2.Value = date2.Value
        sqlcommand.Parameters.Add(p1)
        sqlcommand.Parameters.Add(p2)
        sqlcommand.Connection = SQLConnection
        Dim dt As New DataTable
        dt.Load(sqlcommand.ExecuteReader)
        GridControl1.DataSource = dt
    End Sub

    Private Sub loadborongan()
        Dim sqlcommand As New MySqlCommand
        sqlcommand.CommandText = "select a.EmployeeCode, a.FullName, a.Tanggal, a.Shift, Date_Format(a.JamMulai, '%H:%i:%s') as SignIn, DATE_FORMAT(a.JamSelesai, '%H:%i:%s') as SignOut, b.EmployeeType from db_absensi a, db_pegawai b where a.tanggal between @date1 and @date2 and a.EmployeeCode = b.EmployeeCode and b.EmployeeType = 'Borongan'"
        Dim p1, p2 As New MySqlParameter
        p1.ParameterName = "@date1"
        p2.ParameterName = "@date2"
        p1.Value = date1.Value.Date
        p2.Value = date2.Value
        sqlcommand.Parameters.Add(p1)
        sqlcommand.Parameters.Add(p2)
        sqlcommand.Connection = SQLConnection
        Dim dt As New DataTable
        dt.Load(sqlcommand.ExecuteReader)
        GridControl1.DataSource = dt
    End Sub

    Private Sub loadall()
        Dim sqlcommand As New MySqlCommand
        sqlcommand.CommandText = "select a.EmployeeCode, a.FullName, a.Tanggal, a.Shift, Date_Format(a.JamMulai, '%H:%i:%s') as SignIn, DATE_FORMAT(a.JamSelesai, '%H:%i:%s') as SignOut, b.EmployeeType from db_absensi a, db_pegawai b where a.EmployeeCode = b.EmployeeCode and a.tanggal between @date1 and @date2"
        Dim p1, p2 As New MySqlParameter
        p1.ParameterName = "@date1"
        p2.ParameterName = "@date2"
        p1.Value = date1.Value.Date
        p2.Value = date2.Value
        sqlcommand.Parameters.Add(p1)
        sqlcommand.Parameters.Add(p2)
        sqlcommand.Connection = SQLConnection
        Dim dt As New DataTable
        dt.Load(sqlcommand.ExecuteReader)
        GridControl1.DataSource = dt
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        If checkall.Checked = True Then
            loadall()
        ElseIf checkharian.Checked = True Then
            loadhari()
        ElseIf checkbulanan.Checked = True Then
            loadbulan()
        ElseIf checkborongan.Checked = True Then
            loadborongan()
        Else
            MsgBox("Please choose the filters")
        End If
    End Sub

    Private Sub resultpages()
        Dim sqlcommand As New MySqlCommand
        Dim lastn As Integer
        Try
            Dim cmd = SQLConnection.CreateCommand()
            cmd.CommandText = "SELECT count(*) FROM db_borongan where EmployeeCode = @ec and Tanggal = curdate()"
            cmd.Parameters.AddWithValue("@ec", Label5.Text)
            lastn = DirectCast(cmd.ExecuteScalar, Integer)
            MsgBox(lastn)
        Catch ex As Exception
        End Try
        If lastn = 0 Then
            sqlcommand.CommandText = "INSERT INTO db_borongan " +
                          "(FullName, EmployeeCode, Tanggal, Result) " +
                          "values (@FullName, @EmployeeCode, @Tanggal, @Result)"
            sqlcommand.Connection = SQLConnection
            sqlcommand.Parameters.AddWithValue("@FullName", lblname.Text)
            sqlcommand.Parameters.AddWithValue("@Tanggal", Date.Now)
            sqlcommand.Parameters.AddWithValue("@EmployeeCode", Label5.Text)
            sqlcommand.Parameters.AddWithValue("@Result", txtpages.Text)
            sqlcommand.ExecuteNonQuery()
            MsgBox("Added")
        Else
            MsgBox("This employee has already input the result for today")
        End If
    End Sub

    Private Sub overtimeresult()
        Dim dtb As DateTime
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy-MM-dd"
        dtb = DateTimePicker1.Value
        Dim sqlcommand As New MySqlCommand
        Try
            sqlcommand.CommandText = "insert into db_overtime " +
                                    "(FullName, EmployeeCode, Tanggal, Hours) " +
                                    "values (@FullName, @EmployeeCode, @Tanggal, @Hours)"
            sqlcommand.Connection = SQLConnection
            sqlcommand.Parameters.AddWithValue("@FullName", Label9.Text)
            sqlcommand.Parameters.AddWithValue("@EmployeeCode", Label10.Text)
            sqlcommand.Parameters.AddWithValue("@Tanggal", dtb.ToString("yyyy-MM-dd"))
            sqlcommand.Parameters.AddWithValue("@Hours", txtsav.Text)
            sqlcommand.ExecuteNonQuery()
            MsgBox("Added")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub loadDataReq1()
        GridControl2.RefreshDataSource()
        Dim table As New DataTable
        Dim sqlCommand As New MySqlCommand
        Try
            sqlCommand.CommandText = "select a.EmployeeCode, a.FullName, a.Tanggal, a.Shift, b.EmployeeType from db_absensi a, db_pegawai b where a.EmployeeCode = b.EmployeeCode and b.EmployeeType = 'Borongan' and a.tanggal = curdate()"
            sqlCommand.Connection = SQLConnection
            Dim tbl_par As New DataTable
            Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(table)
            GridControl2.DataSource = table
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub loadovertime()
        GridControl3.RefreshDataSource()
        Dim table As New DataTable
        Dim sqlcommand As New MySqlCommand
        Try
            sqlcommand.CommandText = "select a.EmployeeCode, a.CompanyCode, a.FullName, a.EmployeeType, a.Status from db_pegawai a, db_payrolldata b where a.EmployeeCode = b.EmployeeCode"
            sqlcommand.Connection = SQLConnection
            Dim tbl_par As New DataTable
            Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(table)
            GridControl3.DataSource = table
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        loadDataReq1()
        Result.Visible = True
        overtime.Visible = False
    End Sub

    Private Sub Attendances_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        Result.Visible = False
        overtime.Visible = False
    End Sub

    Private Sub Attendances_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        Result.Visible = False
        overtime.Visible = False
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click
        Result.Visible = False
        overtime.Visible = False
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs)
        loadovertime()
        overtime.Visible = True
        Result.Visible = False
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtpages.Text = "" Or lblname.Text = "-" Or Label5.Text = "//" Then
            MsgBox("The input is wrong")
        Else
            resultpages()
        End If
    End Sub

    Private Sub GridView1_Click(sender As Object, e As EventArgs) Handles GridView1.Click
        Result.Visible = False
        overtime.Visible = False
    End Sub

    Private Sub GridView2_FocusedRowChanged_1(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView2.FocusedRowChanged
        Dim datatabl As New DataTable
        Dim sqlCommand As New MySqlCommand
        datatabl.Clear()
        Dim param As String = ""
        Try
            param = "and EmployeeCode='" + GridView2.GetFocusedRowCellValue("EmployeeCode").ToString() + "'"
        Catch ex As Exception
        End Try
        Try
            sqlCommand.CommandText = "SELECT EmployeeCode, FullName, shift, Tanggal,  Date_Format(a.JamMulai, '%H:%i:%s') as SignIn, DATE_FORMAT(a.JamSelesai, '%H:%i:%s') as SignOut from db_absensi WHERE 1=1 " + param.ToString()
            sqlCommand.Connection = SQLConnection

            Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(datatabl)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If datatabl.Rows.Count > 0 Then
            lblname.Text = datatabl.Rows(0).Item(1).ToString()
            Label5.Text = datatabl.Rows(0).Item(0).ToString
        End If
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        If txtsav.Text = "" Or DateTimePicker1.Value = Now.Date Then
            MsgBox("Please fill hours textbox")
        Else
            overtimeresult()
        End If
    End Sub

    Private Sub GridView3_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView3.FocusedRowChanged
        Dim datatabl As New DataTable
        Dim sqlCommand As New MySqlCommand
        datatabl.Clear()
        Dim param As String = ""
        Try
            param = "and EmployeeCode='" + GridView3.GetFocusedRowCellValue("EmployeeCode").ToString() + "'"
        Catch ex As Exception
        End Try
        Try
            sqlCommand.CommandText = "SELECT EmployeeCode, FullName, EmployeeType from db_pegawai WHERE 1=1 " + param.ToString()
            sqlCommand.Connection = SQLConnection

            Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(datatabl)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If datatabl.Rows.Count > 0 Then
            Label9.Text = datatabl.Rows(0).Item(1).ToString()
            Label10.Text = datatabl.Rows(0).Item(0).ToString
        End If
    End Sub

    Private Sub GridView1_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GridView1.PopupMenuShowing
        Dim view As GridView = CType(sender, GridView)
        If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Row Then
            Dim rowHandle As Integer = e.HitInfo.RowHandle
            e.Menu.Items.Clear()
            Dim item As DXMenuItem = CreateMergingEnabledMenuItem(view, rowHandle)
            item.BeginGroup = True
            e.Menu.Items.Add(item)
        End If
    End Sub

    Dim att As New Attendance

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs)
        If att Is Nothing OrElse att.IsDisposed OrElse att.MinimizeBox Then
            att.Close()
            att = New Attendance
        End If
        att.Show()
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        If att Is Nothing OrElse att.IsDisposed OrElse att.MinimizeBox Then
            att.Close()
            att = New Attendance
        End If
        att.Show()
    End Sub

    Dim addmen As New addmenu

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        If addmen Is Nothing OrElse addmen.IsDisposed OrElse addmen.MinimizeBox Then
            addmen.Close()
            addmen = New addmenu
        End If
        addmenu.Show()
        addmen.Overtime.Show()
        'loadovertime()
        'overtime.Visible = True
        'Result.Visible = False
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        If addmen Is Nothing OrElse addmen.IsDisposed OrElse addmen.MinimizeBox Then
            addmen.Close()
            addmen = New addmenu
        End If
        addmenu.Show()
        addmen.Borongan.Show()
        'loadDataReq1()
        'Result.Visible = True
        'overtime.Visible = False
    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GroupControl1.Visible = True
    End Sub

    Private Sub SimpleButton2_Click_1(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GroupControl1.Visible = False
    End Sub

    Private Sub SimpleButton4_Click_1(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        GroupControl1.Visible = False
    End Sub

    Private Sub loadabsensi()
        Dim sqlcommand As New MySqlCommand
        sqlcommand.CommandText = "select a.EmployeeCode, a.FullName, a.Tanggal, a.Shift, Date_Format(a.JamMulai, '%H:%i:%s') as SignIn, DATE_FORMAT(a.JamSelesai, '%H:%i:%s') as SignOut, b.EmployeeType from db_absensi a, db_pegawai b where a.EmployeeCode = b.EmployeeCode and a.tanggal = @date1"
        Dim p1 As New MySqlParameter
        p1.ParameterName = "@date1"
        p1.Value = DateTimePicker2.Value.Date
        sqlcommand.Parameters.Add(p1)
        sqlcommand.Connection = SQLConnection
        Dim dt As New DataTable
        dt.Load(sqlcommand.ExecuteReader)
        GridControl1.DataSource = dt
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        loadabsensi()
        GroupControl1.Visible = False
    End Sub

    Private Sub DateTimePicker2_KeyDown(sender As Object, e As KeyEventArgs) Handles DateTimePicker2.KeyDown
        If e.KeyCode = Keys.Enter Then
            loadabsensi()
            GroupControl1.Visible = False
        End If
    End Sub
End Class