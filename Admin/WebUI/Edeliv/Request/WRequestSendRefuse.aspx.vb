'Class WRequestSendRefuse
'Puspose: Using template get data send email or preview
'Creator: Tuanhv
'CreatedDate: 28/10/2004
'Modification History:

Imports System
Imports eMicLibAdmin.BusinessRules.Edeliv
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WRequestSendRefuse
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblSelectPaterm As System.Web.UI.WebControls.Label
        Protected WithEvents lblOutMsg As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        '***************************************DECLARE VARIABLES*******************************************
        Private objBETemplate As New clsBETemplate
        Private objBCommonTemplate As New clsBCommonTemplate
        Private objERequest As New clsBERequest
        Private objBDB As New clsBCommonDBSystem
        Private objMetric As clsBETemplate.Metric
        Dim strContent, strEmailAddress As String

        '*************************************END DECLARE VARIABLES*****************************************

        'Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPemission()
            'Init alls object 
            Call Initialize()
            Call BindScript()
            'Sub  create active for controls
            Call ActiveControl(True)

            If Not Page.IsPostBack Then
                'Show data
                Call BindData()
            End If
        End Sub

        ' CheckFormPemission method
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            If Not CheckPemission(159) Then
                Call WriteErrorMssg(ddlLabel.Items(4).Text)
            End If
        End Sub

        'BindData method
        'Input: Type template
        'Purpose: Get name all template in database
        Private Sub BindData()
            Dim tblTemplate As DataTable = Nothing
            Dim lItem As New ListItem

            'Get all template to bind to dropdownlist Caption
            objBCommonTemplate.TemplateID = 0
            objBCommonTemplate.TemplateType = Request("TemplateType")

            'Set default templatetype, test
            objBCommonTemplate.TemplateType = 18

            tblTemplate = objBCommonTemplate.GetTemplate

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(6).Text, objBCommonTemplate.ErrorMsg, ddlLabel.Items(5).Text, objBCommonTemplate.ErrorCode)

            If Not tblTemplate Is Nothing And Not IsDBNull(tblTemplate) AndAlso tblTemplate.Rows.Count > 0 Then
                ddlFormatName.DataSource = InsertOneRow(tblTemplate, ddlLabel.Items(3).Text)
                ddlFormatName.DataTextField = "Title"
                ddlFormatName.DataValueField = "ID"
                ddlFormatName.DataBind()
                ddlFormatName.Items(0).Selected = True
            Else
                ddlFormatName.Items.Clear()
                lItem.Text = ddlLabel.Items(3).Text
                lItem.Value = 0
                ddlFormatName.Items.Add(lItem)
            End If
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("ShelfJs", "<script language='javascript' src='../Js/Request/WRequestSendRefuse.js'></script>")
            btnPrintLetter.Attributes.Add("OnClick", "return CheckIt('" & ddlLabel.Items(7).Text & "');")
            btnSendEmail.Attributes.Add("OnClick", "return CheckIt('" & ddlLabel.Items(7).Text & "');")
        End Sub

        ' Preview Letter method
        Public Sub PrevieViewLetter()
            Dim intRow As Integer = 0
            Dim intCount As Integer = 0
            Dim intTempType As Integer
            Dim lngRequestID As Integer
            Dim intIndex As Integer
            'Template Header default
            intCount = ddlHerderColumn.Items.Count - 1
            For intRow = 0 To intCount
                objBETemplate.HeaderData.Add((ddlHerderColumn.Items(intRow).Text), ddlHerderColumn.Items(intRow).Value)
            Next

            'Template footer default
            intCount = ddlFooterColumn.Items.Count - 1
            For intRow = 0 To intCount
                objBETemplate.FooterData.Add((ddlFooterColumn.Items(intRow).Text), ddlFooterColumn.Items(intRow).Value)
            Next

            'Template Body Data
            intCount = ddlBodyColumn.Items.Count - 1
            For intRow = 0 To intCount
                objBETemplate.ContentData.Add((ddlBodyColumn.Items(intRow).Text), ddlBodyColumn.Items(intRow).Value)
            Next

            'Set default template and request
            intTempType = 18
            lngRequestID = CLng(Request("RequestID"))

            objBETemplate.TemplateID = ddlFormatName.SelectedValue
            objMetric = objBETemplate.PreviewTemplateInfor(intTempType, lngRequestID)

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(6).Text, objBCommonTemplate.ErrorMsg, ddlLabel.Items(5).Text, objBCommonTemplate.ErrorCode)

            If Not objMetric.arrStrOutMsg Is Nothing Then
                strContent = objMetric.arrStrOutMsg(0)
                strEmailAddress = objMetric.arrStrEmailAddress(0)
            End If
        End Sub

        ' SetData for Header, Body, Footer and call GenClaimTemplate() method
        Private Sub SendEmail()
            'display(Letter)
            Call PrevieViewLetter()

            ' Send Email here
            Dim boolSendeMail As Boolean
            boolSendeMail = CheckSendEmail()

            If boolSendeMail Then
                Page.RegisterClientScriptBlock("AlertSendMailJs", "<script language='javascript'>alert('" & ddlLabel.Items(1).Text & "')</script>")
                'Update Status=2 (create by chuyenpt 04-06-2007)
                objBDB.SQLStatement = "UPDATE Edl_tblRequest SET StatusID=2 where RequestID=" & CInt(Request("RequestID"))
                objBDB.ProcessItem()
                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(6).Text, objBDB.ErrorMsg, ddlLabel.Items(5).Text, objBDB.ErrorCode)
                Page.RegisterClientScriptBlock("CloseJs", "<script language='javascript'>self.close();</script>")
            End If
        End Sub

        'CheckSendEmail method return true if successful or false if Unsuccessful
        Private Function CheckSendEmail() As Boolean
            Dim intSucess As Integer = 0
            Dim strSubject As String = ddlLabel.Items(0).Text

            CheckSendEmail = False
            Call SendMail(strSubject, strContent, strEmailAddress, True)
            Call WriteErrorMssg(ddlLabel.Items(6).Text, ErrorMsg, ddlLabel.Items(5).Text, ErrorCode)
            CheckSendEmail = True
        End Function

        'SendEmail event
        Private Sub btnSendEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendEmail.Click
            Call SendEmail()
        End Sub

        'PrintLetter event
        Private Sub btnPrintLetter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintLetter.Click

            'Set activecontrol for control in form
            Call ActiveControl(False)

            'Get content for email
            Call PrevieViewLetter()

            lblContents.Text = strContent & "<P Style='Page-break-before:always'>"
            Response.Write(strContent & "<P Style='Page-break-before:always'>")

            'Print content email
            Page.RegisterClientScriptBlock("PrintLetterJs", "<script language='javascript'>self.focus();setTimeout('self.print()', 1);</script>")
        End Sub

        'Sub ActiveControl: Active all control in form
        Private Sub ActiveControl(ByVal value As Boolean)
            ddlFormatName.Visible = value
            btnPrintLetter.Visible = value
            btnSendEmail.Visible = value
            lblFormat.Visible = value
        End Sub


        'Initialize method
        Private Sub Initialize()
            'Init objBBClaimTemplate object
            objBETemplate.ConnectionString = Session("ConnectionString")
            objBETemplate.DBServer = Session("DBServer")
            objBETemplate.InterfaceLanguage = Session("InterfaceLanguage")
            objBETemplate.Initialize()

            'Init objBCommonTemplate object
            objBCommonTemplate.ConnectionString = Session("ConnectionString")
            objBCommonTemplate.DBServer = Session("DBServer")
            objBCommonTemplate.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonTemplate.Initialize()

            'Init objERequest object
            objERequest.ConnectionString = Session("ConnectionString")
            objERequest.DBServer = Session("DBServer")
            objERequest.InterfaceLanguage = Session("InterfaceLanguage")
            objERequest.Initialize()

            'Bind main javscript to from
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/Tool/WBillTemplateMan.js'></script>")

            'Set default value for email
            strContent = ""
            strEmailAddress = ""

            'Init objBDB object
            objBDB.ConnectionString = Session("ConnectionString")
            objBDB.DBServer = Session("DBServer")
            objBDB.InterfaceLanguage = Session("InterfaceLanguage")
            objBDB.Initialize()
        End Sub

        'Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        'Dispose method
        'Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBETemplate Is Nothing Then
                    objBETemplate.Dispose(True)
                    objBETemplate = Nothing
                End If
                If Not objBCommonTemplate Is Nothing Then
                    objBCommonTemplate.Dispose(True)
                    objBCommonTemplate = Nothing
                End If
                If Not objERequest Is Nothing Then
                    objERequest.Dispose(True)
                    objERequest = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace