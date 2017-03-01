<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Payslip
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Payslip))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtname = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtempcode = New DevExpress.XtraEditors.TextEdit()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.txtto = New System.Windows.Forms.DateTimePicker()
        Me.txtperiod = New System.Windows.Forms.DateTimePicker()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        CType(Me.txtname.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtempcode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(5, 11)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(86, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Which Employee ?"
        '
        'txtname
        '
        Me.txtname.Location = New System.Drawing.Point(102, 8)
        Me.txtname.Name = "txtname"
        Me.txtname.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtname.Size = New System.Drawing.Size(100, 20)
        Me.txtname.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(5, 63)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(63, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Salary Period"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(5, 37)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(74, 13)
        Me.LabelControl3.TabIndex = 4
        Me.LabelControl3.Text = "Employee Code"
        '
        'txtempcode
        '
        Me.txtempcode.Location = New System.Drawing.Point(102, 34)
        Me.txtempcode.Name = "txtempcode"
        Me.txtempcode.Size = New System.Drawing.Size(100, 20)
        Me.txtempcode.TabIndex = 5
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.txtto)
        Me.GroupControl1.Controls.Add(Me.txtperiod)
        Me.GroupControl1.Controls.Add(Me.LabelControl4)
        Me.GroupControl1.Controls.Add(Me.SimpleButton1)
        Me.GroupControl1.Controls.Add(Me.RadioButton1)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.txtempcode)
        Me.GroupControl1.Controls.Add(Me.txtname)
        Me.GroupControl1.Controls.Add(Me.LabelControl3)
        Me.GroupControl1.Location = New System.Drawing.Point(2, 1)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(211, 182)
        Me.GroupControl1.TabIndex = 6
        '
        'txtto
        '
        Me.txtto.Location = New System.Drawing.Point(102, 90)
        Me.txtto.Name = "txtto"
        Me.txtto.Size = New System.Drawing.Size(100, 20)
        Me.txtto.TabIndex = 10
        Me.txtto.Value = New Date(2017, 2, 8, 0, 0, 0, 0)
        '
        'txtperiod
        '
        Me.txtperiod.Location = New System.Drawing.Point(102, 63)
        Me.txtperiod.Name = "txtperiod"
        Me.txtperiod.Size = New System.Drawing.Size(100, 20)
        Me.txtperiod.TabIndex = 9
        Me.txtperiod.Value = New Date(2017, 2, 8, 0, 0, 0, 0)
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(56, 87)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(12, 13)
        Me.LabelControl4.TabIndex = 8
        Me.LabelControl4.Text = "To"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Image = CType(resources.GetObject("SimpleButton1.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(102, 139)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(100, 38)
        Me.SimpleButton1.TabIndex = 7
        Me.SimpleButton1.Text = "Preview"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(57, 116)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(145, 17)
        Me.RadioButton1.TabIndex = 6
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Print All Employee Payslip"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Payslip
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(213, 181)
        Me.Controls.Add(Me.GroupControl1)
        Me.MaximumSize = New System.Drawing.Size(229, 220)
        Me.MinimumSize = New System.Drawing.Size(229, 220)
        Me.Name = "Payslip"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Payslip"
        CType(Me.txtname.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtempcode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtname As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtempcode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtto As DateTimePicker
    Friend WithEvents txtperiod As DateTimePicker
End Class
