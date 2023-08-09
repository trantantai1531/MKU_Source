' Name: clsBEducation
' Purpose: 
' Creator: lent
' Created Date: 20/1/2005
' Modification History:

Imports System
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Patron

Namespace eMicLibAdmin.BusinessRules.Patron
    Public Class clsBEducation
        Inherits clsBBase

        Private objDEducation As New clsDEducation
        Private objBCDBS As New clsBCommonDBSystem
        Private objBCSP As New clsBCommonStringProc

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************

        Private intID As Integer
        Private strEducation As String
        Private strIDs As String

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

        ' Education Property
        Public Property Education() As String
            Get
                Return strEducation
            End Get
            Set(ByVal Value As String)
                strEducation = Value
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
            ' Init objDEducation object
            objDEducation.DBServer = strDBServer
            objDEducation.ConnectionString = strConnectionString
            Call objDEducation.Initialize()

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

        ' Method: GetEducation
        ' Purpose : GetEducation
        ' Created by: Lent
        Public Function GetEducation() As DataTable
            Dim tmpResult As DataTable
            Dim i As Integer
            Try
                tmpResult = objBCDBS.ConvertTable(objDEducation.GetEducation())
                For i = 0 To tmpResult.Rows.Count - 1
                    tmpResult.Rows(i).Item("Postion") = CStr(i + 1)
                Next
                GetEducation = tmpResult
                strErrorMsg = objDEducation.ErrorMsg
                intErrorCode = objDEducation.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function


        Public Function GetEducationByName(strEducationLevel As String) As DataTable
            Dim tmpResult As DataTable
            Dim i As Integer
            Try
                tmpResult = objBCDBS.ConvertTable(objDEducation.GetEducationbyName(strEducationLevel))

                GetEducationByName = tmpResult
                strErrorMsg = objDEducation.ErrorMsg
                intErrorCode = objDEducation.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: Create
        ' Purpose : Create one education
        ' Input: education name
        ' Output: -1 if exists
        ' Created by: Lent
        Public Function Create() As Integer
            Try
                objDEducation.Education = objBCSP.ConvertItBack(strEducation)
                Create = objDEducation.Create()
                strErrorMsg = objDEducation.ErrorMsg
                intErrorCode = objDEducation.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: Update
        ' Purpose : Update one education
        ' Input: ID, name
        ' Output: 0 if success, 1 if exists
        ' Created by: LENT
        Public Function Update() As Integer
            Try
                objDEducation.ID = intID
                objDEducation.Education = objBCSP.ConvertItBack(strEducation)
                Update = objDEducation.Update()
                strErrorMsg = objDEducation.ErrorMsg
                intErrorCode = objDEducation.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: Merger
        ' Purpose : Merger some educationlevels
        ' Created by: LENT
        Public Sub Merger()
            Try
                objDEducation.ID = intID
                objDEducation.IDs = strIDs
                Call objDEducation.Merger()
                strErrorMsg = objDEducation.ErrorMsg
                intErrorCode = objDEducation.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Method: Delete
        ' Purpose : Delete one education
        ' Created by: Lent
        Public Sub Delete()
            Try
                objDEducation.ID = intID
                Call objDEducation.Delete()
                strErrorMsg = objDEducation.ErrorMsg
                intErrorCode = objDEducation.ErrorCode
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
                If Not objDEducation Is Nothing Then
                    objDEducation.Dispose(True)
                    objDEducation = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace