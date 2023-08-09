Imports System
Imports System.Data
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.DataAccess.Circulation

Namespace eMicLibAdmin.BusinessRules.Circulation
    Public Class clsBHoldTransaction
        Inherits clsBBaseTransaction

        ' *****************************************************************************************************
        ' Declare member variables
        ' *****************************************************************************************************

        Private strCreatedDateFrom As String = ""
        Private strCreatedDateTo As String = ""
        Private strTimeOutDateFrom As String = ""
        Private strTimeOutDateTo As String = ""
        Private intReservationID As Integer = 0
        Private strSort As String = ""

        Private objBCDBS As New clsBCommonDBSystem
        Private objBCSP As New clsBCommonStringProc
        Private objDHoldTrans As New clsDHoldTransaction

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' CreatedDateFrom property
        Public Property CreatedDateFrom() As String
            Get
                Return strCreatedDateFrom
            End Get
            Set(ByVal Value As String)
                strCreatedDateFrom = Value
            End Set
        End Property

        ' CreatedDateTo property
        Public Property CreatedDateTo() As String
            Get
                Return strCreatedDateTo
            End Get
            Set(ByVal Value As String)
                strCreatedDateTo = Value
            End Set
        End Property

        ' TimeOutDateFrom property
        Public Property TimeOutDateFrom() As String
            Get
                Return strTimeOutDateFrom
            End Get
            Set(ByVal Value As String)
                strTimeOutDateFrom = Value
            End Set
        End Property

        ' TimeOutDateTo property
        Public Property TimeOutDateTo() As String
            Get
                Return strTimeOutDateTo
            End Get
            Set(ByVal Value As String)
                strTimeOutDateTo = Value
            End Set
        End Property

        ' ReservationID property
        Public Property ReservationID() As Integer
            Get
                Return intReservationID
            End Get
            Set(ByVal Value As Integer)
                intReservationID = Value
            End Set
        End Property

        ' Sort property
        Public Property Sort() As String
            Get
                Return strSort
            End Get
            Set(ByVal Value As String)
                strSort = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Initialize method
        ' Purpose: Init all necessary objects
        Public Overloads Sub Initialize()
            Try
                ' Init objBCDBS object
                objBCDBS.ConnectionString = strConnectionString
                objBCDBS.DBServer = strDBServer
                objBCDBS.InterfaceLanguage = strInterfaceLanguage
                Call objBCDBS.Initialize()

                ' objDRTransaction
                objDHoldTrans.ConnectionString = strConnectionString
                objDHoldTrans.DBServer = strDBServer
                Call objDHoldTrans.Initialize()

                ' Init objBCSP object
                objBCSP.ConnectionString = strConnectionString
                objBCSP.DBServer = strDBServer
                objBCSP.InterfaceLanguage = strInterfaceLanguage
                Call objBCSP.Initialize()

                ' Init BaseClass
                MyBase.ConnectionString = strConnectionString
                MyBase.DBServer = strDBServer
                MyBase.InterfaceLanguage = strInterfaceLanguage
                Call MyBase.Initialize()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' GetHoldTransactions function 
        ' Purpose: get information of HoldTransaction
        ' Input:
        ' Output: datatable result
        Public Function GetHoldTransactions(Optional ByVal intReserv As Integer = 0) As Object
            Try
                objDHoldTrans.Title = objBCSP.ConvertItBack(strTitle)
                objDHoldTrans.PatronCode = strPatronCode
                objDHoldTrans.CreatedDateFrom = objBCDBS.ConvertDateBack(strCreatedDateFrom, False)
                objDHoldTrans.CreatedDateTo = objBCDBS.ConvertDateBack(strCreatedDateTo, False)
                objDHoldTrans.TimeOutDateFrom = objBCDBS.ConvertDateBack(strTimeOutDateFrom, False)
                objDHoldTrans.TimeOutDateTo = objBCDBS.ConvertDateBack(strTimeOutDateTo, False)
                objDHoldTrans.UserID = intUserID
                Dim tbl As New DataTable
                objDHoldTrans.LibID = intLibID
                tbl = objBCDBS.ConvertTable(objDHoldTrans.GetHoldTransactions(intReserv), "Content", True)

                If strSort.Length = 0 Then
                    GetHoldTransactions = tbl
                ElseIf UCase(strSort) = "PATRONCODE" Or UCase(strSort) = "CREATEDDATE" Or UCase(strSort) = "EXPIREDDATE" Then
                    Dim dv As New DataView(tbl)
                    dv.Sort = strSort
                    Return dv
                ElseIf UCase(strSort) = "CONTENT" Then
                    Dim dv As New DataView(tbl)
                    ' Sort by Unicode                    
                    dv = objBCDBS.SortTable(tbl, "Content").DefaultView
                    Return dv
                ElseIf UCase(strSort) = "PATRONNAME" Then
                    Dim dv As New DataView(tbl)
                    ' Sort by Unicode                    
                    dv = objBCDBS.SortTable(tbl, "PatronName").DefaultView
                    Return dv
                ElseIf UCase(strSort) = "EXPIREDDATE" Then
                    Dim dv As New DataView(tbl)
                    ' Sort by Unicode                    
                    dv = objBCDBS.SortTable(tbl, "ExpiredDate").DefaultView
                    Return dv
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            Finally
            End Try
        End Function

        ' RemoveReservation method
        ' Purpose: remove selected ReservationTransaction
        ' Input: 
        Public Sub RemoveHoldTransactions()
            Try
                objDHoldTrans.ReservationID = intReservationID
                objDHoldTrans.RemoveHoldTransactions()
                strErrorMsg = objDHoldTrans.ErrorMsg
                intErrorCode = objDHoldTrans.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            Finally
            End Try
        End Sub

        ' CutHoldingTurn method
        ' Purpose: Cut the turn of patron reservation 
        ' Input:
        ' Output: datatable result
        Public Sub CutHoldingTurn()
            Try
                objDHoldTrans.ReservationID = intReservationID
                objDHoldTrans.CutHoldingTurn()
                strErrorMsg = objDHoldTrans.ErrorMsg
                intErrorCode = objDHoldTrans.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            Finally
            End Try
        End Sub

        ' ChangeHoldingTurn method
        ' Purpose: Change the turn of patron reservation 
        ' Input:
        ' Output: datatable result
        Public Sub ChangeHoldingTurn()
            Try
                objDHoldTrans.ReservationID = intReservationID
                objDHoldTrans.ChangeHoldingTurn()
                strErrorMsg = objDHoldTrans.ErrorMsg
                intErrorCode = objDHoldTrans.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            Finally
            End Try
        End Sub

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            If isDisposing Then
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objDHoldTrans Is Nothing Then
                    objDHoldTrans.Dispose(True)
                    objDHoldTrans = Nothing
                End If
            End If
            MyBase.Dispose(True)
            Me.Dispose()
        End Sub
    End Class
End Namespace
