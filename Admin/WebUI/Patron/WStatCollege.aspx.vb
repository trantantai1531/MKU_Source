' Class: WStatCollege
' Puspose: Show statistic by college
' Creator: Sondp
' CreatedDate: 21-1-2005
' Modification History:
'   - 02/05/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Patron
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WStatCollege
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
        Private objBPatronCollection As New clsBPatronCollection
        Private objBCChart As New clsBCommonChart

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            Call GenChart()
        End Sub

        ' Method: Initialize
        Private Sub Initialize()
            ' Initialize objBPatronCollection object
            objBPatronCollection.DBServer = Session("DBServer")
            objBPatronCollection.ConnectionString = Session("ConnectionString")
            objBPatronCollection.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPatronCollection.initialize()

            ' Initialize objBCChart object
            objBCChart.DBServer = Session("DBServer")
            objBCChart.ConnectionString = Session("ConnectionString")
            objBCChart.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCChart.Initialize()
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            If Not CheckPemission(52) Then
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub

        ' Method: WriteFormLog
        Private Sub WriteFormLog()
            Call WriteLog(31, ddlLabel.Items(7).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
        End Sub

        ' Method: BindJS
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("WStatCollegeJs", "<script language='javascript' src='js/WStartIndex.js'></script>")
        End Sub

        ' Method: GenChart
        Private Sub GenChart()
            Dim strImgURL As String
            Dim data As Object
            Dim label As Object

            lblNotFoundData.Visible = False
            strImgURL = "..\Images\bground.gif"
            objBPatronCollection.LibID = clsSession.GlbSite
            objBPatronCollection.CollegeStat(ddlLabel.Items(6).Text)
            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPatronCollection.ErrorMsg, ddlLabel.Items(1).Text, objBPatronCollection.ErrorCode)

            data = objBPatronCollection.ArrDataChart
            label = objBPatronCollection.ArrLabelChart
            If label(0) = "NOT FOUND" Then
                lblNotFoundData.Visible = True
                anh1.Visible = False
                anh2.Visible = False
            Else
                objBCChart.Makebarchart(data, label, ddlLabel.Items(4).Text, ddlLabel.Items(3).Text, 45, strImgURL, "WStatCollege.aspx")
                Session("chart1") = Nothing
                Session("chart1") = objBCChart.OutPutStream
                objBCChart.Makepiechart(data, label, ddlLabel.Items(5).Text, strImgURL)
                Session("char2") = Nothing
                Session("chart2") = objBCChart.OutPutStream
            End If

            ' Write log
            Call WriteFormLog()
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBPatronCollection Is Nothing Then
                objBPatronCollection.Dispose(True)
                objBPatronCollection = Nothing
            End If
            If Not objBCChart Is Nothing Then
                objBCChart.Dispose(True)
                objBCChart = Nothing
            End If
        End Sub
    End Class
End Namespace