' Class: WCheckPatronCodeCI
' Puspose: Check infor of the Patron depending on PatronCode
' Creator: Oanhtn
' CreatedDate: 04/09/2004
' Modification History:
'   - 17/04/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.WebUI.Common

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WCheckPatronCodeCI
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

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call CheckPatronCode()
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

            ' Init objBPatron object
            objBPatron.InterfaceLanguage = Session("InterfaceLanguage")
            objBPatron.DBServer = Session("DBServer")
            objBPatron.ConnectionString = Session("ConnectionString")
            Call objBPatron.Initialize()
        End Sub

        ' Method: BindScript
        ' Purpose: include all neccessary javascript functions
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../Js/CheckIn/WCheckPatronCodeCI.js'></script>")
            btnCheckIn.Attributes.Add("OnClick", "return AutoPaidFees();")
        End Sub

        ' Method: CheckPatronCode
        ' Purpose: check infor depending on CopyNumber
        Private Sub CheckPatronCode()
            Dim intStatus As Int16
            Dim intUserID As Integer = CInt(Session("UserID"))
            Dim strPatronCode As String = Request("txtPatronCode")
            Dim strCopyNumber As String = Request("txtCopyNumber")

            'If Not Request("hidAutoPaidFees") = "" Then
            '    hidAutoPaidFees.Value = Trim(Request("hidAutoPaidFees"))
            'End If
            If Not Request("txtPatronCode") = "" Then
                hidPatronCode.Value = Trim(Request("txtPatronCode"))
            End If
            If Not Request("txtCopyNumber") = "" Then
                hidCopyNumber.Value = Trim(Request("txtCopyNumber"))
            End If

            If hidCheckInDate.Value = "" Then
                If Request("CheckInDate") = "" Then
                    hidCheckInDate.Value = Day(Now) & "/" & Month(Now) & "/" & Year(Now) & " " & CStr(Hour(Now)).PadLeft(2, "0") & ":" & CStr(Minute(Now)).PadLeft(2, "0") & ":" & CStr(Second(Now)).PadLeft(2, "0")
                Else
                    hidCheckInDate.Value = Request("CheckInDate")
                End If
            End If
            strPatronCode = hidPatronCode.Value

            objBLoanTransaction.PatronCode = strPatronCode
            objBLoanTransaction.UserID = intUserID
            intStatus = objBLoanTransaction.CheckPatronCode(0)
            If intStatus = 1 Then ' PatronCode is invalid
                If Request("From") = "" Then
                    Response.Redirect("../WAddPatron.aspx?CheckIn=1&PatronCode=" & strPatronCode)
                Else
                    Page.RegisterClientScriptBlock("InvalidPatronCodeJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(2).Text & "');</script>")
                End If
            Else
                Call ShowPatronInfor(intStatus, 0)
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
        Public Sub ShowPatronInfor(ByVal intStatus As Int16, ByVal intLoanMode As Int16)
            Dim tblPatronInfor As DataTable
            Dim tblOnLoanCopies As DataTable
            Dim tblLocation As DataTable
            Dim intCount As Integer
            Dim lngPatronID As Long
            Dim strPatronCode = hidPatronCode.Value

            lnkRenew.Visible = False
            lnkLoanHistory.NavigateUrl = "javascript:OpenWindow('../WLoanHistory.aspx?PatronCode=" & strPatronCode & "','WLoanHistory',600,400,100,100 );"

            objBPatron.PatronCode = strPatronCode
            tblPatronInfor = objBPatron.GetPatronInfor()
            dtgResult.Visible = False
            lblLoanHome.Visible = False
            btnCheckIn.Visible = False

            If Not tblPatronInfor Is Nothing Then
                If tblPatronInfor.Rows.Count > 0 Then
                    lblFullName.Text = CStr(tblPatronInfor.Rows(0).Item("FullName")) & " (" & CStr(tblPatronInfor.Rows(0).Item("Code")) & ")"
                    lblDOB.Text = CStr(tblPatronInfor.Rows(0).Item("DOB"))
                    lblValidDate.Text = CStr(tblPatronInfor.Rows(0).Item("VALIDDATE"))
                    lblExpiredDate.Text = CStr(tblPatronInfor.Rows(0).Item("EXPIREDDATE"))
                    lblPatronGroup.Text = CStr(tblPatronInfor.Rows(0).Item("GroupName"))
                    lblDebt.Text = CStr(tblPatronInfor.Rows(0).Item("Debt"))
                    lngPatronID = CLng(tblPatronInfor.Rows(0).Item("ID"))

                    ' Add some warning
                    lblLocation.Visible = False
                    If intStatus = 2 Then
                        lblDebt.Text = lblDebt.Text & " (<FONT COLOR=""RED"">" & ddlLabel.Items(3).Text & "</FONT>)"
                        Page.RegisterClientScriptBlock("NoContinueJs", "<script language = 'javascript'>parent.CheckOut.document.forms[0].hidContinue.value=0;</script>")
                        lnkRenew.Visible = True
                        lnkRenew.NavigateUrl = "javascript:OpenWindow('WRenewPatronCard.aspx?PatronCode=" & strPatronCode & "&LoanMode=" & intLoanMode & "', 'WRenewPatronCard',280,125,200,100);"
                    ElseIf intStatus = 3 Then
                        If Not intLoanMode = 3 Then
                            Page.RegisterClientScriptBlock("NoContinueJs", "<script language = 'javascript'>parent.CheckOut.document.forms[0].hidContinue.value=0;</script>")
                        End If
                        lblDebt.Text = lblDebt.Text & " (<FONT COLOR=""RED"">" & ddlLabel.Items(4).Text & "</FONT>)"
                    ElseIf intStatus = 4 Then
                        lblDebt.Text = lblDebt.Text & " (<FONT COLOR=""RED"">" & ddlLabel.Items(5).Text & "</FONT>)"
                    ElseIf intStatus = 5 Then
                        lblLocation.Visible = True
                        tblLocation = objBLoanTransaction.GetPatronLocations(strPatronCode)
                        If Not tblLocation Is Nothing Then
                            If tblLocation.Rows.Count > 0 Then
                                For intCount = 0 To tblLocation.Rows.Count - 1
                                    lblLocation.Text = lblLocation.Text & CStr(tblLocation.Rows(intCount).Item("Library")) & ":" & CStr(tblLocation.Rows(intCount).Item("Symbol")) & ", "
                                Next
                                lblLocation.Text = Left(lblLocation.Text, Len(lblLocation.Text) - 2)
                            End If
                            tblLocation = Nothing
                        End If
                    ElseIf intStatus = 6 Then
                        Page.RegisterClientScriptBlock("NoContinueJs", "<script language = 'javascript'>parent.CheckOut.document.forms[0].hidContinue.value=0;</script>")
                    End If

                    ' Set focus for txtCopyNumber
                    Page.RegisterClientScriptBlock("CopyNumberFocusJs", "<script language = 'javascript'>parent.CheckIn.document.forms[0].txtCopyNumber.focus();</script>")

                    ' Show patron' image
                    If Not IsDBNull(tblPatronInfor.Rows(0).Item("Portrait")) Then
                        Dim strURL As String = "../Images/Card/" & Trim(CStr(tblPatronInfor.Rows(0).Item("Portrait")))
                        imgPatronImage.Src = "../../Common/ShowPic.aspx?intw=90&inth=120&Url=" & strURL
                        'imgPatronImage.Src = "../WRasterImage.aspx?map=" & strURL & "&x=" & GenRandomNumber(10)
                    End If

                    ' Show detail information of this Patron
                    lnkDetailInfor.NavigateUrl = "javascript:OpenWindow('../WPatronDetail.aspx?PatronCode=" & strPatronCode & "','WPatronDetail',700,600,100,100);"

                    ' Show all his loan copies
                    objBLoanTransaction.PatronID = lngPatronID
                    tblOnLoanCopies = objBLoanTransaction.GetOnLoanCopiesOfPatron
                    Dim inti As Integer
                    For inti = 0 To tblOnLoanCopies.Rows.Count - 1
                        If Not IsDBNull(tblOnLoanCopies.Rows(inti).Item("DUEDATE")) And CStr(tblOnLoanCopies.Rows(inti).Item("DUEDATE")) <> "" Then
                            If tblOnLoanCopies.Rows(inti).Item("LoanMode") <> 2 Then
                                If DateDiff(DateInterval.Day, tblOnLoanCopies.Rows(inti).Item("DUEDATE"), Now()) > 0 Then
                                    tblOnLoanCopies.Rows(inti).Item("DUEDATE") = tblOnLoanCopies.Rows(inti).Item("DUEDATE") & vbCrLf & "<font color='red'>" & ddlLabel.Items(8).Text & DateDiff(DateInterval.Day, tblOnLoanCopies.Rows(inti).Item("DUEDATE"), Now()) & ddlLabel.Items(9).Text & "</font>"
                                End If
                            Else
                                If DateDiff(DateInterval.Hour, tblOnLoanCopies.Rows(inti).Item("DUEDATE"), Now()) > 0 Then
                                    tblOnLoanCopies.Rows(inti).Item("DUEDATE") = tblOnLoanCopies.Rows(inti).Item("DUEDATE") & vbCrLf & "<font color='red'>" & ddlLabel.Items(8).Text & DateDiff(DateInterval.Hour, tblOnLoanCopies.Rows(inti).Item("DUEDATE"), Now()) & ddlLabel.Items(11).Text & "</font>"
                                End If
                            End If
                        Else
                            tblOnLoanCopies.Rows(inti).Item("DUEDATE") = tblOnLoanCopies.Rows(inti).Item("DUEDATE") & vbCrLf & "<font color='Blue'>" & ddlLabel.Items(10).Text & "</font>"
                        End If
                    Next

                    If Not tblOnLoanCopies Is Nothing AndAlso tblOnLoanCopies.Rows.Count > 0 Then
                        dtgResult.DataSource = tblOnLoanCopies
                        dtgResult.DataBind()
                        dtgResult.Visible = True
                        lblLoanHome.Visible = True
                        btnCheckIn.Visible = True
                    End If
                    tblOnLoanCopies = Nothing
                End If
                tblPatronInfor = Nothing
            End If
        End Sub

        ' Event: btnCheckIn_Click
        ' Purpose: CheckIn selected copies
        Private Sub btnCheckIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckIn.Click
            Dim dtgItem As DataGridItem
            Dim chkCirID As CheckBox
            Dim strCopyNumbers As String
            Dim intError As Int16 = 0

            For Each dtgItem In dtgResult.Items
                chkCirID = dtgItem.FindControl("chkCopyNumber")
                If chkCirID.Checked Then
                    strCopyNumbers = strCopyNumbers & CType(dtgItem.FindControl("lblCopyNumber"), Label).Text & ","
                End If
            Next
            Session("TransactionIDs") = Nothing
            If Not strCopyNumbers = "" Then
                strCopyNumbers = Left(strCopyNumbers, strCopyNumbers.Length - 1)

                objBLoanTransaction.PatronCode = hidPatronCode.Value
                objBLoanTransaction.CheckInDate = hidCheckInDate.Value
                intError = objBLoanTransaction.CheckIn(strCopyNumbers, hidAutoPaidFees.Value)
                Session("CopyNumber") = strCopyNumbers
                Session("TransactionIDs") = Session("TransactionIDs") & objBLoanTransaction.TransactionIDs & ","

                If intError = 0 Then
                    Page.RegisterClientScriptBlock("SuccessJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(6).Text & "');</script>")
                    If Request("hidAutoPaidFees") = "0" Then
                        lblJavascript.Text = "<script language = 'javascript'>OpenWindow('WPaidFees.aspx','WPaidFees',300,200,150,50);</script>"
                    End If
                    Page.RegisterClientScriptBlock("RefreshCheckInFormJs", "<script language = 'javascript'>parent.CheckIn.document.forms[0].txtCopyNumber.value=''; parent.CheckIn.document.forms[0].txtCopyNumber.focus();</script>")
                Else
                    Page.RegisterClientScriptBlock("FailJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(7).Text & "');</script>")
                End If
                Call CheckPatronCode()
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
    End Class
End Namespace