Public Class Rating
    Dim rate As New selectemp
    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If rate Is Nothing OrElse rate.IsDisposed OrElse rate.MinimizeBox Then
            rate.Close()
            rate = New selectemp
        End If
        rate.Show()
    End Sub

    Private Sub GroupControl1_Paint(sender As Object, e As PaintEventArgs) Handles GroupControl1.Paint

    End Sub

    Private Sub Rating_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class