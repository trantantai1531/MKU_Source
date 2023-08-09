Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WDeleteItem
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

        ' Page_load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPemission()
            Call Initialize()
            Call BindJS()
        End Sub

        ' Initialze method 
        ' Purpose: Initialize all objects
        Private Sub Initialize()
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
            If Not CheckPemission(4) Then
                btnDelete.Enabled = False
            End If
        End Sub

        ' BindJS method
        ' Purpose: get the javascripts, add the attributes for the controls
        Private Sub BindJS()
            Dim strJSConfirm As String
            Dim strJSCheckDel As String
            Dim strJSSearch As String

            ' Register the javascipt files
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/Catalogue/WDeleteItem.js?t=" & String.Format("{0:yyyyMMddHHmmss}", Date.Now) & "'></script>")

            ' Get the js script strings
            strJSConfirm = "return ConfirmDelete('" & ddlLabel.Items(1).Text & "');"
            strJSSearch = "if(!CheckNullInput('" & ddlLabel.Items(0).Text & "')) return false;"
            strJSCheckDel = "if(!CheckOptionsNull('DgrResult', 'CheckItemID', 3, 20, '" & ddlLabel.Items(3).Text & "')) return false;"

            ' Add the attributes for the buttons
            btnSearch.Attributes.Add("onClick", strJSSearch)
            btnDelete.Attributes.Add("onClick", strJSCheckDel & " else " & strJSConfirm)
            btnReset.Attributes.Add("OnClick", "return ResetForm();")
        End Sub

        Public Function Disabled(ByVal state As String) As String
            If state = 1 Then
                Return "disabled"
            End If
            Return ""
        End Function

        ' SearchItem method
        ' Purpose: Search the Items for deletting
        Private Sub SearchItem(Optional ByVal blnPageChange As Boolean = False)
            ' Strings
            Dim intCount As Integer = 0 ' Use to count the number of checked Item to delete
            Dim intSumFound As Integer
            Dim intIndex = 0 ' Use to bound the array
            ' Data Table variable
            Dim tblItem As New DataTable

            Dim arrBool() As String = Nothing
            Dim arrVal() As String = Nothing
            Dim arrField() As String = Nothing

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
            'If Not Trim(txtCopyNumber.Text) = "" Then
            '    ReDim Preserve arrBool(intIndex)
            '    ReDim Preserve arrField(intIndex)
            '    ReDim Preserve arrVal(intIndex)
            '    arrBool(intIndex) = "AND"
            '    arrField(intIndex) = "BN"
            '    arrVal(intIndex) = Trim(txtCopyNumber.Text)
            '    intIndex = intIndex + 1
            'End If
            If Not Trim(txtISBN.Text) = "" Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrField(intIndex)
                ReDim Preserve arrVal(intIndex)
                arrBool(intIndex) = "AND"
                arrField(intIndex) = "IB"
                arrVal(intIndex) = Trim(txtISBN.Text)
                intIndex = intIndex + 1
            End If
            If txtItemCode.Text <> "" Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrField(intIndex)
                ReDim Preserve arrVal(intIndex)
                arrBool(intIndex) = "AND"
                arrField(intIndex) = "BI"
                arrVal(intIndex) = Trim(txtItemCode.Text)
                intIndex = intIndex + 1
            End If
            If txtCopyNumber.Text.Trim <> "" Then
                ReDim Preserve arrBool(intIndex)
                ReDim Preserve arrField(intIndex)
                ReDim Preserve arrVal(intIndex)
                arrBool(intIndex) = "AND"
                arrField(intIndex) = "BN"
                arrVal(intIndex) = Trim(txtCopyNumber.Text)
                intIndex = intIndex + 1
            End If
            ' Add to the arrays in objBFormingSQL the new arrays from the module
            objBFormingSQL.FieldArr = arrField
            objBFormingSQL.ValArr = arrVal
            objBFormingSQL.BoolArr = arrBool

            ' Formming the SQL statement
            objBFormingSQL.LibID = clsSession.GlbSite
            Dim strSQL As String = objBFormingSQL.FormingASQL()

            tblItem = objBItemCollection.GetHoldingDel(strSQL)
            '********************* BEGINDISPLAY THE SEARCH RESULT *******************
            If Not tblItem Is Nothing Then
                If tblItem.Rows.Count > 0 Then
                    intSumFound = tblItem.Rows.Count

                    ' Check the Total of rows counted
                    If intSumFound > 0 Then
                        EnableControls()
                        lblResult.Text = intSumFound
                    Else
                        DisableControls()
                    End If
                    intCount = Math.Ceiling(tblItem.Rows.Count / DgrResult.PageSize)
                    If DgrResult.CurrentPageIndex >= intCount Then
                        DgrResult.CurrentPageIndex = DgrResult.CurrentPageIndex - 1
                    End If

                    DgrResult.DataSource = tblItem
                    DgrResult.DataBind()
                    objBItemCollection.TypeItem = 0
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), "LoadTotal", "<script language='javascript'>parent.Menu.document.forms[0].txtTotalItem.value=" & objBItemCollection.GetRangeItemID.Rows(0).Item("Total") & "</script>", False)

                    ' If no check boxes appear
                    If intCount <> 0 Then
                        btnDelete.Visible = True
                    Else
                        btnDelete.Visible = False
                    End If
                Else
                    btnDelete.Visible = False
                    DisableControls()
                End If
            Else
                btnDelete.Visible = False
                DisableControls()
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
            DgrResult.Visible = True
            DgrResult.CurrentPageIndex = 0
            Call SearchItem()
        End Sub

        ' btnDelete_Click event
        ' Call the Delete method 
        Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            Dim dtgItem As DataGridItem
            Dim chkSelected As HtmlInputCheckBox
            Dim strSelectedIDs As String
            Dim intCount As Integer = 0

            ' Return the IDs string for deletting
            For Each dtgItem In DgrResult.Items
                chkSelected = dtgItem.FindControl("CheckItemID")
                If chkSelected.Checked Then
                    strSelectedIDs = strSelectedIDs & CType(dtgItem.FindControl("LblID"), Label).Text & ", "
                    intCount = intCount + 1
                End If
            Next

            ' If checked, delete
            If strSelectedIDs <> "" Then
                strSelectedIDs = Left(strSelectedIDs, strSelectedIDs.Length - 2)
                objBItemCollection.IsAuthority = 0
                objBItemCollection.ItemIDs = strSelectedIDs
                objBItemCollection.DeleteItem()
                Call WriteLog(12, ddlLabel.Items(6).Text & " (" & intCount & " " & ddlLabel.Items(7).Text & ") ", Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                Page.RegisterClientScriptBlock("DeleteResult", "<script language='javascript'>alert('" & ddlLabel.Items(2).Text & "');</script>")
                Call SearchItem(True)
            End If
        End Sub

        ' DgrResult_ItemCreated event
        ' Purpose: Add the javascript for each table row
        Private Sub DgrResult_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DgrResult.ItemCreated
            Dim intIndex As Int16 = e.Item.ItemIndex + 3
            Dim inti As Integer
            For inti = 0 To e.Item.Cells.Count - 2
                e.Item.Cells(inti).Attributes.Add("onClick", "javascript:CheckOptionVisible('DgrResult','CheckItemID'," & e.Item.ItemIndex + 3 & ");")
            Next
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

        Private Sub DgrResult_ItemDataBound(sender As Object, e As DataGridItemEventArgs) Handles DgrResult.ItemDataBound
            If (e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem) AndAlso e.Item.DataItem("State") = "1" Then
                Dim checkbox As HtmlInputCheckBox = DirectCast(e.Item.FindControl("CheckItemID"), HtmlInputCheckBox)
                checkbox.Visible = False
            End If
        End Sub
    End Class
End Namespace