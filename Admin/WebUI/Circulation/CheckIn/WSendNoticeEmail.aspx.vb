' Class: WSendNoticeEmail
' Puspose: Display notice email form
' Creator: Oanhtn
' CreatedDate: 09/09/2004
' Modification History:
'   17/04/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.WebUI.Common

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WSendNoticeEmail
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblLabel0 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel2 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel3 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel4 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel5 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel6 As System.Web.UI.WebControls.Label


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
            Call SendNoteMail()
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

        ' Method: SendNoteMail
        ' Purpose: send notice mail for inturn patron
        Private Sub SendNoteMail()
            Dim tblHoldInfor As DataTable
            Dim arrTransactionID()
            Dim strTemp As String
            Dim intIndex As Int16
            Dim strTimeOutDate As String
            Dim intPeriod As Int16
            Dim strCreatedDate As String
            Dim strTitle As String
            Dim strEmail As String
            Dim strPatronCode As String
            Dim strFullName As String
            Dim strSubject As String
            Dim strMailBody As String

            Dim tblData As New DataTable
            Dim tblRow As DataRow

            tblData.Columns.Add("ID", Type.GetType("System.Int32"))
            tblData.Columns.Add("PatronCode", Type.GetType("System.String"))
            tblData.Columns.Add("FullName", Type.GetType("System.String"))
            tblData.Columns.Add("Title", Type.GetType("System.String"))
            tblData.Columns.Add("CreatedDate", Type.GetType("System.String"))
            tblData.Columns.Add("TimeOutDate", Type.GetType("System.String"))
            tblData.Columns.Add("Note", Type.GetType("System.String"))

            ' For testing
            Session("TransactionIDs") = 60
            If Not Session("TransactionIDs") Is Nothing Then
                strTemp = Trim(Session("TransactionIDs"))
                If Right(strTemp, 1) = "," Then
                    strTemp = Left(strTemp, Len(strTemp) - 1)
                End If
                arrTransactionID = Split(strTemp, ",")
                For intIndex = LBound(arrTransactionID) To UBound(arrTransactionID)
                    objBLoanTransaction.TransactionID = arrTransactionID(intIndex)
                    tblHoldInfor = objBLoanTransaction.GetHoldRequest()
                    If Not tblHoldInfor Is Nothing Then
                        If tblHoldInfor.Rows.Count > 0 Then
                            strTimeOutDate = CStr(tblHoldInfor.Rows(intIndex).Item("CREATEDDATE"))
                            If Not IsDBNull(tblHoldInfor.Rows(intIndex).Item("HoldTurnTimeOut")) Then
                                intPeriod = CInt(tblHoldInfor.Rows(intIndex).Item("HoldTurnTimeOut"))
                            Else
                                intPeriod = 2
                            End If
                            strTimeOutDate = objBLoanTransaction.CalculateHoldDate(strTimeOutDate, intPeriod)
                            ' Get some infor for sending email
                            strCreatedDate = tblHoldInfor.Rows(intIndex).Item("CREATEDDATE")
                            strTitle = tblHoldInfor.Rows(intIndex).Item("TITLE")
                            strEmail = tblHoldInfor.Rows(intIndex).Item("Email")
                            strPatronCode = tblHoldInfor.Rows(intIndex).Item("PatronCode")
                            strFullName = tblHoldInfor.Rows(intIndex).Item("FirstName") & " "
                            If Not IsDBNull(tblHoldInfor.Rows(intIndex).Item("MiddleName")) Then
                                strFullName = strFullName & Trim(tblHoldInfor.Rows(intIndex).Item("MiddleName")) & " "
                            End If
                            strFullName = strFullName & Trim(tblHoldInfor.Rows(intIndex).Item("LastName"))
                            strFullName = Trim(Replace(strFullName, "  ", " "))

                            strSubject = lblLabel0.Text

                            strMailBody = "<HTML><HEAD><META HTTP-EQUIV=""Content-Type"" CONTENT=""text/html; charset=utf-8""><TITLE>" & strSubject & "</TITLE></HEAD><BODY BGCOLOR=""FFFFFF"" STYLE=""font-family:Arial Unicode MS;font-size=12px""><FONT FACE=""Arial Unicode MS, Arial"" SIZE=2>" & ddlLabel.Items(2).Text & strFullName & "<BR>" & Chr(10) & Chr(13)
                            strMailBody = strMailBody & ddlLabel.Items(3).Text & Chr(10) & Chr(13) & strTitle & ", " & ddlLabel.Items(4).Text & strCreatedDate & ddlLabel.Items(5).Text & Chr(10) & Chr(13) & ddlLabel.Items(6).Text & strTimeOutDate & "<BR>" & Chr(10) & Chr(13) & ddlLabel.Items(7).Text

                            ' Send mail now
                            SendMail(strSubject & " - " & strFullName, strMailBody, strEmail, True)
                            tblRow = tblData.NewRow
                            tblRow(0) = intIndex + 1
                            tblRow(1) = strPatronCode
                            tblRow(2) = strFullName
                            tblRow(3) = strTitle
                            tblRow(4) = strCreatedDate
                            tblRow(5) = strTimeOutDate
                            tblRow(6) = ""
                            tblData.Rows.Add(tblRow)
                        End If
                    End If
                Next
                dtgResult.DataSource = tblData
                dtgResult.DataBind()
            End If
            Session("TransactionIDs") = Nothing
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