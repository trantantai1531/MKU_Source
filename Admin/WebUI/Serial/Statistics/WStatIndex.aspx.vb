' Class: WStatIndex
' Puspose: show statistic index page
' Creator: Oanhtn
' CreatedDate: 21/09/2004
' Modification history:
'   + 01/10/2004 by Tuanhv: repair interface form
'   + 18/04/2005 by Sondp: repaid and create method ReportInTimeRange
' Review code : Lent 20-04-2005

Imports eMicLibAdmin.BusinessRules.Serial

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WStatIndex
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lnkTotal16 As System.Web.UI.WebControls.HyperLink


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBPeriodicalCollection As New clsBPeriodicalCollection

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init objBPeriodicalCollection object
            objBPeriodicalCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBPeriodicalCollection.DBServer = Session("DBServer")
            objBPeriodicalCollection.ConnectionString = Session("ConnectionString")
            Call objBPeriodicalCollection.Initialize()
        End Sub

        ' CheckFormPermission method
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            ' Statistic Year
            If Not CheckPemission(98) Then
                ' Write error
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub

        ' Method: Bindjavascript
        Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")

            'lnkTotal1.NavigateUrl = "WReportByAcqSource.aspx?AcqSourceID=0&OnSubscription=-1"
            'lnkTotal2.NavigateUrl = "WReportByAcqSource.aspx?AcqSourceID=1&OnSubscription=-1"
            'lnkTotal21.NavigateUrl = "WReportByAcqSource.aspx?AcqSourceID=2&OnSubscription=-1"
            'lnkTotal3.NavigateUrl = "WReportByAcqSource.aspx?AcqSourceID=3&OnSubscription=-1"
            'lnkTotal4.NavigateUrl = "WReportByAcqSource.aspx?AcqSourceID=4&OnSubscription=-1"
            'lnkTotal5.NavigateUrl = "WReportByAcqSource.aspx?AcqSourceID=6&OnSubscription=-1"
            'lnkTotal6.NavigateUrl = "WReportByAcqSource.aspx?AcqSourceID=9&OnSubscription=-1"
            'lnkTotal14.NavigateUrl = "WReportByAcqSource.aspx?AcqSourceID=5&OnSubscription=-1"
            'lnkTotal15.NavigateUrl = "WReportByAcqSource.aspx?AcqSourceID=7&OnSubscription=-1"
            'lnkTotal7.NavigateUrl = "WReportByAcqSource.aspx?AcqSourceID=0&OnSubscription=1"
            'lnkTotal8.NavigateUrl = "WReportByAcqSource.aspx?AcqSourceID=0&OnSubscription=0"
            'lnkTotal9.NavigateUrl = "WReportByStatus.aspx"

            'hrfTotal13.NavigateUrl = "WReportInTimeRange.aspx"
        End Sub

        'Get and set all information of report
        Sub BindData()
            Dim tblResult As DataTable
            Dim dtResult11() As DataRow
            Dim dtResult12() As DataRow
            Dim dtResult13() As DataRow
            Dim dtResult14() As DataRow
            Dim dtResult15() As DataRow
            Dim dtResult16() As DataRow
            Dim dtResult17() As DataRow

            Dim intTotal1 As Integer
            Dim intTotal3 As Integer
            Dim intTotal11 As Integer
            Dim intTotal12 As Integer
            Dim intTotal13 As Integer
            Dim intTotal14 As Integer
            Dim intTotal15 As Integer
            Dim intTotal16 As Integer
            Dim intTotal17 As Integer

            Dim dtResult21() As DataRow
            Dim dtResult22() As DataRow
            Dim intTotal21 As Integer
            Dim intTotal22 As Integer

            Dim intTotal41 As Integer
            Dim intTotal42 As Integer
            Dim intTotal43 As Integer

            'tblResult = objBPeriodicalCollection.CreateReportByAcqSourceStatus()

            '' Write error
            'Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPeriodicalCollection.ErrorMsg, ddlLabel.Items(1).Text, objBPeriodicalCollection.ErrorCode)

            'If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
            '    'Tong so dau an pham
            '    intTotal1 = tblResult.Rows.Count
            '    lblTotal1.Text = lblTotal1.Text & "<b>" & CStr(intTotal1) & "</b>"

            '    'Tong so dau an pham mua theo hop dong
            '    dtResult11 = tblResult.Select("AcqSourceID = 1")
            '    intTotal11 = UBound(dtResult11) + 1
            '    lblTotal2.Text = lblTotal2.Text & "<b>" & CStr(intTotal11) & "</b>"

            '    'Tong so dau an pham mua le
            '    dtResult12 = tblResult.Select("AcqSourceID = 2")
            '    intTotal12 = UBound(dtResult12) + 1
            '    lblTotal21.Text = lblTotal21.Text & "<b>" & CStr(intTotal12) & "</b>"

            '    'Tong so dau an pham duoc tang
            '    dtResult12 = tblResult.Select("AcqSourceID = 3")
            '    intTotal12 = UBound(dtResult12) + 1
            '    lblTotal3.Text = lblTotal3.Text & "<b>" & CStr(intTotal12) & "</b>"

            '    'Tong so dau an pham trao doi
            '    dtResult13 = tblResult.Select("AcqSourceID = 4")
            '    intTotal13 = UBound(dtResult13) + 1
            '    lblTotal4.Text = lblTotal4.Text & "<b>" & CStr(intTotal13) & "</b>"

            '    'Tong so dau an pham luu chieu
            '    dtResult14 = tblResult.Select("AcqSourceID = 6")
            '    intTotal14 = UBound(dtResult14) + 1
            '    lblTotal5.Text = lblTotal5.Text & "<b>" & CStr(intTotal14) & "</b>"

            '    'Tong so an pham dong gop
            '    dtResult16 = tblResult.Select("AcqSourceID = 7")
            '    intTotal16 = UBound(dtResult16) + 1
            '    lblTotal15.Text = lblTotal15.Text & "<b>" & CStr(intTotal16) & "</b>"

            '    'Tong so an pham suu tam
            '    dtResult17 = tblResult.Select("AcqSourceID = 5")
            '    intTotal17 = UBound(dtResult17) + 1
            '    lblTotal14.Text = lblTotal14.Text & "<b>" & CStr(intTotal17) & "</b>"

            '    'Tong so dau an pham khac
            '    intTotal15 = intTotal1 - (intTotal11 + intTotal12 + intTotal13 + intTotal14 + intTotal16 + intTotal17 + 1)
            '    If intTotal15 < 0 Then
            '        intTotal15 = 0
            '    End If
            '    lblTotal6.Text = lblTotal6.Text & "<b>" & CStr(intTotal15) & "</b>"

            '    dtResult21 = tblResult.Select("OnSubscription = 1")
            '    intTotal21 = UBound(dtResult21) + 1
            '    lblTotal7.Text = lblTotal7.Text & "<b>" & CStr(intTotal21) & "</b>"

            '    dtResult22 = tblResult.Select("OnSubscription = 0")
            '    intTotal22 = UBound(dtResult22) + 1
            '    lblTotal8.Text = lblTotal8.Text & "<b>" & CStr(intTotal22) & "</b>"
            '    tblResult = Nothing
            'End If

            'tblResult = objBPeriodicalCollection.GetTotalExpired

            '' Write error
            'Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPeriodicalCollection.ErrorMsg, ddlLabel.Items(1).Text, objBPeriodicalCollection.ErrorCode)

            'If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
            '    intTotal3 = CInt(tblResult.Rows(0).Item(0))
            '    lblTotal9.Text = lblTotal9.Text & "<b>" & CStr(intTotal3) & "</b>"
            '    tblResult = Nothing
            'End If

            'Call objBPeriodicalCollection.GetTotalIssue(intTotal41, intTotal42, intTotal43)

            '' Write error
            'Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPeriodicalCollection.ErrorMsg, ddlLabel.Items(1).Text, objBPeriodicalCollection.ErrorCode)

            'lblTotal10.Text = lblTotal10.Text & "<b>" & CStr(intTotal41) & "</b>"
            'lblTotal11.Text = lblTotal11.Text & "<b>" & CStr(intTotal42) & "</b>"
            'lblTotal12.Text = lblTotal12.Text & "<b>" & CStr(intTotal43) & "</b>"
        End Sub

        'Private Sub imgStatByGeneralClassification_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgStatByGeneralClassification.Click
        '    Response.Redirect("WStatByGeneralClassification.aspx")
        'End Sub

        'Private Sub imgStatByLocation_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgStatByLocation.Click
        '    Response.Redirect("WStatByLocation.aspx")
        'End Sub


        'Private Sub imgStatByCategory_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgStatByCategory.Click
        '    Response.Redirect("WStatByCategory.aspx")
        'End Sub

        'Private Sub imgStatByRegularity_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgStatByRegularity.Click
        '    Response.Redirect("WStatByRegularity.aspx")
        'End Sub

        'Private Sub imgStatCountry_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgStatCountry.Click
        '    Response.Redirect("WStatCountry.aspx")
        'End Sub

        'Private Sub imgStatisticPolicy_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgStatisticPolicy.Click
        '    Response.Redirect("WStatLanguage.aspx")
        'End Sub

        'Private Sub imgStatClassification_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgStatClassification.Click
        '    Response.Redirect("WStatClassification.aspx")
        'End Sub

        'Private Sub imgStatisticTop20_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgStatisticTop20.Click
        '    Response.Redirect("WStatByTop20.aspx")
        'End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBPeriodicalCollection Is Nothing Then
                    objBPeriodicalCollection.Dispose(True)
                    objBPeriodicalCollection = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace