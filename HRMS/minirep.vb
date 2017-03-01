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
        totalnew()
        totaltmnt()
    End Sub

    Sub totaltmnt()
        Dim terminat As MySqlCommand = SQLConnection.CreateCommand
        terminat.CommandText = "select count(*) from db_pegawai where status = 'terminate'"
        Dim restmnt As Integer = CInt(terminat.ExecuteScalar)
        Label4.Text = CType(restmnt, String)
    End Sub

    Sub totalnew()
        Dim newemp As MySqlCommand = SQLConnection.CreateCommand
        newemp.CommandText = "select count(*) from db_pegawai where MONTH(FROM_UNIXTIME(workdate))= MONTH(CURDATE())"
        Dim resnew As Integer = CInt(newemp.ExecuteScalar)
        Label5.Text = CType(resnew, String)
    End Sub
End Class