Imports eMicLibOPAC.BusinessRules.OPAC
Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibOPAC.WebUI

Namespace eMicLibOPAC.WebUI.OPAC
    Public Class OPatronInfo
        Inherits clsWBaseJqueryUI

        ' Declare variables
        Private objBOPACPatronInfor As New clsBOPACPatronInfor
        Private objBCDBS As New clsBCommonDBSystem
        Dim intReservationMax As Integer

        ' Event :  Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ' Check exist patron account
            If Trim(clsSession.GlbUser & "") = "" Then
                Response.Redirect("OLogin.aspx?patron=1", False)
            End If
            Call Initialize()
            If Not Page.IsPostBack Then
                If Session("field") = "" Then
                    Session("field") = GetBBK_DDC()
                End If
            End If
            dgrReservation.Visible = False
            dgrReservation.Visible = False
            dgrILLRequest.Visible = False
            ckbCheckAll.Visible = False
            dgrInterestItem.Visible = False
            btnReservationDelete.Visible = False
            divReservationDelete.Visible = False
            If Not Page.IsPostBack Then
                intReservationMax = 0
                Call BindData()
            End If
            ' Note: Must put BindScript method here ,after BindData method
            Call BindScript()
        End Sub

        ' Initialize method
        ' Purpose: Init all necessary objects
        Private Sub Initialize()
            ' Init objBOPACPatronInfor object
            objBOPACPatronInfor.ConnectionString = Session("ConnectionString")
            objBOPACPatronInfor.DBServer = Session("DBServer")
            objBOPACPatronInfor.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBOPACPatronInfor.Initialize()

            ' Init objBCDBS object
            objBCDBS.ConnectionString = Session("ConnectionString")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBCDBS.Initialize()

        End Sub

        ' purponse: Bind Script 
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("WPersonalPageJs", "<script language='javascript' src='JS/OPatronInfo.js'></script>")
            ' Selecte all reservation (javascript)
            ckbCheckAll.Attributes.Add("OnClick", "CheckAll('dgrReservation','ckbItemID','ckbCheckAll'," & intReservationMax & ");")
            btnReservationDelete.Attributes.Add("OnClick", "return(CheckReservationSelected(" & intReservationMax & "));")
            ' btnUpdateInfor.Attributes.Add("OnClick", "document.forms[0].method='post';document.forms[0].action='WUpdatePersonalPage.aspx';document.forms[0].submit();return(false);")
        End Sub

        ' Purpose: GetData for firsttime Display
        Private Sub BindData()
            Dim tblPatronInfor As New DataTable, tblReservation As New DataTable, tblOnHolding As New DataTable, tblILLRequest As New DataTable, tblInterestItems As New DataTable

            ' Get Patron Informations
            objBOPACPatronInfor.CardNo = Trim(clsSession.GlbUser & "")
            objBOPACPatronInfor.Password = Trim(clsSession.GlbPassword & "")
            tblPatronInfor = objBOPACPatronInfor.GetPatron
            If Not tblPatronInfor Is Nothing Then
                If tblPatronInfor.Rows.Count > 0 Then
                    lblPatronName.Text = clsSession.GlbUserFullName & ""
                    lblCardNoValue.Text = clsSession.GlbUser & ""
                    lblValidDateValue.Text = tblPatronInfor.Rows(0).Item("VALIDDATE")
                    lblExpriedDateValue.Text = tblPatronInfor.Rows(0).Item("EXPIREDDATE")
                    lblPatronGroupValue.Text = tblPatronInfor.Rows(0).Item("GroupName")

                    If IsDBNull(tblPatronInfor.Rows(0).Item("Portrait")) Or tblPatronInfor.Rows(0).Item("Portrait") & "" = "" Then
                        imgPatron.Src = Me.getPictureCardVirtualPath & "/Empty.gif"
                    Else
                        Dim strUrl As String = Me.getPictureCardVirtualPath & "/" & tblPatronInfor.Rows(0).Item("Portrait")
                        'imgPatron.Src = "Common/Showpic.aspx?intw90&inth=120&Url=" & strUrl
                        imgPatron.Src = strUrl
                    End If
                    imgPatron.DataBind()
                End If
            End If
            ' Get Patron Reservation
            'objBOPACPatronInfor.CardNo = Trim(clsSession.GlbUser & "")
            'tblReservation = objBOPACPatronInfor.GetReservation(lblGetBefore.Text, lblHour.Text, lblDate.Text, lblLibaryName.Text, lblPosition.Text)
            'If Not tblReservation Is Nothing Then
            '    If tblReservation.Rows.Count > 0 Then
            '        ckbCheckAll.Visible = True
            '        btnReservationDelete.Visible = True
            '        divReservationDelete.Visible = True
            '        intReservationMax = tblReservation.Rows.Count
            '        dgrReservation.Visible = True
            '        dgrReservation.DataSource = tblReservation
            '        dgrReservation.DataBind()
            '    End If
            'End If
            objBOPACPatronInfor.CardNo = Trim(clsSession.GlbUser & "")
            tblReservation = objBOPACPatronInfor.GetReservationOther(lblGetBefore.Text, lblHour.Text, lblDate.Text, lblLibaryName.Text, lblPosition.Text)
            If Not tblReservation Is Nothing Then
                If tblReservation.Rows.Count > 0 Then
                    ckbCheckAll.Visible = True
                    btnReservationDelete.Visible = True
                    divReservationDelete.Visible = True
                    intReservationMax = tblReservation.Rows.Count
                    dgrReservation.Visible = True
                    dgrReservation.DataSource = tblReservation
                    dgrReservation.DataBind()
                    lblReservation.Text = lblHeaderReservation.Text & ": " & tblReservation.Rows.Count.ToString()
                Else
                    lblReservation.Text = lblHeaderReservation.Text & ": 0"
                End If
            Else
                lblReservation.Text = lblHeaderReservation.Text & ": 0"
            End If
            ' Get Patron OnHolding
            objBOPACPatronInfor.CardNo = Trim(clsSession.GlbUser & "")
            tblOnHolding = objBOPACPatronInfor.GetOnHolding(lblCheckOutDate.Text, lblCheckInDate.Text, lblOverDueDate.Text, lblDate.Text, lblOnHoldingB.Text, lblRenew.Text, lblNotRenew.Text)
            If Not tblOnHolding Is Nothing Then
                If tblOnHolding.Rows.Count > 0 Then
                    dgrOnHolding.Visible = True
                    dgrOnHolding.DataSource = tblOnHolding
                    dgrOnHolding.DataBind()
                End If
            End If
            ' Get Patron ILLRequest
            objBOPACPatronInfor.CardNo = Trim(clsSession.GlbUser & "")
            tblILLRequest = objBOPACPatronInfor.GetILLRequest(lblCreatedDate.Text, lblStatus.Text, lbldelILL.Text)
            If Not tblILLRequest Is Nothing Then
                If tblILLRequest.Rows.Count > 0 Then
                    dgrILLRequest.Visible = True
                    dgrILLRequest.DataSource = tblILLRequest
                    dgrILLRequest.DataBind()
                End If
            End If
            ' Get Patron Interest Items
            objBOPACPatronInfor.CardNo = Trim(clsSession.GlbUser & "")
            objBOPACPatronInfor.Password = Trim(clsSession.GlbPassword & "")
            tblInterestItems = objBOPACPatronInfor.GetInterestItem(Session("field"))
            hdInterestObject.Value = objBOPACPatronInfor.InterestedSubject
            If Not tblInterestItems Is Nothing Then
                If tblInterestItems.Rows.Count > 0 Then
                    dgrInterestItem.Visible = True
                    dgrInterestItem.DataSource = tblInterestItems
                    dgrInterestItem.DataBind()
                End If
            End If

            'Clear the last search
            clsSession.GlbIds = Nothing 'Release cache
            'Init some value
            Dim colData As New Collection
            colData.Add("ISBD", "Display")
            colData.Add(False, "SecuredOPAC")
            colData.Add(clsSession.GlbUserLevel, "AccessLevel")
            colData.Add(Session("SearchUbound"), "SelectTop")
            colData.Add("", "SortBy")
            colData.Add("", "Title")
            colData.Add("Detail", "SearchMode") ' detail search
            colData.Add("", "Author")
            colData.Add("", "Publisher")
            colData.Add("", "DDC_BBK")
            colData.Add("", "Language")
            colData.Add("", "KeyWord")
            colData.Add("", "ItemType")
            colData.Add("", "CallNumber")
            colData.Add("", "FromEdeliveryDate")
            colData.Add("", "ISBN")
            colData.Add("", "ISSN")
            colData.Add("", "IssueNo")
            colData.Add("", "TabOfContents")
            colData.Add("", "ThesisSubject")
            colData.Add("", "ToEdeliveryDate")
            colData.Add("", "Vol")
            colData.Add("", "PublishYear")
            Session("colSearch") = colData

        End Sub

        'purpose: Pick selected Reservation ItemID
        Private Function PickReservationItemIDs() As String
            Dim intIndex As Integer
            Dim strIDs As String = ""
            For intIndex = 0 To dgrReservation.Items.Count - 1
                If CType(dgrReservation.Items(intIndex).Cells(0).FindControl("ckbItemID"), CheckBox).Checked = True Then
                    strIDs &= CType(dgrReservation.Items(intIndex).Cells(1).FindControl("txtItemID"), TextBox).Text.ToString & ","
                End If
            Next
            If strIDs <> "" Then
                strIDs = Left(strIDs, strIDs.Length - 1)
            End If
            Return (strIDs)
        End Function

        '  Delete Reservation
        Private Sub btnReservationDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReservationDelete.Click
            Dim strPickReservationItemIDs As String
            strPickReservationItemIDs = PickReservationItemIDs()
            ' Delete patron reservation here
            If Len(strPickReservationItemIDs) > 0 Then
                objBOPACPatronInfor.CardNo = Trim(clsSession.GlbUser & "")
                objBOPACPatronInfor.DeleteReservation(strPickReservationItemIDs)
                strPickReservationItemIDs = ""
            End If
            ' Refresh Data
            Call BindData()
        End Sub


        Public Function GetBBK_DDC() As String
            Dim arrParameterText(0) As String
            Dim arrParameterValue(0) As String
            arrParameterText(0) = "USED_CLASSIFICATION"
            arrParameterValue = objBCDBS.GetSystemParameters(arrParameterText)
            If Not IsDBNull(arrParameterValue(0)) And arrParameterValue(0) = "8" Then
                GetBBK_DDC = "DDC"
            Else ' default BBK
                GetBBK_DDC = "BBK"
            End If

        End Function

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub
        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBOPACPatronInfor Is Nothing Then
                    objBOPACPatronInfor.Dispose(True)
                    objBOPACPatronInfor = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        Private Sub btnUpdateInfor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateInfor.Click
            Response.Redirect("OPatronUpdate.aspx", False)
        End Sub

    End Class
End Namespace
