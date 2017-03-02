Imports System.IO
Imports DevExpress.XtraCharts

Public Class Comparison

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

    Private Sub comparison_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        loadinfo()
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
            sqlCommand.CommandText = "SELECT IdRec FROM db_recruitment WHERE 1=1 " + param.ToString()
            sqlCommand.Connection = SQLConnection
            Dim adapter As New MySqlDataAdapter(sqlCommand.CommandText, SQLConnection)
            Dim cb As New MySqlCommandBuilder(adapter)
            adapter.Fill(datatabl)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If datatabl.Rows.Count > 0 Then
            txtid.Text = datatabl.Rows(0).Item(0).ToString()
        End If
    End Sub
    Private Sub grafik()
        ' ChartControl1.Series.Clear()

        ' Add a radar series to it.
        Dim aname As MySqlCommand = SQLConnection.CreateCommand
        aname.CommandText = "select fullname from db_recruitment where idrec = '" & txtid.Text & "'"
        Dim aaname As String = CStr(aname.ExecuteScalar)

        Dim series1 As New Series("Series 1", ViewType.RadarArea)
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
        ' Populate the series with points.
        series1.Points.Add(New SeriesPoint("SKill1", hasila))
        series1.Points.Add(New SeriesPoint("SKill2", hasilb))
        series1.Points.Add(New SeriesPoint("SKill3", hasilc))
        series1.Points.Add(New SeriesPoint("SKill4", hasild))
        series1.Points.Add(New SeriesPoint("SKill5", hasile))
        ' Add the series to the chart.
        ChartControl1.Series.Add(series1)

        ' Flip the diagram (if necessary).
        'CType(ChartControl2.Diagram, RadarDiagram).StartAngleInDegrees = 180
        'CType(ChartControl2.Diagram, RadarDiagram).RotationDirection =
        '    RadarDiagramRotationDirection.Counterclockwise

        ' Add a title to the chart and hide the legend.
        Dim chartTitle1 As New ChartTitle()
        chartTitle1.Text = "Radar Area Chart"
        'ChartControl2.Titles.Add(chartTitle1)
        ChartControl1.Legend.Visible = False

        '' Add the chart to the form.
        'ChartControl2.Dock = DockStyle.Fill
        'Me.Controls.Add(ChartControl2)
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If LabelControl1.Visible = False Then
            LabelControl1.Visible = True
            Dim a As MySqlCommand = SQLConnection.CreateCommand
            a.CommandText = "select fullname from db_recruitment where idrec = @ic"
            a.Parameters.AddWithValue("@ic", txtid.Text)
            Dim aa As String = CStr(a.ExecuteScalar)
            LabelControl1.Text = aa
        ElseIf LabelControl2.Visible = False Then
            LabelControl2.Visible = True
            Dim a As MySqlCommand = SQLConnection.CreateCommand
            a.CommandText = "select fullname from db_recruitment where idrec = @ic"
            a.Parameters.AddWithValue("@ic", txtid.Text)
            Dim aa As String = CStr(a.ExecuteScalar)
            LabelControl2.Text = aa
        ElseIf LabelControl4.Visible = False Then
            LabelControl4.Visible = True
            Dim a As MySqlCommand = SQLConnection.CreateCommand
            a.CommandText = "select fullname from db_recruitment where idrec = @ic"
            a.Parameters.AddWithValue("@ic", txtid.Text)
            Dim aa As String = CStr(a.ExecuteScalar)
            LabelControl4.Text = aa
        ElseIf LabelControl3.Visible = False Then
            LabelControl3.Visible = True
            Dim a As MySqlCommand = SQLConnection.CreateCommand
            a.CommandText = "select fullname from db_recruitment where idrec = @ic"
            a.Parameters.AddWithValue("@ic", txtid.Text)
            Dim aa As String = CStr(a.ExecuteScalar)
            LabelControl3.Text = aa
        End If
        grafik()
    End Sub
End Class