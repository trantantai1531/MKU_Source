Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Circulation

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WPhotocopyManagement
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblDoneORnot As System.Web.UI.WebControls.Label
        Protected WithEvents lblDataPrince As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBPhotoType As New clsBPhotocopyType
        Private objBPhotoTrans As New clsBPhotocopyTransaction
        Private objBBaseTrans As New clsBBaseTransaction

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialze()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call BindDDl()
                Call BindDataGrid("")
            End If
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(150) Then
                btnNew.Enabled = False
                dtgListPhoto.Columns(10).Visible = False
            End If
        End Sub

        ' Method: BindJS
        ' Purpose: Include all need js functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("JSCommon", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("JSSelf", "<script language = 'javascript' src = '../js/Policy/WPhotocopyManagement.js'></script>")

            btnNew.Attributes.Add("onClick", "return ValidNew('" & Left(lblAlert.Text, InStr(lblAlert.Text, "|") - 1) & "')")
            btnReset.Attributes.Add("onClick", "document.forms[0].reset();return false;")

            txtCreatedDate.Attributes.Add("onChange", "javascript:CheckDate(this,'" & Session("DateFormat") & "','" & ddlLabel.Items(7).Text & " (" & Session("DateFormat") & ")');")
            txtCreatedDate.ToolTip = Session("DateFormat")

            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkFromPhoto, txtFromPhoto, ddlLabel.Items(7).Text)
            SetOnclickCalendar(lnkToPhoto, txtToPhoto, ddlLabel.Items(7).Text)
            SetOnclickCalendar(lnkCreatedDate, txtCreatedDate, ddlLabel.Items(7).Text)

            txtPageCount.Attributes.Add("onchange", "if (!CheckNumBer(this,'" & ddlLabel.Items(8).Text & "',0)) return false; SetPricePhoto();")
            Me.SetCheckNumber(txtPaidAmount, ddlLabel.Items(8).Text, "0")
            ddlTypeID.Attributes.Add("onChange", "SetPricePhoto();")
        End Sub

        ' Method: Initialze
        ' Purpose: Include all need objects
        Private Sub Initialze()
            ' Init objBPhotoType object
            objBPhotoType.InterfaceLanguage = Session("InterfaceLanguage")
            objBPhotoType.DBServer = Session("DBServer")
            objBPhotoType.ConnectionString = Session("ConnectionString")
            Call objBPhotoType.Initialize()

            ' Init objBPhotoTrans object
            objBPhotoTrans.InterfaceLanguage = Session("InterfaceLanguage")
            objBPhotoTrans.DBServer = Session("DBServer")
            objBPhotoTrans.ConnectionString = Session("ConnectionString")
            Call objBPhotoTrans.Initialize()

            ' Init objBBaseTrans object
            objBBaseTrans.InterfaceLanguage = Session("InterfaceLanguage")
            objBBaseTrans.DBServer = Session("DBServer")
            objBBaseTrans.ConnectionString = Session("ConnectionString")
            Call objBBaseTrans.Initialize()
        End Sub

        Private Sub BindDDl()
            Dim tblPhotoType As New DataTable
            Dim intCount As Integer
            Dim strPrice As String = ""
            Dim strIDs As String = ""

            txtCreatedDate.Text = Session("ToDay")

            'PhotocopyType
            objBPhotoType.TypeIDs = ""
            tblPhotoType = objBPhotoType.GetPhotocopyTypes
            If Not tblPhotoType Is Nothing Then
                If tblPhotoType.Rows.Count > 0 Then
                    For intCount = 0 To tblPhotoType.Rows.Count - 1
                        strIDs = strIDs & tblPhotoType.Rows(intCount).Item("TypeID") & ";"
                        strPrice = strPrice & CDbl(tblPhotoType.Rows(intCount).Item("PricePerPage")) & ";"
                    Next
                    If strPrice <> "" Then
                        strIDs = Left(strIDs, Len(strIDs) - 1)
                        strPrice = Left(strPrice, Len(strPrice) - 1)
                    End If
                    txtHidDataPrice.Value = strPrice
                    txtHidDataTypeID.Value = strIDs
                    ddlTypeID.DataSource = InsertOneRow(tblPhotoType, ddlLabel.Items(2).Text)

                    ddlTypeID.DataTextField = "TypeName"
                    ddlTypeID.DataValueField = "TypeID"
                    ddlTypeID.DataBind()
                End If
                tblPhotoType = Nothing
            End If
        End Sub

        Private Sub BindDataGrid(ByVal strCardNo As String, Optional ByVal intPage As Integer = 0)
            Dim tblPhotoReq As New DataTable
            Dim strFrom As String
            Dim strTo As String
            strFrom = txtFromPhoto.Text
            strTo = txtToPhoto.Text
            If strCardNo <> "" Then
                txtCardNo.Text = ""
                txtCardNoSearch.Text = strCardNo
            Else
            End If

            objBPhotoTrans.PatronCode = txtCardNoSearch.Text
            objBPhotoTrans.CopyNumber = txtCopyNumSearch.Text
            objBPhotoTrans.Done = ddlDone.SelectedValue
            objBPhotoTrans.Inputer = ""
            objBPhotoTrans.UserID = Session("UserID")
            tblPhotoReq = objBPhotoTrans.GetPhotocopyOrders(strFrom, strTo)
            dtgListPhoto.Visible = False
            lblNothing.Visible = True
            If Not tblPhotoReq Is Nothing Then
                If tblPhotoReq.Rows.Count > 0 Then
                    dtgListPhoto.Visible = True
                    lblNothing.Visible = False
                    dtgListPhoto.DataSource = tblPhotoReq
                    dtgListPhoto.CurrentPageIndex = intPage
                    dtgListPhoto.DataBind()
                End If
                tblPhotoReq = Nothing
            End If
        End Sub

        ' Method: ShowMessagePatron
        ' Purpose: show message when check patron
        Private Sub ShowMessagePatron(ByVal intOutErr As Integer)
            Select Case intOutErr
                Case 0
                    Page.RegisterClientScriptBlock("JSAlert1", "<script language = 'javascript'>alert('" & ddlLabel.Items(12).Text & "')</script>")
                Case 1
                    Page.RegisterClientScriptBlock("JSAlert1", "<script language = 'javascript'>alert('" & ddlLabel.Items(13).Text & "')</script>")
                Case 2
                    Page.RegisterClientScriptBlock("JSAlert1", "<script language = 'javascript'>alert('" & ddlLabel.Items(9).Text & "')</script>")
                Case 3, 6
                    Page.RegisterClientScriptBlock("JSAlert1", "<script language = 'javascript'>alert('" & ddlLabel.Items(10).Text & "')</script>")
                Case 4
                    Page.RegisterClientScriptBlock("JSAlert1", "<script language = 'javascript'>alert('" & ddlLabel.Items(11).Text & "')</script>")
            End Select
        End Sub

        Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
            Dim blnOK As Boolean = True
            Dim intCheckPatronCode As Integer = 0
            Dim intCheckCopyNum As Integer = 0

            objBBaseTrans.UserID = Session("UserID")
            objBBaseTrans.CopyNumber = txtCopyNumber.Text.Trim
            objBBaseTrans.PatronCode = txtCardNo.Text.Trim
            'intCheckCopyNum = objBBaseTrans.CheckCopyNumber
            'If intCheckCopyNum <> 0 Then
            '    blnOK = False
            'End If
            intCheckPatronCode = objBBaseTrans.CheckPatronCode
            If intCheckPatronCode <> 0 Then
                blnOK = False
            End If
            If blnOK Then
                If Trim(txtAmount.Text) = "" Then
                    objBPhotoTrans.Amount = 0
                Else
                    objBPhotoTrans.Amount = txtAmount.Text
                End If
                objBPhotoTrans.PaidAmount = txtPaidAmount.Text
                objBPhotoTrans.PatronCode = txtCardNo.Text
                objBPhotoTrans.Inputer = txtInputer.Text
                objBPhotoTrans.CopyNumber = txtCopyNumber.Text
                objBPhotoTrans.PageCount = txtPageCount.Text
                objBPhotoTrans.PageDetail = txtPageDetail.Text
                objBPhotoTrans.TypePayerID = ddlTypeID.SelectedValue
                If chkDone.Checked Then
                    objBPhotoTrans.Done = 1
                Else
                    objBPhotoTrans.Done = 0
                End If
                objBPhotoTrans.UserID = Session("UserID")
                objBPhotoTrans.CreatePhotocopyOrder(txtCreatedDate.Text)
                ' WriteLog
                Call WriteLog(110, ddlLabel.Items(3).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                txtPageCount.Text = ""
                ddlTypeID.SelectedIndex = 0
                txtCreatedDate.Text = ""
                txtPageDetail.Text = ""
                txtAmount.Text = ""
                txtPaidAmount.Text = 0
                txtCopyNumber.Text = ""
                txtInputer.Text = ""
                'Call BindDataGrid(txtCardNo.Text)
                Call BindDataGrid(Nothing)
            Else
                Call ShowMessagePatron(intCheckPatronCode)
                'If intCheckCopyNum <> 0 Then
                '    Call ShowMessagePatron(0)
                'Else
                '    Call ShowMessagePatron(intCheckPatronCode)
                'End If
            End If
        End Sub

        Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
            Call BindDataGrid("")
        End Sub

        Private Sub dtgListPhoto_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgListPhoto.CancelCommand
            dtgListPhoto.EditItemIndex = -1
            Call BindDataGrid("", dtgListPhoto.CurrentPageIndex)
        End Sub

        Private Sub dtgListPhoto_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgListPhoto.EditCommand
            Dim tblTemp As DataTable
            Dim ddlTypeID As New DropDownList
            Dim intIndex As Integer
            Dim intCount As Integer
            Dim strTypeID As String

            intIndex = CInt(e.Item.ItemIndex)
            dtgListPhoto.EditItemIndex = intIndex
            Call BindDataGrid("", dtgListPhoto.CurrentPageIndex)
            ' Load all Controls to DataGrid
            ddlTypeID = CType(dtgListPhoto.Items(intIndex).Cells(9).FindControl("ddlTypeIDGrid"), DropDownList)
            strTypeID = CType(dtgListPhoto.Items(intIndex).Cells(9).FindControl("txtTypeIDHid"), TextBox).Text
            tblTemp = objBPhotoType.GetPhotocopyTypes
            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    ddlTypeID.DataSource = tblTemp
                    ddlTypeID.DataTextField = "TypeName"
                    ddlTypeID.DataValueField = "TypeID"
                    ddlTypeID.DataBind()
                    For intCount = 0 To ddlTypeID.Items.Count - 1
                        If CStr(ddlTypeID.Items(intCount).Value) = strTypeID Then
                            ddlTypeID.Items(intCount).Selected = True
                        Else
                            ddlTypeID.Items(intCount).Selected = False
                        End If
                    Next
                End If
                tblTemp = Nothing
            End If
        End Sub

        Private Sub dtgListPhoto_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgListPhoto.UpdateCommand
            Dim ddlTypeID As New DropDownList
            Dim strCopyNumber As String
            Dim strPatronCode As String
            Dim strAmount As String
            Dim strPaidAmount As String
            Dim bytDone As Byte
            Dim strPageCount As String
            Dim strPageDetail As String
            Dim intTypeID As Integer
            Dim intIndex As Integer
            Dim intID As Integer
            Dim blnValid As Boolean = True
            Dim intCheckPatronCode As Integer = 0
            Dim intCheckCopyNum As Integer = 0

            intIndex = e.Item.ItemIndex

            intID = CInt(CType(dtgListPhoto.Items(intIndex).Cells(0).FindControl("lblID"), Label).Text)
            strPatronCode = CType(dtgListPhoto.Items(intIndex).Cells(1).FindControl("txtPatronCodeGrid"), TextBox).Text
            strCopyNumber = CType(dtgListPhoto.Items(intIndex).Cells(2).FindControl("txtCopyNumberGrid"), TextBox).Text
            strPageCount = CType(dtgListPhoto.Items(intIndex).Cells(3).FindControl("txtPageCountGrid"), TextBox).Text
            strAmount = CType(dtgListPhoto.Items(intIndex).Cells(5).FindControl("txtAmountGrid"), TextBox).Text
            strPaidAmount = CType(dtgListPhoto.Items(intIndex).Cells(6).FindControl("txtPaidAmountGrid"), TextBox).Text
            If CType(dtgListPhoto.Items(intIndex).Cells(7).FindControl("chkDoneGrid"), CheckBox).Checked Then
                bytDone = 1
            Else
                bytDone = 0
            End If
            strPageDetail = CType(dtgListPhoto.Items(intIndex).Cells(8).FindControl("txtPageDetailGrid"), TextBox).Text
            If CType(dtgListPhoto.Items(intIndex).Cells(9).FindControl("ddlTypeIDGrid"), DropDownList).SelectedValue <> "" Then
                intTypeID = CInt(CType(dtgListPhoto.Items(intIndex).Cells(9).FindControl("ddlTypeIDGrid"), DropDownList).SelectedValue)
            Else
                intTypeID = 0
            End If
            If strCopyNumber = "" Or strPatronCode = "" Or strPageCount = "" Or strAmount = "" Or strPaidAmount = "" Then
                blnValid = False
            Else
                ' check numeric
                If (Not IsNumeric(strPageCount)) Or (Not IsNumeric(strAmount)) Or (Not IsNumeric(strPaidAmount)) Then
                    blnValid = False
                End If
                ' check CardNo and CopyNumber
                Dim blnOK As Boolean = True
                objBBaseTrans.UserID = Session("UserID")
                objBBaseTrans.CopyNumber = strCopyNumber
                objBBaseTrans.PatronCode = strPatronCode
                intCheckCopyNum = objBBaseTrans.CheckCopyNumber
                If intCheckCopyNum <> 0 Then
                    blnOK = False
                End If
                intCheckPatronCode = objBBaseTrans.CheckPatronCode
                If intCheckPatronCode <> 0 Then
                    blnOK = False
                End If
                blnValid = blnOK
            End If
            If blnValid Then
                objBPhotoTrans.PatronCode = strPatronCode
                objBPhotoTrans.TransactionID = intID
                objBPhotoTrans.Amount = CDbl(strAmount)
                objBPhotoTrans.PaidAmount = CDbl(strPaidAmount)
                objBPhotoTrans.PageDetail = strPageDetail
                objBPhotoTrans.PageCount = CInt(strPageCount)
                objBPhotoTrans.CopyNumber = strCopyNumber
                objBPhotoTrans.Done = bytDone
                objBPhotoTrans.TypePayerID = intTypeID
                objBPhotoTrans.UpdatePhotocopyOrder()
                ' WriteLog
                Call WriteLog(110, ddlLabel.Items(4).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                objBPhotoTrans.TransactionID = 0
                dtgListPhoto.EditItemIndex = -1
                Call BindDataGrid("", dtgListPhoto.CurrentPageIndex)
                Page.RegisterClientScriptBlock("JSAlert2", "<script language = 'javascript'>alert('" & ddlLabel.Items(6).Text & "')</script>")
            Else
                If intCheckCopyNum <> 0 Then
                    Call ShowMessagePatron(0)
                Else
                    Call ShowMessagePatron(intCheckPatronCode)
                End If
            End If
        End Sub

        Private Sub ddlTypeID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlTypeID.SelectedIndexChanged
            Dim tblTypeID As New DataTable
            Dim intPageCount As Integer = 0
            objBPhotoType.TypeIDs = ddlTypeID.SelectedValue
            tblTypeID = objBPhotoType.GetPhotocopyTypes

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPhotoType.ErrorMsg, ddlLabel.Items(0).Text, objBPhotoType.ErrorCode)

            If Not tblTypeID Is Nothing Then
                If tblTypeID.Rows.Count > 0 Then
                    If IsNumeric(txtPageCount.Text) Then
                        intPageCount = txtPageCount.Text
                    Else
                        intPageCount = 0
                    End If
                    txtAmount.Text = CDbl(intPageCount * tblTypeID.Rows(0).Item("PricePerPage"))
                Else
                    txtAmount.Text = "0"
                End If
                tblTypeID = Nothing
            End If
        End Sub

        Private Sub txtPageCount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim tblTypeID As New DataTable
            Dim intPageCount As Integer = 0
            objBPhotoType.TypeIDs = ddlTypeID.SelectedValue
            tblTypeID = objBPhotoType.GetPhotocopyTypes
            If Not tblTypeID Is Nothing Then
                If tblTypeID.Rows.Count > 0 Then
                    If IsNumeric(txtPageCount.Text) Then
                        intPageCount = txtPageCount.Text
                    Else
                        intPageCount = 0
                    End If
                    txtAmount.Text = CDbl(intPageCount * tblTypeID.Rows(0).Item("PricePerPage"))
                Else
                    txtAmount.Text = "0"
                End If
                tblTypeID = Nothing
            End If
        End Sub

        ' Method: PopulateTypeID
        Public Sub PopulateTypeID(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim ddlTypeIDTemp As New DropDownList
            Dim txtPgcountTemp As New TextBox
            Dim intPgCount As Integer
            Dim tblTypeID As New DataTable
            Dim txtAmountTemp As New TextBox

            txtPgcountTemp = CType(dtgListPhoto.Items.Item(dtgListPhoto.EditItemIndex).FindControl("txtPageCountGrid"), TextBox)
            ddlTypeIDTemp = CType(dtgListPhoto.Items.Item(dtgListPhoto.EditItemIndex).FindControl("ddlTypeIDGrid"), DropDownList)
            txtAmountTemp = CType(dtgListPhoto.Items.Item(dtgListPhoto.EditItemIndex).FindControl("txtAmountGrid"), TextBox)

            If Trim(txtPgcountTemp.Text) <> "" Then
                intPgCount = CInt(txtPgcountTemp.Text)
            Else
                intPgCount = 0
            End If
            If ddlTypeIDTemp.SelectedValue <> "" Then
                objBPhotoType.TypeIDs = ddlTypeIDTemp.SelectedValue
            Else
                objBPhotoType.TypeIDs = "0"
            End If
            tblTypeID = objBPhotoType.GetPhotocopyTypes
            If Not tblTypeID Is Nothing Then
                If tblTypeID.Rows.Count > 0 Then
                    txtAmountTemp.Text = CDbl(intPgCount * tblTypeID.Rows(0).Item("PricePerPage"))
                Else
                    txtAmountTemp.Text = "0"
                End If
            End If
        End Sub

        ' Event: dtgListPhoto_ItemCreated
        Private Sub dtgListPhoto_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgListPhoto.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.EditItem, ListItemType.Item, ListItemType.SelectedItem
                    Dim txtTemp As TextBox
                    Dim lnkdtgTemp As LinkButton

                    txtTemp = e.Item.FindControl("txtPageCountGrid")
                    If Not txtTemp Is Nothing Then
                        txtTemp.Attributes.Add("onChange", "if(!CheckNumBer(this,'" & ddlLabel.Items(8).Text & "')) return false;")

                        txtTemp = e.Item.FindControl("txtPaidAmountGrid")
                        txtTemp.Attributes.Add("onChange", "CheckNumBer(this,'" & ddlLabel.Items(8).Text & "');")


                        lnkdtgTemp = CType(e.Item.Cells(10).Controls(0), LinkButton)

                        If Not lnkdtgTemp Is Nothing Then
                            lnkdtgTemp.Attributes.Add("onclick", "javascript:return(CheckUpdate('document.forms[0].dtgListPhoto__ctl" & CStr(e.Item.ItemIndex + 3) & "_','" & lblAlert.Text & "'));")
                        End If

                    End If
            End Select
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBPhotoTrans Is Nothing Then
                    objBPhotoTrans.Dispose(True)
                    objBPhotoTrans = Nothing
                End If
                If Not objBPhotoType Is Nothing Then
                    objBPhotoType.Dispose(True)
                    objBPhotoType = Nothing
                End If
                If Not objBBaseTrans Is Nothing Then
                    objBBaseTrans.Dispose(True)
                    objBBaseTrans = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

    End Class
End Namespace