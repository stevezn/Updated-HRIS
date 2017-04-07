<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RotasiMutasi
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RotasiMutasi))
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.txtDate = New DevExpress.XtraEditors.DateEdit()
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.barbuttonitem3 = New DevExpress.XtraBars.BarButtonItem()
        Me.barJudul = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem4 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem5 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem6 = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.txtnamakaryawan = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.txtEmpCode = New DevExpress.XtraEditors.TextEdit()
        Me.txtCompcode = New DevExpress.XtraEditors.TextEdit()
        Me.btnChange = New DevExpress.XtraEditors.SimpleButton()
        Me.txtChange = New DevExpress.XtraEditors.TextEdit()
        Me.txtPosition = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.lccurpos = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lcRotasi = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lcbutton = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lcompcode = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lcempcode = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lcfullnames = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lctime = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtnamakaryawan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEmpCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCompcode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtChange.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lccurpos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcRotasi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcbutton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcompcode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcempcode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcfullnames, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lctime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.LayoutControl1)
        Me.GroupControl1.Location = New System.Drawing.Point(10, 156)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(484, 213)
        Me.GroupControl1.TabIndex = 5
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.SimpleButton1)
        Me.LayoutControl1.Controls.Add(Me.txtDate)
        Me.LayoutControl1.Controls.Add(Me.txtnamakaryawan)
        Me.LayoutControl1.Controls.Add(Me.txtEmpCode)
        Me.LayoutControl1.Controls.Add(Me.txtCompcode)
        Me.LayoutControl1.Controls.Add(Me.btnChange)
        Me.LayoutControl1.Controls.Add(Me.txtChange)
        Me.LayoutControl1.Controls.Add(Me.txtPosition)
        Me.LayoutControl1.Location = New System.Drawing.Point(5, 24)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(476, 183)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Image = CType(resources.GetObject("SimpleButton1.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(231, 156)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(216, 38)
        Me.SimpleButton1.StyleController = Me.LayoutControl1
        Me.SimpleButton1.TabIndex = 10
        Me.SimpleButton1.Text = "Reset "
        '
        'txtDate
        '
        Me.txtDate.EditValue = Nothing
        Me.txtDate.Location = New System.Drawing.Point(92, 132)
        Me.txtDate.MenuManager = Me.RibbonControl1
        Me.txtDate.Name = "txtDate"
        Me.txtDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtDate.Properties.CalendarTimeProperties.CloseUpKey = New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4)
        Me.txtDate.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.[Default]
        Me.txtDate.Size = New System.Drawing.Size(355, 20)
        Me.txtDate.StyleController = Me.LayoutControl1
        Me.txtDate.TabIndex = 9
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.BarButtonItem1, Me.BarButtonItem2, Me.barbuttonitem3, Me.barJudul, Me.BarButtonItem4, Me.BarButtonItem5, Me.BarButtonItem6})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 13
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl1.Size = New System.Drawing.Size(492, 174)
        Me.RibbonControl1.Toolbar.ItemLinks.Add(Me.barJudul)
        Me.RibbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Below
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Rotasi"
        Me.BarButtonItem1.Glyph = CType(resources.GetObject("BarButtonItem1.Glyph"), System.Drawing.Image)
        Me.BarButtonItem1.Id = 1
        Me.BarButtonItem1.Name = "BarButtonItem1"
        Me.BarButtonItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'BarButtonItem2
        '
        Me.BarButtonItem2.Caption = "Demosi"
        Me.BarButtonItem2.Glyph = CType(resources.GetObject("BarButtonItem2.Glyph"), System.Drawing.Image)
        Me.BarButtonItem2.Id = 2
        Me.BarButtonItem2.Name = "BarButtonItem2"
        Me.BarButtonItem2.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'barbuttonitem3
        '
        Me.barbuttonitem3.Caption = "Surat Peringatan 3"
        Me.barbuttonitem3.Glyph = CType(resources.GetObject("barbuttonitem3.Glyph"), System.Drawing.Image)
        Me.barbuttonitem3.Id = 3
        Me.barbuttonitem3.Name = "barbuttonitem3"
        Me.barbuttonitem3.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'barJudul
        '
        Me.barJudul.Caption = "BarButtonItem4"
        Me.barJudul.Id = 4
        Me.barJudul.Name = "barJudul"
        '
        'BarButtonItem4
        '
        Me.BarButtonItem4.Caption = "Rotasi History"
        Me.BarButtonItem4.Glyph = CType(resources.GetObject("BarButtonItem4.Glyph"), System.Drawing.Image)
        Me.BarButtonItem4.Id = 9
        Me.BarButtonItem4.Name = "BarButtonItem4"
        Me.BarButtonItem4.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'BarButtonItem5
        '
        Me.BarButtonItem5.Caption = "Demosi History"
        Me.BarButtonItem5.Glyph = CType(resources.GetObject("BarButtonItem5.Glyph"), System.Drawing.Image)
        Me.BarButtonItem5.Id = 10
        Me.BarButtonItem5.Name = "BarButtonItem5"
        Me.BarButtonItem5.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'BarButtonItem6
        '
        Me.BarButtonItem6.Caption = "DemosiHistory"
        Me.BarButtonItem6.Glyph = CType(resources.GetObject("BarButtonItem6.Glyph"), System.Drawing.Image)
        Me.BarButtonItem6.Id = 12
        Me.BarButtonItem6.Name = "BarButtonItem6"
        Me.BarButtonItem6.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1, Me.RibbonPageGroup2})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "Rotasi and Demosi"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.Glyph = CType(resources.GetObject("RibbonPageGroup1.Glyph"), System.Drawing.Image)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BarButtonItem1)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BarButtonItem4)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.ItemLinks.Add(Me.BarButtonItem2)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.BarButtonItem6)
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        '
        'txtnamakaryawan
        '
        Me.txtnamakaryawan.Location = New System.Drawing.Point(92, 12)
        Me.txtnamakaryawan.MenuManager = Me.RibbonControl1
        Me.txtnamakaryawan.Name = "txtnamakaryawan"
        Me.txtnamakaryawan.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtnamakaryawan.Size = New System.Drawing.Size(355, 20)
        Me.txtnamakaryawan.StyleController = Me.LayoutControl1
        Me.txtnamakaryawan.TabIndex = 8
        '
        'txtEmpCode
        '
        Me.txtEmpCode.Enabled = False
        Me.txtEmpCode.Location = New System.Drawing.Point(92, 36)
        Me.txtEmpCode.MenuManager = Me.RibbonControl1
        Me.txtEmpCode.Name = "txtEmpCode"
        Me.txtEmpCode.Size = New System.Drawing.Size(355, 20)
        Me.txtEmpCode.StyleController = Me.LayoutControl1
        Me.txtEmpCode.TabIndex = 6
        '
        'txtCompcode
        '
        Me.txtCompcode.Enabled = False
        Me.txtCompcode.Location = New System.Drawing.Point(92, 60)
        Me.txtCompcode.MenuManager = Me.RibbonControl1
        Me.txtCompcode.Name = "txtCompcode"
        Me.txtCompcode.Size = New System.Drawing.Size(355, 20)
        Me.txtCompcode.StyleController = Me.LayoutControl1
        Me.txtCompcode.TabIndex = 7
        '
        'btnChange
        '
        Me.btnChange.Image = CType(resources.GetObject("btnChange.Image"), System.Drawing.Image)
        Me.btnChange.Location = New System.Drawing.Point(12, 156)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(215, 38)
        Me.btnChange.StyleController = Me.LayoutControl1
        Me.btnChange.TabIndex = 4
        Me.btnChange.Text = "Change"
        '
        'txtChange
        '
        Me.txtChange.Location = New System.Drawing.Point(92, 108)
        Me.txtChange.MenuManager = Me.RibbonControl1
        Me.txtChange.Name = "txtChange"
        Me.txtChange.Size = New System.Drawing.Size(355, 20)
        Me.txtChange.StyleController = Me.LayoutControl1
        Me.txtChange.TabIndex = 4
        '
        'txtPosition
        '
        Me.txtPosition.Location = New System.Drawing.Point(92, 84)
        Me.txtPosition.MenuManager = Me.RibbonControl1
        Me.txtPosition.Name = "txtPosition"
        Me.txtPosition.Size = New System.Drawing.Size(355, 20)
        Me.txtPosition.StyleController = Me.LayoutControl1
        Me.txtPosition.TabIndex = 2
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "LayoutControlGroup1"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.lccurpos, Me.lcRotasi, Me.lcbutton, Me.lcompcode, Me.lcempcode, Me.lcfullnames, Me.lctime, Me.LayoutControlItem1})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(459, 206)
        Me.LayoutControlGroup1.Text = "LayoutControlGroup1"
        Me.LayoutControlGroup1.TextVisible = False
        '
        'lccurpos
        '
        Me.lccurpos.Control = Me.txtPosition
        Me.lccurpos.CustomizationFormText = "Company Name :"
        Me.lccurpos.Location = New System.Drawing.Point(0, 72)
        Me.lccurpos.Name = "lccurpos"
        Me.lccurpos.Size = New System.Drawing.Size(439, 24)
        Me.lccurpos.Text = "Current Position"
        Me.lccurpos.TextSize = New System.Drawing.Size(77, 13)
        '
        'lcRotasi
        '
        Me.lcRotasi.Control = Me.txtChange
        Me.lcRotasi.CustomizationFormText = "Rotasi To :"
        Me.lcRotasi.Location = New System.Drawing.Point(0, 96)
        Me.lcRotasi.Name = "lcRotasi"
        Me.lcRotasi.Size = New System.Drawing.Size(439, 24)
        Me.lcRotasi.Text = "Change To"
        Me.lcRotasi.TextSize = New System.Drawing.Size(77, 13)
        '
        'lcbutton
        '
        Me.lcbutton.Control = Me.btnChange
        Me.lcbutton.CustomizationFormText = "LayoutControlItem1"
        Me.lcbutton.Location = New System.Drawing.Point(0, 144)
        Me.lcbutton.Name = "lcbutton"
        Me.lcbutton.Size = New System.Drawing.Size(219, 42)
        Me.lcbutton.Text = "lcbutton"
        Me.lcbutton.TextSize = New System.Drawing.Size(0, 0)
        Me.lcbutton.TextToControlDistance = 0
        Me.lcbutton.TextVisible = False
        '
        'lcompcode
        '
        Me.lcompcode.Control = Me.txtCompcode
        Me.lcompcode.CustomizationFormText = "Company Code"
        Me.lcompcode.Location = New System.Drawing.Point(0, 48)
        Me.lcompcode.Name = "lcompcode"
        Me.lcompcode.Size = New System.Drawing.Size(439, 24)
        Me.lcompcode.Text = "Company Code"
        Me.lcompcode.TextSize = New System.Drawing.Size(77, 13)
        '
        'lcempcode
        '
        Me.lcempcode.Control = Me.txtEmpCode
        Me.lcempcode.CustomizationFormText = "Employee Code"
        Me.lcempcode.Location = New System.Drawing.Point(0, 24)
        Me.lcempcode.Name = "lcempcode"
        Me.lcempcode.Size = New System.Drawing.Size(439, 24)
        Me.lcempcode.Text = "Employee Code"
        Me.lcempcode.TextSize = New System.Drawing.Size(77, 13)
        '
        'lcfullnames
        '
        Me.lcfullnames.Control = Me.txtnamakaryawan
        Me.lcfullnames.CustomizationFormText = "Full Name"
        Me.lcfullnames.Location = New System.Drawing.Point(0, 0)
        Me.lcfullnames.Name = "lcfullnames"
        Me.lcfullnames.Size = New System.Drawing.Size(439, 24)
        Me.lcfullnames.Text = "Full Name"
        Me.lcfullnames.TextSize = New System.Drawing.Size(77, 13)
        '
        'lctime
        '
        Me.lctime.Control = Me.txtDate
        Me.lctime.CustomizationFormText = "Change Date"
        Me.lctime.Location = New System.Drawing.Point(0, 120)
        Me.lctime.Name = "lctime"
        Me.lctime.Size = New System.Drawing.Size(439, 24)
        Me.lctime.Text = "Change Date"
        Me.lctime.TextSize = New System.Drawing.Size(77, 13)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.SimpleButton1
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(219, 144)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(220, 42)
        Me.LayoutControlItem1.Text = "LayoutControlItem1"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextToControlDistance = 0
        Me.LayoutControlItem1.TextVisible = False
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(10, 380)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.MenuManager = Me.RibbonControl1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(469, 200)
        Me.GridControl1.TabIndex = 6
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsFind.AlwaysVisible = True
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        '
        'RotasiMutasi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 593)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.MaximizeBox = False
        Me.Name = "RotasiMutasi"
        Me.Ribbon = Me.RibbonControl1
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RotasiMutasi"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtnamakaryawan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEmpCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCompcode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtChange.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lccurpos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcRotasi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcbutton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcompcode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcempcode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcfullnames, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lctime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents btnChange As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtChange As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPosition As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents lccurpos As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lcRotasi As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lcbutton As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtEmpCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtCompcode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lcompcode As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lcempcode As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtnamakaryawan As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lcfullnames As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents txtDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lctime As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barbuttonitem3 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barJudul As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem4 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem5 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BarButtonItem6 As DevExpress.XtraBars.BarButtonItem
End Class
