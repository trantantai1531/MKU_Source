' Name: clsDILLLibrary
' Purpose: 
' Creator: Sondp
' Created Date: 25/11/2004
' Modification History:

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.ILL
    Public Class clsDILLLibrary
        Inherits clsDBase
        ' ***********************************************************************************************
        ' Declare Private variables
        ' ***********************************************************************************************

        Private lngLibID As Long
        Private strLibrarySymbol As String
        Private strPostDelivName As String
        Private strLibraryName As String
        Private strLibraryCode As String
        Private strPostDelivXAddr As String
        Private strPostDelivStreet As String
        Private strPostDelivBox As String
        Private strPostDelivCode As String
        Private strPostDelivCity As String
        Private strPostDelivRegion As String
        Private intPostDelivCountry As Integer
        Private strPostDelivMode As String
        Private strEDelivMode As String
        Private strEDelivTSAddr As String
        Private strTelephone As String
        Private strEmailReplyAddress As String
        Private strBillDelivName As String
        Private strBillDelivXAddr As String
        Private strBillDelivStreet As String
        Private strBillDelivBox As String
        Private strBillDelivCode As String
        Private strBillDelivCity As String
        Private strBillDelivRegion As String
        Private intBillDelivCountry As Integer
        Private strAccountNumber As String
        Private intEncodingScheme As Int16

        Private strNote As String
        Private strName7 As String

        ' ***********************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' ***********************************************************************************************

        ' LibID property
        Public Property IllLibID() As Long
            Get
                Return lngLibID
            End Get
            Set(ByVal Value As Long)
                lngLibID = Value
            End Set
        End Property

        ' Library Symbol property
        Public Property LibrarySymbol() As String
            Get
                Return strLibrarySymbol
            End Get
            Set(ByVal Value As String)
                strLibrarySymbol = Value
            End Set
        End Property

        ' PostDelivName property
        Public Property PostDelivName() As String
            Get
                Return strPostDelivName
            End Get
            Set(ByVal Value As String)
                strPostDelivName = Value
            End Set
        End Property

        ' Library Name property
        Public Property LibraryName() As String
            Get
                Return strLibraryName
            End Get
            Set(ByVal Value As String)
                strLibraryName = Value
            End Set
        End Property

        ' Library Code property
        Public Property LibraryCode() As String
            Get
                Return strLibraryCode
            End Get
            Set(ByVal Value As String)
                strLibraryCode = Value
            End Set
        End Property

        ' PostDelivXAddr property
        Public Property PostDelivXAddr() As String
            Get
                Return strPostDelivXAddr
            End Get
            Set(ByVal Value As String)
                strPostDelivXAddr = Value
            End Set
        End Property

        ' PostDelivStreet property
        Public Property PostDelivStreet() As String
            Get
                Return strPostDelivStreet
            End Get
            Set(ByVal Value As String)
                strPostDelivStreet = Value
            End Set
        End Property

        ' PostDelivBox property
        Public Property PostDelivBox() As String
            Get
                Return strPostDelivBox
            End Get
            Set(ByVal Value As String)
                strPostDelivBox = Value
            End Set
        End Property

        ' PostDelivCode property
        Public Property PostDelivCode() As String
            Get
                Return strPostDelivCode
            End Get
            Set(ByVal Value As String)
                strPostDelivCode = Value
            End Set
        End Property

        ' BillDelivCode property
        Public Property BillDelivCode() As String
            Get
                Return strBillDelivCode
            End Get
            Set(ByVal Value As String)
                strBillDelivCode = Value
            End Set
        End Property

        ' PostDelivCity property
        Public Property PostDelivCity() As String
            Get
                Return strPostDelivCity
            End Get
            Set(ByVal Value As String)
                strPostDelivCity = Value
            End Set
        End Property

        ' PostDelivRegion property
        Public Property PostDelivRegion() As String
            Get
                Return strPostDelivRegion
            End Get
            Set(ByVal Value As String)
                strPostDelivRegion = Value
            End Set
        End Property

        ' PostDelivCountry property
        Public Property PostDelivCountry() As Integer
            Get
                Return intPostDelivCountry
            End Get
            Set(ByVal Value As Integer)
                intPostDelivCountry = Value
            End Set
        End Property

        ' PostDelivMode property
        Public Property PostDelivMode() As String
            Get
                Return strPostDelivMode
            End Get
            Set(ByVal Value As String)
                strPostDelivMode = Value
            End Set
        End Property

        ' EDelivMode property
        Public Property EDelivMode() As String
            Get
                Return strEDelivMode
            End Get
            Set(ByVal Value As String)
                strEDelivMode = Value
            End Set
        End Property

        ' EDelivTSAddr property
        Public Property EDelivTSAddr() As String
            Get
                Return strEDelivTSAddr
            End Get
            Set(ByVal Value As String)
                strEDelivTSAddr = Value
            End Set
        End Property

        ' Telephone property
        Public Property Telephone() As String
            Get
                Return strTelephone
            End Get
            Set(ByVal Value As String)
                strTelephone = Value
            End Set
        End Property

        ' EmailReplyAddress property
        Public Property EmailReplyAddress() As String
            Get
                Return strEmailReplyAddress
            End Get
            Set(ByVal Value As String)
                strEmailReplyAddress = Value
            End Set
        End Property

        ' BillDelivName property
        Public Property BillDelivName() As String
            Get
                Return strBillDelivName
            End Get
            Set(ByVal Value As String)
                strBillDelivName = Value
            End Set
        End Property

        ' BillDelivXAddr property
        Public Property BillDelivXAddr() As String
            Get
                Return strBillDelivXAddr
            End Get
            Set(ByVal Value As String)
                strBillDelivXAddr = Value
            End Set
        End Property

        ' BillDelivStreet property
        Public Property BillDelivStreet() As String
            Get
                Return strBillDelivStreet
            End Get
            Set(ByVal Value As String)
                strBillDelivStreet = Value
            End Set
        End Property

        ' BillDelivBox property
        Public Property BillDelivBox() As String
            Get
                Return strBillDelivBox
            End Get
            Set(ByVal Value As String)
                strBillDelivBox = Value
            End Set
        End Property

        ' BillDelivCity property
        Public Property BillDelivCity() As String
            Get
                Return strBillDelivCity
            End Get
            Set(ByVal Value As String)
                strBillDelivCity = Value
            End Set
        End Property

        ' BillDelivCountry property
        Public Property BillDelivCountry() As Integer
            Get
                Return intBillDelivCountry
            End Get
            Set(ByVal Value As Integer)
                intBillDelivCountry = Value
            End Set
        End Property

        ' BillDelivRegion property
        Public Property BillDelivRegion() As String
            Get
                Return strBillDelivRegion
            End Get
            Set(ByVal Value As String)
                strBillDelivRegion = Value
            End Set
        End Property

        ' Name7 property
        Public Property Name7() As String
            Get
                Return strName7
            End Get
            Set(ByVal Value As String)
                strName7 = Value
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

        ' AccountNumber property
        Public Property AccountNumber() As String
            Get
                Return strAccountNumber
            End Get
            Set(ByVal Value As String)
                strAccountNumber = Value
            End Set
        End Property

        ' EncodingScheme property
        Public Property EncodingScheme() As Int16
            Get
                Return intEncodingScheme
            End Get
            Set(ByVal Value As Int16)
                intEncodingScheme = Value
            End Set
        End Property

        ' ***********************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' ***********************************************************************************************
        Public Function GetLib(ByVal intType As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_GET_LIB_INFOR"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intLibID", OracleType.Number)).Value = lngLibID
                                .Add(New OracleParameter("intType", OracleType.Number)).Value = intType
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetLib = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spLibrary_SelAllOrById"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                                .Add(New SqlParameter("@intIllLibID", SqlDbType.Int)).Value = lngLibID
                                .Add(New SqlParameter("@intType", SqlDbType.Int)).Value = intType
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetLib = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
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

        Public Function Create() As Integer
            Dim intOut As Integer = 0

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spLibrary_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strSymbol", SqlDbType.NVarChar)).Value = strLibrarySymbol
                                .Add(New SqlParameter("@strName", SqlDbType.NVarChar)).Value = strLibraryName
                                .Add(New SqlParameter("@strEmailAddress", SqlDbType.VarChar)).Value = strEmailReplyAddress
                                .Add(New SqlParameter("@strTelephone", SqlDbType.VarChar)).Value = strTelephone
                                .Add(New SqlParameter("@strCode", SqlDbType.Char)).Value = strLibraryCode
                                .Add(New SqlParameter("@strNote", SqlDbType.NVarChar)).Value = strNote
                                .Add(New SqlParameter("@strEDelivMode", SqlDbType.NVarChar)).Value = strEDelivMode
                                .Add(New SqlParameter("@strEDelivTSAddr", SqlDbType.NVarChar)).Value = strEDelivTSAddr
                                .Add(New SqlParameter("@strBillDelivName", SqlDbType.NVarChar)).Value = strBillDelivName
                                .Add(New SqlParameter("@strBillDelivXAddr", SqlDbType.VarChar)).Value = strBillDelivXAddr
                                .Add(New SqlParameter("@strBillDelivStreet", SqlDbType.NVarChar)).Value = strBillDelivStreet
                                .Add(New SqlParameter("@strBillDelivBox", SqlDbType.NVarChar)).Value = strBillDelivBox
                                .Add(New SqlParameter("@strBillDelivCity", SqlDbType.NVarChar)).Value = strBillDelivCity
                                .Add(New SqlParameter("@strBillDelivRegion", SqlDbType.NVarChar)).Value = strBillDelivRegion
                                .Add(New SqlParameter("@intBillDelivCountry", SqlDbType.TinyInt)).Value = intBillDelivCountry
                                .Add(New SqlParameter("@strBillDelivCode", SqlDbType.VarChar)).Value = strBillDelivCode
                                .Add(New SqlParameter("@strPostDelivName", SqlDbType.NVarChar)).Value = strPostDelivName
                                .Add(New SqlParameter("@strPostDelivXAddr", SqlDbType.NVarChar)).Value = strPostDelivXAddr
                                .Add(New SqlParameter("@strPostDelivStreet", SqlDbType.NVarChar)).Value = strPostDelivStreet
                                .Add(New SqlParameter("@strPostDelivBox", SqlDbType.NVarChar)).Value = strPostDelivBox
                                .Add(New SqlParameter("@strPostDelivCity", SqlDbType.NVarChar)).Value = strPostDelivCity
                                .Add(New SqlParameter("@strPostDelivRegion", SqlDbType.NVarChar)).Value = strPostDelivRegion
                                .Add(New SqlParameter("@intPostDelivCountry", SqlDbType.TinyInt)).Value = intPostDelivCountry
                                .Add(New SqlParameter("@strPostDelivCode", SqlDbType.VarChar)).Value = strPostDelivCode
                                .Add(New SqlParameter("@strAccountNumber", SqlDbType.VarChar)).Value = strPostDelivCode
                                .Add(New SqlParameter("@intEncodingScheme", SqlDbType.TinyInt)).Value = intEncodingScheme
                                .Add(New SqlParameter("@intLibId", SqlDbType.TinyInt)).Value = intLibID
                                .Add(New SqlParameter("@intOut", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intOut = .Parameters("@intOut").Value
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_CREATE_LIBRARY"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strSymbol", OracleType.VarChar, 50)).Value = strLibrarySymbol
                                .Add(New OracleParameter("strName", OracleType.VarChar, 100)).Value = strLibraryName
                                .Add(New OracleParameter("strEmailAddress", OracleType.VarChar, 50)).Value = strEmailReplyAddress
                                .Add(New OracleParameter("strTelephone", OracleType.VarChar, 14)).Value = strTelephone
                                .Add(New OracleParameter("strCode", OracleType.Char, 4)).Value = strLibraryCode
                                .Add(New OracleParameter("strNote", OracleType.VarChar, 200)).Value = strNote
                                .Add(New OracleParameter("strEDelivMode", OracleType.VarChar, 50)).Value = strEDelivMode
                                .Add(New OracleParameter("strEDelivTSAddr", OracleType.VarChar, 50)).Value = strEDelivTSAddr
                                .Add(New OracleParameter("strBillDelivName", OracleType.VarChar, 50)).Value = strBillDelivName
                                .Add(New OracleParameter("strBillDelivXAddr", OracleType.VarChar, 50)).Value = strBillDelivXAddr
                                .Add(New OracleParameter("strBillDelivStreet", OracleType.VarChar, 50)).Value = strBillDelivStreet
                                .Add(New OracleParameter("strBillDelivBox", OracleType.VarChar, 50)).Value = strBillDelivBox
                                .Add(New OracleParameter("strBillDelivCity", OracleType.VarChar, 50)).Value = strBillDelivCity
                                .Add(New OracleParameter("strBillDelivRegion", OracleType.VarChar, 50)).Value = strBillDelivRegion
                                .Add(New OracleParameter("intBillDelivCountry", OracleType.Number)).Value = intBillDelivCountry
                                .Add(New OracleParameter("strBillDelivCode", OracleType.VarChar, 50)).Value = strBillDelivCode
                                .Add(New OracleParameter("strPostDelivName", OracleType.VarChar, 100)).Value = strPostDelivName
                                .Add(New OracleParameter("strPostDelivXAddr", OracleType.VarChar, 100)).Value = strPostDelivXAddr
                                .Add(New OracleParameter("strPostDelivStreet", OracleType.VarChar, 50)).Value = strPostDelivStreet
                                .Add(New OracleParameter("strPostDelivBox", OracleType.VarChar, 50)).Value = strPostDelivBox
                                .Add(New OracleParameter("strPostDelivCity", OracleType.VarChar, 50)).Value = strPostDelivCity
                                .Add(New OracleParameter("strPostDelivRegion", OracleType.VarChar, 50)).Value = strPostDelivRegion
                                .Add(New OracleParameter("intPostDelivCountry", OracleType.Number)).Value = intPostDelivCountry
                                .Add(New OracleParameter("strPostDelivCode", OracleType.VarChar, 10)).Value = strPostDelivCode
                                .Add(New OracleParameter("strAccountNumber", OracleType.VarChar, 50)).Value = strPostDelivCode
                                .Add(New OracleParameter("intEncodingScheme", OracleType.Number)).Value = intEncodingScheme
                                .Add(New OracleParameter("intOut", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intOut = .Parameters("intOut").Value
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            Return intOut
        End Function

        Public Function Update() As Integer
            Dim intOut As Integer = 0

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spLibrary_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = lngLibID
                                .Add(New SqlParameter("@strSymbol", SqlDbType.NVarChar)).Value = strLibrarySymbol
                                .Add(New SqlParameter("@strName", SqlDbType.NVarChar)).Value = strLibraryName
                                .Add(New SqlParameter("@strEmailAddress", SqlDbType.VarChar)).Value = strEmailReplyAddress
                                .Add(New SqlParameter("@strTelephone", SqlDbType.VarChar)).Value = strTelephone
                                .Add(New SqlParameter("@strCode", SqlDbType.Char)).Value = strLibraryCode
                                .Add(New SqlParameter("@strNote", SqlDbType.NVarChar)).Value = strNote
                                .Add(New SqlParameter("@strEDelivMode", SqlDbType.NVarChar)).Value = strEDelivMode
                                .Add(New SqlParameter("@strEDelivTSAddr", SqlDbType.NVarChar)).Value = strEDelivTSAddr
                                .Add(New SqlParameter("@strBillDelivName", SqlDbType.NVarChar)).Value = strBillDelivName
                                .Add(New SqlParameter("@strBillDelivXAddr", SqlDbType.NVarChar)).Value = strBillDelivXAddr
                                .Add(New SqlParameter("@strBillDelivStreet", SqlDbType.NVarChar)).Value = strBillDelivStreet
                                .Add(New SqlParameter("@strBillDelivBox", SqlDbType.NVarChar)).Value = strBillDelivBox
                                .Add(New SqlParameter("@strBillDelivCity", SqlDbType.NVarChar)).Value = strBillDelivCity
                                .Add(New SqlParameter("@strBillDelivRegion", SqlDbType.NVarChar)).Value = strBillDelivRegion
                                .Add(New SqlParameter("@intBillDelivCountry", SqlDbType.TinyInt)).Value = intBillDelivCountry
                                .Add(New SqlParameter("@strBillDelivCode", SqlDbType.VarChar)).Value = strBillDelivCode
                                .Add(New SqlParameter("@strPostDelivName", SqlDbType.NVarChar)).Value = strPostDelivName
                                .Add(New SqlParameter("@strPostDelivXAddr", SqlDbType.NVarChar)).Value = strPostDelivXAddr
                                .Add(New SqlParameter("@strPostDelivStreet", SqlDbType.NVarChar)).Value = strPostDelivStreet
                                .Add(New SqlParameter("@strPostDelivBox", SqlDbType.NVarChar)).Value = strPostDelivBox
                                .Add(New SqlParameter("@strPostDelivCity", SqlDbType.NVarChar)).Value = strPostDelivCity
                                .Add(New SqlParameter("@strPostDelivRegion", SqlDbType.NVarChar)).Value = strPostDelivRegion
                                .Add(New SqlParameter("@intPostDelivCountry", SqlDbType.TinyInt)).Value = intPostDelivCountry
                                .Add(New SqlParameter("@strPostDelivCode", SqlDbType.VarChar)).Value = strPostDelivCode
                                .Add(New SqlParameter("@intEncodingScheme", SqlDbType.TinyInt)).Value = intEncodingScheme
                                .Add(New SqlParameter("@intOut", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intOut = .Parameters("@intOut").Value
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_UPDATE_LIBRARY  "
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intLibID", OracleType.Number)).Value = lngLibID
                                .Add(New OracleParameter("strSymbol", OracleType.VarChar, 50)).Value = strLibrarySymbol
                                .Add(New OracleParameter("strName", OracleType.VarChar, 100)).Value = strLibraryName
                                .Add(New OracleParameter("strEmailAddress", OracleType.VarChar, 50)).Value = strEmailReplyAddress
                                .Add(New OracleParameter("strTelephone", OracleType.VarChar, 14)).Value = strTelephone
                                .Add(New OracleParameter("strCode", OracleType.Char, 4)).Value = strLibraryCode
                                .Add(New OracleParameter("strNote", OracleType.VarChar, 200)).Value = strNote
                                .Add(New OracleParameter("strEDelivMode", OracleType.VarChar, 50)).Value = strEDelivMode
                                .Add(New OracleParameter("strEDelivTSAddr", OracleType.VarChar, 50)).Value = strEDelivTSAddr
                                .Add(New OracleParameter("strBillDelivName", OracleType.VarChar, 50)).Value = strBillDelivName
                                .Add(New OracleParameter("strBillDelivXAddr", OracleType.VarChar, 50)).Value = strBillDelivXAddr
                                .Add(New OracleParameter("strBillDelivStreet", OracleType.VarChar, 50)).Value = strBillDelivStreet
                                .Add(New OracleParameter("strBillDelivBox", OracleType.VarChar, 50)).Value = strBillDelivBox
                                .Add(New OracleParameter("strBillDelivCity", OracleType.VarChar, 50)).Value = strBillDelivCity
                                .Add(New OracleParameter("strBillDelivRegion", OracleType.VarChar, 50)).Value = strBillDelivRegion
                                .Add(New OracleParameter("intBillDelivCountry", OracleType.Number)).Value = intBillDelivCountry
                                .Add(New OracleParameter("strBillDelivCode", OracleType.VarChar, 50)).Value = strBillDelivCode
                                .Add(New OracleParameter("strPostDelivName", OracleType.VarChar, 100)).Value = strPostDelivName
                                .Add(New OracleParameter("strPostDelivXAddr", OracleType.VarChar, 100)).Value = strPostDelivXAddr
                                .Add(New OracleParameter("strPostDelivStreet", OracleType.VarChar, 50)).Value = strPostDelivStreet
                                .Add(New OracleParameter("strPostDelivBox", OracleType.VarChar, 50)).Value = strPostDelivBox
                                .Add(New OracleParameter("strPostDelivCity", OracleType.VarChar, 50)).Value = strPostDelivCity
                                .Add(New OracleParameter("strPostDelivRegion", OracleType.VarChar, 50)).Value = strPostDelivRegion
                                .Add(New OracleParameter("intPostDelivCountry", OracleType.Number)).Value = intPostDelivCountry
                                .Add(New OracleParameter("strPostDelivCode", OracleType.VarChar, 10)).Value = strPostDelivCode
                                .Add(New OracleParameter("strAccountNumber", OracleType.VarChar, 50)).Value = strPostDelivCode
                                .Add(New OracleParameter("intEncodingScheme", OracleType.Number)).Value = intEncodingScheme
                                .Add(New OracleParameter("intOut", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intOut = .Parameters("intOut").Value
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            Return intOut
        End Function

        ' Delete method
        ' Purpose: Delete a remote library
        ' Input: LibID
        ' Output: 0 if success
        ' Creator: 
        Public Function Delete() As Integer
            Dim intOut As Integer = 0

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_Library_Del"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = lngLibID
                            .Parameters.Add(New SqlParameter("@intOut", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            intOut = .Parameters("@intOut").Value
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_DELETE_LIBRARY"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intLibID", OracleType.Number)).Value = lngLibID
                            .Parameters.Add(New OracleParameter("intOut", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            intOut = .Parameters("intOut").Value
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            Return intOut
        End Function

        ' Get Local Library method
        ' Purpose: Get local libraries
        ' Input: intID (0 is all)
        ' Output:  DataTable
        ' Creator: Sondp
        Public Function GetLocalLib(ByVal intID As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_GET_LOCAL_LIBRARY_ADDR"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intID", OracleType.Number)).Value = intID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetLocalLib = dsData.Tables("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_SPLocalLibraryAddress_SelById"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intID
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetLocalLib = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            dsData.Tables.Remove("tblResult")
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function


        ' Purpose: Get ILL quick view
        ' Input: intOption (0,1,2)
        ' Output:  DataTable
        ' Creator: Sondp
        Public Function GetQuickView(ByVal intOption As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_STAT_QUICKVIEW"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intOption", OracleType.Number)).Value = intOption
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetQuickView = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spSelStatQuickView"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intOption", SqlDbType.Int)).Value = intOption
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetQuickView = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
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

        ' Get Edelivery Local Library method
        ' Purpose: Get Edelivery local libraries
        ' Input: intID (0 is all)
        ' Output:  DataTable
        ' Creator: Sondp
        Public Function GetELocalLib(ByVal intID As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ILL.SP_ILL_GET_LOCAL_ELIBRARY_ADDR"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intID", OracleType.Number)).Value = intID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetELocalLib = dsData.Tables("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spLocalLibraryEAddress_SelById"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intID
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetELocalLib = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            dsData.Tables.Remove("tblResult")
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
                Call MyBase.Dispose(isDisposing)
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Dispose()
            End Try
        End Sub
    End Class
End Namespace