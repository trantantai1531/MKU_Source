' class WChangeFolder.aspx
' Puspose: 
' Creator: Sondp
' CreatedDate: 25/11/2004
' Modification History:

Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.ILL

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WChangeFolder
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
        Private objBILLOutRequest As New clsBILLOutRequest

        ' Page_Load event0
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call ChangeFolder()
        End Sub

        ' ChangeFolder method
        Private Sub ChangeFolder()
            If Not CheckPemission(154) Then
                Page.RegisterClientScriptBlock("invaliduser", "<script language='javascript'>alert('" & ddlLabel.Items(0).Text & "');</script>")
            Else
                If IsNumeric(Request("ILLID")) Then
                    objBILLOutRequest.IllID = CLng(Request("ILLID"))
                    objBILLOutRequest.ChangeFolder()
                    ' Write Error
                    Call WriteErrorMssg(objBILLOutRequest.ErrorCode, objBILLOutRequest.ErrorMsg)

                    ' Write log
                    WriteLog(66, ddlLabel.Items(1).Text & " (RequestID:" & Request("ILLID") & ")", Request.ServerVariables("SCRIPT_NAME"), CStr(Request.ServerVariables("Remote_Addr")), clsSession.GlbUserFullName)

                    Page.RegisterClientScriptBlock("LoadWorkForm", "<script language = 'javascript'>alert('" & ddlLabel.Items(2).Text & "');parent.Workform.location.href='WORMan.aspx';</script>")
                End If
            End If

        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBILLOutRequest
            objBILLOutRequest.InterfaceLanguage = Session("InterfaceLanguage")
            objBILLOutRequest.DBServer = Session("DBServer")
            objBILLOutRequest.ConnectionString = Session("ConnectionString")
            objBILLOutRequest.Initialize()
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBILLOutRequest Is Nothing Then
                    objBILLOutRequest.Dispose(True)
                    objBILLOutRequest = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace