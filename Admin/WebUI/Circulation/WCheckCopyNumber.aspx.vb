' Class: WCheckCopyNumber
' Puspose: Check infor of the CopyNumber
' Creator: Oanhtn
' CreatedDate: 25/08/2004
' Modification History:
'   - 17/04/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.BusinessRules.Circulation

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WCheckCopyNumber
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
        Private objBCopyNumber As New clsBCopyNumber
        Private objBLoanTransaction As New clsBLoanTransaction
        Private objBPatron As New clsBPatron

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call CheckCopyNumber()
            Else
                Call GetCopyNumberInfor()
                lblSubmitForm.Text = "<script language = 'javascript'>document.forms[0].hidHoldIgnored.value = 1; SubmitForm();</script>"
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            Response.Expires = 0

            ' Init objBCopyNumber object
            objBCopyNumber.InterfaceLanguage = Session("InterfaceLanguage")
            objBCopyNumber.DBServer = Session("DBServer")
            objBCopyNumber.ConnectionString = Session("ConnectionString")
            Call objBCopyNumber.Initialize()

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
        End Sub

        ' Method: BindJS
        ' Purpose: include all neccessary javascript functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = 'Js/WCheckCopyNumber.js'></script>")
        End Sub

        ' CheckCopyNumber method
        ' Purpose: check infor depending on CopyNumber
        Private Sub CheckCopyNumber()
            Dim intStatus As Int16
            Dim tblPatronInfor As DataTable

            Dim intUserID = CInt(Session("UserID"))
            Dim strPatronCode = Trim(Request.Form("txtPatronCode"))
            Dim strCopyNumber = Trim(Request.Form("txtCopyNumber"))

            ' Get some information for load
            Dim intExemptQuota As Int16 = 1
            Dim intIndefiniteDue As Int16 = 1
            Dim strCheckOutDate As String = Trim(Request.Form("txtCreatedDate"))
            Dim strCheckOutTime As String = Trim(Request.Form("txtCreatedTime"))
            Dim strDueDate As String = Trim(Request.Form("txtDueDate"))
            Dim strDueTime As String = Trim(Request.Form("txtDueTime"))
            Dim intLoanMode As Int16 = CInt(Request.Form("hidLoanMode"))
            Dim intRemain As Int16 = CInt(Request.Form("hidRemain"))

            If Request.Form("chkIndefiniteDue") = "on" Then
                intIndefiniteDue = 0
            End If

            'Check(ExpiredDate And txtDueDate)
            If strDueDate <> "" Then
                objBPatron.PatronCode = strPatronCode
                tblPatronInfor = objBPatron.GetPatronInfor()
                If CDate(strDueDate) > CDate(tblPatronInfor.Rows(0).Item("ExpDate")) Then
                    Page.RegisterClientScriptBlock("ErrJS", "<script language='javascript'>alert('" & ddlLabel.Items(3).Text & "');parent.CheckOut.document.forms[0].reset();</script>")
                    lblReason.Visible = False
                    Exit Sub
                End If
            End If
            ' Create hidden fields
            hidPatronCode.Value = strPatronCode
            hidCopyNumber.Value = strCopyNumber
            hidExemptQuota.Value = intExemptQuota
            hidIndefiniteDue.Value = intIndefiniteDue
            hidCheckOutDate.Value = strCheckOutDate
            hidCheckOutTime.Value = strCheckOutTime
            hidDueDate.Value = strDueDate
            hidDueTime.Value = strDueTime
            hidLoanMode.Value = intLoanMode
            hidRemain.Value = intRemain

            If CInt(Session("Remain")) = 0 And Not intLoanMode = 3 Then
                lblReason.Visible = False
                lblClick.Visible = False
                lblClick1.Visible = True
                lblComment1.Visible = True
                btnCheckOut1.Visible = True
                btnCheckOut1.Attributes.Add("OnClick", "javascript:parent.CheckOut.document.forms[0].hidLoanMode.value=3; parent.CheckOut.document.forms[0].txtCopyNumber.value=''; parent.CheckOut.document.forms[0].txtCopyNumber.focus();")
            Else
                ' Checking now ...
                objBLoanTransaction.UserID = intUserID
                objBLoanTransaction.PatronCode = strPatronCode
                objBLoanTransaction.CopyNumber = strCopyNumber

                lblReason.Visible = False
                intStatus = objBLoanTransaction.CheckCopyNumber()

                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBLoanTransaction.ErrorMsg, ddlLabel.Items(0).Text, objBLoanTransaction.ErrorCode)

                Select Case intStatus
                    Case 0
                        lblReason.Visible = True
                        lblReason.Text = "<H2>" & lblReason.Text & "</H2>"
                        Call GetCopyNumberInfor()
                        lblSubmitForm.Text = "<script language = 'javascript'>SubmitForm();</script>"
                    Case 1 ' Copynumber doesn't exists
                        lblReasonInfor.Text = "<FONT COLOR=""RED"">" & lblMsg1.Text & strCopyNumber & "</FONT>"
                    Case 2 ' Copynumber is locked or not in circulation
                        lblReasonInfor.Text = "<FONT COLOR=""RED"">" & lblMsg2.Text & "</FONT>"
                    Case 3 ' Copynumber is on load
                        lblReasonInfor.Text = "<FONT COLOR=""RED"">" & lblMsg3.Text & "</FONT>"
                    Case 4 ' Copynumber is on hold
                        lblClick.Visible = True
                        btnCheckOut.Visible = True
                        lblComment.Visible = True
                        lblReasonInfor.Text = "<FONT COLOR=""RED"">" & lblMsg4.Text & "</FONT>"
                        ' Allow pass hold now ........
                    Case 5 ' Librarian has not permission to manage location of the CopyNumber
                        lblReasonInfor.Text = "<FONT COLOR=""RED"">" & lblMsg5.Text & "</FONT>"
                    Case 6 ' Librarian has not permission to manage location of Patron
                        lblReasonInfor.Text = "<FONT COLOR=""RED"">" & lblMsg6.Text & "</FONT>"
                    Case 7 ' Patron is locked
                        lblReasonInfor.Text = "<FONT COLOR=""RED"">" & ddlLabel.Items(2).Text & "</FONT>"

                End Select
                Page.RegisterClientScriptBlock("RefreshJs", "<script language = 'javascript'>parent.CheckOut.document.forms[0].txtCopyNumber.value='';parent.CheckOut.document.forms[0].txtCopyNumber.focus();parent.CheckOut.document.forms[0].btnCheckOut.disabled=false;</script>")
            End If
        End Sub

        ' Method: GetCopyNumberInfor
        ' Purpose: Get all information of the selected CopyNumber
        Private Sub GetCopyNumberInfor()
            Dim intLoanMode As Int16
            Dim intLoanTypeID As Integer
            Dim strCopyNumber = hidCopyNumber.Value
            Dim tblCopyNumberInfor As DataTable

            If Not strCopyNumber = "" Then
                objBCopyNumber.CopyNumber = strCopyNumber
                tblCopyNumberInfor = objBCopyNumber.GetCopyNumberInfor

                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCopyNumber.ErrorMsg, ddlLabel.Items(0).Text, objBCopyNumber.ErrorCode)

                If Not tblCopyNumberInfor Is Nothing Then
                    If tblCopyNumberInfor.Rows.Count > 0 Then
                        If Not IsDBNull(tblCopyNumberInfor.Rows(0).Item("ItemID")) Then
                            hidItemID.Value = tblCopyNumberInfor.Rows(0).Item("ItemID")
                        End If
                        If Not IsDBNull(tblCopyNumberInfor.Rows(0).Item("LoanTypeID")) Then
                            hidLoanTypeID.Value = tblCopyNumberInfor.Rows(0).Item("LoanTypeID")
                        End If
                        If Not IsDBNull(tblCopyNumberInfor.Rows(0).Item("LocationID")) Then
                            hidLocationID.Value = tblCopyNumberInfor.Rows(0).Item("LocationID")
                        End If
                        If Not IsDBNull(tblCopyNumberInfor.Rows(0).Item("LibID")) Then
                            hidLibID.Value = tblCopyNumberInfor.Rows(0).Item("LibID")
                        End If
                    End If
                    tblCopyNumberInfor = Nothing
                End If
            End If
            ' Load CheckOutMain
        End Sub

        ' Event: btnCheckOut1_Click
        ' Purpose: UnQuota loan
        Private Sub btnCheckOut1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckOut1.Click
            hidLoanMode.Value = 3
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
                If Not objBCopyNumber Is Nothing Then
                    objBCopyNumber.Dispose(True)
                    objBCopyNumber = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace