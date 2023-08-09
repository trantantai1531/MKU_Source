' Name: clsBUniversity
' Purpose: management patron information (class, grade...)
' Creator: Kiemdv
' Created Date: 12/1/2005
' Modification History:
'   - 25/04/2005 by Oanhtn: review 

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Patron

Namespace eMicLibAdmin.BusinessRules.Patron
    Public Class clsBUniversity
        Inherits clsBBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************

        Private strPatronIDs As String = ""
        Private intPatronID As Integer = 0
        Private intFacultyID As Integer = 0
        Private intCollegeID As Integer = 0
        Private strGrade As String = ""
        Private strUClass As String = ""

        Private objDUniversity As New clsDUniversity
        Private objBCDBS As New clsBCommonDBSystem

        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************

        ' PatronIDs property
        Public Property PatronIDs() As String
            Get
                Return strPatronIDs
            End Get
            Set(ByVal Value As String)
                strPatronIDs = Value
            End Set
        End Property

        ' PatronID property
        Public Property PatronID() As Integer
            Get
                Return intPatronID
            End Get
            Set(ByVal Value As Integer)
                intPatronID = Value
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

        ' FacultyID property
        Public Property FacultyID() As Integer
            Get
                Return intFacultyID
            End Get
            Set(ByVal Value As Integer)
                intFacultyID = Value
            End Set
        End Property

        ' Grade property
        Public Property Grade() As String
            Get
                Return strGrade
            End Get
            Set(ByVal Value As String)
                strGrade = Value
            End Set
        End Property

        ' UClass property
        Public Property UClass() As String
            Get
                Return strUClass
            End Get
            Set(ByVal Value As String)
                strUClass = Value
            End Set
        End Property

        ' *************************************************************************************************
        ' End declare properties
        ' Declare public method
        ' *************************************************************************************************

        ' Method: Initialize
        ' Purpose: Init all need objects
        Public Sub Initialize()
            objDUniversity.DBServer = strDBServer
            objDUniversity.ConnectionString = strConnectionString
            Call objDUniversity.Initialize()

            ' Initialize objBCSP object
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            Call objBCDBS.Initialize()
        End Sub

        ' Purpose: GetUniversity
        ' Input: strPatronIDs
        ' Out: Datatable
        ' Creator: Kiemdv
        Public Function GetUniversity() As DataTable
            Try
                objDUniversity.PatronIDs = strPatronIDs
                GetUniversity = objBCDBS.ConvertTable(objDUniversity.GetUniversity)
                strErrorMsg = objDUniversity.ErrorMsg
                intErrorCode = objDUniversity.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: Create
        ' Purpose: Create Patron_University
        ' Input: All parameters
        ' Creator: Kiemdv
        Public Sub Create()
            Try
                objDUniversity.PatronID = intPatronID
                objDUniversity.CollegeID = intCollegeID
                objDUniversity.FacultyID = intFacultyID
                objDUniversity.Grade = strGrade
                objDUniversity.UClass = strUClass
                Call objDUniversity.Create()
                strErrorMsg = objDUniversity.ErrorMsg
                intErrorCode = objDUniversity.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Method: Update
        ' Purpose: Update Patron_University
        ' Input: All parameters
        ' Creator: Kiemdv
        Public Sub Update()
            Try
                objDUniversity.PatronID = intPatronID
                objDUniversity.CollegeID = intCollegeID
                objDUniversity.FacultyID = intFacultyID
                objDUniversity.Grade = strGrade
                objDUniversity.UClass = strUClass
                objDUniversity.Update()
                strErrorMsg = objDUniversity.ErrorMsg
                intErrorCode = objDUniversity.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Method: Delete
        ' Purpose: Delete from Patron_University
        ' Input: PatronID
        ' Creator: Kiemdv
        Public Sub Delete()
            Try
                objDUniversity.PatronID = intPatronID
                objDUniversity.Delete()
                strErrorMsg = objDUniversity.ErrorMsg
                intErrorCode = objDUniversity.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Method: Dispose
        ' Purpose: Release resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objDUniversity Is Nothing Then
                    objDUniversity.Dispose(True)
                    objDUniversity = Nothing
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