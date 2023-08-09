' Purpose: process location(store) informations
' Creator: sondp
' Created Date: 28/4/2004
Imports Libol60.BusinessRules.Common
Imports Libol60.DataAccess.Catalogue

Namespace Libol60.BusinessRules.Catalogue
    Public Class clsBHoldingLocation1
        Inherits clsBBase

        ' ***********************************************************************
        ' Declare variables
        ' ***********************************************************************

        Private objBCommonSP As New clsBCommonStringProc
        Private objBCommonDB As New clsBCommonDBSystem
        Private objDHoldLoc As New clsDHoldingLocation

        Private strID As String = ""
        Private intLibID As Integer
        Private strSymbol As String
        Private blnStatus As Boolean
        Private intMaxNumberINC As Integer = 0
        Private intMaxNumberNEW As Integer = 0
        'Private intUserID As Integer = 1

        Public intRetVal As Integer

        ' ***********************************************************************
        ' End declare variables
        ' Declare properties
        ' ***********************************************************************

        ' LibID property
        Public Property LibID() As Integer
            Get
                Return (intLibID)
            End Get
            Set(ByVal Value As Integer)
                intLibID = Value
            End Set
        End Property

        ' Symbol property
        Public Property Symbol() As String
            Get
                Return (strSymbol)
            End Get
            Set(ByVal Value As String)
                strSymbol = Value
            End Set
        End Property

        ' Status property
        Public Property Status() As Boolean
            Get
                Return (blnStatus)
            End Get
            Set(ByVal Value As Boolean)
                blnStatus = Value
            End Set
        End Property

        ' MaxNumberINC property
        Public Property MaxNumberINC() As Integer
            Get
                Return intMaxNumberINC
            End Get
            Set(ByVal Value As Integer)
                intMaxNumberINC = Value
            End Set
        End Property
        ' MaxNumberNEW
        Public Property MaxNumberNew() As Integer
            Get
                Return intMaxNumberNEW
            End Get
            Set(ByVal Value As Integer)
                intMaxNumberNEW = Value
            End Set
        End Property

        ' UserID property
        'Public Property UserID() As Integer
        '    Get
        '        Return (intUserID)
        '    End Get
        '    Set(ByVal Value As Integer)
        '        intUserID = Value
        '    End Set
        'End Property

        'IDs property
        Public Property IDs() As String
            Get
                Return strID
            End Get
            Set(ByVal Value As String)
                strID = Value
            End Set
        End Property

        ' RetVal property
        Public ReadOnly Property RetVal() As Integer
            Get
                Return (intRetVal)
            End Get
        End Property
        ' ***********************************************************************
        ' End declare properties
        ' Implement methods
        ' ***********************************************************************

        ' Initialize method
        ' Purpose: Init all need object
        Public Sub Initialize()
            'initialize for string process 
            objBCommonSP.InterfaceLanguage = strInterfaceLanguage
            objBCommonSP.DBServer = strDBServer
            objBCommonSP.ConnectionString = strConnectionstring
            objBCommonSP.Initialize()
            'initialize for database process
            objBCommonDB.InterfaceLanguage = strInterfaceLanguage
            objBCommonDB.DBServer = strDBServer
            objBCommonDB.ConnectionString = strConnectionstring
            objBCommonDB.Initialize()
            'initialize for clsDHoldingLocation
            objDHoldLoc.DBServer = strDBServer
            objDHoldLoc.ConnectionString = strConnectionstring
            objDHoldLoc.Initalize()
        End Sub

        ' Retrieve method
        ' Purpose: Retrieve all Libsys informations
        Public Function Retrieve() As DataTable
            objDHoldLoc.LibID = intLibID
            objDHoldLoc.UserID = intUserID
            Try
                Retrieve = objBCommonDB.ConvertTable(objDHoldLoc.Retrieve())
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
        End Function

        ' Retrieve method
        ' Purpose: Retrieve all Libsys informations
        Public Function RetrieveLoc() As DataTable
            objBCommonDB.SQLStatement = "SELECT A.ID, A.Symbol, A.LibID FROM HOLDING_LOCATION A, SYS_USER_LOCATION B WHERE A.ID = B.LOCID AND B.UserID = " & intUserID.ToString & " ORDER BY Symbol"
            Try
                RetrieveLoc = objBCommonDB.RetrieveItemInfor
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
        End Function

        ' Insert method
        ' Purpose: insert new lib into database
        Public Sub Insert()
            Try
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Update Method
        ' Purpose: Icrease MaxNumber Field
        ' Input: ID,intMaxNum
        Public Sub Update()
            objDHoldLoc.MaxNumberINC = intMaxNumberINC
            objDHoldLoc.MaxNumberNew = intMaxNumberNEW
            objDHoldLoc.IDs = strID
            Try
                objDHoldLoc.Update()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Merge method
        ' Purpose: merger some libs 
        Public Sub Merge()
            Try
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub
        ' RetrieveHoldingLib method
        ' Purpose: Retrieve holding all locations of all libraries in system
        ' Input: int value of UserID
        ' Output: DataTable
        Public Function RetrieveHoldingLibLoc() As DataTable
            Try
                objDHoldLoc.UserID = intUserID
                RetrieveHoldingLibLoc = objDHoldLoc.RetrieveHoldingLibLoc
                strErrorMsg = objDHoldLoc.ErrorMsg
                intErrorCode = objDHoldLoc.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function
        'Dispose method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCommonDB Is Nothing Then
                    objBCommonDB.Dispose(True)
                    objBCommonDB = Nothing
                End If
                If Not objBCommonSP Is Nothing Then
                    objBCommonSP.Dispose(True)
                    objBCommonSP = Nothing
                End If
                If Not objDHoldLoc Is Nothing Then
                    objDHoldLoc.Dispose(True)
                    objDHoldLoc = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace