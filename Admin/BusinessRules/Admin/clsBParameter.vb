' Name: clsBParameter
' Purpose: Management system's parameters
' Creator: Oanhtn
' Created Date: 18/11/2004
' Modification History:

Imports eMicLibAdmin.BusinessRules.Admin
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Admin

Namespace eMicLibAdmin.BusinessRules.Admin
    Public Class clsBParameter
        Inherits clsBBase

        ' *******************************************************************************************************
        ' Declare Private variables
        ' *******************************************************************************************************

        Dim objDParameter As New clsDParameter
        Dim objBCDBS As New clsBCommonDBSystem
        Dim objBCSP As New clsBCommonStringProc

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************


        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Initialize method
        ' Purpose: Init all necessary objects
        Public Sub Initialize()
            ' Init objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.Initialize()

            ' Init objBCSP object
            objBCSP.DBServer = strDBServer
            objBCSP.ConnectionString = strConnectionString
            objBCSP.InterfaceLanguage = strInterfaceLanguage
            objBCSP.Initialize()

            ' Init objDParameter object
            objDParameter.DBServer = strDBServer
            objDParameter.ConnectionString = strConnectionString
            objDParameter.Initialize()
        End Sub

        ' UpdateParamInfor method
        ' Purpose: Update system's parameters
        ' Input: values of sysparams
        ' Output: integer value (0 if success)
        Public Function UpdateParamInfor(ByVal strAlterParams As String, ByVal strAlterValues As String) As Integer
            Try
                UpdateParamInfor = objDParameter.UpdateParamInfor(strAlterParams, strAlterValues)
                strErrorMsg = objDParameter.ErrorMsg
                intErrorCode = objDParameter.ErrorCode
            Catch Ex As Exception
                strErrorMsg = Ex.Message
            Finally
            End Try
        End Function

        ' GetParamInfor method
        ' Purpose: Get system's events
        ' Output: datatable result
        Public Function GetParamInfor() As DataTable
            Try
                GetParamInfor = objBCDBS.ConvertTable(objDParameter.GetParamInfor)
                strErrorMsg = objDParameter.ErrorMsg
                intErrorCode = objDParameter.ErrorCode
            Catch Ex As Exception
                strErrorMsg = Ex.Message
            End Try
        End Function

        ' GetDatabaseSize method
        ' Purpose: Get size of databases
        ' Output: datatable result
        Public Function GetDatabaseSize() As DataTable
            Try
                GetDatabaseSize = objDParameter.GetDatabaseSize
                strErrorMsg = objDParameter.ErrorMsg
                intErrorCode = objDParameter.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objDParameter Is Nothing Then
                    objDParameter.Dispose(True)
                    objDParameter = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace