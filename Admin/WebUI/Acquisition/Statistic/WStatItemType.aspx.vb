' Class: WStatItemType
' Puspose: Statistic by ItemType
' Creator: Sondp
' CreatedDate: 01/04/2005
' Modification History:
'   - 13/04/2005 by Oanhtn: riew & update

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WStatItemType
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
            Call BindJS()
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

        ' Method: BindJS
        ' Purpose: include all need js functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("WStatIndexJs", "<script language='javascript' src='../Js/Statistic/WStatIndex.js'></script>")

            btnClose.Attributes.Add("OnClick", "javascript:self.location.href='WStatIndex.aspx'; return false;")
        End Sub

        ' Method: GenChartDirector
        ' Purpose: generate need charts
        Private Sub GenChart()
            Dim strVtitle As String
            Dim strHtitle As String
            Dim strTitle As String
            Dim strImg As String
            Dim objData As Object
            Dim objLabel As Object

            Try
                strImg = Server.MapPath("..\..\Images\bground.gif")
                objBS.LibID = clsSession.GlbSite
                objBS.StatItemType(lblDAPTotal.Text, lblBAPTotal.Text)
                ' Thong ke cho dau an pham
                objData = objBS.ArrDataChart
                objLabel = objBS.ArrLabelChart

                If objLabel(0) = "NOT FOUND" Then
                    Response.Redirect("WStatEmty.aspx")
                Else
                    strVtitle = lblDAPVTitle.Text
                    strHtitle = lblDAPHTitle.Text
                    strTitle = lblDAPTitle.Text
                    lblDAP.Text = objBS.DAP
                    objBCC.Makebarchart(objData, objLabel, strVtitle, strHtitle, 45, strImg, "WStatItemType.aspx")
                    Session("chart1") = Nothing
                    Session("chart1") = objBCC.OutPutStream
                    objBCC.Makepiechart(objData, objLabel, strTitle, strImg)
                    Session("chart2") = Nothing
                    Session("chart2") = objBCC.OutPutStream
                End If

                ' Thong ke cho ban an pham
                strVtitle = lblBAPVTitle.Text
                strHtitle = lblBAPHTitle.Text
                strTitle = lblBAPTitle.Text
                objData = objBS.ArrDataChartNext
                objLabel = objBS.ArrLabelChartNext
                If objLabel(0) = "NOT FOUND" Then ' khong co du lieu
                    Response.Redirect("WStatEmty.aspx")
                Else
                    lblBAP.Text = objBS.BAP
                    objBCC.Makebarchart(objData, objLabel, strVtitle, strHtitle, 45, strImg, "WStatItemType.aspx")
                    Session("chart3") = Nothing
                    Session("chart3") = objBCC.OutPutStream

                    objBCC.Makepiechart(objData, objLabel, strTitle, strImg)
                    Session("chart4") = Nothing
                    Session("chart4") = objBCC.OutPutStream
                End If
            Catch ex As Exception
                ' Catch errors
                Call WriteErrorMssg(ddlLog.Items(1).Text, objBS.ErrorMsg, ddlLog.Items(2).Text, 0)
            End Try
        End Sub

        ' Method: Page_Unload
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