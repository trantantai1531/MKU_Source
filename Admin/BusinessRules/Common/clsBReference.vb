Imports eMicLibAdmin.DataAccess
Imports eMicLibAdmin.DataAccess.Common

Namespace eMicLibAdmin.BusinessRules.Common
    Public Class clsBReference
        Inherits clsBBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************

        Private objBCDB As New clsBCommonDBSystem
        Private objDReference As New clsDReference

        Private intModuleID As Integer = 0
        Private strIDs As String = ""
        Private intID As Integer = 0
        Private strRefIDs As String = ""

        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************

        ' RefIDs property
        Public Property RefIDs() As String
            Get
                Return strRefIDs
            End Get
            Set(ByVal Value As String)
                strRefIDs = Value
            End Set
        End Property

        ' ID property
        Public Property ID() As Integer
            Get
                Return intID
            End Get
            Set(ByVal Value As Integer)
                intID = Value
            End Set
        End Property

        ' ModuleID property
        Public Property ModuleID() As Integer
            Get
                Return intModuleID
            End Get
            Set(ByVal Value As Integer)
                intModuleID = Value
            End Set
        End Property

        ' *************************************************************************************************
        ' End declare properties
        ' Declare public function 
        ' *************************************************************************************************

        ' Method: Initialize
        Public Sub Initialize()
            ' Init objBCDB object
            objBCDB.InterfaceLanguage = strInterfaceLanguage
            objBCDB.ConnectionString = strConnectionstring
            objBCDB.DBServer = strDBServer
            Call objBCDB.Initialize()

            ' Init objDReference object
            objDReference.ConnectionString = strConnectionstring
            objDReference.DBServer = strDBServer
            Call objDReference.Initialize()
        End Sub

        Public Sub Update()
            Try
                objDReference.RefIDs = strRefIDs
                objDReference.UserID = intUserID
                objDReference.ModuleID = intModuleID
                Call objDReference.Update()
                intErrorCode = objDReference.ErrorCode
                strErrorMsg = objDReference.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Sub

        Public Function GetReference() As DataTable
            Try
                objDReference.UserID = intUserID
                objDReference.ModuleID = intModuleID
                GetReference = objBCDB.ConvertTable(objDReference.GetReference)
                intErrorCode = objDReference.ErrorCode
                strErrorMsg = objDReference.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        ' Method: Dispose
        ' Release resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCDB Is Nothing Then
                    objBCDB.Dispose(True)
                    objBCDB = Nothing
                End If
                If Not objDReference Is Nothing Then
                    objDReference.Dispose(True)
                    objDReference = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace