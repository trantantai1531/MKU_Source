Imports System
Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibOPAC.DataAccess.OPAC

Namespace eMicLibOPAC.BusinessRules.OPAC
    Public Class clsBOPACRoomsBooking
        Inherits clsBBase

        Private objDOPACRoomsBooking As New clsDOPACRoomsBooking

        Private intRoomsBookingID As Integer
        Private intRoomID As Integer
        Private intPatronID As Integer
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
        Public Property PatronID() As Integer
            Get
                Return intPatronID
            End Get
            Set(ByVal Value As Integer)
                intPatronID = Value
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
            ' Init objDOPACLocation object
            objDOPACRoomsBooking.DBServer = strDBServer
            objDOPACRoomsBooking.ConnectionString = strConnectionString
            objDOPACRoomsBooking.Initialize()
        End Sub

        Public Function Create(ByVal strPatronCode As String) As Integer
            Try
                objDOPACRoomsBooking.RoomID = intRoomID
                objDOPACRoomsBooking.BookingDate = strBookingDate
                objDOPACRoomsBooking.TimeStart = intTimeStart
                objDOPACRoomsBooking.TimeEnd = intTimeEnd
                objDOPACRoomsBooking.TypeRoom = intTypeRoom
                objDOPACRoomsBooking.Uses = strUses
                objDOPACRoomsBooking.RequestOther = strRequestOther
                objDOPACRoomsBooking.Count = intCount
                objDOPACRoomsBooking.ListCode = strListCode
                Create = objDOPACRoomsBooking.Create(strPatronCode)
            Catch ex As Exception
                'Return error if sub create not succeed
                strErrorMsg = objDOPACRoomsBooking.ErrorMsg
                intErrorCode = objDOPACRoomsBooking.ErrorCode
            End Try
        End Function
        Public Function Update() As Integer
            Try
                objDOPACRoomsBooking.RoomsBookingID = intRoomsBookingID
                objDOPACRoomsBooking.BookingDate = strBookingDate
                objDOPACRoomsBooking.TimeStart = intTimeStart
                objDOPACRoomsBooking.TimeEnd = intTimeEnd
                objDOPACRoomsBooking.Note = strNote
                Update = objDOPACRoomsBooking.Update()
            Catch ex As Exception
                'Return error if sub create not succeed
                strErrorMsg = objDOPACRoomsBooking.ErrorMsg
                intErrorCode = objDOPACRoomsBooking.ErrorCode
            End Try
        End Function
        Public Function GetHistoryRoomBookingByPatronCode(ByVal strPatronCode As String) As DataTable
            Try
                GetHistoryRoomBookingByPatronCode = objDOPACRoomsBooking.GetHistoryRoomBookingByPatronCode(strPatronCode)
                strErrorMsg = objDOPACRoomsBooking.ErrorMsg
                intErrorCode = objDOPACRoomsBooking.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function
        Public Function GetTimeBusyByDate(ByVal strDate As String) As DataTable
            Try
                objDOPACRoomsBooking.RoomID = intRoomID
                GetTimeBusyByDate = objDOPACRoomsBooking.GetTimeBusyByDate(strDate)
                strErrorMsg = objDOPACRoomsBooking.ErrorMsg
                intErrorCode = objDOPACRoomsBooking.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function
    End Class
End Namespace

