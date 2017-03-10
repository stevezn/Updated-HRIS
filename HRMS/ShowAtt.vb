Imports System.IO

Public Class ShowAtt
    Dim connectionString As String
    Dim SQLConnection As MySqlConnection = New MySqlConnection
    Dim oDt_sched As New DataTable()
    Dim host As String
    Dim id As String
    Dim password As String
    Dim db As String

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        If File.Exists("settinghost.txt") Then
            'My.Computer.FileSystem.DeleteFile("settinghost.txt")
            'File.Create("settinghost.txt").Dispose()
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

    Dim att As New Attendances

    Private Sub loadabsensi()
        Dim sqlcommand As New MySqlCommand
        sqlcommand.CommandText = "select a.EmployeeCode, a.FullName, a.Tanggal, a.Shift, Date_Format(a.JamMulai, '%H:%i:%s') as SignIn, DATE_FORMAT(a.JamSelesai, '%H:%i:%s') as SignOut, b.EmployeeType from db_absensi a, db_pegawai b where a.EmployeeCode = b.EmployeeCode and a.tanggal = @date1"
        Dim p1, p2 As New MySqlParameter
        p1.ParameterName = "@date1"
        p1.Value = DateTimePicker1.Value.Date
        sqlcommand.Parameters.Add(p1)
        sqlcommand.Connection = SQLConnection
        Dim dt As New DataTable
        dt.Load(sqlcommand.ExecuteReader)
        att.GridControl1.DataSource = dt
        Close()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If att Is Nothing OrElse att.IsDisposed OrElse att.MinimizeBox Then
            att.Close()
            att = New Attendances
        End If
        loadabsensi()
        att.Show()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Close()
    End Sub

    Private Sub ShowAtt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        Close()
    End Sub

    Private Sub DateTimePicker1_KeyDown(sender As Object, e As KeyEventArgs) Handles DateTimePicker1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If att Is Nothing OrElse att.IsDisposed OrElse att.MinimizeBox Then
                att.Close()
                att = New Attendances
            End If
            loadabsensi()
            att.Show()
        End If
    End Sub
End Class