<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConvert
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
        Me.folder1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.lblCurrentURL = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BrowserWindow = New System.Windows.Forms.WebBrowser()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtGoodDPLessThan = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtGoodHighGreaterThan = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtGoodHighLessThan = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtDPLessThan = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtHighGreaterThan = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtHighLessThan = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtLocations = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblZipCode = New System.Windows.Forms.Label()
        Me.btnResults = New System.Windows.Forms.Button()
        Me.txtDaysCount = New System.Windows.Forms.TextBox()
        Me.lblDaysCount = New System.Windows.Forms.Label()
        Me.list1 = New System.Windows.Forms.ListBox()
        Me.folderDataFolder = New System.Windows.Forms.FolderBrowserDialog()
        Me.txtDataDirectory = New System.Windows.Forms.TextBox()
        Me.btnFindDataDirectory = New System.Windows.Forms.Button()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.PicStatus = New System.Windows.Forms.PictureBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtLocationName = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.btnDownloadData = New System.Windows.Forms.Button()
        Me.rdoDLInternational = New System.Windows.Forms.RadioButton()
        Me.rdoDLUSA = New System.Windows.Forms.RadioButton()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtStationID = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PicStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(14, 143)
        Me.Label24.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(60, 13)
        Me.Label24.TabIndex = 87
        Me.Label24.Text = "Current Url:"
        '
        'lblCurrentURL
        '
        Me.lblCurrentURL.AutoSize = True
        Me.lblCurrentURL.Location = New System.Drawing.Point(78, 143)
        Me.lblCurrentURL.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCurrentURL.Name = "lblCurrentURL"
        Me.lblCurrentURL.Size = New System.Drawing.Size(60, 13)
        Me.lblCurrentURL.TabIndex = 88
        Me.lblCurrentURL.Text = "Current Url:"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BrowserWindow)
        Me.Panel1.Location = New System.Drawing.Point(17, 159)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(675, 448)
        Me.Panel1.TabIndex = 89
        '
        'BrowserWindow
        '
        Me.BrowserWindow.Location = New System.Drawing.Point(4, 12)
        Me.BrowserWindow.MinimumSize = New System.Drawing.Size(20, 20)
        Me.BrowserWindow.Name = "BrowserWindow"
        Me.BrowserWindow.Size = New System.Drawing.Size(658, 414)
        Me.BrowserWindow.TabIndex = 52
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.txtGoodDPLessThan)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.txtGoodHighGreaterThan)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.txtGoodHighLessThan)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.txtDPLessThan)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.txtHighGreaterThan)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.txtHighLessThan)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.txtLocations)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.lblZipCode)
        Me.Panel2.Controls.Add(Me.btnResults)
        Me.Panel2.Controls.Add(Me.txtDaysCount)
        Me.Panel2.Controls.Add(Me.lblDaysCount)
        Me.Panel2.Controls.Add(Me.list1)
        Me.Panel2.Location = New System.Drawing.Point(705, 159)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(567, 448)
        Me.Panel2.TabIndex = 90
        '
        'txtGoodDPLessThan
        '
        Me.txtGoodDPLessThan.Location = New System.Drawing.Point(410, 320)
        Me.txtGoodDPLessThan.Name = "txtGoodDPLessThan"
        Me.txtGoodDPLessThan.Size = New System.Drawing.Size(47, 20)
        Me.txtGoodDPLessThan.TabIndex = 109
        Me.txtGoodDPLessThan.Text = "60"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(338, 326)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(71, 13)
        Me.Label13.TabIndex = 108
        Me.Label13.Text = "Dew Point <="
        '
        'txtGoodHighGreaterThan
        '
        Me.txtGoodHighGreaterThan.Location = New System.Drawing.Point(410, 291)
        Me.txtGoodHighGreaterThan.Name = "txtGoodHighGreaterThan"
        Me.txtGoodHighGreaterThan.Size = New System.Drawing.Size(47, 20)
        Me.txtGoodHighGreaterThan.TabIndex = 107
        Me.txtGoodHighGreaterThan.Text = "60"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(338, 294)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(70, 13)
        Me.Label14.TabIndex = 106
        Me.Label14.Text = "Daily High >="
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(339, 240)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(125, 13)
        Me.Label15.TabIndex = 105
        Me.Label15.Text = "Good Day Definition:"
        '
        'txtGoodHighLessThan
        '
        Me.txtGoodHighLessThan.Location = New System.Drawing.Point(410, 265)
        Me.txtGoodHighLessThan.Name = "txtGoodHighLessThan"
        Me.txtGoodHighLessThan.Size = New System.Drawing.Size(47, 20)
        Me.txtGoodHighLessThan.TabIndex = 104
        Me.txtGoodHighLessThan.Text = "85"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(338, 268)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(70, 13)
        Me.Label16.TabIndex = 103
        Me.Label16.Text = "Daily High <="
        '
        'txtDPLessThan
        '
        Me.txtDPLessThan.Location = New System.Drawing.Point(410, 190)
        Me.txtDPLessThan.Name = "txtDPLessThan"
        Me.txtDPLessThan.Size = New System.Drawing.Size(47, 20)
        Me.txtDPLessThan.TabIndex = 102
        Me.txtDPLessThan.Text = "50"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(338, 193)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(71, 13)
        Me.Label12.TabIndex = 101
        Me.Label12.Text = "Dew Point <="
        '
        'txtHighGreaterThan
        '
        Me.txtHighGreaterThan.Location = New System.Drawing.Point(410, 161)
        Me.txtHighGreaterThan.Name = "txtHighGreaterThan"
        Me.txtHighGreaterThan.Size = New System.Drawing.Size(47, 20)
        Me.txtHighGreaterThan.TabIndex = 100
        Me.txtHighGreaterThan.Text = "65"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(338, 164)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 13)
        Me.Label11.TabIndex = 99
        Me.Label11.Text = "Daily High >="
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(339, 110)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(136, 13)
        Me.Label10.TabIndex = 98
        Me.Label10.Text = "Perfect Day Definition:"
        '
        'txtHighLessThan
        '
        Me.txtHighLessThan.Location = New System.Drawing.Point(410, 135)
        Me.txtHighLessThan.Name = "txtHighLessThan"
        Me.txtHighLessThan.Size = New System.Drawing.Size(47, 20)
        Me.txtHighLessThan.TabIndex = 97
        Me.txtHighLessThan.Text = "75"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(338, 138)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 96
        Me.Label9.Text = "Daily High <="
        '
        'txtLocations
        '
        Me.txtLocations.Location = New System.Drawing.Point(410, 359)
        Me.txtLocations.Name = "txtLocations"
        Me.txtLocations.Size = New System.Drawing.Size(47, 20)
        Me.txtLocations.TabIndex = 95
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(343, 366)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 13)
        Me.Label8.TabIndex = 94
        Me.Label8.Text = "Locations:"
        '
        'lblZipCode
        '
        Me.lblZipCode.AutoSize = True
        Me.lblZipCode.Location = New System.Drawing.Point(337, 66)
        Me.lblZipCode.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblZipCode.Name = "lblZipCode"
        Me.lblZipCode.Size = New System.Drawing.Size(154, 13)
        Me.lblZipCode.TabIndex = 93
        Me.lblZipCode.Text = "Try a different zip code for data"
        Me.lblZipCode.Visible = False
        '
        'btnResults
        '
        Me.btnResults.Enabled = False
        Me.btnResults.Location = New System.Drawing.Point(14, 12)
        Me.btnResults.Name = "btnResults"
        Me.btnResults.Size = New System.Drawing.Size(110, 23)
        Me.btnResults.TabIndex = 92
        Me.btnResults.Text = "View Weather Data"
        Me.btnResults.UseVisualStyleBackColor = True
        '
        'txtDaysCount
        '
        Me.txtDaysCount.Location = New System.Drawing.Point(405, 41)
        Me.txtDaysCount.Name = "txtDaysCount"
        Me.txtDaysCount.Size = New System.Drawing.Size(55, 20)
        Me.txtDaysCount.TabIndex = 91
        '
        'lblDaysCount
        '
        Me.lblDaysCount.AutoSize = True
        Me.lblDaysCount.Location = New System.Drawing.Point(338, 44)
        Me.lblDaysCount.Name = "lblDaysCount"
        Me.lblDaysCount.Size = New System.Drawing.Size(61, 13)
        Me.lblDaysCount.TabIndex = 90
        Me.lblDaysCount.Text = "Days in file:"
        '
        'list1
        '
        Me.list1.FormattingEnabled = True
        Me.list1.Location = New System.Drawing.Point(14, 41)
        Me.list1.Name = "list1"
        Me.list1.Size = New System.Drawing.Size(319, 381)
        Me.list1.TabIndex = 89
        '
        'txtDataDirectory
        '
        Me.txtDataDirectory.Location = New System.Drawing.Point(151, 43)
        Me.txtDataDirectory.Name = "txtDataDirectory"
        Me.txtDataDirectory.Size = New System.Drawing.Size(541, 20)
        Me.txtDataDirectory.TabIndex = 124
        '
        'btnFindDataDirectory
        '
        Me.btnFindDataDirectory.Location = New System.Drawing.Point(17, 41)
        Me.btnFindDataDirectory.Name = "btnFindDataDirectory"
        Me.btnFindDataDirectory.Size = New System.Drawing.Size(128, 23)
        Me.btnFindDataDirectory.TabIndex = 123
        Me.btnFindDataDirectory.Text = "Select Data Directory:"
        Me.btnFindDataDirectory.UseVisualStyleBackColor = True
        '
        'lbl1
        '
        Me.lbl1.AutoSize = True
        Me.lbl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1.Location = New System.Drawing.Point(9, 12)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(514, 17)
        Me.lbl1.TabIndex = 133
        Me.lbl1.Text = "1. Select your weather data directory (or choose a new directory to save data in)" &
    ""
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(9, 93)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(950, 17)
        Me.Label20.TabIndex = 134
        Me.Label20.Text = "2. Use the web browser window below to fina a weather station. (You can also find" &
    " a station list at ftp://ftp.ncdc.noaa.gov/pub/data/noaa/isd-history.txt)"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(27, 110)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(571, 17)
        Me.Label23.TabIndex = 135
        Me.Label23.Text = "Click the wronch icon beside the active layer and click on identify to find a sta" &
    "tion number."
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.Controls.Add(Me.lblStatus)
        Me.Panel3.Controls.Add(Me.PicStatus)
        Me.Panel3.Location = New System.Drawing.Point(845, 632)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(427, 117)
        Me.Panel3.TabIndex = 140
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(141, 83)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(12, 17)
        Me.lblStatus.TabIndex = 140
        Me.lblStatus.Text = " "
        '
        'PicStatus
        '
        Me.PicStatus.Location = New System.Drawing.Point(18, 9)
        Me.PicStatus.Name = "PicStatus"
        Me.PicStatus.Size = New System.Drawing.Size(108, 91)
        Me.PicStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicStatus.TabIndex = 139
        Me.PicStatus.TabStop = False
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel4.Controls.Add(Me.Label21)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.txtLocationName)
        Me.Panel4.Controls.Add(Me.Label27)
        Me.Panel4.Controls.Add(Me.btnDownloadData)
        Me.Panel4.Controls.Add(Me.rdoDLInternational)
        Me.Panel4.Controls.Add(Me.rdoDLUSA)
        Me.Panel4.Controls.Add(Me.Label26)
        Me.Panel4.Controls.Add(Me.txtStationID)
        Me.Panel4.Controls.Add(Me.Label25)
        Me.Panel4.Location = New System.Drawing.Point(17, 617)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(675, 133)
        Me.Panel4.TabIndex = 141
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(19, 19)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(307, 17)
        Me.Label21.TabIndex = 147
        Me.Label21.Text = " or International for stations outside of the USA."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(1, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(543, 17)
        Me.Label1.TabIndex = 146
        Me.Label1.Text = "3. Type the station id into the station lookup box below, and select LCD for USA " &
    "data,"
        '
        'txtLocationName
        '
        Me.txtLocationName.Location = New System.Drawing.Point(394, 72)
        Me.txtLocationName.Name = "txtLocationName"
        Me.txtLocationName.Size = New System.Drawing.Size(179, 20)
        Me.txtLocationName.TabIndex = 145
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(294, 73)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(94, 15)
        Me.Label27.TabIndex = 144
        Me.Label27.Text = "Location Name:"
        '
        'btnDownloadData
        '
        Me.btnDownloadData.Location = New System.Drawing.Point(447, 108)
        Me.btnDownloadData.Name = "btnDownloadData"
        Me.btnDownloadData.Size = New System.Drawing.Size(126, 23)
        Me.btnDownloadData.TabIndex = 143
        Me.btnDownloadData.Text = "Download Data"
        Me.btnDownloadData.UseVisualStyleBackColor = True
        '
        'rdoDLInternational
        '
        Me.rdoDLInternational.AutoSize = True
        Me.rdoDLInternational.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoDLInternational.Location = New System.Drawing.Point(9, 91)
        Me.rdoDLInternational.Name = "rdoDLInternational"
        Me.rdoDLInternational.Size = New System.Drawing.Size(170, 19)
        Me.rdoDLInternational.TabIndex = 142
        Me.rdoDLInternational.Tag = "rdoDL"
        Me.rdoDLInternational.Text = "Daily Global (international)"
        Me.rdoDLInternational.UseVisualStyleBackColor = True
        '
        'rdoDLUSA
        '
        Me.rdoDLUSA.AutoSize = True
        Me.rdoDLUSA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoDLUSA.Location = New System.Drawing.Point(9, 68)
        Me.rdoDLUSA.Name = "rdoDLUSA"
        Me.rdoDLUSA.Size = New System.Drawing.Size(104, 19)
        Me.rdoDLUSA.TabIndex = 141
        Me.rdoDLUSA.Tag = "rdoDL"
        Me.rdoDLUSA.Text = "LCD (US data)"
        Me.rdoDLUSA.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(0, 42)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(241, 15)
        Me.Label26.TabIndex = 140
        Me.Label26.Text = "File type: (needed to know when formating)"
        '
        'txtStationID
        '
        Me.txtStationID.Location = New System.Drawing.Point(394, 41)
        Me.txtStationID.Name = "txtStationID"
        Me.txtStationID.Size = New System.Drawing.Size(179, 20)
        Me.txtStationID.TabIndex = 139
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(269, 42)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(119, 15)
        Me.Label25.TabIndex = 138
        Me.Label25.Text = "Station ID to look up:"
        '
        'frmConvert
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1284, 761)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.lbl1)
        Me.Controls.Add(Me.txtDataDirectory)
        Me.Controls.Add(Me.btnFindDataDirectory)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblCurrentURL)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Panel3)
        Me.Name = "frmConvert"
        Me.Text = "Convert Data"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PicStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents folder1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Label24 As Label
    Friend WithEvents lblCurrentURL As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BrowserWindow As WebBrowser
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtGoodDPLessThan As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtGoodHighGreaterThan As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents txtGoodHighLessThan As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtDPLessThan As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtHighGreaterThan As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtHighLessThan As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtLocations As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents lblZipCode As Label
    Friend WithEvents btnResults As Button
    Friend WithEvents txtDaysCount As TextBox
    Friend WithEvents lblDaysCount As Label
    Friend WithEvents list1 As ListBox
    Friend WithEvents folderDataFolder As FolderBrowserDialog
    Friend WithEvents txtDataDirectory As TextBox
    Friend WithEvents btnFindDataDirectory As Button
    Friend WithEvents lbl1 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblStatus As Label
    Friend WithEvents PicStatus As PictureBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label21 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtLocationName As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents btnDownloadData As Button
    Friend WithEvents rdoDLInternational As RadioButton
    Friend WithEvents rdoDLUSA As RadioButton
    Friend WithEvents Label26 As Label
    Friend WithEvents txtStationID As TextBox
    Friend WithEvents Label25 As Label
End Class
