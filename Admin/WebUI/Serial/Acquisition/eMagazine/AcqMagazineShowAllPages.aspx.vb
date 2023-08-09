Imports eMicLibAdmin.BusinessRules.Serial
Imports eMicLibAdmin.WebUI.Common

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class eMagazine_AcqMagazineShowAllPages
        Inherits clsWBase
        Private objBMagazine As New clsBMagazine

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Initialize()
            Call BindScript()
            If Not IsPostBack Then
                If Not Request("MagId") Is Nothing AndAlso Request("MagId") <> "" Then
                    hidMagId.Value = Request("MagId")
                End If
                Call loadMagazineNumber(hidMagId.Value)
            End If
        End Sub


        ' BindScript method
        Private Sub BindScript()
            'Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init for objBPeriodicalCollection
            objBMagazine.InterfaceLanguage = Session("InterfaceLanguage")
            objBMagazine.DBServer = Session("DBServer")
            objBMagazine.ConnectionString = Session("ConnectionString")
            objBMagazine.Initialize()
        End Sub

        Private Sub loadMagazineNumber(ByVal MagId As Integer)
            Try
                Dim tblItem As New DataTable
                objBMagazine.MagId = MagId
                tblItem = objBMagazine.getMagazineDetailByMagID
                If Not IsNothing(tblItem) AndAlso tblItem.Rows.Count > 0 Then
                    Dim tblCell As TableCell
                    Dim tblRow As TableRow
                    Dim img As System.Web.UI.WebControls.Image
                    tblRow = New TableRow
                    tblCell = New TableCell
                    With tblCell
                        .Width = Unit.Percentage(100)
                    End With
                    Dim tempThumnail As String = ""
                    'Dim _XMLViewer_physicalPath As String = Replace(clsWCommon._XMLViewer_physicalPath, "\", "/")
                    'Dim _XMLViewer_VirtualPath As String = clsWCommon._XMLViewer_VirtualPath
                    For i As Integer = 0 To tblItem.Rows.Count - 1
                        img = New System.Web.UI.WebControls.Image
                        With img
                            .ID = "img" & tblItem.Rows(i).Item("Id").ToString
                            .Attributes.Add("OnClick", "gotoPages(" & tblItem.Rows(i).Item("PageNum") & ");")
                            tempThumnail = ""
                            If Not IsDBNull(tblItem.Rows(i).Item("Thumnail")) Then
                                tempThumnail = tblItem.Rows(i).Item("Thumnail")
                            End If
                            'tempThumnail = Replace(tempThumnail, "\", "/")
                            'tempThumnail = Replace(tempThumnail.ToLower, _XMLViewer_physicalPath.ToLower, _XMLViewer_VirtualPath)
                            tempThumnail = ChangeMapVirtualPath(tempThumnail)
                            .ImageUrl = tempThumnail
                            .Style.Value = "cursor:pointer"
                            .Attributes.Add("alt", tblItem.Rows(i).Item("FileName").ToString)
                        End With
                        tblCell.Controls.Add(img)
                    Next
                    tblRow.Cells.Add(tblCell)
                    imgList.Rows.Add(tblRow)
                End If

                'Dim procs As New BusinessLayer.Acquisition
                'Dim magNumber As IList = procs.Select_cat_magazine_number_detail(MagId)
                'If Not magNumber Is Nothing AndAlso magNumber.Count > 0 Then

                'End If
                'If Not IsNothing(magNumber) Then
                '    magNumber = Nothing
                'End If
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
                If Not objBMagazine Is Nothing Then
                    objBMagazine.Dispose(True)
                    objBMagazine = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace

