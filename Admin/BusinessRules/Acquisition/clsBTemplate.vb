' class: clsBTemplate
' Purpose: Manager template
' Creator: Sondp
' Created Date:
' History update:

Imports eMicLibAdmin.DataAccess.Acquisition
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports System.Collections.Generic
Imports System.Diagnostics.Eventing.Reader
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports System.Web
Imports System.Text
Imports System.Linq

Namespace eMicLibAdmin.BusinessRules.Acquisition
    Public Class clsBTemplate
        Inherits clsBCommonTemplate
        Private objBInput As New clsBInput
        Private objDT As New clsDTemplate
        Private objBLoc As New clsBLocation
        Private objBFSQL As New clsBFormingSQL
        Private objBCT As New clsBCommonTemplate
        Protected objBCSP As New clsBCommonStringProc
        Private objDCopyNumber As New clsDCopyNumber
        Private objBItem As New clsBItem
        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private strPageHeader As String
        Private strCollum As String
        Private strCollumCaption As String
        Private strCollumWidth As String
        Private strCollumAlign As String
        Private strCollumFormat As String
        Private strTableColor As String = "#FFFFFF"
        Private strEventColor As String = "#FFFFFF"
        Private strOddColor As String = "#FFFFFF"
        Private strPageFooter As String
        Private collCollumsTitle As New Collection
        Private collCollumsData As New Collection
        Private collHeaderFooter As New Collection
        Private intStoreID As Integer
        Private strFromDKCB As String
        Private strToDKCB As String
        Private strToTime As String
        Private strFromTime As String
        Private intFormal As Integer
        Private intOrder As Integer
        Private intBy As Integer
        Private strLiquidCode As String
        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************
        Public Property ItemTypeID() As Integer
        Public Property LanguageID() As Integer
        Public Property AcqSourceID() As Integer
        Public Property PONumber() As String
        Public Property Sh() As String
        Public Property DDC() As String
        Public Property Keyword() As String
        Public Property Cataloguer() As String
        Public Property Faculty() As Integer

        '' LibraryID property
        'Public Property LibID() As Integer
        '    Get
        '        Return (intLibID)
        '    End Get
        '    Set(ByVal Value As Integer)
        '        intLibID = Value
        '    End Set
        'End Property
        ' Store property
        Public Property StoreID() As Integer
            Get
                Return (intStoreID)
            End Get
            Set(ByVal Value As Integer)
                intStoreID = Value
            End Set
        End Property
        ' FromDKCB property
        Public Property FromDKCB() As String
            Get
                Return (strFromDKCB)
            End Get
            Set(ByVal Value As String)
                strFromDKCB = Value
            End Set
        End Property
        ' To DKCB property
        Public Property ToDKCB() As String
            Get
                Return (strToDKCB)
            End Get
            Set(ByVal Value As String)
                strToDKCB = Value
            End Set
        End Property
        ' FromTime property
        Public Property FromTime() As String
            Get
                Return (strFromTime)
            End Get
            Set(ByVal Value As String)
                strFromTime = Value
            End Set
        End Property
        ' ToTime property
        Public Property ToTime() As String
            Get
                Return (strToTime)
            End Get
            Set(ByVal Value As String)
                strToTime = Value
            End Set
        End Property
        ' Formal template property
        Public Property Formal() As Integer
            Get
                Return (intFormal)
            End Get
            Set(ByVal Value As Integer)
                intFormal = Value
            End Set
        End Property
        ' Order property 0: AcqusitionDate, 1: Title, 2: CopyNumber
        Public Property Order() As Integer
            Get
                Return (intOrder)
            End Get
            Set(ByVal Value As Integer)
                intOrder = Value
            End Set
        End Property
        ' Order vector property 0: descreate, 1: increate
        Public Property By() As Integer
            Get
                Return (intBy)
            End Get
            Set(ByVal Value As Integer)
                intBy = Value
            End Set
        End Property
        Public Property PageHeader() As String
            Get
                Return strPageHeader
            End Get
            Set(ByVal Value As String)
                strPageHeader = Value
            End Set
        End Property
        ' Property get/sert strCollum
        Public Property Collum() As String
            Get
                Return (strCollum)
            End Get
            Set(ByVal Value As String)
                strCollum = Value
            End Set
        End Property
        ' Property get/sert strCollumCaption
        Public Property CollumCaption() As String
            Get
                Return (strCollumCaption)
            End Get
            Set(ByVal Value As String)
                strCollumCaption = Value
            End Set
        End Property
        ' Property get/set strCollumWidth
        Public Property CollumWidth() As String
            Get
                Return (strCollumWidth)
            End Get
            Set(ByVal Value As String)
                strCollumWidth = Value
            End Set
        End Property
        ' Property get/set strCollumAlign
        Public Property CollumAlign() As String
            Get
                Return strCollumAlign
            End Get
            Set(ByVal Value As String)
                strCollumAlign = Value
            End Set
        End Property
        ' Property get/set strCollumFormal
        Public Property CollumFormat() As String
            Get
                Return strCollumFormat
            End Get
            Set(ByVal Value As String)
                strCollumFormat = Value
            End Set
        End Property
        ' Property get/sert strTabelColor
        Public Property TableColor() As String
            Get
                Return strTableColor
            End Get
            Set(ByVal Value As String)
                strTableColor = Value
            End Set
        End Property
        ' Property get/set strEventColor
        Public Property EventColor() As String
            Get
                Return strEventColor
            End Get
            Set(ByVal Value As String)
                strEventColor = Value
            End Set
        End Property
        '  Property get/set strOddColor
        Public Property OddColor() As String
            Get
                Return strOddColor
            End Get
            Set(ByVal Value As String)
                strOddColor = Value
            End Set
        End Property
        ' Property get/sert strPageFooter
        Public Property PageFooter() As String
            Get
                Return strPageFooter
            End Get
            Set(ByVal Value As String)
                strPageFooter = Value
            End Set
        End Property
        ' CollectionHeaderFooter property
        Public Property HeaderFooter() As Collection
            Get
                Return collHeaderFooter
            End Get
            Set(ByVal Value As Collection)
                collHeaderFooter = Value
            End Set
        End Property
        ' CollumsData property
        Public Property CollumsData() As Collection
            Get
                Return (collCollumsData)
            End Get
            Set(ByVal Value As Collection)
                collCollumsData = Value
            End Set
        End Property
        ' CollumsTitle property 
        Public Property CollumsTitle() As Collection
            Get
                Return collCollumsTitle
            End Get
            Set(ByVal Value As Collection)
                collCollumsTitle = Value
            End Set
        End Property

        Public Property LiquidCode() As String
            Get
                Return strLiquidCode
            End Get
            Set(ByVal Value As String)
                strLiquidCode = Value
            End Set
        End Property
        ' Purpose: define new structure like 4 array
        Structure Array4Direction
            Dim arrItemID() As String
            Dim arrTotalItemID() As String
            Dim arrTotalPrice() As Double
            Dim arrPrice() As Double
        End Structure

        ' Initialize method
        Public Shadows Sub Initialize()
            ' Initialize objDT object
            objDT.ConnectionString = strConnectionString
            objDT.DBServer = strDBServer
            objDT.Initialize()


            'objDCopyNumber
            objDCopyNumber.ConnectionString = strConnectionString
            objDCopyNumber.DBServer = strDBServer
            objDCopyNumber.Initialize()

            ' Initialize objBInput
            objBInput.ConnectionString = strConnectionString
            objBInput.DBServer = strDBServer
            objBInput.InterfaceLanguage = strInterfaceLanguage
            objBInput.Initialize()
            ' Initialize objBLoc
            objBLoc.ConnectionString = strConnectionString
            objBLoc.DBServer = strDBServer
            objBLoc.InterfaceLanguage = strInterfaceLanguage
            objBLoc.Initialize()
            ' Initialize objBFSQL object
            objBFSQL.InterfaceLanguage = strInterfaceLanguage
            objBFSQL.DBServer = strDBServer
            objBFSQL.ConnectionString = strConnectionString
            objBFSQL.Initialize()
            ' Initialize clsBCommonTemplate
            ' Init objBCT object
            objBCT.ConnectionString = strConnectionString
            objBCT.DBServer = strDBServer
            objBCT.InterfaceLanguage = strInterfaceLanguage
            Call objBCT.Initialize()
            ' Init objBCSP object
            objBCSP.ConnectionString = strConnectionString
            objBCSP.DBServer = strDBServer
            objBCSP.InterfaceLanguage = strInterfaceLanguage
            Call objBCSP.Initialize()
            ' Initialize objDT object
            objBItem.ConnectionString = strConnectionString
            objBItem.DBServer = strDBServer
            objBItem.InterfaceLanguage = strInterfaceLanguage
            objBItem.Initialize()

            MyBase.Initialize()
        End Sub

        ' Purpose: 
        ' In: 
        ' Out: 
        ' Creator: 
        Public Function GenItemOrder() As String
        End Function

        ' Purpose: Generate PO Template
        ' In: intTempType, and some data
        ' Out: string
        ' Creator: Sondp
        Public Function GenPOTemplate(ByVal intTempType As Integer) As String
            'Dim objTemplate As New TVCOMLib.LibolTemplate
            ' Dim objSort As New TVCOMLib.utf8
            'Dim objTvCom As New TVCOMLib.fonts
            Dim objFields As New Object
            Dim objData, objStream As Object
            Dim objColLabel(), objUserColLabel(), objUserColWidth(), objCols(), objUserColAlign(), objUserColFormat() As String
            Dim intk, inti, intj, intMaxRows, intSumVol, intSumPVol, intColspan, intSumRVol As Integer
            Dim dbSumAmount As Double
            Dim boolUsedSum, boolLJ, boolf As Boolean
            Dim strItem, strmw, strma, strmf, strChangeRowColor, strOutMsg As String
            If strCollum = "" Then
                Return (Nothing)
                Exit Function
            End If
            Try
                intk = 0
                boolUsedSum = True
                boolLJ = False
                strChangeRowColor = "#FFFFFF"
                intMaxRows = 5
                intSumVol = 0
                intSumPVol = 0
                intSumRVol = 0
                If strTableColor & "" = "" Then
                    strTableColor = "#FFFFFF" ' Default table color is white
                End If
                If strEventColor & "" = "" Then
                    strEventColor = "#FFFFFF"  ' Default event color is white
                End If
                If strOddColor & "" = "" Then
                    strOddColor = "#FFFFFF" ' Default odd color is white
                End If
                objUserColLabel = Split(strCollumCaption, vbCrLf)
                objUserColWidth = Split(strCollumWidth, vbCrLf)
                objUserColAlign = Split(strCollumAlign, vbCrLf)
                objUserColFormat = Split(strCollumFormat, vbCrLf)
                objCols = Split(strCollum, "<~>")
                ' Get collum title(s)
                For inti = LBound(objCols) To UBound(objCols)
                    Try
                        If Not objCols(inti) & "" = "" Then
                            ReDim Preserve objColLabel(intk)
                            If UBound(objUserColLabel) >= inti Then
                                If Not Trim(objUserColLabel(inti)) = "" Then
                                    objColLabel(intk) = objUserColLabel(inti)
                                Else
                                    objColLabel(intk) = collCollumsTitle.Item(objCols(inti))
                                End If
                            Else
                                objColLabel(intk) = collCollumsTitle.Item(objCols(inti))
                            End If
                            intk = intk + 1
                            If objCols(inti) = "<$REQUESTEDCOPIES$>" Or objCols(inti) = "<$ACCEPTEDCOPIES$>" Or objCols(inti) = "<$MONEY$>" Then
                                boolUsedSum = True
                            End If
                        End If
                    Catch ex As Exception
                        strErrorMsg = ex.Message
                    End Try
                Next
                ' Get Header and Footer data
                'objTemplate.Template = objbcsp.ToUTF8(strHeader) & "@@@@@" & objbcsp.ToUTF8(strFooter)
                'objFields = objTemplate.Fields
                'ReDim objData(UBound(objTemplate.Fields))

                Dim strContentTemp As String = strHeader & "@@@@@" & strFooter
                objFields = objBCT.getArrayFromTemplate(strContentTemp)
                If Not IsNothing(objFields) AndAlso IsArray(objFields) Then
                    ReDim objData(UBound(objFields))
                    For inti = LBound(objFields) To UBound(objFields)
                        Try
                            Select Case UCase(objFields(inti)) & ""
                                Case ""
                                    objData(inti) = "" & Chr(9)
                                Case Else
                                    objData(inti) = collHeaderFooter.Item(UCase(objFields(inti))) '& Chr(9)
                            End Select
                            strContentTemp = Replace(strContentTemp, "<$" & objFields(inti) & "$>", objData(inti))
                        Catch ex As Exception
                            strErrorMsg = ex.Message
                        End Try
                    Next
                End If
                objStream = strContentTemp
                'objStream = objTemplate.Generate(objData)

                objStream = Replace(objStream, "  ", "&nbsp;&nbsp;")
                strHeader = Left(objStream, InStr(objStream, "@@@@@") - 1)
                strFooter = Right(objStream, Len(objStream) - InStr(objStream, "@@@@@") - 4)
                ' Display data
                strOutMsg = strHeader
                strOutMsg = strOutMsg & "<TABLE WIDTH=100% BORDER=0 CELLSPACING=1  CELLPADDING=1 BGCOLOR=""#000000"">"
                strOutMsg = strOutMsg & "<TR BGCOLOR=" & strTableColor & " > "
                ' Collum Title
                For intj = LBound(objColLabel) To UBound(objColLabel)
                    Try
                        strmw = ""
                        ' Collum Width
                        If UBound(objUserColWidth) >= intj Then
                            If Not Trim(objUserColWidth(intj)) = "" Then
                                strmw = " WIDTH=""" & Trim(objUserColWidth(intj)) & """"
                            End If
                        End If
                        strma = ""
                        ' Collum Align
                        If UBound(objUserColAlign) >= intj Then
                            If Not Trim(objUserColAlign(intj)) = "" Then
                                strma = " ALIGN=""" & Trim(objUserColAlign(intj)) & """"
                            End If
                        End If
                        ' Collum Format
                        If UBound(objUserColFormat) >= intj Then
                            If Not Trim(objUserColFormat(intj)) = "" Then
                                strmf = ""
                            End If
                        End If
                    Catch ex As Exception
                        strErrorMsg = ex.Message
                    End Try
                    Try
                        Select Case intTempType
                            Case 10 ' Separated store template
                                strOutMsg = strOutMsg & "<TH ALIGN=""center"" VALIGN=TOP BGCOLOR=" & strTableColor & "  " & strmw & strma & " ROWSPAN = 3>" & objColLabel(intj) & "</TH>"
                            Case Else
                                strOutMsg = strOutMsg & "<TH ALIGN=""center"" VALIGN=TOP BGCOLOR=" & strTableColor & "  " & strmw & strma & ">" & objColLabel(intj) & "</TH>"
                        End Select
                    Catch ex As Exception
                        strErrorMsg = ex.Message
                    End Try
                Next
                ' Some information for only Separated store template
                Select Case intTempType
                    Case 10
                        strOutMsg = strOutMsg & "<TH BGCOLOR=" & strTableColor & " ROWSPAN = 3>" & collCollumsData.Item("<$AMOUNT$>") & "</TH>"
                        strOutMsg = strOutMsg & "<TH BGCOLOR=" & strTableColor & " ROWSPAN = 3>" & collCollumsData.Item("<$AMOUNTMONEY$>") & "<BR></TH>"
                        strOutMsg = strOutMsg & "<TH BGCOLOR=" & strTableColor & " COLSPAN =4>" & collCollumsData.Item("<$STORE$>") & "</TH>"
                        strOutMsg = strOutMsg & "</TR>"
                        strOutMsg = strOutMsg & "<TR BGCOLOR=" & strTableColor & ">"
                        strOutMsg = strOutMsg & "<TH BGCOLOR=" & strTableColor & " COLSPAN = 2>" & collCollumsData.Item("<$STOREA1$>") & "</TH>"
                        strOutMsg = strOutMsg & "<TH BGCOLOR=" & strTableColor & " COLSPAN = 2>" & collCollumsData.Item("<$STOREA2$>") & "</TH>"
                        strOutMsg = strOutMsg & "</TR>"
                        strOutMsg = strOutMsg & "<TR BGCOLOR=" & strTableColor & ">"
                        strOutMsg = strOutMsg & "<TH VALIGN=TOP BGCOLOR=" & strTableColor & ">" & collCollumsData.Item("<$SLG$>") & "</TH>"
                        strOutMsg = strOutMsg & "<TH VALIGN=TOP BGCOLOR=" & strTableColor & ">" & collCollumsData.Item("<$AMOUNTMONEY$>") & "</TH>"
                        strOutMsg = strOutMsg & "<TH VALIGN=TOP BGCOLOR=" & strTableColor & ">" & collCollumsData.Item("<$SLG$>") & "</TH>"
                        strOutMsg = strOutMsg & "<TH VALIGN=TOP BGCOLOR=" & strTableColor & ">" & collCollumsData.Item("<$AMOUNTMONEY$>") & "</TH>"
                End Select
                strOutMsg = strOutMsg & "</TR>"
                For intj = 1 To intMaxRows
                    If intj Mod 2 = 0 Then ' Change color
                        strChangeRowColor = strEventColor
                    Else
                        strChangeRowColor = strOddColor
                    End If
                    strOutMsg = strOutMsg & "<TR BGCOLOR=" & strChangeRowColor & ">"
                    For inti = 0 To UBound(objCols)
                        ' Width
                        strmw = ""
                        If UBound(objUserColWidth) >= inti Then
                            If Not Trim(objUserColWidth(inti)) = "" Then
                                strmw = " WIDTH=""" & Trim(objUserColWidth(inti)) & """"
                            End If
                        End If
                        ' Align 
                        strma = ""
                        If UBound(objUserColAlign) >= inti Then
                            If Not Trim(objUserColAlign(inti)) = "" Then
                                strma = " ALIGN=""" & Trim(objUserColAlign(inti)) & """"
                            End If
                        End If
                        ' Format
                        strmf = ""
                        boolf = False ' Default not have format
                        If UBound(objUserColFormat) >= inti Then
                            If Not Trim(objUserColFormat(inti)) = "" Then
                                boolf = True ' Have format
                            End If
                        End If
                        Try
                            Select Case objCols(inti)
                                Case "<$SEQUENCY$>"
                                    If boolf Then
                                        strOutMsg = strOutMsg & "<TD VALIGN=TOP BGCOLOR=" & strChangeRowColor & strmw & strma & ">" & objUserColFormat(inti).Replace("<$DATA$>", CStr(intj)) & "</TD>"
                                    Else
                                        strOutMsg = strOutMsg & "<TD  VALIGN=TOP BGCOLOR=" & strChangeRowColor & strmw & strma & ">" & CStr(intj) & "</TD>"
                                    End If
                                Case "<$CURRENCY$>"
                                    intSumPVol = intMaxRows * CInt(collCollumsData.Item("<$REQUESTEDCOPIES$>"))
                                    If boolf Then
                                        strOutMsg = strOutMsg & "<TD  VALIGN=TOP BGCOLOR=" & strChangeRowColor & strmw & strma & ">" & objUserColFormat(inti).Replace("<$DATA$>", collCollumsData.Item(objCols(inti))) & "</TD>"
                                    Else
                                        strOutMsg = strOutMsg & "<TD  VALIGN=TOP  BGCOLOR=" & strChangeRowColor & strmw & strma & ">" & CStr(collCollumsData.Item(objCols(inti))) & "</TD>"
                                    End If
                                Case "<$REQUESTEDCOPIES$>"
                                    intSumRVol = intMaxRows * CInt(collCollumsData.Item("<$REQUESTEDCOPIES$>"))
                                    If boolf Then
                                        strOutMsg = strOutMsg & "<TD  VALIGN=TOP  BGCOLOR=" & strChangeRowColor & strmw & strma & ">" & objUserColFormat(inti).Replace("<$DATA$>", collCollumsData.Item(objCols(inti))) & "</TD>"
                                    Else
                                        strOutMsg = strOutMsg & "<TD  VALIGN=TOP  BGCOLOR=" & strChangeRowColor & strmw & strma & ">" & CStr(collCollumsData.Item(objCols(inti))) & "</TD>"
                                    End If
                                Case "<$ACCEPTEDCOPIES$>"
                                    intSumVol = intMaxRows * CInt(collCollumsData.Item("<$ACCEPTEDCOPIES$>"))
                                    If boolf Then
                                        strOutMsg = strOutMsg & "<TD  VALIGN=TOP  BGCOLOR=" & strChangeRowColor & strmw & strma & ">" & objUserColFormat(inti).Replace("<$DATA$>", collCollumsData.Item(objCols(inti))) & "</TD>"
                                    Else
                                        strOutMsg = strOutMsg & "<TD  VALIGN=TOP  BGCOLOR=" & strChangeRowColor & strmw & strma & ">" & CStr(collCollumsData.Item(objCols(inti))) & "</TD>"
                                    End If
                                Case "<$MONEY$>"
                                    dbSumAmount = CDbl(50 * CDbl(collCollumsData.Item("<$UNITPRICE$>")) * CInt(collCollumsData.Item("<$ACCEPTEDCOPIES$>")))
                                    If boolf Then
                                        strOutMsg = strOutMsg & "<TD  VALIGN=TOP  BGCOLOR=" & strChangeRowColor & strmw & strma & ">" & objUserColFormat(inti).Replace("<$DATA$>", collCollumsData.Item(objCols(inti))) & "</TD>"
                                    Else
                                        strOutMsg = strOutMsg & "<TD  VALIGN=TOP   BGCOLOR=" & strChangeRowColor & strmw & strma & ">" & CStr(collCollumsData.Item(objCols(inti))) * CInt(collCollumsData.Item("<$ACCEPTEDCOPIES$>")) & "</TD>"
                                    End If
                                Case Else
                                    If boolf Then
                                        strOutMsg = strOutMsg & "<TD  VALIGN=TOP  BGCOLOR=" & strChangeRowColor & strmw & strma & ">" & objUserColFormat(inti).Replace("<$DATA$>", collCollumsData.Item(objCols(inti))) & "</TD>"
                                    Else
                                        strOutMsg = strOutMsg & "<TD  VALIGN=TOP  BGCOLOR=" & strChangeRowColor & strmw & strma & ">" & CStr(collCollumsData.Item(objCols(inti))) & "</TD>"
                                    End If
                            End Select
                        Catch ex As Exception
                            strErrorMsg = ex.Message
                        End Try
                    Next
                    Select Case intTempType
                        Case 10 ' Separated store template
                            strOutMsg = strOutMsg & "<TD ALIGN=RIGHT BGCOLOR= " & strChangeRowColor & " >" & collCollumsData.Item("<$25$>") & "</TD>"
                            strOutMsg = strOutMsg & "<TD ALIGN=RIGHT BGCOLOR=" & strChangeRowColor & ">" & collCollumsData.Item("<$790$>") & "</TD>"
                            strOutMsg = strOutMsg & "<TD ALIGN=RIGHT BGCOLOR=" & strChangeRowColor & ">" & collCollumsData.Item("<$5$>") & "</TD>"
                            strOutMsg = strOutMsg & "<TD ALIGN=RIGHT BGCOLOR=" & strChangeRowColor & ">" & collCollumsData.Item("<$395$>") & "</TD>"
                            strOutMsg = strOutMsg & "<TD ALIGN=RIGHT BGCOLOR=" & strChangeRowColor & ">" & collCollumsData.Item("<$5$>") & "</TD>"
                            strOutMsg = strOutMsg & "<TD ALIGN=RIGHT BGCOLOR=" & strChangeRowColor & ">" & collCollumsData.Item("<$395$>") & "</TD>"
                            strOutMsg = strOutMsg & "<TR BGCOLOR=" & strChangeRowColor & ">"
                        Case Else
                    End Select
                    strOutMsg = strOutMsg & "</TR>" & Chr(10)
                Next
                ' Dependon TemplateType will display some add information
                Select Case intTempType
                    Case 9 ' Request Template
                        If boolUsedSum = True Then
                            strOutMsg = strOutMsg & "<TR BGCOLOR=" & strTableColor & ">"
                            intk = 0
                            For inti = 0 To UBound(objCols)
                                If objCols(inti) = "<$REQUESTEDCOPIES$>" Then
                                    If intk > 0 Then
                                        strOutMsg = strOutMsg & "<TD COLSPAN=""" & intk & """>&nbsp</TD>"
                                    End If
                                    intk = 0
                                    strOutMsg = strOutMsg & "<TD ALIGN=""right""><B>" & intSumRVol & "</B></TD>"
                                ElseIf objCols(inti) = "<$ACCEPTEDCOPIES$>" Then
                                    If intk > 0 Then
                                        strOutMsg = strOutMsg & "<TD COLSPAN=""" & intk & """>&nbsp</TD>"
                                    End If
                                    intk = 0
                                    strOutMsg = strOutMsg & "<TD ALIGN=""right""><B>" & intSumVol & "</B></TD>"
                                ElseIf objCols(inti) = "<$MONEY$>" Then
                                    If intk > 0 Then
                                        strOutMsg = strOutMsg & "<TD COLSPAN=""" & intk & """>&nbsp</TD>"
                                    End If
                                    intk = 0
                                    strOutMsg = strOutMsg & "<TD ALIGN=""right""><B>" & dbSumAmount & "</B></TD>"
                                ElseIf Not objCols(inti) = "" Then
                                    intk = intk + 1
                                End If
                            Next
                            If intk > 0 Then
                                strOutMsg = strOutMsg & "<TD COLSPAN=""" & intk & """>&nbsp</TD>"
                            End If
                            strOutMsg = strOutMsg & "</TR>"
                        End If
                    Case 10 ' Separated store template
                        If Not strCollum & "" = "" Then
                            If UBound(objCols) > 22 Then ' Maximunm(UBound(objCols))=23
                                intColspan = UBound(objCols) ' For all collums or lost one collum
                            Else
                                intColspan = UBound(objCols) + 1 ' For lost atless two collums
                            End If
                            strOutMsg = strOutMsg & "<TD ALIGN = RIGHT COLSPAN =" & intColspan & " BGCOLOR=" & strTableColor & "><B>" & collCollumsData.Item("<$SUMCOUNT$>") & "</B></TD>"
                        Else
                            strOutMsg = strOutMsg & "<TD ALIGN = RIGHT BGCOLOR=" & strTableColor & "><B>" & collCollumsData.Item("<$SUMCOUNT$>") & "</B></TD>"
                        End If
                        strOutMsg = strOutMsg & "<TD ALIGN = RIGHT BGCOLOR=" & strTableColor & "><B>" & collCollumsData.Item("<$50$>") & "</B></TD>"
                        strOutMsg = strOutMsg & "<TD ALIGN = RIGHT BGCOLOR=" & strTableColor & "><B>" & collCollumsData.Item("<$3950$>") & "</B></TD>"
                        strOutMsg = strOutMsg & "<TD ALIGN = RIGHT BGCOLOR=" & strTableColor & "><B>" & collCollumsData.Item("<$25$>") & "</B></TD>"
                        strOutMsg = strOutMsg & "<TD ALIGN = RIGHT BGCOLOR=" & strTableColor & "><B>" & collCollumsData.Item("<$1975$>") & "</B></TD>"
                        strOutMsg = strOutMsg & "<TD ALIGN = RIGHT BGCOLOR=" & strTableColor & "><B>" & collCollumsData.Item("<$25$>") & "</B></TD>"
                        strOutMsg = strOutMsg & "<TD ALIGN = RIGHT BGCOLOR=" & strTableColor & "><B>" & collCollumsData.Item("<$1975$>") & "</B></TD>"
                        strOutMsg = strOutMsg & "</TR>"
                End Select
                strOutMsg = strOutMsg & "</TABLE>"
                strOutMsg = strOutMsg & strFooter
                GenPOTemplate = strOutMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                'If Not objTemplate Is Nothing Then
                '    objTemplate = Nothing
                'End If
                'If Not objSort Is Nothing Then
                '    objSort = Nothing
                'End If
                'If Not objTvCom Is Nothing Then
                '    objTvCom = Nothing
                'End If
            End Try
        End Function

        ' Purpose: 
        ' In: 
        ' Out: 
        ' Creator: 
        Public Function GenComplain() As String

        End Function

        ' Purpose: 
        ' In: 
        ' Out: 
        ' Creator: 
        Public Function GenDistribute() As String

        End Function

        ' Purpose: Generate CopyNumbe removed
        ' In:  strIDs
        ' Out:  Datatable
        ' Creator:  Sondp
        Public Function GetCopyNumRem(ByVal strIDs As String) As DataTable
            Try
                objDT.IDs = strIDs
                GetCopyNumRem = objBCDBS.ConvertTable(objDT.GetCopyNumRem, "Content")
                strErrorMsg = objDT.ErrorMsg
                intErrorCode = objDT.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose: Generate BookLabelTemplate
        ' In:  Some infor
        ' Out:  string
        ' Creator:  Sondp
        Public Function GenBookLabelTemplate(ByVal strContent As String, ByVal collecData As Collection) As String
            'Dim libcomTemp As New TVCOMLib.LibolTemplate
            'Dim tvcom As New TVCOMLib.utf8
            Dim objFields As Object
            Dim objData As Object
            Dim objSubVal As Object
            Dim strutag As String
            Dim strtag As String
            Dim objStream As Object
            Dim boolUpperIt As Boolean
            Dim strexclTags As String = "001,900,907,911,912,925,926,927,id,leader,no,curday,curmonth,curyear,"
            Dim intl As Integer
            GenBookLabelTemplate = Nothing
            Try
                'libcomTemp.Template = objBCSP.ToUTF8(strContent)
                'objFields = libcomTemp.Fields()
                objFields = objBCT.getArrayFromTemplate(strContent)
                If Not IsNothing(objFields) AndAlso IsArray(objFields) Then
                    ReDim objData(UBound(objFields))
                    For intl = LBound(objFields) To UBound(objFields)
                        strutag = objFields(intl)
                        If InStr(UCase(strutag), ":UPPER") > 0 Then
                            boolUpperIt = True
                        Else
                            boolUpperIt = False
                        End If
                        strutag = Replace(LCase(objFields(intl)), ":upper", "")
                        If InStr(strexclTags, strutag & ",") > 0 Then
                            Try
                                objData(intl) = collecData.Item(strutag) & Chr(9)
                            Catch ex As Exception
                                objData(intl) = ""
                            End Try
                        ElseIf InStr(strutag, "holding") = 0 Then
                            strtag = Left(strutag, 3)
                            Try
                                objData(intl) = collecData.Item(strtag)
                            Catch ex As Exception
                                objData(intl) = ""
                            End Try
                            If Len(strutag) > 3 Then
                                Dim SubFieldCode As String
                                SubFieldCode = Right(strutag, 2)
                                If Not objData(intl) = "" Then
                                    objBCSP.ParseField(SubFieldCode, objData(intl), "tr", objSubVal)
                                    objData(intl) = objBCSP.TheDisplayOne(objSubVal(0) & Chr(9))
                                    If objData(intl) = "" Then
                                        objData(intl) = collecData.Item("LIBOL1") & " " & Replace(strutag, "$", "&#36;") & Chr(9)
                                    End If
                                Else
                                    objData(intl) = collecData.Item("LIBOL1") & " " & Replace(strutag, "$", "&#36;") & Chr(9)
                                End If
                            Else
                                If Not objData(intl) = "" Then
                                    objData(intl) = objBCSP.TheDisplayOne(objData(intl)) & Chr(9)
                                Else
                                    objData(intl) = collecData.Item("LIBOL1") & " " & strutag
                                End If
                            End If
                        ElseIf InStr(strutag, "holdingcomposite") = 1 Then
                            If InStr(strutag, ":lib") > 0 Then
                                objData(intl) = objData(intl) & collecData.Item("LIB")
                            End If
                            If InStr(strutag, ":inventory") > 0 Then
                                objData(intl) = objData(intl) & collecData.Item("INVENTORY")
                            End If
                            If InStr(strutag, ":shelf") > 0 Then
                                objData(intl) = objData(intl) & collecData.Item("SHELF")
                            End If
                            objData(intl) = objData(intl) & collecData.Item("NUMBER")
                        Else
                            If InStr(strutag, ":intlib") > 0 Then
                                objData(intl) = objData(intl) & collecData.Item("LIB")
                            End If
                            If InStr(strutag, ":inventory") > 0 Then
                                objData(intl) = objData(intl) & collecData.Item("INVENTORY")
                            End If
                            If InStr(strutag, ":shelf") > 0 Then
                                objData(intl) = objData(intl) & collecData.Item("SHELF")
                            End If
                            If InStr(strutag, ":number") > 0 Then
                                objData(intl) = objData(intl) & collecData.Item("NUMBER")
                            End If
                            If InStr(strutag, ":bnumber") > 0 Then
                                Dim tbltmp As DataTable

                                tbltmp = objBCDBS.ConvertTable(objDCopyNumber.GetNumberRowOfCopyNumber(collecData.Item("NUMBER")))
                                If Not tbltmp Is Nothing AndAlso tbltmp.Rows.Count > 0 Then
                                    strContent = Replace(strContent, "<$" & objFields(intl) & "$>", "B" & tbltmp.Rows(0).Item("stt"))
                                Else
                                    strContent = Replace(strContent, "<$" & objFields(intl) & "$>", "")

                                End If


                            End If
                            If InStr(strutag, ":callnumber") > 0 Then
                                objData(intl) = objData(intl) & collecData.Item("CALLNUMBER")
                            End If
                            objData(intl) = objData(intl) & Chr(9)
                        End If
                        If Not objData(intl) = "" Then
                            objData(intl) = Left(objData(intl), Len(objData(intl)) - 1)
                        End If
                        If boolUpperIt Then
                            objData(intl) = UCase(objData(intl)) ' tvcom.Upper(objData(intl))
                        End If
                        strContent = Replace(strContent, "<$" & objFields(intl) & "$>", objData(intl))
                    Next
                End If
                'objStream = objBCsp.TrimSubFieldCodes(objBCsp.ToUTF8Back(libcomTemp.Generate(objData).ToString))
                objStream = strContent
                GenBookLabelTemplate = objStream
            Catch ex As Exception
                GenBookLabelTemplate = Nothing
            Finally
                'libcomTemp = Nothing
                'tvcom = Nothing
            End Try
        End Function

        ' Purpose: Gen AcqReport for display report with data select from database
        ' In: intTemplateID, lngStartID, lngStopID, strIDs, collAcq 
        ' Out: string
        ' Creator:  Sondp
        Public Function GenACQReport(ByVal intTemplateID As Integer, ByVal lngStartID As Long, ByVal lngStopID As Long, ByVal strIDs As String, ByVal collAcq As Collection) As String
            'Dim objLBTemplate As New TVCOMLib.LibolTemplate
            Try
                If intTemplateID = 0 Then
                    GenACQReport = Nothing
                    Exit Function
                End If
                Dim tblTemplate As New DataTable
                Dim tblData, tblAuthor, tblTitle, tblPublisher, tblDDC, tblISBN, tblSOHD As DataTable
                Dim dtrowDatas(), dtrowAuthors(), dtrowTitles(), dtrowPublishers(), dtrowISBNs(), dtrowSOHDs(), dtrowDDCs(), dtrowData, dtrowAuthor, dtrowTitle, dtrowPublisher, dtrowISBN, dtrowSOHD, dtrowDDC As DataRow
                Dim arrIDs() As String
                Dim subVal() As Object = Nothing
                Dim strHeader, strCollums, strCollumCaptions, strCollumWidths,
                    strCollumAligns, strCollumFormats, strTableColor, strOddColor, strEventColor, strFooter,
                    strma, strmw, strmf, strChangeRowColor, strOutMsg, strItem, strTitle, strPublisher, strPrice, strAquisitionDate,
                    strCopyNumber, strNote, strPubYear, strAuthor, strISBN, strSOHD, strDDC As String
                Dim bCols(), bColLabels(), bUserColLabels(), bUserColWidths(), bUserColAligns(), bUserColFormats() As String
                Dim objFields As New Object
                Dim objData As New Object
                Dim objStream As New Object
                Dim inti, intj, intk As Integer
                Dim boolmf As Boolean
                strNote = ""
                TemplateID = intTemplateID
                TemplateType = 11
                tblTemplate = GetTemplate()
                If Not tblTemplate Is Nothing Then
                    If tblTemplate.Rows.Count > 0 Then
                        arrIDs = Split(tblTemplate.Rows(0).Item("Content"), Chr(9))
                        If UBound(arrIDs) > 0 Then
                            strHeader = objBCSP.ToUTF8(arrIDs(0))
                            strPageHeader = arrIDs(1)
                            strCollums = arrIDs(2)
                            strCollumCaptions = arrIDs(3)
                            strCollumWidths = arrIDs(4)
                            strCollumAligns = arrIDs(5)
                            strCollumFormats = arrIDs(6)
                            ' Table color
                            If Not arrIDs(7) & "" = "" Then
                                strTableColor = arrIDs(7)
                            Else
                                strTableColor = "#DDDDDD"
                            End If
                            ' Event color
                            If Not arrIDs(8) & "" = "" Then
                                strEventColor = arrIDs(8)
                            Else
                                strEventColor = "#FFFFFF"
                            End If
                            ' Odd color
                            If Not arrIDs(9) & "" = "" Then
                                strOddColor = arrIDs(9)
                            Else
                                strOddColor = "#F0F3F4"
                            End If
                            'tulnn edit 27/8
                            'strPageFooter = arrIDs(10)
                            strPageFooter = "<div align='left' style='width:100%'>" & objBCSP.ToUTF8(arrIDs(11)) & "</div><div align='right' style='width:100%'>" & arrIDs(10) & "</div>"
                            'end edit
                            strFooter = objBCSP.ToUTF8(arrIDs(11))
                            ' Process for Header and Footer
                            'objLBTemplate.Template = strHeader.Replace("<~>", "") & "@@@@@" & strFooter.Replace("<~>", "")
                            'objFields = objLBTemplate.Fields
                            Dim strContentTemp As String = strHeader.Replace("<~>", "") & "@@@@@" & strFooter.Replace("<~>", "")
                            objFields = objBCT.getArrayFromTemplate(strContentTemp)

                            If Not IsNothing(objFields) AndAlso IsArray(objFields) Then
                                ReDim objData(UBound(objFields))
                                For inti = LBound(objFields) To UBound(objFields)
                                    Select Case Len(UCase(objFields(inti)))
                                        Case Is > 0
                                            strItem = "" & "" & UCase(objFields(inti)) & "" & ""
                                            objData(inti) = collAcq.Item(strItem)
                                            strContentTemp = Replace(strContentTemp, "<$" & objFields(inti) & "$>", objData(inti))
                                        Case Else
                                            objData(inti) = ""
                                    End Select
                                Next
                            End If

                            'objStream = objLBTemplate.Generate(objData)
                            objStream = strContentTemp
                            strHeader = objBCSP.ToUTF8Back(Left(objStream, InStr(objStream, "@@@@@") - 1))
                            strFooter = objBCSP.ToUTF8Back(Right(objStream, Len(objStream) - InStr(objStream, "@@@@@") - 4))
                            strOutMsg = strHeader
                            ' Process for collums title
                            bCols = Split(strCollums, "<~>")
                            bUserColLabels = Split(strCollumCaptions, "<~>")
                            bUserColWidths = Split(strCollumWidths, "<~>")
                            bUserColAligns = Split(strCollumAligns, "<~>")
                            bUserColFormats = Split(strCollumFormat, "<~>")
                            intk = 0
                            ' Ga'n ca'c tie^u dde^` tu+o+ng u+'ng cho ca'c co^.t
                            For inti = LBound(bCols) To UBound(bCols)
                                Try
                                    ReDim Preserve bColLabels(intk)
                                    strItem = "" & "" & bCols(inti) & "" & ""
                                    If UBound(bUserColLabels) >= inti Then
                                        If Not Trim(bUserColLabels(inti)) = "" Then
                                            bColLabels(intk) = bUserColLabels(inti)
                                        Else
                                            bColLabels(intk) = collAcq.Item(strItem)
                                        End If
                                    Else
                                        bColLabels(intk) = collAcq.Item(strItem)
                                    End If
                                Catch ex As Exception
                                    bColLabels(intk) = ""
                                Finally
                                    intk = intk + 1
                                End Try
                            Next
                            strOutMsg = strOutMsg & "<TABLE WIDTH=100% BGCOLOR=000000><TR><TD WIDTH=100% BGCOLOR=000000>"
                            strOutMsg = strOutMsg & "<TABLE WIDTH=100% CELLSPACING=1 CELLPADDING=1 BORDER=1>"
                            strOutMsg = strOutMsg & "<TR BGCOLOR=" & strTableColor & ">"
                            For inti = LBound(bColLabels) To UBound(bColLabels)
                                ' Collum width
                                strmw = ""
                                If UBound(bUserColWidths) >= inti Then
                                    If Not Trim(bUserColWidths(inti)) = "" Then
                                        strmw = " WIDTH=""" & Trim(bUserColWidths(inti)) & """"
                                    End If
                                End If
                                ' Collum align
                                strma = " ALIGN=CENTER "
                                If UBound(bUserColAligns) >= inti Then
                                    If Not Trim(bUserColAligns(inti)) = "" Then
                                        strma = " ALIGN=""" & Trim(bUserColAligns(inti)) & """"
                                    End If
                                End If
                                ' Collum format
                                strmf = ""
                                If UBound(bUserColFormats) >= inti Then
                                    If Not Trim(bUserColFormats(inti)) = "" Then
                                        strmf = bUserColFormats(inti).Replace("<$DATA$>", bColLabels(inti))
                                    End If
                                End If
                                If strmf <> "" Then
                                    strOutMsg = strOutMsg & "<TH VALIGN=TOP" & strmw & strma & ">" & strmf & "</TH>"
                                Else
                                    strOutMsg = strOutMsg & "<TH VALIGN=TOP" & strmw & strma & ">" & bColLabels(inti) & "</TH>"
                                End If
                            Next
                            strOutMsg = strOutMsg & "</TR>"
                            ' Get data
                            objDT.IDs = strIDs
                            objDT.SelectMode = "DATA"
                            tblData = objBCDBS.ConvertTable(objDT.CopyNumberRetrieve)
                            strErrorMsg = objDT.ErrorMsg
                            intErrorCode = objDT.ErrorCode
                            ' Title
                            objDT.SelectMode = "TITLE"
                            tblTitle = objBCDBS.ConvertTable(objDT.CopyNumberRetrieve)
                            strErrorMsg = objDT.ErrorMsg
                            intErrorCode = objDT.ErrorCode
                            ' Author
                            objDT.SelectMode = "AUTHOR"
                            tblAuthor = objBCDBS.ConvertTable(objDT.CopyNumberRetrieve)
                            strErrorMsg = objDT.ErrorMsg
                            intErrorCode = objDT.ErrorCode
                            ' Publisher
                            objDT.SelectMode = "PUBLISHER"
                            tblPublisher = objBCDBS.ConvertTable(objDT.CopyNumberRetrieve)
                            strErrorMsg = objDT.ErrorMsg
                            intErrorCode = objDT.ErrorCode

                            objDT.SelectMode = "DDC"
                            tblDDC = objBCDBS.ConvertTable(objDT.CopyNumberRetrieve)
                            strErrorMsg = objDT.ErrorMsg
                            intErrorCode = objDT.ErrorCode

                            objDT.SelectMode = "ISBN"
                            tblISBN = objBCDBS.ConvertTable(objDT.CopyNumberRetrieve)
                            strErrorMsg = objDT.ErrorMsg
                            intErrorCode = objDT.ErrorCode

                            objDT.SelectMode = "SOHD"
                            tblSOHD = objBCDBS.ConvertTable(objDT.CopyNumberRetrieve)
                            strErrorMsg = objDT.ErrorMsg
                            intErrorCode = objDT.ErrorCode

                            arrIDs = Split(strIDs, ",")
                            For inti = LBound(arrIDs) To UBound(arrIDs)
                                Try
                                    dtrowDatas = tblData.Select("ID=" & arrIDs(inti))
                                    dtrowTitles = tblTitle.Select("ID=" & arrIDs(inti))
                                    dtrowAuthors = tblAuthor.Select("ID=" & arrIDs(inti))
                                    dtrowPublishers = tblPublisher.Select("ID=" & arrIDs(inti))
                                    dtrowISBNs = tblISBN.Select("ID=" & arrIDs(inti))
                                    dtrowDDCs = tblDDC.Select("ID=" & arrIDs(inti))
                                    dtrowSOHDs = tblSOHD.Select("ID=" & arrIDs(inti))
                                    If dtrowDatas.Length > 0 Then
                                        ' Split Published Place and Published Year
                                        strPublisher = ""
                                        strPubYear = ""
                                        If dtrowPublishers.Length > 0 Then
                                            For Each dtrowPublisher In dtrowPublishers
                                                objBCSP.ParseField("$a,$c", dtrowPublisher.Item("Content"), "", subVal)
                                                If Not subVal(0) = "" Then
                                                    strPublisher = DeleteChars(subVal(0))
                                                End If
                                                If Not subVal(1) = "" Then
                                                    strPubYear = DeleteChars(subVal(1))
                                                End If
                                            Next
                                        End If

                                        ' Get author
                                        strAuthor = ""
                                        If dtrowAuthors.Length > 0 Then
                                            For Each dtrowAuthor In dtrowAuthors
                                                objBCSP.ParseField("$a", dtrowAuthor.Item("Content").ToString(), "", subVal)
                                                If Not subVal(0) = "" Then
                                                    strAuthor = DeleteChars(Trim(subVal(0)))
                                                End If
                                            Next
                                        End If

                                        ' Get ISBN
                                        strISBN = ""
                                        If dtrowISBNs.Length > 0 Then
                                            For Each dtrowISBN In dtrowISBNs
                                                objBCSP.ParseField("$a", dtrowISBN.Item("Content").ToString(), "", subVal)
                                                If Not subVal(0) = "" Then
                                                    strISBN = DeleteChars(Trim(subVal(0)))
                                                End If
                                            Next
                                        End If

                                        ' Get DDC
                                        strDDC = ""
                                        For Each dtrowDDC In dtrowDDCs
                                            strDDC = If(dtrowDDC.Item("Content").ToString().Split(New Char() {"."c}).FirstOrDefault(), "")
                                        Next

                                        ' Get SOHD
                                        strSOHD = ""
                                        For Each dtrowSOHD In dtrowSOHDs
                                            strSOHD = dtrowSOHD.Item("SOHD").ToString()
                                        Next

                                        ' Get title
                                        strTitle = ""
                                        If dtrowTitles.Length > 0 Then
                                            For Each dtrowTitle In dtrowTitles
                                                strTitle = objBCSP.TrimSubFieldCodesTitle(dtrowTitle.Item("Content"))
                                                If InStr(strTitle, "/") > 0 Then
                                                    strTitle = Left(strTitle, InStr(strTitle, "/") - 1)
                                                End If
                                            Next
                                        End If

                                        strPrice = ""
                                        strCopyNumber = ""
                                        strAquisitionDate = ""
                                        For Each dtrowData In dtrowDatas
                                            strPrice = dtrowData.Item("Price")
                                            If strPrice <> "" Then
                                                Dim arrPrice() As String = strPrice.Split(New Char() {","})
                                                If arrPrice.Length = 2 Then
                                                    Try
                                                        Dim integ As Integer = CInt(arrPrice(1).Trim())
                                                        If integ > 0 Then
                                                            strPrice = arrPrice(0) & "," & integ.ToString()
                                                        Else
                                                            strPrice = arrPrice(0)
                                                        End If
                                                    Catch ex As Exception
                                                        strPrice = arrPrice(0)
                                                    End Try
                                                Else
                                                    strPrice = arrPrice(0)
                                                End If
                                            End If
                                                strCopyNumber = dtrowData.Item("CopyNumber")
                                            If IsDBNull(dtrowData.Item("ACQUIREDDATE")) Then
                                                strAquisitionDate = ""
                                            Else
                                                strAquisitionDate = CStr(dtrowData.Item("ACQUIREDDATE"))
                                            End If
                                        Next
                                        ' Sequency
                                        lngStartID += 1
                                        If inti Mod 2 = 0 Then 'Event Color
                                            strChangeRowColor = strEventColor
                                        Else 'Odd color
                                            strChangeRowColor = strOddColor
                                        End If
                                        strOutMsg &= "<TR BGCOLOR=" & strChangeRowColor & ">"
                                        For intj = 0 To UBound(bCols)
                                            ' Collum width
                                            strmw = ""
                                            If UBound(bUserColWidths) >= intj Then
                                                If Not Trim(bUserColWidths(intj)) = "" Then
                                                    strmw = " WIDTH=""" & Trim(bUserColWidths(intj)) & """"
                                                End If
                                            End If
                                            ' Collum align
                                            strma = " ALIGN=LEFT "
                                            If UBound(bUserColAligns) >= intj Then 'Alias (can le) cho cot
                                                If Not Trim(bUserColAligns(intj)) = "" Then
                                                    strma = " ALIGN=""" & Trim(bUserColAligns(intj)) & """"
                                                End If
                                            End If
                                            ' Collum format
                                            strmf = ""
                                            boolmf = False ' Default not have Format
                                            If UBound(bUserColFormats) >= intj Then
                                                If Not Trim(bUserColFormats(intj)) = "" Then
                                                    boolmf = True ' Have Format
                                                End If
                                            End If
                                            Try
                                                Select Case bCols(intj)
                                                    Case "<$SEQUENCY$>"
                                                        If boolmf Then
                                                            strOutMsg = strOutMsg & "<TD VALIGN=TOP " & strmw & strma & ">" & bUserColFormats(intj).Replace("<$DATA$>", CStr(lngStartID)) & "</TD>"
                                                        Else
                                                            strOutMsg = strOutMsg & "<TD VALIGN=TOP " & strmw & strma & ">" & CStr(lngStartID) & "</TD>"
                                                        End If
                                                    Case "<$DKCB$>"
                                                        If boolmf Then
                                                            strOutMsg = strOutMsg & "<TD VALIGN=TOP " & strmw & strma & ">" & bUserColFormats(intj).Replace("<$DATA$>", strCopyNumber) & "</TD>"
                                                        Else
                                                            strOutMsg = strOutMsg & "<TD NOWRAP VALIGN=TOP " & strmw & strma & ">" & strCopyNumber & "&nbsp;</TD>"
                                                        End If
                                                    Case "<$TITLE$>"
                                                        If boolmf Then
                                                            strOutMsg = strOutMsg & "<TD VALIGN=TOP " & strmw & strma & ">" & bUserColFormats(intj).Replace("<$DATA$>", strTitle) & "</TD>"
                                                        Else
                                                            strOutMsg = strOutMsg & "<TD VALIGN=TOP " & strmw & strma & ">" & strTitle & "&nbsp;</TD>"
                                                        End If
                                                    Case "<$PLACE$>"
                                                        If boolmf Then
                                                            strOutMsg = strOutMsg & "<TD VALIGN=TOP " & strmw & strma & ">" & bUserColFormats(intj).Replace("<$DATA$>", strPublisher) & "</TD>"
                                                        Else
                                                            strOutMsg = strOutMsg & "<TD VALIGN=TOP " & strmw & strma & ">" & strPublisher & "&nbsp;</TD>"
                                                        End If
                                                    Case "<$YEAR$>"
                                                        If boolmf Then
                                                            strOutMsg = strOutMsg & "<TD VALIGN=TOP " & strmw & strma & ">" & bUserColFormats(intj).Replace("<$DATA$>", strPubYear) & "</TD>"
                                                        Else
                                                            strOutMsg = strOutMsg & "<TD VALIGN=TOP " & strmw & strma & ">" & strPubYear & "&nbsp;</TD>"
                                                        End If
                                                    Case "<$ISSUEPRICE$>"
                                                        If boolmf Then
                                                            strOutMsg = strOutMsg & "<TD VALIGN=TOP " & strmw & strma & ">" & bUserColFormats(intj).Replace("<$DATA$>", strPrice) & "</TD>"
                                                        Else
                                                            strOutMsg = strOutMsg & "<TD VALIGN=TOP " & strmw & strma & ">" & strPrice & "&nbsp;</TD>"
                                                        End If
                                                    Case "<$ACQUISITIONDATE$>"
                                                        If boolmf Then
                                                            strOutMsg = strOutMsg & "<TD VALIGN=TOP " & strmw & strma & ">" & bUserColFormats(intj).Replace("<$DATA$>", strAquisitionDate) & "</TD>"
                                                        Else
                                                            strOutMsg = strOutMsg & "<TD VALIGN=TOP " & strmw & strma & ">" & strAquisitionDate & "&nbsp;</TD>"
                                                        End If
                                                    Case "<$NOTE$>"
                                                        If boolmf Then
                                                            strOutMsg = strOutMsg & "<TD VALIGN=TOP " & strmw & strma & ">" & bUserColFormats(intj).Replace("<$DATA$>", strNote) & "</TD>"
                                                        Else
                                                            strOutMsg = strOutMsg & "<TD VALIGN=TOP " & strmw & strma & ">" & strNote & "&nbsp;</TD>"
                                                        End If
                                                    Case "<$ISBN$>"
                                                        If boolmf Then
                                                            strOutMsg = strOutMsg & "<TD VALIGN=TOP " & strmw & strma & ">" & bUserColFormats(intj).Replace("<$DATA$>", strISBN) & "</TD>"
                                                        Else
                                                            strOutMsg = strOutMsg & "<TD VALIGN=TOP " & strmw & strma & ">" & strISBN & "&nbsp;</TD>"
                                                        End If
                                                    Case "<$SOHD$>"
                                                        If boolmf Then
                                                            strOutMsg = strOutMsg & "<TD VALIGN=TOP " & strmw & strma & ">" & bUserColFormats(intj).Replace("<$DATA$>", strSOHD) & "</TD>"
                                                        Else
                                                            strOutMsg = strOutMsg & "<TD VALIGN=TOP " & strmw & strma & ">" & strSOHD & "&nbsp;</TD>"
                                                        End If
                                                    Case "<$AUTHOR$>"
                                                        If boolmf Then
                                                            strOutMsg = strOutMsg & "<TD VALIGN=TOP " & strmw & strma & ">" & bUserColFormats(intj).Replace("<$DATA$>", strAuthor) & "</TD>"
                                                        Else
                                                            strOutMsg = strOutMsg & "<TD VALIGN=TOP " & strmw & strma & ">" & strAuthor & "&nbsp;</TD>"
                                                        End If
                                                    Case "<$DDC$>"
                                                        If boolmf Then
                                                            strOutMsg = strOutMsg & "<TD VALIGN=TOP " & strmw & strma & ">" & bUserColFormats(intj).Replace("<$DATA$>", strDDC) & "</TD>"
                                                        Else
                                                            strOutMsg = strOutMsg & "<TD VALIGN=TOP " & strmw & strma & ">" & strDDC & "&nbsp;</TD>"
                                                        End If
                                                End Select
                                            Catch ex As Exception
                                                strOutMsg = strOutMsg & "<TD VALIGN=TOP " & strmw & strma & ">&nbsp;</TD>"
                                                strErrorMsg = ex.Message
                                            End Try
                                        Next
                                        strOutMsg = strOutMsg & "</TR>"
                                    End If
                                Catch ex As Exception
                                    strErrorMsg = ex.Message
                                End Try
                            Next
                            strOutMsg = strOutMsg & "</TABLE></TD></TR></TABLE>"
                        End If
                    Else
                        strOutMsg = ""
                    End If
                Else
                    strOutMsg = ""
                End If
                GenACQReport = strOutMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                'If Not objLBTemplate Is Nothing Then
                '    objLBTemplate = Nothing
                'End If
            End Try
        End Function
        ' Purpose: Gen AcqReport without data get from database
        ' In: Some infora
        ' Out: string
        ' Creator:  Sondp
        Public Function GenACQReportAll(ByVal intTemplateID As Integer, ByVal lngStartID As Long, ByVal lngStopID As Long, ByVal strIDs As String, ByVal collAcq As Collection) As StringBuilder
            'Dim objLBTemplate As New TVCOMLib.LibolTemplate
            Try
                If intTemplateID = 0 Then
                    GenACQReportAll = Nothing
                    Exit Function
                End If
                Dim tblTemplate As New DataTable
                Dim tblData, tblAuthor, tblTitle, tblPublisher As DataTable
                Dim dtrowDatas(), dtrowAuthors(), dtrowTitles(), dtrowPublishers(), dtrowData, dtrowAuthor, dtrowTitle, dtrowPublisher As DataRow
                Dim arrIDs() As String
                Dim subVal() As Object
                Dim strHeader, strCollums, strCollumCaptions, strCollumWidths, strCollumAligns, strCollumFormats, strTableColor, strOddColor, strEventColor, strFooter, strma, strmw, strmf, strChangeRowColor, strItem, strTitle, strPublisher, strPrice, strAquisitionDate, strSequency, strCopyNumber, strNote, strPubYear, strAuthor As String
                Dim bCols(), bColLabels(), bUserColLabels(), bUserColWidths(), bUserColAligns(), bUserColFormats() As String
                Dim objFields As New Object
                Dim objData As New Object
                Dim objStream As New Object
                Dim inti, intj, intk As Integer
                Dim boolmf As Boolean
                Dim strOutMsg As New StringBuilder()
                TemplateID = intTemplateID
                TemplateType = 11
                tblTemplate = GetTemplate()
                If Not tblTemplate Is Nothing Then
                    If tblTemplate.Rows.Count > 0 Then
                        arrIDs = Split(tblTemplate.Rows(0).Item("Content"), Chr(9))
                        If UBound(arrIDs) > 0 Then
                            strHeader = objBCSP.ToUTF8(arrIDs(0))
                            strPageHeader = arrIDs(1)
                            strCollums = arrIDs(2)
                            strCollumCaptions = arrIDs(3)
                            strCollumWidths = arrIDs(4)
                            strCollumAligns = arrIDs(5)
                            strCollumFormats = arrIDs(6)
                            ' Table color
                            If Not arrIDs(7) & "" = "" Then
                                strTableColor = arrIDs(7)
                            Else
                                strTableColor = "#DDDDDD"
                            End If
                            ' Event color
                            If Not arrIDs(8) & "" = "" Then
                                strEventColor = arrIDs(8)
                            Else
                                strEventColor = "#FFFFFF"
                            End If
                            ' Odd color
                            If Not arrIDs(9) & "" = "" Then
                                strOddColor = arrIDs(9)
                            Else
                                strOddColor = "#F0F3F4"
                            End If
                            'tulnn edit 27/8
                            'strPageFooter = arrIDs(10)
                            strPageFooter = "<div align='left' style='width:100%'>" & objBCSP.ToUTF8(arrIDs(11)) & "</div><div align='right' style='width:100%'>" & arrIDs(10) & "</div>"
                            'end edit
                            strFooter = objBCSP.ToUTF8(arrIDs(11))
                            ' Process for Header and Footer
                            'objLBTemplate.Template = strHeader.Replace("<~>", "") & "@@@@@" & strFooter.Replace("<~>", "")
                            'objFields = objLBTemplate.Fields
                            Dim strContentTemp As String = strHeader.Replace("<~>", "") & "@@@@@" & strFooter.Replace("<~>", "")
                            objFields = objBCT.getArrayFromTemplate(strContentTemp)

                            If Not IsNothing(objFields) AndAlso IsArray(objFields) Then
                                ReDim objData(UBound(objFields))
                                For inti = LBound(objFields) To UBound(objFields)
                                    Select Case Len(UCase(objFields(inti)))
                                        Case Is > 0
                                            strItem = "" & "" & UCase(objFields(inti)) & "" & ""
                                            objData(inti) = collAcq.Item(strItem)
                                            strContentTemp = Replace(strContentTemp, "<$" & objFields(inti) & "$>", objData(inti))
                                        Case Else
                                            objData(inti) = ""
                                    End Select
                                Next
                            End If

                            'objStream = objLBTemplate.Generate(objData)
                            objStream = strContentTemp
                            strHeader = objBCSP.ToUTF8Back(Left(objStream, InStr(objStream, "@@@@@") - 1))
                            strFooter = objBCSP.ToUTF8Back(Right(objStream, Len(objStream) - InStr(objStream, "@@@@@") - 4))
                            'strOutMsg.Append(strHeader)
                            ' Process for collums title
                            bCols = Split(strCollums, "<~>")
                            bUserColLabels = Split(strCollumCaptions, "<~>")
                            bUserColWidths = Split(strCollumWidths, "<~>")
                            bUserColAligns = Split(strCollumAligns, "<~>")
                            bUserColFormats = Split(strCollumFormat, "<~>")
                            intk = 0
                            ' Ga'n ca'c tie^u dde^` tu+o+ng u+'ng cho ca'c co^.t    
                            For inti = LBound(bCols) To UBound(bCols)
                                Try
                                    ReDim Preserve bColLabels(intk)
                                    strItem = "" & "" & bCols(inti) & "" & ""
                                    If UBound(bUserColLabels) >= inti Then
                                        If Not Trim(bUserColLabels(inti)) = "" Then
                                            bColLabels(intk) = bUserColLabels(inti)
                                        Else
                                            bColLabels(intk) = collAcq.Item(strItem)
                                        End If
                                    Else
                                        bColLabels(intk) = collAcq.Item(strItem)
                                    End If
                                Catch ex As Exception
                                    bColLabels(intk) = ""
                                Finally
                                    intk = intk + 1
                                End Try
                            Next
                            strOutMsg.Append("<TABLE WIDTH=100% BGCOLOR=000000><TR><TD WIDTH=100% BGCOLOR=000000>")
                            strOutMsg.Append("<TABLE WIDTH=100% CELLSPACING=1 CELLPADDING=1 BORDER=1>")
                            strOutMsg.Append("<TR BGCOLOR=")
                            strOutMsg.Append(strTableColor)
                            strOutMsg.Append(">")
                            For inti = LBound(bColLabels) To UBound(bColLabels)
                                ' Collum width
                                strmw = ""
                                If UBound(bUserColWidths) >= inti Then
                                    If Not Trim(bUserColWidths(inti)) = "" Then
                                        strmw = " WIDTH=""" & Trim(bUserColWidths(inti)) & """"
                                    End If
                                End If
                                ' Collum align
                                strma = " ALIGN=CENTER "
                                If UBound(bUserColAligns) >= inti Then
                                    If Not Trim(bUserColAligns(inti)) = "" Then
                                        strma = " ALIGN=""" & Trim(bUserColAligns(inti)) & """"
                                    End If
                                End If
                                ' Collum format
                                strmf = ""
                                If UBound(bUserColFormats) >= inti Then
                                    If Not Trim(bUserColFormats(inti)) = "" Then
                                        strmf = bUserColFormats(inti).Replace("<$DATA$>", bColLabels(inti))
                                    End If
                                End If
                                If strmf <> "" Then
                                    strOutMsg.Append("<TH VALIGN=TOP" & strmw & strma & ">" & strmf & "</TH>")
                                Else
                                    strOutMsg.Append("<TH VALIGN=TOP" & strmw & strma & ">" & bColLabels(inti) & "</TH>")
                                End If
                            Next
                            strOutMsg.Append("</TR>")
                            ' Get data
                            objDT.IDs = strIDs
                            objDT.SelectMode = "DATA"
                            tblData = objBCDBS.ConvertTable(objDT.CopyNumberRetrieve)
                            strErrorMsg = objDT.ErrorMsg
                            intErrorCode = objDT.ErrorCode
                            ' Title
                            objDT.SelectMode = "TITLE"
                            tblTitle = objBCDBS.ConvertTable(objDT.CopyNumberRetrieve)
                            strErrorMsg = objDT.ErrorMsg
                            intErrorCode = objDT.ErrorCode
                            ' Author
                            objDT.SelectMode = "AUTHOR"
                            tblAuthor = objBCDBS.ConvertTable(objDT.CopyNumberRetrieve)
                            strErrorMsg = objDT.ErrorMsg
                            intErrorCode = objDT.ErrorCode
                            ' Publisher
                            objDT.SelectMode = "PUBLISHER"
                            tblPublisher = objBCDBS.ConvertTable(objDT.CopyNumberRetrieve)
                            strErrorMsg = objDT.ErrorMsg
                            intErrorCode = objDT.ErrorCode
                            arrIDs = Split(strIDs, ",")
                            For inti = LBound(arrIDs) To UBound(arrIDs)
                                Try
                                    dtrowDatas = tblData.Select("ID=" & arrIDs(inti))
                                    dtrowTitles = tblTitle.Select("ID=" & arrIDs(inti))
                                    dtrowAuthors = tblAuthor.Select("ID=" & arrIDs(inti))
                                    dtrowPublishers = tblPublisher.Select("ID=" & arrIDs(inti))
                                    If dtrowDatas.Length > 0 Then
                                        ' Split Published Place and Published Year
                                        strPublisher = ""
                                        strPubYear = ""
                                        If dtrowPublishers.Length > 0 Then
                                            For Each dtrowPublisher In dtrowPublishers
                                                objBCSP.ParseField("$a,$c", dtrowPublisher.Item("Content"), "", subVal)
                                                If Not subVal(0) = "" Then
                                                    strPublisher = DeleteChars(subVal(0))
                                                End If
                                                If Not subVal(1) = "" Then
                                                    strPubYear = subVal(1)
                                                End If
                                            Next
                                        End If
                                        ' Get author
                                        strAuthor = ""
                                        If dtrowAuthors.Length > 0 Then
                                            For Each dtrowAuthor In dtrowAuthors
                                                objBCSP.ParseField("$a", dtrowAuthor.Item("Content"), "", subVal)
                                                If Not subVal(0) = "" Then
                                                    strAuthor = Trim(subVal(0))
                                                End If
                                            Next
                                        End If
                                        ' Get title
                                        strTitle = ""
                                        If dtrowTitles.Length > 0 Then
                                            For Each dtrowTitle In dtrowTitles
                                                strTitle = objBCSP.TrimSubFieldCodesTitle(dtrowTitle.Item("Content"))
                                                If InStr(strTitle, "/") > 0 Then
                                                    strTitle = Left(strTitle, InStr(strTitle, "/") - 1)
                                                End If
                                            Next
                                        End If
                                        If Not strAuthor = "" Then
                                            strTitle = "<B>" & strAuthor & "</B>" & "." & strTitle
                                        End If
                                        ' Get copynumber, price, acquisitiondata
                                        strPrice = ""
                                        strCopyNumber = ""
                                        strAquisitionDate = ""
                                        For Each dtrowData In dtrowDatas
                                            strPrice = dtrowData.Item("Price")
                                            strCopyNumber = dtrowData.Item("CopyNumber")
                                            If IsDBNull(dtrowData.Item("ACQUIREDDATE")) Then
                                                strAquisitionDate = ""
                                            Else
                                                strAquisitionDate = CStr(dtrowData.Item("ACQUIREDDATE"))
                                            End If
                                        Next
                                        ' Sequency
                                        lngStartID += 1
                                        If inti Mod 2 = 0 Then 'Event Color
                                            strChangeRowColor = strEventColor
                                        Else 'Odd color
                                            strChangeRowColor = strOddColor
                                        End If
                                        strOutMsg.Append("<TR BGCOLOR=" & strChangeRowColor & ">")
                                        For intj = 0 To UBound(bCols)
                                            ' Collum width
                                            strmw = ""
                                            If UBound(bUserColWidths) >= intj Then
                                                If Not Trim(bUserColWidths(intj)) = "" Then
                                                    strmw = " WIDTH=""" & Trim(bUserColWidths(intj)) & """"
                                                End If
                                            End If
                                            ' Collum align
                                            strma = " ALIGN=LEFT "
                                            If UBound(bUserColAligns) >= intj Then 'Alias (can le) cho cot
                                                If Not Trim(bUserColAligns(intj)) = "" Then
                                                    strma = " ALIGN=""" & Trim(bUserColAligns(intj)) & """"
                                                End If
                                            End If
                                            ' Collum format
                                            strmf = ""
                                            boolmf = False ' Default not have Format
                                            If UBound(bUserColFormats) >= intj Then
                                                If Not Trim(bUserColFormats(intj)) = "" Then
                                                    boolmf = True ' Have Format
                                                End If
                                            End If
                                            Try
                                                Select Case bCols(intj)
                                                    Case "<$SEQUENCY$>"
                                                        If boolmf Then
                                                            strOutMsg.Append("<TD VALIGN=TOP ")
                                                            strOutMsg.Append(strmw)
                                                            strOutMsg.Append(strma)
                                                            strOutMsg.Append(">")
                                                            strOutMsg.Append(bUserColFormats(intj).Replace("<$DATA$>", CStr(lngStartID)))
                                                            strOutMsg.Append("</TD>")
                                                        Else
                                                            strOutMsg.Append("<TD VALIGN=TOP ")
                                                            strOutMsg.Append(strmw)
                                                            strOutMsg.Append(strma)
                                                            strOutMsg.Append(">")
                                                            strOutMsg.Append(CStr(lngStartID))
                                                            strOutMsg.Append("</TD>")
                                                        End If
                                                    Case "<$DKCB$>"
                                                        If boolmf Then
                                                            strOutMsg.Append("<TD VALIGN=TOP ")
                                                            strOutMsg.Append(strmw)
                                                            strOutMsg.Append(strma)
                                                            strOutMsg.Append(">")
                                                            strOutMsg.Append(bUserColFormats(intj).Replace("<$DATA$>", strCopyNumber))
                                                            strOutMsg.Append("</TD>")
                                                        Else
                                                            strOutMsg.Append("<TD NOWRAP VALIGN=TOP ")
                                                            strOutMsg.Append(strmw)
                                                            strOutMsg.Append(strma)
                                                            strOutMsg.Append(">")
                                                            strOutMsg.Append(strCopyNumber)
                                                            strOutMsg.Append("&nbsp;</TD>")
                                                        End If
                                                    Case "<$TITLE$>"
                                                        If boolmf Then
                                                            strOutMsg.Append("<TD VALIGN=TOP ")
                                                            strOutMsg.Append(strmw)
                                                            strOutMsg.Append(strma)
                                                            strOutMsg.Append(">")
                                                            strOutMsg.Append(bUserColFormats(intj).Replace("<$DATA$>", strTitle))
                                                            strOutMsg.Append("</TD>")
                                                        Else
                                                            strOutMsg.Append("<TD VALIGN=TOP ")
                                                            strOutMsg.Append(strmw)
                                                            strOutMsg.Append(strma)
                                                            strOutMsg.Append(">")
                                                            strOutMsg.Append(strTitle)
                                                            strOutMsg.Append("&nbsp;</TD>")
                                                        End If
                                                    Case "<$PLACE$>"
                                                        If boolmf Then
                                                            strOutMsg.Append("<TD VALIGN=TOP ")
                                                            strOutMsg.Append(strmw)
                                                            strOutMsg.Append(strma)
                                                            strOutMsg.Append(">")
                                                            strOutMsg.Append(bUserColFormats(intj).Replace("<$DATA$>", strPublisher))
                                                            strOutMsg.Append("</TD>")
                                                        Else
                                                            strOutMsg.Append("<TD VALIGN=TOP ")
                                                            strOutMsg.Append(strmw)
                                                            strOutMsg.Append(strma)
                                                            strOutMsg.Append(">")
                                                            strOutMsg.Append(strPublisher)
                                                            strOutMsg.Append("&nbsp;</TD>")
                                                        End If
                                                    Case "<$YEAR$>"
                                                        If boolmf Then
                                                            strOutMsg.Append("<TD VALIGN=TOP ")
                                                            strOutMsg.Append(strmw)
                                                            strOutMsg.Append(strma)
                                                            strOutMsg.Append(">")
                                                            strOutMsg.Append(bUserColFormats(intj).Replace("<$DATA$>", strPubYear))
                                                            strOutMsg.Append("</TD>")
                                                        Else
                                                            strOutMsg.Append("<TD VALIGN=TOP ")
                                                            strOutMsg.Append(strmw)
                                                            strOutMsg.Append(strma)
                                                            strOutMsg.Append(">")
                                                            strOutMsg.Append(strPubYear)
                                                            strOutMsg.Append("&nbsp;</TD>")
                                                        End If
                                                    Case "<$ISSUEPRICE$>"
                                                        If boolmf Then
                                                            strOutMsg.Append("<TD VALIGN=TOP ")
                                                            strOutMsg.Append(strmw)
                                                            strOutMsg.Append(strma)
                                                            strOutMsg.Append(">")
                                                            strOutMsg.Append(bUserColFormats(intj).Replace("<$DATA$>", strPrice))
                                                            strOutMsg.Append("</TD>")
                                                        Else
                                                            strOutMsg.Append("<TD VALIGN=TOP ")
                                                            strOutMsg.Append(strmw)
                                                            strOutMsg.Append(strma)
                                                            strOutMsg.Append(">")
                                                            strOutMsg.Append(strPrice)
                                                            strOutMsg.Append("&nbsp;</TD>")
                                                        End If
                                                    Case "<$ACQUISITIONDATE$>"
                                                        If boolmf Then
                                                            strOutMsg.Append("<TD VALIGN=TOP ")
                                                            strOutMsg.Append(strmw)
                                                            strOutMsg.Append(strma)
                                                            strOutMsg.Append(">")
                                                            strOutMsg.Append(bUserColFormats(intj).Replace("<$DATA$>", strAquisitionDate))
                                                            strOutMsg.Append("</TD>")
                                                        Else
                                                            strOutMsg.Append("<TD VALIGN=TOP ")
                                                            strOutMsg.Append(strmw)
                                                            strOutMsg.Append(strma)
                                                            strOutMsg.Append(">")
                                                            strOutMsg.Append(strAquisitionDate)
                                                            strOutMsg.Append("&nbsp;</TD>")
                                                        End If
                                                    Case "<$NOTE$>"
                                                        If boolmf Then
                                                            strOutMsg.Append("<TD VALIGN=TOP ")
                                                            strOutMsg.Append(strmw)
                                                            strOutMsg.Append(strma)
                                                            strOutMsg.Append(">")
                                                            strOutMsg.Append(bUserColFormats(intj).Replace("<$DATA$>", strNote))
                                                            strOutMsg.Append("</TD>")
                                                        Else
                                                            strOutMsg.Append("<TD VALIGN=TOP ")
                                                            strOutMsg.Append(strmw)
                                                            strOutMsg.Append(strma)
                                                            strOutMsg.Append(">")
                                                            strOutMsg.Append(strNote)
                                                            strOutMsg.Append("&nbsp;</TD>")
                                                        End If
                                                End Select
                                            Catch ex As Exception
                                                strOutMsg.Append("<TD VALIGN=TOP ")
                                                strOutMsg.Append(strmw)
                                                strOutMsg.Append(strma)
                                                strOutMsg.Append(">&nbsp;</TD>")
                                                strErrorMsg = ex.Message
                                            End Try
                                        Next
                                        strOutMsg.Append("</TR>")
                                    End If
                                Catch ex As Exception
                                    strErrorMsg = ex.Message
                                End Try
                            Next
                            strOutMsg.Append("</TABLE></TD></TR></TABLE>")
                        End If
                    Else
                        strOutMsg.Append("")
                    End If
                Else
                    strOutMsg.Append("")
                End If
                GenACQReportAll = strOutMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                'If Not objLBTemplate Is Nothing Then
                '    objLBTemplate = Nothing
                'End If
            End Try
        End Function
        ' Purpose: Gen AcqReport without data get from database
        Public Function GenACQReport() As String
            'Dim objTemplate As New TVCOMLib.LibolTemplate
            'Dim objSort As New TVCOMLib.utf8
            'Dim objTvCom As New TVCOMLib.fonts
            Dim objFields As New Object
            Dim objStream As Object
            Dim objData As Object
            Dim bColLabel(), bUserColLabel(), bUserColWidth(), bUserColAlign(), bUserColFormat(), bCols() As String
            Dim intk, inti, intj As Integer
            Dim strmw, strma, strmf, strOutMsg As String
            Dim boolmf As Boolean = False
            Dim strChangeRowColor As String = "#FFFFFF" ' Use this string to change rows color
            intk = 0
            ReDim objData(0)
            Try
                ' Get Table color
                If strTableColor & "" = "" Then
                    strTableColor = "#FFFFFF" ' Default white
                End If
                ' Get Odd color
                If strOddColor & "" = "" Then
                    strOddColor = "#FFFFFF" ' Default white
                End If
                ' Get Event color
                If strEventColor & "" = "" Then
                    strEventColor = "#FFFFFF" ' Default white
                End If
                bUserColLabel = Split(strCollumCaption, vbCrLf)
                bUserColWidth = Split(strCollumWidth, vbCrLf)
                bUserColAlign = Split(strCollumAlign, vbCrLf)
                bUserColFormat = Split(strCollumFormat, vbCrLf)
                bCols = Split(strCollum, "<~>")
                'objTemplate.Template = objBCSP.ToUTF8(strHeader) & "@@@@@" & objBCSP.ToUTF8(strFooter)
                'objFields = objTemplate.Fields
                For inti = LBound(bCols) To UBound(bCols)
                    ' Set Collum title for suite collum                    
                    ReDim Preserve bColLabel(intk)
                    Try
                        If UBound(bUserColLabel) >= inti Then
                            If Not Trim(bUserColLabel(inti)) = "" Then
                                bColLabel(intk) = bUserColLabel(inti) & Chr(9)
                            Else
                                bColLabel(intk) = CollumsTitle.Item(bCols(inti)) & Chr(9)
                            End If
                        Else
                            bColLabel(intk) = CollumsTitle.Item(bCols(inti)) & Chr(9)
                        End If
                    Catch ex As Exception
                        bColLabel(intk) = "" & Chr(9)
                        strErrorMsg = ex.Message
                    Finally
                        intk = intk + 1
                    End Try
                Next
                ' Header and Footer
                Dim strContentTemp As String = strHeader & "@@@@@" & strFooter
                objFields = objBCT.getArrayFromTemplate(strContentTemp)
                If Not IsNothing(objFields) AndAlso IsArray(objFields) Then
                    ReDim objData(UBound(objFields))
                    'ReDim objData(UBound(objTemplate.Fields))
                    For inti = LBound(objFields) To UBound(objFields)
                        Try
                            objData(inti) = collHeaderFooter.Item(UCase(objFields(inti))) '& Chr(9)
                            strContentTemp = Replace(strContentTemp, "<$" & objFields(inti) & "$>", objData(inti))
                        Catch ex As Exception
                            objData(inti) = "" & Chr(9)
                            strErrorMsg = ex.Message
                        End Try
                    Next
                End If

                'objStream = objTemplate.Generate(objData)
                objStream = strContentTemp

                objStream = Replace(objStream, "  ", "&nbsp;&nbsp;")
                strHeader = objBCSP.ToUTF8Back(Left(objStream, InStr(objStream, "@@@@@") - 1))
                strFooter = objBCSP.ToUTF8Back(Right(objStream, Len(objStream) - InStr(objStream, "@@@@@") - 4))
                ' Table color
                strOutMsg = strHeader
                strOutMsg = strOutMsg & "<TABLE WIDTH=100% BORDER=0 CELLSPACING=1  CELLPADDING=1 BGCOLOR=""#000000"">"
                strOutMsg = strOutMsg & "<TR BGCOLOR=""" & strTableColor & """ >"
                ' Table Title
                For intj = LBound(bColLabel) To UBound(bColLabel)
                    strmw = ""
                    ' Collum Width
                    If UBound(bUserColWidth) >= intj Then
                        If Not Trim(bUserColWidth(intj)) = "" Then
                            strmw = " WIDTH=""" & Trim(bUserColWidth(intj)) & """"
                        End If
                    End If
                    strma = " ALIGN=center "
                    ' Collum Align
                    If UBound(bUserColAlign) >= intj Then
                        If Not Trim(bUserColAlign(intj)) = "" Then
                            strma = " ALIGN=""" & Trim(bUserColAlign(intj)) & """"
                        End If
                    End If
                    strmf = ""
                    ' Collum Format
                    If UBound(bUserColFormat) >= intj Then
                        If Not Trim(bUserColFormat(intj)) = "" Then
                            strmf = bUserColFormat(intj).Replace("<$DATA$>", bColLabel(intj))
                        End If
                    End If
                    If strmf <> "" Then
                        strOutMsg = strOutMsg & "<TH VALIGN=TOP BGCOLOR=" & strTableColor & "  " & strmw & strma & ">" & strmf & "</TH>"
                    Else
                        strOutMsg = strOutMsg & "<TH VALIGN=TOP BGCOLOR=" & strTableColor & "  " & strmw & strma & ">" & bColLabel(intj) & "</TH>"
                    End If
                Next
                strOutMsg = strOutMsg & "</TR>"
                ' Default display 5 rows
                For intj = 1 To 5
                    If intj Mod 2 = 0 Then ' Change color
                        strChangeRowColor = strEventColor
                    Else
                        strChangeRowColor = strOddColor
                    End If
                    strOutMsg = strOutMsg & "<TR BGCOLOR=" & strChangeRowColor & ">"
                    For inti = 0 To UBound(bCols)
                        ' Width
                        strmw = ""
                        If UBound(bUserColWidth) >= inti Then
                            If Not Trim(bUserColWidth(inti)) = "" Then
                                strmw = " WIDTH=""" & Trim(bUserColWidth(inti)) & """"
                            End If
                        End If
                        ' Align 
                        strma = ""
                        If UBound(bUserColAlign) >= inti Then
                            If Not Trim(bUserColAlign(inti)) = "" Then
                                strma = " ALIGN=""" & Trim(bUserColAlign(inti)) & """"
                            End If
                        End If
                        ' Format
                        strmf = ""
                        boolmf = False ' Default not have Format
                        If UBound(bUserColFormat) >= inti Then
                            If Not Trim(bUserColFormat(inti)) = "" Then
                                boolmf = True ' Have Format
                            End If
                        End If
                        Select Case bCols(inti)
                            Case "<$SEQUENCY$>"
                                If boolmf Then
                                    strOutMsg = strOutMsg & "<TD VALIGN=TOP BGCOLOR=" & strChangeRowColor & " " & strmw & strma & ">" & bUserColFormat(inti).Replace("<$DATA$>", intj) & "&nbsp;</TD>"
                                Else
                                    strOutMsg = strOutMsg & "<TD VALIGN=TOP BGCOLOR=" & strChangeRowColor & " " & strmw & strma & ">" & intj & "&nbsp;</TD>"
                                End If
                            Case Else
                                Try
                                    If boolmf Then
                                        strOutMsg = strOutMsg & "<TD VALIGN=TOP BGCOLOR=" & strChangeRowColor & " " & strmw & strma & ">" & bUserColFormat(inti).Replace("<$DATA$>", collCollumsData.Item(bCols(inti))) & "&nbsp;</TD>"
                                    Else
                                        strOutMsg = strOutMsg & "<TD VALIGN=TOP BGCOLOR=" & strChangeRowColor & " " & strmw & strma & ">" & collCollumsData.Item(bCols(inti)) & "&nbsp;</TD>"
                                    End If
                                Catch ex As Exception
                                    strOutMsg = strOutMsg & "<TD VALIGN=TOP BGCOLOR=" & strChangeRowColor & " " & strmw & strma & ">&nbsp;</TD>"
                                End Try
                        End Select
                    Next
                Next
                strOutMsg = strOutMsg & "</TR>"
                strOutMsg = strOutMsg & "</TABLE>"
                strOutMsg = strOutMsg & strFooter
                GenACQReport = strOutMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
                GenACQReport = Nothing
            End Try
        End Function

        ' Purpose: Generate barcode images
        ' In: collecBarCodeChoice, lngStartID, lngStopID, array Holding.ID ( as objIDs )
        ' Out: Array data to gen barcode
        ' Creator:  Sondp
        Public Function GetBarCodeData(ByVal lngStartID As Long, ByVal lngStopID As Long, ByVal collecBarCodeChoice As Collection, ByVal objIDs As Object) As Object
            Dim lngi, lngj, lngMax As Long
            Dim tblData As New DataTable
            Dim strIDs, strASQL, strBarCodeImg, strFields, strTabs, strJoinSQL As String
            Dim ArrValue() As String
            Try
                If lngStartID > UBound(objIDs) Then
                    lngStartID = UBound(objIDs)
                    lngStopID = lngStartID
                End If
                If lngStopID > UBound(objIDs) Then
                    lngStopID = UBound(objIDs)
                End If
                For lngi = lngStartID To lngStopID
                    If lngi > UBound(objIDs) Then
                        Exit For
                    End If
                    strIDs &= objIDs(lngi) & ", "
                Next
                If strIDs.Length > 2 Then
                    strIDs = Left(strIDs, strIDs.Length - 2)
                End If
                If strIDs <> "" Then
                    strJoinSQL = " Lib_tblHolding.ID IN(" & strIDs & ")"
                    strTabs = " Lib_tblHolding"
                    strFields = " Lib_tblHolding.CopyNumber" ' Defalt select CopyNumber
                    If Not collecBarCodeChoice.Item("shelf") & "" = "" Then ' Select shelf 
                        strFields &= ", " & collecBarCodeChoice.Item("shelf")
                    End If
                    If Not collecBarCodeChoice.Item("itemcode") & "" = "" Then ' Select ItemCode
                        strFields &= " , " & collecBarCodeChoice.Item("itemcode")
                        strTabs &= " ,Lib_tblItem"
                        strJoinSQL &= " AND Lib_tblItem.ID=Lib_tblHolding.ItemID"
                    End If
                    strSQL = "SELECT" & strFields & " FROM" & strTabs & " WHERE" & strJoinSQL
                    strSQL = strSQL & "  ORDER BY " & strFields ' order by 
                    objBCDBS.SQLStatement = strSQL
                    tblData = objBCDBS.RetrieveItemInfor
                    strErrorMsg = objBCDBS.ErrorMsg
                    intErrorCode = objBCDBS.ErrorCode
                    If Not tblData Is Nothing Then
                        If tblData.Rows.Count > 0 Then
                            ReDim ArrValue(0)
                            lngMax = 0
                            For lngi = 0 To tblData.Rows.Count - 1
                                If Not collecBarCodeChoice.Item("shelf") & "" = "" Then
                                    ReDim Preserve ArrValue(lngMax)
                                    If Not IsDBNull(tblData.Rows(lngi).Item("Shelf")) Then
                                        ArrValue(lngMax) = tblData.Rows(lngi).Item("Shelf")
                                    Else
                                        ArrValue(lngMax) = ""
                                    End If
                                    lngMax += 1
                                End If
                                If Not collecBarCodeChoice.Item("itemcode") & "" = "" Then
                                    ReDim Preserve ArrValue(lngMax)
                                    If Not IsDBNull(tblData.Rows(lngi).Item("Code")) Then
                                        ArrValue(lngMax) = tblData.Rows(lngi).Item("Code")
                                    Else
                                        ArrValue(lngMax) = ""
                                    End If
                                    lngMax += 1
                                End If
                                If Not collecBarCodeChoice.Item("copynumber") & "" = "" Then
                                    ReDim Preserve ArrValue(lngMax)
                                    If Not IsDBNull(tblData.Rows(lngi).Item("CopyNumber")) Then
                                        ArrValue(lngMax) = tblData.Rows(lngi).Item("CopyNumber")
                                    Else
                                        ArrValue(lngMax) = ""
                                    End If
                                    lngMax += 1
                                End If
                            Next
                            ' All data in array ArrValue and return value
                            If Not ArrValue Is Nothing AndAlso ArrValue.Length > 0 Then
                                GetBarCodeData = ArrValue
                            Else
                                GetBarCodeData = Nothing
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                GetBarCodeData = Nothing
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose: Gen barcode (string) for barcode machine
        ' In: TemplateID, arrData
        ' Out: String
        ' Creator: Sondp
        Public Function GenBarcodeString(ByVal intTemplateID As Integer, ByVal arrData As Object) As String
            'Dim objTemplate As New TVCOMLib.LibolTemplate
            Dim objField As Object
            Dim objStream As Object
            Dim arrReturn() As String
            Dim objData As Object
            Dim inti, intj, intCount As Integer
            Dim tblTemplate As New DataTable
            Dim boolHave As Boolean

            GenBarcodeString = ""
            Me.TemplateID = intTemplateID
            Me.TemplateType = 79
            Me.LibID = intLibID
            tblTemplate = Me.GetTemplate()
            If Not tblTemplate Is Nothing AndAlso tblTemplate.Rows.Count > 0 Then
                'objTemplate.Template = objBCSP.ToUTF8(tblTemplate.Rows(0).Item("Content"))
                'objField = objTemplate.Fields
                Dim strContent As String = tblTemplate.Rows(0).Item("Content")
                objField = objBCT.getArrayFromTemplate(strContent)

                If (Not IsNothing(objField)) AndAlso UBound(objField) >= 0 Then
                    ReDim objData(UBound(objField))
                    Dim strContentTemp As String = ""
                    If UBound(arrData) >= 0 Then
                        intj = 0
                        intCount = 0
                        While intj <= UBound(arrData)
                            strContentTemp = strContent
                            For inti = 0 To UBound(objField)
                                If intj > UBound(arrData) Then
                                    Exit For
                                End If
                                Select Case Len(objField(inti))
                                    Case Is > 0 And Not IsDBNull(arrData(intj))
                                        objData(inti) = arrData(intj) & Chr(9)
                                    Case Else
                                        objData(inti) = "" & Chr(9)
                                End Select
                                strContentTemp = Replace(strContentTemp, "<$" & objField(inti) & "$>", objData(inti))
                                intj = intj + 1
                            Next
                            ReDim Preserve arrReturn(intCount)
                            'arrReturn(intCount) = objBCSP.ToUTF8Back(objTemplate.Generate(objData))
                            arrReturn(intCount) = strContentTemp
                            intCount = intCount + 1
                        End While
                    End If
                Else
                    ReDim Preserve arrReturn(UBound(arrData))
                    If UBound(arrData) >= 0 Then
                        While intj <= UBound(arrData)
                            arrReturn(intj) = strContent & Chr(9)
                            intj = intj + 1
                        End While
                    End If
                End If
                ' Return barcode string
                If UBound(arrReturn) >= 0 Then
                    For inti = 0 To UBound(arrReturn)
                        GenBarcodeString = GenBarcodeString & arrReturn(inti)
                    Next
                End If
            End If
            'objTemplate = Nothing
        End Function

        ' Purpose: Print Acquistion Label Report
        ' In:  Some infor
        ' Out:  string
        ' Creator:  Sondp
        Public Function PrintAcqLabel(ByVal objIDs As Object, ByVal objItemIDs As Object, ByVal intTemplateID As Integer, ByVal intLibID As Integer, ByVal intLocID As Integer, ByVal intHagPage As Integer, ByVal intColPage As Integer, ByVal lngStartID As Long, ByVal lngStopID As Long, ByVal lngUbound As Long) As String
            Dim tblTemplate As New DataTable
            Dim strContent As String
            Dim strIDs As String
            Dim strItemIDs As String
            Dim Fields As Object
            'Dim objTemplate As New TVCOMLib.LibolTemplate
            Dim Tabs As String
            Dim Tab25 As Integer = 0
            Dim Status As Integer
            Dim intt As Integer
            Dim unionsql As String
            Dim mxg As Integer = 0
            Dim c_j As Integer
            Dim exclTags As String = "001,900,907,911,912,925,926,927,id,leader,no,"
            Dim tlsql As String = ""
            Dim mxgsql As String
            Dim tag As String
            Dim point_pos As String = ""
            Dim strForming As String
            Dim tblData As DataTable
            Dim tblHolding As DataTable
            Dim tblDoc As DataTable
            Dim Data As Object
            Dim SubVal As Object
            Dim Stream As Object
            Dim strOutMsg As String
            Dim IncLib As Boolean
            Dim IncInv As Boolean
            Dim IncShelf As Boolean
            Dim intj, intl, intk As Integer
            Dim dtrow() As DataRow
            Dim row As DataRow
            Dim lngi As Long
            For lngi = lngStartID To lngStopID
                If lngi > lngUbound Then
                    Exit For
                End If
                strIDs = strIDs & objIDs(lngi) & ","
                strItemIDs = strItemIDs & objItemIDs(lngi) & ","
            Next
            If Not strIDs = "" And Not strItemIDs = "" Then
                strIDs = Left(strIDs, Len(strIDs) - 1)
                strItemIDs = Left(strItemIDs, Len(strItemIDs) - 1)
            End If
            TemplateID = intTemplateID
            TemplateType = 4
            tblTemplate = GetTemplate()
            If Not tblTemplate Is Nothing Then
                If tblTemplate.Rows.Count > 0 Then
                    strContent = tblTemplate.Rows(0).Item("Content")
                    'objTemplate.Template = objBCSP.ToUTF8(strContent)
                    'Fields = objTemplate.Fields
                    Fields = objBCT.getArrayFromTemplate(strContent)
                    Tabs = ""
                    Tab25 = 0
                    unionsql = ""
                    mxg = 0
                    tlsql = ""
                    For lngi = LBound(Fields) To UBound(Fields)
                        If InStr(exclTags, Fields(lngi) & ",") > 0 Then
                            Select Case Fields(lngi)
                                Case "leader"
                                    tlsql = tlsql & "ISNULL(Lib_tblItem.Leader,'') AS Leader, "
                                Case "001"
                                    tlsql = tlsql & "ISNULL(Lib_tblItem.Code,'') AS ITEMCODE, "
                                Case "907"
                                    tlsql = tlsql & "ISNULL(Lib_tblItem.CoverPicture,'') AS CoverPicture, "
                                Case "911"
                                    tlsql = tlsql & "ISNULL(Lib_tblItem.Reviewer,'') AS Reviewer, "
                                Case "912"
                                    tlsql = tlsql & "ISNULL(Lib_tblItem.Cataloguer,'') AS Cataloguer, "
                                Case "925"
                                    tlsql = tlsql & "ISNULL(Cat_tblDicMedium.Code,'') AS Code , "
                                Case "926"
                                    tlsql = tlsql & "ISNULL(Lib_tblItem.AccessLevel,0) AS AccessLevel, "
                                Case "927"
                                    tlsql = tlsql & "ISNULL(Cat_tblDic_ItemType.TypeCode) AS TypeCode, "
                            End Select
                        ElseIf InStr(Fields(lngi), "holding") = 1 Then
                            If Not InStr(Fields(lngi), "holdingcomposite") = 1 Then
                                If mxg = 0 Then
                                    If Not strDBServer = "ORACLE" Then
                                        mxgsql = "SELECT ISNULL(Lib_tblHoldingLibrary.Code,'') AS Code, ISNULL(Lib_tblHolding.CopyNumber,'') AS CopyNumber, ISNULL(Lib_tblHolding.CallNumber,'') AS CallNumber, ISNULL(Lib_tblHoldingLocation.Symbol,'') AS Symbol, ISNULL(Lib_tblHolding.Shelf,'') AS Shelf, ISNULL(Lib_tblHolding.ID,0) AS ID FROM Lib_tblHolding LEFT JOIN Lib_tblHoldingLibrary ON  Lib_tblHolding.LibID = Lib_tblHoldingLibrary.ID LEFT JOIN Lib_tblHoldingLocation ON Lib_tblHoldingLocation.ID = Lib_tblHolding.LocationID WHERE Lib_tblHolding.ID IN (" & strIDs & ")"
                                    Else
                                        mxgsql = "SELECT Lib_tblHoldingLibrary.Code, Lib_tblHolding.CopyNumber, Lib_tblHolding.CallNumber, Lib_tblHoldingLocation.Symbol, Lib_tblHolding.Shelf, Lib_tblHolding.ID FROM Lib_tblHolding LEFT JOIN Lib_tblHoldingLibrary ON  Lib_tblHolding.LibID = Lib_tblHoldingLibrary.ID LEFT JOIN Lib_tblHoldingLocation ON Lib_tblHoldingLocation.ID = Lib_tblHolding.LocationID WHERE Lib_tblHolding.ID IN (" & strIDs & ")"
                                        'mxgsql = "SELECT NVL(Lib_tblHoldingLibrary.Code,'') AS Code, NVL(CopyNumber,'') AS CopyNumber, NVL(Lib_tblHoldingLocation.Symbol,'') AS Symbol,NVL(Shelf,'') AS Shelf, NVL(Lib_tblHolding.ID,0) AS ID FROM Lib_tblHolding, Lib_tblHoldingLibrary, Lib_tblHoldingLocation WHERE Lib_tblHolding.LibID = Lib_tblHoldingLibrary.ID(+) AND Lib_tblHoldingLocation.ID(+) = Lib_tblHolding.LocationID AND Lib_tblHolding.ID IN (" & strIDs & ")"
                                    End If
                                    mxg = 1
                                End If
                            End If
                        ElseIf Left(Fields(lngi), 2) >= "25" And Left(Fields(lngi), 2) <= "30" And Tab25 = 0 Then
                            'Phuong 01/08/2008
                            'B2
                            'Lib_tblField200S.FieldCode = Lib_tblMARCBibField.ID
                            unionsql = unionsql & " SELECT Lib_tblField200S.ID, Lib_tblField200S.ItemID, Lib_tblField200S.Content, Lib_tblMARCBibField.FieldCode FROM Lib_tblField200S, Lib_tblMARCBibField WHERE Lib_tblField200S.FieldCode = Lib_tblMARCBibField.FieldCode AND Lib_tblField200S.ItemID IN(" & strItemIDs & ")  UNION"
                            'E2
                            'unionsql = unionsql & " SELECT Lib_tblField200S.ID, Lib_tblField200S.ItemID, Lib_tblField200S.Content, Lib_tblMARCBibField.FieldCode FROM Lib_tblField200S, Lib_tblMARCBibField WHERE Lib_tblField200S.FieldCode = Lib_tblMARCBibField.ID AND Lib_tblField200S.ItemID IN(" & strItemIDs & ")  UNION"
                            Tab25 = 1
                        ElseIf InStr(Tabs, Left(Fields(lngi), 1) & ",") = 0 Then
                            Tabs = Tabs & Left(Fields(lngi), 1) & ","
                            'unionsql = unionsql & " SELECT Field" & Left(Fields(lngi), 1) & "00s.ID, ItemID, Content, Lib_tblMARCBibField.FieldCode FROM Field" & Left(Fields(lngi), 1) & "00s, Lib_tblMARCBibField WHERE Lib_tblMARCBibField.ID = Field" & Left(Fields(lngi), 1) & "00s.FieldCode AND ItemID IN(" & strItemIDs & ")  UNION"
                            'Phuong 01/08/2008
                            'B3
                            'Lib_tblField200S.FieldCode = Lib_tblMARCBibField.ID
                            unionsql = unionsql & " SELECT Field" & Left(Fields(lngi), 1) & "00s.ID, ItemID, Content, Lib_tblMARCBibField.FieldCode FROM Field" & Left(Fields(lngi), 1) & "00s, Lib_tblMARCBibField WHERE Lib_tblMARCBibField.FieldCode = Field" & Left(Fields(lngi), 1) & "00s.FieldCode AND ItemID IN(" & strItemIDs & ")  UNION"
                            'E3
                        End If
                    Next
                    If Not unionsql = "" Then
                        unionsql = Left(unionsql, Len(unionsql) - 6)
                    End If
                End If
                If Not unionsql = "" Then
                    ' Lay du lieu tu cau lenh unionsql
                    objBCDBS.SQLStatement = unionsql
                    tblData = objBCDBS.RetrieveItemInfor
                End If
                If mxg = 1 Then
                    If Not intLocID + 0 = 0 Then
                        mxgsql = mxgsql & " AND Lib_tblHolding.LocationID = " & intLocID
                    Else
                        If Not intLibID + 0 = 0 Then
                            mxgsql = mxgsql & " AND Lib_tblHolding.LibID = " & intLibID
                        End If
                    End If
                    objBCDBS.SQLStatement = mxgsql
                    tblHolding = objBCDBS.RetrieveItemInfor("", True)
                End If
                If Not tlsql = "" Then
                    tlsql = tlsql & "ItemID, "
                    objBCDBS.SQLStatement = "SELECT " & Left(tlsql, Len(tlsql) - 2) & " FROM Lib_tblItem,Cat_tblDic_ItemType,Cat_tblDicMedium WHERE Cat_tblDicMedium.ID=Lib_tblItem.MediumID AND Lib_tblItem.TypeID=Cat_tblDic_ItemType.ID AND ItemID IN(" & strItemIDs & ")"
                    tblDoc = objBCDBS.RetrieveItemInfor
                End If
                intk = 0
                strOutMsg = "<TABLE><TR>"
                For lngi = lngStartID To lngStopID
                    If lngi > lngUbound Then
                        Exit For
                    End If
                    ReDim Data(UBound(Fields))
                    Dim strContentTemp As String = strContent
                    For intl = LBound(Fields) To UBound(Fields)
                        strContentTemp = strContent
                        If InStr(exclTags, Fields(intl) & ",") > 0 Then
                            row = Nothing
                            For intj = 0 To tblDoc.Rows.Count - 1
                                If tblDoc.Rows(intj).Item("ItemID") = objItemIDs(lngi) Then
                                    row = tblDoc.Rows(intj)
                                    Exit For
                                End If
                            Next
                            Select Case Fields(intl)
                                Case "id"
                                    Data(intl) = row.Item("ItemID") & Chr(9)
                                Case "leader"
                                    Data(intl) = Replace(row.Item("Leader").GetType.ToString, " ", "&nbsp;") & Chr(9)
                                Case "001"
                                    Data(intl) = row.Item("ITEMCODE") & Chr(9)
                                Case "907"
                                    Data(intl) = row.Item("CoverPicture") & Chr(9)
                                Case "911"
                                    Data(intl) = row.Item("Reviewer") & Chr(9)
                                Case "912"
                                    Data(intl) = row.Item("Cataloguer") & Chr(9)
                                Case "925"
                                    Data(intl) = row.Item("Code") & Chr(9)
                                Case "926"
                                    Data(intl) = row.Item("AccessLevel") & Chr(9)
                                Case "927"
                                    Data(intl) = row.Item("TypeCode") & Chr(9)
                            End Select
                            row = Nothing
                        ElseIf InStr(Fields(intl), "holding") = 0 Then
                            tag = Left(Fields(intl), 3)
                            dtrow = Nothing
                            Dim strFilter As String
                            Dim SubFieldCode As String = ""
                            strFilter = "ItemID=" & CStr(objItemIDs(lngi)) & " AND FieldCode LIKE '" & tag & "'"
                            dtrow = tblData.Select(strFilter)
                            If dtrow.Length > 0 Then
                                Dim intn As Integer
                                For intn = 0 To dtrow.Length - 1
                                    If Len(Fields(intl)) > 3 Then
                                        SubFieldCode = Right(Fields(intl), 2)
                                        objBCSP.ParseField(SubFieldCode, dtrow(intn).Item("Content"), "tr" & Chr(9), SubVal)
                                        If IsNothing(Data(intl)) Then
                                            Data(intl) = Data(intl) & objBCSP.TheDisplayOne(SubVal(0)) & Chr(9)
                                        ElseIf Not Data(intl).Trim = objBCSP.TheDisplayOne(SubVal(0)).Trim Then
                                            Data(intl) = Data(intl) & objBCSP.TheDisplayOne(SubVal(0)) & Chr(9)
                                        End If
                                    Else
                                        If IsNothing(Data(intl)) Then
                                            Data(intl) = Data(intl) & objBCSP.TrimSubFieldCodes(objBCSP.TheDisplayOne(dtrow(intn).Item("Content"))) & Chr(9)
                                        ElseIf Not Data(intl).Trim = objBCSP.TrimSubFieldCodes(objBCSP.TheDisplayOne(dtrow(intn).Item("Content"))).Trim Then
                                            Data(intl) = Data(intl) & objBCSP.TrimSubFieldCodes(objBCSP.TheDisplayOne(dtrow(intn).Item("Content"))) & Chr(9)
                                        End If
                                    End If
                                    'If Len(Fields(intl)) > 3 Then
                                    '    SubFieldCode = Right(Fields(intl), 2)
                                    '    objBCSP.ParseField(SubFieldCode, dtrow(intn).Item("Content"), "tr" & Chr(9), SubVal)

                                    '    Data(intl) = Data(intl) & objBCSP.TheDisplayOne(SubVal(0)) & Chr(9)
                                    'Else
                                    '    Data(intl) = Data(intl) & objBCSP.TrimSubFieldCodes(objBCSP.TheDisplayOne(dtrow(intn).Item("Content"))) & Chr(9)
                                    'End If
                                    If tag = "050" Or tag = "060" Then
                                        Data(intl) = Replace(Data(intl), " ", "<BR>")
                                    ElseIf tag = "082" And SubFieldCode = "$a" Then
                                        point_pos = InStr(Data(intl), ".")
                                        Data(intl) = Replace((Replace(Data(intl), ".", "")), Chr(9), "")
                                        strForming = ""
                                        c_j = 1
                                        For intj = 1 To Len(Data(intl))
                                            If intj Mod 3 = 0 Then
                                                strForming = strForming & Mid(Data(intl), intj - 2, 3)
                                                If intj <> Len(Data(intl)) Then strForming = strForming & "<BR>"
                                                c_j = intj
                                            End If
                                        Next
                                        If Not intj - c_j - 1 <= 0 Then
                                            strForming = strForming & Right(Data(intl), intj - c_j - 1)
                                        End If
                                        If point_pos > 0 Then
                                            point_pos = point_pos + ((point_pos - 2) \ 3) * 4
                                            strForming = Left(strForming, point_pos - 1) & "." & Right(strForming, Len(strForming) - point_pos + 1)
                                        End If
                                        Data(intl) = strForming & Chr(9)
                                    End If
                                Next
                            End If
                            dtrow = Nothing
                        ElseIf InStr(Fields(intl), "holdingcomposite") = 1 Then
                            If InStr(Fields(intl), ":lib") > 0 Then
                                IncLib = True
                            Else
                                IncLib = False
                            End If
                            If InStr(Fields(intl), ":inventory") > 0 Then
                                IncInv = True
                            Else
                                IncInv = False
                            End If
                            If InStr(Fields(intl), ":shelf") > 0 Then
                                IncShelf = True
                            Else
                                IncShelf = False
                            End If
                            Data(intl) = objBInput.GenerateCompositeHoldings(objItemIDs(lngi), IncLib, IncInv, IncShelf, "", "", ".") & Chr(9)
                        Else
                            dtrow = tblHolding.Select("ID=" & objIDs(lngi))
                            If InStr(Fields(intl), ":lib") > 0 Then
                                If Not dtrow Is Nothing And dtrow.Length > 0 And Not dtrow(0).Item("Code") = "" Then
                                    Data(intl) = Data(intl) & dtrow(0).Item("Code") & Chr(9)
                                End If
                            End If
                            If InStr(Fields(intl), ":inventory") > 0 Then
                                If Not dtrow Is Nothing And dtrow.Length > 0 And Not dtrow(0).Item("Symbol") = "" Then
                                    Data(intl) = Data(intl) & dtrow(0).Item("Symbol") & Chr(9)
                                End If
                            End If
                            If InStr(Fields(intl), ":shelf") > 0 Then
                                If Not dtrow Is Nothing And dtrow.Length > 0 And Not CStr(dtrow(0).Item("Shelf")) = "" Then
                                    Data(intl) = Data(intl) & dtrow(0).Item("Shelf") & Chr(9)
                                End If
                            End If

                            Dim _MXG As String
                            If InStr(Fields(intl), ":number") > 0 Then
                                If Not dtrow Is Nothing And dtrow.Length > 0 Then
                                    _MXG = ""
                                    Status = 1
                                    For intt = 1 To Len(dtrow(0).Item("CopyNumber"))
                                        If IsNumeric(Mid(dtrow(0).Item("CopyNumber"), intt, 1)) And Status = 1 Then
                                            Status = 0
                                            _MXG = _MXG & "<BR>"
                                        ElseIf Not IsNumeric(Mid(dtrow(0).Item("CopyNumber"), intt, 1)) And Status = 0 Then
                                            Status = 1
                                            _MXG = _MXG & "<BR>"
                                        End If
                                        _MXG = _MXG & Mid(dtrow(0).Item("CopyNumber"), intt, 1)
                                    Next
                                    If Left(_MXG, 4) = "<BR>" Then
                                        _MXG = Right(_MXG, Len(_MXG) - 4)
                                    End If
                                    Data(intl) = Data(intl) & _MXG & Chr(9)
                                End If
                            End If
                            If InStr(Fields(intl), ":bnumber") > 0 Then
                                Dim tbltmp As DataTable

                                tbltmp = objBCDBS.ConvertTable(objDCopyNumber.GetNumberRowOfCopyNumber(dtrow(0).Item("CopyNumber")))
                                If Not tbltmp Is Nothing AndAlso tbltmp.Rows.Count > 0 Then
                                    strContent = Replace(strContent, "<$" & Fields(intl) & "$>", "B" & tbltmp.Rows(0).Item("stt"))
                                Else
                                    strContent = Replace(strContent, "<$" & Fields(intl) & "$>", "")

                                End If


                            End If
                            If InStr(Fields(intl), ":callnumber") > 0 Then
                                If Not dtrow Is Nothing And dtrow.Length > 0 And Not CStr(dtrow(0).Item("CallNumber")) = "" Then
                                    Data(intl) = Data(intl) & Replace(dtrow(0).Item("CallNumber") & "", " ", "<BR>") & Chr(9)
                                End If
                            End If
                            dtrow = Nothing
                        End If
                        If Not Data(intl) = "" Then
                            Data(intl) = Left(Data(intl), Len(Data(intl)) - 1)
                        End If

                        strContentTemp = Replace(strContentTemp, "<$" & Fields(intl) & "$>", Data(intl))
                    Next
                    Stream = strContentTemp
                    'Stream = objBCsp.ToUTF8Back(objTemplate.Generate(Data).ToString)
                    If intk Mod intColPage = 0 And intk <> 0 Then
                        strOutMsg &= "</TR><TR>"
                    End If
                    intk += 1
                    strOutMsg &= "<TD> " & Stream & "</TD>"
                Next
                strOutMsg &= "</TR></TABLE>"
                PrintAcqLabel = strOutMsg
            End If
        End Function


        ' Purpose: Print Acquistion Label Report for DHKTTC
        ' In:  Some infor
        ' Out:  string
        ' Creator:  PhuongTT
        Public Function PrintAcqLabel_DHKTTC(ByVal objIDs As Object, ByVal objItemIDs As Object, ByVal intTemplateID As Integer, ByVal intLibID As Integer, ByVal intLocID As Integer, ByVal intHagPage As Integer, ByVal intColPage As Integer, ByVal lngStartID As Long, ByVal lngStopID As Long, ByVal lngUbound As Long) As String
            Dim tblTemplate As New DataTable
            Dim strContent As String
            Dim strIDs As String
            Dim strItemIDs As String
            Dim Fields As Object
            'Dim objTemplate As New TVCOMLib.LibolTemplate
            Dim Tabs As String
            Dim Tab25 As Integer = 0
            Dim Status As Integer
            Dim intt As Integer
            Dim unionsql As String
            Dim mxg As Integer = 0
            Dim c_j As Integer
            Dim exclTags As String = "001,900,907,911,912,925,926,927,id,leader,no,"
            Dim tlsql As String = ""
            Dim mxgsql As String
            Dim tag As String
            Dim point_pos As String = ""
            Dim strForming As String
            Dim tblData As DataTable
            Dim tblHolding As DataTable
            Dim tblDoc As DataTable
            Dim Data As Object
            Dim SubVal As Object
            Dim Stream As Object
            Dim strOutMsg As String
            Dim IncLib As Boolean
            Dim IncInv As Boolean
            Dim IncShelf As Boolean
            Dim intj, intl, intk As Integer
            Dim dtrow() As DataRow
            Dim row As DataRow
            Dim lngi As Long
            For lngi = lngStartID To lngStopID
                If lngi > lngUbound Then
                    Exit For
                End If
                strIDs = strIDs & objIDs(lngi) & ","
                strItemIDs = strItemIDs & objItemIDs(lngi) & ","
            Next
            If Not strIDs = "" And Not strItemIDs = "" Then
                strIDs = Left(strIDs, Len(strIDs) - 1)
                strItemIDs = Left(strItemIDs, Len(strItemIDs) - 1)
            End If
            TemplateID = intTemplateID
            TemplateType = 4
            tblTemplate = GetTemplate()
            If Not tblTemplate Is Nothing Then
                If tblTemplate.Rows.Count > 0 Then
                    strContent = tblTemplate.Rows(0).Item("Content")
                    'objTemplate.Template = objBCSP.ToUTF8(strContent)
                    'Fields = objTemplate.Fields
                    Fields = Me.getArrayFromTemplate(strContent)
                    Tabs = ""
                    Tab25 = 0
                    unionsql = ""
                    mxg = 0
                    tlsql = ""
                    For lngi = LBound(Fields) To UBound(Fields)
                        If InStr(exclTags, Fields(lngi) & ",") > 0 Then
                            Select Case Fields(lngi)
                                Case "leader"
                                    tlsql = tlsql & "ISNULL(Lib_tblItem.Leader,'') AS Leader, "
                                Case "001"
                                    tlsql = tlsql & "ISNULL(Lib_tblItem.Code,'') AS ITEMCODE, "
                                Case "907"
                                    tlsql = tlsql & "ISNULL(Lib_tblItem.CoverPicture,'') AS CoverPicture, "
                                Case "911"
                                    tlsql = tlsql & "ISNULL(Lib_tblItem.Reviewer,'') AS Reviewer, "
                                Case "912"
                                    tlsql = tlsql & "ISNULL(Lib_tblItem.Cataloguer,'') AS Cataloguer, "
                                Case "925"
                                    tlsql = tlsql & "ISNULL(Cat_tblDicMedium.Code,'') AS Code , "
                                Case "926"
                                    tlsql = tlsql & "ISNULL(Lib_tblItem.AccessLevel,0) AS AccessLevel, "
                                Case "927"
                                    tlsql = tlsql & "ISNULL(Cat_tblDic_ItemType.TypeCode) AS TypeCode, "
                            End Select
                        ElseIf InStr(Fields(lngi), "holding") = 1 Then
                            If Not InStr(Fields(lngi), "holdingcomposite") = 1 Then
                                If mxg = 0 Then
                                    If Not strDBServer = "ORACLE" Then
                                        mxgsql = "SELECT ISNULL(Lib_tblHoldingLibrary.Code,'') AS Code, ISNULL(Lib_tblHolding.CopyNumber,'') AS CopyNumber, ISNULL(Lib_tblHolding.CallNumber,'') AS CallNumber, ISNULL(Lib_tblHoldingLocation.Symbol,'') AS Symbol, ISNULL(Lib_tblHolding.Shelf,'') AS Shelf, ISNULL(Lib_tblHolding.ID,0) AS ID, ISNULL(Lib_tblHolding.NumberCopies,'') AS NumberCopies FROM Lib_tblHolding LEFT JOIN Lib_tblHoldingLibrary ON  Lib_tblHolding.LibID = Lib_tblHoldingLibrary.ID LEFT JOIN Lib_tblHoldingLocation ON Lib_tblHoldingLocation.ID = Lib_tblHolding.LocationID WHERE Lib_tblHolding.ID IN (" & strIDs & ")"
                                    Else
                                        mxgsql = "SELECT Lib_tblHoldingLibrary.Code, Lib_tblHolding.CopyNumber, Lib_tblHolding.CallNumber, Lib_tblHoldingLocation.Symbol, Lib_tblHolding.Shelf, Lib_tblHolding.ID FROM Lib_tblHolding LEFT JOIN Lib_tblHoldingLibrary ON  Lib_tblHolding.LibID = Lib_tblHoldingLibrary.ID LEFT JOIN Lib_tblHoldingLocation ON Lib_tblHoldingLocation.ID = Lib_tblHolding.LocationID WHERE Lib_tblHolding.ID IN (" & strIDs & ")"
                                        'mxgsql = "SELECT NVL(Lib_tblHoldingLibrary.Code,'') AS Code, NVL(CopyNumber,'') AS CopyNumber, NVL(Lib_tblHoldingLocation.Symbol,'') AS Symbol,NVL(Shelf,'') AS Shelf, NVL(Lib_tblHolding.ID,0) AS ID FROM Lib_tblHolding, Lib_tblHoldingLibrary, Lib_tblHoldingLocation WHERE Lib_tblHolding.LibID = Lib_tblHoldingLibrary.ID(+) AND Lib_tblHoldingLocation.ID(+) = Lib_tblHolding.LocationID AND Lib_tblHolding.ID IN (" & strIDs & ")"
                                    End If
                                    mxg = 1
                                End If
                            End If
                        ElseIf Left(Fields(lngi), 2) >= "25" And Left(Fields(lngi), 2) <= "30" And Tab25 = 0 Then
                            'Phuong 01/08/2008
                            'B2
                            'Lib_tblField200S.FieldCode = Lib_tblMARCBibField.ID
                            unionsql = unionsql & " SELECT Lib_tblField200S.ID, Lib_tblField200S.ItemID, Lib_tblField200S.Content, Lib_tblMARCBibField.FieldCode FROM Lib_tblField200S, Lib_tblMARCBibField WHERE Lib_tblField200S.FieldCode = Lib_tblMARCBibField.FieldCode AND Lib_tblField200S.ItemID IN(" & strItemIDs & ")  UNION"
                            'E2
                            'unionsql = unionsql & " SELECT Lib_tblField200S.ID, Lib_tblField200S.ItemID, Lib_tblField200S.Content, Lib_tblMARCBibField.FieldCode FROM Lib_tblField200S, Lib_tblMARCBibField WHERE Lib_tblField200S.FieldCode = Lib_tblMARCBibField.ID AND Lib_tblField200S.ItemID IN(" & strItemIDs & ")  UNION"
                            Tab25 = 1
                        ElseIf InStr(Tabs, Left(Fields(lngi), 1) & ",") = 0 Then
                            Tabs = Tabs & Left(Fields(lngi), 1) & ","
                            'unionsql = unionsql & " SELECT Field" & Left(Fields(lngi), 1) & "00s.ID, ItemID, Content, Lib_tblMARCBibField.FieldCode FROM Field" & Left(Fields(lngi), 1) & "00s, Lib_tblMARCBibField WHERE Lib_tblMARCBibField.ID = Field" & Left(Fields(lngi), 1) & "00s.FieldCode AND ItemID IN(" & strItemIDs & ")  UNION"
                            'Phuong 01/08/2008
                            'B3
                            'Lib_tblField200S.FieldCode = Lib_tblMARCBibField.ID
                            unionsql = unionsql & " SELECT Lib_tblField" & Left(Fields(lngi), 1) & "00s.ID, ItemID, Content, Lib_tblMARCBibField.FieldCode FROM Lib_tblField" & Left(Fields(lngi), 1) & "00s, Lib_tblMARCBibField WHERE Lib_tblMARCBibField.FieldCode = Lib_tblField" & Left(Fields(lngi), 1) & "00s.FieldCode AND ItemID IN(" & strItemIDs & ")  UNION"
                            'E3
                        End If
                    Next
                    If Not unionsql = "" Then
                        unionsql = Left(unionsql, Len(unionsql) - 6)
                    End If
                End If
                If Not unionsql = "" Then
                    ' Lay du lieu tu cau lenh unionsql
                    objBCDBS.SQLStatement = unionsql
                    tblData = objBCDBS.RetrieveItemInfor
                End If
                If mxg = 1 Then
                    If Not intLocID + 0 = 0 Then
                        mxgsql = mxgsql & " AND Lib_tblHolding.LocationID = " & intLocID
                    Else
                        If Not intLibID + 0 = 0 Then
                            mxgsql = mxgsql & " AND Lib_tblHolding.LibID = " & intLibID
                        End If
                    End If
                    objBCDBS.SQLStatement = mxgsql
                    tblHolding = objBCDBS.RetrieveItemInfor("", True)
                End If
                If Not tlsql = "" Then
                    tlsql = tlsql & "ItemID, "
                    objBCDBS.SQLStatement = "SELECT " & Left(tlsql, Len(tlsql) - 2) & " FROM Lib_tblItem,Cat_tblDic_ItemType,Cat_tblDicMedium WHERE Cat_tblDicMedium.ID=Lib_tblItem.MediumID AND Lib_tblItem.TypeID=Cat_tblDic_ItemType.ID AND ItemID IN(" & strItemIDs & ")"
                    tblDoc = objBCDBS.RetrieveItemInfor
                End If
                intk = 0
                strOutMsg = "<TABLE><TR>"

                Dim strContentTemp As String = strContent
                'Dim intItemId1 As String = ""
                'Dim intItemId2 As String = intItemId1
                'Dim intSTT As Integer = 0
                'If Not IsNothing(HttpContext.Current.Session("intSTT")) Then
                '    intSTT = HttpContext.Current.Session("intSTT")
                'End If
                'If Not IsNothing(HttpContext.Current.Session("intItemId1")) Then
                '    intItemId1 = HttpContext.Current.Session("intItemId1")
                'End If
                'If Not IsNothing(HttpContext.Current.Session("intItemId2")) Then
                '    intItemId2 = HttpContext.Current.Session("intItemId2")
                'End If

                For lngi = lngStartID To lngStopID
                    If lngi > lngUbound Then
                        While intk Mod intColPage <> 0
                            strOutMsg &= "<TD> <p style="""& "width: 4.5cm;height:4.2cm;" &"""></p></TD>"
                            intk += 1
                        End While
                        Exit For
                    End If
                    strContent = strContentTemp
                    ReDim Data(UBound(Fields))

                    'intItemId1 = objItemIDs(lngi)
                    'If intItemId1 = intItemId2 Then
                    '    intSTT = intSTT + 1
                    'Else
                    '    intSTT = 1
                    'End If
                    'intItemId2 = intItemId1
                    'HttpContext.Current.Session("intSTT") = intSTT
                    'HttpContext.Current.Session("intItemId1") = intItemId1
                    'HttpContext.Current.Session("intItemId2") = intItemId2

                    For intl = LBound(Fields) To UBound(Fields)
                        If InStr(exclTags, Fields(intl) & ",") > 0 Then
                            row = Nothing
                            For intj = 0 To tblDoc.Rows.Count - 1
                                If tblDoc.Rows(intj).Item("ItemID") = objItemIDs(lngi) Then
                                    row = tblDoc.Rows(intj)
                                    Exit For
                                End If
                            Next
                            Select Case Fields(intl)
                                Case "id"
                                    Data(intl) = row.Item("ItemID") & Chr(9)
                                Case "leader"
                                    Data(intl) = Replace(row.Item("Leader").GetType.ToString, " ", "&nbsp;") & Chr(9)
                                Case "001"
                                    Data(intl) = row.Item("ITEMCODE") & Chr(9)
                                Case "907"
                                    Data(intl) = row.Item("CoverPicture") & Chr(9)
                                Case "911"
                                    Data(intl) = row.Item("Reviewer") & Chr(9)
                                Case "912"
                                    Data(intl) = row.Item("Cataloguer") & Chr(9)
                                Case "925"
                                    Data(intl) = row.Item("Code") & Chr(9)
                                Case "926"
                                    Data(intl) = row.Item("AccessLevel") & Chr(9)
                                Case "927"
                                    Data(intl) = row.Item("TypeCode") & Chr(9)
                            End Select
                            row = Nothing
                        ElseIf InStr(Fields(intl), "holding") = 0 Then
                            If InStr(Fields(intl), "852$t") = 1 Then

                                ''objItemIDs(lngi)
                                'objBItem.ItemID = objItemIDs(lngi)
                                'Dim tblTempData As DataTable = objBItem.GetCopyNumbers()
                                ''Data(intl) = "C." & intSTT
                                'If Not IsNothing(tblTempData) Then
                                '    Data(intl) = tblTempData.Rows.Count
                                'End If

                                dtrow = tblHolding.Select("ID=" & objIDs(lngi))
                                If Not dtrow Is Nothing And dtrow.Length > 0 And Not dtrow(0).Item("NumberCopies") = "" Then
                                    Data(intl) = dtrow(0).Item("NumberCopies")
                                End If
                            Else
                                tag = Left(Fields(intl), 3)
                                dtrow = Nothing
                                Dim strFilter As String
                                Dim SubFieldCode As String = ""
                                strFilter = "ItemID=" & CStr(objItemIDs(lngi)) & " AND FieldCode LIKE '" & tag & "'"
                                dtrow = tblData.Select(strFilter)
                                If dtrow.Length > 0 Then
                                    Dim intn As Integer
                                    For intn = 0 To dtrow.Length - 1
                                        Dim strTmp As String = ""
                                        If Len(Fields(intl)) > 3 Then
                                            SubFieldCode = Right(Fields(intl), 2)
                                            objBCSP.ParseField(SubFieldCode, dtrow(intn).Item("Content"), "tr" & Chr(9), SubVal)
                                            If IsNothing(Data(intl)) Then
                                                strTmp = objBCSP.TheDisplayOne(SubVal(0))
                                                'Data(intl) = Data(intl) & objBCSP.TheDisplayOne(SubVal(0)) & Chr(9)
                                            ElseIf Not Data(intl).Trim = objBCSP.TheDisplayOne(SubVal(0)).Trim Then
                                                strTmp = objBCSP.TheDisplayOne(SubVal(0))
                                                'Data(intl) = Data(intl) & objBCSP.TheDisplayOne(SubVal(0)) & Chr(9)
                                            End If
                                        Else
                                            If IsNothing(Data(intl)) Then
                                                strTmp = objBCSP.TrimSubFieldCodes(objBCSP.TheDisplayOne(dtrow(intn).Item("Content")))
                                                'Data(intl) = Data(intl) & objBCSP.TrimSubFieldCodes(objBCSP.TheDisplayOne(dtrow(intn).Item("Content"))) & Chr(9)
                                            ElseIf Not Data(intl).Trim = objBCSP.TrimSubFieldCodes(objBCSP.TheDisplayOne(dtrow(intn).Item("Content"))).Trim Then
                                                strTmp = objBCSP.TrimSubFieldCodes(objBCSP.TheDisplayOne(dtrow(intn).Item("Content")))
                                                'Data(intl) = Data(intl) & objBCSP.TrimSubFieldCodes(objBCSP.TheDisplayOne(dtrow(intn).Item("Content"))) & Chr(9)
                                            End If
                                        End If
                                        If tag = "050" Or tag = "060" Then
                                            Data(intl) = Data(intl) & strTmp & Chr(9)
                                            Data(intl) = Replace(Data(intl), " ", "<BR>")
                                        ElseIf tag = "082" And SubFieldCode = "$a" Then
                                            Dim splitTmp() As String = strTmp.Split(".")
                                            If splitTmp.Length = 1 Then
                                                strTmp = Left(strTmp, 10).ToString() 'SonPQ 20220825, MKU nhap do dai 10
                                            Else
                                                strTmp = Left(splitTmp(0), 3) & "." & Left(splitTmp(1), 9)
                                            End If

                                            'strTmp = Right(strTmp, 9).ToString()

                                            Data(intl) = Data(intl) & strTmp
                                            If intn < dtrow.Length - 1 Then
                                                'Data(intl) = Data(intl) & "<BR>"
                                            End If
                                            'point_pos = InStr(Data(intl), ".")
                                            'Data(intl) = Replace((Replace(Data(intl), ".", "")), Chr(9), "")
                                            'strForming = ""
                                            'c_j = 1
                                            'For intj = 1 To Len(Data(intl))
                                            '    If intj Mod 3 = 0 Then
                                            '        strForming = strForming & Mid(Data(intl), intj - 2, 3)
                                            '        If intj <> Len(Data(intl)) Then strForming = strForming & "<BR>"
                                            '        c_j = intj
                                            '    End If
                                            'Next
                                            'If Not intj - c_j - 1 <= 0 Then
                                            '    strForming = strForming & Right(Data(intl), intj - c_j - 1)
                                            'End If
                                            'If point_pos > 0 Then
                                            '    point_pos = point_pos + ((point_pos - 2) \ 3) * 4
                                            '    strForming = Left(strForming, point_pos - 1) & "." & Right(strForming, Len(strForming) - point_pos + 1)
                                            'End If
                                            'Data(intl) = strForming & Chr(9)
                                            'Data(intl) &= Chr(9)
                                        Else
                                            Data(intl) = Data(intl) & strTmp & Chr(9)
                                        End If
                                    Next
                                End If
                                dtrow = Nothing
                            End If

                        ElseIf InStr(Fields(intl), "holdingcomposite") = 1 Then
                            If InStr(Fields(intl), ":lib") > 0 Then
                                IncLib = True
                            Else
                                IncLib = False
                            End If
                            If InStr(Fields(intl), ":inventory") > 0 Then
                                IncInv = True
                            Else
                                IncInv = False
                            End If
                            If InStr(Fields(intl), ":shelf") > 0 Then
                                IncShelf = True
                            Else
                                IncShelf = False
                            End If
                            Data(intl) = objBInput.GenerateCompositeHoldings(objItemIDs(lngi), IncLib, IncInv, IncShelf, "", "", ".") & Chr(9)
                        Else
                            dtrow = tblHolding.Select("ID=" & objIDs(lngi))
                            If InStr(Fields(intl), ":lib") > 0 Then
                                If Not dtrow Is Nothing And dtrow.Length > 0 And Not dtrow(0).Item("Code") = "" Then
                                    Data(intl) = Data(intl) & dtrow(0).Item("Code") & Chr(9)
                                End If
                            End If
                            If InStr(Fields(intl), ":inventory") > 0 Then
                                If Not dtrow Is Nothing And dtrow.Length > 0 And Not dtrow(0).Item("Symbol") = "" Then
                                    Data(intl) = Data(intl) & dtrow(0).Item("Symbol") & Chr(9)
                                Else
                                    Data(intl) &= Chr(9)
                                End If
                            End If
                            If InStr(Fields(intl), ":shelf") > 0 Then
                                If Not dtrow Is Nothing And dtrow.Length > 0 And Not CStr(dtrow(0).Item("Shelf")) = "" Then
                                    Data(intl) = Data(intl) & dtrow(0).Item("Shelf") & Chr(9)
                                End If
                            End If

                            Dim _MXG As String
                            If InStr(Fields(intl), ":number") > 0 Then
                                _MXG = ""
                                If Not dtrow Is Nothing And dtrow.Length > 0 Then
                                    'Status = 1
                                    'For intt = 1 To Len(dtrow(0).Item("CopyNumber"))
                                    '    If IsNumeric(Mid(dtrow(0).Item("CopyNumber"), intt, 1)) And Status = 1 Then
                                    '        Status = 0
                                    '        _MXG = _MXG & "<BR>"
                                    '    ElseIf Not IsNumeric(Mid(dtrow(0).Item("CopyNumber"), intt, 1)) And Status = 0 Then
                                    '        Status = 1
                                    '        _MXG = _MXG & "<BR>"
                                    '    End If
                                    '    _MXG = _MXG & Mid(dtrow(0).Item("CopyNumber"), intt, 1)
                                    'Next
                                    'If Left(_MXG, 4) = "<BR>" Then
                                    '    _MXG = Right(_MXG, Len(_MXG) - 4)
                                    'End If
                                    If Not IsDBNull(dtrow(0).Item("CopyNumber")) Then
                                        _MXG = dtrow(0).Item("CopyNumber")
                                        Data(intl) &= _MXG & Chr(9)
                                    End If
                                End If
                            End If
                            If InStr(Fields(intl), ":bnumber") > 0 Then
                                Dim tbltmp As DataTable

                                tbltmp = objBCDBS.ConvertTable(objDCopyNumber.GetNumberRowOfCopyNumber(dtrow(0).Item("CopyNumber")))
                                If Not tbltmp Is Nothing AndAlso tbltmp.Rows.Count > 0 Then
                                    strContent = Replace(strContent, "<$" & Fields(intl) & "$>", "B" & tbltmp.Rows(0).Item("stt"))
                                Else
                                    strContent = Replace(strContent, "<$" & Fields(intl) & "$>", "")

                                End If


                            End If
                            If InStr(Fields(intl), ":callnumber") > 0 Then
                                If Not dtrow Is Nothing And dtrow.Length > 0 And Not CStr(dtrow(0).Item("CallNumber")) = "" Then
                                    Data(intl) = Data(intl) & Replace(dtrow(0).Item("CallNumber") & "", " ", "<BR>") & Chr(9)
                                End If
                            End If
                            dtrow = Nothing
                        End If
                        'If Not IsNothing(Data(intl)) AndAlso Data(intl) <> "" Then
                        '    If Not Data(intl) = "" Then
                        '        Data(intl) = Left(Data(intl), Len(Data(intl)) - 1)
                        '    End If
                        '    'Chuyển đổi Đ hoặc đ dùm cho việc chuyển font bị lỗi bị convert cắt thiếu chuỗi
                        '    If InStr(Data(intl).ToUpper.ToString, "Đ") > 0 Then
                        '        Data(intl) = Replace(Data(intl), "Đ", "@phuongtt1@")
                        '        Data(intl) = Replace(Data(intl), "đ", "@phuongtt1@")
                        '    End If
                        '    If InStr(Data(intl).ToUpper.ToString, "Ê") > 0 Then
                        '        Data(intl) = Replace(Data(intl), "Ê", "@phuongtt2@")
                        '        Data(intl) = Replace(Data(intl), "ê", "@phuongtt2@")
                        '    End If
                        '    If InStr(Data(intl).ToUpper.ToString, "Ơ") > 0 Then
                        '        Data(intl) = Replace(Data(intl), "Ơ", "@phuongtt3@")
                        '        Data(intl) = Replace(Data(intl), "ơ", "@phuongtt3@")
                        '    End If
                        '    If InStr(Data(intl).ToUpper.ToString, "Ư") > 0 Then
                        '        Data(intl) = Replace(Data(intl), "Ư", "@phuongtt4@")
                        '        Data(intl) = Replace(Data(intl), "ư", "@phuongtt4@")
                        '    End If
                        '    If InStr(Data(intl).ToUpper.ToString, "Â") > 0 Then
                        '        Data(intl) = Replace(Data(intl), "Â", "@phuongtt5@")
                        '        Data(intl) = Replace(Data(intl), "â", "@phuongtt5@")
                        '    End If
                        '    If InStr(Data(intl).ToUpper.ToString, "Ă") > 0 Then
                        '        Data(intl) = Replace(Data(intl), "Ă", "@phuongtt6@")
                        '        Data(intl) = Replace(Data(intl), "ă", "@phuongtt6@")
                        '    End If
                        'End If
                        strContent = Replace(strContent, "<$" & Fields(intl) & "$>", Data(intl))
                    Next
                    'Note : Kiem tra TVCom chuyen font  -->Chu y
                    'Stream = objBCsp.ToUTF8Back(objTemplate.Generate(Data).ToString)
                    Stream = strContent

                    'Stream = Replace(Stream, "@phuongtt1@", "Đ")
                    'Stream = Replace(Stream, "@phuongtt2@", "Ê")
                    'Stream = Replace(Stream, "@phuongtt3@", "Ơ")
                    'Stream = Replace(Stream, "@phuongtt4@", "Ư")
                    'Stream = Replace(Stream, "@phuongtt5@", "Â")
                    'Stream = Replace(Stream, "@phuongtt6@", "Ă")
                    If intk Mod intColPage = 0 And intk <> 0 Then
                        strOutMsg &= "</TR><TR>"
                    End If
                    intk += 1
                    strOutMsg &= "<TD> " & Stream & "</TD>"
                Next
                strOutMsg &= "</TR></TABLE>"
                PrintAcqLabel_DHKTTC = strOutMsg
            End If
        End Function

        Public Function PrintAcqLabel_CSV(ByVal objIDs As Object, ByVal objItemIDs As Object,
                                          ByVal intTemplateID As Integer, ByVal intLibID As Integer,
                                          ByVal intLocID As Integer, ByVal lngStartID As Long,
                                          ByVal lngStopID As Long, ByVal lngUbound As Long) As StringBuilder
            Dim tblTemplate As New DataTable
            Dim strContent As String = ""
            Dim strIDs As String = ""
            Dim strItemIDs As String = ""
            Dim Fields() As String = Nothing
            Dim Tabs As String
            Dim Tab25 As Integer = 0
            Dim unionsql As String = ""
            Dim mxg As Integer = 0
            Dim exclTags As String = "001,900,907,911,912,925,926,927,id,leader,no,"
            Dim tlsql As String = ""
            Dim mxgsql As String = ""
            Dim tag As String = ""
            Dim point_pos As String = ""
            Dim tblData As DataTable = Nothing
            Dim tblHolding As DataTable = Nothing
            Dim tblDoc As DataTable = Nothing
            Dim Data As Object
            Dim SubVal As Object = Nothing
            Dim Stream As Object = Nothing
            Dim strOutMsg As New StringBuilder(1024)
            Dim IncLib As Boolean
            Dim IncInv As Boolean
            Dim IncShelf As Boolean
            Dim intj, intl As Integer
            Dim dtrow() As DataRow = Nothing
            Dim row As DataRow
            Dim lngi As Long

            For lngi = 0 To lngStopID
                If lngi > lngUbound Then
                    Exit For
                End If
                strIDs = strIDs & objIDs(lngi) & ","
                strItemIDs = strItemIDs & objItemIDs(lngi) & ","
            Next
            If Not strIDs = "" And Not strItemIDs = "" Then
                strIDs = Left(strIDs, Len(strIDs) - 1)
                strItemIDs = Left(strItemIDs, Len(strItemIDs) - 1)
            End If
            TemplateID = intTemplateID
            TemplateType = 4
            tblTemplate = GetTemplate()
            If Not tblTemplate Is Nothing Then
                If tblTemplate.Rows.Count > 0 Then
                    Fields = getArrayFromTemplate(tblTemplate.Rows(0).Item("Content"))
                    strContent = "TVĐHQTMĐ,"
                    For Each s As String In Fields
                        strContent &= String.Format("<${0}$>,", s)
                    Next

                    Tabs = ""
                    Tab25 = 0
                    unionsql = ""
                    mxg = 0
                    tlsql = ""
                    For lngi = LBound(Fields) To UBound(Fields)
                        If InStr(exclTags, Fields(lngi) & ",") > 0 Then
                            Select Case Fields(lngi)
                                Case "leader"
                                    tlsql = tlsql & "ISNULL(Lib_tblItem.Leader,'') AS Leader, "
                                Case "001"
                                    tlsql = tlsql & "ISNULL(Lib_tblItem.Code,'') AS ITEMCODE, "
                                Case "907"
                                    tlsql = tlsql & "ISNULL(Lib_tblItem.CoverPicture,'') AS CoverPicture, "
                                Case "911"
                                    tlsql = tlsql & "ISNULL(Lib_tblItem.Reviewer,'') AS Reviewer, "
                                Case "912"
                                    tlsql = tlsql & "ISNULL(Lib_tblItem.Cataloguer,'') AS Cataloguer, "
                                Case "925"
                                    tlsql = tlsql & "ISNULL(Cat_tblDicMedium.Code,'') AS Code , "
                                Case "926"
                                    tlsql = tlsql & "ISNULL(Lib_tblItem.AccessLevel,0) AS AccessLevel, "
                                Case "927"
                                    tlsql = tlsql & "ISNULL(Cat_tblDic_ItemType.TypeCode) AS TypeCode, "
                            End Select
                        ElseIf InStr(Fields(lngi), "holding") = 1 Then
                            If Not InStr(Fields(lngi), "holdingcomposite") = 1 Then
                                If mxg = 0 Then
                                    If Not strDBServer = "ORACLE" Then
                                        mxgsql = "SELECT ISNULL(Lib_tblHoldingLibrary.Code,'') AS Code, ISNULL(Lib_tblHolding.CopyNumber,'') AS CopyNumber, ISNULL(Lib_tblHolding.CallNumber,'') AS CallNumber, ISNULL(Lib_tblHoldingLocation.Symbol,'') AS Symbol, ISNULL(Lib_tblHolding.Shelf,'') AS Shelf, ISNULL(Lib_tblHolding.ID,0) AS ID, ISNULL(Lib_tblHolding.NumberCopies,'') AS NumberCopies FROM Lib_tblHolding LEFT JOIN Lib_tblHoldingLibrary ON  Lib_tblHolding.LibID = Lib_tblHoldingLibrary.ID LEFT JOIN Lib_tblHoldingLocation ON Lib_tblHoldingLocation.ID = Lib_tblHolding.LocationID WHERE Lib_tblHolding.ID IN (" & strIDs & ")"
                                    Else
                                        mxgsql = "SELECT Lib_tblHoldingLibrary.Code, Lib_tblHolding.CopyNumber, Lib_tblHolding.CallNumber, Lib_tblHoldingLocation.Symbol, Lib_tblHolding.Shelf, Lib_tblHolding.ID FROM Lib_tblHolding LEFT JOIN Lib_tblHoldingLibrary ON  Lib_tblHolding.LibID = Lib_tblHoldingLibrary.ID LEFT JOIN Lib_tblHoldingLocation ON Lib_tblHoldingLocation.ID = Lib_tblHolding.LocationID WHERE Lib_tblHolding.ID IN (" & strIDs & ")"
                                    End If
                                    mxg = 1
                                End If
                            End If
                        ElseIf Left(Fields(lngi), 2) >= "25" And Left(Fields(lngi), 2) <= "30" And Tab25 = 0 Then
                            unionsql = unionsql & " SELECT Lib_tblField200S.ID, Lib_tblField200S.ItemID, Lib_tblField200S.Content, Lib_tblMARCBibField.FieldCode FROM Lib_tblField200S, Lib_tblMARCBibField WHERE Lib_tblField200S.FieldCode = Lib_tblMARCBibField.FieldCode AND Lib_tblField200S.ItemID IN(" & strItemIDs & ")  UNION"
                            Tab25 = 1
                        ElseIf InStr(Tabs, Left(Fields(lngi), 1) & ",") = 0 Then
                            Tabs = Tabs & Left(Fields(lngi), 1) & ","
                            unionsql = unionsql & " SELECT Lib_tblField" & Left(Fields(lngi), 1) & "00s.ID, ItemID, Content, Lib_tblMARCBibField.FieldCode FROM Lib_tblField" & Left(Fields(lngi), 1) & "00s, Lib_tblMARCBibField WHERE Lib_tblMARCBibField.FieldCode = Lib_tblField" & Left(Fields(lngi), 1) & "00s.FieldCode AND ItemID IN(" & strItemIDs & ")  UNION"
                        End If
                    Next
                    If Not unionsql = "" Then
                        unionsql = Left(unionsql, Len(unionsql) - 6)
                    End If
                End If
                If Not unionsql = "" Then
                    objBCDBS.SQLStatement = unionsql
                    tblData = objBCDBS.RetrieveItemInfor
                End If
                If mxg = 1 Then
                    If Not intLocID + 0 = 0 Then
                        mxgsql = mxgsql & " AND Lib_tblHolding.LocationID = " & intLocID
                    Else
                        If Not intLibID + 0 = 0 Then
                            mxgsql = mxgsql & " AND Lib_tblHolding.LibID = " & intLibID
                        End If
                    End If
                    objBCDBS.SQLStatement = mxgsql
                    tblHolding = objBCDBS.RetrieveItemInfor("", True)
                End If
                If Not tlsql = "" Then
                    tlsql = tlsql & "ItemID, "
                    objBCDBS.SQLStatement = "SELECT " & Left(tlsql, Len(tlsql) - 2) & " FROM Lib_tblItem,Cat_tblDic_ItemType,Cat_tblDicMedium WHERE Cat_tblDicMedium.ID=Lib_tblItem.MediumID AND Lib_tblItem.TypeID=Cat_tblDic_ItemType.ID AND ItemID IN(" & strItemIDs & ")"
                    tblDoc = objBCDBS.RetrieveItemInfor
                End If

                Dim strContentTemp As String = strContent

                For lngi = lngStartID To lngStopID
                    strContent = strContentTemp
                    ReDim Data(UBound(Fields))

                    For intl = LBound(Fields) To UBound(Fields)
                        If InStr(exclTags, Fields(intl) & ",") > 0 Then
                            row = Nothing
                            For intj = 0 To tblDoc.Rows.Count - 1
                                If tblDoc.Rows(intj).Item("ItemID") = objItemIDs(lngi) Then
                                    row = tblDoc.Rows(intj)
                                    Exit For
                                End If
                            Next
                            Select Case Fields(intl)
                                Case "id"
                                    Data(intl) = row.Item("ItemID") & Chr(9)
                                Case "leader"
                                    Data(intl) = Replace(row.Item("Leader").GetType.ToString, " ", "&nbsp;") & Chr(9)
                                Case "001"
                                    Data(intl) = row.Item("ITEMCODE") & Chr(9)
                                Case "907"
                                    Data(intl) = row.Item("CoverPicture") & Chr(9)
                                Case "911"
                                    Data(intl) = row.Item("Reviewer") & Chr(9)
                                Case "912"
                                    Data(intl) = row.Item("Cataloguer") & Chr(9)
                                Case "925"
                                    Data(intl) = row.Item("Code") & Chr(9)
                                Case "926"
                                    Data(intl) = row.Item("AccessLevel") & Chr(9)
                                Case "927"
                                    Data(intl) = row.Item("TypeCode") & Chr(9)
                            End Select
                            row = Nothing
                        ElseIf InStr(Fields(intl), "holding") = 0 Then
                            If InStr(Fields(intl), "852$t") = 1 Then

                                dtrow = tblHolding.Select("ID=" & objIDs(lngi))
                                If Not dtrow Is Nothing And dtrow.Length > 0 And Not dtrow(0).Item("NumberCopies") = "" Then
                                    Data(intl) = dtrow(0).Item("NumberCopies")
                                End If
                            Else
                                tag = Left(Fields(intl), 3)
                                dtrow = Nothing
                                Dim strFilter As String
                                Dim SubFieldCode As String = ""
                                strFilter = "ItemID=" & CStr(objItemIDs(lngi)) & " AND FieldCode LIKE '" & tag & "'"
                                dtrow = tblData.Select(strFilter)
                                If dtrow.Length > 0 Then
                                    Dim intn As Integer
                                    For intn = 0 To dtrow.Length - 1
                                        Dim strTmp As String = ""
                                        If Len(Fields(intl)) > 3 Then
                                            SubFieldCode = Right(Fields(intl), 2)
                                            objBCSP.ParseField(SubFieldCode, dtrow(intn).Item("Content"), "tr" & Chr(9), SubVal)
                                            If IsNothing(Data(intl)) Then
                                                strTmp = objBCSP.TheDisplayOne(SubVal(0))
                                            ElseIf Not Data(intl).Trim = objBCSP.TheDisplayOne(SubVal(0)).Trim Then
                                                strTmp = objBCSP.TheDisplayOne(SubVal(0))
                                            End If
                                        Else
                                            If IsNothing(Data(intl)) Then
                                                strTmp = objBCSP.TrimSubFieldCodes(objBCSP.TheDisplayOne(dtrow(intn).Item("Content")))
                                            ElseIf Not Data(intl).Trim = objBCSP.TrimSubFieldCodes(objBCSP.TheDisplayOne(dtrow(intn).Item("Content"))).Trim Then
                                                strTmp = objBCSP.TrimSubFieldCodes(objBCSP.TheDisplayOne(dtrow(intn).Item("Content")))
                                            End If
                                        End If
                                        If tag = "050" Or tag = "060" Then
                                            Data(intl) = Data(intl) & strTmp & Chr(9)
                                            Data(intl) = Replace(Data(intl), " ", "")
                                        ElseIf tag = "082" And SubFieldCode = "$a" Then
                                            Dim splitTmp() As String = strTmp.Split(".")
                                            If splitTmp.Length = 1 Then
                                                strTmp = Left(strTmp, 9).ToString()
                                            Else
                                                strTmp = Left(splitTmp(0), 3) & "." & Left(splitTmp(1), 8)
                                            End If
                                            Data(intl) = Data(intl) & strTmp
                                        Else
                                            Data(intl) = Data(intl) & strTmp & Chr(9)
                                        End If
                                    Next
                                End If
                                dtrow = Nothing
                            End If

                        ElseIf InStr(Fields(intl), "holdingcomposite") = 1 Then
                            If InStr(Fields(intl), ":lib") > 0 Then
                                IncLib = True
                            Else
                                IncLib = False
                            End If
                            If InStr(Fields(intl), ":inventory") > 0 Then
                                IncInv = True
                            Else
                                IncInv = False
                            End If
                            If InStr(Fields(intl), ":shelf") > 0 Then
                                IncShelf = True
                            Else
                                IncShelf = False
                            End If
                            Data(intl) = objBInput.GenerateCompositeHoldings(objItemIDs(lngi), IncLib, IncInv, IncShelf, "", "", ".") & Chr(9)
                        Else
                            dtrow = tblHolding.Select("ID=" & objIDs(lngi))
                            If InStr(Fields(intl), ":lib") > 0 Then
                                If Not dtrow Is Nothing And dtrow.Length > 0 And Not dtrow(0).Item("Code") = "" Then
                                    Data(intl) = Data(intl) & dtrow(0).Item("Code") & Chr(9)
                                End If
                            End If
                            If InStr(Fields(intl), ":inventory") > 0 Then
                                If Not dtrow Is Nothing And dtrow.Length > 0 And Not dtrow(0).Item("Symbol") = "" Then
                                    Data(intl) = Data(intl) & dtrow(0).Item("Symbol") & Chr(9)
                                Else
                                    Data(intl) &= Chr(9)
                                End If
                            End If
                            If InStr(Fields(intl), ":shelf") > 0 Then
                                If Not dtrow Is Nothing And dtrow.Length > 0 And Not CStr(dtrow(0).Item("Shelf")) = "" Then
                                    Data(intl) = Data(intl) & dtrow(0).Item("Shelf") & Chr(9)
                                End If
                            End If

                            Dim _MXG As String
                            If InStr(Fields(intl), ":number") > 0 Then
                                _MXG = ""
                                If Not dtrow Is Nothing And dtrow.Length > 0 Then
                                    If Not IsDBNull(dtrow(0).Item("CopyNumber")) Then
                                        _MXG = dtrow(0).Item("CopyNumber")
                                        Data(intl) &= _MXG & Chr(9)
                                    End If
                                End If
                            End If
                            If InStr(Fields(intl), ":bnumber") > 0 Then
                                Dim tbltmp As DataTable

                                tbltmp = objBCDBS.ConvertTable(objDCopyNumber.GetNumberRowOfCopyNumber(dtrow(0).Item("CopyNumber")))
                                If Not tbltmp Is Nothing AndAlso tbltmp.Rows.Count > 0 Then
                                    strContent = Replace(strContent, "<$" & Fields(intl) & "$>", "B" & tbltmp.Rows(0).Item("stt"))
                                Else
                                    strContent = Replace(strContent, "<$" & Fields(intl) & "$>", "")
                                End If
                            End If
                            If InStr(Fields(intl), ":callnumber") > 0 Then
                                If Not dtrow Is Nothing And dtrow.Length > 0 And Not CStr(dtrow(0).Item("CallNumber")) = "" Then
                                    Data(intl) = Data(intl) & Replace(dtrow(0).Item("CallNumber") & "", " ", "") & Chr(9)
                                End If
                            End If
                            dtrow = Nothing
                        End If
                        If Data(intl) Is Nothing Then
                            Data(intl) = ""
                        End If
                        Dim strTemp As String = Replace(strContent, "<$" & Fields(intl) & "$>", Data(intl))
                        strTemp = Replace(strTemp, vbTab, "")
                        strTemp = Replace(strTemp, vbNullChar, "")
                        strContent = strTemp
                    Next

                    Stream = strContent
                    strOutMsg.Append(Stream).Append(vbCrLf)
                Next
                strOutMsg.Append(vbCrLf)
            End If
            Return strOutMsg
        End Function


        ' Purpoose: Forming search SQL for Gen ComprehensiveReportBook
        ' In: some infor
        ' Out: String
        ' Creator: Sondp
        Public Function FormingSQLComprehensiveReportBook(ByVal intLibID As Integer, ByVal strFromAcqTime As String, ByVal strToAcqTime As String, Optional ByVal boolWhere As Boolean = False) As String
            Dim strWhere As String
            Dim strSelectSQL As String
            strWhere = ""
            strSelectSQL = ""
            ' Select Library
            If intLibID > 0 Then
                strWhere = strWhere & " AND LibID=" & intLibID
            End If
            ' From Acq time
            If strFromAcqTime <> "" Then
                If strDBServer.ToUpper = "ORACLE" Then
                    strWhere = strWhere & " AND AcquiredDate>=TO_DATE('" & objBCDBS.ConvertDateBack(strFromAcqTime) & "','MM/DD/YYYY HH24:MI:SS')"
                Else
                    strWhere = strWhere & " AND AcquiredDate>='" & objBCDBS.ConvertDateBack(strFromAcqTime) & "'"
                End If
            End If
            ' To Acq time
            If strToAcqTime <> "" Then
                If strDBServer.ToUpper = "ORACLE" Then
                    strWhere = strWhere & " AND AcquiredDate<=TO_DATE('" & objBCDBS.ConvertDateBack(strToAcqTime) & "','MM/DD/YYYY HH24:MI:SS')"
                Else
                    strWhere = strWhere & " AND AcquiredDate<='" & objBCDBS.ConvertDateBack(strToAcqTime) & "'"
                End If
            End If
            strWhere = " 1=1" & strWhere
            If Not boolWhere Then ' Return full select command
                If Not strWhere = "" Then
                    strSelectSQL = "SELECT ItemID FROM Lib_tblHolding WHERE" & strWhere & " GROUP BY ItemID"
                Else
                    strSelectSQL = "SELECT TOP 1000 ItemID FROM Lib_tblHolding GROUP BY ItemID"
                End If
            Else ' Return cordition select only
                strSelectSQL = strWhere
            End If
            ' Return value
            FormingSQLComprehensiveReportBook = strSelectSQL
        End Function

        '----------------------------------------------------------------------------------------------
        ' Purpose: Generate comprehensive report book
        ' In:  Some informations
        ' Out: string
        ' Creator:  Sondp
        '----------------------------------------------------------------------------------------------
        'Edit by:Tulnn
        'Modified Date:20/7
        Public Function GenComprehReportBook(ByVal lngStartID As Long, ByVal lngStopID As Long, ByVal arrItemIDs() As String, ByVal intUserID As Integer, ByVal collectReport As Collection) As String
            'Dim objUtf8 As New TVCOMLib.utf8
            Dim lngi, lngj, lngk, lngSumTotalItems, lngSumTotalPrice, arrSumOnLoc(), arrTotalPrice(), arrPrice() As Long
            Dim strPickItemIDs, strOutMsg, strValue, arrTotalItemID() As String
            Dim tblData As New DataTable
            Dim tblLoc, tblValue As DataTable
            Dim dtrows, dtrow As DataRow
            Dim boolFlage As Boolean
            Dim subVal() As Object
            Dim strCopyNumber As String
            Dim inti As Integer

            strPickItemIDs = ""
            strOutMsg = ""
            lngSumTotalItems = 0
            lngSumTotalPrice = 0
            boolFlage = False
            ReDim arrSumOnLoc(0)
            ReDim arrTotalPrice(0)
            ReDim arrPrice(0)
            ReDim arrTotalItemID(0)
            Try
                ' Pick ItemID
                If lngStartID > UBound(arrItemIDs) Then
                    lngStartID = UBound(arrItemIDs)
                    lngStopID = lngStartID
                End If
                If lngStopID > UBound(arrItemIDs) Then
                    lngStopID = UBound(arrItemIDs)
                End If
                For lngi = lngStartID To lngStopID
                    strPickItemIDs = strPickItemIDs & arrItemIDs(lngi) & ","
                Next
                If strPickItemIDs.Length > 0 Then
                    strPickItemIDs = Left(strPickItemIDs, strPickItemIDs.Length - 1)
                End If
                ' Get common data to display
                tblData = objBCDBS.ConvertTable(objDT.GetDataToGenComprehenRB(strPickItemIDs))
                strErrorMsg = objDT.ErrorMsg
                intErrorCode = objDT.ErrorCode
                If Not tblData Is Nothing Then
                    If tblData.Rows.Count > 0 Then
                        ReDim arrTotalItemID(tblData.Rows.Count - 1)
                        ReDim arrTotalPrice(tblData.Rows.Count - 1)
                        ReDim arrPrice(tblData.Rows.Count - 1)
                        For lngi = 0 To tblData.Rows.Count - 1
                            arrTotalItemID(lngi) = tblData.Rows(lngi).Item("TotalItemID")
                            arrPrice(lngi) = tblData.Rows(lngi).Item("Price")
                            arrTotalPrice(lngi) = tblData.Rows(lngi).Item("TotalPrice")
                        Next
                        ' Build table header
                        strOutMsg = "<TABLE style='Z-INDEX: 101; LEFT: 10px; POSITION: ralactive; TOP: 35px' WIDTH=1350 CELLPADDING=0 CELLSPACING=0 BORDER=0 ><TR><TD WIDTH=350 ALIGN=CENTER><H3>" & collectReport.Item("<$HEADERINFORM$>") & "</H3><BR></TD><TD WIDTH=25%><BR><B>" & collectReport.Item("<$ACQFROMTIME$>") & collectReport.Item("<$ACQTOTIME$>") & "</TD><TD WIDTH=40% ALIGN=RIGHT>" & collectReport.Item("<$PAGE$>") & collectReport.Item("<$CURRENTPAGE$>") & "</B></TD></TR></TABLE>"
                        strOutMsg = strOutMsg & "<TABLE WIDTH=1350  BORDER=1 CELLSPACING=1 CELLPADDING=3><TR>" & vbCrLf
                        ' Sequency collum
                        strOutMsg = strOutMsg & "<TD BGCOLOR=#E0E0E0 WIDTH=30 ROWSPAN=2 ALIGN=CENTER><B>" & collectReport.Item("<$SEQUENCYTEXT$>") & "</B></TD>" & vbCrLf
                        ' DKCB
                        strOutMsg = strOutMsg & "<TD BGCOLOR=#E0E0E0 WIDTH=150 ROWSPAN=2 ALIGN=CENTER><B>" & collectReport.Item("<$DKCB$>") & "</B></TD>" & vbCrLf
                        ' Title collum
                        strOutMsg = strOutMsg & "<TD BGCOLOR=#E0E0E0 WIDTH=700 ROWSPAN=2 ALIGN=CENTER><B>" & collectReport.Item("<$TITLE$>") & "</B></TD>" & vbCrLf
                        ' Tpye of subject
                        strOutMsg = strOutMsg & "<TD BGCOLOR=#E0E0E0 WIDTH=30 ROWSPAN=2 ALIGN=CENTER><B>" & collectReport.Item("<$TYPEOFSUBJECT$>") & "</B></TD>" & vbCrLf
                        ' Publisher
                        strOutMsg = strOutMsg & "<TD BGCOLOR=#E0E0E0 WIDTH=130 ROWSPAN=2 ALIGN=CENTER><B>" & collectReport.Item("<$PUBLISHER$>") & "</B></TD>" & vbCrLf
                        ' Pubisher Year
                        strOutMsg = strOutMsg & "<TD BGCOLOR=#E0E0E0 WIDTH=30 ROWSPAN=2 ALIGN=CENTER><B>" & collectReport.Item("<$PUBLISHEDYEAR$>") & "</B></TD>" & vbCrLf
                        ' Amount received
                        strOutMsg = strOutMsg & "<TD BGCOLOR=#E0E0E0 WIDTH=25 ROWSPAN=2 ALIGN=CENTER><B>" & collectReport.Item("<$RECEIVEDAMOUNT$>") & "</B></TD>" & vbCrLf
                        ' Price 
                        strOutMsg = strOutMsg & "<TD BGCOLOR=#E0E0E0 WIDTH=50 ROWSPAN=2 ALIGN=CENTER><B>" & collectReport.Item("<$PRICE$>") & "</B></TD>" & vbCrLf
                        ' Total price
                        strOutMsg = strOutMsg & "<TD BGCOLOR=#E0E0E0 WIDTH=50 ROWSPAN=2 ALIGN=CENTER><B>" & collectReport.Item("<$TOTALPRICES$>") & "</B></TD>" & vbCrLf
                        ' Amount export
                        ' Get all locations
                        objBLoc.LibID = collectReport.Item("<$LIBRARY$>")
                        objBLoc.LocID = 0
                        objBLoc.Status = -1
                        objBLoc.UserID = intUserID
                        tblLoc = objBLoc.GetLocation
                        strErrorMsg = objBLoc.ErrorMsg
                        intErrorCode = objBLoc.ErrorCode
                        If Not tblLoc Is Nothing Then
                            If tblLoc.Rows.Count > 0 Then
                                ReDim arrSumOnLoc(tblLoc.Rows.Count - 1)
                                strOutMsg = strOutMsg & "<TD BGCOLOR=#E0E0E0 WIDTH=280 COLSPAN=" & tblLoc.Rows.Count & " ALIGN=CENTER><B>" & collectReport.Item("<$EXPORTAMOUNT$>") & "</B></TD></TR><TR>" & vbCrLf
                                For lngi = 0 To tblLoc.Rows.Count - 1
                                    Try
                                        ' Didplay each location name
                                        strOutMsg = strOutMsg & "<TD BGCOLOR=#E0E0E0 WIDTH=40 ALIGN=CENTER><B>&nbsp;" & tblLoc.Rows(lngi).Item("Symbol") & "</B></TD>" & vbCrLf
                                    Catch ex As Exception
                                        strErrorMsg = ex.Message
                                        strOutMsg = strOutMsg & "<TD BGCOLOR=#E0E0E0 WIDTH=40 ALIGN=CENTER>&nbsp;</TD>" & vbCrLf
                                    End Try
                                Next
                                ' Finish display all location name
                                strOutMsg = strOutMsg & "</TR>" & vbCrLf
                            End If
                        End If
                        ' Display detail information
                        For lngi = 0 To tblData.Rows.Count - 1
                            Try
                                strOutMsg = strOutMsg & "<TR HEIGHT=30 BGCOLOR=#FFFFFF>" & vbCrLf
                                ' Sequency item
                                strOutMsg = strOutMsg & "<TD WIDTH=30 ALIGN=RIGTH>&nbsp;" & lngStartID + lngi + 1 & "</TD>" & vbCrLf
                                'DKCB
                                tblValue = Nothing
                                objBCDBS.SQLStatement = "SELECT DISTINCT LibID,LocationID FROM Lib_tblHolding WHERE ITEMID IN ('" & tblData.Rows(lngi).Item("ItemID") & "')"
                                tblValue = objBCDBS.RetrieveItemInfor
                                strErrorMsg = objBCDBS.ErrorMsg
                                intErrorCode = objBCDBS.ErrorCode
                                strValue = "&nbsp;"
                                strCopyNumber = ""
                                If Not tblValue Is Nothing Then
                                    If tblValue.Rows.Count > 0 Then
                                        For inti = 0 To tblValue.Rows.Count - 1
                                            strCopyNumber = strCopyNumber & objBInput.GenerateCompositeHoldings(tblData.Rows(lngi).Item("ItemID"), False, False, False, tblValue.Rows(inti).Item("LibID"), tblValue.Rows(inti).Item("LocationID"), " : ") & "<br>"
                                        Next
                                    End If
                                End If
                                strOutMsg = strOutMsg & "<TD WIDTH=150 ALIGN=RIGTH>" & strCopyNumber & "</TD>" & vbCrLf
                                ' Title item
                                tblValue = Nothing
                                objBCDBS.SQLStatement = "SELECT Content FROM Lib_tblField200S WHERE FieldCode=245 AND ItemID=" & tblData.Rows(lngi).Item("ItemID")
                                tblValue = objBCDBS.RetrieveItemInfor
                                strErrorMsg = objBCDBS.ErrorMsg
                                intErrorCode = objBCDBS.ErrorCode
                                strValue = "&nbsp;"
                                If Not tblValue Is Nothing Then
                                    If tblValue.Rows.Count > 0 Then
                                        strValue = objBCSP.TrimSubFieldCodes(objBCSP.ConvertItBack(tblValue.Rows(0).Item("Content")))
                                        objBCSP.CutWords(strValue, 110)
                                        'If objUtf8.Len(strValue) > 110 Then
                                        '    strValue = objUtf8.Left(strValue, 110) & "..."
                                        'End If
                                    End If
                                End If
                                strOutMsg = strOutMsg & "<TD WIDTH=700>" & strValue & "</TD>" & vbCrLf
                                ' Type of subject
                                tblValue = Nothing
                                objBCDBS.SQLStatement = "SELECT C.DISPLAYENTRY AS Content FROM CAT_DIC_CLASS_DDC C,ITEM_DDC I,Lib_tblHolding H WHERE I.DDCID=C.ID AND H.ITEMID=I.ITEMID AND H.ItemID IN ('" & tblData.Rows(lngi).Item("ItemID") & "')"
                                tblValue = objBCDBS.RetrieveItemInfor
                                strErrorMsg = objBCDBS.ErrorMsg
                                intErrorCode = objBCDBS.ErrorCode
                                strValue = "&nbsp;"
                                If Not tblValue Is Nothing Then
                                    If tblValue.Rows.Count > 0 Then
                                        strValue = Left(objBCSP.TrimSubFieldCodes(objBCSP.ConvertItBack(tblValue.Rows(0).Item("Content"))), 3)
                                    End If
                                End If
                                strOutMsg = strOutMsg & "<TD WIDTH=30 ALIGN=left>" & strValue & "</TD>" & vbCrLf
                                ' Publisher
                                tblValue = Nothing
                                objBCDBS.SQLStatement = "SELECT ISNULL(F200s.Content,'''') AS Content FROM Lib_tblHolding H, Lib_tblField200S F200s WHERE H.ItemID=F200s.ItemID AND F200s.FieldCode = (SELECT FieldCode FROM Lib_tblMARCBibField WHERE ID=517) AND H.ItemID IN('" & tblData.Rows(lngi).Item("ItemID") & "')"
                                tblValue = objBCDBS.RetrieveItemInfor
                                strErrorMsg = objBCDBS.ErrorMsg
                                intErrorCode = objBCDBS.ErrorCode
                                strValue = "&nbsp;"
                                If Not tblValue Is Nothing Then
                                    If tblValue.Rows.Count > 0 Then
                                        'objbcsp.ParseField("$b", objBCSP.TrimSubFieldCodes(objBCSP.ConvertItBack(tblValue.Rows(0).Item("Content"))), "", subVal)
                                        objBCSP.ParseField("$b", objBCSP.ConvertItBack(tblValue.Rows(0).Item("Content")), "", subVal)
                                        If Not subVal(0) = "" Then
                                            strValue = Left(subVal(0), Len(subVal(0)) - 1)
                                        End If
                                    End If
                                End If
                                strOutMsg = strOutMsg & "<TD WIDTH=130 ALIGN=Left>" & strValue & "</TD>" & vbCrLf

                                ' Dictionay Year
                                tblValue = Nothing
                                objBCDBS.SQLStatement = "SELECT Year FROM CAT_DIC_YEAR WHERE FieldCode = '260$c' AND ItemID=" & tblData.Rows(lngi).Item("ItemID")
                                tblValue = objBCDBS.RetrieveItemInfor
                                strErrorMsg = objBCDBS.ErrorMsg
                                intErrorCode = objBCDBS.ErrorCode
                                strValue = "&nbsp;"
                                If Not tblValue Is Nothing Then
                                    If tblValue.Rows.Count > 0 Then
                                        strValue = tblValue.Rows(0).Item("Year")
                                    End If
                                End If
                                strOutMsg = strOutMsg & "<TD WIDTH=30 ALIGN=Left>" & strValue & "</TD>" & vbCrLf

                                ' Amount received
                                strOutMsg = strOutMsg & "<TD WIDTH=30 ALIGN=Left>&nbsp;" & arrTotalItemID(lngi) & "</TD>" & vbCrLf
                                ' Price
                                strOutMsg = strOutMsg & "<TD WIDTH=50 ALIGN=Left>&nbsp;" & arrPrice(lngi) & "</TD>" & vbCrLf
                                ' Total Price
                                strOutMsg = strOutMsg & "<TD WIDTH=50 ALIGN=Left>&nbsp;" & arrTotalPrice(lngi) & "</TD>" & vbCrLf
                                ' Select data for each location                               
                                tblValue = Nothing
                                objBCDBS.SQLStatement = "SELECT LocationID, COUNT(*) AS AmountItems FROM Lib_tblHolding WHERE ItemID=" & tblData.Rows(lngi).Item("ItemID") & " AND" & FormingSQLComprehensiveReportBook(0, collectReport.Item("<$FROMTIME$>"), collectReport.Item("<$TOTIME$>"), True) & " GROUP BY LocationID"
                                tblValue = objBCDBS.RetrieveItemInfor
                                strErrorMsg = objBCDBS.ErrorMsg
                                intErrorCode = objBCDBS.ErrorCode
                                If Not tblValue Is Nothing Then
                                    If tblValue.Rows.Count > 0 Then
                                        For lngk = 0 To tblLoc.Rows.Count - 1
                                            boolFlage = False
                                            For lngj = 0 To tblValue.Rows.Count - 1
                                                If tblValue.Rows(lngj).Item("LocationID") = tblLoc.Rows(lngk).Item("ID") Then
                                                    boolFlage = True
                                                    arrSumOnLoc(lngk) = arrSumOnLoc(lngk) + tblValue.Rows(lngj).Item("AmountItems")
                                                    strOutMsg = strOutMsg & "<TD WIDTH=40 ALIGN=Left>&nbsp;" & tblValue.Rows(lngj).Item("AmountItems") & "</TD>"
                                                End If
                                            Next
                                            If Not boolFlage Then
                                                strOutMsg = strOutMsg & "<TD WIDTH=40 ALIGN=Left>&nbsp;</TD>" & vbCrLf
                                            End If
                                        Next
                                    End If
                                End If
                                strOutMsg = strOutMsg & "</TR>" & vbCrLf
                                lngSumTotalItems = lngSumTotalItems + arrTotalItemID(lngi)
                                If Not IsDBNull(arrTotalPrice(lngi)) Then
                                    lngSumTotalPrice = lngSumTotalPrice + arrTotalPrice(lngi)
                                End If
                            Catch ex As Exception
                                strErrorMsg = ex.Message
                            End Try
                        Next
                        ' Table footer (total items) 
                        strOutMsg = strOutMsg & "<TR BGCOLOR=#FFFFFF><TD WIDTH=30>&nbsp;</TD>" & vbCrLf
                        strOutMsg = strOutMsg & "<TD WIDTH=150>&nbsp;</TD>" & vbCrLf
                        strOutMsg = strOutMsg & "<TD WIDTH=800 ALIGN=Left><B>&nbsp;" & collectReport.Item("<$SUMITEMS$>") & "</TD>" & vbCrLf
                        strOutMsg = strOutMsg & "<TD WIDTH=30>&nbsp;</TD>" & vbCrLf
                        strOutMsg = strOutMsg & "<TD WIDTH=30>&nbsp;</TD>" & vbCrLf
                        strOutMsg = strOutMsg & "<TD WIDTH=30>&nbsp;</TD>" & vbCrLf
                        strOutMsg = strOutMsg & "<TD WIDTH=30 ALIGN=Left><B>&nbsp;" & lngSumTotalItems & "</TD>" & vbCrLf
                        strOutMsg = strOutMsg & "<TD WIDTH=50>&nbsp;</TD>" & vbCrLf
                        If lngSumTotalPrice > 0 Then
                            strOutMsg = strOutMsg & "<TD WIDTH=50 ALIGN=Left><B>&nbsp;" & lngSumTotalPrice & "</TD>" & vbCrLf
                        Else
                            strOutMsg = strOutMsg & "<TD WIDTH=50 ALIGN=Left>&nbsp;</TD>" & vbCrLf
                        End If
                        If Not tblLoc Is Nothing Then
                            If tblLoc.Rows.Count > 0 Then
                                For lngj = 0 To tblLoc.Rows.Count - 1
                                    strOutMsg = strOutMsg & "<TD WIDTH=40 ALIGN=Left>&nbsp;" & arrSumOnLoc(lngj) & "</TD>" & vbCrLf
                                Next
                            End If
                        End If
                        strOutMsg = strOutMsg & "</TR>" & vbCrLf
                        ' Add total items
                        lngSumTotalPrice = 0
                        lngSumTotalItems = 0
                        For lngi = 0 To tblData.Rows.Count - 1
                            lngSumTotalItems = lngSumTotalItems + arrTotalItemID(lngi)
                            If Not IsDBNull(arrTotalPrice(lngi)) Then
                                lngSumTotalPrice = lngSumTotalPrice + arrTotalPrice(lngi)
                            End If
                        Next
                        strOutMsg = strOutMsg & "<TR BGCOLOR=FFFFFF>" & vbCrLf
                        strOutMsg = strOutMsg & "<TD WIDTH=30>&nbsp;</TD>" & vbCrLf
                        strOutMsg = strOutMsg & "<TD WIDTH=150>&nbsp;</TD>" & vbCrLf
                        strOutMsg = strOutMsg & "<TD WIDTH=730 ALIGN=Left><B>&nbsp;" & collectReport.Item("<$TOTALSUM$>") & "</TD>" & vbCrLf
                        strOutMsg = strOutMsg & "<TD WIDTH=30>&nbsp;</TD>" & vbCrLf
                        strOutMsg = strOutMsg & "<TD WIDTH=130>&nbsp;</TD>" & vbCrLf
                        strOutMsg = strOutMsg & "<TD WIDTH=30>&nbsp;</TD>" & vbCrLf
                        strOutMsg = strOutMsg & "<TD WIDTH=30 ALIGN=Left><B>&nbsp;" & lngSumTotalItems & "</TD>" & vbCrLf
                        strOutMsg = strOutMsg & "<TD WIDTH=50>&nbsp;</TD>" & vbCrLf
                        If lngSumTotalPrice > 0 Then
                            strOutMsg = strOutMsg & "<TD WIDTH=50 ALIGN=Left><B>&nbsp;" & lngSumTotalPrice & "</TD>" & vbCrLf
                        Else
                            strOutMsg = strOutMsg & "<TD WIDTH=50 ALIGN=Left><B>&nbsp;</TD>" & vbCrLf
                        End If
                        For lngi = 0 To tblLoc.Rows.Count - 1
                            strOutMsg = strOutMsg & "<TD WIDTH=40 ALIGN=Left>&nbsp;" & arrSumOnLoc(lngi) & "</TD>" & vbCrLf
                        Next
                        strOutMsg = strOutMsg & "</TR>" & vbCrLf
                        strOutMsg = strOutMsg & "<TR bgcolor=#FFFFFF HEIGHT=60>" & vbCrLf
                        strOutMsg = strOutMsg & "<TD WIDTH=30>&nbsp;</TD><TD WIDTH=150>&nbsp;</TD>" & vbCrLf
                        strOutMsg = strOutMsg & "<TD WIDTH=750 ALIGN=Left><B>&nbsp;" & collectReport.Item("<$ACCEPTEDSIGN$>") & "</TD>" & vbCrLf
                        strOutMsg = strOutMsg & "<TD WIDTH=30>&nbsp;</TD><TD WIDTH=30>&nbsp;</TD><TD WIDTH=30>&nbsp;</TD><TD WIDTH=30>&nbsp;</TD><TD WIDTH=50>&nbsp;</TD><TD WIDTH=50>&nbsp;</TD>" & vbCrLf
                        For lngi = 0 To tblLoc.Rows.Count - 1
                            strOutMsg = strOutMsg & "<TD WIDTH=40>&nbsp;</TD>" & vbCrLf
                        Next
                        strOutMsg = strOutMsg & "</TR>" & vbCrLf
                        strOutMsg = strOutMsg & "</TABLE>" & vbCrLf
                    End If
                End If
                GenComprehReportBook = strOutMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                'If Not objUtf8 Is Nothing Then
                '    objUtf8 = Nothing
                'End If
            End Try
        End Function

        ' Purpose: sort Acqusition Data
        ' In:  object sort, title sort, derection sort ( 1: desc, 0: asc )
        ' Creator:  Sondp
        Public Sub SortData(ByVal objSort As Object, ByVal objTitle As Object, Optional ByVal intDirectionsort As Integer = 1)
            'Sap xep
            'B1
            'PhuongTT -  2014.11.19
            Dim sortDic As New SortedDictionary(Of Object, Object)
            Dim strKey As Object = ""
            Dim intValue As Object = 0
            Dim inti As Integer
            For inti = 0 To UBound(objSort)
                Try
                    strKey = ""
                    If Not IsDBNull(objTitle(inti)) Then
                        strKey = Trim(objTitle(inti))
                    Else
                        'Neu gia tri rong thi sap xep nam o cuoi cung
                        strKey &= "z"
                    End If
                    strKey &= objSort(inti)
                    intValue = objSort(inti)
                    sortDic.Add(strKey, intValue)
                Catch ex As Exception
                    'pass duplicate record
                End Try
            Next
            inti = 0
            For Each kvp As KeyValuePair(Of Object, Object) In sortDic
                ReDim Preserve objSort(inti)
                objSort(inti) = kvp.Value
                inti += 1
            Next
            'Dim objUtf8 As New TVCOMLib.utf8
            'Dim inti As Integer
            'Try
            '    objUtf8.SortBy(objSort, objTitle, 1)
            '    If intDirectionsort = 1 Then  ' Descreate
            '        Dim asize(UBound(objSort)) As String
            '        Dim strTemp As String = ""
            '        For inti = 0 To CInt((UBound(asize) + 1) / 2)
            '            strTemp = CStr(objSort(inti))
            '            objSort(inti) = asize(inti)
            '            asize(inti) = strTemp
            '        Next
            '    End If
            'Catch ex As Exception
            '    strerrormsg = ex.Message
            'Finally
            '    If Not objUtf8 Is Nothing Then
            '        objUtf8 = Nothing
            '    End If
            'End Try
        End Sub

        ' Purpose: Format date
        ' In: strValue
        ' Out: string
        ' Creator: Sondp
        Function FormatDate(ByVal val As String) As String
            If Not IsDate(val) Then
                FormatDate = ""
                Exit Function
            End If
            Dim Days, Months, Years, i
            If val <> "" Then
                i = InStr(val, "/")
                Days = Left(val, i - 1)
                val = Right(val, Len(val) - i)
                i = InStr(val, "/")
                Months = Left(val, i - 1)
                val = Right(val, Len(val) - i)
                Years = val
                FormatDate = Months & "/" & Days & "/" & Years
            Else
                FormatDate = ""
            End If
        End Function

        '----------------------------------------------------------------------------------------------
        ' Purpose: Generate SQL to print Acqusition report
        ' In:  Some informations
        ' Out:  string
        ' Creator:  Sondp
        '----------------------------------------------------------------------------------------------
        Public Function FormmingAcqSQL() As String
            Dim sbSql As New StringBuilder(4096)
            Dim sbSelect As New StringBuilder(1024)
            Dim sbJoin As New StringBuilder(2048)
            Dim sbWhere As New StringBuilder(1024)
            Dim sbOrder As New StringBuilder(256)
            Dim boolCheck As Boolean = False
            sbSelect.Append(" SELECT H.ID ")
            sbJoin.Append(" FROM Lib_tblHolding H ")
            sbWhere.Append(" WHERE 1=1 ")

            'Filter by Item Type and Cataloguer
            If ItemTypeID > 0 AndAlso Cataloguer <> "" Then
                sbJoin.AppendFormat(" JOIN Lib_tblItem I ON H.ItemID=I.ID AND I.TypeID={0} AND Cataloguer LIKE N'%{1}%' ", ItemTypeID, Cataloguer)
                boolCheck = True
            ElseIf ItemTypeID > 0 Then
                sbJoin.AppendFormat(" JOIN Lib_tblItem I ON H.ItemID=I.ID AND I.TypeID={0} ", ItemTypeID)
                boolCheck = True
            ElseIf Cataloguer <> "" Then
                sbJoin.AppendFormat(" JOIN Lib_tblItem I ON H.ItemID=I.ID AND Cataloguer LIKE N'%{0}%' ", Cataloguer)
                boolCheck = True
            End If

            If Faculty > 0 Then
                sbJoin.AppendFormat(" JOIN Lib_tblField900S F900S ON F900S.ItemID=H.ItemID AND F900S.Content LIKE CONCAT(N'%',(SELECT Faculty FROM Cir_tblDicFaculty WHERE ID={0}),N'%') ", Faculty)
                boolCheck = True
            End If

            'Filter by Language
            If LanguageID > 0 Then
                sbJoin.AppendFormat(" JOIN Lib_tblItemLanguage L ON L.ItemID=H.ItemID AND L.LanguageID={0} ", LanguageID)
                boolCheck = True
            End If

            'Filter by Acquisition Source
            If AcqSourceID > 0 Then
                sbWhere.AppendFormat(" AND H.AcquiredSourceID={0} ", AcqSourceID)
                boolCheck = True
            End If

            'Filter by purchase order code
            If PONumber <> "" Then
                sbJoin.AppendFormat(" JOIN Acq_tblPO_Item AI ON AI.ItemID=H.ItemID AND AI.POID IN(SELECT ID FROM Acq_tblPO WHERE ReceiptNo LIKE N'%{0}%') ", PONumber)
                boolCheck = True
            End If

            'Filter by Keyword
            If Keyword <> "" Then
                sbJoin.AppendFormat(" JOIN Lib_tblItemKeyword IK ON IK.ItemID=H.ItemID AND IK.KeywordID IN(SELECT ID FROM Cat_tblDicKeyword WHERE AccessEntry LIKE N'%{0}%') ", Keyword)
                boolCheck = True
            End If

            'Filter by DDC(Môn loại)
            If DDC <> "" Then
                Select Case DDC
                    Case "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
                        sbJoin.AppendFormat(" JOIN Lib_tblItemDDC DI ON DI.ItemID=H.ItemID AND DI.DDCID IN(SELECT ID FROM Cat_tblDic_ClassDDC WHERE AccessEntry LIKE N'{0}__ %') ", DDC)
                        boolCheck = True
                End Select

            End If

            'Filter by SH(Tiêu đề đề mục)
            If Sh <> "" Then
                sbJoin.AppendFormat(" JOIN Lib_tblItemSH ISH ON ISH.ItemID=H.ItemID AND ISH.SHID IN(SELECT ID FROM Cat_tblDicSH WHERE AccessEntry LIKE N'%{0}%') ", Sh)
                boolCheck = True
            End If

            'Filter by LocationID
            If intStoreID > 0 Then
                sbWhere.AppendFormat(" AND H.LocationID ={0} ", intStoreID)
                boolCheck = True
            End If

            'Filter by LibID
            If intLibID > 0 Then
                sbWhere.AppendFormat(" AND H.LibID={0} ", intLibID)
                boolCheck = True
            End If

            ' Filter copynumber from
            If Not strFromDKCB & "" = "" Then
                sbWhere.AppendFormat(" AND H.CopyNumber>='{0}' AND LEN(H.CopyNumber)>={1} ", strFromDKCB, Len(strFromDKCB))
                boolCheck = True
            End If

            'Filter copynumber to
            If Not strToDKCB & "" = "" Then
                sbWhere.AppendFormat(" AND H.CopyNumber<='{0}' ", strToDKCB)
                boolCheck = True
            End If

            If Not strFromTime & "" = "" And Not strToTime & "" = "" Then
                If strFromTime = strToTime Then
                    ' From Acquisition Date
                    If Not strFromTime & "" = "" Then
                        sbWhere.AppendFormat(" AND CONVERT(VARCHAR,H.AcquiredDate,103) >='{0}' ", strFromTime)
                        boolCheck = True
                    End If
                    ' To Acquisition Date
                    If Not strToTime & "" = "" Then
                        sbWhere.AppendFormat(" AND CONVERT(VARCHAR,H.AcquiredDate,103)<='{0}' ", strFromTime)
                        boolCheck = True
                    End If
                Else
                    ' From Acquisition Date
                    If Not strFromTime & "" = "" Then
                        sbWhere.AppendFormat(" AND H.AcquiredDate>=CONVERT(DATETIME,'{0}',103) ", strFromTime)
                        boolCheck = True
                    End If
                    ' To Acquisition Date
                    If Not strToTime & "" = "" Then
                        sbWhere.AppendFormat(" AND H.AcquiredDate<=CONVERT(DATETIME,'{0}',103) ", strToTime)
                        boolCheck = True
                    End If
                End If
            Else
                ' From Acquisition Date
                If Not strFromTime & "" = "" Then
                    sbWhere.AppendFormat(" AND H.AcquiredDate>=CONVERT(DATETIME,'{0}',103) ", strFromTime)
                    boolCheck = True
                End If
                ' To Acquisition Date
                If Not strToTime & "" = "" Then
                    sbWhere.AppendFormat(" AND H.AcquiredDate<=CONVERT(DATETIME,'{0}',103) ", strToTime)
                    boolCheck = True
                End If
            End If

            Select Case intOrder
                Case 1 ' Order by title will select add data
                    sbSelect.Append(", F200s.Content, F200s.Ind1, F200s.Ind2 ")
                    sbJoin.Append(" JOIN Lib_tblField200S F200s ON F200s.ItemID=H.ItemID AND F200s.FieldCode=(SELECT FieldCode FROM Lib_tblMARCBibField WHERE ID=448) ")
                    boolCheck = True
                Case 0 ' Acquisition Date
                    Select Case intBy
                        Case 0 ' Asc
                            sbOrder.Append(" ORDER BY H.AcquiredDate ASC ")
                        Case Else ' Desc
                            sbOrder.Append(" ORDER BY H.AcquiredDate DESC ")
                    End Select
                Case 2 ' CopyNumber
                    Select Case intBy
                        Case 0 ' ASC
                            sbOrder.Append(" ORDER BY H.CopyNumber ASC ")
                        Case Else ' DESC
                            sbOrder.Append(" ORDER BY H.CopyNumber DESC ")
                    End Select
            End Select
            ' Return SQL Command
            If boolCheck = True Then
                strSQL = sbSql.Append(sbSelect.ToString()).Append(sbJoin.ToString()).Append(sbWhere.ToString()).Append(sbOrder.ToString()).ToString()
            Else
                Select Case intOrder
                    Case 1 ' Title
                        strSQL = "SELECT TOP 1000 H.ID, F200s.Content, F200s.Ind1, F200s.Ind2 FROM Lib_tblHolding H, Lib_tblField200S F200s WHERE H.ItemID=F200s.ItemID "
                    Case 0 ' Acquisition date
                        Select Case intBy
                            Case 0 ' ASC
                                strSQL = "SELECT TOP 1000 ID, AcquiredDate FROM Lib_tblHolding ORDER BY AcquiredDate ASC "
                            Case Else ' DESC
                                strSQL = "SELECT TOP 1000 ID, AcquiredDate FROM Lib_tblHolding ORDER BY AcquiredDate DESC "
                        End Select
                    Case Else ' CopyNumber
                        Select Case intBy
                            Case 0 ' ASC
                                strSQL = "SELECT TOP 1000 ID, CopyNumber FROM Lib_tblHolding ORDER BY CopyNumber ASC "
                            Case Else ' DESC
                                strSQL = "SELECT TOP 1000 ID, CopyNumber FROM Lib_tblHolding ORDER BY CopyNumber DESC "
                        End Select
                End Select
            End If

            Return strSQL
        End Function

        ' Purpose: Forming CopyNumber Removed SQL command
        ' In: Some infor
        ' Out: string
        ' Creator:  Sondp
        Public Function FormingCopyNumRemSQL() As String
            Dim strSelectedFields, strTabs, strJoinSQL, strSQL As String
            Dim boolCheck As Boolean
            boolCheck = False
            Try
                strSelectedFields = " R.ID"
                strJoinSQL = " 1=1"
                strTabs = " HOLDING_REMOVED R"
                If intOrder = 2 Then ' Order by Title will add information
                    strSelectedFields = strSelectedFields & ", F200s.Content, F200s.Ind1,F200s.Ind2"
                    strTabs = strTabs & ", Lib_tblField200S F200s"
                    strJoinSQL = strJoinSQL & " AND F200s.ItemID = R.ItemID AND F200s.FieldCode = '245'"
                Else
                    strSelectedFields = strSelectedFields & ",'' AS Content"
                End If
                ' Get LiquidCode
                If strLiquidCode <> "" Then
                    If InStr(strLiquidCode, "%") > 0 Then
                        If strDBServer.ToUpper = "ORACE" Then
                            strJoinSQL = strJoinSQL & " AND R.LiquidCode Like '%" & strLiquidCode & "%'"
                        Else
                            strJoinSQL = strJoinSQL & " AND R.LiquidCode Like '%" & strLiquidCode & "%'"
                        End If
                    Else
                        If strDBServer.ToUpper = "ORACE" Then
                            strJoinSQL = strJoinSQL & " AND R.LiquidCode = '" & strLiquidCode & "'"
                        Else
                            strJoinSQL = strJoinSQL & " AND R.LiquidCode = '" & strLiquidCode & "'"
                        End If
                    End If
                    boolCheck = True
                End If
                ' Get Location
                If intStoreID > 0 Then
                    strJoinSQL = strJoinSQL & " AND R.LocationID = " & StoreID
                    boolCheck = True
                End If
                ' Get Library
                If intLibID > 0 Then
                    strJoinSQL = strJoinSQL & " AND R.LibID = " & LibID
                    boolCheck = True
                End If

                If Not strFromTime & "" = "" And Not strToTime & "" = "" Then
                    If strFromTime = strToTime Then
                        ' From Acquisition Date
                        If Not strFromTime & "" = "" Then
                            If Not UCase(strDBServer) = "ORACLE" Then
                                strJoinSQL &= " AND CONVERT(VARCHAR,R.RemovedDate,103) >='" & strFromTime & "'"
                            Else
                                strJoinSQL &= " AND TO_CHAR(R.RemovedDate,'dd/mm/yyyy') >='" & strFromTime & "'"
                            End If
                            boolCheck = True
                        End If
                        ' To Acquisition Date
                        If Not strToTime & "" = "" Then
                            If Not UCase(strDBServer) = "ORACLE" Then
                                strJoinSQL &= " AND CONVERT(VARCHAR,R.RemovedDate,103)<='" & strFromTime & "'"
                            Else
                                strJoinSQL &= " AND TO_CHAR(R.RemovedDate,'dd/mm/yyyy') <='" & strFromTime & "'"
                            End If
                            boolCheck = True
                        End If
                    Else
                        ' From Acquisition date
                        If Not strFromTime & "" = "" Then
                            If Not strDBServer = "ORACLE" Then
                                strJoinSQL = strJoinSQL & " AND R.RemovedDate >= CONVERT(DATETIME, '" & strFromTime & "', 103)"
                            Else
                                strJoinSQL = strJoinSQL & " AND R.RemovedDate >= To_Date('" & strFromTime & "', 'dd/mm/yyyy')"
                            End If
                            boolCheck = True
                        End If
                        ' To Acquisition date
                        If Not strToTime & "" = "" Then
                            If Not strDBServer = "ORACLE" Then
                                strJoinSQL = strJoinSQL & " AND R.RemovedDate <= CONVERT(DATETIME, '" & strToTime & "', 103)"
                            Else
                                strJoinSQL = strJoinSQL & " AND R.RemovedDate <= To_Date('" & strToTime & "', 'dd/mm/yyyy')"
                            End If
                            boolCheck = True
                        End If
                    End If
                Else
                    ' From Acquisition date
                    If Not strFromTime & "" = "" Then
                        If Not strDBServer = "ORACLE" Then
                            strJoinSQL = strJoinSQL & " AND R.RemovedDate >= CONVERT(DATETIME, '" & strFromTime & "', 103)"
                        Else
                            strJoinSQL = strJoinSQL & " AND R.RemovedDate >= To_Date('" & strFromTime & "', 'dd/mm/yyyy')"
                        End If
                        boolCheck = True
                    End If
                    ' To Acquisition date
                    If Not strToTime & "" = "" Then
                        If Not strDBServer = "ORACLE" Then
                            strJoinSQL = strJoinSQL & " AND R.RemovedDate <= CONVERT(DATETIME, '" & strToTime & "', 103)"
                        Else
                            strJoinSQL = strJoinSQL & " AND R.RemovedDate <= To_Date('" & strToTime & "', 'dd/mm/yyyy')"
                        End If
                        boolCheck = True
                    End If
                End If

                ' Forming SQL command
                strSQL = "SELECT " & strSelectedFields & " FROM " & strTabs & " WHERE " & strJoinSQL
                ' Sort by
                Select Case intOrder
                    Case 1 ' Order by removed date
                        strSQL = strSQL & " ORDER BY R.RemovedDate"
                        If intBy = 1 Then ' DESC
                            strSQL = strSQL & " DESC"
                        End If
                    Case 2 ' Order by CopyNumber
                        strSQL = strSQL & " ORDER BY R.CopyNumber"
                        If By = 1 Then 'theo chieu giam dan
                            strSQL = strSQL & " DESC"
                        End If
                    Case Else
                End Select
                If boolCheck = False Then ' Default select 1000 records
                    If intOrder = 1 Then ' Order by removeddate
                        If Not strDBServer = "ORACLE" Then
                            strSQL = "SELECT TOP 1000 R.ID,F200s.Content,F200s.Ind1,F200s.Ind2 FROM HOLDING_REMOVED R,Lib_tblField200S F200s WHERE F200s.FieldCode='245' AND F200s.ItemID=R.ItemID ORDER BY R.RemovedDate"
                        Else
                            strSQL = "SELECT R.ID,F200s.Content,F200s.Ind1,F200s.Ind2 FROM HOLDING_REMOVED R, Lib_tblField200S F200s WHERE RowNum<=1000 AND F200s.FieldCode='245' AND F200s.ItemID=R.ItemID ORBER BY R.RemovedDate DESC"
                        End If
                    Else
                        If Not strDBServer = "ORACLE" Then
                            strSQL = "SELECT TOP 1000 ID FROM HOLDING_REMOVED ORDER BY RemovedDate DESC"
                        Else
                            strSQL = "SELECT ID FROM HOLDING_REMOVED WHERE RowNum<=1000 ORDER BY RemovedDate DESC"
                        End If
                    End If
                End If
                ' Return value
                FormingCopyNumRemSQL = strSQL
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose: Select ItemID for print label
        ' In: Some infor
        ' Out: Datatable
        'Modify : Phuong 20080820 --> Them Orderby sap xep theo kho & ma xep gia
        Public Function GetIDsItemIDs(ByVal intSelMode As Integer, ByVal intLibID As Integer, ByVal intLocID As Integer, ByVal strFromItemCode As String, ByVal strToItemCode As String, ByVal strFromCopyNumber As String, ByVal strToCopyNumber As String, ByVal strElse As String, ByVal intItemType As Integer, Optional ByVal Orderby As Boolean = False) As DataTable
            Dim arrValueFields() As String
            Dim arrTextFields() As String
            Dim arrBoolFields() As String
            Dim intk As Integer
            Dim strWhere, strSQLSearch As String
            GetIDsItemIDs = Nothing
            Select Case intSelMode
                Case 0 ' Select by ItemCode mode
                    ' Library
                    If intLibID > 0 Then
                        ReDim Preserve arrValueFields(intk)
                        ReDim Preserve arrTextFields(intk)
                        ReDim Preserve arrBoolFields(intk)
                        arrValueFields(intk) = intLibID
                        arrTextFields(intk) = "LIBID"
                        arrBoolFields(intk) = "AND"
                        intk = intk + 1
                    End If
                    ' Location
                    If intLocID > 0 Then
                        ReDim Preserve arrValueFields(intk)
                        ReDim Preserve arrTextFields(intk)
                        ReDim Preserve arrBoolFields(intk)
                        arrValueFields(intk) = intLocID
                        arrTextFields(intk) = "LOCID"
                        arrBoolFields(intk) = "AND"
                        intk = intk + 1
                    End If
                    ' ItemType
                    If intItemType > 0 Then
                        ReDim Preserve arrValueFields(intk)
                        ReDim Preserve arrTextFields(intk)
                        ReDim Preserve arrBoolFields(intk)
                        arrValueFields(intk) = intItemType
                        arrTextFields(intk) = "ITEMTYPE"
                        arrBoolFields(intk) = "AND"
                        intk = intk + 1
                    End If
                    ' From ItemCode
                    If strFromItemCode <> "" Then
                        ReDim Preserve arrValueFields(intk)
                        ReDim Preserve arrTextFields(intk)
                        ReDim Preserve arrBoolFields(intk)
                        arrValueFields(intk) = strFromItemCode
                        arrTextFields(intk) = "FROMIC"
                        arrBoolFields(intk) = "AND"
                        intk = intk + 1
                    End If
                    ' To ItemCode
                    If strToItemCode <> "" Then
                        ReDim Preserve arrValueFields(intk)
                        ReDim Preserve arrTextFields(intk)
                        ReDim Preserve arrBoolFields(intk)
                        arrValueFields(intk) = strToItemCode
                        arrTextFields(intk) = "TOIC"
                        arrBoolFields(intk) = "AND"
                        intk = intk + 1
                    End If
                    objBFSQL.ValArr = arrValueFields
                    objBFSQL.FieldArr = arrTextFields
                    objBFSQL.BoolArr = arrBoolFields
                    ' Forming select SQL and return data
                    strSQLSearch = objBFSQL.FormingASQL()
                    Dim strSQLA As String
                    strSQLA = "SELECT ID, ItemID FROM Lib_tblHolding WHERE ItemID IN(" & strSQLSearch & ")"
                    If intLibID > 0 Then
                        strSQLA = strSQLA & " AND LibID=" & intLibID
                    End If
                    If intLocID > 0 Then
                        strSQLA = strSQLA & " AND LocationID=" & intLocID
                    End If
                    If Not strSQLSearch = "" Then
                        'objBCDBS.SQLStatement = "SELECT ID, ItemID FROM Lib_tblHolding WHERE ItemID IN(" & strSQLSearch & ") ORDER BY ItemID"
                        If Orderby Then
                            objBCDBS.SQLStatement = strSQLA & " ORDER BY LOCATIONID, DBO.FULLSTRING(COPYNUMBER,'/')"
                        Else
                            objBCDBS.SQLStatement = strSQLA & " ORDER BY ItemID"
                        End If
                        GetIDsItemIDs = objBCDBS.RetrieveItemInfor
                    End If
                Case 1 ' Select by CopyNumber mode
                    strWhere = " 1=1"
                    ' Select Library
                    If intLibID > 0 Then
                        strWhere = strWhere & " AND LibID=" & intLibID
                    End If
                    ' Select Location
                    If intLocID > 0 Then
                        strWhere = strWhere & " AND LocationID=" & intLocID
                    End If
                    ' Select ItemType
                    If intItemType > 0 Then
                        strWhere = strWhere & " AND ItemID IN(SELECT I.ID FROM Lib_tblItem I, Cat_tblDic_ItemType C WHERE I.TypeID=C.ID AND C.ID=" & intItemType & ")"
                    End If
                    ' From CopyNumber
                    If strFromCopyNumber <> "" Then
                        strWhere = strWhere & " AND CopyNumber>='" & strFromCopyNumber & "'"
                    End If
                    ' To CopyNumber
                    If strToCopyNumber <> "" Then
                        strWhere = strWhere & " AND CopyNumber<='" & strToCopyNumber & "'"
                    End If
                    ' Forming select SQL and return data
                    If strWhere.Length > 4 Then
                        objBCDBS.SQLStatement = "SELECT ID, ItemID FROM Lib_tblHolding WHERE" & strWhere & " ORDER BY  LOCATIONID, DBO.FULLSTRING(COPYNUMBER,'/')"
                    Else
                        Select Case UCase(strDBServer)
                            Case "ORACLE"
                                objBCDBS.SQLStatement = "SELECT ID, ItemID FROM Lib_tblHolding WHERE ROWNUM<=1000 ORDER BY ItemID"
                            Case Else
                                If Orderby Then
                                    objBCDBS.SQLStatement = "SELECT TOP 1000 ID, ItemID FROM Lib_tblHolding ORDER BY LOCATIONID, DBO.FULLSTRING(COPYNUMBER,'/')"
                                Else
                                    objBCDBS.SQLStatement = "SELECT TOP 1000 ID, ItemID FROM Lib_tblHolding ORDER BY ItemID"
                                End If
                        End Select
                    End If
                    GetIDsItemIDs = objBCDBS.RetrieveItemInfor
                Case Else ' Select by input data mode
                    strWhere = " 1=1"
                    ' Select Library
                    If intLibID > 0 Then
                        strWhere = strWhere & " AND LibID=" & intLibID
                    End If
                    ' Select Location
                    If intLocID > 0 Then
                        strWhere = strWhere & " AND LocationID=" & intLocID
                    End If
                    ' Select ItemType
                    If intItemType > 0 Then
                        strWhere = strWhere & " AND ItemID IN (SELECT I.ID FROM Lib_tblItem I, Cat_tblDic_ItemType C WHERE I.TypeID=C.ID AND C.ID=" & intItemType & ")"
                    End If
                    ' Forming select SQL and return data
                    If strElse <> "" Then
                        objBCDBS.SQLStatement = "SELECT ID, ItemID FROM Lib_tblHolding WHERE CopyNumber IN(" & SplitCopyNumber(strElse, ";") & ") AND" & strWhere & " ORDER BY  LOCATIONID, DBO.FULLSTRING(COPYNUMBER,'/')"
                    Else
                        Select Case UCase(strDBServer)
                            Case "ORACLE"
                                objBCDBS.SQLStatement = "SELECT ID, ItemID FROM Lib_tblHolding WHERE" & strWhere & " AND ROWNUM<=1000 ORDER BY ItemID"
                            Case Else
                                If Orderby Then
                                    objBCDBS.SQLStatement = "SELECT TOP 1000 ID, ItemID FROM Lib_tblHolding WHERE" & strWhere & " ORDER BY LOCATIONID, DBO.FULLSTRING(COPYNUMBER,'/')"
                                Else
                                    objBCDBS.SQLStatement = "SELECT TOP 1000 ID, ItemID FROM Lib_tblHolding WHERE" & strWhere & " ORDER BY ItemID"
                                End If
                        End Select
                    End If
                    GetIDsItemIDs = objBCDBS.RetrieveItemInfor
            End Select
        End Function

        ' Purpose: Get ID from Lib_tblHolding for BarCode print
        ' In: Some infor
        ' Out: Datable
        Public Function GetIDforBarCode(ByVal intSelMode As Integer, ByVal intLibID As Integer, ByVal intLocID As Integer, ByVal strFromItemCode As String, ByVal strToItemCode As String, ByVal strFromCopyNumber As String, ByVal strToCopyNumber As String, Optional ByVal strFromDate As String = "", Optional ByVal strToDate As String = "") As DataTable
            Dim arrValueFields() As String
            Dim arrTextFields() As String
            Dim arrBoolFields() As String
            Dim strWhere As String
            Dim intk As Integer
            Dim strSQL As String = ""
            intk = 0
            GetIDforBarCode = Nothing
            Select Case intSelMode
                Case 0 ' Select by ItemCode
                    If intLibID > 0 Then
                        ReDim Preserve arrValueFields(intk)
                        ReDim Preserve arrTextFields(intk)
                        ReDim Preserve arrBoolFields(intk)
                        arrValueFields(intk) = intLibID
                        arrTextFields(intk) = "LIBID"
                        arrBoolFields(intk) = "AND"
                        intk = intk + 1
                    End If
                    If intLocID > 0 Then
                        ReDim Preserve arrValueFields(intk)
                        ReDim Preserve arrTextFields(intk)
                        ReDim Preserve arrBoolFields(intk)
                        arrValueFields(intk) = intLocID
                        arrTextFields(intk) = "LOCID"
                        arrBoolFields(intk) = "AND"
                        intk = intk + 1
                    End If
                    If strFromItemCode <> "" Then
                        ReDim Preserve arrValueFields(intk)
                        ReDim Preserve arrTextFields(intk)
                        ReDim Preserve arrBoolFields(intk)
                        arrValueFields(intk) = strFromItemCode
                        arrTextFields(intk) = "FROMIC"
                        arrBoolFields(intk) = "AND"
                        intk = intk + 1
                    End If
                    If strToItemCode <> "" Then
                        ReDim Preserve arrValueFields(intk)
                        ReDim Preserve arrTextFields(intk)
                        ReDim Preserve arrBoolFields(intk)
                        arrValueFields(intk) = strToItemCode
                        arrTextFields(intk) = "TOIC"
                        arrBoolFields(intk) = "AND"
                        intk = intk + 1
                    End If
                    If strFromDate <> "" Then
                        ReDim Preserve arrValueFields(intk)
                        ReDim Preserve arrTextFields(intk)
                        ReDim Preserve arrBoolFields(intk)
                        arrValueFields(intk) = strFromDate
                        arrTextFields(intk) = "FROMDTE"
                        arrBoolFields(intk) = "AND"
                        intk = intk + 1
                    End If
                    If strToDate <> "" Then
                        ReDim Preserve arrValueFields(intk)
                        ReDim Preserve arrTextFields(intk)
                        ReDim Preserve arrBoolFields(intk)
                        arrValueFields(intk) = strToDate
                        arrTextFields(intk) = "TODTE"
                        arrBoolFields(intk) = "AND"
                        intk = intk + 1
                    End If
                    ' Forming select SQL and return data
                    objBFSQL.ValArr = arrValueFields
                    objBFSQL.FieldArr = arrTextFields
                    objBFSQL.BoolArr = arrBoolFields
                    strSQL = objBFSQL.FormingASQL
                    If strSQL = "" Then
                        Select Case UCase(strDBServer)
                            Case "ORACLE"
                                objBCDBS.SQLStatement = "SELECT ID FROM Lib_tblHolding WHERE ROWNUM<=1000 ORDER BY ID"
                            Case Else
                                objBCDBS.SQLStatement = "SELECT TOP 1000 ID FROM Lib_tblHolding ORDER BY DBO.FULLSTRING(COPYNUMBER,'/')"
                        End Select
                    Else
                        Dim strSQLA As String
                        strSQLA = "SELECT ID FROM Lib_tblHolding WHERE ItemID IN (" & strSQL & ")"
                        If intLibID > 0 Then
                            strSQLA = strSQLA & " AND ( LibID=" & intLibID & "or " & intLibID & " = 0 ) "
                        End If
                        If intLocID > 0 Then
                            strSQLA = strSQLA & " AND LocationID=" & intLocID
                        End If
                        objBCDBS.SQLStatement = strSQLA & " ORDER BY  DBO.FULLSTRING(COPYNUMBER,'/')"
                        'objBCDBS.SQLStatement = "SELECT ID FROM Lib_tblHolding WHERE ItemID IN (" & strSQL & ") ORDER BY ID"
                    End If
                    GetIDforBarCode = objBCDBS.RetrieveItemInfor
                Case 1 ' Select by CopyNumber
                    strWhere = " 1=1"
                    If intLibID > 0 Then
                        strWhere = strWhere & " AND ( LibID=" & intLibID & "or " & intLibID & " = 0 ) "
                    End If
                    If intLocID > 0 Then
                        strWhere = strWhere & " AND LocationID=" & intLocID
                    End If
                    If strFromCopyNumber <> "" Then
                        strWhere = strWhere & " AND UPPER(CopyNumber)>='" & strFromCopyNumber & "'"
                    End If
                    If strToCopyNumber <> "" Then
                        strWhere = strWhere & " AND UPPER(CopyNumber)<='" & strToCopyNumber & "'"
                    End If
                    ' Forimng select SQL and return data
                    If strWhere.Length > 4 Then
                        objBCDBS.SQLStatement = "SELECT ID FROM Lib_tblHolding WHERE" & strWhere & " ORDER BY DBO.FULLSTRING(COPYNUMBER,'/')"
                    Else
                        Select Case UCase(strDBServer)
                            Case "ORACLE"
                                objBCDBS.SQLStatement = "SELECT ID FROM Lib_tblHolding WHERE ROWNUM<=1000 ORDER BY ID"
                            Case Else
                                objBCDBS.SQLStatement = "SELECT TOP 1000 ID FROM Lib_tblHolding ORDER BY DBO.FULLSTRING(COPYNUMBER,'/')"
                        End Select
                    End If
                    GetIDforBarCode = objBCDBS.RetrieveItemInfor
                Case Else
                    GetIDforBarCode = Nothing
            End Select
        End Function

        ' Purpose: Delete some specifical char
        Private Function DeleteChars(ByVal Str As String) As String
            Str = Replace(Str, "/", "")
            Str = Replace(Str, ".", "")
            Str = Replace(Str, ",", "")
            Str = Replace(Str, ":", "")
            Str = Replace(Str, ";", "")
            Str = Replace(Str, "?", "")
            Str = Replace(Str, "!", "")
            Str = Replace(Str, "[", "")
            Str = Replace(Str, "]", "")
            Str = Replace(Str, """", "")
            Str = Replace(Str, "-", "")
            DeleteChars = Trim(Str)
        End Function

        ' Purpose: Pick each copynumber 
        ' In: strCopyNumber, strSplit
        ' Out: string
        Public Function SplitCopyNumber(ByVal strCopyNumber As String, ByVal strSplit As String, Optional ByVal boolCut As Boolean = False) As String
            Dim BarcodeNumb(0) As String
            Dim ParseError As Boolean = False
            Dim Range As String
            Dim tmmRange As String
            Dim aRange() As String
            Dim m As Integer
            Dim j As Integer
            Dim aRangeInRow() As String
            Dim tmpCommonCode As String
            Dim tmpSlashCode As String
            Dim SlashCode As String
            Dim FlageCode As String
            Dim StartCode As String
            Dim EndNumb As String
            Dim tmpRange As String
            Dim k As Integer
            Dim LenNumb As Integer
            Dim CommonCode As String
            Dim StartNumb As String
            Dim strPickCopyNumber As String
            Dim l As Integer
            Dim i As Integer
            Range = strCopyNumber
            tmpRange = Range
            Range = Range.Replace(strSplit, ",")
            aRange = Split(Range, vbCrLf)
            Range = ""
            m = 0
            Try
                For j = 0 To UBound(aRange)
                    Range = aRange(j)
                    If Not Range = "" Then
                        aRangeInRow = Split(Range, ",")
                        tmpCommonCode = ""
                        tmpSlashCode = ""
                        For k = 0 To UBound(aRangeInRow)
                            Range = aRangeInRow(k)
                            If InStr(Range, "-") > 0 Then
                                StartCode = Trim(Left(Range, InStrRev(Range, "-") - 1))
                                EndNumb = Trim(Right(Range, Len(Range) - InStrRev(Range, "-")))
                                If Len(EndNumb) > Len(StartCode) Then
                                    StartCode = StartCode.PadLeft(Len(StartCode) + Len(EndNumb) - Len(StartCode), " ")
                                End If
                                If Not IsNumeric(EndNumb) Then
                                    ParseError = 1
                                Else
                                    LenNumb = Len(EndNumb)
                                    If InStr(StartCode, "/") > 0 Then
                                        SlashCode = Trim(Right(StartCode, Len(StartCode) - InStrRev(StartCode, "/") + 1))
                                        StartCode = Trim(Left(StartCode, InStrRev(StartCode, "/") - 1))
                                    End If
                                    For l = 1 To Len(StartCode)
                                        If Not IsNumeric(Right(StartCode, l)) Then Exit For
                                    Next
                                    CommonCode = Left(StartCode, Len(StartCode) - l + 1)
                                    StartNumb = Trim(Right(StartCode, l - 1))
                                    If Not IsNumeric(StartNumb) Then
                                        ParseError = 1
                                    Else
                                        If Not Trim(CommonCode) = "" Then tmpCommonCode = CommonCode
                                        If Not Trim(SlashCode) = "" Then tmpSlashCode = SlashCode
                                        For i = CInt(StartNumb) To CInt(EndNumb)
                                            ReDim Preserve BarcodeNumb(m)
                                            If Len(StartNumb) > Len(CStr(i)) Then
                                                BarcodeNumb(m) = tmpCommonCode.PadRight(Len(tmpCommonCode) + Len(StartNumb) - Len(CStr(i)), "0") & i & tmpSlashCode
                                            Else
                                                BarcodeNumb(m) = tmpCommonCode & i & tmpSlashCode
                                            End If
                                            m = m + 1
                                        Next
                                    End If
                                End If
                            ElseIf Not Range = "" Then
                                If Not IsNumeric(Range) Then
                                    If InStr(Range, "/") > 0 Then
                                        tmpSlashCode = Trim(Right(Range, Len(Range) - InStrRev(Range, "/") + 1))
                                        StartCode = Trim(Left(Range, InStrRev(Range, "/") - 1))
                                    Else
                                        StartCode = Range
                                    End If
                                    For l = 1 To Len(StartCode)
                                        If Not IsNumeric(Right(StartCode, l)) Then Exit For
                                    Next
                                    tmpCommonCode = Left(StartCode, Len(StartCode) - l + 1)
                                Else
                                    Range = tmpCommonCode & Range & tmpSlashCode & " "
                                End If
                                ReDim Preserve BarcodeNumb(m)
                                BarcodeNumb(m) = Range
                                m = m + 1
                            End If
                        Next
                    End If
                Next
                Range = tmpRange
                tmpRange = ""
                If ParseError = 1 Then
                    ReDim BarcodeNumb(0)
                    BarcodeNumb(0) = Range
                End If
                For i = 0 To UBound(BarcodeNumb)
                    strPickCopyNumber &= "'" & BarcodeNumb(i) & "'" & ","
                Next
                If Not strPickCopyNumber = "" Then
                    strPickCopyNumber = Left(strPickCopyNumber, strPickCopyNumber.Length - 1)
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                If Not boolCut Then
                    SplitCopyNumber = strPickCopyNumber
                Else
                    SplitCopyNumber = strPickCopyNumber.Replace("'", "")
                End If
            End Try
        End Function


        Public Function GetNumberRowOfCopyNumber(strCopyNumber As String) As DataTable
            Try

                GetNumberRowOfCopyNumber = objBCDBS.ConvertTable(objDCopyNumber.GetNumberRowOfCopyNumber(strCopyNumber))
                intErrorCode = objDCopyNumber.ErrorCode
                strErrorMsg = objDCopyNumber.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        ' Release resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not objDT Is Nothing Then
                        objDT.Dispose(True)
                        objDT = Nothing
                    End If
                    If Not objBInput Is Nothing Then
                        objBInput.Dispose(True)
                        objBInput = Nothing
                    End If
                    If Not objBLoc Is Nothing Then
                        objBLoc.Dispose(True)
                        objBLoc = Nothing
                    End If
                    If Not objBFSQL Is Nothing Then
                        objBFSQL.Dispose(True)
                        objBFSQL = Nothing
                    End If
                    If Not objBCT Is Nothing Then
                        objBCT.Dispose(True)
                        objBCT = Nothing
                    End If
                    If Not objBCSP Is Nothing Then
                        objBCSP.Dispose(True)
                        objBCSP = Nothing
                    End If
                    If Not objBItem Is Nothing Then
                        objBItem.Dispose(True)
                        objBItem = Nothing
                    End If
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace