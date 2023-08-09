' Class: WSendPOClaimSearch
' Puspose: Send Claim template
' Creator: Sondp
' CreatedDate: 06/04/2005
' Modification History:

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WSendPOClaimSearch
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
        Private objBCT As New clsBCommonTemplate
        Private objBCDBS As New clsBCommonDBSystem

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                hidContractID.Value = Request.QueryString("ContractID")
                Call BindData()
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: init object
        Private Sub Initialize()
            ' Initialize objBCT object
            objBCT.InterfaceLanguage = Session("InterfaceLanguage")
            objBCT.DBServer = Session("DBServer")
            objBCT.ConnectionString = Session("ConnectionString")
            Call objBCT.Initialize()

            ' Initialize objBCDBS object
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            Call objBCDBS.Initialize()
        End Sub

        ' Method: BindScript
        ' Purpose: Include need js functions
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("WSendPOClaimSearchJs", "<script language='javascript' src='../Js/PO/WSendPOClaim.js'></script>")

            btnPreview.Attributes.Add("OnClick", "TransferData('PREVIEW','" & ddlLabel.Items(3).Text & "');return false;")
            btnPrint.Attributes.Add("OnClick", "TransferData('PRINT','" & ddlLabel.Items(3).Text & "');return false;")
            btnSaveToFile.Attributes.Add("OnClick", "TransferData('FILE','" & ddlLabel.Items(3).Text & "');return false;")
            btnEmail.Attributes.Add("OnClick", "TransferData('EMAIL','" & ddlLabel.Items(3).Text & "');return false;")
        End Sub

        ' Method: BindData
        Private Sub BindData()
            Dim tblTemplate As New DataTable
            Dim listItem As New listItem

            Try
                objBCT.TemplateID = 0
                objBCT.TemplateType = 8
                objBCT.LibID = clsSession.GlbSite
                tblTemplate = objBCT.GetTemplate
                If Not tblTemplate Is Nothing Then
                    If tblTemplate.Rows.Count > 0 Then
                        ddlTemplate.DataSource = InsertOneRow(tblTemplate, ddlLabel.Items(2).Text)
                        ddlTemplate.DataTextField = "Title"
                        ddlTemplate.DataValueField = "ID"
                        ddlTemplate.DataBind()
                    End If
                Else
                    listItem.Text = ddlLabel.Items(2).Text
                    listItem.Value = 0
                    ddlTemplate.Items.Add(listItem)
                End If
            Catch ex As Exception ' Error occurred
            Finally
                tblTemplate = Nothing
                listItem = Nothing
            End Try
        End Sub

        ' Method: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBCT Is Nothing Then
                objBCT.Dispose(True)
                objBCT = Nothing
            End If
            If Not objBCDBS Is Nothing Then
                objBCDBS.Dispose(True)
                objBCDBS = Nothing
            End If
            If Not Session("Metric") Is Nothing Then
                Session("Metric") = Nothing
            End If
        End Sub
    End Class
End Namespace