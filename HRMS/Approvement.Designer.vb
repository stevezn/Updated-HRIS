<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Approvement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Approvement))
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.SimpleButton9 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton8 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.SimpleButton4 = New DevExpress.XtraEditors.SimpleButton()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.SimpleButton5 = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SimpleButton7 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton6 = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.SimpleButton9)
        Me.GroupControl1.Controls.Add(Me.SimpleButton8)
        Me.GroupControl1.Controls.Add(Me.SimpleButton1)
        Me.GroupControl1.Controls.Add(Me.SimpleButton2)
        Me.GroupControl1.Controls.Add(Me.SimpleButton3)
        Me.GroupControl1.Location = New System.Drawing.Point(859, 2)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(215, 161)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "View Request Lists"
        '
        'SimpleButton9
        '
        Me.SimpleButton9.Location = New System.Drawing.Point(22, 128)
        Me.SimpleButton9.Name = "SimpleButton9"
        Me.SimpleButton9.Size = New System.Drawing.Size(183, 23)
        Me.SimpleButton9.TabIndex = 6
        Me.SimpleButton9.Text = "Other Income"
        '
        'SimpleButton8
        '
        Me.SimpleButton8.Location = New System.Drawing.Point(22, 49)
        Me.SimpleButton8.Name = "SimpleButton8"
        Me.SimpleButton8.Size = New System.Drawing.Size(184, 23)
        Me.SimpleButton8.TabIndex = 5
        Me.SimpleButton8.Text = "Loans"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(22, 100)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(183, 23)
        Me.SimpleButton1.TabIndex = 2
        Me.SimpleButton1.Text = "Status Change"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Location = New System.Drawing.Point(22, 75)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(184, 23)
        Me.SimpleButton2.TabIndex = 3
        Me.SimpleButton2.Text = "Termination"
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Location = New System.Drawing.Point(22, 21)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(184, 23)
        Me.SimpleButton3.TabIndex = 4
        Me.SimpleButton3.Text = "Leave Request"
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(859, 444)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsFind.AlwaysVisible = True
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.PaintStyleName = "UltraFlat"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(73, 180)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(49, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Approving"
        '
        'TextBox1
        '
        Me.TextBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TextBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TextBox1.Location = New System.Drawing.Point(6, 199)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(170, 20)
        Me.TextBox1.TabIndex = 3
        '
        'SimpleButton4
        '
        Me.SimpleButton4.Image = CType(resources.GetObject("SimpleButton4.Image"), System.Drawing.Image)
        Me.SimpleButton4.Location = New System.Drawing.Point(181, 198)
        Me.SimpleButton4.Name = "SimpleButton4"
        Me.SimpleButton4.Size = New System.Drawing.Size(26, 20)
        Me.SimpleButton4.TabIndex = 9
        '
        'TextBox2
        '
        Me.TextBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TextBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TextBox2.Location = New System.Drawing.Point(6, 225)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(170, 20)
        Me.TextBox2.TabIndex = 10
        '
        'SimpleButton5
        '
        Me.SimpleButton5.Location = New System.Drawing.Point(6, 251)
        Me.SimpleButton5.Name = "SimpleButton5"
        Me.SimpleButton5.Size = New System.Drawing.Size(82, 23)
        Me.SimpleButton5.TabIndex = 11
        Me.SimpleButton5.Text = "Approve"
        '
        'GroupControl3
        '
        Me.GroupControl3.Controls.Add(Me.Label1)
        Me.GroupControl3.Controls.Add(Me.SimpleButton7)
        Me.GroupControl3.Controls.Add(Me.SimpleButton5)
        Me.GroupControl3.Controls.Add(Me.SimpleButton6)
        Me.GroupControl3.Controls.Add(Me.TextBox2)
        Me.GroupControl3.Controls.Add(Me.LabelControl6)
        Me.GroupControl3.Controls.Add(Me.SimpleButton4)
        Me.GroupControl3.Controls.Add(Me.LabelControl5)
        Me.GroupControl3.Controls.Add(Me.TextBox1)
        Me.GroupControl3.Controls.Add(Me.TextBox4)
        Me.GroupControl3.Controls.Add(Me.LabelControl1)
        Me.GroupControl3.Controls.Add(Me.TextBox3)
        Me.GroupControl3.Controls.Add(Me.LabelControl4)
        Me.GroupControl3.Controls.Add(Me.LabelControl3)
        Me.GroupControl3.Controls.Add(Me.LabelControl2)
        Me.GroupControl3.Location = New System.Drawing.Point(859, 165)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(215, 279)
        Me.GroupControl3.TabIndex = 2
        Me.GroupControl3.Text = "Request"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 156)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Label1"
        Me.Label1.Visible = False
        '
        'SimpleButton7
        '
        Me.SimpleButton7.Location = New System.Drawing.Point(94, 251)
        Me.SimpleButton7.Name = "SimpleButton7"
        Me.SimpleButton7.Size = New System.Drawing.Size(82, 23)
        Me.SimpleButton7.TabIndex = 14
        Me.SimpleButton7.Text = "Reject"
        '
        'SimpleButton6
        '
        Me.SimpleButton6.Location = New System.Drawing.Point(90, 124)
        Me.SimpleButton6.Name = "SimpleButton6"
        Me.SimpleButton6.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButton6.TabIndex = 3
        Me.SimpleButton6.Text = "View"
        Me.SimpleButton6.Visible = False
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(4, 128)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(76, 13)
        Me.LabelControl6.TabIndex = 13
        Me.LabelControl6.Text = "See Details --->"
        Me.LabelControl6.Visible = False
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(96, 99)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(0, 13)
        Me.LabelControl5.TabIndex = 3
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(90, 70)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(117, 20)
        Me.TextBox4.TabIndex = 12
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(90, 40)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(117, 20)
        Me.TextBox3.TabIndex = 11
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(5, 72)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl4.TabIndex = 5
        Me.LabelControl4.Text = "Name :"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(5, 43)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(78, 13)
        Me.LabelControl3.TabIndex = 4
        Me.LabelControl3.Text = "Employee Code:"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(4, 100)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(84, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Type of request :"
        '
        'Timer1
        '
        '
        'Approvement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1077, 450)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.GroupControl1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1093, 489)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1093, 489)
        Me.Name = "Approvement"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Approvement"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        Me.GroupControl3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton4 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents SimpleButton5 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SimpleButton7 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton6 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Label1 As Label
    Friend WithEvents SimpleButton9 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton8 As DevExpress.XtraEditors.SimpleButton
End Class
