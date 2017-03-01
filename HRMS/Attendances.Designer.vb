<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Attendances
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Attendances))
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.btnFind = New DevExpress.XtraEditors.SimpleButton()
        Me.checkall = New System.Windows.Forms.RadioButton()
        Me.checkharian = New System.Windows.Forms.RadioButton()
        Me.checkbulanan = New System.Windows.Forms.RadioButton()
        Me.checkborongan = New System.Windows.Forms.RadioButton()
        Me.overtime = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.date1 = New System.Windows.Forms.DateTimePicker()
        Me.date2 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Result = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblname = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.txtpages = New DevExpress.XtraEditors.TextEdit()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridControl3 = New DevExpress.XtraGrid.GridControl()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtsav = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.overtime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.overtime.SuspendLayout()
        Me.XtraTabPage2.SuspendLayout()
        CType(Me.Result, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Result.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        CType(Me.txtpages.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtsav.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(2, 74)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1270, 565)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsFind.AlwaysVisible = True
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(18, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(106, 14)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Attendance Filter"
        '
        'btnFind
        '
        Me.btnFind.Image = CType(resources.GetObject("btnFind.Image"), System.Drawing.Image)
        Me.btnFind.Location = New System.Drawing.Point(555, 31)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(93, 32)
        Me.btnFind.TabIndex = 5
        Me.btnFind.Text = "Filter"
        '
        'checkall
        '
        Me.checkall.AutoSize = True
        Me.checkall.Location = New System.Drawing.Point(134, 15)
        Me.checkall.Name = "checkall"
        Me.checkall.Size = New System.Drawing.Size(36, 17)
        Me.checkall.TabIndex = 7
        Me.checkall.TabStop = True
        Me.checkall.Text = "All"
        Me.checkall.UseVisualStyleBackColor = True
        '
        'checkharian
        '
        Me.checkharian.AutoSize = True
        Me.checkharian.Location = New System.Drawing.Point(134, 38)
        Me.checkharian.Name = "checkharian"
        Me.checkharian.Size = New System.Drawing.Size(56, 17)
        Me.checkharian.TabIndex = 8
        Me.checkharian.TabStop = True
        Me.checkharian.Text = "Harian"
        Me.checkharian.UseVisualStyleBackColor = True
        '
        'checkbulanan
        '
        Me.checkbulanan.AutoSize = True
        Me.checkbulanan.Location = New System.Drawing.Point(198, 15)
        Me.checkbulanan.Name = "checkbulanan"
        Me.checkbulanan.Size = New System.Drawing.Size(64, 17)
        Me.checkbulanan.TabIndex = 9
        Me.checkbulanan.TabStop = True
        Me.checkbulanan.Text = "Bulanan"
        Me.checkbulanan.UseVisualStyleBackColor = True
        '
        'checkborongan
        '
        Me.checkborongan.AutoSize = True
        Me.checkborongan.Location = New System.Drawing.Point(198, 38)
        Me.checkborongan.Name = "checkborongan"
        Me.checkborongan.Size = New System.Drawing.Size(71, 17)
        Me.checkborongan.TabIndex = 10
        Me.checkborongan.TabStop = True
        Me.checkborongan.Text = "Borongan"
        Me.checkborongan.UseVisualStyleBackColor = True
        '
        'overtime
        '
        Me.overtime.Location = New System.Drawing.Point(795, 63)
        Me.overtime.Name = "overtime"
        Me.overtime.SelectedTabPage = Me.XtraTabPage2
        Me.overtime.Size = New System.Drawing.Size(482, 338)
        Me.overtime.TabIndex = 11
        Me.overtime.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage2})
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.DateTimePicker1)
        Me.XtraTabPage2.Controls.Add(Me.SimpleButton3)
        Me.XtraTabPage2.Controls.Add(Me.LabelControl3)
        Me.XtraTabPage2.Controls.Add(Me.txtsav)
        Me.XtraTabPage2.Controls.Add(Me.LabelControl2)
        Me.XtraTabPage2.Controls.Add(Me.Label10)
        Me.XtraTabPage2.Controls.Add(Me.Label9)
        Me.XtraTabPage2.Controls.Add(Me.Label8)
        Me.XtraTabPage2.Controls.Add(Me.Label4)
        Me.XtraTabPage2.Controls.Add(Me.GridControl3)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(476, 310)
        Me.XtraTabPage2.Text = "Overtime"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(665, 34)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(119, 23)
        Me.SimpleButton1.TabIndex = 12
        Me.SimpleButton1.Text = "Borongan Menu"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Location = New System.Drawing.Point(790, 34)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButton2.TabIndex = 13
        Me.SimpleButton2.Text = "Overtime"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(284, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Range Date"
        '
        'date1
        '
        Me.date1.Location = New System.Drawing.Point(338, 18)
        Me.date1.Name = "date1"
        Me.date1.Size = New System.Drawing.Size(200, 20)
        Me.date1.TabIndex = 15
        '
        'date2
        '
        Me.date2.Location = New System.Drawing.Point(338, 43)
        Me.date2.Name = "date2"
        Me.date2.Size = New System.Drawing.Size(200, 20)
        Me.date2.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(285, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "From"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(285, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "To"
        '
        'Result
        '
        Me.Result.Location = New System.Drawing.Point(665, 63)
        Me.Result.Name = "Result"
        Me.Result.SelectedTabPage = Me.XtraTabPage1
        Me.Result.Size = New System.Drawing.Size(441, 347)
        Me.Result.TabIndex = 83
        Me.Result.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1})
        Me.Result.Visible = False
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.GridControl2)
        Me.XtraTabPage1.Controls.Add(Me.Label6)
        Me.XtraTabPage1.Controls.Add(Me.Label5)
        Me.XtraTabPage1.Controls.Add(Me.lblname)
        Me.XtraTabPage1.Controls.Add(Me.Label7)
        Me.XtraTabPage1.Controls.Add(Me.LabelControl10)
        Me.XtraTabPage1.Controls.Add(Me.txtpages)
        Me.XtraTabPage1.Controls.Add(Me.btnSave)
        Me.XtraTabPage1.Controls.Add(Me.LabelControl11)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(435, 319)
        Me.XtraTabPage1.Text = "Result"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 262)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 13)
        Me.Label6.TabIndex = 89
        Me.Label6.Text = "Employee Code"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(105, 262)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 13)
        Me.Label5.TabIndex = 85
        Me.Label5.Text = "//"
        '
        'lblname
        '
        Me.lblname.AutoSize = True
        Me.lblname.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblname.Location = New System.Drawing.Point(107, 240)
        Me.lblname.Name = "lblname"
        Me.lblname.Size = New System.Drawing.Size(12, 14)
        Me.lblname.TabIndex = 88
        Me.lblname.Text = "-"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 240)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 13)
        Me.Label7.TabIndex = 87
        Me.Label7.Text = "Name"
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(268, 267)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl10.TabIndex = 85
        Me.LabelControl10.Text = "Lembar"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(210, 286)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(52, 23)
        Me.btnSave.TabIndex = 84
        Me.btnSave.Text = "Save"
        '
        'LabelControl11
        '
        Me.LabelControl11.Location = New System.Drawing.Point(208, 239)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(98, 13)
        Me.LabelControl11.TabIndex = 83
        Me.LabelControl11.Text = "Today's Work Result"
        '
        'txtpages
        '
        Me.txtpages.Location = New System.Drawing.Point(210, 260)
        Me.txtpages.Name = "txtpages"
        Me.txtpages.Size = New System.Drawing.Size(52, 20)
        Me.txtpages.TabIndex = 82
        '
        'GridControl2
        '
        Me.GridControl2.Location = New System.Drawing.Point(0, 0)
        Me.GridControl2.MainView = Me.GridView2
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.Size = New System.Drawing.Size(432, 223)
        Me.GridControl2.TabIndex = 90
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GridControl2
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsFind.AlwaysVisible = True
        Me.GridView2.OptionsView.ColumnAutoWidth = False
        '
        'GridControl3
        '
        Me.GridControl3.Location = New System.Drawing.Point(3, 3)
        Me.GridControl3.MainView = Me.GridView3
        Me.GridControl3.Name = "GridControl3"
        Me.GridControl3.Size = New System.Drawing.Size(470, 223)
        Me.GridControl3.TabIndex = 91
        Me.GridControl3.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.GridControl3
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsFind.AlwaysVisible = True
        Me.GridView3.OptionsView.ColumnAutoWidth = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 237)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 92
        Me.Label4.Text = "Name"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(15, 262)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 13)
        Me.Label8.TabIndex = 93
        Me.Label8.Text = "Employee Code"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(123, 237)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(12, 14)
        Me.Label9.TabIndex = 94
        Me.Label9.Text = "-"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(118, 262)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(17, 13)
        Me.Label10.TabIndex = 95
        Me.Label10.Text = "//"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(197, 235)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(75, 13)
        Me.LabelControl2.TabIndex = 96
        Me.LabelControl2.Text = "Overtime Hours"
        '
        'txtsav
        '
        Me.txtsav.Location = New System.Drawing.Point(197, 256)
        Me.txtsav.Name = "txtsav"
        Me.txtsav.Size = New System.Drawing.Size(52, 20)
        Me.txtsav.TabIndex = 97
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(255, 259)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(28, 13)
        Me.LabelControl3.TabIndex = 98
        Me.LabelControl3.Text = "Hours"
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Location = New System.Drawing.Point(403, 280)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(52, 23)
        Me.SimpleButton3.TabIndex = 99
        Me.SimpleButton3.Text = "Save"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(197, 282)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker1.TabIndex = 100
        '
        'Attendances
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1274, 637)
        Me.Controls.Add(Me.Result)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.date2)
        Me.Controls.Add(Me.date1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.overtime)
        Me.Controls.Add(Me.checkborongan)
        Me.Controls.Add(Me.checkbulanan)
        Me.Controls.Add(Me.checkharian)
        Me.Controls.Add(Me.checkall)
        Me.Controls.Add(Me.btnFind)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.GridControl1)
        Me.MaximumSize = New System.Drawing.Size(1290, 676)
        Me.MinimumSize = New System.Drawing.Size(1290, 676)
        Me.Name = "Attendances"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Attendances"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.overtime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.overtime.ResumeLayout(False)
        Me.XtraTabPage2.ResumeLayout(False)
        Me.XtraTabPage2.PerformLayout()
        CType(Me.Result, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Result.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        Me.XtraTabPage1.PerformLayout()
        CType(Me.txtpages.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtsav.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnFind As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents checkall As RadioButton
    Friend WithEvents checkharian As RadioButton
    Friend WithEvents checkbulanan As RadioButton
    Friend WithEvents checkborongan As RadioButton
    Friend WithEvents overtime As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label1 As Label
    Friend WithEvents date1 As DateTimePicker
    Friend WithEvents date2 As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Result As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblname As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtpages As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtsav As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents GridControl3 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents DateTimePicker1 As DateTimePicker
End Class
