' class WComprehReportBookE
' Puspose: Edit Comprehensive Report Book
' Creator: Sondp
' CreatedDate: 12/04/2005
' Modification History:

Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.WebUI.Acquisition
Imports eMicLibAdmin.BusinessRules.Acquisition.clsBItemOrder
Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WComprehReportBookE
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

        Private objBIO As New clsBItemOrder
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                If Not Session("EditComprehendsiveReportBook") Is Nothing Then
                    Editor.Text = Session("EditComprehendsiveReportBook")
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
            Page.RegisterClientScriptBlock("WComprehReportBookE", "<script language='javascript' src='../Js/ACQ/WComprehReportBook.js'></script>")
            btnEmail.Attributes.Add("OnClick", "Encryption();return(true);Decryption();")
            btnPreview.Attributes.Add("OnClick", "Encryption();return(Preview('Preview'));Decryption();")
            btnPrint.Attributes.Add("OnClick", "Encryption();return(Preview('Print'));Decryption();")
        End Sub


        Private Sub btnEmail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEmail.Click
            Editor.Text.Replace("&lt;", "<").Replace("&gt;", ">")
            If Page.IsValid Then
                If SendMail(ddlLog.Items(3).Text, Editor.Text, txtEmailAddress.Text, True) Then
                    Page.RegisterClientScriptBlock("SendEmailSuccessfulJs", "<script language='javascript'>alert('" & lblSendEmailSuccessful.Text & "');</script>")
                Else
                    Page.RegisterClientScriptBlock("SendEmailUnSuccessfulJs", "<script language='javascript'>alert('" & lblSendMailUnSuccessful.Text & "');</script>")
                End If
            End If
        End Sub

        ' Page_Unload method
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBIO Is Nothing Then
                objBIO.Dispose(True)
                objBIO = Nothing
            End If
            If Not Session("EditComprehendsiveReportBook") Is Nothing Then
                Session("EditComprehendsiveReportBook") = Nothing
            End If
        End Sub
    End Class
End Namespace