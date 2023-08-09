Imports eMicLibOPAC.BusinessRules.OPAC

Namespace eMicLibOPAC.WebUI.OPAC
    Public Class OViewerMagazineBrowseIssue
        Inherits clsWBase ' System.Web.UI.Page

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
                Else
                    hidYear.Value = 0
                End If
                Call loadYears(docId.Value, hidYear.Value)
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

        Private Sub loadMagazineNumber(ByVal docId As Integer, ByVal year As Integer)
            Try
                objBeMagazine.ItemID = docId
                objBeMagazine.eYear = year
                Dim magNumber As DataTable = objBeMagazine.GetMagazineNumberDetailByYear(1, 1000)
                If Not IsNothing(magNumber) AndAlso magNumber.Rows.Count > 0 Then
                    Dim tblCell As TableCell
                    Dim tblRow As TableRow
                    Dim ul As HtmlGenericControl
                    Dim li As HtmlGenericControl
                    Dim img As System.Web.UI.WebControls.Image
                    tblRow = New TableRow
                    tblCell = New TableCell
                    With tblCell
                        .Width = Unit.Percentage(100)
                    End With
                    Dim strYear As String = ""
                    'Dim i As Integer = 1
                    ul = New HtmlGenericControl("ul")
                    With ul
                        .ID = "Gallery"
                        .Attributes.Add("class", "gallery")
                    End With
                    Dim magId As Integer = 0
                    Dim strThumnail As String = ""
                    Dim strDate As String = ""
                    For i As Integer = 0 To magNumber.Rows.Count - 1
                        If Not IsDBNull(magNumber.Rows(i).Item("MagId")) Then
                            If magId <> magNumber.Rows(i).Item("MagId") Then
                                strThumnail = ""
                                If Not IsDBNull(magNumber.Rows(i).Item("Thumnail")) AndAlso magNumber.Rows(i).Item("Thumnail") <> "" Then
                                    strThumnail = Me.ChangeMapVirtualPath(magNumber.Rows(i).Item("Thumnail"))
                                End If
                                img = New System.Web.UI.WebControls.Image
                                With img
                                    .ID = "img" & i.ToString
                                    .Attributes.Add("OnClick", "gotoViewerNumber(" & magNumber.Rows(i).Item("MagId") & "," & docId & "," & year & ");")
                                    'strThumnail = Replace(strThumnail, "\", "/")
                                    'strThumnail = Replace(strThumnail.ToLower, _XMLViewer_physicalPath.ToLower, _XMLViewer_VirtualPath)
                                    .ImageUrl = strThumnail
                                    .Style.Value = "cursor:pointer"
                                End With

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

                                li = New HtmlGenericControl("li")
                                With li
                                    .ID = "li" & i.ToString
                                    If i > 4 Then
                                        .InnerHtml = "<p>&nbsp;</p><span style='background-color:black;color:#fff'>" & magNumber.Rows(i).Item("eNum").ToString & strDate & "</span>"
                                    Else
                                        .InnerHtml = "<span style='background-color:black;color:#fff'>" & magNumber.Rows(i).Item("eNum").ToString & strDate & "</span>"
                                    End If
                                    .Controls.Add(img)
                                End With
                                With ul
                                    .Controls.Add(li)
                                End With
                            End If
                            magId = magNumber.Rows(i).Item("MagId")
                        End If
                    Next
                    tblCell.Controls.Add(ul)
                    tblRow.Cells.Add(tblCell)
                    imgList.Rows.Add(tblRow)
                End If
                If Not IsNothing(magNumber) Then
                    magNumber = Nothing
                End If
            Catch ex As Exception
            End Try
        End Sub

        Private Sub loadYears(ByVal docId As Integer, ByVal year As Integer)
            Try
                objBeMagazine.ItemID = docId
                Dim magNumber As DataTable = objBeMagazine.GetYearMagazineNumberByItemID
                If Not IsNothing(magNumber) AndAlso magNumber.Rows.Count > 0 Then
                    Dim tblCell As TableCell
                    Dim tblRow As TableRow
                    Dim p As HtmlGenericControl
                    tblRow = New TableRow
                    tblCell = New TableCell
                    With tblCell
                        .Width = Unit.Percentage(100)
                    End With
                    Dim strYear As String = ""
                    'Dim i As Integer = 1
                    For i As Integer = 0 To magNumber.Rows.Count - 1
                        If i = magNumber.Rows.Count - 1 Then
                            If year = 0 Then
                                year = magNumber.Rows(i).Item("eYear")
                            End If
                        End If
                        strYear = magNumber.Rows(i).Item("eYear")
                        p = New HtmlGenericControl("p")
                        With p
                            .ID = "P" & i.ToString
                            If year = strYear Then
                                .InnerHtml = "<span style='background-color:black;color:#fff'>" & strYear & "</span>"
                            Else
                                .InnerHtml = "<a href=""javascript:getMagNumByYear(" & strYear & ")""><span>" & strYear & "</span></a>"
                            End If
                        End With
                        tblCell.Controls.Add(p)
                        i += 1
                    Next
                    tblRow.Cells.Add(tblCell)
                    tbYearBrowseIssue.Rows.Add(tblRow)

                    Call loadMagazineNumber(docId, year)
                End If
                If Not IsNothing(magNumber) Then
                    magNumber = Nothing
                End If
            Catch ex As Exception
            End Try
        End Sub

        Protected Sub raiseBrowseIssue_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles raiseBrowseIssue.Click
            Call loadYears(docId.Value, hidYear.Value)
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
