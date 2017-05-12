<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Login
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.teUsername = New DevExpress.XtraEditors.TextEdit()
        Me.tePassword = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.AutomaticUpdater1 = New wyDay.Controls.AutomaticUpdater()
        Me.CheckForUpdatesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnTest = New DevExpress.XtraEditors.SimpleButton()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.teUsername.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tePassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AutomaticUpdater1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(9, 66)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(2)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Username"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(9, 93)
        Me.LabelControl2.Margin = New System.Windows.Forms.Padding(2)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl2.TabIndex = 0
        Me.LabelControl2.Text = "Password"
        '
        'teUsername
        '
        Me.teUsername.Location = New System.Drawing.Point(80, 63)
        Me.teUsername.Margin = New System.Windows.Forms.Padding(2)
        Me.teUsername.Name = "teUsername"
        Me.teUsername.Size = New System.Drawing.Size(238, 20)
        Me.teUsername.TabIndex = 1
        '
        'tePassword
        '
        Me.tePassword.Location = New System.Drawing.Point(80, 90)
        Me.tePassword.Margin = New System.Windows.Forms.Padding(2)
        Me.tePassword.Name = "tePassword"
        Me.tePassword.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tePassword.Size = New System.Drawing.Size(238, 20)
        Me.tePassword.TabIndex = 2
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(118, 38)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(123, 15)
        Me.LabelControl4.TabIndex = 70
        Me.LabelControl4.Text = "Sign In To Enter HRIS"
        '
        'Timer1
        '
        Me.Timer1.Interval = 150
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(9, 116)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(208, 32)
        Me.ProgressBar1.TabIndex = 81
        Me.ProgressBar1.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 159)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 82
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.WebBrowser1.Location = New System.Drawing.Point(190, 165)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.TabIndex = 83
        Me.WebBrowser1.Visible = False
        '
        'AutomaticUpdater1
        '
        Me.AutomaticUpdater1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AutomaticUpdater1.ContainerForm = Me
        Me.AutomaticUpdater1.GUID = "f59e7ad5-abbf-4a4a-91f5-f37710530bbe"
        Me.AutomaticUpdater1.Location = New System.Drawing.Point(309, 149)
        Me.AutomaticUpdater1.Name = "AutomaticUpdater1"
        Me.AutomaticUpdater1.Size = New System.Drawing.Size(16, 16)
        Me.AutomaticUpdater1.TabIndex = 84
        Me.AutomaticUpdater1.ToolStripItem = Me.CheckForUpdatesToolStripMenuItem
        Me.AutomaticUpdater1.UpdateType = wyDay.Controls.UpdateType.OnlyCheck
        Me.AutomaticUpdater1.wyUpdateCommandline = Nothing
        '
        'CheckForUpdatesToolStripMenuItem
        '
        Me.CheckForUpdatesToolStripMenuItem.Name = "CheckForUpdatesToolStripMenuItem"
        Me.CheckForUpdatesToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.CheckForUpdatesToolStripMenuItem.Text = "Check For Updates"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(329, 24)
        Me.MenuStrip1.TabIndex = 85
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CheckForUpdatesToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.OptionsToolStripMenuItem.Text = "Options"
        Me.OptionsToolStripMenuItem.Visible = False
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Image = CType(resources.GetObject("SimpleButton1.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(291, 2)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(24, 22)
        Me.SimpleButton1.TabIndex = 86
        '
        'btnTest
        '
        Me.btnTest.Image = CType(resources.GetObject("btnTest.Image"), System.Drawing.Image)
        Me.btnTest.Location = New System.Drawing.Point(218, 116)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(100, 30)
        Me.btnTest.TabIndex = 79
        Me.btnTest.Text = "Connect.."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(287, 165)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 87
        Me.Label2.Text = "V 1.27"
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(329, 179)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.AutomaticUpdater1)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.btnTest)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.tePassword)
        Me.Controls.Add(Me.teUsername)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.LookAndFeel.SkinName = "DevExpress Dark Style"
        Me.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.LookAndFeel.UseWindowsXPTheme = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Login"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.teUsername.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tePassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AutomaticUpdater1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents teUsername As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tePassword As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnTest As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Label1 As Label
    Friend WithEvents WebBrowser1 As WebBrowser
    Friend WithEvents AutomaticUpdater1 As wyDay.Controls.AutomaticUpdater
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents OptionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CheckForUpdatesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label2 As Label
End Class
