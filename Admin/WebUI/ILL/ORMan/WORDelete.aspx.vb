'Class WORDelete.aspx
'Puspose: Detele request in query
'Creator: Tuanhv
'CreatedDate: 25/11/2004
'Modification History:

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.ILL

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WORDelete
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
        Private objBILLOutRequest As New clsBILLOutRequest

        'Page_Load event
        'Pupose: Load information init in this form
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJavascript()
        End Sub

        ' CheckFormPermission method
        Private Sub CheckFormPermission()
            If Not CheckPemission(154) Then
                Page.RegisterClientScriptBlock("invaliduser", "<script language='javascript'>alert('" & ddlLabel.Items(2).Text & "'); self.close();</script>")
                Response.End()
            End If
        End Sub

        'Initialize method
        'Pupose: Init all object use in form
        Private Sub Initialize()
            objBILLOutRequest.InterfaceLanguage = Session("InterfaceLanguage")
            objBILLOutRequest.DBServer = Session("DBServer")
            objBILLOutRequest.ConnectionString = Session("ConnectionString")
            Call objBILLOutRequest.Initialize()
        End Sub

        'BindJavascript method
        'Pupose: Bind javascript in form
        Private Sub BindJavascript()
            btnDelete.Attributes.Add("onClick", "javascript:if(!confirm('" + lblCheck.Text + "')) return false;")
            btnNoDelete.Attributes.Add("Onclick", "javascript:self.close()")
        End Sub

        'DeleteRequest method
        'Pupose: Changer request in out request 
        Sub DeleteRequest()
            If IsNumeric(Request("ILLID")) Then
                objBILLOutRequest.IllID = Request("ILLID")
                objBILLOutRequest.DeleteOR()
                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(1).Text, objBILLOutRequest.ErrorCode)

                ' Write log
                WriteLog(66, ddlLabel.Items(3).Text & " (RequestID:" & Request("ILLID") & ")", Request.ServerVariables("SCRIPT_NAME"), CStr(Request.ServerVariables("Remote_Addr")), clsSession.GlbUserFullName)
            End If
        End Sub

        'Event btnDelete_Click
        'Pupose: Delete request in out request
        Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            Call DeleteRequest()
            Page.RegisterClientScriptBlock("CloseJS", "<script language='javascript'>opener.top.main.Workform.location.href='WORMan.aspx';self.close();</script>")
        End Sub

        'Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        'Dispose method
        'Purpose: release all objects
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