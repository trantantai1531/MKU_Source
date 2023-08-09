' Name: clsDPhysDelMode
' Purpose: Physical transport mode
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
    Public Class clsDPhysDelMode
        Inherits clsDBase

        ' ***********************************************************************************************
        ' Declare Private variables
        ' ***********************************************************************************************

        Private intID As Integer
        Private strModeName As String

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

        ' ModeName property
        Public Property ModeName() As String
            Get
                Return strModeName
            End Get
            Set(ByVal Value As String)
                strModeName = Value
            End Set
        End Property

        ' ***********************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' ***********************************************************************************************

        ' Method: Create
        ' Purpose: Create Physical transport mode
        ' Input: strModeName
        ' Creator: Sondp
        Public Function Create() As Integer
            Dim intOut As Integer = 0

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spPhysicalDeliveryMode_InsMode"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strDeliveryMode", SqlDbType.NVarChar, 100)).Value = strModeName
                                .Add(New SqlParameter("@intLibId", SqlDbType.Int)).Value = intLibID
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
                        .CommandText = "ILL.SP_ILL_CREATE_PHYSICALMODE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strDeliveryMode", OracleType.VarChar, 100)).Value = strModeName
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
        ' Purpose: Update Physical transport mode method
        ' Input: strModeName, intID
        ' Creator: Sondp
        Public Function Update() As Integer
            Dim intOut As Integer = 0

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spPhysicalDeliveryMode_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strDeliveryMode", SqlDbType.NVarChar, 100)).Value = strModeName
                                .Add(New SqlParameter("@intID", SqlDbType.Int, 4)).Value = intID
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
                        .CommandText = "ILL.SP_ILL_UPDATE_PHYSICALMODE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strDeliveryMode", OracleType.VarChar, 100)).Value = strModeName
                                .Add(New OracleParameter("intID", OracleType.Number, 4)).Value = intID
                                .Add(New OracleParameter("intOut", OracleType.Number, 4)).Direction = ParameterDirection.Output
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

        ' Delete Physical transport mode method
        ' Purpose: Delete physical mode
        ' Input: intID
        ' Creator: Sondp
        Public Function Delete() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spPhysicalDeliveryMode_Del"
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
                        .CommandText = "ILL.SP_ILL_DELETE_PHYSICALMODE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intID", OracleType.Number, 4)).Value = intID
                                .Add(New OracleParameter("intValue", OracleType.Number, 4)).Direction = ParameterDirection.Output
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

        ' Get Physical transport mode method
        ' Purpose: GetPhyDelMode
        ' Input: intID
        ' Output: Datatable
        ' Creator: Sondp
        Public Function GetPhyDelMode() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spPhysicalDeliveryMode_SelAllOrById"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intID
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetPhyDelMode = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oracommand
                        .CommandText = "ILL.SP_ILL_GET_PHYSICALMODE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intID", OracleType.Number)).Value = intID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetPhyDelMode = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
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

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                Call MyBase.Dispose(isDisposing)
            Finally
                Dispose()
            End Try
        End Sub
    End Class
End Namespace