' Name: clsDPhyDelAddress
' Purpose: Manage physical delivery address
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
    Public Class clsDPhyDelAddress
        Inherits clsDBase

        ' ***********************************************************************************************
        ' Declare Private variables
        ' ***********************************************************************************************

        Private intID As Integer
        Private strStreet As String
        Private strXAddress As String
        Private strAddress As String
        Private strPOBox As String
        Private strCity As String
        Private strRegion As String
        Private intCountryID As Integer
        Private strPostCode As String

        ' ***********************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' ***********************************************************************************************

        ' ID property
        Public Property ID() As Integer
            Get
                Return (intID)
            End Get
            Set(ByVal Value As Integer)
                intID = Value
            End Set
        End Property

        ' Street property
        Public Property Street() As String
            Get
                Return (strStreet)
            End Get
            Set(ByVal Value As String)
                strStreet = Value
            End Set
        End Property

        ' XAddress property
        Public Property XAddress() As String
            Get
                Return (strXAddress)
            End Get
            Set(ByVal Value As String)
                strXAddress = Value
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

        ' POBox property
        Public Property POBox() As String
            Get
                Return (strPOBox)
            End Get
            Set(ByVal Value As String)
                strPOBox = Value
            End Set
        End Property

        ' City property
        Public Property City() As String
            Get
                Return (strCity)
            End Get
            Set(ByVal Value As String)
                strCity = Value
            End Set
        End Property

        ' Region property
        Public Property Region() As String
            Get
                Return (strRegion)
            End Get
            Set(ByVal Value As String)
                strRegion = Value
            End Set
        End Property

        ' Country ID property
        Public Property CountryID() As Integer
            Get
                Return (intCountryID)
            End Get
            Set(ByVal Value As Integer)
                intCountryID = Value
            End Set
        End Property

        ' PostCode property
        Public Property PostCode() As String
            Get
                Return (strPostCode)
            End Get
            Set(ByVal Value As String)
                strPostCode = Value
            End Set
        End Property

        ' ***********************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' ***********************************************************************************************

        ' Method: GetPhyDelAddr
        ' Purpose: Get physical del address
        ' Input: intID
        ' Output: Datatable
        ' Creator: Sondp
        Public Function GetPhyDelAddr() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spLocalLibraryAddress_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intID", SqlDbType.Int, 4)).Value = intID
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            sqlDataAdapter.Fill(dsData, "Ill_spLocalLibraryAddress_Sel")
                            GetPhyDelAddr = dsData.Tables("Ill_spLocalLibraryAddress_Sel")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("Ill_spLocalLibraryAddress_Sel")
                        End Try
                    End With
                Case "ORACLE"
                    With oracommand
                        .CommandText = "ILL.SP_ILL_GET_LOCLIBADDR"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intID", OracleType.Number, 4)).Value = intID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "SP_ILL_GET_LOCLIBADDR")
                            GetPhyDelAddr = dsData.Tables("SP_ILL_GET_LOCLIBADDR")
                        Catch oraClientEx As OracleException
                            strErrorMsg = oraClientEx.Message.ToString
                            intErrorCode = oraClientEx.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("SP_ILL_GET_LOCLIBADDR")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Method: Create
        ' Purpose: Create physical del address
        ' Input: Some Information
        ' Output: 0 if success, 1 if exists
        ' Creator: Sondp
        Public Function Create() As Integer
            Dim intOut As Integer = 0

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spLocalLibraryAddress_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strAddress", SqlDbType.NVarChar, 100)).Value = strAddress
                                .Add(New SqlParameter("@strCity", SqlDbType.NVarChar, 40)).Value = strCity
                                .Add(New SqlParameter("@intCountryID", SqlDbType.Int, 4)).Value = intCountryID
                                .Add(New SqlParameter("@strPOBox", SqlDbType.VarChar, 32)).Value = strPOBox
                                .Add(New SqlParameter("@strPostCode", SqlDbType.VarChar, 10)).Value = strPostCode
                                .Add(New SqlParameter("@strRegion", SqlDbType.NVarChar, 50)).Value = strRegion
                                .Add(New SqlParameter("@strStreet", SqlDbType.NVarChar, 64)).Value = strStreet
                                .Add(New SqlParameter("@strXAddress", SqlDbType.NVarChar, 100)).Value = strXAddress
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                                .Add(New SqlParameter("@intOut", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intOut = .Parameters("@intOut").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oracommand
                        .CommandText = "ILL.SP_ILL_CREATE_LOCLIBADDR"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strAddress", OracleType.VarChar, 100)).Value = strAddress
                                .Add(New OracleParameter("strCity", OracleType.VarChar, 40)).Value = strCity
                                .Add(New OracleParameter("intCountryID", OracleType.Number, 4)).Value = intCountryID
                                .Add(New OracleParameter("strPOBox", OracleType.VarChar, 32)).Value = strPOBox
                                .Add(New OracleParameter("strPostCode", OracleType.VarChar, 32)).Value = strPostCode
                                .Add(New OracleParameter("strRegion", OracleType.VarChar, 50)).Value = strRegion
                                .Add(New OracleParameter("strStreet", OracleType.VarChar, 100)).Value = strStreet
                                .Add(New OracleParameter("strXAddress", OracleType.VarChar, 64)).Value = strXAddress
                                .Add(New OracleParameter("intOut", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intOut = .Parameters("intOut").Value
                        Catch oraClientEx As OracleException
                            strErrorMsg = oraClientEx.Message.ToString
                            intErrorCode = oraClientEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            Return intOut
        End Function

        ' Method: Update
        ' Purpose: Update physical del address
        ' Input: Some information
        ' Output: 0 if success, 1 if exists
        ' Creator: Sondp
        Public Function Update() As Integer
            Dim intOut As Integer = 0

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spLocalLibraryAddress_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intID", SqlDbType.Int, 4)).Value = intID
                                .Add(New SqlParameter("@strAddress", SqlDbType.NVarChar, 100)).Value = strAddress
                                .Add(New SqlParameter("@strCity", SqlDbType.NVarChar, 40)).Value = strCity
                                .Add(New SqlParameter("@intCountryID", SqlDbType.Int, 4)).Value = intCountryID
                                .Add(New SqlParameter("@strPOBox", SqlDbType.NVarChar, 50)).Value = strPOBox
                                .Add(New SqlParameter("@strPostCode", SqlDbType.NVarChar, 50)).Value = strPostCode
                                .Add(New SqlParameter("@strRegion", SqlDbType.NVarChar, 50)).Value = strRegion
                                .Add(New SqlParameter("@strStreet", SqlDbType.NVarChar, 64)).Value = strStreet
                                .Add(New SqlParameter("@strXAddress", SqlDbType.NVarChar, 100)).Value = strXAddress
                                .Add(New SqlParameter("@intOut", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intOut = .Parameters("@intOut").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oracommand
                        .CommandText = "ILL.SP_ILL_UPDATE_LOCLIBADDR"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intID", OracleType.Number, 4)).Value = intID
                                .Add(New OracleParameter("strAddress", OracleType.VarChar, 100)).Value = strAddress
                                .Add(New OracleParameter("strCity", OracleType.VarChar, 40)).Value = strCity
                                .Add(New OracleParameter("intCountryID", OracleType.Number, 4)).Value = intCountryID
                                .Add(New OracleParameter("strPOBox", OracleType.VarChar, 32)).Value = strPOBox
                                .Add(New OracleParameter("strPostCode", OracleType.VarChar, 32)).Value = strPostCode
                                .Add(New OracleParameter("strRegion", OracleType.VarChar, 50)).Value = strRegion
                                .Add(New OracleParameter("strStreet", OracleType.VarChar, 100)).Value = strStreet
                                .Add(New OracleParameter("strXAddress", OracleType.VarChar, 64)).Value = strXAddress
                                .Add(New OracleParameter("intOut", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intOut = .Parameters("intOut").Value
                        Catch oraClientEx As OracleException
                            strErrorMsg = oraClientEx.Message.ToString
                            intErrorCode = oraClientEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            Return intOut
        End Function

        ' Method: Delete
        ' Purpose: Delete physical del address
        ' Input: intID
        ' Creator: Sondp
        Public Function Delete() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spLocalLibraryAddress_Del"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intID", SqlDbType.Int, 4)).Value = intID
                                .Add(New SqlParameter("@intValue", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            Delete = .Parameters("@intValue").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oracommand
                        .CommandText = "ILL.SP_ILL_DELETE_LOCLIBADDR"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intID", OracleType.Number, 4)).Value = intID
                                .Add(New OracleParameter("intValue", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            Delete = .Parameters("intValue").Value
                        Catch oraClientEx As OracleException
                            strErrorMsg = oraClientEx.Message.ToString
                            intErrorCode = oraClientEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Method: Dispose
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