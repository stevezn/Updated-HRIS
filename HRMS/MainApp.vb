Imports System.IO
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Utils.Menu

Public Class MainApp
    'recruitment
    Dim connectionString As String
    Dim SQLConnection As MySqlConnection = New MySqlConnection
    Dim oDt_sched As New DataTable()

    Public conStr As String

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

#Region "koneksi "

#End Region


    Private Sub MainApp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        Dim lbl As MySqlCommand = SQLConnection.CreateCommand
        lbl.CommandText = "select user from db_temp"
        Dim name As String = CStr(lbl.ExecuteScalar)
        Label1.Text = name
        RibbonPageGroup7.Visible = False
        Timer1.Enabled = True
        BarButtonItem1.PerformClick()
        act = "input"
        If barJudul.Caption = "Module Employee" Then
        End If
        Dim notify As MySqlCommand = SQLConnection.CreateCommand
        notify.CommandText = "select count(*) from db_recruitment where interviewdate = curdate() and status = 'In Progress'"
        Dim note As Integer = CInt(notify.ExecuteScalar)
        If note > 0 Then
            NotifyIcon1.Visible = True
            NotifyIcon1.Icon = SystemIcons.Information
            NotifyIcon1.BalloonTipTitle = "Reminders"
            NotifyIcon1.BalloonTipText = "You have " & note & " Interviews Scheduled For Today"
            NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
            NotifyIcon1.ShowBalloonTip(300000)
            Dim notify2 As MySqlCommand = SQLConnection.CreateCommand
            notify2.CommandText = "select count(*) from db_recruitment where status = 'In Progress'"
            Dim note2 As Integer = CInt(notify2.ExecuteScalar)
            If note2 > 0 Then
                NotifyIcon2.Visible = True
                NotifyIcon2.Icon = SystemIcons.Information
                NotifyIcon2.BalloonTipTitle = "Reminders"
                NotifyIcon2.BalloonTipText = "You Still Have " & note2 & " Recruitment Progress In The Lists"
                NotifyIcon2.BalloonTipIcon = ToolTipIcon.Info
                NotifyIcon2.ShowBalloonTip(300000)
            End If
        End If
    End Sub

    Sub resetclear()
        txtposition.Text = ""
        txtBar1.Text = ""
        txtBar2.Text = ""
        txtBar3.Text = ""
        txtBar4.Text = ""
        txtBar5.Text = ""
        txtbar6.Text = ""
        txtstart.Text = ""
        txtfinish.Text = ""
        txtlocation.Text = ""
        txtphone.Text = ""
        compacode.Text = ""
    End Sub

    Sub reset()
        txtBar1.Text = ""
        txtBar2.Text = ""
        txtBar3.Text = ""
        txtBar4.Text = ""
        txtBar5.Text = ""
        txtbar6.Text = ""
        txtTanggal.Text = ""
        txtposition.Text = ""
        txtstart.Text = ""
        txtfinish.Text = ""
        lcproc.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcprogress.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcchange.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcbtnnew.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcstart.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcfinish.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcrotasi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcnotes.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcsp1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcposition.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcphone.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lclocation.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lc3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lc3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lc4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lc5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lc6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcTanggal.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcJnsShif.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        loadDataKaryawan()
    End Sub

