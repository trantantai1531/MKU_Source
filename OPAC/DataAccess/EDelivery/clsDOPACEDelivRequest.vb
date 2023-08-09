
Imports System.Data
Imports System.Data.sqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibOPAC.DataAccess.OPAC
    Public Class clsDOPACEDelivRequest
        Inherits clsDBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private lngItemID As Long
        Private strItemIDs As String
        Private intModeID As Integer
        Private strExpireDate As String
        Private lngEDelivUserID As Long
        Private lngFileID As Long
        Private strCurrency As String
        Private dblAmount As Double
        Private dblDebt As Double
        Private strNote As String
        Private dblRate As Double
        Private lngRequestGroupID As Long

        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************

        ' ItemID property
        Public Property ItemID() As Long
            Get
                Return lngItemID
            End Get
            Set(ByVal Value As Long)
                lngItemID = Value
            End Set
        End Property

        ' ItemIDs property 
        Public Property ItemIDs() As String
            Get
                Return strItemIDs
            End Get
            Set(ByVal Value As String)
                strItemIDs = Value
            End Set
        End Property

        ' ModeID property
        ' Mode receive E-Delivery
        Public Property ModeID() As Integer
            Get
                Return intModeID
            End Get
            Set(ByVal Value As Integer)
                intModeID = Value
            End Set
        End Property

        ' EDelivUserID property
        Public Property EDelivUserID() As Long
            Get
                Return lngEDelivUserID
            End Get
            Set(ByVal Value As Long)
                lngEDelivUserID = Value
            End Set
        End Property

        ' FileID property
        Public Property FileID() As Long
            Get
                Return lngFileID
            End Get
            Set(ByVal Value As Long)
                lngFileID = Value
            End Set
        End Property

        ' Currency property
        Public Property Currency() As String
            Get
                Return strCurrency
            End Get
            Set(ByVal Value As String)
                strCurrency = Value
            End Set
        End Property

        ' Amount property
        Public Property Amount() As Double
            Get
                Return dblAmount
            End Get
            Set(ByVal Value As Double)
                dblAmount = Value
            End Set
        End Property

        ' Debt property
        Public Property Debt() As Double
            Get
                Return dblDebt
            End Get
            Set(ByVal Value As Double)
                dblDebt = Value
            End Set
        End Property

        ' Note property
        Public Property Note() As String
            Get
                Return strNote
            End Get
            Set(ByVal Value As String)
                strNote = Value
            End Set
        End Property

        ' Rate property
        Public Property Rate() As Double
            Get
                Return dblRate
            End Get
            Set(ByVal Value As Double)
                dblRate = Value
            End Set
        End Property

        ' RequestGroupID property
        Public Property RequestGroupID() As Long
            Get
                Return lngRequestGroupID
            End Get
            Set(ByVal Value As Long)
                lngRequestGroupID = Value
            End Set
        End Property

        ' ExpireDate property 
        Public Property ExpireDate() As String
            Get
                Return strExpireDate
            End Get
            Set(ByVal Value As String)
                strExpireDate = Value
            End Set
        End Property

        ' purpose : Create one E-Delivery Request
        ' Created by: dgsoft
        Public Sub CreateRequest()
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spEdlRequest_Create"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strExpireDate", SqlDbType.VarChar, 20)).Value = strExpireDate
                                .Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = lngEDelivUserID
                                .Add(New SqlParameter("@intFileID", SqlDbType.Int)).Value = lngFileID
                                .Add(New SqlParameter("@intDevModeID", SqlDbType.Int)).Value = intModeID
                                .Add(New SqlParameter("@strCurrency", SqlDbType.VarChar, 10)).Value = strCurrency
                                .Add(New SqlParameter("@mnyAmount", SqlDbType.Money)).Value = dblAmount
                                .Add(New SqlParameter("@strNote", SqlDbType.NVarChar, 1000)).Value = strNote
                                .Add(New SqlParameter("@fltRate", SqlDbType.Float)).Value = dblRate
                                .Add(New SqlParameter("@intRequestGroupID", SqlDbType.Int)).Value = lngRequestGroupID
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
                        .CommandText = "OPAC.Opac_spEdlRequest_Create"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strExpireDate", OracleType.VarChar, 20)).Value = strExpireDate
                                .Add(New OracleParameter("intUserID", OracleType.Number)).Value = lngEDelivUserID
                                .Add(New OracleParameter("intFileID", OracleType.Number)).Value = lngFileID
                                .Add(New OracleParameter("intDevModeID", OracleType.Number)).Value = intModeID
                                .Add(New OracleParameter("strCurrency", OracleType.VarChar, 10)).Value = strCurrency
                                .Add(New OracleParameter("mnyAmount", OracleType.Float)).Value = dblAmount
                                .Add(New OracleParameter("strNote", OracleType.VarChar, 100)).Value = strNote
                                .Add(New OracleParameter("fltRate", OracleType.Float)).Value = dblRate
                                .Add(New OracleParameter("intRequestGroupID", OracleType.Number)).Value = lngRequestGroupID
                            End With
                            .ExecuteNonQuery()
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Sub

        ' purpose : Update EDELIV_DEBT of an e-delevery user
        Public Sub UpdateUserDebt()
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spEdlDebt_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = lngEDelivUserID
                                .Add(New SqlParameter("@mnyAddDebt", SqlDbType.Money)).Value = dblDebt
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
                        .CommandText = "OPAC.Opac_spEdlDebt_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intUserID", OracleType.Number)).Value = lngEDelivUserID
                                .Add(New OracleParameter("mnyAddDebt", OracleType.Float)).Value = dblDebt
                            End With
                            .ExecuteNonQuery()
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Sub

        ' GetEDelivInfor function
        ' purpose: Get the e delevery item infor that user selected
        Public Function GetEDelivInfor() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spEdl_GetInfo"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strFileIDs", SqlDbType.VarChar, 500)).Value = strItemIDs
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblEdelivInfor")
                            GetEDelivInfor = dsData.Tables("tblEdelivInfor")
                            dsData.Tables.Remove("tblEdelivInfor")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.Opac_spEdl_GetInfo"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strFileIDs", OracleType.VarChar, 500)).Value = strItemIDs
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            OraDataAdapter.SelectCommand = OraCommand
                            OraDataAdapter.Fill(dsData, "tblEdelivInfor")
                            GetEDelivInfor = dsData.Tables("tblEdelivInfor")
                            dsData.Tables.Remove("tblEdelivInfor")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        ' GetNewRequestgroupID function
        Public Function GetNewRequestgroupID() As Long
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spRequest_GetNewGroupID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intNewRequestGroupID", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            GetNewRequestgroupID = .Parameters("@intNewRequestGroupID").Value
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.SP_OPAC_GET_NEW_REQ_GROUP_ID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intNewRequestGroupID", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            GetNewRequestgroupID = .Parameters("intNewRequestGroupID").Value
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        ' GetEDelivInforByRequest function
        ' purpose: Get the e delevery item infor by the user request
        Public Function GetEDelivInforByRequest(ByRef dblTotal As Double) As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spEdl_GetInfoByGroup"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intRequestGroupID", SqlDbType.Int)).Value = lngRequestGroupID
                            .Add(New SqlParameter("@mnyTotal", SqlDbType.Money)).Direction = ParameterDirection.Output
                        End With
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblEdelivInforByReq")
                            GetEDelivInforByRequest = dsData.Tables("tblEdelivInforByReq")
                            dblTotal = .Parameters("@mnyTotal").Value
                            dsData.Tables.Remove("tblEdelivInforByReq")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.Opac_spEdl_GetInfoByGroup"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("intRequestGroupID", OracleType.Number)).Value = lngRequestGroupID
                            .Add(New OracleParameter("mnyTotal", OracleType.Float)).Direction = ParameterDirection.Output
                            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        End With
                        Try
                            OraDataAdapter.SelectCommand = OraCommand
                            OraDataAdapter.Fill(dsData, "tblEdelivInforByReq")
                            GetEDelivInforByRequest = dsData.Tables("tblEdelivInforByReq")
                            dblTotal = .Parameters("mnyTotal").Value
                            dsData.Tables.Remove("tblEdelivInforByReq")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        ' GetRequestGroup fucntion
        ' Purpose: Get the distinct request group
        Public Function GetRequestGroup(ByVal strRequestGroupID As String, ByVal strCreatedDate As String) As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spRequest_GetGroup"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@strRequestGroupID", SqlDbType.NVarChar, 100)).Value = strRequestGroupID
                            .Add(New SqlParameter("@strCreatedDate", SqlDbType.NVarChar, 100)).Value = strCreatedDate
                            .Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = lngEDelivUserID
                        End With
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblRequestGroup")
                            GetRequestGroup = dsData.Tables("tblRequestGroup")
                            dsData.Tables.Remove("tblRequestGroup")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.Opac_spRequest_GetGroup"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strRequestGroupID", OracleType.VarChar, 100)).Value = strRequestGroupID
                                .Add(New OracleParameter("strCreatedDate", OracleType.VarChar, 100)).Value = strCreatedDate
                                .Add(New OracleParameter("intUserID", OracleType.Number)).Value = lngEDelivUserID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            OraDataAdapter.SelectCommand = OraCommand
                            OraDataAdapter.Fill(dsData, "tblRequestGroup")
                            GetRequestGroup = dsData.Tables("tblRequestGroup")
                            dsData.Tables.Remove("tblRequestGroup")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        ' GetRequestGroupCount function
        ' Purpose: Get the number of distinct request groups of an user
        Public Function GetRequestGroupCount() As Integer
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spRequest_GetNumGroup"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = lngEDelivUserID
                                .Add(New SqlParameter("@intNumOfReq", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            GetRequestGroupCount = .Parameters("@intNumOfReq").Value
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.Opac_spRequest_GetNumGroup"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intUserID", OracleType.Number)).Value = lngEDelivUserID
                                .Add(New OracleParameter("intNumOfReq", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            GetRequestGroupCount = .Parameters("intNumOfReq").Value
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        ' CheckEdelivUser method
        ' Purpose: Check the username and password of edeliv user
        Public Function CheckEdelivUser(ByVal strUserName As String, ByVal strPassword As String) As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spEdlUser_Check"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strUserName", SqlDbType.VarChar, 100)).Value = strUserName
                                .Add(New SqlParameter("@strPassword", SqlDbType.VarChar, 100)).Value = strPassword
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblUser")
                            CheckEdelivUser = dsData.Tables("tblUser")
                            dsData.Tables.Remove("tblUser")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.Opac_spEdlUser_Check"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strUserName", OracleType.VarChar, 100)).Value = strUserName
                                .Add(New OracleParameter("strPassword", OracleType.VarChar, 100)).Value = strPassword
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblUser")
                            CheckEdelivUser = dsData.Tables("tblUser")
                            dsData.Tables.Remove("tblUser")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        ' CheckEdelivUserDownload method
        ' Purpose: Check the e-delivery user download right
        Public Function CheckEdelivUserDownload(ByVal intUserID As Integer, ByVal intFileID As Integer) As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spEdlUser_CheckDownload"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                                .Add(New SqlParameter("@intFileID", SqlDbType.Int)).Value = intFileID
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblUser")
                            CheckEdelivUserDownload = dsData.Tables("tblUser")
                            dsData.Tables.Remove("tblUser")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.Opac_spEdlUser_CheckDownload"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUserID
                                .Add(New OracleParameter("intFileID", OracleType.Number)).Value = intFileID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblUser")
                            CheckEdelivUserDownload = dsData.Tables("tblUser")
                            dsData.Tables.Remove("tblUser")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        ' CancelPendingERequest method
        ' Purpose: Change the status of request to Cancel pending
        Public Sub CancelPendingERequest(ByVal lngRequestID As Long)
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spPendingRequest_Cancel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@lngRequestID", SqlDbType.Int)).Value = lngRequestID
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
                        .CommandText = "OPAC.Opac_spPendingRequest_Cancel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("lngRequestID", OracleType.Number)).Value = lngRequestID
                            End With
                            .ExecuteNonQuery()
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

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