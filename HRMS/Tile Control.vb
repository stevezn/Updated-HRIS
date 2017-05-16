Imports System.IO
Imports DevExpress.XtraBars.Alerter

Public Class Tile_Control
    Dim connectionString As String
    Dim SQLConnection As MySqlConnection = New MySqlConnection
    Dim oDt_sched As New DataTable()

    Public conStr As String

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
    Dim main As MainApp

    Private Sub TileItem1_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItem1.ItemClick
        If main Is Nothing OrElse main.IsDisposed OrElse main.MinimizeBox Then
            ' main.Close()
            main = New MainApp
        End If
        main.Show()
        Close()
    End Sub

    Private Sub TileItem5_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItem5.ItemClick
        If main Is Nothing OrElse main.IsDisposed OrElse main.MinimizeBox Then
            ' main.Close()
            main = New MainApp
        End If
        main.Show()
        Close()
    End Sub

    Private Sub TileItem6_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItem6.ItemClick
        Dim pesan As String
        pesan = CType(MsgBox("Log Off Application?", MsgBoxStyle.YesNo, "Warning"), String)
        If CType(pesan, Global.Microsoft.VisualBasic.MsgBoxResult) = vbYes Then
            Try
                Dim del As MySqlCommand = SQLConnection.CreateCommand
                del.CommandText = "truncate db_hasil"
                del.ExecuteNonQuery()
                Dim dele As MySqlCommand = SQLConnection.CreateCommand
                dele.CommandText = "truncate db_temp"
                dele.ExecuteNonQuery()

                dele.CommandText = "truncate db_tmpname"
                dele.ExecuteNonQuery()
            Catch ex As Exception

            End Try
            SQLConnection.Close()
            Close()
            Login.Close()
            Application.Exit()
        End If
    End Sub

    Private Sub TileItem2_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItem2.ItemClick
        MainApp.Show()
        Close()
    End Sub
    Dim loan As New Payments

    Private Sub TileItem3_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItem3.ItemClick
        If loan Is Nothing OrElse loan.IsDisposed OrElse loan.MinimizeBox Then
            loan.Close()
            loan = New Payments
        End If
        loan.Show()
        Close()
    End Sub

    Dim att As New Attendances

    Private Sub TileItem4_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItem4.ItemClick
        If att Is Nothing OrElse att.IsDisposed OrElse att.MinimizeBox Then
            att.Close()
            att = New Attendances
        End If
        att.Show()
        Close()
    End Sub

    Dim rep As New Reports

    Private Sub TileItem7_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItem7.ItemClick
        If rep Is Nothing OrElse rep.IsDisposed OrElse rep.MinimizeBox Then
            rep.Close()
            rep = New Reports
        End If
        rep.Show()
        Close()
    End Sub

    Private Sub Tile_Control_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLConnection.ConnectionString = connectionString
        SQLConnection.Open()
        'ShowAlert()
        alert()
    End Sub

    Private Sub Tile_Control_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

    End Sub

    Dim cus As New Customize

    Private Sub TileItem8_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItem8.ItemClick
        If cus Is Nothing OrElse cus.IsDisposed OrElse cus.MinimizeBox Then
            cus.Close()
            cus = New Customize
        End If
        cus.Show()
    End Sub

    Dim asp As New AspekKerja

    Private Sub TileItem9_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItem9.ItemClick
        If asp Is Nothing OrElse asp.IsDisposed OrElse asp.MinimizeBox Then
            asp.Close()
            asp = New AspekKerja
        End If
        asp.Show()
    End Sub

    Dim reps As New Reports

    Private Sub TileItem10_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItem10.ItemClick
        If reps Is Nothing OrElse reps.IsDisposed OrElse reps.MinimizeBox Then
            reps.Close()
            reps = New Reports
        End If
        reps.Show()
    End Sub

    Dim approve As New Approvement

    Private Sub TileItem11_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItem11.ItemClick
        If approve Is Nothing OrElse approve.IsDisposed OrElse approve.MinimizeBox Then
            approve.Close()
            approve = New Approvement
        End If
        approve.Show()
    End Sub

    Private Sub AlertControl1_AlertClick(sender As Object, e As DevExpress.XtraBars.Alerter.AlertClickEventArgs)

    End Sub

    Private Function GetImage() As Image
        Return ImageCollection1.Images(0)
    End Function

    Private Function GetImage1() As Image
        Return ImageCollection1.Images(1)
    End Function

    Sub alert()
        Dim btn1 As AlertButton = New AlertButton(GetImage)
        Dim btn2 As AlertButton = New AlertButton(GetImage1)
        btn1.Hint = "View Progress"
        btn1.Name = "btnProg"
        btn2.Hint = "View Candidates"
        btn2.Name = "btnview"
        AlertControl1.Buttons.Add(btn1)
        AlertControl1.Buttons.Add(btn2)
        AddHandler AlertControl1.ButtonClick, AddressOf AlertControl1_ButtonClick
        AddHandler AlertControl1.ButtonDownChanged,
        AddressOf AlertControl1_ButtonDownChanged
        Dim info As AlertInfo = New AlertInfo("Welcome User", "HRIS")
        'AlertControl1.Show(Me, info)
        Try
            Dim query As MySqlCommand = SQLConnection.CreateCommand
            query.CommandText = "select user from db_temp"
            Dim quer As String = CStr(query.ExecuteScalar)
            query.CommandText = "select count(status) from db_recruitment where status = 'In progress'"
            Dim quer2 As Integer = CInt(query.ExecuteScalar)
            query.CommandText = "select count(interviewdate) from db_recruitment where interviewdate = @d1"
            query.Parameters.AddWithValue("@d1", Date.Now)
            Dim quer1 As Integer = CInt(query.ExecuteScalar)
            query.CommandText = "select "
            If quer2 > 1 Then
                AlertControl1.Show(Me, "Welcome To HRIS", "<color=green> " & quer.ToString & " you have " & quer2 & " 'In Progress' Status in Recruitment</color> <color=green> and " & quer1.ToString & " interviews schedules for today </color>")
            Else
                AlertControl1.Show(Me, "Welcome To HRIS", "<color=green>" & quer.ToString & "</color><br>")
            End If
        Catch ex As Exception
            'MsgBox(" alert" & ex.Message)
        End Try
    End Sub

    Private Sub AlertControl1_BeforeFormShow(sender As Object, e As AlertFormEventArgs)
        e.AlertForm.OpacityLevel = 1
    End Sub

    Dim prog As New RecProcess

    Private Sub AlertControl1_ButtonClick(sender As Object, e As AlertButtonClickEventArgs) Handles AlertControl1.ButtonClick
        If e.ButtonName = "btnProg" Then
            If prog Is Nothing OrElse prog.IsDisposed OrElse prog.MinimizeBox Then
                prog.Close()
                prog = New RecProcess
            End If
            prog.Show()
        ElseIf e.ButtonName = "btnview" Then
            MsgBox("No idea")
        End If
    End Sub

    Private Sub AlertControl1_ButtonDownChanged(sender As Object, e As AlertButtonDownChangedEventArgs) Handles AlertControl1.ButtonDownChanged

    End Sub
End Class
