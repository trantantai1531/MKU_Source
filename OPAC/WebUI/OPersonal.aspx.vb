Imports eMicLibOPAC.BusinessRules.OPAC
Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibOPAC.WebUI

Namespace eMicLibOPAC.WebUI.OPAC
    Public Class OPersonal
        Inherits clsWBaseJqueryUI
        

        ' Declare variables
        Private objBOPACPatronInfor As New clsBOPACPatronInfor
        Private objBCDBS As New clsBCommonDBSystem
        Private objBReserve As New clsBReserve
        Private objBOPACLoanRequest As New clsBOPACLoanRequest

        Dim intReservationMax As Integer
        Dim intReserveMax As Integer

        Private Sub ResetSessionUser()
            clsSession.GlbUser = ""
            clsSession.GlbUserFullName = ""
            clsSession.GlbPassword = ""
            clsSession.GlbUserLevel = 0
            clsSession.GlbEmail = ""
        End Sub

        Private Sub RemoveCookieAll()
            clsCookie.CookieGlbUserFullName = ""
            clsCookie.CookieGlbUser = ""
            clsCookie.CookieGlbPassword = ""
            clsCookie.CookieGlbUserLevel = 0
            clsCookie.CookieGlbEmail = ""
        End Sub
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Call Initialize()
            If Not Page.IsPostBack Then
                Session("pageIndex") = 0
                MainView.ActiveViewIndex = 0
                If Session("field") = "" Then
                    Session("field") = GetBBK_DDC()
                End If
                If (Not IsNothing(Request.QueryString("delete"))) Then
                    If (Request.QueryString("delete") = "reserve") Then
                        Try
                            objBReserve.DeleteReserve(Request.QueryString("ID"))
                            Response.Redirect("OPersonal.aspx")
                        Catch ex As Exception

                        End Try
                    End If
                End If
            End If
            If (String.IsNullOrEmpty(clsSession.GlbUser)) Then
                Call ResetSessionUser()
                Call RemoveCookieAll()
                Response.Redirect("OLoginRequest.aspx?RequestLogin=1")
            End If
            'dgrReservation.Visible = False
            'dgrReserve.Visible = False
            'dgrILLRequest.Visible = False
            ckbCheckAll.Visible = False
            dgrInterestItem.Visible = False
            btnReservationDelete.Visible = False
            'ckbReserveCheckAll.Visible = False
            divReservationDelete.Visible = False
            'divReserveDelete.Visible = False
            'btnReserveDelete.Visible = False
            If Not Page.IsPostBack Then
                intReservationMax = 0
                intReserveMax = 0
                Call BindData()
                Call BindData2()
            End If
            ' Note: Must put BindScript method here ,after BindData method
        End Sub

        ' Purpose: GetData for firsttime Display
        Private Sub BindData()
            Dim tblPatronInfor As New DataTable, tblReservation As New DataTable, tblOnHolding As New DataTable, tblILLRequest As New DataTable, tblInterestItems As New DataTable
            Dim tblCreateloanReport As DataTable
            Dim inti As Integer

            '' Get Patron Informations
            'objBOPACPatronInfor.CardNo = Trim(clsSession.GlbUser & "")
            'objBOPACPatronInfor.Password = Trim(Session("PatronPass") & "")
            'tblPatronInfor = objBOPACPatronInfor.GetPatron
            'If Not tblPatronInfor Is Nothing Then
            '    If tblPatronInfor.Rows.Count > 0 Then
            '        lblPatronName.Text = Session("PatronName") & ""
            '        lblCardNoValue.Text = clsSession.GlbUser & ""
            '        lblValidDateValue.Text = tblPatronInfor.Rows(0).Item("VALIDDATE")
            '        lblExpriedDateValue.Text = tblPatronInfor.Rows(0).Item("EXPIREDDATE")
            '        lblPatronGroupValue.Text = tblPatronInfor.Rows(0).Item("GroupName")

            '        If IsDBNull(tblPatronInfor.Rows(0).Item("Portrait")) Or tblPatronInfor.Rows(0).Item("Portrait") & "" = "" Then
            '            imgPatron.Src = "../../Libol60/images/card/Empty.gif"
            '        Else
            '            Dim strUrl = "../../Libol60/images/card/" & tblPatronInfor.Rows(0).Item("Portrait")
            '            imgPatron.Src = "Common/Showpic.aspx?intw90&inth=120&Url=" & strUrl
            '        End If


            '        'If IsDBNull(tblPatronInfor.Rows(0).Item("Portrait")) Or tblPatronInfor.Rows(0).Item("Portrait") & "" = "" Then
            '        '    imgPatron.Src = "..\Libol60\images\card\emty.gif"
            '        'Else
            '        '    imgPatron.Src = "..\Libol60\images\card\" & tblPatronInfor.Rows(0).Item("Portrait")
            '        'End If
            '        imgPatron.DataBind()
            '    End If
            'End If
            ' Get Patron Reservation

            Dim tblReserve As New DataTable("tblReserve")
            objBReserve.PatronCode = Trim(clsSession.GlbUser & "")
            tblReserve = objBReserve.GetReserve()
            If Not tblReserve Is Nothing Then
                If tblReserve.Rows.Count > 0 Then

                    Dim newColumn As New Data.DataColumn("STT", GetType(System.String))
                    newColumn.DefaultValue = "1"
                    tblReserve.Columns.Add(newColumn)
                    Dim indexRows As Integer = 1
                    For Each rows As DataRow In tblReserve.Rows
                        If (Not (rows.RowState = DataRowState.Deleted)) AndAlso (Not (String.IsNullOrEmpty(rows.Item("STT")))) Then
                            rows.Item("STT") = indexRows.ToString()
                            indexRows = indexRows + 1
                        End If

                        'If String.IsNullOrEmpty(rows.Item("DateExpire").ToString) Then
                           'CStr(String, rows.Item("DateExpire")) = "Đang chờ"
                        'End If
                    Next
                    'ckbReserveCheckAll.Visible = True
                    'divReserveDelete.Visible = True
                    'btnReserveDelete.Visible = True
                    intReserveMax = tblReserve.Rows.Count
                    lblReserve.Text = lblHeaderReserve.Text & ": " & tblReserve.Rows.Count.ToString()
                    dgrReserve.Visible = True
                    dgrReserve.DataSource = tblReserve
                    dgrReserve.DataBind()
                Else
                    lblReserve.Text = lblHeaderReserve.Text & ": 0"
                End If
            Else
                lblReserve.Text = lblHeaderReserve.Text & ": 0"
            End If


            objBOPACPatronInfor.CardNo = Trim(clsSession.GlbUser & "")
            tblReservation = objBOPACPatronInfor.GetReservationOther(lblGetBefore.Text, lblHour.Text, lblDate.Text, lblLibaryName.Text, lblPosition.Text)
            Session("CountReservation") = If(tblReservation Is Nothing, 0, tblReservation.Rows.Count)
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
            tblOnHolding = objBOPACPatronInfor.GetOnHoldingOther(lblCheckOutDate.Text, lblCheckInDate.Text, lblOverDueDate.Text, lblDate.Text, lblOnHoldingB.Text, lblRenew.Text, lblNotRenew.Text)
            If Not tblOnHolding Is Nothing Then
                If tblOnHolding.Rows.Count > 0 Then
                    dgrOnHolding.Visible = True
                    dgrOnHolding.CurrentPageIndex = CType(Session("pageIndex").ToString(), Integer)
                    dgrOnHolding.DataSource = tblOnHolding
                    dgrOnHolding.DataBind()
                    btnOnHolding.Text = lblHeaderOnHolding.Text & ": " & tblOnHolding.Rows.Count.ToString()
                Else
                    btnOnHolding.Text = lblHeaderOnHolding.Text & ": 0"
                End If

            Else
                btnOnHolding.Text = lblHeaderOnHolding.Text & ": 0"
                Session("pageIndex") = 0
                dgrOnHolding.CurrentPageIndex = CType(Session("pageIndex").ToString(), Integer)
                dgrOnHolding.DataSource = Nothing
                dgrOnHolding.DataBind()
            End If
            ''
           
            'Try
            'tblCreateloanReport = objBOPACPatronInfor.GetHoldingOther()
            '        tblCreateloanReport.Columns.Add("STT")
            '        If Not tblCreateloanReport Is Nothing Then
            '             For inti = 0 To tblCreateloanReport.Rows.Count - 1
            '                tblCreateloanReport.Rows(inti).Item("STT") = inti + 1
            '             Next
            '        End If
            '        'If Not tblCreateloanReport Is Nothing Then
            '        If tblCreateloanReport.Rows.Count > 0 Then

            '            dgrHolding.Visible = True
            '            dgrHolding.CurrentPageIndex = CType(Session("pageIndex").ToString(), Integer)
            '            dgrHolding.DataSource = tblCreateloanReport
            '            dgrHolding.DataBind()
            '            btnHolding.Text = btnHolding.Text & ": " & tblCreateloanReport.Rows.Count.ToString()
            '        Else
            '            btnHolding.Text = btnHolding.Text & ": 0"
            '            Session("pageIndex") = 0
            '            dgrHolding.CurrentPageIndex = CType(Session("pageIndex").ToString(), Integer)
            '            dgrHolding.DataSource = Nothing
            '            dgrHolding.DataBind()
            '        End If
            '        'Else
            '        '    btnHolding.Text = btnHolding.Text & ": 0"
            '        'End If
            '    Catch ex As Exception
            '    End Try

            '' Get Patron ILLRequest
            'objBOPACPatronInfor.CardNo = Trim(clsSession.GlbUser & "")
            'tblILLRequest = objBOPACPatronInfor.GetILLRequest(lblCreatedDate.Text, lblStatus.Text, lbldelILL.Text)
            'If Not tblILLRequest Is Nothing Then
            '    If tblILLRequest.Rows.Count > 0 Then
            '        dgrILLRequest.Visible = True
            '        dgrILLRequest.DataSource = tblILLRequest
            '        dgrILLRequest.DataBind()
            '    End If
            'End If
            ' Get Patron Interest Items
            objBOPACPatronInfor.CardNo = Trim(clsSession.GlbUser & "")
            objBOPACPatronInfor.Password = Trim(clsSession.GlbPassword & "")
            Dim patronResult As DataTable = objBOPACPatronInfor.GetPatronOther()
            If Not (IsNothing(patronResult) AndAlso patronResult.Rows.Count = 1) Then
                lblNotePatron.Text = patronResult.Rows(0).Item("Note").ToString()
            Else
                lblNotePatron.Text = ""
            End If

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

            tblPatronInfor = objBOPACPatronInfor.GetPatronInfo()
            If tblPatronInfor IsNot Nothing Then
                If tblPatronInfor.Rows.Count > 0 Then
                    hidEmail.Value = If(IsDBNull(tblPatronInfor.Rows(0).Item("Email")),
                                        "", tblPatronInfor.Rows(0).Item("Email"))
                    hidFacebook.Value = If(IsDBNull(tblPatronInfor.Rows(0).Item("Facebook")),
                                        "", tblPatronInfor.Rows(0).Item("Facebook"))
                    hidMobile.Value = If(IsDBNull(tblPatronInfor.Rows(0).Item("Mobile")),
                                        "", tblPatronInfor.Rows(0).Item("Mobile"))
                    hidTelephone.Value = If(IsDBNull(tblPatronInfor.Rows(0).Item("Telephone")), "", tblPatronInfor.Rows(0).Item("Telephone"))
                    hidDOB.Value = If(IsDBNull(tblPatronInfor.Rows(0).Item("DOB")), "", tblPatronInfor.Rows(0).Item("DOB"))
                    lblFullName.Text = If(IsDBNull(tblPatronInfor.Rows(0).Item("FullName")),
                                            "", tblPatronInfor.Rows(0).Item("FullName"))
                    lblGender.Text = If(IsDBNull(tblPatronInfor.Rows(0).Item("SexName")),
                                            "", tblPatronInfor.Rows(0).Item("SexName"))
                    lblEmail.Text = hidEmail.Value
                    lblFacebook.Text = hidFacebook.Value
                    lblMobile.Text = hidMobile.Value
                    lblTelephone.Text = hidTelephone.Value
                    lblDOB.Text = hidDOB.Value
                    lblClass.Text = If(IsDBNull(tblPatronInfor.Rows(0).Item("Class")),
                                            "", tblPatronInfor.Rows(0).Item("Class"))
                    lblFaculty.Text = If(IsDBNull(tblPatronInfor.Rows(0).Item("Faculty")),
                                        "", tblPatronInfor.Rows(0).Item("Faculty"))
                    lblValidDate.Text = If(IsDBNull(tblPatronInfor.Rows(0).Item("ValidDate")),
                                        "", tblPatronInfor.Rows(0).Item("ValidDate"))
                    lblExpiredDate.Text = If(IsDBNull(tblPatronInfor.Rows(0).Item("ExpiredDate")),
                                            "", tblPatronInfor.Rows(0).Item("ExpiredDate"))
                    lblCode.Text = tblPatronInfor.Rows(0).Item("Code")
                    lblGroupName.Text = If(IsDBNull(tblPatronInfor.Rows(0).Item("GroupName")),
                                            "", tblPatronInfor.Rows(0).Item("GroupName"))
                    lblGrade.Text = If(IsDBNull(tblPatronInfor.Rows(0).Item("Grade")),
                                            "", tblPatronInfor.Rows(0).Item("Grade"))

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

            'Clear the last search
            Session("IDs") = Nothing 'Release cache
            'Init some value
            Dim colData As New Collection
            colData.Add("ISBD", "Display")
            colData.Add(False, "SecuredOPAC")
            colData.Add(Session("AccessLevel"), "AccessLevel")
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

            Call BindScript()
        End Sub

        'purpose: Pick selected Reservation ItemID
        Private Function PickReservationItemIDs() As String
            Dim intIndex As Integer
            Dim strIDs As String = ""
            For intIndex = 0 To dgrReservation.Items.Count - 1
                If CType(dgrReservation.Items(intIndex).Cells(0).FindControl("ckbItemID"), CheckBox).Checked = True Then
                    strIDs &= CType(dgrReservation.Items(intIndex).Cells(0).FindControl("txtItemID"), HiddenField).Value.ToString & ","
                End If
            Next
            If strIDs <> "" Then
                strIDs = Left(strIDs, strIDs.Length - 1)
            End If
            Return (strIDs)
        End Function
        Private Function PickReserveItemIDs() As String
            Dim intIndex As Integer
            Dim strIDs As String = ""
            For intIndex = 0 To dgrReserve.Items.Count - 1
                If CType(dgrReserve.Items(intIndex).Cells(0).FindControl("ckbItemID"), CheckBox).Checked = True Then
                    strIDs &= CType(dgrReserve.Items(intIndex).Cells(0).FindControl("txtItemID"), HiddenField).Value.ToString & ","
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

        'Protected Sub btnReserveDelete_Click(sender As Object, e As EventArgs) Handles btnReserveDelete.Click
        '    Dim strPickReserveItemIDs As String
        '    strPickReserveItemIDs = PickReserveItemIDs()
        '    ' Delete patron reservation here
        '    If Len(strPickReserveItemIDs) > 0 Then
        '        objBReserve.DeleteReserve(strPickReserveItemIDs)
        '        strPickReserveItemIDs = ""
        '    End If
        '    ' Refresh Data
        '    Call BindData()
        'End Sub
        Private Sub Initialize()

             ' Init objBOPACPatronInfor object
            objBOPACPatronInfor.ConnectionString = Session("ConnectionString")
            objBOPACPatronInfor.DBServer = Session("DBServer")
            objBOPACPatronInfor.InterfaceLanguage = Session("InterfaceLanguage")
            objBOPACPatronInfor.Initialize()

            ' Init objBCDBS object
            objBCDBS.ConnectionString = Session("ConnectionString")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.Initialize()

            ' Init objBReserve object
            objBReserve.ConnectionString = Session("ConnectionString")
            objBReserve.DBServer = Session("DBServer")
            objBReserve.InterfaceLanguage = Session("InterfaceLanguage")
            objBReserve.Initialize()

            ' Init objBOPACLoanRequest object
            objBOPACLoanRequest.ConnectionString = Session("ConnectionString")
            objBOPACLoanRequest.DBServer = Session("DBServer")
            objBOPACLoanRequest.InterfaceLanguage = Session("InterfaceLanguage")
            objBOPACLoanRequest.Initialize()

        End Sub

        Private Sub BindScript()
            'Page.RegisterClientScriptBlock("WPersonalPageJs", "<script language='javascript' src='JS/OPersonal.js'></script>")
            ' Selecte all reservation (javascript)
            ckbCheckAll.Attributes.Add("OnClick", "CheckAll('dgrReservation','ckbItemID','ckbCheckAll'," & intReservationMax & ");")
            btnReservationDelete.Attributes.Add("OnClick", "return(CheckReservationSelected(" & intReservationMax & ",'" & spChooseDocument.InnerText & "'));")
            'CheckAllReserve
            'ckbReserveCheckAll.Attributes.Add("OnClick", "CheckAllReserve(" & intReserveMax & ");")
            'btnReserveDelete.Attributes.Add("OnClick", "return(CheckReserveSelected(" & intReserveMax & ",'" & spChooseDocument.InnerText & "'));")
            ' btnUpdateInfor.Attributes.Add("OnClick", "document.forms[0].method='post';document.forms[0].action='WUpdatePersonalPage.aspx';document.forms[0].submit();return(false);")
            'Me.RegisterCalendar("../..")
            'SetOnclickCalendar(lnkDOB, "txtDOB")
        End Sub

        
        Protected Sub Tab1_Click(ByVal sender As Object, ByVal e As EventArgs)
            If CType(Session("CountReservation"), Integer) > 0 Then
                ckbCheckAll.Visible = True
                dgrInterestItem.Visible = True
                btnReservationDelete.Visible = True
                divReservationDelete.Visible = True
            End If
            MainView.ActiveViewIndex = 0
            Call BindScript()
        End Sub
        Protected Sub Tab2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnHolding.Click
            MainView.ActiveViewIndex = 1
            If CType(Session("CountReservation"), Integer) > 0 Then
                ckbCheckAll.Visible = True
                dgrInterestItem.Visible = True
                btnReservationDelete.Visible = True
                divReservationDelete.Visible = True
            End If
            BindScript()
        End Sub
        Protected Sub BindData2()
            objBOPACPatronInfor.CardNo = Trim(clsSession.GlbUser & "")
            Dim tblCreateloanReport As DataTable
            Dim inti As Integer
            If CType(Session("CountReservation"), Integer) > 0 Then
                ckbCheckAll.Visible = True
                dgrInterestItem.Visible = True
                btnReservationDelete.Visible = True
                divReservationDelete.Visible = True
            End If
            Try
                tblCreateloanReport = objBOPACPatronInfor.GetHoldingOther()
                tblCreateloanReport.Columns.Add("STT")
                If Not tblCreateloanReport Is Nothing Then
                    For inti = 0 To tblCreateloanReport.Rows.Count - 1
                        tblCreateloanReport.Rows(inti).Item("STT") = inti + 1
                    Next
                End If
                If Not tblCreateloanReport Is Nothing Then
                    If tblCreateloanReport.Rows.Count > 0 Then

                        'dgrHolding.Visible = True
                        dgrHolding.CurrentPageIndex = CType(Session("pageIndex").ToString(), Integer)
                        dgrHolding.DataSource = tblCreateloanReport
                        dgrHolding.DataBind()
                        btnHolding.Text = lblHeaderHolding.Text & ": " & tblCreateloanReport.Rows.Count.ToString()
                    Else
                        btnHolding.Text = lblHeaderHolding.Text & ": 0"
                    End If
                Else
                    btnHolding.Text = lblHeaderHolding.Text & ": 0"
                    Session("pageIndex") = 0
                    dgrHolding.CurrentPageIndex = CType(Session("pageIndex").ToString(), Integer)
                    dgrHolding.DataSource = Nothing
                    dgrHolding.DataBind()
                End If
            Catch ex As Exception
            End Try

        End Sub
       

        Public Function GetBBK_DDC() As String
            Dim arrParameterText(0) As String
            Dim arrParameterValue(0) As String
            arrParameterText(0) = "USED_CLASSIFICATION"
            arrParameterValue = objBCDBS.GetSystemParameters(arrParameterText)
            If Not IsDBNull(arrParameterValue(0)) And arrParameterValue(0) = "1" Then
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
                If Not objBReserve Is Nothing Then
                    objBReserve.Dispose(True)
                    objBReserve = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBOPACLoanRequest Is Nothing Then
                    objBOPACLoanRequest.Dispose(True)
                    objBOPACLoanRequest = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        <System.Web.Services.WebMethod>
        Public Shared Function Update(ByVal action As Integer, ByVal value As String) As Boolean
            Return True
        End Function


        Protected Sub dgrOnHolding_PageIndexChanged(source As Object, e As DataGridPageChangedEventArgs) Handles dgrOnHolding.PageIndexChanged
            Session("pageIndex") = e.NewPageIndex
            BindData()
        End Sub

        Protected Sub dgrHolding_PageIndexChanged(source As Object, e As DataGridPageChangedEventArgs) Handles dgrHolding.PageIndexChanged
            Session("pageIndex") = e.NewPageIndex
            BindData2()
        End Sub

        Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
            'Try
            '    objBOPACPatronInfor.CardNo = clsSession.GlbUser
            '    objBOPACPatronInfor.Tel = If(hidTelephoneUpdated.Value = "", hidTelephone.Value, hidTelephoneUpdated.Value)
            '    objBOPACPatronInfor.Mobile = If(hidMobileUpdated.Value = "", hidMobile.Value, hidMobileUpdated.Value)
            '    objBOPACPatronInfor.Email = If(hidEmailUpdated.Value = "", hidEmail.Value, hidEmailUpdated.Value)
            '    objBOPACPatronInfor.Facebook = If(hidFacebookUpdated.Value = "", hidFacebook.Value, hidFacebookUpdated.Value)
            '    objBOPACPatronInfor.DOB = If(hidDOBUpdated.Value = "", hidDOB.Value, hidDOBUpdated.Value)
            '    objBOPACPatronInfor.UpdatePatron()
            'Catch ex As Exception
            'End Try

            If txtPasswordOld.Text <> clsSession.GlbPassword Then
                Page.RegisterClientScriptBlock("AlertRenewJs", "<script language='javascript'>alert('" & lbPasswordOldNotTrue.Text & "');</script>")
            Else
                If txtPasswordNew.Text <> txtPasswordNewRe.Text Then
                    Page.RegisterClientScriptBlock("AlertRenewJs", "<script language='javascript'>alert('" & lbPasswordReNotTrue.Text & "');</script>")
                Else
                    objBOPACPatronInfor.CardNo = clsSession.GlbUser
                    objBOPACPatronInfor.Password = txtPasswordNew.Text
                    Dim intUpdatePassword As Integer = objBOPACPatronInfor.UpdatePasswordPatron()
                    If intUpdatePassword = 1 Then
                        Page.RegisterClientScriptBlock("AlertRenewJs", "<script language='javascript'>alert('" & lbChangePassSuccess.Text & "');</script>")
                        clsSession.GlbPassword = txtPasswordNew.Text
                        Call BindData()
                        Call BindData2()
                    Else
                        Page.RegisterClientScriptBlock("AlertRenewJs", "<script language='javascript'>alert('" & lbChangePassError.Text & "');</script>")
                    End If

                End If
            End If

        End Sub

        Private Sub btRenews_Click(sender As Object, e As EventArgs) Handles btRenews.Click
            Dim intLoanID As String = hdCirIDRenew.Value
            Dim intResultRenew As Integer = objBOPACLoanRequest.Renew(intLoanID)
            If intResultRenew = 1 Then
                Page.RegisterClientScriptBlock("AlertRenewJs", "<script language='javascript'>alert('" & lbRenewSuccess.Text & "');</script>")
                Call BindData()
                Call BindData2()
            Else
                Page.RegisterClientScriptBlock("AlertRenewJs", "<script language='javascript'>alert('" & lbRenewError.Text & "');</script>")
            End If
        End Sub
    End Class
End Namespace
