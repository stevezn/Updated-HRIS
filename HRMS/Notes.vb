Imports System.IO

Public Class Notes

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
        'connectionString = "Server=" + host + "; User Id=root; Password=; Database=db_hris"
        connectionString = "Server=" + host + "; User Id=" + id + "; Password=" + password + "; Database=" + db + ""
    End Sub
    Sub loadD()
        SQLConnection = New MySqlConnection()
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        Dim sqlCommand As New MySqlCommand
        sqlCommand.CommandText = "SELECT a.EmployeeCode, a.FullName, a.Position, a.CompanyCode, a.PlaceOfBirth, a.DateOfBirth, a.Gender, a.Religion, a.Address, a.Email, a.IdNumber, a.OfficeLocation, a.WorkDate, a.PhoneNumber, a.Photo, a.Status, a.TrainingSampai, b.Sp1, b.Sp1Date, b.Sp2, b.Sp2Date, b.Sp3, b.Sp3Date, c.Rotasi, c.RotasiDate, d.Demosi, d.DemosiDate FROM db_pegawai a, db_sp b, db_rotasi c, db_demosi d"
        sqlCommand.Connection = SQLConnection
        Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
        Dim cb As New MySqlCommandBuilder(adapter)
        adapter.Fill(tbl_par)
        For index As Integer = 0 To tbl_par.Rows.Count - 1
            txtname.Properties.Items.Add(tbl_par.Rows(index).Item(1).ToString())
        Next
        SQLConnection.Close()
    End Sub

    Dim tbl_par5 As New DataTable

    Sub loadall()
        SQLConnection = New MySqlConnection
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        Dim sqlcommand As New MySqlCommand
        sqlcommand.CommandText = "Select EmployeeCode, FullName, Position, CompanyCode, PlaceOfBirth, DateOfBirth, Gender, Religion, Address, Email, IdNumber, OfficeLocation, WorkDate, PhoneNumber, Photo, Status, TrainingSampai from db_pegawai"
        sqlcommand.Connection = SQLConnection
        Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
        Dim cb As New MySqlCommandBuilder(adapter)
        adapter.Fill(tbl_par5)
        For index As Integer = 0 To tbl_par5.Rows.Count - 1
            txtname.Properties.Items.Add(tbl_par5.Rows(index).Item(1).ToString)
        Next
        SQLConnection.Close()
    End Sub

    Dim tbl_par4 As New DataTable

    Sub loadsp()
        SQLConnection = New MySqlConnection
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        Dim sqlcommand As New MySqlCommand
        sqlcommand.CommandText = "SELECT EmployeeCode, CompanyCode, FullName, Sp1, Sp1Date, Sp2, Sp2Date, Sp3, Sp3Date FROM db_sp"
        sqlcommand.Connection = SQLConnection
        Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
        Dim cb As New MySqlCommandBuilder(adapter)
        adapter.Fill(tbl_par4)
        For index As Integer = 0 To tbl_par4.Rows.Count - 1
            txtname.Properties.Items.Add(tbl_par4.Rows(index).Item(2).ToString)
        Next
    End Sub

    Dim tbl_par2 As New DataTable

    Sub loadrotasi()
        SQLConnection = New MySqlConnection
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        Dim sqlcommand As New MySqlCommand
        sqlcommand.CommandText = "SELECT FullName, Rotasi, RotasiDate, EmployeeCode FROM db_rotasi"
        sqlcommand.Connection = SQLConnection
        Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
        Dim cb As New MySqlCommandBuilder(adapter)
        adapter.Fill(tbl_par2)
        For index As Integer = 0 To tbl_par2.Rows.Count - 1
            txtname.Properties.Items.Add(tbl_par2.Rows(index).Item(0).ToString())
        Next
        SQLConnection.Close()
    End Sub

    Dim tbl_par3 As New DataTable

    Function ImageToByte(ByVal pbImg As PictureBox) As Byte()
        If pbImg Is Nothing Then
            Return Nothing
        End If
        Dim ms As New IO.MemoryStream()
        pbImg.Image.Save(ms, Imaging.ImageFormat.Jpeg)
        Return ms.ToArray()
    End Function

    Public Function ByteToImage(ByVal filefoto As Byte()) As Image
        Dim pictureBytes As New IO.MemoryStream(filefoto)
        Return Image.FromStream(pictureBytes)
    End Function

    Sub loaddemosi()
        SQLConnection = New MySqlConnection
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        Dim sqlcommand As New MySqlCommand
        sqlcommand.CommandText = "Select FullName, Demosi, DemosiDate, EmployeeCode FROM db_demosi"
        sqlcommand.Connection = SQLConnection
        Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
        Dim cb As New MySqlCommandBuilder(adapter)
        adapter.Fill(tbl_par3)
        For index As Integer = 0 To tbl_par3.Rows.Count - 1
            txtname.Properties.Items.Add(tbl_par3.Rows(index).Item(0).ToString())
        Next
        SQLConnection.Close()
    End Sub

    Private Sub Notes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadD()
        loadall()
    End Sub

    Private Sub txtname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtname.SelectedIndexChanged
        For indexing As Integer = 0 To tbl_par5.Rows.Count - 1
            If txtname.SelectedItem Is tbl_par5.Rows(indexing).Item(1).ToString() Then
                txtempcode.Text = tbl_par5.Rows(indexing).Item(0).ToString()
                txtpos.Text = tbl_par5.Rows(indexing).Item(2).ToString()
                txtcompcode.Text = tbl_par5.Rows(indexing).Item(3).ToString
                txtpob.Text = tbl_par5.Rows(indexing).Item(4).ToString
                txtdob.Text = tbl_par5.Rows(indexing).Item(5).ToString
                txtgender.Text = tbl_par5.Rows(indexing).Item(6).ToString
                txtreligion.Text = tbl_par5.Rows(indexing).Item(7).ToString
                txtaddress.Text = tbl_par5.Rows(indexing).Item(8).ToString
                txtemail.Text = tbl_par5.Rows(indexing).Item(9).ToString
                txtidcard.Text = tbl_par5.Rows(indexing).Item(10).ToString
                txtol.Text = tbl_par5.Rows(indexing).Item(11).ToString
                txtwd.Text = tbl_par5.Rows(indexing).Item(12).ToString
                txtphone.Text = tbl_par5.Rows(indexing).Item(13).ToString
                txtstat.Text = tbl_par5.Rows(indexing).Item(15).ToString
                txttrains.Text = tbl_par5.Rows(indexing).Item(16).ToString
                Dim filefoto As Byte() = CType(tbl_par5.Rows(indexing).Item(14), Byte())
                If filefoto.Length > 0 Then
                    PictureEdit1.Image = ByteToImage(filefoto)
                Else
                    PictureEdit1.Image = Nothing
                    PictureEdit1.Refresh()
                End If
                'txtsp1.Text = tbl_par.Rows(indexing).Item(17).ToString
                'txtsp1date.Text = tbl_par.Rows(indexing).Item(18).ToString
                'txtsp2.Text = tbl_par.Rows(indexing).Item(19).ToString
                'txtsp2date.Text = tbl_par.Rows(indexing).Item(20).ToString
                'txtsp3.Text = tbl_par.Rows(indexing).Item(21).ToString
                'txtsp3date.Text = tbl_par.Rows(indexing).Item(22).ToString
                'txtrotasi.Text = tbl_par.Rows(indexing).Item(23).ToString
                'txtrotasidate.Text = tbl_par.Rows(indexing).Item(24).ToString
                'txtdemosi.Text = tbl_par.Rows(indexing).Item(25).ToString
                'txtdemosidate.Text = tbl_par.Rows(indexing).Item(26).ToString
            End If
        Next
    End Sub
End Class