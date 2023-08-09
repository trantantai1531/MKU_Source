Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WSearchCopyNumber
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents btnDelete As System.Web.UI.WebControls.Button
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBCommonDBSystem As New clsBCommonDBSystem
        Private objBItemCollection As New clsBItemCollection
        Private objBCDS As New clsBCommonDBSystem
        Private objBForming As New clsBFormingSQL

        ' Page_load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJavaScript()
        End Sub

        ' Initialze method 
        ' Purpose: Initialize all objects
        Private Sub Initialize()
            ' Init for objBCommon
            objBCommonDBSystem.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonDBSystem.DBServer = Session("DBServer")
            objBCommonDBSystem.ConnectionString = Session("ConnectionString")
            objBCommonDBSystem.Initialize()

            ' Init for objBItemCollection
            objBItemCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemCollection.DBServer = Session("DBServer")
            objBItemCollection.ConnectionString = Session("ConnectionString")
            objBItemCollection.Initialize()

            ' Init for objBCDS
            objBCDS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDS.DBServer = Session("DBServer")
            objBCDS.ConnectionString = Session("ConnectionString")
            objBCDS.Initialize()

            'objBForming
            objBForming.InterfaceLanguage = Session("InterfaceLanguage")
            objBForming.DBServer = Session("DBServer")
            objBForming.ConnectionString = Session("ConnectionString")
            objBForming.Initialize()

            ' Init the style for the elements of datagrid
            DgrResult.HeaderStyle.CssClass = "lbGridHeader"
            DgrResult.PagerStyle.CssClass = "lbGridPager"
            DgrResult.AlternatingItemStyle.CssClass = "lbGridAlterCell"
            DgrResult.ItemStyle.CssClass = "lbGridCell"
            DgrResult.EditItemStyle.CssClass = "lbGridEdit"
        End Sub

        ' BindJavaScript method
        ' Purpose: get the javascripts, add the attributes for the controls
        Private Sub BindJavaScript()
            ' Register the javascipt files
            Page.RegisterClientScriptBlock("CommonJs", "<script language = ""javascript"" src = ""../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & """></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/EData/WSearchCopyNumber.js'></script>")

            ' Add the attributes for the buttons
            btnSearch.Attributes.Add("OnClick", "if(!CheckNullInput('" & ddlLabel.Items(2).Text & "','" & ddlLabel.Items(4).Text & "')) return false;")
            btnReset.Attributes.Add("OnClick", "ResetForm(); return false;")
            btnClose.Attributes.Add("OnClick", "self.close(); return false;")
            btnClose2.Attributes.Add("OnClick", "self.close(); return false;")
        End Sub

        ' SearchItem method
        ' Purpose: Search the Items for deletting
        Private Sub SearchItem()
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
            Dim intIDSumFound As Integer
            Dim intCopyNumSumFound As Integer
            Dim intIndex = 0 ' Use to bound the array
            ' Data Table variable
            Dim tblItem As New DataTable

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
            objBCommonDBSystem.SQLStatement = objBForming.FormingASQL(100)
            tblItem = objBCommonDBSystem.RetrieveItemInfor()
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBCommonDBSystem.ErrorMsg, ddlLabel.Items(1).Text, objBCommonDBSystem.ErrorCode)

            If Not tblItem Is Nothing Then
                intIDSumFound = CInt(tblItem.Rows.Count)

                ' Set the strIDs variables to null
                strIDs = ""

                If intIDSumFound > 0 Then
                    ' Get the string of ID found separated by the comma character
                    For intIndex = 0 To intIDSumFound - 1
                        strIDs = strIDs & tblItem.Rows(intIndex).Item("ID") & ","
                    Next
                    If strIDs <> "" Then
                        strIDs = Left(strIDs, Len(strIDs) - 1)
                    End If

                    tblItem.Clear()

                    ' Get the IDs string (objBItemCollection) 
                    objBItemCollection.ItemIDs = strIDs
                    tblItem = objBItemCollection.RetrieveCode_Title

                    Call WriteErrorMssg(ddlLabel.Items(0).Text, objBItemCollection.ErrorMsg, ddlLabel.Items(1).Text, objBItemCollection.ErrorCode)
                End If

                '********************* BEGINDISPLAY THE SEARCH RESULT *******************
                ' Check the Total of rows counted
                If intIDSumFound > 0 Then
                    ' Check the Total of rows counted
                    If Not tblItem Is Nothing Then
                        If tblItem.Rows.Count > 0 Then
                            EnableControls()
                            lblResult.Text = CStr(intIDSumFound)
                            DgrResult.Visible = True
                            DgrResult.DataSource = tblItem
                            DgrResult.DataBind()
                        Else
                            DisableControls()
                            DgrResult.Visible = False
                        End If
                    Else
                        DisableControls()
                        DgrResult.Visible = False
                    End If
                Else
                    DisableControls()
                    DgrResult.Visible = False
                End If
            Else
                DisableControls()
                DgrResult.Visible = False
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

        ' DgrResult_PageIndexChanged event
        ' Purpose: Change the page index
        Private Sub DgrResult_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DgrResult.PageIndexChanged
            DgrResult.CurrentPageIndex = e.NewPageIndex
            Call SearchItem()
        End Sub

        ' btnSearch_Click event
        ' Purpose: Search the Items for displaying
        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            ' Call the SearchItem method
            DgrResult.CurrentPageIndex = 0
            Call SearchItem()
        End Sub

        ' btnDelete_Click event
        ' Call the Delete method 
        ' DgrResult_ItemCreated event
        ' Purpose: Add the javascript for each table row
        Private Sub DgrResult_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DgrResult.ItemCreated
            Dim strJS As String
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                    Dim tblCell As TableCell
                    tblCell = e.Item.Cells(0)
                    Dim lnk As HyperLink
                    lnk = CType(tblCell.FindControl("lnkTitle"), HyperLink)
                    lnk.Font.Bold = True

                    ' Add the attribute for the hiperlink to modify an item
                    lnk.NavigateUrl = "#"
                    lnk.ToolTip = ddlLabel.Items(3).Text

                    strJS = "javascript:opener.document.forms[0].hidFunc.value = ""Attach"";opener.document.forms[0].hidFolder.value = """ & DataBinder.Eval(e.Item.DataItem, "Code") & """;opener.document.forms[0].submit();self.close();"
                    lnk.Attributes.Add("onclick", strJS)
            End Select
        End Sub

        ' Page_UnLoad event    
        ' Purpose: Unload the page and dispose the elements
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Release all object
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
                If Not objBCDS Is Nothing Then
                    objBCDS.Dispose(True)
                    objBCDS = Nothing
                    objBCDS = Nothing
                End If
                If Not objBForming Is Nothing Then
                    objBForming.Dispose(True)
                    objBForming = Nothing
                    objBForming = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

    End Class
End Namespace
