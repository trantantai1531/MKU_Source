' class  WBorrowCountManagement
' Puspose: 
' Creator: 
' CreatedDate: 
' Modification History:

Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.WebUI

Partial Class WBorrowCountManagement
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
    End Sub

    ' Initialize method
    Private Sub Initialize()
    End Sub

    ' BindScript method
    ' Purpose: Bind JAVASCRIPTS
    Private Sub BindScript()
        Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
    End Sub

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

End Class
