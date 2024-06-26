Imports System.IO
Imports System.Data.OleDb
Imports System.Threading
Imports System.Net
Imports System.Text.RegularExpressions


Public Class frmConvert
    Dim strURL As String = "https://www.ncei.noaa.gov/maps/hourly/"
    Dim strCurrentFilePathAndName As String


    Private Sub formatDownloadedData(fileName As String)
        ' 2024 version since NOAA seems to have formatted their data differently now
        ' takes the downloaded data and removes a bunch of columns and rows
        ' I am only interested in rows that say "SOD" .... that means daily average

        ' I can't figure out how to have a different thread update the status pictures, so I am doing this line as a work around
        Me.CheckForIllegalCrossThreadCalls = False

        If rdoDLUSA.Checked = True Then ' USA data

            '    load the downloaded CSV data into a dataTable called dtNOAAResults
            NOAADataToDataTable(fileName)

            ' delete all hourly lines, but keep the daily ones...these are lines that say "SOD"
            ' fastest way was to filter and put into another data table called dtRersults
            Call deleteLinesThatAreNotDaily()

            If dtResults.Rows.Count > 2000 Then
                'Cursor = Cursors.WaitCursor

                ' here is where I start removing not needed data to cut down on processing time later and reduce storage size
                ' remove column D-T
                dtResults.Columns.RemoveAt(3)
                dtResults.Columns.RemoveAt(3)
                dtResults.Columns.RemoveAt(3)
                dtResults.Columns.RemoveAt(3)
                dtResults.Columns.RemoveAt(3)
                dtResults.Columns.RemoveAt(3)
                dtResults.Columns.RemoveAt(3)
                dtResults.Columns.RemoveAt(3)
                dtResults.Columns.RemoveAt(3)
                dtResults.Columns.RemoveAt(3)
                dtResults.Columns.RemoveAt(3)
                dtResults.Columns.RemoveAt(3)
                dtResults.Columns.RemoveAt(3)
                dtResults.Columns.RemoveAt(3)
                dtResults.Columns.RemoveAt(3)
                dtResults.Columns.RemoveAt(3)
                dtResults.Columns.RemoveAt(3)

                ' remove columns x-cz 
                Try
                    For x = 23 To 103
                        dtResults.Columns.RemoveAt(23)
                    Next
                Catch ex As Exception
                End Try

                dtResults.Columns.RemoveAt(25)

                ' remove any "T" (for trace) in the data table and set it to 0... T could show up in rows 17,18,or 19 it seems
                For Each row In dtResults.Rows
                    If Not IsDBNull(row(17)) Then
                        If Trim(row(17)) = "T" Then
                            row(17) = 0
                        End If
                    End If

                    If Not IsDBNull(row(18)) Then
                        If Trim(row(18)) = "T" Then
                            row(18) = 0
                        End If
                    End If

                    If Not IsDBNull(row(19)) Then
                        If Trim(row(19)) = "T" Then
                            row(19) = 0
                        End If
                    End If

                Next

                ' strip out days with no humidity and high and low temperatures
                Dim dtResultsFiltered As New DataTable
                dtResultsFiltered = dtResults.Select("F21 is not null and F31 is not null and F32 is not null").CopyToDataTable()

                If dtResultsFiltered.Rows.Count > 1000 Then

                    DataTableToCSV(dtResults, fileName, ",")
                    'Cursor = Cursors.Default

                    MessageBox.Show("Success! Weather information downloaded to: " & txtDataDirectory.Text & "\" & txtLocationName.Text & "-" & txtStationID.Text & ".csv")
                Else
                    'call to delete the downloaded file
                    Call deleteFile(fileName)
                    MessageBox.Show("There was not enough weather data for this location!  Please try another one.")
                End If
            Else
                MessageBox.Show("This data already looks formatted!")
            End If


        ElseIf rdoDLInternational.Checked = True Then 'international data
            '    load the downloaded CSV data into a dataTable

            Dim matchFound As Match
                matchFound = Regex.Match(fileName, "(.*)\\(.*\..*)[\\]?", RegexOptions.IgnoreCase)

            fileName = matchFound.Groups(1).Value & "\_" & matchFound.Groups(2).Value

            NOAADataToDataTableInternational(fileName)

            Dim x As Integer = 0

            For Each row In dtResults.Rows
                If row.Item(0) <> "STATION" Then ' is NOT the header row
                    For Each column In dtResults.Columns
                        x = x + 1
                        If x > 3 Then ' no need to convert the first 3 columns
                            If column.columnname <> "Column1" And column.columnname <> "Column2" And column.columnname <> "Column3" Then ' these are columns "Station" "date" and "report"
                                If IsNumeric(row.item(column)) Then
                                    row.Item(column) = CInt(row.Item(column).ToString) ' set the weather data to whole numbers since international data is in decimal
                                End If
                            End If
                            End If
                    Next
                End If
            Next


            If dtResults.Rows.Count > 1000 Then

                DataTableToCSV(dtResults, fileName, ",")
                'Cursor = Cursors.Default

                MessageBox.Show("Success! Weather information downloaded to: " & txtDataDirectory.Text & "\" & txtLocationName.Text & "-" & txtStationID.Text & ".csv")
            Else
                'call to delete the downloaded file
                Call deleteFile(fileName)
                MessageBox.Show("There was not enough weather data for this location!  Please try another one.")
            End If
        End If

        dtNOAAResults.Clear()
        dtResults.Clear()
        dtResults.Dispose()
        dtNOAAResults.Dispose()


        PicStatus.Image = Nothing
        lblStatus.Text = ""

        txtLocationName.Enabled = True
        txtStationID.Enabled = True
        btnDownloadData.Enabled = True
        btnResults.Enabled = True

    End Sub

    Private Sub deleteFile(fileName As String)
        If System.IO.File.Exists(fileName) = True Then

            System.IO.File.Delete(fileName)
        End If

    End Sub
    Public Sub deleteLinesThatAreNotDaily()

        ' filter only daily lines out and the header line
        dtNOAAResults.DefaultView.RowFilter = "F3 = 'SOD' or F1 = 'STATION'"
        dtResults = dtNOAAResults.DefaultView.ToTable

    End Sub

    Public Function BIP_xlsDeleteColumnRange(sSrcPath, sDestPath, sStartCol, sEndCol) 'Create Excel object
        Try
            Dim oExcel = CreateObject("Excel.Application")
            'Sets the application to raise no app alerts
            'In this case it will allow a file overwrite w/o raising a ‘yes/no’ dialog
            oExcel.DisplayAlerts = False 'Open Book in Excel
            Dim oBook = oExcel.Workbooks.Open(sSrcPath)
            'Set Activesheet
            Dim oSheet = oExcel.Activesheet

            'Delete row range
            oSheet.Columns(sStartCol + ":" + sEndCol).Delete()

            'Save new book to Excel file
            oBook.SaveAs(sDestPath)

            'Close the xls file
            oExcel.Workbooks.Close()
            oExcel.quit()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

        Return True
    End Function


    Private Sub btnResults_Click(sender As System.Object, e As System.EventArgs) Handles btnResults.Click
        ' clears out the data table and shows the results form
        dtNOAAResults.Clear()
        dtNOAAResults.Dispose()
        Results.Show()

    End Sub


    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        lblCurrentURL.Text = strURL

        ' format the controls on the page depending on screen resolution
        Call formatAllControls()

        ' start a new thread to display the NOAA web page in the background (DOES NOT SEEM TO BE WORKING LIKE I WANT IT TO)
        Dim loadWebPageThread As New Thread(AddressOf loadWebPage)
        loadWebPageThread.Priority = ThreadPriority.AboveNormal
        loadWebPageThread.Start()


    End Sub
    Private Sub loadWebPage()

        BrowserWindow.Navigate(strURL)

    End Sub

    Private Sub formatAllControls()

        Panel1.Height = Me.Height * 0.65
        Panel1.Width = Me.Width * 0.5
        BrowserWindow.Height = Panel1.Height - 10
        BrowserWindow.Width = Panel1.Width - 10
        Panel2.Height = Me.Height * 0.65
        list1.Height = Panel1.Height * 0.9
    End Sub



    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Call formatAllControls()
    End Sub


    Private Sub list1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles list1.Click

        Dim intLineCount As Integer = 0
        Try ' Open the file to see how may lines it has
            If list1.SelectedIndex > -1 Then
                Using reader As New IO.StreamReader(txtDataDirectory.Text & "\" & list1.SelectedItem().ToString)
                    While Not reader.EndOfStream()
                        reader.ReadLine()

                        intLineCount = intLineCount + 1
                    End While

                    reader.Close()

                End Using
                txtDaysCount.Text = intLineCount

                If intLineCount < 3550 Or intLineCount > 3750 Then
                    txtDaysCount.ForeColor = Color.Red
                    lblZipCode.ForeColor = Color.Red
                    lblZipCode.Visible = True
                Else
                    txtDaysCount.ForeColor = Color.Black
                    lblZipCode.Visible = False
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LinkLabel1_Click(sender As Object, e As System.EventArgs)
        System.Diagnostics.Process.Start("https://www.ncdc.noaa.gov/cdo-web/datatools/lcd")
    End Sub


    Private Sub btnDownloadData_Click(sender As Object, e As EventArgs) Handles btnDownloadData.Click

        ' verify that the correct data is entered in first
        Dim URL As String
        If txtStationID.Text = "" Or txtLocationName.Text = "" Or txtDataDirectory.Text = "" Or (rdoDLUSA.Checked = False And rdoDLInternational.Checked = False) Then
            MessageBox.Show("You must enter your data directory, a station ID, file type and name the physical location! " & vbLf & "(ie: somwhere USA")
            Exit Sub
        End If

        txtLocationName.Enabled = False
        txtStationID.Enabled = False
        btnDownloadData.Enabled = False
        btnResults.Enabled = False

        ' set appropriate URL to download the data from
        If rdoDLUSA.Checked = True Then
            ' USA data
            URL = "https://www.ncei.noaa.gov/access/services/data/v1?dataset=local-climatological-data&stations=" & Trim(txtStationID.Text) & "&startDate=2014-01-01&endDate=2023-12-31&format=csv"
        Else
            ' International data
            URL = "https://www.ncei.noaa.gov/access/services/data/v1?dataset=global-summary-of-the-day&stations=" & Trim(txtStationID.Text) & "&startDate=2014-01-01&endDate=2023-12-31&format=csv"
        End If

        PicStatus.Image = ExcelWeatherFormatting.My.Resources.Resources.downloading_cat
        lblStatus.Text = "Downloading weather data..."

        ' the call to download the data from NOAA
        ' do this using a new thread so you can still interact with the web browser window while this is working
        Dim downloadData As New Thread(AddressOf downloadWeatherDataFromURL)
        downloadData.Priority = ThreadPriority.AboveNormal
        downloadData.Start(URL)

    End Sub


    Private Sub downloadWeatherDataFromURL(URL As String)
        ' Downloads the weather data from NOAA in CSV using the passed in URL

        Try
            ' Create a New WebClient instance
            Dim client As New WebClient

            ' I can't figure out how to have a different thread update the status pictures, so I am doing this line as a work around
            Me.CheckForIllegalCrossThreadCalls = False


            ' sets the CSV file name to save the NOAA data in
            If rdoDLUSA.Checked = True Then
                ' USA data
                strCurrentFilePathAndName = txtDataDirectory.Text & "\" & txtLocationName.Text & "-" & txtStationID.Text & ".csv"
            Else
                ' International data, so I add a "_" to the beginning of the file name so we know later it's international
                strCurrentFilePathAndName = txtDataDirectory.Text & "\_" & txtLocationName.Text & "-" & txtStationID.Text & ".csv"
            End If

            ' fire off the download and save the data
            client.DownloadFile(URL, strCurrentFilePathAndName)
        Catch ex As Exception
            MessageBox.Show("Error: " & vbLf & ex.Message, "Error...")
            txtLocationName.Enabled = True
            txtStationID.Enabled = True
            btnDownloadData.Enabled = True
            btnResults.Enabled = True
        End Try

        PicStatus.Image = ExcelWeatherFormatting.My.Resources.Resources.Processing
        lblStatus.Text = "Processing the data..."

        ' the call to format the data that was downloaded by removing or adding (not)needed stuff from it
        Call formatDownloadedData(txtDataDirectory.Text & "\" & txtLocationName.Text & "-" & txtStationID.Text & ".csv")

        Call populateListBox()

    End Sub


    Private Sub btnFindDataDirectory_Click(sender As Object, e As EventArgs) Handles btnFindDataDirectory.Click
        ' sets the directory that contains all of the weather data

        If folderDataFolder.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Call populateListBox()
        End If
    End Sub

    Private Sub populateListBox()
        ' puts all data files into a list box

        Dim di As New IO.DirectoryInfo(folderDataFolder.SelectedPath)
        txtDataDirectory.Text = di.FullName

        Dim diar1 As IO.FileInfo() = di.GetFiles()
        Dim dra As IO.FileInfo

        list1.Items.Clear()
        'list the names of all files in the specified directory (if there is already ones in there)
        For Each dra In diar1
            If InStr(dra.ToString, "csv") > 0 Then
                list1.Items.Add(dra)
            End If
        Next

        btnResults.Enabled = True

        txtLocations.Text = list1.Items.Count
    End Sub
End Class
