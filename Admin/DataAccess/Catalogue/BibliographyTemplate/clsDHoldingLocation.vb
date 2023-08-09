' Purpose: process location(store) informations
' Creator: Sondp
' Created Date: 28/4/2004
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.oleDb.OleDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType
Imports Libol60.DataAccess.Common

Namespace Libol60.DataAccess.Catalogue
    Public Class clsDHoldingLocation
        Inherits clsDBase

        ' ***********************************************************************
        ' Declare variables
        ' ***********************************************************************

        Private oraDA As New OracleDataAdapter
        Private sqlDA As New SqlDataAdapter
        Private objDS As New DataSet

        Private strID As String = ""
        Private intLibID As Integer = 0
        Private intID As Integer = 0
        Private strSymbol As String
        Private blnStatus As Boolean
        Private intMaxNumberINC As Integer
        Private intMaxNumberNEW As Integer


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

        ' Symbol property
        Public Property Symbol() As String
            Get
                Return (strSymbol)
            End Get
            Set(ByVal Value As String)
                strSymbol = Value
            End Set
        End Property

        ' Status property
        Public Property Status() As Boolean
            Get
                Return (blnStatus)
            End Get
            Set(ByVal Value As Boolean)
                blnStatus = Value
            End Set
        End Property


        ' MaxNumberINC property
        Public Property MaxNumberINC() As Integer
            Get
                Return intMaxNumberINC
            End Get
            Set(ByVal Value As Integer)
                intMaxNumberINC = Value
            End Set
        End Property

        ' MaxNumberNEW
        Public Property MaxNumberNew() As Integer
            Get
                Return intMaxNumberNEW
            End Get
            Set(ByVal Value As Integer)
                intMaxNumberNEW = Value
            End Set
        End Property

        ' ID property
        Public Property ID() As Integer
            Get
                Return intID
            End Get
            Set(ByVal Value As Integer)
                intID = Value
            End Set
        End Property

        'IDs property
        Public Property IDs() As String
            Get
                Return strID
            End Get
            Set(ByVal Value As String)
                strID = Value
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
                        .CommandText = "ACQUISITION.SP_HOLDING_LOCATION_SEL"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("intLibID", OracleType.Number, 2)).Value = intLibID
                            .Add(New OracleParameter("intStoreID", OracleType.Number, 2)).Value = intID
                            .Add(New OracleParameter("intUserID", OracleType.Number, 2)).Value = intUserID
                            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        End With
                        Try
                            .ExecuteNonQuery()
                            oraDA.SelectCommand = oraCommand
                            oraDA.Fill(objDS, "HOLDLOC")
                            Retrieve = objDS.Tables("HOLDLOC")
                            objDS.Tables.Remove("HOLDLOC")
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "SP_HOLDING_LOCATION_SEL"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            .Add(New SqlParameter("@intStoreID", SqlDbType.Int)).Value = intID
                            .Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                        End With
                        Try
                            .ExecuteNonQuery()
                            sqlDA.SelectCommand = sqlCommand
                            sqlDA.Fill(objDS, "HOLDLOC")
                            Retrieve = objDS.Tables("HOLDLOC")
                            objDS.Tables.Remove("HOLDLOC")
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
                Case "SQLSERVER"
            End Select
        End Sub

        ' Update Method
        ' Purpose: Icrease MaxNumber Field
        ' Input: ID,intMaxNum
        Public Sub Update()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SP_HOLDING_LOCATION_INCMAXNUM"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("intID", OracleType.Number)).Value = CInt(strID)
                            .Add(New OracleParameter("intValINC", OracleType.Number)).Value = intMaxNumberINC
                            .Add(New OracleParameter("intValNew", OracleType.Number)).Value = intMaxNumberNEW
                        End With
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "SP_HOLDING_LOCATION_INCMAXNUM"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intID", SqlDbType.Int)).Value = CInt(strID)
                            .Add(New SqlParameter("@intValINC", SqlDbType.Int)).Value = intMaxNumberINC
                            .Add(New SqlParameter("@intValNew", SqlDbType.Int)).Value = intMaxNumberNEW
                        End With
                        Try
                            .ExecuteNonQuery()
                        Catch ex As SqlException
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
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
                Case "SQLSERVER"
            End Select
        End Sub
        ' RetrieveHoldingLib method
        ' Purpose: Retrieve holding all locations of all libraries in system
        ' Input: int value of UserID
        ' Output: DataTable
        Public Function RetrieveHoldingLibLoc() As DataTable
            Dim dsTemp As New DataSet
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    Dim oraDataAdapter As OracleDataAdapter
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_HOLDING_LIBLOC_SEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUserID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter = New OracleDataAdapter(oraCommand)
                            oraDataAdapter.Fill(dsTemp, "LIBLOC")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    Dim sqlClientDataAdapter As SqlDataAdapter
                    With sqlCommand
                        .CommandText = "SP_HOLDING_LIBLOC_SEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                            sqlClientDataAdapter = New SqlDataAdapter(sqlCommand)
                            sqlClientDataAdapter.Fill(dsTemp, "LIBLOC")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            RetrieveHoldingLibLoc = dsTemp.Tables(0)
            dsTemp.Dispose()
            dsTemp = Nothing
        End Function
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