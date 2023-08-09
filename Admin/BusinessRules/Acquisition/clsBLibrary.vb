' Purpose: process libraries informations
' Creator: Lent
' Created Date: 17-2-2005
' Last Modified Date: 
Imports eMicLibAdmin.DataAccess.Acquisition
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition

Namespace eMicLibAdmin.BusinessRules.Acquisition
    Public Class clsBLibrary
        Inherits clsBBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************

        Private objDLib As New clsDLibrary
        Private objBCDBS As New clsBCommonDBSystem
        Private objBCSP As New clsBCommonStringProc

      
        Private strName As String = ""
        Private strCode As String = ""
        Private booLocalLib As Boolean = True
        Private strAddress As String = ""
        Private strAccessEntry As String = ""
        Private intSouLibID As Integer = 0
        Private intDesLibID As Integer = 0

        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************

      

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
                Return (intSouLibID)
            End Get
            Set(ByVal Value As Integer)
                intSouLibID = Value
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

        ' *************************************************************************************************
        ' End declare properties
        ' Declare public function 
        ' *************************************************************************************************

        ' Init all objects
        Public Sub Initialize()
            ' Intialize objDLib object
            objDLib.DBServer = strdbserver
            objDLib.ConnectionString = strConnectionString
            Call objDLib.Initialize()

            ' Initialise objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            Call objBCDBS.Initialize()

            ' Initialise objBCSP object
            objBCSP.DBServer = strDBServer
            objBCSP.ConnectionString = strConnectionString
            objBCSP.InterfaceLanguage = strInterfaceLanguage
            Call objBCSP.Initialize()
        End Sub


        ' Method: Create
        ' Purpose: Select one Library which existed
        ' Input: library informations
        ' Output: > 0 if successfull
        ' Creator: PhuongTT
        ' CreatedDate : 30-06-2008
        Public Function SelectID() As Integer
            Try
                objDLib.Code = objBCSP.ConvertItBack(strCode)
                SelectID = objDLib.SelectID
                strErrorMsg = objDLib.ErrorMsg
                intErrorCode = objDLib.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function


        ' Method: Create
        ' Purpose: insert one Library
        ' Input: library informations
        ' Output: 0 if successfull
        ' Creator: lent
        ' CreatedDate : 17-2-2005
        Public Function Create() As Integer
            Try
                objDLib.Name = objBCSP.ConvertItBack(strName)
                objDLib.Code = objBCSP.ConvertItBack(strCode)
                objDLib.Address = objBCSP.ConvertItBack(strAddress)
                objDLib.AccessEntry = objBCSP.ConvertItBack(strAccessEntry)
                objDLib.LibID = intLibID
                Create = objDLib.Create
                strErrorMsg = objDLib.ErrorMsg
                intErrorCode = objDLib.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        ' Method: Update
        ' Purpose: update one Library
        ' Input: library informations
        ' Output: 0 if successfull
        ' Creator: lent
        ' CreatedDate : 17-2-2005
        Public Function Update() As Integer
            Try
                objDLib.LibID = intLibID
                objDLib.Name = objBCSP.ConvertItBack(strName)
                objDLib.Code = objBCSP.ConvertItBack(strCode)
                objDLib.Address = objBCSP.ConvertItBack(strAddress)
                objDLib.AccessEntry = objBCSP.ConvertItBack(strAccessEntry)
                Update = objDLib.Update()
                strErrorMsg = objDLib.ErrorMsg
                intErrorCode = objDLib.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        'purpose:
        'in:
        'out:
        'creator:
        Public Sub Delete()

        End Sub

        'purpose:
        'in:
        'out:
        'creator:
        Public Sub MergeLibrary(ByVal strSouLibIDs As String)
            Try
                objDLib.DesLibID = intDesLibID
                Call objDLib.MergeLibrary(strSouLibIDs)
                strErrorMsg = objDLib.ErrorMsg
                intErrorCode = objDLib.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Sub

        ' Purpose: Get Holding Library
        ' In: intLibID, intLocalLib
        ' Out: Datatable
        ' Creator: Sondp
        ' Modify : Lent 29-3-2005
        Public Function GetLibrary(Optional ByVal intStatus As Integer = -1, Optional ByVal intLocalLib As Integer = -1, Optional ByVal intType As Integer = 1) As DataTable
            Try
                objDLib.LibID = intLibID
                objDLib.UserID = intUserID
                intLocalLib = 1
                GetLibrary = objBCDBS.ConvertTable(objDLib.GetLibrary(intStatus, intLocalLib))
                strErrorMsg = objDLib.ErrorMsg
                intErrorCode = objDLib.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function


        ' Method: SelectID
        ' Purpose: Get Folder by LibID
        ' Input: library Id
        ' Output: GetID
        ' Creator: QuocDD
        ' CreatedDate : 04-09-2015
        Public Function GetFolderbyLibId() As DataTable
            Try
                objDLib.LibID = intLibID
                GetFolderbyLibId = objBCDBS.ConvertTable(objDLib.GetFolderbyLibId())
                strErrorMsg = objDLib.ErrorMsg
                intErrorCode = objDLib.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: SelectID
        ' Purpose: Get Folder by LibID
        ' Input: library Id
        ' Output: GetID
        ' Creator: QuocDD
        ' CreatedDate : 04-09-2015
        Public Function GetListFolder() As DataTable
            Try
                objDLib.LibID = intLibID
                GetListFolder = objBCDBS.ConvertTable(objDLib.GetListFolder())
                strErrorMsg = objDLib.ErrorMsg
                intErrorCode = objDLib.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Release resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                End If
                If Not objDLib Is Nothing Then
                    objDLib.Dispose(True)
                    objDLib = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace