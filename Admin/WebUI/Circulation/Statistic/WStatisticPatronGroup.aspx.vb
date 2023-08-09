' class  WStatisticPatronGroup
' Puspose: Static allow patron group
' Creator: Tuanhv
' CreatedDate: 06/09/2004
' Modification History:

Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WStatisticPatronGroup
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
        Private objBCommonChart As New clsBCommonChart
        Private objBLoanTransaction As New clsBLoanTransaction

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindScript()
            Call BindStatic()
        End Sub

        ' Initialize method
        ' Purpose: Init all necessary objects now
        Private Sub Initialize()
            ' Init clsBLoanTransaction object
            objBLoanTransaction.ConnectionString = Session("ConnectionString")
            objBLoanTransaction.DBServer = Session("DBServer")
            objBLoanTransaction.InterfaceLanguage = Session("InterfaceLanguage")
            objBLoanTransaction.Initialize()

            ' Init objBCommonChart object
            objBCommonChart.ConnectionString = Session("ConnectionString")
            objBCommonChart.DBServer = Session("DBServer")
            objBCommonChart.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonChart.Initialize()
        End Sub

        ' BindScript method
        ' Purpose: Bind javascript
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("StatJs", "<script language = 'javascript' src = '../Js/Statistic/WStatistic.js'></script>")

            txtCheckOutDateFrom.Attributes.Add("onChange", "javascript:CheckDate(this,'" & Session("DateFormat") & "','" & ddlLabel.Items(5).Text & " (" & Session("DateFormat") & ")');")
            txtCheckOutDateFrom.ToolTip = Session("DateFormat")
            txtCheckOutDateTo.Attributes.Add("onChange", "javascript:CheckDate(this,'" & Session("DateFormat") & "','" & ddlLabel.Items(5).Text & " (" & Session("DateFormat") & ")');")
            txtCheckOutDateTo.ToolTip = Session("DateFormat")
            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkCheckOutDateFrom, txtCheckOutDateFrom, ddlLabel.Items(5).Text)
            SetOnclickCalendar(lnkCheckOutDateTo, txtCheckOutDateTo, ddlLabel.Items(5).Text)
        End Sub

        ' CheckFormPermission method
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            If Not CheckPemission(67) Then
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub

        ' BindStatic method
        ' Purpose: stattistic now
        Private Sub BindStatic()
            Dim arrData As Object
            Dim arrLabel As Object
            Dim strImage As String
            Dim strVTitle As String
            Dim strHTitle As String
            strImage = Server.MapPath("../Images/bground.gif")
            strVTitle = ddlLabel.Items(7).Text
            strHTitle = ddlLabel.Items(6).Text
            If rdoItems.Checked = True Then
                objBLoanTransaction.OptItemID = 0
            Else
                objBLoanTransaction.OptItemID = 1
                lblOnLoanItems.Text = ddlLabel.Items(3).Text
                lblLoanItems.Text = ddlLabel.Items(4).Text
            End If
            objBLoanTransaction.UserID = Session("UserID")

            ' Static on loan
            objBLoanTransaction.History = 0
            objBLoanTransaction.CreatePatronGroupStatistic(Trim(txtCheckOutDateFrom.Text), Trim(txtCheckOutDateTo.Text))
            arrData = objBLoanTransaction.arrData
            arrLabel = objBLoanTransaction.arrLabel
            image1.Visible = False
            image2.Visible = False
            hidHave.Value = 0
            hidHave1.Value = 0
            lblNostatic.Visible = True
            lblNostatic1.Visible = True
            lblNostatic2.Visible = True
            lblNostatic3.Visible = True

            If Not arrData Is Nothing Then
                If UBound(arrData) > -1 Then
                    image1.Visible = True
                    image2.Visible = True
                    Call objBCommonChart.Makebarchart(arrData, arrLabel, strVTitle, strHTitle, 45, strImage, "")
                    Session("chart1") = Nothing
                    Session("chart1") = objBCommonChart.OutPutStream

                    Call objBCommonChart.Makepiechart(arrData, arrLabel, strHTitle, strImage)
                    Session("chart2") = Nothing
                    Session("chart2") = objBCommonChart.OutPutStream
                    hidHave.Value = 1
                    lblNostatic.Visible = False
                    lblNostatic1.Visible = False
                    arrData = Nothing
                    arrLabel = Nothing
                Else
                    Session("chart1") = Nothing
                    Session("chart2") = Nothing
                    'lblOnLoanItems.Text = lblOnLoanItems.Text & ": 0"
                End If
            Else
                Session("chart1") = Nothing
                Session("chart2") = Nothing
                'lblOnLoanItems.Text = lblOnLoanItems.Text & ": 0"
            End If
            ' Static loaned 
            objBLoanTransaction.History = 1
            objBLoanTransaction.CreatePatronGroupStatistic(Trim(txtCheckOutDateFrom.Text), Trim(txtCheckOutDateTo.Text))
            arrData = objBLoanTransaction.arrData
            arrLabel = objBLoanTransaction.arrLabel
            image3.Visible = False
            image4.Visible = False
            If Not arrData Is Nothing Then
                If UBound(arrData) > -1 Then
                    image3.Visible = True
                    image4.Visible = True
                    Call objBCommonChart.Makebarchart(arrData, arrLabel, strVTitle, strHTitle, 45, strImage, "")
                    Session("chart3") = Nothing
                    Session("chart3") = objBCommonChart.OutPutStream

                    Call objBCommonChart.Makepiechart(arrData, arrLabel, strHTitle, strImage)
                    Session("chart4") = Nothing
                    Session("chart4") = objBCommonChart.OutPutStream
                    hidHave1.Value = 1
                    lblNostatic2.Visible = False
                    lblNostatic3.Visible = False
                    arrData = Nothing
                    arrLabel = Nothing
                Else
                    Session("chart3") = Nothing
                    Session("chart4") = Nothing
                    'lblLoanItems.Text = lblLoanItems.Text & ": 0"
                End If
            Else

                Session("chart3") = Nothing
                Session("chart4") = Nothing
                'lblLoanItems.Text = lblLoanItems.Text & ": 0"
            End If
        End Sub

        ' btnCancel_Click event
        ' Purpose: reset form
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
                Dim strTitle As String = ""
                If rdoItems.Checked = True Then
                    objBLoanTransaction.OptItemID = 0
                    strTitle = rdoItems.Text
                Else
                    objBLoanTransaction.OptItemID = 1
                    strTitle = rdoCopynumber.Text
                End If
                objBLoanTransaction.UserID = Session("UserID")

                ' Static on loan
                objBLoanTransaction.History = 0
                objBLoanTransaction.CreatePatronGroupStatistic(Trim(txtCheckOutDateFrom.Text), Trim(txtCheckOutDateTo.Text))

                Dim sBuilder1 As StringBuilder = clsBExportHelper.GenToExcel(objBLoanTransaction.arrLabel, objBLoanTransaction.arrData, strTitle & " " & lblStringBuilder1.Text)


                objBLoanTransaction.History = 1
                objBLoanTransaction.CreatePatronGroupStatistic(Trim(txtCheckOutDateFrom.Text), Trim(txtCheckOutDateTo.Text))

                Dim sBuilder2 As StringBuilder = clsBExportHelper.GenToExcel(objBLoanTransaction.arrLabel, objBLoanTransaction.arrData, strTitle & " " & lblStringBuilder2.Text)

                clsExport.StringBuilderToExcel(sBuilder1.Append("<br/>" & sBuilder2.ToString()))
            Catch ex As Exception

            End Try
        End Sub
    End Class
End Namespace