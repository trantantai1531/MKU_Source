'Name: clsBLog
'Purpose: Management log object
'Creator: Oanhtn
'Created Date: 18/11/2004
'Modification History:
'  Creator: Tuanhv
'          Date: 26/11/2004

Imports eMicLibAdmin.BusinessRules.Admin
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Admin

Namespace eMicLibAdmin.BusinessRules.Admin
    Public Class clsBLog
        Inherits clsBBase

        '*******************************************************************************************************
        'Declare Private variables
        '*******************************************************************************************************
        Private lngLogID As Long = 0
        Private strEventGroupIDs As String = ""
        Private strUserNames As String = ""
        Private strMessage As String = ""
        Private strLogTimeTo As String = ""
        Private strLogTimeFrom As String = ""

        Dim objDLog As New clsDLog
        Dim objDEventGroup As New clsDEventGroup
        Dim objBCDBS As New clsBCommonDBSystem
        Dim objBCSP As New clsBCommonStringProc

        '*****************************************************************************************************
        'End declare variables
        'Declare public properties
        '*****************************************************************************************************

        'LogID property
        Public Property LogID() As Long
            Get
                Return lngLogID
            End Get
            Set(ByVal Value As Long)
                lngLogID = Value
            End Set
        End Property

        'EventGroupIDs property
        Public Property EventGroupIDs() As String
            Get
                Return strEventGroupIDs
            End Get
            Set(ByVal Value As String)
                strEventGroupIDs = Value
            End Set
        End Property

        'UserNames property
        Public Property UserNames() As String
            Get
                Return strUserNames
            End Get
            Set(ByVal Value As String)
                strUserNames = Value
            End Set
        End Property

        'Message property
        Public Property Message() As String
            Get
                Return strMessage
            End Get
            Set(ByVal Value As String)
                strMessage = Value
            End Set
        End Property

        'LogTimeTo property
        Public Property LogTimeTo() As String
            Get
                Return strLogTimeTo
            End Get
            Set(ByVal Value As String)
                strLogTimeTo = Value
            End Set
        End Property

        'LogTimeFrom property
        Public Property LogTimeFrom() As String
            Get
                Return strLogTimeFrom
            End Get
            Set(ByVal Value As String)
                strLogTimeFrom = Value
            End Set
        End Property

        '*****************************************************************************************************
        'End declare properties
        'Implement methods here
        '*****************************************************************************************************

        'Initialize method
        'Purpose: Init all necessary objects
        Public Sub Initialize()
            'Init objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.Initialize()

            'Init objBCSP object
            objBCSP.DBServer = strDBServer
            objBCSP.ConnectionString = strConnectionString
            objBCSP.InterfaceLanguage = strInterfaceLanguage
            objBCSP.Initialize()

            'Init objDLog object
            objDLog.DBServer = strDBServer
            objDLog.ConnectionString = strConnectionString
            objDLog.Initialize()

            ' Init objDEventGroup object
            objDEventGroup.DBServer = strDBServer
            objDEventGroup.ConnectionString = strConnectionString
            objDEventGroup.Initialize()
        End Sub

        'DeleteLog method
        'Purpose: delete log
        'Input: some conditions
        'Output: integer value (0 if success)
        Public Function DeleteLog() As Integer
            Try
                objDLog.LogTimeFrom = objBCDBS.ConvertDateBack(strLogTimeFrom, True)
                objDLog.LogTimeTo = objBCDBS.ConvertDateBack(strLogTimeTo, True)
                DeleteLog = objDLog.DeleteLog
                strErrorMsg = objDLog.ErrorMsg
                intErrorCode = objDLog.ErrorCode
            Catch Ex As Exception
                strErrorMsg = Ex.Message
            Finally
            End Try
        End Function

        'Search method
        'Purpose: Get logs informations
        'Input: some logs information
        'Output: datatable result
        Public Function Search(ByVal strFromTime As String, ByVal strToTime As String) As DataTable
            Try
                objDLog.EventGroupIDs = Trim(strEventGroupIDs)
                objDLog.UserNames = objBCSP.ConvertItBack(strUserNames)
                objDLog.Message = Trim(objBCSP.ConvertItBack(strMessage))
                If Not strLogTimeFrom = "" Then
                    strLogTimeFrom = Trim(CStr(CDate(strLogTimeFrom))) & " " & Trim(strFromTime)
                End If
                If Not strLogTimeTo = "" Then
                    strLogTimeTo = Trim(CStr(CDate(strLogTimeTo))) & " " & Trim(strToTime)
                End If
                objDLog.LogTimeFrom = objBCDBS.ConvertDateBack(strLogTimeFrom, True)
                objDLog.LogTimeTo = objBCDBS.ConvertDateBack(strLogTimeTo, True)
                Search = objBCDBS.ConvertTable(objDLog.Search, True)
                strErrorMsg = objDLog.ErrorMsg
                intErrorCode = objDLog.ErrorCode
            Catch Ex As Exception
                strErrorMsg = Ex.Message
            Finally
            End Try
        End Function

        'StatMonthly method
        'Purpose: create monthly statistic
        'Input: some information
        'Output: datatable result
        Public Function StatMonthly(ByVal intMonth As Integer, ByVal intYear As Integer) As DataTable
            Try
                StatMonthly = objDLog.StatMonthly(intMonth, intYear)
                strErrorMsg = objDLog.ErrorMsg
                intErrorCode = objDLog.ErrorCode
            Catch Ex As Exception
                strErrorMsg = Ex.Message
            Finally
            End Try
        End Function

        ' Purpose: Statistic log group event method
        ' In: intMonth, intYear, intDay
        ' Creator: Sondp
        ' Output: 2 array(objLabel, objData) 
        Public Sub StatQuickView(ByVal intDay As Integer, ByVal intMonth As Integer, ByVal intYear As Integer, ByRef objLabel As Object, ByRef objData As Object)
            Dim tblStat As New DataTable
            Dim inti As Integer
            ReDim objLabel(0)
            ReDim objData(0)
            objLabel(0) = "noname"
            objData(0) = "-1"
            Try
                tblStat = objBCDBS.ConvertTable(objDLog.StatQuickView(intDay, intMonth, intYear))
                strErrorMsg = objDLog.ErrorMsg
                intErrorCode = objDLog.ErrorCode
                If Not tblStat Is Nothing AndAlso tblStat.Rows.Count > 0 Then
                    ReDim objLabel(tblStat.Rows.Count - 1)
                    ReDim objData(tblStat.Rows.Count - 1)
                    For inti = 0 To tblStat.Rows.Count - 1
                        objLabel(inti) = tblStat.Rows(inti).Item("Vietname")
                        objData(inti) = tblStat.Rows(inti).Item("Nor")
                    Next
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' StatDayModule method
        ' Purpose: create daymodule statistic
        ' Input: date
        ' Output: datatable result
        Public Function StatDayModule(ByVal intDay As Integer, ByVal intMonth As Integer, ByVal intYear As Integer) As DataTable
            Try
                StatDayModule = objDLog.StatDayModule(intDay, intMonth, intYear)
                strErrorMsg = objDLog.ErrorMsg
                intErrorCode = objDLog.ErrorCode
            Catch Ex As Exception
                strErrorMsg = Ex.Message
            Finally
            End Try
        End Function

        ' StatDayEvent method
        ' Purpose: create daymodule statistic
        ' Input: date
        ' Output: datatable result
        Public Function StatDayEvent(ByVal intParentID As Integer, ByVal intDay As Integer, ByVal intMonth As Integer, ByVal intYear As Integer) As DataTable
            Try
                StatDayEvent = objDLog.StatDayEvent(intParentID, intDay, intMonth, intYear)
                strErrorMsg = objDLog.ErrorMsg
                intErrorCode = objDLog.ErrorCode
            Catch Ex As Exception
                strErrorMsg = Ex.Message
            Finally
            End Try
        End Function

        Public Structure abc
            Dim strAdmin As String
        End Structure


        'StatWeekly method
        'Purpose: Create weekly statistic
        'Input: some information
        'Output: datatable result
        'Note: objSort is array content sort, choose color in graph. Ex:Biên mục, mượn trả..
        Public Function StatWeekly(ByVal strDateTo As String, ByVal strDateFrom As String, ByRef objLegend As Object, ByRef objData As Object)
            Dim tblData As DataTable
            Dim tblEventGroup As DataTable
            Dim objLegendID() As Object
            Dim objTemp() As Object
            Dim intMax As Integer
            Dim inti As Integer
            Dim intj As Integer
            Dim intk As Integer
            Dim intCount As Integer

            Try
                tblEventGroup = objBCDBS.ConvertTable(objDEventGroup.GetEventGroups)
                tblData = objDLog.StatWeekly(strDateTo, strDateFrom)
                If Not tblData Is Nothing Then
                    intMax = tblEventGroup.Rows.Count - 1

                    ReDim objLegendID(intMax)
                    ReDim objData(intMax)
                    ReDim objTemp(intMax)
                    ReDim objLegend(intMax)

                    For inti = 0 To intMax
                        objLegendID(inti) = CInt(tblEventGroup.Rows(inti).Item("ParentID"))
                        objLegend(inti) = tblEventGroup.Rows(inti).Item("VietName")
                    Next

                    For inti = LBound(objLegendID) To UBound(objLegendID)
                        ReDim Preserve objTemp(inti)(6)
                        For intk = 0 To UBound(objTemp) - 2
                            objTemp(inti)(intk) = 0
                        Next

                        'Select day in week
                        For intj = 2 To 7
                            tblData.DefaultView.RowFilter = "Thu = " & CStr(intj) & " And ParentID = " & CInt(objLegendID(inti))
                            If Not IsDBNull(tblData.DefaultView) Then
                                If tblData.DefaultView.Count > 0 Then
                                    For intCount = 0 To tblData.DefaultView.Count - 1
                                        objTemp(inti)(intj - 2) = objTemp(inti)(intj - 2) + CDbl(tblData.DefaultView.Item(intCount).Item("Dem"))
                                    Next
                                End If
                            End If
                        Next intj

                        tblData.DefaultView.RowFilter = "Thu = 1 And ParentID = " & CInt(objLegendID(inti))
                        If Not IsDBNull(tblData.DefaultView) Then
                            If tblData.DefaultView.Count > 0 Then
                                For intCount = 0 To tblData.DefaultView.Count - 1
                                    objTemp(inti)(6) = objTemp(inti)(6) + CDbl(tblData.DefaultView.Item(intCount).Item("Dem"))
                                Next
                            End If
                        End If
                        objData(inti) = objTemp(inti)
                    Next inti
                    tblData.Dispose()
                    tblData = Nothing
                End If
                strErrorMsg = objDLog.ErrorMsg
                intErrorCode = objDLog.ErrorCode
            Catch Ex As Exception
                strErrorMsg = Ex.Message
            Finally
            End Try
        End Function

        'Dispose method
        'Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objDLog Is Nothing Then
                    objDLog.Dispose(True)
                    objDLog = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace