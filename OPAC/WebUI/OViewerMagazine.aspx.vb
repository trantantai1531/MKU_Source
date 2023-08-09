Imports eMicLibOPAC.BusinessRules.OPAC

Namespace eMicLibOPAC.WebUI.OPAC
    Public Class OViewerMagazine
        Inherits System.Web.UI.Page

        Private objBeMagazine As New clsBOPACeMagazine

        Private Sub loadMagazineNumber(ByVal MagId As Integer, ByVal MagPage As Integer)
            Try
                objBeMagazine.MagID = MagId
                Dim magNumber As DataTable = objBeMagazine.GetMagazineNumberDetailByMagID
                If Not IsNothing(magNumber) AndAlso magNumber.Rows.Count > 0 Then
                    hidMagPageCount.Value = magNumber.Rows.Count
                    For i As Integer = 0 To magNumber.Rows.Count - 1
                        If magNumber.Rows(i).Item("PageNum").ToString = MagPage.ToString Then
                            hidMagFilePath.Value = Replace(magNumber.Rows(i).Item("XMLpath").ToString, "\", "/")
                            hidMagDetailId.Value = magNumber.Rows(i).Item("Id")
                            Exit For
                        End If
                    Next
                End If
            Catch ex As Exception
            End Try
        End Sub


        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Call checkPermission()
            Call Initialize()
            Call BindScript()
            Try
                If Not Page.IsPostBack Then
                    hidIIPServer.Value = Application("IIPServer")
                    If Not Request("MagId") Is Nothing AndAlso Request("MagId") <> "" Then
                        hidMagId.Value = Request("MagId")
                    End If
                    If Not Request("ItemID") Is Nothing AndAlso Request("ItemID") <> "" Then
                        hidDocId.Value = Request("ItemID")
                    End If
                    If Not Request("page") Is Nothing AndAlso Request("page") <> "" Then
                        hidMagPage.Value = Request("page")
                    End If
                    If Not Request("X") Is Nothing AndAlso Request("X") <> "" Then
                        hidCoordinatesX.Value = Request("X")
                    End If
                    If Not Request("Y") Is Nothing AndAlso Request("Y") <> "" Then
                        hidCoordinatesY.Value = Request("Y")
                    End If
                    If Not Request("year") Is Nothing AndAlso Request("year") <> "" Then
                        hidYear.Value = Request("year")
                    End If
                    'Call CheckSercretLevel(hidDocId.Value)
                    Call loadMagazineNumber(hidMagId.Value, hidMagPage.Value)
                    pageInfo.InnerText = span_page.InnerText & Space(1) & hidMagPage.Value & "/" & hidMagPageCount.Value
                    'Call setMetadata()
                    'Call Update_View(hidDocId.Value)
                End If
            Catch ex As Exception
            End Try
        End Sub

        Private Sub checkPermission()
            Try
                Dim MagId As Integer = 0
                Dim ItemID As Integer = 0
                Dim pageNo As Integer = 1
                If Not IsNothing(Request("MagId")) AndAlso Request("MagId") <> "" Then
                    MagId = Request("MagId")
                End If
                If Not IsNothing(Request("ItemID")) AndAlso Request("ItemID") <> "" Then
                    ItemID = Request("ItemID")
                End If
                If Not IsNothing(Request("page")) AndAlso Request("page") <> "" Then
                    pageNo = Request("page")
                End If
                If Not clsUICommon.checkPermission() Then
                    Dim collViewer As New Collection
                    With collViewer
                        .Add(MagId, "MagId")
                        .Add(ItemID, "ItemID")
                        .Add(pageNo, "pageno")
                    End With
                    clsSession.GlbViewerCollection = collViewer
                    Response.Redirect("OLoginRequest.aspx?viewer=2", False)
                End If
            Catch ex As Exception
            End Try
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

        'Private Sub Update_View(ByVal _DocID As Integer)
        '    Try
        '        Dim procs As New BusinessLayer.eMagazine
        '        Dim bol As Boolean = procs.Update_Magazine_views(_DocID)
        '        If Not IsNothing(procs) Then
        '            procs = Nothing
        '        End If
        '    Catch ex As Exception : End Try
        'End Sub

        'Private Sub CheckSercretLevel(ByVal docId As Integer)
        '    Try
        '        Dim procs As New BusinessLayer.eMagazine
        '        Dim intSercretLevel As Integer = procs.selectSercretLevel(docId)
        '        If Not clsCommon.checkSecurityLevel(intSercretLevel) Then
        '            Response.Redirect("Index.aspx")
        '        End If
        '    Catch ex As Exception
        '    End Try
        'End Sub

        'Private Sub setMetadata(Optional ByVal strBookTitle As String = "")
        '    Try
        '        Page.Title = "Xem báo in trực tuyến: " & strBookTitle
        '        Page.MetaDescription = "Trang xem báo in trực tuyến"
        '        Page.MetaKeywords = "Xem báo in trực tuyến, xem bao in truc tuyen"
        '    Catch ex As Exception
        '    End Try
        'End Sub

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
