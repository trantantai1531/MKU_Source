Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibOPAC.BusinessRules.OPAC
Imports System.Collections.Generic

Namespace eMicLibOPAC.WebUI.OPAC
    Public Class OPrint
        Inherits System.Web.UI.Page

        Private objBCommonStringProc As New clsBCommonStringProc
        Private objBSearchResult As New clsBOPACSearchResult
        Private objBSearchQr As New clsBOPACSearchQuery

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Call Initialize()
            If Not Page.IsPostBack Then
                Dim strReportTitle As String = ""
                Dim intOrderBy As Integer = 1
                If Not IsNothing(Request("reportTitle")) AndAlso Request("reportTitle") <> "" Then
                    strReportTitle = Request("reportTitle")
                End If
                If Not IsNothing(Request("orderBy")) AndAlso IsNumeric(Request("orderBy")) Then
                    intOrderBy = CInt(Request("orderBy"))
                Else
                    intOrderBy = 1
                End If
                Dim strSort As String = ""
                Select Case intOrderBy
                    Case 1
                        strSort = "TITLE"
                    Case 2
                        strSort = "AUTHOR"
                    Case 3
                        strSort = "MXG"
                End Select
                Dim strIds As String = objBCommonStringProc.getIdsSring(clsSession.GlbMyListIds)
                Dim strList As String = resortListIds(strIds, strSort)
                Call processBooks(strList, strReportTitle, intOrderBy)
            End If
        End Sub

        ' Init method
        ' purpose initialize all components
        Private Sub Initialize()
            '  Init objBCommonStringProc
            objBCommonStringProc.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBCommonStringProc.ConnectionString = Session("ConnectionString")
            objBCommonStringProc.DBServer = Session("DBServer")
            objBCommonStringProc.Initialize()

            ' init objBSearchQr object
            objBSearchQr.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBSearchQr.DBServer = Session("DBServer")
            objBSearchQr.ConnectionString = Session("ConnectionString")
            objBSearchQr.Initialize()

            ' init objBSearchResult object
            objBSearchResult.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBSearchResult.DBServer = Session("DBServer")
            objBSearchResult.ConnectionString = Session("ConnectionString")
            objBSearchResult.Initialize()

        End Sub


        ' purpose :  show books by list of ids document
        ' Creator: phuongtt
        Private Sub processBooks(ByVal strIds As String, ByVal strReportTitle As String, ByVal intOrderBy As Integer)
            Try
                If strIds.Trim <> "" Then
                    'Dim strArrayIds() As String = Split(strIds, ",")
                    'Dim intTotal As Integer = UBound(strArrayIds)
                    'Dim idsList As String = ""
                    'For intCount As Integer = 0 To intTotal - 1
                    '    If strArrayIds(intCount) <> "" Then
                    '        idsList = idsList & strArrayIds(intCount) & ","
                    '    End If
                    'Next
                    'If idsList <> "" Then
                    '    idsList = Left(idsList, Len(idsList) - 1)
                    'End If
                    'objBSearchResult.ItemIDs = idsList
                    strIds = objBCommonStringProc.getIdsSring(strIds)
                    objBSearchResult.ItemIDs = strIds
                    Dim arrField() As String = {"022", "100", "245", "250", "260", "300", "490", "700", "773"}
                    Dim strSort As String = ""
                    Select Case intOrderBy
                        Case 1
                            strSort = ""
                        Case 2
                        Case 3
                        Case 4
                    End Select
                    Dim tblTmp As New DataTable
                    tblTmp = objBSearchResult.GetItemResultsByFields(arrField, True)
                    'Call showBooks(tblTmp, idsList, strReportTitle, intOrderBy)
                    Call showBooks(tblTmp, strIds, strReportTitle, intOrderBy)
                Else
                End If
            Catch ex As Exception
            End Try
        End Sub

        ' resortListIds method
        ' Purpose: resort by fields
        Private Function resortListIds(ByVal Ids As String, ByVal strSortby As String) As String
            Dim strListIds As String = ""
            Try
                Dim dtListIds As DataTable = Nothing
                objBSearchQr.SortBy = strSortby
                Dim strSQL As String = objBSearchQr.sortByListIds(Ids)
                dtListIds = objBSearchQr.eExecuteQuerySQL(strSQL)
                strListIds = objBCommonStringProc.getiTemString(dtListIds)
            Catch ex As Exception
            End Try
            Return strListIds
        End Function

        ' purpose :  show books
        ' Creator: phuongtt
        Private Sub showBooks(ByVal tblData As DataTable, ByVal strIDs As String, ByVal strReportTitle As String, ByVal intOrderBy As Integer)
            Dim strResult As String = ""
            Try
                Dim strTitle As String = ""
                Dim str100 As String = ""
                Dim str022 As String = ""
                Dim str700 As String = ""
                Dim str773 As String = ""
                Dim str260_300 As String = ""
                Dim intCount As Integer
                Dim arrIDs() As String
                Dim strCover As String = ""
                Dim intJ As Integer = 0
                If tblData Is Nothing Then
                    Exit Sub
                End If
                arrIDs = Split(strIDs, ",")
                strResult = "<TABLE WIDTH='100%' BORDER = '0px'  cellpadding='2px' cellspacing='2px'>"
                strResult &= "<TR VALIGN='Top'><TD colspan='2'><strong>" & strReportTitle & "</strong></TD></TR>"
                strResult &= "<TR VALIGN='Top'><TD colspan='2'>&nbsp;</TD></TR>"
                If tblData.Rows.Count > 0 Then
                    For intCount = 0 To UBound(arrIDs)
                        strResult &= "<TR VALIGN='Top'>"

                        'GetHolding
                        tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND Field='MXG'"
                        If tblData.DefaultView.Count > 0 Then
                            strResult &= "<TD style='width:10%;'>" & tblData.DefaultView(0).Item("Content") & "</TD>"
                        Else
                            strResult &= "<TD style='width:10%;'>&nbsp;</TD>"
                        End If

                        strResult &= "<TD style='width:90%;'>"

                        strTitle = ""
                        str260_300 = ""
                        str773 = ""
                        '022
                        tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND (Field='022')"
                        For intJ = 0 To tblData.DefaultView.Count - 1
                            str022 = str022 & tblData.DefaultView(intJ).Item("Content")
                        Next
                        '100
                        tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND Field='100'"
                        If tblData.DefaultView.Count > 0 Then
                            str100 = tblData.DefaultView(0).Item("Content") & ""
                        End If
                        '245
                        tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND Field='245'"
                        If tblData.DefaultView.Count > 0 Then
                            strTitle = tblData.DefaultView(0).Item("Content") & ""
                        End If
                        '250
                        tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND (Field='250')"
                        For intJ = 0 To tblData.DefaultView.Count - 1
                            str260_300 = str260_300 & tblData.DefaultView(intJ).Item("Content") & ". - "
                        Next
                        '260
                        tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND (Field='260')"
                        For intJ = 0 To tblData.DefaultView.Count - 1
                            str260_300 = str260_300 & tblData.DefaultView(intJ).Item("Content") & ". - "
                        Next
                        '300
                        tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND (Field='300')"
                        For intJ = 0 To tblData.DefaultView.Count - 1
                            str260_300 = str260_300 & tblData.DefaultView(intJ).Item("Content") & ". - "
                        Next
                        '490
                        tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND (Field='490')"
                        For intJ = 0 To tblData.DefaultView.Count - 1
                            str260_300 = str260_300 & "( " & tblData.DefaultView(intJ).Item("Content") & " )" & ". - "
                        Next
                        '700
                        tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND (Field='700')"
                        For intJ = 0 To tblData.DefaultView.Count - 1
                            str260_300 = str260_300 & tblData.DefaultView(intJ).Item("Content")
                        Next
                        '773
                        tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND (Field='773')"
                        For intJ = 0 To tblData.DefaultView.Count - 1
                            str773 = str773 & " //" & tblData.DefaultView(intJ).Item("Content")
                        Next
                        strResult &= "<u>" & strTitle & "</u> . - " & str260_300 & str773
                        strResult &= "</TD></TR>"
                        strResult &= "<TR VALIGN='Top'><TD colspan='2'>&nbsp;</TD></TR>"
                    Next
                    strResult &= "</TABLE>"
                End If
            Catch ex As Exception
            End Try
            ltrBookList.Text = strResult
        End Sub


        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCommonStringProc Is Nothing Then
                    objBCommonStringProc.Dispose(True)
                    objBCommonStringProc = Nothing
                End If
                If Not objBSearchQr Is Nothing Then
                    objBSearchQr.Dispose(True)
                    objBSearchQr = Nothing
                End If
                If Not objBSearchResult Is Nothing Then
                    objBSearchResult.Dispose(True)
                    objBSearchResult = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub


    End Class
End Namespace