#Region "menu bar"
    Private Sub BarButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        btnLihat.Enabled = True
        clearForm()
        reset()
        resetclear()
        lcprogress.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcForm.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcBtnSimpan.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcBtnHapus.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcBtnReset.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcbtnnew.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcchange.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        btnImport.Enabled = False
        barJudul.Caption = "Module Recruitment"
        GridControl1.RefreshDataSource()
        GridView1.Columns.Clear()
        loadDataReq()
        RibbonPageGroup7.Visible = False
    End Sub

    Private Sub BarButtonItem2_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        btnLihat.Enabled = False
        btnImport.Enabled = True
        reset()
        resetclear()
        lcrotasi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcsp1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcnotes.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcForm.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcBtnSimpan.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcBtnHapus.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcBtnReset.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcbtnnew.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcchange.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcprogress.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        barJudul.Caption = "Module Employee"
        GridControl1.RefreshDataSource()
        GridView1.Columns.Clear()
        loadDataReq()
        RibbonPageGroup7.Visible = False
    End Sub

    Private Sub BarButtonItem3_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        If loan Is Nothing OrElse loan.IsDisposed OrElse loan.MinimizeBox Then
            loan.Close()
            loan = New Payments
        End If
        loan.Show()
        loan.BarButtonItem1.PerformClick()
        loan.XtraTabPage5.Show()
        RibbonPageGroup7.Visible = False
    End Sub
    Dim showatt As New ShowAtt

    Private Sub BarButtonItem4_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        If showatt Is Nothing OrElse showatt.IsDisposed OrElse showatt.MinimizeBox Then
            showatt.Close()
            showatt = New ShowAtt
        End If
        showatt.Show()
    End Sub

    Private Sub BarButtonItem5_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        Dim pesan As String
        pesan = CType(MsgBox("Log Off Application?", MsgBoxStyle.YesNo, "Warning"), String)
        If CType(pesan, Global.Microsoft.VisualBasic.MsgBoxResult) = vbYes Then
            Dim del As MySqlCommand = SQLConnection.CreateCommand
            del.CommandText = "delete from db_hasil where EmployeeCode != 'absbahsgedeg'"
            del.ExecuteNonQuery()
            Dim dele As MySqlCommand = SQLConnection.CreateCommand
            dele.CommandText = "delete from db_temp where EmployeeCode != 'absbahsgedeg'"
            dele.ExecuteNonQuery()

            Dim delet As MySqlCommand = SQLConnection.CreateCommand
            delet.CommandText = "delete from db_tmpname where EmployeeCode != 'absbahsgedeg'"
            delet.ExecuteNonQuery()

            SQLConnection.Close()
            Close()
            setting.Close()
            rotasi.Close()
            employeenotes.Close()
            loan.Close()
            Login.Close()
        End If
    End Sub

    'Private Sub btnCari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    'load data ke grid
    '    'GridControl1.DataSource = DBNull.Value
    '    GridControl1.RefreshDataSource()
    '    Dim table As New DataTable

    '    SQLConnection = New MySqlConnection()
    '    SQLConnection.ConnectionString = connectionString
    '    SQLConnection.Open()
    '    Dim sqlCommand As New MySqlCommand
    '    Try
    '        If barJudul.Caption = "Module Recruitment" Then
    '            sqlCommand.CommandText = "Select IdRec, InterviewTimes, FullName, PlaceOfBirth, DateOfBirth, Gender, Religion, IdNumber, Status FROM db_recruitment" +
    '                                     " WHERE InterviewTimes Like '%" + tePencarian.Text + "%' or " +
    '                                     " FullName like'%" + tePencarian.Text + "%' or " +
    '                                     " PlaceOfBirth like'%" + tePencarian.Text + "%' or " +
    '                                     " DateOfBirth like'%" + tePencarian.Text + "%' or " +
    '                                     " Gender like'%" + tePencarian.Text + "%' or " +
    '                                     " Religion like'%" + tePencarian.Text + "%' or " +
    '                                     " IdNumber like'%" + tePencarian.Text + "%' or " +
    '                                     " Status like'%" + tePencarian.Text + "%'"
    '        ElseIf barJudul.Caption = "Module Employee" Then
    '            Dim param As Double
    '            If tePencarian.Text = "" Then
    '                param = 0
    '            End If
    '            sqlCommand.CommandText = "SELECT EmployeeCode, CompanyCode, FullName, PlaceOfBirth, DateOfBirth, Gender, Religion, IdNumber, Status, TrainingSampai, JenisPegawai, StatusWajibPajak from db_pegawai" +
    '                                     " WHERE CompanyCode like '%" + tePencarian.Text + "%' or " +
    '                                     " FullName like '%" + tePencarian.Text + "%' or " +
    '                                     " PlaceOfBirth like '%" + tePencarian.Text + "%' or " +
    '                                     " DateOfBirth like '%" + tePencarian.Text + "%' or " +
    '                                     " Gender like '%" + tePencarian.Text + "%' or " +
    '                                     " Religion like '%" + tePencarian.Text + "%' or " +
    '                                     " IdNumber like '%" + tePencarian.Text + "%' or " +
    '                                     " Status like '%" + tePencarian.Text + "%' or " +
    '                                     " TrainingSampai like '%" + tePencarian.Text + "%' or " +
    '                                     " JenisPegawai like '%" + tePencarian.Text + "%' or " +
    '                                     " BasicRate =" + param.ToString() + " or " +
    '                                     " Allowance =" + param.ToString() + " or " +
    '                                     " BiayaJabatan = " + param.ToString() + " or " +
    '                                     " iuran_pensiun = " + param.ToString() + " or " +
    '                                     " StatusWajibPajak like '%" + tePencarian.Text + "%'  "
    '        ElseIf barJudul.Caption = "Module Payroll" Then
    '            sqlCommand.CommandText = "SELECT EmployeeCode, FullName, BasicRate, Allowance, Incentives, MealRate, BiayaJabatan, JaminanKematian from db_payroll" +
    '                                        " WHERE EmployeeCode like '%" + tePencarian.Text + "%' or " +
    '                                        " FullName like '%" + tePencarian.Text + "%' or " +
    '                                        " BasicRate like '%" + tePencarian.Text + "%' or " +
    '                                        " Allowance like '%" + tePencarian.Text + "%' or " +
    '                                        " Incentives like '%" + tePencarian.Text + "%' or " +
    '                                        " MealRate like '%" + tePencarian.Text + "%' or " +
    '                                        " BiayaJabatan like '%" + tePencarian.Text + "%' or " +
    '                                        " IuranPensiun like '%" + tePencarian.Text + "%'    "
    '            Dim param As Double
    '            If tePencarian.Text = "" Then
    '                param = 0
    '            End If
    '            sqlCommand.CommandText = "SELECT a.EmployeeCode, a.FullName , count(b.FullName) as jml_masuk, a.JenisPegawai, a.BasicRate, IF(a.JenisPegawai ='Full Time', a.BasicRate, (a.BasicRate * count(b.BasicRate))) as jml_gaji, b.tanggal, IF(sum(b.lama_lembur) > 0, ((1.5 *(1/173)) * a.BasicRate * sum(b.lama_lembur)), 0) as jml_lembur, a.Allowance, a.StatusWajibPajak, BiayaJabatan,Iuran_pensiun" +
    '                                         " from" +
    '                                         " db_pegawai a, db_absensi b" +
    '                                         " WHERE a.EmployeeCode = b.EmployeeCode " +
    '                                         " group by SUBSTRING(b.tanggal, 1,2), SUBSTRING(b.tanggal, 7,10)" +
    '                                         " having " +
    '                                         " a.EmployeeCode like'%" + tePencarian.Text + "%' or " +
    '                                         " a.FullName like'%" + tePencarian.Text + "%' or " +
    '                                         " count(b.EmployeeCode) =" + param.ToString() + " or " +
    '                                         " a.JenisPegawai like'%" + tePencarian.Text + "%' or " +
    '                                         " a.BasicRate like'%" + tePencarian.Text + "%' or " +
    '                                         " IF(a.JenisPegawai like 'Full Time', a.BasicRate, (a.BasicRate * count(b.EmployeeCode))) =" + param.ToString() + " or " +
    '                                         " IF(sum(b.lama_lembur) > 0, ((1.5 *(1/173)) * a.BasicRate * sum(b.lama_lembur)), 0) =" + param.ToString() + " or " +
    '                                         " b.tanggal like'%" + tePencarian.Text + "%'"
    '        ElseIf barJudul.Caption = "Module Attendance" Then
    '            sqlCommand.CommandText = "SELECT a.id_absensi, a.EmployeeCode, b.FullName, a.tanggal, a.shift, a.jam_mulai, a.jam_selesai from db_absensi a, db_pegawai b WHERE a.EmployeeCode=b.EmployeeCode"
    '        End If
    '        sqlCommand.Connection = SQLConnection
    '        Dim tbl_par As New DataTable
    '        Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
    '        Dim cb As New MySqlCommandBuilder(adapter)
    '        adapter.Fill(table)
    '        SQLConnection.Close()
    '    Catch ex As Exception
    '        SQLConnection.Close()
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Dim tbl_par As New DataTable

    Sub loadDataKaryawan()
        Dim sqlCommand As New MySqlCommand
        sqlCommand.CommandText = "SELECT EmployeeCode, FullName, Position, CompanyCode FROM db_pegawai WHERE Status!='Fired'"
        sqlCommand.Connection = SQLConnection
        Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
        Dim cb As New MySqlCommandBuilder(adapter)
        adapter.Fill(tbl_par)
        For index As Integer = 0 To tbl_par.Rows.Count - 1
        Next
    End Sub

