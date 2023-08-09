'Purpose : Retrieve all functions about CATALOGUE TEMPLATE
'Creator sondp
'CreatedDate: 22/4/04
Imports System
Imports eMicLibAdmin.DataAccess
Imports eMicLibAdmin.DataAccess.Common
Imports eMicLibAdmin.BusinessRules.Common
Namespace eMicLibAdmin.BusinessRules.Catalogue
    Public Class clsBCatalogueTemplate
        Inherits clsBBase

        Private objBCSP As New clsBCommonStringProc
        Private objBCT As New clsBCommonTemplate
        Private objTemp As Object

        Private collHeaderData As New Collection
        Private collContentData As New Collection
        Private collFooterData As New Collection
        Private collData As New Collection

        Private strOutMsg As String = "" 'string display Catalogue Template 
        Private strHeader As String = "" 'string Header Catalogue Template
        Private strContent As String = "" 'string Content Catalogue Template
        Private strFooter As String = "" 'string Footer Catalogue Template

        ' ***********************************************************************
        ' Properties here
        ' ***********************************************************************
        'property readonly display Catalogue Template
        ReadOnly Property OutMsg() As String
            Get
                Return (strOutMsg)
            End Get
        End Property
        'property get/set Catalogue Template Header
        Property Header() As String
            Get
                Return (strHeader)
            End Get
            Set(ByVal Value As String)
                strHeader = Value
            End Set
        End Property
        'property get/set Catalogue Template Content
        Property Content() As String
            Get
                Return (strContent)
            End Get
            Set(ByVal Value As String)
                strContent = Value
            End Set
        End Property
        'property get/set Catalogue Template Footer
        Property Footer() As String
            Get
                Return (strFooter)
            End Get
            Set(ByVal Value As String)
                strFooter = Value
            End Set
        End Property
        'property get/set Data Header to Display
        Property HeaderData() As Collection
            Get
                Return (collHeaderData)
            End Get
            Set(ByVal Value As Collection)
                collHeaderData = Value
            End Set
        End Property
        'property get/set Data Content to Display
        Property ContentData() As Collection
            Get
                Return (collContentData)
            End Get
            Set(ByVal Value As Collection)
                collContentData = Value
            End Set
        End Property
        'property get/set Data Footer to Display
        Property FooterData() As Collection
            Get
                Return (collFooterData)
            End Get
            Set(ByVal Value As Collection)
                collFooterData = Value
            End Set
        End Property
        'property get/set Data to display when view Catalogue Templage
        Property Data() As Collection
            Get
                Return collData
            End Get
            Set(ByVal Value As Collection)
                collData = Value
            End Set
        End Property
        'get/set objTemp
        Property Temp() As Object
            Get
                Return (objTemp)
            End Get
            Set(ByVal Value As Object)
                objTemp = Value
            End Set
        End Property

        ' ***********************************************************************
        ' Function Code here
        ' ***********************************************************************

        ' Initialize method
        Public Sub Initialize()
            objBCSP.InterfaceLanguage = strInterfaceLanguage
            objBCSP.ConnectionString = strConnectionString
            objBCSP.DBServer = strDBServer
            objBCSP.Initialize()
            ' Initialize objBCT object
            objBCT.InterfaceLanguage = strInterfaceLanguage
            objBCT.DBServer = strDBServer
            objBCT.ConnectionString = strConnectionString
            objBCT.Initialize()
        End Sub

        'propose: use tvCom.Template to Generate Catalogue Template or Generate Fich Template.
        'in: strHeader, strContent, strFooter.
        'out: property readonly OutMsg.
        'creator: sondp.
        '-----------------------------------------------------------------------
        Public Sub GenerateCatalogueTemplate()
            'Dim for string
            Dim arraPages(3) As String
            Dim ValArr() As String
            Dim strexclTags As String = "001,900,907,911,912,925,926,927,id,leader,no,curday,curmonth,curyear,"
            Dim strUtag As String
            Dim strSerialFormat As String = ""
            Dim strFixFormat As String = ""
            Dim strTag As String
            Dim strSubFieldCode As String = ""
            Dim strFixedFormat As String
            'Dim for Object
            'Dim objtvComLT As New TVCOMLib.LibolTemplate
            'Dim objtvComUpc As New TVCOMLib.utf8
            Dim objData As Object
            Dim objSubVal As Object
            ReDim objData(0)
            Dim objFields As New Object
            'Dim for Integer, Long...
            Dim inti As Integer
            Dim intl As Integer
            Dim intStart As Integer
            Dim intmi As Integer
            'Dim for boolean
            Dim bolUpperIt As Boolean
            Dim bolSerializeIt As Boolean
            Dim bolFixIt As Boolean

            'Get data to process
            'arraPages(0) = objBCSP.ToUTF8(strHeader)
            'arraPages(1) = objBCSP.ToUTF8(strContent)
            'arraPages(2) = objBCSP.ToUTF8(strFooter)
            arraPages(0) = strHeader
            arraPages(1) = strContent
            arraPages(2) = strFooter
            strOutMsg = ""
            Dim strContentTemp As String = ""
            For inti = 0 To 2
                'objtvComLT.Template = arraPages(inti)
                'objFields = objtvComLT.Fields
                strContentTemp = arraPages(inti)
                objFields = objBCT.getArrayFromTemplate(strContentTemp)
                If Not IsNothing(objFields) AndAlso IsArray(objFields) Then
                    ReDim objData(UBound(objFields))
                    intStart = 1
                    For intl = LBound(objFields) To UBound(objFields)
                        strUtag = LCase(objFields(intl))
                        'Have upper or not
                        If InStr(strUtag, ":upper") > 0 Then
                            bolUpperIt = True
                            strUtag = Replace(strUtag, ":upper", "")
                        Else
                            bolUpperIt = False
                        End If
                        'Check have serial sequency
                        If InStr(strUtag, ":serial") > 0 Then
                            strSerialFormat = GetProperty(objFields(intl), ":serial")
                            strUtag = Replace(strUtag, LCase(strSerialFormat), "")
                        Else
                            bolSerializeIt = False
                        End If
                        'Check have fixed
                        If InStr(strUtag, ":fixed") > 0 Then
                            bolFixIt = True
                            strFixFormat = GetProperty(objFields(intl), ":fixed")
                            strUtag = Replace(strUtag, LCase(strFixFormat), "")
                            If InStr(strFixFormat, "=") > 0 Then
                                strFixFormat = Right(strFixFormat, Len(strFixFormat) - InStr(strFixFormat, "="))
                            Else
                                strFixedFormat = ""
                            End If
                        Else
                            bolFixIt = False
                        End If

                        'Check in utag have any field in exclTag, if have insert data to it
                        If InStr(strexclTags, strUtag & ",") > 0 Then
                            Try
                                'utag = objData(intl + 1) = collData.Item(utag) & Chr(9)
                                'objData(intl) = objBCSP.ToUTF8(collData.Item(strUtag)) & Chr(9)
                                objData(intl) = collData.Item(strUtag) & Chr(9)
                            Catch ex As Exception
                                Select Case strUtag
                                    Case "curday" 'get day
                                        objData(intl) = collData.Item("CURDAY") & Chr(9)
                                    Case "curmonth" 'get month
                                        objData(intl) = collData.Item("CURMONTH") & Chr(9)
                                    Case "curyear" 'get year
                                        objData(intl) = collData.Item("CURYEAR") & Chr(9)
                                End Select
                            End Try

                        ElseIf InStr(strUtag, "holding") = 0 Then
                            If bolSerializeIt And InStr(strSerialFormat, "start") > 0 Then
                                intStart = 1
                            End If
                            strTag = Left(strUtag, 3)
                            Try
                                'objData(intl) = objBCSP.ToUTF8(collData.Item(strTag))
                                objData(intl) = collData.Item(strTag)
                            Catch ex As Exception
                                ' objData(intl) = objBCSP.ToUTF8(collData.Item(strUtag))
                            End Try

                            ValArr = Split(objData(intl), Chr(9))
                            objData(intl) = ""
                            For intmi = LBound(ValArr) To UBound(ValArr)
                                If bolSerializeIt Then
                                    Select Case strSerialFormat
                                        Case "serialstart1", "serialcontinue1" 'from SerialStart to SerialEnd(number)
                                            objData(intl) = objData(intl) & intStart & ". "
                                        Case "serialstartI", "serialcontinueI" 'from SerialStart to SerialEnd(Roman)
                                            objData(intl) = objData(intl) & ToRoman(intStart, 1) & ". "
                                        Case "serialstarti", "serialcontinuei" 'from SerialStart to SerialEnd(letter)
                                            objData(intl) = objData(intl) & ToRoman(intStart, 0) & ". "
                                        Case "serialstartA", "serialcontinueA" 'from SerialStart to SerialEnd(capital letter)
                                            objData(intl) = objData(intl) & ToChar(intStart, 1) & ". "
                                        Case "serialstarta", "serialcontinuea"
                                            objData(intl) = objData(intl) & ToChar(intStart, 0) & ". "
                                    End Select
                                    intStart = intStart + 1
                                End If
                                If bolFixIt Then
                                    objData(intl) = objData(intl) & strFixFormat & Chr(9)
                                Else
                                    If InStr(strUtag, "$") = 4 Then
                                        strSubFieldCode = Mid(strUtag, 4, 2)
                                        objBCSP.ParseField(strSubFieldCode, ValArr(intmi), "tr" & Chr(9), objSubVal)
                                        objData(intl) = objData(intl) & objBCSP.TheDisplayOne(objSubVal(0)) & Chr(9)
                                    Else
                                        objData(intl) = objData(intl) & objBCSP.TheDisplayOne(objBCSP.TrimSubFieldCodes(ValArr(intmi))) & Chr(9)
                                    End If
                                End If
                            Next

                        ElseIf InStr(strUtag, "holdingcomposite") = 1 Then

                            If InStr(strUtag, ":lib") > 0 Then
                                objData(intl) = objData(intl) & collData.Item("LIB")
                            End If
                            If InStr(strUtag, ":inventory") > 0 Then
                                objData(intl) = objData(intl) & collData.Item("INVENTORY")
                            End If
                            If InStr(strUtag, ":shelf") > 0 Then
                                objData(intl) = objData(intl) & collData.Item("SHELF")
                            End If
                            objData(intl) = objData(intl) & collData.Item("HOLDINGCOMPOSITEELSE") & Chr(9)
                        Else
                            If InStr(strUtag, ":lib") > 0 Then
                                objData(intl) = objData(intl) & collData.Item("LIB")
                            End If
                            If InStr(strUtag, ":inventory") > 0 Then
                                objData(intl) = objData(intl) & collData.Item("INVENTORY")
                            End If
                            If InStr(strUtag, ":shelf") > 0 Then
                                objData(intl) = objData(intl) & collData.Item("SHELF")
                            End If
                            If InStr(strUtag, ":number") > 0 Then
                                'objData(intl) = objData(intl) & objBCSP.ToUTF8(collData.Item("NUMBER"))
                                objData(intl) = objData(intl) & collData.Item("NUMBER")
                            End If
                            If InStr(strUtag, ":callnumber") > 0 Then
                                'objData(intl) = objData(intl) & objBCSP.ToUTF8(collData.Item("CALLNUMBER"))
                                objData(intl) = objData(intl) & collData.Item("CALLNUMBER")
                            End If
                            objData(intl) = objData(intl) & Chr(9)
                        End If

                        If Not objData(intl) = "" Then
                            objData(intl) = Left(objData(intl), Len(objData(intl)) - 1)
                        End If
                        If bolUpperIt Then
                            'objData(intl) = objtvComUpc.Upper(objData(intl))
                            objData(intl) = UCase(objData(intl))
                        End If
                        strContentTemp = Replace(strContentTemp, "<$" & objFields(intl) & "$>", objData(intl))
                    Next
                End If
                'Dim strTemp As Object
                'Get data to display
                'strTemp = objBCSP.ToUTF8Back(objtvComLT.Generate(objData))
                'strTemp = strContentTemp
                strOutMsg &= strContentTemp
            Next

            'Dispose COM
            'objtvComLT = Nothing
            'objtvComUpc = Nothing
        End Sub

        Function GetProperty(ByVal f, ByVal ss) As Object
            Dim mp As Object
            Dim p As Object
            p = InStr(LCase(f), ss)
            If p > 0 Then
                mp = Right(f, Len(f) - p)
                f = Left(f, p - 1)
                p = InStr(mp, ":")
                If p > 0 Then
                    GetProperty = Left(mp, p - 1)
                Else
                    GetProperty = mp
                End If
            Else
                GetProperty = ""
            End If
        End Function
        'convert integer, long...to Char
        Function ToChar(ByVal lngNumber, ByVal CCase) As String
            ToChar = Chr(lngNumber Mod 26 + 64)
            If CCase = 0 Then
                ToChar = LCase(ToChar)
            End If
        End Function
        Function ToRoman(ByVal lngNumber, ByVal CCase) As Object
            Dim lngThousands As Long
            Dim lngFiveHundreds As Long
            Dim lngHundreds As Long
            Dim lngFifties As Long
            Dim lngTens As Long
            Dim lngFives As Long
            Dim lngOnes As Long
            Dim lngi As Long
            lngOnes = lngNumber
            lngThousands = lngOnes \ 1000
            lngOnes = lngOnes - lngThousands * 1000
            lngFiveHundreds = lngOnes \ 500
            lngOnes = lngOnes - lngFiveHundreds * 500
            lngHundreds = lngOnes \ 100
            lngOnes = lngOnes - lngHundreds * 100
            lngFifties = lngOnes \ 50
            lngOnes = lngOnes - lngFifties * 50
            lngTens = lngOnes \ 10
            lngOnes = lngOnes - lngTens * 10
            lngFives = lngOnes \ 5
            lngOnes = lngOnes - lngFives * 5
            For lngi = 1 To lngThousands
                ToRoman &= "M"
            Next
            If lngHundreds = 4 Then
                If lngFiveHundreds = 1 Then
                    ToRoman &= "CM"
                Else
                    ToRoman &= "CD"
                End If
            Else
                For lngi = 1 To lngFiveHundreds
                    ToRoman &= "D"
                Next
                For lngi = 1 To lngHundreds
                    ToRoman &= "C"
                Next
            End If

            If lngTens = 4 Then
                If lngFifties = 1 Then
                    ToRoman &= "XC"
                Else
                    ToRoman &= "XL"
                End If
            Else
                For lngi = 1 To lngFifties
                    ToRoman &= "L"
                Next
                For lngi = 1 To lngTens
                    ToRoman &= "X"
                Next
            End If
            If lngOnes = 4 Then
                If lngFives = 1 Then
                    ToRoman &= "IX"
                Else
                    ToRoman &= "IV"
                End If
            Else
                For lngi = 1 To lngFives
                    ToRoman &= "V"
                Next
                For lngi = 1 To lngOnes
                    ToRoman &= "I"
                Next
            End If
            If CCase = 0 Then
                ToRoman = LCase(ToRoman)
            End If
        End Function
        ' ***********************************************************************
        ' Dispose Method here
        ' ***********************************************************************
        ' Release resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBCT Is Nothing Then
                    objBCT.Dispose(True)
                    objBCT = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace