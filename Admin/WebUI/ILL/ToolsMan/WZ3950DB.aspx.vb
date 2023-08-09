' Class: WZ3950DB
' Puspose: Management data of Z3950 server
' Creator: Lent
' CreatedDate: 02/12/2004
' Modification History:

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.ILL

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WZ3950DB
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

        Private objBZDBS As New clsBZ3950Server
        Private objBCDBS As New clsBCommonDBSystem

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJavascript()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Initialize method
        ' Purpose: init all neccessary objects
        Private Sub Initialize()
            ' Init objBZDBS object
            objBZdbs.InterfaceLanguage = Session("InterfaceLanguage")
            objBZdbs.DBServer = Session("DBServer")
            objBZdbs.ConnectionString = Session("ConnectionString")
            Call objBZDBS.Initialize()

            ' Init objBCDBS object
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            Call objBCDBS.Initialize()
        End Sub

        ' BindJavascript method
        ' Purpose: include all neccessary javascript functions
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WZ3950DBJs", "<script language = 'javascript' src = '../Js/ToolsMan/WZ3950DB.js'></script>")
            btnReset.Attributes.Add("Onclick", "javascript:document.forms[0].reset();return false;")
            btnClose.Attributes.Add("Onclick", "javascript:self.close();")
            btnAddnew.Attributes.Add("Onclick", "javascript:if(trim(document.forms[0].txtNameDB.value)=='') { alert(document.forms[0].ipAlertEmpty.value); document.forms[0].txtNameDB.focus(); return false;} else return true;")
        End Sub

        ' BindData method
        Private Sub BindData()
            Dim intServerID As Integer = 0
            If Request("intServerID") & "" <> "" Then
                intServerID = CInt(Request("intServerID"))
            Else
                If Request("ipServerID") & "" <> "" Then
                    intServerID = CInt(Request("ipServerID"))
                End If
            End If

            txtDescription.Text = ""
            txtNameDB.Text = ""
            ipServerID.Value = CStr(intServerID)
            objBZDBS.ServerID = intServerID
            dtgZServerDB.DataSource = objBZDBS.GetZServerDB
            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBZDBS.ErrorMsg, ddlLabel.Items(0).Text, objBZDBS.ErrorCode)

            dtgZServerDB.DataBind()
        End Sub

        ' btnAddnew_Click event
        ' Purpose: add new item
        Private Sub btnAddnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddnew.Click
            Dim intResult As Integer
            objBZDBS.DBName = txtNameDB.Text
            objBZDBS.Description = txtDescription.Text
            objBZDBS.ServerID = CStr(ipServerID.Value)
            intResult = objBZDBS.AddNewDB()
            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBZDBS.ErrorMsg, ddlLabel.Items(0).Text, objBZDBS.ErrorCode)

            If intResult = 0 Then
                ' WriteLog
                Call WriteLog(67, ddlLabel.Items(7).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                Page.RegisterClientScriptBlock("JSSucc", "<script language='javascript'>alert('" & ddlLabel.Items(11).Text & "');</script>")
            Else
                Page.RegisterClientScriptBlock("JSSucc", "<script language='javascript'>alert('" & ddlLabel.Items(12).Text & "');</script>")
            End If
            ' Refresh Data
            Call BindData()
        End Sub

        ' dtgZServerDB_EditCommand event
        Private Sub dtgZServerDB_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgZServerDB.EditCommand
            dtgZServerDB.EditItemIndex = e.Item.ItemIndex
            Call BindData()
        End Sub

        ' dtgZServerDB_CancelCommand event
        Private Sub dtgZServerDB_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgZServerDB.CancelCommand
            dtgZServerDB.EditItemIndex = -1
            Call BindData()
        End Sub

        ' dtgZServerDB_DeleteCommand event
        Private Sub dtgZServerDB_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgZServerDB.DeleteCommand
            Dim intID As Integer

            ' Get ID             
            intID = CInt(e.Item.Cells(0).Text)

            'Delete here
            objBZDBS.DBID = intID
            Call objBZDBS.DeleteDB()
            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBZDBS.ErrorMsg, ddlLabel.Items(0).Text, objBZDBS.ErrorCode)
            ' WriteLog
            Call WriteLog(67, ddlLabel.Items(6).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

            ' Refresh Data
            dtgZServerDB.EditItemIndex = -1
            Call BindData()
        End Sub

        ' dtgZServerDB_UpdateCommand event
        Private Sub dtgZServerDB_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgZServerDB.UpdateCommand
            Dim intResult As Integer
            Dim ttxtNameDB As TextBox = CType(e.Item.Cells(2).FindControl("txtNameDBdtg"), TextBox)
            Dim ttxtDescription As TextBox = CType(e.Item.Cells(3).FindControl("dtxtDescription"), TextBox)
            Dim intID As Integer

            ' Get ID             
            intID = CInt(e.Item.Cells(0).Text)
            If ttxtNameDB.Text <> "" Then
                objBZDBS.DBName = ttxtNameDB.Text
                objBZDBS.Description = ttxtDescription.Text
                objBZDBS.ServerID = CStr(ipServerID.Value)
                objBZDBS.DBID = intID
                intResult = objBZDBS.UpdateDB()
                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBZDBS.ErrorMsg, ddlLabel.Items(0).Text, objBZDBS.ErrorCode)

                If intResult = 0 Then
                    ' WriteLog
                    Call WriteLog(67, ddlLabel.Items(8).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                    Page.RegisterClientScriptBlock("JSSucc", "<script language='javascript'>alert('" & ddlLabel.Items(11).Text & "');</script>")
                    ' Refresh Data
                    dtgZServerDB.EditItemIndex = -1
                    Call BindData()
                Else
                    Page.RegisterClientScriptBlock("JSSucc", "<script language='javascript'>alert('" & ddlLabel.Items(12).Text & "');</script>")
                End If
            End If
        End Sub

        ' dtgZServerDB_ItemCreated event
        Private Sub dtgZServerDB_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgZServerDB.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                    Dim tlcTableC1 As TableCell
                    Dim tlcTableC2 As TableCell
                    Dim txtdtTemp As New TextBox
                    Dim txtdtTemp1 As New TextBox
                    Dim lnkdtgUpdate As LinkButton
                    Dim myDeleteButton As LinkButton
                    Dim strError1 As String
                    Dim strError2 As String

                    txtdtTemp = CType(e.Item.FindControl("txtNameDBdtg"), TextBox)
                    If Not txtdtTemp Is Nothing Then
                        txtdtTemp.Attributes.Add("Onchange", "if (CheckNull(this)) {alert('" & ddlLabel.Items(4).Text & "'); return false;};")
                        strError1 = txtdtTemp.Text
                    End If

                    tlcTableC1 = e.Item.Cells(6)
                    tlcTableC2 = e.Item.Cells(5)
                    myDeleteButton = tlcTableC1.Controls(0)
                    myDeleteButton.Attributes.Add("Onclick", "swapBG(this,'red'); if (confirm(' " & ddlLabel.Items(3).Text & " ')==false) {swapBG(this,'red');return false}")

                    lnkdtgUpdate = tlcTableC2.Controls(0)
                    If Not lnkdtgUpdate Is Nothing Then
                        lnkdtgUpdate.Attributes.Add("OnClick", "javascript:return(CheckInserUpdate('document.forms[0].dtgZServer__ctl" & CStr(e.Item.ItemIndex + 2) & "_','" & ddlLabel.Items(4).Text & "'));")
                    End If
            End Select
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBZDBS Is Nothing Then
                    objBZDBS.Dispose(True)
                    objBZDBS = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace