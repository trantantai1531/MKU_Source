Imports System
Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibOPAC.DataAccess.OPAC

Namespace eMicLibOPAC.BusinessRules.OPAC
    Public Class clsBOPACRooms
        Inherits clsBBase

        Private objDOPACRooms As New clsDOPACRooms

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private intRoomID As Integer
        Private strRoomCode As String
        Private strRoomName As String
        Private strRoomNote As String
        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************
        ' LocID property
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


        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************
        ' Initialize method
        Public Sub Initialize()
            ' Init objDOPACLocation object
            objDOPACRooms.DBServer = strDBServer
            objDOPACRooms.ConnectionString = strConnectionString
            objDOPACRooms.Initialize()
        End Sub

        Public Function GetAllRooms() As DataTable
            Try
                GetAllRooms = objDOPACRooms.GetAllRooms
                strErrorMsg = objDOPACRooms.ErrorMsg
                intErrorCode = objDOPACRooms.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objDOPACRooms Is Nothing Then
                    objDOPACRooms.Dispose(True)
                    objDOPACRooms = Nothing
                End If
            Finally
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace

