<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Attendances
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

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
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtsav = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GridControl3 = New DevExpress.XtraGrid.GridControl()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.date1 = New System.Windows.Forms.DateTimePicker()
        Me.date2 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblname = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.txtpages = New DevExpress.XtraEditors.TextEdit()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem3 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem4 = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup3 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup4 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.SimpleButton4 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton5 = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.SimpleButton6 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton7 = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl4 = New DevExpress.XtraEditors.GroupControl()
        Me.SimpleButton9 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton8 = New DevExpress.XtraEditors.SimpleButton()
        Me.DateTimePicker3 = New System.Windows.Forms.DateTimePicker()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtsav.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtpages.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.GroupControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(198, 162)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1349, 750)
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
        Me.LabelControl1.Location = New System.Drawing.Point(31, 162)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(106, 14)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Attendance Filter"
        '
        'btnFind
        '
        Me.btnFind.Image = CType(resources.GetObject("btnFind.Image"), System.Drawing.Image)
        Me.btnFind.Location = New System.Drawing.Point(99, 312)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(93, 32)
        Me.btnFind.TabIndex = 5
        Me.btnFind.Text = "Filter"
        '
        'checkall
        '
        Me.checkall.AutoSize = True
        Me.checkall.Location = New System.Drawing.Point(12, 183)
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
        Me.checkharian.Location = New System.Drawing.Point(12, 206)
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
        Me.checkbulanan.Location = New System.Drawing.Point(81, 183)
        Me.checkbulanan.Name = "checkbulanan"
        Me.checkbulanan.Size = New System.Drawing.Size(63, 17)
        Me.checkbulanan.TabIndex = 9
        Me.checkbulanan.TabStop = True
        Me.checkbulanan.Text = "Bulanan"
        Me.checkbulanan.UseVisualStyleBackColor = True
        '
        'checkborongan
        '
        Me.checkborongan.AutoSize = True
        Me.checkborongan.Location = New System.Drawing.Point(81, 206)
        Me.checkborongan.Name = "checkborongan"
        Me.checkborongan.Size = New System.Drawing.Size(71, 17)
        Me.checkborongan.TabIndex = 10
        Me.checkborongan.TabStop = True
        Me.checkborongan.Text = "Borongan"
        Me.checkborongan.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(4, 22)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 21)
        Me.DateTimePicker1.TabIndex = 100
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Location = New System.Drawing.Point(299, 288)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(52, 23)
        Me.SimpleButton3.TabIndex = 99
        Me.SimpleButton3.Text = "Save"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(253, 292)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(28, 13)
        Me.LabelControl3.TabIndex = 98
        Me.LabelControl3.Text = "Hours"
        '
        'txtsav
        '
        Me.txtsav.Location = New System.Drawing.Point(195, 290)
        Me.txtsav.Name = "txtsav"
        Me.txtsav.Size = New System.Drawing.Size(52, 20)
        Me.txtsav.TabIndex = 97
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(195, 267)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(75, 13)
        Me.LabelControl2.TabIndex = 96
        Me.LabelControl2.Text = "Overtime Hours"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(114, 295)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(15, 13)
        Me.Label10.TabIndex = 95
        Me.Label10.Text = "//"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(116, 269)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(12, 14)
        Me.Label9.TabIndex = 94
        Me.Label9.Text = "-"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 294)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 13)
        Me.Label8.TabIndex = 93
        Me.Label8.Text = "Employee Code"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 268)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 92
        Me.Label4.Text = "Name"
        '
        'GridControl3
        '
        Me.GridControl3.Location = New System.Drawing.Point(4, 47)
        Me.GridControl3.MainView = Me.GridView3
        Me.GridControl3.Name = "GridControl3"
        Me.GridControl3.Size = New System.Drawing.Size(498, 206)
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(51, 235)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Range Date"
        '
        'date1
        '
        Me.date1.Location = New System.Drawing.Point(53, 255)
        Me.date1.Name = "date1"
        Me.date1.Size = New System.Drawing.Size(140, 21)
        Me.date1.TabIndex = 15
        '
        'date2
        '
        Me.date2.Location = New System.Drawing.Point(53, 285)
        Me.date2.Name = "date2"
        Me.date2.Size = New System.Drawing.Size(139, 21)
        Me.date2.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 259)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "From"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 289)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(19, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "To"
        '
        'GridControl2
        '
        Me.GridControl2.Location = New System.Drawing.Point(4, 48)
        Me.GridControl2.MainView = Me.GridView2
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.Size = New System.Drawing.Size(493, 205)
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
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 295)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 13)
        Me.Label6.TabIndex = 89
        Me.Label6.Text = "Employee Code"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(105, 295)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(15, 13)
        Me.Label5.TabIndex = 85
        Me.Label5.Text = "//"
        '
        'lblname
        '
        Me.lblname.AutoSize = True
        Me.lblname.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblname.Location = New System.Drawing.Point(108, 268)
        Me.lblname.Name = "lblname"
        Me.lblname.Size = New System.Drawing.Size(12, 14)
        Me.lblname.TabIndex = 88
        Me.lblname.Text = "-"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(5, 270)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 87
        Me.Label7.Text = "Name"
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(288, 293)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(20, 13)
        Me.LabelControl10.TabIndex = 85
        Me.LabelControl10.Text = "....."
        '
        'txtpages
        '
        Me.txtpages.Location = New System.Drawing.Point(230, 290)
        Me.txtpages.Name = "txtpages"
        Me.txtpages.Size = New System.Drawing.Size(52, 20)
        Me.txtpages.TabIndex = 82
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(338, 286)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(52, 23)
        Me.btnSave.TabIndex = 84
        Me.btnSave.Text = "Save"
        '
        'LabelControl11
        '
        Me.LabelControl11.Location = New System.Drawing.Point(231, 270)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(121, 13)
        Me.LabelControl11.TabIndex = 83
        Me.LabelControl11.Text = "Work Result on that date"
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.BarButtonItem1, Me.BarButtonItem2, Me.BarButtonItem3, Me.BarButtonItem4})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 5
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl1.Size = New System.Drawing.Size(810, 144)
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Overtime"
        Me.BarButtonItem1.Glyph = CType(resources.GetObject("BarButtonItem1.Glyph"), System.Drawing.Image)
        Me.BarButtonItem1.Id = 1
        Me.BarButtonItem1.Name = "BarButtonItem1"
        Me.BarButtonItem1.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarButtonItem2
        '
        Me.BarButtonItem2.Caption = "Borongan"
        Me.BarButtonItem2.Glyph = CType(resources.GetObject("BarButtonItem2.Glyph"), System.Drawing.Image)
        Me.BarButtonItem2.Id = 2
        Me.BarButtonItem2.Name = "BarButtonItem2"
        Me.BarButtonItem2.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarButtonItem3
        '
        Me.BarButtonItem3.Caption = "Menu"
        Me.BarButtonItem3.Glyph = CType(resources.GetObject("BarButtonItem3.Glyph"), System.Drawing.Image)
        Me.BarButtonItem3.Id = 3
        Me.BarButtonItem3.Name = "BarButtonItem3"
        Me.BarButtonItem3.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarButtonItem4
        '
        Me.BarButtonItem4.Caption = "Show Attendance Records"
        Me.BarButtonItem4.Glyph = CType(resources.GetObject("BarButtonItem4.Glyph"), System.Drawing.Image)
        Me.BarButtonItem4.Id = 4
        Me.BarButtonItem4.Name = "BarButtonItem4"
        Me.BarButtonItem4.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1, Me.RibbonPageGroup2, Me.RibbonPageGroup3, Me.RibbonPageGroup4})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "Menu"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BarButtonItem1)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "                                               "
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.ItemLinks.Add(Me.BarButtonItem2)
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        Me.RibbonPageGroup2.Text = "                                               "
        '
        'RibbonPageGroup3
        '
        Me.RibbonPageGroup3.ItemLinks.Add(Me.BarButtonItem3)
        Me.RibbonPageGroup3.Name = "RibbonPageGroup3"
        Me.RibbonPageGroup3.Text = "                                               "
        '
        'RibbonPageGroup4
        '
        Me.RibbonPageGroup4.ItemLinks.Add(Me.BarButtonItem4)
        Me.RibbonPageGroup4.Name = "RibbonPageGroup4"
        Me.RibbonPageGroup4.Text = "                                               "
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.GroupControl2)
        Me.GroupControl1.Controls.Add(Me.Label11)
        Me.GroupControl1.Controls.Add(Me.DateTimePicker2)
        Me.GroupControl1.Controls.Add(Me.SimpleButton4)
        Me.GroupControl1.Controls.Add(Me.SimpleButton5)
        Me.GroupControl1.Location = New System.Drawing.Point(299, 140)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(302, 108)
        Me.GroupControl1.TabIndex = 87
        Me.GroupControl1.Visible = False
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.SimpleButton2)
        Me.GroupControl2.Location = New System.Drawing.Point(4, 6)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(298, 26)
        Me.GroupControl2.TabIndex = 7
        Me.GroupControl2.Text = "View Attendance Record"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Image = CType(resources.GetObject("SimpleButton2.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(270, 1)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(23, 21)
        Me.SimpleButton2.TabIndex = 0
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(4, 35)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(292, 13)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Select the date you want to display the attendance record:"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(5, 52)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(294, 21)
        Me.DateTimePicker2.TabIndex = 5
        '
        'SimpleButton4
        '
        Me.SimpleButton4.Location = New System.Drawing.Point(224, 79)
        Me.SimpleButton4.Name = "SimpleButton4"
        Me.SimpleButton4.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButton4.TabIndex = 9
        Me.SimpleButton4.Text = "Cancel"
        '
        'SimpleButton5
        '
        Me.SimpleButton5.Location = New System.Drawing.Point(148, 79)
        Me.SimpleButton5.Name = "SimpleButton5"
        Me.SimpleButton5.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButton5.TabIndex = 8
        Me.SimpleButton5.Text = "OK"
        '
        'GroupControl3
        '
        Me.GroupControl3.Controls.Add(Me.SimpleButton6)
        Me.GroupControl3.Controls.Add(Me.SimpleButton7)
        Me.GroupControl3.Controls.Add(Me.SimpleButton3)
        Me.GroupControl3.Controls.Add(Me.DateTimePicker1)
        Me.GroupControl3.Controls.Add(Me.GridControl3)
        Me.GroupControl3.Controls.Add(Me.Label4)
        Me.GroupControl3.Controls.Add(Me.LabelControl3)
        Me.GroupControl3.Controls.Add(Me.Label9)
        Me.GroupControl3.Controls.Add(Me.txtsav)
        Me.GroupControl3.Controls.Add(Me.Label8)
        Me.GroupControl3.Controls.Add(Me.LabelControl2)
        Me.GroupControl3.Controls.Add(Me.Label10)
        Me.GroupControl3.Location = New System.Drawing.Point(11, 140)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(506, 325)
        Me.GroupControl3.TabIndex = 1
        Me.GroupControl3.Text = "Overtime"
        Me.GroupControl3.Visible = False
        '
        'SimpleButton6
        '
        Me.SimpleButton6.Image = CType(resources.GetObject("SimpleButton6.Image"), System.Drawing.Image)
        Me.SimpleButton6.Location = New System.Drawing.Point(480, 1)
        Me.SimpleButton6.Name = "SimpleButton6"
        Me.SimpleButton6.Size = New System.Drawing.Size(23, 21)
        Me.SimpleButton6.TabIndex = 101
        '
        'SimpleButton7
        '
        Me.SimpleButton7.Location = New System.Drawing.Point(206, 21)
        Me.SimpleButton7.Name = "SimpleButton7"
        Me.SimpleButton7.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButton7.TabIndex = 102
        Me.SimpleButton7.Text = "Show"
        '
        'GroupControl4
        '
        Me.GroupControl4.Controls.Add(Me.SimpleButton9)
        Me.GroupControl4.Controls.Add(Me.SimpleButton8)
        Me.GroupControl4.Controls.Add(Me.DateTimePicker3)
        Me.GroupControl4.Controls.Add(Me.LabelControl10)
        Me.GroupControl4.Controls.Add(Me.Label5)
        Me.GroupControl4.Controls.Add(Me.btnSave)
        Me.GroupControl4.Controls.Add(Me.txtpages)
        Me.GroupControl4.Controls.Add(Me.Label6)
        Me.GroupControl4.Controls.Add(Me.GridControl2)
        Me.GroupControl4.Controls.Add(Me.LabelControl11)
        Me.GroupControl4.Controls.Add(Me.Label7)
        Me.GroupControl4.Controls.Add(Me.lblname)
        Me.GroupControl4.Location = New System.Drawing.Point(112, 140)
        Me.GroupControl4.Name = "GroupControl4"
        Me.GroupControl4.Size = New System.Drawing.Size(502, 325)
        Me.GroupControl4.TabIndex = 89
        Me.GroupControl4.Text = "Borongan"
        Me.GroupControl4.Visible = False
        '
        'SimpleButton9
        '
        Me.SimpleButton9.Location = New System.Drawing.Point(209, 22)
        Me.SimpleButton9.Name = "SimpleButton9"
        Me.SimpleButton9.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButton9.TabIndex = 104
        Me.SimpleButton9.Text = "Show"
        '
        'SimpleButton8
        '
        Me.SimpleButton8.Image = CType(resources.GetObject("SimpleButton8.Image"), System.Drawing.Image)
        Me.SimpleButton8.Location = New System.Drawing.Point(476, 4)
        Me.SimpleButton8.Name = "SimpleButton8"
        Me.SimpleButton8.Size = New System.Drawing.Size(23, 21)
        Me.SimpleButton8.TabIndex = 103
        '
        'DateTimePicker3
        '
        Me.DateTimePicker3.Location = New System.Drawing.Point(5, 24)
        Me.DateTimePicker3.Name = "DateTimePicker3"
        Me.DateTimePicker3.Size = New System.Drawing.Size(200, 21)
        Me.DateTimePicker3.TabIndex = 101
        '
        'Attendances
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(810, 574)
        Me.Controls.Add(Me.GroupControl4)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.date2)
        Me.Controls.Add(Me.date1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.checkborongan)
        Me.Controls.Add(Me.checkbulanan)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.checkharian)
        Me.Controls.Add(Me.checkall)
        Me.Controls.Add(Me.btnFind)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.Name = "Attendances"
        Me.Ribbon = Me.RibbonControl1
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Attendances"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtsav.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtpages.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        Me.GroupControl3.PerformLayout()
        CType(Me.GroupControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl4.ResumeLayout(False)
        Me.GroupControl4.PerformLayout()
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
    Friend WithEvents Label1 As Label
    Friend WithEvents date1 As DateTimePicker
    Friend WithEvents date2 As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
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
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem3 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPageGroup3 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label11 As Label
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents SimpleButton4 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton5 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SimpleButton6 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton7 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl4 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SimpleButton8 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DateTimePicker3 As DateTimePicker
    Friend WithEvents SimpleButton9 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BarButtonItem4 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup4 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
End Class
