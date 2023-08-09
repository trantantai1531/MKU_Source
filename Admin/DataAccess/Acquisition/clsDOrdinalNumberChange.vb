'class:clsDOrdinalNumberChange
'purpose: set ordinal number
'creator: lent
'CreateDate: 16/2/2005
'histoty update:

Imports System.Data
Imports System.Data.sqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Acquisition
    Public Class clsDOrdinalNumberChange
        Inherits clsDBase

        Private intLibID As Integer
        Private strStoreIDs As String
        Private strMaxNumber As String

        'propertys
        'get LibraryID
        Public Property LibID() As Integer
            Get
                Return (intLibID)
            End Get
            Set(ByVal Value As Integer)
                intLibID = Value
            End Set
        End Property
        'get StoreID
        Public Property StoreIDs() As String
            Get
                Return (strStoreIDs)
            End Get
            Set(ByVal Value As String)
                strStoreIDs = Value
            End Set
        End Property
        'get MaxNumber to update in holding_location
        Public Property MaxNumber() As String
            Get
                Return (strMaxNumber)
            End Get
            Set(ByVal Value As String)
                strMaxNumber = Value
            End Set
        End Property

        Function RetrieveLibLoc() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "SP_SYS_TEMPLATE_SEL_LIB_LOC"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            RetrieveLibLoc = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "ACQUISITION.SP_SYS_TEMPLATE_SEL_LIB_LOC"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                                .Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            RetrieveLibLoc = dsData.Tables("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function
        'purpose: update holding_location
        'in: StoreIDs, maxNumbers
        'out: 
        Public Sub UpdateMaxNumber()
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_HOLDING_LOCATION_MAXNUMBER"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strStoreIDs", OracleType.VarChar, 200)).Value = strStoreIDs
                                .Add(New OracleParameter("strMaxNumber", OracleType.VarChar, 200)).Value = strMaxNumber
                            End With
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHoldingLocation_SelMaxNumber"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strStoreIDs", SqlDbType.VarChar, 200)).Value = strStoreIDs
                                .Add(New SqlParameter("@strMaxNumber", SqlDbType.VarChar, 200)).Value = strMaxNumber
                            End With
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Sub
        ' Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not oraCommand Is Nothing Then
                    oraCommand.Dispose()
                    oraCommand = Nothing
                End If
                If Not SqlCommand Is Nothing Then
                    SqlCommand.Dispose()
                    SqlCommand = Nothing
                End If
                If Not SqlConnection Is Nothing Then
                    SqlConnection.Close()
                    SqlConnection.Dispose()
                    SqlConnection = Nothing
                End If
                If Not oraConnection Is Nothing Then
                    oraConnection.Close()
                    oraConnection.Dispose()
                    oraConnection = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace