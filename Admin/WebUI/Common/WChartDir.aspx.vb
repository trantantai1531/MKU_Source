' Name: WChartDir
' Purpose: write chart
' Creator: Oanhtn
' CreatedDate: 07/09/2004
' Modification History:

Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.WebUI.Common

Namespace eMicLibAdmin.WebUI
    Partial Class WChartDir
        Inherits System.Web.UI.Page

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
            If Not (Session("chart" & Request.QueryString("i")) Is Nothing) Then
                Response.ContentType = "images/gif"
                Response.BinaryWrite(Session("chart" & Request.QueryString("i")))
            Else
                Response.ContentType = "images/png"
                Dim fileTmp As Byte() = System.IO.File.ReadAllBytes(Server.MapPath("../Resources/Images/bgicon.png"))
                Response.BinaryWrite(fileTmp)
            End If
        End Sub
    End Class
End Namespace