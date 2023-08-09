'Name: clsBILLTemplate
'Purpose: Template purpose
'Creator: Sondp
'Created Date: 25/11/2004
'Modification History: 

Imports System
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.ILL

Namespace eMicLibAdmin.BusinessRules.ILL
    Public Class clsBILLTemplate
        Inherits clsBBase
        '***********************************************************************************************
        'Declare Private variables
        '***********************************************************************************************

        Private collectionContentData As Collection
        Private strTitle As String
        Private strContent As String

        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        Private objBCommonTemplate As New clsBCommonTemplate

        '***********************************************************************************************
        'End declare variables
        'Declare public properties
        '***********************************************************************************************

        'ContentData property
        Public Property ContentData() As Collection
            Get
                Return (collectionContentData)
            End Get
            Set(ByVal Value As Collection)
                collectionContentData = Value
            End Set
        End Property

        'Title property
        Public Property Title() As String
            Get
                Return (strTitle)
            End Get
            Set(ByVal Value As String)
                strTitle = Value
            End Set
        End Property

        'Content property
        Public Property Content() As String
            Get
                Return (strContent)
            End Get
            Set(ByVal Value As String)
                strContent = Value
            End Set
        End Property

        '***********************************************************************************************
        'End declare properties
        'Implement methods here
        '***********************************************************************************************

        'Initialize method
        Public Sub Initialize()
            'Initialize objBCSP object
            objBCSP.InterfaceLanguage = strInterfaceLanguage
            objBCSP.ConnectionString = strconnectionstring
            objBCSP.DBServer = strdbserver
            objBCSP.Initialize()

            'Init objBCDBS object
            objBCDBS.ConnectionString = strconnectionstring
            objBCDBS.DBServer = strdbserver
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.Initialize()

            'Init objBCommonTemplate object
            objBCommonTemplate.ConnectionString = strconnectionstring
            objBCommonTemplate.DBServer = strdbserver
            objBCommonTemplate.InterfaceLanguage = strInterfaceLanguage
            objBCommonTemplate.Initialize()
        End Sub

        'Purpose: define new structure
        'Creator: Tuanhv
        Public Structure Metric
            Public arrStrOutMsg As String()
            Public arrStrEmailAddress As String()
        End Structure

        'GetTemplate function
        'Purpose: Create new Template
        'Input: TemplateType, TemplateID
        'Output: datatable result
        'Creator: Tuanhv
        Public Function GetTemplate(ByVal intTemplateID As Integer, ByVal intTemplateType As Integer) As DataTable
            Try
                objBCommonTemplate.TemplateID = intTemplateID
                objBCommonTemplate.TemplateType = intTemplateType
                GetTemplate = objBCDBS.ConvertTable(objBCommonTemplate.GetTemplate)
                ErrorCode = objBCommonTemplate.ErrorCode
                ErrorMsg = objBCommonTemplate.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally

            End Try
        End Function

        'GenOverdueTemplate method
        'Purpose: Get data for template of the selected request
        'Output: Matric 
        'Note: Alls field in database same data in bcol(bcol is a array which init in WebUI) 
        'Creator: Tuanhv
        'Date" 22/12/2004
        Public Function GenOverdueTemplate(ByVal intTempType As Integer, ByVal lngRequestID As Integer, ByVal tblPatronInfor As DataTable, ByVal intTemplateID As Integer) As Metric
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
            Dim tblTemplateDeny As DataTable
            Dim tblResult As DataTable
            Dim intk As Integer
            Dim inti As Integer
            Dim intj As Integer
            Dim strms As String 'width collum
            Dim strma As String 'align collum
            Dim strmf As String 'format collum
            Dim boomf As Boolean 'control format template
            Dim strHeader As String = ""
            Dim strFooter As String = ""
            'Get ClaimTemplate
            Try
                tblTemplateDeny = GetTemplate(intTemplateID, intTempType)

                If Not tblTemplateDeny Is Nothing Then
                    If tblTemplateDeny.Rows.Count > 0 Then
                        objarrContent = Split(tblTemplateDeny.Rows(0).Item("Content"), Chr(9))
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
                        objFields = objBCommonTemplate.getArrayFromTemplate(strContentTemp)
                        intk = 0

                        'Select Content
                        If UBound(bCols) > 0 Then
                            For inti = 0 To UBound(bCols)
                                bCols(inti) = Trim(bCols(inti))
                                bCols(inti) = bCols(inti).Substring(2, Len(bCols(inti)) - 4)
                                ReDim Preserve bColLabel(intk)
                                If UBound(bUserColLabel) >= inti Then
                                    If Not Trim(bUserColLabel(inti)) = "" Then
                                        bColLabel(intk) = bUserColLabel(inti)
                                    Else
                                        bColLabel(intk) = collectionContentData.Item("<$" & bCols(intk) & "$>")
                                    End If
                                Else
                                    bColLabel(intk) = collectionContentData.Item("<$" & bCols(intk) & "$>")
                                End If
                                intk += 1
                            Next
                        End If

                        tblResult = tblPatronInfor
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

                                'Can select some ItemID
                                ReDim arrIDs(0)
                                ReDim strOutMsg(UBound(arrIDs))
                                ReDim strEmailAddess(UBound(arrIDs))

                                'Can exit some row in body template
                                intm = 0

                                'Get information for Header or Footer
                                If Not IsNothing(objFields) AndAlso IsArray(objFields) Then
                                    ReDim objData(UBound(objFields))
                                    If Not tblResult Is Nothing Then
                                        If tblResult.Rows.Count > 0 Then
                                            For inti = 0 To UBound(objFields)
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
                                                        Try
                                                            If Not IsDBNull(tblResult.Rows(0).Item(objFields(inti))) Then
                                                                objData(inti) = objBCSP.ToUTF8(tblResult.Rows(0).Item(objFields(inti))) & Chr(9)
                                                            Else
                                                                objData(inti) = " " & Chr(9)
                                                            End If
                                                        Catch ex As Exception
                                                            Try
                                                                If Not IsDBNull(tblPatronInfor.Rows(0).Item(objFields(inti))) Then
                                                                    objData(inti) = objBCSP.ToUTF8(tblPatronInfor.Rows(0).Item(objFields(inti))) & Chr(9)
                                                                Else
                                                                    objData(inti) = " " & Chr(9)
                                                                End If
                                                            Catch ex1 As Exception

                                                            End Try

                                                        End Try
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
                                        For intj = 0 To UBound(bColLabel)
                                            strms = ""
                                            'Collumn Width
                                            If UBound(bUserColWidth) >= intj Then
                                                If Not Trim(bUserColWidth(intj)) = "" Then
                                                    strms = " WIDTH=""" & Trim(bUserColWidth(intj)) & """"
                                                End If
                                            End If

                                            strma = ""
                                            'Collumn Align
                                            If UBound(bUserColAlign) >= intj Then
                                                If Not Trim(bUserColAlign(intj)) = "" Then
                                                    strma = " ALIGN=""" & Trim(bUserColAlign(intj)) & """"
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
                                                strOutMsg(intm) = strOutMsg(intm) & "<TD VALIGN=TOP " & strms & strma & " ALIGN=TOP BGCOLOR=FFFFFF>" & bUserColFormat(intj).Replace("<$DATA$>", bColLabel(intj)) & "</TD>"
                                            Else
                                                strOutMsg(intm) = strOutMsg(intm) & "<TD  VALIGN=TOP " & strms & strma & "  BGCOLOR=FFFFFF>" & bColLabel(intj) & "</TD>"
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
                                        For inti = 0 To UBound(bCols)
                                            If bCols(inti) = "NO" Then
                                                If boomf Then
                                                    strOutMsg(intm) = strOutMsg(intm) & "<TD  VALIGN=TOP " & strms & strma & "  BGCOLOR=FFFFFF>" & bUserColFormat(inti).Replace("<$DATA$>", inti + 1) & "</TD>"
                                                Else
                                                    strOutMsg(intm) = strOutMsg(intm) & "<TD VALIGN=TOP " & strms & strma & " BGCOLOR=FFFFFF>" & inti + 1 & "&nbsp;</TD>"
                                                End If
                                            Else
                                                If boomf Then
                                                    strOutMsg(intm) = strOutMsg(intm) & "<TD  VALIGN=TOP " & strms & strma & "  BGCOLOR=FFFFFF>" & bUserColFormat(inti).Replace("<$DATA$>", dtRow.Item(bCols(inti))) & "</TD>"
                                                Else
                                                    strOutMsg(intm) = strOutMsg(intm) & "<TD VALIGN=TOP " & strms & strma & " BGCOLOR=FFFFFF>" & dtRow.Item(bCols(inti)) & "&nbsp;</TD>"
                                                End If
                                            End If

                                        Next
                                    End If
                                End If

                                strOutMsg(intm) = strOutMsg(intm) & "</TR>"
                                strOutMsg(intm) = strOutMsg(intm) & "</TABLE></TD></TR></TABLE>"
                                strOutMsg(intm) = strOutMsg(intm) & objBCSP.ToUTF8Back(Right(objStream, Len(objStream) - InStr(objStream, "@@@@@") - 4))
                                If Not IsDBNull(tblPatronInfor.Rows(0).Item("Email")) Then
                                    strEmailAddess(intm) = tblPatronInfor.Rows(0).Item("Email")
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
                ' objLBTemplate = Nothing
            End Try
        End Function

        'GenDenniedTemplate method
        'Purpose: Get data for template of the selected request
        'Output: Matric 
        'Note: Alls field in database same data in bcol(bcol is a array which init in WebUI) 
        'Creator: Tuanhv
        'Date" 22/12/2004
        Public Function GenDenniedTemplate(ByVal intTempType As Integer, ByVal lngRequestID As Integer, ByVal tblPatronInfor As DataTable, ByVal tblResponseInfor As DataTable, ByVal intTemplateID As Integer, ByVal strCauseResponse As String) As Metric
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
            Dim tblTemplateDeny As DataTable
            Dim tblResult As DataTable
            Dim intk As Integer
            Dim inti As Integer
            Dim intj As Integer
            Dim strms As String 'width collum
            Dim strma As String 'align collum
            Dim strmf As String 'format collum
            Dim boomf As Boolean 'control format template
            Dim strHeader As String = ""
            Dim strFooter As String = ""
            'Get ClaimTemplate
            Try
                tblTemplateDeny = GetTemplate(intTemplateID, intTempType)

                If Not tblTemplateDeny Is Nothing Then
                    If tblTemplateDeny.Rows.Count > 0 Then
                        objarrContent = Split(tblTemplateDeny.Rows(0).Item("Content"), Chr(9))
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
                        objFields = objBCommonTemplate.getArrayFromTemplate(strContentTemp)
                        intk = 0

                        'Select Content
                        If UBound(bCols) > 0 Then
                            For inti = 0 To UBound(bCols)
                                bCols(inti) = Trim(bCols(inti))
                                bCols(inti) = bCols(inti).Substring(2, Len(bCols(inti)) - 4)
                                ReDim Preserve bColLabel(intk)
                                If UBound(bUserColLabel) >= inti Then
                                    If Not Trim(bUserColLabel(inti)) = "" Then
                                        bColLabel(intk) = bUserColLabel(inti)
                                    Else
                                        bColLabel(intk) = collectionContentData.Item("<$" & bCols(intk) & "$>")
                                    End If
                                Else
                                    bColLabel(intk) = collectionContentData.Item("<$" & bCols(intk) & "$>")
                                End If
                                intk += 1
                            Next
                        End If

                        tblResult = tblResponseInfor
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

                                'Can select some ItemID
                                ReDim arrIDs(0)
                                ReDim strOutMsg(UBound(arrIDs))
                                ReDim strEmailAddess(UBound(arrIDs))

                                'Can exit some row in body template
                                intm = 0

                                'Get information for Header or Footer
                                If Not IsNothing(objFields) AndAlso IsArray(objFields) Then
                                    ReDim objData(UBound(objFields))
                                    If Not tblResult Is Nothing Then
                                        If tblResult.Rows.Count > 0 Then
                                            For inti = 0 To UBound(objFields)
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
                                                        Try
                                                            If Not IsDBNull(tblResult.Rows(0).Item(objFields(inti))) Then
                                                                objData(inti) = objBCSP.ToUTF8(tblResult.Rows(0).Item(objFields(inti))) & Chr(9)
                                                            Else
                                                                objData(inti) = " " & Chr(9)
                                                            End If
                                                        Catch ex As Exception
                                                            Try
                                                                If Not IsDBNull(tblPatronInfor.Rows(0).Item(objFields(inti))) Then
                                                                    objData(inti) = objBCSP.ToUTF8(tblPatronInfor.Rows(0).Item(objFields(inti))) & Chr(9)
                                                                Else
                                                                    objData(inti) = " " & Chr(9)
                                                                End If
                                                            Catch ex1 As Exception
                                                                objData(inti) = objBCSP.ToUTF8(strCauseResponse)
                                                            End Try

                                                        End Try
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
                                strOutMsg(intm) = strOutMsg(intm) & "<TABLE WIDTH=100% BORDER=0 CELLSPACING=0  CELLPADDING=0 ><TR><TD><TABLE WIDTH=100% BORDER=0  CELLSPACING=0  CELLPADDING=3>"
                                strOutMsg(intm) = strOutMsg(intm) & "<TR> "

                                'Collumn title
                                If Not bColLabel Is Nothing Then
                                    If UBound(bColLabel) > 0 Then
                                        For intj = 0 To UBound(bColLabel)
                                            strms = ""
                                            'Collumn Width
                                            If UBound(bUserColWidth) >= intj Then
                                                If Not Trim(bUserColWidth(intj)) = "" Then
                                                    strms = " WIDTH=""" & Trim(bUserColWidth(intj)) & """"
                                                End If
                                            End If

                                            strma = ""
                                            'Collumn Align
                                            If UBound(bUserColAlign) >= intj Then
                                                If Not Trim(bUserColAlign(intj)) = "" Then
                                                    strma = " ALIGN=""" & Trim(bUserColAlign(intj)) & """"
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
                                                strOutMsg(intm) = strOutMsg(intm) & "<TD VALIGN=TOP " & strms & strma & " ALIGN=TOP BGCOLOR=FFFFFF>" & bUserColFormat(intj).Replace("<$DATA$>", bColLabel(intj)) & "</TD>"
                                            Else
                                                strOutMsg(intm) = strOutMsg(intm) & "<TD  VALIGN=TOP " & strms & strma & "  BGCOLOR=FFFFFF>" & bColLabel(intj) & "</TD>"
                                            End If
                                        Next 'bColLabel
                                    End If
                                End If

                                strOutMsg(intm) = strOutMsg(intm) & "</TR>"
                                'for collum and row data
                                strOutMsg(intm) = strOutMsg(intm) & "<TR >"
                                'for collum and row data
                                If Not bCols Is Nothing Then
                                    If UBound(bCols) > 0 Then
                                        For inti = 0 To UBound(bCols)
                                            If bCols(inti) = "NO" Then
                                                If boomf Then
                                                    strOutMsg(intm) = strOutMsg(intm) & "<TD  VALIGN=TOP " & strms & strma & "  BGCOLOR=FFFFFF>" & bUserColFormat(inti).Replace("<$DATA$>", inti + 1) & "</TD>"
                                                Else
                                                    strOutMsg(intm) = strOutMsg(intm) & "<TD VALIGN=TOP " & strms & strma & " BGCOLOR=FFFFFF>" & inti + 1 & "&nbsp;</TD>"
                                                End If
                                            Else
                                                If boomf Then
                                                    strOutMsg(intm) = strOutMsg(intm) & "<TD  VALIGN=TOP " & strms & strma & "  BGCOLOR=FFFFFF>" & bUserColFormat(inti).Replace("<$DATA$>", dtRow.Item(bCols(inti))) & "</TD>"
                                                Else
                                                    strOutMsg(intm) = strOutMsg(intm) & "<TD VALIGN=TOP " & strms & strma & " BGCOLOR=FFFFFF>" & dtRow.Item(bCols(inti)) & "&nbsp;</TD>"
                                                End If
                                            End If

                                        Next
                                    End If
                                End If

                                strOutMsg(intm) = strOutMsg(intm) & "</TR>"
                                strOutMsg(intm) = strOutMsg(intm) & "</TABLE></TD></TR></TABLE>"
                                strOutMsg(intm) = strOutMsg(intm) & objBCSP.ToUTF8Back(Right(objStream, Len(objStream) - InStr(objStream, "@@@@@") - 4))
                                If Not IsDBNull(tblPatronInfor.Rows(0).Item("Email")) Then
                                    strEmailAddess(intm) = tblPatronInfor.Rows(0).Item("Email")
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

        'Purpose: Gen common template
        'Input: TemplateType
        'Output: String
        'Creator: Sondp
        Public Function GenILLTemplate(ByVal intTemplateType As Integer) As String
            'Dim objTVCom As New TVCOMLib.LibolTemplate
            Dim objFields() As String
            Dim arrData As Object
            Dim strOutMsg As String
            Dim inti As Integer

            Try
                'objTVCom.Template = objBCSP.ToUTF8(strContent)
                'objFields = objTVCom.Fields
                'Dim strContentTemp As String = objBCSP.ToUTF8(strContent)
                Dim strContentTemp As String = strContent
                objFields = objBCommonTemplate.getArrayFromTemplate(strContentTemp)
                ReDim arrData(UBound(objFields))
                'Load data to array
                For inti = LBound(objFields) To UBound(objFields)
                    Select Case objFields(inti)
                        Case "DD"
                            arrData(inti) = Day(Now) & Chr(9)
                        Case "MM"
                            arrData(inti) = Month(Now) & Chr(9)
                        Case "YYYY"
                            arrData(inti) = Year(Now) & Chr(9)
                        Case Else
                            Try
                                'arrData(inti) = objBCSP.ToUTF8(collectionContentData.Item(objFields(inti))) & Chr(9)
                                arrData(inti) = collectionContentData.Item(objFields(inti)) & Chr(9)
                            Catch ex As Exception
                                Continue For
                            End Try
                    End Select
                    strContentTemp = Replace(strContentTemp, "<$" & objFields(inti) & "$>", arrData(inti))
                    strContentTemp = Replace(strContentTemp, "<$DD$>", Day(Now) & Chr(9))
                    strContentTemp = Replace(strContentTemp, "<$MM$>", Month(Now) & Chr(9))
                    strContentTemp = Replace(strContentTemp, "<$YYYY$>", Year(Now) & Chr(9))
                    strContentTemp = Replace(strContentTemp, "<$DATE.NOW$>", String.Format("{0:dd/MM/yyyy}", Date.Now) & Chr(9))
                    strContentTemp = Replace(strContentTemp, "<$DATE.NOW.DAY$>", Day(Now) & Chr(9))
                    strContentTemp = Replace(strContentTemp, "<$DATE.NOW.MONTH$>", Month(Now) & Chr(9))
                    strContentTemp = Replace(strContentTemp, "<$DATE.NOW.YEAR$>", Year(Now) & Chr(9))
                    strContentTemp = Replace(strContentTemp, "<$TABLE$>", "")
                    strContentTemp = Replace(strContentTemp, "</$TABLE$>", "")
                Next
                'Display data here
                'strOutMsg = objTVCom.Generate(arrData)
                strOutMsg = strContentTemp
                'GenILLTemplate = objBCSP.ToUTF8Back(strOutMsg)
                GenILLTemplate = strOutMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                'objTVCom = Nothing
            End Try
        End Function

        Public Function GenNoticePatron(ByVal intTempType As Integer, ByVal lngRequestID As Integer, ByVal tblPatronInfor As DataTable, ByVal tblResponseInfor As DataTable, ByVal intTemplateID As Integer) As Metric
            'Dim objTVCom As New TVCOMLib.LibolTemplate
            Dim objFields As Object
            Dim objData As Object
            Dim strOutMsg(0) As String
            Dim strEmailAddess(0) As String
            Dim inti As Integer
            Dim objMetric As Metric
            Dim tblResult As DataTable
            Dim strTmpContent As String

            Try
                If Not tblResponseInfor Is Nothing AndAlso tblResponseInfor.Rows.Count > 0 Then
                    tblResult = GetTemplate(intTemplateID, intTempType)

                    strTmpContent = tblResult.Rows(0).Item("Content")

                    'objTVCom.Template = objBCSP.ToUTF8(strTmpContent)
                    'objFields = objTVCom.Fields
                    Dim strContentTemp As String = objBCSP.ToUTF8(strTmpContent)
                    objFields = objBCommonTemplate.getArrayFromTemplate(strContentTemp)
                    If Not IsNothing(objFields) AndAlso IsArray(objFields) Then
                        ReDim objData(UBound(objFields))
                        'Load data to array
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
                                    Try
                                        If Not IsDBNull(tblResponseInfor.Rows(0).Item(objFields(inti))) Then
                                            objData(inti) = objBCSP.ToUTF8(tblResponseInfor.Rows(0).Item(objFields(inti))) & Chr(9)
                                        Else
                                            objData(inti) = " " & Chr(9)
                                        End If
                                    Catch ex As Exception
                                        Try
                                            If Not IsDBNull(tblPatronInfor.Rows(0).Item(objFields(inti))) Then
                                                objData(inti) = objBCSP.ToUTF8(tblPatronInfor.Rows(0).Item(objFields(inti))) & Chr(9)
                                            Else
                                                objData(inti) = " " & Chr(9)
                                            End If
                                        Catch ex1 As Exception
                                            strErrorMsg = ex.Message
                                        End Try
                                    End Try
                            End Select

                            strContentTemp = Replace(strContentTemp, "<$" & objFields(inti) & "$>", objData(inti))
                        Next
                    End If
                    
                    'Display data here
                    'strOutMsg(0) = objBCSP.ToUTF8Back(objTVCom.Generate(objData))
                    strOutMsg(0) = strContentTemp

                    If Not IsDBNull(tblResponseInfor.Rows(0).Item("Email")) Then
                        strEmailAddess(0) = tblResponseInfor.Rows(0).Item("Email")
                    Else
                        strEmailAddess(0) = "lent@GREENHOUSE.com"
                    End If
                    objMetric.arrStrEmailAddress = strEmailAddess
                    objMetric.arrStrOutMsg = strOutMsg
                    Return (objMetric)
                End If

            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                'objTVCom = Nothing
            End Try

        End Function
        'GenNoticeTemplate method
        'Purpose: Get data for template of the selected request
        'Output: Matric 
        'Note: Alls field in database same data in bcol(bcol is a array which init in WebUI) 
        'Creator: Tuanhv
        'Date" 22/12/2004
        Public Function GenNoticeTemplate(ByVal intTempType As Integer, ByVal lngRequestID As Integer, ByVal tblPatronInfor As DataTable, ByVal tblResponseInfor As DataTable, ByVal intTemplateID As Integer) As Metric
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
            Dim tblTemplateDeny As DataTable
            Dim tblResult As DataTable
            Dim intk As Integer
            Dim inti As Integer
            Dim intj As Integer
            Dim strms As String 'width collum
            Dim strma As String 'align collum
            Dim strmf As String 'format collum
            Dim boomf As Boolean 'control format template
            Dim strHeader As String = ""
            Dim strFooter As String = ""
            'Get ClaimTemplate
            Try
                tblTemplateDeny = GetTemplate(intTemplateID, intTempType)

                If Not tblTemplateDeny Is Nothing Then
                    If tblTemplateDeny.Rows.Count > 0 Then
                        objarrContent = Split(tblTemplateDeny.Rows(0).Item("Content"), Chr(9))
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
                        objFields = objBCommonTemplate.getArrayFromTemplate(strContentTemp)
                        intk = 0

                        'Select Content
                        If UBound(bCols) > 0 Then
                            For inti = 0 To UBound(bCols)
                                bCols(inti) = Trim(bCols(inti))
                                bCols(inti) = bCols(inti).Substring(2, Len(bCols(inti)) - 4)
                                ReDim Preserve bColLabel(intk)
                                If UBound(bUserColLabel) >= inti Then
                                    If Not Trim(bUserColLabel(inti)) = "" Then
                                        bColLabel(intk) = bUserColLabel(inti)
                                    Else
                                        bColLabel(intk) = collectionContentData.Item("<$" & bCols(intk) & "$>")
                                    End If
                                Else
                                    bColLabel(intk) = collectionContentData.Item("<$" & bCols(intk) & "$>")
                                End If
                                intk += 1
                            Next
                        End If

                        tblResult = tblResponseInfor
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

                                'Can select some ItemID
                                ReDim arrIDs(0)
                                ReDim strOutMsg(UBound(arrIDs))
                                ReDim strEmailAddess(UBound(arrIDs))

                                'Can exit some row in body template
                                intm = 0

                                'Get information for Header or Footer
                                If Not IsNothing(objFields) AndAlso IsArray(objFields) Then
                                    ReDim objData(UBound(objFields))
                                    If Not tblResult Is Nothing Then
                                        If tblResult.Rows.Count > 0 Then
                                            For inti = 0 To UBound(objFields)
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
                                                    Case "SHIPPEDDATE"
                                                        Try
                                                            If Not IsDBNull(tblResult.Rows(0).Item("REQUESTDATE")) Then
                                                                objData(inti) = objBCSP.ToUTF8(tblResult.Rows(0).Item("REQUESTDATE")) & Chr(9)
                                                            Else
                                                                objData(inti) = " " & Chr(9)
                                                            End If
                                                        Catch ex As Exception
                                                            Try
                                                                If Not IsDBNull(tblPatronInfor.Rows(0).Item("REQUESTDATE")) Then
                                                                    objData(inti) = objBCSP.ToUTF8(tblPatronInfor.Rows(0).Item("REQUESTDATE")) & Chr(9)
                                                                Else
                                                                    objData(inti) = " " & Chr(9)
                                                                End If
                                                            Catch ex1 As Exception
                                                                strErrorMsg = ex.Message
                                                            End Try
                                                        End Try
                                                    Case Else
                                                        Try
                                                            If Not IsDBNull(tblResult.Rows(0).Item(objFields(inti))) Then
                                                                objData(inti) = objBCSP.ToUTF8(tblResult.Rows(0).Item(objFields(inti))) & Chr(9)
                                                            Else
                                                                objData(inti) = " " & Chr(9)
                                                            End If
                                                        Catch ex As Exception
                                                            Try
                                                                If Not IsDBNull(tblPatronInfor.Rows(0).Item(objFields(inti))) Then
                                                                    objData(inti) = objBCSP.ToUTF8(tblPatronInfor.Rows(0).Item(objFields(inti))) & Chr(9)
                                                                Else
                                                                    objData(inti) = " " & Chr(9)
                                                                End If
                                                            Catch ex1 As Exception
                                                                strErrorMsg = ex.Message
                                                            End Try
                                                        End Try
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
                                strOutMsg(intm) = strOutMsg(intm) & "<TABLE WIDTH=100% BORDER=0 CELLSPACING=0  CELLPADDING=1><TR><TD><TABLE WIDTH=100% BORDER=0  CELLSPACING=0  CELLPADDING=3>"
                                strOutMsg(intm) = strOutMsg(intm) & "<TR> "

                                'Collumn title
                                If Not bColLabel Is Nothing Then
                                    If UBound(bColLabel) > 0 Then
                                        For intj = 0 To UBound(bColLabel)
                                            strms = ""
                                            'Collumn Width
                                            If UBound(bUserColWidth) >= intj Then
                                                If Not Trim(bUserColWidth(intj)) = "" Then
                                                    strms = " WIDTH=""" & Trim(bUserColWidth(intj)) & """"
                                                End If
                                            End If

                                            strma = ""
                                            'Collumn Align
                                            If UBound(bUserColAlign) >= intj Then
                                                If Not Trim(bUserColAlign(intj)) = "" Then
                                                    strma = " ALIGN=""" & Trim(bUserColAlign(intj)) & """"
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
                                                strOutMsg(intm) = strOutMsg(intm) & "<TD VALIGN=TOP " & strms & strma & " ALIGN=TOP BGCOLOR=FFFFFF>" & bUserColFormat(intj).Replace("<$DATA$>", bColLabel(intj)) & "</TD>"
                                            Else
                                                strOutMsg(intm) = strOutMsg(intm) & "<TD  VALIGN=TOP " & strms & strma & "  BGCOLOR=FFFFFF>" & bColLabel(intj) & "</TD>"
                                            End If
                                        Next 'bColLabel
                                    End If
                                End If

                                strOutMsg(intm) = strOutMsg(intm) & "</TR>"
                                'for collum and row data
                                strOutMsg(intm) = strOutMsg(intm) & "<TR >"
                                'for collum and row data
                                If Not bCols Is Nothing Then
                                    If UBound(bCols) > 0 Then
                                        For inti = 0 To UBound(bCols)
                                            If bCols(inti) = "NO" Then
                                                If boomf Then
                                                    strOutMsg(intm) = strOutMsg(intm) & "<TD  VALIGN=TOP " & strms & strma & "  BGCOLOR=FFFFFF>" & bUserColFormat(inti).Replace("<$DATA$>", inti + 1) & "</TD>"
                                                Else
                                                    strOutMsg(intm) = strOutMsg(intm) & "<TD VALIGN=TOP " & strms & strma & " BGCOLOR=FFFFFF>" & inti + 1 & "&nbsp;</TD>"
                                                End If
                                            Else
                                                If boomf Then
                                                    strOutMsg(intm) = strOutMsg(intm) & "<TD  VALIGN=TOP " & strms & strma & "  BGCOLOR=FFFFFF>" & bUserColFormat(inti).Replace("<$DATA$>", dtRow.Item(bCols(inti))) & "</TD>"
                                                Else
                                                    strOutMsg(intm) = strOutMsg(intm) & "<TD VALIGN=TOP " & strms & strma & " BGCOLOR=FFFFFF>" & dtRow.Item(bCols(inti)) & "&nbsp;</TD>"
                                                End If
                                            End If

                                        Next
                                    End If
                                End If

                                strOutMsg(intm) = strOutMsg(intm) & "</TR>"
                                strOutMsg(intm) = strOutMsg(intm) & "</TABLE></TD></TR></TABLE>"
                                strOutMsg(intm) = strOutMsg(intm) & objBCSP.ToUTF8Back(Right(objStream, Len(objStream) - InStr(objStream, "@@@@@") - 4))
                                If Not IsDBNull(tblResponseInfor.Rows(0).Item("Email")) Then
                                    strEmailAddess(intm) = tblResponseInfor.Rows(0).Item("Email")
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
                ' objLBTemplate = Nothing
            End Try
        End Function

        'Purpose: Get denied to gen template
        'Input: TemplateType
        'Output: Datatable content pattern denied response
        'Creator: Tuanhv
        'Date: 21/12/2004
        Public Function GetGenTemplate(ByVal intTemplateType As Integer) As DataTable
            Try
                objBCommonTemplate.TemplateType = intTemplateType
                GetGenTemplate = objBCDBS.ConvertTable(objBCommonTemplate.GetTemplate)
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        'Dispose method
        'Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not objBCSP Is Nothing Then
                        objBCSP.Dispose(True)
                        objBCSP = Nothing
                    End If
                    If Not objBCommonTemplate Is Nothing Then
                        objBCommonTemplate.Dispose(True)
                        objBCommonTemplate = Nothing
                    End If
                    If Not objBCDBS Is Nothing Then
                        objBCDBS.Dispose(True)
                        objBCDBS = Nothing
                    End If
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Dispose()
            End Try
        End Sub
    End Class
End Namespace

