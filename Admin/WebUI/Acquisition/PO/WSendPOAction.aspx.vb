' class 
' Puspose: Manager send po
' Creator: Sondp
' CreatedDate: 21/03/2005
' Modification History:
Imports eMicLibAdmin.BusinessRules.Acquisition.clsBItemOrder
Imports eMicLibAdmin.BusinessRules.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WSendPOAction
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblDisplay As System.Web.UI.WebControls.Label
        Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private objBIO As New clsBItemOrder
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            Call BindScript()
            hidAction.Value = ""
            If Not Page.IsPostBack Then
                If Not Session("Metric") Is Nothing Then
                    Dim objMetric As New Metric
                    objMetric = Session("Metric")
                    txtEmailAddress.Text = objMetric.objEmail(Request.QueryString("index"))
                    Select Case UCase(Request.QueryString("action")) & ""
                        Case "EMAIL"
                            Editor.Visible = False
                            If Not txtEmailAddress.Text = "" Then
                                If SendEmail(objMetric.objData(Request.QueryString("index")), True, txtEmailAddress.Text) = True Then
                                    Page.RegisterClientScriptBlock("SendEmailSuccessfulJs", "<script language='javascript'>alert('" & lblSendEmailSuccessful.Text & "');</script>")
                                Else
                                    Page.RegisterClientScriptBlock("SendEmailUnSuccessfulJs", "<script language='javascript'>alert('" & lblSendEmailUnSuccessful.Text & "');</script>")
                                End If
                            End If
                            hidAction.Value = "EMAIL"
                        Case "EDIT"
                            Editor.Visible = True
                            Editor.Text = objMetric.objData(Request.QueryString("index"))
                        Case Else 'print
                            Editor.Visible = True
                            Editor.Text = objMetric.objData(Request.QueryString("index"))
                            hidAction.Value = "PRINT"
                    End Select
                End If
            End If
            Editor.Text = Editor.Text.Replace("&lt;", "<").Replace("&gt;", ">")
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
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WSendPOActionJs", "<script language='javascript' src='../Js/PO/WSendPO.js'></script>")

            btnEmail.Attributes.Add("OnClick", "return SendMailPO('" & ddlLabel.Items(3).Text & "','" & ddlLabel.Items(4).Text & "');")
            btnPreview.Attributes.Add("OnClick", "Encryption();return(Preview('Preview'));Decryption();")
            btnPrint.Attributes.Add("OnClick", "Encryption();return(Preview('Print'));Decryption();")
        End Sub

        ' SendEmail method
        Private Function SendEmail(ByVal strContent As String, ByVal isHTML As Boolean, ByVal strEmailAddress As String) As Boolean
            If SendMail(ddlLabel.Items(2).Text, strContent, strEmailAddress, isHTML) = 1 Then
                SendEmail = True
            Else
                SendEmail = False
            End If
        End Function

        Private Sub btnEmail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEmail.Click
            Editor.Text = Editor.Text.Replace("&lt;", "<").Replace("&gt;", ">")
            If Page.IsValid Then
                If SendEmail(Editor.Text, True, txtEmailAddress.Text) Then
                    Page.RegisterClientScriptBlock("SendEmailSuccessfulJs", "<script language='javascript'>alert('" & lblSendEmailSuccessful.Text & "');</script>")
                    hidAction.Value = "EMAIL"
                Else
                    Page.RegisterClientScriptBlock("SendEmailUnSuccessfulJs", "<script language='javascript'>alert('" & lblSendEmailUnSuccessful.Text & "');</script>")
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