' Name: clsBSysLibrary
' Purpose: 
' Creator: PhuongTT
' Created Date: 12/08/2014

Imports System
Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibOPAC.DataAccess.Common

Namespace eMicLibOPAC.BusinessRules.OPAC
    Public Class clsBSysLibrary
        Inherits clsBBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private strLanguage As String
        Private objDSysLibrary As New clsDSysLibrary
        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************

        ' Language property
        Public Property Language() As String
            Get
                Return strLanguage
            End Get
            Set(ByVal Value As String)
                strLanguage = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************
        ' Initialize method
        Public Sub Initialize()
            ' Init objDOPACLocation object
            objDSysLibrary.DBServer = strDBServer
            objDSysLibrary.ConnectionString = strConnectionString
            objDSysLibrary.Initialize()

            ' Init objBCSP object
            objBCSP.DBServer = strDBServer
            objBCSP.ConnectionString = strConnectionString
            objBCSP.InterfaceLanguage = strInterfaceLanguage
            objBCSP.Initialize()

            ' Init objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.Initialize()
        End Sub

        ' Purpose: Get all locations in all libraries
        ' Input: 
        ' Output: DataTable
        ' Created by: dgsoft2016
        Public Function SysGetAllLibrary() As DataTable
            Dim dtResult As DataTable = Nothing
            Try
                objDSysLibrary.Language = strLanguage
                dtResult = objBCDBS.ConvertTable(objDSysLibrary.SysGetAllLibraryOPAC)
                strErrorMsg = objDSysLibrary.ErrorMsg
                intErrorCode = objDSysLibrary.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return dtResult
        End Function

        ' Purpose: Get all locations in all libraries - collection
        ' Input: 
        ' Output: DataTable
        ' Created by: dgsoft2016
        Public Function SysGetAllLibraryMap() As DataTable
            Dim dtResult As DataTable = Nothing
            Try
                objDSysLibrary.Language = strLanguage
                dtResult = objBCDBS.ConvertTable(objDSysLibrary.SysGetAllLibraryMap)
                strErrorMsg = objDSysLibrary.ErrorMsg
                intErrorCode = objDSysLibrary.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return dtResult
        End Function
      

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                End If
                If Not objDSysLibrary Is Nothing Then
                    Call objDSysLibrary.Dispose(True)
                    objDSysLibrary = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    Call objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    Call objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Dispose()
            End Try
        End Sub




    End Class
End Namespace