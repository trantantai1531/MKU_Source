Imports eMicLibAdmin.BusinessRules.Admin
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Admin

Namespace eMicLibAdmin.BusinessRules.Admin
    Public Class clsBRole
        Inherits clsBBase

        ' *******************************************************************************************************
        ' Declare Private variables
        ' *******************************************************************************************************

        Dim objDRole As New clsDRole
        Dim objBCDBS As New clsBCommonDBSystem
        Private intModuleID As Integer = 0
        Private intUID As Integer = 0
        Private intParentID As Integer = 0

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************
        Public Property ModuleID() As Integer
            Get
                Return intModuleID
            End Get
            Set(ByVal Value As Integer)
                intModuleID = Value
            End Set
        End Property

        Public Property UID() As Integer
            Get
                Return intUID
            End Get
            Set(ByVal Value As Integer)
                intUID = Value
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
        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Initialize method
        ' Purpose: Init all necessary objects
        Public Sub Initialize()
            ' Init objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.Initialize()

            ' Init objDRole object
            objDRole.DBServer = strDBServer
            objDRole.ConnectionString = strConnectionString
            objDRole.Initialize()
        End Sub

        ' GetRights method
        ' Purpose: Get user informations
        ' Output: datatable result
        Public Function GetRights() As DataTable
            Try
                objDRole.ModuleID = intModuleID
                objDRole.UID = intUID
                objDRole.ParentID = intParentID
                GetRights = objDRole.GetRights
                strErrorMsg = objDRole.ErrorMsg
                intErrorCode = objDRole.ErrorCode
            Catch Ex As Exception
                strErrorMsg = Ex.Message
            Finally
            End Try
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objDRole Is Nothing Then
                    objDRole.Dispose(True)
                    objDRole = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
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