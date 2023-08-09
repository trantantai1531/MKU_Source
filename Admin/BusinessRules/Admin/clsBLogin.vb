Imports eMicLibAdmin.BusinessRules.Admin
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Admin

Namespace eMicLibAdmin.BusinessRules.Admin
    Public Class clsBLogin
        Inherits clsBBase
        Private strUserName As String
        Private strPassWord As String
        Private strOldPassWord As String

        Dim objDLogin As New ClsDLogin

        ' UserName property
        Public Property UserName() As String
            Get
                Return strUserName
            End Get
            Set(ByVal Value As String)
                strUserName = Value
            End Set
        End Property

        ' PassWord property
        Public Property PassWord() As String
            Get
                Return strPassWord
            End Get
            Set(ByVal Value As String)
                strPassWord = Value
            End Set
        End Property

        ' PassWord property
        Public Property OldPassWord() As String
            Get
                Return strOldPassWord
            End Get
            Set(ByVal Value As String)
                strOldPassWord = Value
            End Set
        End Property

        ' Initialize method
        ' Purpose: Init all necessary objects
        Public Sub Initialize()
            ' Init objBCDBS object
            objDLogin.DBServer = strDBServer
            objDLogin.ConnectionString = strConnectionString
            objDLogin.Initialize()
        End Sub

        ' UpdatePassUser method
        ' Purpose: Update Login database
        Public Sub UpdatePassUser()
            objDLogin.UserName = strUserName
            objDLogin.OldPassWord = strOldPassWord
            objDLogin.PassWord = strPassWord
            Call objDLogin.UpdatePassUser()
        End Sub

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objDLogin Is Nothing Then
                    objDLogin.Dispose(True)
                    objDLogin = Nothing
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace

