'Class: clsBBinding
'Purpose: Management claim template
'Creator: Tuanhv
'Created Date: 
'Modification History:
'   + 09/11/2004 by Tuanhv: 

Imports System
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Edeliv
Imports System.ValueType
Namespace eMicLibAdmin.BusinessRules.Edeliv
    Public Class clsBETemplate
        Inherits clsBCommonTemplate

        '***************************************DECLARE VARIABLES*******************************************
        Private objDETemplate As New clsDETemplate
        Private objDERequest As New clsDERequest
        '*************************************END DECLARE VARIABLES*****************************************


        '************************************DECLARE PUBLIC PROPERTIES***************************************
        Private colHeaderData As New Collection 'data for Template Header
        Private colContentData As New Collection 'data for Template Content
        Private colFooterData As New Collection 'data for Template Footer

        Private strCollums As String
        Private strCollumCaption As String
        Private strCollumWidth As String
        Private strCollumAlign As String
        Private strCollumFormat As String
        Private strCollumFooter As String
        Private lngItemID As Long
        Private chrClaimCycleMode As Char
        Private strIssueYear As String
        Private strIDs As String = ""
        Private chrSelectMode As Char
        Private strFileName As String
        Private dtCreatedDate As DateTime

        'ItemID property
        Public Property ItemID() As Long
            Get
                Return lngItemID
            End Get
            Set(ByVal Value As Long)
                lngItemID = Value
            End Set
        End Property

        'Get/set strFileName to inrert into table Sys_download_file
        Public Property DownloadFileName() As String
            Get
                Return (strFileName)
            End Get
            Set(ByVal Value As String)
                strFileName = Value
            End Set
        End Property

        'get/set dtCreatedDate to insert into table Sys_download_file
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

        'HeaderData property
        Property HeaderData() As Collection
            Get
                Return colHeaderData
            End Get
            Set(ByVal Value As Collection)
                colHeaderData = Value
            End Set
        End Property

        'ContentData property
        Property ContentData() As Collection
            Get
                Return colContentData
            End Get
            Set(ByVal Value As Collection)
                colContentData = Value
            End Set
        End Property

        'FooterData property
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
        '***********************************END DECLARE PROPERTIES*******************************************


        '***********************************IMPLEMENT METHORS HERE ******************************************
        'Initialize method
        Public Overloads Sub Initialize()
            'Init MyBase object
            MyBase.DBServer = strDBServer
            MyBase.ConnectionString = strConnectionString
            MyBase.InterfaceLanguage = strInterfaceLanguage
            Call MyBase.Initialize()

            'Init objDETemplate object
            objDETemplate.DBServer = strDBServer
            objDETemplate.ConnectionString = strConnectionString
            Call objDETemplate.Initialize()

            'Init objDERequest object
            objDERequest.DBServer = strDBServer
            objDERequest.ConnectionString = ConnectionString
            Call objDERequest.Initialize()
        End Sub

        '---------------------------------------------------------------------------------------------------
        'Purpose: insert a new record into table Sys_download_file
        'in: strFileName, dtCreatedDate
        'out: true/false
        '---------------------------------------------------------------------------------------------------
        Public Function InsertSysDownloadFile() As Boolean
            Try
                objDETemplate.DownloadFileName = strFileName
                objDETemplate.DownloadFileCreateDate = dtCreatedDate
                Return objDETemplate.InsertSysDownloadFile
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function


        'Purpose: define new structure
        'Creator: Tuanhv
        Public Structure Metric
            Public arrStrOutMsg As String()
            Public arrStrEmailAddress As String()
        End Structure

        'PreviewTemplate method
        'Purpose: Get data for template of the selected request
        'Output: String
        'Note: Alls field in database same data in bcol(bcol is a array which init in WebUI) 
        'Creator: Tuanhv
        Public Function PreviewTemplateInfor(ByVal intTempType As Integer, ByVal lngRequestID As Integer) As Metric
            'Declare variables
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
            Dim objFields As Object
            Dim objStream As Object
            Dim objData As Object
            Dim objarrContent As Object
            Dim tblClaimTemplate As DataTable
            Dim tblResult As DataTable
            Dim intk As Integer
            Dim inti As Integer
            Dim intj As Integer
            Dim mw As String 'width collum
            Dim ma As String 'align collum
            Dim mf As String 'format collum
            Dim boomf As Boolean 'control format template
            'Get ClaimTemplate
            Try
                TemplateType = intTempType
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

                        If UBound(objarrContent) > 1 Then
                            'Set body
                            bCols = Split(objarrContent(1), "<~>") 'Colllums
                            bUserColLabel = Split(objarrContent(2), "<~>") 'Collumns Caption
                            bUserColWidth = Split(objarrContent(3), "<~>") 'Collumns width
                            bUserColAlign = Split(objarrContent(4), "<~>") 'Collumns Align
                            bUserColFormat = Split(objarrContent(5), "<~>") 'Collumns Format                

                            'Footer
                            If Not IsDBNull(objarrContent(6)) Then
                                strFooter = objBCSP.ToUTF8(Replace(objarrContent(6), "<~>", vbCrLf))
                            Else
                                strFooter = " "
                            End If
                        Else
                            ReDim bCols(-1)
                            ReDim bUserColLabel(-1)
                            ReDim bUserColWidth(-1)
                            ReDim bUserColAlign(-1)
                            ReDim bUserColFormat(-1)
                            strFooter = " "
                        End If

                        'objLBTemplate.Template = strHeader & "@@@@@" & strFooter
                        'objFields = objLBTemplate.Fields

                        Dim strContentTemp As String = strHeader & "@@@@@" & strFooter
                        objFields = Me.getArrayFromTemplate(strContentTemp)
                        intk = 0

                        'Select Content
                        If UBound(bCols) > 0 Then
                            For inti = LBound(bCols) To UBound(bCols)
                                bCols(inti) = Trim(bCols(inti))
                                bCols(inti) = bCols(inti).Substring(2, Len(bCols(inti)) - 4)
                                ReDim Preserve bColLabel(intk)
                                If UBound(bUserColLabel) >= inti Then
                                    If Not Trim(bUserColLabel(inti)) = "" Then
                                        bColLabel(intk) = bUserColLabel(inti)
                                    Else
                                        bColLabel(intk) = colContentData.Item("<$" & bCols(intk) & "$>")
                                    End If
                                Else
                                    bColLabel(intk) = colContentData.Item("<$" & bCols(intk) & "$>")
                                End If
                                intk += 1
                            Next
                        End If

                        objDERequest.RequestID = lngRequestID
                        tblResult = objBCDBS.ConvertTable(objDERequest.GetRequestInfor)

                        'Check error
                        ErrorCode = objDERequest.ErrorCode
                        ErrorMsg = objDERequest.ErrorMsg

                        If Not tblResult Is Nothing Then
                            If tblResult.Rows.Count > 0 Then
                                Dim dtRows() As DataRow
                                Dim dtRow As DataRow
                                Dim dtRowsVendor() As DataRow
                                Dim dtRowVendor As DataRow
                                Dim dtrowsField200s() As DataRow
                                Dim dtrowField200s As DataRow
                                Dim arrIDs() As String
                                Dim intm As Integer
                                arrIDs = Split(strIDs, ",")

                                'Can select some ItemID
                                ReDim arrIDs(0)
                                arrIDs(0) = CStr(lngItemID)
                                ReDim strOutMsg(UBound(arrIDs))
                                ReDim strEmailAddess(UBound(arrIDs))

                                'Can exit some row in body template
                                intm = 0

                                'Get information for Header or Footer
                                If Not IsNothing(objFields) AndAlso IsArray(objFields) Then
                                    ReDim objData(UBound(objFields))
                                    If Not tblResult Is Nothing Then
                                        If tblResult.Rows.Count > 0 Then
                                            For inti = LBound(objFields) To UBound(objFields)
                                                Select Case objFields(inti)
                                                    Case "TODAY"
                                                        objData(inti) = CStr(Now) & Chr(9)
                                                    Case "DD"
                                                        objData(inti) = CStr(Day(Now)) & Chr(9)
                                                    Case "MM"
                                                        objData(inti) = CStr(Month(Now)) & Chr(9)
                                                    Case "YYYY"
                                                        objData(inti) = CStr(Year(Now)) & Chr(9)
                                                    Case "HH"
                                                        objData(inti) = CStr(Hour(Now)) & Chr(9)
                                                    Case "MI"
                                                        objData(inti) = CStr(Minute(Now)) & Chr(9)
                                                    Case "SS"
                                                        objData(inti) = CStr(Second(Now)) & Chr(9)
                                                    Case Else
                                                        If Not IsDBNull(tblResult.Rows(0).Item(objFields(inti))) Then
                                                            objData(inti) = objBCSP.ToUTF8(tblResult.Rows(0).Item(objFields(inti))) & Chr(9)
                                                        Else
                                                            objData(inti) = " " & Chr(9)
                                                        End If
                                                End Select
                                                strContentTemp = Replace(strContentTemp, "<$" & objFields(inti) & "$>", objData(inti))
                                            Next
                                        End If
                                    End If

                                End If
                               
                                Dim intCurID As Integer
                                intCurID = 0
                                'Generete data for Header and Footer
                                'objStream = objLBTemplate.Generate(objData)
                                objStream = strContentTemp
                                objStream.GetType.ToString.Replace(" ", "&nbsp;&nbsp;")
                                'Generate String Template                                             
                                strOutMsg(intm) = strOutMsg(intm) & objBCSP.ToUTF8Back(Left(objStream, InStr(objStream, "@@@@@") - 1))

                                'Get data
                                dtRow = tblResult.Rows(0)
                                strOutMsg(intm) = strOutMsg(intm) & "<TABLE WIDTH=100% BORDER=0 CELLSPACING=1  CELLPADDING=1 BGCOLOR=""#000000""><TR><TD><TABLE WIDTH=100% BORDER=0  CELLSPACING=1  CELLPADDING=3>"
                                strOutMsg(intm) = strOutMsg(intm) & "<TR  BGCOLOR=FFFFFF> "

                                'Collumn title
                                If Not bColLabel Is Nothing Then
                                    If UBound(bColLabel) > 0 Then
                                        For intj = LBound(bColLabel) To UBound(bColLabel)
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
                                                strOutMsg(intm) = strOutMsg(intm) & "<TD VALIGN=TOP " & mw & ma & " ALIGN=TOP BGCOLOR=FFFFFF>" & bUserColFormat(intj).Replace("<$DATA$>", bColLabel(intj)) & "</TD>"
                                            Else
                                                strOutMsg(intm) = strOutMsg(intm) & "<TD  VALIGN=TOP " & mw & ma & "  BGCOLOR=FFFFFF>" & bColLabel(intj) & "</TD>"
                                            End If
                                        Next 'bColLabel
                                    End If
                                End If


                                strOutMsg(intm) = strOutMsg(intm) & "</TR>"
                                'for collum and row data
                                strOutMsg(intm) = strOutMsg(intm) & "<TR  BGCOLOR=FFFFFF>"
                                'for collum and row data
                                If Not bCols Is Nothing Then
                                    If UBound(bCols) > 0 Then
                                        For inti = LBound(bCols) To UBound(bCols)
                                            If bCols(inti) = "NO" Then
                                                If boomf Then
                                                    strOutMsg(intm) = strOutMsg(intm) & "<TD  VALIGN=TOP " & mw & ma & "  BGCOLOR=FFFFFF>" & bUserColFormat(inti).Replace("<$DATA$>", inti + 1) & "</TD>"
                                                Else
                                                    strOutMsg(intm) = strOutMsg(intm) & "<TD VALIGN=TOP " & mw & ma & " BGCOLOR=FFFFFF>" & inti + 1 & "&nbsp;</TD>"
                                                End If
                                            Else
                                                If boomf Then
                                                    strOutMsg(intm) = strOutMsg(intm) & "<TD  VALIGN=TOP " & mw & ma & "  BGCOLOR=FFFFFF>" & bUserColFormat(inti).Replace("<$DATA$>", dtRow.Item(bCols(inti))) & "</TD>"
                                                Else
                                                    strOutMsg(intm) = strOutMsg(intm) & "<TD VALIGN=TOP " & mw & ma & " BGCOLOR=FFFFFF>" & dtRow.Item(bCols(inti)) & "&nbsp;</TD>"
                                                End If
                                            End If

                                        Next
                                    End If
                                End If
                                strOutMsg(intm) = strOutMsg(intm) & "</TR>"
                                strOutMsg(intm) = strOutMsg(intm) & "</TABLE></TD></TR></TABLE>"
                                strOutMsg(intm) = strOutMsg(intm) & objBCSP.ToUTF8Back(Right(objStream, Len(objStream) - InStr(objStream, "@@@@@") - 4))
                                If Not IsDBNull(tblResult.Rows(0).Item("EmailAddess")) Then
                                    strEmailAddess(intm) = tblResult.Rows(0).Item("EmailAddess")
                                End If
                                objMetric.arrStrEmailAddress = strEmailAddess
                                objMetric.arrStrOutMsg = strOutMsg
                                Return (objMetric)
                            Else 'don't have any information for template
                                Return (Nothing)
                            End If
                        End If
                    Else 'don't have any template
                        Return (Nothing)
                    End If
                Else 'don't have any template
                    Return (Nothing)
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                'objLBTemplate = Nothing
            End Try
        End Function

        'GenClaimTemplate method
        'Purpose: gen claim letter with template
        'Input: ID of claim template
        'Output: string result
        Public Function GenClaimTemplate() As String
            'Declare variables
            'Dim objLBTemplate As New TVCOMLib.LibolTemplate
            Dim bColLabel() As String
            Dim bUserColLabel() As String
            Dim bUserColWidth() As String
            Dim bCols() As String 'for Collumn
            Dim bUserColAlign() As String 'for Align
            Dim bUserColFormat() As String 'for Format
            Dim strOutMsg As String = ""
            Dim objFields As Object
            Dim objStream As Object
            Dim objData As Object
            Dim intk As Integer
            Dim inti As Integer
            Dim intj As Integer
            Dim mw As String 'width collumn
            Dim ma As String 'align collumn
            Dim mf As String 'format collumn
            Dim boomf As Boolean 'control format template

            Try
                'objLBTemplate.Template = objBCSP.ToUTF8(strHeader) & "@@@@@" & objBCSP.ToUTF8(strFooter)
                'objFields = objLBTemplate.Fields
                Dim strContentTemp As String = objBCSP.ToUTF8(strHeader) & "@@@@@" & objBCSP.ToUTF8(strFooter)
                objFields = Me.getArrayFromTemplate(strContentTemp)

                'Get CollumCaption, CollumWidth, CollumAlign, CollumFormat...
                bUserColLabel = Split(strCollumCaption, vbCrLf)
                bUserColWidth = Split(strCollumWidth, vbCrLf)
                bUserColAlign = Split(strCollumAlign, vbCrLf)
                bUserColFormat = Split(strCollumFormat, vbCrLf)
                bCols = Split(strCollums, "<~>")
                intk = 0
                If UBound(bUserColLabel) < UBound(bCols) Then
                    ReDim Preserve bUserColLabel(UBound(bCols) - UBound(bUserColLabel) + 1)
                End If

                If UBound(bCols) >= 0 Then
                    For inti = LBound(bCols) To UBound(bCols)
                        bCols(inti) = Trim(bCols(inti))
                        bCols(inti) = bCols(inti).Substring(2, Len(bCols(inti)) - 4)
                        ReDim Preserve bColLabel(intk)
                        If UBound(bUserColLabel) >= inti Then
                            If Not Trim(bUserColLabel(inti)) = "" Then
                                bColLabel(intk) = bUserColLabel(inti)
                            Else
                                'bColLabel(intk) = colContentData.Item(bColLabel(intk))
                                bColLabel(intk) = colContentData.Item("<$" & bCols(intk) & "$>")
                            End If
                        Else
                            bColLabel(intk) = colContentData.Item("<$" & bCols(intk) & "$>")
                            'bColLabel(intk) = colContentData.Item(bCols(intk))
                        End If
                        intk += 1
                    Next
                End If

                'Get Header or Footer
                intk = 0
                If Not IsNothing(objFields) AndAlso IsArray(objFields) Then
                    ReDim objData(UBound(objFields))
                    For inti = LBound(objFields) To UBound(objFields)
                        objData(inti) = objBCSP.ToUTF8(colHeaderData.Item(objFields(inti))) & Chr(9)
                        strContentTemp = Replace(strContentTemp, "<$" & objFields(inti) & "$>", objData(inti))
                    Next
                End If
                

                'Generete data for Header and Footer
                'objStream = objLBTemplate.Generate(objData)
                objStream = strContentTemp

                strOutMsg = objBCSP.ToUTF8Back(Left(objStream, InStr(objStream, "@@@@@") - 1))
                strOutMsg = strOutMsg & "<TABLE WIDTH=100% BORDER=0 CELLSPACING=1  CELLPADDING=1 BGCOLOR=""#000000""><TR><TD><TABLE WIDTH=100% BORDER=0  CELLSPACING=1  CELLPADDING=3>"
                strOutMsg = strOutMsg & "<TR  BGCOLOR=FFFFFF> "
                'Find table title
                If IsArray(bColLabel) Then
                    For intj = LBound(bColLabel) To UBound(bColLabel)
                        'Collumn Width
                        mw = ""
                        If UBound(bUserColWidth) >= intj Then
                            If Not Trim(bUserColWidth(intj)) = "" Then
                                mw = " WIDTH=""" & Trim(bUserColWidth(intj)) & """"
                            End If
                        End If
                        'Collumn Align
                        ma = ""
                        If UBound(bUserColAlign) >= intj Then
                            If Not Trim(bUserColAlign(intj)) = "" Then
                                ma = " ALIGN=""" & Trim(bUserColAlign(intj)) & """"
                            End If
                        End If
                        boomf = False
                        'Collumn Format
                        If UBound(bUserColFormat) >= intj Then
                            If Not Trim(bUserColFormat(intj)) = "" Then
                                boomf = True
                            End If
                        End If
                        If boomf Then
                            strOutMsg = strOutMsg & "<TD VALIGN=TOP " & mw & ma & " ALIGN=TOP BGCOLOR=FFFFFF>" & bUserColFormat(intj).Replace("<$DATA$>", bColLabel(intj)) & "</TD>"
                        Else
                            strOutMsg = strOutMsg & "<TD  VALIGN=TOP " & mw & ma & "  BGCOLOR=FFFFFF>" & bColLabel(intj) & "</TD>"
                        End If
                    Next
                End If
                strOutMsg = strOutMsg & "</TR><TR  BGCOLOR=FFFFFF>"
                'Find collumns and rows data
                If IsArray(bCols) Then
                    For inti = LBound(bCols) To UBound(bCols)
                        'Collumn Width
                        mw = ""
                        If UBound(bUserColWidth) >= inti Then
                            If Not Trim(bUserColWidth(inti)) = "" Then
                                mw = " WIDTH=""" & Trim(bUserColWidth(inti)) & """"
                            End If
                        End If
                        'Collumn Align 
                        ma = ""
                        If UBound(bUserColAlign) >= inti Then
                            If Not Trim(bUserColAlign(inti)) = "" Then
                                ma = " ALIGN=""" & Trim(bUserColAlign(inti)) & """"
                            End If
                        End If
                        'Collumn Format
                        boomf = False 'default not have Format
                        If UBound(bUserColFormat) >= inti Then
                            If Not Trim(bUserColFormat(inti)) = "" Then
                                boomf = True 'have Format
                            End If
                        End If

                        If boomf Then
                            strOutMsg = strOutMsg & "<TD  VALIGN=TOP " & mw & ma & "  BGCOLOR=FFFFFF>" & bUserColFormat(inti).Replace("<$DATA$>", colContentData.Item(bCols(inti))) & "</TD>"
                        Else
                            strOutMsg = strOutMsg & "<TD VALIGN=TOP " & mw & ma & " BGCOLOR=FFFFFF>" & colContentData.Item(bCols(inti)) & "&nbsp;</TD>"
                        End If
                    Next
                End If
                strOutMsg = strOutMsg & "</TR>"
                strOutMsg = strOutMsg & "</TABLE></TD></TR></TABLE>"
                strOutMsg = strOutMsg & objBCSP.ToUTF8Back(Right(objStream, Len(objStream) - InStr(objStream, "@@@@@") - 4))

                Return (strOutMsg)
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function


        'GenClaimTemplate method
        'Purpose: gen claim letter with template
        'Input: ID of claim template
        'Output: string result
        Public Function GenClaimTemplatePack() As String
            'Declare variables
            'Dim objLBTemplate As New TVCOMLib.LibolTemplate
            Dim bColLabel() As String
            Dim bUserColLabel() As String
            Dim bUserColWidth() As String
            Dim bCols() As String 'for collumn
            Dim bUserColAlign() As String 'for Align
            Dim bUserColFormat() As String 'for Format
            Dim strOutMsg As String = ""
            Dim objFields As Object
            Dim objStream As Object
            Dim objData As Object
            Dim intk As Integer
            Dim inti As Integer
            Dim intj As Integer
            Dim mw As String 'width collumn
            Dim ma As String 'align collumn
            Dim mf As String 'format collumn
            Dim boomf As Boolean 'control format template
            'process here
            Try
                'objLBTemplate.Template = objBCSP.ToUTF8(strHeader) & "@@@@@" & ""
                'objFields = objLBTemplate.Fields
                Dim strContentTemp As String = objBCSP.ToUTF8(strHeader) & "@@@@@" & ""
                objFields = Me.getArrayFromTemplate(strContentTemp)

                'Get header 
                intk = 0
                If Not IsNothing(objFields) AndAlso IsArray(objFields) Then
                    ReDim objData(UBound(objFields))
                    For inti = LBound(objFields) To UBound(objFields)
                        objData(inti) = objBCSP.ToUTF8(colHeaderData.Item(objFields(inti))) & Chr(9)
                        strContentTemp = Replace(strContentTemp, "<$" & objFields(inti) & "$>", objData(inti))
                    Next
                End If
                
                'Generete data for header 
                'objStream = objLBTemplate.Generate(objData)
                objStream = strContentTemp
                strOutMsg = objBCSP.ToUTF8Back(Left(objStream, InStr(objStream, "@@@@@") - 1))
                Return (strOutMsg)
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        'Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objDERequest Is Nothing Then
                    objDERequest.Dispose(True)
                    objDERequest = Nothing
                End If
                If Not objDETemplate Is Nothing Then
                    objDETemplate.Dispose(True)
                    objDETemplate = Nothing
                End If
            Finally
                Call MyBase.Dispose(True)
                Call Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace