' Purpose: process liquidate location
' Creator: Lent
' Created Date: 7-3-2005
' Last Modified Date: 

Imports System.Data
Imports System.Data.sqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Acquisition
    Public Class clsDHoldingRemove
        Inherits clsDBase

        ' *******************************************************************************************************
        ' Declare private variables
        ' *******************************************************************************************************
        Private strCopyNumbers As String
        Private intReasonID As Integer
        Private strRemovedDate As String
        Private strItemCode As String
        Private intTotalItem As Integer
        Private intOnLoan As Integer

        ' *******************************************************************************************************
        ' End declare variables
        ' Declare properties here
        ' *******************************************************************************************************
        Public Property CopyNumbers() As String
            Get
                Return (strCopyNumbers)
            End Get
            Set(ByVal Value As String)
                strCopyNumbers = Value
            End Set
        End Property
        Public Property ReasonID() As Integer
            Get
                Return (intReasonID)
            End Get
            Set(ByVal Value As Integer)
                intReasonID = Value
            End Set
        End Property
        Public Property RemovedDate() As String
            Get
                Return (strRemovedDate)
            End Get
            Set(ByVal Value As String)
                strRemovedDate = Value
            End Set
        End Property
        Public Property ItemCode() As String
            Get
                Return (strItemCode)
            End Get
            Set(ByVal Value As String)
                strItemCode = Value
            End Set
        End Property
        Public Property TotalItem() As Integer
            Get
                Return (intTotalItem)
            End Get
            Set(ByVal Value As Integer)
                intTotalItem = Value
            End Set
        End Property
        Public Property OnLoan() As Integer
            Get
                Return (intOnLoan)
            End Get
            Set(ByVal Value As Integer)
                intOnLoan = Value
            End Set
        End Property


        ' *******************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *******************************************************************************************************
        ' Liquidate method
        ' Purpose: process liquidate
        ' Input: 
        ' Output: 
        ' date : 7-3-2005
        Public Sub Liquidate()
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_HOLDING_REMOVED_LIQUIDATE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strCopyNumbers", OracleType.VarChar, 2500)).Value = strCopyNumbers
                                .Add(New OracleParameter("strRemovedDate", OracleType.VarChar, 20)).Value = strRemovedDate
                                .Add(New OracleParameter("intReasonID", OracleType.Number)).Value = intReasonID
                                .Add(New OracleParameter("strItemCode", OracleType.VarChar, 20)).Value = strItemCode
                                .Add(New OracleParameter("intTotalItem", OracleType.Number)).Direction = ParameterDirection.Output
                                .Add(New OracleParameter("intOnLoan", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intTotalItem = .Parameters("intTotalItem").Value
                            intOnLoan = .Parameters("intOnLoan").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_upHoldingRemoved_UpdLiquiDate"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strCopyNumbers", SqlDbType.VarChar, 2500)).Value = strCopyNumbers
                                .Add(New SqlParameter("@strRemovedDate", SqlDbType.VarChar, 20)).Value = strRemovedDate
                                .Add(New SqlParameter("@intReasonID", SqlDbType.Int)).Value = intReasonID
                                .Add(New SqlParameter("@strItemCode", SqlDbType.VarChar, 20)).Value = strItemCode
                                .Add(New SqlParameter("@intTotalItem", SqlDbType.Int)).Direction = ParameterDirection.Output
                                .Add(New SqlParameter("@intOnLoan", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intTotalItem = .Parameters("@intTotalItem").Value
                            intOnLoan = .Parameters("@intOnLoan").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Sub
        ' RetrieveRemoveReason method 
        ' Purpose: retrieve removed reason
        ' Output: datatable
        ' Creator: Lent
        Public Function GetHoldingRemoveReason() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHoldingRemoveReason_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intReasonID", SqlDbType.Int)).Value = intReasonID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetHoldingRemoveReason = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "ACQUISITION.SP_HOLDING_REMOVE_REASON_SEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intReasonID", OracleType.Number)).Value = intReasonID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetHoldingRemoveReason = dsData.Tables("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        ' Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not oraCommand Is Nothing Then
                        oraCommand.Dispose()
                        oraCommand = Nothing
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
                    If Not oraConnection Is Nothing Then
                        oraConnection.Close()
                        oraConnection.Dispose()
                        oraConnection = Nothing
                    End If
                    If Not oraDataAdapter Is Nothing Then
                        oraDataAdapter.Dispose()
                        oraDataAdapter = Nothing
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
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace