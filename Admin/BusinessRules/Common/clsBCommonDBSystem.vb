Imports eMicLibAdmin.DataAccess
Imports eMicLibAdmin.DataAccess.Common
Imports System.Data

Namespace eMicLibAdmin.BusinessRules.Common
    Public Class clsBCommonDBSystem
        Inherits clsBBase

        Private objBString As New clsBCommonStringProc
        Private objDCommon As New clsDCommon
        Private objDSyscommon As New clsDSysCommon
        'Private TvSort As New TVCOMLib.utf8

        Private strSQLStatement As String
        Private strClassTab As String
        Private strExtension As String
        Private strCondition As String
        Private strFileName As String
        Private strCreatedDate As String
        Private blnIsConvertDate As Boolean = True
        Private strField245np As String

        ' *************************************************************************************************
        ' Declare public properties
        ' *************************************************************************************************
        ' ---- IsConvertDate Property
        Public Property IsConvertDate() As Boolean
            Get
                IsConvertDate = blnIsConvertDate
            End Get
            Set(ByVal Value As Boolean)
                blnIsConvertDate = Value
            End Set
        End Property

        ' ---- Extension Property
        Public Property Extension() As String
            Get
                Extension = strExtension
            End Get
            Set(ByVal Value As String)
                strExtension = Value
            End Set
        End Property

        ' ---- Condition Property
        Public Property Condition() As String
            Get
                Condition = strCondition
            End Get
            Set(ByVal Value As String)
                strCondition = Value
            End Set
        End Property

        ' ---- Condition Property
        Public Property FileName() As String
            Get
                FileName = strFileName
            End Get
            Set(ByVal Value As String)
                strFileName = Value
            End Set
        End Property

        ' ---- Condition Property
        Public Property CreatedDate() As String
            Get
                CreatedDate = strCreatedDate
            End Get
            Set(ByVal Value As String)
                strCreatedDate = Value
            End Set
        End Property

        Public Property Field245np() As String
            Get
                Field245np = strField245np
            End Get
            Set(value As String)
                strField245np = Field245np
            End Set
        End Property

        '========================================================
        ' Properties here
        '========================================================
        '-----------------------------------------
        ' This property use get/set type Interface Language
        '-----------------------------------------
        Public Overloads Property InterfaceLanguage() As String
            Get
                If Trim(strInterfaceLanguage) = "" Then
                    Dim TblSysPara As New DataTable
                    TblSysPara = objDcommon.Retrieve_SysParameters("INTERFACE_LANGUAGE")
                    If TblSysPara.Rows.Count > 0 Then
                        InterfaceLanguage = CStr(TblSysPara.Rows(0).Item("val"))
                    Else
                        InterfaceLanguage = "unicode"
                    End If
                    If objDcommon.ErrorMsg <> "" Then
                        strErrorMsg = objDcommon.ErrorMsg
                        intErrorCode = objDcommon.ErrorCode
                    End If
                Else
                    InterfaceLanguage = strInterfaceLanguage
                End If
            End Get
            Set(ByVal Value As String)
                strInterfaceLanguage = Value
            End Set
        End Property

        Public Function CheckOpenConnection(ByVal strDBServerCheck As String, ByVal strConnectionstringCheck As String) As Boolean
            Try
                CheckOpenConnection = objDCommon.CheckOpenConnection(strDBServerCheck, strConnectionstringCheck)
                strErrorMsg = objDCommon.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        '-----------------------------------------
        ' This property use get/set ..
        '-----------------------------------------
        Public Property ClassTab() As String
            Get
                Dim TblSysPara As New DataTable
                TblSysPara = objDCommon.Retrieve_SysParameters("Name='USED_CLASSIFICATION'")
                ClassTab = "DDC"
                If TblSysPara.Rows.Count > 0 Then
                    If TblSysPara.Rows(0).Item("Val") = "0" Then
                        ClassTab = "BBK"
                    End If
                Else
                End If
                If objDCommon.ErrorMsg <> "" Then
                    strErrorMsg = objDCommon.ErrorMsg
                    intErrorCode = objDCommon.ErrorCode
                End If
            End Get
            Set(ByVal Value As String)
                strClassTab = Value
            End Set
        End Property

        ' Statement SQL 
        Public Property SQLStatement() As String
            Get
                Return strSQLStatement
            End Get
            Set(ByVal Value As String)
                strSQLStatement = Value
            End Set
        End Property

        Public Sub Initialize()
            ' Code here
            objBString.DBServer = strDBServer
            objBString.InterfaceLanguage = strInterfaceLanguage
            objBString.ConnectionString = strconnectionstring
            Call objBString.Initialize()

            objDCommon.ConnectionString = strconnectionstring
            objDCommon.DBServer = strDBServer
            Call objDCommon.Initialize()

            objDSyscommon.ConnectionString = strconnectionstring
            objDSyscommon.DBServer = strdbserver
            Call objDSyscommon.Initialize()

            If objDCommon.ErrorMsg <> "" Then
                strErrorMsg = objDCommon.ErrorMsg
                intErrorCode = objDCommon.ErrorCode
            End If
        End Sub

        Public Function GetSystemParameters(ByVal strNames() As String) As Object
            Dim inti As Integer
            Dim strRet() As String
            Dim objDr As DataRow()
            Dim row As DataRow
            Dim TblTmp As DataTable
            Dim strFilter As String
            Try
                ReDim strRet(UBound(strNames))
                Dim strSQL As String
                If UBound(strNames) <> -1 Then
                    strSQL = " UPPER(Name)= UPPER('" & strNames(0) & "') "
                    For inti = 1 To UBound(strNames)
                        strSQL = strSQL & " OR UPPER(Name) = UPPER('" & strNames(inti) & "')"
                    Next
                End If
                TblTmp = objDCommon.Retrieve_SysParameters(strSQL)
                If objDCommon.ErrorMsg <> "" Then
                    strErrorMsg = objDCommon.ErrorMsg
                    intErrorCode = objDCommon.ErrorCode
                    Exit Function
                End If
                If Not (Not TblTmp Is Nothing AndAlso TblTmp.Rows.Count > 0) Then
                    Exit Function
                End If
                For inti = 0 To UBound(strNames)
                    strFilter = "Name='" & strNames(inti) & "'"
                    objDr = TblTmp.Select(strFilter)
                    If objDr.Length > 0 Then
                        row = objDr.GetValue(0)
                        If IsDBNull(row.Item(0)) Then
                            strRet(inti) = "Not Found"
                        Else
                            strRet(inti) = CStr(row.Item(0))
                        End If
                    Else
                        strRet(inti) = "Not Found"
                    End If
                    objDr = Nothing
                    row = Nothing
                Next inti
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            Finally
            End Try
            Return strRet
        End Function

        '------------------------------------------------------------------
        ' purpose : 
        '------------------------------------------------------------------
        Public Function CheckPermission(ByVal strAlias() As String, ByVal lngUserID As Long) As Collection
            Dim inti As Integer
            Dim objDr As DataRow()
            Dim row As DataRow
            Dim TblTmp As DataTable
            Dim strFilter As String
            Dim colRet As New Collection
            Try
                ' TblTmp = objDCommon.CheckPermission(strAlias, lngUserID)
                If objDCommon.ErrorMsg <> "" Then
                    strErrorMsg = objDCommon.ErrorMsg
                    intErrorCode = objDCommon.ErrorCode
                    Exit Function
                End If
                For inti = 0 To UBound(strAlias)
                    strFilter = "Alias='" & strAlias(inti) & "'"
                    objDr = TblTmp.Select(strFilter)
                    If objDr.Length > 0 Then
                        row = objDr.GetValue(0)
                        If IsDBNull(row.Item(0)) Then
                            ' NULL value
                            colRet.Add(0, strAlias(inti))
                        Else
                            ' have value
                            colRet.Add(1, strAlias(inti))
                        End If
                    Else
                        ' not found
                        colRet.Add(0, strAlias(inti))
                    End If
                    objDr = Nothing
                    row = Nothing
                Next inti
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
            Return colRet
        End Function

        ' Write Log method
        Public Sub WriteLog(ByVal lngGroupID As Long, ByVal strMsg As String, ByVal strFilename As String, ByVal strRemoteHost As String, ByVal strUser_name As String)
            objDCommon.WriteLog(lngGroupID, objBString.ConvertItBack(strMsg), objBString.ConvertItBack(strFilename), strRemoteHost, objBString.ConvertItBack(strUser_name))
            If objDCommon.ErrorMsg <> "" Then
                strErrorMsg = objDCommon.ErrorMsg
                intErrorCode = objDCommon.ErrorCode
            End If
        End Sub

        Public Function GetUserRightModule(ByVal strUS As String, ByVal strPW As String) As Collection
            Dim collRet As New Collection
            Dim TblUser As New DataTable

            TblUser = objDCommon.Retrieve_OneUser(objBString.ConvertItBack(strUS), objBString.EncryptedPassword(strPW))
            If TblUser.Rows.Count > 0 Then
                collRet.Add(CInt(TblUser.Rows(0).Item(0)), "ID")
                collRet.Add(CStr(TblUser.Rows(0).Item(1)), "UserName")
                collRet.Add(CInt(TblUser.Rows(0).Item(2)), "PatModule")
                collRet.Add(CInt(TblUser.Rows(0).Item(3)), "CirModule")
                collRet.Add(CInt(TblUser.Rows(0).Item(4)), "AcqModule")
                collRet.Add(CInt(TblUser.Rows(0).Item(5)), "SerModule")
                collRet.Add(CInt(TblUser.Rows(0).Item(6)), "ILLModule")
                collRet.Add(CInt(TblUser.Rows(0).Item(7)), "CatModule")
                collRet.Add(CInt(TblUser.Rows(0).Item(8)), "AdmModule")
                collRet.Add(CInt(TblUser.Rows(0).Item(9)), "DelModule")
                collRet.Add(CInt(TblUser.Rows(0).Item(10)), "LocModule")
                collRet.Add(CStr(TblUser.Rows(0).Item(11)), "Password")
            Else
                collRet.Add(0, "ID")
                collRet.Add("", "UserName")
                collRet.Add(0, "PatModule")
                collRet.Add(0, "CirModule")
                collRet.Add(0, "AcqModule")
                collRet.Add(0, "SerModule")
                collRet.Add(0, "ILLModule")
                collRet.Add(0, "CatModule")
                collRet.Add(0, "AdmModule")
                collRet.Add(0, "DelModule")
                collRet.Add(0, "LocModule")
            End If
            'TblUser.Dispose()
            TblUser = Nothing
            GetUserRightModule = collRet
        End Function

        Public Function ConvertTable(ByVal scrTable As DataTable, Optional ByVal blnShowTime As Boolean = False, Optional ByVal blnConvertNull As Boolean = False) As DataTable
            Dim strColNameTmp As String
            Dim inti As Integer
            Dim intcoli As Integer
            Dim strColDel As String
            Dim strTemp As String
            Dim strValDate As String

            strColNameTmp = ""
            If scrTable.Rows.Count > 0 Then
                strColDel = ""
                For intcoli = 0 To scrTable.Columns.Count - 1
                    ' chi convert date khi property IsConvertDate=true(default)
                    If blnIsConvertDate Then
                        ' Check DateTime
                        If System.Type.GetType("System.DateTime").Equals(scrTable.Columns(intcoli).DataType) Then
                            strColNameTmp = ""
                            strColNameTmp = scrTable.Columns(intcoli).ColumnName
                            strColDel = strColDel & strColNameTmp & ","
                            scrTable.Columns.Add(strColNameTmp & "_Tmp", Type.GetType("System.String"))
                            For inti = 0 To scrTable.Rows.Count - 1
                                strValDate = ""
                                If Not IsDBNull(scrTable.Rows(inti).Item(strColNameTmp)) Then
                                    strValDate = ConvertDate(scrTable.Rows(inti).Item(strColNameTmp), blnShowTime)
                                End If
                                ' convert DateTime
                                scrTable.Rows(inti).Item(strColNameTmp & "_Tmp") = strValDate
                            Next
                        End If
                    End If
                    Select Case UCase(strDBServer)
                        Case "SQLSERVER"
                            If Not UCase(strInterfaceLanguage) = "UNICODE" Then
                                ' chi convert TCVN,VNI,VIQR Encode
                                ' Check String 
                                If System.Type.GetType("System.String").Equals(scrTable.Columns(intcoli).DataType) Then
                                    For inti = 0 To scrTable.Rows.Count - 1
                                        If Not IsDBNull(scrTable.Rows(inti).Item(intcoli)) Then
                                            ' Convert String
                                            scrTable.Rows(inti).Item(intcoli) = objBString.ConvertIt(scrTable.Rows(inti).Item(intcoli))
                                        End If
                                    Next
                                End If
                            End If
                            If blnConvertNull Then
                                If System.Type.GetType("System.String").Equals(scrTable.Columns(intcoli).DataType) Then
                                    For inti = 0 To scrTable.Rows.Count - 1
                                        If IsDBNull(scrTable.Rows(inti).Item(intcoli)) Then
                                            scrTable.Rows(inti).Item(intcoli) = ""
                                        End If
                                    Next
                                End If
                            End If
                        Case "ORACLE"
                            ' Check String 
                            If System.Type.GetType("System.String").Equals(scrTable.Columns(intcoli).DataType) Then
                                For inti = 0 To scrTable.Rows.Count - 1
                                    If Not IsDBNull(scrTable.Rows(inti).Item(intcoli)) Then
                                        ' Convert String
                                        scrTable.Rows(inti).Item(intcoli) = objBString.ConvertIt(scrTable.Rows(inti).Item(intcoli))
                                    Else
                                        If blnConvertNull Then
                                            scrTable.Rows(inti).Item(intcoli) = ""
                                        End If
                                    End If
                                Next
                            End If
                    End Select
                Next
                Dim arrColDel
                If strColDel <> "" Then
                    strColDel = Left(strColDel, Len(strColDel) - 1)
                    arrColDel = Split(strColDel, ",")
                    ' Change name Column temp
                    For inti = LBound(arrColDel) To UBound(arrColDel)
                        scrTable.Columns(arrColDel(inti)).ColumnName = UCase(arrColDel(inti)) & "_"
                        scrTable.Columns(arrColDel(inti) & "_Tmp").ColumnName = UCase(arrColDel(inti))
                    Next
                End If
            End If
            Return scrTable
        End Function

        Public Function ConvertTableKillChar(ByVal scrTable As DataTable, ByVal chrCharOld As Char, Optional ByVal chrCharNew As Char = "") As DataTable
            Dim intcoli As Integer
            Dim inti As Integer
            If Not scrTable Is Nothing Then
                If scrTable.Rows.Count > 0 Then
                    For intcoli = 0 To scrTable.Columns.Count - 1
                        For inti = 0 To scrTable.Rows.Count - 1
                            If System.Type.GetType("System.String").Equals(scrTable.Columns(intcoli).DataType) Then
                                scrTable.Rows(inti).Item(intcoli) = scrTable.Rows(inti).Item(intcoli).ToString().Replace(chrCharOld, chrCharNew)
                            End If
                        Next
                    Next
                End If
            End If
            Return scrTable
        End Function

        Public Function GetContent(ByVal strInput As String, ByVal chrSplit As Char, ByVal chrKeyCode As Char) As String
            Dim strResult As String = ""
            Dim strReplace As String = String.Format("{0}{1}", chrSplit, chrKeyCode)
            If strInput.Contains(strReplace) Then
                Dim split() As String = strInput.Split(New Char() {chrSplit})
                For Each iSplit As String In split
                    If Not String.IsNullOrEmpty(iSplit) AndAlso iSplit(0) = chrKeyCode.ToString() Then
                        strResult = iSplit.Substring(1, iSplit.Length - 1).Trim()
                        Exit For
                    End If
                Next
            End If
            Return strResult
        End Function

        Public Function GetContent(ByVal strInput As String, ByVal chrSplit As Char) As String
            Dim strResult As String = ""
            Dim split() As String = strInput.Split(New Char() {chrSplit})
            For Each iSplit As String In split
                If Not String.IsNullOrEmpty(iSplit) Then
                    strResult = strResult & iSplit.Substring(1, iSplit.Length - 1).Trim()
                End If
            Next
            Return strResult
        End Function

        Public Function ConvertTable(ByVal scrTable As DataTable, ByVal FieldNameTrimsub As String, Optional ByVal blnShowTime As Boolean = False) As DataTable
            Dim strColNameTmp As String
            Dim inti As Integer
            Dim intcoli As Integer
            Dim strColDel As String
            Dim strTemp As String
            Dim arrS() As String
            Dim strValDate As String

            strColNameTmp = ""
            If FieldNameTrimsub <> "" Then
                arrS = Split(UCase(FieldNameTrimsub), ",")
            End If
            Try
                If Not scrTable Is Nothing Then
                If scrTable.Rows.Count > 0 Then
                    strColDel = ""
                    For intcoli = 0 To scrTable.Columns.Count - 1
                        ' chi convert date khi property IsConvertDate=true(default)
                        If blnIsConvertDate Then
                            ' Check DateTime
                            If System.Type.GetType("System.DateTime").Equals(scrTable.Columns(intcoli).DataType) Then
                                strColNameTmp = ""
                                strColNameTmp = scrTable.Columns(intcoli).ColumnName
                                strColDel = strColDel & strColNameTmp & ","
                                scrTable.Columns.Add(strColNameTmp & "_Tmp", Type.GetType("System.String"))
                                For inti = 0 To scrTable.Rows.Count - 1
                                    strValDate = ""
                                    If Not IsDBNull(scrTable.Rows(inti).Item(strColNameTmp)) Then
                                        strValDate = ConvertDate(scrTable.Rows(inti).Item(strColNameTmp), blnShowTime)
                                    End If
                                    ' convert DateTime
                                    scrTable.Rows(inti).Item(strColNameTmp & "_Tmp") = strValDate
                                Next
                            End If
                        End If
                        Select Case UCase(strDBServer)
                            Case "SQLSERVER"
                                Select Case UCase(strInterfaceLanguage)
                                    Case "UNICODE"
                                        ' UNICODE khong can phai convert
                                        ' Chi can TrimSubFieldCode
                                        If arrS.IndexOf(arrS, UCase(scrTable.Columns(intcoli).ColumnName)) > -1 Then
                                            For inti = 0 To scrTable.Rows.Count - 1
                                                If Not IsDBNull(scrTable.Rows(inti).Item(intcoli)) Then
                                                    scrTable.Rows(inti).Item(intcoli) = objBString.TrimSubFieldCodes(scrTable.Rows(inti).Item(intcoli))
                                                End If
                                            Next
                                        End If
                                    Case Else ' TCVN,VNI,VIQR Encode
                                        ' Check String 
                                        If System.Type.GetType("System.String").Equals(scrTable.Columns(intcoli).DataType) Then
                                            If arrS.IndexOf(arrS, UCase(scrTable.Columns(intcoli).ColumnName)) > -1 Then
                                                For inti = 0 To scrTable.Rows.Count - 1
                                                    If Not IsDBNull(scrTable.Rows(inti).Item(intcoli)) Then
                                                        ' Convert String
                                                        scrTable.Rows(inti).Item(intcoli) = objBString.ConvertIt(objBString.TrimSubFieldCodes(scrTable.Rows(inti).Item(intcoli)))
                                                    End If
                                                Next
                                            Else
                                                For inti = 0 To scrTable.Rows.Count - 1
                                                    If Not IsDBNull(scrTable.Rows(inti).Item(intcoli)) Then
                                                        ' Convert String
                                                        scrTable.Rows(inti).Item(intcoli) = objBString.ConvertIt(scrTable.Rows(inti).Item(intcoli))
                                                    End If
                                                Next
                                            End If
                                        End If
                                End Select
                            Case "ORACLE"
                                ' Check String
                                If System.Type.GetType("System.String").Equals(scrTable.Columns(intcoli).DataType) Then
                                    If arrS.IndexOf(arrS, UCase(scrTable.Columns(intcoli).ColumnName)) > -1 Then
                                        ' dung TrimSubFieldCodes
                                        For inti = 0 To scrTable.Rows.Count - 1
                                            If Not IsDBNull(scrTable.Rows(inti).Item(intcoli)) Then
                                                ' Convert String
                                                scrTable.Rows(inti).Item(intcoli) = objBString.TrimSubFieldCodes(scrTable.Rows(inti).Item(intcoli))
                                            End If
                                        Next
                                    Else
                                        For inti = 0 To scrTable.Rows.Count - 1
                                            If Not IsDBNull(scrTable.Rows(inti).Item(intcoli)) Then
                                                ' Convert String
                                                scrTable.Rows(inti).Item(intcoli) = objBString.ConvertIt(scrTable.Rows(inti).Item(intcoli))
                                            End If
                                        Next
                                    End If
                                End If
                        End Select
                    Next
                    Dim arrColDel()
                    If strColDel <> "" Then
                        strColDel = Left(strColDel, Len(strColDel) - 1)
                        arrColDel = Split(strColDel, ",")
                        ' Change name Column temp
                        For inti = LBound(arrColDel) To UBound(arrColDel) -1
                            scrTable.Columns(arrColDel(inti)).ColumnName = UCase(arrColDel(inti)) & "_"
                            scrTable.Columns(arrColDel(inti) & "_Tmp").ColumnName = UCase(arrColDel(inti))
                        Next
                    End If
                End If
            End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            
            Return scrTable
        End Function

        Public Function ConvertTableAuthorDDC(ByVal scrTable As DataTable, ByVal FieldNameTrimsub As String, Optional ByVal blnShowTime As Boolean = False) As DataTable
            Dim strColNameTmp As String
            Dim inti As Integer
            Dim intcoli As Integer
            Dim strColDel As String
            Dim strTemp As String
            Dim arrS() As String
            Dim strValDate As String

            strColNameTmp = ""
            If FieldNameTrimsub <> "" Then
                arrS = Split(UCase(FieldNameTrimsub), ",")
            End If
            If Not scrTable Is Nothing Then
                If scrTable.Rows.Count > 0 Then
                    strColDel = ""
                    For intcoli = 0 To scrTable.Columns.Count - 1
                        ' chi convert date khi property IsConvertDate=true(default)
                        If blnIsConvertDate Then
                            ' Check DateTime
                            If System.Type.GetType("System.DateTime").Equals(scrTable.Columns(intcoli).DataType) Then
                                strColNameTmp = ""
                                strColNameTmp = scrTable.Columns(intcoli).ColumnName
                                strColDel = strColDel & strColNameTmp & ","
                                scrTable.Columns.Add(strColNameTmp & "_Tmp", Type.GetType("System.String"))
                                For inti = 0 To scrTable.Rows.Count - 1
                                    strValDate = ""
                                    If Not IsDBNull(scrTable.Rows(inti).Item(strColNameTmp)) Then
                                        strValDate = ConvertDate(scrTable.Rows(inti).Item(strColNameTmp), blnShowTime)
                                    End If
                                    ' convert DateTime
                                    scrTable.Rows(inti).Item(strColNameTmp & "_Tmp") = strValDate
                                Next
                            End If
                        End If
                        Select Case UCase(strDBServer)
                            Case "SQLSERVER"
                                Select Case UCase(strInterfaceLanguage)
                                    Case "UNICODE"
                                        ' UNICODE khong can phai convert
                                        ' Chi can TrimSubFieldCode
                                        If arrS.IndexOf(arrS, UCase(scrTable.Columns(intcoli).ColumnName)) > -1 Then
                                            For inti = 0 To scrTable.Rows.Count - 1
                                                If Not IsDBNull(scrTable.Rows(inti).Item(intcoli)) Then
                                                    scrTable.Rows(inti).Item(intcoli) = objBString.TrimSubFieldCodes(scrTable.Rows(inti).Item(intcoli))
                                                End If
                                            Next
                                        End If
                                    Case Else ' TCVN,VNI,VIQR Encode
                                        ' Check String 
                                        If System.Type.GetType("System.String").Equals(scrTable.Columns(intcoli).DataType) Then
                                            If arrS.IndexOf(arrS, UCase(scrTable.Columns(intcoli).ColumnName)) > -1 Then
                                                For inti = 0 To scrTable.Rows.Count - 1
                                                    If Not IsDBNull(scrTable.Rows(inti).Item(intcoli)) Then
                                                        'Dim Field245np As String = ""
                                                        ' Convert String
                                                        If (scrTable.Rows(inti).Item("FieldCode").ToString() = "100") Then
                                                            Dim contentTemp As String = scrTable.Rows(inti).Item("Content").ToString()
                                                            If (contentTemp.Contains("$a")) Then
                                                                Dim splitContent() As String = contentTemp.Split("$")
                                                                For Each stringTemp As String In splitContent
                                                                    If (stringTemp.Length > 0 AndAlso stringTemp(0) = "a") Then
                                                                        scrTable.Rows(inti).Item(intcoli) = stringTemp.Replace(" ,", "").Substring(1).Trim()
                                                                        Exit For
                                                                    End If
                                                                Next
                                                                'Else
                                                                '    scrTable.Rows(inti).Item(intcoli) = objBString.ConvertIt(objBString.TrimSubFieldCodes(scrTable.Rows(inti).Item(intcoli)))
                                                            End If
                                                        Else
                                                            If (scrTable.Rows(inti).Item("FieldCode").ToString() = "245") Then
                                                                Dim contentTemp As String = scrTable.Rows(inti).Item("Content").ToString()
                                                                If (contentTemp.Contains("$n") Or (contentTemp.Contains("$p"))) Then
                                                                    Dim tempField245np As String = ""
                                                                    Dim tempField245n As String = ""
                                                                    Dim tempField245p As String = ""
                                                                    Dim splitContent() As String = contentTemp.Split("$")
                                                                    For Each tempContent As String In splitContent
                                                                        If (tempContent.Length > 0 AndAlso (tempContent(0) = "n" Or tempContent(0) = "p")) Then
                                                                            If (tempContent(0) = "n") Then
                                                                                Try
                                                                                    tempField245np = tempField245np & tempContent.Substring(1).Replace(" /", "").Replace(" ,", "") & ": "
                                                                                    tempField245n = "$n" & tempContent.Substring(1)
                                                                                Catch ex As Exception

                                                                                End Try
                                                                            Else
                                                                                Try
                                                                                    tempField245np = tempField245np & tempContent.Substring(1).Replace(" /", "")
                                                                                    tempField245p = "$p" & tempContent.Substring(1)
                                                                                Catch ex As Exception

                                                                                End Try
                                                                            End If
                                                                        End If
                                                                    Next

                                                                    'If (contentTemp.Contains("$n")) Then
                                                                    '    Dim splitContent() As String = contentTemp.Split("$n")
                                                                    '    If (splitContent.Length > 1) Then
                                                                    '        Dim temp() As String = splitContent(1).Split("$")
                                                                    '        Field245np = Field245np & temp(0) & ":"
                                                                    '        tempField245n = "$n" & Field245np
                                                                    '    End If
                                                                    'End If
                                                                    'If (contentTemp.Contains("$p")) Then
                                                                    '    Dim splitContent() As String = contentTemp.Split("$p")
                                                                    '    If (splitContent.Length > 1) Then
                                                                    '        Dim temp() As String = splitContent(1).Split("$")
                                                                    '        Field245np = Field245np & temp(0)
                                                                    '        tempField245n = "$p" & Field245np
                                                                    '    End If
                                                                    'End If
                                                                    If (tempField245p <> "") Then
                                                                        scrTable.Rows(inti).Item(intcoli) = scrTable.Rows(inti).Item(intcoli).ToString().Replace(tempField245p, "")
                                                                    End If

                                                                    If (tempField245n <> "") Then
                                                                        If contentTemp.Contains("$c") Then
                                                                            scrTable.Rows(inti).Item(intcoli) = scrTable.Rows(inti).Item(intcoli).ToString().Replace(tempField245n, " /")
                                                                        Else
                                                                            scrTable.Rows(inti).Item(intcoli) = scrTable.Rows(inti).Item(intcoli).ToString().Replace(tempField245n, "")
                                                                        End If
                                                                    End If

                                                                    scrTable.Rows(inti).Item(intcoli) = scrTable.Rows(inti).Item(intcoli).ToString().Replace(" .", "")
                                                                    scrTable.Rows(inti).Item(intcoli) = objBString.ConvertIt(objBString.TrimSubFieldCodes(scrTable.Rows(inti).Item(intcoli).ToString())) & "^" & tempField245np

                                                                Else
                                                                    scrTable.Rows(inti).Item(intcoli) = scrTable.Rows(inti).Item(intcoli).ToString().Replace(" .", "")
                                                                    scrTable.Rows(inti).Item(intcoli) = objBString.ConvertIt(objBString.TrimSubFieldCodes(scrTable.Rows(inti).Item(intcoli)))
                                                                End If
                                                            Else
                                                                scrTable.Rows(inti).Item(intcoli) = scrTable.Rows(inti).Item(intcoli).ToString().Replace(" .", "")
                                                                scrTable.Rows(inti).Item(intcoli) = objBString.ConvertIt(objBString.TrimSubFieldCodes(scrTable.Rows(inti).Item(intcoli)))
                                                            End If
                                                        End If
                                                    End If

                                                Next
                                            Else
                                                For inti = 0 To scrTable.Rows.Count - 1
                                                    If Not IsDBNull(scrTable.Rows(inti).Item(intcoli)) Then
                                                        ' Convert String
                                                        scrTable.Rows(inti).Item(intcoli) = objBString.ConvertIt(scrTable.Rows(inti).Item(intcoli))
                                                    End If
                                                Next
                                            End If
                                        End If
                                End Select
                            Case "ORACLE"
                                ' Check String
                                If System.Type.GetType("System.String").Equals(scrTable.Columns(intcoli).DataType) Then
                                    If arrS.IndexOf(arrS, UCase(scrTable.Columns(intcoli).ColumnName)) > -1 Then
                                        ' dung TrimSubFieldCodes
                                        For inti = 0 To scrTable.Rows.Count - 1
                                            If Not IsDBNull(scrTable.Rows(inti).Item(intcoli)) Then
                                                ' Convert String
                                                scrTable.Rows(inti).Item(intcoli) = objBString.TrimSubFieldCodes(scrTable.Rows(inti).Item(intcoli))
                                            End If
                                        Next
                                    Else
                                        For inti = 0 To scrTable.Rows.Count - 1
                                            If Not IsDBNull(scrTable.Rows(inti).Item(intcoli)) Then
                                                ' Convert String
                                                scrTable.Rows(inti).Item(intcoli) = objBString.ConvertIt(scrTable.Rows(inti).Item(intcoli))
                                            End If
                                        Next
                                    End If
                                End If
                        End Select
                    Next
                    Dim arrColDel()
                    If strColDel <> "" Then
                        strColDel = Left(strColDel, Len(strColDel) - 1)
                        arrColDel = Split(strColDel, ",")
                        ' Change name Column temp
                        For inti = LBound(arrColDel) To UBound(arrColDel)
                            scrTable.Columns(arrColDel(inti)).ColumnName = UCase(arrColDel(inti)) & "_"
                            scrTable.Columns(arrColDel(inti) & "_Tmp").ColumnName = UCase(arrColDel(inti))
                        Next
                    End If
                End If
            End If
            Return scrTable
        End Function

        Public Function InsertOneRow(ByVal scrTable As DataTable, ByVal objInsert As Object, Optional ByVal blnInsertAtEnd As Boolean = False) As DataTable
            Dim tblTemp As New DataTable
            Dim objrow As DataRow
            Dim byti As Integer
            If Not (scrTable Is Nothing) Then
                tblTemp = scrTable.Copy
                objrow = tblTemp.NewRow
                If tblTemp.Rows.Count > 0 Then
                    For byti = 0 To tblTemp.Columns.Count - 1
                        If IsNumeric(tblTemp.Rows(0).Item(byti)) And Not tblTemp.Columns(byti).DataType.FullName.ToLower = "system.string" Then
                            objrow.Item(byti) = 0
                        ElseIf IsDate(tblTemp.Rows(0).Item(byti)) Then
                            objrow.Item(byti) = Now
                        ElseIf IsDBNull(objInsert) Or (objInsert = "") Then
                            strErrorMsg = "Object is Null"
                            Exit Function
                        Else
                            Try
                                objrow.Item(byti) = objInsert
                            Catch ex As Exception

                            End Try
                        End If
                    Next
                Else
                    For byti = 0 To tblTemp.Columns.Count - 1
                        If System.Type.GetType("System.Decimal").Equals(tblTemp.Columns(byti).DataType) Then
                            objrow.Item(byti) = 0
                        ElseIf System.Type.GetType("System.DateTime").Equals(tblTemp.Columns(byti).DataType) Then
                            objrow.Item(byti) = Now
                        ElseIf System.Type.GetType("System.Int32").Equals(tblTemp.Columns(byti).DataType) Then
                            objrow.Item(byti) = 0
                        Else
                            If IsDBNull(objInsert) Or (objInsert = "") Then
                                strErrorMsg = "Object is Null"
                                Exit Function
                            Else
                                objrow.Item(byti) = objInsert
                            End If
                        End If
                    Next
                End If

                If blnInsertAtEnd = True Then
                    tblTemp.Rows.InsertAt(objrow, tblTemp.Rows.Count)
                Else
                    tblTemp.Rows.InsertAt(objrow, 0)
                End If

            Else
                strErrorMsg = "scrTable is not table !"
            End If
            Return tblTemp
        End Function

        Public Function CreateTable(ByVal ArrTextField As Object, ByVal ArrValueField As Object) As DataTable
            Dim TblRet As New DataTable
            If IsArray(ArrTextField) And IsArray(ArrValueField) Then
                If UBound(ArrTextField) = UBound(ArrValueField) Then
                    Dim byti As Byte
                    Dim row As DataRow
                    If System.Type.GetType("System.String").Equals(ArrTextField(0).GetType) Then
                        TblRet.Columns.Add("TextField", System.Type.GetType("System.String"))
                    ElseIf System.Type.GetType("System.Int64").Equals(ArrTextField(0).GetType) Then
                        TblRet.Columns.Add("TextField", System.Type.GetType("System.Int64"))
                    ElseIf System.Type.GetType("System.Int32").Equals(ArrTextField(0).GetType) Then
                        TblRet.Columns.Add("TextField", System.Type.GetType("System.Int32"))
                    ElseIf System.Type.GetType("System.DateTime").Equals(ArrTextField(0).GetType) Then
                        TblRet.Columns.Add("TextField", System.Type.GetType("System.DateTime"))
                    ElseIf System.Type.GetType("System.Decimal").Equals(ArrTextField(0).GetType) Then
                        TblRet.Columns.Add("TextField", System.Type.GetType("System.Decimal"))
                    End If

                    If System.Type.GetType("System.String").Equals(ArrTextField(0).GetType) Then
                        TblRet.Columns.Add("ValueField", System.Type.GetType("System.String"))
                    ElseIf System.Type.GetType("System.Int64").Equals(ArrTextField(0).GetType) Then
                        TblRet.Columns.Add("ValueField", System.Type.GetType("System.Int64"))
                    ElseIf System.Type.GetType("System.Int32").Equals(ArrTextField(0).GetType) Then
                        TblRet.Columns.Add("ValueField", System.Type.GetType("System.Int32"))
                    ElseIf System.Type.GetType("System.DateTime").Equals(ArrTextField(0).GetType) Then
                        TblRet.Columns.Add("ValueField", System.Type.GetType("System.DateTime"))
                    ElseIf System.Type.GetType("System.Decimal").Equals(ArrTextField(0).GetType) Then
                        TblRet.Columns.Add("ValueField", System.Type.GetType("System.Decimal"))
                    End If
                    For byti = 0 To UBound(ArrTextField)
                        If ArrTextField(byti) <> "" Then
                            row = TblRet.NewRow
                            row(0) = ArrTextField(byti)
                            row(1) = ArrValueField(byti)
                            TblRet.Rows.Add(row)
                        End If

                    Next
                    CreateTable = TblRet
                Else
                    strErrorMsg = "Length of two Parameters not equal"
                    Exit Function
                End If
            Else
                strErrorMsg = "Parameter not an Array"
                Exit Function
            End If
        End Function

        Public Function SortByIndex(ByVal ArrID As Object, ByVal ArrIndex As Object) As Object
            Dim inti As Integer
            Dim ArrRet()
            If IsArray(ArrID) And IsArray(ArrIndex) Then
                If UBound(ArrID) = UBound(ArrIndex) Then
                    ReDim ArrRet(UBound(ArrIndex))
                    For inti = 0 To UBound(ArrIndex)
                        ArrRet(inti) = ArrID(ArrIndex(inti))
                    Next
                Else
                    ReDim ArrRet(0)
                    ArrRet(0) = "Length of Parameter not equal"
                End If
            Else
                ReDim ArrRet(0)
                ArrRet(0) = "Parameter not an array"
            End If
            SortByIndex = ArrRet
        End Function

        Public Function GenTableSort(ByVal ArrID As Object, ByVal TblSource As DataTable) As DataTable
            Dim TblRet As New DataTable("tbl_tmp")
            Dim row As DataRow
            Dim rowi() As DataRow
            If IsArray(ArrID) And (Not TblSource Is Nothing AndAlso TblSource.Rows.Count > 0) Then
                If UBound(ArrID) = TblSource.Rows.Count - 1 Then
                    TblRet = TblSource.Clone
                    Dim intj As Integer
                    Dim inti As Integer
                    For inti = 0 To UBound(ArrID)
                        rowi = TblSource.Select("ID=" & CStr(ArrID(inti)))
                        If rowi.GetUpperBound(0) > -1 Then
                            row = TblRet.NewRow
                            For intj = 0 To TblSource.Columns.Count - 1
                                row.Item(intj) = rowi(0).Item(intj)
                            Next
                        End If
                        TblRet.Rows.Add(row)
                    Next
                Else
                    strErrorMsg = "Count not Equal"
                End If
            Else
                strErrorMsg = "Count not Equal"
            End If
            GenTableSort = TblRet
        End Function

        Public Function SortTable(ByVal srcTable As DataTable, ByVal strColSort As String, Optional ByVal intASC As Integer = 1) As DataTable
            Dim TblRet As New DataTable("tbl_tmp")
            Dim inti As Integer
            Dim blnHaveCol As Boolean
            Dim strConv As String
            Dim row As DataRow

            strColSort = UCase(strColSort)
            ' check collumn to sort
            If srcTable.Columns.IndexOf(strColSort) <> -1 Then
                blnHaveCol = True
            Else
                strErrorMsg = "Column " & strColSort & " Not found !"
                SortTable = srcTable
                Exit Function
            End If
            If srcTable.Rows.Count > 0 Then
                ' kiem tra du lieu la text moi dung Tvsort
                If System.Type.GetType("System.String").Equals(srcTable.Columns(strColSort).DataType) Then
                    If srcTable.Columns.IndexOf(strColSort & "_") > -1 Then
                        ' la truong datetime
                        TblRet = srcTable
                    Else
                        ' khong phai la truong datetime
                        Dim ArrIndex()
                        Dim ArrText()
                        ReDim ArrText(srcTable.Rows.Count - 1)
                        TblRet = srcTable.Clone
                        ' export Table to Array
                        For inti = 0 To srcTable.Rows.Count - 1
                            ArrText(inti) = srcTable.Rows(inti).Item(strColSort) & ""
                            ArrText(inti) = Trim(objBString.ToUTF8(ArrText(inti)))
                        Next
                        ' Use tvcom to sort utf8 encode
                        'ArrIndex = TvSort.SortIndex(ArrText, 1)
                        ArrIndex = objBString.SortIndexDictionary(ArrText, 1)
                        ' Create new table have been sort
                        If intASC = 1 Then
                            For inti = 0 To srcTable.Rows.Count - 1
                                row = TblRet.NewRow
                                row = srcTable.Rows(ArrIndex(inti))
                                row.Item(strColSort) = Replace(Replace(row.Item(strColSort), "<", "&lt;"), ">", "&gt;")
                                TblRet.ImportRow(row)
                            Next
                        Else
                            For inti = srcTable.Rows.Count - 1 To 0 Step -1
                                row = TblRet.NewRow
                                row = srcTable.Rows(ArrIndex(inti))
                                row.Item(strColSort) = Replace(Replace(row.Item(strColSort), "<", "&lt;"), ">", "&gt;")
                                TblRet.ImportRow(row)
                            Next
                        End If
                    End If
                Else
                    TblRet = srcTable
                End If
            Else
                TblRet = srcTable
            End If
            SortTable = TblRet
        End Function

        ' Retrieve data
        ' Input: string of select statement
        ' Output: DataTable
        ' STOREPROCEDURE
        Public Function RetrieveItemInfor(Optional ByVal strFieldTrim As String = "", Optional ByVal blnConvertNull As Boolean = False, Optional itemInfo As Integer = 0) As DataTable
            Try
                objDCommon.SQLStatement = strSQLStatement
                objDCommon.LibID = intLibID
                If strFieldTrim <> "" Then
                    RetrieveItemInfor = Me.ConvertTable(objDCommon.RetrieveItemInfor, strFieldTrim)
                Else
                    RetrieveItemInfor = Me.ConvertTable(objDCommon.RetrieveItemInfor, False, blnConvertNull)
                End If
                strErrorMsg = objDCommon.ErrorMsg
                intErrorCode = objDCommon.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            Finally
            End Try
        End Function

        Public Sub RetrieveNonQuery()
            Try
                objDCommon.SQLStatement = strSQLStatement
                objDCommon.LibID = intLibID
                objDCommon.RetrieveNonQuery()
                strErrorMsg = objDCommon.ErrorMsg
                intErrorCode = objDCommon.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            Finally
            End Try
        End Sub
        Public Function RetrieveCopyNumberIds() As DataTable
            Try
                objDCommon.SQLStatement = strSQLStatement
                objDCommon.LibID = intLibID
                RetrieveCopyNumberIds = objDCommon.RetrieveItemInfor
                strErrorMsg = objDCommon.ErrorMsg
                intErrorCode = objDCommon.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
                RetrieveCopyNumberIds = New DataTable()
                RetrieveCopyNumberIds.Columns.Add(New DataColumn("ID"))
            End Try
        End Function

        Public Function RetrieveItemInfor(ByVal blnConvert As Boolean) As DataTable
            Try
                objDCommon.SQLStatement = strSQLStatement
                If blnConvert Then
                    RetrieveItemInfor = Me.ConvertTable(objDCommon.RetrieveItemInfor)
                Else
                    RetrieveItemInfor = objDCommon.RetrieveItemInfor
                End If
                strErrorMsg = objDCommon.ErrorMsg
                intErrorCode = objDCommon.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Insert (Update)
        ' Input: string of SQL statement
        ' STOREPROCEDURE
        Public Sub ProcessItem()
            Try
                objDCommon.SQLStatement = strSQLStatement
                objDCommon.ProcessItem()
            Catch ex As Exception
                strErrorMsg = objDCommon.ErrorMsg
                intErrorCode = objDCommon.ErrorCode
            End Try
        End Sub

        '=========================================================
        ' Process Date Time Here
        '=========================================================
        Public Function ConvertDate(ByVal dtmDateTime As DateTime, Optional ByVal blnShowTime As Boolean = False) As String
            Dim strRet As String
            Dim strTime As String
            Dim strDate As String
            Dim strPara(1) As String
            Dim strARet(1) As String
            Dim strTypeShow As String
            Dim strArr(2) As String
            strPara(0) = "DATE_FORMAT"
            strARet = GetSystemParameters(strPara)
            If strARet(0) <> "" Then
                strTypeShow = strARet(0)
            Else
                strTypeShow = "DD/MM/YYYY"
            End If
            Select Case UCase(strTypeShow)
                Case "DD/MM/YYYY"
                    strRet = StrDup(2 - Len(CStr(Day(dtmDateTime))), "0") & Day(dtmDateTime) & "/" & StrDup(2 - Len(CStr(Month(dtmDateTime))), "0") & Month(dtmDateTime) & "/" & Year(dtmDateTime)
                Case "MM/DD/YYYY"
                    strRet = StrDup(2 - Len(CStr(Month(dtmDateTime))), "0") & Month(dtmDateTime) & "/" & StrDup(2 - Len(CStr(Day(dtmDateTime))), "0") & Day(dtmDateTime) & "/" & Year(dtmDateTime)
                Case "YYYY/DD/MM"
                    strRet = Year(dtmDateTime) & "/" & StrDup(2 - Len(CStr(Day(dtmDateTime))), "0") & Day(dtmDateTime) & "/" & StrDup(2 - Len(CStr(Month(dtmDateTime))), "0") & Month(dtmDateTime)
                Case "YYYY/MM/DD"
                    strRet = Year(dtmDateTime) & "/" & StrDup(2 - Len(CStr(Month(dtmDateTime))), "0") & Month(dtmDateTime) & "/" & StrDup(2 - Len(CStr(Day(dtmDateTime))), "0") & Day(dtmDateTime)
            End Select
            If blnShowTime Then
                strRet = strRet & " " & Hour(dtmDateTime) & ":" & Minute(dtmDateTime) & ":" & Second(dtmDateTime)
            End If
            ConvertDate = strRet
        End Function

        Public Function ConvertDateBack(ByVal strDateTime As String, Optional ByVal blnShowTime As Boolean = True) As String
            Try
                Dim strDate As String
                Dim strTime As String
                Dim strDeli As String
                Dim strRet As String
                Dim strPara(1) As String
                Dim strARet(1) As String
                Dim strTypeCurent As String
                strPara(0) = "DATE_FORMAT"
                strARet = GetSystemParameters(strPara)
                If strARet(0) <> "" Then
                    strTypeCurent = strARet(0)
                Else
                    strTypeCurent = "DD/MM/YYYY"
                End If
                'strTypeCurent = "DD/MM/YYYY"
                strDateTime = Trim(strDateTime)
                If strDateTime <> "" Then
                    If InStr(strDateTime, " ") > 0 Then
                        strDate = Left(strDateTime, InStr(strDateTime, " ") - 1)
                        strTime = Trim(Right(strDateTime, Len(strDateTime) - InStr(strDateTime, " ")))
                    Else
                        strDate = strDateTime
                    End If
                    If InStr(strDate, "/") <> 0 Then
                        strDeli = "/"
                    End If
                    If InStr(strDate, "-") <> 0 Then
                        strDeli = "-"
                    End If
                End If
                If strDeli <> "" And strDate <> "" Then
                    Dim bytPos1 As Byte
                    Dim bytPos2 As Byte
                    bytPos1 = InStr(strDate, strDeli)
                    bytPos2 = InStrRev(strDate, strDeli)
                    ' convert to format mm/dd/yyyy
                    Select Case UCase(strTypeCurent)
                        Case "DD/MM/YYYY"
                            strRet = Mid(strDate, bytPos1 + 1, bytPos2 - bytPos1 - 1) & "/" & Left(strDate, bytPos1 - 1) & "/" & Right(strDate, Len(strDate) - bytPos2)
                        Case "MM/DD/YYYY"
                            strRet = strDate
                        Case "YYYY/DD/MM"
                            strRet = Right(strDate, Len(strDate) - bytPos2) & "/" & Mid(strDate, bytPos1 + 1, bytPos2 - bytPos1 - 1) & "/" & Left(strDate, bytPos1 - 1)
                        Case "YYYY/MM/DD"
                            strRet = Mid(strDate, bytPos1 + 1, bytPos2 - bytPos1 - 1) & "/" & Right(strDate, Len(strDate) - bytPos2) & "/" & Left(strDate, bytPos1 - 1)
                    End Select
                    If blnShowTime Then
                        If strTime <> "" Then
                            strRet = strRet & " " & strTime
                        Else
                            strRet = strRet & " 00:00:00"
                        End If
                    End If
                Else
                    strRet = strDateTime
                End If
                ConvertDateBack = strRet
            Catch ex As Exception
                Return strDateTime
            End Try

        End Function

        Public Function GetTempFilePath(ByVal intModuleID As Integer) As DataTable
            GetTempFilePath = ConvertTable(objDCommon.GetTempFilePath(intModuleID))
            strErrorMsg = objDCommon.ErrorMsg
            intErrorCode = objDCommon.ErrorCode
        End Function
        ' *************************************************************************************************
        ' purpose: Generate random file name for upload, import, export and insert Sys_tblDownloadFile
        ' *************************************************************************************************
        Public Function GenRandomFile() As String
            Dim dtbTempFile As DataTable = Nothing
            Randomize()
            FileName = Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65)
            strCondition = " WHERE LOWER(FileName)= LOWER('" & FileName & "." & Extension & "')"
            dtbTempFile = GetSysDownloadFile()
            While dtbTempFile.Rows.Count > 0
                FileName = Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65)
                strCondition = " WHERE LOWER(FileName)=LOWER('" & FileName & "." & Extension & "')"
                dtbTempFile = GetSysDownloadFile()
            End While
            If Trim(Extension) <> "" Then
                strFileName = FileName & "." & Extension
            Else
                strFileName = FileName
            End If
            strCreatedDate = Now()
            InsertSysDownloadFile()
            'dtbTempFile.Dispose()
            dtbTempFile = Nothing
            Return strFileName
        End Function

        ' *************************************************************************************************
        ' purpose: Insert a new record into table Sys_tblDownloadFile
        ' in: strFileName, dtCreatedDate
        ' out: true/false
        ' *************************************************************************************************
        Public Function InsertSysDownloadFile() As Boolean
            Try
                objDSyscommon.FileName = strFileName
                objDSyscommon.CreatedDate = strCreatedDate
                Return objDSyscommon.InsertSysDownloadFile
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' *************************************************************************************************
        ' purpose: Get records in table Sys_tblDownloadFile
        ' in: string: strCondition, if strCondition = null selece all fields from Sys_tblDownloadFile
        ' out: datatable 
        ' *************************************************************************************************
        Public Function GetSysDownloadFile() As DataTable
            Try
                objDSyscommon.Condition = strCondition
                Return objDSyscommon.GetSysDownloadFile()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' *************************************************************************************************
        ' purpose: Delete record(s) in table Sys_tblDownloadFile
        ' in: string: strCondition, if strCondition = null selece all fields from Sys_tblDownloadFile
        ' out: true/false
        ' *************************************************************************************************
        Public Function DeleteSysDownloadFile() As Boolean
            Try
                objDSyscommon.Condition = strCondition
                Return objDSyscommon.DeleteSysDownloadFile
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function


        '=========================================================
        ' End Process Date Time
        '=========================================================
        ' Release resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                'TvSort = Nothing
                ' Release unmanaged resources.
                If Not objDCommon Is Nothing Then
                    objDCommon.Dispose(True)
                    objDCommon = Nothing
                End If
                If Not objBString Is Nothing Then
                    objBString.Dispose(True)
                    objBString = Nothing
                End If
                If Not objDSyscommon Is Nothing Then
                    objDSyscommon.Dispose(True)
                    objDSyscommon = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace