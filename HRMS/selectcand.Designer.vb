<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class selectcand
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(selectcand))
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton4 = New DevExpress.XtraEditors.SimpleButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtrec1 = New DevExpress.XtraEditors.LabelControl()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(181, 32)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1079, 620)
        Me.GridControl1.TabIndex = 22
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsFind.AlwaysVisible = True
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.PaintStyleName = "Office2003"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(11, 31)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(145, 159)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 21
        Me.PictureBox1.TabStop = False
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(12, 10)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(45, 16)
        Me.LabelControl2.TabIndex = 20
        Me.LabelControl2.Text = "Preview"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(181, 13)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(87, 13)
        Me.LabelControl1.TabIndex = 19
        Me.LabelControl1.Text = "Selected records :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(34, 342)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Label5"
        Me.Label5.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(32, 318)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "Label4"
        Me.Label4.Visible = False
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Image = CType(resources.GetObject("SimpleButton3.Image"), System.Drawing.Image)
        Me.SimpleButton3.Location = New System.Drawing.Point(44, 196)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(73, 23)
        Me.SimpleButton3.TabIndex = 25
        Me.SimpleButton3.Text = "Select"
        '
        'SimpleButton4
        '
        Me.SimpleButton4.Location = New System.Drawing.Point(8, 246)
        Me.SimpleButton4.Name = "SimpleButton4"
        Me.SimpleButton4.Size = New System.Drawing.Size(63, 23)
        Me.SimpleButton4.TabIndex = 27
        Me.SimpleButton4.Text = "Refresh"
        Me.SimpleButton4.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1166, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "All records"
        '
        'txtrec1
        '
        Me.txtrec1.Location = New System.Drawing.Point(1237, 14)
        Me.txtrec1.Name = "txtrec1"
        Me.txtrec1.Size = New System.Drawing.Size(4, 13)
        Me.txtrec1.TabIndex = 26
        Me.txtrec1.Text = "-"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(57, 406)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Label3"
        Me.Label3.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(272, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Label2"
        '
        'selectcand
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1266, 662)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.SimpleButton3)
        Me.Controls.Add(Me.SimpleButton4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtrec1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Name = "selectcand"
        Me.Text = "View Browser : Candidates"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton4 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label1 As Label
    Friend WithEvents txtrec1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
End Class
