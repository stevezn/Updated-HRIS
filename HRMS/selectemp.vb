﻿Imports System.IO
Imports DevExpress.Utils.Menu
Imports DevExpress.XtraGrid.Views.Grid

Public Class selectemp
    Dim connectionString As String
    Dim SQLConnection As MySqlConnection = New MySqlConnection
    Dim oDt_sched As New DataTable()
    Dim tbl_par As New DataTable

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call.
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
        Dim ms As New MemoryStream()
        pbImg.Image.Save(ms, Imaging.ImageFormat.Jpeg)
        Return ms.ToArray()
    End Function

    Public Function ByteToImage(ByVal filefoto As Byte()) As Image
        Dim pictureBytes As New MemoryStream(filefoto)
        Return Image.FromStream(pictureBytes)
    End Function

    Dim att As New Attendance

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
            sqlCommand.CommandText = "SELECT FUllName, EmployeeCode, Photo, Position, Status FROM db_pegawai WHERE 1=1 " + param.ToString()
            sqlCommand.Connection = SQLConnection

            Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(datatabl)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If datatabl.Rows.Count > 0 Then
            Label2.Text = datatabl.Rows(0).Item(0).ToString()
            Label3.Text = datatabl.Rows(0).Item(1).ToString
            Dim filefoto As Byte() = CType(datatabl.Rows(0).Item(2), Byte())
            If filefoto.Length > 0 Then
                PictureBox1.Image = ByteToImage(filefoto)
            Else
                PictureBox1.Image = Nothing
                PictureBox1.Refresh()
            End If
            Label4.Text = datatabl.Rows(0).Item(3).ToString
            Label5.Text = datatabl.Rows(0).Item(4).ToString
        End If
    End Sub

    Sub recordss()
        Dim rec As MySqlCommand = SQLConnection.CreateCommand
        rec.CommandText = "select count(*) from db_pegawai"
        txtrec1.Text = CStr(rec.ExecuteScalar)
    End Sub

    Sub loaddata()
        GridControl1.RefreshDataSource()
        Dim table As New DataTable
        Dim sqlcommand As New MySqlCommand
        Try
            sqlcommand.CommandText = "Select EmployeeCode, CompanyCode, FullName, Position, PlaceOfBirth, DateOfBirth, Gender, Religion, Address, IdNumber, OfficeLocation, WorkDate, PhoneNumber, Status, EmployeeType from db_pegawai where status != 'Fired' and status != 'Terminate'"
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

    Private Sub selectemp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        loaddata()
        recordss()
        GridView1.BestFitColumns()
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        loaddata()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Dim del As MySqlCommand = SQLConnection.CreateCommand
        del.CommandText = "truncate db_tmpname"
        del.ExecuteNonQuery()

        Dim name As MySqlCommand = SQLConnection.CreateCommand
        name.CommandText = "insert into db_tmpname" +
                            "(name, employeecode, jobtitle, status)" +
                            "Values(@name, @employeecode, @jobtitle, @status)"
        name.Parameters.AddWithValue("@name", Label2.Text)
        name.Parameters.AddWithValue("@Employeecode", Label3.Text)
        name.Parameters.AddWithValue("@jobtitle", Label4.Text)
        name.Parameters.AddWithValue("@status", Label5.Text)
        name.ExecuteNonQuery()
        Close()
    End Sub

    Private Sub GridView1_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GridView1.PopupMenuShowing
        If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Row Then
            e.Menu.Items.Add(New DXMenuItem("Select Employee", New EventHandler(AddressOf SimpleButton3_Click)))
        End If
    End Sub
End Class