Imports eMicLibOPAC.BusinessRules.OPAC

Namespace eMicLibOPAC.WebUI.OPAC
    Public Class OMap
        'Inherits System.Web.UI.Page
        Inherits clsWBaseJqueryUI

        Private objBSysLibrary As New clsBSysLibrary

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Call Initialize()
            Call BindJavascript()
            If Not IsPostBack Then
                Call LoadData()
                Call changeImageLanguage()
            End If
            Call showLanguage()
        End Sub

        ' Init method
        ' purpose initialize all components
        Private Sub Initialize()
            objBSysLibrary.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBSysLibrary.DBServer = Session("DBServer")
            objBSysLibrary.ConnectionString = Session("ConnectionString")
            objBSysLibrary.Initialize()
        End Sub

        Private Sub showLanguage()
            Dim strResult As String = ""
            Try
                Select Case UCase(clsSession.GlbLanguage)
                    Case "VIE"
                        strResult &= "<li><a onclick=""changLanguage('vie')""><span runat='server' class='icon-radio-checked'>&nbsp;&nbsp;" & spLanguageVietNamese.InnerText & "</span></a></li>"
                        strResult &= "<li><a onclick=""changLanguage('eng')""><span runat='server' class='icon-radio-unchecked'>&nbsp;&nbsp;" & spLanguageEnglish.InnerText & "</span></a></li>"
                    Case "ENG"
                        strResult &= "<li><a onclick=""changLanguage('vie')""><span runat='server' class='icon-radio-unchecked'>&nbsp;&nbsp;" & spLanguageVietNamese.InnerText & "</span></a></li>"
                        strResult &= "<li><a onclick=""changLanguage('eng')""><span runat='server' class='icon-radio-checked'>&nbsp;&nbsp;" & spLanguageEnglish.InnerText & "</span></a></li>"
                    Case Else
                        strResult &= "<li><a onclick=""changLanguage('vie')""><span runat='server' class='icon-radio-checked'>&nbsp;&nbsp;" & spLanguageVietNamese.InnerText & "</span></a></li>"
                        strResult &= "<li><a onclick=""changLanguage('eng')""><span runat='server' class='icon-radio-unchecked'>&nbsp;&nbsp;" & spLanguageEnglish.InnerText & "</span></a></li>"
                End Select
            Catch ex As Exception
            End Try
            ltrLanguage.Text = strResult
        End Sub

        Private Sub changeImageLanguage()
            Try
                Dim strLanguage As String = "vie"
                If Not IsNothing(clsSession.GlbLanguage) AndAlso clsSession.GlbLanguage <> "" Then
                    strLanguage = clsSession.GlbLanguage
                End If
                imgFlag.Src = "images/Language/" & strLanguage & ".png"
            Catch ex As Exception
            End Try
        End Sub

        ' Method :  LoadData
        Private Sub LoadData()
            Dim strResult As String = ""
            strResult &= "<div class='listview-outlook' data-role='listview'>"
            Try
                Dim i As Integer = 0
                Dim intPercent As Integer = 0
                'If clsSession.GlbLanguage & "" <> "" Then
                '    Dim strLanguage As String
                '    strLanguage = clsSession.GlbLanguage
                '    For i = 0 To ddlLanguage.Items.Count - 1
                '        If ddlLanguage.Items(i).Value = strLanguage Then
                '            ddlLanguage.SelectedIndex = i
                '            Exit For
                '        End If
                '    Next
                'End If
                Dim tblResult As DataTable
                objBSysLibrary.Language = clsSession.GlbLanguage
                tblResult = objBSysLibrary.SysGetAllLibrary
                If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                    Dim tblCell As TableCell = Nothing
                    Dim tblRow As TableRow = Nothing
                    'Dim img As System.Web.UI.WebControls.Image
                    Dim hpl As HyperLink = Nothing
                    Dim LibType As Integer = 0
                    Dim lbl As Label = Nothing

                    Dim dlLatitude As Double = 0.0
                    Dim dlLongitude As Double = 0.0

                    strResult &= "<div class='list-content'>"
                    strResult &= "<span>"
                    strResult &= "<h4>"
                    strResult &= spLibrary.InnerText
                    strResult &= "</h4>"
                    strResult &= "</span>"
                    strResult &= "</div>"
                    For i = 0 To tblResult.Rows.Count - 1
                        'If LibType <> tblResult.Rows(i).Item("LibTypeId") Then
                        '    strResult &= "<div class='list-content'>"
                        '    strResult &= "<span>"
                        '    strResult &= "<h4>"
                        '    strResult &= tblResult.Rows(i).Item("LibType")
                        '    strResult &= "</h4>"
                        '    strResult &= "</span>"
                        '    strResult &= "</div>"
                        'End If

                        dlLatitude = 0.0
                        dlLongitude = 0.0
                        If Not IsDBNull(tblResult.Rows(i).Item("latitude")) Then
                            dlLatitude = tblResult.Rows(i).Item("latitude")
                        End If
                        If Not IsDBNull(tblResult.Rows(i).Item("longitude")) Then
                            dlLongitude = tblResult.Rows(i).Item("longitude")
                        End If
                        intPercent = GetRandom(10, 75)
                        strResult &= "<a class='list' onclick='moveMarker(" & Replace(dlLatitude, ",", ".") & "," & Replace(dlLongitude, ",", ".") & ");'>"
                        strResult &= "<div class='list-content'>"
                        strResult &= "<img src='images/library/publicLibrary.png' class='icon'/>"
                        strResult &= "<div class='data'>"
                        strResult &= "<span class='list-title'>"
                        strResult &= tblResult.Rows(i).Item("LibName").ToString
                        strResult &= "</span>"
                        strResult &= "<span class='list-subtitle'>"
                        strResult &= tblResult.Rows(i).Item("LibAddress").ToString
                        strResult &= "</span>"
                        strResult &= "<div class='progress-bar small' data-role='progress-bar' data-value='" & intPercent & "'></div>"
                        strResult &= "<span class='list-remark'>" & spFinish.InnerText & intPercent.ToString & "%</span>"
                        strResult &= "</div>"
                        strResult &= "</div>"
                        strResult &= "</a>"
                        'tbLibrary.Rows.Add(tblRow)
                        LibType = tblResult.Rows(i).Item("LibTypeId")
                    Next
                End If
            Catch ex As Exception
            End Try
            strResult &= "</div>"
            lrtLibrary.Text = strResult
        End Sub

        Private Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
            System.Threading.Thread.Sleep(10)
            Randomize()
            Dim Generator As System.Random = New System.Random()
            Return Generator.Next(Min, Max)
            'Randomize()
            '' Generate random value between 1 and 6. 
            'Dim value As Integer = CInt(Int((Max * Rnd()) + Min))
            'Return value
        End Function

        ' Method :  BindJavascript
        Private Sub BindJavascript()
            'Page.RegisterClientScriptBlock("SelfJs", "<script language='javascript' src='JS/OLibrary.js'></script>")
        End Sub

        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: Release all object
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBSysLibrary Is Nothing Then
                    objBSysLibrary.Dispose(True)
                    objBSysLibrary = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub


    End Class
End Namespace
