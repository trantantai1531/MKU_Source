' Class: WStatTop20
' Puspose: Create statistic top 20 items
' Creator: Sondp
' CreatedDate: 01/04/2005
' Modification History:
'   - 13/04/2005 by Oanhtn: review 

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WStatTop20
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
        ' Declare variables
        Private objBCDL As New clsBCatDicList
        Private objBCDBS As New clsBCommonDBSystem

        ' Event: page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then

                Call BindData()
                Session("chart1") = Nothing
                Session("chart2") = Nothing
                Session("chart3") = Nothing
                Session("chart4") = Nothing
                'If Request.QueryString("ID") & "" <> "" Then
                '    If Request.QueryString("ID").Trim = "0" Then
                '        Page.RegisterClientScriptBlock("ErrorJS", "<script language='javascript'>alert('" & lblError.Text & "');self.close();</script>")
                '    Else
                '        Call GenChart()

                '        If (Not IsNothing(Request.QueryString("export"))) Then

                '            Dim objData() As String = CType(objBS.ArrDataChart, String())
                '            Dim objLabel() As Integer = CType(objBS.ArrLabelChart, Integer())
                '            Dim objDataNext() As String = CType(objBS.ArrDataChartNext, String())

                '            Dim sBuilder1 As StringBuilder = clsBExportHelper.GenToExcel(objLabel, objData, lblDAPTotal.Text & Request.QueryString("text"))

                '            Dim sBuilder2 As StringBuilder = clsBExportHelper.GenToExcel(objLabel, objDataNext, lblBAPTotal.Text & Request.QueryString("text"))


                '            clsExport.StringBuilderToExcel(sBuilder1.Append("<br/>" & sBuilder2.ToString()))
                '        End If
                '    End If
                'End If
            End If
        End Sub

        Private Sub BindData()
            Dim tblCatDicList As New DataTable
            Dim listItem As New listItem

            Try
                tblCatDicList = objBCDL.GetCatDicList(0)
                If Not tblCatDicList Is Nothing Then
                    If tblCatDicList.Rows.Count > 0 Then
                        ddlTop20.DataSource = objBCDBS.InsertOneRow(tblCatDicList, lblSelectStat.Text)
                        ddlTop20.DataValueField = "ID"
                        ddlTop20.DataTextField = "Name"
                        ddlTop20.DataBind()
                    End If
                Else
                    listItem.Value = "0"
                    listItem.Text = lblSelectStat.Text
                    ddlTop20.Items.Add(listItem)
                End If
            Catch ex As Exception
            End Try
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
            ' Initialize objBCDL object
            objBCDL.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDL.DBServer = Session("DBServer")
            objBCDL.ConnectionString = Session("ConnectionString")
            Call objBCDL.Initialize()

            ' Initialize objBCDBS object
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            Call objBCDBS.Initialize()
        End Sub

        ' Method: BindScript
        ' Purpose: include all need js functions
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("WStatIndexJs", "<script language='javascript' src='../Js/Statistic/WStatTop20.js'></script>")
        End Sub

        ' Method: GenChart
        ' Purpose: generate suite charts now
        Private Sub GenChart()
            Dim strVtitle As String
            Dim strHtitle As String
            Dim strTitle As String
            Dim strImg As String
            Dim ArrDataDAP As Object
            Dim ArrLabelDAP As Object
            Dim ArrDataBAP As Object
            Dim ArrLabelBAP As Object
            Dim objData As Object
            Dim objLabel As Object
            strImg = Server.MapPath("..\..\Images\bground.gif")

            Try
                ' Goi ham thong ke
                objBS.LibID = clsSession.GlbSite
                objBS.StatTop20(lblDAPTotal.Text, lblBAPTotal.Text, CInt(ddlTop20.SelectedItem.Value))

                objData = objBS.ArrDataChart
                objLabel = objBS.ArrLabelChart
                If objLabel(0) = "NOT FOUND" Then
                    'Page.RegisterClientScriptBlock("NothingJS", "<script language='javascript'>alert('" & lblNothing.Text & "');</script>")
                    'Response.Redirect("WStatEmty.aspx")
                    Session("chart1") = Nothing
                    Session("chart2") = Nothing
                    Session("chart3") = Nothing
                    Session("chart4") = Nothing
                    lblDAP.Text = lblNothing.Text
                    lblBAP.Text = objBS.BAP
                Else
                    ' Thong ke cho dau an pham
                    strTitle = lblTitle.Text & ddlTop20.SelectedItem.Text
                    strVtitle = lblVTitle.Text & ddlTop20.SelectedItem.Text
                    strHtitle = lblHTitle.Text & ddlTop20.SelectedItem.Text
                    lblDAP.Text = objBS.DAP
                    objBCC.Makebarchart(objData, objLabel, strVtitle, strHtitle, 45, strImg, "WStatTop20.aspx")
                    Session("chart1") = Nothing
                    Session("chart1") = objBCC.OutPutStream
                    objBCC.Makepiechart(objData, objLabel, strTitle, strImg)
                    Session("chart2") = Nothing
                    Session("chart2") = objBCC.OutPutStream
                    ' Thong ke cho ban an pham
                    lblBAP.Text = objBS.BAP
                    objData = objBS.ArrDataChartNext
                    objLabel = objBS.ArrLabelChartNext
                    objBCC.Makebarchart(objData, objLabel, strVtitle, strHtitle, 45, strImg, "WStatTop20.aspx")
                    Session("chart3") = Nothing
                    Session("chart3") = objBCC.OutPutStream
                    objBCC.Makepiechart(objData, objLabel, strTitle, strImg)
                    Session("chart4") = Nothing
                    Session("chart4") = objBCC.OutPutStream
                End If
            Catch ex As Exception ' Catch errors
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
            If Not objBCDL Is Nothing Then
                objBCDL.Dispose(True)
                objBCDL = Nothing
            End If
            If Not objBCDBS Is Nothing Then
                objBCDBS.Dispose(True)
                objBCDBS = Nothing
            End If
        End Sub

        Protected Sub btnStatistic_Click(sender As Object, e As EventArgs) Handles btnStatistic.Click
            Call GenChart()
        End Sub

        Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
            objBS.LibID = clsSession.GlbSite
            objBS.StatTop20(lblDAPTotal.Text, lblBAPTotal.Text, CInt(ddlTop20.SelectedItem.Value))


            Dim objData() As Integer = CType(objBS.ArrDataChart, Integer())
            Dim objLabel() As String = CType(objBS.ArrLabelChart, String())
            Dim objDataNext() As Integer = CType(objBS.ArrDataChartNext, Integer())

            Dim sBuilder1 As StringBuilder = clsBExportHelper.GenToExcel(objLabel, objData, lblHTitle.Text & " " & ddlTop20.SelectedItem.Text & ", " & lblDAPTotal.Text)

            Dim sBuilder2 As StringBuilder = clsBExportHelper.GenToExcel(objLabel, objDataNext, lblHTitle.Text & " " & ddlTop20.SelectedItem.Text & ", " & lblBAPTotal.Text)

            clsExport.StringBuilderToExcel(sBuilder1.Append("<br/>" & sBuilder2.ToString()))
        End Sub
    End Class
End Namespace