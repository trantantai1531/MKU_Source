' Class: WRate
' Puspose: management system's currency
' Creator: Lent
' CreatedDate: 07/04/2005
' Modification History:
'   - 11/04/2005 by Oanhtn: review & update
'   - 09/06/2005 by Oanhtn: fix errors

Imports eMicLibAdmin.BusinessRules.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WRate
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
        Dim objBRateMan As New clsBRateMan

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' CheckFormPermission method
        ' Purpose: check the permission of user
        Private Sub CheckFormPermission()
            If Not CheckPemission(111) Then
                dtgContent.Columns(2).Visible = False
            End If
            If Not CheckPemission(184) Then
                btnUpdate.Enabled = False
                dtgContent.Columns(2).Visible = True
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: Init all neccessary objects
        Private Sub Initialize()
            ' Initialize objBRateMan object
            objBRateMan.DBServer = Session("DBServer")
            objBRateMan.ConnectionString = Session("ConnectionString")
            objBRateMan.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBRateMan.Initialize()
        End Sub

        ' Method: BindJS
        ' Purpose: Include all need js functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language='javascript' src='../JS/Accounting/WRate.js'></script>")

            btnReset.Attributes.Add("OnClick", "document.forms[0].txtUnitMoney.value=''; document.forms[0].txtUnitMoney.focus(); document.forms[0].txtRate.value='1'; return false;")
            btnUpdate.Attributes.Add("OnClick", "return(CheckAddNew('" & ddlLabelNote.Items(0).Text & "','" & ddlLabelNote.Items(1).Text & "','" & ddlLabelNote.Items(2).Text & "'));")
            If Not Request("Load") = "" Then
                btnClose.Visible = True
                btnClose.Attributes.Add("OnClick", "opener.document.forms[0].txbFunc.value='ADD'; opener.document.forms[0].submit(); self.close(); return false;")
            Else
                btnClose.Visible = False
            End If

            txtRate.Attributes.Add("OnChange", "if (!CheckNum(this)) {alert('" & ddlLabelNote.Items(1).Text & "');}")
        End Sub

        ' Method: BindData
        ' Purpose: Load data
        Private Sub BindData()
            Dim tblResult As DataTable
            Dim intRow As Integer
            Dim strCurCode As String = ","
            objBRateMan.CurrencyCode = ""
            tblResult = objBRateMan.GetRate

            If (Not tblResult Is Nothing) AndAlso (tblResult.Rows.Count > 0) Then
                For intRow = 0 To tblResult.Rows.Count - 1
                    If intRow <> dtgContent.EditItemIndex Then
                        strCurCode = strCurCode & CStr(tblResult.Rows(intRow).Item("CurrencyCode")) & ","
                    End If
                Next
            End If
            hidCurrencyCode.Value = strCurCode
            dtgContent.DataSource = tblResult
            dtgContent.DataBind()
        End Sub

        ' Event: btnUpdate_Click
        ' Purpose: update currency information
        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            objBRateMan.CurrencyCode = txtUnitMoney.Text.Trim.ToUpper
            objBRateMan.Rate = CDbl(Trim(txtRate.Text))
            Dim intRetVal = objBRateMan.Create()

            If intRetVal = 0 Then ' Success

                ' Write log
                Call WriteLog(102, ddlLabelNote.Items(6).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                ' Alert message
                Page.RegisterClientScriptBlock("AlertJS", "<script language='javascript'>alert('" & ddlLabelNote.Items(8).Text.Trim & "');</script>")

                ' Reload form
                Call BindData()
            Else ' Fail
                ' Alert message
                Page.RegisterClientScriptBlock("AlertJS", "<script language='javascript'>alert('" & ddlLabelNote.Items(2).Text.Trim & "');</script>")
            End If
        End Sub

        ' Event: dtgContent_CancelCommand
        Private Sub dtgContent_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgContent.CancelCommand
            dtgContent.EditItemIndex = -1
            Call BindData()
        End Sub

        ' Event: dtgContent_EditCommand
        Private Sub dtgContent_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgContent.EditCommand
            dtgContent.EditItemIndex = e.Item.ItemIndex
            Call BindData()
        End Sub

        ' Event: dtgContent_ItemCreated
        Private Sub dtgContent_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgContent.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.AlternatingItem, ListItemType.EditItem, ListItemType.Item, ListItemType.Separator
                    Dim lnkdtgUpdatetmp As LinkButton
                    lnkdtgUpdatetmp = CType(e.Item.FindControl("lnkdtgUpdate"), LinkButton)
                    If Not lnkdtgUpdatetmp Is Nothing Then
                        lnkdtgUpdatetmp.Attributes.Add("OnClick", "javascript:return(CheckUpdate('document.forms[0].dtgContent__ctl" & CStr(e.Item.ItemIndex + 2) & "_','" & ddlLabelNote.Items(0).Text & "','" & ddlLabelNote.Items(1).Text & "','" & ddlLabelNote.Items(2).Text & "'));")
                    End If
            End Select
        End Sub

        ' Event: dtgContent_UpdateCommand
        ' Purpose: update information of the current currency
        Private Sub dtgContent_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgContent.UpdateCommand
            Dim txtdtgTemp As TextBox
            Dim strCurrentCode As String = e.Item.Cells(0).Text
            If strCurrentCode = "&nbsp;" Then
                strCurrentCode = ""
            End If

            objBRateMan.CurrencyCode = strCurrentCode
            txtdtgTemp = CType(e.Item.FindControl("txtdtgRate"), TextBox)
            objBRateMan.Rate = CDbl(Trim(txtdtgTemp.Text))
            Dim intRetVal = objBRateMan.Update()

            If intRetVal = 0 Then ' Success

                ' Write log
                Call WriteLog(102, ddlLabelNote.Items(7).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                dtgContent.EditItemIndex = -1

                ' Reload form
                Call BindData()
                ' Alert message
                Page.RegisterClientScriptBlock("AlertJS", "<script language='javascript'>alert('" & ddlLabelNote.Items(8).Text.Trim & "');</script>")

                ' Reload form
                Call BindData()
            Else ' Fail
                ' Alert message
                Page.RegisterClientScriptBlock("AlertJS", "<script language='javascript'>alert('" & ddlLabelNote.Items(2).Text.Trim & "');</script>")
            End If
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBRateMan Is Nothing Then
                    objBRateMan.Dispose(True)
                    objBRateMan = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace