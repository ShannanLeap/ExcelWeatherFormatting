<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConvert
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
        Me.btnFormat = New System.Windows.Forms.Button()
        Me.bntOpen = New System.Windows.Forms.Button()
        Me.list1 = New System.Windows.Forms.ListBox()
        Me.folder1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.lblDaysCount = New System.Windows.Forms.Label()
        Me.txtDaysCount = New System.Windows.Forms.TextBox()
        Me.btnResults = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblZipCode = New System.Windows.Forms.Label()
        Me.txtLocations = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtHighLessThan = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtHighGreaterThan = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtDPLessThan = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtGoodDPLessThan = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtGoodHighGreaterThan = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtGoodHighLessThan = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.RBFileTypeLocal = New System.Windows.Forms.RadioButton()
        Me.RBFileTypeInternational = New System.Windows.Forms.RadioButton()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnFormat
        '
        Me.btnFormat.Enabled = False
        Me.btnFormat.Location = New System.Drawing.Point(111, 200)
        Me.btnFormat.Name = "btnFormat"
        Me.btnFormat.Size = New System.Drawing.Size(75, 23)
        Me.btnFormat.TabIndex = 0
        Me.btnFormat.Text = "Format"
        Me.btnFormat.UseVisualStyleBackColor = True
        '
        'bntOpen
        '
        Me.bntOpen.Location = New System.Drawing.Point(15, 200)
        Me.bntOpen.Name = "bntOpen"
        Me.bntOpen.Size = New System.Drawing.Size(90, 23)
        Me.bntOpen.TabIndex = 1
        Me.bntOpen.Text = "Select Folder"
        Me.bntOpen.UseVisualStyleBackColor = True
        '
        'list1
        '
        Me.list1.FormattingEnabled = True
        Me.list1.Location = New System.Drawing.Point(15, 227)
        Me.list1.Name = "list1"
        Me.list1.Size = New System.Drawing.Size(319, 563)
        Me.list1.TabIndex = 2
        '
        'lblDaysCount
        '
        Me.lblDaysCount.AutoSize = True
        Me.lblDaysCount.Location = New System.Drawing.Point(339, 234)
        Me.lblDaysCount.Name = "lblDaysCount"
        Me.lblDaysCount.Size = New System.Drawing.Size(61, 13)
        Me.lblDaysCount.TabIndex = 3
        Me.lblDaysCount.Text = "Days in file:"
        '
        'txtDaysCount
        '
        Me.txtDaysCount.Location = New System.Drawing.Point(406, 231)
        Me.txtDaysCount.Name = "txtDaysCount"
        Me.txtDaysCount.Size = New System.Drawing.Size(55, 20)
        Me.txtDaysCount.TabIndex = 4
        '
        'btnResults
        '
        Me.btnResults.Enabled = False
        Me.btnResults.Location = New System.Drawing.Point(194, 200)
        Me.btnResults.Name = "btnResults"
        Me.btnResults.Size = New System.Drawing.Size(75, 23)
        Me.btnResults.TabIndex = 6
        Me.btnResults.Text = "Results"
        Me.btnResults.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 61)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(22, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "2a."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(37, 96)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "International:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 130)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(16, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "3."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(32, 130)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(441, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Save CSV. Find with select folder button and click format button. This formats da" &
    "ta correctly."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 167)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(16, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "4."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(32, 167)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(287, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "When format is done, days in file should report about 3,000."
        '
        'lblZipCode
        '
        Me.lblZipCode.AutoSize = True
        Me.lblZipCode.Location = New System.Drawing.Point(338, 252)
        Me.lblZipCode.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblZipCode.Name = "lblZipCode"
        Me.lblZipCode.Size = New System.Drawing.Size(154, 13)
        Me.lblZipCode.TabIndex = 15
        Me.lblZipCode.Text = "Try a different zip code for data"
        Me.lblZipCode.Visible = False
        '
        'txtLocations
        '
        Me.txtLocations.Location = New System.Drawing.Point(406, 770)
        Me.txtLocations.Name = "txtLocations"
        Me.txtLocations.Size = New System.Drawing.Size(33, 20)
        Me.txtLocations.TabIndex = 17
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(344, 773)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Locations:"
        '
        'txtHighLessThan
        '
        Me.txtHighLessThan.Location = New System.Drawing.Point(406, 397)
        Me.txtHighLessThan.Name = "txtHighLessThan"
        Me.txtHighLessThan.Size = New System.Drawing.Size(47, 20)
        Me.txtHighLessThan.TabIndex = 19
        Me.txtHighLessThan.Text = "80"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(339, 400)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Daily High <"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(340, 372)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(136, 13)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Perfect Day Definition:"
        '
        'txtHighGreaterThan
        '
        Me.txtHighGreaterThan.Location = New System.Drawing.Point(406, 423)
        Me.txtHighGreaterThan.Name = "txtHighGreaterThan"
        Me.txtHighGreaterThan.Size = New System.Drawing.Size(47, 20)
        Me.txtHighGreaterThan.TabIndex = 22
        Me.txtHighGreaterThan.Text = "70"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(339, 426)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 13)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Daily High >"
        '
        'txtDPLessThan
        '
        Me.txtDPLessThan.Location = New System.Drawing.Point(406, 452)
        Me.txtDPLessThan.Name = "txtDPLessThan"
        Me.txtDPLessThan.Size = New System.Drawing.Size(47, 20)
        Me.txtDPLessThan.TabIndex = 24
        Me.txtDPLessThan.Text = "65"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(339, 455)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 13)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Dew Point <"
        '
        'txtGoodDPLessThan
        '
        Me.txtGoodDPLessThan.Location = New System.Drawing.Point(406, 592)
        Me.txtGoodDPLessThan.Name = "txtGoodDPLessThan"
        Me.txtGoodDPLessThan.Size = New System.Drawing.Size(47, 20)
        Me.txtGoodDPLessThan.TabIndex = 31
        Me.txtGoodDPLessThan.Text = "60"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(339, 595)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(65, 13)
        Me.Label13.TabIndex = 30
        Me.Label13.Text = "Dew Point <"
        '
        'txtGoodHighGreaterThan
        '
        Me.txtGoodHighGreaterThan.Location = New System.Drawing.Point(406, 563)
        Me.txtGoodHighGreaterThan.Name = "txtGoodHighGreaterThan"
        Me.txtGoodHighGreaterThan.Size = New System.Drawing.Size(47, 20)
        Me.txtGoodHighGreaterThan.TabIndex = 29
        Me.txtGoodHighGreaterThan.Text = "60"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(339, 566)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(64, 13)
        Me.Label14.TabIndex = 28
        Me.Label14.Text = "Daily High >"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(340, 512)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(125, 13)
        Me.Label15.TabIndex = 27
        Me.Label15.Text = "Good Day Definition:"
        '
        'txtGoodHighLessThan
        '
        Me.txtGoodHighLessThan.Location = New System.Drawing.Point(406, 537)
        Me.txtGoodHighLessThan.Name = "txtGoodHighLessThan"
        Me.txtGoodHighLessThan.Size = New System.Drawing.Size(47, 20)
        Me.txtGoodHighLessThan.TabIndex = 26
        Me.txtGoodHighLessThan.Text = "90"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(339, 540)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(64, 13)
        Me.Label16.TabIndex = 25
        Me.Label16.Text = "Daily High <"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(338, 283)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(210, 13)
        Me.Label17.TabIndex = 32
        Me.Label17.Text = "File type: (needed to know when formating)"
        '
        'RBFileTypeLocal
        '
        Me.RBFileTypeLocal.AutoSize = True
        Me.RBFileTypeLocal.Checked = True
        Me.RBFileTypeLocal.Location = New System.Drawing.Point(342, 300)
        Me.RBFileTypeLocal.Name = "RBFileTypeLocal"
        Me.RBFileTypeLocal.Size = New System.Drawing.Size(94, 17)
        Me.RBFileTypeLocal.TabIndex = 33
        Me.RBFileTypeLocal.TabStop = True
        Me.RBFileTypeLocal.Text = "LCD (US data)"
        Me.RBFileTypeLocal.UseVisualStyleBackColor = True
        '
        'RBFileTypeInternational
        '
        Me.RBFileTypeInternational.AutoSize = True
        Me.RBFileTypeInternational.Location = New System.Drawing.Point(342, 323)
        Me.RBFileTypeInternational.Name = "RBFileTypeInternational"
        Me.RBFileTypeInternational.Size = New System.Drawing.Size(147, 17)
        Me.RBFileTypeInternational.TabIndex = 34
        Me.RBFileTypeInternational.Text = "Daily Global (international)"
        Me.RBFileTypeInternational.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(53, 146)
        Me.Label18.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(673, 13)
        Me.Label18.TabIndex = 35
        Me.Label18.Text = "IF LCD DATA IS USED, NAME CSV WITH ZIPCODE AT THE END AND SELECT LCD DATA OR INTE" &
    "RNATIONAL IF NON-LCD IS USED"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(33, 61)
        Me.Label19.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(32, 13)
        Me.Label19.TabIndex = 36
        Me.Label19.Text = "USA:"
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Location = New System.Drawing.Point(70, 61)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(822, 13)
        Me.TextBox1.TabIndex = 37
        Me.TextBox1.Text = " https://www.ncei.noaa.gov/access/services/data/v1?dataset=local-climatological-d" &
    "ata&stations=72462023061&startDate=2010-01-01&endDate=2019-01-01&format=csv"
        '
        'TextBox2
        '
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox2.Location = New System.Drawing.Point(110, 95)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(822, 13)
        Me.TextBox2.TabIndex = 38
        Me.TextBox2.Text = "https://www.ncei.noaa.gov/access/services/data/v1?dataset=global-summary-of-the-d" &
    "ay&stations=76750399999&startDate=2010-01-01&endDate=2019-01-01&format=csv"
        '
        'TextBox3
        '
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox3.Location = New System.Drawing.Point(35, 10)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(822, 13)
        Me.TextBox3.TabIndex = 40
        Me.TextBox3.Text = "Find a station: https://gis.ncdc.noaa.gov/maps/ncei/cdo/hourly  or  txt file: ftp" &
    "://ftp.ncdc.noaa.gov/pub/data/noaa/isd-history.txt"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 10)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(22, 13)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "1a."
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(13, 39)
        Me.Label21.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(22, 13)
        Me.Label21.TabIndex = 43
        Me.Label21.Text = "1b."
        '
        'TextBox4
        '
        Me.TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox4.Location = New System.Drawing.Point(35, 39)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(822, 13)
        Me.TextBox4.TabIndex = 42
        Me.TextBox4.Text = "OR use the text file: ftp://ftp.ncdc.noaa.gov/pub/data/noaa/isd-history.txt"
        '
        'TextBox5
        '
        Me.TextBox5.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox5.Location = New System.Drawing.Point(56, 25)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(822, 13)
        Me.TextBox5.TabIndex = 44
        Me.TextBox5.Text = "Click the wrench icon beside the active layer and click on the Identify tool. Fro" &
    "m there, you can click on a dot to retrieve metadata/station number."
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(53, 76)
        Me.Label20.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(318, 13)
        Me.Label20.TabIndex = 45
        Me.Label20.Text = "Insert the station ID from step #1 as ""stations"" in the above query."
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(13, 95)
        Me.Label22.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(22, 13)
        Me.Label22.TabIndex = 46
        Me.Label22.Text = "2b."
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(53, 110)
        Me.Label23.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(381, 13)
        Me.Label23.TabIndex = 47
        Me.Label23.Text = "Start file name with a ""_"".  You can also use this for USA if the USA option fail" &
    "s."
        '
        'frmConvert
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(988, 796)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.RBFileTypeInternational)
        Me.Controls.Add(Me.RBFileTypeLocal)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtGoodDPLessThan)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtGoodHighGreaterThan)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtGoodHighLessThan)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtDPLessThan)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtHighGreaterThan)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtHighLessThan)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtLocations)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblZipCode)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnResults)
        Me.Controls.Add(Me.txtDaysCount)
        Me.Controls.Add(Me.lblDaysCount)
        Me.Controls.Add(Me.list1)
        Me.Controls.Add(Me.bntOpen)
        Me.Controls.Add(Me.btnFormat)
        Me.Name = "frmConvert"
        Me.Text = "Convert Data"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnFormat As System.Windows.Forms.Button
    Friend WithEvents bntOpen As System.Windows.Forms.Button
    Friend WithEvents list1 As System.Windows.Forms.ListBox
    Friend WithEvents folder1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents lblDaysCount As System.Windows.Forms.Label
    Friend WithEvents txtDaysCount As System.Windows.Forms.TextBox
    Friend WithEvents btnResults As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblZipCode As System.Windows.Forms.Label
    Friend WithEvents txtLocations As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtHighLessThan As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtHighGreaterThan As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtDPLessThan As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtGoodDPLessThan As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtGoodHighGreaterThan As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtGoodHighLessThan As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents RBFileTypeLocal As System.Windows.Forms.RadioButton
    Friend WithEvents RBFileTypeInternational As System.Windows.Forms.RadioButton
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label

End Class
