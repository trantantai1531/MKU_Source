' class WCopyPayPhyType
' Puspose: Management copyright, physical, paymenttype mode
' Creator: Sondp
' CreatedDate: 1/12/2004
' Modification History:
'   - 23/04/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.ILL

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WCopyPayPhyType
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblMainTitlePayment As System.Web.UI.WebControls.Label
        Protected WithEvents lblMainTitlePhyment As System.Web.UI.WebControls.Label
        Protected WithEvents lblMainTitleCopyRightment As System.Web.UI.WebControls.Label
        Protected WithEvents lblNewPaymentEmty As System.Web.UI.WebControls.Label
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblDeleteAlert As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBPayType As New clsBPaymentType
        Private objBCopyRight As New clsBCopyRightCompliance
        Private objBPhyDelMode As New clsBPhysDelMode

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                If Request.QueryString("Mode") & "" = "" Then ' Close current page
                    Page.RegisterClientScriptBlock("CloseJs", "<script language='javascript'>self.close();</script>")
                Else
                    hdMode.Value = UCase(Request.QueryString("Mode"))
                    Call BindData()

                End If
            End If
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            'Quan ly danh muc
            If Not CheckPemission(155) Then
                btnAddnew.Enabled = False
                dgrCopyPayPhyType.Columns(2).Visible = False
                dgrCopyPayPhyType.Columns(3).Visible = False
            End If
            'Nhap moi
            If CheckPemission(207) Then
                btnAddnew.Enabled = True
            End If
            'Xoa
            If CheckPemission(210) Then
                dgrCopyPayPhyType.Columns(3).Visible = True
            End If
            'Sua
            If CheckPemission(209) Then
                dgrCopyPayPhyType.Columns(2).Visible = True
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: Init all neccessary objects
        Private Sub Initialize()
            ' Initialize objBPayType object
            objBPayType.ConnectionString = Session("ConnectionString")
            objBPayType.InterfaceLanguage = Session("InterfaceLanguage")
            objBPayType.DBServer = Session("DBServer")
            Call objBPayType.Initialize()

            ' Initialize objBCopyRight object
            objBCopyRight.ConnectionString = Session("ConnectionString")
            objBCopyRight.InterfaceLanguage = Session("InterfaceLanguage")
            objBCopyRight.DBServer = Session("DBServer")
            Call objBCopyRight.Initialize()

            ' Initialize objBPhyDelMode object
            objBPhyDelMode.ConnectionString = Session("ConnectionString")
            objBPhyDelMode.InterfaceLanguage = Session("InterfaceLanguage")
            objBPhyDelMode.DBServer = Session("DBServer")
            Call objBPhyDelMode.Initialize()
        End Sub

        ' Method: BindScript
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("TempalteJs", "<script language='javascript' src='../JS/ToolsMan/WCopyPayPhyType.js'></script>")
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")

            btnAddnew.Attributes.Add("OnClick", "javascript:return(CheckAddNew('" & ddlLabel.Items(5).Text & "'));")
            btnClose.Attributes.Add("OnClick", "javascript:self.close();")
            txtNewPayment.Attributes.Add("OnChange", "if(this.value.length>50) {alert('" & ddlLabel.Items(17).Text & "'); this.focus(); return false;}")
        End Sub

        ' Method: BindData
        ' Purpose: Load data
        Private Sub BindData()
            Dim tblData As New DataTable

            txtNewPayment.Text = ""
            dgrCopyPayPhyType.Visible = False

            Select Case UCase(hdMode.Value)
                Case "PAYMENTTYPE" ' Payment Type
                    lblMainTitle.Text = ddlLabel.Items(2).Text
                    objBPayType.ID = 0
                    objBPayType.LibID = clsSession.GlbSite
                    tblData = objBPayType.GetPaymentType
                Case "PHYSICAL" ' Physical Mode
                    lblMainTitle.Text = ddlLabel.Items(3).Text
                    objBPhyDelMode.ID = 0
                    objBPhyDelMode.LibID = clsSession.GlbSite
                    tblData = objBPhyDelMode.GetPhyDelMode
                Case Else ' Defaul CopyRight Compliance
                    lblMainTitle.Text = ddlLabel.Items(4).Text
                    objBCopyRight.ID = 0
                    objBCopyRight.LibID = clsSession.GlbSite
                    tblData = objBCopyRight.GetCopyright
            End Select

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCopyRight.ErrorMsg, ddlLabel.Items(0).Text, objBCopyRight.ErrorCode)

            If Not tblData Is Nothing Then
                If tblData.Rows.Count > 0 Then
                    dgrCopyPayPhyType.Visible = True
                    dgrCopyPayPhyType.DataSource = tblData
                    dgrCopyPayPhyType.DataBind()
                End If
            End If
        End Sub

        ' Method: Addnew
        ' In: strMode
        ' Out: boolean
        Public Sub AddNew(ByVal strMode As String)
            Dim intOut As Integer = 0

            Select Case UCase(strMode)
                Case "PAYMENTTYPE" ' Payment Type
                    objBPayType.Type = txtNewPayment.Text
                    objBPayType.LibID = clsSession.GlbSite
                    intOut = objBPayType.Create()
                    ' Check error
                    Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPayType.ErrorMsg, ddlLabel.Items(0).Text, objBPayType.ErrorCode)

                    ' WriteLog
                    Call WriteLog(67, ddlLabel.Items(11).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                Case "PHYSICAL" ' Physical Mode
                    objBPhyDelMode.ModeName = txtNewPayment.Text
                    objBPhyDelMode.LibID = clsSession.GlbSite
                    intOut = objBPhyDelMode.Create()
                    ' Check error
                    Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPhyDelMode.ErrorMsg, ddlLabel.Items(0).Text, objBPhyDelMode.ErrorCode)

                    ' WriteLog
                    Call WriteLog(67, ddlLabel.Items(7).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                Case "COPYRIGHT" ' Copyright Compliance
                    objBCopyRight.Name = txtNewPayment.Text
                    objBCopyRight.LibID = clsSession.GlbSite
                    intOut = objBCopyRight.Create()
                    ' Check error
                    Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCopyRight.ErrorMsg, ddlLabel.Items(0).Text, objBCopyRight.ErrorCode)

                    ' WriteLog
                    Call WriteLog(67, ddlLabel.Items(9).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
            End Select

            If intOut > 0 Then
                Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(13).Text & "')</script>")
            End If
        End Sub

        ' Method: Update
        ' In: intID, strMode, strUpdateType
        ' Out: boolean
        Public Function Update(ByVal strMode As String, ByVal intID As Integer, ByVal strUpdateType As String) As Boolean
            Dim intOut As Integer = 0

            Select Case UCase(strMode)
                Case "PAYMENTTYPE" ' Payment Type
                    objBPayType.ID = intID
                    objBPayType.Type = strUpdateType
                    intOut = objBPayType.Update()

                    ' Check error
                    Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPayType.ErrorMsg, ddlLabel.Items(0).Text, objBPayType.ErrorCode)

                    ' WriteLog
                    Call WriteLog(67, ddlLabel.Items(12).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                Case "PHYSICAL" ' Physical Mode
                    objBPhyDelMode.ID = intID
                    objBPhyDelMode.ModeName = strUpdateType
                    intOut = objBPhyDelMode.Update()

                    ' Check error
                    Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPhyDelMode.ErrorMsg, ddlLabel.Items(0).Text, objBPhyDelMode.ErrorCode)

                    ' WriteLog
                    Call WriteLog(67, ddlLabel.Items(12).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                Case "COPYRIGHT" ' Copyright Compliance
                    objBCopyRight.ID = intID
                    objBCopyRight.Name = strUpdateType
                    intOut = objBCopyRight.Update()

                    ' Check error
                    Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCopyRight.ErrorMsg, ddlLabel.Items(0).Text, objBCopyRight.ErrorCode)

                    ' WriteLog
                    Call WriteLog(67, ddlLabel.Items(12).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
            End Select

            If intOut > 0 Then
                Update = False
                Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(13).Text & "')</script>")
            Else
                Update = True
                Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(14).Text & "')</script>")
            End If
        End Function

        ' Method: Delete
        ' In: strMode, intID
        ' Out: boolean
        Public Sub Delete(ByVal strMode As String, ByVal intID As Integer)
            Dim intOut As Integer
            Select Case UCase(strMode)
                Case "PAYMENTTYPE" ' Payment type
                    objBPayType.ID = intID
                    objBPayType.Type = txtNewPayment.Text.Trim
                    intOut = objBPayType.Delete()

                    ' Check error
                    Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPayType.ErrorMsg, ddlLabel.Items(0).Text, objBPayType.ErrorCode)
                    If intOut = 0 Then
                        Page.RegisterClientScriptBlock("Alert1Msg", "<script language='javascript'>alert('" & ddlLabel.Items(15).Text & "');</script>")
                    Else
                        Page.RegisterClientScriptBlock("Alert2Msg", "<script language='javascript'>alert('" & ddlLabel.Items(18).Text & "');</script>")
                    End If

                    ' WriteLog
                    Call WriteLog(67, ddlLabel.Items(12).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                Case "PHYSICAL" ' Physical Mode
                    objBPhyDelMode.ID = intID
                    objBPhyDelMode.ModeName = txtNewPayment.Text.Trim
                    intOut = objBPhyDelMode.Delete()

                    ' Check error
                    Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPhyDelMode.ErrorMsg, ddlLabel.Items(0).Text, objBPhyDelMode.ErrorCode)
                    If intOut = 0 Then
                        Page.RegisterClientScriptBlock("Alert3Msg", "<script language='javascript'>alert('" & ddlLabel.Items(15).Text & "');</script>")
                    Else
                        Page.RegisterClientScriptBlock("Alert4Msg", "<script language='javascript'>alert('" & ddlLabel.Items(18).Text & "');</script>")
                    End If

                    ' WriteLog
                    Call WriteLog(67, ddlLabel.Items(8).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                Case "COPYRIGHT" ' Copyright Compliance
                    objBCopyRight.ID = intID
                    objBCopyRight.Name = txtNewPayment.Text.Trim
                    intOut = objBCopyRight.Delete()

                    ' Check error
                    Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCopyRight.ErrorMsg, ddlLabel.Items(0).Text, objBCopyRight.ErrorCode)
                    If intOut = 0 Then
                        Page.RegisterClientScriptBlock("Alert5Msg", "<script language='javascript'>alert('" & ddlLabel.Items(15).Text & "');</script>")
                    Else
                        Page.RegisterClientScriptBlock("Alert6Msg", "<script language='javascript'>alert('" & ddlLabel.Items(18).Text & "');</script>")
                    End If

                    ' WriteLog
                    Call WriteLog(67, ddlLabel.Items(10).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
            End Select
            'Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(15).Text & "')</script>")
        End Sub

        ' Event: dgrCopyPayPhyType_ItemCreated
        Private Sub dgrCopyPayPhyType_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrCopyPayPhyType.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                    Dim tblCell As TableCell
                    Dim btnAction As LinkButton

                    tblCell = e.Item.Cells(3)
                    btnAction = tblCell.Controls(0)
                    btnAction.Attributes.Add("Onclick", "swapBG(this,'red'); if (confirm(' " & ddlLabel.Items(6).Text & " ')==false) {swapBG(this,'red');return false}")

                    tblCell = e.Item.Cells(2)
                    btnAction = tblCell.Controls(0)
                    btnAction.Attributes.Add("OnClick", "if (CheckNull(document.forms[0].dgrCopyPayPhyType__ctl" & CStr(e.Item.ItemIndex + 2) & "_txbEntry)) {alert('" & ddlLabel.Items(5).Text & "'); document.forms[0].dgrCopyPayPhyType__ctl" & CStr(e.Item.ItemIndex + 2) & "_txbEntry.focus(); return false;}")
            End Select
        End Sub

        ' Event: dgrCopyPayPhyType_DeleteCommand
        Private Sub dgrCopyPayPhyType_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrCopyPayPhyType.DeleteCommand
            Dim intID As Integer
            Dim txtTextbox As TextBox

            ' Get ID             
            intID = CInt(e.Item.Cells(0).Text)

            'Delete here
            Call Delete(hdMode.Value, intID)

            ' Refresh Data
            dgrCopyPayPhyType.EditItemIndex = -1
            Call BindData()
        End Sub

        ' Event: dgrCopyPayPhyType_EditCommand
        Private Sub dgrCopyPayPhyType_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrCopyPayPhyType.EditCommand
            Dim txtName As New TextBox
            Try
                dgrCopyPayPhyType.EditItemIndex = e.Item.ItemIndex
                Call BindData()
                CType(dgrCopyPayPhyType.Items(dgrCopyPayPhyType.EditItemIndex).Cells(1).Controls(0), TextBox).CssClass = "lbTextBox"
                txtName = CType(dgrCopyPayPhyType.Items(dgrCopyPayPhyType.EditItemIndex).Cells(1).Controls(0), TextBox)
                txtName.Attributes.Add("Onchange", "if (CheckNull(this)) {alert('" & ddlLabel.Items(5).Text & "'); return false;} else {if(this.value.length>50) {alert('" & ddlLabel.Items(17).Text & "'); this.focus(); return false;} };")
            Catch ex As Exception
            End Try
        End Sub

        ' Event: dgrCopyPayPhyType_UpdateCommand
        Private Sub dgrCopyPayPhyType_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrCopyPayPhyType.UpdateCommand
            Dim txtType As TextBox
            Dim intID As Integer
            Try
                ' Get data to update
                txtType = e.Item.Cells(1).Controls(0)
                intID = CInt(e.Item.Cells(0).Text)
                If Update(hdMode.Value, intID, txtType.Text.Trim) Then
                    ' Refresh Data
                    dgrCopyPayPhyType.EditItemIndex = -1
                    Call BindData()
                End If
            Catch ex As Exception
            End Try
        End Sub

        ' Event: dgrCopyPayPhyType_CancelCommand
        Private Sub dgrCopyPayPhyType_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrCopyPayPhyType.CancelCommand
            Try
                dgrCopyPayPhyType.EditItemIndex = -1
                Call BindData()
            Catch ex As Exception
            End Try
        End Sub

        ' Event: btnAddnew_Click
        Private Sub btnAddnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddnew.Click
            Call AddNew(hdMode.Value)
            Try
                ' Refresh data
                dgrCopyPayPhyType.EditItemIndex = -1
                Call BindData()
            Catch ex As Exception
            End Try
        End Sub

        ' Event: Page UnLoad
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBPayType Is Nothing Then
                    objBPayType.Dispose(True)
                    objBPayType = Nothing
                End If
                If Not objBCopyRight Is Nothing Then
                    objBCopyRight.Dispose(True)
                    objBCopyRight = Nothing
                End If
                If Not objBPhyDelMode Is Nothing Then
                    objBPhyDelMode.Dispose(True)
                    objBPhyDelMode = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace