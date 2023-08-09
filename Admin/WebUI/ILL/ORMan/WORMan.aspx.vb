Imports eMicLibAdmin.BusinessRules.ILL
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WORMan
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
        Private objBILLOutRequestCollection As New clsBILLOutRequestCollection
        Private objBCDBS As New clsBCommonDBSystem

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call BindDropDownList()
                Call FilterData()
            End If
        End Sub

        ' CheckFormPermission method
        Private Sub CheckFormPermission()
            If Not CheckPemission(154) Then
                'Page.RegisterClientScriptBlock("invaliduser", "<script language='javascript'>alert('" & ddlLabel.Items(29).Text & "'); self.close();</script>")
                'Response.End()
                Call WriteErrorMssg(ddlLabel.Items(29).Text)
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBAccountTrans
            objBILLOutRequestCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBILLOutRequestCollection.DBServer = Session("DBServer")
            objBILLOutRequestCollection.ConnectionString = Session("ConnectionString")
            objBILLOutRequestCollection.Initialize()

            ' Init for objBCDBS
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            objBCDBS.Initialize()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Dim strJS As String
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/ORMan/WORMan.js'></script>")

            strJS = "<script language='javascript'>" & Chr(10)
            strJS = strJS & "ActID = new Array(20);" & Chr(10)
            strJS = strJS & "ActName = new Array(20);" & Chr(10)
            strJS = strJS & "for (i = 0; i <= 20; i++) {" & Chr(10)
            strJS = strJS & "ActID[i] = i + 1;}" & Chr(10)
            strJS = strJS & "ActName[0] = '" & ddlLabel.Items(2).Text & "'" & Chr(10)
            strJS = strJS & "ActName[1] = '" & ddlLabel.Items(3).Text & "'" & Chr(10)
            strJS = strJS & "ActName[2] = '" & ddlLabel.Items(4).Text & "'" & Chr(10)
            strJS = strJS & "ActName[3] = '" & ddlLabel.Items(5).Text & "'" & Chr(10)
            strJS = strJS & "ActName[4] = '" & ddlLabel.Items(6).Text & "'" & Chr(10)
            strJS = strJS & "ActName[5] = '" & ddlLabel.Items(7).Text & "'" & Chr(10)
            strJS = strJS & "ActName[6] = '" & ddlLabel.Items(8).Text & "'" & Chr(10)
            strJS = strJS & "ActName[7] = '" & ddlLabel.Items(9).Text & "'" & Chr(10)
            strJS = strJS & "ActName[8] = '" & ddlLabel.Items(10).Text & "'" & Chr(10)
            strJS = strJS & "ActName[9] = '" & ddlLabel.Items(11).Text & "'" & Chr(10)
            strJS = strJS & "ActName[10] = '" & ddlLabel.Items(12).Text & "'" & Chr(10)
            strJS = strJS & "ActName[11] = '" & ddlLabel.Items(13).Text & "'" & Chr(10)
            strJS = strJS & "ActName[12] = '" & ddlLabel.Items(14).Text & "'" & Chr(10)
            strJS = strJS & "ActName[13] = '" & ddlLabel.Items(15).Text & "'" & Chr(10)
            strJS = strJS & "ActName[14] = '" & ddlLabel.Items(16).Text & "'" & Chr(10)
            strJS = strJS & "ActName[15] = '" & ddlLabel.Items(17).Text & "'" & Chr(10)
            strJS = strJS & "ActName[16] = '" & ddlLabel.Items(18).Text & "'" & Chr(10)
            strJS = strJS & "ActName[17] = '" & ddlLabel.Items(19).Text & "'" & Chr(10)
            strJS = strJS & "ActName[18] = '" & ddlLabel.Items(20).Text & "'" & Chr(10)
            strJS = strJS & "ActName[19] = '" & ddlLabel.Items(21).Text & "'" & Chr(10)
            strJS = strJS & "ActName[20] = '" & ddlLabel.Items(22).Text & "'" & Chr(10)
            strJS = strJS & "</script>"
            Page.RegisterClientScriptBlock("LoadArray", strJS)
            lnkOutGoingReq.Target = "Hiddenbase"
            lnkOutGoingReq.NavigateUrl = "../WSaveMail.aspx?Mode=2"
        End Sub

        ' FilterData method
        Private Sub FilterData()
            ' Declare variables
            Dim tblTemp As Object

            ' Cancel Filter
            If Request("Cancel") = "True" Then
                Session("ORIDs") = Nothing
            End If

            ' Filter or not
            If Session("ORIDs") <> "" Then
                Call VisibleFilter()
                objBILLOutRequestCollection.StatusID = 0
                objBILLOutRequestCollection.RequestIDs = Session("ORIDs")
            Else
                objBILLOutRequestCollection.RequestIDs = ""
                Call DisableFilter()
                If ddlStatus.SelectedValue <> "" Then
                    objBILLOutRequestCollection.StatusID = ddlStatus.SelectedValue
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
            objBILLOutRequestCollection.Sort = hidColSort.Value
            tblTemp = objBILLOutRequestCollection.GetORList

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBILLOutRequestCollection.ErrorMsg, ddlLabel.Items(0).Text, objBILLOutRequestCollection.ErrorCode)

            If Not tblTemp Is Nothing Then
                dgtRequest.DataSource = tblTemp
                dgtRequest.DataBind()
                Call BindImages()
                hidHasItem.Value = CType(tblTemp, DataTable).Rows.Count
            Else
                hidHasItem.Value = 0
            End If
            If Session("ORIDs") <> "" Then
                Dim arrIDs() As String

                arrIDs = Split(Session("ORIDs"), ",")
                lblFilterAmount.Text = CStr(UBound(arrIDs) + 1)
            Else
                If ddlStatus.Items.Count > 0 Then
                    lblAmount.Text = Replace(Replace(Right(ddlStatus.Items(ddlStatus.SelectedIndex).Text, Len(ddlStatus.Items(ddlStatus.SelectedIndex).Text) - InStr(ddlStatus.Items(ddlStatus.SelectedIndex).Text, "(") + 1), "(", ""), ")", "")
                End If
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
            Dim strStatusID As String
            Dim lblCreatedDate As Label
            Dim lblServiceType As Label
            Dim lblPriority As Label
            Dim lnkHistory As HyperLink
            Dim strServiceType As String
            Dim strPriority As String
            Dim strHistory As String
            Dim lngRequestID As Long

            For Each dtgItem In dgtRequest.Items
                strStatusID = CStr(CType(dtgItem.FindControl("lblStatusTemp"), Label).Text)
                strPriority = CStr(CType(dtgItem.FindControl("lblPriorityID"), Label).Text)
                strServiceType = CStr(CType(dtgItem.FindControl("lblServiceTypeID"), Label).Text)
                strHistory = CStr(CType(dtgItem.FindControl("lblNom"), Label).Text)
                lngRequestID = CLng(CType(dtgItem.FindControl("lblID"), Label).Text)

                lblStatus = dtgItem.FindControl("lblStatusDisplay")
                lblPriority = dtgItem.FindControl("lblPriority")
                lblServiceType = dtgItem.FindControl("lblServiceType")
                lblCreatedDate = dtgItem.FindControl("lblDate")
                lnkHistory = dtgItem.FindControl("lnkHistory")

                Select Case CInt(Trim(strStatusID))
                    Case Is <= 22
                        lblStatus.Text = "<img title='" & ddlStatusToolTip.Items(CInt(strStatusID) - 1).Text & "' src=""../images/stat" & Trim(strStatusID) & ".gif"">"
                    Case Else
                        lblStatus.Text = ""
                End Select

                Select Case Trim(strPriority)
                    Case "1"
                        lblPriority.Text = ddlLabel.Items(25).Text
                    Case "2"
                        lblPriority.Text = ddlLabel.Items(26).Text
                    Case Else
                        lblPriority.Text = ddlLabel.Items(32).Text
                End Select

                Select Case Trim(strServiceType)
                    Case "1"
                        lblServiceType.Text = ddlLabel.Items(27).Text
                    Case "2"
                        lblServiceType.Text = ddlLabel.Items(28).Text
                    Case "3"
                        lblServiceType.Text = ddlLabel.Items(30).Text
                    Case "4"
                        lblServiceType.Text = ddlLabel.Items(31).Text
                    Case Else
                        lblServiceType.Text = ddlLabel.Items(32).Text
                End Select

                If Trim(strHistory) <> "0" Then
                    lnkHistory.Text = "<img src=""../images/newmail.gif"" border=""0"" alt=""" & ddlLabel.Items(7).Text & """>"
                    lnkHistory.NavigateUrl = "#"
                    lnkHistory.Attributes.Add("OnClick", "OpenWindow('WORHisRequest.aspx?HasMail=1&ILLID=" & lngRequestID & "','WRequestHistory',500,300,50,50);return false;")
                End If
            Next
        End Sub

        ' BindDropDownList method
        Private Sub BindDropDownList()
            Dim tblRequest As DataTable
            Dim intTotal As Integer = 0
            Dim lstItem As New ListItem

            tblRequest = objBILLOutRequestCollection.GetILLOutRequestProcess(intTotal)
            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBILLOutRequestCollection.ErrorMsg, ddlLabel.Items(0).Text, objBILLOutRequestCollection.ErrorCode)

            ' Insert the row in the top of drop down list
            If Not tblRequest Is Nothing AndAlso tblRequest.Rows.Count > 0 Then
                tblRequest = InsertOneRow(tblRequest, ddlLabel.Items(23).Text & " (" & intTotal & ")")
                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, ErrorMsg, ddlLabel.Items(0).Text, ErrorCode)
            Else
                ddlStatus.Items.Clear()
                lstItem.Text = ddlLabel.Items(23).Text & " (0)"
                lstItem.Value = 0
                ddlStatus.Items.Add(lstItem)
            End If

            ' Get the data details
            If Not tblRequest Is Nothing AndAlso tblRequest.Rows.Count > 0 Then
                ddlStatus.DataSource = tblRequest
                ddlStatus.DataTextField = "Result"
                ddlStatus.DataValueField = "Status"
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

        ' dgtRequest_PageIndexChanged event
        Private Sub dgtRequest_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgtRequest.PageIndexChanged
            Try
                dgtRequest.CurrentPageIndex = e.NewPageIndex
                Call FilterData()
            Catch ex As Exception
            End Try
        End Sub

        ' dgtRequest_SortCommand event
        Private Sub dgtRequest_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgtRequest.SortCommand
            Try
                hidColSort.Value = e.SortExpression
                Call FilterData()
            Catch ex As Exception

            End Try
        End Sub

        ' dgtRequest_ItemCreated event
        Private Sub dgtRequest_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgtRequest.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                    ' Declare variables
                    Dim tblCell As TableCell

                    'Dim chk As CheckBox
                    Dim lnk As HyperLink

                    tblCell = e.Item.Cells(1)
                    lnk = CType(tblCell.FindControl("lnkRequestID"), HyperLink)
                    lnk.NavigateUrl = "WORDetail.aspx?ILLID=" & DataBinder.Eval(e.Item.DataItem, "ID")
            End Select

            Dim inti As Integer
            For inti = 1 To e.Item.Cells.Count - 1
                If e.Item.ItemIndex <> -1 Then
                    e.Item.Cells(inti).Attributes.Add("onClick", "javascript:rdoEvent(" & e.Item.ItemIndex & ");")
                End If
            Next
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBILLOutRequestCollection Is Nothing Then
                    objBILLOutRequestCollection.Dispose(True)
                    objBILLOutRequestCollection = Nothing
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