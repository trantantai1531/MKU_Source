Imports eMicLibAdmin.BusinessRules.Patron
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WPatronIndex
        Inherits clsWbase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents imgSub As System.Web.UI.HtmlControls.HtmlImage
        Protected WithEvents imgModule As System.Web.UI.HtmlControls.HtmlImage


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBPatronCollection As New clsBPatronCollection
        Private objBCChart As New clsBCommonChart

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            Call BindScript()
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

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("HeaderJs", "<script language='javascript' src='js/WHeader.js'></script>")
            hrfPatronProfile.Attributes.Add("OnClick", "OpenDocument();")
            hrfPatronCard.Attributes.Add("OnClick", "OpenCard();")
            hrfBatchProcess.Attributes.Add("OnClick", "OpenBathProcess();")
            hrfStatistic.Attributes.Add("OnClick", "OpenStat();")
        End Sub
        ' Gen Chart method
        Private Sub GenChart()
            Dim strImgURL As String
            strImgURL = Server.MapPath("..\Images\bground.gif")
            objBPatronCollection.LibID = clsSession.GlbSite
            objBPatronCollection.PatronGroupStat(ddlLabel.Items(6).Text)
            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPatronCollection.ErrorMsg, ddlLabel.Items(1).Text, objBPatronCollection.ErrorCode)
            lblStatCat.Visible = False
            anh1.Visible = False
            If Not objBPatronCollection.ArrLabelChart Is Nothing AndAlso Not objBPatronCollection.ArrLabelChart(0) = "NOT FOUND" Then
                lblStatCat.Visible = True
                anh1.Visible = True
                hidControl.Value = 1
                objBCChart.Makebarchart(objBPatronCollection.ArrDataChart, objBPatronCollection.ArrLabelChart, "", "", 45, strImgURL, "WPatronIndex.aspx", "", 1)
                Session("chart1") = Nothing
                Session("chart1") = objBCChart.OutPutStream
            End If
            lblTotalOfPatrons.Text &= Space(1) & "<b>" & FormatNumber(objBPatronCollection.GetTotalPatrons.Rows(0).Item(0), 0) & "</b>"
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