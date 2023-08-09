' Class: WPreviewLetter
' Puspose: Preview Claim Letter
' Creator: Oanhtn
' CreatedDate: 21/09/2004
' Modification history:
'   + 18/10/2004 by Sondp: PreviewLetter

Imports eMicLibAdmin.BusinessRules.Serial
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WPreviewLetter
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

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            If Not Request.QueryString("SignFlage") Is Nothing Then
                Dim strOutMsg As String = ""
                Dim a = Request("Editor")
                strOutMsg = "<div class='conten-letter'>" & Request("Editor").Replace("&lt;", "<").Replace("&gt;", ">") & "</div>"
                Select Case UCase(Request.QueryString("SignFlage"))
                    Case "PREVIEW"
                        strOutMsg = strOutMsg & "<div ><input type=""button"" class=""lbButton"" runat=""server"" OnClick=""javascript:self.close();return(false);"" value=""" & lblClose.Text & """></div>"
                        lblOutMsg.Text = strOutMsg
                    Case "PRINT"
                        strOutMsg = strOutMsg
                        lblOutMsg.Text = strOutMsg
                        Page.RegisterClientScriptBlock("PrintJs", "<script language='javascript'>self.focus();setTimeout('self.print()', 1);;</script>")
                    Case "EMAIL"
                End Select
            End If
        End Sub
#Region "Initialize method"
        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()

        End Sub
#End Region
#Region "Page_Unload event"
        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try

            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
#End Region

    End Class
End Namespace