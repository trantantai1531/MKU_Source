Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Public MustInherit Class clsDBase
    Implements IDisposable

    ' *****************************************************************************************************
    ' Declare Private variables
    ' *****************************************************************************************************

    Protected strErrorMsg As String = ""
    Protected intErrorCode As Integer = 0
    Protected strDBServer As String = ""
    Protected strConnectionstring As String = ""
    Protected strInterfaceLanguage As String = ""
    Protected strSQLStatement As String = ""
    Protected intUserID As Integer = 0
    Protected strModuleName As String = ""

    Protected oraConnection As OracleConnection
    Protected oraCommand As OracleCommand
    Protected oraDataAdapter As New OracleDataAdapter
    Protected sqlConnection As SqlConnection
    Protected sqlCommand As SqlCommand
    Protected sqlDataAdapter As New SqlDataAdapter
    Protected dsData As New DataSet
    Protected intLibID As Integer = 0
    ' *****************************************************************************************************
    ' End declare variables
    ' Declare public properties
    ' *****************************************************************************************************

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

    ' DBServer property
    Public Property DBServer() As String
        Get
            DBServer = strDBServer
        End Get
        Set(ByVal Value As String)
            strDBServer = Value
        End Set
    End Property

    ' ConnectionString property
    Public Property ConnectionString() As String
        Get
            ConnectionString = strConnectionstring
        End Get
        Set(ByVal Value As String)
            strConnectionstring = Value
        End Set
    End Property

    ' SQLStatement property
    Public Property SQLStatement() As String
        Get
            Return strSQLStatement
        End Get
        Set(ByVal Value As String)
            strSQLStatement = Value
        End Set
    End Property

    ' UserID property
    Public Property UserID() As Integer
        Get
            Return intUserID
        End Get
        Set(ByVal Value As Integer)
            intUserID = Value
        End Set
    End Property

    ' ModuleName property
    Public Property ModuleName() As String
        Get
            Return strModuleName
        End Get
        Set(ByVal Value As String)
            strModuleName = Value
        End Set
    End Property

    ' LibID property
    Public Property LibID() As Long
        Get
            LibID = intLibID
        End Get
        Set(ByVal Value As Long)
            intLibID = Value
        End Set
    End Property
    ' *****************************************************************************************************
    ' End declare properties
    ' Implement methods here
    ' *****************************************************************************************************

    ' Initialize method
    ' Purpose: init all objects
    Public Sub Initialize()
        Select Case UCase(strDBServer)
            Case "ORACLE"
                oraConnection = New OracleConnection(strConnectionstring)
                oraCommand = New OracleCommand
                oraCommand.Connection = oraConnection
            Case "SQLSERVER"
                sqlConnection = New sqlConnection(strConnectionstring)
                sqlCommand = New sqlCommand
                sqlCommand.Connection = sqlConnection
        End Select
    End Sub

    ' OpenConnection method
    ' Purpose: open connection
    Public Sub OpenConnection()
        strErrorMsg = ""
        intErrorCode = 0
        Select Case UCase(strDBServer)
            Case "ORACLE"
                If oraConnection.State = ConnectionState.Closed Then
                    oraConnection.Open()
                End If
            Case "SQLSERVER"
                If sqlConnection.State = ConnectionState.Closed Then
                    sqlConnection.Open()
                End If
        End Select
    End Sub

    ' CloseConnection method
    ' Purpose: close connection
    Public Sub CloseConnection()
        Select Case UCase(strDBServer)
            Case "ORACLE"
                If Not oraConnection.State = ConnectionState.Closed Then
                    oraConnection.Close()
                End If
            Case "SQLSERVER"
                If Not sqlConnection.State = ConnectionState.Closed Then
                    sqlConnection.Close()
                End If
        End Select
    End Sub

    ' Dispose method
    ' Purpose: release all objects
    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    ' Dispose method
    ' Purpose: release all objects
    ' Input: boolean value IsDisposing
    Public Overridable Overloads Sub Dispose(ByVal IsDisposing As Boolean)
        If IsDisposing Then
            ' Release unmanaged resources.
            If Not dsData Is Nothing Then
                dsData.Dispose()
                dsData = Nothing
            End If
            If Not oraConnection Is Nothing Then
                oraConnection.Dispose()
                oraConnection = Nothing
            End If
            If Not oraCommand Is Nothing Then
                oraCommand.Dispose()
                oraCommand = Nothing
            End If
            If Not sqlConnection Is Nothing Then
                sqlConnection.Dispose()
                sqlConnection = Nothing
            End If
            If Not sqlCommand Is Nothing Then
                sqlCommand.Dispose()
                sqlCommand = Nothing
            End If
            If Not sqlDataAdapter Is Nothing Then
                sqlDataAdapter.Dispose()
                sqlDataAdapter = Nothing
            End If
            If Not oraDataAdapter Is Nothing Then
                oraDataAdapter.Dispose()
                oraDataAdapter = Nothing
            End If
        End If
    End Sub

    ' Finalize method
    ' Purpose: call Dispose(False).
    Protected Overrides Sub Finalize()
        Dispose(False)
    End Sub
End Class