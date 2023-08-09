Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Circulation
    Public Class clsDPhotocopyType
        Inherits clsDBase

        ' *****************************************************************************************************
        ' Declare member variables
        ' *****************************************************************************************************

        Private intTypeID As Integer = 0
        Private strTypeName As String = ""
        Private dblPricePerPage As Double = 0
        Private strTypeIDs As String

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' TypeID property
        Public Property TypeIDs() As String
            Get
                Return strTypeIDs
            End Get
            Set(ByVal Value As String)
                strTypeIDs = Value
            End Set
        End Property

        ' TypeID property
        Public Property TypeID() As Integer
            Get
                Return intTypeID
            End Get
            Set(ByVal Value As Integer)
                intTypeID = Value
            End Set
        End Property

        ' TypeName property
        Public Property TypeName() As String
            Get
                Return strTypeName
            End Get
            Set(ByVal Value As String)
                strTypeName = Value
            End Set
        End Property

        ' PricePerPage property
        Public Property PricePerPage() As Double
            Get
                Return dblPricePerPage
            End Get
            Set(ByVal Value As Double)
                dblPricePerPage = Value
            End Set
        End Property

        Public Function CreatePhotocopyType() As Integer
            Dim intRetVal As Integer = 0

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPhotocopyPrice_Ins"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@strTypeName", SqlDbType.NVarChar, 30)).Value = strTypeName
                            .Add(New SqlParameter("@monPricePerPage", SqlDbType.Money)).Value = dblPricePerPage
                            .Add(New SqlParameter("@intRetVal", SqlDbType.Int)).Direction = ParameterDirection.Output
                        End With
                        Try
                            .ExecuteNonQuery()
                            intRetVal = .Parameters("@intRetVal").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_CIR_PHOTO_PRICE_INS"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("strTypeName", OracleType.VarChar, 30)).Value = strTypeName
                            .Add(New OracleParameter("monPricePerPage", OracleType.Double)).Value = dblPricePerPage
                            .Add(New OracleParameter("intRetVal", OracleType.Number)).Direction = ParameterDirection.Output
                        End With
                        Try
                            .ExecuteNonQuery()
                            intRetVal = .Parameters("intRetVal").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            Return intRetVal
        End Function

        Public Function UpdatePhotocopyType() As Integer
            Dim intRetVal As Integer = 0

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPhotocopyPrice_Upd"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intTypeID", SqlDbType.Int)).Value = intTypeID
                            .Add(New SqlParameter("@strTypeName", SqlDbType.NVarChar, 30)).Value = strTypeName
                            .Add(New SqlParameter("@monPricePerPage", SqlDbType.Money)).Value = dblPricePerPage
                            .Add(New SqlParameter("@intRetVal", SqlDbType.Int)).Direction = ParameterDirection.Output
                        End With
                        Try
                            .ExecuteNonQuery()
                            intRetVal = .Parameters("@intRetVal").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_CIR_PHOTO_PRICE_UPD"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("intTypeID", OracleType.Number)).Value = intTypeID
                            .Add(New OracleParameter("strTypeName", OracleType.VarChar, 30)).Value = strTypeName
                            .Add(New OracleParameter("monPricePerPage", OracleType.Double)).Value = dblPricePerPage
                            .Add(New OracleParameter("intRetVal", OracleType.Number)).Direction = ParameterDirection.Output
                        End With
                        Try
                            .ExecuteNonQuery()
                            intRetVal = .Parameters("intRetVal").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            Return intRetVal
        End Function

        ' DeletePhotocopyType method
        ' Purpose: Delete information of the selected PhotocopyType
        ' Input: intTypeID
        Public Sub DeletePhotocopyType()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPhotocopyPrice_Del"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strTypeIDs", SqlDbType.VarChar, 500)).Value = strTypeIDs
                        Try
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_CIR_PHOTO_PRICE_DEL"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("strTypeIDs", OracleType.VarChar, 500)).Value = intTypeID
                        Try
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        ' GetPhotocopyTypes method
        ' Purpose: Get information of all PhotocopyTypes
        ' Input: 
        ' Output: datatable result
        Public Function GetPhotocopyTypes() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPhotocopyPrice_Sel"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strTypeIDs", SqlDbType.VarChar, 1000)).Value = strTypeIDs
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblPhotoType")
                            GetPhotocopyTypes = dsData.Tables("tblPhotoType")
                            dsData.Tables.Remove("tblPhotoType")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_CIR_PHOTO_PRICE_SEL"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("strTypeIDs", OracleType.VarChar, 1000)).Value = strTypeIDs
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblPhotoType")
                            GetPhotocopyTypes = dsData.Tables("tblPhotoType")
                            dsData.Tables.Remove("tblPhotoType")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not oraConnection Is Nothing Then
                        oraConnection.Dispose()
                        oraConnection = Nothing
                    End If
                    If Not oraCommand Is Nothing Then
                        oraCommand.Dispose()
                        oraCommand = Nothing
                    End If
                    If Not oraDataAdapter Is Nothing Then
                        oraDataAdapter.Dispose()
                        oraDataAdapter = Nothing
                    End If
                    If Not SqlConnection Is Nothing Then
                        SqlConnection.Dispose()
                        SqlConnection = Nothing
                    End If
                    If Not SqlCommand Is Nothing Then
                        SqlCommand.Dispose()
                        SqlCommand = Nothing
                    End If
                    If Not SqlDataAdapter Is Nothing Then
                        SqlDataAdapter.Dispose()
                        SqlDataAdapter = Nothing
                    End If
                    If Not dsData Is Nothing Then
                        dsData.Dispose()
                        dsData = Nothing
                    End If
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace