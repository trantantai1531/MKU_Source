Imports System.Data

Namespace eMicLibAdmin.BusinessRules
    Public MustInherit Class clsBBase
        Implements IDisposable

        ' *****************************************************************************************************
        ' Declare member variables
        ' *****************************************************************************************************

        Protected strInterfaceLanguage As String
        Protected strConnectionString As String
        Protected strDBServer As String
        Protected strErrorMsg As String
        Protected intErrorCode As Integer
        Protected strSQL As String
        Protected intUserID As Integer
        Protected intLibID As Integer
        Protected intPatronID As String
        Protected strEmail As String

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' UserID property
        Public Property UserID() As Integer
            Get
                Return intUserID
            End Get
            Set(ByVal Value As Integer)
                intUserID = Value
            End Set
        End Property

        ' InterfaceLanguage property
        Public Property InterfaceLanguage() As String
            Get
                Return strInterfaceLanguage
            End Get
            Set(ByVal Value As String)
                strInterfaceLanguage = Value
            End Set
        End Property

        ' ConnectionString property
        Public Property ConnectionString() As String
            Get
                Return strConnectionString
            End Get
            Set(ByVal Value As String)
                strConnectionString = Value
            End Set
        End Property

        ' DBServer property
        Public Property DBServer() As String
            Get
                Return strDBServer
            End Get
            Set(ByVal Value As String)
                strDBServer = Value
            End Set
        End Property

        ' ErrorMsg property
        Public Property ErrorMsg() As String
            Get
                ErrorMsg = strErrorMsg
            End Get
            Set(ByVal Value As String)
                strErrorMsg = Value
            End Set
        End Property

        ' ErrorCode property
        Public Property ErrorCode() As Integer
            Get
                ErrorCode = intErrorCode
            End Get
            Set(ByVal Value As Integer)
                intErrorCode = Value
            End Set
        End Property

        ' SQL property
        Public Property SQL() As String
            Get
                Return strSQL
            End Get
            Set(ByVal Value As String)
                strSQL = Value
            End Set
        End Property

        ' LibID property
        Public Property LibID() As Integer
            Get
                Return intLibID
            End Get
            Set(ByVal Value As Integer)
                intLibID = Value
            End Set
        End Property

        ' PatronID property
        Public Property PatronID() As Integer
            Get
                Return intPatronID
            End Get
            Set(ByVal Value As Integer)
                intPatronID = Value
            End Set
        End Property

        ' Email property
        Public Property Email() As String
            Get
                Return strEmail
            End Get
            Set(ByVal Value As String)
                strEmail = Value
            End Set
        End Property

        Public Property Facebook() As String

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        Public Overloads Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub

        Public Overridable Overloads Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                'Free other state (managed objects).
            End If
            'Free your own state (unmanaged objects).
            'Set large fields to null.
        End Sub

        Protected Overrides Sub Finalize()
            ' Simply call Dispose(False).
            Dispose(False)
        End Sub
    End Class
End Namespace