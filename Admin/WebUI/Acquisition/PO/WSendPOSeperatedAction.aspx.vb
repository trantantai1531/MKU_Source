' class 
' Puspose: Send PO Seperated Store
' Creator: Sondp
' CreatedDate: 29/03/2005
' Modification History:

Imports eMicLibAdmin.BusinessRules.Acquisition.clsBItemOrder
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WSendPOSeperatedAction
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private objBIO As New clsBItemOrder

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Dim objMetric As New Metric
                If Not Session("Metric") Is Nothing Then
                    objMetric = Session("Metric")
                    txtEmailAddress.Text = objMetric.objEmail(0)
                    Select Case UCase(Request.QueryString("action")) & ""
                        Case "EMAIL"
                            Editor.Visible = False
                            If Not txtEmailAddress.Text = "" Then
                                If SendMail(ddlLabel.Items(5).Text, objMetric.objData(0), txtEmailAddress.Text, True) Then
                                    Page.RegisterClientScriptBlock("SendEmailSuccessfulJs", "<script language='javascript'>alert('" & ddlLabel.Items(2).Text & "');</script>")
                                Else
                                    Page.RegisterClientScriptBlock("SendEmailUnSuccessfulJs", "<script language='javascript'>alert('" & ddlLabel.Items(3).Text & "');</script>")
                                End If
                            End If
                        Case "EDIT"
                            Editor.Visible = True
                            Editor.Text = objMetric.objData(0)
                            'Editor.Text = CStr(objMetric.objData(0)).Replace("<", "&lt;").Replace(">", "&gt;")
                        Case Else
                            Editor.Visible = False
                    End Select
                End If
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Initialize objBIO object
            objBIO.InterfaceLanguage = Session("InterfaceLanguage")
            objBIO.DBServer = Session("DBServer")
            objBIO.ConnectionString = Session("ConnectionString")
            objBIO.Initialize()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("WCommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WSendPOSeperatedActionJs", "<script language='javascript' src='../Js/PO/WSendPOSeperated.js'></script>")
            btnEmail.Attributes.Add("OnClick", "return SendMailPO('" & ddlLabel.Items(6).Text & "','" & ddlLabel.Items(4).Text & "');")
            btnPreview.Attributes.Add("OnClick", "Encryption();ActionPO('Preview');return false;")
            btnPrint.Attributes.Add("OnClick", "Encryption();ActionPO('Print');return false;")
        End Sub


        Private Sub btnEmail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEmail.Click
            Dim intSuccess As Integer
            If Page.IsValid Then
                intSuccess = SendMail(ddlLabel.Items(5).Text, Editor.Text, txtEmailAddress.Text, True)
                If intSuccess = 1 Then
                    Page.RegisterClientScriptBlock("SendEmailSuccessfulJs", "<script language='javascript'>alert('" & ddlLabel.Items(2).Text & "');window.location.href = 'WSendPOSeperatedSearch.aspx';</script>")
                Else
                    Page.RegisterClientScriptBlock("SendEmailUnSuccessfulJs", "<script language='javascript'>alert('" & ddlLabel.Items(3).Text & "');window.location.href = 'WSendPOSeperatedSearch.aspx';</script>")
                End If
            End If
        End Sub

        ' Page_Unload method
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBIO Is Nothing Then
                objBIO.Dispose(True)
                objBIO = Nothing
            End If
            If Not Session("Metric") Is Nothing Then
                Session("Metric") = Nothing
            End If
        End Sub
    End Class
End Namespace