' Purpose: process move a location to another
' Creator: Lent
' Created Date: 23-2-2005
' Last Modified Date: 

Imports System.Data
Imports System.Data.sqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Acquisition

    Public Class clsDMoveLocation
        Inherits clsDBase
        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private intLibID1 As Integer
        Private intLocID1 As Integer
        Private intLibID2 As Integer
        Private intLocID2 As Integer
        Private strShelf1 As String = ""
        Private strShelf2 As String = ""
        Private strCode As String = ""
        Private strCopyNumber As String = ""
        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************
        ' LibID1 Properties
        Public Property LibID1() As Integer
            Get
                Return (intLibID1)
            End Get
            Set(ByVal Value As Integer)
                intLibID1 = Value
            End Set
        End Property

        ' LibID2 Properties
        Public Property LibID2() As Integer
            Get
                Return (intLibID2)
            End Get
            Set(ByVal Value As Integer)
                intLibID2 = Value
            End Set
        End Property

        ' LocationID1 Properties
        Public Property LocID1()
            Get
                Return intLocID1
            End Get
            Set(ByVal Value)
                intLocID1 = Value
            End Set
        End Property

        ' LocationID2 Properties
        Public Property LocID2()
            Get
                Return intLocID2
            End Get
            Set(ByVal Value)
                intLocID2 = Value
            End Set
        End Property

        ' Shelf1 Properties
        Public Property Shelf1() As String
            Get
                Return (strShelf1)
            End Get
            Set(ByVal Value As String)
                strShelf1 = Value
            End Set
        End Property

        ' Shelf2 Properties
        Public Property Shelf2() As String
            Get
                Return (strShelf2)
            End Get
            Set(ByVal Value As String)
                strShelf2 = Value
            End Set
        End Property

        ' CopyNumber Properties
        Public Property CopyNumber() As String
            Get
                Return (strCopyNumber)
            End Get
            Set(ByVal Value As String)
                strCopyNumber = Value
            End Set
        End Property

        ' Code Properties
        Public Property Code() As String
            Get
                Return (strCode)
            End Get
            Set(ByVal Value As String)
                strCode = Value
            End Set
        End Property
        ' *************************************************************************************************
        ' End declare properties
        ' Declare public function 
        ' *************************************************************************************************

        'purpose: move a location to another 
        'in: 
        'out:
        'creator: lent
        'date : 23-2-2005
        Public Sub UpdateHoldingMove()
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_HOLDING_MOVE_UPD"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intLibID1", OracleType.Number)).Value = intLibID1
                                .Add(New OracleParameter("intLibID2", OracleType.Number)).Value = intLibID2
                                .Add(New OracleParameter("intLocationID1", OracleType.Number)).Value = intLocID1
                                .Add(New OracleParameter("intLocationID2", OracleType.Number)).Value = intLocID2
                                .Add(New OracleParameter("strShelf1", OracleType.NVarChar, 10)).Value = strShelf1
                                .Add(New OracleParameter("strShelf2", OracleType.NVarChar, 10)).Value = strShelf2
                                .Add(New OracleParameter("strCode", OracleType.NVarChar, 20)).Value = strCode
                                .Add(New OracleParameter("strCopyNumber", OracleType.NVarChar, 2500)).Value = strCopyNumber
                            End With
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
                        .CommandText = "Lib_spHolding_UpdMoveCopyNumber"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intLibID1", SqlDbType.Int)).Value = intLibID1
                                .Add(New SqlParameter("@intLibID2", SqlDbType.Int)).Value = intLibID2
                                .Add(New SqlParameter("@intLocationID1", SqlDbType.Int)).Value = intLocID1
                                .Add(New SqlParameter("@intLocationID2", SqlDbType.Int)).Value = intLocID2
                                .Add(New SqlParameter("@strShelf1", SqlDbType.NVarChar, 10)).Value = strShelf1
                                .Add(New SqlParameter("@strShelf2", SqlDbType.NVarChar, 10)).Value = strShelf2
                                .Add(New SqlParameter("@strCode", SqlDbType.NVarChar, 20)).Value = strCode
                                .Add(New SqlParameter("@strCopyNumber", SqlDbType.NVarChar, 2500)).Value = strCopyNumber
                            End With
                            .ExecuteNonQuery()
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