' clsBAuthority class
' Purpose: process authority data
' Creator: Oanhtn
' Created Date: 20/05/2004
' Modification history:

Imports System
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Catalogue

Namespace eMicLibAdmin.BusinessRules.Catalogue
    Public Class clsBAuthority
        Inherits clsBBase

        ' *****************************************************************************************************
        ' Declare Private variables
        ' *****************************************************************************************************

        Private lngID As Long = 0
        Private intFormID As Integer = 0
        Private strLeader As String = ""
        Private lngReferenceID As Long = 0
        Private intSourceID As Integer = 0
        Private intStatus As Integer = 0
        Private strCode As String = ""
        Private strDisplayEntry As String = ""
        Private strAccessEntry As String = ""
        Private strCataloguer As String = ""
        Private strReviewer As String = ""
        Private strCreatedDate As String = ""
        Private strLastModifiedDate As String = ""
        Private strAuthorityIDs As String = ""

        Private objDAuthority As New clsDAuthority
        Private objBCDBS As New clsBCommonDBSystem
        Private objBCSP As New clsBCommonStringProc

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' ID property
        Public Property ID() As Long
            Get
                Return lngID
            End Get
            Set(ByVal Value As Long)
                lngID = Value
            End Set
        End Property

        ' FormID property
        Public Property FormID() As Integer
            Get
                Return intFormID
            End Get
            Set(ByVal Value As Integer)
                intFormID = Value
            End Set
        End Property

        ' Leader property
        Public Property Leader() As String
            Get
                Return strLeader
            End Get
            Set(ByVal Value As String)
                strLeader = Value
            End Set
        End Property

        ' ReferenceID property
        Public Property ReferenceID() As Long
            Get
                Return lngReferenceID
            End Get
            Set(ByVal Value As Long)
                lngReferenceID = Value
            End Set
        End Property

        ' SourceID property
        Public Property SourceID() As Integer
            Get
                Return intSourceID
            End Get
            Set(ByVal Value As Integer)
                intSourceID = Value
            End Set
        End Property

        ' Status property
        Public Property Status() As Integer
            Get
                Return intStatus
            End Get
            Set(ByVal Value As Integer)
                intStatus = Value
            End Set
        End Property

        ' Code property
        Public Property Code() As String
            Get
                Return strCode
            End Get
            Set(ByVal Value As String)
                strCode = Value
            End Set
        End Property

        ' DisplayEntry property
        Public Property DisplayEntry() As String
            Get
                Return strDisplayEntry
            End Get
            Set(ByVal Value As String)
                strDisplayEntry = Value
            End Set
        End Property

        ' AccessEntry property
        Public Property AccessEntry() As String
            Get
                Return strAccessEntry
            End Get
            Set(ByVal Value As String)
                strAccessEntry = Value
            End Set
        End Property

        ' Cataloguer property
        Public Property Cataloguer() As String
            Get
                Return strCataloguer
            End Get
            Set(ByVal Value As String)
                strCataloguer = Value
            End Set
        End Property

        ' Reviewer property
        Public Property Reviewer() As String
            Get
                Return strReviewer
            End Get
            Set(ByVal Value As String)
                strReviewer = Value
            End Set
        End Property

        ' CreatedDate property
        Public Property CreatedDate() As String
            Get
                Return strCreatedDate
            End Get
            Set(ByVal Value As String)
                strCreatedDate = Value
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

        ' AuthorityIDs property
        Public Property AuthorityIDs() As String
            Get
                Return strAuthorityIDs
            End Get
            Set(ByVal Value As String)
                strAuthorityIDs = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Initialize method
        ' Purpose: Init all necessary objects
        Public Sub Initialize()
            Try
                ' Init objDAuthority
                objDAuthority.DBServer = strDBserver
                objDAuthority.ConnectionString = strConnectionString
                Call objDAuthority.Initialize()

                ' Init objBCDBS
                objBCDBS.DBServer = strDBServer
                objBCDBS.InterfaceLanguage = strInterfaceLanguage
                objBCDBS.ConnectionString = strConnectionString
                Call objBCDBS.Initialize()

                ' Init objBCSP
                objBCSP.DBServer = strDBServer
                objBCSP.InterfaceLanguage = strInterfaceLanguage
                objBCSP.ConnectionString = strConnectionString
                Call objBCSP.Initialize()
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        ' GetProperties method
        ' Purpose: Get all properties of the selected field
        Public Function GetAuthority() As DataTable
            Try
                objDAuthority.AuthorityIDs = Trim(strAuthorityIDs)
                objDAuthority.AccessEntry = objBCSP.ProcessVal(objBCSP.ConvertItBack(objBCSP.GEntryTrim(strAccessEntry)))
                objDAuthority.ReferenceID = lngReferenceID
                GetAuthority = objBCDBS.ConvertTable(objDAuthority.GetAuthority())
                intErrorCode = objDAuthority.ErrorCode
                strErrorMsg = objDAuthority.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objDAuthority Is Nothing Then
                    objDAuthority.Dispose(True)
                    objDAuthority = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
            Finally
                Me.Dispose()
                MyBase.Dispose()
            End Try
        End Sub
    End Class
End Namespace