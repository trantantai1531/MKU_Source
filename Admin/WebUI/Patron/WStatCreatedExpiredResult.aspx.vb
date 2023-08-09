' Class: WStatCreatedDate
' Puspose: Show statistic by validdate
' Creator: Sondp
' CreatedDate: 21-1-2005
' Modification History:
'   - 02/05/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Patron
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WStatCreatedExpiredResult
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
            Call Initialize()
            Call BindScript()
            If Page.IsPostBack = False Then
                'Call GenChart()
                Call BindData()
            End If
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

        ' Method: BindScript
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("WStatCreatedDateResultJs", "<script language='javascript' src='js/WStartIndex.js'></script>")
        End Sub

        ' GenChart method
        Private Sub GenChart()
            Dim strImgURL As String
            Dim data As Object
            Dim label As Object
            strImgURL = "../Images/bground.gif"
            lblNotFound.Visible = False
            objBPatronCollection.LibID = clsSession.GlbSite

            If Not Request.QueryString("Year") & "" = "" Then
                'objBPatronCollection.ExpiredDateStat(CInt(Request.QueryString("Year")))
                objBPatronCollection.CreatedDateStat(CInt(Request.QueryString("Year")))
                ' Write error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPatronCollection.ErrorMsg, ddlLabel.Items(1).Text, objBPatronCollection.ErrorCode)

                data = objBPatronCollection.ArrDataChart
                label = objBPatronCollection.ArrLabelChart
                If label(0) = "NOT FOUND" Then
                    lblNotFound.Visible = True
                    anh1.Visible = False
                    anh2.Visible = False
                Else
                    If Request.QueryString("Year") = "0" Then
                        objBCChart.Makebarchart(data, label, ddlLabel.Items(6).Text, ddlLabel.Items(3).Text, 0, strImgURL, "WStatCreatedExpiredResult.aspx")
                    Else
                        objBCChart.Makebarchart(data, label, ddlLabel.Items(6).Text, ddlLabel.Items(4).Text & ": " & Request.QueryString("Year"), 0, strImgURL, "WStatCreatedExpiredResult.aspx")
                    End If
                    Session("chart1") = objBCChart.OutPutStream
                    objBCChart.Makepiechart(data, label, ddlLabel.Items(5).Text, strImgURL)
                    Session("chart2") = objBCChart.OutPutStream
                End If
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

        Protected Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            Response.Redirect("WStatCreatedExpired.aspx")
        End Sub

        Private Sub ConvertTable(ByVal tblResult As DataTable, ByRef tblConvert As DataTable)
            If (Not IsNothing(tblResult)) AndAlso (tblResult.Rows.Count > 0) Then
                tblConvert.Clear()
                tblConvert.Columns.Add("STT")
                tblConvert.Columns.Add("FirstName")
                tblConvert.Columns.Add("LastName")
                tblConvert.Columns.Add("PatronCode")
                tblConvert.Columns.Add("LastIssuedDate")
                'tblConvert.Columns.Add("ValidDate")
                tblConvert.Columns.Add("ExpiredDate")
                tblConvert.Columns.Add("Class")
                tblConvert.Columns.Add("Grade")
                tblConvert.Columns.Add("Faculty")
                tblConvert.Columns.Add("College")
                tblConvert.Columns.Add("GroupName")

                tblConvert.Columns.Add("Mobile")
                tblConvert.Columns.Add("Email")
                tblConvert.Columns.Add("Address")
                tblConvert.Columns.Add("City")
                tblConvert.Columns.Add("Note")

                For Each rows As DataRow In tblResult.Rows
                    Dim dtRow As DataRow = tblConvert.NewRow()
                    Dim stt As String = rows.Item("STT") & ""
                    Dim strFirstName As String = rows.Item("FirstName") & ""
                    Dim strLastName As String = rows.Item("LastName") & ""
                    Dim strPatronCode As String = rows.Item("PatronCode") & ""
                    Dim strLastIssuedDate As String = rows.Item("LastIssuedDate") & ""
                    'Dim strValidDate As String = rows.Item("ValidDate") & ""
                    Dim strExpiredDate As String = rows.Item("ExpiredDate") & ""
                    Dim strClass As String = rows.Item("Class") & ""
                    Dim strGrade As String = rows.Item("Grade") & ""
                    Dim strFaculty As String = rows.Item("Faculty") & ""
                    Dim strCollege As String = rows.Item("College") & ""
                    Dim strGroupName As String = rows.Item("GroupName") & ""

                    Dim strMobile As String = rows.Item("Mobile") & ""
                    Dim strEmail As String = rows.Item("Email") & ""
                    Dim strAddress As String = rows.Item("Address") & ""
                    Dim strCity As String = rows.Item("City") & ""
                    Dim strNote As String = rows.Item("Note") & ""

                    dtRow.Item("STT") = stt
                    dtRow.Item("FirstName") = strFirstName
                    dtRow.Item("LastName") = strLastName
                    dtRow.Item("PatronCode") = strPatronCode
                    dtRow.Item("LastIssuedDate") = If(Not strLastIssuedDate = String.Empty, String.Format("{0:dd/MM/yyyy}", strLastIssuedDate).Substring(0, 10), "")
                    'dtRow.Item("ValidDate") = String.Format("{0:dd/MM/yyyy}", strValidDate).Substring(0, 10)
                    dtRow.Item("ExpiredDate") = If(Not strExpiredDate = String.Empty, String.Format("{0:dd/MM/yyyy}", strExpiredDate).Substring(0, 10), "")
                    dtRow.Item("Class") = strClass
                    dtRow.Item("Grade") = strGrade
                    dtRow.Item("Faculty") = strFaculty
                    dtRow.Item("College") = strCollege
                    dtRow.Item("GroupName") = strGroupName
                    dtRow.Item("Mobile") = strMobile
                    dtRow.Item("Email") = strEmail
                    dtRow.Item("Address") = strAddress
                    dtRow.Item("City") = strCity
                    dtRow.Item("Note") = strNote

                    tblConvert.Rows.Add(dtRow)
                Next
            End If
        End Sub

        Private Sub BindData()
            Dim tblResult As New DataTable("tblResult")

            objBPatronCollection.Faculty = Session("FacultyID")
            Dim strFromDate = Session("DateFrom")
            Dim strDateTo = Session("DateTo")
            'Dim intYear As Integer = CInt(Request.QueryString("Year"))
            objBPatronCollection.LibID = clsSession.GlbSite
            tblResult = objBPatronCollection.CreatedDateStatDetailDHVL(strFromDate, strDateTo)
            lblTotal.Text = "0"
            If Not IsNothing(tblResult) Then
                If tblResult.Rows.Count > 0 Then
                    lblTotal.Text = tblResult.Rows.Count
                    tblResult.Columns.Add("STT")
                    Dim intSTT As Integer = 1
                    For Each row As DataRow In tblResult.Rows
                        row("STT") = intSTT
                        intSTT = intSTT + 1
                    Next
                    dtgResult.DataSource = tblResult
                    dtgResult.DataBind()
                End If
            End If
        End Sub
        Protected Sub dtgResult_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles dtgResult.PageIndexChanging
            dtgResult.PageIndex = e.NewPageIndex
            BindData()
        End Sub

        Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
            Dim strFromDate = Session("DateFrom")
            Dim strDateTo = Session("DateTo")
            If strFromDate & "" <> "" AndAlso strDateTo <> "" Then

                Dim tblData As New DataTable("tblResult")
                objBPatronCollection.Faculty = Session("FacultyID")
                'Dim intYear As Integer = CInt(Request.QueryString("Year"))

                objBPatronCollection.LibID = clsSession.GlbSite
                tblData = objBPatronCollection.CreatedDateStatDetailDHVL(strFromDate, strDateTo)

                If Not IsNothing(tblData) AndAlso tblData.Rows.Count > 0 Then

                    tblData.Columns.Add("STT")
                    Dim intSTT As Integer = 1
                    For Each row As DataRow In tblData.Rows
                        row("STT") = intSTT
                        intSTT = intSTT + 1
                    Next
                    Dim tblConvert As New DataTable("tblConvert")
                    ConvertTable(tblData, tblConvert)
                    tblConvert.Rows.Add(ddlLabelHeaderTable.Items(0).Text, ddlLabelHeaderTable.Items(1).Text, ddlLabelHeaderTable.Items(2).Text,
                                        ddlLabelHeaderTable.Items(3).Text, ddlLabelHeaderTable.Items(4).Text, ddlLabelHeaderTable.Items(5).Text,
                                        ddlLabelHeaderTable.Items(6).Text, ddlLabelHeaderTable.Items(7).Text, ddlLabelHeaderTable.Items(8).Text,
                                        ddlLabelHeaderTable.Items(9).Text, ddlLabelHeaderTable.Items(10).Text, ddlLabelHeaderTable.Items(11).Text,
                                        ddlLabelHeaderTable.Items(12).Text, ddlLabelHeaderTable.Items(13).Text, ddlLabelHeaderTable.Items(14).Text,
                                        ddlLabelHeaderTable.Items(15).Text)

                    Dim strHTMLContent As New StringBuilder()
                    strHTMLContent.Append(clsBExportHelper.GenDataTableToString(tblConvert))

                    clsExport.StringBuilderToExcel(strHTMLContent)
                End If
            End If
        End Sub
    End Class
End Namespace