' Creator : Vantd
' Last Update: 30/5/2004
Imports Libol60.DataAccess
Imports Libol60.DataAccess.Catalogue
Imports Libol60.BusinessRules
Imports Libol60.BusinessRules.Common

Namespace Libol60.BusinessRules.Catalogue
    Public Class clsBHolding_Lib_Loc
        Inherits clsBBase

        Private objDhold_Lib_loc As New clsDHolding_Lib_Loc
        Private objBString As New clsBCommonStringProc
        Private objBComDB As New clsBCommonDBSystem

        ' ***********************************************************************
        ' Declare variables
        ' ***********************************************************************
        Private strName As String = ""
        Private strCode As String = ""
        Private intLibID As Integer = 0
        Private intLocID As Integer = 0
        Private bytLocalLib As Byte = 0
        Private strAddress As String = ""
        Private intSrcLibID As Integer = 0
        Private intDesLibID As Integer = 0

        ' LibID property
        Public Property LibID() As Integer
            Get
                Return (intLibID)
            End Get
            Set(ByVal Value As Integer)
                intLibID = Value
            End Set
        End Property

        ' LocID property
        Public Property LocID() As Integer
            Get
                Return (intLocID)
            End Get
            Set(ByVal Value As Integer)
                intLocID = Value
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
        Public Property LocalLib() As Byte
            Get
                Return (bytLocalLib)
            End Get
            Set(ByVal Value As Byte)
                bytLocalLib = Value
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

        ' SouLibID property
        Public Property SrcLibID() As Integer
            Get
                Return (intSrcLibID)
            End Get
            Set(ByVal Value As Integer)
                intSrcLibID = Value
            End Set
        End Property

        ' DesLibID property
        Public Property DesLibID() As Integer
            Get
                Return (intDesLibID)
            End Get
            Set(ByVal Value As Integer)
                intDesLibID = Value
            End Set
        End Property

        ' Initialize method
        ' Purpose: Init all necessary objects
        Public Sub Initialize()
            Try
                objBString.DBServer = strDBserver
                objBString.ConnectionString = strConnectionString
                objBString.Initialize()

                objBComDB.DBServer = strDBServer
                objBComDB.InterfaceLanguage = strInterfaceLanguage
                objBComDB.ConnectionString = strConnectionString
                objBComDB.Initialize()

                objDhold_Lib_loc.DBServer = strDBServer
                objDhold_Lib_loc.ConnectionString = strConnectionString
                objDhold_Lib_loc.Initialize()
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        ' Retrieve_Lib method
        ' Purpose: Retrieve the library
        Public Function Retrieve_Lib() As DataTable
            Try
                objDhold_Lib_loc.LibID = intLibID
                objDhold_Lib_loc.LocalLib = bytLocalLib
                Retrieve_Lib = objBComDB.ConvertTable(objDhold_Lib_loc.Retrieve_Lib)
                strErrorMsg = objDhold_Lib_loc.ErrorMsg
                intErrorCode = objDhold_Lib_loc.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Retrieve_Loc method
        ' Purpose: Retrieve the library location
        Public Function Retrieve_Loc() As DataTable
            Try
                objDhold_Lib_loc.LibID = intLibID
                objDhold_Lib_loc.LocID = intLocID
                objDhold_Lib_loc.UserID = intUserID
                Retrieve_Loc = objBComDB.ConvertTable(objDhold_Lib_loc.Retrieve_Loc)
                strErrorMsg = objDhold_Lib_loc.ErrorMsg
                intErrorCode = objDhold_Lib_loc.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBComDB Is Nothing Then
                    objBComDB.Dispose(True)
                    objBComDB = Nothing
                End If
                If Not objDhold_Lib_loc Is Nothing Then
                    objDhold_Lib_loc.Dispose(True)
                    objDhold_Lib_loc = Nothing
                End If
                If Not objBString Is Nothing Then
                    objBString.Dispose(True)
                    objBString = Nothing
                End If
            Finally
                Me.Dispose()
                MyBase.Dispose()
            End Try
        End Sub
    End Class
End Namespace