#End Region

#Region "button fungsional"
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        resetclear()
        act = "input"
    End Sub

    Private Sub btnSegarkan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSegarkan.Click
        loadDataReq()
        'CardView1.Focus()
        'CardView1.MoveLast()
    End Sub

    Private Sub btnHapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHapus.Click
        lcProgbar.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        marqueBar.Visible = True
        If barJudul.Caption = "Module Recruitment" Then
            DeleteReq()
        ElseIf barJudul.Caption = "Module Employee" Then
            DeleteEmp()
        ElseIf barJudul.Caption = "Module Payroll" Then
            DeletePay()
        ElseIf barJudul.Caption = "Module Attendance" Then
            DeleteAtt()
        End If
        loadDataReq()
        marqueBar.Visible = False
        lcProgbar.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        importData()
        updatestats()
        'CardView1.Focus()
        'CardView1.MoveLast()
    End Sub

    Dim infoForm As New infoReq

    Public Sub btnLihat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLihat.Click
        If infoForm Is Nothing OrElse infoForm.IsDisposed OrElse infoForm.MinimizeBox Then
            infoForm.Close()
            infoForm = New infoReq
        End If
        infoForm.Show()
    End Sub

#End Region

#Region "CRUD database"
    'import to employee
    Dim table As DataTable

    Private Sub importData()
        Dim maxid As Integer
        Dim newid As Integer = maxid + 1
        Dim ynow As String = Format(Now, "yy").ToString
        Dim mnow As String = Month(Now).ToString
        Dim lastn As Integer
        Dim updmon As String
        Dim lastcode As String = ""
        Dim tmp As Integer
        Dim numstat As Integer
        Try
            Dim cmd1 = SQLConnection.CreateCommand
            cmd1.CommandText = "select idrec from db_recruitment where status = 'Accepted'"
            Dim adp1 As New MySqlDataAdapter(cmd1)
            Dim ds1 As New DataSet
            adp1.Fill(ds1)
            For Each dt As DataTable In ds1.Tables
                For Each row As DataRow In dt.Rows
                    Try
                        Dim cmd = SQLConnection.CreateCommand
                        cmd.CommandText = "select count(*) from db_recruitment where status = 'Accepted'"
                        numstat = CInt(cmd.ExecuteScalar)
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                    Try
                        Dim cmd = SQLConnection.CreateCommand()
                        cmd.CommandText = "SELECT last_num FROM view_emp_last_code"
                        lastn = DirectCast(cmd.ExecuteScalar(), Integer)
                    Catch ex As Exception
                    End Try
                    Try
                        Dim cmd = SQLConnection.CreateCommand
                        cmd.CommandText = "SELECT EmployeeCode FROM db_pegawai ORDER BY EmployeeCode DESC LIMIT 1"
                        lastcode = DirectCast(cmd.ExecuteScalar(), String)
                    Catch ex As Exception
                    End Try
                    Try
                        Dim cmd = SQLConnection.CreateCommand
                        cmd.CommandText = "SELECT MID(EmployeeCode, 4, 1) FROM db_pegawai where EmployeeCode = '" & lastcode & "'"
                        updmon = DirectCast(cmd.ExecuteScalar(), String)
                        If CInt(updmon) <> CInt(mnow) Then
                            tmp = 1
                        Else
                            tmp = lastn + 1
                        End If
                    Catch ex2 As Exception
                    End Try
                    Dim actualcode As String = ynow & "-" & mnow & "-" & Strings.Right("0000" & tmp, 5)
                    Dim sqlCommand As New MySqlCommand
                    Try
                        sqlCommand.CommandText = "INSERT INTO db_pegawai (FullName, PlaceOfBirth, DateOfBirth, Address, Gender, Religion, IdNumber, Photo, status, CompanyCode, EmployeeCode, OfficeLocation, PhoneNumber, TrainingSampai, WorkDate, ChangeDate)" +
                                                         "SELECT FullName, PlaceOfBirth, DateOfBirth, Address, Gender, Religion, IdNumber, Photo, @status, @CompanyCode, @EmployeeCode, @OfficeLocation, @PhoneNumber, @TrainingSampai, @WorkDate, @ChangeDate FROM db_recruitment WHERE Status='Accepted' AND idrec = @idrec"
                        sqlCommand.Parameters.AddWithValue("@Status", "Active")
                        sqlCommand.Parameters.AddWithValue("@CompanyCode", "<empty>")
                        sqlCommand.Parameters.AddWithValue("@EmployeeCode", actualcode)
                        sqlCommand.Parameters.AddWithValue("@OfficeLocation", "<empty>")
                        sqlCommand.Parameters.AddWithValue("@PhoneNumber", employees.txtphone.Text)
                        sqlCommand.Parameters.AddWithValue("@TrainingSampai", "<empty>")
                        sqlCommand.Parameters.AddWithValue("@WorkDate", Date.Now)
                        sqlCommand.Parameters.AddWithValue("@ChangeDate", Date.Now)
                        sqlCommand.Parameters.AddWithValue("@idrec", row.Item("idrec"))
                        sqlCommand.Connection = SQLConnection
                        sqlCommand.ExecuteNonQuery()
                        MessageBox.Show("Data Succesfully Imported, Please Click Refresh To Load")
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Next
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'SELECT CONCAT(DATE_FORMAT(Now(),'%y-%m'),"-", LPAD((RIGHT(MAX(EmployeeCode),4)+1),4,'0')) FROM db_pegawai 

    Public Sub updatestats()
        Dim sqlcommand As New MySqlCommand
        Try
            sqlcommand.CommandText = "UPDATE db_recruitment SET" +
                                    " Status = @Status" +
                                    " WHERE Status = 'Accepted'"
            sqlcommand.Connection = SQLConnection
            sqlcommand.Parameters.AddWithValue("@Status", "Processed")
            sqlcommand.Connection = SQLConnection
            sqlcommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub loadDataReq()
        GridControl1.RefreshDataSource()
        Dim table As New DataTable
        Dim sqlCommand As New MySqlCommand
        Try
            If barJudul.Caption = "Module Recruitment" Then
                sqlCommand.CommandText = "Select IdRec, InterviewTimes, FullName, PlaceOfBirth, DateOfBirth, Address, Gender, Religion, PhoneNumber, IdNumber, InterviewDate, Status, CreatedDate from db_recruitment where status != 'In Progress'"
            ElseIf barJudul.Caption = "Module Employee" Then
                sqlCommand.CommandText = "Select EmployeeCode, CompanyCode, FullName, Position, PlaceOfBirth, DateOfBirth, Gender, Religion, Address, Email, IdNumber, OfficeLocation, WorkDate, PhoneNumber, Status, TrainingSampai, EmployeeType FROM db_pegawai where status != 'Fired'"
            ElseIf barJudul.Caption = "Module Payroll" Then
                sqlCommand.CommandText = "Select EmployeeCode, CompanyCode, PaymentDate, FullName, BasicRate, Gross, Bpjs, OvertimeSalary, TotalDeductions, NetIncome, JaminanKecelakaanKerja, PremiJaminanKematian, JaminanHariTua, BiayaJabatan, IuranPensiun, PphTerhutang, PajakPphPerTahun, PenghasilanKenaPajak, NettoSetahun, StatusWajibPajak, Rapel FROM db_payroll"
            ElseIf barJudul.Caption = "Module Attendance" Then
                sqlCommand.CommandText = "SELECT EmployeeCode, FullName, Tanggal, Shift, JamMulai, JamSelesai FROM db_absensi"
            ElseIf barJudul.Caption = "Module Payment Details" Then
                sqlCommand.CommandText = "SELECT EmployeeCode, PaymentDate, FullName, BasicRate, Gross, Bpjs, OvertimeSalary, TotalDeductions, NetIncome, JaminanKecelakaanKerja, PremiJaminanKematian, JaminanHariTua, BiayaJabatan, IuranPensiun, PphTerhutang, PajakPphPerTahun, PenghasilanKenaPajak, NettoSetahun, StatusWajibPajak, Rapel FROM db_payrolldetails"
            ElseIf barJudul.Caption = "Employee Menus" Then
                sqlCommand.CommandText = "SELECT EmployeeCode, FullName, Position, SuratPeringatan1, SuratPeringatan2, SuratPeringatan3, Rotasi, Demosi FROM db_sp"
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

    Public Function InsertAtt() As Boolean
        Dim sqlCommand As New MySqlCommand
        Dim str_carSql As String
        Try
            If act = "edit" Then
                str_carSql = "UPDATE db_absensi SET" +
                        " FullName = @FullName" +
                       ", Tanggal = @Tanggal" +
                       ", Shift = @Shift" +
                       ", JamMulai = @JamMulai" +
                       ", JamSelesai = @JamSelesai" +
                       " WHERE EmployeeCode = @EmployeeCode"
            Else
                str_carSql = "INSERT INTO db_absensi " +
                            "(EmployeeCode, FullName, Tanggal, Shift, JamMulai, JamSelesai) " +
                            "values (@EmployeeCode,@FullName,@Tanggal,@Shift,@JamMulai,@JamSelesai)"
            End If
            sqlCommand.Connection = SQLConnection
            sqlCommand.CommandText = str_carSql
            sqlCommand.Parameters.AddWithValue("@EmployeeCode", txtbar2.Text)
            sqlCommand.Parameters.AddWithValue("@Tanggal", txtTanggal.Text)
            sqlCommand.Parameters.AddWithValue("@Shift", txtJnsShift.Text)
            sqlCommand.Parameters.AddWithValue("@JamMulai", txtstart.Text)
            sqlCommand.Parameters.AddWithValue("@JamSelesai", txtfinish.Text)
            sqlCommand.ExecuteNonQuery()
            If act = "input" Then
                MessageBox.Show("Data Successfully Added!")
            ElseIf act = "edit" Then
                MessageBox.Show("Data Successfully Changed!")
            End If
            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show("Process Failed!")
        End Try
    End Function
    ''delete

    'Private Sub GridView1_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs)
    '    SQLConnection = New MySqlConnection()
    '    SQLConnection.ConnectionString = connectionString
    '    SQLConnection.Open()
    '    Dim datatabl As New DataTable
    '    Dim sqlCommand As New MySqlCommand
    '    datatabl.Clear()
    '    If barJudul.Caption = "Module Recruitment" Then
    '        Dim param As String = ""
    '        Try
    '            param = "and IdRec='" + GridView1.GetFocusedRowCellValue("IdRec").ToString() + "'"
    '        Catch ex As Exception
    '        End Try
    '        If param > "" Then
    '            act = "edit"
    '        Else
    '            act = "input"
    '        End If
    '        Try
    '            sqlCommand.CommandText = "SELECT IdRec,InterviewTimes FROM db_recruitment WHERE 1 = 1 " + param.ToString()
    '            sqlCommand.Connection = SQLConnection

    '            Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
    '            Dim cb As New MySqlCommandBuilder(adapter)
    '            adapter.Fill(datatabl)
    '            SQLConnection.Close()
    '        Catch ex As Exception
    '            SQLConnection.Close()
    '            MsgBox(ex.Message, MsgBoxStyle.Critical)
    '        End Try
    '        If datatabl.Rows.Count > 0 Then
    '            txtBar1.Text = datatabl.Rows(0).Item(0).ToString()
    '            txtBar2.Text = datatabl.Rows(0).Item(1).ToString()
    '        End If
    '    ElseIf barJudul.Caption = "Module Employee" Then
    '        Dim param2 As String = ""
    '        Try
    '            param2 = "and EmployeeCode='" + GridView1.GetFocusedRowCellValue("EmployeeCode").ToString() + "'"
    '        Catch ex As Exception
    '            MsgBox(ex.Message, MsgBoxStyle.Critical)
    '        End Try
    '        If param2 = "" Then
    '            act = "input"
    '        Else
    '            act = "edit"
    '        End If
    '        Try
    '            sqlCommand.CommandText = "SELECT * FROM db_pegawai WHERE 1 = 1 " + param2.ToString()
    '            sqlCommand.Connection = SQLConnection
    '            Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
    '            Dim cb As New MySqlCommandBuilder(adapter)
    '            adapter.Fill(datatabl)
    '            SQLConnection.Close()
    '        Catch ex As Exception
    '            SQLConnection.Close()
    '            MsgBox(ex.Message, MsgBoxStyle.Critical)
    '        End Try
    '        If datatabl.Rows.Count > 0 Then
    '            txtBar2.Text = datatabl.Rows(0).Item(0).ToString()
    '            compacode.Text = datatabl.Rows(0).Item(1).ToString()
    '            txtBar3.Text = datatabl.Rows(0).Item(2).ToString()
    '            txtposition.Text = datatabl.Rows(0).Item(3).ToString()
    '            txtBar4.Text = datatabl.Rows(0).Item(4).ToString()
    '            txtTanggal.Text = datatabl.Rows(0).Item(5).ToString()
    '            txtbar6.Text = datatabl.Rows(0).Item(6).ToString()
    '            txtbar7.Text = datatabl.Rows(0).Item(7).ToString()
    '            txtaddress.Text = datatabl.Rows(0).Item(8).ToString()
    '            txtemail.Text = datatabl.Rows(0).Item(9).ToString()
    '            txtBar8.Text = datatabl.Rows(0).Item(10).ToString()
    '            txtlocation.Text = datatabl.Rows(0).Item(11).ToString()
    '            txtworkdate.Text = datatabl.Rows(0).Item(12).ToString()
    '            txtphone.Text = datatabl.Rows(0).Item(13).ToString()
    '            Dim filefoto As Byte() = CType(datatabl.Rows(0).Item(14), Byte())
    '            If filefoto.Length > 0 Then
    '                pictureEdit.Image = ByteToImage(filefoto)
    '            Else
    '                pictureEdit.Image = Nothing
    '                pictureEdit.Refresh()
    '            End If
    '            txtStatEmp.Text = datatabl.Rows(0).Item(15).ToString()
    '            'txtTrainingSampai.Text = datatabl.Rows(0).Item(16).ToString()
    '        End If
    '    ElseIf barJudul.Caption = "Module Payroll" Then
    '        Dim param2 As String = ""
    '        Try
    '            param2 = "and EmployeeCode='" + GridView1.GetFocusedRowCellValue("EmployeeCode").ToString() + "'"
    '        Catch ex As Exception
    '        End Try
    '        If param2 = "" Then
    '            act = "input"
    '        Else
    '            act = "edit"
    '        End If
    '        Try
    '            sqlCommand.CommandText = "SELECT * FROM db_payroll WHERE 1 = 1 " + param2.ToString()
    '            sqlCommand.Connection = SQLConnection
    '            Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
    '            Dim cb As New MySqlCommandBuilder(adapter)
    '            adapter.Fill(datatabl)
    '            SQLConnection.Close()
    '        Catch ex As Exception
    '            SQLConnection.Close()
    '            MsgBox(ex.Message, MsgBoxStyle.Critical)
    '        End Try
    '        If datatabl.Rows.Count > 0 Then
    '            txtBar2.Text = datatabl.Rows(0).Item(0).ToString()
    '            txtNamaKaryawan.Text = datatabl.Rows(0).Item(1).ToString()
    '            txtpayment.Text = datatabl.Rows(0).Item(2).ToString()
    '            txtGaji.Text = datatabl.Rows(0).Item(3).ToString()
    '            txtAllowance.Text = datatabl.Rows(0).Item(4).ToString()
    '            txtIncentives.Text = datatabl.Rows(0).Item(5).ToString()
    '            txtMeal.Text = datatabl.Rows(0).Item(6).ToString()
    '            txtTransport.Text = datatabl.Rows(0).Item(7).ToString()
    '            txtadddc1.Text = datatabl.Rows(0).Item(8).ToString()
    '            txtadddc2.Text = datatabl.Rows(0).Item(9).ToString()
    '            txtadddc3.Text = datatabl.Rows(0).Item(10).ToString()
    '            txtadddc4.Text = datatabl.Rows(0).Item(11).ToString()
    '            txtadddc5.Text = datatabl.Rows(0).Item(12).ToString()
    '            txt1add.Text = datatabl.Rows(0).Item(13).ToString()
    '            txt2add.Text = datatabl.Rows(0).Item(14).ToString()
    '            txt3add.Text = datatabl.Rows(0).Item(15).ToString()
    '            txt4add.Text = datatabl.Rows(0).Item(16).ToString()
    '            txt5add.Text = datatabl.Rows(0).Item(17).ToString()
    '            txtothours.Text = datatabl.Rows(0).Item(18).ToString()
    '            txtottype.Text = datatabl.Rows(0).Item(19).ToString()
    '            txtbpjspercentage.Text = datatabl.Rows(0).Item(20).ToString()
    '            txttaxes.Text = datatabl.Rows(0).Item(21).ToString()
    '            txtloan.Text = datatabl.Rows(0).Item(22).ToString()
    '            txtlates.Text = datatabl.Rows(0).Item(23).ToString()
    '            txtdeddc1.Text = datatabl.Rows(0).Item(24).ToString()
    '            txtdeddc2.Text = datatabl.Rows(0).Item(25).ToString()
    '            txtdeddc3.Text = datatabl.Rows(0).Item(26).ToString()
    '            txtdeddc4.Text = datatabl.Rows(0).Item(27).ToString()
    '            txtdeddc5.Text = datatabl.Rows(0).Item(28).ToString()
    '            txt1ded.Text = datatabl.Rows(0).Item(29).ToString()
    '            txt2ded.Text = datatabl.Rows(0).Item(30).ToString()
    '            txt3ded.Text = datatabl.Rows(0).Item(31).ToString()
    '            txt4ded.Text = datatabl.Rows(0).Item(32).ToString()
    '            txt5ded.Text = datatabl.Rows(0).Item(33).ToString()
    '            cmboxjkk.Text = datatabl.Rows(0).Item(34).ToString()
    '            cmboxjk.Text = datatabl.Rows(0).Item(35).ToString()
    '            cmboxjht.Text = datatabl.Rows(0).Item(36).ToString()
    '            cmboxbj.Text = datatabl.Rows(0).Item(37).ToString()
    '            cmboxiuranpensiun.Text = datatabl.Rows(0).Item(38).ToString()
    '            cmboxnpwp.Text = datatabl.Rows(0).Item(44).ToString()
    '            txtgross.Text = datatabl.Rows(0).Item(45).ToString()
    '            txtbpjs.Text = datatabl.Rows(0).Item(46).ToString()
    '            txtotsalary.Text = datatabl.Rows(0).Item(47).ToString()
    '            txtdeduction.Text = datatabl.Rows(0).Item(48).ToString()
    '            txtnetincome.Text = datatabl.Rows(0).Item(49).ToString()
    '            txtpkp.Text = datatabl.Rows(0).Item(50).ToString()
    '            txtjkk.Text = datatabl.Rows(0).Item(51).ToString()
    '            txtjk.Text = datatabl.Rows(0).Item(52).ToString()
    '            txtjht.Text = datatabl.Rows(0).Item(53).ToString()
    '            txtpphterutang.Text = datatabl.Rows(0).Item(54).ToString()
    '            txthasilbjabatan.Text = datatabl.Rows(0).Item(55).ToString()
    '            txthasiliuranpensiun.Text = datatabl.Rows(0).Item(56).ToString()
    '            lcnettosetahun.Text = datatabl.Rows(0).Item(57).ToString()
    '            txtStatWp.Text = datatabl.Rows(0).Item(58).ToString()
    '            frommonth.Text = datatabl.Rows(0).Item(59).ToString()
    '            tomonth.Text = datatabl.Rows(0).Item(60).ToString()
    '            txtrapel.Text = datatabl.Rows(0).Item(61).ToString()
    '            rapel.Text = datatabl.Rows(0).Item(62).ToString()
    '            txtpajakpph.Text = datatabl.Rows(0).Item(63).ToString()
    '        End If
    '    ElseIf barJudul.Caption = "Module Attendance" Then
    '        Dim param2 As String = ""
    '        Try
    '            param2 = "and EmployeeCode ='" + GridView1.GetFocusedRowCellValue("EmployeeCode").ToString() + "'"
    '        Catch ex As Exception
    '            MsgBox(ex.Message, MsgBoxStyle.Critical)
    '        End Try
    '        If param2 = "" Then
    '            act = "input"
    '        Else
    '            act = "edit"
    '        End If
    '        Try
    '            sqlCommand.CommandText = "SELECT * FROM db_absensi WHERE 1 = 1 " + param2.ToString()
    '            sqlCommand.Connection = SQLConnection
    '            Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
    '            Dim cb As New MySqlCommandBuilder(adapter)
    '            adapter.Fill(datatabl)
    '            SQLConnection.Close()
    '        Catch ex As Exception
    '            SQLConnection.Close()
    '            MsgBox(ex.Message, MsgBoxStyle.Critical)
    '        End Try
    '        If datatabl.Rows.Count > 0 Then
    '            txtBar2.Text = datatabl.Rows(0).Item(0).ToString()
    '            txtNamaKaryawan.Text = datatabl.Rows(0).Item(1).ToString()
    '            txtTanggal.Text = datatabl.Rows(0).Item(2).ToString
    '            txtJnsShift.Text = datatabl.Rows(0).Item(3).ToString
    '            txtstart.Text = datatabl.Rows(0).Item(4).ToString
    '            txtfinish.Text = datatabl.Rows(0).Item(5).ToString
    '        End If
    '    ElseIf barJudul.Caption = "Employee Menus" Then
    '        Dim param2 As String = ""
    '        Try
    '            param2 = "and EmployeeCode='" + GridView1.GetFocusedRowCellValue("EmployeeCode").ToString() + "'"
    '        Catch ex As Exception
    '        End Try
    '        If param2 = "" Then
    '            act = "input"
    '        Else
    '            act = "edit"
    '        End If
    '        Try
    '            sqlCommand.CommandText = "SELECT EmployeeCode, CompanyCode, FullName, Position, SuratPeringatan1, SuratPeringatan2, SuratPeringatan3, Rotasi, Demosi from db_sp" + param2.ToString()
    '            sqlCommand.Connection = SQLConnection
    '            Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
    '            Dim cb As New MySqlCommandBuilder(adapter)
    '            adapter.Fill(datatabl)
    '            SQLConnection.Close()
    '        Catch ex As Exception
    '            SQLConnection.Close()
    '            MsgBox(ex.Message)
    '        End Try
    '        If datatabl.Rows.Count > 0 Then
    '            txtBar2.Text = datatabl.Rows(0).Item(0).ToString()
    '            compcode.Text = datatabl.Rows(0).Item(1).ToString()
    '            txtNamaKaryawan.Text = datatabl.Rows(0).Item(2).ToString()
    '            txtposition.Text = datatabl.Rows(0).Item(3).ToString()
    '        End If
    '    End If
    'End Sub

    Public Function deletesp() As Boolean
        Dim sqlcommand As New MySqlCommand
        Dim mess As String
        mess = CType(MsgBox("Sure To Delete ?", MsgBoxStyle.YesNo, "Warning"), String)
        If CType(mess, Global.Microsoft.VisualBasic.MsgBoxResult) = vbYes Then
            sqlcommand.Connection = SQLConnection
            sqlcommand.CommandType = CommandType.Text
            sqlcommand.CommandText = "DELETE FROM db_sp WHERE EmployeeCode = " + txtbar2.Text
            sqlcommand.ExecuteNonQuery()
            MsgBox("Data Succesfully Removed!", MsgBoxStyle.Information, "Success")
            GridControl1.RefreshDataSource()
            loadDataReq()
        End If
        Return Nothing
    End Function

    Private movelast As Boolean = True

    Public Function DeleteReq() As Boolean
        Dim sqlCommand As New MySqlCommand
        Dim pesan As String
        pesan = CType(MsgBox("Sure To Delete ?", MsgBoxStyle.YesNo, "Warning"), String)
        If CType(pesan, Global.Microsoft.VisualBasic.MsgBoxResult) = vbYes Then
            sqlCommand.Connection = SQLConnection
            sqlCommand.CommandType = CommandType.Text
            sqlCommand.CommandText = "DELETE FROM db_recruitment WHERE IdRec = " + txtBar1.Text
            sqlCommand.ExecuteNonQuery()
            MsgBox("Data Successfully Removed", MsgBoxStyle.Information, "Success")
            GridControl1.RefreshDataSource()
            loadDataReq()
        End If
        Return Nothing
    End Function

    Private needMoveLastRow As Boolean = True

    Public Function DeleteEmp() As Boolean
        Try
            Dim sqlCommand As New MySqlCommand
            Dim pesan As String
            pesan = CType(MsgBox("Sure To Delete ?", MsgBoxStyle.YesNo, "Warning"), String)
            If CType(pesan, Global.Microsoft.VisualBasic.MsgBoxResult) = vbYes Then
                sqlCommand.Connection = SQLConnection
                sqlCommand.CommandType = CommandType.Text
                sqlCommand.CommandText = "DELETE FROM db_pegawai WHERE EmployeeCode = " + txtBar2.Text
                sqlCommand.ExecuteNonQuery()
                MsgBox("Data Succesfully Removed !", MsgBoxStyle.Information, "Success")
                GridControl1.RefreshDataSource()
                loadDataReq()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return Nothing
    End Function

    Public Function DeletePay() As Boolean
        Dim sqlcommand As New MySqlCommand
        Dim messages As String
        messages = CType(MsgBox("Sure To Delete ?", MsgBoxStyle.YesNo, "Warning"), String)
        If CType(messages, Global.Microsoft.VisualBasic.MsgBoxResult) = vbYes Then
            sqlcommand.Connection = SQLConnection
            sqlcommand.CommandType = CommandType.Text
            sqlcommand.CommandText = "DELETE FROM db_payroll WHERE EmployeeCode = " + txtBar2.Text
            sqlcommand.ExecuteNonQuery()
            MsgBox("Data Succesfully Removed!", MsgBoxStyle.Information, "Success")
            GridControl1.RefreshDataSource()
            loadDataReq()
        End If
        Return Nothing
    End Function

    Public Function DeleteAtt() As Boolean
        Dim sqlcommand As New MySqlCommand
        Dim pesan As String
        pesan = CType(MsgBox("Sure To Delete ?", MsgBoxStyle.YesNo, "Warning"), String)
        If CType(pesan, Global.Microsoft.VisualBasic.MsgBoxResult) = vbYes Then
            sqlcommand.Connection = SQLConnection
            sqlcommand.CommandType = CommandType.Text
            sqlcommand.CommandText = "DELETE FROM db_absensi WHERE EmployeeCode = " + txtbar2.Text
            sqlcommand.ExecuteNonQuery()
            MsgBox("Data Successfully Removed!", MsgBoxStyle.Information, "Success")
            GridControl1.RefreshDataSource()
            loadDataReq()
        End If
        Return Nothing
    End Function
