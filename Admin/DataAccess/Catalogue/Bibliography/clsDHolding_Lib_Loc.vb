' Purpose: 
' Creator: Vantd
' Created Date: 31/05/2004
' Last Update By Vantd : 31/05/2004
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType
Namespace Libol60.DataAccess.Catalogue
    Public Class clsDHolding_Lib_Loc
        Inherits clsDBase
        ' ***********************************************************************
        ' Declare variables
        ' ***********************************************************************
        Private strName As String
        Private strCode As String
        Private intLibID As Integer
        Private intLocID As Integer
        Private bytLocalLib As Byte
        Private strAddress As String
        Private intSrcLibID As Integer
        Private intDesLibID As Integer

        ' LibID property
        Public Property LibID() As Integer
            Get
                Return (intLibID)
            End Get
            Set(ByVal Value As Integer)
                intLibID = Value
            End Set
        End Property

        ' LocID property
        Public Property LocID() As Integer
            Get
                Return (intLocID)
            End Get
            Set(ByVal Value As Integer)
                intLocID = Value
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
        Public Property LocalLib() As Byte
            Get
                Return (bytLocalLib)
            End Get
            Set(ByVal Value As Byte)
                bytLocalLib = Value
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

        ' SouLibID property
        Public Property SrcLibID() As Integer
            Get
                Return (intSrcLibID)
            End Get
            Set(ByVal Value As Integer)
                intSrcLibID = Value
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

        ' Retrieve_Lib method
        Public Function Retrieve_Lib() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "SP_HOLDING_LIBRARY_SELECT"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            .Add(New SqlParameter("@intLocalLib", SqlDbType.Int)).Value = bytLocalLib
                            .Add(New SqlParameter("@intStatus", SqlDbType.Int)).Value = -1
                        End With
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "HOLDINGLIB")
                            Retrieve_Lib = dsData.Tables("HOLDINGLIB")
                            dsData.Tables.Remove("HOLDINGLIB")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SP_HOLDING_LIBRARY_SEL"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                            .Add(New OracleParameter("intLocalLib", OracleType.Number)).Value = bytLocalLib
                            .Add(New OracleParameter("intStatus", OracleType.Number)).Value = -1
                        End With
                        Try
                            OraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "HOLDINGLIB")
                            Retrieve_Lib = dsData.Tables("HOLDINGLIB")
                            dsData.Tables.Remove("HOLDINGLIB")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Retrieve_Loc method
        Public Function Retrieve_Loc() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "SP_HOLDING_LOCATION_SEL"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            .Add(New SqlParameter("@intStoreID", SqlDbType.Int)).Value = intLocID
                            .Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                        End With
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "HOLDINGLOC")
                            Retrieve_Loc = dsData.Tables("HOLDINGLOC")
                            dsData.Tables.Remove("HOLDINGLOC")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_HOLDING_LOCATION_SEL"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                            .Add(New OracleParameter("intStoreID", OracleType.Number)).Value = intLocID
                            .Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUserID
                        End With
                        Try
                            OraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "HOLDINGLOC")
                            Retrieve_Loc = dsData.Tables("HOLDINGLOC")
                            dsData.Tables.Remove("HOLDINGLOC")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Number
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
                Call MyBase.Dispose(True)
            Finally
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace