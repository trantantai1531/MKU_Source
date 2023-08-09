'-----------------------------
' Purpose: Working with DBSystem
' Modified history: PhuongTT - 2014.09.22

Imports eMicLibOPAC.DataAccess.Common
Imports System.Data
Imports System.Collections.Generic


Namespace eMicLibOPAC.BusinessRules.Common
    Public Class clsBCommonDBSystem
        Inherits clsBBase

        Private objBString As New clsBCommonStringProc
        Private objDcommon As New clsDCommon
        Private objDSyscommon As New clsDSysCommon

        Private strSQLStatement As String
        Private strClassTab As String
        Private blnIsConvertDate As Boolean = True
        Private strDefaultError As String = "Error in BussinessRule(clsBCommonDBSystem). Description:"


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

        '-----------------------------------------
        ' This property use get/set ..
        '-----------------------------------------
        Public Property ClassTab() As String
            Get
                Dim TblSysPara As New DataTable
                TblSysPara = objDcommon.Retrieve_SysParameters("Name='USED_CLASSIFICATION'")
                ClassTab = "DDC"
                If TblSysPara.Rows.Count > 0 Then
                    If TblSysPara.Rows(0).Item("Val") = "0" Then
                        ClassTab = "BBK"
                    End If
                Else
                End If
                If objDcommon.ErrorMsg <> "" Then
                    strErrorMsg = objDcommon.ErrorMsg
                    intErrorCode = objDcommon.ErrorCode
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
            objBString.InterfaceLanguage = strInterfaceLanguage
            objBString.DBServer = strDBServer
            objBString.ConnectionString = strConnectionString
            Call objBString.Initialize()

            objDcommon.ConnectionString = strconnectionstring
            objDcommon.DBServer = strdbserver
            Call objDcommon.Initialize()

            objDSyscommon.ConnectionString = strconnectionstring
            objDSyscommon.DBServer = strdbserver
            Call objDSyscommon.Initialize()

            If objDcommon.ErrorMsg <> "" Then
                strErrorMsg = objDcommon.ErrorMsg
                intErrorCode = objDcommon.ErrorCode
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
                TblTmp = objDcommon.Retrieve_SysParameters(strSQL)
                If objDcommon.ErrorMsg <> "" Then
                    strErrorMsg = objDcommon.ErrorMsg
                    intErrorCode = objDcommon.ErrorCode
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
        ' in: Array of Alias,UserID
        ' out: a Collection 
        ' creator :
        '------------------------------------------------------------------
        Public Function CheckPermission(ByVal strAlias() As String, ByVal lngUserID As Long) As Collection
            Dim inti As Integer
            Dim objDr As DataRow()
            Dim row As DataRow
            Dim TblTmp As DataTable
            Dim strFilter As String
            Dim colRet As New Collection
            Try
                ' TblTmp = objDcommon.CheckPermission(strAlias, lngUserID)
                If objDcommon.ErrorMsg <> "" Then
                    strErrorMsg = objDcommon.ErrorMsg
                    intErrorCode = objDcommon.ErrorCode
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
            objDcommon.WriteLog(lngGroupID, objBString.ConvertItBack(strMsg), objBString.ConvertItBack(strFilename), strRemoteHost, objBString.ConvertItBack(strUser_name))
            If objDcommon.ErrorMsg <> "" Then
                strErrorMsg = objDcommon.ErrorMsg
                intErrorCode = objDcommon.ErrorCode
            End If
        End Sub


        ' Purpose : Convert Data in Table to current Encode 
        ' Note: default Not show time if have datetime fields
        ' IN: DataTable,blnShowTime, IsConvertDate Property (use for not convert datetime fields)
        ' OUT: DataTable

        Public Function ConvertTable(ByVal scrTable As DataTable, Optional ByVal blnShowTime As Boolean = False) As DataTable
            Dim strColNameTmp As String
            Dim inti As Integer
            Dim intcoli As Integer
            Dim strColDel As String
            Dim strTemp As String
            Dim strValDate As String

            strColNameTmp = ""
            If Not scrTable Is Nothing AndAlso scrTable.Rows.Count > 0 Then
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
                        Case "ORACLE"
                            ' Check String 
                            If System.Type.GetType("System.String").Equals(scrTable.Columns(intcoli).DataType) Then
                                For inti = 0 To scrTable.Rows.Count - 1
                                    If Not IsDBNull(scrTable.Rows(inti).Item(intcoli)) Then
                                        ' Convert String
                                        scrTable.Rows(inti).Item(intcoli) = objBString.ConvertIt(scrTable.Rows(inti).Item(intcoli))
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
                        scrTable.Columns(arrColDel(inti)).ColumnName = arrColDel(inti) & "_"
                        scrTable.Columns(arrColDel(inti) & "_Tmp").ColumnName = UCase(arrColDel(inti))
                    Next
                End If
            End If
            Return scrTable
        End Function

        ' Purpose : Convert all DataTable in Dataset from UTF8 Encode to current Encode 
        ' IN: Dataset
        ' OUT: Dataset

        Public Function ConvertDataSet(ByVal scrDS As DataSet, Optional ByVal blnUTF8 As Boolean = True) As DataSet
            Dim intCount As Integer
            Dim intCountCol As Integer
            Dim intRowi As Integer

            For intCount = 0 To scrDS.Tables.Count - 1
                For intCountCol = 0 To scrDS.Tables(intCount).Columns.Count - 1
                    If System.Type.GetType("System.String").Equals(scrDS.Tables(intCount).Columns(intCountCol).DataType) Then
                        For intRowi = 0 To scrDS.Tables(intCount).Rows.Count - 1
                            If Not IsDBNull(scrDS.Tables(intCount).Rows(intRowi).Item(intCountCol)) Then
                                ' Convert String
                                If blnUTF8 Then
                                    scrDS.Tables(intCount).Rows(intRowi).Item(intCountCol) = objBString.ToUTF8Back(scrDS.Tables(intCount).Rows(intRowi).Item(intCountCol))
                                Else
                                    scrDS.Tables(intCount).Rows(intRowi).Item(intCountCol) = objBString.UCS2ToCurrent(scrDS.Tables(intCount).Rows(intRowi).Item(intCountCol))
                                End If

                            End If
                        Next
                    End If
                Next
            Next
            Return scrDS
        End Function

        Public Function ConvertTableHoldingOther(ByVal scrTable As DataTable) As DataTable
            Dim arrS() As  String
            Dim arrFullName() As String
            Dim inti As Integer
            Try
            If Not scrTable Is Nothing Then
                For inti = 0 To scrTable.Columns.Count -1 
                    arrS = Split(scrTable.Rows(inti).Item("Content"), "$a")
                    scrTable.Rows(inti).Item("Content") = arrS(1)

                    'arrFullName = Split(scrTable.Rows(inti).Item("FullName"), "(")
                    'scrTable.Rows(inti).Item("FullName") = arrFullName(0)
                Next
            End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return scrTable
        End Function

        ' Purpose : Convert Data in Table to current Encode 
        ' Note: default Not show time if have datetime fields
        ' IN: DataTable,blnShowTime, IsConvertDate Property (use for not convert datetime fields)
        ' OUT: DataTable,FieldNameTrimsub : All field need TrimSubFieldCode separate by ",". Ex: FieldNameTrimsub="Title,TitleCode"
        ' Creator: dgsoft
        ' Last Update: 16/9/2004
        'Public Function ConvertTable(ByVal scrTable As DataTable, ByVal FieldNameTrimsub As String, Optional ByVal blnShowTime As Boolean = False) As DataTable
        '    Dim strColNameTmp As String
        '    Dim inti As Integer
        '    Dim intcoli As Integer
        '    Dim strColDel As String
        '    Dim strTemp As String
        '    Dim arrS() As String
        '    Dim strValDate As String


        '    strColNameTmp = ""
        '    If FieldNameTrimsub <> "" Then
        '        FieldNameTrimsub = FieldNameTrimsub.ToUpper
        '        arrS = Split(FieldNameTrimsub, ",")
        '    End If

        '    If Not scrTable Is Nothing Then
        '        If scrTable.Rows.Count > 0 Then
        '            strColDel = ""
        '            For intcoli = 0 To scrTable.Columns.Count - 1
        '                ' chi convert date khi property IsConvertDate=true(default)
        '                If blnIsConvertDate Then
        '                    ' Check DateTime
        '                    If System.Type.GetType("System.DateTime").Equals(scrTable.Columns(intcoli).DataType) Then
        '                        strColNameTmp = ""
        '                        strColNameTmp = scrTable.Columns(intcoli).ColumnName
        '                        strColDel = strColDel & strColNameTmp & ","
        '                        scrTable.Columns.Add(strColNameTmp & "_Tmp", Type.GetType("System.String"))
        '                        For inti = 0 To scrTable.Rows.Count - 1
        '                            strValDate = ""
        '                            If Not IsDBNull(scrTable.Rows(inti).Item(strColNameTmp)) Then
        '                                strValDate = ConvertDate(scrTable.Rows(inti).Item(strColNameTmp), blnShowTime)
        '                            End If
        '                            ' convert DateTime
        '                            scrTable.Rows(inti).Item(strColNameTmp & "_Tmp") = strValDate
        '                        Next
        '                    End If
        '                End If
        '                Select Case UCase(strDBServer)
        '                    Case "SQLSERVER"
        '                        Select Case UCase(strInterfaceLanguage)
        '                            Case "UNICODE"
        '                                ' UNICODE khong can phai convert
        '                                ' Chi can TrimSubFieldCode
        '                                If arrS.IndexOf(arrS, scrTable.Columns(intcoli).ColumnName.ToUpper) > -1 Then
        '                                    For inti = 0 To scrTable.Rows.Count - 1
        '                                        If Not IsDBNull(scrTable.Rows(inti).Item(intcoli)) Then
        '                                            scrTable.Rows(inti).Item(intcoli) = objBString.TrimSubFieldCodes(scrTable.Rows(inti).Item(intcoli))
        '                                        End If
        '                                    Next
        '                                End If
        '                            Case Else ' TCVN,VNI,VIQR Encode
        '                                ' Check String 
        '                                If System.Type.GetType("System.String").Equals(scrTable.Columns(intcoli).DataType) Then
        '                                    If arrS.IndexOf(arrS, scrTable.Columns(intcoli).ColumnName.ToUpper) > -1 Then
        '                                        For inti = 0 To scrTable.Rows.Count - 1
        '                                            If Not IsDBNull(scrTable.Rows(inti).Item(intcoli)) Then
        '                                                ' Convert String
        '                                                scrTable.Rows(inti).Item(intcoli) = objBString.ConvertIt(objBString.TrimSubFieldCodes(scrTable.Rows(inti).Item(intcoli)))
        '                                            End If
        '                                        Next
        '                                    Else
        '                                        For inti = 0 To scrTable.Rows.Count - 1
        '                                            If Not IsDBNull(scrTable.Rows(inti).Item(intcoli)) Then
        '                                                ' Convert String
        '                                                scrTable.Rows(inti).Item(intcoli) = objBString.ConvertIt(scrTable.Rows(inti).Item(intcoli))
        '                                            End If
        '                                        Next
        '                                    End If
        '                                End If
        '                        End Select
        '                    Case "ORACLE"
        '                        ' Check String
        '                        If System.Type.GetType("System.String").Equals(scrTable.Columns(intcoli).DataType) Then
        '                            If arrS.IndexOf(arrS, scrTable.Columns(intcoli).ColumnName.ToUpper) > -1 Then
        '                                ' dung TrimSubFieldCodes
        '                                For inti = 0 To scrTable.Rows.Count - 1
        '                                    If Not IsDBNull(scrTable.Rows(inti).Item(intcoli)) Then
        '                                        ' Convert String
        '                                        scrTable.Rows(inti).Item(intcoli) = objBString.ConvertIt(objBString.TrimSubFieldCodes(scrTable.Rows(inti).Item(intcoli)))
        '                                    End If
        '                                Next
        '                            Else
        '                                For inti = 0 To scrTable.Rows.Count - 1
        '                                    If Not IsDBNull(scrTable.Rows(inti).Item(intcoli)) Then
        '                                        ' Convert String
        '                                        scrTable.Rows(inti).Item(intcoli) = objBString.ConvertIt(scrTable.Rows(inti).Item(intcoli))
        '                                    End If
        '                                Next
        '                            End If
        '                        End If
        '                End Select
        '            Next
        '            Dim arrColDel()
        '            If strColDel <> "" Then
        '                strColDel = Left(strColDel, Len(strColDel) - 1)
        '                arrColDel = Split(strColDel, ",")
        '                ' Change name Column temp
        '                For inti = LBound(arrColDel) To UBound(arrColDel)
        '                    scrTable.Columns(arrColDel(inti)).ColumnName = arrColDel(inti) & "_"
        '                    scrTable.Columns(arrColDel(inti) & "_Tmp").ColumnName = UCase(arrColDel(inti))
        '                Next
        '            End If
        '        End If
        '    End If
        '    Return scrTable
        'End Function

        ' ---------------------------------------------------------
        ' Purpose : Insert one row in top table, or bottom table.
        ' In : Table,objInsert,blnPosition default top.
        ' Out : Table
        ' ---------------------------------------------------------
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
                    'Dim arrColDel()
                    'If strColDel <> "" Then
                    '    strColDel = Left(strColDel, Len(strColDel) - 1)
                    '    arrColDel = Split(strColDel, ",")
                    '    ' Change name Column temp
                    '    For inti = LBound(arrColDel) To UBound(arrColDel)
                    '        scrTable.Columns(arrColDel(inti)).ColumnName = UCase(arrColDel(inti)) & "_"
                    '        scrTable.Columns(arrColDel(inti) & "_Tmp").ColumnName = UCase(arrColDel(inti))
                    '    Next
                    'End If
                End If
            End If
            Return scrTable
        End Function
        Public Function InsertOneRow(ByVal scrTable As DataTable, ByVal objInsert As Object, Optional ByVal blnPosition As Boolean = True) As DataTable
            Dim objrow As DataRow
            Dim byti As Integer
            If Not (scrTable Is Nothing) Then
                objrow = scrTable.NewRow
                For byti = 0 To scrTable.Columns.Count - 1
                    If System.Type.GetType("System.Decimal").Equals(scrTable.Columns(byti).DataType) Then
                        objrow.Item(byti) = 0
                    ElseIf System.Type.GetType("System.DateTime").Equals(scrTable.Columns(byti).DataType) Then
                        objrow.Item(byti) = Now
                    ElseIf System.Type.GetType("System.Boolean").Equals(scrTable.Columns(byti).DataType) Then
                        objrow.Item(byti) = True
                    ElseIf System.Type.GetType("System.Byte").Equals(scrTable.Columns(byti).DataType) Then
                        objrow.Item(byti) = 0
                    ElseIf System.Type.GetType("System.Single").Equals(scrTable.Columns(byti).DataType) Then
                        objrow.Item(byti) = 0
                    ElseIf System.Type.GetType("System.Int16").Equals(scrTable.Columns(byti).DataType) Then
                        objrow.Item(byti) = 0
                    ElseIf System.Type.GetType("System.Int32").Equals(scrTable.Columns(byti).DataType) Then
                        objrow.Item(byti) = 0
                    ElseIf System.Type.GetType("System.Int64").Equals(scrTable.Columns(byti).DataType) Then
                        objrow.Item(byti) = 0
                    ElseIf System.Type.GetType("System.Double").Equals(scrTable.Columns(byti).DataType) Then
                        objrow.Item(byti) = 0
                    ElseIf System.Type.GetType("System.String").Equals(scrTable.Columns(byti).DataType) Then
                        If IsDBNull(objInsert) Then
                            strErrorMsg = "Object is Null"
                            Exit Function
                        Else
                            objrow.Item(byti) = objInsert
                        End If
                    End If
                Next
                If blnPosition = True Then
                    scrTable.Rows.InsertAt(objrow, 0)
                Else
                    scrTable.Rows.InsertAt(objrow, scrTable.Rows.Count)
                End If
            Else
                strErrorMsg = "scrTable is not table !"
            End If
            Return scrTable
        End Function

        ' purpose : Tao 1 bang dua vao hai Array dung khi Bind no vao 
        '            mot datagrid hoac dropdownlist

        Public Function CreateTable(ByVal ArrTextField As Object, ByVal ArrValueField As Object) As DataTable
            Dim TblRet As New DataTable
            If IsArray(ArrTextField) And IsArray(ArrValueField) Then
                If UBound(ArrTextField) = UBound(ArrValueField) Then
                    Dim inti As Integer
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
                    For inti = 0 To UBound(ArrTextField)
                        Try
                            row = TblRet.NewRow
                            row(0) = ArrTextField(inti)
                            row(1) = ArrValueField(inti)
                            TblRet.Rows.Add(row)
                        Catch ex As Exception
                            strErrorMsg = ex.Message
                            row(0) = ""
                            row(1) = ""
                        End Try
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

        Public Function CreateTables(ByVal ArrField() As Object, ByVal ArrTypeField As Object, ByVal ArrFieldName As Object, Optional ByVal blnDefaultType As Boolean = True, Optional ByVal blnDefaultName As Boolean = True) As DataTable
            Dim TblRet As New DataTable
            Dim intColumn As Integer
            Dim inti As Integer
            Try
                If blnDefaultType = False Then
                    ReDim ArrTypeField(UBound(ArrField))
                    For inti = 0 To UBound(ArrField) - 1
                        ArrTypeField(inti) = "String"
                    Next
                End If
                If blnDefaultName = False Then
                    ReDim ArrTypeField(UBound(ArrField))
                    For inti = 0 To UBound(ArrField) - 1
                        ArrFieldName(inti) = "Field" + CStr(inti)
                    Next
                End If
                If IsArray(ArrTypeField) Then
                    If UBound(ArrField) = UBound(ArrTypeField) Then
                        intColumn = UBound(ArrTypeField) - 1
                        Dim byti As Byte
                        Dim row As DataRow
                        For inti = 0 To intColumn
                            If Trim(ArrTypeField(inti)) = "String" Then
                                TblRet.Columns.Add(ArrFieldName(inti), System.Type.GetType("System.String"))
                            ElseIf Trim(ArrTypeField(inti)) = "Int64" Then
                                TblRet.Columns.Add(ArrFieldName(inti), System.Type.GetType("System.Int64"))
                            ElseIf Trim(ArrTypeField(inti)) = "Int32" Then
                                TblRet.Columns.Add(ArrFieldName(inti), System.Type.GetType("System.Int32"))
                            ElseIf Trim(ArrTypeField(inti)) = "DateTime" Then
                                TblRet.Columns.Add(ArrFieldName(inti), System.Type.GetType("System.DateTime"))
                            ElseIf Trim(ArrTypeField(inti)) = "Decimal" Then
                                TblRet.Columns.Add(ArrFieldName(inti), System.Type.GetType("System.Decimal"))
                            ElseIf Trim(ArrTypeField(inti)) = "Boolean" Then
                                TblRet.Columns.Add(ArrFieldName(inti), System.Type.GetType("System.Boolean"))
                            ElseIf Trim(ArrTypeField(inti)) = "Double" Then
                                TblRet.Columns.Add(ArrFieldName(inti), System.Type.GetType("System.Double"))
                            ElseIf Trim(ArrTypeField(inti)) = "Single" Then
                                TblRet.Columns.Add(ArrFieldName(inti), System.Type.GetType("System.Single"))
                            End If
                            For byti = 0 To UBound(ArrField(inti))
                                row = TblRet.NewRow
                                row(inti) = ArrField(byti)
                                TblRet.Rows.Add(row)
                            Next
                        Next
                        CreateTables = TblRet
                    Else
                        strErrorMsg = "Length of two Parameters not equal"
                        Exit Function
                    End If
                Else
                    strErrorMsg = "Parameter not an Array"
                    Exit Function
                End If
            Catch
                strErrorMsg = "Parameter not an Array"
            End Try
        End Function

        ' purpose : Tao mang sap xep theo mot mang chua index cua no
        ' In : ArrID -> mang can sort
        '      ArrIndex -> Mang chua index cua ArrID da sort
        ' Out : Mang sort

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

        ' purpose : Tao bang sap xep theo ID
        ' In : TblSource -> bang du can sort
        '      ArrID -> Mang da sap xep
        ' Out : Bang
        ' Creator : dgsoft2016
        Public Function GenTableSort(ByVal ArrID As Object, ByVal TblSource As DataTable) As DataTable
            Dim TblRet As New DataTable("tbl_tmp")
            Dim row As DataRow
            Dim rowi() As DataRow
            If IsArray(ArrID) And TblSource.Rows.Count > 0 Then
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


        Public Function eSortTable(ByVal srcTable As DataTable, ByVal strColSort As String, Optional ByVal strSortMethod As String = "ASC") As DataView
            Dim TblRet As New DataTable("tbl_tmp")
            Dim inti As Integer
            Dim blnHaveCol As Boolean
            Dim dtvRet As DataView

            strColSort = UCase(strColSort)
            blnHaveCol = False
            For inti = 0 To srcTable.Columns.Count - 1
                If UCase(srcTable.Columns(inti).ColumnName) = strColSort Then
                    blnHaveCol = True
                    Exit For
                End If
            Next
            ' check collumn to sort
            If Not blnHaveCol Then
                strErrorMsg = "Column " & strColSort & " Not found !"
                eSortTable = srcTable.DefaultView
                Exit Function
            End If
            If srcTable.Rows.Count > 0 Then
                dtvRet = srcTable.DefaultView
                dtvRet.Sort = strColSort & " " & strSortMethod
            Else
                dtvRet = srcTable.DefaultView
            End If
            eSortTable = dtvRet
        End Function

        'Public Function SortTable_old(ByVal srcTable As DataTable, ByVal strColSort As String) As DataView
        '    Dim TblRet As New DataTable("tbl_tmp")
        '    Dim inti As Integer
        '    Dim blnHaveCol As Boolean
        '    Dim strConv As String
        '    Dim row As DataRow
        '    Dim dtvRet As DataView

        '    strColSort = UCase(strColSort)
        '    blnHaveCol = False
        '    For inti = 0 To srcTable.Columns.Count - 1
        '        If UCase(srcTable.Columns(inti).ColumnName) = strColSort Then
        '            blnHaveCol = True
        '            Exit For
        '        End If
        '    Next
        '    ' check collumn to sort
        '    If Not blnHaveCol Then
        '        strErrorMsg = "Column " & strColSort & " Not found !"
        '        SortTable = srcTable.DefaultView
        '        Exit Function
        '    End If
        '    If srcTable.Rows.Count > 0 Then
        '        ' kiem tra du lieu la text moi dung Tvsort
        '        If System.Type.GetType("System.String").Equals(srcTable.Columns(strColSort).DataType) Then
        '            If srcTable.Columns.IndexOf(strColSort & "_") > -1 Then
        '                ' la truong datetime
        '                dtvRet = srcTable.DefaultView
        '                dtvRet.Sort = strColSort & "_ ASC"
        '            Else
        '                ' khong phai la truong datetime
        '                Dim ArrIndex()
        '                Dim ArrText()
        '                ReDim ArrText(srcTable.Rows.Count - 1)
        '                TblRet = srcTable.Clone
        '                ' export Table to Array
        '                For inti = 0 To srcTable.Rows.Count - 1
        '                    ArrText(inti) = srcTable.Rows(inti).Item(strColSort) & ""
        '                    ArrText(inti) = Trim(objBString.ToUTF8(ArrText(inti)))
        '                Next
        '                ' Use tvcom to sort utf8 encode
        '                ArrIndex = TvSort.SortIndex(ArrText, 1)
        '                ' Create new table have been sort
        '                For inti = 0 To srcTable.Rows.Count - 1
        '                    row = TblRet.NewRow
        '                    row = srcTable.Rows(ArrIndex(inti))
        '                    TblRet.ImportRow(row)
        '                Next
        '                dtvRet = TblRet.DefaultView
        '            End If
        '        Else
        '            dtvRet = srcTable.DefaultView
        '            dtvRet.Sort = strColSort & " ASC"
        '        End If
        '    Else
        '        dtvRet = srcTable.DefaultView
        '    End If
        '    SortTable = dtvRet
        'End Function


        Public Function SortTable(ByVal srcTable As DataTable, ByVal strColSort As String) As DataView
            Dim TblRet As New DataTable("tbl_tmp")
            Dim inti As Integer
            Dim blnHaveCol As Boolean
            Dim dtvRet As DataView
            Dim dtrow As DataRow

            strColSort = UCase(strColSort)
            blnHaveCol = False
            For inti = 0 To srcTable.Columns.Count - 1
                If UCase(srcTable.Columns(inti).ColumnName) = strColSort Then
                    blnHaveCol = True
                    Exit For
                End If
            Next
            ' check collumn to sort
            If Not blnHaveCol Then
                strErrorMsg = "Column " & strColSort & " Not found !"
                SortTable = srcTable.DefaultView
                Exit Function
            End If
            If srcTable.Rows.Count > 0 Then
                ' kiem tra du lieu la text 
                If System.Type.GetType("System.String").Equals(srcTable.Columns(strColSort).DataType) Then
                    If srcTable.Columns.IndexOf(strColSort & "_") > -1 Then
                        ' la truong datetime
                        dtvRet = srcTable.DefaultView
                        dtvRet.Sort = strColSort & "_ ASC"
                    Else
                        Dim sortDic As New SortedDictionary(Of String, Integer)
                        Dim strKey As String = ""
                        Dim intValue As Integer = 0
                        For inti = 0 To srcTable.Rows.Count - 1
                            Try
                                strKey = ""
                                If Not IsDBNull(srcTable.Rows(inti).Item(strColSort)) Then
                                    strKey = Trim(srcTable.Rows(inti).Item(strColSort))
                                End If
                                strKey &= srcTable.Rows(inti).Item("ID")
                                intValue = srcTable.Rows(inti).Item("ID")
                                sortDic.Add(strKey, intValue)
                            Catch ex As Exception
                                'pass duplicate record
                            End Try
                        Next
                        TblRet.Columns.Add("ID")
                        For Each kvp As KeyValuePair(Of String, Integer) In sortDic
                            dtrow = TblRet.NewRow
                            dtrow.Item(0) = kvp.Value
                            TblRet.Rows.Add(dtrow)
                        Next kvp
                        dtvRet = TblRet.DefaultView
                    End If
                Else
                    dtvRet = srcTable.DefaultView
                    dtvRet.Sort = strColSort & " ASC"
                End If
            Else
                dtvRet = srcTable.DefaultView
            End If
            SortTable = dtvRet
        End Function

        ' Retrieve data
        ' Input: string of select statement
        ' Output: DataTable
        ' STOREPROCEDURE
        Public Function RetrieveItemInfor(Optional ByVal blnConvert As Boolean = True) As DataTable
            Try
                objDcommon.SQLStatement = strSQLStatement
                If blnConvert Then
                    RetrieveItemInfor = Me.ConvertTable(objDcommon.RetrieveItemInfor)
                Else
                    RetrieveItemInfor = objDcommon.RetrieveItemInfor
                End If
                strErrorMsg = objDcommon.ErrorMsg
                intErrorCode = objDcommon.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

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

        '------------------------------------------------------------------------
        ' purpose: ddi.nh da.ng kie^?u nga`y tha'ng ve^` da.ng mm/dd/yyyy
        ' in : strTypeCurent,strDate
        ' Out : string format datetime
        ' Creator : dgsoft2016
        '------------------------------------------------------------------------
        Public Function ConvertDateBack(ByVal strDateTime As String, Optional ByVal blnShowTime As Boolean = True) As String
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
                        strRet = Mid(strDate, bytPos1 + 1, bytPos2 - bytPos1 - 1).PadLeft(2, "0") & "/" & Left(strDate, bytPos1 - 1).PadLeft(2, "0") & "/" & Right(strDate, Len(strDate) - bytPos2)
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
        End Function

        '------------------------------------------------------------------------
        ' purpose: Get the file path of a module's folder to upload file 
        ' in: ModuleName
        ' Out : DataTable
        '------------------------------------------------------------------------
        Public Function GetTempFilePath(ByVal intModuleID As Integer) As DataTable
            GetTempFilePath = ConvertTable(objDcommon.GetTempFilePath(intModuleID))
            strErrorMsg = objDcommon.ErrorMsg
            intErrorCode = objDcommon.ErrorCode
        End Function

        Public Function GetSysDownloadFile(ByVal strCondition As String) As DataTable
            Try
                objDSyscommon.Condition = strCondition
                Return objDSyscommon.GetSysDownloadFile()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function DeleteSysDownloadFile(ByVal strCondition As String) As Boolean
            Try
                objDSyscommon.Condition = strCondition
                Return objDSyscommon.DeleteSysDownloadFile
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GenRandomFile(ByVal Extension As String) As String
            Dim dtbTempFile As DataTable = Nothing
            Dim strFilename As String
            Randomize()
            strFilename = Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65)
            dtbTempFile = GetSysDownloadFile(" WHERE LOWER(FileName)= LOWER('" & strFilename & "." & Extension & "')")
            While dtbTempFile.Rows.Count > 0
                strFilename = Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65)
                dtbTempFile = GetSysDownloadFile(" WHERE LOWER(FileName)=LOWER('" & strFilename & "." & Extension & "')")
            End While
            If Trim(Extension) <> "" Then
                strFilename = strFilename & "." & Extension
            End If
            InsertSysDownloadFile(strFilename, Now())
            'dtbTempFile.Dispose()
            dtbTempFile = Nothing
            Return strFilename
        End Function

        Public Function InsertSysDownloadFile(ByVal strFileName As String, ByVal strCreatedDate As String) As Boolean
            Try
                objDSyscommon.FileName = strFileName
                objDSyscommon.CreatedDate = strCreatedDate
                Return objDSyscommon.InsertSysDownloadFile
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
                ' Release unmanaged resources.
                If Not objDcommon Is Nothing Then
                    objDcommon.Dispose(True)
                    objDcommon = Nothing
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