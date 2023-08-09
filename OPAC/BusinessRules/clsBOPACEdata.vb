Imports System
Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibOPAC.DataAccess.OPAC

Namespace eMicLibOPAC.BusinessRules.OPAC
    Public Class clsBOPACEData
        Inherits clsBBase
        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        Private objDOPACEdata As New clsDOPACEData

        Private lngStartID As Long = 0
        Private lngFileID As Long = 0
        Private intPageSize As Integer = 0
        Private strParam As String = ""

        ' StartID property
        Public Property StartID() As Long
            Get
                Return lngStartID
            End Get
            Set(ByVal Value As Long)
                lngStartID = Value
            End Set
        End Property

        ' PageSize property
        Public Property PageSize() As Integer
            Get
                Return intPageSize
            End Get
            Set(ByVal Value As Integer)
                intPageSize = Value
            End Set
        End Property

        ' Param property
        Public Property Param() As String
            Get
                Return strParam
            End Get
            Set(ByVal Value As String)
                strParam = Value
            End Set
        End Property

        ' FileID property
        Public Property FileID() As Long
            Get
                Return lngFileID
            End Get
            Set(ByVal Value As Long)
                lngFileID = Value
            End Set
        End Property

        ' ************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' ************************************************************************************************

        ' Initialize method
        Public Sub Initialize()
            ' Init objDOPACEdata object
            objDOPACEdata.DBServer = strDBServer
            objDOPACEdata.ConnectionString = strConnectionString
            objDOPACEdata.Initialize()

            ' Init objBCSP object
            objBCSP.DBServer = strDBServer
            objBCSP.ConnectionString = strConnectionString
            objBCSP.InterfaceLanguage = strInterfaceLanguage
            objBCSP.Initialize()

            ' Init objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.Initialize()
        End Sub

        ' GetMinIDByTopNum method
        ' Purpose: Get the min ID of the page having a top number
        ' Output: datatable result
        ' Creator:
        Public Function GetMaxIDByTopNum(ByVal lngTopNum As Long, Optional ByVal intFree As Integer = -1) As DataTable
            Try
                objDOPACEdata.Param = Replace(objBCSP.ConvertItBack(strParam), "''", "'")
                GetMaxIDByTopNum = objBCDBS.ConvertTable(objDOPACEdata.GetMaxIDByTopNum(lngTopNum, intFree))
                intErrorCode = objDOPACEdata.ErrorCode
                strErrorMsg = objDOPACEdata.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetEdataInfor(ByVal strSort As String, Optional ByVal intFree As Integer = -1, Optional ByVal strIDs As String = "") As DataTable
            Try
                objDOPACEdata.StartID = lngStartID
                objDOPACEdata.PageSize = intPageSize
                objDOPACEdata.Param = strParam
                GetEdataInfor = objBCDBS.ConvertTable(objDOPACEdata.GetEdataInfor(strSort, intFree, strIDs))
                intErrorCode = objDOPACEdata.ErrorCode
                strErrorMsg = objDOPACEdata.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' UpdateEDownloadTimes method
        ' Purpose: Update edata download times
        ' Output: DataTable
        ' Creator: dgsoft2016
        Public Sub UpdateEDownloadTimes()
            Try
                objDOPACEdata.FileID = lngFileID
                objDOPACEdata.UpdateEDownloadTimes()
                intErrorCode = objDOPACEdata.ErrorCode
                strErrorMsg = objDOPACEdata.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' GetEdataDetails method
        ' Purpose: Get Edata Details
        ' Output: DataTable
        ' Creator: dgsoft2016
        Public Function GetEdataDetails() As DataTable
            Try
                objDOPACEdata.FileID = lngFileID
                GetEdataDetails = objDOPACEdata.GetEdataDetails
                intErrorCode = objDOPACEdata.ErrorCode
                strErrorMsg = objDOPACEdata.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetEdataDubTitle method
        ' Purpose: Get the dubplico title for edata record
        Public Function GetEdataDubTitle(ByVal lngID As Long) As DataTable
            Try
                GetEdataDubTitle = objBCDBS.ConvertTable(objDOPACEdata.GetEdataDubTitle(lngID))
                intErrorCode = objDOPACEdata.ErrorCode
                strErrorMsg = objDOPACEdata.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetEdataFile(ByVal lngID As Long) As String
            Dim inti As Integer
            Dim tblData As New DataTable
            Dim strHref As String
            Try
                strHref = ""
                tblData = objBCDBS.ConvertTable(objDOPACEdata.GetEdataFile(lngID))
                If Not tblData Is Nothing AndAlso tblData.Rows.Count > 0 Then
                    For inti = 0 To tblData.Rows.Count - 1
                        Select Case LCase(tblData.Rows(inti).Item("Extension"))
                            Case "pdf", "doc", "txt", "rtf", "html", "htm", "xls", "ppt", "pps", "ps", "wri"
                                strHref = strHref & "<A HREF=WuniVisDownload.aspx?ID=" & tblData.Rows(inti).Item("ID") & ">WuniVisDownload.aspx?ID=" & tblData.Rows(inti).Item("ID") & "&nbsp;</A>"
                        End Select
                    Next
                    strHref = strHref & "<A HREF=index.aspx?Start=" & tblData.Rows(tblData.Rows.Count - 1).Item("ID") & ">index.aspx?Start=" & tblData.Rows(tblData.Rows.Count - 1).Item("ID") & "&nbsp;</A>"
                End If
                GetEdataFile = strHref
                intErrorCode = objDOPACEdata.ErrorCode
                strErrorMsg = objDOPACEdata.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetEdataMetadata method
        ' Purpose: Get the dubplico information for edata record
        Public Function GetEdataMetadata() As DataTable
            Try
                objDOPACEdata.FileID = lngFileID
                GetEdataMetadata = objBCDBS.ConvertTable(objDOPACEdata.GetEdataMetadata())
                intErrorCode = objDOPACEdata.ErrorCode
                strErrorMsg = objDOPACEdata.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                End If
                If Not objDOPACEdata Is Nothing Then
                    Call objDOPACEdata.Dispose(True)
                    objDOPACEdata = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    Call objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    Call objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Dispose()
            End Try
        End Sub
    End Class
End Namespace