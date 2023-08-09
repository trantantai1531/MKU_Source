'Purpose: Report patron max in and out library
'Creator: Tuannv
Imports eMicLibAdmin.BusinessRules.Common
Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WPatronReport
        Inherits clsWBase
        Dim objBCSP As New clsBCommonStringProc
        Dim objBCDBS As New clsBCommonDBSystem
        Dim objBPatron As New eMicLibAdmin.BusinessRules.Circulation.clsBPatron
        Private objBCC As New clsBCommonChart
        Dim intMonth As Integer
        Dim intYear As Integer
        Dim intLocationID As Integer
        Dim strFromDate As String
        Dim strToDate As String
        Dim strLocation As String

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

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call CheckFormPermission()
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                BindLocation()
                txtFromDate.Text = Session("today")
                txtToDate.Text = Session("today")

                anh1.Visible = False
                anh2.Visible = False
            End If
            If Page.IsPostBack Then
                intLocationID = ddlLocation.SelectedItem.Value
                strLocation = ddlLocation.SelectedItem.Text
                If txtFromDate.Text = "" Then
                    strFromDate = Session("today")
                Else
                    strFromDate = txtFromDate.Text
                End If
                If txtToDate.Text = "" Then
                    strToDate = Session("today")
                Else
                    strToDate = txtToDate.Text
                End If
                '' format string datetime yyyy/mm/dd
                Dim DateFrom = DateTime.ParseExact(strFromDate, "dd/MM/yyyy", Nothing)
                Dim DateTo = DateTime.ParseExact(strToDate, "dd/MM/yyyy", Nothing)
                strFromDate = DateFrom.ToString("yyyy/MM/dd")
                strToDate = DateTo.ToString("yyyy/MM/dd")
                ''

                'Call GenChart()
            End If
            BindData()
            'If Not Page.IsPostBack Then
            '    BindLocation()
            '    txtMonth.Text = Month(Session("today"))
            '    txtYear.Text = Year(Session("today"))
            '    anh1.Visible = False
            '    anh2.Visible = False
            'End If
            'If Page.IsPostBack Then
            '    intLocationID = ddlLocation.SelectedItem.Value
            '    strLocation = ddlLocation.SelectedItem.Text
            '    If txtMonth.Text = "" Then
            '        intMonth = Month(Session("today"))
            '    Else
            '        intMonth = txtMonth.Text
            '    End If
            '    If txtYear.Text = "" Then
            '        intYear = Year(Session("today"))
            '    Else
            '        intYear = txtYear.Text
            '    End If
            '    Call GenChart()
            'End If
        End Sub
        Private Sub Initialize()
            ' Init for objBCommonStringProc
            objBCSP.InterfaceLanguage = Session("InterfaceLanguage")
            objBCSP.DBServer = Session("DBServer")
            objBCSP.ConnectionString = Session("ConnectionString")
            objBCSP.Initialize()
            ' Init for objBCDBS
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            objBCDBS.Initialize()

            ' Init for objBPatron
            objBPatron.InterfaceLanguage = Session("InterfaceLanguage")
            objBPatron.DBServer = Session("DBServer")
            objBPatron.ConnectionString = Session("ConnectionString")
            objBPatron.Initialize()
            ' Initialize objBCC object
            objBCC.InterfaceLanguage = Session("InterfaceLanguage")
            objBCC.DBServer = Session("DBServer")
            objBCC.ConnectionString = Session("ConnectionString")
            Call objBCC.Initialize()
            Response.Expires = 0
            Session("Remain") = 0
            Session("TransactionID") = Nothing
        End Sub
        Private Sub CheckFormPermission()
            If Not CheckPemission(57) Then
                Call WriteErrorMssg(ddlLabel.Items(0).Text.Trim)
            End If
        End Sub
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/CheckOut/WCheckOut.js'></script>")
            Page.RegisterClientScriptBlock("SelfJsPatron", "<script language = 'javascript' src = '../js/CheckOut/WPatronMax.js'></script>")
            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkFromDate, txtFromDate, ddlLabel.Items(2).Text)
            SetOnclickCalendar(lnkToDate, txtToDate, ddlLabel.Items(2).Text)
            btnReport.Attributes.Add("OnClick", "javascript:if(!btnInputCheckNum('document.forms[0].txtMonth','document.forms[0].txtYear','" & ddlLabel.Items(4).Text & "')){return false;}else{document.forms[0].action='WPatronReport.aspx?x=" & GenRandomNumber(10) & "'; document.forms[0].submit();}")
        End Sub
        Private Sub BindLocation()
            Dim tblLocation As New DataTable
            Dim listItem As New listItem
            objBPatron.User_ID = Session("UserID")
            tblLocation = objBPatron.GetLocationID
            If Not tblLocation Is Nothing Then
                If tblLocation.Rows.Count > 0 Then
                    ddlLocation.DataSource = objBCDBS.InsertOneRow(tblLocation, lblLocation.Text)
                    ddlLocation.DataTextField = "LOCNAME"
                    ddlLocation.DataValueField = "ID"
                    ddlLocation.DataBind()
                End If
            Else
                listItem.Value = "0"
                listItem.Text = lblLocation.Text
                ddlLocation.Items.Add(listItem)
            End If

        End Sub
        ' Method: GenChart
        ' Purpose: generate suite charts now
        'Private Sub GenChart()
        '    Dim objData As Object
        '    Dim objLabel As Object
        '    Dim strImg As String
        '    Dim strVtitle As String
        '    Dim strHtitle As String
        '    Dim strTitle As String
        '    strImg = Server.MapPath("..\..\Images\bground.gif")
        '    Try
        '        objBPatron.Month = intMonth
        '        objBPatron.Year = intYear
        '        objBPatron.LocationID = intLocationID
        '        objBPatron.User_ID = Session("UserID")
        '        objBPatron.GetPatronTotal()
        '        objData = objBPatron.ArrDataChart
        '        objLabel = objBPatron.ArrLabelChart
        '        If objLabel(0) = "Not found" Then
        '            anh1.Visible = False
        '            anh2.Visible = False
        '            hidHave.Value = 0
        '            dtgResult.DataSource = Nothing
        '            dtgResult.DataBind()
        '        Else
        '            anh1.Visible = True
        '            anh2.Visible = True
        '            hidHave.Value = 1
        '            strVtitle = lblPatronTotal.Text & vbCrLf
        '            If intLocationID = 0 Then
        '                strVtitle = strVtitle
        '            Else
        '                strVtitle = strVtitle & strLocation & ")"
        '            End If
        '            strHtitle = lbldayofmonth.Text & " " & intMonth & "/" & intYear
        '            objBCC.Makebarchart(objData, objLabel, strVtitle, strHtitle, 45, strImg, "")
        '            Session("chart1") = Nothing
        '            Session("chart1") = objBCC.OutPutStream
        '            strTitle = LblPercent.Text & " " & intMonth & "/" & intYear
        '            objBCC.Makepiechart(objData, objLabel, strTitle, strImg)
        '            Session("chart2") = Nothing
        '            Session("chart2") = objBCC.OutPutStream
        '            Call BindData()
        '        End If
        '    Catch ex As Exception
        '        Dim err = ex.Message
        '    End Try
        'End Sub

        Private Sub BindData()
            'objBPatron.Month = intMonth
            'objBPatron.Year = intYear
            objBPatron.FromDate = strFromDate
            objBPatron.ToDate = strToDate
            objBPatron.LocationID = intLocationID
            objBPatron.User_ID = Session("UserID")
            Dim tblResult As DataTable = objBPatron.GetPatronTotalDetail()

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
        End Sub
        Protected Sub dtgResult_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles dtgResult.PageIndexChanging
            dtgResult.PageIndex = e.NewPageIndex
            BindData()
        End Sub

        Private Sub ConvertTable(ByVal tblResult As DataTable, ByRef tblConvert As DataTable)
            If (Not IsNothing(tblResult)) AndAlso (tblResult.Rows.Count > 0) Then
                tblConvert.Clear()
                tblConvert.Columns.Add("STT")
                tblConvert.Columns.Add("PatronCode")
                tblConvert.Columns.Add("FullName")

                'tblConvert.Columns.Add("Birthday")
                'tblConvert.Columns.Add("YEARS")
                tblConvert.Columns.Add("Mobile")
                tblConvert.Columns.Add("Email")

                tblConvert.Columns.Add("Facebook")
                tblConvert.Columns.Add("GroupName")
                tblConvert.Columns.Add("Grade")
                tblConvert.Columns.Add("Class")

                tblConvert.Columns.Add("Faculty")
                tblConvert.Columns.Add("CodeLoc")
                tblConvert.Columns.Add("CREATEDATE")
                tblConvert.Columns.Add("Name")
                'tblConvert.Columns.Add("CountCheckIn")
                tblConvert.Columns.Add("Note")

                For Each rows As DataRow In tblResult.Rows
                    Dim dtRow As DataRow = tblConvert.NewRow()
                    Dim stt As String = rows.Item("STT") & ""
                    Dim strPatronCode As String = rows.Item("PatronCode") & ""
                    Dim strFullName As String = rows.Item("FullName") & ""

                    'Dim strBirthday As String = rows.Item("Birthday") & ""
                    'Dim strYears As String = rows.Item("YEARS") & ""
                    Dim strMobile As String = rows.Item("Mobile") & ""
                    Dim strEmail As String = rows.Item("Email") & ""

                    Dim strFacebook As String = rows.Item("Facebook") & ""
                    Dim strGroupName As String = rows.Item("GroupName") & ""
                    Dim strGrade As String = rows.Item("Grade") & ""
                    Dim strClass As String = rows.Item("Class") & ""

                    Dim strFaculty As String = rows.Item("Faculty") & ""
                    Dim strCodeLoc As String = rows.Item("CodeLoc") & ""
                    Dim strCREATEDATE As String = rows.Item("CREATEDATE") & ""
                    Dim strName As String = rows.Item("Name") & ""
                    'Dim strCountCheckIn As String = rows.Item("CountCheckIn") & ""
                    Dim strNote As String = rows.Item("Note") & ""

                    dtRow.Item("STT") = stt
                    dtRow.Item("FullName") = strFullName
                    dtRow.Item("PatronCode") = strPatronCode

                    'dtRow.Item("Birthday") = String.Format("{0:dd/MM/yyyy}", strBirthday)
                    'dtRow.Item("YEARS") = strYears
                    dtRow.Item("Mobile") = strMobile
                    dtRow.Item("Email") = strEmail

                    dtRow.Item("Facebook") = strFacebook
                    dtRow.Item("GroupName") = strGroupName
                    dtRow.Item("Grade") = strGrade
                    dtRow.Item("Class") = strClass

                    dtRow.Item("Faculty") = strFaculty
                    dtRow.Item("CodeLoc") = strCodeLoc
                    dtRow.Item("CREATEDATE") = String.Format("{0:hh:mm:tt  dd/MM/yyyy}", strCREATEDATE)
                    dtRow.Item("Name") = strName
                    'dtRow.Item("CountCheckIn") = strCountCheckIn
                    dtRow.Item("Note") = strNote

                    tblConvert.Rows.Add(dtRow)
                Next
            End If
        End Sub

        Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click

            Dim tblData As New DataTable("tblResult")

            objBPatron.Month = intMonth
            objBPatron.Year = intYear
            objBPatron.LocationID = intLocationID
            objBPatron.User_ID = Session("UserID")
            tblData = objBPatron.GetPatronTotalDetail()

            If Not IsNothing(tblData) AndAlso tblData.Rows.Count > 0 Then

                tblData.Columns.Add("STT")
                Dim intSTT As Integer = 1
                For Each row As DataRow In tblData.Rows
                    row("STT") = intSTT
                    intSTT = intSTT + 1
                Next
                Dim tblConvert As New DataTable("tblConvert")
                ConvertTable(tblData, tblConvert)
                tblConvert.Rows.Add(ddlLabelHeaderTable.Items(0).Text, ddlLabelHeaderTable.Items(1).Text,
                                    ddlLabelHeaderTable.Items(2).Text, ddlLabelHeaderTable.Items(5).Text,
                                    ddlLabelHeaderTable.Items(6).Text, ddlLabelHeaderTable.Items(7).Text, ddlLabelHeaderTable.Items(8).Text,
                                    ddlLabelHeaderTable.Items(9).Text, ddlLabelHeaderTable.Items(10).Text, ddlLabelHeaderTable.Items(11).Text,
                                    ddlLabelHeaderTable.Items(12).Text, ddlLabelHeaderTable.Items(13).Text, ddlLabelHeaderTable.Items(14).Text,
                                    ddlLabelHeaderTable.Items(16).Text)

                Dim strHTMLContent As New StringBuilder()
                strHTMLContent.Append(clsBExportHelper.GenDataTableToString(tblConvert))

                clsExport.StringBuilderToExcel(strHTMLContent)
            End If
        End Sub
    End Class
End Namespace
