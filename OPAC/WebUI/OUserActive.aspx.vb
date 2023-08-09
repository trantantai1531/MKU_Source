Imports eMicLibOPAC.BusinessRules.OPAC

Namespace eMicLibOPAC.WebUI.OPAC
    Public Class OUserActive
        Inherits clsWBase
        ' Declare variables
        Private objBOPatronInfor As New clsBOPACPatronInfor

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Call Initialize()
            Call BindScript()
            Call onSubmitActive()
        End Sub
        ' BindScript method
        Private Sub BindScript()
            'Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = 'js/OUserActive.js'></script>")
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init for objBOPatronInfor
            objBOPatronInfor.InterfaceLanguage = Session("InterfaceLanguage")
            objBOPatronInfor.DBServer = Session("DBServer")
            objBOPatronInfor.ConnectionString = Session("ConnectionString")
            objBOPatronInfor.Initialize()
        End Sub

        Private Sub onSubmitActive()
            Try
                spInfo.InnerText = ""
                If (Not IsNothing(Request("txtSothe")) AndAlso Request("txtSothe") <> "") AndAlso (Not IsNothing(Request("txtNgaycap")) AndAlso Request("txtNgaycap") <> "") AndAlso (Not IsNothing(Request("txtNgaysinh")) AndAlso Request("txtNgaysinh") <> "") AndAlso (Not IsNothing(Request("txtMatkhau")) AndAlso Request("txtMatkhau") <> "") AndAlso (Not IsNothing(Request("txtMatkhau1")) AndAlso Request("txtMatkhau1") <> "") Then
                    ' Declare variables
                    Dim _strInfo As String = ""
                    Dim tblPatron As DataTable
                    Dim strJS As String

                    objBOPatronInfor.CardNo = Trim(Request("txtSothe") & "")
                    objBOPatronInfor.Password = Trim(Request("txtMatkhau") & "")
                    objBOPatronInfor.ValidDate = Trim(Request("txtNgaycap") & "")
                    objBOPatronInfor.DOB = Trim(Request("txtNgaysinh") & "")

                    tblPatron = objBOPatronInfor.ActiveAccount

                    If Not tblPatron Is Nothing Then
                        If tblPatron.Rows.Count > 0 Then
                            If Not IsDBNull(tblPatron.Rows(0).Item("Code")) Then
                                clsSession.GlbUser = Trim(CStr(tblPatron.Rows(0).Item("Code") & ""))
                            End If
                            If Not IsDBNull(tblPatron.Rows(0).Item("Password")) Then
                                clsSession.GlbPassword = Trim(CStr(tblPatron.Rows(0).Item("Password") & ""))
                            End If
                            If Not IsDBNull(tblPatron.Rows(0).Item("FullName")) Then
                                clsSession.GlbUserFullName = Trim(CStr(tblPatron.Rows(0).Item("FullName") & ""))
                            End If
                            If Not IsDBNull(tblPatron.Rows(0).Item("AccessLevel")) Then
                                clsSession.GlbUserLevel = Trim(CStr(tblPatron.Rows(0).Item("AccessLevel") & ""))
                            End If
                            clsCookie.RemoveCookieGlbUserFullname()
                            clsCookie.RemoveCookieGlbUser()
                            clsCookie.RemoveCookieGlbPassword()
                            clsCookie.RemoveCookieGlbUserLevel()
                            _strInfo &= " parent.setUser('" & clsSession.GlbUser & "','" & clsSession.GlbUserFullName & "');" & vbCrLf
                            'Kiem tra neu la form comment thi submit
                            If (Not IsNothing(Request("comment")) AndAlso Request("comment") <> "") Then
                                '_strInfo &= " showAlert('" & spSetPassSuccess.InnerText & "');" & vbCrLf
                                _strInfo &= " parent.closeShowLogin();" & vbCrLf
                                _strInfo &= " parent.onSubmitComment();" & vbCrLf
                            Else
                                _strInfo &= " parent.closeShowLogin();" & vbCrLf
                                '_strInfo &= " parent.showNotify(3,'" & spSetPassSuccess.InnerText & "');" & vbCrLf
                                'strJS = strJS & "self.location.href='OLogin.aspx';" & vbCrLf
                            End If
                        Else
                            _strInfo &= " parent.showNotify(2,'" & spSetPasstFail.InnerText & "');" & vbCrLf
                        End If
                    Else
                        _strInfo &= " parent.showNotify(2,'" & spSetPassSuccess.InnerText & "');" & vbCrLf
                    End If
                    spInfo.InnerText = spSetPassSuccess.InnerText
                    clsUICommon.MyMsgBoxInfor(_strInfo, Me.Page)
                End If
            Catch ex As Exception
            End Try
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBOPatronInfor Is Nothing Then
                    objBOPatronInfor.Dispose(True)
                    objBOPatronInfor = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
