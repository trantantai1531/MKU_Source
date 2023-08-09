Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType
Namespace eMicLibAdmin.DataAccess.Catalogue
    Public Class clsDFiche
        Inherits clsDBase

        ' Declare variables
        Private intItemType As Integer
        Private strCopyNumFrom As String
        Private strCopyNumTo As String
        Private strItemCodes As String
        Private intMultiFiche As Integer
        Private intItemIDFrom As Integer
        Private intItemIDTo As Integer
        Private intLibID As Integer
        Private intLocID As Integer
        Private intNewItemOnly As Integer
        Private strOUT As String

        Private strItemCodeFrom As String
        Private strItemCodeTo As String

        ' SQLOUT property
        Public ReadOnly Property SQLOUT() As String
            Get
                Return strOUT
            End Get
        End Property

        ' ItemType property
        Public Property ItemType() As Integer
            Get
                Return intItemType
            End Get
            Set(ByVal Value As Integer)
                intItemType = Value
            End Set
        End Property

        ' CopyNumFrom property
        Public Property CopyNumFrom() As String
            Get
                Return strCopyNumFrom
            End Get
            Set(ByVal Value As String)
                strCopyNumFrom = Value
            End Set
        End Property

        ' CopyNumTo property
        Public Property CopyNumTo() As String
            Get
                Return strCopyNumTo
            End Get
            Set(ByVal Value As String)
                strCopyNumTo = Value
            End Set
        End Property

        ' CopyNums property
        Public Property ItemCodes() As String
            Get
                Return strItemCodes
            End Get
            Set(ByVal Value As String)
                strItemCodes = Value
            End Set
        End Property

        ' MultiFiche property
        Public Property MultiFiche() As Integer
            Get
                Return intMultiFiche
            End Get
            Set(ByVal Value As Integer)
                intMultiFiche = Value
            End Set
        End Property

        ' ItemIDFrom property
        Public Property ItemIDFrom() As Integer
            Get
                Return intItemIDFrom
            End Get
            Set(ByVal Value As Integer)
                intItemIDFrom = Value
            End Set
        End Property

        ' ItemIDTo property
        Public Property ItemIDTo() As Integer
            Get
                Return intItemIDTo
            End Get
            Set(ByVal Value As Integer)
                intItemIDTo = Value
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

        ' LocID property
        Public Property LocID() As Integer
            Get
                Return intLocID
            End Get
            Set(ByVal Value As Integer)
                intLocID = Value
            End Set
        End Property

        ' NewItemOnly property
        Public Property NewItemOnly() As Integer
            Get
                Return intNewItemOnly
            End Get
            Set(ByVal Value As Integer)
                intNewItemOnly = Value
            End Set
        End Property

        ' ItemIDFrom property
        Public Property ItemCodeFrom() As String
            Get
                Return strItemCodeFrom
            End Get
            Set(ByVal Value As String)
                strItemCodeFrom = Value
            End Set
        End Property

        ' ItemIDTo property
        Public Property ItemCodeTo() As String
            Get
                Return strItemCodeTo
            End Get
            Set(ByVal Value As String)
                strItemCodeTo = Value
            End Set
        End Property

        ' Retrieve_ItemID method
        Public Function Retrieve_ItemID() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Acq_spPrintFicheSel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intItemType", SqlDbType.Int)).Value = intItemType
                                .Add(New SqlParameter("@strCopyNumFrom", SqlDbType.VarChar, 100)).Value = strCopyNumFrom
                                .Add(New SqlParameter("@strCopyNumTo", SqlDbType.VarChar, 100)).Value = strCopyNumTo
                                .Add(New SqlParameter("@intMultiFiche", SqlDbType.Int)).Value = intMultiFiche
                                .Add(New SqlParameter("@intItemIDFrom", SqlDbType.Int)).Value = intItemIDFrom
                                .Add(New SqlParameter("@intItemIDTo", SqlDbType.Int)).Value = intItemIDTo
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                                .Add(New SqlParameter("@intLocID", SqlDbType.Int)).Value = intLocID
                                .Add(New SqlParameter("@intNewItemOnly", SqlDbType.Int)).Value = intNewItemOnly
                                .Add(New SqlParameter("@strOUT", SqlDbType.VarChar, 4000)).Direction = ParameterDirection.Output
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            strOUT = .Parameters("@strOUT").Value
                            Retrieve_ItemID = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_PRINT_FICHE_SEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intItemType", OracleType.Number)).Value = intItemType
                                .Add(New OracleParameter("strCopyNumFrom", OracleType.VarChar, 100)).Value = strCopyNumFrom
                                .Add(New OracleParameter("strCopyNumTo", OracleType.VarChar, 100)).Value = strCopyNumTo
                                .Add(New OracleParameter("intMultiFiche", OracleType.Number)).Value = intMultiFiche
                                .Add(New OracleParameter("intItemIDFrom", OracleType.Number)).Value = intItemIDFrom
                                .Add(New OracleParameter("intItemIDTo", OracleType.Number)).Value = intItemIDTo
                                .Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                                .Add(New OracleParameter("intLocID", OracleType.Number)).Value = intLocID
                                .Add(New OracleParameter("intNewItemOnly", OracleType.Number)).Value = intNewItemOnly
                                .Add(New OracleParameter("strOutSQL", OracleType.VarChar, 4000)).Direction = ParameterDirection.Output
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            strOUT = .Parameters("strOutSQL").Value
                            Retrieve_ItemID = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Retrieve_ItemCode method
        Public Function Retrieve_ItemCode() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Acq_spPrintFicheSelOther"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intItemType", SqlDbType.Int)).Value = intItemType
                                .Add(New SqlParameter("@strCopyNumFrom", SqlDbType.VarChar, 100)).Value = strCopyNumFrom
                                .Add(New SqlParameter("@strCopyNumTo", SqlDbType.VarChar, 100)).Value = strCopyNumTo
                                .Add(New SqlParameter("@intMultiFiche", SqlDbType.Int)).Value = intMultiFiche
                                .Add(New SqlParameter("@strItemCodes", SqlDbType.VarChar, 1000)).Value = strItemCodes
                                .Add(New SqlParameter("@intItemCodeFrom", SqlDbType.VarChar, 100)).Value = strItemCodeFrom
                                .Add(New SqlParameter("@intItemCodeTo", SqlDbType.VarChar, 100)).Value = strItemCodeTo
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                                .Add(New SqlParameter("@intLocID", SqlDbType.Int)).Value = intLocID
                                .Add(New SqlParameter("@intNewItemOnly", SqlDbType.Int)).Value = intNewItemOnly
                                .Add(New SqlParameter("@strOUT", SqlDbType.VarChar, 4000)).Direction = ParameterDirection.Output
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            strOUT = .Parameters("@strOUT").Value
                            Retrieve_ItemCode = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_PRINT_FICHE_SEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intItemType", OracleType.Number)).Value = intItemType
                                .Add(New OracleParameter("strCopyNumFrom", OracleType.VarChar, 100)).Value = strCopyNumFrom
                                .Add(New OracleParameter("strCopyNumTo", OracleType.VarChar, 100)).Value = strCopyNumTo
                                .Add(New OracleParameter("intMultiFiche", OracleType.Number)).Value = intMultiFiche
                                .Add(New OracleParameter("intItemCodeFrom", OracleType.VarChar, 100)).Value = strItemCodeFrom
                                .Add(New OracleParameter("intItemCodeTo", OracleType.VarChar, 100)).Value = strItemCodeTo
                                .Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                                .Add(New OracleParameter("intLocID", OracleType.Number)).Value = intLocID
                                .Add(New OracleParameter("intNewItemOnly", OracleType.Number)).Value = intNewItemOnly
                                .Add(New OracleParameter("strOutSQL", OracleType.VarChar, 4000)).Direction = ParameterDirection.Output
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            strOUT = .Parameters("strOutSQL").Value
                            Retrieve_ItemCode = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Code
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