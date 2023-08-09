' Purpose: process form
' Creator: Oanhtn
' Created Date: 28/04/2004
' Modification history:
'   - 28/04/2004 by KhoaNA
'       + Add Public Function SearchField() As DataTable 
'   - 07/05/2004 by Oanhtn: get all none marc fields
'       + Add new method: GetUserFields to get all none marc fields

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Catalogue
    Public Class clsDField
        Inherits clsDBase

        ' *****************************************************************************************************
        ' Declare Private variables
        ' *****************************************************************************************************

        Protected strFieldCode As String
        Private strFieldName As String
        Private strVietFieldName As String
        Private strIndicators As String
        Private strVietIndicators As String
        Private intRepeatable As Integer
        Private intMandatory As Integer
        Private strDescription As String
        Private intDicID As Integer
        Private intFieldTypeID As Integer
        Private intLength As Integer
        Private intFunctionID As Integer
        Private intLinkTypeID As Integer
        Private intBlockID As Integer
        Protected strFCURL1 As String
        Protected strFCURL2 As String
        Protected strFCURL3 As String
        Protected strFCURL4 As String
        Protected strFCURL5 As String
        Protected strFCURL6 As String
        Protected strPickedFieldCodes As String
        Protected strMandatoryFieldCodes As String
        Private intHaveParentFieldCode As Integer
        Protected intIsAuthority As Integer
        Private strPattern As String
        Public strSQL As String

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' FieldCode property
        Public Property FieldCode() As String
            Get
                Return strFieldCode
            End Get
            Set(ByVal Value As String)
                strFieldCode = Value
            End Set
        End Property

        ' FieldName property
        Public Property FieldName() As String
            Get
                Return strFieldName
            End Get
            Set(ByVal Value As String)
                strFieldName = Value
            End Set
        End Property

        ' VietFieldName property
        Public Property VietFieldName() As String
            Get
                Return strVietFieldName
            End Get
            Set(ByVal Value As String)
                strVietFieldName = Value
            End Set
        End Property

        ' Indicators property
        Public Property Indicators() As String
            Get
                Return strIndicators
            End Get
            Set(ByVal Value As String)
                strIndicators = Value
            End Set
        End Property

        ' VietIndicators property
        Public Property VietIndicators() As String
            Get
                Return strVietIndicators
            End Get
            Set(ByVal Value As String)
                strVietIndicators = Value
            End Set
        End Property

        ' Repeatable property
        Public Property Repeatable() As Integer
            Get
                Return intRepeatable
            End Get
            Set(ByVal Value As Integer)
                intRepeatable = Value
            End Set
        End Property

        ' Mandatory property
        Public Property Mandatory() As Integer
            Get
                Return intMandatory
            End Get
            Set(ByVal Value As Integer)
                intMandatory = Value
            End Set
        End Property

        ' Length property
        Public Property Length() As Integer
            Get
                Return intLength
            End Get
            Set(ByVal Value As Integer)
                intLength = Value
            End Set
        End Property

        ' Description property
        Public Property Description() As String
            Get
                Return strDescription
            End Get
            Set(ByVal Value As String)
                strDescription = Value
            End Set
        End Property

        ' LinkTypeID property
        Public Property LinkTypeID() As Integer
            Get
                Return intLinkTypeID
            End Get
            Set(ByVal Value As Integer)
                intLinkTypeID = Value
            End Set
        End Property

        ' FunctionID property
        Public Property FunctionID() As Integer
            Get
                Return intFunctionID
            End Get
            Set(ByVal Value As Integer)
                intFunctionID = Value
            End Set
        End Property

        ' FieldTypeID property
        Public Property FieldTypeID() As Integer
            Get
                Return intFieldTypeID
            End Get
            Set(ByVal Value As Integer)
                intFieldTypeID = Value
            End Set
        End Property

        ' DicID property
        Public Property DicID() As Integer
            Get
                Return intDicID
            End Get
            Set(ByVal Value As Integer)
                intDicID = Value
            End Set
        End Property

        ' BlockID property
        Public Property BlockID() As Integer
            Get
                Return intBlockID
            End Get
            Set(ByVal Value As Integer)
                intBlockID = Value
            End Set
        End Property

        ' FCURL1 property
        Public Property FCURL1() As String
            Get
                Return strFCURL1
            End Get
            Set(ByVal Value As String)
                strFCURL1 = Value
            End Set
        End Property

        ' FCURL2 property
        Public Property FCURL2() As String
            Get
                Return strFCURL2
            End Get
            Set(ByVal Value As String)
                strFCURL2 = Value
            End Set
        End Property

        ' FCURL3 property
        Public Property FCURL3() As String
            Get
                Return strFCURL3
            End Get
            Set(ByVal Value As String)
                strFCURL3 = Value
            End Set
        End Property

        ' FCURL4 property
        Public Property FCURL4() As String
            Get
                Return strFCURL4
            End Get
            Set(ByVal Value As String)
                strFCURL4 = Value
            End Set
        End Property

        ' FCURL5 property
        Public Property FCURL5() As String
            Get
                Return strFCURL5
            End Get
            Set(ByVal Value As String)
                strFCURL5 = Value
            End Set
        End Property

        ' FCURL6 property
        Public Property FCURL6() As String
            Get
                Return strFCURL6
            End Get
            Set(ByVal Value As String)
                strFCURL6 = Value
            End Set
        End Property

        'HaveParentFieldCode property
        Public Property HaveParentFieldCode() As Integer
            Get
                Return intHaveParentFieldCode
            End Get
            Set(ByVal Value As Integer)
                intHaveParentFieldCode = Value
            End Set
        End Property

        ' IsAuthority property
        Public Property IsAuthority() As Integer
            Get
                Return intIsAuthority
            End Get
            Set(ByVal Value As Integer)
                intIsAuthority = Value
            End Set
        End Property

        ' Pattern property
        Public Property Pattern() As String
            Get
                Return strPattern
            End Get
            Set(ByVal Value As String)
                strPattern = Value
            End Set
        End Property

        ' PickedFieldCodes property
        Public Property PickedFieldCodes() As String
            Get
                Return strPickedFieldCodes
            End Get
            Set(ByVal Value As String)
                strPickedFieldCodes = Value
            End Set
        End Property

        ' MandatoryFieldCodes property
        Public Property MandatoryFieldCodes() As String
            Get
                Return strMandatoryFieldCodes
            End Get
            Set(ByVal Value As String)
                strMandatoryFieldCodes = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Create method
        ' Purpose: Create new field (user define)
        ' Input: all properties of field
        ' Output: int value (0 when fail)
        Public Function Create() As Integer
            Dim intFieldID As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_CREATE_MARC_BIB_FIELD"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strFieldCode", OracleType.VarChar, 10)).Value = strFieldCode
                            .Parameters.Add(New OracleParameter("strFieldName", OracleType.VarChar, 255)).Value = strFieldName
                            .Parameters.Add(New OracleParameter("strVietFieldName", OracleType.VarChar, 255)).Value = strVietFieldName
                            .Parameters.Add(New OracleParameter("strIndicators", OracleType.VarChar, 1000)).Value = strIndicators
                            .Parameters.Add(New OracleParameter("strVietIndicators", OracleType.VarChar, 1000)).Value = strVietIndicators
                            .Parameters.Add(New OracleParameter("intRepeatable", OracleType.Number)).Value = intRepeatable
                            .Parameters.Add(New OracleParameter("intMandatory", OracleType.Number)).Value = intMandatory
                            .Parameters.Add(New OracleParameter("intLength", OracleType.Number)).Value = intLength
                            .Parameters.Add(New OracleParameter("strDescription", OracleType.VarChar, 1000)).Value = strDescription
                            .Parameters.Add(New OracleParameter("intLinkTypeID", OracleType.Number)).Value = intLinkTypeID
                            .Parameters.Add(New OracleParameter("intFunctionID", OracleType.Number)).Value = intFunctionID
                            .Parameters.Add(New OracleParameter("intFieldTypeID", OracleType.Number)).Value = intFieldTypeID
                            .Parameters.Add(New OracleParameter("intDicID", OracleType.Number)).Value = intDicID
                            .Parameters.Add(New OracleParameter("intBlockID", OracleType.Number)).Value = CInt(Left(strFieldCode, 1)) + 1
                            .Parameters.Add(New OracleParameter("intFieldID", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            intFieldID = .Parameters("intFieldID").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spMARCBibField_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strFieldCode", SqlDbType.VarChar)).Value = strFieldCode
                            .Parameters.Add(New SqlParameter("@strFieldName", SqlDbType.NVarChar)).Value = strFieldName
                            .Parameters.Add(New SqlParameter("@strVietFieldName", SqlDbType.NVarChar)).Value = strVietFieldName
                            .Parameters.Add(New SqlParameter("@strIndicators", SqlDbType.NVarChar)).Value = strIndicators
                            .Parameters.Add(New SqlParameter("@strVietIndicators", SqlDbType.NVarChar)).Value = strVietIndicators
                            .Parameters.Add(New SqlParameter("@intRepeatable", SqlDbType.Int)).Value = intRepeatable
                            .Parameters.Add(New SqlParameter("@intMandatory", SqlDbType.Int)).Value = intMandatory
                            .Parameters.Add(New SqlParameter("@intLength", SqlDbType.Int)).Value = intLength
                            .Parameters.Add(New SqlParameter("@strDescription", SqlDbType.NVarChar)).Value = strDescription
                            .Parameters.Add(New SqlParameter("@intLinkTypeID", SqlDbType.Int)).Value = intLinkTypeID
                            .Parameters.Add(New SqlParameter("@intFunctionID", SqlDbType.Int)).Value = intFunctionID
                            .Parameters.Add(New SqlParameter("@intFieldTypeID", SqlDbType.Int)).Value = intFieldTypeID
                            .Parameters.Add(New SqlParameter("@intDicID", SqlDbType.Int)).Value = intDicID
                            .Parameters.Add(New SqlParameter("@intBlockID", SqlDbType.Int)).Value = CInt(Left(strFieldCode, 1)) + 1
                            .Parameters.Add(New SqlParameter("@intFieldID", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            intFieldID = .Parameters("@intFieldID").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Create = intFieldID
            Call CloseConnection()
        End Function

        ' Modify method
        ' Purpose: Modify the information of the user define field
        Public Sub Modify()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_UPDATE_MARC_BIB_FIELD"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strFieldCode", OracleType.VarChar, 10)).Value = strFieldCode
                            .Parameters.Add(New OracleParameter("strFieldName", OracleType.VarChar, 255)).Value = strFieldName
                            .Parameters.Add(New OracleParameter("strVietFieldName", OracleType.VarChar, 255)).Value = strVietFieldName
                            .Parameters.Add(New OracleParameter("strIndicators", OracleType.VarChar, 1000)).Value = strIndicators
                            .Parameters.Add(New OracleParameter("strVietIndicators", OracleType.VarChar, 1000)).Value = strVietIndicators
                            .Parameters.Add(New OracleParameter("intRepeatable", OracleType.Number)).Value = intRepeatable
                            .Parameters.Add(New OracleParameter("intMandatory", OracleType.Number)).Value = intMandatory
                            .Parameters.Add(New OracleParameter("intLength", OracleType.Number)).Value = intLength
                            .Parameters.Add(New OracleParameter("strDescription", OracleType.VarChar, 1000)).Value = strDescription
                            .Parameters.Add(New OracleParameter("intLinkTypeID", OracleType.Number)).Value = intLinkTypeID
                            .Parameters.Add(New OracleParameter("intFunctionID", OracleType.Number)).Value = intFunctionID
                            .Parameters.Add(New OracleParameter("intFieldTypeID", OracleType.Number)).Value = intFieldTypeID
                            .Parameters.Add(New OracleParameter("intDicID", OracleType.Number)).Value = intDicID
                            .Parameters.Add(New OracleParameter("intBlockID", OracleType.Number)).Value = CInt(Left(strFieldCode, 1)) + 1
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spMARCBibField_upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strFieldCode", SqlDbType.VarChar)).Value = strFieldCode
                            .Parameters.Add(New SqlParameter("@strFieldName", SqlDbType.NVarChar)).Value = strFieldName
                            .Parameters.Add(New SqlParameter("@strVietFieldName", SqlDbType.NVarChar)).Value = strVietFieldName
                            .Parameters.Add(New SqlParameter("@strIndicators", SqlDbType.NVarChar)).Value = strIndicators
                            .Parameters.Add(New SqlParameter("@strVietIndicators", SqlDbType.NVarChar)).Value = strVietIndicators
                            .Parameters.Add(New SqlParameter("@intRepeatable", SqlDbType.Int)).Value = intRepeatable
                            .Parameters.Add(New SqlParameter("@intMandatory", SqlDbType.Int)).Value = intMandatory
                            .Parameters.Add(New SqlParameter("@intLength", SqlDbType.Int)).Value = intLength
                            .Parameters.Add(New SqlParameter("@strDescription", SqlDbType.NVarChar)).Value = strDescription
                            .Parameters.Add(New SqlParameter("@intLinkTypeID", SqlDbType.Int)).Value = intLinkTypeID
                            .Parameters.Add(New SqlParameter("@intFunctionID", SqlDbType.Int)).Value = intFunctionID
                            .Parameters.Add(New SqlParameter("@intFieldTypeID", SqlDbType.Int)).Value = intFieldTypeID
                            .Parameters.Add(New SqlParameter("@intDicID", SqlDbType.Int)).Value = intDicID
                            .Parameters.Add(New SqlParameter("@intBlockID", SqlDbType.Int)).Value = CInt(Left(strFieldCode, 1)) + 1
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

        ' Delete method
        ' Purpose: Delete the selected user define fied
        ' KHONG CO STORE NAY
        Public Sub Delete()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_MARC_BIB_FIELD_DEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strFieldCode", OracleType.VarChar, 5)).Value = strFieldCode
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "SP_MARC_BIB_FIELD_DEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strFieldCode", SqlDbType.VarChar)).Value = strFieldCode
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

        ' GetProperties method
        ' Purpose: Get all properties of the selected field
        Public Function GetProperties() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_GET_FIELD_PROPERTIES"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intIsAuthority", OracleType.Number)).Value = intIsAuthority
                            .Parameters.Add(New OracleParameter("strFieldCode", OracleType.VarChar, 5)).Value = strFieldCode
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter = New OracleDataAdapter(oraCommand)
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetProperties = dsData.Tables("tblResult")
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
                        .CommandText = "Lib_spMARCAuthorityField_SelFieldProperties"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intIsAuthority", SqlDbType.Int)).Value = intIsAuthority
                            .Parameters.Add(New SqlParameter("@strFieldCode", SqlDbType.VarChar)).Value = strFieldCode
                            SqlDataAdapter = New SqlDataAdapter(SqlCommand)
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetProperties = dsData.Tables("tblResult")
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

        ' GetSubFields method
        ' Purpose: Get all subfield of the selected field
        Public Function GetSubFields() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_GET_SUBFIELDS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intIsAuthority", OracleType.Number)).Value = intIsAuthority
                            .Parameters.Add(New OracleParameter("strFCURL1", OracleType.VarChar, 150)).Value = strFCURL1
                            .Parameters.Add(New OracleParameter("strFCURL2", OracleType.VarChar, 200)).Value = strFCURL2
                            .Parameters.Add(New OracleParameter("strFieldCode", OracleType.VarChar)).Value = strFieldCode
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter = New OracleDataAdapter(oraCommand)
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetSubFields = dsData.Tables("tblResult")
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
                        .CommandText = "Lib_spMARCBibField_SelSubFields"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intIsAuthority", SqlDbType.Int)).Value = intIsAuthority
                            .Parameters.Add(New SqlParameter("@strFCURL1", SqlDbType.VarChar)).Value = strFCURL1
                            .Parameters.Add(New SqlParameter("@strFCURL2", SqlDbType.VarChar)).Value = strFCURL2
                            .Parameters.Add(New SqlParameter("@strFieldCode", SqlDbType.VarChar)).Value = strFieldCode
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetSubFields = dsData.Tables("tblResult")
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

        ' GetIndicatorValues method
        ' Purpose: Get value of indicators of the selected field
        Public Function GetIndicatorValues() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand

                        .CommandText = "CATALOGUE.SP_CATA_GET_INDICATORS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intIsAuthority", OracleType.Number)).Value = intIsAuthority
                            .Parameters.Add(New OracleParameter("strFieldCode", OracleType.VarChar, 200)).Value = strFieldCode
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter = New OracleDataAdapter(oraCommand)
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetIndicatorValues = dsData.Tables("tblResult")
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
                        .CommandText = "Lib_spMARCAuthorityIndicator_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intIsAuthority", SqlDbType.Int)).Value = intIsAuthority
                            .Parameters.Add(New SqlParameter("@strFieldCode", SqlDbType.VarChar)).Value = strFieldCode
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetIndicatorValues = dsData.Tables("tblResult")
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

        ' GetBlockFields method
        ' Purpose: Get all blocks of sysfields
        Public Function GetBlockFields() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_GET_BLOCKFIELDS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intIsAuthority", OracleType.Number)).Value = intIsAuthority
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter = New OracleDataAdapter(oraCommand)
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetBlockFields = dsData.Tables("tblResult")
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
                        .CommandText = "Lib_spMARCBIBBlock_SelBlockFields"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intIsAuthority", SqlDbType.Int)).Value = intIsAuthority
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetBlockFields = dsData.Tables("tblResult")
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

        ' GetFieldsOfBlock method
        ' Purpose: Get all fields of the selected block
        Public Function GetFieldsOfBlock() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_GET_FIELDS_OF_BLOCK"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intIsAuthority", OracleType.Number)).Value = intIsAuthority
                            .Parameters.Add(New OracleParameter("strFCURL1", OracleType.VarChar, 150)).Value = strFCURL1
                            .Parameters.Add(New OracleParameter("strFCURL2", OracleType.VarChar, 150)).Value = strFCURL2
                            .Parameters.Add(New OracleParameter("intBlockID", OracleType.Number)).Value = intBlockID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter = New OracleDataAdapter(oraCommand)
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetFieldsOfBlock = dsData.Tables("tblResult")
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
                        .CommandText = "Lib_spMARCAuthorityField_SelFieldsOfBlock"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intIsAuthority", SqlDbType.Int)).Value = intIsAuthority
                            .Parameters.Add(New SqlParameter("@strFCURL1", SqlDbType.VarChar)).Value = strFCURL1
                            .Parameters.Add(New SqlParameter("@strFCURL2", SqlDbType.VarChar)).Value = strFCURL2
                            .Parameters.Add(New SqlParameter("@intBlockID", SqlDbType.Int)).Value = intBlockID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetFieldsOfBlock = dsData.Tables("tblResult")
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

        ' SearchField method
        ' Purpose: search by fieldcode
        ' Input: search pattern & some parameters
        ' Output: datatable
        Public Function SearchField() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    Try
                        With oraCommand
                            .CommandText = "CATALOGUE.SP_CATA_SEARCH_MARC_FIELDS"
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New OracleParameter("strPattern", OracleType.VarChar, 1000)).Value = strPattern
                            .Parameters.Add(New OracleParameter("intHaveParentFieldCode", OracleType.Number)).Value = intHaveParentFieldCode
                            .Parameters.Add(New OracleParameter("intIsAuthority", OracleType.Number)).Value = intIsAuthority
                            .Parameters.Add(New OracleParameter("strFCURL1", OracleType.VarChar, 1000)).Value = strFCURL1
                            .Parameters.Add(New OracleParameter("strFCURL2", OracleType.VarChar, 1000)).Value = strFCURL2
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        End With
                        oraDataAdapter.SelectCommand = oraCommand
                        oraDataAdapter.Fill(dsData, "tblResult")
                        SearchField = dsData.Tables("tblResult")
                        dsData.Tables.Remove("tblResult")
                    Catch OraEx As OracleException
                        strErrorMsg = OraEx.Message.ToString
                        intErrorCode = OraEx.Code
                    Finally
                        oraCommand.Parameters.Clear()
                    End Try
                Case "SQLSERVER"
                    Try
                        With SqlCommand
                            .CommandText = "Lib_spMARCBibField_SelToSearch"
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New SqlParameter("@strPattern", SqlDbType.NVarChar, 1000)).Value = strPattern
                            .Parameters.Add(New SqlParameter("@intHaveParentFieldCode", SqlDbType.Int)).Value = intHaveParentFieldCode
                            .Parameters.Add(New SqlParameter("@intIsAuthority", SqlDbType.Int)).Value = intIsAuthority
                            .Parameters.Add(New SqlParameter("@strFCURL1", SqlDbType.VarChar)).Value = strFCURL1
                            .Parameters.Add(New SqlParameter("@strFCURL2", SqlDbType.VarChar)).Value = strFCURL2
                        End With
                        SqlDataAdapter.SelectCommand = SqlCommand
                        SqlDataAdapter.Fill(dsData, "tblResult")
                        SearchField = dsData.Tables("tblResult")
                        dsData.Tables.Remove("tblResult")
                    Catch sqlClientEx As SqlException
                        strErrorMsg = sqlClientEx.Message.ToString
                        intErrorCode = sqlClientEx.Number
                    Finally
                        SqlCommand.Parameters.Clear()
                    End Try
            End Select
            Call CloseConnection()
        End Function


        ' GetUserFields method
        ' Purpose: get all user define fields
        ' Output: datatable
        Public Function GetUserFields() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_GET_USERFIELDS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter = New OracleDataAdapter(oraCommand)
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetUserFields = dsData.Tables("tblResult")
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
                        .CommandText = "Lib_spMARCBibField_SelUserFields"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetUserFields = dsData.Tables("tblResult")
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

        ' RetrieveMarcFieldTypes method
        ' Purpose: get all types of marcfields
        Public Function RetrieveMarcFieldTypes() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_GET_FIELDTYPES"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                    End With
                    Try
                        oraDataAdapter.SelectCommand = oraCommand
                        oraDataAdapter.Fill(dsData, "tblResult")
                        RetrieveMarcFieldTypes = dsData.Tables("tblResult")
                        dsData.Tables.Remove("tblResult")
                    Catch OraEx As OracleException
                        strErrorMsg = OraEx.Message.ToString
                        intErrorCode = OraEx.Code
                    Finally
                        oraCommand.Parameters.Clear()
                    End Try
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spMARCFieldType_SelAll"
                        .CommandType = CommandType.StoredProcedure
                    End With
                    Try
                        SqlDataAdapter.SelectCommand = SqlCommand
                        SqlDataAdapter.Fill(dsData, "tblResult")
                        RetrieveMarcFieldTypes = dsData.Tables("tblResult")
                        dsData.Tables.Remove("tblResult")
                    Catch sqlClientEx As SqlException
                        strErrorMsg = sqlClientEx.Message.ToString
                        intErrorCode = sqlClientEx.Number
                    Finally
                        SqlCommand.Parameters.Clear()
                    End Try
            End Select
            Call CloseConnection()
        End Function

        'RetrieveMarcFunctions method
        'Purpose: get all functions of marcfields
        Public Function RetrieveMarcFunctions() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_GET_FIELDFUNCTIONS"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                    End With
                    Try
                        oraDataAdapter.SelectCommand = oraCommand
                        oraDataAdapter.Fill(dsData, "tblResult")
                        RetrieveMarcFunctions = dsData.Tables("tblResult")
                        dsData.Tables.Remove("tblResult")
                    Catch OraEx As OracleException
                        strErrorMsg = OraEx.Message.ToString
                        intErrorCode = OraEx.Code
                    Finally
                        oraCommand.Parameters.Clear()
                    End Try
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spMARCFunction_SelAllFunction"
                        .CommandType = CommandType.StoredProcedure
                    End With
                    Try
                        SqlDataAdapter.SelectCommand = SqlCommand
                        SqlDataAdapter.Fill(dsData, "tblResult")
                        RetrieveMarcFunctions = dsData.Tables("tblResult")
                        dsData.Tables.Remove("tblResult")
                    Catch sqlClientEx As SqlException
                        strErrorMsg = sqlClientEx.Message.ToString
                        intErrorCode = sqlClientEx.Number
                    Finally
                        SqlCommand.Parameters.Clear()
                    End Try
            End Select
            Call CloseConnection()
        End Function

        ' GetLinkTypes method
        ' Purpose: get all type of links
        ' Output: Datatable
        Public Function GetLinkTypes() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_GET_LINKTYPES"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter = New OracleDataAdapter(oraCommand)
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetLinkTypes = dsData.Tables("tblResult")
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
                        .CommandText = "Lib_spMARCLinkType_SelAll"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetLinkTypes = dsData.Tables("tblResult")
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

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                MyBase.Dispose(True)
            Finally
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace