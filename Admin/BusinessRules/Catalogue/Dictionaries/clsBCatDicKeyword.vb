Imports eMicLibAdmin.DataAccess.Catalogue
Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue
Namespace eMicLibAdmin.BusinessRules.Catalogue
    Public Class clsBCatDicKeyword
        Inherits clsBBase

        Private objDCatDicKeyword As New clsDCatDicKeyword

        Private intID As Integer
        Private strDisplayEntry As String
        Private strAccessEntry As String
        Private intDicItemID As Integer
        Private strVietnameseAccent As String

        Public Property ID() As Integer
            Get
                Return intID
            End Get
            Set(ByVal Value As Integer)
                intID = Value
            End Set
        End Property

        Public Property DicItemID() As Integer
            Get
                Return intDicItemID
            End Get
            Set(ByVal Value As Integer)
                intDicItemID = Value
            End Set
        End Property

        Public Property DisplayEntry() As String
            Get
                Return strDisplayEntry
            End Get
            Set(ByVal Value As String)
                strDisplayEntry = Value
            End Set
        End Property

        Public Property AccessEntry() As String
            Get
                Return strAccessEntry
            End Get
            Set(ByVal Value As String)
                strAccessEntry = Value
            End Set
        End Property

        Public Property VietnameseAccent() As String
            Get
                Return strVietnameseAccent
            End Get
            Set(ByVal Value As String)
                strVietnameseAccent = Value
            End Set
        End Property
        Public Function Insert() As Integer
            Try
                objDCatDicKeyword.AccessEntry = strAccessEntry
                objDCatDicKeyword.DicItemID = intDicItemID
                objDCatDicKeyword.DisplayEntry = strDisplayEntry
                objDCatDicKeyword.VietnameseAccent = strVietnameseAccent

                Dim result As Integer = objDCatDicKeyword.Insert()
                strErrorMsg = objDCatDicKeyword.ErrorMsg
                intErrorCode = objDCatDicKeyword.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDCatDicKeyword.ErrorMsg
                intErrorCode = objDCatDicKeyword.ErrorCode
                Return -1
            End Try
        End Function

        Public Function Update() As Integer
            Try
                objDCatDicKeyword.ID = intID
                objDCatDicKeyword.AccessEntry = strAccessEntry
                objDCatDicKeyword.DicItemID = intDicItemID
                objDCatDicKeyword.DisplayEntry = strDisplayEntry
                objDCatDicKeyword.VietnameseAccent = strVietnameseAccent

                Dim result As Integer = objDCatDicKeyword.Update()
                strErrorMsg = objDCatDicKeyword.ErrorMsg
                intErrorCode = objDCatDicKeyword.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDCatDicKeyword.ErrorMsg
                intErrorCode = objDCatDicKeyword.ErrorCode
                Return -1
            End Try
        End Function

        Public Function GetAll(Optional ByVal strSearch As String = "") As DataTable
            Try
                Dim result As DataTable = objDCatDicKeyword.GetAll(strSearch)
                strErrorMsg = objDCatDicKeyword.ErrorMsg
                intErrorCode = objDCatDicKeyword.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDCatDicKeyword.ErrorMsg
                intErrorCode = objDCatDicKeyword.ErrorCode
                Return New DataTable
            End Try
        End Function
        Public Function GetAllKeywordBibliography() As DataTable
            Try
                Dim result As DataTable = objDCatDicKeyword.GetAllKeywordBibliography()
                strErrorMsg = objDCatDicKeyword.ErrorMsg
                intErrorCode = objDCatDicKeyword.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDCatDicKeyword.ErrorMsg
                intErrorCode = objDCatDicKeyword.ErrorCode
                Return New DataTable
            End Try
        End Function
        Public Function InsertKeywordBibliography(ByVal intKeywordID As Integer) As Integer
            Try
                Dim result As Integer = objDCatDicKeyword.InsertKeywordBibliography(intKeywordID)
                strErrorMsg = objDCatDicKeyword.ErrorMsg
                intErrorCode = objDCatDicKeyword.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDCatDicKeyword.ErrorMsg
                intErrorCode = objDCatDicKeyword.ErrorCode
                Return -1
            End Try
        End Function
        Public Function DeleteKeywordBibliography(ByVal intKeywordID As Integer) As Integer
            Try
                Dim result As Integer = objDCatDicKeyword.DeleteKeywordBibliography(intKeywordID)
                strErrorMsg = objDCatDicKeyword.ErrorMsg
                intErrorCode = objDCatDicKeyword.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDCatDicKeyword.ErrorMsg
                intErrorCode = objDCatDicKeyword.ErrorCode
                Return -1
            End Try
        End Function
        Public Sub Initialize()
            Try
                objDCatDicKeyword.ConnectionString = strConnectionString
                objDCatDicKeyword.DBServer = strDBServer
                Call objDCatDicKeyword.Initialize()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            If isDisposing Then
                If Not objDCatDicKeyword Is Nothing Then
                    objDCatDicKeyword.Dispose(True)
                    objDCatDicKeyword = Nothing
                End If
            End If
            MyBase.Dispose()
            Me.Dispose()
        End Sub
    End Class
End Namespace
