Imports eMicLibAdmin.DataAccess
Imports eMicLibAdmin.DataAccess.Common
Imports eMicLibAdmin.BusinessRules.Catalogue
Namespace eMicLibAdmin.BusinessRules.Common
    Public Class clsBFormingSQL
        Inherits clsBBase
        Private objBCommonDBSystem As New clsBCommonDBSystem
        Private objBCommonStringProc As New clsBCommonStringProc
        Private objBCatDicList As New clsBCatDicList
        Private objBoolArr()
        Private objFieldArr()
        Private objValArr()


        Public Property ValArr()
            Get
                Return objValArr
            End Get
            Set(ByVal Value)
                objValArr = Value
            End Set
        End Property

        Public Property FieldArr()
            Get
                Return objFieldArr
            End Get
            Set(ByVal Value)
                objFieldArr = Value
            End Set
        End Property

        Public Property BoolArr()
            Get
                Return objBoolArr
            End Get
            Set(ByVal Value)
                objBoolArr = Value
            End Set
        End Property

        Public Sub Initialize()
            objBCommonDBSystem.ConnectionString = strConnectionstring
            objBCommonDBSystem.DBServer = strDBServer
            objBCommonDBSystem.InterfaceLanguage = strInterfaceLanguage
            objBCommonDBSystem.Initialize()

            objBCommonStringProc.InterfaceLanguage = strInterfaceLanguage
            objBCommonStringProc.ConnectionString = strConnectionstring
            objBCommonStringProc.DBServer = strDBServer
            objBCommonStringProc.Initialize()

            objBCatDicList.ConnectionString = strConnectionstring
            objBCatDicList.DBServer = strDBServer
            objBCatDicList.InterfaceLanguage = strInterfaceLanguage
            objBCatDicList.Initialize()
        End Sub

        Public Function FormingASQL(Optional ByVal intTop As Integer = 0, Optional ByVal intCheckHolding As Integer = 0) As String
            If objFieldArr Is Nothing Then
                FormingASQL = ""
                Exit Function
            End If
            Dim strFinalsql As String
            Dim strUnionsql As String
            Dim strMysql As String
            Dim strMysql1 As String
            Dim inti As Integer
            Dim blnUseFulltextIndex As Boolean
            Dim strTitle As String
            Dim strStartYr As String
            Dim strEndYr As String
            'Dim objUtf8 As New TVCOMLib.utf8
            Dim TblCatDicList As New DataTable
            Dim strval1 As String
            Dim strDicTable As String
            Dim strResult As String = ""
            strFinalsql = ""
            strUnionsql = ""
            For inti = LBound(objFieldArr) To UBound(objFieldArr)
                If Not Trim(objValArr(inti)) = "" Then
                    'Comment by chuyenpt(16/03/07): Bo cac dau "'" neu nguoi dung nhap vao. Vi du: "'Ha Noi'" --> ""Ha Noi""
                    ''objValArr(inti) = Replace(objValArr(inti), "'", "''")
                    strMysql = ""
                  ''  objValArr(inti) = objBCommonStringProc.ConvertItBack(objValArr(inti))
                    Select Case objFieldArr(inti)
                        Case "FT"
                            objValArr(inti) = objBCommonStringProc.ProcessVal(objValArr(inti))
                            objValArr(inti) = Replace(objValArr(inti), "'", "''")
                            If CStr(objValArr(inti)).Length = 1 Then
                                Select Case UCase(strDBServer)
                                    Case "SQLSERVER"
                                        strMysql = "SELECT ItemID FROM Lib_tblItemFulltext WHERE Contents like '%" & objValArr(inti) & "%'"
                                    Case "ORACLE"
                                        If InStr(objValArr(inti), """") = 0 Then
                                            objValArr(inti) = """" & objValArr(inti) & """"
                                        End If
                                        strMysql = "SELECT ItemID FROM Lib_tblItemFulltext WHERE CONTAINS(Contents, '" & objValArr(inti) & "') > 0"
                                End Select
                            Else
                                If InStr(objValArr(inti), """") = 0 Then
                                    objValArr(inti) = """" & objValArr(inti) & """"
                                End If
                                Select Case UCase(strDBServer)
                                    Case "SQLSERVER"
                                        strMysql = "SELECT ItemID FROM Lib_tblItemFulltext WHERE CONTAINS(Contents, '" & objValArr(inti) & "')"
                                    Case "ORACLE"
                                        strMysql = "SELECT ItemID FROM Lib_tblItemFulltext WHERE CONTAINS(Contents, '" & objValArr(inti) & "') > 0"
                                End Select
                            End If
                        Case "TI", "TP", "TZ"
                            If (Right(objValArr(inti), 1) = "%") Or (Left(objValArr(inti), 1) = "%") Then
                                blnUseFulltextIndex = False
                            Else
                                blnUseFulltextIndex = True
                            End If
                            strTitle = objBCommonStringProc.ProcessVal(objValArr(inti))
                           '' strTitle = Replace(strTitle, "'", "''")
                            If blnUseFulltextIndex And strTitle.Length = 1 And UCase(strDBServer) = "SQLSERVER" Then
                                blnUseFulltextIndex = False
                            End If
                            If blnUseFulltextIndex Then
                                If InStr(strTitle, """") = 0 Then
                                    strTitle = """" & strTitle & """"
                                End If
                                Select Case UCase(strDBServer)
                                    Case "SQLSERVER"
                                        strMysql = "SELECT ItemID FROM Lib_tblItemTitle WHERE CONTAINS(Title, '" & strTitle & "')"
                                    Case "ORACLE"
                                        strMysql = "SELECT ItemID FROM Lib_tblItemTitle WHERE CONTAINS(Title, '" & strTitle & "') > 0"
                                End Select
                            Else
                                Select Case UCase(strDBServer)
                                    Case "SQLSERVER"
                                        strMysql = "SELECT ItemID FROM Lib_tblItemTitle WHERE Title LIKE N'" & strTitle & "'"
                                    Case "ORACLE"
                                        strMysql = "SELECT ItemID FROM Lib_tblItemTitle WHERE title LIKE '" & strTitle & "'"
                                End Select
                            End If
                            If objFieldArr(inti) = "TP" Then
                                strMysql = strMysql & " AND FieldCode = '245'"
                            End If
                        Case "YR"
                            If InStr(objValArr(inti), "-") = 0 Then
                                strMysql = strMysql & " AND Year LIKE '" & objValArr(inti) & "'"
                            Else
                                strStartYr = Trim(Left(objValArr(inti), InStr(objValArr(inti), "-") - 1))
                                strEndYr = Trim(Right(objValArr(inti), Len(objValArr(inti)) - InStr(ValArr(inti), "-")))
                                If Not strStartYr = "" Then
                                    strMysql = strMysql & " AND Year >= '" & strStartYr & "'"
                                End If
                                If Not strEndYr = "" Then
                                    If Len(strStartYr) > Len(strEndYr) Then
                                        strEndYr = Left(strStartYr, Len(strStartYr) - Len(strEndYr)) & strEndYr
                                    End If
                                    strMysql = strMysql & " AND Year <= '" & strEndYr & "'"
                                End If
                            End If
                            strMysql = "SELECT Cat_tblDicYear.ItemID FROM Cat_tblDicYear WHERE " & Right(strMysql, Len(strMysql) - 5)
                        Case "CN"
                            Select Case UCase(strDBServer)
                                Case "SQLSERVER"
                                    strMysql = " SELECT ID FROM Lib_tblItem WHERE CallNumber LIKE N'%" & objBCommonStringProc.ProcessVal(objValArr(inti)) & "%'"
                                Case "ORACLE"
                                    strMysql = " SELECT ID FROM Lib_tblItem WHERE UPPER(CallNumber) LIKE UPPER('" & objValArr(inti) & "')"
                            End Select
                        Case "BI"
                            Select Case UCase(strDBServer)
                                Case "SQLSERVER"
                                    strMysql = " SELECT ID FROM Lib_tblItem WHERE Code LIKE N'%" & objBCommonStringProc.ProcessVal(objValArr(inti)) & "%'"
                                Case "ORACLE"
                                    strMysql = " SELECT ID FROM Lib_tblItem WHERE UPPER(Code) LIKE UPPER('" & objValArr(inti) & "')"
                            End Select
                        Case "IN"
                            Select Case UCase(strDBServer)
                                Case "SQLSERVER"
                                    strMysql = " SELECT ItemID FROM Ser_tblIssue WHERE IssueNo LIKE N'%" & objBCommonStringProc.ProcessVal(objValArr(inti)) & "%'"
                                Case "ORACLE"
                                    strMysql = " SELECT ItemID FROM Ser_tblIssue WHERE UPPER(IssueNo) LIKE UPPER('" & objValArr(inti) & "')"
                            End Select
                        Case "IV"
                            Select Case UCase(strDBServer)
                                Case "SQLSERVER"
                                    strMysql = " SELECT ItemID FROM Ser_tblIssue WHERE Volume LIKE N'%" & objBCommonStringProc.ProcessVal(objValArr(inti)) & "%'"
                                Case "ORACLE"
                                    strMysql = " SELECT ItemID FROM Ser_tblIssue WHERE UPPER(Volume) LIKE UPPER('" & objValArr(inti) & "')"
                            End Select
                        Case "IF"
                            strMysql = " SELECT ID FROM Lib_tblItem WHERE ID >= " & ValArr(inti)
                        Case "IE"
                            strMysql = " SELECT ID FROM Lib_tblItem WHERE ID <= " & ValArr(inti)
                        Case "US"
                            Select Case UCase(strDBServer)
                                Case "SQLSERVER"
                                    strMysql = " SELECT ID FROM Lib_tblItem WHERE Reviewer LIKE N'%" & objBCommonStringProc.ProcessVal(objValArr(inti)) & "%'"
                                Case "ORACLE"
                                    strMysql = " SELECT ID FROM Lib_tblItem WHERE UPPER(Reviewer) LIKE UPPER('" & objValArr(inti) & "')"
                            End Select
                        Case "PF"
                            Select Case UCase(strDBServer)
                                Case "SQLSERVER"
                                    strMysql = " SELECT ItemID FROM Ser_tblIssue WHERE IssuedDate >= CONVERT(datetime, '" & objValArr(inti) & "', 103)"
                                Case "ORACLE"
                                    strMysql = " SELECT ItemID FROM Ser_tblIssue WHERE IssuedDate >= To_Date('" & objValArr(inti) & "', 'dd/mm/yyyy')"
                            End Select
                        Case "PT"
                            Select Case UCase(strDBServer)
                                Case "SQLSERVER"
                                    strMysql = " SELECT ItemID FROM IssuedDate WHERE IssuedDate <= CONVERT(datetime, '" & objValArr(inti) & "', 103)"
                                Case "ORACLE"
                                    strMysql = " SELECT ItemID FROM IssuedDate WHERE IssuedDate <= To_Date('" & objValArr(inti) & "', 'dd/mm/yyyy')"
                            End Select
                        Case "FR"
                            strMysql = " SELECT ItemID FROM Ser_tblItem WHERE FreqCode = '" & objValArr(inti) & "'"
                        Case "BN"
                            Select Case UCase(strDBServer)
                                Case "SQLSERVER"
                                    ' strMysql = " SELECT ItemID FROM HOLDING WHERE CopyNumber LIKE '" & objBCommonStringProc.ProcessVal(objValArr(inti)) & "'"
                                    'PHUONGTT 
                                    '20080810
                                    'B3
                                    strMysql = " SELECT ItemID FROM Lib_tblHolding WHERE CopyNumber LIKE '%" & Trim(objValArr(inti)) & "%'"
                                    'E3
                                Case "ORACLE"
                                    strMysql = " SELECT ItemID FROM HOLDING WHERE UPPER(CopyNumber) LIKE UPPER('" & objValArr(inti) & "')"
                            End Select
                        Case "IB"
                            Select Case UCase(strDBServer)
                                Case "SQLSERVER"
                                    strMysql = " SELECT ItemID FROM Lib_tblField000S WHERE Content LIKE '%" & objValArr(inti) & "%' AND FieldCode = '020'"
                                Case "ORACLE"
                                    strMysql = " SELECT CAT_DIC_NUMBER.ItemID FROM CAT_DIC_NUMBER WHERE ""NUMBER"" LIKE '%" & objValArr(inti) & "%' AND FieldCode = '020'"
                            End Select
                        Case "IS"
                            Select Case UCase(strDBServer)
                                Case "SQLSERVER"
                                    strMysql = " SELECT CAT_DIC_NUMBER.ItemID FROM CAT_DIC_NUMBER WHERE Number LIKE '%" & Replace(objValArr(inti), "-", "") & "%' AND FieldCode = '022'"
                                Case "ORACLE"
                                    strMysql = " SELECT CAT_DIC_NUMBER.ItemID FROM CAT_DIC_NUMBER WHERE ""NUMBER"" LIKE '%" & Replace(objValArr(inti), "-", "") & "%' AND FieldCode = '022'"
                            End Select
                        Case "IT"
                            If Not IsNumeric(objValArr(inti)) Then
                                Select Case UCase(strDBServer)
                                    Case "SQLSERVER"
                                        strMysql = " SELECT Lib_tblItem.ID FROM Lib_tblItem, Cat_tblDic_ItemType WHERE Lib_tblItem.TypeID = Cat_tblDic_ItemType.ID   AND TypeCode LIKE '%" & objValArr(inti) & "%'" 'objUtf8.SearchPattern(objValArr(inti))
                                    Case "ORACLE"
                                        strMysql = " SELECT Lib_tblItem.ID FROM Lib_tblItem, Cat_tblDic_ItemType WHERE Lib_tblItem.TypeID = Cat_tblDic_ItemType.ID AND TypeCode LIKE '" & objValArr(inti) & "'"
                                End Select
                            Else
                                strMysql = "SELECT ID FROM Lib_tblItem WHERE TypeID = " & objValArr(inti)
                            End If
                        Case "CA"
                            Select Case UCase(strDBServer)
                                Case "SQLSERVER"
                                    strMysql = " SELECT ID FROM Lib_tblItem WHERE Cataloguer LIKE N'%" & objBCommonStringProc.ProcessVal(objValArr(inti)) & "%'"
                                Case "ORACLE"
                                    strMysql = " SELECT ID FROM Lib_tblItem WHERE UPPER(Cataloguer) LIKE UPPER('" & objValArr(inti) & "')"
                            End Select

                        Case "CO"
                            Select Case UCase(strDBServer)
                                Case "SQLSERVER"
                                    strMysql = " SELECT ID FROM Lib_tblItem WHERE Code LIKE N'%" & objBCommonStringProc.ProcessVal(objValArr(inti)) & "%'"
                                Case "ORACLE"
                                    strMysql = " SELECT ID FROM Lib_tblItem WHERE UPPER(Code) LIKE UPPER('" & objValArr(inti) & "')"
                            End Select

                        Case "FROMID"
                            Select Case UCase(strDBServer)
                                Case "SQLSERVER"
                                    strMysql = " SELECT Lib_tblItem.ID FROM Lib_tblItem WHERE Lib_tblItem.ID >= " & objValArr(inti)
                                Case "ORACLE"
                                    strMysql = " SELECT Lib_tblItem.ID FROM Lib_tblItem WHERE Lib_tblItem.ID >= " & objValArr(inti)
                            End Select
                        Case "TOID"
                            Select Case UCase(strDBServer)
                                Case "SQLSERVER"
                                    strMysql = " SELECT Lib_tblItem.ID FROM Lib_tblItem WHERE Lib_tblItem.ID <= " & objValArr(inti)
                                Case "ORACLE"
                                    strMysql = " SELECT Lib_tblItem.ID FROM Lib_tblItem WHERE Lib_tblItem.ID <= " & objValArr(inti)
                            End Select
                        Case "FROMDTE"
                            Select Case UCase(strDBServer)
                                Case "SQLSERVER"
                                    strMysql = " SELECT Lib_tblItem.ID FROM Lib_tblItem WHERE CreatedDate >= CONVERT(datetime,'" & objValArr(inti) & "',103)"
                                Case "ORACLE"
                                    strMysql = " SELECT Lib_tblItem.ID FROM Lib_tblItem WHERE CreatedDate >= To_Date('" & objValArr(inti) & "','dd/mm/yyyy')"
                            End Select

                        Case "TODTE"
                            Select Case UCase(strDBServer)
                                Case "SQLSERVER"
                                    strMysql = " SELECT Lib_tblItem.ID FROM Lib_tblItem WHERE CreatedDate <= CONVERT(datetime,'" & objValArr(inti) & "',103)"
                                Case "ORACLE"
                                    strMysql = " SELECT Lib_tblItem.ID FROM Lib_tblItem WHERE CreatedDate <= To_Date('" & objValArr(inti) & "','dd/mm/yyyy')"
                            End Select
                        Case "ITEMTYPE"
                            strMysql = " SELECT Lib_tblItem.ID FROM Lib_tblItem WHERE TypeID IN(" & objValArr(inti) & ")"
                        Case "LIBID"
                            strMysql = " SELECT Lib_tblHolding.ItemID FROM Lib_tblHolding WHERE LibID = " & objValArr(inti)
                        Case "LOCID"
                            strMysql = " SELECT Lib_tblHolding.ItemID FROM Lib_tblHolding WHERE LocationID = " & objValArr(inti)
                        Case "FROMIC"
                            strMysql = " SELECT Lib_tblItem.ID FROM Lib_tblItem WHERE Code >= '" & objValArr(inti) & "' AND  LEN(Code)>=" & Len(objValArr(inti) & "")
                        Case "TOIC"
                            strMysql = " SELECT Lib_tblItem.ID FROM Lib_tblItem WHERE Code <= '" & objValArr(inti) & "' AND  LEN(Code)<=" & Len(objValArr(inti) & "")
                        Case Else
                            strMysql = "1 = 1"
                            If IsNumeric(objFieldArr(inti)) Then
                                objBCatDicList.IDs = CStr(objFieldArr(inti))
                                objBCatDicList.IsClassifiCation = -1
                                objBCatDicList.IsAuthority = -1
                                objBCatDicList.SystemDic = 2
                                TblCatDicList = objBCatDicList.Retrieve
                                strval1 = objBCommonStringProc.ProcessVal(objValArr(inti))
                                If TblCatDicList.Rows.Count > 0 Then
                                    strDicTable = TblCatDicList.Rows(0).Item("DicTable")

                                    'Alter by chuyenpt(22/08/07): tim kiem khong dau

                                    'Select Case strDicTable
                                    '    Case "CAT_DIC_ITEM_TYPE"
                                    '        strMysql = "SELECT Lib_tblItem.ID FROM Lib_tblItem,CAT_DIC_ITEM_TYPE WHERE Lib_tblItem.TypeID = CAT_DIC_ITEM_TYPE.ID AND TypeCode "
                                    '    Case "CAT_DIC_MEDIUM"
                                    '        strMysql = "SELECT Lib_tblItem.ID FROM Lib_tblItem,CAT_DIC_MEDIUM WHERE Lib_tblItem.MediumID = CAT_DIC_MEDIUM.ID AND AccessEntry "
                                    '    Case Else
                                    '        If Not IsDBNull(TblCatDicList.Rows(0).Item("IndexTable")) Then
                                    '            strMysql = " SELECT ItemID FROM " & Trim(TblCatDicList.Rows(0).Item("DicTable") & "") & ", " & Trim(TblCatDicList.Rows(0).Item("IndexTable") & "") & " WHERE " & Trim(TblCatDicList.Rows(0).Item("DicTable") & "") & "." & Trim(TblCatDicList.Rows(0).Item("DicIDField") & "") & " = " & Trim(TblCatDicList.Rows(0).Item("IndexTable") & "") & "." & Trim(TblCatDicList.Rows(0).Item("IndexIDField") & "") & " AND AccessEntry"
                                    '        Else
                                    '            strMysql = " SELECT ItemID FROM " & Trim(TblCatDicList.Rows(0).Item("DicTable") & "") & ", HOLDING WHERE " & Trim(TblCatDicList.Rows(0).Item("DicTable") & "") & ".ID = HOLDING.LibID" & " AND HOLDING_LIBRARY.AccessEntry"
                                    '        End If
                                    'End Select
                                    Select Case strDicTable
                                        'Phuong
                                        'Modify  20080810
                                        'Purpose : chèn dấu phẩy vào cuối chuỗi đối với loại tìm kiếm là vật mang tin và dạng tài liệu
                                        'B1
                                        Case "Cat_tblDic_ItemType"
                                            strMysql = "SELECT Lib_tblItem.ID FROM Lib_tblItem,Cat_tblDic_ItemType WHERE Lib_tblItem.TypeID = Cat_tblDic_ItemType.ID  "
                                            strMysql1 = " AND (" & CStr(TblCatDicList.Rows(0).Item("SearchFields")).Trim
                                            If Right(strMysql1.Trim, 1) <> "," Then
                                                strMysql1 = strMysql1 & ","
                                            End If
                                            'If strMysql1.IndexOf(",") <= 0 Then
                                            '    strMysql1 = strMysql1 & ","
                                            'End If
                                        Case "Cat_tblDicMedium"
                                            strMysql = "SELECT Lib_tblItem.ID FROM Lib_tblItem,Cat_tblDicMedium WHERE Lib_tblItem.MediumID = Cat_tblDicMedium.ID  "
                                            strMysql1 = " AND (" & CStr(TblCatDicList.Rows(0).Item("SearchFields")).Trim
                                            strMysql1 = strMysql1.Replace("Code", "Cat_tblDicMedium.Code")
                                            'AccessEntry,Code,Description
                                            If Right(strMysql1.Trim, 1) <> "," Then
                                                strMysql1 = strMysql1 & ","
                                            End If
                                            'If strMysql1.IndexOf(",") <= 0 Then
                                            '    strMysql1 = strMysql1 & ","
                                            'End If
                                            'E1
                                        Case Else
                                            If Not IsDBNull(TblCatDicList.Rows(0).Item("IndexTable")) Then
                                                strMysql = " SELECT ItemID FROM " & Trim(TblCatDicList.Rows(0).Item("DicTable") & "") & ", " & Trim(TblCatDicList.Rows(0).Item("IndexTable") & "") & " WHERE " & Trim(TblCatDicList.Rows(0).Item("DicTable") & "") & "." & Trim(TblCatDicList.Rows(0).Item("DicIDField") & "") & " = " & Trim(TblCatDicList.Rows(0).Item("IndexTable") & "") & "." & Trim(TblCatDicList.Rows(0).Item("IndexIDField") & "")
                                                strMysql1 = " AND (" & CStr(TblCatDicList.Rows(0).Item("SearchFields")).Trim
                                                If Right(strMysql1, 1) <> "," Then
                                                    strMysql1 = strMysql1 & ","
                                                End If
                                            Else
                                                strMysql = " SELECT ItemID FROM " & Trim(TblCatDicList.Rows(0).Item("DicTable") & "") & ", Lib_tblHolding WHERE " & Trim(TblCatDicList.Rows(0).Item("DicTable") & "") & ".ID = Lib_tblHolding.LibID"
                                                '& " AND HOLDING_LIBRARY.AccessEntry"
                                                'PHUONGTT
                                                '20080810
                                                'B2
                                                strMysql1 = " AND (" & CStr(TblCatDicList.Rows(0).Item("SearchFields")).Trim
                                                If Right(strMysql1, 1) <> "," Then
                                                    strMysql1 = strMysql1 & ","
                                                End If
                                                'E2
                                            End If
                                    End Select
                                    Select Case UCase(strDBServer)

                                        'Alter by chuyenpt(22/08/07): tim kiem khong dau

                                        'Case "SQLSERVER"
                                        '    strMysql = strMysql & " LIKE N'" & strval1 & "'"
                                        'Case "ORACLE"
                                        '    strMysql = strMysql & " LIKE '" & strval1 & "'"
                                        'Case Else
                                        Case "SQLSERVER"
                                            strMysql = strMysql & strMysql1.Replace(",", " LIKE N'%" & strval1 & "%' OR ")
                                            strMysql = Left(strMysql, Len(strMysql) - 3) & " ) "
                                        Case "ORACLE"
                                            strMysql = strMysql & strMysql1.Replace(",", " LIKE '" & strval1 & "' OR")
                                            strMysql = Left(strMysql, Len(strMysql) - 3) & " ) "
                                        Case Else
                                    End Select
                                End If
                            End If
                    End Select
                    If Not strMysql = "1 = 1" Then
                        Select Case UCase(strDBServer)
                            Case "SQLSERVER"
                                Select Case objBoolArr(inti)
                                    Case "AND"
                                        strFinalsql = strFinalsql & " AND Lib_tblItem.ID IN (" & strMysql & ")"
                                    Case "OR"
                                        strUnionsql = strUnionsql & " UNION " & strMysql
                                    Case "NOT"
                                        strFinalsql = strFinalsql & " AND Lib_tblItem.ID NOT IN (" & strMysql & ")"
                                End Select
                            Case "ORACLE"
                                Select Case objBoolArr(inti)
                                    Case "AND"
                                        strFinalsql = strFinalsql & " AND Lib_tblItem.ID IN (" & strMysql & ")"
                                        ' strFinalsql = strFinalsql & " INTERSECT " & strMysql
                                    Case "OR"
                                        strUnionsql = strUnionsql & " UNION " & strMysql
                                    Case "NOT"
                                        strFinalsql = strFinalsql & " MINUS " & strMysql
                                End Select
                        End Select
                    End If
                End If
            Next
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    If intTop > 0 Then
                        strResult = "SELECT DISTINCT TOP " & intTop & " ID FROM Lib_tblItem WHERE 1 = 1  " & " " & strFinalsql & strUnionsql
                    Else
                        strResult = "SELECT DISTINCT ID FROM Lib_tblItem WHERE 1 = 1  " & strFinalsql & strUnionsql
                    End If
                Case "ORACLE"
                    If InStr(strFinalsql, " INTERSECT") = 1 Then
                        strFinalsql = Right(strFinalsql, Len(strFinalsql) - 10)
                    Else
                        If InStr(strFinalsql, " MINUS") = 1 Then
                            strFinalsql = Right(strFinalsql, Len(strFinalsql) - 6)
                        Else
                            strFinalsql = "SELECT DISTINCT ID FROM Lib_tblItem WHERE 1 = 1  " & "  " & strFinalsql
                        End If
                    End If
                    strResult = Replace(strFinalsql & strUnionsql, "ItemID", "ItemID AS ID")
                    If intTop > 0 Then
                        strResult = "SELECT * FROM (" & FormingASQL & ") WHERE ROWNUM<=" & intTop
                    End If
            End Select
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    strResult = "SELECT eMicLib6x.* FROM(" & strResult & ")eMicLib6x where (1=1)"
                Case "ORACLE"
                    strResult = "SELECT eMicLib6x.* FROM(" & strResult & ")eMicLib6x where (1=1)"
            End Select
            For inti = LBound(objFieldArr) To UBound(objFieldArr)
                If Not Trim(objValArr(inti)) = "" Then
                    Select Case objFieldArr(inti)
                        Case "ITEMFORMAT"
                            If objValArr(inti) = 1 Then 'Du lieu bien muc
                                strResult &= " AND eMicLib6x.ID IN (SELECT IT.ID FROM Lib_tblItem IT WHERE IT.FormatId = 0 and IT.libid = " & intLibID & " )"
                            Else 'Du lieu dien tu
                                strResult &= " AND eMicLib6x.ID IN (SELECT IT.ID FROM Lib_tblItem IT WHERE IT.FormatId > 0 and IT.libid = " & intLibID & " )"
                            End If
                    End Select
                End If
            Next
            Return strResult
        End Function

        Public Function ExecuteQuery(Optional ByVal intTop As Integer = 0) As String
            Dim tblTmp As New DataTable
            Dim strIDs As String = ""
            Dim inti As Integer
            objBCommonDBSystem.SQLStatement = Me.FormingASQL(intTop)
            tblTmp = objBCommonDBSystem.RetrieveItemInfor
            If tblTmp.Rows.Count > 0 Then
                For inti = 0 To tblTmp.Rows.Count - 1
                    strIDs = strIDs & tblTmp.Rows(inti).Item(0) & ","
                Next
                If Left(strIDs, 1) = "," Then
                    strIDs = Right(strIDs, Len(strIDs) - 1)
                End If
                If Right(strIDs, 1) = "," Then
                    strIDs = Left(strIDs, Len(strIDs) - 1)
                End If
            End If
            Return strIDs
        End Function

        ' Release resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                ' Release unmanaged resources.
                If Not objBCommonDBSystem Is Nothing Then
                    objBCommonDBSystem.Dispose(True)
                    objBCommonDBSystem = Nothing
                End If
                If Not objBCommonStringProc Is Nothing Then
                    objBCommonStringProc.Dispose(True)
                    objBCommonStringProc = Nothing
                End If
                If Not objBCatDicList Is Nothing Then
                    objBCatDicList.Dispose(True)
                    objBCatDicList = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace