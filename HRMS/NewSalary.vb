Imports System.IO
Imports System.Windows.Controls

Public Class NewSalary

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

    Sub reset()
        lcnama.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcemployeecode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lccompanycode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcnames.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcnames.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcpayment.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcstatpajak.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcnpwp.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcbasicrate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcallowance.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcincentives.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcmeal.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lctransport.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcdesc1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcdesc2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcdesc3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcdesc4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcdesc5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcadd1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcadd2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcadd3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcadd4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcadd5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcothours.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcottype.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lctaxes.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcloan.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lclates.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcbpjs.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcjkk.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcpjk.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcjht.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcbj.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcip.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcpjkk.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcppjk.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcpjht.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcpbj.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcpip.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcrapel.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcfm.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lctm.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
    End Sub

    Public Sub updatechange()
        SQLConnection = New MySqlConnection
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        Dim sqlcommand As New MySqlCommand
        Try
            sqlcommand.CommandText = "UPDATE db_payroll SET" +
                    " CompanyCode = @CompanyCode" +
                    ", FullName = @FullName" +
                    ", PaymentDate = @PaymentDate" +
                    ", BasicRate = @BasicRate" +
                    ", Allowance = @Allowance" +
                    ", Incentives = @Incentives" +
                    ", TableMoney = @TableMoney" +
                    ", Transport = @Transport" +
                    ", OtherAdditionalAllowance1 = @OtherAdditionalAllowance1" +
                    ", OtherAdditionalAllowance2 = @OtherAdditionalAllowance2" +
                    ", OtherAdditionalAllowance3 = @OtherAdditionalAllowance3" +
                    ", OtherAdditionalAllowance4 = @OtherAdditionalAllowance4" +
                    ", OtherAdditionalAllowance5 = @OtherAdditionalAllowance5" +
                    ", AdditionalAllowance1 = @AdditionalAllowance1" +
                    ", AdditionalAllowance2 = @AdditionalAllowance2" +
                    ", AdditionalAllowance3 = @AdditionalAllowance3" +
                    ", AdditionalAllowance4 = @AdditionalAllowance4" +
                    ", AdditionalAllowance5 = @AdditionalAllowance5" +
                    ", OvertimeHours = @OvertimeHours" +
                    ", OvertimeType = @OvertimeType" +
                    ", BpjsPercentage = @BpjsPercentage" +
                    ", Taxes = @Taxes" +
                    ", Loan = @Loan" +
                    ", Lates = @Lates" +
                    ", OtherAdditionalDeduction1 = @OtherAdditionalDeduction1" +
                    ", OtherAdditionalDeduction2 = @OtherAdditionalDeduction2" +
                    ", OtherAdditionalDeduction3 = @OtherAdditionalDeduction3" +
                    ", OtherAdditionalDeduction4 = @OtherAdditionalDeduction4" +
                    ", OtherAdditionalDeduction5 = @OtherAdditionalDeduction5" +
                    ", AdditionalDeduction1 = @AdditionalDeduction1" +
                    ", AdditionalDeduction2 = @AdditionalDeduction2" +
                    ", AdditionalDeduction3 = @AdditionalDeduction3" +
                    ", AdditionalDeduction4 = @AdditionalDeduction4" +
                    ", AdditionalDeduction5 = @AdditionalDeduction5" +
                    ", ResJaminanKecelakaanKerja = @ResJaminanKecelakaanKerja" +
                    ", ResPremiJaminanKematian = @ResPremiJaminanKematian" +
                    ", ResJaminanHariTua = @ResJaminanHariTua" +
                    ", ResBiayaJabatan = @ResBiayaJabatan" +
                    ", ResIuranPensiun = @ResIuranPensiun" +
                    ", PersenKk = @PersenKk" +
                    ", PersenJk = @PersenJk" +
                    ", PersenJht = @PersenJht" +
                    ", PersenBj = @PersenBj" +
                    ", PersenIp = @PersenIp" +
                    ", MemilikiNpwp = @MemilikiNpwp" +
                    ", Gross = @Gross" +
                    ", Bpjs = @Bpjs" +
                    ", OvertimeSalary = @OvertimeSalary" +
                    ", TotalDeductions = @TotalDeductions" +
                    ", NetIncome = @NetIncome" +
                    ", PenghasilanKenaPajak = @PenghasilanKenaPajak" +
                    ", JaminanKecelakaanKerja = @JaminanKecelakaanKerja" +
                    ", PremiJaminanKematian = @PremiJaminanKematian" +
                    ", JaminanHariTua = @JaminanHariTua" +
                    ", PphTerhutang = @PphTerhutang" +
                    ", BiayaJabatan = @BiayaJabatan" +
                    ", IuranPensiun = @IuranPensiun" +
                    ", NettoSetahun = @NettoSetahun" +
                    ", StatusWajibPajak = @StatusWajibPajak" +
                    ", RapelFromMonth = @RapelFromMonth" +
                    ", RapelToMonth = @RapelToMonth" +
                    ", RapelRate = @RapelRate" +
                    ", Rapel = @Rapel" +
                    ", PajakPphPerTahun = @PajakPphPerTahun" +
                    " WHERE EmployeeCode = @EmployeeCode"
            sqlcommand.Connection = SQLConnection
            sqlcommand.Parameters.AddWithValue("@EmployeeCode", txtempcode.Text)
            sqlcommand.Parameters.AddWithValue("@CompanyCode", txtcompcode.Text)
            sqlcommand.Parameters.AddWithValue("@FullName", txtnames.Text)
            sqlcommand.Parameters.AddWithValue("@PaymentDate", txtpayment.Text)
            sqlcommand.Parameters.AddWithValue("@BasicRate", txtbasicrate.Text)
            sqlcommand.Parameters.AddWithValue("@Allowance", txtallowance.Text)
            sqlcommand.Parameters.AddWithValue("@Incentives", txtincentives.Text)
            sqlcommand.Parameters.AddWithValue("@TableMoney", txtmeal.Text)
            sqlcommand.Parameters.AddWithValue("@Transport", txttransport.Text)
            sqlcommand.Parameters.AddWithValue("@OtherAdditionalAllowance1", txtdesc1.Text)
            sqlcommand.Parameters.AddWithValue("@OtherAdditionalAllowance2", txtdesc2.Text)
            sqlcommand.Parameters.AddWithValue("@OtherAdditionalAllowance3", txtdesc3.Text)
            sqlcommand.Parameters.AddWithValue("@OtherAdditionalAllowance4", txtdesc4.Text)
            sqlcommand.Parameters.AddWithValue("@OtherAdditionalAllowance5", txtdesc5.Text)
            sqlcommand.Parameters.AddWithValue("@AdditionalAllowance1", txtadd1.Text)
            sqlcommand.Parameters.AddWithValue("@AdditionalAllowance2", txtadd2.Text)
            sqlcommand.Parameters.AddWithValue("@AdditionalAllowance3", txtadd3.Text)
            sqlcommand.Parameters.AddWithValue("@AdditionalAllowance4", txtadd4.Text)
            sqlcommand.Parameters.AddWithValue("@AdditionalAllowance5", txtadd5.Text)
            sqlcommand.Parameters.AddWithValue("@OvertimeHours", txtothours.Text)
            sqlcommand.Parameters.AddWithValue("@OvertimeType", txtottype.Text)
            sqlcommand.Parameters.AddWithValue("@BpjsPercentage", txtbpjs.Text)
            sqlcommand.Parameters.AddWithValue("@Taxes", txttaxes.Text)
            sqlcommand.Parameters.AddWithValue("@Loan", txtloan.Text)
            sqlcommand.Parameters.AddWithValue("@Lates", txtlates.Text)
            sqlcommand.Parameters.AddWithValue("@OtherAdditionalDeduction1", txtdesc11.Text)
            sqlcommand.Parameters.AddWithValue("@OtherAdditionalDeduction2", txtdesc22.Text)
            sqlcommand.Parameters.AddWithValue("@OtherAdditionalDeduction3", txtdesc33.Text)
            sqlcommand.Parameters.AddWithValue("@OtherAdditionalDeduction4", txtdesc44.Text)
            sqlcommand.Parameters.AddWithValue("@OtherAdditionalDeduction5", txtdesc55.Text)
            sqlcommand.Parameters.AddWithValue("@AdditionalDeduction1", txtded1.Text)
            sqlcommand.Parameters.AddWithValue("@AdditionalDeduction2", txtded2.Text)
            sqlcommand.Parameters.AddWithValue("@AdditionalDeduction3", txtded3.Text)
            sqlcommand.Parameters.AddWithValue("@AdditionalDeduction4", txtded4.Text)
            sqlcommand.Parameters.AddWithValue("@AdditionalDeduction5", txtded5.Text)
            sqlcommand.Parameters.AddWithValue("@ResJaminanKecelakaanKerja", txtjkk.Text)
            sqlcommand.Parameters.AddWithValue("@ResPremiJaminanKematian", txtpjk.Text)
            sqlcommand.Parameters.AddWithValue("@ResJaminanHariTua", txtjht.Text)
            sqlcommand.Parameters.AddWithValue("@ResBiayajabatan", txtbj.Text)
            sqlcommand.Parameters.AddWithValue("@ResIuranPensiun", txtip.Text)
            sqlcommand.Parameters.AddWithValue("@PersenKk", txtpkk.Text)
            sqlcommand.Parameters.AddWithValue("@PersenJk", txtppjk.Text)
            sqlcommand.Parameters.AddWithValue("@PersenJht", txtpjht.Text)
            sqlcommand.Parameters.AddWithValue("@PersenBj", txtpbj.Text)
            sqlcommand.Parameters.AddWithValue("@PersenIp", txtpip.Text)
            sqlcommand.Parameters.AddWithValue("@MemilikiNpwp", txtnpwp.Text)
            sqlcommand.Parameters.AddWithValue("@Gross", txtgross.Text)
            sqlcommand.Parameters.AddWithValue("@Bpjs", txtresbpjs.Text)
            sqlcommand.Parameters.AddWithValue("@OvertimeSalary", txtots.Text)
            sqlcommand.Parameters.AddWithValue("@TotalDeductions", txtded.Text)
            sqlcommand.Parameters.AddWithValue("@Netincome", txtnetincome.Text)
            sqlcommand.Parameters.AddWithValue("@PenghasilanKenaPajak", txtpkp.Text)
            sqlcommand.Parameters.AddWithValue("@JaminanKecelakaanKerja", txtresjkk.Text)
            sqlcommand.Parameters.AddWithValue("@PremiJaminanKematian", txtpremi.Text)
            sqlcommand.Parameters.AddWithValue("@JaminanHariTua", txtresjht.Text)
            sqlcommand.Parameters.AddWithValue("@PphTerhutang", txtpph.Text)
            sqlcommand.Parameters.AddWithValue("@BiayaJabatan", txtresbj.Text)
            sqlcommand.Parameters.AddWithValue("@IuranPensiun", txtresip.Text)
            sqlcommand.Parameters.AddWithValue("@NettoSetahun", txtnetto.Text)
            sqlcommand.Parameters.AddWithValue("@StatusWajibPajak", txtwp.Text)
            sqlcommand.Parameters.AddWithValue("@RapelFromMonth", frommonth.Text)
            sqlcommand.Parameters.AddWithValue("@RapelToMonth", tomonth.Text)
            sqlcommand.Parameters.AddWithValue("@RapelRate", txtresrapel.Text)
            sqlcommand.Parameters.AddWithValue("@Rapel", txtrapel.Text)
            sqlcommand.Parameters.AddWithValue("@PajakPphPerTahun", txtpajak.Text)
            sqlcommand.Connection = SQLConnection
            sqlcommand.ExecuteNonQuery()
            MessageBox.Show("Data Successfully Changed!")
        Catch ex As Exception
            MsgBox("Error Occured: Could Not Change Records")
        End Try
    End Sub

    Sub cleartxt()
        txtnama.Text = ""
        txtempcode.Text = ""
        txtcompcode.Text = ""
        txtnames.Text = ""
        txtpayment.Text = ""
        txtwp.Text = ""
        txtnpwp.Text = ""
        txtbasicrate.Text = ""
        txtallowance.Text = ""
        txtincentives.Text = ""
        txtmeal.Text = ""
        txttransport.Text = ""
        txtdesc1.Text = ""
        txtdesc2.Text = ""
        txtdesc3.Text = ""
        txtdesc4.Text = ""
        txtdesc5.Text = ""
        txtadd1.Text = ""
        txtadd2.Text = ""
        txtadd3.Text = ""
        txtadd4.Text = ""
        txtadd5.Text = ""
        txtothours.Text = ""
        txtottype.Text = ""
        txttaxes.Text = ""
        txtloan.Text = ""
        txtlates.Text = ""
        txtbpjs.Text = ""
        txtjkk.Text = ""
        txtpjk.Text = ""
        txtjht.Text = ""
        txtbj.Text = ""
        txtip.Text = ""
        txtpkk.Text = ""
        txtppjk.Text = ""
        txtpjht.Text = ""
        txtpbj.Text = ""
        txtpip.Text = ""
        txtdesc11.Text = ""
        txtdesc22.Text = ""
        txtdesc33.Text = ""
        txtdesc44.Text = ""
        txtdesc55.Text = ""
        txtded1.Text = ""
        txtded2.Text = ""
        txtded3.Text = ""
        txtded4.Text = ""
        txtded5.Text = ""
        txtrapel.Text = ""
        frommonth.Text = ""
        tomonth.Text = ""
    End Sub

    Public Function InsertReq() As Boolean
        SQLConnection = New MySqlConnection()
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        Dim sqlCommand As New MySqlCommand
        Dim str_carSql As String
        Try
            str_carSql = "INSERT INTO db_payroll " +
                            "(EmployeeCode, CompanyCode, FullName, PaymentDate, BasicRate, Allowance, Incentives, TableMoney, Transport, OtherAdditionalAllowance1, OtherAdditionalAllowance2, OtherAdditionalAllowance3, OtherAdditionalAllowance4, OtherAdditionalAllowance5, AdditionalAllowance1, AdditionalAllowance2, AdditionalAllowance3, AdditionalAllowance4, AdditionalAllowance5, OvertimeHours, OvertimeType, BpjsPercentage, Taxes, Loan, Lates, OtherAdditionalDeduction1, OtherAdditionalDeduction2, OtherAdditionalDeduction3, OtherAdditionalDeduction4, OtherAdditionalDeduction5, AdditionalDeduction1, AdditionalDeduction2, AdditionalDeduction3, AdditionalDeduction4, AdditionalDeduction5, ResJaminanKecelakaanKerja, ResPremiJaminanKematian, ResJaminanHariTua, ResBiayaJabatan, ResIuranPensiun, PersenKk, PersenJk, PersenJht, PersenBj, PersenIp, MemilikiNpwp, Gross, Bpjs, OvertimeSalary, TotalDeductions, NetIncome, PenghasilanKenaPajak, JaminanKecelakaanKerja, PremiJaminanKematian, JaminanHariTua, PphTerhutang, BiayaJabatan, IuranPensiun, NettoSetahun, StatusWajibPajak, RapelFromMonth, RapelToMonth, RapelRate, Rapel, PajakPphPerTahun) " +
                            "values (@EmployeeCode, @CompanyCode, @FullName, @PaymentDate, @BasicRate, @Allowance, @Incentives, @TableMoney, @Transport, @OtherAdditionalAllowance1, @OtherAdditionalAllowance2, @OtherAdditionalAllowance3, @OtherAdditionalAllowance4, @OtherAdditionalAllowance5, @AdditionalAllowance1, @AdditionalAllowance2, @AdditionalAllowance3, @AdditionalAllowance4, @AdditionalAllowance5, @OvertimeHours, @OvertimeType, @BpjsPercentage, @Taxes, @Loan, @Lates, @OtherAdditionalDeduction1, @OtherAdditionalDeduction2, @OtherAdditionalDeduction3, @OtherAdditionalDeduction4, @OtherAdditionalDeduction5, @AdditionalDeduction1, @AdditionalDeduction2, @AdditionalDeduction3, @AdditionalDeduction4, @AdditionalDeduction5, @ResJaminanKecelakaanKerja, @ResPremiJaminanKematian, @ResJaminanHariTua, @ResBiayaJabatan, @ResIuranPensiun, @PersenKk, @PersenJk, @PersenJht, @PersenBj, @PersenIp, @MemilikiNpwp, @Gross, @Bpjs, @OvertimeSalary, @TotalDeductions, @NetIncome, @PenghasilanKenaPajak, @JaminanKecelakaanKerja, @PremiJaminanKematian, @JaminanHariTua, @PphTerhutang, @BiayaJabatan, @IuranPensiun, @NettoSetahun, @StatusWajibPajak, @RapelFromMonth, @RapelToMonth, @RapelRate, @Rapel, @PajakPphPerTahun)"
            sqlCommand.Connection = SQLConnection
            sqlCommand.CommandText = str_carSql
            sqlCommand.Parameters.AddWithValue("@EmployeeCode", txtempcode.Text)
            sqlCommand.Parameters.AddWithValue("@CompanyCode", txtcompcode.Text)
            sqlCommand.Parameters.AddWithValue("@FullName", txtnama.Text)
            sqlCommand.Parameters.AddWithValue("@PaymentDate", txtpayment.Text)
            sqlCommand.Parameters.AddWithValue("@BasicRate", txtbasicrate.Text)
            sqlCommand.Parameters.AddWithValue("@Allowance", txtallowance.Text)
            sqlCommand.Parameters.AddWithValue("@Incentives", txtincentives.Text)
            sqlCommand.Parameters.AddWithValue("@TableMoney", txtmeal.Text)
            sqlCommand.Parameters.AddWithValue("@Transport", txttransport.Text)
            sqlCommand.Parameters.AddWithValue("@OtherAdditionalAllowance1", txtdesc1.Text)
            sqlCommand.Parameters.AddWithValue("@OtherAdditionalAllowance2", txtdesc2.Text)
            sqlCommand.Parameters.AddWithValue("@OtherAdditionalAllowance3", txtdesc3.Text)
            sqlCommand.Parameters.AddWithValue("@OtherAdditionalAllowance4", txtdesc4.Text)
            sqlCommand.Parameters.AddWithValue("@OtherAdditionalAllowance5", txtdesc5.Text)
            sqlCommand.Parameters.AddWithValue("@AdditionalAllowance1", txtadd1.Text)
            sqlCommand.Parameters.AddWithValue("@AdditionalAllowance2", txtadd2.Text)
            sqlCommand.Parameters.AddWithValue("@AdditionalAllowance3", txtadd3.Text)
            sqlCommand.Parameters.AddWithValue("@AdditionalAllowance4", txtadd4.Text)
            sqlCommand.Parameters.AddWithValue("@AdditionalAllowance5", txtadd5.Text)
            sqlCommand.Parameters.AddWithValue("@OvertimeHours", txtothours.Text)
            sqlCommand.Parameters.AddWithValue("@OvertimeType", txtottype.Text)
            sqlCommand.Parameters.AddWithValue("@BpjsPercentage", txtbpjs.Text)
            sqlCommand.Parameters.AddWithValue("@Taxes", txttaxes.Text)
            sqlCommand.Parameters.AddWithValue("@Loan", txtloan.Text)
            sqlCommand.Parameters.AddWithValue("@Lates", txtlates.Text)
            sqlCommand.Parameters.AddWithValue("@OtherAdditionalDeduction1", txtdesc11.Text)
            sqlCommand.Parameters.AddWithValue("@OtherAdditionalDeduction2", txtdesc22.Text)
            sqlCommand.Parameters.AddWithValue("@OtherAdditionalDeduction3", txtdesc33.Text)
            sqlCommand.Parameters.AddWithValue("@OtherAdditionalDeduction4", txtdesc44.Text)
            sqlCommand.Parameters.AddWithValue("@OtherAdditionalDeduction5", txtdesc55.Text)
            sqlCommand.Parameters.AddWithValue("@AdditionalDeduction1", txtded1.Text)
            sqlCommand.Parameters.AddWithValue("@AdditionalDeduction2", txtded2.Text)
            sqlCommand.Parameters.AddWithValue("@AdditionalDeduction3", txtded3.Text)
            sqlCommand.Parameters.AddWithValue("@AdditionalDeduction4", txtded4.Text)
            sqlCommand.Parameters.AddWithValue("@AdditionalDeduction5", txtded5.Text)
            sqlCommand.Parameters.AddWithValue("@ResJaminanKecelakaanKerja", txtjkk.Text)
            sqlCommand.Parameters.AddWithValue("@ResPremiJaminanKematian", txtpjk.Text)
            sqlCommand.Parameters.AddWithValue("@ResJaminanHariTua", txtjht.Text)
            sqlCommand.Parameters.AddWithValue("@ResBiayajabatan", txtbj.Text)
            sqlCommand.Parameters.AddWithValue("@ResIuranPensiun", txtip.Text)
            sqlCommand.Parameters.AddWithValue("@PersenKk", txtpkk.Text)
            sqlCommand.Parameters.AddWithValue("@PersenJk", txtppjk.Text)
            sqlCommand.Parameters.AddWithValue("@PersenJht", txtpjht.Text)
            sqlCommand.Parameters.AddWithValue("@PersenBj", txtpbj.Text)
            sqlCommand.Parameters.AddWithValue("@PersenIp", txtpip.Text)
            sqlCommand.Parameters.AddWithValue("@MemilikiNpwp", txtnpwp.Text)
            sqlCommand.Parameters.AddWithValue("@Gross", txtgross.Text)
            sqlCommand.Parameters.AddWithValue("@Bpjs", txtresbpjs.Text)
            sqlCommand.Parameters.AddWithValue("@OvertimeSalary", txtots.Text)
            sqlCommand.Parameters.AddWithValue("@TotalDeductions", txtded.Text)
            sqlCommand.Parameters.AddWithValue("@Netincome", txtnetincome.Text)
            sqlCommand.Parameters.AddWithValue("@PenghasilanKenaPajak", txtpkp.Text)
            sqlCommand.Parameters.AddWithValue("@JaminanKecelakaanKerja", txtresjkk.Text)
            sqlCommand.Parameters.AddWithValue("@PremiJaminanKematian", txtpremi.Text)
            sqlCommand.Parameters.AddWithValue("@JaminanHariTua", txtresjht.Text)
            sqlCommand.Parameters.AddWithValue("@PphTerhutang", txtpph.Text)
            sqlCommand.Parameters.AddWithValue("@BiayaJabatan", txtresbj.Text)
            sqlCommand.Parameters.AddWithValue("@IuranPensiun", txtresip.Text)
            sqlCommand.Parameters.AddWithValue("@NettoSetahun", txtnetto.Text)
            sqlCommand.Parameters.AddWithValue("@StatusWajibPajak", txtwp.Text)
            sqlCommand.Parameters.AddWithValue("@RapelFromMonth", frommonth.Text)
            sqlCommand.Parameters.AddWithValue("@RapelToMonth", tomonth.Text)
            sqlCommand.Parameters.AddWithValue("@RapelRate", txtresrapel.Text)
            sqlCommand.Parameters.AddWithValue("@Rapel", txtrapel.Text)
            sqlCommand.Parameters.AddWithValue("@PajakPphPerTahun", txtpajak.Text)
            sqlCommand.ExecuteNonQuery()
            MessageBox.Show("Data Succesfully Added!")
            Return True
        Catch ex As Exception
            Return False
            MsgBox(ex.Message)
        End Try
    End Function

    Dim tbl_par As New DataTable

    Sub loadDataKaryawan()
        SQLConnection = New MySqlConnection()
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        Dim sqlCommand As New MySqlCommand
        sqlCommand.CommandText = "SELECT EmployeeCode, CompanyCode, FullName, PaymentDate, BasicRate, Allowance, Incentives, TableMoney, Transport, OtherAdditionalAllowance1, OtherAdditionalAllowance2, OtherAdditionalAllowance3, OtherAdditionalAllowance4, OtherAdditionalAllowance5, AdditionalAllowance1, AdditionalAllowance2, AdditionalAllowance3, AdditionalAllowance4, AdditionalAllowance5, OvertimeHours, OvertimeType, BpjsPercentage, Taxes, Loan, Lates, OtherAdditionalDeduction1, OtherAdditionalDeduction2, OtherAdditionalDeduction3, OtherAdditionalDeduction4, OtherAdditionalDeduction5, AdditionalDeduction1, AdditionalDeduction2, AdditionalDeduction3, AdditionalDeduction4, AdditionalDeduction5, ResJaminanKecelakaanKerja, ResPremiJaminanKematian, ResJaminanHariTua, ResBiayaJabatan, ResIuranPensiun, PersenKk, PersenJk, PersenJht PersenBj, PersenIp, MemilikiNpwp, Gross, Bpjs, OvertimeSalary, TotalDeductions, NetIncome, PenghasilanKenaPajak, JaminanKecelakaanKerja, PremiJaminanKematian, JaminanHariTua, PphTerhutang, BiayaJabatan, IuranPensiun, NettoSetahun, StatusWajibPajak, RapelFromMonth, RapelToMonth, RapelRate, Rapel, PajakPphPerTahun FROm db_payroll"
        sqlCommand.Connection = SQLConnection
        Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
        Dim cb As New MySqlCommandBuilder(adapter)
        adapter.Fill(tbl_par)
        For index As Integer = 0 To tbl_par.Rows.Count - 1
            txtnames.Properties.Items.Add(tbl_par.Rows(index).Item(2).ToString())
        Next
        SQLConnection.Close()
    End Sub

    Private Sub TextEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles txtdesc11.EditValueChanged

    End Sub

    Private Sub RibbonControl1_Click(sender As Object, e As EventArgs) Handles RibbonControl1.Click

    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        cleartxt()
        lcnama.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcnames.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        barJudul.Caption = "Add Payroll Data"
        BarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        RibbonPageGroup2.Visible = False
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        cleartxt()
        barJudul.Caption = "Change Data"
        lcnama.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        BarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        RibbonPageGroup1.Visible = False
        btnsave.Text = "Change"
    End Sub

    Private Sub txtnames_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtnames.SelectedIndexChanged
        For indexing As Integer = 0 To tbl_par.Rows.Count - 1
            If txtnames.SelectedItem Is tbl_par.Rows(indexing).Item(2).ToString() Then
                txtempcode.Text = tbl_par.Rows(indexing).Item(0).ToString()
                txtcompcode.Text = tbl_par.Rows(indexing).Item(1).ToString
                txtnames.Text = tbl_par.Rows(indexing).Item(2).ToString
                txtpayment.Text = tbl_par.Rows(indexing).Item(3).ToString
                txtbasicrate.Text = tbl_par.Rows(indexing).Item(4).ToString
                txtallowance.Text = tbl_par.Rows(indexing).Item(5).ToString
                txtincentives.Text = tbl_par.Rows(indexing).Item(6).ToString
                txtmeal.Text = tbl_par.Rows(indexing).Item(7).ToString
                txttransport.Text = tbl_par.Rows(indexing).Item(8).ToString
                txtdesc1.Text = tbl_par.Rows(indexing).Item(9).ToString
                txtdesc2.Text = tbl_par.Rows(indexing).Item(10).ToString
                txtdesc3.Text = tbl_par.Rows(indexing).Item(11).ToString
                txtdesc4.Text = tbl_par.Rows(indexing).Item(12).ToString
                txtdesc5.Text = tbl_par.Rows(indexing).Item(13).ToString
                txtadd1.Text = tbl_par.Rows(indexing).Item(14).ToString
                txtadd2.Text = tbl_par.Rows(indexing).Item(15).ToString
                txtadd3.Text = tbl_par.Rows(indexing).Item(16).ToString
                txtadd4.Text = tbl_par.Rows(indexing).Item(17).ToString
                txtadd5.Text = tbl_par.Rows(indexing).Item(18).ToString
                txtothours.Text = tbl_par.Rows(indexing).Item(19).ToString
                txtottype.Text = tbl_par.Rows(indexing).Item(20).ToString
                txtbpjs.Text = tbl_par.Rows(indexing).Item(21).ToString
                txttaxes.Text = tbl_par.Rows(indexing).Item(22).ToString
                txtloan.Text = tbl_par.Rows(indexing).Item(23).ToString
                txtlates.Text = tbl_par.Rows(indexing).Item(24).ToString
                txtdesc11.Text = tbl_par.Rows(indexing).Item(25).ToString
                txtdesc22.Text = tbl_par.Rows(indexing).Item(26).ToString
                txtdesc33.Text = tbl_par.Rows(indexing).Item(27).ToString
                txtdesc44.Text = tbl_par.Rows(indexing).Item(28).ToString
                txtdesc55.Text = tbl_par.Rows(indexing).Item(29).ToString
                txtded1.Text = tbl_par.Rows(indexing).Item(30).ToString
                txtded2.Text = tbl_par.Rows(indexing).Item(31).ToString
                txtded3.Text = tbl_par.Rows(indexing).Item(32).ToString
                txtded4.Text = tbl_par.Rows(indexing).Item(33).ToString
                txtded5.Text = tbl_par.Rows(indexing).Item(34).ToString
                txtjkk.Text = tbl_par.Rows(indexing).Item(35).ToString
                txtpjk.Text = tbl_par.Rows(indexing).Item(36).ToString
                txtjht.Text = tbl_par.Rows(indexing).Item(37).ToString
                txtbj.Text = tbl_par.Rows(indexing).Item(38).ToString
                txtip.Text = tbl_par.Rows(indexing).Item(39).ToString
                txtpkk.Text = tbl_par.Rows(indexing).Item(40).ToString
                txtppjk.Text = tbl_par.Rows(indexing).Item(41).ToString
                txtpjht.Text = tbl_par.Rows(indexing).Item(42).ToString
                txtpbj.Text = tbl_par.Rows(indexing).Item(43).ToString
                txtpip.Text = tbl_par.Rows(indexing).Item(43).ToString
                txtnpwp.Text = tbl_par.Rows(indexing).Item(44).ToString
                txtwp.Text = tbl_par.Rows(indexing).Item(58).ToString
                frommonth.Text = tbl_par.Rows(indexing).Item(59).ToString
                tomonth.Text = tbl_par.Rows(indexing).Item(60).ToString
                txtrapel.Text = tbl_par.Rows(indexing).Item(62).ToString
            End If
        Next
    End Sub

    Private Sub NewSalary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadDataKaryawan()
        loadData()
    End Sub

    Private Sub btnCount_Click(sender As Object, e As EventArgs) Handles btnCount.Click
        Call gross()
        Call bpjs()
        Call overtime()
        Call deductions()
        Call netincome()
        Call nettosetahun()
        Call jaminanharitua()
        Call jaminankecelakaankerja()
        Call jaminankematian()
        Call biayajabatan()
        Call iuranpensiun()
        Call pkpn()
        Call pphterutang()
        Call hitungrapel()
        Call pphtahun()
    End Sub

    Private Sub hitungrapel()
        Dim a, totalvalue, res As Double
        a = Convert.ToDouble(txtrapel.Text)
        totalvalue = value2 - value
        res = a * totalvalue - a
        txtresrapel.Text = res.ToString
        txtresrapel.Text = Format(res, "##,##0")
        txtresrapel.SelectionStart = Len(txtresrapel.Text)
    End Sub

    Private Sub biayajabatan()
        Try
            Dim a, b, res As Double
            a = Convert.ToDouble(txtbasicrate.Text)
            b = Convert.ToDouble(txtpbj.Text)
            res = a * b / 100
            txtresbj.Text = res.ToString()
            txtresbj.Text = Format(res, "##,##0")
            txtresbj.SelectionStart = Len(txtresbj.Text)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub pkpn()
        Try
            Dim a, b, res As Double
            a = Convert.ToDouble(txtnetto.Text)
            b = Convert.ToDouble(nilai)
            res = a - b
            txtpkp.Text = res.ToString()
            txtpkp.Text = Format(res, "##,##0")
            txtpkp.SelectionStart = Len(txtpkp.Text)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub pphtahun()
        Try
            Dim a, res As Double
            a = Convert.ToDouble(txtpkp.Text)
            If (a < 25000000) Then
                res = a * 5 / 100
            ElseIf (a > 250000000) Then
                res = a * 10 / 100
            ElseIf (a > 500000000) Then
                res = a * 15 / 10
            ElseIf (a > 1000000000) Then
                res = a * 25 / 100
            End If
            txtpajak.Text = res.ToString()
            txtpajak.Text = Format(res, "##,##0")
            txtpajak.SelectionStart = Len(txtpajak.Text)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub pphterutang()
        Try
            Dim a, b, c As Double
            a = Convert.ToDouble(txtnetto.Text)
            b = Convert.ToDouble(nilai)
            c = a - b
            Dim hasil1, hasil2, nilai1, nilai2 As Double
            hasil1 = Convert.ToDouble(c)
            hasil2 = Convert.ToDouble(CInt(txtbasicrate.Text) * 12)
            If txtnpwp.SelectedIndex = 0 Then
                If hasil2 < 5000000 Then
                    nilai1 = c * 5 / 100
                ElseIf hasil2 > 50000000 Then
                    nilai1 = c * 15 / 100
                ElseIf hasil2 > 250000000 Then
                    nilai1 = c * 25 / 100
                Else
                    nilai1 = c * 30 / 100
                End If
                txtpph.Text = nilai1.ToString()
                txtpph.Text = Format(nilai, "##,##0")
                txtpph.SelectionStart = Len(txtpph.Text)
            ElseIf txtnpwp.SelectedIndex = 1 Then
                If hasil2 < 50000000 Then
                    nilai1 = c * 5 / 100
                    nilai2 = nilai1 * 120 / 100
                ElseIf hasil2 > 50000000 Then
                    nilai1 = c * 15 / 100
                    nilai2 = nilai1 * 120 / 100
                ElseIf hasil2 > 250000000 Then
                    nilai1 = c * 25 / 100
                    nilai2 = nilai1 * 120 / 100
                Else
                    nilai1 = c * 30 / 100
                    nilai2 = nilai1 * 120 / 100
                End If
                txtpph.Text = nilai1.ToString()
                txtpph.Text = Format(nilai1, "##,##0")
                txtpph.SelectionStart = Len(txtpph.Text)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub gross()
        Try
            Dim a, b, c, d, e, f, g, h, i, j, k, l, res As Long
            a = CLng(Convert.ToDouble(txtbasicrate.Text))
            b = CLng(Convert.ToDouble(txtallowance.Text))
            c = CLng(Convert.ToDouble(txtincentives.Text))
            d = CLng(Convert.ToDouble(txtmeal.Text))
            e = CLng(Convert.ToDouble(txttransport.Text))
            f = CLng(Convert.ToDouble(txtadd1.Text))
            g = CLng(Convert.ToDouble(txtadd2.Text))
            h = CLng(Convert.ToDouble(txtadd3.Text))
            i = CLng(Convert.ToDouble(txtadd4.Text))
            j = CLng(Convert.ToDouble(txtadd5.Text))
            res = a + b + c + d + e + f + g + h + i + j + k + l
            txtgross.Text = res.ToString()
            txtgross.Text = Format(res, "##,##0")
            txtgross.SelectionStart = Len(txtgross.Text)
        Catch ex As Exception
            If txtbasicrate.Text = "" Or txtallowance.Text = "" Or txtincentives.Text = "" Or txtmeal.Text = "" Or txttransport.Text = "" Or txtadd1.Text = "" Or txtadd2.Text = "" Or txtadd3.Text = "" Or txtadd4.Text = "" Or txtadd5.Text = "" Then ' Or txtotsalary.Text = "" Or rapel.Text = "" Then
                MsgBox("Allowances Fields Can't Be Empty, Please Input 0 if There Is No Any Additional Allowances")
            End If
        End Try
    End Sub

    Private Sub deductions()
        Try
            Dim a, b, c, d, e, f, g, h, res As Long
            a = CLng(Convert.ToDouble(txttaxes.Text))
            b = CLng(Convert.ToDouble(txtloan.Text))
            c = CLng(Convert.ToDouble(txtlates.Text))
            d = CLng(Convert.ToDouble(txtded1.Text))
            e = CLng(Convert.ToDouble(txtded2.Text))
            f = CLng(Convert.ToDouble(txtded3.Text))
            g = CLng(Convert.ToDouble(txtded4.Text))
            h = CLng(Convert.ToDouble(txtded5.Text))
            res = a + b + c + d + e + f + g + h
            txtded.Text = res.ToString()
            txtded.Text = Format(res, "##,##0")
            txtded.SelectionStart = Len(txtded.Text)
        Catch ex As Exception
            If txttaxes.Text = "" Or txtloan.Text = "" Or txtlates.Text = "" Or txtded1.Text = "" Or txtded2.Text = "" Or txtded3.Text = "" Or txtded4.Text = "" Then ' Or txtbpjs.Text = "" Or txtjkk.Text = "" Or txtjk.Text = "" Or txthasilbjabatan.Text = "" Or txthasiliuranpensiun.Text = "" Then
                MsgBox("Deductions Fields Can't Be Empty, Please Input 0 If There Is No Any Additional Deductions")
            End If
        End Try
    End Sub

    Private Sub jaminanharitua()
        Try
            Dim a, b, res As Double
            If txtjht.Text = "Yes" Then
                a = Convert.ToDouble(txtbasicrate.Text)
                b = Convert.ToDouble(txtpjht.Text)
                res = a * b / 100
                txtresjht.Text = res.ToString()
                txtresjht.Text = Format(res, "##,##0")
                txtresjht.SelectionStart = Len(txtresjht.Text)
            Else
                res = 0
                txtresjht.Text = res.ToString()
                txtresjht.Text = Format(res, "##,##0")
                txtresjht.SelectionStart = Len(txtresjht.Text)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub iuranpensiun()
        Try
            Dim a, b, res As Double
            If txtip.Text = "Yes" Then
                a = Convert.ToDouble(txtbasicrate.Text)
                b = Convert.ToDouble(txtpip.Text)
                res = a * b / 100
                txtresip.Text = res.ToString()
                txtresip.Text = Format(res, "##,##0")
                txtresip.SelectionStart = Len(txtresip.Text)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Public Sub overtime()
        Try
            If txtottype.Text = "Regular Day" Then
                Dim hours, pay, salary, temp, totot, tempo, value1, value2, pay2 As Double
                hours = CInt(Convert.ToInt64(txtothours.Text))
                salary = CInt(Convert.ToInt64(txtbasicrate.Text))
                pay = CInt(salary / 173)
                pay2 = CInt(pay * 1.5)
                If (hours = 1) Then
                    tempo = CInt(pay * 1.5)
                    value1 = tempo
                    totot = value1
                ElseIf (hours > 1) Then
                    temp = pay * 2
                    tempo = temp * hours - pay * 2
                    value2 = tempo
                    totot = value2 + pay2
                End If
                txtots.Text = totot.ToString()
                txtots.Text = Format(totot, "##,##0")
                txtots.SelectionStart = Len(txtots.Text)
            ElseIf txtottype.Text = "Holiday / Sunday" Then
                Dim hours, pay, salary, temp, totot2, tempo, value1, value2, pay2, value3 As Double
                hours = CInt(Convert.ToInt64(txtothours.Text))
                salary = CInt(Convert.ToInt64(txtbasicrate.Text))
                pay = CInt(salary / 173)
                pay2 = pay * 3
                If (hours > 0) And (hours < 8) Then
                    tempo = pay * hours * 2
                    value1 = tempo
                    totot2 = value1
                ElseIf (hours = 8) Then
                    temp = pay * 3
                    tempo = temp * hours - pay * 3
                    value2 = tempo
                    totot2 = value2 - pay2 - pay
                ElseIf (hours > 8) Then
                    temp = pay * 4
                    tempo = temp * hours - pay * 4
                    value3 = tempo
                    totot2 = value3 - value2 - value1
                End If
                txtots.Text = totot2.ToString()
                txtots.Text = Format(totot2, "##,##0")
                txtots.SelectionStart = Len(txtots.Text)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub jaminankecelakaankerja()
        Try
            Dim a, b, res As Double
            If txtjkk.Text = "Yes" Then
                a = Convert.ToDouble(txtbasicrate.Text)
                b = Convert.ToDouble(txtpkk.Text)
                res = a * b / 100
                txtresjkk.Text = res.ToString()
                txtresjkk.Text = Format(res, "##,##0")
                txtresjkk.SelectionStart = Len(txtresjkk.Text)
            Else
                res = 0
                txtresjkk.Text = res.ToString()
                txtresjkk.Text = Format(res, "##,##0")
                txtresjkk.SelectionStart = Len(txtresjkk.Text)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub jaminankematian()
        Try
            Dim a, b, res As Double
            If txtpjk.Text = "Yes" Then
                a = Convert.ToDouble(txtbasicrate.Text)
                b = Convert.ToDouble(txtppjk.Text)
                res = a * b / 100
                txtpremi.Text = res.ToString()
                txtpremi.Text = Format(res, "##,##0")
                txtpremi.SelectionStart = Len(txtpremi.Text)
            Else
                res = 0
                txtpremi.Text = res.ToString()
                txtpremi.Text = Format(res, "##,##0")
                txtpremi.SelectionStart = Len(txtpremi.Text)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub nettosetahun()
        Try
            Dim a, res As Double
            a = Convert.ToDouble(txtnetincome.Text)
            res = a * 12
            txtnetto.Text = res.ToString()
            txtnetto.Text = Format(res, "##,##0")
            txtnetto.SelectionStart = Len(txtnetto.Text)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub netincome()
        Try
            Dim a, b, res As Double
            a = Convert.ToDouble(txtgross.Text)
            b = Convert.ToDouble(txtded.Text)
            res = a - b
            txtnetincome.Text = res.ToString()
            txtnetincome.Text = Format(res, "##,##0")
            txtnetincome.SelectionStart = Len(txtnetincome.Text)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub bpjs()
        Try
            Dim a, b, res As Double
            a = Convert.ToDouble(txtbpjs.Text)
            b = Convert.ToDouble(txtbasicrate.Text)
            res = b * a / 100
            txtresbpjs.Text = res.ToString()
            txtresbpjs.Text = Format(res, "##,##0")
            txtresbpjs.SelectionStart = Len(txtresbpjs.Text)
        Catch ex As Exception
            If txtbpjs.Text = "" Then
                MsgBox("Please Input BPJS Percentage First")
            End If
        End Try
    End Sub
    Dim value, value2 As Long

    Private Sub tomonth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tomonth.SelectedIndexChanged
        If tomonth.Text = "January" Then
            value2 = 1
        ElseIf tomonth.Text = "February" Then
            value2 = 2
        ElseIf tomonth.Text = "March" Then
            value2 = 3
        ElseIf tomonth.Text = "April" Then
            value2 = 4
        ElseIf tomonth.Text = "May" Then
            value2 = 5
        ElseIf tomonth.Text = "June" Then
            value2 = 6
        ElseIf tomonth.Text = "July" Then
            value2 = 7
        ElseIf tomonth.Text = "August" Then
            value2 = 8
        ElseIf tomonth.Text = "September" Then
            value2 = 9
        ElseIf tomonth.Text = "October" Then
            value2 = 10
        ElseIf tomonth.Text = "November" Then
            value2 = 11
        Else
            value2 = 12
        End If
    End Sub

    Private Sub txtip_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtip.SelectedIndexChanged
        If txtip.SelectedIndex = 0 Then
            txtip.SelectedItem = "Yes"
            lcpip.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        ElseIf txtip.SelectedIndex = 1 Then
            txtip.SelectedItem = "No"
            lcpip.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            txtpip.Text = "0"
        End If
    End Sub

    Private Sub txtjkk_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtjkk.SelectedIndexChanged
        If txtjkk.SelectedIndex = 0 Then
            txtjkk.SelectedItem = "Yes"
            lcpjkk.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        ElseIf txtjkk.SelectedIndex = 1 Then
            txtjkk.SelectedItem = "No"
            lcpjkk.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            txtpkk.Text = "0"
        End If
    End Sub

    Private Sub txtpjk_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtpjk.SelectedIndexChanged
        If txtpjk.SelectedIndex = 0 Then
            txtpjk.SelectedItem = "Yes"
            lcppjk.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        ElseIf txtpjk.SelectedIndex = 1 Then
            txtpjk.SelectedItem = "No"
            lcppjk.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            txtppjk.Text = "0"
        End If
    End Sub

    Private Sub txtjht_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtjht.SelectedIndexChanged
        If txtjht.SelectedIndex = 0 Then
            txtjht.SelectedItem = "Yes"
            lcpjht.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        ElseIf txtjht.SelectedIndex = 1 Then
            txtjht.SelectedItem = "No"
            lcpjht.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            txtpjht.Text = "0"
        End If
    End Sub

    Private Sub txtbj_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtbj.SelectedIndexChanged
        If txtbj.SelectedIndex = 0 Then
            txtbj.SelectedItem = "Yes"
            lcpbj.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        ElseIf txtbj.SelectedIndex = 1 Then
            txtbj.SelectedItem = "No"
            lcpbj.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            txtpbj.Text = "0"
        End If
    End Sub
    Dim nilai As Long

    Private Sub txtwp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtwp.SelectedIndexChanged
        If txtwp.Text = "" Then
            nilai = 0
        ElseIf txtwp.SelectedIndex = 0 Then
            nilai = 54000000
        ElseIf txtwp.SelectedIndex = 1 Then
            nilai = 58500000
        ElseIf txtwp.SelectedIndex = 2 Then
            nilai = 63000000
        ElseIf txtwp.SelectedIndex = 3 Then
            nilai = 67500000
        ElseIf txtwp.SelectedIndex = 4 Then
            nilai = 11250000
        ElseIf txtwp.SelectedIndex = 5 Then
            nilai = 11700000
        ElseIf txtwp.SelectedIndex = 6 Then
            nilai = 12150000
        Else
            nilai = 126000000
        End If
    End Sub

    Private Sub txtwp_SelectedValueChanged(sender As Object, e As EventArgs) Handles txtwp.SelectedValueChanged
        If txtwp.SelectedIndex = 0 Then
            txtwp.SelectedItem = "Tidak Kawin, Tanpa Tanggungan"
        ElseIf txtwp.SelectedIndex = 1 Then
            txtwp.SelectedItem = "Tidak Kawin, Tanggungan 1"
        ElseIf txtwp.SelectedIndex = 2 Then
            txtwp.SelectedItem = "Tidak Kawin, Tanggungan 2"
        ElseIf txtwp.SelectedIndex = 3 Then
            txtwp.SelectedItem = "Tidak Kawin, Tanggungan 3"
        ElseIf txtwp.SelectedIndex = 4 Then
            txtwp.SelectedItem = "Kawin, Tanpa Tanggungan"
        ElseIf txtwp.SelectedIndex = 5 Then
            txtwp.SelectedItem = "Kawin, Tanggungan 1"
        ElseIf txtwp.SelectedIndex = 6 Then
            txtwp.SelectedItem = "Kawin, Tanggungan 2"
        ElseIf txtwp.SelectedIndex = 7 Then
            txtwp.SelectedItem = "Kawin, Tanggungan 3"
        ElseIf txtwp.SelectedIndex = 8 Then
            txtwp.SelectedItem = "Kawin, Penghasilan Istri Dan Suami Digabung"
        ElseIf txtwp.SelectedIndex = 9 Then
            txtwp.SelectedItem = "Kawin, Penghasilan Digabung Tanggungan 1"
        ElseIf txtwp.SelectedIndex = 10 Then
            txtwp.SelectedItem = "Kawin, Penghasilan Digabung Tanggungan 2"
        ElseIf txtwp.SelectedIndex = 11 Then
            txtwp.SelectedItem = "Kawin, Penghasilan Digabung Tanggungan 3"
        End If
    End Sub
    Dim tbl_par2 As New DataTable

    Sub loadData()
        SQLConnection = New MySqlConnection()
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        Dim sqlCommand As New MySqlCommand
        sqlCommand.CommandText = "SELECT EmployeeCode, FullName, CompanyCode FROM db_pegawai WHERE Status!='Fired'"
        sqlCommand.Connection = SQLConnection
        Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
        Dim cb As New MySqlCommandBuilder(adapter)
        adapter.Fill(tbl_par2)
        For index As Integer = 0 To tbl_par2.Rows.Count - 1
            txtnama.Properties.Items.Add(tbl_par2.Rows(index).Item(1).ToString())
        Next
        SQLConnection.Close()
    End Sub

    Private Sub txtnama_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtnama.SelectedIndexChanged
        For indexing As Integer = 0 To tbl_par2.Rows.Count - 1
            If txtnama.SelectedItem Is tbl_par2.Rows(indexing).Item(1).ToString() Then
                txtempcode.Text = tbl_par2.Rows(indexing).Item(0).ToString()
                txtcompcode.Text = tbl_par2.Rows(indexing).Item(2).ToString()
            End If
        Next
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        If barJudul.Caption = "Add Payroll Data" Then
            InsertReq()
        ElseIf barJudul.Caption = "Change Data" Then
            updatechange()
        End If
    End Sub

    Private Sub frommonth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles frommonth.SelectedIndexChanged
        If frommonth.Text = "January" Then
            value = 0
        ElseIf frommonth.Text = "February" Then
            value = 1
        ElseIf frommonth.Text = "March" Then
            value = 2
        ElseIf frommonth.Text = "April" Then
            value = 3
        ElseIf frommonth.Text = "May" Then
            value = 4
        ElseIf frommonth.Text = "June" Then
            value = 5
        ElseIf frommonth.Text = "July" Then
            value = 6
        ElseIf frommonth.Text = "August" Then
            value = 7
        ElseIf frommonth.Text = "September" Then
            value = 8
        ElseIf frommonth.Text = "October" Then
            value = 9
        ElseIf frommonth.Text = "November" Then
            value = 10
        Else
            value = 11
        End If
    End Sub
End Class