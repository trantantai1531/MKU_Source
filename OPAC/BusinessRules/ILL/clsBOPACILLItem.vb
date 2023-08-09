
Imports eMicLibOPAC.BusinessRules
Imports eMicLibOPAC.BusinessRules.OPAC
Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibOPAC.DataAccess
Imports eMicLibOPAC.DataAccess.OPAC

Namespace eMicLibOPAC.BusinessRules.OPAC
    Public Class clsBOPACILLItem
        Inherits clsBBase
        Private objBSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        Private objDOPACILLItem As New clsDOPACILLItem

        ' Initialize method
        Public Sub Initialize()
            ' Init objBCSP object
            objBSP.DBServer = strDBServer
            objBSP.ConnectionString = strConnectionString
            objBSP.InterfaceLanguage = strInterfaceLanguage
            objBSP.Initialize()

            ' Init objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.Initialize()

            ' Init objDAcqPurchaseOrder object
            objDOPACILLItem.DBServer = strDBServer
            objDOPACILLItem.ConnectionString = strConnectionString
            objDOPACILLItem.Initialize()
        End Sub

        ' GetILLRecItem 
        Public Function GetILLRecItem() As DataTable
            Try
                GetILLRecItem = objBCDBS.ConvertTable(objDOPACILLItem.GetILLRecItem)
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetILLDueItem 
        Public Function GetILLDueItem() As DataTable
            Try
                GetILLDueItem = objBCDBS.ConvertTable(objDOPACILLItem.GetILLDueItem)
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        'Dispose 
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBSP Is Nothing Then
                    objBSP.Dispose(True)
                    objBSP = Nothing
                End If
                If Not objDOPACILLItem Is Nothing Then
                    objDOPACILLItem.Dispose(True)
                    objDOPACILLItem = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace