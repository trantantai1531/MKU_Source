' Name: clsBReservationTransaction
' Purpose: allow manage ReservationTransactions
' Creator: Tuanhv
' CreatedDate: 16/08/2004
' Modification History:

Imports System
Imports System.Data
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.DataAccess.Circulation

Namespace eMicLibAdmin.BusinessRules.Circulation
    Public Class clsBReservationTransaction
        Inherits clsBBaseTransaction

        ' *****************************************************************************************************
        ' Declare member variables
        ' *****************************************************************************************************

        Private objBCDBS As New clsBCommonDBSystem
        Private objDRTransaction As New clsDReservationTransaction

        Private strCRR_ID As String

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' CRR_ID property
        Public Property CRR_ID() As String
            Get
                Return CRR_ID
            End Get
            Set(ByVal Value As String)
                strCRR_ID = Value
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
                objDRTransaction.ConnectionString = strConnectionString
                objDRTransaction.DBServer = strDBServer
                Call objDRTransaction.Initialize()

                ' Init BaseClass
                MyBase.ConnectionString = strConnectionString
                MyBase.DBServer = strDBServer
                MyBase.InterfaceLanguage = strInterfaceLanguage
                Call MyBase.Initialize()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' GetReservationPatronInfor method
        ' Purpose: Get information of ReservationTransactions
        ' Input:
        ' Output: datatable result
        Public Function GetReservationPatronInfor(Optional ByVal intType As Int16 = 0) As DataTable
            Try
                objDRTransaction.UserID = intUserID
                GetReservationPatronInfor = objBCDBS.ConvertTable(objDRTransaction.GetReservationPatronInfor(intType), "MainItem", True)
                strErrorMsg = objDRTransaction.ErrorMsg
                intErrorCode = objDRTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            Finally
            End Try
        End Function

        Public Function GetReservationPatronByTime(Optional ByVal intType As Int16 = 0, Optional ByVal strDateFrom As String = "", Optional ByVal strDateTo As String = "") As DataTable
            Try
                objDRTransaction.UserID = intUserID
                GetReservationPatronByTime = objBCDBS.ConvertTable(objDRTransaction.GetReservationPatronByTime(0,strDateFrom, strDateTo), "MainItem", True)
                strErrorMsg = objDRTransaction.ErrorMsg
                intErrorCode = objDRTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
        End Function
        Public Function GetReservation_ReportByTime(Optional ByVal intType As Int16 = 0, Optional ByVal strDateFrom As String = "", Optional ByVal strDateTo As String = "") As DataTable
            Try
                objDRTransaction.UserID = intUserID
                GetReservation_ReportByTime = objBCDBS.ConvertTable(objDRTransaction.GetReservation_ReportByTime(0, strDateFrom, strDateTo), "MainItem", True)
                strErrorMsg = objDRTransaction.ErrorMsg
                intErrorCode = objDRTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
        End Function


        Public Function GetResereAll(Optional ByVal intType As Int16 = 0) As DataTable
            Try
                objDRTransaction.UserID = intUserID
                GetResereAll = objBCDBS.ConvertTable(objDRTransaction.GetResereAll(intType), "MainItem", True)
                strErrorMsg = objDRTransaction.ErrorMsg
                intErrorCode = objDRTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            Finally
            End Try
        End Function

        ' GetReservationCopynumberInfor method
        ' Purpose: Get information of copynumber
        ' Input:
        ' Output: datatable result
        Public Function GetReservationInfor() As DataTable
            Try
                objDRTransaction.UserID = intUserID
                objDRTransaction.LibID = intLibID
                GetReservationInfor = objBCDBS.ConvertTable(objDRTransaction.GetReservationInfor)
                strErrorMsg = objDRTransaction.ErrorMsg
                intErrorCode = objDRTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            Finally
            End Try
        End Function

        ' RemoveReservation() method
        ' Purpose: Xoa thong tin mot yeu cau dat muon tu hang doi
        ' Input:
        ' Output: datatable result
        Public Function RemoveReservation()
            Try
                objDRTransaction.CRR_ID = strCRR_ID
                objDRTransaction.RemoveReservation()
                strErrorMsg = objDRTransaction.ErrorMsg
                intErrorCode = objDRTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            Finally
            End Try
        End Function
        Public Function RemoveHoldTransaction()
            Try
                objDRTransaction.CRR_ID = strCRR_ID
                objDRTransaction.RemoveHoldTransaction()
                strErrorMsg = objDRTransaction.ErrorMsg
                intErrorCode = objDRTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            Finally
            End Try
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            If isDisposing Then
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
            End If
            MyBase.Dispose(True)
            Me.Dispose()
        End Sub
    End Class
End Namespace