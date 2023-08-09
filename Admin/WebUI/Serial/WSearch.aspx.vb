Imports eMicLibAdmin.BusinessRules.Serial
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports Telerik.Web.UI

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WSearch
        Inherits clsWBase
        Implements IUCNumberOfRecord

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblGroupName As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBCommonBusiness As New clsBCommonBusiness
        Private objBItemCollection As New clsBItemCollection
        Private objBFormingSQL As New clsBFormingSQL
        Private objBCDBS As New clsBCommonDBSystem

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not CheckPemission() Then
                Call WritePermErrorMssg()
            End If
            Initialize()
            Call BindScript()
            Call BindHyperLink()

            If Not Page.IsPostBack Then
                Call ClearControls()
                txtGroupName.Text = clsSession.GlbUser
                Call LoadHiddenBase()
                Call BindDropdownList()
            End If
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()

            ' Init for objBCommonBusiness
            objBCommonBusiness.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonBusiness.DBServer = Session("DBServer")
            objBCommonBusiness.ConnectionString = Session("ConnectionString")
            objBCommonBusiness.Initialize()

            ' Init for objBPeriodicalCollection
            objBItemCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemCollection.DBServer = Session("DBServer")
            objBItemCollection.ConnectionString = Session("ConnectionString")
            objBItemCollection.Initialize()

            ' Init for objBFormingSQL 
            objBFormingSQL.InterfaceLanguage = Session("InterfaceLanguage")
            objBFormingSQL.DBServer = Session("DBServer")
            objBFormingSQL.ConnectionString = Session("ConnectionString")
            objBFormingSQL.Initialize()

            ' Init for objBCDBS 
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            objBCDBS.Initialize()
            'ddlGroup.Visible = False
            'txtGroupName.Visible = False
            'lblRegularity.Visible = False
            'ddlRegularity.Visible = False
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJS", "<script language = 'javascript' src = 'js/WSearch.js'></script>")
            btnUpdate.Attributes.Add("OnClick", "javascript:if(!CheckNullInput('" & ddlLabel.Items(3).Text & "','" & ddlLabel.Items(5).Text & "')) return false;")
            btnSearch.Attributes.Add("OnClick", "javascript:if(!CheckNullInputSearch('" & ddlLabel.Items(3).Text & "','" & ddlLabel.Items(5).Text & "')) return false;")
            btnReset.Attributes.Add("OnClick", "return ResetForm();")
            btnDelete.Attributes.Add("OnClick", "return CheckDel('" & ddlLabel.Items(7).Text & "','" & ddlLabel.Items(6).Text & "');")
        End Sub

        ' BindDropdownList method
        Private Sub BindDropdownList()
            Dim tblRegularity As DataTable
            Dim tblSysView As DataTable
            Dim lsItem As New ListItem

            ' get the regularity
            tblRegularity = objBCommonBusiness.GetRegularity
            ' Write Error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBCommonBusiness.ErrorMsg, ddlLabel.Items(1).Text, objBCommonBusiness.ErrorCode)

            ' get the list of user views
            tblSysView = objBItemCollection.GetSysUserViews(clsSession.GlbUser)
            ' Write Error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBItemCollection.ErrorMsg, ddlLabel.Items(1).Text, objBItemCollection.ErrorCode)

            If Not tblSysView Is Nothing Then
                tblSysView = InsertOneRow(tblSysView, Trim(ddlLabel.Items(4).Text), True)
                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, ErrorMsg, ddlLabel.Items(1).Text, ErrorCode)
            End If

            ' Bind the user views in the drop down list
            If Not tblSysView Is Nothing Then
                If tblSysView.Rows.Count > 0 Then
                    ddlGroup.DataSource = tblSysView
                    ddlGroup.DataTextField = "ViewName"
                    ddlGroup.DataValueField = "ID"
                    ddlGroup.DataBind()
                Else
                    ddlGroup.Items.Clear()
                    lsItem.Text = ddlLabel.Items(4).Text
                    lsItem.Value = 0
                    ddlGroup.Items.Add(lsItem)
                End If
            Else
                ddlGroup.Items.Clear()
                lsItem.Text = ddlLabel.Items(4).Text
                lsItem.Value = 0
                ddlGroup.Items.Add(lsItem)
            End If

            If Not tblRegularity Is Nothing Then
                tblRegularity = InsertOneRow(tblRegularity, Trim(ddlLabel.Items(2).Text))
                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, ErrorMsg, ddlLabel.Items(1).Text, ErrorCode)
            End If

            ' Bind the regularity in the drop down list
            If Not tblRegularity Is Nothing Then
                If tblRegularity.Rows.Count > 0 Then
                    ddlRegularity.DataSource = tblRegularity
                    ddlRegularity.DataTextField = "Regularity"
                    ddlRegularity.DataValueField = "RegularityCode"
                    ddlRegularity.DataBind()
                Else
                    lsItem.Text = ddlLabel.Items(2).Text
                    lsItem.Value = 0
                    ddlRegularity.Items.Add(lsItem)
                End If
            Else
                lsItem.Text = ddlLabel.Items(2).Text
                lsItem.Value = 0
                ddlRegularity.Items.Add(lsItem)
            End If

        End Sub

        ' LoadHiddenBase method
        Private Sub LoadHiddenBase()
            If Request.QueryString("URL") & "" <> "" Then
                If Request.QueryString("URL") = "Article/WShowIssueInfor.aspx" Then

                    Page.RegisterClientScriptBlock("LoadHiddenBase", "<script language = 'javascript'>parent.Hiddenbase.location.href='WSaveSession.aspx?FormName=" & "Acquisition/WAcquire.aspx" & "'</script>")
                Else
                    Page.RegisterClientScriptBlock("LoadHiddenBase", "<script language = 'javascript'>parent.Hiddenbase.location.href='WSaveSession.aspx?FormName=" & Request.QueryString("URL") & "'</script>")
                End If
            Else
                Page.RegisterClientScriptBlock("LoadHiddenBase", "<script language = 'javascript'>parent.Hiddenbase.location.href='WSaveSession.aspx'</script>")
            End If
        End Sub

        ' Refresh group method
        Private Sub RefreshGroup()
            Dim tblSysView As DataTable
            Dim lsItem As ListItem

            ' get the list of user views
            tblSysView = objBItemCollection.GetSysUserViews(clsSession.GlbUser)
            ' Write Error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBItemCollection.ErrorMsg, ddlLabel.Items(1).Text, objBItemCollection.ErrorCode)

            If Not tblSysView Is Nothing Then
                tblSysView = InsertOneRow(tblSysView, Trim(ddlLabel.Items(4).Text), True)
                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, ErrorMsg, ddlLabel.Items(1).Text, ErrorCode)
            End If

            ' Bind the user views to the drop down list
            If Not tblSysView Is Nothing Then
                If tblSysView.Rows.Count > 0 Then
                    ddlGroup.DataSource = tblSysView
                    ddlGroup.DataTextField = "ViewName"
                    ddlGroup.DataValueField = "ID"
                    ddlGroup.DataBind()
                Else
                    ddlGroup.Items.Clear()
                    lsItem.Text = ddlLabel.Items(4).Text
                    lsItem.Value = 0
                    ddlGroup.Items.Add(lsItem)
                End If
            Else
                ddlGroup.Items.Clear()
                lsItem.Text = ddlLabel.Items(4).Text
                lsItem.Value = 0
                ddlGroup.Items.Add(lsItem)
            End If
        End Sub

        ' ProcessSearchGroup method
        ' Purpose: Get the select statement, update or insert to the sys view table
        '          then create or alter user view
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
            Dim inti As Integer = 0

            Dim tblItem As New DataTable
            Dim strOutPut As String
            Dim intOutPut As Integer

            ' Add to the arrays new elements if the text boxes is not null
            ' Title
            If Not Trim(txtTitle.Text) = "" Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrField(intIndex)
                ReDim Preserve arrVal(intIndex)
                arrBool(intIndex) = "AND"
                arrField(intIndex) = "TI"
                arrVal(intIndex) = txtTitle.Text
                intIndex = intIndex + 1
            End If
            ' Country
            If Not Trim(txtCountry.Text) = "" Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrField(intIndex)
                ReDim Preserve arrVal(intIndex)
                arrBool(intIndex) = "AND"
                arrField(intIndex) = "11"
                arrVal(intIndex) = txtCountry.Text
                intIndex = intIndex + 1
            End If
            ' Publisher
            If Not Trim(txtPublisher.Text) = "" Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrField(intIndex)
                ReDim Preserve arrVal(intIndex)
                arrBool(intIndex) = "AND"
                arrField(intIndex) = "2"
                arrVal(intIndex) = txtPublisher.Text
                intIndex = intIndex + 1
            End If
            ' Language
            If Not Trim(txtLanguage.Text) = "" Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrField(intIndex)
                ReDim Preserve arrVal(intIndex)
                arrBool(intIndex) = "AND"
                arrField(intIndex) = "10"
                arrVal(intIndex) = txtLanguage.Text
                intIndex = intIndex + 1
            End If
            ' Regularity
            If Not Trim(ddlRegularity.SelectedValue) = Trim(ddlLabel.Items(2).Text) Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrField(intIndex)
                ReDim Preserve arrVal(intIndex)
                arrBool(intIndex) = "AND"
                arrField(intIndex) = "FR"
                arrVal(intIndex) = ddlRegularity.SelectedValue
                intIndex = intIndex + 1
            End If
            ' ISSN
            If Not Trim(txtISSN.Text) = "" Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrField(intIndex)
                ReDim Preserve arrVal(intIndex)
                arrBool(intIndex) = "AND"
                arrField(intIndex) = "IS"
                arrVal(intIndex) = txtISSN.Text
                intIndex = intIndex + 1
            End If
            ' Classify
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
                arrVal(intIndex) = txtClassify.Text
                intIndex = intIndex + 1
            End If
            ' Subject
            If Not Trim(txtSubject.Text) = "" Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrField(intIndex)
                ReDim Preserve arrVal(intIndex)
                arrBool(intIndex) = "AND"
                arrField(intIndex) = "9"
                arrVal(intIndex) = txtSubject.Text
                intIndex = intIndex + 1
            End If
            ' Keyword
            If Not Trim(txtKeyword.Text) = "" Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrField(intIndex)
                ReDim Preserve arrVal(intIndex)
                arrBool(intIndex) = "AND"
                arrField(intIndex) = "3"
                arrVal(intIndex) = txtKeyword.Text
                intIndex = intIndex + 1
            End If

            ' Formming the sql statement
            If Not Trim(txtTitle.Text) = "" Or Not Trim(txtCountry.Text) = "" Or _
                Not Trim(txtPublisher.Text) = "" Or Not Trim(txtLanguage.Text) = "" Or _
                Not Trim(txtISSN.Text) = "" Or Not Trim(txtClassify.Text) = "" Or _
                Not Trim(txtSubject.Text) = "" Or Not Trim(txtKeyword.Text) = "" Or _
                Not Trim(ddlRegularity.SelectedValue) = Trim(ddlLabel.Items(2).Text) Then

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
                'Response.Write(strSQL)
                'Response.End()
                'strSQL = strSQL.Replace("WHERE 1=1", "WHERE OPAC=1")
                'strSQL = strSQL.Replace("DISTINCT", "")
                'objBCDBS.SQLStatement = strSQL
                'Dim tblIDs As DataTable
                'tblIDs = objBCDBS.RetrieveItemInfor
                'strSQL = ""
                'If Not tblIDs Is Nothing AndAlso tblIDs.Rows.Count > 0 Then
                '    For inti = 0 To tblIDs.Rows.Count - 1
                '        strSQL = strSQL & tblIDs.Rows(inti).Item(0) & ","
                '    Next
                '    If strSQL <> "" Then
                '        strSQL = Left(strSQL, Len(strSQL) - 1)
                '    End If
                'End If
            End If

            ' Process the select statement strings (separate the field and value search by $@)
            ' (To get back the search value in to the controls each time view loaded)
            If strSQL <> "" Then
                strSQLStatement = "SELECT DISTINCT Lib_tblItem.ID, Lib_tblItem.Code, Lib_tblField200S.CONTENT AS TITLE,Lib_tblField000S.CONTENT AS ISSN FROM " & _
                "Lib_tblItem LEFT JOIN Lib_tblField200S ON Lib_tblItem.ID = Lib_tblField200S.ITEMID AND Lib_tblField200S.FIELDCODE = '245' " & _
                "LEFT JOIN Lib_tblField000S ON Lib_tblItem.ID = Lib_tblField000S.ITEMID AND Lib_tblField000S.FIELDCODE = '022' " & _
                "WHERE Lib_tblItem.ID IN (" & strSQL & ")"
                'strSQLStatement = "SELECT DISTINCT Item.ID, Item.Code, Lib_tblField200S.CONTENT AS TITLE,'' AS ISSN FROM " & _
                '                "ITEM LEFT JOIN Lib_tblField200S ON ITEM.ID = Lib_tblField200S.ITEMID AND Lib_tblField200S.FIELDCODE = '245' " & _
                '                "WHERE ITEM.ID IN (" & strSQL & ")"
                ' Get the strSelectStatement

                ' Get the field name(s) search
                For inti = LBound(arrField) To UBound(arrField)
                    strSelectStatement = strSelectStatement & arrField(inti) & "$@"
                Next

                ' Get the field value(s) search (separate the field names by #)
                If Trim(strSelectStatement) <> "" Then
                    strSelectStatement = strSelectStatement & "#"
                    For inti = LBound(arrField) To UBound(arrField)
                        strSelectStatement = strSelectStatement & arrVal(inti) & "$@"
                    Next
                End If
            End If
            'Set Lib ID
            strSQLStatement = strSQLStatement & " and (  LibId =  " & clsSession.GlbSite.ToString() & " or " & clsSession.GlbSite.ToString() & " =0 ) "

            ' UPDATE or NOT
            If Not ddlGroup.SelectedValue = 0 Then  ' UPDATE
                Dim intCount As Integer
                Dim intViewID As Integer

                intViewID = CInt(ddlGroup.SelectedValue)
                objBItemCollection.LibID = clsSession.GlbSite
                tblItem = objBItemCollection.SearchSerialItems(clsSession.GlbUser, txtGroupName.Text, strSQLStatement, strSelectStatement, intViewID, strOutPut, 1)
                'tblItem = objBItemCollection.SearchSerialItems(clsSession.GlbUser, clsSession.GlbUser, strSQLStatement, strSelectStatement, intViewID, strOutPut, 1)

                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBItemCollection.ErrorMsg, ddlLabel.Items(1).Text, objBItemCollection.ErrorCode)

                'Call RefreshGroup()
                For intCount = 0 To ddlGroup.Items.Count - 1
                    If CStr(ddlGroup.Items(intCount).Value) = Trim(CStr(intViewID)) Then
                        ddlGroup.SelectedIndex = intCount
                    End If
                Next
            Else  ' NOT UPDATE (INSERT)
                ' Kiem tra trung ten nhom
                intOutPut = objBItemCollection.CheckGroupName(clsSession.GlbUser, txtGroupName.Text)
                If intOutPut > 0 Then
                    Page.RegisterClientScriptBlock("SameJS", "<script language='javascript'>alert('" & ddlLabel.Items(9).Text & "');</script>")
                Else

                    tblItem = objBItemCollection.SearchSerialItems(clsSession.GlbUser, txtGroupName.Text, strSQLStatement, strSelectStatement, 0, strOutPut)
                    'tblItem = objBItemCollection.SearchSerialItems(clsSession.GlbUser, clsSession.GlbUser, strSQLStatement, strSelectStatement, 0, strOutPut)

                    ' Write Error
                    Call WriteErrorMssg(ddlLabel.Items(0).Text, objBItemCollection.ErrorMsg, ddlLabel.Items(1).Text, objBItemCollection.ErrorCode)

                    'If tblItem Is Nothing Then
                    '    Page.RegisterClientScriptBlock("SameJS", "<script language='javascript'>alert('" & ddlLabel.Items(9).Text & "');</script>")
                    'End If
                    Call RefreshGroup()
                    'ddlGroup.SelectedIndex = ddlGroup.Items.Count - 2
                End If
            End If

            '********************* BEGINDISPLAY THE SEARCH RESULT *******************
            If Not tblItem Is Nothing Then
                If tblItem.Rows.Count > 0 Then
                    lblResult.Visible = False
                    dtgResult.Visible = True
                    dtgResult.DataSource = tblItem
                    dtgResult.DataBind()
                Else
                    lblResult.Visible = True
                    dtgResult.Visible = False
                End If
            End If
        End Sub

        ' btnUpdate_Click event
        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Call ProcessSearchGroup()
        End Sub

        ' dtgResult_PageIndexChanged event
        ' Purpose: Change the page index
        'Private Sub dtgResult_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgResult.PageIndexChanged
        '    dtgResult.CurrentPageIndex = e.NewPageIndex
        '    Call BindData()
        'End Sub


        Protected Sub dtgResult_PageIndexChanged(sender As Object, e As GridPageChangedEventArgs) Handles dtgResult.PageIndexChanged
            dtgResult.CurrentPageIndex = e.NewPageIndex
            Call ResultSearch()
        End Sub

        ' Delete_Click event
        Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            If Not ddlGroup.SelectedValue = 0 Then
                objBItemCollection.RemoveSysUserView(ddlGroup.SelectedValue)

                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBItemCollection.ErrorMsg, ddlLabel.Items(1).Text, objBItemCollection.ErrorCode)

                Call BindDropdownList()
                Call BindData()
            End If
        End Sub

        ' BindData method
        Private Sub BindData()
            Dim tblItem As DataTable
            Dim strOutPut As String
            Dim arrField() As String
            Dim arrValue() As String
            Dim arrRecord() As String
            Dim intIndex As Integer
            Dim inti As Integer

            'Call ClearControls()
            If ddlGroup.SelectedIndex <> ddlGroup.Items.Count - 1 Then
                tblItem = objBItemCollection.SearchSerialItems(clsSession.GlbUser, "", "", "", ddlGroup.SelectedValue, strOutPut)
                'tblItem = objBItemCollection.SearchSerialItems(clsSession.GlbUser, clsSession.GlbUser, "", "", ddlGroup.SelectedValue, strOutPut)

                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBItemCollection.ErrorMsg, ddlLabel.Items(1).Text, objBItemCollection.ErrorCode)

                ' Get the search value

                '********************* BEGINDISPLAY THE SEARCH RESULT *******************
                If Not tblItem Is Nothing Then
                    If tblItem.Rows.Count > 0 Then
                        lblResult.Visible = False
                        dtgResult.Visible = True
                        dtgResult.DataSource = tblItem
                        ' dtgResult.DataBind()
                    Else
                        lblResult.Visible = True
                        dtgResult.Visible = False
                    End If
                End If

                txtGroupName.Text = ddlGroup.Items(ddlGroup.SelectedIndex).Text
            Else
                lblResult.Visible = False
                dtgResult.Visible = False
            End If
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
            strJavaScript1 = "'WGetReferences.aspx?Frame=txtCountry&DicID=11&SearchData=' + document.forms[0].txtCountry.value"
            strJavaScript2 = "'WGetReferences.aspx?Frame=txtPublisher&DicID=2&SearchData=' + document.forms[0].txtPublisher.value"
            strJavaScript3 = "'WGetReferences.aspx?Frame=txtLanguage&DicID=10&SearchData=' + document.forms[0].txtLanguage.value"

            Select Case strVal
                Case "0"
                    strJavaScript4 = "'WGetReferences.aspx?Frame=txtClassify&DicID=4&SearchData=' + document.forms[0].txtClassify.value"
                Case "1"
                    strJavaScript4 = "'WGetReferences.aspx?Frame=txtClassify&DicID=5&SearchData=' + document.forms[0].txtClassify.value"
            End Select

            strJavaScript5 = "'WGetReferences.aspx?Frame=txtSubject&DicID=9&SearchData=' + document.forms[0].txtSubject.value"
            strJavaScript6 = "'WGetReferences.aspx?Frame=txtKeyword&DicID=3&SearchData=' + document.forms[0].txtKeyword.value"

            ' Add attributes for the hyperlinks
            lnkCountry.NavigateUrl = "javascript:OpenWindow(" & strJavaScript1 & ",'Dictionary',450,400,150,30)"
            lnkPublisher.NavigateUrl = "javascript:OpenWindow(" & strJavaScript2 & ",'Dictionary',450,400,150,30)"
            lnkLanguage.NavigateUrl = "javascript:OpenWindow(" & strJavaScript3 & ",'Dictionary',450,400,150,30)"
            lnkClassify.NavigateUrl = "javascript:OpenWindow(" & strJavaScript4 & ",'Dictionary',450,400,150,30)"
            lnkSubject.NavigateUrl = "javascript:OpenWindow(" & strJavaScript5 & ",'Dictionary',450,400,150,30)"
            lnkKeyword.NavigateUrl = "javascript:OpenWindow(" & strJavaScript6 & ",'Dictionary',450,400,150,30)"
        End Sub

        ' dtgResult_ItemCreated event
        ' Purpose: Add the javascript for each table row
        Private Sub dtgResult_ItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles dtgResult.ItemCreated

            If TypeOf e.Item Is GridDataItem Then
                Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)


                Dim lnkSession = TryCast(e.Item.FindControl("lnkSelect"), HyperLink)
                If Not lnkSession Is Nothing AndAlso e.Item.DataItem IsNot Nothing Then
                    lnkSession.NavigateUrl = "javascript:parent.Hiddenbase.document.forms[0].hidItemID.value=" & DataBinder.Eval(e.Item.DataItem, "ID") & ";parent.Hiddenbase.document.forms[0].hidTitle.value='" & DataBinder.Eval(e.Item.DataItem, "Title").ToString.Replace("'", "'+String.fromCharCode(39)+'") & "';alert('" & ddlLabel.Items(8).Text & "');parent.Hiddenbase.document.forms[0].btnSave.click();"
                End If

                Dim lnkItemDetails = TryCast(e.Item.FindControl("lnkItemDetails"), HyperLink)
                If Not lnkItemDetails Is Nothing Then
                    lnkItemDetails.NavigateUrl = "javascript:OpenWindow('WItemDetails.aspx?ItemID=" & DataBinder.Eval(e.Item.DataItem, "ID") & "','ViewItem',500,200,200,50);"
                End If

            End If
        End Sub

        ' ddlGroup_SelectedIndexChanged event
        ' Purpose: Get the data of view selected by user
        Private Sub ddlGroup_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlGroup.SelectedIndexChanged
            Call BindData()
            If ddlGroup.SelectedValue = 0 Then
                txtGroupName.Text = ""
            End If
        End Sub

        ' ClearControls method
        Private Sub ClearControls()
            txtTitle.Text = ""
            txtClassify.Text = ""
            txtCountry.Text = ""
            txtISSN.Text = ""
            txtKeyword.Text = ""
            txtLanguage.Text = ""
            txtPublisher.Text = ""
            txtSubject.Text = ""
            ddlRegularity.SelectedIndex = 0
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCommonBusiness Is Nothing Then
                    objBCommonBusiness.Dispose(True)
                    objBCommonBusiness = Nothing
                End If
                If Not objBItemCollection Is Nothing Then
                    objBItemCollection.Dispose(True)
                    objBItemCollection = Nothing
                End If
                If Not objBFormingSQL Is Nothing Then
                    objBFormingSQL.Dispose(True)
                    objBFormingSQL = Nothing
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

        Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
            ResultSearch()
        End Sub

        Private Sub ResultSearch()
            ' Variables
            Dim arrBool()
            Dim arrVal()
            Dim arrField()

            Dim intIDSumFound As Integer
            Dim intIndex = 0 ' Use to bound the array
            Dim strSQL As String = ""
            Dim strSQLStatement As String = ""
            Dim strSelectStatement As String = ""
            Dim inti As Integer = 0

            Dim tblItem As New DataTable
            Dim strOutPut As String
            Dim intOutPut As Integer

            ' Add to the arrays new elements if the text boxes is not null
            ' Title
            If Not Trim(txtTitle.Text) = "" Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrField(intIndex)
                ReDim Preserve arrVal(intIndex)
                arrBool(intIndex) = "AND"
                arrField(intIndex) = "TI"
                arrVal(intIndex) = txtTitle.Text
                intIndex = intIndex + 1
            End If
            ' Country
            If Not Trim(txtCountry.Text) = "" Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrField(intIndex)
                ReDim Preserve arrVal(intIndex)
                arrBool(intIndex) = "AND"
                arrField(intIndex) = "11"
                arrVal(intIndex) = txtCountry.Text
                intIndex = intIndex + 1
            End If
            ' Publisher
            If Not Trim(txtPublisher.Text) = "" Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrField(intIndex)
                ReDim Preserve arrVal(intIndex)
                arrBool(intIndex) = "AND"
                arrField(intIndex) = "2"
                arrVal(intIndex) = txtPublisher.Text
                intIndex = intIndex + 1
            End If
            ' Language
            If Not Trim(txtLanguage.Text) = "" Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrField(intIndex)
                ReDim Preserve arrVal(intIndex)
                arrBool(intIndex) = "AND"
                arrField(intIndex) = "10"
                arrVal(intIndex) = txtLanguage.Text
                intIndex = intIndex + 1
            End If
            ' Regularity
            If Not Trim(ddlRegularity.SelectedValue) = Trim(ddlLabel.Items(2).Text) Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrField(intIndex)
                ReDim Preserve arrVal(intIndex)
                arrBool(intIndex) = "AND"
                arrField(intIndex) = "FR"
                arrVal(intIndex) = ddlRegularity.SelectedValue
                intIndex = intIndex + 1
            End If
            ' ISSN
            If Not Trim(txtISSN.Text) = "" Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrField(intIndex)
                ReDim Preserve arrVal(intIndex)
                arrBool(intIndex) = "AND"
                arrField(intIndex) = "IS"
                arrVal(intIndex) = txtISSN.Text
                intIndex = intIndex + 1
            End If
            ' Classify
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
                arrVal(intIndex) = txtClassify.Text
                intIndex = intIndex + 1
            End If
            ' Subject
            If Not Trim(txtSubject.Text) = "" Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrField(intIndex)
                ReDim Preserve arrVal(intIndex)
                arrBool(intIndex) = "AND"
                arrField(intIndex) = "9"
                arrVal(intIndex) = txtSubject.Text
                intIndex = intIndex + 1
            End If
            ' Keyword
            If Not Trim(txtKeyword.Text) = "" Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrField(intIndex)
                ReDim Preserve arrVal(intIndex)
                arrBool(intIndex) = "AND"
                arrField(intIndex) = "3"
                arrVal(intIndex) = txtKeyword.Text
                intIndex = intIndex + 1
            End If

            ' Formming the sql statement
            If Not Trim(txtTitle.Text) = "" Or Not Trim(txtCountry.Text) = "" Or _
                Not Trim(txtPublisher.Text) = "" Or Not Trim(txtLanguage.Text) = "" Or _
                Not Trim(txtISSN.Text) = "" Or Not Trim(txtClassify.Text) = "" Or _
                Not Trim(txtSubject.Text) = "" Or Not Trim(txtKeyword.Text) = "" Or _
                Not Trim(ddlRegularity.SelectedValue) = Trim(ddlLabel.Items(2).Text) Then

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
                'Response.Write(strSQL)
                'Response.End()
                'strSQL = strSQL.Replace("WHERE 1=1", "WHERE OPAC=1")
                'strSQL = strSQL.Replace("DISTINCT", "")
                'objBCDBS.SQLStatement = strSQL
                'Dim tblIDs As DataTable
                'tblIDs = objBCDBS.RetrieveItemInfor
                'strSQL = ""
                'If Not tblIDs Is Nothing AndAlso tblIDs.Rows.Count > 0 Then
                '    For inti = 0 To tblIDs.Rows.Count - 1
                '        strSQL = strSQL & tblIDs.Rows(inti).Item(0) & ","
                '    Next
                '    If strSQL <> "" Then
                '        strSQL = Left(strSQL, Len(strSQL) - 1)
                '    End If
                'End If
            End If

            ' Process the select statement strings (separate the field and value search by $@)
            ' (To get back the search value in to the controls each time view loaded)
            If strSQL <> "" Then
                strSQLStatement = "SELECT DISTINCT Lib_tblItem.ID, Lib_tblItem.Code, Lib_tblField200S.CONTENT AS TITLE,Lib_tblField000S.CONTENT AS ISSN FROM " & _
                "Lib_tblItem LEFT JOIN Lib_tblField200S ON Lib_tblItem.ID = Lib_tblField200S.ITEMID AND Lib_tblField200S.FIELDCODE = '245' " & _
                "LEFT JOIN Lib_tblField000S ON Lib_tblItem.ID = Lib_tblField000S.ITEMID AND Lib_tblField000S.FIELDCODE = '022' " & _
                "WHERE Lib_tblItem.ID IN (" & strSQL & ")"
                'strSQLStatement = "SELECT DISTINCT Item.ID, Item.Code, Lib_tblField200S.CONTENT AS TITLE,'' AS ISSN FROM " & _
                '                "ITEM LEFT JOIN Lib_tblField200S ON ITEM.ID = Lib_tblField200S.ITEMID AND Lib_tblField200S.FIELDCODE = '245' " & _
                '                "WHERE ITEM.ID IN (" & strSQL & ")"
                ' Get the strSelectStatement

                ' Get the field name(s) search
                For inti = LBound(arrField) To UBound(arrField)
                    strSelectStatement = strSelectStatement & arrField(inti) & "$@"
                Next

                ' Get the field value(s) search (separate the field names by #)
                If Trim(strSelectStatement) <> "" Then
                    strSelectStatement = strSelectStatement & "#"
                    For inti = LBound(arrField) To UBound(arrField)
                        strSelectStatement = strSelectStatement & arrVal(inti) & "$@"
                    Next
                End If
            End If
            'Set Lib ID
            strSQLStatement = strSQLStatement & " and (  LibId =  " & clsSession.GlbSite.ToString() & " or " & clsSession.GlbSite.ToString() & " =0 ) "

            tblItem = objBItemCollection.SearchSerialItemsNoSave(strSQLStatement)

            '********************* BEGINDISPLAY THE SEARCH RESULT *******************
            If Not tblItem Is Nothing Then
                If tblItem.Rows.Count > 0 Then
                    lblResult.Visible = False
                    dtgResult.Visible = True
                    dtgResult.DataSource = tblItem
                    dtgResult.DataBind()
                Else
                    lblResult.Visible = True
                    dtgResult.Visible = False
                End If
            End If
        End Sub

        Public Function NumberOfRecord() As Integer Implements IUCNumberOfRecord.NumberOfRecord
            Return 25
        End Function


        Protected Sub dtgResult_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles dtgResult.NeedDataSource
            BindData()
        End Sub

    End Class
End Namespace