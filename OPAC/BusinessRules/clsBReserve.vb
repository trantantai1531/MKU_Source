Imports System
Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibOPAC.DataAccess.OPAC
Imports System.Linq
Imports System.Collections.Generic

Namespace eMicLibOPAC.BusinessRules.OPAC
    Public Class clsBReserve
        Inherits clsBBase

        Protected intItemID As Integer = 0
        Protected intID As Integer = 0
        Protected strPatronCode As String = ""
        Private objBReserve As New clsDReserve
        Private objBCDBS As New clsBCommonDBSystem

        Public Property ItemID() As Integer
            Get
                Return intItemID
            End Get
            Set(ByVal Value As Integer)
                intItemID = Value
            End Set
        End Property

        ' LocationID property
        Public Property ID() As Integer
            Get
                Return intID
            End Get
            Set(ByVal Value As Integer)
                intID = Value
            End Set
        End Property

        ' LocationID property
        Public Property PatronCode() As String
            Get
                Return strPatronCode
            End Get
            Set(ByVal Value As String)
                strPatronCode = Value
            End Set
        End Property

        Public Overloads Sub Initialize()
            Try
                ' Init objBCDBS object
                objBReserve.ConnectionString = strConnectionString
                objBReserve.DBServer = strDBServer
                Call objBReserve.Initialize()

                ' Init objBCDBS object
                objBCDBS.ConnectionString = strConnectionString
                objBCDBS.DBServer = strDBServer
                objBCDBS.InterfaceLanguage = strInterfaceLanguage
                Call objBCDBS.Initialize()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Function GetReserve() As DataTable
            Try
                objBReserve.PatronCode = strPatronCode
                GetReserve = objBCDBS.ConvertTable(objBReserve.GetReserve(), "Content", True)
                strErrorMsg = objBReserve.ErrorMsg
                intErrorCode = objBReserve.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
        End Function


        Public Function GetResereByItemID(Optional ByVal intItemId As Int16 = 0) As DataTable
            Try
                GetResereByItemID = objBCDBS.ConvertTable(objBReserve.GetResereByItemID(intItemId), "Content", True)
                strErrorMsg = objBReserve.ErrorMsg
                intErrorCode = objBReserve.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
        End Function

        Public Function InsertReserve() As Integer
            Try
                objBReserve.ItemID = intItemID
                objBReserve.PatronCode = strPatronCode
                InsertReserve = objBReserve.InsertReserve()
                strErrorMsg = objBReserve.ErrorMsg
                intErrorCode = objBReserve.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
        End Function
        Public Function InsertReserveReport() As Integer
            Try
                objBReserve.ItemID = intItemID
                objBReserve.PatronCode = strPatronCode
                InsertReserveReport = objBReserve.InsertReserveReport()
                strErrorMsg = objBReserve.ErrorMsg
                intErrorCode = objBReserve.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
        End Function

        Public Function DeleteReserve() As Integer
            Try
                objBReserve.ID = intID
                DeleteReserve = objBReserve.DeleteReserve()
                strErrorMsg = objBReserve.ErrorMsg
                intErrorCode = objBReserve.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
        End Function


        Public Function DeleteReserve(ByVal strIDs As String) As Integer
            Try
                DeleteReserve = objBReserve.DeleteReserve(strIDs)
                strErrorMsg = objBReserve.ErrorMsg
                intErrorCode = objBReserve.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
        End Function

        Public Function FillReserve(ByVal intTypeReserve As Integer, ByVal intTypeSearch As Integer, Optional ByVal strSearch As String = "", Optional ByVal strDateFrom As String = "", Optional ByVal strDateTo As String = "") As DataTable
            Try
                FillReserve = objBCDBS.ConvertTable(objBReserve.FillReserve(intTypeReserve, intTypeSearch, strSearch, objBCDBS.ConvertDateBack(strDateFrom, True), objBCDBS.ConvertDateBack(strDateTo, True)), "", True)
                strErrorMsg = objBReserve.ErrorMsg
                intErrorCode = objBReserve.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
        End Function

        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            If isDisposing Then
                If Not objBReserve Is Nothing Then
                    objBReserve.Dispose(True)
                    objBReserve = Nothing
                End If

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
