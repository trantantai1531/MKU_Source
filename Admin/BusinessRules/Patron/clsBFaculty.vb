Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Patron

Namespace eMicLibAdmin.BusinessRules.Patron
    Public Class clsBFaculty
        Inherits clsBBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************

        Private intID As Integer = 0
        Private strFaculty As String = ""
        Private intCollegeID As Integer = 0
        Private strIDs As String = ""

        Private objDFaculty As New clsDFaculty
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

        ' Faculty Property
        Public Property Faculty() As String
            Get
                Return strFaculty
            End Get
            Set(ByVal Value As String)
                strFaculty = Value
            End Set
        End Property

        ' CollegeID property
        Public Property CollegeID() As Integer
            Get
                Return intCollegeID
            End Get
            Set(ByVal Value As Integer)
                intCollegeID = Value
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
            ' Init objDFaculty object
            objDFaculty.DBServer = strDBServer
            objDFaculty.ConnectionString = strConnectionString
            Call objDFaculty.Initialize()

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

            intID = 0
            intCollegeID = 0
        End Sub

        ' Method: GetFaculty
        ' Purpose: Get faculties
        ' Input: intCollegeID, intFacultyID
        ' Output: Datatable
        ' Created by: Sondp
        Public Function GetFaculty() As DataTable
            Dim tbltemp As DataTable
            Dim intIndex As Integer

            Try
                objDFaculty.CollegeID = intCollegeID
                objDFaculty.ID = intID
                tbltemp = objBCDBS.ConvertTable(objDFaculty.GetFaculty())
                For intIndex = 0 To tbltemp.Rows.Count - 1
                    tbltemp.Rows(intIndex).Item("Postion") = CStr(intIndex + 1)
                Next
                GetFaculty = tbltemp
                strErrorMsg = objDFaculty.ErrorMsg
                intErrorCode = objDFaculty.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function


        Public Function GetFacultyByName() As DataTable
            Dim tbltemp As DataTable
            Dim intIndex As Integer

            Try
                objDFaculty.CollegeID = intCollegeID
                objDFaculty.Faculty = strFaculty
                tbltemp = objBCDBS.ConvertTable(objDFaculty.GetFacultyByName())
                For intIndex = 0 To tbltemp.Rows.Count - 1
                    tbltemp.Rows(intIndex).Item("Postion") = CStr(intIndex + 1)
                Next
                GetFacultyByName = tbltemp
                strErrorMsg = objDFaculty.ErrorMsg
                intErrorCode = objDFaculty.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: Create
        ' Purpose: Create one faculty
        ' Input: faculty information
        ' Output: -1 if exists
        ' Created by: Lent
        Public Function Create() As Integer
            Try
                objDFaculty.CollegeID = intCollegeID
                objDFaculty.Faculty = objBCSP.ConvertItBack(strFaculty)
                Create = objDFaculty.Create()
                strErrorMsg = objDFaculty.ErrorMsg
                intErrorCode = objDFaculty.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: Update
        ' Purpose : Update one faculty
        ' Input: ID, name
        ' Output: 0 if success, 1 if exists
        ' Created by: LENT
        Public Function Update() As Integer
            Try
                objDFaculty.ID = intID
                objDFaculty.CollegeID = intCollegeID
                objDFaculty.Faculty = objBCSP.ConvertItBack(strFaculty)
                Update = objDFaculty.Update()
                strErrorMsg = objDFaculty.ErrorMsg
                intErrorCode = objDFaculty.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: Merger
        ' Purpose : Merger one Faculty
        ' Created by: LENT
        Public Sub Merger()
            Try
                objDFaculty.ID = intID
                objDFaculty.IDs = strIDs
                Call objDFaculty.Merger()
                strErrorMsg = objDFaculty.ErrorMsg
                intErrorCode = objDFaculty.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' purpose : Delete one Faculy
        ' Created by: Lent
        Public Sub Delete()
            Try
                objDFaculty.ID = intID
                Call objDFaculty.Delete()
                strErrorMsg = objDFaculty.ErrorMsg
                intErrorCode = objDFaculty.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Method: Dispose
        ' Purpose: Release resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objDFaculty Is Nothing Then
                    objDFaculty.Dispose(True)
                    objDFaculty = Nothing
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