#End Region

    ''fungsi extras
    Sub clearForm()
        lc3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lc4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lc5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lc6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        txtbar1.Text = ""
        txtbar2.Text = ""
        txtBar3.Text = ""
        txtBar4.Text = ""
        txtBar5.Text = ""
        txtbar6.Text = ""
        txtTanggal.Text = ""
    End Sub

    Function ImageToByte(ByVal pbImg As PictureBox) As Byte()
        If pbImg Is Nothing Then
            Return Nothing
        End If
        Dim ms As New MemoryStream()
        pbImg.Image.Save(ms, Imaging.ImageFormat.Jpeg)
        Return ms.ToArray()
    End Function

    Public Function ByteToImage(ByVal filefoto As Byte()) As Image
        Dim pictureBytes As New MemoryStream(filefoto)
        Return Image.FromStream(pictureBytes)
    End Function

    Dim act As String = ""
    Dim spform As New SPForms

    Private Sub txtJnsShift_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJnsShift.SelectedValueChanged
        If txtJnsShift.SelectedIndex = 0 Then
            txtJnsShift.SelectedItem = "Shift 1(08.00-16.00)"
        ElseIf txtJnsShift.SelectedIndex = 1 Then
            txtJnsShift.SelectedItem = "Shift 2(16.00-00.00)"
        ElseIf txtJnsShift.SelectedIndex = 2 Then
            txtJnsShift.SelectedItem = "Shift 4(00.00-08.00)"
        ElseIf txtJnsShift.SelectedIndex = 3 Then
            txtJnsShift.SelectedItem = "Full Time (08.00-17.00)"
        ElseIf txtJnsShift.SelectedIndex = 4 Then
            txtJnsShift.SelectedItem = "Overtime"
        End If
    End Sub

    Dim setting As New setting

    Private Sub BarButtonItem6_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        If setting Is Nothing OrElse setting.IsDisposed Then
            setting = New setting
        End If
        setting.Show()
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

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        ShowGridPreview(GridControl1)
    End Sub

    Private Sub txtBar1_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim ch As Char = e.KeyChar
        If Char.IsLetter(ch) Then
            e.Handled = True
        End If
    End Sub

    Dim nilai As Double

    Dim value As Long
    Dim value2 As Long

    Private Sub rapel_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim ch As Char = e.KeyChar
        If Char.IsLetter(ch) Then
            e.Handled = True
        End If
    End Sub

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        clearForm()
        reset()
        resetclear()
        lcForm.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcBtnSimpan.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcBtnHapus.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcBtnReset.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        btnImport.Enabled = False
        barJudul.Caption = "Module Payment Details"
        GridControl1.RefreshDataSource()
        GridView1.Columns.Clear()
        loadDataReq()
    End Sub

    Private Sub BarButtonItem8_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem8.ItemClick
        clearForm()
        reset()
        resetclear()
        lcForm.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcBtnSimpan.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcBtnHapus.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcBtnReset.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcposition.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcsp1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcrotasi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        barJudul.Caption = "Employee Menus"
        GridControl1.RefreshDataSource()
        GridView1.Columns.Clear()
        loadDataReq()
    End Sub

    Dim employeenotes As New Notes
    Private Sub btnNotes_Click(sender As Object, e As EventArgs) Handles btnNotes.Click
        If employeenotes Is Nothing OrElse employeenotes.IsDisposed OrElse employeenotes.MinimizeBox Then
            employeenotes.Close()
            employeenotes = New Notes
        End If
        employeenotes.Show()
    End Sub

    Dim spforms As New SPForms

    Private Sub sp1_Click(sender As Object, e As EventArgs) Handles sp1.Click
        If spforms Is Nothing OrElse spforms.IsDisposed OrElse spforms.MinimizeBox Then
            spform.Close()
            spforms = New SPForms
        End If
        spforms.Show()
    End Sub

    Dim rotasi As New RotasiMutasi

    Private Sub GridView1_RowLoaded(sender As Object, e As Views.Base.RowEventArgs)
        Dim view As ColumnView = TryCast(sender, ColumnView)
        If needMoveLastRow = False Then
            view.MoveLast()
        End If
    End Sub

    Dim employees As New NewRec
    Dim newemps As New NewEmp

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        If barJudul.Caption = "Module Recruitment" Then
            If employees Is Nothing OrElse employees.IsDisposed OrElse employees.MinimizeBox Then
                employees.Close()
                employees = New NewRec
            End If
            employees.Show()
            employees.BarButtonItem1.PerformClick()
        ElseIf barJudul.Caption = "Module Employee" Then
            If newemps Is Nothing OrElse newemps.IsDisposed OrElse newemps.MinimizeBox Then
                newemps.Close()
                newemps = New NewEmp
            End If
            newemps.Show()
            newemps.BarButtonItem1.PerformClick()
        End If
    End Sub

    Dim proses As New RecProcess
    Dim formed As New ChangeData
    Dim changeem As New ChangeEmp

    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        If barJudul.Caption = "Module Recruitment" Then
            If formed Is Nothing OrElse formed.IsDisposed OrElse formed.MinimizeBox Then
                formed.Close()
                formed = New ChangeData
            End If
            formed.Show()
        ElseIf barJudul.Caption = "Module Employee" Then
            If changeem Is Nothing OrElse changeem.IsDisposed OrElse changeem.MinimizeBox Then
                formed.Close()
                changeem = New ChangeEmp
            End If
            changeem.Show()
        End If
    End Sub

    Private Sub btnProg_Click(sender As Object, e As EventArgs) Handles btnProg.Click
        If proses Is Nothing OrElse proses.IsDisposed OrElse proses.MinimizeBox Then
            proses.Close()
            proses = New RecProcess
        End If
        proses.Show()
    End Sub

    Dim loan As New Payments

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles btnProc.Click
        If loan Is Nothing OrElse loan.IsDisposed OrElse loan.MinimizeBox Then
            loan.Close()
            loan = New Payments
        End If
        loan.Show()
        loan.BarButtonItem1.PerformClick()
        loan.XtraTabPage5.Show()
    End Sub

    Private Sub GridView1_PopupMenuShowing_1(sender As Object, e As PopupMenuShowingEventArgs)
        Dim view As GridView = CType(sender, GridView)
        If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Row Then
            Dim rowHandle As Integer = e.HitInfo.RowHandle
            e.Menu.Items.Clear()
            Dim item As DXMenuItem = CreateMergingEnabledMenuItem(view, rowHandle)
            item.BeginGroup = True
            e.Menu.Items.Add(item)
        End If
    End Sub

    Dim repot As New Report

    Private Sub BarButtonItem11_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem11.ItemClick
        If repot Is Nothing OrElse repot.IsDisposed OrElse repot.MinimizeBox Then
            repot.Close()
            repot = New Report
        End If
        repot.Show()
        RibbonPageGroup7.Visible = False
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        TextEdit1.Text = Format(Now, "dd, MMMM, yyyy hhhh:mm:ss")
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If rotasi Is Nothing OrElse rotasi.IsDisposed OrElse rotasi.MinimizeBox Then
            rotasi.Close()
            rotasi = New RotasiMutasi
        End If
        rotasi.Show()
    End Sub

    Dim att2 As New Attendances

    Private Sub BarButtonItem12_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem12.ItemClick
        If att2 Is Nothing OrElse att2.IsDisposed OrElse att2.MinimizeBox Then
            att2.Close()
            att2 = New Attendances
        End If
        att2.Show()
    End Sub

    Private Sub MainApp_Closed(sender As Object, e As EventArgs) Handles Me.Closed
    End Sub

    Dim info As infoReq
    Dim note As New Notes

    Private Sub GridView1_PopupMenuShowing_2(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView1.PopupMenuShowing
        Dim view As GridView = CType(sender, GridView)
        If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Row Then
            Dim rowHandle As Integer = e.HitInfo.RowHandle
            e.Menu.Items.Clear()
            Dim item As DXMenuItem = CreateMergingEnabledMenuItem(view, rowHandle)
            item.BeginGroup = True
            e.Menu.Items.Add(item)
        End If
        If barJudul.Caption = "Module Recruitment" Then
            If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Row Then
                e.Menu.Items.Add(New DXMenuItem("View Recruitment Details", New EventHandler(AddressOf btnLihat_Click)))
            End If
        ElseIf barJudul.Caption = "Module Employee" Then
            If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Row Then
                e.Menu.Items.Add(New DXMenuItem("Terminate This Employee ?", New EventHandler(AddressOf SimpleButton2_Click_1)))
                e.Menu.Items.Add(New DXMenuItem("View Employee", New EventHandler(AddressOf btnNotes_Click)))
            End If
        End If
    End Sub
    Private Sub SimpleButton2_Click_1(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Dim mess As String
        Dim nam As MySqlCommand = SQLConnection.CreateCommand
        nam.CommandText = "select fullname from db_pegawai where employeecode = '" & SimpleButton2.Text & "'"
        Dim nama As String = CStr(nam.ExecuteScalar)
        mess = CType(MsgBox("Are you sure to change " & nama & " status with Employee Code " & SimpleButton2.Text & " to be 'Terminated' ?", MsgBoxStyle.YesNo, "Warning"), String)
        If CType(mess, Global.Microsoft.VisualBasic.MsgBoxResult) = vbYes Then
            Try
                Dim up As MySqlCommand = SQLConnection.CreateCommand
                up.CommandText = "update db_pegawai set" +
                                " Status = @stat" +
                                ", TerminateDate = @tmntdates" +
                                " where Employeecode = @ic"
                up.Parameters.AddWithValue("@ic", SimpleButton2.Text)
                up.Parameters.AddWithValue("@stat", "Terminated")
                up.Parameters.AddWithValue("@tmntdates", Date.Now)
                up.ExecuteNonQuery()
                MsgBox("Status from " & nama & " Is changed to be 'Terminated'", MsgBoxStyle.Information)
                Dim delsal As MySqlCommand = SQLConnection.CreateCommand
                delsal.CommandText = "delete from db_payrolldata where EmployeeCode = '" & SimpleButton2.Text & "'"
                delsal.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        Dim datatabl As New DataTable
        Dim sqlCommand As New MySqlCommand
        datatabl.Clear()
        Dim param As String = ""
        Try
            param = "and EmployeeCode='" + GridView1.GetFocusedRowCellValue("EmployeeCode").ToString() + "'"
        Catch ex As Exception
        End Try
        Try
            sqlCommand.CommandText = "SELECT EmployeeCode FROM db_pegawai WHERE 1=1 " + param.ToString()
            sqlCommand.Connection = SQLConnection
            Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(datatabl)
        Catch ex As Exception
            SQLConnection.Close()
            MsgBox(ex.Message)
        End Try
        If datatabl.Rows.Count > 0 Then
            SimpleButton2.Text = datatabl.Rows(0).Item(0).ToString
        End If
    End Sub
End Class