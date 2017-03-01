Imports System.IO

Public Class Analytical
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

    'Public Sub GRAFIK(ByVal chartcontrol1 As Chart)
    '    Try
    '        chartcontrol1.Series.Add("ket")
    '        Dim cnt As New MySqlConnection(connectionString)
    '        Dim cmd As New MySqlCommand
    '        cnt.Open()
    '        cmd.Connection = cnt
    '        Dim Comment As String = "SELECT * FROM db_skills"
    '        Dim da As New MySqlDataAdapter(Comment, cnt)
    '        Dim ds As New DataSet()
    '        da.Fill(ds, "grafik")
    '        chartcontrol1.Series("ket").XValueMember = "SKill"
    '        chartcontrol1.Series("ket").YValueMembers = "Result"
    '        chartcontrol1.DataSource = ds.Tables("grafik")
    '        cnt.Close()
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Private Sub grafik()
        Chart1.Series.Add("Value")
        Dim a As MySqlCommand = SQLConnection.CreateCommand
        a.CommandText = "select skill1 from db_skills where idrec = '" & txtid.Text & "'"
        Dim hasila As Integer = CInt(a.ExecuteScalar)
        Dim b As MySqlCommand = SQLConnection.CreateCommand
        b.CommandText = "select skill2 from db_skills where idrec = '" & txtid.Text & "'"
        Dim hasilb As Integer = CInt(b.ExecuteScalar)
        Dim c As MySqlCommand = SQLConnection.CreateCommand
        c.CommandText = "select skill3 from db_skills where idrec = '" & txtid.Text & "'"
        Dim hasilc As Integer = CInt(c.ExecuteScalar)
        Dim d As MySqlCommand = SQLConnection.CreateCommand
        d.CommandText = "select skill4 from db_skills where idrec = '" & txtid.Text & "'"
        Dim hasild As Integer = CInt(d.ExecuteScalar)
        Dim e As MySqlCommand = SQLConnection.CreateCommand
        e.CommandText = "select skill5 from db_skills where idrec = '" & txtid.Text & "'"
        Dim hasile As Integer = CInt(e.ExecuteScalar)
        Chart1.Series("Value").Points.AddXY("SKill1", hasila)
        Chart1.Series("Value").Points.AddXY("Skill2", hasilb)
        Chart1.Series("Value").Points.AddXY("Skill3", hasilc)
        Chart1.Series("Value").Points.AddXY("Skill4", hasild)
        Chart1.Series("Value").Points.AddXY("Skill5", hasile)
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        grafik()
    End Sub

    'Private Sub drawchart()
    '    'draw the chart
    '    Chart1.Series.Clear()
    '    Chart1.Series.Add("Recruitment Statistical")

    '    With Chart1.Series(0)
    '        '.ChartType = DataVisualization.Charting.SeriesChartType.Line
    '        .BorderWidth = 1
    '        .Color = Color.Red
    '        .BorderDashStyle = ChartDashStyle.Dash
    '        .MarkerStyle = MarkerStyle.Square
    '        .MarkerSize = 4
    '        .IsVisibleInLegend = False
    '        For m = 1 To 12
    '            .Points.AddXY(m, MonthlyData(m))
    '        Next
    '    End With
    'End Sub

    Private Sub Analytical_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        loadinfo()
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

    Private Sub Chart1_Paint(sender As Object, e As PaintEventArgs) Handles Chart1.Paint
        ' drawchart()
    End Sub

    Private Sub loadinfo()
        GridControl1.RefreshDataSource()
        Dim table As New DataTable
        Dim sqlcommand As New MySqlCommand
        Try
            sqlcommand.CommandText = "Select FullName from db_recruitment where status != 'In Progress'"
            sqlcommand.Connection = SQLConnection
            Dim tbl_par As New DataTable
            Dim adapter As New MySqlDataAdapter(sqlcommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(table)
            GridControl1.DataSource = table
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        Dim datatabl As New DataTable
        Dim sqlCommand As New MySqlCommand
        datatabl.Clear()
        Dim param As String = ""
        Try
            param = "and FullName='" + GridView1.GetFocusedRowCellValue("FullName").ToString() + "'"
        Catch ex As Exception
        End Try
        Try
            sqlCommand.CommandText = "SELECT IdRec, InterviewTimes, FullName, PlaceofBirth, DateOfBirth, Address,Gender, Religion, PhoneNumber, IdNumber, Photo, Status, InterviewDate, PhoneNumber, InterviewDate, Reason FROM db_recruitment WHERE 1=1 " + param.ToString()
            sqlCommand.Connection = SQLConnection
            Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(datatabl)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If datatabl.Rows.Count > 0 Then
            txtnames.Text = datatabl.Rows(0).Item(2).ToString()
            txtid.Text = datatabl.Rows(0).Item(0).ToString()
            txtinterview.Text = datatabl.Rows(0).Item(1).ToString()
            txtpob.Text = datatabl.Rows(0).Item(3).ToString()
            txtdob.Text = datatabl.Rows(0).Item(4).ToString()
            txtaddress.Text = datatabl.Rows(0).Item(5).ToString()
            txtgender.Text = datatabl.Rows(0).Item(6).ToString()
            Dim filefoto As Byte() = CType(datatabl.Rows(0).Item(10), Byte())
            If filefoto.Length > 0 Then
                PictureBox1.Image = ByteToImage(filefoto)
            Else
                PictureBox1.Image = Nothing
                PictureBox1.Refresh()
            End If
            txtreligion.Text = datatabl.Rows(0).Item(7).ToString()
            txtidcard.Text = datatabl.Rows(0).Item(9).ToString()
            txtstatus.Text = datatabl.Rows(0).Item(11).ToString()
            txtphone.Text = datatabl.Rows(0).Item(13).ToString()
            txtinterviewdate.Text = datatabl.Rows(0).Item(14).ToString()
        End If
    End Sub
End Class