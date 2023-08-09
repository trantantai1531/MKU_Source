Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.ILL

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WSearchPatron
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

        Private objBILLOR As New clsBILLOutRequest

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindScript()
            dgrPatronResult.Visible = False
        End Sub

        ' CheckFormPermission method
        Private Sub CheckFormPermission()
            If Not CheckPemission(154) Then
                Page.RegisterClientScriptBlock("invaliduser", "<script language='javascript'>alert('" & ddlLabel.Items(2).Text & "'); self.close();</script>")
                Response.End()
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Initilaize objBILLOR object
            objBILLOR.ConnectionString = Session("ConnectionString")
            objBILLOR.InterfaceLanguage = Session("InterfaceLanguage")
            objBILLOR.DBServer = Session("DBServer")
            objBILLOR.Initialize()
        End Sub

        ' Bind Script method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("SearchPatronJs", "<script language='javascript' src='../JS/ORMan/WSearchPatron.js'></script>")
            btnReset.Attributes.Add("OnClick", "javascript:document.forms[0].txtPatronName.value='';document.forms[0].txtPatronCode.value='';return(false);")
            btnClose.Attributes.Add("OnClick", "javascript:self.close();return(false);")
        End Sub

        ' Search Patron method
        ' In: PatronFullName, PatronCode
        Private Sub GetPatronInfor()
            Dim tblPatronInfor As New DataTable
            tblPatronInfor = objBILLOR.SearchPatron(txtPatronName.Text, txtPatronCode.Text)
            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLOR.ErrorMsg, ddlLabel.Items(1).Text, objBILLOR.ErrorCode)
            If Not tblPatronInfor Is Nothing Then
                If tblPatronInfor.Rows.Count > 0 Then
                    dgrPatronResult.Visible = True
                    dgrPatronResult.DataSource = tblPatronInfor
                    dgrPatronResult.DataBind()
                Else
                    Page.RegisterClientScriptBlock("NotFound", "<script language='javascript'>alert('" & ddlLabel.Items(3).Text & "')</script>")
                End If
            Else
                Page.RegisterClientScriptBlock("NotFound", "<script language='javascript'>alert('" & ddlLabel.Items(3).Text & "')</script>")
            End If
        End Sub

        ' dgrPatronResult_PageIndexChanged event
        Private Sub dgrPatronResult_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrPatronResult.PageIndexChanged
            dgrPatronResult.CurrentPageIndex = e.NewPageIndex
            Call GetPatronInfor()
        End Sub

        ' btnSearch_Click event
        Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            Call GetPatronInfor()
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBILLOR Is Nothing Then
                    objBILLOR.Dispose(True)
                    objBILLOR = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace

