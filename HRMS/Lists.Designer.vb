<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Lists
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
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Lists))
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutView1 = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.LayoutViewCard1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridControl1
        '
        GridLevelNode1.RelationName = "Level1"
        Me.GridControl1.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GridControl1.Location = New System.Drawing.Point(2, 2)
        Me.GridControl1.MainView = Me.LayoutView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1528, 851)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.LayoutView1})
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Image = CType(resources.GetObject("SimpleButton1.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(500, 12)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(75, 22)
        Me.SimpleButton1.TabIndex = 1
        Me.SimpleButton1.Text = "Print Data"
        '
        'LayoutView1
        '
        Me.LayoutView1.GridControl = Me.GridControl1
        Me.LayoutView1.Name = "LayoutView1"
        Me.LayoutView1.OptionsFind.AlwaysVisible = True
        Me.LayoutView1.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateAllContent
        Me.LayoutView1.TemplateCard = Me.LayoutViewCard1
        '
        'LayoutViewCard1
        '
        Me.LayoutViewCard1.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.LayoutViewCard1.Name = "LayoutViewCard1"
        '
        'Lists
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1436, 865)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.GridControl1)
        Me.Name = "Lists"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lists"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutView1 As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents LayoutViewCard1 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
End Class
