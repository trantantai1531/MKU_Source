Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Patron

Namespace eMicLibAdmin.BusinessRules.Patron
    Public Class clsBOccupation
        Inherits clsBBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************

        Private intID As Integer
        Private strOccupation As String
        Private strIDs As String

        Private objDOccupation As New clsDOccupation
        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem

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

        ' Occupation Property
        Public Property Occupation() As String
            Get
                Return strOccupation
            End Get
            Set(ByVal Value As String)
                strOccupation = Value
            End Set
        End Property

        ' IDs Property
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
            objDOccupation.DBServer = strDBServer
            objDOccupation.ConnectionString = strConnectionString
            Call objDOccupation.Initialize()

            ' Initialize objBCSP object
            objBCSP.InterfaceLanguage = strinterfacelanguage
            objBCSP.DBServer = strDBServer
            objBCSP.ConnectionString = strConnectionString
            Call objBCSP.Initialize()

            ' Initialize objBCDBS object
            objBCDBS.InterfaceLanguage = strinterfacelanguage
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            Call objBCDBS.Initialize()
        End Sub

        ' Purpose: GetOccupation
        ' Input: Get list occupations
        ' Output: Datatable
        ' Created by: Sondp
        Public Function GetOccupation() As DataTable
            Dim tblResult As DataTable
            Dim intIndex As Integer
            Try
                tblResult = objBCDBS.ConvertTable(objDOccupation.GetOccupation())
                For intIndex = 0 To tblResult.Rows.Count - 1
                    tblResult.Rows(intIndex).Item("Postion") = CStr(intIndex + 1)
                Next
                GetOccupation = tblResult
                strErrorMsg = objDOccupation.ErrorMsg
                intErrorCode = objDOccupation.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose: Import Occupation
        ' In: strOccupation
        ' Out: intOccupationID
        ' Creator: Sondp
        Public Function ImportOccupation(ByVal strImportOccupation As String) As Integer
            Try
                objDOccupation.Occupation = objBCSP.ConvertItBack(strImportOccupation)
                ImportOccupation = objDOccupation.Create()
                strErrorMsg = objDOccupation.ErrorMsg
                intErrorCode = objDOccupation.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: Create
        ' Purpose : Create one occupation
        ' Input: occupation name
        ' Output: -1 if exists
        ' Created by: Lent
        Public Function Create() As Integer
            Try
                objDOccupation.Occupation = objBCSP.ConvertItBack(strOccupation)
                Create = objDOccupation.Create()
                strErrorMsg = objDOccupation.ErrorMsg
                intErrorCode = objDOccupation.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: Update
        ' Purpose : Update one occupation
        ' Input: ID, name
        ' Output: 0 if success, 1 if exists
        ' Created by: LENT
        Public Function Update() As Integer
            Try
                objDOccupation.ID = intID
                objDOccupation.Occupation = objBCSP.ConvertItBack(strOccupation)
                Update = objDOccupation.Update()
                strErrorMsg = objDOccupation.ErrorMsg
                intErrorCode = objDOccupation.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: Merger
        ' Purpose : merger some occupations
        ' Created by: LENT
        Public Sub Merger()
            Try
                objDOccupation.ID = intID
                objDOccupation.IDs = strIDs
                Call objDOccupation.Merger()
                strErrorMsg = objDOccupation.ErrorMsg
                intErrorCode = objDOccupation.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' purpose : Delete one Occupation
        ' Created by: Lent
        Public Sub Delete()
            Try
                objDOccupation.ID = intID
                Call objDOccupation.Delete()
                strErrorMsg = objDOccupation.ErrorMsg
                intErrorCode = objDOccupation.ErrorCode
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
                If Not objDOccupation Is Nothing Then
                    objDOccupation.Dispose(True)
                    objDOccupation = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace