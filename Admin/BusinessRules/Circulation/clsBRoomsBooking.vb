Imports System
Imports System.Data
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.DataAccess.Circulation

Namespace eMicLibAdmin.BusinessRules.Circulation
    Public Class clsBRoomsBooking
        Inherits clsBBase

        Private objDRoomsBooking As New clsDRoomsBooking

        Private intRoomsBookingID As Integer
        Private intRoomID As Integer
        Private strBookingDate As String
        Private intTimeStart As Integer
        Private intTimeEnd As Integer
        Private strNote As String

        Private intTypeRoom As Integer
        Private strUses As String
        Private strRequestOther As String
        Private intCount As Integer
        Private strListCode As String

        Public Property RoomsBookingID() As Integer
            Get
                Return intRoomsBookingID
            End Get
            Set(ByVal Value As Integer)
                intRoomsBookingID = Value
            End Set
        End Property

        ' RoomID property
        Public Property RoomID() As Integer
            Get
                Return intRoomID
            End Get
            Set(ByVal Value As Integer)
                intRoomID = Value
            End Set
        End Property

        Public Property BookingDate() As String
            Get
                Return strBookingDate
            End Get
            Set(ByVal Value As String)
                strBookingDate = Value
            End Set
        End Property

        Public Property TimeStart() As Integer
            Get
                Return intTimeStart
            End Get
            Set(ByVal Value As Integer)
                intTimeStart = Value
            End Set
        End Property

        Public Property TimeEnd() As Integer
            Get
                Return intTimeEnd
            End Get
            Set(ByVal Value As Integer)
                intTimeEnd = Value
            End Set
        End Property

        Public Property Note() As String
            Get
                Return strNote
            End Get
            Set(ByVal Value As String)
                strNote = Value
            End Set
        End Property


        Public Property TypeRoom() As Integer
            Get
                Return intTypeRoom
            End Get
            Set(ByVal Value As Integer)
                intTypeRoom = Value
            End Set
        End Property
        Public Property Uses() As String
            Get
                Return strUses
            End Get
            Set(ByVal Value As String)
                strUses = Value
            End Set
        End Property
        Public Property RequestOther() As String
            Get
                Return strRequestOther
            End Get
            Set(ByVal Value As String)
                strRequestOther = Value
            End Set
        End Property
        Public Property Count() As Integer
            Get
                Return intCount
            End Get
            Set(ByVal Value As Integer)
                intCount = Value
            End Set
        End Property
        Public Property ListCode() As String
            Get
                Return strListCode
            End Get
            Set(ByVal Value As String)
                strListCode = Value
            End Set
        End Property

        Public Sub Initialize()
            Try
                ' Init objDRoomsBooking object
                objDRoomsBooking.ConnectionString = strConnectionString
                objDRoomsBooking.DBServer = strDBServer
                Call objDRoomsBooking.Initialize()

            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Function Update() As Integer
            Try
                objDRoomsBooking.RoomsBookingID = intRoomsBookingID
                objDRoomsBooking.BookingDate = strBookingDate
                objDRoomsBooking.TimeStart = intTimeStart
                objDRoomsBooking.TimeEnd = intTimeEnd
                objDRoomsBooking.Note = strNote
                Update = objDRoomsBooking.Update()
                strErrorMsg = objDRoomsBooking.ErrorMsg
                intErrorCode = objDRoomsBooking.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function Active() As Integer
            Try
                objDRoomsBooking.RoomsBookingID = intRoomsBookingID
                Active = objDRoomsBooking.Active()
                strErrorMsg = objDRoomsBooking.ErrorMsg
                intErrorCode = objDRoomsBooking.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function Cancel() As Integer
            Try
                objDRoomsBooking.RoomsBookingID = intRoomsBookingID
                Cancel = objDRoomsBooking.Cancel()
                strErrorMsg = objDRoomsBooking.ErrorMsg
                intErrorCode = objDRoomsBooking.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetRoomsBooking(Optional ByVal strPatronCode As String = "", Optional ByVal strDateFrom As String = "", Optional ByVal strDateTo As String = "") As DataTable
            Try
                objDRoomsBooking.RoomID = intRoomID
                objDRoomsBooking.BookingDate = strBookingDate
                GetRoomsBooking = objDRoomsBooking.GetRoomsBooking(strPatronCode, strDateFrom, strDateTo)
                strErrorMsg = objDRoomsBooking.ErrorMsg
                intErrorCode = objDRoomsBooking.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function
        Public Function GetRoomsBookingById() As DataTable
            Try
                objDRoomsBooking.RoomsBookingID = intRoomsBookingID
                GetRoomsBookingById = objDRoomsBooking.GetRoomsBookingById()
                strErrorMsg = objDRoomsBooking.ErrorMsg
                intErrorCode = objDRoomsBooking.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            If isDisposing Then
                If Not objDRoomsBooking Is Nothing Then
                    objDRoomsBooking.Dispose(True)
                    objDRoomsBooking = Nothing
                End If
            End If
            MyBase.Dispose()
            Me.Dispose()
        End Sub
    End Class
End Namespace

