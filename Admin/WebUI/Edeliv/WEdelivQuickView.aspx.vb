Imports eMicLibAdmin.BusinessRules.Edeliv
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WEdelivQuickView
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
        Dim objBEdata As New clsBEData

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
            'Call CreateStatistic()
        End Sub

        ' Initialize method
        Private Sub Initialize()
            Response.Expires = 0

            ' Init objBCommonChart object
            objBCommonChart.ConnectionString = Session("ConnectionString")
            objBCommonChart.DBServer = Session("DBServer")
            objBCommonChart.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCommonChart.Initialize()

            ' Init objBEdata object
            objBEdata.ConnectionString = Session("ConnectionString")
            objBEdata.DBServer = Session("DBServer")
            objBEdata.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBEdata.Initialize()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = 'Js/WMainMenu.js'></script>")

            lnkCustomer.Attributes.Add("OnClick", "OpenCustomer();")
            lnkFinance.Attributes.Add("OnClick", "OpenAccount();")
            lnkRequest.Attributes.Add("OnClick", "OpenRequest();")
            lnkStat.Attributes.Add("OnClick", "OpenStatistic();")
            lnkTool.Attributes.Add("OnClick", "OpenTool();")
            lnkEdata.Attributes.Add("OnClick", "OpenEdata();")
        End Sub

        ' CreateStatistic method
        ' Purpose: show statistic
        Private Sub CreateStatistic()
            Dim tblTemp As DataTable
            Dim intMax As Integer
            Dim arrData()
            Dim arrLabel()
            Dim intCount As Integer
            Dim strImage As String = Server.MapPath("../Images/bground.gif")
            Dim strVTitle As String = ""
            Dim strHTitle As String = ""
            Dim blnNotFound As Boolean = False

            ' For statistic informations
            Dim lngFreeCount As Long
            Dim lngChargeCount As Long
            Dim lngReqNum As Long
            Dim lngUserCount As Long
            Dim lngAccessNum As Long

            tblTemp = objBEdata.GetDisplayTypes(3, -1)

            ' Write Error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBEdata.ErrorMsg, ddlLabel.Items(1).Text, objBEdata.ErrorCode)
            anh1.Visible = False
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                intMax = tblTemp.Rows.Count
                ReDim arrLabel(intMax - 1)
                ReDim arrData(intMax - 1)

                For intCount = 0 To intMax - 1
                    Select Case tblTemp.Rows(intCount).Item("MediaType")
                        Case 1
                            arrLabel(intCount) = ddlLabel.Items(2).Text
                        Case 2
                            arrLabel(intCount) = ddlLabel.Items(3).Text
                        Case 3
                            arrLabel(intCount) = ddlLabel.Items(4).Text
                        Case 4
                            arrLabel(intCount) = ddlLabel.Items(5).Text
                        Case 5
                            arrLabel(intCount) = ddlLabel.Items(6).Text
                        Case 6
                            arrLabel(intCount) = ddlLabel.Items(7).Text
                        Case 7
                            arrLabel(intCount) = ddlLabel.Items(8).Text
                    End Select
                    arrData(intCount) = CInt(tblTemp.Rows(intCount).Item("NOR"))
                Next

                intMax = tblTemp.Rows.Count
                hidControl.Value = 1
                anh1.Visible = True
                Call objBCommonChart.Makebarchart(arrData, arrLabel, strVTitle, strHTitle, 45, strImage, "WEdelivQuickView.aspx", "", 1)
                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBCommonChart.ErrorMsg, ddlLabel.Items(1).Text, objBCommonChart.ErrorCode)

                Session("chart1") = Nothing
                Session("chart1") = objBCommonChart.OutPutStream

                Call objBEdata.GetEdataStatistic(lngFreeCount, lngChargeCount, lngReqNum, lngUserCount, lngAccessNum)

                lblFreeCount.Text = lblFreeCount.Text & " " & lngFreeCount.ToString
                lblChargeCount.Text = lblChargeCount.Text & " " & lngChargeCount.ToString
                lblNumOfReq.Text = lblNumOfReq.Text & " " & lngReqNum.ToString
                lblNumOfAcc.Text = lblNumOfAcc.Text & " " & lngUserCount.ToString
                lblDownLoadTime.Text = lblDownLoadTime.Text & " " & lngAccessNum.ToString

                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBEdata.ErrorMsg, ddlLabel.Items(1).Text, objBEdata.ErrorCode)
            End If
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBEdata Is Nothing Then
                    objBEdata.Dispose(True)
                    objBEdata = Nothing
                End If
                If Not objBCommonChart Is Nothing Then
                    objBCommonChart.Dispose(True)
                    objBCommonChart = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

    End Class
End Namespace
