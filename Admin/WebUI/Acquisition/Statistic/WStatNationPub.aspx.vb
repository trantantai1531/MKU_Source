' Class: WStatNationPub
' Puspose: Create statistic by pubcountry
' Creator: Sondp
' CreatedDate: 01/04/2005
' Modification History:
'   - 14/24/2005 by oanhtn: review

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WStatNationPub
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
        Private objBS As New clsBStatistic
        Private objBCC As New clsBCommonChart

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                ' WriteLog
                Call WriteLog(42, ddlLog.Items(0).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                Call GenChart()
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: init all objects
        Private Sub Initialize()
            ' Initialize objBS object
            objBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBS.DBServer = Session("DBServer")
            objBS.ConnectionString = Session("ConnectionString")
            Call objBS.Initialize()

            ' Initialize objBCC object
            objBCC.InterfaceLanguage = Session("InterfaceLanguage")
            objBCC.DBServer = Session("DBServer")
            objBCC.ConnectionString = Session("ConnectionString")
            Call objBCC.Initialize()
        End Sub

        ' Method: BindScript
        ' Purpose: include all need js functions
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("WStatIndexJs", "<script language='javascript' src='../Js/Statistic/WStatIndex.js'></script>")

            btnClose.Attributes.Add("OnClick", "self.location.href='WStatIndex.aspx';return(false);")
        End Sub

        ' Method: GenChartDirector
        ' Purpose: generate charts here
        Private Sub GenChart()
            Dim vtitle As String
            Dim htitle As String
            Dim title As String
            Dim strImg As String
            Dim objData As Object
            Dim objLabel As Object
            Dim objDataNext As Object
            Dim objLabelNext As Object

            Try
                strImg = Server.MapPath("..\..\Images\bground.gif")
                objBS.LibID = clsSession.GlbSite
                objBS.StatNationPub(lblDAPTotal.Text, lblBAPTotal.Text)
                objData = objBS.ArrDataChart
                objLabel = objBS.ArrLabelChart
                objDataNext = objBS.ArrDataChartNext
                objLabelNext = objBS.ArrLabelChartNext
                If objLabel(0) = "NOT FOUND" And objLabelNext(0) = "NOT FOUND" Then
                    Response.Redirect("WStatEmty.aspx")
                Else
                    ' Thong ke cho dau an pham
                    If Not objLabel(0) = "NOT FOUND" Then
                        vtitle = lblDAPVTitle.Text
                        htitle = lblDAPHTitle.Text
                        title = lblDAPTitle.Text
                        lblDAP.Text = objBS.DAP
                        objBCC.Makebarchart(objData, objLabel, vtitle, htitle, 45, strImg, "WStatNationPub.aspx")
                        Session("chart1") = Nothing
                        Session("chart1") = objBCC.OutPutStream
                        objBCC.Makepiechart(objData, objLabel, title, strImg)
                        Session("chart2") = Nothing
                        Session("chart2") = objBCC.OutPutStream
                    End If
                    ' Thong ke cho ban an pham
                    If Not objLabelNext(0) = "NOT FOUND" Then
                        vtitle = lblBAPVTitle.Text
                        htitle = lblBAPHTitle.Text
                        title = lblBAPTitle.Text
                        lblBAP.Text = objBS.BAP
                        objBCC.Makebarchart(objDataNext, objLabelNext, vtitle, htitle, 45, strImg, "WStatNationPub.aspx")
                        Session("chart3") = Nothing
                        Session("chart3") = objBCC.OutPutStream
                        objBCC.Makepiechart(objDataNext, objLabelNext, title, strImg)
                        Session("chart4") = Nothing
                        Session("chart4") = objBCC.OutPutStream
                    End If
                End If
            Catch ex As Exception ' Catch errors
                Call WriteErrorMssg(ddlLog.Items(1).Text, ex.Message.Trim, ddlLog.Items(2).Text, 0)
            End Try
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBS Is Nothing Then
                objBS.Dispose(True)
                objBS = Nothing
            End If
            If Not objBCC Is Nothing Then
                objBCC.Dispose(True)
                objBCC = Nothing
            End If
        End Sub

        Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
            objBS.LibID = clsSession.GlbSite
            objBS.StatNationPub(lblDAPTotal.Text, lblBAPTotal.Text)
            If (Not objBS.ArrLabelChart(0) = "NOT FOUND") And (Not objBS.ArrLabelChartNext(0) = "NOT FOUND") Then

                Dim objData() As String = CType(objBS.ArrDataChart, String())
                Dim objLabel() As Integer = CType(objBS.ArrLabelChart, Integer())
                Dim objDataNext() As String = CType(objBS.ArrDataChartNext, String())

                Dim sBuilder1 As StringBuilder = clsBExportHelper.GenToExcel(objLabel, objData, lblDAPVTitle.Text)

                Dim sBuilder2 As StringBuilder = clsBExportHelper.GenToExcel(objLabel, objDataNext, lblBAPVTitle.Text)

                clsExport.StringBuilderToExcel(sBuilder1.Append("<br/>" & sBuilder2.ToString()))
            End If
        End Sub
    End Class
End Namespace