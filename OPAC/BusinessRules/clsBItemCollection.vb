
Imports eMicLibOPAC.BusinessRules
Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibOPAC.DataAccess
Imports eMicLibOPAC.DataAccess.OPAC

Namespace eMicLibOPAC.BusinessRules.OPAC
    Public Class clsBItemCollection
        Inherits clsBBase

        ' *****************************************************************************************************
        ' Declare Private variables
        ' *****************************************************************************************************
        Private intIsAuthority As Integer = 0
        Private strItemIDs As String
        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        Private objDItemCollection As New clsDItemCollection

        ' *****************************************************************************************************
        ' IsAuthority property
        Public Property IsAuthority() As Integer
            Get
                Return intIsAuthority
            End Get
            Set(ByVal Value As Integer)
                intIsAuthority = Value
            End Set
        End Property
        ' ItemIDs property
        Public Property ItemIDs() As String
            Get
                Return strItemIDs
            End Get
            Set(ByVal Value As String)
                strItemIDs = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Initialize method
        ' Purpose: Init all necessary objects
        Public Overloads Sub Initialize()
            Try
                ' Init objDItemCollection object
                objDItemCollection.DBServer = strDBserver
                objDItemCollection.ConnectionString = strConnectionString
                Call objDItemCollection.Initialize()

                ' Init objBCDBS object
                objBCDBS.DBServer = strDBServer
                objBCDBS.InterfaceLanguage = strInterfaceLanguage
                objBCDBS.ConnectionString = strConnectionString
                Call objBCDBS.Initialize()

                ' Init objBCSP object
                objBCSP.DBServer = strDBServer
                objBCSP.InterfaceLanguage = strInterfaceLanguage
                objBCSP.ConnectionString = strConnectionString
                Call objBCSP.Initialize()
                'Catch ex As Exception
                '    strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        ' GetItemMainInfor method
        ' Purpose: get all main information of item (Leader, ItemType, ItemMedia...)
        ' Input: strItemIDs, intIsAuthority
        ' Output: Datatable result
        Public Function GetItemMainInfor() As DataTable
            Try
                objDItemCollection.IsAuthority = intIsAuthority
                objDItemCollection.ItemIDs = strItemIDs
                GetItemMainInfor = objBCDBS.ConvertTable(objDItemCollection.GetItemMainInfor)
                strErrorMsg = objDItemCollection.ErrorMsg
                intErrorCode = objDItemCollection.ErrorCode
                'Catch ex As Exception
                '    strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' GetItemDetailInfor method
        ' Purpose: get all main information of item (Leader, ItemType, ItemMedia...)
        ' Input: strItemIDs, intIsAuthority
        ' Output: Datatable result
        Public Function GetItemDetailInfor() As DataTable
            Try
                objDItemCollection.IsAuthority = intIsAuthority
                objDItemCollection.ItemIDs = strItemIDs
                GetItemDetailInfor = objBCDBS.ConvertTable(objDItemCollection.GetItemDetailInfor)
                strErrorMsg = objDItemCollection.ErrorMsg
                intErrorCode = objDItemCollection.ErrorCode
                'Catch ex As Exception
                '    strErrorMsg = ex.Message
            Finally
            End Try
        End Function
        ' CreateISORec function
        ' Purpose: View record with ISOAuthority type

        Public Function CreateISORec() As String
            Dim ft As Char = "#" '#
            Dim rt As Char = "#" 'Chr(29) '#
            Dim si As Char = "$" 'Chr(31) '$
            Dim TotalLen As Integer
            Dim BaseAdd As Integer
            Dim Leader As String
            Dim Dir As String, RecVal As String, fVal As String, FLen As Long
            Dim Indicators As String, Recwbr As String, Record As String

            Dim i As Integer, ISBDStr As String, rowMain, rowDetail As DataRow
            Dim tblMainInfor As New DataTable, tblDetailInfor As New DataTable

            tblMainInfor = GetItemMainInfor()
            tblDetailInfor = GetItemDetailInfor()

            If Not tblDetailInfor Is Nothing AndAlso tblMainInfor.Rows.Count > 0 Then
                rowMain = tblMainInfor.Rows.Item(0)
                TotalLen = 28
                BaseAdd = 25

                If Not IsDBNull(rowMain.Item("Code")) And rowMain.Item("Code") <> "" Then ' Use Main
                    fVal = objBCSP.ConvertIt(rowMain.Item("Code"))
                    FLen = Len(fVal) + 1
                    Dir = Dir & "001" & Strings.StrDup(4 - Len(CStr(FLen)), "0") & FLen & "00000"
                    BaseAdd = BaseAdd + 12
                    RecVal = RecVal & rowMain.Item("Code") & ft 'Use Main
                End If

                For Each rowDetail In tblDetailInfor.Rows
                    If Not IsDBNull(rowDetail.Item("Indicators")) And Not IsDBNull(rowDetail.Item("VietIndicators")) Then
                        If Not rowDetail.Item("Indicators") = "" Or Not rowDetail.Item("VietIndicators") = "" Then
                            Select Case Len(rowDetail.Item("Indicators") & "")
                                Case 0
                                    Indicators = ""
                                Case 1
                                    Indicators = rowDetail.Item("Indicators") & " "
                                Case 2
                                    Indicators = rowDetail.Item("Indicators")
                                Case Else
                                    Indicators = Left(rowDetail.Item("Indicators"), 2)
                            End Select
                        End If
                    End If
                    If Not IsDBNull(rowDetail.Item("Content")) And Not IsDBNull(rowDetail.Item("FieldCode")) Then
                        fVal = Indicators & objBCSP.Symbolize(objBCSP.ConvertIt(rowDetail.Item("Content")), rowDetail.Item("FieldCode"))
                    End If

                    FLen = Len(fVal) + 1
                    Dir = Dir & rowDetail.Item("FieldCode") & Strings.StrDup(4 - Len(CStr(FLen)), "0") & FLen & Strings.StrDup(5 - Len(CStr(Len(RecVal))), "0") & Len(RecVal)
                    BaseAdd = BaseAdd + 12
                    RecVal = RecVal & fVal & ft
                Next
                If Not IsDBNull(rowMain.Item("NewRecord")) Then 'Use Main
                    fVal = objBCSP.ConvertIt(rowMain.Item("NewRecord"))
                    FLen = Len(fVal) + 1
                    Dir = Dir & "900" & Strings.StrDup(4 - Len(CStr(FLen)), "0") & FLen & Strings.StrDup(5 - Len(CStr(Len(RecVal))), "0") & Len(RecVal)
                    BaseAdd = BaseAdd + 12
                    RecVal = RecVal & rowMain.Item("NewRecord") & ft 'Use Main
                End If
                If Not IsDBNull(rowMain.Item("CoverPicture")) And Not rowMain.Item("CoverPicture") = "" Then 'Use Main
                    fVal = objBCSP.ConvertIt(rowMain.Item("CoverPicture"))
                    FLen = Len(fVal) + 1
                    Dir = Dir & "907" & Strings.StrDup(4 - Len(CStr(FLen)), "0") & FLen & Strings.StrDup(5 - Len(CStr(Len(RecVal))), "0") & Len(RecVal)
                    BaseAdd = BaseAdd + 12
                    RecVal = RecVal & rowMain.Item("CoverPicture") & ft 'Use Main
                End If
                If Not IsDBNull(rowMain.Item("Reviewer")) And Not rowMain.Item("Reviewer") = "" Then 'Use Main
                    fVal = objBCSP.ConvertIt(rowMain.Item("Reviewer"))
                    FLen = Len(fVal) + 1
                    Dir = Dir & "911" & Strings.StrDup(4 - Len(CStr(FLen)), "0") & FLen & Strings.StrDup(5 - Len(CStr(Len(RecVal))), "0") & Len(RecVal)
                    BaseAdd = BaseAdd + 12
                    RecVal = RecVal & fVal & ft 'Use Main
                End If
                If Not IsDBNull(rowMain.Item("Cataloguer")) And Not rowMain.Item("Cataloguer") = "" Then 'Use Main
                    fVal = objBCSP.ConvertIt(rowMain.Item("Cataloguer"))
                    FLen = Len(fVal) + 1
                    Dir = Dir & "912" & Strings.StrDup(4 - Len(CStr(FLen)), "0") & FLen & Strings.StrDup(5 - Len(CStr(Len(RecVal))), "0") & Len(RecVal)
                    BaseAdd = BaseAdd + 12
                    RecVal = RecVal & rowMain.Item("Cataloguer") & ft 'Use Main
                End If
                If Not IsDBNull(rowMain.Item("Code")) And Not rowMain.Item("Code") = "" Then 'Use Main
                    fVal = objBCSP.ConvertIt(rowMain.Item("Code"))
                    FLen = Len(fVal) + 1
                    Dir = Dir & "925" & Strings.StrDup(4 - Len(CStr(FLen)), "0") & FLen & Strings.StrDup(5 - Len(CStr(Len(RecVal))), "0") & Len(RecVal)
                    BaseAdd = BaseAdd + 12
                    RecVal = RecVal & fVal & ft 'Use Main
                End If
                If Not IsDBNull(rowMain.Item("AccessLevel")) Then 'Use Main
                    fVal = objBCSP.ConvertIt(rowMain.Item("AccessLevel"))
                    FLen = Len(fVal) + 1
                    Dir = Dir & "926" & Strings.StrDup(4 - Len(CStr(FLen)), "0") & FLen & Strings.StrDup(5 - Len(CStr(Len(RecVal))), "0") & Len(RecVal)
                    BaseAdd = BaseAdd + 12
                    RecVal = RecVal & fVal & ft 'Use Main
                End If
                If Not IsDBNull(rowMain.Item("TypeCode")) And Not rowMain.Item("TypeCode") = "" Then
                    fVal = objBCSP.ConvertIt(rowMain.Item("TypeCode"))
                    FLen = Len(fVal) + 1
                    Dir = Dir & "927" & Strings.StrDup(4 - Len(CStr(FLen)), "0") & FLen & Strings.StrDup(5 - Len(CStr(Len(RecVal))), "0") & Len(RecVal)
                    BaseAdd = BaseAdd + 12
                    RecVal = RecVal & fVal & ft
                End If
                TotalLen = TotalLen + Len(Dir) + Len(RecVal)
                Leader = Strings.StrDup(5 - Len(CStr(TotalLen)), "0") & TotalLen & Mid(rowMain.Item("Leader"), 6, 7) & Strings.StrDup(5 - Len(CStr(BaseAdd)), "0") & BaseAdd & Right(rowMain.Item("Leader"), 7)
                Record = Leader & Dir & ft & RecVal & rt
                Record = Strings.StrDup(5 - Len(CStr(Len(Record))), "0") & CStr(Len(Record)) & Right(Record, Len(Record) - 5)

                While Len(Record) > 0
                    If Len(Record) > 80 Then
                        Recwbr = Recwbr & Left(Record, 80) & Chr(13)
                        Record = Right(Record, Len(Record) - 80)
                    Else
                        Recwbr = Recwbr & Record
                        Record = ""
                    End If
                End While
                Recwbr = "<PRE>" & Chr(13) & Recwbr & Chr(13) & "</PRE>"
            End If
            CreateISORec = Recwbr
        End Function

        ' CreateISOAuthorityRec function
        ' Purpose: View record with ISOAuthority type
        Public Function CreateISOAuthorityRec() As String
            Dim ft As Char = Chr(30) '#
            Dim rt As Char = Chr(29) '#
            Dim si As Char = Chr(31) '$
            Dim TotalLen, BaseAdd, Flen As Integer
            Dim Dir, RecVal, FVal, Indicators As String
            Dim Leader, Record, Recwbr As String
            Dim rowMain, rowDetail As DataRow
            Dim tblMainInfor As New DataTable, tblDetailInfor As New DataTable
            tblMainInfor = GetItemMainInfor()
            tblDetailInfor = GetItemDetailInfor()

            If Not tblMainInfor Is Nothing AndAlso tblMainInfor.Rows.Count > 0 Then
                rowMain = tblMainInfor.Rows.Item(0)
                TotalLen = 28 ' Recounter
                BaseAdd = 25
                Dir = ""
                RecVal = ""
                If Not IsDBNull(rowMain.Item("Code")) And Not rowMain.Item("Code") = "" Then
                    FVal = objBCSP.ConvertIt(rowMain.Item("Code"))
                    Flen = Len(FVal) + 1
                    Dir = Dir & "001" & Strings.StrDup(4 - Len(CStr(Flen)), "0") & Flen & "00000"
                    BaseAdd = BaseAdd + 12
                    RecVal = RecVal & FVal & ft
                End If

                For Each rowDetail In tblDetailInfor.Rows 'Do While Not rs2.EOF
                    If Not IsDBNull(rowDetail.Item("Indicators")) Or Not IsDBNull(rowDetail.Item("VietIndicators")) Then
                        Select Case Len(rowDetail.Item("Indicators"))
                            Case 0
                                Indicators = "  "
                            Case 1
                                Indicators = rowDetail.Item("Indicators") & " "
                            Case 2
                                Indicators = rowDetail.Item("Indicators")
                        End Select
                    End If

                    If Not IsDBNull(rowDetail) Then
                        If Not IsDBNull(rowDetail.Item("Content")) And Not IsDBNull(rowDetail.Item("FieldCode")) Then
                            FVal = Indicators & objBCSP.Symbolize(objBCSP.ConvertIt(rowDetail.Item("Content")), rowDetail.Item("FieldCode"))
                        End If
                    End If

                    Flen = Len(FVal) + 1
                    Dir = Dir & rowDetail.Item("FieldCode") & Strings.StrDup(4 - Len(CStr(Flen)), "0") & Flen & Strings.StrDup(5 - Len(CStr(Len(RecVal))), "0") & Len(RecVal)
                    BaseAdd = BaseAdd + 12
                    RecVal = RecVal & FVal & ft
                Next 'Loop

                If Not IsDBNull(rowMain.Item("Cataloguer")) And Not rowMain.Item("Cataloguer") = "" Then
                    FVal = objBCSP.ConvertIt(rowMain.Item("Cataloguer"))
                    Flen = Len(FVal) + 1
                    Dir = Dir & "911" & Strings.StrDup(4 - Len(CStr(Flen)), "0") & Flen & Strings.StrDup(5 - Len(CStr(Len(RecVal))), "0") & Len(RecVal)
                    BaseAdd = BaseAdd + 12
                    RecVal = RecVal & FVal & ft
                End If

                If Not IsDBNull(rowMain.Item("Reviewer")) And Not rowMain.Item("Reviewer") = "" Then
                    FVal = objBCSP.ConvertIt(rowMain.Item("Reviewer"))
                    Flen = Len(FVal) + 1
                    Dir = Dir & "912" & Strings.StrDup(4 - Len(CStr(Flen)), "0") & Flen & Strings.StrDup(5 - Len(CStr(Len(RecVal))), "0") & Len(RecVal)
                    BaseAdd = BaseAdd + 12
                    RecVal = RecVal & FVal & ft
                End If

                TotalLen = TotalLen + Len(Dir) + Len(RecVal)
                Leader = Strings.StrDup(5 - Len(CStr(TotalLen)), "0") & TotalLen & Mid(rowMain.Item("Leader"), 6, 7) & Strings.StrDup(5 - Len(CStr(BaseAdd)), "0") & BaseAdd & Right(rowMain.Item("Leader"), 7)
                Record = Leader & Dir & ft & RecVal & rt
                Record = Strings.StrDup(5 - Len(CStr(Len(Record))), "0") & CStr(Len(Record)) & Right(Record, Len(Record) - 5)

                While Len(Record) > 0
                    If Len(Record) > 80 Then
                        Recwbr = Recwbr & Left(Record, 80) & Chr(13)
                        Record = Right(Record, Len(Record) - 80)
                    Else
                        Recwbr = Recwbr & Record
                        Record = ""
                    End If
                End While
            End If
            Recwbr = "<PRE>" & Chr(13) & Recwbr & Chr(13) & "</PRE>"
            CreateISOAuthorityRec = Recwbr
        End Function

        Public Function GetInfoISOUNIMARC() As DataTable
            Dim tblResult As New DataTable
            Dim rowNew As DataRow
            tblResult.Columns.Add("Content", System.Type.GetType("System.String"))
            rowNew = tblResult.NewRow()
            rowNew.Item("Content") = "No support" 'CreateISOAuthorityRec()
            tblResult.Rows.Add(rowNew)
            GetInfoISOUNIMARC = tblResult
        End Function

        Public Function GetInfoISOUSMARC() As DataTable
            Dim ft As Char = CStr(Chr(30)) '#
            Dim rt As Char = CStr(Chr(29)) '#
            Dim si As Char = CStr(Chr(31)) '$

            Dim strFVal, strFGroupVal, strRecVal, strLeader As String
            ' Variables: PadLeft1, PadLeft2 
            Dim strPadLeft1, strPadLeft2 As String
            ' Variables: FieldLen
            Dim intFLen As Integer
            ' Variables:  TotalLen, BaseAdd be used by Leader
            Dim intTotalLen, intBaseAdd As Integer
            Dim strIndicators As String

            Dim tblResult As New DataTable
            Dim rowNew As DataRow
            Dim arrIDs() As String = strItemIDs.Split(",")
            Dim intid As Integer
            Dim tblDetailInfor As DataTable
            Dim tblMainInfor As DataTable
            Dim i As Integer
            Try
                'get info record from database
                tblDetailInfor = GetItemDetailInfor()
                tblMainInfor = GetItemMainInfor()
                'initialize table Result
                tblResult.Columns.Add("Content", System.Type.GetType("System.String"))
                For intid = 0 To arrIDs.Length - 1
                    rowNew = tblResult.NewRow()
                    intTotalLen = 26
                    intBaseAdd = 25
                    strRecVal = ""
                    strFGroupVal = ""
                    strPadLeft1 = ""
                    strPadLeft2 = ""

                    tblMainInfor.DefaultView.RowFilter = "ItemID=" & arrIDs(intid)

                    If Not IsDBNull(tblMainInfor.DefaultView(0).Item("Code")) And tblMainInfor.DefaultView(0).Item("Code") <> "" Then ' Use Main
                        strFVal = objBCSP.ToUTF8(tblMainInfor.DefaultView(0).Item("Code").ToString.Trim)
                        intFLen = Len(strFVal) + 1
                        strRecVal = strRecVal & "001" & strPadLeft1.PadLeft(4 - Len(CStr(intFLen)), "0") & intFLen & "00000"
                        intBaseAdd = intBaseAdd + 12
                        strFGroupVal = strFGroupVal & strFVal & CStr(Chr(30))
                        strPadLeft1 = ""
                    End If
                    tblDetailInfor.DefaultView.RowFilter = "ItemID=" & arrIDs(intid)

                    For i = 0 To tblDetailInfor.DefaultView.Count - 1
                        If Not IsDBNull(tblDetailInfor.DefaultView(i).Item("Indicators")) AndAlso Not IsDBNull(tblDetailInfor.DefaultView(i).Item("VietIndicators")) Then
                            If tblDetailInfor.DefaultView(i).Item("Indicators") <> "" Or tblDetailInfor.DefaultView(i).Item("VietIndicators") <> "" Then
                                If Not IsDBNull(tblDetailInfor.DefaultView(i).Item("Ind1")) AndAlso Not tblDetailInfor.DefaultView(i).Item("Ind1") = "" Then
                                    strIndicators = tblDetailInfor.DefaultView(i).Item("Ind1")
                                Else
                                    strIndicators = " "
                                End If
                                If Not IsDBNull(tblDetailInfor.DefaultView(i).Item("Ind2")) AndAlso Not tblDetailInfor.DefaultView(i).Item("Ind2") = "" Then
                                    strIndicators = strIndicators & tblDetailInfor.DefaultView(i).Item("Ind2")
                                Else
                                    strIndicators = strIndicators & " "
                                End If
                            End If
                        End If
                        strFVal = strIndicators & Replace(objBCSP.ToUTF8(tblDetailInfor.DefaultView(i).Item("Content")), "$", CStr(Chr(31)))
                        intFLen = Len(strFVal) + 1
                        strRecVal = strRecVal & tblDetailInfor.DefaultView(i).Item("FieldCode") & strPadLeft1.PadLeft(4 - Len(CStr(intFLen)), "0") & intFLen & strPadLeft2.PadLeft(5 - Len(CStr(Len(strFGroupVal))), "0") & Len(strFGroupVal)
                        strPadLeft1 = ""
                        strPadLeft2 = ""
                        intBaseAdd = intBaseAdd + 12
                        strFGroupVal = strFGroupVal & strFVal & CStr(Chr(30))
                    Next

                    ' New record
                    If Not IsDBNull(tblMainInfor.DefaultView(0).Item("NewRecord")) Then
                        If tblMainInfor.DefaultView(0).Item("NewRecord") > 0 Then
                            strFVal = tblMainInfor.DefaultView(0).Item("NewRecord")
                            intFLen = Len(strFVal) + 1
                            strRecVal = strRecVal & "900" & strPadLeft1.PadLeft(4 - Len(CStr(intFLen)), "0") & intFLen & strPadLeft2.PadLeft(5 - Len(CStr(Len(strFGroupVal))), "0") & Len(strFGroupVal)
                            intBaseAdd = intBaseAdd + 12
                            strFGroupVal = strFGroupVal & strFVal & CStr(Chr(30))
                            strPadLeft1 = ""
                            strPadLeft2 = ""
                        End If
                    End If

                    ' CoverPicture
                    If Not IsDBNull(tblMainInfor.DefaultView(0).Item("CoverPicture")) Then
                        If Not tblMainInfor.DefaultView(0).Item("CoverPicture") = "" Then
                            strFVal = tblMainInfor.DefaultView(0).Item("CoverPicture")
                            intFLen = Len(strFVal) + 1
                            strRecVal = strRecVal & "907" & strPadLeft1.PadLeft(4 - Len(CStr(intFLen)), "0") & intFLen & strPadLeft2.PadLeft(5 - Len(CStr(Len(strFGroupVal))), "0") & Len(strFGroupVal)
                            intBaseAdd = intBaseAdd + 12
                            strFGroupVal = strFGroupVal & strFVal & CStr(Chr(30))
                            strPadLeft1 = ""
                            strPadLeft2 = ""
                        End If
                    End If

                    ' Cataloguer
                    If Not IsDBNull(tblMainInfor.DefaultView(0).Item("Cataloguer")) Then
                        If Not tblMainInfor.DefaultView(0).Item("Cataloguer") = "" Then
                            strFVal = objBCSP.ToUTF8(tblMainInfor.DefaultView(0).Item("Cataloguer"))
                            intFLen = Len(strFVal) + 1
                            strRecVal = strRecVal & "911" & strPadLeft1.PadLeft(4 - Len(CStr(intFLen)), "0") & intFLen & strPadLeft2.PadLeft(5 - Len(CStr(Len(strFGroupVal))), "0") & Len(strFGroupVal)
                            intBaseAdd = intBaseAdd + 12
                            strFGroupVal = strFGroupVal & strFVal & CStr(Chr(30))
                            strPadLeft1 = ""
                            strPadLeft2 = ""
                        End If
                    End If

                    ' Reviewer
                    If Not IsDBNull(tblMainInfor.DefaultView(0).Item("Reviewer")) Then
                        If Not tblMainInfor.DefaultView(0).Item("Reviewer") = "" Then
                            strFVal = objBCSP.ToUTF8(tblMainInfor.DefaultView(0).Item("Reviewer"))
                            intFLen = Len(strFVal) + 1
                            strRecVal = strRecVal & "912" & strPadLeft1.PadLeft(4 - Len(CStr(intFLen)), "0") & intFLen & strPadLeft2.PadLeft(5 - Len(CStr(Len(strFGroupVal))), "0") & Len(strFGroupVal)
                            intBaseAdd = intBaseAdd + 12
                            strFGroupVal = strFGroupVal & strFVal & CStr(Chr(30))
                            strPadLeft1 = ""
                            strPadLeft2 = ""
                        End If
                    End If

                    ' MediumCode
                    If Not IsDBNull(tblMainInfor.DefaultView(0).Item("MediumCode")) Then
                        If Not tblMainInfor.DefaultView(0).Item("MediumCode") = "" Then
                            strFVal = objBCSP.ToUTF8(tblMainInfor.DefaultView(0).Item("MediumCode"))
                            intFLen = Len(strFVal) + 1
                            strRecVal = strRecVal & "925" & strPadLeft1.PadLeft(4 - Len(CStr(intFLen)), "0") & intFLen & strPadLeft2.PadLeft(5 - Len(CStr(Len(strFGroupVal))), "0") & Len(strFGroupVal)
                            intBaseAdd = intBaseAdd + 12
                            strFGroupVal = strFGroupVal & strFVal & CStr(Chr(30))
                            strPadLeft1 = ""
                            strPadLeft2 = ""
                        End If
                    End If

                    ' AccessLevel
                    If Not IsDBNull(tblMainInfor.DefaultView(0).Item("AccessLevel")) Then
                        If tblMainInfor.DefaultView(0).Item("AccessLevel") > 0 Then
                            strFVal = tblMainInfor.DefaultView(0).Item("AccessLevel")
                            intFLen = Len(strFVal) + 1
                            strRecVal = strRecVal & "926" & strPadLeft1.PadLeft(4 - Len(CStr(intFLen)), "0") & intFLen & strPadLeft2.PadLeft(5 - Len(CStr(Len(strFGroupVal))), "0") & Len(strFGroupVal)
                            intBaseAdd = intBaseAdd + 12
                            strFGroupVal = strFGroupVal & strFVal & CStr(Chr(30))
                            strPadLeft1 = ""
                            strPadLeft2 = ""
                        End If
                    End If

                    ' TypeCode
                    If Not IsDBNull(tblMainInfor.DefaultView(0).Item("TypeCode")) Then
                        If Not tblMainInfor.DefaultView(0).Item("TypeCode") = "" Then
                            strFVal = objBCSP.ToUTF8(tblMainInfor.DefaultView(0).Item("TypeCode"))
                            intFLen = Len(strFVal) + 1
                            strRecVal = strRecVal & "927" & strPadLeft1.PadLeft(4 - Len(CStr(intFLen)), "0") & intFLen & strPadLeft2.PadLeft(5 - Len(CStr(Len(strFGroupVal))), "0") & Len(strFGroupVal)
                            intBaseAdd = intBaseAdd + 12
                            strFGroupVal = strFGroupVal & strFVal & CStr(Chr(30))
                            strPadLeft1 = ""
                            strPadLeft2 = ""
                        End If
                    End If

                    intTotalLen = intTotalLen + Len(strRecVal) + Len(strFGroupVal)
                    strLeader = strPadLeft1.PadLeft(5 - Len(CStr(intTotalLen)), "0") & intTotalLen & Mid(tblMainInfor.DefaultView(0).Item("Leader"), 6, 7) & strPadLeft1.PadLeft(5 - Len(CStr(intBaseAdd)), "0") & intBaseAdd & Right(tblMainInfor.DefaultView(0).Item("Leader"), 7)
                    strPadLeft1 = ""
                    strPadLeft2 = ""
                    strRecVal = objBCSP.ToUTF8Back(strLeader & strRecVal & CStr(Chr(31)) & strFGroupVal & CStr(Chr(29)))
                    rowNew.Item("Content") = strRecVal
                    tblResult.Rows.Add(rowNew)
                Next
            Catch ex As Exception
                rowNew.Item("Content") = ex.Message
                tblResult.Rows.Add(rowNew)
            End Try
            GetInfoISOUSMARC = tblResult
        End Function

        Public Function GetInfoISOTVQG() As DataTable
            Dim tblResult As New DataTable
            Dim rowNew As DataRow
            tblResult.Columns.Add("Content", System.Type.GetType("System.String"))
            rowNew = tblResult.NewRow()
            rowNew.Item("Content") = "No Support!"
            tblResult.Rows.Add(rowNew)
            GetInfoISOTVQG = tblResult
        End Function
 
        Public Function GetInfoISONACESTID() As DataTable
            Dim tblResult As New DataTable
            Dim rowNew As DataRow
            tblResult.Columns.Add("Content", System.Type.GetType("System.String"))
            rowNew = tblResult.NewRow()
            rowNew.Item("Content") = "No support!"
            tblResult.Rows.Add(rowNew)
            GetInfoISONACESTID = tblResult
        End Function

        Public Function GetInfoISBD() As DataTable
            Dim tblResult As New DataTable
            Dim rowNew As DataRow
            Dim arrIDs() As String = strItemIDs.Split(",")
            Dim intid As Integer
            Dim tblDetailInfor As DataTable
            Dim ISBDstr As String
            Dim i As Integer
            Try
                'get info record from database
                tblDetailInfor = GetItemDetailInfor()
                'initialize table Result
                tblResult.Columns.Add("Content", System.Type.GetType("System.String"))
                For intid = 0 To arrIDs.Length - 1
                    rowNew = tblResult.NewRow()
                    ISBDstr = "<b>" & CStr(intid + 1) & "</b>. "
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '100' AND ItemID=" & arrIDs(intid)
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        ISBDstr = ISBDstr & tblDetailInfor.DefaultView(0).Item("Content")
                    Else
                        tblDetailInfor.DefaultView.RowFilter = "FieldCode = '110' AND ItemID=" & arrIDs(intid)
                        If tblDetailInfor.DefaultView.Count > 0 Then
                            ISBDstr = ISBDstr & tblDetailInfor.DefaultView(0).Item("Content")
                        Else
                            tblDetailInfor.DefaultView.RowFilter = "FieldCode = '111' AND ItemID=" & arrIDs(intid)
                            If tblDetailInfor.DefaultView.Count > 0 Then
                                ISBDstr = ISBDstr & tblDetailInfor.DefaultView(0).Item("Content")
                            End If
                        End If
                    End If
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '245' AND ItemID=" & arrIDs(intid)
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        ISBDstr = ISBDstr & tblDetailInfor.DefaultView(0).Item("Content")
                    End If
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '250' AND ItemID=" & arrIDs(intid)
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        ISBDstr = ISBDstr & tblDetailInfor.DefaultView(0).Item("Content")
                    End If
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '260' AND ItemID=" & arrIDs(intid)
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        ISBDstr = ISBDstr & tblDetailInfor.DefaultView(0).Item("Content")
                    End If
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '300' AND ItemID=" & arrIDs(intid)
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        ISBDstr = ISBDstr & tblDetailInfor.DefaultView(0).Item("Content")
                    End If
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '400' AND ItemID=" & arrIDs(intid)
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        ISBDstr = ISBDstr & tblDetailInfor.DefaultView(0).Item("Content")
                    End If

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode LIKE '5%' AND ItemID=" & arrIDs(intid)
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        ISBDstr = ISBDstr & "<BR>"
                        For i = 0 To tblDetailInfor.DefaultView.Count - 1
                            ISBDstr = ISBDstr & "-" & tblDetailInfor.DefaultView(i).Item("Content")
                        Next
                    End If
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '020' AND ItemID=" & arrIDs(intid)
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        ISBDstr = ISBDstr & ". - " & tblDetailInfor.DefaultView(0).Item("Content")
                    End If
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode = '022' AND ItemID=" & arrIDs(intid)
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        ISBDstr = ISBDstr & ". - " & tblDetailInfor.DefaultView(0).Item("Content")
                    End If
                    rowNew.Item("Content") = objBCSP.TrimSubFieldCodes(ISBDstr)
                    tblResult.Rows.Add(rowNew)
                Next
            Catch ex As Exception
                rowNew = tblResult.NewRow()
                rowNew.Item("Content") = ex.Message
                tblResult.Rows.Add(rowNew)
            End Try
            GetInfoISBD = tblResult
        End Function
 
        Public Function GetInfoMARC() As DataTable
            Dim tblResult As New DataTable
            Dim rowNew As DataRow
            Dim arrIDs() As String = strItemIDs.Split(",")
            Dim intid, intfield As Integer
            Dim tblDetailInfor As DataTable
            Dim ISBDstr As String
            Try
                'get info record from database
                tblDetailInfor = GetItemDetailInfor()
                'initialize table Result
                tblResult.Columns.Add("Content", System.Type.GetType("System.String"))
                For intid = 0 To arrIDs.Length - 1
                    rowNew = tblResult.NewRow()
                    ISBDstr = ""
                    tblDetailInfor.DefaultView.RowFilter = "ItemID=" & arrIDs(intid)
                    For intfield = 0 To tblDetailInfor.DefaultView.Count - 1
                        ISBDstr = ISBDstr & tblDetailInfor.DefaultView(intfield).Item("FieldCode") & " " & tblDetailInfor.DefaultView(intfield).Item("Content") & "<br>"
                    Next
                    rowNew.Item("Content") = ISBDstr
                    tblResult.Rows.Add(rowNew)
                Next
            Catch ex As Exception
                rowNew = tblResult.NewRow()
                rowNew.Item("Content") = ex.Message
                tblResult.Rows.Add(rowNew)
            End Try
            GetInfoMARC = tblResult
        End Function

        Public Function GetInfoXMLMARC21() As DataTable
            Dim tblResult As New DataTable
            Dim rowNew As DataRow
            Dim arrIDs() As String = strItemIDs.Split(",")
            Dim intid, i, j As Integer
            Dim tblMainInfor, tblDetailInfor As DataTable
            Dim XMLStr As String = ""
            Dim strSpace As String = "&nbsp;&nbsp;&nbsp;"
            Try
                'get info record from database
                tblDetailInfor = GetItemDetailInfor()
                tblMainInfor = GetItemMainInfor()
                'initialize table Result
                tblResult.Columns.Add("Content", System.Type.GetType("System.String"))
                rowNew = tblResult.NewRow()
                XMLStr = ""
                If Me.InterfaceLanguage = "tcvn" Or Me.InterfaceLanguage = "vni" Then
                    XMLStr = "<?xml version=""1.0"" encoding='iso8859-1'?>"
                Else
                    XMLStr = "<?xml version=""1.0"" encoding=""UTF-8""?>"
                End If
                XMLStr = XMLStr & Chr(10) & "<downloadrecords>"

                For intid = 0 To arrIDs.Length - 1
                    XMLStr = XMLStr & Chr(10) & strSpace & "<record>"
                    XMLStr = XMLStr & Chr(10) & strSpace & strSpace & "<leader>" & tblMainInfor.Rows(intid).Item("Leader") & "</leader>"

                    For i = 0 To 9
                        tblDetailInfor.DefaultView.RowFilter = "FieldCode like '" & CStr(i) & "%' AND ItemID=" & arrIDs(intid)
                        If (tblDetailInfor.DefaultView.Count > 0) Or (i = 0) Then
                            XMLStr = XMLStr & Chr(10) & strSpace & strSpace & "<tag" & CStr(i) & "xx>"
                            If (Not IsDBNull(tblMainInfor.Rows(intid).Item("Code"))) And (i = 0) Then
                                XMLStr = XMLStr & Chr(10) & strSpace & strSpace & strSpace & "<recid>" & tblMainInfor.Rows(intid).Item("Code") & "</recid>"
                            End If
                            For j = 0 To tblDetailInfor.DefaultView.Count - 1
                                XMLStr = XMLStr & Chr(10) & strSpace & strSpace & strSpace & "<v" & tblDetailInfor.DefaultView(j).Item("FieldCode") & ">"
                                If Not IsDBNull(tblDetailInfor.DefaultView(j).Item("Ind1")) Then
                                    XMLStr = XMLStr & Chr(10) & strSpace & strSpace & strSpace & strSpace & "<ind" & tblDetailInfor.DefaultView(j).Item("FieldCode") & ">"
                                    XMLStr = XMLStr & tblDetailInfor.DefaultView(j).Item("Ind1")
                                    XMLStr = XMLStr & "</ind" & tblDetailInfor.DefaultView(j).Item("FieldCode") & ">"
                                End If
                                XMLStr = XMLStr & Chr(10) & strSpace & strSpace & strSpace & strSpace & "<val" & tblDetailInfor.DefaultView(j).Item("FieldCode") & ">"
                                XMLStr = XMLStr & tblDetailInfor.DefaultView(j).Item("Content")
                                XMLStr = XMLStr & "</val" & tblDetailInfor.DefaultView(j).Item("FieldCode") & ">"
                                XMLStr = XMLStr & Chr(10) & strSpace & strSpace & strSpace & "</v" & tblDetailInfor.DefaultView(j).Item("FieldCode") & ">"
                            Next
                            XMLStr = XMLStr & Chr(10) & strSpace & strSpace & "</tag" & CStr(i) & "xx>"
                        End If
                    Next
                    XMLStr = XMLStr & Chr(10) & strSpace & "</record>"
                Next
                XMLStr = XMLStr & Chr(10) & "</downloadrecords>"
                rowNew.Item("Content") = ConverXML2Text(objBCSP.TrimSubFieldCodes(XMLStr))
                'ConverXML2Text()
                tblResult.Rows.Add(rowNew)
            Catch ex As Exception
                rowNew = tblResult.NewRow()
                rowNew.Item("Content") = ex.Message
                tblResult.Rows.Add(rowNew)
            End Try
            GetInfoXMLMARC21 = tblResult
        End Function

        Function GetInfoXMLDCMI() As DataTable

            Dim tblResult As New DataTable
            Dim rowNew As DataRow
            Dim arrIDs() As String = strItemIDs.Split(",")
            Dim intid, i, j As Integer
            Dim tblMainInfor, tblDetailInfor As DataTable
            Dim XMLStream As String = ""
            Dim strSpace As String = "&nbsp;&nbsp;&nbsp;"
            Dim SubRecords() As String
            Dim strtemp As String
            Try
                'get info record from database
                tblDetailInfor = GetItemDetailInfor()
                tblMainInfor = GetItemMainInfor()
                'initialize table Result
                tblResult.Columns.Add("Content", System.Type.GetType("System.String"))
                rowNew = tblResult.NewRow()
                XMLStream = ""
                If Me.InterfaceLanguage = "tcvn" Or Me.InterfaceLanguage = "vni" Then
                    XMLStream = "<?xml version=""1.0"" encoding=""iso8859-1""?>"
                Else
                    XMLStream = "<?xml version=""1.0"" encoding=""UTF-8""?>"
                End If
                XMLStream = XMLStream & Chr(10) & "<!DOCTYPE rdf:RDF (View Source for full doctype...)> "
                XMLStream = XMLStream & Chr(10) & "<rdf:RDF xmlns:dc=""xmlfiles/dcns.xml"" xmlns:rdf=""xmlfiles/rdfns.xml"">"

                For intid = 0 To arrIDs.Length - 1
                    XMLStream = XMLStream & Chr(10) & strSpace & "<rdf:Description>"

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode='245' AND ItemID=" & arrIDs(intid)
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        XMLStream = XMLStream & Chr(10) & strSpace & strSpace & "<dc:title>"
                        XMLStream = XMLStream & tblDetailInfor.DefaultView(0).Item("Content")
                        XMLStream = XMLStream & "</dc:title>"
                    End If

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode in ('100','110','111','700','710','711') AND ItemID=" & arrIDs(intid)
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        For i = 0 To tblDetailInfor.DefaultView.Count - 1
                            XMLStream = XMLStream & Chr(10) & strSpace & strSpace & "<dc:creator>"
                            XMLStream = XMLStream & tblDetailInfor.DefaultView(0).Item("Content")
                            XMLStream = XMLStream & "</dc:creator>"
                        Next
                    End If

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode in ('600','610','611','630','650','653') AND ItemID=" & arrIDs(intid)
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        For i = 0 To tblDetailInfor.DefaultView.Count - 1
                            XMLStream = XMLStream & Chr(10) & strSpace & strSpace & "<dc:subject>"
                            XMLStream = XMLStream & tblDetailInfor.DefaultView(0).Item("Content")
                            XMLStream = XMLStream & "</dc:subject>"
                        Next
                    End If

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode in ('500','501','502','503','504','505','507','508','510','511','512','513') AND ItemID=" & arrIDs(intid)
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        For i = 0 To tblDetailInfor.DefaultView.Count - 1
                            XMLStream = XMLStream & Chr(10) & strSpace & strSpace & "<dc:description>"
                            XMLStream = XMLStream & tblDetailInfor.DefaultView(0).Item("Content")
                            XMLStream = XMLStream & "</dc:description>"
                        Next
                    End If

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode ='260' AND ItemID=" & arrIDs(intid)
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        If Not IsDBNull(tblDetailInfor.DefaultView(0).Item("Content")) Then
                            Call objBCSP.ParseField("$a,$b,$c", tblDetailInfor.DefaultView(0).Item("Content"), "nc ", SubRecords)
                        End If
                        If SubRecords(0) <> "" Or SubRecords(1) <> "" Then
                            XMLStream = XMLStream & Chr(10) & strSpace & strSpace & "<dc:publisher>"
                            XMLStream = XMLStream & Trim(objBCSP.ConvertIt(SubRecords(0) & SubRecords(1)))
                            XMLStream = XMLStream & "</dc:publisher>"
                        End If
                        If SubRecords(2) <> "" Then
                            XMLStream = XMLStream & Chr(10) & strSpace & strSpace & "<dc:date>"
                            XMLStream = XMLStream & Trim(objBCSP.ConvertIt(SubRecords(2)))
                            XMLStream = XMLStream & "</dc:date>"
                        End If
                    End If

                    tblMainInfor.DefaultView.RowFilter = "ItemID=" & arrIDs(intid)
                    Select Case Mid(tblMainInfor.DefaultView(0).Item("Leader"), 7, 1)
                        Case "a", "c", "d", "t"
                            strtemp = "text"
                        Case "e", "f", "g", "k"
                            strtemp = "image"
                        Case "m", "o", "p", "r"
                            strtemp = "no type provided"
                        Case Else
                            Select Case Mid(tblMainInfor.DefaultView(0).Item("Leader"), 8, 1)
                                Case "c", "s", "p"
                                    strtemp = "collection"
                            End Select
                    End Select
                    XMLStream = XMLStream & Chr(10) & strSpace & strSpace & "<dc:type>"
                    XMLStream = XMLStream & strtemp
                    XMLStream = XMLStream & "</dc:type>"

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode='655' AND ItemID=" & arrIDs(intid)
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        XMLStream = XMLStream & Chr(10) & strSpace & strSpace & "<dc:title>"
                        XMLStream = XMLStream & tblDetailInfor.DefaultView(0).Item("Content")
                        XMLStream = XMLStream & "</dc:title>"
                    End If

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode ='856' AND ItemID=" & arrIDs(intid)
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        If Not IsDBNull(tblDetailInfor.DefaultView(0).Item("Content")) Then
                            Call objBCSP.ParseField("$q,$u", tblDetailInfor.DefaultView(0).Item("Content"), "nc", SubRecords)
                        End If
                        If Not SubRecords(0) = "" Then
                            XMLStream = XMLStream & Chr(10) & strSpace & strSpace & "<dc:format>"
                            XMLStream = XMLStream & objBCSP.ConvertIt(SubRecords(0))
                            XMLStream = XMLStream & "</dc:format>"
                        End If
                        If Not SubRecords(1) = "" Then
                            XMLStream = XMLStream & Chr(10) & strSpace & strSpace & "<dc:identifier>"
                            XMLStream = XMLStream & objBCSP.ConvertIt(SubRecords(1))
                            XMLStream = XMLStream & "</dc:identifier>"
                        End If
                    End If

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode ='786' AND ItemID=" & arrIDs(intid)
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        If Not IsDBNull(tblDetailInfor.DefaultView(0).Item("Content")) Then
                            Call objBCSP.ParseField("$o,$t", tblDetailInfor.DefaultView(0).Item("Content"), "nc", SubRecords)
                        End If
                        If Not SubRecords(0) = "" Or Not SubRecords(1) = "" Then
                            XMLStream = XMLStream & Chr(10) & strSpace & strSpace & "<dc:source>"
                            XMLStream = XMLStream & objBCSP.ConvertIt(SubRecords(0) & SubRecords(1))
                            XMLStream = XMLStream & "</dc:source>"
                        End If
                    End If

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode='008' AND ItemID=" & arrIDs(intid)
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        XMLStream = XMLStream & Chr(10) & strSpace & strSpace & "<dc:language>"
                        XMLStream = XMLStream & Mid(tblDetailInfor.DefaultView(0).Item("Content"), 36, 3)
                        XMLStream = XMLStream & "</dc:language>"
                    End If
                    tblDetailInfor.DefaultView.RowFilter = "FieldCode='546' AND ItemID=" & arrIDs(intid)
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        XMLStream = XMLStream & Chr(10) & strSpace & strSpace & "<dc:language>"
                        XMLStream = XMLStream & tblDetailInfor.DefaultView(0).Item("Content")
                        XMLStream = XMLStream & "</dc:language>"
                    End If

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode='530' AND ItemID=" & arrIDs(intid)
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        XMLStream = XMLStream & Chr(10) & strSpace & strSpace & "<dc:relation>"
                        XMLStream = XMLStream & tblDetailInfor.DefaultView(0).Item("Content")
                        XMLStream = XMLStream & "</dc:relation>"
                    End If

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode in ('760','762','787') AND ItemID=" & arrIDs(intid)
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        For i = 0 To tblDetailInfor.DefaultView.Count - 1
                            If Not IsDBNull(tblDetailInfor.DefaultView(0).Item("Content")) Then
                                Call objBCSP.ParseField("$o,$t", tblDetailInfor.DefaultView(0).Item("Content"), "nc", SubRecords)
                            End If
                            If SubRecords(0) <> "" Or SubRecords(1) <> "" Then
                                XMLStream = XMLStream & Chr(10) & strSpace & strSpace & "<dc:relation>"
                                XMLStream = XMLStream & objBCSP.ConvertIt(SubRecords(0) & SubRecords(1))
                                XMLStream = XMLStream & "</dc:relation>"
                            End If
                        Next
                    End If

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode IN ('651','752') AND ItemID=" & arrIDs(intid)
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        XMLStream = XMLStream & Chr(10) & strSpace & strSpace & "<dc:coverage>"
                        XMLStream = XMLStream & tblDetailInfor.DefaultView(0).Item("Content")
                        XMLStream = XMLStream & "</dc:coverage>"
                    End If

                    tblDetailInfor.DefaultView.RowFilter = "FieldCode IN ('540','506') AND ItemID=" & arrIDs(intid)
                    If tblDetailInfor.DefaultView.Count > 0 Then
                        XMLStream = XMLStream & Chr(10) & strSpace & strSpace & "<dc:rights>"
                        XMLStream = XMLStream & tblDetailInfor.DefaultView(0).Item("Content")
                        XMLStream = XMLStream & "</dc:rights>"
                    End If

                    XMLStream = XMLStream & Chr(10) & strSpace & "</rdf:Description>"
                Next
                XMLStream = XMLStream & Chr(10) & "</rdf:RDF>"
                rowNew.Item("Content") = ConverXML2Text(objBCSP.TrimSubFieldCodes(XMLStream))
                tblResult.Rows.Add(rowNew)
            Catch ex As Exception
                rowNew = tblResult.NewRow()
                rowNew.Item("Content") = ex.Message
                tblResult.Rows.Add(rowNew)
            End Try
            GetInfoXMLDCMI = tblResult
        End Function

        ' purpose : convert XML to text for write format XML out HTML
        Public Function ConverXML2Text(ByVal strXML As String) As String
            Dim strReplace As String = strXML
            strReplace = strReplace.Replace("<", "&lt;")
            strReplace = strReplace.Replace(">", "&gt;")
            strReplace = strReplace.Replace(Chr(10), "<br>")
            ConverXML2Text = strReplace
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objDItemCollection Is Nothing Then
                    objDItemCollection.Dispose(True)
                    objDItemCollection = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
            Finally
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace