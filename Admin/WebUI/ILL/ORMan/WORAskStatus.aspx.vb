Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.ILL
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WORAskStatus
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
        Private objBILLOutRequestCollection As New clsBILLOutRequestCollection

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' CheckFormPermission
        Private Sub CheckFormPermission()
            If Not CheckPemission(154) Then
                Page.RegisterClientScriptBlock("invaliduser", "<script language='javascript'>alert('" & ddlLabel.Items(5).Text & "');</script>")
                Response.End()
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBILLOutRequestCollection object 
            objBILLOutRequestCollection.ConnectionString = Session("ConnectionString")
            objBILLOutRequestCollection.DBServer = Session("DBServer")
            objBILLOutRequestCollection.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBILLOutRequestCollection.Initialize()
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

            If IsNumeric(Request("ILLID")) Then
                objBILLOutRequestCollection.IllID = CInt(Request("ILLID"))
                objBILLOutRequestCollection.Note = txtNote.Text

                strContent = objBILLOutRequestCollection.StatusXmlRecord(txtNote.Text)
                objBILLOutRequestCollection.AddORLog(18)
                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(3).Text, objBILLOutRequestCollection.ErrorMsg, ddlLabel.Items(4).Text, objBILLOutRequestCollection.ErrorCode)
                objBILLOutRequestCollection.ResponderID = hdnResponderID.Value
                intSuccess = objBILLOutRequestCollection.GetEmailInfor(Server.MapPath(""), strContent, strMailFrom, strMailTo, strContentOut)
                EncodeILLError(objBILLOutRequestCollection.EncodeOk)
                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(3).Text, objBILLOutRequestCollection.ErrorMsg, ddlLabel.Items(4).Text, objBILLOutRequestCollection.ErrorCode)

                ' Success
                If intSuccess = 0 Then
                    intSendMail = SendMail("ILL", strContentOut, strMailTo, False, strMailFrom)
                    ' Write Error
                    Call WriteErrorMssg(ddlLabel.Items(3).Text, ErrorMsg, ddlLabel.Items(4).Text, ErrorCode)
                    If intSendMail = 1 Then
                        Page.RegisterClientScriptBlock("Success", "<script language = 'javascript'>alert('" & ddlLabel.Items(0).Text & "');opener.top.main.Workform.location.href='WORMan.aspx';self.close();</script>")
                    Else
                        Page.RegisterClientScriptBlock("UnSuccess", "<script language = 'javascript'>alert('" & ddlLabel.Items(2).Text & "');opener.top.main.Workform.location.href='WORMan.aspx';self.close();</script>")
                    End If
                Else
                    Page.RegisterClientScriptBlock("UnSuccess", "<script language = 'javascript'>alert('" & ddlLabel.Items(2).Text & "');opener.top.main.Workform.location.href='WORMan.aspx';self.close();</script>")
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
                objBILLOutRequestCollection.IllID = CLng(Request("ILLID"))
                tblRequest = objBILLOutRequestCollection.GetORInfor
                blnValid = False
                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(3).Text, objBILLOutRequestCollection.ErrorMsg, ddlLabel.Items(4).Text, objBILLOutRequestCollection.ErrorCode)
                If Not tblRequest Is Nothing Then
                    If tblRequest.Rows.Count > 0 Then
                        ' ResponderID
                        If Not IsDBNull(tblRequest.Rows(0).Item("ResponderID")) Then
                            hdnResponderID.Value = tblRequest.Rows(0).Item("ResponderID")
                        Else
                            hdnResponderID.Value = 0
                        End If

                        blnValid = True
                    End If
                End If
            End If

            ' Not success
            If blnValid = False Then
                Page.RegisterClientScriptBlock("Msg1", "<script language = 'javascript'>alert('" & ddlLabel.Items(1).Text & "');self.close();</script>")
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
                If Not objBILLOutRequestCollection Is Nothing Then
                    objBILLOutRequestCollection.Dispose(True)
                    objBILLOutRequestCollection = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace

