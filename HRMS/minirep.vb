Imports System.IO

Public Class minirep
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

    Private Sub minirep_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        totaltmnt()
    End Sub


    Sub newemp()
        Dim newemp As MySqlCommand = SQLConnection.CreateCommand
        newemp.CommandText = "select count(*) from db_pegawai where month(from_unixtime(workdate)) = month(curdate())"
        Dim newe As Integer = CInt(newemp.ExecuteScalar)
        Label4.Text = newe.ToString
    End Sub

    Sub emp()
        Dim emp As MySqlCommand = SQLConnection.CreateCommand
        emp.CommandText = "select count(*) from db_pegawai where month(workdate()) = month(curdate())"
        Dim emp1 As Integer = CInt(emp.ExecuteScalar)
    End Sub

    Sub totaltmnt()
        Dim terminat As MySqlCommand = SQLConnection.CreateCommand
        terminat.CommandText = "select count(*) from db_pegawai where status = 'Terminated'"
        Dim restmnt As Integer = CInt(terminat.ExecuteScalar)
        Label5.Text = CType(restmnt, String)
    End Sub
End Class