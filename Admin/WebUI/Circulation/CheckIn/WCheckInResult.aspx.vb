' Class: WCheckInResult
' Puspose: Display checkin result
' Creator: Oanhtn
' CreatedDate: 06/09/2004
' Modification History:
'   - 17/04/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.WebUI.Common
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WCheckInResult
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Label14 As System.Web.UI.WebControls.Label
        Protected WithEvents Label19 As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBLoanTransaction As New clsBLoanTransaction
        Private objBPatron As New clsBPatron
        Private objBRT As New clsBReservationTransaction
        Private objBReserve As New clsBReserve
        Private objBHolding As New clsBHolding
        Private objBCDBS As New clsBCommonDBSystem
        '' 
        Public strTotalFees As String = ""
        Public strTotalOverdueFine As String = ""
        Public strTotalLoanDepositFee As String = ""
        Public strTotal As String = ""
        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call CheckIn()
                Call ShowDetailInfor()
                Call ShowOnLoanCopies()
                Call ShowLoanCurrentCheckIn()
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: Init all necessary objects
        Private Sub Initialize()
            Response.Expires = 0

            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            Call objBCDBS.Initialize()

            ' Init objBLoanTransaction object
            objBLoanTransaction.InterfaceLanguage = Session("InterfaceLanguage")
            objBLoanTransaction.DBServer = Session("DBServer")
            objBLoanTransaction.ConnectionString = Session("ConnectionString")
            Call objBLoanTransaction.Initialize()

            ' Init objBPatron object
            objBPatron.InterfaceLanguage = Session("InterfaceLanguage")
            objBPatron.DBServer = Session("DBServer")
            objBPatron.ConnectionString = Session("ConnectionString")
            Call objBPatron.Initialize()

            ' Init objBRT object
            objBRT.ConnectionString = Session("ConnectionString")
            objBRT.DBServer = Session("DBServer")
            objBRT.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBRT.Initialize()

            ' Init objBReserve object
            objBReserve.ConnectionString = Session("ConnectionString")
            objBReserve.DBServer = Session("DBServer")
            objBReserve.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBReserve.Initialize()

            ' Init objBReserve object
            objBHolding.ConnectionString = Session("ConnectionString")
            objBHolding.DBServer = Session("DBServer")
            objBHolding.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBHolding.Initialize()
        End Sub

        ' Method: BindScript
        ' Purpose: include all neccessary javascript functions
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../Js/CheckIn/WCheckInResult.js'></script>")
            btnCheckIn.Attributes.Add("OnClick", "return AutoPaidFees();")
        End Sub

        ' Method: ShowDetailInfor
        ' Purpose: Show some main information of the current checkin transaction
        Private Sub ShowDetailInfor()
            Dim tblPatronInfor As DataTable
            Dim tblCurrentCheckInInfor As DataTable

            ' Get patron informations
            objBPatron.PatronCode = hidPatronCode.Value
            objBPatron.LibID = clsSession.GlbSite
            tblPatronInfor = objBPatron.GetPatronInfor()
            If Not tblPatronInfor Is Nothing AndAlso tblPatronInfor.Rows.Count > 0 Then
                lblFullName.Text = CStr(tblPatronInfor.Rows(0).Item("FullName")) & " (" & CStr(tblPatronInfor.Rows(0).Item("Code")) & ")"
                lblRange.Text = CStr(tblPatronInfor.Rows(0).Item("VALIDDATE")) & " - " & CStr(tblPatronInfor.Rows(0).Item("EXPIREDDATE"))
                lblPatronGroup.Text = CStr(tblPatronInfor.Rows(0).Item("GroupName"))
                hidPatronID.Value = tblPatronInfor.Rows(0).Item("ID")
                lblDOB.Text = CStr(tblPatronInfor.Rows(0).Item("DOB"))
                lblNote.Text = CStr(tblPatronInfor.Rows(0).Item("Note"))

                ' Show patron' image
                If Not IsDBNull(tblPatronInfor.Rows(0).Item("Portrait")) Then
                    Dim strURL As String = "../Images/Card/" & Trim(CStr(tblPatronInfor.Rows(0).Item("Portrait")))
                    imgPatronImage.Src = "../../Common/ShowPic.aspx?intw=90&inth=120&Url=" & strURL
                End If
                tblPatronInfor = Nothing
            End If

            tblCurrentCheckInInfor = objBLoanTransaction.GetCurrentCheckInInfor()
            If Not tblCurrentCheckInInfor Is Nothing AndAlso tblCurrentCheckInInfor.Rows.Count > 0 Then
                lblTitle.Text = tblCurrentCheckInInfor.Rows(0).Item("TITLE")
                lblCopyNumber.Text = tblCurrentCheckInInfor.Rows(0).Item("CopyNumber")
                lblCheckOutDate.Text = tblCurrentCheckInInfor.Rows(0).Item("CHECKOUTDATE")
                lblCheckInDate.Text = tblCurrentCheckInInfor.Rows(0).Item("CHECKINDATE")
                lblFees.Text = CStr(CInt(tblCurrentCheckInInfor.Rows(0).Item("Fees")) + CInt(tblCurrentCheckInInfor.Rows(0).Item("Fines")))
                tblCurrentCheckInInfor = Nothing
            Else
                lblTitlelb.Visible = False
                lblCopyNumberlb.Visible = False
                lblCheckOutDatelb.Visible = False
                lblCheckInDatelb.Visible = False
                lblFeeslb.Visible = False
                lblCopyInfor.Visible = False
            End If
        End Sub

        ' Method: ShowOnLoanCopies
        ' Purpose: Show onloan copies of this patron
        Private Sub ShowOnLoanCopies()
            Dim tblOnLoanCopies As DataTable
            Dim tblCopy As New DataTable

            tblCopy.Columns.Add("STT")
            tblCopy.Columns.Add("TITLE")
            tblCopy.Columns.Add("CopyNumber")
            tblCopy.Columns.Add("CheckOutDate")
            tblCopy.Columns.Add("DueDate")
            tblCopy.Columns.Add("Note")
            tblCopy.Columns.Add("LoanMode")
            tblCopy.Columns.Add("RenewCount")
            tblCopy.Columns.Add("LoanDepositFee")

            ' Show all his loan copies
            If hidPatronID.Value <> "" Then
                objBLoanTransaction.PatronID = CLng(hidPatronID.Value)
                tblOnLoanCopies = objBLoanTransaction.GetOnLoanCopiesOfPatron
                btnCheckIn.Visible = False
                dtgResult.Visible = False
                lblLoanAlso.Visible = False
                If Not tblOnLoanCopies Is Nothing AndAlso tblOnLoanCopies.Rows.Count > 0 Then
                    Dim inti As Integer = 1
                    'For inti = 0 To tblOnLoanCopies.Rows.Count - 1
                    '    If Not IsDBNull(tblOnLoanCopies.Rows(inti).Item("DUEDATE")) And CStr(tblOnLoanCopies.Rows(inti).Item("DUEDATE")) <> "" Then
                    '        If tblOnLoanCopies.Rows(inti).Item("LoanMode") <> 2 Then
                    '            If DateDiff(DateInterval.Day, tblOnLoanCopies.Rows(inti).Item("DUEDATE"), Now()) > 0 Then
                    '                tblOnLoanCopies.Rows(inti).Item("DUEDATE") = tblOnLoanCopies.Rows(inti).Item("DUEDATE") & vbCrLf & "<font color='red'>" & ddlLabel.Items(10).Text & DateDiff(DateInterval.Day, tblOnLoanCopies.Rows(inti).Item("DUEDATE"), Now()) & ddlLabel.Items(11).Text & "</font>"
                    '            End If
                    '        Else
                    '            If DateDiff(DateInterval.Hour, tblOnLoanCopies.Rows(inti).Item("DUEDATE"), Now()) > 0 Then
                    '                tblOnLoanCopies.Rows(inti).Item("DUEDATE") = tblOnLoanCopies.Rows(inti).Item("DUEDATE") & "<br><font color='red'>" & ddlLabel.Items(10).Text & DateDiff(DateInterval.Hour, tblOnLoanCopies.Rows(inti).Item("DUEDATE"), Now()) & ddlLabel.Items(13).Text & "</font>"
                    '            End If
                    '        End If
                    '    Else
                    '        tblOnLoanCopies.Rows(inti).Item("DUEDATE") = tblOnLoanCopies.Rows(inti).Item("DUEDATE") & vbCrLf & "<font color='Blue'>" & ddlLabel.Items(12).Text & "</font>"
                    '    End If
                    'Next


                    'For inti = 0 To tblOnLoanCopies.Rows.Count - 1
                    For Each dt As DataRow In tblOnLoanCopies.Rows
                        Dim dtCopy As DataRow = tblCopy.NewRow
                        dtCopy.Item("STT") = inti
                        dtCopy.Item("TITLE") = dt.Item("TITLE").ToString
                        dtCopy.Item("CopyNumber") = dt.Item("CopyNumber").ToString
                        dtCopy.Item("CheckOutDate") = dt.Item("CheckOutDate").ToString
                        dtCopy.Item("Note") = dt.Item("Note").ToString
                        dtCopy.Item("RenewCount") = dt.Item("RenewCount").ToString
                        dtCopy.Item("LoanMode") = dt.Item("LoanMode").ToString
                        dtCopy.Item("DueDate") = dt.Item("DUEDATE").ToString
                        dtCopy.Item("LoanDepositFee") = String.Format("{0:###,###}", dt.Item("LoanDepositFee"))

                        If Not IsDBNull(dt.Item("DUEDATE")) And CStr(dt.Item("DUEDATE")) <> "" Then
                            If dt.Item("LoanMode") <> 2 Then
                                If DateDiff(DateInterval.Day, dt.Item("DUEDATE"), Now()) > 0 Then
                                    dtCopy.Item("DueDate") = dt.Item("DUEDATE") & vbCrLf & "<font color='red'>" & ddlLabel.Items(10).Text & DateDiff(DateInterval.Day, dt.Item("DUEDATE"), Now()) & ddlLabel.Items(11).Text & "</font>"
                                End If
                            Else
                                If DateDiff(DateInterval.Hour, dt.Item("DUEDATE"), Now()) > 0 Then
                                    dtCopy.Item("DueDate") = dt.Item("DUEDATE") & "<br><font color='red'>" & ddlLabel.Items(10).Text & DateDiff(DateInterval.Hour, dt.Item("DUEDATE"), Now()) & ddlLabel.Items(13).Text & "</font>"
                                End If
                            End If
                        Else
                            dtCopy.Item("DueDate") = dt.Item("DUEDATE") & vbCrLf & "<font color='Blue'>" & ddlLabel.Items(12).Text & "</font>"
                        End If
                        tblCopy.Rows.Add(dtCopy)
                        inti = inti + 1
                    Next

                    'dtgResult.DataSource = tblOnLoanCopies
                    dtgResult.DataSource = tblCopy
                    dtgResult.DataBind()
                    tblOnLoanCopies = Nothing
                    btnCheckIn.Visible = True
                    dtgResult.Visible = True
                    lblLoanAlso.Text = lblLoanAlso.Text + " : " + CStr(inti - 1)
                    lblLoanAlso.Visible = True
                End If
                tblOnLoanCopies = Nothing
                tblCopy = Nothing
            End If
        End Sub
        Private Sub ShowLoanCurrentCheckIn()
            lblLoanCurrentCheckIn.Visible = False
            tblFeeInfo.Visible = False
            If hidTransactionIDs.Value <> "" Then

                Dim totalLoanFees As Double = 0
                Dim totalLoanOverdueFee As Double = 0
                Dim totalLoanDepositFee As Double = 0

                objBLoanTransaction.TransactionIDs = hidTransactionIDs.Value
                Dim tblCurrentCheckInInfor As DataTable = objBLoanTransaction.GetCurrentCheckInInfor("LOAN")
                If Not tblCurrentCheckInInfor Is Nothing AndAlso tblCurrentCheckInInfor.Rows.Count > 0 Then
                    Dim index As Integer = 0
                    tblCurrentCheckInInfor.Columns.Add("STT")
                    tblCurrentCheckInInfor.Columns.Add("FeesTmp", GetType(String))
                    tblCurrentCheckInInfor.Columns.Add("OverdueFineTmp", GetType(String))
                    tblCurrentCheckInInfor.Columns.Add("LoanDepositFeeTmp", GetType(String))
                    For index = 0 To tblCurrentCheckInInfor.Rows.Count - 1
                        tblCurrentCheckInInfor.Rows(index).Item("STT") = (index + 1)
                        tblCurrentCheckInInfor.Rows(index).Item("FeesTmp") = "0"
                        tblCurrentCheckInInfor.Rows(index).Item("OverdueFineTmp") = "0"
                        tblCurrentCheckInInfor.Rows(index).Item("LoanDepositFeeTmp") = "0"
                        tblCurrentCheckInInfor.Rows(index).Item("FeesTmp") = If(CDbl(tblCurrentCheckInInfor.Rows(index).Item("Fees")) <> 0, String.Format("{0:###,###}", CDbl(tblCurrentCheckInInfor.Rows(index).Item("Fees"))), "0")
                        tblCurrentCheckInInfor.Rows(index).Item("OverdueFineTmp") = If(CDbl(tblCurrentCheckInInfor.Rows(index).Item("OverdueFine")) <> 0, String.Format("{0:###,###}", CDbl(tblCurrentCheckInInfor.Rows(index).Item("OverdueFine"))), "0")
                        tblCurrentCheckInInfor.Rows(index).Item("LoanDepositFeeTmp") = If(CDbl(tblCurrentCheckInInfor.Rows(index).Item("LoanDepositFee")) <> 0, String.Format("{0:###,###}", CDbl(tblCurrentCheckInInfor.Rows(index).Item("LoanDepositFee"))), "0")

                        totalLoanFees = totalLoanFees + If(CDbl(tblCurrentCheckInInfor.Rows(index).Item("Fees")) <> 0, CDbl(tblCurrentCheckInInfor.Rows(index).Item("Fees")), 0)
                        totalLoanDepositFee = totalLoanDepositFee + If(CDbl(tblCurrentCheckInInfor.Rows(index).Item("LoanDepositFee")) <> 0, CDbl(tblCurrentCheckInInfor.Rows(index).Item("LoanDepositFee")), 0)
                        totalLoanOverdueFee = totalLoanOverdueFee + If(CDbl(tblCurrentCheckInInfor.Rows(index).Item("OverdueFine")) <> 0, CDbl(tblCurrentCheckInInfor.Rows(index).Item("OverdueFine")), 0)
                    Next

                    strTotalFees = If(CInt(totalLoanFees) <> 0, String.Format("{0:###,###}", totalLoanFees), "0")
                    strTotalOverdueFine = If(CInt(totalLoanOverdueFee) <> 0, String.Format("{0:###,###}", totalLoanOverdueFee), "0")
                    strTotalLoanDepositFee = If(CInt(totalLoanDepositFee) <> 0, String.Format("{0:###,###}", totalLoanDepositFee), "0")
                    Dim intTongPhaitra = strTotalLoanDepositFee - strTotalFees
                    Dim TotalTmp = CInt(totalLoanDepositFee) - CInt(totalLoanOverdueFee) - CInt(totalLoanFees)
                    If TotalTmp = 0 Then
                        strTotal = "0"
                    Else
                        strTotal = String.Format("{0:###,###}", CInt(totalLoanDepositFee) - (CInt(totalLoanFees) + CInt(totalLoanOverdueFee)))
                    End If

                    Session("strTotalFees") = strTotalFees
                    Session("strTotalOverdueFine") = strTotalOverdueFine
                    Session("strTotalLoanDepositFee") = strTotalLoanDepositFee
                    Session("strTotal") = strTotal

                    dtgResultCurrentCheckIn.DataSource = tblCurrentCheckInInfor
                    dtgResultCurrentCheckIn.DataBind()
                    tblFeeInfo.Visible = True
                    lblLoanCurrentCheckIn.Visible = True
                    'btnSendMail.Visible = True

                    btnPrintCheckIn.Visible = True
                    'btnPrintReceiptCheckIn.Visible = True
                    Dim strQueryString As String = "?txtPatronInfo=" & lblFullName.Text & "&hidTransactionIDs=" & hidTransactionIDs.Value
                    btnPrintCheckIn.Attributes.Add("OnClick", "showPopupDetail('" & strQueryString & "')")

                    'strQueryString = "?txtPatronInfo=" & lblFullName.Text & "&txtPatronID=" & hidPatronID.Value & "&hidTransactionIDs=" & hidTransactionIDs.Value & "&hidLoanCode=" & hidLoanCode.Value
                    'btnPrintReceiptCheckIn.Attributes.Add("OnClick", "showPopupReceipt('" & strQueryString & "')")
                Else
                    dtgResultCurrentCheckIn.DataSource = Nothing
                    dtgResultCurrentCheckIn.DataBind()
                    lblLoanCurrentCheckIn.Visible = False
                    'btnSendMail.Visible = False
                    btnPrintCheckIn.Visible = False

                    'btnPrintReceiptCheckIn.Visible = False
                End If
            Else
                lblLoanCurrentCheckIn.Visible = False
                'btnSendMail.Visible = False
                btnPrintCheckIn.Visible = False
                'btnPrintReceiptCheckIn.Visible = False
            End If
        End Sub

        ' Method: CheckIn
        ' Purpose: checkin & show detail result
        Private Sub CheckIn()
            Dim intUserID = CInt(Session("UserID"))

            ' Get some information for load
            Dim strPatronCode As String = Trim(Request("txtPatronCode"))
            Dim strCopyNumber As String = Trim(Request("txtCopyNumber"))
            Dim strCheckInDate As String = Trim(Request("txtCheckInDate"))
            Dim strCheckInTime As String = Trim(Request("txtCheckInTime"))
            Dim strAutoPaidFees As String = Trim(Request("hidAutoPaidFees"))
            Dim intError As Integer = 0

            strCheckInDate = Trim(strCheckInDate & " " & strCheckInTime)
            If strCheckInDate = "" Then
                strCheckInDate = CStr(Day(Now)).PadLeft(2, "0") & "/" & CStr(Month(Now)).PadLeft(2, "0") & "/" & Year(Now) & " " & CStr(Hour(Now)).PadLeft(2, "0") & ":" & CStr(Minute(Now)).PadLeft(2, "0") & ":" & CStr(Second(Now)).PadLeft(2, "0")
            End If

            ' Load into some hidden fields
            If Not strPatronCode = "" Then
                hidPatronCode.Value = strPatronCode
            End If
            If Not strCheckInDate = "" Then
                hidCheckInDate.Value = strCheckInDate
            End If
            If Not strAutoPaidFees = "" Then
                hidAutoPaidFees.Value = strAutoPaidFees
            End If
            If Not strCopyNumber = "" Then
                hidCopyNumber.Value = strCopyNumber
            End If

            ' CheckIn now
            objBLoanTransaction.LibID = clsSession.GlbSite
            objBLoanTransaction.UserID = intUserID
            objBLoanTransaction.CheckInDate = strCheckInDate
            If hidCopyNumber.Value <> "" Then
                'intError = objBLoanTransaction.CheckIn(hidCopyNumber.Value, hidAutoPaidFees.Value)
                intError = objBLoanTransaction.CheckIn(hidCopyNumber.Value, hidAutoPaidFees.Value, clsSession.GlbUserFullName)
                Select Case intError
                    Case 0 ' Copynumber doesn't exists
                        lblReasonInfor.Text = "<FONT COLOR=""RED""><b>" & ddlLabel.Items(4).Text & strCopyNumber & "</b></FONT>"
                    Case 1 ' Copynumber doesn't exists
                        lblReasonInfor.Text = "<FONT COLOR=""RED""><b>" & ddlLabel.Items(4).Text & strCopyNumber & "</b></FONT>"
                    Case 2 ' Copynumber is locked or not in circulation
                        ' Impossiable
                        lblReasonInfor.Text = "<FONT COLOR=""RED""><b>" & ddlLabel.Items(5).Text & "</b></FONT>"
                    Case 3 ' Copynumber is on load
                        Session("CopyNumber") = Session("CopyNumber") & hidCopyNumber.Value & ","
                        Session("TransactionIDs") = Session("TransactionIDs") & objBLoanTransaction.TransactionIDs & ","
                        hidTransactionIDs.Value = hidTransactionIDs.Value & objBLoanTransaction.TransactionIDs & ","
                        lblPageTitle.Text = ddlLabel.Items(2).Text
                        hidPatronCode.Value = objBLoanTransaction.PatronCode

                        '-- Thong bao an pham co nguoi dat muon & dat cho
                        Dim strAlert As String = ""
                        Dim tblContent As DataTable = objBHolding.GetContentByCopyNumber(strCopyNumber)
                        Dim strContent As String = tblContent.Rows(0).Item("Content")

                        objBRT.UserID = Session("UserID")
                        Dim tblReserveRequestList As DataTable = objBRT.GetReservationPatronInfor()
                        Dim tblReservList As DataTable = objBReserve.FillReserve(0, 0, "", "", "")

                        Dim dvRequest As DataView = tblReserveRequestList.DefaultView()
                        dvRequest.RowFilter = "MainItem = '" & strContent & "'"

                        tblReserveRequestList = dvRequest.ToTable()
                        If (Not IsNothing(tblReserveRequestList)) AndAlso tblReserveRequestList.Rows.Count > 0 Then
                            strAlert = strAlert & String.Format(lblMsg3.Text, strContent, tblReserveRequestList.Rows(0).Item("CODE"))
                        End If

                        Dim dvReserve As DataView = tblReservList.DefaultView()
                        dvReserve.RowFilter = "Content = '" & strContent & "'"

                        tblReservList = dvReserve.ToTable()
                        If (Not IsNothing(tblReservList)) AndAlso tblReservList.Rows.Count > 0 Then
                            strAlert = strAlert & " " & String.Format(lblMsg4.Text, strContent, tblReservList.Rows(0).Item("PatronCode"))
                        End If

                        If strAlert <> "" Then
                            Page.RegisterClientScriptBlock("AlertJS", "<script language='javascript'> alert('" & strAlert & "'); </script>")
                        End If

                        If hidAutoPaidFees.Value = "0" Then
                            lblJavascript.Text = "<script language = 'javascript'>OpenWindow('WPaidFees.aspx','WPaidFees',300,200,150,50);</script>"
                        End If
                        'lblSubmitForm.Text = "<script language = 'javascript'>document.forms[0].target='CheckInMain'; document.forms[0].action = 'WCheckInResult.aspx'; document.forms[0].submit();</script>"
                    Case 4 ' Copynumber is on hold
                        ' Impossiable
                        ' lblReasonInfor.Text = "<FONT COLOR=""RED"">" & ddlLabel.items(4).Text & "</FONT>"
                        ' Allow pass hold now ........
                    Case 5 ' Librarian has not permission to manage location of the CopyNumber
                        lblReasonInfor.Text = "<FONT COLOR=""RED""><b>" & ddlLabel.Items(7).Text & "</b></FONT>"
                    Case 6 ' Librarian has not permission to manage location of Patron
                        lblReasonInfor.Text = "<FONT COLOR=""RED""><b>" & ddlLabel.Items(8).Text & "</b></FONT>"
                    Case 9
                        lblPageTitle.Visible = False
                        btnCheckIn.Visible = False
                        lblLoanAlso.Visible = False
                        lblReasonInfor.Text = "<FONT COLOR=""RED""><b>" & ddlLabel.Items(9).Text & "</b></FONT>"
                End Select

            End If
            Page.RegisterClientScriptBlock("RefreshJs", "<script language = 'javascript'>parent.CheckIn.document.forms[0].txtCopyNumber.value='';parent.CheckIn.document.forms[0].txtCopyNumber.focus();parent.CheckIn.document.forms[0].btnCheckIn.disabled=false;</script>")
        End Sub
        ' Event: btnCheckIn_Click
        ' Purpose: CheckIn
        Private Sub btnCheckIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckIn.Click
            Dim dtgItem As DataGridItem
            Dim chkCirID As HtmlInputCheckBox
            Dim strCopyNumbers As String
            Dim intError As Int16 = 0

            For Each dtgItem In dtgResult.Items
                chkCirID = dtgItem.FindControl("chkCopyNumber")
                If chkCirID.Checked Then
                    strCopyNumbers = strCopyNumbers & CType(dtgItem.FindControl("lblSelectCopyNumber"), Label).Text & ","
                End If
            Next

            If Not strCopyNumbers = "" Then
                strCopyNumbers = Left(strCopyNumbers, strCopyNumbers.Length - 1)
                hidCopyNumber.Value = strCopyNumbers

                objBLoanTransaction.PatronCode = hidPatronCode.Value
                objBLoanTransaction.CheckInDate = hidCheckInDate.Value
                objBLoanTransaction.UserID = CInt(Session("UserID"))
                'intError = objBLoanTransaction.CheckIn(hidCopyNumber.Value, hidAutoPaidFees.Value)
                intError = objBLoanTransaction.CheckIn(hidCopyNumber.Value, hidAutoPaidFees.Value, clsSession.GlbUserFullName)
                Select Case intError
                    Case 0 ' Copynumber doesn't exists
                        Page.RegisterClientScriptBlock("RefreshJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(2).Text & "');</script>")
                        Session("CopyNumber") = Session("CopyNumber") & hidCopyNumber.Value & ","
                        Session("TransactionIDs") = Session("TransactionIDs") & objBLoanTransaction.TransactionIDs & ","
                        hidTransactionIDs.Value = hidTransactionIDs.Value & objBLoanTransaction.TransactionIDs & ","
                        lblPageTitle.Text = ddlLabel.Items(2).Text
                        hidPatronCode.Value = objBLoanTransaction.PatronCode
                        If hidAutoPaidFees.Value = "0" Then
                            lblJavascript.Text = "<script language = 'javascript'>OpenWindow('WPaidFees.aspx','WPaidFees',300,200,150,50);</script>"
                        Else
                            'Tulnn:De in dc phieu tra thi phai co Session("TransactionIDs")
                            'Session("TransactionIDs") = Nothing
                            'End Tulnn
                        End If

                        Call ShowDetailInfor()
                        Call ShowOnLoanCopies()
                        Call ShowLoanCurrentCheckIn()
                        lblTitlelb.Visible = True
                        lblCopyNumberlb.Visible = True
                        lblCheckOutDatelb.Visible = True
                        lblCheckInDatelb.Visible = True
                        lblFeeslb.Visible = True
                        btnPrintCheckIn.Visible = True

                    Case 1 ' Copynumber doesn't exists
                        lblReasonInfor.Text = "<FONT COLOR=""RED""><b>" & ddlLabel.Items(4).Text & strCopyNumbers & "</b></FONT>"
                    Case 2 ' Copynumber is locked or not in circulation
                        ' Impossiable
                        lblReasonInfor.Text = "<FONT COLOR=""RED""><b>" & ddlLabel.Items(5).Text & "</b></FONT>"
                    Case 3 ' Copynumber is on load
                        Session("CopyNumber") = Session("CopyNumber") & hidCopyNumber.Value & ","
                        Session("TransactionIDs") = Session("TransactionIDs") & objBLoanTransaction.TransactionIDs & ","
                        hidTransactionIDs.Value = hidTransactionIDs.Value & objBLoanTransaction.TransactionIDs & ","
                        lblPageTitle.Text = ddlLabel.Items(2).Text
                        hidPatronCode.Value = objBLoanTransaction.PatronCode
                        If hidAutoPaidFees.Value = "0" Then
                            lblJavascript.Text = "<script language = 'javascript'>OpenWindow('WPaidFees.aspx','WPaidFees',300,200,150,50);</script>"
                        Else
                            'Tulnn:De in dc phieu tra thi phai co Session("TransactionIDs")
                            'Session("TransactionIDs") = Nothing
                            'End Tulnn
                        End If

                        Call ShowDetailInfor()
                        Call ShowOnLoanCopies()
                        Call ShowLoanCurrentCheckIn()
                        lblTitlelb.Visible = True
                        lblCopyNumberlb.Visible = True
                        lblCheckOutDatelb.Visible = True
                        lblCheckInDatelb.Visible = True
                        lblFeeslb.Visible = True
                        btnPrintCheckIn.Visible = True
                        'lblSubmitForm.Text = "<script language = 'javascript'>document.forms[0].target='CheckInMain'; document.forms[0].action = 'WCheckInResult.aspx'; document.forms[0].submit();</script>"
                    Case 4 ' Copynumber is on hold
                        ' Impossiable
                        ' lblReasonInfor.Text = "<FONT COLOR=""RED"">" & ddlLabel.items(4).Text & "</FONT>"
                        ' Allow pass hold now ........
                    Case 5 ' Librarian has not permission to manage location of the CopyNumber
                        lblReasonInfor.Text = "<FONT COLOR=""RED""><b>" & ddlLabel.Items(7).Text & "</b></FONT>"
                    Case 6 ' Librarian has not permission to manage location of Patron
                        lblReasonInfor.Text = "<FONT COLOR=""RED""><b>" & ddlLabel.Items(8).Text & "</b></FONT>"
                End Select
                Page.RegisterClientScriptBlock("RefreshJs", "<script language = 'javascript'>parent.CheckIn.document.forms[0].txtCopyNumber.value='';parent.CheckIn.document.forms[0].txtCopyNumber.focus();</script>")
            End If
        End Sub
        Protected Sub dtgResultCurrentCheckIn_CancelCommand(source As Object, e As DataGridCommandEventArgs) Handles dtgResultCurrentCheckIn.CancelCommand
            Try
                dtgResultCurrentCheckIn.EditItemIndex = -1
                Call ShowLoanCurrentCheckIn()
            Catch ex As Exception
            End Try
        End Sub

        Protected Sub dtgResultCurrentCheckIn_EditCommand(source As Object, e As DataGridCommandEventArgs) Handles dtgResultCurrentCheckIn.EditCommand
            Dim intIndex As Integer = CInt(e.Item.ItemIndex)
            dtgResultCurrentCheckIn.EditItemIndex = intIndex
            Call ShowLoanCurrentCheckIn()
        End Sub
        Protected Sub dtgResultCurrentCheckIn_UpdateCommand(source As Object, e As DataGridCommandEventArgs) Handles dtgResultCurrentCheckIn.UpdateCommand
            Try
                'Dim itemLoanHistory As CirLoanHistory = _cirLoanHistoryService.GetCirLoanHistoryById(dtgResultCurrentCheckIn.DataKeys(e.Item.ItemIndex))
                Dim ID = dtgResultCurrentCheckIn.DataKeys(e.Item.ItemIndex)
                Dim strOverdueFine As String = CType(e.Item.Cells(6).Controls(0), TextBox).Text
                Dim doubOverdueFine = CDbl(strOverdueFine.Replace(".", ""))

                ''Update Cir_tblLoanHistory
                objBCDBS.SQLStatement =  " Update Cir_tblLoanHistory set OverdueFine = '"  & doubOverdueFine.ToString() & "' where ID = " & ID
                objBCDBS.RetrieveItemInfor()
                ''
                'If objBCDBS.ErrorMsg Is Nothing Then
                '    Page.RegisterClientScriptBlock("AlertJs", "<script language = 'javascript'>alert('" & lblMsg4.Text & "');</script>")
                '    Else 
                '        Page.RegisterClientScriptBlock("AlertJs", "<script language = 'javascript'>alert('" & lblMsg5.Text & "');</script>")
                'End If

                dtgResultCurrentCheckIn.EditItemIndex = -1
                Call ShowLoanCurrentCheckIn()
            Catch ex As Exception
                Page.RegisterClientScriptBlock("AlertJs", "<script language = 'javascript'>alert('" & lblMsg5.Text & "');</script>")
            End Try
        End Sub
        Private Sub HidControl()
            btnCheckIn.Visible = False
            lblLoanAlso.Visible = False
            lblFullName.Visible = False
            lblDOB.Visible = False
            lblRange.Visible = False
            lblPatronGroup.Visible = False
            lblFullNamelb.Visible = False
            lblDOBlb.Visible = False
            lblRangelb.Visible = False
            lblPatronGrouplb.Visible = False
            imgPatronImage.Visible = False
            lblPatronInfor.Visible = False
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
                If Not objBRT Is Nothing Then
                    objBRT.Dispose(True)
                    objBRT = Nothing
                End If
                If Not objBHolding Is Nothing Then
                    objBHolding.Dispose(True)
                    objBHolding = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace