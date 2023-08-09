' Purpose: process libraries informations
' Creator: sondp
' Created Date: 28/4/2004
Imports Libol60.BusinessRules.Common
Imports Libol60.DataAccess.Catalogue
Namespace Libol60.BusinessRules.Catalogue
    Public Class clsBHoldingLibrary1
        Inherits clsBBase

        ' ***********************************************************************
        ' Declare variables
        ' ***********************************************************************

        Private objBCommonSP As New clsBCommonStringProc
        Private objBCommonDB As New clsBCommonDBSystem
        Private objDHoldingLibrary As New clsDHoldingLibrary

        Private intLibID As Integer = 0
        Private intSouLibID As Integer
        Private intDesLibID As Integer

        Private strName As String
        Private strCode As String
        Private blnLocalLib As Boolean
        Private strAddress As String
        Private strAccessEntry As String

        'Private intUserID As Integer
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

        ' Name property
        Public Property Name() As String
            Get
                Return (strName)
            End Get
            Set(ByVal Value As String)
                strName = Value
            End Set
        End Property

        ' Code property
        Public Property Code() As String
            Get
                Return (strCode)
            End Get
            Set(ByVal Value As String)
                strCode = Value
            End Set
        End Property

        ' LocalLib property
        Public Property LocalLib() As Boolean
            Get
                Return (blnLocalLib)
            End Get
            Set(ByVal Value As Boolean)
                blnLocalLib = Value
            End Set
        End Property

        ' Address property
        Public Property Address() As String
            Get
                Return (strAddress)
            End Get
            Set(ByVal Value As String)
                strAddress = Value
            End Set
        End Property

        ' AccessEntry property
        Public Property AccessEntry() As String
            Get
                Return (strAccessEntry)
            End Get
            Set(ByVal Value As String)
                strAccessEntry = Value
            End Set
        End Property

        ' SouLibID property
        Public Property SouLibID() As Integer
            Get
                Return intSouLibID
            End Get
            Set(ByVal Value As Integer)
                intSouLibID = Value
            End Set
        End Property

        ' DesLibID property
        Public Property DesLibID() As Integer
            Get
                Return intDesLibID
            End Get
            Set(ByVal Value As Integer)
                intDesLibID = Value
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
            'for String process
            objBCommonSP.InterfaceLanguage = strInterfaceLanguage
            objBCommonSP.DBServer = strDBServer
            objBCommonSP.ConnectionString = strConnectionstring
            objBCommonSP.Initialize()
            'for database process
            objBCommonDB.InterfaceLanguage = strInterfaceLanguage
            objBCommonDB.DBServer = strDBServer
            objBCommonDB.ConnectionString = strConnectionstring
            objBCommonDB.Initialize()

            objDHoldingLibrary.DBServer = strDBServer
            objDHoldingLibrary.ConnectionString = strConnectionstring
            objDHoldingLibrary.Initalize()
        End Sub

        ' Retrieve method
        ' Purpose: Retrieve all Libsys informations
        Public Function Retrieve() As DataTable
            Try
                objDHoldingLibrary.LibID = intLibID
                Retrieve = objBCommonDB.ConvertTable(objDHoldingLibrary.Retrieve())
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
        End Function

        ' Retrieve method
        ' Purpose: Retrieve all Libsys informations
        Public Function RetrieveLib() As DataTable

            objBCommonDB.SQLStatement = "SELECT ID, Code FROM HOLDING_LIBRARY WHERE  HOLDING_LIBRARY.ID IN (SELECT LibID FROM HOLDING_LOCATION A, SYS_USER_LOCATION B WHERE A.ID = B.LOCID AND UserID = " & intUserID.ToString & ") AND LocalLib = 1 ORDER BY Code ASC"
            Try
                RetrieveLib = objBCommonDB.RetrieveItemInfor
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
        End Function

        ' Insert method
        ' Purpose: insert new lib into database
        Public Sub Insert()
            objDHoldingLibrary.Name = objBCommonSP.ConvertItBack(strName)
            objDHoldingLibrary.Code = objBCommonSP.ConvertItBack(strCode)
            objDHoldingLibrary.Address = objBCommonSP.ConvertItBack(strAddress)
            objDHoldingLibrary.AccessEntry = objBCommonSP.ConvertItBack(AccessEntry)
            Try
                objDHoldingLibrary.Insert()
                intRetVal = objDHoldingLibrary.RetVal
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Update method
        ' Purpose: Update information for the selected library
        Public Sub Update()
            objDHoldingLibrary.Name = objBCommonSP.ConvertItBack(strName)
            objDHoldingLibrary.Code = objBCommonSP.ConvertItBack(strCode)
            objDHoldingLibrary.Address = objBCommonSP.ConvertItBack(strAddress)
            objDHoldingLibrary.AccessEntry = objBCommonSP.ConvertItBack(strAccessEntry)
            objDHoldingLibrary.LibID = intLibID
            Try
                objDHoldingLibrary.Update()
                intRetVal = objDHoldingLibrary.RetVal
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Merge method
        ' Purpose: merger some libs 
        Public Sub Merge()
            objDHoldingLibrary.SouLibID = intSouLibID
            objDHoldingLibrary.DesLibID = intDesLibID
            Try
                objDHoldingLibrary.Merge()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        'Dispose method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCommonSP Is Nothing Then
                    objBCommonSP.Dispose(True)
                    objBCommonSP = Nothing
                End If
                If Not objBCommonDB Is Nothing Then
                    objBCommonDB.Dispose(True)
                    objBCommonDB = Nothing
                End If
                If Not objDHoldingLibrary Is Nothing Then
                    objDHoldingLibrary.Dispose(True)
                    objDHoldingLibrary = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace