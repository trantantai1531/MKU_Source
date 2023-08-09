Imports System.IO
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WExportRecordToFile
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Private designerPlaceholderDeclaration As System.Object
        'Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
        Protected WithEvents lblC As System.Web.UI.WebControls.Label
        Protected WithEvents lblExportProcess As System.Web.UI.WebControls.Label
        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBCatCommon As New clsBCatCommon
        Private objBFormingSQL As New clsBFormingSQL
        Private objBCommonDBSystem As New clsBCommonDBSystem
        Private objBCSP As New clsBCommonStringProc
        Private objBItemCollection As New clsBItemCollection
        Private objBCommonBusiness As New clsBCommonBusiness

        Private strPath As String = ""
        Private strFileName As String

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            If Not IsPostBack Then
                Call BindData()
            End If
            Call CheckFormPemission()
        End Sub

        ' Method: Initialize
        ' Purpose: Init all variables for objects and form
        Private Sub Initialize()
            ' Init objBFormingSQL 
            objBFormingSQL.InterfaceLanguage = Session("InterfaceLanguage")
            objBFormingSQL.DBServer = Session("DBServer")
            objBFormingSQL.ConnectionString = Session("ConnectionString")
            Call objBFormingSQL.Initialize()

            ' Init objBCommonDBSystem object 
            objBCommonDBSystem.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonDBSystem.DBServer = Session("DBServer")
            objBCommonDBSystem.ConnectionString = Session("ConnectionString")
            Call objBCommonDBSystem.Initialize()

            ' Inti objBCSP object
            objBCSP.InterfaceLanguage = Session("InterfaceLanguage")
            objBCSP.DBServer = Session("DBServer")
            objBCSP.ConnectionString = Session("ConnectionString")
            Call objBCSP.Initialize()

            ' Init objBItemCollection object
            objBItemCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemCollection.DBServer = Session("DBServer")
            objBItemCollection.ConnectionString = Session("ConnectionString")
            Call objBItemCollection.Initialize()

            ' Init objBCommonBusiness object
            objBCommonBusiness.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonBusiness.DBServer = Session("DBServer")
            objBCommonBusiness.ConnectionString = Session("ConnectionString")
            Call objBCommonBusiness.Initialize()


            ' Init objBCatCommon object 
            objBCatCommon.InterfaceLanguage = Session("InterfaceLanguage")
            objBCatCommon.DBServer = Session("DBServer")
            objBCatCommon.ConnectionString = Session("ConnectionString")
            Call objBCatCommon.Initialize()
        End Sub

        ' Method: CheckFormPemission
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            If Not CheckPemission(10) Then
                btnExport.Enabled = False
            End If
        End Sub

        ' Method: BindJS
        ' Purpose: Bind Style, JScript for Controls
        Private Sub BindJS()
            Dim strJSAuthor As String
            Dim strJSFrameType As String
            Dim strJSKeyWord As String
            Dim strJSLanguage As String
            Dim strJSPublisher As String
            Dim strJS As String

            ' JavaScript            
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/Catalogue/WExportRecordToFile.js'></script>")

            strJSAuthor = "'WReferenceToFilter.aspx?Frame=txtAuthor&DicID=1&SearchData=' + document.Form1.txtAuthor.value"
            If Session("USED_CLASSIFICATION") = "BBK" Then
                strJSFrameType = "'WReferenceToFilter.aspx?Frame=txtFrameType&DicID=4&SearchData=' + document.Form1.txtFrameType.value"
            Else
                strJSFrameType = "'WReferenceToFilter.aspx?Frame=txtFrameType&DicID=5&SearchData=' + document.Form1.txtFrameType.value"
            End If

            strJSKeyWord = "'WReferenceToFilter.aspx?Frame=txtKeyWord&DicID=3&SearchData=' + document.Form1.txtKeyWord.value"
            strJSLanguage = "'WReferenceToFilter.aspx?Frame=txtLanguage&DicID=10&SearchData=' + document.Form1.txtLanguage.value"
            strJSPublisher = "'WReferenceToFilter.aspx?Frame=txtPublisher&DicID=2&SearchData=' + document.Form1.txtPublisher.value"
            strJS = "javascript: if(!CheckInput('" & ddlLabel.Items(10).Text & "','" & ddlLabel.Items(8).Text & "','" & ddlLabel.Items(7).Text & "','" & ddlLabel.Items(9).Text & "')) return false;"

            lnkAuthor.NavigateUrl = "javascript:OpenWindow(" & strJSAuthor & ",'Dictionary',350,300,150,30)"
            lnkFrameType.NavigateUrl = "javascript:OpenWindow(" & strJSFrameType & ",'Dictionary',350,300,150,30)"
            lnkKeyWord.NavigateUrl = "javascript:OpenWindow(" & strJSKeyWord & ",'Dictionary',350,300,150,30)"
            lnkLanguage.NavigateUrl = "javascript:OpenWindow(" & strJSLanguage & ",'Dictionary',350,300,150,30)"
            lnkPublisher.NavigateUrl = "javascript:OpenWindow(" & strJSPublisher & ",'Dictionary',350,300,150,30)"

            btnExport.Attributes.Add("Onclick", strJS)
            btnReset.Attributes.Add("OnClick", "ClearContent(); return false;")

            txtFrom.Attributes.Add("OnChange", "if (!CheckNumBer(this, '" & ddlLabel.Items(14).Text & "')) {this.value='';this.focus();return false;}")
            txtTo.Attributes.Add("OnChange", "if (!CheckNumBer(this, '" & ddlLabel.Items(14).Text & "')) {this.value='';this.focus();return false;}")
        End Sub

        ' BindData sub
        ' Purpose: Bind data for Controls
        Private Sub BindData()
            ' Bind Data for drop down list ddlItemType
            Dim tblForm As DataTable
            Dim tblUser As DataTable

            tblForm = objBCommonBusiness.GetItemTypes()

            If Not tblForm Is Nothing Then
                If tblForm.Rows.Count > 0 Then
                    ' Bind Data for drop down list ddlForm
                    ddlItemType.DataSource = objBCommonDBSystem.InsertOneRow(tblForm, ddlLabel.Items(6).Text)
                    ddlItemType.DataTextField = "Type"
                    ddlItemType.DataValueField = "ID"
                    ddlItemType.DataBind()
                End If
            End If

            objBCatCommon.LibID = clsSession.GlbSite
            tblUser = objBCatCommon.GetUsers

            If Not tblUser Is Nothing Then
                If tblUser.Rows.Count > 0 Then
                    ' Bind Data for drop down list ddlEditPerson
                    ddlEditPerson.DataSource = objBCommonDBSystem.InsertOneRow(objBCatCommon.GetUsers, ddlLabel.Items(5).Text)
                    ddlEditPerson.DataTextField = "Name"
                    ddlEditPerson.DataValueField = "UserName"
                    ddlEditPerson.DataBind()
                End If
            End If
            hidFormAction.Value = 0
        End Sub

        ' btnExport_Click event
        ' Purpose: Select and export data to file
        Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
            Dim i As Integer = 0
            Dim BoolArr() As String
            Dim FieldArr() As String
            Dim ValArr()
            If Not Trim(txtTitle.Text) = "" Then
                ReDim Preserve BoolArr(i)
                ReDim Preserve FieldArr(i)
                ReDim Preserve ValArr(i)
                BoolArr(i) = "AND"
                FieldArr(i) = "TI"
                ValArr(i) = Trim(txtTitle.Text)
                i = i + 1
            End If
            If Not Trim(txtPublisher.Text) = "" Then
                ReDim Preserve BoolArr(i)
                ReDim Preserve FieldArr(i)
                ReDim Preserve ValArr(i)
                BoolArr(i) = "AND"
                FieldArr(i) = "2"
                ValArr(i) = Trim(txtPublisher.Text)
                i = i + 1
            End If
            If Not Trim(txtAuthor.Text) = "" Then
                ReDim Preserve BoolArr(i)
                ReDim Preserve FieldArr(i)
                ReDim Preserve ValArr(i)
                BoolArr(i) = "AND"
                FieldArr(i) = "1"
                ValArr(i) = Trim(txtAuthor.Text)
                i = i + 1
            End If
            If Not Trim(txtKeyWord.Text) = "" Then
                ReDim Preserve BoolArr(i)
                ReDim Preserve FieldArr(i)
                ReDim Preserve ValArr(i)
                BoolArr(i) = "AND"
                FieldArr(i) = "3"
                ValArr(i) = Trim(txtKeyWord.Text)
                i = i + 1
            End If
            If Not Trim(txtFrom.Text) = "" Then
                Dim tblLRange As New DataTable
                ReDim Preserve BoolArr(i)
                ReDim Preserve FieldArr(i)
                ReDim Preserve ValArr(i)
                BoolArr(i) = "AND"
                FieldArr(i) = "FROMID"
                objBItemCollection.TopNum = CInt(Trim(txtFrom.Text))
                objBItemCollection.LibID = clsSession.GlbSite
                tblLRange = objBItemCollection.GetIDByTopNum()
                Call WriteErrorMssg(ddlLabel.Items(4).Text, objBItemCollection.ErrorMsg, ddlLabel.Items(3).Text, objBItemCollection.ErrorCode)
                If Not tblLRange Is Nothing Then
                    If tblLRange.Rows.Count > 0 Then
                        ValArr(i) = tblLRange.Rows(0).Item(0)
                    End If
                End If
                i = i + 1
            End If
            If Not Trim(txtTo.Text) = "" Then
                Dim tblRRange As New DataTable
                ReDim Preserve BoolArr(i)
                ReDim Preserve FieldArr(i)
                ReDim Preserve ValArr(i)
                BoolArr(i) = "AND"
                FieldArr(i) = "TOID"
                objBItemCollection.TopNum = CInt(Trim(txtTo.Text))
                objBItemCollection.LibID = clsSession.GlbSite
                tblRRange = objBItemCollection.GetIDByTopNum()
                Call WriteErrorMssg(ddlLabel.Items(4).Text, objBItemCollection.ErrorMsg, ddlLabel.Items(3).Text, objBItemCollection.ErrorCode)
                If Not tblRRange Is Nothing Then
                    If tblRRange.Rows.Count > 0 Then
                        ValArr(i) = tblRRange.Rows(0).Item(0)
                    End If
                End If
                i = i + 1
            End If
            If Not Trim(txtLanguage.Text) = "" Then
                ReDim Preserve BoolArr(i)
                ReDim Preserve FieldArr(i)
                ReDim Preserve ValArr(i)
                BoolArr(i) = "AND"
                FieldArr(i) = "10"
                ValArr(i) = Trim(txtLanguage.Text)
                i = i + 1
            End If
            If Not Trim(txtFrameType.Text) = "" Then
                ReDim Preserve BoolArr(i)
                ReDim Preserve FieldArr(i)
                ReDim Preserve ValArr(i)
                BoolArr(i) = "AND"
                FieldArr(i) = "4"
                ValArr(i) = Trim(txtFrameType.Text)
                i = i + 1
            End If
            If ddlEditPerson.SelectedIndex > 0 Then
                ReDim Preserve BoolArr(i)
                ReDim Preserve FieldArr(i)
                ReDim Preserve ValArr(i)
                BoolArr(i) = "AND"
                FieldArr(i) = "US"
                ValArr(i) = ddlEditPerson.SelectedValue
                i = i + 1
            End If
            If ddlPattern.SelectedIndex > 0 Then
                ReDim Preserve BoolArr(i)
                ReDim Preserve FieldArr(i)
                ReDim Preserve ValArr(i)
                BoolArr(i) = "AND"
                FieldArr(i) = Request("ClassDic")
                ValArr(i) = ddlPattern.SelectedValue
                i = i + 1
            End If
            If ddlItemType.SelectedIndex > 0 Then
                ReDim Preserve BoolArr(i)
                ReDim Preserve FieldArr(i)
                ReDim Preserve ValArr(i)
                BoolArr(i) = "AND"
                FieldArr(i) = "IT"
                ValArr(i) = ddlItemType.SelectedValue
                i = i + 1
            End If
            objBFormingSQL.BoolArr = BoolArr
            objBFormingSQL.FieldArr = FieldArr
            objBFormingSQL.ValArr = ValArr
            objBFormingSQL.LibID = clsSession.GlbSite
            objBCommonDBSystem.SQLStatement = objBFormingSQL.FormingASQL()
            Dim dtbTmp As DataTable
            dtbTmp = objBCommonDBSystem.RetrieveItemInfor()

            Dim strItemIDs As String = ""
            Dim intLoop As Integer = 40
            Dim intTotal As Integer = 0
            Dim intRow As Integer = 0
            Dim intRowCur As Integer = 0

            If Not dtbTmp Is Nothing Then
                If dtbTmp.Rows.Count > 0 Then
                    intTotal = dtbTmp.Rows.Count
                    Dim strHtml As String

                    ' Progress bar
                    strHtml = "<span id='spnMain' style=''	class='lblLabel'>"
                    strHtml = strHtml & "<span id='spnCover' style='POSITION:relative;'>"
                    strHtml = strHtml & "<span id='spnPecent' style=''>0%</span>"
                    strHtml = strHtml & "<span id='spnlbProcessing' style=''>" & ddlLabel.Items(12).Text & "</span>"
                    strHtml = strHtml & "<table height=10px cellspacing=0 cellpadding=0><tr><td></td><tr></table>"
                    strHtml = strHtml & "<table width=100% border=1 bgcolor=#999966 height=30px cellspacing=0 cellpadding=0><tr><td>"
                    strHtml = strHtml & "<table id='spnProgess' width=0% border=0 bgcolor=#006291 height=100%><tr><td></td></tr></table></td></tr></table></span></span>"

                    Dim tblTemp As DataTable
                    tblTemp = objBCommonDBSystem.GetTempFilePath(1)

                    strPath = ""
                    If Not tblTemp Is Nothing Then
                        If tblTemp.Rows.Count > 0 Then
                            strPath = Server.MapPath("../..") & tblTemp.Rows(0).Item("TempFilePath")
                        End If
                    End If

                    objBCommonDBSystem.Extension = "ISO"
                    strFileName = objBCommonDBSystem.GenRandomFile
                    strPath = strPath & "\" & strFileName

                    Dim ObjOut = New StreamWriter(strPath, True)

                    Response.Write(strHtml)
                    While intRow < intTotal
                        Dim intj As Integer
                        strItemIDs = ""
                        intRowCur = intRow
                        If intRowCur + intLoop > intTotal Then
                            intj = intTotal - 1
                        Else
                            intj = intRowCur + intLoop - 1
                        End If

                        For i = intRow To intj
                            strItemIDs = strItemIDs & dtbTmp.Rows(i).Item("ID") & ","
                        Next
                        If strItemIDs <> "" Then
                            If Right(strItemIDs, 1) = "," Then
                                strItemIDs = Left(strItemIDs, Len(strItemIDs) - 1)
                            End If

                            If ddlPattern.SelectedValue = 1 Then
                                Call CreateBulkMARCRec(strItemIDs, ObjOut, strFileName, intRowCur, intTotal)
                            Else
                                Call CreateBulkISORec(strItemIDs, ObjOut, strFileName, intRowCur, intTotal)
                            End If
                        End If
                        intRow = intRow + intLoop
                    End While
                    hidFormAction.Value = 1
                    ObjOut.Close()
                    dtbTmp.Dispose()
                    dtbTmp = Nothing
                    Response.Write("<script language='javascript'>spnlbProcessing.innerHTML ='" & ddlLabel.Items(13).Text & "';</script>")
                    lblClick.Visible = True
                    lnkLink.Visible = True
                    lblLinkTail.Visible = True
                    lnkLink.Target = "Hiddenbase"
                    lnkLink.NavigateUrl = "#"
                    lnkLink.Attributes.Add("OnClick", "parent.Hiddenbase.location.href='../../Common/WSaveTempFile.aspx?ModuleID=1&FileName=" & strFileName & "';return false;")
                    lblResult.Visible = True
                    lblCount.Visible = True
                    lblCount.Text = intTotal
                Else
                    lblResult.Visible = False
                    lblClick.Visible = False
                    lnkLink.Visible = False
                    lblLinkTail.Visible = False
                    hidFormAction.Value = 0
                    RegisterClientScriptBlock("SearchFail", "<script language='JavaScript'>alert('" & ddlLabel.Items(1).Text & "')</script>")
                End If
            Else
                lblResult.Visible = False
                lblClick.Visible = False
                lnkLink.Visible = False
                lblLinkTail.Visible = False
                hidFormAction.Value = 0
                RegisterClientScriptBlock("SearchFail", "<script language='JavaScript'>alert('" & ddlLabel.Items(1).Text & "')</script>")
            End If
        End Sub

        ' CreateBulkISORec sub 
        ' Purpose: Select and export data to file (Raw)
        Private Sub CreateBulkISORec(ByVal ItemIDs As String, ByVal objF As StreamWriter, ByVal strFileName As String, ByVal intRowCur As Integer, ByVal intTotal As Integer)
            Dim dtbItemMainInfor As New DataTable
            Dim dtbItemDetailInfor As New DataTable

            objBItemCollection.ItemIDs = ItemIDs
            dtbItemMainInfor = objBItemCollection.GetItemMainInfor()

            objBItemCollection.ItemIDs = ItemIDs
            dtbItemDetailInfor = objBItemCollection.GetItemDetailInfor()

            If Not dtbItemMainInfor Is Nothing Then
                If dtbItemMainInfor.Rows.Count > 0 Then
                    ' Variables: FieldVal, FieldGroupVal, RecordVal,  Leader
                    Dim strFVal, strFGroupVal, strRecVal, strLeader As String
                    ' Variables: PadLeft1, PadLeft2 
                    Dim strPadLeft1, strPadLeft2 As String
                    ' Variables: FieldLen
                    Dim intFLen As Integer
                    ' Variables:  TotalLen, BaseAdd be used by Leader
                    Dim intTotalLen, intBaseAdd As Integer
                    Dim i, j, intSum As Integer
                    intSum = 0

                    For i = 0 To dtbItemMainInfor.Rows.Count - 1
                        intTotalLen = 26
                        intBaseAdd = 25
                        strRecVal = ""
                        strFGroupVal = ""
                        strPadLeft1 = ""
                        strPadLeft2 = ""

                        If dtbItemMainInfor.Rows(i).Item("Code") <> "" Then
                            strFVal = objBCSP.ToUTF8(dtbItemMainInfor.Rows(i).Item("Code").ToString.Trim)
                            intFLen = Len(strFVal) + 1
                            strRecVal = strRecVal & "001" & strPadLeft1.PadLeft(4 - Len(CStr(intFLen)), "0") & intFLen & "00000"
                            intBaseAdd = intBaseAdd + 12
                            strFGroupVal = strFGroupVal & strFVal & CStr(Chr(30))
                            strPadLeft1 = ""
                        End If

                        If Not dtbItemDetailInfor Is Nothing Then
                            If dtbItemDetailInfor.Rows.Count > 0 Then
                                For j = 0 To dtbItemDetailInfor.Rows.Count - 1
                                    If Not CLng(dtbItemDetailInfor.Rows(j).Item("ItemID")) = CLng(dtbItemMainInfor.Rows(i).Item("ID")) Then
                                        'Exit For
                                    Else
                                        Dim strIndicators As String
                                        If Not IsDBNull(dtbItemDetailInfor.Rows(j).Item("Indicators")) AndAlso Not IsDBNull(dtbItemDetailInfor.Rows(j).Item("VietIndicators")) Then
                                            If dtbItemDetailInfor.Rows(j).Item("Indicators") <> "" Or dtbItemDetailInfor.Rows(j).Item("VietIndicators") <> "" Then
                                                If Not IsDBNull(dtbItemDetailInfor.Rows(j).Item("Ind1")) AndAlso Not dtbItemDetailInfor.Rows(j).Item("Ind1") = "" Then
                                                    strIndicators = dtbItemDetailInfor.Rows(j).Item("Ind1")
                                                Else
                                                    strIndicators = " "
                                                End If
                                                If Not IsDBNull(dtbItemDetailInfor.Rows(j).Item("Ind2")) AndAlso Not dtbItemDetailInfor.Rows(j).Item("Ind2") = "" Then
                                                    strIndicators = strIndicators & dtbItemDetailInfor.Rows(j).Item("Ind2")
                                                Else
                                                    strIndicators = strIndicators & " "
                                                End If
                                            End If
                                        End If
                                        strFVal = strIndicators & Replace(objBCSP.ToUTF8(dtbItemDetailInfor.Rows(j).Item("Content")), "$", CStr(Chr(31)))
                                        intFLen = Len(strFVal) + 1
                                        strRecVal = strRecVal & dtbItemDetailInfor.Rows(j).Item("FieldCode") & strPadLeft1.PadLeft(4 - Len(CStr(intFLen)), "0") & intFLen & strPadLeft2.PadLeft(5 - Len(CStr(Len(strFGroupVal))), "0") & Len(strFGroupVal)
                                        strPadLeft1 = ""
                                        strPadLeft2 = ""
                                        intBaseAdd = intBaseAdd + 12
                                        strFGroupVal = strFGroupVal & strFVal & CStr(Chr(30))
                                    End If
                                Next
                            End If
                        End If

                        ' New record
                        If Not IsDBNull(dtbItemMainInfor.Rows(i).Item("NewRecord")) Then
                            If dtbItemMainInfor.Rows(i).Item("NewRecord") > 0 Then
                                strFVal = dtbItemMainInfor.Rows(i).Item("NewRecord")
                                intFLen = Len(strFVal) + 1
                                strRecVal = strRecVal & "900" & strPadLeft1.PadLeft(4 - Len(CStr(intFLen)), "0") & intFLen & strPadLeft2.PadLeft(5 - Len(CStr(Len(strFGroupVal))), "0") & Len(strFGroupVal)
                                intBaseAdd = intBaseAdd + 12
                                strFGroupVal = strFGroupVal & strFVal & CStr(Chr(30))
                                strPadLeft1 = ""
                                strPadLeft2 = ""
                            End If
                        End If

                        ' CoverPicture
                        If Not IsDBNull(dtbItemMainInfor.Rows(i).Item("CoverPicture")) Then
                            If Not dtbItemMainInfor.Rows(i).Item("CoverPicture") = "" Then
                                strFVal = dtbItemMainInfor.Rows(i).Item("CoverPicture")
                                intFLen = Len(strFVal) + 1
                                strRecVal = strRecVal & "907" & strPadLeft1.PadLeft(4 - Len(CStr(intFLen)), "0") & intFLen & strPadLeft2.PadLeft(5 - Len(CStr(Len(strFGroupVal))), "0") & Len(strFGroupVal)
                                intBaseAdd = intBaseAdd + 12
                                strFGroupVal = strFGroupVal & strFVal & CStr(Chr(30))
                                strPadLeft1 = ""
                                strPadLeft2 = ""
                            End If
                        End If

                        ' Cataloguer
                        If Not IsDBNull(dtbItemMainInfor.Rows(i).Item("Cataloguer")) Then
                            If Not dtbItemMainInfor.Rows(i).Item("Cataloguer") = "" Then
                                strFVal = objBCSP.ToUTF8(dtbItemMainInfor.Rows(i).Item("Cataloguer"))
                                intFLen = Len(strFVal) + 1
                                strRecVal = strRecVal & "911" & strPadLeft1.PadLeft(4 - Len(CStr(intFLen)), "0") & intFLen & strPadLeft2.PadLeft(5 - Len(CStr(Len(strFGroupVal))), "0") & Len(strFGroupVal)
                                intBaseAdd = intBaseAdd + 12
                                strFGroupVal = strFGroupVal & strFVal & CStr(Chr(30))
                                strPadLeft1 = ""
                                strPadLeft2 = ""
                            End If
                        End If

                        ' Reviewer
                        If Not IsDBNull(dtbItemMainInfor.Rows(i).Item("Reviewer")) Then
                            If Not dtbItemMainInfor.Rows(i).Item("Reviewer") = "" Then
                                strFVal = objBCSP.ToUTF8(dtbItemMainInfor.Rows(i).Item("Reviewer"))
                                intFLen = Len(strFVal) + 1
                                strRecVal = strRecVal & "912" & strPadLeft1.PadLeft(4 - Len(CStr(intFLen)), "0") & intFLen & strPadLeft2.PadLeft(5 - Len(CStr(Len(strFGroupVal))), "0") & Len(strFGroupVal)
                                intBaseAdd = intBaseAdd + 12
                                strFGroupVal = strFGroupVal & strFVal & CStr(Chr(30))
                                strPadLeft1 = ""
                                strPadLeft2 = ""
                            End If
                        End If

                        ' MediumCode
                        If Not IsDBNull(dtbItemMainInfor.Rows(i).Item("MediumCode")) Then
                            If Not dtbItemMainInfor.Rows(i).Item("MediumCode") = "" Then
                                strFVal = objBCSP.ToUTF8(dtbItemMainInfor.Rows(i).Item("MediumCode"))
                                intFLen = Len(strFVal) + 1
                                strRecVal = strRecVal & "925" & strPadLeft1.PadLeft(4 - Len(CStr(intFLen)), "0") & intFLen & strPadLeft2.PadLeft(5 - Len(CStr(Len(strFGroupVal))), "0") & Len(strFGroupVal)
                                intBaseAdd = intBaseAdd + 12
                                strFGroupVal = strFGroupVal & strFVal & CStr(Chr(30))
                                strPadLeft1 = ""
                                strPadLeft2 = ""
                            End If
                        End If

                        ' AccessLevel
                        If Not IsDBNull(dtbItemMainInfor.Rows(i).Item("AccessLevel")) Then
                            If dtbItemMainInfor.Rows(i).Item("AccessLevel") > 0 Then
                                strFVal = dtbItemMainInfor.Rows(i).Item("AccessLevel")
                                intFLen = Len(strFVal) + 1
                                strRecVal = strRecVal & "926" & strPadLeft1.PadLeft(4 - Len(CStr(intFLen)), "0") & intFLen & strPadLeft2.PadLeft(5 - Len(CStr(Len(strFGroupVal))), "0") & Len(strFGroupVal)
                                intBaseAdd = intBaseAdd + 12
                                strFGroupVal = strFGroupVal & strFVal & CStr(Chr(30))
                                strPadLeft1 = ""
                                strPadLeft2 = ""
                            End If
                        End If

                        ' TypeCode
                        If Not IsDBNull(dtbItemMainInfor.Rows(i).Item("TypeCode")) Then
                            If Not dtbItemMainInfor.Rows(i).Item("TypeCode") = "" Then
                                strFVal = objBCSP.ToUTF8(dtbItemMainInfor.Rows(i).Item("TypeCode"))
                                intFLen = Len(strFVal) + 1
                                strRecVal = strRecVal & "927" & strPadLeft1.PadLeft(4 - Len(CStr(intFLen)), "0") & intFLen & strPadLeft2.PadLeft(5 - Len(CStr(Len(strFGroupVal))), "0") & Len(strFGroupVal)
                                intBaseAdd = intBaseAdd + 12
                                strFGroupVal = strFGroupVal & strFVal & CStr(Chr(30))
                                strPadLeft1 = ""
                                strPadLeft2 = ""
                            End If
                        End If

                        intTotalLen = intTotalLen + Len(strRecVal) + Len(strFGroupVal)
                        strLeader = strPadLeft1.PadLeft(5 - Len(CStr(intTotalLen)), "0") & intTotalLen & Mid(dtbItemMainInfor.Rows(i).Item("Leader"), 6, 7) & strPadLeft1.PadLeft(5 - Len(CStr(intBaseAdd)), "0") & intBaseAdd & Right(dtbItemMainInfor.Rows(i).Item("Leader"), 7)
                        strPadLeft1 = ""
                        strPadLeft2 = ""
                        objF.Write(objBCSP.ToUTF8Back(strLeader & strRecVal & CStr(Chr(31)) & strFGroupVal & CStr(Chr(29))))

                        ' Display the progress bar
                        Call BindPrg(intRowCur + i, intTotal)

                        intSum = intSum + 1
                    Next

                    Call objBCommonDBSystem.InsertSysDownloadFile()
                End If
            End If
        End Sub

        ' CreateBulkMARCRec Sub
        ' Purpose: Select and export data to file (Target(MARC))
        Private Sub CreateBulkMARCRec(ByVal ItemIDs As String, ByVal objF As StreamWriter, ByVal strFileName As String, ByVal intRowCur As Integer, ByVal intTotal As Integer)
            ' Declare variables
            Dim dtbItemMainInfor As New DataTable
            Dim dtbItemDetailInfor As New DataTable

            objBItemCollection.ItemIDs = ItemIDs
            dtbItemMainInfor = objBItemCollection.GetItemMainInfor()
            objBItemCollection.ItemIDs = ItemIDs
            dtbItemDetailInfor = objBItemCollection.GetItemDetailInfor()

            If Not dtbItemMainInfor Is Nothing Then
                If dtbItemMainInfor.Rows.Count > 0 Then
                    Dim i, j, intSum As Integer

                    For i = 0 To dtbItemMainInfor.Rows.Count - 1
                        objF.WriteLine("Ldr " & dtbItemMainInfor.Rows(i).Item("Leader"))
                        If Not dtbItemMainInfor.Rows(i).Item("Code") = "" Then
                            objF.WriteLine("#001 " & dtbItemMainInfor.Rows(i).Item("Code"))
                        End If
                        If Not dtbItemDetailInfor Is Nothing Then
                            For j = 0 To dtbItemDetailInfor.Rows.Count - 1
                                If Not CLng(dtbItemDetailInfor.Rows(j).Item("ItemID")) = CLng(dtbItemMainInfor.Rows(i).Item("ItemID")) Then
                                    ' Exit For
                                Else
                                    Dim strIndicators As String
                                    If Not IsDBNull(dtbItemDetailInfor.Rows(j).Item("Indicators")) AndAlso Not IsDBNull(dtbItemDetailInfor.Rows(j).Item("VietIndicators")) Then
                                        If Not dtbItemDetailInfor.Rows(j).Item("Indicators") = "" Or Not dtbItemDetailInfor.Rows(j).Item("VietIndicators") = "" Then
                                            If IsDBNull(dtbItemDetailInfor.Rows(j).Item("Ind1")) Then
                                                strIndicators = " "
                                            Else
                                                strIndicators = dtbItemDetailInfor.Rows(j).Item("Ind1")
                                            End If
                                            If IsDBNull(dtbItemDetailInfor.Rows(j).Item("Ind2")) Then
                                                strIndicators = strIndicators & " "
                                            Else
                                                strIndicators = strIndicators & dtbItemDetailInfor.Rows(j).Item("Ind2")
                                            End If
                                        End If
                                    End If
                                    objF.WriteLine("#" & dtbItemDetailInfor.Rows(j).Item("FieldCode") & " " & strIndicators & " " & dtbItemDetailInfor.Rows(j).Item("Content"))
                                End If
                            Next
                        End If

                        ' NewRecord
                        If Not IsDBNull(dtbItemMainInfor.Rows(i).Item("NewRecord")) Then
                            If dtbItemMainInfor.Rows(i).Item("NewRecord") > 0 Then
                                objF.WriteLine("#900 " & dtbItemMainInfor.Rows(i).Item("NewRecord"))
                            End If
                        End If

                        ' CoverPicture
                        If Not IsDBNull(dtbItemMainInfor.Rows(i).Item("CoverPicture")) Then
                            If Not dtbItemMainInfor.Rows(i).Item("CoverPicture") = "" Then
                                objF.WriteLine("#907 " & dtbItemMainInfor.Rows(i).Item("CoverPicture"))
                            End If
                        End If

                        ' Cataloguer
                        If Not IsDBNull(dtbItemMainInfor.Rows(i).Item("Cataloguer")) Then
                            If Not dtbItemMainInfor.Rows(i).Item("Cataloguer") = "" Then
                                objF.WriteLine("#911 " & dtbItemMainInfor.Rows(i).Item("Cataloguer"))
                            End If
                        End If

                        ' Reviewer
                        If Not IsDBNull(dtbItemMainInfor.Rows(i).Item("Reviewer")) Then
                            If Not dtbItemMainInfor.Rows(i).Item("Reviewer") = "" Then
                                objF.WriteLine("#912 " & dtbItemMainInfor.Rows(i).Item("Reviewer"))
                            End If
                        End If

                        ' MediumCode 
                        If Not IsDBNull(dtbItemMainInfor.Rows(i).Item("MediumCode")) Then
                            If Not dtbItemMainInfor.Rows(i).Item("MediumCode") = "" Then
                                objF.WriteLine("#925 " & dtbItemMainInfor.Rows(i).Item("MediumCode"))
                            End If
                        End If

                        ' AccessLevel
                        If Not IsDBNull(dtbItemMainInfor.Rows(i).Item("AccessLevel")) Then
                            If dtbItemMainInfor.Rows(i).Item("AccessLevel") > 0 Then
                                objF.WriteLine("#926 " & dtbItemMainInfor.Rows(i).Item("AccessLevel"))
                            End If
                        End If

                        ' TypeCode
                        If Not IsDBNull(dtbItemMainInfor.Rows(i).Item("TypeCode")) Then
                            If Not dtbItemMainInfor.Rows(i).Item("TypeCode") = "" Then
                                objF.WriteLine("#927 " & dtbItemMainInfor.Rows(i).Item("TypeCode"))
                            End If
                        End If

                        objF.WriteLine("##")

                        Call BindPrg(intRowCur + i, intTotal)
                        intSum = intSum + 1
                    Next
                    Call objBCommonDBSystem.InsertSysDownloadFile()
                End If
            End If
        End Sub

        ' BindPrg method 
        ' Purpose: Bind data for Controls
        Public Sub BindPrg(ByVal intCurrent As Integer, ByVal intSum As Integer)
            Dim intCurrentPercent As Integer
            intCurrentPercent = ((intCurrent + 1) * 100) / intSum
            System.Threading.Thread.Sleep(50 / intSum)
            Response.Write("<script language='javascript'>spnProgess.width =" & intCurrentPercent & " + '%'; spnPecent.innerHTML =" & intCurrentPercent & " + '%';</script>")
            Response.Flush()
        End Sub

        ' Page Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: Release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not objBFormingSQL Is Nothing Then
                        objBFormingSQL.Dispose(True)
                        objBFormingSQL = Nothing
                    End If
                    If Not objBItemCollection Is Nothing Then
                        objBItemCollection.Dispose(True)
                        objBItemCollection = Nothing
                    End If
                    If Not objBCommonDBSystem Is Nothing Then
                        objBCommonDBSystem.Dispose(True)
                        objBCommonDBSystem = Nothing
                    End If
                    If Not objBCommonBusiness Is Nothing Then
                        objBCommonBusiness.Dispose(True)
                        objBCommonBusiness = Nothing
                    End If
                    If Not objBCatCommon Is Nothing Then
                        objBCatCommon.Dispose(True)
                        objBCatCommon = Nothing
                    End If
                    If Not objBCSP Is Nothing Then
                        objBCSP.Dispose(True)
                        objBCSP = Nothing
                    End If
                Else
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace