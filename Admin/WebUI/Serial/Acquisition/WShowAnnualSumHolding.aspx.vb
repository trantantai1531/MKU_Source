Imports eMicLibAdmin.BusinessRules.Serial
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WShowAnnualSumHolding
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
        Private objBCommon As New clsBCommonBusiness
        Private objBFormingSQL As New clsBFormingSQL
        Private objBPeriodical As New clsBPeriodical
        Private objBPeriodicalCollection As New clsBPeriodicalCollection
        Private objBCDBS As New clsBCommonDBSystem
        Dim tblResult1 As DataTable

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindScript()
            Call BindHyperLink()

            If Not Page.IsPostBack Then
                Call BindDataYear()
                Call BindRegularity()
            End If
        End Sub

        ' CheckFormPermission method
        ' Purpose: check the user permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(84) Then
                Call WriteErrorMssg(ddlLabel.Items(9).Text)
            End If
        End Sub

        ' BindDataYear method
        ' Purpose: Bind year into ddlyear
        Sub BindDataYear()
            Dim tblResult As New DataTable
            Dim intItemID As Integer
            Dim intYear As Integer

            Try
                objBPeriodical.ItemID = 0 ' All periodicals
                objBPeriodical.LocationID = 0
                tblResult = objBPeriodical.GetReceivedYear
                Call WriteErrorMssg(ddlLabel.Items(5).Text, objBPeriodical.ErrorMsg, ddlLabel.Items(6).Text, objBPeriodical.ErrorCode)

                If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                    ddlYears.DataTextField = "Years"
                    ddlYears.DataValueField = "Years"
                    ddlYears.DataSource = tblResult
                    ddlYears.DataBind()
                End If

                If tblResult.Rows.Count > 0 Then
                    intYear = CInt(ddlYears.SelectedValue)
                Else
                    intYear = Year(Now)
                End If
                tblResult = Nothing
            Finally
            End Try
        End Sub

        ' BindRegularity method
        Private Sub BindRegularity()
            Dim tblRegularity As DataTable
            Dim tblSysView As DataTable

            tblRegularity = objBCommon.GetRegularity
            Call WriteErrorMssg(ddlLabel.Items(5).Text, objBCommon.ErrorMsg, ddlLabel.Items(6).Text, objBCommon.ErrorCode)

            If Not tblRegularity Is Nothing AndAlso tblRegularity.Rows.Count > 0 Then
                tblRegularity = InsertOneRow(tblRegularity, Trim(ddlLabel.Items(0).Text))
                Call WriteErrorMssg(ddlLabel.Items(5).Text, ErrorMsg, ddlLabel.Items(6).Text, ErrorCode)
                ddlRegularity.DataSource = tblRegularity
                ddlRegularity.DataTextField = "Regularity"
                ddlRegularity.DataValueField = "RegularityCode"
                ddlRegularity.DataBind()
            End If
        End Sub

        ' ProcessSearchGroup method
        Private Sub ProcessSearchGroup()
            ' Variables
            Dim arrBool()
            Dim arrVal()
            Dim arrField()

            Dim intIDSumFound As Integer
            Dim intIndex = 0 ' Use to bound the array
            Dim strSQL As String = ""
            Dim strSQLStatement As String = ""
            Dim strSelectStatement As String = ""
            Dim strItemIDs As String = ""
            Dim inti As Integer = 0

            Dim tblItem As New DataTable

            ' Add to the arrays new elements if the text boxes is not null
            If Not Trim(txtTitle.Text) = "" Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrField(intIndex)
                ReDim Preserve arrVal(intIndex)
                arrBool(intIndex) = "AND"
                arrField(intIndex) = "TI"
                arrVal(intIndex) = Trim(txtTitle.Text)
                intIndex = intIndex + 1
            End If
            If Not Trim(txtCountry.Text) = "" Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrField(intIndex)
                ReDim Preserve arrVal(intIndex)
                arrBool(intIndex) = "AND"
                arrField(intIndex) = "11"
                arrVal(intIndex) = Trim(txtCountry.Text)
                intIndex = intIndex + 1
            End If
            If Not Trim(txtPublisher.Text) = "" Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrField(intIndex)
                ReDim Preserve arrVal(intIndex)
                arrBool(intIndex) = "AND"
                arrField(intIndex) = "2"
                arrVal(intIndex) = Trim(txtPublisher.Text)
                intIndex = intIndex + 1
            End If
            If Not Trim(txtLanguage.Text) = "" Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrField(intIndex)
                ReDim Preserve arrVal(intIndex)
                arrBool(intIndex) = "AND"
                arrField(intIndex) = "10"
                arrVal(intIndex) = Trim(txtLanguage.Text)
                intIndex = intIndex + 1
            End If
            If Not Trim(ddlRegularity.SelectedValue) = Trim(ddlLabel.Items(0).Text) Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrField(intIndex)
                ReDim Preserve arrVal(intIndex)
                arrBool(intIndex) = "AND"
                arrField(intIndex) = "FR"
                arrVal(intIndex) = Trim(ddlRegularity.SelectedValue)
                intIndex = intIndex + 1
            End If
            If Not Trim(txtISSN.Text) = "" Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrField(intIndex)
                ReDim Preserve arrVal(intIndex)
                arrBool(intIndex) = "AND"
                arrField(intIndex) = "IS"
                arrVal(intIndex) = Trim(txtISSN.Text)
                intIndex = intIndex + 1
            End If
            If Not Trim(txtClassify.Text) = "" Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrField(intIndex)
                ReDim Preserve arrVal(intIndex)
                arrBool(intIndex) = "AND"
                If Me.objSysPara(12) = 0 Then
                    arrField(intIndex) = "4"
                Else
                    arrField(intIndex) = "5"
                End If
                arrVal(intIndex) = Trim(txtClassify.Text)
                intIndex = intIndex + 1
            End If
            If Not Trim(txtSubject.Text) = "" Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrField(intIndex)
                ReDim Preserve arrVal(intIndex)
                arrBool(intIndex) = "AND"
                arrField(intIndex) = "9"
                arrVal(intIndex) = Trim(txtSubject.Text)
                intIndex = intIndex + 1
            End If
            If Not Trim(txtKeyword.Text) = "" Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrField(intIndex)
                ReDim Preserve arrVal(intIndex)
                arrBool(intIndex) = "AND"
                arrField(intIndex) = "3"
                arrVal(intIndex) = Trim(txtKeyword.Text)
                intIndex = intIndex + 1
            End If

            'If Not Trim(txtTitle.Text) = "" Or Not Trim(txtCountry.Text) = "" Or _
            '    Not Trim(txtPublisher.Text) = "" Or Not Trim(txtLanguage.Text) = "" Or _
            '    Not Trim(txtISSN.Text) = "" Or Not Trim(txtClassify.Text) = "" Or _
            '    Not Trim(txtSubject.Text) = "" Or Not Trim(txtKeyword.Text) = "" Or _
            '    Not Trim(ddlRegularity.SelectedValue) = Trim(ddlLabel.Items(0).Text) Then

            '    ReDim Preserve arrBool(intIndex)
            '    ReDim Preserve arrField(intIndex)
            '    ReDim Preserve arrVal(intIndex)
            '    arrBool(intIndex) = "AND"
            '    arrField(intIndex) = "IT"
            '    arrVal(intIndex) = "TT"
            '    intIndex = intIndex + 1

            '    ' Add to the arrays in objBFormingSQL the new arrays from the module
            '    objBFormingSQL.FieldArr = arrField
            '    objBFormingSQL.ValArr = arrVal
            '    objBFormingSQL.BoolArr = arrBool

            '    ' Formming the SQL statement
            '    strSQL = objBFormingSQL.FormingASQL
            '    Call WriteErrorMssg(ddlLabel.Items(5).Text, objBFormingSQL.ErrorMsg, ddlLabel.Items(6).Text, objBFormingSQL.ErrorCode)
            'End If
            ReDim Preserve arrBool(intIndex)
            ReDim Preserve arrField(intIndex)
            ReDim Preserve arrVal(intIndex)
            arrBool(intIndex) = "AND"
            arrField(intIndex) = "IT"
            arrVal(intIndex) = "TT"
            intIndex = intIndex + 1

            ' Add to the arrays in objBFormingSQL the new arrays from the module
            objBFormingSQL.FieldArr = arrField
            objBFormingSQL.ValArr = arrVal
            objBFormingSQL.BoolArr = arrBool
            objBFormingSQL.LibID = clsSession.GlbSite
            ' Formming the SQL statement
            strSQL = objBFormingSQL.FormingASQL
            Call WriteErrorMssg(ddlLabel.Items(5).Text, objBFormingSQL.ErrorMsg, ddlLabel.Items(6).Text, objBFormingSQL.ErrorCode)


            'Get ItemId
            If strSQL <> "" Then
                objBCDBS.SQLStatement = strSQL
                tblItem = objBCDBS.RetrieveItemInfor()
                Call WriteErrorMssg(ddlLabel.Items(5).Text, objBCDBS.ErrorMsg, ddlLabel.Items(6).Text, objBCDBS.ErrorCode)
                strItemIDs = ""
                If Not tblItem Is Nothing Then
                    If tblItem.Rows.Count > 0 Then
                        For inti = 0 To tblItem.Rows.Count - 1
                            strItemIDs = strItemIDs & Trim(CStr(tblItem.Rows(inti).Item(0))) & ","
                        Next
                        Session("IDs") = Left(strItemIDs, Len(strItemIDs) - 1)
                        Session("Years") = CInt(ddlYears.SelectedValue)
                    Else
                        Session("IDs") = ""
                    End If
                Else
                    Session("IDs") = ""
                End If
            Else
                Session("IDs") = ""
            End If

            If Session("IDs") = "" Then
                Page.RegisterClientScriptBlock("NotFound1", "<script language='javascript'>alert('" & ddlLabel.Items(7).Text & "')</script>")
            End If
        End Sub

        ' Get data 
        Sub BindData()
            Dim strIDs As String
            Dim intYears As Integer
            Dim intCount As Integer
            Dim intRow As Integer
            Dim blnFound As Boolean = False
            Dim tblReceived As DataTable

            DgrResult.Visible = False
            Try
                strIDs = Session("IDs")
                If strIDs <> "" Then
                    intYears = CInt(Session("Years"))
                    tblResult1 = objBPeriodicalCollection.GetAnnualSummaryHolding(strIDs, intYears)
                    Call WriteErrorMssg(ddlLabel.Items(5).Text, objBPeriodicalCollection.ErrorMsg, ddlLabel.Items(6).Text, objBPeriodicalCollection.ErrorCode)

                    If Not tblResult1 Is Nothing AndAlso tblResult1.Rows.Count > 0 Then

                        blnFound = True
                        DgrResult.Visible = True
                        DgrResult.DataSource = tblResult1
                        DgrResult.DataBind()
                        intCount = tblResult1.Rows.Count
                        'Changer columns
                        For intRow = 0 To intCount - 1
                            DgrResult.Items(intRow).Cells(1).Text = ChangColumn(CInt(tblResult1.Rows(intRow).Item("ItemID")))
                            'tblReceived = objBPeriodicalCollection.GetLastReceivedDate(CInt(tblResult1.Rows(intRow).Item("ItemID")))
                            'If Not tblReceived Is Nothing AndAlso tblReceived.Rows.Count > 0 Then
                            '    DgrResult.Items(intRow).Cells(2).Text = tblReceived.Rows(0).Item(0).ToString
                            'End If
                        Next
                        tblReceived = Nothing
                        tblResult1 = Nothing
                    End If

                    If blnFound = False Then
                        Page.RegisterClientScriptBlock("NotFound2", "<script language='javascript'>alert('" & ddlLabel.Items(7).Text & "')</script>")
                    End If
                    Session("IDs") = ""
                End If
            Catch
            End Try
        End Sub


        ' BindData method
        Private Function ChangColumn(ByVal intItemID As Integer) As String
            Dim intYear As Integer
            Dim intResetReg As Integer

            Dim strMonths As String
            Dim strYear As String
            Dim strHavingYearIssue As String

            Dim strFirstIssueInYear As String

            Dim strShowHas, strShowLost As String


            intYear = Session("Years")

            objBPeriodical.LocationID = 0
            objBPeriodical.ItemID = intItemID
            Call objBPeriodical.GetReceiveIssueNums(intYear, intResetReg, strMonths, strHavingYearIssue, strFirstIssueInYear)
            Call WriteErrorMssg(ddlLabel.Items(5).Text, objBPeriodical.ErrorMsg, ddlLabel.Items(6).Text, objBPeriodical.ErrorCode)
            clsGetIssueNos.GetHasLostIssueNo(intResetReg, strMonths, strHavingYearIssue, strFirstIssueInYear, ddlLabel.Items(10).Text, ddlLabel.Items(4).Text, ddlLabel.Items(11).Text, strShowHas, strShowLost)
            ChangColumn = "<b>" & ddlLabel.Items(2).Text & "</b> " & strShowHas & "<br>" & "<b><font color=red>" & ddlLabel.Items(3).Text & "</font></b> " & strShowLost
        End Function




        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()

            ' Init for objBCommon
            objBCommon.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommon.DBServer = Session("DBServer")
            objBCommon.ConnectionString = Session("ConnectionString")
            objBCommon.Initialize()

            ' Init for objBPeriodical
            objBPeriodical.InterfaceLanguage = Session("InterfaceLanguage")
            objBPeriodical.DBServer = Session("DBServer")
            objBPeriodical.ConnectionString = Session("ConnectionString")
            objBPeriodical.ItemID = CInt(Session("ItemID"))
            objBPeriodical.Initialize()

            ' Init for objBPeriodicalCollection
            objBFormingSQL.InterfaceLanguage = Session("InterfaceLanguage")
            objBFormingSQL.DBServer = Session("DBServer")
            objBFormingSQL.ConnectionString = Session("ConnectionString")
            objBFormingSQL.Initialize()

            ' Init for objBCDBS 
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            objBCDBS.Initialize()

            'Init objBPeriodicalCollection
            objBPeriodicalCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBPeriodicalCollection.DBServer = Session("DBServer")
            objBPeriodicalCollection.ConnectionString = Session("ConnectionString")
            objBPeriodicalCollection.Initialize()

            tblResult1 = Nothing
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJS", "<script language = 'javascript' src = '../Js/Acquisition/WShowAnnualSumHolding.js'></script>")

            btnSearch.Attributes.Add("OnClick", "if (!CheckAllInput()) {alert('" & ddlLabel.Items(1).Text & "'); return false;}")
            btnReset.Attributes.Add("OnClick", "return ResetAll();")
        End Sub

        ' DgrResult_PageIndexChanged event
        ' Purpose: Change the page index
        Private Sub DgrResult_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DgrResult.PageIndexChanged
            DgrResult.CurrentPageIndex = e.NewPageIndex
            Call BindData()
        End Sub

        ' DgrResult_ItemCreated event
        ' Purpose: Add the javascript for each table row
        Private Sub DgrResult_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DgrResult.ItemCreated
            Try
                Select Case e.Item.ItemType
                    Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                        Dim lnk As HyperLink
                        lnk = CType(e.Item.Cells(5).FindControl("lnkSelect"), HyperLink)
                        lnk.Font.Bold = True
                        Dim inti As Integer
                        inti = e.Item.DataSetIndex()
                        ' Add the attribute for the hiperlink to change the item session to item selected
                        lnk.NavigateUrl = "#"
                        lnk.Attributes.Add("onclick", "javascript:parent.Hiddenbase.location.href='../WSaveSession.aspx';parent.Hiddenbase.document.forms[0].hidItemID.value=" & CInt(tblResult1.Rows(inti).Item("ItemID")) & ";parent.Hiddenbase.document.forms[0].hidTitle.value='" & CStr(tblResult1.Rows(inti).Item("Content")) & "';parent.Hiddenbase.document.forms[0].btnSave.click();alert('" & ddlLabel.Items(8).Text & "');return false;")
                End Select
            Catch
                tblResult1 = Nothing
                DgrResult.Visible = False
            End Try
        End Sub

        ' BindHyperLink method
        ' Purpose: Bind the javascripts to the hiperlinks 
        Private Sub BindHyperLink()
            ' Declare variables
            Dim strJavaScript1 As String
            Dim strJavaScript2 As String
            Dim strJavaScript3 As String
            Dim strJavaScript4 As String
            Dim strJavaScript5 As String
            Dim strJavaScript6 As String

            Dim objSysPara() As String
            Dim strAbbr As String = ""
            Dim objPara() As String = {"USED_CLASSIFICATION"}
            Dim strVal As String = ""

            ' Get LibAbbr from SYS_PARAMETERS table to forming classifycation dic
            objSysPara = objBCDBS.GetSystemParameters(objPara)

            If Not objSysPara(0) Is Nothing Then
                strAbbr = objSysPara(0)
            End If

            strVal = strAbbr

            ' Get the string of javascripts
            strJavaScript1 = "'../WGetReferences.aspx?Frame=txtCountry&DicID=11&SearchData=' + document.forms[0].txtCountry.value"
            strJavaScript2 = "'../WGetReferences.aspx?Frame=txtPublisher&DicID=2&SearchData=' + document.forms[0].txtPublisher.value"
            strJavaScript3 = "'../WGetReferences.aspx?Frame=txtLanguage&DicID=10&SearchData=' + document.forms[0].txtLanguage.value"

            Select Case strVal
                Case "0"
                    strJavaScript4 = "'../WGetReferences.aspx?Frame=txtClassify&DicID=4&SearchData=' + document.forms[0].txtClassify.value"
                Case "1"
                    strJavaScript4 = "'../WGetReferences.aspx?Frame=txtClassify&DicID=5&SearchData=' + document.forms[0].txtClassify.value"
            End Select

            strJavaScript5 = "'../WGetReferences.aspx?Frame=txtSubject&DicID=9&SearchData=' + document.forms[0].txtSubject.value"
            strJavaScript6 = "'../WGetReferences.aspx?Frame=txtKeyword&DicID=3&SearchData=' + document.forms[0].txtKeyword.value"

            ' Add attributes for the hyperlinks
            lnkCountry.NavigateUrl = "javascript:OpenWindow(" & strJavaScript1 & ",'Dictionary',350,300,150,30)"
            lnkPublisher.NavigateUrl = "javascript:OpenWindow(" & strJavaScript2 & ",'Dictionary',350,300,150,30)"
            lnkLanguage.NavigateUrl = "javascript:OpenWindow(" & strJavaScript3 & ",'Dictionary',350,300,150,30)"
            lnkClassify.NavigateUrl = "javascript:OpenWindow(" & strJavaScript4 & ",'Dictionary',350,300,150,30)"
            lnkSubject.NavigateUrl = "javascript:OpenWindow(" & strJavaScript5 & ",'Dictionary',350,300,150,30)"
            lnkKeyword.NavigateUrl = "javascript:OpenWindow(" & strJavaScript6 & ",'Dictionary',350,300,150,30)"
        End Sub

        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            Call ProcessSearchGroup()
            Call BindData()
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCommon Is Nothing Then
                    objBCommon.Dispose(True)
                    objBCommon = Nothing
                End If
                If Not objBFormingSQL Is Nothing Then
                    objBFormingSQL.Dispose(True)
                    objBFormingSQL = Nothing
                End If
                If Not objBPeriodicalCollection Is Nothing Then
                    objBPeriodicalCollection.Dispose(True)
                    objBPeriodicalCollection = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace