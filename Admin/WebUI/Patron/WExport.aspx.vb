' Class: WExport
' Puspose: export data
' Creator: Sondp
' CreatedDate: 21-1-2005
' Modification History:
'   - 13/05/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Patron

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WExport
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
        Private objBPT As New clsBPatronTemplate
        Private objBPC As New clsBPatronCollection

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            lnkPhysicalPath.Visible = False
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub
        ' CheckFormPermission method
        ' Purpose: check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(216) Then
                Call WriteErrorMssg(ddlLabel.Items(9).Text)
            End If
        End Sub
        ' Method: Initialize
        Private Sub Initialize()
            ' Initialize objBPT object
            objBPT.DBServer = Session("DBServer")
            objBPT.ConnectionString = Session("ConnectionString")
            objBPT.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPT.Initialize()

            ' Initialize objBPC object
            objBPC.DBServer = Session("DBServer")
            objBPC.ConnectionString = Session("ConnectionString")
            objBPC.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPC.initialize()
        End Sub

        ' BindJS method
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WExportJs", "<script language = 'javascript' src = 'js/WExport.js'></script>")

            btnExport.Attributes.Add("OnClick", "return(CheckExport('" & ddlLabel.Items(4).Text & "','" & ddlLabel.Items(5).Text & "'));")
            btnReset.Attributes.Add("OnClick", "document.forms[0].reset();return(false);")

            txtFromID.Attributes.Add("OnChange", "if (!CheckInt(this, '" & ddlLabel.Items(7).Text & "')) {this.focus(); this.value=0;}")
            txtToID.Attributes.Add("OnChange", "if (!CheckInt(this, '" & ddlLabel.Items(7).Text & "')) {this.focus(); this.value=0;}")
        End Sub

        ' BindData method
        Private Sub BindData()
            Dim tblTemplate As New DataTable
            Dim lsItem As New ListItem

            objBPT.TemplateID = 0
            objBPT.TemplateType = 31
            tblTemplate = objBPT.GetPatronTemplate
            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPT.ErrorMsg, ddlLabel.Items(1).Text, objBPT.ErrorCode)

            If Not tblTemplate Is Nothing Then
                ddlTemplate.DataSource = InsertOneRow(tblTemplate, ddlLabel.Items(3).Text)
                ddlTemplate.DataTextField = "Title"
                ddlTemplate.DataValueField = "ID"
                ddlTemplate.DataBind()
            Else
                lsItem.Value = "0"
                lsItem.Text = ddlLabel.Items(3).Text
                ddlTemplate.Items.Add(lsItem)
            End If
            lsItem = Nothing
            tblTemplate = Nothing
        End Sub

        ' Event: btnExport_Click
        Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
            Dim objPatron()
            Dim intCounter As Integer
            Dim strFilename As String
            Dim intFromID As Integer
            Dim intToID As Integer
            Dim intFileTypeID As Integer

            objBPT.TemplateID = ddlTemplate.SelectedItem.Value
            objBPT.TemplateType = 31
            intFromID = 0
            intToID = 0

            If Not Trim(txtFromID.Text) = "" And IsNumeric(txtFromID.Text) Then
                intFromID = CInt(txtFromID.Text)
            End If
            If Not Trim(txtToID.Text) = "" And IsNumeric(txtToID.Text) Then
                intToID = CInt(txtToID.Text)
            End If
            If txtSeperator.Text = "" Then
                txtSeperator.Text = "#"
            End If
            If optXML.Checked Then
                intFileTypeID = 1
            Else
                intFileTypeID = 0
            End If
            If CInt(ddlTemplate.SelectedItem.Value) > 0 Then
                Try
                    strFilename = objBPC.Export(ddlTemplate.SelectedItem.Value, 31, intFromID, intToID, txtSeperator.Text, Server.MapPath(""), intFileTypeID)
                Catch ex As Exception
                    Page.RegisterClientScriptBlock("JSSucc", "<script language='javascript'>alert('" & ddlLabel.Items(8).Text & "');</script>")
                    Exit Sub
                End Try
                ' Write error
                ' Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPC.ErrorMsg, ddlLabel.Items(1).Text, objBPC.ErrorCode)

                If Trim(strFilename & "") <> "" Then
                    lnkPhysicalPath.Visible = True
                    Session("FileName") = strFilename
                    lnkPhysicalPath.NavigateUrl = "#"
                    lnkPhysicalPath.Attributes.Add("Onclick", "javascript:parent.hiddenbase.location.href='../Common/WSaveTempFile.aspx?ModuleID=2&bol=1&FileName=abc';")
                    ' WriteLog
                    Call WriteLog(119, ddlLabel.Items(6).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                Else
                    Page.RegisterClientScriptBlock("JSSucc", "<script language='javascript'>alert('" & ddlLabel.Items(8).Text & "');</script>")
                End If
            End If
        End Sub

        ' Page_Unload method
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBPT Is Nothing Then
                objBPT.Dispose(True)
                objBPT = Nothing
            End If
            If Not objBPC Is Nothing Then
                objBPC.Dispose(True)
                objBPC = Nothing
            End If
        End Sub
    End Class
End Namespace