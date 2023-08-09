Imports System.IO
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue
'Phuong Modify 9
'B0 Import HodingNo from Fields852
Imports eMicLibAdmin.BusinessRules.Acquisition

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WImportFromFile
        Inherits clsWBase

        ' Declare class variables
        Private objBForm As New clsBForm
        Private objBCDS As New clsBCommonDBSystem
        Private objBInput As New clsBInput

        ' Declare module variables
        Private strFileName As String
        Private strPath As String
        Private strFileNameTemp As String
        Private strImport As String  ' Imported string 

        ' Arrays
        Private arrForms()
        Private arrPartForms()
        Private arrPrgBar()
        Private arrFieldName()
        Private arrFieldValue()
        Private intFormID As Integer

        'Phuong Modify 
        'B1 Import HodingNo from Fields852
        Private objBCSP As New clsBCommonStringProc
        Private objBLocation As New clsBLocation
        Private objBLibrary As New clsBLibrary
        Private objBCopyNumber As New clsBCopyNumber
        Private objBItem As New clsBItem
        'E1

        'B2 Check dubplicate
        Private objBFormingSQL As New clsBFormingSQL
        'E2
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents tblMain As System.Web.UI.HtmlControls.HtmlTable


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPemission()
            Call Initialize()
            Call BindLabel()
            Call BindJS()
            Call BindData()
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            If IsNumeric(Request("Authority")) Then
                Session("IsAuthority") = CInt(Request("Authority"))
            Else
                If Not IsNumeric(Session("IsAuthority")) Then
                    Session("IsAuthority") = 0
                End If
            End If

            ' Init objBForm object
            objBForm.IsAuthority = Session("IsAuthority")
            objBForm.InterfaceLanguage = Session("InterfaceLanguage")
            objBForm.DBServer = Session("DBServer")
            objBForm.ConnectionString = Session("ConnectionString")
            Call objBForm.Initialize()

            ' Init objBCDS object
            objBCDS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDS.DBServer = Session("DBServer")
            objBCDS.ConnectionString = Session("ConnectionString")
            Call objBCDS.Initialize()

            ' Init objBInput object
            objBInput.InterfaceLanguage = Session("InterfaceLanguage")
            objBInput.DBServer = Session("DBServer")
            objBInput.ConnectionString = Session("ConnectionString")
            Call objBInput.Initialize()

            'Phuong Modify 
            'B2 Import HodingNo from Fields852
            ' Init objBCSP object
            objBCSP.DBServer = Session("DBServer")
            objBCSP.ConnectionString = Session("ConnectionString")
            objBCSP.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCSP.Initialize()

            'Init objBFormingSQL object
            objBFormingSQL.InterfaceLanguage = Session("InterfaceLanguage")
            objBFormingSQL.DBServer = Session("DBServer")
            objBFormingSQL.ConnectionString = Session("ConnectionString")
            Call objBFormingSQL.Initialize()

            ' Initialize objBLocation object
            objBLocation.DBServer = Session("DBServer")
            objBLocation.ConnectionString = Session("ConnectionString")
            objBLocation.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBLocation.Initialize()

            ' Initialize objBLibrary object
            objBLibrary.DBServer = Session("DBServer")
            objBLibrary.ConnectionString = Session("ConnectionString")
            objBLibrary.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBLibrary.Initialize()

            ' Init objBCopyNumber object
            objBCopyNumber.InterfaceLanguage = Session("InterfaceLanguage")
            objBCopyNumber.DBServer = Session("DBServer")
            objBCopyNumber.ConnectionString = Session("ConnectionString")
            Call objBCopyNumber.Initialize()

            ' Init objBItem object
            objBItem.InterfaceLanguage = Session("InterfaceLanguage")
            objBItem.DBServer = Session("DBServer")
            objBItem.ConnectionString = Session("ConnectionString")
            Call objBItem.Initialize()
            'E2
        End Sub

        ' Method: CheckFormPemission
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            If Session("IsAuthority") = 0 Then 'Thu muc
                If Not CheckPemission(9) Then
                    btnImport.Enabled = False
                End If
            Else 'Tu chuan
                If Not CheckPemission(145) Then
                    btnImport.Enabled = False
                End If
            End If
        End Sub

        ' BindJS method
        ' Purpose: Get the javascripts
        Private Sub BindJS()
            ' JAVASCRIPT string
            Dim strJS As String

            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("selfJs", "<script language = 'javascript' src = '../js/Catalogue/WImportFromFile.js'></script>")

            strJS = "javascript:if(!CheckInput('" & ddlLabel.Items(4).Text & "','" & ddlLabel.Items(1).Text & "','" & ddlLabel.Items(0).Text & "','" & ddlLabel.Items(2).Text & "')) return false;" & Chr(10)
            'strJS = strJS & "if (document.forms[0].filAttach.value.substring(document.forms[0].filAttach.value.lenght - 3, document.forms[0].filAttach.value).toLowerCase != 'iso') {alert(document.forms[0].filAttach.value.substring(document.forms[0].filAttach.value.lenght - 3, document.forms[0].filAttach.value.lenght));alert('" & ddlLabel.Items(5).Text.Trim & "'); return false;}"
            btnImport.Attributes.Add("Onclick", strJS)

            filAttach.Attributes.Add("onKeyDown", "javascript:if(event.keyCode ) {document.forms(0).filAttach.value='';keyCode=27;return false;}")

            SetCheckNumber(txtLRange, ddlLabel.Items(1).Text, "")
            SetCheckNumber(txtRRange, ddlLabel.Items(1).Text, "")
        End Sub

        ' BindLabel method
        Private Sub BindLabel()
            If Session("IsAuthority") = 0 Then
                lblAutitle.Visible = False
            Else
                lblTitle.Visible = False
            End If
        End Sub

        ' BindData method
        ' Purpose: load all marc worksheet into dropdown list
        Private Sub BindData()
            Dim tblTemp As DataTable

            objBForm.IsAuthority = CInt(Session("IsAuthority"))

            tblTemp = objBForm.GetForms
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlForm.DataSource = tblTemp
                ddlForm.DataTextField = "Name"
                ddlForm.DataValueField = "ID"
                ddlForm.DataBind()
            End If
        End Sub

        ' btnImport_Click action
        ' Purpose: Import the ISO file to the system
        Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
            ' Declare variables
            Dim intImportCount As Integer
            Dim intImportCountDuplicate As Integer = 0
            Dim tblTemp As DataTable  ' Datatable variable
            Dim intIndex As Integer  ' Index of the string character
            Dim strFieldName As String  ' String of the Field Names part in the iso file (separate with other part by "#")
            Dim intArrIndex As Integer  ' Array index
            Dim intFieldIndex As Integer  ' Field index
            Dim strFieldNum As String  ' String of each field (001, 005...)
            Dim strFieldVal As String  ' Value of each field (001, 005...)
            Dim intLRange As Integer   ' First value of imported records (User defined)
            Dim intRRange As Integer   ' Last value of imported records (User defined)
            Dim strTemp As String
            ' File to read to display the progress bar

            ' Get the path file in the server for uploading
            tblTemp = objBCDS.GetTempFilePath(1)
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                strPath = Server.MapPath("../../") & CStr(tblTemp.Rows(0).Item("TempFilePath"))
            End If
            Dim checkType = True

            If Not CheckFileType(filAttach) Then
                checkType = False
            End If

            If Not CheckFileType(filAttach2) Then
                checkType = False
            End If

            If Not CheckFileType(filAttach3) Then
                checkType = False
            End If

            If Not CheckFileType(filAttach4) Then
                checkType = False
            End If

            If Not CheckFileType(filAttach5) Then
                checkType = False
            End If
            If checkType Then
                For ii As Integer = 1 To 5
                    objBCDS.Extension = "iso"
                    strFileNameTemp = objBCDS.GenRandomFile()

                    Select Case ii
                        Case 1
                            ' Upload file
                            strFileName = UpLoadFiles(filAttach, strPath, strFileNameTemp)
                        Case 2
                            ' Upload file
                            strFileName = UpLoadFiles(filAttach2, strPath, strFileNameTemp)
                        Case 3
                            ' Upload file
                            strFileName = UpLoadFiles(filAttach3, strPath, strFileNameTemp)
                        Case 4
                            ' Upload file
                            strFileName = UpLoadFiles(filAttach4, strPath, strFileNameTemp)
                        Case 5
                            ' Upload file
                            strFileName = UpLoadFiles(filAttach5, strPath, strFileNameTemp)
                    End Select

                    If Not strFileName = "Fail" Then
                        ' Read from file and get the import string
                        strImport = ReadFromFile(strPath & "\" & strFileNameTemp)
                        ' Replace some control charaters
                        strImport = Replace(strImport, Chr(31), "$")
                        strImport = Replace(strImport, Chr(30), "#")
                        strImport = Replace(strImport, Chr(29), "#")

                        ' Transfer the value for the InterfaceLanguage in objBInput
                        If ddlEncode.SelectedIndex <> 0 Then
                            objBInput.InterfaceLanguage = ddlEncode.SelectedValue
                        End If

                        ' BEGIN IMPORT 
                        ReDim arrFieldName(0)
                        ReDim arrFieldValue(0)

                        ' If pattern is MARC21 (tagged)
                        If InStr(strImport, "##") = 0 Or strImport = "" Or InStr(strImport, "#") = 0 Then
                            Page.RegisterClientScriptBlock("JSInvalidData", "<script language = 'javascript'> alert('" & ddlLabel.Items(5).Text & "'); </script>")
                            lblFail.Visible = False
                            lblSuccess.Visible = False
                            lblTotal.Visible = False
                            lblCount.Visible = False
                            lblTotalDuplicate.Visible = False
                            lblCountDuplicate.Visible = False
                        Else
                            ' Divide the import string to the parts to recieve the records
                            arrForms = Split(Trim(strImport), "##")

                            ' FormID
                            intFormID = CInt(ddlForm.SelectedValue)

                            ' Get the coordinate of records (FROM...TO)
                            If Trim(txtLRange.Text) <> "" Then
                                intLRange = CInt(Trim(txtLRange.Text))
                            Else
                                intLRange = LBound(arrForms) + 1
                            End If

                            If Trim(txtRRange.Text) <> "" Then
                                intRRange = CInt(Trim(txtRRange.Text))
                            Else
                                intRRange = UBound(arrForms)
                            End If

                            ' If the range is valid strContent = Replace(strContent, Chr(10), "")
                            If intLRange > 0 And intRRange <= UBound(arrForms) And intLRange <= intRRange Then
                                intImportCount = 0

                                Response.Write("<SPAN class='lbLabel' style=' margin: 0 auto 0 45%;top:250;left: 20px'>")
                                Response.Write(ddlLabel.Items(6).Text & "<span id='pgbMain_label'>0%</span><br>")
                                Response.Write("<table width='0%' border=2 bordercolor='white' id='pgbMain' bgcolor=blue><tr style='HEIGHT: 18px'><td></td></tr></table>")

                                ' If pattern is MARC21 (tagged)
                                If ddlPattern.SelectedIndex = 0 Then
                                    For intArrIndex = intLRange - 1 To intRRange - 1
                                        Call BindPrg(intArrIndex, intRRange)   ' Display the progress bar
                                        strTemp = Trim(Replace(Replace(arrForms(intArrIndex), Chr(10), ""), "Ldr", "000"))
                                        If strTemp <> "" Then
                                            objBInput.ParseTaggedRecord(Chr(13), " ", strTemp, arrFieldName, arrFieldValue, "$", False)

                                            ReDim Preserve arrFieldName(UBound(arrFieldName) + 1)
                                            ReDim Preserve arrFieldValue(UBound(arrFieldValue) + 1)

                                            arrFieldName(UBound(arrFieldName)) = "911"
                                            arrFieldValue(UBound(arrFieldValue)) = clsSession.GlbUserFullName

                                            objBInput.FieldName = arrFieldName
                                            objBInput.FieldValue = arrFieldValue

                                            Dim lngRecID As Long = 0

                                            ' Is biography
                                            If Session("IsAuthority") = 0 Then
                                                If ddlImportMode.SelectedValue = 0 Then
                                                    lngRecID = objBInput.Update(intFormID, 1)
                                                Else
                                                    lngRecID = objBInput.Update(intFormID, 0, True)
                                                End If

                                                If Not lngRecID = 0 Then
                                                    intImportCount = intImportCount + 1
                                                    'Phuong Modify 
                                                    'B3 Import HodingNo from Fields852
                                                    Call InsertHoding852(arrFieldName, arrFieldValue, objBInput.WorkID)
                                                    'E3
                                                End If
                                            Else    ' Is authority
                                                objBInput.ItemCode = ""
                                                If ddlImportMode.SelectedValue = 0 Then
                                                    lngRecID = objBInput.UpdateAuthority(intFormID, 1)
                                                Else
                                                    lngRecID = objBInput.UpdateAuthority(intFormID, 0, True)
                                                End If

                                                If Not lngRecID = 0 Then
                                                    intImportCount = intImportCount + 1
                                                    'Phuong Modify 
                                                    'B3 Import HodingNo from Fields852
                                                    Call InsertHoding852(arrFieldName, arrFieldValue, objBInput.WorkID)
                                                    'E3
                                                End If
                                            End If
                                        End If
                                    Next
                                Else  ' If pattern is MARC21 (raw)
                                    For intArrIndex = intLRange - 1 To intRRange - 1
                                        Call BindPrg(intArrIndex, intRRange)   ' Display the progress bar
                                        strTemp = Trim(Replace(arrForms(intArrIndex), vbCrLf, ""))
                                        If strTemp <> "" Then
                                            objBInput.ParseISORec(Replace(arrForms(intArrIndex), vbCrLf, ""), arrFieldName, arrFieldValue)
                                            Dim lngRecID As Long = 0
                                            If objBInput.ErrorMsg = "" Then

                                                'Lay nhung bieu ghi co muc do mat <=0
                                                '
                                                Dim intTag926 As Integer = 0
                                                intIndex = objBInput.FindIndex(arrFieldName, "926")
                                                If intIndex >= 0 Then
                                                    If Not IsNothing(arrFieldValue(intIndex)) AndAlso arrFieldValue(intIndex) <> "" Then
                                                        intTag926 = arrFieldValue(intIndex)
                                                    End If
                                                End If
                                                If intTag926 <= 0 Then
                                                    'PhuongTT 2014.12.26
                                                    'CheckDuplicate
                                                    'If Not chekDuplicateRecord(arrFieldName, arrFieldValue) Then
                                                    ReDim Preserve arrFieldName(UBound(arrFieldName) + 1)
                                                    ReDim Preserve arrFieldValue(UBound(arrFieldValue) + 1)

                                                    arrFieldName(UBound(arrFieldName)) = "911"
                                                    arrFieldValue(UBound(arrFieldValue)) = clsSession.GlbUserFullName

                                                    objBInput.FieldName = arrFieldName
                                                    objBInput.FieldValue = arrFieldValue

                                                    ' Is biography
                                                    If Session("IsAuthority") = 0 Then
                                                        If ddlImportMode.SelectedValue = 0 Then
                                                            lngRecID = objBInput.Update(intFormID, 1)
                                                        Else
                                                            lngRecID = objBInput.Update(intFormID, 0, True)
                                                        End If
                                                    Else    ' Is authority
                                                        objBInput.ItemCode = ""
                                                        If ddlImportMode.SelectedValue = 0 Then
                                                            lngRecID = objBInput.UpdateAuthority(intFormID, 1)
                                                        Else
                                                            lngRecID = objBInput.UpdateAuthority(intFormID, 0, True)
                                                        End If
                                                    End If
                                                    'Else
                                                    '    intImportCountDuplicate += 1
                                                    'End If
                                                End If
                                            End If
                                            If Not lngRecID = 0 Then
                                                intImportCount = intImportCount + 1
                                                'Phuong Modify 
                                                'B3 Import HodingNo from Fields852
                                                Call InsertHoding852(arrFieldName, arrFieldValue, objBInput.WorkID)
                                                'E3
                                            End If
                                        End If

                                    Next
                                End If
                                Response.Write("</SPAN>")
                                If intImportCount <> 0 Then
                                    lblSuccess.Visible = True
                                    lblFail.Visible = False
                                    lblTotal.Visible = True
                                    lblCount.Visible = True
                                    lblCount.Text = " " & intImportCount
                                    lblTotalDuplicate.Visible = True
                                    lblCountDuplicate.Visible = True
                                    lblCountDuplicate.Text = " " & intImportCountDuplicate
                                    If Session("isAuthority") = 0 Then
                                        Call WriteLog(87, ddlLabel.Items(9).Text & lblTotal.Text & " " & intImportCount, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                                    Else
                                        Call WriteLog(87, ddlLabel.Items(10).Text & lblTotal.Text & " " & intImportCount, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                                    End If
                                Else
                                    ' If no records imported
                                    lblSuccess.Visible = False
                                    lblFail.Visible = True
                                    lblTotal.Visible = True
                                    lblCount.Visible = True
                                    lblCount.Text = " " & intImportCount
                                    lblTotalDuplicate.Visible = True
                                    lblCountDuplicate.Visible = True
                                    lblCountDuplicate.Text = " " & intImportCountDuplicate
                                End If
                            Else
                                ' Invalid range
                                Page.RegisterClientScriptBlock("InvalidRange", "<script language='JavaScript'>alert('" & ddlLabel.Items(3).Text & "')</script>")
                                lblFail.Visible = False
                                lblSuccess.Visible = False
                                lblTotal.Visible = False
                                lblCount.Visible = False
                                lblTotalDuplicate.Visible = False
                                lblCountDuplicate.Visible = False
                            End If
                        End If

                        ' Reset the value for the controls
                        txtLRange.Text = ""
                        txtRRange.Text = ""
                        ddlEncode.SelectedIndex = 0

                        ' Delete the uploaded file
                        Dim filUpload As File
                        filUpload.Delete(strPath & "\" & strFileNameTemp)
                    End If
                Next
            Else
                Page.RegisterClientScriptBlock("JSInvalidData", "<script language = 'javascript'> alert('" & ddlLabel.Items(5).Text & "'); </script>")
            End If
        End Sub

        Private Function chekDuplicateRecord(ByVal strArrFieldName() As Object, ByVal strArrFieldValue() As Object) As Boolean
            Dim bolResult As Boolean = False
            Try
                Dim _CheckField245 As String = ""
                Dim _CheckFiled100 As String = ""
                Dim _CheckField260c As String = ""
                For i As Integer = 0 To UBound(strArrFieldName)
                    If Not strArrFieldName(i) Is Nothing AndAlso Not strArrFieldName(i) Is Nothing Then
                        Select Case strArrFieldName(i)
                            Case "245", "246"
                                ' _CheckField245 = objBCSP.UTF8ToUCS2(strArrFieldValue(i))
                                _CheckField245 = strArrFieldValue(i)
                                Dim arr245Val() As Object = Nothing
                                Call objBInput.ParseField("$a", Replace(_CheckField245, """", "&quot;"), "tr", arr245Val)
                                If Not arr245Val(0) Is Nothing AndAlso arr245Val(0) <> "" Then
                                    _CheckField245 = arr245Val(0).Trim
                                End If
                            Case "100", "110"
                                '_CheckFiled100 = objBCSP.UTF8ToUCS2(strArrFieldValue(i))
                                _CheckFiled100 = strArrFieldValue(i)
                                Dim arr100Val() As Object = Nothing
                                Call objBInput.ParseField("$a", Replace(_CheckFiled100, """", "&quot;"), "tr", arr100Val)
                                If Not arr100Val(0) Is Nothing AndAlso arr100Val(0) <> "" Then
                                    _CheckFiled100 = arr100Val(0).Trim
                                End If
                            Case "260"
                                '_CheckField260c = objBCSP.UTF8ToUCS2(strArrFieldValue(i))
                                _CheckField260c = strArrFieldValue(i)
                                Dim arr260Val() As Object = Nothing
                                Call objBInput.ParseField("$c,$g", _CheckField260c, "tr", arr260Val)
                                _CheckField260c = ""
                                If Not arr260Val(0) Is Nothing AndAlso arr260Val(0) <> "" Then
                                    _CheckField260c &= arr260Val(0).Trim
                                End If
                                If Not arr260Val(1) Is Nothing AndAlso arr260Val(1) <> "" Then
                                    _CheckField260c &= arr260Val(1).Trim
                                End If
                        End Select
                    End If
                Next
                Dim BoolArr()
                Dim FieldArr()
                Dim ValArr()
                Dim intk As Integer = 0
                If _CheckField245 <> "" Then
                    ReDim Preserve BoolArr(intk)
                    ReDim Preserve FieldArr(intk)
                    ReDim Preserve ValArr(intk)
                    BoolArr(intk) = "AND"
                    FieldArr(intk) = "TI"
                    ValArr(intk) = _CheckField245
                    intk = intk + 1
                End If
                If _CheckField260c <> "" Then
                    ReDim Preserve BoolArr(intk)
                    ReDim Preserve FieldArr(intk)
                    ReDim Preserve ValArr(intk)
                    BoolArr(intk) = "AND"
                    FieldArr(intk) = "YR"
                    ValArr(intk) = _CheckField260c
                    intk = intk + 1
                End If
                If _CheckFiled100 <> "" Then
                    ReDim Preserve BoolArr(intk)
                    ReDim Preserve FieldArr(intk)
                    ReDim Preserve ValArr(intk)
                    BoolArr(intk) = "AND"
                    FieldArr(intk) = "1" 'Dictionary Table: 1-->Author, 2-->Publisher,...
                    ValArr(intk) = _CheckFiled100
                    intk = intk + 1
                End If

                Dim strSQL As String = ""
                Dim tblItem As DataTable
                ' Form the sql string and get Items
                objBFormingSQL.BoolArr = BoolArr
                objBFormingSQL.FieldArr = FieldArr
                objBFormingSQL.ValArr = ValArr
                strSQL = objBFormingSQL.FormingASQL()
                objBCDS.SQLStatement = strSQL
                tblItem = objBCDS.RetrieveItemInfor()
                If Not IsNothing(tblItem) AndAlso tblItem.Rows.Count > 0 Then
                    bolResult = True
                End If
            Catch ex As Exception
            End Try
            Return bolResult
        End Function

        'Phuong Modify 
        'B3 Import HodingNo from Fields852
        Private Sub InsertHoding852(ByVal jarrFieldName() As Object, ByVal jarrFieldValue() As Object, ByVal jItemcode As Integer)
            Try
                Dim intmarcName As Integer = UBound(jarrFieldName)
                Dim marcNameDollarA As String = ""
                Dim marcNameDollarB As String = ""
                Dim marcNameDollarJ As String = ""
                Dim objRec As Object
                Dim dupHoding As Object
                Dim intdupHoding As Integer = 0
                Dim iBol As Boolean = False
                Dim tblItem As New DataTable
                Dim strItemID As String = ""
                For kk As Integer = 0 To intmarcName
                    If jarrFieldName(kk) = "852" Then
                        dupHoding = Split(jarrFieldValue(kk).trim, "::")
                        intdupHoding = UBound(dupHoding)
                        For jj As Integer = 0 To intdupHoding
                            If Not dupHoding(jj).trim = "" Then
                                objBCSP.ParseField("$a,$b,$j", dupHoding(jj), "tr", objRec)
                                If objRec(2) & "" <> "" Then
                                    marcNameDollarJ = objBCSP.GEntryTrim(Replace(objRec(2), "'", "\'"))
                                    If Not marcNameDollarJ = "" Then
                                        'If objRec(0) & "" <> "" Then
                                        '    marcNameDollarA = objBCSP.GEntryTrim(Replace(objRec(0), "'", "\'"))
                                        'End If
                                        'Dim intLocVal As Integer = 0
                                        'Dim intLibVal As Integer = 0
                                        'If objRec(1) & "" <> "" Then
                                        '    marcNameDollarB = objBCSP.GEntryTrim(Replace(objRec(1), "'", "\'"))
                                        '    objBLibrary.Code = marcNameDollarA
                                        '    objBLibrary.Name = marcNameDollarA
                                        '    objBLibrary.Address = ""
                                        '    objBLibrary.AccessEntry = marcNameDollarA
                                        '    intLibVal = objBLibrary.Create
                                        '    If Not marcNameDollarB = "" Then
                                        '        objBLibrary.Code = marcNameDollarA
                                        '        intLibVal = objBLibrary.SelectID()
                                        '        If intLibVal > 0 Then
                                        '            objBLocation.Symbol = marcNameDollarB
                                        '            objBLocation.CodeLoc = marcNameDollarB
                                        '            objBLocation.LibID = intLibVal
                                        '            objBLocation.UserID = Session("UserID")
                                        '            intLocVal = objBLocation.CreateAndGetID()
                                        '        End If
                                        '    End If
                                        'End If

                                        If Not iBol Then
                                            objBItem.ItemID = jItemcode
                                            objBItem.Code = ""
                                            tblItem = objBItem.GetItems
                                            If Not tblItem Is Nothing AndAlso tblItem.Rows.Count > 0 Then
                                                strItemID = tblItem.Rows(0).Item("Code")
                                            End If
                                            iBol = True
                                        End If

                                        For xx As Integer = 0 To marcNameDollarJ.Length / 8 - 1
                                            Dim DollarJ = Mid(marcNameDollarJ, 8 * xx + 1, 8)
                                            objBCopyNumber.Code = strItemID
                                            'objBCopyNumber.HolLibID = intLibVal
                                            objBCopyNumber.HolLibID = 1 'Thư viện HVHK (VAA)
                                            objBCopyNumber.LoanTypeID = 1
                                            objBCopyNumber.StartHolding = DollarJ
                                            objBCopyNumber.Price = 0

                                            objBCopyNumber.Range = 1
                                            'objBCopyNumber.LocID = intLocVal
                                            objBCopyNumber.LocID = 2 'Cơ sở 2 (CS2)
                                            objBCopyNumber.ChangeDate = Format(Date.Today.Now, "dd/MM/yyyy")
                                            objBCopyNumber.Shelf = ""
                                            objBCopyNumber.AcqSourceID = 1

                                            ' Add Holding
                                            Dim bytErrAddHold As Byte
                                            'Chinh add Fix Convert Excel DKCB cho truong DH FPT Tp.HCM
                                            'bytErrAddHold = objBCopyNumber.Create_FPT
                                            bytErrAddHold = objBCopyNumber.Create
                                        Next
                                    End If
                                End If
                            End If
                        Next
                    End If
                Next
            Catch ex As Exception
            End Try
        End Sub
 
        ' BindPrg method 
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

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBForm Is Nothing Then
                    objBForm.Dispose(True)
                    objBForm = Nothing
                End If
                If Not objBCDS Is Nothing Then
                    objBCDS.Dispose(True)
                    objBCDS = Nothing
                End If
                If Not objBInput Is Nothing Then
                    objBInput.Dispose(True)
                    objBInput = Nothing
                End If

                'Phuong Modify 
                'B4 Import HodingNo from Fields852
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBFormingSQL Is Nothing Then
                    objBFormingSQL.Dispose(True)
                    objBFormingSQL = Nothing
                End If
                If Not objBLocation Is Nothing Then
                    objBLocation.Dispose(True)
                    objBLocation = Nothing
                End If
                If Not objBLibrary Is Nothing Then
                    objBLibrary.Dispose(True)
                    objBLibrary = Nothing
                End If
                If Not objBCopyNumber Is Nothing Then
                    objBCopyNumber.Dispose(True)
                    objBCopyNumber = Nothing
                End If
                If Not objBItem Is Nothing Then
                    objBItem.Dispose(True)
                    objBItem = Nothing
                End If
                'E4
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace