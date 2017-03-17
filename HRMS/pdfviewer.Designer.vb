<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pdfviewer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PdfViewer1 = New DevExpress.XtraPdfViewer.PdfViewer()
        Me.SuspendLayout()
        '
        'PdfViewer1
        '
        Me.PdfViewer1.AutoSize = True
        Me.PdfViewer1.Location = New System.Drawing.Point(0, 0)
        Me.PdfViewer1.Name = "PdfViewer1"
        Me.PdfViewer1.Size = New System.Drawing.Size(587, 658)
        Me.PdfViewer1.TabIndex = 0
        Me.PdfViewer1.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.FitToWidth
        '
        'pdfviewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(588, 656)
        Me.Controls.Add(Me.PdfViewer1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(604, 695)
        Me.MinimumSize = New System.Drawing.Size(604, 695)
        Me.Name = "pdfviewer"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "pdfviewer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PdfViewer1 As DevExpress.XtraPdfViewer.PdfViewer
End Class
