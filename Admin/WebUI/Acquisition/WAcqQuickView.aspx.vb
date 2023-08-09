Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WAcqQuickView
        Inherits clswbase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblItemsInUsed As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBS As New clsBStatistic
        Private objBCC As New clsBCommonChart

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            Call GenChart()
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
            Page.RegisterClientScriptBlock("WAcqMenuJs", "<script language='javascript' src='js/WACQMenu.js'></script>")
            hrfPO.Attributes.Add("OnClick", "IndexPO_Click();")
            hrfAcquisition.Attributes.Add("OnClick", "IndexACQ_Click();")
            hrfBudget.Attributes.Add("OnClick", "IndexAccounting_Click();")
            hrfInventory.Attributes.Add("OnClick", "IndexStore_Click();")
            hrfStatistic.Attributes.Add("OnClick", "IndexStat_Click();")
        End Sub

        ' Method: GenChartDirector
        ' Purpose: generate need charts
        Private Sub GenChart()
            Dim strImg As String
            Dim objData As Object
            Dim objLabel As Object
            Dim tblTemp As DataTable

            strImg = Server.MapPath("..\Images\bground.gif")
            ' Gen barchart
            objBS.LibID = clsSession.GlbSite
            objBS.GetSummaryHoldings(Session("UserID"), 0)
            Call WriteErrorMssg(ddlLog.Items(1).Text, objBS.ErrorMsg, ddlLog.Items(2).Text, objBS.ErrorCode)
            objData = objBS.ArrDataChart
            objLabel = objBS.ArrLabelChart
            lblStatCat.Visible = False
            anh1.Visible = False
            If objLabel(0) <> "NOT FOUND" Then
                lblStatCat.Visible = True
                anh1.Visible = True
                hidControl.Value = 1
                objBCC.Makebarchart(objData, objLabel, "", "", 45, strImg, "WAcqQuickView.aspx", "", 0)
                Session("chart1") = Nothing
                Session("chart1") = objBCC.OutPutStream
            End If
            ' Get summary
            tblTemp = objBS.GetSummaryHoldings(Session("UserID"), 1)
            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    lblItemsInOrder.Text &= Space(1) & "<b>" & FormatNumber(tblTemp.Rows(0).Item("ItemsInOrder"), 0) & "</b>"
                    lblTotalHolding.Text &= Space(1) & "<b>" & FormatNumber(tblTemp.Rows(0).Item("TotalHodling"), 0) & "</b>"
                    lblItemsInProcess.Text &= Space(1) & "<b>" & FormatNumber(tblTemp.Rows(0).Item("ItemsInProcess"), 0) & "</b>"
                    lblItemsInQuery.Text &= Space(1) & "<b>" & FormatNumber(tblTemp.Rows(0).Item("ItemsInQuery"), 0) & "</b>"
                    lblItemsWaiting.Text &= Space(1) & "<b>" & FormatNumber(tblTemp.Rows(0).Item("ItemsWaiting"), 0) & "</b>"
                    lblItemsSendCatalogue.Text &= Space(1) & "<b>" & FormatNumber(tblTemp.Rows(0).Item("ItemsSendCatalogue"), 0) & "</b>"
                    lblItemsRequest.Text &= Space(1) & "<b>" & FormatNumber(tblTemp.Rows(0).Item("ItemsRequest"), 0) & "</b>"
                End If
            End If
        End Sub

        ' Method: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose()
        End Sub

        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBS Is Nothing Then
                    objBS.Dispose(True)
                    objBS = Nothing
                End If
                If Not objBCC Is Nothing Then
                    objBCC.Dispose(True)
                    objBCC = Nothing
                End If
            Catch ex As Exception
            End Try
        End Sub
    End Class
End Namespace