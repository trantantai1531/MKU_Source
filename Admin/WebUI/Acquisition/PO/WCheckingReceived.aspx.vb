' class: WCheckingReveived
' Puspose: Checking Received items
' Creator: Sondp
' CreatedDate: 11/04/2005
' Modification History:
'   - 14/04/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WCheckingReceived
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblNumericAlert As System.Web.UI.WebControls.Label
        Protected WithEvents lblLessThan As System.Web.UI.WebControls.Label
        Protected WithEvents lbl As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private objBPO As New clsBPurchaseOrder

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            If Not Page.IsPostBack Then
                hidContractID.Value = Request.QueryString("ContractID")
                Call BindData()
            End If
            Call BindJS()
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(41) Then
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: init objects
        Private Sub Initialize()
            ' Initialize objBPO object
            objBPO.InterfaceLanguage = Session("InterfaceLanguage")
            objBPO.DBServer = Session("DBServer")
            objBPO.ConnectionString = Session("ConnectionString")
            Call objBPO.Initialize()
        End Sub

        ' Method: BindData
        Private Sub BindData()
            Dim tbltemp As New DataTable

            If Not hidContractID.Value = 0 Then
                objBPO.AcqPOID = hidContractID.Value
                tbltemp = objBPO.GetCheckingReceived
                If Not tbltemp Is Nothing Then
                    If tbltemp.Rows.Count > 0 Then
                        dgrCheckingReceived.DataSource = tbltemp
                        dgrCheckingReceived.DataBind()
                    End If
                    tbltemp = Nothing
                End If
            End If
        End Sub

        ' Method: BindJS
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")

            lnkBack.NavigateUrl = "WContractDetail.aspx?ContractID=" & hidContractID.Value
        End Sub

        ' Event: btnUpdate_Click
        ' Purpose: Update infor
        Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Dim dtgTemp As DataGridItem
            Dim strIDs As String = ""
            Dim strReceivedCopies As String = ""
            Dim strNoties As String = ""
            Dim strReceived As String = ""
            Dim strRequested As String = ""

            For Each dtgTemp In dgrCheckingReceived.Items
                strIDs = strIDs & CType(dtgTemp.FindControl("lblID"), Label).Text & ","
                strReceivedCopies = strReceivedCopies & CType(dtgTemp.FindControl("txtReceive"), TextBox).Text & ","
                strNoties = strNoties & CType(dtgTemp.FindControl("txtNote"), TextBox).Text & ","
            Next

            If strIDs <> "" Then
                strIDs = Left(strIDs, strIDs.Length - 1)
                strReceivedCopies = Left(strReceivedCopies, strReceivedCopies.Length - 1)
                strNoties = Left(strNoties, strNoties.Length - 1)

                ' Update process

                Call objBPO.UpdateCheckingReceived(strIDs, strReceivedCopies, strNoties)
                'Message OK
                If objBPO.ErrorMsg = "" Then
                    Page.RegisterClientScriptBlock("SuccessJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(5).Text & "');self.location.href='WContractDetail.aspx?ContractID=" & hidContractID.Value & "';</script>")
                End If
            End If
            Call BindData()
        End Sub

        ' Event: dgrCheckingReceived_ItemCreated
        Private Sub dgrCheckingReceived_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrCheckingReceived.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                    Dim tblCell As TableCell
                    tblCell = e.Item.Cells(2)
                    Dim txtReceiveTemp As TextBox

                    txtReceiveTemp = CType(tblCell.FindControl("txtReceive"), TextBox)
                    ' txtReceiveTemp.Attributes.Add("OnChange", "if((this.value > " & DataBinder.Eval(e.Item.DataItem, "RequestedCopies") & ") || CheckNull(this) || (!CheckNum(this))) {alert(' " & ddlLabel.Items(4).Text & "'); this.focus(); this.value='" & DataBinder.Eval(e.Item.DataItem, "RequestedCopies") & "'; return(false);}")
                    'txtReceiveTemp.Attributes.Add("OnChange", "if(CheckNull(this) || (!CheckNum(this))) {alert(' " & ddlLabel.Items(4).Text & "'); this.focus(); this.value='" & DataBinder.Eval(e.Item.DataItem, "RequestedCopies") & "'; return(false);}")
                    SetCheckNumber(txtReceiveTemp, ddlLabel.Items(4).Text, "0")
            End Select
        End Sub

        ' Method: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBPO Is Nothing Then
                objBPO.Dispose(True)
                objBPO = Nothing
            End If
        End Sub
    End Class
End Namespace