Namespace eMicLibOPAC.WebUI
    Public Class OViewLoading
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Try
                Dim fileId As Integer = 0
                Dim pageno As Integer = 0
                Dim ItemID As Integer = 0
                Dim fileType As Integer = 0
                Dim fulltext As String = ""
                Dim subjectId As Integer = 0
                Dim search As Integer = 0
                Dim collectionIds As String = "0"
                If Not IsNothing(Request("search")) AndAlso Request("search") <> "" Then
                    search = Request("search")
                End If
                If Not IsNothing(Request("fileId")) AndAlso Request("fileId") <> "" Then
                    fileId = Request("fileId")
                End If
                If Not IsNothing(Request("pageno")) AndAlso Request("pageno") <> "" Then
                    pageno = Request("pageno")
                End If
                If Not IsNothing(Request("ItemID")) AndAlso Request("ItemID") <> "" Then
                    ItemID = Request("ItemID")
                End If
                If Not IsNothing(Request("fileType")) AndAlso Request("fileType") <> "" Then
                    fileType = Request("fileType")
                End If
                If Not IsNothing(Request("fulltext")) AndAlso Request("fulltext") <> "" Then
                    fulltext = Request("fulltext")
                End If
                If Not IsNothing(Request("subjectId")) AndAlso Request("subjectId") <> "" Then
                    subjectId = Request("subjectId")
                End If
                If Not IsNothing(Request("collectionId")) AndAlso Request("collectionId") <> "" Then
                    collectionIds = Request("collectionId")
                End If

                If Not clsUICommon.checkPermission() Then
                    Dim collViewer As New Collection
                    With collViewer
                        .Add(search, "search")
                        .Add(fileId, "fileId")
                        .Add(pageno, "pageno")
                        .Add(ItemID, "ItemID")
                        .Add(fileType, "fileType")
                        .Add(fulltext, "fulltext")
                        .Add(subjectId, "subjectId")
                        .Add(collectionIds, "collectionId")
                    End With
                    clsSession.GlbViewerCollection = collViewer
                    Response.Redirect("OLoginRequest.aspx?viewer=1", False)
                Else
                    Select Case fileType
                        Case clsUICommon.gFileType.eDocument
                            Response.Redirect(String.Format("OViewBook.aspx?search={0}&pageno={1}&ItemID={2}&fileId={3}&fileType={4}&subjectId={5}&collectionId={6}&fulltext={7}", search, pageno, ItemID, fileId, fileType, subjectId, collectionIds, fulltext), False)
                            If Not String.IsNullOrEmpty(fulltext) Then
                                'Response.Redirect(String.Format("~/" & clsUICommon.gUrlRewrite_URLView2 & "/{0}/{1}/{2}/{3}/{4}/{5}/{6}/{7}/", search, docId, fileType, fileId, pageno, subjectId, fulltext, collectionIds), False)
                            Else
                                'Response.Redirect(String.Format("~/" & clsUICommon.gUrlRewrite_URLView1 & "/{0}/{1}/{2}/{3}/{4}/{5}/{6}/", search, docId, fileType, fileId, pageno, subjectId, collectionIds), False)
                            End If
                        Case clsUICommon.gFileType.eMedia, clsUICommon.gFileType.eSound, clsUICommon.gFileType.ePicture
                            Response.Redirect(String.Format("OView.aspx?fileId={0}&ItemID={1}&fileType={2}&subjectId={3}&collectionId={4}", fileId, ItemID, fileType, subjectId, collectionIds), False)
                        Case clsUICommon.gFileType.eOther
                        Case clsUICommon.gFileType.eExe
                        Case clsUICommon.gFileType.eSound
                        Case Else
                            Response.Redirect("OError.aspx")
                    End Select
                End If
            Catch ex As Exception
                Response.Redirect("OError.aspx?err=" & ex.Message)
            End Try
        End Sub

    End Class
End Namespace
