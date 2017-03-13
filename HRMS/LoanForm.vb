Imports System.IO
Imports System.Windows.Forms.DataVisualization.Charting
Imports DevExpress.Utils.Menu
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views
Imports DevExpress.XtraGrid.Views.Grid

Public Class Payments
    Dim connectionString As String
    Dim SQLConnection As MySqlConnection = New MySqlConnection
    Dim oDt_sched As New DataTable()
    Dim tbl_par As New DataTable

    Sub loaddata()
        Dim sqlcommand As New MySqlCommand
        sqlcommand.CommandText = "select fullname, employeecode from db_pegawai a where a.employeecode not in (select b.employeecode from db_payrolldata b )"
        sqlcommand.Connection = SQLConnection
        Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
        Dim cb As New MySqlCommandBuilder(adapter)
        adapter.Fill(tbl_par)
        For index As Integer = 0 To tbl_par.Rows.Count - 1
            txtname1.Properties.Items.Add(tbl_par.Rows(index).Item(0).ToString())
        Next
    End Sub

    Dim tbl_par3 As New DataTable
    Dim log As Login

    Public Sub New()
        InitializeComponent()
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

    Sub loanlists()
        Dim sqlcommand As New MySqlCommand
        sqlcommand.CommandText = "SELECT FullName, EmployeeCode from db_loan"
        sqlcommand.Connection = SQLConnection
        Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
        Dim cb As New MySqlCommandBuilder(adapter)
        adapter.Fill(tbl_par3)
        For index As Integer = 0 To tbl_par3.Rows.Count - 1
            txtloanname.Properties.Items.Add(tbl_par3.Rows(index).Item(0).ToString())
            txtnameloan.Properties.Items.Add(tbl_par3.Rows(index).Item(1).ToString())
        Next
    End Sub

    Dim tbl_par2 As New DataTable

    Sub loaddata1()
        Dim sqlcommand As New MySqlCommand
        sqlcommand.CommandText = "SELECT FullName, EmployeeCode, StatusWajibPajak, MemilikiNpwp, BasicRate, Allowance, Incentives, MealRate, Transport, JaminanKesehatan, Bpjs, JaminanKecelakaanKerja, JaminanKematian, JaminanHariTua, IuranPensiun, BiayaJabatan, Rapel, Loan From db_payrolldata"
        sqlcommand.Connection = SQLConnection
        Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
        Dim cb As New MySqlCommandBuilder(adapter)
        adapter.Fill(tbl_par2)
        For index As Integer = 0 To tbl_par2.Rows.Count - 1
            txtname2.Properties.Items.Add(tbl_par2.Rows(index).Item(0).ToString())
            txtname3.Properties.Items.Add(tbl_par2.Rows(index).Item(0).ToString())
            txtname.Properties.Items.Add(tbl_par2.Rows(index).Item(0).ToString())
        Next
    End Sub

    Sub selectname()
        GridControl8.RefreshDataSource()
        Dim table As New DataTable
        Dim sqlCommand As New MySqlCommand
        Try
            sqlCommand.CommandText = "select a.FullName, a.EmployeeCode, a.BasicRate, b.Gender, b.Status, b.IdNumber, b.Religion from db_payrolldata a, db_pegawai b where a.EMployeeCode = b.EmployeeCode"
            sqlCommand.Connection = SQLConnection
            Dim tbl_par As New DataTable
            Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(table)
            GridControl8.DataSource = table
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub Insertpart()
        Dim sqlCommand As MySqlCommand = SQLConnection.CreateCommand
        Try
            sqlCommand.CommandText = "INSERT INTO db_salarychange " +
                                "(FullName, EmployeeCode, StatusWajibPajak, MemilikiNpwp, BasicRate, Allowance, Incentives, MealRate, Transport, JaminanKesehatan, Bpjs, JaminanKecelakaanKerja, JaminanKematian, JaminanHariTua, IuranPensiun, BiayaJabatan, Rapel, Loan, ChangeDate, ChangeBy) " +
                                "values (@FullName, @EmployeeCode, @StatusWajibPajak, @MemilikiNpwp, @BasicRate, @Allowance, @Incentives, @MealRate, @Transport, @JaminanKesehatan, @Bpjs, @JaminanKecelakaanKerja, @JaminanKematian, @JaminanHariTua, @IuranPensiun, @BiayaJabatan, @Rapel, @Loan, @ChangeDate, @ChangeBy)"
            sqlCommand.Parameters.AddWithValue("@FullName", txtname1.Text)
            sqlCommand.Parameters.AddWithValue("@EmployeeCode", txtempcode1.Text)
            sqlCommand.Parameters.AddWithValue("@StatusWajibPajak", txtwajibpajak.Text)
            sqlCommand.Parameters.AddWithValue("@MemilikiNpwp", txtnpwp.Text)
            sqlCommand.Parameters.AddWithValue("@BasicRate", txtbasicrate.Text)
            sqlCommand.Parameters.AddWithValue("@Allowance", txtallowance.Text)
            sqlCommand.Parameters.AddWithValue("@Incentives", txtincentives.Text)
            sqlCommand.Parameters.AddWithValue("@MealRate", txtmealrate.Text)
            sqlCommand.Parameters.AddWithValue("@Transport", txttransport.Text)
            Dim cjks As String
            If cjk.Checked = True Then
                cjks = "Yes"
            Else
                cjks = "No"
            End If
            sqlCommand.Parameters.AddWithValue("@JaminanKesehatan", "12")
            Dim cbpjss As String
            If cbpjs.Checked = True Then
                cbpjss = "Yes"
            Else
                cbpjss = "No"
            End If
            sqlCommand.Parameters.AddWithValue("@Bpjs", cbpjss)
            Dim cjkks As String
            If cjkk.Checked = True Then
                cjkks = "Yes"
            Else
                cjkks = "No"
            End If
            sqlCommand.Parameters.AddWithValue("@JaminanKecelakaanKerja", cjkks)
            Dim jks As String
            If cjamkem.Checked = True Then
                jks = "Yes"
            Else
                jks = "No"
            End If
            sqlCommand.Parameters.AddWithValue("@JaminanKematian", jks)
            Dim jhts As String
            If cjht.Checked = True Then
                jhts = "Yes"
            Else
                jhts = "No"
            End If
            sqlCommand.Parameters.AddWithValue("@JaminanHariTua", jhts)
            Dim iupes As String
            If ciupe.Checked = True Then
                iupes = "Yes"
            Else
                iupes = "No"
            End If
            sqlCommand.Parameters.AddWithValue("@IuranPensiun", iupes)
            Dim bjs As String '
            If cbj.Checked = True Then
                bjs = "Yes"
            Else
                bjs = "No"
            End If
            sqlCommand.Parameters.AddWithValue("@BiayaJabatan", bjs)
            Dim rapels As String
            If crapel.Checked = True Then
                rapels = "Yes"
            Else
                rapels = "No"
            End If
            sqlCommand.Parameters.AddWithValue("@Rapel", rapels)
            Dim loans As String
            If cloan.Checked = True Then
                loans = "Yes"
            Else
                loans = "No"
            End If
            sqlCommand.Parameters.AddWithValue("@Loan", loans)
            sqlCommand.Parameters.AddWithValue("@ChangeDate", Date.Now)
            sqlCommand.Parameters.AddWithValue("@ChangeBy", "Unknown")
            sqlCommand.ExecuteNonQuery()
            MessageBox.Show("Data Succesfully Added!")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub updatepart()
        Dim sqlCommand As MySqlCommand = SQLConnection.CreateCommand
        Try
            Dim a As MySqlCommand = SQLConnection.CreateCommand
            a.CommandText = "select JaminanKesehatan from db_payrolldata where employeecode = '" & txtempcode2.Text & "'"
            Dim aa As Integer = CInt(a.ExecuteScalar)
            Dim aaaa As String
            If aa = 1 Then
                aaaa = "Yes"
            Else
                aaaa = "No"
            End If

            Dim b As MySqlCommand = SQLConnection.CreateCommand
            b.CommandText = "select Bpjs from db_payrolldata where employeecode = '" & txtempcode2.Text & "'"
            Dim bb As Integer = CInt(b.ExecuteScalar)
            Dim bbbb As String
            If bb = 1 Then
                bbbb = "Yes"
            Else
                bbbb = "No"
            End If

            Dim c As MySqlCommand = SQLConnection.CreateCommand
            c.CommandText = "select JaminanKecelakaanKerja from db_payrolldata where employeecode = '" & txtempcode2.Text & "'"
            Dim cc As Integer = CInt(c.ExecuteScalar)
            Dim cccc As String
            If cc = 1 Then
                cccc = "Yes"
            Else
                cccc = "No"
            End If

            Dim d As MySqlCommand = SQLConnection.CreateCommand
            d.CommandText = "select JaminanKematian from db_payrolldata where employeecode = '" & txtempcode2.Text & "'"
            Dim dd As Integer = CInt(d.ExecuteScalar)
            Dim dddd As String
            If dd = 1 Then
                dddd = "Yes"
            Else
                dddd = "No"
            End If

            Dim e As MySqlCommand = SQLConnection.CreateCommand
            e.CommandText = "select JaminanHariTua from db_payrolldata where employeecode = '" & txtempcode2.Text & "'"
            Dim ee As Integer = CInt(e.ExecuteScalar)
            Dim eeee As String
            If ee = 1 Then
                eeee = "Yes"
            Else
                eeee = "N0"
            End If

            Dim f As MySqlCommand = SQLConnection.CreateCommand
            f.CommandText = "select IuranPensiun from db_payrolldata where employeecode = '" & txtempcode2.Text & "'"
            Dim ff As Integer = CInt(f.ExecuteScalar)
            Dim ffff As String
            If ff = 1 Then
                ffff = "Yes"
            Else
                ffff = "No"
            End If

            Dim g As MySqlCommand = SQLConnection.CreateCommand
            g.CommandText = "select BiayaJabatan from db_payrolldata where employeecode = '" & txtempcode2.Text & "'"
            Dim gg As Integer = CInt(g.ExecuteScalar)
            Dim gggg As String
            If bb = 1 Then
                gggg = "Yes"
            Else
                gggg = "No"
            End If

            Dim h As MySqlCommand = SQLConnection.CreateCommand
            h.CommandText = "select rapel from db_payrolldata where employeecode = '" & txtempcode2.Text & "'"
            Dim hh As Integer = CInt(h.ExecuteScalar)
            Dim hhhh As String
            If hh = 1 Then
                hhhh = "Yes"
            Else
                hhhh = "No"
            End If

            Dim i As MySqlCommand = SQLConnection.CreateCommand
            i.CommandText = "select loan from db_payrolldata where employeecode = '" & txtempcode2.Text & "'"
            Dim ii As Integer = CInt(i.ExecuteScalar)
            Dim iiii As String
            If ii = 1 Then
                iiii = "Yes"
            Else
                iiii = "No"
            End If

            Dim use As MySqlCommand = SQLConnection.CreateCommand
            use.CommandText = "select user from db_temp"
            Dim user As String = CStr(use.ExecuteScalar)


            sqlCommand.CommandText = "INSERT INTO db_salarychange " +
                                "(FullName, EmployeeCode, StatusWajibPajak, MemilikiNpwp, BasicRate, Allowance, Incentives, MealRate, Transport, JaminanKesehatan, Bpjs, JaminanKecelakaanKerja, JaminanKematian, JaminanHariTua, IuranPensiun, BiayaJabatan, Rapel, Loan, ChangeDate, ChangeBy) " +
                                "values (@FullName, @EmployeeCode, @StatusWajibPajak, @MemilikiNpwp, @BasicRate, @Allowance, @Incentives, @MealRate, @Transport, @JaminanKesehatan, @Bpjs, @JaminanKecelakaanKerja, @JaminanKematian, @JaminanHariTua, @IuranPensiun, @BiayaJabatan, @Rapel, @Loan, @ChangeDate, @ChangeBy)"
            sqlCommand.Parameters.AddWithValue("@FullName", txtname2.Text)
            sqlCommand.Parameters.AddWithValue("@EmployeeCode", txtempcode2.Text)
            sqlCommand.Parameters.AddWithValue("@StatusWajibPajak", txtwp1.Text)
            sqlCommand.Parameters.AddWithValue("@MemilikiNpwp", txtnpwp1.Text)
            sqlCommand.Parameters.AddWithValue("@BasicRate", txtbasicrate1.Text)
            sqlCommand.Parameters.AddWithValue("@Allowance", txtallowance1.Text)
            sqlCommand.Parameters.AddWithValue("@Incentives", txtincentives1.Text)
            sqlCommand.Parameters.AddWithValue("@MealRate", txtmealrate1.Text)
            sqlCommand.Parameters.AddWithValue("@Transport", txttransport1.Text)
            sqlCommand.Parameters.AddWithValue("@JaminanKesehatan", aaaa)
            sqlCommand.Parameters.AddWithValue("@Bpjs", bbbb)
            sqlCommand.Parameters.AddWithValue("@JaminanKecelakaanKerja", cccc)
            sqlCommand.Parameters.AddWithValue("@JaminanKematian", dddd)
            sqlCommand.Parameters.AddWithValue("@JaminanHariTua", eeee)
            sqlCommand.Parameters.AddWithValue("@IuranPensiun", ffff)
            sqlCommand.Parameters.AddWithValue("@BiayaJabatan", gggg)
            sqlCommand.Parameters.AddWithValue("@Rapel", hhhh)
            sqlCommand.Parameters.AddWithValue("@Loan", iiii)
            sqlCommand.Parameters.AddWithValue("@ChangeDate", Date.Now)
            sqlCommand.Parameters.AddWithValue("@ChangeBy", user)
            sqlCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Dim main As MainApp

    Public Sub updatechange()
        Dim sqlcommand As New MySqlCommand
        Try
            sqlcommand.CommandText = "UPDATE db_payrolldata SET" +
                    " FullName = @FullName" +
                    ", EmployeeCode = @EmployeeCode" +
                    ", StatusWajibPajak = @StatusWajibPajak" +
                    ", MemilikiNpwp = @MemilikiNpwp" +
                    ", BasicRate = @BasicRate" +
                    ", Allowance = @Allowance" +
                    ", Incentives = @Incentives" +
                    ", MealRate = @MealRate" +
                    ", Transport = @Transport" +
                    ", JaminanKesehatan = @JaminanKesehatan" +
                    ", Bpjs = @Bpjs" +
                    ", JaminanKecelakaanKerja = @JaminanKecelakaanKerja" +
                    ", JaminanKematian = @JaminanKematian" +
                    ", JaminanHariTua = @JaminanHariTua" +
                    ", IuranPensiun = @IuranPensiun" +
                    ", BiayaJabatan = @BiayaJabatan" +
                    ", Rapel = @Rapel" +
                    ", Loan = @Loan" +
                    " WHERE EmployeeCode = @EmployeeCode"
            sqlcommand.Connection = SQLConnection
            sqlcommand.Parameters.AddWithValue("@FullName", txtname2.Text)
            sqlcommand.Parameters.AddWithValue("@EmployeeCode", txtempcode2.Text)
            sqlcommand.Parameters.AddWithValue("@StatusWajibPajak", txtwp1.Text)
            sqlcommand.Parameters.AddWithValue("@MemilikiNpwp", txtnpwp1.Text)
            sqlcommand.Parameters.AddWithValue("@BasicRate", txtbasicrate1.Text)
            sqlcommand.Parameters.AddWithValue("@Allowance", txtallowance1.Text)
            sqlcommand.Parameters.AddWithValue("@Incentives", txtincentives1.Text)
            sqlcommand.Parameters.AddWithValue("@MealRate", txtmealrate1.Text)
            sqlcommand.Parameters.AddWithValue("@Transport", txttransport1.Text)
            sqlcommand.Parameters.AddWithValue("@JaminanKesehatan", cjk1.Checked)
            sqlcommand.Parameters.AddWithValue("@Bpjs", cbpjs1.Checked)
            sqlcommand.Parameters.AddWithValue("@JaminanKecelakaanKerja", cjkk1.Checked)
            sqlcommand.Parameters.AddWithValue("@JaminanKematian", cjamkem1.Checked)
            sqlcommand.Parameters.AddWithValue("@JaminanHariTua", cjht1.Checked)
            sqlcommand.Parameters.AddWithValue("@IuranPensiun", ciupe1.Checked)
            sqlcommand.Parameters.AddWithValue("@BiayaJabatan", cbj1.Checked)
            sqlcommand.Parameters.AddWithValue("@Rapel", crapel1.Checked)
            sqlcommand.Parameters.AddWithValue("@Loan", cloan1.Checked)
            sqlcommand.Connection = SQLConnection
            sqlcommand.ExecuteNonQuery()
            MessageBox.Show("Data Successfully Changed!")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub insertlists()
        Dim lesser, greater As Date
        If txtmonth.Value < txtcompletedon1.Value Then
            lesser = txtmonth.Value
            greater = txtcompletedon1.Value
        Else
            lesser = txtcompletedon1.Value
            greater = txtmonth.Value
        End If
        While lesser <= greater
            Dim nilai As String = ""
            If lesser.Month = 1 Then
                nilai = "January"
            ElseIf lesser.Month = 2 Then
                nilai = "February"
            ElseIf lesser.Month = 3 Then
                nilai = "March"
            ElseIf lesser.Month = 4 Then
                nilai = "April"
            ElseIf lesser.Month = 5 Then
                nilai = "May"
            ElseIf lesser.Month = 6 Then
                nilai = "June"
            ElseIf lesser.Month = 7 Then
                nilai = "July"
            ElseIf lesser.Month = 8 Then
                nilai = "August"
            ElseIf lesser.Month = 9 Then
                nilai = "September"
            ElseIf lesser.Month = 10 Then
                nilai = "October"
            ElseIf lesser.Month = 11 Then
                nilai = "November"
            ElseIf lesser.Month = 12 Then
                nilai = "December"
            End If
            Try
                Dim sqlcommand As MySqlCommand = SQLConnection.CreateCommand
                sqlcommand.CommandText = "insert into db_loanlist " +
                                        "(FullName, EmployeeCode, AmountOfLoan, Month, Realisasi)" +
                                        " Values (@FullName, @EmployeeCode, @AmountOfLoan, @Month, @Realisasi)"
                sqlcommand.Parameters.AddWithValue("@FullName", txtname.Text)
                sqlcommand.Parameters.AddWithValue("@EmployeeCode", txtempcode.Text)
                sqlcommand.Parameters.AddWithValue("@AmountOfLoan", txtloan.Text)
                sqlcommand.Parameters.AddWithValue("@Month", nilai)
                sqlcommand.Parameters.AddWithValue("@Realisasi", "")
                sqlcommand.ExecuteNonQuery()
                lesser = lesser.AddMonths(1)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End While
    End Sub

    Public Sub InsertLoan()
        Dim quer As Integer
        Try
            Dim cmd = SQLConnection.CreateCommand
            cmd.CommandText = "select count(*) as numRows from db_loan where EmployeeCode = '" & txtempcode.Text & "'"
            quer = CInt(cmd.ExecuteScalar)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If quer = 0 Then
            insertlists()
            Dim sqlcommand As New MySqlCommand
            Dim str_carsql As String
            str_carsql = "INSERT INTO db_loan " +
                                "(FullName, EmployeeCode, ApprovedBy, Reason, Dates, AmountOfLoan, Months, SalaryInclude, FromMonths, PaymentPerMonth, CompletedOn ) " +
                                " Values (@FullName, @EmployeeCode, @ApprovedBy, @Reason, @Dates, @AmountOfLoan, @Months, @SalaryInclude, @FromMonths, @PaymentPerMonth, @CompletedOn)"
            sqlcommand.Connection = SQLConnection
            sqlcommand.CommandText = str_carsql
            sqlcommand.Parameters.AddWithValue("@FullName", txtname.Text)
            sqlcommand.Parameters.AddWithValue("@EmployeeCode", txtempcode.Text)
            sqlcommand.Parameters.AddWithValue("@ApprovedBy", txtapproved.Text)
            sqlcommand.Parameters.AddWithValue("@Reason", txtreason.Text)
            sqlcommand.Parameters.AddWithValue("@Dates", txtdates.Text)
            sqlcommand.Parameters.AddWithValue("@AmountOfLoan", txtloan.Text)
            sqlcommand.Parameters.AddWithValue("@Months", txtrangemon.Text)
            sqlcommand.Parameters.AddWithValue("@SalaryInclude", CheckEdit2.Checked)
            sqlcommand.Parameters.AddWithValue("@FromMonths", txtmonth.Text)
            sqlcommand.Parameters.AddWithValue("@PaymentPerMonth", lcpayment.Text)
            sqlcommand.Parameters.AddWithValue("@CompletedOn", txtcompletedon1.Text)
            sqlcommand.Connection = SQLConnection
            sqlcommand.ExecuteNonQuery()
            MessageBox.Show("Data Succesfully Added!")
        Else
            MsgBox("This Employee still have a loan in the lists!")
        End If
    End Sub

    Public Sub UpdateLoan()
        Dim sqlcommand As New MySqlCommand
        Try
            sqlcommand.CommandText = "UPDATE db_payrolldata SET" +
                                    " Loan = @Loan" +
                                    " Where EmployeeCode = @EmployeeCode"
            sqlcommand.Connection = SQLConnection
            sqlcommand.Parameters.AddWithValue("EmployeeCode", txtempcode.Text)
            sqlcommand.Parameters.AddWithValue("@Loan", "1")
            sqlcommand.Connection = SQLConnection
            sqlcommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub UpdateRapel()
        Dim sqlcommand As New MySqlCommand
        Try
            sqlcommand.CommandText = "Update db_payrolldata SET" +
                                    " Rapel = @Rapel" +
                                    " Where EmployeeCode = @EmployeeCode"
            sqlcommand.Connection = SQLConnection
            sqlcommand.Parameters.AddWithValue("EmployeeCode", txtempcode.Text)
            sqlcommand.Parameters.AddWithValue("@Rapel", "1")
            sqlcommand.Connection = SQLConnection
            sqlcommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub insertrapel2()
        Dim quer As Integer
        Try
            Dim cmd = SQLConnection.CreateCommand
            cmd.CommandText = "select count(*) as numRows from db_rapel where EmployeeCode = '" & txtempcode3.Text & "'"
            quer = CInt(cmd.ExecuteScalar)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If quer = 0 Then
            Dim sqlcommand As New MySqlCommand
            Dim str_carsql As String
            str_carsql = "Insert into db_rapel " +
                            "(FullName, EmployeeCode, RapelRate, EffSince, Until)" +
                            "Values (@FullName, @EmployeeCode, @RapelRate, @EffSince, @Until)"
            sqlcommand.Connection = SQLConnection
            sqlcommand.CommandText = str_carsql
            sqlcommand.Parameters.AddWithValue("@FullName", txtname3.Text)
            sqlcommand.Parameters.AddWithValue("@EmployeeCode", txtempcode3.Text)
            sqlcommand.Parameters.AddWithValue("@RapelRate", txtrapel.Text)
            sqlcommand.Parameters.AddWithValue("@EffSince", txteffective.Text)
            sqlcommand.Parameters.AddWithValue("@Until", txtuntil.Text)
            sqlcommand.Connection = SQLConnection
            sqlcommand.ExecuteNonQuery()
            MessageBox.Show("Data Successfully Added!")
        Else
            MsgBox("This employee still in rapel progress lists")
        End If
    End Sub

    Public Function InsertPayroll() As Boolean
        Dim quer As Integer
        Try
            Dim cmd = SQLConnection.CreateCommand
            cmd.CommandText = "select count(*) as numRows from db_payrolldata where EmployeeCode = '" & txtempcode1.Text & "'"
            quer = CInt(cmd.ExecuteScalar)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If quer = 0 Then
            Dim sqlCommand As New MySqlCommand
            Dim str_carSql As String
            Try
                str_carSql = "INSERT INTO db_payrolldata " +
                                "(FullName, EmployeeCode, StatusWajibPajak, MemilikiNpwp, BasicRate, Allowance, Incentives, MealRate, Transport, JaminanKesehatan, Bpjs, JaminanKecelakaanKerja, JaminanKematian, JaminanHariTua, IuranPensiun, BiayaJabatan, Rapel, Loan) " +
                                "values (@FullName, @EmployeeCode, @StatusWajibPajak, @MemilikiNpwp, @BasicRate, @Allowance, @Incentives, @MealRate, @Transport, @JaminanKesehatan, @Bpjs, @JaminanKecelakaanKerja, @JaminanKematian, @JaminanHariTua, @IuranPensiun, @BiayaJabatan, @Rapel, @Loan)"
                sqlCommand.Connection = SQLConnection
                sqlCommand.CommandText = str_carSql
                sqlCommand.Parameters.AddWithValue("@FullName", txtname1.Text)
                sqlCommand.Parameters.AddWithValue("@EmployeeCode", txtempcode1.Text)
                sqlCommand.Parameters.AddWithValue("@StatusWajibPajak", txtwajibpajak.Text)
                sqlCommand.Parameters.AddWithValue("@MemilikiNpwp", txtnpwp.Text)
                sqlCommand.Parameters.AddWithValue("@BasicRate", txtbasicrate.Text)
                sqlCommand.Parameters.AddWithValue("@Allowance", txtallowance.Text)
                sqlCommand.Parameters.AddWithValue("@Incentives", txtincentives.Text)
                sqlCommand.Parameters.AddWithValue("@MealRate", txtmealrate.Text)
                sqlCommand.Parameters.AddWithValue("@Transport", txttransport.Text)
                sqlCommand.Parameters.AddWithValue("@JaminanKesehatan", cjk.Checked)
                sqlCommand.Parameters.AddWithValue("@Bpjs", cbpjs.Checked)
                sqlCommand.Parameters.AddWithValue("@JaminanKecelakaanKerja", cjkk.Checked)
                sqlCommand.Parameters.AddWithValue("@JaminanKematian", cjamkem.Checked)
                sqlCommand.Parameters.AddWithValue("@JaminanHariTua", cjht.Checked)
                sqlCommand.Parameters.AddWithValue("@IuranPensiun", ciupe.Checked)
                sqlCommand.Parameters.AddWithValue("@BiayaJabatan", cbj.Checked)
                sqlCommand.Parameters.AddWithValue("@Rapel", crapel.Checked)
                sqlCommand.Parameters.AddWithValue("@Loan", cloan.Checked)
                sqlCommand.Connection = SQLConnection
                sqlCommand.ExecuteNonQuery()
                MessageBox.Show("Data Succesfully Added!")
                Return True
            Catch ex As Exception
                Return False
                MsgBox(ex.Message)
            End Try
        Else
            MsgBox("The Employee Already on the lists!")
        End If
        Return False
    End Function

    Public Function Process() As Boolean
        Dim dtb, dtr As DateTime
        date1.Format = DateTimePickerFormat.Custom
        date1.CustomFormat = "yyyy-MM-dd"
        dtb = date1.Value
        date2.Format = DateTimePickerFormat.Custom
        date2.CustomFormat = "yyyy-MM-dd"
        dtr = date2.Value
        Dim sqlcommand As New MySqlCommand
        Dim str_carsql As String
        Try
            str_carsql = "INSERT INTO db_holiday " +
                            "(StartDate, EndDate, TotalDays, Reason) " +
                            " Values (@StartDate, @EndDate, @TotalDays, @Reason)"
            sqlcommand.Connection = SQLConnection
            sqlcommand.CommandText = str_carsql
            sqlcommand.Parameters.AddWithValue("@StartDate", dtb.ToString("yyyy-MM-dd"))
            sqlcommand.Parameters.AddWithValue("@EndDate", dtr.ToString("yyyy-MM-dd"))
            sqlcommand.Parameters.AddWithValue("@TotalDays", txtdays.Text)
            sqlcommand.Parameters.AddWithValue("@Reason", textreason.Text)
            sqlcommand.Connection = SQLConnection
            sqlcommand.ExecuteNonQuery()
            MessageBox.Show("Data Succesfully Added!")
            Return True
        Catch ex As Exception
            Return False
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function updateholiday() As Boolean
        Dim dtb, dtr As DateTime
        date1.Format = DateTimePickerFormat.Custom
        date1.CustomFormat = "yyyy-MM-dd"
        dtb = date1.Value
        date2.Format = DateTimePickerFormat.Custom
        date2.CustomFormat = "yyyy-MM-dd"
        dtr = date2.Value
        Dim sqlcommand As New MySqlCommand
        Dim str_carsql As String
        Try
            str_carsql = "Update db_holiday SET" +
                          "StartDate = @StartDate" +
                          "EndDate = @EndDate" +
                          "Reason = @Reason" +
                          "TotalDays = @TotalDays"
            sqlcommand.Connection = SQLConnection
            sqlcommand.CommandText = str_carsql
            sqlcommand.Parameters.AddWithValue("@StartDate", dtb.ToString("yyyy-MM-dd"))
            sqlcommand.Parameters.AddWithValue("@EndDate", dtr.ToString("yyyy-MM-dd"))
            sqlcommand.Parameters.AddWithValue("@Reason", txtreason.Text)
            sqlcommand.Parameters.AddWithValue("@TotalDays", txtdays.Text)
            sqlcommand.Connection = SQLConnection
            sqlcommand.ExecuteNonQuery()
            MessageBox.Show("Data Successfully Added!")
            Return True
        Catch ex As Exception
            Return False
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub loanpay()
        Try
            Dim a, b, res As Double
            a = Convert.ToDouble(txtloan.Text)
            b = Convert.ToDouble(txtrangemon.Text)
            res = a / b
            lcpayment.Text = res.ToString
        Catch ex As Exception
        End Try
    End Sub

    Private Sub loadpayroll()
        GridControl2.RefreshDataSource()
        Dim table As New DataTable
        Dim sqlCommand As New MySqlCommand
        Try
            sqlCommand.CommandText = "Select FullName, EmployeeCode, BasicRate FROM db_payrolldata"
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

    Private Sub loadrapel()
        GridControl5.RefreshDataSource()
        Dim table As New DataTable
        Dim sqlcommand As New MySqlCommand
        Try
            sqlcommand.CommandText = "Select FullName, EmployeeCode, RapelRate, EffSince, Until from db_rapel"
            sqlcommand.Connection = SQLConnection
            Dim tbl_par As New DataTable
            Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(table)
            GridControl5.DataSource = table
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub loadloan()
        GridControl7.RefreshDataSource()
        Dim table As New DataTable
        Dim sqlcommand As New MySqlCommand
        Try
            sqlcommand.CommandText = "select FullName, EmployeeCode, AmountOfLoan, FromMonths, PaymentPerMonth, CompletedOn From db_loan "
            sqlcommand.Connection = SQLConnection
            Dim tbl_par As New DataTable
            Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(table)
            GridControl7.DataSource = table
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub loadloanname()
        GridControl1.RefreshDataSource()
        Dim table As New DataTable
        Dim sqlcommand As New MySqlCommand
        Try
            sqlcommand.CommandText = "select FullName, EmployeeCode, AmountOfLoan, Month, Realisasi from db_loanlist where FullName Like '%" + txtloanname.Text + "%'"
            sqlcommand.Connection = SQLConnection
            Dim tbl_par As New DataTable
            Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(table)
            GridControl1.DataSource = table
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub loadpayroll1()
        GridControl4.RefreshDataSource()
        Dim table As New DataTable
        Dim sqlcommand As New MySqlCommand
        Try
            sqlcommand.CommandText = "Select FullName, EmployeeCode, BasicRate FROM db_payrolldata"
            sqlcommand.Connection = SQLConnection
            Dim tbl_par As New DataTable
            Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(table)
            GridControl4.DataSource = table
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        barJudul.Caption = "Loan"
        XtraTabPage3.Show()
        XtraTabPage2.Show()
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        barJudul.Caption = "Rapel"
        XtraTabPage4.Show()
    End Sub

    Private Sub holidays()
        GridControl6.RefreshDataSource()
        Dim table As New DataTable
        Dim sqlcommand As New MySqlCommand
        Try
            sqlcommand.CommandText = "Select StartDate, EndDate, Reason, TotalDays from db_holiday"
            sqlcommand.Connection = SQLConnection
            Dim tbl_par As New DataTable
            Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(table)
            GridControl6.DataSource = table
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Sub countdate()
    '    Dim dtr As DateTime
    '    dtr = CDate(DateEdit1.EditValue)
    '    DateEdit1.Properties.Mask.EditMask = CType(Date.Now, String)
    '    dtr = CDate(DateEdit1.EditValue.ToString)
    '    MsgBox(dtr)
    '    Try
    '        Dim tes As MySqlCommand = SQLConnection.CreateCommand
    '        tes.CommandText = "INSERT INTO test " +
    '                            "(datedd) " +
    '                            "values (@datedd)"
    '        tes.Parameters.AddWithValue("@datedd", dtr.ToString("yyyy-MM-dd HH:mm:ss"))
    '        tes.ExecuteNonQuery()
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub    

    Private Sub LoanForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        'txtyears.Text = Year(Now).ToString
        selectname()
        holidays()
        loaddata()
        loaddata1()
        loadpayroll()
        loadpayroll1()
        loadloan()
        loanlists()
        loadrapel()
        txtmonth.Format = DateTimePickerFormat.Custom
        txtcompletedon1.Format = DateTimePickerFormat.Custom
        txteffective.Format = DateTimePickerFormat.Custom
        txtuntil.Format = DateTimePickerFormat.Custom
        txteffective.CustomFormat = "MMMM yyyy"
        txtuntil.CustomFormat = "MMMM yyyy"
        txtcompletedon1.CustomFormat = "MMMM yyyy"
        txtmonth.CustomFormat = "MMMM yyyy"
    End Sub

    Private Sub txtname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtname.SelectedIndexChanged
        For index As Integer = 0 To tbl_par2.Rows.Count - 1
            If txtname.SelectedItem Is tbl_par2.Rows(index).Item(0).ToString Then
                txtempcode.Text = tbl_par2.Rows(index).Item(1).ToString
            End If
        Next
    End Sub

    Private Sub txtmonths_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim ch As Char = e.KeyChar
        If Char.IsLetter(ch) Then
            e.Handled = True
        End If
    End Sub

    Dim value As Integer = 0

    Sub dateyear()
        Try
            Dim Msg, Number, StartDate As String
            Dim Months As Double
            Dim SecondDate As Date
            Dim IntervalType As DateInterval
            IntervalType = DateInterval.Month
            StartDate = CType((txtmonth.Value), String)
            SecondDate = CDate(StartDate)
            Number = (txtrangemon.Text)
            Months = Val(Number)
            Msg = CType(DateAdd(IntervalType, Months, SecondDate), String)
            txtcompletedon1.Text = Msg
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtamount_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim ch As Char = e.KeyChar
        If Char.IsLetter(ch) Then
            e.Handled = True
        End If
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        barJudul.Caption = "Salary Adjustment"
        XtraTabPage5.Show()
    End Sub

    Private Sub ComboBoxEdit5_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' txtyears.Text = Year(Now).ToString
    End Sub

    Private Sub txtname1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtname1.SelectedIndexChanged
        For index As Integer = 0 To tbl_par.Rows.Count - 1
            If txtname1.SelectedItem Is tbl_par.Rows(index).Item(0).ToString Then
                txtempcode1.Text = tbl_par.Rows(index).Item(1).ToString
            End If
        Next
    End Sub

    Sub cleartxt()
        txtname1.Text = ""
        txtempcode1.Text = ""
        txtwajibpajak.Text = ""
        txtnpwp.Text = ""
        txtbasicrate.Text = ""
        txtallowance.Text = ""
        txtincentives.Text = ""
        txtmealrate.Text = ""
        txttransport.Text = ""
        cjk.Checked = False
        cbpjs.Checked = False
        cjkk.Checked = False
        cjamkem.Checked = False
        cjht.Checked = False
        ciupe.Checked = False
        cbj.Checked = False
        crapel.Checked = False
        cloan.Checked = False
    End Sub

    Sub cleartxt2()
        txtname2.Text = ""
        txtempcode2.Text = ""
        txtwp1.Text = ""
        txtnpwp1.Text = ""
        txtbasicrate1.Text = ""
        txtallowance1.Text = ""
        txtincentives1.Text = ""
        txtmealrate1.Text = ""
        txttransport1.Text = ""
        cjk1.Checked = False
        cbpjs1.Checked = False
        cjkk1.Checked = False
        cjamkem1.Checked = False
        cjht1.Checked = False
        ciupe1.Checked = False
        cbj1.Checked = False
        crapel1.Checked = False
        cloan1.Checked = False
    End Sub

    Private Sub btnapp1_Click(sender As Object, e As EventArgs) Handles btnapp1.Click
        If txtname1.Text = "" OrElse txtempcode1.Text = "" Then
            MsgBox("Please Insert Employee Name Or Employee Code")
        Else
            Insertpart()
            InsertPayroll()
            cleartxt()
        End If
        loadpayroll()
        loadpayroll1()
    End Sub

    Private Sub ComboBoxEdit6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtname2.SelectedIndexChanged
        For index As Integer = 0 To tbl_par2.Rows.Count - 1
            If txtname2.SelectedItem Is tbl_par2.Rows(index).Item(0).ToString Then
                txtempcode2.Text = tbl_par2.Rows(index).Item(1).ToString
                txtwp1.Text = tbl_par2.Rows(index).Item(2).ToString
                txtnpwp1.Text = tbl_par2.Rows(index).Item(3).ToString
                txtbasicrate1.Text = tbl_par2.Rows(index).Item(4).ToString
                txtallowance1.Text = tbl_par2.Rows(index).Item(5).ToString
                txtincentives1.Text = tbl_par2.Rows(index).Item(6).ToString
                txtmealrate1.Text = tbl_par2.Rows(index).Item(7).ToString
                txttransport1.Text = tbl_par2.Rows(index).Item(8).ToString
                cjk1.Checked = CBool(tbl_par2.Rows(index).Item(9).ToString)
                cbpjs1.Checked = CBool(tbl_par2.Rows(index).Item(10).ToString)
                cjkk1.Checked = CBool(tbl_par2.Rows(index).Item(11).ToString)
                cjamkem1.Checked = CBool(tbl_par2.Rows(index).Item(12).ToString)
                cjht1.Checked = CBool(tbl_par2.Rows(index).Item(13).ToString)
                ciupe1.Checked = CBool(tbl_par2.Rows(index).Item(14).ToString)
                cbj1.Checked = CBool(tbl_par2.Rows(index).Item(15).ToString)
                crapel1.Checked = CBool(tbl_par2.Rows(index).Item(16).ToString)
                cloan1.Checked = CBool(tbl_par2.Rows(index).Item(17).ToString)
            End If
        Next
    End Sub

    Dim additional As New Additional

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If txtname2.Text = "" OrElse txtempcode2.Text = "" Then
            MsgBox("Please Input Employee Name Or Employee Code!")
        Else
            Dim mess2 As String
            mess2 = CType(MsgBox("Are you sure to change this employee data?", MsgBoxStyle.YesNo, "Warning"), String)
            If CType(mess2, Global.Microsoft.VisualBasic.MsgBoxResult) = vbYes Then
                updatechange()
                updatepart()
                cleartxt2()
            End If
            'Dim mess As String
            'mess = CType(MsgBox("Is there any additionals or deductions left?", MsgBoxStyle.YesNo, "Warning"), String)
            'If CType(mess, Global.Microsoft.VisualBasic.MsgBoxResult) = vbYes Then
            '    If additional Is Nothing OrElse additional.IsDisposed Then
            '        additional = New Additional
            '    End If
            '    additional.Show()
            'Else
            'End If
        End If
        loadpayroll1()
        loadpayroll()
    End Sub

    Private Sub CheckEdit2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit2.CheckedChanged
        If CheckEdit2.Checked = True Then
            txtmonth.Enabled = True
        Else
            txtmonth.Enabled = False
        End If
    End Sub

    Private Sub btnApp_Click(sender As Object, e As EventArgs) Handles btnApp.Click
        If txtname.Text = "" OrElse txtempcode.Text = "" Then
            MsgBox("Please Insert Employee Name Or Employee Code!")
        Else
            InsertLoan()
            UpdateLoan()
        End If
        loadloan()
        'loadloanname()
    End Sub

    Private Sub txtrangemon_EditValueChanged(sender As Object, e As EventArgs) Handles txtrangemon.EditValueChanged
        loanpay()
        dateyear()
    End Sub

    Dim closer As New ClosePayroll

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        If closer Is Nothing OrElse closer.IsDisposed OrElse closer.MinimizeBox Then
            closer.Close()
            closer = New ClosePayroll
        End If
        closer.Show()
    End Sub

    Dim proses As New PayrollSet

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        If proses Is Nothing OrElse proses.IsDisposed OrElse proses.MinimizeBox Then
            proses.Close()
            proses = New PayrollSet
        End If
        proses.Show()
    End Sub

    Private Sub txtname3_SelectedIndexChanged(sender As Object, e As EventArgs)
        For index As Integer = 0 To tbl_par2.Rows.Count - 1
            If txtname3.SelectedItem Is tbl_par2.Rows(index).Item(0).ToString Then
                txtempcode3.Text = tbl_par2.Rows(index).Item(1).ToString
            End If
        Next
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        XtraTabPage6.Show()
    End Sub

    Sub reset()
        txtname3.Text = ""
        txtempcode3.Text = ""
        txtrapel.Text = ""
        txteffective.Text = ""
        txtuntil.Text = ""
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        If txtname3.Text = "" Or txtempcode3.Text = "" Then
            MsgBox("Please Insert Employee Code Or Employee Name")
        Else
            insertrapel2()
            UpdateRapel()
            reset()
        End If
        loadrapel()
    End Sub

    Dim value1, value2 As Integer

    Private Sub txtuntil_SelectedIndexChanged(sender As Object, e As EventArgs)
        If txtuntil.Text = "January" Then
            value2 = 1
        ElseIf txtuntil.Text = "February" Then
            value2 = 2
        ElseIf txtuntil.Text = "March" Then
            value2 = 3
        ElseIf txtuntil.Text = "April" Then
            value2 = 4
        ElseIf txtuntil.Text = "May" Then
            value2 = 5
        ElseIf txtuntil.Text = "June" Then
            value2 = 6
        ElseIf txtuntil.Text = "July" Then
            value2 = 7
        ElseIf txtuntil.Text = "August" Then
            value2 = 8
        ElseIf txtuntil.Text = "September" Then
            value2 = 9
        ElseIf txtuntil.Text = "October" Then
            value2 = 10
        ElseIf txtuntil.Text = "November" Then
            value2 = 11
        Else
            value2 = 12
        End If
    End Sub

    Private Sub txtloanname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtloanname.SelectedIndexChanged
        For index As Integer = 0 To tbl_par3.Rows.Count - 1
            If txtloanname.SelectedItem Is tbl_par3.Rows(index).Item(0).ToString Then
            End If
        Next
    End Sub

    Private Sub btnLookup_Click(sender As Object, e As EventArgs) Handles btnLookup.Click
        If txtloanname.Text = "" Then
            MsgBox("Please insert the employee name")
        Else
            loadloanname()
        End If
    End Sub

    Dim act As String = ""

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        Dim datatabl As New DataTable
        Dim sqlCommand As New MySqlCommand
        datatabl.Clear()
        Dim param As String = ""
        Try
            param = "And EmployeeCode='" + GridView1.GetFocusedRowCellValue("EmployeeCode").ToString() + "'"
        Catch ex As Exception
        End Try
        If param > "" Then
            act = "edit"
        Else
            act = "input"
        End If
        Try
            sqlCommand.CommandText = "SELECT FullName, EmployeeCode FROM db_loan WHERE 1 = 1 " + param.ToString()
            sqlCommand.Connection = SQLConnection
            Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(datatabl)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        If datatabl.Rows.Count > 0 Then
            txtloanname.Text = datatabl.Rows(0).Item(0).ToString()
            txtempcode.Text = datatabl.Rows(0).Item(1).ToString()
        End If
    End Sub

    Dim pay As New Payslip

    Private Sub BarButtonItem8_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem8.ItemClick
        If pay Is Nothing OrElse pay.IsDisposed OrElse pay.MinimizeBox Then
            pay.Close()
            pay = New Payslip
        End If
        pay.Show()
    End Sub

    Private Sub txtbasicrate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtbasicrate.KeyPress
        Dim ch As Char = e.KeyChar
        If Char.IsLetter(ch) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtallowance_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtallowance.KeyPress
        Dim ch As Char = e.KeyChar
        If Char.IsLetter(ch) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtincentives_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtincentives.KeyPress
        Dim ch As Char = e.KeyChar
        If Char.IsLetter(ch) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtmealrate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtmealrate.KeyPress
        Dim ch As Char = e.KeyChar
        If Char.IsLetter(ch) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txttransport_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttransport.KeyPress
        Dim ch As Char = e.KeyChar
        If Char.IsLetter(ch) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txteffective_SelectedIndexChanged(sender As Object, e As EventArgs)
        If txteffective.Text = "January" Then
            value = 0
        ElseIf txteffective.Text = "February" Then
            value = 1
        ElseIf txteffective.Text = "March" Then
            value = 2
        ElseIf txteffective.Text = "April" Then
            value = 3
        ElseIf txteffective.Text = "May" Then
            value = 4
        ElseIf txteffective.Text = "June" Then
            value = 5
        ElseIf txteffective.Text = "July" Then
            value = 6
        ElseIf txteffective.Text = "August" Then
            value = 7
        ElseIf txteffective.Text = "September" Then
            value = 8
        ElseIf txteffective.Text = "October" Then
            value = 9
        ElseIf txteffective.Text = "November" Then
            value = 10
        Else
            value = 11
        End If
    End Sub

    Sub completedloan()
        Dim sqlcommand As New MySqlCommand
        Try
            sqlcommand.CommandText = "UPDATE db_payrolldata SET" +
                                    " Loan = @Loan" +
                                    "WHERE EmployeeCode = @EmployeeCode "
            sqlcommand.Connection = SQLConnection
            sqlcommand.Parameters.AddWithValue("@EmployeeCode", txtempcode.Text)
            sqlcommand.Parameters.AddWithValue("@Loan", "1")
            sqlcommand.Connection = SQLConnection
            sqlcommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub paid()
        Dim cmd As MySqlCommand = SQLConnection.CreateCommand
        cmd.CommandText = "update db_loanlist set realisasi = 'PAID' where employeecode = @ec"
        cmd.Parameters.AddWithValue("@ec", txtnameloan.Text)
        cmd.ExecuteNonQuery()
    End Sub

    Sub settling()
        Dim cmd As MySqlCommand = SQLConnection.CreateCommand
        Dim mess As String
        Dim name As MySqlCommand = SQLConnection.CreateCommand
        name.CommandText = "select fullname from db_loan where employeecode = @ec"
        name.Parameters.AddWithValue("@ec", txtnameloan.Text)
        Dim rname As String = CStr(name.ExecuteScalar)
        mess = CType(MsgBox("Sure to clear this employee named  " & rname & " with employee code " & txtnameloan.Text & "?", MsgBoxStyle.YesNo, "Warning"), String)
        If CType(mess, Global.Microsoft.VisualBasic.MsgBoxResult) = vbYes Then
            paid()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New MySqlParameter("@empcode", txtnameloan.Text))
            cmd.CommandText = "deleteloan"
            cmd.ExecuteNonQuery()
            MsgBox("Data successfully removed", MsgBoxStyle.Information, "Success")
        End If
    End Sub

    Sub updatedloan()
        Dim conn As New MySqlConnection(connectionString)
        Dim cmd As MySqlCommand = conn.CreateCommand
        conn.Open()
        cmd.CommandText = "update db_payrolldata set loan = 0 where employeecode = @emp"
        cmd.Parameters.AddWithValue("@emp", txtnameloan.Text)
        cmd.ExecuteNonQuery()
        conn.Close()
    End Sub

    Private Sub txtnameloan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtnameloan.SelectedIndexChanged
        loanlists()
        For index As Integer = 0 To tbl_par3.Rows.Count - 1
            If txtnameloan.SelectedItem Is tbl_par3.Rows(index).Item(1).ToString Then
            End If
        Next
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Call complete()
    End Sub

    Private Sub btnProcess_Click(sender As Object, e As EventArgs) Handles btnProcess.Click
        days()
        If date1.Text = "" Then
            MsgBox("Please Input The Start Date")
        ElseIf date1.Value > date2.Value Then
            MsgBox("Total days can't be zero or less than zero days")
        ElseIf txtreason.Text = "" Then
            MsgBox("Please insert the reason of the holiday")
        Else
            Process()
            holidays()
        End If
    End Sub

    Sub days()
        Dim t As TimeSpan = date2.Value - date1.Value
        Dim tmp As String
        tmp = t.Days.ToString
        Dim hasil As Integer
        hasil = CInt(tmp)
        Dim hasil2 As Integer = hasil + 1
        txtdays.Text = hasil2.ToString
    End Sub

    Private Sub date2_ValueChanged(sender As Object, e As EventArgs) Handles date2.ValueChanged
        days()
    End Sub

    Private Sub SimpleButton3_Click_1(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        If txtnameloan.Text = "" Then
            MsgBox("Please Input The EmployeeCode To The Field!")
        Else
            Call settling()
            updatedloan()
            loadloan()
            txtnameloan.Text = ""
        End If
    End Sub

    Private Sub txtname3_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles txtname3.SelectedIndexChanged
        For index As Integer = 0 To tbl_par2.Rows.Count - 1
            If txtname3.SelectedItem Is tbl_par2.Rows(index).Item(0).ToString Then
                txtempcode3.Text = tbl_par2.Rows(index).Item(1).ToString
            End If
        Next
    End Sub

    Private Sub GridView4_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView4.FocusedRowChanged
        Dim datatabl As New DataTable
        Dim sqlCommand As New MySqlCommand
        datatabl.Clear()
        Dim param As String = ""
        Try
            param = "and EmployeeCode='" + GridView4.GetFocusedRowCellValue("EmployeeCode").ToString() + "'"
        Catch ex As Exception
        End Try
        Try
            sqlCommand.CommandText = "SELECT FullName, EmployeeCode, StatusWajibPajak, MemilikiNpwp, BasicRate, Allowance, Incentives, MealRate, Transport, JaminanKesehatan, Bpjs, JaminanKecelakaanKerja, JaminanKematian, JaminanHariTua, IuranPensiun, BiayaJabatan, Rapel, Loan from db_payrolldata WHERE 1=1 " + param.ToString()
            sqlCommand.Connection = SQLConnection
            Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(datatabl)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If datatabl.Rows.Count > 0 Then
            txtname2.Text = datatabl.Rows(0).Item(0).ToString()
            txtempcode2.Text = datatabl.Rows(0).Item(1).ToString()
            txtwp1.Text = datatabl.Rows(0).Item(2).ToString()
            txtnpwp1.Text = datatabl.Rows(0).Item(3).ToString()
            txtbasicrate1.Text = datatabl.Rows(0).Item(4).ToString()
            txtallowance1.Text = datatabl.Rows(0).Item(5).ToString()
            txtincentives1.Text = datatabl.Rows(0).Item(6).ToString()
            txtmealrate1.Text = datatabl.Rows(0).Item(7).ToString()
            txttransport1.Text = datatabl.Rows(0).Item(8).ToString()
            cjk1.Checked = CBool(datatabl.Rows(0).Item(9).ToString)
            cbpjs1.Checked = CBool(datatabl.Rows(0).Item(10).ToString)
            cjkk1.Checked = CBool(datatabl.Rows(0).Item(11).ToString)
            cjamkem1.Checked = CBool(datatabl.Rows(0).Item(12).ToString)
            cjht1.Checked = CBool(datatabl.Rows(0).Item(13).ToString)
            ciupe1.Checked = CBool(datatabl.Rows(0).Item(14).ToString)
            cbj1.Checked = CBool(datatabl.Rows(0).Item(15).ToString)
            crapel1.Checked = CBool(datatabl.Rows(0).Item(16).ToString)
            cloan1.Checked = CBool(datatabl.Rows(0).Item(17).ToString)
        End If
    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If txtname3.Text = "" Or txtempcode3.Text = "" Then
            MsgBox("Please Insert Employee Code Or Employee Name")
        Else
            insertrapel2()
            UpdateRapel()
            reset()
        End If
        loadrapel()
    End Sub

    Private Sub GridView6_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GridView6.PopupMenuShowing
        Dim view As GridView = CType(sender, GridView)
        If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Row Then
            Dim rowHandle As Integer = e.HitInfo.RowHandle
            e.Menu.Items.Clear()
            Dim item As DXMenuItem = CreateMergingEnabledMenuItem(view, rowHandle)
            item.BeginGroup = True
            e.Menu.Items.Add(item)
        End If
    End Sub

    Private Sub GridView2_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GridView2.PopupMenuShowing
        Dim view As GridView = CType(sender, GridView)
        If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Row Then
            Dim rowHandle As Integer = e.HitInfo.RowHandle
            e.Menu.Items.Clear()
            Dim item As DXMenuItem = CreateMergingEnabledMenuItem(view, rowHandle)
            item.BeginGroup = True
            e.Menu.Items.Add(item)
        End If
    End Sub

    Private Sub GridView4_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GridView4.PopupMenuShowing
        Dim view As GridView = CType(sender, GridView)
        If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Row Then
            Dim rowHandle As Integer = e.HitInfo.RowHandle
            e.Menu.Items.Clear()
            Dim item As DXMenuItem = CreateMergingEnabledMenuItem(view, rowHandle)
            item.BeginGroup = True
            e.Menu.Items.Add(item)
        End If
    End Sub

    Private Sub GridView1_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView1.PopupMenuShowing
        Dim view As GridView = CType(sender, GridView)
        If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Row Then
            Dim rowHandle As Integer = e.HitInfo.RowHandle
            e.Menu.Items.Clear()
            Dim item As DXMenuItem = CreateMergingEnabledMenuItem(view, rowHandle)
            item.BeginGroup = True
            e.Menu.Items.Add(item)
        End If
    End Sub

    Private Sub GridView7_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView7.PopupMenuShowing
        Dim view As GridView = CType(sender, GridView)
        If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Row Then
            Dim rowHandle As Integer = e.HitInfo.RowHandle
            e.Menu.Items.Clear()
            Dim item As DXMenuItem = CreateMergingEnabledMenuItem(view, rowHandle)
            item.BeginGroup = True
            e.Menu.Items.Add(item)
        End If
    End Sub

    Private Sub GridView5_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView5.PopupMenuShowing
        Dim view As GridView = CType(sender, GridView)
        If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Row Then
            Dim rowHandle As Integer = e.HitInfo.RowHandle
            e.Menu.Items.Clear()
            Dim item As DXMenuItem = CreateMergingEnabledMenuItem(view, rowHandle)
            item.BeginGroup = True
            e.Menu.Items.Add(item)
        End If
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        GroupControl6.Visible = True
    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        GroupControl6.Visible = False
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

    Private Sub GridView8_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView8.FocusedRowChanged
        Dim datatabl As New DataTable
        Dim sqlCommand As New MySqlCommand
        datatabl.Clear()
        Dim param As String = ""
        Try
            param = "and EmployeeCode='" + GridView8.GetFocusedRowCellValue("EmployeeCode").ToString() + "'"
        Catch ex As Exception
        End Try
        Try
            sqlCommand.CommandText = "SELECT Photo, FullName from db_pegawai WHERE 1=1 " + param.ToString()
            sqlCommand.Connection = SQLConnection
            Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(datatabl)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If datatabl.Rows.Count > 0 Then
            Dim filefoto As Byte() = CType(datatabl.Rows(0).Item(0), Byte())
            If filefoto.Length > 0 Then
                PictureBox1.Image = ByteToImage(filefoto)
            Else
                PictureBox1.Image = Nothing
                PictureBox1.Refresh()
            End If
        End If
        txtname.SelectedItem = (datatabl.Rows(0).Item(1).ToString)
        txtname3.SelectedItem = (datatabl.Rows(0).Item(1).ToString)
    End Sub

    Private Sub GridView8_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView8.PopupMenuShowing
        Dim view As GridView = CType(sender, GridView)
        If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Row Then
            Dim rowHandle As Integer = e.HitInfo.RowHandle
            e.Menu.Items.Clear()
            Dim item As DXMenuItem = CreateMergingEnabledMenuItem(view, rowHandle)
            item.BeginGroup = True
            e.Menu.Items.Add(item)
        End If
        If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Row Then
            e.Menu.Items.Add(New DXMenuItem("Select Employee", New EventHandler(AddressOf SimpleButton7_Click)))
        End If
    End Sub

    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs) Handles SimpleButton8.Click
        selectname()
    End Sub

    Dim form As New Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If form Is Nothing OrElse form.IsDisposed OrElse form.MinimizeBox Then
            form.Close()
            form = New Form1
        End If
        form.Show()
    End Sub

    Private Sub txtmonth_ValueChanged(sender As Object, e As EventArgs) Handles txtmonth.ValueChanged
        dateyear()
    End Sub

    Sub updateloanlist()
        Dim count As MySqlCommand = SQLConnection.CreateCommand
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs)
        selectname()
    End Sub

    Private Sub SimpleButton9_Click(sender As Object, e As EventArgs) Handles SimpleButton9.Click
        GroupControl6.Visible = True
    End Sub

    Private Sub txtcompletedon1_ValueChanged(sender As Object, e As EventArgs) Handles txtcompletedon1.ValueChanged
        dateyear()
    End Sub

    Private Sub txtloan_EditValueChanged(sender As Object, e As EventArgs) Handles txtloan.EditValueChanged
        loanpay()
        dateyear()
    End Sub

    Private Sub date1_ValueChanged(sender As Object, e As EventArgs) Handles date1.ValueChanged
        days()
    End Sub

    Sub complete()
        Dim count As MySqlCommand = SQLConnection.CreateCommand
        count.CommandText = "select count(*) from db_loanlist where realisasi = curdate()"
        Dim xcount As Integer = CInt(count.ExecuteScalar)
        If xcount = 0 Then
            MsgBox("There's no data")
        Else
            Dim sqlcommand As New MySqlCommand
            sqlcommand.CommandType = CommandType.StoredProcedure
            sqlcommand.CommandText = "completedloan"
            Dim p1 As New MySqlParameter
            p1.ParameterName = "@empcode"
            p1.Value = txtnameloan.Text
            sqlcommand.Parameters.Add(p1)
            sqlcommand.Connection = SQLConnection
        End If
    End Sub
End Class