' Name: clsBILLOutRequestCollection
' Purpose: Out ILL request
' Creator: Sondp
' Created Date: 25/11/2004
' Modification History: 

Imports System
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.ILL
Imports eMicLibAdmin.DataAccess.ILL
Imports System.Math

Namespace eMicLibAdmin.BusinessRules.ILL
    Public Class clsBILLOutRequestCollection
        Inherits clsBILLOutRequest

        ' ***********************************************************************************************
        ' Declare Private variables
        ' ***********************************************************************************************

        Private strRequestIDs As String = ""
        Private intStatusID As Integer = 0
        Private strSort As String = ""
        Private strLibIDs As String = ""
        Private intTimeMode As Int16 = 0
        Private strTimeFrom As String = ""
        Private strTimeTo As String = ""
        Private intDocType As Int16 = 0

        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        Private objDILLOutRequestCollection As New clsDILLOutRequestCollection
        Private objDIllLibrary As New clsDILLLibrary

        ' ***********************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' ***********************************************************************************************

        ' RequestIDs property
        Public Property RequestIDs() As String
            Get
                Return strRequestIDs
            End Get
            Set(ByVal Value As String)
                strRequestIDs = Value
            End Set
        End Property

        ' StatusID property
        Public Property StatusID() As Integer
            Get
                Return intStatusID
            End Get
            Set(ByVal Value As Integer)
                intStatusID = Value
            End Set
        End Property

        ' Sort property 
        Public Property Sort() As String
            Get
                Sort = strSort
            End Get
            Set(ByVal Value As String)
                strSort = Value
            End Set
        End Property

        ' LibIDs property
        Public Property LibIDs() As String
            Get
                Return strLibIDs
            End Get
            Set(ByVal Value As String)
                strLibIDs = Value
            End Set
        End Property

        ' TimeMode property
        Public Property TimeMode() As Int16
            Get
                Return intTimeMode
            End Get
            Set(ByVal Value As Int16)
                intTimeMode = Value
            End Set
        End Property

        ' TimeFrom property
        Public Property TimeFrom() As String
            Get
                Return strTimeFrom
            End Get
            Set(ByVal Value As String)
                strTimeFrom = Value
            End Set
        End Property

        ' TimeTo property
        Public Property TimeTo() As String
            Get
                Return strTimeTo
            End Get
            Set(ByVal Value As String)
                strTimeTo = Value
            End Set
        End Property

        ' DocType property
        Public Property DocType() As Int16
            Get
                Return intDocType
            End Get
            Set(ByVal Value As Int16)
                intDocType = Value
            End Set
        End Property

        ' ***********************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' ***********************************************************************************************

        ' Initialize method
        Public Overridable Overloads Sub Initialize()
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

            ' Init objDILLOutRequestCollection object
            objDILLOutRequestCollection.DBServer = strDBServer
            objDILLOutRequestCollection.ConnectionString = strConnectionString
            objDILLOutRequestCollection.Initialize()
            ' Init objDIllLibrary object  
            objDIllLibrary.DBServer = strDBServer
            objDIllLibrary.ConnectionString = strConnectionString
            objDIllLibrary.Initialize()

            ' Init base object
            MyBase.DBServer = strDBServer
            MyBase.ConnectionString = strConnectionString
            MyBase.Initialize()
        End Sub

        Public Function FilterORList() As DataTable
            Try
                objDILLOutRequestCollection.LibIDs = strLibIDs
                objDILLOutRequestCollection.TimeMode = intTimeMode
                objDILLOutRequestCollection.TimeFrom = objBCDBS.ConvertDateBack(strTimeFrom, False)
                objDILLOutRequestCollection.TimeTo = objBCDBS.ConvertDateBack(strTimeTo, False)
                objDILLOutRequestCollection.Title = objBCSP.ConvertItBack(strTitle)
                objDILLOutRequestCollection.Author = objBCSP.ConvertItBack(strAuthor)
                objDILLOutRequestCollection.PatronName = objBCSP.ConvertItBack(strPatronName)
                objDILLOutRequestCollection.PatronCode = objBCSP.ConvertItBack(strPatronCode)
                objDILLOutRequestCollection.DocType = intDocType
                FilterORList = objDILLOutRequestCollection.FilterORList
                strErrorMsg = objDILLOutRequestCollection.ErrorMsg
                intErrorCode = objDILLOutRequestCollection.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetORList() As Object

            Dim TblRet As New DataView
            Dim tbl As New DataTable
            Try
                objDILLOutRequestCollection.StatusID = intStatusID
                objDILLOutRequestCollection.RequestIDs = strRequestIDs
                tbl = objBCDBS.ConvertTable(objDILLOutRequestCollection.GetORList, "TITLE", True)

                If strSort.Length = 0 Then
                    GetORList = tbl
                ElseIf UCase(strSort) = "STATUS" Or UCase(strSort) = "REQUESTID" Or UCase(strSort) = "LIBRARYSYMBOL" Or UCase(strSort) = "PRIORITY" Or UCase(strSort) = "SERVICETYPE" Then 'DataView de sort
                    Dim dv As New DataView(tbl)
                    dv.Sort = strSort
                    Return dv
                ElseIf UCase(strSort) = "CREATEDDATE" Then
                    Dim dv As New DataView(tbl)
                    dv = objBCDBS.SortTable(tbl, "CREATEDDATE").DefaultView
                    Return dv
                Else 'Sort bang Unicode                    
                    Dim dv As New DataView(tbl)
                    dv = objBCDBS.SortTable(tbl, "TITLE").DefaultView
                    Return dv
                End If

                intErrorCode = objDILLOutRequestCollection.ErrorCode
                strErrorMsg = objDILLOutRequestCollection.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetILLInRequestProcess
        ' Purpose: Get the ill incoming request processing
        ' Output: datatable result
        Public Function GetILLOutRequestProcess(ByRef intNumOfReq As Integer) As DataTable
            Try
                GetILLOutRequestProcess = objBCDBS.ConvertTable(objDILLOutRequestCollection.GetILLOutRequestProcess(intNumOfReq))
                intErrorCode = objDILLOutRequestCollection.ErrorCode
                strErrorMsg = objDILLOutRequestCollection.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function CreateGeneralReport() As DataTable
            Dim tblILL1 As New DataTable, tblILL2 As New DataTable, tblILL3 As New DataTable, tblOutPut As New DataTable
            Dim dtrow1 As DataRow, dtrow2 As DataRow, dtrow3 As DataRow, row As DataRow
            Dim collum As DataColumn
            Dim dtrows1() As DataRow, dtrows2() As DataRow, dtrows3() As DataRow
            Dim inti As Integer
            Dim lnginR1 As Long, lngoutR1 As Long, lnginR2 As Long, lngoutR2 As Long, lnginR3 As Long, lngoutR3 As Long, temp As Long
            Dim strscaleR1 As String, strtimeR1 As String, strscaleR2 As String, strtimeR2 As String, strscaleR3 As String, strtimeR3 As String

            Try
                ' Make new datatable ( have 12 columns )
                tblOutPut = MakeNamesTable(False)
                ' Get data to insert into tblOutPut
                tblILL1 = objDILLOutRequestCollection.CreateGeneralReport(1)
                tblILL2 = objDILLOutRequestCollection.CreateGeneralReport(2)
                tblILL3 = objDILLOutRequestCollection.CreateGeneralReport(3)
                strErrorMsg = objDILLOutRequestCollection.ErrorMsg
                interrorcode = objDILLOutRequestCollection.ErrorCode
                ' Process here
                lnginR1 = 0
                lngoutR1 = 0
                lnginR2 = 0
                lngoutR2 = 0
                lnginR3 = 0
                lngoutR3 = 0
                strscaleR1 = "-"
                strtimeR1 = "-"
                strscaleR2 = "-"
                strtimeR2 = "-"
                strscaleR3 = "-"
                strtimeR3 = "-"
                temp = 0
                ' First cell
                If Not tblILL1 Is Nothing Then
                    If tblILL1.Rows.Count > 0 Then
                        For inti = 0 To tblILL1.Rows.Count - 1
                            If Not IsDBNull(tblILL1.Rows(inti).Item("NOR")) And CStr(tblILL1.Rows(inti).Item("NOR")) <> "" And IsNumeric(tblILL1.Rows(inti).Item("NOR")) Then
                                lnginR1 = lnginR1 + CLng(tblILL1.Rows(inti).Item("NOR"))
                            End If
                        Next
                        dtrows2 = tblILL1.Select("ServiceType=1")
                        If dtrows2.Length > 0 Then
                            For Each dtrow2 In dtrows2
                                If Not IsDBNull(dtrow2.Item("NOR")) And CStr(dtrow2.Item("NOR")) <> "" And IsNumeric(dtrow2.Item("NOR")) Then
                                    lnginR2 = lnginR2 + CLng(dtrow2.Item("NOR"))
                                End If
                            Next
                        End If
                        dtrows3 = tblILL1.Select("ServiceType=2")
                        If dtrows2.Length > 0 Then
                            For Each dtrow3 In dtrows3
                                If Not IsDBNull(dtrow3.Item("NOR")) And CStr(dtrow3.Item("NOR")) <> "" And IsNumeric(dtrow3.Item("NOR")) Then
                                    lnginR3 = lnginR3 + CLng(dtrow3.Item("NOR"))
                                End If
                            Next
                        End If
                    End If
                End If
                ' Second cell
                If Not tblILL2 Is Nothing Then
                    If tblILL2.Rows.Count > 0 Then
                        For inti = 0 To tblILL2.Rows.Count - 1
                            If Not IsDBNull(tblILL2.Rows(inti).Item("NOR")) And CStr(tblILL2.Rows(inti).Item("NOR")) <> "" And IsNumeric(tblILL2.Rows(inti).Item("NOR")) Then
                                lngoutR1 = lngoutR1 + CLng(tblILL2.Rows(inti).Item("NOR"))
                            End If
                        Next
                        dtrows2 = tblILL2.Select("ServiceType=1")
                        If dtrows2.Length > 0 Then
                            For Each dtrow2 In dtrows2
                                If Not IsDBNull(dtrow2.Item("NOR")) And CStr(dtrow2.Item("NOR")) <> "" And IsNumeric(dtrow2.Item("NOR")) Then
                                    lngoutR2 = lngoutR2 + CLng(dtrow2.Item("NOR"))
                                End If
                            Next
                        End If
                        dtrows3 = tblILL2.Select("ServiceType=2")
                        If dtrows3.Length > 0 Then
                            For Each dtrow3 In dtrows3
                                If Not IsDBNull(dtrow3.Item("NOR")) And CStr(dtrow3.Item("NOR")) <> "" And IsNumeric(dtrow3.Item("NOR")) Then
                                    lngoutR3 = lngoutR3 + CLng(dtrow3.Item("NOR"))
                                End If
                            Next
                        End If
                    End If
                End If
                ' Third cell
                If lnginR1 > 0 Then
                    strscaleR1 = CStr(Round(lngoutR1 * 100 / lnginR1, 1))
                End If
                If lnginR2 > 0 Then
                    strscaleR2 = CStr(Round(lngoutR2 * 100 / lnginR2, 1))
                End If
                If lnginR3 > 0 Then
                    strscaleR3 = CStr(Round(lngoutR3 * 100 / lnginR3, 1))
                End If
                If strscaleR1 = "0" Then
                    strscaleR1 = "-"
                End If
                If strscaleR2 = "0" Then
                    strscaleR2 = "-"
                End If
                If strscaleR3 = "0" Then
                    strscaleR3 = "-"
                End If
                ' Four cell
                If Not tblILL3 Is Nothing Then
                    If tblILL3.Rows.Count > 0 Then
                        For inti = 0 To tblILL3.Rows.Count - 1
                            If Not IsDBNull(tblILL3.Rows(inti).Item("NOR")) And CStr(tblILL3.Rows(inti).Item("NOR")) <> "" And IsNumeric(tblILL3.Rows(inti).Item("NOR")) And lnginR1 > 0 Then
                                temp = temp + CLng(tblILL3.Rows(inti).Item("NOR"))
                            End If
                        Next
                        If lnginR1 > 0 Then
                            strtimeR1 = CStr(Round(temp / lnginR1, 1))
                        End If
                        If strtimeR1 = "0" Then
                            strtimeR1 = "-"
                        End If
                        dtrows2 = tblILL3.Select("ServiceType=1")
                        If dtrows2.Length > 0 Then
                            For Each dtrow2 In dtrows2
                                If Not IsDBNull(dtrow2.Item("NOR")) And CStr(dtrow2.Item("NOR")) <> "" And IsNumeric(dtrow2.Item("NOR")) And lnginR2 > 0 Then
                                    strtimeR2 = CStr(Round(CLng(dtrow2.Item("NOR")) / lnginR2, 1))
                                End If
                            Next
                            If strtimeR2 = "0" Then
                                strtimeR2 = "-"
                            End If
                        End If
                        dtrows3 = tblILL3.Select("ServiceType=2")
                        If dtrows3.Length > 0 Then
                            For Each dtrow3 In dtrows3
                                If Not IsDBNull(dtrow3.Item("NOR")) And CStr(dtrow3.Item("NOR")) <> "" And IsNumeric(dtrow2.Item("NOR")) And lnginR3 > 0 Then
                                    strtimeR3 = CStr(Round(CLng(dtrow3.Item("NOR")) / lnginR3, 1))
                                End If
                            Next
                            If strtimeR3 = "0" Then
                                strtimeR3 = "-"
                            End If
                        End If
                    End If
                End If
                ' Bind data to tblOutPut
                row = tblOutPut.NewRow
                ' Group 1
                row("inR1") = CStr(lnginR1)
                row("outR1") = CStr(lngoutR1)
                row("scaleR1") = strscaleR1
                row("timeR1") = strtimeR1
                ' Group 2
                row("inR2") = CStr(lnginR2)
                row("outR2") = CStr(lngoutR2)
                row("scaleR2") = strscaleR2
                row("timeR2") = strtimeR2
                ' Group 3
                row("inR3") = CStr(lnginR3)
                row("outR3") = CStr(lngoutR3)
                row("scaleR3") = strscaleR3
                row("timeR3") = strtimeR3
                tblOutPut.Rows.Add(row)
                CreateGeneralReport = tblOutPut
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function CreateDeniedORReport() As DataTable
            Dim tbLibSymbol As DataTable
            Dim tbReasonCode As DataTable
            Dim tbInOut As DataTable
            Dim tbResult As New DataTable
            Dim itemCollum As DataColumn
            Dim itemRow As DataRow
            Dim i As Integer
            Dim j As Integer

            Try
                'get data 
                tbLibSymbol = objBCDBS.ConvertTable(objDIllLibrary.GetLib(0))
                tbReasonCode = objBCDBS.ConvertTable(objDILLOutRequestCollection.GetIllReasonCode)
                tbInOut = objBCDBS.ConvertTable(objDILLOutRequestCollection.CreateDeniedORReport)
                'add new column 
                itemCollum = New DataColumn
                itemCollum.DataType = System.Type.GetType("System.String")
                itemCollum.ColumnName = "LibSymbol"
                itemCollum.DefaultValue = "--"
                tbResult.Columns.Add(itemCollum)
                For i = 0 To tbReasonCode.Rows.Count - 1
                    itemCollum = New DataColumn
                    itemCollum.DataType = System.Type.GetType("System.Int32")
                    itemCollum.ColumnName = CStr(tbReasonCode.Rows(i).Item("ReasonCode"))
                    itemCollum.DefaultValue = 0
                    tbResult.Columns.Add(itemCollum)
                Next
                'set data into tblResult
                For i = 0 To tbLibSymbol.Rows.Count - 1
                    itemRow = tbResult.NewRow
                    itemRow("LibSymbol") = CStr(tbLibSymbol.Rows(i).Item("LibrarySymbol"))
                    For j = 0 To tbReasonCode.Rows.Count - 1
                        tbInOut.DefaultView.RowFilter = "ReID=" + CStr(tbLibSymbol.Rows(i).Item("ID")) + " AND ReasonID=" + CStr(tbReasonCode.Rows(j).Item("ID"))
                        If tbInOut.DefaultView.Count > 0 Then
                            itemRow(j + 1) = CInt(tbInOut.DefaultView(0).Item("NOR"))
                        End If
                    Next
                    tbResult.Rows.Add(itemRow)
                Next
                CreateDeniedORReport = tbResult
                strErrorMsg = objDILLOutRequestCollection.ErrorMsg
                intErrorCode = objDILLOutRequestCollection.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        Public Function CreateServReport() As DataTable
            Dim tblILL0 As New DataTable, tblILL1 As New DataTable, tblILL2 As New DataTable, tblILL3 As New DataTable
            Dim tblOutPut As New DataTable
            Dim dtrow0 As DataRow, dtrow1 As DataRow, dtrow2 As DataRow, dtrow3 As DataRow, row As DataRow
            Dim collum As DataColumn
            Dim dtrows0() As DataRow, dtrows1() As DataRow, dtrows2() As DataRow, dtrows3() As DataRow
            Dim inti, intj, intID, i As Integer
            Dim lnginR1, lngoutR1, lnginR2, lngoutR2, lnginR3, lngoutR3, temp As Long
            Dim strscaleR1, strtimeR1, strscaleR2, strtimeR2, strscaleR3, strtimeR3, LibName As String

            Try
                ' Make new datatable ( have 13 columns )
                tblOutPut = MakeNamesTable(True)
                objDILLOutRequestCollection.LibID = intLibID
                ' Get data to insert into tblOutPut
                ' Table ILL_LIBRARY
                tblILL0 = objDILLOutRequestCollection.CreateServReport(0)
                tblILL1 = objDILLOutRequestCollection.CreateServReport(1)
                tblILL2 = objDILLOutRequestCollection.CreateServReport(2)
                tblILL3 = objDILLOutRequestCollection.CreateServReport(3)
                strErrorMsg = objDILLOutRequestCollection.ErrorMsg
                interrorcode = objDILLOutRequestCollection.ErrorCode
                ' Process here
                If Not tblILL0 Is Nothing Then
                    If tblILL0.Rows.Count > 0 Then
                        For i = 0 To tblILL0.Rows.Count - 1
                            inti = 0
                            lnginR1 = 0
                            lngoutR1 = 0
                            lnginR2 = 0
                            lngoutR2 = 0
                            lnginR3 = 0
                            lngoutR3 = 0
                            strscaleR1 = "-"
                            strtimeR1 = "-"
                            strscaleR2 = "-"
                            strtimeR2 = "-"
                            strscaleR3 = "-"
                            strtimeR3 = "-"
                            temp = 0
                            LibName = tblILL0.Rows(i).Item("LibrarySymbol")
                            ' First column
                            dtrows1 = tblILL1.Select("ID=" & tblILL0.Rows(i).Item("ID"))
                            If dtrows1.Length > 0 Then
                                For Each dtrow1 In dtrows1
                                    If Not dtrow1.Item("NOR") Is Nothing Then
                                        If Not IsDBNull(dtrow1.Item("NOR")) And CStr(dtrow1.Item("NOR")) <> "" And IsNumeric(dtrow1.Item("NOR")) Then
                                            lnginR1 = lnginR1 + CLng(dtrow1.Item("NOR"))
                                        End If
                                    End If
                                Next
                                dtrows2 = tblILL1.Select("ServiceType=1 AND ID=" & tblILL0.Rows(i).Item("ID"))
                                If dtrows2.Length > 0 Then
                                    For Each dtrow2 In dtrows2
                                        If Not dtrow2.Item("NOR") Is Nothing Then
                                            If Not IsDBNull(dtrow2.Item("NOR")) And CStr(dtrow2.Item("NOR")) <> "" And IsNumeric(dtrow2.Item("NOR")) Then
                                                lnginR2 = lnginR2 + CLng(dtrow2.Item("NOR"))
                                            End If
                                        End If
                                    Next
                                End If
                                dtrows3 = tblILL1.Select("ServiceType=2 AND ID=" & tblILL0.Rows(i).Item("ID"))
                                If dtrows3.Length > 0 Then
                                    For Each dtrow3 In dtrows3
                                        If Not dtrow3.Item("NOR") Is Nothing Then
                                            If Not IsDBNull(dtrow3.Item("NOR")) And CStr(dtrow3.Item("NOR")) <> "" And IsNumeric(dtrow3.Item("NOR")) Then
                                                lnginR3 = lnginR3 + CLng(dtrow3.Item("NOR"))
                                            End If
                                        End If
                                    Next
                                End If
                            End If
                            ' Second column
                            dtrows1 = tblILL2.Select("ID=" & tblILL0.Rows(i).Item("ID"))
                            If dtrows1.Length > 0 Then
                                For Each dtrow1 In dtrows1
                                    If Not dtrow1.Item("NOR") Is Nothing Then
                                        If Not IsDBNull(dtrow1.Item("NOR")) And CStr(dtrow1.Item("NOR")) <> "" And IsNumeric(dtrow1.Item("NOR")) Then
                                            lngoutR1 = lngoutR1 + CLng(dtrow1.Item("NOR"))
                                        End If
                                    End If
                                Next
                                dtrows2 = tblILL2.Select("ServiceType=1 AND ID=" & tblILL0.Rows(i).Item("ID"))
                                If dtrows2.Length > 0 Then
                                    For Each dtrow2 In dtrows2
                                        If Not dtrow2.Item("NOR") Is Nothing Then
                                            If Not IsDBNull(dtrow2.Item("NOR")) And CStr(dtrow2.Item("NOR")) <> "" And IsNumeric(dtrow2.Item("NOR")) Then
                                                lngoutR2 = lngoutR2 + CLng(dtrow2.Item("NOR"))
                                            End If
                                        End If
                                    Next
                                End If
                                dtrows3 = tblILL2.Select("ServiceType=2 AND ID=" & tblILL0.Rows(i).Item("ID"))
                                If dtrows3.Length > 0 Then
                                    For Each dtrow3 In dtrows3
                                        If Not dtrow3.Item("NOR") Is Nothing Then
                                            If Not IsDBNull(dtrow3.Item("NOR")) And CStr(dtrow3.Item("NOR")) <> "" And IsNumeric(dtrow3.Item("NOR")) Then
                                                lngoutR3 = lngoutR3 + CLng(dtrow3.Item("NOR"))
                                            End If
                                        End If
                                    Next
                                End If
                            End If
                            ' Third column
                            If lnginR1 > 0 Then
                                strscaleR1 = CStr(Round(lngoutR1 * 100 / lnginR1, 1))
                            End If
                            If lnginR2 > 0 Then
                                strscaleR2 = CStr(Round(lngoutR2 * 100 / lnginR2, 1))
                            End If
                            If lnginR3 > 0 Then
                                strscaleR3 = CStr(Round(lngoutR3 * 100 / lnginR3, 1))
                            End If
                            If strscaleR1 = "0" Then
                                strscaleR1 = "-"
                            End If
                            If strscaleR2 = "0" Then
                                strscaleR2 = "-"
                            End If
                            If strscaleR3 = "0" Then
                                strscaleR3 = "-"
                            End If
                            ' Four collumn
                            temp = 0
                            dtrows1 = tblILL3.Select("ID=" & tblILL0.Rows(i).Item("ID"))
                            If dtrows1.Length > 0 Then
                                For Each dtrow1 In dtrows1
                                    If Not dtrow1.Item("NOR") Is Nothing Then
                                        If Not IsDBNull(dtrow1.Item("NOR")) AndAlso CStr(dtrow1.Item("NOR")) <> "" And IsNumeric(dtrow1.Item("NOR")) Then
                                            temp = temp + CLng(dtrow1.Item("NOR"))
                                        End If
                                    End If
                                Next
                                If lnginR1 > 0 Then
                                    strtimeR1 = CStr(Round(temp / lnginR1, 1))
                                End If
                                If strtimeR1 = "0" Then
                                    strtimeR1 = "-"
                                End If
                                temp = 0
                                dtrows2 = tblILL3.Select("ServiceType=1 AND ID=" & tblILL0.Rows(i).Item("ID"))
                                If dtrows2.Length > 0 Then
                                    For Each dtrow2 In dtrows2
                                        If Not dtrow2.Item("NOR") Is Nothing Then
                                            If Not IsDBNull(dtrow2.Item("NOR")) AndAlso CStr(dtrow2.Item("NOR")) <> "" And IsNumeric(dtrow2.Item("NOR")) Then
                                                temp = temp + CLng(dtrow2.Item("NOR"))
                                            End If
                                        End If
                                    Next
                                    'If temp > 0 Then
                                    '    strtimeR2 = CStr(temp)
                                    'End If
                                    If lnginR2 > 0 Then
                                        strtimeR2 = CStr(Round(temp / lnginR2, 1))
                                    End If
                                    If strtimeR2 = "0" Then
                                        strtimeR2 = "-"
                                    End If
                                End If
                                temp = 0
                                dtrows3 = tblILL3.Select("ServiceType=2 AND ID=" & tblILL0.Rows(i).Item("ID"))
                                For Each dtrow3 In dtrows3
                                    If Not dtrow3.Item("NOR") Is Nothing Then
                                        If Not IsDBNull(dtrow3.Item("NOR")) AndAlso CStr(dtrow3.Item("NOR")) <> "" And IsNumeric(dtrow3.Item("NOR")) Then
                                            temp = temp + CLng(dtrow3.Item("NOR"))
                                        End If
                                    End If
                                Next
                                'If temp > 0 Then
                                '    strtimeR3 = CStr(temp)
                                'End If
                                If lnginR3 > 0 Then
                                    strtimeR3 = CStr(Round(temp / lnginR3, 1))
                                End If
                                If strtimeR3 = "0" Then
                                    strtimeR3 = "-"
                                End If
                            End If
                            ' Add data to table OutPut
                            row = tblOutPut.NewRow
                            ' LibrarySymbol
                            row("LibrarySymbol") = LibName
                            ' Group 1
                            row("inR1") = CStr(lnginR1)
                            row("outR1") = CStr(lngoutR1)
                            row("scaleR1") = strscaleR1
                            row("timeR1") = strtimeR1
                            ' Group 2
                            row("inR2") = CStr(lnginR2)
                            row("outR2") = CStr(lngoutR2)
                            row("scaleR2") = strscaleR2
                            row("timeR2") = strtimeR2
                            ' Group 3
                            row("inR3") = CStr(lnginR3)
                            row("outR3") = CStr(lngoutR3)
                            row("scaleR3") = strscaleR3
                            row("timeR3") = strtimeR3
                            tblOutPut.Rows.Add(row)
                        Next
                    End If
                End If
                CreateServReport = tblOutPut
                strErrorMsg = objDILLOutRequestCollection.ErrorMsg
                intErrorCode = objDILLOutRequestCollection.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Create new table have 13 ( if boolflage=true) or 12 (if boolfalge=false) columns
        Private Function MakeNamesTable(Optional ByVal boolflage As Boolean = True) As DataTable
            Dim tblName As New DataTable
            Dim itemCollum As New DataColumn
            ' Total
            Dim LibSymbol As New DataColumn
            Dim inR1 As New DataColumn
            Dim outR1 As New DataColumn
            Dim scaleR1 As New DataColumn
            Dim timeR1 As New DataColumn
            ' Retrieve/ Check out
            Dim inR2 As New DataColumn
            Dim outR2 As New DataColumn
            Dim scaleR2 As New DataColumn
            Dim timeR2 As New DataColumn
            ' Scale 
            Dim inR3 As New DataColumn
            Dim outR3 As New DataColumn
            Dim scaleR3 As New DataColumn
            Dim timeR3 As New DataColumn
            ' Time 
            Dim inR4 As New DataColumn
            Dim outR4 As New DataColumn
            Dim scaleR4 As New DataColumn
            Dim timeR4 As New DataColumn
            Dim inti As Integer
            ' Make new datatable
            If boolflage = True Then
                LibSymbol.DataType = System.Type.GetType("System.String")
                LibSymbol.ColumnName = "LibrarySymbol"
                tblName.Columns.Add(LibSymbol)
            End If
            ' Group 1
            inR1.DataType = System.Type.GetType("System.Int32")
            inR1.ColumnName = "inR1"
            inR1.DefaultValue = 0
            tblName.Columns.Add(inR1)
            '-----------
            outR1.DataType = System.Type.GetType("System.Int32")
            outR1.ColumnName = "outR1"
            outR1.DefaultValue = 0
            tblName.Columns.Add(outR1)
            '----------
            scaleR1.DataType = System.Type.GetType("System.String")
            scaleR1.ColumnName = "scaleR1"
            scaleR1.DefaultValue = "-"
            tblName.Columns.Add(scaleR1)
            '----------
            timeR1.DataType = System.Type.GetType("System.String")
            timeR1.ColumnName = "timeR1"
            timeR1.DefaultValue = "-"
            tblName.Columns.Add(timeR1)
            ' Group 2 
            inR2.DataType = System.Type.GetType("System.Int32")
            inR2.ColumnName = "inR2"
            inR2.DefaultValue = 0
            tblName.Columns.Add(inR2)
            '-----------
            outR2.DataType = System.Type.GetType("System.Int32")
            outR2.ColumnName = "outR2"
            outR2.DefaultValue = 0
            tblName.Columns.Add(outR2)
            '----------
            scaleR2.DataType = System.Type.GetType("System.String")
            scaleR2.ColumnName = "scaleR2"
            scaleR2.DefaultValue = "-"
            tblName.Columns.Add(scaleR2)
            '----------
            timeR2.DataType = System.Type.GetType("System.String")
            timeR2.ColumnName = "timeR2"
            timeR2.DefaultValue = "-"
            tblName.Columns.Add(timeR2)
            ' Group 3
            inR3.DataType = System.Type.GetType("System.Int32")
            inR3.ColumnName = "inR3"
            inR3.DefaultValue = 0
            tblName.Columns.Add(inR3)
            '-----------
            outR3.DataType = System.Type.GetType("System.Int32")
            outR3.ColumnName = "outR3"
            outR3.DefaultValue = 0
            tblName.Columns.Add(outR3)
            '----------
            scaleR3.DataType = System.Type.GetType("System.String")
            scaleR3.ColumnName = "scaleR3"
            scaleR3.DefaultValue = "-"
            tblName.Columns.Add(scaleR3)
            '----------
            timeR3.DataType = System.Type.GetType("System.String")
            timeR3.ColumnName = "timeR3"
            timeR3.DefaultValue = "-"
            tblName.Columns.Add(timeR3)
            MakeNamesTable = tblName
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objDILLOutRequestCollection Is Nothing Then
                    objDILLOutRequestCollection.Dispose(True)
                    objDILLOutRequestCollection = Nothing
                End If
                If Not objDIllLibrary Is Nothing Then
                    Call objDIllLibrary.Dispose(True)
                    objDIllLibrary = Nothing
                End If
            Finally
                MyBase.Dispose(True)
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace