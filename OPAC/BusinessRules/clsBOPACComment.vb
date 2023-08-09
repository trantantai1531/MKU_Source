Imports System
Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibOPAC.DataAccess.OPAC

Namespace eMicLibOPAC.BusinessRules.OPAC
    Public Class clsBOPACComment
        Inherits clsBBase
        '***************************************************************************************************
        '                                 DECLARE PRIVATE VARIABLES
        '***************************************************************************************************
        Private strCardNo As String
        Private strPassword As String
        Private strContent As String
        Private intRanking As Integer
        Private strSubject As String
        Private strComment As String
        Private lngItemID As Long
        Private strCode As String

        Private objDOPACComment As New clsDOPACComment
        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem

        '***************************************************************************************************
        '                              END DECLARE PRIVATE VARIABLES
        '                               DECLARE PRIVATE PROPARTIES
        '***************************************************************************************************

        'ItemID Property
        Public Property ItemID() As Long
            Get
                Return lngItemID
            End Get
            Set(ByVal Value As Long)
                lngItemID = Value
            End Set
        End Property


        'Code Property
        Public Property Code() As String
            Get
                Return strCode
            End Get
            Set(ByVal Value As String)
                strCode = Value
            End Set
        End Property

        'Comment Property
        Public Property Comment() As String
            Get
                Return strComment
            End Get
            Set(ByVal Value As String)
                strComment = Value
            End Set
        End Property

        'CardNo Property
        Public Property CardNo() As String
            Get
                Return strCardNo
            End Get
            Set(ByVal Value As String)
                strCardNo = Value
            End Set
        End Property

        'Password Property
        Public Property Password() As String
            Get
                Return strPassword
            End Get
            Set(ByVal Value As String)
                strPassword = Value
            End Set
        End Property

        'Content Property
        Public Property Content() As String
            Get
                Return strContent
            End Get
            Set(ByVal Value As String)
                strContent = Value
            End Set
        End Property

        'Ranking Property
        Public Property Ranking() As Integer
            Get
                Return intRanking
            End Get
            Set(ByVal Value As Integer)
                intRanking = Value
            End Set
        End Property

        'Subject Property
        Public Property Subject()
            Get
                Return strSubject
            End Get
            Set(ByVal Value)
                strSubject = Value
            End Set
        End Property

        '***************************************************************************************************
        '                                         END DECLARE PROPERTIES
        '                                         IMPLEMENT METHODS HERE
        '***************************************************************************************************

        'Initialize method
        Public Sub Initialize()
            'Init objDOPACComment object
            objDOPACComment.DBServer = strDBServer
            objDOPACComment.ConnectionString = strConnectionString
            objDOPACComment.Initialize()

            'Init objBCSP object
            objBCSP.DBServer = strDBServer
            objBCSP.ConnectionString = strConnectionString
            objBCSP.InterfaceLanguage = strInterfaceLanguage
            objBCSP.Initialize()

            'Init objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.Initialize()
        End Sub

        Public Function Create(ByVal intSelect As Integer) As Integer
            Try
                objDOPACComment.Comment = strComment
                objDOPACComment.Subject = strSubject
                objDOPACComment.Ranking = intRanking
                objDOPACComment.ItemID = lngItemID
                objDOPACComment.Code = strCode
                Create = objDOPACComment.Create(intSelect)
            Catch ex As Exception
                'Return error if sub create not succeed
                strErrorMsg = objDOPACComment.ErrorMsg
                intErrorCode = objDOPACComment.Code
            End Try
        End Function

        Public Function Update(ByVal intSelect As Integer, ByVal intCo_ID As Integer) As Integer
            Try
                objDOPACComment.Comment = strComment
                objDOPACComment.Subject = strSubject
                objDOPACComment.Ranking = intRanking
                objDOPACComment.ItemID = lngItemID
                objDOPACComment.Code = strCode
                objDOPACComment.Password = strPassword
                Update = objDOPACComment.Update(intSelect, intCo_ID)
            Catch ex As Exception
                'Return error if sub update not succeed
                strErrorMsg = objDOPACComment.ErrorMsg
                intErrorCode = objDOPACComment.Code
            End Try
        End Function

        'Delete method
        'Purpose: Delete 
        'Input: some main infor: ID, ..., intCo_ID is ID of record comment
        'Output: 0 if fail, else is CurrentID
        Public Function Delete(ByVal intCo_ID As Integer) As Integer
            Try
                Delete = objDOPACComment.Delete(intCo_ID)
            Catch ex As Exception
                'Return error if sub delete not succeed
                strErrorMsg = objDOPACComment.ErrorMsg
                intErrorCode = objDOPACComment.Code
            End Try
        End Function

        'Dispose method
        'Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                End If
                If Not objDOPACComment Is Nothing Then
                    Call objDOPACComment.Dispose(True)
                    objDOPACComment = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    Call objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    Call objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Dispose()
            End Try
        End Sub
    End Class
End Namespace