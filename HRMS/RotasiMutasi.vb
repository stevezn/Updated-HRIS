Imports System.IO
Imports DevExpress.Utils.Menu
Imports DevExpress.XtraGrid.Views.Grid

Public Class RotasiMutasi
    Dim connectionString As String
    Dim SQLConnection As MySqlConnection = New MySqlConnection
    Dim oDt_sched As New DataTable()

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
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

    Private Sub reset()
        txtnamakaryawan.Text = ""
        txtEmpCode.Text = ""
        txtCompcode.Text = ""
        txtPosition.Text = ""
        txtChange.Text = ""
        txtDate.Text = ""
    End Sub

    Public Function saverotasi() As Boolean
        Dim sqlCommand As New MySqlCommand
        Dim str_carSql As String
        Try
            If act = "edit" Then
                str_carSql = "UPDATE db_rotasi SET" +
                       " CompanyCode = @CompanyCode" +
                       ", FullName = @FullName" +
                       ", Position = @Position" +
                       ", Rotasi = @Rotasi" +
                       ", RotasiDate = @RotasiDate" +
                       " WHERE EmployeeCode = @EmployeeCode"
                sqlCommand.Connection = SQLConnection
                sqlCommand.CommandText = str_carSql
                sqlCommand.Parameters.AddWithValue("@EmployeeCode", txtEmpCode.Text)
                sqlCommand.Parameters.AddWithValue("@CompanyCode", txtCompcode.Text)
                sqlCommand.Parameters.AddWithValue("@FullName", txtnamakaryawan.Text)
                sqlCommand.Parameters.AddWithValue("@Position", txtPosition.Text)
                sqlCommand.Parameters.AddWithValue("@Rotasi", txtChange.Text)
                sqlCommand.Parameters.AddWithValue("@RotasiDate", txtDate.Text)
            ElseIf act = "input" Then
                str_carSql = "INSERT INTO db_rotasi " +
                       "(EmployeeCode, CompanyCode, FullName, Position, Rotasi, RotasiDate) " +
                       "values (@EmployeeCode,@CompanyCode,@FullName,@Position,@Rotasi,@RotasiDate)"
                sqlCommand.Connection = SQLConnection
                sqlCommand.CommandText = str_carSql
                sqlCommand.Parameters.AddWithValue("@EmployeeCode", txtEmpCode.Text)
                sqlCommand.Parameters.AddWithValue("@CompanyCode", txtCompcode.Text)
                sqlCommand.Parameters.AddWithValue("@FullName", txtnamakaryawan.Text)
                sqlCommand.Parameters.AddWithValue("@Position", txtPosition.Text)
                sqlCommand.Parameters.AddWithValue("@Rotasi", txtChange.Text)
                sqlCommand.Parameters.AddWithValue("@RotasiDate", txtDate.Text)
            End If
            sqlCommand.ExecuteNonQuery()
            If act = "input" Then
                MessageBox.Show("Data Succesfully Added!")
            ElseIf act = "edit" Then
                MessageBox.Show("Data Succesfully Changed!")
            End If
            Return True
        Catch ex As Exception
            Return False
            MsgBox("Error Occured: Could Not Insert Records")
        End Try
    End Function

    Public Function savedemosi() As Boolean
        Dim sqlCommand As New MySqlCommand
        Dim str_carSql As String
        Try
            If act = "edit" Then
                str_carSql = "UPDATE db_demosi SET" +
                       " CompanyCode = @CompanyCode" +
                       ", FullName = @FullName" +
                       ", Position = @Position" +
                       ", Demosi = @Demosi" +
                       ", DemosiDate = @DemosiDate" +
                       " WHERE EmployeeCode = @EmployeeCode"
                sqlCommand.Connection = SQLConnection
                sqlCommand.CommandText = str_carSql
                sqlCommand.Parameters.AddWithValue("@EmployeeCode", txtEmpCode.Text)
                sqlCommand.Parameters.AddWithValue("@CompanyCode", txtCompcode.Text)
                sqlCommand.Parameters.AddWithValue("@FullName", txtnamakaryawan.Text)
                sqlCommand.Parameters.AddWithValue("@Position", txtPosition.Text)
                sqlCommand.Parameters.AddWithValue("@Demosi", txtChange.Text)
                sqlCommand.Parameters.AddWithValue("@DemosiDate", txtDate.Text)
            ElseIf act = "input" Then
                str_carSql = "INSERT INTO db_Demosi " +
                       "(EmployeeCode, CompanyCode, FullName, Position, Demosi, DemosiDate) " +
                       "values (@EmployeeCode,@CompanyCode,@FullName,@Position,@Demosi,@DemosiDate)"
                sqlCommand.Connection = SQLConnection
                sqlCommand.CommandText = str_carSql
                sqlCommand.Parameters.AddWithValue("@EmployeeCode", txtEmpCode.Text)
                sqlCommand.Parameters.AddWithValue("@CompanyCode", txtCompcode.Text)
                sqlCommand.Parameters.AddWithValue("@FullName", txtnamakaryawan.Text)
                sqlCommand.Parameters.AddWithValue("@Position", txtPosition.Text)
                sqlCommand.Parameters.AddWithValue("@Demosi", txtChange.Text)
                sqlCommand.Parameters.AddWithValue("@DemosiDate", txtDate.Text)
            End If
            sqlCommand.ExecuteNonQuery()
            If act = "input" Then
                MessageBox.Show("Data Succesfully Added!")
            ElseIf act = "edit" Then
                MessageBox.Show("Data Succesfully Changed!")
            End If
            Return True
        Catch ex As Exception
            Return False
            MsgBox("Error occured: Could Not Insert Records")
        End Try
    End Function

    Public Sub historydemosi()
        Dim sqlCommand As New MySqlCommand
        Try
            sqlCommand.CommandText = "INSERT INTO db_demotehistory " +
                   "(EmployeeCode, CompanyCode, FullName, Position, Demosi, DemosiDate) " +
                   "values (@EmployeeCode,@CompanyCode,@FullName,@Position,@Demosi,@DemosiDate)"
            sqlCommand.Connection = SQLConnection
            sqlCommand.Parameters.AddWithValue("@EmployeeCode", txtEmpCode.Text)
            sqlCommand.Parameters.AddWithValue("@CompanyCode", txtCompcode.Text)
            sqlCommand.Parameters.AddWithValue("@FullName", txtnamakaryawan.Text)
            sqlCommand.Parameters.AddWithValue("@Position", txtPosition.Text)
            sqlCommand.Parameters.AddWithValue("@Demosi", txtChange.Text)
            sqlCommand.Parameters.AddWithValue("@DemosiDate", txtDate.Text)
            sqlCommand.Connection = SQLConnection
            sqlCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub updatepos()
        Dim sqlcommand As New MySqlCommand
        Try
            sqlcommand.CommandText = "UPDATE db_pegawai SET" +
                                    " Position = @Position" +
                                    " WHERE EmployeeCode = @EmployeeCode"
            sqlcommand.Connection = SQLConnection
            sqlcommand.Parameters.AddWithValue("@EmployeeCode", txtEmpCode.Text)
            sqlcommand.Parameters.AddWithValue("@Position", txtChange.Text)
            sqlcommand.Connection = SQLConnection
            sqlcommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub historyrotasi()
        Dim sqlCommand As New MySqlCommand
        Try
            sqlCommand.CommandText = "INSERT INTO db_rotasihistory " +
                   "(EmployeeCode, CompanyCode, FullName, Position, Rotasi, RotasiDate) " +
                   "values (@EmployeeCode,@CompanyCode,@FullName,@Position,@Rotasi,@RotasiDate)"
            sqlCommand.Connection = SQLConnection
            sqlCommand.Parameters.AddWithValue("@EmployeeCode", txtEmpCode.Text)
            sqlCommand.Parameters.AddWithValue("@CompanyCode", txtCompcode.Text)
            sqlCommand.Parameters.AddWithValue("@FullName", txtnamakaryawan.Text)
            sqlCommand.Parameters.AddWithValue("@Position", txtPosition.Text)
            sqlCommand.Parameters.AddWithValue("@Rotasi", txtChange.Text)
            sqlCommand.Parameters.AddWithValue("@RotasiDate", txtDate.Text)
            sqlCommand.Connection = SQLConnection
            sqlCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub clear()
        lccurpos.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcempcode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcfullnames.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcompcode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcRotasi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lctime.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcbutton.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
    End Sub

    Dim tbl_par As New DataTable

    Sub loadDataKaryawan()
        Dim sqlCommand As New MySqlCommand
        sqlCommand.CommandText = "SELECT EmployeeCode, FullName, Position, CompanyCode FROM db_pegawai WHERE Status!='Fired'"
        sqlCommand.Connection = SQLConnection
        Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
        Dim cb As New MySqlCommandBuilder(adapter)
        adapter.Fill(tbl_par)
        For index As Integer = 0 To tbl_par.Rows.Count - 1
            txtnamakaryawan.Properties.Items.Add(tbl_par.Rows(index).Item(1).ToString())
        Next
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        reset()
        barJudul.Caption = "Rotasi"
        GroupControl1.Text = "Rotasi"
        GridControl1.RefreshDataSource()
        GridView1.Columns.Clear()
        lccurpos.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcempcode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcfullnames.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcompcode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcRotasi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcRotasi.Text = "Promote To"
        lcbutton.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        loadDataKaryawan()
        loadData()
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        reset()
        barJudul.Caption = "Demosi"
        GroupControl1.Text = "Demosi"
        GridControl1.RefreshDataSource()
        GridView1.Columns.Clear()
        lccurpos.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcempcode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcfullnames.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcompcode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcRotasi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcRotasi.Text = "Demote To"
        lcbutton.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        loadDataKaryawan()
        loadData()
    End Sub

    Private Sub loadData()
        GridControl1.RefreshDataSource()
        Dim table As New DataTable
        Dim sqlCommand As New MySqlCommand
        Try
            If barJudul.Caption = "Rotasi" Then
                sqlCommand.CommandText = "SELECT EmployeeCode, CompanyCode, FullName, Position, Rotasi, RotasiDate FROM db_rotasi"
            ElseIf barJudul.Caption = "Demosi" Then
                sqlCommand.CommandText = "SELECT EmployeeCode, CompanyCode, FullName, Position, Demosi, DemosiDate FROM db_demosi"
            End If
            sqlCommand.Connection = SQLConnection
            Dim tbl_par As New DataTable
            Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(table)
            GridControl1.DataSource = table
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub RotasiMutasi_Load(sender As Object, e As EventArgs)
    End Sub

    Private Sub RotasiMutasi_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        act = "input"
        BarButtonItem1.PerformClick()
        reset()
    End Sub

    Private Sub txtnamakaryawan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtnamakaryawan.SelectedIndexChanged
        For indexing As Integer = 0 To tbl_par.Rows.Count - 1
            If txtnamakaryawan.SelectedItem Is tbl_par.Rows(indexing).Item(1).ToString() Then
                txtEmpCode.Text = tbl_par.Rows(indexing).Item(0).ToString()
                txtPosition.Text = tbl_par.Rows(indexing).Item(2).ToString()
                txtCompcode.Text = tbl_par.Rows(indexing).Item(3).ToString()
            End If
        Next
    End Sub

    Dim act As String = ""

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        Dim datatabl As New DataTable
        Dim sqlCommand As New MySqlCommand
        datatabl.Clear()
        If barJudul.Caption = "Rotasi" Then
            Dim param As String = ""
            Try
                param = "and EmployeeCode='" + GridView1.GetFocusedRowCellValue("EmployeeCode").ToString() + "'"
            Catch ex As Exception
            End Try
            If param > "" Then
                act = "edit"
            Else
                act = "input"
            End If
            Try
                sqlCommand.CommandText = "SELECT * FROM db_rotasi WHERE 1 = 1 " + param.ToString()
                sqlCommand.Connection = SQLConnection
                Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
                Dim cb As New MySqlCommandBuilder(adapter)
                adapter.Fill(datatabl)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
            If datatabl.Rows.Count > 0 Then
                txtEmpCode.Text = datatabl.Rows(0).Item(0).ToString()
                txtCompcode.Text = datatabl.Rows(0).Item(1).ToString()
                txtnamakaryawan.Text = datatabl.Rows(0).Item(2).ToString()
                txtPosition.Text = datatabl.Rows(0).Item(3).ToString()
                txtChange.Text = datatabl.Rows(0).Item(4).ToString()
                txtDate.Text = datatabl.Rows(0).Item(5).ToString()
            End If
        ElseIf barJudul.Caption = "Demosi" Then
            Dim param As String = ""
            Try
                param = "and EmployeeCode='" + GridView1.GetFocusedRowCellValue("EmployeeCode").ToString() + "'"
            Catch ex As Exception
            End Try
            If param > "" Then
                act = "edit"
            Else
                act = "input"
            End If
            Try
                sqlCommand.CommandText = "SELECT * FROM db_demosi WHERE 1 = 1 " + param.ToString()
                sqlCommand.Connection = SQLConnection
                Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
                Dim cb As New MySqlCommandBuilder(adapter)
                adapter.Fill(datatabl)
                SQLConnection.Close()
            Catch ex As Exception
                SQLConnection.Close()
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
            If datatabl.Rows.Count > 0 Then
                txtEmpCode.Text = datatabl.Rows(0).Item(0).ToString()
                txtCompcode.Text = datatabl.Rows(0).Item(1).ToString()
                txtnamakaryawan.Text = datatabl.Rows(0).Item(2).ToString()
                txtPosition.Text = datatabl.Rows(0).Item(3).ToString()
                txtChange.Text = datatabl.Rows(0).Item(4).ToString()
                txtDate.Text = datatabl.Rows(0).Item(5).ToString()
            End If
        End If
    End Sub

    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        If barJudul.Caption = "Rotasi" Then
            If txtEmpCode.Text = "" Then
                MsgBox("Please Insert Employee Code")
            Else
                saverotasi()
                historyrotasi()
                updatepos()
            End If
        ElseIf barJudul.Caption = "Demosi" Then
            If txtEmpCode.Text = "" Then
                MsgBox("Please Insert Employee Code")
            Else
                savedemosi()
                historydemosi()
                updatepos()
            End If
        End If
        loadData()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        reset()
        act = "input"
    End Sub

    Dim history As RotasiHistory
    Dim history2 As DemosiHistory


    Private Sub BarButtonItem4_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        If history Is Nothing OrElse history.IsDisposed Then
            history = New RotasiHistory
        End If
        history.Show()
    End Sub


    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        If history2 Is Nothing OrElse history2.IsDisposed Then
            history2 = New DemosiHistory
        End If
        history2.Show()
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
End Class