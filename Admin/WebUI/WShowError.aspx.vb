Imports System.Web.Mail
Namespace eMicLibAdmin.WebUI
    Partial Class WShowError
        Inherits Web.UI.Page

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lbResult As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            If clsSession.GlbUser & "" = "" Then
                Response.Write("<script language = 'javascript'>if(top.header){top.location.href= top.header.location.href.toLowerCase().replace('header.aspx', 'index.aspx');}else{self.close(); opener.top.location.href = opener.top.header.location.href.toLowerCase().replace('header.aspx', 'index.aspx');}</script>")
                Response.End()
            End If
            Response.Write("<link href=""Resources/StyleSheet/Admin.unicode.css"" type=""text/css"" rel=""StyleSheet"">")
            btnBack.Attributes.Add("onClick", "self.close();")
            txtContent.Text = Session("ErrorMessage")
        End Sub

        Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
            If Me.SendMail("Error customer !", txtContent.Text) = 1 Then
                Page.RegisterClientScriptBlock("CloseJS", "<script language = 'javascript'>self.close();</script>")
            Else
                lblError.Visible = True
            End If
        End Sub
        ' SendMail method
        Public Function SendMail(ByVal strSubject As String, ByVal strContent As String) As Integer
            Dim objMail As New MailMessage
            Dim arrFileAttach() As String
            Dim intIndex As Integer
            strContent = strContent.Replace(vbCrLf, "<br>")
            Try
                'strSubject = Trim(objBCSP.ToUTF8(strSubject))
                objMail.From = Application("SendErrorFromEmail")
                objMail.To = Application("SendErrorToEmail")


                objMail.Subject = strSubject
                objMail.Headers.Add("Content-Transfer-Encoding", "8bit")
                strContent = strContent.Replace("&lt;", "<").Replace("&gt;", ">")
                objMail.BodyFormat = MailFormat.Html
                objMail.Body = strContent

                objMail.BodyEncoding = System.Text.Encoding.UTF8
                objMail.Priority = MailPriority.High
                SmtpMail.SmtpServer = Application("SmtpServer")
                SmtpMail.Send(objMail)
                SendMail = 1
            Catch ex As Exception
                SendMail = 0
            End Try
        End Function
    End Class
End Namespace