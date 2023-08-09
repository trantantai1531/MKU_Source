' Purpose: process libraries location informations
' Creator: Lent
' Created Date: 17-2-2005
' Last Modified Date: 

Imports eMicLibAdmin.DataAccess.Acquisition
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition

Namespace eMicLibAdmin.BusinessRules.Acquisition
    Public Class clsBMoveLocation
        Inherits clsBBase
        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private objDMoveLocation As New clsDMoveLocation
        Private objBCDBS As New clsBCommonDBSystem

        Private intLibID1 As Integer
        Private intLocID1 As Integer
        Private intLibID2 As Integer
        Private intLocID2 As Integer
        Private strShelf1 As String = ""
        Private strShelf2 As String = ""
        Private strCode As String = ""
        Private strCopyNumber As String = ""
        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************
        ' LibID1 Properties
        Public Property LibID1() As Integer
            Get
                Return (intLibID1)
            End Get
            Set(ByVal Value As Integer)
                intLibID1 = Value
            End Set
        End Property

        ' LibID2 Properties
        Public Property LibID2() As Integer
            Get
                Return (intLibID2)
            End Get
            Set(ByVal Value As Integer)
                intLibID2 = Value
            End Set
        End Property

        ' LocationID1 Properties
        Public Property LocID1()
            Get
                Return intLocID1
            End Get
            Set(ByVal Value)
                intLocID1 = Value
            End Set
        End Property

        ' LocationID2 Properties
        Public Property LocID2()
            Get
                Return intLocID2
            End Get
            Set(ByVal Value)
                intLocID2 = Value
            End Set
        End Property

        ' Shelf1 Properties
        Public Property Shelf1() As String
            Get
                Return (strShelf1)
            End Get
            Set(ByVal Value As String)
                strShelf1 = Value
            End Set
        End Property

        ' Shelf2 Properties
        Public Property Shelf2() As String
            Get
                Return (strShelf2)
            End Get
            Set(ByVal Value As String)
                strShelf2 = Value
            End Set
        End Property

        ' CopyNumber Properties
        Public Property CopyNumber() As String
            Get
                Return (strCopyNumber)
            End Get
            Set(ByVal Value As String)
                strCopyNumber = Value
            End Set
        End Property

        ' Code Properties
        Public Property Code() As String
            Get
                Return (strCode)
            End Get
            Set(ByVal Value As String)
                strCode = Value
            End Set
        End Property
        ' *************************************************************************************************
        ' End declare properties
        ' Declare public function 
        ' *************************************************************************************************

        ' init all objects
        Public Sub Initialize()
            ' Intialize objDMoveLocation object
            objDMoveLocation.DBServer = strdbserver
            objDMoveLocation.ConnectionString = strConnectionString
            objDMoveLocation.Initialize()
            ' Initialise objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.Initialize()
        End Sub
        'purpose: move a location to another 
        'in: 
        'out:
        'creator: lent
        'date : 23-2-2005
        Public Sub UpdateHoldingMove()
            Try
                objDMoveLocation.LibID1 = intLibID1
                objDMoveLocation.LibID2 = intLibID2
                objDMoveLocation.LocID1 = intLocID1
                objDMoveLocation.LocID2 = intLocID2
                objDMoveLocation.Shelf1 = strShelf1
                objDMoveLocation.Shelf2 = strShelf2
                objDMoveLocation.Code = strCode
                objDMoveLocation.CopyNumber = strCopyNumber
                Call objDMoveLocation.UpdateHoldingMove()
            Catch ex As Exception
                strerrormsg = objDMoveLocation.ErrorMsg
                interrorcode = objDMoveLocation.ErrorCode
            End Try
        End Sub

        ' Release resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                End If
                If Not objDMoveLocation Is Nothing Then
                    objDMoveLocation.Dispose(True)
                    objDMoveLocation = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace