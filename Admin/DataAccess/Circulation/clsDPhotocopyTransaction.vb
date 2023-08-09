Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Circulation
    Public Class clsDPhotocopyTransaction
        Inherits clsDBase

        ' ***************************************************************************************************
        ' Declare member variables
        ' ***************************************************************************************************
        Private intTransactionID As Integer = 0
        Private intPageCount As Integer = 0
        Private strPageDetail As String = ""
        Private intPhotocopyTypeID As Integer = 0
        Private dblAmount As Double = 0
        Private dblPaidAmount As Double = 0
        Private intItemID As Integer
        Private strCopyNumber As String
        Private strInputer As String
        Private bytDone As Byte
        Private intTypePaperID As Integer
        Private strTransactionDate As String = ""
        Private strPatronCode As String = ""
        Private strTitle As String = ""

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************
        Public Property TransactionID() As Integer
            Get
                Return intTransactionID
            End Get
            Set(ByVal Value As Integer)
                intTransactionID = Value
            End Set
        End Property

        ' PageCount property
        Public Property PageCount() As Integer
            Get
                Return intPageCount
            End Get
            Set(ByVal Value As Integer)
                intPageCount = Value
            End Set
        End Property

        ' PageDetail property
        Public Property PageDetail() As String
            Get
                Return strPageDetail
            End Get
            Set(ByVal Value As String)
                strPageDetail = Value
            End Set
        End Property

        ' PhotocopyTypeID Property
        Public Property PhotocopyTypeID() As Int16
            Get
                Return intPhotocopyTypeID
            End Get
            Set(ByVal Value As Int16)
                intPhotocopyTypeID = Value
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

        ' PaidAmount property
        Public Property PaidAmount() As Double
            Get
                Return dblPaidAmount
            End Get
            Set(ByVal Value As Double)
                dblPaidAmount = Value
            End Set
        End Property

        ' ItemID property
        Public Property ItemID() As Integer
            Get
                Return intItemID
            End Get
            Set(ByVal Value As Integer)
                intItemID = Value
            End Set
        End Property


        ' Inputer property
        Public Property Inputer() As String
            Get
                Return strInputer
            End Get
            Set(ByVal Value As String)
                strInputer = Value
            End Set
        End Property

        ' Done property
        Public Property Done() As Byte
            Get
                Return bytDone
            End Get
            Set(ByVal Value As Byte)
                bytDone = Value
            End Set
        End Property

        ' TypePayerID property
        Public Property TypePaperID() As Integer
            Get
                Return intTypePaperID
            End Get
            Set(ByVal Value As Integer)
                intTypePaperID = Value
            End Set
        End Property

        ' TransactionDate property
        Public Property TransactionDate() As String
            Get
                Return strTransactionDate
            End Get
            Set(ByVal Value As String)
                strTransactionDate = Value
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

        ' CopyNumber property
        Public Property CopyNumber() As String
            Get
                Return strCopyNumber
            End Get
            Set(ByVal Value As String)
                strCopyNumber = Value
            End Set
        End Property

        ' Title property
        Public Property Title() As String
            Get
                Return strTitle
            End Get
            Set(ByVal Value As String)
                strTitle = Value
            End Set
        End Property

        Public Sub CreatePhotocopyOrder(ByVal strCreateDate As String)
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPhotocopyRequest_Ins"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intTypeID", SqlDbType.Int)).Value = intTypePaperID
                            .Add(New SqlParameter("@monAmount", SqlDbType.Money)).Value = dblAmount
                            .Add(New SqlParameter("@monPaidAmount", SqlDbType.Money)).Value = dblPaidAmount
                            .Add(New SqlParameter("@strCopyNumber", SqlDbType.VarChar, 50)).Value = strCopyNumber
                            .Add(New SqlParameter("@strInputer", SqlDbType.NVarChar, 50)).Value = strInputer
                            .Add(New SqlParameter("@intDone", SqlDbType.Int)).Value = bytDone
                            .Add(New SqlParameter("@intPageCount", SqlDbType.Int)).Value = intPageCount
                            .Add(New SqlParameter("@strPageDetail", SqlDbType.NVarChar, 50)).Value = strPageDetail
                            .Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 30)).Value = strPatronCode
                            .Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                            .Add(New SqlParameter("@strCreateDate", SqlDbType.VarChar, 50)).Value = strCreateDate
                        End With
                        Try
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        Try
                            .CommandText = "CIRCULATION.SP_CIR_PHOTOCOPY_REQUEST_INS"
                            .CommandType = CommandType.StoredProcedure
                            With .Parameters
                                .Add(New OracleParameter("intTypeID", OracleType.Number)).Value = intTypePaperID
                                .Add(New OracleParameter("monAmount", OracleType.Double)).Value = dblAmount
                                .Add(New OracleParameter("monPaidAmount", OracleType.Double)).Value = dblPaidAmount
                                .Add(New OracleParameter("strCopyNumber", OracleType.VarChar, 50)).Value = strCopyNumber
                                .Add(New OracleParameter("strInputer", OracleType.VarChar, 50)).Value = strInputer
                                .Add(New OracleParameter("intDone", OracleType.Number)).Value = bytDone
                                .Add(New OracleParameter("intPageCount", OracleType.Number)).Value = intPageCount
                                .Add(New OracleParameter("strPageDetail", OracleType.VarChar, 50)).Value = strPageDetail
                                .Add(New OracleParameter("strPatronCode", OracleType.VarChar, 30)).Value = strPatronCode
                                .Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUserID
                                .Add(New OracleParameter("strCreateDate", OracleType.VarChar, 50)).Value = strCreateDate
                            End With
                            .ExecuteNonQuery()
                        Catch oraClientEx As OracleException
                            strErrorMsg = oraClientEx.Message
                            intErrorCode = oraClientEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Sub

        Public Function GetPhotocopyOrders(ByVal strFromCreatedDate As String, ByVal strToCreatedDate As String) As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPhotocopyRequest_Sel"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intTransactionID
                            .Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                            .Add(New SqlParameter("@strCopyNumber", SqlDbType.VarChar, 50)).Value = strCopyNumber
                            .Add(New SqlParameter("@intDone", SqlDbType.Int)).Value = bytDone
                            .Add(New SqlParameter("@strFromDate", SqlDbType.VarChar, 30)).Value = strFromCreatedDate
                            .Add(New SqlParameter("@strToDate", SqlDbType.VarChar, 20)).Value = strToCreatedDate
                            .Add(New SqlParameter("@strInputer", SqlDbType.NVarChar, 50)).Value = strInputer
                            .Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 30)).Value = strPatronCode
                        End With
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblCirPhotoRequest")
                            GetPhotocopyOrders = dsData.Tables("tblCirPhotoRequest")
                            dsData.Tables.Remove("tblCirPhotoRequest")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_CIR_PHOTO_REQUEST_SEL"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("intID", OracleType.Number)).Value = intTransactionID
                            .Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUserID
                            .Add(New OracleParameter("strCopyNumber", OracleType.VarChar, 50)).Value = strCopyNumber
                            .Add(New OracleParameter("intDone", OracleType.Number)).Value = bytDone
                            .Add(New OracleParameter("strFromDate", OracleType.VarChar, 30)).Value = strFromCreatedDate
                            .Add(New OracleParameter("strToDate", OracleType.VarChar, 10)).Value = strToCreatedDate
                            .Add(New OracleParameter("strInputer", OracleType.VarChar, 50)).Value = strInputer
                            .Add(New OracleParameter("strPatronCode", OracleType.VarChar, 30)).Value = strPatronCode
                            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        End With
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblCirPhotoRequest")
                            GetPhotocopyOrders = dsData.Tables("tblCirPhotoRequest")
                            dsData.Tables.Remove("tblCirPhotoRequest")
                        Catch oraClientEx As OracleException
                            strErrorMsg = oraClientEx.Message
                            intErrorCode = oraClientEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        ' UpdatePhotocopyOrder method
        ' Purpose: Update information if the selected PhotocopyOrder
        ' Input: intTransactionID
        Public Sub UpdatePhotocopyOrder()
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPhotocopyRequest_Upd"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intTransactionID
                            .Add(New SqlParameter("@intTypeID", SqlDbType.Int)).Value = intTypePaperID
                            .Add(New SqlParameter("@monAmount", SqlDbType.Money)).Value = dblAmount
                            .Add(New SqlParameter("@monPaidAmount", SqlDbType.Money)).Value = dblPaidAmount
                            .Add(New SqlParameter("@strCopyNumber", SqlDbType.VarChar, 50)).Value = strCopyNumber
                            .Add(New SqlParameter("@strInputer", SqlDbType.NVarChar, 50)).Value = strInputer
                            .Add(New SqlParameter("@intDone", SqlDbType.Int)).Value = bytDone
                            .Add(New SqlParameter("@intPageCount", SqlDbType.Int)).Value = intPageCount
                            .Add(New SqlParameter("@strPageDetail", SqlDbType.NVarChar, 50)).Value = strPageDetail
                            .Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 30)).Value = strPatronCode
                            .Add(New SqlParameter("@strCreatedDate", SqlDbType.VarChar, 30)).Value = strTransactionDate
                        End With
                        Try
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_CIR_PHOTOCOPY_REQUEST_UPD"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("intID", OracleType.Number)).Value = intTransactionID
                            .Add(New OracleParameter("intTypeID", OracleType.Number)).Value = intTypePaperID
                            .Add(New OracleParameter("monAmount", OracleType.Double)).Value = dblAmount
                            .Add(New OracleParameter("monPaidAmount", OracleType.Double)).Value = dblPaidAmount
                            .Add(New OracleParameter("strCopyNumber", OracleType.VarChar, 50)).Value = strCopyNumber
                            .Add(New OracleParameter("strInputer", OracleType.VarChar, 50)).Value = strInputer
                            .Add(New OracleParameter("intDone", OracleType.Number)).Value = bytDone
                            .Add(New OracleParameter("intPageCount", OracleType.Number)).Value = intPageCount
                            .Add(New OracleParameter("strPageDetail", OracleType.VarChar, 50)).Value = strPageDetail
                            .Add(New OracleParameter("strPatronCode", OracleType.VarChar, 30)).Value = strPatronCode
                        End With
                        Try
                            .ExecuteNonQuery()
                        Catch oraClientEx As OracleException
                            strErrorMsg = oraClientEx.Message
                            intErrorCode = oraClientEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Sub

        ' DeletePhotocopyOrder method
        ' Purpose: Update information if the selected PhotocopyOrder
        ' Input: intTransactionID
        Public Sub DeletePhotocopyOrder()
            Try

            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
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
