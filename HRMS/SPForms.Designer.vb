<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SPForms
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SPForms))
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.barbuttonitem3 = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.barJudul = New DevExpress.XtraBars.BarButtonItem()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.txtreason = New DevExpress.XtraEditors.TextEdit()
        Me.lcTitle = New DevExpress.XtraEditors.LabelControl()
        Me.btnReset = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSP = New DevExpress.XtraEditors.SimpleButton()
        Me.txtNamaKaryawan = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.txtPosition = New DevExpress.XtraEditors.TextEdit()
        Me.txtcompcode = New DevExpress.XtraEditors.TextEdit()
        Me.txtEmpCode = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.lcempcode = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lccompcode = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lcposition = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lcnames = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lcreason = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtreason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNamaKaryawan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcompcode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEmpCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcempcode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lccompcode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcposition, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcnames, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcreason, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.Glyph = CType(resources.GetObject("RibbonPageGroup1.Glyph"), System.Drawing.Image)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BarButtonItem1)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BarButtonItem2)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.barbuttonitem3)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Surat Peringatan 1"
        Me.BarButtonItem1.Glyph = CType(resources.GetObject("BarButtonItem1.Glyph"), System.Drawing.Image)
        Me.BarButtonItem1.Id = 1
        Me.BarButtonItem1.Name = "BarButtonItem1"
        Me.BarButtonItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'BarButtonItem2
        '
        Me.BarButtonItem2.Caption = "Surat Peringatan 2"
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
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "Surat Peringatan"
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.BarButtonItem1, Me.BarButtonItem2, Me.barbuttonitem3, Me.barJudul})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 5
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl1.Size = New System.Drawing.Size(373, 147)
        Me.RibbonControl1.Toolbar.ItemLinks.Add(Me.barJudul)
        Me.RibbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Below
        '
        'barJudul
        '
        Me.barJudul.Caption = "BarButtonItem4"
        Me.barJudul.Id = 4
        Me.barJudul.Name = "barJudul"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.txtreason)
        Me.LayoutControl1.Controls.Add(Me.lcTitle)
        Me.LayoutControl1.Controls.Add(Me.btnReset)
        Me.LayoutControl1.Controls.Add(Me.btnSP)
        Me.LayoutControl1.Controls.Add(Me.txtNamaKaryawan)
        Me.LayoutControl1.Controls.Add(Me.txtPosition)
        Me.LayoutControl1.Controls.Add(Me.txtcompcode)
        Me.LayoutControl1.Controls.Add(Me.txtEmpCode)
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 153)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(374, 207)
        Me.LayoutControl1.TabIndex = 13
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'txtreason
        '
        Me.txtreason.Location = New System.Drawing.Point(96, 130)
        Me.txtreason.MenuManager = Me.RibbonControl1
        Me.txtreason.Name = "txtreason"
        Me.txtreason.Size = New System.Drawing.Size(266, 20)
        Me.txtreason.StyleController = Me.LayoutControl1
        Me.txtreason.TabIndex = 19
        '
        'lcTitle
        '
        Me.lcTitle.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lcTitle.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lcTitle.LineLocation = DevExpress.XtraEditors.LineLocation.Center
        Me.lcTitle.Location = New System.Drawing.Point(177, 12)
        Me.lcTitle.Name = "lcTitle"
        Me.lcTitle.Size = New System.Drawing.Size(20, 18)
        Me.lcTitle.StyleController = Me.LayoutControl1
        Me.lcTitle.TabIndex = 14
        Me.lcTitle.Text = "SP"
        '
        'btnReset
        '
        Me.btnReset.Image = CType(resources.GetObject("btnReset.Image"), System.Drawing.Image)
        Me.btnReset.Location = New System.Drawing.Point(188, 154)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(174, 38)
        Me.btnReset.StyleController = Me.LayoutControl1
        Me.btnReset.TabIndex = 14
        Me.btnReset.Text = "Reset"
        '
        'btnSP
        '
        Me.btnSP.Image = CType(resources.GetObject("btnSP.Image"), System.Drawing.Image)
        Me.btnSP.Location = New System.Drawing.Point(12, 154)
        Me.btnSP.Name = "btnSP"
        Me.btnSP.Size = New System.Drawing.Size(172, 38)
        Me.btnSP.StyleController = Me.LayoutControl1
        Me.btnSP.TabIndex = 14
        Me.btnSP.Text = "Give SP"
        '
        'txtNamaKaryawan
        '
        Me.txtNamaKaryawan.Location = New System.Drawing.Point(96, 34)
        Me.txtNamaKaryawan.MenuManager = Me.RibbonControl1
        Me.txtNamaKaryawan.Name = "txtNamaKaryawan"
        Me.txtNamaKaryawan.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtNamaKaryawan.Size = New System.Drawing.Size(266, 20)
        Me.txtNamaKaryawan.StyleController = Me.LayoutControl1
        Me.txtNamaKaryawan.TabIndex = 14
        '
        'txtPosition
        '
        Me.txtPosition.Location = New System.Drawing.Point(96, 106)
        Me.txtPosition.MenuManager = Me.RibbonControl1
        Me.txtPosition.Name = "txtPosition"
        Me.txtPosition.Size = New System.Drawing.Size(266, 20)
        Me.txtPosition.StyleController = Me.LayoutControl1
        Me.txtPosition.TabIndex = 17
        '
        'txtcompcode
        '
        Me.txtcompcode.Location = New System.Drawing.Point(96, 82)
        Me.txtcompcode.MenuManager = Me.RibbonControl1
        Me.txtcompcode.Name = "txtcompcode"
        Me.txtcompcode.Size = New System.Drawing.Size(266, 20)
        Me.txtcompcode.StyleController = Me.LayoutControl1
        Me.txtcompcode.TabIndex = 16
        '
        'txtEmpCode
        '
        Me.txtEmpCode.Location = New System.Drawing.Point(96, 58)
        Me.txtEmpCode.MenuManager = Me.RibbonControl1
        Me.txtEmpCode.Name = "txtEmpCode"
        Me.txtEmpCode.Size = New System.Drawing.Size(266, 20)
        Me.txtEmpCode.StyleController = Me.LayoutControl1
        Me.txtEmpCode.TabIndex = 15
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "LayoutControlGroup1"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.lcempcode, Me.lccompcode, Me.lcposition, Me.lcnames, Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.lcreason})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(374, 207)
        Me.LayoutControlGroup1.Text = "LayoutControlGroup1"
        Me.LayoutControlGroup1.TextVisible = False
        '
        'lcempcode
        '
        Me.lcempcode.Control = Me.txtEmpCode
        Me.lcempcode.CustomizationFormText = "Employee Code"
        Me.lcempcode.Location = New System.Drawing.Point(0, 46)
        Me.lcempcode.Name = "lcempcode"
        Me.lcempcode.Size = New System.Drawing.Size(354, 24)
        Me.lcempcode.Text = "Employee Code"
        Me.lcempcode.TextSize = New System.Drawing.Size(81, 13)
        '
        'lccompcode
        '
        Me.lccompcode.Control = Me.txtcompcode
        Me.lccompcode.CustomizationFormText = "LayoutControlItem3"
        Me.lccompcode.Location = New System.Drawing.Point(0, 70)
        Me.lccompcode.Name = "lccompcode"
        Me.lccompcode.Size = New System.Drawing.Size(354, 24)
        Me.lccompcode.Text = "Company Code"
        Me.lccompcode.TextSize = New System.Drawing.Size(81, 13)
        '
        'lcposition
        '
        Me.lcposition.Control = Me.txtPosition
        Me.lcposition.CustomizationFormText = "Position"
        Me.lcposition.Location = New System.Drawing.Point(0, 94)
        Me.lcposition.Name = "lcposition"
        Me.lcposition.Size = New System.Drawing.Size(354, 24)
        Me.lcposition.Text = "Position"
        Me.lcposition.TextSize = New System.Drawing.Size(81, 13)
        '
        'lcnames
        '
        Me.lcnames.Control = Me.txtNamaKaryawan
        Me.lcnames.CustomizationFormText = "Employee Names"
        Me.lcnames.Location = New System.Drawing.Point(0, 22)
        Me.lcnames.Name = "lcnames"
        Me.lcnames.Size = New System.Drawing.Size(354, 24)
        Me.lcnames.Text = "Employee Names"
        Me.lcnames.TextSize = New System.Drawing.Size(81, 13)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.btnSP
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 142)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(176, 45)
        Me.LayoutControlItem1.Text = "LayoutControlItem1"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextToControlDistance = 0
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.btnReset
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem2"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(176, 142)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(178, 45)
        Me.LayoutControlItem2.Text = "LayoutControlItem2"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextToControlDistance = 0
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.lcTitle
        Me.LayoutControlItem3.ControlAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(354, 22)
        Me.LayoutControlItem3.Text = "LayoutControlItem3"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextToControlDistance = 0
        Me.LayoutControlItem3.TextVisible = False
        '
        'lcreason
        '
        Me.lcreason.Control = Me.txtreason
        Me.lcreason.CustomizationFormText = "SP Reason"
        Me.lcreason.Location = New System.Drawing.Point(0, 118)
        Me.lcreason.Name = "lcreason"
        Me.lcreason.Size = New System.Drawing.Size(354, 24)
        Me.lcreason.Text = "SP Reason"
        Me.lcreason.TextSize = New System.Drawing.Size(81, 13)
        '
        'SPForms
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(373, 356)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SPForms"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SPForms"
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtreason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNamaKaryawan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcompcode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEmpCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcempcode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lccompcode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcposition, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcnames, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcreason, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barbuttonitem3 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents barJudul As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents btnSP As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtNamaKaryawan As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents txtPosition As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtcompcode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtEmpCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents lcempcode As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lccompcode As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lcposition As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lcnames As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnReset As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lcTitle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtreason As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lcreason As DevExpress.XtraLayout.LayoutControlItem
End Class
