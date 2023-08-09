Imports eMicLibAdmin.DataAccess.Catalogue
Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.BusinessRules.Catalogue
    Public Class clsBDictionarySelfMade
        Inherits clsBBase

        ' Declare variables
        Private objBCDBS As New clsBCommonDBSystem
        Private objBCSP As New clsBCommonStringProc
        Private objDDicShelfMade As New clsDDictionarySelfMade

        Private strTableName As String
        Private strFieldCode As String
        Private strFieldName As String
        Private intID As Integer
        Private strDictionary As String = ""
        Private strAccessEntry As String
        Private intDicID As Integer
        Private strFieldID As String
        Private strContent As String
        Private intForPatron As Integer
        Private intForStaff As Integer
        Private intFieldSize As Integer
        Private strNameDic As String
        Private intItemID As Integer
        Private intIDNew As Integer
        Private strIDMerge As String

        ' IDNew property
        Public Property IDNew() As Integer
            Get
                Return intIDNew
            End Get
            Set(ByVal Value As Integer)
                intIDNew = Value
            End Set
        End Property

        ' IDMerge property
        Public Property IDMerge() As String
            Get
                Return strIDMerge
            End Get
            Set(ByVal Value As String)
                strIDMerge = Value
            End Set
        End Property

        ' TableName property
        Public Property TableName() As String
            Get
                Return strTableName
            End Get
            Set(ByVal Value As String)
                strTableName = Value
            End Set
        End Property

        ' FieldCode property
        Public Property FieldCode() As String
            Get
                Return strFieldCode
            End Get
            Set(ByVal Value As String)
                strFieldCode = Value
            End Set
        End Property

        ' FieldName property
        Public Property FieldName() As String
            Get
                Return strFieldName
            End Get
            Set(ByVal Value As String)
                strFieldName = Value
            End Set
        End Property

        ' ID property
        Public Property ID() As Integer
            Get
                Return intID
            End Get
            Set(ByVal Value As Integer)
                intID = Value
            End Set
        End Property

        ' Dictionary property
        Public Property Dictionary() As String
            Get
                Return strDictionary
            End Get
            Set(ByVal Value As String)
                strDictionary = Value
            End Set
        End Property

        ' AccessEntry property
        Public Property AccessEntry() As String
            Get
                Return strAccessEntry
            End Get
            Set(ByVal Value As String)
                strAccessEntry = Value
            End Set
        End Property

        ' DicID property
        Public Property DicID() As Integer
            Get
                Return intDicID
            End Get
            Set(ByVal Value As Integer)
                intDicID = Value
            End Set
        End Property

        ' FieldID property
        Public Property FieldID() As String
            Get
                Return strFieldID
            End Get
            Set(ByVal Value As String)
                strFieldID = Value
            End Set
        End Property

        ' Content property
        Public Property Content() As String
            Get
                Return strContent
            End Get
            Set(ByVal Value As String)
                strContent = Value
            End Set
        End Property

        ' ForPatron property
        Public Property ForPatron() As Integer
            Get
                Return intForPatron
            End Get
            Set(ByVal Value As Integer)
                intForPatron = Value
            End Set
        End Property

        ' ForStaff property
        Public Property ForStaff() As Integer
            Get
                Return intForStaff
            End Get
            Set(ByVal Value As Integer)
                intForStaff = Value
            End Set
        End Property

        ' FieldSize property
        Public Property FieldSize()
            Get
                Return intFieldSize
            End Get
            Set(ByVal Value)
                intFieldSize = Value
            End Set
        End Property

        ' NameDic property
        Public Property NameDic() As String
            Get
                Return strNameDic
            End Get
            Set(ByVal Value As String)
                strNameDic = Value
            End Set
        End Property

        ' ItemID property
        Public Property ItemID() As Integer
            Get
                Return intItemID
            End Get
            Set(ByVal Value As Integer)
                intItemID = Value
            End Set
        End Property

        Public Sub Initialize()
            Try
                objBCDBS.InterfaceLanguage = strInterfaceLanguage
                objBCDBS.DBServer = strDBServer
                objBCDBS.ConnectionString = strConnectionString
                objBCDBS.Initialize()

                objBCSP.InterfaceLanguage = strInterfaceLanguage
                objBCSP.DBServer = strDBServer
                objBCSP.ConnectionString = strConnectionString
                objBCSP.Initialize()

                objDDicShelfMade.DBServer = strDBServer
                objDDicShelfMade.ConnectionString = strConnectionString
                objDDicShelfMade.Initialize()
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        ' Method: UpdateEntry
        ' Purpose: Update information of the selected entry
        ' Input: some main infor
        Public Sub UpdateEntry()
            Dim strTemp As String

            Try
                strTemp = objBCSP.ConvertItBack(strDictionary)
                objDDicShelfMade.Dictionary = strTemp
                objDDicShelfMade.AccessEntry = objBCSP.ProcessVal(strTemp)
                objDDicShelfMade.ID = intID
                objDDicShelfMade.DicID = intDicID
                objDDicShelfMade.UpdateEntry()
                strErrorMsg = objDDicShelfMade.ErrorMsg
                intErrorCode = objDDicShelfMade.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        ' Method: RemoveAllEntries
        ' Purpose: Remove all entries of the selected dictionary
        ' Input: Name of dictionary, fielcode
        Public Sub RemoveAllEntries()
            Try
                objDDicShelfMade.TableName = strTableName
                objDDicShelfMade.FieldCode = strFieldCode
                Call objDDicShelfMade.RemoveAllEntries()
                strTableName = ""
                strFieldCode = ""
                strErrorMsg = objDDicShelfMade.ErrorMsg
                intErrorCode = objDDicShelfMade.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        ' Method: CreateEntry
        ' Purpose: New entry
        Public Function CreateEntry() As Integer
            Dim strTemp As String
            Try
                strTemp = objBCSP.ConvertItBack(strDictionary)
                objDDicShelfMade.TableName = strTableName
                objDDicShelfMade.Dictionary = Replace(strTemp, "'", "''")
                objDDicShelfMade.AccessEntry = objBCSP.ProcessVal(strTemp)
                CreateEntry = objDDicShelfMade.CreateEntry()
                strErrorMsg = objDDicShelfMade.ErrorMsg
                intErrorCode = objDDicShelfMade.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' Method: Insert_Item_Dic
        Public Sub Insert_Item_Dic()
            Try
                objDDicShelfMade.ItemID = intItemID
                objDDicShelfMade.TableName = objBCSP.ConvertItBack(strTableName)
                objDDicShelfMade.FieldCode = objBCSP.ConvertItBack(strFieldCode)
                objDDicShelfMade.DicID = intDicID
                objDDicShelfMade.Insert_Item_Dic()
                strErrorMsg = objDDicShelfMade.ErrorMsg
                intErrorCode = objDDicShelfMade.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        ' Method: CreateID
        ' Purpose: Get next ID of the selected table
        Public Function CreateID() As Integer
            Dim tbltemp As New DataTable

            Try
                objDDicShelfMade.TableName = strTableName
                objDDicShelfMade.FieldID = strFieldID
                tbltemp = objDDicShelfMade.GetNextID()
                If tbltemp.Rows.Count > 0 Then
                    CreateID = CLng(tbltemp.Rows(0).Item("val")) + 1
                Else
                    CreateID = 1
                End If
                tbltemp.Clear()
                strErrorMsg = objDDicShelfMade.ErrorMsg
                intErrorCode = objDDicShelfMade.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' Method: Retrieve_Source_Dic
        Public Function Retrieve_Source_Dic() As DataTable
            Try
                objDDicShelfMade.FieldCode = objBCSP.ConvertItBack(strFieldCode)
                Retrieve_Source_Dic = objBCDBS.ConvertTable(objDDicShelfMade.Retrieve_Source_Dic())
                strFieldName = objBCSP.ConvertIt(objDDicShelfMade.FieldName)
                strTableName = objBCSP.ConvertIt(objDDicShelfMade.TableName)
                strErrorMsg = objDDicShelfMade.ErrorMsg
                intErrorCode = objDDicShelfMade.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' Method: Retrieve_Source_Dic_byVal
        Public Function Retrieve_Source_Dic_byVal() As DataTable
            Try
                objDDicShelfMade.Content = Replace(objBCSP.ConvertItBack(strContent), "'", "''")
                objDDicShelfMade.FieldName = objBCSP.ConvertItBack(strFieldName)
                objDDicShelfMade.TableName = objBCSP.ConvertItBack(strTableName)
                Retrieve_Source_Dic_byVal = objBCDBS.ConvertTable(objDDicShelfMade.Retrieve_Source_Dic_byVal())
                strErrorMsg = objDDicShelfMade.ErrorMsg
                intErrorCode = objDDicShelfMade.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' Method: Retrieve_Table_By_FieldCode
        Public Function Retrieve_Table_By_FieldCode() As DataTable
            Try
                objDDicShelfMade.FieldCode = objBCSP.ConvertItBack(strFieldCode)
                Retrieve_Table_By_FieldCode = objBCDBS.ConvertTable(objDDicShelfMade.Retrieve_Table_By_FieldCode)
                strErrorMsg = objDDicShelfMade.ErrorMsg
                intErrorCode = objDDicShelfMade.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' Method: ChangeDic
        ' Purpose: Modify information of the selected index (rename, reindex...)
        ' Input: Some main informations
        ' Output: int value
        Public Function ChangeDic() As Integer
            Try
                objDDicShelfMade.ID = intID
                objDDicShelfMade.TableName = objBCSP.ConvertItBack(strTableName)
                objDDicShelfMade.ForPatron = intForPatron
                objDDicShelfMade.ForStaff = intForStaff
                objDDicShelfMade.FieldSize = intFieldSize
                ChangeDic = objDDicShelfMade.ChangeDic()
                strErrorMsg = objDDicShelfMade.ErrorMsg
                intErrorCode = objDDicShelfMade.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' CreateDictionary method
        ' Purpose: Create dictionary
        ' Input: some main informations
        ' Output: int value
        Public Function CreateDictionary() As Integer
            Try
                objDDicShelfMade.NameDic = objBCSP.ConvertItBack(strNameDic)
                objDDicShelfMade.FieldSize = intFieldSize
                objDDicShelfMade.ForPatron = intForPatron
                objDDicShelfMade.ForStaff = intForStaff
                objDDicShelfMade.LibID = intLibID
                CreateDictionary = objDDicShelfMade.CreateDictionary()
                strErrorMsg = objDDicShelfMade.ErrorMsg
                intErrorCode = objDDicShelfMade.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' DropDictionary method
        ' Purpose: drop dictionary table
        ' Input: ID of the dictionary
        Public Sub DropDictionary()
            Try
                objDDicShelfMade.ID = intID
                objDDicShelfMade.DropDictionary()
                strErrorMsg = objDDicShelfMade.ErrorMsg
                intErrorCode = objDDicShelfMade.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        ' Purpose: Return Code Alert after check to insert Dictionary
        ' IN : DicID, FielsCode
        ' OUT: 
        '	1 - Chua co nhan truong
        '	2 - Nhan truong da ton tai tu dien tham chieu khac
        '	3 - Nhan truong gan voi tu dien tham chieu nay, co the lay du lieu lai tu Bang Field900s
        '	4 - Nhan truong khong thuoc dang usmarc
        '	5 - Nhan truong thuoc dang usmarc chuan  (khong thuoc dang usmarc mo rong)
        '	6 - Nhan truong da ton tai va chua gan voi tu dien tham chieu nao
        Public Function CheckDicID(ByVal intLocalDicID As Integer) As Integer
            Try
                ' kiem tra strNhanTruong co phai theo chuan usmarc hay khong
                strFieldCode = Trim(strFieldCode)
                If Len(strFieldCode) <> 5 And Len(strFieldCode) <> 3 Then
                    CheckDicID = 4
                    Exit Function
                End If
                Dim strSubField As String
                strSubField = Left(strFieldCode, 3)
                If Len(strFieldCode) = 5 Then
                    If Not Mid(strFieldCode, 4, 1) = "$" Or (Right(strFieldCode, 1) < "0" Or LCase(Right(strFieldCode, 1)) > "z") Then
                        CheckDicID = 4
                        Exit Function
                    End If
                End If
                If Not IsNumeric(strSubField) Then
                    CheckDicID = 4
                    Exit Function
                End If
                Dim blnUSMARC As Boolean
                If Left(strSubField, 1) = "9" Or Mid(strSubField, 2, 1) = "9" Then
                    blnUSMARC = False
                Else
                    blnUSMARC = True
                End If

                'kiem tra da ton tai nhan truong ?
                Dim tblFieldCode As New DataTable
                tblFieldCode = Me.Retrieve_Table_By_FieldCode
                If tblFieldCode.Rows.Count = 0 Then
                    CheckDicID = 1
                Else
                    If Not IsDBNull(tblFieldCode.Rows(0).Item("dicID")) Then
                        If CInt(tblFieldCode.Rows(0).Item("dicID")) > 0 Then
                            If CInt(tblFieldCode.Rows(0).Item("dicID")) <> intLocalDicID Then
                                CheckDicID = 2
                                'If Not CInt(tblFieldCode.Rows(0).Item("SystemDic")) = 0 Then
                                '    'Nhan truong da ton tai tu dien tham chieu khac
                                '    CheckDicID = 2
                                'Else
                                '    CheckDicID = 2
                                'End If
                            Else
                                'Nhan truong gan voi tu dien tham chieu nay
                                CheckDicID = 3
                            End If
                        End If
                    Else
                        'Nhan truong chua tham chieu toi tu dien tham chieu nao
                        CheckDicID = 6
                    End If
                End If
                strErrorMsg = objDDicShelfMade.ErrorMsg
                intErrorCode = objDDicShelfMade.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' GetEntries method
        ' Purpose: Get list of entries
        ' Input: DicID, AccessEntry
        ' Output: datatable result
        Public Function GetEntries() As DataTable
            Try
                objDDicShelfMade.DicID = intDicID
                objDDicShelfMade.AccessEntry = objBCSP.ConvertItBack(strDictionary)
                GetEntries = objBCDBS.ConvertTable(objDDicShelfMade.GetEntries)
                strErrorMsg = objDDicShelfMade.ErrorMsg
                intErrorCode = objDDicShelfMade.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' Method: MergeEntries
        ' Purpose: merge some entries
        ' Input: some main information
        Public Sub MergeEntries()
            Try
                objDDicShelfMade.DicID = intDicID
                objDDicShelfMade.IDMerge = objBCSP.ConvertItBack(strIDMerge)
                objDDicShelfMade.IDNew = intIDNew
                objDDicShelfMade.MergeEntries()
                strErrorMsg = objDDicShelfMade.ErrorMsg
                intErrorCode = objDDicShelfMade.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        ' Method: NewEntry
        ' Purpose: new entry
        Public Function NewEntry() As Byte
            Dim bytRET As Byte
            Dim strDic As String
            Dim tblTemp As New DataTable

            Try
                tblTemp = GetEntries()
                If tblTemp.Rows.Count > 0 Then
                    bytRET = 1 ' Exist
                Else
                    strFieldID = "ID" ' need for CreateID
                    strTableName = "DICTIONARY" & Trim(CStr(intDicID)) ' need for CreateID
                    strDic = objBCSP.ConvertItBack(strDictionary)
                    objDDicShelfMade.ID = CreateID()
                    objDDicShelfMade.Dictionary = strDic
                    objDDicShelfMade.AccessEntry = objBCSP.ProcessVal(strDic)
                    objDDicShelfMade.TableName = strTableName
                    objDDicShelfMade.CreateEntry()
                    bytRET = 0
                End If
                NewEntry = bytRET
                strErrorMsg = objDDicShelfMade.ErrorMsg
                intErrorCode = objDDicShelfMade.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' Method: SetDicIDForField
        ' Purpose: Set DicID for the selected field
        ' Input: DicID, FieldCode
        Public Sub SetDicIDForField()
            Try
                objDDicShelfMade.DicID = intDicID
                objDDicShelfMade.FieldCode = Trim(strFieldCode)
                objDDicShelfMade.SetDicIDForField()
                strErrorMsg = objDDicShelfMade.ErrorMsg
                intErrorCode = objDDicShelfMade.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        ' Release resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objDDicShelfMade Is Nothing Then
                    objDDicShelfMade.Dispose(True)
                    objDDicShelfMade = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace