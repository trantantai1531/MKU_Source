Imports eMicLibOPAC.BusinessRules.OPAC

Namespace eMicLibOPAC.WebUI.OPAC
    Public Class UHeader
        Inherits System.Web.UI.UserControl

        Private objBSysLibrary As New clsBSysLibrary
        Private objBOPACItem As New clsBOPACItem

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Try
                Call Initialize()
                'Call BindJavascript()
                Call getMyListItems()
                If Not IsPostBack Then
                    'Call ExportResource()
                    'Call changeImageLanguage()
                    Call BindData()
                End If
                'Call SetResourceForControls()
                Call getUser()
                'Call showLanguage()
                'Call getLibrary()
            Catch ex As Exception

            End Try
        End Sub

        Private Sub BindData()
            Try
                rdSearchOption.Items.Clear()
                'set text and value for dropdownlist document type
                Dim strResult As String = ""
                Dim dtTemp As DataTable = objBOPACItem.GetDicItemType(clsSession.GlbSite)
                If Not IsNothing(dtTemp) AndAlso dtTemp.Rows.Count > 0 Then
                    Dim item As ListItem
                    For inti As Integer = 0 To dtTemp.Rows.Count - 1
                        'strResult &= "<label>"
                        'strResult &= "<input type='checkbox' id='chkMaterialType" & dtTemp.Rows(inti).Item("ID") & "' onclick='setIdFromCheckBoxForMaterialType(this.id)' value='" & dtTemp.Rows(inti).Item("ID") & "'/>"
                        'strResult &= "<span class='check'></span>"
                        'If Not IsDBNull(dtTemp.Rows(inti).Item("TypeName")) Then
                        '    strResult &= dtTemp.Rows(inti).Item("TypeName")
                        'End If
                        'strResult &= "</label>"
                        If Not IsDBNull(dtTemp.Rows(inti).Item("TypeName")) Then
                            item = New ListItem(dtTemp.Rows(inti).Item("TypeName"), dtTemp.Rows(inti).Item("ID"))
                            rdSearchOption.Items.Add(item)
                        End If
                    Next
                    item = New ListItem(spSearchAll.InnerText, 0)
                    rdSearchOption.Items.Insert(0, item)
                End If
            Catch ex As Exception

            End Try
        End Sub

        ' Purpose: get item lists from session
        Private Sub getMyListItems()
            Try
                Dim iCount As Integer = 0
                hidMyListIds.Value = clsSession.GlbMyListIds
                If (hidMyListIds.Value <> "") Then
                    Dim strArr() As String = Split(hidMyListIds.Value, ",")
                    iCount = UBound(strArr)
                End If
                Dim str As String = ""
                'str &= "("
                str &= iCount
                'str &= "  <span class=""mif-books fg-emerald""></span>)"
                spMyList.InnerHtml = str
            Catch ex As Exception
            End Try
        End Sub

        ' Init method
        ' purpose initialize all components
        Private Sub Initialize()
            objBSysLibrary.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBSysLibrary.DBServer = Session("DBServer")
            objBSysLibrary.ConnectionString = Session("ConnectionString")
            objBSysLibrary.Initialize()

            ' Init objBOPACItem object
            objBOPACItem.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBOPACItem.DBServer = Session("DBServer")
            objBOPACItem.ConnectionString = Session("ConnectionString")
            Call objBOPACItem.Initialize()
        End Sub

        ''spLibrary
        'Private Sub getLibrary()
        '    spLibrary.InnerText = ""
        '    ltrLibraryList.Text = ""
        '    Dim strResult As String = ""
        '    Try
        '        'Dim tblResult As DataTable
        '        'objBSysLibrary.Language = clsSession.GlbLanguage
        '        'tblResult = objBSysLibrary.SysGetAllLibrary
        '        'If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
        '        '    For i As Integer = 0 To tblResult.Rows.Count - 1
        '        '        If tblResult.Rows(i).Item("LibId") = clsSession.GlbSite Then
        '        '            spLibrary.InnerHtml = "<Strong>" & tblResult.Rows(i).Item("LibName").ToString & "</Strong>"
        '        '        End If
        '        '        strResult &= "<li>"
        '        '        strResult &= "<a  href='OIndex.aspx?Site=" & tblResult.Rows(i).Item("LibId") & "'>"
        '        '        strResult &= "<i class='icon-database'>&nbsp;"
        '        '        strResult &= tblResult.Rows(i).Item("LibName").ToString
        '        '        strResult &= "</i>"
        '        '        strResult &= "</a>"
        '        '        strResult &= "</li>"
        '        '    Next
        '        '    ltrLibraryList.Text = strResult
        '        'End If


        '        Dim tblResult As DataTable
        '        objBSysLibrary.Language = clsSession.GlbLanguage
        '        tblResult = objBSysLibrary.SysGetAllLibrary
        '        If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
        '            For i As Integer = 0 To tblResult.Rows.Count - 1
        '                If tblResult.Rows(i).Item("LibId") = clsSession.GlbSite Then
        '                    spLibrary.InnerHtml = "<Strong>" & tblResult.Rows(i).Item("LibName").ToString & "</Strong>"
        '                    Exit For
        '                End If
        '            Next
        '        End If

        '        strResult &= "<li>"
        '        strResult &= "<a  href='OMap.aspx'>"
        '        strResult &= "<i class='icon-database'>&nbsp;"
        '        strResult &= spLibraryLink.InnerText
        '        strResult &= "</i>"
        '        strResult &= "</a>"
        '        strResult &= "</li>"
        '        ltrLibraryList.Text = strResult
        '    Catch ex As Exception
        '    End Try
        'End Sub

        Private Sub getUser()
            Try
                Dim strGlbUserFullname As String = clsCookie.CookieGlbUserFullName
                Dim strGlbUser As String = clsCookie.CookieGlbUser
                Dim strCookieGlbPassword As String = clsCookie.CookieGlbPassword
                Dim intCookieGlblevel As Integer = clsCookie.CookieGlbUserLevel
                Dim strGlbEmail As String = clsCookie.CookieGlbEmail
                If Not String.IsNullOrEmpty(strGlbUser) Then
                    clsSession.GlbUser = strGlbUser
                End If
                If Not String.IsNullOrEmpty(strGlbUserFullname) Then
                    clsSession.GlbUserFullName = strGlbUserFullname
                End If
                If Not String.IsNullOrEmpty(strCookieGlbPassword) Then
                    clsSession.GlbPassword = strCookieGlbPassword
                End If
                If Not String.IsNullOrEmpty(intCookieGlblevel) Then
                    clsSession.GlbUserLevel = intCookieGlblevel
                End If
                If Not String.IsNullOrEmpty(strGlbEmail) Then
                    clsSession.GlbEmail = strGlbEmail
                End If
                spFullName.InnerText = clsSession.GlbUserFullName
                Dim strAccountInfo As String = ""
                strAccountInfo &= "<h3>"
                strAccountInfo &= clsSession.GlbUserFullName
                strAccountInfo &= "</h3>"
                strAccountInfo &= "<h4>"
                strAccountInfo &= strGlbEmail
                strAccountInfo &= "</h4>"
                strAccountInfo &= "<a href='OPersonal.aspx'>"
                strAccountInfo &= spAccountConfig.InnerText
                strAccountInfo &= "</a>"

                ltrAccountInfo.Text = strAccountInfo
                'If Not String.IsNullOrEmpty(clsSession.GlbUser) Then
                '    btnStudentLogin.Value = spLogout.InnerText
                'Else
                '    btnStudentLogin.Value = spLogin.InnerText
                'End If
                 If Not String.IsNullOrEmpty(clsSession.GlbUser) Then
                    btnStudentLogin.Visible = False
                    btnLogout.Visible = True
                  Else
                    btnStudentLogin.Visible = True
                    btnLogout.Visible = False
                 End If
                hidUser.Value = clsSession.GlbUser
                'hidUser.Value = clsSession.GlbUser
                'If clsSession.GlbUserFullName <> "" Then
                '    Dim strFullName As String = clsSession.GlbUserFullName
                '    If clsSession.GlbLanguage.ToUpper = "ENG" Then
                '        strFullName = Me.CutVietnameseAccent(strFullName)
                '    End If
                '    spAccount.InnerText = spHello.InnerText & Space(1) & strFullName & "!"
                '    spLoginLogout.InnerText = spLogout.InnerText
                'Else
                '    spAccount.InnerText = spHello.InnerText & Space(1) & spGuest.InnerText & "!"
                '    spLoginLogout.InnerText = spLogin.InnerText
                'End If
                'txtEmail.Value = strGlbEmail
            Catch ex As Exception
            End Try
        End Sub

        Private Sub showLanguage()
            Throw New NotImplementedException
        End Sub

        Private Sub btnStudentLogin_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnStudentLogin.ServerClick
            'If Not String.IsNullOrEmpty(clsSession.GlbUser) Then
            '    Call ResetSessionUser()
            '    Call RemoveCookieAll()
            '    Response.Redirect(String.Format("OIndex.aspx"), False)
            'Else
                Response.Redirect(String.Format("OLoginRequest.aspx?RequestLogin=1"), False)
            'End If

        End Sub

        Private Sub btnLogout_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogout.ServerClick
                Call ResetSessionUser()
                Call RemoveCookieAll()
                Response.Redirect(String.Format("OIndex.aspx"), False)
        End Sub
        Private Sub ResetSessionUser()
            clsSession.GlbUser = ""
            clsSession.GlbUserFullName = ""
            clsSession.GlbPassword = ""
            clsSession.GlbUserLevel = 0
            clsSession.GlbEmail = ""
        End Sub

        Private Sub RemoveCookieAll()
            clsCookie.CookieGlbUserFullName = ""
            clsCookie.CookieGlbUser = ""
            clsCookie.CookieGlbPassword = ""
            clsCookie.CookieGlbUserLevel = 0
            clsCookie.CookieGlbEmail = ""
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
