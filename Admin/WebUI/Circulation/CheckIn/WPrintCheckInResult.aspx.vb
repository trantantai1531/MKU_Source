Imports eMicLibAdmin.WebUI.Common
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Circulation

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WPrintCheckInResult
        Inherits clsWBase

        Private objBLoanTransaction As New clsBLoanTransaction
        Public strTotalFees As String = ""
        Public strTotalOverdueFine As String = ""
        Public strTotalLoanDepositFee As String = ""
        Public strTotal As String = ""
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            If Page.IsPostBack = False Then
                If Not (String.IsNullOrEmpty(Request.QueryString("txtPatronInfo"))) Then
                    lbPatronInfo.Text = Request.QueryString("txtPatronInfo")
                    lbPatronInfolb.Visible = True
                    lbPatronInfo.Visible = True
                Else
                    lbPatronInfolb.Visible = False
                    lbPatronInfo.Visible = False
                End If


                Call BindData()
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: Init all necessary objects
        Private Sub Initialize()
            Response.Expires = 0

            ' Init objBLoanTransaction object
            objBLoanTransaction.InterfaceLanguage = Session("InterfaceLanguage")
            objBLoanTransaction.DBServer = Session("DBServer")
            objBLoanTransaction.ConnectionString = Session("ConnectionString")
            Call objBLoanTransaction.Initialize()
        End Sub

        Private Sub BindData()

            Dim strTransactionIDs As String = Request.QueryString("hidTransactionIDs")

            If (strTransactionIDs IsNot Nothing) AndAlso (strTransactionIDs <> "") Then
                objBLoanTransaction.TransactionIDs = strTransactionIDs
                Dim tblCurrentCheckInInfor As DataTable = objBLoanTransaction.GetCurrentCheckInInfor("LOAN")
                If Not tblCurrentCheckInInfor Is Nothing AndAlso tblCurrentCheckInInfor.Rows.Count > 0 Then
                    Dim index As Integer = 0
                    tblCurrentCheckInInfor.Columns.Add("STT")
                    For index = 0 To tblCurrentCheckInInfor.Rows.Count - 1
                        tblCurrentCheckInInfor.Rows(index).Item("STT") = (index + 1)
                    Next

                    strTotalFees = Session("strTotalFees")
                    strTotalOverdueFine = Session("strTotalOverdueFine")
                    strTotalLoanDepositFee = Session("strTotalLoanDepositFee")
                    strTotal = Session("strTotal")

                    tblFeeInfo.Visible = True
                    dtgResultCurrentCheckIn.DataSource = tblCurrentCheckInInfor
                    dtgResultCurrentCheckIn.DataBind()
                Else
                    tblFeeInfo.Visible = False
                    dtgResultCurrentCheckIn.DataSource = Nothing
                    dtgResultCurrentCheckIn.DataBind()
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
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace

