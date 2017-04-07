Imports System.IO

Public Class ChangeEmp

    Dim connectionString As String
    Dim SQLConnection As MySqlConnection = New MySqlConnection
    Dim oDt_sched As New DataTable()

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Try
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
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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

    Private Sub loadinfo()
        GridControl1.RefreshDataSource()
        Dim table As New DataTable
        Dim sqlcommand As New MySqlCommand
        'Try
            sqlcommand.CommandText = "Select EmployeeCode, FullName from db_pegawai where status != 'Fired' and status != 'Terminated'"
            sqlcommand.Connection = SQLConnection
            Dim tbl_par As New DataTable
            Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(table)
            GridControl1.DataSource = table
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        Dim datatabl As New DataTable
        Dim sqlCommand As New MySqlCommand
        datatabl.Clear()
        Dim param As String = ""
        Try
            param = "and EmployeeCode='" + GridView1.GetFocusedRowCellValue("EmployeeCode").ToString() + "'"
        Catch ex As Exception
        End Try
        'Try
        sqlCommand.CommandText = "SELECT * FROM db_pegawai WHERE 1=1 " + param.ToString()
            sqlCommand.Connection = SQLConnection

            Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(datatabl)
            'Catch ex As Exception
            '    MsgBox(ex.Message)
            'End Try
            If datatabl.Rows.Count > -1 Then
            TextBox1.Text = datatabl.Rows(0).Item(0).ToString()
            TextBox2.Text = datatabl.Rows(0).Item(2).ToString()
            txtnick.Text = datatabl.Rows(0).Item(18).ToString()
            ComboBoxEdit6.Text = datatabl.Rows(0).Item(6).ToString()
            txtbp.Text = datatabl.Rows(0).Item(4).ToString()
            txtbod.Value = CDate(datatabl.Rows(0).Item(5).ToString())
            txtidno.Text = datatabl.Rows(0).Item(9).ToString()
            Dim filefoto As Byte() = CType(datatabl.Rows(0).Item(13), Byte())
            If filefoto.Length > 0 Then
                PictureBox1.Image = ByteToImage(filefoto)
            Else
                PictureBox1.Image = Nothing
                PictureBox1.Refresh()
            End If
            txtkg.Text = datatabl.Rows(0).Item(19).ToString
            txtcm.Text = datatabl.Rows(0).Item(20).ToString
            txtjoin.Text = datatabl.Rows(0).Item(11).ToString
            txtrel.Text = datatabl.Rows(0).Item(7).ToString
            txtblood.Text = datatabl.Rows(0).Item(21).ToString()
            txtphoneno.Text = datatabl.Rows(0).Item(12).ToString()
            txtwemail.Text = datatabl.Rows(0).Item(22).ToString()
            txtpemail.Text = datatabl.Rows(0).Item(23).ToString
            txtadd.Text = datatabl.Rows(0).Item(8).ToString
            txtrecby.Text = datatabl.Rows(0).Item(24).ToString
            txtjob.Text = datatabl.Rows(0).Item(3).ToString
            txtcompany.Text = datatabl.Rows(0).Item(1).ToString
            txtofloc.Text = datatabl.Rows(0).Item(1).ToString
            txtgroup.Text = datatabl.Rows(0).Item(25).ToString
            txtdept.Text = datatabl.Rows(0).Item(26).ToString
            txttype.Text = datatabl.Rows(0).Item(15).ToString
            ComboBoxEdit1.Text = datatabl.Rows(0).Item(14).ToString
            txtjobdesk.Text = datatabl.Rows(0).Item(28).ToString
            ComboBoxEdit2.Text = datatabl.Rows(0).Item(28).ToString
            ComboBoxEdit7.Text = datatabl.Rows(0).Item(29).ToString
            ComboBoxEdit1.Text = datatabl.Rows(0).Item(14).ToString
            CheckEdit1.Checked = CType(datatabl.Rows(0).Item(30).ToString, Boolean)
            TextBox3.Text = datatabl.Rows(0).Item(32).ToString
            CheckEdit2.Checked = CType(datatabl.Rows(0).Item(33).ToString, Boolean)
            CheckEdit3.Checked = CType(datatabl.Rows(0).Item(34).ToString, Boolean)
            CheckEdit4.Checked = CType(datatabl.Rows(0).Item(35).ToString, Boolean)
            CheckEdit5.Checked = CType(datatabl.Rows(0).Item(36).ToString, Boolean)
            CheckEdit6.Checked = CType(datatabl.Rows(0).Item(37).ToString, Boolean)
            CheckEdit7.Checked = CType(datatabl.Rows(0).Item(38).ToString, Boolean)
            ComboBoxEdit9.Text = datatabl.Rows(0).Item(39).ToString
            DateTimePicker2.Text = datatabl.Rows(0).Item(31).ToString
        End If
        edu()
        cert()
        skill()
        fam()
        exp()
    End Sub

    Private Sub ChangeEmp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        loadinfo()
    End Sub

    Public Sub UpdateEmp()
        Dim dtb, dtr As DateTime
        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.CustomFormat = "yyyy-MM-dd"
        dtb = DateTimePicker2.Value
        Dim sqlCommand As New MySqlCommand
        Dim str_carSql As String
        ' Try
        str_carSql = "UPDATE db_pegawai SET" +
                   " CompanyCode = @CompanyCode" +
                   ", FullName = @FullName" +
                   ", Position = @Position" +
                   ", PlaceOfBirth = @PlaceOfBirth" +
                   ", DateOfBirth = @DateOfBirth" +
                   ", Gender = @Gender" +
                   ", Religion = @Religion" +
                   ", Address = @Address" +
                   ", IdNumber = @IdNumber" +
                   ", OfficeLocation = @OfficeLocation" +
                   ", WorkDate = @WorkDate" +
                   ", PhoneNumber = @PhoneNumber" +
                   ", Photo = @Photo" +
                   ", Status = @Status" +
                   ", EmployeeType = @EmployeeType " +
                   ", TerminateDate = @TerminateDate" +
                   ", ChangeDate = @ChangeDate" +
                   ", NickName = @NickName" +
                   ", Weight = @Weight" +
                   ", Height = @height" +
                   ", BloodType = @BloodType" +
                   ", WorkEmail = @WorkEmail" +
                   ", PrivateEmail = @PrivateEmail" +
                   ", RecommendedBy = @RecommendedBy" +
                   ", Grouping = @Grouping" +
                   ", Department = @Department" +
                   ", JobDesks = @Jobdesks" +
                   ", MaritalStatus = @maritalStatus" +
                   ", PphStatus = @PphStatus" +
                   ", IsExpiry = @IsExpiry" +
                   ", ExpiryDates = @ExpiryDates " +
                   ", ApprovedBy = @ApprovedBy " +
                   ", ExcludePayroll = @ExcludePayroll " +
                   ", PayCash = @PayCash " +
                   ", ProcessTax = @ProcessTax " +
                   ", ExcludeThr = @ExcludeThr " +
                   ", ExcludeBonus = @ExcludeBonus " +
                   ", PrintSlip = @Printslip" +
                   ", PayrollInterval = @payrollInterval " +
                   " WHERE EmployeeCode = @EmployeeCode"
        sqlCommand.Connection = SQLConnection
        sqlCommand.CommandText = str_carSql
        sqlCommand.Parameters.AddWithValue("@EmployeeCode", TextBox1.Text)
        sqlCommand.Parameters.AddWithValue("@CompanyCode", txtcompany.Text)
        sqlCommand.Parameters.AddWithValue("@FullName", TextBox2.Text)
        sqlCommand.Parameters.AddWithValue("@Position", txtjob.Text)
        sqlCommand.Parameters.AddWithValue("@PlaceOfBirth", txtbp.Text)
        sqlCommand.Parameters.AddWithValue("@DateOfBirth", txtbod.Value.Date)
        sqlCommand.Parameters.AddWithValue("@Gender", ComboBoxEdit6.Text)
        sqlCommand.Parameters.AddWithValue("@Religion", txtrel.Text)
        sqlCommand.Parameters.AddWithValue("@Address", txtadd.Text)
        sqlCommand.Parameters.AddWithValue("@IdNumber", txtidno.Text)
        sqlCommand.Parameters.AddWithValue("@OfficeLocation", txtofloc.Text)
        sqlCommand.Parameters.AddWithValue("@WorkDate", txtjoin.Value.Date)
        sqlCommand.Parameters.AddWithValue("@PhoneNumber", txtphoneno.Text)
        If Not ImageEdit1.Text Is Nothing Then
            Dim param As New MySqlParameter("@Photo", ImageToByte(PictureBox1))
            sqlCommand.Parameters.Add(param)
        Else
            sqlCommand.Parameters.AddWithValue("@Photo", "")
        End If
        sqlCommand.Parameters.AddWithValue("@Status", ComboBoxEdit1.Text)
        sqlCommand.Parameters.AddWithValue("@EmployeeType", txttype.Text)
        sqlCommand.Parameters.AddWithValue("@TerminateDate", Nothing)
        sqlCommand.Parameters.AddWithValue("@ChangeDate", Date.Now)
        sqlCommand.Parameters.AddWithValue("@NickName", txtnick.Text)
        sqlCommand.Parameters.AddWithValue("@Weight", txtkg.Text)
        sqlCommand.Parameters.AddWithValue("@Height", txtcm.Text)
        sqlCommand.Parameters.AddWithValue("@BloodType", txtblood.Text)
        sqlCommand.Parameters.AddWithValue("@WorkEmail", txtwemail.Text)
        sqlCommand.Parameters.AddWithValue("@PrivateEmail", txtpemail.Text)
        sqlCommand.Parameters.AddWithValue("@RecommendedBy", txtrecby.Text)
        sqlCommand.Parameters.AddWithValue("@Grouping", txtgroup.Text)
        sqlCommand.Parameters.AddWithValue("@Department", txtdept.Text)
        sqlCommand.Parameters.AddWithValue("@Jobdesks", txtjobdesk.Text)
        sqlCommand.Parameters.AddWithValue("@MaritalStatus", ComboBoxEdit2.Text)
        sqlCommand.Parameters.AddWithValue("@pphStatus", ComboBoxEdit7.Text)
        sqlCommand.Parameters.AddWithValue("@IsExpiry", CheckEdit1.Checked)
        sqlCommand.Parameters.AddWithValue("@ExpiryDates", dtb.ToString("yyyy-MM-dd"))
        sqlCommand.Parameters.AddWithValue("@ApprovedBy", TextBox3.Text)
        sqlCommand.Parameters.AddWithValue("@ExcludePayroll", CheckEdit2.Checked)
        sqlCommand.Parameters.AddWithValue("@PayCash", CheckEdit3.Checked)
        sqlCommand.Parameters.AddWithValue("@ProcessTax", CheckEdit4.Checked)
        sqlCommand.Parameters.AddWithValue("@ExcludeThr", CheckEdit5.Checked)
        sqlCommand.Parameters.AddWithValue("@ExcludeBonus", CheckEdit6.Checked)
        sqlCommand.Parameters.AddWithValue("@PrintSlip", CheckEdit7.Checked)
        sqlCommand.Parameters.AddWithValue("@PayrollInterval", ComboBoxEdit9.Text)
        sqlCommand.Connection = SQLConnection
        sqlCommand.ExecuteNonQuery()
        MsgBox("Data Successfully Changed")
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
    End Sub

    Dim dt1 As Date
    Dim dt2 As Date
    Dim dt3 As TimeSpan
    Dim diff As Double

    Private Sub txtjoin_ValueChanged(sender As Object, e As EventArgs) Handles txtjoin.ValueChanged
        Dim bulan, tahun As String
        dt1 = CDate(txtjoin.Value.ToShortDateString)
        dt2 = Date.Now
        dt3 = (dt2 - dt1)
        diff = dt3.Days
        tahun = CStr(Int(diff / 365))
        Dim tmpmonth As String = CStr(Int(diff Mod 365))
        bulan = CStr(Int(CInt(tmpmonth) / 30))
        Dim tmpdays As String = CStr(Int(CInt(tmpmonth) Mod 30))
        txtwork.Text = tahun & " Y" & " " & bulan & " M" & " " & tmpdays & " D"
    End Sub

    Private Sub txtbod_ValueChanged(sender As Object, e As EventArgs) Handles txtbod.ValueChanged
        dt1 = CDate(txtbod.Value.ToShortDateString)
        dt2 = Date.Now
        dt3 = (dt2 - dt1)
        diff = dt3.Days
        txtage.Text = Str(Int(diff / 365))
    End Sub

    Private Sub SimpleButton10_Click(sender As Object, e As EventArgs) Handles SimpleButton10.Click
        UpdateEmp()
    End Sub

    Dim act As String = ""

    Private Sub GridView3_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView3.FocusedRowChanged
        Dim datatabl As New DataTable
        Dim sqlcommand As New MySqlCommand
        datatabl.Clear()
        Dim param As String = ""
        Try
            param = "and NoId ='" + GridView3.GetFocusedRowCellValue("NoId").ToString() + "'"
        Catch ex As Exception
        End Try
        If param > "" Then
            act = "edit"
        Else
            act = "input"
        End If
        Try
            sqlcommand.CommandText = "Select NoId, EmployeeCode, School, GraduatedYear, StudyField from db_education where 1 = 1 " + param.ToString()
            sqlcommand.Connection = SQLConnection
            Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(datatabl)
        Catch ex As Exception
        End Try
        If datatabl.Rows.Count > 0 Then
            Label29.Text = datatabl.Rows(0).Item(0).ToString
            txtschoolname.Text = datatabl.Rows(0).Item(2).ToString
            txtyears.Text = datatabl.Rows(0).Item(3).ToString
            txtmajor.Text = datatabl.Rows(0).Item(4).ToString
        End If
    End Sub

    Private Sub GridView2_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView2.FocusedRowChanged
        Dim datatabl As New DataTable
        Dim sqlcommand As New MySqlCommand
        datatabl.Clear()
        Dim param As String = ""
        Try
            param = "and NoId ='" + GridView2.GetFocusedRowCellValue("NoId").ToString() + "'"
        Catch ex As Exception
        End Try
        If param > "" Then
            act = "edit"
        Else
            act = "input"
        End If
        Try
            sqlcommand.CommandText = "Select NoId, EmployeeCode, Certificates, Years, Reasons from db_certificates where 1 = 1 " + param.ToString()
            sqlcommand.Connection = SQLConnection
            Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(datatabl)
        Catch ex As Exception
        End Try
        If datatabl.Rows.Count > 0 Then
            Label29.Text = datatabl.Rows(0).Item(0).ToString
            txtcertificate.Text = datatabl.Rows(0).Item(2).ToString
            txtyear.Text = datatabl.Rows(0).Item(3).ToString
            txtreason.Text = datatabl.Rows(0).Item(4).ToString
        End If
    End Sub

    Private Sub GridView4_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView4.FocusedRowChanged
        Dim datatabl As New DataTable
        Dim sqlcommand As New MySqlCommand
        datatabl.Clear()
        Dim param As String = ""
        Try
            param = "and NoId ='" + GridView4.GetFocusedRowCellValue("NoId").ToString() + "'"
        Catch ex As Exception
        End Try
        If param > "" Then
            act = "edit"
        Else
            act = "input"
        End If
        Try
            sqlcommand.CommandText = "Select NoId, EmployeeCode, MemberName, Relationship, Gender, Address, Occupation, PhoneNo from db_family where 1 = 1 " + param.ToString()
            sqlcommand.Connection = SQLConnection
            Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(datatabl)
        Catch ex As Exception
        End Try
        If datatabl.Rows.Count > 0 Then
            Label29.Text = datatabl.Rows(0).Item(0).ToString
            txtmember.Text = datatabl.Rows(0).Item(2).ToString
            txtrelation.Text = datatabl.Rows(0).Item(3).ToString
            txtmemgender.Text = datatabl.Rows(0).Item(4).ToString
            txtmemadd.Text = datatabl.Rows(0).Item(5).ToString
            txtocc.Text = datatabl.Rows(0).Item(6).ToString
            txtmemph.Text = datatabl.Rows(0).Item(7).ToString
        End If
    End Sub

    Private Sub GridView5_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView5.FocusedRowChanged
        Dim datatabl As New DataTable
        Dim sqlcommand As New MySqlCommand
        datatabl.Clear()
        Dim param As String = ""
        Try
            param = "and NoId ='" + GridView5.GetFocusedRowCellValue("NoId").ToString() + "'"
        Catch ex As Exception
        End Try
        If param > "" Then
            act = "edit"
        Else
            act = "input"
        End If
        Try
            sqlcommand.CommandText = "Select NoId, EmployeeCode, Position, Company, Manager, Address, Period, Until, BasicSalary, AdditionalSalary, TotalSalary, QuitReason from db_exp where 1 = 1 " + param.ToString()
            sqlcommand.Connection = SQLConnection
            Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(datatabl)
        Catch ex As Exception
        End Try
        If datatabl.Rows.Count > 0 Then
            Label29.Text = datatabl.Rows(0).Item(0).ToString
            txtjobtitle.Text = datatabl.Rows(0).Item(2).ToString
            txtcompanyname.Text = datatabl.Rows(0).Item(3).ToString
            txtmanagername.Text = datatabl.Rows(0).Item(4).ToString
            txtcompadd.Text = datatabl.Rows(0).Item(5).ToString
            txtperiod.Text = datatabl.Rows(0).Item(6).ToString
            txtuntil.Text = datatabl.Rows(0).Item(7).ToString
            txtbasic.Text = datatabl.Rows(0).Item(8).ToString
            txtaddi.Text = datatabl.Rows(0).Item(9).ToString
            txttotalsa.Text = datatabl.Rows(0).Item(10).ToString
            txtreasonquit.Text = datatabl.Rows(0).Item(11).ToString
        End If
    End Sub

    Private Sub GridView6_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView6.FocusedRowChanged
        Dim datatabl As New DataTable
        Dim sqlcommand As New MySqlCommand
        datatabl.Clear()
        Dim param As String = ""
        Try
            param = "and NoId ='" + GridView6.GetFocusedRowCellValue("NoId").ToString() + "'"
        Catch ex As Exception
        End Try
        If param > "" Then
            act = "edit"
        Else
            act = "input"
        End If
        Try
            sqlcommand.CommandText = "Select NoId, EmployeeCode, SkillName, SkillLevel, SkillDescription from db_empskill where 1 = 1 " + param.ToString()
            sqlcommand.Connection = SQLConnection
            Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(datatabl)
        Catch ex As Exception
        End Try
        If datatabl.Rows.Count > 0 Then
            Label29.Text = datatabl.Rows(0).Item(0).ToString
            skillname.Text = datatabl.Rows(0).Item(2).ToString
            skilllevel.Text = datatabl.Rows(0).Item(3).ToString
            skilldesc.Text = datatabl.Rows(0).Item(4).ToString
        End If
    End Sub

    Private Sub SimpleButton11_Click(sender As Object, e As EventArgs) Handles SimpleButton11.Click
        txtschoolname.Text = ""
        txtyears.Text = ""
        Label29.Text = ""
        txtmajor.Text = ""
        act = "input"
    End Sub

    Public Sub cert()
        GridControl2.Refresh()
        Dim table As New DataTable
        Dim sqlcommand As New MySqlCommand
        Try
            sqlcommand.CommandText = "select NoId, EmployeeCode, Certificates, Years, Reasons from db_certificates where EmployeeCode = '" & TextBox1.Text & "'"
            sqlcommand.Connection = SQLConnection
            Dim tbl_par As New DataTable
            Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(table)
            GridControl2.DataSource = table
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
        txtcertificate.Text = ""
        txtyears.Text = ""
        txtreason.Text = ""
    End Sub

    Sub certificates()
        Dim cmmd As MySqlCommand = SQLConnection.CreateCommand
        Try
            If act = "edit" Then
                cmmd.CommandText = "update db_certificates set " +
                                    " Certificates = @certificates " +
                                    ", Years = @Years" +
                                    ", Reasons = @reasons" +
                                    " where noid = @noid"
            Else
                cmmd.CommandText = "insert into db_certificates " +
                                    "(EmployeeCode, Certificates, Years, Reasons)" +
                                    " values (@EmployeeCode, @Certificates, @Years, @Reasons)"
            End If
            cmmd.Parameters.AddWithValue("@EmployeeCode", TextBox1.Text)
            cmmd.Parameters.AddWithValue("@noid", Label29.Text)
            cmmd.Parameters.AddWithValue("@Certificates", txtcertificate.Text)
            cmmd.Parameters.AddWithValue("@Years", txtyear.Text)
            cmmd.Parameters.AddWithValue("@Reasons", txtreason.Text)
            cmmd.ExecuteNonQuery()
            If act = "input" Then
                MsgBox("data succesfully added")
            ElseIf act = "edit" Then
                MsgBox("data changed")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        cert()
    End Sub

    Private Sub SimpleButton12_Click(sender As Object, e As EventArgs) Handles SimpleButton12.Click
        txtcertificate.Text = ""
        txtyear.Text = ""
        txtreason.Text = ""
        act = "input"
    End Sub

    Private Sub SimpleButton13_Click(sender As Object, e As EventArgs) Handles SimpleButton13.Click
        txtmember.Text = ""
        txtrelation.Text = ""
        txtmemgender.Text = ""
        txtmemadd.Text = ""
        txtocc.Text = ""
        txtmemph.Text = ""
        act = "input"
    End Sub

    Private Sub SimpleButton14_Click(sender As Object, e As EventArgs) Handles SimpleButton14.Click
        txtjobtitle.Text = ""
        txtcompanyname.Text = ""
        txtmanagername.Text = ""
        txtcompadd.Text = ""
        txtbasic.Text = ""
        txtaddi.Text = ""
        txttotalsa.Text = ""
        txtreasonquit.Text = ""
        act = "input"
    End Sub

    Private Sub SimpleButton15_Click(sender As Object, e As EventArgs) Handles SimpleButton15.Click
        skillname.Text = ""
        skilllevel.Text = ""
        skilldesc.Text = ""
        act = "input"
    End Sub

    Sub school()
        Dim cmmd As MySqlCommand = SQLConnection.CreateCommand
        Try
            If act = "edit" Then
                cmmd.CommandText = "update db_education set" +
                                    " school = @school" +
                                    ", graduatedyear = @graduatedyear" +
                                    ", studyfield = @studyfield" +
                                    " where NoId = @NoId"
            Else
                cmmd.CommandText = "insert into db_education " +
                            "(EmployeeCode, School, GraduatedYear, StudyField) " +
                            "values (@EmployeeCode, @School, @GraduatedYear, @StudyField)"
            End If
            cmmd.Parameters.AddWithValue("@NoId", Label29.Text)
            cmmd.Parameters.AddWithValue("@EmployeeCode", TextBox1.Text)
            cmmd.Parameters.AddWithValue("@School", txtschoolname.Text)
            cmmd.Parameters.AddWithValue("@GraduatedYear", txtyears.Text)
            cmmd.Parameters.AddWithValue("@StudyField", txtmajor.Text)
            cmmd.ExecuteNonQuery()
            If act = "input" Then
                MsgBox("Data succesfully added")
            ElseIf act = "edit" Then
                MsgBox("Data changed")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        edu()
    End Sub


    Sub family()
        Dim cmmd As MySqlCommand = SQLConnection.CreateCommand
        Try
            If act = "edit" Then
                cmmd.CommandText = "update db_family set " +
                                    " MemberName = @MemberName" +
                                    ", Gender = @gender" +
                                    ", Address = @Address" +
                                    ", Relationship = @Relationship" +
                                    ", Occupation = @Occupation" +
                                    ", PhoneNo = @PhoneNo" +
                                    " where NoId = @Noid"
            Else
                cmmd.CommandText = "insert into db_family " +
                          "(EmployeeCode, Relationship, MemberName, Gender, Address, Occupation, PhoneNo)" +
                          " values (@EmployeeCode,@Relationship, @MemberName, @Gender, @Address, @Occupation, @PhoneNo)"
            End If
            cmmd.Parameters.AddWithValue("@Noid", Label29.Text)
            cmmd.Parameters.AddWithValue("@EmployeeCode", TextBox1.Text)
            cmmd.Parameters.AddWithValue("@Relationship", txtrelation.Text)
            cmmd.Parameters.AddWithValue("@MemberName", txtmember.Text)
            cmmd.Parameters.AddWithValue("@Gender", txtmemgender.Text)
            cmmd.Parameters.AddWithValue("@Address", txtmemadd.Text)
            cmmd.Parameters.AddWithValue("@Occupation", txtocc.Text)
            cmmd.Parameters.AddWithValue("@PhoneNo", txtmemph.Text)
            cmmd.ExecuteNonQuery()
            If act = "input" Then
                MsgBox("data succesfully added")
            ElseIf act = "edit" Then
                MsgBox("data changed")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        fam()
    End Sub

    Public Sub fam()
        GridControl4.RefreshDataSource()
        Dim table As New DataTable
        Dim sqlcommand As New MySqlCommand
        Try
            sqlcommand.CommandText = "select NoId, EmployeeCode, MemberName, Relationship, Gender, Address, Occupation, PhoneNo from db_family where EmployeeCode = '" & TextBox1.Text & "'"
            sqlcommand.Connection = SQLConnection
            Dim tbl_par As New DataTable
            Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(table)
            GridControl4.DataSource = table
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
        txtmember.Text = ""
        txtmemgender.Text = ""
        txtmemadd.Text = ""
        txtocc.Text = ""
        txtmemph.Text = ""
    End Sub

    Public Sub edu()
        GridControl3.Refresh()
        Dim table As New DataTable
        Dim sqlcommand As New MySqlCommand
        Try
            sqlcommand.CommandText = "select NoId, EmployeeCode, School as SchoolOrUniversity, GraduatedYear, StudyField from db_education where EmployeeCode = '" & TextBox1.Text & "'"
            sqlcommand.Connection = SQLConnection
            Dim tbl_par As New DataTable
            Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(table)
            GridControl3.DataSource = table
        Catch ex As Exception
        End Try
        txtschoolname.Text = ""
        Label29.Text = ""
        txtyears.Text = ""
        txtmajor.Text = ""
    End Sub


    Sub insertexp()
        Dim dtb, dtr As Date
        txtperiod.Format = DateTimePickerFormat.Custom
        txtperiod.CustomFormat = "yyyy-MM-dd"
        dtb = txtperiod.Value
        txtuntil.Format = DateTimePickerFormat.Custom
        txtuntil.CustomFormat = "yyyy-MM-dd"
        dtr = txtuntil.Value
        Dim cmmd As MySqlCommand = SQLConnection.CreateCommand
        Try
            If act = "edit" Then
                cmmd.CommandText = "update db_exp set " +
                                    " Position = @Position" +
                                    ", Company = @Company" +
                                    ", Manager = @Manager" +
                                    ", Address = @Address" +
                                    ", Period = @Period" +
                                    ", Until = @Until" +
                                    ", BasicSalary = @BasicSalary " +
                                    ", AdditionalSalary = @AdditionalSalary" +
                                    ", TotalSalary = @TotalSalary" +
                                    ", QuitReason = @QuitReason " +
                                    " where noid = @NoId"
            Else
                cmmd.CommandText = "insert into db_exp " +
                           "(EmployeeCode, Position, Company, Manager, Address, Period, Until, BasicSalary, AdditionalSalary, TotalSalary, QuitReason)" +
                           " values (@EmployeeCode, @Company, @Position, @Manager, @Address, @Period, @Until, @BasicSalary, @AdditionalSalary, @TotalSalary, @QuitReason)"
            End If
            cmmd.Parameters.AddWithValue("@EmployeeCode", TextBox1.Text)
            cmmd.Parameters.AddWithValue("@NoId", Label29.Text)
            cmmd.Parameters.AddWithValue("@Position", txtjobtitle.Text)
            cmmd.Parameters.AddWithValue("@Company", txtcompanyname.Text)
            cmmd.Parameters.AddWithValue("@Manager", txtmanagername.Text)
            cmmd.Parameters.AddWithValue("@Address", txtcompadd.Text)
            cmmd.Parameters.AddWithValue("@Period", dtb.ToString("yyyy-MM-dd"))
            cmmd.Parameters.AddWithValue("@Until", dtr.ToString("yyyy-MM-dd"))
            cmmd.Parameters.AddWithValue("@BasicSalary", txtbasic.Text)
            cmmd.Parameters.AddWithValue("@AdditionalSalary", txtaddi.Text)
            cmmd.Parameters.AddWithValue("@TotalSalary", txttotalsa.Text)
            cmmd.Parameters.AddWithValue("@QuitReason", txtreasonquit.Text)
            cmmd.ExecuteNonQuery()
            If act = "edit" Then
                MsgBox("Data sucessfully changed")
            Else
                MsgBox("Data succesfully added")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        txtcompanyname.Text = ""
        txtmanagername.Text = ""
        txtcompadd.Text = ""
        txtbasic.Text = ""
        txtaddi.Text = ""
        txttotalsa.Text = ""
        txtreasonquit.Text = ""
        exp()
    End Sub

    Public Sub exp()
        GridControl5.RefreshDataSource()
        Dim table As New DataTable
        Dim sqlcommand As New MySqlCommand
        Try
            sqlcommand.CommandText = "select NoId, EmployeeCode, Position, Company, Manager, Address, Period, Until, BasicSalary, AdditionalSalary, TotalSalary, QuitReason from db_exp where EmployeeCode = '" & TextBox1.Text & "'"
            sqlcommand.Connection = SQLConnection
            Dim tbl_par As New DataTable
            Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(table)
            GridControl5.DataSource = table
        Catch ex As Exception
        End Try
        txtjobtitle.Text = ""
        txtcompanyname.Text = ""
        txtmanagername.Text = ""
        txtcompadd.Text = ""
        txtbasic.Text = ""
        txtaddi.Text = ""
        txttotalsa.Text = ""
        txtreasonquit.Text = ""
    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        school()
        SimpleButton11.PerformClick()
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        certificates()
        SimpleButton12.PerformClick()
    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        family()
        SimpleButton13.PerformClick()
    End Sub

    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs) Handles SimpleButton8.Click
        insertexp()
        SimpleButton14.PerformClick()
    End Sub

    Sub insertskill()
        Dim cmmd As MySqlCommand = SQLConnection.CreateCommand
        Try
            If act = "edit" Then
                cmmd.CommandText = "update db_empskill set" +
                                   " skillname = @skillname" +
                                   ", skilllevel = @skilllevel" +
                                   ", skilldescription = @skilldescription" +
                                   " where noid = @NoId"
            Else
                cmmd.CommandText = "insert into db_empskill " +
                           "(EmployeeCode, SkillName, SkillLevel, SKillDescription) " +
                           "values (@EmployeeCode, @SkillName, @SkillLevel, @SkillDescription)"
            End If
            cmmd.Parameters.AddWithValue("@NoId", Label29.Text)
            cmmd.Parameters.AddWithValue("@EmployeeCode", TextBox1.Text)
            cmmd.Parameters.AddWithValue("@SkillName", skillname.Text)
            cmmd.Parameters.AddWithValue("@SkillLevel", skilllevel.Text)
            cmmd.Parameters.AddWithValue("@SkillDescription", skilldesc.Text)
            cmmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        skill()
    End Sub
    Public Sub skill()
        GridControl6.RefreshDataSource()
        Dim table As New DataTable
        Dim sqlcommand As New MySqlCommand
        Try
            sqlcommand.CommandText = "select NoId, EmployeeCode, SkillName, SkillLevel, SkillDescription from db_empskill where employeecode = '" & TextBox1.Text & "'"
            sqlcommand.Connection = SQLConnection
            Dim tbl_par As New DataTable
            Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(table)
            GridControl6.DataSource = table
        Catch ex As Exception
        End Try
        skillname.Text = ""
        skilllevel.Text = ""
        skilldesc.Text = ""
    End Sub

    Private Sub SimpleButton9_Click(sender As Object, e As EventArgs) Handles SimpleButton9.Click
        insertskill()
        SimpleButton15.PerformClick()
    End Sub

    Private Sub txtbasic_EditValueChanged(sender As Object, e As EventArgs) Handles txtbasic.EditValueChanged
        Try
            Dim a, b, c As Integer
            a = Convert.ToInt32(txtaddi.Text)
            b = Convert.ToInt32(txtbasic.Text)
            c = a + b
            txttotalsa.Text = c.ToString
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtaddi_EditValueChanged(sender As Object, e As EventArgs) Handles txtaddi.EditValueChanged
        Try
            Dim a, b, c As Integer
            a = Convert.ToInt32(txtaddi.Text)
            b = Convert.ToInt32(txtbasic.Text)
            c = a + b
            txttotalsa.Text = c.ToString
        Catch ex As Exception
        End Try
    End Sub

    Private Sub OpenPreviewWindows()
        Try
            Dim iHeight As Integer = PictureBox1.Height
            Dim iWidth As Integer = PictureBox1.Width
            hHwnd = capCreateCaptureWindowA((iDevice), WS_VISIBLE Or WS_CHILD, 0, 0, 640, 480, PictureBox1.Handle.ToInt32, 0)
            Try
                If SendMessage(hHwnd, WM_Cap_Paki_CONNECT, iDevice, 0) Then
                    SendMessage(hHwnd, WM_Cap_SET_SCALE, True, 0)
                    SendMessage(hHwnd, WM_Cap_SET_PREVIEWRATE, 66, 0)
                    SendMessage(hHwnd, WM_Cap_SET_PREVIEW, True, 0)
                    SetWindowPos(hHwnd, HWND_BOTTOM, 0, 0, PictureBox1.Width, PictureBox1.Height, SWP_NOMOVE Or SWP_NOZORDER)
                Else
                    DestroyWindow(hHwnd)
                End If
            Catch ex1 As Exception
                MsgBox(ex1.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ClosePreviewWindow()
        SendMessage(hHwnd, WM_Cap_Paki_DISCONNECT, iDevice, 0)
        DestroyWindow(hHwnd)
    End Sub

    Private Sub btnCapture_Click(sender As Object, e As EventArgs) Handles btnCapture.Click
        Try
            If btnCapture.Text = "Camera" Then
                Call OpenPreviewWindows()
                btnCapture.Text = "Capture"
            ElseIf btnCapture.Text = "Capture" Then
                Dim data As IDataObject
                Dim Bmap As Image
                SendMessage(hHwnd, WM_Cap_EDIT_COPY, 0, 0)
                data = Clipboard.GetDataObject()
                If data.GetDataPresent(GetType(Bitmap)) Then
                    Bmap = CType(data.GetData(GetType(Bitmap)), Image)
                    PictureBox1.Image = Bmap
                    ClosePreviewWindow()
                End If
                btnCapture.Text = "Camera"
                PictureBox1.Enabled = True
                PictureBox1.Enabled = True
                Call ClosePreviewWindow()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CheckEdit2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit2.CheckedChanged
        If CheckEdit2.Checked = True Then
            CheckEdit3.Enabled = False
            CheckEdit3.Checked = False
            CheckEdit4.Enabled = False
            CheckEdit4.Checked = False
        Else
            CheckEdit3.Enabled = True
            CheckEdit4.Enabled = True
        End If
    End Sub

    Dim sel As New selectemp

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Timer1.Start()
        If sel Is Nothing OrElse sel.IsDisposed OrElse sel.MinimizeBox Then
            sel.Close()
            sel = New selectemp
        End If
        sel.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Dim query As MySqlCommand = SQLConnection.CreateCommand
            query.CommandText = "select name from db_tmpname"
            Dim quer1 As String = CType(query.ExecuteScalar, String)
            TextBox3.Text = quer1.ToString
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        Timer1.Stop()
    End Sub

End Class