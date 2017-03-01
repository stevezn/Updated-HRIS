Imports System.IO

Public Class NewEmp
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
        'connectionString = "Server=" + host + "; User Id=root; Password=; Database=db_hris"
        connectionString = "Server=" + host + "; User Id=" + id + "; Password=" + password + "; Database=" + db + ""
    End Sub

    Sub reset()
        lctrains.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcfullname.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcName.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcempcode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcpob.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcdob.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcoffice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcposition.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcbrowse.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcgender.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcreligion.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcidcard.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcaddress.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcphone.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcstats.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcbtnsave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcbtnreset.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
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

    Public Sub UpdateEmp()
        SQLConnection = New MySqlConnection()
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
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
                   ", TrainingSampai = @TrainingSampai" +
                   ", EmployeeType = @EmployeeType " +
                   " WHERE EmployeeCode = @EmployeeCode"
            sqlCommand.Connection = SQLConnection
            sqlCommand.CommandText = str_carSql
            sqlCommand.Parameters.AddWithValue("@EmployeeCode", txtempcode.Text)
            sqlCommand.Parameters.AddWithValue("@CompanyCode", txtcompcode.Text)
            sqlCommand.Parameters.AddWithValue("@FullName", txtfullname.Text)
            sqlCommand.Parameters.AddWithValue("@Position", txtposition.Text)
            sqlCommand.Parameters.AddWithValue("@PlaceOfBirth", txtpob.Text)
            sqlCommand.Parameters.AddWithValue("@DateOfBirth", txtdob.Text)
            sqlCommand.Parameters.AddWithValue("@Gender", txtgender.Text)
            sqlCommand.Parameters.AddWithValue("@Religion", txtreligion.Text)
            sqlCommand.Parameters.AddWithValue("@Address", txtaddress.Text)
            sqlCommand.Parameters.AddWithValue("@Email", txtemail.Text)
            sqlCommand.Parameters.AddWithValue("@IdNumber", txtidcard.Text)
            sqlCommand.Parameters.AddWithValue("@OfficeLocation", txtoffloc.Text)
            sqlCommand.Parameters.AddWithValue("@WorkDate", txtworkdate.Text)
            sqlCommand.Parameters.AddWithValue("@PhoneNumber", txtphone.Text)
            If Not txtfoto.Text Is Nothing Then
                Dim param As New MySqlParameter("@Photo", ImageToByte(pictureEdit))
                sqlCommand.Parameters.Add(param)
            Else
                sqlCommand.Parameters.AddWithValue("@Photo", "")
            End If
            sqlCommand.Parameters.AddWithValue("@Status", txtstatus.Text)
            sqlCommand.Parameters.AddWithValue("@TrainingSampai", txtrains.Text)
            sqlCommand.Parameters.AddWithValue("@EmployeeType", txtemptype.Text)
            sqlCommand.Connection = SQLConnection
            sqlCommand.ExecuteNonQuery()
            MsgBox("Data Successfully Changed")
            SQLConnection.Close()
        Catch ex As Exception
            SQLConnection.Close()
            MessageBox.Show("Process Failed!")
        End Try
    End Sub

    Sub cleartxt()
        txtempcode.Text = ""
        txtcompcode.Text = ""
        txtoffloc.Text = ""
        txtnames.Text = ""
        txtfullname.Text = ""
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
        txtrains.Text = ""
        txtposition.Text = ""
    End Sub

    Public Function InsertEmp() As Boolean
        SQLConnection = New MySqlConnection()
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        Dim dtb As DateTime
        txtworkdate.Format = DateTimePickerFormat.Custom
        txtworkdate.CustomFormat = "yyyy-MM-dd"
        dtb = txtworkdate.Value
        Dim lastn As Integer
        Dim ynow As String = Format(Now, "yy").ToString
        Dim mnow As String = Month(Now).ToString
        Try
            Dim cmd = SQLConnection.CreateCommand()
            cmd.CommandText = "SELECT last_num FROM view_emp_last_code"

            lastn = DirectCast(cmd.ExecuteScalar(), Integer) + 1
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Dim rescode As String = ynow & "-" & mnow & "-" & Strings.Right("00000" & lastn, 5)
        Dim sqlCommand As New MySqlCommand
        Dim str_carSql As String
        Try
            str_carSql = "INSERT INTO db_pegawai " +
                            "(EmployeeCode, CompanyCode, FullName, Position, PlaceOfBirth, DateOfBirth, Gender, Religion, Address, Email, IdNumber, OfficeLocation, WorkDate, PhoneNumber, Photo, Status, TrainingSampai) " +
                            "values (@EmployeeCode,@CompanyCode,@FullName,@Position,@PlaceOfBirth,@DateOfBirth,@Gender,@Religion,@Address,@Email,@IdNumber,@OfficeLocation,@WorkDate,@PhoneNumber,@Photo,@Status,@TrainingSampai)"
            sqlCommand.Connection = SQLConnection
            sqlCommand.CommandText = str_carSql
            sqlCommand.Parameters.AddWithValue("@EmployeeCode", rescode)
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
            sqlCommand.Parameters.AddWithValue("@TrainingSampai", txtrains.Text)
            sqlCommand.Connection = SQLConnection
            sqlCommand.ExecuteNonQuery()
            MessageBox.Show("Data Succesfully Added!")
            Return True
        Catch ex As Exception
            Return False
            MsgBox(ex.Message)
        End Try
    End Function

    Dim tbl_par As New DataTable

    'Sub loadDataKaryawan()
    '    SQLConnection = New MySqlConnection()
    '    SQLConnection.ConnectionString = connectionString
    '    SQLConnection.Open()
    '    Dim sqlCommand As New MySqlCommand
    '    sqlCommand.CommandText = "SELECT EmployeeCode, CompanyCode, FullName, Position, PlaceOfBirth, DateOfBirth, Gender, Religion, Address, Email, IdNumber, OfficeLocation, WorkDate, PhoneNumber, Photo, Status, TrainingSampai, EmployeeType FROM db_pegawai"
    '    sqlCommand.Connection = SQLConnection
    '    Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
    '    Dim cb As New MySqlCommandBuilder(adapter)
    '    adapter.Fill(tbl_par)
    '    For index As Integer = 0 To tbl_par.Rows.Count - 1
    '        txtfullname.Properties.Items.Add(tbl_par.Rows(index).Item(2).ToString())
    '    Next
    '    SQLConnection.Close()
    'End Sub

    Private Sub NewEmp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'loadDataKaryawan()
        reset()
        cleartxt()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        cleartxt()
        reset()
        barJudul.Caption = "Add Employee"
        lcName.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcoffice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcempcode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lccompcode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcposition.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcpob.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcdob.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcbrowse.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcgender.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcreligion.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcidcard.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcaddress.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcphone.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcstats.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lctrains.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcbtnsave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcbtnreset.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        BarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        RibbonPageGroup2.Visible = False
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        cleartxt()
        reset()
        barJudul.Caption = "Change Data"
        lcfullname.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcemail.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcpob.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcoffice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcdob.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcposition.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcempcode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lccompcode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcbrowse.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcgender.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcreligion.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcidcard.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcaddress.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcphone.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcstats.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcbtnsave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        btnSave.Text = "Change"
        lcbtnreset.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        BarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        RibbonPageGroup1.Visible = False
    End Sub

    Private Sub txtfullname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtfullname.SelectedIndexChanged
        For indexing As Integer = 0 To tbl_par.Rows.Count - 1
            If txtfullname.SelectedItem Is tbl_par.Rows(indexing).Item(2).ToString() Then
                txtempcode.Text = tbl_par.Rows(indexing).Item(0).ToString()
                txtcompcode.Text = tbl_par.Rows(indexing).Item(1).ToString()
                txtposition.Text = tbl_par.Rows(indexing).Item(3).ToString()
                txtpob.Text = tbl_par.Rows(indexing).Item(4).ToString()
                txtdob.Text = tbl_par.Rows(indexing).Item(5).ToString()
                txtgender.Text = tbl_par.Rows(indexing).Item(6).ToString()
                txtreligion.Text = tbl_par.Rows(indexing).Item(7).ToString()
                txtaddress.Text = tbl_par.Rows(indexing).Item(8).ToString()
                txtemail.Text = tbl_par.Rows(indexing).Item(9).ToString()
                txtidcard.Text = tbl_par.Rows(indexing).Item(10).ToString()
                txtoffloc.Text = tbl_par.Rows(indexing).Item(11).ToString()
                txtworkdate.Text = tbl_par.Rows(indexing).Item(12).ToString()
                txtphone.Text = tbl_par.Rows(indexing).Item(13).ToString()
                Dim filefoto As Byte() = CType(tbl_par.Rows(indexing).Item(14), Byte())
                If filefoto.Length > 0 Then
                    pictureEdit.Image = ByteToImage(filefoto)
                Else
                    pictureEdit.Image = Nothing
                    pictureEdit.Refresh()
                End If
                txtstatus.Text = tbl_par.Rows(indexing).Item(15).ToString()
                txtrains.Text = tbl_par.Rows(indexing).Item(16).ToString()
                txtemptype.Text = tbl_par.Rows(indexing).Item(17).ToString()
            End If
        Next
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If barJudul.Caption = "Add Employee" Then
            If txtnames.Text = "" Then
                MsgBox("Please Fill The Required Fields")
            Else
                InsertEmp()
            End If
        ElseIf barJudul.Caption = "Change Data" Then
            If txtempcode.Text = "" Then
                MsgBox("Please Choose The Employee Code")
            ElseIf txtstatus.Text = "Fired" Then
                Dim mess2 As String
                mess2 = CType(MsgBox("are you sure to 'FIRED' thia employee ?", MsgBoxStyle.YesNo, "Warning"), String)
                If CType(mess2, Global.Microsoft.VisualBasic.MsgBoxResult) = vbYes Then
                    UpdateEmp()
                End If
                'MsgBox("Are you sure to change this employee status to be FIRED?", MsgBoxStyle.YesNo)
                'If vbYes = CType(True, Global.Microsoft.VisualBasic.MsgBoxResult) Then
                '    UpdateEmp()
                'End If
            Else
                UpdateEmp()
            End If
        End If
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        cleartxt()
    End Sub

    Private Sub txtstatus_SelectedValueChanged(sender As Object, e As EventArgs) Handles txtstatus.SelectedValueChanged
        If txtstatus.SelectedIndex = 0 Then
            txtstatus.SelectedItem = "Active"
            lctrains.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        ElseIf txtstatus.SelectedIndex = 1 Then
            txtstatus.SelectedItem = "Training"
            lctrains.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        ElseIf txtstatus.SelectedIndex = 2 Then
            txtstatus.SelectedItem = "Fired"
            lctrains.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End If
    End Sub

    Private Sub btnPhoto_Click(sender As Object, e As EventArgs) Handles btnPhoto.Click
        Using dialog As New OpenFileDialog
            If dialog.ShowDialog() <> DialogResult.OK Then Return
            txtfoto.Image = Image.FromFile(dialog.FileName)
            pictureEdit.Image = Image.FromFile(dialog.FileName)
        End Using
    End Sub
End Class