' Class: WStatLocation
' Puspose: Create statistic by location
' Creator: Sondp
' CreatedDate: 15/02/2005 
' Modification History:
'   - 13/04/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WStatLocation
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents tblLocation As System.Web.UI.HtmlControls.HtmlTable


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
        ' Purpose: init all need objects
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

        ' BindScript method
        ' Purpose: include need js functions
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("WStatIndexJs", "<script language='javascript' src='../Js/Statistic/WStatIndex.js'></script>")
        End Sub

        ' Method: GenChart
        ' Purpose: generate charts now
        Private Sub GenChart()
            Dim vtitle As String
            Dim htitle As String
            Dim title As String
            Dim strImg As String
            Dim objData As Object
            Dim objLabel As Object
            Dim intLocID As Integer

            strImg = Server.MapPath("..\..\Images\bground.gif")
            If Request.QueryString("LocID") & "" = "" Then
                intLocID = 0
            Else
                intLocID = CInt(Request.QueryString("LocID"))
            End If
            Session("chart1") = Nothing
            Session("chart2") = Nothing
            Session("chart3") = Nothing
            Session("chart4") = Nothing

            ' Call Statistic method
            objBS.StatLocation(lblDapTotal.Text, lblBapTotal.Text, intLocID)
            ' Thong ke cho dau an pham
            objData = objBS.ArrDataChart
            objLabel = objBS.ArrLabelChart
            If objLabel(0) = "NOT FOUND" Then
                Call NotFoundData()
                Response.End()
            Else
                vtitle = lblDAPVTitle.Text
                htitle = lblDAPHTitle.Text
                title = lblDAPTitle.Text
                lblDAP.Text = objBS.DAP
                objBCC.Makebarchart(objData, objLabel, vtitle, htitle, 45, strImg, "WStatLocation.aspx")
                Session("chart1") = objBCC.OutPutStream
                objBCC.Makepiechart(objData, objLabel, title, strImg)
                Session("chart2") = objBCC.OutPutStream
            End If

            ' Thong ke cho ban an pham
            vtitle = lblBAPVTitle.Text
            htitle = lblBAPHTitle.Text
            title = lblBAPTitle.Text
            lblBAP.Text = objBS.BAP
            objData = objBS.ArrDataChartNext
            objLabel = objBS.ArrLabelChartNext
            If Not objLabel(0) = "NOT FOUND" Then
                lblBAP.Text = objBS.BAP
                objBCC.Makebarchart(objData, objLabel, vtitle, htitle, 45, strImg, "WStatLocation.aspx")
                Session("chart3") = objBCC.OutPutStream
                objBCC.Makepiechart(objData, objLabel, title, strImg)
                Session("chart4") = objBCC.OutPutStream
            End If
        End Sub

        ' NotFoundData method
        Private Sub NotFoundData()
            lblNotFound.Visible = True
            anh1.Visible = False
            anh2.Visible = False
            lblBAP.Visible = False
            lblDAP.Visible = False
        End Sub

        ' Event: Page_Unload
        ' Purpose: release objects
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
    End Class
End Namespace