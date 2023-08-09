Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Patron

Namespace eMicLibAdmin.BusinessRules.Patron
    Public Class clsBProvince
        Inherits clsBBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************

        Private intID As Integer
        Private strProvince As String
        Private strIDs As String

        Private objDProvince As New clsDProvince
        Private objBCDBS As New clsBCommonDBSystem
        Private objBCSP As New clsBCommonStringProc

        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************

        ' ID Property
        Public Property ID() As Integer
            Get
                Return intID
            End Get
            Set(ByVal Value As Integer)
                intID = Value
            End Set
        End Property

        ' Province property
        Public Property Province() As String
            Get
                Return strProvince
            End Get
            Set(ByVal Value As String)
                strProvince = Value
            End Set
        End Property

        ' IDs property
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
            ' Init objDProvince object
            objDProvince.DBServer = strDBServer
            objDProvince.ConnectionString = strConnectionString
            Call objDProvince.Initialize()

            ' Initialize objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.ConnectionString = strConnectionString
            Call objBCDBS.Initialize()

            ' Initialize objBCSP object
            objBCSP.DBServer = strDBServer
            objBCSP.InterfaceLanguage = strInterfaceLanguage
            objBCSP.ConnectionString = strConnectionString
            Call objBCSP.Initialize()
        End Sub

        ' Method: GetProvince
        ' Purpose : GetProvince
        ' Output: datatable result
        ' Created by: Sondp
        Public Function GetProvince() As DataTable
            Dim tblResult As DataTable
            Dim intIndex As Integer

            Try
                tblResult = objBCDBS.ConvertTable(objDProvince.GetProvince())
                For intIndex = 0 To tblResult.Rows.Count - 1
                    tblResult.Rows(intIndex).Item("Postion") = CStr(intIndex + 1)
                Next
                GetProvince = tblResult
                strErrorMsg = objDProvince.ErrorMsg
                intErrorCode = objDProvince.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function
        ' Method: GetProvince Filter
        ' Purpose : GetProvince
        ' Output: datatable result
        ' Created by: Chinhnh
        Public Function GetProvince(ByVal strFilter As String) As DataView
            Dim tblResult As DataView
            Dim intIndex As Integer

            Try
                tblResult = objBCDBS.ConvertTable(objDProvince.GetProvince()).DefaultView
                If strFilter <> "" Then
                    tblResult.RowFilter = "Province like '" & strFilter & "'"
                End If
                For intIndex = 0 To tblResult.Count - 1
                    tblResult.Item(intIndex).Item("Postion") = CStr(intIndex + 1)
                Next
                GetProvince = tblResult
                strErrorMsg = objDProvince.ErrorMsg
                intErrorCode = objDProvince.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose: Import province 
        ' In: strProvince
        ' Out: ProvinceID
        ' Creator: Sondp
        Public Function ImportProvince() As Integer
            Try
                objDProvince.Province = objBCSP.ConvertItBack(strProvince)
                ImportProvince = objDProvince.Create
                strErrorMsg = objDProvince.ErrorMsg
                intErrorCode = objDProvince.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: Create
        ' Purpose : Create one province
        ' Input: province name
        ' Output: -1 if exists
        ' Created by: Lent
        Public Function Create() As Integer
            Try
                objDProvince.Province = objBCSP.ConvertItBack(strProvince)
                Create = objDProvince.Create()
                strErrorMsg = objDProvince.ErrorMsg
                intErrorCode = objDProvince.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: Update
        ' Purpose : Update one province
        ' Input: ID, name
        ' Output: 0 if success, 1 if exists
        ' Created by: LENT
        Public Function Update() As Integer
            Try
                objDProvince.ID = intID
                objDProvince.Province = objBCSP.ConvertItBack(strProvince)
                Update = objDProvince.Update()
                strErrorMsg = objDProvince.ErrorMsg
                intErrorCode = objDProvince.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: Merger
        ' Purpose : merger some provinces
        ' Created by: LENT
        Public Sub Merger()
            Try
                objDProvince.ID = intID
                objDProvince.IDs = strIDs
                Call objDProvince.Merger()
                strErrorMsg = objDProvince.ErrorMsg
                intErrorCode = objDProvince.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' purpose : Delete one Occupation
        ' Created by: Lent
        Public Sub Delete()
            Try
                objDProvince.ID = intID
                Call objDProvince.Delete()
                strErrorMsg = objDProvince.ErrorMsg
                intErrorCode = objDProvince.ErrorCode
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
                If Not objDProvince Is Nothing Then
                    objDProvince.Dispose(True)
                    objDProvince = Nothing
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