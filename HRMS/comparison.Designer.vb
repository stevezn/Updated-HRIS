<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Comparison
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
        Dim RadarDiagram1 As DevExpress.XtraCharts.RadarDiagram = New DevExpress.XtraCharts.RadarDiagram()
        Dim Series1 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim RadarPointSeriesLabel1 As DevExpress.XtraCharts.RadarPointSeriesLabel = New DevExpress.XtraCharts.RadarPointSeriesLabel()
        Dim RadarAreaSeriesView1 As DevExpress.XtraCharts.RadarAreaSeriesView = New DevExpress.XtraCharts.RadarAreaSeriesView()
        Dim Series2 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim RadarPointSeriesLabel2 As DevExpress.XtraCharts.RadarPointSeriesLabel = New DevExpress.XtraCharts.RadarPointSeriesLabel()
        Dim RadarAreaSeriesView2 As DevExpress.XtraCharts.RadarAreaSeriesView = New DevExpress.XtraCharts.RadarAreaSeriesView()
        Dim RadarPointSeriesLabel3 As DevExpress.XtraCharts.RadarPointSeriesLabel = New DevExpress.XtraCharts.RadarPointSeriesLabel()
        Dim RadarAreaSeriesView3 As DevExpress.XtraCharts.RadarAreaSeriesView = New DevExpress.XtraCharts.RadarAreaSeriesView()
        Me.ChartControl1 = New DevExpress.XtraCharts.ChartControl()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TextEdit1 = New DevExpress.XtraEditors.TextEdit()
        Me.btnFind = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.txtid = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.ChartControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(RadarDiagram1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(RadarPointSeriesLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(RadarAreaSeriesView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(RadarPointSeriesLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(RadarAreaSeriesView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(RadarPointSeriesLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(RadarAreaSeriesView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ChartControl1
        '
        RadarDiagram1.AxisX.Range.ScrollingRange.SideMarginsEnabled = False
        RadarDiagram1.AxisY.Range.AlwaysShowZeroLevel = True
        RadarDiagram1.AxisY.Range.ScrollingRange.SideMarginsEnabled = True
        RadarDiagram1.AxisY.Range.SideMarginsEnabled = True
        Me.ChartControl1.Diagram = RadarDiagram1
        Me.ChartControl1.Location = New System.Drawing.Point(191, 9)
        Me.ChartControl1.Name = "ChartControl1"
        RadarPointSeriesLabel1.LineVisible = True
        Series1.Label = RadarPointSeriesLabel1
        Series1.Name = "Series 1"
        Series1.View = RadarAreaSeriesView1
        RadarPointSeriesLabel2.LineVisible = True
        Series2.Label = RadarPointSeriesLabel2
        Series2.Name = "Series 2"
        Series2.View = RadarAreaSeriesView2
        Me.ChartControl1.SeriesSerializable = New DevExpress.XtraCharts.Series() {Series1, Series2}
        RadarPointSeriesLabel3.LineVisible = True
        Me.ChartControl1.SeriesTemplate.Label = RadarPointSeriesLabel3
        RadarAreaSeriesView3.Transparency = CType(0, Byte)
        Me.ChartControl1.SeriesTemplate.View = RadarAreaSeriesView3
        Me.ChartControl1.Size = New System.Drawing.Size(462, 324)
        Me.ChartControl1.TabIndex = 0
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(7, 37)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(174, 484)
        Me.GridControl1.TabIndex = 37
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'TextEdit1
        '
        Me.TextEdit1.Location = New System.Drawing.Point(7, 6)
        Me.TextEdit1.Name = "TextEdit1"
        Me.TextEdit1.Size = New System.Drawing.Size(105, 20)
        Me.TextEdit1.TabIndex = 39
        '
        'btnFind
        '
        Me.btnFind.Location = New System.Drawing.Point(118, 5)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(62, 23)
        Me.btnFind.TabIndex = 40
        Me.btnFind.Text = "Search"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(192, 339)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButton1.TabIndex = 41
        Me.SimpleButton1.Text = "Select"
        '
        'txtid
        '
        Me.txtid.Location = New System.Drawing.Point(191, 389)
        Me.txtid.Name = "txtid"
        Me.txtid.Size = New System.Drawing.Size(66, 13)
        Me.txtid.TabIndex = 42
        Me.txtid.Text = "LabelControl1"
        Me.txtid.Visible = False
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LabelControl4.Location = New System.Drawing.Point(326, 387)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(78, 13)
        Me.LabelControl4.TabIndex = 43
        Me.LabelControl4.Text = "LabelControl1"
        Me.LabelControl4.Visible = False
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Appearance.ForeColor = System.Drawing.Color.Red
        Me.LabelControl3.Location = New System.Drawing.Point(326, 406)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(78, 13)
        Me.LabelControl3.TabIndex = 44
        Me.LabelControl3.Text = "LabelControl2"
        Me.LabelControl3.Visible = False
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.Green
        Me.LabelControl1.Location = New System.Drawing.Point(326, 349)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(78, 13)
        Me.LabelControl1.TabIndex = 45
        Me.LabelControl1.Text = "LabelControl3"
        Me.LabelControl1.Visible = False
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LabelControl2.Location = New System.Drawing.Point(326, 368)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(78, 13)
        Me.LabelControl2.TabIndex = 46
        Me.LabelControl2.Text = "LabelControl4"
        Me.LabelControl2.Visible = False
        '
        'Comparison
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(654, 523)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.txtid)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.btnFind)
        Me.Controls.Add(Me.TextEdit1)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.ChartControl1)
        Me.MaximizeBox = False
        Me.Name = "Comparison"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(RadarDiagram1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(RadarPointSeriesLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(RadarAreaSeriesView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(RadarPointSeriesLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(RadarAreaSeriesView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(RadarPointSeriesLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(RadarAreaSeriesView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ChartControl1 As DevExpress.XtraCharts.ChartControl
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TextEdit1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnFind As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtid As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
End Class
