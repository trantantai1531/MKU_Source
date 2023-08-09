' Class: WPaidFees
' Puspose: Display paid fees window
' Creator: Oanhtn
' CreatedDate: 08/09/2004
' Modification History:
'   - 17/04/2005 by Oanhtn: Review & update

Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.WebUI.Common

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WPaidFees
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

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
            Call ShowLoanInfor()
        End Sub

        ' Method: BindScript
        ' Purpose: include all neccessary javascript functions
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")

            btnClose.Attributes.Add("OnClick", "javascript:self.close();")
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
        End Sub

        ' Method: ShowLoanInfor
        ' Purpose: show information of the current loan transaction
        Private Sub ShowLoanInfor()
            Dim tblCurrentTrans As DataTable
            Dim dblFees As Double = 0

            If Not Session("TransactionIDs") Is Nothing Then
                If Not Session("TransactionIDs") = "" Then
                    objBLoanTransaction.TransactionIDs = Session("TransactionIDs")
                    tblCurrentTrans = objBLoanTransaction.GetFineFees()
                    If Not tblCurrentTrans Is Nothing Then
                        If tblCurrentTrans.Rows.Count > 0 Then
                            lblFines.Text = tblCurrentTrans.Rows(0).Item("Fines")
                            lblFees.Text = tblCurrentTrans.Rows(0).Item("Fees")
                            dblFees = CDbl(tblCurrentTrans.Rows(0).Item("Fees")) + CDbl(tblCurrentTrans.Rows(0).Item("Fines"))
                        End If
                        tblCurrentTrans = Nothing
                    End If
                End If
            End If
            If dblFees = 0 Then
                Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript'>self.close();</script>")
            End If
        End Sub

        ' Event: btnLog_Click
        ' Purpose: Update debt, fees
        Private Sub btnLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLog.Click
            objBLoanTransaction.TransactionIDs = Session("TransactionIDs")
            Call objBLoanTransaction.LogFineFees()
            Session("TransactionIDs") = Nothing
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript'>self.close();</script>")
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

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Session("TransactionIDs") = Nothing
        End Sub
    End Class
End Namespace