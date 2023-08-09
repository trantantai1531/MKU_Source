' Class: WOverCatalogue
' Purpose: Overview information of Catalogue
' Creator: Tuanhv
' CreatedDate: 22/09/2005
' Modified 
' + 05/11/2005: by Sondp: review and update 
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WOverCatalogue
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
        Private objBCChart As New clsBCommonChart
        Private objBItemCollection As New clsBItemCollection
        Private objBCataQueue As New clsBCataQueue

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            Call BindJS()
            Call GenChart()
        End Sub

        ' Method: Initialize
        Private Sub Initialize()
            ' Initialize objBCChart object
            objBCChart.DBServer = Session("DBServer")
            objBCChart.ConnectionString = Session("ConnectionString")
            objBCChart.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCChart.Initialize()

            ' Init objBItemCollection object
            objBItemCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemCollection.DBServer = Session("DBServer")
            objBItemCollection.ConnectionString = Session("ConnectionString")
            Call objBItemCollection.Initialize()

            'Init objBCataQueue
            objBCataQueue.ConnectionString = Session("ConnectionString")
            objBCataQueue.InterfaceLanguage = Session("InterfaceLanguage")
            objBCataQueue.DBServer = Session("DBServer")
            objBCataQueue.Initialize()
        End Sub

        ' BindJS method
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = 'Js/WMainTab.js'></script>")

            lnkBibliographic.Attributes.Add("Onclick", "Index_Click();")
            lnkBibliographies.Attributes.Add("Onclick", "IDX_Click();")
            lnkIndex.Attributes.Add("Onclick", "Dictionary_Click();")
        End Sub

        ' Method: GenChart
        Private Sub GenChart()
            Dim strImgURL As String
            Dim tblResult As New DataTable
            Dim data As Object
            Dim label As Object
            Dim i As Integer

            strImgURL = Server.MapPath("..\Images\bground.gif")
            ' Get data for quick view
            objBCataQueue.LibID = clsSession.GlbSite
            tblResult = objBCataQueue.GetQuickView
            ' Total of Bibliography items
            lblTotalRecords_Bib.Text &= Space(1) & "<b>" & FormatNumber(tblResult.Rows(0).Item("TotalItems"), 0) & "</b>"
            ' Total of Authority items
            lblTotalRecords_Aut.Text &= Space(1) & "<b>" & FormatNumber(tblResult.Rows(0).Item("TotalAuthorityItems"), 0) & "</b>"
            ' Total of raw catalogued items
            lblTotalRecords_Soluoc.Text &= Space(1) & "<b>" & FormatNumber(tblResult.Rows(0).Item("TotalCataRawItems"), 0) & "</b>"
            ' Total of items not accepted
            lblTotalRecords_Review.Text &= Space(1) & "<b>" & FormatNumber(tblResult.Rows(0).Item("TotalAcceptedItems"), 0) & "</b>"

            lblTotalItems.Text &= Space(1) & "<b>" & FormatNumber(tblResult.Rows(0).Item("TotalItems"), 0) & "</b>"

            lblTotalItemsQueue.Text &= Space(1) & "<b>" & FormatNumber(tblResult.Rows(0).Item("TotalItemsQueue"), 0) & "</b>"

            lblTotalItemsSendLocation.Text &= Space(1) & "<b>" & FormatNumber(tblResult.Rows(0).Item("TotalItemsSendLocation"), 0) & "</b>"

            lblTotalItemsWaitSendLocation.Text &= Space(1) & "<b>" & FormatNumber(tblResult.Rows(0).Item("TotalItemsWaitSendLocation"), 0) & "</b>"

            tblResult = Nothing
            objBItemCollection.LibID = clsSession.GlbSite
            tblResult = objBItemCollection.GetCatalogueStatOverView()
            anh1.Visible = False
            If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                ReDim data(tblResult.Rows.Count - 1)
                ReDim label(tblResult.Rows.Count - 1)
                For i = 0 To tblResult.Rows.Count - 1
                    data(i) = tblResult.Rows(i).Item("Total")
                    label(i) = tblResult.Rows(i).Item("TypeCode")
                Next
                If Not label(0) = "NOT FOUND" Then
                    anh1.Visible = True
                    hidControl.Value = 1
                    objBCChart.Makebarchart(data, label, "", "", 45, strImgURL, "WOverViewCatalogue.aspx", "", 0)
                    Session("chart1") = Nothing
                    Session("chart1") = objBCChart.OutPutStream
                End If
            End If
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose()
        End Sub

        ' Dispose method
        ' Purpose: Release the methods
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCChart Is Nothing Then
                    objBCChart.Dispose(True)
                    objBCChart = Nothing
                End If
                If Not objBItemCollection Is Nothing Then
                    objBItemCollection.Dispose(True)
                    objBItemCollection = Nothing
                End If
                If Not objBCataQueue Is Nothing Then
                    objBCataQueue.Dispose(True)
                    objBCataQueue = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

    End Class
End Namespace
