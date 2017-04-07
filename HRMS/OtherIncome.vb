Imports System.IO
Imports DevExpress.Utils.Menu
Imports DevExpress.XtraGrid.Views.Grid

Public Class OtherIncome
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

    'Sub changer()
    '    Dim mnow As String = Month(Now).ToString
    '    Dim yearx As String = Format(Now, "yy").ToString
    '        Dim updmon As String
    '        Dim tmp As Integer
    '        Dim lastcode As String = ""
    '        Dim query As MySqlCommand = SQLConnection.CreateCommand
    '        query.CommandText = "select last_num from lastmemo"
    '        Dim lastn As Integer = DirectCast(query.ExecuteScalar, Integer)
    '        query.CommandText = "SELECT Memono FROM db_addition ORDER BY MemoNo DESC LIMIT 1"
    '        lastcode = DirectCast(query.ExecuteScalar(), String)
    '            Dim cmd = SQLConnection.CreateCommand
    '            cmd.CommandText = "SELECT MID(MemoNo, 9, 1) FROM db_addition where MemoNo = '" & lastcode & "'"
    '            updmon = DirectCast(cmd.ExecuteScalar(), String)
    '            If CInt(updmon) <> CInt(mnow) Then
    '                tmp = 1
    '            Else
    '                tmp = lastn + 1
    '            End If
    '            selectname()
    '            loads()
    '            Dim actualcode As String
    '            actualcode = "Memo" & "-" & yearx & "-" & mnow & "-" & Strings.Right("0000" & tmp, 5)
    '    txtmemo.Text = actualcode.ToString
    'End Sub

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
            cmd.CommandText = "SELECT last_num FROM lastmemo"
            lastn = DirectCast(cmd.ExecuteScalar(), Integer)
        Catch ex As Exception
        End Try
        Try
            Dim cmd = SQLConnection.CreateCommand
            cmd.CommandText = "SELECT MemoNo FROM db_addition ORDER BY MemoNo DESC LIMIT 1"
            lastcode = DirectCast(cmd.ExecuteScalar(), String)
        Catch ex As Exception
        End Try
        Try
            Dim cmd = SQLConnection.CreateCommand
            cmd.CommandText = "SELECT MID(MemoNo, 8, 1) FROM db_addition where MemoNo = '" & lastcode & "'"
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

    Private Sub OtherIncome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLConnection.ConnectionString = connectionstring
        SQLConnection.Open()
        changer()
        txtperiod.Format = DateTimePickerFormat.Custom
        txtperiod.CustomFormat = "MMMM yyyy"
        txtuntil.Format = DateTimePickerFormat.Custom
        txtuntil.CustomFormat = "MMMM yyyy"
    End Sub

    Sub loads()
        Dim table As New DataTable
        Try
            Dim query As MySqlCommand = SQLConnection.CreateCommand
            query.CommandText = "select * from db_addition"
            Dim tbl_par As New DataTable
            Dim adapter As New MySqlDataAdapter(query.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(table)
            GridControl1.DataSource = table
        Catch ex As Exception
        End Try
    End Sub

    Sub insertion()
        Dim dta, dtb, dtc As Date
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy-MM-dd"
        dtb = DateTimePicker1.Value
        txtperiod.Format = DateTimePickerFormat.Custom
        txtperiod.CustomFormat = "MMMM yyyy"
        dta = txtperiod.Value
        txtuntil.Format = DateTimePickerFormat.Custom
        txtuntil.CustomFormat = "MMMM yyyy"
        dtc = txtuntil.Value
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "select last_num from lastmemo"
        query.CommandText = "insert into db_addition " +
                                "(Memono, EmployeeCode, Period, Until, Amount, As1, Reason, Tanggal) " +
                                 " values (@Memono, @EmployeeCode, @Period, @Until, @Amount, @As1, @Reason, @Date1)"
        query.Parameters.AddWithValue("@Memono", txtmemo.Text)
        query.Parameters.AddWithValue("@EmployeeCode", txtemployeecode.Text)
        query.Parameters.AddWithValue("@Period", txtperiod.Text)
        query.Parameters.AddWithValue("@Until", txtuntil.Text)
        query.Parameters.AddWithValue("@Amount", txtamount.Text)
        query.Parameters.AddWithValue("@As1", txtas.Text)
        query.Parameters.AddWithValue("@Reason", txtreason.Text)
        query.Parameters.AddWithValue("@Date1", dtb.ToString("yyyy-MM-dd"))
        query.ExecuteNonQuery()
        changer()
        txtemployeecode.Text = ""
        txtperiod.Text = ""
        txtuntil.Text = ""
        txtamount.Text = ""
        txtas.Text = ""
        txtreason.Text = ""
        GridControl1.RefreshDataSource()
        Dim table As New DataTable
        Try
            query.CommandText = "select * from db_addition"
            Dim tbl_par As New DataTable
            Dim adapter As New MySqlDataAdapter(query.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(table)
            GridControl1.DataSource = table
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If txtamount.Text = "" OrElse txtemployeecode.Text = "" OrElse txtas.Text = "" Then
            MsgBox("The required data is still empty, please fill the rest")
        Else
            insertion()
        End If
    End Sub

    Function ImageToByte(ByVal pbImg As PictureBox) As Byte()
        If pbImg Is Nothing Then
            Return Nothing
        End If
        Dim ms As New MemoryStream()
        pbImg.Image.Save(ms, Imaging.ImageFormat.Jpeg)
        Return ms.ToArray()
    End Function

    Public Function ByteToImage(ByVal filefoto As Byte()) As Image
        Dim pictureBytes As New MemoryStream(filefoto)
        Return Image.FromStream(pictureBytes)
    End Function

    Private Sub GridView2_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs)
        Dim view As GridView = CType(sender, GridView)
        If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Row Then
            Dim rowHandle As Integer = e.HitInfo.RowHandle
            e.Menu.Items.Clear()
            Dim item As DXMenuItem = CreateMergingEnabledMenuItem(view, rowHandle)
            item.BeginGroup = True
            e.Menu.Items.Add(item)
        End If
        If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Row Then
            e.Menu.Items.Add(New DXMenuItem("Select Employee", New EventHandler(AddressOf SimpleButton7_Click)))
        End If
    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs)

    End Sub
    Dim sel As New selectemp

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        timer1.start
        If sel Is Nothing OrElse sel.IsDisposed OrElse sel.MinimizeBox Then
            sel.Close()
            sel = New selectemp
        End If
        sel.Show()
    End Sub

    Private Sub txtamount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtamount.KeyPress
        Dim ch As Char = e.KeyChar
        If Char.IsLetter(ch) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Dim query As MySqlCommand = SQLConnection.CreateCommand
            query.CommandText = "select name from db_tmpname"
            Dim quer1 As String = CType(query.ExecuteScalar, String)
            TextBox1.Text = quer1.ToString

            query.CommandText = "select employeecode from db_tmpname"
            Dim quer2 As String = CType(query.ExecuteScalar, String)
            txtemployeecode.Text = quer2.ToString
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtemployeecode_TextChanged(sender As Object, e As EventArgs) Handles txtemployeecode.TextChanged
        Timer1.Stop()
    End Sub
End Class