' Class: WCataModify
' Purpose: Display modify form
' Creator: Oanhtn
' CreatedDate: 29/06/2004
' Modification history:
'   - 03/03/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WCataModify
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBItemCollection As New clsBItemCollection
        Private objBItem As New clsBItem
        Private objBCatalogueForm As New clsBCatalogueForm
        Private objBCSP As New clsBCommonStringProc
        Dim intUTF As Integer = 0

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            If Page.IsPostBack Then
                Me.SetResourceForControls()
            End If
            If Request("FormID") <> "" Then
                txtFormID.Value = Request("FormID")
                txtHolding.Value = 0
            End If
            Call Initialize()
            Call BindJavascripts()
            Call BindData()
            If CInt(Session("IsAuthority")) = 1 Then
                btnHolding.Visible = False
                btnCatalogue.Visible = False
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            If IsNumeric(Request("Authority")) Then
                Session("IsAuthority") = CInt(Request("Authority"))
            Else
                If Not IsNumeric(Session("IsAuthority")) Then
                    Session("IsAuthority") = 0
                End If
            End If
            If Request("Holdings") = 1 Then
                btnHolding.Enabled = False
            Else
                btnCatalogue.Enabled = False
            End If

            ' Init objBCatalogueForm object
            objBCatalogueForm.InterfaceLanguage = Session("InterfaceLanguage")
            objBCatalogueForm.DBServer = Session("DBServer")
            objBCatalogueForm.ConnectionString = Session("ConnectionString")
            objBCatalogueForm.IsAuthority = CInt(Session("IsAuthority"))
            Call objBCatalogueForm.Initialize()

            ' Init objBItemCollection object
            objBItemCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemCollection.DBServer = Session("DBServer")
            objBItemCollection.ConnectionString = Session("ConnectionString")
            objBItemCollection.IsAuthority = CInt(Session("IsAuthority"))
            Call objBItemCollection.Initialize()


            ' Init objBItemCollection object
            objBItem.InterfaceLanguage = Session("InterfaceLanguage")
            objBItem.DBServer = Session("DBServer")
            objBItem.ConnectionString = Session("ConnectionString")
            objBItem.IsAuthority = CInt(Session("IsAuthority"))
            Call objBItem.Initialize()

            ' Init objBCSP
            objBCSP.InterfaceLanguage = Session("InterfaceLanguage")
            objBCSP.DBServer = Session("DBServer")
            objBCSP.ConnectionString = Session("ConnectionString")
            Call objBCSP.Initialize()

            ' UTF variable
            If Not UCase(Session("InterfaceLanguage")) = "ENGLISH" Then
                intUTF = 1
            End If

            Call resetSessionUpload()
        End Sub

        'Reset session upload every request.
        Private Sub resetSessionUpload()
            Try
                Session("uploadFiles") = Nothing
            Catch ex As Exception
            End Try
        End Sub

        ' CheckFormPermission method
        ' Purpose: check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(2) Then
                btnNew.Enabled = False
            End If
            If Not CheckPemission(173) Then
                btnOverlay.Visible = False
            End If
            If Not CheckPemission(3) Then
                btnUpdate.Enabled = False
                btnOverlay.Enabled = False
            End If
            If Session("IsAuthority") = "1" Then
                btnOverlay.Visible = False
            End If
        End Sub

        ' BindJavascripts method
        ' Purpose: include all necessary javascript Functions
        Private Sub BindJavascripts()
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "WCommonJs", "<script type = 'text/javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>", False)
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "WCataSentJs", "<script type = 'text/javascript' src = '../Js/Catalogue/WCataSent.js'></script>", False)
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "WCataModifyJs", "<script type = 'text/javascript' src = '../Js/Catalogue/WCataModify.js'></script>", False)

            btnCatalogue.Attributes.Add("OnClick", "javascript:this.disabled = true;document.forms[0].btnHolding.disabled=false; OnLoad(); return false;")
            btnHolding.Attributes.Add("OnClick", "javascript:this.disabled = true;document.forms[0].btnCatalogue.disabled=false; ShowCopynumber(); return false;")
            btnMoveFirst.Attributes.Add("OnClick", "javascript:MoveFirst(); return false;")
            btnMovePrev.Attributes.Add("OnClick", "javascript:MovePrev(); return false;")
            btnMoveNext.Attributes.Add("OnClick", "javascript:MoveNext(); return false;")
            btnMoveLast.Attributes.Add("OnClick", "javascript:MoveLast(); return false;")
            btnNew.Attributes.Add("OnClick", "javascript:NewItem(); return false;")
            btnFilter.Attributes.Add("OnClick", "javascript:FilterItem(); return false;")
            txtCurrentRec.Attributes.Add("OnChange", "javascript:MoveTo(this);")
        End Sub

        Private Function InitRequest(ByRef intCheckUpdate As Integer, ByRef lngTotalRec As Long) As Integer
            Dim lngItemID As Long = 0
            Dim lngCurrentRec As Long = 0
            Dim intSelectOption As Integer = 0
            Dim intFormID As Integer = 0
            Dim arrFilteredItemID() As String
            Dim tblRangeItemID As DataTable ' Contents the range of ItemID
            Dim tblTemp As DataTable

            objBItemCollection.LibID = clsSession.GlbSite
            intCheckUpdate = 1

            'Precedence order ItemID retrieve is Session("strIDs") -> Session("sqlFilter") & Current Record -> Request("ItemID")
            If Not Request("ItemID") = "" Then
                txtItemID.Value = Request("ItemID")
                lngItemID = CLng(txtItemID.Value)
            End If

            If Request("Clone") <> "" Then
                txtClone.Value = Request("Clone")
                If Request("Clone") = 1 Then
                    intCheckUpdate = 0
                End If
            End If

            If Request("CurrentID") <> "" AndAlso txtFunc.Value = "" Then
                If Request("CurrentID") = "0" Then
                    objBItemCollection.ItemID = CInt(Request("ItemID"))
                    objBItemCollection.LibID = clsSession.GlbSite
                    tblTemp = objBItemCollection.GetTopNumByID
                    If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                        txtCurrentRec.Text = tblTemp.Rows(0).Item("TopNum")
                        tblTemp.Dispose()
                        tblTemp = Nothing
                    End If
                Else
                    txtCurrentRec.Text = Request("CurrentID")
                End If
            End If

            If txtCurrentRec.Text = "" Then
                txtCurrentRec.Text = 1
            End If

            ' Hide some controls when reusing
            If Request("Reuse") <> "" Then
                Session("Reuse") = 1
                Call HideControls()
            End If

            lngCurrentRec = CLng(txtCurrentRec.Text)

            ' Incase moving data
            If Not txtFunc.Value = "" Then
                ' Get ItemID
                objBItemCollection.TopNum = lngCurrentRec
                tblTemp = objBItemCollection.GetIDByTopNum(Session("sqlFilter") & "")

                If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                    txtItemID.Value = tblTemp.Rows(0).Item("MaxID")
                    lngItemID = CLng(txtItemID.Value)
                    lngTotalRec = Session("TotalRecord")
                    tblTemp.Dispose()
                    tblTemp = Nothing
                End If
            End If

            'Huy bo ket qua loc (Thumuc-->Xem-->Loc) truoc khi chuyen den bieu ghi de sua --> Tranh bao loi
            If Not Request("FindModify") Is Nothing Then
                Session("sqlFilter") = Nothing
                Session("Filter") = Nothing
                Session("arrFilteredItemID") = Nothing
                Session("TotalRecord") = Nothing
                Session("strIDs") = Nothing
            End If

            If Session("strIDs") & "" <> "" Then
                arrFilteredItemID = CStr(Session("strIDs")).Split(",")
                txtItemID.Value = arrFilteredItemID(lngCurrentRec - 1)
                lngItemID = CLng(txtItemID.Value)
                lngTotalRec = arrFilteredItemID.Length
            ElseIf Session("sqlFilter") <> "" Then
                objBItemCollection.TopNum = lngCurrentRec
                tblTemp = objBItemCollection.GetIDByTopNum(Session("sqlFilter") & "")
                If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                    txtItemID.Value = tblTemp.Rows(0).Item("MaxID")
                    lngItemID = CLng(txtItemID.Value)
                    lngTotalRec = Session("TotalRecord")
                    tblTemp.Dispose()
                    tblTemp = Nothing
                End If
            Else
                objBItemCollection.LibID = clsSession.GlbSite
                tblRangeItemID = objBItemCollection.GetRangeItemID
                If Not tblRangeItemID Is Nothing AndAlso tblRangeItemID.Rows.Count > 0 Then
                    If txtItemID.Value = "0" Then
                        txtItemID.Value = tblRangeItemID.Rows(0).Item("MinID")
                    End If
                    lngItemID = CLng(txtItemID.Value)
                    lngTotalRec = tblRangeItemID.Rows(0).Item("Total")
                End If
            End If
            ' Display total of record
            txtTotalRec.Text = lngTotalRec
            Return lngItemID
        End Function

        Private Function GetItemInformation(ByVal lngItemID As Integer) As DataTable
            Dim tblItemMainInfor As DataTable ' Contents main information of the selected Item (Item table)

            ' Get main information of current item
            objBItemCollection.ItemIDs = CStr(lngItemID)
            tblItemMainInfor = objBItemCollection.GetItemMainInfor
            If txtItemID.Value <> "" AndAlso tblItemMainInfor IsNot Nothing AndAlso tblItemMainInfor.Rows.Count <> 0 Then
                ' Load value for some textbox
                txtLeader.Value = tblItemMainInfor.Rows(0).Item("Leader")
                If Not CInt(txtFormID.Value) > 0 Then
                    txtFormID.Value = tblItemMainInfor.Rows(0).Item("FormID")
                End If
                Return tblItemMainInfor
            End If
            Return Nothing
        End Function

        Private Sub ProcessHolding(ByVal lngItemID As Long, ByVal lngTotalRec As Long, ByVal strCheckAllJS As String, ByVal strMess1 As String, ByVal strMess2 As String)
            Dim tblRangeItemID As DataTable ' Contents the range of ItemID
            Session("Holdings") = Session("Holdings") + 1
            objBItemCollection.ItemID = CInt(Request("ItemID"))

            tblRangeItemID = objBItemCollection.GetRangeItemID
            If Not tblRangeItemID Is Nothing AndAlso tblRangeItemID.Rows.Count > 0 Then
                txtItemID.Value = tblRangeItemID.Rows(0).Item("Total")
                txtCurrentRec.Text = tblRangeItemID.Rows(0).Item("Total")
                lngItemID = CLng(txtItemID.Value)
                lngTotalRec = tblRangeItemID.Rows(0).Item("Total")
            End If
            ' Display total of record
            txtTotalRec.Text = lngTotalRec
            txtHolding.Value = 1
            strCheckAllJS = ""
            strCheckAllJS = strCheckAllJS & "parent.Workform.focus();" & Chr(10)
            strCheckAllJS = strCheckAllJS & "self.focus();" & Chr(10)
            lblMyJS.Text = "<script language='javascript'>" & strCheckAllJS & Chr(10) & "parent.Workform.location.href = 'WCopyNumber.aspx?FormID=" & "" & Trim(txtFormID.Value) & "&Module=" & "" & Trim(txtModule.Value) & "&AddedFieldCodes=" & "" & Trim(txtAddedFieldCodes.Value) & "';</script>"

            ' Write event for all button on this form
            btnUpdate.Attributes.Add("OnClick", "javascript:CheckAll('" & strMess1 & "', '" & strMess2 & "', 'strMess3'); return false;")
            btnPreview.Attributes.Add("OnClick", "javascript:Preview(); return false;")
            btnValidate.Attributes.Add("OnClick", "javascript:ValidateMARC(0, 0); return false;")
            btnAddFields.Attributes.Add("OnClick", "javascript:AddFields(); return false;")
            btnSpellCheck.Attributes.Add("OnClick", "javascript:SpellCheck(); return false;")
            btnOverlay.Attributes.Add("OnClick", "javascript:OverlayRec(); return false;")
        End Sub

        Private Sub BindData()
            Dim strItemCode As String
            Dim lngItemID As Long = 0
            Dim lngCurrentRec As Long = 0
            Dim lngTotalRec As Long = 0
            Dim intSelectOption As Integer = 0
            Dim intFormID As Integer = 0
            Dim strFieldCodes As String
            Dim strAddedFieldCodes As String
            Dim strUsedFieldCodes As String = ""
            Dim strModifiedFieldCodes As String = ""
            Dim intCounter As Integer
            Dim strCheckAllJS As String = ""

            Dim tblRangeItemID As DataTable ' Contents the range of ItemID

            Dim tblItemDetailInfor As DataTable ' Contents detailed information of the selected Item (in Fieldxxxs tables)
            Dim tblModiFields As DataTable ' Contents all field user wants modify
            Dim tblDefaultValue As DataTable

            ' LabelString
            Dim strLabel5 As String = ddlLabel.Items(1).Text
            Dim strLabel6 As String = ddlLabel.Items(2).Text
            Dim strLabel10 As String = ddlLabel.Items(3).Text
            Dim strLabel20 As String = ddlLabel.Items(4).Text
            Dim strLabel22 As String = ddlLabel.Items(5).Text
            Dim strLabel23 As String = ddlLabel.Items(6).Text
            Dim strLabel24 As String = ddlLabel.Items(7).Text
            Dim strLabel25 As String = ddlLabel.Items(8).Text

            Dim strMsgCheckFieldValue As String = ddlLabel.Items(9).Text
            Dim strMsgNotEmptyValue As String = ddlLabel.Items(10).Text
            Dim strMsgErrorCode As String = ddlLabel.Items(11).Text

            'State marked for javascript function to work.
            Dim intCheckUpdate As Integer
            lngItemID = InitRequest(intCheckUpdate, lngCurrentRec)
            Dim tblItemMainInfor As DataTable = GetItemInformation(lngItemID)
            If tblItemMainInfor IsNot Nothing Then
                If Request("Holdings") = 1 And Session("Holdings") = 1 Then
                    ProcessHolding(lngItemID, lngTotalRec, strCheckAllJS, strMsgCheckFieldValue, strMsgNotEmptyValue)
                Else
                    If txtModifiedFieldCodes.Value <> "" Then
                        strModifiedFieldCodes = txtModifiedFieldCodes.Value
                    End If

                    Dim blnReviewed As Boolean = False

                    ' Get detailed information of the current item
                    objBItemCollection.ItemIDs = CStr(lngItemID)
                    tblItemDetailInfor = objBItemCollection.GetItemDetailInfor

                    ' Get some variables for retrieving contents of the current item
                    intFormID = CInt(txtFormID.Value)
                    strFieldCodes = ""
                    strUsedFieldCodes = ""
                    strAddedFieldCodes = txtAddedFieldCodes.Value

                    If txtFieldCodes.Value <> "" And txtUsedFieldCodes.Value = "" Then
                        strFieldCodes = txtFieldCodes.Value
                        strAddedFieldCodes = txtAddedFieldCodes.Value
                    Else
                        ' Get strUsedFieldCodes
                        strUsedFieldCodes = ""
                        For intCounter = 0 To tblItemDetailInfor.Rows.Count - 1
                            If Not InStr("," & strUsedFieldCodes & ",", "," & tblItemDetailInfor.Rows(intCounter).Item("FieldCode") & ",") > 0 Then
                                Dim strValFieldMARC As String = objBCSP.getSubFieldMARC(tblItemDetailInfor.Rows(intCounter).Item("FieldCode"), tblItemDetailInfor.Rows(intCounter).Item("Content"))
                                If strValFieldMARC <> "" Then
                                    strUsedFieldCodes &= strValFieldMARC & ","
                                End If
                            End If
                        Next
                        If Not strUsedFieldCodes = "" Then
                            strUsedFieldCodes = Left(strUsedFieldCodes, Len(strUsedFieldCodes) - 1)
                        End If
                    End If

                    ' Get content
                    objBCatalogueForm.FormID = intFormID
                    objBCatalogueForm.FieldCodes = strFieldCodes
                    objBCatalogueForm.AddedFieldCodes = strAddedFieldCodes
                    objBCatalogueForm.UsedFieldCodes = strUsedFieldCodes
                    tblModiFields = objBCatalogueForm.GetModiFields

                    ' Get default value from database (by form id)
                    objBCatalogueForm.Creator = clsSession.GlbUserFullName
                    tblDefaultValue = objBCatalogueForm.GetFields

                    ' Load form
                    Dim strPreviewJS As String = "" ' String Javascript to preview the content of the current item
                    Dim strHiddenFields As String = "" ' String contents all hidden field of this form
                    Dim strFieldValue As String = "" ' String content field' value
                    Dim blnMandatory As Boolean
                    'Dim strCheckAllJS As String = "" ' Validate data
                    Dim strJavaScript As String = "" ' Check null value of mandatory fields
                    Dim intCount As Integer
                    Dim intRowCount As Integer
                    Dim blnUseIndicator As Boolean
                    Dim chrInd1 As Char ' value of the first indicator
                    Dim chrInd2 As Char ' value of the second indicator
                    Dim strIndicators As String ' merger value of 2 indicator

                    Dim dtrData As DataRow() ' Datarows contain FieldID, FieldName after filtered

                    ' Create some javascript variables for process
                    strPreviewJS = strPreviewJS & "var strLabel5 = '" & strLabel5 & "';" & Chr(13)
                    strPreviewJS = strPreviewJS & "var strLabel6 = '" & strLabel6 & "';" & Chr(13)
                    strPreviewJS = strPreviewJS & "var strLabel10 = '" & strLabel10 & "';" & Chr(13)
                    strPreviewJS = strPreviewJS & "var strLabel22 = '" & strLabel22 & "';" & Chr(13)
                    strPreviewJS = strPreviewJS & "var strLabel23 = '" & strLabel23 & "';" & Chr(13)
                    strPreviewJS = strPreviewJS & "var strLabel24 = '" & strLabel24 & "';" & Chr(13)
                    strPreviewJS = strPreviewJS & "var strLabel25 = '" & strLabel25 & "';" & Chr(13)

                    'If Not tblModiFields.Rows.Count = 0 Then
                    If Not IsNothing(tblModiFields) AndAlso Not tblModiFields.Rows.Count = 0 Then
                        Dim strValueTemp As String = ""
                        strUsedFieldCodes = ""
                        strPreviewJS = strPreviewJS & "varStyleStheet = '" & String.Format("<link href=""{0}"" type=""text/css"" rel=""StyleSheet"">", Me.GetStyleSheetURL("Catalogue")) & "';" & Chr(13)
                        strPreviewJS = strPreviewJS & "var arrFieldCode = new Array(" & tblModiFields.Rows.Count + 1 & ");" & Chr(13)
                        strPreviewJS = strPreviewJS & "var arrFieldValue = new Array(" & tblModiFields.Rows.Count + 1 & ");" & Chr(13)

                        Dim bol900 As Boolean = False
                        For intCount = 0 To tblModiFields.Rows.Count - 1
                            ' Get UsedFieldCodes
                            strUsedFieldCodes = strUsedFieldCodes & tblModiFields.Rows(intCount).Item("FieldCode") & ","

                            blnMandatory = False
                            If Not IsDBNull(tblModiFields.Rows(intCount).Item("Mandatory")) Then
                                If CInt(tblModiFields.Rows(intCount).Item("Mandatory")) = 1 Then
                                    blnMandatory = True
                                End If
                            End If
                            If Not IsDBNull(tblModiFields.Rows(intCount).Item("AlwaysMandatory")) And Not blnMandatory Then
                                If CInt(tblModiFields.Rows(intCount).Item("AlwaysMandatory")) = 1 Then
                                    blnMandatory = True
                                End If
                            End If

                            If blnMandatory Then
                                If Not IsDBNull(tblModiFields.Rows(intCount).Item("ParentFieldCode")) Then
                                    If Not IsDBNull(tblModiFields.Rows(intCount).Item("Repeatable")) Then
                                        If Not UCase(Session("InterfaceLanguage")) = "ENGLISH" Then
                                            strJavaScript = strJavaScript & "if (CheckNullValue(document.forms[0].tag" & tblModiFields.Rows(intCount).Item("FieldCode") & ", '" & tblModiFields.Rows(intCount).Item("FieldCode") & "--" & tblModiFields.Rows(intCount).Item("VietFieldName") & "', '" & strMsgCheckFieldValue & "', '" & strMsgNotEmptyValue & "')) {return false;}" & Chr(10)
                                        Else
                                            strJavaScript = strJavaScript & "if (CheckNullValue(document.forms[0].tag" & tblModiFields.Rows(intCount).Item("FieldCode") & ", '" & tblModiFields.Rows(intCount).Item("FieldCode") & "--" & Replace(tblModiFields.Rows(intCount).Item("FieldName"), "'", "\'") & "', '" & strMsgCheckFieldValue & "', '" & strMsgNotEmptyValue & "')) {return false;}" & Chr(10)
                                        End If
                                    End If
                                Else
                                    If Not UCase(Session("InterfaceLanguage")) = "ENGLISH" Then
                                        strJavaScript = strJavaScript & "if (CheckNullValue(document.forms[0].tag" & tblModiFields.Rows(intCount).Item("FieldCode") & ", '" & tblModiFields.Rows(intCount).Item("FieldCode") & "--" & tblModiFields.Rows(intCount).Item("VietFieldName") & "', '" & strMsgCheckFieldValue & "', '" & strMsgNotEmptyValue & "')) {return false;}" & Chr(10)
                                    Else
                                        strJavaScript = strJavaScript & "if (CheckNullValue(document.forms[0].tag" & tblModiFields.Rows(intCount).Item("FieldCode") & ", '" & tblModiFields.Rows(intCount).Item("FieldCode") & "--" & Replace(tblModiFields.Rows(intCount).Item("FieldName"), "'", "\'") & "', '" & strMsgCheckFieldValue & "', '" & strMsgNotEmptyValue & "')) {return false;}" & Chr(10)
                                    End If
                                End If
                            End If

                            ' Create hidden fields
                            strFieldValue = ""
                            Select Case tblModiFields.Rows(intCount).Item("FieldCode")
                                Case "001" ' ItemCode
                                    ' Not Clone
                                    If Not txtClone.Value = "1" Then
                                        If Not Request("tag001") = "" And txtFunc.Value = "" Then
                                            strFieldValue = Request("tag001")
                                        Else
                                            strFieldValue = tblItemMainInfor.Rows(0).Item("Code")
                                        End If
                                    End If
                                    strItemCode = strFieldValue
                                Case "900" ' New catalogue
                                    bol900 = True
                                    If Not Request("tag900") = "" And txtFunc.Value = "" Then
                                        strFieldValue = Request("tag900")
                                    Else
                                        If CInt(tblItemMainInfor.Rows(0).Item("NewRecord")) = 0 Then
                                            strFieldValue = "False"
                                        Else
                                            strFieldValue = "True"
                                        End If
                                    End If
                                Case "907" ' Cover Picture
                                    If Not Request("tag907") = "" And txtFunc.Value = "" Then
                                        strFieldValue = Request("tag907")
                                    Else
                                        If Not IsDBNull(tblItemMainInfor.Rows(0).Item("CoverPicture")) Then
                                            strFieldValue = tblItemMainInfor.Rows(0).Item("CoverPicture")
                                        Else
                                            strFieldValue = ""
                                        End If
                                    End If
                                Case "911" ' Cataloguer
                                    If txtClone.Value = "1" Then
                                        strFieldValue = clsSession.GlbUserFullName
                                    ElseIf txtCataDetail.Value = "1" And blnReviewed Then
                                        strFieldValue = clsSession.GlbUserFullName
                                    Else
                                        If Not Request("tag911") = "" Then
                                            strFieldValue = Request("tag911")
                                        Else
                                            If Not IsDBNull(tblItemMainInfor.Rows(0).Item("Cataloguer")) Then
                                                strFieldValue = tblItemMainInfor.Rows(0).Item("Cataloguer")
                                            Else
                                                strFieldValue = ""
                                            End If
                                        End If
                                    End If
                                Case "912" ' Reviewer
                                    If Not Request("tag912") = "" And txtFunc.Value = "" Then
                                        strFieldValue = Request("tag912")
                                    Else
                                        If Not IsDBNull(tblItemMainInfor.Rows(0).Item("Reviewer")) Then
                                            strFieldValue = tblItemMainInfor.Rows(0).Item("Reviewer")
                                        Else
                                            strFieldValue = ""
                                        End If
                                    End If
                                Case "925" ' Medium
                                    If Not Request("tag925") = "" And txtFunc.Value = "" Then
                                        strFieldValue = Request("tag925")
                                    Else
                                        If Not IsDBNull(tblItemMainInfor.Rows(0).Item("MediumCode")) Then
                                            strFieldValue = tblItemMainInfor.Rows(0).Item("MediumCode")
                                        Else
                                            strFieldValue = ""
                                        End If
                                    End If
                                Case "926" ' AccessLevel
                                    If Not Request("tag926") = "" And txtFunc.Value = "" Then
                                        strFieldValue = Request("tag926")
                                    Else
                                        If Not IsDBNull(tblItemMainInfor.Rows(0).Item("AccessLevel")) Then
                                            strFieldValue = tblItemMainInfor.Rows(0).Item("AccessLevel")
                                        Else
                                            strFieldValue = ""
                                        End If
                                    End If
                                Case "927" ' ItemType
                                    If Not Request("tag927") = "" And txtFunc.Value = "" Then
                                        strFieldValue = Request("tag927")
                                    Else
                                        If Not IsDBNull(tblItemMainInfor.Rows(0).Item("TypeCode")) Then
                                            strFieldValue = tblItemMainInfor.Rows(0).Item("TypeCode")
                                        Else
                                            strFieldValue = ""
                                        End If
                                    End If
                                Case "852$t"
                                    If Not Request("tag852$t") = "" And txtFunc.Value = "" Then
                                        strFieldValue = Request("tag852$t")
                                    Else
                                        objBItem.ItemID = lngItemID
                                        Dim tblData As DataTable = objBItem.GetCopyNumbers()
                                        If Not IsNothing(tblData) Then
                                            If tblData.Rows.Count > 0 Then
                                                strFieldValue = tblData.Rows.Count
                                            Else
                                                strFieldValue = "0"
                                            End If
                                        End If
                                    End If
                                Case Else ' remaind fields
                                    If Request("tag" & tblModiFields.Rows(intCount).Item("FieldCode")) <> "" And txtFunc.Value = "" Then
                                        strFieldValue = Request("tag" & tblModiFields.Rows(intCount).Item("FieldCode"))
                                    ElseIf (Session(tblModiFields.Rows(intCount).Item("FieldCode"))) IsNot Nothing And CInt(Request("UseDefault")) = 1 Then
                                        strFieldValue = Session(tblModiFields.Rows(intCount).Item("FieldCode"))
                                    Else
                                        blnUseIndicator = False
                                        If Not IsDBNull(tblModiFields.Rows(intCount).Item("Indicators")) Or Not IsDBNull(tblModiFields.Rows(intCount).Item("VietIndicators")) Then
                                            blnUseIndicator = True
                                        End If
                                        dtrData = tblItemDetailInfor.Select("FieldCode='" & Left(tblModiFields.Rows(intCount).Item("FieldCode"), 3) & "'")
                                        If dtrData.Length <> 0 Then
                                            If tblModiFields.Rows(intCount).Item("FieldCode") = "245$b" Then
                                                strFieldValue = objBCSP.getValSubFieldMARC(tblModiFields.Rows(intCount).Item("FieldCode"), dtrData(0).Item("Content"))
                                                strFieldValue = strFieldValue.Replace(" : ", "##")
                                            ElseIf tblModiFields.Rows(intCount).Item("Repeatable") Then
                                                For intRowCount = 0 To dtrData.Length - 1
                                                    If blnUseIndicator Then ' UseIndicator
                                                        ' Get value of the first indicator
                                                        chrInd1 = " "
                                                        chrInd2 = " "
                                                        If Not IsDBNull(dtrData(intRowCount).Item("Ind1")) Then
                                                            If Not dtrData(intRowCount).Item("Ind1") = "" Then
                                                                chrInd1 = dtrData(intRowCount).Item("Ind1")
                                                            End If
                                                        End If
                                                        ' Get value of the second indicator
                                                        If Not IsDBNull(dtrData(intRowCount).Item("Ind2")) Then
                                                            If Not dtrData(intRowCount).Item("Ind2") = "" Then
                                                                chrInd2 = dtrData(intRowCount).Item("Ind2")
                                                            End If
                                                        End If
                                                        strIndicators = chrInd1 & chrInd2
                                                        strValueTemp = objBCSP.getValSubFieldMARC(tblModiFields.Rows(intCount).Item("FieldCode"), dtrData(intRowCount).Item("Content"))
                                                        If strValueTemp <> "" Then
                                                            strFieldValue = strFieldValue & strIndicators.Trim() & "::" & strValueTemp & "$&"
                                                        End If
                                                    Else
                                                        strValueTemp = objBCSP.getValSubFieldMARC(tblModiFields.Rows(intCount).Item("FieldCode"), dtrData(intRowCount).Item("Content"))
                                                        If strValueTemp <> "" Then
                                                            strFieldValue = strFieldValue & strValueTemp & "$&"
                                                        End If
                                                    End If
                                                Next
                                            Else
                                                If blnUseIndicator Then
                                                    ' Get value of the first indicator
                                                    chrInd1 = " "
                                                    chrInd2 = " "
                                                    If Not IsDBNull(dtrData(0).Item("Ind1")) AndAlso dtrData(0).Item("Ind1") <> "" Then
                                                        chrInd1 = dtrData(0).Item("Ind1")
                                                    End If
                                                    ' Get value of the second indicator
                                                    If Not IsDBNull(dtrData(0).Item("Ind2")) AndAlso dtrData(0).Item("Ind2") <> "" Then
                                                        chrInd2 = dtrData(0).Item("Ind2")
                                                    End If
                                                    strIndicators = chrInd1 & chrInd2
                                                    strValueTemp = objBCSP.getValSubFieldMARC(tblModiFields.Rows(intCount).Item("FieldCode"), dtrData(0).Item("Content"))
                                                    If strValueTemp <> "" Then
                                                        strFieldValue = strIndicators.Trim() & "::" & strValueTemp
                                                    End If
                                                Else
                                                    strValueTemp = objBCSP.getValSubFieldMARC(tblModiFields.Rows(intCount).Item("FieldCode"), dtrData(0).Item("Content"))
                                                    If strValueTemp <> "" Then
                                                        strFieldValue = strValueTemp
                                                    End If
                                                End If
                                            End If
                                        Else
                                            strFieldValue = ""
                                        End If
                                        dtrData = tblItemDetailInfor.Select()
                                    End If
                            End Select

                            ' FieldValue null
                            If strFieldValue = "" And CInt(Request("UseDefault")) = 1 Then
                                If InStr(strModifiedFieldCodes, tblModiFields.Rows(intCount).Item("FieldCode")) = 0 Then
                                    strModifiedFieldCodes = strModifiedFieldCodes & tblModiFields.Rows(intCount).Item("FieldCode") & ","
                                End If
                                Dim dtrow() As DataRow
                                dtrow = tblDefaultValue.Select("FieldCode = '" & tblModiFields.Rows(intCount).Item("FieldCode") & "'")
                                If dtrow.Length > 0 Then
                                    If Not IsDBNull(tblModiFields.Rows(intCount).Item("Indicators")) Or Not IsDBNull(tblModiFields.Rows(intCount).Item("VietIndicators")) Then
                                        If Not IsDBNull(dtrow(0).Item("DefaultIndicators")) Then
                                            strFieldValue = dtrow(0).Item("DefaultIndicators") & "::" & dtrow(0).Item("DefaultValue")
                                        Else
                                            If Not IsDBNull(dtrow(0).Item("DefaultValue")) Then
                                                strFieldValue = dtrow(0).Item("DefaultValue")
                                            End If
                                        End If
                                    Else
                                        If Not IsDBNull(dtrow(0).Item("DefaultValue")) Then
                                            strFieldValue = dtrow(0).Item("DefaultValue")
                                        End If
                                    End If
                                End If
                                If Not (Session(tblModiFields.Rows(intCount).Item("FieldCode"))) Is Nothing Then
                                    strFieldValue = Session(tblModiFields.Rows(intCount).Item("FieldCode"))
                                End If
                            Else
                                If Left(strFieldValue.Trim(), 3) = ":::" Then
                                    strFieldValue = strFieldValue.Replace(":::", "::")
                                End If
                                strFieldValue = strFieldValue.Replace("""", "&quot;").Replace(Chr(10), "").Replace(Chr(13), "")
                            End If

                            ' Create hidden fields
                            Dim fieldCode As String = tblModiFields.Rows(intCount).Item("FieldCode")
                            If fieldCode = "245$n" OrElse fieldCode = "245$p" Then
                                strFieldValue = strFieldValue.Replace("$&", "##")
                                Dim arrs() As String = strFieldValue.Split(New String() {"##"}, StringSplitOptions.None)
                                strFieldValue = ""
                                For Each s As String In arrs
                                    s = s.Trim()
                                    If s <> "" Then
                                        If s.EndsWith(" ,") OrElse s.EndsWith(" .") OrElse s.EndsWith(" /") Then
                                            s = s.Substring(0, s.Length - 2)
                                        End If
                                        strFieldValue &= s.Trim() & "$&"
                                    End If
                                Next
                            End If

                            strHiddenFields = strHiddenFields & "<input type=""hidden"" runat=""server"" id=""tag" & tblModiFields.Rows(intCount).Item("FieldCode") & """  name=""tag" & tblModiFields.Rows(intCount).Item("FieldCode") & """ value=""" & strFieldValue & """>" & Chr(10)
                            strPreviewJS = strPreviewJS & "arrFieldCode[" & intCount + 1 & "] = '" & tblModiFields.Rows(intCount).Item("FieldCode") & "';" & Chr(13)
                            strFieldCodes = strFieldCodes & tblModiFields.Rows(intCount).Item("FieldCode") & ","
                        Next
                        If Not bol900 AndAlso CInt(Session("IsAuthority")) <> 1 Then
                            ' Create hidden fields
                            strHiddenFields = strHiddenFields & "<input type=""hidden"" runat=""server"" id=""tag900""  name=""tag900"" value=""" & strFieldValue & """>" & Chr(10)
                            strPreviewJS = strPreviewJS & "arrFieldCode[" & intCount + 1 & "] = '900';" & Chr(13)
                            strFieldCodes = strFieldCodes & "900" & ","
                        Else
                            If InStr(strHiddenFields, "tag900") = 0 AndAlso CInt(Session("IsAuthority")) <> 1 Then
                                strHiddenFields = strHiddenFields & "<input type=""hidden"" runat=""server"" id=""tag900""  name=""tag900"" value="">" & Chr(10)
                            End If
                        End If
                    End If

                    ' Write hidden fields to form
                    If Not strHiddenFields = "" Then
                        lblHiddenField.Text = strHiddenFields
                    End If

                    ' Create CheckAll Js functions to check null value of all field' value
                    strCheckAllJS = strCheckAllJS & "function CheckAll() {" & Chr(10)
                    strCheckAllJS = strCheckAllJS & "parent.Workform.focus();" & Chr(10)
                    strCheckAllJS = strCheckAllJS & "self.focus();" & Chr(10)
                    ' Check RightLevel (Only user' RightLevel = 2 Or user is administrator)
                    If Not UCase(clsSession.GlbUserFullName) = "ADMINISTRATOR" And Not Session("RightLevel") = 2 Then
                        strCheckAllJS = strCheckAllJS & "if (document.forms[0].tag911.value == '" & clsSession.GlbUserFullName & "' || document.forms[0].tag911.value == '') {" & Chr(10)
                    End If
                    strCheckAllJS = strCheckAllJS & "if (CheckNullValue(document.forms[0].txtLeader, '" & strMsgErrorCode & "', '" & strMsgCheckFieldValue & "', '" & strMsgNotEmptyValue & "')) { return false; }" & Chr(10)
                    strCheckAllJS = strCheckAllJS & strJavaScript
                    strCheckAllJS = strCheckAllJS & "ValidateMARC(1, " & intCheckUpdate & ");" & Chr(10)
                    If Not UCase(clsSession.GlbUserFullName) = "ADMINISTRATOR" And Not Session("RightLevel") = 2 Then
                        strCheckAllJS = strCheckAllJS & "} else {" & Chr(10)
                        strCheckAllJS = strCheckAllJS & "alert('" & strLabel20 & "');" & Chr(10)
                        strCheckAllJS = strCheckAllJS & "}" & Chr(10)
                    End If
                    strCheckAllJS = strCheckAllJS & "}" & Chr(10) & Chr(10)

                    ' Create CheckAll Js functions to check null value of all field's value but not submit
                    Dim strCheckAll1Js As String = ""

                    strCheckAll1Js = strCheckAll1Js & "function CheckAll1() {" & Chr(10)
                    strCheckAll1Js = strCheckAll1Js & "parent.Workform.focus();" & Chr(10)
                    strCheckAll1Js = strCheckAll1Js & "self.focus();" & Chr(10)
                    ' Check RightLevel (Only user' RightLevel = 2 Or user is administrator)
                    If Not UCase(clsSession.GlbUserFullName) = "ADMINISTRATOR" And Not Session("RightLevel") = 2 Then
                        strCheckAll1Js = strCheckAll1Js & "if (document.forms[0].tag911.value == '" & clsSession.GlbUserFullName & "' || document.forms[0].tag911.value == '') {" & Chr(10)
                    End If
                    strCheckAll1Js = strCheckAll1Js & "if (CheckNullValue(document.forms[0].txtLeader, '" & strMsgErrorCode & "', '" & strMsgCheckFieldValue & "', '" & strMsgNotEmptyValue & "')) { return false; }" & Chr(10)
                    strCheckAll1Js = strCheckAll1Js & strJavaScript
                    strCheckAll1Js = strCheckAll1Js & "ValidateMARC(0, 0);" & Chr(10)
                    If Not UCase(clsSession.GlbUserFullName) = "ADMINISTRATOR" And Not Session("RightLevel") = 2 Then
                        strCheckAll1Js = strCheckAll1Js & "} else {" & Chr(10)
                        strCheckAll1Js = strCheckAll1Js & "alert('" & strLabel20 & "');" & Chr(10)
                        strCheckAll1Js = strCheckAll1Js & "}" & Chr(10)
                    End If
                    strCheckAll1Js = strCheckAll1Js & "}" & Chr(10) & Chr(10)

                    ' Create OverlayRec Js functions
                    strCheckAllJS = strCheckAllJS & "function OverlayRec() {" & Chr(10)
                    strCheckAllJS = strCheckAllJS & "parent.Workform.focus();" & Chr(10)
                    strCheckAllJS = strCheckAllJS & "self.focus();" & Chr(10)

                    ' Check RightLevel (Only user' RightLevel = 2 Or user is administrator)
                    If Not UCase(clsSession.GlbUserFullName) = "ADMINISTRATOR" And Not Session("RightLevel") = 2 Then
                        strCheckAllJS = strCheckAllJS & "if (document.forms[0].tag911.value == '" & clsSession.GlbUserFullName & "' || document.forms[0].tag911.value == '') {" & Chr(10)
                    End If
                    strCheckAllJS = strCheckAllJS & "OverlayWin = window.open(""WOverlayForm.aspx?CurrentID=" & lngCurrentRec & "&Stage=Modify&ItemID=" & lngItemID & "&Leader=" & txtLeader.Value & "&ItemCode=" & strItemCode & "&FormID=" & intFormID & """, ""OverlayWin"", ""width=720,height=430,resizable,menubar=yes,scrollbars=yes,screenX=40,screenY=10,top=10,left=40"");" & Chr(10)
                    strCheckAllJS = strCheckAllJS & "OverlayWin.focus();" & Chr(10)
                    If Not UCase(clsSession.GlbUserFullName) = "ADMINISTRATOR" And Not Session("RightLevel") = 2 Then
                        strCheckAllJS = strCheckAllJS & "} else {" & Chr(10)
                        strCheckAllJS = strCheckAllJS & "alert('" & strLabel20 & "');" & Chr(10)
                        strCheckAllJS = strCheckAllJS & "}" & Chr(10)
                    End If
                    strCheckAllJS = strCheckAllJS & "}" & Chr(10)

                    ' Load strCheckAllJS to form
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), "CheckAllJS", strCheckAllJS & Chr(10) & strCheckAll1Js, True)

                    ' For preview content of the current item
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), "PreviewJS", strPreviewJS, True)

                    ' Write event for all button on this form
                    btnUpdate.Attributes.Add("OnClick", "javascript:CheckAll('" & strMsgCheckFieldValue & "', '" & strMsgNotEmptyValue & "', 'strMess3'); return false;")
                    btnPreview.Attributes.Add("OnClick", "javascript:Preview(); return false;")
                    btnValidate.Attributes.Add("OnClick", "javascript:CheckAll1('" & strMsgCheckFieldValue & "', '" & strMsgNotEmptyValue & "', 'strMess3'); return false;")
                    btnAddFields.Attributes.Add("OnClick", "javascript:AddFields(); return false;")
                    btnSpellCheck.Attributes.Add("OnClick", "javascript:SpellCheck(); return false;")
                    btnOverlay.Attributes.Add("OnClick", "javascript:OverlayRec(); return false;")
                End If
            End If

            ' Reserve strUsedFieldCodes
            txtUsedFieldCodes.Value = strUsedFieldCodes
            txtFieldCodes.Value = strUsedFieldCodes
            txtFunc.Value = ""
            ' Incase not clone
            If Not txtClone.Value = "1" Then
                btnHolding.Visible = True
                btnCatalogue.Visible = True
                btnMoveFirst.Visible = True
                btnMovePrev.Visible = True
                btnMoveNext.Visible = True
                btnMoveLast.Visible = True
                txtCurrentRec.Visible = True
                txtTotalRec.Visible = True
            Else
                'btnHolding.Visible = False
                btnCatalogue.Visible = False
                btnMoveFirst.Visible = False
                btnMovePrev.Visible = False
                btnMoveNext.Visible = False
                btnMoveLast.Visible = False
                txtCurrentRec.Visible = False
                txtTotalRec.Visible = False
            End If

            ' Release objects
            tblRangeItemID = Nothing
            tblModiFields = Nothing
        End Sub

        Private Sub HideControls()
            btnOverlay.Visible = False
            btnNew.Visible = False
            btnFilter.Visible = False
            txtClone.Value = "1"
        End Sub

        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCatalogueForm Is Nothing Then
                    objBCatalogueForm.Dispose(True)
                    objBCatalogueForm = Nothing
                End If
                If Not objBItemCollection Is Nothing Then
                    objBItemCollection.Dispose(True)
                    objBItemCollection = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace