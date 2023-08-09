Imports eMicLibAdmin.WebUI.Common
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.BusinessRules.Circulation
Imports Telerik.Web.UI

Namespace eMicLibAdmin.WebUI
    Partial Class WSearchCopyNumber
        Inherits clsWBase
        Implements IUCNumberOfRecord

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents btnDelete As System.Web.UI.WebControls.Button
        Protected WithEvents dgtResult As System.Web.UI.WebControls.DataGrid


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBCommonDBSystem As New clsBCommonDBSystem
        Private objBItemCollection As New clsBItemCollection
        Private objBCommonBusiness As New clsBCommonBusiness
        Private objBForming As New clsBFormingSQL

        Private intCheckIn As Int16 = 0

        ' Page_load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJavaScript()
            If Not IsPostBack Then
                BindDropdownList()
            End If
        End Sub

        ' Method: Initialze 
        ' Purpose: Initialize all objects
        Private Sub Initialize()
            objBForming.InterfaceLanguage = Session("InterfaceLanguage")
            objBForming.DBServer = Session("DBServer")
            objBForming.ConnectionString = Session("ConnectionString")
            Call objBForming.Initialize()

            ' Init for objBCommon
            objBCommonDBSystem.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonDBSystem.DBServer = Session("DBServer")
            objBCommonDBSystem.ConnectionString = Session("ConnectionString")
            Call objBCommonDBSystem.Initialize()

            ' Init for objBItemCollection
            objBItemCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemCollection.DBServer = Session("DBServer")
            objBItemCollection.ConnectionString = Session("ConnectionString")
            Call objBItemCollection.Initialize()

            ' Init for objBCommonBusiness
            objBCommonBusiness.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonBusiness.DBServer = Session("DBServer")
            objBCommonBusiness.ConnectionString = Session("ConnectionString")
            objBCommonBusiness.UserID = Session("UserID")
            Call objBCommonBusiness.Initialize()

            If Request("CheckIn") = 1 Then
                intCheckIn = 1
            Else
                intCheckIn = 0
            End If
        End Sub

        ' Method: BindJavaScript
        ' Purpose: get the javascripts, add the attributes for the controls
        Private Sub BindJavaScript()
            ' Register the javascipt files
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = 'js/WSearchCopyNumber.js'></script>")

            ' Add the attributes for the buttons
            btnSearch.Attributes.Add("OnClick", "javascript:if(!CheckNullInput('" & ddlLabel.Items(2).Text & "')) return false;")
            btnReset.Attributes.Add("OnClick", "return ResetForm();")
        End Sub

        ' Method: BindDropDownList
        ' Purpose: Get the holding location that current user manage
        Private Sub BindDropdownList()
            Dim tblUserLocation As DataTable

            tblUserLocation = objBCommonBusiness.GetLocations(2)

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCommonBusiness.ErrorMsg, ddlLabel.Items(0).Text, objBCommonBusiness.ErrorCode)

            If Not tblUserLocation Is Nothing Then
                With ddlLocation
                    tblUserLocation = InsertOneRow(tblUserLocation, ddlLabel.Items(3).Text)

                    ' Check error
                    Call WriteErrorMssg(ddlLabel.Items(1).Text, ErrorMsg, ddlLabel.Items(0).Text, ErrorCode)

                    .DataSource = tblUserLocation
                    .DataTextField = "LOCNAME"
                    .DataValueField = "ID"
                    .DataBind()
                End With
            End If
        End Sub

        ' SearchItem method
        ' Purpose: Search the Items for deletting
        Private Sub SearchItem(Optional ByVal blnPageChange As Boolean = False)
            ' Arrays
            Dim arrBool()
            Dim arrVal()
            Dim arrField()
            ' Controls
            Dim dtgItem As DataGridItem
            Dim chkSelected As CheckBox
            ' Strings
            Dim strIDs As String
            Dim strCodeCount As String
            ' Integers
            Dim intCodeCount As Integer
            Dim intCount As Integer = 0 ' Use to count the number of checked Item to delete
            Dim intIDSumFound As Integer = 0
            Dim intCopyNumSumFound As Integer
            Dim intIndex = 0 ' Use to bound the array
            ' Data Table variable
            Dim tblItem As New DataTable

            dtgResult.DataSource = Nothing
            'dtgResult.DataBind()

            If blnPageChange AndAlso hidIDs.Value <> "" Then
                objBItemCollection.ItemIDs = hidIDs.Value
                objBItemCollection.LibID = clsSession.GlbSite
                tblItem = objBItemCollection.RetrieveCode_Title()
                '********************* BEGINDISPLAY THE SEARCH RESULT *******************
                If Not tblItem Is Nothing AndAlso tblItem.Rows.Count > 0 Then
                    intCount = Math.Ceiling(tblItem.Rows.Count / dtgResult.PageSize)
                    If dtgResult.CurrentPageIndex >= intCount Then
                        dtgResult.CurrentPageIndex = dtgResult.CurrentPageIndex - 1
                    End If
                    dtgResult.DataSource = tblItem
                    'dtgResult.DataBind()
                End If
                Exit Sub
            End If

            ' Add to the arrays new elements if the text boxes is not null
            If ddlLocation.SelectedIndex <> 0 Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrField(intIndex)
                ReDim Preserve arrVal(intIndex)
                arrBool(intIndex) = "AND"
                arrField(intIndex) = "LOCID"
                arrVal(intIndex) = ddlLocation.SelectedValue
                intIndex = intIndex + 1
            End If
            If Not Trim(txtCallNumber.Text) = "" Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrField(intIndex)
                ReDim Preserve arrVal(intIndex)
                arrBool(intIndex) = "AND"
                arrField(intIndex) = "CN"
                arrVal(intIndex) = Trim(txtCallNumber.Text)
                intIndex = intIndex + 1
            End If
            If Not Trim(txtTitle.Text) = "" Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrField(intIndex)
                ReDim Preserve arrVal(intIndex)
                arrBool(intIndex) = "AND"
                arrField(intIndex) = "TI"
                arrVal(intIndex) = Trim(txtTitle.Text)
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
            If Not Trim(txtAuthor.Text) = "" Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrField(intIndex)
                ReDim Preserve arrVal(intIndex)
                arrBool(intIndex) = "AND"
                arrField(intIndex) = "1"
                arrVal(intIndex) = Trim(txtAuthor.Text)
                intIndex = intIndex + 1
            End If
            If Not Trim(txtYear.Text) = "" Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrField(intIndex)
                ReDim Preserve arrVal(intIndex)
                arrBool(intIndex) = "AND"
                arrField(intIndex) = "YR"
                arrVal(intIndex) = Trim(txtYear.Text)
                intIndex = intIndex + 1
            End If
            If Not Trim(txtCopyNumber.Text) = "" Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrField(intIndex)
                ReDim Preserve arrVal(intIndex)
                arrBool(intIndex) = "AND"
                arrField(intIndex) = "BN"
                arrVal(intIndex) = Trim(txtCopyNumber.Text)
                intIndex = intIndex + 1
            End If
            If Not Trim(txtISBN.Text) = "" Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrField(intIndex)
                ReDim Preserve arrVal(intIndex)
                arrBool(intIndex) = "AND"
                arrField(intIndex) = "IB"
                arrVal(intIndex) = Trim(txtISBN.Text)
                intIndex = intIndex + 1
            End If

            ' Add to the arrays in objBItemCollection the new arrays from the module
            objBForming.FieldArr = arrField
            objBForming.ValArr = arrVal
            objBForming.BoolArr = arrBool

            ' Formming the SQL statement
            objBForming.LibID = clsSession.GlbSite
            objBCommonDBSystem.SQLStatement = objBForming.FormingASQL

            Dim _strTemp As String = objBCommonDBSystem.SQLStatement

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBItemCollection.ErrorMsg, ddlLabel.Items(0).Text, objBItemCollection.ErrorCode)

            tblItem = objBCommonDBSystem.RetrieveItemInfor()

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCommonDBSystem.ErrorMsg, ddlLabel.Items(0).Text, objBCommonDBSystem.ErrorCode)
            'intIDSumFound = 100
            If Not tblItem Is Nothing AndAlso tblItem.Rows.Count > 0 Then
                intIDSumFound = tblItem.Rows.Count
                lblResult.Text = intIDSumFound
                'If tblItem.Rows.Count < intIDSumFound Then
                '    intIDSumFound = CInt(tblItem.Rows.Count)
                'End If
            Else
                intIDSumFound = 0
            End If

            ' Set the strIDs variables to null
            strIDs = ""

            If intIDSumFound > 0 Then
                hidIDs.Value = _strTemp
                ' Get the string of ID found separated by the comma character
                'For intIndex = 0 To intIDSumFound - 1
                '    strIDs = strIDs & tblItem.Rows(intIndex).Item("ID") & ","
                'Next
                'If strIDs <> "" Then
                '    strIDs = Left(strIDs, Len(strIDs) - 1)
                'End If

                'tblItem.Clear()

                ' Get the IDs string (objBItemCollection) 
                objBForming.LibID = clsSession.GlbSite

                objBItemCollection.ItemIDs = objBForming.FormingASQL 'strIDs
                objBItemCollection.LibID = clsSession.GlbSite
                tblItem = objBItemCollection.RetrieveCode_Title

                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBItemCollection.ErrorMsg, ddlLabel.Items(0).Text, objBItemCollection.ErrorCode)

                'tblItem = objBItem.GetCopyNumbers
            End If

            '********************* BEGINDISPLAY THE SEARCH RESULT *******************
            ' Check the Total of rows counted
            If intIDSumFound > 0 Then
                ' Check the Total of rows counted
                EnableControls()
                lblResult.Text = CStr(intIDSumFound)
                dtgResult.Visible = True
                dtgResult.DataSource = tblItem

            Else
                DisableControls()
                dtgResult.Visible = False
            End If
        End Sub

        ' EnableControls function
        ' Purpose: Visible the controls
        Private Sub EnableControls()
            lblCap.Visible = True
            lblCapResult.Visible = True
            lblResult.Visible = True
            lblNotFound.Visible = False
        End Sub

        ' DisableControls function
        ' Purpose: Disable the controls
        Private Sub DisableControls()
            lblCap.Visible = False
            lblCapResult.Visible = False
            lblResult.Visible = False
            lblNotFound.Visible = True
        End Sub

        '' Event: dtgResult_PageIndexChanged
        '' Purpose: Change the page index
        'Private Sub dtgResult_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgResult.PageIndexChanged
        '    dtgResult.CurrentPageIndex = e.NewPageIndex
        '    Call SearchItem(True)
        'End Sub

        ' Event: btnSearch_Click
        ' Purpose: Search the Items for displaying
        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            ' Call the SearchItem method
            dtgResult.CurrentPageIndex = 0
            Call SearchItem()
            dtgResult.Rebind()
        End Sub


        Protected Sub dtgResult_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles dtgResult.NeedDataSource
            SearchItem(False)

        End Sub

        ' Event: dtgResult_ItemCreated
        ' Purpose: Add the javascript for each table row
        'Private Sub dtgResult_ItemCreated(sender As Object, e As GridNeedDataSourceEventArgs) Handles dtgResult.ItemCreated
        '    Dim strJS As String
        '    Select Case e.Item.ItemType
        '        Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
        '            Dim tblCell As TableCell
        '            tblCell = e.Item.Cells(0)
        '            Dim lnk As HyperLink
        '            lnk = CType(tblCell.FindControl("lnkTitle"), HyperLink)
        '            lnk.Font.Bold = True

        '            ' Add the attribute for the hiperlink to modify an item
        '            'lnk.NavigateUrl = "#"

        '            If Trim(CStr(Request("SearchType"))) <> "" Then
        '                strJS = "javascript:opener.document.forms(0).txtItemCode.value = '" & DataBinder.Eval(e.Item.DataItem, "Code") & "';"
        '                strJS = strJS & "opener.document.forms(0).txtItemCode.focus();"
        '                strJS = strJS & "self.close();"
        '                'lnk.Attributes.Add("onclick", strJS)
        '                lnk.NavigateUrl = strJS
        '            Else
        '                If intCheckIn = 1 Then
        '                    lnk.NavigateUrl = "javascript:location.href='WItemDetails.aspx?ItemID=" & DataBinder.Eval(e.Item.DataItem, "ItemID") & "&CheckIn=1';"
        '                    'lnk.Attributes.Add("onclick", "javascript:location.href='WItemDetails.aspx?ItemID=" & DataBinder.Eval(e.Item.DataItem, "ItemID") & "&CheckIn=1';")
        '                Else
        '                    lnk.NavigateUrl = "javascript:location.href='WItemDetails.aspx?ItemID=" & DataBinder.Eval(e.Item.DataItem, "ItemID") & "';"
        '                    'lnk.Attributes.Add("onclick", "javascript:location.href='WItemDetails.aspx?ItemID=" & DataBinder.Eval(e.Item.DataItem, "ItemID") & "';")
        '                End If
        '            End If
        '    End Select
        'End Sub

        ' Event: Page_UnLoad
        ' Purpose: Unload the page and dispose the elements
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: Release all object
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCommonDBSystem Is Nothing Then
                    objBCommonDBSystem.Dispose(True)
                    objBCommonDBSystem = Nothing
                End If
                If Not objBItemCollection Is Nothing Then
                    objBItemCollection.Dispose(True)
                    objBItemCollection = Nothing
                End If
                If Not objBCommonBusiness Is Nothing Then
                    objBCommonBusiness.Dispose(True)
                    objBCommonBusiness = Nothing
                End If
                If Not objBForming Is Nothing Then
                    objBForming.Dispose(True)
                    objBForming = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        Protected Sub dtgResult_ItemCreated(sender As Object, e As GridItemEventArgs) Handles dtgResult.ItemCreated
            Dim strJS As String
            If TypeOf e.Item Is GridDataItem Then
                Dim tblCell As TableCell
                tblCell = e.Item.Cells(0)
                Dim lnk As HyperLink
                lnk = CType(tblCell.FindControl("lnkTitle"), HyperLink)
                lnk.Font.Bold = True

                ' Add the attribute for the hiperlink to modify an item
                'lnk.NavigateUrl = "#"

                If Trim(CStr(Request("SearchType"))) <> "" Then
                    strJS = "javascript:opener.document.forms(0).txtItemCode.value = '" & DataBinder.Eval(e.Item.DataItem, "Code") & "';"
                    strJS = strJS & "opener.document.forms(0).txtItemCode.focus();"
                    strJS = strJS & "self.close();"
                    'lnk.Attributes.Add("onclick", strJS)
                    lnk.NavigateUrl = strJS
                Else
                    If intCheckIn = 1 Then
                        lnk.NavigateUrl = "javascript:location.href='WItemDetails.aspx?ItemID=" & DataBinder.Eval(e.Item.DataItem, "ItemID") & "&CheckIn=1';"
                        'lnk.Attributes.Add("onclick", "javascript:location.href='WItemDetails.aspx?ItemID=" & DataBinder.Eval(e.Item.DataItem, "ItemID") & "&CheckIn=1';")
                    Else
                        lnk.NavigateUrl = "javascript:location.href='WItemDetails.aspx?ItemID=" & DataBinder.Eval(e.Item.DataItem, "ItemID") & "';"
                        'lnk.Attributes.Add("onclick", "javascript:location.href='WItemDetails.aspx?ItemID=" & DataBinder.Eval(e.Item.DataItem, "ItemID") & "';")
                    End If
                End If
            End If

        End Sub

        Public Function NumberOfRecord() As Integer Implements IUCNumberOfRecord.NumberOfRecord
            Return 25
        End Function
    End Class
End Namespace