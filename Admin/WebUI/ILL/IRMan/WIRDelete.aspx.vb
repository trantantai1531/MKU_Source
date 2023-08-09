' class WIRChangeStatus
' Puspose: 
' Creator: Lent
' CreatedDate: 25/11/2004
' Modification History:
' Review code : lent 25-4-2005

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.ILL

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WIRDelete
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

        ' Event : Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJavascript()
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBILLInRequest object
            objBILLInRequest.InterfaceLanguage = Session("InterfaceLanguage")
            objBILLInRequest.DBServer = Session("DBServer")
            objBILLInRequest.ConnectionString = Session("ConnectionString")
            Call objBILLInRequest.Initialize()
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(153) Then
                Page.RegisterClientScriptBlock("AccessDeniedJS", "<script language = 'javascript'>alert('" & ddlLabel.Items(2).Text & "');self.close();</script>")
                Response.End()
            End If
        End Sub

        ' BindScript method
        Private Sub BindJavascript()
            Dim intIllID As Integer = 0
            If Request("IllID") & "" <> "" Then
                intIllID = CInt(Request("IllID"))
            End If
            hidILLID.Value = intIllID
            btnDelete.Attributes.Add("onClick", "javascript:if(!confirm('" + ddlLabel.Items(5).Text + "')) return false;")
            btnCancel.Attributes.Add("onClick", "javascript:self.close()")
        End Sub

        ' Data proccess 
        Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            Dim intSuccess As Integer = 0

            objBILLInRequest.ILLID = CLng(hidIllID.Value)
            intSuccess = objBILLInRequest.DeleteIR()
            ' Write Error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLInRequest.ErrorMsg, ddlLabel.Items(1).Text, objBILLInRequest.ErrorCode)
            ' WriteLog
            Call WriteLog(65, lblHeader.Text & ": ILLID=" & hidILLID.Value, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

            If intSuccess = 1 Then
                Page.RegisterClientScriptBlock("ViewMsg1", "<script language = 'javascript'>alert('" & ddlLabel.Items(4).Text & "');opener.top.main.Workform.location.href='WIRMan.aspx';self.close();</script>")
            Else
                Page.RegisterClientScriptBlock("ViewMsg2", "<script language = 'javascript'>alert('" & ddlLabel.Items(6).Text & "');opener.top.main.Workform.location.href='WIRMan.aspx';self.close();</script>")
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