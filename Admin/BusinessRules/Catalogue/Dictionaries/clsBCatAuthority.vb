Imports eMicLibAdmin.DataAccess.Catalogue
Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.BusinessRules.Catalogue
    Public Class clsBCatAuthority
        Inherits clsBBase

        ' Declare variables
        Private objDCatAuthor As New clsDCatAuthority
        Private objBString As New clsBCommonStringProc
        Private objBComDB As New clsBCommonDBSystem
        Private strIDs As String = ""
        Private strAccessEntry As String = ""

        ' AccessEntry property
        Public Property AccessEntry() As String
            Get
                Return strAccessEntry
            End Get
            Set(ByVal Value As String)
                strAccessEntry = Value
            End Set
        End Property

        ' IDs property
        Public Property IDs() As String
            Get
                Return strIDs
            End Get
            Set(ByVal Value As String)
                strIDs = Value
            End Set
        End Property

        Public Sub Initialize()
            Try
                objDCatAuthor.ConnectionString = strConnectionString
                objDCatAuthor.DBServer = strDBServer
                objDCatAuthor.Initialize()

                objBComDB.InterfaceLanguage = strInterfaceLanguage
                objBComDB.DBServer = strDBServer
                objBComDB.ConnectionString = strConnectionString
                objBComDB.Initialize()

                objBString.InterfaceLanguage = strInterfaceLanguage
                objBString.DBServer = strDBServer
                objBString.ConnectionString = strConnectionString
                objBString.Initialize()
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        ' Retrieve method
        Public Function Retrieve() As DataTable
            Try
                objDCatAuthor.IDs = strIDs
                objDCatAuthor.AccessEntry = strAccessEntry
                Return objBComDB.ConvertTable(objDCatAuthor.Retrieve)
                strErrorMsg = objBComDB.ErrorMsg
                intErrorCode = objBComDB.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Release resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objDCatAuthor Is Nothing Then
                    objDCatAuthor.Dispose(True)
                    objDCatAuthor = Nothing
                End If
                If Not objBComDB Is Nothing Then
                    objBComDB.Dispose(True)
                    objBComDB = Nothing
                End If
                If Not objBString Is Nothing Then
                    objBString.Dispose(True)
                    objBString = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace