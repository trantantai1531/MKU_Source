Imports eMicLibOPAC.BusinessRules.OPAC

Namespace eMicLibOPAC.WebUI.OPAC
    Public Class OZ3950ServerList
        Inherits clsWBaseJqueryUI ' clsWBase
        Private objBZdbs As New clsBOPACZ3950Client

        ' Event : Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJavascript()
            If Not IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            Response.Expires = 0
            'Init objBZdbs object
            objBZdbs.InterfaceLanguage = Session("InterfaceLanguage")
            objBZdbs.DBServer = Session("DBServer")
            objBZdbs.ConnectionString = Session("ConnectionString")
            Call objBZdbs.Initialize()
        End Sub

        ' BindData method
        ' Purpose: Create Z3950 server list
        Private Sub BindData()
            Try
                Dim strResult As String = ""
                Dim tblTemp As DataView = objBZdbs.GetZServerList.DefaultView
                strResult = getServerList(tblTemp)
                ltrServerList.Text = strResult
            Catch ex As Exception
            End Try
        End Sub
        ' BindJavascript method
        ' Include all neccessary javascript function
        Public Sub BindJavascript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = 'Common/eMicLibCommon.js'></script>")
            Page.RegisterClientScriptBlock("WZFindJs", "<script language = 'javascript' src = 'Js/Z3950/OZ3950Show.js'></script>")
        End Sub

        ' getDictionaryString method
        ' Purpose: get objects string to into browse
        Private Function getServerList(ByVal dv As DataView) As String
            Dim strResult As String = ""
            Try
                If Not IsNothing(dv) AndAlso dv.Count > 0 Then
                    Dim iCount As Integer = 0
                    Dim intCurPage As Integer
                    Dim intCount As Integer = 0
                    Dim intSumPage As Integer
                    Dim intStart, intStop As Integer
                    Dim colSearch As New Collection
                    Dim intSumResult As Integer = 0
                    Dim strSelectTop As String = ""
                    Dim intTotal As Integer = dv.Count
                    Dim intPagezise As Integer = 5 ' Application("ePageSize")
                    Dim intPageLength As Integer = Application("ePageLength")
                    Dim intPageSpace As Integer = Application("ePageSpace")
                    intSumPage = (intTotal - 1) \ intPagezise + 1
                    intCurPage = hidCurrentPage.Value

                    intStart = (intCurPage - 1) * intPagezise
                    intStop = (((intCurPage - 1) * intPagezise) + intPagezise) - 1
                    If intStart > intTotal - 1 Then
                        intStart = intTotal - 1
                    End If
                    If intStop > intTotal - 1 Then
                        intStop = intTotal - 1
                    End If
                    Call showPagingControl(intTotal, intPagezise, intCurPage, intPageSpace, intPageLength, intStop)


                    'strResult &= "<div>"
                    'strResult &= "<div class='listview-outlook' data-role='listview'>"
                    'For intCount = intStart To intStop
                    '    strResult &= "<a class='list' onclick=""" & dv.Item(intCount).Row("LoadBack") & """>"
                    '    strResult &= "<div class='list-content'>" 'list-title
                    '    strResult &= "<span class='list-title' title='" & dv.Item(intCount).Row("Name") & "'>"
                    '    strResult &= (intCount + 1).ToString & ". " & dv.Item(intCount).Row("Name")
                    '    strResult &= "</span>"
                    '    strResult &= "</div>"
                    '    strResult &= "</a>"
                    'Next

                    'strResult &= "</div>" 'Close data-role='listview'
                    'strResult &= "</div>" 'Close div class='span4'

                    For intCount = intStart To intStop
                        strResult &= "<div>"
                        strResult &= "<li><span>" & (intCount + 1).ToString & ".</span><a onclick=""" & dv.Item(intCount).Row("LoadBack") & """   style='cursor:pointer;'>" & dv.Item(intCount).Row("Name") & "</a></li>"
                        strResult &= "</div>" 'Close div class='span4'
                    Next
                    
                End If
            Catch ex As Exception
                strResult = ""
            End Try
            If strResult = "" Then
                strResult = ""
                lrtPagination1.Visible = False
                lrtPagination2.Visible = False
            Else
                lrtPagination1.Visible = True
                lrtPagination2.Visible = True
            End If
            Return strResult
        End Function

        '' purpose :  show paging as google paging
        '' Creator: phuongtt
        'Private Sub showPagingControl(ByVal intCount As Integer, ByVal intPagezise As Integer, ByVal intPage As Integer, ByVal intPageSpace As Integer, ByVal intPageLength As Integer, ByVal intStop As Integer)
        '    Try
        '        Dim iPage As Integer = CInt((intCount / intPagezise) + 0.4999)
        '        Dim strPagination As String = ""
        '        Dim PreviousPage As Integer = intPage - 1
        '        Dim NextPage As Integer = intPage + 1
        '        If PreviousPage >= 1 Then
        '            strPagination &= "<li class='prev'><a onclick='showRecordByPage(" & PreviousPage.ToString & ")' data-hint='|" & spPreviousPage.InnerText & "' data-hint-position='top'><i class='icon-previous' style='padding:1px;'></i></a></li>"
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
        '            strPagination &= "<a onclick='showRecordByPage(" & j.ToString & ")'>" & j.ToString & "</a><li>"
        '        Next
        '        If NextPage <= iPage Then
        '            strPagination &= "<li class='next'><a onclick='showRecordByPage(" & NextPage.ToString & ")' data-hint='|" & spNextPage.InnerText & "' data-hint-position='top'><i class='icon-next' style='padding:1px;'></i></a></li>"
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
        '        lrtPagination1.Text &= strItemInfo
        '        lrtPagination2.Text &= strItemInfo
        '    Catch ex As Exception
        '    End Try
        'End Sub

        ' purpose :  show paging as google paging
        ' Creator: phuongtt
        Private Sub showPagingControl(ByVal intCount As Integer, ByVal intPagezise As Integer, ByVal intPage As Integer, ByVal intPageSpace As Integer, ByVal intPageLength As Integer, ByVal intStop As Integer)
            Try
                Dim iPage As Integer = CInt((intCount / intPagezise) + 0.4999)
                Dim strPagination As String = ""
                Dim PreviousPage As Integer = intPage - 1
                Dim NextPage As Integer = intPage + 1
                If PreviousPage >= 1 Then
                    strPagination &= "<li><a onclick='showRecordByPage(" & PreviousPage.ToString & ")' data-hint='|" & spPreviousPage.InnerText & "' data-hint-position='top' style='cursor:pointer;'><</a></li>"
                End If
                Dim xy As Integer = CInt((intPage / intPageSpace) + 0.4999)
                Dim alpha As Integer = (xy - 1) * intPageSpace
                Dim iPageCount As Integer = IIf(intPageLength + alpha <= iPage, intPageLength + alpha, iPage)

                For j As Integer = 1 + alpha To iPageCount
                    strPagination &= "<li>"
                    If j = intPage Then
                        strPagination &= "<a onclick='showRecordByPage(" & j.ToString & ")' class='PageSeleted'  style='cursor:pointer;'>" & j.ToString & "</a>"
                    Else
                        strPagination &= "<a onclick='showRecordByPage(" & j.ToString & ")'  style='cursor:pointer;'>" & j.ToString & "</a>"
                    End If
                    strPagination &= "</li>"
                Next
                If NextPage <= iPage Then
                    strPagination &= "<li><a onclick='showRecordByPage(" & NextPage.ToString & ")' data-hint='|" & spNextPage.InnerText & "' data-hint-position='top'  style='cursor:pointer;'>></a></li>"
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
                Dim intCurrenPage As Integer = hidCurrentPage.Value
                Call BindData()
                'Dim dv As DataView = objBZdbs.GetZServerList.DefaultView
                'If Not IsNothing(clsSession.GlbBrowseIds) Then
                '    dv = clsSession.GlbBrowseIds
                'Else
                '    dv = clsSession.GlbBrowseIds
                'End If
                'ltrServerList.Text = getServerList(dv)
            Catch ex As Exception
            End Try
        End Sub

        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose()
        End Sub

        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBZdbs Is Nothing Then
                    objBZdbs.Dispose(True)
                    objBZdbs = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        
    End Class
End Namespace
