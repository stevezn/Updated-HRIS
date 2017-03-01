<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Additional
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Additional))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.txtdate2 = New System.Windows.Forms.DateTimePicker()
        Me.txtdate1 = New System.Windows.Forms.DateTimePicker()
        Me.txtname = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.txtempcode = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.txtas2 = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.txtamount2 = New DevExpress.XtraEditors.TextEdit()
        Me.txtas1 = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.txtamount1 = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.DateEdit1 = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.btnapprove = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtname.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtempcode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtas2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtamount2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtas1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtamount1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.txtdate2)
        Me.LayoutControl1.Controls.Add(Me.txtdate1)
        Me.LayoutControl1.Controls.Add(Me.txtname)
        Me.LayoutControl1.Controls.Add(Me.txtempcode)
        Me.LayoutControl1.Controls.Add(Me.txtas2)
        Me.LayoutControl1.Controls.Add(Me.txtamount2)
        Me.LayoutControl1.Controls.Add(Me.txtas1)
        Me.LayoutControl1.Controls.Add(Me.txtamount1)
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 31)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(306, 217)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'txtdate2
        '
        Me.txtdate2.Location = New System.Drawing.Point(91, 84)
        Me.txtdate2.Name = "txtdate2"
        Me.txtdate2.Size = New System.Drawing.Size(203, 20)
        Me.txtdate2.TabIndex = 17
        '
        'txtdate1
        '
        Me.txtdate1.Location = New System.Drawing.Point(91, 60)
        Me.txtdate1.Name = "txtdate1"
        Me.txtdate1.Size = New System.Drawing.Size(203, 20)
        Me.txtdate1.TabIndex = 17
        '
        'txtname
        '
        Me.txtname.Location = New System.Drawing.Point(91, 12)
        Me.txtname.Name = "txtname"
        Me.txtname.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtname.Size = New System.Drawing.Size(203, 20)
        Me.txtname.StyleController = Me.LayoutControl1
        Me.txtname.TabIndex = 19
        '
        'txtempcode
        '
        Me.txtempcode.Location = New System.Drawing.Point(91, 36)
        Me.txtempcode.Name = "txtempcode"
        Me.txtempcode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtempcode.Size = New System.Drawing.Size(203, 20)
        Me.txtempcode.StyleController = Me.LayoutControl1
        Me.txtempcode.TabIndex = 13
        '
        'txtas2
        '
        Me.txtas2.Location = New System.Drawing.Point(91, 180)
        Me.txtas2.Name = "txtas2"
        Me.txtas2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtas2.Properties.Items.AddRange(New Object() {"Deductions", "Income"})
        Me.txtas2.Size = New System.Drawing.Size(203, 20)
        Me.txtas2.StyleController = Me.LayoutControl1
        Me.txtas2.TabIndex = 11
        '
        'txtamount2
        '
        Me.txtamount2.Location = New System.Drawing.Point(91, 156)
        Me.txtamount2.Name = "txtamount2"
        Me.txtamount2.Size = New System.Drawing.Size(203, 20)
        Me.txtamount2.StyleController = Me.LayoutControl1
        Me.txtamount2.TabIndex = 10
        '
        'txtas1
        '
        Me.txtas1.Location = New System.Drawing.Point(91, 132)
        Me.txtas1.Name = "txtas1"
        Me.txtas1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtas1.Properties.Items.AddRange(New Object() {"Deductions", "Income"})
        Me.txtas1.Size = New System.Drawing.Size(203, 20)
        Me.txtas1.StyleController = Me.LayoutControl1
        Me.txtas1.TabIndex = 10
        '
        'txtamount1
        '
        Me.txtamount1.Location = New System.Drawing.Point(91, 108)
        Me.txtamount1.Name = "txtamount1"
        Me.txtamount1.Size = New System.Drawing.Size(203, 20)
        Me.txtamount1.StyleController = Me.LayoutControl1
        Me.txtamount1.TabIndex = 9
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "LayoutControlGroup1"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem6, Me.LayoutControlItem7, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem8, Me.LayoutControlItem1, Me.LayoutControlItem2})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(306, 217)
        Me.LayoutControlGroup1.Text = "LayoutControlGroup1"
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.txtamount1
        Me.LayoutControlItem6.CustomizationFormText = "Amount"
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 96)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(286, 24)
        Me.LayoutControlItem6.Text = "Amount"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(76, 13)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.txtas1
        Me.LayoutControlItem7.CustomizationFormText = "As :"
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 120)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(286, 24)
        Me.LayoutControlItem7.Text = "As :"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(76, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtamount2
        Me.LayoutControlItem3.CustomizationFormText = "Amount"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 144)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(286, 24)
        Me.LayoutControlItem3.Text = "Amount"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(76, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtas2
        Me.LayoutControlItem4.CustomizationFormText = "As"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 168)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(286, 29)
        Me.LayoutControlItem4.Text = "As"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(76, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.txtempcode
        Me.LayoutControlItem5.CustomizationFormText = "Employee Code"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(286, 24)
        Me.LayoutControlItem5.Text = "Employee Code"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(76, 13)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.txtname
        Me.LayoutControlItem8.CustomizationFormText = "LayoutControlItem8"
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(286, 24)
        Me.LayoutControlItem8.Text = "Employee Name"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(76, 13)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtdate1
        Me.LayoutControlItem1.CustomizationFormText = "Salary Period"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(286, 24)
        Me.LayoutControlItem1.Text = "Salary Period"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(76, 13)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtdate2
        Me.LayoutControlItem2.CustomizationFormText = "Until"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(286, 24)
        Me.LayoutControlItem2.Text = "Until"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(76, 13)
        '
        'DateEdit1
        '
        Me.DateEdit1.EditValue = Nothing
        Me.DateEdit1.Location = New System.Drawing.Point(194, 5)
        Me.DateEdit1.Name = "DateEdit1"
        Me.DateEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit1.Properties.CalendarTimeProperties.CloseUpKey = New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4)
        Me.DateEdit1.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.[Default]
        Me.DateEdit1.Size = New System.Drawing.Size(100, 20)
        Me.DateEdit1.TabIndex = 2
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(165, 8)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl1.TabIndex = 3
        Me.LabelControl1.Text = "Date"
        '
        'btnapprove
        '
        Me.btnapprove.Image = CType(resources.GetObject("btnapprove.Image"), System.Drawing.Image)
        Me.btnapprove.Location = New System.Drawing.Point(179, 250)
        Me.btnapprove.Name = "btnapprove"
        Me.btnapprove.Size = New System.Drawing.Size(115, 39)
        Me.btnapprove.TabIndex = 1
        Me.btnapprove.Text = "Approve"
        '
        'Additional
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(300, 294)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.DateEdit1)
        Me.Controls.Add(Me.btnapprove)
        Me.Controls.Add(Me.LayoutControl1)
        Me.MaximumSize = New System.Drawing.Size(316, 333)
        Me.MinimumSize = New System.Drawing.Size(316, 333)
        Me.Name = "Additional"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Other Income / Deductions"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtname.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtempcode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtas2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtamount2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtas1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtamount1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents txtas1 As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents txtamount1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnapprove As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DateEdit1 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtas2 As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents txtamount2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtempcode As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtname As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtdate2 As DateTimePicker
    Friend WithEvents txtdate1 As DateTimePicker
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
End Class
