Imports System.IO
Imports DevExpress.Utils.Menu

Public Class ChangeData
    Private Declare Function ShellEx Lib "shell32.dll" Alias "ShellExecuteA" (
   ByVal hWnd As Integer, ByVal lpOperation As String,
   ByVal lpFile As String, ByVal lpParameters As String,
   ByVal lpDirectory As String, ByVal nShowCmd As Integer) As Integer
    Dim connectionString As String
    Dim SQLConnection As MySqlConnection = New MySqlConnection
    Dim oDt_sched As New DataTable()

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        Application.EnableVisualStyles()

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


    Private Function GetOpenFileDialog() As OpenFileDialog
        Dim openFileDialog As New OpenFileDialog

        openFileDialog.CheckPathExists = True
        openFileDialog.CheckFileExists = True

        openFileDialog.Filter = "Any Files(*.txt)|*.txt"

        openFileDialog.Multiselect = False
        openFileDialog.AddExtension = True
        openFileDialog.ValidateNames = True
        openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

        Return openFileDialog
    End Function


    Private Sub loadinfo()
        GridControl1.RefreshDataSource()
        Dim table As New DataTable
        Dim sqlcommand As New MySqlCommand
        Try
            'sqlcommand.CommandText = "Select IdRec as IdRecruitment, FullName from db_recruitment where status = 'Pending' or status = 'In Progress'"
            sqlcommand.CommandText = "select idrec as IdRecruitment, FullName from db_recruitment"
            sqlcommand.Connection = SQLConnection
            Dim tbl_par As New DataTable
            Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(table)
            GridControl1.DataSource = table
        Catch ex As Exception
        End Try
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
                           "(idrec, Position, Company, Manager, Address, Period, Until, BasicSalary, AdditionalSalary, TotalSalary, QuitReason)" +
                           " values (@idrec, @Company, @Position, @Manager, @Address, @Period, @Until, @BasicSalary, @AdditionalSalary, @TotalSalary, @QuitReason)"
            End If
            cmmd.Parameters.AddWithValue("@Idrec", txtidrec.Text)
            cmmd.Parameters.AddWithValue("@NoId", Label38.Text)
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
                                    "(idrec, Certificates, Years, Reasons)" +
                                    " values (@idrec, @Certificates, @Years, @Reasons)"
            End If
            cmmd.Parameters.AddWithValue("@idrec", txtidrec.Text)
            cmmd.Parameters.AddWithValue("@noid", Label38.Text)
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

    Sub family()
        Dim cmmd As MySqlCommand = SQLConnection.CreateCommand
        Try
            If act = "edit" Then
                cmmd.CommandText = "update db_family set " +
                                    " MemberName = @MemberName" +
                                    ", Relationship = @Relationship " +
                                    ", Gender = @gender" +
                                    ", Address = @Address" +
                                    ", Occupation = @Occupation" +
                                    ", PhoneNo = @PhoneNo" +
                                    " where NoId = @Noid"
            Else
                cmmd.CommandText = "insert into db_family " +
                          "(idrec, RelationShip, MemberName, Gender, Address, Occupation, PhoneNo)" +
                          " values (@idrec, @Relationship, @MemberName, @Gender, @Address, @Occupation, @PhoneNo)"
            End If
            cmmd.Parameters.AddWithValue("@Noid", Label38.Text)
            cmmd.Parameters.AddWithValue("@idrec", txtidrec.Text)
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
                           "(Idrec, SkillName, SkillLevel, SKillDescription) " +
                           "values (@idrec, @SkillName, @SkillLevel, @SkillDescription)"
            End If
            cmmd.Parameters.AddWithValue("@NoId", Label38.Text)
            cmmd.Parameters.AddWithValue("@idrec", txtidrec.Text)
            cmmd.Parameters.AddWithValue("@SkillName", skillname.Text)
            cmmd.Parameters.AddWithValue("@SkillLevel", skilllevel.Text)
            cmmd.Parameters.AddWithValue("@SkillDescription", skilldesc.Text)
            cmmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        skill()
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
                            "(IdRec, School, GraduatedYear, StudyField) " +
                            "values (@idrec, @School, @GraduatedYear, @StudyField)"
            End If
            cmmd.Parameters.AddWithValue("@NoId", Label38.Text)
            cmmd.Parameters.AddWithValue("@idrec", txtidrec.Text)
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

    Sub delschool()
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "delete from db_education where NoId = @noid"
        query.Parameters.AddWithValue("@noid", Label38.Text)
        query.ExecuteNonQuery()
        MsgBox("Deleted")
        edu()
    End Sub

    Sub delcer()
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "delete from db_certificates where NoId = @noid"
        query.Parameters.AddWithValue("@noid", Label38.Text)
        query.ExecuteNonQuery()
        MsgBox("Deleted")
        certificates()
    End Sub

    Sub delfam()
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "delete from db_family where NoId = @noid"
        query.Parameters.AddWithValue("@noid", Label38.Text)
        query.ExecuteNonQuery()
        MsgBox("Deleted")
        family()
    End Sub

    Sub delexp()
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "delete from db_exp where NoId = @noid"
        query.Parameters.AddWithValue("@noid", Label38.Text)
        query.ExecuteNonQuery()
        MsgBox("Deleted")
        exp()
    End Sub

    Sub delskill()
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "delete from db_skill where NoId = @noid"
        query.Parameters.AddWithValue("@noid", Label38.Text)
        query.ExecuteNonQuery()
        MsgBox("Deleted")
        skill()
    End Sub

    Dim datatable As New DataTable

    Public Sub edu()
        GridControl3.Refresh()
        Dim table As New DataTable
        Dim sqlcommand As New MySqlCommand
        Try
            sqlcommand.CommandText = "select NoId, Idrec as IdRecruitment, School as SchoolOrUniversity, GraduatedYear, StudyField from db_education where idrec = '" & txtidrec.Text & "'"
            sqlcommand.Connection = SQLConnection
            DataTable.Load(sqlcommand.ExecuteReader)

            Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(table)
            GridControl3.DataSource = datatable
            'GridControl3.DataMember = DataTable.TableName
        Catch ex As Exception
        End Try
        txtschoolname.Text = ""
        Label38.Text = ""
        txtyears.Text = ""
        txtmajor.Text = ""
    End Sub

    Public Sub cert()
        GridControl2.Refresh()
        Dim table As New DataTable
        Dim sqlcommand As New MySqlCommand
        Try
            sqlcommand.CommandText = "select NoId, Idrec as IdRecruitment, Certificates, Years, Reasons from db_certificates where idrec = '" & txtidrec.Text & "'"
            sqlcommand.Connection = SQLConnection
            Dim tbl_par As New DataTable
            Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(table)
            GridControl2.DataSource = table
        Catch ex As Exception
            MsgBox("1" & ex.Message & "'")
        End Try
        txtcertificate.Text = ""
        txtyear.Text = ""
        txtreason.Text = ""
    End Sub

    Public Sub fam()
        GridControl4.RefreshDataSource()
        Dim table As New DataTable
        Dim sqlcommand As New MySqlCommand
        Try
            sqlcommand.CommandText = "select NoId, Idrec as IdRecruitment, MemberName, Relationship, Gender, Address, Occupation, PhoneNo from db_family where idrec = '" & txtidrec.Text & "'"
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

    Public Sub exp()
        GridControl5.RefreshDataSource()
        Dim table As New DataTable
        Dim sqlcommand As New MySqlCommand
        Try
            sqlcommand.CommandText = "select NoId, Idrec as IdRecruitment, Position, Company, Manager, Address, Period, Until, BasicSalary, AdditionalSalary, TotalSalary, QuitReason from db_exp where idrec = '" & txtidrec.Text & "'"
            sqlcommand.Connection = SQLConnection
            Dim tbl_par As New DataTable
            Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(table)
            GridControl5.DataSource = table
        Catch ex As Exception
            'MsgBox(ex.Message)
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

    Public Sub skill()
        GridControl6.RefreshDataSource()
        Dim table As New DataTable
        Dim sqlcommand As New MySqlCommand
        Try
            sqlcommand.CommandText = "select NoId, Idrec as IdRecruitment, SkillName, SkillLevel, SkillDescription from db_empskill where idrec = '" & txtidrec.Text & "'"
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

    'Sub retrieved()
    '    Dim cmmd As MySqlCommand = SQLConnection.CreateCommand
    '    cmmd.CommandText = "select cv from db_recruitment where idrec = '" & txtidrec.Text & "'"
    '    Dim dr As MySqlDataReader
    '    dr = cmmd.ExecuteReader
    '    dr.Read()
    '    Dim filebytes() As Byte = CType(dr(0), Byte())
    '    Dim fstream As New FileStream(dr(0).ToString, FileMode.Create, FileAccess.Write)
    '    fstream.Write(filebytes, 0, filebytes.Length)
    '    File.WriteAllBytes("C:\testpdf.pdf", fstream)
    '    fstream.Close()
    'End Sub

    Sub download()
        Dim sFilePath As String
        Dim buffer As Byte()
        Using cmd As New MySqlCommand("select cv from db_recruitment where idrec = '" & txtidrec.Text & "'", SQLConnection)
            'Using cmd As New MySqlCommand("Select Top 1 PDF From PDF", SQLConnection)
            buffer = CType(cmd.ExecuteScalar(), Byte())
        End Using
        sFilePath = System.IO.Path.GetTempFileName()
        System.IO.File.Move(sFilePath, System.IO.Path.ChangeExtension(sFilePath, ".pdf"))
        sFilePath = System.IO.Path.ChangeExtension(sFilePath, ".pdf")
        System.IO.File.WriteAllBytes(sFilePath, buffer)
        Dim act As Action(Of String) = New Action(Of String)(AddressOf OpenPDFFile)
        act.BeginInvoke(sFilePath, Nothing, Nothing)
    End Sub

    Private Shared Sub OpenPDFFile(ByVal sFilePath)
        Using p As New System.Diagnostics.Process
            p.StartInfo = New System.Diagnostics.ProcessStartInfo(CType(sFilePath, String))
            p.Start()
            p.WaitForExit()
            Try
                System.IO.File.Delete(CType(sFilePath, String))
            Catch
            End Try
        End Using
    End Sub

    Public Sub updatechange2()
        Dim dta, dtb, dtr As Date
        txtapplieddate.Format = DateTimePickerFormat.Custom
        txtapplieddate.CustomFormat = "yyyy-MM-dd"
        dta = txtapplieddate.Value

        txtbod.Format = DateTimePickerFormat.Custom
        txtbod.CustomFormat = "yyyy-MM-dd"
        dtb = txtbod.Value
        Dim sqlcommand As New MySqlCommand
        Try
            sqlcommand.CommandText = "UPDATE db_recruitment SET" +
                                     " FullName = @FullName" +
                                     ", PlaceOfBirth = @PlaceOfBirth" +
                                     ", DateOfBirth = @DateOfBirth" +
                                     ", Address = @Address" +
                                     ", Gender = @Gender" +
                                     ", Religion = @Religion" +
                                     ", PhoneNumber = @PhoneNumber" +
                                     ", IdNumber = @IdNumber" +
                                     ", Photo = @Photo" +
                                     ", Status = @Status" +
                                     ", InterviewDate = @InterviewDate" +
                                     ", Reason = @Reason" +
                                     ", Position = @Position" +
                                     ", NickName = @NickName" +
                                     ", ApplicationDate = @Applicationdate" +
                                     ", Weight = @Weight " +
                                     ", Height = @Height " +
                                     ", BloodType = @BloodType " +
                                     ", City = @City " +
                                     ", ZIP = @Zip " +
                                     ", HomeNumber = @HomeNumber " +
                                     ", RecommendedBy = @RecommendedBy " +
                                     ", Martial = @Martial " +
                                     ", LastSalary = @LastSalary " +
                                     ", OtherIncome = @OtherIncome " +
                                     ", ExpectedSalary = @ExpectedSalary" +
                                     ", ExpFacilities = @ExpFacilities" +
                                     ", FavoriteJob = @FavoriteJob" +
                                     ", Fwhy = @Fwhy" +
                                     ", AppliedHere = @AppliedHere" +
                                     ", AWhy = @Awhy" +
                                     ", Family = @Family" +
                                     ", Who = @Who " +
                                     ", Strenghts = @Strenghts" +
                                     ", Weakness = @Weakness" +
                                     ", Suitable = @Suitable" +
                                     ", CarrierObject = @CarrierObject" +
                                     ", Reference = @Reference" +
                                     ", PrivateEmail = @Private" +
                                     " WHERE IdRec = @IdRec"
            sqlcommand.Connection = SQLConnection
            sqlcommand.Parameters.AddWithValue("@IdRec", txtidrec.Text)
            sqlcommand.Parameters.AddWithValue("@FullName", txtcandname.Text)
            sqlcommand.Parameters.AddWithValue("@PlaceOfBirth", txtbp.Text)
            sqlcommand.Parameters.AddWithValue("@DateOfBirth", dtb.ToString("yyyy-MM-dd"))
            sqlcommand.Parameters.AddWithValue("@Address", txtadd.Text)
            sqlcommand.Parameters.AddWithValue("@Gender", txtgend.Text)
            sqlcommand.Parameters.AddWithValue("@Religion", txtrel.Text)
            sqlcommand.Parameters.AddWithValue("@PhoneNumber", txtphoneno.Text)
            sqlcommand.Parameters.AddWithValue("@IdNumber", txtidno.Text)
            If Not ImageEdit1.Text Is Nothing Then
                Dim param As New MySqlParameter("@Photo", ImageToByte(pictureEdit))
                sqlcommand.Parameters.Add(param)
            Else
                sqlcommand.Parameters.AddWithValue("@Photo", "")
            End If
            sqlcommand.Parameters.AddWithValue("@Status", txtofloc.Text)
            sqlcommand.Parameters.AddWithValue("@InterviewDate", dtr.ToString("yyyy-MM-dd"))
            sqlcommand.Parameters.AddWithValue("@Reason", txtcandreason.Text)
            sqlcommand.Parameters.AddWithValue("@Position", TextEdit7.Text)
            sqlcommand.Parameters.AddWithValue("@NickName", txtnick.Text)
            sqlcommand.Parameters.AddWithValue("@ApplicationDate", dta.ToString("yyyy-MM-dd"))
            sqlcommand.Parameters.AddWithValue("@Weight", txtkg.Text)
            sqlcommand.Parameters.AddWithValue("@Height", txtcm.Text)
            sqlcommand.Parameters.AddWithValue("@BloodType", txtblood.Text)
            sqlcommand.Parameters.AddWithValue("@City", txtcity.Text)
            sqlcommand.Parameters.AddWithValue("@Zip", txtzip.Text)
            sqlcommand.Parameters.AddWithValue("@HomeNumber", txthome.Text)
            sqlcommand.Parameters.AddWithValue("@RecommendedBy", txtrecby.Text)
            sqlcommand.Parameters.AddWithValue("@Martial", ComboBoxEdit4.Text)
            sqlcommand.Parameters.AddWithValue("@LastSalary", TextBox3.Text)
            sqlcommand.Parameters.AddWithValue("@OtherIncome", TextBox4.Text)
            sqlcommand.Parameters.AddWithValue("@ExpectedSalary", TextBox5.Text)
            sqlcommand.Parameters.AddWithValue("@ExpFacilities", RichTextBox1.Text)
            sqlcommand.Parameters.AddWithValue("@FavoriteJob", TextBox6.Text)
            sqlcommand.Parameters.AddWithValue("@Fwhy", RichTextBox2.Text)
            sqlcommand.Parameters.AddWithValue("@AppliedHere", CheckEdit1.Checked)
            sqlcommand.Parameters.AddWithValue("@AWhy", RichTextBox3.Text)
            sqlcommand.Parameters.AddWithValue("@Family", CheckEdit2.Checked)
            sqlcommand.Parameters.AddWithValue("@Who", RichTextBox4.Text)
            sqlcommand.Parameters.AddWithValue("@Strenghts", RichTextBox5.Text)
            sqlcommand.Parameters.AddWithValue("@Weakness", RichTextBox6.Text)
            sqlcommand.Parameters.AddWithValue("@Suitable", RichTextBox7.Text)
            sqlcommand.Parameters.AddWithValue("@CarrierObject", RichTextBox8.Text)
            sqlcommand.Parameters.AddWithValue("@Reference", RichTextBox9.Text)
            sqlcommand.Parameters.AddWithValue("@private", txtwemail.Text)
            'Dim sqlquery As MySqlCommand = SQLConnection.CreateCommand
            'Dim finfo As New FileInfo(Label39.Text)
            'Dim numBytes As Long = finfo.Length
            'Dim fstream As New FileStream(Label39.Text, FileMode.Open, FileAccess.Read)
            'Dim br As New BinaryReader(fstream)
            'Dim data As Byte() = br.ReadBytes(CInt(numBytes))
            'br.Close()
            'fstream.Close()
            'If Not data Is Nothing Then
            '    sqlcommand.Parameters.AddWithValue("@cv", data)
            'Else
            '    sqlcommand.Parameters.AddWithValue("@cv", "")
            'End If
            sqlcommand.Connection = SQLConnection
            sqlcommand.ExecuteNonQuery()
            MsgBox("Data succesfully changed")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        Dim datatabl As New DataTable
        Dim sqlCommand As New MySqlCommand
        datatabl.Clear()
        Dim param As String = ""
        Try
            param = "and FullName='" + GridView1.GetFocusedRowCellValue("FullName").ToString() + "'"
        Catch ex As Exception
        End Try
        Try
            sqlCommand.CommandText = "SELECT * FROM db_recruitment WHERE 1 = 1 " + param.ToString()
            sqlCommand.Connection = SQLConnection
            Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(datatabl)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If datatabl.Rows.Count > -1 Then
            txtidrec.Text = datatabl.Rows(0).Item(0).ToString()
            TextEdit1.Text = datatabl.Rows(0).Item(1).ToString
            txtcandname.Text = datatabl.Rows(0).Item(2).ToString()
            txtbp.Text = datatabl.Rows(0).Item(3).ToString
            txtbod.Text = datatabl.Rows(0).Item(4).ToString
            txtadd.Text = datatabl.Rows(0).Item(5).ToString
            txtgend.Text = datatabl.Rows(0).Item(6).ToString()
            txtrel.Text = datatabl.Rows(0).Item(7).ToString
            txtphoneno.Text = datatabl.Rows(0).Item(8).ToString
            txtidno.Text = datatabl.Rows(0).Item(9).ToString()
            txtofloc.Text = datatabl.Rows(0).Item(11).ToString()
            ' DateTimePicker2.Value = CDate(datatabl.Rows(0).Item(12).ToString())
            txtcandreason.Text = datatabl.Rows(0).Item(15).ToString()
            Dim filefoto As Byte() = CType(datatabl.Rows(0).Item(10), Byte())
            If filefoto.Length > 0 Then
                pictureEdit.Image = ByteToImage(filefoto)
            Else
                pictureEdit.Image = Nothing
                pictureEdit.Refresh()
            End If
            TextEdit7.Text = datatabl.Rows(0).Item(17).ToString()
            txtnick.Text = datatabl.Rows(0).Item(19).ToString()
            txtapplieddate.Text = datatabl.Rows(0).Item(20).ToString()
            txtkg.Text = datatabl.Rows(0).Item(21).ToString
            txtcm.Text = datatabl.Rows(0).Item(22).ToString
            txtblood.Text = datatabl.Rows(0).Item(23).ToString
            txtcity.Text = datatabl.Rows(0).Item(24).ToString
            txtzip.Text = datatabl.Rows(0).Item(25).ToString
            txthome.Text = datatabl.Rows(0).Item(26).ToString
            txtrecby.Text = datatabl.Rows(0).Item(27).ToString
            ComboBoxEdit4.Text = datatabl.Rows(0).Item(28).ToString
            TextBox3.Text = datatabl.Rows(0).Item(29).ToString
            TextBox4.Text = datatabl.Rows(0).Item(30).ToString
            TextBox5.Text = datatabl.Rows(0).Item(18).ToString
            RichTextBox1.Text = datatabl.Rows(0).Item(31).ToString
            TextBox6.Text = datatabl.Rows(0).Item(32).ToString
            RichTextBox2.Text = datatabl.Rows(0).Item(33).ToString
            CheckEdit1.Checked = CBool(datatabl.Rows(0).Item(34).ToString)
            RichTextBox3.Text = datatabl.Rows(0).Item(35).ToString
            CheckEdit2.Checked = CBool(datatabl.Rows(0).Item(36).ToString)
            RichTextBox4.Text = datatabl.Rows(0).Item(37).ToString
            RichTextBox5.Text = datatabl.Rows(0).Item(38).ToString
            RichTextBox6.Text = datatabl.Rows(0).Item(39).ToString
            RichTextBox7.Text = datatabl.Rows(0).Item(40).ToString
            RichTextBox8.Text = datatabl.Rows(0).Item(41).ToString
            RichTextBox9.Text = datatabl.Rows(0).Item(42).ToString
            txtwemail.Text = datatabl.Rows(0).Item(43).ToString
            edu()
            cert()
            skill()
            fam()
            exp()
        End If
    End Sub

    Private Sub ChangeData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        loadinfo()
        GridView1.BestFitColumns()
        GridView2.BestFitColumns()
        GridView3.BestFitColumns()
        GridView4.BestFitColumns()
        GridView5.BestFitColumns()
        GridView6.BestFitColumns()
        act = "input"
        Label39.Text = "C:\pdffile\file.pdf"
        edu()
    End Sub

    Dim openfd As New OpenFileDialog

    Private Sub btnSave_Click(sender As Object, e As EventArgs)
        updatechange2()
    End Sub

    Dim dt1 As Date
    Dim dt2 As Date
    Dim dt3 As TimeSpan
    Dim diff As Double

    Private Sub txtbod_ValueChanged(sender As Object, e As EventArgs) Handles txtbod.ValueChanged
        dt1 = CDate(txtbod.Value.ToShortDateString)
        dt2 = Date.Now
        dt3 = (dt2 - dt1)
        diff = dt3.Days
        txtage.Text = Str(Int(diff / 365))
    End Sub

    Private Sub SimpleButton9_Click(sender As Object, e As EventArgs) Handles SimpleButton9.Click
        updatechange2()
    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        school()
        act = "input"
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        certificates()
        act = "input"
    End Sub

    Private Sub SimpleButton13_Click(sender As Object, e As EventArgs) Handles SimpleButton13.Click
        insertskill()
        act = "input"
    End Sub

    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs) Handles SimpleButton8.Click
        insertexp()
        act = "input"
    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        family()
        act = "input"
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

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        Using dialog As New OpenFileDialog
            If dialog.ShowDialog() <> DialogResult.OK Then Return
            ImageEdit1.Image = Image.FromFile(dialog.FileName)
            pictureEdit.Image = Image.FromFile(dialog.FileName)
        End Using
    End Sub

    Private Sub OpenPreviewWindows()
        Try
            Dim iHeight As Integer = pictureEdit.Height
            Dim iWidth As Integer = pictureEdit.Width
            hHwnd = capCreateCaptureWindowA((iDevice), WS_VISIBLE Or WS_CHILD, 0, 0, 640, 480, pictureEdit.Handle.ToInt32, 0)
            Try
                If SendMessage(hHwnd, WM_Cap_Paki_CONNECT, iDevice, 0) Then
                    SendMessage(hHwnd, WM_Cap_SET_SCALE, True, 0)
                    SendMessage(hHwnd, WM_Cap_SET_PREVIEWRATE, 66, 0)
                    SendMessage(hHwnd, WM_Cap_SET_PREVIEW, True, 0)
                    SetWindowPos(hHwnd, HWND_BOTTOM, 0, 0, pictureEdit.Width, pictureEdit.Height, SWP_NOMOVE Or SWP_NOZORDER)
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
                    pictureEdit.Image = Bmap
                    ClosePreviewWindow()
                End If
                btnCapture.Text = "Camera"
                pictureEdit.Enabled = True
                pictureEdit.Enabled = True
                Call ClosePreviewWindow()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub SavePdf()
        'Try
        openfd.InitialDirectory = "C:\pdffile"
        openfd.Title = "Open a CV FIle"
        openfd.Filter = "PDF Files|*.pdf|Text Files|*.txt|Word FIles|*.docx"
        openfd.Filter = "PDF Files|*.pdf"
        openfd.ShowDialog()
        Dim sqlquery As MySqlCommand = SQLConnection.CreateCommand
        Dim finfo As New FileInfo(Label38.Text)
        Dim numBytes As Long = finfo.Length
        Dim fstream As New FileStream(Label38.Text, FileMode.Open, FileAccess.Read)
        Dim br As New BinaryReader(fstream)
        Dim data As Byte() = br.ReadBytes(CInt(numBytes))
        br.Close()
        fstream.Close()
        sqlquery.CommandText = "update db_recruitment set (cv) = (@cv) where idrec = '" & txtidrec.Text & "'"
        sqlquery.Parameters.AddWithValue("@cv", data)
        sqlquery.ExecuteNonQuery()
        MsgBox("Saved")
    End Sub

    Private Sub SimpleButton10_Click(sender As Object, e As EventArgs) Handles SimpleButton10.Click
        Try
            openfd.InitialDirectory = "C:\"
            openfd.Title = "Open a CV FIle"
            openfd.Filter = "PDF Files|*.pdf|Text Files|*.txt|Word FIles|*.docx"
            openfd.ShowDialog()
            Label39.Text = openfd.FileName
            Dim sqlcommand As MySqlCommand = SQLConnection.CreateCommand
            Dim finfo As New FileInfo(Label39.Text)
            Dim numBytes As Long = finfo.Length
            Dim fstream As New FileStream(Label39.Text, FileMode.Open, FileAccess.Read)
            Dim br As New BinaryReader(fstream)
            Dim data As Byte() = br.ReadBytes(CInt(numBytes))
            br.Close()
            fstream.Close()
            sqlcommand.CommandText = "update db_recruitment set cv = @cv where idrec = @emp"
            sqlcommand.Parameters.AddWithValue("@emp", txtidrec.Text)
            If Not data Is Nothing Then
                sqlcommand.Parameters.AddWithValue("@cv", data)
            Else
                sqlcommand.Parameters.AddWithValue("@cv", "")
            End If
            sqlcommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("CV" & ex.Message)
        End Try
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
            sqlcommand.CommandText = "Select NoId, Idrec, School, GraduatedYear, StudyField from db_education where 1 = 1 " + param.ToString()
            sqlcommand.Connection = SQLConnection
            Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(datatabl)
        Catch ex As Exception
        End Try
        If datatabl.Rows.Count > 0 Then
            Label38.Text = datatabl.Rows(0).Item(0).ToString
            txtschoolname.Text = datatabl.Rows(0).Item(2).ToString
            txtyears.Text = datatabl.Rows(0).Item(3).ToString
            txtmajor.Text = datatabl.Rows(0).Item(4).ToString
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        txtschoolname.Text = ""
        txtyears.Text = ""
        Label38.Text = ""
        txtmajor.Text = ""
        act = "input"
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
            sqlcommand.CommandText = "Select NoId, Idrec, Certificates, Years, Reasons from db_certificates where 1 = 1 " + param.ToString()
            sqlcommand.Connection = SQLConnection
            Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(datatabl)
        Catch ex As Exception
        End Try
        If datatabl.Rows.Count > 0 Then
            Label38.Text = datatabl.Rows(0).Item(0).ToString
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
            sqlcommand.CommandText = "Select NoId, Idrec, MemberName, Relationship, Gender, Address, Occupation, PhoneNo from db_family where 1 = 1 " + param.ToString()
            sqlcommand.Connection = SQLConnection
            Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(datatabl)
        Catch ex As Exception
        End Try
        If datatabl.Rows.Count > 0 Then
            Label38.Text = datatabl.Rows(0).Item(0).ToString
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
            sqlcommand.CommandText = "Select NoId, Idrec, Position, Company, Manager, Address, Period, Until, BasicSalary, AdditionalSalary, TotalSalary, QuitReason from db_exp where 1 = 1 " + param.ToString()
            sqlcommand.Connection = SQLConnection
            Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(datatabl)
        Catch ex As Exception
        End Try
        If datatabl.Rows.Count > 0 Then
            Label38.Text = datatabl.Rows(0).Item(0).ToString
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
            sqlcommand.CommandText = "Select NoId, IdRec, SkillName, SkillLevel, SkillDescription from db_empskill where 1 = 1 " + param.ToString()
            sqlcommand.Connection = SQLConnection
            Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(datatabl)
        Catch ex As Exception
        End Try
        If datatabl.Rows.Count > 0 Then
            Label38.Text = datatabl.Rows(0).Item(0).ToString
            skillname.Text = datatabl.Rows(0).Item(2).ToString
            skilllevel.Text = datatabl.Rows(0).Item(3).ToString
            skilldesc.Text = datatabl.Rows(0).Item(4).ToString
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        txtcertificate.Text = ""
        txtyear.Text = ""
        txtreason.Text = ""
        act = "input"
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        txtmember.Text = ""
        txtrelation.Text = ""
        txtmemgender.Text = ""
        txtmemadd.Text = ""
        txtocc.Text = ""
        txtmemph.Text = ""
        act = "input"
    End Sub

    Private Sub SimpleButton11_Click(sender As Object, e As EventArgs) Handles SimpleButton11.Click
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

    Private Sub SimpleButton12_Click(sender As Object, e As EventArgs) Handles SimpleButton12.Click
        skillname.Text = ""
        skilllevel.Text = ""
        skilldesc.Text = ""
        act = "input"
    End Sub


    Private Sub SimpleButton14_Click(sender As Object, e As EventArgs) Handles SimpleButton14.Click
        download()
        ' retrieved()
        'Dim quer As MySqlCommand = SQLConnection.CreateCommand
        'quer.CommandText = "select cv from db_recruitment where "
    End Sub

    Private Sub txtbp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtbp.KeyPress
        Dim ch As Char = e.KeyChar
        If Char.IsDigit(ch) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtidno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtidno.KeyPress
        Dim ch As Char = e.KeyChar
        If Char.IsLetter(ch) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtrel_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtrel.KeyPress
        Dim ch As Char = e.KeyChar
        If Char.IsDigit(ch) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtblood_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtblood.KeyPress
        Dim ch As Char = e.KeyChar
        If Char.IsDigit(ch) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtkg_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtkg.KeyPress
        Dim ch As Char = e.KeyChar
        If Char.IsLetter(ch) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtcm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcm.KeyPress
        Dim ch As Char = e.KeyChar
        If Char.IsLetter(ch) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtphoneno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtphoneno.KeyPress
        Dim ch As Char = e.KeyChar
        If Char.IsLetter(ch) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txthome_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txthome.KeyPress
        Dim ch As Char = e.KeyChar
        If Char.IsLetter(ch) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        Dim ch As Char = e.KeyChar
        If Char.IsLetter(ch) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        Dim ch As Char = e.KeyChar
        If Char.IsLetter(ch) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        Dim ch As Char = e.KeyChar
        If Char.IsLetter(ch) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtbasic_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtbasic.KeyPress
        Dim ch As Char = e.KeyChar
        If Char.IsLetter(ch) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtaddi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtaddi.KeyPress
        Dim ch As Char = e.KeyChar
        If Char.IsLetter(ch) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txttotalsa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttotalsa.KeyPress
        Dim ch As Char = e.KeyChar
        If Char.IsLetter(ch) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtcandname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcandname.KeyPress
        Dim ch As Char = e.KeyChar
        If Char.IsDigit(ch) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtnick_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnick.KeyPress
        Dim ch As Char = e.KeyChar
        If Char.IsDigit(ch) Then
            e.Handled = True
        End If
    End Sub

    Private Sub CheckEdit3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit3.CheckedChanged
        If CheckEdit3.Checked = True Then
            DateTimePicker2.Enabled = True
            Dim dtr As DateTime
            DateTimePicker2.Format = DateTimePickerFormat.Custom
            DateTimePicker2.CustomFormat = "yyyy-MM-dd"
            dtr = DateTimePicker2.Value
        ElseIf CheckEdit3.Checked = False Then
            DateTimePicker2.Enabled = False
            Dim dtr As DateTime
            DateTimePicker2.Format = DateTimePickerFormat.Custom
            DateTimePicker2.CustomFormat = "----"
            dtr = DateTimePicker2.Value
        End If
    End Sub

    Private Sub SimpleButton15_Click(sender As Object, e As EventArgs) Handles SimpleButton15.Click
        delschool()
        edu()
    End Sub

    Private Sub SimpleButton16_Click(sender As Object, e As EventArgs) Handles SimpleButton16.Click
        delcer()
        cert()
    End Sub

    Private Sub SimpleButton17_Click(sender As Object, e As EventArgs) Handles SimpleButton17.Click
        delfam()
        fam()
    End Sub

    Private Sub SimpleButton18_Click(sender As Object, e As EventArgs) Handles SimpleButton18.Click
        delskill()
        skill()
    End Sub

    Private Sub SimpleButton19_Click(sender As Object, e As EventArgs) Handles SimpleButton19.Click
        delexp()
        exp()
    End Sub

    Private Sub GridView3_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GridView3.PopupMenuShowing
        If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Row Then
            e.Menu.Items.Add(New DXMenuItem("Delete..", New EventHandler(AddressOf SimpleButton15_Click)))
        End If
    End Sub

    Private Sub GridView2_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GridView2.PopupMenuShowing
        If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Row Then
            e.Menu.Items.Add(New DXMenuItem("Delete..", New EventHandler(AddressOf SimpleButton16_Click)))
        End If
    End Sub

    Private Sub GridView4_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GridView4.PopupMenuShowing
        If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Row Then
            e.Menu.Items.Add(New DXMenuItem("Delete..", New EventHandler(AddressOf SimpleButton17_Click)))
        End If
    End Sub

    Private Sub GridView5_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GridView5.PopupMenuShowing
        If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Row Then
            e.Menu.Items.Add(New DXMenuItem("Delete..", New EventHandler(AddressOf SimpleButton18_Click)))
        End If
    End Sub

    Private Sub GridView6_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GridView6.PopupMenuShowing
        If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Row Then
            e.Menu.Items.Add(New DXMenuItem("Delete..", New EventHandler(AddressOf SimpleButton19_Click)))
        End If
    End Sub
End Class