Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Patron

Namespace eMicLibAdmin.BusinessRules.Patron
    Public Class clsBCollege
        Inherits clsBBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************

        Private intID As Integer
        Private strCollege As String
        Private strIDs As String

        Private objDCollege As New clsDCollege
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

        ' College Property
        Public Property College() As String
            Get
                Return strCollege
            End Get
            Set(ByVal Value As String)
                strCollege = Value
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
            objDCollege.DBServer = strDBServer
            objDCollege.ConnectionString = strConnectionString
            Call objDCollege.Initialize()

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

        Public Function GetCollege() As DataTable
            Dim tblResult As DataTable
            Dim intIndex As Integer

            Try
                tblResult = objBCDBS.ConvertTable(objDCollege.GetCollege())
                For intIndex = 0 To tblResult.Rows.Count - 1
                    tblResult.Rows(intIndex).Item("Postion") = CStr(intIndex + 1)
                Next
                GetCollege = tblResult
                strErrorMsg = objDCollege.ErrorMsg
                intErrorCode = objDCollege.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function


        Public Function GetCollegebyName(strCollege As String) As DataTable
            Dim tblResult As DataTable
         
            Try
                tblResult = objBCDBS.ConvertTable(objDCollege.GetCollegeByName(strCollege))
                GetCollegebyName = tblResult
                strErrorMsg = objDCollege.ErrorMsg
                intErrorCode = objDCollege.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function Create() As Integer
            Try
                objDCollege.College = objBCSP.ConvertItBack(strCollege)
                Create = objDCollege.Create()
                strErrorMsg = objDCollege.ErrorMsg
                intErrorCode = objDCollege.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function ImportCollect(ByVal strImportCollect As String) As Integer
            Try
                objDCollege.College = objBCSP.ConvertItBack(strImportCollect)
                ImportCollect = objDCollege.Create
                strErrorMsg = objDCollege.ErrorMsg
                intErrorCode = objDCollege.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function Update() As Integer
            Try
                objDCollege.ID = intID
                objDCollege.College = objBCSP.ConvertItBack(strCollege)
                Update = objDCollege.Update()
                strErrorMsg = objDCollege.ErrorMsg
                intErrorCode = objDCollege.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Sub Merger()
            Try
                objDCollege.ID = intID
                objDCollege.IDs = strIDs
                Call objDCollege.Merger()
                strErrorMsg = objDCollege.ErrorMsg
                intErrorCode = objDCollege.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Sub Delete()
            Try
                objDCollege.ID = intID
                Call objDCollege.Delete()
                strErrorMsg = objDCollege.ErrorMsg
                intErrorCode = objDCollege.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Method: Dispose
        ' Purpose: Release resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objDCollege Is Nothing Then
                    objDCollege.Dispose(True)
                    objDCollege = Nothing
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