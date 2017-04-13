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

    Function ImageToByte(ByVal pbImg As PictureBox) As Byte()
        If pbImg Is Nothing Then
            Return Nothing
        End If
        Dim ms As New IO.MemoryStream()
        pbImg.Image.Save(ms, Imaging.ImageFormat.Jpeg)
        Return ms.ToArray()
    End Function

    Public Function ByteToImage(ByVal filefoto As Byte()) As Image
        Dim pictureBytes As New MemoryStream(filefoto)
        Return Image.FromStream(pictureBytes)
    End Function


    Private Sub Notes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        loadinfo()
        cleared()
    End Sub

    Sub cleared()
        txtname.Text = ""
        txtempcode.Text = ""
        txtpos.Text = ""
        txtcompcode.Text = ""
        txtpob.Text = ""
        txtdob.Text = ""
        txtgender.Text = ""
        txtreligion.Text = ""
        txtaddress.Text = ""
        txtemail.Text = ""
        txtidcard.Text = ""
        txtol.Text = ""
        txtwd.Text = ""
        txtphone.Text = ""
        txtstat.Text = ""
        txttrains.Text = ""
        pictureedit.Image = Nothing
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
            ' MsgBox(ex.Message)
        End Try
        cleared()
    End Sub

    Private Sub terminate()
        cleared()
        GridControl1.RefreshDataSource()
        Dim table As New DataTable
        Dim sqlcommand As New MySqlCommand
        Try
            sqlcommand.CommandText = "select EmployeeCode, FullName, IdNumber from db_pegawai where status = 'Terminated' or status = 'Fired'"
            sqlcommand.Connection = SQLConnection
            Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(table)
            GridControl1.DataSource = table
        Catch ex As Exception
            'MsgBox(ex.Message)
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
            ' MsgBox(ex.Message)
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
            Dim filefoto As Byte() = CType(datatabl.Rows(0).Item(13), Byte())
            If filefoto.Length > 0 Then
                pictureEdit.Image = ByteToImage(filefoto)
            Else
                pictureEdit.Image = Nothing
                pictureEdit.Refresh()
            End If
            txtemail.Text = datatabl.Rows(0).Item(22).ToString
            txtol.Text = datatabl.Rows(0).Item(10).ToString
            txtwd.Text = datatabl.Rows(0).Item(11).ToString
            txtemptype.Text = datatabl.Rows(0).Item(15).ToString
            txtreligion.Text = datatabl.Rows(0).Item(7).ToString()
            txtidcard.Text = datatabl.Rows(0).Item(9).ToString()
            txtstat.Text = datatabl.Rows(0).Item(14).ToString()
            txttrains.Text = datatabl.Rows(0).Item(30).ToString
            txtphone.Text = datatabl.Rows(0).Item(12).ToString
        End If
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        terminate()
        cleared()
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

    Private Sub RibbonControl1_Click(sender As Object, e As EventArgs) Handles RibbonControl1.Click

    End Sub
End Class