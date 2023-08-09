Imports System
Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibOPAC.DataAccess.OPAC

Namespace eMicLibOPAC.BusinessRules.OPAC
    Public Class clsBOPACRequestCataloguer
        Inherits clsBBase

        Private strFullName As String
        Private strPatronCode As String
        Private strEmail As String
        Private strPhone As String
        Private strFacebook As String
        Private strSupplier As String
        Private strGroupName As String
        Private strTitle As String
        Private strAuthor As String
        Private strPublisher As String
        Private strPublishYear As String
        Private strInformation As String

        Private objDOpacRequestCataloguer As New clsDOpacRequestCataloguer

        Public Property FullName() As String
            Get
                Return strFullName
            End Get
            Set(ByVal Value As String)
                strFullName = Value
            End Set
        End Property

        Public Property PatronCode() As String
            Get
                Return strPatronCode
            End Get
            Set(ByVal Value As String)
                strPatronCode = Value
            End Set
        End Property

        Public Property Email() As String
            Get
                Return strEmail
            End Get
            Set(ByVal Value As String)
                strEmail = Value
            End Set
        End Property

        Public Property Phone() As String
            Get
                Return strPhone
            End Get
            Set(ByVal Value As String)
                strPhone = Value
            End Set
        End Property

        Public Property Facebook() As String
            Get
                Return strFacebook
            End Get
            Set(ByVal Value As String)
                strFacebook = Value
            End Set
        End Property

        Public Property Supplier() As String
            Get
                Return strSupplier
            End Get
            Set(ByVal Value As String)
                strSupplier = Value
            End Set
        End Property

        Public Property GroupName() As String
            Get
                Return strGroupName
            End Get
            Set(ByVal Value As String)
                strGroupName = Value
            End Set
        End Property

        Public Property Title() As String
            Get
                Return strTitle
            End Get
            Set(ByVal Value As String)
                strTitle = Value
            End Set
        End Property

        Public Property Author() As String
            Get
                Return strAuthor
            End Get
            Set(ByVal Value As String)
                strAuthor = Value
            End Set
        End Property

        Public Property Publisher() As String
            Get
                Return strPublisher
            End Get
            Set(ByVal Value As String)
                strPublisher = Value
            End Set
        End Property

        Public Property PublishYear() As String
            Get
                Return strPublishYear
            End Get
            Set(ByVal Value As String)
                strPublishYear = Value
            End Set
        End Property

        Public Property Information() As String
            Get
                Return strInformation
            End Get
            Set(ByVal Value As String)
                strInformation = Value
            End Set
        End Property


        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************
        ' Initialize method
        Public Sub Initialize()
            ' Init objDOpacRequestCataloguer object
            objDOpacRequestCataloguer.DBServer = strDBServer
            objDOpacRequestCataloguer.ConnectionString = strConnectionString
            objDOpacRequestCataloguer.Initialize()
        End Sub

        Public Function Insert() As Integer
            Try
                objDOpacRequestCataloguer.FullName = strFullName
                objDOpacRequestCataloguer.PatronCode = strPatronCode
                objDOpacRequestCataloguer.Email = strEmail
                objDOpacRequestCataloguer.Phone = strPhone
                objDOpacRequestCataloguer.Facebook = strFacebook
                objDOpacRequestCataloguer.Supplier = strSupplier
                objDOpacRequestCataloguer.GroupName = strGroupName
                objDOpacRequestCataloguer.Title = strTitle
                objDOpacRequestCataloguer.Author = strAuthor
                objDOpacRequestCataloguer.Publisher = strPublisher
                objDOpacRequestCataloguer.PublishYear = strPublishYear
                objDOpacRequestCataloguer.Information = strInformation
                Insert = objDOpacRequestCataloguer.Insert()
                strErrorMsg = objDOpacRequestCataloguer.ErrorMsg
                intErrorCode = objDOpacRequestCataloguer.ErrorCode
            Catch ex As Exception
                Insert = 0
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                End If
                If Not objDOpacRequestCataloguer Is Nothing Then
                    Call objDOpacRequestCataloguer.Dispose(True)
                    objDOpacRequestCataloguer = Nothing
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Dispose()
            End Try
        End Sub
    End Class
End Namespace

