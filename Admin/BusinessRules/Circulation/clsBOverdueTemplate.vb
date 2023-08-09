' Name: clsBTemplate
' Purpose: allow working with Template
' Creator: Oanhtn
' CreatedDate: 16/08/2004
' Modification History:
'   + 20/8/2004: by Sondp: GenTemplate()

Imports System
Imports System.Data
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Circulation

Namespace eMicLibAdmin.BusinessRules.Circulation
    Public Class clsBOverdueTemplate
        Inherits clsBCommonTemplate

        ' *****************************************************************************************************
        ' Declare member variables
        ' *****************************************************************************************************

        Private colHeaderData As New Collection
        Private colContentData As New Collection
        Private colFooterData As New Collection

        Private strCollums As String
        Private strCollumCaption As String
        Private strCollumWidth As String
        Private strCollumAlign As String
        Private strCollumFormat As String
        Private strCollumFooter As String

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' HeaderData property
        Property HeaderData() As Collection
            Get
                Return colHeaderData
            End Get
            Set(ByVal Value As Collection)
                colHeaderData = Value
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

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************        

        ' GenOverdueData method
        ' Purpose: Get Overdue data from objLBTemplate
        ' Output: string value after generate
        Public Function GenOverdueData() As String
            '  Try

            ' Declare variables
            'Dim objLBTemplate As New TVCOMLib.LibolTemplate
            Dim bColLabel() As String
            Dim bUserColLabel() As String
            Dim bUserColWidth() As String
            Dim bCols() As String
            Dim bUserColAlign() As String 'for Align
            Dim bUserColFormat() As String 'for Format
            Dim strOutMsg As String = ""
            Dim objFields As Object
            Dim objStream As Object
            Dim objData As Object
            Dim intk As Integer
            Dim inti As Integer
            Dim intj As Integer
            Dim mw As String ' width collum
            Dim ma As String ' align collum
            Dim mf As String ' format collum
            Dim boomf As Boolean ' control format template

            'objLBTemplate.Template = objBCSP.ToUTF8(strHeader) & "@@@@@" & objBCSP.ToUTF8(strFooter)
            'objFields = objLBTemplate.Fields
            Dim strContentTemp As String = objBCSP.ToUTF8(strHeader) & "@@@@@" & objBCSP.ToUTF8(strFooter)
            objFields = Me.getArrayFromTemplate(strContentTemp)

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
                Select Case bCols(inti)
                    Case "<$ITEMCODE$>"
                        ReDim Preserve bColLabel(intk)
                        If UBound(bUserColLabel) >= inti Then
                            If Not Trim(bUserColLabel(inti)) = "" Then
                                bColLabel(intk) = bUserColLabel(inti)
                            Else
                                bColLabel(intk) = colContentData.Item("<$ITEMCODE$>")
                            End If
                        Else
                            bColLabel(intk) = colContentData.Item("<$ITEMCODE$>")
                        End If
                        intk += 1
                    Case "<$COPYNUMBER$>"
                        ReDim Preserve bColLabel(intk)
                        If UBound(bUserColLabel) >= inti Then
                            If Not Trim(bUserColLabel(inti)) = "" Then
                                bColLabel(intk) = bUserColLabel(inti)
                            Else
                                bColLabel(intk) = colContentData.Item("<$COPYNUMBER$>")
                            End If
                        Else
                            bColLabel(intk) = colContentData.Item("<$COPYNUMBER$>")
                        End If
                        intk += 1
                    Case "<$ITEMTITLE$>"
                        ReDim Preserve bColLabel(intk)
                        If UBound(bUserColLabel) >= inti Then
                            If Not Trim(bUserColLabel(inti)) = "" Then
                                bColLabel(intk) = bUserColLabel(inti)
                            Else
                                bColLabel(intk) = colContentData.Item("<$ITEMTITLE$>")
                            End If
                        Else
                            bColLabel(intk) = colContentData.Item("<$ITEMTITLE$>")
                        End If
                        intk += 1
                    Case "<$CHECKOUTDATE$>"
                        ReDim Preserve bColLabel(intk)
                        If UBound(bUserColLabel) >= inti Then
                            If Not Trim(bUserColLabel(inti)) = "" Then
                                bColLabel(intk) = bUserColLabel(inti)
                            Else
                                bColLabel(intk) = colContentData.Item("<$CHECKOUTDATE$>")
                            End If
                        Else
                            bColLabel(intk) = colContentData.Item("<$CHECKOUTDATE$>")
                        End If
                        intk += 1
                    Case "<$CHECKINDATE$>"
                        ReDim Preserve bColLabel(intk)
                        If UBound(bUserColLabel) >= inti Then
                            If Not Trim(bUserColLabel(inti)) = "" Then
                                bColLabel(intk) = bUserColLabel(inti)
                            Else
                                bColLabel(intk) = colContentData.Item("<$CHECKINDATE$>")
                            End If
                        Else
                            bColLabel(intk) = colContentData.Item("<$CHECKINDATE$>")
                        End If
                        intk += 1
                    Case "<$OVERDUEDATE$>"
                        ReDim Preserve bColLabel(intk)
                        If UBound(bUserColLabel) >= inti Then
                            If Not Trim(bUserColLabel(inti)) = "" Then
                                bColLabel(intk) = bUserColLabel(inti)
                            Else
                                bColLabel(intk) = colContentData.Item("<$OVERDUEDATE$>")
                            End If
                        Else
                            bColLabel(intk) = colContentData.Item("<$OVERDUEDATE$>")
                        End If
                        intk += 1
                    Case "<$PENATI$>"
                        ReDim Preserve bColLabel(intk)
                        If UBound(bUserColLabel) >= inti Then
                            If Not Trim(bUserColLabel(inti)) = "" Then
                                bColLabel(intk) = bUserColLabel(inti)
                            Else
                                bColLabel(intk) = colContentData.Item("<$PENATI$>")
                            End If
                        Else
                            bColLabel(intk) = colContentData.Item("<$PENATI$>")
                        End If
                        intk += 1
                    Case "<$SEQUENCY$>"
                        ReDim Preserve bColLabel(intk)
                        If UBound(bUserColLabel) >= inti Then
                            If Not Trim(bUserColLabel(inti)) = "" Then
                                bColLabel(intk) = bUserColLabel(inti)
                            Else
                                bColLabel(intk) = colContentData.Item("<$SEQUENCY$>")
                            End If
                        Else
                            bColLabel(intk) = colContentData.Item("<$SEQUENCY$>")
                        End If
                        intk += 1
                    Case "<$LIBRARY$>"
                        ReDim Preserve bColLabel(intk)
                        If UBound(bUserColLabel) >= inti Then
                            If Not Trim(bUserColLabel(inti)) = "" Then
                                bColLabel(intk) = bUserColLabel(inti)
                            Else
                                bColLabel(intk) = colContentData.Item("<$LIBRARY$>")
                            End If
                        Else
                            bColLabel(intk) = colContentData.Item("<$LIBRARY$>")
                        End If
                        intk += 1
                    Case "<$STORE$>"
                        ReDim Preserve bColLabel(intk)
                        If UBound(bUserColLabel) >= inti Then
                            If Not Trim(bUserColLabel(inti)) = "" Then
                                bColLabel(intk) = bUserColLabel(inti)
                            Else
                                bColLabel(intk) = colContentData.Item("<$STORE$>")
                            End If
                        Else
                            bColLabel(intk) = colContentData.Item("<$STORE$>")
                        End If
                        intk += 1
                    Case "<$NOTE$>"
                        ReDim Preserve bColLabel(intk)
                        If UBound(bUserColLabel) >= inti Then
                            If Not Trim(bUserColLabel(inti)) = "" Then
                                bColLabel(intk) = bUserColLabel(inti)
                            Else
                                bColLabel(intk) = colContentData.Item("<$NOTE$>")
                            End If
                        Else
                            bColLabel(intk) = colContentData.Item("<$NOTE$>")
                        End If
                        intk += 1
                    Case "<$LOANCOUNT$>"
                        ReDim Preserve bColLabel(intk)
                        If UBound(bUserColLabel) >= inti Then
                            If Not Trim(bUserColLabel(inti)) = "" Then
                                bColLabel(intk) = bUserColLabel(inti)
                            Else
                                bColLabel(intk) = colContentData.Item("<$LOANCOUNT$>")
                            End If
                        Else
                            bColLabel(intk) = colContentData.Item("<$LOANCOUNT$>")
                        End If
                        intk += 1
                End Select
            Next
            'for Header or Footer
            'ReDim objData(UBound(objLBTemplate.Fields))
            If Not IsNothing(objFields) AndAlso IsArray(objFields) Then
                ReDim objData(UBound(objFields))
                For inti = LBound(objFields) To UBound(objFields)
                    Select Case UCase(objFields(inti))
                        Case "CARDNUMBER"
                            objData(inti) = colHeaderData.Item("CARDNUMBER") & Chr(9)
                        Case "NAME"
                            objData(inti) = colHeaderData.Item("NAME") & Chr(9)
                        Case "DOB"
                            objData(inti) = colHeaderData.Item("DOB") & Chr(9)
                        Case "OCUPATION"
                            objData(inti) = colHeaderData.Item("OCUPATION") & Chr(9)
                        Case "WORKPLACE"
                            objData(inti) = colHeaderData.Item("WORKPLACE") & Chr(9)
                        Case "WORKADDRESS"
                            objData(inti) = colHeaderData.Item("WORKADDRESS") & Chr(9)
                        Case "HOMEADDRESS"
                            objData(inti) = colHeaderData.Item("HOMEADDRESS") & Chr(9)
                        Case "PHONE"
                            objData(inti) = colHeaderData.Item("PHONE") & Chr(9)
                        Case "FACULITY"
                            objData(inti) = colHeaderData.Item("FACULITY") & Chr(9)
                        Case "GRADE"
                            objData(inti) = colHeaderData.Item("GRADE") & Chr(9)
                        Case "CARDVALIDDATE"
                            objData(inti) = colHeaderData.Item("CARDVALIDDATE") & Chr(9)
                        Case "CARDEXPIREDDATE"
                            objData(inti) = colHeaderData.Item("CARDEXPIREDDATE") & Chr(9)
                        Case "EMAIL"
                            objData(inti) = colHeaderData.Item("EMAIL") & Chr(9)
                        Case "DATE"
                            objData(inti) = "1/4/2004" & Chr(9)
                        Case "LOANCOUNT"
                            objData(inti) = colHeaderData.Item("LOANCOUNT") & Chr(9)
                        Case Else
                            objData(inti) = " " & Chr(9)
                    End Select

                    strContentTemp = Replace(strContentTemp, "<$" & objFields(inti) & "$>", objData(inti))
                Next
            End If

            'Generete data for Header and Footer
            'objStream = objLBTemplate.Generate(objData)
            objStream = strContentTemp
            objStream.GetType.ToString.Replace(" ", "&nbsp;&nbsp;")
            'Generate String Template 
            strOutMsg = objBCSP.ToUTF8Back(Left(objStream, InStr(objStream, "@@@@@") - 1))
            strOutMsg = strOutMsg & "<TABLE WIDTH=100% BORDER=0 CELLSPACING=1  CELLPADDING=1 ><TR><TD><TABLE WIDTH=100% BORDER=0  CELLSPACING=1  CELLPADDING=3>"
            strOutMsg = strOutMsg & "<TR  BGCOLOR=#AACFEA class=""tb-header""> "
            'for table title
            If Not bColLabel Is Nothing Then
                For intj = 0 To UBound(bColLabel)
                    mw = ""
                    'Collum Width
                    If UBound(bUserColWidth) >= intj Then
                        If Not Trim(bUserColWidth(intj)) = "" Then
                            mw = " WIDTH=""" & Trim(bUserColWidth(intj)) & """"
                        End If
                    End If
                    ma = ""
                    'Collum Align
                    If UBound(bUserColAlign) >= intj Then
                        If Not Trim(bUserColAlign(intj)) = "" Then
                            ma = " ALIGN=""" & Trim(bUserColAlign(intj)) & """"
                        End If
                    End If
                    'Collum Format
                    boomf = False
                    If UBound(bUserColFormat) >= intj Then
                        If Not Trim(bUserColFormat(intj)) = "" Then
                            boomf = True
                        End If
                    End If
                    If mf <> "" Then
                        strOutMsg = strOutMsg & "<TD VALIGN=TOP " & mw & ma & " ALIGN=TOP BGCOLOR=FFFFFF>" & mf & "</TD>"
                    Else
                        strOutMsg = strOutMsg & "<TD ALIGN=""center"" VALIGN=TOP " & mw & ma & "  BGCOLOR=#AACFEA class=""tb-header"">" & bColLabel(intj) & "</TD>"
                    End If
                Next
            End If
            strOutMsg = strOutMsg & "</TR><TR  BGCOLOR=FFFFFF>"
            'for collum and row data
            For inti = 0 To UBound(bCols)
                'Width
                mw = ""
                If UBound(bUserColWidth) >= inti Then
                    If Not Trim(bUserColWidth(inti)) = "" Then
                        mw = " WIDTH=""" & Trim(bUserColWidth(inti)) & """"
                    End If
                End If
                'Align 
                ma = ""
                If UBound(bUserColAlign) >= inti Then
                    If Not Trim(bUserColAlign(inti)) = "" Then
                        ma = " ALIGN=""" & Trim(bUserColAlign(inti)) & """"
                    End If
                End If
                'Format
                mf = ""
                boomf = False 'default not have Format
                If UBound(bUserColFormat) >= inti Then
                    If Not Trim(bUserColFormat(inti)) = "" Then
                        boomf = True 'have Format
                    End If
                End If
                Select Case bCols(inti)
                    Case "<$ITEMCODE$>"
                        If boomf Then
                            strOutMsg = strOutMsg & "<TD  VALIGN=TOP " & mw & ma & "  BGCOLOR=FFFFFF>" & bUserColFormat(inti).Replace("<$DATA$>", colContentData.Item("<$ITEMCODEDATA$>")) & "</TD>"
                        Else
                            strOutMsg = strOutMsg & "<TD VALIGN=TOP " & mw & ma & " BGCOLOR=FFFFFF>" & colContentData.Item("<$ITEMCODEDATA$>") & "&nbsp;</TD>"
                        End If
                    Case "<$COPYNUMBER$>"
                        If boomf Then
                            strOutMsg = strOutMsg & "<TD  VALIGN=TOP " & mw & ma & " BGCOLOR=FFFFFF>" & bUserColFormat(inti).Replace("<$DATA$>", colContentData.Item("<$COPYNUMBERDATA$>")) & "</TD>"
                        Else
                            strOutMsg = strOutMsg & "<TD VALIGN=TOP " & mw & ma & " BGCOLOR=FFFFFF>" & colContentData.Item("<$COPYNUMBERDATA$>") & "&nbsp;</TD>"
                        End If
                    Case "<$ITEMTITLE$>"
                        If boomf Then
                            strOutMsg = strOutMsg & "<TD  VALIGN=TOP " & mw & ma & " BGCOLOR=FFFFFF>" & bUserColFormat(inti).Replace("<$DATA$>", colContentData.Item("<$ITEMTITLEDATA$>")) & "</TD>"
                        Else
                            strOutMsg = strOutMsg & "<TD VALIGN=TOP " & mw & ma & " BGCOLOR=FFFFFF>" & colContentData.Item("<$ITEMTITLEDATA$>") & "&nbsp;</TD>"
                        End If
                    Case "<$CHECKOUTDATE$>"
                        If boomf Then
                            strOutMsg = strOutMsg & "<TD  VALIGN=TOP " & mw & ma & " BGCOLOR=FFFFFF>" & bUserColFormat(inti).Replace("<$DATA$>", colContentData.Item("<$CHECKOUTDATEDATA$>")) & "</TD>"
                        Else
                            strOutMsg = strOutMsg & "<TD VALIGN=TOP " & mw & ma & " BGCOLOR=FFFFFF>" & colContentData.Item("<$CHECKOUTDATEDATA$>") & "&nbsp;</TD>"
                        End If
                    Case "<$CHECKINDATE$>"
                        If boomf Then
                            strOutMsg = strOutMsg & "<TD  VALIGN=TOP " & mw & ma & " BGCOLOR=FFFFFF>" & bUserColFormat(inti).Replace("<$DATA$>", colContentData.Item("<$CHECKINDATEDATA$>")) & "</TD>"
                        Else
                            strOutMsg = strOutMsg & "<TD VALIGN=TOP " & mw & ma & " BGCOLOR=FFFFFF>" & colContentData.Item("<$CHECKINDATEDATA$>") & "&nbsp;</TD>"
                        End If
                    Case "<$OVERDUEDATE$>"
                        If boomf Then
                            strOutMsg = strOutMsg & "<TD  VALIGN=TOP " & mw & ma & " BGCOLOR=FFFFFF>" & bUserColFormat(inti).Replace("<$DATA$>", colContentData.Item("<$OVERDUEDATEDATA$>")) & "</TD>"
                        Else
                            strOutMsg = strOutMsg & "<TD VALIGN=TOP " & mw & ma & " BGCOLOR=FFFFFF>" & colContentData.Item("<$OVERDUEDATEDATA$>") & "&nbsp;</TD>"
                        End If
                    Case "<$PENATI$>"
                        If boomf Then
                            strOutMsg = strOutMsg & "<TD  VALIGN=TOP " & mw & ma & " BGCOLOR=FFFFFF>" & bUserColFormat(inti).Replace("<$DATA$>", colContentData.Item("<$PENATIDATA$>")) & "</TD>"
                        Else
                            strOutMsg = strOutMsg & "<TD VALIGN=TOP " & mw & ma & " BGCOLOR=FFFFFF>" & colContentData.Item("<$PENATIDATA$>") & "&nbsp;</TD>"
                        End If
                    Case "<$SEQUENCY$>"
                        If boomf Then
                            strOutMsg = strOutMsg & "<TD  VALIGN=TOP " & mw & ma & " BGCOLOR=FFFFFF>" & bUserColFormat(inti).Replace("<$DATA$>", colContentData.Item("<$SEQUENCYDATA$>")) & "</TD>"
                        Else
                            strOutMsg = strOutMsg & "<TD VALIGN=TOP " & mw & ma & " BGCOLOR=FFFFFF>" & colContentData.Item("<$SEQUENCYDATA$>") & "&nbsp;</TD>"
                        End If
                    Case "<$LIBRARY$>"
                        If boomf Then
                            strOutMsg = strOutMsg & "<TD  VALIGN=TOP " & mw & ma & " BGCOLOR=FFFFFF>" & bUserColFormat(inti).Replace("<$DATA$>", colContentData.Item("<$LIBRARYDATA$>")) & "</TD>"
                        Else
                            strOutMsg = strOutMsg & "<TD VALIGN=TOP " & mw & ma & " BGCOLOR=FFFFFF>" & colContentData.Item("<$LIBRARYDATA$>") & "&nbsp;</TD>"
                        End If
                    Case "<$STORE$>"
                        If boomf Then
                            strOutMsg = strOutMsg & "<TD  VALIGN=TOP " & mw & ma & " BGCOLOR=FFFFFF>" & bUserColFormat(inti).Replace("<$DATA$>", colContentData.Item("<$STOREDATA$>")) & "</TD>"
                        Else
                            strOutMsg = strOutMsg & "<TD VALIGN=TOP " & mw & ma & " BGCOLOR=FFFFFF>" & colContentData.Item("<$STOREDATA$>") & "&nbsp;</TD>"
                        End If
                    Case "<$NOTE$>"
                        If boomf Then
                            strOutMsg = strOutMsg & "<TD  VALIGN=TOP " & mw & ma & " BGCOLOR=FFFFFF>" & bUserColFormat(inti).Replace("<$DATA$>", colContentData.Item("<$NOTEDATA$>")) & "</TD>"
                        Else
                            strOutMsg = strOutMsg & "<TD VALIGN=TOP " & mw & ma & " BGCOLOR=FFFFFF>" & colContentData.Item("<$NOTEDATA$>") & "&nbsp;</TD>"
                        End If
                    Case "<$LOANCOUNT$>"
                        If boomf Then
                            strOutMsg = strOutMsg & "<TD  VALIGN=TOP " & mw & ma & " BGCOLOR=FFFFFF>" & bUserColFormat(inti).Replace("<$DATA$>", colContentData.Item("<$LOANCOUNTDATA$>")) & "</TD>"
                        Else
                            strOutMsg = strOutMsg & "<TD VALIGN=TOP " & mw & ma & " BGCOLOR=FFFFFF>" & colContentData.Item("<$LOANCOUNTDATA$>") & "&nbsp;</TD>"
                        End If
                End Select
            Next
            strOutMsg = strOutMsg & "</TR>"
            strOutMsg = strOutMsg & "</TABLE></TD></TR></TABLE>"
            strOutMsg = strOutMsg & objBCSP.ToUTF8Back(Right(objStream, Len(objStream) - InStr(objStream, "@@@@@") - 4))

            Return (strOutMsg)
            '    Catch ex As Exception
            '        strErrorMsg = ex.Message
            ' Finally
            '    End Try
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            If isDisposing Then

            End If
            MyBase.Dispose()
            Dispose()
        End Sub
    End Class
End Namespace