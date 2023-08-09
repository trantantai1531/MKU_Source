Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WDelivered
        Inherits clsWBase

        Private objBCB As New clsBCommonBusiness
        Private objBCopyNumber As New clsBCopyNumber
        Private objBCDBS As New clsBCommonDBSystem
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
            If Page.IsPostBack = False Then
                Call BindDDL()
                Call BindData()
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: Init all need objects
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

        Public Sub BindDDL()
            Dim tblTemp As DataTable = objBCB.GetAcqSources
            ddlAcquireSource.Items.Clear()
            ddlAcquireSource.Items.Add(New ListItem("Toàn bộ", "0"))
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                For Each row As DataRow In tblTemp.Rows
                    ddlAcquireSource.Items.Add(New ListItem(row.Item("Source").ToString(), row.Item("ID").ToString()))
                Next
            End If
            ddlAcquireSource.DataBind()
        End Sub

        Public Sub BindData()
            Dim strCopyNumber As String = txtCopyNumber.Text
            Dim strTitle As String = txtTitle.Text
            Dim strAuthor As String = txtAuthor.Text
            Dim strClassification As String = txtClassification.Text
            Dim intAcquiredSource As Integer = CInt(ddlAcquireSource.SelectedValue)
            Dim strAdditionalBy As String = txtAdditionalBy.Text
            Dim strDateFrom As String = txtDateFrom.Text
            Dim strDateTo As String = txtDateTo.Text

            If strDateFrom <> "" Then strDateFrom = objBCDBS.ConvertDateBack(strDateFrom)
            If strDateTo <> "" Then strDateTo = objBCDBS.ConvertDateBack(strDateTo)

            objBCopyNumber.LibID = clsSession.GlbSite
            Dim tblData As DataTable = objBCopyNumber.GetHoldingDevered("", strCopyNumber, strTitle, strAuthor, strClassification, intAcquiredSource, strAdditionalBy, strDateFrom, strDateTo)

            Dim newColumn As New Data.DataColumn("STT", GetType(System.String))
            newColumn.DefaultValue = "1"
            tblData.Columns.Add(newColumn)
            Dim indexRows As Integer = 1
            For Each rows As DataRow In tblData.Rows
                If (Not (rows.RowState = DataRowState.Deleted)) AndAlso (Not (String.IsNullOrEmpty(rows.Item("STT")))) Then
                    rows.Item("STT") = indexRows.ToString()
                    indexRows = indexRows + 1
                End If
            Next

            Dim tblConvert As New DataTable("tblConvert")
            ConvertTable(tblData, tblConvert)

            If tblConvert.Rows.Count > 0 Then
                dtgDelivered.DataSource = tblConvert
                dtgDelivered.DataBind()
                btnDelivered.Visible = True
            Else
                dtgDelivered.DataSource = Nothing
                dtgDelivered.DataBind()
                btnDelivered.Visible = False
            End If
        End Sub

        Public Sub ConvertTable(ByVal tblData As DataTable, ByRef tblConvert As DataTable)
            If (Not IsNothing(tblData)) AndAlso (tblData.Rows.Count > 0) Then
                tblConvert.Clear()
                tblConvert.Columns.Add("STT")
                tblConvert.Columns.Add("ID")
                tblConvert.Columns.Add("CopyNumber")
                tblConvert.Columns.Add("Title")
                tblConvert.Columns.Add("Author")
                tblConvert.Columns.Add("Classification")
                tblConvert.Columns.Add("AcquireSource")
                tblConvert.Columns.Add("AdditionalBy")

                For Each rows As DataRow In tblData.Rows
                    Dim dtRow As DataRow = tblConvert.NewRow()

                    Dim content245 As String = rows.Item("Title").ToString()
                    Dim content082 As String = rows.Item("Classification").ToString()
                    Dim content100 As String = rows.Item("Author").ToString()

                    Dim title As String = ""
                    Dim author As String = ""
                    Dim classification As String = ""

                    If content245.Contains("$a") Then
                        Dim split() As String = content245.Split("$")
                        For Each iSplit As String In split
                            If Not String.IsNullOrEmpty(iSplit) AndAlso iSplit(0) = "a" Then
                                title = iSplit.Substring(1).Trim()
                                Exit For
                            End If
                        Next
                    End If

                    If content100.Contains("$a") Then
                        Dim split() As String = content100.Split("$")
                        For Each iSplit As String In split
                            If Not String.IsNullOrEmpty(iSplit) AndAlso iSplit(0) = "a" Then
                                author = iSplit.Substring(1).Trim()
                                Exit For
                            End If
                        Next
                    End If


                    If content082.Contains("$a") Then
                        Dim split() As String = content082.Split("$")
                        For Each iSplit As String In split
                            If Not String.IsNullOrEmpty(iSplit) AndAlso iSplit(0) = "a" Then
                                classification = iSplit.Substring(1).Trim()
                                Exit For
                            End If
                        Next
                    End If

                    Dim stt As String = rows.Item("STT")
                    Dim intID As String = rows.Item("ID") & ""
                    Dim strCopyNumber As String = rows.Item("CopyNumber") & ""
                    Dim strAcquireSource As String = rows.Item("AcquireSource") & ""
                    Dim strAdditionalBy As String = rows.Item("AdditionalBy") & ""

                    dtRow.Item("STT") = stt
                    dtRow.Item("CopyNumber") = strCopyNumber
                    dtRow.Item("ID") = intID
                    dtRow.Item("Title") = title
                    dtRow.Item("Author") = author
                    dtRow.Item("Classification") = classification
                    dtRow.Item("AcquireSource") = strAcquireSource
                    dtRow.Item("AdditionalBy") = strAdditionalBy

                    tblConvert.Rows.Add(dtRow)
                Next
            End If
        End Sub

        Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
            Call BindData()
        End Sub

        Protected Sub btnDelivered_Click(sender As Object, e As EventArgs) Handles btnDelivered.Click
            Dim dtgItem As DataGridItem
            Dim chkSelected As CheckBox
            Dim strIDs As String = ""

            For Each dtgItem In dtgDelivered.Items
                chkSelected = dtgItem.FindControl("chkID")
                If chkSelected.Checked Then
                    strIDs = strIDs & CType(dtgItem.FindControl("hidID"), HiddenField).Value & ","
                End If
            Next

            If strIDs <> "" Then
                strIDs = Left(strIDs, Len(strIDs) - 1)

                Response.Redirect("WDeliveredCheckOut.aspx?strIDs=" & strIDs)
            Else
                Page.RegisterClientScriptBlock("ReceivedUnLockSuccess", "<script>alert('Chưa chọn ĐKCB cần ghi nhận');</script>")
            End If
        End Sub
    End Class
End Namespace

