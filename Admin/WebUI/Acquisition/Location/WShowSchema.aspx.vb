' class WShowSchema
' Puspose: process location
' Creator: lent
' CreatedDate: 17-2-2005
' Modification History:

Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition
Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WShowSchema
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
            Call BindJavascript()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' BindJavascript method
        Private Sub BindJavascript()
            btnClose.Attributes.Add("onClick", "javascript:self.close();")
        End Sub
        ' BindData method
        ' Purpose: Load data
        Private Sub BindData()

            If Request.QueryString("LocID") & "" <> "" Then
                imgLoc.Src = "..\..\Common\ShowSchemaPicture.aspx?LocID=" & Request.QueryString("LocID")

            Else
                imgLoc.Src = "..\..\Empty.gif"
            End If

        End Sub
    End Class
End Namespace