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
        Try
            sqlcommand.CommandText = "Select EmployeeCode, FullName from db_pegawai where status != 'Fired' and status != 'Terminated'"
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
            param = "and EmployeeCode='" + GridView1.GetFocusedRowCellValue("EmployeeCode").ToString() + "'"
        Catch ex As Exception
        End Try
        Try
            sqlCommand.CommandText = "SELECT * FROM db_pegawai WHERE 1=1 " + param.ToString()
            sqlCommand.Connection = SQLConnection

            Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(datatabl)
        Catch ex As Exception
            SQLConnection.Close()
            MsgBox(ex.Message)
        End Try
        If datatabl.Rows.Count > -1 Then
            txtnames.Text = datatabl.Rows(0).Item(2).ToString()
            txtempcode.Text = datatabl.Rows(0).Item(0).ToString()
            txtcompcode.Text = datatabl.Rows(0).Item(1).ToString()
            txtposition.Text = datatabl.Rows(0).Item(3).ToString()
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
            txtoffloc.Text = datatabl.Rows(0).Item(11).ToString
            txtworkdate.Text = datatabl.Rows(0).Item(12).ToString
            txtemptype.Text = datatabl.Rows(0).Item(16).ToString
            txtreligion.Text = datatabl.Rows(0).Item(7).ToString()
            txtidcard.Text = datatabl.Rows(0).Item(10).ToString()
            txtstatus.Text = datatabl.Rows(0).Item(15).ToString()
            txtphone.Text = datatabl.Rows(0).Item(13).ToString
        End If
    End Sub

    Private Sub ChangeEmp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        loadinfo()
    End Sub

    Private Sub btnPhoto_Click(sender As Object, e As EventArgs) Handles btnPhoto.Click
        Using dialog As New OpenFileDialog
            If dialog.ShowDialog() <> DialogResult.OK Then Return
            txtfoto.Image = Image.FromFile(dialog.FileName)
            pictureEdit.Image = Image.FromFile(dialog.FileName)
        End Using
    End Sub

    Public Sub UpdateEmp()
        Dim dtb, dtr As DateTime
        txtworkdate.Format = DateTimePickerFormat.Custom
        txtworkdate.CustomFormat = "yyyy-MM-dd"
        dtb = txtworkdate.Value
        Dim sqlCommand As New MySqlCommand
        Dim str_carSql As String
        Try
            str_carSql = "UPDATE db_pegawai SET" +
                   " CompanyCode = @CompanyCode" +
                   ", FullName = @FullName" +
                   ", Position = @Position" +
                   ", PlaceOfBirth = @PlaceOfBirth" +
                   ", DateOfBirth = @DateOfBirth" +
                   ", Gender = @Gender" +
                   ", Religion = @Religion" +
                   ", Address = @Address" +
                   ", Email = @Email" +
                   ", IdNumber = @IdNumber" +
                   ", OfficeLocation = @OfficeLocation" +
                   ", WorkDate = @WorkDate" +
                   ", PhoneNumber = @PhoneNumber" +
                   ", Photo = @Photo" +
                   ", Status = @Status" +
                   ", EmployeeType = @EmployeeType " +
                   ", ChangeDate = @ChangeDate" +
                   " WHERE EmployeeCode = @EmployeeCode"
            sqlCommand.Connection = SQLConnection
            sqlCommand.CommandText = str_carSql
            sqlCommand.Parameters.AddWithValue("@EmployeeCode", txtempcode.Text)
            sqlCommand.Parameters.AddWithValue("@CompanyCode", txtcompcode.Text)
            sqlCommand.Parameters.AddWithValue("@FullName", txtnames.Text)
            sqlCommand.Parameters.AddWithValue("@Position", txtposition.Text)
            sqlCommand.Parameters.AddWithValue("@PlaceOfBirth", txtpob.Text)
            sqlCommand.Parameters.AddWithValue("@DateOfBirth", txtdob.Text)
            sqlCommand.Parameters.AddWithValue("@Gender", txtgender.Text)
            sqlCommand.Parameters.AddWithValue("@Religion", txtreligion.Text)
            sqlCommand.Parameters.AddWithValue("@Address", txtaddress.Text)
            sqlCommand.Parameters.AddWithValue("@Email", txtemail.Text)
            sqlCommand.Parameters.AddWithValue("@IdNumber", txtidcard.Text)
            sqlCommand.Parameters.AddWithValue("@OfficeLocation", txtoffloc.Text)
            sqlCommand.Parameters.AddWithValue("@WorkDate", dtb.ToString("yyyy-MM-dd"))
            sqlCommand.Parameters.AddWithValue("@PhoneNumber", txtphone.Text)
            If Not txtfoto.Text Is Nothing Then
                Dim param As New MySqlParameter("@Photo", ImageToByte(pictureEdit))
                sqlCommand.Parameters.Add(param)
            Else
                sqlCommand.Parameters.AddWithValue("@Photo", "")
            End If
            sqlCommand.Parameters.AddWithValue("@Status", txtstatus.Text)
            sqlCommand.Parameters.AddWithValue("@EmployeeType", txtemptype.Text)
            sqlCommand.Parameters.AddWithValue("@ChangeDate", Date.Now)
            sqlCommand.Connection = SQLConnection
            sqlCommand.ExecuteNonQuery()
            MsgBox("Data Successfully Changed")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtempcode.Text = "" Then
            MsgBox("Please fill the empty fields")
        Else
            UpdateEmp()
        End If
    End Sub

    Sub cleartxt()
        txtemptype.Text = ""
        txtempcode.Text = ""
        txtcompcode.Text = ""
        txtoffloc.Text = ""
        txtnames.Text = ""
        txtemail.Text = ""
        txtworkdate.Text = ""
        txtpob.Text = ""
        txtdob.Text = ""
        txtfoto.Text = ""
        txtaddress.Text = ""
        txtgender.Text = ""
        txtreligion.Text = ""
        txtphone.Text = ""
        txtidcard.Text = ""
        txtstatus.Text = ""
        pictureEdit.Controls.Clear()
        txtposition.Text = ""
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        cleartxt()
    End Sub

    Private Sub txtstatus_TextChanged(sender As Object, e As EventArgs) Handles txtstatus.TextChanged
        Dim monthss As Date
        If txtstatus.Text = "Training" Then
            Try
                monthss = CDate(InputBox("Enter a date with format ( 2017-15-01 )"))
                Dim train As MySqlCommand = SQLConnection.CreateCommand
                train.CommandText = "update db_pegawai set trainingsampai = @date1 where employeecode = @ec"
                train.Parameters.AddWithValue("@date1", monthss)
                train.Parameters.AddWithValue("@ec", txtempcode.Text)
                train.ExecuteNonQuery()
                MsgBox("Added")
            Catch ex As Exception

            End Try

        End If
    End Sub
End Class