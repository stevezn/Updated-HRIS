Imports System.Globalization
Imports System.IO
Imports MySql.Data.MySqlClient

Public Class ClosePayroll
    Dim connectionString As String
    Dim SQLConnection As MySqlConnection = New MySqlConnection
    Dim oDt_sched As New DataTable()
    Dim tbl_par As New DataTable
    Dim log As Login

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

    Sub loaddata()
        Dim sqlcommand As New MySqlCommand
        sqlcommand.CommandText = "SELECT FullName, EmployeeCode From db_payrolldata"
        sqlcommand.Connection = SQLConnection
        Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
        Dim cb As New MySqlCommandBuilder(adapter)
        adapter.Fill(tbl_par)
        For index As Integer = 0 To tbl_par.Rows.Count - 1
            txtname.Properties.Items.Add(tbl_par.Rows(index).Item(0).ToString())
        Next
    End Sub

    Sub computesalary()
        Dim sqlcommand As New MySqlCommand
        sqlcommand.CommandType = CommandType.StoredProcedure
        sqlcommand.CommandText = "test"
        Dim p1 As New MySqlParameter
        p1.ParameterName = "@empcode"
        p1.Value = txtempcode.Text
        sqlcommand.Parameters.Add(p1)
        sqlcommand.Connection = SQLConnection
        Dim dt As New DataTable
        dt.Load(sqlcommand.ExecuteReader)
        list.GridControl1.DataSource = dt
    End Sub

    Dim list As New Lists

    Private Sub ClosePayroll_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        loaddata()
    End Sub

    Private Sub radiochoose_CheckedChanged(sender As Object, e As EventArgs) Handles radiochoose.CheckedChanged
        If radiochoose.Checked = True Then
            txtname.Enabled = True
            txtempcode.Enabled = False
        Else
            txtname.Enabled = False
            txtempcode.Enabled = False
        End If
    End Sub

    Sub nilaiot(emp As String)
        Dim as1 As MySqlCommand = SQLConnection.CreateCommand
        as1.CommandText = "select overtimehours from db_absensi where overtimehours != '' and tanggal between @date1 and @date1"
        as1.Parameters.AddWithValue("@date1", date1.Value.Date)
        as1.Parameters.AddWithValue("@date2", date2.Value.Date)
        Dim as11 As String = CStr(as1.ExecuteScalar)

        Dim as2 As MySqlCommand = SQLConnection.CreateCommand
        as2.CommandText = "select employeetype from db_pegawai where employeecode = '" & emp & "'"
        Dim as22 As String = CStr(as2.ExecuteScalar)

        Dim as3 As MySqlCommand = SQLConnection.CreateCommand
        as3.CommandText = "select overtimetype from db_overtime where employeecode = '" & emp & "'"
        Dim as33 As String = CStr(as3.ExecuteScalar)
    End Sub

    Private Sub txtname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtname.SelectedIndexChanged
        For index As Integer = 0 To tbl_par.Rows.Count - 1
            If txtname.SelectedItem Is tbl_par.Rows(index).Item(0).ToString Then
                txtempcode.Text = tbl_par.Rows(index).Item(1).ToString
            End If
        Next
    End Sub

    Dim lis As New Lists
    Dim basicsalary As Decimal
    Dim pphutang As Decimal

    Sub computingsalary(emp As String)
        ''find rangedate between start and end holiday
        'Dim dates1 As MySqlCommand = SQLConnection.CreateCommand
        'dates1.CommandText = "select startdate from db_holiday where startdate between @date1 and @date2"
        'dates1.Parameters.AddWithValue("@date1", date1.Value.Date)
        'dates1.Parameters.AddWithValue("@date2", date2.Value)
        'Dim realdate1 As String = CStr(dates1.ExecuteScalar)

        'Dim dates2 As MySqlCommand = SQLConnection.CreateCommand
        'dates2.CommandText = "select enddate from db_holiday where startdate between @date1 and @date2"
        'dates2.Parameters.AddWithValue("@date1", date1.Value.Date)
        'dates2.Parameters.AddWithValue("@date2", date2.Value)
        'Dim realdate2 As String = CStr(dates2.ExecuteScalar)

        'Dim sqlcommand0 As New MySqlCommand
        'sqlcommand0.CommandType = CommandType.StoredProcedure
        'sqlcommand0.CommandText = "rangedate"
        'Dim p1, p2 As New MySqlParameter
        'p1.ParameterName = "@date1"
        'p2.ParameterName = "@date2"
        'p1.Value = realdate1
        'p2.Value = realdate2
        'sqlcommand0.Parameters.Add(p1)
        'sqlcommand0.Parameters.Add(p2)
        'sqlcommand0.Connection = SQLConnection
        'Dim rangedate As String = CStr(sqlcommand0.ExecuteScalar)
        ''end

        'Dim aabsen As MySqlCommand = SQLConnection.CreateCommand
        'aabsen.CommandText = "select startdate from db_attrec where startdate between @date1 and @date2 and reason = 'Sakit' or reason = 'Izin'"
        'aabsen.Parameters.AddWithValue("@date1", date1.Value.Date)
        'aabsen.Parameters.AddWithValue("@date2", date2.Value)
        'Dim reala As String = CStr(aabsen.ExecuteScalar)

        'Dim babsen As MySqlCommand = SQLConnection.CreateCommand
        'babsen.CommandText = "Select enddate from db_attrec where enddate between @date1 And @date2 and reason = 'Sakit' or reason = 'Izin'"
        'babsen.Parameters.AddWithValue("@date1", date1.Value.Date)
        'babsen.Parameters.AddWithValue("@date2", date2.Value)
        'Dim realb As String = CStr(babsen.ExecuteScalar)

        'Dim sqlcommand1 As New MySqlCommand
        'sqlcommand1.CommandType = CommandType.StoredProcedure
        'sqlcommand1.CommandText = "rangedate"
        'Dim d1, d2 As New MySqlParameter
        'd1.ParameterName = "@date1"
        'd2.ParameterName = "@date2"
        'd1.Value = date1.Value
        'd2.Value = date2.Value
        'sqlcommand1.Parameters.Add(d1)
        'sqlcommand1.Parameters.Add(d2)
        'sqlcommand1.Connection = SQLConnection

        'Dim days As New DataSet
        'Dim daysAdp As New MySqlDataAdapter(sqlcommand1)

        'daysAdp.Fill(days)

        'Dim hslabsen As String = CStr(sqlcommand1.ExecuteScalar)
        'end

        ''find HK dates 
        'Dim jlhhk As MySqlCommand = SQLConnection.CreateCommand
        'jlhhk.CommandText = "Select tanggal from db_absensi where employeecode = @ec And tanggal between @date1 And @date2"
        'jlhhk.Parameters.AddWithValue("@ec", emp)
        'jlhhk.Parameters.AddWithValue("@date1", date1.Value.Date)
        'jlhhk.Parameters.AddWithValue("@date2", date2.Value)
        'Dim tggl As String = CStr(jlhhk.ExecuteScalar)
        ''end

        'find an employeetype from the employee
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "select employeetype from db_pegawai where EmployeeCode = '" & emp & "'"
        Dim emptype As String = CStr(query.ExecuteScalar)
        'end

        Dim q As MySqlCommand = SQLConnection.CreateCommand()
        q.CommandText = "select * from db_employeetype where emptype = '" & emptype & "'"

        'count HK
        'Dim a As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "select count(*) from db_absensi where Tanggal between @date1 and @date2 and EmployeeCode = '" & emp & "'"
        query.Parameters.Clear()
        query.Parameters.AddWithValue("@date1", date1.Value.Date)
        query.Parameters.AddWithValue("@date2", date2.Value)
        Dim hk As Integer = CInt(query.ExecuteScalar)

        'Dim a As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "select count(*) from db_absensi where Tanggal between @date1 and @date2 and EmployeeCode = '" & emp & "' and isHoliday = 1"
        query.Parameters.Clear()
        query.Parameters.AddWithValue("@date1", date1.Value.Date)
        query.Parameters.AddWithValue("@date2", date2.Value)
        Dim hkholiday As Integer = CInt(query.ExecuteScalar)

        Select Case LCase(emptype)
            Case "bulanan"
                query.CommandText = "insert into payroll2(pay_date, employee_code, employee_type, salary_component, salary_value) select @date, @emp, @types, 'Gapok', basicrate from db_payrolldata where EmployeeCode = @emp"
                query.Parameters.Clear()
                query.Parameters.AddWithValue("@types", "Bulanan")
                query.Parameters.AddWithValue("@date", DateTimePicker1.Value.Date)
                query.Parameters.AddWithValue("@emp", emp)
                query.ExecuteNonQuery()

                query.CommandText = "insert into payroll2(pay_date, employee_code, employee_type, salary_component, salary_value) select @date, @emp, @types, 'Overtime', sum(calc_overtime(pd.basicrate, a.OvertimeHours, a.isHoliday)) from db_payrolldata pd join db_absensi a on a.EmployeeCode = pd.EmployeeCode where a.EmployeeCode = @emp and a.OvertimeHours > 0 and a.Tanggal between @d1 and @d2"
                query.Parameters.Clear()
                query.Parameters.AddWithValue("@types", "Bulanan")
                query.Parameters.AddWithValue("@date", DateTimePicker1.Value.Date)
                query.Parameters.AddWithValue("@emp", emp)
                query.Parameters.AddWithValue("@d1", date1.Value.Date)
                query.Parameters.AddWithValue("@d2", date2.Value.Date)
                query.ExecuteNonQuery()

                'query.CommandText = "select as1 from db_addition where employeecode = @emp"
                'query.Parameters.Clear()
                'query.Parameters.AddWithValue("@emp", emp)
                'Dim quers As String = CStr(query.ExecuteScalar)

                'query.CommandText = "insert into payroll2(pay_date, employee_code, employee_type, salary_component, salary_value) select @date, @emp, @types, @types2, calc_addsubx(a.amount, a.as1, b.basicrate) from db_addition a, db_payrolldata b where a.EmployeeCode = @emp and a.period between @d1 and a.until"
                'query.Parameters.Clear()
                'query.Parameters.AddWithValue("@types", "Bulanan")
                'query.Parameters.AddWithValue("@date", DateTimePicker1.Value.Date)
                'query.Parameters.AddWithValue("@emp", emp)
                'query.Parameters.AddWithValue("@d1", date1.Value.Date)
                'query.Parameters.AddWithValue("@types2", quers)
                'query.ExecuteNonQuery()

                'query.CommandText = "insert into payroll2(pay_date, employee_code, employee_type, salary_component, salary_value) select @date, @emp, @types, 'Warning Fine', b.basicrate - a.amount from db_warning a, db_payrolldata b where a.employeecode = @emp and a.paymentdate = @d1"
                'query.Parameters.Clear()
                'query.Parameters.AddWithValue("@types", "Bulanan")
                'query.Parameters.AddWithValue("@date", DateTimePicker1.Value.Date)
                'query.Parameters.AddWithValue("@emp", emp)
                'query.Parameters.AddWithValue("@d1", date1.Value.Date)
                'query.ExecuteNonQuery()

                'query.CommandText = "insert into payroll2(pay_date, employee_code, employee_type, salary_component, salary_value) select @date, @emp, @types, 'Loans', a.basicrate - b.paymentpermonth from db_payrolldata a, db_loan b where a.EmployeeCode = @emp and b.frommonths between @d1 and @d2"
                'query.Parameters.Clear()
                'query.Parameters.AddWithValue("@types", "Bulanan")
                'query.Parameters.AddWithValue("@date", DateTimePicker1.Value.Date)
                'query.Parameters.AddWithValue("@emp", emp)
                'query.Parameters.AddWithValue("@d1", date1.Value.Date)
                'query.Parameters.AddWithValue("@d2", date2.Value.Date)
                'query.ExecuteNonQuery()

            Case "harian"
                query.CommandText = "insert into payroll2(pay_date, employee_code, employee_type, salary_component, salary_value) select @date, @emp, @types, 'Gapok', @hk * basicrate / 30 from db_payrolldata where EmployeeCode = @emp"
                query.Parameters.Clear()
                query.Parameters.AddWithValue("@types", "Harian")
                query.Parameters.AddWithValue("@date", DateTimePicker1.Value.Date)
                query.Parameters.AddWithValue("@hk", hk)
                query.Parameters.AddWithValue("@emp", emp)
                query.ExecuteNonQuery()

                query.CommandText = "insert into payroll2(pay_date, employee_code, employee_type, salary_component, salary_value) select @date, @emp, @types, 'Overtime', sum(calc_overtime(pd.basicrate, a.OvertimeHours, a.isHoliday)) from db_payrolldata pd join db_absensi a on a.EmployeeCode = pd.EmployeeCode where a.EmployeeCode = @emp and a.OvertimeHours > 0 and a.Tanggal between @d1 and @d2"
                query.Parameters.Clear()
                query.Parameters.AddWithValue("@types", "Harian")
                query.Parameters.AddWithValue("@date", DateTimePicker1.Value.Date)
                query.Parameters.AddWithValue("@emp", emp)
                query.Parameters.AddWithValue("@d1", date1.Value.Date)
                query.Parameters.AddWithValue("@d2", date2.Value.Date)
                query.ExecuteNonQuery()
            Case "borongan"
                query.CommandText = "insert into payroll2(pay_date, employee_code, employee_type, salary_component, salary_value) select @date, @emp, @types, 'Borong', calc_borongan(Quantity, Target, Target1, Target2, Target3, Amount, Amount1, Amount2, Amount3) from db_borongan where Employeecode = @emp and tanggal between @d1 and @d2"
                query.Parameters.Clear()
                query.Parameters.AddWithValue("@types", "Borongan")
                query.Parameters.AddWithValue("@date", DateTimePicker1.Value.Date)
                query.Parameters.AddWithValue("@emp", emp)
                query.Parameters.AddWithValue("@d1", date1.Value.Date)
                query.Parameters.AddWithValue("@d2", date2.Value.Date)
                query.ExecuteNonQuery()
        End Select
        Try
            query.CommandText = "select employeetype from db_pegawai where employeecode = @emp"
            Dim quer As String = CStr(query.ExecuteScalar)

            query.CommandText = "insert into payroll2(pay_date, employee_code, employee_type, salary_component, salary_value) select @date, @emp, @types, 'Tunjangan', allowance from db_payrolldata where EmployeeCode = @emp"
            query.Parameters.Clear()
            query.Parameters.AddWithValue("@types", quer)
            query.Parameters.AddWithValue("@date", DateTimePicker1.Value.Date)
            query.Parameters.AddWithValue("@emp", emp)
            query.ExecuteNonQuery()

            query.CommandText = "insert into payroll2(pay_date, employee_code, employee_type, salary_component, salary_value) select @date, @emp, @types, 'Uang Makan', mealrate from db_payrolldata where EmployeeCode = @emp"
            query.Parameters.Clear()
            query.Parameters.AddWithValue("@types", quer)
            query.Parameters.AddWithValue("@date", DateTimePicker1.Value.Date)
            query.Parameters.AddWithValue("@emp", emp)
            query.ExecuteNonQuery()

            query.CommandText = "insert into payroll2(pay_date, employee_code, employee_type, salary_component, salary_value) select @date, @emp, @types, 'Transportasi', transport from db_payrolldata where EmployeeCode = @emp"
            query.Parameters.Clear()
            query.Parameters.AddWithValue("@types", quer)
            query.Parameters.AddWithValue("@date", DateTimePicker1.Value.Date)
            query.Parameters.AddWithValue("@emp", emp)
            query.ExecuteNonQuery()

            query.CommandText = "insert into payroll2(pay_date, employee_code, employee_type, salary_component, salary_value) select @date, @emp, @types, 'Others', amount from db_addition where EmployeeCode = @emp"
            query.Parameters.Clear()
            query.Parameters.AddWithValue("@types", quer)
            query.Parameters.AddWithValue("@date", DateTimePicker1.Value.Date)
            query.Parameters.AddWithValue("@emp", emp)
            query.ExecuteNonQuery()

            query.CommandText = "select as1 from db_addition where employeecode = @emp"
            query.Parameters.Clear()
            query.Parameters.AddWithValue("@emp", emp)
            Dim quers As String = CStr(query.ExecuteScalar)

            query.CommandText = "insert into payroll2(pay_date, employee_code, employee_type, salary_component, salary_value) select @date, @emp, @types, @types2, calc_addsubx(a.amount, a.as1, b.basicrate) from db_addition a, db_payrolldata b where a.EmployeeCode = @emp and a.period between @d1 and a.until"
            query.Parameters.Clear()
            query.Parameters.AddWithValue("@types", quer)
            query.Parameters.AddWithValue("@date", DateTimePicker1.Value.Date)
            query.Parameters.AddWithValue("@emp", emp)
            query.Parameters.AddWithValue("@d1", date1.Value.Date)
            query.Parameters.AddWithValue("@types2", quers)
            query.ExecuteNonQuery()

            query.CommandText = "insert into payroll2(pay_date, employee_code, employee_type, salary_component, salary_value) select @date, @emp, @types, 'Warning Fine', b.basicrate - a.amount from db_warning a, db_payrolldata b where a.employeecode = @emp and a.paymentdate = @date"
            query.Parameters.Clear()
            query.Parameters.AddWithValue("@types", quer)
            query.Parameters.AddWithValue("@date", DateTimePicker1.Value.Date)
            query.Parameters.AddWithValue("@emp", emp)
            ' query.Parameters.AddWithValue("@d1", date1.Value.Date)
            query.ExecuteNonQuery()

            query.CommandText = "insert into payroll2(pay_date, employee_code, employee_type, salary_component, salary_value) select @date, @emp, @types, 'Loans', a.basicrate - b.paymentpermonth from db_payrolldata a, db_loan b where a.EmployeeCode = @emp and b.frommonths = @date"
            query.Parameters.Clear()
            query.Parameters.AddWithValue("@types", quer)
            query.Parameters.AddWithValue("@date", DateTimePicker1.Value.Date)
            query.Parameters.AddWithValue("@emp", emp)
            'query.Parameters.AddWithValue("@d1", date1.Value.Date)
            'query.Parameters.AddWithValue("@d2", date2.Value.Date)
            query.ExecuteNonQuery()

            Dim sqlCommand As New MySqlCommand
            sqlCommand.CommandText = "Select employee_code, salary_component, salary_value, employee_type from payroll2"
            sqlCommand.Connection = SQLConnection
            Dim dt As New DataTable
            dt.Load(sqlCommand.ExecuteReader)
            lis.GridControl1.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub checkloan()
        Try
            Dim dtb As Date
            DateTimePicker1.Format = DateTimePickerFormat.Custom
            DateTimePicker1.CustomFormat = "yyyy-MM-dd"
            dtb = DateTimePicker1.Value
            Dim query As MySqlCommand = SQLConnection.CreateCommand
            query.CommandText = "select monthx from db_loanlist where monthx = @date1"
            query.Parameters.AddWithValue("@date1", dtb.ToString("yyyy-MM-dd"))
            Dim quer As Date = CDate(query.ExecuteScalar)
            If CDate(dtb.ToString("yyyy-MM-dd")) = quer.Date Then
                Dim cmd As MySqlCommand = SQLConnection.CreateCommand
                cmd.CommandText = "update db_loanlist set Realisasi = 'PAID' where monthx = '" & dtb.ToString("yyyy-MM-dd") & "'"
                cmd.ExecuteNonQuery()
                MsgBox("Loan subtracted for this month")
            End If
        Catch ex As Exception
            MsgBox("loan" & ex.Message)
        End Try
    End Sub

    Private Sub processpayroll()
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "truncate payroll2"
        query.ExecuteNonQuery()

        If payrollcheck.Checked = True Then
            If radiochoose.Checked = True Then
                computingsalary(txtempcode.Text)
            Else
                Dim cmd As MySqlCommand = SQLConnection.CreateCommand()
                cmd.CommandText = "select employeecode from db_payrolldata"
                Dim adp As New MySqlDataAdapter(cmd)
                Dim ds As New DataSet
                adp.Fill(ds)
                For Each tbl As DataTable In ds.Tables
                    For Each row As DataRow In tbl.Rows
                        computingsalary(CType(row.Item("EmployeeCode"), String))
                    Next
                Next
            End If
        ElseIf thrcheck.Checked = True Then
        ElseIf bonuscheck.Checked = True Then
            loaddata()
        ElseIf checkovertime.Checked = True Then
        ElseIf payrollcheck.Checked = True And thrcheck.Checked = True And bonuscheck.Checked = True Then
            loaddata()
        ElseIf payrollcheck.Checked = True And thrcheck.Checked = True And bonuscheck.Checked = False Then
        ElseIf payrollcheck.Checked = True And thrcheck.Checked = False And bonuscheck.Checked = True Then
            loaddata()
        ElseIf payrollcheck.Checked = False And thrcheck.Checked = True And bonuscheck.Checked = True Then
            loaddata()
        ElseIf payrollcheck.Checked = True And thrcheck.Checked = False And bonuscheck.Checked = True Then
        End If
    End Sub

    Private Sub btnProcess_Click(sender As Object, e As EventArgs) Handles btnProcess.Click
        If radiochoose.Checked = True And txtname.Text = "" Then
            MsgBox("Please insert the employee name you wanted to display")
        ElseIf Date1.Value.Date > date2.Value.Date Then
            MsgBox("Wrong Dates, please do check again")
        Else
            If lis Is Nothing OrElse lis.IsDisposed OrElse lis.MinimizeBox Then
                lis.Close()
                lis = New Lists
            End If
            Close()
            checkloan()
            processpayroll()
            lis.Show()
        End If
        'If payrollcheck.Checked = False And thrcheck.Checked = False And bonuscheck.Checked = False And checkovertime.Checked = False Then
        '    MsgBox("Please choose the Checkbox to processing")
        'Else
        '    If lis Is Nothing OrElse lis.IsDisposed OrElse lis.MinimizeBox Then
        '        lis.Close()
        '        lis = New Lists
        '    End If
        '    processpayroll()
        '    lis.Show()
    End Sub

    Private Sub radioloadall_CheckedChanged(sender As Object, e As EventArgs) Handles radioloadall.CheckedChanged
        If radioloadall.Checked = True Then
            txtname.Text = ""
            txtempcode.Text = ""
        End If
    End Sub
End Class