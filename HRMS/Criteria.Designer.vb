<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Criteria
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Criteria))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.CheckEdit1 = New DevExpress.XtraEditors.CheckEdit()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.textedit2 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.CheckEdit2 = New DevExpress.XtraEditors.CheckEdit()
        Me.SimpleButton5 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton4 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.TextEdit1 = New DevExpress.XtraEditors.TextEdit()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.CheckEdit3 = New DevExpress.XtraEditors.CheckEdit()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.CheckEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEdit3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(9, 10)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(57, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Range Date"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Enabled = False
        Me.DateTimePicker1.Location = New System.Drawing.Point(58, 32)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(152, 20)
        Me.DateTimePicker1.TabIndex = 2
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(214, 35)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(19, 13)
        Me.LabelControl3.TabIndex = 3
        Me.LabelControl3.Text = "To :"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Enabled = False
        Me.DateTimePicker2.Location = New System.Drawing.Point(236, 32)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(153, 20)
        Me.DateTimePicker2.TabIndex = 4
        '
        'CheckEdit1
        '
        Me.CheckEdit1.Location = New System.Drawing.Point(17, 26)
        Me.CheckEdit1.Name = "CheckEdit1"
        Me.CheckEdit1.Properties.Caption = "Employee Code"
        Me.CheckEdit1.Size = New System.Drawing.Size(96, 19)
        Me.CheckEdit1.TabIndex = 5
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.textedit2)
        Me.GroupControl1.Controls.Add(Me.Label1)
        Me.GroupControl1.Controls.Add(Me.SimpleButton2)
        Me.GroupControl1.Controls.Add(Me.CheckEdit2)
        Me.GroupControl1.Controls.Add(Me.SimpleButton5)
        Me.GroupControl1.Controls.Add(Me.SimpleButton4)
        Me.GroupControl1.Controls.Add(Me.SimpleButton1)
        Me.GroupControl1.Controls.Add(Me.TextEdit1)
        Me.GroupControl1.Controls.Add(Me.CheckEdit1)
        Me.GroupControl1.Location = New System.Drawing.Point(4, 58)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(384, 297)
        Me.GroupControl1.TabIndex = 6
        Me.GroupControl1.Text = "Details"
        '
        'textedit2
        '
        Me.textedit2.Location = New System.Drawing.Point(119, 52)
        Me.textedit2.Name = "textedit2"
        Me.textedit2.Size = New System.Drawing.Size(232, 20)
        Me.textedit2.TabIndex = 19
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Label1"
        Me.Label1.Visible = False
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Enabled = False
        Me.SimpleButton2.Image = CType(resources.GetObject("SimpleButton2.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(354, 52)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(27, 22)
        Me.SimpleButton2.TabIndex = 17
        Me.SimpleButton2.Text = "SimpleButton2"
        '
        'CheckEdit2
        '
        Me.CheckEdit2.EditValue = True
        Me.CheckEdit2.Location = New System.Drawing.Point(17, 51)
        Me.CheckEdit2.Name = "CheckEdit2"
        Me.CheckEdit2.Properties.Caption = "All Employee"
        Me.CheckEdit2.Size = New System.Drawing.Size(96, 19)
        Me.CheckEdit2.TabIndex = 15
        '
        'SimpleButton5
        '
        Me.SimpleButton5.Location = New System.Drawing.Point(223, 269)
        Me.SimpleButton5.Name = "SimpleButton5"
        Me.SimpleButton5.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButton5.TabIndex = 14
        Me.SimpleButton5.Text = "Ok"
        '
        'SimpleButton4
        '
        Me.SimpleButton4.Location = New System.Drawing.Point(304, 269)
        Me.SimpleButton4.Name = "SimpleButton4"
        Me.SimpleButton4.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButton4.TabIndex = 7
        Me.SimpleButton4.Text = "Cancel"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Enabled = False
        Me.SimpleButton1.Image = CType(resources.GetObject("SimpleButton1.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(354, 24)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(27, 22)
        Me.SimpleButton1.TabIndex = 7
        Me.SimpleButton1.Text = "SimpleButton1"
        '
        'TextEdit1
        '
        Me.TextEdit1.Enabled = False
        Me.TextEdit1.Location = New System.Drawing.Point(119, 25)
        Me.TextEdit1.Name = "TextEdit1"
        Me.TextEdit1.Size = New System.Drawing.Size(232, 20)
        Me.TextEdit1.TabIndex = 7
        '
        'Timer1
        '
        '
        'CheckEdit3
        '
        Me.CheckEdit3.EditValue = True
        Me.CheckEdit3.Location = New System.Drawing.Point(4, 32)
        Me.CheckEdit3.Name = "CheckEdit3"
        Me.CheckEdit3.Properties.Caption = "From :"
        Me.CheckEdit3.Size = New System.Drawing.Size(51, 19)
        Me.CheckEdit3.TabIndex = 18
        '
        'Criteria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(393, 358)
        Me.Controls.Add(Me.CheckEdit3)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.LabelControl1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(409, 397)
        Me.MinimumSize = New System.Drawing.Size(409, 397)
        Me.Name = "Criteria"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Criteria"
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.CheckEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEdit3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents CheckEdit1 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SimpleButton5 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton4 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TextEdit1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents CheckEdit2 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents Timer1 As Timer
    Friend WithEvents CheckEdit3 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents Timer2 As Timer
    Friend WithEvents Label1 As Label
    Friend WithEvents textedit2 As TextBox
End Class
