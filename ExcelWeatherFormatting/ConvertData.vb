Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel
Imports Microsoft.Office
Imports System.Runtime.InteropServices
Imports System.Data.OleDb


Public Class frmConvert

    Private Sub bntOpen_Click(sender As System.Object, e As System.EventArgs) Handles bntOpen.Click
        ' new version
        If folder1.ShowDialog() = Windows.Forms.DialogResult.OK Then

            Dim di As New IO.DirectoryInfo(folder1.SelectedPath)
            Dim diar1 As IO.FileInfo() = di.GetFiles()
            Dim dra As IO.FileInfo

            list1.Items.Clear()
            'list the names of all files in the specifieddirectory
            For Each dra In diar1
                If InStr(dra.ToString, "csv") > 0 Then
                    list1.Items.Add(dra)
                End If
            Next

            btnFormat.Enabled = True
            btnResults.Enabled = True

            txtLocations.Text = list1.Items.Count
        End If
    End Sub

    Private Sub btnFormat_Click(sender As System.Object, e As System.EventArgs) Handles btnFormat.Click
        ' new version
        If RBFileTypeLocal.Checked = True Then ' LCD local data

            '    load CSV data into a dataTable
            NOAADataToDataTable(list1.SelectedItem.ToString)



            If list1.SelectedIndex < 0 Then
                MsgBox("Select a file to process!")
                Exit Sub
            End If
            If dtNOAAResults.Rows.Count > 4000 Then

                Cursor = Cursors.WaitCursor


                ' remove column D-R
                dtNOAAResults.Columns.RemoveAt(3)
                dtNOAAResults.Columns.RemoveAt(3)
                dtNOAAResults.Columns.RemoveAt(3)
                dtNOAAResults.Columns.RemoveAt(3)
                dtNOAAResults.Columns.RemoveAt(3)
                dtNOAAResults.Columns.RemoveAt(3)
                dtNOAAResults.Columns.RemoveAt(3)
                dtNOAAResults.Columns.RemoveAt(3)
                dtNOAAResults.Columns.RemoveAt(3)
                dtNOAAResults.Columns.RemoveAt(3)
                dtNOAAResults.Columns.RemoveAt(3)
                dtNOAAResults.Columns.RemoveAt(3)
                dtNOAAResults.Columns.RemoveAt(3)
                dtNOAAResults.Columns.RemoveAt(3)
                dtNOAAResults.Columns.RemoveAt(3)


                ' remove columns G-H
                dtNOAAResults.Columns.RemoveAt(6)
                dtNOAAResults.Columns.RemoveAt(6)

                ' remove columns I-K
                dtNOAAResults.Columns.RemoveAt(8)
                dtNOAAResults.Columns.RemoveAt(8)
                dtNOAAResults.Columns.RemoveAt(8)

                ' remove columns K-L
                dtNOAAResults.Columns.RemoveAt(10)
                dtNOAAResults.Columns.RemoveAt(10)



                ' remove columnsP-the end
                Try
                    For z = 15 To dtNOAAResults.Columns.Count - 2
                        dtNOAAResults.Columns.RemoveAt(z)
                    Next
                Catch ex As Exception
                    ' code to catch no columns
                End Try

                ' delete all hourly lines, but keep the daily ones
                Call deleteLinesThatAreNotDaily()

                DataTableToCSV(dtResults, folder1.SelectedPath & "\" & list1.SelectedItem.ToString, ",")
                Cursor = Cursors.Default

                MsgBox("Finished!")
            Else
                MessageBox.Show("This data already looks formatted!")
            End If

        ElseIf RBFileTypeInternational.Checked = True Then 'international data
            MessageBox.Show("International data does not have to be formatted since it is already in summary form." & vbCrLf & "Some data is different/missing from LCD data, but NOAA does not have it.")

        End If



    End Sub
    Public Sub deleteLinesThatAreNotDaily()
        ' new version

        ' filter only daily lines out
        dtNOAAResults.DefaultView.RowFilter = "F3 = 'SOD'"
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


    Private Sub cmdView_Click(sender As System.Object, e As System.EventArgs) Handles btnResults.Click
        ' new version
        dtNOAAResults.Clear()
        dtNOAAResults.Dispose()
        Results.Show()

    End Sub

    Private Sub frmConvert_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub list1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles list1.SelectedIndexChanged

        Dim intLineCount As Integer = 0
        Try ' Open the file to see how may lines it has
            Using reader As New IO.StreamReader(folder1.SelectedPath & "\" & list1.SelectedItem().ToString)
                While Not reader.EndOfStream()
                    reader.ReadLine()

                    intLineCount = intLineCount + 1
                End While

                reader.Close()

            End Using
            txtDaysCount.Text = intLineCount

            If intLineCount < 3200 Or intLineCount > 3300 Then
                txtDaysCount.ForeColor = Color.Red
                lblZipCode.ForeColor = Color.Red
                lblZipCode.Visible = True
            Else
                txtDaysCount.ForeColor = Color.Black
                lblZipCode.Visible = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LinkLabel1_Click(sender As Object, e As System.EventArgs)
        System.Diagnostics.Process.Start("https://www.ncdc.noaa.gov/cdo-web/datatools/lcd")
    End Sub

    Private Sub Label6_Click(sender As System.Object, e As System.EventArgs) Handles Label6.Click

    End Sub
End Class
