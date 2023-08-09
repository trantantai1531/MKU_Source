' Purpose: process form
' Creator: Oanhtn
' Created Date: 14/04/2004
' Modification history:
'   - 07/05/04 by Oanhtn: merger two marcform
'       + Add two properties: intSouFormID, intDesFormID
'       + Add method: MergerForms to merger two marcform
'   - 12/07/2004 by Oanhtn: set textbox fields
'       + Add new property: strTextBoxFields
'       + Update two method: Create & Modify to resolve problem abowe
'   - 14/07/2004 by Oanhtn
'       + Add new method: GetTextAreaFields to get all textarea fields
'   - 27/07/2004 by Oanhtn: set default value (include indicator value)
'       + Modify two method: Create & Modify

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Catalogue
    Public Class clsDForm
        Inherits clsDField

        ' *****************************************************************************************************
        ' Declare Private variables
        ' *****************************************************************************************************

        Protected intFormID As Integer
        Private strFormName As String
        Private strCreator As String
        Private strNote As String
        Private strCreatedDate As String
        Private strLastModifiedDate As String
        Protected strFieldCodes As String
        Private strFieldDefaultValues As String
        Private strTextBoxFields As String
        Private strFieldIndicatorValues As String
        Private intSouFormID As Integer = 0
        Private intDesFormID As Integer = 0

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' FormID property
        Public Property FormID() As Integer
            Get
                Return intFormID
            End Get
            Set(ByVal Value As Integer)
                intFormID = Value
            End Set
        End Property

        ' FormName property
        Public Property FormName() As String
            Get
                Return strFormName
            End Get
            Set(ByVal Value As String)
                strFormName = Value
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

        ' Note property
        Public Property Note() As String
            Get
                Return strNote
            End Get
            Set(ByVal Value As String)
                strNote = Value
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

        ' LastModifiedDate property
        Public Property LastModifiedDate() As String
            Get
                Return strLastModifiedDate
            End Get
            Set(ByVal Value As String)
                strLastModifiedDate = Value
            End Set
        End Property

        ' FieldCodes property
        Public Property FieldCodes() As String
            Get
                Return strFieldCodes
            End Get
            Set(ByVal Value As String)
                strFieldCodes = Value
            End Set
        End Property

        ' FieldDefaultValues property
        Public Property FieldDefaultValues() As String
            Get
                Return strFieldDefaultValues
            End Get
            Set(ByVal Value As String)
                strFieldDefaultValues = Value
            End Set
        End Property

        ' FieldIndicatorValues property
        Public Property FieldIndicatorValues() As String
            Get
                Return strFieldIndicatorValues
            End Get
            Set(ByVal Value As String)
                strFieldIndicatorValues = Value
            End Set
        End Property

        ' TextBoxFields property
        Public Property TextBoxFields() As String
            Get
                Return strTextBoxFields
            End Get
            Set(ByVal Value As String)
                strTextBoxFields = Value
            End Set
        End Property

        ' SouFormID property
        Public Property SouFormID() As Integer
            Get
                Return intSouFormID
            End Get
            Set(ByVal Value As Integer)
                intSouFormID = Value
            End Set
        End Property

        ' DesFormID property
        Public Property DesFormID() As Integer
            Get
                Return intDesFormID
            End Get
            Set(ByVal Value As Integer)
                intDesFormID = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Create method
        ' Purpose: Create new catalogue form
        ' Input: integer value
        Public Overloads Function Create() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_CREATE_MARC_FORM"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intIsAuthority", OracleType.Number)).Value = intIsAuthority
                            .Parameters.Add(New OracleParameter("strFormName", OracleType.VarChar, 255)).Value = strFormName
                            .Parameters.Add(New OracleParameter("strCreator", OracleType.VarChar, 50)).Value = strCreator
                            .Parameters.Add(New OracleParameter("strNote", OracleType.VarChar, 255)).Value = strNote
                            .Parameters.Add(New OracleParameter("strFieldCodes", OracleType.VarChar, 1000)).Value = strFieldCodes
                            .Parameters.Add(New OracleParameter("strMandatoryFieldCodes", OracleType.VarChar, 1000)).Value = strMandatoryFieldCodes
                            .Parameters.Add(New OracleParameter("strFieldDefaultValues", OracleType.VarChar, 2000)).Value = strFieldDefaultValues
                            .Parameters.Add(New OracleParameter("strTextBoxFields", OracleType.VarChar, 1000)).Value = strTextBoxFields
                            .Parameters.Add(New OracleParameter("strFieldIndicatorValues", OracleType.VarChar, 1000)).Value = strFieldIndicatorValues
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
                        .CommandText = "Lib_SPMARCWorksheet_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intIsAuthority", SqlDbType.Int)).Value = intIsAuthority
                            .Parameters.Add(New SqlParameter("@strFormName", SqlDbType.NVarChar)).Value = strFormName
                            .Parameters.Add(New SqlParameter("@strCreator", SqlDbType.NVarChar)).Value = strCreator
                            .Parameters.Add(New SqlParameter("@strNote", SqlDbType.NVarChar)).Value = strNote
                            .Parameters.Add(New SqlParameter("@strFieldCodes", SqlDbType.VarChar, 1000)).Value = strFieldCodes
                            .Parameters.Add(New SqlParameter("@strMandatoryFieldCodes", SqlDbType.VarChar, 1000)).Value = strMandatoryFieldCodes
                            .Parameters.Add(New SqlParameter("@strFieldDefaultValues", SqlDbType.NVarChar, 2000)).Value = strFieldDefaultValues
                            .Parameters.Add(New SqlParameter("@strTextBoxFields", SqlDbType.VarChar, 1000)).Value = strTextBoxFields
                            .Parameters.Add(New SqlParameter("@strFieldIndicatorValues", SqlDbType.VarChar, 1000)).Value = strFieldIndicatorValues
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
        End Function

        ' Modify method
        ' Purpose: Modify the selected catalogue form
        Public Overloads Sub Modify()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_UPDATE_MARC_FORM"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intIsAuthority", OracleType.Number)).Value = intIsAuthority
                            .Parameters.Add(New OracleParameter("intFormID", OracleType.Number)).Value = intFormID
                            .Parameters.Add(New OracleParameter("strFormName", OracleType.VarChar, 255)).Value = strFormName
                            .Parameters.Add(New OracleParameter("strNote", OracleType.VarChar, 255)).Value = strNote
                            .Parameters.Add(New OracleParameter("strFieldCodes", OracleType.VarChar, 1000)).Value = strFieldCodes
                            .Parameters.Add(New OracleParameter("strMandatoryFieldCodes", OracleType.VarChar, 1000)).Value = strMandatoryFieldCodes
                            .Parameters.Add(New OracleParameter("strTextBoxFields", OracleType.VarChar, 1000)).Value = strTextBoxFields
                            .Parameters.Add(New OracleParameter("strFieldDefaultValues", OracleType.VarChar, 1000)).Value = strFieldDefaultValues
                            .Parameters.Add(New OracleParameter("strFieldIndicatorValues", OracleType.VarChar, 1000)).Value = strFieldIndicatorValues
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
                        .CommandText = "Lib_spMARCBibField_updForm"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intIsAuthority", SqlDbType.Int)).Value = intIsAuthority
                            .Parameters.Add(New SqlParameter("@intFormID", SqlDbType.Int)).Value = intFormID
                            .Parameters.Add(New SqlParameter("@strFormName", SqlDbType.NVarChar)).Value = strFormName
                            .Parameters.Add(New SqlParameter("@strNote", SqlDbType.NVarChar)).Value = strNote
                            .Parameters.Add(New SqlParameter("@strFieldCodes", SqlDbType.VarChar, 1000)).Value = strFieldCodes
                            .Parameters.Add(New SqlParameter("@strMandatoryFieldCodes", SqlDbType.VarChar, 1000)).Value = strMandatoryFieldCodes
                            .Parameters.Add(New SqlParameter("@strTextBoxFields", SqlDbType.VarChar, 1000)).Value = strTextBoxFields
                            .Parameters.Add(New SqlParameter("@strFieldDefaultValues", SqlDbType.NVarChar, 1000)).Value = strFieldDefaultValues
                            .Parameters.Add(New SqlParameter("@strFieldIndicatorValues", SqlDbType.VarChar, 1000)).Value = strFieldIndicatorValues
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
        ' Purpose: Delete the selected catalogue form
        ' Khong co store nay trong sqlserver
        Public Overloads Sub Delete()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_MARC_FORM_DEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intIsAuthority", OracleType.Number)).Value = intIsAuthority
                            .Parameters.Add(New OracleParameter("intFormID", OracleType.Number)).Value = intFormID
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
                        .CommandText = "SP_MARC_FORM_DEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intIsAuthority", SqlDbType.Int)).Value = intIsAuthority
                            .Parameters.Add(New SqlParameter("@intFormID", SqlDbType.Int)).Value = intFormID
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

        ' GetBlockFields method
        ' Purpose: Get all blocks of sysfields
        'Public Function GetBlockFields() As DataTable
        '    Select Case UCase(strDBServer)
        '        Case "ORACLE"
        '            With oraCommand
        '                .CommandText = "CATALOGUE.SP_MARC_BIB_BLOCK_SEL"
        '                .CommandType = CommandType.StoredProcedure
        '                Try
        '                    .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
        '                    oraDataAdapter.SelectCommand = oraCommand
        '                    oraDataAdapter.Fill(dsData, "MARCBLOCKFIELDS")
        '                    'Catch OraEx As OracleException
        '                    '    strErrorMsg = OraEx.Message.ToString
        '                    '    intErrorCode = OraEx.Code
        '                Finally
        '                    .Parameters.Clear()
        '                End Try
        '            End With
        '        Case "SQLSERVER"
        '            With SqlCommand
        '                .CommandText = "SP_MARC_BIB_BLOCK_SEL"
        '                .CommandType = CommandType.StoredProcedure
        '                Try
        '                    SqlDataAdapter.SelectCommand = SqlCommand
        '                    SqlDataAdapter.Fill(dsData, "MARCBLOCKFIELDS")
        '                    'Catch sqlClientEx As SqlException
        '                    '    strErrorMsg = sqlClientEx.Message.ToString
        '                    '    intErrorCode = sqlClientEx.Number
        '                Finally
        '                    .Parameters.Clear()
        '                End Try
        '            End With
        '    End Select
        '    Return dsData.Tables("MARCBLOCKFIELDS")
        '    dsData.Tables.Remove("MARCBLOCKFIELDS")
        'End Function

        ' GetFields method
        ' Purpose: Get all fields of the selected catalogue form
        ' Output: datatable result
        Public Function GetFields() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_GETFIELDS_OF_FORM"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intIsAuthority", OracleType.Number)).Value = intIsAuthority
                            .Parameters.Add(New OracleParameter("intFormID", OracleType.Number)).Value = intFormID
                            .Parameters.Add(New OracleParameter("strCreator", OracleType.VarChar, 50)).Value = strCreator
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetFields = dsData.Tables("tblResult")
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
                        .CommandText = "Lib_spMARCWorksheet_SelFieldOfForm"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intIsAuthority", SqlDbType.Int)).Value = intIsAuthority
                            .Parameters.Add(New SqlParameter("@intFormID", SqlDbType.Int)).Value = intFormID
                            .Parameters.Add(New SqlParameter("@strCreator", SqlDbType.NVarChar)).Value = strCreator
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetFields = dsData.Tables("tblResult")
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

        ' GetForms method
        ' Purpose: Get information of all catalogue forms
        ' Input: int value of FormID (if need)
        ' Output: Datatable
        Public Function GetForms() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_GET_MARC_FORM"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intIsAuthority", OracleType.Number)).Value = intIsAuthority
                            .Parameters.Add(New OracleParameter("intFormID", OracleType.Number)).Value = intFormID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetForms = dsData.Tables("tblResult")
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
                        .CommandText = "Lib_spMARCWorksheet_SelMARCForm"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intIsAuthority", SqlDbType.Int)).Value = intIsAuthority
                            .Parameters.Add(New SqlParameter("@intFormID", SqlDbType.Int)).Value = intFormID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetForms = dsData.Tables("tblResult")
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

        ' GetForms method
        ' Purpose: merger some catalogue forms
        ' Input: two int value of sourceFormID, destinationFormID
        Public Sub MergerForms()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_MERGER_MARC_FORM"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intIsAuthority", OracleType.Number)).Value = intIsAuthority
                            .Parameters.Add(New OracleParameter("intSouFormID", OracleType.Number)).Value = intSouFormID
                            .Parameters.Add(New OracleParameter("intDesFormID", OracleType.Number)).Value = intDesFormID
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
                        .CommandText = "Lib_spMARCAuthorityWorksheet_MergeMARCForm"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intIsAuthority", SqlDbType.Int)).Value = intIsAuthority
                            .Parameters.Add(New SqlParameter("@intSouFormID", SqlDbType.Int)).Value = intSouFormID
                            .Parameters.Add(New SqlParameter("@intDesFormID", SqlDbType.Int)).Value = intDesFormID
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

        ' GetFieldsToView method
        ' Purpose: Get properties of all current picked fields
        ' Input: strFCURL1, strFCURL2, strPickedFieldCodes, strMandatoryFieldCodes
        ' Output: Datatable result
        Public Function GetFieldsToView() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_GETFIELDSTOVIEW"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intIsAuthority", OracleType.Number)).Value = intIsAuthority
                            .Parameters.Add(New OracleParameter("strFCURL1", OracleType.VarChar, 150)).Value = strFCURL1
                            .Parameters.Add(New OracleParameter("strFCURL2", OracleType.VarChar, 200)).Value = strFCURL2
                            .Parameters.Add(New OracleParameter("strFCURL3", OracleType.VarChar, 100)).Value = strFCURL3
                            .Parameters.Add(New OracleParameter("strFCURL4", OracleType.VarChar, 100)).Value = strFCURL4
                            .Parameters.Add(New OracleParameter("strFCURL5", OracleType.VarChar, 120)).Value = strFCURL5
                            .Parameters.Add(New OracleParameter("strFCURL6", OracleType.VarChar, 120)).Value = strFCURL6
                            .Parameters.Add(New OracleParameter("strPickedFieldCodes", OracleType.VarChar, 1000)).Value = strPickedFieldCodes
                            .Parameters.Add(New OracleParameter("strMandatoryFieldCodes", OracleType.VarChar, 1000)).Value = strMandatoryFieldCodes
                            .Parameters.Add(New OracleParameter("intFormID", OracleType.Number)).Value = intFormID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetFieldsToView = dsData.Tables("tblResult")
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
                        .CommandText = "Lib_spMARCBibField_SelFieldsToView"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intIsAuthority", SqlDbType.Int)).Value = intIsAuthority
                            .Parameters.Add(New SqlParameter("@strFCURL1", SqlDbType.VarChar)).Value = strFCURL1
                            .Parameters.Add(New SqlParameter("@strFCURL2", SqlDbType.VarChar)).Value = strFCURL2
                            .Parameters.Add(New SqlParameter("@strFCURL3", SqlDbType.VarChar)).Value = strFCURL3
                            .Parameters.Add(New SqlParameter("@strFCURL4", SqlDbType.VarChar)).Value = strFCURL4
                            .Parameters.Add(New SqlParameter("@strFCURL5", SqlDbType.VarChar)).Value = strFCURL5
                            .Parameters.Add(New SqlParameter("@strFCURL6", SqlDbType.VarChar)).Value = strFCURL6
                            .Parameters.Add(New SqlParameter("@strPickedFieldCodes", SqlDbType.VarChar)).Value = strPickedFieldCodes
                            .Parameters.Add(New SqlParameter("@strMandatoryFieldCodes", SqlDbType.VarChar)).Value = strMandatoryFieldCodes
                            .Parameters.Add(New SqlParameter("@intFormID", SqlDbType.Int)).Value = intFormID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetFieldsToView = dsData.Tables("tblResult")
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

        ' GetFieldsToView method
        ' Purpose: Get properties of all current picked fields
        ' Input: intIsAuthority, intFormID
        ' Output: Datatable result
        Public Function GetPickedFieldView() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_GET_PICKED_FIELDVIEW"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intIsAuthority", OracleType.Number)).Value = intIsAuthority
                            .Parameters.Add(New OracleParameter("strPickedField", OracleType.VarChar, 4000)).Value = strPickedFieldCodes
                            .Parameters.Add(New OracleParameter("intFormID", OracleType.Number)).Value = intFormID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetPickedFieldView = dsData.Tables("tblResult")
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
                        .CommandText = "Lib_spMARCBibField_SelPickedFieldVIew"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intIsAuthority", SqlDbType.Int)).Value = intIsAuthority
                            .Parameters.Add(New SqlParameter("@strPickedField", SqlDbType.VarChar)).Value = strPickedFieldCodes
                            .Parameters.Add(New SqlParameter("@intFormID", SqlDbType.Int)).Value = intFormID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetPickedFieldView = dsData.Tables("tblResult")
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

        ' GetTextAreaFields method
        ' Purpose: Get all textarea fields
        ' Input: intIsAuthority, intFormID
        ' Output: Datatable result
        Public Function GetTextAreaFields() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_GET_TEXTAREAFIELDS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intIsAuthority", OracleType.Number)).Value = intIsAuthority
                            .Parameters.Add(New OracleParameter("intFormID", OracleType.Number)).Value = intFormID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetTextAreaFields = dsData.Tables("tblResult")
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
                        .CommandText = "Lib_spMARCAuthorityWSDetail_SelTextAreaFields"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intIsAuthority", SqlDbType.Int)).Value = intIsAuthority
                            .Parameters.Add(New SqlParameter("@intFormID", SqlDbType.Int)).Value = intFormID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetTextAreaFields = dsData.Tables("tblResult")
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