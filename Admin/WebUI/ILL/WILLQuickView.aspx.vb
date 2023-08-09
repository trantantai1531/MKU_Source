Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.ILL

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WILLQuickView
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents hrfCheckOut As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lblCheckOut As System.Web.UI.WebControls.Label
        Protected WithEvents hrfCheckIn As System.Web.UI.WebControls.HyperLink
        Protected WithEvents llbCHeckin As System.Web.UI.WebControls.Label
        Protected WithEvents hrfRenew As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lblRenew As System.Web.UI.WebControls.Label
        Protected WithEvents hrfStatistic As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lblStastistic As System.Web.UI.WebControls.Label
        Protected WithEvents hrfOverdue As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lblOverdue1 As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private objBILLLib As New clsBILLLibrary
        Private objBCChart As New clsBCommonChart

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
            Call GenChart()
        End Sub

        ' Initialize method
        ' Purpose: init all neccessary objects
        Private Sub Initialize()
            ' Init objBILLLib object 
            objBILLLib.ConnectionString = Session("ConnectionString")
            objBILLLib.DBServer = Session("DBServer")
            objBILLLib.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBILLLib.Initialize()
            ' Initialize objBCChart object
            objBCChart.DBServer = Session("DBServer")
            objBCChart.ConnectionString = Session("ConnectionString")
            objBCChart.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCChart.Initialize()
        End Sub

        ' BindScript methos
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("ILLMenuJs", "<script language = 'javascript' src = 'Js/WILLMenu.js'></script>")
            hrfInRequest.Attributes.Add("OnClick", "OpenIRMan();")
            hrfOutRequest.Attributes.Add("OnClick", "OpenORMan();")
            hrfIllLib.Attributes.Add("OnClick", "OpenLibMan();")
            hrfTools.Attributes.Add("OnClick", "OpenToolsMan();")
            hrfStaistic.Attributes.Add("OnClick", "OpenStatistic();")
            hrfCreateOR.Attributes.Add("OnClick", "parent.Sentform.location.href='ORMan/WORCreateTaskBar.aspx';")
        End Sub

        ' GenChart method
        Private Sub GenChart()
            Dim strImgURL As String
            Dim tblQuickView As New DataTable
            Dim arrLabel, arrData As Object
            strImgURL = Server.MapPath("..\Images\bground.gif")
            ' Outgoing requests
            objBILLLib.GetQuickView(1, arrData, arrLabel)
            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLLib.ErrorMsg, ddlLabel.Items(1).Text, objBILLLib.ErrorCode)
            lblStatCat1.Visible = False
            anh1.Visible = False
            If Not arrData(0) = -1 Then
                lblStatCat1.Visible = True
                anh1.Visible = True
                hidControlOutComming.Value = 1
                objBCChart.Makebarchart(arrData, arrLabel, ddlLabel.Items(3).Text, ddlLabel.Items(2).Text, 45, strImgURL, "WILLQuickView.aspx", "", 1)
                Session("chart1") = Nothing
                Session("chart1") = objBCChart.OutPutStream
            End If
            ' InComing requests
            objBILLLib.GetQuickView(2, arrData, arrLabel)
            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLLib.ErrorMsg, ddlLabel.Items(1).Text, objBILLLib.ErrorCode)
            lblStartCat2.Visible = False
            anh2.Visible = False
            If Not arrData(0) = -1 Then
                lblStartCat2.Visible = True
                anh2.Visible = True
                hidControlInComming.Value = 1
                objBCChart.Makebarchart(arrData, arrLabel, ddlLabel.Items(3).Text, ddlLabel.Items(2).Text, 45, strImgURL, "WILLQuickView.aspx", "", 1)
                Session("chart2") = Nothing
                Session("chart2") = objBCChart.OutPutStream
            End If
            ' Common
            tblQuickView = objBILLLib.GetQuickView(0, arrData, arrLabel)
            lblIllLibs.Text &= Space(1) & "<b>" & FormatNumber(tblQuickView.Rows(0).Item("LibPartner"), 0) & "</b>"
            lblTotalIncomingRequests.Text &= Space(1) & "<b>" & FormatNumber(tblQuickView.Rows(0).Item("InComingRequests"), 0) & "</b>"
            lblTotalOutRequests.Text &= Space(1) & "<b>" & FormatNumber(tblQuickView.Rows(0).Item("OutGoingRequests"), 0) & "</b>"
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBILLLib Is Nothing Then
                    objBILLLib.Dispose(True)
                    objBILLLib = Nothing
                End If
                If Not objBCChart Is Nothing Then
                    objBCChart.Dispose(True)
                    objBCChart = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace