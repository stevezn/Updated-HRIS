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
        connectionString = "Server=" + host + "; User Id=" + id + "; Password=" + password + "; Database=" + db + ""
    End Sub

    Sub loadD()
        Dim sqlCommand As New MySqlCommand
        sqlCommand.CommandText = "SELECT a.EmployeeCode, a.FullName, a.Position, a.CompanyCode, a.PlaceOfBirth, a.DateOfBirth, a.Gender, a.Religion, a.Address, a.Email, a.IdNumber, a.OfficeLocation, a.WorkDate, a.PhoneNumber, a.Photo, a.Status, a.TrainingSampai, b.Sp1, b.Sp1Date, b.Sp2, b.Sp2Date, b.Sp3, b.Sp3Date, c.Rotasi, c.RotasiDate, d.Demosi, d.DemosiDate FROM db_pegawai a, db_sp b, db_rotasi c, db_demosi d"
        sqlCommand.Connection = SQLConnection
        Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
        Dim cb As New MySqlCommandBuilder(adapter)
        adapter.Fill(tbl_par)
        For index As Integer = 0 To tbl_par.Rows.Count - 1
            txtname.Properties.Items.Add(tbl_par.Rows(index).Item(1).ToString())
        Next
    End Sub

    Dim tbl_par5 As New DataTable

    Sub loadall()
        Dim sqlcommand As New MySqlCommand
        sqlcommand.CommandText = "Select EmployeeCode, FullName, Position, CompanyCode, PlaceOfBirth, DateOfBirth, Gender, Religion, Address, Email, IdNumber, OfficeLocation, WorkDate, PhoneNumber, Photo, Status, TrainingSampai from db_pegawai"
        sqlcommand.Connection = SQLConnection
        Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
        Dim cb As New MySqlCommandBuilder(adapter)
        adapter.Fill(tbl_par5)
        For index As Integer = 0 To tbl_par5.Rows.Count - 1
            txtname.Properties.Items.Add(tbl_par5.Rows(index).Item(1).ToString)
        Next
    End Sub

    Dim tbl_par4 As New DataTable

    Sub loadsp()
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
        Dim sqlcommand As New MySqlCommand
        sqlcommand.CommandText = "SELECT FullName, Rotasi, RotasiDate, EmployeeCode FROM db_rotasi"
        sqlcommand.Connection = SQLConnection
        Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
        Dim cb As New MySqlCommandBuilder(adapter)
        adapter.Fill(tbl_par2)
        For index As Integer = 0 To tbl_par2.Rows.Count - 1
            txtname.Properties.Items.Add(tbl_par2.Rows(index).Item(0).ToString())
        Next
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
        Dim sqlcommand As New MySqlCommand
        sqlcommand.CommandText = "Select FullName, Demosi, DemosiDate, EmployeeCode FROM db_demosi"
        sqlcommand.Connection = SQLConnection
        Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
        Dim cb As New MySqlCommandBuilder(adapter)
        adapter.Fill(tbl_par3)
        For index As Integer = 0 To tbl_par3.Rows.Count - 1
            txtname.Properties.Items.Add(tbl_par3.Rows(index).Item(0).ToString())
        Next
    End Sub

    Private Sub Notes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        loadinfo()
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
                    pictureedit.Image = ByteToImage(filefoto)
                Else
                    pictureedit.Image = Nothing
                    pictureedit.Refresh()
                End If
            End If
        Next
    End Sub

    Private Sub loadinfo()
        GridControl1.RefreshDataSource()
        Dim table As New DataTable
        Dim sqlcommand As New MySqlCommand
        Try
            sqlcommand.CommandText = "Select EmployeeCode, FullName, IdNumber from db_pegawai where status != 'Fired'"
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

    Private Sub terminate()
        GridControl1.RefreshDataSource()
        Dim table As New DataTable
        Dim sqlcommand As New MySqlCommand
        Try
            sqlcommand.CommandText = "select EmployeeCode, FullName, IdNumber from db_pegawai where status = 'Terminated' or status =  'Fired'"
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

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        Dim datatabl As New DataTable
        Dim sqlCommand As New MySqlCommand
        datatabl.Clear()
        Dim param As String = ""
        Try
            param = "and FullName='" + GridView1.GetFocusedRowCellValue("FullName").ToString() + "'"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            sqlCommand.CommandText = "SELECT * FROM db_pegawai WHERE 1=1 " + param.ToString()
            sqlCommand.Connection = SQLConnection

            Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(datatabl)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If datatabl.Rows.Count > 0 Then
            txtname.Text = datatabl.Rows(0).Item(2).ToString()
            txtempcode.Text = datatabl.Rows(0).Item(0).ToString()
            txtcompcode.Text = datatabl.Rows(0).Item(1).ToString()
            txtpos.Text = datatabl.Rows(0).Item(3).ToString()
            txtpob.Text = datatabl.Rows(0).Item(4).ToString()
            txtdob.Text = datatabl.Rows(0).Item(5).ToString()
            txtaddress.Text = datatabl.Rows(0).Item(8).ToString()
            txtgender.Text = datatabl.Rows(0).Item(6).ToString()
            Dim filefoto As Byte() = CType(datatabl.Rows(0).Item(14), Byte())
            If filefoto.Length > 0 Then
                pictureEdit.Image = ByteToImage(filefoto)
            Else
                pictureEdit.Image = Nothing
                pictureEdit.Refresh()
            End If
            txtemail.Text = datatabl.Rows(0).Item(9).ToString
            txtol.Text = datatabl.Rows(0).Item(11).ToString
            txtwd.Text = datatabl.Rows(0).Item(12).ToString
            txtemptype.Text = datatabl.Rows(0).Item(16).ToString
            txtreligion.Text = datatabl.Rows(0).Item(7).ToString()
            txtidcard.Text = datatabl.Rows(0).Item(10).ToString()
            txtstat.Text = datatabl.Rows(0).Item(15).ToString()
            txttrains.Text = datatabl.Rows(0).Item(17).ToString
            txtphone.Text = datatabl.Rows(0).Item(13).ToString
        End If
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        terminate()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        loadinfo()
    End Sub

    Dim mini As New minirep

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        If mini Is Nothing OrElse mini.IsDisposed Then
            mini = New minirep
        End If
        mini.Show()
    End Sub
End Class