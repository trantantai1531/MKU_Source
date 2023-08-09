Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Circulation
    Public Class clsDAccountTransaction
        Inherits clsDBase

        ' *****************************************************************************************************
        ' Declare member variables
        ' *****************************************************************************************************

        Private strPatronCode As String = ""
        Private intFineID As Integer
        Private dblAmount As Double = 0
        Private strReason As String = 0
        Private strCreatedDate As String = ""
        Private strCurrency As String = ""
        Private strCreator As String = ""
        Private intMonth As Int16 = 0
        Private intYear As Integer = 0
        Private intType As Int16 = 0
        Private dblSeetled As Double = 0
        Private dblUnSeetled As Double = 0
        Private dblRemain As Double = 0
        Private intOutPut As Int16
        Private dblRate As Double = 0
        Private intLibID As Integer = 0

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' FineID property
        Public Property FineID() As Integer
            Get
                Return intFineID
            End Get
            Set(ByVal Value As Integer)
                intFineID = Value
            End Set
        End Property

        ' PatronCode property
        Public Property PatronCode() As String
            Get
                Return strPatronCode
            End Get
            Set(ByVal Value As String)
                strPatronCode = Value
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

        ' Reason property
        Public Property Reason() As String
            Get
                Return strReason
            End Get
            Set(ByVal Value As String)
                strReason = Value
            End Set
        End Property

        ' CreatedDate property
        Public Property CreatedDate() As String
            Get
                Return strCreatedDate
            End Get
            Set(ByVal Value As String)
                strCreatedDate = Value
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

        ' Creator property
        Public Property Creator() As String
            Get
                Return strCreator
            End Get
            Set(ByVal Value As String)
                strCreator = Value
            End Set
        End Property

        ' Month property
        Public Property Month() As Int16
            Get
                Return intMonth
            End Get
            Set(ByVal Value As Int16)
                intMonth = Value
            End Set
        End Property

        ' Year property 
        Public Property Year() As Integer
            Get
                Return intYear
            End Get
            Set(ByVal Value As Integer)
                intYear = Value
            End Set
        End Property

        ' Type property 
        Public Property Type() As Int16
            Get
                Return intType
            End Get
            Set(ByVal Value As Int16)
                intType = Value
            End Set
        End Property

        ' Settled property
        Public Property Settled() As Double
            Get
                Return dblSeetled
            End Get
            Set(ByVal Value As Double)
                dblSeetled = Value
            End Set
        End Property

        ' UnSettled property
        Public Property UnSettled() As Double
            Get
                Return dblUnSeetled
            End Get
            Set(ByVal Value As Double)
                dblUnSeetled = Value
            End Set
        End Property

        ' Remain property
        Public Property Remain() As Double
            Get
                Return dblRemain
            End Get
            Set(ByVal Value As Double)
                dblRemain = Value
            End Set
        End Property

        ' OutPut property
        Public Property OutPut() As Int16
            Get
                Return intOutPut
            End Get
            Set(ByVal Value As Int16)
                intOutPut = Value
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
        ' LibID property
        Public Property LibID() As Integer
            Get
                Return intLibID
            End Get
            Set(ByVal Value As Integer)
                intLibID = Value
            End Set
        End Property
        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' GetAccountInfor method
        ' Purpose: get all SettedFees, Unsettled Fees and Summaries
        ' Input:
        ' Output: datatable result
        Public Function GetAccountInfor() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_CIR_FINE_SEL"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("strPatronCode", OracleType.VarChar, 30)).Value = strPatronCode
                        .Parameters.Add(New OracleParameter("intMonth", OracleType.Number)).Value = intMonth
                        .Parameters.Add(New OracleParameter("intYear", OracleType.Number)).Value = intYear
                        .Parameters.Add(New OracleParameter("intType", OracleType.Number)).Value = intType
                        .Parameters.Add(New OracleParameter("mnySettled", OracleType.Float)).Direction = ParameterDirection.Output
                        .Parameters.Add(New OracleParameter("mnyUnSettled", OracleType.Float)).Direction = ParameterDirection.Output
                        .Parameters.Add(New OracleParameter("mnyRemain", OracleType.Float)).Direction = ParameterDirection.Output
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblSettedFees")
                            GetAccountInfor = dsData.Tables("tblSettedFees")
                            dblSeetled = .Parameters("mnySettled").Value
                            dblUnSeetled = .Parameters("mnyUnSettled").Value
                            dblRemain = .Parameters("mnyRemain").Value
                            dsData.Tables.Remove("tblSettedFees")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spFine_Sel"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 30)).Value = strPatronCode
                        .Parameters.Add(New SqlParameter("@intMonth", SqlDbType.Int)).Value = intMonth
                        .Parameters.Add(New SqlParameter("@intYear", SqlDbType.Int)).Value = intYear
                        .Parameters.Add(New SqlParameter("@intType", SqlDbType.Int)).Value = intType
                        .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                        .Parameters.Add(New SqlParameter("@mnySettled", SqlDbType.Money)).Direction = ParameterDirection.Output
                        .Parameters.Add(New SqlParameter("@mnyUnSettled", SqlDbType.Money)).Direction = ParameterDirection.Output
                        .Parameters.Add(New SqlParameter("@mnyRemain", SqlDbType.Money)).Direction = ParameterDirection.Output
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblSettedFees")
                            dblSeetled = .Parameters("@mnySettled").Value
                            dblUnSeetled = .Parameters("@mnyUnSettled").Value
                            dblRemain = .Parameters("@mnyRemain").Value
                            GetAccountInfor = dsData.Tables("tblSettedFees")
                            dsData.Tables.Remove("tblSettedFees")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' CreateNewFine method
        ' Purpose: Add new fine (settled or unsettled)
        ' Input: some main information of Fine
        Public Sub CreateNewFine(ByVal intCheckPatronDept As Integer)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spFine_Ins"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intType", SqlDbType.Int)).Value = intType
                            .Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 30)).Value = strPatronCode
                            .Add(New SqlParameter("@mnyAmount", SqlDbType.Money)).Value = dblAmount
                            .Add(New SqlParameter("@strCurrency", SqlDbType.VarChar, 10)).Value = strCurrency
                            .Add(New SqlParameter("@fltRate", SqlDbType.Float)).Value = dblRate
                            .Add(New SqlParameter("@strCreatedDate", SqlDbType.VarChar, 30)).Value = strCreatedDate
                            .Add(New SqlParameter("@strReason", SqlDbType.NVarChar, 2000)).Value = strReason
                            .Add(New SqlParameter("@intCheckPatronDept", SqlDbType.Int)).Value = intCheckPatronDept
                            .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            .Add(New SqlParameter("@intOutPut", SqlDbType.Int)).Direction = ParameterDirection.Output
                        End With
                        Try
                            .ExecuteNonQuery()
                            intOutPut = .Parameters("@intOutPut").Value
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_CIR_FINE_INS"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("intType", OracleType.Number)).Value = intType
                            .Add(New OracleParameter("strPatronCode", OracleType.VarChar, 30)).Value = strPatronCode
                            .Add(New OracleParameter("mnyAmount", OracleType.Double)).Value = dblAmount
                            .Add(New OracleParameter("strCurrency", OracleType.VarChar, 10)).Value = strCurrency
                            .Add(New OracleParameter("fltRate", OracleType.Float)).Value = dblRate
                            .Add(New OracleParameter("strCreatedDate", OracleType.VarChar, 30)).Value = strCreatedDate
                            .Add(New OracleParameter("strReason", OracleType.VarChar, 2000)).Value = strReason
                            .Add(New OracleParameter("intCheckPatronDept", OracleType.Number)).Value = intCheckPatronDept
                            .Add(New OracleParameter("intOutPut", OracleType.Number)).Direction = ParameterDirection.Output
                        End With
                        Try
                            .ExecuteNonQuery()
                            intOutPut = .Parameters("intOutPut").Value
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

        ' UpdateFine method
        ' Purpose: Update fine (settled or unsettled)
        ' Input: some main information of Fine
        Public Sub UpdateFine()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "SP_CIR_FINE_UPD"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intType", SqlDbType.Int)).Value = intType
                            .Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intFineID
                            .Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 30)).Value = strPatronCode
                            .Add(New SqlParameter("@mnyAmount", SqlDbType.Money)).Value = dblAmount
                            .Add(New SqlParameter("@strCurrency", SqlDbType.VarChar, 10)).Value = strCurrency
                            .Add(New SqlParameter("@fltRate", SqlDbType.Float)).Value = dblRate
                            .Add(New SqlParameter("@strCreatedDate", SqlDbType.VarChar, 30)).Value = strCreatedDate
                            .Add(New SqlParameter("@strReason", SqlDbType.NVarChar, 2000)).Value = strReason
                            .Add(New SqlParameter("@intOutPut", SqlDbType.Int)).Direction = ParameterDirection.Output
                        End With
                        Try
                            .ExecuteNonQuery()
                            intOutPut = .Parameters("@intOutPut").Value
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_CIR_FINE_UPD"
                        .CommandType = CommandType.StoredProcedure

                        With .Parameters
                            .Add(New OracleParameter("intType", OracleType.Number)).Value = intType
                            .Add(New OracleParameter("intID", OracleType.Number)).Value = intFineID
                            .Add(New OracleParameter("strPatronCode", OracleType.VarChar, 30)).Value = strPatronCode
                            .Add(New OracleParameter("mnyAmount", OracleType.Double)).Value = dblAmount
                            .Add(New OracleParameter("strCurrency", OracleType.VarChar, 10)).Value = strCurrency
                            .Add(New OracleParameter("fltRate", OracleType.Double)).Value = dblRate
                            .Add(New OracleParameter("strCreatedDate", OracleType.VarChar, 30)).Value = strCreatedDate
                            .Add(New OracleParameter("strReason", OracleType.NVarChar, 2000)).Value = strReason
                            .Add(New OracleParameter("intOutPut", OracleType.Number)).Direction = ParameterDirection.Output
                        End With
                        Try
                            .ExecuteNonQuery()
                            intOutPut = .Parameters("intOutPut").Value
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

        ' DeleteFine method
        ' Purpose: Delete fine (settled or unsettled)
        ' Input: ID
        Public Sub DeleteFine()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spFine_DelById"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intFineID
                        End With
                        Try
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
                        .CommandText = "CIRCULATION.SP_CIR_FINE_DEL"
                        .CommandType = CommandType.StoredProcedure

                        With .Parameters
                            .Add(New OracleParameter("intID", OracleType.Number)).Value = intFineID
                        End With
                        Try
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
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
