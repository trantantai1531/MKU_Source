Imports eMicLibAdmin.DataAccess
Imports eMicLibAdmin.DataAccess.Catalogue
Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.BusinessRules.Catalogue
    Public Class clsBTemplate
        Inherits clsBBase
        Private objDTemplate As New clsDTemplate
        Private objBComDB As New clsBCommonDBSystem

        ' ***************************************************************************************************
        ' Declare Private variables
        ' ***************************************************************************************************
        Private strIDs As String = ""
        Private intType As Integer = 0

        ' IDs property
        Public Property IDs() As String
            Get
                Return strIDs
            End Get
            Set(ByVal Value As String)
                strIDs = Value
            End Set
        End Property

        ' Type property
        Public Property Type() As Integer
            Get
                Return intType
            End Get
            Set(ByVal Value As Integer)
                intType = Value
            End Set
        End Property

        ' Initialize method
        ' Purpose: Init all necessary objects
        Public Sub Initialize()
            Try
                objBComDB.DBServer = strDBServer
                objBComDB.InterfaceLanguage = strInterfaceLanguage
                objBComDB.ConnectionString = strConnectionString
                objBComDB.Initialize()

                objDTemplate.DBServer = strDBServer
                objDTemplate.ConnectionString = strConnectionString
                objDTemplate.Initialize()
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub


        ' GetTemplates method
        ' Purpose: Get all systemplate
        Public Function GetTemplates() As DataTable
            Try
                objDTemplate.IDs = strIDs
                objDTemplate.Type = intType
                GetTemplates = objBComDB.ConvertTable(objDTemplate.GetTemplates())
                strErrorMsg = objDTemplate.ErrorMsg
                intErrorCode = objDTemplate.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBComDB Is Nothing Then
                    objBComDB.Dispose(True)
                    objBComDB = Nothing
                End If
                If Not objDTemplate Is Nothing Then
                    objDTemplate.Dispose(True)
                    objDTemplate = Nothing
                End If
            Finally
                Me.Dispose()
                MyBase.Dispose()
            End Try
        End Sub
    End Class
End Namespace