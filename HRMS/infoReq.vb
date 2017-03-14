Imports System.IO

Public Class infoReq
    Dim connectionString As String
    Dim SQLConnection As MySqlConnection = New MySqlConnection
    Dim oDt_sched As New DataTable()

    Dim tbl_par As New DataTable

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

    Private Sub loadinfo()
        GridControl1.RefreshDataSource()
        Dim table As New DataTable
        Dim sqlcommand As New MySqlCommand
        Try
            sqlcommand.CommandText = "Select IdRec, FullName from db_recruitment where status != 'In Progress'"
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

    Sub loadD()
        Dim sqlCommand As New MySqlCommand
        sqlCommand.CommandText = "SELECT IdRec, InterviewTimes, FullName, PlaceOfBirth, DateOfBirth, Address, Gender, Religion, IdNumber, Photo, status, InterviewDate FROM db_recruitment"
        sqlCommand.Connection = SQLConnection
        Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
        Dim cb As New MySqlCommandBuilder(adapter)
        adapter.Fill(tbl_par)
        For index As Integer = 0 To tbl_par.Rows.Count - 1
            txtnamakaryawan.Properties.Items.Add(tbl_par.Rows(index).Item(2).ToString())
        Next
    End Sub

    Private Sub infoReq_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        loadD()
        loadinfo()
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

    Private Sub txtidrec_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtnamakaryawan.SelectedIndexChanged
        For indexing As Integer = 0 To tbl_par.Rows.Count - 1
            If txtnamakaryawan.SelectedItem Is tbl_par.Rows(indexing).Item(2).ToString() Then
                lcidrec.Text = tbl_par.Rows(indexing).Item(0).ToString()
                lctgl.Text = tbl_par.Rows(indexing).Item(11).ToString()
                lcinterviewke.Text = tbl_par.Rows(indexing).Item(1).ToString()
                lcpob.Text = tbl_par.Rows(indexing).Item(3).ToString()
                lcdob.Text = tbl_par.Rows(indexing).Item(4).ToString()
                lcaddress.Text = tbl_par.Rows(indexing).Item(5).ToString()
                lcgender.Text = tbl_par.Rows(indexing).Item(6).ToString()
                lcreligion.Text = tbl_par.Rows(indexing).Item(7).ToString()
                lcid.Text = tbl_par.Rows(indexing).Item(8).ToString()
                lcHasil.Text = tbl_par.Rows(indexing).Item(10).ToString()
                Dim filefoto As Byte() = CType(tbl_par.Rows(indexing).Item(9), Byte())
                If filefoto.Length > 0 Then
                    PictureEdit1.Image = ByteToImage(filefoto)
                Else
                    PictureEdit1.Image = Nothing
                    PictureEdit1.Refresh()
                End If
            End If
        Next
    End Sub

    Dim act As String = ""

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        Dim datatabl As New DataTable
        Dim sqlCommand As New MySqlCommand
        datatabl.Clear()
        Dim param As String = ""
        Try
            param = "and IdRec='" + GridView1.GetFocusedRowCellValue("IdRec").ToString() + "'"
        Catch ex As Exception
        End Try
        If param > "" Then
            act = "edit"
        Else
            act = "input"
        End If
        Try
            sqlCommand.CommandText = "SELECT IdRec, InterviewTimes, FullName, PlaceofBirth, DateOfBirth, Address,Gender, Religion, PhoneNumber, IdNumber, Photo, Status, InterviewDate, Reason FROM db_recruitment WHERE 1=1 " + param.ToString()
            sqlCommand.Connection = SQLConnection

            Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(datatabl)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If datatabl.Rows.Count > 0 Then
            txtnamakaryawan.Text = datatabl.Rows(0).Item(2).ToString()
            lcidrec.Text = datatabl.Rows(0).Item(0).ToString()
            lctgl.Text = datatabl.Rows(0).Item(12).ToString()
            lcinterviewke.Text = datatabl.Rows(0).Item(1).ToString()
            lcpob.Text = datatabl.Rows(0).Item(3).ToString()
            lcdob.Text = datatabl.Rows(0).Item(4).ToString()
            lcaddress.Text = datatabl.Rows(0).Item(5).ToString()
            lcgender.Text = datatabl.Rows(0).Item(6).ToString()

            Dim filefoto As Byte() = CType(datatabl.Rows(0).Item(10), Byte())

            If filefoto.Length > 0 Then
                PictureEdit1.Image = ByteToImage(filefoto)
            Else
                PictureEdit1.Image = Nothing
                PictureEdit1.Refresh()
            End If
            lcreligion.Text = datatabl.Rows(0).Item(7).ToString()
            lcid.Text = datatabl.Rows(0).Item(9).ToString()
            lcHasil.Text = datatabl.Rows(0).Item(11).ToString()
        End If
    End Sub
End Class