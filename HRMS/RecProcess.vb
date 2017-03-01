Imports System.IO
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Utils.Menu

Public Class RecProcess

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
        lcreason.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcfullname.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcid.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcidcard.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcaddress.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcphone.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcstats.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
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

    Sub cleartxt()
        txtid.Text = ""
        txtinterview.Text = ""
        txtaddress.Text = ""
        txtphone.Text = ""
        txtidcard.Text = ""
        txtstatus.Text = ""
        pictureEdit.Controls.Clear()
        txtinterviewdate.Text = ""
    End Sub

    Public Function InsertReq() As Boolean
        Dim sqlCommand As New MySqlCommand
        Dim str_carSql As String
        Try
            str_carSql = "INSERT INTO db_recruit " +
                   "(IdRec, InterviewTimes, FullName,PhoneNumber, IdNumber, Status, InterviewDate, Reason) " +
                   "values (@IdRec,@InterviewTimes,@FullName,@PhoneNumber,@IdNumber,@Status,@InterviewDate,@Reason)"
            sqlCommand.Connection = SQLConnection
            sqlCommand.CommandText = str_carSql
            sqlCommand.Parameters.AddWithValue("@IdRec", txtid.Text)
            sqlCommand.Parameters.AddWithValue("@InterviewTimes", txtinterview.Text)
            sqlCommand.Parameters.AddWithValue("@FullName", txtfullname.Text)
            sqlCommand.Parameters.AddWithValue("@PhoneNumber", txtphone.Text)
            sqlCommand.Parameters.AddWithValue("@IdNumber", txtidcard.Text)
            sqlCommand.Parameters.AddWithValue("@Status", txtstatus.Text)
            sqlCommand.Parameters.AddWithValue("@InterviewDate", txtinterviewdate.Text)
            sqlCommand.Parameters.AddWithValue("@Reason", txtreason.Text)
            sqlCommand.ExecuteNonQuery()
            MessageBox.Show("Data Succesfully Added!")
            Return True
        Catch ex As Exception
            Return False
            MsgBox(ex.Message)
        End Try
    End Function

    Public Sub updatechange()
        Dim dtb As DateTime
        txtinterviewdate.Format = DateTimePickerFormat.Custom
        txtinterviewdate.CustomFormat = "yyyy-MM-dd"
        dtb = txtinterviewdate.Value
        Dim cmd As MySqlCommand = SQLConnection.CreateCommand
        cmd.CommandText = "Update db_recruitment set interviewtimes = @it, FullName = @fn, Address = @address, PhoneNumber = @pn, IdNumber = @in, status = @status, interviewdates = @id where idrec = '" & txtid.Text & "'"
        cmd.Parameters.AddWithValue("@it", txtinterview.Text)
        cmd.Parameters.AddWithValue("@fn", txtfullname.Text)
        cmd.Parameters.AddWithValue("@address", txtaddress.Text)
        cmd.Parameters.AddWithValue("@pn", txtphone.Text)
        cmd.Parameters.AddWithValue("@in", txtidcard.Text)
        cmd.Parameters.AddWithValue("@status", txtstatus.Text)
        cmd.Parameters.AddWithValue("@id", dtb.ToString("yyyy-MM-dd"))
        cmd.ExecuteNonQuery()
        NotifyIcon1.Visible = True
        NotifyIcon1.Icon = SystemIcons.Information
        NotifyIcon1.BalloonTipTitle = "Recruitment Process"
        NotifyIcon1.BalloonTipText = "Data Changed"
        NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
        NotifyIcon1.ShowBalloonTip(300000)
    End Sub


    Public Sub updatechange2()
        Dim dtb As DateTime
        txtinterviewdate.Format = DateTimePickerFormat.Custom
        txtinterviewdate.CustomFormat = "yyyy-MM-dd"
        dtb = txtinterviewdate.Value
        Dim sqlcommand As New MySqlCommand
        Try
            sqlcommand.CommandText = "UPDATE db_recruitment SET" +
                                     " InterviewTimes = @InterviewTimes" +
                                     ", FullName = @FullName" +
                                     ", Address = @Address" +
                                     ", PhoneNumber = @PhoneNumber" +
                                     ", IdNumber = @IdNumber" +
                                     ", Status = @Status" +
                                     ", InterviewDate = @InterviewDate" +
                                     " WHERE IdRec = @IdRec"
            sqlcommand.Connection = SQLConnection
            sqlcommand.Parameters.AddWithValue("@IdRec", txtid.Text)
            sqlcommand.Parameters.AddWithValue("@InterviewTimes", txtinterview.Text)
            sqlcommand.Parameters.AddWithValue("@FullName", txtfullname.Text)
            sqlcommand.Parameters.AddWithValue("@Address", txtaddress.Text)
            sqlcommand.Parameters.AddWithValue("@PhoneNumber", txtphone.Text)
            sqlcommand.Parameters.AddWithValue("@IdNumber", txtidcard.Text)
            sqlcommand.Parameters.AddWithValue("@Status", txtstatus.Text)
            sqlcommand.Parameters.AddWithValue("@InterviewDates", dtb.ToString("yyyy-MM-dd"))
            sqlcommand.Connection = SQLConnection
            sqlcommand.ExecuteNonQuery()
            MessageBox.Show("Data Successfully Changed!")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Function insertreq2() As Boolean
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
            ElseIf hasil = 1 OrElse hasil < 1 Then
                lastres = hasil + 1
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        txtinterview.Text = lastres.ToString
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
            sqlCommand.Parameters.AddWithValue("@PlaceOfBirth", "")
            sqlCommand.Parameters.AddWithValue("@DateOfBirth", "")
            sqlCommand.Parameters.AddWithValue("@Address", txtaddress.Text)
            sqlCommand.Parameters.AddWithValue("@Gender", "")
            sqlCommand.Parameters.AddWithValue("@Religion", "")
            sqlCommand.Parameters.AddWithValue("@PhoneNumber", txtphone.Text)
            sqlCommand.Parameters.AddWithValue("@IdNumber", txtidcard.Text)
            sqlCommand.Parameters.AddWithValue("@Photo", "")
            sqlCommand.Parameters.AddWithValue("@Status", txtstatus.Text)
            sqlCommand.Parameters.AddWithValue("@InterviewDate", txtinterviewdate.Text)
            sqlCommand.Parameters.AddWithValue("@Cv", "")
            sqlCommand.Parameters.AddWithValue("@Reason", "")
            sqlCommand.Parameters.AddWithValue("@CreatedDate", Date.Now)
            sqlCommand.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Return False
            MsgBox("Error Occured: Could Not Insert Records")
        End Try
    End Function

    Dim tbl_par As New DataTable

    Sub loadDataKaryawan()
        Dim sqlCommand As New MySqlCommand
        sqlCommand.CommandText = "SELECT IdRec, InterviewTimes, FullName, PlaceOfBirth, DateOfBirth, Address, Gender, Religion, PhoneNumber, IdNumber, Photo, status, InterviewDate, Cv, Reason FROM db_recruitment where status = 'Pending'"
        sqlCommand.Connection = SQLConnection
        Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
        Dim cb As New MySqlCommandBuilder(adapter)
        adapter.Fill(tbl_par)
        For index As Integer = 0 To tbl_par.Rows.Count - 1
            txtfullname.Properties.Items.Add(tbl_par.Rows(index).Item(2).ToString())
        Next
    End Sub

    Dim tbl_par12 As New DataTable

    Sub loadDataKaryawan2()
        Dim sqlCommand As New MySqlCommand
        sqlCommand.CommandText = "SELECT IdRec, InterviewTimes, FullName, PhoneNumber, IdNumber, status, InterviewDate, Reason FROM db_recruit where status = 'In Progress'"
        sqlCommand.Connection = SQLConnection
        Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
        Dim cb As New MySqlCommandBuilder(adapter)
        adapter.Fill(tbl_par12)
        For index As Integer = 0 To tbl_par12.Rows.Count - 1
        Next
    End Sub

    Private Sub txtfullname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtfullname.SelectedIndexChanged
        For indexing As Integer = 0 To tbl_par.Rows.Count - 1
            If txtfullname.SelectedItem Is tbl_par.Rows(indexing).Item(2).ToString() Then
                txtid.Text = tbl_par.Rows(indexing).Item(0).ToString()
                txtinterview.Text = tbl_par.Rows(indexing).Item(1).ToString()
                txtaddress.Text = tbl_par.Rows(indexing).Item(5).ToString()
                txtphone.Text = tbl_par.Rows(indexing).Item(8).ToString()
                txtidcard.Text = tbl_par.Rows(indexing).Item(9).ToString()
                Dim filefoto As Byte() = CType(tbl_par.Rows(indexing).Item(10), Byte())
                If filefoto.Length > 0 Then
                    pictureEdit.Image = ByteToImage(filefoto)
                Else
                    pictureEdit.Image = Nothing
                    pictureEdit.Refresh()
                End If
                txtstatus.Text = tbl_par.Rows(indexing).Item(11).ToString
                txtinterviewdate.Text = tbl_par.Rows(indexing).Item(12).ToString
                txtreason.Text = tbl_par.Rows(indexing).Item(14).ToString
            End If
        Next
    End Sub

    Private Sub loadDataReq()
        GridControl1.RefreshDataSource()
        Dim table As New DataTable
        Dim sqlCommand As New MySqlCommand
        Try
            If barJudul.Caption = "Recruitment Process" Then
                sqlCommand.CommandText = "SELECT IdRec, InterviewTimes, FullName, PhoneNumber, IdNumber, Status, InterviewDate, Reason FROM db_recruit where status = 'In Progress'"
            End If
            sqlCommand.Connection = SQLConnection
            Dim tbl_par As New DataTable
            Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(table)
            GridControl1.DataSource = table
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub loadinfo()
        GridControl1.RefreshDataSource()
        Dim table As New DataTable
        Dim sqlcommand As New MySqlCommand
        Try
            sqlcommand.CommandText = "select IdRec, FullName, InterviewTimes, IdNumber, Gender, Status CreatedDate from db_recruitment where status = 'Pending'"
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

    Private Sub loadinfo2()
        GridControl1.RefreshDataSource()
        Dim table As New DataTable
        Dim sqlcommand As New MySqlCommand
        Try
            sqlcommand.CommandText = "select IdRec, FullName, InterviewTimes, IdNumber, Gender, Status CreatedDate from db_recruitment where status = 'In progress'"
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

    Private Sub loadinfo3()
        GridControl1.RefreshDataSource()
        Dim table As New DataTable
        Dim sqlcommand As New MySqlCommand
        Try
            sqlcommand.CommandText = "select IdRec, FullName, InterviewTimes, IdNumber, Gender, Status, CreatedDate  from db_recruitment where status = 'Processed'"
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

    Private Sub RecProcess_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        barJudul.Caption = "Recruitment Process"
        GridControl1.RefreshDataSource()
        GridView1.Columns.Clear()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs)
        cleartxt()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs)
        cleartxt()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If txtid.Text = "" Then
            MsgBox("Please insert an employee name or employee code")
        Else
            updatechange()
        End If
    End Sub

    Private Sub GridView1_PopupMenuShowing(sender As Object, e As Views.Grid.PopupMenuShowingEventArgs) Handles GridView1.PopupMenuShowing
        Dim view As GridView = CType(sender, GridView)
        If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Row Then
            Dim rowHandle As Integer = e.HitInfo.RowHandle
            e.Menu.Items.Clear()
            Dim item As DXMenuItem = CreateMergingEnabledMenuItem(view, rowHandle)
            item.BeginGroup = True
            e.Menu.Items.Add(item)
        End If
    End Sub

    Dim view As New pdfviewer

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        If view Is Nothing OrElse view.IsDisposed Then
            view = New pdfviewer
        End If
        view.Show()
    End Sub

    Private Sub ComboBoxEdit1_SelectedIndexChanged(sender As Object, e As EventArgs)
        For indexing As Integer = 0 To tbl_par12.Rows.Count - 1
            If txtfullname.SelectedItem Is tbl_par12.Rows(indexing).Item(2).ToString() Then
                txtid.Text = tbl_par12.Rows(indexing).Item(0).ToString()
                txtinterview.Text = tbl_par12.Rows(indexing).Item(1).ToString()
                txtphone.Text = tbl_par12.Rows(indexing).Item(3).ToString()
                txtidcard.Text = tbl_par12.Rows(indexing).Item(4).ToString()
                txtstatus.Text = tbl_par12.Rows(indexing).Item(5).ToString
                txtinterviewdate.Text = tbl_par12.Rows(indexing).Item(6).ToString
                txtreason.Text = tbl_par12.Rows(indexing).Item(7).ToString
            End If
        Next
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        lcview.Text = "Pending Lists"
        loadinfo()
    End Sub

    Private Sub SimpleButton2_Click_1(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        lcview.Text = "In Progress Lists"
        loadinfo2()
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        lcview.Text = "Proccessed"
        loadinfo3()
    End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
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
        If datatabl.Rows.Count > 0 Then
            txtfullname.Text = datatabl.Rows(0).Item(2).ToString()
            txtid.Text = datatabl.Rows(0).Item(0).ToString()
            txtinterview.Text = datatabl.Rows(0).Item(1).ToString()
            txtidcard.Text = datatabl.Rows(0).Item(9).ToString()
            txtaddress.Text = datatabl.Rows(0).Item(5).ToString()
            txtphone.Text = datatabl.Rows(0).Item(8).ToString()
            txtinterviewdate.Text = datatabl.Rows(0).Item(12).ToString()
            Dim filefoto As Byte() = CType(datatabl.Rows(0).Item(10), Byte())
            If filefoto.Length > 0 Then
                pictureEdit.Image = ByteToImage(filefoto)
            Else
                pictureEdit.Image = Nothing
                pictureEdit.Refresh()
            End If
            txtstatus.Text = datatabl.Rows(0).Item(11).ToString()
        End If
    End Sub
    Dim anly As New Analytical

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        If anly Is Nothing OrElse anly.IsDisposed OrElse anly.MinimizeBox Then
            anly.Close()
            anly = New Analytical
        End If
        anly.Show()
    End Sub

    Dim rates As New Rating

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        If rates Is Nothing OrElse rates.IsDisposed OrElse rates.MinimizeBox Then
            rates.Close()
            rates = New Rating
        End If
        rates.Show()
    End Sub
End Class