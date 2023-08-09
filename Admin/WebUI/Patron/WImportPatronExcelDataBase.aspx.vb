Imports System.IO
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Patron
Imports OfficeOpenXml

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WImportPatronExcelDataBase
        Inherits clsWBase

        ' Private variable
        Private strSeparate As String = ":::"
        Private strIDs As String
        Private objBPatronGroup As New clsBPatronGroup
        Private objBEthnic As New clsBEthnic
        Private objBEducation As New clsBEducation
        Private objBCollege As New clsBCollege
        Private objBInput As New clsBInput
        Private objBPatron As New eMicLibAdmin.BusinessRules.Patron.clsBPatron
        Private objBOtherAddress As New clsBOtherAddress

        Private intPatronGroup As Integer = 1
        Private intFaculty As Integer = 1
        Private intCollege As Integer = 1

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        ' Initialize Method
        ' Popurse: Init all object using in form
        Private Sub Initialize()

            ' Init objBInput object
            objBInput.InterfaceLanguage = Session("InterfaceLanguage")
            objBInput.DBServer = Session("DBServer")
            objBInput.ConnectionString = Session("ConnectionString")
            Call objBInput.Initialize()

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
            '
            'objBPatronGroup
            objBOtherAddress.InterfaceLanguage = Session("InterfaceLanguage")
            objBOtherAddress.DBServer = Session("DBServer")
            objBOtherAddress.ConnectionString = Session("ConnectionString")
            Call objBOtherAddress.initialize()
        End Sub

        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Me.Dispose(True)
        End Sub

        ' Dispose Method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not objBInput Is Nothing Then
                        objBInput.Dispose(True)
                        objBInput = Nothing
                    End If
                    If Not objBPatron Is Nothing Then
                        objBPatron.Dispose(True)
                        objBPatron = Nothing
                    End If
                    If Not objBCollege Is Nothing Then
                        objBCollege.Dispose(True)
                        objBCollege = Nothing
                    End If
                    If Not objBEducation Is Nothing Then
                        objBEducation.Dispose(True)
                        objBEducation = Nothing
                    End If
                    If Not objBEthnic Is Nothing Then
                        objBEthnic.Dispose(True)
                        objBEthnic = Nothing
                    End If
                    If Not objBPatronGroup Is Nothing Then
                        objBPatronGroup.Dispose(True)
                        objBPatronGroup = Nothing
                    End If
                    If Not objBOtherAddress Is Nothing Then
                        objBOtherAddress.Dispose(True)
                        objBOtherAddress = Nothing
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

        Public Sub BindPrg(ByVal intCurrent As Integer, ByVal intSum As Integer)
            Dim intCurrentPercent As Integer
            intCurrentPercent = ((intCurrent + 1) * 100) / intSum
            Response.Write("<script>if (pgbObj = document.getElementById('pgbMain')) pgbObj.width =" & intCurrentPercent & " + '%'; if (lblObj = document.getElementById('pgbMain_label')) lblObj.innerHTML =" & intCurrentPercent & " + '%';</script>")
            Response.Flush()
        End Sub

        Private Function ReadFileExcelToDataTable(ByVal fileUploadInput As FileUpload) As DataTable
            Dim tbl = New DataTable()
            If (fileUploadInput.HasFile AndAlso (IO.Path.GetExtension(fileUploadInput.FileName) = ".xlsx" Or IO.Path.GetExtension(fileUploadInput.FileName) = ".xls")) Then
                Using excel = New ExcelPackage(fileUploadInput.PostedFile.InputStream)
                    Dim ws = excel.Workbook.Worksheets.First()
                    Dim hasHeader = True ' change it if required '

                    Dim arrColumn As New List(Of String)
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

        Private Sub ImportData(ByVal tbl As DataTable)
            Dim listError As New List(Of String) ' Danh sách insert ko được
            Dim listErrorDKCB As New List(Of String) ' Danh sách insert DKCB ko được

            Dim countTotalRecordInput As Integer = If(tbl.Rows.Count <= 0, 0, tbl.Rows.Count) 'Tổng dòng nhập từ file excel
            Dim countSusscess As Integer = 0  'Tổng dòng thực hiện thành công

            lbTotalInput.Text = "<i>Tổng số dòng nhập từ file Excel: </i><b><u>" & countTotalRecordInput & "</u></b>"

            Response.Write("<div class='lbLabel' style=' margin:0;top:250;left:0; width:100%;'>")
            Response.Write("<p style='position:absolute; left:45%;'>Nhập khẩu dữ liệu: <span id='pgbMain_label'>0%</span></p>")
            Response.Write("<p style='padding-top:35px;'><table width='0%' border=2 bordercolor='white' id='pgbMain' bgcolor=blue><tr style='HEIGHT: 18px'><td></td></tr></table></p>")
            Response.Write("</div>")

            Dim tblTemp As New DataTable()

            Dim strPatronCode As String = ""
            Dim strFirstName As String = ""
            Dim strLastName As String = ""
            Dim strBirthday As String = ""
            Dim strSex As String = ""
            Dim strAddress As String = ""
            Dim strEmail As String = ""
            Dim strPhone As String = ""
            Dim strNote As String = ""
            Dim strGroupName As String = ""
            Dim strFaculty As String = ""
            Dim strStatus As String = ""
            Dim strValidLastIssueDate As String = ""
            Dim strLastModifiedDate As String = ""
            Dim strNameCreate As String = ""
            Dim strNameUpdate As String = ""

            Dim bolSex As Boolean = True
            Dim intStatus As Integer = 1

            For i As Integer = 0 To tbl.Rows.Count - 1
                Dim row As DataRow = tbl.Rows(i)

                Try
                    strPatronCode = row.Item("MaDocGia") & ""
                    strFirstName = row.Item("Ho") & ""
                    strLastName = row.Item("Ten") & ""
                    strBirthday = row.Item("NgaySinh") & ""
                    strSex = row.Item("GioiTinh") & ""
                    strAddress = row.Item("DiaChi") & ""
                    strEmail = row.Item("Email") & ""
                    strPhone = row.Item("DienThoai") & ""
                    strNote = row.Item("GhiChu") & ""
                    strGroupName = row.Item("MaNhomDocGia") & ""
                    strFaculty = row.Item("MaDonVi") & ""
                    strStatus = row.Item("SuDung") & ""
                    strValidLastIssueDate = row.Item("NgayTao") & ""
                    strLastModifiedDate = row.Item("NgayCapNhat") & ""
                    strNameCreate = row.Item("NhanVienTao") & ""
                    strNameUpdate = row.Item("NhanVienCapNhat") & ""

                    If strPatronCode = "NULL" Then strPatronCode = ""
                    If strFirstName = "NULL" Then strFirstName = ""
                    If strLastName = "NULL" Then strLastName = ""
                    If strBirthday = "NULL" Then strBirthday = ""
                    If strSex = "NULL" Then strSex = ""
                    If strAddress = "NULL" Then strAddress = ""
                    If strEmail = "NULL" Then strEmail = ""
                    If strPhone = "NULL" Then strPhone = ""
                    If strNote = "NULL" Then strNote = ""
                    If strGroupName = "NULL" Then strGroupName = ""
                    If strFaculty = "NULL" Then strFaculty = ""
                    If strStatus = "NULL" Then strStatus = ""
                    If strNameCreate = "NULL" Then strNameCreate = ""
                    If strNameUpdate = "NULL" Then strNameUpdate = ""
                    If strLastModifiedDate = "NULL" Then strLastModifiedDate = ""

                    If strSex = "1" Then
                        bolSex = True
                    Else
                        bolSex = False
                    End If

                    If strStatus = "1" Then
                        intStatus = 1
                    Else
                        intStatus = 0
                    End If

                    If strValidLastIssueDate <> "" Then
                        strValidLastIssueDate = String.Format("{0:yyyy-MM-dd HH:mm:ss}", Date.Parse(strValidLastIssueDate))
                    End If

                    If strBirthday <> "" Then
                        If strBirthday = "//" Then
                            strBirthday = ""
                        Else
                            Try
                                If strBirthday <> "" Then
                                    strBirthday = String.Format("{0:yyyy-MM-dd HH:mm:ss}", Date.Parse(strBirthday))
                                End If
                            Catch ex As Exception
                                'Dim arrSplit As String() = strBirthday.Split("/")
                                'If arrSplit(2) < 1900 Then
                                '    strBirthday = "19" & arrSplit(2) & "-01-01 00:00:00"
                                'Else
                                '    strBirthday = arrSplit(2) & "-01-01 00:00:00"
                                'End If
                                strBirthday = ""
                            End Try
                        End If
                    End If

                    If strLastModifiedDate <> "" Then
                        If strLastModifiedDate <> "NULL" Then
                            strLastModifiedDate = String.Format("{0:yyyy-MM-dd HH:mm:ss}", Date.Parse(strLastModifiedDate))
                        End If
                    End If

                    ReferrenceGroupName(strGroupName)
                    ReferrenceFaculty(strFaculty)

                    objBPatron.Code = strPatronCode
                    objBPatron.FirstName = strFirstName
                    objBPatron.MiddleName = ""
                    objBPatron.LastName = strLastName
                    objBPatron.DOB = strBirthday
                    objBPatron.Sex = bolSex
                    objBPatron.AddressInfor = strAddress
                    objBPatron.Email = strEmail
                    objBPatron.Telephone = strPhone
                    objBPatron.Mobile = strPhone
                    objBPatron.Note = strNote
                    objBPatron.Portrait = ""
                    objBPatron.PatronGroupID = intPatronGroup
                    objBPatron.Status = intStatus
                    objBPatron.EthnicID = 0
                    objBPatron.EducationID = 0
                    objBPatron.OccupationID = 0
                    objBPatron.LibID = clsSession.GlbSite
                    objBPatron.Password = ""
                    objBPatron.NameCreate = strNameCreate
                    objBPatron.NameUpdate = strNameUpdate
                    objBPatron.LastIssuedDate = strValidLastIssueDate
                    objBPatron.ValidDate = strValidLastIssueDate
                    objBPatron.LastModifiedDate = strLastModifiedDate

                    Dim intPatronId As Long = objBPatron.CreatePatron(intFaculty, intCollege)

                    If intPatronId > 0 Then
                        objBOtherAddress.PatronID = intPatronId
                        objBOtherAddress.Create(strAddress, 1, "", 209, "", 1)
                    End If

                    If objBPatron.ErrorMsg = "" Then
                        countSusscess = countSusscess + 1
                    Else
                        listError.Add("<br/>" & (i + 1) & ": " & objBPatron.ErrorMsg)
                    End If

                    lbSuccess.Text = "<i>Số dòng đã thực hiện thành công: </i><b><u>" & countSusscess & "</u></b>"

                    Call BindPrg(i, tbl.Rows.Count)

                Catch ex As Exception
                    listError.Add("<br/>" & i & ": " & ex.Message)
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

        End Sub

        Private Sub ReferrenceGroupName(ByVal strInput As String)
            intPatronGroup = 1
            Select Case strInput
                Case "CHSH"
                    intPatronGroup = 8
                Case "GV"
                    intPatronGroup = 5
                Case "KK"
                    intPatronGroup = 9
                Case "NV"
                    intPatronGroup = 7
                Case "SV"
                    intPatronGroup = 1
                Case "SVC"
                    intPatronGroup = 6
                Case Else
                    intPatronGroup = 1
            End Select
        End Sub

        Private Sub ReferrenceFaculty(ByVal strInput As String)
            intCollege = 12
            intFaculty = 35
            Select Case strInput
                Case "BDBCL"
                    intFaculty = 29
                Case "BGH"
                    intFaculty = 30
                Case "C.PC"
                    intCollege = 13
                    intFaculty = 75
                Case "CO"
                    intFaculty = 31
                Case "DA"
                    intFaculty = 32
                Case "DL"
                    intFaculty = 33
                Case "DTN"
                    intFaculty = 34
                Case "HSV"
                    intFaculty = 35
                Case "KKT"
                    intFaculty = 36
                Case "KT"
                    intFaculty = 37
                Case "L.TV"
                    intFaculty = 38
                Case "LKT"
                    intFaculty = 39
                Case "MC"
                    intFaculty = 40
                Case "MT"
                    intFaculty = 41
                Case "NCDT"
                    intFaculty = 42
                Case "NN"
                    intFaculty = 43
                Case "O.CB"
                    intFaculty = 28
                Case "O.TT"
                    intFaculty = 44
                Case "P.CTSV"
                    intFaculty = 45
                Case "P.DN"
                    intFaculty = 46
                Case "P.DT"
                    intFaculty = 47
                Case "P.DTSDH"
                    intFaculty = 48
                Case "P.H1"
                    intFaculty = 49
                Case "P.H2"
                    intFaculty = 50
                Case "P.H3"
                    intFaculty = 51
                Case "P.HC"
                    intFaculty = 52
                Case "P.KH"
                    intFaculty = 53
                Case "P.KT"
                    intFaculty = 54
                Case "P.KTDB"
                    intFaculty = 55
                Case "P.QLKHCN"
                    intFaculty = 56
                Case "P.TVTS"
                    intFaculty = 57
                Case "PR"
                    intFaculty = 58
                Case "QT"
                    intFaculty = 59
                Case "SDC"
                    intFaculty = 60
                Case "SH"
                    intFaculty = 61
                Case "T.NN"
                    intFaculty = 62
                Case "T.SV"
                    intFaculty = 63
                Case "T.TH"
                    intFaculty = 64
                Case "T.TT"
                    intFaculty = 65
                Case "TC"
                    intFaculty = 66
                Case "TH"
                    intFaculty = 13
                Case "TNH"
                    intFaculty = 67
                Case "TTDNKTC"
                    intFaculty = 68
                Case "TTDTQT"
                    intFaculty = 69
                Case "UD"
                    intFaculty = 70
                Case "V.CD"
                    intFaculty = 71
                Case "V.DU"
                    intFaculty = 72
                Case "V.TN"
                    intFaculty = 73
                Case "YTHD"
                    intFaculty = 74
                Case Else
                    intFaculty = 35
            End Select
        End Sub

    End Class
End Namespace

