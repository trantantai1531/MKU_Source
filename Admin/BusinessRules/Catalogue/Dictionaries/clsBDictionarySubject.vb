Imports System
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.BusinessRules.Catalogue
    Public Class clsBLibrarySubject
        Inherits clsBBase

        Private objDLibrarySubject As New clsDLibrarySubject
        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem

#Region "Properties"
        Private intId As Integer
        Public Property Id() As String
            Get
                Return intId
            End Get
            Set(ByVal value As String)
                intId = value
            End Set
        End Property



        Private strSubject As String
        Public Property Subject() As String
            Get
                Return strSubject
            End Get
            Set(ByVal value As String)
                strSubject = value
            End Set
        End Property

        Private intParentId As Integer
        Public Property ParentId() As Integer
            Get
                Return intParentId
            End Get
            Set(ByVal value As Integer)
                intParentId = value
            End Set
        End Property




#End Region

        Public Sub Initialize()
            'Init objDOPACComment object
            objDLibrarySubject.DBServer = strDBServer
            objDLibrarySubject.ConnectionString = strConnectionString
            objDLibrarySubject.Initialize()

            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.Initialize()

            objBCSP.InterfaceLanguage = strInterfaceLanguage
            objBCSP.DBServer = strDBServer
            objBCSP.ConnectionString = strConnectionString
            objBCSP.Initialize()


        End Sub

        Public Function Create() As Integer
            Try
                objDLibrarySubject.Subject = strSubject
                objDLibrarySubject.ParentId = ParentId
                Create = objDLibrarySubject.Create()
            Catch ex As Exception
                'Return error if sub create not succeed
                strErrorMsg = objDLibrarySubject.ErrorMsg
                intErrorCode = objDLibrarySubject.Id
            End Try
        End Function

        Public Function Update() As Integer
            Try
                objDLibrarySubject.Id = intId
                objDLibrarySubject.Subject = strSubject
                objDLibrarySubject.ParentId = ParentId
                Update = objDLibrarySubject.Update()
            Catch ex As Exception
                'Return error if sub create not succeed
                strErrorMsg = objDLibrarySubject.ErrorMsg
                intErrorCode = objDLibrarySubject.Id
            End Try
        End Function

        Public Function Delete() As Integer
            Try
                objDLibrarySubject.Id = intId
                Delete = objDLibrarySubject.Delete()
            Catch ex As Exception
                'Return error if sub create not succeed
                strErrorMsg = objDLibrarySubject.ErrorMsg
                intErrorCode = objDLibrarySubject.Id
            End Try
        End Function

        Public Function GetAllSubject() As DataTable
            Try
                GetAllSubject = objBCDBS.ConvertTable(objDLibrarySubject.GetAllSubject())
                strErrorMsg = objDLibrarySubject.ErrorMsg
                intErrorCode = objDLibrarySubject.ErrorCode
                'Catch ex As Exception
                '    strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        Public Function GetAllSubjectName() As DataTable
            Try
                GetAllSubjectName = objBCDBS.ConvertTable(objDLibrarySubject.GetAllSubjectName())
                strErrorMsg = objDLibrarySubject.ErrorMsg
                intErrorCode = objDLibrarySubject.ErrorCode
                'Catch ex As Exception
                '    strErrorMsg = ex.Message
            Finally
            End Try
        End Function


        Public Function GetSubjectByName(subjectstr As String) As DataTable
            Try
                objDLibrarySubject.Subject = subjectstr
                GetSubjectByName = objBCDBS.ConvertTable(objDLibrarySubject.GetSubjectByName())
                strErrorMsg = objDLibrarySubject.ErrorMsg
                intErrorCode = objDLibrarySubject.ErrorCode
                'Catch ex As Exception
                '    strErrorMsg = ex.Message
            Finally
            End Try
        End Function

    End Class
End Namespace

