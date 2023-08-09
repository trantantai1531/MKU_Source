' Class: WCheckCopyNumber
' Puspose: Check infor of the CopyNumber
' Creator: Oanhtn
' CreatedDate: 25/08/2004
' Modification History:
'   - 17/04/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WCheckCopyNumberCI
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

        Private objBLoanTransaction As New clsBLoanTransaction

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
            Call CheckCopyNumber()
        End Sub

        ' Method: Initialize
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init objBLoanTransaction object
            objBLoanTransaction.InterfaceLanguage = Session("InterfaceLanguage")
            objBLoanTransaction.DBServer = Session("DBServer")
            objBLoanTransaction.ConnectionString = Session("ConnectionString")
            Call objBLoanTransaction.Initialize()
        End Sub

        ' Method: BindScript
        ' Purpose: include all neccessary javascript functions
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = 'Js/WCheckCopyNumber.js'></script>")
        End Sub

        ' Method: CheckCopyNumber
        ' Purpose: check infor depending on CopyNumber
        Private Sub CheckCopyNumber()
            Dim intStatus As Int16
            Dim intUserID = CInt(Session("UserID"))

            ' Get some information for load
            Dim strPatronCode As String = Trim(Request.Form("txtPatronCode"))
            Dim strCopyNumber As String = Trim(Request.Form("txtCopyNumber"))
            Dim strCheckInDate As String = Trim(Request.Form("txtCheckInDate"))
            Dim strCheckInTime As String = Trim(Request.Form("txtCheckInTime"))
            Dim strAutoPaidFees As String = Trim(Request.Form("hidAutoPaidFees"))
            If strCheckInTime <> "" Then
                strCheckInDate = Trim(strCheckInDate & " " & strCheckInTime)
            End If
            ' Create hidden fields
            txtPatronCode.Value = strPatronCode
            txtCopyNumber.Value = strCopyNumber
            txtCheckInDate.Value = strCheckInDate
            hidAutoPaidFees.Value = strAutoPaidFees


            ' Checking now ...
            objBLoanTransaction.UserID = intUserID
            objBLoanTransaction.PatronCode = strPatronCode
            objBLoanTransaction.CopyNumber = strCopyNumber

            lblReason.Visible = False
            intStatus = objBLoanTransaction.CheckCopyNumber()
            Select Case intStatus
                Case 0 ' Copynumber doesn't exists
                    lblReasonInfor.Text = "<FONT COLOR=""RED"">" & ddlLabel.Items(2).Text & strCopyNumber & "</FONT>"
                Case 1 ' Copynumber doesn't exists
                    lblReasonInfor.Text = "<FONT COLOR=""RED"">" & ddlLabel.Items(2).Text & strCopyNumber & "</FONT>"
                Case 2 ' Copynumber is locked or not in circulation
                    ' Impossiable
                    lblReasonInfor.Text = "<FONT COLOR=""RED"">" & ddlLabel.Items(3).Text & "</FONT>"
                Case 3 ' Copynumber is on load
                    lblSubmitForm.Text = "<script language = 'javascript'>document.forms[0].target='CheckInMain'; document.forms[0].action = 'WCheckInResult.aspx?CheckInDate=" & Request("CheckInDate") & "'; document.forms[0].submit();</script>"
                    'Page.RegisterClientScriptBlock("OpenWindowJs", "<script language = 'javascript'>document.forms[0].target='CheckInMain'; document.forms[0].action = 'WCheckInResult.aspx'; document.forms[0].submit();</script>")
                Case 4 ' Copynumber is on hold
                    ' Impossiable
                    ' lblReasonInfor.Text = "<FONT COLOR=""RED"">" & ddlLabel.items(4).Text & "</FONT>"
                    ' Allow pass hold now ........
                Case 5 ' Librarian has not permission to manage location of the CopyNumber
                    lblReasonInfor.Text = "<FONT COLOR=""RED"">" & ddlLabel.Items(5).Text & "</FONT>"
                Case 6 ' Librarian has not permission to manage location of Patron
                    lblReasonInfor.Text = "<FONT COLOR=""RED"">" & ddlLabel.Items(6).Text & "</FONT>"
            End Select
            Page.RegisterClientScriptBlock("RefreshJs", "<script language = 'javascript'>parent.CheckIn.document.forms[0].txtCopyNumber.value='';parent.CheckIn.document.forms[0].txtCopyNumber.focus();</script>")
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
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace