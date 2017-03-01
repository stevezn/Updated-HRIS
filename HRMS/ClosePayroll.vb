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
        SQLConnection = New MySqlConnection
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        Dim sqlcommand As New MySqlCommand
        sqlcommand.CommandText = "SELECT FullName, EmployeeCode From db_payrolldata"
        sqlcommand.Connection = SQLConnection
        Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
        Dim cb As New MySqlCommandBuilder(adapter)
        adapter.Fill(tbl_par)
        For index As Integer = 0 To tbl_par.Rows.Count - 1
            txtname.Properties.Items.Add(tbl_par.Rows(index).Item(0).ToString())
        Next
        SQLConnection.Close()
    End Sub

    Sub computesalary()
        SQLConnection = New MySqlConnection
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
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
        SQLConnection.Close()
    End Sub

    Dim list As New Lists

    Private Sub ClosePayroll_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaddata()
    End Sub

    Private Sub radiochoose_CheckedChanged(sender As Object, e As EventArgs) Handles radiochoose.CheckedChanged
        If radiochoose.Checked = True Then
            txtname.Enabled = True
        Else
            txtname.Enabled = False
        End If
    End Sub

    Private Sub txtname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtname.SelectedIndexChanged
        For index As Integer = 0 To tbl_par.Rows.Count - 1
            If txtname.SelectedItem Is tbl_par.Rows(index).Item(0).ToString Then
                txtempcode.Text = tbl_par.Rows(index).Item(1).ToString
            End If
        Next
    End Sub

    Sub loadbonus()

    End Sub

    Sub loademployee()

    End Sub

    Sub loadthr()
        SQLConnection = New MySqlConnection
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()

    End Sub

    Sub overtime()
        If radiochoose.Checked = True Then
            Dim othours As MySqlCommand = SQLConnection.CreateCommand
            othours.CommandText = "select overtimehours from db_absensi where EmployeeCode ='" & txtempcode.Text & "'"
            Dim hours As Integer = CInt(othours.ExecuteScalar)

            Dim type As MySqlCommand = SQLConnection.CreateCommand
            type.CommandText = "select OvertimeType from db_absensi where EmployeeCode ='" & txtempcode.Text & "'"
            Dim realtype As String = CStr(type.ExecuteScalar)

            Dim salary As MySqlCommand = SQLConnection.CreateCommand
            salary.CommandText = "select basicrate from db_payrolldata where EmployeeCode = '" & txtempcode.Text & "'"
            Dim realsalary As Integer = CInt(salary.ExecuteScalar)

            If realtype = "Regular Day" Then
                Dim pay, temp, totot, tempo, value1, value2, pay2 As Double
                pay = CDec(realsalary / 173)
                pay2 = pay * 1.5
                If hours = 1 Then
                    tempo = pay * 1.5
                    value1 = tempo
                    totot = value1
                ElseIf hours > 1 Then
                    temp = pay * 2
                    tempo = temp * hours - pay * 2
                    value2 = tempo
                    totot = value2 + pay2
                End If
            ElseIf realtype = "Holiday Day" Then
                Dim pay, temp, totot2, tempo, value1, value2, pay2, value3 As Double
                pay = realsalary / 173
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
            End If
        ElseIf radioloadall.Checked = True Then
            Dim othours As MySqlCommand = SQLConnection.CreateCommand
            othours.CommandText = "select overtimehours from db_absensi where EmployeeCode ='" & txtempcode.Text & "'"
            Dim hours As Integer = CInt(othours.ExecuteScalar)

            Dim type As MySqlCommand = SQLConnection.CreateCommand
            type.CommandText = "select OvertimeType from db_absensi where EmployeeCode ='" & txtempcode.Text & "'"
            Dim realtype As String = CStr(type.ExecuteScalar)

            Dim salary As MySqlCommand = SQLConnection.CreateCommand
            salary.CommandText = "select basicrate from db_payrolldata where EmployeeCode = '" & txtempcode.Text & "'"
            Dim realsalary As Integer = CInt(salary.ExecuteScalar)

            If realtype = "Regular Day" Then
                Dim pay, temp, totot, tempo, value1, value2, pay2 As Double
                pay = CDec(realsalary / 173)
                pay2 = pay * 1.5
                If hours = 1 Then
                    tempo = pay * 1.5
                    value1 = tempo
                    totot = value1
                ElseIf hours > 1 Then
                    temp = pay * 2
                    tempo = temp * hours - pay * 2
                    value2 = tempo
                    totot = value2 + pay2
                End If
            ElseIf realtype = "Holiday Day" Then
                Dim pay, temp, totot2, tempo, value1, value2, pay2, value3 As Double
                pay = realsalary / 173
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
            End If
        End If
    End Sub

    Dim lis As New Lists
    Dim basicsalary As Decimal
    Dim pphutang As Decimal

    Sub computesalaries()
        SQLConnection = New MySqlConnection
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        Dim basrate As MySqlCommand = SQLConnection.CreateCommand
        basrate.CommandText = "select basicrate from db_payrolldata where EmployeeCode = '" & txtempcode.Text & "'"
        Dim basicrate As Integer = CInt(basrate.ExecuteScalar)
        Dim salaryperyear As Integer = basicrate * 12

        Dim netto As MySqlCommand = SQLConnection.CreateCommand
        netto.CommandText = "select basicrate + allowance + incentives + mealrate + transport as netto from db_payrolldata where Employeecode = '" & txtempcode.Text & "'"
        Dim net As Integer = CInt(netto.ExecuteScalar)

        Dim deduct As MySqlCommand = SQLConnection.CreateCommand
        deduct.CommandText = "select a.basicrate - a.basicrate * b.bpjs / 100 - a.basicrate * b.JamKecelakaanKerja / 100 - a.basicrate * b.JaminanKesehatan / 100 - a.basicrate * b.IuranPensiun / 100 - a.basicrate * b.JaminanHariTua / 100 - a.basicrate * b.BiayaJabatan / 100 - a.basicrate * lates/ 100 - a.basicrate * b.JaminanKematian/100 from db_payrolldata a, db_setpayroll b where a.EmployeeCode = '" & txtempcode.Text & "'"
        Dim gross As Integer = CInt(deduct.ExecuteScalar)

        Dim ptkp As MySqlCommand = SQLConnection.CreateCommand
        ptkp.CommandText = "select StatusWajibPajak from db_payrolldata where EmployeeCode = '" & txtempcode.Text & "'"
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

        Dim pkpajak As Decimal = net - hasilptkp
        Dim tmp As Decimal

        Dim npwp As MySqlCommand = SQLConnection.CreateCommand
        npwp.CommandText = "select memilikinpwp from db_payrolldata where EmployeeCode = '" & txtempcode.Text & "'"
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
        Dim collect As MySqlCommand = SQLConnection.CreateCommand
        collect.CommandText = "INSERT INTO db_hasil " +
                                "(EmployeeCode, FullName, SalaryPerYear, Netto, Gross, WajibPajak, pkpn, pphutang) " +
                                " Values (@EmployeeCode, @FullName, @SalaryPerYear, @Netto, @Gross, @WajibPajak, @pkpn, @pphutang)"
        collect.Parameters.AddWithValue("@EmployeeCode", txtempcode.Text)
        collect.Parameters.AddWithValue("@FullName", txtname.Text)
        collect.Parameters.AddWithValue("@SalaryPerYear", salaryperyear)
        collect.Parameters.AddWithValue("@Netto", net)
        collect.Parameters.AddWithValue("@Gross", gross)
        collect.Parameters.AddWithValue("@WajibPajak", wajibpajak)
        collect.Parameters.AddWithValue("@pkpn", pkpajak)
        collect.Parameters.AddWithValue("@pphutang", pphutang)
        collect.ExecuteNonQuery()
        Dim table As New DataTable
        Dim sqlCommand As New MySqlCommand
        sqlCommand.CommandText = "Select EmployeeCode, FullName, SalaryPerYear, Netto, Gross, WajibPajak, pkpn, pphutang FROM db_hasil"
        sqlCommand.Connection = SQLConnection
        Dim dt As New DataTable
        dt.Load(sqlCommand.ExecuteReader)
        lis.GridControl1.DataSource = dt
        SQLConnection.Close()
    End Sub

    Sub loadall()
        SQLConnection = New MySqlConnection
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        If radiochoose.Checked = True Then
            Dim names As MySqlCommand = SQLConnection.CreateCommand
            names.CommandText = "select employeetype from db_pegawai where EmployeeCode = '" & txtempcode.Text & "'"
            Dim name As String = CStr(names.ExecuteScalar)

            Dim q As MySqlCommand = SQLConnection.CreateCommand()
            q.CommandText = "select * from db_employeetype where emptype = '" & name & "'"

            Dim a As MySqlCommand = SQLConnection.CreateCommand
            a.CommandText = "select count(*) from db_absensi where Tanggal between @date1 and @date2 and EmployeeCode = '" & txtempcode.Text & "'"
            a.Parameters.AddWithValue("@date1", date1.Value)
            a.Parameters.AddWithValue("@date2", date2.Value)
            Dim hk As Integer
            hk = CInt(a.ExecuteScalar)
            'If hk = 0 Then
            '    hk = 0
            'Else
            '    hk = hk + 1
            'End If
            MsgBox(hk)
            Dim b As MySqlCommand = SQLConnection.CreateCommand
            b.CommandText = "select a.basicrate * b.bpjs/100 from db_payrolldata a, db_setpayroll b where a.EmployeeCode = '" & txtempcode.Text & "'"
            Dim bpjs As Integer
            bpjs = CInt(b.ExecuteScalar)

            Dim c As MySqlCommand = SQLConnection.CreateCommand
            c.CommandText = "select a.basicrate * b.iuranpensiun/100 from db_payrolldata a, db_setpayroll b where a.EmployeeCode = '" & txtempcode.Text & "'"
            Dim iuranpensiun As Integer
            iuranpensiun = CInt(c.ExecuteScalar)

            Dim d As MySqlCommand = SQLConnection.CreateCommand
            d.CommandText = "select a.basicrate * b.JaminanKesehatan/100 from db_payrolldata a, db_setpayroll b where a.EmployeeCode = '" & txtempcode.Text & "'"
            Dim jamkes As Integer
            jamkes = CInt(d.ExecuteScalar)

            Dim e As MySqlCommand = SQLConnection.CreateCommand
            e.CommandText = "select a.basicrate * b.JaminanHariTua/100 from db_payrolldata a, db_setpayroll b where a.EmployeeCode = '" & txtempcode.Text & "'"
            Dim jht As Integer
            jht = CInt(e.ExecuteScalar)

            Dim f As MySqlCommand = SQLConnection.CreateCommand
            f.CommandText = "select a.basicrate * b.BiayaJabatan/100 from db_payrolldata a, db_setpayroll b where a.EmployeeCode = '" & txtempcode.Text & "'"
            Dim bj As Integer
            bj = CInt(f.ExecuteScalar)

            Dim g As MySqlCommand = SQLConnection.CreateCommand
            g.CommandText = "select basicrate from db_payrolldata where EmployeeCode = '" & txtempcode.Text & "'"
            Dim basicrate As Integer
            basicrate = CInt(g.ExecuteScalar)

            Dim h As MySqlCommand = SQLConnection.CreateCommand
            h.CommandText = "select a.basicrate * b.JaminanKematian/100 from db_payrolldata a, db_setpayroll b where a.EmployeeCode = '" & txtempcode.Text & "'"
            Dim jamkem As Integer
            jamkem = CInt(h.ExecuteScalar)

            Dim i As MySqlCommand = SQLConnection.CreateCommand
            i.CommandText = "select a.basicrate * b.jamKecelakaanKerja/100 from db_payrolldata a, db_setpayroll b where a.EmployeeCode = '" & txtempcode.Text & "'"
            Dim jkk As Integer
            jkk = CInt(i.ExecuteScalar)
            Dim adp As New MySqlDataAdapter(q)
            Dim ds As New DataSet
            adp.Fill(ds)
            If ds.Tables.Count = 1 Then
                If ds.Tables(0).Rows.Count = 1 Then
                    Dim calc = ds.Tables(0).Rows(0).Item("calculation")
                    calc = calc.replace("[hk]", hk)
                    calc = calc.Replace("[output]", "")
                    calc = calc.Replace("[basicrate]", basicrate)
                    calc = calc.replace("[bpjs]", bpjs)
                    calc = calc.replace("[jamkem]", jamkem)
                    calc = calc.replace("[jaminanharitua]", jht)
                    calc = calc.replace("[jaminankecelakaankerja]", jkk)
                    calc = calc.replace("[jaminankematian]", jamkem)
                    calc = calc.replace("[jaminankesehatan]", jamkes)
                    Dim q2 As MySqlCommand = SQLConnection.CreateCommand()
                    q2.CommandText = CType("select " + calc, String)
                    Dim dt As New DataTable
                    dt.Load(q2.ExecuteReader)
                    lis.GridControl1.DataSource = dt
                    'SQLConnection.Close()
                    'MsgBox(q2.ExecuteScalar)
                End If
            End If

        ElseIf radioloadall.Checked = True Then
            Dim names As MySqlCommand = SQLConnection.CreateCommand
            names.CommandText = "select employeetype from db_pegawai"
            Dim name As String = CStr(names.ExecuteScalar)

            Dim q As MySqlCommand = SQLConnection.CreateCommand()
            q.CommandText = "select * from db_employeetype "

            Dim a As MySqlCommand = SQLConnection.CreateCommand
            a.CommandText = "select count(*) from db_absensi where Tanggal between @date1 and @date2"
            a.Parameters.AddWithValue("@date1", date1.Value)
            a.Parameters.AddWithValue("@date2", date2.Value)
            Dim hk As Integer
            hk = CInt(a.ExecuteScalar)
            If hk = 0 Then
                hk = 0
            Else
                hk = hk + 1
            End If
            MsgBox(hk)
            Dim b As MySqlCommand = SQLConnection.CreateCommand
            b.CommandText = "select a.basicrate * b.bpjs/100 from db_payrolldata a, db_setpayroll b"
            Dim bpjs As Integer
            bpjs = CInt(b.ExecuteScalar)

            Dim c As MySqlCommand = SQLConnection.CreateCommand
            c.CommandText = "select a.basicrate * b.iuranpensiun/100 from db_payrolldata a, db_setpayroll b"
            Dim iuranpensiun As Integer
            iuranpensiun = CInt(c.ExecuteScalar)

            Dim d As MySqlCommand = SQLConnection.CreateCommand
            d.CommandText = "select a.basicrate * b.JaminanKesehatan/100 from db_payrolldata a, db_setpayroll b"
            Dim jamkes As Integer
            jamkes = CInt(d.ExecuteScalar)

            Dim e As MySqlCommand = SQLConnection.CreateCommand
            e.CommandText = "select a.basicrate * b.JaminanHariTua/100 from db_payrolldata a, db_setpayroll b"
            Dim jht As Integer
            jht = CInt(e.ExecuteScalar)

            Dim f As MySqlCommand = SQLConnection.CreateCommand
            f.CommandText = "select a.basicrate * b.BiayaJabatan/100 from db_payrolldata a, db_setpayroll b"
            Dim bj As Integer
            bj = CInt(f.ExecuteScalar)

            Dim g As MySqlCommand = SQLConnection.CreateCommand
            g.CommandText = "select basicrate from db_payrolldata"
            Dim basicrate As Integer
            basicrate = CInt(g.ExecuteScalar)

            Dim h As MySqlCommand = SQLConnection.CreateCommand
            h.CommandText = "select a.basicrate * b.JaminanKematian/100 from db_payrolldata a, db_setpayroll b"
            Dim jamkem As Integer
            jamkem = CInt(h.ExecuteScalar)

            Dim i As MySqlCommand = SQLConnection.CreateCommand
            i.CommandText = "select a.basicrate * b.jamKecelakaanKerja/100 from db_payrolldata a, db_setpayroll b"
            Dim jkk As Integer
            jkk = CInt(i.ExecuteScalar)
            Dim adp As New MySqlDataAdapter(q)
            Dim ds As New DataSet
            adp.Fill(ds)
            If ds.Tables.Count = 1 Then
                If ds.Tables(0).Rows.Count = 1 Then
                    Dim calc = ds.Tables(0).Rows(0).Item("calculation")
                    calc = calc.replace("[hk]", hk)
                    calc = calc.Replace("[output]", "")
                    calc = calc.Replace("[basicrate]", basicrate)
                    calc = calc.replace("[bpjs]", bpjs)
                    calc = calc.replace("[jamkem]", jamkem)
                    calc = calc.replace("[jaminanharitua]", jht)
                    calc = calc.replace("[jaminankecelakaankerja]", jkk)
                    calc = calc.replace("[jaminankematian]", jamkem)
                    calc = calc.replace("[jaminankesehatan]", jamkes)
                    Dim q2 As MySqlCommand = SQLConnection.CreateCommand()
                    q2.CommandText = CType("select " + calc, String)
                    Dim dt As New DataTable
                    dt.Load(q2.ExecuteReader)
                    lis.GridControl1.DataSource = dt
                    'MsgBox(q2.ExecuteScalar)
                End If
            End If
        End If
    End Sub

    Private Sub processpayroll()
        If payrollcheck.Checked = True Then
            computesalaries()
            'loadall()
            If lis Is Nothing OrElse lis.IsDisposed Then
                lis = New Lists
            End If
            lis.Show()
        ElseIf thrcheck.Checked = True Then
            loadthr()
        ElseIf bonuscheck.Checked = True Then
            loaddata()
        ElseIf checkovertime.Checked = True Then
            overtime()
        ElseIf payrollcheck.Checked = True And thrcheck.Checked = True And bonuscheck.Checked = True Then
            loaddata()
            loadall()
            loadthr()
        ElseIf payrollcheck.Checked = True And thrcheck.Checked = True And bonuscheck.Checked = False Then
            loadthr()
            loadall()
        ElseIf payrollcheck.Checked = True And thrcheck.Checked = False And bonuscheck.Checked = True Then
            loadall()
            loaddata()
        ElseIf payrollcheck.Checked = False And thrcheck.Checked = True And bonuscheck.Checked = True Then
            loaddata()
            loadthr()
        ElseIf payrollcheck.Checked = True And thrcheck.Checked = False And bonuscheck.Checked = True Then
            loadall()
            loadthr()
        End If
    End Sub

    Private Sub btnProcess_Click(sender As Object, e As EventArgs) Handles btnProcess.Click
        If payrollcheck.Checked = False And thrcheck.Checked = False And bonuscheck.Checked = False And checkovertime.Checked = False Then
            MsgBox("Please choose the Checkbox to processing")
        Else
            processpayroll()
        End If
        'If list Is Nothing OrElse list.IsDisposed Then
        '    list = New Lists
        'End If
        'computesalary()
        'list.Show()
    End Sub

    Private Sub radioloadall_CheckedChanged(sender As Object, e As EventArgs) Handles radioloadall.CheckedChanged
        If radioloadall.Checked = True Then
            txtname.Text = ""
            txtempcode.Text = ""
        End If
    End Sub
End Class