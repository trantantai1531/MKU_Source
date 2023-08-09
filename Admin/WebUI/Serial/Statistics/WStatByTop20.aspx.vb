' Class: WStatByTop20
' Puspose: create statistic by top 20
' Creator: Oanhtn
' CreatedDate: 21/09/2004
' Modification history:
' Date : 05/10/2004
'       Modify by Tuanhv  
'          Works : Statistic allow Top20
'   Date: 20/04/2005
'       Modify by: Tuanhv
'           Works: View code & Update

Imports eMicLibAdmin.BusinessRules.Serial
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Circulation

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WStatByTop20
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents lblTitleChartBarItem2 As System.Web.UI.WebControls.Label
        Protected WithEvents lblTitleChartBarCopynumber2 As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBPC As New clsBPeriodicalCollection
        Private objBCommonChart As New clsBCommonChart
        Private objBLT As New clsBLoanTransaction

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                BindDataLocation()
                EventStatic()
            End If
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

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init objBPC object
            objBPC.InterfaceLanguage = Session("InterfaceLanguage")
            objBPC.DBServer = Session("DBServer")
            objBPC.ConnectionString = Session("ConnectionString")
            objBPC.Initialize()

            ' Init objBPC object
            objBLT.InterfaceLanguage = Session("InterfaceLanguage")
            objBLT.DBServer = Session("DBServer")
            objBLT.ConnectionString = Session("ConnectionString")
            objBLT.Initialize()

            ' Init objBCommonChart object
            objBCommonChart.Initialize()
        End Sub

        'Bind javascript
        Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("StatJs", "<script language = 'javascript' src = '../Js/Statistics/WStatistic.js'></script>")
        End Sub

        'BindDataLocation method
        'Purpose: Bind top 20 to dropdownload
        Sub BindDataLocation()
            Dim tblUserLocations As DataTable
            lstName.Items.Clear()
            objBLT.Simple = 1
            lstName.DataSource = objBLT.GetDisList
            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBLT.ErrorMsg, ddlLabel.Items(1).Text, objBLT.ErrorCode)

            lstName.DataTextField = "Name"
            lstName.DataValueField = "ID"
            lstName.DataBind()
            If Not lstName Is Nothing AndAlso lstName.Items.Count > 0 Then
                lstName.Items(0).Selected = True
            End If
        End Sub

        'Stastic allow regularity
        Sub EventStatic()
            Dim arrData As Object
            Dim arrLabel As Object
            Dim strImage As String
            Dim strVTitle As String
            Dim strHTitle As String
            Dim intID As Integer
            strImage = "../Images/bground.gif"
            strVTitle = ddlLabel.Items(4).Text
            strHTitle = ddlLabel.Items(3).Text & " " & CStr(lstName.SelectedItem.Text)
            intID = CInt(lstName.SelectedValue)
            ' Static on regularity
            objBPC.LibID = clsSession.GlbSite
            Call objBPC.StatByTop20(intID)
            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPC.ErrorMsg, ddlLabel.Items(1).Text, objBPC.ErrorCode)
            arrData = objBPC.arrData
            arrLabel = objBPC.arrLabel
            Img1.Visible = False
            anh2.Visible = False
            lblNostatic.Visible = True
            lblNostatic1.Visible = True
            If Not arrData Is Nothing Then
                If UBound(arrData) > -1 Then
                    Img1.Visible = True
                    anh2.Visible = True
                    Call objBCommonChart.Makebarchart(arrData, arrLabel, strVTitle, strHTitle, 45, strImage, "javascript:OpenWindow('WReportDetailInfor.aspx")
                    ' Write error
                    Call WriteErrorMssg(ddlLabel.Items(0).Text, objBCommonChart.ErrorMsg, ddlLabel.Items(1).Text, objBCommonChart.ErrorCode)
                    Session("chart1") = Nothing
                    Session("chart1") = objBCommonChart.OutPutStream
                    Dim strOutput As String = ""
                    strOutput = objBCommonChart.OutMapImg
                    strOutput = Replace(strOutput, "xLabel", "Freq")
                    strOutput = Replace(strOutput, "dataSet", "ds")
                    strOutput = Replace(strOutput, "dataSetName", "dsn")
                    strOutput = Replace(strOutput, """>", "','ReportDetailInfor',600,400,50,50)" & """>")
                    Response.Write("<MAP NAME=""map1"">" & strOutput & "</MAP>")
                    Call objBCommonChart.Makepiechart(arrData, arrLabel, strHTitle, strImage)
                    ' Write error
                    Call WriteErrorMssg(ddlLabel.Items(0).Text, objBCommonChart.ErrorMsg, ddlLabel.Items(1).Text, objBCommonChart.ErrorCode)

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
        End Sub

        ' Event: btnStatic_Click
        Private Sub btnStatic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStatic.Click
            'Staic allow chose
            Call EventStatic()
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBPC Is Nothing Then
                    objBPC.Dispose(True)
                    objBPC = Nothing
                End If
                If Not objBLT Is Nothing Then
                    objBLT.Dispose(True)
                    objBLT = Nothing
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