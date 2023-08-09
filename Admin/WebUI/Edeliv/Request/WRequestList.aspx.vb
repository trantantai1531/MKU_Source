Imports eMicLibAdmin.BusinessRules.Edeliv
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WRequestList
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents hidIDs As System.Web.UI.HtmlControls.HtmlInputText
        Protected WithEvents hidRequestIDs As System.Web.UI.HtmlControls.HtmlInputText


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBRequestCollection As New clsBERequestCollection
        Private objBEdata As New clsBEData

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPemission()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call BindDropDownList()
                Call FilterData()
            End If
        End Sub

        ' CheckFormPemission method
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            If Not CheckPemission(159) Then
                Call WriteErrorMssg(ddlLabel.Items(13).Text)
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBAccountTrans
            objBRequestCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBRequestCollection.DBServer = Session("DBServer")
            objBRequestCollection.ConnectionString = Session("ConnectionString")
            Call objBRequestCollection.Initialize()

            ' Init objBEdata
            objBEdata.InterfaceLanguage = Session("InterfaceLanguage")
            objBEdata.DBServer = Session("DBServer")
            objBEdata.ConnectionString = Session("ConnectionString")
            Call objBEdata.Initialize()
        End Sub

        ' BindJS method
        Private Sub BindJS()
            Dim strJS As String
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/Request/WRequestList.js'></script>")

            strJS = "<script language='javascript'>" & Chr(10)
            strJS = strJS & "ActID = new Array(10);" & Chr(10)
            strJS = strJS & "ActName = new Array(10);" & Chr(10)
            strJS = strJS & "for (i = 0; i <= 9; i++) {" & Chr(10)
            strJS = strJS & "ActID[i] = i + 1;}" & Chr(10)
            strJS = strJS & "ActName[0] = '" & ddlLabel.Items(1).Text & "'" & Chr(10)
            strJS = strJS & "ActName[1] = '" & ddlLabel.Items(2).Text & "'" & Chr(10)
            strJS = strJS & "ActName[2] = '" & ddlLabel.Items(3).Text & "'" & Chr(10)
            strJS = strJS & "ActName[3] = '" & ddlLabel.Items(4).Text & "'" & Chr(10)
            strJS = strJS & "ActName[4] = '" & ddlLabel.Items(5).Text & "'" & Chr(10)
            strJS = strJS & "ActName[5] = '" & ddlLabel.Items(6).Text & "'" & Chr(10)
            strJS = strJS & "ActName[6] = '" & ddlLabel.Items(7).Text & "'" & Chr(10)
            strJS = strJS & "ActName[7] = '" & ddlLabel.Items(8).Text & "'" & Chr(10)
            strJS = strJS & "ActName[8] = '" & ddlLabel.Items(9).Text & "'" & Chr(10)
            strJS = strJS & "ActName[9] = '" & ddlLabel.Items(10).Text & "'" & Chr(10)
            strJS = strJS & "</script>"
            Page.RegisterClientScriptBlock("LoadArray", strJS)
        End Sub

        ' FilterData method
        Private Sub FilterData()
            ' Declare variables
            Dim tblRequestProcess As Object

            ' Cancel Filter
            If Request("Cancel") = "True" Then
                Session("ERequestIDs") = Nothing
            End If

            ' Filter or not
            If Session("ERequestIDs") <> "" Then
                Call VisibleFilter()
                objBRequestCollection.StatusID = 0
                objBRequestCollection.RequestIDs = Session("ERequestIDs")
            Else
                Call DisableFilter()
                If ddlStatus.SelectedValue <> "" Then
                    objBRequestCollection.StatusID = ddlStatus.SelectedValue
                    lblAmount.Visible = False
                    lblMainTitle.Visible = False
                    lblProcess.Visible = True
                    lblProcess.Text = Replace(Replace(ddlStatus.Items(ddlStatus.SelectedIndex).Text, "(", ""), ")", "")
                Else
                    lblAmount.Visible = True
                    lblMainTitle.Visible = True
                    lblProcess.Visible = False
                End If
            End If

            ' Bind the data
            objBRequestCollection.Sort = hidColSort.Value
            tblRequestProcess = objBRequestCollection.GetERequestList
            Call WriteErrorMssg(ddlLabel.Items(15).Text, objBRequestCollection.ErrorMsg, ddlLabel.Items(14).Text, objBRequestCollection.ErrorCode)

            If Not tblRequestProcess Is Nothing Then
                dgtRequest.DataSource = tblRequestProcess
                dgtRequest.DataBind()
                Call BindImages()
                hidHasItem.Value = CType(tblRequestProcess, DataTable).Rows.Count
            Else
                hidHasItem.Value = 0
            End If

            If Session("ERequestIDs") <> "" Then
                lblFilterAmount.Text = CStr(dgtRequest.Items.Count)
            Else
                lblAmount.Text = CStr(dgtRequest.Items.Count)
            End If
        End Sub

        ' Visible Filter
        Private Sub VisibleFilter()
            lblMainTitle.Visible = False
            lblProcess.Visible = False
            lblAmount.Visible = False
            lblStatus.Visible = False
            ddlStatus.Visible = False
            lblFilter.Visible = True
            lblFilterTotal.Visible = True
            lblFilterAmount.Visible = True
            lblRecord.Visible = True
        End Sub

        ' Disable Filter
        Private Sub DisableFilter()
            lblMainTitle.Visible = True
            lblProcess.Visible = True
            lblAmount.Visible = True
            lblStatus.Visible = True
            ddlStatus.Visible = True
            lblFilter.Visible = False
            lblFilterTotal.Visible = False
            lblFilterAmount.Visible = False
            lblRecord.Visible = False
        End Sub

        ' BindImages method
        Private Sub BindImages()
            ' Declare variables
            Dim dtgItem As DataGridItem
            Dim lblStatus As Label
            Dim lblMode As Label
            Dim strStatusID As String
            Dim strModeID As String
            Dim strCreatedDateTemp As String
            Dim strExpiredDateTemp As String
            Dim strExpiredDate As String
            Dim lblCreatedDate As Label

            For Each dtgItem In dgtRequest.Items
                strStatusID = CStr(CType(dtgItem.FindControl("lblStatusTemp"), Label).Text)
                strModeID = CStr(CType(dtgItem.FindControl("lblModeTemp"), Label).Text)
                strCreatedDateTemp = CStr(CType(dtgItem.FindControl("lblCreatedDateTemp"), Label).Text)
                strExpiredDateTemp = CStr(CType(dtgItem.FindControl("lblExpiredDateTemp"), Label).Text)
                strExpiredDate = CStr(CType(dtgItem.FindControl("lblExpiredDate"), Label).Text)

                lblStatus = dtgItem.FindControl("lblStatusDisplay")
                lblMode = dtgItem.FindControl("lblMode")
                lblCreatedDate = dtgItem.FindControl("lblDate")

                Select Case Trim(strStatusID)
                    Case "1"
                        lblStatus.Text = "<img src=""../images/stat1.gif"">"
                    Case "2"
                        lblStatus.Text = "<img src=""../images/stat2.gif"">"
                    Case "3"
                        lblStatus.Text = "<img src=""../images/stat3.gif"">"
                    Case "4"
                        lblStatus.Text = "<img src=""../images/stat4.gif"">"
                    Case "5"
                        lblStatus.Text = "<img src=""../images/stat5.gif"">"
                    Case "6"
                        lblStatus.Text = "<img src=""../images/stat6.gif"">"
                    Case "7"
                        lblStatus.Text = "<img src=""../images/stat7.gif"">"
                    Case Else
                        lblStatus.Text = ""
                End Select
                Select Case Trim(strModeID)
                    Case "1"
                        lblMode.Text = "<img src=""../images/mode1.gif"">"
                    Case "2"
                        lblMode.Text = "<img src=""../images/mode2.gif"">"
                    Case "3"
                        lblMode.Text = "<img src=""../images/mode3.gif"">"
                    Case Else
                        lblMode.Text = ""
                End Select

                If Trim(strExpiredDate) <> "" And Trim(strCreatedDateTemp) <> "" Then
                    lblCreatedDate = dtgItem.FindControl("lblDate")
                    If CDate(strCreatedDateTemp) > CDate(strExpiredDateTemp) Then
                        lblCreatedDate.Text = lblCreatedDate.Text & "<BR><Font color=""red"">" & Left(Trim(strExpiredDate), 10) & " " & ddlLabel.Items(12).Text & "</font>"
                        lblStatus.Text = lblStatus.Text & "<img src=""../images/expired.gif"">"
                    End If
                End If

            Next
        End Sub

        ' BindDropDownList method
        Private Sub BindDropDownList()
            Dim tblRequest As DataTable
            Dim intTotal As Integer = 0
            tblRequest = objBRequestCollection.GetERequestProcess(intTotal)
            Call WriteErrorMssg(ddlLabel.Items(15).Text, objBRequestCollection.ErrorMsg, ddlLabel.Items(14).Text, objBRequestCollection.ErrorCode)

            If Not tblRequest Is Nothing Then
                tblRequest = InsertOneRow(tblRequest, ddlLabel.Items(11).Text & " (" & intTotal & ")")
                ddlStatus.DataSource = tblRequest
                ddlStatus.DataTextField = "Result"
                ddlStatus.DataValueField = "StatusID"
                ddlStatus.DataBind()
            End If

            If ddlStatus.SelectedIndex = 0 Then
                lblAmount.Visible = True
                lblAmount.Text = CStr(intTotal)
            End If
        End Sub

        ' ddlStatus_SelectedIndexChanged event
        Private Sub ddlStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlStatus.SelectedIndexChanged
            dgtRequest.CurrentPageIndex = 0
            Call FilterData()
        End Sub

        ' dgtRequest_ItemCreated event
        Private Sub dgtRequest_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgtRequest.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                    ' Declare variables
                    Dim tblCell As TableCell

                    Dim lnk As HyperLink
                    Dim lblTitle As Label
                    Dim tblTitle As DataTable

                    tblCell = e.Item.Cells(1)

                    lblTitle = CType(tblCell.FindControl("lblTitle"), Label)

                    tblTitle = objBEdata.GetEdataDubTitle(DataBinder.Eval(e.Item.DataItem, "ID"))

                    If Not tblTitle Is Nothing AndAlso tblTitle.Rows.Count > 0 Then
                        If DataBinder.Eval(e.Item.DataItem, "Title") & "" <> "" Then
                            lblTitle.Text = tblTitle.Rows(0).Item("DubTitle") & "<BR>(" & ddlLabel.Items(16).Text & " " & DataBinder.Eval(e.Item.DataItem, "Title") & ")<BR>"
                        Else
                            lblTitle.Text = tblTitle.Rows(0).Item("DubTitle") & "<BR>"
                        End If
                    Else
                        If DataBinder.Eval(e.Item.DataItem, "Title") & "" <> "" Then
                            lblTitle.Text = "(" & ddlLabel.Items(16).Text & " " & DataBinder.Eval(e.Item.DataItem, "Title") & ")<BR>"
                        Else
                            lblTitle.Text = ""
                        End If
                    End If
                    lnk = CType(tblCell.FindControl("lnkTitle"), HyperLink)
                    lnk.NavigateUrl = "WRequestDetail.aspx?RequestID=" & DataBinder.Eval(e.Item.DataItem, "RequestID")
            End Select

            Dim inti As Integer
            For inti = 1 To e.Item.Cells.Count - 1
                If e.Item.ItemIndex <> -1 Then
                    e.Item.Cells(inti).Attributes.Add("onClick", "javascript:rdoEvent(" & e.Item.ItemIndex & ");")
                End If
            Next
        End Sub

        ' dgtRequest_PageIndexChanged event
        Private Sub dgtRequest_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgtRequest.PageIndexChanged
            dgtRequest.CurrentPageIndex = e.NewPageIndex
            Call FilterData()
        End Sub

        ' dgtRequest_SortCommand event
        Private Sub dgtRequest_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgtRequest.SortCommand
            hidColSort.Value = e.SortExpression
            Call FilterData()
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBRequestCollection Is Nothing Then
                    objBRequestCollection.Dispose(True)
                    objBRequestCollection = Nothing
                End If
                If Not objBEdata Is Nothing Then
                    objBEdata.Dispose(True)
                    objBEdata = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
