Imports eMicLibOPAC.BusinessRules.OPAC

Namespace eMicLibOPAC.WebUI.OPAC
    Public Class OMagList
        Inherits clsWBaseJqueryUI

        Private objBeMagazine As New clsBOPACeMagazine

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Call Initialize()
            Call BindScript()
            If Not IsPostBack Then
                If Not Request("ItemID") Is Nothing AndAlso Request("ItemID") <> "" Then
                    docId.Value = Request("ItemID")
                End If
                If Not Request("year") Is Nothing AndAlso Request("year") <> "" Then
                    hidYear.Value = Request("year")
                End If
                If Not Request("page") Is Nothing AndAlso Request("page") <> "" Then
                    hidPage.Value = Request("page")
                End If
                Call loadYears(docId.Value, hidYear.Value, hidPage.Value)
            End If
        End Sub
        ' Init method
        ' purpose initialize all components
        Private Sub Initialize()
            ' Init objBHoldingInfo object
            objBeMagazine.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBeMagazine.DBServer = Session("DBServer")
            objBeMagazine.ConnectionString = Session("ConnectionString")
            Call objBeMagazine.Initialize()
        End Sub

        ' BindScript method
        ' Purpose: Bind JAVASCRIPTS
        Private Sub BindScript()
            'Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = 'js/OShow.js'></script>")
        End Sub

        Private Sub loadYears(ByVal docId As Integer, ByVal year As Integer, ByVal page As Integer)
            Try
                objBeMagazine.ItemID = docId
                Dim magNumber As DataTable = objBeMagazine.GetYearMagazineNumberByItemID
                If Not IsNothing(magNumber) AndAlso magNumber.Rows.Count > 0 Then
                    Dim strOptions As String = ""
                    Dim strYear As String = ""
                    Dim strTitle As String = ""
                    strOptions &= "<select onChange=""showYear(" & docId.ToString & ",this)"">"
                    For i As Integer = 0 To magNumber.Rows.Count - 1
                        If i = magNumber.Rows.Count - 1 Then
                            If year = 0 Then
                                year = magNumber.Rows(i).Item("eYear")
                            End If
                            strTitle = magNumber.Rows(i).Item("Content")
                        End If
                        strYear = magNumber.Rows(i).Item("eYear")

                        If year = strYear Then
                            strOptions &= "<option value=""" & strYear.ToString & """ selected>" & strYear.ToString & "</option>"
                        Else
                            strOptions &= "<option value=""" & strYear.ToString & """>" & strYear.ToString & "</option>"
                        End If
                    Next
                    strOptions &= "</select>"

                    ltrTitle.Text = strTitle

                    ltrYear.Text = strOptions

                    Call loadMagazineNumber(docId, year, page)
                End If
                If Not IsNothing(magNumber) Then
                    magNumber = Nothing
                End If
            Catch ex As Exception
            End Try
        End Sub

        Private Sub loadMagazineNumber(ByVal docId As Integer, ByVal year As Integer, ByVal page As Integer)
            Dim intPagezise As Integer = Application("eMagazinePageSize")
            Dim intPageLength As Integer = Application("eMagazinePageLength")
            Dim intPageSpace As Integer = Application("eMagazinePageSpace")
            Try
                objBeMagazine.ItemID = docId
                objBeMagazine.eYear = year
                Dim magNumber As DataTable = objBeMagazine.GetMagazineNumberDetailByYear(page, intPagezise)
                If Not IsNothing(magNumber) AndAlso magNumber.Rows.Count > 0 Then
                    Dim iCount As Integer = magNumber.Rows.Count
                    Dim strYear As String = ""
                    'Dim i As Integer = 1
                    Dim intId As Integer = 1
                    Dim magId As Integer = 0
                    Dim strThumnail As String = ""
                    Dim strDate As String = ""
                    Dim intSercretLevel As Integer = 0
                    Dim intInfo As Integer = 1
                    If IsNothing(clsSession.GlbUser) OrElse String.IsNullOrEmpty(clsSession.GlbUser) Then
                        intInfo = 2
                    End If
                    Dim strResult As String = ""
                    For i As Integer = 0 To iCount - 1
                        If Not IsDBNull(magNumber.Rows(i).Item("MagId")) Then
                            If magId <> magNumber.Rows(i).Item("MagId") Then
                                intSercretLevel = magNumber.Rows(i).Item("SercretLevel")
                                strDate = ""
                                If Not IsDBNull(magNumber.Rows(i).Item("eDay")) Then
                                    strDate &= magNumber.Rows(i).Item("eDay")
                                End If
                                If Not IsDBNull(magNumber.Rows(i).Item("eMonth")) Then
                                    strDate &= "/" & magNumber.Rows(i).Item("eMonth")
                                End If
                                If strDate <> "" Then
                                    strDate &= "/" & year
                                    strDate = " (" & strDate & ")"
                                End If

                                Title = magNumber.Rows(i).Item("eNum") & " - " & strDate
                                'If clsCommon.checkSecurityLevel(intSercretLevel) Then
                                '    Title = proc.eNum.ToString & " - " & strDate
                                'Else
                                '    Title = "<span class='icon-locked'></span>" & proc.eNum.ToString & " - " & strDate
                                'End If

                                strThumnail = ""
                                If Not IsDBNull(magNumber.Rows(i).Item("Thumnail")) AndAlso magNumber.Rows(i).Item("Thumnail") <> "" Then
                                    strThumnail = Me.ChangeMapVirtualPath(magNumber.Rows(i).Item("Thumnail"))
                                End If

                                strResult &= "<article class=""list-item unit5"">" ' onClick='" & "javascript:gotoViewer(" & CInt(magNumber.Rows(i).Item("MagId")) & "," & docId & ")'>"
                                strResult &= "<div class=""item-lesson box-raised"">"
                                strResult &= "<a href=""javascript:gotoViewer(" & CInt(magNumber.Rows(i).Item("MagId")) & "," & docId & ")"">"
                                'strResult &= "<h2 class=""clr-cyan""><span>" & Title & "</span></h2>"
                                strResult &= "<div class=""img-box""><img src='" & strThumnail & "'  alt='" & strThumnail & "'/></div>"
                                strResult &= "<div class=""more-detail ClearFix"">"
                                strResult &= "<h3 class=""news-image"">" & Title & "</h3>"
                                strResult &= "</div>"
                                strResult &= "</a>"
                                strResult &= "</div>" 'box-raised
                                strResult &= "</article>" 'article
                            End If
                            magId = magNumber.Rows(i).Item("MagId")
                        End If
                    Next

                    ltrContents.Text = strResult

                    objBeMagazine.ItemID = docId
                    objBeMagazine.eYear = year
                    iCount = objBeMagazine.GetMagazineNumberDetailCount
                    Dim iPage As Integer = CInt((iCount / intPagezise) + 0.4999)
                    If iPage > 1 Then
                        Dim strPagination As String = ""
                        Dim PreviousPage As Integer = page - 1
                        Dim NextPage As Integer = page + 1
                        If PreviousPage >= 1 Then
                            strPagination &= "<li><a href='OMagList.aspx?ItemID=" & docId & "&year=" & year & "&page=" & PreviousPage.ToString & "'><</a></li>"
                        End If
                        Dim xy As Integer = CInt((page / intPageSpace) + 0.4999)
                        Dim alpha As Integer = (xy - 1) * intPageSpace
                        Dim iPageCount As Integer = IIf(intPageLength + alpha <= iPage, intPageLength + alpha, iPage)

                        For j As Integer = 1 + alpha To iPageCount
                            strPagination &= "<li>"
                            If j = page Then
                                strPagination &= "<a href='OMagList.aspx?ItemID=" & docId & "&year=" & year & "&page=" & j.ToString & "' class='PageSeleted'  style='cursor:pointer;'>" & j.ToString & "</a>"
                            Else
                                strPagination &= "<a href='OMagList.aspx?ItemID=" & docId & "&year=" & year & "&page=" & j.ToString & "' style='cursor:pointer;'>" & j.ToString & "</a>"
                            End If
                            strPagination &= "</li>"
                        Next
                        If NextPage <= iPage Then
                            strPagination &= "<li><a href='OMagList.aspx?ItemID=" & docId & "&year=" & year & "&page=" & NextPage.ToString & "'>></a></li>"
                        End If
                        lrtPagination.Text = strPagination
                    End If

                End If
                If Not IsNothing(magNumber) Then
                    magNumber = Nothing
                End If
            Catch ex As Exception
            End Try
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub
        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBeMagazine Is Nothing Then
                    objBeMagazine.Dispose(True)
                    objBeMagazine = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
