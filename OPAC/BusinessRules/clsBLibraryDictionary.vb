Imports System
Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibOPAC.DataAccess.OPAC
Namespace eMicLibOPAC.BusinessRules.OPAC
    Public Class clsBLibraryDictionary
        Inherits clsBBase
        Private objType As New clsDLibraryDictionary
        Private objDLibraryDictionary As New clsDLibraryDictionary
        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem

#Region "Properties"
         Private idStr As String
        Public Property id() As String
            Get
                Return idStr
            End Get
            Set(ByVal value As String)
                idStr = value
            End Set
        End Property

        Private searchTypeInt As Integer
        Public Property SearchType() As Integer
            Get
                Return searchTypeInt
            End Get
            Set(ByVal value As Integer)
                searchTypeInt = value
            End Set
        End Property


        Private EnglishVocabularyStr As String
        Public Property EnglishVocabulary() As String
            Get
                Return EnglishVocabularyStr
            End Get
            Set(ByVal value As String)
                EnglishVocabularyStr = value
            End Set
        End Property


        Private MeanStr As String
        Public Property Mean() As String
            Get
                Return MeanStr
            End Get
            Set(ByVal value As String)
                Mean = value
            End Set
        End Property
#End Region

        Public Sub Initialize()
            'Init objDOPACComment object
            objDLibraryDictionary.DBServer = strDBServer
            objDLibraryDictionary.ConnectionString = strConnectionString
            objDLibraryDictionary.Initialize()


            ' Init objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.ConnectionString = strConnectionString
            Call objBCDBS.Initialize()

            ' Init objBCSP object
            objBCSP.DBServer = strDBServer
            objBCSP.InterfaceLanguage = strInterfaceLanguage
            objBCSP.ConnectionString = strConnectionString
            Call objBCSP.Initialize()

        End Sub

        Public Function Create() As Integer
            Try
                objDLibraryDictionary.EnglishVocabulary = EnglishVocabulary
                objDLibraryDictionary.Mean = Mean
                Create = objType.Create()
            Catch ex As Exception
                'Return error if sub create not succeed
                strErrorMsg = objType.ErrorMsg
                intErrorCode = objType.id
            End Try
        End Function

        Public Function GetVocabulary(englishVocabularyStr As String) As DataTable
            Try
                objDLibraryDictionary.EnglishVocabulary = englishVocabularyStr
                objDLibraryDictionary.SearchType = searchTypeInt
                GetVocabulary = objBCDBS.ConvertTable(objDLibraryDictionary.GetVocabulary())
                strErrorMsg = objDLibraryDictionary.ErrorMsg
                intErrorCode = objDLibraryDictionary.ErrorCode
                'Catch ex As Exception
                '    strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        Public Function GetMeanVocabulary(englishVocabularyStr As String) As DataTable
            Try
                objDLibraryDictionary.EnglishVocabulary = englishVocabularyStr
                objDLibraryDictionary.SearchType = searchTypeInt
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

