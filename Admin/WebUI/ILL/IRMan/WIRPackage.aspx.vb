' class WIRPackage.aspx
' Purpose: 
' Creator: Sondp
' CreatedDate: 25/11/2004
' Modification History:
' Review code : lent 25-4-2005

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.ILL

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WIRPackage
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

        Private objBILLInR As New clsBILLInRequest
        Private objBCTemplate As New clsBCommonTemplate

        ' Event : Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                If Request("ILLID") Is Nothing Or Request("ILLID") = "" Then
                    hidILLID.Value = 0
                Else
                    hidILLID.Value = Request("ILLID")
                End If
                Call BindData()
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Initialize objBILLInR object
            objBILLInR.ConnectionString = Session("ConnectionString")
            objBILLInR.InterfaceLanguage = Session("InterfaceLanguage")
            objBILLInR.DBServer = Session("DBServer")
            objBILLInR.Initialize()
            ' Initialize objBCTemplate object
            objBCTemplate.ConnectionString = Session("ConnectionString")
            objBCTemplate.InterfaceLanguage = Session("InterfaceLanguage")
            objBCTemplate.DBServer = Session("DBServer")
            objBCTemplate.Initialize()
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(153) Then
                Page.RegisterClientScriptBlock("AccessDeniedJS", "<script language = 'javascript'>alert('" & ddlLabel.Items(2).Text & "');self.close();</script>")
                Response.End()
            End If
        End Sub

        ' BindData method
        Private Sub BindData()
            Dim tblTemplate As New DataTable
            objBCTemplate.TemplateID = 0
            objBCTemplate.TemplateType = 12
            tblTemplate = objBCTemplate.GetTemplate
            ' Write Error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBCTemplate.ErrorMsg, ddlLabel.Items(1).Text, objBCTemplate.ErrorCode)

            If Not tblTemplate Is Nothing Then
                If tblTemplate.Rows.Count > 0 Then
                    ddlTemplate.DataSource = tblTemplate
                    ddlTemplate.DataTextField = "Title"
                    ddlTemplate.DataValueField = "ID"
                    ddlTemplate.DataBind()
                End If
            End If
        End Sub
        ' Bind script method
        Private Sub BindScript()
            btnClose.Attributes.Add("OnClick", "javascript:self.close();return(false);")
            btnPrint.Attributes.Add("OnClick", "javascript:if(document.forms[0].ddlTemplate.options[document.forms[0].ddlTemplate.options.selectedIndex].value==0 || document.forms[0].ddlTemplate.options.length<=0){return(false);}else{return(true);}")
            ddlTemplate.Attributes.Add("OnChange", "javascript:document.forms[0].hdTemplateID.value=this.value;return(false);")
        End Sub

        Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
            objBILLInR.TemplateID = hdTemplateID.Value
            lblDisplay.Text = objBILLInR.PackageIR(hidILLID.Value).Replace("<~>", vbCrLf)
            ' Write Error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLInR.ErrorMsg, ddlLabel.Items(1).Text, objBILLInR.ErrorCode)

            If lblDisplay.Text <> "" Then
                lblDisplay.Visible = True
                'btnClose.Visible = True
                btnPrint.Visible = False
                ddlTemplate.Visible = False
                lblMainTitle.Visible = False
                lblTemplate.Visible = False
            Else
                Page.RegisterClientScriptBlock("NOJs", "<script language='javascript'>alert('" & ddlLabel.Items(3).Text & "');</script>")
            End If
            Page.RegisterClientScriptBlock("PrintActionJs", "<script language='javascript'>self.focus();setTimeout('self.print()', 1);</script>")
            'Call BindData()
        End Sub
        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBILLInR Is Nothing Then
                    objBILLInR.Dispose(True)
                    objBILLInR = Nothing
                End If
                If Not objBCTemplate Is Nothing Then
                    objBCTemplate.Dispose(True)
                    objBCTemplate = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace

