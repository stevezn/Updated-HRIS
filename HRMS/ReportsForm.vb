Imports word = Microsoft.Office.Interop.Word
Imports System.IO

Public Class ReportsForm
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

    Private Sub txtdate_CheckedChanged(sender As Object, e As EventArgs) Handles txtdate.CheckedChanged
        If txtdate.Checked = True Then
            date1.Enabled = True
            date2.Enabled = True
        ElseIf txtdate.Checked = False Then
            date1.Enabled = False
            date2.Enabled = False
        End If
    End Sub

    Sub attendance()
        Dim table As New DataTable
        SQLConnection = New MySqlConnection()
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        Dim a As MySqlCommand = SQLConnection.CreateCommand
        a.CommandText = "select * from db_absensi where tanggal between @date1 and @date2"
        a.Parameters.AddWithValue("@date1", date1.Value)
        a.Parameters.AddWithValue("@date2", date2.Value)
        Dim tbl_par As New DataTable
        Dim adapter As New MySqlDataAdapter(a.CommandText, SQLConnection)
        Dim cb As New MySqlCommandBuilder(adapter)
        adapter.Fill(table)
        lis.GridControl1.DataSource = table
        SQLConnection.Close()
    End Sub

    Sub attend()
        SQLConnection = New MySqlConnection
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        Dim sqlcommand As New MySqlCommand
        sqlcommand.CommandText = "select * from db_absensi where tanggal between @date1 and @date2"
        Dim p1, p2 As New MySqlParameter
        p1.ParameterName = "@date1"
        p1.Value = date1.Value
        p2.ParameterName = "@date2"
        p2.Value = date2.Value
        sqlcommand.Parameters.Add(p1)
        sqlcommand.Parameters.Add(p2)
        sqlcommand.Connection = SQLConnection
        Dim dt As New DataTable
        dt.Load(sqlcommand.ExecuteReader)
        lis.GridControl1.DataSource = dt
        SQLConnection.Close()
    End Sub

    Sub employee()

    End Sub

    Dim reports As Report

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        'If date1.Text = "" Then
        '    MsgBox("Please Input The Start Date")
        'ElseIf date1.Value > date2.Value Then
        '    MsgBox("Invalid Input")
        'Else
        '    If Label2.Text = "item1" Then
        '        attendance()
        '        If lis Is Nothing OrElse lis.IsDisposed Then
        '            lis = New Lists
        '        End If
        '        lis.Show()
        '    ElseIf Label2.Text = "item2" Then
        '        employee()
        If lis Is Nothing OrElse lis.IsDisposed Then
            lis = New Lists
        End If
        attend()
        lis.Show()
        'end if
        'End If
    End Sub

    Dim lis As New Lists

    Private Sub ReportsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class