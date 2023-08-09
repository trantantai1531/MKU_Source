Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType
Imports eMicLibAdmin.DataAccess.Common

Namespace eMicLibAdmin.DataAccess.Catalogue
    Public Class clsDCatCommon
        Inherits clsDBase
        Private strItemTypeId As String
        Private intIDUser As Integer
        ' ***************************************************************************************************
        ' Public Properties
        ' ***************************************************************************************************

        'Dictionary
        Private intDicID As Integer
        Private strMethodSort As String
        Private strDicVal As String
        Private intDicTop As Integer

        ' ---- DicID Property
        Public Property DicID() As Integer
            Get
                DicID = intDicID
            End Get
            Set(ByVal Value As Integer)
                intDicID = Value
            End Set
        End Property

        ' ---- MethodSort Property
        Public Property MethodSort() As String
            Get
                MethodSort = strMethodSort
            End Get
            Set(ByVal Value As String)
                strMethodSort = Value
            End Set
        End Property

        ' ---- DicVal Property
        Public Property DicVal() As String
            Get
                DicVal = strDicVal
            End Get
            Set(ByVal Value As String)
                strDicVal = Value
            End Set
        End Property

        ' ---- DicID Property
        Public Property DicTop() As Integer
            Get
                DicTop = intDicTop
            End Get
            Set(ByVal Value As Integer)
                intDicTop = Value
            End Set
        End Property


        ' ---- ItemTypeId Property
        Public Property ItemTypeId() As String
            Get
                ItemTypeId = strItemTypeId
            End Get
            Set(ByVal Value As String)
                strItemTypeId = Value
            End Set
        End Property

        ' ---- IDUser Property
        Public Property IDUser() As Integer
            Get
                IDUser = intIDUser
            End Get
            Set(ByVal Value As Integer)
                intIDUser = Value
            End Set
        End Property

        ' ***************************************************************************************************
        ' Retrieve medium from Cat_tblDic_ItemType
        ' In: strItemTypeID
        ' Output: DataTable
        ' ***************************************************************************************************
        Public Function RetrieveItemType() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CAT_DIC_ITEM_TYPE_SEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strTypeID", OracleType.VarChar, 1000)).Value = strItemTypeId
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "ITEMTYPE")
                            RetrieveItemType = dsData.Tables("ITEMTYPE")
                            dsData.Tables.Remove("ITEMTYPE")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spDicItemType_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strTypeID", SqlDbType.VarChar)).Value = strItemTypeId
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "ITEMTYPE")
                            RetrieveItemType = dsData.Tables("ITEMTYPE")
                            dsData.Tables.Remove("ITEMTYPE")
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

        ' ***************************************************************************************************
        ' Get USER from SYS_USER
        ' In: intIDUser
        ' Output: DataTable
        ' ***************************************************************************************************
        Public Function GetUsers() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SYS.SP_SYS_GETUSER"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("intIDUser", OracleType.Number)).Value = intIDUser
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "SYSUSER")
                            GetUsers = dsData.Tables("SYSUSER")
                            dsData.Tables.Remove("SYSUSER")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Sys_spUser_Sel"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intIDUser", SqlDbType.Int)).Value = intIDUser
                        .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "SYSUSER")
                            GetUsers = dsData.Tables("SYSUSER")
                            dsData.Tables.Remove("SYSUSER")
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


        ' ***************************************************************************************************
        'getAutocompleteDictionary method
        ' Retrieve dictionary
        ' In: intDicID,strMethodSort,strDicVal,intDicTop
        ' Output: DataTable
        ' ***************************************************************************************************
        Public Function getAutocompleteDictionary() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.Opac_spAutocomplete_Dictionary"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intDicID", OracleType.Number)).Value = intDicID
                            .Parameters.Add(New OracleParameter("methodSort", OracleType.NVarChar, 5)).Value = strMethodSort
                            .Parameters.Add(New OracleParameter("strVal", OracleType.NVarChar, 100)).Value = strDicVal
                            .Parameters.Add(New OracleParameter("intTop", OracleType.Number)).Value = intDicTop
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "AUTOCOMPLETE")
                            getAutocompleteDictionary = dsData.Tables("AUTOCOMPLETE")
                            dsData.Tables.Remove("AUTOCOMPLETE")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Opac_spAutocomplete_Dictionary"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intDicID", SqlDbType.Int)).Value = intDicID
                            .Parameters.Add(New SqlParameter("@methodSort", SqlDbType.NVarChar, 5)).Value = strMethodSort
                            .Parameters.Add(New SqlParameter("@strVal", SqlDbType.NVarChar, 100)).Value = strDicVal
                            .Parameters.Add(New SqlParameter("@intTop", SqlDbType.Int)).Value = intDicTop
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "AUTOCOMPLETE")
                            getAutocompleteDictionary = dsData.Tables("AUTOCOMPLETE")
                            dsData.Tables.Remove("AUTOCOMPLETE")
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

        ' ***************************************************************************************************    
        ' Release resource method        
        ' ***************************************************************************************************
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not oraCommand Is Nothing Then
                    oraCommand.Dispose()
                    oraCommand = Nothing
                End If
                If Not oraConnection Is Nothing Then
                    oraConnection.Close()
                    oraConnection.Dispose()
                    oraConnection = Nothing
                End If
                If Not SqlCommand Is Nothing Then
                    SqlCommand.Dispose()
                    SqlCommand = Nothing
                End If
                If Not SqlConnection Is Nothing Then
                    SqlConnection.Close()
                    SqlConnection.Dispose()
                    SqlConnection = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        ' ***************************************************************************************************    
        ' Only when dispose fail
        ' ***************************************************************************************************    
        Protected Overrides Sub Finalize()
            Dispose(False)
        End Sub
    End Class
End Namespace