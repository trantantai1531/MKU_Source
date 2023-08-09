' class  WStatisticPatronGroup
' Puspose: Static allow patron group
' Creator: Tuanhv
' CreatedDate: 06/09/2004
' Modification History:
'   + 17/04/2005 by Sondp: update and review

Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WStatisticTopCopy
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
        Private objBCommonChart As New clsBCommonChart
        Private objBLoanTransaction As New clsBLoanTransaction

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            Call BindStatic()
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBCommonChart object
            objBCommonChart.ConnectionString = Session("ConnectionString")
            objBCommonChart.DBServer = Session("DBServer")
            objBCommonChart.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCommonChart.Initialize()

            ' Init clsBLoanTransaction object
            objBLoanTransaction.ConnectionString = Session("ConnectionString")
            objBLoanTransaction.DBServer = Session("DBServer")
            objBLoanTransaction.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBLoanTransaction.Initialize()
        End Sub

        ' CheckFormPermission method
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            If Not CheckPemission(67) Then
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub

        ' BindJS method
        ' Purpose: Bind javascript
        Private Sub BindJS()


            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")

            txtCheckOutDateFrom.Attributes.Add("onChange", "javascript:CheckDate(this,'" & Session("DateFormat") & "','" & ddlLabel.Items(6).Text & " (" & Session("DateFormat") & ")');")
            txtCheckOutDateFrom.ToolTip = Session("DateFormat")
            txtCheckOutDateTo.Attributes.Add("onChange", "javascript:CheckDate(this,'" & Session("DateFormat") & "','" & ddlLabel.Items(6).Text & " (" & Session("DateFormat") & ")');")
            txtCheckOutDateTo.ToolTip = Session("DateFormat")

            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkCheckOutDateFrom, txtCheckOutDateFrom, ddlLabel.Items(6).Text)
            SetOnclickCalendar(lnkCheckOutDateTo, txtCheckOutDateTo, ddlLabel.Items(6).Text)

            SetCheckNumber(txtMin, ddlLabel.Items(3).Text)
            SetCheckNumber(txtTopNum, ddlLabel.Items(3).Text)


        End Sub

        ' BindStatic method
        Private Sub BindStatic()
            Dim arrData As Object
            Dim arrLabel As Object
            Dim strImage As String = "../Images/bground.gif"
            Dim strVTitle As String = ddlLabel.Items(4).Text
            Dim strHTitle As String = ddlLabel.Items(5).Text
            Dim intLstCount As Integer
            Dim strCheckOutDateFrom As String
            Dim strCheckOutDateTo As String
            Dim intTopNum As Integer
            Dim intMinLoan As Integer

            objBLoanTransaction.UserID = Session("UserID")

            ' Static on loan
            strCheckOutDateFrom = Trim(txtCheckOutDateFrom.Text)
            strCheckOutDateTo = Trim(txtCheckOutDateTo.Text)
            intTopNum = CInt(Trim(txtTopNum.Text))
            intMinLoan = CInt(Trim(txtMin.Text))
            'objBLoanTransaction.CreateTopCopyStatistic(strCheckOutDateFrom, strCheckOutDateTo, intTopNum, intMinLoan)
            objBLoanTransaction.CreateTopCopyStatisticOther(strCheckOutDateFrom, strCheckOutDateTo, intTopNum, intMinLoan)
            arrData = objBLoanTransaction.arrData
            arrLabel = objBLoanTransaction.arrLabel
            image1.Visible = False
            image2.Visible = False
            hidHave.Value = 0
            lblNostatic.Visible = True
            lblNostatic1.Visible = True

            If Not arrData Is Nothing And Not arrLabel Is Nothing Then
                If UBound(arrData) > -1 Then
                    image1.Visible = True
                    image2.Visible = True
                    Call objBCommonChart.Makebarchart(arrData, arrLabel, strHTitle, strVTitle, 45, strImage, "")
                    Session("chart1") = Nothing
                    Session("chart1") = objBCommonChart.OutPutStream

                    Call objBCommonChart.Makepiechart(arrData, arrLabel, strHTitle, strImage)
                    Session("chart2") = Nothing
                    Session("chart2") = objBCommonChart.OutPutStream
                    hidHave.Value = 1
                    lblNostatic.Visible = False
                    lblNostatic1.Visible = False
                Else
                    Session("chart1") = Nothing
                    Session("chart2") = Nothing
                End If
            Else
                Session("chart1") = Nothing
                Session("chart2") = Nothing
            End If
        End Sub

        ' Event: btnCancel_Click
        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            txtCheckOutDateFrom.Text = ""
            txtCheckOutDateTo.Text = ""
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCommonChart Is Nothing Then
                    objBCommonChart.Dispose(True)
                    objBCommonChart = Nothing
                End If
                If Not objBLoanTransaction Is Nothing Then
                    objBLoanTransaction.Dispose(True)
                    objBLoanTransaction = Nothing
                End If
            Finally
                MyBase.Dispose()
            End Try
        End Sub

        Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
            Try
                Dim strCheckOutDateFrom As String
                Dim strCheckOutDateTo As String
                Dim intTopNum As Integer
                Dim intMinLoan As Integer
                Dim tblData As New DataTable("tblResult")
                objBLoanTransaction.UserID = Session("UserID")

                ' Static on loan
                strCheckOutDateFrom = Trim(txtCheckOutDateFrom.Text)
                strCheckOutDateTo = Trim(txtCheckOutDateTo.Text)
                intTopNum = CInt(Trim(txtTopNum.Text))
                intMinLoan = CInt(Trim(txtMin.Text))
                tblData = objBLoanTransaction.CreateTopCopyStatisticOtherDHVL(strCheckOutDateFrom, strCheckOutDateTo, intTopNum, intMinLoan)
                If Not IsNothing(tblData) AndAlso tblData.Rows.Count > 0 Then

                    'tblData.Columns.Add("STT")
                    'Dim intSTT As Integer = 1
                    'For Each row As DataRow In tblData.Rows
                    '    row("STT") = intSTT
                    '    intSTT = intSTT + 1
                    'Next
                    Dim tblConvert As New DataTable("tblConvert")
                    ConvertTable(tblData, tblConvert)
                    tblConvert.Rows.Add(ddlLabelHeaderTable.Items(0).Text, ddlLabelHeaderTable.Items(1).Text, ddlLabelHeaderTable.Items(2).Text,
                                        ddlLabelHeaderTable.Items(3).Text, ddlLabelHeaderTable.Items(4).Text, ddlLabelHeaderTable.Items(5).Text,
                                        ddlLabelHeaderTable.Items(6).Text, ddlLabelHeaderTable.Items(7).Text, ddlLabelHeaderTable.Items(8).Text,
                                        ddlLabelHeaderTable.Items(9).Text)

                    Dim strHTMLContent As New StringBuilder()
                    strHTMLContent.Append(clsBExportHelper.GenDataTableToString(tblConvert))

                    clsExport.StringBuilderToExcel(strHTMLContent)
                End If
            Catch ex As Exception

            End Try
        End Sub
        Private Sub ConvertTable(ByVal tblResult As DataTable, ByRef tblConvert As DataTable)
            If (Not IsNothing(tblResult)) AndAlso (tblResult.Rows.Count > 0) Then
                tblConvert.Clear()
                tblConvert.Columns.Add("STT")
                tblConvert.Columns.Add("CopyNumber")
                tblConvert.Columns.Add("SubjectNum")
                tblConvert.Columns.Add("Title")
                tblConvert.Columns.Add("Author")
                tblConvert.Columns.Add("Publisher")
                tblConvert.Columns.Add("YearPublishing")
                tblConvert.Columns.Add("TotalLoan")
                tblConvert.Columns.Add("CodeLoc")
                tblConvert.Columns.Add("Note")

                Dim intSTT = 0
                For Each rows As DataRow In tblResult.Rows
                    Dim dtRow As DataRow = tblConvert.NewRow()
                    intSTT += 1
                    Dim stt As String = CStr(intSTT)
                    Dim strCopyNumber As String = rows.Item("CopyNumber") & ""
                    Dim strSubjectNum As String = rows.Item("SubjectNum") & ""
                    Dim strTitle As String = rows.Item("Title") & ""
                    Dim strAuthor As String = rows.Item("Author") & ""
                    Dim strPublisher As String = rows.Item("Publisher") & ""
                    Dim strYearPublishing As String = rows.Item("YearPublishing") & ""
                    Dim strTotalLoan As String = rows.Item("TotalLoan") & ""
                    Dim strCodeLoc As String = rows.Item("CodeLoc") & ""
                    Dim strNote As String = ""

                    dtRow.Item("STT") = stt
                    dtRow.Item("CopyNumber") = strCopyNumber
                    dtRow.Item("SubjectNum") = strSubjectNum
                    dtRow.Item("Title") = strTitle

                    dtRow.Item("Author") = strAuthor
                    dtRow.Item("Publisher") = strPublisher
                    dtRow.Item("YearPublishing") = strYearPublishing
                    dtRow.Item("TotalLoan") = strTotalLoan
                    dtRow.Item("CodeLoc") = strCodeLoc
                    dtRow.Item("Note") = strNote

                    tblConvert.Rows.Add(dtRow)
                Next
            End If
        End Sub
    End Class
End Namespace