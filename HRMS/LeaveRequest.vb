﻿Imports System.IO
Public Class LeaveRequest

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

    Dim sel As New selectemp

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Timer1.Start()
        If sel Is Nothing OrElse sel.IsDisposed OrElse sel.MinimizeBox Then
            sel.Close()
            sel = New selectemp
        End If
        sel.Show()
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
            cmd.CommandText = "SELECT last_num FROM lastmemo2"
            lastn = DirectCast(cmd.ExecuteScalar(), Integer)
        Catch ex As Exception
        End Try
        Try
            Dim cmd = SQLConnection.CreateCommand
            cmd.CommandText = "SELECT MemoNo FROM db_attrec ORDER BY MemoNo DESC LIMIT 1"
            lastcode = DirectCast(cmd.ExecuteScalar(), String)
        Catch ex As Exception
        End Try
        Try
            Dim cmd = SQLConnection.CreateCommand
            cmd.CommandText = "SELECT MID(MemoNo, 8, 1) FROM db_attrec where MemoNo = '" & lastcode & "'"
            updmon = DirectCast(cmd.ExecuteScalar(), String)
            If CInt(updmon) <> CInt(mnow) Then
                tmp = 1
            Else
                tmp = lastn + 1
            End If
        Catch ex2 As Exception
        End Try
        Dim actualcode As String = "Memo" & ynow & "-" & mnow & "-" & Strings.Right("0000" & tmp, 5)
        txtmemo.Text = actualcode.ToString
    End Sub

    Private Sub LeaveRequest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
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

    Sub days()
        Dim t As TimeSpan = DateTimePicker3.Value.Date - DateTimePicker2.Value.Date
        Dim tmp As String
        tmp = t.Days.ToString
        Dim hasil As Integer
        hasil = CInt(tmp)
        Dim hasil2 As Integer = hasil
        TextBox4.Text = hasil2.ToString
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Dim query As MySqlCommand = SQLConnection.CreateCommand
            query.CommandText = "select name from db_tmpname"
            Dim quer1 As String = CType(query.ExecuteScalar, String)
            TextBox2.Text = quer1.ToString

            query.CommandText = "select employeecode from db_tmpname"
            Dim quer2 As String = CType(query.ExecuteScalar, String)
            TextBox3.Text = quer2.ToString
        Catch ex As Exception
        End Try
    End Sub

    Sub holiday()
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "select a.tgl, b.tgl from db_holiday a, db_attrec b where a.tgl = b.tgl"
        Dim hasil As MySqlDataReader = query.ExecuteReader()

    End Sub

    Sub insertlists()
        Dim dtb, dtr, dts As DateTime
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy-MM-dd"
        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.CustomFormat = "yyyy-MM-dd"
        DateTimePicker3.Format = DateTimePickerFormat.Custom
        DateTimePicker3.CustomFormat = "yyyy-MM-dd"
        dtr = DateTimePicker2.Value
        dtb = DateTimePicker1.Value
        dts = DateTimePicker3.Value
        Dim d1 As Date = DateTimePicker2.Value.Date
        Dim d2 As Date = DateTimePicker3.Value.Date

        For j As Integer = 1 To DateDiff("d", d1, d2)
            d1 = d1.AddDays(1)
            Dim cmd As MySqlCommand = SQLConnection.CreateCommand
            cmd.CommandText = "insert into db_attreclist" +
                          "(Memono, tgl, FullName, Employeecode, Reason)" +
                          "values(@Memono, @tgl, @names, @ec, @reason)"
            cmd.Parameters.AddWithValue("@Memono", txtmemo.Text)
            cmd.Parameters.AddWithValue("@tgl", d1.ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@names", TextBox2.Text)
            cmd.Parameters.AddWithValue("@ec", TextBox3.Text)
            cmd.Parameters.AddWithValue("@reason", ComboBox1.Text)
            cmd.ExecuteNonQuery()
        Next
        'TextBox3.Text = ""
        'TextBox2.Text = ""
        'txtmemo.Text = ""
        'ComboBox1.Text = ""
        'TextBox4.Text = ""
        'RichTextBox1.Text = ""
        'changer()
    End Sub

    Sub save()
        Dim dtb, dtr, dts As DateTime
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy-MM-dd"
        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.CustomFormat = "yyyy-MM-dd"
        DateTimePicker3.Format = DateTimePickerFormat.Custom
        DateTimePicker3.CustomFormat = "yyyy-MM-dd"
        dtr = DateTimePicker2.Value
        dtb = DateTimePicker1.Value
        dts = DateTimePicker3.Value
        insertlists()
        Dim cmd1 As MySqlCommand = SQLConnection.CreateCommand
        cmd1.CommandType = CommandType.StoredProcedure
        cmd1.CommandText = "rangedate"
        cmd1.Parameters.AddWithValue("@date1", DateTimePicker2.Value.Date)
        cmd1.Parameters.AddWithValue("@date2", DateTimePicker3.Value.Date)
        Dim adp As New MySqlDataAdapter(cmd1)
        Dim ds1 As New DataSet
        adp.Fill(ds1)
        Dim cmd As MySqlCommand = SQLConnection.CreateCommand
        cmd.CommandText = "insert into db_attrec" +
                          "(Memono, tgl, FullName, Employeecode, Reason, StartDate, EndDate, TotalDays, Ket, ApprovedStatus)" +
                          "values(@Memono, @tgl, @names, @ec, @reason, @sd, @ed, @TotalDays, @ket, @stats)"
        cmd.Parameters.AddWithValue("@Memono", txtmemo.Text)
        cmd.Parameters.AddWithValue("@tgl", dtr.ToString("yyyy-MM-dd"))
        cmd.Parameters.AddWithValue("@names", TextBox2.Text)
        cmd.Parameters.AddWithValue("@ec", TextBox3.Text)
        cmd.Parameters.AddWithValue("@reason", ComboBox1.Text)
        cmd.Parameters.AddWithValue("@@sd", dtr.ToString("yyyy-MM-dd"))
        cmd.Parameters.AddWithValue("@ed", dts.ToString("yyyy-MM-dd"))
        cmd.Parameters.AddWithValue("@TotalDays", TextBox4.Text)
        cmd.Parameters.AddWithValue("@ket", RichTextBox1.Text)
        cmd.Parameters.AddWithValue("@stats", "Requested")
        cmd.ExecuteNonQuery()
        MsgBox("Requested")
        '    Next
        ' 
        'TextBox3.Text = ""
        'TextBox2.Text = ""
        'txtmemo.Text = ""
        'ComboBox1.Text = ""
        'TextBox4.Text = ""
        'RichTextBox1.Text = ""
        'changer()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Timer1.Stop()
        Try
            Dim query As MySqlCommand = SQLConnection.CreateCommand
            query.CommandText = "select fullname from db_pegawai where employeecode = '" & TextBox2.Text & "'"
            Dim quer As String = CStr(query.ExecuteScalar)
            TextBox3.Text = quer.ToString
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        days()
    End Sub

    Private Sub DateTimePicker3_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker3.ValueChanged
        days()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text = "" Or RichTextBox1.Text = "" OrElse TextBox3.Text = "" Then
            MsgBox("Please fill reason field")
        ElseIf DateTimePicker1.Value.Date > DateTimePicker2.Value.Date Then
            MsgBox("Total days can't be minus")
        Else
            save()
        End If
    End Sub
End Class