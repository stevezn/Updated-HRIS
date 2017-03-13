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
        Else
            txtname.Enabled = False
        End If
    End Sub

    Sub nilaiot()
        Dim as1 As MySqlCommand = SQLConnection.CreateCommand
        as1.CommandText = "select overtimehours from db_absensi where overtimehours != '' and tanggal between @date1 and @date1"
        as1.Parameters.AddWithValue("@date1", date1.Value.Date)
        as1.Parameters.AddWithValue("@date2", date2.Value.Date)
        Dim as11 As String = CStr(as1.ExecuteScalar)

        Dim as2 As MySqlCommand = SQLConnection.CreateCommand
        as2.CommandText = ""


    End Sub

    Private Sub txtname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtname.SelectedIndexChanged
        For index As Integer = 0 To tbl_par.Rows.Count - 1
            If txtname.SelectedItem Is tbl_par.Rows(index).Item(0).ToString Then
                txtempcode.Text = tbl_par.Rows(index).Item(1).ToString
            End If
        Next
    End Sub

    Sub loadot(emp As String)
        If thrcheck.Checked = True Then
            Dim ot As MySqlCommand = SQLConnection.CreateCommand
            ot.CommandText = "select sum(hours) from db_overtime where tanggal between @date1 and @date2 and employeecode = '" & emp & "'"
            ot.Parameters.AddWithValue("@date1", date1.Value.Date)
            ot.Parameters.AddWithValue("@date2", date2.Value)
            Dim tot As Integer = CInt(ot.ExecuteScalar)
            Dim meetholiday As MySqlCommand = SQLConnection.CreateCommand
            meetholiday.CommandText = "select startdate from db_holiday"
            Dim result As String = CStr(meetholiday.ExecuteScalar)
            Dim inholiday As MySqlCommand = SQLConnection.CreateCommand
            inholiday.CommandText = "select sum(hours) from db_overtime a where a.employeecode = '" & emp & " and a.tanggal in (select b.startdate from db_holiday b where b.startdate between @date1 and @date2)"
            inholiday.Parameters.AddWithValue("@date1", date1.Value.Date)
            inholiday.Parameters.AddWithValue("@date2", date2.Value)
            Dim resin As Integer = CInt(inholiday.ExecuteScalar)
            Dim outholiday As MySqlCommand = SQLConnection.CreateCommand
            outholiday.CommandText = "select sum(hours) from db_overtime a where a.employeecode = '" & emp & " and a.tanggal not in (select b.startdate from db_holiday b where b.startdate between @date1 and @date2)"
            outholiday.Parameters.AddWithValue("@date1", date1.Value.Date)
            outholiday.Parameters.AddWithValue("@date2", date2.Value)
            Dim resout As Integer = CInt(outholiday.ExecuteScalar)
            Dim gaji As MySqlCommand = SQLConnection.CreateCommand
            gaji.CommandText = "select basicrate from db_payrolldata where employeecode = '" & emp & "'"
            Dim exegaji As Integer = CInt(gaji.ExecuteScalar)
            Dim otin, otout, otmix As Integer
            Dim pay, temp, totot2, tempo, value1, value2, pay2, value3 As Integer
            pay = CInt(exegaji / 173)
            pay2 = pay * 3
            If resin > 0 And resin < 8 Then
                tempo = pay * resin * 2
                value1 = tempo
                totot2 = value1
            ElseIf resin = 8 Then
                temp = pay * 3
                tempo = temp * resin - pay * 3
                value2 = tempo
                totot2 = value2 - pay2 - pay
            ElseIf resin > 8 Then
                temp = pay * 4
                tempo = temp * resin - pay * 4
                value3 = tempo
                totot2 = value3 - value2 - value1
            End If
            otin = totot2
            Dim pay1, temp1, totot, tempo1, value11, value21, pay21 As Integer
            pay1 = CInt(exegaji / 173)
            pay21 = CInt(pay1 * 1.5)
            If resout = 1 Then
                tempo1 = CInt(pay1 * 1.5)
                value11 = tempo1
                totot = value1
            ElseIf resout > 1 Then
                temp1 = pay1 * 2
                tempo1 = temp1 * resout - pay1 * 2
                value21 = tempo1
                totot = value21 + pay21
            End If
            otout = totot
            otmix = otin + otout
        End If
    End Sub

    Dim lis As New Lists
    Dim basicsalary As Decimal
    Dim pphutang As Decimal

    Sub computingsalary(emp As String)
        'find rangedate between start and end holiday
        Dim dates1 As MySqlCommand = SQLConnection.CreateCommand
        dates1.CommandText = "select startdate from db_holiday where startdate between @date1 and @date2"
        dates1.Parameters.AddWithValue("@date1", date1.Value.Date)
        dates1.Parameters.AddWithValue("@date2", date2.Value)
        Dim realdate1 As String = CStr(dates1.ExecuteScalar)

        Dim dates2 As MySqlCommand = SQLConnection.CreateCommand
        dates2.CommandText = "select enddate from db_holiday where startdate between @date1 and @date2"
        dates2.Parameters.AddWithValue("@date1", date1.Value.Date)
        dates2.Parameters.AddWithValue("@date2", date2.Value)
        Dim realdate2 As String = CStr(dates2.ExecuteScalar)

        Dim sqlcommand0 As New MySqlCommand
        sqlcommand0.CommandType = CommandType.StoredProcedure
        sqlcommand0.CommandText = "rangedate"
        Dim p1, p2 As New MySqlParameter
        p1.ParameterName = "@date1"
        p2.ParameterName = "@date2"
        p1.Value = realdate1
        p2.Value = realdate2
        sqlcommand0.Parameters.Add(p1)
        sqlcommand0.Parameters.Add(p2)
        sqlcommand0.Connection = SQLConnection
        Dim rangedate As String = CStr(sqlcommand0.ExecuteScalar)
        'end

        Dim aabsen As MySqlCommand = SQLConnection.CreateCommand
        aabsen.CommandText = "select startdate from db_attrec where startdate between @date1 and @date2 and reason = 'Sakit' or reason = 'Izin'"
        aabsen.Parameters.AddWithValue("@date1", date1.Value.Date)
        aabsen.Parameters.AddWithValue("@date2", date2.Value)
        Dim reala As String = CStr(aabsen.ExecuteScalar)

        Dim babsen As MySqlCommand = SQLConnection.CreateCommand
        babsen.CommandText = "Select enddate from db_attrec where enddate between @date1 And @date2 and reason = 'Sakit' or reason = 'Izin'"
        babsen.Parameters.AddWithValue("@date1", date1.Value.Date)
        babsen.Parameters.AddWithValue("@date2", date2.Value)
        Dim realb As String = CStr(babsen.ExecuteScalar)

        Dim sqlcommand1 As New MySqlCommand
        sqlcommand1.CommandType = CommandType.StoredProcedure
        sqlcommand1.CommandText = "rangedate"
        Dim d1, d2 As New MySqlParameter
        d1.ParameterName = "@date1"
        d2.ParameterName = "@date2"
        d1.Value = reala
        d2.Value = realb
        sqlcommand1.Parameters.Add(d1)
        sqlcommand1.Parameters.Add(d2)
        sqlcommand1.Connection = SQLConnection
        Dim hslabsen As String = CStr(sqlcommand1.ExecuteScalar)
        'end

        'find HK dates 
        Dim jlhhk As MySqlCommand = SQLConnection.CreateCommand
        jlhhk.CommandText = "Select tanggal from db_absensi where employeecode = @ec And tanggal between @date1 And @date2"
        jlhhk.Parameters.AddWithValue("@ec", emp)
        jlhhk.Parameters.AddWithValue("@date1", date1.Value.Date)
        jlhhk.Parameters.AddWithValue("@date2", date2.Value)
        Dim tggl As String = CStr(jlhhk.ExecuteScalar)
        'end

        'find an employeetype from the employee
        Dim names As MySqlCommand = SQLConnection.CreateCommand
        names.CommandText = "select employeetype from db_pegawai where EmployeeCode = '" & emp & "'"
        Dim name As String = CStr(names.ExecuteScalar)
        'end

        Dim q As MySqlCommand = SQLConnection.CreateCommand()
        q.CommandText = "select * from db_employeetype where emptype = '" & name & "'"

        'count HK
        Dim a As MySqlCommand = SQLConnection.CreateCommand
        a.CommandText = "select count(*) from db_absensi where Tanggal between @date1 and @date2 and EmployeeCode = '" & emp & "'"
        a.Parameters.AddWithValue("@date1", date1.Value.Date)
        a.Parameters.AddWithValue("@date2", date2.Value)
        Dim hk As Integer = CInt(a.ExecuteScalar)
        Dim subtract As MySqlCommand = SQLConnection.CreateCommand
        subtract.CommandText = "select a.basicrate + a.allowance + a.incentives + a.mealrate + a.transport - (a.basicrate * b.bpjs / 100) - (a.basicrate * b.JamKecelakaanKerja/100) - (a.basicrate * b.JaminanKesehatan / 100) - (a.basicrate * b.iuranpensiun / 100) - (a.basicrate * b.JaminanHariTua / 100) - (a.basicrate * b.BiayaJabatan / 100) -( a.basicrate * b.lates / 100) - (a.basicrate * b.JaminanKematian / 100) as hasil from db_payrolldata a, db_setpayroll b where a.EmployeeCode = '" & emp & "'"
        Dim subx As Integer = CInt(subtract.ExecuteScalar)
        Dim empcode As MySqlCommand = SQLConnection.CreateCommand
        empcode.CommandText = "select employeecode from db_payrolldata"
        Dim ec As String = CStr(empcode.ExecuteScalar)
        Dim basrate As MySqlCommand = SQLConnection.CreateCommand
        basrate.CommandText = "select basicrate from db_payrolldata where EmployeeCode = '" & emp & "'"
        Dim basicrate As Integer = CInt(basrate.ExecuteScalar)
        Dim salaryperyear As Integer = basicrate * 12
        Dim netto As MySqlCommand = SQLConnection.CreateCommand
        netto.CommandText = "select basicrate + allowance + incentives + mealrate + transport as netto from db_payrolldata where EmployeeCode = '" & emp & "'"
        Dim net As Integer = CInt(netto.ExecuteScalar)
        Dim realnetto As Integer = net * 12
        Dim deduct As MySqlCommand = SQLConnection.CreateCommand
        deduct.CommandText = "select a.basicrate - a.basicrate * b.bpjs / 100 - a.basicrate * b.JamKecelakaanKerja / 100 - a.basicrate * b.JaminanKesehatan / 100 - a.basicrate * b.IuranPensiun / 100 - a.basicrate * b.JaminanHariTua / 100 - a.basicrate * b.BiayaJabatan / 100 - a.basicrate * lates/ 100 - a.basicrate * b.JaminanKematian/100 from db_payrolldata a, db_setpayroll b where a.EmployeeCode = '" & emp & "'"
        Dim gross As Integer = CInt(deduct.ExecuteScalar)
        Dim ptkp As MySqlCommand = SQLConnection.CreateCommand
        ptkp.CommandText = "select StatusWajibPajak from db_payrolldata where EmployeeCode = '" & emp & "'"
        Dim wajibpajak As String = CStr(ptkp.ExecuteScalar)
        Dim hasilptkp As Integer
        If wajibpajak = "Tidak Kawin, Tanpa Tanggungan" Then
            hasilptkp = 54000000
        ElseIf wajibpajak = "Tidak Kawin, Tanggungan 1" Then
            hasilptkp = 58500000
        ElseIf wajibpajak = "Tidak Kawin, Tanggungan 2" Then
            hasilptkp = 63000000
        ElseIf wajibpajak = "Tidak Kawin, Tanggungan 3" Then
            hasilptkp = 67500000
        ElseIf wajibpajak = "Kawin, Tanpa Tanggungan" Then
            hasilptkp = 58500000
        ElseIf wajibpajak = "Kawin, Tanggungan 1" Then
            hasilptkp = 63000000
        ElseIf wajibpajak = "Kawin, Tanggungan 2" Then
            hasilptkp = 67500000
        ElseIf wajibpajak = "Kawin, Tanggungan 3" Then
            hasilptkp = 112500000
        ElseIf wajibpajak = "Kawin, Penghasilan Istri Dan Suami Digabung" Then
            hasilptkp = 117000000
        ElseIf wajibpajak = "Kawin, Penghasilan Digabung Tanggungan 1" Then
            hasilptkp = 121500000
        ElseIf wajibpajak = "Kawin, Penghasilan Digabung Tanggungan 2" Then
            hasilptkp = 126000000
        End If

        Dim pkpajak As Decimal = realnetto - hasilptkp
        Dim tmp As Decimal

        Dim npwp As MySqlCommand = SQLConnection.CreateCommand
        npwp.CommandText = "select memilikinpwp from db_payrolldata where EmployeeCode = '" & emp & "'"
        Dim hasilnpwp As String = CStr(npwp.ExecuteScalar)
        If hasilnpwp = "Yes" Then
            If salaryperyear < 50000000 Then
                pphutang = pkpajak * 5 / 100
            ElseIf salaryperyear > 50000000 Then
                pphutang = pkpajak * 15 / 100
            ElseIf salaryperyear > 250000000 Then
                pphutang = pkpajak * 25 / 100
            Else
                pphutang = pkpajak * 30 / 100
            End If
        ElseIf hasilnpwp = "No" Then
            If salaryperyear < 5000000 Then
                tmp = pkpajak * 5 / 100
                pphutang = tmp * 120 / 100
            ElseIf salaryperyear > 50000000 Then
                tmp = pkpajak * 15 / 100
                pphutang = tmp * 120 / 100
            ElseIf salaryperyear > 250000000 Then
                tmp = pkpajak * 25 / 100
                pphutang = tmp * 120 / 100
            Else
                tmp = pkpajak * 30 / 100
                pphutang = tmp * 120 / 100
            End If
        End If
        Dim adp As New MySqlDataAdapter(q)
        Dim ds As New DataSet
        Dim income As Integer
        adp.Fill(ds)
        If ds.Tables.Count = 1 Then
            If ds.Tables(0).Rows.Count = 1 Then
                Dim calc = ds.Tables(0).Rows(0).Item("calculation")
                If calc IsNot Nothing Then
                    calc = calc.replace("[hk]", hk)
                    calc = calc.Replace("[output]", "30")
                    calc = calc.replace("[salarypermonth]", subx)
                    Dim q2 As MySqlCommand = SQLConnection.CreateCommand()
                    q2.CommandText = CType("select " & calc, String)
                    income = CInt(q2.ExecuteScalar)
                End If
            End If
        End If

        Dim ottype As MySqlCommand = SQLConnection.CreateCommand
        ottype.CommandText = "select overtimeType from db_absensi where employeecode = '" & emp & "'"
        Dim ot As String = CStr(ottype.ExecuteScalar)

        Dim othours As MySqlCommand = SQLConnection.CreateCommand
        othours.CommandText = "select overtimehours from db_absensi where EmployeeCode = '" & emp & "'"
        Dim hours As Integer = CInt(othours.ExecuteScalar)

        Dim type As MySqlCommand = SQLConnection.CreateCommand
        type.CommandText = "select OvertimeType from db_absensi where EmployeeCode = '" & emp & "'"
        Dim realtype As String = CStr(type.ExecuteScalar)

        Dim salary As MySqlCommand = SQLConnection.CreateCommand
        salary.CommandText = "select basicrate from db_payrolldata where EmployeeCode = '" & emp & "'"
        Dim realsalary As Integer = CInt(salary.ExecuteScalar)

        Dim tgl As MySqlCommand = SQLConnection.CreateCommand
        tgl.CommandText = "select tanggal from db_absensi where overtimehours != 0 and employeecode = '" & emp & "'"
        Dim tanggal As String = CStr(tgl.ExecuteScalar)

        Dim absen As MySqlCommand = SQLConnection.CreateCommand
        absen.CommandText = "select tanggal from db_absensi where tanggal between @date1 and @date2 and employeecode = '" & emp & "'"
        absen.Parameters.AddWithValue("@date1", date1.Value.Date)
        absen.Parameters.AddWithValue("@date2", date2.Value)
        Dim hasil As String = CStr(absen.ExecuteScalar)

        Dim hol As MySqlCommand = SQLConnection.CreateCommand
        hol.CommandText = "select startdate from db_holiday where startdate between @date1 and @date2"
        hol.Parameters.AddWithValue("@date1", date1.Value.Date)
        hol.Parameters.AddWithValue("@date2", date2.Value)
        Dim holiday As String = CStr(hol.ExecuteScalar)

        Dim otout, otin As Integer

        If rangedate <> tggl Then
            Dim pay, temp, totot, tempo, value1, value2, pay2 As Integer
            pay = CInt(realsalary / 173)
            pay2 = CInt(pay * 1.5)
            If hours = 1 Then
                tempo = CInt(pay * 1.5)
                value1 = tempo
                totot = value1
            ElseIf hours > 1 Then
                temp = pay * 2
                tempo = temp * hours - pay * 2
                value2 = tempo
                totot = value2 + pay2
            End If
            otin = totot
        Else
            Dim pay, temp, totot2, tempo, value1, value2, pay2, value3 As Integer
            pay = CInt(realsalary / 173)
            pay2 = pay * 3
            If hours > 0 And hours < 8 Then
                tempo = pay * hours * 2
                value1 = tempo
                totot2 = value1
            ElseIf hours = 8 Then
                temp = pay * 3
                tempo = temp * hours - pay * 3
                value2 = tempo
                totot2 = value2 - pay2 - pay
            ElseIf hours > 8 Then
                temp = pay * 4
                tempo = temp * hours - pay * 4
                value3 = tempo
                totot2 = value3 - value2 - value1
            End If
            otout = totot2
        End If
        Dim realot As Integer = otout + otin
        Dim collect As MySqlCommand = SQLConnection.CreateCommand
        collect.CommandText = "INSERT INTO db_hasil " +
                                "(EmployeeCode, SalaryPerYear, Netto, Gross, WajibPajak, pkpn, pphutang, income, Overtime) " +
                                " Values (@EmployeeCode, @SalaryPerYear, @Netto, @Gross, @WajibPajak, @pkpn, @pphutang, @income, @Overtime)"
        collect.Parameters.AddWithValue("@EmployeeCode", emp)
        collect.Parameters.AddWithValue("@SalaryPerYear", salaryperyear)
        collect.Parameters.AddWithValue("@Netto", net)
        collect.Parameters.AddWithValue("@Gross", gross)
        collect.Parameters.AddWithValue("@WajibPajak", wajibpajak)
        collect.Parameters.AddWithValue("@pkpn", pkpajak)
        collect.Parameters.AddWithValue("@pphutang", pphutang)
        collect.Parameters.AddWithValue("@income", income)
        collect.Parameters.AddWithValue("@Overtime", realot)
        collect.ExecuteNonQuery()
        Dim table As New DataTable
        Dim sqlCommand As New MySqlCommand
        sqlCommand.CommandText = "Select a.EmployeeCode, b.FullName, a.SalaryPerYear, a.Netto, a.Gross, a.WajibPajak as StatusWajibPajak, a.pkpn as PenghasilanKenaPajak, a.pphutang as PphHutang, a.income as IncomePerMonth , a.Overtime FROM db_hasil a, db_payrolldata b where a.Employeecode = b.Employeecode"
        sqlCommand.Connection = SQLConnection
        Dim dt As New DataTable
        dt.Load(sqlCommand.ExecuteReader)
        lis.GridControl1.DataSource = dt
    End Sub

    Private Sub processpayroll()
        If payrollcheck.Checked = True Then
            If radiochoose.Checked = True Then
                computingsalary(txtempcode.Text)
            Else
                Dim cmd As MySqlCommand = SQLConnection.CreateCommand()
                cmd.CommandText = "select employeecode from db_pegawai where status = 'Active'"
                Dim adp As New MySqlDataAdapter(cmd)
                Dim ds As New DataSet
                adp.Fill(ds)
                For Each tbl As DataTable In ds.Tables
                    For Each row As DataRow In tbl.Rows
                        computingsalary(row.Item("EmployeeCode"))
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
        If payrollcheck.Checked = False And thrcheck.Checked = False And bonuscheck.Checked = False And checkovertime.Checked = False Then
            MsgBox("Please choose the Checkbox to processing")
        Else
            If lis Is Nothing OrElse lis.IsDisposed OrElse lis.MinimizeBox Then
                lis.Close()
                lis = New Lists
            End If
            processpayroll()
            lis.Show()
        End If
    End Sub

    Private Sub radioloadall_CheckedChanged(sender As Object, e As EventArgs) Handles radioloadall.CheckedChanged
        If radioloadall.Checked = True Then
            txtname.Text = ""
            txtempcode.Text = ""
        End If
    End Sub
End Class