Imports System.IO
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid

Public Class Criteria
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

    Private Sub Criteria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        Try
            Dim query As MySqlCommand = SQLConnection.CreateCommand
            query.CommandText = "select status from db_tmpname"
            Dim quer2 As String = CType(query.ExecuteScalar, String)
            Label1.Text = quer2.ToString
            If Label1.Text = "Candidates List" Then
                CheckEdit1.Text = "Id Recruitment"
            Else
                CheckEdit1.Text = "Employee Code"
            End If
        Catch ex As Exception
        End Try
        autofill()
        DateTimePicker1.Enabled = True
        DateTimePicker2.Enabled = True
    End Sub

    Sub autofill()
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim da As New MySqlDataAdapter("select EmployeeCode from db_pegawai", SQLConnection)
        da.Fill(dt)
        Dim r As DataRow
        textedit2.AutoCompleteCustomSource.Clear()
        For Each r In dt.Rows
            textedit2.AutoCompleteCustomSource.Add(r.Item(0).ToString)
        Next
    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit1.CheckedChanged
        If Label1.Text = "Candidates List" Then
            If CheckEdit1.Checked = True Then
                TextEdit1.Enabled = True
                TextEdit1.Text = ""
                SimpleButton1.Enabled = True
                CheckEdit2.Checked = False
                CheckEdit3.Checked = False
                CheckEdit3.Enabled = False
            Else
                TextEdit1.Enabled = False
                SimpleButton1.Enabled = False
                CheckEdit3.Enabled = True
            End If
        Else
            If CheckEdit1.Checked = True Then
                TextEdit1.Enabled = True
                TextEdit1.Text = ""
                SimpleButton1.Enabled = True
                CheckEdit2.Checked = False
            Else
                TextEdit1.Enabled = False
                SimpleButton1.Enabled = False
            End If
        End If
    End Sub

    Private Sub CheckEdit2_CheckedChanged_1(sender As Object, e As EventArgs) Handles CheckEdit2.CheckedChanged
        If CheckEdit2.Checked = True Then
            TextEdit2.Enabled = False
            SimpleButton2.Enabled = False
            CheckEdit1.Checked = False
        Else
            TextEdit2.Enabled = False
            SimpleButton2.Enabled = False
        End If
    End Sub

    Dim sel As New selectemp
    Dim sel1 As New selectcand

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Timer1.Start()
        If Label1.Text = "Candidates List" Then
            CheckEdit1.Text = "Id Recruitment"
            If sel1 Is Nothing OrElse sel1.IsDisposed OrElse sel1.MinimizeBox Then
                sel1.Close()
                sel1 = New selectcand
            End If
            sel1.Show()
        Else
            If sel Is Nothing OrElse sel.IsDisposed OrElse sel.MinimizeBox Then
                sel.Close()
                sel = New selectemp
            End If
            sel.Show()
        End If
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        Close()
    End Sub

    Private Sub TextEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit1.EditValueChanged
        Timer1.Stop()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            If Label1.Text = "Candidates List" Then
                Dim query As MySqlCommand = SQLConnection.CreateCommand
                query.CommandText = "select idrec from db_tmpname"
                Dim quer1 As String = CType(query.ExecuteScalar, String)
                TextEdit1.Text = quer1.ToString
            Else
                Dim query As MySqlCommand = SQLConnection.CreateCommand
                query.CommandText = "select employeecode from db_tmpname"
                Dim quer1 As String = CType(query.ExecuteScalar, String)
                TextEdit1.Text = quer1.ToString
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CheckEdit3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit3.CheckedChanged
        If CheckEdit3.Checked = True Then
            DateTimePicker1.Enabled = True
            DateTimePicker2.Enabled = True
        Else
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
        End If
    End Sub

    Dim rep As Reports

    Sub candidates(emp As String)
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "select IdRec, InterviewTImes as AppliedTimes, FullName, PlaceOfBirth, DateOfBirth, Address, Gender, Religion, PhoneNumber, IdNumber, Status, Reason, CreatedDate, ExpectedSalary from db_recruitment where idrec = @emp"
        query.Parameters.AddWithValue("@emp", emp)
        Dim dt As New DataTable
        dt.Load(query.ExecuteReader)
        rep.GridControl1.DataSource = dt
    End Sub

    Sub employee(emp As String)
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "select EmployeeCode, CompanyCode, FullName, Position as JobTitle, WorkDate as JoinDate, Gender, Religion, PhoneNumber from db_pegawai where employeecode = @emp"
        'And WorkDate between @date1 And @date2"
        query.Parameters.AddWithValue("@emp", emp)
        'query.Parameters.AddWithValue("@date1", DateTimePicker1.Value.Date)
        'query.Parameters.AddWithValue("@date2", DateTimePicker2.Value.Date)
        Dim dt As New DataTable
        dt.Load(query.ExecuteReader)
        rep.GridControl1.DataSource = dt
    End Sub

    Sub attendance(emp As String)
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "select EmployeeCode, FullName, Tanggal as Date, Shift, JamMulai as StartingHour, JamSelesai as EndedHour from db_absensi where EmployeeCode = @emp And tanggal between @date1 And @date2"
        query.Parameters.AddWithValue("@emp", emp)
        query.Parameters.AddWithValue("@date1", DateTimePicker1.Value.Date)
        query.Parameters.AddWithValue("@date2", DateTimePicker2.Value.Date)
        Dim dt As New DataTable
        dt.Load(query.ExecuteReader)
        rep.GridControl1.DataSource = dt
    End Sub

    Sub overtime(emp As String)
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "select EmployeeCode, FullName, Tanggal as Date, Shift, OvertimeType, OvertimeHours from db_absensi where EmployeeCode = @emp And tanggal between @date1 And @date2"
        query.Parameters.AddWithValue("@emp", emp)
        query.Parameters.AddWithValue("@date1", DateTimePicker1.Value.Date)
        query.Parameters.AddWithValue("@date2", DateTimePicker2.Value.Date)
        Dim dt As New DataTable
        dt.Load(query.ExecuteReader)
        rep.GridControl1.DataSource = dt
    End Sub

    Sub warning(emp As String)
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "select MemoNo, tgl as Date, EmployeeCode, FullName, WarningLevel, OffenseType, DescriptionOfInfraction as Description, Plan, Consequences from db_warning where employeecode = @emp And tgl between @date1 And @date2"
        query.Parameters.AddWithValue("@emp", emp)
        query.Parameters.AddWithValue("@date1", DateTimePicker1.Value.Date)
        query.Parameters.AddWithValue("@date2", DateTimePicker2.Value.Date)
        Dim dt As New DataTable
        dt.Load(query.ExecuteReader)
        rep.GridControl1.DataSource = dt
    End Sub

    Sub leavereq(emp As String)
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "select MemoNo, tgl as Date, EmployeeCode, FullName, Reason, StartDate, EndDate, TotalDays from db_attrec where employeecode = @emp And tgl between @date1 And @date2 and approvedstatus = 'Approved'"
        query.Parameters.AddWithValue("@emp", emp)
        query.Parameters.AddWithValue("@date1", DateTimePicker1.Value.Date)
        query.Parameters.AddWithValue("@date2", DateTimePicker2.Value.Date)
        Dim dt As New DataTable
        dt.Load(query.ExecuteReader)
        rep.GridControl1.DataSource = dt
    End Sub

    Sub others(emp As String)
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "select MemoNo, Tanggal as Date, EmployeeCode, Period, Until, Amount, As1 as AsAn, Reason from db_addition where employeecode = @emp And tanggal between @date1 And @date2"
        query.Parameters.AddWithValue("@emp", emp)
        query.Parameters.AddWithValue("@date1", DateTimePicker1.Value.Date)
        query.Parameters.AddWithValue("@date2", DateTimePicker2.Value.Date)
        Dim dt As New DataTable
        dt.Load(query.ExecuteReader)
        rep.GridControl1.DataSource = dt
    End Sub

    Sub loanlist(emp As String)
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "select EmployeeCode, FullName, ApprovedBy, Reason, Dates as Date, Date_format(FromMonths, '%M-%Y') as FromMonth, AmountOfLoan, Date_Format(CompletedOn, '%M-%Y') as CompletedPayment from db_loan where EmployeeCode = @emp and dates between @date1 and @date2"
        query.Parameters.AddWithValue("@emp", emp)
        query.Parameters.AddWithValue("@date1", DateTimePicker1.Value.Date)
        query.Parameters.AddWithValue("@date2", DateTimePicker2.Value.Date)
        Dim dt As New DataTable
        dt.Load(query.ExecuteReader)
        rep.GridControl1.DataSource = dt
    End Sub

    Sub loansummary(emp As String)
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "select EmployeeCode, FullName, AmountOfLoan, Month, Realisasi from db_loanlist where EmployeeCode = @emp"
        query.Parameters.AddWithValue("@emp", emp)
        Dim dt As New DataTable
        dt.Load(query.ExecuteReader)
        rep.GridControl1.DataSource = dt
    End Sub

    Sub payroll(emp As String)
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "select a.employee_code as EmployeeCode, b.FullName, a.salary_component as SalaryComponent, a.salary_value as SalaryValue, a.employee_type as EmployeeType from payroll2 a, db_pegawai b where a.employee_code = @emp and b.EmployeeCode = @emp and pay_date between @date1 and @date2"
        query.Parameters.AddWithValue("@emp", emp)
        query.Parameters.AddWithValue("@date1", DateTimePicker1.Value.Date)
        query.Parameters.AddWithValue("@date2", DateTimePicker2.Value.Date)
        Dim dt As New DataTable
        dt.Load(query.ExecuteReader)
        rep.GridControl1.DataSource = dt
    End Sub

    Sub premi(emp As String)
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "select EmployeeCode, CompanyCode, FullName, Tanggal as Date, Tasks, Machines, Quantity from db_borongan where employeecode = @emp and tanggal between @date1 and @date2"
        query.Parameters.AddWithValue("@emp", emp)
        query.Parameters.AddWithValue("@date1", DateTimePicker1.Value.Date)
        query.Parameters.AddWithValue("@date2", DateTimePicker2.Value.Date)
        Dim dt As New DataTable
        dt.Load(query.ExecuteReader)
        rep.GridControl1.DataSource = dt
    End Sub

    Sub absence(emp As String)
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "select EmployeeCode, FullName, Tanggal as Date, Shift, JamMulai as StartingHour, JamSelesai as EndedHour from db_absensi where EmployeeCode = @emp and JamMulai is null and JamSelesai is null and tanggal between @date1 and @date2"
        query.Parameters.AddWithValue("@emp", emp)
        query.Parameters.AddWithValue("@date1", DateTimePicker1.Value.Date)
        query.Parameters.AddWithValue("@date2", DateTimePicker2.Value.Date)
        Dim dt As New DataTable
        dt.Load(query.ExecuteReader)
        rep.GridControl1.DataSource = dt
    End Sub

    Sub terminate(emp As String)
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "select MemoNo, FullName, EmployeeCode, tgl as Dates, ApprovedBy, Reason, JobTitle, Status, Explanation from db_terminate where EmployeeCode = @emp and tgl between @date1 and @date2"
        query.Parameters.AddWithValue("@emp", emp)
        query.Parameters.AddWithValue("@date1", DateTimePicker1.Value.Date)
        query.Parameters.AddWithValue("@date2", DateTimePicker2.Value.Date)
        Dim dt As New DataTable
        dt.Load(query.ExecuteReader)
        rep.GridControl1.DataSource = dt
    End Sub

    Sub latesin(emp As String)
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "select EmployeeCode, FullName, Tanggal as Dates, Shift, timediff(Date_Format(JamMulai, '%H:%i:%s'), '08:00:00') as LateSignIn, timediff(Date_Format(JamSelesai, '%H:%i:%s'), '17:00:00') as LateSignOut from db_absensi where employeecode = @emp and tanggal between @date1 and @date2"
        query.Parameters.AddWithValue("@emp", emp)
        query.Parameters.AddWithValue("@date1", DateTimePicker1.Value.Date)
        query.Parameters.AddWithValue("@date2", DateTimePicker2.Value.Date)
        Dim dt As New DataTable
        dt.Load(query.ExecuteReader)
        rep.GridControl1.DataSource = dt
    End Sub

    Sub statuschange(emp As String)
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "select EmployeeCode, FullName, tgl as ChangeDate, ChangeType, JobTitle, OfficeLocation, Department, Grouping as Groups from db_statuschange where status = 'Approved' and employeecode = @emp and tanggal between @date1 and @date2"
        query.Parameters.AddWithValue("@emp", emp)
        query.Parameters.AddWithValue("@date1", DateTimePicker1.Value.Date)
        query.Parameters.AddWithValue("@date2", DateTimePicker2.Value.Date)
        Dim dt As New DataTable
        dt.Load(query.ExecuteReader)
        rep.GridControl1.DataSource = dt
    End Sub

    Sub pajak(emp As String)
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "select basicrate from db_payrolldata where employeecode = '" & emp & "'"
        Dim quer As String = CStr(query.ExecuteScalar)
        query.CommandText = "select allowance from db_payrolldata where employeecode = '" & emp & "'"
        Dim quer1 As String = CStr(query.ExecuteScalar)
        query.CommandText = "select PphStatus from db_pegawai where employeecode = '" & emp & "'"
        Dim quer2 As String = CStr(query.ExecuteScalar)

        query.CommandText = "select " & quer2 & " from db_setpayroll"
        Dim quer3 As String = CStr(query.ExecuteScalar)

        query.CommandText = "select a.Basicrate * b.jamkecelakaankerja / 100 from db_payrolldata a, db_setpayroll b where Employeecode = @emp"
        query.Parameters.Clear()
        query.Parameters.AddWithValue("@emp", emp)
        Dim quer5 As Integer = CInt(query.ExecuteScalar)

        query.CommandText = "select a.Basicrate * b.JaminanKematian / 100 from db_payrolldata a, db_setpayroll b where EmployeeCode = @emp"
        query.Parameters.Clear()
        query.Parameters.AddWithValue("@emp", emp)
        Dim quer6 As Int64 = CInt(query.ExecuteScalar)

        query.CommandText = "select basicrate + allowance from db_payrolldata where employeecode = @emp"
        query.Parameters.Clear()
        query.Parameters.AddWithValue("@emp", emp)
        Dim quer7 As String = CStr(query.ExecuteScalar)
        Dim quer77 As Integer = CInt(quer7) + quer5 + quer6

        query.CommandText = "select a.basicrate + a.allowance + (a.basicrate * b.jamkecelakaankerja / 100) + (a.basicrate * b.jaminankematian / 100) * b.biayajabatan / 100 from db_payrolldata a, db_setpayroll b where employeecode = @emp"
        query.Parameters.Clear()
        query.Parameters.AddWithValue("@emp", emp)
        Dim quer8 As String = CStr(query.ExecuteScalar)

        query.CommandText = "select a.basicrate * b.jaminanharitua / 100 from db_payrolldata a, db_setpayroll b where employeecode = @emp"
        query.Parameters.Clear()
        query.Parameters.AddWithValue("@emp", emp)
        Dim quer9 As String = CStr(query.ExecuteScalar)

        query.CommandText = "select a.basicrate * b.iuranpensiun / 100 from db_payrolldata a, db_setpayroll b where employeecode = @emp"
        query.Parameters.Clear()
        query.Parameters.AddWithValue("@emp", emp)
        Dim quer10 As String = CStr(query.ExecuteScalar)

        Dim nettobulan As Integer = CInt(quer77 - CInt(quer10))


        query.CommandText = "insert into db_hasil (EmployeeCode, GajiPokok, TunjanganLain, JKK, Jk, Bruto, BiayaJabatan, JHT, JaminanPensiun, NettoBulan, NettoTahun, Ptkp, pphbulan) " +
                            " select @Emp, @Gapok, @tunjanganlain, @jkk, @jk, @bruto, @biayajabatan, @jht, @jaminanpensiun, @nettobulan, @nettotahun, @ptkp, calc_pajak(a.BasicRate, b.JamKecelakaanKerja, b.JaminanKematian, a.Allowance, b.BiayaJabatan, a.MemilikiNpwp, b.JaminanHariTua, b.IuranPensiun, a.StatusWajibPajak) from db_payrolldata a, db_setpayroll b  where a.EmployeeCode = '" & emp & "'"
        query.Parameters.Clear()
        query.Parameters.AddWithValue("@emp", emp)
        query.Parameters.AddWithValue("@gapok", quer)
        query.Parameters.AddWithValue("@tunjanganlain", quer1)
        query.Parameters.AddWithValue("@jkk", quer5)
        query.Parameters.AddWithValue("@jk", quer6)
        query.Parameters.AddWithValue("@bruto", quer77)
        query.Parameters.AddWithValue("@biayajabatan", quer8)
        query.Parameters.AddWithValue("@jht", quer9)
        query.Parameters.AddWithValue("@jaminanpensiun", quer10)
        query.Parameters.AddWithValue("@nettobulan", nettobulan)
        query.Parameters.AddWithValue("@nettotahun", nettobulan * 12)
        query.Parameters.AddWithValue("@ptkp", quer3)
        query.ExecuteNonQuery()

        query.CommandText = "select a.EmployeeCode, b.FullName, a.GajiPokok, a.TunjanganLain, a.Jkk as JaminanKecelakaanKerja, a.Jk as JaminanKematian, a.Bruto, a.BiayaJabatan, a.JHT as JaminanHariTua, a.JaminanPensiun, a.NettoBulan as NettoPerBulan, a.NettoTahun as NettoPerTahun, a.Ptkp, a.pphbulan as PphPerBulan from db_hasil a, db_payrolldata b where a.employeecode = @emp and b.employeecode = @emp"
        query.Parameters.Clear()
        query.Parameters.AddWithValue("@emp", emp)
        Dim dt As New DataTable
        dt.Load(query.ExecuteReader)
        rep.GridControl1.DataSource = dt
    End Sub

    Sub proceed()
        If Label1.Text = "Candidates List" Then
            If CheckEdit1.Checked = True Then
                candidates(TextEdit1.Text)
            Else
                Dim cmd As MySqlCommand = SQLConnection.CreateCommand()
                cmd.CommandText = "Select IdRec, InterviewTImes As AppliedTimes, FullName, PlaceOfBirth, DateOfBirth, Address, Gender, Religion, PhoneNumber, IdNumber, Status, Reason, CreatedDate, ExpectedSalary from db_recruitment where CreatedDate between @date1 And @date2"
                cmd.Parameters.AddWithValue("@date1", DateTimePicker1.Value.Date)
                cmd.Parameters.AddWithValue("@date2", DateTimePicker2.Value.Date)
                Dim dt As New DataTable
                dt.Load(cmd.ExecuteReader)
                rep.GridControl1.DataSource = dt
            End If
        ElseIf Label1.Text = "Employee List" Then
            If CheckEdit1.Checked = True Then
                employee(TextEdit1.Text)
            Else
                Dim cmd As MySqlCommand = SQLConnection.CreateCommand
                cmd.CommandText = "Select EmployeeCode, CompanyCode, FullName, Position As JobTitle, WorkDate As JoinDate, Gender, Religion, PhoneNumber from db_pegawai"
                'where WorkDate between @date1 And @date2"
                'cmd.Parameters.AddWithValue("@date1", DateTimePicker1.Value.Date)
                'cmd.Parameters.AddWithValue("@date2", DateTimePicker2.Value.Date)
                Dim dt As New DataTable
                dt.Load(cmd.ExecuteReader)
                rep.GridControl1.DataSource = dt
            End If
        ElseIf Label1.Text = "Attendance List" Then
            If CheckEdit1.Checked = True Then
                attendance(TextEdit1.Text)
            Else
                Dim query As MySqlCommand = SQLConnection.CreateCommand
                query.CommandText = "Select EmployeeCode, FullName, Tanggal As Date, Shift, JamMulai As StartingHour, JamSelesai As EndedHour from db_absensi where tanggal between @date1 And @date2"
                query.Parameters.AddWithValue("@date1", DateTimePicker1.Value.Date)
                query.Parameters.AddWithValue("@date2", DateTimePicker2.Value.Date)
                Dim dt As New DataTable
                dt.Load(query.ExecuteReader)
                rep.GridControl1.DataSource = dt
            End If
        ElseIf Label1.Text = "Overtime List" Then
            If CheckEdit1.Checked = True Then
                overtime(TextEdit1.Text)
            Else
                Dim query As MySqlCommand = SQLConnection.CreateCommand
                query.CommandText = "Select EmployeeCode, FullName, Tanggal As Date, Shift, OvertimeType, OvertimeHours from db_absensi where tanggal between @date1 And @date2"
                query.Parameters.AddWithValue("@date1", DateTimePicker1.Value.Date)
                query.Parameters.AddWithValue("@date2", DateTimePicker2.Value.Date)
                Dim dt As New DataTable
                dt.Load(query.ExecuteReader)
                rep.GridControl1.DataSource = dt
            End If
        ElseIf Label1.Text = "Warning Notice" Then
            If CheckEdit1.Checked = True Then
                warning(TextEdit1.Text)
            Else
                Dim query As MySqlCommand = SQLConnection.CreateCommand
                query.CommandText = "Select MemoNo, tgl As Date, EmployeeCode, FullName, WarningLevel, OffenseType, DescriptionOfInfraction As Description, Plan, Consequences from db_warning where tgl between @date1 And @date2"
                query.Parameters.AddWithValue("@date1", DateTimePicker1.Value.Date)
                query.Parameters.AddWithValue("@date2", DateTimePicker2.Value.Date)
                Dim dt As New DataTable
                dt.Load(query.ExecuteReader)
                rep.GridControl1.DataSource = dt
            End If
        ElseIf Label1.Text = "Leave Request" Then
            If CheckEdit1.Checked = True Then
                leavereq(TextEdit1.Text)
            Else
                Dim query As MySqlCommand = SQLConnection.CreateCommand
                query.CommandText = "Select MemoNo, tgl As Date, EmployeeCode, FullName, Reason, StartDate, EndDate, TotalDays from db_attrec where tgl between @date1 And @date2 and Approvedstatus = 'Approved'"
                query.Parameters.AddWithValue("@date1", DateTimePicker1.Value.Date)
                query.Parameters.AddWithValue("@date2", DateTimePicker2.Value.Date)
                Dim dt As New DataTable
                dt.Load(query.ExecuteReader)
                rep.GridControl1.DataSource = dt
            End If
        ElseIf Label1.Text = "Others Income / Deductions" Then
            If CheckEdit1.Checked = True Then
                leavereq(TextEdit1.Text)
            Else
                Dim query As MySqlCommand = SQLConnection.CreateCommand
                query.CommandText = "Select MemoNo, Tanggal As Date, EmployeeCode, Period, Until, Amount, As1 As AsA, Reason from db_addition where tanggal between @date1 And @date2"
                query.Parameters.AddWithValue("@date1", DateTimePicker1.Value.Date)
                query.Parameters.AddWithValue("@date2", DateTimePicker2.Value.Date)
                Dim dt As New DataTable
                dt.Load(query.ExecuteReader)
                rep.GridControl1.DataSource = dt
            End If
        ElseIf Label1.Text = "Loan Lists" Then
            If CheckEdit1.Checked = True Then
                loanlist(TextEdit1.Text)
            Else
                Dim query As MySqlCommand = SQLConnection.CreateCommand
                query.CommandText = "Select EmployeeCode, FullName, ApprovedBy, Reason, Dates As Date, Date_Format(FromMonths, '%M-%Y') as FromMonth, AmountOfLoan, Date_Format(CompletedOn, '%M-%Y') As CompletedPayment from db_loan where dates between @date1 And @date2"
                query.Parameters.AddWithValue("@date1", DateTimePicker1.Value.Date)
                query.Parameters.AddWithValue("@date2", DateTimePicker2.Value.Date)
                Dim dt As New DataTable
                dt.Load(query.ExecuteReader)
                rep.GridControl1.DataSource = dt
            End If
        ElseIf Label1.Text = "Loan Summary" Then
            If CheckEdit1.Checked = True Then
                loansummary(TextEdit1.Text)
            Else
                Dim query As MySqlCommand = SQLConnection.CreateCommand
                query.CommandText = "Select EmployeeCode, FullName, AmountOfLoan, Date_Format(Monthx, '%M-%Y') as Month, Realisasi from db_loanlist"
                Dim dt As New DataTable
                dt.Load(query.ExecuteReader)
                rep.GridControl1.DataSource = dt
            End If
        ElseIf Label1.Text = "Payroll Sheet" Then
            If CheckEdit1.Checked = True Then
                payroll(TextEdit1.Text)
            Else
                Dim query As MySqlCommand = SQLConnection.CreateCommand
                query.CommandText = "Select a.employee_code as EmployeeCode, b.FullName, a.salary_component as SalaryComponent, a.salary_value as SalaryValue, a.Employee_type as EmployeeType from payroll2 a, db_pegawai b where a.pay_date between @date1 And @date2 and a.employee_code = b.EmployeeCode"
                query.Parameters.AddWithValue("@date1", DateTimePicker1.Value.Date)
                query.Parameters.AddWithValue("@date2", DateTimePicker2.Value.Date)
                Dim dt As New DataTable
                dt.Load(query.ExecuteReader)
                rep.GridControl1.DataSource = dt
            End If
        ElseIf Label1.Text = "Premi" Then
            If CheckEdit1.Checked = True Then
                premi(TextEdit1.Text)
            Else
                Dim query As MySqlCommand = SQLConnection.CreateCommand
                query.CommandText = "Select EmployeeCode, CompanyCode, FullName, Tanggal As Date, Tasks, Machines, Quantity from db_borongan where tanggal between @date1 And @date2"
                query.Parameters.AddWithValue("@date1", DateTimePicker1.Value.Date)
                query.Parameters.AddWithValue("@date2", DateTimePicker2.Value.Date)
                Dim dt As New DataTable
                dt.Load(query.ExecuteReader)
                rep.GridControl1.DataSource = dt
            End If
        ElseIf Label1.Text = "Lates Or Early Sign In/Out" Then
            If CheckEdit1.Checked = True Then
                latesin(TextEdit1.Text)
            Else
                Dim query As MySqlCommand = SQLConnection.CreateCommand
                query.CommandText = "select EmployeeCode, FullName, Tanggal as Dates, Shift, timediff(Date_Format(JamMulai, '%H:%i:%s'), '08:00:00') as LateSignIn, timediff(Date_Format(JamSelesai, '%H:%i:%s'), '17:00:00') as LateSignOut from db_absensi where tanggal between @date1 and @date2"
                query.Parameters.AddWithValue("@date1", DateTimePicker1.Value.Date)
                query.Parameters.AddWithValue("@date2", DateTimePicker2.Value.Date)
                Dim dt As New DataTable
                dt.Load(query.ExecuteReader)
                rep.GridControl1.DataSource = dt
            End If
        ElseIf Label1.Text = "Absences List" Then
            If CheckEdit1.Checked = True Then
                absence(TextEdit1.Text)
            Else
                Dim query As MySqlCommand = SQLConnection.CreateCommand
                query.CommandText = "Select EmployeeCode, FullName, Tanggal As Dates, Shift, JamMulai as StartingHour, JamSelesai as EndedHour from db_absensi where JamMulai is null and JamSelesai is null and tanggal between @date1 and @date2"
                query.Parameters.AddWithValue("@date1", DateTimePicker1.Value.Date)
                query.Parameters.AddWithValue("@date2", DateTimePicker2.Value.Date)
                Dim dt As New DataTable
                dt.Load(query.ExecuteReader)
                rep.GridControl1.DataSource = dt
            End If
        ElseIf Label1.Text = "Terminate Lists" Then
            If CheckEdit1.Checked = True Then
                terminate(TextEdit1.Text)
            Else
                Dim query As MySqlCommand = SQLConnection.CreateCommand
                query.CommandText = "select MemoNo, FullName, EmployeeCode, tgl as Dates, ApprovedBy, Reason, JobTitle, Status, Explanation from db_terminate where tgl between @date1 and @date2"
                query.Parameters.AddWithValue("@date1", DateTimePicker1.Value.Date)
                query.Parameters.AddWithValue("@date2", DateTimePicker2.Value.Date)
                Dim dt As New DataTable
                dt.Load(query.ExecuteReader)
                rep.GridControl1.DataSource = dt
            End If
        ElseIf Label1.Text = "Pajak" Then
            If CheckEdit1.Checked = True Then
                pajak(TextEdit1.Text)
            Else
                Dim cmd As MySqlCommand = SQLConnection.CreateCommand()
                cmd.CommandText = "select employeecode from db_payrolldata"
                Dim adp As New MySqlDataAdapter(cmd)
                Dim ds As New DataSet
                adp.Fill(ds)
                For Each tbl As DataTable In ds.Tables
                    For Each row As DataRow In tbl.Rows
                        pajak(CType(row.Item("EmployeeCode"), String))
                    Next
                Next
                Dim query As MySqlCommand = SQLConnection.CreateCommand
                query.CommandText = "select a.EmployeeCode, b.FullName, a.GajiPokok, a.TunjanganLain, a.Jkk as JaminanKecelakaanKerja, a.Jk as JaminanKematian, a.Bruto, a.BiayaJabatan, a.JHT as JaminanHariTua, a.JaminanPensiun, a.NettoBulan as NettoPerBulan, a.NettoTahun as NettoPerTahun, a.Ptkp, a.pphbulan as PphPerBulan from db_hasil a, db_payrolldata b where a.EmployeeCode = b.EmployeeCode"
                query.Parameters.Clear()
                Dim dt As New DataTable
                dt.Load(query.ExecuteReader)
                rep.GridControl1.DataSource = dt
            End If
        ElseIf Label1.Text = "Status Change" Then
            If CheckEdit1.Checked = True Then
                statuschange(TextEdit1.Text)
            Else
                Dim cmd As MySqlCommand = SQLConnection.CreateCommand
                cmd.CommandText = "select EmployeeCode, FullName, tgl as ChangeDate, ChangeType, JobTitle, OfficeLocation, Department, Grouping as Groups, ApprovedBy from db_statuschange where status = 'Approved'"
                cmd.Parameters.Clear()
                Dim dt As New DataTable
                dt.Load(cmd.ExecuteReader)
                rep.GridControl1.DataSource = dt
            End If
        End If
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "truncate db_tmpname"
        query.ExecuteNonQuery()
        query.CommandText = "insert into db_tmpname (status) values (@status)"
        query.Parameters.AddWithValue("@status", Label1.Text)
        query.ExecuteNonQuery()
        If rep Is Nothing OrElse rep.IsDisposed OrElse rep.MinimizeBox Then
            rep = New Reports
        End If
        proceed()
        rep.Show()
        Close()
    End Sub
End Class