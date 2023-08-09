Namespace eMicLibOPAC.WebUI
    Public Class clsSession
#Region "Common"
        Public Shared Property GlbUserFullName() As String
            Get
                Dim strResult As String = ""
                If HttpContext.Current.Session("UFULLNAME") IsNot Nothing Then
                    strResult = DirectCast(HttpContext.Current.Session("UFULLNAME"), String)
                End If
                Return strResult
            End Get
            Set(ByVal value As String)
                HttpContext.Current.Session("UFULLNAME") = value
            End Set
        End Property

        Public Shared Property GlbUser() As String
            Get
                Dim strResult As String = ""
                If HttpContext.Current.Session("UNAME") IsNot Nothing Then
                    strResult = DirectCast(HttpContext.Current.Session("UNAME"), String)
                End If
                Return strResult
            End Get
            Set(ByVal value As String)
                HttpContext.Current.Session("UNAME") = value
            End Set
        End Property

        Public Shared Property GlbUserLevel() As String
            Get
                Dim intResult As String = 0
                If HttpContext.Current.Session("UNAMELEVEL") IsNot Nothing Then
                    intResult = DirectCast(HttpContext.Current.Session("UNAMELEVEL"), String)
                End If
                Return intResult
            End Get
            Set(ByVal value As String)
                HttpContext.Current.Session("UNAMELEVEL") = value
            End Set
        End Property

        Public Shared Property GlbPassword() As String
            Get
                Dim strResult As String = ""
                If HttpContext.Current.Session("UPASS") IsNot Nothing Then
                    strResult = (DirectCast(HttpContext.Current.Session("UPASS"), String))
                End If
                Return strResult
            End Get
            Set(ByVal value As String)
                HttpContext.Current.Session("UPASS") = value
            End Set
        End Property

        Public Shared Property GlbLanguage() As String
            Get
                Dim strResult As String = ""
                If HttpContext.Current.Session("Language") IsNot Nothing Then
                    strResult = DirectCast(HttpContext.Current.Session("Language"), String)
                End If
                Return strResult
            End Get
            Set(ByVal value As String)
                HttpContext.Current.Session("Language") = value
            End Set
        End Property

        Public Shared Property GlbEmail() As String
            Get
                Dim strResult As String = ""
                If HttpContext.Current.Session("UEmail") IsNot Nothing Then
                    strResult = DirectCast(HttpContext.Current.Session("UEmail"), String)
                End If
                Return strResult
            End Get
            Set(ByVal value As String)
                HttpContext.Current.Session("UEmail") = value
            End Set
        End Property

        Public Shared Property GlbInterfaceLanguage() As String
            Get
                Dim strResult As String = ""
                If HttpContext.Current.Session("InterfaceLanguage") IsNot Nothing Then
                    strResult = DirectCast(HttpContext.Current.Session("InterfaceLanguage"), String)
                End If
                Return strResult
            End Get
            Set(ByVal value As String)
                HttpContext.Current.Session("InterfaceLanguage") = value
            End Set
        End Property

        Public Shared Property GlbcssPage() As String
            Get
                Dim strResult As String = ""
                If HttpContext.Current.Session("cssPage") IsNot Nothing Then
                    strResult = DirectCast(HttpContext.Current.Session("cssPage"), String)
                End If
                Return strResult
            End Get
            Set(ByVal value As String)
                HttpContext.Current.Session("cssPage") = value
            End Set
        End Property

        Public Shared Property GlbSearchFullText() As Boolean
            Get
                Dim bolResult As Boolean = False
                If HttpContext.Current.Session("SearchFullText") IsNot Nothing Then
                    bolResult = DirectCast(HttpContext.Current.Session("SearchFullText"), Boolean)
                End If
                Return bolResult
            End Get
            Set(ByVal value As Boolean)
                HttpContext.Current.Session("SearchFullText") = value
            End Set
        End Property

        Public Shared Property GlbIds() As DataTable
            Get
                Dim dtResult As DataTable = Nothing
                If HttpContext.Current.Session("IDs") IsNot Nothing Then
                    dtResult = DirectCast(HttpContext.Current.Session("IDs"), DataTable)
                End If
                Return dtResult
            End Get
            Set(ByVal value As DataTable)
                HttpContext.Current.Session("IDs") = value
            End Set
        End Property

        Public Shared Property GlbIdsForStore() As DataTable
            Get
                Dim dtResult As DataTable = Nothing
                If HttpContext.Current.Session("IDsForStore") IsNot Nothing Then
                    dtResult = DirectCast(HttpContext.Current.Session("IDsForStore"), DataTable)
                End If
                Return dtResult
            End Get
            Set(ByVal value As DataTable)
                HttpContext.Current.Session("IDsForStore") = value
            End Set
        End Property

        Public Shared Property GlbIdsInResult() As DataTable
            Get
                Dim dtResult As DataTable = Nothing
                If HttpContext.Current.Session("IDsInResult") IsNot Nothing Then
                    dtResult = DirectCast(HttpContext.Current.Session("IDsInResult"), DataTable)
                End If
                Return dtResult
            End Get
            Set(ByVal value As DataTable)
                HttpContext.Current.Session("IDsInResult") = value
            End Set
        End Property

        Public Shared Property GlbFulltextPages() As DataTable
            Get
                Dim dtResult As DataTable = Nothing
                If HttpContext.Current.Session("FulltextPages") IsNot Nothing Then
                    dtResult = DirectCast(HttpContext.Current.Session("FulltextPages"), DataTable)
                End If
                Return dtResult
            End Get
            Set(ByVal value As DataTable)
                HttpContext.Current.Session("FulltextPages") = value
            End Set
        End Property

        Public Shared Property GlbFilterIds() As DataTable
            Get
                Dim dtResult As DataTable = Nothing
                If HttpContext.Current.Session("FilterIDs") IsNot Nothing Then
                    dtResult = DirectCast(HttpContext.Current.Session("FilterIDs"), DataTable)
                End If
                Return dtResult
            End Get
            Set(ByVal value As DataTable)
                HttpContext.Current.Session("FilterIDs") = value
            End Set
        End Property

        Public Shared Property GlbBrowseIds() As DataView
            Get
                Dim dvResult As DataView = Nothing
                If HttpContext.Current.Session("BrowseIds") IsNot Nothing Then
                    dvResult = DirectCast(HttpContext.Current.Session("BrowseIds"), DataView)
                End If
                Return dvResult
            End Get
            Set(ByVal value As DataView)
                HttpContext.Current.Session("BrowseIds") = value
            End Set
        End Property

        Public Shared Property GlbFilterConditionString() As String
            Get
                Dim strResult As String = ""
                If HttpContext.Current.Session("FilterConditionString") IsNot Nothing Then
                    strResult = DirectCast(HttpContext.Current.Session("FilterConditionString"), String)
                End If
                Return strResult
            End Get
            Set(ByVal value As String)
                HttpContext.Current.Session("FilterConditionString") = value
            End Set
        End Property

        Public Shared Property GlbFilterConditionStringInResult() As String
            Get
                Dim strResult As String = ""
                If HttpContext.Current.Session("FilterConditionStringInResult") IsNot Nothing Then
                    strResult = DirectCast(HttpContext.Current.Session("FilterConditionStringInResult"), String)
                End If
                Return strResult
            End Get
            Set(ByVal value As String)
                HttpContext.Current.Session("FilterConditionStringInResult") = value
            End Set
        End Property

        Public Shared Property GlbFilterConditionValue() As String
            Get
                Dim strResult As String = ""
                If HttpContext.Current.Session("FilterConditionValue") IsNot Nothing Then
                    strResult = DirectCast(HttpContext.Current.Session("FilterConditionValue"), String)
                End If
                Return strResult
            End Get
            Set(ByVal value As String)
                HttpContext.Current.Session("FilterConditionValue") = value
            End Set
        End Property

        Public Shared Property GlbMyListIds() As String
            Get
                Dim strResult As String = ""
                If HttpContext.Current.Session("MyListIds") IsNot Nothing Then
                    strResult = DirectCast(HttpContext.Current.Session("MyListIds"), String)
                End If
                Return strResult
            End Get
            Set(ByVal value As String)
                HttpContext.Current.Session("MyListIds") = value
            End Set
        End Property

        Public Shared Property GlbOrderBy() As String
            Get
                Dim strResult As String = ""
                If HttpContext.Current.Session("OrderBy") IsNot Nothing Then
                    strResult = DirectCast(HttpContext.Current.Session("OrderBy"), String)
                End If
                Return strResult
            End Get
            Set(ByVal value As String)
                HttpContext.Current.Session("OrderBy") = value
            End Set
        End Property

        Public Shared Property GlbBrowseOrderBy() As String
            Get
                Dim strResult As String = ""
                If HttpContext.Current.Session("BrowseOrderBy") IsNot Nothing Then
                    strResult = DirectCast(HttpContext.Current.Session("BrowseOrderBy"), String)
                End If
                Return strResult
            End Get
            Set(ByVal value As String)
                HttpContext.Current.Session("BrowseOrderBy") = value
            End Set
        End Property

        Public Shared Property GlbClassification() As Integer
            Get
                Dim strResult As Integer = 8 'DDC
                If HttpContext.Current.Session("Classification") IsNot Nothing Then
                    strResult = DirectCast(HttpContext.Current.Session("Classification"), Integer)
                End If
                Return strResult
            End Get
            Set(ByVal value As Integer)
                HttpContext.Current.Session("Classification") = value
            End Set
        End Property

        Public Shared Property GlbTopTopics() As Integer
            Get
                Dim strResult As Integer = 8 'DDC
                If HttpContext.Current.Session("TopTopics") IsNot Nothing Then
                    strResult = DirectCast(HttpContext.Current.Session("TopTopics"), Integer)
                End If
                Return strResult
            End Get
            Set(ByVal value As Integer)
                HttpContext.Current.Session("TopTopics") = value
            End Set
        End Property

        Public Shared Property GlbViewerCollection() As Collection
            Get
                Dim dtResult As Collection = Nothing
                If HttpContext.Current.Session("ViewerCollection") IsNot Nothing Then
                    dtResult = DirectCast(HttpContext.Current.Session("ViewerCollection"), Collection)
                End If
                Return dtResult
            End Get
            Set(ByVal value As Collection)
                HttpContext.Current.Session("ViewerCollection") = value
            End Set
        End Property

        Public Shared Property GlbSQLStatement() As String
            Get
                Dim strResult As String = ""
                If HttpContext.Current.Session("SQLStatement") IsNot Nothing Then
                    strResult = DirectCast(HttpContext.Current.Session("SQLStatement"), String)
                End If
                Return strResult
            End Get
            Set(ByVal value As String)
                HttpContext.Current.Session("SQLStatement") = value
            End Set
        End Property

        Public Shared Property GlbSQLStatementFilter() As String
            Get
                Dim strResult As String = ""
                If HttpContext.Current.Session("SQLStatementFilter") IsNot Nothing Then
                    strResult = DirectCast(HttpContext.Current.Session("SQLStatementFilter"), String)
                End If
                Return strResult
            End Get
            Set(ByVal value As String)
                HttpContext.Current.Session("SQLStatementFilter") = value
            End Set
        End Property

        Public Shared Property GlbSQLStatementForStore() As String
            Get
                Dim strResult As String = ""
                If HttpContext.Current.Session("SQLStatementForStore") IsNot Nothing Then
                    strResult = DirectCast(HttpContext.Current.Session("SQLStatementForStore"), String)
                End If
                Return strResult
            End Get
            Set(ByVal value As String)
                HttpContext.Current.Session("SQLStatementForStore") = value
            End Set
        End Property

        Public Shared Property GlbBrowseFilter() As String
            Get
                Dim strResult As String = ""
                If HttpContext.Current.Session("BrowseFilter") IsNot Nothing Then
                    strResult = DirectCast(HttpContext.Current.Session("BrowseFilter"), String)
                End If
                Return strResult
            End Get
            Set(ByVal value As String)
                HttpContext.Current.Session("BrowseFilter") = value
            End Set
        End Property

        Public Shared Property GlbSite() As Integer
            Get
                Dim strResult As Integer = 0
                Return strResult
            End Get
            Set(ByVal value As Integer)
                HttpContext.Current.Session("Site") = 0
            End Set
        End Property

        Public Shared Property GlbSSCId() As String
            Get
                Dim strResult As String = ""
                If HttpContext.Current.Session("SSCId") IsNot Nothing Then
                    strResult = DirectCast(HttpContext.Current.Session("SSCId"), String)
                End If
                Return strResult
            End Get
            Set(ByVal value As String)
                HttpContext.Current.Session("SSCId") = value
            End Set
        End Property

#End Region
    End Class

End Namespace
