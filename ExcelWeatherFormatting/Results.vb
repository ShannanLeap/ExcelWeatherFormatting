Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel
Imports Microsoft.Office
Imports System.Runtime.InteropServices
Imports System.Data.OleDb
Imports System.Text.RegularExpressions


Public Class Results

    Dim dtWeatherResults As New DataTable
    Dim dtChartData As New DataTable

    Private Sub Results_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' clear out data table
        dtWeatherResults.Dispose()
    End Sub

    Private Sub Results_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.SizeChanged
        Call resizeControls()
    End Sub


    Private Sub Results_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call resizeControls()

        ' loads csv data into a data table for viewing the summary data for each location in the list box
        If frmConvert.list1.Items.Count < 1 Then Exit Sub

        Cursor = Cursors.WaitCursor
        If dtWeatherResults.Columns.Count > 0 Then
            dtWeatherResults = Nothing
        End If

        ' do this for each data file (each location)
        For Each item In frmConvert.list1.Items
            Call NOAADataToDataTable(frmConvert.txtDataDirectory.Text & "\" & item.ToString)
            Call processData(item.ToString)
        Next item

        Cursor = Cursors.Default

    End Sub

    Private Sub resizeControls()
        Panel1.Height = Me.Height * 0.45
        Panel1.Width = Me.Width * 0.99

        DataGridView1.Height = Panel1.Height
        DataGridView1.Width = Panel1.Width

        Panel2.Height = Me.Height * 0.45
        Panel2.Width = Me.Width * 0.99

        chtDailyAverages.Height = Panel2.Height
        chtDailyAverages.Width = Panel2.Width



    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Call resizeControls()
    End Sub

    Private Sub processData(fileName As String)
        ' processing a data file and save into the dataTable

        If frmConvert.list1.Items.Count > 0 Then

            Dim strStationName As String = ""
            Dim dblTotalTemperature As Double = 0
            Dim dtRow As DataRow
            Dim dblTotalDewPoint As Double = 0
            Dim dblTotalWindSpeed As Double = 0
            Dim intDaysHighLess32 As Integer = 0
            Dim intDaysHighLess50 As Integer = 0
            Dim intDaysHighMore90 As Integer = 0
            Dim intAverageSummerDP As Integer = 0
            Dim dblTotalSummerDP As Double = 0
            Dim intPerfectDay As Integer = 0
            Dim intGreatDay As Integer = 0

            Dim intTotalDaysTemperature As Integer = 0
            Dim intTotalDaysDewPoint As Integer = 0
            Dim intTotalDaysWindSpeed As Integer = 0

            Dim intTotalRainDays As Integer = 0
            Dim dblTotalRain As Double = 0
            Dim intTotalSnowDays As Integer = 0
            Dim dblTotalSnow As Double = 0
            Dim dblHousePrice As Double = 0

            Dim intTotalDaysWithValues As Integer = 0


            If dtWeatherResults.Columns.Count < 1 Then
                ' if the table has not already has been built
                Call buildDataTable()
            End If




            For y = 0 To dtNOAAResults.Rows.Count - 1
                ' daily average dry bulb temperature
                If IsNumeric(dtNOAAResults.Rows(y).Item(4).ToString) = True Then
                    dblTotalTemperature = dblTotalTemperature + CInt(dtNOAAResults.Rows(y).Item(4).ToString)
                    intTotalDaysTemperature = intTotalDaysTemperature + 1
                End If

                If IsNumeric(dtNOAAResults.Rows(y).Item(3).ToString) = True Then
                    ' daily average dew point temp
                    dblTotalDewPoint = dblTotalDewPoint + CInt(dtNOAAResults.Rows(y).Item(3).ToString)
                    intTotalDaysDewPoint = intTotalDaysDewPoint + 1

                    'USA DATA
                    If Mid(fileName, 1, 1) <> "_" Then  'USA Data
                        If CInt(Mid((dtNOAAResults.Rows(y).Item(1).ToString), 6, 2)) >= 6 And CInt(Mid((dtNOAAResults.Rows(y).Item(1).ToString), 6, 2)) <= 8 Then
                            ' summer months
                            dblTotalSummerDP = dblTotalSummerDP + CInt(dtNOAAResults.Rows(y).Item(3).ToString)
                            intAverageSummerDP = intAverageSummerDP + 1
                        End If
                    Else
                        ' INTERNATIONAL DATA
                        If CInt(Mid((dtNOAAResults.Rows(y).Item(1).ToString), 1, 2)) >= 6 And CInt(Mid((dtNOAAResults.Rows(y).Item(1).ToString), 1, 2)) <= 8 Then
                            ' summer months
                            dblTotalSummerDP = dblTotalSummerDP + CInt(dtNOAAResults.Rows(y).Item(3).ToString)
                            intAverageSummerDP = intAverageSummerDP + 1
                        End If
                    End If
                End If

                If IsNumeric(dtNOAAResults.Rows(y).Item(9).ToString) = True Then
                    ' daily average wind speed
                    dblTotalWindSpeed = dblTotalWindSpeed + CInt(dtNOAAResults.Rows(y).Item(9).ToString)
                    intTotalDaysWindSpeed = intTotalDaysWindSpeed + 1
                End If

                If IsNumeric(dtNOAAResults.Rows(y).Item(13).ToString) = True Then
                    ' max temperature for the day
                    If CInt(dtNOAAResults.Rows(y).Item(13).ToString) <= 50 Then
                        intDaysHighLess50 = intDaysHighLess50 + 1
                        If CInt(dtNOAAResults.Rows(y).Item(13).ToString) <= 32 Then
                            intDaysHighLess32 = intDaysHighLess32 + 1
                        End If
                    ElseIf CInt(dtNOAAResults.Rows(y).Item(13).ToString) >= 90 Then
                        intDaysHighMore90 = intDaysHighMore90 + 1
                    End If
                End If

                ' if there is a number in dailyAverageDP and dailyMaxDryBulbTemp
                If IsNumeric(dtNOAAResults.Rows(y).Item(13).ToString) = True And IsNumeric(dtNOAAResults.Rows(y).Item(3).ToString) = True Then
                    ' max temperature and dew point temperature fit the perfect day requirement
                    If CInt(dtNOAAResults.Rows(y).Item(13).ToString) <= frmConvert.txtHighLessThan.Text And CInt(dtNOAAResults.Rows(y).Item(13).ToString) >= frmConvert.txtHighGreaterThan.Text And dtNOAAResults.Rows(y).Item(3).ToString <= frmConvert.txtDPLessThan.Text Then
                        intPerfectDay = intPerfectDay + 1
                        ' 2024 ElseIf IsNumeric(dtNOAAResults.Rows(y).Item(8).ToString) = True And IsNumeric(dtNOAAResults.Rows(y).Item(3).ToString) = True Then

                        ' max temp and DP fit great day requirement
                    ElseIf CInt(dtNOAAResults.Rows(y).Item(13).ToString) <= frmConvert.txtGoodHighLessThan.Text And CInt(dtNOAAResults.Rows(y).Item(13).ToString) >= frmConvert.txtGoodHighGreaterThan.Text And dtNOAAResults.Rows(y).Item(3).ToString <= frmConvert.txtGoodDPLessThan.Text Then
                        intGreatDay = intGreatDay + 1
                        ' 2024 End If
                    End If
                End If

                If IsNumeric(dtNOAAResults.Rows(y).Item(17).ToString) = True Then
                    ' if value for rain
                    dblTotalRain = dblTotalRain + CDbl(dtNOAAResults.Rows(y).Item(17).ToString)
                    If CDbl(dtNOAAResults.Rows(y).Item(17).ToString) > 0 Then
                        intTotalRainDays = intTotalRainDays + 1
                    End If
                End If

                If IsNumeric(dtNOAAResults.Rows(y).Item(19).ToString) = True Then
                    ' if value for snow
                    dblTotalSnow = dblTotalSnow + CDbl(dtNOAAResults.Rows(y).Item(19).ToString)
                    If CDbl(dtNOAAResults.Rows(y).Item(19).ToString) > 0 Then
                        intTotalSnowDays = intTotalSnowDays + 1
                    End If
                End If

                If dtNOAAResults.Columns.Count = 26 Then
                    If IsNumeric(dtNOAAResults.Rows(y).Item(25).ToString) = True Then
                        ' median house price
                        dblHousePrice = dtNOAAResults.Rows(y).Item(25).ToString
                    End If
                End If


                If IsNumeric(dtNOAAResults.Rows(y).Item(3).ToString) And IsNumeric(dtNOAAResults.Rows(y).Item(13).ToString) And IsNumeric(dtNOAAResults.Rows(y).Item(4).ToString) Then
                    intTotalDaysWithValues = intTotalDaysWithValues + 1
                End If

            Next

            dtRow = dtWeatherResults.NewRow()

            dtRow.Item("Name") = fileName.ToString
            dtRow.Item("TotalDays") = dtNOAAResults.Rows.Count
            dtRow.Item("DaysCalculated") = intTotalDaysWithValues

            If dblTotalTemperature > 0 And intTotalDaysTemperature > 0 Then
                dtRow.Item("AverageTemperature") = CInt(dblTotalTemperature / intTotalDaysTemperature)
            End If

            If dblTotalDewPoint > 0 And intTotalDaysDewPoint > 0 Then
                dtRow.Item("AverageDewPoint") = CInt(dblTotalDewPoint / intTotalDaysDewPoint)
            End If

            If dblTotalWindSpeed > 0 And intTotalDaysWindSpeed > 0 Then
                dtRow.Item("AverageWindSpeed") = CInt(dblTotalWindSpeed / intTotalDaysWindSpeed)
            End If

            If dblTotalSummerDP > 0 And intTotalDaysDewPoint > 0 Then
                dtRow.Item("AverageSummerDP") = CInt(dblTotalSummerDP / intAverageSummerDP)
            End If

            dtRow.Item("DaysLess32") = intDaysHighLess32
            dtRow.Item("DaysLess50") = intDaysHighLess50
            dtRow.Item("DaysMore90") = intDaysHighMore90
            dtRow.Item("DaysPerfect") = intPerfectDay
            dtRow.Item("DaysGreat") = intGreatDay
            dtRow.Item("TotalGoodDays") = intGreatDay + intPerfectDay

            dtRow.Item("TotalRainDays") = intTotalRainDays
            dtRow.Item("TotalRain") = CInt(dblTotalRain)
            dtRow.Item("TotalSnowDays") = intTotalSnowDays
            dtRow.Item("TotalSnow") = CInt(dblTotalSnow)
            dtRow.Item("HousePrice") = dblHousePrice

            dtWeatherResults.Rows.Add(dtRow)


            intTotalDaysDewPoint = 0
            intTotalDaysTemperature = 0
            intTotalDaysWindSpeed = 0
            dblTotalTemperature = 0
            dblTotalDewPoint = 0
            dblTotalWindSpeed = 0
            intDaysHighLess32 = 0
            intDaysHighLess50 = 0
            intDaysHighMore90 = 0
            dblTotalSummerDP = 0
            intAverageSummerDP = 0
            intPerfectDay = 0
            intGreatDay = 0
            dblTotalRain = 0
            intTotalRainDays = 0
            intTotalDaysWithValues = 0




            DataGridView1.DataSource = dtWeatherResults

            DataGridView1.Columns(1).DefaultCellStyle.Format = "###,###"
            DataGridView1.Columns(2).DefaultCellStyle.Format = "###,###"
            DataGridView1.Columns(5).DefaultCellStyle.Format = "###,###"
            DataGridView1.Columns(6).DefaultCellStyle.Format = "###,###"
            DataGridView1.Columns(7).DefaultCellStyle.Format = "###,###"
            DataGridView1.Columns(9).DefaultCellStyle.Format = "###,###"
            DataGridView1.Columns(10).DefaultCellStyle.Format = "###,###"
            DataGridView1.Columns(11).DefaultCellStyle.Format = "###,###"
            DataGridView1.Columns(12).DefaultCellStyle.Format = "###,###"
            DataGridView1.Columns(14).DefaultCellStyle.Format = "###,###"
            DataGridView1.Columns(17).DefaultCellStyle.Format = "###,###"

            dtNOAAResults.Clear()

        End If
    End Sub


    Private Sub buildDataTable()
        ' builds a data table to store the data in
        dtWeatherResults.Columns.Add("Name", GetType(String))
        dtWeatherResults.Columns.Add("TotalDays", GetType(Integer))
        dtWeatherResults.Columns.Add("DaysCalculated", GetType(Integer))
        dtWeatherResults.Columns.Add("AverageTemperature", GetType(Integer))
        dtWeatherResults.Columns.Add("AverageDewPoint", GetType(Integer))
        dtWeatherResults.Columns.Add("AverageWindSpeed", GetType(Integer))
        dtWeatherResults.Columns.Add("DaysLess32", GetType(Integer))
        dtWeatherResults.Columns.Add("DaysLess50", GetType(Integer))
        dtWeatherResults.Columns.Add("DaysMore90", GetType(Integer))
        dtWeatherResults.Columns.Add("AverageSummerDP", GetType(Integer))
        dtWeatherResults.Columns.Add("DaysPerfect", GetType(Integer))
        dtWeatherResults.Columns.Add("DaysGreat", GetType(Integer))
        dtWeatherResults.Columns.Add("TotalGoodDays", GetType(Integer))
        dtWeatherResults.Columns.Add("TotalRainDays", GetType(Integer))
        dtWeatherResults.Columns.Add("TotalRain", GetType(Integer))
        dtWeatherResults.Columns.Add("TotalSnowDays", GetType(Integer))
        dtWeatherResults.Columns.Add("TotalSnow", GetType(Integer))
        dtWeatherResults.Columns.Add("HousePrice", GetType(Double))
    End Sub

    Private Sub btnOpen_Click(sender As System.Object, e As System.EventArgs) Handles btnOpen.Click

        If dtWeatherResults.Columns.Count <> 13 Then
            dtWeatherResults.Clear()
            Call buildDataTable()
        End If

        Call openData()

        Call formatGrid()
    End Sub

    Private Sub formatGrid()
        ' formats the data grid

        With DataGridView1.Columns("TotalDays")
            .ValueType = Type.GetType("System.Decimal")
            .DefaultCellStyle.Format = "###,###,###"
        End With

        With DataGridView1.Columns("DaysCalculated")
            .ValueType = Type.GetType("System.Decimal")
            .DefaultCellStyle.Format = "###,###,###"
        End With

        With DataGridView1.Columns("DaysLess32")
            .ValueType = Type.GetType("System.Decimal")
            .DefaultCellStyle.Format = "###,###,###"
        End With

        With DataGridView1.Columns("DaysLess50")
            .ValueType = Type.GetType("System.Decimal")
            .DefaultCellStyle.Format = "###,###,###"
        End With

        With DataGridView1.Columns("DaysMore90")
            .ValueType = Type.GetType("System.Decimal")
            .DefaultCellStyle.Format = "###,###,###"
        End With

        With DataGridView1.Columns("DaysPerfect")
            .ValueType = Type.GetType("System.Decimal")
            .DefaultCellStyle.Format = "###,###,###"
        End With

        With DataGridView1.Columns("DaysGreat")
            .ValueType = Type.GetType("System.Decimal")
            .DefaultCellStyle.Format = "###,###,###"
        End With

        With DataGridView1.Columns("TotalGoodDays")
            .ValueType = Type.GetType("System.Decimal")
            .DefaultCellStyle.Format = "###,###,###"
        End With

        With DataGridView1.Columns("TotalRainDays")
            .ValueType = Type.GetType("System.Decimal")
            .DefaultCellStyle.Format = "###,###,###"
        End With

        With DataGridView1.Columns("HousePrice")
            .ValueType = Type.GetType("System.Decimal")
            .DefaultCellStyle.Format = "###,###,###"
        End With
    End Sub

    Private Sub openData()


        Dim folder = frmConvert.folder1.SelectedPath
        Dim CnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & frmConvert.txtDataDirectory.Text & ";Extended Properties=""text;HDR=No;FMT=Delimited"";"
        Dim dt1 As New DataTable

        Using Adp As New OleDbDataAdapter("select * from [Weather.csv]", CnStr)
            Adp.Fill(dt1)
        End Using


        Dim newdr As DataRow
        dtWeatherResults.Clear()

        For x = 0 To dt1.Rows.Count - 1
            newdr = dtWeatherResults.NewRow
            newdr.ItemArray = dt1.Rows(x).ItemArray
            dtWeatherResults.Rows.Add(newdr)
        Next


        DataGridView1.DataSource = dtWeatherResults
        dt1.Dispose()
    End Sub

    Private Sub g_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click

        ' Save the input DataTable to a CSV file. By default the values are Tab 
        ' delimited, but you can use the second overload version to use any other 
        ' string you want.

        Dim ds As New DataSet
        '    SqlDataAdapter1.Fill(ds, "Users")
        DataTable2CSV2(dtWeatherResults, frmConvert.txtDataDirectory.Text & " \Weather.csv", ",")

        dtWeatherResults.Dispose()
        Me.Close()
    End Sub

    Private Sub DataTable2CSV(ByVal table As DataTable, ByVal filename As String, ByVal sepChar As String)

        ' takes the edited data table, and saves is back to a CSV file
        Dim writer As System.IO.StreamWriter

        Try
            writer = New System.IO.StreamWriter(filename)

            ' first write a line with the columns name
            Dim sep As String = ""
            Dim builder As New System.Text.StringBuilder



            For Each row As DataRow In table.Rows
                For Each col As DataColumn In table.Columns
                    builder.Append(sep).Append(row(col.ColumnName))
                    sep = sepChar
                Next

                writer.WriteLine(builder.ToString())
                builder.Clear()
                sep = ""
            Next
        Finally
            If Not writer Is Nothing Then writer.Close()
        End Try
    End Sub

    Private Sub DataTable2CSV2(ByVal table As DataTable, ByVal filename As String, ByVal sepChar As String)
        ' takes the edited data table, and saves is back to a CSV file

        Dim path As String = filename
        Dim builder As New System.Text.StringBuilder
        Dim sep As String = ""

        ' This text is added only once to the file.
        If Not File.Exists(path) Then

            'Create a file to write to.
            Dim sw As StreamWriter
            ' Dim writer As System.IO.StreamWriter

            sw = File.CreateText(path)

            Using sw

                For Each row As DataRow In table.Rows
                    For Each col As DataColumn In table.Columns
                        builder.Append(sep).Append(row(col.ColumnName))
                        sep = sepChar
                    Next

                    sw.WriteLine(builder.ToString())
                    builder.Clear()
                    sep = ""
                Next
            End Using

            sw.Close()
        Else
            'Create a file to write to.
            Dim sw As StreamWriter
            ' Dim writer As System.IO.StreamWriter

            sw = File.AppendText(path)

            Using sw

                For Each row As DataRow In table.Rows
                    For Each col As DataColumn In table.Columns
                        builder.Append(sep).Append(row(col.ColumnName))
                        sep = sepChar
                    Next

                    sw.WriteLine(builder.ToString())
                    builder.Clear()
                    sep = ""
                Next
            End Using

            sw.Close()
        End If
    End Sub


    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        ' get daily data and chart (high, low, dewpoint) 

        Dim fileName = frmConvert.txtDataDirectory.Text & "\" & DataGridView1.SelectedRows(0).Cells(0).Value

        ' call to get chart data
        Call getChartData(fileName)

        chtDailyAverages.Series.Clear()
        chtDailyAverages.ChartAreas("ChartArea1").AxisY.Maximum = 115
        chtDailyAverages.ChartAreas("ChartArea1").AxisY.Minimum = -10
        chtDailyAverages.ChartAreas("ChartArea1").AxisY.LabelStyle.Interval = 25


        ' daily dewpoints
        chtDailyAverages.Series.Add("DewPoint")
        chtDailyAverages.Series(0).Color = Color.Green
        chtDailyAverages.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Line
        ' daily highs
        chtDailyAverages.Series.Add("High")
        chtDailyAverages.Series(1).Color = Color.OrangeRed
        chtDailyAverages.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Line
        ' daily lows
        chtDailyAverages.Series.Add("Low")
        chtDailyAverages.Series(2).Color = Color.MediumSlateBlue
        chtDailyAverages.Series(2).ChartType = DataVisualization.Charting.SeriesChartType.Line


        For Each row As DataRow In dtChartData.Rows
            If Not IsDBNull(row.Item(0)) And Not IsDBNull(row.Item(1)) And Not IsDBNull(row.Item(2)) Then
                chtDailyAverages.Series(0).Points.Add(row.Item(0))
                chtDailyAverages.Series(1).Points.Add(row.Item(1))
                chtDailyAverages.Series(2).Points.Add(row.Item(2))
            End If
        Next

    End Sub

    Public Sub getChartData(ByVal filename As String)
        'only query out dewpoint, high and low from the CSV file and save it to a data table

        Dim matchFound As Match
        matchFound = Regex.Match(filename, "(.*)\\(.*\..*)[\\]?", RegexOptions.IgnoreCase)

        Dim CnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & matchFound.Groups(1).Value & ";Extended Properties=""text;HDR=No;FMT=Delimited"";"


        Dim dt1 As New DataTable

        dtChartData.Clear()

        'only query out dewpoint, high and low 

        Using Adp As New OleDbDataAdapter("select F4 as 'DP', F14 as 'MAX', F15 as 'MIN' from [" & matchFound.Groups(2).Value & "] where (F4 is not null and F15 is not null and F14 is not null)", CnStr)
            Adp.Fill(dtChartData)
        End Using

        ' remove header row
        dtChartData.Rows.RemoveAt(0)

    End Sub


End Class