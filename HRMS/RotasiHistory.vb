﻿Imports System.IO
Imports DevExpress.Utils.Menu
Imports DevExpress.XtraGrid.Views.Grid

Public Class RotasiHistory
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

    Private Sub loadData()
        GridControl1.RefreshDataSource()
        Dim table As New DataTable
        SQLConnection = New MySqlConnection()
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        Dim sqlCommand As New MySqlCommand
        Try
            sqlCommand.CommandText = "Select EmployeeCode, CompanyCode, FullName, Position, Rotasi, RotasiDate FROM db_rotasihistory"
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
    Private Sub RotasiHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GridControl1.RefreshDataSource()
        GridView1.Columns.Clear()
        loadData()

    End Sub

    Private Sub GridView1_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GridView1.PopupMenuShowing
        Dim view As GridView = CType(sender, GridView)
        ' Check whether a row is right-clicked.
        If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Row Then
            Dim rowHandle As Integer = e.HitInfo.RowHandle
            ' Delete existing menu items, if any.
            e.Menu.Items.Clear()
            ' Add a submenu with a single menu item.
            ' e.Menu.Items.Add(CreateRowSubMenu(view, rowHandle))
            ' Add a check menu item.           
            Dim item As DXMenuItem = CreateMergingEnabledMenuItem(view, rowHandle)
            item.BeginGroup = True
            e.Menu.Items.Add(item)
        End If
    End Sub
End Class