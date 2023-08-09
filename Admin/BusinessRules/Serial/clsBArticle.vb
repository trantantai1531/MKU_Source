' Class: clsBArticle
' Purpose: Management Article of issues
' Creator: Oanhtn
' Created Date: 20/09/2004
' Modification History:

Imports System
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Serial

Namespace eMicLibAdmin.BusinessRules.Serial
    Public Class clsBArticle
        Inherits clsBBase

        ' *******************************************************************************************************
        ' Declare Private variables
        ' *******************************************************************************************************

        Private intItemID As Integer = 0
        Private lngIssueID As Long = 0
        Private strTitle As String = ""
        Private strAuthor As String = ""
        Private strSubject As String = ""
        Private strPage As String = ""
        Private strNote As String = ""
        Private strName As String = ""
        Private strIssueNo As String = ""
        Private intCopyNumberID As Integer = 0
        Private intID As Integer = 0
        Private strIDs As String = ""
        Private strCreatedDate As String = ""
        Private strFileAttack As String = ""

        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        Private objDArticle As New clsDArticle

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        'FileAttack Property
        Public Property FileAttack() As String
            Get
                Return strFileAttack
            End Get
            Set(ByVal Value As String)
                strFileAttack = Value
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
        'CreateDate Property
        Public Property CreatedDate() As String
            Get
                Return strCreatedDate
            End Get
            Set(ByVal Value As String)
                strCreatedDate = Value
            End Set
        End Property
        ' Name Property
        Public Property Name() As String
            Get
                Return strName
            End Get
            Set(ByVal Value As String)
                strName = Value
            End Set
        End Property

        ' ID Property
        Public Property ID() As Integer
            Get
                Return intID
            End Get
            Set(ByVal Value As Integer)
                intID = Value
            End Set
        End Property

        ' CopyNumberID Property
        Public Property CopyNumberID() As Integer
            Get
                Return intCopyNumberID
            End Get
            Set(ByVal Value As Integer)
                intCopyNumberID = Value
            End Set
        End Property

        ' IssueNo Property
        Public Property IssueNo() As String
            Get
                Return strIssueNo
            End Get
            Set(ByVal Value As String)
                strIssueNo = Value
            End Set
        End Property

        'ItemID Property
        Public Property ItemID() As Integer
            Get
                Return intItemID
            End Get
            Set(ByVal Value As Integer)
                intItemID = Value
            End Set
        End Property

        ' IssueID Property
        Public Property IssueID() As Long
            Get
                Return lngIssueID
            End Get
            Set(ByVal Value As Long)
                lngIssueID = Value
            End Set
        End Property

        ' Title Property
        Public Property Title() As String
            Get
                Return strTitle
            End Get
            Set(ByVal Value As String)
                strTitle = Value
            End Set
        End Property

        ' Author Property
        Public Property Author() As String
            Get
                Return strAuthor
            End Get
            Set(ByVal Value As String)
                strAuthor = Value
            End Set
        End Property

        ' Subject Property
        Public Property Subject() As String
            Get
                Return strSubject
            End Get
            Set(ByVal Value As String)
                strSubject = Value
            End Set
        End Property

        ' Page Property
        Public Property Page() As String
            Get
                Return strPage
            End Get
            Set(ByVal Value As String)
                strPage = Value
            End Set
        End Property

        ' Note Property
        Public Property Note() As String
            Get
                Return strNote
            End Get
            Set(ByVal Value As String)
                strNote = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Initialize method
        Public Sub Initialize()
            ' Init objBCSP object
            objBCSP.DBServer = strDBServer
            objBCSP.ConnectionString = strConnectionString
            objBCSP.InterfaceLanguage = strInterfaceLanguage
            Call objBCSP.Initialize()

            ' Init objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            Call objBCDBS.Initialize()

            ' Init objDArticle object
            objDArticle.DBServer = strDBServer
            objDArticle.ConnectionString = strConnectionString
            Call objDArticle.Initialize()
        End Sub

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' Create method
        ' Purpose: Create new component of Article
        ' Input: some main infor of component
        ' Output: Boolean value (true when success)
        Public Function Create() As Boolean
            Try
                objDArticle.IssueID = lngIssueID
                objDArticle.Name = objBCSP.ConvertItBack(strName)
                objDArticle.Author = objBCSP.ConvertItBack(strAuthor)
                objDArticle.Page = objBCSP.ConvertItBack(strPage)
                objDArticle.Note = objBCSP.ConvertItBack(strNote)
                objDArticle.Subject = objBCSP.ConvertItBack(strSubject)
                objDArticle.CreatedDate = objBCDBS.ConvertDateBack(strCreatedDate)
                objDArticle.FileAttack = objBCDBS.ConvertDateBack(strFileAttack)
                Create = objDArticle.Create
                intErrorCode = objDArticle.ErrorCode
                strErrorMsg = objDArticle.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function
        'Insert into Subject
        'Input: txtSubject
        'Created by: Tuannv
        Public Sub AddSubject(ByVal strSubject As String)
            Try
                objDArticle.AddSubject(strSubject)
                intErrorCode = objDArticle.ErrorCode
                strErrorMsg = objDArticle.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Update method
        ' Purpose: Update information of the selected component
        ' Input: some main infor of component
        ' Output: Boolean value (true when success)
        Public Function Update() As Boolean
            Try
                objDArticle.ID = intID
                objDArticle.IssueID = lngIssueID
                objDArticle.Name = objBCSP.ConvertItBack(strName)
                objDArticle.Author = objBCSP.ConvertItBack(strAuthor)
                objDArticle.Page = objBCSP.ConvertItBack(strPage)
                objDArticle.Note = objBCSP.ConvertItBack(strNote)
                objDArticle.Subject = objBCSP.ConvertItBack(strSubject)
                objDArticle.CreatedDate = objBCDBS.ConvertDateBack(strCreatedDate)
                objDArticle.FileAttack = objBCSP.ConvertItBack(strFileAttack)
                'objDArticle.CreatedDate = objBCDBS.ConvertDateBack(strCreatedDate)
                Update = objDArticle.Update
                intErrorCode = objDArticle.ErrorCode
                strErrorMsg = objDArticle.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Delete method
        ' Purpose: delete the selected component
        ' Input: ID of component
        ' Output: Boolean value (true when success)
        Public Function Delete() As Boolean
            Try
                objDArticle.IDs = strIDs
                Delete = objDArticle.Delete
                intErrorCode = objDArticle.ErrorCode
                strErrorMsg = objDArticle.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetArticleInfor method
        ' Purpose: get infor of the current Article
        ' Input: IssueID
        ' Output: datatable result
        Public Function GetArticleInfor() As DataTable
            Try
                objDArticle.IssueID = lngIssueID
                GetArticleInfor = objBCDBS.ConvertTable(objDArticle.GetArticleInfor)
                intErrorCode = objDArticle.ErrorCode
                strErrorMsg = objDArticle.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCSP Is Nothing Then
                    Call objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    Call objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objDArticle Is Nothing Then
                    objDArticle.Dispose(True)
                    objDArticle = Nothing
                End If
            Finally
                Call MyBase.Dispose()
                Call Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace