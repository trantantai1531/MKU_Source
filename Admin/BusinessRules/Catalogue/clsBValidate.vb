' Purpose: validate data
' Creator: KhoaNA
' Created Date: 27/04/2004
' Modification history:
'   - 14/06/2003 by Oanhtn: review

Imports System
Imports System.Linq
Imports System.Text
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Catalogue

Namespace eMicLibAdmin.BusinessRules.Catalogue
    Public Class clsBValidate
        Inherits clsBField

        ' *****************************************************************************************************
        ' Declare Private variables
        ' *****************************************************************************************************

        Private strIndicator As String
        Private strFieldValue As String
        Private blnRepeat As Boolean
        Private strLblViewDefaul As String
        Private strLblValue As String
        Private boolIsAuthority As Boolean = False
        Private hidAction As String
        Private strSeparate As String
        Private strID As String
        Private strOldIndicator As String

        Private objBCSP As New clsBCommonStringProc
        Private objDField As New clsDField

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' Separate Property
        Public Property Separate() As String
            Get
                Separate = strSeparate
            End Get
            Set(ByVal Value As String)
                strSeparate = Value
            End Set
        End Property

        ' ID property
        Public Property ID() As String
            Get
                ID = strID
            End Get
            Set(ByVal Value As String)
                strID = Value
            End Set
        End Property

        ' OldIndicator property
        Public Property OldIndicator() As String
            Get
                OldIndicator = strOldIndicator
            End Get
            Set(ByVal Value As String)
                strOldIndicator = Value
            End Set
        End Property

        ' Action property
        Public Property Action() As String
            Get
                Action = hidAction
            End Get
            Set(ByVal Value As String)
                hidAction = Value
            End Set
        End Property

        ' Repeat property
        Public Property Repeat() As Boolean
            Get
                Return blnRepeat
            End Get
            Set(ByVal Value As Boolean)
                blnRepeat = Value
            End Set
        End Property

        ' FieldValue property
        Public Property FieldValue() As String
            Get
                Return strFieldValue
            End Get
            Set(ByVal Value As String)
                strFieldValue = Value
            End Set
        End Property

        ' LblValue property
        Public Property LblValue() As String
            Get
                Return strLblValue
            End Get
            Set(ByVal Value As String)
                strLblValue = Value
            End Set
        End Property

        ' LblViewDefaul property
        Public Property LblViewDefaul() As String
            Get
                Return strLblViewDefaul
            End Get
            Set(ByVal Value As String)
                strLblViewDefaul = Value
            End Set
        End Property

        ' Indicator property
        Public Property Indicator() As String
            Get
                Return strIndicator
            End Get
            Set(ByVal Value As String)
                strIndicator = Value
            End Set
        End Property

        ' LabelStr property
        Public Property LabelStr() As String()

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Initialize
        ' Init all neccessary objects
        Public Overridable Overloads Sub Initialize()
            Try
                ' Init objBCSP
                objBCSP.DBServer = strDBServer
                objBCSP.ConnectionString = strConnectionString
                objBCSP.Initialize()

                ' Init MyBase (Field) object
                MyBase.DBServer = strDBServer
                MyBase.ConnectionString = strConnectionString
                MyBase.Initialize()

                'objDCatDicList Properties
                objDField.DBServer = strDBServer
                objDField.ConnectionString = strConnectionString
                objDField.Initialize()

            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        ' CheckTag method
        ' Purpose: validate field's value
        ' Output: string value of CheckMessage
        Public Function CheckTag(ByVal strNoHave As String) As String
            Dim strOutMsg As String = ""
            Dim arrSubField()
            Dim intCounter As Integer
            Dim strSubFields As String = ""
            Dim tbFieldProperties As DataTable
            Dim tblSubField As New DataTable

            ' Get all subfield of the selected field
            tblSubField = GetSubFields()
            If Not tblSubField Is Nothing AndAlso tblSubField.Rows.Count > 0 Then
                For intCounter = 0 To tblSubField.Rows.Count - 1
                    If Len(tblSubField.Rows(intCounter).Item("FieldCode")) > 3 Then
                        strSubFields = strSubFields & Right(tblSubField.Rows(intCounter).Item("FieldCode"), 1)
                    End If
                Next
            End If

            ' Get all properties of the selected field
            tbFieldProperties = GetProperties()
            If Not tbFieldProperties Is Nothing AndAlso tbFieldProperties.Rows.Count > 0 Then
                ' Check value of Field008
                If strFieldCode = "008" And Not strFieldValue = "" Then
                    strOutMsg = strOutMsg & Check008Book(strFieldValue, strFieldCode)
                    strFieldCode = tbFieldProperties.Rows(0).Item("FieldCode")
                End If

                ' Check repeatable, assign to variables
                blnRepeat = tbFieldProperties.Rows(0).Item("Repeatable")

                ' Get subfields
                arrSubField = Split(strFieldValue, "$")
                If tblSubField.Rows.Count > 0 And Len(tblSubField.Rows(0).Item("FieldCode")) > 3 Then
                    If Not UBound(arrSubField) > 0 Then
                        strOutMsg = strOutMsg & strNoHave & " $"
                        Return strOutMsg
                        Exit Function
                    End If
                    ' Validate subfields
                    For intCounter = LBound(arrSubField) To UBound(arrSubField)
                        If Len(Left(arrSubField(intCounter), 1).Trim) > 0 Then
                            If Not InStr(strSubFields, Left(arrSubField(intCounter), 1)) > 0 Then
                                strOutMsg = strOutMsg & strNoHave & FieldCode & "$" & Left(arrSubField(intCounter), 1)
                            End If
                        End If
                    Next
                Else
                    ' Validate subfields
                    For intCounter = LBound(arrSubField) To UBound(arrSubField)
                        If Len(Left(arrSubField(intCounter), 1).Trim) > 0 Then
                            If Not InStr(strSubFields, Left(arrSubField(intCounter), 1)) > 0 And (Trim(strSubFields) <> "") Then
                                strOutMsg = strOutMsg & strNoHave & FieldCode & "$" & Left(arrSubField(intCounter), 1)
                            Else
                                Exit Function
                            End If
                        End If
                    Next
                End If
            End If
            Return strOutMsg
        End Function

        ' CheckAllTags function
        ' Purpose: Check valid fields's data
        ' Putput: string value of unvalid messages
        Public Function CheckAllTags(Optional ByVal strLea As String = "") As String
            Dim strOutMsg As New StringBuilder(512)
            Dim repItor As Integer
            Dim subRepItor As Integer
            Dim strSubfieldCodesCsv As String = ""
            Dim strmList As String
            Dim strTagVal As String
            Dim strIndicators As String
            Dim intColonPos As Integer
            Dim repeatableRecords() As Object = Nothing
            Dim subRecords() As Object = Nothing
            Dim tblFieldProperties As DataTable
            Dim tblSubfields As DataTable
            Dim isRepeatableField As Boolean = False
            Dim isMandatoryField As Boolean = False

            ' Get Field's properties : Mandatory,Indicator,FieldTypeId,Repeatable ...
            tblFieldProperties = GetProperties()
            isRepeatableField = tblFieldProperties.Rows(0).Item("Repeatable")
            isMandatoryField = tblFieldProperties.Rows(0).Item("Mandatory")
            If Not tblFieldProperties Is Nothing Then
                If tblFieldProperties.Rows.Count > 0 Then
                    If strFieldCode = "006" AndAlso strFieldValue <> "" Then
                        strOutMsg.Append(CheckField006(strFieldCode, strLea, strFieldValue))
                        strFieldCode = tblFieldProperties.Rows(0).Item("FieldCode")
                    End If

                    ' Check value of field007
                    If strFieldCode = "007" And Not strFieldValue = "" Then
                        strOutMsg.Append(CheckField007(strFieldCode, strLea, strFieldValue))
                        strFieldCode = tblFieldProperties.Rows(0).Item("FieldCode")
                    End If

                    ' Check value of field008
                    If strFieldCode = "008" And Not strFieldValue = "" Then
                        strOutMsg.Append(CheckField008(strFieldCode, strLea, strFieldValue))
                        strFieldCode = tblFieldProperties.Rows(0).Item("FieldCode")
                    End If

                    'Check value of field005
                    If strFieldCode = "005" And Not strFieldValue = "" Then
                        Dim strResult As String = Trim(Check005(strFieldCode, strFieldValue))
                        If strResult <> "" Then
                            strOutMsg.Append(strResult).AppendLine()
                        End If
                    End If

                    'Check FieldCode Mandatory
                    If strFieldValue = "" And isMandatoryField Then
                        strOutMsg.Append(strFieldCode).Append(": ").Append(LabelStr(3)).AppendLine()
                    End If

                    'Get all subfield of the selected field
                    tblSubfields = GetSubFields()
                    If tblSubfields.Rows.Count > 0 Then
                        For i As Integer = 0 To tblSubfields.Rows.Count - 1
                            If Len(tblSubfields.Rows(i).Item("FieldCode")) > 3 Then
                                strSubfieldCodesCsv = strSubfieldCodesCsv & Right(tblSubfields.Rows(i).Item("FieldCode"), 2) & ","
                            End If
                        Next
                    End If

                    objBCSP.ParseFieldValue(strFieldValue, "$&", repeatableRecords, strFieldCode)
                    If UBound(repeatableRecords) > 1 AndAlso Not isRepeatableField Then
                        strOutMsg.Append(strFieldCode).Append(": ").Append(LabelStr(4)).AppendLine()
                    End If

                    For repItor = LBound(repeatableRecords) To UBound(repeatableRecords) - 1
                        If repeatableRecords(repItor) <> "" Then
                            strTagVal = repeatableRecords(repItor)
                            strIndicators = ""
                            intColonPos = InStr(strTagVal, "::")
                            If intColonPos > 0 And intColonPos <= 3 Then
                                strIndicators = Left(strTagVal, intColonPos - 1)
                                strTagVal = Right(strTagVal, Len(strTagVal) - intColonPos - 1)
                            Else
                                strIndicators = "  "
                            End If
                            If Not IsDBNull(tblFieldProperties.Rows(0).Item("Indicators")) OrElse Not IsDBNull(tblFieldProperties.Rows(0).Item("VietIndicators")) Then
                                Select Case CheckIndicators(strIndicators)
                                    Case 1
                                        strOutMsg.Append(strFieldCode).Append(": ").Append(LabelStr(7)).AppendLine()
                                    Case 2
                                        strOutMsg.Append(strFieldCode).Append(": ").Append(LabelStr(8)).AppendLine()
                                    Case 3
                                        strOutMsg.Append(strFieldCode).Append(": ").Append(LabelStr(12)).AppendLine()
                                End Select
                            End If

                            strmList = strSubfieldCodesCsv
                            If strmList <> "" Then
                                strmList = Left(strSubfieldCodesCsv, Len(strmList) - 1)
                                objBCSP.ParseField(strmList, strTagVal, "##", subRecords)

                                If subRecords(UBound(subRecords)) <> "" Then
                                    If strmList.Split(",").Length < subRecords.Length Then
                                        strOutMsg.Append(strFieldCode).Append(": ").Append(LabelStr(5)).Append(Replace(subRecords(UBound(subRecords)), "$", " $")).AppendLine()
                                    End If
                                End If
                                strmList = strmList & ","
                                For subRepItor = LBound(subRecords) To UBound(subRecords) - 1
                                    If tblSubfields.Rows.Count > repItor Then
                                        If Len(CStr(tblSubfields.Rows(repItor).Item("FieldCode"))) > 3 Then
                                            If Not strmList = "" Then
                                                strmList = Trim(Right(strmList, Len(strmList) - 3))
                                                If InStr(subRecords(subRepItor), "##") > 0 AndAlso CInt(tblSubfields.Rows(subRepItor).Item("Repeatable")) = 0 Then
                                                    strOutMsg.Append(strFieldCode).Append(": ").Append(LabelStr(4)).AppendLine()
                                                End If
                                                If repItor > 0 Then
                                                    If CInt(tblSubfields.Rows(subRepItor).Item("Repeatable")) = 1 AndAlso subRecords(subRepItor) = "" AndAlso CInt(tblSubfields.Rows(subRepItor).Item("Mandatory")) <> 0 Then
                                                        strOutMsg.Append(strFieldCode).Append(": ").Append(LabelStr(3)).AppendLine()
                                                    End If
                                                Else
                                                    If subRecords(subRepItor) = "" AndAlso CInt(tblSubfields.Rows(subRepItor).Item("Mandatory")) <> 0 Then
                                                        strOutMsg.Append(strFieldCode).Append(": ").Append(LabelStr(3)).AppendLine()
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                Next
                            End If
                        End If
                    Next
                End If
            End If
            tblSubfields = Nothing
            tblFieldProperties = Nothing
            Return strOutMsg.ToString().Trim()
        End Function

        Private Function CheckField008(ByVal strFieldCode As String, ByVal strLea As String, ByVal strFieldValue As String) As String
            Dim strOutMsg As New StringBuilder(256)
            Dim strLeaAtPos7 As String = ""
            Dim strLeaAtPos8 As String = ""
            Dim strCheckResult As String = ""
            strLeaAtPos7 = Mid(strLea, 7, 1)
            If strLeaAtPos7 = "z" Then
                strCheckResult = Trim(Check008Authory(strFieldValue, strFieldCode))
                If strCheckResult <> "" Then
                    strOutMsg.Append(strCheckResult).AppendLine()
                End If
            Else
                strCheckResult = Trim(Check008(strFieldValue, strFieldCode))
                If strCheckResult <> "" Then
                    strOutMsg.Append(strCheckResult).AppendLine()
                Else
                    Select Case strLeaAtPos7
                        Case "a"
                            strLeaAtPos8 = Mid(strLea, 8, 1)
                            Select Case strLeaAtPos8
                                Case "a", "c", "d", "m"
                                    strOutMsg.Append(Check008Book(strFieldValue, strFieldCode))
                                Case "b", "s"
                                    strOutMsg.Append(Check008Con_Resources(strFieldValue, strFieldCode))
                            End Select
                        Case "b", "t"
                            strOutMsg.Append(Check008Book(strFieldValue, strFieldCode))
                        Case "c", "d", "i", "j"
                            strOutMsg.Append(Check008Music(strFieldValue, strFieldCode))
                        Case "e", "f"
                            strOutMsg.Append(Check008Maps(strFieldValue, strFieldCode))
                        Case "m"
                            strOutMsg.Append(Check008ComputerFile(strFieldValue, strFieldCode))
                        Case "p"
                            strOutMsg.Append(Check008Mix_Materials(strFieldValue, strFieldCode))
                    End Select
                End If
            End If
            Return strOutMsg.ToString().Trim()
        End Function
        Private Function CheckField007(ByVal strFieldCode As String, ByVal strLea As String, ByVal strFieldValue As String) As String
            Dim strOutMsg As New StringBuilder(256)
            Dim strLeaAtPos7 As String = ""
            strLeaAtPos7 = Mid(strLea, 7, 1)
            Select Case strLeaAtPos7
                Case "a", "t"
                    strOutMsg.Append(Check007_Text(strFieldValue, strFieldCode))
                Case "c", "d", "i", "j"
                    strOutMsg.Append(Check007_Sound(strFieldValue, strFieldCode))
                Case "e", "f"
                    strOutMsg.Append(Check007_Maps(strFieldValue, strFieldCode))
                Case "m"
                    strOutMsg.Append(Check007_Electronic(strFieldValue, strFieldCode))
                Case "g"
                    strOutMsg.Append(Check007_Motion(strFieldValue, strFieldCode))
                Case "o"
                    strOutMsg.Append(Check007_Kit(strFieldValue, strFieldCode))
                Case "p", "r"
                    strOutMsg.Append(Check007_Tactile(strFieldValue, strFieldCode))
                Case "k"
                    strOutMsg.Append(Check007_Nonprojected(strFieldValue, strFieldCode))
            End Select

            Return strOutMsg.ToString().Trim()
        End Function

        Private Function CheckField006(ByVal strFieldCode As String, ByVal strLea As String, ByVal strFieldValue As String) As String
            Dim strLeaAtPos7 As String = ""
            Dim strLeadAtPos8 As String = ""
            Dim strCheckResult As String = ""
            Dim strOutMsg As New StringBuilder(256)
            strLeaAtPos7 = Mid(strLea, 7, 1)
            strCheckResult = Trim(Check006(strFieldValue, strFieldCode))
            If strCheckResult <> "" Then
                strOutMsg.Append(strCheckResult).Append("\n")
            Else
                Select Case strLeaAtPos7
                    Case "a"
                        strLeadAtPos8 = Mid(strLea, 8, 1)
                        Select Case strLeadAtPos8
                            Case "a", "c", "d", "m"
                                strOutMsg.Append(Check006_Book(strFieldValue, strFieldCode))
                            Case "b", "s"
                                strOutMsg.Append(Check006_ConResources(strFieldValue, strFieldCode))
                        End Select
                    Case "t"
                        strOutMsg.Append(Check006_Book(strFieldValue, strFieldCode))
                    Case "c", "d", "i", "j"
                        strOutMsg.Append(Check006_Music(strFieldValue, strFieldCode))
                    Case "e", "f"
                        strOutMsg.Append(Check006_Maps(strFieldValue, strFieldCode))
                    Case "m"
                        strOutMsg.Append(Check006_ComputerFile(strFieldValue, strFieldCode))
                    Case "g", "o", "r"
                        strOutMsg.Append(Check006_VisMaterials(strFieldValue, strFieldCode))
                    Case "p"
                        strOutMsg.Append(Check006_MixMaterials(strFieldValue, strFieldCode))
                End Select
            End If
            Return strOutMsg.ToString().Trim()
        End Function

        ' CheckIndicators method
        ' Purpose check Indicators input
        ' Input: string value of Indicator
        ' Output: int value
        '   0 if successful 
        '   1 if first indicator fail
        '   2 if second indicator fail,
        '   3 if two Ind fail
        Public Function CheckIndicators(ByVal strIndicator As String) As Integer
            Dim intCounter As Integer
            Dim intResult As Integer = 0
            Dim strInd1 As String = ""
            Dim strInd2 As String = ""
            Dim tblIndicatorValues As DataTable

            If Len(Trim(strIndicator)) = 0 Then
                strIndicator = Trim(strIndicator)
            End If
            'If Len(strIndicator) = 0 Then
            '    strIndicator = " "
            'Else
            If Len(strIndicator) = 1 Then
                strIndicator = strIndicator & " "
            End If

            tblIndicatorValues = GetIndicatorValues()
            If Not tblIndicatorValues Is Nothing AndAlso Not tblIndicatorValues.Rows.Count = 0 Then
                For intCounter = 0 To tblIndicatorValues.Rows.Count - 1
                    If CInt(tblIndicatorValues.Rows(intCounter).Item("Pos")) = 1 Then
                        strInd1 = strInd1 & tblIndicatorValues.Rows(intCounter).Item("Val")
                    Else
                        strInd2 = strInd2 & tblIndicatorValues.Rows(intCounter).Item("Val")
                    End If
                Next
                ' Check values of indicators 
                strInd1 = UCase(strInd1)
                strInd2 = UCase(strInd2)
                strIndicator = UCase(strIndicator)
                If strFieldCode = "072" And strInd1 = "" Then
                    strInd1 = " "
                End If
                ' Invalid indicator 1
                If InStr(strInd1, Left(strIndicator, 1)) = 0 Then
                    intResult = intResult + 1
                End If
                ' Invalid indicator 2
                If InStr(strInd2, Right(strIndicator, 1)) = 0 Then
                    intResult = intResult + 2
                End If
            End If

            ' Return
            CheckIndicators = intResult
        End Function
        Public Function Check005(ByVal strFieldCode As String, ByVal strValue As String) As String
            Dim strOutMsg As String = ""
            Dim strSubString As String = ""
            Dim intDay As Integer = 30
            If strValue = "" Then
                Check005 = ""
            Else
                ' Kiem tra do dai
                If strValue.Length <> 16 Then
                    strOutMsg = strOutMsg & strFieldCode & ": " & LabelStr(13) & "\n"
                Else
                    'Kiem tra nam
                    strSubString = strValue.Substring(0, 4)
                    If Not IsNumeric(strSubString) Then
                        strOutMsg = strOutMsg & strFieldCode & ": " & LabelStr(14) & "\n"
                        'ElseIf CInt(strSubString) < 1990 Then
                        '    strOutMsg = strOutMsg & strFieldCode & ": " & arrLabelStr(14) & "\n"
                    End If
                    'Kiem tra thang
                    strSubString = strValue.Substring(4, 2)
                    If Not IsNumeric(strSubString) Then
                        strOutMsg = strOutMsg & strFieldCode & ": " & LabelStr(15) & "\n"
                    ElseIf CInt(strSubString) < 1 Or CInt(strSubString) > 12 Then
                        strOutMsg = strOutMsg & strFieldCode & ": " & LabelStr(15) & "\n"
                    Else
                        Select Case CInt(strSubString)
                            Case 1, 3, 5, 7, 8, 10, 12
                                intDay = 31
                            Case 2
                                intDay = 28
                            Case Else
                                intDay = 30
                        End Select
                    End If
                    'Kiem tra ngay
                    strSubString = strValue.Substring(6, 2)
                    If Not IsNumeric(strSubString) Then
                        strOutMsg = strOutMsg & strFieldCode & ": " & LabelStr(16) & "\n"
                    ElseIf CInt(strSubString) < 1 Or CInt(strSubString) > intDay Then
                        strOutMsg = strOutMsg & strFieldCode & ": " & LabelStr(16) & "\n"
                    End If
                    'Kiem ra gio
                    strSubString = strValue.Substring(8, 2)
                    If Not IsNumeric(strSubString) Then
                        strOutMsg = strOutMsg & strFieldCode & ": " & LabelStr(17) & "\n"
                    ElseIf CInt(strSubString) < 0 Or CInt(strSubString) > 23 Then
                        strOutMsg = strOutMsg & strFieldCode & ": " & LabelStr(17) & "\n"
                    End If
                    'Kiem tra phut
                    strSubString = strValue.Substring(10, 2)
                    If Not IsNumeric(strSubString) Then
                        strOutMsg = strOutMsg & strFieldCode & ": " & LabelStr(18) & "\n"
                    ElseIf CInt(strSubString) < 0 Or CInt(strSubString) > 59 Then
                        strOutMsg = strOutMsg & strFieldCode & ": " & LabelStr(18) & "\n"
                    End If
                    'Kiem tra giay
                    strSubString = strValue.Substring(12, 2)
                    If Not IsNumeric(strSubString) Then
                        strOutMsg = strOutMsg & strFieldCode & ": " & LabelStr(19) & "\n"
                    ElseIf CInt(strSubString) < 0 Or CInt(strSubString) > 59 Then
                        strOutMsg = strOutMsg & strFieldCode & ": " & LabelStr(19) & "\n"
                    End If
                    'Kiem tra phan tram giay
                    strSubString = strValue.Substring(14, 2)
                    If Not IsNumeric(strSubString) Then
                        If Not IsNumeric(strSubString.Substring(1, 1)) Then
                            strOutMsg = strOutMsg & strFieldCode & ": " & LabelStr(20) & "\n"
                        End If
                    End If
                End If
            End If
            Check005 = strOutMsg
        End Function
        Public Function CheckDate008(ByVal val As String, ByVal intPos As Integer, ByVal intLen As Integer, ByVal strFieldCode As String) As String
            Dim strTemp As String = ""
            Dim strDate As String = ""
            Dim strOutMsg As String = ""
            Dim intDay As Integer = 30
            If val = "" Then
                CheckDate008 = ""
                Exit Function
            End If
            strTemp = val.Substring(intPos, intLen)
            strDate = strTemp.Substring(0, 2)
            If Not IsNumeric(strDate) Then
                strOutMsg = strOutMsg & strFieldCode & ": " & LabelStr(14) & "\n"
            End If
            strDate = strTemp.Substring(2, 2)
            If Not IsNumeric(strDate) Then
                strOutMsg = strOutMsg & strFieldCode & ": " & LabelStr(15) & "\n"
            ElseIf CInt(strDate) < 0 Or CInt(strDate) > 12 Then
                strOutMsg = strOutMsg & strFieldCode & ": " & LabelStr(15) & "\n"
            Else
                Select Case CInt(strDate)
                    Case 1, 3, 5, 7, 8, 10, 12
                        intDay = 31
                    Case 2
                        intDay = 28
                    Case Else
                        intDay = 30
                End Select
            End If
            strDate = strTemp.Substring(4, 2)
            If Not IsNumeric(strDate) Then
                strOutMsg = strOutMsg & strFieldCode & ": " & LabelStr(16) & "\n"
            ElseIf CInt(strDate) < 0 Or CInt(strDate) > intDay Then
                strOutMsg = strOutMsg & strFieldCode & ": " & LabelStr(16) & "\n"
            End If
            CheckDate008 = strOutMsg
        End Function
        Public Function CheckDate007(ByVal val As String, ByVal intPos As Integer, ByVal intLen As Integer, ByVal strFieldCode As String) As String
            'ccyymm (century/year/month)
            Dim strTemp As String = ""
            Dim strDate As String = ""
            Dim strOutMsg As String = ""
            Dim intDay As Integer = 30
            If val = "" Then
                CheckDate007 = ""
                Exit Function
            End If
            strTemp = val.Substring(intPos, intLen)
            strDate = strTemp.Substring(0, 2)
            If Not IsNumeric(strDate) Then
                strOutMsg = strOutMsg & strFieldCode & ": " & LabelStr(21) & "\n"
            End If
            strDate = strTemp.Substring(2, 2)
            If Not IsNumeric(strDate) Then
                strOutMsg = strOutMsg & strFieldCode & ": " & LabelStr(14) & "\n"
            End If
            strDate = strTemp.Substring(4, 2)
            If Not IsNumeric(strDate) Then
                strOutMsg = strOutMsg & strFieldCode & ": " & LabelStr(15) & "\n"
            ElseIf CInt(strDate) < 0 Or CInt(strDate) > 12 Then
                strOutMsg = strOutMsg & strFieldCode & ": " & LabelStr(15) & "\n"
            End If

            CheckDate007 = strOutMsg
        End Function
        ' Check006 method
        ' Purpose: validate value of field006
        ' Input: value of field006
        ' Output: string value of ErrorMessage
        ' Creator: chuyenpt (09/08/07)
        Public Function Check006(ByVal val As String, ByVal strfieldcode As String) As String
            Dim strOutMsg As String = ""

            ' Kie^?m tra ddo^. da`i
            If Len(val) > 18 Or Len(val) < 18 Then
                strOutMsg = strOutMsg & strfieldcode & ": " & strLblViewDefaul & "\n"
            End If

            Check006 = Trim(strOutMsg)
        End Function
        ' Check006 method
        ' Purpose: validate value of field006
        ' Input: value of field006
        ' Output: string value of ErrorMessage
        ' Creator: chuyenpt (09/08/07)
        Public Function Check006_Book(ByVal val As String, ByVal strFieldCode As String) As String
            Dim strOutMsg As String = ""

            ' Kie^?m tra 00
            Dim ArrValue1() = {"a", "t"}
            strOutMsg = strOutMsg & CheckValue(val, 0, 1, 1, ArrValue1, strFieldCode)
            ' Kie^?m tra 01-04
            Dim ArrValue2() As String = {" ", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "o", "p", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 1, 4, 2, ArrValue2, strFieldCode)
            ' Kie^?m tra 05
            Dim ArrValue3() As String = {" ", "a", "b", "c", "d", "e", "f", "g", "j", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 5, 1, 1, ArrValue3, strFieldCode)
            ' Kie^?m tra 06
            Dim ArrValue4() As String = {" ", "a", "b", "c", "d", "f", "r", "s", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 6, 1, 1, ArrValue4, strFieldCode)
            ' Kie^?m tra 07-10
            Dim ArrValue5() As String = {" ", "a", "b", "c", "d", "e", "f", "g", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 7, 4, 2, ArrValue5, strFieldCode)
            ' Kie^?m tra 11
            Dim ArrValue6() As String = {" ", "a", "c", "f", "i", "l", "m", "o", "s", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 11, 1, 1, ArrValue6, strFieldCode)
            ' Kie^?m tra 12
            Dim ArrValue7() As String = {"0", "1", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 12, 1, 1, ArrValue7, strFieldCode)
            ' Kie^?m tra 13
            Dim ArrValue8() As String = {"|", "0", "1"}
            strOutMsg = strOutMsg & CheckValue(val, 13, 1, 1, ArrValue8, strFieldCode)
            ' Kie^?m tra 14
            Dim ArrValue9() As String = {"|", "0", "1"}
            strOutMsg = strOutMsg & CheckValue(val, 14, 1, 1, ArrValue9, strFieldCode)
            ' Kie^?m tra 15
            Dim ArrValue12() = {" ", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 15, 1, 1, ArrValue12, strFieldCode)
            ' Kie^?m tra 16
            Dim ArrValue10() As String = {"|", "0", "1", "c", "d", "e", "f", "h", "i", "j", "m", "p", "s", "u"}
            strOutMsg = strOutMsg & CheckValue(val, 16, 1, 1, ArrValue10, strFieldCode)
            ' Kie^?m tra 17
            Dim ArrValue11() As String = {" ", "a", "b", "c", "d", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 17, 1, 1, ArrValue11, strFieldCode)
            ' Tra? la.i ke^'t qua?
            Check006_Book = Trim(strOutMsg)
        End Function
        ' Check006 method
        ' Purpose: validate value of field006
        ' Input: value of field006
        ' Output: string value of ErrorMessage
        ' Creator: chuyenpt (09/08/07)
        Public Function Check006_ComputerFile(ByVal val As String, ByVal strFieldCode As String) As String
            Dim strOutMsg As String = ""

            ' Kie^?m tra 00
            Dim ArrValue1() = {"m"}
            strOutMsg = strOutMsg & CheckValue(val, 0, 1, 1, ArrValue1, strFieldCode)
            ' Kie^?m tra 01-04
            Dim ArrValue5() = {" ", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 1, 4, 2, ArrValue5, strFieldCode)
            ' Kie^?m tra 05
            Dim ArrValue2() As String = {" ", "a", "b", "c", "d", "e", "f", "g", "j", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 5, 1, 1, ArrValue2, strFieldCode)
            ' Kie^?m tra 06-08
            Dim ArrValue6() = {" ", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 6, 3, 2, ArrValue6, strFieldCode)
            ' Kie^?m tra 09
            Dim ArrValue3() As String = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "m", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 9, 1, 1, ArrValue3, strFieldCode)
            ' Kie^?m tra 10
            Dim ArrValue7() = {" ", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 10, 1, 1, ArrValue7, strFieldCode)
            ' Kie^?m tra 11
            Dim ArrValue4() As String = {" ", "a", "c", "f", "i", "l", "m", "o", "s", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 11, 1, 1, ArrValue4, strFieldCode)
            ' Tra? la.i ke^'t qua?
            Check006_ComputerFile = Trim(strOutMsg)
        End Function
        ' Check006 method
        ' Purpose: validate value of field006
        ' Input: value of field006
        ' Output: string value of ErrorMessage
        ' Creator: chuyenpt (09/08/07)
        Public Function Check006_Maps(ByVal val As String, ByVal strFieldCode As String) As String
            Dim strOutMsg As String = ""

            ' Kie^?m tra 00
            Dim ArrValue1() = {"e", "f"}
            strOutMsg = strOutMsg & CheckValue(val, 0, 1, 1, ArrValue1, strFieldCode)
            ' Kie^?m tra 01-04
            Dim ArrValue2() As String = {" ", "a", "b", "c", "d", "e", "f", "g", "i", "j", "k", "m", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 1, 4, 2, ArrValue2, strFieldCode)
            ' Kie^?m tra 05-06
            Dim ArrValue3() As String = {"  ", "aa", "ab", "ac", "ad", "ae", "af", "ag", "am", "an", "ap", "au", "az", "ba", "bb", "bc", "bd", "be", "bf", "bg", "bh", "bi", "bj", "bo", "br", "bs", "bu", "bz", "ca", "cb", "cc", "ce", "cp", "cu", "cz", "da", "db", "dc", "dd", "de", "df", "dg", "dh", "dl", "dz", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 5, 2, 2, ArrValue3, strFieldCode)
            ' Kie^?m tra 07
            Dim ArrValue9() = {" ", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 7, 1, 1, ArrValue9, strFieldCode)
            ' Kie^?m tra 08
            Dim ArrValue4() As String = {"a", "b", "c", "d", "e", "f", "g", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 8, 1, 1, ArrValue4, strFieldCode)
            ' Kie^?m tra 09-10
            Dim ArrValue10() = {" ", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 9, 2, 2, ArrValue10, strFieldCode)
            ' Kie^?m tra 11
            Dim ArrValue5() As String = {" ", "a", "c", "f", "i", "l", "m", "o", "s", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 11, 1, 1, ArrValue5, strFieldCode)
            ' Kie^?m tra 12
            Dim ArrValue6() As String = {" ", "a", "b", "c", "d", "f", "r", "s", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 12, 1, 1, ArrValue6, strFieldCode)
            ' Kie^?m tra 13
            Dim ArrValue11() = {" ", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 13, 1, 1, ArrValue11, strFieldCode)
            ' Kie^?m tra 14
            Dim ArrValue7() As String = {"|", "0", "1"}
            strOutMsg = strOutMsg & CheckValue(val, 14, 1, 1, ArrValue7, strFieldCode)
            ' Kie^?m tra 15
            Dim ArrValue12() = {" ", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 15, 1, 1, ArrValue12, strFieldCode)
            ' Kie^?m tra 16-17
            Dim ArrValue8() As String = {" ", "e", "j", "k", "l", "n", "o", "p", "r", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 16, 2, 2, ArrValue8, strFieldCode)
            ' Tra? la.i ke^'t qua?
            Check006_Maps = Trim(strOutMsg)
        End Function
        ' Check006 method
        ' Purpose: validate value of field006
        ' Input: value of field006
        ' Output: string value of ErrorMessage
        ' Creator: chuyenpt (09/08/07)
        Public Function Check006_MixMaterials(ByVal val As String, ByVal strFieldCode As String) As String
            Dim strOutMsg As String = ""

            ' Kie^?m tra 00
            Dim ArrValue1() = {"p"}
            strOutMsg = strOutMsg & CheckValue(val, 0, 1, 1, ArrValue1, strFieldCode)
            ' Kie^?m tra 01-05
            Dim ArrValue2() = {" ", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 1, 5, 2, ArrValue2, strFieldCode)
            ' Kie^?m tra 06 (Form of item- A one-character code that indicates the form of material for the item)
            Dim ArrValue3() As String = {" ", "a", "b", "c", "d", "f", "r", "s", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 6, 1, 1, ArrValue3, strFieldCode)
            ' Kie^?m tra 07-17
            Dim ArrValue4() = {" ", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 7, 11, 2, ArrValue4, strFieldCode)

            ' Tra? la.i ke^'t qua?
            Check006_MixMaterials = Trim(strOutMsg)
        End Function
        ' Check006 method
        ' Purpose: validate value of field006
        ' Input: value of field006
        ' Output: string value of ErrorMessage
        ' Creator: chuyenpt (09/08/07)
        Public Function Check006_Music(ByVal val As String, ByVal strFieldCode As String) As String
            Dim strOutMsg As String = ""

            ' Kie^?m tra 00
            Dim ArrValue1() = {"c", "d", "i", "j"}
            strOutMsg = strOutMsg & CheckValue(val, 0, 1, 1, ArrValue1, strFieldCode)
            ' Kie^?m tra 01-02 (Form of composition)
            Dim ArrValue2() As String = {"an", "bd", "bg", "bl", "bt", "ca", "cb", "cc", "cg", "ch", "cl", "cn", "co", "cp", "cr", "cs", "ct", "cy", "cz", "df", "dv", "fg", "fm", "ft", "gm", "hy", "jz", "mc", "md", "mi", "mo", "mp", "mr", "ms", "mu", "mz", "nc", "nn", "op", "or", "ov", "pg", "pm", "po", "pp", "pr", "ps", "pt", "pv", "rc", "rd", "rg", "ri", "rp", "rq", "sd", "sg", "sn", "sp", "st", "su", "sy", "tc", "ts", "uu", "vr", "wz", "zz", "||"}
            strOutMsg = strOutMsg & CheckValue(val, 1, 2, 1, ArrValue2, strFieldCode)
            ' Kie^?m tra 03 (Format of music- A one-character code that indicates the format of a musical composition)
            Dim ArrValue3() As String = {"a", "b", "c", "d", "e", "g", "m", "n", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 3, 1, 1, ArrValue3, strFieldCode)
            ' Kie^?m tra 04 (Music parts)
            Dim ArrValue4() As String = {" ", "d", "e", "f", "n", "u", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 4, 1, 1, ArrValue4, strFieldCode)
            ' Kie^?m tra 05 (Target audience)
            Dim ArrValue5() As String = {" ", "a", "b", "c", "d", "e", "f", "g", "j", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 5, 1, 1, ArrValue5, strFieldCode)
            ' Kie^?m tra 06 (Form of item)
            Dim ArrValue6() As String = {" ", "a", "b", "c", "d", "f", "r", "s", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 6, 1, 1, ArrValue6, strFieldCode)
            ' Kie^?m tra 07-12 (Accompanying matter- Up to six one-character codes (recorded in alphabetical order) that indicate the contents of program notes and other accompanying material for the sound recording, manuscript notated music, or notated music. If fewer than six codes are assigned, the codes are left justified and each unused position contains a blank)
            Dim ArrValue7() As String = {" ", "a", "b", "c", "d", "e", "f", "g", "h", "i", "k", "r", "s", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 7, 5, 2, ArrValue7, strFieldCode)
            ' Kie^?m tra 13-14 (Literary text for sound recordings- Up to two one-character codes (recorded in the order of the following list) that indicate the type of literary text contained in a nonmusical sound recording. If only one code is assigned, it is left justified and the unused position contains a blank (#).)
            Dim ArrValue8() As String = {" ", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "r", "s", "t", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 13, 2, 2, ArrValue8, strFieldCode)
            ' Kie^?m tra 15
            Dim ArrValue10() = {" ", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 15, 1, 1, ArrValue10, strFieldCode)
            ' Kie^?m tra 16 (Transposition and arrangement)
            Dim ArrValue9() As String = {" ", "a", "b", "c", "n", "u", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 16, 1, 1, ArrValue9, strFieldCode)
            ' Kie^?m tra 17
            Dim ArrValue11() = {" ", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 17, 1, 1, ArrValue11, strFieldCode)

            Check006_Music = Trim(strOutMsg)
        End Function
        ' Check006 method
        ' Purpose: validate value of field006
        ' Input: value of field006
        ' Output: string value of ErrorMessage
        ' Creator: chuyenpt (09/08/07)
        Public Function Check006_ConResources(ByVal val As String, ByVal strFieldCode As String) As String
            Dim strOutMsg As String = ""

            ' Kie^?m tra 00
            Dim ArrValue1() = {"s"}
            strOutMsg = strOutMsg & CheckValue(val, 0, 1, 1, ArrValue1, strFieldCode)
            ' Kie^?m tra 01 (Frequency- A one-character code that indicates the frequency of an item; used in conjunction with 008/19 (Regularity).)
            Dim ArrValue2() As String = {" ", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "m", "q", "s", "t", "u", "w", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 1, 1, 1, ArrValue2, strFieldCode)
            ' Kie^?m tra 02 (Regularity- A one-character code that indicates the intended regularity of an item; used in conjunction with 008/18 (Frequency).)
            Dim ArrValue3() As String = {"n", "r", "u", "x", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 2, 1, 1, ArrValue3, strFieldCode)
            ' Kie^?m tra 03
            Dim ArrValue13() = {" ", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 3, 1, 1, ArrValue13, strFieldCode)
            ' Kie^?m tra 04 (Type of continuing resource- A one-character code that indicates the type of continuing resource.)
            Dim ArrValue4() As String = {" ", "d", "l", "m", "n", "p", "w", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 4, 1, 1, ArrValue4, strFieldCode)
            ' Kie^?m tra 05 (Form of original item- A one-character code that indicates the form of material in which an item was originally published)
            Dim ArrValue5() As String = {" ", "a", "b", "c", "d", "e", "f", "s"}
            strOutMsg = strOutMsg & CheckValue(val, 5, 1, 1, ArrValue5, strFieldCode)
            ' Kie^?m tra 06 (Form of item- A one-character code that indicates the form of material for the item being described)
            Dim ArrValue6() As String = {" ", "a", "b", "c", "d", "f", "r", "s", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 6, 1, 1, ArrValue6, strFieldCode)
            ' Kie^?m tra 07 (Nature of entire work- A one-character code that indicates the nature of an item if it consists entirely of a certain type of material. If more than one code is applicable, 008/24 contains a blank (#) and up to three codes may be recorded in 008/25-27 (Nature of contents). )
            Dim ArrValue7() As String = {" ", "a", "b", "c", "d", "e", "f", "g", "h", "i", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 7, 1, 1, ArrValue7, strFieldCode)
            ' Kie^?m tra 08-10 (Nature of contents- Up to three one-character codes (recorded in alphabetical order) that indicate that a work contains certain types of materials. If fewer than three codes are assigned, the codes are left justified and each unused position contains a blank (#). )
            Dim ArrValue8() As String = {" ", "a", "b", "c", "d", "e", "f", "g", "h", "i", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 8, 3, 2, ArrValue8, strFieldCode)
            ' Kie^?m tra 11 (Government publication- A one-character code that indicates whether an item is published or produced by or for a government agency, and, if so, the jurisdictional level of the agency)
            Dim ArrValue9() As String = {" ", "a", "c", "f", "i", "l", "m", "o", "s", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 11, 1, 1, ArrValue9, strFieldCode)
            ' Kie^?m tra 12 (Conference publication- A one-character code that indicates whether an item consists of the proceedings, reports, or summaries of a conference. )
            Dim ArrValue10() As String = {"|", "0", "1"}
            strOutMsg = strOutMsg & CheckValue(val, 12, 1, 1, ArrValue10, strFieldCode)
            ' Kie^?m tra 13-15
            Dim ArrValue14() = {" ", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 13, 3, 2, ArrValue14, strFieldCode)
            ' Kie^?m tra 16 (Original alphabet or script of title- A one-character code that indicates the original alphabet or script of the language of the title on the source item upon which the key title (field 222) is based)
            Dim ArrValue11() As String = {" ", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 16, 1, 1, ArrValue11, strFieldCode)
            ' Kie^?m tra 17 (Entry convention- A one-character code that indicates whether an item was cataloged according to successive entry, latest entry or integrated entry cataloging conventions.)
            Dim ArrValue12() As String = {"|", "0", "1", "2"}
            strOutMsg = strOutMsg & CheckValue(val, 17, 1, 1, ArrValue12, strFieldCode)

            ' Tra? la.i ke^'t qua?
            Check006_ConResources = Trim(strOutMsg)
        End Function
        ' Check006 method
        ' Purpose: validate value of field006
        ' Input: value of field006
        ' Output: string value of ErrorMessage
        ' Creator: chuyenpt (09/08/07)
        Public Function Check006_VisMaterials(ByVal val As String, ByVal strFieldCode As String) As String
            Dim strOutMsg As String = ""

            ' Kie^?m tra 00
            Dim ArrValue6() = {"g", "k", "o", "r"}
            strOutMsg = strOutMsg & CheckValue(val, 0, 1, 1, ArrValue6, strFieldCode)
            ' Kiem tra 01-03
            strOutMsg = strOutMsg & Me.CheckValue18_20OfVis(val, 2, 3, 2, strFieldCode)
            ' Kie^?m tra 04
            Dim ArrValue7() = {" ", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 4, 1, 1, ArrValue7, strFieldCode)
            ' Kiem tra 05
            Dim ArrValue1() As String = {" ", "a", "b", "c", "d", "e", "f", "g", "j", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 5, 1, 1, ArrValue1, strFieldCode)
            ' Kie^?m tra 06-10
            Dim ArrValue8() = {" ", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 6, 5, 2, ArrValue8, strFieldCode)
            ' Kiem tra 11
            Dim ArrValue2() As String = {" ", "a", "c", "f", "i", "l", "m", "o", "s", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 11, 1, 1, ArrValue2, strFieldCode)
            ' Kiem tra 12
            Dim ArrValue3() As String = {" ", "a", "b", "c", "d", "f", "r", "s", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 12, 1, 1, ArrValue3, strFieldCode)
            ' Kie^?m tra 13-15
            Dim ArrValue9() = {" ", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 13, 3, 2, ArrValue9, strFieldCode)
            ' Kiem tra 16
            Dim ArrValue4() As String = {"a", "b", "c", "d", "f", "g", "i", "k", "n", "m", "o", "p", "q", "r", "s", "t", "v", "w", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 16, 1, 1, ArrValue4, strFieldCode)
            ' Kiem tra 17
            Dim ArrValue5() As String = {"a", "c", "l", "n", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 17, 1, 1, ArrValue5, strFieldCode)

            ' Tra? la.i ke^'t qua?
            Check006_VisMaterials = Trim(strOutMsg)
        End Function
        ' Check008 method
        ' Purpose: validate value of field008
        ' Input: value of field008
        ' Output: string value of ErrorMessage
        ' Creator: chuyenpt (3/8/07)
        Public Function Check008Authory(ByVal val As String, ByVal strFieldCode As String) As String
            Dim strOutMsg As String = ""

            ' Kie^?m tra ddo^. da`i
            If Len(val) > 40 Or Len(val) < 40 Then
                strOutMsg = strOutMsg & strFieldCode & ": " & strLblViewDefaul & "\n"
            End If
            ' Kiem tra 00-05
            strOutMsg = strOutMsg & CheckDate008(val, 0, 6, strFieldCode)
            ' Kiem tra 06
            Dim ArrValue01() As String = {" ", "d", "i", "n", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 6, 1, 1, ArrValue01, strFieldCode)
            ' Kiem tra 07
            Dim ArrValue02() As String = {"a", "b", "c", "d", "e", "f", "g", "n", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 7, 1, 1, ArrValue02, strFieldCode)
            ' Kiem tra 08
            Dim ArrValue03() As String = {" ", "b", "e", "f", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 8, 1, 1, ArrValue03, strFieldCode)
            ' Kiem tra 09
            Dim ArrValue04() As String = {"a", "b", "c", "d", "e", "f", "g"}
            strOutMsg = strOutMsg & CheckValue(val, 9, 1, 1, ArrValue04, strFieldCode)
            ' Kiem tra 10
            Dim ArrValue05() As String = {"a", "b", "c", "d", "z", "n", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 10, 1, 1, ArrValue05, strFieldCode)
            ' Kiem tra 11
            Dim ArrValue06() As String = {"a", "b", "c", "d", "k", "n", "r", "s", "v", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 11, 1, 1, ArrValue06, strFieldCode)
            ' Kiem tra 12
            Dim ArrValue07() As String = {"a", "b", "c", "n", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 12, 1, 1, ArrValue07, strFieldCode)
            ' Kiem tra 13
            Dim ArrValue08() As String = {"a", "b", "c", "n", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 13, 1, 1, ArrValue08, strFieldCode)
            ' Kiem tra 14
            Dim ArrValue09() As String = {"a", "b", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 14, 1, 1, ArrValue09, strFieldCode)
            ' Kiem tra 15
            Dim ArrValue10() As String = {"a", "b", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 15, 1, 1, ArrValue10, strFieldCode)
            ' Kiem tra 16
            Dim ArrValue11() As String = {"a", "b", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 16, 1, 1, ArrValue11, strFieldCode)
            ' Kiem tra 17
            Dim ArrValue12() As String = {"a", "b", "c", "d", "e", "n", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 17, 1, 1, ArrValue12, strFieldCode)
            ' Kiem tra 18-27
            Dim ArrValue13() As String = {" ", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 18, 10, 2, ArrValue13, strFieldCode)
            ' Kiem tra 28
            Dim ArrValue14() As String = {" ", "a", "f", "c", "i", "l", "m", "o", "s", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 28, 1, 1, ArrValue14, strFieldCode)
            ' Kiem tra 29
            Dim ArrValue15() As String = {"a", "b", "n", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 29, 1, 1, ArrValue15, strFieldCode)
            ' Kiem tra 30
            Dim ArrValue16() As String = {" ", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 30, 1, 1, ArrValue16, strFieldCode)
            ' Kiem tra 31
            Dim ArrValue17() As String = {"a", "b", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 31, 1, 1, ArrValue17, strFieldCode)
            ' Kiem tra 32
            Dim ArrValue18() As String = {"a", "b", "n", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 32, 1, 1, ArrValue18, strFieldCode)
            ' Kiem tra 33
            Dim ArrValue19() As String = {"a", "b", "c", "d", "n", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 33, 1, 1, ArrValue19, strFieldCode)
            ' Kiem tra 34-37
            Dim ArrValue20() As String = {" ", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 34, 4, 2, ArrValue20, strFieldCode)
            ' Kiem tra 38
            Dim ArrValue21() As String = {" ", "s", "x", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 38, 1, 1, ArrValue21, strFieldCode)
            ' Kiem tra 39
            Dim ArrValue22() As String = {" ", "c", "d", "u", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 39, 1, 1, ArrValue22, strFieldCode)
            ' Ket qua
            Check008Authory = Trim(strOutMsg)
        End Function
        ' Check007 method
        ' Purpose: validate value of field007
        ' Input: value of field007
        ' Output: string value of ErrorMessage
        ' Creator: chuyenpt (08/08/07)
        Public Function Check007_Text(ByVal val As String, ByVal strFieldCode As String) As String
            Dim strOutMsg As String = ""
            ' Kiem tra vi tri 00
            Dim ArrValue1() = {"t"}
            strOutMsg = strOutMsg & CheckValue(val, 0, 1, 1, ArrValue1, strFieldCode)
            ' Kiem tra vi tri 01
            Dim ArrValue2() = {"a", "b", "c", "d", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 1, 1, 1, ArrValue2, strFieldCode)

            Check007_Text = Trim(strOutMsg)
        End Function
        ' Check007 method
        ' Purpose: validate value of field007
        ' Input: value of field007
        ' Output: string value of ErrorMessage
        ' Creator: chuyenpt (08/08/07)
        Public Function Check007_Kit(ByVal val As String, ByVal strFieldCode As String) As String
            Dim strOutMsg As String = ""
            ' Kiem tra vi tri 00
            Dim ArrValue1() = {"o"}
            strOutMsg = strOutMsg & CheckValue(val, 0, 1, 1, ArrValue1, strFieldCode)
            ' Kiem tra vi tri 01
            Dim ArrValue2() = {"u", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 1, 1, 1, ArrValue2, strFieldCode)

            Check007_Kit = Trim(strOutMsg)
        End Function
        ' Check007 method
        ' Purpose: validate value of field007
        ' Input: value of field007
        ' Output: string value of ErrorMessage
        ' Creator: chuyenpt (08/08/07)
        Public Function Check007_Maps(ByVal val As String, ByVal strFieldCode As String) As String
            Dim strOutMsg As String = ""
            ' Kiem tra vi tri 00
            Dim ArrValue1() = {"a"}
            strOutMsg = strOutMsg & CheckValue(val, 0, 1, 1, ArrValue1, strFieldCode)
            ' Kiem tra vi tri 01
            Dim ArrValue2() = {"d", "g", "j", "k", "q", "r", "s", "u", "y", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 1, 1, 1, ArrValue2, strFieldCode)
            ' Kiem tra vi tri 03
            Dim ArrValue3() = {"a", "c", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 3, 1, 1, ArrValue3, strFieldCode)
            ' Kiem tra vi tri 04
            Dim ArrValue4() = {"a", "b", "c", "d", "e", "f", "g", "j", "p", "q", "r", "s", "t", "u", "y", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 4, 1, 1, ArrValue4, strFieldCode)
            ' Kiem tra vi tri 05
            Dim ArrValue5() = {"f", "n", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 5, 1, 1, ArrValue5, strFieldCode)
            ' Kiem tra vi tri 06
            Dim ArrValue6() = {"a", "b", "c", "d", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 6, 1, 1, ArrValue6, strFieldCode)
            ' Kiem tra vi tri 07
            Dim ArrValue7() = {"a", "b", "m", "n", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 7, 1, 1, ArrValue7, strFieldCode)

            Check007_Maps = Trim(strOutMsg)
        End Function
        ' Check007 method
        ' Purpose: validate value of field007
        ' Input: value of field007
        ' Output: string value of ErrorMessage
        ' Creator: chuyenpt (08/08/07)
        Public Function Check007_Tactile(ByVal val As String, ByVal strFieldCode As String) As String
            Dim strOutMsg As String = ""
            ' Kiem tra vi tri 00
            Dim ArrValue1() = {"f"}
            strOutMsg = strOutMsg & CheckValue(val, 0, 1, 1, ArrValue1, strFieldCode)
            ' Kiem tra vi tri 01
            Dim ArrValue2() = {"a", "b", "c", "d", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 1, 1, 1, ArrValue2, strFieldCode)
            ' Kiem tra vi tri 03-04
            Dim ArrValue3() = {"a", "b", "c", "d", "e", "m", "n", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 3, 2, 2, ArrValue3, strFieldCode)
            ' Kiem tra vi tri 05
            Dim ArrValue5() = {"a", "b", "m", "n", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 5, 1, 1, ArrValue5, strFieldCode)
            ' Kiem tra vi tri 06-08
            Dim ArrValue6() = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "n", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 6, 3, 2, ArrValue6, strFieldCode)
            ' Kiem tra vi tri 09
            Dim ArrValue7() = {"a", "b", "u", "n", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 9, 1, 1, ArrValue7, strFieldCode)

            Check007_Tactile = Trim(strOutMsg)
        End Function
        ' Check007 method
        ' Purpose: validate value of field007
        ' Input: value of field007
        ' Output: string value of ErrorMessage
        ' Creator: chuyenpt (08/08/07)
        Public Function Check007_Nonprojected(ByVal val As String, ByVal strFieldCode As String) As String
            Dim strOutMsg As String = ""
            ' Kiem tra vi tri 00
            Dim ArrValue1() = {"k"}
            strOutMsg = strOutMsg & CheckValue(val, 0, 1, 1, ArrValue1, strFieldCode)
            ' Kiem tra vi tri 01
            Dim ArrValue2() = {"c", "d", "e", "f", "g", "h", "i", "j", "l", "n", "o", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 1, 1, 1, ArrValue2, strFieldCode)
            ' Kiem tra vi tri 03
            Dim ArrValue3() = {"a", "b", "c", "h", "m", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 3, 1, 1, ArrValue3, strFieldCode)
            ' Kiem tra vi tri 04
            Dim ArrValue4() = {"a", "b", "c", "d", "e", "f", "g", "h", "m", "o", "p", "q", "r", "s", "t", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 4, 1, 1, ArrValue4, strFieldCode)
            ' Kiem tra vi tri 05
            Dim ArrValue5() = {" ", "a", "b", "c", "d", "e", "f", "g", "h", "m", "o", "p", "q", "r", "s", "t", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 5, 1, 1, ArrValue5, strFieldCode)

            Check007_Nonprojected = Trim(strOutMsg)
        End Function
        ' Check007 method
        ' Purpose: validate value of field007
        ' Input: value of field007
        ' Output: string value of ErrorMessage
        ' Creator: chuyenpt (08/08/07)
        Public Function Check007_Electronic(ByVal val As String, ByVal strFieldCode As String) As String
            Dim strOutMsg As String = ""
            ' Kiem tra vi tri 00
            Dim ArrValue1() = {"c"}
            strOutMsg = strOutMsg & CheckValue(val, 0, 1, 1, ArrValue1, strFieldCode)
            ' Kiem tra vi tri 01
            Dim ArrValue2() = {"a", "b", "c", "f", "h", "j", "m", "r", "u", "o", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 1, 1, 1, ArrValue2, strFieldCode)
            ' Kiem tra vi tri 03
            Dim ArrValue3() = {"a", "b", "c", "g", "m", "n", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 3, 1, 1, ArrValue3, strFieldCode)
            ' Kiem tra vi tri 04
            Dim ArrValue4() = {"a", "e", "g", "i", "j", "n", "o", "u", "v", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 4, 1, 1, ArrValue4, strFieldCode)
            ' Kiem tra vi tri 05
            Dim ArrValue5() = {" ", "a", "u", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 5, 1, 1, ArrValue5, strFieldCode)
            ' Kiem tra vi tri 06-08
            strOutMsg = strOutMsg & CheckValue18_20OfVis(val, 6, 3, 2, strFieldCode)
            ' Kiem tra vi tri 09
            Dim ArrValue7() = {"a", "m", "u", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 9, 1, 1, ArrValue7, strFieldCode)
            ' Kiem tra vi tri 10
            Dim ArrValue8() = {"a", "n", "p", "u", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 10, 1, 1, ArrValue8, strFieldCode)
            ' Kiem tra vi tri 11
            Dim ArrValue9() = {"a", "b", "c", "d", "m", "n", "u", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 11, 1, 1, ArrValue9, strFieldCode)
            ' Kiem tra vi tri 12
            Dim ArrValue10() = {"a", "b", "d", "m", "u", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 12, 1, 1, ArrValue10, strFieldCode)
            ' Kiem tra vi tri 13
            Dim ArrValue11() = {"a", "p", "r", "n", "u", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 13, 1, 1, ArrValue11, strFieldCode)

            Check007_Electronic = Trim(strOutMsg)
        End Function
        ' Check007 method
        ' Purpose: validate value of field007
        ' Input: value of field007
        ' Output: string value of ErrorMessage
        ' Creator: chuyenpt (08/08/07)
        Public Function Check007_Sound(ByVal val As String, ByVal strFieldCode As String) As String
            Dim strOutMsg As String = ""
            ' Kiem tra vi tri 00
            Dim ArrValue1() = {"s"}
            strOutMsg = strOutMsg & CheckValue(val, 0, 1, 1, ArrValue1, strFieldCode)
            ' Kiem tra vi tri 01
            Dim ArrValue2() = {"d", "e", "r", "i", "q", "s", "t", "u", "w", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 1, 1, 1, ArrValue2, strFieldCode)
            ' Kiem tra vi tri 03
            Dim ArrValue3() = {"a", "b", "c", "g", "i", "k", "l", "m", "o", "p", "r", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 3, 1, 1, ArrValue3, strFieldCode)
            ' Kiem tra vi tri 04
            Dim ArrValue4() = {"m", "q", "u", "s", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 4, 1, 1, ArrValue4, strFieldCode)
            ' Kiem tra vi tri 05
            Dim ArrValue5() = {"m", "n", "u", "s", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 5, 1, 1, ArrValue5, strFieldCode)
            ' Kiem tra vi tri 06
            Dim ArrValue6() = {"a", "b", "c", "d", "e", "f", "g", "j", "o", "n", "u", "s", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 6, 1, 1, ArrValue6, strFieldCode)
            ' Kiem tra vi tri 07
            Dim ArrValue12() = {"n", "m", "l", "p", "o", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 7, 1, 1, ArrValue12, strFieldCode)
            ' Kiem tra vi tri 08
            Dim ArrValue13() = {"a", "b", "c", "d", "e", "f", "n", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 8, 1, 1, ArrValue13, strFieldCode)
            ' Kiem tra vi tri 09
            Dim ArrValue7() = {"a", "b", "d", "i", "m", "n", "r", "s", "t", "z", "u", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 9, 1, 1, ArrValue7, strFieldCode)
            ' Kiem tra vi tri 10
            Dim ArrValue8() = {"a", "b", "c", "g", "i", "l", "m", "p", "r", "s", "w", "z", "u", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 10, 1, 1, ArrValue8, strFieldCode)
            ' Kiem tra vi tri 11
            Dim ArrValue9() = {"h", "l", "n", "u", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 11, 1, 1, ArrValue9, strFieldCode)
            ' Kiem tra vi tri 12
            Dim ArrValue10() = {"a", "b", "c", "d", "e", "f", "g", "h", "n", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 12, 1, 1, ArrValue10, strFieldCode)
            ' Kiem tra vi tri 13
            Dim ArrValue11() = {"a", "b", "d", "e", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 13, 1, 1, ArrValue11, strFieldCode)

            Check007_Sound = Trim(strOutMsg)
        End Function
        ' Check007 method
        ' Purpose: validate value of field007
        ' Input: value of field007
        ' Output: string value of ErrorMessage
        ' Creator: chuyenpt (08/08/07)
        Public Function Check007_Motion(ByVal val As String, ByVal strFieldCode As String) As String
            Dim strOutMsg As String = ""
            ' Kiem tra vi tri 00
            Dim ArrValue1() = {"m"}
            strOutMsg = strOutMsg & CheckValue(val, 0, 1, 1, ArrValue1, strFieldCode)
            ' Kiem tra vi tri 01
            Dim ArrValue2() = {"c", "f", "r", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 1, 1, 1, ArrValue2, strFieldCode)
            ' Kiem tra vi tri 03
            Dim ArrValue3() = {"b", "c", "h", "m", "n", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 3, 1, 1, ArrValue3, strFieldCode)
            ' Kiem tra vi tri 04
            Dim ArrValue4() = {"a", "b", "c", "d", "e", "f", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 4, 1, 1, ArrValue4, strFieldCode)
            ' Kiem tra vi tri 05
            Dim ArrValue5() = {" ", "a", "b", "u", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 5, 1, 1, ArrValue5, strFieldCode)
            ' Kiem tra vi tri 06
            Dim ArrValue6() = {" ", "a", "b", "c", "d", "e", "f", "g", "h", "i", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 6, 1, 1, ArrValue6, strFieldCode)
            ' Kiem tra vi tri 07
            Dim ArrValue12() = {"a", "b", "c", "d", "e", "f", "g", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 7, 1, 1, ArrValue12, strFieldCode)
            ' Kiem tra vi tri 08
            Dim ArrValue13() = {"k", "m", "q", "s", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 8, 1, 1, ArrValue13, strFieldCode)
            ' Kiem tra vi tri 09
            Dim ArrValue7() = {"a", "b", "c", "d", "e", "f", "g", "n", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 9, 1, 1, ArrValue7, strFieldCode)
            ' Kiem tra vi tri 10
            Dim ArrValue8() = {"a", "b", "n", "z", "u", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 10, 1, 1, ArrValue8, strFieldCode)
            ' Kiem tra vi tri 11
            Dim ArrValue9() = {"d", "e", "o", "u", "r", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 11, 1, 1, ArrValue9, strFieldCode)
            ' Kiem tra vi tri 12
            Dim ArrValue10() = {"a", "p", "c", "d", "r", "t", "i", "m", "n", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 12, 1, 1, ArrValue10, strFieldCode)
            ' Kiem tra vi tri 13
            Dim ArrValue11() = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "u", "v", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 13, 1, 1, ArrValue11, strFieldCode)
            ' Kiem tra vi tri 14
            Dim ArrValue14() = {"a", "b", "c", "d", "n", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 14, 1, 1, ArrValue14, strFieldCode)
            ' Kiem tra vi tri 15
            Dim ArrValue15() = {"a", "b", "c", "d", "e", "f", "g", "h", "k", "l", "m", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 15, 1, 1, ArrValue15, strFieldCode)
            ' Kiem tra vi tri 16
            Dim ArrValue16() = {"c", "i", "n", "u", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 16, 1, 1, ArrValue16, strFieldCode)
            ' Kiem tra vi tri 17-22
            strOutMsg = strOutMsg & CheckDate007(val, 17, 6, strFieldCode)

            Check007_Motion = Trim(strOutMsg)
        End Function
        ' Check008 method
        ' Purpose: validate value of field008
        ' Input: value of field008
        ' Output: string value of ErrorMessage
        ' Creator: chuyenpt
        Public Function Check008(ByVal val As String, ByVal strFieldCode As String) As String
            Dim strOutMsg As String = ""

            ' Kie^?m tra ddo^. da`i
            If Len(val) > 40 Or Len(val) < 40 Then
                strOutMsg = strOutMsg & strFieldCode & ": " & strLblViewDefaul & "\n"
            End If
            ' Kiem tra 00-05
            strOutMsg = strOutMsg & CheckDate008(val, 0, 6, strFieldCode)
            ' Kiem tra 06
            Dim ArrValue06() As String = {"b", "c", "d", "e", "i", "k", "n", "m", "p", "q", "r", "s", "t", "u", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 6, 1, 1, ArrValue06, strFieldCode)
            ' Kiem tra 07-10
            Dim ArrValue07_10() As String = {" ", "u", "|", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"}
            strOutMsg = strOutMsg & CheckValue(val, 7, 4, 2, ArrValue07_10, strFieldCode)
            ' Kiem tra 11-14
            Dim ArrValue11_14() As String = {" ", "u", "|", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"}
            strOutMsg = strOutMsg & CheckValue(val, 11, 4, 2, ArrValue11_14, strFieldCode)
            ' Kiem tra 15-17
            ' Kiem tra 35-37
            ' Kie^?m tra 38
            Dim ArrValue12() As String = {" ", "d", "o", "r", "s", "x", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 38, 1, 1, ArrValue12, strFieldCode)
            ' Kie^?m tra 39
            Dim ArrValue13() As String = {" ", "c", "d", "u", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 39, 1, 1, ArrValue13, strFieldCode)
            ' Ket qua
            Check008 = Trim(strOutMsg)
        End Function

        ' Check008Book method
        ' Purpose: validate value of field008
        ' Input: value of field008
        ' Output: string value of ErrorMessage
        ' Creator: Sondp
        Public Function Check008Book(ByVal val As String, ByVal strFieldCode As String) As String
            Dim strOutMsg As String = ""

            ' Kie^?m tra 18-21
            Dim ArrValue2() As String = {" ", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "o", "p", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 18, 4, 2, ArrValue2, strFieldCode)
            ' Kie^?m tra 22
            Dim ArrValue3() As String = {" ", "a", "b", "c", "d", "e", "f", "g", "j", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 22, 1, 1, ArrValue3, strFieldCode)
            ' Kie^?m tra 23
            Dim ArrValue4() As String = {" ", "a", "b", "c", "d", "f", "r", "s", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 23, 1, 1, ArrValue4, strFieldCode)
            ' Kie^?m tra 24-27
            Dim ArrValue5() As String = {" ", "a", "b", "c", "d", "e", "f", "g", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 24, 4, 2, ArrValue5, strFieldCode)
            ' Kie^?m tra 28
            Dim ArrValue6() As String = {" ", "a", "c", "f", "i", "l", "m", "o", "s", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 28, 1, 1, ArrValue6, strFieldCode)
            ' Kie^?m tra 29
            Dim ArrValue7() As String = {"0", "1", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 29, 1, 1, ArrValue7, strFieldCode)
            ' Kie^?m tra 30
            Dim ArrValue8() As String = {"|", "0", "1"}
            strOutMsg = strOutMsg & CheckValue(val, 30, 1, 1, ArrValue8, strFieldCode)
            ' Kie^?m tra 31
            Dim ArrValue9() As String = {"|", "0", "1"}
            strOutMsg = strOutMsg & CheckValue(val, 31, 1, 1, ArrValue9, strFieldCode)
            ' Kie^?m tra 33
            Dim ArrValue10() As String = {"|", "0", "1", "c", "d", "e", "f", "h", "i", "j", "m", "p", "s", "u"}
            strOutMsg = strOutMsg & CheckValue(val, 33, 1, 1, ArrValue10, strFieldCode)
            ' Kie^?m tra 34
            Dim ArrValue11() As String = {" ", "a", "b", "c", "d", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 34, 1, 1, ArrValue11, strFieldCode)
            ' Tra? la.i ke^'t qua?
            Check008Book = Trim(strOutMsg)
        End Function

        ' Check008ComputerFile method
        ' Purpose: validate value of field008
        ' Input: value of field008
        ' Output: string value of ErrorMessage
        ' Creator: Sondp
        Public Function Check008ComputerFile(ByVal val As String, ByVal strFieldCode As String) As String
            Dim strOutMsg As String = ""

            ' Kie^?m tra 22
            Dim ArrValue2() As String = {" ", "a", "b", "c", "d", "e", "f", "g", "j", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 22, 1, 1, ArrValue2, strFieldCode)
            ' Kie^?m tra 26
            Dim ArrValue3() As String = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "m", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 26, 1, 1, ArrValue3, strFieldCode)
            ' Kie^?m tra 28
            Dim ArrValue4() As String = {" ", "a", "c", "f", "i", "l", "m", "o", "s", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 28, 1, 1, ArrValue4, strFieldCode)
            ' Tra? la.i ke^'t qua?
            Check008ComputerFile = Trim(strOutMsg)
        End Function

        ' Check008Maps method
        ' Purpose: validate value of field008
        ' Input: value of field008
        ' Output: string value of ErrorMessage
        ' Creator: Sondp
        Public Function Check008Maps(ByVal val As String, ByVal strFieldCode As String) As String
            Dim strOutMsg As String = ""

            ' Kie^?m tra 18-21
            Dim ArrValue2() As String = {" ", "a", "b", "c", "d", "e", "f", "g", "i", "j", "k", "m", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 18, 4, 2, ArrValue2, strFieldCode)
            ' Kie^?m tra 22-23
            Dim ArrValue3() As String = {"  ", "aa", "ab", "ac", "ad", "ae", "af", "ag", "am", "an", "ap", "au", "az", "ba", "bb", "bc", "bd", "be", "bf", "bg", "bh", "bi", "bj", "bo", "br", "bs", "bu", "bz", "ca", "cb", "cc", "ce", "cp", "cu", "cz", "da", "db", "dc", "dd", "de", "df", "dg", "dh", "dl", "dz", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 22, 2, 1, ArrValue3, strFieldCode)
            ' Kie^?m tra 25
            Dim ArrValue4() As String = {"a", "b", "c", "d", "e", "f", "g", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 25, 1, 1, ArrValue4, strFieldCode)
            ' Kie^?m tra 28
            Dim ArrValue5() As String = {" ", "a", "c", "f", "i", "l", "m", "o", "s", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 28, 1, 1, ArrValue5, strFieldCode)
            ' Kie^?m tra 29
            Dim ArrValue6() As String = {" ", "a", "b", "c", "d", "f", "r", "s", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 29, 1, 1, ArrValue6, strFieldCode)
            ' Kie^?m tra 31
            Dim ArrValue7() As String = {"|", "0", "1"}
            strOutMsg = strOutMsg & CheckValue(val, 31, 1, 1, ArrValue7, strFieldCode)
            ' Kie^?m tra 33-34
            Dim ArrValue8() As String = {" ", "e", "j", "k", "l", "n", "o", "p", "r", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 33, 2, 2, ArrValue8, strFieldCode)
            ' Tra? la.i ke^'t qua?
            Check008Maps = Trim(strOutMsg)
        End Function

        ' Check008Music method
        ' Purpose: validate value of field008
        ' Input: value of field008
        ' Output: string value of ErrorMessage
        ' Creator: Sondp
        Public Function Check008Music(ByVal val As String, ByVal strFieldCode As String) As String
            Dim strOutMsg As String = ""

            ' Kie^?m tra 18-19 (Form of composition)
            Dim ArrValue2() As String = {"an", "bd", "bg", "bl", "bt", "ca", "cb", "cc", "cg", "ch", "cl", "cn", "co", "cp", "cr", "cs", "ct", "cy", "cz", "df", "dv", "fg", "fm", "ft", "gm", "hy", "jz", "mc", "md", "mi", "mo", "mp", "mr", "ms", "mu", "mz", "nc", "nn", "op", "or", "ov", "pg", "pm", "po", "pp", "pr", "ps", "pt", "pv", "rc", "rd", "rg", "ri", "rp", "rq", "sd", "sg", "sn", "sp", "st", "su", "sy", "tc", "ts", "uu", "vr", "wz", "zz", "||"}
            strOutMsg = strOutMsg & CheckValue(val, 18, 2, 1, ArrValue2, strFieldCode)
            ' Kie^?m tra 20 (Format of music- A one-character code that indicates the format of a musical composition)
            Dim ArrValue3() As String = {"a", "b", "c", "d", "e", "g", "m", "n", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 20, 1, 1, ArrValue3, strFieldCode)
            ' Kie^?m tra 21 (Music parts)
            Dim ArrValue4() As String = {" ", "d", "e", "f", "n", "u", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 21, 1, 1, ArrValue4, strFieldCode)
            ' Kie^?m tra 22 (Target audience)
            Dim ArrValue5() As String = {" ", "a", "b", "c", "d", "e", "f", "g", "j", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 22, 1, 1, ArrValue5, strFieldCode)
            ' Kie^?m tra 23 (Form of item)
            Dim ArrValue6() As String = {" ", "a", "b", "c", "d", "f", "r", "s", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 23, 1, 1, ArrValue6, strFieldCode)
            ' Kie^?m tra 24-29 (Accompanying matter- Up to six one-character codes (recorded in alphabetical order) that indicate the contents of program notes and other accompanying material for the sound recording, manuscript notated music, or notated music. If fewer than six codes are assigned, the codes are left justified and each unused position contains a blank)
            Dim ArrValue7() As String = {" ", "a", "b", "c", "d", "e", "f", "g", "h", "i", "k", "r", "s", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 24, 5, 2, ArrValue7, strFieldCode)
            ' Kie^?m tra 30-31 (Literary text for sound recordings- Up to two one-character codes (recorded in the order of the following list) that indicate the type of literary text contained in a nonmusical sound recording. If only one code is assigned, it is left justified and the unused position contains a blank (#).)
            Dim ArrValue8() As String = {" ", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "r", "s", "t", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 30, 2, 2, ArrValue8, strFieldCode)
            ' Kie^?m tra 33 (Transposition and arrangement)
            Dim ArrValue9() As String = {" ", "a", "b", "c", "n", "u", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 33, 1, 1, ArrValue9, strFieldCode)
            Check008Music = Trim(strOutMsg)
        End Function

        ' Check008 CONTINUING RESOURCES method
        ' Purpose: validate value of field008
        ' Input: value of field008
        ' Output: string value of ErrorMessage
        ' Creator: Sondp
        Public Function Check008Con_Resources(ByVal val As String, ByVal strFieldCode As String) As String
            Dim strOutMsg As String = ""

            ' Kie^?m tra 18 (Frequency- A one-character code that indicates the frequency of an item; used in conjunction with 008/19 (Regularity).)
            Dim ArrValue2() As String = {" ", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "m", "q", "s", "t", "u", "w", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 18, 1, 1, ArrValue2, strFieldCode)
            ' Kie^?m tra 19 (Regularity- A one-character code that indicates the intended regularity of an item; used in conjunction with 008/18 (Frequency).)
            Dim ArrValue3() As String = {"n", "r", "u", "x", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 19, 1, 1, ArrValue3, strFieldCode)
            ' Kie^?m tra 21 (Type of continuing resource- A one-character code that indicates the type of continuing resource.)
            Dim ArrValue4() As String = {" ", "d", "l", "m", "n", "p", "w", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 21, 1, 1, ArrValue4, strFieldCode)
            ' Kie^?m tra 22 (Form of original item- A one-character code that indicates the form of material in which an item was originally published)
            Dim ArrValue5() As String = {" ", "a", "b", "c", "d", "e", "f", "s"}
            strOutMsg = strOutMsg & CheckValue(val, 22, 1, 1, ArrValue5, strFieldCode)
            ' Kie^?m tra 23 (Form of item- A one-character code that indicates the form of material for the item being described)
            Dim ArrValue6() As String = {" ", "a", "b", "c", "d", "f", "r", "s", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 23, 1, 1, ArrValue6, strFieldCode)
            ' Kie^?m tra 24 (Nature of entire work- A one-character code that indicates the nature of an item if it consists entirely of a certain type of material. If more than one code is applicable, 008/24 contains a blank (#) and up to three codes may be recorded in 008/25-27 (Nature of contents). )
            Dim ArrValue7() As String = {" ", "a", "b", "c", "d", "e", "f", "g", "h", "i", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 24, 1, 1, ArrValue7, strFieldCode)
            ' Kie^?m tra 25-27 (Nature of contents- Up to three one-character codes (recorded in alphabetical order) that indicate that a work contains certain types of materials. If fewer than three codes are assigned, the codes are left justified and each unused position contains a blank (#). )
            Dim ArrValue8() As String = {" ", "a", "b", "c", "d", "e", "f", "g", "h", "i", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 25, 3, 2, ArrValue8, strFieldCode)
            ' Kie^?m tra 28 (Government publication- A one-character code that indicates whether an item is published or produced by or for a government agency, and, if so, the jurisdictional level of the agency)
            Dim ArrValue9() As String = {" ", "a", "c", "f", "i", "l", "m", "o", "s", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 28, 1, 1, ArrValue9, strFieldCode)
            ' Kie^?m tra 29 (Conference publication- A one-character code that indicates whether an item consists of the proceedings, reports, or summaries of a conference. )
            Dim ArrValue10() As String = {"|", "0", "1"}
            strOutMsg = strOutMsg & CheckValue(val, 29, 1, 1, ArrValue10, strFieldCode)
            ' Kie^?m tra 33 (Original alphabet or script of title- A one-character code that indicates the original alphabet or script of the language of the title on the source item upon which the key title (field 222) is based)
            Dim ArrValue11() As String = {" ", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 33, 1, 1, ArrValue11, strFieldCode)
            ' Kie^?m tra 34 (Entry convention- A one-character code that indicates whether an item was cataloged according to successive entry, latest entry or integrated entry cataloging conventions.)
            Dim ArrValue12() As String = {"|", "0", "1", "2"}
            strOutMsg = strOutMsg & CheckValue(val, 34, 1, 1, ArrValue12, strFieldCode)
            ' Tra? la.i ke^'t qua?
            Check008Con_Resources = Trim(strOutMsg)
        End Function
        ' Check008 VISUAL MATERIALS method
        ' Purpose: validate value of field008
        ' Input: value of field008
        ' Output: string value of ErrorMessage
        ' Creator: chuyenpt
        Public Function Check008Vis_Materials(ByVal val As String, ByVal strFieldCode As String) As String
            Dim strOutMsg As String = ""

            ' Kiem tra 18-20
            strOutMsg = strOutMsg & Me.CheckValue18_20OfVis(val, 19, 3, 2, strFieldCode)
            ' Kiem tra 22
            Dim ArrValue1() As String = {" ", "a", "b", "c", "d", "e", "f", "g", "j", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 22, 1, 1, ArrValue1, strFieldCode)
            ' Kiem tra 28
            Dim ArrValue2() As String = {" ", "a", "c", "f", "i", "l", "m", "o", "s", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 28, 1, 1, ArrValue2, strFieldCode)
            ' Kiem tra 29
            Dim ArrValue3() As String = {" ", "a", "b", "c", "d", "f", "r", "s", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 29, 1, 1, ArrValue3, strFieldCode)
            ' Kiem tra 33
            Dim ArrValue4() As String = {"a", "b", "c", "d", "f", "g", "i", "k", "n", "m", "o", "p", "q", "r", "s", "t", "v", "w", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 33, 1, 1, ArrValue4, strFieldCode)
            ' Kiem tra 34
            Dim ArrValue5() As String = {"a", "c", "l", "n", "u", "z", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 34, 1, 1, ArrValue5, strFieldCode)
            ' Tra? la.i ke^'t qua?
            Check008Vis_Materials = Trim(strOutMsg)
        End Function
        ' Check008 MIXED MATERIALS method
        ' Purpose: validate value of field008
        ' Input: value of field008
        ' Output: string value of ErrorMessage
        ' Creator: Sondp
        Public Function Check008Mix_Materials(ByVal val As String, ByVal strFieldCode As String) As String
            Dim strOutMsg As String = ""

            ' Kie^?m tra 23 (Form of item- A one-character code that indicates the form of material for the item)
            Dim ArrValue2() As String = {" ", "a", "b", "c", "d", "f", "r", "s", "|"}
            strOutMsg = strOutMsg & CheckValue(val, 23, 1, 1, ArrValue2, strFieldCode)
            ' Tra? la.i ke^'t qua?
            Check008Mix_Materials = Trim(strOutMsg)
        End Function
        ' Check 18-20 Of Visual Materials
        ' Purpose: validate value of field008
        ' Input: value of field008
        ' Output: string value of ErrorMessage
        ' Creator: chuyenpt 
        Public Function CheckValue18_20OfVis(ByVal mVal, ByVal mPos, ByVal mLength, ByVal mType, ByVal mTag) As String
            Dim btnCheck As Boolean
            btnCheck = False
            Dim strChar As Char
            Dim Arrvalue(1000) As String
            Dim strCheckMsg As String = ""
            Dim inti As Int16, intj As Int16, intk As Int16
            Dim intInc As Integer

            intInc = 4
            Arrvalue(0) = "000"
            Arrvalue(1) = "---"
            Arrvalue(2) = "nnn"
            Arrvalue(3) = "|||"
            Arrvalue(4) = "mmm"
            For inti = 0 To 9
                For intj = 0 To 9
                    For intk = 1 To 9
                        intInc += 1
                        Arrvalue(intInc) = CStr(inti) & CStr(intj) & CStr(intk)
                    Next
                Next
            Next
            For inti = 0 To UBound(Arrvalue)
                If Mid(mVal, mPos, mLength) = CStr(Arrvalue(inti)) Then
                    btnCheck = True
                    Exit For
                End If
            Next
            If btnCheck = False Then
                strCheckMsg = mTag & ": Ind " & mPos & "-" & CStr(CInt(mPos) + CInt(mLength) - 1) & strLblValue & " (" & Mid(mVal, mPos, mLength) & ")\n"
            End If
            CheckValue18_20OfVis = Trim(strCheckMsg)
        End Function
        ' CheckISBN method
        ' Purpose: validate ISBN value
        ' Input: string value of ISBN
        ' Output: boolean value
        ' ---
        ' Alter by chuyenpt (26/7/07)
        ' X10=[11-([10X1+9X2+8X3+7X4+6X5+5X6+4X7+3X8+2X9] MOD 11 )] MOD 11
        ' X13=[10-([X1+3X2+X3+3X4+...+X11+3X12] MOD 10 )] MOD 10

        '2016.04.29 B2
        Public Function CheckISBN(ByVal strISBN As String) As Boolean
            Dim blnReturnValue As Boolean = False
            Try
                ' Declare variables
                Dim strTempISBN As String

                Dim strISBN2Check As String
                Dim strIncludeCheckSum As String
                Dim intCounter As Integer
                Dim intComputeCheckSum As Integer
                Dim inth As Integer

                ' Process

                'strTempISBN = KeepISBNDigit(strISBN)
                strTempISBN = ISN_clean(strISBN)


                blnReturnValue = True
                If Len(strTempISBN) <> 10 And Len(strTempISBN) <> 13 Then
                    blnReturnValue = False
                Else
                    If Len(strTempISBN) = 10 Then
                        strISBN2Check = Left(strTempISBN, 9)
                        If InStr(UCase(strISBN2Check), "X") Then
                            blnReturnValue = False
                        Else
                            strIncludeCheckSum = Right(strTempISBN, 1)
                            If UCase(strIncludeCheckSum) = "X" Then
                                strIncludeCheckSum = "10"
                            Else
                                strIncludeCheckSum = strIncludeCheckSum
                            End If
                            intComputeCheckSum = 0
                            inth = 10
                            For intCounter = 1 To 9
                                intComputeCheckSum = intComputeCheckSum + inth * CInt(Mid(strISBN2Check, intCounter, 1))
                                inth -= 1
                            Next
                            intComputeCheckSum = (11 - (intComputeCheckSum Mod 11)) Mod 11
                            If Not strIncludeCheckSum = "" And CStr(intComputeCheckSum) <> strIncludeCheckSum Then
                                blnReturnValue = False
                            End If
                        End If
                    Else
                        strISBN2Check = Left(strTempISBN, 12)
                        If InStr(UCase(strISBN2Check), "X") Then
                            blnReturnValue = False
                        Else
                            strIncludeCheckSum = Right(strTempISBN, 1)
                            If UCase(strIncludeCheckSum) = "X" Then
                                strIncludeCheckSum = "13"
                            Else
                                strIncludeCheckSum = strIncludeCheckSum
                            End If
                            intComputeCheckSum = 0
                            For intCounter = 1 To 12
                                If intCounter Mod 2 = 0 Then
                                    intComputeCheckSum = intComputeCheckSum + 3 * CInt(Mid(strISBN2Check, intCounter, 1))
                                Else
                                    intComputeCheckSum = intComputeCheckSum + CInt(Mid(strISBN2Check, intCounter, 1))
                                End If
                            Next
                            intComputeCheckSum = (10 - (intComputeCheckSum Mod 10)) Mod 10
                            If Not strIncludeCheckSum = "" And CStr(intComputeCheckSum) <> strIncludeCheckSum Then
                                blnReturnValue = False
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
            End Try
            Return blnReturnValue
        End Function
        '2016.04.29 E2

        ' CheckISBN method
        ' Purpose: validate ISBN value
        ' Input: string value of ISBN
        ' Output: boolean value
        Public Function CheckISSN(ByVal strISSN As String) As Boolean
            Dim strTempISSN As String
            Dim blnReturnValue As Boolean
            Dim strISSN2Check As String
            Dim strIncludeCheckSum As String
            Dim intComputeCheckSum As Integer
            Dim inth As Integer

            strTempISSN = KeepISBNDigit(strISSN)
            Dim intCounter As Integer
            blnReturnValue = True
            If Len(strTempISSN) <> 8 Then
                blnReturnValue = False
            Else
                strISSN2Check = Left(strTempISSN, 7)
                If InStr(UCase(strISSN2Check), "X") Then
                    blnReturnValue = False
                Else
                    strIncludeCheckSum = Right(strTempISSN, 1)
                    If UCase(strIncludeCheckSum) = "X" Then
                        strIncludeCheckSum = "10"
                    Else
                        strIncludeCheckSum = strIncludeCheckSum
                    End If
                    intComputeCheckSum = 0
                    inth = 8
                    For intCounter = 1 To 7
                        intComputeCheckSum = intComputeCheckSum + inth * CInt(Mid(strISSN2Check, intCounter, 1))
                        inth -= 1
                    Next
                    intComputeCheckSum = 11 - (intComputeCheckSum Mod 11)

                    If Not strIncludeCheckSum = "" And intComputeCheckSum <> strIncludeCheckSum Then
                        blnReturnValue = False
                    End If
                End If
            End If
            CheckISSN = blnReturnValue
        End Function

        ' CheckValue method
        ' Purpose: validate input value
        ' Input: some parameters
        ' Output: string value of check message
        Public Function CheckValue(ByVal mVal, ByVal mPos, ByVal mLength, ByVal mType, ByVal mArrvalue, ByVal mTag) As String
            ' Declare variables
            Dim strCheckMsg As String = ""
            Dim btnCheck As Boolean
            Dim intCounter As Integer
            Dim strChar As Char

            ' Process
            Select Case mType
                Case 1 ' Kie^?m tra 1 gia' tri.
                    btnCheck = False
                    For Each strChar In mArrvalue
                        If Mid(mVal, mPos + 1, 1) = strChar Then
                            btnCheck = True
                            Exit For
                        End If
                    Next
                    If btnCheck = False Then
                        strCheckMsg = mTag & ": Ind " & mPos & " " & strLblValue & " (" & Mid(mVal, mPos + 1, 1) & ")\n"
                    End If
                Case 2 ' Kie^?m tra nhie^`u gia' tri.
                    For intCounter = mPos To mPos + mLength - 1
                        btnCheck = False
                        For Each strChar In mArrvalue
                            If Mid(mVal, intCounter + 1, 1) = strChar Then
                                btnCheck = True
                                Exit For
                            End If
                        Next
                        If btnCheck = False Then
                            strCheckMsg = strCheckMsg & mTag & ": Ind " & intCounter & " " & strLblValue & " (" & Mid(mVal, intCounter + 1, 1) & ")\n"
                        End If
                    Next
            End Select
            ' Tra? la.i ke^'t qua?
            CheckValue = Trim(strCheckMsg)
        End Function

        ' KeepISBNDigit method
        ' Purpose: exclude some unvalid characters
        ' Input: string value of ISBN
        ' Output: string value of result ISBN
        Public Function KeepISBNDigit(ByVal strISBN) As String
            Dim strOutput As String = ""
            Try
                Dim intCounter As Integer
                Dim strCurs As String
                strOutput = Left(strISBN, 13)
                If Not IsNumeric(strOutput) Then
                    strOutput = Left(strISBN, 10)
                End If
                'For intCounter = 1 To Len(strISBN)
                '    strCurs = Mid(strISBN, intCounter, 1)
                '    If (strCurs >= "0" And strCurs <= "9") Or UCase(strCurs) = "X" Then
                '        strOutput = strOutput & strCurs
                '    End If
                'Next
            Catch ex As Exception
            End Try
            Return strOutput
        End Function

        'If IsAuthority=0,1 then
        Public Function MakeDataTable(ByRef secFieldCode, ByRef secIndicator, ByRef secFieldValue, ByRef secIDs) As DataTable
            Dim arrFieldCode()
            Dim arrIndicator()
            Dim arrFieldValue()
            Dim arrIDs()
            Dim i As Integer
            'If InStr(secFieldCode, strFieldCode) > 0 Then
            arrIDs = Split(secIDs, strSeparate)
            If hidAction = "ADD" Then
                'True la khong lap
                If blnRepeat = False And InStr(secFieldCode, strFieldCode) > 0 Then
                    'If blnRepeat = False And InStr(secFieldCode, strFieldCode) > 0 And InStr(secFieldValue, strFieldValue) > 0 Then
                    hidAction = "UPDATE"
                Else
                    secFieldCode = secFieldCode & strSeparate & strFieldCode
                    secIndicator = secIndicator & strSeparate & strIndicator
                    secFieldValue = secFieldValue & strSeparate & strFieldValue
                    secIDs = secIDs & strSeparate & UBound(arrIDs)
                End If
            End If

            'strSeparate la dau :::
            arrFieldCode = Split(secFieldCode, strSeparate)
            arrIndicator = Split(secIndicator, strSeparate)
            arrFieldValue = Split(secFieldValue, strSeparate)
            arrIDs = Split(secIDs, strSeparate)
            'Tao mot DataTable tam tblTmp, lam trung gian
            Dim tblTmp As DataTable = New DataTable("Temp")
            Dim dtcCols As DataColumn
            Dim dtrRow As DataRow

            ' tao cot thu nhat va them vao tblTmp
            dtcCols = New DataColumn
            dtcCols.DataType = System.Type.GetType("System.String")
            dtcCols.ColumnName = "ID"
            tblTmp.Columns.Add(dtcCols)

            ' tao cot thu hai va them vao tblTmp
            dtcCols = New DataColumn
            dtcCols.DataType = System.Type.GetType("System.String")
            dtcCols.ColumnName = "FieldCode"
            tblTmp.Columns.Add(dtcCols)

            ' tao cot thu ba va them vao tblTmp
            dtcCols = New DataColumn
            dtcCols.DataType = System.Type.GetType("System.String")
            dtcCols.ColumnName = "Indicator"
            tblTmp.Columns.Add(dtcCols)

            ' tao cot thu tu va them vao tblTmp
            dtcCols = New DataColumn
            dtcCols.DataType = System.Type.GetType("System.String")
            dtcCols.ColumnName = "FieldValue"
            tblTmp.Columns.Add(dtcCols)

            secIDs = ""
            secFieldCode = ""
            secIndicator = ""
            secFieldValue = ""
            For i = 0 To UBound(arrFieldCode)
                ' them thanh phan trong array vao row
                If Len(arrFieldCode(i)) > 0 Then
                    Select Case hidAction
                        Case "MODIFY"
                            dtrRow = tblTmp.NewRow()
                            If CInt(arrIDs(i)) = CInt(strID) Then
                                dtrRow("ID") = arrIDs(i)
                                dtrRow("FieldCode") = strFieldCode
                                dtrRow("Indicator") = strIndicator
                                dtrRow("FieldValue") = strFieldValue
                                secIDs = secIDs & strSeparate & arrIDs(i)
                                secFieldCode = secFieldCode & strSeparate & strFieldCode
                                secIndicator = secIndicator & strSeparate & strIndicator
                                secFieldValue = secFieldValue & strSeparate & strFieldValue
                            Else
                                dtrRow("ID") = arrIDs(i)
                                dtrRow("FieldCode") = arrFieldCode(i)
                                dtrRow("Indicator") = arrIndicator(i)
                                dtrRow("FieldValue") = arrFieldValue(i)
                                secIDs = secIDs & strSeparate & arrIDs(i)
                                secFieldCode = secFieldCode & strSeparate & arrFieldCode(i)
                                secIndicator = secIndicator & strSeparate & arrIndicator(i)
                                secFieldValue = secFieldValue & strSeparate & arrFieldValue(i)
                            End If
                            tblTmp.Rows.Add(dtrRow)
                        Case "DELETE"
                            If arrIDs(i) <> strID Then
                                dtrRow = tblTmp.NewRow()

                                dtrRow("ID") = arrIDs(i)
                                dtrRow("FieldCode") = arrFieldCode(i)
                                dtrRow("Indicator") = arrIndicator(i)
                                dtrRow("FieldValue") = arrFieldValue(i)
                                secIDs = secIDs & strSeparate & arrIDs(i)

                                secFieldCode = secFieldCode & strSeparate & arrFieldCode(i)
                                secIndicator = secIndicator & strSeparate & arrIndicator(i)
                                secFieldValue = secFieldValue & strSeparate & arrFieldValue(i)
                                tblTmp.Rows.Add(dtrRow)
                            End If
                        Case "ADD"
                            dtrRow = tblTmp.NewRow()

                            dtrRow("ID") = arrIDs(i)
                            dtrRow("FieldCode") = arrFieldCode(i)
                            dtrRow("Indicator") = arrIndicator(i)
                            dtrRow("FieldValue") = arrFieldValue(i)
                            secIDs = secIDs & strSeparate & arrIDs(i)
                            secFieldCode = secFieldCode & strSeparate & arrFieldCode(i)
                            secIndicator = secIndicator & strSeparate & arrIndicator(i)
                            secFieldValue = secFieldValue & strSeparate & arrFieldValue(i)
                            tblTmp.Rows.Add(dtrRow)

                        Case "UPDATE"
                            dtrRow = tblTmp.NewRow()
                            If arrFieldCode(i) = strFieldCode Then

                                dtrRow("ID") = arrIDs(i)
                                dtrRow("FieldCode") = strFieldCode
                                dtrRow("Indicator") = strIndicator
                                dtrRow("FieldValue") = strFieldValue

                                secIDs = secIDs & strSeparate & arrIDs(i)
                                secFieldCode = secFieldCode & strSeparate & strFieldCode
                                secIndicator = secIndicator & strSeparate & strIndicator
                                secFieldValue = secFieldValue & strSeparate & strFieldValue
                            Else
                                dtrRow("ID") = arrIDs(i)
                                dtrRow("FieldCode") = arrFieldCode(i)
                                dtrRow("Indicator") = arrIndicator(i)
                                dtrRow("FieldValue") = arrFieldValue(i)
                                secIDs = secIDs & strSeparate & arrIDs(i)
                                secFieldCode = secFieldCode & strSeparate & arrFieldCode(i)
                                secIndicator = secIndicator & strSeparate & arrIndicator(i)
                                secFieldValue = secFieldValue & strSeparate & arrFieldValue(i)
                            End If
                            tblTmp.Rows.Add(dtrRow)
                        Case Else
                            dtrRow = tblTmp.NewRow()

                            dtrRow("ID") = arrIDs(i)
                            dtrRow("FieldCode") = arrFieldCode(i)
                            dtrRow("Indicator") = arrIndicator(i)
                            dtrRow("FieldValue") = arrFieldValue(i)
                            secIDs = secIDs & strSeparate & arrIDs(i)
                            secFieldCode = secFieldCode & strSeparate & arrFieldCode(i)
                            secIndicator = secIndicator & strSeparate & arrIndicator(i)
                            secFieldValue = secFieldValue & strSeparate & arrFieldValue(i)
                            tblTmp.Rows.Add(dtrRow)
                    End Select
                End If
            Next
            Return tblTmp
        End Function


        '2016.04.29 B1
        Function mod11_checksum(protostring As String, weight As Integer) As Integer
            Dim intResult As Integer = 0
            Try
                Dim checksum As Integer = 0
                Dim pos As Integer = 1
                Dim CharAtPos As String = ""
                While ((pos <= Len(protostring)) And (weight >= 1))
                    CharAtPos = Mid(protostring, pos, 1)
                    If ((CharAtPos >= "0") And (CharAtPos <= "9")) Then
                        checksum = checksum + weight * CharAtPos
                        weight = weight - 1
                    ElseIf ((weight = 1) And (UCase(CharAtPos) = "X")) Then
                        checksum = checksum + 10
                        weight = weight - 1
                    End If
                    pos = pos + 1
                End While
                intResult = checksum Mod 11
            Catch ex As Exception
            End Try
            Return intResult
        End Function

        Function make_checkdigit(checksum As Integer) As String
            Dim strResult As String = ""
            Try
                Dim checkdigit As Integer = 0
                checkdigit = (11 - checksum) Mod 11
                If checkdigit = 10 Then
                    make_checkdigit = "X"
                Else
                    make_checkdigit = CStr(checkdigit)
                End If
            Catch ex As Exception
            End Try
            Return strResult
        End Function

        Function bad_ISN_char_count(proto_string As String) As Integer
            Dim intResult As Integer = 0
            Try
                Dim count As Integer = 0
                Dim c As String = ""
                For i As Integer = 1 To Len(proto_string)
                    c = Mid(proto_string, i, 1)
                    If (c < "0" Or c > "9") And c <> "-" Then
                        count = count + 1
                    End If
                Next
                If UCase(c) = "X" Then
                    count = count - 1
                End If
                bad_ISN_char_count = count
            Catch ex As Exception
            End Try
            Return intResult
        End Function

        Function ISN_clean(isbn_proto) As String
            Return UCase(Replace(isbn_proto, "-", ""))
        End Function

        Function ISN_checksum_OK(isn_proto, length) As Boolean
            Dim bolResult As Boolean = False
            Try
                isn_proto = ISN_clean(isn_proto)
                If (Len(isn_proto) = length) And (bad_ISN_char_count(isn_proto) = 0) And (mod11_checksum(isn_proto, length) = 0) Then
                    bolResult = True
                Else
                    bolResult = False
                End If
            Catch ex As Exception
            End Try
            Return bolResult
        End Function

        Function ISBN_checksum_OK(isbn_proto) As Boolean
            Dim bolResult As Boolean = False
            Try
                If Len(ISN_clean(isbn_proto)) = 13 Then
                    bolResult = CheckISBN(isbn_proto)
                Else
                    bolResult = ISN_checksum_OK(isbn_proto, 10)
                End If
            Catch ex As Exception
            End Try
            Return bolResult
        End Function

        Function ISSN_checksum_OK(issn_proto) As Boolean
            Return ISN_checksum_OK(issn_proto, 8)
        End Function
        '2016.04.29 E1

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If isDisposing Then
                    If Not objDField Is Nothing Then
                        objDField.Dispose(True)
                        objDField = Nothing
                    End If
                End If
            Finally
                Me.Dispose()
                MyBase.Dispose(True)
            End Try
        End Sub
    End Class
End Namespace