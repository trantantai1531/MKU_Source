Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.ILL
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WORSendMess
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

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindScript()
            Call BindData()
        End Sub

        ' CheckFormPermission method
        Private Sub CheckFormPermission()
            If Not CheckPemission(154) Then
                Page.RegisterClientScriptBlock("invaliduser", "<script language='javascript'>alert('" & ddlLabel.Items(5).Text & "'); self.close();</script>")
                Response.End()
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBILLOutRequest object 
            objBILLOutRequest.ConnectionString = Session("ConnectionString")
            objBILLOutRequest.DBServer = Session("DBServer")
            objBILLOutRequest.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBILLOutRequest.Initialize()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            btnCancel.Attributes.Add("OnClick", "self.close();")
        End Sub

        ' btnSent_Click event
        Private Sub btnSent_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSent.Click
            Call SentMsg()
        End Sub

        ' SentMsg method
        Private Sub SentMsg()
            ' Declare variables
            Dim strContent As String
            Dim intAnswer As Integer
            Dim intSuccess As Int16
            Dim intSendMail As Int16 = 0
            Dim strMailFrom As String
            Dim strMailTo As String
            Dim strContentOut As String
            Dim strSubject As String

            If IsNumeric(Request("ILLID")) Then
                objBILLOutRequest.IllID = CInt(Request("ILLID"))
                objBILLOutRequest.Note = txtNote.Text

                strContent = objBILLOutRequest.MessageXmlRecord(txtNote.Text)
                objBILLOutRequest.ResponderID = hdnResponderID.Value
                intSuccess = objBILLOutRequest.GetEmailInfor(Server.MapPath(""), strContent, strMailFrom, strMailTo, strContentOut)
                EncodeILLError(objBILLOutRequest.EncodeOk)
                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(3).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(4).Text, objBILLOutRequest.ErrorCode)

                objBILLOutRequest.AddORLog(17)

                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(3).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(4).Text, objBILLOutRequest.ErrorCode)

                ' Success 
                If intSuccess = 0 Then
                    intSendMail = SendMail(strSubject, strContentOut, strMailTo, False, strMailFrom)
                    ' Check error
                    Call WriteErrorMssg(ddlLabel.Items(3).Text, ErrorMsg, ddlLabel.Items(4).Text, ErrorCode)
                    If intSendMail = 1 Then
                        Page.RegisterClientScriptBlock("Success", "<script language = 'javascript'>alert('" & ddlLabel.Items(0).Text & "');self.close();</script>")
                    Else
                        Page.RegisterClientScriptBlock("Success", "<script language = 'javascript'>alert('" & ddlLabel.Items(2).Text & "');self.close();</script>")
                    End If
                Else
                    Page.RegisterClientScriptBlock("Success", "<script language = 'javascript'>alert('" & ddlLabel.Items(2).Text & "');self.close();</script>")
                End If
            End If
        End Sub

        ' BindData method
        Private Sub BindData()
            ' Declare variables
            Dim tblRequest As DataTable
            Dim blnValid As Boolean = True

            ' Check the request infor
            If IsNumeric(Request("ILLID")) Then
                objBILLOutRequest.IllID = CLng(Request("ILLID"))
                tblRequest = objBILLOutRequest.GetORInfor

                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(3).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(4).Text, objBILLOutRequest.ErrorCode)

                If Not tblRequest Is Nothing Then
                    If tblRequest.Rows.Count > 0 Then
                        ' ResponderID
                        If Not IsDBNull(tblRequest.Rows(0).Item("ResponderID")) Then
                            hdnResponderID.Value = tblRequest.Rows(0).Item("ResponderID")
                        Else
                            hdnResponderID.Value = 0
                        End If
                    Else
                        blnValid = False
                    End If
                Else
                    blnValid = False
                End If
            Else
                blnValid = False
            End If

            ' Error
            If blnValid = False Then
                Page.RegisterClientScriptBlock("Msg2", "<script language = 'javascript'>alert('" & ddlLabel.Items(1).Text & "');self.close();</script>")
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

