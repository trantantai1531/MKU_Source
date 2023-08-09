Imports eMicLibOPAC.DataAccess.OPAC
Imports eMicLibOPAC.BusinessRules.Common
Namespace eMicLibOPAC.BusinessRules.OPAC
    Public Class clsMBSearch
        Inherits clsBBase
        ' Objects declare
        Private objBCDBS As New clsBCommonDBSystem
        Private objDMS As New clsMDSearch
        ' Variable declare
        Private strIDs As String

        ' Properties declare
        ' --------------------------------------------------------------------------------------------------
        ' IDs property
        Public Property IDs() As String
            Get
                Return (strIDs)
            End Get
            Set(ByVal Value As String)
                strIDs = Value
            End Set
        End Property


        ' Function declare
        ' --------------------------------------------------------------------------------------------------
        ' Initialize method
        Public Sub Initialize()
            ' Init objDMS object
            objDMS.DBServer = strDBServer
            objDMS.ConnectionString = strConnectionString
            objDMS.Initialize()
            ' Init objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.Initialize()
        End Sub

        '' Purpose:      get data display
        '' Input:        strIDs
        '' Output:       string
        'Public Function GetDataDisplay_old(ByVal intCurPage As Integer, ByVal intStartID As Integer, ByVal strPre As String, ByVal strNext As String) As String
        '    Dim tblData As New DataTable
        '    Dim strDisplay, strContent As String
        '    Dim inti As Integer
        '    Dim objFont As New TVCOMLib.utf8
        '    If Not strIDs = "" Then
        '        objDMS.IDs = strIDs
        '        Try
        '            tblData = objBCDBS.ConvertTable(objDMS.GetDataDisplay, "Content")
        '            strErrorMsg = objDMS.ErrorMsg
        '            intErrorCode = objDMS.ErrorCode
        '            If Not tblData Is Nothing AndAlso tblData.Rows.Count > 0 Then
        '                For inti = 0 To tblData.Rows.Count - 1
        '                    If objFont.Len(tblData.Rows(inti).Item("Content")) > 50 Then
        '                        strContent = objFont.Left(tblData.Rows(inti).Item("Content"), 50) & "..."
        '                    Else
        '                        strContent = tblData.Rows(inti).Item("Content")
        '                    End If
        '                    strDisplay = strDisplay & "<B>" & CStr(intStartID + inti + 1) & "</B>.<A HREF='MWDetail.aspx?&CurPage=" & intCurPage & "&ItemID=" & tblData.Rows(inti).Item("ItemID") & "&Pos=" & intStartID + inti & "'>" & strContent & "</A><BR>"
        '                Next
        '            End If
        '            ' Gen Next, Previous button
        '            strDisplay = strDisplay & "<A HREF='MWShowResult.aspx?CurPage=" & intCurPage - 1 & "'>" & strPre & "</A><BR>"
        '            strDisplay = strDisplay & "<A HREF='MWShowResult.aspx?CurPage=" & intCurPage + 1 & "'>" & strNext & "</A>"
        '            GetDataDisplay = strDisplay
        '        Catch ex As Exception
        '            strErrorMsg = ex.Message
        '        End Try
        '    End If
        '    objFont = Nothing
        'End Function

        ' Purpose:      get data display
        ' Input:        strIDs
        ' Output:       string
        Public Function GetDataDisplay(ByVal intCurPage As Integer, ByVal intStartID As Integer, ByVal strPre As String, ByVal strNext As String) As String
            Dim strResult As String = ""
            Dim tblData As New DataTable
            Dim strDisplay As String = "", strContent As String = ""
            Dim inti As Integer
            If Not strIDs = "" Then
                objDMS.IDs = strIDs
                Try
                    tblData = objBCDBS.ConvertTable(objDMS.GetDataDisplay, "Content")
                    strErrorMsg = objDMS.ErrorMsg
                    intErrorCode = objDMS.ErrorCode
                    If Not tblData Is Nothing AndAlso tblData.Rows.Count > 0 Then
                        For inti = 0 To tblData.Rows.Count - 1
                            'If objFont.Len(tblData.Rows(inti).Item("Content")) > 50 Then
                            '    strContent = objFont.Left(tblData.Rows(inti).Item("Content"), 50) & "..."
                            'Else
                            '    strContent = tblData.Rows(inti).Item("Content")
                            'End If
                            strContent = CutWords(tblData.Rows(inti).Item("Content"), 50)
                            strDisplay &= "<B>" & CStr(intStartID + inti + 1) & "</B>.<A HREF='MWDetail.aspx?&CurPage=" & intCurPage & "&ItemID=" & tblData.Rows(inti).Item("ItemID") & "&Pos=" & intStartID + inti & "'>" & strContent & "</A><BR>"
                        Next
                    End If
                    ' Gen Next, Previous button
                    strDisplay = strDisplay & "<A HREF='MWShowResult.aspx?CurPage=" & intCurPage - 1 & "'>" & strPre & "</A><BR>"
                    strDisplay = strDisplay & "<A HREF='MWShowResult.aspx?CurPage=" & intCurPage + 1 & "'>" & strNext & "</A>"
                    strResult = strDisplay
                Catch ex As Exception
                    strErrorMsg = ex.Message
                End Try
            End If
            Return strResult
        End Function

        Public Function CutWords(ByVal _words As String, Optional ByVal _CountCutWords As Integer = 10) As String
            Dim _str As String = ""
            Try
                Dim _cutWord As String = ""
                Dim _arrWord() As String = Nothing
                Dim _bol As Boolean = False
                _cutWord = _words
                _arrWord = Split(_cutWord, " ")
                _bol = False
                _str = ""
                If _CountCutWords >= UBound(_arrWord) Then
                    _CountCutWords = UBound(_arrWord)
                    _bol = True
                End If
                For i As Integer = 0 To _CountCutWords
                    _str &= _arrWord(i) & " "
                Next
                If Not _bol Then
                    _str &= "..."
                End If
            Catch ex As Exception

            End Try
            Return _str
        End Function

        ' Purpose:      get detail of item to display
        ' Input:        intID
        ' Output:       datatable
        Public Function GetDetailOfItem() As DataTable
            Try
                objDMS.IDs = CInt(strIDs)
                GetDetailOfItem = objBCDBS.ConvertTable(objDMS.GetDetailOfItem, "Content")
                strErrorMsg = objDMS.ErrorMsg
                intErrorCode = objDMS.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose:      get holding detail of item to display
        ' Input:        intID
        ' Output:       datatable
        Public Function GetHoldingDetailOfItem() As DataTable
            Try
                objDMS.IDs = CInt(strIDs)
                GetHoldingDetailOfItem = objBCDBS.ConvertTable(objDMS.GetHoldingDetailOfItem)
                strErrorMsg = objDMS.ErrorMsg
                intErrorCode = objDMS.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose:      get reserved items
        ' Input:        strCode
        ' Output:       datatable
        Public Function GetReserveItems(ByVal strCode As String) As DataTable
            Try
                GetReserveItems = objBCDBS.ConvertTable(objDMS.GetReserveItems(strCode), "Content")
                strErrorMsg = objDMS.ErrorMsg
                intErrorCode = objDMS.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose: GetOnHolding
        ' Input: strCardNo
        ' Output: Datatable 
        ' Created by: dgsoft2016
        Public Function GetOnHoldedItems(ByVal strCode As String) As DataTable
            Try
                GetOnHoldedItems = objBCDBS.ConvertTable(objDMS.GetOnHoldedItems(strCode), "Content")
                strErrorMsg = objDMS.ErrorMsg
                intErrorCode = objDMS.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose: get detail of item include holding + fields
        ' Input: strCopyNumber, intItemID
        ' Output: Datatable 
        ' Created by: dgsoft2016 
        Public Function GetHolFieldOfItem(ByVal strCopyNumber As String, ByVal intItemID As Integer) As DataTable
            Try
                GetHolFieldOfItem = objBCDBS.ConvertTable(objDMS.GetHolFieldOfItem(strCopyNumber, intItemID), "Content")
                strErrorMsg = objDMS.ErrorMsg
                intErrorCode = objDMS.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose: Get ILL request
        ' Input: strCardNo
        ' Output: Datatable 
        ' Created by: dgsoft2016
        Public Function GetILLRequestItems(ByVal strCode As String) As DataTable
            Try
                GetILLRequestItems = objBCDBS.ConvertTable(objDMS.GetILLRequestItems(strCode))
                strErrorMsg = objDMS.ErrorMsg
                intErrorCode = objDMS.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose: cancel reseved item
        ' Input: strCopyNumber, intItemID
        ' Created by: dgsoft2016 
        Public Sub CancelReseved(ByVal strCopyNumber As String, ByVal strCode As String)
            Try
                objDMS.CancelReseved(strCopyNumber, strCode)
                strErrorMsg = objDMS.ErrorMsg
                intErrorCode = objDMS.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCDBS Is Nothing Then
                    Call objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objDMS Is Nothing Then
                    objDMS.Dispose(True)
                    objDMS = Nothing
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Dispose()
            End Try
        End Sub
    End Class
End Namespace