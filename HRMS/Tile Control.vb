Imports System.IO

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
                ' del.CommandText = "delete from db_hasil where EmployeeCode != 'absbahsgedeg'"
                del.CommandText = "truncate db_hasil"
                del.ExecuteNonQuery()
                Dim dele As MySqlCommand = SQLConnection.CreateCommand
                'dele.CommandText = "delete from db_temp where EmployeeCode != 'absbahsgedeg'"
                dele.CommandText = "truncate db_temp"
                dele.Parameters.Clear()
                dele.ExecuteNonQuery()

                dele.CommandText = "truncate db_tmpname"
                dele.Parameters.Clear()
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

    End Sub

    Private Sub Tile_Control_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
    End Sub

    Private Sub TileControl1_Click(sender As Object, e As EventArgs) Handles TileControl1.Click

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
End Class