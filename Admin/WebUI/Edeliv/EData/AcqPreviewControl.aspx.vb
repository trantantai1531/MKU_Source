
Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class Pages_AcqPreviewControl
        Inherits clsWBase
        Protected Sub ToolBar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolBar.Load
            Call AddItems()
        End Sub
        Private Sub AddItems()
            ToolBar.Items.Clear()
            Dim _int As Integer = 0
            Dim newItem As ComponentArt.Web.UI.ToolBarItem
            If Not Request("id") Is Nothing AndAlso Not Request("id") = "" Then
                newItem = New ComponentArt.Web.UI.ToolBarItem
                With newItem
                    .Text = span_Toolbar_item0.InnerText
                    .Value = "openrecord"
                    .ImageUrl = "open_record.png"
                End With
                ToolBar.Items.Insert(_int, newItem)
                _int += 1
            End If
            newItem = New ComponentArt.Web.UI.ToolBarItem
            With newItem
                .ItemType = ComponentArt.Web.UI.ToolBarItemType.Separator
                .Width = 1
            End With
            ToolBar.Items.Insert(_int, newItem)
            _int += 1

            newItem = New ComponentArt.Web.UI.ToolBarItem
            With newItem
                .Text = span_Toolbar_item1.InnerText
                .Value = "close"
                .ImageUrl = "dialog-close.png"
            End With
            ToolBar.Items.Insert(_int, newItem)
        End Sub
    End Class
End Namespace

