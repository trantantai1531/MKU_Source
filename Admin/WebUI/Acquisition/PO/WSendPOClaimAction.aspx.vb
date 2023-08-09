' class 
' Puspose: Edit PO Claim
' Creator: Sondp
' CreatedDate: 07/04/2005
' Modification History:

Imports eMicLibAdmin.BusinessRules.Acquisition.clsBItemOrder
Imports eMicLibAdmin.BusinessRules.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WSendPOClaimAction
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


        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            Call BindScript()

            If Not Page.IsPostBack Then
                If Not Session("Metric") Is Nothing Then
                    Dim objMetric As New Metric
                    objMetric = Session("Metric")
                    txtEmailAddress.Text = objMetric.objEmail(0)
                    Editor.Visible = True
                    Editor.Text = objMetric.objData(0)
                End If
            End If
            If Not Request.QueryString("action") & "" = "" Then
                Select Case UCase(Request.QueryString("action"))
                    Case "EMAIL"
                        Editor.Visible = False
                        If Not txtEmailAddress.Text = "" Then
                            Dim intSuccess As Integer
                            Call WriteErrorMssg(ddlLabel.Items(0).Text, ErrorMsg, ddlLabel.Items(1).Text, ErrorCode)
                            intSuccess = SendMail(ddlLabel.Items(3).Text, Editor.Text, txtEmailAddress.Text, True)
                            If intSuccess = 1 Then
                                Page.RegisterClientScriptBlock("SendEmailSuccessfulJs", "<script language='javascript'>alert('" & ddlLabel.Items(2).Text & "');</script>")
                            Else
                                Page.RegisterClientScriptBlock("SendEmailUnSuccessfulJs", "<script language='javascript'>alert('" & ddlLabel.Items(3).Text & "');</script>")
                            End If
                        End If
                End Select
            End If
            Editor.Text = Editor.Text.Replace("&lt;", "<").Replace("&gt;", ">")
        End Sub

        ' Initialize method
        Private Sub Initialize()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("WSendPOClaimActionJs", "<script language='javascript' src='../Js/PO/WSendPOClaim.js'></script>")

            btnEmail.Attributes.Add("OnClick", "Encryption();return(true);Decryption();")
            btnPreview.Attributes.Add("OnClick", "Encryption();return(Preview('Preview'));Decryption();")
            btnPrint.Attributes.Add("OnClick", "Encryption();return(Preview('Print'));Decryption();")
        End Sub

        ' btnEmail_Click event
        Private Sub btnEmail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEmail.Click
            Dim intSuccess As Integer
            Editor.Text.Replace("&lt;", "<").Replace("&gt;", ">")
            If Page.IsValid Then
                intSuccess = SendMail("", Editor.Text, txtEmailAddress.Text, True)
                If intSuccess = 1 Then
                    Page.RegisterClientScriptBlock("SendEmailSuccessfulJs", "<script language='javascript'>alert('" & ddlLabel.Items(2).Text & "');</script>")
                Else
                    Page.RegisterClientScriptBlock("SendEmailUnSuccessfulJs", "<script language='javascript'>alert('" & ddlLabel.Items(3).Text & "');</script>")
                End If
            End If
        End Sub

        ' Page_Unload method
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not Session("Metric") Is Nothing Then
                Session("Metric") = Nothing
            End If
        End Sub
    End Class
End Namespace