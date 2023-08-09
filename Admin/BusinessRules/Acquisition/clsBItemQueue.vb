'class:clsBItemQueue
'purpose: show list item reviewed =0
'creator: lent
'created date: 15-2-2005
'histoty update:

Imports eMicLibAdmin.DataAccess.Acquisition
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition

Namespace eMicLibAdmin.BusinessRules.Acquisition
    Public Class clsBItemQueue
        Inherits clsBBase

        Private intOrderBy As Integer
        Private strDate As String
        Private strIDs As String
        Private objDItemQueue As New clsDItemQueue
        Private objBCDBS As New clsBCommonDBSystem
        Private objBCSP As New clsBCommonStringProc

        Public Property OrderBy() As Integer
            Get
                Return intOrderBy
            End Get
            Set(ByVal Value As Integer)
                intOrderBy = Value
            End Set
        End Property

        Public Property FilterDate() As String
            Get
                Return strDate
            End Get
            Set(ByVal Value As String)
                strDate = Value
            End Set
        End Property

        Public Property IDs() As String
            Get
                Return strIDs
            End Get
            Set(ByVal Value As String)
                strIDs = Value
            End Set
        End Property

        ' Init all objects
        Public Sub Initialize()
            ' Initialize objDItemQueue object
            objDItemQueue.ConnectionString = strconnectionstring
            objDItemQueue.DBServer = strdbserver
            objDItemQueue.Initialize()
            ' Initialize objBCDBS object
            objBCDBS.ConnectionString = strconnectionstring
            objBCDBS.DBServer = strdbserver
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.Initialize()
            ' Initialize objBCSP object
            objBCSP.ConnectionString = strconnectionstring
            objBCSP.DBServer = strdbserver
            objBCSP.InterfaceLanguage = strInterfaceLanguage
            objBCSP.Initialize()
        End Sub

        ' Purpose : Get list count items follow month and year
        ' In: 
        ' Out: Datatable
        ' Created by: Lent
        Function GetCountItemQueue(ByRef intCountRec As Integer, ByVal lblMonth As String) As DataTable
            Dim tmpResult As DataTable
            Dim intRow As Integer
            intCountRec = 0
            Try
                tmpResult = objBCDBS.ConvertTable(objDItemQueue.GetCountItemQueue)
                If Not tmpResult Is Nothing Then
                    For intRow = 0 To tmpResult.Rows.Count - 1
                        intCountRec = intCountRec + CInt(tmpResult.Rows(intRow).Item("NOR"))
                        tmpResult.Rows(intRow).Item("Content") = "    " & lblMonth & " " & tmpResult.Rows(intRow).Item("InputDate") & "(" & tmpResult.Rows(intRow).Item("NOR") & ")"
                    Next
                End If
                GetCountItemQueue = tmpResult
                strErrorMsg = objDItemQueue.ErrorMsg
                intErrorCode = objDItemQueue.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        ' Purpose : Get content items
        ' In: 
        ' Out: Datatable
        ' Created by: Lent
        Function GetListItemQueue() As DataTable
            Try
                objDItemQueue.OrderBy = intOrderBy
                objDItemQueue.FilterDate = strDate
                GetListItemQueue = objBCDBS.ConvertTable(objDItemQueue.GetListItemQueue, "Content")
            Catch ex As Exception
                strErrorMsg = objDItemQueue.ErrorMsg
                intErrorCode = objDItemQueue.ErrorCode
            End Try
        End Function

        ' Purpose : Get content and document code of items
        ' In: 
        ' Out: Datatable
        ' Created by: Lent
        ' Date : 26-2-2005
        Function GetInfoItem() As DataTable
            Dim tblResult As DataTable
            Dim intRow As Integer
            Try
                objDItemQueue.IDs = strIDs
                tblResult = objBCDBS.ConvertTable(objDItemQueue.GetInfoItem, "Content")
                For intRow = 0 To tblResult.Rows.Count - 1
                    tblResult.Rows(intRow).Item("InOrder") = CStr(intRow + 1)
                Next
                GetInfoItem = tblResult
            Catch ex As Exception
                strErrorMsg = objDItemQueue.ErrorMsg
                intErrorCode = objDItemQueue.ErrorCode
            End Try
        End Function

        ' Release resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objDItemQueue Is Nothing Then
                    objDItemQueue.Dispose(True)
                    objDItemQueue = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace