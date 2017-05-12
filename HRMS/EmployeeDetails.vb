Imports System.IO

Public Class EmployeeDetails
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

    Private Sub EmployeeDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "select employeecode from db_tmpname where 1 = 1"
        Dim quer As String = CType(query.ExecuteScalar, String)
        TextBox1.Text = quer.ToString
        loaddata1()
        loadsc()
        chng()
        loadcert()
        loadschool()
        loadwarn()
        loadexp()
        loadskill()
        loadfamily()
        GridView2.BestFitColumns()
        GridView3.BestFitColumns()
        GridView4.BestFitColumns()
        GridView5.BestFitColumns()
        GridView6.BestFitColumns()
        GridView7.BestFitColumns()
    End Sub

    Dim tbl_par2 As New DataTable

    Sub loadschool()
        Dim sqlCommand As New MySqlCommand
        sqlCommand.CommandText = "Select EmployeeCode, School as SchoolOrUniversity, GraduatedYear, StudyField from db_education where EmployeeCode = '" & TextBox1.Text & "'"
        sqlCommand.Connection = SQLConnection
        Dim dt As New DataTable
        dt.Load(sqlCommand.ExecuteReader)
        GridControl3.DataSource = dt
    End Sub

    Sub loadcert()
        Dim sqlcommand As New MySqlCommand
        sqlcommand.CommandText = "Select EmployeeCode, Certificates, Years, Reasons from db_certificates where employeecode = '" & TextBox1.Text & "'"
        sqlcommand.Connection = SQLConnection
        Dim dt As New DataTable
        dt.Load(sqlcommand.ExecuteReader)
        GridControl2.DataSource = dt
    End Sub

    Sub loadwarn()
        Dim sqlcommand As New MySqlCommand
        sqlcommand.CommandText = "Select tgl as Dates, WarningLevel, OffenseType, DescriptionOfInfraction, Plan, Consequences, Amount as PenaltyAmount from db_warning where employeecode = '" & TextBox1.Text & "'"
        sqlcommand.Connection = SQLConnection
        Dim dt As New DataTable
        dt.Load(sqlcommand.ExecuteReader)
        GridControl1.DataSource = dt
    End Sub

    Sub loadexp()
        Dim sqlcommand As New MySqlCommand
        sqlcommand.CommandText = "Select EmployeeCode, Company, Manager, Address, Period, Until, BasicSalary, AdditionalSalary, TotalSalary, QuitReason from db_exp where employeecode = '" & TextBox1.Text & "'"
        sqlcommand.Connection = SQLConnection
        Dim dt As New DataTable
        dt.Load(sqlcommand.ExecuteReader)
        GridControl5.DataSource = dt
    End Sub

    Sub loadskill()
        Dim sqlcommand As New MySqlCommand
        sqlcommand.CommandText = "Select EmployeeCode, SkillName, SkillLevel, SkillDescription from db_empskill where EmployeeCode = '" & TextBox1.Text & "'"
        sqlcommand.Connection = SQLConnection
        Dim dt As New DataTable
        dt.Load(sqlcommand.ExecuteReader)
        GridControl6.DataSource = dt
    End Sub

    Sub loadfamily()
        Dim sqlcommand As New MySqlCommand
        sqlcommand.CommandText = "Select EmployeeCode, MemberName, Relationship, Gender, Address, Occupation, PhoneNo from db_family where employeecode = '" & TextBox1.Text & "'"
        sqlcommand.Connection = SQLConnection
        Dim dt As New DataTable
        dt.Load(sqlcommand.ExecuteReader)
        GridControl4.DataSource = dt
    End Sub

    Dim tbl_par3 As New DataTable

    Sub loadsc()
        Dim sqlcommand As MySqlCommand = SQLConnection.CreateCommand
        sqlcommand.CommandText = "select * from db_statuschange where employeecode = '" & TextBox1.Text & "'"
        Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
        Dim cb As New MySqlCommandBuilder(adapter)
        adapter.Fill(tbl_par3)
        For index As Integer = 0 To tbl_par3.Rows.Count - 1
        Next
    End Sub

    Sub loaddata1()
        Dim sqlcommand As MySqlCommand = SQLConnection.CreateCommand
        sqlcommand.CommandText = "SELECT * from db_pegawai where employeecode = '" & TextBox1.Text & "'"
        Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
        Dim cb As New MySqlCommandBuilder(adapter)
        adapter.Fill(tbl_par2)
        For index As Integer = 0 To tbl_par2.Rows.Count - 1
        Next
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        chng()
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

    Sub chng()
        For index As Integer = 0 To tbl_par3.Rows.Count - 1
            ' TextBox1.Text = tbl_par3.Rows(index).Item(2).ToString
            ComboBoxEdit14.Text = tbl_par3.Rows(index).Item(4).ToString
            ComboBoxEdit13.Text = tbl_par3.Rows(index).Item(5).ToString
            ComboBoxEdit12.Text = tbl_par3.Rows(index).Item(6).ToString
            ComboBoxEdit10.Text = tbl_par3.Rows(index).Item(7).ToString
            ComboBoxEdit11.Text = tbl_par3.Rows(index).Item(8).ToString
        Next

        For index As Integer = 0 To tbl_par2.Rows.Count - 1
            TextBox2.Text = tbl_par2.Rows(index).Item(2).ToString
            txtnick.Text = tbl_par2.Rows(index).Item(18).ToString
            ComboBoxEdit6.Text = tbl_par2.Rows(index).Item(6).ToString
            txtbp.Text = tbl_par2.Rows(index).Item(4).ToString
            txtjoin.Text = tbl_par2.Rows(index).Item(11).ToString
            txtbod.Text = tbl_par2.Rows(index).Item(5).ToString
            txtrel.Text = tbl_par2.Rows(index).Item(7).ToString
            txtidno.Text = tbl_par2.Rows(index).Item(9).ToString
            txtblood.Text = tbl_par2.Rows(index).Item(21).ToString
            txtkg.Text = tbl_par2.Rows(index).Item(19).ToString
            txtcm.Text = tbl_par2.Rows(index).Item(20).ToString
            txtphoneno.Text = tbl_par2.Rows(index).Item(12).ToString
            txtwemail.Text = tbl_par2.Rows(index).Item(22).ToString
            txtpemail.Text = tbl_par2.Rows(index).Item(23).ToString
            txtadd.Text = tbl_par2.Rows(index).Item(8).ToString
            txtrecby.Text = tbl_par2.Rows(index).Item(24).ToString
            txtjob.Text = tbl_par2.Rows(index).Item(3).ToString
            txtcompany.Text = tbl_par2.Rows(index).Item(1).ToString
            txtofloc.Text = tbl_par2.Rows(index).Item(10).ToString
            txtgroup.Text = tbl_par2.Rows(index).Item(25).ToString
            txtdept.Text = tbl_par2.Rows(index).Item(26).ToString
            txttype.Text = tbl_par2.Rows(index).Item(15).ToString
            txtjobdesk.Text = tbl_par2.Rows(index).Item(27).ToString
            ComboBoxEdit2.Text = tbl_par2.Rows(index).Item(28).ToString
            ComboBoxEdit7.Text = tbl_par2.Rows(index).Item(29).ToString
            ComboBoxEdit1.Text = tbl_par2.Rows(index).Item(14).ToString
            CheckEdit1.Checked = CType(tbl_par2.Rows(index).Item(30).ToString, Boolean)
            DateTimePicker2.Text = tbl_par2.Rows(index).Item(31).ToString
            TextBox3.Text = tbl_par2.Rows(index).Item(32).ToString
            CheckEdit2.Checked = CType(tbl_par2.Rows(index).Item(33).ToString, Boolean)
            CheckEdit3.Checked = CType(tbl_par2.Rows(index).Item(34).ToString, Boolean)
            CheckEdit4.Checked = CType(tbl_par2.Rows(index).Item(35).ToString, Boolean)
            CheckEdit5.Checked = CType(tbl_par2.Rows(index).Item(36).ToString, Boolean)
            CheckEdit6.Checked = CType(tbl_par2.Rows(index).Item(37).ToString, Boolean)
            CheckEdit7.Checked = CType(tbl_par2.Rows(index).Item(38).ToString, Boolean)
            ComboBoxEdit9.Text = tbl_par2.Rows(index).Item(39).ToString
            Dim filefoto As Byte() = CType(tbl_par2.Rows(0).Item(13), Byte())
            If filefoto.Length > 0 Then
                PictureBox1.Image = ByteToImage(filefoto)
            Else
                PictureBox1.Image = Nothing
                PictureBox1.Refresh()
            End If
            npwp.Text = tbl_par2.Rows(index).Item(41).ToString
            TextEdit1.Text = tbl_par2.Rows(index).Item(44).ToString
            TextEdit2.Text = tbl_par2.Rows(index).Item(43).ToString
        Next
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


    Sub download()
        Dim sFilePath As String
        Dim buffer As Byte()
        Using cmd As New MySqlCommand("select jobdesk from db_pegawai where employeecode = '" & TextBox1.Text & "'", SQLConnection)
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

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        download()
    End Sub
End Class