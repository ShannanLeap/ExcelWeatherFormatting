Imports System.IO
Imports System.Data.OleDb
Imports System.Text.RegularExpressions


Public Module ProcessCSVData
    Public dtNOAAResults As New DataTable
    Public dtNOAAResultsInternational As New DataTable
    Public dtResults As New DataTable

    Public Sub NOAADataToDataTable(ByVal filename As String)
        ' loads the contents of the CSV into a data table for processing
        Dim matchFound As Match
        matchFound = Regex.Match(filename, "(.*)\\(.*\..*)[\\]?", RegexOptions.IgnoreCase)

        Dim CnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & matchFound.Groups(1).Value & ";Extended Properties=""text;HDR=No;FMT=Delimited"";"
        Dim strSQL As String = "select * from [" & matchFound.Groups(2).Value & "] where [F1] is not null"

        Using Adp As New OleDbDataAdapter(strSQL, CnStr)
            Try
                Adp.Fill(dtNOAAResults)
            Catch ex As Exception
                MessageBox.Show("ERROR!" & vbLf & ex.Message)
                MessageBox.Show("Error in file " & matchFound.Groups(2).Value & " Edit line: " & dtNOAAResults.Rows.Count)

            End Try
            Adp.Dispose()
        End Using
    End Sub

    Public Sub NOAADataToDataTableInternational(ByVal filename As String)
        ' loads the contents of the CSV into a data table called "dtNOAAResultsInternational" for processing
        Dim matchFound As Match
        matchFound = Regex.Match(filename, "(.*)\\(.*\..*)[\\]?", RegexOptions.IgnoreCase)


        Dim CnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & matchFound.Groups(1).Value & ";Extended Properties=""text;HDR=No;FMT=Delimited"";"
        Dim strSQL As String = "select * from [" & matchFound.Groups(2).Value & "] where [F1] is not null"

        Using Adp As New OleDbDataAdapter(strSQL, CnStr)
            Try
                Adp.Fill(dtNOAAResultsInternational)
            Catch ex As Exception
                MessageBox.Show("ERROR!" & vbLf & ex.Message)
                MessageBox.Show("Error in file " & matchFound.Groups(2).Value & " Edit line: " & dtNOAAResultsInternational.Rows.Count)
            End Try
            Adp.Dispose()
        End Using

        ' add columns to dtNOAAREsults manually since we are doing international data and it's in a different format
        dtResults.Clear()
        If dtResults.Columns.Count < 24 Then
            For x = 1 To 25
                dtResults.Columns.Add()
            Next x
        End If

        ' add the header row
        dtResults.Rows.Add("STATION", "DATE", "REPORT_TYPE", "DailyAverageDewPointTemperature", "DailyAverageDryBulbTemperature", "DailyAverageRelativeHumidity", "DailyAverageSeaLevelPressure", "DailyAverageStationPressure", "DailyAverageWetBulbTemperature", "DailyAverageWindSpeed",
                           "DailyHeatingDegreeDays", "DailyDepartureFromNormalAverageTemperature", "DailyHeatingDegreeDays", "DailyMaximumDryBulbTemperature", "DailyMinimumDryBulbTemperature", "DailyPeakWindDirection", "DailyPeakWindSpeed",
                           "DailyPrecipitation", "DailySnowDepth", "DailySnowfall", "DailySustainedWindDirection", "DailySustainedWindSpeed", "DailyWeather", "Sunrise", "Sunset")
        ' add international data to the data table row by row with data editing
        Dim z As Integer = 0
        For Each row As DataRow In dtNOAAResultsInternational.Rows
            If z <> 0 Then ' so it does not pick up the header row
                dtResults.Rows.Add(row.Item(0), row.Item(1), "SOD", IIf(CInt(row.Item(2)) > 999, " ", CInt(row.Item(2))), IIf(CInt(row.Item(12)) > 999, " ", CInt(row.Item(12))), 0, 0, 0, 0, IIf(CInt(row.Item(14)) > 999, " ", CInt(row.Item(14))), 0, 0, 0, IIf(CInt(row.Item(5)) > 999, " ", CInt(row.Item(5))), IIf(CInt(row.Item(6)) > 999, " ", CInt(row.Item(6))), 0, CInt(row.Item(7)), IIf(CInt(row.Item(8)) > 999, " ", CInt(row.Item(8))), 0, 0, 0, IIf(CInt(row.Item(14)) > 999, " ", CInt(row.Item(14))), 0, 0, 0)
            End If
            z = z + 1
        Next row

        dtNOAAResultsInternational.Clear()
    End Sub

    Public Sub DataTableToCSV(ByVal table As DataTable, ByVal filename As String, ByVal sepChar As String)
        ' new version
        Dim path As String = filename
        Dim builder As New System.Text.StringBuilder
        Dim sep As String = ""



        Try
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
        Catch ex As Exception
            MessageBox.Show("ERROR: " & vbLf & ex.Message)
        End Try
    End Sub
End Module
