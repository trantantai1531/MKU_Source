Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.ILL
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WRequestTaskBar
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents hidCreateRq As System.Web.UI.HtmlControls.HtmlInputHidden


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call CheckFormPermission()
            Call BindScript()
        End Sub

        ' CheckFormPermission method
        Private Sub CheckFormPermission()
            'Yeu cau den
            If CInt(Trim(Request("ReqType"))) = 1 Then
                If Not CheckPemission(153) Then
                    btnCreate.Enabled = False
                    btnFilter.Enabled = False
                    btnAction.Enabled = False
                    btnCancelFilter.Enabled = False
                End If
            Else
                'Yeu cau di
                If Not CheckPemission(154) Then
                    btnCreate.Enabled = False
                    btnFilter.Enabled = False
                    btnAction.Enabled = False
                    btnCancelFilter.Enabled = False
                End If
            End If
        End Sub
        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = 'js/WRequestTaskbar.js'></script>")
            btnCreate.Attributes.Add("OnClick", "javascript:Create();return(false);")
            If Not Request("ReqType") Is Nothing Then
                Select Case Trim(Request("ReqType"))
                    Case "1"
                        Page.RegisterClientScriptBlock("LoadForm", "<script language='javascript'>parent.Workform.location.href='IRMan/WIRMan.aspx';</script>")
                        btnCreate.Visible = False
                        btnFilter.Attributes.Add("OnClick", "javascript:FilterInData(); return false;")
                        btnCancelFilter.Attributes.Add("OnClick", "javascript:parent.Workform.location.href='IRMan/WIRman.aspx?Cancel=True'; return false;")
                        btnAction.Attributes.Add("OnClick", "javascript:Act();return false;")
                        hidReqType.Value = 1
                    Case "2"
                        Page.RegisterClientScriptBlock("LoadForm", "<script language='javascript'>parent.Workform.location.href='ORMan/WORMan.aspx';</script>")
                        btnCreate.Visible = True
                        btnFilter.Attributes.Add("OnClick", "javascript:FilterOutData(); return false;")
                        btnCancelFilter.Attributes.Add("OnClick", "javascript:parent.Workform.location.href='ORMan/WORman.aspx?Cancel=True'; return false;")
                        btnAction.Attributes.Add("OnClick", "javascript:Act();return false;")
                        hidReqType.Value = 2
                End Select
            End If

        End Sub

        ' Page UnLoad event
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
End Namespace
