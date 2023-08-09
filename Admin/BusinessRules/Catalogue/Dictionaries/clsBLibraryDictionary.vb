Imports System
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.BusinessRules.Catalogue
    Public Class clsBLibraryDictionary
        Inherits clsBBase
        Private objType As New clsDLibraryDictionary
        Private objDLibraryDictionary As New clsDLibraryDictionary
        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem

#Region "Properties"
        Private intId As Integer
        Public Property Id() As Integer
            Get
                Return intId
            End Get
            Set(ByVal value As Integer)
                intId = value
            End Set
        End Property


    


        Private strEnglishVocabulary As String
        Public Property EnglishVocabulary() As String
            Get
                Return strEnglishVocabulary
            End Get
            Set(ByVal value As String)
                strEnglishVocabulary = value
            End Set
        End Property


        Private strMean As String
        Public Property Mean() As String
            Get
                Return strMean
            End Get
            Set(ByVal value As String)
                strMean = value
            End Set
        End Property
#End Region

        Public Sub Initialize()
            'Init objDOPACComment object
            objDLibraryDictionary.DBServer = strDBServer
            objDLibraryDictionary.ConnectionString = strConnectionString
            objDLibraryDictionary.Initialize()

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
                objDLibraryDictionary.EnglishVocabulary = strEnglishVocabulary
                objDLibraryDictionary.Mean = StrMean
                Create = objDLibraryDictionary.Create()
            Catch ex As Exception
                'Return error if sub create not succeed
                strErrorMsg = objDLibraryDictionary.ErrorMsg
                intErrorCode = objDLibraryDictionary.id
            End Try
        End Function

        Public Function Update() As Integer
            Try
                objDLibraryDictionary.Id = intId
                objDLibraryDictionary.EnglishVocabulary = strEnglishVocabulary
                objDLibraryDictionary.Mean = strMean
                Update = objDLibraryDictionary.Update()
            Catch ex As Exception
                'Return error if sub create not succeed
                strErrorMsg = objDLibraryDictionary.ErrorMsg
                intErrorCode = objDLibraryDictionary.id
            End Try
        End Function

        Public Function Delete() As Integer
            Try
                objDLibraryDictionary.Id = intId
                Delete = objDLibraryDictionary.Delete()
            Catch ex As Exception
                'Return error if sub create not succeed
                strErrorMsg = objDLibraryDictionary.ErrorMsg
                intErrorCode = objDLibraryDictionary.Id
            End Try
        End Function

        Public Function GetAllVocabulary() As DataTable
            Try
                objDLibraryDictionary.EnglishVocabulary = strEnglishVocabulary
                GetAllVocabulary = objBCDBS.ConvertTable(objDLibraryDictionary.GetAllVocabulary())
                strErrorMsg = objDLibraryDictionary.ErrorMsg
                intErrorCode = objDLibraryDictionary.ErrorCode
                'Catch ex As Exception
                '    strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        Public Function GetMeanVocabulary(englishVocabularyStr As String) As DataTable
            Try
                objDLibraryDictionary.EnglishVocabulary = strEnglishVocabulary
                GetMeanVocabulary = objBCDBS.ConvertTable(objDLibraryDictionary.GetMeanVocabulary())
                strErrorMsg = objDLibraryDictionary.ErrorMsg
                intErrorCode = objDLibraryDictionary.ErrorCode
                'Catch ex As Exception
                '    strErrorMsg = ex.Message
            Finally
            End Try
        End Function

    End Class
End Namespace

