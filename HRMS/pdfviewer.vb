Public Class pdfviewer
    Private Sub pdfviewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.PdfViewer1.LoadDocument("E:\Backup\.pdf")
    End Sub
End Class