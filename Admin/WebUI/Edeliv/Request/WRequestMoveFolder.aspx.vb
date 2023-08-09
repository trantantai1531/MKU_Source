Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.Edeliv
Imports eMicLibAdmin.BusinessRules.Common


Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WRequestMoveFolder
        Inherits clsWBase

        Dim objBERequest As New clsBERequest

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
            Call CheckFormPemission()
            Call Initialize()
            Call BindScript()
            objBERequest.RequestID = CLng(Request("RequestID"))
            Call objBERequest.MoveFolder()

            Call WriteErrorMssg(objBERequest.ErrorCode, objBERequest.ErrorMsg)
            ' WriteLog
            Call WriteLog(72, lblTemp.Text & " (RequestID:" & Request("RequestID") & ")", Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
            ' Refresh workform
            Page.RegisterClientScriptBlock("LoadWorkForm", "<script language = 'javascript'>parent.Workform.location.href='WRequestList.aspx';</script>")
        End Sub

        ' CheckFormPemission method
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            If Not CheckPemission(159) Then
                Page.RegisterClientScriptBlock("ErrorAlert", "<script language='javascript'>alert('ErrorMessage: " & lblLabel1.Text & " ');</script>")
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBERequest object
            objBERequest.ConnectionString = Session("ConnectionString")
            objBERequest.DBServer = Session("DBServer")
            objBERequest.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBERequest.Initialize()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/Request/WRequestRemove.js'></script>")
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBERequest Is Nothing Then
                    objBERequest.Dispose(True)
                    objBERequest = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

    End Class
End Namespace

