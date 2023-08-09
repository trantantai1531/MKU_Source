Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.Edeliv
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WStatYear
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
        Private objBRequestCollection As New clsBERequestCollection
        Private objBCommonChart As New clsBCommonChart

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPemission()
            Call Initialize()
            Call BindScript()
            Call DrawYearStat()
            ' WriteLog
            Call WriteLog(76, ddlLabel.Items(10).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
        End Sub

        ' CheckFormPemission method
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            If Not CheckPemission(163) Then
                Call WriteErrorMssg(ddlLabel.Items(7).Text)
            End If
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/Statistic/WStatYear.js'></script>")
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBCommonChart object
            objBCommonChart.ConnectionString = Session("ConnectionString")
            objBCommonChart.DBServer = Session("DBServer")
            objBCommonChart.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonChart.Initialize()

            ' Init objBRequestCollection object
            objBRequestCollection.ConnectionString = Session("ConnectionString")
            objBRequestCollection.DBServer = Session("DBServer")
            objBRequestCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBRequestCollection.Initialize()
        End Sub

        ' DrawYearStat
        Private Sub DrawYearStat()
            Dim arrData As Object
            Dim arrLabel As Object
            Dim strImage As String
            Dim strVTitle1 As String
            Dim strVTitle2 As String
            Dim strHTitle1 As String
            Dim strHTitle2 As String
            Dim strTitle1 As String
            Dim strTitle2 As String
            Dim strTitle3 As String

            ' ***************** Get the request's annual static **************
            Dim intYear As Integer
            strImage = Server.MapPath("..\..\Images\bground.gif")

            strHTitle1 = ddlLabel.Items(6).Text
            strVTitle1 = ddlLabel.Items(3).Text
            strVTitle2 = ddlLabel.Items(4).Text
            strHTitle2 = ddlLabel.Items(5).Text

            strTitle1 = ddlLabel.Items(0).Text
            strTitle2 = ddlLabel.Items(1).Text
            strTitle3 = ddlLabel.Items(2).Text

            ' Get the selected request's annual static (Type 1)
            arrData = Nothing
            arrLabel = Nothing
            objBRequestCollection.CreateAnnualStat(0)
            Call WriteErrorMssg(ddlLabel.Items(9).Text, objBRequestCollection.ErrorMsg, ddlLabel.Items(8).Text, objBRequestCollection.ErrorCode)

            arrData = objBRequestCollection.arrData
            arrLabel = objBRequestCollection.arrLabel
            chart1.Visible = False
            chart2.Visible = False
            If Not arrData Is Nothing Then
                If UBound(arrData) > -1 Then
                    Try
                        chart1.Visible = True
                        chart2.Visible = True
                        Call objBCommonChart.Makebarchart(arrData, arrLabel, strVTitle1, strHTitle1, 1, strImage, "WStatMonth.aspx", "")
                        Call WriteErrorMssg(ddlLabel.Items(9).Text, objBCommonChart.ErrorMsg, ddlLabel.Items(8).Text, objBCommonChart.ErrorCode)

                        Session("chart1") = Nothing
                        Session("chart1") = objBCommonChart.OutPutStream

                        Dim strOutput As String
                        strOutput = objBCommonChart.OutMapImg
                        strOutput = Replace(strOutput, "xLabel", "Year")

                        Response.Write("<MAP NAME=""map1"">" & strOutput & "</MAP>")

                        Call objBCommonChart.Makepiechart(arrData, arrLabel, strTitle1, strImage)
                        Call WriteErrorMssg(ddlLabel.Items(9).Text, objBCommonChart.ErrorMsg, ddlLabel.Items(8).Text, objBCommonChart.ErrorCode)
                        Session("chart2") = Nothing
                        Session("chart2") = objBCommonChart.OutPutStream
                    Catch
                    End Try
                Else
                    Session("chart1") = Nothing
                    Session("chart2") = Nothing

                End If
            Else
                Session("chart1") = Nothing
                Session("chart2") = Nothing
            End If

            ' Get the request's annual static (Type 2)
            arrData = Nothing
            arrLabel = Nothing
            objBRequestCollection.CreateAnnualStat(1)
            Call WriteErrorMssg(ddlLabel.Items(9).Text, objBRequestCollection.ErrorMsg, ddlLabel.Items(8).Text, objBRequestCollection.ErrorCode)

            arrData = objBRequestCollection.arrData
            arrLabel = objBRequestCollection.arrLabel
            chart3.Visible = False
            chart4.Visible = False
            If Not arrData Is Nothing Then
                If UBound(arrData) > -1 Then
                    Try
                        chart3.Visible = True
                        chart4.Visible = True
                        Call objBCommonChart.Makebarchart(arrData, arrLabel, strVTitle2, strHTitle1, 1, strImage, "WStatMonth.aspx", "")
                        Call WriteErrorMssg(ddlLabel.Items(9).Text, objBCommonChart.ErrorMsg, ddlLabel.Items(8).Text, objBCommonChart.ErrorCode)

                        Session("chart3") = Nothing
                        Session("chart3") = objBCommonChart.OutPutStream

                        Dim strOutput As String
                        strOutput = objBCommonChart.OutMapImg
                        strOutput = Replace(strOutput, "xLabel", "Year")

                        Response.Write("<MAP NAME=""map3"">" & strOutput & "</MAP>")

                        Call objBCommonChart.Makepiechart(arrData, arrLabel, strTitle2, strImage)
                        Call WriteErrorMssg(ddlLabel.Items(9).Text, objBCommonChart.ErrorMsg, ddlLabel.Items(8).Text, objBCommonChart.ErrorCode)
                        Session("chart4") = Nothing
                        Session("chart4") = objBCommonChart.OutPutStream
                    Catch
                    End Try
                Else
                    Session("chart3") = Nothing
                    Session("chart4") = Nothing

                End If
            Else
                Session("chart3") = Nothing
                Session("chart4") = Nothing
            End If

            ' Get the request's annual static (Type 3)
            arrData = Nothing
            arrLabel = Nothing
            objBRequestCollection.CreateAnnualStat(2)
            Call WriteErrorMssg(ddlLabel.Items(9).Text, objBRequestCollection.ErrorMsg, ddlLabel.Items(8).Text, objBRequestCollection.ErrorCode)

            arrData = objBRequestCollection.arrData
            arrLabel = objBRequestCollection.arrLabel
            chart5.Visible = False
            chart6.Visible = False
            If Not arrData Is Nothing Then
                If UBound(arrData) > -1 Then
                    Try
                        chart5.Visible = True
                        chart6.Visible = True
                        Call objBCommonChart.Makebarchart(arrData, arrLabel, strVTitle1, strHTitle2, 15, strImage, "", "")
                        Call WriteErrorMssg(ddlLabel.Items(9).Text, objBCommonChart.ErrorMsg, ddlLabel.Items(8).Text, objBCommonChart.ErrorCode)

                        Session("chart5") = Nothing
                        Session("chart5") = objBCommonChart.OutPutStream

                        Dim strOutput As String
                        strOutput = objBCommonChart.OutMapImg
                        strOutput = Replace(strOutput, "xLabel", "Year")

                        Response.Write("<MAP NAME=""map5"">" & strOutput & "</MAP>")

                        Call objBCommonChart.Makepiechart(arrData, arrLabel, strTitle3, strImage)
                        Call WriteErrorMssg(ddlLabel.Items(9).Text, objBCommonChart.ErrorMsg, ddlLabel.Items(8).Text, objBCommonChart.ErrorCode)
                        Session("chart6") = Nothing
                        Session("chart6") = objBCommonChart.OutPutStream
                    Catch
                    End Try
                Else
                    Session("chart5") = Nothing
                    Session("chart6") = Nothing

                End If
            Else
                Session("chart5") = Nothing
                Session("chart6") = Nothing
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
                If Not objBCommonChart Is Nothing Then
                    objBCommonChart.Dispose(True)
                    objBCommonChart = Nothing
                End If
                If Not objBRequestCollection Is Nothing Then
                    objBRequestCollection.Dispose(True)
                    objBRequestCollection = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class

End Namespace
