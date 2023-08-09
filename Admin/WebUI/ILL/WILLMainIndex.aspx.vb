' class WILLMainIndex
' Puspose: ILL main 
' Creator: Sondp
' CreatedDate: 1/12/2004
' Modification History:

Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WILLMainIndex
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

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            If Not Session("ILLModule") Is Nothing Then
                'ILL Module
                Session("ModuleName") = "ILL"
                Session("ModuleID") = 8

                If Session("ILLModule") = 0 Then
                    Response.Redirect("../WInvalidUser.aspx")
                End If
            Else
                Response.Redirect("../WNothing.aspx")
            End If
        End Sub

    End Class
End Namespace

