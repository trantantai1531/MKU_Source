Imports System
Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibOPAC.DataAccess.OPAC

Namespace eMicLibOPAC.BusinessRules.OPAC
    Public Class clsBOPACUser
        'Inherits clsBBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private strUsername As String
        Private strPassword As String
        Private strEmail As String
        Private strpublicKey As String
        
        ' WorkPlace property
        Public Property Username() As String
            Get
                Return strUsername
            End Get
            Set(ByVal Value As String)
                strUsername = Value
            End Set
        End Property
        ' Education property
        Public Property Password() As String
            Get
                Return strPassword
            End Get
            Set(ByVal Value As String)
                strPassword = Value
            End Set
        End Property
        ' FirstName property
        Public Property Email() As String
            Get
                Return strEmail
            End Get
            Set(ByVal Value As String)
                strEmail = Value
            End Set
        End Property
        ' FirstName property
        Public Property publicKey() As String
            Get
                Return strpublicKey
            End Get
            Set(ByVal Value As String)
                strpublicKey = Value
            End Set
        End Property
    End Class
End Namespace