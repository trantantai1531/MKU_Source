Imports System
Imports System.Data
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.DataAccess.Circulation

Namespace eMicLibAdmin.BusinessRules.Circulation
    Public Class clsBRooms
        Inherits clsBBase
        Private objDRooms As New clsDRooms

        Private intRoomID As Integer
        Private strRoomCode As String
        Private strRoomName As String
        Private strRoomNote As String

        Public Property RoomID() As Integer
            Get
                Return intRoomID
            End Get
            Set(ByVal Value As Integer)
                intRoomID = Value
            End Set
        End Property

        Public Property RoomCode() As String
            Get
                Return strRoomCode
            End Get
            Set(ByVal Value As String)
                strRoomCode = Value
            End Set
        End Property

        Public Property RoomName() As String
            Get
                Return strRoomName
            End Get
            Set(ByVal Value As String)
                strRoomName = Value
            End Set
        End Property

        Public Property RoomNote() As String
            Get
                Return strRoomNote
            End Get
            Set(ByVal Value As String)
                strRoomNote = Value
            End Set
        End Property

        Public Sub Initialize()
            Try
                ' Init objBCSP object
                objDRooms.ConnectionString = strConnectionString
                objDRooms.DBServer = strDBServer
                Call objDRooms.Initialize()

            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Function Create() As Integer
            Try
                objDRooms.RoomCode = strRoomCode
                objDRooms.RoomName = strRoomName
                objDRooms.RoomNote = strRoomNote
                Create = objDRooms.Create()
                strErrorMsg = objDRooms.ErrorMsg
                intErrorCode = objDRooms.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function Update() As Integer
            Try
                objDRooms.RoomID = intRoomID
                objDRooms.RoomCode = strRoomCode
                objDRooms.RoomName = strRoomName
                objDRooms.RoomNote = strRoomNote
                Update = objDRooms.Update()
                strErrorMsg = objDRooms.ErrorMsg
                intErrorCode = objDRooms.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function
        Public Function Delete() As Integer
            Try
                objDRooms.RoomID = intRoomID
                Delete = objDRooms.Delete()
                strErrorMsg = objDRooms.ErrorMsg
                intErrorCode = objDRooms.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetAllRooms() As DataTable
            Try
                GetAllRooms = objDRooms.GetAllRooms()
                strErrorMsg = objDRooms.ErrorMsg
                intErrorCode = objDRooms.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            If isDisposing Then
                If Not objDRooms Is Nothing Then
                    objDRooms.Dispose(True)
                    objDRooms = Nothing
                End If
            End If
            MyBase.Dispose()
            Me.Dispose()
        End Sub
    End Class
End Namespace

