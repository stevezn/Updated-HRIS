Imports DevExpress.XtraGrid

Public Class Lists

    Sub ShowGridPreview(ByVal grid As GridControl)
        ' Check whether the GridControl can be previewed.
        If Not grid.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' library is not found", "Error")
            Return
        End If
        ' Opens the Preview window.
        grid.ShowPrintPreview()
    End Sub


    Sub PrintGrid(ByVal grid As GridControl)
        ' Check whether the GridControl can be printed.
        If Not grid.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' library is not found", "Error")
            Return
        End If
        ' Print.
        grid.Print()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        ShowGridPreview(GridControl1)
    End Sub

End Class