Imports System.IO
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.WebUI.Common
Imports OfficeOpenXml
Imports OfficeOpenXml.FormulaParsing.Excel.Functions.Math

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WImportDataExcelDataBase
        Inherits clsWBase

        Private objBItem As New clsBItem
        Private objBLocation As New clsBLocation
        Private objBLoanType As New clsBLoanType
        Private objBCopyNumber As New clsBCopyNumber
        Private objBInput As New clsBInput
        Private objBCDBS As New clsBCommonDBSystem


        Private intLibID As Integer = 0
        Private intHolID As Integer = 0

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            If (Not Page.IsPostBack) Then

            End If
        End Sub

        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
        End Sub

        Private Sub Initialize()
            If IsNumeric(Request("Authority")) Then
                Session("IsAuthority") = CInt(Request("Authority"))
            Else
                If Not IsNumeric(Session("IsAuthority")) Then
                    Session("IsAuthority") = 0
                End If
            End If

            ' Init objBCopyNumber object
            objBCopyNumber.InterfaceLanguage = Session("InterfaceLanguage")
            objBCopyNumber.DBServer = Session("DBServer")
            objBCopyNumber.ConnectionString = Session("ConnectionString")
            Call objBCopyNumber.Initialize()

            ' Init objBLocation object
            objBLocation.InterfaceLanguage = Session("InterfaceLanguage")
            objBLocation.DBServer = Session("DBServer")
            objBLocation.ConnectionString = Session("ConnectionString")
            Call objBLocation.Initialize()

            ' Init objBLocation object
            objBLoanType.InterfaceLanguage = Session("InterfaceLanguage")
            objBLoanType.DBServer = Session("DBServer")
            objBLoanType.ConnectionString = Session("ConnectionString")
            Call objBLoanType.Initialize()

            ' Init objBItem object
            objBItem.InterfaceLanguage = Session("InterfaceLanguage")
            objBItem.DBServer = Session("DBServer")
            objBItem.ConnectionString = Session("ConnectionString")
            Call objBItem.Initialize()

            ' Init objBInput object
            objBInput.InterfaceLanguage = Session("InterfaceLanguage")
            objBInput.DBServer = Session("DBServer")
            objBInput.ConnectionString = Session("ConnectionString")
            Call objBInput.Initialize()

            Session("IsAuthority") = 0
        End Sub

        Private Function BindProgress(ByVal valueTimeLoop As String) As String
            Dim resultText As String = "<script type='text/javascript'> "
            resultText = resultText & "function move() {"
            resultText = resultText & "var elem = document.getElementById('myBar'); "
            resultText = resultText & "var width = 0; "
            resultText = resultText & "var id = setInterval(frame, " & valueTimeLoop & "); "
            resultText = resultText & "function frame() { "
            resultText = resultText & "if (width >= 100) { "
            resultText = resultText & "clearInterval(id); "
            resultText = resultText & "} else { "
            resultText = resultText & "width++; "
            resultText = resultText & "elem.style.width = width + '%'; "
            resultText = resultText & "elem.style.width = width + '%'; "
            resultText = resultText & "document.getElementById('label').innerHTML = width * 1 + '%'; "
            resultText = resultText & "}}} "
            resultText = resultText & "document.getElementById('myProgress').style.display = 'inherit'; "
            resultText = resultText & "move(); "
            resultText = resultText & "</script>"

            Return resultText
        End Function

        Private Function GetListColumns(ByVal strColumnContains As String, ByVal tbl As DataTable) As List(Of String)
            Dim result As New List(Of String)
            For Each col As DataColumn In tbl.Columns
                If col.ColumnName.Contains(strColumnContains) Then
                    result.Add(col.ColumnName)
                End If
            Next
            Return result
        End Function

        Private Function ReadFileExcelToDataTable(ByVal fileUploadInput As FileUpload) As DataTable
            Dim tbl = New DataTable()
            If (fileUploadInput.HasFile AndAlso (IO.Path.GetExtension(fileUploadInput.FileName) = ".xlsx" Or IO.Path.GetExtension(fileUploadInput.FileName) = ".xls")) Then
                Using excel = New ExcelPackage(fileUploadInput.PostedFile.InputStream)
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
            Return tbl
        End Function

        Private Function CheckExistColumn(ByVal columnName As String, ByVal dataTable As DataTable) As Boolean
            Dim result As Boolean = False
            Dim dataColumn As DataColumnCollection = dataTable.Columns

            For Each tmp As DataColumn In dataColumn
                If tmp.ColumnName.Contains(columnName) Then
                    result = True
                    Exit For
                End If
            Next

            Return result
        End Function

        Private Sub InsertHoding(ByVal strCopyNumber As String, ByVal jItemID As Integer, ByVal strNumberCopies As String, ByVal strLoanType As String, ByVal strBarCode As String, ByVal strLocation As String, ByVal strAcqSource As String,
                                    ByVal strStatusCode As String, ByVal strStatusNode As String, ByVal intPrice As Double, ByVal strDateCreate As Date, ByVal strDateUpdate As Date, ByVal strNameCreate As String, ByVal strNameUpdate As String, ByVal strNote As String)
            Try
                Dim tblItem As New DataTable
                Dim strItemID As String = ""

                objBItem.ItemID = jItemID
                objBItem.Code = ""
                tblItem = objBItem.GetItems
                If Not tblItem Is Nothing AndAlso tblItem.Rows.Count > 0 Then
                    strItemID = tblItem.Rows(0).Item("Code")
                End If

                intLibID = 0
                intHolID = 0
                ReferrenceLocation(strLocation)



                Dim strLoanTypeReferrence As String = ReferrenceLoanTypeDHVL(strLoanType) 'ReferrenceLoanType(strLoanType)
                objBLoanType.LoanTypeCode = strLoanTypeReferrence
                Dim tblLoanType As DataTable = objBLoanType.GetLoanTypesByLoanTypeCode()
                Dim intLoanTypeID As Integer = 3
                If Not IsNothing(tblLoanType) AndAlso tblLoanType.Rows.Count > 0 Then
                    intLoanTypeID = tblLoanType.Rows(0).Item("ID") & ""
                End If

                Dim intAcqSourceID As Integer = 1
                Dim tblAcqSource As DataTable = objBCopyNumber.GetAcqSource(strAcqSource)
                If Not IsNothing(tblAcqSource) AndAlso tblAcqSource.Rows.Count > 0 Then
                    intAcqSourceID = tblAcqSource.Rows(0).Item("ID") & ""
                End If

                If Not String.IsNullOrEmpty(strStatusCode) Then
                    strStatusNode = ReferrenceStatusNote(strStatusCode)
                End If

                objBCopyNumber.Code = strItemID
                objBCopyNumber.HolLibID = intLibID
                objBCopyNumber.LoanTypeID = intLoanTypeID
                objBCopyNumber.StartHolding = strCopyNumber
                objBCopyNumber.Price = intPrice

                objBCopyNumber.Range = 1
                objBCopyNumber.LocID = intHolID
                objBCopyNumber.ChangeDate = Format(Date.Now, "dd/MM/yyyy")
                objBCopyNumber.Shelf = ""
                objBCopyNumber.AcqSourceID = intAcqSourceID
                objBCopyNumber.NumberCopies = strNumberCopies
                objBCopyNumber.BarCode = strBarCode
                objBCopyNumber.StatusNode = strStatusNode
                objBCopyNumber.StatusCode = strStatusCode
                objBCopyNumber.DateCreate = strDateCreate
                objBCopyNumber.DateUpdate = strDateUpdate
                objBCopyNumber.Note = strNote

                ' Add Holding
                Dim bytErrAddHold As Byte
                bytErrAddHold = objBCopyNumber.Create(strNameCreate, strNameUpdate, 1, 1)
            Catch ex As Exception
            End Try
        End Sub

        Private Sub UpdateLoanType(ByVal strCopNumber As String, ByVal intLoanType As Integer)
            Dim textQuery As String = "Update Lib_tblHolding SET LoanTypeID=" & intLoanType & " WHERE CopyNumber=N'" & strCopNumber & "'"
            objBInput.ExcuteQueryByScript(textQuery)
        End Sub

        ' GenerateCutter method
        ' Purpose: generate suite cutter
        Private Function GenerateCutter(ByVal stringStart As String) As String
            Dim strCutter As String
            'Dim strPath As String = Request.ApplicationPath & "/oclccutt/"
            Dim strPath As String = Server.MapPath("../../oclccutt/")
            Dim objDirInfo As DirectoryInfo
            objDirInfo = New DirectoryInfo(strPath)
            If Not objDirInfo.Exists Then
                Call objDirInfo.Create()
            End If
            ' Get cutter
            'objBCatalogueForm.Path = Server.MapPath(strPath)
            Dim pathCode = Server.MapPath(Request.ApplicationPath) & "/Excell" & "/Code.xlsx"
            Dim pathNguyenAm = Server.MapPath(Request.ApplicationPath) & "/Excell" & "/NguyenAm.xlsx"
            Dim pathPhuAm = Server.MapPath(Request.ApplicationPath) & "/Excell" & "/PhuAm.xlsx"

            Dim tableCode = ExcellHelper.GetDataTableFromExcel(pathCode, False)
            Dim tableNguyenAm = ExcellHelper.GetDataTableFromExcel(pathNguyenAm, False)
            Dim tablePhuAm = ExcellHelper.GetDataTableFromExcel(pathPhuAm, False)
            Dim charStart = stringStart.ToCharArray()
            stringStart = ""
            For Each item As Char In charStart
                For Each dtrow As DataRow In tablePhuAm.Rows
                    If dtrow.Item(0).ToString() <> "" Then
                        Dim chartmp = dtrow.Item(0).ToString().ToCharArray()(0)
                        If item = chartmp Then
                            item = dtrow.Item(1).ToString().ToCharArray()(0)
                        End If
                    End If
                Next
                Dim i = Asc(item)
                If item <> "" AndAlso i <> 180 AndAlso i <> 63 AndAlso i <> 96 AndAlso i <> 126 Then
                    stringStart = stringStart + item.ToString()
                End If
            Next

            stringStart = stringStart.ToLower()
            Dim stringFirt = stringStart.Split(" ")(0)
            Dim listString = stringStart.Split(" ")
            Dim charSecond = ""

            If listString.Count() > 1 Then
                Dim secondString = listString(1)
                Dim checkExitNguyenAmSecond = False
                Dim lenght = 0

                For Each dr As DataRow In tableNguyenAm.Rows
                    Dim nguyenAmExcel = dr.Item(0).ToString()
                    If secondString.IndexOf(nguyenAmExcel) = 0 AndAlso nguyenAmExcel <> "" Then

                        If (lenght <= nguyenAmExcel.Length) Then
                            lenght = nguyenAmExcel.Length
                            charSecond = nguyenAmExcel
                        End If
                        checkExitNguyenAmSecond = True
                    End If
                Next
                If checkExitNguyenAmSecond = False Then
                    charSecond = secondString.ToCharArray()(0)
                End If
            End If

            Dim stringb = listString(0).ToLower()
            Dim checkExitNguyenAm = False
            Dim nguyenAm = ""

            For Each dr As DataRow In tableNguyenAm.Rows
                Dim nguyenAmExcel = dr.Item(0).ToString()
                If stringb.IndexOf(nguyenAmExcel) = 0 AndAlso nguyenAmExcel <> "" Then
                    checkExitNguyenAm = True
                    If nguyenAm.Length < nguyenAmExcel.Length Then
                        nguyenAm = nguyenAmExcel
                    End If

                End If
            Next

            If checkExitNguyenAm Then
                For Each drCode As Object In tableCode.Rows
                    Dim phuAmExcel = drCode.Item(0).ToString()
                    Dim code = drCode.Item(1).ToString()
                    Dim tmp = stringFirt.ToLower().Remove(0, nguyenAm.Length)
                    If stringFirt.Contains(phuAmExcel) AndAlso tmp.Length = phuAmExcel.Length Then
                        stringFirt = stringFirt.Replace(stringFirt, code)
                    End If
                Next
            Else
                Dim phuAmDau = stringFirt.ToCharArray()(0)
                For Each drCode As Object In tableCode.Rows
                    Dim phuAmExcel = drCode.Item(0).ToString()
                    If stringb.Contains(phuAmExcel) = 0 AndAlso stringb.Length = phuAmExcel.Length Then
                        stringFirt = phuAmDau & drCode.Item(1).ToString()
                    End If
                Next

            End If

            Dim stringcuoi = (nguyenAm & stringFirt & charSecond).ToString().ToUpper() '"$b" & (nguyenAm & stringFirt & charSecond).ToString().ToUpper()
            Return stringcuoi

        End Function

        Public Sub BindPrg(ByVal intCurrent As Integer, ByVal intSum As Integer)
            Dim intCurrentPercent As Integer
            intCurrentPercent = ((intCurrent + 1) * 100) / intSum
            'System.Threading.Thread.Sleep(850)
            Response.Write("<script>if (pgbObj = document.getElementById('pgbMain')) pgbObj.width =" & intCurrentPercent & " + '%'; if (lblObj = document.getElementById('pgbMain_label')) lblObj.innerHTML =" & intCurrentPercent & " + '%';</script>")
            Response.Flush()
        End Sub

        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Me.Dispose(True)
        End Sub

        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not objBItem Is Nothing Then
                        objBItem.Dispose(True)
                        objBItem = Nothing
                    End If
                    If Not objBLocation Is Nothing Then
                        objBLocation.Dispose(True)
                        objBLocation = Nothing
                    End If
                    If Not objBLoanType Is Nothing Then
                        objBLoanType.Dispose(True)
                        objBLoanType = Nothing
                    End If
                    If Not objBCopyNumber Is Nothing Then
                        objBCopyNumber.Dispose(True)
                        objBCopyNumber = Nothing
                    End If
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

        Protected Sub btnImportData_Click(sender As Object, e As EventArgs) Handles btnImportData.Click
            Dim tbl As DataTable = ReadFileExcelToDataTable(FileUpload1)
            If Not IsNothing(tbl) AndAlso tbl.Rows.Count Then
                Call ImportData(tbl)
            End If

        End Sub

        '{Sach}
        '{GiaoTrinh}
        '{SachThaoKhao}
        '{TaiLieuDienTu}
        '{DeTaiNghienCuu}
        '{Bao}
        '{BaoCaoThucTap}
        '{LuanVan}
        '{CDROM}
        '{LuanAn}
        '{TapChi}
        Private Function ReferrenceItemType(ByVal strValue As String) As String
            Dim intResult As String = "S"
            Select Case strValue
                Case "Sach"
                    intResult = "S"
                Case "GiaoTrinh"
                    intResult = "GT"
                Case "SachThaoKhao"
                    intResult = "S"
                Case "TaiLieuDienTu"
                    intResult = "TLDT"
                Case "DeTaiNghienCuu"
                    intResult = "BC"
                Case "BAO"
                    intResult = "BAO"
                Case "BaoCaoThucTap"
                    intResult = "BC"
                Case "LuanVan"
                    intResult = "LA"
                Case "CDROM"
                    intResult = "MEDIA"
                Case "LuanAn"
                    intResult = "LA"
                Case Else
                    intResult = "S"
            End Select
            Return intResult
        End Function

        '{Sach}
        '{GiaoTrinh}
        '{SachThaoKhao}
        '{TaiLieuDienTu}
        '{DeTaiNghienCuu}
        '{Bao}
        '{BaoCaoThucTap}
        '{LuanVan}
        '{CDROM}
        '{LuanAn}
        '{TapChi}

        Private Function ReferrenceLoanTypeDHVL(ByVal strValue As String) As String
            Dim strResult As String = "S"
            Select Case strValue
                Case "Sach"
                    strResult = "Sach"
                Case "GiaoTrinh"
                    strResult = "GiaoTrinh"
                Case "SachThaoKhao"
                    strResult = "SachThaoKhao"
                Case "TaiLieuDienTu"
                    strResult = "TaiLieuDienTu"
                Case "DeTaiNghienCuu"
                    strResult = "DeTaiNghienCuu"
                Case "Bao"
                    strResult = "BAO"
                Case "BaoCaoThucTap"
                    strResult = "BaoCaoThucTap"
                Case "LuanVan"
                    strResult = "LuanVan"
                Case "CDROM"
                    strResult = "CDROM"
                Case "LuanAn"
                    strResult = "LuanAn"
                Case "TapChi"
                    strResult = "TapChi"
                Case Else
                    strResult = "Sach"
            End Select
            Return strResult
        End Function

        Private Function ReferrenceLoanType(ByVal strValue As String) As String
            Dim strResult As String = "STK"
            Select Case strValue
                Case "Bao"
                    strResult = "BAO"
                Case "BaoCaoThucTap"
                    strResult = "KL"
                Case "CDROM"
                    strResult = "CD"
                Case "DeTaiNghienCuu"
                    strResult = "NCKH-GV"
                Case "GiaoTrinh"
                    strResult = "STK"
                Case "LuanAn"
                    strResult = "LA"
                Case "LuanVan"
                    strResult = "LV"
                Case "Sach"
                    strResult = "STK"
                Case "SachThaoKhao"
                    strResult = "STK"
                Case "TaiLieuDienTu"
                    strResult = "TLDT"
                Case "TapChi"
                    strResult = "TC"
                Case Else
                    strResult = "TLDT"
            End Select
            Return strResult
        End Function

        Private Sub ReferrenceLocation(ByVal strValue As String)

            'Select Case strValue
            '    Case "NN"
            '        strValue = "N"
            '    Case "P.DT"
            '        strValue = "DT"
            '    Case "CO"
            '        strValue = "C"
            '    Case "QT"
            '        strValue = "Q"
            '    Case "A"
            '        strValue = "CS1"
            '    Case "MC"
            '        strValue = "H"
            '    Case "MT"
            '        strValue = "M"
            '    Case "BCL"
            '        strValue = "CL"
            '    Case "TC"
            '        strValue = "TC"
            '    Case "KZ"
            '        strValue = "KZ"
            '    Case "SH"
            '        strValue = "MS"
            '    Case "TH"
            '        strValue = "T"
            '    Case "P.KT"
            '        strValue = "K"
            '    Case "KT"
            '        strValue = "F"
            '    Case "DL"
            '        strValue = "D"
            '    Case "P.HD3"
            '        strValue = "P.HD3"
            '    Case "O.CB"
            '        strValue = "CB"
            '    Case "B"
            '        strValue = "CS2"
            '    Case "KY"
            '        strValue = "KY"
            'End Select

            Dim tblLocation As DataTable = objBLocation.GetLocationBySymbol(strValue)
            If Not IsNothing(tblLocation) AndAlso tblLocation.Rows.Count > 0 Then
                intLibID = tblLocation.Rows(0).Item("LibID") & ""
                intHolID = tblLocation.Rows(0).Item("ID") & ""
            End If
        End Sub

        Private Function ReferrenceStatusNote(ByVal strStatusCode As String) As String
            Dim strResult As String = ""
            Select Case strStatusCode
                Case "SDTL"
                    strResult = "Sách đã thanh lý"
                Case "TT001"
                    strResult = "Nhập mới ấn phẩm mới mua"
                Case "TT002"
                    strResult = "Nhập mới ấn phẩm được đền từ độc giả"
                Case "TT003"
                    strResult = "Nhập mới ấn phẩm được tặng"
                Case "TT004"
                    strResult = "Ấn phẩm bảo trì kỹ thuật"
                Case "TT005"
                    strResult = "Ấn phẩm cần sử đổi thông tin"
                Case "TT006"
                    strResult = "Ấn phẩm chờ thanh lý"
                Case "TT007"
                    strResult = "Ấn phẩm đang lưu hành bình thường"
                Case "TT008"
                    strResult = "AP cần phải chuyển về cho bộ phận biên mục xử lý"
                Case "TT009"
                    strResult = "Ấn phẩm được yêu cầu sửa đổi thông tin"
                Case "TT010"
                    strResult = "Ấn phẩm đã đem đi triển lãm"
                Case "TT011"
                    strResult = "Ấn phẩm đánh dấu thanh lý (vẫn được lưu hành)"
                Case "TT012"
                    strResult = "Đã nhập mới xong và sẽ chuyển ra kho"
                Case "TT013"
                    strResult = "Ấn phẩm chuyển đi bảo trì"
                Case "TT014"
                    strResult = "Ấn phẩm đã bảo trì xong cần chuyển ra kho"
                Case "TT015"
                    strResult = "Sách thanh lý năm 2007"
                Case "TT016"
                    strResult = "Tặng sách đồng môn"
                Case "TT017"
                    strResult = "Thanh lý tháng 11/2008"
                Case "TT018"
                    strResult = "Thanh lý tháng 12/2008"
                Case "TT019"
                    strResult = "Mất"
                Case "TT020"
                    strResult = "Mất - đã đền tiền"
                Case "TT021"
                    strResult = "Mất - đã đền tiền trước KK 2008"
                Case "TT022"
                    strResult = "Mất - sau KK 2008-2009"
                Case "TT023"
                    strResult = "Mất - đã đền tiền 10/2008"
                Case "TT024"
                    strResult = "Mất - sau KK 2009-2010"
                Case "TT025"
                    strResult = "Sách không tồn tại sau 8 năm 2008"
                Case "TT026"
                    strResult = "Mất - đền tiền năm học 09-10"
                Case "TT027"
                    strResult = "Mất - sau kk 2010-2011"
                Case "TT028"
                    strResult = "Mất - sau kk 2011-2012"
                Case "TT029"
                    strResult = "Mất - sau kk 2012-2013"
                Case Else
                    strResult = ""
            End Select
            Return strResult
        End Function

        Private Sub ImportData(ByVal tbl As DataTable)
            Dim listError As New List(Of String) ' Danh sách insert ko được
            Dim listErrorDKCB As New List(Of String) ' Danh sách insert DKCB ko được

            Dim countTotalRecordInput As Integer = If(tbl.Rows.Count <= 0, 0, tbl.Rows.Count) 'Tổng dòng nhập từ file excel
            Dim countSusscess As Integer = 0  'Tổng dòng thực hiện thành công

            Dim itemId As Integer = 0

            lbTotalInput.Text = "<i>Tổng số dòng nhập từ file Excel: </i><b><u>" & countTotalRecordInput & "</u></b>"

            Response.Write("<div class='lbLabel' style=' margin:0;top:250;left:0; width:100%;'>")
            Response.Write("<p style='position:absolute; left:45%;'>Nhập khẩu dữ liệu: <span id='pgbMain_label'>0%</span></p>")
            Response.Write("<p style='padding-top:35px;'><table width='0%' border=2 bordercolor='white' id='pgbMain' bgcolor=blue><tr style='HEIGHT: 18px'><td></td></tr></table></p>")
            Response.Write("</div>")

            Dim strDollarSplit As String = "$"

            Dim strTitle As String = ""
            Dim strTitlePre As String = ""
            Dim strCopyNumber As String = ""
            Dim strBarCode As String = ""
            Dim strLocation As String = ""
            Dim strAuthor As String = ""
            Dim strAuthorPre As String = ""
            Dim strItemSH As String = ""
            Dim strDescription As String = ""
            Dim strPublisher As String = ""
            Dim strPublisherPre As String = ""
            Dim strPublishYear As String = ""
            Dim strPublishYearPre As String = ""
            Dim strAuthorOther As String = ""
            Dim strPhysical As String = ""
            Dim strDocumentFormat As String = ""
            Dim strSource As String = ""
            Dim strLanguage As String = ""
            Dim strStatusCode As String = ""
            Dim strStatusNote As String = ""
            Dim strDateCreate As String = ""
            Dim strDateUpdate As String = ""
            Dim strCataloguer As String = ""
            Dim strCataloguerUpdate As String = ""
            Dim strItemType As String = ""
            Dim strNumberCopies As String = ""
            Dim strPrice As String = "0"
            Dim strLoanType As String = ""
            Dim listColumn650a As New List(Of String)
            Dim listColumn700a As New List(Of String)
            Dim strNote As String = ""


            For i As Integer = 0 To tbl.Rows.Count - 1
                Try
                    Dim row As DataRow = tbl.Rows(i)
                    Dim textQuery = ""

                    strCopyNumber = row.Item("SDKCaBiet") & ""                      'CopyNumber
                    strBarCode = row.Item("MaVach") & ""                            'BarCode
                    strLocation = row.Item("MaKho") & ""                            'Location
                    strTitle = row.Item("NhanDeChinh") & ""                         'Nhan de / $a:245$a; $b:245$b ; $e:NumberCopies
                    strAuthor = row.Item("TacGia") & ""                             'Tac gia / $a:100$a
                    strItemSH = row.Item("DeMuc") & ""                              'De muc / $a:082$a ; $b:082$b ; $c:650$a 
                    strDescription = row.Item("MoTa") & ""                          'Mo ta / $a:520$a
                    strPublisher = row.Item("XuatBan") & ""                         'Xuat ban / $a:250$a ; $c:260$a ; $d:260$b; 
                    strPublishYear = row.Item("NgayThang") & ""                     'Ngay thang / $a:260$c (bỏ : và khoảng trắng)
                    strAuthorOther = row.Item("TacGiaPhu") & ""                     'Tac gia phu / $a:700$a
                    strPhysical = row.Item("MoTaVatLy") & ""                        'Mo ta vat ly / $a:300$a ; $b:300$b ; $c:300$c ; $d:300$e ; $e:Price
                    strDocumentFormat = row.Item("DinhDanhTuLieu") & ""             'Dinh dang tai lieu / $a:020$a (bỏ gạch ngang, khoảng trắng)
                    strSource = row.Item("NguonGoc") & ""                           'Nguon goc / $a:040$a
                    strLanguage = row.Item("NgonNgu") & ""                          'Ngon ngu / $a:041$a
                    strStatusCode = row.Item("MaTinhTrang") & ""                    'StatusCode
                    strStatusNote = row.Item("GhiChuTinhTrang") & ""                'StatusNote
                    strDateCreate = row.Item("NgayTao") & ""                        'CreateDate - Item ; DateCreate - Holding
                    strDateUpdate = row.Item("NgayCapNhat") & ""                    'UpdateDate - Item ; DateUpdate - Holding
                    strCataloguer = row.Item("NhanVienTao") & ""                    'Cataloguer - Item ; NameCreate - Holding
                    strCataloguerUpdate = row.Item("NhanVienCapNhat") & ""          'CataloguerUpdate - Item ; NameUpdate - Holding
                    strItemType = row.Item("MaLoaiAnPham") & ""                     'ItemType
                    strLoanType = row.Item("MaLoaiAnPham") & ""

                    If strCopyNumber = "NULL" Then strCopyNumber = ""
                    If strBarCode = "NULL" Then strBarCode = ""
                    If strLocation = "NULL" Then strLocation = ""
                    If strTitle = "NULL" Then strTitle = ""
                    If strAuthor = "NULL" Then strAuthor = ""
                    If strItemSH = "NULL" Then strItemSH = ""
                    If strDescription = "NULL" Then strDescription = ""
                    If strPublisher = "NULL" Then strPublisher = ""
                    If strPublishYear = "NULL" Then strPublishYear = ""
                    If strAuthorOther = "NULL" Then strAuthorOther = ""
                    If strPhysical = "NULL" Then strPhysical = ""
                    If strDocumentFormat = "NULL" Then strDocumentFormat = ""
                    If strSource = "NULL" Then strSource = ""
                    If strLanguage = "NULL" Then strLanguage = ""
                    If strStatusCode = "NULL" Then strStatusCode = ""
                    If strStatusNote = "NULL" Then strStatusNote = ""
                    If strDateCreate = "NULL" Then strDateCreate = ""
                    If strDateUpdate = "NULL" Then strDateUpdate = ""
                    If strCataloguer = "NULL" Then strCataloguer = ""
                    If strCataloguerUpdate = "NULL" Then strCataloguerUpdate = ""
                    If strItemType = "NULL" Then strItemType = ""
                    If strLoanType = "NULL" Then strLoanType = ""

                    listColumn650a.Clear()
                    listColumn700a.Clear()

                    Dim arrFieldName() As Object
                    Dim arrFieldValue() As Object
                    ReDim Preserve arrFieldName(17)
                    ReDim Preserve arrFieldValue(17)

                    Try
                        arrFieldName(0) = "000"
                        arrFieldValue(0) = "00172nam a2200121 p 4500"
                    Catch ex As Exception
                        arrFieldName(0) = Nothing
                        arrFieldValue(0) = Nothing
                    End Try

                    Try
                        arrFieldName(1) = "001"
                        arrFieldValue(1) = objBInput.Gen001(CInt(Session("IsAuthority")))
                    Catch ex As Exception
                        arrFieldName(1) = Nothing
                        arrFieldValue(1) = Nothing
                    End Try

                    Try
                        arrFieldName(2) = "911"
                        arrFieldValue(2) = strCataloguer
                    Catch ex As Exception
                        arrFieldName(2) = Nothing
                        arrFieldValue(2) = Nothing
                    End Try

                    Try
                        arrFieldName(3) = "925"
                        arrFieldValue(3) = "G"
                    Catch ex As Exception
                        arrFieldName(3) = Nothing
                        arrFieldValue(3) = Nothing
                    End Try

                    Try
                        arrFieldName(4) = "926"
                        arrFieldValue(4) = "0"
                    Catch ex As Exception
                        arrFieldName(4) = Nothing
                        arrFieldValue(4) = Nothing
                    End Try

                    Try
                        arrFieldName(5) = "927"
                        arrFieldValue(5) = ReferrenceItemType(ReferrenceLoanTypeDHVL(strItemType))
                    Catch ex As Exception
                        arrFieldName(5) = Nothing
                        arrFieldValue(5) = Nothing
                    End Try

                    Try
                        arrFieldName(6) = "900"
                        arrFieldValue(6) = "1"
                    Catch ex As Exception
                        arrFieldName(6) = Nothing
                        arrFieldValue(6) = Nothing
                    End Try

                    '245 - Nhan de / $a:245$a; $b:245$b ; $d:245$d ; $e:NumberCopies
                    strNumberCopies = ""
                    Try
                        arrFieldName(7) = Nothing
                        arrFieldValue(7) = Nothing
                        If Not String.IsNullOrEmpty(strTitle) Then
                            arrFieldName(7) = "245"
                            arrFieldValue(7) = ""
                            Dim arrSplitTitle As String() = strTitle.Split(strDollarSplit)
                            For Each itemArr As String In arrSplitTitle
                                If itemArr.Length > 0 Then
                                    itemArr = itemArr.Trim()
                                    If itemArr(0) <> "e" Then
                                        arrFieldValue(7) = arrFieldValue(7) & strDollarSplit & itemArr.Replace(Left(itemArr, 1) & ":", Left(itemArr, 1)).Replace("'", "")
                                    Else
                                        strNumberCopies = itemArr.Replace("e:", "e").Trim()
                                        strNumberCopies = strNumberCopies.Substring(1).Trim()
                                    End If

                                    'If itemArr(0) <> "e" Then
                                    '    If itemArr(0) = "a" Then
                                    '        strTitle = itemArr.Replace("a:", "").Replace("'", "").Trim()
                                    '    End If
                                    '    arrFieldValue(7) = arrFieldValue(7) & strDollarSplit & itemArr.Replace(Left(itemArr, 1) & ":", Left(itemArr, 1)).Replace("'", "")
                                    'Else
                                    '    strNumberCopies = itemArr.Replace("e:", "e").Trim()
                                    '    strNumberCopies = strNumberCopies.Substring(1).Trim()
                                    'End If
                                End If
                            Next
                            strTitle = arrFieldValue(7) & ""
                        End If
                    Catch ex As Exception
                        arrFieldName(7) = Nothing
                        arrFieldValue(7) = Nothing
                    End Try

                    '100 - Tac gia / $a:100$a
                    Try
                        arrFieldName(8) = Nothing
                        arrFieldValue(8) = Nothing
                        If Not String.IsNullOrEmpty(strAuthor) Then
                            arrFieldName(8) = "100"
                            arrFieldValue(8) = strAuthor.Replace(Left(strAuthor, 2) & ":", Left(strAuthor, 2)).Replace("'", "")
                        End If
                    Catch ex As Exception
                        arrFieldName(8) = Nothing
                        arrFieldValue(8) = Nothing
                    End Try

                    '082,650 - De muc / $a:082$a ; $b:082$b ; $c:650$a
                    Try
                        arrFieldName(9) = Nothing
                        arrFieldValue(9) = Nothing
                        If Not String.IsNullOrEmpty(strItemSH) Then
                            arrFieldName(9) = "082"
                            arrFieldValue(9) = ""
                            Dim arrSplitItemSH As String() = strItemSH.Split(strDollarSplit)
                            For Each itemArr As String In arrSplitItemSH
                                If itemArr.Length > 0 Then
                                    If itemArr(0) <> "c" Then
                                        arrFieldValue(9) = arrFieldValue(9) & strDollarSplit & itemArr.Replace(Left(itemArr, 1) & ":", Left(itemArr, 1))
                                    Else
                                        Dim str650a As String = itemArr.Replace("c:", "c").Substring(1)
                                        'Dim arr650aSplit As String() = str650a.Split(New String() {"--"}, StringSplitOptions.None)
                                        'For Each item650 As String In arr650aSplit
                                        '    listColumn650a.Add(item650.Trim())
                                        'Next
                                        listColumn650a.Add(str650a.Trim())
                                    End If
                                End If
                            Next
                        End If
                    Catch ex As Exception
                        arrFieldName(9) = Nothing
                        arrFieldValue(9) = Nothing
                    End Try

                    '520 - Mo ta / $a:520$a
                    Try
                        arrFieldName(10) = Nothing
                        arrFieldValue(10) = Nothing
                        If Not String.IsNullOrEmpty(strDescription) Then
                            arrFieldName(10) = "520"
                            arrFieldValue(10) = strDescription.Replace(Left(strDescription, 2) & ":", Left(strDescription, 2)).Trim().Replace("'", "").Replace("’", "")
                        End If
                    Catch ex As Exception
                        arrFieldName(10) = Nothing
                        arrFieldValue(10) = Nothing
                    End Try

                    '250,260 - Xuat ban / $a:250$a ; $c:260$a ; $d:260$b
                    '260 - Ngay thang / $a:260$c (bỏ : và khoảng trắng)
                    Try
                        arrFieldName(11) = Nothing
                        arrFieldValue(11) = Nothing
                        arrFieldName(12) = Nothing
                        arrFieldValue(12) = Nothing
                        If Not String.IsNullOrEmpty(strPublisher) Then
                            arrFieldName(11) = "250"
                            arrFieldName(12) = "260"
                            arrFieldValue(11) = ""
                            arrFieldValue(12) = ""
                            Dim arrSplitPublisher As String() = strPublisher.Split(strDollarSplit)
                            For Each itemArr As String In arrSplitPublisher
                                If itemArr.Length > 0 Then
                                    If itemArr(0) = "a" Then
                                        arrFieldValue(11) = Trim(arrFieldValue(11) & strDollarSplit & itemArr.Replace(Left(itemArr, 1) & ":", Left(itemArr, 1)))
                                    Else
                                        If itemArr(0) = "c" Then
                                            itemArr = "a" & itemArr.Substring(1)
                                        End If
                                        If itemArr(0) = "d" Then
                                            itemArr = "b" & itemArr.Substring(1)
                                        End If
                                        arrFieldValue(12) = Trim(arrFieldValue(12) & strDollarSplit & itemArr.Replace(Left(itemArr, 1) & ":", Left(itemArr, 1))).Replace("'", "")
                                    End If
                                End If
                            Next
                        End If

                        If Not String.IsNullOrEmpty(strPublishYear) Then
                            Dim arrSplitPublishYear As String() = strPublishYear.Split(strDollarSplit)
                            For Each itemArr As String In arrSplitPublishYear
                                If itemArr.Length > 0 Then
                                    If itemArr(0) = "a" Then
                                        itemArr = "c" & itemArr.Trim.Substring(1)
                                    End If
                                    arrFieldValue(12) = Trim(arrFieldValue(12) & strDollarSplit & itemArr.Replace(Left(itemArr, 1) & ":", Left(itemArr, 1)))
                                End If
                            Next
                        End If
                    Catch ex As Exception
                        arrFieldName(11) = Nothing
                        arrFieldValue(11) = Nothing
                        arrFieldName(12) = Nothing
                        arrFieldValue(12) = Nothing
                    End Try

                    '700 - Tac gia phu / $a:700$a
                    Try
                        arrFieldName(13) = Nothing
                        arrFieldValue(13) = Nothing
                        If Not String.IsNullOrEmpty(strAuthorOther) Then
                            arrFieldName(13) = "700"
                            arrFieldValue(13) = ""
                            Dim arrSplitAuthorOther As String() = strAuthorOther.Split(strDollarSplit)
                            For Each itemArr As String In arrSplitAuthorOther
                                If itemArr.Length > 0 Then
                                    Dim str700a As String = itemArr.Replace(Left(itemArr, 1) & ":", Left(itemArr, 1)).Substring(1)
                                    Dim arr700aSplit As String() = str700a.Split(New Char() {","}, StringSplitOptions.None)
                                    For Each item700 As String In arr700aSplit
                                        listColumn700a.Add(item700.Trim())
                                    Next
                                End If
                            Next
                        End If
                    Catch ex As Exception
                        arrFieldName(13) = Nothing
                        arrFieldValue(13) = Nothing
                    End Try

                    strPrice = "0"
                    strNote = ""
                    '300 - Mo ta vat ly / $a:300$a ; $b:300$b ; $c:300$c ; $d:300$e ; $e:Price
                    Try
                        arrFieldName(14) = Nothing
                        arrFieldValue(14) = Nothing
                        If Not String.IsNullOrEmpty(strPhysical) Then
                            arrFieldName(14) = "300"
                            arrFieldValue(14) = ""
                            Dim arrPhysical As String() = strPhysical.Split(strDollarSplit)
                            For Each itemArr As String In arrPhysical
                                If itemArr.Length > 0 Then
                                    If itemArr(0) <> "e" Then
                                        If itemArr(0) = "d" Then
                                            itemArr = "e" & itemArr.Substring(1)
                                        End If
                                        arrFieldValue(14) = arrFieldValue(14) & strDollarSplit & itemArr.Replace(Left(itemArr, 1) & ":", Left(itemArr, 1))
                                    Else
                                        strPrice = itemArr.Replace(Left(itemArr, 1) & ":", Left(itemArr, 1)).Substring(1)
                                        Dim strTypeCurency As String = "VN"
                                        If strPrice.Contains("USD") Then
                                            strTypeCurency = "EN"
                                        End If
                                        strPrice = strPrice.Replace("(", "").Trim()
                                        strPrice = strPrice.Replace("VNĐ", "").Trim()
                                        strPrice = strPrice.Replace(")", "").Trim()
                                        strPrice = strPrice.Replace("VND", "").Trim()
                                        strPrice = strPrice.Replace("đ", "").Trim()
                                        strPrice = strPrice.Replace("đồng", "").Trim()
                                        strPrice = strPrice.Replace("USD", "").Trim()
                                        If Not IsNumeric(strPrice) Then
                                            'strPrice = strPrice.Replace("sách tặng", "").Trim()
                                            'strPrice = strPrice.Replace("photo", "").Trim()
                                            'strPrice = strPrice.Replace("Download", "").Trim()
                                            'strPrice = strPrice.Replace("Scan", "").Trim()

                                            strNote = strPrice
                                            strPrice = "0"
                                        Else
                                            If strTypeCurency = "VN" Then
                                                strPrice = strPrice.Replace(".", "").Trim()
                                                strPrice = strPrice.Replace(",", "").Trim()
                                                If strPrice.Trim().Length < 3 Then
                                                    strPrice = strPrice & "000"
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            Next
                        End If
                    Catch ex As Exception
                        arrFieldName(14) = Nothing
                        arrFieldValue(14) = Nothing
                    End Try

                    '020 - Dinh dang tai lieu / $a:020$a (bỏ gạch ngang, khoảng trắng)
                    Try
                        arrFieldName(15) = Nothing
                        arrFieldValue(15) = Nothing
                        If Not String.IsNullOrEmpty(strDocumentFormat) Then
                            arrFieldName(15) = "020"
                            arrFieldValue(15) = strDocumentFormat.Replace(Left(strDocumentFormat, 2) & ":", Left(strDocumentFormat, 2)).Replace("-", "").Replace("'", "").Replace(".", "").Trim()
                        End If
                    Catch ex As Exception
                        arrFieldName(15) = Nothing
                        arrFieldValue(15) = Nothing
                    End Try

                    '040 - Nguon goc / $a:040$a
                    Try
                        arrFieldName(16) = Nothing
                        arrFieldValue(16) = Nothing
                        If Not String.IsNullOrEmpty(strSource) Then
                            arrFieldName(16) = "040"
                            arrFieldValue(16) = strSource.Replace(Left(strDocumentFormat, 2) & ":", Left(strDocumentFormat, 2)).Trim()
                        End If
                    Catch ex As Exception
                        arrFieldName(16) = Nothing
                        arrFieldValue(16) = Nothing
                    End Try

                    '041 - Ngon ngu / $a:041$a
                    Try
                        arrFieldName(17) = Nothing
                        arrFieldValue(17) = Nothing
                        If Not String.IsNullOrEmpty(strLanguage) Then
                            arrFieldName(17) = "041"
                            arrFieldValue(17) = strLanguage.Replace("$a:", "").Trim()
                        End If
                    Catch ex As Exception
                        arrFieldName(17) = Nothing
                        arrFieldValue(17) = Nothing
                    End Try


                    For j As Integer = 7 To 17
                        If (IsNothing(arrFieldValue(j))) Or (String.IsNullOrEmpty(arrFieldValue(j))) Then
                            arrFieldName(j) = Nothing
                            arrFieldValue(j) = Nothing
                        End If
                    Next

                    ' import to data
                    objBInput.FieldName = arrFieldName

                    objBInput.FieldValue = arrFieldValue
                    objBInput.LibID = clsSession.GlbSite



                    objBInput.SQL = "select * from Lib_tblHolding where Lib_tblHolding.CopyNumber = '" & strCopyNumber.Trim() & "'"
                    Dim tblDataCheckCopyNumber As DataTable = objBInput.GetData()
                    objBInput.SQL = ""


                    Dim boolExist As Boolean = True
                    If strTitle <> strTitlePre Then
                        boolExist = False
                    End If
                    If strAuthor <> strAuthorPre Then
                        boolExist = False
                    End If
                    If strPublisher <> strPublisherPre Then
                        boolExist = False
                    End If
                    If strPublishYear <> strPublishYearPre Then
                        boolExist = False
                    End If


                    If (Not IsNothing(tblDataCheckCopyNumber)) AndAlso (tblDataCheckCopyNumber.Rows.Count > 0) Then
                        If itemId > 0 Then
                            Call InsertHoding(strCopyNumber.Trim(), itemId, strNumberCopies.Trim(), strLoanType.Trim(), strBarCode.Trim(), strLocation.Trim(), strSource.Trim(), strStatusCode.Trim(), strStatusNote.Trim(), CType(strPrice, Double), strDateCreate.Trim(), Date.Now, strCataloguer.Trim(), strCataloguerUpdate.Trim(), strNote)
                            'objBInput.SQL = "select * from Lib_tblHolding where Lib_tblHolding.CopyNumber = '" & strCopyNumber & "'"
                            'Dim tblDataCheckCopyNumber As DataTable = objBInput.GetData()

                            'If (Not IsNothing(tblDataCheckCopyNumber)) AndAlso tblDataCheckCopyNumber.Rows.Count = 1 Then
                            '    Dim strHoldingID As String = tblDataCheckCopyNumber.Rows(0).Item("ID") & ""
                            '    textQuery = "insert into Lib_tblItemLocationVANLANG(HoldingID,MaKho) values (" & strHoldingID & ",N'" & strLocation.Trim() & "')"
                            '    objBInput.ExcuteQueryByScript(textQuery)

                            '    textQuery = "insert into Lib_tblItemLoanTypeVANLANG(HoldingID,MaLoai) values (" & strHoldingID & ",N'" & strLoanType.Trim() & "')"
                            '    objBInput.ExcuteQueryByScript(textQuery)
                            'End If
                            countSusscess = countSusscess + 1
                        End If
                    Else
                        If Not boolExist Then
                            If Session("IsAuthority") = 1 Then
                                If objBInput.UpdateAuthority(4, 1) = 1 Then
                                    itemId = Integer.Parse(objBInput.WorkID.ToString())
                                    If itemId > 0 Then
                                        For Each str650a As String In listColumn650a
                                            If str650a & "" <> "" Then
                                                textQuery = objBInput.GetTextQueryField("Lib_tblField600S", strDollarSplit & "a" & str650a, itemId, 650, 0)
                                                If objBInput.ExcuteQueryByScript(textQuery) = 1 Then
                                                    textQuery = "exec Cat_spDicSh_Ins N'" & str650a & "', " & itemId & ", '650$a'"
                                                    objBInput.ExcuteQueryByScript(textQuery)
                                                End If
                                            End If
                                        Next
                                        For Each str700a As String In listColumn700a
                                            If str700a & "" <> "" Then
                                                textQuery = objBInput.GetTextQueryField("Lib_tblField700S", strDollarSplit & "a" & str700a, itemId, 700, 0)
                                                If objBInput.ExcuteQueryByScript(textQuery) = 1 Then
                                                    textQuery = "exec Cat_spDicAuthor_Ins N'" & str700a & "', " & itemId & ", '700$a'"
                                                    objBInput.ExcuteQueryByScript(textQuery)
                                                End If
                                            End If
                                        Next
                                        Call InsertHoding(strCopyNumber.Trim(), itemId, strNumberCopies.Trim(), strLoanType.Trim(), strBarCode.Trim(), strLocation.Trim(), strSource.Trim(), strStatusCode.Trim(), strStatusNote.Trim(), CType(strPrice, Double), strDateCreate.Trim(), Date.Now, strCataloguer.Trim(), strCataloguerUpdate.Trim(), strNote)
                                        'objBInput.SQL = "select * from Lib_tblHolding where Lib_tblHolding.CopyNumber = '" & strCopyNumber & "'"
                                        'Dim tblDataCheckCopyNumber As DataTable = objBInput.GetData()

                                        'If (Not IsNothing(tblDataCheckCopyNumber)) AndAlso tblDataCheckCopyNumber.Rows.Count = 1 Then
                                        '    Dim strHoldingID As String = tblDataCheckCopyNumber.Rows(0).Item("ID") & ""
                                        '    textQuery = "insert into Lib_tblItemLocationVANLANG(HoldingID,MaKho) values (" & strHoldingID & ",N'" & strLocation.Trim() & "')"
                                        '    objBInput.ExcuteQueryByScript(textQuery)

                                        '    textQuery = "insert into Lib_tblItemLoanTypeVANLANG(HoldingID,MaLoai) values (" & strHoldingID & ",N'" & strLoanType.Trim() & "')"
                                        '    objBInput.ExcuteQueryByScript(textQuery)
                                        'End If
                                        countSusscess = countSusscess + 1
                                    End If
                                End If
                            Else
                                If objBInput.Update(4, 0) = 1 Then ' 4
                                    itemId = Integer.Parse(objBInput.WorkID.ToString())
                                    If itemId > 0 Then
                                        For Each str650a As String In listColumn650a
                                            If str650a & "" <> "" Then
                                                textQuery = objBInput.GetTextQueryField("Lib_tblField600S", strDollarSplit & "a" & str650a, itemId, 650, 0)
                                                If objBInput.ExcuteQueryByScript(textQuery) = 1 Then
                                                    textQuery = "exec Cat_spDicSh_Ins N'" & str650a & "', " & itemId & ", '650$a'"
                                                    objBInput.ExcuteQueryByScript(textQuery)
                                                End If
                                            End If
                                        Next
                                        For Each str700a As String In listColumn700a
                                            If str700a & "" <> "" Then
                                                textQuery = objBInput.GetTextQueryField("Lib_tblField700S", strDollarSplit & "a" & str700a, itemId, 700, 0)
                                                If objBInput.ExcuteQueryByScript(textQuery) = 1 Then
                                                    textQuery = "exec Cat_spDicAuthor_Ins N'" & str700a & "', " & itemId & ", '700$a'"
                                                    objBInput.ExcuteQueryByScript(textQuery)
                                                End If
                                            End If
                                        Next
                                        Call InsertHoding(strCopyNumber.Trim(), itemId, strNumberCopies.Trim(), strLoanType.Trim(), strBarCode.Trim(), strLocation.Trim(), strSource.Trim(), strStatusCode.Trim(), strStatusNote.Trim(), CType(strPrice, Double), strDateCreate.Trim(), Date.Now, strCataloguer.Trim(), strCataloguerUpdate.Trim(), strNote)
                                        'objBInput.SQL = "select * from Lib_tblHolding where Lib_tblHolding.CopyNumber = '" & strCopyNumber & "'"
                                        'Dim tblDataCheckCopyNumber As DataTable = objBInput.GetData()

                                        'If (Not IsNothing(tblDataCheckCopyNumber)) AndAlso tblDataCheckCopyNumber.Rows.Count = 1 Then
                                        '    Dim strHoldingID As String = tblDataCheckCopyNumber.Rows(0).Item("ID") & ""
                                        '    textQuery = "insert into Lib_tblItemLocationVANLANG(HoldingID,MaKho) values (" & strHoldingID & ",N'" & strLocation.Trim() & "')"
                                        '    objBInput.ExcuteQueryByScript(textQuery)

                                        '    textQuery = "insert into Lib_tblItemLoanTypeVANLANG(HoldingID,MaLoai) values (" & strHoldingID & ",N'" & strLoanType.Trim() & "')"
                                        '    objBInput.ExcuteQueryByScript(textQuery)
                                        'End If
                                        countSusscess = countSusscess + 1
                                    End If
                                End If
                            End If
                        Else
                            If itemId > 0 Then
                                Call InsertHoding(strCopyNumber.Trim(), itemId, strNumberCopies.Trim(), strLoanType.Trim(), strBarCode.Trim(), strLocation.Trim(), strSource.Trim(), strStatusCode.Trim(), strStatusNote.Trim(), CType(strPrice, Double), strDateCreate.Trim(), Date.Now, strCataloguer.Trim(), strCataloguerUpdate.Trim(), strNote)
                                'objBInput.SQL = "select * from Lib_tblHolding where Lib_tblHolding.CopyNumber = '" & strCopyNumber & "'"
                                'Dim tblDataCheckCopyNumber As DataTable = objBInput.GetData()

                                'If (Not IsNothing(tblDataCheckCopyNumber)) AndAlso tblDataCheckCopyNumber.Rows.Count = 1 Then
                                '    Dim strHoldingID As String = tblDataCheckCopyNumber.Rows(0).Item("ID") & ""
                                '    textQuery = "insert into Lib_tblItemLocationVANLANG(HoldingID,MaKho) values (" & strHoldingID & ",N'" & strLocation.Trim() & "')"
                                '    objBInput.ExcuteQueryByScript(textQuery)

                                '    textQuery = "insert into Lib_tblItemLoanTypeVANLANG(HoldingID,MaLoai) values (" & strHoldingID & ",N'" & strLoanType.Trim() & "')"
                                '    objBInput.ExcuteQueryByScript(textQuery)
                                'End If
                                countSusscess = countSusscess + 1
                            End If
                        End If
                    End If

                    strTitlePre = strTitle
                    strAuthorPre = strAuthor
                    strPublisherPre = strPublisher
                    strPublishYearPre = strPublishYear


                    lbSuccess.Text = "<i>Số dòng đã thực hiện thành công: </i><b><u>" & countSusscess & "</u></b>"

                    Call BindPrg(i, tbl.Rows.Count)
                Catch ex As Exception
                    listError.Add((i).ToString())
                End Try
            Next

            If listError.Count > 0 Then
                lblErrorDataCat.Text = "Những dòng không import được dữ liệu: "
                For Each item As String In listError
                    lblErrorDataCat.Text += item.ToString() + "; "
                Next
            Else
                lblErrorDataCat.Text = ""
            End If
            If listErrorDKCB.Count > 0 Then
                lblErrorItemHolding.Text = "Những dòng không import ĐKCB được: "
                For Each item As String In listErrorDKCB
                    lblErrorItemHolding.Text += item.ToString() + "; "
                Next
            Else
                lblErrorItemHolding.Text = ""
            End If
        End Sub
        Protected Sub btnUpdateLoanType_Click(sender As Object, e As EventArgs) Handles btnUpdateLoanType.Click
            Dim tbl As DataTable = ReadFileExcelToDataTable(FileUpload1)
            If Not IsNothing(tbl) AndAlso tbl.Rows.Count Then

                Dim strCopyNumber As String = ""
                Dim strLoanType As String = ""

                For i As Integer = 0 To tbl.Rows.Count - 1
                    Try
                        Dim row As DataRow = tbl.Rows(i)
                        Dim textQuery = ""

                        strCopyNumber = row.Item("SDKCaBiet") & ""                      'CopyNumber
                        strLoanType = row.Item("MaLoaiAnPham") & ""

                        If strCopyNumber = "NULL" Then strCopyNumber = ""
                        If strLoanType = "NULL" Then strLoanType = ""

                        Dim strLoanTypeReferrence As String = ReferrenceLoanTypeDHVL(strLoanType.Trim()) 'ReferrenceLoanType(strLoanType)
                        objBLoanType.LoanTypeCode = strLoanTypeReferrence
                        Dim tblLoanType As DataTable = objBLoanType.GetLoanTypesByLoanTypeCode()
                        Dim intLoanTypeID As Integer = 3
                        If Not IsNothing(tblLoanType) AndAlso tblLoanType.Rows.Count > 0 Then
                            intLoanTypeID = tblLoanType.Rows(0).Item("ID") & ""
                        End If

                        UpdateLoanType(strCopyNumber, intLoanTypeID)
                    Catch ex As Exception

                    End Try
                Next
            End If
        End Sub

    End Class
End Namespace

