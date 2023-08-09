Imports System.Data
Imports System.Data.sqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Patron
    Public Class clsDOtherAddress
        Inherits clsDBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************

        Private strPatronIDs As String
        Private intPatronID As Integer
        Private strAddress As String
        Private strProvince As String
        Private strCity As String
        Private strCountry As String
        Private strZip As String
        Private strActive As String

        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************
        ' PatronIDs property
        Public Property PatronIDs() As String
            Get
                Return strPatronIDs
            End Get
            Set(ByVal Value As String)
                strPatronIDs = Value
            End Set
        End Property

        ' PatronID property
        Public Property PatronID() As Integer
            Get
                Return intPatronID
            End Get
            Set(ByVal Value As Integer)
                intPatronID = Value
            End Set
        End Property

        ' Address property
        Public Property Address() As String
            Get
                Return strAddress
            End Get
            Set(ByVal Value As String)
                strAddress = Value
            End Set
        End Property

        ' Province Property
        Public Property Province() As String
            Get
                Return strProvince
            End Get
            Set(ByVal Value As String)
                strProvince = Value
            End Set
        End Property

        ' City property
        Public Property City() As String
            Get
                Return strCity
            End Get
            Set(ByVal Value As String)
                strCity = Value
            End Set
        End Property

        ' Country property
        Public Property Country() As String
            Get
                Return strCountry
            End Get
            Set(ByVal Value As String)
                strCountry = Value
            End Set
        End Property

        ' Zip property
        Public Property Zip() As String
            Get
                Return strZip
            End Get
            Set(ByVal Value As String)
                strZip = Value
            End Set
        End Property

        ' Active property
        Public Property Active() As String
            Get
                Return strActive
            End Get
            Set(ByVal Value As String)
                strActive = Value
            End Set
        End Property

        ' *************************************************************************************************
        ' End declare properties
        ' Declare public method
        ' *************************************************************************************************
        Public Function GetOtherAddress() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatGetOtherAdd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intPatronID", SqlDbType.Int)).Value = intPatronID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetOtherAddress = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        ' Change SP
                        ' .CommandText = "PATRON.SP_CIR_PATRON_OA_SELECT"
                        .CommandText = "PATRON.SP_PAT_GET_OTHERADDRESS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("intPatronID", OracleType.Number)).Value = intPatronID
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetOtherAddress = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Method: Create
        ' Purpose: Create patron's address informations
        ' Input: All parameters
        ' Creator: Sondp
        Public Sub Create(ByVal strAddress As String, ByVal intProvinceID As Integer, ByVal strCity As String, ByVal intCountryID As Integer, ByVal strZip As String, ByVal intisActive As Integer)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatCreateOtherAdd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intPatronID", SqlDbType.Int)).Value = intPatronID
                                .Add(New SqlParameter("@strAddress", SqlDbType.NVarChar, 250)).Value = strAddress
                                .Add(New SqlParameter("@intProvinceID", SqlDbType.Int)).Value = intProvinceID
                                .Add(New SqlParameter("@strCity", SqlDbType.NVarChar, 250)).Value = strCity
                                .Add(New SqlParameter("@intCountryID", SqlDbType.Int)).Value = intCountryID
                                .Add(New SqlParameter("@strZip", SqlDbType.VarChar, 5)).Value = strZip
                                .Add(New SqlParameter("@intisActive", SqlDbType.Int)).Value = intisActive
                            End With
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "PATRON.SP_PAT_CREATE_OTHERADDRESS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intPatronID", OracleType.Number)).Value = intPatronID
                                .Add(New OracleParameter("strAddress", OracleType.VarChar, 250)).Value = strAddress
                                .Add(New OracleParameter("intProvinceID", OracleType.Number)).Value = intProvinceID
                                .Add(New OracleParameter("strCity", OracleType.VarChar, 250)).Value = strCity
                                .Add(New OracleParameter("intCountryID", OracleType.Number)).Value = intCountryID
                                .Add(New OracleParameter("strZip", OracleType.VarChar, 10)).Value = strZip
                                .Add(New OracleParameter("intisActive", OracleType.Number)).Value = intisActive
                            End With
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

        ' Method: Create
        ' Purpose: Create patron's address informations
        ' Input: All parameters
        ' Creator: Sondp
        Public Sub Update(ByVal intID As Integer, ByVal strAddress As String, ByVal intProvinceID As Integer, ByVal strCity As String, ByVal intCountryID As Integer, ByVal strZip As String, ByVal intisActive As Integer)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatUpdateOtherAdd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intPatronID
                                .Add(New SqlParameter("@intPatronID", SqlDbType.Int)).Value = intPatronID
                                .Add(New SqlParameter("@strAddress", SqlDbType.NVarChar, 250)).Value = strAddress
                                .Add(New SqlParameter("@intProvinceID", SqlDbType.Int)).Value = intProvinceID
                                .Add(New SqlParameter("@strCity", SqlDbType.NVarChar, 250)).Value = strCity
                                .Add(New SqlParameter("@intCountryID", SqlDbType.Int)).Value = intCountryID
                                .Add(New SqlParameter("@strZip", SqlDbType.VarChar, 5)).Value = strZip
                                .Add(New SqlParameter("@intisActive", SqlDbType.Int)).Value = intisActive
                            End With
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "PATRON.SP_PAT_UPDATE_OTHERADDRESS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intID", OracleType.Number)).Value = intID
                                .Add(New OracleParameter("intPatronID", OracleType.Number)).Value = intPatronID
                                .Add(New OracleParameter("strAddress", OracleType.VarChar, 250)).Value = strAddress
                                .Add(New OracleParameter("intProvinceID", OracleType.Number)).Value = intProvinceID
                                .Add(New OracleParameter("strCity", OracleType.VarChar, 250)).Value = strCity
                                .Add(New OracleParameter("intCountryID", OracleType.Number)).Value = intCountryID
                                .Add(New OracleParameter("strZip", OracleType.VarChar, 10)).Value = strZip
                                .Add(New OracleParameter("intisActive", OracleType.Number)).Value = intisActive
                            End With
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

        Public Sub Delete()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatronOtherAddr_DelById"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intPatronID", SqlDbType.Int)).Value = intPatronID
                            End With
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "PATRON.SP_CIR_PATRON_OA_DELETE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intPatronID", OracleType.Number)).Value = intPatronID
                            End With
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