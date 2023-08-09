' Class: WClaimTemplateManagement
' Puspose: Manage Claim Template
' Creator: Sondp
' CreatedDate: 5/10/2004
' Modification history:
'   + 20/10/2004 by Sondp: EditClaimLetter 

Imports eMicLibAdmin.BusinessRules.Serial
Imports eMicLibAdmin.BusinessRules.Common
Imports ExportTechnologies.WebControls.RTE.Edit
Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WEditClaimLetter
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
        Private objBClaimTemplate As New clsBClaimTemplate
        Private objBIssue As New clsBIssue
        Private objBDB As New clsBCommonDBSystem

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                If Not Request.QueryString("ID") & "" = "" Then
                    Editor.Text = CStr(Session("OutMsg")(CInt(Request.QueryString("ID"))))
                End If
                If Not Request.QueryString("ItemID") & "" = "" Then
                    Call BindEmailTo()
                End If
            End If
        End Sub
        Private Sub BindEmailTo()
            objBDB.SQLStatement = "SELECT B.Email FROM Acq_tblItem A,ACQ_VENDOR B,Acq_tblPo C WHERE A.POID=C.ID AND C.VendorID=B.ID AND B.Email<>'' AND A.ItemID=" & Request.QueryString("ItemID")
            Dim tblResult As DataTable = objBDB.RetrieveItemInfor
            If Not tblResult Is Nothing Then
                If tblResult.Rows.Count > 0 Then
                    txtEmailAddress.Text = tblResult.Rows(0).Item("Email")
                End If
            End If
        End Sub
        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()

            'Init objBClaimTemplate object
            objBClaimTemplate.ConnectionString = Session("ConnectionString")
            objBClaimTemplate.DBServer = Session("DBServer")
            objBClaimTemplate.InterfaceLanguage = Session("InterfaceLanguage")
            objBClaimTemplate.Initialize()

            ' Init objBIssue object
            objBIssue.ConnectionString = Session("ConnectionString")
            objBIssue.DBServer = Session("DBServer")
            objBIssue.InterfaceLanguage = Session("InterfaceLanguage")
            objBIssue.Initialize()

            ' Init objBDB object
            objBDB.InterfaceLanguage = Session("InterfaceLanguage")
            objBDB.DBServer = Session("DBServer")
            objBDB.ConnectionString = Session("ConnectionString")
            Call objBDB.Initialize()
        End Sub

        ' Bind Script method
        Private Sub BindScript()
            'Bind Page Script Source            
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("EditClaimLetterJs", "<script language='javascript' src='../js/Claim/WEditClaimLetter.js'></script>")
            btnPreview.Attributes.Add("OnClick", "javascript:EditSubmit('Preview');return(false);")
            btnPrint.Attributes.Add("OnClick", "javascript:EditSubmit('Print');return(false);")
            btnSendEmail.Attributes.Add("OnClick", "javascript:if(CheckNull(document.forms[0].txtEmailAddress) || !CheckValidEmail(document.forms[0].txtEmailAddress)){alert('" & lblMailError.Text & "');document.forms[0].txtEmailAddress.focus();return(false);}else{EncryptionTags();return(true);}")
            'txtReceivedDate.Attributes.Add("OnChange", "return CheckDate(this, '" & Session("DateFormat") & "', '" & ddlLabel.Items(2).Text & " (" & Session("DateFormat") & ")');")
        End Sub

        ' Send Email method return true if successfull else false
        Private Function SendEmail() As Boolean
            Dim intSendMail As Int16 = 0
            Dim strMailTo As String
            Dim strContentOut As String
            Dim intIndex As Integer = 0
            Dim intCount As Integer = 0

            ' clsBClaimTemplate.Metric is a metric have two arrays
            Dim objMetric As New clsBClaimTemplate.Metric
            ReDim objMetric.arrStrOutMsg(0)
            ReDim objMetric.arrStrEmailAddress(0)
            Dim boolSendEmail As Boolean
            objMetric.arrStrOutMsg(0) = Editor.Text.Replace("&lt;", "<").Replace("&gt;", ">")
            objMetric.arrStrEmailAddress(0) = txtEmailAddress.Text

            For intIndex = 0 To UBound(objMetric.arrStrEmailAddress)
                If Not IsDBNull(objMetric.arrStrEmailAddress(intIndex)) Then
                    strMailTo = objMetric.arrStrEmailAddress(intIndex)
                    strContentOut = objMetric.arrStrOutMsg(intIndex)
                    intSendMail = SendMail(lblEmailTitle.Text, strContentOut, strMailTo, True, "")
                    If intSendMail = 1 Then
                        intCount = intCount + 1
                    End If
                End If
            Next

            If intCount > 0 Then 'send email successcul
                ' Update Claim date
                Call objBIssue.UpdateClaimDate(Request.QueryString("ItemID"), Request.QueryString("ClaimMode"))

                ' Write error
                Call WriteErrorMssg(lblErrorMsg.Text, objBIssue.ErrorMsg, lblErrorCode.Text, objBIssue.ErrorCode)

                Page.RegisterClientScriptBlock("SendEmailSuccessfulJs", "<script language='javascript'>alert('" & lblSendEmailSuccessful.Text & "');</script>")
            Else
                Page.RegisterClientScriptBlock("SendEmailUnSuccessfulJs", "<script language='javascript'>alert('" & lblSendEmailUnSuccessful.Text & ", Error at: " & objBClaimTemplate.ErrorMsg & " ');</script>")
            End If
        End Function

        Private Sub btnSendEmail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSendEmail.Click
            If Page.IsValid Then
                Call SendEmail()
            End If
            Editor.Text = Editor.Text.Replace("&lt;", "<").Replace("&gt;", ">")
        End Sub
        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBClaimTemplate Is Nothing Then
                    objBClaimTemplate.Dispose(True)
                    objBClaimTemplate = Nothing
                End If
                If Not objBIssue Is Nothing Then
                    objBIssue.Dispose(True)
                    objBIssue = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub


    End Class
End Namespace