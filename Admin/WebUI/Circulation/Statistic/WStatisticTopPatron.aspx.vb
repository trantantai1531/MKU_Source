' class  WStatisticPatronGroup
' Puspose: Static allow patron group
' Creator: Tuanhv
' CreatedDate: 06/09/2004
' Modification History:
'   + 17/04/2005 by Sondp: update and review

Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WStatisticTopPatron
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblErrInput As System.Web.UI.WebControls.Label
        Protected WithEvents lblTitleChartBarItem2 As System.Web.UI.WebControls.Label
        Protected WithEvents lblTitleChartBarCopynumber2 As System.Web.UI.WebControls.Label
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents lblGroupName As System.Web.UI.WebControls.Label
        Protected WithEvents lblTotalLoan As System.Web.UI.WebControls.Label
        Protected WithEvents lblLevel As System.Web.UI.WebControls.Label
        Protected WithEvents rbtLibLevel As System.Web.UI.WebControls.RadioButton
        Protected WithEvents rbtLocLevel As System.Web.UI.WebControls.RadioButton
        Protected WithEvents lblLibs As System.Web.UI.WebControls.Label
        Protected WithEvents lstLib As System.Web.UI.WebControls.ListBox
        Protected WithEvents lblLevelStatic As System.Web.UI.WebControls.Label
        Protected WithEvents lblErrInputNum As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBCommonChart As New clsBCommonChart
        Private objBLoanTransaction As New clsBLoanTransaction

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            Call BindStatic()
        End Sub

        ' Initialize method
        Private Sub Initialize()
            'Init objBCommonChart
            objBCommonChart.ConnectionString = Session("ConnectionString")
            objBCommonChart.DBServer = Session("DBServer")
            objBCommonChart.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCommonChart.Initialize()

            'Init clsBLoanTransaction
            objBLoanTransaction.ConnectionString = Session("ConnectionString")
            objBLoanTransaction.DBServer = Session("DBServer")
            objBLoanTransaction.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBLoanTransaction.Initialize()
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            If Not CheckPemission(67) Then
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub

        ' BindJS method
        ' Purpose: Bind javascript
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("StatJs", "<script language = 'javascript' src = '../Js/Statistic/WStatistic.js'></script>")

            Me.SetCheckNumber(txtMin, ddlLabel.Items(3).Text, "1")
            Me.SetCheckNumber(txtTopNum, ddlLabel.Items(3).Text, "50")

            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkCheckOutDateFrom, txtCheckOutDateFrom, ddlLabel.Items(5).Text)
            SetOnclickCalendar(lnkCheckOutDateTo, txtCheckOutDateTo, ddlLabel.Items(5).Text)
        End Sub

        ' BindStatic method
        Private Sub BindStatic()
            Try
                Dim arrData As Object
                Dim arrLabel As Object
                Dim strImage As String
                Dim strVTitle As String
                Dim strHTitle As String
                Dim intLstCount As Integer
                Dim intOptLib As Integer
                Dim strCheckOutDateFrom As String
                Dim strCheckOutDateTo As String
                Dim intTopNum As Integer
                Dim intMinLoan As Integer
                If RbtItem.Checked = True Then
                    objBLoanTransaction.OptItemID = 0
                Else
                    objBLoanTransaction.OptItemID = 1
                End If

                objBLoanTransaction.UserID = Session("UserID")
                strImage = "../Images/bground.gif"
                strVTitle = ddlLabel.Items(6).Text
                strHTitle = ddlLabel.Items(4).Text

                ' Static on loan
                strCheckOutDateFrom = Trim(txtCheckOutDateFrom.Text)
                strCheckOutDateTo = Trim(txtCheckOutDateTo.Text)
                intTopNum = CInt(Trim(txtTopNum.Text))
                intMinLoan = CInt(Trim(txtMin.Text))
                objBLoanTransaction.CreateTopPatrolStatistic(strCheckOutDateFrom, strCheckOutDateTo, intTopNum, intMinLoan)
                arrData = objBLoanTransaction.arrData
                arrLabel = objBLoanTransaction.arrLabel
                image1.Visible = False
                image2.Visible = False
                hidHave.Value = 0
                lblNostatic.Visible = True
                lblNostatic1.Visible = True

                If Not arrData Is Nothing Then
                    If UBound(arrData) > -1 Then
                        image1.Visible = True
                        image2.Visible = True
                        Call objBCommonChart.Makebarchart(arrData, arrLabel, strVTitle, strHTitle, 45, strImage, "javascript:OpenWindow('../WPatronDetail.aspx")
                        Session("chart1") = Nothing
                        Session("chart1") = objBCommonChart.OutPutStream
                        Dim strOutput As String = ""
                        strOutput = objBCommonChart.OutMapImg
                        strOutput = Replace(strOutput, "xLabel", "PatronCode")
                        strOutput = Replace(strOutput, "dataSet", "ds")
                        strOutput = Replace(strOutput, "dataSetName", "dsn")
                        Dim arrAuput() As String
                        strOutput = Replace(strOutput, """>", "','PatronDetail',600,400,50,50)" & """>")
                        Response.Write("<MAP NAME=""map1"">" & strOutput & "</MAP>")
                        Call objBCommonChart.Makepiechart(arrData, arrLabel, strHTitle, strImage)
                        Session("chart2") = Nothing
                        Session("chart2") = objBCommonChart.OutPutStream
                        hidHave.Value = 1
                        lblNostatic.Visible = False
                        lblNostatic1.Visible = False
                    Else
                        Session("chart1") = Nothing
                        Session("chart2") = Nothing
                    End If
                Else
                    Session("chart1") = Nothing
                    Session("chart2") = Nothing
                End If
            Catch
            End Try
        End Sub

        ' Event: btnCancel_Click
        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            txtCheckOutDateFrom.Text = ""
            txtCheckOutDateTo.Text = ""
        End Sub

        ' Page_Unload event
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
                If Not objBLoanTransaction Is Nothing Then
                    objBLoanTransaction.Dispose(True)
                    objBLoanTransaction = Nothing
                End If
            Finally
                MyBase.Dispose()
            End Try
        End Sub

        Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
            Try
                Dim strTitle As String = lblTitle.Text
                Dim strCheckOutDateFrom As String
                Dim strCheckOutDateTo As String
                Dim intTopNum As Integer
                Dim intMinLoan As Integer
                If RbtItem.Checked = True Then
                    objBLoanTransaction.OptItemID = 0
                    strTitle = strTitle & " " & RbtItem.Text
                Else
                    objBLoanTransaction.OptItemID = 1
                    strTitle = strTitle & " " & RbtCopynumber.Text
                End If

                objBLoanTransaction.UserID = Session("UserID")

                ' Static on loan
                strCheckOutDateFrom = Trim(txtCheckOutDateFrom.Text)
                strCheckOutDateTo = Trim(txtCheckOutDateTo.Text)
                intTopNum = CInt(Trim(txtTopNum.Text))
                intMinLoan = CInt(Trim(txtMin.Text))
                objBLoanTransaction.CreateTopPatrolStatistic(strCheckOutDateFrom, strCheckOutDateTo, intTopNum, intMinLoan)

                Dim sBuilder As StringBuilder = clsBExportHelper.GenToExcel(objBLoanTransaction.arrLabel, objBLoanTransaction.arrData, strTitle)

                clsExport.StringBuilderToExcel(sBuilder)
            Catch ex As Exception

            End Try
        End Sub
    End Class
End Namespace