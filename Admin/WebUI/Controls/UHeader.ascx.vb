Imports eMicLibAdmin.BusinessRules.Admin

Namespace eMicLibAdmin.WebUI
    Partial Class Controls_UHeader
        Inherits System.Web.UI.UserControl 'clsControl '
        Private _RootPath As String = ""
        Private _Language As String = "vie"
        Dim objBUser As New clsBUser

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Call Initialize()
            Call BindScript()
            If Not IsPostBack Then
                'Call ChangeLanguage()
                'Call ControlInit()
                Call buildMenu()
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            Response.Expires = 0
            ' Init objBUser object
            objBUser.ConnectionString = Session("ConnectionString")
            objBUser.DBServer = Session("DBServer")
            objBUser.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBUser.Initialize()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            'Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
        End Sub


        Private Sub buildMenuRecursively(ByRef rbTabsSub As Telerik.Web.UI.RibbonBarTab, ByVal rightsList As String, ByVal parentId As Integer, Optional ByVal bVNLanguage As Boolean = True)
            objBUser.RightList = ""
            Dim dtMudule As DataTable = objBUser.getModules(parentId)
            If Not IsNothing(dtMudule) AndAlso dtMudule.Rows.Count > 0 Then
                Dim rbBarGroup As Telerik.Web.UI.RibbonBarGroup = Nothing
                Dim rbToggleButton As Telerik.Web.UI.RibbonBarToggleButton = Nothing
                Dim rbToggleList As Telerik.Web.UI.RibbonBarToggleList = Nothing
                Dim rbRibbonBarSplitButton As Telerik.Web.UI.RibbonBarSplitButton = Nothing
                Dim rbRibbonBarButton As Telerik.Web.UI.RibbonBarButton = Nothing
                Dim checkpointGroup As Boolean = False
                Dim strModule As String = ""
                Dim strIcon As String = ""
                Dim strLink As String = ""
                Dim intAction As Integer = 1
                Dim intSequence As Integer = 1
                Dim strDescription As String = ""
                For i As Integer = 0 To dtMudule.Rows.Count - 1
                    strModule = ""
                    strIcon = ""
                    strLink = ""
                    intAction = 1
                    checkpointGroup = False
                    If Not checkpointGroup Then
                        rbBarGroup = New Telerik.Web.UI.RibbonBarGroup
                        With rbBarGroup
                            .ID = "GroupMenu" & dtMudule.Rows(i).Item("Id").ToString
                            If bVNLanguage Then
                                If Not IsDBNull(dtMudule.Rows(i).Item("ModuleVie")) Then
                                    strModule = dtMudule.Rows(i).Item("ModuleVie")
                                End If
                            Else
                                If Not IsDBNull(dtMudule.Rows(i).Item("Module")) Then
                                    strModule = dtMudule.Rows(i).Item("Module")
                                End If
                            End If
                            .Text = strModule
                        End With
                        checkpointGroup = True
                        rbToggleList = New Telerik.Web.UI.RibbonBarToggleList
                        rbRibbonBarSplitButton = New Telerik.Web.UI.RibbonBarSplitButton
                    End If
                    rbToggleButton = New Telerik.Web.UI.RibbonBarToggleButton
                    With rbToggleButton
                        .ID = "ToggleButtonMenu" & dtMudule.Rows(i).Item("Id").ToString
                        If bVNLanguage Then
                            If Not IsDBNull(dtMudule.Rows(i).Item("ModuleVie")) Then
                                strModule = dtMudule.Rows(i).Item("ModuleVie")
                            End If
                            .Text = strModule
                        Else
                            If Not IsDBNull(dtMudule.Rows(i).Item("Module")) Then
                                strModule = dtMudule.Rows(i).Item("Module")
                            End If
                            .Text = strModule
                        End If
                        If Not IsDBNull(dtMudule.Rows(i).Item("Icon")) Then
                            strIcon = dtMudule.Rows(i).Item("Icon")
                        End If
                        'If parentId <> 6 Then
                        '    .ImageUrl = "~/Images/RibbonBar/" & strIcon
                        '    .Size = Telerik.Web.UI.RibbonBarItemSize.Medium
                        'Else
                        '    .ImageUrlLarge = "~/Images/RibbonBar/" & strIcon
                        '    .Size = Telerik.Web.UI.RibbonBarItemSize.Large
                        'End If
                        '.ImageUrlLarge = "~/Images/RibbonBar/" & strIcon
                        .ImageUrlLarge = "~/Resources/Images/bgicon.png"
                        .Size = Telerik.Web.UI.RibbonBarItemSize.Large
                        .CssClass = strIcon

                        If Not IsDBNull(dtMudule.Rows(i).Item("Link")) Then
                            strLink = dtMudule.Rows(i).Item("Link")
                        End If
                        If Not IsDBNull(dtMudule.Rows(i).Item("Action_type")) Then
                            intAction = dtMudule.Rows(i).Item("Action_type")
                        End If
                        .Value = intAction.ToString & Page.ResolveUrl(strLink)
                        If bVNLanguage Then
                            .ToolTip = dtMudule.Rows(i).Item("ModuleVie").ToString
                        Else
                            .ToolTip = dtMudule.Rows(i).Item("Module").ToString
                        End If
                    End With
                    rbToggleList.ToggleButtons.Add(rbToggleButton)

                    rbRibbonBarButton = New Telerik.Web.UI.RibbonBarButton
                    With rbRibbonBarButton
                        .ID = "RibbonBarButton" & dtMudule.Rows(i).Item("Id").ToString
                        .CssClass = "exicon-" + dtMudule.Rows(i).Item("Id").ToString
                        If bVNLanguage Then
                            If Not IsDBNull(dtMudule.Rows(i).Item("ModuleVie")) Then
                                strModule = dtMudule.Rows(i).Item("ModuleVie")
                            End If
                        Else
                            If Not IsDBNull(dtMudule.Rows(i).Item("Module")) Then
                                strModule = dtMudule.Rows(i).Item("Module")
                            End If
                        End If
                        If Not IsDBNull(dtMudule.Rows(i).Item("Description")) Then
                            strModule = dtMudule.Rows(i).Item("Description")
                        End If
                        .Text = strModule
                        If Not IsDBNull(dtMudule.Rows(i).Item("Icon")) Then
                            strIcon = dtMudule.Rows(i).Item("Icon")
                        End If
                        '.ImageUrlLarge = "~/Images/RibbonBar/" & strIcon
                        .ImageUrlLarge = "~/Resources/Images/bgicon.png"
                        .Size = Telerik.Web.UI.RibbonBarItemSize.Large

                        If Not IsDBNull(dtMudule.Rows(i).Item("Link")) Then
                            strLink = dtMudule.Rows(i).Item("Link")
                        End If
                        If Not IsDBNull(dtMudule.Rows(i).Item("Action_type")) Then
                            intAction = dtMudule.Rows(i).Item("Action_type")
                        End If
                        .Value = intAction.ToString & Page.ResolveUrl(strLink)
                        If bVNLanguage Then
                            .ToolTip = dtMudule.Rows(i).Item("ModuleVie").ToString
                        Else
                            .ToolTip = dtMudule.Rows(i).Item("Module").ToString
                        End If
                    End With
                    'rbRibbonBarSplitButton.Buttons.Add(rbRibbonBarButton)

                    'rbToggleList.ToggleButtons.Add(rbRibbonBarButton)
                    rbBarGroup.Items.Add(rbRibbonBarButton)

                    Call buildMenuRecursively(rbTabsSub, rightsList, dtMudule.Rows(i).Item("Id"), bVNLanguage)
                    'If intSequence > 11 Then
                    '    checkpointGroup = False
                    '    intSequence = 0
                    '    If Not IsNothing(rbBarGroup) Then
                    '        rbBarGroup.Items.Add(rbToggleList)
                    '        rbBarGroup.Items.Add(rbRibbonBarSplitButton)
                    '        rbTabsSub.Groups.Add(rbBarGroup)
                    '    End If
                    'End If
                    'intSequence += 1
                    rbTabsSub.Groups.Add(rbBarGroup)
                Next
                If Not IsNothing(rbBarGroup) Then
                    'rbBarGroup.Items.Add(rbToggleList)
                    'rbBarGroup.Items.Add(rbRibbonBarSplitButton)
                    ' rbTabsSub.Groups.Add(rbBarGroup)
                End If
            End If
        End Sub

        Private Sub buildMenu()
            Dim bolVNLanguage As Boolean = True
            If Not IsNothing(clsSession.GlbLanguage) Then
                If Not clsSession.GlbLanguage = "vie" Then
                    bolVNLanguage = False
                End If
            End If
            Dim rrbMenu As New Telerik.Web.UI.RadRibbonBar
            With rrbMenu
                .ID = "rrbMenu"
                .Skin = "Silk" ' "Windows7"
                .OnClientButtonClicked = "ClientButtonToggledHandler"
                .OnClientSelectedTabChanged = "ClientSelectedTabChangedHandler"
                .SelectedTabIndex = 1
            End With
            Dim strModule As String = ""
            Dim strIcon As String = ""
            Dim strLink As String = ""
            Dim intAction As Integer = 1
            Dim strRightsList As String = clsSession.GlbRightList
            objBUser.RightList = strRightsList
            Dim dtMudule As DataTable = objBUser.getModules()
            Dim rbTabs As Telerik.Web.UI.RibbonBarTab
            If Not IsNothing(dtMudule) AndAlso dtMudule.Rows.Count > 0 Then
                For i As Integer = 0 To dtMudule.Rows.Count - 1
                    rbTabs = New Telerik.Web.UI.RibbonBarTab
                    strModule = ""
                    strIcon = ""
                    strLink = ""
                    intAction = 1
                    With rbTabs
                        .ID = "Menu" & dtMudule.Rows(i).Item("Id").ToString
                        If bolVNLanguage Then
                            If Not IsDBNull(dtMudule.Rows(i).Item("ModuleVie")) Then
                                strModule = dtMudule.Rows(i).Item("ModuleVie")
                            End If
                            .Text = strModule
                        Else
                            If Not IsDBNull(dtMudule.Rows(i).Item("Module")) Then
                                strModule = dtMudule.Rows(i).Item("Module")
                            End If
                            .Text = strModule
                        End If
                        If Not IsDBNull(dtMudule.Rows(i).Item("Link")) Then
                            strLink = dtMudule.Rows(i).Item("Link")
                        End If
                        If Not IsDBNull(dtMudule.Rows(i).Item("Action_type")) Then
                            intAction = dtMudule.Rows(i).Item("Action_type")
                        End If
                        .Value = intAction.ToString & Page.ResolveUrl(strLink)

                    End With
                    Call buildMenuRecursively(rbTabs, strRightsList, dtMudule.Rows(i).Item("Id"), bolVNLanguage)
                    rrbMenu.Tabs.Add(rbTabs)
                Next
                header.Controls.Add(rrbMenu)
            End If
        End Sub


        Private Function getLanguageString(ByVal str As String, Optional ByVal len As Integer = 3) As String
            Dim strResult As String = "vie"
            Try
                strResult = Right(str, len)
            Catch ex As Exception
            End Try
            Return strResult
        End Function

        'Private Sub ChangeLanguage()
        '    If Not HttpContext.Current.Request.QueryString("Language") Is Nothing Then
        '        Me._Language = HttpContext.Current.Request.QueryString("Language")
        '        Me._Language = getLanguageString(Me._Language)
        '        clsSession.GlbLanguage = Me._Language
        '        Dim _httpCookies As HttpCookie
        '        _httpCookies = New HttpCookie("Language", Me._Language)
        '        _httpCookies.Expires = Now.AddDays(30)
        '        Response.Cookies.Add(_httpCookies)
        '    ElseIf Not HttpContext.Current.Request.Cookies.Item("Language") Is Nothing Then
        '        Me._Language = HttpContext.Current.Request.Cookies.Item("Language").Value
        '        Me._Language = getLanguageString(Me._Language)
        '        clsSession.GlbLanguage = Me._Language
        '    ElseIf Not clsSession.GlbLanguage Is Nothing Then
        '        Me._Language = clsSession.GlbLanguage
        '        Me._Language = getLanguageString(Me._Language)
        '    Else
        '        Me._Language = "vie"
        '    End If
        '    clsSession.GlbLanguage = Me._Language
        '    clsSession.GlbInterfaceLanguage = Me._Language

        '    If Not clsSession.GlbLanguage Is Nothing Then
        '        If clsSession.GlbLanguage = "vie" Then
        '            imgVieLanguage.Attributes.Add("title", "Tiếng việt")
        '            imgEngLanguage.Attributes.Add("title", "Tiếng anh")
        '            lkbLogout.Text = "Thoát"
        '        Else
        '            imgVieLanguage.Attributes.Add("title", "Vietnamese")
        '            imgEngLanguage.Attributes.Add("title", "English")
        '            lkbLogout.Text = "Log out"
        '        End If
        '    Else
        '        imgVieLanguage.Attributes.Add("title", "Tiếng việt")
        '        imgEngLanguage.Attributes.Add("title", "Tiếng anh")
        '        lkbLogout.Text = "Thoát"
        '    End If
        'End Sub

        Private Sub GetRootPath()
            Dim applicationPath As String = HttpContext.Current.Request.ApplicationPath
            If Not applicationPath.EndsWith("/") Then
                applicationPath = applicationPath + "/"
            End If
            Me._RootPath = applicationPath
        End Sub

        'Private Sub ControlInit()
        '    ltlogin.Text = clsSession.GlbUserFullName
        '    'Call GetRootPath()
        '    'lkbLogout.PostBackUrl = Me._RootPath & "index.aspx?out=ok"
        'End Sub


        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBUser Is Nothing Then
                    objBUser.Dispose(True)
                    objBUser = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace

