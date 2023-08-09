' Name: clsBEthnic
' Purpose: Management ethnic
' Creator: lent
' Created Date: 20/1/2005
' Modification History:

Imports System
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Patron

Namespace eMicLibAdmin.BusinessRules.Patron
    Public Class clsBEthnic
        Inherits clsBBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************

        Private intID As Integer
        Private strEthnic As String
        Private strIDs As String

        Private objDEthnic As New clsDEthnic
        Private objBCDBS As New clsBCommonDBSystem
        Private objBCSP As New clsBCommonStringProc

        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************

        ' ID property
        Public Property ID() As Integer
            Get
                Return intID
            End Get
            Set(ByVal Value As Integer)
                intID = Value
            End Set
        End Property

        ' Ethnic Property
        Public Property Ethnic() As String
            Get
                Return strEthnic
            End Get
            Set(ByVal Value As String)
                strEthnic = Value
            End Set
        End Property

        ' Ethnic Property
        Public Property IDs() As String
            Get
                Return strIDs
            End Get
            Set(ByVal Value As String)
                strIDs = Value
            End Set
        End Property

        ' *************************************************************************************************
        ' End declare properties
        ' Declare public method
        ' *************************************************************************************************

        ' Method: Initialize
        ' Purpose: Init all need objects
        Public Sub Initialize()
            objDEthnic.DBServer = strDBServer
            objDEthnic.ConnectionString = strConnectionString
            Call objDEthnic.Initialize()

            ' Init objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            Call objBCDBS.Initialize()

            ' Init objBCSP object
            objBCSP.DBServer = strDBServer
            objBCSP.ConnectionString = strConnectionString
            objBCSP.InterfaceLanguage = strInterfaceLanguage
            Call objBCSP.Initialize()
        End Sub

        ' Method: GetEthnic
        ' Purpose : Get list of ethnics
        ' Created by: Lent
        Public Function GetEthnic() As DataTable
            Dim tmpResult As DataTable
            Dim intIndex As Integer

            Try
                tmpResult = objBCDBS.ConvertTable(objDEthnic.GetEthnic())
                For intIndex = 0 To tmpResult.Rows.Count - 1
                    tmpResult.Rows(intIndex).Item("Postion") = CStr(intIndex + 1)
                Next
                GetEthnic = tmpResult
                strErrorMsg = objDEthnic.ErrorMsg
                intErrorCode = objDEthnic.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try

        End Function

        ' Created by: Lent
        Public Function GetEthnicByName(stEthnicName As String) As DataTable
            Dim tmpResult As DataTable


            Try
                tmpResult = objBCDBS.ConvertTable(objDEthnic.GetEthnicByName(stEthnicName))
                GetEthnicByName = tmpResult
                strErrorMsg = objDEthnic.ErrorMsg
                intErrorCode = objDEthnic.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try

        End Function

        ' Method: GetEthnic with filter
        ' Purpose : Get list of ethnics
        ' Created by: Lent
        Public Function GetEthnic(ByVal strFilter As String) As DataView
            Dim tmpResult As DataView
            Dim intIndex As Integer

            Try
                tmpResult = objBCDBS.ConvertTable(objDEthnic.GetEthnic()).DefaultView
                If strFilter <> "" Then
                    tmpResult.RowFilter = "Ethnic like '" & strFilter & "'"
                End If
                For intIndex = 0 To tmpResult.Count - 1
                    tmpResult.Item(intIndex).Item("Postion") = CStr(intIndex + 1)
                Next
                GetEthnic = tmpResult
                strErrorMsg = objDEthnic.ErrorMsg
                intErrorCode = objDEthnic.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try

        End Function

        ' Purpose: Import Ethnic
        ' Input: strImportEthnic
        ' Output: intEthnicID
        ' Created by: Sondp
        Public Function ImportEthnic(ByVal strImportEthnic As String) As Integer
            Try
                objDEthnic.Ethnic = objBCSP.ConvertItBack(strImportEthnic)
                ImportEthnic = objDEthnic.Create()
                strErrorMsg = objDEthnic.ErrorMsg
                intErrorCode = objDEthnic.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: Create
        ' Purpose : Create one Ethnic
        ' Input: Ethnic name
        ' Output: -1 if exists
        ' Created by: Lent
        Public Function Create() As Integer
            Try
                objDEthnic.Ethnic = objBCSP.ConvertItBack(strEthnic)
                Create = objDEthnic.Create()
                strErrorMsg = objDEthnic.ErrorMsg
                intErrorCode = objDEthnic.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: Update
        ' Purpose : Update one Ethnic
        ' Input: ID, name
        ' Output: 0 if success, 1 if exists
        ' Created by: LENT
        Public Function Update() As Integer
            Try
                objDEthnic.ID = intID
                objDEthnic.Ethnic = objBCSP.ConvertItBack(strEthnic)
                Update = objDEthnic.Update()
                strErrorMsg = objDEthnic.ErrorMsg
                intErrorCode = objDEthnic.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: Merger
        ' Purpose : merger some ethnics
        ' Created by: LENT
        Public Sub Merger()
            Try
                objDEthnic.ID = intID
                objDEthnic.IDs = strIDs
                Call objDEthnic.Merger()
                strErrorMsg = objDEthnic.ErrorMsg
                intErrorCode = objDEthnic.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Method: Delete
        ' Purpose : Delete one ethnic
        ' Created by: Lent
        Public Sub Delete()
            Try
                objDEthnic.ID = intID
                Call objDEthnic.Delete()
                strErrorMsg = objDEthnic.ErrorMsg
                intErrorCode = objDEthnic.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Method: Finalize
        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub

        ' Method: Dispose
        ' Purpose: Release resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objDEthnic Is Nothing Then
                    objDEthnic.Dispose(True)
                    objDEthnic = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace