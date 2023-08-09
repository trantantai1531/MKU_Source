' Name: clsDZ3950Server
' Purpose: Z3950 purpose
' Creator: Sondp
' Created Date: 02/12/2004
' Modification History:
'   - 05/01/2005 by Oanhtn: review

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.ILL
    Public Class clsDZ3950Server
        Inherits clsDBase

        ' ***********************************************************************************************
        ' Declare Private variables
        ' ***********************************************************************************************

        Private intServerID As Integer
        Private strName As String
        Private strHost As String
        Private intPort As Integer
        Private strAccount As String
        Private strPassword As String
        Private bytPrefer As Byte
        Private intDBID As Integer
        Private strDBName As String
        Private strDescription As String

        ' ***********************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' ***********************************************************************************************

        ' ServerID property
        Public Property ServerID() As Integer
            Get
                Return (intServerID)
            End Get
            Set(ByVal Value As Integer)
                intServerID = Value
            End Set
        End Property

        ' Port property
        Public Property Port() As Integer
            Get
                Return (intPort)
            End Get
            Set(ByVal Value As Integer)
                intPort = Value
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

        ' Host property
        Public Property Host() As String
            Get
                Return (strHost)
            End Get
            Set(ByVal Value As String)
                strHost = Value
            End Set
        End Property

        ' Account property
        Public Property Account() As String
            Get
                Return (strAccount)
            End Get
            Set(ByVal Value As String)
                strAccount = Value
            End Set
        End Property

        ' Password property
        Public Property Password() As String
            Get
                Return (strPassword)
            End Get
            Set(ByVal Value As String)
                strPassword = Value
            End Set
        End Property

        ' Prefer property
        Public Property Prefer() As Byte
            Get
                Return (bytPrefer)
            End Get
            Set(ByVal Value As Byte)
                bytPrefer = Value
            End Set
        End Property

        ' DBID property
        Public Property DBID() As Integer
            Get
                Return (intDBID)
            End Get
            Set(ByVal Value As Integer)
                intDBID = Value
            End Set
        End Property

        ' Description property
        Public Property Description() As String
            Get
                Return (strDescription)
            End Get
            Set(ByVal Value As String)
                strDescription = Value
            End Set
        End Property

        ' DBName property
        Public Property DBName() As String
            Get
                Return (strDBName)
            End Get
            Set(ByVal Value As String)
                strDBName = Value
            End Set
        End Property

        ' ***********************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' ***********************************************************************************************

        ' Createnew Z3950 method
        ' Purpose: Create Z3950
        ' Input: All info of Host
        ' Creator: by Lent
        Public Function CreateNew() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spZ3950Server_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strName", SqlDbType.NVarChar, 50)).Value = strName
                                .Add(New SqlParameter("@strHost", SqlDbType.NVarChar, 50)).Value = strHost
                                .Add(New SqlParameter("@intPort", SqlDbType.Int, 4)).Value = intPort
                                .Add(New SqlParameter("@strAccount", SqlDbType.VarChar, 50)).Value = strAccount
                                .Add(New SqlParameter("@strPassword", SqlDbType.VarChar, 50)).Value = strPassword
                                .Add(New SqlParameter("@bytPrefer", SqlDbType.Bit)).Value = bytPrefer
                                .Add(New SqlParameter("@intResult", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            CreateNew = .Parameters("@intResult").Value
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_INSERT_ZSERVER_LIST"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strName", OracleType.VarChar, 256)).Value = strName
                                .Add(New OracleParameter("strHost", OracleType.VarChar, 50)).Value = strHost
                                .Add(New OracleParameter("intPort", OracleType.Number, 4)).Value = intPort
                                .Add(New OracleParameter("strAccount", OracleType.VarChar, 50)).Value = strAccount
                                .Add(New OracleParameter("strPassword", OracleType.VarChar, 50)).Value = strPassword
                                .Add(New OracleParameter("bytPrefer", OracleType.Number, 1)).Value = bytPrefer
                                .Add(New OracleParameter("intResult", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            CreateNew = .Parameters("intResult").Value
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

        ' Update Z3950 method
        ' Purpose: Update Z3950
        ' Input: All info of Host
        ' Creator: by Lent
        Public Function Update() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spZ3950Server_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intServerID", SqlDbType.Int, 4)).Value = intServerID
                                .Add(New SqlParameter("@strName", SqlDbType.NVarChar, 50)).Value = strName
                                .Add(New SqlParameter("@strHost", SqlDbType.NVarChar, 50)).Value = strHost
                                .Add(New SqlParameter("@intPort", SqlDbType.Int, 4)).Value = intPort
                                .Add(New SqlParameter("@strAccount", SqlDbType.VarChar, 50)).Value = strAccount
                                .Add(New SqlParameter("@strPassword", SqlDbType.VarChar, 50)).Value = strPassword
                                .Add(New SqlParameter("@bytPrefer", SqlDbType.Bit)).Value = bytPrefer
                                .Add(New SqlParameter("@intResult", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            Update = .Parameters("@intResult").Value
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_UPDATE_ZSERVER_LIST"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intServerID", OracleType.Number, 4)).Value = intServerID
                                .Add(New OracleParameter("strName", OracleType.VarChar, 256)).Value = strName
                                .Add(New OracleParameter("strHost", OracleType.VarChar, 50)).Value = strHost
                                .Add(New OracleParameter("intPort", OracleType.Number, 4)).Value = intPort
                                .Add(New OracleParameter("strAccount", OracleType.VarChar, 50)).Value = strAccount
                                .Add(New OracleParameter("strPassword", OracleType.VarChar, 50)).Value = strPassword
                                .Add(New OracleParameter("bytPrefer", OracleType.Number, 1)).Value = bytPrefer
                                .Add(New OracleParameter("intResult", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            Update = .Parameters("intResult").Value
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

        ' Delete Z3950 method
        ' Purpose: Delete Z3950
        ' Input: ID
        ' Creator: lent
        Public Function Delete() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spZ3950Server_Del"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intServerID", SqlDbType.Int, 4)).Value = intServerID
                                .Add(New SqlParameter("@intValue", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            Delete = .Parameters("@intValue").Value
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_DELETE_ZSERVER_LIST"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("intServerID", OracleType.Number, 4)).Value = intServerID
                            .Add(New OracleParameter("intValue", OracleType.Number)).Direction = ParameterDirection.Output
                        End With
                        Try
                            .ExecuteNonQuery()
                            Delete = .Parameters("intValue").Value
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

        ' AddNewDB method
        ' Purpose: AddDB in select Z3950 selected
        ' Input: 
        ' Creator: lent
        Public Function AddNewDB() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spZ3950DB_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intServerID", SqlDbType.Int, 4)).Value = intServerID
                                .Add(New SqlParameter("@strDBName", SqlDbType.VarChar, 20)).Value = strDBName
                                .Add(New SqlParameter("@strDescription", SqlDbType.NVarChar, 200)).Value = strDescription
                                .Add(New SqlParameter("@intResult", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            AddNewDB = .Parameters("@intResult").Value
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_INSERT_Z3950_DBS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intServerID", OracleType.Number, 4)).Value = intServerID
                                .Add(New OracleParameter("strDBName", OracleType.VarChar, 20)).Value = strDBName
                                .Add(New OracleParameter("strDescription", OracleType.VarChar, 200)).Value = strDescription
                                .Add(New OracleParameter("intResult", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            AddNewDB = .Parameters("intResult").Value
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

        ' UpdateDB method
        ' Purpose: UpdateDB in select Z3950 selected
        ' Input: main informations
        ' Creator: lent
        Public Function UpdateDB() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spZ3950DB_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intServerID", SqlDbType.Int, 4)).Value = intServerID
                                .Add(New SqlParameter("@strDBName", SqlDbType.VarChar, 20)).Value = strDBName
                                .Add(New SqlParameter("@strDescription", SqlDbType.NVarChar, 200)).Value = strDescription
                                .Add(New SqlParameter("@intDBID", SqlDbType.Int, 4)).Value = intDBID
                                .Add(New SqlParameter("@intResult", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            UpdateDB = .Parameters("@intResult").Value
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_UPDATE_Z3950_DBS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intServerID", OracleType.Number, 4)).Value = intServerID
                                .Add(New OracleParameter("strDBName", OracleType.VarChar, 20)).Value = strDBName
                                .Add(New OracleParameter("strDescription", OracleType.VarChar, 200)).Value = strDescription
                                .Add(New OracleParameter("intDBID", OracleType.Number, 4)).Value = intDBID
                                .Add(New OracleParameter("intResult", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            UpdateDB = .Parameters("intResult").Value
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

        ' DeleteDB method
        ' Purpose: DeleteDB in select Z3950 selected
        ' Input: 
        ' Creator: 
        Public Sub DeleteDB()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spZ3950DB_Del"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intDBID", SqlDbType.Int, 4)).Value = intDBID
                            End With
                            .ExecuteNonQuery()
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_DELETE_Z3950_DBS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intDBID", OracleType.Number, 4)).Value = intDBID
                            End With
                            .ExecuteNonQuery()
                        Catch ex As OracleException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        ' GetZServerList method
        ' Purpose: Get Z3950Server List
        ' Output: Datatable result
        ' Add by :lent
        Public Function GetZServerList() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_GET_LIST_ZSERVER"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        End With
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblZServer")
                            GetZServerList = dsData.Tables("tblZServer")
                            dsData.Tables.Remove("tblZServer")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spZ3950Server_SelOrderByName"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblZServer")
                            GetZServerList = dsData.Tables("tblZServer")
                            dsData.Tables.Remove("tblZServer")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' GetZServerDB method
        ' Purpose: Get Z3950ServerDB List
        ' Output: Datatable result
        ' Add by :lent
        Public Function GetZServerDB(ByVal intShowAll As Byte) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_GET_ZSERVER_DBS"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            .Add(New OracleParameter("intServerID", OracleType.Number, 4)).Value = intServerID
                            .Add(New OracleParameter("intShowAll", OracleType.Number, 1)).Value = intShowAll
                        End With
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblZServer")
                            GetZServerDB = dsData.Tables("tblZServer")
                            dsData.Tables.Remove("tblZServer")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spZ3950DB_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intServerID", SqlDbType.Int, 4)).Value = intServerID
                                .Add(New SqlParameter("@intShowAll", SqlDbType.Bit, 4)).Value = intShowAll
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblZServer")
                            GetZServerDB = dsData.Tables("tblZServer")
                            dsData.Tables.Remove("tblZServer")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
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
                Dispose()
            End Try
        End Sub
    End Class
End Namespace