Imports System.IO
Imports System.Runtime.InteropServices
Imports word = Microsoft.Office.Interop.Word

Public Class Payslip
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
        'connectionString = "Server=" + host + "; User Id=root; Password=; Database=db_hris"
        connectionString = "Server=" + host + "; User Id=" + id + "; Password=" + password + "; Database=" + db + ""
    End Sub
    Sub loaddata()
        SQLConnection = New MySqlConnection
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        Dim sqlcommand As New MySqlCommand
        sqlcommand.CommandText = "SELECT EmployeeCode, FullName From db_payrolldata"
        sqlcommand.Connection = SQLConnection
        Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
        Dim cb As New MySqlCommandBuilder(adapter)
        adapter.Fill(tbl_par)
        For index As Integer = 0 To tbl_par.Rows.Count - 1
            txtname.Properties.Items.Add(tbl_par.Rows(index).Item(1).ToString())
        Next
        SQLConnection.Close()
    End Sub

    Private Sub ComboBoxEdit1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtname.SelectedIndexChanged
        For index As Integer = 0 To tbl_par.Rows.Count - 1
            If txtname.SelectedItem Is tbl_par.Rows(index).Item(1).ToString Then
                txtempcode.Text = tbl_par.Rows(index).Item(0).ToString
            End If
        Next
    End Sub

    Private Sub payrollslip()
        SQLConnection = New MySqlConnection
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        Dim bs As MySqlCommand = SQLConnection.CreateCommand
        bs.CommandText = "select basicrate from db_payrolldata where EmployeeCode = '" & txtempcode.Text & "'"
        Dim salary As String = CStr(bs.ExecuteScalar)

        Dim pos As MySqlCommand = SQLConnection.CreateCommand
        pos.CommandText = "select position from db_pegawai where EmployeeCode = '" & txtempcode.Text & "'"
        Dim position As String = CStr(pos.ExecuteScalar)

        Dim objword As word.Application = Nothing
        Try
            objword = New word.Application
            objword.Documents.Open("E:\Backup\payrollreports.docx")
            Dim findobject As word.Find = objword.Selection.Find
            With findobject
                .ClearFormatting()
                .Text = "Name"
                .Replacement.ClearFormatting()
                .Replacement.Text = txtname.Text
                .Execute(Replace:=word.WdReplace.wdReplaceAll)
            End With
            With findobject
                .ClearFormatting()
                .Text = "EmployeeCode"
                .Replacement.ClearFormatting()
                .Replacement.Text = txtempcode.Text
                .Execute(Replace:=word.WdReplace.wdReplaceAll)
            End With
            With findobject
                .ClearFormatting()
                .Text = "Gapok"
                .Replacement.ClearFormatting()
                .Replacement.Text = salary
                .Execute(Replace:=word.WdReplace.wdReplaceAll)
            End With
            With findobject
                .ClearFormatting()
                .Text = "Position"
                .Replacement.Text = position
                .Execute(Replace:=word.WdReplace.wdReplaceAll)
            End With
            With findobject
                .ClearFormatting()
                .Text = "Periode"
                .Replacement.Text = CType(txtperiod.Value, String)
                .Execute(Replace:=word.WdReplace.wdReplaceAll)
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Payslip_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaddata()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        payrollslip()
        'If txtperiod.Text = "" Then
        '    MsgBox("Please Input The Start Date")
        'ElseIf txtperiod.Value > txtto.Value Then
        '    MsgBox("Invalid Input")
        'Else

        'End If
        'If txtname.Text = "" OrElse txtempcode.Text = "" Then
        '    MsgBox("Please insert the employee")
        'End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            txtname.Text = "<empty>"
            txtname.Enabled = False
        End If
    End Sub
End Class