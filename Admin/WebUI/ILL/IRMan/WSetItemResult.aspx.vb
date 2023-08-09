Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.ILL

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WSetItemResult
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

        Private objBILLInRequest As New clsBILLInRequest

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            Call SetItem()
            Page.RegisterClientScriptBlock("LoadWorkForm", "<script language = 'javascript'>parent.Workform.location.href='WIRMan.aspx';</script>")
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBILLInRequest object 
            objBILLInRequest.ConnectionString = Session("ConnectionString")
            objBILLInRequest.DBServer = Session("DBServer")
            objBILLInRequest.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBILLInRequest.Initialize()
        End Sub

        ' SetItem method
        Private Sub SetItem()
            If IsNumeric(Request("ILLID")) Then
                objBILLInRequest.ILLID = CLng(Request("ILLID"))
                If IsNumeric(Request("ItemID")) Then
                    If Request("IssueID") & "" <> "" Then
                        objBILLInRequest.SetIRItem(CLng(Request("ItemID")), Request("IssueID"))
                    Else
                        objBILLInRequest.SetIRItem(CLng(Request("ItemID")))
                    End If
                    ' Check error
                    Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLInRequest.ErrorMsg, ddlLabel.Items(1).Text, objBILLInRequest.ErrorCode)
                    ' Write log
                    WriteLog(66, ddlLabel.Items(2).Text & " (RequestID:" & Request("ILLID") & ", ItemID:" & Request("ItemID") & ")", Request.ServerVariables("SCRIPT_NAME"), CStr(Request.ServerVariables("Remote_Addr")), clsSession.GlbUserFullName)
                End If
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
                If Not objBILLInRequest Is Nothing Then
                    objBILLInRequest.Dispose(True)
                    objBILLInRequest = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace