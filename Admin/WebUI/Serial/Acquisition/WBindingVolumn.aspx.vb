' Class: WBindingVolumn
' Puspose: Show and modify the binding of serial
' Creator: lent
' CreatedDate: 16/11/2006
' Modification history:

Imports eMicLibAdmin.BusinessRules.Serial
Imports eMicLibAdmin.BusinessRules.Common
Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WBindingVolumn
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

        Private objBBindingVolume As New clsBBindingVolume
        Private objBCDBS As New clsBCommonDBSystem
        Private objBPeriodical As New clsBPeriodical
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub
        ' Method: CheckFormPermission
        ' Purpose: Check permissions
        Private Sub CheckFormPermission()
            If Not CheckPemission(197) Then
                btnUnBind.Enabled = False
            End If
        End Sub
        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()

            ' Init objBBindingVolume object
            objBBindingVolume.InterfaceLanguage = Session("InterfaceLanguage")
            objBBindingVolume.DBServer = Session("DBServer")
            objBBindingVolume.ConnectionString = Session("ConnectionString")
            Call objBBindingVolume.Initialize()

            ' Init objBCDBS object
            objBCDBS.ConnectionString = Session("ConnectionString")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCDBS.Initialize()

            ' Init objBPeriodical object
            objBPeriodical.ConnectionString = Session("ConnectionString")
            objBPeriodical.DBServer = Session("DBServer")
            objBPeriodical.InterfaceLanguage = Session("InterfaceLanguage")

            Call objBPeriodical.Initialize()
        End Sub
        ' BindJS method
        ' Purpose: Include all javascript functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../Js/Acquisition/WBinding.js'></script>")
            btnUnBind.Attributes.Add("OnClick", "if (!confirm('" & ddlLabel.Items(4).Text & "')) {return false;}")
            btnClose.Attributes.Add("OnClick", "if (document.forms[0].hidUpdate.value==1) {RefreshBinding();};self.close();return false;")
        End Sub
        Private Sub BindData()
            ' bind issueno ddl
            Dim tblTemp As DataTable
            objBPeriodical.ItemID = Session("ItemID")
            tblTemp = objBPeriodical.GetReceivedIssues(Request("Year"), "NULL")

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPeriodical.ErrorMsg, ddlLabel.Items(0).Text, objBPeriodical.ErrorCode)


            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    ddlIssueNo.DataSource = tblTemp
                    ddlIssueNo.DataValueField = "ID"
                    ddlIssueNo.DataTextField = "IssueNo"
                    ddlIssueNo.DataBind()
                    ddlIssueNo.SelectedIndex = 0
                    Call LoadReceivedCopies(ddlIssueNo.SelectedValue)
                End If
                tblTemp.Clear()
            End If

            ShowCopiesOfBind()
        End Sub
        ' LoadReceivedCopies method
        ' Purpose: Load received copies of the selected issue
        Private Sub LoadReceivedCopies(ByVal lngIssueID As Integer)
            Dim tblTemp As DataTable
            objBBindingVolume.IssuedYear = Request("Year")
            objBBindingVolume.ItemID = Session("ItemID")
            objBBindingVolume.LocationID = Request("LocationID")
            tblTemp = objBBindingVolume.GetCopiesToBind(lngIssueID)

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBBindingVolume.ErrorMsg, ddlLabel.Items(0).Text, objBBindingVolume.ErrorCode)

            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    dtgCopiesToBind.DataSource = tblTemp
                Else
                    dtgCopiesToBind.DataSource = Nothing
                End If
                dtgCopiesToBind.DataBind()
            End If
        End Sub
        ' ShowCopiesOfBind method
        ' Purpose: view copies of the selected volume (by library)
        Private Sub ShowCopiesOfBind()
            Dim tblTemp As DataTable
            ' Get copies to show
            objBBindingVolume.IssuedYear = Request("Year")
            objBBindingVolume.ItemID = Session("ItemID")
            objBBindingVolume.LocationID = Request("LocationID")
            objBBindingVolume.CopyNumberID = Request("CopyNumberID")
            tblTemp = objBBindingVolume.GetCopiesOfBind()

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBBindingVolume.ErrorMsg, ddlLabel.Items(0).Text, objBBindingVolume.ErrorCode)

            ' Show
            dtgCopiesOfBind.Visible = False
            btnUnBind.Visible = False
            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    btnUnBind.Visible = True
                    dtgCopiesOfBind.Visible = True
                    dtgCopiesOfBind.DataSource = tblTemp
                    dtgCopiesOfBind.DataBind()
                End If
                tblTemp.Dispose()
                tblTemp = Nothing
            End If
        End Sub
        ' btnUnBind_Click event
        ' Purpose: unbind for the selected volume
        Private Sub btnUnBind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnBind.Click
            objBBindingVolume.ItemID = Session("ItemID")
            objBBindingVolume.CopyNumberID = CLng(Request("CopyNumberID"))
            Call objBBindingVolume.UnBind()

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBBindingVolume.ErrorMsg, ddlLabel.Items(0).Text, objBBindingVolume.ErrorCode)

            ' WriteLog
            Call WriteLog(34, ddlLabel.Items(6).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

            ' Success
            Page.RegisterClientScriptBlock("sucess", "<script language='javascript'>alert('" & ddlLabel.Items(5).Text & "');RefreshBinding();self.close();</script>")
        End Sub

        Private Sub dtgCopiesOfBind_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgCopiesOfBind.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.AlternatingItem, ListItemType.Item, ListItemType.EditItem
                    Dim lnkdtgDel As LinkButton
                    lnkdtgDel = e.Item.FindControl("lnkdtgDelete")
                    lnkdtgDel.Attributes.Add("Onclick", "swapBG(this,'red'); if (confirm(' " & ddlLabel.Items(3).Text & " ')==false) {swapBG(this,'red');return false}")
            End Select
        End Sub

        Private Sub dtgCopiesOfBind_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgCopiesOfBind.DeleteCommand
            Dim intID As Integer = e.Item.Cells(0).Text
            objBCDBS.SQLStatement = "update Ser_tblCopy set COPYNUMBERID=null,VOLUMEBYLIBRARY=null, BINDED=0 where id=" & intID
            objBCDBS.ProcessItem()
            Me.AlertMsg(ddlLabel.Items(2).Text)
            hidUpdate.Value = 1
            BindData()
        End Sub

        Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
            Dim dtgItem As DataGridItem
            Dim chkCopyID As CheckBox
            Dim strCopyIDs As String = ""

            For Each dtgItem In dtgCopiesToBind.Items
                chkCopyID = dtgItem.FindControl("chkID")
                If chkCopyID.Checked Then
                    strCopyIDs = strCopyIDs & CType(dtgItem.FindControl("lblID"), Label).Text & ","
                End If
            Next
            If Not strCopyIDs = "" Then
                strCopyIDs = Trim(Left(strCopyIDs, Len(strCopyIDs) - 1))
                If Session("DBServer") = "SQLSERVER" Then
                    objBCDBS.SQLStatement = "UPDATE Ser_tblCopy SET CopyNumberID = " & Request("CopyNumberID") & ", Binded = 1, VolumeByLibrary = N'" & Request("VolumeByLibrary") & "' WHERE LocationID = " & Request("LocationID") & " AND ID IN (" & strCopyIDs & ")"
                Else
                    objBCDBS.SQLStatement = "UPDATE Ser_tblCopy SET CopyNumberID = " & Request("CopyNumberID") & ", Binded = 1, VolumeByLibrary = '" & Request("VolumeByLibrary") & "' WHERE LocationID = " & Request("LocationID") & " AND ID IN (" & strCopyIDs & ")"
                End If
                objBCDBS.ProcessItem()
                Me.AlertMsg(ddlLabel.Items(2).Text)
                hidUpdate.Value = 1
                Call LoadReceivedCopies(ddlIssueNo.SelectedValue)
            End If
            BindData()
        End Sub

        Private Sub ddlIssueNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlIssueNo.SelectedIndexChanged
            Call LoadReceivedCopies(ddlIssueNo.SelectedValue)
        End Sub
        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBBindingVolume Is Nothing Then
                    objBBindingVolume.Dispose(True)
                    objBBindingVolume = Nothing
                End If
                If Not objBPeriodical Is Nothing Then
                    objBPeriodical.Dispose(True)
                    objBPeriodical = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

    End Class
End Namespace