Imports System.IO
Imports word = Microsoft.Office.Interop.Word

Public Class Payslip
    Dim connectionString As String
    Dim SQLConnection As MySqlConnection = New MySqlConnection
    Dim oDt_sched As New DataTable()
    Dim tbl_par As New DataTable

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
        sqlcommand.CommandText = "SELECT EmployeeCode, FullName From db_payrolldata"
        sqlcommand.Connection = SQLConnection
        Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
        Dim cb As New MySqlCommandBuilder(adapter)
        adapter.Fill(tbl_par)
        For index As Integer = 0 To tbl_par.Rows.Count - 1
            txtname.Properties.Items.Add(tbl_par.Rows(index).Item(1).ToString())
        Next
    End Sub

    Private Sub ComboBoxEdit1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtname.SelectedIndexChanged
        For index As Integer = 0 To tbl_par.Rows.Count - 1
            If txtname.SelectedItem Is tbl_par.Rows(index).Item(1).ToString Then
                txtempcode.Text = tbl_par.Rows(index).Item(0).ToString
            End If
        Next
    End Sub

    Dim list As New Lists

    Public Sub slip(code As String)
        Dim bs As MySqlCommand = SQLConnection.CreateCommand
        bs.CommandText = "select basicrate, allowance, incentives, mealrate, transport from db_payrolldata where employeecode = @empcode"
        bs.Parameters.AddWithValue("@empcode", code)
        Dim res As String = CStr(bs.ExecuteScalar)
        bs.Connection = SQLConnection
        Dim dt As New DataTable
        dt.Load(bs.ExecuteReader)
        List.GridControl1.DataSource = dt
    End Sub

    Private Sub payrollslip()
        SQLConnection = New MySqlConnection
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        Dim bs As MySqlCommand = SQLConnection.CreateCommand
        bs.CommandText = "select basicrate from db_payrolldata where EmployeeCode = '" & txtempcode.Text & "'"
        Dim salary As String = CStr(bs.ExecuteScalar)

        Dim pos As MySqlCommand = SQLConnection.CreateCommand
        pos.CommandText = "select position from db_pegawai where EmployeeCode = '" & txtempcode.Text & "'"
        Dim position As String = CStr(pos.ExecuteScalar)

        Dim objword As word.Application = Nothing
        Try
            objword = New word.Application
            objword.Documents.Open("E:\Backup\payrollreports.docx")
            Dim findobject As word.Find = objword.Selection.Find
            With findobject
                .ClearFormatting()
                .Text = "Name"
                .Replacement.ClearFormatting()
                .Replacement.Text = txtname.Text
                .Execute(Replace:=word.WdReplace.wdReplaceAll)
            End With
            With findobject
                .ClearFormatting()
                .Text = "EmployeeCode"
                .Replacement.ClearFormatting()
                .Replacement.Text = txtempcode.Text
                .Execute(Replace:=word.WdReplace.wdReplaceAll)
            End With
            With findobject
                .ClearFormatting()
                .Text = "Gapok"
                .Replacement.ClearFormatting()
                .Replacement.Text = salary
                .Execute(Replace:=word.WdReplace.wdReplaceAll)
            End With
            With findobject
                .ClearFormatting()
                .Text = "Position"
                .Replacement.Text = position
                .Execute(Replace:=word.WdReplace.wdReplaceAll)
            End With
            With findobject
                .ClearFormatting()
                .Text = "Periode"
                .Replacement.Text = CType(txtperiod.Value, String)
                .Execute(Replace:=word.WdReplace.wdReplaceAll)
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Sub hasilslip(emp As String)
        Try
            Dim names As MySqlCommand = SQLConnection.CreateCommand
            names.CommandText = "select employeetype from db_pegawai where EmployeeCode = '" & emp & "'"
            Dim name As String = CStr(names.ExecuteScalar)

            Dim q As MySqlCommand = SQLConnection.CreateCommand()
            q.CommandText = "select * from db_employeetype where emptype = '" & name & "'"

            Dim a As MySqlCommand = SQLConnection.CreateCommand
            a.CommandText = "select count(*) from db_absensi where Tanggal between @date1 and @date2 and EmployeeCode = '" & emp & "'"
            a.Parameters.AddWithValue("@date1", txtperiod.Value.Date)
            a.Parameters.AddWithValue("@date2", txtto.Value)
            Dim hk As Integer = CInt(a.ExecuteScalar)

            'Dim b As MySqlCommand = SQLConnection.CreateCommand
            'b.CommandText = "select (a.basicrate * b.bpjs / 100) + (a.basicrate * b.JamKecelakaanKerja / 100 ) + (a.basicrate * b.JaminanKesehatan/ 100) + (a.basicrate * b.IuranPensiun/100) + (a.basicrate * b.JaminanHariTua / 100) + (a.basicrate * b.biayajabatan / 100) + (a.basicrate * b.lates / 100) + (a.basicrate * b.JaminanKematian / 100) from db_payrolldata a, db_setpayroll b where employeecode = '" & emp & "'"
            'Dim deduc As Integer = CInt(b.ExecuteScalar)
            Dim b As MySqlCommand = SQLConnection.CreateCommand
            b.CommandText = "select (calc_deductions(a.basicrate, a.Bpjs, b.Bpjs, a.JaminanKecelakaanKerja, b.JamKecelakaanKerja, a.JaminanKematian, b.JaminanKematian, a.JaminanHariTua, b.JaminanHariTua, a.IuranPensiun, b.IuranPensiun, a.BiayaJabatan, b.BiayaJabatan)) from db_payrolldata a join db_setpayroll b  where a.EmployeeCode = @emp"
            b.Parameters.AddWithValue("@emp", emp)
            Dim deduc As Integer = CInt(b.ExecuteScalar)
            MsgBox(deduc)

            Dim salary As MySqlCommand = SQLConnection.CreateCommand
            salary.CommandText = "select basicrate from db_payrolldata where EmployeeCode = '" & emp & "'"
            Dim realsalary As Integer = CInt(salary.ExecuteScalar)

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
                        calc = calc.replace("[salarypermonth]", realsalary)
                        Dim q2 As MySqlCommand = SQLConnection.CreateCommand()
                        q2.CommandText = CType("select " & calc, String)
                        income = CInt(q2.ExecuteScalar)
                    End If
                End If
            End If

            Dim fix As Integer = income - deduc
            Dim ovt As MySqlCommand = SQLConnection.CreateCommand
            ovt.CommandText = "select sum(overtimehours) from db_absensi where employeecode = '" & emp & "'"
            Dim realovt As Integer = CInt(ovt.ExecuteScalar)
            Dim collect As MySqlCommand = SQLConnection.CreateCommand
            collect.CommandText = "INSERT INTO db_temp " +
                                "(Dated, EmployeeCode, HK, Overtime, Deductions, FixedSalary) " +
                                " Values (@Dated, @EmployeeCode, @HK, @Overtime, @Deductions, @FixedSalary)"
            collect.Parameters.AddWithValue("@Dated", Date.Now)
            collect.Parameters.AddWithValue("@EmployeeCode", emp)
            collect.Parameters.AddWithValue("@HK", hk)
            collect.Parameters.AddWithValue("@Overtime", realovt)
            collect.Parameters.AddWithValue("@Deductions", deduc)
            collect.Parameters.AddWithValue("@FixedSalary", fix)
            collect.ExecuteNonQuery()
            Dim table As New DataTable
            Dim sqlCommand As New MySqlCommand
            sqlCommand.CommandText = "Select b.Dated as Dates, a.EmployeeCode, b.HK as JumlahHariKerja, a.FullName, a.BasicRate as Salary, a.MealRate, a.Allowance, a.Incentives, b.Overtime as OvertimeHours, b.Deductions, b.FixedSalary FROM db_payrolldata a, db_temp b where a.Employeecode = b.Employeecode"
            sqlCommand.Connection = SQLConnection
            Dim dt As New DataTable
            dt.Load(sqlCommand.ExecuteReader)
            viw.GridControl1.DataSource = dt
        Catch ex As Exception
            MsgBox("Payslip" & ex.Message)
        End Try
    End Sub

    Private Sub Payslip_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        loaddata()
    End Sub

    Dim viw As New View

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If viw Is Nothing OrElse viw.IsDisposed Or viw.MinimizeBox Then
            viw = New View
        End If
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "truncate db_temp"
        query.ExecuteNonQuery()

        If RadioButton1.Checked = True Then
            Dim cmd As MySqlCommand = SQLConnection.CreateCommand()
            cmd.CommandText = "select employeecode from db_payrolldata"
            Dim adp As New MySqlDataAdapter(cmd)
            Dim ds As New DataSet
            adp.Fill(ds)
            For Each tbl As DataTable In ds.Tables
                For Each row As DataRow In tbl.Rows
                    hasilslip(CType(row.Item("EmployeeCode"), String))
                Next
            Next
            viw.Show()
            viw.SimpleButton1.PerformClick()
        ElseIf RadioButton2.Checked = True And txtname.Text = "" Or txtempcode.Text = "" Then
            MsgBox("Select the employee")
        Else
            hasilslip(txtempcode.Text)
            viw.Show()
            viw.SimpleButton1.PerformClick()
        End If
        viw.Hide()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            txtname.Text = "<empty>"
            txtempcode.Text = ""
            txtempcode.Enabled = False
            txtname.Enabled = False
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            txtname.Enabled = True
            txtempcode.Enabled = True
        End If
    End Sub
End Class