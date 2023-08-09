' Name: clsDTemplate
' Purpose: allow working with Template
' Creator: Oanhtn
' CreatedDate: 16/08/2004
' Modification History:
'   +20/8/2004: by Sondp

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType
Imports eMicLibAdmin.DataAccess.Common

Namespace eMicLibAdmin.DataAccess.Circulation
    Public Class clsDOverdueTemplate
        Inherits clsDBase

        ' *****************************************************************************************************
        ' Declare member variables
        ' *****************************************************************************************************

        Private strCreator As String = ""
        Private strModifier As String = ""
        Private strLastModifiedDate As String = ""
        Private intTemplateID As Integer = 0
        Private intTemplateType As Integer = 0
        Private strName As String = ""
        Private strContent As String = ""
        Private strHeader As String = ""
        Private strFooter As String = ""
        Private colHeaderData As New Collection
        Private colContentData As New Collection
        Private colFooterData As New Collection
        Private objDCommonTemplate As New clsDCommonTemplate

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' Creator property
        Public Property Creator() As String
            Get
                Return strCreator
            End Get
            Set(ByVal Value As String)
                strCreator = Value
            End Set
        End Property

        ' LastModifiedDate property
        Public Property LastModifiedDate() As String
            Get
                Return strLastModifiedDate
            End Get
            Set(ByVal Value As String)
                strLastModifiedDate = Value
            End Set
        End Property

        ' TemplateID property
        Public Property TemplateID() As Integer
            Get
                Return intTemplateID
            End Get
            Set(ByVal Value As Integer)
                intTemplateID = Value
            End Set
        End Property

        'Template Type
        Public Property TemplateType() As Integer
            Get
                Return intTemplateType
            End Get
            Set(ByVal Value As Integer)
                intTemplateType = Value
            End Set
        End Property

        ' Name property
        Public Property Name() As String
            Get
                Return strName
            End Get
            Set(ByVal Value As String)
                strName = Value
            End Set
        End Property

        ' Content property
        Public Property Content() As String
            Get
                Return strContent
            End Get
            Set(ByVal Value As String)
                strContent = Value
            End Set
        End Property

        ' Header property
        Public Property Header() As String
            Get
                Return strHeader
            End Get
            Set(ByVal Value As String)
                strHeader = Value
            End Set
        End Property

        ' Footer property
        Public Property Footer() As String
            Get
                Return strFooter
            End Get
            Set(ByVal Value As String)
                strFooter = Value
            End Set
        End Property

        ' HeaderData property
        Property HeaderData() As Collection
            Get
                Return colHeaderData
            End Get
            Set(ByVal Value As Collection)
                colHeaderData = Value
            End Set
        End Property

        ' ContentData property
        Property ContentData() As Collection
            Get
                Return colContentData
            End Get
            Set(ByVal Value As Collection)
                colContentData = Value
            End Set
        End Property

        ' FooterData property
        Property FooterData() As Collection
            Get
                Return colFooterData
            End Get
            Set(ByVal Value As Collection)
                colFooterData = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Init objDCommonTemplate
        Public Sub Initial()
            'Init objDCommonTemplate object
            objDCommonTemplate.ConnectionString = strConnectionstring
            objDCommonTemplate.DBServer = strDBServer
            objDCommonTemplate.Initialize()
        End Sub

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not objDCommonTemplate Is Nothing Then
                        objDCommonTemplate.Dispose(True)
                        objDCommonTemplate = Nothing
                    End If
                    If Not oraConnection Is Nothing Then
                        oraConnection.Dispose()
                        oraConnection = Nothing
                    End If
                    If Not oraCommand Is Nothing Then
                        oraCommand.Dispose()
                        oraCommand = Nothing
                    End If
                    If Not oraDataAdapter Is Nothing Then
                        oraDataAdapter.Dispose()
                        oraDataAdapter = Nothing
                    End If
                    If Not SqlConnection Is Nothing Then
                        SqlConnection.Dispose()
                        SqlConnection = Nothing
                    End If
                    If Not SqlCommand Is Nothing Then
                        SqlCommand.Dispose()
                        SqlCommand = Nothing
                    End If
                    If Not SqlDataAdapter Is Nothing Then
                        SqlDataAdapter.Dispose()
                        SqlDataAdapter = Nothing
                    End If
                    If Not dsData Is Nothing Then
                        dsData.Dispose()
                        dsData = Nothing
                    End If
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Dispose()
            End Try
        End Sub
    End Class
End Namespace