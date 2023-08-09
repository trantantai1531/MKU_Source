' Class: clsBBinding
' Purpose: Management claim template
' Creator: Oanhtn
' Created Date: 20/09/2004
' Modification History:
'+ 25/09/2004 by Sondp: 
Imports System
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Serial
Imports System.ValueType
Namespace eMicLibAdmin.BusinessRules.Serial
    Public Class clsBClaimTemplate
        Inherits clsBCommonTemplate
        ' *******************************************************************************************************
        ' Declare Private variables
        ' *******************************************************************************************************

        Private objDClaimTemplate As New clsDClaimTemplate
        Private objDPeriodical As New clsDPeriodical
        Private objDPeriodicalCollection As New clsDPeriodicalCollection
        Private objBCT As New clsBCommonTemplate
        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************
        Private colHeaderData As New Collection 'data for Template Header
        Private colContentData As New Collection 'data for Template Content
        Private colColumnTitle As New Collection
        Private colFooterData As New Collection ' data for Template Footer

        Private strCollums As String
        Private strCollumCaption As String
        Private strPageHeader As String
        Private strCollumWidth As String
        Private strCollumAlign As String
        Private strCollumFormat As String
        Private strTableColor As String
        Private strOddColor As String
        Private strEventColor As String
        Private strPageFooter As String
        Private strCollumFooter As String
        Private lngItemID As Long
        Private chrClaimCycleMode As Char
        Private strIssueYear As String
        Private strIDs As String = ""
        Private chrSelectMode As Char
        Private strFileName As String
        Private dtCreatedDate As DateTime
        ' ItemID property
        Public Property ItemID() As Long
            Get
                Return lngItemID
            End Get
            Set(ByVal Value As Long)
                lngItemID = Value
            End Set
        End Property

        'get/set strFileName to inrert into table SYS_DOWNLOAD_FILE
        Public Property DownloadFileName() As String
            Get
                Return (strFileName)
            End Get
            Set(ByVal Value As String)
                strFileName = Value
            End Set
        End Property
        'get/set dtCreatedDate to insert into table SYS_DOWNLOAD_FILE
        Public Property DownloadFileCreateDate() As DateTime
            Get
                Return (dtCreatedDate)
            End Get
            Set(ByVal Value As DateTime)
                dtCreatedDate = Value
            End Set
        End Property

        'IDs property
        Public Property IDs() As String
            Get
                Return (strIDs)
            End Get
            Set(ByVal Value As String)
                strIDs = Value
            End Set
        End Property
        'ClaimCycleMode  property
        Public Property ClaimCycleMode() As Char
            Get
                Return (chrClaimCycleMode)
            End Get
            Set(ByVal Value As Char)
                chrClaimCycleMode = Value
            End Set
        End Property
        'IssueDate property
        Public Property IssueYear() As String
            Get
                Return (strIssueYear)
            End Get
            Set(ByVal Value As String)
                strIssueYear = Value
            End Set
        End Property

        ' HeaderData property
        Property HeaderData() As Collection
            Get
                Return colHeaderData
            End Get
            Set(ByVal Value As Collection)
                colHeaderData = Value
            End Set
        End Property

        ' ColumnTitle property
        Property ColumnTitle() As Collection
            Get
                Return (colColumnTitle)
            End Get
            Set(ByVal Value As Collection)
                colColumnTitle = Value
            End Set
        End Property

        ' ContentData property
        Property ContentData() As Collection
            Get
                Return colContentData
            End Get
            Set(ByVal Value As Collection)
                colContentData = Value
            End Set
        End Property

        ' FooterData property
        Property FooterData() As Collection
            Get
                Return colFooterData
            End Get
            Set(ByVal Value As Collection)
                colFooterData = Value
            End Set
        End Property

        'Collums property
        Property Collums() As String
            Get
                Return strCollums
            End Get
            Set(ByVal Value As String)
                strCollums = Value
            End Set
        End Property

        ' PageHeader property
        Property PageHeader() As String
            Get
                Return (strPageHeader)
            End Get
            Set(ByVal Value As String)
                strPageHeader = Value
            End Set
        End Property

        'CollumCaption property
        Property CollumCaption() As String
            Get
                Return strCollumCaption
            End Get
            Set(ByVal Value As String)
                strCollumCaption = Value
            End Set
        End Property

        'CollumWidth property
        Property CollumWidth() As String
            Get
                Return strCollumWidth
            End Get
            Set(ByVal Value As String)
                strCollumWidth = Value
            End Set
        End Property

        'CollumAlign property
        Property CollumAlign() As String
            Get
                Return strCollumAlign
            End Get
            Set(ByVal Value As String)
                strCollumAlign = Value
            End Set
        End Property

        'CollumFormat property
        Property CollumFormat() As String
            Get
                Return strCollumFormat
            End Get
            Set(ByVal Value As String)
                strCollumFormat = Value
            End Set
        End Property

        ' TableColor property
        Property TableColor() As String
            Get
                Return (strTableColor)
            End Get
            Set(ByVal Value As String)
                strTableColor = Value
            End Set
        End Property

        ' OddColor property
        Property OddColor() As String
            Get
                Return (strOddColor)
            End Get
            Set(ByVal Value As String)
                strOddColor = Value
            End Set
        End Property

        ' EventColor property
        Property EventColor() As String
            Get
                Return (strEventColor)
            End Get
            Set(ByVal Value As String)
                strEventColor = Value
            End Set
        End Property

        ' PageFooter property
        Property PageFooter() As String
            Get
                Return (strPageFooter)
            End Get
            Set(ByVal Value As String)
                strPageFooter = Value
            End Set
        End Property
        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Initialize method
        Public Overloads Sub Initialize()
            ' Init objBCT object
            objBCT.ConnectionString = strConnectionString
            objBCT.DBServer = strDBServer
            objBCT.InterfaceLanguage = strInterfaceLanguage
            Call objBCT.Initialize()

            ' Init MyBase object
            MyBase.DBServer = strDBServer
            MyBase.ConnectionString = strConnectionString
            MyBase.InterfaceLanguage = strInterfaceLanguage
            Call MyBase.Initialize()

            ' Init objDClaimTemplate object
            objDClaimTemplate.DBServer = strDBServer
            objDClaimTemplate.ConnectionString = strConnectionString
            objDClaimTemplate.Initialize()
            'Init objDPeriodical object
            objDPeriodical.DBServer = strDBServer
            objDPeriodical.ConnectionString = ConnectionString
            objDPeriodical.Initialize()
            ' Init objDPeriodicalCollection
            objDPeriodicalCollection.DBServer = strDBServer
            objDPeriodicalCollection.ConnectionString = ConnectionString
            objDPeriodicalCollection.Initialize()
        End Sub


        '*****************************************  WILL REMOVE THEY  ********************************************
        '---------------------------------------------------------------------------------------------------
        'purpose: insert a new record into table SYS_DOWNLOAD_FILE
        'in: strFileName, dtCreatedDate
        'out: true/false
        '---------------------------------------------------------------------------------------------------
        Public Function InsertSysDownloadFile() As Boolean
            Try
                objDClaimTemplate.DownloadFileName = strFileName
                objDClaimTemplate.DownloadFileCreateDate = dtCreatedDate
                Return objDClaimTemplate.InsertSysDownloadFile
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        'purpose: define new structure
        'creator: Sondp
        Public Structure Metric
            Public arrStrOutMsg As String()
            Public arrStrEmailAddress As String()
        End Structure

        ' PreviewClaimUnReceivedIssues method
        ' Purpose: get unreceived issues of the selected periodical
        ' Input: ClaimTemplateID, string UnRecivedIssues IDs
        ' Output: Claim string
        ' Creator: Sondp
        Public Function PreviewClaimUnReceivedIssues() As Metric
            ' Declare variables
            Dim objMetric As Metric
            'Dim objLBTemplate As New TVCOMLib.LibolTemplate
            Dim bColLabel() As String
            Dim bUserColLabel() As String
            Dim bUserColWidth() As String
            Dim bCols() As String
            Dim bUserColAlign() As String 'for Align
            Dim bUserColFormat() As String 'for Format
            Dim strOutMsg As String()
            Dim strEmailAddess As String()
            Dim strChangeColor As String = "#FFFFFF"
            Dim objFields As Object
            Dim objStream As Object
            Dim objData As Object
            Dim objarrContent As Object
            Dim tblClaimTemplate As DataTable
            Dim tblUnReceivedIssues As DataTable
            Dim tblVendor As DataTable
            Dim tblField200s As DataTable
            Dim intk As Integer
            Dim inti As Integer
            Dim intj As Integer
            Dim mw As String ' width collum
            Dim ma As String ' align collum
            Dim mf As String ' format collum
            Dim boomf As Boolean ' control format template

            'get ClaimTemplate
            TemplateType = 6
            LibID = intLibID
            tblClaimTemplate = GetTemplate()
            If Not tblClaimTemplate Is Nothing Then
                If tblClaimTemplate.Rows.Count > 0 Then
                    objarrContent = Split(tblClaimTemplate.Rows(0).Item("Content"), Chr(9))
                    'Header
                    If Not IsDBNull(objarrContent(0)) Then
                        strHeader = objBCSP.ToUTF8(Replace(objarrContent(0), "<~>", vbCrLf))
                    Else
                        strHeader = " "
                    End If
                    Try
                        If Not IsDBNull(objarrContent(1)) Then
                            strPageHeader = objarrContent(1)
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If Not IsDBNull(objarrContent(2)) Then
                            bCols = Split(objarrContent(2), "<~>") 'Colllums
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If Not IsDBNull(objarrContent(3)) Then
                            bUserColLabel = Split(objarrContent(3), "<~>") 'Collumns Caption
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If Not IsDBNull(objarrContent(4)) Then
                            bUserColWidth = Split(objarrContent(4), "<~>") 'Collumns width
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If Not IsDBNull(objarrContent(5)) Then
                            bUserColAlign = Split(objarrContent(5), "<~>") 'Collumns Align
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If Not IsDBNull(objarrContent(6)) Then
                            bUserColFormat = Split(objarrContent(6), "<~>") 'Collumns Format      
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If Not IsDBNull(objarrContent(7)) Then
                            strTableColor = objarrContent(7)
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                    Catch ex As Exception

                    End Try
                    If strTableColor & "" = "" Then
                        strTableColor = "#FFFFFF"
                    End If
                    Try
                        If Not IsDBNull(objarrContent(8)) Then
                            strEventColor = objarrContent(8)
                        End If
                    Catch ex As Exception

                    End Try
                    If strEventColor & "" = "" Then
                        strEventColor = "#CDCDCD"
                    End If
                    Try
                        If Not IsDBNull(objarrContent(9)) Then
                            strOddColor = objarrContent(9)
                        End If
                    Catch ex As Exception

                    End Try
                    If strOddColor & "" = "" Then
                        strOddColor = "#E0E0E0"
                    End If
                    Try
                        If Not IsDBNull(objarrContent(10)) Then
                            strPageFooter = objarrContent(10).Replace("<~>", "\n").Replace("'", "")
                        End If
                    Catch ex As Exception

                    End Try
                    'Footer
                    Try
                        If Not IsDBNull(objarrContent(11)) Then
                            strFooter = Replace(objarrContent(11), "<~>", vbCrLf)
                        Else
                            strFooter = " "
                        End If
                    Catch ex As Exception

                    End Try
                    'objLBTemplate.Template = strHeader & "@@@@@" & strFooter
                    'objFields = objLBTemplate.Fields
                    Dim strContentTemp As String = strHeader & "@@@@@" & strFooter
                    objFields = objBCT.getArrayFromTemplate(strContentTemp)
                    intk = 0
                    'for Content
                    If Not bCols Is Nothing Then


                        For inti = 0 To UBound(bCols)
                            ' Ga'n ca'c tie^u dde^` tu+o+ng u+'ng cho ca'c co^.t     
                            Try
                                Select Case bCols(inti) & ""
                                    Case ""
                                        ReDim Preserve bColLabel(intk)
                                        bColLabel(intk) = ""
                                        intk += 1
                                    Case Else
                                        ReDim Preserve bColLabel(intk)
                                        If UBound(bUserColLabel) >= inti Then
                                            If Not Trim(bUserColLabel(inti)) = "" Then
                                                bColLabel(intk) = bUserColLabel(inti)
                                            Else
                                                bColLabel(intk) = colColumnTitle.Item(bCols(inti))
                                            End If
                                        Else
                                            bColLabel(intk) = colColumnTitle.Item(bCols(inti))
                                        End If
                                        intk += 1
                                End Select
                            Catch ex As Exception
                                strErrorMsg = ex.Message
                                ReDim Preserve bColLabel(intk)
                                bColLabel(intk) = ""
                                intk += 1
                            End Try
                        Next
                    End If
                    ' Get UnreceiverdIssues
                    objDPeriodicalCollection.SelectMode = "1"
                    objDPeriodicalCollection.ClaimCycleMode = chrClaimCycleMode
                    objDPeriodicalCollection.IssueYear = strIssueYear
                    objDPeriodicalCollection.IDs = strIDs
                    tblUnReceivedIssues = objBCDBS.ConvertTable(objDPeriodicalCollection.GetIssueForClaim, "Content")
                    Dim intt As Integer
                    For intt = 0 To tblUnReceivedIssues.Rows.Count - 1
                        If Not IsDBNull(tblUnReceivedIssues.Rows(intt).Item("Price")) Then
                            tblUnReceivedIssues.Rows(intt).Item("Price") = CInt(tblUnReceivedIssues.Rows(intt).Item("Price"))
                        End If
                    Next
                    intErrorCode = objDPeriodical.ErrorCode
                    strErrorMsg = objDPeriodical.ErrorMsg
                    'get Vendor to Claim
                    objDPeriodicalCollection.IDs = strIDs
                    tblVendor = objDPeriodicalCollection.GetVendorToClaim
                    intErrorCode = objDPeriodical.ErrorCode
                    strErrorMsg = objDPeriodical.ErrorMsg

                    ' Get title
                    objDPeriodical.IDs = strIDs
                    tblField200s = objBCDBS.ConvertTable(objDPeriodical.GetTitle, "Content")
                    intErrorCode = objDPeriodical.ErrorCode
                    strErrorMsg = objDPeriodical.ErrorMsg

                    If Not tblUnReceivedIssues Is Nothing Then
                        If tblUnReceivedIssues.Rows.Count > 0 Then
                            Dim dtRows() As DataRow
                            Dim dtRow As DataRow
                            Dim dtRowsVendor() As DataRow
                            Dim dtRowVendor As DataRow
                            Dim dtrowsField200s() As DataRow
                            Dim dtrowField200s As DataRow
                            Dim arrIDs() As String
                            Dim mi As Integer
                            arrIDs = Split(strIDs, ",")
                            ReDim strOutMsg(UBound(arrIDs))
                            ReDim strEmailAddess(UBound(arrIDs))
                            ' For Header or Footer
                            'ReDim objData(UBound(objLBTemplate.Fields))
                            If Not IsNothing(objFields) AndAlso IsArray(objFields) Then
                                ReDim objData(UBound(objFields))
                            End If
                            Dim strContent As String = strContentTemp
                            For mi = LBound(arrIDs) To UBound(arrIDs)
                                dtRows = tblUnReceivedIssues.Select("ItemID=" & arrIDs(mi))
                                dtRowsVendor = tblVendor.Select("ItemID=" & arrIDs(mi))
                                strContent = strContentTemp
                                If Not IsNothing(objFields) AndAlso IsArray(objFields) Then
                                    For Each dtRowVendor In dtRowsVendor
                                        For inti = LBound(objFields) To UBound(objFields)
                                            If Not IsDBNull(dtRowVendor) Then ' Get Vendor Email Address
                                                strEmailAddess(mi) = dtRowVendor.Item("Email")
                                            End If
                                            '    Try
                                            Select Case objFields(inti) & ""
                                                Case ""
                                                    objData(inti) = "" & Chr(9)
                                                Case "TODAY"
                                                    objData(inti) = CStr(Now) & Chr(9)
                                                Case "TODAY:DD"
                                                    objData(inti) = CStr(Day(Now)) & Chr(9)
                                                Case "TODAY:MM"
                                                    objData(inti) = CStr(Month(Now)) & Chr(9)
                                                Case "TODAY:YYYY"
                                                    objData(inti) = CStr(Year(Now)) & Chr(9)
                                                Case "TODAY:YY"
                                                    objData(inti) = Right(CStr(Year(Now)), 2) & Chr(9)
                                                Case "TODAY:HH"
                                                    objData(inti) = CStr(Hour(Now)) & Chr(9)
                                                Case "TODAY:MI"
                                                    objData(inti) = CStr(Minute(Now)) & Chr(9)
                                                Case "TODAY:SS"
                                                    objData(inti) = CStr(Second(Now)) & Chr(9)
                                                Case "ITEMNAME"
                                                    dtrowsField200s = tblField200s.Select("ItemID=" & arrIDs(mi) & " AND FieldCode='245'")
                                                    For Each dtrowField200s In dtrowsField200s
                                                        If Not IsDBNull(dtrowField200s.Item("Content")) Then
                                                            objData(inti) = objBCSP.ToUTF8(dtrowField200s.Item("Content")) & Chr(9)
                                                        Else
                                                            objData(inti) = "" & Chr(9)
                                                        End If
                                                    Next
                                                    dtrowsField200s = tblField200s.Select("")
                                                Case Else
                                                    If Not IsDBNull(dtRowVendor.Item("" & objFields(inti) & "")) Then
                                                        objData(inti) = objBCSP.ToUTF8(dtRowVendor.Item("" & objFields(inti) & "")) & Chr(9)
                                                    End If
                                            End Select
                                            '        Catch ex As Exception
                                            '         objData(inti) = "" & Chr(9)
                                            '              strErrorMsg = ex.Message
                                            '        End Try
                                            strContent = Replace(strContent, "<$" & objFields(inti) & "$>", objData(inti))
                                        Next ' objFields
                                    Next ' Vendor         
                                End If

                                ' Generete data for Header and Footer
                                'objStream = objLBTemplate.Generate(objData)
                                objStream = strContent

                                objStream.GetType.ToString.Replace(" ", "&nbsp;&nbsp;")
                                ' Generate String Template    
                                strOutMsg(mi) = strPageHeader
                                strOutMsg(mi) = strOutMsg(mi) & objBCSP.ToUTF8Back(Left(objStream, InStr(objStream, "@@@@@") - 1))

                                If Not IsDBNull(dtRows) Then
                                    If dtRows.Length > 0 Then
                                        strOutMsg(mi) = strOutMsg(mi) & "<TABLE WIDTH=100% BORDER=0 CELLSPACING=1  CELLPADDING=1><TR><TD><TABLE WIDTH=100% BORDER=0  CELLSPACING=1  CELLPADDING=3 BGCOLOR=" & strTableColor & ">"
                                        strOutMsg(mi) = strOutMsg(mi) & "<TR  BGCOLOR=#CCCCCC class=""tb-header""> "
                                        ' Collumn title
                                        If Not bColLabel Is Nothing Then


                                            For intj = 0 To UBound(bColLabel)
                                                mw = ""
                                                'Collumn Width
                                                If UBound(bUserColWidth) >= intj Then
                                                    If Not Trim(bUserColWidth(intj)) = "" Then
                                                        mw = " WIDTH=""" & Trim(bUserColWidth(intj)) & """"
                                                    End If
                                                End If
                                                ma = ""
                                                'Collumn Align
                                                If UBound(bUserColAlign) >= intj Then
                                                    If Not Trim(bUserColAlign(intj)) = "" Then
                                                        ma = " ALIGN=""" & Trim(bUserColAlign(intj)) & """"
                                                    End If
                                                End If
                                                'Collumn Format
                                                boomf = False
                                                If UBound(bUserColFormat) >= intj Then
                                                    If Not Trim(bUserColFormat(intj)) = "" Then
                                                        boomf = True
                                                    End If
                                                End If
                                                If boomf Then
                                                    strOutMsg(mi) = strOutMsg(mi) & "<TD VALIGN=TOP " & mw & ma & " ALIGN=TOP BGCOLOR=#DEDEDE>" & bUserColFormat(intj).Replace("<$DATA$>", bColLabel(intj)) & "</TD>"
                                                Else
                                                    strOutMsg(mi) = strOutMsg(mi) & "<TD  VALIGN=TOP " & mw & ma & "  BGCOLOR=#DEDEDE>" & bColLabel(intj) & "</TD>"
                                                End If
                                            Next 'bColLabel
                                        End If
                                        strOutMsg(mi) = strOutMsg(mi) & "</TR>"
                                        'for collum and row data
                                        intk = 1
                                        For Each dtRow In dtRows
                                            If intk Mod 2 = 0 Then
                                                strChangeColor = strEventColor
                                            Else
                                                strChangeColor = strOddColor
                                            End If
                                            intk += 1
                                            strOutMsg(mi) = strOutMsg(mi) & "<TR  BGCOLOR=" & strChangeColor & ">"
                                            'for collum and row data
                                            If Not bCols Is Nothing Then


                                                For inti = 0 To UBound(bCols)
                                                    ' CollumnWidth
                                                    mw = ""
                                                    If UBound(bUserColWidth) >= inti Then
                                                        If Not Trim(bUserColWidth(inti)) = "" Then
                                                            mw = " WIDTH=""" & Trim(bUserColWidth(inti)) & """"
                                                        End If
                                                    End If
                                                    ' CollumnAlign 
                                                    ma = ""
                                                    If UBound(bUserColAlign) >= inti Then
                                                        If Not Trim(bUserColAlign(inti)) = "" Then
                                                            ma = " ALIGN=""" & Trim(bUserColAlign(inti)) & """"
                                                        End If
                                                    End If
                                                    ' Collumn Format
                                                    boomf = False 'default not have Format
                                                    If UBound(bUserColFormat) >= inti Then
                                                        If Not Trim(bUserColFormat(inti)) = "" Then
                                                            boomf = True 'have Format
                                                        End If
                                                    End If
                                                    'Try
                                                    Select Case bCols(inti) & ""
                                                        Case ""
                                                            strOutMsg(mi) = strOutMsg(mi) & "<TD  VALIGN=TOP " & mw & ma & "  BGCOLOR=" & strChangeColor & ">&nbsp;</TD>"
                                                        Case Else
                                                            If boomf Then
                                                                strOutMsg(mi) = strOutMsg(mi) & "<TD  VALIGN=TOP " & mw & ma & " BGCOLOR=" & strChangeColor & ">" & bUserColFormat(inti).Replace("<$DATA$>", dtRow.Item("" & bCols(inti).Replace("<$", "").Replace("$>", "") & "")) & "&nbsp;</TD>"
                                                            Else
                                                                If bCols(inti) & "" = "<$SPECIALISSUE$>" Then
                                                                    strOutMsg(mi) = strOutMsg(mi) & "<TD VALIGN=TOP " & mw & ma & " BGCOLOR=" & strChangeColor & ">" & "" & "&nbsp;</TD>"
                                                                Else
                                                                    strOutMsg(mi) = strOutMsg(mi) & "<TD VALIGN=TOP " & mw & ma & " BGCOLOR=" & strChangeColor & ">" & dtRow.Item("" & bCols(inti).Replace("<$", "").Replace("$>", "")) & "&nbsp;</TD>"
                                                                End If
                                                            End If
                                                    End Select
                                                    'Catch ex As Exception
                                                    'strErrorMsg = ex.Message
                                                    'strOutMsg(mi) = strOutMsg(mi) & "<TD  VALIGN=TOP " & mw & ma & "  BGCOLOR=" & strChangeColor & ">&nbsp;</TD>"
                                                    'End Try
                                                Next
                                            End If

                                            strOutMsg(mi) = strOutMsg(mi) & "</TR>"
                                        Next
                                    End If
                                End If
                                strOutMsg(mi) = strOutMsg(mi) & "</TABLE></TD></TR></TABLE>" & strPageFooter
                                strOutMsg(mi) = strOutMsg(mi) & objBCSP.ToUTF8Back(Right(objStream, Len(objStream) - InStr(objStream, "@@@@@") - 4))
                            Next ' end mi
                            objMetric.arrStrEmailAddress = strEmailAddess
                            objMetric.arrStrOutMsg = strOutMsg
                            Return (objMetric)
                        Else 'don't have any UnReceivedIssues
                            Return (Nothing)
                        End If
                    End If
                Else 'don't have any ClaimTemplate
                    Return (Nothing)
                End If
            Else 'don't have any ClaimTemplate
                Return (Nothing)
            End If
            'If Not objLBTemplate Is Nothing Then
            '    objLBTemplate = Nothing
            'End If
        End Function
        '********************************************************************************************************
        ' GenClaimTemplate method
        ' Purpose: gen claim letter with template
        ' Input: ID of claim template
        ' Output: string result
        Public Function GenClaimTemplate() As String
            ' Declare variables
            'Dim objLBTemplate As New TVCOMLib.LibolTemplate
            Dim bColLabel() As String
            Dim bUserColLabel() As String
            Dim bUserColWidth() As String
            Dim bCols() As String ' for Collumn
            Dim bUserColAlign() As String 'for Align
            Dim bUserColFormat() As String 'for Format
            Dim objFields As Object
            Dim objStream As Object
            Dim objData As Object
            Dim intk As Integer
            Dim inti As Integer
            Dim intj As Integer
            Dim strOutMsg As String = ""
            Dim strChangeColor As String = "FFFFFF"
            Dim strWidth As String ' width collumn
            Dim strAlign As String ' align collumn
            Dim strFormat As String ' format collumn
            Dim strString As String
            Dim boolFormat As Boolean ' control format template
            ' Inti some value
            If strTableColor & "" = "" Then
                strTableColor = "FFFFFF"
            End If
            If strOddColor & "" = "" Then
                strOddColor = "E0E0E0"
            End If
            If strEventColor & "" = "" Then
                strEventColor = "FFFFFF"
            End If
            ' Process here
            'objLBTemplate.Template = objBCSP.ToUTF8(strHeader) & "@@@@@" & objBCSP.ToUTF8(strFooter)
            'objFields = objLBTemplate.Fields


            Dim strContentTemp As String = strHeader & "@@@@@" & strFooter
            objFields = objBCT.getArrayFromTemplate(strContentTemp)

            'get CollumCaption, CollumWidth, CollumAlign, CollumFormat...
            bUserColLabel = Split(strCollumCaption, vbCrLf)
            bUserColWidth = Split(strCollumWidth, vbCrLf)
            bUserColAlign = Split(strCollumAlign, vbCrLf)
            bUserColFormat = Split(strCollumFormat, vbCrLf)
            bCols = Split(strCollums, "<~>")
            intk = 0
            'for Content
            For inti = 0 To UBound(bCols)
                ' Ga'n ca'c tie^u dde^` tu+o+ng u+'ng cho ca'c co^.t     
                Try
                    Select Case bCols(inti) & ""
                        Case ""
                            ReDim Preserve bColLabel(intk)
                            bColLabel(intk) = ""
                            intk += 1
                        Case Else
                            ReDim Preserve bColLabel(intk)
                            If UBound(bUserColLabel) >= inti Then
                                If Not Trim(bUserColLabel(inti)) = "" Then
                                    bColLabel(intk) = bUserColLabel(inti)
                                Else
                                    bColLabel(intk) = colColumnTitle.Item(bCols(inti))
                                End If
                            Else
                                bColLabel(intk) = colColumnTitle.Item(bCols(inti))
                            End If
                            intk += 1
                    End Select
                Catch ex As Exception
                    strErrorMsg = ex.Message
                    ReDim Preserve bColLabel(intk)
                    bColLabel(intk) = ""
                    intk += 1
                End Try
            Next
            ' For Header or Footer
            'ReDim objData(UBound(objLBTemplate.Fields))
            If Not IsNothing(objFields) AndAlso IsArray(objFields) Then
                ReDim objData(UBound(objFields))
                For inti = LBound(objFields) To UBound(objFields)
                    Try
                        objData(inti) = objBCSP.ToUTF8(colHeaderData.Item(objFields(inti))) & Chr(9)
                        strContentTemp = Replace(strContentTemp, "<$" & objFields(inti) & "$>", objData(inti))
                    Catch ex As Exception
                        strErrorMsg = ex.Message
                        objData(inti) = "" & Chr(9)
                    End Try
                Next
            End If
            
            ' Generete data for Header and Footer
            'objStream = objLBTemplate.Generate(objData)
            objStream = strContentTemp

            objStream.GetType.ToString.Replace(" ", "&nbsp;&nbsp;")
            strOutMsg = strPageHeader & Left(objStream, InStr(objStream, "@@@@@") - 1)
            strOutMsg = strOutMsg & "<TABLE WIDTH=100% BORDER=0 CELLSPACING=1  CELLPADDING=1 ><TR><TD WIDTH=100%><TABLE WIDTH=100% BORDER=0  CELLSPACING=1  CELLPADDING=3 BGCOLOR=" & strTableColor & " BORDERCOLOR=" & strTableColor & ">"
            strOutMsg = strOutMsg & "<TR  BGCOLOR=#CCCCCC class=""tb-header""> "
            'for table title
            For intj = 0 To UBound(bColLabel)
                'Collumn Width
                strWidth = ""
                If UBound(bUserColWidth) >= intj Then
                    If Not Trim(bUserColWidth(intj)) = "" Then
                        strWidth = " WIDTH=""" & Trim(bUserColWidth(intj)) & """"
                    End If
                End If
                'Collumn Align
                strAlign = ""
                If UBound(bUserColAlign) >= intj Then
                    If Not Trim(bUserColAlign(intj)) = "" Then
                        strAlign = " ALIGN=""" & Trim(bUserColAlign(intj)) & """"
                    End If
                End If
                boolFormat = False
                strString = bColLabel(intj)
                'Collumn Format
                If UBound(bUserColFormat) >= intj Then
                    If Not Trim(bUserColFormat(intj)) = "" Then
                        strString = bUserColFormat(intj)
                        boolFormat = True
                    End If
                End If
                strOutMsg = strOutMsg & "<TD VALIGN=TOP " & strWidth & strAlign & " ALIGN=TOP BGCOLOR=#CCCCCC class=""tb-header"">&nbsp;" & strString.Replace("<$DATA$>", bColLabel(intj)) & "</TD>"
            Next
            strOutMsg = strOutMsg & "</TR>"
            ' For collumns and rows data
            For intj = 1 To 5
                If intj Mod 2 = 0 Then
                    strChangeColor = strEventColor
                Else
                    strChangeColor = strOddColor
                End If
                strOutMsg = strOutMsg & "<TR  BGCOLOR=" & strChangeColor & ">"
                For inti = 0 To UBound(bCols)
                    ' Collumn Width
                    strWidth = ""
                    If UBound(bUserColWidth) >= inti Then
                        If Not Trim(bUserColWidth(inti)) = "" Then
                            strWidth = " WIDTH=""" & Trim(bUserColWidth(inti)) & """"
                        End If
                    End If
                    ' Collumn Align 
                    strAlign = ""
                    If UBound(bUserColAlign) >= inti Then
                        If Not Trim(bUserColAlign(inti)) = "" Then
                            strAlign = " ALIGN=""" & Trim(bUserColAlign(inti)) & """"
                        End If
                    End If
                    ' Collumn Format
                    boolFormat = False 'default not have Format
                    If UBound(bUserColFormat) >= inti Then
                        If Not Trim(bUserColFormat(inti)) = "" Then
                            boolFormat = True 'have Format
                        End If
                    End If
                    Try
                        Select Case bCols(inti) & ""
                            Case ""
                                strOutMsg = strOutMsg & "<TD  VALIGN=TOP " & strWidth & strAlign & "  BGCOLOR=" & strChangeColor & ">&nbsp;</TD>"
                            Case "<$NUMBER$>"
                                strOutMsg = strOutMsg & "<TD  VALIGN=TOP " & strWidth & strAlign & "  BGCOLOR=" & strChangeColor & ">&nbsp;" & intk & "</TD>"
                            Case Else
                                If boolFormat Then
                                    strOutMsg = strOutMsg & "<TD  VALIGN=TOP " & strWidth & strAlign & "  BGCOLOR=" & strChangeColor & ">&nbsp;" & bUserColFormat(inti).Replace("<$DATA$>", colContentData.Item(bCols(inti))) & "</TD>"
                                Else
                                    strOutMsg = strOutMsg & "<TD VALIGN=TOP " & strWidth & strAlign & " BGCOLOR=" & strChangeColor & ">" & colContentData.Item(bCols(inti)) & "&nbsp;</TD>"
                                End If
                        End Select
                    Catch ex As Exception
                        strOutMsg = strOutMsg & "<TD  VALIGN=TOP " & strWidth & strAlign & "  BGCOLOR=" & strChangeColor & ">&nbsp;</TD>"
                        strErrorMsg = ex.Message
                    End Try
                Next
                strOutMsg = strOutMsg & "</TR>"
            Next
            strOutMsg = strOutMsg & "</TABLE></TD></TR></TABLE>"
            strOutMsg = strOutMsg & Right(objStream, Len(objStream) - InStr(objStream, "@@@@@") - 4) & strPageFooter
            GenClaimTemplate = strOutMsg
            'If Not objLBTemplate Is Nothing Then
            '    objLBTemplate = Nothing
            'End If
        End Function
        ' Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objDPeriodicalCollection Is Nothing Then
                    objDPeriodicalCollection.Dispose(True)
                    objDPeriodicalCollection = Nothing
                End If
                If Not objDPeriodical Is Nothing Then
                    objDPeriodical.Dispose(True)
                    objDPeriodical = Nothing
                End If
                If Not objDClaimTemplate Is Nothing Then
                    objDClaimTemplate.Dispose(True)
                    objDClaimTemplate = Nothing
                End If
                If Not objBCT Is Nothing Then
                    objBCT.Dispose(True)
                    objBCT = Nothing
                End If
            Finally
                Call MyBase.Dispose(True)
                Call Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace