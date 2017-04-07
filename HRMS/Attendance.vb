Imports System.IO

Public Class Attendance
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

    Sub names()
        Dim name As MySqlCommand = SQLConnection.CreateCommand
        name.CommandText = "select name from db_tmpname"
        Dim realn As String = CStr(name.ExecuteScalar)
        TextEdit2.Text = realn
    End Sub

    Sub ec()
        Dim ec As MySqlCommand = SQLConnection.CreateCommand
        ec.CommandText = "select employeecode from db_tmpname"
        Dim realec As String = CStr(ec.ExecuteScalar)
        TextEdit1.Text = realec
    End Sub

    Private Sub Attendance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        names()
        ec()
        days()
    End Sub

    Dim emp As selectemp

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If emp Is Nothing OrElse emp.IsDisposed OrElse emp.MinimizeBox Then
            emp = New selectemp
        End If
        emp.Show()
        Close()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If ComboBoxEdit1.Text = "" Or RichTextBox1.Text = "" Then
            MsgBox("Please fill reason field")
        ElseIf DateTimePicker1.Value.Date > DateTimePicker2.Value.Date Then
            MsgBox("Total days can't be minus")
        Else
            save()
        End If
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        If emp Is Nothing OrElse emp.IsDisposed OrElse emp.MinimizeBox Then
            emp = New selectemp
        End If
        emp.Show()
        Close()
    End Sub

    Sub save()
        Dim dtb, dtr As DateTime
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy-MM-dd"
        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.CustomFormat = "yyyy-MM-dd"
        dtr = DateTimePicker2.Value
        dtb = DateTimePicker1.Value
        Dim cmd As MySqlCommand = SQLConnection.CreateCommand
        cmd.CommandText = "insert into db_attrec" +
                          "(Employeecode, Reason, StartDate, EndDate, TotalDays, Ket)" +
                          "values(@ec, @reason, @sd, @ed, @TotalDays, @ket)"
        cmd.Parameters.AddWithValue("@ec", TextEdit1.Text)
        cmd.Parameters.AddWithValue("@reason", ComboBoxEdit1.Text)
        cmd.Parameters.AddWithValue("@@sd", dtb.ToString("yyyy-MM-dd"))
        cmd.Parameters.AddWithValue("@ed", dtr.ToString("yyyy-MM-dd"))
        cmd.Parameters.AddWithValue("@TotalDays", Label5.Text)
        cmd.Parameters.AddWithValue("@ket", RichTextBox1.Text)
        cmd.ExecuteNonQuery()
        MsgBox("Proccessed")
    End Sub

    Sub days()
        Dim t As TimeSpan = DateTimePicker2.Value.Date - DateTimePicker1.Value.Date
        Dim tmp As String
        tmp = t.Days.ToString
        Dim hasil As Integer
        hasil = CInt(tmp)
        Dim hasil2 As Integer = hasil
        Label5.Text = hasil2.ToString
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        days()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        days()
    End Sub
End Class