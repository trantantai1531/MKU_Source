' WMarcFormSave class: create/update new form
' Creator: Oanhtn
' CreatedDate: 06/05/2004
' Modification history:
'   - 23/02/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WMarcFormSave
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

        Private objBForm As New clsBForm

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            Call SaveMarcForm()
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init for objBForm
            objBForm.InterfaceLanguage = Session("InterfaceLanguage")
            objBForm.DBServer = Session("DBServer")
            objBForm.ConnectionString = Session("ConnectionString")
            objBForm.IsAuthority = Session("IsAuthority")
            Call objBForm.Initialize()
        End Sub

        ' BindJS method
        ' Purpose: include all necessary javascript functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WMarcFormSave", "<script language = 'javascript' src = '../Js/BibliographyTemplate/WMarcFormSave.js'></script>")
        End Sub

        ' SaveMarcForm method
        ' Purpose: Create new catalogue form
        Private Sub SaveMarcForm()
            ' Declare variables
            Dim intCounter As Integer
            Dim strTempo As String
            Dim arrTemp()
            Dim strFormName As String = Request("txtFormName")
            Dim strFieldDefaultValues As String = Request("txtFieldDefaultValues")
            Dim strFieldIndicatorValues As String = Request("txtFieldIndicatorValues")
            Dim strFieldCodes As String = Request("txtPickedFields")
            Dim strMandatoryFieldCodes As String = Request("txtMandatoryFields")
            Dim strTextBoxFields As String = Request("txtTextBoxFields")

            Dim strMess0 As String = ddlLabel.Items(0).Text
            Dim strMess1 As String = ddlLabel.Items(1).Text
            Dim strMess2 As String = ddlLabel.Items(2).Text


            objBForm.FieldCodes = strFieldCodes
            objBForm.MandatoryFieldCodes = strMandatoryFieldCodes
            objBForm.FieldDefaultValues = strFieldDefaultValues
            objBForm.FieldIndicatorValues = strFieldIndicatorValues
            objBForm.TextBoxFields = strTextBoxFields
            objBForm.Creator = clsSession.GlbUserFullName
            objBForm.FormName = strFormName

            ' Update exist Form
            If Not Request("txtFormID") = "0" Then
                objBForm.FormID = CInt(Request("txtFormID"))
                Call WriteLog(21, ddlLabel.Items(2).Text & ": " & strFormName & " (" & Request("txtFormID") & ")", Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                Call objBForm.Modify()
                ' Loadback data
                Page.RegisterClientScriptBlock("Success", "<script language = 'javascript'>LoadBack('" & strMess2 & " " & strFormName & " " & strMess1 & "'); parent.Sentform.location.href='WMarcSend.aspx?FormID=" & CInt(Request("txtFormID")) & "';</script>")
            Else ' Create new Form
                Call WriteLog(20, ddlLabel.Items(0).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                Call objBForm.Create()
                ' Alert message
                Page.RegisterClientScriptBlock("Success", "<script language = 'javascript'>LoadBack('" & strMess0 & " " & strFormName & " " & strMess1 & "');</script>")
            End If
        End Sub

        ' Page_Unload event
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBForm Is Nothing Then
                    objBForm.Dispose(True)
                    objBForm = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace