
Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Common
Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WCheckOutAddDeposit
        Inherits clsWBase

        Private objBLoanTransaction As New clsBLoanTransaction
        Private objBPatron As New clsBPatron
        Private objBPatronGroup As New BusinessRules.Patron.clsBPatronGroup
        Private objBLoanTransactionDetail As New clsBLoanTransaction
        Private objBOverdueTransaction As New clsBOverdueTransaction
        Private objBCDBS As New clsBCommonDBSystem
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
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            If Page.IsPostBack = False Then
                Dim strPatronCode = Trim(Request("txtPatronCode"))

                Dim strCopyNumber As String = Request.QueryString("txtCopyNumber")
                Dim strCreatedDate As String = Request.QueryString("txtCreatedDate")
                Dim strCreatedTime As String = Request.QueryString("txtCreatedTime")
                Dim strHidOpen As String = Request.QueryString("hidOpen")
                Dim strDueDatee As String = Request.QueryString("txtDueDate")
                Dim strDueTime As String = Request.QueryString("txtDueTime")
                Dim strHidLoanMode As String = Request.QueryString("hidLoanMode")
                'Dim strLoanCode As String = Request.QueryString("txtLoanCode") & ""
                'Dim strHidHighQuanlity As String = Request.QueryString("hidHighQuanlity")
                Dim tblResult As DataTable
                objBCDBS.SQLStatement = "SELECT * FROM Lib_tblHolding WHERE UPPER(CopyNumber)='" & strCopyNumber.ToUpper & "'"
                tblResult = objBCDBS.RetrieveItemInfor()

                If Not IsNothing(tblResult) AndAlso tblResult.Rows.Count > 0 Then
                    Dim intPrice As Integer = CInt(tblResult.Rows(0).Item("Price").ToString)
                    intPrice = ((intPrice + 50000) \ 50000) * 50000
                    txtAmountDeposit.Text = CStr(intPrice \ 1000)
                    LiteralHoldingPrice.Text = String.Format(lblMsg1.Text, If(CInt("0" & tblResult.Rows(0).Item("Price").ToString) <> 0, String.Format("{0:###,###}", CDbl(tblResult.Rows(0).Item("Price").ToString)), "0"))
                Else
                    txtAmountDeposit.Text = "50"
                    LiteralHoldingPrice.Text = String.Format(lblMsg1.Text, "0")
                End If

                LiteralHoldingPrice.Text = String.Format(lblMsg1.Text, If(CInt("0" & tblResult.Rows(0).Item("Price").ToString) <> 0, String.Format("{0:###,###}", CDbl(tblResult.Rows(0).Item("Price").ToString)), "0"))

                Dim strRequestPageNothing As String = "document.location.href = '../../WNothing.aspx';"

                'If Not Page.IsPostBack Then
                '    If CheckOverdue() Then
                '        'Call Prepare()
                '        Call CheckOut()
                '    End If
                'End If
            End If
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
        Protected Sub btnAddDeposit_Click(sender As Object, e As EventArgs) Handles btnAddDeposit.Click
            Dim strPatronCode = Trim(Request("txtPatronCode"))
            Dim strCopyNumber As String = Request.QueryString("txtCopyNumber")
            Dim strCreatedDate As String = Request.QueryString("txtCreatedDate")
            Dim strCreatedTime As String = Request.QueryString("txtCreatedTime")
            Dim strHidOpen As String = Request.QueryString("hidOpen")
            Dim strDueDatee As String = Request.QueryString("txtDueDate")
            Dim strDueTime As String = Request.QueryString("txtDueTime")
            Dim strHidLoanMode As String = Request.QueryString("hidLoanMode")

            Dim strAmountDeposit = String.Format("{0}", CInt(txtAmountDeposit.Text) * 1000)
            Dim strHidHighQuanlity As String = hidIsHighQuanlity.Value
            'Dim strHref As String = "WCheckOutResult.aspx?txtPatronCode=" & strPatronCode & "&txtCopyNumber=" & strCopyNumber & "&txtCreatedDate=" & strCreatedDate & "&txtCreatedTime=" & strCreatedTime & "&hidOpen=" & strHidOpen & "&txtDueDate=" & strDueDatee & "&txtDueTime=" & strDueTime & "&hidLoanMode=" & strHidLoanMode & "&txtAmountDeposit=" & strAmountDeposit & "&hidHighQuanlity=" & strHidHighQuanlity
            Dim strHref As String = "WCheckOutResult.aspx?txtPatronCode=" & strPatronCode & "&txtCopyNumber=" & strCopyNumber & "&txtCreatedDate=" & strCreatedDate & "&txtCreatedTime=" & strCreatedTime & "&hidOpen=" & strHidOpen & "&txtDueDate=" & strDueDatee & "&txtDueTime=" & strDueTime & "&hidLoanMode=" & strHidLoanMode & "&txtAmountDeposit=" & strAmountDeposit & "&hidHighQuanlity=" & strHidHighQuanlity
            Page.RegisterClientScriptBlock("RefreshJs", "<script type='text/javascript'> document.location.href = '" & strHref & "'; </script>")
        End Sub

        Private Sub WCheckOutAddDeposit_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed

        End Sub
    End Class
End Namespace