' Name: clsBUserLocation
' Purpose: working with userlocations
' Creator: Oanhtn
' CreatedDate: 17/08/2004
' Modification History:

Imports System
Imports System.Data
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Common

Namespace eMicLibAdmin.BusinessRules.Common
    Public Class clsBUserLocation
        Inherits clsBBase

        ' *****************************************************************************************************
        ' Declare member variables
        ' *****************************************************************************************************

        Private strLocationIDs As String = ""

        Private objBCDBS As New clsBCommonDBSystem
        Private objDUserLocation As New clsDUserLocation

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' LocationIDs property
        Public Property LocationIDs() As String
            Get
                Return strLocationIDs
            End Get
            Set(ByVal Value As String)
                strLocationIDs = Value
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
                ' Init objBCDBS object
                objBCDBS.ConnectionString = strConnectionString
                objBCDBS.DBServer = strDBServer
                objBCDBS.InterfaceLanguage = strInterfaceLanguage
                Call objBCDBS.Initialize()

                ' Init objDUserLocation object
                objDUserLocation.ConnectionString = strConnectionString
                objDUserLocation.DBServer = strDBServer
                Call objDUserLocation.Initialize()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' GetUserLocations method
        ' Purpose: Get valid locations of the SelectedUser
        ' Input: intUserID
        ' Output: datatable result
        Public Function GetUserLocations(Optional ByVal intSubsystemID As Integer = 1) As DataTable
            Try
                objDUserLocation.UserID = intUserID
                GetUserLocations = objBCDBS.ConvertTable(objDUserLocation.GetUserLocations(intSubsystemID))
                strErrorMsg = objBCDBS.ErrorMsg
                intErrorCode = objBCDBS.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetHoldingLocationByUserID(ByVal intHoldingLibrary As Integer,
                                                   Optional intUserID As Integer = 0,
                                                   Optional intTopText As Integer = 1,
                                                   Optional strTopText As String = Nothing) As DataTable
            GetHoldingLocationByUserID = Nothing
            Try
                If strTopText IsNot Nothing AndAlso strTopText.Trim() = "" Then
                    strTopText = Nothing
                End If
                GetHoldingLocationByUserID = objDUserLocation.GetHoldingLocationByUserID(intHoldingLibrary, intUserID, intTopText)
                strErrorMsg = objDUserLocation.ErrorMsg
                intErrorCode = objDUserLocation.ErrorCode
            Catch ex As Exception
                strErrorMsg = objDUserLocation.ErrorMsg
                intErrorCode = objDUserLocation.ErrorCode
            End Try
        End Function

        Public Function GetHoldingCirLocationByUserID(ByVal intHoldingLibrary As Integer,
                                                   Optional intUserID As Integer = 0,
                                                   Optional intTopText As Integer = 1,
                                                   Optional strTopText As String = Nothing) As DataTable
            GetHoldingCirLocationByUserID = Nothing
            Try
                If strTopText IsNot Nothing AndAlso strTopText.Trim() = "" Then
                    strTopText = Nothing
                End If
                GetHoldingCirLocationByUserID = objDUserLocation.GetHoldingCirLocationByUserID(intHoldingLibrary, intUserID, intTopText)
                strErrorMsg = objDUserLocation.ErrorMsg
                intErrorCode = objDUserLocation.ErrorCode
            Catch ex As Exception
                strErrorMsg = objDUserLocation.ErrorMsg
                intErrorCode = objDUserLocation.ErrorCode
            End Try
        End Function

        ' GetLibraries method
        ' Purpose: Get all libraries
        ' Output: datatable result
        Public Function GetLibraries() As DataTable
            Try
                GetLibraries = objBCDBS.ConvertTable(objDUserLocation.GetLibraries)
                strErrorMsg = objBCDBS.ErrorMsg
                intErrorCode = objBCDBS.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetHoldingLibrary method
        ' Purpose: Get valid holding library of the Selected User
        ' Input: intUserID
        ' Output: datatable result
        Public Function GetHoldingLibrary() As DataTable
            Try
                objDUserLocation.UserID = intUserID
                GetHoldingLibrary = objBCDBS.ConvertTable(objDUserLocation.GetHoldingLibrary)
                strErrorMsg = objBCDBS.ErrorMsg
                intErrorCode = objBCDBS.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            If isDisposing Then
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objDUserLocation Is Nothing Then
                    objDUserLocation.Dispose(True)
                    objDUserLocation = Nothing
                End If
            End If
            MyBase.Dispose()
            Me.Dispose()
        End Sub
    End Class
End Namespace