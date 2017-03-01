Imports System.IO

Public Class addmenu
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

    Private Sub addmenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        Dim datatabl As New DataTable
        Dim sqlCommand As New MySqlCommand
        datatabl.Clear()
        Dim param As String = ""
        Try
            param = "and EmployeeCode='" + GridView1.GetFocusedRowCellValue("EmployeeCode").ToString() + "'"
        Catch ex As Exception
        End Try
        Try
            sqlCommand.CommandText = "SELECT EmployeeCode, FullName, shift, Tanggal, JamMulai, JamSelesai from db_absensi WHERE 1=1 " + param.ToString()
            sqlCommand.Connection = SQLConnection
            Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(datatabl)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If datatabl.Rows.Count > 0 Then
            label9.Text = datatabl.Rows(0).Item(1).ToString()
            Label5.Text = datatabl.Rows(0).Item(0).ToString
        End If
    End Sub

    Private Sub resultpages()
        Dim sqlcommand As New MySqlCommand
        Dim lastn As Integer
        Try
            Dim cmd = SQLConnection.CreateCommand()
            cmd.CommandText = "SELECT count(*) FROM db_borongan where EmployeeCode = @ec and Tanggal = curdate()"
            cmd.Parameters.AddWithValue("@ec", Label5.Text)
            lastn = DirectCast(cmd.ExecuteScalar, Integer)
            MsgBox(lastn)
        Catch ex As Exception
        End Try
        If lastn = 0 Then
            sqlcommand.CommandText = "INSERT INTO db_borongan " +
                          "(FullName, EmployeeCode, Tanggal, Result) " +
                          "values (@FullName, @EmployeeCode, @Tanggal, @Result)"
            sqlcommand.Connection = SQLConnection
            sqlcommand.Parameters.AddWithValue("@FullName", label9.Text)
            sqlcommand.Parameters.AddWithValue("@Tanggal", Date.Now)
            sqlcommand.Parameters.AddWithValue("@EmployeeCode", Label5.Text)
            sqlcommand.Parameters.AddWithValue("@Result", txtpages.Text)
            sqlcommand.ExecuteNonQuery()
            MsgBox("Added")
        Else
            MsgBox("This employee has already input for today")
        End If
    End Sub

    Private Sub overtimeresult()
        Dim dtb As DateTime
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy-MM-dd"
        dtb = DateTimePicker1.Value
        Dim sqlcommand As New MySqlCommand
        Try
            sqlcommand.CommandText = "insert into db_overtime " +
                                    "(FullName, EmployeeCode, Tanggal, Hours) " +
                                    "values (@FullName, @EmployeeCode, @Tanggal, @Hours)"
            sqlcommand.Connection = SQLConnection
            sqlcommand.Parameters.AddWithValue("@FullName", label9.Text)
            sqlcommand.Parameters.AddWithValue("@EmployeeCode", Label10.Text)
            sqlcommand.Parameters.AddWithValue("@Tanggal", dtb.ToString("yyyy-MM-dd"))
            sqlcommand.Parameters.AddWithValue("@Hours", txtsav.Text)
            sqlcommand.ExecuteNonQuery()
            MsgBox("Added")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If txtpages.Text = "" Or label9.Text = "-" Or Label5.Text = "//" Then
            MsgBox("The input is wrong")
        Else
            resultpages()
        End If
    End Sub

    Private Sub SimpleButton3_Click_1(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        If txtsav.Text = "" Or DateTimePicker1.Value = Now.Date Then
            MsgBox("Please fill hours textbox")
        Else
            overtimeresult()
        End If
    End Sub

    Private Sub GridView3_FocusedRowChanged_1(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView3.FocusedRowChanged
        Dim datatabl As New DataTable
        Dim sqlCommand As New MySqlCommand
        datatabl.Clear()
        Dim param As String = ""
        Try
            param = "and EmployeeCode='" + GridView3.GetFocusedRowCellValue("EmployeeCode").ToString() + "'"
        Catch ex As Exception
        End Try
        Try
            sqlCommand.CommandText = "SELECT EmployeeCode, FullName, EmployeeType from db_pegawai WHERE 1=1 " + param.ToString()
            sqlCommand.Connection = SQLConnection

            Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(datatabl)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If datatabl.Rows.Count > 0 Then
            label9.Text = datatabl.Rows(0).Item(1).ToString()
            Label10.Text = datatabl.Rows(0).Item(0).ToString
        End If
    End Sub
End Class