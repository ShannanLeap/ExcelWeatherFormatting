Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel
Imports Microsoft.Office
Imports System.Runtime.InteropServices
Imports System.Data.OleDb


Public Class Results

    Dim dtWeatherResults As New DataTable
    Dim dtChartData As New DataTable

    Private Sub Results_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' new version
        dtWeatherResults.Dispose()
    End Sub


    Private Sub Results_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ' new version
        If frmConvert.list1.SelectedIndex < 0 Then Exit Sub

        Cursor = Cursors.WaitCursor
        If dtWeatherResults.Columns.Count > 0 Then
            dtWeatherResults = Nothing
        End If

        If IsNumeric(Mid(frmConvert.list1.SelectedItem.ToString, Len(frmConvert.list1.SelectedItem.ToString) - 8, 5)) Then
            ' USA data
            Call NOAADataToDataTable(frmConvert.list1.SelectedItem.ToString)
        Else
            'international
            Call NOAADataToDataTableInternational(frmConvert.list1.SelectedItem.ToString)
        End If

        Call processData()
        Cursor = Cursors.Default

    End Sub

    Private Sub processData()
        ' new version
        ' processing a file and save into the dataTable

        'if zipcode is at the end of the file, then it is LCD data
        If frmConvert.list1.SelectedIndex > -1 Then

            Dim strStationName As String = ""
            Dim dblTotalTemperature As Double = 0 ' 5th field
            Dim dtRow As DataRow
            Dim dblTotalDewPoint As Double = 0 ' 3rd field
            Dim dblTotalWindSpeed As Double = 0 ' 8th field
            Dim intDaysHighLess32 As Integer = 0 ' 9th field
            Dim intDaysHighLess50 As Integer = 0 ' 9th field
            Dim intDaysHighMore90 As Integer = 0 ' 9th field
            Dim intAverageSummerDP As Integer = 0 '4th field
            Dim dblTotalSummerDP As Double = 0  '4th field
            Dim intPerfectDay As Integer = 0 ' multiple fields
            Dim intGreatDay As Integer = 0 ' multiple fields

            Dim intTotalDaysTemperature As Integer = 0
            Dim intTotalDaysDewPoint As Integer = 0
            Dim intTotalDaysWindSpeed As Integer = 0

            Dim intTotalRainDays As Integer = 0 ' 11th field
            Dim dblTotalRain As Double = 0
            Dim intTotalSnowDays As Integer = 0 ' 13th field
            Dim dblTotalSnow As Double = 0
            Dim dblHousePrice As Double = 0

            Dim intTotalDaysWithValues As Integer = 0


            If dtWeatherResults.Columns.Count < 1 Then
                ' if the table already has been built
                Call buildDataTable()
            End If

            'Call openData() ' loads any saved data into the DT first



            For y = 0 To dtNOAAResults.Rows.Count - 1
                ' average temperature
                If IsNumeric(dtNOAAResults.Rows(y).Item(4).ToString) = True Then
                    dblTotalTemperature = dblTotalTemperature + CInt(dtNOAAResults.Rows(y).Item(4).ToString)
                    intTotalDaysTemperature = intTotalDaysTemperature + 1
                End If

                If IsNumeric(dtNOAAResults.Rows(y).Item(3).ToString) = True Then
                    ' average dew point temp
                    dblTotalDewPoint = dblTotalDewPoint + CInt(dtNOAAResults.Rows(y).Item(3).ToString)
                    intTotalDaysDewPoint = intTotalDaysDewPoint + 1

                    'USA DATA
                    If IsNumeric(Mid(frmConvert.list1.SelectedItem.ToString, Len(frmConvert.list1.SelectedItem.ToString) - 8, 5)) Then
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

                    If IsNumeric(dtNOAAResults.Rows(y).Item(7).ToString) = True Then
                        ' average wind speed
                        dblTotalWindSpeed = dblTotalWindSpeed + CInt(dtNOAAResults.Rows(y).Item(7).ToString)
                        intTotalDaysWindSpeed = intTotalDaysWindSpeed + 1
                    End If

                    If IsNumeric(dtNOAAResults.Rows(y).Item(8).ToString) = True Then
                        ' max temperature
                        If CInt(dtNOAAResults.Rows(y).Item(8).ToString) <= 60 Then
                            intDaysHighLess50 = intDaysHighLess50 + 1
                            If CInt(dtNOAAResults.Rows(y).Item(8).ToString) < 32 Then
                                intDaysHighLess32 = intDaysHighLess32 + 1
                            End If
                        ElseIf CInt(dtNOAAResults.Rows(y).Item(8).ToString) >= 90 Then
                            intDaysHighMore90 = intDaysHighMore90 + 1
                        End If
                    End If

                    If IsNumeric(dtNOAAResults.Rows(y).Item(8).ToString) = True And IsNumeric(dtNOAAResults.Rows(y).Item(3).ToString) = True Then
                        ' max temperature and dew point temperature
                        If CInt(dtNOAAResults.Rows(y).Item(8).ToString) <= frmConvert.txtHighLessThan.Text And CInt(dtNOAAResults.Rows(y).Item(8).ToString) >= frmConvert.txtHighGreaterThan.Text And dtNOAAResults.Rows(y).Item(3).ToString <= frmConvert.txtDPLessThan.Text Then
                            intPerfectDay = intPerfectDay + 1
                        ElseIf IsNumeric(dtNOAAResults.Rows(y).Item(8).ToString) = True And IsNumeric(dtNOAAResults.Rows(y).Item(3).ToString) = True Then
                            If CInt(dtNOAAResults.Rows(y).Item(8).ToString) <= frmConvert.txtGoodHighLessThan.Text And CInt(dtNOAAResults.Rows(y).Item(8).ToString) >= frmConvert.txtGoodHighGreaterThan.Text And dtNOAAResults.Rows(y).Item(3).ToString <= frmConvert.txtGoodDPLessThan.Text Then
                                intGreatDay = intGreatDay + 1
                            End If
                        End If
                    End If

                    If IsNumeric(dtNOAAResults.Rows(y).Item(10).ToString) = True Then
                        ' if value for rain
                        dblTotalRain = dblTotalRain + CDbl(dtNOAAResults.Rows(y).Item(10).ToString)
                        If CDbl(dtNOAAResults.Rows(y).Item(10).ToString) > 0 Then
                            intTotalRainDays = intTotalRainDays + 1
                        End If
                    End If

                    If IsNumeric(dtNOAAResults.Rows(y).Item(12).ToString) = True Then
                        ' if value for snow
                        dblTotalSnow = dblTotalSnow + CDbl(dtNOAAResults.Rows(y).Item(12).ToString)
                        If CDbl(dtNOAAResults.Rows(y).Item(12).ToString) > 0 Then
                            intTotalSnowDays = intTotalSnowDays + 1
                        End If
                    End If

                    If dtNOAAResults.Columns.Count = 16 Then
                        If IsNumeric(dtNOAAResults.Rows(y).Item(15).ToString) = True Then
                            ' median house price
                            dblHousePrice = dtNOAAResults.Rows(y).Item(15).ToString
                        End If
                    End If


                    If IsNumeric(dtNOAAResults.Rows(y).Item(3).ToString) And IsNumeric(dtNOAAResults.Rows(y).Item(4).ToString) And IsNumeric(dtNOAAResults.Rows(y).Item(8).ToString) Then
                        intTotalDaysWithValues = intTotalDaysWithValues + 1
                    End If

            Next

            dtRow = dtWeatherResults.NewRow()

            dtRow.Item("Name") = frmConvert.list1.SelectedItem.ToString
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

        End If
    End Sub


    Private Sub buildDataTable()
        ' new version
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
        ' new version
        If dtWeatherResults.Columns.Count <> 13 Then
            dtWeatherResults.Clear()
            Call buildDataTable()
        End If

        Call openData()

        Call formatGrid()
    End Sub

    Private Sub formatGrid()
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
        ' new version

        Dim folder = frmConvert.folder1.SelectedPath
        Dim CnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & folder & ";Extended Properties=""text;HDR=No;FMT=Delimited"";"
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
        'DataGridView1.DefaultCellStyle.Format = "###,###"
        dt1.Dispose()
    End Sub

    Private Sub g_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        ' new version
        ' Save the input DataTable to a CSV file. By default the values are Tab 
        ' delimited, but you can use the second overload version to use any other 
        ' string you want.
        '
        ' Example:
        Dim ds As New DataSet
        '    SqlDataAdapter1.Fill(ds, "Users")
        DataTable2CSV2(dtWeatherResults, frmConvert.folder1.SelectedPath & " \Weather.csv", ",")

        dtWeatherResults.Dispose()
        Me.Close()
    End Sub

    Private Sub DataTable2CSV(ByVal table As DataTable, ByVal filename As String, ByVal sepChar As String)
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
        Dim fileName = frmConvert.folder1.SelectedPath & "\" & DataGridView1.SelectedRows(0).Cells(0).Value
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
        ' new version
        Dim folder = frmConvert.folder1.SelectedPath
        Dim CnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & folder & ";Extended Properties=""text;HDR=No;FMT=Delimited"";"
        Dim dt1 As New DataTable

        dtChartData.Clear()

        'only query out dewpoint, high and low
        If IsNumeric(Mid(DataGridView1.SelectedRows(0).Cells(0).Value, Len(DataGridView1.SelectedRows(0).Cells(0).Value) - 8, 5)) Then
            ' LCD USA data
            'Using Adp As New OleDbDataAdapter("select F4, F9, F10 from " & DataGridView1.SelectedRows(0).Cells(0).Value & " where (f4 is not null and f9 is not null and f10 is not null)", CnStr)
            Using Adp As New OleDbDataAdapter("select F4 as 'DP', F9 as 'MIN', F10 as 'MAX' from " & DataGridView1.SelectedRows(0).Cells(0).Value & " where (F4 is not null and F9 is not null and F10 is not null)", CnStr)
                Adp.Fill(dtChartData)
            End Using
        Else
            'International data
            'Using Adp As New OleDbDataAdapter("select F3, F6, F7 as from " & DataGridView1.SelectedRows(0).Cells(0).Value & " where (f3 is not null and f6 is not null and f7 is not null)", CnStr)
            Using Adp As New OleDbDataAdapter("select F3 as 'DP', F6 as 'MIN', F7 as 'MAX' from " & DataGridView1.SelectedRows(0).Cells(0).Value & " where (F3 is not null and F6 is not null and F7 is not null)", CnStr)
                Adp.Fill(dtChartData)
            End Using
        End If

        ' remove header row
        dtChartData.Rows.RemoveAt(0)

    End Sub



End Class