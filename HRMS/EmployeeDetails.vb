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

    'Sub selection()
    '    Dim query As MySqlCommand = SQLConnection.CreateCommand
    '    query.CommandText = "select * from db_pegawai where employeecode = @emp"
    '    query.Parameters.AddWithValue("@emp", TextBox1.Text)

    'End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "select employeecode from db_tmpname"
            Dim quer1 As String = CType(query.ExecuteScalar, String)
        TextBox1.Text = quer1.ToString
    End Sub

    Private Sub EmployeeDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        'loaddata1()
        'loadsc()
        'loadcert()
        'loadschool()
        'loadwarn()
        'loadexp()
        'loadskill()
        'loadfamily()
    End Sub

    Dim tbl_par2 As New DataTable

    'Sub loadschool()
    '    SQLConnection.Open()
    '    Dim sqlCommand As New MySqlCommand
    '    sqlCommand.CommandText = "Select EmployeeCode, School as SchoolOrUniversity, GraduatedYear, StudyField from db_education where EmployeeCode = '" & TextBox1.Text & "'"
    '    sqlCommand.Connection = SQLConnection
    '    Dim dt As New DataTable
    '    dt.Load(sqlCommand.ExecuteReader)
    '    GridControl3.DataSource = dt
    'End Sub

    'Sub loadcert()
    '    SQLConnection.Open()
    '    Dim sqlcommand As New MySqlCommand
    '    sqlcommand.CommandText = "Select select EmployeeCode, Certificates, Years, Reasons from db_certificates where employeecode = '" & TextBox1.Text & "'"
    '    sqlcommand.Connection = SQLConnection
    '    Dim dt As New DataTable
    '    dt.Load(sqlcommand.ExecuteReader)
    '    GridControl2.DataSource = dt
    'End Sub

    'Sub loadwarn()
    '    SQLConnection.Open()
    '    Dim sqlcommand As New MySqlCommand
    '    sqlcommand.CommandText = "Select select EmployeeCode, Certificates, Years, Reasons from db_certificates where employeecode = '" & TextBox1.Text & "'"
    '    sqlcommand.Connection = SQLConnection
    '    Dim dt As New DataTable
    '    dt.Load(sqlcommand.ExecuteReader)
    '    GridControl1.DataSource = dt
    'End Sub

    'Sub loadexp()
    '    SQLConnection.Open()
    '    Dim sqlcommand As New MySqlCommand
    '    sqlcommand.CommandText = "Select EmployeeCode, Company, Manager, Address, Period, Until, BasicSalary, AdditionalSalary, TotalSalary, QuitReason from db_exp where employeecode = '" & TextBox1.Text & "'"
    '    sqlcommand.Connection = SQLConnection
    '    Dim dt As New DataTable
    '    dt.Load(sqlcommand.ExecuteReader)
    '    GridControl1.DataSource = dt
    'End Sub

    'Sub loadskill()
    '    SQLConnection.Open()
    '    Dim sqlcommand As New MySqlCommand
    '    sqlcommand.CommandText = "Select EmployeeCode, SkillName, SkillLevel, SkillDescription from db_empskill where EmployeeCode = '" & TextBox1.Text & "'"
    '    sqlcommand.Connection = SQLConnection
    '    Dim dt As New DataTable
    '    dt.Load(sqlcommand.ExecuteReader)
    '    GridControl1.DataSource = dt
    'End Sub

    'Sub loadfamily()
    '    SQLConnection.Open()
    '    Dim sqlcommand As New MySqlCommand
    '    sqlcommand.CommandText = "Select EmployeeCode, MemberName, RelationShip, Gender, Address, Occupation, PhoneNo from db_family where employeecode = '" & TextBox1.Text & "'"
    '    sqlcommand.Connection = SQLConnection
    '    Dim dt As New DataTable
    '    dt.Load(sqlcommand.ExecuteReader)
    '    GridControl1.DataSource = dt
    'End Sub

    Dim tbl_par3 As New DataTable

    Sub loadsc()
        Dim sqlcommand As MySqlCommand = SQLConnection.CreateCommand
        sqlcommand.CommandText = "select * from db_statuschange"
        Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
        Dim cb As New MySqlCommandBuilder(adapter)
        adapter.Fill(tbl_par3)
        For index As Integer = 0 To tbl_par3.Rows.Count - 1

        Next
    End Sub

    Sub loaddata1()
        Dim sqlcommand As MySqlCommand = SQLConnection.CreateCommand
        sqlcommand.CommandText = "SELECT * from db_pegawai"
        Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
        Dim cb As New MySqlCommandBuilder(adapter)
        adapter.Fill(tbl_par2)
        For index As Integer = 0 To tbl_par2.Rows.Count - 1
            'TextBox1.Properties.Items.Add(tbl_par2.Rows(index).Item(0).ToString())
            ''txtname3.Properties.Items.Add(tbl_par2.Rows(index).Item(0).ToString())
            ''txtname.Properties.Items.Add(tbl_par2.Rows(index).Item(0).ToString())
        Next
    End Sub


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Timer1.Stop()
        'loadschool()
        'loadcert()
        'loadexp()
        'loadfamily()
        'loadskill()
        'loadwarn()
        For index As Integer = 0 To tbl_par3.Rows.Count - 1
            If TextBox1.Text Is tbl_par3.Rows(index).Item(2).ToString Then
                ComboBoxEdit14.Text = tbl_par3.Rows(index).Item(4).ToString
                ComboBoxEdit13.Text = tbl_par3.Rows(index).Item(5).ToString
                ComboBoxEdit12.Text = tbl_par3.Rows(index).Item(6).ToString
                ComboBoxEdit10.Text = tbl_par3.Rows(index).Item(7).ToString
                ComboBoxEdit11.Text = tbl_par3.Rows(index).Item(8).ToString
            End If
        Next

        For index As Integer = 0 To tbl_par2.Rows.Count - 1
            If TextBox1.Text Is tbl_par2.Rows(index).Item(0).ToString Then
                TextBox2.Text = tbl_par2.Rows(index).Item(1).ToString
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
                txtjob.Text = tbl_par2.Rows(index).Item(28).ToString
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
            End If
        Next
    End Sub
End Class