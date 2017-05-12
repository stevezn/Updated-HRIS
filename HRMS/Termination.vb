﻿Imports System.IO
Public Class Termination
    Dim connectionstring As String
    Dim SQLConnection As MySqlConnection = New MySqlConnection

    Public Sub New()
        InitializeComponent()
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
        connectionstring = "Server=" + host + "; User Id=" + id + "; Password=" + password + "; Database=" + db + ""
    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit1.CheckedChanged
        If CheckEdit1.Checked = True Then
            DateTimePicker2.Enabled = True
        Else
            DateTimePicker2.Enabled = False
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Dim query As MySqlCommand = SQLConnection.CreateCommand
            query.CommandText = "select name from db_tmpname"
            Dim quer1 As String = CType(query.ExecuteScalar, String)
            TextBox2.Text = quer1.ToString

            query.CommandText = "select employeecode from db_tmpname"
            Dim quer2 As String = CType(query.ExecuteScalar, String)
            TextEdit1.Text = quer2.ToString

            query.CommandText = "select Jobtitle from db_tmpname"
            Dim quer3 As String = CType(query.ExecuteScalar, String)
            TextBox6.Text = quer3.ToString

            query.CommandText = "select Status from db_tmpname"
            Dim quer4 As String = CType(query.ExecuteScalar, String)
            TextBox7.Text = quer4.ToString
        Catch ex As Exception
        End Try
    End Sub

    Sub changer()
        Dim maxid As Integer
        Dim newid As Integer = maxid + 1
        Dim ynow As String = Format(Now, "yy").ToString
        Dim mnow As String = Month(Now).ToString
        Dim lastn As Integer
        Dim updmon As String
        Dim lastcode As String = ""
        Dim tmp As Integer
        Dim cd As MySqlCommand = SQLConnection.CreateCommand
        Try
            Dim cmd = SQLConnection.CreateCommand()
            cmd.CommandText = "Select last_num FROM lastmemo3"
            lastn = DirectCast(cmd.ExecuteScalar(), Integer)
        Catch ex As Exception
        End Try
        Try
            Dim cmd = SQLConnection.CreateCommand
            cmd.CommandText = "Select MemoNo FROM db_terminate ORDER BY MemoNo DESC LIMIT 1"
            lastcode = DirectCast(cmd.ExecuteScalar(), String)
        Catch ex As Exception
        End Try
        Try
            Dim cmd = SQLConnection.CreateCommand
            cmd.CommandText = "Select MID(MemoNo, 8, 1) FROM db_terminate where MemoNo = '" & lastcode & "'"
            updmon = DirectCast(cmd.ExecuteScalar(), String)
            If CInt(updmon) <> CInt(mnow) Then
                tmp = 1
            Else
                tmp = lastn + 1
            End If
        Catch ex2 As Exception
        End Try
        Dim actualcode As String = "TMT-" & ynow & "-" & mnow & "-" & Strings.Right("0000" & tmp, 5)
        txtmemo.Text = actualcode.ToString
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
        cmd.CommandText = "insert into db_terminate" +
                          "(Memono, tgl, FullName, Employeecode, ApprovedBy, AppEmployeeCode, Blacklist, Reason, JobTitle, Status, Allowance, AllowanceTax, IsPay, PaymentDate, Explanation, ApprovedStatus, AllowanceResult)" +
                          "values(@Memono, @tgl, @names, @ec, @ApprovedBy, @AppEmployeeCode, @Blacklist, @Reason, @JobTitle, @Status, @Allowance, @AllowanceTax, @IsPay, @PaymentDate, @Explanation, @apps, @AllowanceResult)"
        cmd.Parameters.AddWithValue("@Memono", txtmemo.Text)
        cmd.Parameters.AddWithValue("@tgl", dtb.ToString("yyyy-MM-dd"))
        cmd.Parameters.AddWithValue("@names", TextEdit1.Text)
        cmd.Parameters.AddWithValue("@ec", TextBox2.Text)
        cmd.Parameters.AddWithValue("@ApprovedBy", "")
        cmd.Parameters.AddWithValue("@AppEmployeeCode", TextEdit2.Text)
        cmd.Parameters.AddWithValue("@Blacklist", CheckEdit2.Checked)
        cmd.Parameters.AddWithValue("@Reason", ComboBoxEdit1.Text)
        cmd.Parameters.AddWithValue("@JobTitle", TextBox6.Text)
        cmd.Parameters.AddWithValue("@Status", TextBox7.Text)
        cmd.Parameters.AddWithValue("@Allowance", TextBox4.Text)
        cmd.Parameters.AddWithValue("@AllowanceTax", TextBox5.Text)
        cmd.Parameters.AddWithValue("@Ispay", CheckEdit1.Checked)
        cmd.Parameters.AddWithValue("@PaymentDate", dtr.ToString("yyyy-MM-dd"))
        cmd.Parameters.AddWithValue("@Explanation", RichTextBox1.Text)
        cmd.Parameters.AddWithValue("@apps", "Requested")
        cmd.Parameters.AddWithValue("@AllowanceResult", TextBox1.Text)
        cmd.ExecuteNonQuery()
        'cmd.CommandText = "update db_pegawai set status = 'Terminate' where employeecode = @emp"
        'cmd.Parameters.Clear()
        'cmd.Parameters.AddWithValue("@emp", TextEdit1.Text)
        'cmd.ExecuteNonQuery()
        'Dim query As MySqlCommand = SQLConnection.CreateCommand
        'query.CommandText = "select idnumber from db_pegawai where employeecode = @emp"
        'query.Parameters.AddWithValue("@emp", TextEdit1.Text)
        'Dim hsl As String = CStr(query.ExecuteScalar)
        'query.CommandText = "update db_recruitment set blacklist = @check where idnumber = @id"
        'query.Parameters.Clear()
        'query.Parameters.AddWithValue("@check", CheckEdit2.Checked)
        'query.Parameters.AddWithValue("@id", hsl)
        'query.ExecuteNonQuery()
        TextBox3.Text = ""
        TextBox2.Text = ""
        TextEdit1.Text = ""
        TextEdit2.Text = ""
        TextBox7.Text = ""
        CheckEdit1.Checked = False
        CheckEdit2.Checked = False
        txtmemo.Text = ""
        ComboBoxEdit1.Text = ""
        TextBox4.Text = ""
        RichTextBox1.Text = ""
        TextBox1.Text = ""
        changer()
        MsgBox("Requested")
    End Sub

    Private Sub Termination_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLConnection.ConnectionString = connectionstring
        SQLConnection.Open()
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "select employeecode from db_tmpname where 1 = 1"
        Dim quer As String = CType(query.ExecuteScalar, String)
        TextBox2.Text = quer.ToString

        query.CommandText = "select Name from db_tmpname where 1 = 1"
        Dim quer1 As String = CType(query.ExecuteScalar, String)
        TextEdit1.Text = quer1.ToString
        Try
            query.CommandText = "select position from db_pegawai where employeecode = '" & TextBox2.Text & "'"
            TextBox6.Text = CStr(query.ExecuteScalar)
            query.CommandText = "select status from db_pegawai where employeecode = '" & TextBox2.Text & "'"
            TextBox7.Text = CStr(query.ExecuteScalar)
        Catch ex As Exception
        End Try

        ''query.CommandText = "select Jobtitle from db_tmpname where 1 = 1"
        ''Dim quer2 As String = CType(query.ExecuteScalar, String)
        ''TextBox6.Text = quer2.ToString

        ''query.CommandText = "select Status from db_tmpname where 1 = 1"
        ''Dim quer3 As String = CType(query.ExecuteScalar, String)
        ''TextBox7.Text = quer3.ToString
        changer()
        autofill()
    End Sub

    Sub autofill()
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim da As New MySqlDataAdapter("select EmployeeCode from db_pegawai", SQLConnection)
        da.Fill(dt)
        Dim r As DataRow
        TextBox2.AutoCompleteCustomSource.Clear()
        For Each r In dt.Rows
            TextBox2.AutoCompleteCustomSource.Add(r.Item(0).ToString)
        Next
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Timer1.Stop()
        Try
            Dim query As MySqlCommand = SQLConnection.CreateCommand
            query.CommandText = "select position from db_pegawai where employeecode = '" & TextBox2.Text & "'"
            TextBox6.Text = CStr(query.ExecuteScalar)
            query.CommandText = "select status from db_pegawai where employeecode = '" & TextBox2.Text & "'"
            TextBox7.Text = CStr(query.ExecuteScalar)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        Timer2.Stop()
    End Sub

    Dim sel As New selectemp

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Timer1.Start()
        If sel Is Nothing OrElse sel.IsDisposed OrElse sel.MinimizeBox Then
            sel.Close()
            sel = New selectemp
        End If
        sel.Show()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Timer2.Start()
        If sel Is Nothing OrElse sel.IsDisposed OrElse sel.MinimizeBox Then
            sel.Close()
            sel = New selectemp
        End If
        sel.Show()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Try
            Dim query As MySqlCommand = SQLConnection.CreateCommand
            query.CommandText = "select name from db_tmpname"
            Dim quer1 As String = CType(query.ExecuteScalar, String)
            TextEdit2.Text = quer1.ToString

            query.CommandText = "select employeecode from db_tmpname"
            Dim quer2 As String = CType(query.ExecuteScalar, String)
            TextBox3.Text = quer2.ToString
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBoxEdit1.Text = "" OrElse RichTextBox1.Text = "" Then
            MsgBox("Please fill the empty fields")
        ElseIf TextEdit1.Text = TextEdit2.Text Then
            MsgBox("The identity can't be same!")
        Else
            save()
        End If
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        Dim ch As Char = e.KeyChar
        If Char.IsLetter(ch) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        Dim ch As Char = e.KeyChar
        If Char.IsLetter(ch) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        Try
            Dim a, b, c, d As Integer
            a = Convert.ToInt32(TextBox4.Text)
            b = Convert.ToInt32(TextBox5.Text)
            c = CInt(a * b / 100)
            d = a - c
            TextBox1.Text = d.ToString
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        Try
            Dim a, b, c, d As Integer
            a = Convert.ToInt32(TextBox4.Text)
            b = Convert.ToInt32(TextBox5.Text)
            c = CInt(a * b / 100)
            d = a - c
            TextBox1.Text = d.ToString
        Catch ex As Exception
        End Try
    End Sub
End Class