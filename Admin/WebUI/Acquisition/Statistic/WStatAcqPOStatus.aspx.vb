Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WStatAcqPOStatus
        Inherits clsWBase
        Private objBCommonChart As New clsBCommonChart
        Private objBPurchaseOrder As New clsBPurchaseOrder
        Private objBCommon As New clsBCommonBusiness

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If Not IsPostBack Then
                '' Load nguon bo sung
                Dim tblTemp As New DataTable
                tblTemp = objBCommon.GetAcqSources
                If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                    ddlAcqSource.DataSource = tblTemp
                    ddlAcqSource.DataTextField = "Source"
                    ddlAcqSource.DataValueField = "ID"
                    ddlAcqSource.DataBind()
                    ddlAcqSource.Items.Insert(0, New ListItem("Tất cả", 0))
                    ddlAcqSource.SelectedIndex = 0
                End If
                tblTemp.Clear()
            End If
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
            objBPurchaseOrder.ConnectionString = Session("ConnectionString")
            objBPurchaseOrder.DBServer = Session("DBServer")
            objBPurchaseOrder.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPurchaseOrder.Initialize()
            ' Init BCommonBusiness object
            objBCommon.DBServer = Session("DBServer")
            objBCommon.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommon.ConnectionString = Session("ConnectionString")
            Call objBCommon.Initialize()
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

            txtDateSetFrom.Attributes.Add("onChange", "javascript:CheckDate(this,'" & Session("DateFormat") & "','" & ddlLabel.Items(6).Text & " (" & Session("DateFormat") & ")');")
            txtDateSetFrom.ToolTip = Session("DateFormat")
            txtDateSetTo.Attributes.Add("onChange", "javascript:CheckDate(this,'" & Session("DateFormat") & "','" & ddlLabel.Items(6).Text & " (" & Session("DateFormat") & ")');")
            txtDateSetTo.ToolTip = Session("DateFormat")

            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkDateSetFrom, txtDateSetFrom, ddlLabel.Items(6).Text)
            SetOnclickCalendar(lnkDateSetTo, txtDateSetTo, ddlLabel.Items(6).Text)

        End Sub

        ' BindStatic method
        Private Sub BindStatic()
            Dim arrData As Object
            Dim arrLabel As Object
            Dim strImage As String = "../Images/bground.gif"
            Dim strVTitle As String = ddlLabel.Items(4).Text
            Dim strHTitle As String = ddlLabel.Items(5).Text
            Dim strDateSetFrom As String = ""
            Dim strDateSetTo As String = ""
            Dim intAcqSourceID As Integer
            ' Static on loan
            strDateSetFrom = Trim(txtDateSetFrom.Text)
            strDateSetTo = Trim(txtDateSetTo.Text)
            intAcqSourceID = CInt(ddlAcqSource.SelectedItem.Value)

            objBPurchaseOrder.StatAcqPOStatus(strDateSetFrom, strDateSetTo, intAcqSourceID)
            arrData = objBPurchaseOrder.arrData
            arrLabel = objBPurchaseOrder.arrLabel
            image1.Visible = False
            image2.Visible = False
            hidHave.Value = 0
            lblNostatic.Visible = True
            lblNostatic1.Visible = True

            If Not arrData Is Nothing And Not arrLabel Is Nothing Then
                If arrData(0) > -1 Then
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

                    BindData()
                Else
                    Session("chart1") = Nothing
                    Session("chart2") = Nothing

                    dtgResult.DataSource = Nothing
                    dtgResult.DataBind()
                End If
            Else
                Session("chart1") = Nothing
                Session("chart2") = Nothing

                dtgResult.DataSource = Nothing
                dtgResult.DataBind()
            End If

        End Sub

        Private Sub BindData()
            Dim strDateSetFrom As String = ""
            Dim strDateSetTo As String = ""
            Dim intAcqSourceID As Integer
            '' Reset dtgResult view
            dtgResult.DataSource = Nothing
            dtgResult.DataBind()
            ' Static on loan
            strDateSetFrom = Trim(txtDateSetFrom.Text)
            strDateSetTo = Trim(txtDateSetTo.Text)
            intAcqSourceID = CInt(ddlAcqSource.SelectedItem.Value)
            Dim tblData As DataTable = objBPurchaseOrder.StatAcqPOStatusDetail(strDateSetFrom, strDateSetTo, intAcqSourceID)
            If Not IsNothing(tblData) AndAlso tblData.Rows.Count > 0 Then
                tblData.Columns.Add("STT")
                Dim intSTT As Integer = 1
                For Each row As DataRow In tblData.Rows
                    row("STT") = intSTT
                    intSTT = intSTT + 1
                Next
                dtgResult.DataSource = tblData
                dtgResult.DataBind()
            End If
        End Sub

        Private Sub ConvertTable(ByVal tblResult As DataTable, ByRef tblConvert As DataTable)
            If (Not IsNothing(tblResult)) AndAlso (tblResult.Rows.Count > 0) Then
                tblConvert.Clear()
                tblConvert.Columns.Add("STT")
                tblConvert.Columns.Add("Status")
                tblConvert.Columns.Add("POName")
                tblConvert.Columns.Add("SetDate")
                tblConvert.Columns.Add("Note")
                tblConvert.Columns.Add("FilledDate")
                For Each rows As DataRow In tblResult.Rows
                    Dim dtRow As DataRow = tblConvert.NewRow()
                    Dim stt As String = rows.Item("STT") & ""
                    Dim strStatus As String = rows.Item("Status") & ""
                    Dim strPOName As String = rows.Item("POName") & ""
                    Dim strSetDate As String = rows.Item("SetDate") & ""
                    Dim strNote As String = rows.Item("Note") & ""
                    Dim strFilledDate As String = rows.Item("FilledDate") & ""

                    dtRow.Item("STT") = stt
                    dtRow.Item("Status") = strStatus
                    dtRow.Item("POName") = strPOName
                    dtRow.Item("SetDate") = strSetDate
                    dtRow.Item("Note") = strNote
                    dtRow.Item("FilledDate") = strFilledDate

                    tblConvert.Rows.Add(dtRow)
                Next
            End If
        End Sub

        ' Event: btnCancel_Click
        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            txtDateSetFrom.Text = ""
            txtDateSetTo.Text = ""
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
                If Not objBPurchaseOrder Is Nothing Then
                    objBPurchaseOrder.Dispose(True)
                    objBPurchaseOrder = Nothing
                End If
            Finally
                MyBase.Dispose()
            End Try
        End Sub

        Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
            Try
                Dim strDateSetFrom As String = ""
                Dim strDateSetTo As String = ""

                ' Static on loan
                strDateSetFrom = Trim(txtDateSetFrom.Text)
                strDateSetTo = Trim(txtDateSetTo.Text)

                Dim tblData As DataTable = objBPurchaseOrder.StatAcqPOStatusDetail(strDateSetFrom, strDateSetTo)

                If Not IsNothing(tblData) AndAlso tblData.Rows.Count > 0 Then

                    tblData.Columns.Add("STT")
                    Dim intSTT As Integer = 1
                    For Each row As DataRow In tblData.Rows
                        row("STT") = intSTT
                        intSTT = intSTT + 1
                    Next
                    Dim tblConvert As New DataTable("tblConvert")
                    ConvertTable(tblData, tblConvert)
                    tblConvert.Rows.Add(ddlLabelHeaderTable.Items(0).Text, ddlLabelHeaderTable.Items(1).Text, ddlLabelHeaderTable.Items(2).Text, ddlLabelHeaderTable.Items(3).Text, ddlLabelHeaderTable.Items(4).Text, ddlLabelHeaderTable.Items(5).Text)

                    Dim strHTMLContent As New StringBuilder()
                    strHTMLContent.Append(clsBExportHelper.GenDataTableToString(tblConvert))

                    clsExport.StringBuilderToExcel(strHTMLContent)
                End If
            Catch ex As Exception

            End Try
        End Sub
        Protected Sub dtgResult_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles dtgResult.PageIndexChanging
            dtgResult.PageIndex = e.NewPageIndex
            BindData()
        End Sub
    End Class
End Namespace

