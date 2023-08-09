' Class: WstatCountry
' Puspose: create statistic by country publicer
' Creator: Tuanhv
' Modify history
'    Modify by Tuanhv  
'    Date : 05/10/2004
'           Add: Method EventStatic 
'    Method works : Statistic allow country

Imports eMicLibAdmin.BusinessRules.Serial
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WstatCountry
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
        Private objBPeriodicalCollection As New clsBPeriodicalCollection
        Private objBCommonChart As New clsBCommonChart

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindScript()
            Call ShowStat()
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
            ' Init objBPeriodicalCollection object
            objBPeriodicalCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBPeriodicalCollection.DBServer = Session("DBServer")
            objBPeriodicalCollection.ConnectionString = Session("ConnectionString")
            objBPeriodicalCollection.Initialize()

            ' Init objBCommonChart object
            objBCommonChart.Initialize()

        End Sub

        'Bind javascript
        Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("StatJs", "<script language = 'javascript' src = '../Js/Statistics/WStatistic.js'></script>")
        End Sub

        ' ShowStat method
        ' Purpose: show stattistic by country
        Sub ShowStat()
            'Declare varable using in sub
            Dim arrData As Object
            Dim arrLabel As Object
            Dim strImage As String
            Dim strVTitle As String
            Dim strHTitle As String

            Try
                strImage = Server.MapPath("../Images/bground.gif")
                strVTitle = ddlLabel.Items(4).Text
                strHTitle = ddlLabel.Items(3).Text

                ' Static by country
                objBPeriodicalCollection.LibID = clsSession.GlbSite
                Call objBPeriodicalCollection.StatByCountry(ddlLabel.Items(5).Text)
                arrData = objBPeriodicalCollection.arrData
                arrLabel = objBPeriodicalCollection.arrLabel
                anh1.Visible = False
                anh2.Visible = False
                lblNostatic.Visible = True
                lblNostatic1.Visible = True
                If Not arrData Is Nothing Then
                    If UBound(arrData) > -1 Then
                        anh1.Visible = True
                        anh2.Visible = True
                        Call objBCommonChart.Makebarchart(arrData, arrLabel, strVTitle, strHTitle, 45, strImage, "javascript:OpenWindow('WReportDetailInfor.aspx")
                        Session("chart1") = Nothing
                        Session("chart1") = objBCommonChart.OutPutStream
                        Dim strOutput As String = ""
                        strOutput = objBCommonChart.OutMapImg
                        strOutput = Replace(strOutput, "xLabel", "Country")
                        strOutput = Replace(strOutput, "dataSet", "ds")
                        strOutput = Replace(strOutput, "dataSetName", "dsn")
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