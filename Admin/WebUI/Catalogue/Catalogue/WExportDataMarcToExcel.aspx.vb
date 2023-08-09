
Imports System.IO
Imports Aspose.Cells
Imports eMicLibAdmin.BusinessRules.Common
Imports OfficeOpenXml
Imports eMicLibAdmin.WebUI.Common

Partial Class Catalogue_Catalogue_WExportDataMarcToExcel
    Inherits System.Web.UI.Page

    Private objBInput As New clsBInput
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Initialize()
        If (Not Page.IsPostBack) Then

        End If
    End Sub

    Private Sub Initialize()
        ' Init objBInput object
        objBInput.InterfaceLanguage = Session("InterfaceLanguage")
        objBInput.DBServer = Session("DBServer")
        objBInput.ConnectionString = Session("ConnectionString")
        Call objBInput.Initialize()
    End Sub

    Public Sub BindPrg(ByVal intCurrent As Integer, ByVal intSum As Integer)
        Dim intCurrentPercent As Integer
        intCurrentPercent = ((intCurrent + 1) * 100) / intSum
        'System.Threading.Thread.Sleep(850)
        Response.Write("<script>if (pgbObj = document.getElementById('pgbMain')) pgbObj.width =" & intCurrentPercent & " + '%'; if (lblObj = document.getElementById('pgbMain_label')) lblObj.innerHTML =" & intCurrentPercent & " + '%';</script>")
        Response.Flush()
    End Sub

    Protected Sub ExportExcel_Click(sender As Object, e As EventArgs) Handles ExportExcel.Click

        'Response.Write("<div class='lbLabel' style=' margin:0;top:250;left:0; width:100%;'>")
        'Response.Write("<p style='position:absolute; left:45%;'>Export dữ liệu: <span id='pgbMain_label'>0%</span></p>")
        'Response.Write("<p style='padding-top:35px;'><table width='0%' border=2 bordercolor='white' id='pgbMain' bgcolor=blue><tr style='HEIGHT: 18px'><td></td></tr></table></p>")
        'Response.Write("</div>")

        Dim intIDFrom As Integer = CInt(txtIDFrom.Text)
        Dim intIDTo As Integer = CInt(txtIDTo.Text)

        Dim tbExport As DataTable = GetDataTableFromDataBase(intIDFrom, intIDTo)

        Call ExportToExcel(tbExport, String.Format("export_AllData_{0}_{1}.xlsx", intIDFrom, intIDTo))
    End Sub

    Private Function CountRowInsertOfItemID(ByVal intItemID As Integer, ByVal tblData As DataTable, ByVal tblDataColumn As DataTable) As Integer
        Dim intResult As Integer = 0
        Dim intCount As Integer = 0
        Dim tbViewTmp As DataView = tblData.DefaultView
        For Each row As DataRow In tblDataColumn.Rows
            tbViewTmp.RowFilter = "ItemID=" & intItemID & " AND FieldCode='" & row.Item("FieldCode").ToString() & "'"
            intCount = tbViewTmp.ToTable.Rows.Count
            If intCount > intResult Then
                intResult = intCount
            End If
        Next
        Return intResult
    End Function

    Private Function ReferrenceItemTypeCodeToItemTypeName(ByVal strValue As String) As String
        Dim strResult As String = "STK"
        'SH - BC - TT - ĐT - CD - TLDT
        Select Case strValue
            Case "SH"
                strResult = "Sách giáo khoa, sách chuyên ngành,..."
            Case "BC"
                strResult = "Báo cáo"
            Case "TT"
                strResult = "Báo tạp chí"
            Case "ĐT"
                strResult = "Đề tài nghiên cứu"
            Case "CD"
                strResult = "Đĩa CD-ROM và DVD"
            Case "TLDT"
                strResult = "Tài liệu điện tử"
            Case Else
                strResult = "Sách giáo khoa, sách chuyên ngành,..."
        End Select
        Return strResult
    End Function

    Private Function GenDataRowOfItemID(ByVal intItemID As Integer, ByRef intSTT As Integer, ByVal tblData As DataTable, ByVal tblDataColumn As DataTable) As DataTable
        Dim tblResult As New DataTable()
        tblResult.Columns.Add("STT", GetType(String))
        For i As Integer = 0 To tblDataColumn.Rows.Count - 1
            Dim rows As DataRow = tblDataColumn.Rows(i)
            tblResult.Columns.Add(rows.Item("FieldCode").ToString(), GetType(String))
        Next
        tblResult.Columns.Add("StatusNote", GetType(String))
        tblResult.Columns.Add("NumberCopies", GetType(String))
        tblResult.Columns.Add("LoanType", GetType(String))
        tblResult.Columns.Add("Price", GetType(String))
        tblResult.Columns.Add("BarCode", GetType(String))
        tblResult.Columns.Add("LocationName", GetType(String))
        tblResult.Columns.Add("Note", GetType(String))

        Dim intCountInsertRow As Integer = CountRowInsertOfItemID(intItemID, tblData, tblDataColumn)
        If intCountInsertRow > 0 Then
            For i As Integer = 0 To intCountInsertRow - 1
                Dim dtRowAdd As DataRow = tblResult.NewRow()
                For Each col As DataColumn In tblResult.Columns
                    dtRowAdd(col.ColumnName) = ""
                Next
                tblResult.Rows.Add()
            Next
        End If

        Dim arrValue As New Dictionary(Of String, String)

        For Each col As DataColumn In tblResult.Columns
            If col.ColumnName = "STT" Then
                For i As Integer = 0 To intCountInsertRow - 1
                    tblResult.Rows(i).Item(col.ColumnName) = intSTT
                    intSTT = intSTT + 1
                Next
            Else
                'For i As Integer = 0 To intCountInsertRow - 1
                '    tblResult.Rows(i).Item(col.ColumnName) = ""
                'Next
                Dim tbView As DataView = tblData.DefaultView
                tbView.RowFilter = "ItemID=" & intItemID & " AND FieldCode='" & col.ColumnName & "'"
                Dim iEnd As Integer = tbView.ToTable.Rows.Count - 1
                If intCountInsertRow < tbView.ToTable.Rows.Count Then
                    iEnd = intCountInsertRow - 1
                End If

                Dim strValue As String = ""
                If col.ColumnName = "852" Then
                    '{0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} - 0:copynumber; 1:statusnote; 2:numbercopies; 3:loantype; 4:price; 5:barcode; 6:locationname; 7:Note
                    For i As Integer = 0 To iEnd
                        tblResult.Rows(i).Item("StatusNote") = ""
                        tblResult.Rows(i).Item("NumberCopies") = ""
                        tblResult.Rows(i).Item("LoanType") = ""
                        tblResult.Rows(i).Item("Price") = ""
                        tblResult.Rows(i).Item("BarCode") = ""
                        tblResult.Rows(i).Item("LocationName") = ""
                        tblResult.Rows(i).Item("Note") = ""
                        Dim rowview As DataRow = tbView.ToTable.Rows(i)
                        If rowview.Item("Content") & "" <> "" Then
                            strValue = rowview.Item("Content")
                            Dim split As String() = strValue.Split("|")
                            If split.Length > 0 Then
                                If (Not String.IsNullOrEmpty(Trim(split(0) & ""))) Then
                                    tblResult.Rows(i).Item(col.ColumnName) = Trim(split(0) & "")
                                End If
                                If (Not String.IsNullOrEmpty(Trim(split(1) & ""))) Then
                                    tblResult.Rows(i).Item("StatusNote") = Trim(split(1) & "")
                                End If
                                If (Not String.IsNullOrEmpty(Trim(split(2) & ""))) Then
                                    tblResult.Rows(i).Item("NumberCopies") = Trim(split(2) & "")
                                End If
                                If (Not String.IsNullOrEmpty(Trim(split(3) & ""))) Then
                                    tblResult.Rows(i).Item("LoanType") = Trim(split(3) & "")
                                End If
                                If (Not String.IsNullOrEmpty(Trim(split(4) & ""))) Then
                                    tblResult.Rows(i).Item("Price") = Trim(split(4) & "")
                                End If
                                If (Not String.IsNullOrEmpty(Trim(split(5) & ""))) Then
                                    tblResult.Rows(i).Item("BarCode") = Trim(split(5) & "")
                                End If
                                If (Not String.IsNullOrEmpty(Trim(split(6) & ""))) Then
                                    tblResult.Rows(i).Item("LocationName") = Trim(split(6) & "")
                                End If
                                If (Not String.IsNullOrEmpty(Trim(split(7) & ""))) Then
                                    tblResult.Rows(i).Item("Note") = Trim(split(7) & "")
                                End If
                            End If

                        End If
                    Next
                Else
                    For i As Integer = 0 To iEnd
                        If tbView.ToTable.Rows.Count > 0 Then
                            Dim rowview As DataRow = tbView.ToTable.Rows(i)
                            If rowview.Item("Content") & "" <> "" Then
                                If col.ColumnName = "927" Then
                                    strValue = ReferrenceItemTypeCodeToItemTypeName(rowview.Item("Content") & "")
                                Else
                                    strValue = rowview.Item("Content")
                                End If
                            Else
                                tblResult.Rows(i).Item(col.ColumnName) = strValue
                            End If
                        End If
                        tblResult.Rows(i).Item(col.ColumnName) = strValue
                    Next
                End If

            End If

        Next

        Return tblResult
    End Function

    Private Function GetDataTableFromDataBase(ByVal intIDFrom As Integer, ByVal intIDTo As Integer) As DataTable
        Dim dtResult As New DataTable()

        Dim strQueryCheckTitle As String = "Lib_spField_GetAllFieldCodeUsed"
        objBInput.SQL = strQueryCheckTitle
        Dim tblDataColumn As DataTable = objBInput.GetData()

        dtResult.Columns.Add("STT", GetType(String))
        For i As Integer = 0 To tblDataColumn.Rows.Count - 1
            Dim rows As DataRow = tblDataColumn.Rows(i)
            dtResult.Columns.Add(rows.Item("FieldCode").ToString(), GetType(String))
        Next
        dtResult.Columns.Add("852", GetType(String))
        dtResult.Columns.Add("911", GetType(String))
        dtResult.Columns.Add("927", GetType(String))
        dtResult.Columns.Add("StatusNote", GetType(String))
        dtResult.Columns.Add("NumberCopies", GetType(String))
        dtResult.Columns.Add("LoanType", GetType(String))
        dtResult.Columns.Add("Price", GetType(String))
        dtResult.Columns.Add("BarCode", GetType(String))
        dtResult.Columns.Add("LocationName", GetType(String))
        dtResult.Columns.Add("Note", GetType(String))

        tblDataColumn.Rows.Add("852")
        tblDataColumn.Rows.Add("911")
        tblDataColumn.Rows.Add("927")

        strQueryCheckTitle = "Lib_spItem_GetAllDataUsed " & intIDFrom & "," & intIDTo
        objBInput.SQL = strQueryCheckTitle
        Dim tblDataAll As DataTable = objBInput.GetData()

        Dim intSTT As Integer = 1

        'For i As Integer = intIDFrom To intIDTo
        '    Dim tbView As DataView = tblDataAll.DefaultView

        '    Dim dtRowAdd As DataRow = dtResult.NewRow()
        '    For Each col As DataColumn In dtResult.Columns
        '        If (col.ColumnName = "STT") Then
        '            dtRowAdd.Item(col.ColumnName) = intSTT + 1
        '        Else
        '            dtRowAdd.Item(col.ColumnName) = ""
        '            tbView.RowFilter = "ItemID=" & i & " AND FieldCode='" & col.ColumnName & "'"
        '            If tbView.Count > 0 Then
        '                dtRowAdd.Item(col.ColumnName) = tbView(0).Item("Content")
        '            End If
        '        End If
        '    Next
        '    dtResult.Rows.Add(dtRowAdd)
        '    'Call BindPrg(intSTT, (intIDTo - intIDFrom) + 1)
        '    intSTT = intSTT + 1
        'Next

        For i As Integer = intIDFrom To intIDTo
            Dim tblTmp As DataTable = GenDataRowOfItemID(i, intSTT, tblDataAll, tblDataColumn)
            For Each row As DataRow In tblTmp.Rows
                dtResult.Rows.Add(row.ItemArray)
            Next
        Next

        Return dtResult
    End Function

    Private Sub ExportToExcel(ByVal dtExport As DataTable, ByVal strFileName As String)
        Try
            Dim strRoot As String = Server.MapPath("~")
            Dim l As New Aspose.Cells.License()
            Dim strLicense As String = strRoot & Convert.ToString("\Bin\Aspose.Cells.lic")
            l.SetLicense(strLicense)

            Dim workbook As New Workbook()

            Dim worksheet As Worksheet = workbook.Worksheets(0)

            worksheet.Cells.ImportDataTable(dtExport, True, "A1")

            Dim ms1 As New MemoryStream()
            workbook.Save(ms1, FileFormatType.Xlsx)
            Dim bin As Byte() = ms1.ToArray()

            Dim attachment As String = "attachment; filename=" & strFileName
            Response.Clear()
            Response.Buffer = True
            Response.AddHeader("content-disposition", attachment)
            Response.ContentType = "application/octet-stream"
            Response.ContentEncoding = Encoding.Unicode
            Response.BinaryWrite(bin)
            Response.Flush()
            Response.End()
            ms1.Close()
        Catch ex As Exception
            Response.Flush()
            Response.Clear()
            Response.ClearContent()
            Response.End()
            Response.Headers.Clear()
        End Try

    End Sub

    Private Function ReadFileExcelToDataTable(ByVal fileUploadInput As FileUpload) As DataTable
        Dim tbl = New DataTable()
        If (fileUploadInput.HasFile AndAlso (IO.Path.GetExtension(fileUploadInput.FileName) = ".xlsx" Or IO.Path.GetExtension(fileUploadInput.FileName) = ".xls")) Then
            Using excel = New ExcelPackage(fileUploadInput.PostedFile.InputStream)
                Dim ws = excel.Workbook.Worksheets.First()
                Dim hasHeader = True ' change it if required '

                'Dim arrColumn As New List(Of String)
                For Each firstRowCell In ws.Cells(1, 1, 1, ws.Dimension.End.Column)
                    'arrColumn.Add(firstRowCell.Text)
                    tbl.Columns.Add("Field" & firstRowCell.Text)
                Next

                'For i As Integer = 0 To arrColumn.Count - 1
                '    tbl.Columns.Add(arrColumn(i))
                'Next

                ' add rows to DataTable '
                For rowNum = 2 To ws.Dimension.End.Row
                    Dim wsRow = ws.Cells(rowNum, 1, rowNum, ws.Dimension.End.Column)
                    Dim row = tbl.NewRow()

                    Dim isAdd As Boolean = True
                    Dim intIndex As Integer = 0

                    For Each cell In wsRow
                        If (intIndex = 0) AndAlso (cell.Text = "") Then
                            isAdd = False
                            Exit For
                        Else
                            row(cell.Start.Column - 1) = cell.Text
                        End If
                        intIndex = intIndex + 1
                    Next
                    If isAdd Then
                        tbl.Rows.Add(row)
                    End If
                Next
            End Using
        End If
        Return tbl
    End Function

    Private Function ConvertDataToFullMarc(ByVal table As DataTable) As DataTable
        Dim tblResult As New DataTable()

        Dim arrColumn As New List(Of String)
        For Each column As DataColumn In table.Columns
            arrColumn.Add(column.ColumnName)
        Next

        For Each column As String In arrColumn

            Dim tblView As DataView = table.DefaultView
            tblView.RowFilter = column & " <> ''"
            Dim tblTmp As DataTable = tblView.ToTable()
            If tblTmp.Rows.Count > 0 Then
                For Each row As DataRow In tblTmp.Rows
                    Dim value As String = row.Item(column) & ""
                    'Dim splitValue As String() = value.Trim().Split("|")
                    'For Each itemSplit As String In splitValue
                    '    Dim splitDollar As String() = itemSplit.Trim().Split("$")
                    '    If splitDollar.Length = 1 Then
                    '        tblResult.UpgradeColumns(column.Replace("Field", ""))
                    '    Else
                    '        For Each itemDollar As String In splitDollar
                    '            If Not String.IsNullOrEmpty(itemDollar.Trim()) Then
                    '                Dim columnTmp As String = column.Replace("Field", "") & "$" & itemDollar.Substring(0, 1)
                    '                tblResult.UpgradeColumns(columnTmp)
                    '            End If
                    '        Next
                    '    End If
                    'Next
                    Dim splitDollar As String() = value.Trim().Split("$")
                    If splitDollar.Length = 1 Then
                        tblResult.UpgradeColumns(column.Replace("Field", ""))
                    Else
                        For Each itemDollar As String In splitDollar
                            If Not String.IsNullOrEmpty(itemDollar.Trim()) Then
                                Dim columnTmp As String = column.Replace("Field", "") & "$" & itemDollar.Substring(0, 1)
                                tblResult.UpgradeColumns(columnTmp)
                            End If
                        Next
                    End If
                Next
            Else
                tblResult.UpgradeColumns(column.Replace("Field", ""))
            End If
        Next

        For Each row As DataRow In table.Rows
            Dim rowAdd As DataRow = tblResult.NewRow()
            'Default value
            For i As Integer = 0 To rowAdd.ItemArray.Count - 1
                rowAdd.Item(i) = ""
            Next

            For Each column As DataColumn In tblResult.Columns
                If column.ColumnName.Length = 3 Then
                    rowAdd.Item(column.ColumnName) = rowAdd.Item(column.ColumnName) & row.Item("Field" & column.ColumnName)
                Else
                    Try
                        Dim value As String = row.Item("Field" & column.ColumnName.Substring(0, 3)) & ""
                        'Dim splitValue As String() = value.Trim().Split("|")
                        'For Each itemSplit As String In splitValue
                        '    Dim splitDollar As String() = itemSplit.Trim().Split("$")
                        '    For Each itemDollar As String In splitDollar
                        '        If Not String.IsNullOrEmpty(itemDollar.Trim()) Then
                        '            If itemDollar.Substring(0, 1) = column.ColumnName.Substring(4, 1) Then
                        '                Dim valueTmp As String = itemDollar.Trim().Substring(1)
                        '                rowAdd.Item(column.ColumnName) = rowAdd.Item(column.ColumnName) & valueTmp.Trim()
                        '            End If
                        '        End If
                        '    Next
                        'Next
                        Dim splitDollar As String() = value.Trim().Split("$")
                        For Each itemDollar As String In splitDollar
                            If Not String.IsNullOrEmpty(itemDollar.Trim()) Then
                                If itemDollar.Substring(0, 1) = column.ColumnName.Substring(4, 1) Then
                                    Dim valueTmp As String = itemDollar.Trim().Substring(1)
                                    rowAdd.Item(column.ColumnName) = rowAdd.Item(column.ColumnName) & valueTmp.Trim()
                                End If
                            End If
                        Next
                    Catch ex As Exception
                        Dim value As String = row.Item("Field" & column.ColumnName) & ""
                        Dim splitDollar As String() = value.Trim().Split("$")
                        For Each itemDollar As String In splitDollar
                            If Not String.IsNullOrEmpty(itemDollar.Trim()) Then
                                Dim valueTmp As String = itemDollar.Trim()
                                rowAdd.Item(column.ColumnName) = rowAdd.Item(column.ColumnName) & valueTmp.Trim()
                            End If
                        Next
                    End Try

                End If
            Next
            tblResult.Rows.Add(rowAdd)
        Next

        Return tblResult
    End Function

    Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
        Me.Dispose(True)
    End Sub

    Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
        Try
            If isDisposing Then
                If Not objBInput Is Nothing Then
                    objBInput.Dispose(True)
                    objBInput = Nothing
                End If
            End If
        Finally
            MyBase.Dispose()
            Me.Dispose()
        End Try
    End Sub

    Protected Sub ConvertFileExcel_Click(sender As Object, e As EventArgs) Handles ConvertFileExcel.Click
        Dim tbl As DataTable = ReadFileExcelToDataTable(FileUpload1)
        Dim tblConvert As DataTable = ConvertDataToFullMarc(tbl)

        Try
            Dim strRoot As String = Server.MapPath("~")
            Dim l As New Aspose.Cells.License()
            Dim strLicense As String = strRoot & Convert.ToString("\Bin\Aspose.Cells.lic")
            l.SetLicense(strLicense)

            Dim workbook As New Workbook()

            Dim worksheet As Worksheet = workbook.Worksheets(0)

            worksheet.Cells.ImportDataTable(tblConvert, True, "A1")

            Dim ms1 As New MemoryStream()
            workbook.Save(ms1, FileFormatType.Xlsx)
            Dim bin As Byte() = ms1.ToArray()

            Dim attachment As String = "attachment; filename=" & String.Format("export_FullMarc_{0}", FileUpload1.FileName)
            Response.Clear()
            Response.Buffer = True
            Response.AddHeader("content-disposition", attachment)
            Response.ContentType = "application/octet-stream"
            Response.ContentEncoding = Encoding.Unicode
            Response.BinaryWrite(bin)
            Response.Flush()
            Response.End()
            ms1.Close()
        Catch ex As Exception
            Response.Flush()
            Response.Clear()
            Response.ClearContent()
            Response.End()
            Response.Headers.Clear()
        End Try
    End Sub
    Protected Sub ViewGroupBy_Click(sender As Object, e As EventArgs) Handles ViewGroupBy.Click
        Dim tbl = New DataTable()
        If (FileUpload2.HasFile AndAlso (IO.Path.GetExtension(FileUpload2.FileName) = ".xlsx" Or IO.Path.GetExtension(FileUpload2.FileName) = ".xls")) Then
            Using excel = New ExcelPackage(FileUpload2.PostedFile.InputStream)
                Dim ws = excel.Workbook.Worksheets.First()
                Dim hasHeader = True ' change it if required '

                'Dim arrColumn As New List(Of String)
                For Each firstRowCell In ws.Cells(1, 1, 1, ws.Dimension.End.Column)
                    'arrColumn.Add(firstRowCell.Text)
                    tbl.Columns.Add(firstRowCell.Text)
                Next

                'For i As Integer = 0 To arrColumn.Count - 1
                '    tbl.Columns.Add(arrColumn(i))
                'Next

                ' add rows to DataTable '
                For rowNum = 2 To ws.Dimension.End.Row
                    Dim wsRow = ws.Cells(rowNum, 1, rowNum, ws.Dimension.End.Column)
                    Dim row = tbl.NewRow()

                    Dim isAdd As Boolean = True
                    Dim intIndex As Integer = 0

                    For Each cell In wsRow
                        If (intIndex = 0) AndAlso (cell.Text = "") Then
                            isAdd = False
                            Exit For
                        Else
                            row(cell.Start.Column - 1) = cell.Text
                        End If
                        intIndex = intIndex + 1
                    Next
                    If isAdd Then
                        tbl.Rows.Add(row)
                    End If
                Next
            End Using
        End If

        Dim groupby = tbl.AsEnumerable().GroupBy(Of String)(Function(x) Trim(x.Item("MaLoaiAnPham") & "")).Select(Function(x) x.Key).ToList()
        Dim strGroupBy As String = ""
        For Each strItem As String In groupby
            strGroupBy = strGroupBy & "{" & strItem & "} "
        Next
        LabelList.Text = strGroupBy
    End Sub
End Class
