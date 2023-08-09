' Purpose: process libraries informations
' Creator: Lent
' Created Date: 17-2-2005
' Last Modified Date: 

Imports System.Data
Imports System.Data.sqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Acquisition
    Public Class clsDLibrary
        Inherits clsDBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************


        Private strName As String
        Private strCode As String
        Private booLocalLib As Boolean
        Private strAddress As String
        Private strAccessEntry As String
        Private intSouLibID As Integer
        Private intDesLibID As Integer

        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************
     
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

        ' *************************************************************************************************
        ' End declare properties
        ' Declare public function 
        ' *************************************************************************************************


        ' Method: SelectID
        ' Purpose: Check Exist the library
        ' Input: library informations
        ' Output: GetID
        ' Creator: PhuongTT
        ' CreatedDate : 30-06-2008
        Public Function SelectID() As Integer
            Dim intRetVal As Integer = 0

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_HOLDING_LIBRARY_CHECK_EXIST"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strCode", OracleType.VarChar, 32)).Value = strCode
                                .Add(New OracleParameter("intRetVal", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRetVal = .Parameters("intRetVal").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHoldingLibrary_SelCheckExit"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strCode", SqlDbType.NVarChar)).Value = strCode
                                .Add(New SqlParameter("@intRetVal", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRetVal = .Parameters("@intRetVal").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            SelectID = intRetVal
        End Function


        ' Method: SelectID
        ' Purpose: Get Folder by LibID
        ' Input: library Id
        ' Output: GetID
        ' Creator: QuocDD
        ' CreatedDate : 04-09-2015

        Public Function GetFolderbyLibId() As DataTable
            Call OpenConnection()

            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Sys_spLibrary_SelFolderByLibId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetFolderbyLibId = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SP_SYS_GET_LIBRARY_BY_LIBID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetFolderbyLibId = dsData.Tables("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Method: SelectID
        ' Purpose: Get Folder by LibID
        ' Input: library Id
        ' Output: GetID
        ' Creator: QuocDD
        ' CreatedDate : 04-09-2015

        Public Function GetListFolder() As DataTable
            Call OpenConnection()

            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Sys_spLibrary_SelFolders"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetListFolder = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SP_SYS_GET_LIBRARY_BY_LIBID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetListFolder = dsData.Tables("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function


        ' Method: Create
        ' Purpose: insert one Library
        ' Input: library informations
        ' Output: 0 if successfull
        ' Creator: lent
        ' CreatedDate : 17-2-2005
        Public Function Create() As Integer
            Dim intRetVal As Integer = 0

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_HOLDING_LIBRARY_INS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strName", OracleType.VarChar, 160)).Value = strName
                                .Add(New OracleParameter("strCode", OracleType.VarChar, 32)).Value = strCode
                                .Add(New OracleParameter("strAddress", OracleType.VarChar, 240)).Value = strAddress
                                .Add(New OracleParameter("strAccessEntry", OracleType.VarChar, 32)).Value = strAccessEntry
                                .Add(New OracleParameter("intRetVal", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRetVal = .Parameters("intRetVal").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHoldingLibrary_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strName", SqlDbType.NVarChar)).Value = strName
                                .Add(New SqlParameter("@strCode", SqlDbType.NVarChar)).Value = strCode
                                .Add(New SqlParameter("@strAddress", SqlDbType.NVarChar)).Value = strAddress
                                .Add(New SqlParameter("@strAccessEntry", SqlDbType.NVarChar)).Value = strAccessEntry
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                                .Add(New SqlParameter("@intRetVal", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRetVal = .Parameters("@intRetVal").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            Create = intRetVal
        End Function

        ' Method: Update
        ' Purpose: update one Library
        ' Input: library informations
        ' Output: 0 if successfull
        ' Creator: lent
        ' CreatedDate : 17-2-2005
        Public Function Update() As Integer
            Dim intRetVal As Integer = 0

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_HOLDING_LIBRARY_UPD"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intLibID", OracleType.Number, 2)).Value = intLibID
                                .Add(New OracleParameter("strName", OracleType.VarChar, 160)).Value = strName
                                .Add(New OracleParameter("strCode", OracleType.VarChar, 32)).Value = strCode
                                .Add(New OracleParameter("strAddress", OracleType.VarChar, 240)).Value = strAddress
                                .Add(New OracleParameter("strAccessEntry", OracleType.VarChar, 32)).Value = strAccessEntry
                                .Add(New OracleParameter("intRetVal", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRetVal = .Parameters("intRetVal").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHoldingLibrary_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                                .Add(New SqlParameter("@strName", SqlDbType.NVarChar)).Value = strName
                                .Add(New SqlParameter("@strCode", SqlDbType.NVarChar)).Value = strCode
                                .Add(New SqlParameter("@strAddress", SqlDbType.NVarChar)).Value = strAddress
                                .Add(New SqlParameter("@strAccessEntry", SqlDbType.NVarChar)).Value = strAccessEntry
                                .Add(New SqlParameter("@intRetVal", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRetVal = .Parameters("@intRetVal").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            Update = intRetVal
        End Function

        ' Purpose: merger one Library into other lib
        ' Input: 
        ' Output: 
        ' Creator: lent
        ' CreatedDate : 17-2-2005
        Public Sub MergeLibrary(ByVal strSouLibIDs As String)
            Call OpenConnection()

            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_HOLDING_LIBRARY_MER"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strSouLibIDs", OracleType.VarChar, 1000)).Value = strSouLibIDs
                                .Add(New OracleParameter("intDesLibID", OracleType.Number)).Value = intDesLibID
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
                    With sqlCommand
                        .CommandText = "Lib_spHoldingLibrary_Merge"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strSouLibIDs", SqlDbType.VarChar, 1000)).Value = strSouLibIDs
                                .Add(New SqlParameter("@intDesLibID", SqlDbType.Int)).Value = intDesLibID
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
            Call CloseConnection()
        End Sub

        ' Purpose : Get Holding Library
        ' In: intLibID, intLocalLib
        ' Out: Datatable
        ' Created by: Sondp
        ' Modify : Lent 29-3-2005
        Public Function GetLibrary(ByVal intStatus As Integer, ByVal intLocalLib As Integer, Optional ByVal intType As Integer = 1) As DataTable
            Call OpenConnection()

            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHoldingLibrary_SelDetail"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                                .Add(New SqlParameter("@intLocalLib", SqlDbType.Int)).Value = intLocalLib
                                .Add(New SqlParameter("@intStatus", SqlDbType.Int)).Value = intStatus
                                .Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                                .Add(New SqlParameter("@intType", SqlDbType.Int)).Value = intType
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetLibrary = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_HOLDING_LIBRARY_SELECT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUserID
                                .Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                                .Add(New OracleParameter("intLocalLib", OracleType.Number)).Value = intLocalLib
                                .Add(New OracleParameter("intStatus", OracleType.Number)).Value = intStatus
                                .Add(New OracleParameter("intType", OracleType.Number)).Value = intType
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetLibrary = dsData.Tables("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                Call MyBase.Dispose(isDisposing)
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace