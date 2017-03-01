<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RecProcess
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RecProcess))
        Me.lcphone = New DevExpress.XtraLayout.LayoutControlItem()
        Me.txtphone = New DevExpress.XtraEditors.TextEdit()
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.barJudul = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem3 = New DevExpress.XtraBars.BarButtonItem()
        Me.Employee = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.txtinterviewdate = New System.Windows.Forms.DateTimePicker()
        Me.txtreason = New DevExpress.Tutorials.Controls.RichTextBoxEx()
        Me.txtfullname = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.txtinterview = New DevExpress.XtraEditors.TextEdit()
        Me.txtstatus = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.txtaddress = New DevExpress.XtraEditors.TextEdit()
        Me.txtidcard = New DevExpress.XtraEditors.TextEdit()
        Me.txtid = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.lcid = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lcidcard = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lcaddress = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lcinterview = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lcfullname = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lcreason = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lcstats = New DevExpress.XtraLayout.LayoutControlItem()
        Me.pictureEdit = New System.Windows.Forms.PictureBox()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.lcview = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButton4 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnView = New DevExpress.XtraEditors.SimpleButton()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.RibbonPageGroup3 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.BarButtonItem4 = New DevExpress.XtraBars.BarButtonItem()
        CType(Me.lcphone, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtphone.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtfullname.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtinterview.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtstatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtaddress.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtidcard.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtid.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcidcard, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcaddress, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcinterview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcfullname, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcreason, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcstats, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lcphone
        '
        Me.lcphone.Control = Me.txtphone
        Me.lcphone.CustomizationFormText = "Phone Number"
        Me.lcphone.Location = New System.Drawing.Point(0, 120)
        Me.lcphone.Name = "lcphone"
        Me.lcphone.Size = New System.Drawing.Size(289, 24)
        Me.lcphone.Text = "Phone Number"
        Me.lcphone.TextSize = New System.Drawing.Size(87, 13)
        '
        'txtphone
        '
        Me.txtphone.EditValue = ""
        Me.txtphone.Location = New System.Drawing.Point(102, 132)
        Me.txtphone.MenuManager = Me.RibbonControl1
        Me.txtphone.Name = "txtphone"
        Me.txtphone.Size = New System.Drawing.Size(195, 20)
        Me.txtphone.StyleController = Me.LayoutControl1
        Me.txtphone.TabIndex = 13
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.BarButtonItem1, Me.barJudul, Me.BarButtonItem2, Me.BarButtonItem3, Me.BarButtonItem4})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 7
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.Employee})
        Me.RibbonControl1.Size = New System.Drawing.Size(883, 144)
        Me.RibbonControl1.Toolbar.ItemLinks.Add(Me.barJudul)
        Me.RibbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Above
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Recruitment Progress"
        Me.BarButtonItem1.Glyph = CType(resources.GetObject("BarButtonItem1.Glyph"), System.Drawing.Image)
        Me.BarButtonItem1.Id = 1
        Me.BarButtonItem1.Name = "BarButtonItem1"
        Me.BarButtonItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'barJudul
        '
        Me.barJudul.Caption = "barJudul"
        Me.barJudul.Id = 3
        Me.barJudul.Name = "barJudul"
        '
        'BarButtonItem2
        '
        Me.BarButtonItem2.Caption = "Change Data"
        Me.BarButtonItem2.Glyph = CType(resources.GetObject("BarButtonItem2.Glyph"), System.Drawing.Image)
        Me.BarButtonItem2.Id = 4
        Me.BarButtonItem2.Name = "BarButtonItem2"
        Me.BarButtonItem2.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'BarButtonItem3
        '
        Me.BarButtonItem3.Caption = "Analytical SKills"
        Me.BarButtonItem3.Glyph = CType(resources.GetObject("BarButtonItem3.Glyph"), System.Drawing.Image)
        Me.BarButtonItem3.Id = 5
        Me.BarButtonItem3.Name = "BarButtonItem3"
        Me.BarButtonItem3.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'Employee
        '
        Me.Employee.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1, Me.RibbonPageGroup2, Me.RibbonPageGroup3})
        Me.Employee.Name = "Employee"
        Me.Employee.Text = "Recruitment"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BarButtonItem1)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "                                                 "
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.ItemLinks.Add(Me.BarButtonItem3)
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        Me.RibbonPageGroup2.Text = "                                                 "
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.txtinterviewdate)
        Me.LayoutControl1.Controls.Add(Me.txtreason)
        Me.LayoutControl1.Controls.Add(Me.txtfullname)
        Me.LayoutControl1.Controls.Add(Me.txtinterview)
        Me.LayoutControl1.Controls.Add(Me.txtstatus)
        Me.LayoutControl1.Controls.Add(Me.txtphone)
        Me.LayoutControl1.Controls.Add(Me.txtaddress)
        Me.LayoutControl1.Controls.Add(Me.txtidcard)
        Me.LayoutControl1.Controls.Add(Me.txtid)
        Me.LayoutControl1.Location = New System.Drawing.Point(5, 24)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(409, 411, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(309, 327)
        Me.LayoutControl1.TabIndex = 29
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'txtinterviewdate
        '
        Me.txtinterviewdate.Location = New System.Drawing.Point(102, 180)
        Me.txtinterviewdate.Name = "txtinterviewdate"
        Me.txtinterviewdate.Size = New System.Drawing.Size(195, 21)
        Me.txtinterviewdate.TabIndex = 35
        '
        'txtreason
        '
        Me.txtreason.Location = New System.Drawing.Point(102, 204)
        Me.txtreason.Name = "txtreason"
        Me.txtreason.Size = New System.Drawing.Size(195, 111)
        Me.txtreason.TabIndex = 34
        Me.txtreason.Text = ""
        '
        'txtfullname
        '
        Me.txtfullname.Location = New System.Drawing.Point(102, 12)
        Me.txtfullname.MenuManager = Me.RibbonControl1
        Me.txtfullname.Name = "txtfullname"
        Me.txtfullname.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtfullname.Size = New System.Drawing.Size(195, 20)
        Me.txtfullname.StyleController = Me.LayoutControl1
        Me.txtfullname.TabIndex = 31
        '
        'txtinterview
        '
        Me.txtinterview.Location = New System.Drawing.Point(102, 60)
        Me.txtinterview.MenuManager = Me.RibbonControl1
        Me.txtinterview.Name = "txtinterview"
        Me.txtinterview.Size = New System.Drawing.Size(195, 20)
        Me.txtinterview.StyleController = Me.LayoutControl1
        Me.txtinterview.TabIndex = 28
        '
        'txtstatus
        '
        Me.txtstatus.Location = New System.Drawing.Point(102, 156)
        Me.txtstatus.MenuManager = Me.RibbonControl1
        Me.txtstatus.Name = "txtstatus"
        Me.txtstatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtstatus.Properties.Items.AddRange(New Object() {"Pending", "In Progress", "Accepted", "Rejected", "Blocked"})
        Me.txtstatus.Size = New System.Drawing.Size(195, 20)
        Me.txtstatus.StyleController = Me.LayoutControl1
        Me.txtstatus.TabIndex = 27
        '
        'txtaddress
        '
        Me.txtaddress.Location = New System.Drawing.Point(102, 108)
        Me.txtaddress.MenuManager = Me.RibbonControl1
        Me.txtaddress.Name = "txtaddress"
        Me.txtaddress.Size = New System.Drawing.Size(195, 20)
        Me.txtaddress.StyleController = Me.LayoutControl1
        Me.txtaddress.TabIndex = 10
        '
        'txtidcard
        '
        Me.txtidcard.Location = New System.Drawing.Point(102, 84)
        Me.txtidcard.MenuManager = Me.RibbonControl1
        Me.txtidcard.Name = "txtidcard"
        Me.txtidcard.Size = New System.Drawing.Size(195, 20)
        Me.txtidcard.StyleController = Me.LayoutControl1
        Me.txtidcard.TabIndex = 7
        '
        'txtid
        '
        Me.txtid.Enabled = False
        Me.txtid.Location = New System.Drawing.Point(102, 36)
        Me.txtid.MenuManager = Me.RibbonControl1
        Me.txtid.Name = "txtid"
        Me.txtid.Size = New System.Drawing.Size(195, 20)
        Me.txtid.StyleController = Me.LayoutControl1
        Me.txtid.TabIndex = 6
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "LayoutControlGroup1"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.lcid, Me.lcidcard, Me.lcaddress, Me.lcphone, Me.lcinterview, Me.lcfullname, Me.lcreason, Me.LayoutControlItem1, Me.lcstats})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(309, 327)
        Me.LayoutControlGroup1.Text = "LayoutControlGroup1"
        Me.LayoutControlGroup1.TextVisible = False
        '
        'lcid
        '
        Me.lcid.Control = Me.txtid
        Me.lcid.CustomizationFormText = "ID Rec"
        Me.lcid.Location = New System.Drawing.Point(0, 24)
        Me.lcid.Name = "lcid"
        Me.lcid.Size = New System.Drawing.Size(289, 24)
        Me.lcid.Text = "ID Rec"
        Me.lcid.TextSize = New System.Drawing.Size(87, 13)
        '
        'lcidcard
        '
        Me.lcidcard.Control = Me.txtidcard
        Me.lcidcard.CustomizationFormText = "LayoutControlItem4"
        Me.lcidcard.Location = New System.Drawing.Point(0, 72)
        Me.lcidcard.Name = "lcidcard"
        Me.lcidcard.Size = New System.Drawing.Size(289, 24)
        Me.lcidcard.Text = "ID Number"
        Me.lcidcard.TextSize = New System.Drawing.Size(87, 13)
        '
        'lcaddress
        '
        Me.lcaddress.Control = Me.txtaddress
        Me.lcaddress.CustomizationFormText = "Address"
        Me.lcaddress.Location = New System.Drawing.Point(0, 96)
        Me.lcaddress.Name = "lcaddress"
        Me.lcaddress.Size = New System.Drawing.Size(289, 24)
        Me.lcaddress.Text = "Address"
        Me.lcaddress.TextSize = New System.Drawing.Size(87, 13)
        '
        'lcinterview
        '
        Me.lcinterview.Control = Me.txtinterview
        Me.lcinterview.CustomizationFormText = "Interview Times"
        Me.lcinterview.Location = New System.Drawing.Point(0, 48)
        Me.lcinterview.Name = "lcinterview"
        Me.lcinterview.Size = New System.Drawing.Size(289, 24)
        Me.lcinterview.Text = "Interview Times"
        Me.lcinterview.TextSize = New System.Drawing.Size(87, 13)
        '
        'lcfullname
        '
        Me.lcfullname.Control = Me.txtfullname
        Me.lcfullname.CustomizationFormText = "Full Name"
        Me.lcfullname.Location = New System.Drawing.Point(0, 0)
        Me.lcfullname.Name = "lcfullname"
        Me.lcfullname.Size = New System.Drawing.Size(289, 24)
        Me.lcfullname.Text = "Full Name"
        Me.lcfullname.TextSize = New System.Drawing.Size(87, 13)
        '
        'lcreason
        '
        Me.lcreason.Control = Me.txtreason
        Me.lcreason.CustomizationFormText = "Reason"
        Me.lcreason.Location = New System.Drawing.Point(0, 192)
        Me.lcreason.Name = "lcreason"
        Me.lcreason.Size = New System.Drawing.Size(289, 115)
        Me.lcreason.Text = "Reason"
        Me.lcreason.TextSize = New System.Drawing.Size(87, 13)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtinterviewdate
        Me.LayoutControlItem1.CustomizationFormText = "Tanggal Interview"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 168)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(289, 24)
        Me.LayoutControlItem1.Text = "Tanggal Interview"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(87, 13)
        '
        'lcstats
        '
        Me.lcstats.Control = Me.txtstatus
        Me.lcstats.CustomizationFormText = "Status"
        Me.lcstats.Location = New System.Drawing.Point(0, 144)
        Me.lcstats.Name = "lcstats"
        Me.lcstats.Size = New System.Drawing.Size(289, 24)
        Me.lcstats.Text = "Status"
        Me.lcstats.TextSize = New System.Drawing.Size(87, 13)
        '
        'pictureEdit
        '
        Me.pictureEdit.Image = Global.HRMS.My.Resources.Resources.user_icon_6
        Me.pictureEdit.Location = New System.Drawing.Point(308, 33)
        Me.pictureEdit.Name = "pictureEdit"
        Me.pictureEdit.Size = New System.Drawing.Size(148, 157)
        Me.pictureEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictureEdit.TabIndex = 30
        Me.pictureEdit.TabStop = False
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.lcview)
        Me.GroupControl1.Controls.Add(Me.SimpleButton4)
        Me.GroupControl1.Controls.Add(Me.SimpleButton3)
        Me.GroupControl1.Controls.Add(Me.SimpleButton2)
        Me.GroupControl1.Controls.Add(Me.GridControl1)
        Me.GroupControl1.Controls.Add(Me.SimpleButton1)
        Me.GroupControl1.Controls.Add(Me.btnView)
        Me.GroupControl1.Controls.Add(Me.pictureEdit)
        Me.GroupControl1.Controls.Add(Me.LayoutControl1)
        Me.GroupControl1.Location = New System.Drawing.Point(0, 141)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(880, 396)
        Me.GroupControl1.TabIndex = 35
        '
        'lcview
        '
        Me.lcview.Appearance.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lcview.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lcview.Location = New System.Drawing.Point(474, 69)
        Me.lcview.Name = "lcview"
        Me.lcview.Size = New System.Drawing.Size(5, 17)
        Me.lcview.TabIndex = 37
        Me.lcview.Text = "-"
        '
        'SimpleButton4
        '
        Me.SimpleButton4.Image = CType(resources.GetObject("SimpleButton4.Image"), System.Drawing.Image)
        Me.SimpleButton4.Location = New System.Drawing.Point(683, 32)
        Me.SimpleButton4.Name = "SimpleButton4"
        Me.SimpleButton4.Size = New System.Drawing.Size(105, 37)
        Me.SimpleButton4.TabIndex = 38
        Me.SimpleButton4.Text = "Processed"
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Image = CType(resources.GetObject("SimpleButton3.Image"), System.Drawing.Image)
        Me.SimpleButton3.Location = New System.Drawing.Point(462, 32)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(106, 38)
        Me.SimpleButton3.TabIndex = 38
        Me.SimpleButton3.Text = "Pending"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Image = CType(resources.GetObject("SimpleButton2.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(574, 32)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(103, 38)
        Me.SimpleButton2.TabIndex = 37
        Me.SimpleButton2.Text = "In Progress"
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(460, 87)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.MenuManager = Me.RibbonControl1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(415, 288)
        Me.GridControl1.TabIndex = 34
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsFind.AlwaysVisible = True
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Image = CType(resources.GetObject("SimpleButton1.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(198, 346)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(104, 38)
        Me.SimpleButton1.TabIndex = 32
        Me.SimpleButton1.Text = "Change"
        '
        'btnView
        '
        Me.btnView.Image = CType(resources.GetObject("btnView.Image"), System.Drawing.Image)
        Me.btnView.Location = New System.Drawing.Point(308, 196)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(146, 38)
        Me.btnView.StyleController = Me.LayoutControl1
        Me.btnView.TabIndex = 31
        Me.btnView.Text = "View CV"
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'RibbonPageGroup3
        '
        Me.RibbonPageGroup3.ItemLinks.Add(Me.BarButtonItem4)
        Me.RibbonPageGroup3.Name = "RibbonPageGroup3"
        Me.RibbonPageGroup3.Text = "                                                 "
        '
        'BarButtonItem4
        '
        Me.BarButtonItem4.Caption = "Rating"
        Me.BarButtonItem4.Glyph = CType(resources.GetObject("BarButtonItem4.Glyph"), System.Drawing.Image)
        Me.BarButtonItem4.Id = 6
        Me.BarButtonItem4.Name = "BarButtonItem4"
        Me.BarButtonItem4.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'RecProcess
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(883, 539)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.MaximumSize = New System.Drawing.Size(893, 544)
        Me.MinimumSize = New System.Drawing.Size(893, 544)
        Me.Name = "RecProcess"
        Me.Ribbon = Me.RibbonControl1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recruitment Progress"
        CType(Me.lcphone, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtphone.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtfullname.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtinterview.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtstatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtaddress.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtidcard.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtid.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcidcard, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcaddress, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcinterview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcfullname, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcreason, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcstats, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lcphone As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtphone As DevExpress.XtraEditors.TextEdit
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barJudul As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Employee As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents txtreason As DevExpress.Tutorials.Controls.RichTextBoxEx
    Friend WithEvents txtfullname As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents txtinterview As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtstatus As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents txtaddress As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtidcard As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtid As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents lcid As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lcidcard As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lcaddress As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lcstats As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lcinterview As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lcfullname As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lcreason As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents pictureEdit As PictureBox
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SimpleButton4 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lcview As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtinterviewdate As DateTimePicker
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents BarButtonItem3 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BarButtonItem4 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup3 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
End Class
