' Class: WReportLoan
' Puspose: Get Patron loaned
' Creator: Tuanhv
' CreatedDate: 05/09/2004
' Modification History:
'   - 17/04/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WLoanHistory
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Protected WithEvents lblErrInput As System.Web.UI.WebControls.Label



        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBUserLocation As New clsBUserLocation
        Private objBLoanTransaction As New clsBLoanTransaction

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()

            If Not Page.IsPostBack Then
                'Call bindDataLoaction()
                Dim strPatronCode As String = Request("PatronCode")
                Dim strItemCode As String = ""
                Dim strCopyNumber As String = ""
                Dim intLocationID As Integer = 0
                Dim strCheckOutDateFrom As String = ""
                Dim strCheckOutDateTo As String = ""
                Dim strDueDateFrom As String = ""
                Dim strDueDateTo As String = ""
                Dim intUserID As Integer = Session("UserID")
                Dim tblCreateloanReport As DataTable

                lblPatronCode.Text = lblPatronCode.Text & Request("PatronCode")
                tblCreateloanReport = objBLoanTransaction.CreateLoanReport(strPatronCode, strItemCode, strCopyNumber, intLocationID, strCheckOutDateFrom, strCheckOutDateTo, strDueDateFrom, strDueDateTo, intUserID)

                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBLoanTransaction.ErrorMsg, ddlLabel.Items(0).Text, objBLoanTransaction.ErrorCode)

                If Not tblCreateloanReport Is Nothing Then
                    If tblCreateloanReport.Rows.Count > 0 Then
                        DgdGetPatronInfor.DataSource = tblCreateloanReport
                        DgdGetPatronInfor.DataBind()
                    End If
                    tblCreateloanReport = Nothing
                End If
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: Init all need object
        Private Sub Initialize()
            ' Init objBUserLocation object
            objBUserLocation.ConnectionString = Session("ConnectionString")
            objBUserLocation.DBServer = Session("DBServer")
            objBUserLocation.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBUserLocation.Initialize()

            ' Init clsBLoanTransaction object
            objBLoanTransaction.ConnectionString = Session("ConnectionString")
            objBLoanTransaction.DBServer = Session("DBServer")
            objBLoanTransaction.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBLoanTransaction.Initialize()
        End Sub

        ' Method: BindScript
        ' Purpose: Bind javascript
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("CheckDateSetForcus", "<script language = 'javascript' src = '../Js/Statistic/WReportOnLoanCopy.js'></script>")
        End Sub

        ' Event: DgdGetPatronInfor_PageIndexChanged
        ' Purpose: Result data allow pageIndex
        Private Sub DgdGetPatronInfor_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DgdGetPatronInfor.PageIndexChanged
            Call BindData(e.NewPageIndex)
        End Sub

        ' Method: BindData
        ' Purpose : Result data allow pageIndex
        Sub BindData(Optional ByVal intPage As Integer = 0)
            Dim strPatronCode As String = Request("PatronCode")
            Dim strItemCode As String = ""
            Dim strCopyNumber As String = ""
            Dim intLocationID As Integer = 0
            Dim strCheckOutDateFrom As String = ""
            Dim strCheckOutDateTo As String = ""
            Dim strDueDateFrom As String = ""
            Dim strDueDateTo As String = ""
            Dim intUserID As Integer = Session("UserID")
            Dim tblCreateloanReport As DataTable

            lblPatronCode.Text = lblPatronCode.Text & Request("PatronCode")
            tblCreateloanReport = objBLoanTransaction.CreateLoanReport(strPatronCode, strItemCode, strCopyNumber, intLocationID, strCheckOutDateFrom, strCheckOutDateTo, strDueDateFrom, strDueDateTo, intUserID)

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBLoanTransaction.ErrorMsg, ddlLabel.Items(0).Text, objBLoanTransaction.ErrorCode)

            If Not tblCreateloanReport Is Nothing Then
                If tblCreateloanReport.Rows.Count > 0 Then
                    DgdGetPatronInfor.DataSource = tblCreateloanReport
                    DgdGetPatronInfor.CurrentPageIndex = intPage
                    DgdGetPatronInfor.DataBind()
                End If
                tblCreateloanReport = Nothing
            End If
        End Sub

        ' Method: Dispose
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBUserLocation Is Nothing Then
                    objBUserLocation.Dispose(True)
                    objBUserLocation = Nothing
                End If
                If Not objBLoanTransaction Is Nothing Then
                    objBLoanTransaction.Dispose(True)
                    objBLoanTransaction = Nothing
                End If
            Finally
                MyBase.Dispose()
            End Try
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub
    End Class
End Namespace