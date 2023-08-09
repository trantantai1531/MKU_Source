Imports eMicLibOPAC.BusinessRules.OPAC
Imports eMicLibOPAC.BusinessRules.Common

Namespace eMicLibOPAC.WebUI
    Public Class OSearchContent
        Inherits clsWBaseJqueryUI ' clsWBase

        Private objBOPACFile As New clsBOPACFile
        Private objBCommonStringProc As New clsBCommonStringProc
        Private objBSearchQr As New clsBOPACSearchQuery
        Private objBSearchResult As New clsBOPACSearchResult

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Call Initialize()
            Call BindScript()
            If Not IsPostBack Then
                Call getItems()
            End If
        End Sub

        ' Init method
        ' purpose initialize all components
        Private Sub Initialize()
            ' Init objBOPACItem object
            objBOPACFile.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBOPACFile.DBServer = Session("DBServer")
            objBOPACFile.ConnectionString = Session("ConnectionString")
            Call objBOPACFile.Initialize()

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
        ' BindScript method
        ' Purpose: Bind JAVASCRIPTS
        Private Sub BindScript()
            'Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = 'js/OShow.js'></script>")
        End Sub



        ' Init getItems
        ' purpose get iTems and into session
        Private Sub getItems()
            Try
                If Not IsNothing(Request("txtSearchContent")) Then
                    Dim strSearchTemp As String = ""
                    Dim strSearchContent As String = ""
                    Dim intItemID As Integer = 0
                    If Not IsNothing(Request("ItemID")) Then
                        intItemID = Request("ItemID")
                    End If
                    strSearchContent = Request("txtSearchContent").Trim
                    If strSearchContent <> "" Then
                        strSearchTemp = objBCommonStringProc.killCharsProcessVal(strSearchContent)
                        strSearchContent = getCutVietnameseAccent(strSearchTemp)
                        Dim tblTmp As New DataTable
                        objBOPACFile.ItemID = intItemID
                        objBOPACFile.WordSearch = strSearchContent
                        tblTmp = objBOPACFile.fulltextWordSearch
                        clsSession.GlbFulltextPages = tblTmp
                        Call showBooks(tblTmp, strSearchTemp)
                    End If
                End If
            Catch ex As Exception
            End Try
        End Sub

        Private Function getCutVietnameseAccent(ByVal strSearch As String) As String
            Dim strResult As String = ""
            Try
                strResult = objBCommonStringProc.CutVietnameseAccent(strSearch)
            Catch ex As Exception
            End Try
            Return strResult
        End Function

        Private Sub showBooks(ByVal tblTmp As DataTable, Optional ByVal strSearch As String = "")
            Try
                If Not IsNothing(tblTmp) AndAlso tblTmp.Rows.Count > 0 Then
                    Dim intTotal As Integer = tblTmp.Rows.Count
                    Dim intPagezise As Integer = Application("ePageSize") / 2
                    Dim intPageLength As Integer = 3
                    Dim intPageSpace As Integer = 3
                    Dim intCurPage As Integer = hidCurrentPage.Value
                    Dim intStart, intStop As Integer
                    intStart = (intCurPage - 1) * intPagezise
                    intStop = (((intCurPage - 1) * intPagezise) + intPagezise) - 1
                    If intStart > intTotal - 1 Then
                        intStart = intTotal - 1
                    End If
                    If intStop > intTotal - 1 Then
                        intStop = intTotal - 1
                    End If

                    Dim strWordHighlight As String = ""
                    For i As Integer = intStart To intStop
                        If strWordHighlight = "" Then
                            strWordHighlight = clsUICommon.getWordHightLight(tblTmp.Rows(i).Item("Contents"), "<span class=""hightlight-text"">", Len(strSearch))
                            If strWordHighlight <> "" Then
                                Exit For
                            End If
                        End If
                    Next
                    Call showPagingControl(intTotal, intPagezise, intCurPage, intPageSpace, intPageLength, intStop, strWordHighlight)

                    Dim strResult As String = ""
                    
                    For i As Integer = intStart To intStop
                        'strResult &= "<div class='grid no-margin'>"
                        'strResult &= "<div class='row'>"
                        'strResult &= "<span class='line-height' style='text-align:justify'>"
                        'strResult &= "<strong><a style='cursor:pointer;' onclick=""gotoPage(" & tblTmp.Rows(i).Item("LinkPage") & ",'" & strWordHighlight & "')"">" & spPage.InnerText & Space(1) & tblTmp.Rows(i).Item("LinkPage") & "</a></strong> " & clsUICommon.sumaryContents(tblTmp.Rows(i).Item("Contents"), "<span style=""background-color:#60a917 !important;color:white;"">", 10, 30, 10, 30)
                        'strResult &= "</span>"
                        'strResult &= "<hr/>"
                        'strResult &= "<div/>"
                        'strResult &= "<div/>"
                        strResult &= "<p><a style='cursor:pointer;' onclick=""gotoPage(" & tblTmp.Rows(i).Item("LinkPage") & ",'" & strWordHighlight & "')"">" & spPage.InnerText & Space(1) & tblTmp.Rows(i).Item("LinkPage") & "</a> " & clsUICommon.sumaryContents(tblTmp.Rows(i).Item("Contents"), "<span class=""hightlight-text"">", 10, 30, 10, 30) & "</p>"
                    Next
                    ltrBookList.Text = strResult
                    panelBook.Visible = True
                    panelNotFound.Visible = False
                Else
                    panelBook.Visible = False
                    panelNotFound.Visible = True
                    ltrNotFound.Text = spNotFound.InnerText & strSearch
                End If
            Catch ex As Exception
            End Try
        End Sub

        '' purpose :  show paging as google paging
        '' Creator: phuongtt
        'Private Sub showPagingControl(ByVal intCount As Integer, ByVal intPagezise As Integer, ByVal intPage As Integer, ByVal intPageSpace As Integer, ByVal intPageLength As Integer, ByVal intStop As Integer, ByVal strSearch As String)
        '    Try
        '        Dim iPage As Integer = CInt((intCount / intPagezise) + 0.4999)
        '        Dim strPagination As String = ""
        '        Dim PreviousPage As Integer = intPage - 1
        '        Dim NextPage As Integer = intPage + 1
        '        If PreviousPage >= 1 Then
        '            strPagination &= "<li class='prev'><a onclick=""showRecord(" & PreviousPage.ToString & ",'" & strSearch & "')"" data-hint='|" & spPreviousPage.InnerText & "' data-hint-position='top'><i class='icon-previous' style='padding:1px;'></i></a></li>"
        '        End If
        '        Dim xy As Integer = CInt((intPage / intPageSpace) + 0.4999)
        '        Dim alpha As Integer = (xy - 1) * intPageSpace
        '        Dim iPageCount As Integer = IIf(intPageLength + alpha <= iPage, intPageLength + alpha, iPage)

        '        For j As Integer = 1 + alpha To iPageCount
        '            If j = intPage Then
        '                strPagination &= "<li class='active'>"
        '            Else
        '                strPagination &= "<li>"
        '            End If
        '            strPagination &= "<a onclick=""showRecord(" & j.ToString & ",'" & strSearch & "')"">" & j.ToString & "</a><li>"
        '        Next
        '        If NextPage <= iPage Then
        '            strPagination &= "<li class='next'><a onclick=""showRecord(" & NextPage.ToString & ",'" & strSearch & "')"" data-hint='|" & spNextPage.InnerText & "' data-hint-position='top'><i class='icon-next' style='padding:1px;'></i></a></li>"
        '        End If
        '        lrtPagination1.Text = strPagination
        '        lrtPagination2.Text = strPagination

        '        Dim strItemInfo As String = ""
        '        strItemInfo &= "<div style='vertical-align:middle;'><span class='tertiary-text-secondary'>"
        '        strItemInfo &= "&nbsp;"
        '        strItemInfo &= spRecordItem.InnerText
        '        strItemInfo &= "&nbsp;"
        '        strItemInfo &= intPagezise * (intPage - 1) + 1
        '        strItemInfo &= "&nbsp;"
        '        strItemInfo &= spRecordTo.InnerText
        '        strItemInfo &= "&nbsp;"
        '        strItemInfo &= intStop + 1
        '        strItemInfo &= "&nbsp;"
        '        strItemInfo &= spRecordOf.InnerText
        '        strItemInfo &= "&nbsp;"
        '        strItemInfo &= intCount
        '        'strItemInfo &= "</strong> "
        '        strItemInfo &= "</span>"
        '        strItemInfo &= "</div>"
        '        ltrHeader.Text = strItemInfo
        '    Catch ex As Exception
        '    End Try
        'End Sub

        ' purpose :  show paging as google paging
        ' Creator: phuongtt
        Private Sub showPagingControl(ByVal intCount As Integer, ByVal intPagezise As Integer, ByVal intPage As Integer, ByVal intPageSpace As Integer, ByVal intPageLength As Integer, ByVal intStop As Integer, ByVal strSearch As String)
            Try
                Dim iPage As Integer = CInt((intCount / intPagezise) + 0.4999)
                Dim strPagination As String = ""
                Dim PreviousPage As Integer = intPage - 1
                Dim NextPage As Integer = intPage + 1
                If PreviousPage >= 1 Then
                    strPagination &= "<li><a onclick=""showRecord(" & PreviousPage.ToString & ",'" & strSearch & "')"" data-hint='|" & spPreviousPage.InnerText & "' data-hint-position='top' style='cursor:pointer;'><</a></li>"
                End If
                Dim xy As Integer = CInt((intPage / intPageSpace) + 0.4999)
                Dim alpha As Integer = (xy - 1) * intPageSpace
                Dim iPageCount As Integer = IIf(intPageLength + alpha <= iPage, intPageLength + alpha, iPage)

                For j As Integer = 1 + alpha To iPageCount
                    strPagination &= "<li>"
                    If j = intPage Then
                        strPagination &= "<a onclick=""showRecord(" & j.ToString & ",'" & strSearch & "')"" class='PageSeleted'  style='cursor:pointer;'>" & j.ToString & "</a>"
                    Else
                        strPagination &= "<a onclick=""showRecord(" & j.ToString & ",'" & strSearch & "')""  style='cursor:pointer;'>" & j.ToString & "</a>"
                    End If
                    strPagination &= "</li>"
                Next
                If NextPage <= iPage Then
                    strPagination &= "<li><a onclick=""showRecord(" & NextPage.ToString & ",'" & strSearch & "')"" data-hint='|" & spNextPage.InnerText & "' data-hint-position='top'  style='cursor:pointer;'>></a></li>"
                End If
                lrtPagination1.Text = strPagination
                lrtPagination2.Text = strPagination

                Dim strItemInfo As String = ""
                strItemInfo &= "<div style='vertical-align:middle;'><span class='tertiary-text-secondary'>"
                strItemInfo &= "&nbsp;"
                strItemInfo &= spRecordItem.InnerText
                strItemInfo &= "&nbsp;"
                strItemInfo &= FormatNumber(intPagezise * (intPage - 1) + 1, 0)
                strItemInfo &= "&nbsp;"
                strItemInfo &= spRecordTo.InnerText
                strItemInfo &= "&nbsp;"
                strItemInfo &= FormatNumber(intStop + 1, 0)
                strItemInfo &= "&nbsp;"
                strItemInfo &= spRecordOf.InnerText
                strItemInfo &= "&nbsp;"
                strItemInfo &= FormatNumber(intCount, 0)
                'strItemInfo &= "</strong> "
                strItemInfo &= "</span>"
                strItemInfo &= "</div>"
                lrtPagination1.Text &= strItemInfo
                lrtPagination2.Text &= strItemInfo
            Catch ex As Exception
            End Try
        End Sub

        Private Sub raiseShowRecord_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles raiseShowRecord.Click
            Try
                If Not IsNothing(clsSession.GlbFulltextPages) Then
                    Dim dt As DataTable = Nothing
                    dt = clsSession.GlbFulltextPages
                    Call showBooks(dt, hidSearchContent.Value)
                End If
            Catch ex As Exception
            End Try
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBOPACFile Is Nothing Then
                    objBOPACFile.Dispose(True)
                    objBOPACFile = Nothing
                End If
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
