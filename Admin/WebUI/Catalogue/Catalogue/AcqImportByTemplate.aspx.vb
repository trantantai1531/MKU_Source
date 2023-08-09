Imports System.IO
Imports System.IO.Path
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.WebUI.Common
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports Aspose.Cells
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.BusinessRules.Patron

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class Catalogue_Catalogue_AcqImportByTemplate
        Inherits clsWBase

        ' Private objects
        Private objBInput As New clsBInput
        Private objBCatalogueForm As New clsBCatalogueForm
        Private objBItemCollection As New clsBItemCollection
        Private objBEData As New clsBEData
        Private objBCopyNumber As New clsBCopyNumber
        Private objBPatron As New clsBPatron

        Private Function ImportExcelByTemplate(ByVal strType As String, ByVal strFileName As String, ByVal intRowStart As Integer) As Integer
            Dim intResult As Integer = 0
            Try
                If File.Exists(strFileName) Then
                    Dim strRoot As String = HttpContext.Current.Server.MapPath("~")

                    Dim l As New Aspose.Cells.License()
                    Dim strLicense As String = strRoot & Convert.ToString("\Bin\Aspose.Cells.lic")
                    l.SetLicense(strLicense)

                    Dim wb As Workbook = New Workbook(strFileName)
                    Dim ws As Worksheet = wb.Worksheets(0)
                    Dim dt As New DataTable

                    Dim iColEnd As Integer = GetEndCol(ws)
                    Dim iRowEnd As Integer = GetEndRow(ws, intRowStart)
                    For j As Integer = 0 To iColEnd - 1
                        Dim strDataColumn As String = ws.Cells(intRowStart, j).Value.ToString().Trim()
                        dt.Columns.Add(New DataColumn(strDataColumn, GetType(String)))
                    Next
                    For i As Integer = intRowStart + 1 To iRowEnd - 1
                        Dim dr As DataRow = dt.NewRow()
                        For j As Integer = 0 To iColEnd - 1
                            Dim strValue As String = If(ws.Cells(i, j).Value Is Nothing, "", ws.Cells(i, j).Value.ToString())
                            dr(j) = strValue
                        Next
                        dt.Rows.Add(dr)
                    Next
                    Select Case strType
                        Case "CATALOGUE"
                            Dim strDollarA As String = "$a"
                            Dim strDollarB As String = "$b"
                            Dim strDollarC As String = "$c"
                            Dim strF245 As String = ""
                            Dim strF250 As String = ""
                            Dim strF260 As String = ""
                            Dim strF260Temp As String = ""
                            Dim strF250Temp As String = ""
                            Dim strF100 As String = ""
                            Dim strF500 As String = ""
                            Dim strF700 As String = ""
                            Dim strF082 As String = ""
                            Dim strMXG As String = ""
                            Dim strCol1 As String = ""
                            Dim strArrCol1() As String
                            Dim strArrMXGTemp() As String
                            Dim strArrMXG() As String
                            Dim strCol2 As String = ""
                            Dim strCol3 As String = ""
                            Dim strCol4 As String = ""
                            Dim strCol5 As String = ""
                            Dim arrFName() As String
                            Dim arrFValue() As String
                            Dim intItemId As Integer = 0
                            Dim strCode001 As String = ""
                            Dim k As Integer = 0
                            Dim iCount As Integer = dt.Rows.Count - 1

                            Response.Write("<SPAN class='lbLabel' style='position:absolute;top:250;left: 20px'>")
                            Response.Write("Dang nhap khau tai lieu:" & "<span id='pgbMain_label'>0%</span><br>")
                            Response.Write("<table width='0%' border=2 bordercolor='white' id='pgbMain' bgcolor=blue><tr style='HEIGHT: 18px'><td></td></tr></table>")
                            For i As Integer = 0 To iCount
                                Call BindPrg(i, iCount)   ' Display the progress bar
                                'If i = 2 Then
                                '    Exit For
                                'End If
                                strF245 = ""
                                strF250 = ""
                                strF260 = ""
                                strF100 = ""
                                strF500 = ""
                                strF700 = ""
                                strF082 = ""
                                strMXG = ""
                                strCol1 = ""
                                strF250Temp = ""
                                strF260Temp = ""
                                If Not IsNothing(dt.Rows(i).Item("MÔ TẢ THƯ MỤC")) AndAlso dt.Rows(i).Item("MÔ TẢ THƯ MỤC") <> "" Then
                                    strCol1 = dt.Rows(i).Item("MÔ TẢ THƯ MỤC")
                                End If
                                If strCol1 <> "" Then
                                    strArrCol1 = Split(strCol1, ". -")
                                    If UBound(strArrCol1) = 0 Then
                                        strArrCol1 = Split(strCol1, ".-")
                                    End If
                                    If UBound(strArrCol1) >= 0 AndAlso Not IsNothing(strArrCol1(0)) AndAlso strArrCol1(0) <> "" Then
                                        strF245 = strDollarA & strArrCol1(0).Trim
                                        strF245 = Replace(strF245, "/", "/" & strDollarC)
                                    End If
                                    If UBound(strArrCol1) >= 1 AndAlso Not IsNothing(strArrCol1(1)) AndAlso strArrCol1(1) <> "" Then
                                        If UBound(strArrCol1) >= 2 AndAlso Not IsNothing(strArrCol1(2)) AndAlso strArrCol1(2) <> "" Then
                                            If InStr(strArrCol1(1), "Tái bản lần") > 0 Or InStr(strArrCol1(1), "In lần") > 0 Then
                                                strF250Temp = strArrCol1(1).Trim
                                                strF250Temp = Replace(strF250Temp, ": ", ": " & strDollarB)
                                                If InStr(strF250Temp, strDollarB) = 0 Then
                                                    strF250Temp = Replace(strF250Temp, ":", ":" & strDollarB)
                                                End If
                                                strF250Temp = Replace(strF250Temp, "; ", "; " & strDollarC)
                                                If InStr(strF250Temp, strDollarC) = 0 Then
                                                    strF250Temp = Replace(strF250Temp, ";", ";" & strDollarC)
                                                End If
                                                strF250 = strDollarA & strF250Temp.Trim

                                                If strArrCol1(2).Trim <> "" Then
                                                    strF260Temp = strArrCol1(2).Trim
                                                    strF260Temp = Replace(strF260Temp, ": ", ": " & strDollarB)
                                                    If InStr(strF260Temp, strDollarB) = 0 Then
                                                        strF260Temp = Replace(strF260Temp, ":", ":" & strDollarB)
                                                    End If
                                                    strF260Temp = Replace(strF260Temp, ", ", ", " & strDollarC)
                                                    If InStr(strF260Temp, strDollarC) = 0 Then
                                                        strF260Temp = Replace(strF260Temp, ",", "," & strDollarC)
                                                    End If
                                                    strF260 = strDollarA & strF260Temp.Trim
                                                End If

                                                If UBound(strArrCol1) >= 3 AndAlso Not IsNothing(strArrCol1(3)) AndAlso strArrCol1(3) <> "" Then
                                                    strF250Temp = strArrCol1(3).Trim
                                                    strF250Temp = Replace(strF250Temp, ": ", ": " & strDollarB)
                                                    If InStr(strF250Temp, strDollarB) = 0 Then
                                                        strF250Temp = Replace(strF250Temp, ":", ":" & strDollarB)
                                                    End If
                                                    strF250Temp = Replace(strF250Temp, "; ", "; " & strDollarC)
                                                    If InStr(strF250Temp, strDollarC) = 0 Then
                                                        strF250Temp = Replace(strF250Temp, ";", ";" & strDollarC)
                                                    End If
                                                    strF250 &= "@LAP@" & strDollarA & strF250Temp.Trim
                                                End If
                                            Else
                                                If strArrCol1(1).Trim <> "" Then
                                                    strF260Temp = strArrCol1(1).Trim
                                                    strF260Temp = Replace(strF260Temp, ": ", ": " & strDollarB)
                                                    If InStr(strF260Temp, strDollarB) = 0 Then
                                                        strF260Temp = Replace(strF260Temp, ":", ":" & strDollarB)
                                                    End If
                                                    strF260Temp = Replace(strF260Temp, ", ", ", " & strDollarC)
                                                    If InStr(strF260Temp, strDollarC) = 0 Then
                                                        strF260Temp = Replace(strF260Temp, ",", "," & strDollarC)
                                                    End If
                                                    strF260 = strDollarA & strF260Temp
                                                End If

                                                If strArrCol1(2).Trim <> "" Then
                                                    strF250Temp = strArrCol1(2).Trim
                                                    strF250Temp = Replace(strF250Temp, ": ", ": " & strDollarB)
                                                    If InStr(strF250Temp, strDollarB) = 0 Then
                                                        strF250Temp = Replace(strF250Temp, ":", ":" & strDollarB)
                                                    End If
                                                    strF250Temp = Replace(strF250Temp, "; ", "; " & strDollarC)
                                                    If InStr(strF250Temp, strDollarC) = 0 Then
                                                        strF250Temp = Replace(strF250Temp, ";", ";" & strDollarC)
                                                    End If
                                                    strF250 = strDollarA & strF250Temp.Trim
                                                End If
                                            End If

                                        Else
                                            If strArrCol1(1).Trim <> "" Then
                                                strF260Temp = strArrCol1(1).Trim
                                                strF260Temp = Replace(strF260Temp, ": ", ": " & strDollarB)
                                                If InStr(strF260Temp, strDollarB) = 0 Then
                                                    strF260Temp = Replace(strF260Temp, ":", ":" & strDollarB)
                                                End If
                                                strF260Temp = Replace(strF260Temp, ", ", ", " & strDollarC)
                                                If InStr(strF260Temp, strDollarC) = 0 Then
                                                    strF260Temp = Replace(strF260Temp, ",", "," & strDollarC)
                                                End If
                                                strF260 = strDollarA & strF260Temp.Trim
                                            End If
                                        End If
                                    End If
                                End If
                                If Not IsNothing(dt.Rows(i).Item("TÁC GiẢ")) AndAlso dt.Rows(i).Item("TÁC GiẢ") <> "" Then
                                    strCol2 = dt.Rows(i).Item("TÁC GiẢ")
                                    strF100 = strDollarA & strCol2.Trim
                                End If
                                strArrMXG = Nothing
                                strArrMXGTemp = Nothing
                                If Not IsNothing(dt.Rows(i).Item("SỐ ĐKCB")) AndAlso dt.Rows(i).Item("SỐ ĐKCB") <> "" Then
                                    strCol3 = dt.Rows(i).Item("SỐ ĐKCB")
                                    If InStr(strCol3, "-") Then
                                        strArrMXGTemp = Split(strCol3, "-")
                                    Else
                                        strArrMXGTemp = Split(strCol3, ",")
                                    End If
                                    Dim n As Integer = 0
                                    For j As Integer = 0 To UBound(strArrMXGTemp)
                                        If strArrMXGTemp(j).Trim <> "" Then
                                            ReDim Preserve strArrMXG(n)
                                            strArrMXG(n) = fillItem(strArrMXGTemp(j).Trim)
                                            n += 1
                                        End If
                                    Next
                                End If
                                If Not IsNothing(dt.Rows(i).Item("KHPH")) AndAlso dt.Rows(i).Item("KHPH") <> "" Then
                                    strCol4 = dt.Rows(i).Item("KHPH")
                                    strF082 = strDollarA & strCol4.Trim
                                End If
                                If Not IsNothing(dt.Rows(i).Item("GHI CHÚ")) AndAlso dt.Rows(i).Item("GHI CHÚ") <> "" Then
                                    strCol5 = dt.Rows(i).Item("GHI CHÚ")
                                    strF500 = strDollarA & strCol5.Trim
                                End If

                                k = 0
                                arrFName = Nothing
                                arrFValue = Nothing
                                If strF245 <> "" Then
                                    ReDim Preserve arrFName(k)
                                    ReDim Preserve arrFValue(k)
                                    arrFName(k) = "245"
                                    arrFValue(k) = strF245
                                    k += 1
                                End If
                                If strF082 <> "" Then
                                    ReDim Preserve arrFName(k)
                                    ReDim Preserve arrFValue(k)
                                    arrFName(k) = "082"
                                    arrFValue(k) = strF082
                                    k += 1
                                End If
                                If strF100 <> "" Then
                                    ReDim Preserve arrFName(k)
                                    ReDim Preserve arrFValue(k)
                                    arrFName(k) = "100"
                                    arrFValue(k) = strF100
                                    k += 1
                                End If
                                If strF250 <> "" Then
                                    Dim strArr250() As String
                                    strArr250 = Split(strF250, "@LAP@")
                                    For v As Integer = 0 To UBound(strArr250)
                                        ReDim Preserve arrFName(k)
                                        ReDim Preserve arrFValue(k)
                                        arrFName(k) = "250"
                                        arrFValue(k) = strArr250(v)
                                        k += 1
                                    Next
                                End If
                                If strF260 <> "" Then
                                    ReDim Preserve arrFName(k)
                                    ReDim Preserve arrFValue(k)
                                    arrFName(k) = "260"
                                    arrFValue(k) = strF260
                                    k += 1
                                End If
                                If strF500 <> "" Then
                                    ReDim Preserve arrFName(k)
                                    ReDim Preserve arrFValue(k)
                                    arrFName(k) = "500"
                                    arrFValue(k) = strF500
                                End If
                                strCode001 = GenItemCode()
                                intItemId = Update(arrFName, arrFValue, strCode001)
                                If intItemId > 0 Then
                                    If Not IsNothing(strArrMXG) Then
                                        For m As Integer = 0 To UBound(strArrMXG)
                                            If Not IsNothing(strArrMXG) AndAlso strArrMXG(m) <> "" Then
                                                strMXG = strArrMXG(m).Trim
                                                Call updateMXG(strCode001, strMXG, 1, 1, 1, 1, "", 1)
                                            End If
                                        Next
                                    End If
                                End If
                                '
                            Next
                        Case "PATRON"
                            Dim strLop As String = ""
                            Dim strMSV As String = ""
                            Dim strHo As String = ""
                            Dim strTen As String = ""
                            Dim strGioiTinh As String = ""
                            Dim strNgaySinh As String = ""
                            Dim strDiachi As String = ""
                            Dim strGhichu As String = ""
                            Dim strNgayhieuluc As String = ""
                            Dim strNgayhethan As String = ""
                            Dim strNgaycap As String = ""
                            Dim iCount As Integer = dt.Rows.Count - 1

                            Response.Write("<SPAN class='lbLabel' style='position:absolute;top:250;left: 20px'>")
                            Response.Write("Dang nhap khau ban doc:" & "<span id='pgbMain_label'>0%</span><br>")
                            Response.Write("<table width='0%' border=2 bordercolor='white' id='pgbMain' bgcolor=blue><tr style='HEIGHT: 18px'><td></td></tr></table>")
                            For i As Integer = 0 To iCount
                                Call BindPrg(i, iCount)   ' Display the progress bar
                                'If i = 2 Then
                                '    Exit For
                                'End If
                                strLop = ""
                                strMSV = ""
                                strHo = ""
                                strTen = ""
                                strGioiTinh = ""
                                strNgaySinh = ""
                                strDiachi = ""
                                strGhichu = ""
                                strNgaycap = "1/1/2015"
                                strNgayhieuluc = "1/1/2015"
                                strNgayhethan = "1/1/2019"

                                If Not IsNothing(dt.Rows(i).Item("Lớp")) AndAlso dt.Rows(i).Item("Lớp") <> "" Then
                                    strLop = dt.Rows(i).Item("Lớp")
                                    strLop = strLop.Trim
                                End If
                                If Not IsNothing(dt.Rows(i).Item("MSSV")) AndAlso dt.Rows(i).Item("MSSV") <> "" Then
                                    strMSV = dt.Rows(i).Item("MSSV")
                                    strMSV = Replace(strMSV, ".", "").Trim
                                End If
                                If Not IsNothing(dt.Rows(i).Item("Họ và")) AndAlso dt.Rows(i).Item("Họ và") <> "" Then
                                    strHo = dt.Rows(i).Item("Họ và")
                                    strHo = strHo.Trim
                                End If
                                If Not IsNothing(dt.Rows(i).Item("Tên")) AndAlso dt.Rows(i).Item("Tên") <> "" Then
                                    strTen = dt.Rows(i).Item("Tên")
                                    strTen = strTen.Trim
                                End If
                                If Not IsNothing(dt.Rows(i).Item("GT")) AndAlso dt.Rows(i).Item("GT") <> "" Then
                                    strGioiTinh = dt.Rows(i).Item("GT")
                                    strGioiTinh = strGioiTinh.Trim
                                End If
                                If Not IsNothing(dt.Rows(i).Item("NG.Sinh")) AndAlso dt.Rows(i).Item("NG.Sinh") <> "" Then
                                    strNgaySinh = dt.Rows(i).Item("NG.Sinh")
                                    strNgaySinh = strNgaySinh.Trim
                                End If
                                If Not IsNothing(dt.Rows(i).Item("H.Khẩu")) AndAlso dt.Rows(i).Item("H.Khẩu") <> "" Then
                                    strDiachi = dt.Rows(i).Item("H.Khẩu")
                                    strDiachi = strDiachi.Trim
                                End If
                                If Not IsNothing(dt.Rows(i).Item("Ghi chú")) AndAlso dt.Rows(i).Item("Ghi chú") <> "" Then
                                    strGhichu = dt.Rows(i).Item("Ghi chú")
                                    strGhichu = strGhichu.Trim
                                End If
                                Call updatePatron(strMSV, strHo, strTen, strGioiTinh, strNgaySinh, strNgaycap, strNgayhieuluc, strNgayhethan, strLop, strDiachi, strGhichu)
                            Next
                    End Select
                Else
                End If
            Catch ex As Exception
                Stop
            End Try
            Return intResult
        End Function

        'BindPrg method 
        ' Purpose: Bind data for Controls
        Public Sub BindPrg(ByVal intCurrent As Integer, ByVal intSum As Integer)
            Dim intCurrentPercent As Integer
            intCurrentPercent = ((intCurrent + 1) * 100) / intSum
            If intCurrentPercent Mod 10 = 0 Then
                System.Threading.Thread.Sleep(500 / intSum)
                Response.Write("<script>if (pgbObj = document.getElementById('pgbMain')) pgbObj.width =" & intCurrentPercent & " + '%'; if (lblObj = document.getElementById('pgbMain_label')) lblObj.innerHTML =" & intCurrentPercent & " + '%';</script>")
                Response.Flush()
            End If
        End Sub

        Private Function fillItem(ByVal strCon As String, Optional ByVal intNuLimit As Integer = 5) As String
            strCon = Replace(Replace(strCon, ".", ""), ",", "").Trim
            Dim strResult As String = strCon
            Try
                For k As Integer = Len(strCon) + 1 To intNuLimit
                    strResult = "0" & strResult
                Next
            Catch ex As Exception
            End Try
            Return strResult
        End Function

        Private Function GetEndCol(ByVal ws As Worksheet) As Integer
            Dim iResult As Integer = 0
            Try
                While True
                    Dim sValue As String = If(ws.Cells(1, iResult).Value Is Nothing, "", ws.Cells(1, iResult).Value.ToString())
                    If sValue <> "" Then
                        iResult += 1
                    Else
                        Exit While
                    End If
                End While
            Catch ex As Exception
            End Try
            Return iResult
        End Function

        Private Function GetEndRow(ByVal ws As Worksheet, ByVal StartRow As Integer) As Integer
            Dim iResult As Integer = StartRow
            Try
                While True
                    Dim sValue As String = If(ws.Cells(iResult, 0).Value Is Nothing, "", ws.Cells(iResult, 0).Value.ToString())
                    If sValue <> "" Then
                        iResult += 1
                    Else
                        Exit While
                    End If
                End While
            Catch ex As Exception
            End Try
            Return iResult
        End Function

        'Public Shared Sub export2Excel(ByVal filePath As String, ByVal saveFile As String, ByVal ds As DataSet, Optional ByVal officeStype As Util.excelType = Util.excelType.office2003, Optional ByVal dtVariable As DataTable = Nothing)
        '    Try
        '        Dim strRoot As String = HttpContext.Current.Server.MapPath("~")

        '        Dim l As New Aspose.Cells.License()
        '        Dim strLicense As String = strRoot & Convert.ToString("\Lib\Aspose.Cells.lic")
        '        l.SetLicense(strLicense)

        '        Dim path As String = strRoot & filePath

        '        Dim designer As New WorkbookDesigner()
        '        designer.Open(path)

        '        designer.SetDataSource(ds)

        '        If dtVariable IsNot Nothing Then
        '            Dim intCols As Integer = dtVariable.Columns.Count
        '            For i As Integer = 0 To intCols - 1
        '                designer.SetDataSource(dtVariable.Columns(i).ColumnName.ToString(), dtVariable.Rows(0).ItemArray(i).ToString())
        '            Next
        '        End If

        '        designer.Process()

        '        'Save the excel file
        '        'designer.Workbook.Save(saveFile, Aspose.Cells.FileFormatType.Excel2003, Aspose.Cells.SaveType.OpenInExcel, HttpContext.Current.Response);

        '        Dim Stream As New MemoryStream()
        '        Dim Format As FileFormatType = New Aspose.Cells.FileFormatType()

        '        If officeStype = Util.excelType.office2007 Then
        '            Format = Aspose.Cells.FileFormatType.Excel2007Xlsx
        '            saveFile += ".xlsx"
        '        Else

        '            Format = Aspose.Cells.FileFormatType.Excel2003
        '            saveFile += ".xls"
        '        End If

        '        designer.Workbook.Save(Stream, Format)
        '        HttpContext.Current.Response.ContentType = "application/vnd.ms-excel"
        '        HttpContext.Current.Response.AddHeader("content-disposition", Convert.ToString("attachment; filename=") & saveFile)
        '        HttpContext.Current.Response.BinaryWrite(Stream.ToArray())
        '        'HttpContext.Current.Response.End();
        '        HttpContext.Current.ApplicationInstance.CompleteRequest()

        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not IsPostBack Then
                'Me.ShowWaitingOnPage(ddlLabel.Items(12).Text, "../..", False, True)
                Call Initialize()
                'Call Update()
                Call ImportExcelByTemplate("CATALOGUE", "C:\eMicLib\Working\DGSoft\Project\eMicLib\DHLDXH\ImportDATA\Book\Book1.xls", 1)
                Call ImportExcelByTemplate("PATRON", "C:\eMicLib\Working\DGSoft\Project\eMicLib\DHLDXH\ImportDATA\Book\SVTT.xlsx", 0)
                'ShowWaitingOnPage("", "", True)
            End If
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init objBInput object
            objBInput.InterfaceLanguage = Session("InterfaceLanguage")
            objBInput.DBServer = Session("DBServer")
            objBInput.ConnectionString = Session("ConnectionString")
            Call objBInput.Initialize()

            ' Init objBCatalogueForm
            objBCatalogueForm.InterfaceLanguage = Session("InterfaceLanguage")
            objBCatalogueForm.DBServer = Session("DBServer")
            objBCatalogueForm.ConnectionString = Session("ConnectionString")
            Call objBCatalogueForm.Initialize()

            ' Init objBItemCollection
            objBItemCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemCollection.DBServer = Session("DBServer")
            objBItemCollection.ConnectionString = Session("ConnectionString")
            Call objBItemCollection.Initialize()


            ' Init objBEData object
            objBEData.DBServer = Session("DBServer")
            objBEData.ConnectionString = Session("ConnectionString")
            objBEData.InterfaceLanguage = Session("InterfaceLanguage")
            objBEData.Initialize()

            ' Init objBCopyNumber object
            objBCopyNumber.InterfaceLanguage = Session("InterfaceLanguage")
            objBCopyNumber.DBServer = Session("DBServer")
            objBCopyNumber.ConnectionString = Session("ConnectionString")
            Call objBCopyNumber.Initialize()

            ' Init objBPatron object
            objBPatron.DBServer = Session("DBServer")
            objBPatron.ConnectionString = Session("ConnectionString")
            objBPatron.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPatron.Initialize()
        End Sub

        ' Update method
        ' Purpose: update content of this item
        Private Function Update(ByVal arrFName() As String, ByVal arrFValue() As String, ByVal strCode001 As String) As Integer
            Dim intItemId As Integer = 0
            Try
                Dim arrFieldName() As Object
                Dim arrFieldValue() As Object
                Dim arrLabelStr() As Object
                Dim blnModifyHoldings As Boolean = False
                Dim strJS As String = ""

                Dim intCounter As Integer = 1
                Dim strControlName As String = ""
                Dim intValue900 As Integer = 0
                Dim intField911Value As Integer = 0
                Dim intField912Value As Integer = 0
                Dim intFormID = 1 'CInt(Request.Form("txtFormID"))

                ' Set array of LabelString
                ReDim arrLabelStr(9)
                arrLabelStr(0) = ddlLabel.Items(0).Text
                arrLabelStr(1) = ddlLabel.Items(1).Text
                arrLabelStr(2) = ddlLabel.Items(2).Text
                arrLabelStr(3) = ddlLabel.Items(3).Text
                arrLabelStr(4) = ddlLabel.Items(4).Text
                arrLabelStr(5) = ddlLabel.Items(5).Text
                arrLabelStr(6) = ddlLabel.Items(6).Text
                arrLabelStr(7) = ddlLabel.Items(7).Text
                arrLabelStr(8) = ddlLabel.Items(8).Text

                Dim strLabel5 As String = ddlLabel.Items(10).Text
                Dim strLabel15 As String = ddlLabel.Items(11).Text

                ReDim Preserve arrFieldName(0)
                ReDim Preserve arrFieldValue(0)
                arrFieldName(0) = "000"
                arrFieldValue(0) = "00025nam a22      p 4500" 'Request("txtLeader")

                ReDim Preserve arrFieldName(UBound(arrFieldName) + 1)
                ReDim Preserve arrFieldValue(UBound(arrFieldValue) + 1)
                arrFieldName(UBound(arrFieldName)) = "001"
                arrFieldValue(UBound(arrFieldValue)) = strCode001
                intCounter = UBound(arrFieldName) + 1

                For i As Integer = 0 To UBound(arrFName)
                    If Not IsNothing(arrFName(i)) AndAlso arrFName(i) <> "" AndAlso Not IsNothing(arrFValue(i)) AndAlso arrFValue(i) <> "" Then
                        ReDim Preserve arrFieldName(intCounter)
                        ReDim Preserve arrFieldValue(intCounter)
                        arrFieldName(intCounter) = arrFName(i)
                        arrFieldValue(intCounter) = arrFValue(i)
                        intCounter = intCounter + 1
                    End If
                Next

                ReDim Preserve arrFieldName(UBound(arrFieldName) + 1)
                ReDim Preserve arrFieldValue(UBound(arrFieldValue) + 1)
                arrFieldName(UBound(arrFieldName)) = "900"
                arrFieldValue(UBound(arrFieldValue)) = 1 'Hoi co


                'For Each strControlName In Request.Form
                '    If Left(strControlName, 3) = "tag" And Not Trim(Request.Form(strControlName)) = "" Then
                '        ReDim Preserve arrFieldName(intCounter)
                '        ReDim Preserve arrFieldValue(intCounter)
                '        arrFieldName(intCounter) = CStr(Right(strControlName, Len(strControlName) - 3))
                '        arrFieldValue(intCounter) = CStr(Request.Form(strControlName))
                '        intCounter = intCounter + 1
                '        If Right(strControlName, Len(strControlName) - 3) = "911" Then
                '            intField911Value = 1
                '        End If
                '        If Right(strControlName, Len(strControlName) - 3) = "912" Then
                '            intField912Value = 1
                '        End If
                '        If Right(strControlName, Len(strControlName) - 3) = "900" Then
                '            If Request("tag900") <> "" Then
                '                intValue900 = CInt(Request("tag900"))
                '            End If
                '        End If
                '    End If
                'Next

                ' Add cataloguer
                If intField911Value = 0 Then
                    ReDim Preserve arrFieldName(UBound(arrFieldName) + 1)
                    ReDim Preserve arrFieldValue(UBound(arrFieldValue) + 1)
                    arrFieldName(UBound(arrFieldName)) = "911"
                    arrFieldValue(UBound(arrFieldValue)) = clsSession.GlbUserFullName
                End If
                objBInput.FieldName = arrFieldName
                objBInput.FieldValue = arrFieldValue

                Call objBInput.Update(1, 0)

                intItemId = objBInput.WorkID
                'If Session("IsAuthority") = 1 Then
                '    If objBInput.UpdateAuthority(Request("txtFormID"), 1) = 0 Then
                '    End If
                'Else
                '    If objBInput.Update(Request("txtFormID"), 0) = 0 Then
                '    End If
                'End If

                '' Update OPAC value depending on OPAC_LEVEL parameter
                'objBItemCollection.ItemID = objBInput.WorkID
                'objBItemCollection.Field912Value = intField912Value
                'objBItemCollection.UpdateOpacItem(1)
                '' Write log
                'Call WriteLog(10, ddlLabel.Items(10).Text & ": " & objBInput.CodeOut, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                '' Ke^'t thu'c kie^?m tra
                'If Request("Module") = "Serial" Then
                '    objBItemCollection.TypeItem = 9
                'Else
                '    objBItemCollection.TypeItem = 0
                'End If

                ''Cap Nhat tai lieu dien tu
                'Call updateEData(objBInput.WorkID)

                ''strJS = strJS & "parent.Menu.document.forms[0].txtTotalItem.value = """ & objBItemCollection.GetRangeItemID.Rows(0).Item("TOTAL") & """;" & Chr(13)

                '' ModifyHoding from this module
                'blnModifyHoldings = objBCatalogueForm.IsModifyHoldings

                '' Cataloged only
                ''If Not blnModifyHoldings Or intValue900 = 1 Then
                'If Not blnModifyHoldings Then
                '    strJS = strJS & " alert('" & strLabel5 & "');" & Chr(13)
                '    strJS = strJS & "parent.Sentform.location.href = ""WCataSent.aspx?FormID=" & intFormID & "&ItemID=" & objBInput.WorkID & """;" & Chr(13)
                'Else
                '    If Session("IsAuthority") = 1 Then ' IsAuthority not update holding informations
                '        strJS = strJS & " alert('" & strLabel5 & "');" & Chr(13)
                '        strJS = strJS & "parent.Sentform.location.href=""WCataSent.aspx?FormID=" & intFormID & "&ItemID=" & objBInput.WorkID & """;" & Chr(13)
                '    Else
                '        Session("Holdings") = 1
                '        Session("HoldingsInCatalogNew") = 1
                '        strJS = strJS & "if (confirm(""" & strLabel15 & """)) {" & Chr(13)
                '        strJS = strJS & "parent.Sentform.location.href=""WCataModify.aspx?FormID=" & intFormID & "&Module=Catalog&ItemID=" & objBInput.WorkID & "&CodeCatalog=" & objBInput.CodeOut & "&Holdings=1"";" & Chr(13)
                '        strJS = strJS & "} else {" & Chr(13)
                '        strJS = strJS & "parent.Sentform.location.href=""WCataSent.aspx?FormID=" & intFormID & "&ItemID=" & objBInput.WorkID & """;" & Chr(13)
                '        strJS = strJS & "}" & Chr(13)
                '    End If
                'End If
                'Page.RegisterClientScriptBlock("LoadJS", "<script language = 'javascript'>" & strJS & "</script>")
            Catch ex As Exception

            End Try
            Return intItemId
        End Function

        Private Sub updateMXG(ByVal strCode As String, ByVal strMXG As String, ByVal intLidID As Integer, ByVal intLoanTypeID As Integer, ByVal intQuantity As Integer, ByVal intLocID As Integer, ByVal strShelf As String, ByVal intAcqSourceID As Integer, Optional ByVal dbPrice As Double = 0)
            Try
                objBCopyNumber.Code = strCode
                objBCopyNumber.LibID = intLidID
                objBCopyNumber.LoanTypeID = intLoanTypeID
                objBCopyNumber.StartHolding = strMXG

                objBCopyNumber.Range = intQuantity

                'If txtCodePO.Text.Trim <> "" Then
                '    If IsNumeric(txtCodePO.Text) Then
                '        objBCopyNumber.POID = CInt(txtCodePO.Text.Trim)
                '    End If
                'End If
                objBCopyNumber.LocID = intLocID
                objBCopyNumber.ChangeDate = Now.Date
                objBCopyNumber.Price = 0
                objBCopyNumber.Shelf = strShelf
                objBCopyNumber.AcqSourceID = intAcqSourceID

                ' Add Holding
                Dim bytErrAddHold As Byte
                'bytErrAddHold = objBCopyNumber.Create(1, 1)
                bytErrAddHold = objBCopyNumber.Create(0, 0)
                ' Writelog
                'Call WriteLog(39, ddlLabel.Items(8).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                'If bytErrAddHold <> 0 Then
                '    Dim strJS As String
                '    If bytErrAddHold = 1 Then
                '        strJS = "alert('" & ddlLabel.Items(6).Text & "')"
                '    End If
                '    If bytErrAddHold = 2 Then
                '        strJS = "alert('" & ddlLabel.Items(5).Text & "')"
                '    End If
                '    Page.RegisterClientScriptBlock("MessageJS", "<script language = 'javascript'>" & strJS & "</script>")
                'End If
                'Call BindDataGrid(dtgHoldingInfo.CurrentPageIndex)
            Catch ex As Exception

            End Try
        End Sub

        Private Function updatePatron(ByVal strCode As String, ByVal strFirstName As String, ByVal strLastName As String, ByVal strSex As String, ByVal strDOB As String, ByVal strValidDate As String, ByVal strLastIssuedDate As String, ByVal strExpiredDate As String, ByVal strClassCPU As String, ByVal srtAddressInfor As String, ByVal strNote As String, Optional ByVal intPatronGroup As Integer = 1, Optional ByVal intCollegeIDCPU As Integer = 8, Optional ByVal intFacultyIDCPU As Integer = 1) As Integer
            Dim intResult As Integer = 0
            Try
                With objBPatron
                    If InStr(strFirstName, " ") > 0 Then
                        .FirstName = Left(strFirstName, InStr(strFirstName, " "))
                        .MiddleName = Right(strFirstName, Len(strFirstName) - InStr(strFirstName, " "))
                    Else
                        .FirstName = strFirstName
                    End If
                    .LastName = strLastName
                    If strSex.ToUpper = "NAM" Then
                        .Sex = 1
                    Else
                        .Sex = 0
                    End If
                    .DOB = strDOB
                    .Code = strCode
                    .ValidDate = strValidDate
                    .LastIssuedDate = strLastIssuedDate
                    .ExpiredDate = strExpiredDate
                    .AddressInfor = srtAddressInfor
                    .Note = strNote
                    .PatronGroupID = intPatronGroup 'ban doc

                    'Dua du lieu vao bang Cir_tblPatronUniversity
                    .CollegeIDCPU = intCollegeIDCPU
                    .FacultyIDCPU = intFacultyIDCPU
                    .GradeCPU = ""
                    .ClassCPU = strClassCPU

                    .CountryIDCPOA = ""
                    intResult = .Create()
                End With
            Catch ex As Exception
            End Try
            Return intResult
        End Function


        ' GenItemCode method
        ' Purpose: generate the code of new item
        Private Function GenItemCode() As String
            Dim strItemCode As String = ""
            Dim strErrorMsg As String = ""
            Try
                strItemCode = objBInput.Gen001(CInt(Session("IsAuthority")))
            Catch ex As Exception
                strErrorMsg = ex.Message.ToCharArray
            End Try
            Return strItemCode
        End Function


        Private Sub updateEData(ByVal intItemID As Integer)
            Try
                If Not IsNothing(Session("uploadFiles")) Then
                    Dim _icountArr As Integer = UBound(Session("uploadFiles"), 2)
                    For _icount As Integer = _icountArr To 0 Step -1
                        If System.IO.File.Exists(System.IO.Path.Combine(Session("uploadFiles")(0, _icount), Session("uploadFiles")(1, _icount))) Then
                            Dim _fileInfo As New System.IO.FileInfo(System.IO.Path.Combine(Session("uploadFiles")(0, _icount), Session("uploadFiles")(1, _icount)))
                            With objBEData
                                .ItemID = intItemID
                                .FileName = _fileInfo.Name
                                .MediaType = clsWCommon.GetExtensionFileType(_fileInfo.Extension)
                                .FileSize = _fileInfo.Length
                                .Existed = 1
                                .FileLocation = _fileInfo.FullName
                                .DownloadTimes = 0
                                .UploadedDate = Format(Now.Date, "dd/MM/yyyy")
                                .FileFormat = _fileInfo.Extension
                                Dim intFileId As Integer = .insertItemFile()
                            End With
                        End If
                    Next
                    Session("uploadFiles") = Nothing
                End If
                If Not IsNothing(Session("imageCover")) Then
                    Dim strImage As String = Session("imageCover")
                    Dim fileName As String = Path.GetFileName(strImage)
                    Dim strPath As String = Me.getPhysicalPath & "\ImageCover\" & Now.Year.ToString & "\" & Now.Month.ToString & "\" & Now.Day.ToString  'Format(Now, "yyyyMMdd")
                    If Not Directory.Exists(strPath) Then
                        Directory.CreateDirectory(strPath)
                    End If
                    If strPath.EndsWith("\") = False Then
                        strPath &= "\"
                    End If
                    strPath &= fileName
                    If Not File.Exists(strPath) Then
                        File.Copy(strImage, strPath)
                    End If
                    Dim strCoverPicture As String = changeCoverPath(strPath)
                    With objBEData
                        .ItemID = intItemID
                        .CoverPicture = strCoverPicture
                        Dim intResult As Integer = .updateCoverItem()
                    End With
                End If
            Catch ex As Exception
            End Try
        End Sub

        Private Function changeCoverPath(ByVal strCover As String) As String
            Dim strResult As String = ""
            Try
                strResult = Replace(strCover, Me.getPhysicalPath, "")
                strResult = Replace(strResult, "\", "/")
            Catch ex As Exception
            End Try
            Return strResult
        End Function

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not objBInput Is Nothing Then
                        objBInput.Dispose(True)
                        objBInput = Nothing
                    End If
                    If Not objBCatalogueForm Is Nothing Then
                        objBCatalogueForm.Dispose(True)
                        objBCatalogueForm = Nothing
                    End If
                    If Not objBItemCollection Is Nothing Then
                        objBItemCollection.Dispose(True)
                        objBItemCollection = Nothing
                    End If
                    If Not objBEData Is Nothing Then
                        objBEData.Dispose(True)
                        objBEData = Nothing
                    End If
                    If Not objBCopyNumber Is Nothing Then
                        objBCopyNumber.Dispose(True)
                        objBCopyNumber = Nothing
                    End If
                    If Not objBPatron Is Nothing Then
                        objBPatron.Dispose(True)
                        objBPatron = Nothing
                    End If
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

    End Class

End Namespace
