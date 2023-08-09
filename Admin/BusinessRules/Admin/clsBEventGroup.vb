' Name: clsBEventGroup
' Purpose: Management event
' Creator: Oanhtn
' Created Date: 18/11/2004
' Modification History:

Imports eMicLibAdmin.BusinessRules.Admin
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Admin

Namespace eMicLibAdmin.BusinessRules.Admin
    Public Class clsBEventGroup
        Inherits clsBBase

        ' *******************************************************************************************************
        ' Declare Private variables
        ' *******************************************************************************************************

        Private intEventGroupID As Integer = 0
        Private intParentID As Integer = 0
        Private intLogMode As Integer = 0
        Private strEventIDs As String = ""

        Dim objDEventGroup As New clsDEventGroup
        Dim objBCDBS As New clsBCommonDBSystem

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' EventGroupID property
        Public Property EventGroupID() As Integer
            Get
                Return intEventGroupID
            End Get
            Set(ByVal Value As Integer)
                intEventGroupID = Value
            End Set
        End Property

        ' ParentID property
        Public Property ParentID() As Integer
            Get
                Return intParentID
            End Get
            Set(ByVal Value As Integer)
                intParentID = Value
            End Set
        End Property

        ' LogMode property
        Public Property LogMode() As Integer
            Get
                Return intLogMode
            End Get
            Set(ByVal Value As Integer)
                intLogMode = Value
            End Set
        End Property

        ' EventIDs property
        Public Property EventIDs() As String
            Get
                Return strEventIDs
            End Get
            Set(ByVal Value As String)
                strEventIDs = Value
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

            ' Init objDEventGroup object
            objDEventGroup.DBServer = strDBServer
            objDEventGroup.ConnectionString = strConnectionString
            objDEventGroup.Initialize()
        End Sub


        ' SetLogMode method
        ' Purpose: Set log mode
        ' Input: strEventIDs
        Public Sub SetLogMode()
            Try
                objDEventGroup.ParentID = intParentID
                objDEventGroup.EventIDs = strEventIDs
                Call objDEventGroup.SetLogMode()
                strErrorMsg = objDEventGroup.ErrorMsg
                intErrorCode = objDEventGroup.ErrorCode
            Catch Ex As Exception
                strErrorMsg = Ex.Message
            Finally
            End Try
        End Sub

        ' GetEventsOfGroup method
        ' Purpose: Get events to write log
        ' Input: EventGroupID
        ' Output: datatable result
        Public Function GetEventsOfGroup() As DataTable
            Try
                objDEventGroup.EventGroupID = intEventGroupID
                GetEventsOfGroup = objBCDBS.ConvertTable(objDEventGroup.GetEventsOfGroup)
                strErrorMsg = objDEventGroup.ErrorMsg
                intErrorCode = objDEventGroup.ErrorCode
            Catch Ex As Exception
                strErrorMsg = Ex.Message
            Finally
            End Try
        End Function

        ' GetEventGroups method
        ' Purpose: Get groups of events
        ' Output: datatable result
        Public Function GetEventGroups() As DataTable
            Try
                GetEventGroups = objBCDBS.ConvertTable(objDEventGroup.GetEventGroups)
                strErrorMsg = objDEventGroup.ErrorMsg
                intErrorCode = objDEventGroup.ErrorCode
            Catch Ex As Exception
                strErrorMsg = Ex.Message
            Finally
            End Try
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objDEventGroup Is Nothing Then
                    objDEventGroup.Dispose(True)
                    objDEventGroup = Nothing
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