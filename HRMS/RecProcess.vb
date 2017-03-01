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
        'connectionString = "Server=" + host + "; User Id=root; Password=; Database=db_hris"
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
        SQLConnection = New MySqlConnection()
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
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

    Public Function deletereq() As Boolean
        SQLConnection = New MySqlConnection
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        Dim sqlcommand As New MySqlCommand
        'Dim mess As String
        'mess = CType(MsgBox("Sure To Delete ?", MsgBoxStyle.YesNo, "Warning"), String)
        'If CType(mess, Global.Microsoft.VisualBasic.MsgBoxResult) = vbYes Then
        sqlcommand.Connection = SQLConnection
        sqlcommand.CommandType = CommandType.Text
        sqlcommand.CommandText = "DELETE FROM db_recruitment WHERE status = 'Pending' and IdNumber = " + txtidcard.Text
        sqlcommand.ExecuteNonQuery()
        'MsgBox("Data Succesfully Removed!", MsgBoxStyle.Information, "Success")
        GridControl1.RefreshDataSource()
        loadDataReq()
        SQLConnection.Close()
        'End If
        Return Nothing
    End Function

    Public Function insertreq2() As Boolean
        SQLConnection = New MySqlConnection()
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
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
            ' sqlCommand.Parameters.AddWithValue("@FullName", txtfullname.Text & txtprogname.Text)
            sqlCommand.Parameters.AddWithValue("@PlaceOfBirth", "")
            sqlCommand.Parameters.AddWithValue("@DateOfBirth", "")
            sqlCommand.Parameters.AddWithValue("@Address", txtaddress.Text)
            sqlCommand.Parameters.AddWithValue("@Gender", "")
            sqlCommand.Parameters.AddWithValue("@Religion", "")
            sqlCommand.Parameters.AddWithValue("@PhoneNumber", txtphone.Text)
            sqlCommand.Parameters.AddWithValue("@IdNumber", txtidcard.Text)
            ' If Not txtbrowse.Text Is Nothing Then
            ' Dim param As New MySqlParameter("@Photo", ImageToByte(pictureEdit))
            '   sqlCommand.Parameters.Add(param)
            ' Else
            sqlCommand.Parameters.AddWithValue("@Photo", "")
            ' End If
            sqlCommand.Parameters.AddWithValue("@Status", txtstatus.Text)
            sqlCommand.Parameters.AddWithValue("@InterviewDate", txtinterviewdate.Text)
            sqlCommand.Parameters.AddWithValue("@Cv", "")
            sqlCommand.Parameters.AddWithValue("@Reason", "")
            sqlCommand.Parameters.AddWithValue("@CreatedDate", Date.Now)
            sqlCommand.ExecuteNonQuery()
            ' MessageBox.Show("Data Succesfully Added!")
            Return True
        Catch ex As Exception
            Return False
            MsgBox("Error Occured: Could Not Insert Records")
        End Try
    End Function

    Dim tbl_par As New DataTable

    Sub loadDataKaryawan()
        SQLConnection = New MySqlConnection()
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        Dim sqlCommand As New MySqlCommand
        sqlCommand.CommandText = "SELECT IdRec, InterviewTimes, FullName, PlaceOfBirth, DateOfBirth, Address, Gender, Religion, PhoneNumber, IdNumber, Photo, status, InterviewDate, Cv, Reason FROM db_recruitment where status = 'Pending'"
        sqlCommand.Connection = SQLConnection
        Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
        Dim cb As New MySqlCommandBuilder(adapter)
        adapter.Fill(tbl_par)
        For index As Integer = 0 To tbl_par.Rows.Count - 1
            txtfullname.Properties.Items.Add(tbl_par.Rows(index).Item(2).ToString())
        Next
        SQLConnection.Close()
    End Sub

    Dim tbl_par12 As New DataTable

    Sub loadDataKaryawan2()
        SQLConnection = New MySqlConnection()
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        Dim sqlCommand As New MySqlCommand
        sqlCommand.CommandText = "SELECT IdRec, InterviewTimes, FullName, PhoneNumber, IdNumber, status, InterviewDate, Reason FROM db_recruit where status = 'In Progress'"
        sqlCommand.Connection = SQLConnection
        Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
        Dim cb As New MySqlCommandBuilder(adapter)
        adapter.Fill(tbl_par12)
        For index As Integer = 0 To tbl_par12.Rows.Count - 1
            'txtprogname.Properties.Items.Add(tbl_par12.Rows(index).Item(2).ToString())
        Next
        SQLConnection.Close()
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

        SQLConnection = New MySqlConnection()
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
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
            SQLConnection.Close()
        Catch ex As Exception
            SQLConnection.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub loadinfo()
        GridControl1.RefreshDataSource()
        Dim table As New DataTable
        SQLConnection = New MySqlConnection
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        Dim sqlcommand As New MySqlCommand
        Try
            sqlcommand.CommandText = "select IdRec, FullName, InterviewTimes, IdNumber, Gender, CreatedDate  from db_recruitment where status = 'Pending'"
            sqlcommand.Connection = SQLConnection
            Dim tbl_par As New DataTable
            Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(table)
            GridControl1.DataSource = table
            SQLConnection.Close()
        Catch ex As Exception
            SQLConnection.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub loadinfo2()
        GridControl1.RefreshDataSource()
        Dim table As New DataTable
        SQLConnection = New MySqlConnection
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        Dim sqlcommand As New MySqlCommand
        Try
            sqlcommand.CommandText = "select IdRec, FullName, InterviewTimes, IdNumber, Gender, CreatedDate from db_recruitment where status = 'In progress'"
            sqlcommand.Connection = SQLConnection
            Dim tbl_par As New DataTable
            Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(table)
            GridControl1.DataSource = table
            SQLConnection.Close()
        Catch ex As Exception
            SQLConnection.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub loadinfo3()
        GridControl1.RefreshDataSource()
        Dim table As New DataTable
        SQLConnection = New MySqlConnection
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        Dim sqlcommand As New MySqlCommand
        Try
            sqlcommand.CommandText = "select IdRec, FullName, InterviewTimes, IdNumber, Gender, CreatedDate  from db_recruitment where status = 'Processed'"
            sqlcommand.Connection = SQLConnection
            Dim tbl_par As New DataTable
            Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(table)
            GridControl1.DataSource = table
            SQLConnection.Close()
        Catch ex As Exception
            SQLConnection.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub RecProcess_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' loadinfo()
        'loadDataKaryawan()
        'loadDataKaryawan2()
        ' BarButtonItem1.PerformClick()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        barJudul.Caption = "Recruitment Process"
        GridControl1.RefreshDataSource()
        GridView1.Columns.Clear()
        'loadDataReq()
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
            InsertReq()
            insertreq2()
            deletereq()
        End If
    End Sub

    Private Sub GridView1_PopupMenuShowing(sender As Object, e As Views.Grid.PopupMenuShowingEventArgs) Handles GridView1.PopupMenuShowing
        Dim view As GridView = CType(sender, GridView)
        ' Check whether a row is right-clicked.
        If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Row Then
            Dim rowHandle As Integer = e.HitInfo.RowHandle
            ' Delete existing menu items, if any.
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

    'Private Sub GridView1_FocusedRowChanged(sender As Object, e As Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
    '    SQLConnection = New MySqlConnection()
    '    SQLConnection.ConnectionString = connectionString
    '    SQLConnection.Open()
    '    Dim datatabl As New DataTable
    '    Dim sqlCommand As New MySqlCommand
    '    datatabl.Clear()
    '    If lcview.Text = "Pending" Then
    '        Dim param As String = ""
    '        Try
    '            param = "and IdRec='" + GridView1.GetFocusedRowCellValue("IdRec").ToString() + "'"
    '        Catch ex As Exception
    '        End Try
    '        Try
    '            sqlCommand.CommandText = "SELECT IdRec, InterviewTimes, FullName, PlaceofBirth, DateOfBirth, Address,Gender, Religion, PhoneNumber, IdNumber, Photo, Status, InterviewDate, PhoneNumber, InterviewDate, Reason FROM db_recruitment WHERE IdRec = '" + param.ToString()
    '            sqlCommand.Connection = SQLConnection
    '            Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
    '            Dim cb As New MySqlCommandBuilder(adapter)
    '            adapter.Fill(datatabl)
    '            SQLConnection.Close()
    '        Catch ex As Exception
    '            SQLConnection.Close()
    '            MsgBox(ex.Message)
    '        End Try
    '        If datatabl.Rows.Count > 0 Then
    '            txtfullname.Text = datatabl.Rows(0).Item(2).ToString()
    '            txtid.Text = datatabl.Rows(0).Item(0).ToString()
    '            txtinterview.Text = datatabl.Rows(0).Item(1).ToString()
    '            txtidcard.Text = datatabl.Rows(0).Item(9).ToString()
    '            txtaddress.Text = datatabl.Rows(0).Item(5).ToString()
    '            txtphone.Text = datatabl.Rows(0).Item(8).ToString()
    '            txtinterviewdate.Text = datatabl.Rows(0).Item(12).ToString()
    '            Dim filefoto As Byte() = CType(datatabl.Rows(0).Item(10), Byte())
    '            If filefoto.Length > 0 Then
    '                pictureEdit.Image = ByteToImage(filefoto)
    '            Else
    '                pictureEdit.Image = Nothing
    '                pictureEdit.Refresh()
    '            End If
    '            txtstatus.Text = datatabl.Rows(0).Item(11).ToString()
    '        End If
    '    ElseIf lcview.Text = "In Progress" Then
    '        Dim param As String = ""
    '        Try
    '            param = "and IdRec='" + GridView1.GetFocusedRowCellValue("IdRec").ToString() + "'"
    '        Catch ex As Exception
    '        End Try
    '        Try
    '            sqlCommand.CommandText = "SELECT IdRec, InterviewTimes, FullName, PlaceofBirth, DateOfBirth, Address,Gender, Religion, PhoneNumber, IdNumber, Photo, Status, InterviewDate, PhoneNumber, InterviewDate, Reason FROM db_recruitment WHERE IdRec= '" + param.ToString()
    '            sqlCommand.Connection = SQLConnection
    '            Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
    '            Dim cb As New MySqlCommandBuilder(adapter)
    '            adapter.Fill(datatabl)
    '            SQLConnection.Close()
    '        Catch ex As Exception
    '            SQLConnection.Close()
    '            MsgBox(ex.Message)
    '        End Try
    '        If datatabl.Rows.Count > 0 Then
    '            txtfullname.Text = datatabl.Rows(0).Item(2).ToString()
    '            txtid.Text = datatabl.Rows(0).Item(0).ToString()
    '            txtinterview.Text = datatabl.Rows(0).Item(1).ToString()
    '            txtidcard.Text = datatabl.Rows(0).Item(9).ToString()
    '            txtaddress.Text = datatabl.Rows(0).Item(5).ToString()
    '            txtphone.Text = datatabl.Rows(0).Item(8).ToString()
    '            txtinterviewdate.Text = datatabl.Rows(0).Item(12).ToString()
    '            Dim filefoto As Byte() = CType(datatabl.Rows(0).Item(10), Byte())
    '            If filefoto.Length > 0 Then
    '                pictureEdit.Image = ByteToImage(filefoto)
    '            Else
    '                pictureEdit.Image = Nothing
    '                pictureEdit.Refresh()
    '            End If
    '            txtstatus.Text = datatabl.Rows(0).Item(11).ToString()
    '        End If
    '    ElseIf lcview.Text = "Processed" Then
    '        Dim param As String = ""
    '        Try
    '            param = "and IdRec='" + GridView1.GetFocusedRowCellValue("IdRec").ToString() + "'"
    '        Catch ex As Exception
    '        End Try
    '        Try
    '            sqlCommand.CommandText = "SELECT IdRec, InterviewTimes, FullName, PlaceofBirth, DateOfBirth, Address,Gender, Religion, PhoneNumber, IdNumber, Photo, Status, InterviewDate, PhoneNumber, InterviewDate, Reason FROM db_recruitment WHERE IdRec =  '" + param.ToString()
    '            sqlCommand.Connection = SQLConnection
    '            Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
    '            Dim cb As New MySqlCommandBuilder(adapter)
    '            adapter.Fill(datatabl)
    '            SQLConnection.Close()
    '        Catch ex As Exception
    '            SQLConnection.Close()
    '            MsgBox(ex.Message)
    '        End Try
    '        If datatabl.Rows.Count > 0 Then
    '            txtfullname.Text = datatabl.Rows(0).Item(2).ToString()
    '            txtid.Text = datatabl.Rows(0).Item(0).ToString()
    '            txtinterview.Text = datatabl.Rows(0).Item(1).ToString()
    '            txtidcard.Text = datatabl.Rows(0).Item(9).ToString()
    '            txtaddress.Text = datatabl.Rows(0).Item(5).ToString()
    '            txtphone.Text = datatabl.Rows(0).Item(8).ToString()
    '            txtinterviewdate.Text = datatabl.Rows(0).Item(12).ToString()
    '            Dim filefoto As Byte() = CType(datatabl.Rows(0).Item(10), Byte())
    '            If filefoto.Length > 0 Then
    '                pictureEdit.Image = ByteToImage(filefoto)
    '            Else
    '                pictureEdit.Image = Nothing
    '                pictureEdit.Refresh()
    '            End If
    '            txtstatus.Text = datatabl.Rows(0).Item(11).ToString()
    '        End If
    '    End If
    'End Sub

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
        SQLConnection = New MySqlConnection()
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
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
            SQLConnection.Close()
        Catch ex As Exception
            SQLConnection.Close()
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
End Class