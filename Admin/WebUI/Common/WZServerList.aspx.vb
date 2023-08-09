' Class: WZServerList
' Puspose: Show ZServer List
' Creator: Lent
' CreatedDate: 22/10/2004

Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Common
    Partial Class WZServerList
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

        'Declare variables
        Private objBZdbs As New clsBZ3950

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            If Page.IsPostBack = False Then
                Call BindData()
            End If
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            'Init objBZdbs object
            objBZdbs.InterfaceLanguage = Session("InterfaceLanguage")
            objBZdbs.DBServer = Session("DBServer")
            objBZdbs.ConnectionString = Session("ConnectionString")
            Call objBZdbs.Initialize()
            btnClose.Attributes.Add("onClick", "self.close();")
        End Sub

        ' BindData method
        ' Purpose: Create Z3950 server list
        Private Sub BindData()
            Dim tblResult As DataTable

            tblResult = objBZdbs.GetZServerList

            ' Write error
            Call WriteErrorMssg(ddlLabelNote.Items(0).Text, objBZdbs.ErrorMsg, ddlLabelNote.Items(1).Text, objBZdbs.ErrorCode)

            If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                dtgZDbs.DataSource = tblResult
                dtgZDbs.DataBind()
            End If
        End Sub

        ' BindJS method
        ' Include all neccessary javascript function
        Public Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = 'eMicLibCommon.js'></script>")
            Page.RegisterClientScriptBlock("WZFindJs", "<script language = 'javascript' src = 'WZFind.js'></script>")

            btnClose.Attributes.Add("onClick", "self.close();")
        End Sub

        Private Sub dtgZDbs_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgZDbs.DeleteCommand

        End Sub
        Private Sub dtgZDbs_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgZDbs.EditCommand

            Dim intIndex As Integer = CInt(e.Item.ItemIndex)
            dtgZDbs.EditItemIndex = intIndex

            BindData()
        End Sub
        Private Sub dtgZDbs_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgZDbs.UpdateCommand
            Dim intIndex As Integer = e.Item.ItemIndex
            Dim intID As Integer = CInt(dtgZDbs.DataKeys(intIndex).ToString())

            Dim strName As String = CType(e.Item.Cells(0).Controls(0), TextBox).Text
            Dim strHost As String = CType(e.Item.Cells(1).Controls(0), TextBox).Text
            Dim strPort As String = CType(e.Item.Cells(2).Controls(0), TextBox).Text
            Dim strAccount As String = CType(e.Item.Cells(3).Controls(0), TextBox).Text
            Dim strPassword As String = CType(e.Item.Cells(4).Controls(0), TextBox).Text
            Dim strDBName As String = CType(e.Item.Cells(5).Controls(0), TextBox).Text
            Dim strDescription As String = CType(e.Item.Cells(6).Controls(0), TextBox).Text

            Try
                Dim intResult As Integer = objBZdbs.UpdZServer(intID, strName.Trim, strHost.Trim, CInt(strPort.Trim), strAccount.Trim, strPassword.Trim, strDBName.Trim, strDescription.Trim)
                If intResult = 0 Then

                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(2).Text & "');</script>")
                    dtgZDbs.EditItemIndex = -1
                    BindData()
                Else
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(3).Text & "');</script>")
                End If
            Catch ex As Exception
                Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(3).Text & "');</script>")
            End Try
        End Sub
        Private Sub dtgZDbs_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgZDbs.CancelCommand
            dtgZDbs.EditItemIndex = -1

            BindData()
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose()
        End Sub

        ' Method: Dispose
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBZdbs Is Nothing Then
                    objBZdbs.Dispose(True)
                    objBZdbs = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
        Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
            Try
                Dim intResult As Integer = objBZdbs.InsZServer(txtName.Text.Trim, txtHost.Text.Trim, CInt(txtPort.Text.Trim), txtAccount.Text.Trim, txtPassword.Text.Trim, txtDBName.Text.Trim, txtDescription.Text.Trim)
                If intResult = 0 Then

                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(0).Text & "');</script>")
                    BindData()
                Else
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(1).Text & "');</script>")
                End If
            Catch ex As Exception
                Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(1).Text & "');</script>")
            End Try
        End Sub

    End Class
End Namespace