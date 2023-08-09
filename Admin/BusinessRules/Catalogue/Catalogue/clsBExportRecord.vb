Imports System
Imports eMicLibAdmin.DataAccess.Catalogue
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.BusinessRules.Catalogue
    Public Class clsBExportRecord
        Inherits clsBBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************

        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        Private objDER As New clsDExportRecord

        Private intID As Integer
        Private intCount As Integer
        Private strTerm As String
        Private intReferenceID As Integer
        Private intSourceID As Integer
        Private strCataFrom As String
        Private strCataTo As String
        Private intFromID As Integer
        Private intToID As Integer
        Private strAccessEntry As String

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' AccessEntry property
        Public Property AccessEntry() As String
            Get
                AccessEntry = strAccessEntry
            End Get
            Set(ByVal Value As String)
                strAccessEntry = Value
            End Set
        End Property

        ' Term property
        Public Property Term() As String
            Get
                Term = strTerm
            End Get
            Set(ByVal Value As String)
                strTerm = Value
            End Set
        End Property

        ' ReferenceID property
        Public Property ReferenceID() As Integer
            Get
                ReferenceID = intReferenceID
            End Get
            Set(ByVal Value As Integer)
                intReferenceID = Value
            End Set
        End Property

        ' SourceID property
        Public Property SourceID() As Integer
            Get
                SourceID = intSourceID
            End Get
            Set(ByVal Value As Integer)
                intSourceID = Value
            End Set
        End Property

        ' CataFrom property
        Public Property CataFrom() As String
            Get
                CataFrom = strCataFrom
            End Get
            Set(ByVal Value As String)
                strCataFrom = Value
            End Set
        End Property

        ' CataTo property
        Public Property CataTo() As String
            Get
                CataTo = strCataTo
            End Get
            Set(ByVal Value As String)
                strCataTo = Value
            End Set
        End Property

        ' FromID property
        Public Property FromID() As Integer
            Get
                FromID = intFromID
            End Get
            Set(ByVal Value As Integer)
                intFromID = Value
            End Set
        End Property

        ' ToID property
        Public Property ToID() As Integer
            Get
                ToID = intToID
            End Get
            Set(ByVal Value As Integer)
                intToID = Value
            End Set
        End Property

        ' ID Property
        Public Property ID() As Integer
            Get
                ID = intID
            End Get
            Set(ByVal Value As Integer)
                intID = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Initialize method
        ' Purpose: init all neccessary objects
        Public Sub Initialize()
            Try
                ' Init objBCSP object
                objBCSP.DBServer = strDBServer
                objBCSP.InterfaceLanguage = strInterfaceLanguage
                objBCSP.ConnectionString = strConnectionString
                objBCSP.Initialize()

                ' Init objBCDBS object
                objBCDBS.DBServer = strDBServer
                objBCDBS.InterfaceLanguage = strInterfaceLanguage
                objBCDBS.ConnectionString = strConnectionString
                objBCDBS.Initialize()

                ' Init objDER object
                objDER.DBServer = strDBServer
                objDER.ConnectionString = strConnectionString
                objDER.Initialize()
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        ' GetAuthorityMainInfor
        ' Purpose: Get main authority data
        ' Input: somecondition
        ' Ouput: datatable result
        Public Function GetAuthorityMainInfor() As DataTable
            Try
                objDER.Term = objBCSP.ProcessVal(objBCSP.ConvertItBack(strTerm))
                objDER.ReferenceID = intReferenceID
                objDER.SourceID = intSourceID
                objDER.CataFrom = objBCDBS.ConvertDateBack(Trim(strCataFrom))
                objDER.CataTo = objBCDBS.ConvertDateBack(Trim(strCataTo))
                objDER.FromID = intFromID
                objDER.ToID = intToID
                GetAuthorityMainInfor = objBCDBS.ConvertTable(objDER.GetAuthorityMainInfor)
                strErrorMsg = objDER.ErrorMsg
                intErrorCode = objDER.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' Method: GetAuthorityDetailInfor
        ' Purpose: Get detail (field) information of authority data
        ' Input: some conditions
        ' Ouput: datatable result
        Public Function GetAuthorityDetailInfor() As DataTable
            Try
                objDER.Term = objBCSP.ProcessVal(objBCSP.ConvertItBack(strTerm))
                objDER.ReferenceID = intReferenceID
                objDER.SourceID = intSourceID
                objDER.CataFrom = objBCDBS.ConvertDateBack(Trim(strCataFrom))
                objDER.CataTo = objBCDBS.ConvertDateBack(Trim(strCataTo))
                objDER.FromID = intFromID
                objDER.ToID = intToID
                GetAuthorityDetailInfor = objBCDBS.ConvertTable(objDER.GetAuthorityDetailInfor)
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' GetSourceAuthority method
        ' Purpose: Get AuthoritySource
        ' Output: result datatable
        Public Function GetSourceAuthority() As DataTable
            Try
                GetSourceAuthority = objBCDBS.ConvertTable(objDER.GetSourceAuthority)
                strErrorMsg = objDER.ErrorMsg
                intErrorCode = objDER.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' GetClassficationData
        ' Purpose: Get classification data to export
        ' Input: some conditions
        ' Ouput: datatable redult
        Public Function GetClassficationData() As DataTable
            Try
                objDER.AccessEntry = objBCSP.ProcessVal(objBCSP.ConvertItBack(strAccessEntry))
                objDER.FromID = intFromID
                objDER.ToID = intToID
                GetClassficationData = objBCDBS.ConvertTable(objDER.GetClassficationData)
                strErrorMsg = objDER.ErrorMsg
                intErrorCode = objDER.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' *************************************************************************************************
        ' Dispose method
        ' Purpose: Release all resource
        ' *************************************************************************************************
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objDER Is Nothing Then
                    objDER.Dispose(True)
                    objDER = Nothing
                End If
            Finally
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace