Imports ComponentArt.Web.UI
'Imports Common.FDataType
'Imports Common.FMessage
Imports eMicLibAdmin.WebUI.Common
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class Pages_AcqCreateCollectionControl
        Inherits clsWBase

        Protected Sub ToolBar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolBar.Load
            Call ChangeLanguage()
            Call EnableToolbar()
        End Sub

        Private Sub EnableToolbar()
            Try
                Dim strLang As String = "vie"
                Call VisibleToolBarItem(ToolBarItem5, clsWCommon.MAIN_TOOLBAR.catRecordManagement, "New", clsWCommon.COM_MESS(clsWCommon.COM_INFO._New, strLang), "Acquisition.png", "Acquisition.png", Separator5, , , strLang)
                Call VisibleToolBarItem(ToolBarItem3, clsWCommon.MAIN_TOOLBAR.catRecordManagement, "Edit", clsWCommon.COM_MESS(clsWCommon.COM_INFO._Edit, strLang), "Modify.png", "Modify.png", Separator3, , , strLang)
                Call VisibleToolBarItem(ToolBarItem4, clsWCommon.MAIN_TOOLBAR.catRecordManagement, "Delete", clsWCommon.COM_MESS(clsWCommon.COM_INFO._Delete, strLang), "RecycleBin.png", "RecycleBin.png", Separator4, , , strLang)
                Call VisibleToolBarItem(ToolBarItem7, clsWCommon.MAIN_TOOLBAR.catRecordManagement, "Cancel", clsWCommon.COM_MESS(clsWCommon.COM_INFO._Cancel, strLang), "Reset.png", "Reset.png", ToolBarItem7, , , strLang, False)
                Call VisibleToolBarItem(ToolBarItem8, clsWCommon.MAIN_TOOLBAR.catRecordManagement, "Save", clsWCommon.COM_MESS(clsWCommon.COM_INFO._Save, strLang), "Update.png", "Update.png", ToolBarItem8, , , strLang, False)
                Call VisibleToolBarItem(ToolBarItem6, clsWCommon.MAIN_TOOLBAR.catRecordManagement, "Close", clsWCommon.COM_MESS(clsWCommon.COM_INFO._Close, strLang), "Close.png", "Close.png", Separator6, True, False, strLang)
            Catch ex As Exception : End Try
        End Sub

        Private Sub VisibleToolBarItem(ByVal tbi As ToolBarItem, ByVal idControl As Integer, ByVal strValue As String, ByVal strText As String, ByVal strImageUrl As String, ByVal strDisabledImageUrl As String, ByVal Separator As ToolBarItem, Optional ByVal bolVisible As Boolean = True, Optional ByVal bolSeparator As Boolean = True, Optional ByVal strLang As String = "vie", Optional ByVal bolEnable As Boolean = True)
            Try
                bolVisible = getVisibleToolbarItem(strValue, idControl)
                With tbi
                    .Visible = bolVisible
                    .Text = strText
                    .Value = strValue
                    .Enabled = bolEnable
                    If bolEnable Then
                        .ImageUrl = strImageUrl
                    Else
                        .ImageUrl = strDisabledImageUrl
                    End If
                End With
                If bolSeparator Then
                    Separator.Visible = bolVisible
                End If
            Catch ex As Exception : End Try
        End Sub

        Private Function getVisibleToolbarItem(ByVal strValue As String, ByVal idControl As Integer) As Boolean
            Dim bolResults As Boolean = False
            Try
                'Dim ilUserRights As IList = Session("UserRight")
                'If Not IsNothing(ilUserRights) AndAlso ilUserRights.Count > 0 Then
                '    For Each ilData In ilUserRights
                '        If ilData.ModuleID = idControl Then
                '            bolResults = getFunction(strValue, ilData.RightsList.ToString)
                '            Exit For
                '        End If
                '    Next
                'End If
                bolResults = True
            Catch ex As Exception
            End Try
            Return bolResults
        End Function

        Private Function getFunction(ByVal strValue As String, ByVal strRightsList As String) As Boolean
            Dim bolResults As Boolean = False
            Try
                Select Case strValue
                    Case "New"
                        If strRightsList.Substring(1, 1) = "1" Then
                            bolResults = True
                        End If
                    Case "Edit"
                        If strRightsList.Substring(2, 1) = "1" Then
                            bolResults = True
                        End If
                    Case "Delete"
                        If strRightsList.Substring(3, 1) = "1" Then
                            bolResults = True
                        End If
                    Case "Save"
                        bolResults = True
                    Case "Cancel"
                        bolResults = True
                    Case "Close"
                        bolResults = True
                End Select
            Catch ex As Exception
            End Try
            Return bolResults
        End Function

        Private Sub ChangeLanguage()
            ToolBar.Items(0).Text = span_addnew.InnerText
            ToolBar.Items(2).Text = span_modify.InnerText
            ToolBar.Items(4).Text = span_delete.InnerText
            ToolBar.Items(6).Text = span_cancel.InnerText
            ToolBar.Items(8).Text = span_save.InnerText
            ToolBar.Items(10).Text = span_close.InnerText
        End Sub

        Public Sub DisplayInfo(ByVal _id As Integer)
            Dim _strInfo As String = ""
            _strInfo = "OnSubmit('first'," & _id & ");"
            clsWCommon.MyMsgBoxInfor(_strInfo, Me.Page)
        End Sub

    End Class
End Namespace

