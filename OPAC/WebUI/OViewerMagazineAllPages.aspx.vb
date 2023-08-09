Imports eMicLibOPAC.BusinessRules.OPAC

Namespace eMicLibOPAC.WebUI.OPAC
    Public Class OViewerMagazineAllPages
        Inherits clsWBase 'System.Web.UI.Page

        Private objBeMagazine As New clsBOPACeMagazine

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Call Initialize()
            Call BindScript()
            If Not IsPostBack Then
                If Not Request("MagId") Is Nothing AndAlso Request("MagId") <> "" Then
                    hidMagId.Value = Request("MagId")
                End If
                If Not Request("ItemID") Is Nothing AndAlso Request("ItemID") <> "" Then
                    hidDocId.Value = Request("ItemID")
                End If
                If Not Request("year") Is Nothing AndAlso Request("year") <> "" Then
                    hidYear.Value = Request("year")
                Else
                    hidYear.Value = 0
                End If
                Call loadMagazineNumber(hidMagId.Value)
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

        Private Sub loadMagazineNumber(ByVal MagId As Integer)
            Try
                objBeMagazine.MagID = MagId
                Dim magNumber As DataTable = objBeMagazine.GetMagazineNumberDetailByMagID
                If Not IsNothing(magNumber) AndAlso magNumber.Rows.Count > 0 Then
                    Dim tblCell As TableCell
                    Dim tblRow As TableRow
                    Dim img As System.Web.UI.WebControls.Image
                    tblRow = New TableRow
                    tblCell = New TableCell
                    With tblCell
                        .Width = Unit.Percentage(100)
                    End With
                    Dim tempThumnail As String = ""
                    For i As Integer = 0 To magNumber.Rows.Count - 1
                        img = New System.Web.UI.WebControls.Image
                        With img
                            .ID = "img" & magNumber.Rows(i).Item("id").ToString
                            .Attributes.Add("OnClick", "gotoPages(" & magNumber.Rows(i).Item("PageNum").ToString & ");")
                            tempThumnail = ""
                            If Not IsDBNull(magNumber.Rows(i).Item("Thumnail")) Then
                                tempThumnail = Me.ChangeMapVirtualPath(magNumber.Rows(i).Item("Thumnail").ToString)
                            End If
                            'tempThumnail = proc.Thumnail.ToString
                            'tempThumnail = Replace(tempThumnail, "\", "/")
                            'tempThumnail = Replace(tempThumnail.ToLower, _XMLViewer_physicalPath.ToLower, _XMLViewer_VirtualPath)
                            .ImageUrl = tempThumnail
                            .Style.Value = "cursor:pointer"
                            .Attributes.Add("alt", magNumber.Rows(i).Item("FileName").ToString)
                        End With
                        tblCell.Controls.Add(img)
                    Next
                    tblRow.Cells.Add(tblCell)
                    imgList.Rows.Add(tblRow)
                End If
                If Not IsNothing(magNumber) Then
                    magNumber = Nothing
                End If
            Catch ex As Exception
            End Try
        End Sub

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
