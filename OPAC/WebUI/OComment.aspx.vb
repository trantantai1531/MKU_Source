Namespace eMicLibOPAC.WebUI.OPAC
    Public Class OComment
        Inherits clsWBase

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Try
                If Not IsPostBack Then
                    If Not IsNothing(Request("txtComment")) AndAlso Request("txtComment") <> "" Then
                        If clsSession.GlbUser <> "" Then
                            Dim _strInfo As String = ""
                            _strInfo &= " raiseWarning();" & vbCrLf
                            clsUICommon.MyMsgBoxInfor(_strInfo, Me.Page)
                        Else
                            Dim _strInfo As String = ""
                            _strInfo &= " showLogin();" & vbCrLf
                            clsUICommon.MyMsgBoxInfor(_strInfo, Me.Page)
                        End If
                    End If
                End If
            Catch ex As Exception
            End Try
        End Sub
    End Class
End Namespace
