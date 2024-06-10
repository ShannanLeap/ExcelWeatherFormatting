Imports System.IO
Imports System.Data.OleDb


Public Module ProcessCSVData
    Public dtNOAAResults As New DataTable
    Public dtNOAAResultsInternational As New DataTable
    Public dtResults As New DataTable

    Public Sub NOAADataToDataTable(ByVal filename As String)
        ' new version
        Dim folder = frmConvert.folder1.SelectedPath
        Dim CnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & folder & ";Extended Properties=""text;HDR=No;FMT=Delimited"";"
        Dim strSQL As String = "select * from [" & filename & "]"

        Using Adp As New OleDbDataAdapter(strSQL, CnStr)
            Adp.Fill(dtNOAAResults)
        End Using
    End Sub

    Public Sub NOAADataToDataTableInternational(ByVal filename As String)
        ' new version
        Dim folder = frmConvert.folder1.SelectedPath
        Dim CnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & folder & ";Extended Properties=""text;HDR=No;FMT=Delimited"";"
        Dim strSQL As String = "select * from [" & filename & "]"

        Using Adp As New OleDbDataAdapter(strSQL, CnStr)
            Adp.Fill(dtNOAAResultsInternational)
        End Using

        For x = 1 To 15
            dtNOAAResults.Columns.Add()
        Next x

        Dim z As Integer = 0
        For Each row As DataRow In dtNOAAResultsInternational.Rows
            If z <> 0 Then
                dtNOAAResults.Rows.Add(row.Item(0), row.Item(1), "SOD", row.Item(2), row.Item(12), " ", " ", row.Item(14), row.Item(5), row.Item(6), " ", " ", " ", " ", row.Item(14))
            End If
            z = z + 1
        Next row

    End Sub

    Public Sub DataTableToCSV(ByVal table As DataTable, ByVal filename As String, ByVal sepChar As String)
        ' new version
        Dim path As String = filename
        Dim builder As New System.Text.StringBuilder
        Dim sep As String = ""

        ' This text is added only once to the file.

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
    End Sub
End Module
