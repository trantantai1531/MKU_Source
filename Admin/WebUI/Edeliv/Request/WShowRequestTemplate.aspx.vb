'Class WBillTemplateMan
'Puspose: Using template get data send email or preview
'Creator: Tuanhv   
'CreatedDate: 28/10/2004
'Modification History:

Imports System
Imports eMicLibAdmin.BusinessRules.Edeliv
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WShowRequestTemplate
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

        '***************************************DECLARE VARIABLES*******************************************
        Private objBETemplate As New clsBETemplate
        Private objBCommonTemplate As New clsBCommonTemplate

        '*************************************END DECLARE VARIABLES*****************************************

        'Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Init alls object 
            Call Initialize()

            'Bind javascript
            '   Call BindScript()

            If Not Page.IsPostBack Then
                'Show data
                Call BindData()
            End If
        End Sub

        'BindData method
        'Input: Type template
        'Purpose: Get name all template in database
        Private Sub BindData()
            Dim tblTemplate As DataTable = Nothing
            Dim lstItem As New ListItem

            'Get all template to bind to dropdownlist Caption
            objBCommonTemplate.TemplateID = 0
            objBCommonTemplate.TemplateType = Request("TemplateType")

            'Set default templatetype, test
            objBCommonTemplate.TemplateType = 19
            tblTemplate = objBCommonTemplate.GetTemplate

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBCommonTemplate.ErrorMsg, ddlLabel.Items(1).Text, objBCommonTemplate.ErrorCode)

            If Not tblTemplate Is Nothing And Not IsDBNull(tblTemplate) AndAlso tblTemplate.Rows.Count > 0 Then
                ddlFormatName.DataSource = InsertOneRow(tblTemplate, ddlLabel.Items(2).Text)
                ddlFormatName.DataTextField = "Title"
                ddlFormatName.DataValueField = "ID"
                ddlFormatName.DataBind()
            Else
                lstItem.Text = ddlLabel.Items(2).Text
                lstItem.Value = 0
                ddlFormatName.Items.Add(lstItem)
            End If
        End Sub

        'SendEmail event
        Private Sub btnSendEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendEmail.Click
            Page.RegisterClientScriptBlock("SubmitPageJs", "<script language='javascript'>document.forms[0].action='../Tool/WTemplatePreview.aspx?Destination=EMAIL&RequestID= " & Request("RequestID") & "&TemplateID=" & ddlFormatName.SelectedValue & "';document.forms[0].method='post';document.forms[0].submit();</script>")
        End Sub

        'Initialize method
        Private Sub Initialize()
            'Init objBBClaimTemplate object
            objBETemplate.ConnectionString = Session("ConnectionString")
            objBETemplate.DBServer = Session("DBServer")
            objBETemplate.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBETemplate.Initialize()

            'Init objBCommonTemplate object
            objBCommonTemplate.ConnectionString = Session("ConnectionString")
            objBCommonTemplate.DBServer = Session("DBServer")
            objBCommonTemplate.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCommonTemplate.Initialize()

            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript'src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript'src = '../js/Tool/WBillTemplateMan.js'></script>")
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
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace