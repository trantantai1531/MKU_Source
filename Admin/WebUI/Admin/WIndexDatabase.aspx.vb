Imports eMicLibAdmin.BusinessRules.Admin
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibLogin
Imports System.IO

Namespace eMicLibAdmin.WebUI.Admin
    Partial Class WIndexDatabase
        Inherits clsWBase
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents tbnTestAll As System.Web.UI.WebControls.Button


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Dim objBLogin As New clsBLogin
        Dim objBCommon As New clsBCommonDBSystem
        Public tblData As DataTable

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            If (Session("DefaultDatabaseID") = Session("DatabaseID")) And (Session("UserID") = 1) Then
                Call Initialize()
                Call BindScript()
                If Not Page.IsPostBack Then
                    Call BindData()
                End If
            Else
                Me.WriteErrorMssg(ddlLabel.Items(2).Text)
            End If

        End Sub

        ' Method: BindScript
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJS", "<script language = 'javascript' src = 'Js/WIndexDatabase.js'></script>")
            btnAdd.Attributes.Add("Onclick", "return CheckUpdate('" & ddlLabel.Items(3).Text & "','" & ddlLabel.Items(4).Text & "','" & ddlLabel.Items(5).Text & "','" & ddlLabel.Items(6).Text & "','" & ddlLabel.Items(7).Text & "');")
            btnReset.Attributes.Add("Onclick", "ResetControl(); return true;")
        End Sub

        'Initialize method
        ' Purpose: Init all neccessary objects
        Private Sub Initialize()
            ' Init objBUser object
            objBLogin.ConnectionString = Session("ConnectionString")
            objBLogin.DBServer = Session("DBServer")
            objBLogin.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBLogin.Initialize()
            objBCommon.ConnectionString = Session("ConnectionString")
            objBCommon.DBServer = Session("DBServer")
            objBCommon.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCommon.Initialize()
        End Sub

        ' Method: BindData
        Private Sub BindData()
            'Put user code to initialize the page here
            Dim objLiboLogin As New clseMicLibLogin

            btnDelete.Visible = False
            lblNote2.Visible = False
            dtgDatabase.Visible = False
            tblData = objLiboLogin.GetDBConnection
            If Not tblData Is Nothing AndAlso tblData.Rows.Count > 0 Then
                dtgDatabase.DataSource = tblData
                dtgDatabase.DataBind()
                dtgDatabase.Visible = True
                btnDelete.Visible = True
                lblNote2.Visible = True
            End If
        End Sub


        ' Event: dtgDatabase_ItemCreated
        Private Sub dtgDatabase_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgDatabase.ItemCreated
            If Not (Not tblData Is Nothing AndAlso tblData.Rows.Count > 0) Then
                Exit Sub
            End If
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                    Dim tblCell As TableCell
                    Dim inti As Integer
                    Dim lblConnstr As Label
                    Dim lblServerDB As Label
                    Dim intIndex As Integer

                    'Dim chk As CheckBox
                    Dim lnk As HyperLink
                    Dim rdo As RadioButton

                    tblCell = e.Item.Cells(1)
                    lnk = CType(tblCell.FindControl("lnkDatabase"), HyperLink)

                    intIndex = e.Item.ItemIndex

                    Dim strUserName As String = ""
                    Dim strPassWordNew As String = ""
                    Dim strDataSource As String = ""
                    Dim strServerName As String = ""
                    Dim strServerIP As String
                    Dim intDatabase As Integer
                    strUserName = tblData.Rows(intIndex).Item("UserName")
                    strPassWordNew = tblData.Rows(intIndex).Item("PassWord")
                    strDataSource = tblData.Rows(intIndex).Item("DataSource")
                    strServerIP = tblData.Rows(intIndex).Item("ServerIP")
                    If tblData.Rows(intIndex).Item("DBServer") = "SQLSERVER" Then
                        intDatabase = 0
                    Else
                        intDatabase = 1
                    End If

                    If Not CheckConnection(strUserName, strPassWordNew, strDataSource, strServerIP, intDatabase) Then
                        e.Item.BackColor = Color.FromName("#95b9c7")
                    End If
                    lnk.Target = "Hiddenbase"

                    If DataBinder.Eval(e.Item.DataItem, "ID") = 1 Then
                        lnk.NavigateUrl = "javascript:parent.Hiddenbase.location.href = 'WDatabaseMan.aspx?ConnID=" & DataBinder.Eval(e.Item.DataItem, "ID") & "';"
                    Else
                        lnk.NavigateUrl = "javascript:parent.Hiddenbase.location.href = 'WDatabaseMan.aspx?ConnID=" & DataBinder.Eval(e.Item.DataItem, "ID") & "';"
                    End If
            End Select
        End Sub
        ' CheckConnection
        Private Function CheckConnection(ByVal strUserName As String, ByVal strPassWordNew As String, ByVal strDataSource As String, ByVal strServerIP As String, ByVal intDatabase As Integer) As Boolean
            Dim strConnection As String = ""
            Dim strConnectionBack As String = ""
            Dim strDBServer As String

            If intDatabase = 0 Then
                strDBServer = "SQLSERVER"
                strConnection = "Data Source=" & strServerIP & ";Initial Catalog=" & strDataSource & ";UID=" & strUserName & ";PWD=" & strPassWordNew & ";"
            Else
                strDBServer = "ORACLE"
                strConnection = "User ID=" & strUserName & ";Password=" & strPassWordNew & ";Data Source=" & strDataSource
            End If
            Try
                If objBCommon.CheckOpenConnection(strDBServer, strConnection) Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Return False
                Session("ConnectionString") = strConnectionBack
            End Try
        End Function

        ' Event: btnDelete_Click
        Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            Dim dtgItem As DataGridItem
            Dim chkSelected As CheckBox
            Dim strSelectedIDs As String

            ' Return the IDs string for deletting
            For Each dtgItem In dtgDatabase.Items
                chkSelected = dtgItem.FindControl("chkID")
                If chkSelected.Checked = True Then
                    strSelectedIDs = strSelectedIDs & CType(dtgItem.FindControl("lblID"), Label).Text & ","
                End If
            Next

            ' If checked, delete
            If strSelectedIDs <> "" Then
                strSelectedIDs = Left(strSelectedIDs, strSelectedIDs.Length - 1)
                Dim objLibollg As New clseMicLibLogin
                Call objLibollg.DeleteConnection(strSelectedIDs)
                objLibollg = Nothing
            End If
            Call BindData()
        End Sub

        ' Event: btnReset_Click
        Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
            Call BindData()
        End Sub

        'Event: btnAdd_Click
        Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
            Dim intConnId As Integer
            Dim objLibollg As New clseMicLibLogin
            intConnId = CInt(hidConnID.Value)
            ' Update password in database
            Dim strUserName As String = txtUserName.Text.Trim
            Dim strPasswordOld As String = txtPasswordOld.Text.Trim
            Dim strPasswordNew As String = txtPasswordNew.Text.Trim
            Dim strServerIP As String = txtServerIP.Text.Trim
            Dim strDataSource As String = txtDataSource.Text.Trim
            objLibollg.DBServer = "SQLSERVER"
            If ddlDatabase.SelectedIndex > 0 Then
                objLibollg.DBServer = "ORACLE"
            End If

            If intConnId > 0 Then
                ' chi update khi dang login vao conection hien tai
                Dim strConnection As String = ""

                If Session("DBServer") = "SQLSERVER" Then
                    strConnection = "Data Source=" & strServerIP & ";Initial Catalog=" & strDataSource & ";UID=" & strUserName & ";PWD=" & strPasswordOld & ";"
                Else
                    strConnection = "User ID=" & strUserName & ";Password=" & strPasswordOld & ";Data Source=" & strDataSource
                End If

                If CStr(Session("ConnectionString")).ToUpper = strConnection.ToUpper Then
                    objBLogin.UserName = strUserName
                    objBLogin.OldPassWord = strPasswordOld
                    objBLogin.PassWord = strPasswordNew
                    objBLogin.UpdatePassUser()
                End If
                objLibollg.UpdateConnection(intConnId, strUserName, strPasswordNew, strDataSource, strServerIP, txtConnectionName.Text.Trim, Me.chkRun.Checked)
            Else
                objLibollg.AddNewConnection(strUserName, strPasswordOld, strDataSource, strServerIP, txtConnectionName.Text.Trim, Me.chkRun.Checked)
            End If
            objLibollg = Nothing
            Call BindData()
            hidConnID.Value = 0
        End Sub

        Private Sub btnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest.Click
            Dim strUserName As String = ""
            Dim strPassWordNew As String = ""
            Dim strDataSource As String = ""
            Dim strServerIP As String
            Dim intDatabase As Integer
            strUserName = Trim(txtUserName.Text)
            If hidConnID.Value > 0 Then
                strPassWordNew = Trim(txtPasswordNew.Text)
            Else
                strPassWordNew = Trim(txtPasswordOld.Text)
            End If

            strDataSource = Trim(txtDataSource.Text)
            strServerIP = Trim(txtServerIP.Text)
            intDatabase = ddlDatabase.SelectedValue()
            If CheckConnection(strUserName, strPassWordNew, strDataSource, strServerIP, intDatabase) Then
                Page.RegisterClientScriptBlock("JSSucc", "<script language='javascript'>alert('" & ddlLabel.Items(8).Text & "');</script>")
            Else
                Page.RegisterClientScriptBlock("NoJSSucc", "<script language='javascript'>alert('" & ddlLabel.Items(9).Text & "');</script>")
            End If
            Call BindData()
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBLogin Is Nothing Then
                    objBLogin.Dispose(True)
                    objBLogin = Nothing
                End If
                If Not objBCommon Is Nothing Then
                    objBCommon.Dispose(True)
                    objBCommon = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
