' Name: clsBPhysDelMode
' Purpose: management physical delivery mode
' Creator: Sondp
' Created Date: 25/11/2004
' Modification History: 

Imports System
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.ILL

Namespace eMicLibAdmin.BusinessRules.ILL
    Public Class clsBPhysDelMode
        Inherits clsBBase

        ' ***********************************************************************************************
        ' Declare Private variables
        ' ***********************************************************************************************

        Private intID As Integer
        Private strModeName As String
        Private objBCDBS As New clsBCommonDBSystem
        Private objBCSP As New clsBCommonStringProc
        Private objDPhyDelMode As New clsDPhysDelMode

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

        ' ModeName property
        Public Property ModeName() As String
            Get
                Return strModeName
            End Get
            Set(ByVal Value As String)
                strModeName = Value
            End Set
        End Property

        ' ***********************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' ***********************************************************************************************

        ' Initialize method
        ' Purpose: Init all neccessary objects
        Public Sub Initialize()
            ' Initialize objDPhyDelMode object
            objDPhyDelMode.ConnectionString = strconnectionstring
            objDPhyDelMode.DBServer = strdbserver
            objDPhyDelMode.Initialize()

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

        ' Method: Create
        ' Purpose: Create Physical transport mode
        ' Input: strModeName
        ' Creator: Sondp
        Public Function Create() As Integer
            Try
                objDPhyDelMode.ModeName = Trim(objBCSP.ConvertItBack(strModeName))
                objDPhyDelMode.LibID = intLibID
                Create = objDPhyDelMode.Create()
                strErrorMsg = objDPhyDelMode.ErrorMsg
                intErrorCode = objDPhyDelMode.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: Update
        ' Purpose: Update Physical transport mode method
        ' Input: strModeName, intID
        ' Creator: Sondp
        Public Function Update() As Integer
            Try
                objDPhyDelMode.ID = intID
                objDPhyDelMode.ModeName = Trim(objBCSP.ConvertItBack(strModeName))
                Update = objDPhyDelMode.Update()
                strErrorMsg = objDPhyDelMode.ErrorMsg
                intErrorCode = objDPhyDelMode.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Delete Physical transport mode method
        ' Purpose: Delete
        ' Input: intID
        ' Output: 
        ' Creator: Sondp
        Public Function Delete() As Integer
            Try
                objDPhyDelMode.ID = intID
                Delete = objDPhyDelMode.Delete()
                strErrorMsg = objDPhyDelMode.ErrorMsg
                intErrorCode = objDPhyDelMode.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Get Physical transport mode method
        ' Purpose: GetPhyDelMode
        ' Input: intID
        ' Output: Datatable
        ' Creator: Sondp
        Public Function GetPhyDelMode() As DataTable
            Try
                objDPhyDelMode.ID = intID
                objDPhyDelMode.LibID = intLibID
                GetPhyDelMode = objBCDBS.ConvertTable(objDPhyDelMode.GetPhyDelMode())
                strErrorMsg = objDPhyDelMode.ErrorMsg
                intErrorCode = objDPhyDelMode.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not objDPhyDelMode Is Nothing Then
                        objDPhyDelMode.Dispose(True)
                        objDPhyDelMode = Nothing
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