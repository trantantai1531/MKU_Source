Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Edeliv
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess
Imports eMicLibAdmin.DataAccess.Edeliv

Namespace eMicLibAdmin.BusinessRules.Edeliv
    Public Class clsBERequestMode
        Inherits clsBBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************

        Private objBSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        Private objDRequestMode As New clsDERequestMode

        Private intRequestModeID As Integer = 0
        Private strRequestMode As String = ""

        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************

        ' RequestModeID property
        Public Property RequestModeID() As Integer
            Get
                Return intRequestModeID
            End Get
            Set(ByVal Value As Integer)
                intRequestModeID = Value
            End Set
        End Property

        ' RequestMode property
        Public Property RequestMode() As String
            Get
                Return strRequestMode
            End Get
            Set(ByVal Value As String)
                strRequestMode = Value
            End Set
        End Property

        ' *************************************************************************************************
        ' End declare public properties
        ' Implement methods here
        ' *************************************************************************************************

        ' Initialize method
        Public Sub Initialize()
            ' Init objBCSP object
            objBSP.DBServer = strDBServer
            objBSP.ConnectionString = strConnectionString
            objBSP.InterfaceLanguage = strInterfaceLanguage
            objBSP.Initialize()

            ' Init objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.Initialize()

            ' Init objDRequestMode object
            objDRequestMode.DBServer = strDBServer
            objDRequestMode.ConnectionString = strConnectionString
            objDRequestMode.Initialize()
        End Sub

        ' Create method
        ' Purpose: create new RequestMode record
        ' Input: main infor of RequestMode infor
        ' Output: int value (0 when success)
        Public Function Create() As Integer
            Try
                objDRequestMode.RequestMode = objBSP.ConvertItBack(strRequestMode)
                Create = objDRequestMode.Create
                strErrorMsg = objDRequestMode.ErrorMsg
                intErrorCode = objDRequestMode.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Update method
        ' Purpose: update information of the selected RequestMode record
        ' Input: main infor of RequestMode infor
        ' Output: int value (0 when success)
        Public Function Update() As Integer
            Try
                objDRequestMode.RequestModeID = intRequestModeID
                objDRequestMode.RequestMode = objBSP.ConvertItBack(strRequestMode)
                Update = objDRequestMode.Update
                strErrorMsg = objDRequestMode.ErrorMsg
                intErrorCode = objDRequestMode.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Delete method
        ' Purpose: delete the selected RequestMode record
        ' Input: CustomerID
        Public Sub Delete()
            Try
                objDRequestMode.RequestModeID = intRequestModeID
                objDRequestMode.Delete()
                strErrorMsg = objDRequestMode.ErrorMsg
                intErrorCode = objDRequestMode.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' GetRequestMode method
        ' Purpose: Get information of the selected RequestMode (also of all sys RequestModes)
        ' Input: main infor of RequestMode infor
        ' Output: datatable result
        Public Function GetRequestMode() As DataTable
            Try
                objDRequestMode.RequestModeID = intRequestModeID
                GetRequestMode = objBCDBS.ConvertTable(objDRequestMode.GetRequestMode)
                strErrorMsg = objDRequestMode.ErrorMsg
                intErrorCode = objDRequestMode.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBSP Is Nothing Then
                    objBSP.Dispose(True)
                    objBSP = Nothing
                End If
                If Not objDRequestMode Is Nothing Then
                    objDRequestMode.Dispose(True)
                    objDRequestMode = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
