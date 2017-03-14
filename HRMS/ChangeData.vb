Imports System.IO

Public Class ChangeData
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

    Private Sub loadinfo()
        GridControl1.RefreshDataSource()
        Dim table As New DataTable
        Dim sqlcommand As New MySqlCommand
        Try
            sqlcommand.CommandText = "Select IdRec, FullName from db_recruitment where status = 'Pending' or status = 'In Progress'"
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
            sqlCommand.CommandText = "SELECT IdRec, InterviewTimes, FullName, PlaceofBirth, DateOfBirth, Address,Gender, Religion, PhoneNumber, IdNumber, Photo, Status, InterviewDate, PhoneNumber, InterviewDate, Reason FROM db_recruitment WHERE 1=1 " + param.ToString()
            sqlCommand.Connection = SQLConnection
            Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(datatabl)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If datatabl.Rows.Count > -1 Then
            txtnames.Text = datatabl.Rows(0).Item(2).ToString()
            txtid.Text = datatabl.Rows(0).Item(0).ToString()
            txtinterview.Text = datatabl.Rows(0).Item(1).ToString()
            txtpob.Text = datatabl.Rows(0).Item(3).ToString()
            txtdob.Text = datatabl.Rows(0).Item(4).ToString()
            txtaddress.Text = datatabl.Rows(0).Item(5).ToString()
            txtgender.Text = datatabl.Rows(0).Item(6).ToString()
            Dim filefoto As Byte() = CType(datatabl.Rows(0).Item(10), Byte())
            If filefoto.Length > 0 Then
                pictureEdit.Image = ByteToImage(filefoto)
            Else
                pictureEdit.Image = Nothing
                pictureEdit.Refresh()
            End If
            txtreligion.Text = datatabl.Rows(0).Item(7).ToString()
            txtidcard.Text = datatabl.Rows(0).Item(9).ToString()
            txtstatus.Text = datatabl.Rows(0).Item(11).ToString()
            txtphone.Text = datatabl.Rows(0).Item(13).ToString
            txtinterviewdate.Text = datatabl.Rows(0).Item(14).ToString
        End If
    End Sub

    Public Sub updatechange2()
        Dim dtb, dtr As Date
        txtinterviewdate.Format = DateTimePickerFormat.Custom
        txtinterviewdate.CustomFormat = "yyyy-MM-dd"
        dtb = txtinterviewdate.Value
        txtdob.Format = DateTimePickerFormat.Custom
        txtdob.CustomFormat = "yyyy-MM-dd"
        dtr = txtdob.Value
        Dim sqlcommand As New MySqlCommand
        Try
            sqlcommand.CommandText = "UPDATE db_recruitment SET" +
                                     " InterviewTimes = @InterviewTimes" +
                                     ", FullName = @FullName" +
                                     ", PlaceOfBirth = @PlaceOfBirth" +
                                     ", DateOfBirth = @DateOfBirth" +
                                     ", Address = @Address" +
                                     ", Gender  = @Gender" +
                                     ", Religion = @Religion" +
                                     ", PhoneNumber = @PhoneNumber" +
                                     ", IdNumber = @IdNumber" +
                                     ", Photo = @Photo" +
                                     ", Status = @Status" +
                                     ", InterviewDate = @InterviewDate" +
                                     ", Cv = @Cv" +
                                     " WHERE IdRec = @IdRec"
            sqlcommand.Connection = SQLConnection
            sqlcommand.Parameters.AddWithValue("@IdRec", txtid.Text)
            sqlcommand.Parameters.AddWithValue("@InterviewTimes", txtinterview.Text)
            sqlcommand.Parameters.AddWithValue("@FullName", txtnames.Text)
            sqlcommand.Parameters.AddWithValue("@PlaceOfBirth", txtpob.Text)
            sqlcommand.Parameters.AddWithValue("@DateOfBirth", dtr.ToString("yyyy-MM-dd"))
            sqlcommand.Parameters.AddWithValue("@Address", txtaddress.Text)
            sqlcommand.Parameters.AddWithValue("@Gender", txtgender.Text)
            sqlcommand.Parameters.AddWithValue("@Religion", txtreligion.Text)
            sqlcommand.Parameters.AddWithValue("@PhoneNumber", txtphone.Text)
            sqlcommand.Parameters.AddWithValue("@IdNumber", txtidcard.Text)
            If Not txtbrowse.Text Is Nothing Then
                Dim param As New MySqlParameter("@Photo", ImageToByte(pictureEdit))
                sqlcommand.Parameters.Add(param)
            Else
                sqlcommand.Parameters.AddWithValue("@Photo", "")
            End If
            sqlcommand.Parameters.AddWithValue("@Status", txtstatus.Text)
            sqlcommand.Parameters.AddWithValue("@InterviewDate", dtb.ToString("yyyy-MM-dd"))
            sqlcommand.Parameters.AddWithValue("@Cv", txtcv.Text)
            sqlcommand.Connection = SQLConnection
            sqlcommand.ExecuteNonQuery()
            MsgBox("Data succesfully added")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ChangeData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        loadinfo()
    End Sub

    Private Sub btnPhoto_Click(sender As Object, e As EventArgs) Handles btnPhoto.Click
        Using dialog As New OpenFileDialog
            If dialog.ShowDialog() <> DialogResult.OK Then Return
            txtbrowse.Image = Image.FromFile(dialog.FileName)
            pictureEdit.Image = Image.FromFile(dialog.FileName)
        End Using
    End Sub

    Dim openfd As New OpenFileDialog

    Private Sub btnCV_Click(sender As Object, e As EventArgs) Handles btnCV.Click
        openfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer)
        openfd.Title = "Open a CV File"
        openfd.Filter = "Word Files|*.docx|Text Files|*.txt"
        openfd.ShowDialog()
        txtcv.Text = openfd.FileName
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        updatechange2()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        txtid.Text = ""
        txtinterview.Text = ""
        txtnames.Text = ""
        txtpob.Text = ""
        txtdob.Text = ""
        txtaddress.Text = ""
        txtgender.Text = ""
        txtreligion.Text = ""
        txtphone.Text = ""
        txtidcard.Text = ""
        txtstatus.Text = ""
        pictureEdit.Controls.Clear()
        txtinterviewdate.Text = ""
        txtcv.Text = ""
    End Sub
End Class