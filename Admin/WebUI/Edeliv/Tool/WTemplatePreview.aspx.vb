'Puspose: Preview tempplate
'Creator: Tuanhv   
'CreatedDate: 09/11/2004
'Modification History:

Imports eMicLibAdmin.BusinessRules.Edeliv

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WTemplatePreview
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lbOption As System.Web.UI.WebControls.Label
        Protected WithEvents lbOption2 As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        '***************************************DECLARE VARIABLES*******************************************

        Private objETemplate As New clsBETemplate

        '*************************************END DECLARE VARIABLES*****************************************

        'Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPemission()
            'Init all object 
            Call Initialize()
            'Bind javscript
            Call BindScript()
            'Get data
            If Not Page.IsPostBack Then
                If Request("SelectPackTemplateMan") <> "" Then
                    lblPageTitle.Visible = True
                    Call SetDataPack()
                Else
                    lblPageTitle.Visible = False
                    Call SetData()
                End If
            End If
        End Sub

        ' CheckFormPemission method
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            If Not CheckPemission(161) Then
                ' Call WriteErrorMssg(lblLabel1.Text)
            End If
        End Sub

        'BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript'src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript'src = '../js/Tool/WTemplatePreview.js'></script>")
        End Sub

        'Initialize method
        'Purpose: init all necessary objects
        Private Sub Initialize()
            Response.Expires = 0

            'Init objETemplate object
            objETemplate.ConnectionString = Session("ConnectionString")
            objETemplate.DBServer = Session("DBServer")
            objETemplate.InterfaceLanguage = Session("InterfaceLanguage")
            objETemplate.Initialize()
        End Sub

        ' SetData for Header, Body, Footer and call GenClaimTemplate() method
        Private Sub SetData()
            Dim intRow As Integer = 0
            Dim intCount As Integer = 0

            'Get submit Information
            objETemplate.Header = Request("txtHeader").Replace("&lt;", "<").Replace("&gt;", ">")
            objETemplate.Collums = Request("txtCollum").Replace("&lt;", "<").Replace("&gt;", ">")
            objETemplate.CollumCaption = Request("txtCollumCaption").Replace("&lt;", "<").Replace("&gt;", ">")
            objETemplate.CollumWidth = Request("txtCollumWidth").Replace("&lt;", "<").Replace("&gt;", ">")
            objETemplate.CollumAlign = Request("txtAlign").Replace("&lt;", "<").Replace("&gt;", ">")
            objETemplate.CollumFormat = Request("txtFormat").Replace("&lt;", "<").Replace("&gt;", ">")
            objETemplate.Footer = Request("txtFooter").Replace("&lt;", "<").Replace("&gt;", ">")

            'Template Header default
            intCount = ddlHeadRequestInfo1.Items.Count - 1
            For intRow = 0 To intCount
                objETemplate.HeaderData.Add((ddlHeadRequestInfo1.Items(intRow).Text), ddlHeadRequestInfo1.Items(intRow).Value)
            Next

            'Template footer default
            intCount = ddlFootRequestInfo.Items.Count - 1
            For intRow = 0 To intCount
                objETemplate.FooterData.Add((ddlFootRequestInfo.Items(intRow).Text), ddlFootRequestInfo.Items(intRow).Value)
            Next

            'Template Body Data
            intCount = ddlBodyInfo.Items.Count - 1
            For intRow = 0 To intCount
                objETemplate.ContentData.Add((ddlBodyInfo.Items(intRow).Text), ddlBodyInfo.Items(intRow).Value)
                objETemplate.ContentData.Add((ddlColumnCaption.Items(intRow).Text), ddlColumnCaption.Items(intRow).Value)
            Next

            'ColumnCaption

            'Display ClaimTemplate
            lblOutMsg.Text = objETemplate.GenClaimTemplate
            ' Call WriteErrorMssg(lblLabel3.Text, objETemplate.ErrorMsg, lblLabel2.Text, objETemplate.ErrorCode)
        End Sub

        ' SetData for Header, Body, Footer and call GenClaimTemplate() method
        Private Sub SetDataPack()
            Dim intRow As Integer = 0
            Dim intCount As Integer = 0

            'Get submit Information
            objETemplate.Header = Request("txtContents").Replace("&lt;", "<").Replace("&gt;", ">")

            'Template Body Data
            intCount = ddlTemplatePack.Items.Count - 1
            For intRow = 0 To intCount
                objETemplate.HeaderData.Add((ddlTemplatePack.Items(intRow).Text), ddlTemplatePack.Items(intRow).Value)
            Next

            'Display ClaimTemplate
            lblOutMsg.Text = objETemplate.GenClaimTemplatePack
            ' Call WriteErrorMssg(lblLabel3.Text, objETemplate.ErrorMsg, lblLabel2.Text, objETemplate.ErrorCode)
        End Sub

        'Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        'Dispose method
        'Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objETemplate Is Nothing Then
                    objETemplate.Dispose(True)
                    objETemplate = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace