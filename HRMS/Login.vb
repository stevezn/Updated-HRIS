Imports System.IO
Imports System.Windows.Controls

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
        'If Not AutomaticUpdater1.ClosingForInstall Then
        '    ' load important files, etc.
        '    ' LoadFilesEtc()
        'End If

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

    Dim main As New MainApp
    Dim cir As New Circle

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
    Dim tile As New Tile_Control

    Private Sub btnLogin_Click(sender As Object, e As EventArgs)
        Try
            Dim tbl_par As New DataTable
            Dim sqlCommand As New MySqlCommand
            sqlCommand.CommandText = "Select * FROM db_user WHERE Binary username ='" + teUsername.Text + "' and Binary password='" + tePassword.Text + "'"
            sqlCommand.Connection = SQLConnection
            Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(tbl_par)
            If tbl_par.Rows.Count > 0 Then
                tile.Show()
                Hide()
            Else
                MessageBox.Show("Username and Password Didn't Match!")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub user()
        Dim use As MySqlCommand = SQLConnection.CreateCommand
        use.CommandText = "INSERT INTO db_temp " +
                           "(User) " +
                            "values (@User) "
        use.Parameters.AddWithValue("@User", teUsername.Text)
        use.ExecuteNonQuery()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        Close()
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        AutomaticUpdater1.Show()
        Me.AutoSizeMode = AutoSizeMode.GrowAndShrink
        CheckForUpdatesToolStripMenuItem.PerformClick()
    End Sub

    Public Sub CheckForUpdates()
        Try
            Timer1.Enabled = False
            ProgressBar1.Visible = True
            WebBrowser1.Visible = False
            Dim request As Net.HttpWebRequest = CType(Net.WebRequest.Create("https://dl.dropbox.com/s/f3hbcpzffkdg5y0/version.txt?dl=0"), Net.HttpWebRequest)
            Dim response As Net.HttpWebResponse = CType(request.GetResponse(), Net.HttpWebResponse)
            Dim sr As StreamReader = New StreamReader(response.GetResponseStream())
            Dim newestversion As String = sr.ReadToEnd()
            Dim currentversion As String = Application.ProductVersion
            If newestversion.Contains(currentversion) Then
                Timer1.Enabled = True
            Else
                Dim mess As String
                mess = CType(MsgBox("There's a new update, Update ?", MsgBoxStyle.YesNo, "Information"), String)
                If CType(mess, Global.Microsoft.VisualBasic.MsgBoxResult) = vbYes Then
                    WebBrowser1.Navigate("https://dl.dropbox.com/s/axtsp9oq8pez6u6/HRIS.exe?dl=0")
                Else
                    Timer1.Enabled = True
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click
        Try
            Dim tbl_par As New DataTable
            Dim sqlCommand As New MySqlCommand
            sqlCommand.CommandText = "Select * FROM db_user WHERE BINARY username ='" + teUsername.Text + "' and BINARY password='" + tePassword.Text + "'"
            sqlCommand.Connection = SQLConnection
            Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(tbl_par)
            If tbl_par.Rows.Count > 0 Then
                ProgressBar1.Visible = True
                Timer1.Enabled = True
                user()
            Else
                MessageBox.Show("Username and Password Didn't Match!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub tePassword_KeyDown(sender As Object, e As KeyEventArgs) Handles tePassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                Dim tbl_par As New DataTable
                Dim sqlCommand As New MySqlCommand
                sqlCommand.CommandText = "Select * FROM db_user WHERE BINARY username ='" + teUsername.Text + "' and BINARY password='" + tePassword.Text + "'"
                sqlCommand.Connection = SQLConnection
                Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
                Dim cb As New MySqlCommandBuilder(adapter)
                adapter.Fill(tbl_par)
                If tbl_par.Rows.Count > 0 Then
                    ProgressBar1.Visible = True
                    Timer1.Enabled = True
                    user()
                Else
                    MessageBox.Show("Username and Password Didn't Match!")
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            teUsername.Enabled = False
            tePassword.Enabled = False
            If ProgressBar1.Value < 100 Then
                ProgressBar1.Value += 10
            ElseIf ProgressBar1.Value = 100 Then
                Timer1.Stop()
                Dim tbl_par As New DataTable
                Dim sqlCommand As New MySqlCommand
                sqlCommand.CommandText = "Select * FROM db_user WHERE BINARY username ='" + teUsername.Text + "' and BINARY password='" + tePassword.Text + "'"
                sqlCommand.Connection = SQLConnection
                Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
                Dim cb As New MySqlCommandBuilder(adapter)
                adapter.Fill(tbl_par)
                If tbl_par.Rows.Count > 0 Then
                    tile.Show()
                    Hide()
                Else
                    MsgBox("Username and Password Didn't Match!")
                End If
                Timer1.Stop()
            End If
            If ProgressBar1.Value = 10 Then
                Label1.Text = "Preparing"
            ElseIf ProgressBar1.Value = 50 Then
                Label1.Text = "Initializing"
            ElseIf ProgressBar1.Value = 60 Then
                CheckForUpdates()
            ElseIf ProgressBar1.Value = 96 Then
                Label1.Text = "Ready"
            ElseIf ProgressBar1.Value = 97 Then
                Label1.Text = "Ready."
            ElseIf ProgressBar1.Value = 98 Then
                Label1.Text = "Ready.."
            ElseIf ProgressBar1.Value = 99 Then
                Label1.Text = "Ready..."
            ElseIf ProgressBar1.Value = 100 Then
                Label1.Text = "Ready...."
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub AutomaticUpdater1_ClosingAborted(sender As Object, e As EventArgs) Handles AutomaticUpdater1.ClosingAborted
        'your app was preparing to close
        ' however the update wasn't ready so your app is going to show itself
        'LoadFilesEtc()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub teUsername_KeyDown(sender As Object, e As KeyEventArgs) Handles teUsername.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                Dim tbl_par As New DataTable
                Dim sqlCommand As New MySqlCommand
                sqlCommand.CommandText = "Select * FROM db_user WHERE BINARY username ='" + teUsername.Text + "' and BINARY password='" + tePassword.Text + "'"
                sqlCommand.Connection = SQLConnection
                Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
                Dim cb As New MySqlCommandBuilder(adapter)
                adapter.Fill(tbl_par)
                If tbl_par.Rows.Count > 0 Then
                    ProgressBar1.Visible = True
                    Timer1.Enabled = True
                    user()
                Else
                    MessageBox.Show("Username and Password Didn't Match!")
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Close()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class