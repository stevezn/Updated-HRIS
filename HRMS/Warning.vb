Imports System.IO
Imports word = Microsoft.Office.Interop.Word

Public Class Warning
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
            cmd.CommandText = "Select last_num FROM lastmemo4"
            lastn = DirectCast(cmd.ExecuteScalar(), Integer)
        Catch ex As Exception
        End Try
        Try
            Dim cmd = SQLConnection.CreateCommand
            cmd.CommandText = "Select MemoNo FROM db_warning ORDER BY MemoNo DESC LIMIT 1"
            lastcode = DirectCast(cmd.ExecuteScalar(), String)
        Catch ex As Exception
        End Try
        Try
            Dim cmd = SQLConnection.CreateCommand
            cmd.CommandText = "Select MID(MemoNo, 8, 1) FROM db_warning where MemoNo = '" & lastcode & "'"
            updmon = DirectCast(cmd.ExecuteScalar(), String)
            If CInt(updmon) <> CInt(mnow) Then
                tmp = 1
            Else
                tmp = lastn + 1
            End If
        Catch ex2 As Exception
        End Try
        Dim actualcode As String = "WRG-" & ynow & "-" & mnow & "-" & Strings.Right("0000" & tmp, 5)
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
        cmd.CommandText = "insert into db_warning" +
                          "(Memono, tgl, FullName, Employeecode, WarningLevel, OffenseType, DescriptionOfInfraction, Plan, Consequences, IsPenalty, PaymentDate, Amount)" +
                          "values(@Memono, @tgl, @names, @ec, @warninglevel, @offensetype, @descriptionofinfraction, @plan, @consequences, @ispenalty, @paymentdate, @amount)"
        cmd.Parameters.AddWithValue("@Memono", txtmemo.Text)
        cmd.Parameters.AddWithValue("@tgl", dtb.ToString("yyyy-MM-dd"))
        cmd.Parameters.AddWithValue("@names", TextBox3.Text)
        cmd.Parameters.AddWithValue("@ec", TextBox2.Text)
        cmd.Parameters.AddWithValue("@WarningLevel", ComboBox1.Text)
        cmd.Parameters.AddWithValue("@OffenseType", ComboBox2.Text)
        cmd.Parameters.AddWithValue("@descriptionofinfraction", RichTextBox1.Text)
        cmd.Parameters.AddWithValue("@plan", RichTextBox2.Text)
        cmd.Parameters.AddWithValue("@consequences", RichTextBox3.Text)
        cmd.Parameters.AddWithValue("@ispenalty", CheckEdit1.Checked)
        cmd.Parameters.AddWithValue("@paymentdate", dtr.ToString("yyyy-MM-dd"))
        cmd.Parameters.AddWithValue("@amount", TextBox4.Text)
        cmd.ExecuteNonQuery()
        TextBox3.Text = ""
        TextBox2.Text = ""
        txtmemo.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        RichTextBox1.Text = ""
        CheckEdit1.Checked = False
        RichTextBox2.Text = ""
        TextBox4.Text = ""
        RichTextBox3.Text = ""
        changer()
        MsgBox("Proccessed")
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

    Dim tbl_par7 As New DataTable

    Sub loaddept()
        Dim sqlcommand As MySqlCommand = SQLConnection.CreateCommand
        sqlcommand.CommandText = "select typeofoffense from db_offense"
        Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
        Dim cb As New MySqlCommandBuilder(adapter)
        adapter.Fill(tbl_par7)
        For index As Integer = 0 To tbl_par7.Rows.Count - 1
            ComboBox2.Properties.Items.Add(tbl_par7.Rows(index).Item(0).ToString())
        Next
    End Sub

    Private Sub Warning_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLConnection.ConnectionString = connectionstring
        SQLConnection.Open()
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "select employeecode from db_tmpname where 1 = 1"
        Dim quer As String = CType(query.ExecuteScalar, String)
        TextBox2.Text = quer.ToString

        query.CommandText = "select Name from db_tmpname where 1 =1"
        Dim quer1 As String = CType(query.ExecuteScalar, String)
        TextBox3.Text = quer1.ToString
        changer()
        autofill()
        loaddept()
    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit1.CheckedChanged
        If CheckEdit1.Checked = True Then
            DateTimePicker2.Enabled = True
            TextBox4.Enabled = True
        Else
            DateTimePicker2.Enabled = False
            TextBox4.Enabled = False
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
            TextBox2.Text = quer1.ToString

            query.CommandText = "select employeecode from db_tmpname"
            Dim quer2 As String = CType(query.ExecuteScalar, String)
            TextBox3.Text = quer2.ToString
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Timer1.Stop()
        Try
            Dim query As MySqlCommand = SQLConnection.CreateCommand
            query.CommandText = "select fullname from db_pegawai where employeecode = '" & TextBox2.Text & "'"
            TextBox3.Text = CStr(query.ExecuteScalar)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox2.Text = "" OrElse TextBox3.Text = "" OrElse ComboBox1.Text = "" Then
            MsgBox("Please fill the empty fields")
        Else
            save()
        End If
    End Sub

    Sub reprimand()
        Dim bs As MySqlCommand = SQLConnection.CreateCommand
        bs.CommandText = "select Employeecode from db_pegawai where EmployeeCode = '" & TextBox2.Text & "'"
        Dim employeecode As String = CStr(bs.ExecuteScalar)

        Dim pos As MySqlCommand = SQLConnection.CreateCommand
        pos.CommandText = "select FullName from db_pegawai where EmployeeCode = '" & TextBox2.Text & "'"
        Dim fullname As String = CStr(pos.ExecuteScalar)
        Dim objword As word.Application = Nothing
        Try
            objword = New word.Application
            'objword.Documents.Open("reprimand.docx")
            objword.Documents.Open(Application.StartupPath + "\\reprimand.docx")
            Dim findobject As word.Find = objword.Selection.Find
            With findobject
                .ClearFormatting()
                .Text = "<Name>"
                .Replacement.ClearFormatting()
                .Replacement.Text = fullname.ToString
                .Execute(Replace:=word.WdReplace.wdReplaceAll)
            End With
            With findobject
                .ClearFormatting()
                .Text = "<EmployeeCode>"
                .Replacement.ClearFormatting()
                .Replacement.Text = employeecode.ToString
                .Execute(Replace:=word.WdReplace.wdReplaceAll)
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Sub warn()
        Dim bs As MySqlCommand = SQLConnection.CreateCommand
        bs.CommandText = "select EmployeeCode from db_pegawai where employeecode = '" & TextBox2.Text & "'"
        Dim employeecode As String = CStr(bs.ExecuteScalar)

        Dim ps As MySqlCommand = SQLConnection.CreateCommand
        ps.CommandText = "select fullname from db_pegawai where employeecode = '" & TextBox2.Text & "'"
        Dim pos As String = CStr(ps.ExecuteScalar)
        Dim objword As word.Application = Nothing
        Try
            objword = New word.Application
            'objword.Documents.Open("reprimand.docx")
            objword.Documents.Open(Application.StartupPath + "\\reprimand.docx")
            Dim findobject As word.Find = objword.Selection.Find
            With findobject
                .ClearFormatting()
                .Text = "<Name>"
                .Replacement.ClearFormatting()
                .Replacement.Text = pos.ToString
                .Execute(Replace:=word.WdReplace.wdReplaceAll)
            End With
            With findobject
                .ClearFormatting()
                .Text = "<EmployeeCode>"
                .Replacement.ClearFormatting()
                .Replacement.Text = employeecode.ToString
                .Execute(Replace:=word.WdReplace.wdReplaceAll)
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        reprimand()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        warn()
    End Sub
End Class