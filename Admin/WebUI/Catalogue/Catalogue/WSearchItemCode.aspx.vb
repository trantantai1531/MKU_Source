' Class: WSearchItemCode
' Purpose: Search an Item's code title to delete
' Creater: lenta
' CreatedDate: 7/6/2006
' Modify history:
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.BusinessRules.Circulation

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WSearchItemCode
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
        Private objBCDBS As New clsBCommonDBSystem
        Private objBFormingSQL As New clsBFormingSQL
        Private objBItemCollection As New clsBItemCollection
        Private objBCommon As New clsBCommonBusiness

        ' Page_load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPemission()
            Call Initialize()
            If Not IsPostBack Then
                Call BindData()
            End If
            Call BindJS()
        End Sub

        ' Initialze method 
        ' Purpose: Initialize all objects
        Private Sub Initialize()
            ' Init BCommonBusiness object
            objBCommon.DBServer = Session("DBServer")
            objBCommon.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommon.ConnectionString = Session("ConnectionString")
            Call objBCommon.Initialize()

            ' Init for objBCommon
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            Call objBCDBS.Initialize()

            ' Init for objBFormingSQL
            objBFormingSQL.InterfaceLanguage = Session("InterfaceLanguage")
            objBFormingSQL.DBServer = Session("DBServer")
            objBFormingSQL.ConnectionString = Session("ConnectionString")
            Call objBFormingSQL.Initialize()

            'objBItemCollection
            objBItemCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemCollection.DBServer = Session("DBServer")
            objBItemCollection.ConnectionString = Session("ConnectionString")
            objBItemCollection.IsAuthority = Session("IsAuthority")
            Call objBItemCollection.Initialize()
        End Sub

        ' CheckFormPemission method
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            If Not CheckPemission(3) Then
                Me.WriteErrorMssg(ddlLabel.Items(4).Text)
            End If
        End Sub

        Private Sub BindData()
            Dim tblTemp As New DataTable

            ' Item type
            tblTemp = objBCommon.GetItemTypes()
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                tblTemp = InsertOneRow(tblTemp, "----Chọn----")
                ddlItemType.DataSource = tblTemp
                ddlItemType.DataTextField = "Type"
                ddlItemType.DataValueField = "TypeCode"
                ddlItemType.DataBind()
            End If
        End Sub

        ' BindJS method
        ' Purpose: get the javascripts, add the attributes for the controls
        Private Sub BindJS()
            Dim strJSSearch As String

            ' Register the javascipt files
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>", False)
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "SelfJs", "<script language = 'javascript' src = '../js/Catalogue/WDeleteItem.js?t=" & String.Format("{0:yyyyMMddHHmmss}", Date.Now) & "'></script>", False)

            ' Get the js script strings
            strJSSearch = "if(!CheckNullAll('" & ddlLabel.Items(0).Text & "')) return false;"
            ' Add the attributes for the buttons
            btnSearch.Attributes.Add("onClick", strJSSearch)
            btnReset.Attributes.Add("OnClick", "return ResetFormSearch();")
        End Sub

        ' SearchItem method
        ' Purpose: Search the Items for deletting
        Private Sub SearchItem(Optional ByVal blnPageChange As Boolean = False)
            Dim intCount As Integer = 0 ' Use to count the number of checked Item to delete
            Dim intSumFound As Integer
            Dim intIndex = 0 ' Use to bound the array
            ' Data Table variable
            Dim tblItem As New DataTable

            DgrResult.DataSource = Nothing
            DgrResult.DataBind()
            objBItemCollection.LibID = clsSession.GlbSite
            If blnPageChange AndAlso hidIDs.Value <> "" Then
                objBItemCollection.ItemIDs = hidIDs.Value
                tblItem = objBItemCollection.RetrieveCode_Title(ddlItemInfor.SelectedValue)
                '********************* BEGINDISPLAY THE SEARCH RESULT *******************
                If Not tblItem Is Nothing AndAlso tblItem.Rows.Count > 0 Then
                    intCount = Math.Ceiling(tblItem.Rows.Count / DgrResult.PageSize)
                    If DgrResult.CurrentPageIndex >= intCount Then
                        DgrResult.CurrentPageIndex = DgrResult.CurrentPageIndex - 1
                    End If
                    DgrResult.DataSource = tblItem
                    DgrResult.DataBind()
                End If
                Exit Sub
            End If
            ' Add to the arrays new elements if the text boxes is not null
            ' Arrays
            Dim arrBool() As String = Nothing
            Dim arrVal() As String = Nothing
            Dim arrField() As String = Nothing

            If ddlItemInfor.SelectedValue > 0 Then
                If Trim(txtTitle.Text) = "" Then
                    ReDim Preserve arrBool(intIndex)
                    ReDim Preserve arrField(intIndex)
                    ReDim Preserve arrVal(intIndex)
                    arrBool(intIndex) = "AND"
                    arrField(intIndex) = "TI"
                    arrVal(intIndex) = Trim("%")
                    intIndex = intIndex + 1
                Else
                    ReDim Preserve arrBool(intIndex)
                    ReDim Preserve arrField(intIndex)
                    ReDim Preserve arrVal(intIndex)
                    arrBool(intIndex) = "AND"
                    arrField(intIndex) = "TI"
                    arrVal(intIndex) = Trim(txtTitle.Text)
                    intIndex = intIndex + 1
                End If
            Else
                If Not Trim(txtTitle.Text) = "" Then
                    ReDim Preserve arrBool(intIndex)
                    ReDim Preserve arrField(intIndex)
                    ReDim Preserve arrVal(intIndex)
                    arrBool(intIndex) = "AND"
                    arrField(intIndex) = "TI"
                    arrVal(intIndex) = Trim(txtTitle.Text)
                    intIndex = intIndex + 1
                End If
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

            If ddlItemType.SelectedIndex > 0 Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrField(intIndex)
                ReDim Preserve arrVal(intIndex)
                arrBool(intIndex) = "AND"
                arrField(intIndex) = "IT"
                arrVal(intIndex) = ddlItemType.SelectedValue
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
            If Not Trim(txtItemCode.Text) = "" Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrField(intIndex)
                ReDim Preserve arrVal(intIndex)
                arrBool(intIndex) = "AND"
                arrField(intIndex) = "BI"
                arrVal(intIndex) = Trim(txtItemCode.Text)
                intIndex = intIndex + 1
            End If

            ' Add to the arrays in objBFormingSQL the new arrays from the module
            objBFormingSQL.FieldArr = arrField
            objBFormingSQL.ValArr = arrVal
            objBFormingSQL.BoolArr = arrBool

            ' Formming the SQL statement
            objBFormingSQL.LibID = clsSession.GlbSite
            objBCDBS.SQLStatement = objBFormingSQL.FormingASQL()
            Dim _strTemp As String = objBCDBS.SQLStatement
            hidIDs.Value = _strTemp
            objBItemCollection.ItemIDs = _strTemp
            'E2
            tblItem = objBItemCollection.RetrieveCode_Title(ddlItemInfor.SelectedValue)
            DisableControls()
            If Not tblItem Is Nothing AndAlso tblItem.Rows.Count > 0 Then
                intSumFound = tblItem.Rows.Count
                EnableControls()
                lblResult.Text = intSumFound

                intCount = Math.Ceiling(tblItem.Rows.Count / DgrResult.PageSize)
                If DgrResult.CurrentPageIndex >= intCount Then
                    DgrResult.CurrentPageIndex = DgrResult.CurrentPageIndex - 1
                End If
                DgrResult.DataSource = tblItem
                DgrResult.DataBind()
            End If
        End Sub

        ' EnableControls function
        ' Purpose: Visible the controls
        Private Sub EnableControls()
            lblCap.Visible = True
            lblCapResult.Visible = True
            lblResult.Visible = True
            lblNotFound.Visible = False
            DgrResult.Visible = True
        End Sub

        ' DisableControls function
        ' Purpose: Disable the controls
        Private Sub DisableControls()
            lblCap.Visible = False
            lblCapResult.Visible = False
            lblResult.Visible = False
            lblNotFound.Visible = True
            DgrResult.Visible = False
        End Sub

        ' DgrResult_PageIndexChanged event
        ' Purpose: Change the page index
        Private Sub DgrResult_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DgrResult.PageIndexChanged
            DgrResult.CurrentPageIndex = e.NewPageIndex
            Call SearchItem(True)
        End Sub

        ' btnSearch_Click event
        ' Purpose: Search the Items for displaying
        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            ' Call the SearchItem method
            DgrResult.CurrentPageIndex = 0
            Call SearchItem()
        End Sub

        ' DgrResult_ItemCreated event
        ' Purpose: Add the javascript for each table row
        Private Sub DgrResult_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DgrResult.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.SelectedItem, ListItemType.AlternatingItem
                    Dim lnkTemp As HyperLink
                    lnkTemp = CType(e.Item.FindControl("lnkItemCode"), HyperLink)
                    If Not lnkTemp Is Nothing Then
                        lnkTemp.NavigateUrl = "#"
                        lnkTemp.Attributes.Add("onClick", "FindGotoModify(" & DataBinder.Eval(e.Item.DataItem, "ItemID") & ");")
                    End If
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
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBFormingSQL Is Nothing Then
                    objBFormingSQL.Dispose(True)
                    objBFormingSQL = Nothing
                End If
                If Not objBItemCollection Is Nothing Then
                    objBItemCollection.Dispose(True)
                    objBItemCollection = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click

            Dim intCount As Integer = 0 ' Use to count the number of checked Item to delete
            Dim intSumFound As Integer
            Dim intIndex = 0 ' Use to bound the array
            ' Data Table variable
            Dim tblItem As New DataTable

            Dim arrBool() As String = Nothing
            Dim arrVal() As String = Nothing
            Dim arrField() As String = Nothing

            If ddlItemInfor.SelectedValue > 0 Then
                If Trim(txtTitle.Text) = "" Then
                    ReDim Preserve arrBool(intIndex)
                    ReDim Preserve arrField(intIndex)
                    ReDim Preserve arrVal(intIndex)
                    arrBool(intIndex) = "AND"
                    arrField(intIndex) = "TI"
                    arrVal(intIndex) = Trim("%")
                    intIndex = intIndex + 1
                Else
                    ReDim Preserve arrBool(intIndex)
                    ReDim Preserve arrField(intIndex)
                    ReDim Preserve arrVal(intIndex)
                    arrBool(intIndex) = "AND"
                    arrField(intIndex) = "TI"
                    arrVal(intIndex) = Trim(txtTitle.Text)
                    intIndex = intIndex + 1
                End If
            Else
                If Not Trim(txtTitle.Text) = "" Then
                    ReDim Preserve arrBool(intIndex)
                    ReDim Preserve arrField(intIndex)
                    ReDim Preserve arrVal(intIndex)
                    arrBool(intIndex) = "AND"
                    arrField(intIndex) = "TI"
                    arrVal(intIndex) = Trim(txtTitle.Text)
                    intIndex = intIndex + 1
                End If
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
            If Not Trim(txtItemCode.Text) = "" Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrField(intIndex)
                ReDim Preserve arrVal(intIndex)
                arrBool(intIndex) = "AND"
                arrField(intIndex) = "BI"
                arrVal(intIndex) = Trim(txtItemCode.Text)
                intIndex = intIndex + 1
            End If

            ' Add to the arrays in objBFormingSQL the new arrays from the module
            objBFormingSQL.FieldArr = arrField
            objBFormingSQL.ValArr = arrVal
            objBFormingSQL.BoolArr = arrBool

            ' Formming the SQL statement
            objBFormingSQL.LibID = clsSession.GlbSite
            objBCDBS.SQLStatement = objBFormingSQL.FormingASQL()
            Dim _strTemp As String = objBCDBS.SQLStatement
            hidIDs.Value = _strTemp
            objBItemCollection.ItemIDs = _strTemp
            'E2
            tblItem = objBItemCollection.RetrieveCode_Title(ddlItemInfor.SelectedValue)
            If Not tblItem Is Nothing AndAlso tblItem.Rows.Count > 0 Then
                Dim tblResult As DataTable = ConvertTable(tblItem)
                Dim strHTMLContent As New StringBuilder()
                strHTMLContent.Append(clsBExportHelper.GenDataTableToString(tblResult, "Tìm kiếm biểu ghi biên mục"))
                clsExport.StringBuilderToExcel(strHTMLContent)
            Else
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "NoDataExport", "alert('Không có dữ liệu để xuất!')", True)
            End If
        End Sub

        Public Function ConvertTable(
                                              ByVal tblResult As DataTable
                                              ) As DataTable
            If (Not IsNothing(tblResult)) AndAlso (tblResult.Rows.Count > 0) Then
                Dim tblConvert As New DataTable
                tblConvert.Columns.Add("Code")
                tblConvert.Columns.Add("Title")
                For Each row As DataRow In tblResult.Rows
                    Dim dtRow As DataRow = tblConvert.NewRow()
                    dtRow.Item("Code") = row("Code").ToString()
                    'dtRow.Item("Title") = clsBDHVLStatistic.GetLibFieldContent(row("Title").ToString(), "a")
                    dtRow.Item("Title") = row("Title").ToString()
                    tblConvert.Rows.Add(dtRow)
                Next
                tblConvert.Rows.Add(
                            "Mã tài liệu",
                            "Nhan đề"
                        )
                tblResult = tblConvert
            End If
            Return tblResult
        End Function
    End Class
End Namespace

