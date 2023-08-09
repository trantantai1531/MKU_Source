Imports System.IO
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.WebUI.Common
Imports OfficeOpenXml

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WImportDataExcel
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Button1 As System.Web.UI.WebControls.Button


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Private variable
        Private strSeparate As String = ":::"
        Private strIDs As String
        Private strTmpFieldCode As String
        Private strTmpIndicator As String
        Private strTmpFieldValue As String
        Private strCellText As String
        Private objBInput As New clsBInput
        Private objBCatalogueForm As New clsBCatalogueForm
        Private objBItemCollection As New clsBItemCollection
        Private objBCopyNumber As New clsBCopyNumber
        Private objBLoanType As New clsBLoanType


        'B1 Import HodingNo from Fields852
        Private objBCSP As New clsBCommonStringProc
        Private objBLocation As New clsBLocation
        Private objBLibrary As New clsBLibrary
        Private objBItem As New clsBItem
        Private objBCDB As New clsBCommonDBSystem

        Private objBCatDicItemType As New clsBCatDicItemType


        Dim tblTable As DataTable
        Dim dvDefaultView As DataView
        Dim strPrefix As String = ""

        ' Private objBValidate As New clsBCataDefault
        Private objBValidate As New clsBValidate
        Private objBField As New clsBField

        Private intLibID As Integer = 0
        Private intHolID As Integer = 0

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim tblFields As DataTable
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If (Not Page.IsPostBack) Then
                BindDllItemType()
            End If
        End Sub

        Private Sub BindDllItemType()
            Dim tblResult As DataTable = objBCatDicItemType.GetAll()
            ddlFormatType.DataSource = tblResult
            ddlFormatType.DataValueField = "AccessEntry"
            ddlFormatType.DataTextField = "TypeName"
            ddlFormatType.DataBind()
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()

        End Sub

        ' BindJS method
        ' Purpose: include all neccessary javascript functions
        Private Sub BindJS()
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>", False)
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

        ' Method: CancelAction

        ' Initialize Method
        ' Popurse: Init all object using in form
        Private Sub Initialize()
            If IsNumeric(Request("Authority")) Then
                Session("IsAuthority") = CInt(Request("Authority"))
            Else
                If Not IsNumeric(Session("IsAuthority")) Then
                    Session("IsAuthority") = 0
                End If
            End If

            If Session("IsAuthority") = 1 Then
                strPrefix = "a"
            End If

            ' Init objBInput object
            objBInput.InterfaceLanguage = Session("InterfaceLanguage")
            objBInput.DBServer = Session("DBServer")
            objBInput.ConnectionString = Session("ConnectionString")
            Call objBInput.Initialize()

            ' Init objBItemCollection
            objBItemCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemCollection.DBServer = Session("DBServer")
            objBItemCollection.ConnectionString = Session("ConnectionString")
            Call objBItemCollection.Initialize()

            ' Init objBValidate object
            objBValidate.IsAuthority = Session("IsAuthority")
            objBValidate.ConnectionString = Session("ConnectionString")
            objBValidate.InterfaceLanguage = Session("InterfaceLanguage")
            objBValidate.DBServer = Session("DBServer")
            objBValidate.Separate = strSeparate
            objBValidate.Initialize()

            ' Init objBField object
            objBField.IsAuthority = Session("IsAuthority")
            objBField.ConnectionString = Session("ConnectionString")
            objBField.InterfaceLanguage = Session("InterfaceLanguage")
            objBField.DBServer = Session("DBServer")
            objBField.Initialize()


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


            ' Init objBItem object
            objBCatDicItemType.InterfaceLanguage = Session("InterfaceLanguage")
            objBCatDicItemType.DBServer = Session("DBServer")
            objBCatDicItemType.ConnectionString = Session("ConnectionString")
            Call objBCatDicItemType.Initialize()

            ' Init objBItem object
            objBCDB.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDB.DBServer = Session("DBServer")
            objBCDB.ConnectionString = Session("ConnectionString")
            Call objBCDB.Initialize()
        End Sub

        ' InsertSession method
        ' Purpose: Get content for field name, field value
        ' UpdateSession method
        ' Purpose: Get content for field name, field value if you update one field
        Sub UpdateSession(ByVal strFieldName As String, ByVal strInd As String, ByVal strFieldValueNew As String, ByVal strFieldValueOld As String, ByVal intCheckInd As Integer)
            Dim arrValues As Object = Nothing

            If intCheckInd = 1 Then
                strFieldValueNew = strInd & "::" & strFieldValueNew
            End If
            If InStr("," & Session(strPrefix & "AllFields"), "," & strFieldName & ",") > 0 Then
                Session(strPrefix & strFieldName) = Replace(Session(strPrefix & strFieldName) & "$&", strFieldValueOld & "$&", strFieldValueNew & "$&")
                Session(strPrefix & strFieldName) = Left(Session(strPrefix & strFieldName), Len(Session(strPrefix & strFieldName)) - 2)
                If Not Session(strPrefix & strFieldName) Is Nothing Then
                    If Len(CStr(Session(strPrefix & strFieldName))) > 0 Then
                        If Left(CStr(Session(strPrefix & strFieldName)), 2) = "$&" Then
                            Session(strPrefix & strFieldName) = Right(Session(strPrefix & strFieldName), Len(Session(strPrefix & strFieldName)) - 2)
                        End If
                    End If
                End If
            End If
        End Sub

        ' grdDefault_UpdateCommand event
        ' DeleteSession
        ' Purpose: Get content for field name, field value if you delete one field
        Sub DeleteSession(ByVal strFieldName As String, ByVal strFieldValue As String)
            If InStr("," & Session(strPrefix & "AllFields"), "," & strFieldName & ",") > 0 Then
                Session(strPrefix & strFieldName) = Replace(Session(strPrefix & strFieldName) & "$&", strFieldValue & "$&", "$&")
                Session(strPrefix & strFieldName) = Replace(Session(strPrefix & strFieldName), "$&$&", "$&")
                If Not Session(strPrefix & strFieldName) Is Nothing Then
                    If Len(CStr(Session(strPrefix & strFieldName))) > 0 Then
                        If Left(CStr(Session(strPrefix & strFieldName)), 2) = "$&" Then
                            Session(strPrefix & strFieldName) = Right(Session(strPrefix & strFieldName), Len(Session(strPrefix & strFieldName)) - 2)
                        End If
                        If Right(CStr(Session(strPrefix & strFieldName)), 2) = "$&" Then
                            Session(strPrefix & strFieldName) = Left(Session(strPrefix & strFieldName), Len(Session(strPrefix & strFieldName)) - 2)
                        End If
                    End If
                End If
            End If
        End Sub

        ' Page Unload Method
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Me.Dispose(True)
        End Sub

        ' Dispose Method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not objBValidate Is Nothing Then
                        objBValidate.Dispose(True)
                        objBValidate = Nothing
                    End If
                    If Not objBField Is Nothing Then
                        objBField.Dispose(True)
                        objBField = Nothing
                    End If
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        '0: ĐKCB 'Field:852
        '1: Nhan đề /
        '2: Tác giả chính 'Field: 245
        '3: Tác giả 'Field: 245 /
        '4: Nhà XB /
        '5: Nơi XB /
        '6: Năm XB /
        '7: Số trang /
        '8: Khổ /
        '9: Chủ đề /
        '10: Từ khóa /
        '11: DDC /
        '12: Cutter /
        '13: Đường dẫn file Ebook ' Field: 856
        '14: Dạng tài liệu - Sách điện tử 'Field : 927
        '15: Giá tiền 'Field : 956
        '16: HĐ 'Field : 971/

        'insert Table ITEM_FILES (ItemID : Item | FormatID : CAT_DIC_FORMAT)
        'insert Table FieldXXXS 

        'Import DataExcel

        'Protected Sub btnImportData_Click(sender As Object, e As EventArgs) Handles btnImportData.Click
        '    Try
        '        If (FileUpload1.HasFile AndAlso (IO.Path.GetExtension(FileUpload1.FileName) = ".xlsx" Or IO.Path.GetExtension(FileUpload1.FileName) = ".xls")) Then
        '            Using excel = New ExcelPackage(FileUpload1.PostedFile.InputStream)
        '                Dim tbl = New DataTable()
        '                Dim ws = excel.Workbook.Worksheets.First()
        '                Dim hasHeader = True ' change it if required '

        '                ' create DataColumns '
        '                For Each firstRowCell In ws.Cells(1, 1, 1, ws.Dimension.End.Column)
        '                    tbl.Columns.Add(If(hasHeader,
        '                                       firstRowCell.Text,
        '                                       String.Format("Column {0}", firstRowCell.Start.Column)))
        '                Next

        '                ' add rows to DataTable '
        '                Dim startRow = If(hasHeader, 2, 1)
        '                For rowNum = startRow To ws.Dimension.End.Row
        '                    Dim wsRow = ws.Cells(rowNum, 1, rowNum, ws.Dimension.End.Column)
        '                    Dim row = tbl.NewRow()
        '                    For Each cell In wsRow
        '                        row(cell.Start.Column - 1) = cell.Text
        '                    Next
        '                    tbl.Rows.Add(row)
        '                Next

        '                Dim i = 0
        '                Dim listError As New List(Of String) ' Danh sách insert ko được
        '                Dim listErrorDKCB As New List(Of String) ' Danh sách insert DKCB ko được

        '                Dim countTotalRecordInput As Integer = If(tbl.Rows.Count - 1 <= 0, 0, tbl.Rows.Count - 1) 'Tổng dòng nhập từ file excel
        '                Dim countSusscess As Integer = 0  'Tổng dòng thực hiện thành công

        '                Dim pathRoot As String = objBInput.GetValueSysByParameter("EDATA_LOCATIONS") 'Đường dẫn gốc
        '                pathRoot = pathRoot.Replace(";", "")

        '                Dim itemId As Integer = 0

        '                lbTotalInput.Text = "<i>Tổng số dòng nhập từ file Excel: </i><b><u>" & countTotalRecordInput & "</u></b>"

        '                Response.Write("<div class='lbLabel' style=' margin:0;top:250;left:0; width:100%;'>")
        '                Response.Write("<p style='position:absolute; left:45%;'>Nhập khẩu dữ liệu: <span id='pgbMain_label'>0%</span></p>")
        '                Response.Write("<p style='padding-top:35px;'><table width='0%' border=2 bordercolor='white' id='pgbMain' bgcolor=blue><tr style='HEIGHT: 18px'><td></td></tr></table></p>")
        '                Response.Write("</div>")
        '                For Each row As DataRow In tbl.Rows

        '                    If (i >= 1) And (Not row.Item("Nhan đề") Is Nothing AndAlso row.Item("Nhan đề") <> "") Then
        '                        Try
        '                            Dim textQuery = ""
        '                            Dim arrFieldName() As Object
        '                            Dim arrFieldValue() As Object
        '                            ReDim Preserve arrFieldName(18)
        '                            ReDim Preserve arrFieldValue(18)

        '                            Dim fullPath As String = ""
        '                            If Not row.Item("File") Is Nothing Then
        '                                fullPath = row.Item("File").ToString()
        '                            End If

        '                            Dim splitPath() As String = fullPath.Split(New Char() {"\"c})
        '                            Dim fileName As String = splitPath(splitPath.Length - 1)
        '                            Dim splitFileName() As String = fileName.Split(New Char() {"."c})
        '                            Dim originFile As String = splitFileName(splitFileName.Length - 1)
        '                            Dim fileSize As Integer = 0

        '                            Dim typeCodeResult As String = "SH"
        '                            If fullPath <> "" Then
        '                                typeCodeResult = "TLDT"
        '                            End If

        '                            Try
        '                                arrFieldName(0) = "000"
        '                                arrFieldValue(0) = "00025nam a2200024 a 4500"
        '                            Catch ex As Exception
        '                                arrFieldName(0) = Nothing
        '                                arrFieldValue(0) = Nothing
        '                            End Try


        '                            Try
        '                                arrFieldName(1) = "001"
        '                                arrFieldValue(1) = objBInput.Gen001(CInt(Session("IsAuthority")))
        '                            Catch ex As Exception
        '                                arrFieldName(1) = Nothing
        '                                arrFieldValue(1) = Nothing
        '                            End Try


        '                            Try
        '                                arrFieldName(2) = "040"
        '                                arrFieldValue(2) = "$aGTVT"
        '                            Catch ex As Exception
        '                                arrFieldName(2) = Nothing
        '                                arrFieldValue(2) = Nothing
        '                            End Try


        '                            Try
        '                                arrFieldName(3) = "041"
        '                                arrFieldValue(3) = "$avie"
        '                            Catch ex As Exception
        '                                arrFieldName(3) = Nothing
        '                                arrFieldValue(3) = Nothing
        '                            End Try


        '                            Try
        '                                arrFieldName(4) = "911"
        '                                arrFieldValue(4) = clsSession.GlbUserFullName
        '                            Catch ex As Exception
        '                                arrFieldName(4) = Nothing
        '                                arrFieldValue(4) = Nothing
        '                            End Try


        '                            Try
        '                                arrFieldName(5) = "925"
        '                                arrFieldValue(5) = "G"
        '                            Catch ex As Exception
        '                                arrFieldName(5) = Nothing
        '                                arrFieldValue(5) = Nothing
        '                            End Try


        '                            Try
        '                                arrFieldName(6) = "926"
        '                                arrFieldValue(6) = "0"
        '                            Catch ex As Exception
        '                                arrFieldName(6) = Nothing
        '                                arrFieldValue(6) = Nothing
        '                            End Try


        '                            Try
        '                                arrFieldName(7) = "927"
        '                                arrFieldValue(7) = typeCodeResult
        '                            Catch ex As Exception
        '                                arrFieldName(7) = Nothing
        '                                arrFieldValue(7) = Nothing
        '                            End Try


        '                            Try
        '                                arrFieldName(8) = "900"
        '                                arrFieldValue(8) = "1"
        '                            Catch ex As Exception
        '                                arrFieldName(8) = Nothing
        '                                arrFieldValue(8) = Nothing
        '                            End Try


        '                            Try
        '                                If (row.Item("Nhan đề") <> "") Then
        '                                    arrFieldName(9) = "245"
        '                                    arrFieldValue(9) = "$a" & row.Item("Nhan đề")
        '                                    If (row.Item("Tác giả chính") <> "") Then
        '                                        arrFieldName(9) = "245"
        '                                        arrFieldValue(9) = arrFieldValue(9) & " /$c" & row.Item("Tác giả chính")
        '                                    End If
        '                                End If
        '                            Catch ex As Exception
        '                                arrFieldName(9) = Nothing
        '                                arrFieldValue(9) = Nothing
        '                            End Try


        '                            Try
        '                                If (row.Item("Lần XB") <> "") Then
        '                                    arrFieldName(10) = "250"
        '                                    arrFieldValue(10) = "$a" & row.Item("Lần XB")
        '                                End If
        '                            Catch ex As Exception
        '                                arrFieldName(10) = Nothing
        '                                arrFieldValue(10) = Nothing
        '                            End Try


        '                            Try
        '                                If (row.Item("Nhà XB") <> "" Or row.Item("Nơi XB") <> "" Or row.Item("Năm XB") <> "") Then
        '                                    arrFieldName(11) = "260"
        '                                    arrFieldValue(11) = "$a" & row.Item("Nơi XB")
        '                                    If (row.Item("Nhà XB") <> "") Then
        '                                        arrFieldValue(11) = arrFieldValue(11) & " :$b" & row.Item("Nhà XB")
        '                                    End If
        '                                    If (row.Item("Năm XB") <> "") Then
        '                                        arrFieldValue(11) = arrFieldValue(11) & ",$c" & row.Item("Năm XB")
        '                                    End If
        '                                End If
        '                            Catch ex As Exception
        '                                arrFieldName(11) = Nothing
        '                                arrFieldValue(11) = Nothing
        '                            End Try


        '                            Try
        '                                If (row.Item("Số trang") <> "" Or row.Item("Khổ") <> "") Then
        '                                    arrFieldName(12) = "300"
        '                                    arrFieldValue(12) = "$a" & row.Item("Số trang")
        '                                    If (row.Item("Khổ") <> "") Then
        '                                        arrFieldValue(12) = arrFieldValue(12) & " ;$c" & row.Item("Khổ")
        '                                    End If
        '                                End If
        '                            Catch ex As Exception
        '                                arrFieldName(12) = Nothing
        '                                arrFieldValue(12) = Nothing
        '                            End Try

        '                            Try
        '                                If (row.Item("Giá tiền") <> "") Then
        '                                    arrFieldName(13) = "020"
        '                                    arrFieldValue(13) = "$c" & row.Item("Giá tiền")
        '                                End If
        '                            Catch ex As Exception
        '                                arrFieldName(13) = Nothing
        '                                arrFieldValue(13) = Nothing
        '                            End Try

        '                            Try
        '                                If (row.Item("DDC") <> "") Then
        '                                    arrFieldName(14) = "082"
        '                                    arrFieldValue(14) = "$a" & row.Item("DDC")
        '                                    If (row.Item("Nhan đề") <> "") Then
        '                                        arrFieldValue(14) = arrFieldValue(14) & " $b" & GenerateCutter(row.Item("Nhan đề").ToString()) 'row.Item("Cutter")
        '                                    End If
        '                                End If
        '                            Catch ex As Exception
        '                                arrFieldName(14) = Nothing
        '                                arrFieldValue(14) = Nothing
        '                            End Try

        '                            Try
        '                                If (row.Item("Tóm tắt") <> "") Then
        '                                    arrFieldName(15) = "520"
        '                                    arrFieldValue(15) = "$a" & row.Item("Tóm tắt")
        '                                End If
        '                            Catch ex As Exception
        '                                arrFieldName(15) = Nothing
        '                                arrFieldValue(15) = Nothing
        '                            End Try


        '                            Try
        '                                If (row.Item("Từ Khóa") <> "") Then
        '                                    arrFieldName(16) = "653"
        '                                    arrFieldValue(16) = "$a" & row.Item("Từ Khóa")
        '                                End If
        '                            Catch ex As Exception
        '                                arrFieldName(16) = Nothing
        '                                arrFieldValue(16) = Nothing
        '                            End Try

        '                            Try
        '                                If (fullPath <> "") Then
        '                                    arrFieldName(17) = "856"
        '                                    arrFieldValue(17) = "$f" & fileName 'row.Item("Đường dẫn file Ebook")
        '                                End If
        '                            Catch ex As Exception
        '                                arrFieldName(17) = Nothing
        '                                arrFieldValue(17) = Nothing
        '                            End Try


        '                            ' import to data
        '                            objBInput.FieldName = arrFieldName

        '                            objBInput.FieldValue = arrFieldValue
        '                            objBInput.LibID = clsSession.GlbSite

        '                            If Session("IsAuthority") = 1 Then
        '                                If objBInput.UpdateAuthority(4, 1) = 0 Then
        '                                End If
        '                            Else
        '                                If objBInput.Update(4, 0) = 0 Then ' 4
        '                                End If
        '                            End If

        '                            itemId = Integer.Parse(objBInput.WorkID.ToString())

        '                            'B3 Import HodingNo from Fields852
        '                            If Not itemId = 0 AndAlso row.Item("ĐKCB") <> "" Then
        '                                Call InsertHoding852(row.Item("ĐKCB").ToString(), itemId)
        '                            End If

        '                            'Update Item_File
        '                            Dim formatId = objBInput.GetFormatId(originFile)

        '                            If fullPath <> "" Then
        '                                Try
        '                                    Dim info As New FileInfo(fullPath)
        '                                    fileSize = Integer.Parse(info.Length.ToString())
        '                                Catch ex As Exception
        '                                    fileSize = 1
        '                                End Try
        '                                objBInput.QueryExcuteItemFile(itemId, fileName, fileSize, pathRoot & "\GTVT\" & fullPath, "." & originFile, formatId)
        '                                'objBInput.ExcuteQueryByScript(textQuery)
        '                            End If

        '                            countSusscess = countSusscess + 1

        '                            lbSuccess.Text = "<i>Số dòng đã thực hiện thành công: </i><b><u>" & countSusscess & "</u></b>"

        '                            Call BindPrg(i, tbl.Rows.Count)
        '                        Catch ex As Exception
        '                            listError.Add((i + 2).ToString())
        '                        End Try
        '                    End If
        '                    i = i + 1
        '                Next
        '                If listError.Count > 0 Then
        '                    lblErrorDataCat.Text = "Những dòng không import được dữ liệu: "
        '                    For Each item As String In listError
        '                        lblErrorDataCat.Text += item.ToString() + "; "
        '                    Next
        '                Else
        '                    lblErrorDataCat.Text = ""
        '                End If
        '                If listErrorDKCB.Count > 0 Then
        '                    lblErrorItemHolding.Text = "Những dòng không ĐKCB được: "
        '                    For Each item As String In listErrorDKCB
        '                        lblErrorItemHolding.Text += item.ToString() + "; "
        '                    Next
        '                Else
        '                    lblErrorItemHolding.Text = ""
        '                End If

        '            End Using
        '        Else
        '            lblErrorDataCat.Text = "File không đúng định dạng theo mẫu"
        '            lbSuccess.Text = ""
        '            lbTotalInput.Text = ""
        '            Return
        '        End If

        '    Catch ex As Exception
        '        lblErrorDataCat.Text = "File không đúng định dạng theo mẫu"
        '        lbSuccess.Text = ""
        '        lbTotalInput.Text = ""
        '    End Try
        'End Sub

        'Protected Sub btnImportData_Click(sender As Object, e As EventArgs) Handles btnImportData.Click
        '    Try
        '        If (FileUpload1.HasFile AndAlso (IO.Path.GetExtension(FileUpload1.FileName) = ".xlsx" Or IO.Path.GetExtension(FileUpload1.FileName) = ".xls")) Then
        '            Using excel = New ExcelPackage(FileUpload1.PostedFile.InputStream)
        '                Dim tbl = New DataTable()
        '                Dim ws = excel.Workbook.Worksheets.First()
        '                Dim hasHeader = True ' change it if required '

        '                ' create DataColumns '
        '                For Each firstRowCell In ws.Cells(1, 1, 1, ws.Dimension.End.Column)
        '                    tbl.Columns.Add(If(hasHeader, firstRowCell.Text, String.Format("Column {0}", firstRowCell.Start.Column)))
        '                Next

        '                ' add rows to DataTable '
        '                Dim startRow = If(hasHeader, 1, 1)
        '                For rowNum = startRow To ws.Dimension.End.Row
        '                    Dim wsRow = ws.Cells(rowNum, 1, rowNum, ws.Dimension.End.Column)
        '                    Dim row = tbl.NewRow()

        '                    Dim isAdd As Boolean = True
        '                    Dim intIndex As Integer = 0

        '                    For Each cell In wsRow
        '                        If (intIndex = 0) AndAlso (cell.Text = "") Then
        '                            isAdd = False
        '                            Exit For
        '                        Else
        '                            row(cell.Start.Column - 1) = cell.Text
        '                        End If
        '                        intIndex = intIndex + 1
        '                    Next
        '                    If isAdd Then
        '                        tbl.Rows.Add(row)
        '                    End If
        '                Next

        '                'Dim i = 0
        '                Dim listError As New List(Of String) ' Danh sách insert ko được
        '                Dim listErrorDKCB As New List(Of String) ' Danh sách insert DKCB ko được

        '                Dim countTotalRecordInput As Integer = If(tbl.Rows.Count - 1 <= 0, 0, tbl.Rows.Count - 1) 'Tổng dòng nhập từ file excel
        '                Dim countSusscess As Integer = 0  'Tổng dòng thực hiện thành công

        '                Dim pathRoot As String = objBInput.GetValueSysByParameter("EDATA_LOCATIONS") 'Đường dẫn gốc
        '                pathRoot = pathRoot.Replace(";", "")
        '                Dim libaryPath As String = objBInput.GetLibaryUrl(clsSession.GlbSite) 'Đường dẫn thư viện trường
        '                Dim itemId As Integer = 0

        '                'Dim listItemCat = objBInput.GetListItemCatType() 'Danh sách CAT_DIC_ITEM_TYPE

        '                lbTotalInput.Text = "<i>Tổng số dòng nhập từ file Excel: </i><b><u>" & countTotalRecordInput & "</u></b>"

        '                Response.Write("<div class='lbLabel' style=' margin:0;top:250;left:0; width:100%;'>")
        '                Response.Write("<p style='position:absolute; left:45%;'>Nhập khẩu dữ liệu: <span id='pgbMain_label'>0%</span></p>")
        '                Response.Write("<p style='padding-top:35px;'><table width='0%' border=2 bordercolor='white' id='pgbMain' bgcolor=blue><tr style='HEIGHT: 18px'><td></td></tr></table></p>")
        '                Response.Write("</div>")

        '                For i As Integer = 1 To tbl.Rows.Count - 1
        '                    Try
        '                        Dim row As DataRow = tbl.Rows(i)
        '                        Dim textQuery = ""
        '                        Dim arrFieldName() As Object
        '                        Dim arrFieldValue() As Object
        '                        ReDim Preserve arrFieldName(29)
        '                        ReDim Preserve arrFieldValue(29)

        '                        Try
        '                            arrFieldName(0) = "000"
        '                            arrFieldValue(0) = "00172nam a2200121 p 4500"
        '                            'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(0), itemId, 0)
        '                        Catch ex As Exception
        '                            arrFieldName(0) = Nothing
        '                            arrFieldValue(0) = Nothing
        '                        End Try


        '                        Try
        '                            arrFieldName(1) = "001"
        '                            arrFieldValue(1) = objBInput.Gen001(CInt(Session("IsAuthority")))
        '                            'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(1), itemId, 1)
        '                        Catch ex As Exception
        '                            arrFieldName(1) = Nothing
        '                            arrFieldValue(1) = Nothing
        '                        End Try


        '                        Try
        '                            arrFieldName(2) = "040"
        '                            arrFieldValue(2) = "$aDHVL"
        '                            'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(2), itemId, 40)
        '                        Catch ex As Exception
        '                            arrFieldName(2) = Nothing
        '                            arrFieldValue(2) = Nothing
        '                        End Try


        '                        Try
        '                            arrFieldName(3) = Nothing
        '                            arrFieldValue(3) = Nothing
        '                        Catch ex As Exception
        '                            arrFieldName(3) = Nothing
        '                            arrFieldValue(3) = Nothing
        '                        End Try


        '                        Try
        '                            arrFieldName(4) = "911"
        '                            arrFieldValue(4) = clsSession.GlbUserFullName
        '                            'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField900S", arrFieldValue(4), itemId, 911)
        '                        Catch ex As Exception
        '                            arrFieldName(4) = Nothing
        '                            arrFieldValue(4) = Nothing
        '                        End Try


        '                        Try
        '                            arrFieldName(5) = "925"
        '                            arrFieldValue(5) = "G"
        '                            'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField900S", arrFieldValue(5), itemId, 925)
        '                        Catch ex As Exception
        '                            arrFieldName(5) = Nothing
        '                            arrFieldValue(5) = Nothing
        '                        End Try


        '                        Try
        '                            arrFieldName(6) = "926"
        '                            arrFieldValue(6) = "0"
        '                            'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField900S", arrFieldValue(6), itemId, 926)
        '                        Catch ex As Exception
        '                            arrFieldName(6) = Nothing
        '                            arrFieldValue(6) = Nothing
        '                        End Try


        '                        Try
        '                            arrFieldName(7) = "927"
        '                            'arrFieldValue(7) = "LA"
        '                            arrFieldValue(7) = ddlFormatType.SelectedItem.Value
        '                            'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField900S", arrFieldValue(7), itemId, 927)
        '                        Catch ex As Exception
        '                            arrFieldName(7) = Nothing
        '                            arrFieldValue(7) = Nothing
        '                        End Try



        '                        Try
        '                            arrFieldName(8) = "900"
        '                            arrFieldValue(8) = "1"
        '                            'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField900S", arrFieldValue(8), itemId, 900)
        '                        Catch ex As Exception
        '                            arrFieldName(8) = Nothing
        '                            arrFieldValue(8) = Nothing
        '                        End Try

        '                        'Try
        '                        '    arrFieldName(9) = Nothing
        '                        '    arrFieldValue(9) = Nothing
        '                        '    If (Not CheckExistColumn("852", tbl)) Then
        '                        '        If (Not CheckExistColumn("852$j", tbl)) Then
        '                        '            arrFieldName(9) = "852"
        '                        '            arrFieldValue(9) = "$j" & row.Item("852$j")
        '                        '        End If
        '                        '        'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField800S", arrFieldValue(9), itemId, 852)
        '                        '    End If
        '                        'Catch ex As Exception
        '                        '    arrFieldName(9) = Nothing
        '                        '    arrFieldValue(9) = Nothing
        '                        'End Try

        '                        Try
        '                            arrFieldName(9) = Nothing
        '                            arrFieldValue(9) = Nothing
        '                            If (CheckExistColumn("856", tbl)) Then
        '                                If (CheckExistColumn("856$f", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("856$f") & ""))) Then
        '                                    arrFieldName(9) = "856"
        '                                    arrFieldValue(9) = "$f" & row.Item("856$f")
        '                                End If
        '                                'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField800S", arrFieldValue(9), itemId, 852)
        '                            End If
        '                        Catch ex As Exception
        '                            arrFieldName(9) = Nothing
        '                            arrFieldValue(9) = Nothing
        '                        End Try

        '                        '020$a
        '                        '020$c
        '                        '----- 020$aTho $cVu
        '                        Try
        '                            arrFieldName(10) = Nothing
        '                            arrFieldValue(10) = Nothing
        '                            If (CheckExistColumn("020", tbl)) Then
        '                                If (CheckExistColumn("020$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("020$a") & ""))) Then
        '                                    arrFieldName(10) = "020"
        '                                    arrFieldValue(10) = arrFieldValue(10) & "" & "$a" & row.Item("020$a")
        '                                    arrFieldValue(10) = arrFieldValue(10).ToString.Trim()
        '                                End If
        '                                If (CheckExistColumn("020$c", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("020$c") & ""))) Then
        '                                    arrFieldName(10) = "020"
        '                                    arrFieldValue(10) = arrFieldValue(10) & "" & " $c" & row.Item("020$c")
        '                                    arrFieldValue(10) = arrFieldValue(10).ToString.Trim()
        '                                End If
        '                                'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(10), itemId, 20)
        '                            End If
        '                        Catch ex As Exception
        '                            arrFieldName(10) = Nothing
        '                            arrFieldValue(10) = Nothing
        '                        End Try

        '                        '041$a
        '                        Try
        '                            arrFieldName(11) = Nothing
        '                            arrFieldValue(11) = Nothing
        '                            If (CheckExistColumn("041", tbl)) Then
        '                                If (CheckExistColumn("041$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("041$a") & ""))) Then
        '                                    arrFieldName(11) = "041"
        '                                    arrFieldValue(11) = "$a" & row.Item("041$a")
        '                                    'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
        '                                End If
        '                            End If
        '                        Catch ex As Exception
        '                            arrFieldName(11) = Nothing
        '                            arrFieldValue(11) = Nothing
        '                        End Try

        '                        '082$2	
        '                        '082$a	
        '                        '082$b	
        '                        '082$c	
        '                        '------- 082$2Tho $aVu $bSon $cPhuong
        '                        Try
        '                            arrFieldName(12) = Nothing
        '                            arrFieldValue(12) = Nothing
        '                            If (CheckExistColumn("082", tbl)) Then
        '                                If (CheckExistColumn("082$2", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("082$2") & ""))) Then
        '                                    arrFieldName(12) = "082"
        '                                    arrFieldValue(12) = arrFieldValue(12) & "" & "$2" & row.Item("082$2")
        '                                    arrFieldValue(12) = arrFieldValue(12).ToString.Trim()
        '                                    'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
        '                                End If

        '                                If (CheckExistColumn("082$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("082$a") & ""))) Then
        '                                    arrFieldName(12) = "082"
        '                                    arrFieldValue(12) = arrFieldValue(12) & "" & "$a" & row.Item("082$a")
        '                                    arrFieldValue(12) = arrFieldValue(12).ToString.Trim()
        '                                    'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
        '                                End If

        '                                If (CheckExistColumn("082$b", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("082$b") & ""))) Then
        '                                    arrFieldName(12) = "082"
        '                                    arrFieldValue(12) = arrFieldValue(12) & "" & "$b" & row.Item("082$b")
        '                                    arrFieldValue(12) = arrFieldValue(12).ToString.Trim()
        '                                    'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
        '                                End If

        '                                If (CheckExistColumn("082$c", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("082$c") & ""))) Then
        '                                    arrFieldName(12) = "082"
        '                                    arrFieldValue(12) = arrFieldValue(12) & "" & "$c" & row.Item("082$c")
        '                                    arrFieldValue(12) = arrFieldValue(12).ToString.Trim()
        '                                    'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
        '                                End If
        '                            End If

        '                        Catch ex As Exception
        '                            arrFieldName(12) = Nothing
        '                            arrFieldValue(12) = Nothing
        '                        End Try

        '                        '100$a	
        '                        '100$c	
        '                        '100$e
        '                        '------ 100$aTho, $cVu $eSon
        '                        Try
        '                            arrFieldName(13) = Nothing
        '                            arrFieldValue(13) = Nothing
        '                            If (CheckExistColumn("100", tbl)) Then

        '                                If (CheckExistColumn("100$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("100$a") & ""))) Then
        '                                    arrFieldName(13) = "100"
        '                                    arrFieldValue(13) = arrFieldValue(13) & "" & "$a" & row.Item("100$a")
        '                                    arrFieldValue(13) = arrFieldValue(13).ToString.Trim()
        '                                    'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
        '                                End If

        '                                If (CheckExistColumn("100$c", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("100$c") & ""))) Then
        '                                    arrFieldName(13) = "100"
        '                                    If (Not IsNothing(arrFieldValue(13))) Then
        '                                        arrFieldValue(13) = arrFieldValue(13) & "" & ", $c" & row.Item("100$c")
        '                                    Else
        '                                        arrFieldValue(13) = arrFieldValue(13) & "" & " $c" & row.Item("100$c")
        '                                    End If
        '                                    arrFieldValue(13) = arrFieldValue(13).ToString.Trim()
        '                                    'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
        '                                End If

        '                                If (CheckExistColumn("100$e", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("100$e") & ""))) Then
        '                                    arrFieldName(13) = "100"
        '                                    arrFieldValue(13) = arrFieldValue(13) & "" & " $e" & row.Item("100$e")
        '                                    arrFieldValue(13) = arrFieldValue(13).ToString.Trim()
        '                                    'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
        '                                End If
        '                            End If

        '                        Catch ex As Exception
        '                            arrFieldName(13) = Nothing
        '                            arrFieldValue(13) = Nothing
        '                        End Try

        '                        '110$a	
        '                        '110$b	
        '                        '------ 110$aTho, $bVu
        '                        Try

        '                            arrFieldName(14) = Nothing
        '                            arrFieldValue(14) = Nothing
        '                            If (CheckExistColumn("110", tbl)) Then

        '                                If (CheckExistColumn("110$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("110$a") & ""))) Then
        '                                    arrFieldName(14) = "110"
        '                                    arrFieldValue(14) = arrFieldValue(14) & "" & "$a" & row.Item("110$a")
        '                                    arrFieldValue(14) = arrFieldValue(14).ToString.Trim()
        '                                    'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
        '                                End If

        '                                If (CheckExistColumn("110$b", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("110$b") & ""))) Then
        '                                    arrFieldName(14) = "110"
        '                                    If (Not IsNothing(arrFieldValue(14))) Then
        '                                        arrFieldValue(14) = arrFieldValue(14) & "" & ", $c" & row.Item("110$b")
        '                                    Else
        '                                        arrFieldValue(14) = arrFieldValue(14) & "" & " $c" & row.Item("110$b")
        '                                    End If
        '                                    arrFieldValue(14) = arrFieldValue(14).ToString.Trim()
        '                                    'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
        '                                End If

        '                            End If

        '                        Catch ex As Exception
        '                            arrFieldName(14) = Nothing
        '                            arrFieldValue(14) = Nothing
        '                        End Try

        '                        '245$a	
        '                        '245$b	
        '                        '245$c	
        '                        '245$n	
        '                        '245$p	
        '                        '------ 245$aTho: $bVu. $nSon, $pPhuong/ $cQuoc
        '                        Try

        '                            arrFieldName(15) = Nothing
        '                            arrFieldValue(15) = Nothing
        '                            If (CheckExistColumn("245", tbl)) Then

        '                                If (CheckExistColumn("245$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("245$a") & ""))) Then
        '                                    arrFieldName(15) = "245"
        '                                    arrFieldValue(15) = arrFieldValue(15) & "" & "$a" & row.Item("245$a")
        '                                    arrFieldValue(15) = arrFieldValue(15).ToString.Trim()
        '                                    'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
        '                                End If

        '                                If (CheckExistColumn("245$b", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("245$b") & ""))) Then
        '                                    arrFieldName(15) = "245"
        '                                    If (Not IsNothing(arrFieldValue(15))) Then
        '                                        arrFieldValue(15) = arrFieldValue(15) & "" & ": $b" & row.Item("245$b")
        '                                    Else
        '                                        arrFieldValue(15) = arrFieldValue(15) & "" & " $b" & row.Item("245$b")
        '                                    End If
        '                                    arrFieldValue(15) = arrFieldValue(15).ToString.Trim()
        '                                    'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
        '                                End If

        '                                If (CheckExistColumn("245$n", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("245$n") & ""))) Then
        '                                    arrFieldName(15) = "245"
        '                                    If (Not IsNothing(arrFieldValue(15))) Then
        '                                        arrFieldValue(15) = arrFieldValue(15) & "" & ". $n" & row.Item("245$n")
        '                                    Else
        '                                        arrFieldValue(15) = arrFieldValue(15) & "" & " $n" & row.Item("245$n")
        '                                    End If
        '                                    arrFieldValue(15) = arrFieldValue(15).ToString.Trim()
        '                                    'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
        '                                End If

        '                                If (CheckExistColumn("245$p", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("245$p") & ""))) Then
        '                                    arrFieldName(15) = "245"
        '                                    If (Not IsNothing(arrFieldValue(15))) Then
        '                                        arrFieldValue(15) = arrFieldValue(15) & "" & ", $p" & row.Item("245$p")
        '                                    Else
        '                                        arrFieldValue(15) = arrFieldValue(15) & "" & " $p" & row.Item("245$p")
        '                                    End If
        '                                    arrFieldValue(15) = arrFieldValue(15).ToString.Trim()
        '                                    'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
        '                                End If

        '                                If (CheckExistColumn("245$c", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("245$c") & ""))) Then
        '                                    arrFieldName(15) = "245"
        '                                    If (Not IsNothing(arrFieldValue(15))) Then
        '                                        arrFieldValue(15) = arrFieldValue(15) & "" & "/ $c" & row.Item("245$c")
        '                                        If (CheckExistColumn("700$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("700$a") & ""))) Then
        '                                            arrFieldValue(15) = arrFieldValue(15) & "; " & row.Item("700$a")
        '                                        End If
        '                                    Else
        '                                        arrFieldValue(15) = arrFieldValue(15) & "" & " $c" & row.Item("245$c")
        '                                        If (CheckExistColumn("700$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("700$a") & ""))) Then
        '                                            arrFieldValue(15) = arrFieldValue(15) & "; " & row.Item("700$a")
        '                                        End If
        '                                    End If
        '                                    arrFieldValue(15) = arrFieldValue(15).ToString.Trim()
        '                                    'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
        '                                Else
        '                                    If (CheckExistColumn("700$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("700$a") & ""))) Then
        '                                        arrFieldName(15) = "245"
        '                                        If (Not IsNothing(arrFieldValue(15))) Then
        '                                            arrFieldValue(15) = arrFieldValue(15) & "/ $c" & row.Item("700$a")
        '                                        Else
        '                                            arrFieldValue(15) = arrFieldValue(15) & " $c" & row.Item("700$a")
        '                                        End If
        '                                        arrFieldValue(15) = arrFieldValue(15).ToString.Trim()
        '                                    End If
        '                                End If

        '                            End If


        '                        Catch ex As Exception
        '                            arrFieldName(15) = Nothing
        '                            arrFieldValue(15) = Nothing
        '                        End Try

        '                        '246$a	
        '                        '246$b
        '                        '------ 246$aTho, $bVu
        '                        Try
        '                            arrFieldName(16) = Nothing
        '                            arrFieldValue(16) = Nothing
        '                            If (CheckExistColumn("246", tbl)) Then

        '                                If (CheckExistColumn("246$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("246$a") & ""))) Then
        '                                    arrFieldName(16) = "246"
        '                                    arrFieldValue(16) = arrFieldValue(16) & "" & "$a" & row.Item("246$a")
        '                                    arrFieldValue(16) = arrFieldValue(16).ToString.Trim()
        '                                    'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
        '                                End If

        '                                If (CheckExistColumn("246$b", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("246$b") & ""))) Then
        '                                    arrFieldName(16) = "246"
        '                                    If (Not IsNothing(arrFieldValue(16))) Then
        '                                        arrFieldValue(16) = arrFieldValue(16) & "" & ", $c" & row.Item("246$b")
        '                                    Else
        '                                        arrFieldValue(16) = arrFieldValue(16) & "" & " $c" & row.Item("246$b")
        '                                    End If
        '                                    arrFieldValue(16) = arrFieldValue(16).ToString.Trim()
        '                                    'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
        '                                End If

        '                            End If

        '                        Catch ex As Exception
        '                            arrFieldName(16) = Nothing
        '                            arrFieldValue(16) = Nothing
        '                        End Try

        '                        '250$a
        '                        Try
        '                            arrFieldName(17) = Nothing
        '                            arrFieldValue(17) = Nothing
        '                            If (CheckExistColumn("250", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("250$a") & ""))) Then
        '                                If (CheckExistColumn("250$a", tbl)) Then
        '                                    arrFieldName(17) = "250"
        '                                    arrFieldValue(17) = "$a" & row.Item("250$a")
        '                                End If
        '                            End If
        '                        Catch ex As Exception
        '                            arrFieldName(17) = Nothing
        '                            arrFieldValue(17) = Nothing
        '                        End Try

        '                        '260$a	
        '                        '260$b	
        '                        '260$c	
        '                        '------ 260$aTho: $bVu, $cSon
        '                        Try
        '                            arrFieldName(18) = Nothing
        '                            arrFieldValue(18) = Nothing
        '                            If (CheckExistColumn("260", tbl)) Then

        '                                If (CheckExistColumn("260$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("260$a") & ""))) Then
        '                                    arrFieldName(18) = "260"
        '                                    arrFieldValue(18) = arrFieldValue(18) & "" & "$a" & row.Item("260$a")
        '                                    arrFieldValue(18) = arrFieldValue(18).ToString.Trim()
        '                                    'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
        '                                End If

        '                                If (CheckExistColumn("260$b", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("260$b") & ""))) Then
        '                                    arrFieldName(18) = "260"
        '                                    If (Not IsNothing(arrFieldValue(18))) Then
        '                                        arrFieldValue(18) = arrFieldValue(18) & "" & ": $b" & row.Item("260$b")
        '                                    Else
        '                                        arrFieldValue(18) = arrFieldValue(18) & "" & " $b" & row.Item("260$b")
        '                                    End If
        '                                    arrFieldValue(18) = arrFieldValue(18).ToString.Trim()
        '                                    'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
        '                                End If

        '                                If (CheckExistColumn("260$c", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("260$c") & ""))) Then
        '                                    arrFieldName(18) = "260"
        '                                    If (Not IsNothing(arrFieldValue(18))) Then
        '                                        arrFieldValue(18) = arrFieldValue(18) & "" & ", $c" & row.Item("260$c")
        '                                    Else
        '                                        arrFieldValue(18) = arrFieldValue(18) & "" & " $c" & row.Item("260$c")
        '                                    End If
        '                                    arrFieldValue(18) = arrFieldValue(18).ToString.Trim()
        '                                    'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
        '                                End If
        '                            End If

        '                        Catch ex As Exception
        '                            arrFieldName(18) = Nothing
        '                            arrFieldValue(18) = Nothing
        '                        End Try

        '                        '300$a	
        '                        '300$b	
        '                        '300$c	
        '                        '300$e
        '                        '------ 300$aTho: $bVu; $cSon+ $ePhuong
        '                        Try
        '                            arrFieldName(19) = Nothing
        '                            arrFieldValue(19) = Nothing
        '                            If (CheckExistColumn("300", tbl)) Then

        '                                If (CheckExistColumn("300$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("300$a") & ""))) Then
        '                                    arrFieldName(19) = "300"
        '                                    arrFieldValue(19) = arrFieldValue(19) & "" & "$a" & row.Item("300$a")
        '                                    arrFieldValue(19) = arrFieldValue(19).ToString.Trim()
        '                                    'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
        '                                End If

        '                                If (CheckExistColumn("300$b", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("300$b") & ""))) Then
        '                                    arrFieldName(19) = "300"
        '                                    If (Not IsNothing(arrFieldValue(19))) Then
        '                                        arrFieldValue(19) = arrFieldValue(19) & "" & ": $b" & row.Item("300$b")
        '                                    Else
        '                                        arrFieldValue(19) = arrFieldValue(19) & "" & " $b" & row.Item("300$b")
        '                                    End If
        '                                    arrFieldValue(19) = arrFieldValue(19).ToString.Trim()
        '                                    'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
        '                                End If

        '                                If (CheckExistColumn("300$c", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("300$c") & ""))) Then
        '                                    arrFieldName(19) = "300"
        '                                    If (Not IsNothing(arrFieldValue(18))) Then
        '                                        arrFieldValue(19) = arrFieldValue(19) & "" & ", $c" & row.Item("300$c")
        '                                    Else
        '                                        arrFieldValue(19) = arrFieldValue(19) & "" & " $c" & row.Item("300$c")
        '                                    End If
        '                                    arrFieldValue(19) = arrFieldValue(19).ToString.Trim()
        '                                    'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
        '                                End If

        '                                If (CheckExistColumn("300$e", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("300$e") & ""))) Then
        '                                    arrFieldName(19) = "300"
        '                                    If (Not IsNothing(arrFieldValue(18))) Then
        '                                        arrFieldValue(19) = arrFieldValue(19) & "" & "= $e" & row.Item("300$e")
        '                                    Else
        '                                        arrFieldValue(19) = arrFieldValue(19) & "" & " $e" & row.Item("300$e")
        '                                    End If
        '                                    arrFieldValue(19) = arrFieldValue(19).ToString.Trim()
        '                                    'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
        '                                End If
        '                            End If

        '                        Catch ex As Exception
        '                            arrFieldName(19) = Nothing
        '                            arrFieldValue(19) = Nothing
        '                        End Try

        '                        '440$a
        '                        Try
        '                            arrFieldName(20) = Nothing
        '                            arrFieldValue(20) = Nothing
        '                            If (CheckExistColumn("440", tbl)) Then
        '                                If (CheckExistColumn("440$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("440$a") & ""))) Then
        '                                    arrFieldName(20) = "440"
        '                                    arrFieldValue(20) = "$a" & row.Item("440$a")
        '                                End If

        '                            End If
        '                        Catch ex As Exception
        '                            arrFieldName(20) = Nothing
        '                            arrFieldValue(20) = Nothing
        '                        End Try

        '                        '490$a	
        '                        Try
        '                            arrFieldName(21) = Nothing
        '                            arrFieldValue(21) = Nothing
        '                            If (CheckExistColumn("490", tbl)) Then
        '                                If (CheckExistColumn("490$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("490$a") & ""))) Then
        '                                    arrFieldName(21) = "490"
        '                                    arrFieldValue(21) = "$a" & row.Item("490$a")
        '                                End If

        '                            End If
        '                        Catch ex As Exception
        '                            arrFieldName(21) = Nothing
        '                            arrFieldValue(21) = Nothing
        '                        End Try

        '                        '500$a	
        '                        Try
        '                            arrFieldName(22) = Nothing
        '                            arrFieldValue(22) = Nothing
        '                            If (CheckExistColumn("500", tbl)) Then
        '                                If (CheckExistColumn("500$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("500$a") & ""))) Then
        '                                    arrFieldName(22) = "500"
        '                                    arrFieldValue(22) = "$a" & row.Item("500$a")
        '                                End If

        '                            End If

        '                        Catch ex As Exception
        '                            arrFieldName(22) = Nothing
        '                            arrFieldValue(22) = Nothing
        '                        End Try

        '                        '520$a	
        '                        Try
        '                            arrFieldName(23) = Nothing
        '                            arrFieldValue(23) = Nothing
        '                            If (CheckExistColumn("520", tbl)) Then
        '                                If (CheckExistColumn("520$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("520$a") & ""))) Then
        '                                    arrFieldName(23) = "520"
        '                                    arrFieldValue(23) = "$a" & row.Item("520$a")
        '                                End If

        '                            End If

        '                        Catch ex As Exception
        '                            arrFieldName(23) = Nothing
        '                            arrFieldValue(23) = Nothing
        '                        End Try

        '                        '650$2	
        '                        '650$a	
        '                        '------ $650$2Tho, $aVu
        '                        Try
        '                            arrFieldName(24) = Nothing
        '                            arrFieldValue(24) = Nothing
        '                            If (CheckExistColumn("650", tbl)) Then

        '                                If (CheckExistColumn("650$2", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("650$2") & ""))) Then
        '                                    arrFieldName(24) = "650"
        '                                    arrFieldValue(24) = arrFieldValue(24) & "" & "$2" & row.Item("650$2")
        '                                    arrFieldValue(24) = arrFieldValue(24).ToString.Trim()
        '                                    'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
        '                                End If

        '                                If (CheckExistColumn("650$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("650$a") & ""))) Then
        '                                    arrFieldName(24) = "650"
        '                                    If (Not IsNothing(arrFieldValue(24))) Then
        '                                        arrFieldValue(24) = arrFieldValue(24) & "" & ", $a" & row.Item("650$a")
        '                                    Else
        '                                        arrFieldValue(24) = arrFieldValue(24) & "" & " $a" & row.Item("650$a")
        '                                    End If
        '                                    arrFieldValue(24) = arrFieldValue(24).ToString.Trim()
        '                                    'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
        '                                End If

        '                            End If

        '                        Catch ex As Exception
        '                            arrFieldName(24) = Nothing
        '                            arrFieldValue(24) = Nothing
        '                        End Try

        '                        '653$a	
        '                        Try
        '                            arrFieldName(25) = Nothing
        '                            arrFieldValue(25) = Nothing
        '                            If (CheckExistColumn("653", tbl)) Then
        '                                If (CheckExistColumn("653$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("653$a") & ""))) Then
        '                                    arrFieldName(25) = "653"
        '                                    arrFieldValue(25) = "$a" & row.Item("653$a")
        '                                End If

        '                            End If

        '                        Catch ex As Exception
        '                            arrFieldName(25) = Nothing
        '                            arrFieldValue(25) = Nothing
        '                        End Try

        '                        '655$a	
        '                        Try
        '                            arrFieldName(26) = Nothing
        '                            arrFieldValue(26) = Nothing
        '                            If (CheckExistColumn("655", tbl)) Then
        '                                If (CheckExistColumn("655$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("655$a") & ""))) Then
        '                                    arrFieldName(26) = "655"
        '                                    arrFieldValue(26) = "$a" & row.Item("655$a")
        '                                End If

        '                            End If

        '                        Catch ex As Exception
        '                            arrFieldName(26) = Nothing
        '                            arrFieldValue(26) = Nothing
        '                        End Try

        '                        '700$a	
        '                        '700$c	
        '                        '700$e	
        '                        '------ 700$aTho $cVu $eSon
        '                        Try
        '                            arrFieldName(27) = Nothing
        '                            arrFieldValue(27) = Nothing
        '                            If (CheckExistColumn("700", tbl)) Then
        '                                If (CheckExistColumn("700$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("700$a") & ""))) Then
        '                                    arrFieldName(27) = "700"
        '                                    arrFieldValue(27) = arrFieldValue(27) & "" & "$a" & row.Item("700$a")
        '                                    arrFieldValue(27) = arrFieldValue(27).ToString.Trim()
        '                                    'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
        '                                End If

        '                                If (CheckExistColumn("700$c", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("700$c") & ""))) Then
        '                                    arrFieldName(27) = "700"
        '                                    arrFieldValue(27) = arrFieldValue(27) & "" & "$c" & row.Item("700$c")
        '                                    arrFieldValue(27) = arrFieldValue(27).ToString.Trim()
        '                                    'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
        '                                End If

        '                                If (CheckExistColumn("700$e", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("700$e") & ""))) Then
        '                                    arrFieldName(27) = "700"
        '                                    arrFieldValue(27) = arrFieldValue(27) & "" & "$e" & row.Item("700$e")
        '                                    arrFieldValue(27) = arrFieldValue(27).ToString.Trim()
        '                                    'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
        '                                End If
        '                            End If

        '                        Catch ex As Exception
        '                            arrFieldName(27) = Nothing
        '                            arrFieldValue(27) = Nothing
        '                        End Try

        '                        '710$a
        '                        Try
        '                            arrFieldName(28) = Nothing
        '                            arrFieldValue(28) = Nothing
        '                            If (CheckExistColumn("710", tbl)) Then
        '                                If (CheckExistColumn("710$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("710$a") & ""))) Then
        '                                    arrFieldName(28) = "710"
        '                                    arrFieldValue(28) = "$a" & row.Item("710$a")
        '                                End If

        '                            End If

        '                        Catch ex As Exception
        '                            arrFieldName(28) = Nothing
        '                            arrFieldValue(28) = Nothing
        '                        End Try

        '                        ' import to data
        '                        objBInput.FieldName = arrFieldName

        '                        objBInput.FieldValue = arrFieldValue
        '                        objBInput.LibID = clsSession.GlbSite

        '                        If Session("IsAuthority") = 1 Then
        '                            If objBInput.UpdateAuthority(4, 1) = 0 Then
        '                            End If
        '                        Else
        '                            If objBInput.Update(4, 0) = 0 Then ' 4
        '                            End If
        '                        End If


        '                        If (CheckExistColumn("856$f", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("856$f") & ""))) Then
        '                            'Update Item_File
        '                            itemId = Integer.Parse(objBInput.WorkID.ToString())
        '                            Dim valueColumn As String = row.Item("856$f")
        '                            Dim extensionFile As String = valueColumn.Substring(valueColumn.Length - 3)
        '                            Dim formatId = objBInput.GetFormatId(extensionFile)
        '                            If (formatId <> 0) Then
        '                                objBInput.QueryExcuteItemFile(itemId, "", 0, "", "", formatId)
        '                            End If

        '                        End If


        '                        'objBInput.ExcuteQueryByScript(textQuery)

        '                        countSusscess = countSusscess + 1

        '                        lbSuccess.Text = "<i>Số dòng đã thực hiện thành công: </i><b><u>" & countSusscess & "</u></b>"

        '                        Call BindPrg(i, tbl.Rows.Count)

        '                    Catch ex As Exception
        '                        listError.Add((i).ToString())
        '                    End Try

        '                Next

        '                If listError.Count > 0 Then
        '                    lblErrorDataCat.Text = "Những dòng không import được dữ liệu: "
        '                    For Each item As String In listError
        '                        lblErrorDataCat.Text += item.ToString() + "; "
        '                    Next
        '                Else
        '                    lblErrorDataCat.Text = ""
        '                End If
        '                If listErrorDKCB.Count > 0 Then
        '                    lblErrorItemHolding.Text = "Những dòng không ĐKCB được: "
        '                    For Each item As String In listErrorDKCB
        '                        lblErrorItemHolding.Text += item.ToString() + "; "
        '                    Next
        '                Else
        '                    lblErrorItemHolding.Text = ""
        '                End If

        '            End Using
        '        Else
        '            lblErrorDataCat.Text = "File không đúng định dạng theo mẫu"
        '            lbSuccess.Text = ""
        '            lbTotalInput.Text = ""
        '            Return
        '        End If

        '        objBInput.CloseConnection()

        '    Catch ex As Exception
        '        lblErrorDataCat.Text = "File không đúng định dạng theo mẫu"
        '        lbSuccess.Text = ""
        '        lbTotalInput.Text = ""
        '        objBInput.CloseConnection()
        '    End Try
        'End Sub

        Protected Sub btnImportData_Click(sender As Object, e As EventArgs) Handles btnImportData.Click
            Dim tbl As DataTable = ReadUploadFile(FileUpload1)
            If Not IsNothing(tbl) AndAlso tbl.Rows.Count Then
                Call ImportData(tbl)
            End If
        End Sub

        Private Function ReadUploadFile(ByVal fileUploadInput As FileUpload) As DataTable
            If fileUploadInput.FileName.Trim().ToLower().EndsWith(".mrc") Then
                Return ReadFileMrcToDataTable(fileUploadInput)
            Else
                Return ReadFileExcelToDataTable(fileUploadInput)
            End If
        End Function

        Private Function ReadFileMrcToDataTable(ByVal fileUploadInput As FileUpload) As DataTable
            Dim tbl As DataTable = Nothing
            Return tbl
        End Function


        'Private Sub ImportData(ByVal tbl As DataTable)
        '    Dim listError As New List(Of String) ' Danh sách insert ko được
        '    Dim listErrorDKCB As New List(Of String) ' Danh sách insert DKCB ko được

        '    Dim countTotalRecordInput As Integer = If(tbl.Rows.Count <= 0, 0, tbl.Rows.Count) 'Tổng dòng nhập từ file excel
        '    Dim countSusscess As Integer = 0  'Tổng dòng thực hiện thành công

        '    Dim itemId As Integer = 0

        '    lbTotalInput.Text = "<i>Tổng số dòng nhập từ file Excel: </i><b><u>" & countTotalRecordInput & "</u></b>"

        '    Response.Write("<div class='lbLabel' style=' margin:0;top:250;left:0; width:100%;'>")
        '    Response.Write("<p style='position:absolute; left:45%;'>Nhập khẩu dữ liệu: <span id='pgbMain_label'>0%</span></p>")
        '    Response.Write("<p style='padding-top:35px;'><table width='0%' border=2 bordercolor='white' id='pgbMain' bgcolor=blue><tr style='HEIGHT: 18px'><td></td></tr></table></p>")
        '    Response.Write("</div>")

        '    Dim strDollarSplit As String = "$"

        '    Dim strTitle As String = ""
        '    Dim strTitlePre As String = ""
        '    Dim strCopyNumber As String = ""
        '    Dim strBarCode As String = ""
        '    Dim strLocation As String = ""
        '    Dim strAuthor As String = ""
        '    Dim strItemSH As String = ""
        '    Dim strDescription As String = ""
        '    Dim strPublisher As String = ""
        '    Dim strPublishYear As String = ""
        '    Dim strAuthorOther As String = ""
        '    Dim strPhysical As String = ""
        '    Dim strDocumentFormat As String = ""
        '    Dim strSource As String = ""
        '    Dim strLanguage As String = ""
        '    Dim strStatusCode As String = ""
        '    Dim strStatusNote As String = ""
        '    Dim strDateCreate As String = ""
        '    Dim strDateUpdate As String = ""
        '    Dim strCataloguer As String = ""
        '    Dim strCataloguerUpdate As String = ""
        '    Dim strItemType As String = ""
        '    Dim strNumberCopies As String = ""
        '    Dim strPrice As String = "0"
        '    Dim strLoanType As String = ""
        '    Dim listColumn650a As New List(Of String)
        '    Dim listColumn700a As New List(Of String)


        '    For i As Integer = 0 To tbl.Rows.Count - 1
        '        Try
        '            Dim row As DataRow = tbl.Rows(i)
        '            Dim textQuery = ""

        '            strCopyNumber = row.Item("SDKCaBiet") & ""                      'CopyNumber
        '            strBarCode = row.Item("MaVach") & ""                            'BarCode
        '            strLocation = row.Item("MaKho") & ""                            'Location
        '            strTitle = row.Item("NhanDeChinh") & ""                         'Nhan de / $a:245$a; $b:245$b ; $e:NumberCopies
        '            strAuthor = row.Item("TacGia") & ""                             'Tac gia / $a:100$a
        '            strItemSH = row.Item("DeMuc") & ""                              'De muc / $a:082$a ; $b:082$b ; $c:650$a 
        '            strDescription = row.Item("MoTa") & ""                          'Mo ta / $a:520$a
        '            strPublisher = row.Item("XuatBan") & ""                         'Xuat ban / $a:250$a ; $c:260$a ; $d:260$b; 
        '            strPublishYear = row.Item("NgayThang") & ""                     'Ngay thang / $a:260$c (bỏ : và khoảng trắng)
        '            strAuthorOther = row.Item("TacGiaPhu") & ""                     'Tac gia phu / $a:700$a
        '            strPhysical = row.Item("MoTaVatLy") & ""                        'Mo ta vat ly / $a:300$a ; $b:300$b ; $c:300$c ; $d:300$e ; $e:Price
        '            strDocumentFormat = row.Item("DinhDanhTuLieu") & ""             'Dinh dang tai lieu / $a:020$a (bỏ gạch ngang, khoảng trắng)
        '            strSource = row.Item("NguonGoc") & ""                           'Nguon goc / $a:040$a
        '            strLanguage = row.Item("NgonNgu") & ""                          'Ngon ngu / $a:041$a
        '            strStatusCode = row.Item("MaTinhTrang") & ""                    'StatusCode
        '            strStatusNote = row.Item("GhiChuTinhTrang") & ""                'StatusNote
        '            strDateCreate = row.Item("NgayTao") & ""                        'CreateDate - Item ; DateCreate - Holding
        '            strDateUpdate = row.Item("NgayCapNhat") & ""                    'UpdateDate - Item ; DateUpdate - Holding
        '            strCataloguer = row.Item("NhanVienTao") & ""                    'Cataloguer - Item ; NameCreate - Holding
        '            strCataloguerUpdate = row.Item("NhanVienCapNhat") & ""          'CataloguerUpdate - Item ; NameUpdate - Holding
        '            strItemType = row.Item("MaLoaiAnPham") & ""                     'ItemType
        '            strLoanType = row.Item("MaLoaiAnPham") & ""
        '            listColumn650a.Clear()
        '            listColumn700a.Clear()

        '            Dim arrFieldName() As Object
        '            Dim arrFieldValue() As Object
        '            ReDim Preserve arrFieldName(17)
        '            ReDim Preserve arrFieldValue(17)

        '            Try
        '                arrFieldName(0) = "000"
        '                arrFieldValue(0) = "00172nam a2200121 p 4500"
        '            Catch ex As Exception
        '                arrFieldName(0) = Nothing
        '                arrFieldValue(0) = Nothing
        '            End Try

        '            Try
        '                arrFieldName(1) = "001"
        '                arrFieldValue(1) = objBInput.Gen001(CInt(Session("IsAuthority")))
        '            Catch ex As Exception
        '                arrFieldName(1) = Nothing
        '                arrFieldValue(1) = Nothing
        '            End Try

        '            Try
        '                arrFieldName(2) = "911"
        '                arrFieldValue(2) = strCataloguer
        '            Catch ex As Exception
        '                arrFieldName(2) = Nothing
        '                arrFieldValue(2) = Nothing
        '            End Try

        '            Try
        '                arrFieldName(3) = "925"
        '                arrFieldValue(3) = "G"
        '            Catch ex As Exception
        '                arrFieldName(3) = Nothing
        '                arrFieldValue(3) = Nothing
        '            End Try

        '            Try
        '                arrFieldName(4) = "926"
        '                arrFieldValue(4) = "0"
        '            Catch ex As Exception
        '                arrFieldName(4) = Nothing
        '                arrFieldValue(4) = Nothing
        '            End Try

        '            Try
        '                arrFieldName(5) = "927"
        '                arrFieldValue(5) = ReferrenceItemType(strItemType)
        '            Catch ex As Exception
        '                arrFieldName(5) = Nothing
        '                arrFieldValue(5) = Nothing
        '            End Try

        '            Try
        '                arrFieldName(6) = "900"
        '                arrFieldValue(6) = "1"
        '            Catch ex As Exception
        '                arrFieldName(6) = Nothing
        '                arrFieldValue(6) = Nothing
        '            End Try

        '            '245 - Nhan de / $a:245$a; $b:245$b ; $d:245$d ; $e:NumberCopies
        '            Try
        '                arrFieldName(7) = Nothing
        '                arrFieldValue(7) = Nothing
        '                If Not String.IsNullOrEmpty(strTitle) Then
        '                    arrFieldName(7) = "245"
        '                    arrFieldValue(7) = ""
        '                    Dim arrSplitTitle As String() = strTitle.Split(strDollarSplit)
        '                    For Each itemArr As String In arrSplitTitle
        '                        If itemArr.Length > 0 Then
        '                            If itemArr(0) <> "e" Then
        '                                arrFieldValue(7) = arrFieldValue(7) & strDollarSplit & itemArr.Replace(Left(itemArr, 1) & ":", Left(itemArr, 1))
        '                            Else
        '                                strNumberCopies = itemArr.Replace(Left(itemArr, 1) & ":", Left(itemArr, 1)).Substring(1)
        '                            End If
        '                        End If
        '                    Next
        '                End If
        '            Catch ex As Exception
        '                arrFieldName(7) = Nothing
        '                arrFieldValue(7) = Nothing
        '            End Try

        '            '100 - Tac gia / $a:100$a
        '            Try
        '                arrFieldName(8) = Nothing
        '                arrFieldValue(8) = Nothing
        '                If Not String.IsNullOrEmpty(strAuthor) Then
        '                    arrFieldName(8) = "100"
        '                    arrFieldValue(8) = strAuthor.Replace(Left(strAuthor, 2) & ":", Left(strAuthor, 2))
        '                End If
        '            Catch ex As Exception
        '                arrFieldName(8) = Nothing
        '                arrFieldValue(8) = Nothing
        '            End Try

        '            '082,650 - De muc / $a:082$a ; $b:082$b ; $c:650$a
        '            Try
        '                arrFieldName(9) = Nothing
        '                arrFieldValue(9) = Nothing
        '                If Not String.IsNullOrEmpty(strItemSH) Then
        '                    arrFieldName(9) = "082"
        '                    arrFieldValue(9) = ""
        '                    Dim arrSplitItemSH As String() = strItemSH.Split(strDollarSplit)
        '                    For Each itemArr As String In arrSplitItemSH
        '                        If itemArr.Length > 0 Then
        '                            If itemArr(0) <> "c" Then
        '                                arrFieldValue(9) = arrFieldValue(9) & strDollarSplit & itemArr.Replace(Left(itemArr, 1) & ":", Left(itemArr, 1))
        '                            Else
        '                                Dim str650a As String = itemArr.Replace(Left(itemArr, 1) & ":", Left(itemArr, 1)).Substring(1)
        '                                Dim arr650aSplit As String() = str650a.Split(New String() {"--"}, StringSplitOptions.None)
        '                                For Each item650 As String In arr650aSplit
        '                                    listColumn650a.Add(item650.Trim())
        '                                Next
        '                            End If
        '                        End If
        '                    Next
        '                End If
        '            Catch ex As Exception
        '                arrFieldName(9) = Nothing
        '                arrFieldValue(9) = Nothing
        '            End Try

        '            '520 - Mo ta / $a:520$a
        '            Try
        '                arrFieldName(10) = Nothing
        '                arrFieldValue(10) = Nothing
        '                If Not String.IsNullOrEmpty(strDescription) Then
        '                    arrFieldName(10) = "520"
        '                    arrFieldValue(10) = strDescription.Replace(Left(strDescription, 2) & ":", Left(strDescription, 2))
        '                End If
        '            Catch ex As Exception
        '                arrFieldName(10) = Nothing
        '                arrFieldValue(10) = Nothing
        '            End Try

        '            '250,260 - Xuat ban / $a:250$a ; $c:260$a ; $d:260$b
        '            '260 - Ngay thang / $a:260$c (bỏ : và khoảng trắng)
        '            Try
        '                arrFieldName(11) = Nothing
        '                arrFieldValue(11) = Nothing
        '                arrFieldName(12) = Nothing
        '                arrFieldValue(12) = Nothing
        '                If Not String.IsNullOrEmpty(strPublisher) Then
        '                    arrFieldName(11) = "250"
        '                    arrFieldName(12) = "260"
        '                    arrFieldValue(11) = ""
        '                    arrFieldValue(12) = ""
        '                    Dim arrSplitPublisher As String() = strPublisher.Split(strDollarSplit)
        '                    For Each itemArr As String In arrSplitPublisher
        '                        If itemArr.Length > 0 Then
        '                            If itemArr(0) = "a" Then
        '                                arrFieldValue(11) = arrFieldValue(11) & strDollarSplit & itemArr.Replace(Left(itemArr, 1) & ":", Left(itemArr, 1))
        '                            Else
        '                                If itemArr(0) = "c" Then
        '                                    itemArr = "a" & itemArr.Substring(1)
        '                                End If
        '                                If itemArr(0) = "d" Then
        '                                    itemArr = "b" & itemArr.Substring(1)
        '                                End If
        '                                arrFieldValue(12) = arrFieldValue(12) & strDollarSplit & itemArr.Replace(Left(itemArr, 1) & ":", Left(itemArr, 1))
        '                            End If
        '                        End If
        '                    Next
        '                End If

        '                If Not String.IsNullOrEmpty(strPublishYear) Then
        '                    Dim arrSplitPublishYear As String() = strPublishYear.Split(strDollarSplit)
        '                    For Each itemArr As String In arrSplitPublishYear
        '                        If itemArr.Length > 0 Then
        '                            If itemArr(0) = "a" Then
        '                                itemArr = "c" & itemArr.Trim.Substring(1)
        '                            End If
        '                            arrFieldValue(12) = arrFieldValue(12) & strDollarSplit & itemArr.Replace(Left(itemArr, 1) & ":", Left(itemArr, 1))
        '                        End If
        '                    Next
        '                End If
        '            Catch ex As Exception
        '                arrFieldName(11) = Nothing
        '                arrFieldValue(11) = Nothing
        '                arrFieldName(12) = Nothing
        '                arrFieldValue(12) = Nothing
        '            End Try

        '            '700 - Tac gia phu / $a:700$a
        '            Try
        '                arrFieldName(13) = Nothing
        '                arrFieldValue(13) = Nothing
        '                If Not String.IsNullOrEmpty(strAuthorOther) Then
        '                    arrFieldName(13) = "700"
        '                    arrFieldValue(13) = ""
        '                    Dim arrSplitAuthorOther As String() = strAuthorOther.Split(strDollarSplit)
        '                    For Each itemArr As String In arrSplitAuthorOther
        '                        If itemArr.Length > 0 Then
        '                            Dim str700a As String = itemArr.Replace(Left(itemArr, 1) & ":", Left(itemArr, 1)).Substring(1)
        '                            Dim arr700aSplit As String() = str700a.Split(New Char() {","}, StringSplitOptions.None)
        '                            For Each item700 As String In arr700aSplit
        '                                listColumn700a.Add(item700.Trim())
        '                            Next
        '                        End If
        '                    Next
        '                End If
        '            Catch ex As Exception
        '                arrFieldName(13) = Nothing
        '                arrFieldValue(13) = Nothing
        '            End Try

        '            '300 - Mo ta vat ly / $a:300$a ; $b:300$b ; $c:300$c ; $d:300$e ; $e:Price
        '            Try
        '                arrFieldName(14) = Nothing
        '                arrFieldValue(14) = Nothing
        '                If Not String.IsNullOrEmpty(strPhysical) Then
        '                    arrFieldName(14) = "300"
        '                    arrFieldValue(14) = ""
        '                    Dim arrPhysical As String() = strPhysical.Split(strDollarSplit)
        '                    For Each itemArr As String In arrPhysical
        '                        If itemArr.Length > 0 Then
        '                            If itemArr(0) <> "e" Then
        '                                If itemArr(0) = "d" Then
        '                                    itemArr = "e" & itemArr.Substring(1)
        '                                End If
        '                                arrFieldValue(14) = arrFieldValue(14) & strDollarSplit & itemArr.Replace(Left(itemArr, 1) & ":", Left(itemArr, 1))
        '                            Else
        '                                strPrice = itemArr.Replace(Left(itemArr, 1) & ":", Left(itemArr, 1)).Substring(1)
        '                                Dim strTypeCurency As String = "VN"
        '                                If strPrice.Contains("USD") Then
        '                                    strTypeCurency = "EN"
        '                                End If
        '                                strPrice = strPrice.Replace("(", "").Trim()
        '                                strPrice = strPrice.Replace("VNĐ", "").Trim()
        '                                strPrice = strPrice.Replace(")", "").Trim()
        '                                strPrice = strPrice.Replace("VND", "").Trim()
        '                                strPrice = strPrice.Replace("đ", "").Trim()
        '                                strPrice = strPrice.Replace("đồng", "").Trim()
        '                                strPrice = strPrice.Replace("sách tặng", "").Trim()
        '                                strPrice = strPrice.Replace("photo", "").Trim()
        '                                strPrice = strPrice.Replace("Download", "").Trim()
        '                                strPrice = strPrice.Replace("Scan", "").Trim()
        '                                strPrice = strPrice.Replace("USD", "").Trim()
        '                                If strPrice = "VN" Then
        '                                    strPrice = strPrice.Replace(".", "").Trim()
        '                                    strPrice = strPrice.Replace(",", "").Trim()
        '                                    If strPrice.Trim().Length < 3 Then
        '                                        strPrice = strPrice & "000"
        '                                    End If
        '                                End If
        '                                If Not IsNumeric(strPrice) Then
        '                                    strPrice = "0"
        '                                End If
        '                            End If
        '                        End If
        '                    Next
        '                End If
        '            Catch ex As Exception
        '                arrFieldName(14) = Nothing
        '                arrFieldValue(14) = Nothing
        '            End Try

        '            '020 - Dinh dang tai lieu / $a:020$a (bỏ gạch ngang, khoảng trắng)
        '            Try
        '                arrFieldName(15) = Nothing
        '                arrFieldValue(15) = Nothing
        '                If Not String.IsNullOrEmpty(strDocumentFormat) Then
        '                    arrFieldName(15) = "020"
        '                    arrFieldValue(15) = strDocumentFormat.Replace(Left(strDocumentFormat, 2) & ":", Left(strDocumentFormat, 2))
        '                End If
        '            Catch ex As Exception
        '                arrFieldName(15) = Nothing
        '                arrFieldValue(15) = Nothing
        '            End Try

        '            '040 - Nguon goc / $a:040$a
        '            Try
        '                arrFieldName(16) = Nothing
        '                arrFieldValue(16) = Nothing
        '                If Not String.IsNullOrEmpty(strSource) Then
        '                    arrFieldName(16) = "040"
        '                    arrFieldValue(16) = "" 'strSource.Replace(Left(strSource, 2) & ":", Left(strSource, 2))
        '                End If
        '            Catch ex As Exception
        '                arrFieldName(16) = Nothing
        '                arrFieldValue(16) = Nothing
        '            End Try

        '            '041 - Ngon ngu / $a:041$a
        '            Try
        '                arrFieldName(17) = Nothing
        '                arrFieldValue(17) = Nothing
        '                If Not String.IsNullOrEmpty(strLanguage) Then
        '                    arrFieldName(17) = "041"
        '                    arrFieldValue(17) = strLanguage.Replace(Left(strLanguage, 2) & ":", Left(strLanguage, 2))
        '                End If
        '            Catch ex As Exception
        '                arrFieldName(17) = Nothing
        '                arrFieldValue(17) = Nothing
        '            End Try


        '            For j As Integer = 7 To 17
        '                If (IsNothing(arrFieldValue(j))) Or (String.IsNullOrEmpty(arrFieldValue(j))) Then
        '                    arrFieldName(j) = Nothing
        '                    arrFieldValue(j) = Nothing
        '                End If
        '            Next

        '            ' import to data
        '            objBInput.FieldName = arrFieldName

        '            objBInput.FieldValue = arrFieldValue
        '            objBInput.LibID = clsSession.GlbSite

        '            If strTitle <> strTitlePre Then
        '                If Session("IsAuthority") = 1 Then
        '                    If objBInput.UpdateAuthority(4, 1) = 1 Then
        '                        itemId = Integer.Parse(objBInput.WorkID.ToString())
        '                        If itemId > 0 Then
        '                            For Each str650a As String In listColumn650a
        '                                If str650a & "" <> "" Then
        '                                    textQuery = objBInput.GetTextQueryField("Lib_tblField600S", strDollarSplit & "a" & str650a, itemId, 650, 0)
        '                                    If objBInput.ExcuteQueryByScript(textQuery) = 1 Then
        '                                        textQuery = "exec Cat_spDicSh_Ins N'" & str650a & "', " & itemId & ", '650$a'"
        '                                        objBInput.ExcuteQueryByScript(textQuery)
        '                                    End If
        '                                End If
        '                            Next
        '                            For Each str700a As String In listColumn700a
        '                                If str700a & "" <> "" Then
        '                                    textQuery = objBInput.GetTextQueryField("Lib_tblField700S", strDollarSplit & "a" & str700a, itemId, 700, 0)
        '                                    If objBInput.ExcuteQueryByScript(textQuery) = 1 Then
        '                                        textQuery = "exec Cat_spDicAuthor_Ins N'" & str700a & "', " & itemId & ", '700$a'"
        '                                        objBInput.ExcuteQueryByScript(textQuery)
        '                                    End If
        '                                End If
        '                            Next
        '                            Call InsertHoding(strCopyNumber, itemId, strNumberCopies, ReferrenceLoanType(strLoanType), strBarCode, strLocation, strSource, strStatusCode, strStatusNote, CType(strPrice, Double), strDateCreate, Date.Now)
        '                        End If
        '                    End If
        '                Else
        '                    If objBInput.Update(4, 0) = 1 Then ' 4
        '                        itemId = Integer.Parse(objBInput.WorkID.ToString())
        '                        If itemId > 0 Then
        '                            For Each str650a As String In listColumn650a
        '                                If str650a & "" <> "" Then
        '                                    textQuery = objBInput.GetTextQueryField("Lib_tblField600S", strDollarSplit & "a" & str650a, itemId, 650, 0)
        '                                    If objBInput.ExcuteQueryByScript(textQuery) = 1 Then
        '                                        textQuery = "exec Cat_spDicSh_Ins N'" & str650a & "', " & itemId & ", '650$a'"
        '                                        objBInput.ExcuteQueryByScript(textQuery)
        '                                    End If
        '                                End If
        '                            Next
        '                            For Each str700a As String In listColumn700a
        '                                If str700a & "" <> "" Then
        '                                    textQuery = objBInput.GetTextQueryField("Lib_tblField700S", strDollarSplit & "a" & str700a, itemId, 700, 0)
        '                                    If objBInput.ExcuteQueryByScript(textQuery) = 1 Then
        '                                        textQuery = "exec Cat_spDicAuthor_Ins N'" & str700a & "', " & itemId & ", '700$a'"
        '                                        objBInput.ExcuteQueryByScript(textQuery)
        '                                    End If
        '                                End If
        '                            Next
        '                            Call InsertHoding(strCopyNumber, itemId, strNumberCopies, ReferrenceLoanType(strLoanType), strBarCode, strLocation, strSource, strStatusCode, strStatusNote, CType(strPrice, Double), strDateCreate, Date.Now)
        '                        End If
        '                    End If
        '                End If
        '            Else
        '                If itemId > 0 Then
        '                    Call InsertHoding(strCopyNumber, itemId, strNumberCopies, ReferrenceLoanType(strLoanType), strBarCode, strLocation, strSource, strStatusCode, strStatusNote, CType(strPrice, Double), strDateCreate, Date.Now)
        '                End If
        '            End If

        '            strTitlePre = strTitle

        '            countSusscess = countSusscess + 1

        '            lbSuccess.Text = "<i>Số dòng đã thực hiện thành công: </i><b><u>" & countSusscess & "</u></b>"

        '            Call BindPrg(i, tbl.Rows.Count)
        '        Catch ex As Exception
        '            listError.Add((i).ToString())
        '        End Try
        '    Next

        '    If listError.Count > 0 Then
        '        lblErrorDataCat.Text = "Những dòng không import được dữ liệu: "
        '        For Each item As String In listError
        '            lblErrorDataCat.Text += item.ToString() + "; "
        '        Next
        '    Else
        '        lblErrorDataCat.Text = ""
        '    End If
        '    If listErrorDKCB.Count > 0 Then
        '        lblErrorItemHolding.Text = "Những dòng không ĐKCB được: "
        '        For Each item As String In listErrorDKCB
        '            lblErrorItemHolding.Text += item.ToString() + "; "
        '        Next
        '    Else
        '        lblErrorItemHolding.Text = ""
        '    End If
        'End Sub

        'Private Function ReferrenceItemType(ByVal strValue As String) As Integer
        '    Dim intResult As Integer = 1
        '    Select Case strValue
        '        Case "Bao"
        '            intResult = 9
        '        Case "BaoCaoThucTap"
        '            intResult = 4
        '        Case "CDROM"
        '            intResult = 23
        '        Case "DeTaiNghienCuu"
        '            intResult = 32
        '        Case "GiaoTrinh"
        '            intResult = 15
        '        Case "LuanAn"
        '            intResult = 3
        '        Case "LuanVan"
        '            intResult = 3
        '        Case "Sach"
        '            intResult = 1
        '        Case "SachThaoKhao"
        '            intResult = 1
        '        Case "TaiLieuDienTu"
        '            intResult = 32
        '        Case "TapChi"
        '            intResult = 9
        '        Case "TranhAnh"
        '            intResult = 12
        '        Case Else
        '            intResult = 1
        '    End Select
        '    Return intResult
        'End Function

        'Private Function ReferrenceLoanType(ByVal strValue As String) As String
        '    Dim strResult As String = "STK"
        '    Select Case strValue
        '        Case "Bao"
        '            strResult = "BAO"
        '        Case "BaoCaoThucTap"
        '            strResult = "KL"
        '        Case "CDROM"
        '            strResult = "CD"
        '        Case "DeTaiNghienCuu"
        '            strResult = "NCKH-GV"
        '        Case "GiaoTrinh"
        '            strResult = "GT"
        '        Case "LuanAn"
        '            strResult = "LA"
        '        Case "LuanVan"
        '            strResult = "LV"
        '        Case "Sach"
        '            strResult = "GT"
        '        Case "SachThaoKhao"
        '            strResult = "STK"
        '        Case "TaiLieuDienTu"
        '            strResult = "SH"
        '        Case "TapChi"
        '            strResult = "TC"
        '        Case "TranhAnh"
        '            strResult = "EB"
        '        Case Else
        '            strResult = "STK"
        '    End Select
        '    Return strResult
        'End Function

        Private Function ReferrenceLoanTypeDHVL(ByVal strValue As String) As String
            Dim strResult As String = "STK"
            Select Case strValue.Trim()
                Case "STK"
                    strResult = "STK"
                Case "Sách tham khảo"
                    strResult = "STK"
                Case "TK"
                    strResult = "STK"
                Case "GT"
                    strResult = "GT"
                Case "SGT"
                    strResult = "GT"
                Case "Sách chuyên ngành"
                    strResult = "GT"
                Case "Giáo trình"
                    strResult = "GT"
                Case "TUD"
                    strResult = "TUD"
                Case "TD"
                    strResult = "TUD"
                Case "Tài liệu điện tử"
                    strResult = "TLDT"
                Case "EB"
                    strResult = "Ebook"
                Case "SH"
                    strResult = "SH"
                Case "CD"
                    strResult = "CD"
                Case "DA"
                    strResult = "DA"
                Case "SCK"
                    strResult = "SCK"
                Case "LA"
                    strResult = "LA"
                Case "LV"
                    strResult = "LV"
                Case "KL"
                    strResult = "KL"
                Case "NCKH"
                    strResult = "NCKH"
                Case Else
                    strResult = "STK"
            End Select
            Return strResult
        End Function

        '{STK} {GT} {SGT} {TUD}
        '{STK} {GT} {TD}
        '{STK}
        '{STK} {GT} {TUD} {TD} {Tài liệu điện tử} {}
        '{TUD} {STK} {GT} {DA} {SCK} {NCKH} {LV} {LA} {KL} {} {TK}
        '{EB} {SH} {CD}
        '{STK} {Sách tham khảo} {GT} {Sách chuyên ngành} {Giáo trình} {Tài liệu điện tử}

        '{STK}/{Sách tham khảo}/{TK}                    -> LoanType:STK     -> ItemType:SH
        '{GT}/{SGT}/{Sách chuyên ngành}/{Giáo trình}    -> LoanType:GT      -> ItemType:SH 
        '{TUD}/{TD}                                     -> LoanType:TUD     -> ItemType:SH
        '{Tài liệu điện tử}                             -> LoanType:TLDT    -> ItemType:TLDT
        '{DA}                                           -> LoanType:DA      -> ItemType:ĐT
        '{SCK}                                          -> LoanType:SCK     -> ItemType:SH
        '{NCKH}                                         -> LoanType:NCKH-GV -> ItemType:ĐT
        '{LV}                                           -> LoanType:LV      -> ItemType:ĐT
        '{LA}                                           -> LoanType:LA      -> ItemType:ĐT
        '{KL}                                           -> LoanType:KL      -> ItemType:ĐT
        '{}                                             -> LoanType:STK     -> ItemType:SH              Default
        '{EB}                                           -> LoanType:Ebook   -> ItemType:TLDT
        '{SH}                                           -> LoanType:SH      -> ItemType:TLDT
        '{CD}                                           -> LoanType:CD      -> ItemType:CD


        Private Function ReferrenceItemType(ByVal strValue As String) As String
            Dim intResult As String = "S"
            Select Case strValue
                Case "STK"
                    intResult = "S"
                Case "GT"
                    intResult = "S"
                Case "TUD"
                    intResult = "S"
                Case "SCK"
                    intResult = "S"
                Case "TLDT"
                    intResult = "TLDT"
                Case "DA"
                    intResult = "DTTN"
                Case "NCKH"
                    intResult = "SPKH"
                Case "LV"
                    intResult = "DTTN"
                Case "LA"
                    intResult = "DTTN"
                Case "KL"
                    intResult = "DTTN"
                Case "Ebook"
                    intResult = "TLDT"
                Case "CDS"
                    intResult = "MEDIA"
                Case "CDB"
                    intResult = "MEDIA"
                Case "DVD"
                    intResult = "MEDIA"
                Case Else
                    intResult = "S"
            End Select
            Return intResult
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

        Private Sub ImportData(ByVal tbl As DataTable)
            Dim listError As New List(Of String) ' Danh sách insert ko được
            Dim listErrorDKCB As New List(Of String) ' Danh sách insert DKCB ko được
            Dim listCopyNumber As New List(Of String) ' Danh sach DKCB da ton tai

            Dim countTotalRecordInput As Integer = If(tbl.Rows.Count <= 0, 0, tbl.Rows.Count) 'Tổng dòng nhập từ file excel
            Dim countSusscess As Integer = 0  'Tổng dòng thực hiện thành công

            Dim pathRoot As String = objBInput.GetValueSysByParameter("EDATA_LOCATIONS") 'Đường dẫn gốc
            pathRoot = pathRoot.Replace(";", "")
            Dim libaryPath As String = objBInput.GetLibaryUrl(clsSession.GlbSite) 'Đường dẫn thư viện trường
            Dim itemId As Integer = 0

            'Dim listItemCat = objBInput.GetListItemCatType() 'Danh sách CAT_DIC_ITEM_TYPE

            lbTotalInput.Text = "<i>Tổng số dòng nhập từ file Excel: </i><b><u>" & countTotalRecordInput & "</u></b>"

            Response.Write("<div class='lbLabel' style=' margin:0;top:250;left:0; width:100%;'>")
            Response.Write("<p style='position:absolute; left:45%;'>Nhập khẩu dữ liệu: <span id='pgbMain_label'>0%</span></p>")
            Response.Write("<p style='padding-top:35px;'><table width='0%' border=2 bordercolor='white' id='pgbMain' bgcolor=blue><tr style='HEIGHT: 18px'><td></td></tr></table></p>")
            Response.Write("</div>")

            Dim strTitle As String = ""
            Dim strTitlePre As String = ""
            Dim strAuthor As String = ""
            Dim strAuthorPre As String = ""
            Dim strPublisher As String = ""
            Dim strPublisherPre As String = ""
            Dim strPublishYear As String = ""
            Dim strPublishYearPre As String = ""
            Dim strCallNumber As String = ""
            Dim strPricePre As String = "0"

            For i As Integer = 0 To tbl.Rows.Count - 1
                Try
                    Dim row As DataRow = tbl.Rows(i)
                    Dim textQuery = ""
                    Dim arrFieldName() As Object
                    Dim arrFieldValue() As Object
                    ReDim Preserve arrFieldName(28)
                    ReDim Preserve arrFieldValue(28)

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
                        arrFieldName(2) = "003"
                        arrFieldValue(2) = row.Item("003")
                    Catch ex As Exception
                        arrFieldName(2) = Nothing
                        arrFieldValue(2) = Nothing
                    End Try


                    Try
                        arrFieldName(3) = "008"
                        arrFieldValue(3) = row.Item("008")
                    Catch ex As Exception
                        arrFieldName(3) = Nothing
                        arrFieldValue(3) = Nothing
                    End Try


                    '020$a
                    '020$c
                    '----- 020$aTho $cVu
                    Try
                        arrFieldName(4) = Nothing
                        arrFieldValue(4) = Nothing
                        If (CheckExistColumn("020", tbl)) Then
                            If (CheckExistColumn("020$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("020$a") & ""))) Then
                                arrFieldName(4) = "020"
                                arrFieldValue(4) = arrFieldValue(4) & "" & "$a" & row.Item("020$a")
                                arrFieldValue(4) = arrFieldValue(4).ToString.Trim()
                            End If
                            If (CheckExistColumn("020$c", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("020$c") & ""))) Then
                                arrFieldName(4) = "020"
                                arrFieldValue(4) = arrFieldValue(4) & "" & " $c" & row.Item("020$c")
                                arrFieldValue(4) = arrFieldValue(4).ToString.Trim()
                            End If
                            'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(10), itemId, 20)
                        End If

                    Catch ex As Exception
                        arrFieldName(4) = Nothing
                        arrFieldValue(4) = Nothing
                    End Try


                    '040$a 040$c
                    Try
                        arrFieldName(5) = Nothing
                        arrFieldValue(5) = Nothing
                        arrFieldName(5) = "040"
                        arrFieldValue(5) = ""

                        'If (CheckExistColumn("040", tbl)) Then
                        '    If (CheckExistColumn("040$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("040$a") & ""))) Then
                        '        arrFieldName(5) = "040"
                        '        arrFieldValue(5) = arrFieldValue(5) & "" & "$a" & row.Item("040$a")
                        '        arrFieldValue(5) = arrFieldValue(5).ToString.Trim()
                        '    End If
                        '    If (CheckExistColumn("040$c", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("040$c") & ""))) Then
                        '        arrFieldName(5) = "040"
                        '        arrFieldValue(5) = arrFieldValue(5) & "" & " $c" & row.Item("040$c")
                        '        arrFieldValue(5) = arrFieldValue(5).ToString.Trim()
                        '    End If
                        'End If
                    Catch ex As Exception
                        arrFieldName(5) = Nothing
                        arrFieldValue(5) = Nothing
                    End Try


                    '041$a 041$h
                    Try
                        arrFieldName(6) = Nothing
                        arrFieldValue(6) = Nothing
                        If (CheckExistColumn("041", tbl)) Then
                            If (CheckExistColumn("041$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("041$a") & ""))) Then
                                arrFieldName(6) = "041"
                                arrFieldValue(6) = arrFieldValue(6) & "" & "$a" & row.Item("041$a")
                                arrFieldValue(6) = arrFieldValue(6).ToString.Trim()
                            End If
                            If (CheckExistColumn("041$h", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("041$h") & ""))) Then
                                arrFieldName(6) = "041"
                                arrFieldValue(6) = arrFieldValue(6) & "" & " $h" & row.Item("041$h")
                                arrFieldValue(6) = arrFieldValue(6).ToString.Trim()
                            End If
                        End If
                    Catch ex As Exception
                        arrFieldName(6) = Nothing
                        arrFieldValue(6) = Nothing
                    End Try

                    '082$2	
                    '082$a	
                    '082$b	
                    '082$c	
                    '------- 082$2Tho $aVu $bSon $cPhuong
                    Try
                        arrFieldName(7) = Nothing
                        arrFieldValue(7) = Nothing
                        strCallNumber = ""
                        If (CheckExistColumn("082", tbl)) Then
                            If (CheckExistColumn("082$2", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("082$2") & ""))) Then
                                arrFieldName(7) = "082"
                                arrFieldValue(7) = arrFieldValue(7) & "" & "$2" & row.Item("082$2")
                                arrFieldValue(7) = arrFieldValue(7).ToString.Trim()
                                'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
                            End If

                            If (CheckExistColumn("082$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("082$a") & ""))) Then
                                arrFieldName(7) = "082"
                                arrFieldValue(7) = arrFieldValue(7) & "" & "$a" & row.Item("082$a")
                                arrFieldValue(7) = arrFieldValue(7).ToString.Trim()
                                'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
                                strCallNumber = row.Item("082$a")
                            End If

                            If (CheckExistColumn("082$b", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("082$b") & ""))) Then
                                arrFieldName(7) = "082"
                                arrFieldValue(7) = arrFieldValue(7) & "" & "$b" & row.Item("082$b")
                                arrFieldValue(7) = arrFieldValue(7).ToString.Trim()
                                'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
                            End If

                            If (CheckExistColumn("082$c", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("082$c") & ""))) Then
                                arrFieldName(7) = "082"
                                arrFieldValue(7) = arrFieldValue(7) & "" & "$c" & row.Item("082$c")
                                arrFieldValue(7) = arrFieldValue(7).ToString.Trim()
                                'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
                            End If
                        End If

                    Catch ex As Exception
                        arrFieldName(7) = Nothing
                        arrFieldValue(7) = Nothing
                    End Try

                    '100$a	
                    '100$c	
                    '100$e
                    '------ 100$aTho, $cVu $eSon
                    Try
                        strAuthor = ""
                        arrFieldName(8) = Nothing
                        arrFieldValue(8) = Nothing
                        If (CheckExistColumn("100", tbl)) Then

                            If (CheckExistColumn("100$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("100$a") & ""))) Then
                                arrFieldName(8) = "100"
                                arrFieldValue(8) = arrFieldValue(8) & "" & "$a" & row.Item("100$a")
                                arrFieldValue(8) = arrFieldValue(8).ToString.Trim()
                                'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
                            End If

                            If (CheckExistColumn("100$c", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("100$c") & ""))) Then
                                arrFieldName(8) = "100"
                                If (Not IsNothing(arrFieldValue(8))) Then
                                    arrFieldValue(8) = arrFieldValue(8) & "" & " $c" & row.Item("100$c")
                                Else
                                    arrFieldValue(8) = arrFieldValue(8) & "" & " $c" & row.Item("100$c")
                                End If
                                arrFieldValue(8) = arrFieldValue(8).ToString.Trim()
                                'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
                            End If

                            If (CheckExistColumn("100$e", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("100$e") & ""))) Then
                                arrFieldName(8) = "100"
                                arrFieldValue(8) = arrFieldValue(8) & "" & " $e" & row.Item("100$e")
                                arrFieldValue(8) = arrFieldValue(8).ToString.Trim()
                                'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
                            End If
                        End If
                        strAuthor = arrFieldValue(8)

                        If strAuthor = "" Then
                            strAuthor = strAuthorPre
                        End If

                    Catch ex As Exception
                        arrFieldName(8) = Nothing
                        arrFieldValue(8) = Nothing
                    End Try

                    '110$a	
                    '110$b	
                    '------ 110$aTho, $bVu
                    Try

                        arrFieldName(9) = Nothing
                        arrFieldValue(9) = Nothing
                        If (CheckExistColumn("110", tbl)) Then

                            If (CheckExistColumn("110$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("110$a") & ""))) Then
                                arrFieldName(9) = "110"
                                arrFieldValue(9) = arrFieldValue(9) & "" & "$a" & row.Item("110$a")
                                arrFieldValue(9) = arrFieldValue(9).ToString.Trim()
                                'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
                            End If

                            If (CheckExistColumn("110$b", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("110$b") & ""))) Then
                                arrFieldName(9) = "110"
                                If (Not IsNothing(arrFieldValue(9))) Then
                                    arrFieldValue(9) = arrFieldValue(9) & "" & " $c" & row.Item("110$b")
                                Else
                                    arrFieldValue(9) = arrFieldValue(9) & "" & " $c" & row.Item("110$b")
                                End If
                                arrFieldValue(14) = arrFieldValue(9).ToString.Trim()
                                'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
                            End If

                        End If

                    Catch ex As Exception
                        arrFieldName(9) = Nothing
                        arrFieldValue(9) = Nothing
                    End Try

                    '245$a	
                    '245$b	
                    '245$c	
                    '245$n	
                    '245$p	
                    '------ 245$aTho: $bVu. $nSon, $pPhuong/ $cQuoc
                    Try
                        strTitle = ""
                        arrFieldName(10) = Nothing
                        arrFieldValue(10) = Nothing
                        If (CheckExistColumn("245", tbl)) Then

                            If (CheckExistColumn("245$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("245$a") & ""))) Then
                                arrFieldName(10) = "245"
                                arrFieldValue(10) = arrFieldValue(10) & "" & "$a" & row.Item("245$a")
                                arrFieldValue(10) = arrFieldValue(10).ToString.Trim()
                                'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
                            End If

                            If (CheckExistColumn("245$b", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("245$b") & ""))) Then
                                arrFieldName(10) = "245"
                                If (Not IsNothing(arrFieldValue(10))) Then
                                    arrFieldValue(10) = arrFieldValue(10) & "" & " $b" & row.Item("245$b")
                                Else
                                    arrFieldValue(10) = arrFieldValue(10) & "" & " $b" & row.Item("245$b")
                                End If
                                arrFieldValue(10) = arrFieldValue(10).ToString.Trim()
                                'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
                            End If

                            If (CheckExistColumn("245$n", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("245$n") & ""))) Then
                                arrFieldName(10) = "245"
                                If (Not IsNothing(arrFieldValue(10))) Then
                                    arrFieldValue(10) = arrFieldValue(10) & "" & " $n" & row.Item("245$n")
                                Else
                                    arrFieldValue(10) = arrFieldValue(10) & "" & " $n" & row.Item("245$n")
                                End If
                                arrFieldValue(10) = arrFieldValue(10).ToString.Trim()
                                'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
                            End If

                            If (CheckExistColumn("245$p", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("245$p") & ""))) Then
                                arrFieldName(10) = "245"
                                If (Not IsNothing(arrFieldValue(10))) Then
                                    arrFieldValue(10) = arrFieldValue(10) & "" & " $p" & row.Item("245$p")
                                Else
                                    arrFieldValue(10) = arrFieldValue(10) & "" & " $p" & row.Item("245$p")
                                End If
                                arrFieldValue(10) = arrFieldValue(10).ToString.Trim()
                                'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
                            End If

                            If (CheckExistColumn("245$c", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("245$c") & ""))) Then
                                arrFieldName(10) = "245"
                                If (Not IsNothing(arrFieldValue(10))) Then
                                    arrFieldValue(10) = arrFieldValue(10) & "" & " $c" & row.Item("245$c")
                                    'If (CheckExistColumn("700$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("700$a") & ""))) Then
                                    '    arrFieldValue(10) = arrFieldValue(15) & "; " & row.Item("700$a")
                                    'End If
                                Else
                                    arrFieldValue(10) = arrFieldValue(10) & "" & " $c" & row.Item("245$c")
                                    'If (CheckExistColumn("700$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("700$a") & ""))) Then
                                    '    arrFieldValue(10) = arrFieldValue(10) & "; " & row.Item("700$a")
                                    'End If
                                End If
                                arrFieldValue(10) = arrFieldValue(10).ToString.Trim()
                                'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
                            Else
                                'If (CheckExistColumn("700$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("700$a") & ""))) Then
                                '    arrFieldName(10) = "245"
                                '    If (Not IsNothing(arrFieldValue(15))) Then
                                '        arrFieldValue(10) = arrFieldValue(10) & "/ $c" & row.Item("700$a")
                                '    Else
                                '        arrFieldValue(10) = arrFieldValue(10) & " $c" & row.Item("700$a")
                                '    End If
                                '    arrFieldValue(10) = arrFieldValue(10).ToString.Trim()
                                'End If
                            End If
                            strTitle = arrFieldValue(10)
                        End If

                        If strTitle = "" Then
                            strTitle = strTitlePre
                        End If

                    Catch ex As Exception
                        arrFieldName(10) = Nothing
                        arrFieldValue(10) = Nothing
                    End Try



                    '246$a	
                    '246$b
                    '------ 246$aTho, $bVu
                    Try
                        arrFieldName(11) = Nothing
                        arrFieldValue(11) = Nothing
                        If (CheckExistColumn("246", tbl)) Then

                            If (CheckExistColumn("246$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("246$a") & ""))) Then
                                arrFieldName(11) = "246"
                                arrFieldValue(11) = arrFieldValue(11) & "" & "$a" & row.Item("246$a")
                                arrFieldValue(11) = arrFieldValue(11).ToString.Trim()
                                'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
                            End If

                            If (CheckExistColumn("246$b", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("246$b") & ""))) Then
                                arrFieldName(11) = "246"
                                If (Not IsNothing(arrFieldValue(11))) Then
                                    arrFieldValue(11) = arrFieldValue(11) & "" & " $c" & row.Item("246$b")
                                Else
                                    arrFieldValue(11) = arrFieldValue(11) & "" & " $c" & row.Item("246$b")
                                End If
                                arrFieldValue(11) = arrFieldValue(11).ToString.Trim()
                                'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
                            End If

                        End If

                    Catch ex As Exception
                        arrFieldName(11) = Nothing
                        arrFieldValue(11) = Nothing
                    End Try

                    '250$a 250$b
                    Try
                        strPublisher = ""
                        arrFieldName(12) = Nothing
                        arrFieldValue(12) = Nothing
                        If (CheckExistColumn("250", tbl)) Then

                            If (CheckExistColumn("250$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("250$a") & ""))) Then
                                arrFieldName(12) = "250"
                                arrFieldValue(12) = arrFieldValue(12) & "" & "$a" & row.Item("250$a")
                                arrFieldValue(12) = arrFieldValue(12).ToString.Trim()
                                'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
                            End If

                            If (CheckExistColumn("250$b", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("250$b") & ""))) Then
                                arrFieldName(12) = "250"
                                If (Not IsNothing(arrFieldValue(12))) Then
                                    arrFieldValue(12) = arrFieldValue(12) & "" & " $c" & row.Item("250$b")
                                Else
                                    arrFieldValue(12) = arrFieldValue(12) & "" & " $c" & row.Item("250$b")
                                End If
                                arrFieldValue(12) = arrFieldValue(12).ToString.Trim()
                                'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
                            End If
                            strPublisher = arrFieldValue(12)
                        End If

                        If strPublisher = "" Then
                            strPublisher = strPublisherPre
                        End If

                    Catch ex As Exception
                        arrFieldName(12) = Nothing
                        arrFieldValue(12) = Nothing
                    End Try

                    '260$a	
                    '260$b	
                    '260$c	
                    '------ 260$aTho: $bVu, $cSon
                    Try
                        strPublishYear = ""
                        arrFieldName(13) = Nothing
                        arrFieldValue(13) = Nothing
                        If (CheckExistColumn("260", tbl)) Then
                            If (CheckExistColumn("260$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("260$a") & ""))) Then
                                arrFieldName(13) = "260"
                                arrFieldValue(13) = arrFieldValue(13) & "" & "$a" & row.Item("260$a")
                                arrFieldValue(13) = arrFieldValue(13).ToString.Trim()
                                'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
                            End If

                            If (CheckExistColumn("260$b", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("260$b") & ""))) Then
                                arrFieldName(13) = "260"
                                If (Not IsNothing(arrFieldValue(13))) Then
                                    arrFieldValue(13) = arrFieldValue(13) & "" & " $b" & row.Item("260$b")
                                Else
                                    arrFieldValue(13) = arrFieldValue(13) & "" & " $b" & row.Item("260$b")
                                End If
                                arrFieldValue(13) = arrFieldValue(13).ToString.Trim()
                                'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
                            End If

                            If (CheckExistColumn("260$c", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("260$c") & ""))) Then
                                arrFieldName(13) = "260"
                                If (Not IsNothing(arrFieldValue(13))) Then
                                    arrFieldValue(13) = arrFieldValue(13) & "" & " $c" & row.Item("260$c")
                                Else
                                    arrFieldValue(13) = arrFieldValue(13) & "" & " $c" & row.Item("260$c")
                                End If
                                arrFieldValue(13) = arrFieldValue(13).ToString.Trim()
                                'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
                            End If

                            strPublishYear = arrFieldValue(13)
                        End If

                        If strPublishYear = "" Then
                            strPublishYear = strPublishYearPre
                        End If

                    Catch ex As Exception
                        arrFieldName(13) = Nothing
                        arrFieldValue(13) = Nothing
                    End Try

                    '300$a	
                    '300$b	
                    '300$c	
                    '300$e
                    '------ 300$aTho: $bVu; $cSon+ $ePhuong
                    Try
                        arrFieldName(14) = Nothing
                        arrFieldValue(14) = Nothing
                        If (CheckExistColumn("300", tbl)) Then

                            If (CheckExistColumn("300$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("300$a") & ""))) Then
                                arrFieldName(14) = "300"
                                arrFieldValue(14) = arrFieldValue(14) & "" & "$a" & row.Item("300$a")
                                arrFieldValue(14) = arrFieldValue(14).ToString.Trim()
                                'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
                            End If

                            If (CheckExistColumn("300$b", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("300$b") & ""))) Then
                                arrFieldName(14) = "300"
                                If (Not IsNothing(arrFieldValue(14))) Then
                                    arrFieldValue(14) = arrFieldValue(14) & "" & " $b" & row.Item("300$b")
                                Else
                                    arrFieldValue(14) = arrFieldValue(14) & "" & " $b" & row.Item("300$b")
                                End If
                                arrFieldValue(14) = arrFieldValue(14).ToString.Trim()
                                'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
                            End If

                            If (CheckExistColumn("300$c", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("300$c") & ""))) Then
                                arrFieldName(14) = "300"
                                If (Not IsNothing(arrFieldValue(14))) Then
                                    arrFieldValue(14) = arrFieldValue(14) & "" & " $c" & row.Item("300$c")
                                Else
                                    arrFieldValue(14) = arrFieldValue(14) & "" & " $c" & row.Item("300$c")
                                End If
                                arrFieldValue(14) = arrFieldValue(14).ToString.Trim()
                                'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
                            End If

                            If (CheckExistColumn("300$e", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("300$e") & ""))) Then
                                arrFieldName(14) = "300"
                                If (Not IsNothing(arrFieldValue(14))) Then
                                    arrFieldValue(14) = arrFieldValue(14) & "" & " $e" & row.Item("300$e")
                                Else
                                    arrFieldValue(14) = arrFieldValue(14) & "" & " $e" & row.Item("300$e")
                                End If
                                arrFieldValue(14) = arrFieldValue(14).ToString.Trim()
                                'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
                            End If
                        End If

                    Catch ex As Exception
                        arrFieldName(14) = Nothing
                        arrFieldValue(14) = Nothing
                    End Try

                    '440$a
                    Try
                        arrFieldName(15) = Nothing
                        arrFieldValue(15) = Nothing
                        If (CheckExistColumn("440", tbl)) Then
                            If (CheckExistColumn("440$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("440$a") & ""))) Then
                                arrFieldName(15) = "440"
                                arrFieldValue(15) = "$a" & row.Item("440$a")
                            End If

                        End If
                    Catch ex As Exception
                        arrFieldName(15) = Nothing
                        arrFieldValue(15) = Nothing
                    End Try

                    '490$a	
                    Try
                        arrFieldName(16) = Nothing
                        arrFieldValue(16) = Nothing
                        If (CheckExistColumn("490", tbl)) Then
                            If (CheckExistColumn("490$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("490$a") & ""))) Then
                                arrFieldName(16) = "490"
                                arrFieldValue(16) = "$a" & row.Item("490$a")
                            End If

                        End If
                    Catch ex As Exception
                        arrFieldName(16) = Nothing
                        arrFieldValue(16) = Nothing
                    End Try

                    '500$a	
                    Try
                        arrFieldName(17) = Nothing
                        arrFieldValue(17) = Nothing
                        If (CheckExistColumn("500", tbl)) Then
                            If (CheckExistColumn("500$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("500$a") & ""))) Then
                                arrFieldName(17) = "500"
                                arrFieldValue(17) = "$a" & row.Item("500$a")
                            End If

                        End If

                    Catch ex As Exception
                        arrFieldName(17) = Nothing
                        arrFieldValue(17) = Nothing
                    End Try

                    '520$a	
                    Try
                        arrFieldName(18) = Nothing
                        arrFieldValue(18) = Nothing
                        If (CheckExistColumn("520", tbl)) Then
                            If (CheckExistColumn("520$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("520$a") & ""))) Then
                                arrFieldName(18) = "520"
                                arrFieldValue(18) = "$a" & row.Item("520$a")
                            End If

                        End If

                    Catch ex As Exception
                        arrFieldName(18) = Nothing
                        arrFieldValue(18) = Nothing
                    End Try


                    '650$a	
                    '------ $650$aVu
                    Try
                        arrFieldName(19) = Nothing
                        arrFieldValue(19) = Nothing
                        If (CheckExistColumn("650", tbl)) Then
                            If (CheckExistColumn("650$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("650$a") & ""))) Then
                                arrFieldName(19) = "650"
                                arrFieldValue(19) = "$a" & row.Item("650$a")
                                'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField000S", arrFieldValue(11), itemId, 41)
                            End If

                        End If

                    Catch ex As Exception
                        arrFieldName(19) = Nothing
                        arrFieldValue(19) = Nothing
                    End Try


                    '653$a	
                    Try
                        arrFieldName(20) = Nothing
                        arrFieldValue(20) = Nothing
                        If (CheckExistColumn("653", tbl)) Then
                            If (CheckExistColumn("653$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("653$a") & ""))) Then
                                arrFieldName(20) = "653"
                                arrFieldValue(20) = "$a" & row.Item("653$a")
                            End If

                        End If

                    Catch ex As Exception
                        arrFieldName(20) = Nothing
                        arrFieldValue(20) = Nothing
                    End Try

                    '691$a	
                    Try
                        arrFieldName(21) = Nothing
                        arrFieldValue(21) = Nothing
                        If (CheckExistColumn("691", tbl)) Then
                            If (CheckExistColumn("691$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("691$a") & ""))) Then
                                arrFieldName(21) = "691"
                                arrFieldValue(21) = "$a" & row.Item("691$a")
                            End If

                        End If

                    Catch ex As Exception
                        arrFieldName(21) = Nothing
                        arrFieldValue(21) = Nothing
                    End Try


                    '700$a	
                    '------ 700$aTho
                    Try
                        arrFieldName(22) = Nothing
                        arrFieldValue(22) = Nothing
                        If (CheckExistColumn("700", tbl)) Then
                            If (CheckExistColumn("700$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("700$a") & ""))) Then
                                arrFieldName(22) = "700"
                                arrFieldValue(22) = "$a" & row.Item("700$a")
                            End If
                        End If

                    Catch ex As Exception
                        arrFieldName(22) = Nothing
                        arrFieldValue(22) = Nothing
                    End Try

                    '710$a
                    Try
                        arrFieldName(23) = Nothing
                        arrFieldValue(23) = Nothing
                        If (CheckExistColumn("710", tbl)) Then
                            If (CheckExistColumn("710$a", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("710$a") & ""))) Then
                                arrFieldName(23) = "710"
                                arrFieldValue(23) = "$a" & row.Item("710$a")
                            End If

                        End If

                    Catch ex As Exception
                        arrFieldName(23) = Nothing
                        arrFieldValue(23) = Nothing
                    End Try

                    'Try
                    '    arrFieldName(9) = Nothing
                    '    arrFieldValue(9) = Nothing
                    '    If (CheckExistColumn("856", tbl)) Then
                    '        If (CheckExistColumn("856$f", tbl) AndAlso Not (String.IsNullOrEmpty(row.Item("856$f") & ""))) Then
                    '            arrFieldName(9) = "856"
                    '            arrFieldValue(9) = "$f" & row.Item("856$f")
                    '        End If
                    '        'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField800S", arrFieldValue(9), itemId, 852)
                    '    End If
                    'Catch ex As Exception
                    '    arrFieldName(9) = Nothing
                    '    arrFieldValue(9) = Nothing
                    'End Try

                    Dim strCopyNumber As String = row.Item("852$j") & ""
                    Dim strNumberCopies As String = row.Item("852$t") & ""
                    Dim strLoanType As String = row.Item("942$c") & ""
                    Dim strBarCode As String = row.Item("Tạo bản tài liệu$p") & ""
                    Dim strLocation As String = row.Item("Tạo bản tài liệu$c") & ""
                    Dim strShelf As String = row.Item("Tạo bản tài liệumục 8 - h") & ""
                    Dim strAcqSource As String = row.Item("Tạo bản tài liệumục 8 - e") & ""
                    Dim strAdditionalBy As String = row.Item("Tạo bản tài liệumục 8 - f") & ""
                    Dim strStatusNote As String = row.Item("Tạo bản tài liệumục 7") & ""
                    Dim strPrice As String = row.Item("Tạo bản tài liệumục 8 - g") & ""
                    Dim strDateCreate As String = row.Item("008") & ""
                    Dim strItemType As String = row.Item("927") & ""
                    Dim strCataloguerName As String = row.Item("911$a") & ""

                    If strDateCreate = "" Then
                        strDateCreate = String.Format("{0:dd/MM/yyyy}", Date.Now)
                    End If


                    If Not IsNumeric(strPrice) Then
                        strPrice = "0"
                    End If

                    Try
                        arrFieldName(24) = "911"
                        arrFieldValue(24) = strCataloguerName 'clsSession.GlbUserFullName
                        'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField900S", arrFieldValue(4), itemId, 911)
                    Catch ex As Exception
                        arrFieldName(24) = Nothing
                        arrFieldValue(24) = Nothing
                    End Try


                    Try
                        arrFieldName(25) = "925"
                        arrFieldValue(25) = "G"
                        'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField900S", arrFieldValue(5), itemId, 925)
                    Catch ex As Exception
                        arrFieldName(25) = Nothing
                        arrFieldValue(25) = Nothing
                    End Try


                    Try
                        arrFieldName(26) = "926"
                        arrFieldValue(26) = "0"
                        'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField900S", arrFieldValue(6), itemId, 926)
                    Catch ex As Exception
                        arrFieldName(26) = Nothing
                        arrFieldValue(26) = Nothing
                    End Try


                    Try
                        arrFieldName(27) = "927"
                        'arrFieldValue(7) = "LA"
                        'arrFieldValue(27) = ddlFormatType.SelectedItem.Value
                        'arrFieldValue(27) = ReferrenceItemType(strLoanType)
                        Dim strItemTypeTmp As String = "S"
                        If Not IsNothing(ddlFormatType.Items.FindByValue(strItemType)) Then
                            strItemTypeTmp = ddlFormatType.Items.FindByValue(strItemType).Value
                        End If
                        arrFieldValue(27) = strItemTypeTmp
                        'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField900S", arrFieldValue(7), itemId, 927)
                    Catch ex As Exception
                        arrFieldName(27) = Nothing
                        arrFieldValue(27) = Nothing
                    End Try


                    Try
                        arrFieldName(28) = "900"
                        arrFieldValue(28) = "1"
                        'textQuery = textQuery & " " & objBInput.GetTextQueryField("Lib_tblField900S", arrFieldValue(8), itemId, 900)
                    Catch ex As Exception
                        arrFieldName(28) = Nothing
                        arrFieldValue(28) = Nothing
                    End Try

                    For j As Integer = 4 To 28
                        If (IsNothing(arrFieldValue(j))) Or (String.IsNullOrEmpty(arrFieldValue(j))) Then
                            arrFieldName(j) = Nothing
                            arrFieldValue(j) = Nothing
                        End If
                    Next

                    ' import to data
                    objBInput.FieldName = arrFieldName

                    objBInput.FieldValue = arrFieldValue
                    objBInput.LibID = clsSession.GlbSite


                    objBInput.SQL = "select * from Lib_tblHolding where Lib_tblHolding.CopyNumber = '" & strCopyNumber & "'"
                    Dim tblDataCheckCopyNumber As DataTable = objBInput.GetData()
                    objBInput.SQL = ""


                    Dim boolExist As Boolean = True
                    If strPublishYear <> strPublishYearPre Then
                        boolExist = False
                    End If
                    If strPublisher <> strPublisherPre Then
                        boolExist = False
                    End If
                    If strAuthor <> strAuthorPre Then
                        boolExist = False
                    End If
                    If strTitle <> strTitlePre Then
                        boolExist = False
                    End If

                    If (Not IsNothing(tblDataCheckCopyNumber)) AndAlso (tblDataCheckCopyNumber.Rows.Count > 0) Then
                        listCopyNumber.Add(strCopyNumber)
                        strTitle = "Duplicate-CopyNumber"
                        strTitlePre = ""
                    Else
                        If Not boolExist Then
                            If Session("IsAuthority") = 1 Then
                                If objBInput.UpdateAuthority(4, 1) = 1 Then
                                    itemId = Integer.Parse(objBInput.WorkID.ToString())

                                    If itemId > 0 Then
                                        Dim listColumn650a As List(Of String) = GetListColumns("650$a", tbl)
                                        For Each column As String In listColumn650a
                                            If row.Item(column) & "" <> "" Then
                                                textQuery = objBInput.GetTextQueryField("Lib_tblField600S", Left(column.Replace("650", ""), 2) & row.Item(column), itemId, 650, 0)
                                                If objBInput.ExcuteQueryByScript(textQuery) = 1 Then
                                                    textQuery = "exec Cat_spDicSh_Ins N'" & row.Item(column) & "', " & itemId & ", '650$a'"
                                                    objBInput.ExcuteQueryByScript(textQuery)
                                                End If
                                            End If

                                        Next

                                        Dim listColumn700a As List(Of String) = GetListColumns("700$a", tbl)
                                        For Each column As String In listColumn700a
                                            If row.Item(column) & "" <> "" Then
                                                textQuery = objBInput.GetTextQueryField("Lib_tblField700S", Left(column.Replace("700", ""), 2) & row.Item(column), itemId, 700, 0)
                                                If objBInput.ExcuteQueryByScript(textQuery) = 1 Then
                                                    textQuery = "exec Cat_spDicAuthor_Ins N'" & row.Item(column) & "', " & itemId & ", '700$a'"
                                                    objBInput.ExcuteQueryByScript(textQuery)
                                                End If
                                            End If
                                        Next

                                        Call InsertHoding(strCopyNumber, itemId, strNumberCopies, strLoanType, strBarCode, strLocation, strShelf, strAcqSource, strAdditionalBy, "", strStatusNote, CType(strPrice, Double), strDateCreate, Date.Now, clsSession.GlbUserFullName, clsSession.GlbUserFullName)
                                        'objBInput.SQL = "select * from Lib_tblHolding where Lib_tblHolding.CopyNumber = '" & strCopyNumber & "'"
                                        'tblDataCheckCopyNumber = objBInput.GetData()

                                        'If (Not IsNothing(tblDataCheckCopyNumber)) AndAlso tblDataCheckCopyNumber.Rows.Count = 1 Then
                                        '    Dim strHoldingID As String = tblDataCheckCopyNumber.Rows(0).Item("ID") & ""
                                        '    textQuery = "insert into Lib_tblItemLocationVANLANG(HoldingID,MaKho) values (" & strHoldingID & ",N'" & strLocation & "')"
                                        '    objBInput.ExcuteQueryByScript(textQuery)

                                        '    textQuery = "insert into Lib_tblItemLoanTypeVANLANG(HoldingID,MaLoai) values (" & strHoldingID & ",N'" & strLoanType & "')"
                                        '    objBInput.ExcuteQueryByScript(textQuery)
                                        'End If

                                        countSusscess = countSusscess + 1
                                    End If

                                End If
                            Else
                                If objBInput.Update(4, 0) = 1 Then ' 4
                                    itemId = Integer.Parse(objBInput.WorkID.ToString())

                                    If itemId > 0 Then
                                        Dim listColumn650a As List(Of String) = GetListColumns("650$a", tbl)
                                        For Each column As String In listColumn650a
                                            If row.Item(column) & "" <> "" Then
                                                textQuery = objBInput.GetTextQueryField("Lib_tblField600S", Left(column.Replace("650", ""), 2) & row.Item(column), itemId, 650, 0)
                                                If objBInput.ExcuteQueryByScript(textQuery) = 1 Then
                                                    textQuery = "exec Cat_spDicSh_Ins N'" & row.Item(column) & "', " & itemId & ", '650$a'"
                                                    objBInput.ExcuteQueryByScript(textQuery)
                                                End If
                                            End If

                                        Next

                                        Dim listColumn700a As List(Of String) = GetListColumns("700$a", tbl)
                                        For Each column As String In listColumn700a
                                            If row.Item(column) & "" <> "" Then
                                                textQuery = objBInput.GetTextQueryField("Lib_tblField700S", Left(column.Replace("700", ""), 2) & row.Item(column), itemId, 700, 0)
                                                If objBInput.ExcuteQueryByScript(textQuery) = 1 Then
                                                    textQuery = "exec Cat_spDicAuthor_Ins N'" & row.Item(column) & "', " & itemId & ", '700$a'"
                                                    objBInput.ExcuteQueryByScript(textQuery)
                                                End If
                                            End If
                                        Next

                                        Call InsertHoding(strCopyNumber, itemId, strNumberCopies, strLoanType, strBarCode, strLocation, strShelf, strAcqSource, strAdditionalBy, "", strStatusNote, CType(strPrice, Double), strDateCreate, Date.Now, clsSession.GlbUserFullName, clsSession.GlbUserFullName)
                                        'objBInput.SQL = "select * from Lib_tblHolding where Lib_tblHolding.CopyNumber = '" & strCopyNumber & "'"
                                        'tblDataCheckCopyNumber = objBInput.GetData()

                                        'If (Not IsNothing(tblDataCheckCopyNumber)) AndAlso tblDataCheckCopyNumber.Rows.Count = 1 Then
                                        '    Dim strHoldingID As String = tblDataCheckCopyNumber.Rows(0).Item("ID") & ""
                                        '    textQuery = "insert into Lib_tblItemLocationVANLANG(HoldingID,MaKho) values (" & strHoldingID & ",N'" & strLocation & "')"
                                        '    objBInput.ExcuteQueryByScript(textQuery)

                                        '    textQuery = "insert into Lib_tblItemLoanTypeVANLANG(HoldingID,MaLoai) values (" & strHoldingID & ",N'" & strLoanType & "')"
                                        '    objBInput.ExcuteQueryByScript(textQuery)
                                        'End If

                                        countSusscess = countSusscess + 1
                                    End If

                                End If
                            End If
                        Else
                            If itemId > 0 Then


                                If strTitle <> "Duplicate-CopyNumber" Then
                                    If strPrice <> "0" Then
                                        strPricePre = strPrice
                                    Else
                                        strPrice = strPricePre
                                    End If
                                    Call InsertHoding(strCopyNumber, itemId, strNumberCopies, strLoanType, strBarCode, strLocation, strShelf, strAcqSource, strAdditionalBy, "", strStatusNote, CType(strPrice, Double), strDateCreate, Date.Now, clsSession.GlbUserFullName, clsSession.GlbUserFullName)
                                    countSusscess = countSusscess + 1
                                End If


                                'objBInput.SQL = "select * from Lib_tblHolding where Lib_tblHolding.CopyNumber = '" & strCopyNumber & "'"
                                'Dim tblDataCheckCopyNumber As DataTable = objBInput.GetData()

                                'If (Not IsNothing(tblDataCheckCopyNumber)) AndAlso tblDataCheckCopyNumber.Rows.Count = 1 Then
                                '    Dim strHoldingID As String = tblDataCheckCopyNumber.Rows(0).Item("ID") & ""
                                '    textQuery = "insert into Lib_tblItemLocationVANLANG(HoldingID,MaKho) values (" & strHoldingID & ",N'" & strLocation.Trim() & "')"
                                '    objBInput.ExcuteQueryByScript(textQuery)

                                '    textQuery = "insert into Lib_tblItemLoanTypeVANLANG(HoldingID,MaLoai) values (" & strHoldingID & ",N'" & strLoanType.Trim() & "')"
                                '    objBInput.ExcuteQueryByScript(textQuery)
                                'End If
                            End If
                        End If
                    End If

                    strTitlePre = strTitle
                    strAuthorPre = strAuthor
                    strPublisherPre = strPublisher
                    strPublishYearPre = strPublishYear
                    strPricePre = strPrice

                    'objBInput.ExcuteQueryByScript(textQuery)


                Catch ex As Exception
                    listError.Add((i).ToString())
                End Try

                Call BindPrg(i, tbl.Rows.Count)
            Next

            lbSuccess.Text = "<i>Số dòng đã thực hiện thành công: </i><b><u>" & countSusscess & "</u></b>"

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
            If listCopyNumber.Count > 0 Then
                lbCopyNumberExist.Text = "Những ĐKCB đã tồn tại: "
                For Each item As String In listCopyNumber
                    lbCopyNumberExist.Text += item.ToString() + "; "
                Next
            Else

            End If
        End Sub

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

                    Dim arrField As New List(Of String)
                    For Each firstRowCell In ws.Cells(1, 1, 1, ws.Dimension.End.Column)
                        arrField.Add(firstRowCell.Text.Replace(vbLf, ""))
                    Next

                    Dim arrDollar As New List(Of String)
                    For Each firstRowCell In ws.Cells(2, 1, 2, ws.Dimension.End.Column)
                        arrDollar.Add(firstRowCell.Text)
                    Next

                    Dim intTemp As Integer = 2
                    Dim strColumnName As String = ""
                    Dim strColumnNamePre As String = ""

                    For i As Integer = 0 To arrField.Count - 1
                        strColumnName = arrField(i) & arrDollar(i)
                        If tbl.Columns.Count > 0 Then
                            If strColumnName = strColumnNamePre Then
                                If Not IsNothing(tbl.Columns(strColumnName)) Then
                                    tbl.Columns(strColumnName).ColumnName = strColumnName & "1"
                                End If
                                tbl.Columns.Add(strColumnName & intTemp)
                                intTemp = intTemp + 1
                            Else
                                intTemp = 2
                                tbl.Columns.Add(strColumnName)
                            End If
                        Else
                            tbl.Columns.Add(strColumnName)
                        End If
                        strColumnNamePre = strColumnName
                    Next

                    ' add rows to DataTable '
                    For rowNum = 4 To ws.Dimension.End.Row
                        Dim wsRow = ws.Cells(rowNum, 1, rowNum, If(ws.Dimension.End.Column > arrField.Count, arrField.Count, ws.Dimension.End.Column))
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
            'Dim tbView As DataView = tbl.DefaultView()
            'tbView.Sort = "245$a ASC"
            'tbl = tbView.ToTable()
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

        Private Sub InsertHoding(ByVal strCopyNumber As String, ByVal jItemID As Integer, ByVal strNumberCopies As String, ByVal strLoanType As String, ByVal strBarCode As String, ByVal strLocation As String, ByVal strShelf As String, ByVal strAcqSource As String,
                                  ByVal strAdditionalBy As String, ByVal strStatusCode As String, ByVal strStatusNode As String, ByVal intPrice As Double, ByVal strDateCreate As Date, ByVal strDateUpdate As Date, ByVal strNameCreate As String, ByVal strNameUpdate As String)
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

                Dim strLoanTypeReferrence As String = strLoanType 'ReferrenceLoanTypeDHVL(strLoanType) 'strLoanType 'ReferrenceLoanType(strLoanType)
                objBLoanType.LoanTypeCode = strLoanTypeReferrence
                Dim tblLoanType As DataTable = objBLoanType.GetLoanTypesByLoanTypeCode()
                Dim intLoanTypeID As Integer = 0
                If Not IsNothing(tblLoanType) AndAlso tblLoanType.Rows.Count > 0 Then
                    intLoanTypeID = tblLoanType.Rows(0).Item("ID") & ""
                End If

                Dim intAcqSourceID As Integer = 0
                Dim tblAcqSource As DataTable = objBCopyNumber.GetAcqSource(strAcqSource)
                If Not IsNothing(tblAcqSource) AndAlso tblAcqSource.Rows.Count > 0 Then
                    intAcqSourceID = tblAcqSource.Rows(0).Item("ID") & ""
                End If

                Dim strStatusCodeTmp As String = strStatusCode
                Dim strStatusNoteTmp As String = strStatusNode
                Dim intInCurculation As Integer = 0
                Dim intAcquired As Integer = 0

                If String.IsNullOrEmpty(strStatusCode) Then
                    Dim tblHoldingStatus As DataTable = objBCopyNumber.GetStatusByNote(strStatusNode)
                    If Not IsNothing(tblHoldingStatus) AndAlso tblHoldingStatus.Rows.Count > 0 Then
                        strStatusCodeTmp = tblHoldingStatus.Rows(0).Item("StatusCode") & ""
                        strStatusNoteTmp = tblHoldingStatus.Rows(0).Item("StatusNote") & ""
                        intAcquired = If(CBool(tblHoldingStatus.Rows(0).Item("Acquired")), 1, 0)
                        intInCurculation = If(CBool(tblHoldingStatus.Rows(0).Item("InCirculation")), 1, 0)
                    End If
                Else
                    Dim tblHoldingStatus As DataTable = objBCopyNumber.GetStatusByCode(strStatusCode)
                    If Not IsNothing(tblHoldingStatus) AndAlso tblHoldingStatus.Rows.Count > 0 Then
                        strStatusCodeTmp = tblHoldingStatus.Rows(0).Item("StatusCode") & ""
                        strStatusNoteTmp = tblHoldingStatus.Rows(0).Item("StatusNote") & ""
                        intAcquired = If(CBool(tblHoldingStatus.Rows(0).Item("Acquired")), 1, 0)
                        intInCurculation = If(CBool(tblHoldingStatus.Rows(0).Item("InCirculation")), 1, 0)
                    End If
                End If


                objBCopyNumber.Code = strItemID
                objBCopyNumber.HolLibID = intLibID
                objBCopyNumber.LoanTypeID = intLoanTypeID
                objBCopyNumber.StartHolding = strCopyNumber
                objBCopyNumber.Price = intPrice
                objBCopyNumber.Range = 1
                objBCopyNumber.LocID = intHolID
                objBCopyNumber.ChangeDate = Format(Date.Now, "dd/MM/yyyy")
                objBCopyNumber.Shelf = strShelf
                objBCopyNumber.AcqSourceID = intAcqSourceID
                objBCopyNumber.AdditionalBy = strAdditionalBy
                objBCopyNumber.NumberCopies = strNumberCopies
                objBCopyNumber.BarCode = strBarCode
                objBCopyNumber.StatusNode = strStatusNoteTmp
                objBCopyNumber.StatusCode = strStatusCodeTmp
                objBCopyNumber.DateCreate = strDateCreate
                objBCopyNumber.DateUpdate = strDateUpdate

                ' Add Holding
                Dim bytErrAddHold As Byte
                bytErrAddHold = objBCopyNumber.Create(strNameCreate, strNameUpdate, intInCurculation, intAcquired)
            Catch ex As Exception
            End Try
        End Sub

        Protected Sub btnDownloadFile_Click(sender As Object, e As EventArgs) Handles btnDownloadFile.Click
            Dim strTime As String = DateAndTime.Now.Year & DateAndTime.Now.Month & DateAndTime.Now.Day & DateAndTime.Now.Hour & DateAndTime.Now.Minute & DateAndTime.Now.Second & DateAndTime.Now.Millisecond
            Response.Clear()
            Response.AddHeader("content-disposition", "attachment;filename=Template_Import_BienMuc_" & strTime & ".xlsx")
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            Response.WriteFile(Server.MapPath("../../Template/Template_Import_BienMuc.xlsx"))
            Response.Flush()
            Response.End()
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

    End Class
End Namespace