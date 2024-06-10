<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Results
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
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnOpen = New System.Windows.Forms.Button()
        Me.chtDailyAverages = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chtDailyAverages, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(16, 44)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1870, 499)
        Me.DataGridView1.TabIndex = 0
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(16, 11)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(72, 28)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save data"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnOpen
        '
        Me.btnOpen.Location = New System.Drawing.Point(92, 11)
        Me.btnOpen.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(105, 28)
        Me.btnOpen.TabIndex = 2
        Me.btnOpen.Text = "Open Saved Data"
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'chtDailyAverages
        '
        ChartArea2.Name = "ChartArea1"
        Me.chtDailyAverages.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.chtDailyAverages.Legends.Add(Legend2)
        Me.chtDailyAverages.Location = New System.Drawing.Point(20, 549)
        Me.chtDailyAverages.Name = "chtDailyAverages"
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.chtDailyAverages.Series.Add(Series2)
        Me.chtDailyAverages.Size = New System.Drawing.Size(1866, 420)
        Me.chtDailyAverages.TabIndex = 3
        Me.chtDailyAverages.Text = "Chart1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(251, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(434, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "if the dew-point temperature is close to the dry air temperature -  the relative " & _
    "humidity is high"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(251, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(380, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "if the dew point is well below the dry air temperature - the relative humidity is" & _
    " low"
        '
        'Results
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1443, 857)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chtDailyAverages)
        Me.Controls.Add(Me.btnOpen)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "Results"
        Me.Text = "Results"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chtDailyAverages, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents chtDailyAverages As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
