﻿Imports System.IO

Public Class StatusChange
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

    Private Sub CheckEdit2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit2.CheckedChanged
        If CheckEdit2.Checked = True Then
            CheckEdit3.Enabled = False
            CheckEdit3.Checked = False
            CheckEdit4.Enabled = False
            CheckEdit4.Checked = False
            ComboBoxEdit9.Enabled = False
            ComboBoxEdit9.Text = ""
        Else
            CheckEdit3.Enabled = True
            CheckEdit4.Enabled = True
            ComboBoxEdit9.Enabled = True
        End If
    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit1.CheckedChanged
        If CheckEdit1.Checked = True Then
            DateTimePicker2.Enabled = True
        Else
            DateTimePicker2.Enabled = False

        End If
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

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Dim query As MySqlCommand = SQLConnection.CreateCommand
            query.CommandText = "select name from db_tmpname"
            Dim quer1 As String = CType(query.ExecuteScalar, String)
            TextEdit1.Text = quer1.ToString

            query.CommandText = "select employeecode from db_tmpname"
            Dim quer2 As String = CType(query.ExecuteScalar, String)
            TextBox2.Text = quer2.ToString
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Timer1.Stop()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Try
            Dim query As MySqlCommand = SQLConnection.CreateCommand
            query.CommandText = "select employeecode from db_tmpname"
            Dim quer2 As String = CType(query.ExecuteScalar, String)
            TextBox3.Text = quer2.ToString
        Catch ex As Exception
        End Try
    End Sub

    Dim tbl_par2, tbl_par1 As New DataTable

    Sub loaddata1()
        Dim sqlcommand As MySqlCommand = SQLConnection.CreateCommand
        sqlcommand.CommandText = "SELECT departmentname from db_departmentmbp"
        Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
        Dim cb As New MySqlCommandBuilder(adapter)
        adapter.Fill(tbl_par2)
        For index As Integer = 0 To tbl_par2.Rows.Count - 1
            ComboBoxEdit5.Properties.Items.Add(tbl_par2.Rows(index).Item(0).ToString())
        Next
    End Sub

    Sub loaddata()
        Dim sqlcommand As MySqlCommand = SQLConnection.CreateCommand
        sqlcommand.CommandText = "select groupname from db_groupmbp"
        Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
        Dim cb As New MySqlCommandBuilder(adapter)
        adapter.Fill(tbl_par1)
        For index As Integer = 0 To tbl_par1.Rows.Count - 1
            ComboBoxEdit4.Properties.Items.Add(tbl_par1.Rows(index).Item(0).ToString())
        Next
    End Sub

    Sub calledx()
        If Label14.Text = "1" Then
            Dim query As MySqlCommand = SQLConnection.CreateCommand
            query.CommandText = "select * from db_statuschange where MemoNo = '" & txtmemo.Text & "'"
            Dim adapter As New MySqlDataAdapter(query.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(tbl_par3)
            For index As Integer = 0 To tbl_par3.Rows.Count - 1
            Next
        Else
            changer()
        End If
    End Sub

    Sub chng()
        For index As Integer = 0 To tbl_par3.Rows.Count - 1
            TextBox2.Text = tbl_par3.Rows(index).Item(2).ToString
            ComboBoxEdit1.Text = tbl_par3.Rows(index).Item(4).ToString
            ComboBoxEdit2.Text = tbl_par3.Rows(index).Item(5).ToString
            ComboBoxEdit3.Text = tbl_par3.Rows(index).Item(6).ToString
            ComboBoxEdit4.Text = tbl_par3.Rows(index).Item(8).ToString
            ComboBoxEdit5.Text = tbl_par3.Rows(index).Item(7).ToString
            TextBox3.Text = tbl_par3.Rows(index).Item(9).ToString
        Next
    End Sub

    Dim tbl_par3 As New DataTable

    Dim tbl_par6, tbl_par33, tbl_par4, tbl_par5, tbl_par7 As New DataTable

    Sub loadjob()
        Dim sqlcommand As MySqlCommand = SQLConnection.CreateCommand
        sqlcommand.CommandText = "select JobTitle from db_jobtitle"
        Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
        Dim cb As New MySqlCommandBuilder(adapter)
        adapter.Fill(tbl_par6)
        For index As Integer = 0 To tbl_par6.Rows.Count - 1
            ComboBoxEdit2.Properties.Items.Add(tbl_par6.Rows(index).Item(0).ToString())
        Next
    End Sub

    Sub loadofloc()
        Dim sqlcommand As MySqlCommand = SQLConnection.CreateCommand
        sqlcommand.CommandText = "select OfficeLocation from db_officelocation"
        Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
        Dim cb As New MySqlCommandBuilder(adapter)
        adapter.Fill(tbl_par4)
        For index As Integer = 0 To tbl_par4.Rows.Count - 1
            ComboBoxEdit3.Properties.Items.Add(tbl_par4.Rows(index).Item(0).ToString())
        Next
    End Sub

    Sub loadgroup()
        Dim sqlcommand As MySqlCommand = SQLConnection.CreateCommand
        sqlcommand.CommandText = "select groupname from db_groupmbp"
        Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
        Dim cb As New MySqlCommandBuilder(adapter)
        adapter.Fill(tbl_par5)
        For index As Integer = 0 To tbl_par5.Rows.Count - 1
            ComboBoxEdit4.Properties.Items.Add(tbl_par5.Rows(index).Item(0).ToString())
        Next
    End Sub

    Sub loaddept()
        Dim sqlcommand As MySqlCommand = SQLConnection.CreateCommand
        sqlcommand.CommandText = "select DepartmentName from db_departmentmbp"
        Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
        Dim cb As New MySqlCommandBuilder(adapter)
        adapter.Fill(tbl_par7)
        For index As Integer = 0 To tbl_par7.Rows.Count - 1
            ComboBoxEdit5.Properties.Items.Add(tbl_par7.Rows(index).Item(0).ToString())
        Next
    End Sub

    Private Sub StatusChange_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLConnection.ConnectionString = connectionstring
        SQLConnection.Open()
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "select employeecode from db_tmpname where 1 = 1"
        Dim quer As String = CType(query.ExecuteScalar, String)
        txtmemo.Text = quer.ToString
        TextBox2.Text = quer.ToString

        query.CommandText = "select Name from db_tmpname where 1 = 1"
        Dim quer1 As String = CType(query.ExecuteScalar, String)
        TextEdit1.Text = quer1.ToString

        query.CommandText = "select initial from db_tmpname"
        Dim quer3 As String = CStr(query.ExecuteScalar)
        Label14.Text = quer3.ToString

        'changer()
        loadjob()
        loadofloc()
        loaddept()
        loadgroup()
        loaddata1()
        loaddata()
        calledx()
        chng()
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        Timer2.Stop()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Timer2.Start()
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
            cmd.CommandText = "Select last_num FROM lastmemo5"
            lastn = DirectCast(cmd.ExecuteScalar(), Integer)
        Catch ex As Exception
        End Try
        Try
            Dim cmd = SQLConnection.CreateCommand
            cmd.CommandText = "Select MemoNo FROM db_statuschange ORDER BY MemoNo DESC LIMIT 1"
            lastcode = DirectCast(cmd.ExecuteScalar(), String)
        Catch ex As Exception
        End Try
        Try
            Dim cmd = SQLConnection.CreateCommand
            cmd.CommandText = "Select MID(MemoNo, 8, 1) FROM db_statuschange where MemoNo = '" & lastcode & "'"
            updmon = DirectCast(cmd.ExecuteScalar(), String)
            If CInt(updmon) <> CInt(mnow) Then
                tmp = 1
            Else
                tmp = lastn + 1
            End If
        Catch ex2 As Exception
        End Try
        Dim actualcode As String = "SCH-" & ynow & "-" & mnow & "-" & Strings.Right("0000" & tmp, 5)
        txtmemo.Text = actualcode.ToString
    End Sub

    Public Sub updation()
        Dim dtb, dta As Date
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy-MM-dd"
        dtb = DateTimePicker1.Value
        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.CustomFormat = "yyyy-MM-dd"
        dta = DateTimePicker2.Value
        Dim cmmd As MySqlCommand = SQLConnection.CreateCommand
        Try
            cmmd.CommandText = "update db_pegawai set Grouping = @grp, Department = @dept, Position = @pos, MaritalStatus = @MaritalStatus, PphStatus = @PphStatus, IsExpiry = @IsExpiry, ExpiryDates = @ExpiryDates, ApprovedBy = @ApprovedBy, ExcludePayroll = @ExcludePayroll, PayCash = @PayCash, ProcessTax = @ProcessTax, ExcludeThr = @ExcludeThr, ExcludeBonus = @ExcludeBonus, PrintSlip = @PrintSlip, PayrollInterval = @PayrollInterval, JobDesks = @JobDesks where EmployeeCode = @ec"
            cmmd.Parameters.AddWithValue("@grp", ComboBoxEdit4.Text)
            cmmd.Parameters.AddWithValue("@dept", ComboBoxEdit5.Text)
            cmmd.Parameters.AddWithValue("@pos", ComboBoxEdit2.Text)
            cmmd.Parameters.AddWithValue("@ec", TextBox2.Text)
            cmmd.Parameters.AddWithValue("@MaritalStatus", ComboBoxEdit6.Text)
            cmmd.Parameters.AddWithValue("@PphStatus", ComboBoxEdit7.Text)
            cmmd.Parameters.AddWithValue("@IsExpiry", CheckEdit1.Checked)
            cmmd.Parameters.AddWithValue("@ExpiryDates", dta.ToString("yyyy-MM-dd"))
            cmmd.Parameters.AddWithValue("@ApprovedBy", TextBox3.Text)
            cmmd.Parameters.AddWithValue("@ExcludePayroll", CheckEdit2.Checked)
            cmmd.Parameters.AddWithValue("@PayCash", CheckEdit3.Checked)
            cmmd.Parameters.AddWithValue("@ProcessTax", CheckEdit4.Checked)
            cmmd.Parameters.AddWithValue("@ExcludeThr", CheckEdit5.Checked)
            cmmd.Parameters.AddWithValue("@ExcludeBonus", CheckEdit6.Checked)
            cmmd.Parameters.AddWithValue("@PrintSlip", CheckEdit7.Checked)
            cmmd.Parameters.AddWithValue("@PayrollInterval", ComboBoxEdit9.Text)
            cmmd.Parameters.AddWithValue("@JobDesks", RichTextBox2.Text)
            cmmd.ExecuteNonQuery()
            MsgBox("Changed")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub insertion()
        Dim dtb As Date
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy-MM-dd"
        dtb = DateTimePicker1.Value
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        Try
            query.CommandText = "insert into db_statuschange" +
                     "(MemoNo, FullName, EmployeeCode, tgl, ChangeType, JobTitle, OfficeLocation, Department, Grouping, Status)" +
                     "values (@MemoNo, @FullName, @EmployeeCode, @tgl, @ChangeType, @JobTitle, @OfficeLocation, @Department, @Grouped, @stats)"
            query.Parameters.AddWithValue("@MemoNo", txtmemo.Text)
            query.Parameters.AddWithValue("@FullName", TextBox2.Text)
            query.Parameters.AddWithValue("@EmployeeCode", TextEdit1.Text)
            query.Parameters.AddWithValue("@tgl", dtb.ToString("yyyy-MM-dd"))
            query.Parameters.AddWithValue("@ChangeType", ComboBoxEdit1.Text)
            query.Parameters.AddWithValue("@JobTitle", ComboBoxEdit2.Text)
            query.Parameters.AddWithValue("@OfficeLocation", ComboBoxEdit3.Text)
            query.Parameters.AddWithValue("@Department", ComboBoxEdit5.Text)
            query.Parameters.AddWithValue("@Grouped", ComboBoxEdit4.Text)
            query.Parameters.AddWithValue("@stats", "Requested")
            query.ExecuteNonQuery()
            MsgBox("Requested!")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        insertion()
        'updation()
    End Sub
End Class