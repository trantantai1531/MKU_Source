Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WIDXForm
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
        Private objBCatDic As New clsBCatDicList
        Private objBItemType As New clsBCatDicItemType
        Private objBIDXUpdate As New clsBIDXUpdate
        Private objBIDXGrp As New clsBIDXGroup
        Private objBIDX As New clsBIDX
        Private objBItemCollection As New clsBItemCollection

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Init all object use in form
            Call Initialize()
            ' Bind javascript for all control need
            Call BindJavaScript()
            ' Bind Hyperlink for calendars,dictionaries
            Call BindHiperLink()
            If Not Page.IsPostBack Then
                'Show data init on form
                Call LoadData()
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            'Object objBCatDic
            objBCatDic.InterfaceLanguage = Session("InterfaceLanguage")
            objBCatDic.DBServer = Session("DbServer")
            objBCatDic.ConnectionString = Session("ConnectionString")
            objBCatDic.Initialize()

            'Object objBItemType
            objBItemType.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemType.DBServer = Session("DbServer")
            objBItemType.ConnectionString = Session("ConnectionString")
            objBItemType.Initialize()

            'Object objBIDXUpdate
            objBIDXUpdate.InterfaceLanguage = Session("InterfaceLanguage")
            objBIDXUpdate.DBServer = Session("DbServer")
            objBIDXUpdate.ConnectionString = Session("ConnectionString")
            objBIDXUpdate.Initialize()

            'Object objBIDXGrp
            objBIDXGrp.InterfaceLanguage = Session("InterfaceLanguage")
            objBIDXGrp.DBServer = Session("DbServer")
            objBIDXGrp.ConnectionString = Session("ConnectionString")
            objBIDXGrp.Initialize()

            'Object objBIDX
            objBIDX.InterfaceLanguage = Session("InterfaceLanguage")
            objBIDX.DBServer = Session("DbServer")
            objBIDX.ConnectionString = Session("ConnectionString")
            objBIDX.Initialize()

            'objBItemCollection
            objBItemCollection.IsAuthority = 0
            objBItemCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemCollection.DBServer = Session("DBServer")
            objBItemCollection.ConnectionString = Session("ConnectionString")
            objBItemCollection.Initialize()
        End Sub

        ' BindJavaScript method
        Private Sub BindJavaScript()
            ' Declare variables
            Dim strDateCheck As String

            Page.RegisterClientScriptBlock("JSCommon", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("JSSelf", "<script language = 'javascript' src = '../js/Bibliography/WIDXForm.js'></script>")
            btnUpdateGroup.Attributes.Add("onClick", "return ValidUpdate('" & ddlLabel.Items(1).Text & "','" & ddlLabel.Items(2).Text & "','" & ddlLabel.Items(14).Text & "','" & ddlLabel.Items(15).Text & "','" & ddlLabel.Items(16).Text & "','" & ddlLabel.Items(19).Text & "');")
            btnDelGroup.Attributes.Add("onClick", "return ValidDel('" & ddlLabel.Items(0).Text & "','" & ddlLabel.Items(4).Text & "');")
            btnViewGroup.Attributes.Add("onClick", "return ValidView('" & ddlLabel.Items(0).Text & "');")


            strDateCheck = "return CheckDate(this,'dd/mm/yyyy','" & ddlLabel.Items(17).Text & "')"
            txtCataFrom.Attributes.Add("OnChange", strDateCheck)
            txtCataTo.Attributes.Add("OnChange", strDateCheck)
            SetCheckNumber(txtIDFrom, ddlLabel.Items(20).Text, "")
            SetCheckNumber(txtIDTo, ddlLabel.Items(20).Text, "")
        End Sub

        ' BindHiperLink method
        ' Purpose: Bind the javascripts to the hiperlinks 
        Private Sub BindHiperLink()
            Dim strJavaScript1 As String
            Dim strJavaScript2 As String
            Dim strJavaScript3 As String
            Dim strJavaScript4 As String
            Dim strDicName As String

            strJavaScript1 = "'../Catalogue/WReferenceToFilter.aspx?Frame=txtVal1&DicID='+document.Form1.ddlField1.options[document.Form1.ddlField1.options.selectedIndex].value + '&SearchData=' + document.Form1.txtVal1.value"
            strJavaScript2 = "'../Catalogue/WReferenceToFilter.aspx?Frame=txtVal2&DicID='+document.Form1.ddlField2.options[document.Form1.ddlField2.options.selectedIndex].value + '&SearchData=' + document.Form1.txtVal2.value"
            strJavaScript3 = "'../Catalogue/WReferenceToFilter.aspx?Frame=txtVal3&DicID='+document.Form1.ddlField2.options[document.Form1.ddlField2.options.selectedIndex].value + '&SearchData=' + document.Form1.txtVal3.value"
            strJavaScript4 = "'../Catalogue/WReferenceToFilter.aspx?Frame=txtVal4&DicID='+document.Form1.ddlField4.options[document.Form1.ddlField4.options.selectedIndex].value + '&SearchData=' + document.Form1.txtVal4 .value"
            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkFrom, txtCataFrom, ddlLabel.Items(17).Text)
            SetOnclickCalendar(lnkTo, txtCataTo, ddlLabel.Items(17).Text)

            lnkDic1.NavigateUrl = "javascript:OpenWindow(" & strJavaScript1 & ",'Dictionary',350,300,150,30)"
            lnkDic2.NavigateUrl = "javascript:OpenWindow(" & strJavaScript2 & ",'Dictionary',350,300,150,30)"
            lnkDic3.NavigateUrl = "javascript:OpenWindow(" & strJavaScript3 & ",'Dictionary',350,300,150,30)"
            lnkDic4.NavigateUrl = "javascript:OpenWindow(" & strJavaScript4 & ",'Dictionary',350,300,150,30)"
        End Sub

        ' Method: LoadData
        ' Purpose: Show data on form
        Private Sub LoadData()
            ' Bind Boolean dropdownlist
            Dim arrFN() As String = {"AND", "OR", "NOT"}
            Dim arrV() As String = {"AND", "OR", "NOT"}
            Dim tblBool As New DataTable
            Dim intCount As Integer

            tblBool = CreateTable(arrFN, arrV)
            ddlBool1.DataSource = tblBool
            ddlBool1.DataTextField = "TextField"
            ddlBool1.DataValueField = "ValueField"
            ddlBool1.DataBind()
            ddlBool2.DataSource = tblBool
            ddlBool2.DataTextField = "TextField"
            ddlBool2.DataValueField = "ValueField"
            ddlBool2.DataBind()
            ddlBool3.DataSource = tblBool
            ddlBool3.DataTextField = "TextField"
            ddlBool3.DataValueField = "ValueField"
            ddlBool3.DataBind()
            ddlBool4.DataSource = tblBool
            ddlBool4.DataTextField = "TextField"
            ddlBool4.DataValueField = "ValueField"
            ddlBool4.DataBind()

            ' Bind field dropdownlist
            Dim tblCatDic As New DataTable
            ' select only IndexTable not NULL
            objBCatDic.IsDic = 0
            tblCatDic = objBCatDic.Retrieve()
            ddlField1.DataSource = tblCatDic
            ddlField1.DataTextField = "Name"
            ddlField1.DataValueField = "ID"
            ddlField1.DataBind()

            ddlField2.DataSource = tblCatDic
            ddlField2.DataTextField = "Name"
            ddlField2.DataValueField = "ID"
            ddlField2.DataBind()

            ddlField3.DataSource = tblCatDic
            ddlField3.DataTextField = "Name"
            ddlField3.DataValueField = "ID"
            ddlField3.DataBind()

            ddlField4.DataSource = tblCatDic
            ddlField4.DataTextField = "Name"
            ddlField4.DataValueField = "ID"
            ddlField4.DataBind()

            ' List box Item Type
            lstItemType.DataSource = objBItemType.Retrieve()
            lstItemType.DataTextField = "StrView"
            lstItemType.DataValueField = "ID"
            lstItemType.DataBind()

            ' drop down list Group select
            Dim tblGroup As New DataTable
            objBIDXGrp.IDs = Request.QueryString("ID")
            objBIDXGrp.GroupID = 0
            tblGroup = objBIDXGrp.IDXDetailRetrieveDistLink
            tblGroup = objBIDXGrp.ProcessTable(tblGroup)
            ddlGroupHave.DataSource = tblGroup
            ddlGroupHave.DataTextField = "strView"
            ddlGroupHave.DataValueField = "GroupID"
            ddlGroupHave.DataBind()

            ' drop down list First, Last

            ' drop down list Group Name
            Dim tblGrp As New DataTable
            objBIDXGrp.IDs = Request.QueryString("ID")
            objBIDXGrp.GroupID = 0
            tblGrp = objBIDXGrp.IDXDetailRetrieveDist
            ddlGroup.DataSource = InsertOneRow(tblGrp, ddlLabel.Items(3).Text)
            ddlGroup.DataTextField = "GroupName"
            ddlGroup.DataValueField = "GroupID"
            ddlGroup.DataBind()
            tblGroup.Clear()

            For intCount = 0 To ddlGroup.Items.Count - 1
                If CStr(ddlGroup.Items(intCount).Value) = "0" Or CStr(ddlGroup.Items(intCount).Value = "") Then
                    ddlGroup.Items(intCount).Selected = True
                Else
                    ddlGroup.Items(intCount).Selected = False
                End If
                Exit For
            Next

            'Page Title
            Dim tblBib As New DataTable
            objBIDX.IDs = Request.QueryString("ID")
            objBIDX.UserID = 0
            tblBib = objBIDX.IDXRetrieve()
            If tblBib.Rows.Count > 0 Then
                lblPageHeader.Text = tblBib.Rows(0).Item("Title")
            End If
        End Sub

        ' btnUpdateGroup_Click event
        Private Sub btnUpdateGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateGroup.Click
            Dim intGroupID As Integer = 0
            Dim strUpdateType As String = 0
            Dim intIDXID As Integer
            Dim tblGrp As New DataTable
            Dim longTORs As Long
            Dim strMSg As String
            Dim strCataFrom As String
            Dim strCataTo As String

            intIDXID = CInt("0" & Request.QueryString("ID"))
            objBIDXGrp.IDs = CStr(intIDXID)
            objBIDXGrp.GroupID = 0
            objBIDXGrp.LibID = clsSession.GlbSite
            tblGrp = objBIDXGrp.IDXDetailRetrieve
            If ddlGroup.SelectedIndex = 0 Then
                ' have been IDX
                If tblGrp.Rows.Count > 0 Then
                    ' PaddPosition
                    ' padd abs with group
                    If ddlGroupHave.Items.Count > 0 Then
                        intGroupID = ddlGroupHave.SelectedValue
                    Else
                        intGroupID = 0
                    End If

                    If ddlBe_Af.SelectedValue = 1 Then
                        'PADD_BEFORE
                        strUpdateType = "PADD_BEFORE"
                    Else
                        'PADD_AFTER
                        strUpdateType = "PADD_AFTER"
                    End If
                Else
                    intGroupID = 0
                    ' InsertNew
                    strUpdateType = "INSERT_NEW"
                End If
            Else
                ' Group to overwrite
                intGroupID = ddlGroup.SelectedValue
                ' OverWrite
                strUpdateType = "UPDATE_OVERWRITE"
            End If

            ' Calculate the top num of record
            Dim strRecordFrom As String = ""
            Dim strRecordTo As String = ""
            Dim isOver As Boolean = False

            ' From Record ...
            If Trim(txtIDFrom.Text) <> "" Then
                Dim tblLRange As New DataTable
                objBItemCollection.TopNum = CInt(txtIDFrom.Text)
                isOver = objBItemCollection.IsOver()
                If isOver Then
                    Page.RegisterClientScriptBlock("Over", "<script language = 'javascript'>alert('" & ddlLabel.Items(18).Text & "')</script>")
                    txtIDFrom.Text = ""
                    Exit Sub
                End If
                objBItemCollection.LibID = clsSession.GlbSite
                tblLRange = objBItemCollection.GetIDByTopNum()
                If Not tblLRange Is Nothing Then
                    If tblLRange.Rows.Count > 0 Then
                        strRecordFrom = CStr(tblLRange.Rows(0).Item(0))
                    End If
                End If
            End If

            ' To Record ...
            If Trim(txtIDTo.Text) <> "" Then
                Dim tblRRange As New DataTable
                objBItemCollection.TopNum = CInt(txtIDTo.Text)
                isOver = objBItemCollection.IsOver()
                If isOver Then
                    Page.RegisterClientScriptBlock("Over", "<script language = 'javascript'>alert('" & ddlLabel.Items(18).Text & "')</script>")
                    txtIDTo.Text = ""
                    Exit Sub
                End If
                objBItemCollection.LibID = clsSession.GlbSite
                tblRRange = objBItemCollection.GetIDByTopNum()
                If Not tblRRange Is Nothing Then
                    If tblRRange.Rows.Count > 0 Then
                        strRecordTo = CStr(tblRRange.Rows(0).Item(0))
                    End If
                End If
            End If
            strCataFrom = txtCataFrom.Text.Trim
            strCataTo = txtCataTo.Text.Trim

            'Modify : Them dieu kien kiem tra den ngay bien muc khong rong
            'B1
            If (Not strCataTo = "") AndAlso (strCataFrom = strCataTo) Then
                strCataTo = strCataTo & " 23:59:59"
            End If
            'E1

            ' Get all value to array
            Dim arrBool() As String = {"AND", ddlBool1.SelectedValue, ddlBool2.SelectedValue, ddlBool3.SelectedValue, ddlBool4.SelectedValue, "AND", "AND", "AND", "AND", "AND"}
            Dim arrField() As String = {ddlField1.SelectedValue, ddlField2.SelectedValue, ddlField3.SelectedValue, ddlField4.SelectedValue, "FROMID", "TOID", "FROMDTE", "TODTE", "ITEMTYPE"}
            Dim arrValue() As String = {txtVal1.Text, txtVal2.Text, txtVal3.Text, txtVal4.Text, strRecordFrom, strRecordTo, strCataFrom, strCataTo, txtHidTypeIDs.Value}

            ' Set all value to IDXUpdate object
            objBIDXUpdate.arrBool = arrBool
            objBIDXUpdate.arrField = arrField
            objBIDXUpdate.arrValue = arrValue
            objBIDXUpdate.GroupName = txtGroupName.Text
            objBIDXUpdate.OrderBy = txtOrderBy.Text
            objBIDXUpdate.QString = FormingQString(arrBool, arrField, arrValue, txtOrderBy.Text)
            objBIDXUpdate.LibID = clsSession.GlbSite
            longTORs = objBIDXUpdate.idxUpdate(intIDXID, intGroupID, strUpdateType)
            If ddlGroup.SelectedIndex = 0 Then
                'Write log
                Call WriteLog(83, ddlLabel.Items(6).Text & txtGroupName.Text & " (" & ddlLabel.Items(9).Text & lblPageHeader.Text & ")", Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
            Else
                'Write log
                Call WriteLog(83, ddlLabel.Items(7).Text & ddlGroup.SelectedItem.Text & " (ID = " & intGroupID & "; " & ddlLabel.Items(9).Text & lblPageHeader.Text & ")", Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
            End If
            strMSg = ddlLabel.Items(12).Text & " " & CStr(longTORs) & " " & ddlLabel.Items(13).Text
            Page.RegisterClientScriptBlock("JSAlert", "<script language = 'javascript'>alert('" & strMSg & "')</script>")
            Call LoadData()
        End Sub

        ' FormingQString method
        Private Function FormingQString(ByVal arrB As Object, ByVal arrF As Object, ByVal arrV As Object, ByVal strOrderBy As String) As String
            Dim strRet As String = ""
            Dim intCount As Integer

            For intCount = 0 To UBound(arrB) - 1
                strRet = strRet & "&" & arrF(intCount) ' field
                strRet = strRet & "&" & arrB(intCount) ' bool
                strRet = strRet & "&" & arrV(intCount) ' val
            Next intCount

            If Left(strRet, 1) = "&" Then
                strRet = Right(strRet, Len(strRet) - 1)
            End If
            If strOrderBy <> "" Then
                strRet = strRet & "&" & strOrderBy
            End If
            FormingQString = strRet
        End Function

        ' ddlGroup_SelectedIndexChanged event
        Private Sub ddlGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlGroup.SelectedIndexChanged
            Dim tblGr As New DataTable
            Dim strQString As String
            Dim arrV As Object
            Dim arrF As Object
            Dim arrB As Object
            Dim arr() As String
            Dim intCount As Integer
            Dim tblTopNum As DataTable

            If Not ddlGroup.SelectedIndex = 0 Then
                objBIDXGrp.IDs = Request.QueryString("ID")
                tblGr = objBIDXGrp.IDXDetailRetrieve
                If tblGr.Rows.Count > 0 Then
                    strQString = tblGr.Rows(0).Item("QString")
                End If

                ' split strQstring to read value of Group by
                arr = Split(strQString, "&")
                If arr.Length <= 1 Then
                    Exit Sub
                End If
                txtGroupName.Text = ddlGroup.SelectedItem.Text
                'txtOrderBy.Text = arr(27)
                txtOrderBy.Text = arr(UBound(arr))
                If arr(2) & "" <> "" Then
                    Call RestoreDDL(ddlField1, ddlBool1, arr(0), arr(1))
                    txtVal1.Text = arr(2)
                End If
                If arr(5) & "" <> "" Then
                    Call RestoreDDL(ddlField2, ddlBool2, arr(6), arr(7))
                    txtVal2.Text = arr(5)
                End If
                If arr(8) & "" <> "" Then
                    Call RestoreDDL(ddlField3, ddlBool3, arr(9), arr(10))
                    txtVal3.Text = arr(8)
                End If
                If arr(11) & "" <> "" Then
                    Call RestoreDDL(ddlField4, ddlBool4, arr(12), arr(13))
                    txtVal4.Text = arr(11)
                End If
                If arr(14) & "" <> "" Then
                    objBItemCollection.ItemID = CLng(arr(14))
                    objBItemCollection.LibID = clsSession.GlbSite
                    tblTopNum = objBItemCollection.GetTopNumByID
                    If Not tblTopNum Is Nothing Then
                        If tblTopNum.Rows.Count > 0 Then
                            txtIDFrom.Text = tblTopNum.Rows(0).Item(0)
                        End If
                    End If
                End If
                If arr(17) & "" <> "" Then
                    objBItemCollection.ItemID = CLng(arr(17))
                    objBItemCollection.LibID = clsSession.GlbSite
                    tblTopNum = objBItemCollection.GetTopNumByID
                    If Not tblTopNum Is Nothing Then
                        If tblTopNum.Rows.Count > 0 Then
                            txtIDTo.Text = tblTopNum.Rows(0).Item(0)
                        End If
                    End If
                End If
                If arr(20) & "" <> "" Then
                    txtCataFrom.Text = arr(20)
                End If
                If arr(23) & "" <> "" Then
                    txtCataTo.Text = arr(23)
                End If
                If arr(26) & "" <> "" Then
                    'txtHidTypeIDs.Value = arr(26)
                    Dim strTmpIDs As String
                    strTmpIDs = "," & arr(26) & ","
                    For intCount = 0 To lstItemType.Items.Count - 1
                        If InStr(strTmpIDs, CStr(lstItemType.Items(intCount).Value)) <> 0 Then
                            lstItemType.Items(intCount).Selected = True
                        End If
                    Next intCount
                End If
            Else
                txtGroupName.Text = ""
                txtOrderBy.Text = ""
                txtVal1.Text = ""
                txtVal2.Text = ""
                txtVal3.Text = ""
                txtVal4.Text = ""
                txtCataFrom.Text = ""
                txtCataTo.Text = ""
                txtIDFrom.Text = ""
                txtIDTo.Text = ""
                ddlField1.SelectedIndex = 0
                ddlField2.SelectedIndex = 0
                ddlField3.SelectedIndex = 0
                ddlField4.SelectedIndex = 0
                ddlBool1.SelectedIndex = 0
                ddlBool2.SelectedIndex = 0
                ddlBool3.SelectedIndex = 0
                ddlBool4.SelectedIndex = 0
                For intCount = 0 To lstItemType.Items.Count - 1
                    lstItemType.Items(intCount).Selected = False
                Next intCount
            End If
        End Sub

        ' RestoreDDL method
        Private Sub RestoreDDL(ByVal ddlF As DropDownList, ByVal ddlB As DropDownList, ByVal strValF As String, ByVal strValB As String)
            Dim intCount As Integer
            For intCount = 0 To ddlF.Items.Count - 1
                If ddlF.Items(intCount).Value & "" = strValF & "" Then
                    ddlF.Items(intCount).Selected = True
                Else
                    ddlF.Items(intCount).Selected = False
                End If
            Next
            For intCount = 0 To ddlB.Items.Count - 1
                If ddlB.Items(intCount).Value & "" = strValB & "" Then
                    ddlB.Items(intCount).Selected = True
                Else
                    ddlB.Items(intCount).Selected = False
                End If
            Next
        End Sub

        ' btnViewGroup_Click event
        Private Sub btnViewGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewGroup.Click
            If ddlGroup.SelectedIndex > 0 Then
                If Not Request.QueryString("ID") & "" = "" Then
                    Response.Redirect("WIDXViewForm.aspx?intID=" & Request.QueryString("ID") & "&intIDXID=" & ddlGroup.SelectedValue & "&intTypeview=3")
                End If
            End If
        End Sub

        ' btnDelGroup_Click event
        Private Sub btnDelGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelGroup.Click
            Dim strIDs As String
            If ddlGroup.SelectedIndex > 0 Then
                objBIDXGrp.GroupID = ddlGroup.SelectedValue
                objBIDXGrp.IDs = Request.QueryString("ID")
                strIDs = objBIDXGrp.IDs
                objBIDXGrp.IDXDetailDelete()
                'Write log
                Call WriteLog(83, ddlLabel.Items(8).Text & " (IDs= " & strIDs & ")", Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                Call LoadData()
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
                If isDisposing Then
                    If Not objBCatDic Is Nothing Then
                        objBCatDic.Dispose(True)
                        objBCatDic = Nothing
                    End If
                    If Not objBItemType Is Nothing Then
                        objBItemType.Dispose(True)
                        objBItemType = Nothing
                    End If
                    If Not objBIDXUpdate Is Nothing Then
                        objBIDXUpdate.Dispose(True)
                        objBIDXUpdate = Nothing
                    End If
                    If Not objBIDXGrp Is Nothing Then
                        objBIDXGrp.Dispose(True)
                        objBIDXGrp = Nothing
                    End If
                    If Not objBIDX Is Nothing Then
                        objBIDX.Dispose(True)
                        objBIDX = Nothing
                    End If
                    If Not objBItemCollection Is Nothing Then
                        objBItemCollection.Dispose(True)
                        objBItemCollection = Nothing
                    End If
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace