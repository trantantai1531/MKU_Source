Imports System
Imports System.Data
Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Edeliv
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess
Imports eMicLibAdmin.DataAccess.Edeliv

Namespace eMicLibAdmin.BusinessRules.Edeliv
    Public Class clsBEFile
        Inherits clsBBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************

        Private objBSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        Private objDEFile As New clsDEFile
        Private dblSizeOfFile As Double = 0
        Private dblPriceOfFile As Double = 0
        Private strNote As String = ""

        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************

        ' GetFileInfor method
        ' Purpose: Get information of the selected file
        ' Input: FileID
        ' Output: datatable result
        Public Function GetFileInfor() As DataTable
            Try
                GetFileInfor = objBCDBS.ConvertTable(objDEFile.GetFileInfor)
                strErrorMsg = objDEFile.ErrorMsg
                intErrorCode = objDEFile.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function StatisFileUpload(Optional ByVal strCateloguer As String = "", Optional ByVal strDateFrom As String = "", Optional ByVal strDateTo As String = "", Optional ByVal intStatus As Integer = 3, Optional ByVal intType As Integer = 0)
            Try
                Dim strFullDateTimeFrom As String = ""
                Dim strFullDateTimeTo As String = ""

                If Trim(strDateFrom) <> "" Then
                    strFullDateTimeFrom = objBCDBS.ConvertDateBack(strDateFrom, True)
                End If

                If Trim(strDateFrom) <> "" Then
                    strFullDateTimeTo = objBCDBS.ConvertDateBack(strDateTo, True)
                End If

                StatisFileUpload = objBCDBS.ConvertTable(objDEFile.StatisFileUpload(strCateloguer, strFullDateTimeFrom, strFullDateTimeTo, intStatus, intType), "Content")
                strErrorMsg = objDEFile.ErrorMsg
                intErrorCode = objDEFile.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

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

            ' Init objDEFile object
            objDEFile.DBServer = strDBServer
            objDEFile.ConnectionString = strConnectionString
            objDEFile.Initialize()
        End Sub

        ' Release resource method
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
                If Not objDEFile Is Nothing Then
                    objDEFile.Dispose(True)
                    objDEFile = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

    End Class
End Namespace
