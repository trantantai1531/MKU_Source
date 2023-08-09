Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WCatalogueProperty
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblMainTitleDeleteAu As System.Web.UI.WebControls.Label
        Protected WithEvents lblMainTitleDíplay As System.Web.UI.WebControls.Label
        Protected WithEvents lblMainTitleView As System.Web.UI.WebControls.Label
        Protected WithEvents lblMainTitleViewAu As System.Web.UI.WebControls.Label
        Protected WithEvents lblMsg As System.Web.UI.WebControls.Label
        Protected WithEvents lblMainTitleDelete As System.Web.UI.WebControls.Label
        Protected WithEvents lblButtonClose As System.Web.UI.WebControls.Label
        Protected WithEvents lblButtonModify As System.Web.UI.WebControls.Label
        Protected WithEvents lblButtonDelete As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBItemCollection As New clsBItemCollection
        Private objBInput As New clsBInput
        Private objBItem As New clsBItem
        Private strIDs As String
        Private strItemTopNum As String
        Private strAction As String
        Private strPostID As String
        Private strFormID As String = ""
        Private intType As Integer ' View type


        ' Page Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindVariables()
            Call BindLabel()
            Call BindJS()
            Call BindData()
        End Sub

        ' Initialize method
        Private Sub Initialize()
            'Init objBItemCollection
            objBItemCollection.ConnectionString = Session("ConnectionString")
            objBItemCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemCollection.DBServer = Session("DBServer")
            objBItemCollection.IsAuthority = Session("IsAuthority")
            Call objBItemCollection.Initialize()

            'Init objBItem
            objBItem.ConnectionString = Session("ConnectionString")
            objBItem.InterfaceLanguage = Session("InterfaceLanguage")
            objBItem.DBServer = Session("DBServer")
            objBItem.IsAuthority = Session("IsAuthority")
            Call objBItem.Initialize()


            'Init objBInput
            objBInput.ConnectionString = Session("ConnectionString")
            objBInput.InterfaceLanguage = Session("InterfaceLanguage")
            objBInput.DBServer = Session("DBServer")
            Call objBInput.Initialize()
        End Sub

        ' BindVariable method
        ' Purpose: Get the value for the variables
        Private Sub BindVariables()
            strIDs = Request("intItemID")           ' View or delete with itemID
            strItemTopNum = Request("intTopNum")    ' View with top number
            'objBItem.LibID = clsSession.GlbSite
            'objBItem.IndexId = Int(strItemTopNum.Trim())
            'Dim itemInfor = objBItem.GetItemByIndexAndLibID()
            'If Not itemInfor Is Nothing Then
            '    strItemTopNum = itemInfor.Rows(0).Item("ID")
            'End If

            intType = Request("intType")    ' View type
        End Sub

        ' Bindlabel method
        ' Purpose: Bind the text label for the controls
        Private Sub BindLabel()
            strAction = Request("Action").Trim
            Select Case strAction
                Case "Delete" ' Used to delete an Item
                    lblMainTitle.Text = ddlLabel.Items(0).Text
                    btnStatus.Text = ddlLabel.Items(7).Text
                    btnCancel.Text = ddlLabel.Items(15).Text
                    btnCancel.Visible = True
                    lblConfirmDelete.Visible = True
                    btnStatus.Attributes.Add("OnClick", " if(!confirm('" & ddlLabel.Items(14).Text & "')){return false;}")
                    'Dim js = " window.onload = function callButtonClickEvent() { document.getElementById('btnStatus').click(); console.log('hello'); }"
                    ' Page.RegisterClientScriptBlock("JSPostItemID", "<script language='javascript'>" & js & ";</script>")

                    ' btnStatus_Click(Nothing, Nothing)
                Case "Display" ' Used to display the Item details then edit
                    lblMainTitle.Text = ddlLabel.Items(2).Text
                    btnStatus.Text = ddlLabel.Items(8).Text
                    btnStatus.Attributes.Remove("OnClick")
                Case "View" ' Used to display the Item details (Xem)
                    If Session("IsAuthority") = 0 Then
                        lblMainTitle.Text = ddlLabel.Items(3).Text
                    Else
                        lblMainTitle.Text = ddlLabel.Items(4).Text
                    End If
                    btnStatus.Visible = False
                Case Else
            End Select
        End Sub

        ' BindJS method
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("JScript", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("Catalog", "<script language = 'javascript' src = '../Js/Catalogue/WCatalogueProperty.js'></script>")
            'btnStatus.Attributes.Add("OnClick", " if(!confirm('" & ddlLabel.Items(14).Text & "')){return false;}")
        End Sub

        ' BindData Method 
        ' Purpose: Bind the data 
        Private Sub BindData()
            Dim strTempID As String = ""
            Dim tblTemp As New DataTable

            ' Get the IDs string and post to the control bar (if get the top number)
            If strIDs <> "" Then
                strTempID = strIDs
                strPostID = strTempID
            Else
                objBItemCollection.TopNum = CInt(strItemTopNum)
                objBItemCollection.LibID = clsSession.GlbSite
                tblTemp = objBItemCollection.GetIDByTopNum(Session("sqlFilter") & "")
                If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                    strTempID = CStr(tblTemp.Rows(0).Item(0))
                    strPostID = strTempID
                    ' Post the ItemID into the control bar (For edit function and display with other types functions)
                    Page.RegisterClientScriptBlock("JSPostItemID", "<script language='javascript'>PostItemID(" & strPostID & ");</script>")
                    tblTemp.Clear()
                End If

            End If

            ' Display the item infor
            objBItemCollection.LibID = clsSession.GlbSite
            objBItemCollection.ItemIDs = strTempID
            tblTemp = objBItemCollection.GetItemMainInfor()

            ' Post the FormID to the control bar (For edit function)
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                strFormID = CStr(tblTemp.Rows(0).Item("FormID"))
                If strAction = "View" Then Page.RegisterClientScriptBlock("JSPostFormID", "<script language='javascript'>parent.Sentform.document.forms[0].hidFormID.value = " & strFormID & ";</script>")
            End If

            If intType <> 0 Then
                ' Disable the table 
                tblTaggedContent.Visible = False
                Select Case intType
                    Case 1      ' ISO type
                        objBItemCollection.ItemIDs = strTempID
                        If Session("IsAuthority") = 0 Then
                            Response.Write(objBItemCollection.CreateISORec)
                        Else
                            Response.Write(objBItemCollection.CreateISOAuthorityRec)
                        End If
                    Case 2      ' XML (tagged) type
                        Response.ClearContent()
                        objBItemCollection.ItemIDs = strTempID
                        Response.Write(objBItemCollection.CreateXMLTAG)
                        Response.End()
                    Case 3      ' XML (DCMI) type
                        Response.ClearContent()
                        objBItemCollection.ItemIDs = strTempID
                        Response.Write(objBItemCollection.CreateXMLDCMI)
                        Response.End()
                    Case 4      ' ISBD type
                        objBItemCollection.ItemIDs = strTempID
                        Response.Write(objBItemCollection.CreateISBDRec)
                    Case 5      ' Catalogue type
                        objBItemCollection.ItemIDs = strTempID
                        Response.Write(objBItemCollection.CreateCatalogCard)
                End Select
            Else
                ' Get the Item details by Item ID and bind to the datagrid
                objBItemCollection.ItemIDs = strTempID
                grdProperty.DataSource = objBItemCollection.GetContents
                grdProperty.DataBind()
            End If
        End Sub

        ' btnStatus_Click event (delete, display)
        Private Sub btnStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStatus.Click
            Dim tblItem As DataTable  ' Data table variable
            Dim blnNotDel As Boolean

            blnNotDel = True
            If strAction = "Delete" Then
                objBItemCollection.ItemIDs = strIDs
                If Session("IsAuthority") = 0 Then ' biliography
                    tblItem = objBItemCollection.RetrieveCode_Title()
                    If Not tblItem Is Nothing AndAlso tblItem.Rows.Count > 0 Then
                        If tblItem.Rows(0).Item("Nor") = 0 Then ' If not existing holding copies
                            objBItemCollection.ItemIDs = strIDs
                        Else
                            strIDs = ""
                            Page.RegisterClientScriptBlock("JSLoadBack", "<script language='javascript'> LoadBack('" & ddlLabel.Items(5).Text & "');</script>")
                            blnNotDel = False
                        End If
                        tblItem.Clear()
                    End If
                Else ' Authority
                    objBItemCollection.ItemIDs = strIDs
                End If

                ' Begin to delete
                If strIDs <> "" Then
                    Dim tmlItem As DataTable = objBItemCollection.GetItemByID(strIDs)
                    If (tmlItem.Rows.Count > 0) Then
                        Dim valueCode As String = tmlItem.Rows(0).Item("Code").ToString
                        Dim firstCodeItem As String = objBItemCollection.GenFirstCodeItem()
                        Dim idBookCode As Integer = Integer.Parse(valueCode.Substring(firstCodeItem.Length))

                        objBItemCollection.DeleteBookCodeByCode(idBookCode)

                        If (objBInput.ErrorMsg = "") Then
                            objBItemCollection.DeleteItem()

                            Page.RegisterClientScriptBlock("AlertJS", "<script language='javascript'>alert('" & ddlLabel.Items(13).Text.Trim & "');</script>")
                            ' Write Log
                            If Session("IsAuthority") = 0 Then
                                Call WriteLog(13, ddlLabel.Items(11).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                            Else
                                Call WriteLog(13, ddlLabel.Items(12).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                            End If

                            ' Change the session of string IDs (remove the deleted ID)
                            If Session("strIDs") <> "" And InStr(Session("strIDs"), ",") <> 0 Then
                                If InStr(Session("strIDs"), strIDs & ",") = 0 Then
                                    Session("strIDs") = Left(Session("strIDs"), Len(Session("strIDs")) - (Len(strIDs) + 1))
                                    Session("TotalRecord") = Session("TotalRecord") - 1
                                Else
                                    Session("strIDs") = Replace(Session("strIDs"), strIDs & ",", "")
                                    Session("TotalRecord") = Session("TotalRecord") - 1
                                End If
                            End If

                            ' Refresh the control bar
                            Page.RegisterClientScriptBlock("JSLoadControlBar", "<script language='javascript'>LoadControlBar();</script>")
                        Else
                            Page.RegisterClientScriptBlock("JSLoadControlBar", "<script language='javascript'>alert('" & objBInput.ErrorMsg & "')</script>")
                        End If

                    End If
                    
                Else ' Exist copynumber
                    If blnNotDel = True Then
                        Page.RegisterClientScriptBlock("AlertJS", "<script language='javascript'>alert('" & ddlLabel.Items(5).Text.Trim & "');</script>")
                    End If
                End If
            End If

            ' For the edit the item details
            If strAction = "Display" Then
                ' Change to the CataModify page
                Dim strURL As String
                Dim intPostTopNum As Integer

                ' Get the TopNumber (to transfer the query string 'currentID' to the WCataModify page)
                objBItemCollection.ItemID = CInt(strPostID)
                tblItem = objBItemCollection.GetTopNumByID()

                If Not tblItem Is Nothing AndAlso tblItem.Rows.Count > 0 Then
                    intPostTopNum = CInt(tblItem.Rows(0).Item(0))
                    ' Get the FormID (to transfer the query string 'FormID' to the WCataModify page)
                    objBItemCollection.ItemIDs = strPostID
                    strFormID = CStr(objBItemCollection.GetItemMainInfor().Rows(0).Item("FormID"))

                    Session("arrFilteredItemID") = Nothing
                    strURL = "WCataModify.aspx?CurrentID=" & intPostTopNum & "&ItemID=" & strPostID & "&FormID=" & strFormID
                    Page.RegisterClientScriptBlock("JSCataMod", "<script language='javascript'>opener.parent.Sentform.location.href = '" & strURL & "';self.close();</script>")
                    tblItem.Clear()
                    tblItem = Nothing
                End If
            End If
        End Sub

        ' grdProperty_ItemCreated event
        ' Purpose: Add attributes for the controls in datagrid
        Private Sub grdProperty_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdProperty.ItemCreated
            Dim strJs As String         ' String of JAVASCIPT
            Dim tblCell As TableCell
            Dim tblItem As DataTable
            Dim strSQL As String        ' String of SQL
            Dim lnk As HyperLink        ' hiperlink variable

            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                    ' alert the content of fields for the view and delete case only
                    If strAction = "View" Or strAction = "Delete" Then
                        ' Not alert with leader and field 001
                        If DataBinder.Eval(e.Item.DataItem, "FieldCode") <> "001" And DataBinder.Eval(e.Item.DataItem, "FieldCode") <> "Ldr" And DataBinder.Eval(e.Item.DataItem, "FieldCode") <> "852" Then
                            ' Get the property of field code to indicate the field having indicator or not

                            tblCell = e.Item.Cells(0)
                            lnk = CType(tblCell.FindControl("lnkFieldCode"), HyperLink)
                            lnk.NavigateUrl = "WCataViewHidden.aspx"
                            Dim strField As String = ""
                            If Not IsDBNull(DataBinder.Eval(e.Item.DataItem, "FieldCode")) Then
                                strField = CStr(DataBinder.Eval(e.Item.DataItem, "FieldCode")).Trim
                            End If
                            Dim strInd As String = ""
                            If Not IsDBNull(DataBinder.Eval(e.Item.DataItem, "Ind")) Then
                                strInd = CStr(DataBinder.Eval(e.Item.DataItem, "Ind")).Trim
                            End If
                            Dim strContent As String = ""
                            If Not IsDBNull(DataBinder.Eval(e.Item.DataItem, "Content")) Then
                                strContent = CStr(DataBinder.Eval(e.Item.DataItem, "Content")).Trim
                            End If
                            strJs = "WCataViewHidden.aspx?FieldCode=" & strField & "&Indicator=" & strInd.Replace("#", "a") & "&FieldValue=" & strContent.Replace("'", "\'")
                            lnk.Target = "Hiddenbase"
                            'lnk.NavigateUrl = "javascript:parent.Hiddenbase.location.href='" & strJs & "';"
                            lnk.Attributes.Add("OnClick", "javascript:parent.Hiddenbase.location.href='" & strJs & "';return false;")
                        End If
                    End If
            End Select
        End Sub
        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Response.Redirect("WCatalogueProperty.aspx?Action=View&intType=0&intItemID=" & strIDs)
        End Sub

        ' Page_Unload event
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Me.Dispose(True)
        End Sub

        ' Dispose Method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBItemCollection Is Nothing Then
                    objBItemCollection.Dispose(True)
                    objBItemCollection = Nothing
                End If


                If Not objBInput Is Nothing Then
                    objBInput.Dispose(True)
                    objBInput = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub


    End Class
End Namespace