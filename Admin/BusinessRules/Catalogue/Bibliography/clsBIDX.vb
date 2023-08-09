Imports System.IO
Imports eMicLibAdmin.DataAccess
Imports eMicLibAdmin.DataAccess.Catalogue
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.BusinessRules.Catalogue
    Public Class clsBIDX
        Inherits clsBBase

        ' *****************************************************************************************************
        ' Declare Private variables
        ' *****************************************************************************************************

        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        Private objDIDX As New clsDIDX

        Private strIDs As String = ""
        Private strTitle As String = ""
        Private strGroupBy As String = ""
        Private intTORsAdd As Integer = 0
        Private strUPDType As String = ""
        Private intNORs As Integer = 0
        Private intGroupID As Integer = 0
        Private intGroupIDOUT As Integer = 0
        Private intPositionOUT As Integer = 0
        Private intLibID As Integer = 0
        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' IDs property
        Public Property IDs() As String
            Get
                Return strIDs
            End Get
            Set(ByVal Value As String)
                strIDs = Value
            End Set
        End Property

        ' Title property
        Public Property Title() As String
            Get
                Return strTitle
            End Get
            Set(ByVal Value As String)
                strTitle = Value
            End Set
        End Property

        ' GroupBy property
        Public Property GroupBy() As String
            Get
                Return strGroupBy
            End Get
            Set(ByVal Value As String)
                strGroupBy = Value
            End Set
        End Property

        ' TORsAdd property
        Public Property TORsAdd() As Integer
            Get
                Return intTORsAdd
            End Get
            Set(ByVal Value As Integer)
                intTORsAdd = Value
            End Set
        End Property

        ' NORs property
        Public Property NORs() As Integer
            Get
                Return intNORs
            End Get
            Set(ByVal Value As Integer)
                intNORs = Value
            End Set
        End Property

        ' GroupID property
        Public Property GroupID() As Integer
            Get
                Return intGroupID
            End Get
            Set(ByVal Value As Integer)
                intGroupID = Value
            End Set
        End Property

        ' UPDType property
        Public Property UPDType() As String
            Get
                Return strUPDType
            End Get
            Set(ByVal Value As String)
                strUPDType = Value
            End Set
        End Property

        ' PositionOUT property
        Public ReadOnly Property PositionOUT() As Integer
            Get
                Return intPositionOUT
            End Get
        End Property

        ' GroupIDOUT property
        Public ReadOnly Property GroupIDOUT() As Integer
            Get
                Return intGroupIDOUT
            End Get
        End Property

        ' LibID property
        Public Property LibID() As Integer
            Get
                Return intLibID
            End Get
            Set(ByVal Value As Integer)
                intLibID = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Initialize method
        Public Sub Initialize()
            Try
                objBCDBS.ConnectionString = strConnectionstring
                objBCDBS.DBServer = strDBServer
                objBCDBS.InterfaceLanguage = strInterfaceLanguage
                objBCDBS.Initialize()

                objDIDX.ConnectionString = strConnectionstring
                objDIDX.DBServer = strDBServer
                objDIDX.Initialize()

                objBCSP.InterfaceLanguage = strInterfaceLanguage
                objBCSP.ConnectionString = strConnectionstring
                objBCSP.DBServer = strDBServer
                objBCSP.Initialize()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' IDXDelete method
        Public Sub IDXDelete()
            Try
                objDIDX.IDs = strIDs
                objDIDX.IDXDelete()
                strErrorMsg = objDIDX.ErrorMsg
                intErrorCode = objDIDX.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' IDXInsert method
        Public Function IDXInsert() As Integer
            Try
                objDIDX.Title = objBCSP.ConvertItBack(strTitle)
                objDIDX.UserID = intUserID
                objDIDX.GroupBy = objBCSP.ConvertItBack(strGroupBy)
                objDIDX.LibID = intLibID
                IDXInsert = objDIDX.IDXInsert()
                strErrorMsg = objDIDX.ErrorMsg
                intErrorCode = objDIDX.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' IDXRetrive method
        Public Function IDXRetrieve() As DataTable
            Try
                objDIDX.IDs = strIDs
                objDIDX.UserID = intUserID
                objDIDX.LibID = intLibID
                IDXRetrieve = objBCDBS.ConvertTable(objDIDX.IDXRetrieve())
                strErrorMsg = objDIDX.ErrorMsg
                intErrorCode = objDIDX.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' IDXChange method
        Public Sub IDXChange()
            Try
                objDIDX.UPDType = strUPDType
                objDIDX.IDs = strIDs
                objDIDX.GroupID = intGroupID
                objDIDX.NORs = intNORs
                objDIDX.IDXChange()
                intPositionOUT = objDIDX.PositionOUT
                intGroupIDOUT = objDIDX.GroupIDOUT
                strErrorMsg = objDIDX.ErrorMsg
                intErrorCode = objDIDX.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' IDXUpdate method
        Public Function IDXUpdate() As Integer
            Try
                objDIDX.IDs = strIDs
                objDIDX.Title = objBCSP.ConvertItBack(strTitle)
                objDIDX.TORsAdd = intTORsAdd
                objDIDX.LibID = intLibID
                objDIDX.UserID = intUserID
                objDIDX.GroupBy = objBCSP.ConvertItBack(strGroupBy)
                IDXUpdate = objDIDX.IDXUpdate()
                strErrorMsg = objDIDX.ErrorMsg
                intErrorCode = objDIDX.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        '  Save data to file .htm and convert to .doc
        Public Function SaveFile(ByVal strContent As String, Optional ByVal strServerRootDirectory As String = "", Optional ByVal isHTML As Boolean = True) As String
            Dim strContentType, strFileName, strPathFile As String
            Dim objFile As File
            Dim objSw As StreamWriter
            Dim objDoc2html As New DOC2HTMLLib.Converter
            Try
                If objBCDBS.GetTempFilePath(1).Rows.Count > 0 Then
                    strPathFile = strServerRootDirectory & objBCDBS.GetTempFilePath(1).Rows(0).Item("TempFilePath") & "\"
                End If
                ' Create file name
                strFileName = objBCDBS.GenRandomFile
                ' Write file
                ' Write file
                strContentType = "<META HTTP-EQUIV=" & "Content-Type"" CONTENT=" & "text/html; charset=utf-8" & ">"
                objSw = File.CreateText(strPathFile & strFileName & ".htm")
                objSw.WriteLine("<HTML><HEAD>" & strContentType & "<TITLE> LIBOL " & "</TITLE></HEAD>")
                objSw.WriteLine("<BODY>" & strContent & "</BODY></HTML>")
                objSw.Close()
                If Not isHTML Then
                    objDoc2html.HtmlToDocFile(strPathFile & strFileName & ".htm", strPathFile & strFileName & ".doc", 1)
                End If
                intErrorCode = objDoc2html.ErrorCode
                If intErrorCode <> 0 Then
                    strErrorMsg = objDoc2html.ErrorMessage
                End If
                If isHTML Then
                    SaveFile = strFileName & ".htm"
                Else
                    SaveFile = strFileName & ".doc"
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
                SaveFile = ex.Message
            End Try
        End Function
        ' Release resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                ' Release unmanaged resources.
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objDIDX Is Nothing Then
                    objDIDX.Dispose(True)
                    objDIDX = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace