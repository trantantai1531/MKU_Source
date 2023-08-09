' Name: clsBElecDelMode
' Purpose: management electronic delivery mode
' Creator: Sondp
' Created Date: 25/11/2004
' Modification History: 
'   - 05/01/2005 by Oanhtn: review code

Imports System
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.ILL

Namespace eMicLibAdmin.BusinessRules.ILL
    Public Class clsBElecDelMode
        Inherits clsBBase

        ' ***********************************************************************************************
        ' Declare Private variables
        ' ***********************************************************************************************

        Private intID As Integer
        Private strModeName As String
        Private strModeAddr As String

        Private objBCDBS As New clsBCommonDBSystem
        Private objBCSP As New clsBCommonStringProc
        Private objDEDelMode As New clsDElecDelMode

        ' ***********************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' ***********************************************************************************************

        ' ID property
        Public Property ID() As Integer
            Get
                Return (intID)
            End Get
            Set(ByVal Value As Integer)
                intID = Value
            End Set
        End Property

        ' Mode Name property
        Public Property ModeName() As String
            Get
                Return (strModeName)
            End Get
            Set(ByVal Value As String)
                strModeName = Value
            End Set
        End Property

        ' Mode Addr property
        Public Property ModeAddr() As String
            Get
                Return (strModeAddr)
            End Get
            Set(ByVal Value As String)
                strModeAddr = Value
            End Set
        End Property

        ' ***********************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' ***********************************************************************************************

        ' Initialize method
        ' Purpose: Init all neccessary objects
        Public Sub Initialize()
            ' Initialize objDEDelMode object
            objDEDelMode.ConnectionString = strconnectionstring
            objDEDelMode.DBServer = strDBServer
            objDEDelMode.Initialize()

            ' Initialize objBCDBS object
            objBCDBS.InterfaceLanguage = strinterfacelanguage
            objBCDBS.ConnectionString = strconnectionstring
            objBCDBS.DBServer = strdbserver
            objBCDBS.Initialize()

            ' Initialize objBCSP object
            objBCSP.InterfaceLanguage = strinterfacelanguage
            objBCSP.ConnectionString = strconnectionstring
            objBCSP.DBServer = strdbserver
            objBCSP.Initialize()
        End Sub

        ' Purpose: Create new Elecdelmode
        ' Input: strEdelivMode, strEdelivTSAddr
        ' Creator: Sondp
        Public Function Create() As Integer
            Try
                objDEDelMode.ModeName = objBCSP.ConvertItBack(strModeName)
                objDEDelMode.ModeAddr = objBCSP.ConvertItBack(strModeAddr)
                objDEDelMode.LibID = intLibID
                Create = objDEDelMode.Create()
                strErrorMsg = objDEDelMode.ErrorMsg
                intErrorCode = objDEDelMode.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose: Get a Elecdelmode
        ' Input: intID
        ' Output: Datatable
        ' Creator: Sondp
        Public Function GetElectDelMode() As DataTable
            Try
                objDEDelMode.ID = intID
                objDEDelMode.LibID = intLibID
                GetElectDelMode = objBCDBS.ConvertTable(objDEDelMode.GetElectDelMode())
                strErrorMsg = objDEDelMode.ErrorMsg
                intErrorCode = objDEDelMode.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose: Delete a Elecdelmode
        ' Input: intID
        ' Creator: Sondp
        Public Function Delete() As Integer
            Try
                objDEDelMode.ID = intID
                Delete = objDEDelMode.Delete()
                strErrorMsg = objDEDelMode.ErrorMsg
                intErrorCode = objDEDelMode.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose: Update Elecdelmode
        ' Input: intID, strEdelivMode, strEdelivTSAddr
        ' Output: 
        ' Creator: Sondp
        Public Function Update() As Integer
            Try
                objDEDelMode.ID = intID
                objDEDelMode.ModeName = objBCSP.ConvertItBack(strModeName)
                objDEDelMode.ModeAddr = objBCSP.ConvertItBack(strModeAddr)
                Update = objDEDelMode.Update()
                strErrorMsg = objDEDelMode.ErrorMsg
                intErrorCode = objDEDelMode.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not objDEDelMode Is Nothing Then
                        objDEDelMode.Dispose(True)
                        objDEDelMode = Nothing
                    End If
                    If Not objBCDBS Is Nothing Then
                        objBCDBS.Dispose(True)
                        objBCDBS = Nothing
                    End If
                    If Not objBCSP Is Nothing Then
                        objBCSP.Dispose(True)
                        objBCSP = Nothing
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