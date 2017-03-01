Imports System.IO

Public Class Login
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

    Dim main As New MainApp

    Private Sub countButton_Click(sender As Object, e As EventArgs)
        Close()
    End Sub

    Public Sub koneksi()
        connectionString = "Server=" + host + "; User Id=" + id + "; Password=" + password + "; Database=" + db + ""
        SQLConnection.ConnectionString = connectionString
        Try
            SQLConnection.Open()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            SQLConnection.Close()
        End Try
        SQLConnection.Close()
    End Sub

    Dim bar As New ProgressBar

    'If File.Exists("settinghost.txt") Then
    '    My.Computer.FileSystem.DeleteFile("settinghost.txt")
    '    File.Create("settinghost.txt").Dispose()
    'End If
    'If File.Exists("settingid.txt") Then
    '    My.Computer.FileSystem.DeleteFile("settingid.txt")
    '    File.Create("settinghost.txt").Dispose()
    'End If
    'If File.Exists("settingpass.txt") Then
    '    My.Computer.FileSystem.DeleteFile("settingpass.txt")
    '    File.Create("settingpass.txt").Dispose()
    'End If
    'If File.Exists("settingdb.txt") Then
    '    My.Computer.FileSystem.DeleteFile("settingdb.txt")
    '    File.Create("settingdb.txt").Dispose()
    'End If
    'My.Computer.FileSystem.WriteAllText("settinghost.txt", txtserver.Text, True)
    'My.Computer.FileSystem.WriteAllText("settingid.txt", txtuser.Text, True)
    'My.Computer.FileSystem.WriteAllText("settingpass.txt", txtpass.Text, True)
    'My.Computer.FileSystem.WriteAllText("settingdb.txt", txtdb.Text, True)
    'End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs)
        Try
            Dim tbl_par As New DataTable
            Dim sqlCommand As New MySqlCommand
            sqlCommand.CommandText = "Select * FROM db_user WHERE username ='" + teUsername.Text + "' and password='" + tePassword.Text + "'"
            sqlCommand.Connection = SQLConnection
            Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(tbl_par)
            If tbl_par.Rows.Count > 0 Then
                main.Show()
                Hide()
            Else
                MessageBox.Show("Username and Password Didn't Match!")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Close()
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
    End Sub

    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click
        Dim tbl_par As New DataTable
        Dim sqlCommand As New MySqlCommand
        sqlCommand.CommandText = "Select * FROM db_user WHERE username ='" + teUsername.Text + "' and password='" + tePassword.Text + "'"
        sqlCommand.Connection = SQLConnection
        Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
        Dim cb As New MySqlCommandBuilder(adapter)
        adapter.Fill(tbl_par)
        If tbl_par.Rows.Count > 0 Then
            main.Show()
            Hide()
        Else
            MessageBox.Show("Username and Password Didn't Match!")
        End If
    End Sub

    Private Sub tePassword_Enter(sender As Object, e As EventArgs) Handles tePassword.Enter

    End Sub

    Private Sub tePassword_KeyDown(sender As Object, e As KeyEventArgs) Handles tePassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim tbl_par As New DataTable
            Dim sqlCommand As New MySqlCommand
            sqlCommand.CommandText = "Select * FROM db_user WHERE username ='" + teUsername.Text + "' and password='" + tePassword.Text + "'"
            sqlCommand.Connection = SQLConnection
            Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(tbl_par)
            If tbl_par.Rows.Count > 0 Then
                main.Show()
                Hide()
            Else
                MessageBox.Show("Username and Password Didn't Match!")
            End If
        End If
    End Sub
End Class