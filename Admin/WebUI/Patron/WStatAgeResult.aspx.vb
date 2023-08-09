' Class: WStatAgeResult
' Puspose: Show statistic by age
' Creator: Sondp
' CreatedDate: 21-1-2005
' Modification History:
'   - 02/05/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Patron
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WStatAgeResult
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Protected WithEvents btnBack As System.Web.UI.WebControls.Button


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
            'Call GenChart()
            Call BindData()
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
            Call WriteLog(31, ddlLabel.Items(6).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
        End Sub

        ' Method: BindJS
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("WStatAgeResultJs", "<script language='javascript' src='js/WStatAgeResult.js'></script>")
        End Sub

        ' Method: GenChart
        ' Purpose: Gen Image ChartDirect method
        Private Sub GenChart()
            Dim strImgURL As String
            Dim data As Object
            Dim label As Object

            lblNotFound.Visible = False
            strImgURL = "../Images/bground.gif"

            If Request.QueryString("allage") = "nok" And Request.QueryString("from") & "" <> "" And Request.QueryString("to") & "" <> "" Then ' Statistic Each Age
                If IsNumeric(Request.QueryString("from")) And IsNumeric(Request.QueryString("to")) Then
                    objBPatronCollection.LibID = clsSession.GlbSite
                    objBPatronCollection.AgeStat(True, CByte(Request.QueryString("from")), CByte(Request.QueryString("to")))
                    ' Write error
                    Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPatronCollection.ErrorMsg, ddlLabel.Items(1).Text, objBPatronCollection.ErrorCode)

                    data = objBPatronCollection.ArrDataChart
                    label = objBPatronCollection.ArrLabelChart

                    If UCase(label(0)) = "NOT FOUND" Then ' Don't have any data
                        lblNotFound.Visible = True
                        anh1.Visible = False
                        anh2.Visible = False
                        Response.End()
                    Else ' Statistic process
                        objBCChart.Makebarchart(data, label, ddlLabel.Items(3).Text, ddlLabel.Items(4).Text, 60, strImgURL, "WStatAgeResult.aspx")
                        Session("chart1") = Nothing
                        Session("chart1") = objBCChart.OutPutStream
                        objBCChart.Makepiechart(data, label, ddlLabel.Items(5).Text, strImgURL)
                        Session("chart2") = Nothing
                        Session("chart2") = objBCChart.OutPutStream
                    End If
                Else
                    lblNotFound.Visible = True
                    anh1.Visible = False
                    anh2.Visible = False
                    Response.End()
                End If
            Else ' Statistic All Age
                If Request.QueryString("allage") = "ok" Then ' Staitistic all age
                    If Trim(Request.QueryString("xLabel")) = "" Or Request.QueryString("xLabel") Is Nothing Then
                        objBPatronCollection.LibID = clsSession.GlbSite
                        objBPatronCollection.AgeStat(False, 0, 0)
                        ' Write error
                        Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPatronCollection.ErrorMsg, ddlLabel.Items(1).Text, objBPatronCollection.ErrorCode)

                        data = objBPatronCollection.ArrDataChart
                        label = objBPatronCollection.ArrLabelChart
                        If label(0) = "NOT FOUND" Then
                            lblNotFound.Visible = True
                            anh1.Visible = False
                            anh2.Visible = False
                            Response.End()
                        Else
                            objBCChart.Makebarchart(data, label, ddlLabel.Items(3).Text, ddlLabel.Items(4).Text, 45, strImgURL, "WStatAgeResult.aspx")
                            Session("chart1") = Nothing
                            Session("chart1") = objBCChart.OutPutStream
                            Response.Write("<MAP NAME=""map1"">" & objBCChart.OutMapImg & "</MAP>")
                            objBCChart.Makepiechart(data, label, ddlLabel.Items(5).Text, strImgURL)
                            Session("chart2") = Nothing
                            Session("chart2") = objBCChart.OutPutStream
                        End If
                    End If
                Else ' Statistic each age
                    objBPatronCollection.LibID = clsSession.GlbSite
                    Select Case Request.QueryString("xLabel")
                        Case "<=18"
                            objBPatronCollection.AgeStat(True, 0, 18)
                        Case "18-30"
                            objBPatronCollection.AgeStat(True, 18, 30)
                        Case "30-40"
                            objBPatronCollection.AgeStat(True, 30, 40)
                        Case "40-50"
                            objBPatronCollection.AgeStat(True, 40, 50)
                        Case "50-60"
                            objBPatronCollection.AgeStat(True, 50, 60)
                        Case "60-70"
                            objBPatronCollection.AgeStat(True, 60, 70)
                        Case ">=70"
                            objBPatronCollection.AgeStat(True, 70, 200)
                    End Select
                    ' Write error
                    Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPatronCollection.ErrorMsg, ddlLabel.Items(1).Text, objBPatronCollection.ErrorCode)

                    data = objBPatronCollection.ArrDataChart
                    label = objBPatronCollection.ArrLabelChart
                    If label(0) = "NOT FOUND" Then ' Don't have data
                        lblNotFound.Visible = True
                        anh1.Visible = False
                        anh2.Visible = False
                        Response.End()
                    Else
                        objBCChart.Makebarchart(data, label, ddlLabel.Items(3).Text, ddlLabel.Items(4).Text, 0, strImgURL, "WStatAgeResult.aspx")
                        Session("chart1") = Nothing
                        Session("chart1") = objBCChart.OutPutStream
                        objBCChart.Makepiechart(data, label, ddlLabel.Items(5).Text, strImgURL)
                        Session("chart2") = Nothing
                        Session("chart2") = objBCChart.OutPutStream
                    End If
                End If
            End If
            ' Write log
            Call WriteFormLog()
        End Sub

        ' Page Unload method
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Me.Dispose(True)
        End Sub

        ' Method: Dispose
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBPatronCollection Is Nothing Then
                    objBPatronCollection.Dispose(True)
                    objBPatronCollection = Nothing
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

        Protected Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            Response.Redirect("WStatAgeForm.aspx")
        End Sub

        Private Sub BindData()
            If Request.QueryString("allage") = "nok" And Request.QueryString("from") & "" <> "" And Request.QueryString("to") & "" <> "" Then ' Statistic Each Age
                If IsNumeric(Request.QueryString("from")) And IsNumeric(Request.QueryString("to")) Then
                    objBPatronCollection.LibID = clsSession.GlbSite
                    Dim tblResult As DataTable = objBPatronCollection.AgeStatDetail(CByte(Request.QueryString("from")), CByte(Request.QueryString("to")))

                    If Not IsNothing(tblResult) Then
                        If tblResult.Rows.Count > 0 Then
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
                End If
            Else ' Statistic All Age
                If Request.QueryString("allage") = "ok" Then ' Staitistic all age
                    If Trim(Request.QueryString("xLabel")) = "" Or Request.QueryString("xLabel") Is Nothing Then
                        objBPatronCollection.LibID = clsSession.GlbSite
                        Dim tblResult As DataTable = objBPatronCollection.AgeStatDetail(0, 0)

                        If Not IsNothing(tblResult) Then
                            If tblResult.Rows.Count > 0 Then
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
                    End If
                End If
            End If
        End Sub
        Protected Sub dtgResult_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles dtgResult.PageIndexChanging
            dtgResult.PageIndex = e.NewPageIndex
            BindData()
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

        Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
            'If Request.QueryString("allage") = "nok" And Request.QueryString("from") & "" <> "" And Request.QueryString("to") & "" <> "" Then ' Statistic Each Age
            '    If IsNumeric(Request.QueryString("from")) And IsNumeric(Request.QueryString("to")) Then
            '        objBPatronCollection.LibID = clsSession.GlbSite
            '        objBPatronCollection.AgeStat(True, CByte(Request.QueryString("from")), CByte(Request.QueryString("to")))
            '    Else
            '        lblNotFound.Visible = True
            '        anh1.Visible = False
            '        anh2.Visible = False
            '        Response.End()
            '    End If
            'Else ' Statistic All Age
            '    If Request.QueryString("allage") = "ok" Then ' Staitistic all age
            '        If Trim(Request.QueryString("xLabel")) = "" Or Request.QueryString("xLabel") Is Nothing Then
            '            objBPatronCollection.LibID = clsSession.GlbSite
            '            objBPatronCollection.AgeStat(False, 0, 0)
            '        End If
            '    Else ' Statistic each age
            '        objBPatronCollection.LibID = clsSession.GlbSite
            '        Select Case Request.QueryString("xLabel")
            '            Case "<=18"
            '                objBPatronCollection.AgeStat(True, 0, 18)
            '            Case "18-30"
            '                objBPatronCollection.AgeStat(True, 18, 30)
            '            Case "30-40"
            '                objBPatronCollection.AgeStat(True, 30, 40)
            '            Case "40-50"
            '                objBPatronCollection.AgeStat(True, 40, 50)
            '            Case "50-60"
            '                objBPatronCollection.AgeStat(True, 50, 60)
            '            Case "60-70"
            '                objBPatronCollection.AgeStat(True, 60, 70)
            '            Case ">=70"
            '                objBPatronCollection.AgeStat(True, 70, 200)
            '        End Select

            '    End If
            'End If

            'If Not (objBPatronCollection.ArrLabelChart(0) = "NOT FOUND") Then

            '    Dim objData() As Integer = CType(objBPatronCollection.ArrDataChart, Integer())
            '    Dim objLabel() As String = CType(objBPatronCollection.ArrLabelChart, String())
            '    Dim sBuilder1 As StringBuilder = clsBExportHelper.GenToExcel(objLabel, objData, ddlLabel.Items(6).Text)

            '    clsExport.StringBuilderToExcel(sBuilder1)
            'End If

            Dim tblData As New DataTable("tblResult")

            If Request.QueryString("allage") = "nok" And Request.QueryString("from") & "" <> "" And Request.QueryString("to") & "" <> "" Then ' Statistic Each Age
                If IsNumeric(Request.QueryString("from")) And IsNumeric(Request.QueryString("to")) Then
                    objBPatronCollection.LibID = clsSession.GlbSite
                    tblData = objBPatronCollection.AgeStatDetail(CByte(Request.QueryString("from")), CByte(Request.QueryString("to")))
                End If
            Else ' Statistic All Age
                If Request.QueryString("allage") = "ok" Then ' Staitistic all age
                    If Trim(Request.QueryString("xLabel")) = "" Or Request.QueryString("xLabel") Is Nothing Then
                        objBPatronCollection.LibID = clsSession.GlbSite
                        Dim tblResult As DataTable = objBPatronCollection.AgeStatDetail(0, 0)
                    End If
                End If
            End If

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
        End Sub
    End Class
End Namespace