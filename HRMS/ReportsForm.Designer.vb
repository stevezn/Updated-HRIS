<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportsForm
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
        Me.date2 = New System.Windows.Forms.DateTimePicker()
        Me.date1 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtdate = New DevExpress.XtraEditors.CheckEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.txtdate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'date2
        '
        Me.date2.Enabled = False
        Me.date2.Location = New System.Drawing.Point(72, 51)
        Me.date2.Name = "date2"
        Me.date2.Size = New System.Drawing.Size(200, 20)
        Me.date2.TabIndex = 19
        '
        'date1
        '
        Me.date1.Enabled = False
        Me.date1.Location = New System.Drawing.Point(72, 25)
        Me.date1.Name = "date1"
        Me.date1.Size = New System.Drawing.Size(200, 20)
        Me.date1.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1, -1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(142, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Range date to be shown of :"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(189, 77)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(83, 23)
        Me.SimpleButton1.TabIndex = 16
        Me.SimpleButton1.Text = "Process Now"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(39, 51)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(12, 13)
        Me.LabelControl1.TabIndex = 15
        Me.LabelControl1.Text = "To"
        '
        'txtdate
        '
        Me.txtdate.Location = New System.Drawing.Point(8, 26)
        Me.txtdate.Name = "txtdate"
        Me.txtdate.Properties.Caption = "Date"
        Me.txtdate.Size = New System.Drawing.Size(58, 19)
        Me.txtdate.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "visible"
        Me.Label2.Visible = False
        '
        'ReportsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 119)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.date2)
        Me.Controls.Add(Me.date1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.txtdate)
        Me.MaximumSize = New System.Drawing.Size(300, 158)
        Me.MinimumSize = New System.Drawing.Size(300, 158)
        Me.Name = "ReportsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ReportsForm"
        CType(Me.txtdate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents date2 As DateTimePicker
    Friend WithEvents date1 As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtdate As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents Label2 As Label
End Class
