' Purpose: process libraries informations
' Creator: Sondp
' Created Date: 28/4/2004

Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.oleDb.OleDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType
Imports Libol60.DataAccess.Common

Namespace Libol60.DataAccess.Catalogue
    Public Class clsDHoldingLibrary
        Inherits clsDBase

        ' ***********************************************************************
        ' Declare variables
        ' ***********************************************************************

        Private oraDA As New OracleDataAdapter
        Private sqlDA As New SqlDataAdapter
        Private objDS As New DataSet

        Private strName As String
        Private strCode As String
        Private intLibID As Integer
        Private booLocalLib As Boolean
        Private strAddress As String
        Private strAccessEntry As String
        Private intSouLibID As Integer
        Private intDesLibID As Integer

        Private intRetVal As Integer
        Private strSQL As String

        ' ***********************************************************************
        ' End declare variables
        ' Declare properties
        ' ***********************************************************************

        ' LibID property
        Public Property LibID() As Integer
            Get
                Return (intLibID)
            End Get
            Set(ByVal Value As Integer)
                intLibID = Value
            End Set
        End Property

        ' Name property
        Public Property Name() As String
            Get
                Return (strName)
            End Get
            Set(ByVal Value As String)
                strName = Value
            End Set
        End Property

        ' Code property
        Public Property Code() As String
            Get
                Return (strCode)
            End Get
            Set(ByVal Value As String)
                strCode = Value
            End Set
        End Property

        ' LocalLib property
        Public Property LocalLib() As Boolean
            Get
                Return (booLocalLib)
            End Get
            Set(ByVal Value As Boolean)
                booLocalLib = Value
            End Set
        End Property

        ' Address property
        Public Property Address() As String
            Get
                Return (strAddress)
            End Get
            Set(ByVal Value As String)
                strAddress = Value
            End Set
        End Property

        ' AccessEntry property
        Public Property AccessEntry() As String
            Get
                Return (strAccessEntry)
            End Get
            Set(ByVal Value As String)
                strAccessEntry = Value
            End Set
        End Property

        ' SouLibID property
        Public Property SouLibID() As Integer
            Get
                Return (intSouLibID)
            End Get
            Set(ByVal Value As Integer)
                intSouLibID = Value
            End Set
        End Property

        ' DesLibID property
        Public Property DesLibID() As Integer
            Get
                Return (intDesLibID)
            End Get
            Set(ByVal Value As Integer)
                intDesLibID = Value
            End Set
        End Property

        ' RetVal property
        Public ReadOnly Property RetVal() As Integer
            Get
                Return (intRetVal)
            End Get
        End Property

        ' SQL property
        Public ReadOnly Property SQL() As String
            Get
                Return (strSQL)
            End Get
        End Property

        ' ***********************************************************************
        ' End declare properties
        ' Implement methods
        ' ***********************************************************************

        ' Initalize method
        ' Purpose: init all need object
        Public Sub Initalize()
            Select Case (strDBServer)
                Case "ORACLE"
                    Try
                        oraConnection = New OracleConnection(strConnectionstring)
                        oraConnection.Open()
                        oraCommand = New OracleCommand
                        oraCommand.Connection = oraConnection
                    Catch ex As OracleException
                        intErrorCode = ex.Code
                        strErrorMsg = ex.Message.ToString
                    End Try
                Case "SQLSERVER"
                    Try
                        sqlConnection = New SqlConnection(strConnectionstring)
                        sqlConnection.Open()
                        sqlCommand = New SqlCommand
                        sqlCommand.Connection = sqlConnection
                    Catch ex As SqlException
                        intErrorCode = ex.Number
                        strErrorMsg = ex.Message.ToString
                    End Try
            End Select
        End Sub

        ' Retrieve method
        ' Pupuse: retrieve all fields in library_location
        ' Input: strLibID or not
        Public Function Retrieve() As DataTable
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_HOLDING_LIBRARY_SEL"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("intLibID", OracleType.Number, 2)).Value = intLibID
                            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        End With
                        Try
                            .ExecuteNonQuery()
                            oraDA.SelectCommand = oraCommand
                            oraDA.Fill(objDS, "LIBRARYSELECT")
                            Retrieve = objDS.Tables("LIBRARYSELECT")
                            objDS.Tables.Remove("LIBRARYSELECT")
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "SP_HOLDING_LIBRARY_SEL"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                        End With
                        Try
                            .ExecuteNonQuery()
                            sqlDA.SelectCommand = sqlCommand
                            sqlDA.Fill(objDS, "LIBRARYSELECT")
                            Retrieve = objDS.Tables("LIBRARYSELECT")
                            objDS.Tables.Remove("LIBRARYSELECT")
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
        End Function

        'Purpose: insert a new record in to Holding_library table
        'Input: Address,Code,Name,LocalLib,AccessEntry
        'Output: datatable
        Public Sub Insert()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SP_HOLDING_LIBRARY_INS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strName", OracleType.NVarChar, 160)).Value = strName
                                .Add(New OracleParameter("strCode", OracleType.NVarChar, 32)).Value = strName
                                .Add(New OracleParameter("strAddress", OracleType.NVarChar, 240)).Value = strAddress
                                .Add(New OracleParameter("strAccessEntry", OracleType.NVarChar, 32)).Value = strAccessEntry
                                .Add(New OracleParameter("intRetVal", OracleType.Number, 2)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRetVal = .Parameters("intRetVal").Value
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "SP_HOLDING_LIBRARY_INS"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@strName", SqlDbType.NVarChar)).Value = strName
                            .Add(New SqlParameter("@strCode", SqlDbType.NVarChar)).Value = strCode
                            .Add(New SqlParameter("@strAddress", SqlDbType.NVarChar)).Value = strAddress
                            .Add(New SqlParameter("@strAccessEntry", SqlDbType.NVarChar)).Value = strAccessEntry
                            .Add(New SqlParameter("@intRetVal", SqlDbType.Int)).Direction = ParameterDirection.Output
                        End With
                        Try
                            .ExecuteNonQuery()
                            intRetVal = .Parameters("@intRetVal").Value
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
        End Sub

        ' Update Method
        ' Purpose: update a record in to Holding_library table
        ' Input: LibID,Address (if need),Code,Name,LocalLib,AccessEntry
        Public Sub Update()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SP_HOLDING_LIBRARY_UPD"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intLibID", OracleType.Number, 2)).Value = intLibID
                                .Add(New OracleParameter("strName", OracleType.NVarChar, 160)).Value = strName
                                .Add(New OracleParameter("strCode", OracleType.NVarChar, 32)).Value = strCode
                                .Add(New OracleParameter("strAddress", OracleType.NVarChar, 240)).Value = strAddress
                                .Add(New OracleParameter("strAccessEntry", OracleType.NVarChar, 32)).Value = strAccessEntry
                                .Add(New OracleParameter("intRetVal", OracleType.Number, 2)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRetVal = .Parameters("intRetVal").Value
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "SP_HOLDING_LIBRARY_UPD"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            .Add(New SqlParameter("@strName", SqlDbType.NVarChar)).Value = strName
                            .Add(New SqlParameter("@strCode", SqlDbType.NVarChar)).Value = strCode
                            .Add(New SqlParameter("@strAddress", SqlDbType.NVarChar)).Value = strAddress
                            .Add(New SqlParameter("@strAccessEntry", SqlDbType.NVarChar)).Value = strAccessEntry
                            .Add(New SqlParameter("@intRetVal", SqlDbType.Int)).Direction = ParameterDirection.Output
                        End With
                        Try
                            .ExecuteNonQuery()
                            intRetVal = .Parameters("@intRetVal").Value
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
        End Sub

        ' Merge method
        ' Purpose: merge 2 lib in Holding_library table
        ' Input: SouLibID,DesLibID
        Public Sub Merge()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SP_HOLDING_LIBRARY_MER"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intSouLibID", OracleType.Number, 2)).Value = intSouLibID
                                .Add(New OracleParameter("intDesLibID", OracleType.Number, 2)).Value = intDesLibID
                            End With
                            .ExecuteNonQuery()
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "SP_HOLDING_LIBRARY_MER"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intSouLibID", SqlDbType.Int)).Value = intSouLibID
                            .Add(New SqlParameter("@intDesLibID", SqlDbType.Int)).Value = intDesLibID
                        End With
                        Try
                            .ExecuteNonQuery()
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
        End Sub

        ' Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not oraCommand Is Nothing Then
                        oraCommand.Dispose()
                        oraCommand = Nothing
                    End If
                    If Not sqlCommand Is Nothing Then
                        sqlCommand.Dispose()
                        sqlCommand = Nothing
                    End If
                    If Not sqlConnection Is Nothing Then
                        sqlConnection.Close()
                        sqlConnection.Dispose()
                        sqlConnection = Nothing
                    End If
                    If Not oraConnection Is Nothing Then
                        oraConnection.Close()
                        oraConnection.Dispose()
                        oraConnection = Nothing
                    End If
                    If Not sqlDA Is Nothing Then
                        sqlDA.Dispose()
                        sqlDA = Nothing
                    End If
                    If Not oraDA Is Nothing Then
                        oraDA.Dispose()
                        oraDA = Nothing
                    End If
                    If Not objDS Is Nothing Then
                        objDS.Dispose()
                        objDS = Nothing
                    End If
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace