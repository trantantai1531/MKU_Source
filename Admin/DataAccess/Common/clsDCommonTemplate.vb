' Name: clsDCommonTemplate
' Purpose: base for another templates
' Creator: Sondp
' CreatedDate: 20/08/2004
' Modification History:

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Common
    Public Class clsDCommonTemplate
        Inherits clsDBase

        ' *****************************************************************************************************
        ' Declare member variables
        ' *****************************************************************************************************

        Protected strCreator As String
        Protected strModifier As String
        Protected strLastModifiedDate As String
        Protected intTemplateID As Integer
        Protected intLenght As Integer
        Protected intTemplateType As Integer
        Protected intStartPosition As Integer
        Protected boolEnable As Boolean
        Protected intEndPosition As Integer
        Protected strName As String
        Protected strContent As String
        Protected strHeader As String
        Protected strFooter As String
        Protected intLibID As Integer

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' Creator property
        Public Property Creator() As String
            Get
                Return strCreator
            End Get
            Set(ByVal Value As String)
                strCreator = Value
            End Set
        End Property
        'Modifier
        Public Property Modifier() As String
            Get
                Return (strModifier)
            End Get
            Set(ByVal Value As String)
                strModifier = Value
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

        ' TemplateID property
        Public Property TemplateID() As Integer
            Get
                Return intTemplateID
            End Get
            Set(ByVal Value As Integer)
                intTemplateID = Value
            End Set
        End Property

        ' Lenght property
        Public Property Lenght() As Integer
            Get
                Return intLenght
            End Get
            Set(ByVal Value As Integer)
                intLenght = Value
            End Set
        End Property

        ' StartPosition property
        Public Property StartPosition() As Integer
            Get
                Return intStartPosition
            End Get
            Set(ByVal Value As Integer)
                intStartPosition = Value
            End Set
        End Property

         ' StartPosition property
        Public Property EndPosition() As Integer
            Get
                Return intEndPosition
            End Get
            Set(ByVal Value As Integer)
                intEndPosition = Value
            End Set
        End Property

        ' EndPosition property
        Public Property Enable() As Boolean
            Get
                Return boolEnable
            End Get
            Set(ByVal Value As Boolean)
                boolEnable = Value
            End Set
        End Property
        

        'Template Type
        Public Property TemplateType() As Integer
            Get
                Return intTemplateType
            End Get
            Set(ByVal Value As Integer)
                intTemplateType = Value
            End Set
        End Property

        ' Name property
        Public Property Name() As String
            Get
                Return strName
            End Get
            Set(ByVal Value As String)
                strName = Value
            End Set
        End Property

        ' Content property
        Public Property Content() As String
            Get
                Return strContent
            End Get
            Set(ByVal Value As String)
                strContent = Value
            End Set
        End Property

        ' Header property
        Public Property Header() As String
            Get
                Return strHeader
            End Get
            Set(ByVal Value As String)
                strHeader = Value
            End Set
        End Property

        ' Footer property
        Public Property Footer() As String
            Get
                Return strFooter
            End Get
            Set(ByVal Value As String)
                strFooter = Value
            End Set
        End Property

        ' TemplateID property
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

        ' Method: CreateTemplate
        ' Purpose: Create new Template
        ' Input: some main information of Template
        ' Output: 0 if success, 1 if exists title
        Public Function CreateTemplate() As Integer
            Dim intOut As Integer = 0

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    Try
                        With sqlCommand
                            .CommandText = "Sys_spTemplate_Create"
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New SqlParameter("@strTitle", SqlDbType.NVarChar)).Value = strName
                            .Parameters.Add(New SqlParameter("@strCreator", SqlDbType.NVarChar)).Value = strCreator
                            .Parameters.Add(New SqlParameter("@strModifier", SqlDbType.NVarChar)).Value = strModifier
                            .Parameters.Add(New SqlParameter("@strContent", SqlDbType.NVarChar)).Value = strContent
                            .Parameters.Add(New SqlParameter("@intTemplateType", SqlDbType.Int)).Value = intTemplateType
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            .Parameters.Add(New SqlParameter("@intOut", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            intOut = .Parameters("@intOut").Value
                        End With
                    Catch sqlClientEx As SqlException
                        strErrorMsg = sqlClientEx.Message
                        intErrorCode = sqlClientEx.Number
                    Finally
                        sqlCommand.Parameters.Clear()
                        sqlCommand.Dispose()
                    End Try
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "COMMON.SP_SYS_CREATE_TEMPLATE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strTitle", OracleType.VarChar, 450)).Value = strName
                            .Parameters.Add(New OracleParameter("strCreator", OracleType.VarChar, 50)).Value = strCreator
                            .Parameters.Add(New OracleParameter("strModifier", OracleType.VarChar, 50)).Value = strModifier
                            .Parameters.Add(New OracleParameter("strContent", OracleType.LongVarChar, 30000)).Value = strContent
                            .Parameters.Add(New OracleParameter("intTemplateType", OracleType.Number)).Value = intTemplateType
                            .Parameters.Add(New OracleParameter("intOut", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            intOut = .Parameters("intOut").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            Return intOut
        End Function

        ' Function: GetTemplate
        ' Purpose: Create new Template
        ' Input: TemplateType, TemplateID
        ' Output: datatable result
        Public Function GetTemplate() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "Sys_spTemplate_Sel"
                        Try
                            .Parameters.Add(New SqlParameter("@intTemplateID", SqlDbType.Int)).Value = intTemplateID
                            .Parameters.Add(New SqlParameter("@intTemplateType", SqlDbType.Int)).Value = intTemplateType
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            .ExecuteNonQuery()
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetTemplate = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "COMMON.SP_SYS_GET_TEMPLATE"
                        Try
                            .Parameters.Add(New OracleParameter("intTemplateID", OracleType.Number, 4)).Value = intTemplateID
                            .Parameters.Add(New OracleParameter("intTemplateType", OracleType.Number, 4)).Value = intTemplateType
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetTemplate = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Method: UpdateTemplate
        ' Purpose: Update information of the selected Template
        ' Input: some main information of the selected Template
        ' Output: 0 if success, 1 if exists title
        Public Function UpdateTemplate() As Integer
            Dim intOut As Integer = 0

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "Sys_spTemplate_Upd3"
                        Try
                            .Parameters.Add("@intTemplateID", SqlDbType.Int).Value = intTemplateID
                            .Parameters.Add("@intTemplateType", SqlDbType.Int).Value = intTemplateType
                            .Parameters.Add("@strTitle", SqlDbType.NVarChar).Value = strName
                            .Parameters.Add("@strModifier", SqlDbType.NVarChar).Value = strModifier
                            .Parameters.Add("@strContent", SqlDbType.NText).Value = strContent
                            .Parameters.Add("@intLibId", SqlDbType.Int).Value = intLibID
                            .Parameters.Add("@intOut", SqlDbType.Int).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            intOut = .Parameters("@intOut").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "COMMON.SP_SYS_UPDATE_TEMPLATE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intTemplateType", OracleType.Number)).Value = intTemplateType
                            .Parameters.Add(New OracleParameter("intTemplateID", OracleType.Number)).Value = intTemplateID
                            .Parameters.Add(New OracleParameter("strTitle", OracleType.VarChar, 450)).Value = strName
                            .Parameters.Add(New OracleParameter("strModifier", OracleType.VarChar, 50)).Value = strModifier
                            .Parameters.Add(New OracleParameter("strContent", OracleType.LongVarChar, 30000)).Value = strContent
                            .Parameters.Add(New OracleParameter("intOut", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            intOut = .Parameters("intOut").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            Return intOut
        End Function

        ' Method: UpdateHoldingTemplate
        ' Purpose: Update information of the selected HoldingTemplate
        ' Input: some main information of the selected HoldingTemplate
        ' Output: 0 if success, 1 if exists title
        Public Function UpdateHoldingTemplate() As Integer
            Dim intOut As Integer = 0

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "Cat_spHoldingTemplate_InsOrUpd"
                        Try
                            .Parameters.Add("@intId", SqlDbType.Int).Value = intTemplateID
                            .Parameters.Add("@intLenght", SqlDbType.Int).Value = intLenght
                            .Parameters.Add("@intStartPosition", SqlDbType.Int).Value = intStartPosition
                            .Parameters.Add("@intEndPosition", SqlDbType.Int).Value = intEndPosition
                            .Parameters.Add("@boolEnable", SqlDbType.Bit).Value = boolEnable
                            .Parameters.Add("@intLibId", SqlDbType.Int).Value = intLibID
                            .Parameters.Add("@intOut", SqlDbType.Int).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            intOut = .Parameters("@intOut").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            Return intOut
        End Function

         ' Function: GetHoldingTemplate
        ' Purpose: GetHoldingTemplate
        ' Input: intLibID
        ' Output: datatable result
        Public Function GetHoldingTemplate() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "Cat_spHoldingTemplate_SelByLibID"
                        Try
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            .ExecuteNonQuery()
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetHoldingTemplate = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function


        ' Method: DeleteTemplate
        ' Purpose: delete information of the selected Template
        ' Input: intTemplateID
        Public Sub DeleteTemplate()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Sys_spTemplate_DelById"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add("@intTemplateID", SqlDbType.Int).Value = intTemplateID
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "COMMON.SP_DELETE_SYS_TEMPLATE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intTemplateID", OracleType.Number)).Value = intTemplateID
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

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