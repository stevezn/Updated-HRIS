<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class addmenu
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
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.Overtime = New DevExpress.XtraTab.XtraTabPage()
        Me.Borongan = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtpages = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl3 = New DevExpress.XtraGrid.GridControl()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtsav = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.Overtime.SuspendLayout()
        Me.Borongan.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtpages.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtsav.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.Overtime
        Me.XtraTabControl1.Size = New System.Drawing.Size(507, 327)
        Me.XtraTabControl1.TabIndex = 0
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.Overtime, Me.Borongan})
        '
        'Overtime
        '
        Me.Overtime.Controls.Add(Me.SimpleButton1)
        Me.Overtime.Controls.Add(Me.LabelControl2)
        Me.Overtime.Controls.Add(Me.txtpages)
        Me.Overtime.Controls.Add(Me.LabelControl1)
        Me.Overtime.Controls.Add(Me.Label4)
        Me.Overtime.Controls.Add(Me.Label3)
        Me.Overtime.Controls.Add(Me.Label2)
        Me.Overtime.Controls.Add(Me.Label1)
        Me.Overtime.Controls.Add(Me.GridControl1)
        Me.Overtime.Name = "Overtime"
        Me.Overtime.Size = New System.Drawing.Size(501, 299)
        Me.Overtime.Text = "Overtime"
        '
        'Borongan
        '
        Me.Borongan.Controls.Add(Me.SimpleButton3)
        Me.Borongan.Controls.Add(Me.DateTimePicker1)
        Me.Borongan.Controls.Add(Me.LabelControl4)
        Me.Borongan.Controls.Add(Me.txtsav)
        Me.Borongan.Controls.Add(Me.LabelControl3)
        Me.Borongan.Controls.Add(Me.Label10)
        Me.Borongan.Controls.Add(Me.Label8)
        Me.Borongan.Controls.Add(Me.label9)
        Me.Borongan.Controls.Add(Me.Label5)
        Me.Borongan.Controls.Add(Me.GridControl3)
        Me.Borongan.Name = "Borongan"
        Me.Borongan.Size = New System.Drawing.Size(501, 299)
        Me.Borongan.Text = "Borongan"
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(3, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(502, 223)
        Me.GridControl1.TabIndex = 91
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsFind.AlwaysVisible = True
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 243)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 92
        Me.Label1.Text = "Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 269)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 93
        Me.Label2.Text = "Employee Code"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(146, 243)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 14)
        Me.Label3.TabIndex = 94
        Me.Label3.Text = "-"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(141, 264)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(17, 13)
        Me.Label4.TabIndex = 95
        Me.Label4.Text = "//"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(263, 232)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(98, 13)
        Me.LabelControl1.TabIndex = 96
        Me.LabelControl1.Text = "Today's Work Result"
        '
        'txtpages
        '
        Me.txtpages.Location = New System.Drawing.Point(263, 252)
        Me.txtpages.Name = "txtpages"
        Me.txtpages.Size = New System.Drawing.Size(52, 20)
        Me.txtpages.TabIndex = 97
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(326, 254)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl2.TabIndex = 98
        Me.LabelControl2.Text = "Lembar"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(263, 274)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(52, 23)
        Me.SimpleButton1.TabIndex = 99
        Me.SimpleButton1.Text = "Save"
        '
        'GridControl3
        '
        Me.GridControl3.Location = New System.Drawing.Point(0, 3)
        Me.GridControl3.MainView = Me.GridView3
        Me.GridControl3.Name = "GridControl3"
        Me.GridControl3.Size = New System.Drawing.Size(501, 223)
        Me.GridControl3.TabIndex = 92
        Me.GridControl3.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.GridControl3
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsFind.AlwaysVisible = True
        Me.GridView3.OptionsView.ColumnAutoWidth = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 232)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 93
        Me.Label5.Text = "Name"
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label9.Location = New System.Drawing.Point(117, 232)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(12, 14)
        Me.label9.TabIndex = 94
        Me.label9.Text = "-"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(11, 259)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 13)
        Me.Label8.TabIndex = 95
        Me.Label8.Text = "Employee Code"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(116, 259)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(17, 13)
        Me.Label10.TabIndex = 96
        Me.Label10.Text = "//"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(184, 233)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(75, 13)
        Me.LabelControl3.TabIndex = 97
        Me.LabelControl3.Text = "Overtime Hours"
        '
        'txtsav
        '
        Me.txtsav.Location = New System.Drawing.Point(184, 252)
        Me.txtsav.Name = "txtsav"
        Me.txtsav.Size = New System.Drawing.Size(52, 20)
        Me.txtsav.TabIndex = 98
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(242, 257)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(28, 13)
        Me.LabelControl4.TabIndex = 99
        Me.LabelControl4.Text = "Hours"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(183, 278)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker1.TabIndex = 101
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Location = New System.Drawing.Point(389, 273)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(52, 23)
        Me.SimpleButton3.TabIndex = 102
        Me.SimpleButton3.Text = "Save"
        '
        'addmenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(505, 324)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Name = "addmenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.Overtime.ResumeLayout(False)
        Me.Overtime.PerformLayout()
        Me.Borongan.ResumeLayout(False)
        Me.Borongan.PerformLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtpages.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtsav.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents Overtime As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents Borongan As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtpages As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControl3 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label5 As Label
    Friend WithEvents label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtsav As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
End Class
