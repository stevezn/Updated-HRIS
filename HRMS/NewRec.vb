Imports System.IO

Public Class NewRec
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

    Sub reset()
        lcName.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcid.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcpob.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcCv.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcbtncv.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
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

    Public Sub updatechange2()
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
                                     ", Reason = @Reason " +
                                     " WHERE IdRec = @Idrec"
            sqlcommand.Connection = SQLConnection
            sqlcommand.Parameters.AddWithValue("@IdRec", txtid.Text)
            sqlcommand.Parameters.AddWithValue("@InterviewTimes", txtinterview.Text)
            sqlcommand.Parameters.AddWithValue("@PlaceOfBirth", txtpob.Text)
            sqlcommand.Parameters.AddWithValue("@DateOfBirth", txtdob.Text)
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
            sqlcommand.Parameters.AddWithValue("@Status", "Pending")
            sqlcommand.Parameters.AddWithValue("@InterviewDate", txtinterviewdate.Text)
            sqlcommand.Parameters.AddWithValue("@Cv", txtcv.Text)
            sqlcommand.Parameters.AddWithValue("@Reason", txtreason.Text)
            sqlcommand.Connection = SQLConnection
            sqlcommand.ExecuteNonQuery()
            MessageBox.Show("Data Successfully Changed!")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub cleartxt()
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

    Dim main As MainApp

    Public Function insertreq2() As Boolean
        Dim dtb, dtr As DateTime
        txtinterviewdate.Format = DateTimePickerFormat.Custom
        txtinterviewdate.CustomFormat = "yyyy-MM-dd"
        dtb = txtinterviewdate.Value
        txtdob.Format = DateTimePickerFormat.Custom
        txtdob.CustomFormat = "yyyy-MM-dd"
        dtr = txtdob.Value
        Dim ynow As String = Format(Now, "yy").ToString
        Dim mnow As String = Month(Now).ToString
        Dim lastn As Integer
        Dim hasil As Integer
        Dim lastres As Integer
        Dim maxid As Integer
        Dim newid As Integer = maxid + 1
        Dim updmon As String
        Dim lastcode As String = ""
        Dim tmp As Integer
        Try
            Dim cmd = SQLConnection.CreateCommand()
            cmd.CommandText = "SELECT IdRec FROM id_last_num"
            lastn = DirectCast(cmd.ExecuteScalar(), Integer)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            Dim cmd = SQLConnection.CreateCommand
            cmd.CommandText = "SELECT Idrec FROM db_recruitment ORDER BY IdRec DESC LIMIT 1"
            lastcode = DirectCast(cmd.ExecuteScalar(), String)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            Dim cmd = SQLConnection.CreateCommand
            cmd.CommandText = "SELECT MID(Idrec, 8, 1) FROM db_recruitment where idrec = '" & lastcode & "'"
            updmon = DirectCast(cmd.ExecuteScalar(), String)
            If CInt(updmon) <> CInt(mnow) Then
                tmp = 1
            Else
                tmp = lastn + 1
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Dim actualcode As String = "REQ" & "-" & ynow & "-" & mnow & "-" & Strings.Right("0000" & tmp, 5)

        Try
            Dim cmd = SQLConnection.CreateCommand
            cmd.CommandText = "Select count(*) from db_recruitment where IdNumber = '" & txtidcard.Text & "'"
            hasil = CInt(cmd.ExecuteScalar)
            If hasil = 0 Then
                lastres = 1
            ElseIf hasil = 1 OrElse hasil > 1 Then
                lastres = hasil + 1
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        txtinterview.Text = lastres.ToString

        If lastres = 1 OrElse lastres = 2 Then
            txtstatus.Text = "Pending"
        ElseIf lastres > 2 Then
            txtstatus.Text = "Blocked"
        End If
        Dim sqlCommand As New MySqlCommand
        Dim str_carSql As String
        Try
            str_carSql = "INSERT INTO db_recruitment " +
                   "(IdRec, InterviewTimes, FullName, PlaceOfBirth, DateOfBirth, Address, Gender, Religion, PhoneNumber, IdNumber, Photo, Status, InterviewDate, Cv, Reason, CreatedDate) " +
                   "values (@IdRec,@InterviewTimes,@FullName,@PlaceOfBirth,@DateOfBirth,@Address,@Gender,@Religion, @PhoneNumber, @IdNumber,@Photo,@Status,@InterviewDate,@Cv,@Reason, @CreatedDate)"
            sqlCommand.Connection = SQLConnection
            sqlCommand.CommandText = str_carSql
            sqlCommand.Parameters.AddWithValue("@IdRec", actualcode)
            sqlCommand.Parameters.AddWithValue("@InterviewTimes", txtinterview.Text)
            sqlCommand.Parameters.AddWithValue("@FullName", txtnames.Text)
            sqlCommand.Parameters.AddWithValue("@PlaceOfBirth", txtpob.Text)
            sqlCommand.Parameters.AddWithValue("@DateOfBirth", dtr.ToString("yyyy-MM-dd"))
            sqlCommand.Parameters.AddWithValue("@Address", txtaddress.Text)
            sqlCommand.Parameters.AddWithValue("@Gender", txtgender.Text)
            sqlCommand.Parameters.AddWithValue("@Religion", txtreligion.Text)
            sqlCommand.Parameters.AddWithValue("@PhoneNumber", txtphone.Text)
            sqlCommand.Parameters.AddWithValue("@IdNumber", txtidcard.Text)
            If Not txtbrowse.Text Is Nothing Then
                Dim param As New MySqlParameter("@Photo", ImageToByte(pictureEdit))
                sqlCommand.Parameters.Add(param)
            Else
                sqlCommand.Parameters.AddWithValue("@Photo", "")
            End If
            sqlCommand.Parameters.AddWithValue("@Status", txtstatus.Text)
            sqlCommand.Parameters.AddWithValue("@InterviewDate", dtb.ToString("yyyy-MM-dd"))
            sqlCommand.Parameters.AddWithValue("@Cv", txtcv.Text)
            sqlCommand.Parameters.AddWithValue("@Reason", "")
            sqlCommand.Parameters.AddWithValue("@CreatedDate", Date.Now)
            sqlCommand.ExecuteNonQuery()
            MessageBox.Show("Data Succesfully Added!")
            Return True
        Catch ex As Exception
            Return False
            MsgBox(ex.Message)
        End Try
    End Function

    Dim tbl_par As New DataTable

    Private Sub NewEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        cleartxt()
        reset()
        barJudul.Caption = "Add Recruitment"
        lcName.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcid.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcpob.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcbrowse.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcgender.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcreligion.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcidcard.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcaddress.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcphone.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcstats.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcbtnsave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcbtnreset.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        BarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
    End Sub

    Private Sub NewEmployee_Move(sender As Object, e As EventArgs) Handles MyBase.Move
        'Location = New Point(500, 200)
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        cleartxt()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If barJudul.Caption = "Add Recruitment" Then
            If txtnames.Text = "" Then
                MsgBox("Please Insert The Required Fields")
            Else
                insertreq2()
            End If
        ElseIf barJudul.Caption = "Change Data" Then
            updatechange2()
        End If
    End Sub

    Private Sub btnPhoto_Click(sender As Object, e As EventArgs) Handles btnPhoto.Click
        Using dialog As New OpenFileDialog
            If dialog.ShowDialog() <> DialogResult.OK Then Return
            txtbrowse.Image = Image.FromFile(dialog.FileName)
            pictureEdit.Image = Image.FromFile(dialog.FileName)
        End Using
    End Sub

    Private Sub BarButtonItem2_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        cleartxt()
        barJudul.Caption = "Change Data"
        reset()
        lcid.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lcpob.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
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
        RibbonPageGroup1.Visible = False
    End Sub    

    Dim openfd As New OpenFileDialog

    Private Sub btnCV_Click(sender As Object, e As EventArgs) Handles btnCV.Click
        'Try
        '    Dim fs As FileStream
        '    fs = New FileStream(sfile, FileMode.Open, FileAccess.Read)

        '    Dim docByte As Byte() = New Byte(fs.Length - 1) {}

        '    fs.Read(docByte, 0, System.Convert.ToInt32(fs.Length))

        '    fs.Close()
        '    'Insert statement for sql query
        '    Dim sqltxt As String
        '    sqltxt = "insert into db_recruitment values('" & txtcv.Text & "',@fdoc)"

        '    'store doc as Binary value using SQLParameter
        '    Dim docfile As New MySqlParameter
        '    docfile.MySqlDbType = MySqlDbType.Binary
        '    docfile.ParameterName = "fdoc"
        '    docfile.Value = docByte
        '    Dim sqlcmd = New MySqlCommand(sqltxt, SQLConnection)
        '    sqlcmd.Parameters.Add(docfile)
        '    sqlcmd.ExecuteNonQuery()
        '    MsgBox("Data Saved Successfully")
        'Catch ex As Exception
        'End Try

        openfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer)
        openfd.Title = "Open a CV File"
        openfd.Filter = "Word Files|*.docx|Text Files|*.txt"
        openfd.ShowDialog()
        txtcv.Text = openfd.FileName
    End Sub

    Private Sub OpenPreviewWindows()
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
                If data.GetDataPresent(GetType(System.Drawing.Bitmap)) Then
                    Bmap = CType(data.GetData(GetType(System.Drawing.Bitmap)), Drawing.Image)
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
End Class