Imports eMicLibAdmin.BusinessRules.Serial
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WSerialQuickView
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

        Dim objBCommonChart As New clsBCommonChart
        Private objBPeriodicalCollection As New clsBPeriodicalCollection

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call CreateStatistic()
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            Response.Expires = 0

            ' Init objBCommonChart object
            Call objBCommonChart.Initialize()

            ' Init objBPeriodicalCollection object
            objBPeriodicalCollection.ConnectionString = Session("ConnectionString")
            objBPeriodicalCollection.DBServer = Session("DBServer")
            objBPeriodicalCollection.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPeriodicalCollection.Initialize()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = 'Js/WMainMenu.js'></script>")

            lnkAcq.Attributes.Add("OnClick", "OpenAcquisition();")
            lnkClaim.Attributes.Add("OnClick", "OpenClaim();")
            lnkContentTable.Attributes.Add("OnClick", "OpenArticle();")
            lnkIndex.Attributes.Add("OnClick", "OpenSearch();")
            lnkStat.Attributes.Add("OnClick", "OpenStatistic();")

        End Sub

        ' CreateStatistic method
        ' Purpose: show statistic
        Private Sub CreateStatistic()
            'Declare variable using in sub
            Dim strImage As String = Server.MapPath("../Images/bground.gif")

            ' Static on stat by category
            Call objBPeriodicalCollection.StatByCategory()

            ' Write error
            Call WriteErrorMssg(ddlLog.Items(0).Text, objBPeriodicalCollection.ErrorMsg, ddlLog.Items(1).Text, objBPeriodicalCollection.ErrorCode)

            anh1.Visible = False
            lblStatCat.Visible = False
            If Not objBPeriodicalCollection.arrData Is Nothing Then
                If UBound(objBPeriodicalCollection.arrData) > -1 Then
                    anh1.Visible = True
                    lblStatCat.Visible = True
                    hidControl.Value = 1
                    Call objBCommonChart.Makebarchart(objBPeriodicalCollection.arrData, objBPeriodicalCollection.arrLabel, "", "", 45, strImage, "WSerialQuickView.aspx", "", 1)
                    ' Write error
                    Call WriteErrorMssg(ddlLog.Items(0).Text, objBCommonChart.ErrorMsg, ddlLog.Items(1).Text, objBCommonChart.ErrorCode)

                    Session("chart1") = Nothing
                    Session("chart1") = objBCommonChart.OutPutStream
                End If
            End If

            Dim tblResult As DataTable
            Dim intTotal1 As Integer = 0
            Dim intTotal2 As Integer = 0
            Dim intTotal3 As Integer = 0
            Dim intTotal4 As Integer = 0

            tblResult = objBPeriodicalCollection.CreateReportByAcqSourceStatus()
            ' Write error
            Call WriteErrorMssg(ddlLog.Items(0).Text, objBPeriodicalCollection.ErrorMsg, ddlLog.Items(1).Text, objBPeriodicalCollection.ErrorCode)

            If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                intTotal1 = tblResult.Rows.Count
            End If

            Call objBPeriodicalCollection.GetTotalIssue(intTotal2, intTotal3, intTotal4)

            ' Write error
            Call WriteErrorMssg(ddlLog.Items(0).Text, objBPeriodicalCollection.ErrorMsg, ddlLog.Items(1).Text, objBPeriodicalCollection.ErrorCode)

            lblTitleTotal.Text &= Space(1) & "<b>" & FormatNumber(intTotal1, 0) & "</b>"
            lblVolumeTotal.Text &= Space(1) & "<b>" & FormatNumber(intTotal2, 0) & "</b>"
            lblIssueTotal.Text &= Space(1) & "<b>" & FormatNumber(intTotal3, 0) & "</b>"
            lblItemTotal.Text &= Space(1) & "<b>" & FormatNumber(intTotal4, 0) & "</b>"
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCommonChart Is Nothing Then
                    objBCommonChart.Dispose(True)
                    objBCommonChart = Nothing
                End If
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
