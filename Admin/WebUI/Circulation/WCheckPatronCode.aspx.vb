' Class: WCheckPatronCode
' Puspose: Check infor of the Patron depending on PatronCode
' Creator: Oanhtn
' CreatedDate: 25/08/2004
' Modification History:
'   - 17/04/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.WebUI.Common
Imports System.Activities.Expressions
Imports System.Globalization

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WCheckPatronCode
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
        Private objBLoanTransaction As New clsBLoanTransaction
        Private objBPatron As New clsBPatron

        Private objBLoanTransactionDetail As New clsBLoanTransaction

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
            If Not IsPostBack Then
                CheckPatronCode()
                ShowPatronInfor()
            End If

        End Sub

        ' Method: Initialize
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            Response.Expires = 0

            ' Init objBLoanTransaction object
            objBLoanTransaction.InterfaceLanguage = Session("InterfaceLanguage")
            objBLoanTransaction.DBServer = Session("DBServer")
            objBLoanTransaction.ConnectionString = Session("ConnectionString")
            Call objBLoanTransaction.Initialize()


            objBLoanTransactionDetail.InterfaceLanguage = Session("InterfaceLanguage")
            objBLoanTransactionDetail.DBServer = Session("DBServer")
            objBLoanTransactionDetail.ConnectionString = Session("ConnectionString")
            Call objBLoanTransactionDetail.Initialize()

            ' Init objBPatron object
            objBPatron.InterfaceLanguage = Session("InterfaceLanguage")
            objBPatron.DBServer = Session("DBServer")
            objBPatron.ConnectionString = Session("ConnectionString")
            Call objBPatron.Initialize()
        End Sub

        ' Method: BindScript
        ' Purpose: include all neccessary javascript functions
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
        End Sub

        ' Method: CheckPatronCode
        ' Purpose: check infor depending on CopyNumber
        Private Sub CheckPatronCode()
            Dim strPatronCode As String = Request("PatronCode")
            Dim intUserID As Integer = CInt(Session("UserID"))
            objBLoanTransaction.PatronCode = strPatronCode
            objBLoanTransaction.UserID = intUserID
            objBLoanTransaction.LibID = clsSession.GlbSite

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPatron.ErrorMsg, ddlLabel.Items(0).Text, objBPatron.ErrorCode)


            Dim tblLoanDataInfor As DataTable
            objBLoanTransactionDetail.PatronCode = strPatronCode
            objBLoanTransactionDetail.LoanMode = 1
            objBLoanTransactionDetail.UserID = intUserID
            objBLoanTransactionDetail.LibID = clsSession.GlbSite

            Call WriteErrorMssg(ddlLabelLoanDetail.Items(1).Text, objBLoanTransactionDetail.ErrorMsg, ddlLabelLoanDetail.Items(0).Text, objBLoanTransactionDetail.ErrorCode)

            ' Hidden som controls
            'lblClick.Visible = False
            'btnAllow.Visible = False
            'lblContinue.Visible = False

            'tblLoanDataInfor = objBLoanTransactionDetail.GetLoanDetailInfor(1)
            tblLoanDataInfor = objBLoanTransactionDetail.GetLoanDetailInforFull(1)
            Dim tblCopy As New DataTable

            tblCopy.Columns.Add("STT")
            tblCopy.Columns.Add("ID")
            tblCopy.Columns.Add("CopyNumber")
            tblCopy.Columns.Add("TITLE")
            tblCopy.Columns.Add("CheckOutDate")
            tblCopy.Columns.Add("DueDate")
            tblCopy.Columns.Add("Note")
            tblCopy.Columns.Add("RenewCount")

            If Not tblLoanDataInfor Is Nothing Then

                If tblLoanDataInfor.Rows.Count > 0 Then

                    'Dim newColumn As New Data.DataColumn("STT", GetType(System.String))
                    'newColumn.DefaultValue = "1"
                    'tblLoanDataInfor.Columns.Add(newColumn)
                    
                    Dim indexRows As Integer = 1
                    For Each dt As DataRow In tblLoanDataInfor.Rows
                        Dim dtCopy As DataRow = tblCopy.NewRow
                        dtCopy.Item("STT") = indexRows
                        dtCopy.Item("ID") = dt.Item("ID").ToString
                        dtCopy.Item("TITLE") = dt.Item("TITLE").ToString
                        dtCopy.Item("CopyNumber") = dt.Item("CopyNumber").ToString
                        dtCopy.Item("CheckOutDate") = dt.Item("CheckOutDate").ToString
                        dtCopy.Item("Note") = dt.Item("Note").ToString
                        dtCopy.Item("RenewCount") = dt.Item("RenewCount").ToString
                        dtCopy.Item("DueDate") = dt.Item("DUEDATE").ToString
                        'rows.Item("STT") = indexRows.ToString()
                        'indexRows = indexRows + 1
                        If Not IsDBNull(dt.Item("DUEDATE")) And CStr(dt.Item("DUEDATE")) <> "" Then
                            If DateDiff(DateInterval.Day, dt.Item("DUEDATE"), Now()) > 0 Then
                                dtCopy.Item("DueDate") = dt.Item("DUEDATE") & vbCrLf & "<font color='red'>" & ddlLabel.Items(2).Text & DateDiff(DateInterval.Day, dt.Item("DUEDATE"), Now()) & ddlLabel.Items(3).Text & "</font>"
                            End If
                        Else
                            dtCopy.Item("DueDate") = dt.Item("DUEDATE") & vbCrLf & "<font color='Blue'>" & ddlLabel.Items(4).Text & "</font>"
                        End If
                        tblCopy.Rows.Add(dtCopy)
                        indexRows = indexRows + 1
                    Next

                    dtgResult.DataSource = tblCopy
                    dtgResult.DataBind()
                    dtgResult.Visible = True
                End If
                tblLoanDataInfor = Nothing
                tblCopy = Nothing
            End If
        End Sub

        ' Method: ShowPatronInfor
        ' Purpose: Show some main informations of the selected Patron
        ' Input: Patron' status
        '   -- 0: OK
        '   -- 2: Card expired
        '   -- 3: Quota exceeded (Loan in lib)
        '   -- 4: Card is locked
        '   -- 5: Patron doesn't has access permission to one of the locations which this librarian has manage permission
        '   -- 6: Quota exceeded (Loan out of quota)
        '   -- 7: ValidDate
        Public Sub ShowPatronInfor()
            Dim intStatus As Int16
            Dim intLoanMode As Int16 = 1
            Dim strPatronCode = Trim(Request("PatronCode"))
            If Not Request("LoanMode") = "" Then
                intLoanMode = CInt(Request("LoanMode"))
            End If
            intStatus = objBLoanTransaction.CheckPatronCode(intLoanMode)


            If intStatus = 1 Then ' PatronCode is invalid
                If Request("From") = "" Then
                    Response.Redirect("WAddPatron.aspx?PatronCode=" & strPatronCode)
                Else
                    Page.RegisterClientScriptBlock("InvalidPatronCodeJs", "<script language = 'javascript'>alert('" & lblMsg1.Text & "');parent.Workform.document.forms[0].txtPatronCodeText.value = '';parent.Workform.document.forms[0].txtPatronCodeText.focus();</script>")
                End If
            Else
                If Request("From") = "" Then
                    Dim tblPatronInfor As DataTable
                    Dim tblLoanInfor As DataTable
                    Dim tblLocation As DataTable
                    Dim intCount As Integer

                    lnkOverdueQuotaOut.Visible = False
                    lnkOnLoanHome.Visible = False
                    lnkOverdueHome.Visible = False
                    lnkOnLoanLib.Visible = False
                    lnkOverdueLib.Visible = False
                    lnkOnLoanQuotaOut.Visible = False
                    lnkRenew.Visible = False

                    objBPatron.PatronCode = strPatronCode
                    objBPatron.LibID = clsSession.GlbSite
                    tblPatronInfor = objBPatron.GetPatronInfor()

                    ' Check error
                    Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPatron.ErrorMsg, ddlLabel.Items(0).Text, objBPatron.ErrorCode)


                    If Not tblPatronInfor Is Nothing Then
                        If tblPatronInfor.Rows.Count > 0 Then

                            Dim lngPatronID = CLng(tblPatronInfor.Rows(0).Item("ID"))
                            Dim tmpUpdateLoanMode As Integer = objBLoanTransaction.UpdateLoanModePatron(lngPatronID)

                            If Not IsDBNull(tblPatronInfor.Rows(0).Item("FullName")) Then
                                lblFullName.Text = CStr(tblPatronInfor.Rows(0).Item("FullName")) & " (" & CStr(tblPatronInfor.Rows(0).Item("Code")) & ")"
                            Else
                                lblFullName.Text = " (" & CStr(tblPatronInfor.Rows(0).Item("Code")) & ")"
                            End If
                            'lblDOB.Text = lblDOB.Text & " <B>" & CStr(tblPatronInfor.Rows(0).Item("DOB")) & "</B>"
                            'lblValidDate.Text = lblValidDate.Text & " <B>" & CStr(tblPatronInfor.Rows(0).Item("VALIDDATE")) & "</B>"
                            'lblExpiredDate.Text = lblExpiredDate.Text & " <B>" & CStr(tblPatronInfor.Rows(0).Item("EXPIREDDATE")) & "</B>"
                            'lblPatronGroup.Text = lblPatronGroup.Text & " <B>" & CStr(tblPatronInfor.Rows(0).Item("GroupName")) & "</B>"

                            lblDOB.Text = " <B>" & CStr(tblPatronInfor.Rows(0).Item("DOB")) & "</B>"
                            lblValidDate.Text = " <B>" & CStr(tblPatronInfor.Rows(0).Item("VALIDDATE")) & "</B>"
                            lblExpiredDate.Text = " <B>" & CStr(tblPatronInfor.Rows(0).Item("EXPIREDDATE")) & "</B>"
                            lblPatronGroup.Text = " <B>" & CStr(tblPatronInfor.Rows(0).Item("GroupName")) & "</B>"
                            lblNote.Text = " <I>" & CStr(tblPatronInfor.Rows(0).Item("Note")) & "</I>"

                            'lblDebt.Text = lblDebt.Text & " <B>" & Right(Trim(CStr(CLng(tblPatronInfor.Rows(0).Item("Debt")))), Len(Trim(CStr(CLng(tblPatronInfor.Rows(0).Item("Debt"))))) - 1) & "</B>"


                            If Not tblPatronInfor.Rows(0).Item("Debt") Is Nothing Then
                                Dim currency As Double = tblPatronInfor.Rows(0).Item("Debt")
                                If currency < 0 Then
                                    'lblDebt.Text = lblDebt.Text & " <B>" & (currency * -1).ToString("N0", CultureInfo.InvariantCulture) & " VND </B>"
                                    lblDebt.Text = " <B>" & (currency * -1).ToString("N0", CultureInfo.InvariantCulture) & " VND </B>"
                                Else
                                    'lblDebt.Text = lblDebt.Text & " <B>0 VND</B>"
                                    lblDebt.Text = " <B>0 VND</B>"
                                End If

                            End If
                            ' Add some warning
                            lblLocation.Visible = False
                            Page.RegisterClientScriptBlock("ContinueJs", "<script language = 'javascript'>parent.CheckOut.document.forms[0].hidContinue.value=1; parent.CheckOut.document.forms[0].hidError.value=0;</script>")
                            'Page.RegisterClientScriptBlock("ContinueJs", "<script language = 'javascript'>parent.CheckOut.document.forms[0].hidContinue.value=1;</script>")
                            If intStatus = 2 Then 'Expired
                                'lblDebt.Text = lblDebt.Text & " (<FONT COLOR=""RED"">" & lblMsg2.Text & "</FONT>)"
                                lblDebt.Text = " (<FONT COLOR=""RED"">" & lblMsg2.Text & "</FONT>)"
                                Page.RegisterClientScriptBlock("NoContinueJs", "<script language = 'javascript'>parent.CheckOut.document.forms[0].hidContinue.value=0; parent.CheckOut.document.forms[0].hidError.value=1;</script>")
                                lnkRenew.Visible = True
                                lnkRenew.NavigateUrl = "javascript:OpenWindow('WRenewPatronCard.aspx?PatronCode=" & strPatronCode & "&LoanMode=" & intLoanMode & "', 'WRenewPatronCard',500,300,200,150);"
                            ElseIf intStatus = 3 Then 'quota exceed
                                If Not intLoanMode = 3 Then
                                    Page.RegisterClientScriptBlock("NoContinueJs", "<script language = 'javascript'>parent.CheckOut.document.forms[0].hidContinue.value=0;</script>")
                                    'lblClick.Visible = True
                                    'btnAllow.Visible = True
                                    'lblContinue.Visible = True
                                    'btnAllow.Attributes.Add("OnClick", "javascript:parent.CheckOut.document.forms[0].hidLoanMode.value=3; parent.CheckOut.document.forms[0].hidContinue.value=1; return false;")
                                End If
                                'lblDebt.Text = lblDebt.Text & " (<FONT COLOR=""RED"">" & lblMsg3.Text & "</FONT>)"
                                lblDebt.Text = " (<FONT COLOR=""RED"">" & lblMsg3.Text & "</FONT>)"
                            ElseIf intStatus = 4 Then 'Locked
                                'lblDebt.Text = lblDebt.Text & " (<FONT COLOR=""RED"">" & lblMsg4.Text & "</FONT>)"
                                lblDebt.Text = " (<FONT COLOR=""RED"">" & lblMsg4.Text & "</FONT>)"
                                Page.RegisterClientScriptBlock("JSSucc", "<script language='javascript'>parent.CheckOut.document.forms[0].txtPatronCode.value='';</script>")
                            ElseIf intStatus = 5 Then 'Not permission
                                lblLocation.Visible = True
                                tblLocation = objBLoanTransaction.GetPatronLocations(strPatronCode)
                                If tblLocation.Rows.Count > 0 Then
                                    'For intCount = 0 To tblLocation.Rows.Count - 1
                                    '    lblLocation.Text = lblLocation.Text & CStr(tblLocation.Rows(intCount).Item("Library")) & ":" & CStr(tblLocation.Rows(intCount).Item("Symbol")) & ", "
                                    'Next
                                    'lblLocation.Text = Left(lblLocation.Text, Len(lblLocation.Text) - 2)
                                    Dim resultLocation As String = ""
                                    For intCount = 0 To tblLocation.Rows.Count - 1
                                        resultLocation = resultLocation & CStr(tblLocation.Rows(intCount).Item("Library")) & ":" & CStr(tblLocation.Rows(intCount).Item("Symbol")) & ", "
                                    Next
                                    lblLocation.Text = Left(resultLocation, Len(resultLocation) - 2)
                                End If
                            ElseIf intStatus = 6 Then
                                Page.RegisterClientScriptBlock("NoContinueJs", "<script language = 'javascript'>parent.CheckOut.document.forms[0].hidContinue.value=0;</script>")
                                'lblClick.Visible = True
                                'btnAllow.Visible = True
                                'lblContinue.Visible = True
                                'btnAllow.Attributes.Add("OnClick", "javascript:parent.CheckOut.document.forms[0].hidLoanMode.value=3; parent.CheckOut.document.forms[0].hidContinue.value=1; return false;")
                            ElseIf intStatus = 7 Then 'ValidDate
                                'lblDebt.Text = lblDebt.Text & " (<FONT COLOR=""RED"">Thẻ chưa có hiệu lực</FONT>)"
                                lblDebt.Text = " (<FONT COLOR=""RED"">Thẻ chưa có hiệu lực</FONT>)"
                                Page.RegisterClientScriptBlock("JSSucc", "<script language='javascript'>parent.CheckOut.document.forms[0].txtPatronCode.value='';</script>")
                            End If

                            ' Set focus for txtCopyNumber
                            Page.RegisterClientScriptBlock("CopyNumberFocusJs", "<script language = 'javascript'>parent.CheckOut.document.forms[0].txtCopyNumber.focus();</script>")

                            ' Show patron' image
                            If Not IsDBNull(tblPatronInfor.Rows(0).Item("Portrait")) Then

                                Dim strURL As String = "../Images/Card/" & Trim(CStr(tblPatronInfor.Rows(0).Item("Portrait")))
                                imgPatronImage.Src = "../Common/ShowPic.aspx?intw=90&inth=120&Url=" & strURL

                            End If

                            ' Show detail information of this Patron
                            lnkDetailInfor.NavigateUrl = "javascript:OpenWindow('WPatronDetail.aspx?PatronCode=" & strPatronCode & "','WPatronDetail',700,600,100,100);"


                            ' Show loan information of this Patron


                            tblLoanInfor = objBLoanTransaction.GetLoanInfor()

                            ' Check error
                            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBLoanTransaction.ErrorMsg, ddlLabel.Items(0).Text, objBLoanTransaction.ErrorCode)

                            If Not tblLoanInfor Is Nothing Then
                                If tblPatronInfor.Rows.Count > 0 Then
                                    Dim dtrData As DataRow()
                                    Dim intQuotaHome As Int16 = 0
                                    Dim intQuotaLib As Int16 = 0
                                    Dim intLoanHome As Int16 = 0
                                    Dim intLoanLib As Int16 = 0
                                    Dim intLoanOut As Int16 = 0
                                    Dim intOverdueHome As Int16 = 0
                                    Dim intOverdueLib As Int16 = 0
                                    Dim intOverdueQuotaOut As Int16 = 0
                                    Dim intRemainHome As Int16 = 0
                                    Dim intRemainLib As Int16 = 0

                                    intQuotaHome = CInt(tblPatronInfor.Rows(0).Item("LoanQuota"))
                                    intQuotaLib = CInt(tblPatronInfor.Rows(0).Item("InLibraryQuota"))

                                    'lblQuotaHome.Text = lblQuotaHome.Text & " <B>" & CInt(intQuotaHome) & "</B>"
                                    lblQuotaHome.Text = " <B>" & CInt(intQuotaHome) & "</B>"
                                    'lblQuotaLib.Text = lblQuotaLib.Text & " <B>" & CInt(intQuotaLib) & "</B>"
                                    lblQuotaLib.Text = " <B>" & CInt(intQuotaLib) & "</B>"

                                    ' Get Loan infor
                                    intRemainHome = intQuotaHome - intLoanHome
                                    dtrData = tblLoanInfor.Select("Mode=1 AND LoanMode = 1")
                                    If dtrData.Length > 0 Then
                                        intLoanHome = dtrData(0).Item("NOR")
                                        'lblOnLoanHome.Text = lblOnLoanHome.Text & " <B>" & CStr(intLoanHome) & "</B>"
                                        lblOnLoanHome.Text = " <B>" & CStr(intLoanHome) & "</B>"
                                        If intLoanHome > 0 Then
                                            lnkOnLoanHome.Visible = True
                                            lnkOnLoanHome.NavigateUrl = "javascript:OpenWindow('WLoanDetail.aspx?Mode=1&LoanMode=1&PatronCode=" & strPatronCode & "', 'WLoanDetail',540,300,200,100);"
                                            intRemainHome = intQuotaHome - intLoanHome
                                            If intRemainHome < 0 Then intRemainHome = 0
                                        End If
                                    Else
                                        lblOnLoanHome.Text = " <B>0</B>"
                                    End If
                                    'lblRemainHome.Text = lblRemainHome.Text & " <B>" & intRemainHome & "</B>"
                                    lblRemainHome.Text = " <B>" & intRemainHome & "</B>"
                                    tblLoanInfor.Select()

                                    intRemainLib = intQuotaLib - intLoanLib
                                    dtrData = tblLoanInfor.Select("Mode=1 AND LoanMode = 2")
                                    If dtrData.Length > 0 Then
                                        intLoanLib = CInt(dtrData(0).Item("NOR"))
                                        'lblOnLoanLib.Text = lblOnLoanLib.Text & " <B>" & CStr(intLoanLib) & "</B>"
                                        lblOnLoanLib.Text = ""
                                        lblOnLoanLib.Text = " <B>" & CStr(intLoanLib) & "</B>"
                                        If intLoanLib > 0 Then
                                            lnkOnLoanLib.Visible = True
                                            lnkOnLoanLib.NavigateUrl = "javascript:OpenWindow('WLoanDetail.aspx?Mode=1&LoanMode=2&PatronCode=" & strPatronCode & "', 'WLoanDetail',540,300,200,100);"
                                            intRemainLib = intQuotaLib - intLoanLib
                                            If intRemainLib < 0 Then intRemainLib = 0
                                        End If
                                    Else
                                        lblOnLoanLib.Text = " <B>0</B>"
                                    End If
                                    'lblRemainLib.Text = lblRemainLib.Text & " <B>" & intRemainLib & "</B>"
                                    lblRemainLib.Text = " <B>" & intRemainLib & "</B>"

                                    tblLoanInfor.Select()
                                    dtrData = tblLoanInfor.Select("Mode=1 AND LoanMode = 3")
                                    If dtrData.Length > 0 Then
                                        intLoanOut = CInt(dtrData(0).Item("NOR"))
                                        If intLoanOut > 0 Then
                                            lnkOnLoanQuotaOut.Visible = True
                                            lnkOnLoanQuotaOut.NavigateUrl = "javascript:OpenWindow('WLoanDetail.aspx?Mode=1&LoanMode=3&PatronCode=" & strPatronCode & "', 'WLoanDetail',540,300,200,100);"
                                        End If
                                    End If
                                    'lblOnLoanQuotaOut.Text = lblOnLoanQuotaOut.Text & " <B>" & CStr(intLoanOut) & "</B>"
                                    lblOnLoanQuotaOut.Text = " <B>" & CStr(intLoanOut) & "</B>"
                                    tblLoanInfor.Select()

                                    ' Get overdue infor
                                    dtrData = tblLoanInfor.Select("Mode=2 AND LoanMode = 1")
                                    If dtrData.Length > 0 Then
                                        intOverdueHome = CInt(dtrData(0).Item("NOR"))
                                        If intOverdueHome > 0 Then
                                            lnkOverdueHome.Visible = True
                                            lnkOverdueHome.NavigateUrl = "javascript:OpenWindow('WLoanDetail.aspx?Mode=2&LoanMode=1&PatronCode=" & strPatronCode & "', 'WLoanDetail',540,300,200,100);"
                                        End If
                                    End If
                                    'lblOverdueHome.Text = lblOverdueHome.Text & " <B>" & CStr(intOverdueHome) & "</B>"
                                    lblOverdueHome.Text = " <B>" & CStr(intOverdueHome) & "</B>"
                                    tblLoanInfor.Select()

                                    dtrData = tblLoanInfor.Select("Mode=2 AND LoanMode = 2")
                                    If dtrData.Length > 0 Then
                                        intOverdueLib = CInt(dtrData(0).Item("NOR"))
                                        If intOverdueLib > 0 Then
                                            lnkOverdueLib.Visible = True
                                            lnkOverdueLib.NavigateUrl = "javascript:OpenWindow('WLoanDetail.aspx?Mode=2&LoanMode=2&PatronCode=" & strPatronCode & "', 'WLoanDetail',540,300,200,100);"
                                        End If
                                    End If
                                    'lblOverdueLib.Text = lblOverdueLib.Text & " <B>" & CStr(intOverdueLib) & "</B>"
                                    lblOverdueLib.Text = " <B>" & CStr(intOverdueLib) & "</B>"
                                    tblLoanInfor.Select()

                                    dtrData = tblLoanInfor.Select("Mode=2 AND LoanMode = 3")
                                    If dtrData.Length > 0 Then
                                        intOverdueQuotaOut = CInt(dtrData(0).Item("NOR"))
                                        If intOverdueQuotaOut > 0 Then
                                            lnkOverdueQuotaOut.Visible = True
                                            lnkOverdueQuotaOut.NavigateUrl = "javascript:OpenWindow('WLoanDetail.aspx?Mode=2&LoanMode=3&PatronCode=" & strPatronCode & "', 'WLoanDetail',540,300,200,100);"
                                        End If
                                    End If
                                    'lblOverdueQuotaOut.Text = lblOverdueQuotaOut.Text & " <B>" & CStr(intOverdueQuotaOut) & "</B>"
                                    lblOverdueQuotaOut.Text = " <B>" & CStr(intOverdueQuotaOut) & "</B>"
                                    tblLoanInfor.Select()

                                    If intLoanMode = 1 Then
                                        Session("Remain") = intRemainHome
                                    ElseIf intLoanMode = 2 Then
                                        Session("Remain") = intRemainLib
                                    End If
                                End If
                                tblPatronInfor = Nothing
                            End If
                        End If
                        tblLoanInfor = Nothing
                    End If
                End If
            End If

        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBLoanTransaction Is Nothing Then
                    objBLoanTransaction.Dispose(True)
                    objBLoanTransaction = Nothing
                End If
                If Not objBPatron Is Nothing Then
                    objBPatron.Dispose(True)
                    objBPatron = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        Private Sub dtgResult_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgResult.EditCommand
            dtgResult.EditItemIndex = e.Item.ItemIndex
            dtgResult.DataBind()
            CheckPatronCode()
            ShowPatronInfor()
        End Sub
        Protected Sub dtgResult_CancelCommand(source As Object, e As DataGridCommandEventArgs) Handles dtgResult.CancelCommand
            dtgResult.EditItemIndex = -1
            dtgResult.DataBind()
            CheckPatronCode()
            ShowPatronInfor()
        End Sub

        Protected Sub dtgResult_UpdateCommand(source As Object, e As DataGridCommandEventArgs) Handles dtgResult.UpdateCommand

            Dim loanCell As TableCell = e.Item.Cells(5)

            Dim idLoan As Long = CType(CType(loanCell.FindControl("hidLoanID"), HiddenField).Value, Long)

            Dim loanTextBoxNote As String = CType(loanCell.FindControl("txtLoanNote"), TextBox).Text

            objBLoanTransaction.TransactionID = idLoan
            objBLoanTransaction.DueDate = ""
            objBLoanTransaction.UpdateCurrentLoanRecord(Trim(loanTextBoxNote))

            dtgResult.EditItemIndex = -1
            dtgResult.DataBind()

            CheckPatronCode()
            ShowPatronInfor()
        End Sub

        'Protected Sub dtgResult_ItemCommand(source As Object, e As DataGridCommandEventArgs) Handles dtgResult.ItemCommand
        '    If e.CommandName = "Update" Then

        '        Dim idLoan As String = CType(e.Item.Cells(7).Controls(0), TextBox).Text

        '        ' The quantity is in the 7th column.
        '        Dim loanCell As TableCell = e.Item.Cells(5)

        '        ' The TextBox is the 0th element of the Controls collection.
        '        Dim loanTextBox As TextBox = CType(loanCell.FindControl("txtLoanTran"), TextBox)
        '        Dim noteLoan As String = loanTextBox.Text
        '    End If


        'End Sub
    End Class
End Namespace