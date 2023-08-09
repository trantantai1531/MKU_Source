' Class: WCheckOutResult
' Puspose: Display checkout form
' Creator: Oanhtn
' CreatedDate: 28/08/2004
' Modification History:
'   - 17/04/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.WebUI.Common
Imports Telerik.Web.UI

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WCheckOutResult
        Inherits clsWBase 'Web.UI.Page 'clsWBase

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
        Private objBPatronGroup As New BusinessRules.Patron.clsBPatronGroup
        Private objBLoanTransactionDetail As New clsBLoanTransaction
        Private objBOverdueTransaction As New clsBOverdueTransaction
        Private objBCDBS As New clsBCommonDBSystem

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            LabelMessage.Text = ""
            If Not Page.IsPostBack Then
                If CheckOverdue() Then
                    Call Prepare()
                    Call CheckOut()
                End If
            End If
            'Call ShowDetailInfor()
        End Sub

        Private Function CheckOverdue() As Boolean
            Dim strPatronCode As String = Trim(Request("txtPatronCode"))
            objBPatron.PatronCode = strPatronCode
            Dim tblPatron As DataTable = objBPatron.GetPatronByPatronCode()
            If Not IsNothing(tblPatron) Then
                If tblPatron.Rows.Count > 0 Then
                    objBOverdueTransaction.UserID = Session("UserID")
                    objBOverdueTransaction.PatronIDs = tblPatron.Rows(0).Item("ID")
                    Dim tblOverdueList As DataTable = objBOverdueTransaction.GetOverdueListAuthority()

                    If tblOverdueList.Rows.Count > 0 Then
                        Page.RegisterClientScriptBlock("AlertJS", "<script language='javascript'> alert('" & lblMsg8.Text & "'); </script>")
                        Return False
                    Else
                        Return True
                    End If
                Else
                    Page.RegisterClientScriptBlock("AlertJS", "<script language='javascript'> alert('" & lblMsg9.Text & "'); </script>")
                    Return False
                End If
            Else
                Page.RegisterClientScriptBlock("AlertJS", "<script language='javascript'> alert('" & lblMsg9.Text & "'); </script>")
                Return False
            End If
        End Function

        ' Method: Initialize
        ' Purpose: init all necessary objects
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


            objBLoanTransactionDetail.InterfaceLanguage = Session("InterfaceLanguage")
            objBLoanTransactionDetail.DBServer = Session("DBServer")
            objBLoanTransactionDetail.ConnectionString = Session("ConnectionString")
            Call objBLoanTransactionDetail.Initialize()


            objBOverdueTransaction.InterfaceLanguage = Session("InterfaceLanguage")
            objBOverdueTransaction.DBServer = Session("DBServer")
            objBOverdueTransaction.ConnectionString = Session("ConnectionString")
            Call objBOverdueTransaction.Initialize()


            objBPatronGroup.InterfaceLanguage = Session("InterfaceLanguage")
            objBPatronGroup.DBServer = Session("DBServer")
            objBPatronGroup.ConnectionString = Session("ConnectionString")
            Call objBPatronGroup.Initialize()
        End Sub

        ' Method: BindJS
        ' Purpose: Bind javascript
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/CheckOut/WCheckOutResult.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")

            btPrintCheckOut.Attributes.Add("OnClick", "OpenWindow('WCheckOutPrintResult.aspx', 'WCheckOutPrintResult',1200,800,200,150); return false;")
        End Sub
        Private Sub Prepare()
            Dim strPatronCode = Trim(Request("txtPatronCode"))
            Dim strCopyNumber = Trim(Request("txtCopyNumber"))
            Dim strCheckOutDate As String = Trim(Request("txtCreatedDate"))
            Dim strCheckOutTime As String = Trim(Request("txtCreatedTime"))
            Dim strAmountDeposit As String = ""
            If Not IsNothing(Request.QueryString("txtAmountDeposit")) Then
                strAmountDeposit = Trim(Request("txtAmountDeposit"))
            End If
            hidAmountDeposit.Value = strAmountDeposit
            Dim strCheckInDate As String
            If CInt(Request("hidOpen")) > 0 Then
                strCheckInDate = "ISNULL"
            Else
                strCheckInDate = Trim(Request("txtDueDate"))
            End If
            Dim strCheckInTime As String = Trim(Request("txtDueTime"))
            Dim intLoanMode As Int16 = CInt(Request("hidLoanMode"))

            Dim intHoldIgnored As Int16 = CInt(hidHoldIgnored.Value)

            Dim strDate As String = ""
            Dim strTime As String = ""

            If Not strPatronCode = "" Then
                hidPatronCode.Value = strPatronCode
            Else
                hidPatronCode.Value = ""
            End If
            If Not strCopyNumber = "" Then
                hidCopyNumber.Value = strCopyNumber
            Else
                hidCopyNumber.Value = ""
            End If
            hidLoanMode.Value = intLoanMode

            If Session("CurrentPatron") Is Nothing Then
                Session("CurrentPatron") = strPatronCode
            Else
                If Session("CurrentPatron") <> strPatronCode Then
                    Session("TransactionID") = Nothing
                    Session("CurrentPatron") = strPatronCode
                End If
            End If
            ' Get CheckOutDate
            If strCheckOutDate = "" Then
                strCheckOutDate = CStr(Day(Now)).PadLeft(2, "0") & "/" & CStr(Month(Now)).PadLeft(2, "0") & "/" & CStr(Year(Now)).PadLeft(2, "0") & " " & CStr(Hour(Now)).PadLeft(2, "0") & ":" & CStr(Minute(Now)).PadLeft(2, "0") & ":" & CStr(Second(Now)).PadLeft(2, "0")
            Else
                strCheckOutDate = Trim(strCheckOutDate & " " & strCheckOutTime)
            End If

            If (intLoanMode = 1) Then
                If strCheckInDate = "" Then
                    Dim tbPatronGroup As DataTable = objBPatronGroup.GetPatronGroupByPatronCode(hidPatronCode.Value)
                    If (Not IsNothing(tbPatronGroup)) AndAlso tbPatronGroup.Rows.Count > 0 Then
                        strCheckInDate = String.Format("{0:dd/MM/yyyy}", Date.Parse(strCheckOutDate).AddDays(tbPatronGroup.Rows(0).Item("LoanDayPeriod")))
                    End If
                End If
            End If

            ' Get CheckInDate
            If Not strCheckInDate = "" Then
                strCheckInDate = Trim(strCheckInDate & " " & strCheckInTime)
            End If

            hidCheckOutDate.Value = strCheckOutDate
            hidDueDate.Value = strCheckInDate
            lnkRenew.Visible = False
        End Sub
        ' Method: CheckOut
        ' Purpose: checkout
        ' Input: PatronCode, CopyNumber
        Private Sub CheckOut()
            lblReason.Visible = True
            lblReason.Text = "<H2>" & lblReason.Text & "</H2>"

            Dim radLoanType As Integer = CInt(Request("radLoanType"))
            Dim intUserID = CInt(Session("UserID"))
            Dim lngTransactionID As Long

            ' IndefiniteDue
            'If intIndefiniteDue = 0 Then
            '    strCheckInDate = "NULL"
            'End If

            ' Calculate CheckIn Date
            'If strCheckInDate = "" Then
            '    strCheckInDate = objBLoanTransaction.CalculateCheckInDate(intLoanTypeID, strCheckOutDate, intLocationID)
            '    If InStr(strCheckInDate, " ") > 0 Then
            '        strDate = Left(strCheckInDate, InStr(strCheckInDate, " "))
            '        strTime = Mid(strCheckInDate, InStr(strCheckInDate, " ") + 1)
            '        If InStr(strTime, " ") > 0 Then
            '            strTime = Left(strTime, InStr(strTime, " "))
            '        End If
            '    Else
            '        strDate = strCheckInDate
            '        strTime = ""
            '    End If
            '    strCheckInDate = strDate & " " & strTime
            'End If
            objBLoanTransaction.UserID = CInt(Session("UserID"))
            objBLoanTransaction.PatronCode = CStr(hidPatronCode.Value)
            objBLoanTransaction.CopyNumber = CStr(hidCopyNumber.Value)
            objBLoanTransaction.LoanMode = CInt(hidLoanMode.Value)
            objBLoanTransaction.DueDate = CStr(hidDueDate.Value)
            objBLoanTransaction.CheckOutDate = CStr(hidCheckOutDate.Value)
            Dim intCheckInLoc As Integer
            Dim intPatronCodeResult As Integer = 0
            Dim intPermissionPatronGroupLoanType As Integer = 0
            intPatronCodeResult = objBLoanTransaction.CheckPatronCode()

            If intPatronCodeResult = 0 Then
                intPermissionPatronGroupLoanType = objBLoanTransaction.CheckPermissionPatronGroupLoanType()
                If intPermissionPatronGroupLoanType = 0 Then
                    Page.RegisterClientScriptBlock("ErrorPermission", "<script language = 'javascript'>alert('" & ddlLabel.Items(12).Text & "')</script>")
                    Exit Sub
                End If
            End If

            If intPatronCodeResult = 0 Then
                'intCheckInLoc = objBLoanTransaction.CheckOut(CInt(hidHoldIgnored.Value))
                'intCheckInLoc = objBLoanTransaction.CheckOut(CInt(hidHoldIgnored.Value), radLoanType)
                intCheckInLoc = objBLoanTransaction.CheckOut(CInt(hidHoldIgnored.Value), radLoanType, clsSession.GlbUserFullName)
            Else
                Page.RegisterClientScriptBlock("LoadFrame2", "<script language = 'javascript'>CheckPatronCode('hello'," & GenRandomNumber(10) & ", '" & objBLoanTransaction.PatronCode & "', " & hidLoanMode.Value & ");</script>")
            End If

            lblReason.Visible = False
            Select Case intCheckInLoc
                Case -2
                    Page.RegisterClientScriptBlock("ErrorRolCopyNumber", "<script language = 'javascript'>alert('" & ddlLabel.Items(5).Text & "')</script>")
                    Page.RegisterClientScriptBlock("RefreshJs", "<script language = 'javascript'>parent.CheckOut.document.forms[0].txtCopyNumber.value='';parent.CheckOut.document.forms[0].txtCopyNumber.focus();parent.CheckOut.document.forms[0].btnCheckOut.disabled=false;</script>")
                    Exit Sub
                Case 0
                    'lblReason.Visible = False
                    objBCDBS.SQLStatement = "SELECT * FROM Cir_tblLoan WHERE ID ='" & objBLoanTransaction.TransactionID & "'"
                    Dim tblLoan = objBCDBS.RetrieveItemInfor()
                    If Not String.IsNullOrEmpty(hidAmountDeposit.Value) Then
                        Try
                            If Not IsNothing(tblLoan) AndAlso tblLoan.Rows.Count > 0 Then
                                objBCDBS.SQLStatement = "Update Cir_tblLoan Set LoanDepositFee  ='" & CType(hidAmountDeposit.Value, Decimal) & "'" & " WHERE ID ='" & objBLoanTransaction.TransactionID & "'"
                                objBCDBS.RetrieveNonQuery()
                            End If
                        Catch ex As Exception

                        End Try
                    Else
                        Try
                            If Not IsNothing(tblLoan) AndAlso tblLoan.Rows.Count > 0 Then
                                objBCDBS.SQLStatement = "Update Cir_tblLoan Set LoanDepositFee  ='" & CType("0", Decimal) & "'" & " WHERE ID ='" & objBLoanTransaction.TransactionID & "'"
                                objBCDBS.RetrieveNonQuery()
                            End If
                        Catch ex As Exception

                        End Try
                    End If
                    Page.RegisterClientScriptBlock("RefreshJs", "<script language = 'javascript'>parent.CheckOut.document.forms[0].txtCopyNumber.value='';parent.CheckOut.document.forms[0].txtCopyNumber.focus();parent.CheckOut.document.forms[0].btnCheckOut.disabled=false;</script>")
                Case 1 ' Copynumber doesn't exists
                    lblReasonInfor.Text = "<FONT COLOR=""RED""><b>" & lblMsg1.Text & CStr(hidCopyNumber.Value) & "</b></FONT>"
                    Page.RegisterClientScriptBlock("RefreshJs", "<script language = 'javascript'>parent.CheckOut.document.forms[0].txtCopyNumber.value='';parent.CheckOut.document.forms[0].txtCopyNumber.focus();parent.CheckOut.document.forms[0].btnCheckOut.disabled=false;</script>")
                Case 2 ' Copynumber is locked or not in circulation
                    lblReasonInfor.Text = "<FONT COLOR=""RED""><b>" & lblMsg2.Text & "</b></FONT>"
                    Page.RegisterClientScriptBlock("RefreshJs", "<script language = 'javascript'>parent.CheckOut.document.forms[0].txtCopyNumber.value='';parent.CheckOut.document.forms[0].txtCopyNumber.focus();parent.CheckOut.document.forms[0].btnCheckOut.disabled=false;</script>")
                Case 3 ' Copynumber is on load
                    lblReasonInfor.Text = "<FONT COLOR=""RED""><b>" & lblMsg3.Text & "</b></FONT>"
                    Page.RegisterClientScriptBlock("RefreshJs", "<script language = 'javascript'>parent.CheckOut.document.forms[0].txtCopyNumber.value='';parent.CheckOut.document.forms[0].txtCopyNumber.focus();parent.CheckOut.document.forms[0].btnCheckOut.disabled=false;</script>")
                Case 4 ' Copynumber is on hold
                    lblClick.Visible = True
                    btnCheckOut.Visible = True
                    lblComment.Visible = True
                    lblReasonInfor.Text = "<FONT COLOR=""RED""><b>" & lblMsg4.Text & "</b></FONT>"
                    Page.RegisterClientScriptBlock("RefreshJs", "<script language = 'javascript'>parent.CheckOut.document.forms[0].txtCopyNumber.value='';parent.CheckOut.document.forms[0].txtCopyNumber.focus();parent.CheckOut.document.forms[0].btnCheckOut.disabled=false;</script>")
                    ' Allow pass hold now ........
                Case 5 ' Librarian has not permission to manage location of the CopyNumber
                    lblReasonInfor.Text = "<FONT COLOR=""RED""><b>" & lblMsg5.Text & "</b></FONT>"
                    'Page.RegisterClientScriptBlock("RefreshJs", "<script language = 'javascript'>parent.CheckOut.document.forms[0].txtCopyNumber.value='';parent.CheckOut.document.forms[0].txtCopyNumber.focus();parent.CheckOut.document.forms[0].btnCheckOut.disabled=false;</script>")
                Case 6 ' Librarian has not permission to manage location of Patron
                    lblReasonInfor.Text = "<FONT COLOR=""RED""><b>" & lblMsg6.Text & "</b></FONT>"
                    Page.RegisterClientScriptBlock("RefreshJs", "<script language = 'javascript'>parent.CheckOut.document.forms[0].txtCopyNumber.value='';parent.CheckOut.document.forms[0].txtCopyNumber.focus();parent.CheckOut.document.forms[0].btnCheckOut.disabled=false;</script>")
                Case 7 ' Patron is locked
                    lblReasonInfor.Text = "<FONT COLOR=""RED""><b> Thẻ đang bị khóa</b></FONT>"
                    Page.RegisterClientScriptBlock("RefreshJs", "<script language = 'javascript'>parent.CheckOut.document.forms[0].txtCopyNumber.value='';parent.CheckOut.document.forms[0].txtCopyNumber.focus();parent.CheckOut.document.forms[0].btnCheckOut.disabled=false;</script>")
                Case 10 ' qua han ngach
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), "MsgJs1", "Continue('" & ddlLabel.Items(6).Text & "');", True)
                    Page.RegisterClientScriptBlock("MsgJs1", "<script language = 'javascript'>alert('" & lblMsg10.Text & "');CheckPatronCode('" & lblMsg10.Text & "'," & GenRandomNumber(10) & ", '" & objBLoanTransaction.PatronCode & "', " & hidLoanMode.Value & ");</script>")
                    'Chinhnh modify 20080823
                Case 12 'The ban doc het han
                    lblReasonInfor.Text = "<FONT COLOR=""RED""><b>" & lblMsg7.Text & "</b></FONT>"
                    Page.RegisterClientScriptBlock("RefreshJs", "<script language = 'javascript'>parent.CheckOut.document.forms[0].txtCopyNumber.value='';parent.CheckOut.document.forms[0].txtCopyNumber.focus();parent.CheckOut.document.forms[0].btnCheckOut.disabled=false;</script>")
                    lnkRenew.Visible = True
                    lnkRenew.NavigateUrl = "javascript:OpenWindow('../WRenewPatronCard.aspx?PatronCode=" & CStr(hidPatronCode.Value) & "&LoanMode=1', 'WRenewPatronCard',500,300,200,150);"
                    'het add
            End Select
            lngTransactionID = objBLoanTransaction.TransactionID
            ' Decreat Remain
            Session("Remain") = CInt(Session("Remain")) - 1

            ' Get information of the current transaction
            If Session("TransactionID") Is Nothing Then
                Session("TransactionID") = CStr(lngTransactionID)
            Else
                If Trim(Session("TransactionID")) = "" Then
                    Session("TransactionID") = CStr(lngTransactionID)
                Else
                    Session("TransactionID") = Session("TransactionID") & "," & CStr(lngTransactionID)
                End If
            End If
            ' Show loan information
            ShowDetailInfor()
            Call ShowResult()
            ' WriteLog
            Call WriteLog(45, ddlLabel.Items(2).Text & ": " & CStr(hidCopyNumber.Value), Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

            Call ShowResultDetail()

            Call WriteErrorMssg(ddlLabelLoanDetail.Items(1).Text, objBLoanTransactionDetail.ErrorMsg, ddlLabelLoanDetail.Items(0).Text, objBLoanTransactionDetail.ErrorCode)
        End Sub
        Private Sub HidePatronInfor()
            lblPatronInfor.Visible = False
            lblFullNamelb.Visible = False
            lblFullName.Visible = False
            lblRangelb.Visible = False
            lblRange.Visible = False
            lblPatronGrouplb.Visible = False
            lblPatronGroup.Visible = False
            lblReason.Visible = False
            lblCopyInfor.Visible = False
            dtgResult.Visible = False
            btPrintCheckOut.Visible = False
        End Sub
        ' Method: ShowResult
        ' Purpose: ShowResult after loaned
        Private Sub ShowResult()
            Dim blnShow As Boolean = False
            Dim tblCurrentTrans As DataTable

            If Not Session("TransactionID") Is Nothing Then
                If Not Trim(Session("TransactionID")) = "" Then
                    tblCurrentTrans = objBLoanTransaction.GetCurrentLoanInfor(CStr(Session("TransactionID")))
                    If Not tblCurrentTrans Is Nothing AndAlso tblCurrentTrans.Rows.Count > 0 Then
                        Dim newColumn As New Data.DataColumn("STT", GetType(System.String))
                        newColumn.DefaultValue = "1"
                        tblCurrentTrans.Columns.Add(newColumn)
                        Dim indexRows As Integer = 1
                        For Each rows As DataRow In tblCurrentTrans.Rows
                            If (Not (rows.RowState = DataRowState.Deleted)) AndAlso (Not (String.IsNullOrEmpty(rows.Item("STT")))) Then
                                rows.Item("STT") = indexRows.ToString()
                                indexRows = indexRows + 1
                            End If

                        Next
                        dtgResult.Visible = True
                        dtgResult.DataSource = tblCurrentTrans
                        dtgResult.DataBind()
                        btPrintCheckOut.Visible = True
                        blnShow = True
                        lblTotallb.Visible = True
                        lblTotal.Visible = True
                        lblCopyInfor.Visible = True
                        lblTotal.Text = tblCurrentTrans.Rows.Count
                        tblCurrentTrans = Nothing
                        LabelMessage.Text = ""
                    Else
                        If (Page.IsPostBack = False) Then
                            LabelMessage.Text = "Số ĐKCB không tồn tại hoặc đang cho mượn"
                        Else
                            LabelMessage.Text = ""
                        End If
                        btPrintCheckOut.Visible = False
                    End If
                End If
            End If
            If Not blnShow Then
                btPrintCheckOut.Visible = False
                dtgResult.Visible = False
                lblTotal.Visible = False
                lblTotallb.Visible = False
                lblCopyInfor.Visible = False
            End If
        End Sub

        'WCheckOutResult.aspx?txtPatronCode=1351160204&txtCopyNumber=KS1V046305&txtCreatedDate=07%2f09%2f2016&txtCreatedTime=11%3a13%3a24&hidOpen=0&txtDueDate=&txtDueTime=22%3a00%3a00&hidLoanMode=1
        Private Sub ShowResultDetail()
            Dim strPatronCode As String = Request("txtPatronCode")
            Dim intUserID As Integer = CInt(Session("UserID"))
            Dim tblLoanDataInfor As DataTable
            objBLoanTransactionDetail.PatronCode = strPatronCode
            objBLoanTransactionDetail.LoanMode = 1
            objBLoanTransactionDetail.UserID = intUserID
            objBLoanTransactionDetail.LibID = clsSession.GlbSite

            'tblLoanDataInfor = objBLoanTransactionDetail.GetLoanDetailInfor(1)
            tblLoanDataInfor = objBLoanTransactionDetail.GetLoanDetailInforFull(1)

            Dim tblCurrentTrans As DataTable
            If Not Session("TransactionID") Is Nothing Then
                If Not Trim(Session("TransactionID")) = "" Then
                    tblCurrentTrans = objBLoanTransaction.GetCurrentLoanInfor(CStr(Session("TransactionID")))
                    If Not tblCurrentTrans Is Nothing AndAlso tblCurrentTrans.Rows.Count > 0 Then
                        Dim arrIDTrans As String = ""
                        Dim index As Integer = 0
                        For Each row As DataRow In tblCurrentTrans.Rows
                            Dim id As String = row.Item("COPYNUMBER").ToString()
                            arrIDTrans = arrIDTrans & id & ","
                            index = index + 1
                        Next

                        If Not tblLoanDataInfor Is Nothing Then
                            If tblLoanDataInfor.Rows.Count > 0 Then
                                For i As Integer = tblLoanDataInfor.Rows.Count - 1 To 0 Step -1
                                    Dim dr As DataRow = tblLoanDataInfor.Rows(i)
                                    If (arrIDTrans.Contains(dr.Item("COPYNUMBER") & ",")) Then
                                        tblLoanDataInfor.Rows(i).Delete()
                                        tblLoanDataInfor.AcceptChanges()
                                    End If
                                Next

                            End If
                        End If
                    End If
                End If
            End If


            Dim tblCopy As New DataTable

            tblCopy.Columns.Add("STT")
            tblCopy.Columns.Add("TITLE")
            tblCopy.Columns.Add("CopyNumber")
            tblCopy.Columns.Add("CheckOutDate")
            tblCopy.Columns.Add("DueDate")
            tblCopy.Columns.Add("Note")
            tblCopy.Columns.Add("LoanDepositFee")

            If Not tblLoanDataInfor Is Nothing Then
                If tblLoanDataInfor.Rows.Count > 0 Then

                    'Dim newColumn As New Data.DataColumn("STT", GetType(System.String))
                    'newColumn.DefaultValue = "1"
                    'tblLoanDataInfor.Columns.Add(newColumn)
                    Dim indexRows As Integer = 1
                    For Each rows As DataRow In tblLoanDataInfor.Rows
                        Dim dtCopy As DataRow = tblCopy.NewRow
                        dtCopy.Item("STT") = indexRows.ToString()
                        dtCopy.Item("TITLE") = rows.Item("TITLE").ToString
                        dtCopy.Item("CopyNumber") = rows.Item("CopyNumber").ToString
                        dtCopy.Item("CheckOutDate") = rows.Item("CheckOutDate").ToString
                        dtCopy.Item("Note") = rows.Item("Note").ToString
                        dtCopy.Item("LoanDepositFee") = rows.Item("LoanDepositFee").ToString
                        'If (Not (rows.RowState = DataRowState.Deleted)) AndAlso (Not (String.IsNullOrEmpty(rows.Item("STT")))) Then
                        '    rows.Item("STT") = indexRows.ToString()
                        'End If
                        If Not IsDBNull(rows.Item("DUEDATE")) And CStr(rows.Item("DUEDATE")) <> "" Then
                            If rows.Item("LoanMode") <> 2 Then
                                If DateDiff(DateInterval.Day, rows.Item("DUEDATE"), Now()) > 0 Then
                                    dtCopy.Item("DueDate") = rows.Item("DUEDATE") & vbCrLf & "<font color='red'>" & ddlLabel.Items(8).Text & DateDiff(DateInterval.Day, rows.Item("DUEDATE"), Now()) & ddlLabel.Items(9).Text & "</font>"
                                Else
                                    dtCopy.Item("DueDate") = rows.Item("DUEDATE")
                                End If
                            Else
                                If DateDiff(DateInterval.Hour, rows.Item("DUEDATE"), Now()) > 0 Then
                                    dtCopy.Item("DueDate") = rows.Item("DUEDATE") & "<br><font color='red'>" & ddlLabel.Items(8).Text & DateDiff(DateInterval.Hour, rows.Item("DUEDATE"), Now()) & ddlLabel.Items(11).Text & "</font>"
                                Else
                                    dtCopy.Item("DueDate") = rows.Item("DUEDATE")
                                End If
                            End If
                        Else
                            dtCopy.Item("DueDate") = rows.Item("DUEDATE") & vbCrLf & "<font color='Blue'>" & ddlLabel.Items(10).Text & "</font>"
                        End If
                        tblCopy.Rows.Add(dtCopy)
                        indexRows = indexRows + 1
                    Next

                    dtgResultDetail.DataSource = tblCopy
                    dtgResultDetail.DataBind()
                    dtgResultDetail.Visible = True
                End If
                tblLoanDataInfor = Nothing
                tblCopy = Nothing
            End If
        End Sub

        ' dtgResult_UpdateCommand event
        Protected Sub dtgResult_UpdateCommand1(sender As Object, e As GridCommandEventArgs) Handles dtgResult.UpdateCommand
            Dim lngTransID As Long = CLng(CType(e.Item.Cells(0).FindControl("lblID"), Label).Text)

            ' Update now
            Dim editableItem As GridEditableItem = TryCast(e.Item, GridEditableItem)
            Dim strCheckOutDate = CStr(CType(e.Item.FindControl("lblCheckOutDate"), Label).Text).Replace("<br/>", "").Replace("<br/> ", "")
            Dim strDueDate = CType(editableItem("DUEDATE").Controls(0), TextBox).Text.Replace("<br/> ", "")
            If Not strDueDate = "" Then
                If CDate(strCheckOutDate) > CDate(strDueDate) Then
                    Page.RegisterClientScriptBlock("MsgJs2", "<script language = 'javascript'>alert('" & ddlLabel.Items(7).Text & "');</script>")
                Else
                    Dim strNote = CStr(CType(editableItem("Note").Controls(0), TextBox).Text)
                    Dim strDepositFee = CDbl(If(CType(editableItem("LoanDepositFee").Controls(0), TextBox).Text = "", "0", CType(editableItem("LoanDepositFee").Controls(0), TextBox).Text))
                    objBLoanTransaction.TransactionID = lngTransID
                    objBLoanTransaction.DueDate = Trim(strDueDate)
                    objBLoanTransaction.CheckOutDate = Trim(strCheckOutDate)
                    objBLoanTransaction.UpdateCurrentLoanRecord(Trim(strNote), strDepositFee)
                End If
            End If
            ' Refresh interface

            Call ShowResult()

            Call ShowResultDetail()

        End Sub


        'Public Sub dtgResult_UpdateCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
        '    Dim lngTransID As Long = CLng(CType(e.Item.Cells(0).FindControl("lblID"), Label).Text)

        '    ' Update now
        '    Dim strCheckOutDate = CStr(CType(e.Item.Cells(0).FindControl("lblCheckOutDate"), Label).Text)
        '    Dim strDueDate = CStr(CType(e.Item.Cells(5).Controls(0), TextBox).Text)
        '    If Not strDueDate = "" Then
        '        If CDate(strCheckOutDate) > CDate(strDueDate) Then
        '            Page.RegisterClientScriptBlock("MsgJs2", "<script language = 'javascript'>alert('" & ddlLabel.Items(7).Text & "');</script>")
        '        Else
        '            Dim strNote = CStr(CType(e.Item.Cells(6).Controls(0), TextBox).Text)
        '            objBLoanTransaction.TransactionID = lngTransID
        '            objBLoanTransaction.DueDate = Trim(strDueDate)
        '            objBLoanTransaction.UpdateCurrentLoanRecord(Trim(strNote))
        '        End If
        '    End If
        '    ' Refresh interface
        '    'dtgResult.EditItemIndex = -1
        '    Call ShowResult()
        '    'CType(dtgResult.Items(dtgResult.EditItemIndex).Cells(5).Controls(0), TextBox).Attributes.Add("OnChange", "javascript:CheckDate(this, 'dd/mm/yyyy', '" & ddlLabel.Items(3).Text & "');")
        '    'CType(dtgResult.Items(dtgResult.EditItemIndex).Cells(5).Controls(0), TextBox).Width = Unit.Point(60)
        '    'CType(dtgResult.Items(dtgResult.EditItemIndex).Cells(5).Controls(0), TextBox).CssClass = "lbTextBox"
        '    'CType(dtgResult.Items(dtgResult.EditItemIndex).Cells(6).Controls(0), TextBox).Width = Unit.Pixel(150)
        '    'CType(dtgResult.Items(dtgResult.EditItemIndex).Cells(6).Controls(0), TextBox).TextMode = TextBoxMode.MultiLine
        '    'CType(dtgResult.Items(dtgResult.EditItemIndex).Cells(6).Controls(0), TextBox).CssClass = "lbTextBox"
        'End Sub

        ' dtgResult_EditCommand event
        Protected Sub dtgResult_EditCommand1(sender As Object, e As GridCommandEventArgs) Handles dtgResult.EditCommand
            Call ShowResult()
            Call ShowResultDetail()
        End Sub


        'Public Sub dtgResult_EditCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
        '    dtgResult.EditItemIndex = e.Item.ItemIndex

        '    ' Show data for editing
        '    Call ShowResult()

        '    CType(dtgResult.Items(dtgResult.EditItemIndex).Cells(5).Controls(0), TextBox).Attributes.Add("OnChange", "javascript:CheckDate(this, 'dd/mm/yyyy', '" & ddlLabel.Items(3).Text & "');")
        '    CType(dtgResult.Items(dtgResult.EditItemIndex).Cells(5).Controls(0), TextBox).Width = Unit.Point(60)
        '    CType(dtgResult.Items(dtgResult.EditItemIndex).Cells(5).Controls(0), TextBox).CssClass = "lbTextBox"
        '    CType(dtgResult.Items(dtgResult.EditItemIndex).Cells(6).Controls(0), TextBox).Width = Unit.Pixel(150)
        '    CType(dtgResult.Items(dtgResult.EditItemIndex).Cells(6).Controls(0), TextBox).TextMode = TextBoxMode.MultiLine
        '    CType(dtgResult.Items(dtgResult.EditItemIndex).Cells(6).Controls(0), TextBox).CssClass = "lbTextBox"
        'End Sub

        ' dtgResult_CancelCommand event
        'Public Sub dtgResult_CancelCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
        '    dtgResult.EditItemIndex = -1
        '    Call ShowResult()
        'End Sub

        ' dtgResult_DeleteCommand event
        ' Purpose: Recall copy

        Protected Sub dtgResult_DeleteCommand1(sender As Object, e As GridCommandEventArgs) Handles dtgResult.DeleteCommand
            Dim lngTransID As Long = CLng(CType(e.Item.Cells(0).FindControl("lblID"), Label).Text)
            Dim strCurrentIDs As String = Session("TransactionID")

            ' Get CurrentIDs
            strCurrentIDs = Replace("," & strCurrentIDs & ",", "," & CStr(lngTransID) & ",", "")
            If Left(strCurrentIDs, 1) = "," Then
                strCurrentIDs = Right(strCurrentIDs, Len(strCurrentIDs) - 1)
            End If
            If Right(strCurrentIDs, 1) = "," Then
                strCurrentIDs = Left(strCurrentIDs, Len(strCurrentIDs) - 1)
            End If
            Session("TransactionID") = strCurrentIDs

            ' Delete LoanTransaction
            objBLoanTransaction.TransactionID = lngTransID
            objBLoanTransaction.RecallCopies()
            ' WriteLog
            Call WriteLog(45, ddlLabel.Items(4).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

            Session("Remain") = CInt(Session("Remain")) + 1
            Call ShowResult()
            Call ShowResultDetail()
        End Sub

        'Public Sub dtgResult_DeleteCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
        '    'Page.RegisterClientScriptBlock("submitformJS1", "<script language = 'javascript'>document.forms[0].hidHoldIgnored.value = 1;</script>")

        '    Dim lngTransID As Long = CLng(CType(e.Item.Cells(0).FindControl("lblID"), Label).Text)
        '    Dim strCurrentIDs As String = Session("TransactionID")

        '    ' Get CurrentIDs
        '    strCurrentIDs = Replace("," & strCurrentIDs & ",", "," & CStr(lngTransID) & ",", "")
        '    If Left(strCurrentIDs, 1) = "," Then
        '        strCurrentIDs = Right(strCurrentIDs, Len(strCurrentIDs) - 1)
        '    End If
        '    If Right(strCurrentIDs, 1) = "," Then
        '        strCurrentIDs = Left(strCurrentIDs, Len(strCurrentIDs) - 1)
        '    End If
        '    Session("TransactionID") = strCurrentIDs

        '    ' Delete LoanTransaction
        '    objBLoanTransaction.TransactionID = lngTransID
        '    objBLoanTransaction.RecallCopies()
        '    ' WriteLog
        '    Call WriteLog(45, ddlLabel.Items(4).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

        '    dtgResult.EditItemIndex = -1
        '    Session("Remain") = CInt(Session("Remain")) + 1
        '    Call ShowResult()
        'End Sub

        ' method: ShowDetailInfor
        ' Purpose: Show some main information of the current checkin transaction
        Private Sub ShowDetailInfor()
            Dim tblPatronInfor As DataTable

            ' Get patron informations
            objBPatron.PatronCode = Trim(hidPatronCode.Value)
            tblPatronInfor = objBPatron.GetPatronInfor()

            If Not tblPatronInfor Is Nothing Then
                If tblPatronInfor.Rows.Count > 0 Then
                    lblFullName.Text = CStr(tblPatronInfor.Rows(0).Item("FullName")) & " (" & CStr(tblPatronInfor.Rows(0).Item("Code")) & ")"
                    lblRange.Text = CStr(tblPatronInfor.Rows(0).Item("VALIDDATE")) & " - " & CStr(tblPatronInfor.Rows(0).Item("EXPIREDDATE"))
                    lblPatronGroup.Text = CStr(tblPatronInfor.Rows(0).Item("GroupName"))
                    lblDOB.Text = CStr(tblPatronInfor.Rows(0).Item("DOB"))
                    ' Show patron' image
                    If Not IsDBNull(tblPatronInfor.Rows(0).Item("Portrait")) Then
                        Dim strURL As String = "../Images/Card/" & Trim(CStr(tblPatronInfor.Rows(0).Item("Portrait")))
                        imgPatronImage.Src = "../../Common/ShowPic.aspx?intw=90&inth=120&Url=" & strURL
                    End If
                End If
                tblPatronInfor = Nothing
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
                If Not objBLoanTransactionDetail Is Nothing Then
                    objBLoanTransactionDetail.Dispose(True)
                    objBLoanTransactionDetail = Nothing
                End If
                If Not objBOverdueTransaction Is Nothing Then
                    objBOverdueTransaction.Dispose(True)
                    objBOverdueTransaction = Nothing
                End If
                If Not objBPatronGroup Is Nothing Then
                    objBPatronGroup.Dispose(True)
                    objBPatronGroup = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        Private Sub btnCheckOut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCheckOut.Click
            'PhuongTT
            'Modify 20080915
            hidHoldIgnored.Value = 1
            Call CheckOut()
            hidHoldIgnored.Value = 0
            lblClick.Visible = False
            btnCheckOut.Visible = False
            lblComment.Visible = False
            lblReasonInfor.Text = ""
        End Sub



        Protected Sub dtgResult_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles dtgResult.NeedDataSource
            ShowDetailInfor()
        End Sub


        Protected Sub dtgResult_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles dtgResult.ItemDataBound
            'CType(e.Item.FindControl("lblCheckOutDate"), Label).Text)
            If e.Item.Edit Then
                Dim strDuedate As String = CType(e.Item.Cells(8).Controls(0), TextBox).Text
                CType(e.Item.Cells(8).Controls(0), TextBox).Text = strDuedate.Replace("<br/>", "")

                Dim strDepositFee As String = CType(e.Item.Cells(9).Controls(0), TextBox).Text
                CType(e.Item.Cells(9).Controls(0), TextBox).Text = String.Format("{0:###,###}", CDbl(strDepositFee))
            End If
            If TypeOf e.Item Is GridEditFormItem AndAlso e.Item.IsInEditMode Then
                Dim editableItem As GridEditableItem = TryCast(e.Item, GridEditableItem)
                'Dim a = e.Item.Cells(7).Controls(0)
                CType(editableItem("DUEDATE").Controls(0), TextBox).Attributes.Add("OnChange", "javascript:CheckDate(this, 'dd/mm/yyyy', '" & ddlLabel.Items(3).Text & "');")
                CType(editableItem("DUEDATE").Controls(0), TextBox).Width = Unit.Point(60)
                CType(editableItem("DUEDATE").Controls(0), TextBox).CssClass = "lbTextBox"
                CType(editableItem("DUEDATE").Controls(0), TextBox).Width = Unit.Pixel(150)
                CType(editableItem("DUEDATE").Controls(0), TextBox).TextMode = TextBoxMode.MultiLine
                CType(editableItem("DUEDATE").Controls(0), TextBox).CssClass = "lbTextBox"
            End If


        End Sub

        Protected Sub dtgResult_CancelCommand(sender As Object, e As GridCommandEventArgs) Handles dtgResult.CancelCommand
            Call ShowResult()
            Call ShowResultDetail()
        End Sub

    End Class
End Namespace