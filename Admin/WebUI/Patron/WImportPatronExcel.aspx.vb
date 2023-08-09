' Class: WMarcFieldsDefault
' Purpose: Set default value for some fields
' Creator: KhoaNA
' CreatedDate: 16/03/2004
' Modification Historiy
'   - 22/02/2005 by Tuanhv: Repaid form

Imports System.IO
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Patron
Imports OfficeOpenXml

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WImportPatronExcel
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
        Private objBPatronGroup As New clsBPatronGroup
        Private objBEthnic As New clsBEthnic
        Private objBEducation As New clsBEducation
        Private objBCollege As New clsBCollege
        Private objBInput As New clsBInput
        Private objBPatron As New eMicLibAdmin.BusinessRules.Patron.clsBPatron
        Private objBItemCollection As New clsBItemCollection
        Private objBCopyNumber As New clsBCopyNumber
        Private objBLoanType As New clsBLoanType
        Private objBFaculty As New clsBFaculty

        Private objBLocation As New clsBLocation
        Dim tblTable As DataTable
        Dim dvDefaultView As DataView
        Dim strPrefix As String = ""

        ' Private objBValidate As New clsBCataDefault
        Private objBValidate As New clsBValidate
        Private objBField As New clsBField

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim tblFields As DataTable
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()

        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(1) Then
                Call WriteErrorMssg(ddlLabel.Items(8).Text.Trim)
            End If
        End Sub

        ' BindJS method
        ' Purpose: include all neccessary javascript functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
        End Sub

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

            'objBPatron
            objBPatron.InterfaceLanguage = Session("InterfaceLanguage")
            objBPatron.DBServer = Session("DBServer")
            objBPatron.ConnectionString = Session("ConnectionString")
            Call objBPatron.Initialize()



            'objBCollege
            objBCollege.InterfaceLanguage = Session("InterfaceLanguage")
            objBCollege.DBServer = Session("DBServer")
            objBCollege.ConnectionString = Session("ConnectionString")
            Call objBCollege.Initialize()

            'objBEducation
            objBEducation.InterfaceLanguage = Session("InterfaceLanguage")
            objBEducation.DBServer = Session("DBServer")
            objBEducation.ConnectionString = Session("ConnectionString")
            Call objBEducation.Initialize()

            'objBEthnic
            objBEthnic.InterfaceLanguage = Session("InterfaceLanguage")
            objBEthnic.DBServer = Session("DBServer")
            objBEthnic.ConnectionString = Session("ConnectionString")
            Call objBEthnic.Initialize()
            '
            'objBPatronGroup
            objBPatronGroup.InterfaceLanguage = Session("InterfaceLanguage")
            objBPatronGroup.DBServer = Session("DBServer")
            objBPatronGroup.ConnectionString = Session("ConnectionString")
            Call objBPatronGroup.Initialize()
            'objBFaculty
            objBFaculty.InterfaceLanguage = Session("InterfaceLanguage")
            objBFaculty.DBServer = Session("DBServer")
            objBFaculty.ConnectionString = Session("ConnectionString")
            Call objBFaculty.Initialize()
            '
        End Sub

        ' InsertSession method
        ' Purpose: Get content for field name, field value





        ' UpdateSession method
        ' Purpose: Get content for field name, field value if you update one field
        Sub UpdateSession(ByVal strFieldName As String, ByVal strInd As String, ByVal strFieldValueNew As String, ByVal strFieldValueOld As String, ByVal intCheckInd As Integer)
            Dim arrValues As Object

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
        Protected Sub btnImportData_Click(sender As Object, e As EventArgs) Handles btnImportData.Click
            Try
                If (FileUpload1.HasFile AndAlso (IO.Path.GetExtension(FileUpload1.FileName) = ".xls" Or IO.Path.GetExtension(FileUpload1.FileName) = ".xlsx")) Then
                    Using excel = New ExcelPackage(FileUpload1.PostedFile.InputStream)
                        Dim tbl = New DataTable()
                        Dim TotalRowsImport As Integer = 0
                        Dim count As Integer = 0
                        Dim countPatronError As Integer = 0
                        Dim patronloop As Integer = 0
                        Dim Table, errorTable As New DataTable
                        Dim rowresult, errorRowresult As DataRow
                        Table.Columns.Add("STT")
                        Table.Columns.Add("Mã số bạn đọc")
                        Table.Columns.Add("Tên bạn đọc")
                        Table.Columns.Add("Ghi chú")

                        errorTable.Columns.Add("STT")
                        errorTable.Columns.Add("Mã số bạn đọc")
                        errorTable.Columns.Add("Tên bạn đọc")
                        errorTable.Columns.Add("STT trên file")
                        errorTable.Columns.Add("Ghi chú")

                        Dim ws = excel.Workbook.Worksheets.First()
                        Dim hasHeader = True ' change it if required '
                        ' create DataColumns '
                        For Each firstRowCell In ws.Cells(1, 1, 1, ws.Dimension.End.Column)
                            tbl.Columns.Add(If(hasHeader,
                                               firstRowCell.Text,
                                               String.Format("Column {0}", firstRowCell.Start.Column)))
                        Next
                        ' add rows to DataTable '
                        Dim startRow = If(hasHeader, 1, 1)
                        For rowNum = startRow To ws.Dimension.End.Row
                            Dim wsRow = ws.Cells(rowNum, 1, rowNum, ws.Dimension.End.Column)
                            Dim row = tbl.NewRow()
                            For Each cell In wsRow
                                row(cell.Start.Column - 1) = cell.Text
                            Next
                            tbl.Rows.Add(row)
                        Next

                        Response.Write("<div class='lbLabel' style=' margin:0;top:250;left:0; width:100%;'>")
                        Response.Write("<p style='position:absolute; left:45%;'>Nhập khẩu dữ liệu: <span id='pgbMain_label'>0%</span></p>")
                        Response.Write("<p style='padding-top:35px;'><table width='0%' border=2 bordercolor='white' id='pgbMain' bgcolor=blue><tr style='HEIGHT: 18px'><td></td></tr></table></p>")
                        Response.Write("</div>")



                        For i As Integer = 1 To tbl.Rows.Count - 1
                            Dim row As DataRow = tbl.Rows(i)
                            If (Not String.IsNullOrEmpty(row.Item("STT").ToString())) Then
                                Try
                                    '----- Mã bạn đọc (Số thẻ)
                                    Try
                                        If (Not String.IsNullOrEmpty(row.Item("Số thẻ").ToString())) Then
                                            objBPatron.Code = row.Item("Số thẻ")
                                            TotalRowsImport += 1
                                        End If
                                    Catch ex As Exception

                                    End Try
                                    ' họ và tên lót
                                    Try
                                        If (Not String.IsNullOrEmpty(row.Item("Họ và tên lót").ToString())) Then
                                            If InStr(row.Item("Họ và tên lót").ToString.Trim, " ") > 0 Then
                                                objBPatron.FirstName = Left(row.Item("Họ và tên lót").ToString.Trim, InStr(row.Item("Họ và tên lót").ToString.Trim, " ")).Trim()
                                                objBPatron.MiddleName = Right(row.Item("Họ và tên lót").ToString.Trim, Len(row.Item("Họ và tên lót").ToString.Trim) - InStr(row.Item("Họ và tên lót").ToString.Trim, " ")).Trim()
                                            Else
                                                objBPatron.FirstName = row.Item("Họ và tên lót").ToString.Trim
                                            End If
                                        End If
                                    Catch ex As Exception

                                    End Try
                                    '-----Tên bạn đọc
                                    Try
                                        If (Not String.IsNullOrEmpty(row.Item("Tên").ToString())) Then
                                            objBPatron.LastName = row.Item("Tên").ToString.Trim
                                        End If
                                    Catch ex As Exception

                                    End Try
                                    '----- Ngày sinh
                                    Try
                                        If (Not String.IsNullOrEmpty(row.Item("Ngày sinh").ToString())) Then
                                            Dim tempDate As String = row.Item("Ngày sinh").ToString()
                                            Dim splitDate() As String = tempDate.Split("/")
                                            Dim dateResult As DateTime = New DateTime(CType(splitDate(2), Integer), If(CType(splitDate(1), Integer) = 0, 1, CType(splitDate(1), Integer)), If(CType(splitDate(0), Integer) = 0, 1, CType(splitDate(0), Integer)))
                                            objBPatron.DOB = dateResult.ToShortDateString()
                                        End If
                                    Catch ex As Exception

                                    End Try
                                    '----- Giới tính
                                    Try
                                        If (Not String.IsNullOrEmpty(row.Item("Giới tính").ToString())) Then
                                            objBPatron.Sex = If(row.Item("Giới tính").ToString() = "1", True, False)
                                        End If
                                    Catch ex As Exception

                                    End Try
                                    '-----Dân tộc
                                    Try
                                        If (Not String.IsNullOrEmpty(row.Item("Dân tộc").ToString())) Then
                                            Dim strEthnic = row.Item("Dân tộc").ToString()
                                            Dim tblEthnic = objBEthnic.GetEthnicByName(strEthnic)
                                            objBPatron.EthnicID = tblEthnic.Rows(0).Item("ID")
                                        End If
                                    Catch ex As Exception

                                    End Try
                                    '----- Email
                                    Try
                                        If (Not String.IsNullOrEmpty(row.Item("Email").ToString())) Then
                                            objBPatron.Email = row.Item("Email").ToString()
                                        End If
                                    Catch ex As Exception

                                    End Try
                                    '----- Số CMND
                                    Try
                                        If (Not String.IsNullOrEmpty(row.Item("Số CMND").ToString())) Then
                                            objBPatron.IDCard = row.Item("Số CMND").ToString()
                                        End If
                                    Catch ex As Exception

                                    End Try
                                    '----- Số điện thoại
                                    Try
                                        If (Not String.IsNullOrEmpty(row.Item("Số điện thoại").ToString())) Then
                                            objBPatron.Telephone = row.Item("Số điện thoại").ToString()
                                            objBPatron.Mobile = row.Item("Số điện thoại").ToString()
                                        End If
                                    Catch ex As Exception

                                    End Try
                                    '----- Facebook
                                    Try
                                        If (Not String.IsNullOrEmpty(row.Item("Facebook").ToString())) Then
                                            objBPatron.Facebook = row.Item("Facebook").ToString()
                                        End If
                                    Catch ex As Exception

                                    End Try
                                    '----- zalo
                                    Try
                                        If (Not String.IsNullOrEmpty(row.Item("zalo").ToString())) Then
                                            objBPatron.Zalo = row.Item("zalo").ToString()
                                        End If
                                    Catch ex As Exception

                                    End Try
                                    '----- Địa chỉ
                                    '' 245 - id Country VietNam
                                    'Cir_tblPatronOtherAddr : địa chỉ liên lạc bạn đọc
                                    'Cir_tblPatronOtherAddr : PatronID - ID bạn đọc (Cir_tblPatron) ; Address - địa chỉ ; ProvinceID - ID tỉnh (Cir_tblDicProvince) ; City - Tên thành phố : CountryID - ID Quốc gia (Cat_tblDic_Country)
                                    Try
                                        If (Not String.IsNullOrEmpty(row.Item("Địa chỉ").ToString())) Then
                                            If (Not String.IsNullOrEmpty(row.Item("Tỉnh/Thành phố").ToString())) Then
                                                Dim strAdd = row.Item("Địa chỉ").ToString.Trim
                                                Dim strCity = row.Item("Tỉnh/Thành phố").ToString.Trim
                                                objBPatron.AddressInfor = "$&" + strAdd + "$&" + strCity + "$&" + "1" + "$&" + "245" + "$&" + "" + "$&" + "1"
                                            Else
                                                Dim strAdd = row.Item("Địa chỉ").ToString.Trim
                                                objBPatron.AddressInfor = "$&" + strAdd + "$&" + "" + "$&" + "1" + "$&" + "245" + "$&" + "" + "$&" + "1"
                                            End If
                                            'objBPatron.AddressInfor = row.Item("Địa chỉ").ToString()
                                        Else
                                            If (Not String.IsNullOrEmpty(row.Item("Tỉnh/Thành phố").ToString())) Then
                                                Dim strCity = row.Item("Tỉnh/Thành phố").ToString.Trim
                                                objBPatron.AddressInfor = "$&" + "" + "$&" + strCity + "$&" + "1" + "$&" + "245" + "$&" + "" + "$&" + "1"
                                            End If
                                        End If
                                    Catch ex As Exception
                                        Dim mss = ex.Message
                                    End Try
                                    '----- Ngày hiệu lực
                                    Try
                                        If (Not String.IsNullOrEmpty(row.Item("Ngày hiệu lực").ToString())) Then
                                            Dim tempDate As String = row.Item("Ngày hiệu lực").ToString()
                                            Dim dateResult As DateTime = DateTime.ParseExact(tempDate, "dd/MM/yyyy", Nothing)

                                            objBPatron.ValidDate = tempDate
                                            'objBPatron.LastIssuedDate = dateResult.ToShortDateString()
                                        End If
                                    Catch ex As Exception

                                    End Try
                                    '----- Ngày cấp thẻ
                                    Try
                                        If (Not String.IsNullOrEmpty(row.Item("Ngày cấp thẻ").ToString())) Then
                                            Dim tempDate As String = row.Item("Ngày cấp thẻ").ToString()
                                            Dim dateResult As DateTime = DateTime.ParseExact(tempDate, "dd/MM/yyyy", Nothing)
                                            'objBPatron.ValidDate = tempDate
                                            objBPatron.LastIssuedDate = tempDate
                                        End If
                                    Catch ex As Exception

                                    End Try
                                    '----- Ngày hết hạn
                                    Try
                                        If (Not String.IsNullOrEmpty(row.Item("Ngày hết hạn").ToString())) Then
                                            Dim tempDate As String = row.Item("Ngày hết hạn").ToString()
                                            Dim dateResult As DateTime = DateTime.ParseExact(tempDate, "dd/MM/yyyy", Nothing)
                                            objBPatron.ExpiredDate = tempDate
                                        End If
                                    Catch ex As Exception

                                    End Try

                                    'Cir_tblPatronUniversity : PatronID - ID bạn đọc (Cir_tblPatron) ; Grade - Khóa ; FacultyID - ID Khoa (Cir_tblDicFaculty);
                                    'Class - Lớp ; CollegeID - ID trường (Cir_tblDicCollege)
                                    'Trường
                                    Dim collegeId As Integer = 0
                                    Dim tmpCollage As DataTable
                                    Dim strCollegeName As String = ""
                                    objBPatron.CollegeIDCPU = 0
                                    Try
                                        If (Not String.IsNullOrEmpty(row.Item("Trường").ToString())) Then
                                            strCollegeName = row.Item("Trường").ToString.Trim
                                            tmpCollage = objBCollege.GetCollegebyName(strCollegeName)
                                            If Not tmpCollage Is Nothing AndAlso tmpCollage.Rows.Count > 0 Then
                                                collegeId = CType(tmpCollage.Rows(tmpCollage.Rows.Count - 1).Item("ID"), Integer)
                                                objBPatron.CollegeIDCPU = collegeId
                                            End If
                                        End If
                                    Catch ex As Exception

                                    End Try
                                    ''  Đơn vị (Khoa)
                                    objBPatron.FacultyIDCPU = 0
                                    Try
                                        'objBPatron.CollegeIDCPU = collegeId
                                        If (Not String.IsNullOrEmpty(row.Item("Đơn vị").ToString())) Then
                                            objBFaculty.Faculty = row.Item("Đơn vị")
                                            objBFaculty.CollegeID = collegeId
                                            Dim tblFaculty As DataTable = objBFaculty.GetFacultyByName()
                                            If tblFaculty.Rows.Count > 0 Then
                                                objBPatron.FacultyIDCPU = CType(tblFaculty.Rows(0).Item("ID"), Integer)
                                            End If
                                        End If
                                    Catch ex As Exception

                                    End Try
                                    '' Trình độ

                                    Try
                                        If (Not String.IsNullOrEmpty(row.Item("Trình độ").ToString())) Then
                                            Dim strEducation = row.Item("Trình độ").ToString.Trim
                                            Dim tblEducation = objBEducation.GetEducationByName(strEducation)
                                            If Not tblEducation Is Nothing AndAlso tblEducation.Rows.Count > 0 Then
                                                Dim EducationID = CType(tblEducation.Rows(tblEducation.Rows.Count - 1).Item("ID"), Integer)
                                                objBPatron.EducationID = EducationID
                                            End If
                                        End If
                                    Catch ex As Exception

                                    End Try
                                    'Khóa
                                    Try
                                        If (Not String.IsNullOrEmpty(row.Item("Khóa").ToString())) Then
                                            objBPatron.GradeCPU = row.Item("Khóa")
                                        End If
                                    Catch ex As Exception

                                    End Try
                                    'Lớp
                                    Try
                                        If (Not String.IsNullOrEmpty(row.Item("Lớp").ToString())) Then
                                            objBPatron.ClassCPU = row.Item("Lớp")
                                        End If
                                    Catch ex As Exception

                                    End Try

                                    ' Set parameters for University
                                    Try
                                        If (Not String.IsNullOrEmpty(row.Item("Nhóm bạn đọc").ToString())) Then
                                            objBPatronGroup.LibID = clsSession.GlbSite
                                            Dim patronGroup = objBPatronGroup.GetPatronGroupByName(row.Item("Nhóm bạn đọc").ToString.Trim)
                                            If Not patronGroup Is Nothing AndAlso patronGroup.Rows.Count > 0 Then
                                                objBPatron.PatronGroupID = patronGroup.Rows(0).Item("ID")
                                            End If
                                        End If
                                    Catch ex As Exception

                                    End Try
                                    '' Ghi chú
                                    Try
                                        If (Not String.IsNullOrEmpty(row.Item("Ghi chú").ToString())) Then
                                            objBPatron.Note = row.Item("Ghi chú")
                                        End If
                                    Catch ex As Exception

                                    End Try
                                    Dim result As Integer
                                    result = objBPatron.Create()
                                    If result > 0 Then
                                        count = count + 1
                                        rowresult = Table.NewRow()
                                        rowresult.Item("STT") = count
                                        rowresult.Item("Mã số bạn đọc") = objBPatron.Code
                                        rowresult.Item("Tên bạn đọc") = objBPatron.FirstName & " " & objBPatron.MiddleName & " " & objBPatron.LastName
                                        rowresult.Item("Ghi chú") = objBPatron.Note
                                        Table.Rows.Add(rowresult)
                                    End If
                                    If result = 0 Then
                                        countPatronError += 1
                                        errorRowresult = errorTable.NewRow()
                                        errorRowresult.Item("STT") = countPatronError
                                        errorRowresult.Item("Mã số bạn đọc") = row.Item("Số thẻ").ToString()
                                        errorRowresult.Item("Tên bạn đọc") = row.Item("Họ và tên lót").ToString() & " " & row.Item("Tên").ToString()
                                        errorRowresult.Item("STT trên file") = i
                                        errorRowresult.Item("Ghi chú") = "lỗi thông tin import."
                                        errorTable.Rows.Add(errorRowresult)
                                    End If
                                    If result = -1 Then
                                        patronloop = patronloop + 1
                                        countPatronError += 1
                                        errorRowresult = errorTable.NewRow()
                                        errorRowresult.Item("STT") = countPatronError
                                        errorRowresult.Item("Mã số bạn đọc") = row.Item("Số thẻ").ToString()
                                        errorRowresult.Item("Tên bạn đọc") = row.Item("Họ và tên lót").ToString() & " " & row.Item("Tên").ToString()
                                        errorRowresult.Item("STT trên file") = i
                                        errorRowresult.Item("Ghi chú") = "Trùng số thẻ."
                                        errorTable.Rows.Add(errorRowresult)
                                    End If
                                    Call BindPrg(i, tbl.Rows.Count)


                                Catch ex As Exception
                                    'Page.RegisterClientScriptBlock("Fail", "<Script language='JavaScript'>alert('import file không đúng định dạng');</Script>")
                                End Try
                            End If
                            Call ResetValue()
                        Next

                        'Page.RegisterClientScriptBlock("Fail", "<Script language='JavaScript'>alert('import dữ liệu thành công');</Script>")
                        ' Hiển thị kết quả bạn đọc được nhập thành công TotalRowsImport
                        TotalPatronFromExcel.Text = CStr(TotalRowsImport)
                        TotalPatronSuccess.Text = CStr(count).Trim
                        TotalPatronError.Text = CStr(TotalRowsImport - count - patronloop).Trim
                        TotalPatronLoop.Text = CStr(patronloop).Trim
                        If Table.Rows.Count > 0 Then
                            SuccessInfor.Visible = True
                            gvPatronList.DataSource = Table
                            gvPatronList.DataBind()
                        Else
                            SuccessInfor.Visible = False
                        End If
                        '' hien thi thong tin ban doc import trùng hoặc lỗi.
                        If errorTable.Rows.Count > 0 Then
                            errorInfor.Visible = True
                            gvPatronErrorList.DataSource = errorTable
                            gvPatronErrorList.DataBind()
                        Else
                            errorInfor.Visible = False
                        End If
                    End Using
                Else
                    Page.RegisterClientScriptBlock("Fail", "<Script language='JavaScript'>alert('chỉ import file Excel');</Script>")
                End If
            Catch ex As Exception
                Page.RegisterClientScriptBlock("Fail", "<Script language='JavaScript'>alert('có lỗi trong quá trình xử lý');</Script>")
            End Try
        End Sub

        'Protected Sub btnImportData_Click(sender As Object, e As EventArgs) Handles btnImportData.Click
        '    Try
        '        Dim tblTemp As DataTable
        '        If (FileUpload1.HasFile AndAlso (IO.Path.GetExtension(FileUpload1.FileName) = ".xls" Or IO.Path.GetExtension(FileUpload1.FileName) = ".xlsx")) Then
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

        '                For Each row As DataRow In tbl.Rows
        '                    Try
        '                        Try
        '                            objBPatron.FirstName = row.Item("Họ đệm")
        '                        Catch ex As Exception

        '                        End Try


        '                        Try
        '                            objBPatron.LastName = row.Item("Tên")
        '                        Catch ex As Exception

        '                        End Try

        '                        Try
        '                            If row.Item("Giới tính") = "Nữ" Then
        '                                objBPatron.Sex = 0
        '                            Else
        '                                objBPatron.Sex = 1
        '                            End If

        '                        Catch ex As Exception

        '                        End Try

        '                        Try
        '                            objBPatron.DOB = row.Item("Ngày sinh")
        '                        Catch ex As Exception

        '                        End Try


        '                        ' BindData for ddlEthnic

        '                        Try
        '                            tblTemp = objBEthnic.GetEthnic

        '                            tblTemp = objBEthnic.GetEthnicByName(row.Item("Dân tộc"))
        '                            If Not tblTemp Is Nothing Then
        '                                If tblTemp.Rows.Count > 0 Then
        '                                    objBPatron.EthnicID = tblTemp.Rows(0).Item("ID")

        '                                End If
        '                            End If
        '                        Catch ex As Exception

        '                        End Try

        '                        Try
        '                            objBPatron.ClassCPU = row.Item("Lớp học")
        '                        Catch ex As Exception

        '                        End Try

        '                        Try
        '                            objBPatron.GradeCPU = row.Item("Khóa học")
        '                        Catch ex As Exception

        '                        End Try

        '                        Try
        '                            objBPatron.Code = row.Item("Mã HS-SV")
        '                        Catch ex As Exception

        '                        End Try


        '                        objBPatron.Portrait = ""
        '                        objBPatron.LastIssuedDate = Date.Now.Date
        '                        objBPatron.ValidDate = Date.Now.Date

        '                        Try
        '                            objBPatron.AddressInfor = row.Item("Hộ khẩu thường trú")

        '                        Catch ex As Exception

        '                        End Try

        '                        Try
        '                            tblTemp = Nothing
        '                            tblTemp = objBEducation.GetEducationByName(row.Item("Bậc đào tạo"))
        '                            If Not tblTemp Is Nothing Then
        '                                If tblTemp.Rows.Count > 0 Then
        '                                    objBPatron.EducationID = tblTemp.Rows(0).Item("ID")

        '                                End If
        '                            End If
        '                        Catch ex As Exception

        '                        End Try


        '                        Try
        '                            objBPatron.Telephone = row.Item("Điện thoại")
        '                            objBPatron.Mobile = row.Item("Điện thoại")
        '                        Catch ex As Exception

        '                        End Try




        '                        ' Set parameters for University

        '                        tblTemp = objBPatronGroup.GetPatronGroupByName(row.Item("Group"))
        '                        If Not tblTemp Is Nothing Then
        '                            If tblTemp.Rows.Count > 0 Then
        '                                objBPatron.PatronGroupID = tblTemp.Rows(0).Item("ID")

        '                            End If
        '                        End If

        '                        Try

        '                            objBPatron.ClassCPU = row.Item("Lớp học")
        '                        Catch ex As Exception

        '                        End Try

        '                        Try
        '                            objBPatron.Note = row.Item("Ghi chú")
        '                        Catch ex As Exception

        '                        End Try

        '                        objBPatron.Create()

        '                    Catch ex As Exception

        '                    End Try
        '                Next

        '            End Using
        '            Page.RegisterClientScriptBlock("Fail", "<Script language='JavaScript'>alert('import dữ liệu thành công');</Script>")
        '        Else

        '        End If
        '    Catch ex As Exception
        '        Page.RegisterClientScriptBlock("Fail", "<Script language='JavaScript'>alert('có lỗi ttrong quá trình xử lý');</Script>")
        '    End Try
        'End Sub

        'Protected Sub btnImportData_Click(sender As Object, e As EventArgs) Handles btnImportData.Click
        '    Try
        '        If (FileUpload1.HasFile AndAlso (IO.Path.GetExtension(FileUpload1.FileName) = ".xls" Or IO.Path.GetExtension(FileUpload1.FileName) = ".xlsx")) Then
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
        '                Dim startRow = If(hasHeader, 1, 1)
        '                For rowNum = startRow To ws.Dimension.End.Row
        '                    Dim wsRow = ws.Cells(rowNum, 1, rowNum, ws.Dimension.End.Column)
        '                    Dim row = tbl.NewRow()
        '                    For Each cell In wsRow
        '                        row(cell.Start.Column - 1) = cell.Text
        '                    Next
        '                    tbl.Rows.Add(row)
        '                Next

        '                Response.Write("<div class='lbLabel' style=' margin:0;top:250;left:0; width:100%;'>")
        '                Response.Write("<p style='position:absolute; left:45%;'>Nhập khẩu dữ liệu: <span id='pgbMain_label'>0%</span></p>")
        '                Response.Write("<p style='padding-top:35px;'><table width='0%' border=2 bordercolor='white' id='pgbMain' bgcolor=blue><tr style='HEIGHT: 18px'><td></td></tr></table></p>")
        '                Response.Write("</div>")

        '                Dim collegeId As Integer = 0
        '                Dim tmpCollage As DataTable = objBCollege.GetCollege()
        '                If (tmpCollage.Rows.Count > 0) Then
        '                    collegeId = CType(tmpCollage.Rows(tmpCollage.Rows.Count - 1).Item("ID"), Integer)
        '                End If

        '                For i As Integer = 1 To tbl.Rows.Count - 1
        '                    Dim row As DataRow = tbl.Rows(i)

        '                    Try
        '                        '----- Mã bạn đọc (Số thẻ)
        '                        Try
        '                            If (Not String.IsNullOrEmpty(row.Item("Số thẻ").ToString())) Then
        '                                objBPatron.Code = row.Item("Số thẻ")
        '                            End If
        '                        Catch ex As Exception

        '                        End Try


        '                        '----- Tên bạn đọc
        '                        Try
        '                            If (Not String.IsNullOrEmpty(row.Item("Tên bạn đọc").ToString())) Then
        '                                Dim fullname As String = row.Item("Tên bạn đọc").ToString().Trim()
        '                                Dim fullnameSplit() As String = fullname.Split(" ")
        '                                If (fullnameSplit.Length > 0) Then
        '                                    If (fullnameSplit.Length = 1) Then
        '                                        objBPatron.LastName = fullname
        '                                    Else
        '                                        objBPatron.LastName = fullnameSplit(0)
        '                                        objBPatron.FirstName = fullnameSplit(fullnameSplit.Length - 1)
        '                                        Dim midName As String = ""
        '                                        For j As Integer = 1 To fullnameSplit.Length - 2
        '                                            midName = midName & fullnameSplit(j).Trim() & " "
        '                                        Next
        '                                        objBPatron.MiddleName = midName.Trim()
        '                                    End If
        '                                Else
        '                                    objBPatron.LastName = fullname
        '                                End If
        '                            End If
        '                        Catch ex As Exception

        '                        End Try

        '                        '----- Ngày sinh
        '                        Try
        '                            If (Not String.IsNullOrEmpty(row.Item("Ngày sinh").ToString())) Then
        '                                Dim tempDate As String = row.Item("Ngày sinh").ToString()
        '                                Dim splitDate() As String = tempDate.Split("/")
        '                                Dim dateResult As DateTime = New DateTime(CType(splitDate(2), Integer), If(CType(splitDate(1), Integer) = 0, 1, CType(splitDate(1), Integer)), If(CType(splitDate(0), Integer) = 0, 1, CType(splitDate(0), Integer)))
        '                                objBPatron.DOB = dateResult.ToShortDateString()
        '                            End If
        '                        Catch ex As Exception

        '                        End Try


        '                        '----- Tên bạn đọc
        '                        Try
        '                            If (Not String.IsNullOrEmpty(row.Item("Giới tính").ToString())) Then
        '                                objBPatron.Sex = If(row.Item("Giới tính").ToString() = "1", True, False)
        '                            End If
        '                        Catch ex As Exception

        '                        End Try


        '                        '----- Email
        '                        Try
        '                            If (Not String.IsNullOrEmpty(row.Item("Email").ToString())) Then
        '                                objBPatron.Email = row.Item("Email").ToString()
        '                            End If
        '                        Catch ex As Exception

        '                        End Try

        '                        '----- Số CMND
        '                        Try
        '                            If (Not String.IsNullOrEmpty(row.Item("Số CMND").ToString())) Then
        '                                objBPatron.IDCard = row.Item("Số CMND").ToString()
        '                            End If
        '                        Catch ex As Exception

        '                        End Try

        '                        '----- Số điện thoại
        '                        Try
        '                            If (Not String.IsNullOrEmpty(row.Item("Số điện thoại").ToString())) Then
        '                                objBPatron.Telephone = row.Item("Số điện thoại").ToString()
        '                                objBPatron.Mobile = row.Item("Số điện thoại").ToString()
        '                            End If
        '                        Catch ex As Exception

        '                        End Try

        '                        '----- Địa chỉ
        '                        'Cir_tblPatronOtherAddr : địa chỉ liên lạc bạn đọc
        '                        'Cir_tblPatronOtherAddr : PatronID - ID bạn đọc (Cir_tblPatron) ; Address - địa chỉ ; ProvinceID - ID tỉnh (Cir_tblDicProvince) ; City - Tên thành phố : CountryID - ID Quốc gia (Cat_tblDic_Country)
        '                        Try
        '                            If (Not String.IsNullOrEmpty(row.Item("Địa chỉ").ToString())) Then
        '                                objBPatron.AddressCPOA = row.Item("Địa chỉ").ToString()
        '                            End If
        '                        Catch ex As Exception

        '                        End Try


        '                        '----- Ngày hiệu lực
        '                        Try
        '                            If (Not String.IsNullOrEmpty(row.Item("Ngày hiệu lực").ToString())) Then
        '                                Dim tempDate As String = row.Item("Ngày hiệu lực").ToString()
        '                                Dim splitDate() As String = tempDate.Split("/")
        '                                Dim dateResult As DateTime = New DateTime(CType(splitDate(2), Integer), If(CType(splitDate(0), Integer) = 0, 1, CType(splitDate(0), Integer)), If(CType(splitDate(1), Integer) = 0, 1, CType(splitDate(1), Integer)))
        '                                objBPatron.ValidDate = dateResult.ToShortDateString()
        '                                objBPatron.LastIssuedDate = dateResult.ToShortDateString()
        '                            End If
        '                        Catch ex As Exception

        '                        End Try



        '                        '----- Ngày hết hạn
        '                        Try
        '                            If (Not String.IsNullOrEmpty(row.Item("Ngày hết hạn").ToString())) Then
        '                                Dim tempDate As String = row.Item("Ngày hết hạn").ToString()
        '                                Dim splitDate() As String = tempDate.Split("/")
        '                                Dim dateResult As DateTime = New DateTime(CType(splitDate(2), Integer), If(CType(splitDate(0), Integer) = 0, 1, CType(splitDate(0), Integer)), If(CType(splitDate(1), Integer) = 0, 1, CType(splitDate(1), Integer)))
        '                                objBPatron.ExpiredDate = dateResult.ToShortDateString()
        '                            End If
        '                        Catch ex As Exception

        '                        End Try

        '                        'Cir_tblPatronUniversity : PatronID - ID bạn đọc (Cir_tblPatron) ; Grade - Khóa ; FacultyID - ID Khoa (Cir_tblDicFaculty); Class - Lớp ; CollegeID - ID trường (Cir_tblDicCollege)

        '                        '' BindData for ddlEthnic

        '                        'Try
        '                        '    tblTemp = objBEthnic.GetEthnic

        '                        '    tblTemp = objBEthnic.GetEthnicByName(row.Item("Dân tộc"))
        '                        '    If Not tblTemp Is Nothing Then
        '                        '        If tblTemp.Rows.Count > 0 Then
        '                        '            objBPatron.EthnicID = tblTemp.Rows(0).Item("ID")

        '                        '        End If
        '                        '    End If
        '                        'Catch ex As Exception

        '                        'End Try

        '                        'Lớp
        '                        Try
        '                            If (Not String.IsNullOrEmpty(row.Item("Lớp").ToString())) Then
        '                                objBPatron.ClassCPU = row.Item("Lớp")
        '                            End If
        '                        Catch ex As Exception

        '                        End Try

        '                        'Khóa
        '                        Try
        '                            If (Not String.IsNullOrEmpty(row.Item("Khóa").ToString())) Then
        '                                objBPatron.GradeCPU = row.Item("Khóa")
        '                            End If
        '                        Catch ex As Exception

        '                        End Try

        '                        'Khoa
        '                        Try
        '                            objBPatron.CollegeIDCPU = collegeId
        '                            If (Not String.IsNullOrEmpty(row.Item("Khoa").ToString())) Then
        '                                objBFaculty.Faculty = row.Item("Khoa")
        '                                objBFaculty.CollegeID = collegeId
        '                                Dim tblFaculty As DataTable = objBFaculty.GetFacultyByName()
        '                                If tblFaculty.Rows.Count > 0 Then
        '                                    objBPatron.FacultyIDCPU = CType(tblFaculty.Rows(0).Item("ID"), Integer)
        '                                End If
        '                            End If
        '                        Catch ex As Exception

        '                        End Try

        '                        'objBPatron.Portrait = ""
        '                        'objBPatron.LastIssuedDate = Date.Now.Date
        '                        'objBPatron.ValidDate = Date.Now.Date


        '                        ''
        '                        'Try
        '                        '    objBPatron.AddressInfor = row.Item("Hộ khẩu thường trú")

        '                        'Catch ex As Exception

        '                        'End Try

        '                        ''
        '                        'Try
        '                        '    tblTemp = Nothing
        '                        '    tblTemp = objBEducation.GetEducationByName(row.Item("Bậc đào tạo"))
        '                        '    If Not tblTemp Is Nothing Then
        '                        '        If tblTemp.Rows.Count > 0 Then
        '                        '            objBPatron.EducationID = tblTemp.Rows(0).Item("ID")

        '                        '        End If
        '                        '    End If
        '                        'Catch ex As Exception

        '                        'End Try


        '                        ' Set parameters for University
        '                        Try
        '                            If (Not String.IsNullOrEmpty(row.Item("Nhóm bạn đọc").ToString())) Then
        '                                objBPatronGroup.LibID = clsSession.GlbSite
        '                                Dim patronGroup = objBPatronGroup.GetPatronGroupByName(row.Item("Nhóm bạn đọc").ToString())
        '                                If Not patronGroup Is Nothing Then
        '                                    objBPatron.PatronGroupID = patronGroup.Rows(0).Item("ID")
        '                                End If
        '                            End If
        '                        Catch ex As Exception

        '                        End Try

        '                        Try
        '                            If (Not String.IsNullOrEmpty(row.Item("Ghi chú").ToString())) Then
        '                                objBPatron.Note = row.Item("Ghi chú")
        '                            End If
        '                        Catch ex As Exception

        '                        End Try

        '                        objBPatron.Create()

        '                        Call BindPrg(i, tbl.Rows.Count)


        '                    Catch ex As Exception
        '                        'Page.RegisterClientScriptBlock("Fail", "<Script language='JavaScript'>alert('import file không đúng định dạng');</Script>")
        '                    End Try
        '                Next
        '                Page.RegisterClientScriptBlock("Fail", "<Script language='JavaScript'>alert('import dữ liệu thành công');</Script>")
        '            End Using
        '        Else
        '            Page.RegisterClientScriptBlock("Fail", "<Script language='JavaScript'>alert('chỉ import file Excel');</Script>")
        '        End If
        '    Catch ex As Exception
        '        Page.RegisterClientScriptBlock("Fail", "<Script language='JavaScript'>alert('có lỗi trong quá trình xử lý');</Script>")
        '    End Try
        'End Sub
        Public Sub BindPrg(ByVal intCurrent As Integer, ByVal intSum As Integer)
            Dim intCurrentPercent As Integer
            intCurrentPercent = ((intCurrent + 1) * 100) / intSum
            Response.Write("<script>if (pgbObj = document.getElementById('pgbMain')) pgbObj.width =" & intCurrentPercent & " + '%'; if (lblObj = document.getElementById('pgbMain_label')) lblObj.innerHTML =" & intCurrentPercent & " + '%';</script>")
            Response.Flush()
        End Sub

        Protected Sub btnDownloadFile_Click(sender As Object, e As EventArgs) Handles btnDownloadFile.Click
            Dim strTime As String = DateAndTime.Now.Year & DateAndTime.Now.Month & DateAndTime.Now.Day & DateAndTime.Now.Hour & DateAndTime.Now.Minute & DateAndTime.Now.Second & DateAndTime.Now.Millisecond
            Response.Clear()
            Response.AddHeader("content-disposition", "attachment;filename=Template_Import_Bandoc_" & strTime & ".xlsx")
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            Response.WriteFile(Server.MapPath("../Template/Template_Import_Bandoc.xlsx"))
            Response.Flush()
            Response.End()
        End Sub
        Protected Sub ResetValue()
            objBPatron.Code = Nothing
            objBPatron.FirstName = Nothing
            objBPatron.MiddleName = Nothing
            objBPatron.LastName = ""
            objBPatron.DOB = ""
            objBPatron.Sex = Nothing
            objBPatron.EthnicID = 0
            objBPatron.Email = ""
            objBPatron.IDCard = ""
            objBPatron.Telephone = ""
            objBPatron.Mobile = ""
            objBPatron.Facebook = ""
            objBPatron.Zalo = ""
            objBPatron.AddressInfor = ""
            objBPatron.LastIssuedDate = ""
            objBPatron.ValidDate = Nothing
            objBPatron.ExpiredDate = ""
            objBPatron.CollegeIDCPU = 0
            objBPatron.FacultyIDCPU = 0
            objBPatron.EducationID = 0
            objBPatron.GradeCPU = ""
            objBPatron.ClassCPU = ""
            objBPatron.PatronGroupID = Nothing
            objBPatron.Note = ""
        End Sub
    End Class
End Namespace