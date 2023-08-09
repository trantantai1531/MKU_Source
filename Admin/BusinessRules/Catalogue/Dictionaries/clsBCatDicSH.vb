Imports eMicLibAdmin.DataAccess.Catalogue
Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue
Namespace eMicLibAdmin.BusinessRules.Catalogue
    Public Class clsBCatDicSH
        Inherits clsBBase

        Private objDCatDicSH As New clsDCatDicSH

        Private intID As Integer
        Private strDisplayEntry As String
        Private strAccessEntry As String
        Private intParentID As Integer
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
        Public Property ParentID() As Integer
            Get
                Return intParentID
            End Get
            Set(ByVal Value As Integer)
                intParentID = Value
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
        Public Function Update() As Integer
            Try
                objDCatDicSH.ID = intID
                objDCatDicSH.AccessEntry = strAccessEntry
                objDCatDicSH.DicItemID = intDicItemID
                objDCatDicSH.DisplayEntry = strDisplayEntry
                objDCatDicSH.VietnameseAccent = strVietnameseAccent

                Dim result As Integer = objDCatDicSH.Update()
                strErrorMsg = objDCatDicSH.ErrorMsg
                intErrorCode = objDCatDicSH.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDCatDicSH.ErrorMsg
                intErrorCode = objDCatDicSH.ErrorCode
                Return -1
            End Try
        End Function
        Public Function GetAll(Optional ByVal strSearch As String = "") As DataTable
            Try
                Dim result As DataTable = objDCatDicSH.GetAll(strSearch)
                strErrorMsg = objDCatDicSH.ErrorMsg
                intErrorCode = objDCatDicSH.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDCatDicSH.ErrorMsg
                intErrorCode = objDCatDicSH.ErrorCode
                Return New DataTable
            End Try
        End Function
        Public Function GetAllSHBibliography() As DataTable
            Try
                Dim result As DataTable = objDCatDicSH.GetAllSHBibliography()
                strErrorMsg = objDCatDicSH.ErrorMsg
                intErrorCode = objDCatDicSH.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDCatDicSH.ErrorMsg
                intErrorCode = objDCatDicSH.ErrorCode
                Return New DataTable
            End Try
        End Function

        Public Function InsertSHBibliography(ByVal intSHID As Integer) As Integer
            Try
                Dim result As Integer = objDCatDicSH.InsertSHBibliography(intSHID)
                strErrorMsg = objDCatDicSH.ErrorMsg
                intErrorCode = objDCatDicSH.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDCatDicSH.ErrorMsg
                intErrorCode = objDCatDicSH.ErrorCode
                Return -1
            End Try
        End Function

        Public Function DeleteSHBibliography(ByVal intSHID As Integer) As Integer
            Try
                Dim result As Integer = objDCatDicSH.DeleteSHBibliography(intSHID)
                strErrorMsg = objDCatDicSH.ErrorMsg
                intErrorCode = objDCatDicSH.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDCatDicSH.ErrorMsg
                intErrorCode = objDCatDicSH.ErrorCode
                Return -1
            End Try
        End Function
        Public Sub Initialize()
            Try
                objDCatDicSH.ConnectionString = strConnectionString
                objDCatDicSH.DBServer = strDBServer
                Call objDCatDicSH.Initialize()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            If isDisposing Then
                If Not objDCatDicSH Is Nothing Then
                    objDCatDicSH.Dispose(True)
                    objDCatDicSH = Nothing
                End If
            End If
            MyBase.Dispose()
            Me.Dispose()
        End Sub
    End Class
End Namespace

