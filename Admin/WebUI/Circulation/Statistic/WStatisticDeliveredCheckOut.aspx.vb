Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WStatisticDeliveredCheckOut
        Inherits clsWBase

        Private objBCB As New clsBCommonBusiness
        Private objBCopyNumber As New clsBCopyNumber
        Private objBCDBS As New clsBCommonDBSystem

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
            If Page.IsPostBack = False Then
                Call BindData()
            End If
        End Sub

        Sub Initialize()
            ' Init objBCB object
            objBCB.InterfaceLanguage = Session("InterfaceLanguage")
            objBCB.DBServer = Session("DBServer")
            objBCB.ConnectionString = Session("ConnectionString")
            Call objBCB.Initialize()
            ' Init objBCopyNumber object
            objBCopyNumber.InterfaceLanguage = Session("InterfaceLanguage")
            objBCopyNumber.DBServer = Session("DBServer")
            objBCopyNumber.ConnectionString = Session("ConnectionString")
            Call objBCopyNumber.Initialize()
            ' Init objBCDBS object
            objBCB.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            Call objBCDBS.Initialize()
        End Sub
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")

            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkDateFrom, txtDateFrom, ddlLabel.Items(3).Text)
            SetOnclickCalendar(lnkDateTo, txtDateTo, ddlLabel.Items(3).Text)
        End Sub

        Public Sub BindData()
            Dim strDateFrom As String = txtDateFrom.Text
            Dim strDateTo As String = txtDateTo.Text

            If strDateFrom <> "" Then strDateFrom = objBCDBS.ConvertDateBack(strDateFrom)
            If strDateTo <> "" Then strDateTo = objBCDBS.ConvertDateBack(strDateTo)

            objBCopyNumber.LibID = clsSession.GlbSite
            Dim tblData As DataTable = objBCopyNumber.GetHoldingDeveredDetailStatis(strDateFrom, strDateTo)

            Dim newColumn As New Data.DataColumn("STT", GetType(System.String))
            newColumn.DefaultValue = "1"
            tblData.Columns.Add(newColumn)
            Dim indexRows As Integer = 1
            For Each rows As DataRow In tblData.Rows
                If (Not (rows.RowState = DataRowState.Deleted)) AndAlso (Not (String.IsNullOrEmpty(rows.Item("STT")))) Then
                    rows.Item("STT") = indexRows.ToString()
                    indexRows = indexRows + 1
                End If
                If rows.Item("DateDelivered") & "" <> "" Then
                    rows.Item("DateDelivered") = String.Format("{0:dd/MM/yyyy}", Date.Parse(rows.Item("DateDelivered")))
                End If
            Next

            Dim tblConvert As New DataTable("tblConvert")
            ConvertTable(tblData, tblConvert)

            If tblConvert.Rows.Count > 0 Then
                dtgDelivered.DataSource = tblConvert
                dtgDelivered.DataBind()
                btnExport.Visible = True
            Else
                dtgDelivered.DataSource = Nothing
                dtgDelivered.DataBind()
                btnExport.Visible = False
            End If
        End Sub

        Public Sub ConvertTable(ByVal tblData As DataTable, ByRef tblConvert As DataTable)
            If (Not IsNothing(tblData)) AndAlso (tblData.Rows.Count > 0) Then
                tblConvert.Clear()
                tblConvert.Columns.Add("STT")
                tblConvert.Columns.Add("Title")
                tblConvert.Columns.Add("CopyNumber")
                tblConvert.Columns.Add("Classification")
                tblConvert.Columns.Add("SenderDelivered")
                tblConvert.Columns.Add("ReceiverDelivered")
                tblConvert.Columns.Add("DateDelivered")
                tblConvert.Columns.Add("AcqSource")
                tblConvert.Columns.Add("StatusNote")
                tblConvert.Columns.Add("LocationName")
                tblConvert.Columns.Add("AttachDocument")
                tblConvert.Columns.Add("Note")

                For Each rows As DataRow In tblData.Rows
                    Dim dtRow As DataRow = tblConvert.NewRow()

                    Dim content245 As String = rows.Item("Content245").ToString()
                    Dim content082 As String = rows.Item("Content082").ToString()
                    Dim content300 As String = rows.Item("Content300").ToString()

                    Dim strTitle As String = ""
                    Dim strClassification As String = ""
                    Dim strAttachDocument As String = ""

                    If content245.Contains("$a") Then
                        Dim split() As String = content245.Split("$")
                        For Each iSplit As String In split
                            If Not String.IsNullOrEmpty(iSplit) AndAlso iSplit(0) = "a" Then
                                strTitle = iSplit.Substring(1).Trim()
                                Exit For
                            End If
                        Next
                    End If

                    If content082.Contains("$a") Then
                        Dim split() As String = content082.Split("$")
                        For Each iSplit As String In split
                            If Not String.IsNullOrEmpty(iSplit) AndAlso iSplit(0) = "a" Then
                                strClassification = iSplit.Substring(1).Trim()
                                Exit For
                            End If
                        Next
                    End If


                    If content300.Contains("$e") Then
                        Dim split() As String = content082.Split("$")
                        For Each iSplit As String In split
                            If Not String.IsNullOrEmpty(iSplit) AndAlso iSplit(0) = "e" Then
                                strAttachDocument = iSplit.Substring(1).Trim()
                                Exit For
                            End If
                        Next
                    End If

                    Dim strStt As String = rows.Item("STT")
                    Dim strCopyNumber As String = rows.Item("CopyNumber") & ""
                    Dim strSenderDelivered As String = rows.Item("SenderDelivered") & ""
                    Dim strReceiverDelivered As String = rows.Item("ReceiverDelivered") & ""
                    Dim strDateDelivered As String = rows.Item("DateDelivered") & ""

                    Dim strAcqSource As String = rows.Item("AcqSource") & ""
                    Dim strStatusNote As String = rows.Item("StatusNote") & ""
                    Dim strLocationName As String = rows.Item("LocationName") & ""
                    Dim strNote As String = rows.Item("Note") & ""

                    dtRow.Item("STT") = strStt
                    dtRow.Item("Title") = strTitle
                    dtRow.Item("CopyNumber") = strCopyNumber
                    dtRow.Item("Classification") = strClassification
                    dtRow.Item("SenderDelivered") = strSenderDelivered
                    dtRow.Item("ReceiverDelivered") = strReceiverDelivered
                    dtRow.Item("DateDelivered") = strDateDelivered
                    dtRow.Item("AcqSource") = strAcqSource
                    dtRow.Item("StatusNote") = strStatusNote
                    dtRow.Item("LocationName") = strLocationName
                    dtRow.Item("AttachDocument") = strAttachDocument
                    dtRow.Item("Note") = strNote

                    tblConvert.Rows.Add(dtRow)
                Next
            End If
        End Sub
        Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
            Call BindData()
        End Sub

        Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
            Dim strDateFrom As String = txtDateFrom.Text
            Dim strDateTo As String = txtDateTo.Text

            If strDateFrom <> "" Then strDateFrom = objBCDBS.ConvertDateBack(strDateFrom)
            If strDateTo <> "" Then strDateTo = objBCDBS.ConvertDateBack(strDateTo)

            objBCopyNumber.LibID = clsSession.GlbSite
            Dim tblData As DataTable = objBCopyNumber.GetHoldingDeveredDetailStatis(strDateFrom, strDateTo)
            Dim dcIndex = New DataColumn("STT", GetType(Int32))
            tblData.Columns.Add(dcIndex)
            If Not tblData Is Nothing AndAlso tblData.Rows.Count > 0 Then
                For inti = 0 To tblData.Rows.Count - 1
                    tblData.Rows(inti).Item("STT") = inti + 1
                Next

                Dim tblConvert As New DataTable("tblConvert")
                ConvertTable(tblData, tblConvert)
                tblConvert.Rows.Add(ddlLabelHeaderTable.Items(0).Text, ddlLabelHeaderTable.Items(1).Text, ddlLabelHeaderTable.Items(2).Text, ddlLabelHeaderTable.Items(3).Text, ddlLabelHeaderTable.Items(4).Text, ddlLabelHeaderTable.Items(5).Text,
                                    ddlLabelHeaderTable.Items(6).Text, ddlLabelHeaderTable.Items(7).Text, ddlLabelHeaderTable.Items(8).Text, ddlLabelHeaderTable.Items(9).Text, ddlLabelHeaderTable.Items(10).Text, ddlLabelHeaderTable.Items(11).Text)

                Dim strHTMLContent As New StringBuilder()
                strHTMLContent.Append(clsBExportHelper.GenDataTableToString(tblConvert))

                clsExport.StringBuilderToExcel(strHTMLContent)

            End If
        End Sub
    End Class
End Namespace

