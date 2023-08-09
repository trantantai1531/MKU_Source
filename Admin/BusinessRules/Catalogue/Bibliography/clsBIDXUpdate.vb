Imports eMicLibAdmin.DataAccess
Imports eMicLibAdmin.DataAccess.Catalogue
Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.BusinessRules.Catalogue
    Public Class clsBIDXUpdate
        Inherits clsBBase

        ' declare object
        Private objBString As New clsBCommonStringProc
        Private objBComDBSys As New clsBCommonDBSystem
        Private objBIDX As New clsBIDX
        Private objBIDXGroup As New clsBIDXGroup
        Private objBCataLib As New clsBCataLib
        Private objBFormSQL As New clsBFormingSQL

        ' declare variable
        Private strOrderBy As String = ""
        Private strGroupName As String = ""
        Private strQString As String = ""
        Private objBool As Object
        Private objField As Object
        Private objValue As Object

        Public abc As String


        Public Property OrderBy() As String
            Get
                Return strOrderBy
            End Get
            Set(ByVal Value As String)
                strOrderBy = Value
            End Set
        End Property

        Public Property GroupName() As String
            Get
                Return strGroupName
            End Get
            Set(ByVal Value As String)
                strGroupName = Value
            End Set
        End Property

        Public Property QString() As String
            Get
                Return strQString
            End Get
            Set(ByVal Value As String)
                strQString = Value
            End Set
        End Property

        Public WriteOnly Property arrBool() As Object
            Set(ByVal Value As Object)
                objBool = Value
            End Set
        End Property

        Public WriteOnly Property arrField() As Object
            Set(ByVal Value As Object)
                objField = Value
            End Set
        End Property

        Public WriteOnly Property arrValue() As Object
            Set(ByVal Value As Object)
                objValue = Value
            End Set
        End Property

        Public Sub Initialize()
            objBComDBSys.ConnectionString = strConnectionstring
            objBComDBSys.DBServer = strDBServer
            objBComDBSys.InterfaceLanguage = strInterfaceLanguage
            objBComDBSys.Initialize()

            objBIDX.ConnectionString = strConnectionstring
            objBIDX.InterfaceLanguage = strInterfaceLanguage
            objBIDX.DBServer = strDBServer
            objBIDX.Initialize()

            objBIDXGroup.ConnectionString = strConnectionstring
            objBIDXGroup.InterfaceLanguage = strInterfaceLanguage
            objBIDXGroup.DBServer = strDBServer
            objBIDXGroup.Initialize()

            objBCataLib.ConnectionString = strConnectionstring
            objBCataLib.InterfaceLanguage = strInterfaceLanguage
            objBCataLib.DBServer = strDBServer
            objBCataLib.Initialize()

            objBString.InterfaceLanguage = strInterfaceLanguage
            objBString.ConnectionString = strConnectionstring
            objBString.DBServer = strDBServer
            objBString.Initialize()

            objBFormSQL.InterfaceLanguage = strInterfaceLanguage
            objBFormSQL.ConnectionString = strConnectionstring
            objBFormSQL.DBServer = strDBServer
            objBFormSQL.Initialize()
        End Sub

        ' idxUpdate function
        Public Function idxUpdate(ByVal intIDXID As Integer, ByVal intGroupID As Integer, ByVal strUpdateType As String) As Long
            Dim bytRet As Byte = 0
            Dim strSQL As String = ""
            Dim strGroupBy As String
            Dim TblIDX As New DataTable
            Dim arrItemID As Object
            Dim intPositionNew As Integer
            Dim intGroupIDNew As Integer
            Dim intCount As Integer
            Dim lngNORs As Long
            Dim strItemIDs As String = ""
            Dim intCurPos As Integer
            Dim intPart_Index As Integer
            Dim strSQLTmp As String
            Dim strQStringTmp As String

            ' Read information GroupBy
            objBIDX.IDs = CStr(intIDXID)
            TblIDX = objBIDX.IDXRetrieve()
            If TblIDX.Rows.Count > 0 Then
                strGroupBy = TblIDX.Rows(0).Item("GroupedBy")
            End If
            ' Generate SQLStatement
            objBFormSQL.FieldArr = objField
            objBFormSQL.ValArr = objValue
            objBFormSQL.BoolArr = objBool
            objBFormSQL.LibID = intLibID
            strSQL = objBFormSQL.FormingASQL
            ' Process and return array ID have sort
            arrItemID = objBCataLib.SortRecordIDs(strOrderBy, strGroupBy, strSQL)
            'abc = objBCataLib.abc
            'Exit Function
            lngNORs = UBound(arrItemID) + 1
            If CStr(arrItemID(0) & "") <> "empty" Then
                objBIDX.UPDType = UCase(Trim(strUpdateType))
                objBIDX.IDs = CStr(intIDXID)
                objBIDX.GroupID = intGroupID
                objBIDX.NORs = lngNORs
                objBIDX.IDXChange()
                intPositionNew = objBIDX.PositionOUT
                intGroupIDNew = objBIDX.GroupIDOUT

                If UBound(arrItemID) > 99 Then
                    ' split 99 IDs/record
                    intCurPos = 0
                    intPart_Index = 1
                    strSQLTmp = strSQL
                    strQStringTmp = strQString
                    While intCurPos <= lngNORs - 1
                        strItemIDs = ""
                        For intCount = intCurPos To intCurPos + 99
                            If intCount > lngNORs - 1 Then
                                Exit For
                            End If
                            strItemIDs = strItemIDs & arrItemID(intCount) & ","
                        Next
                        strItemIDs = Left(strItemIDs, Len(strItemIDs) - 1)
                        objBIDXGroup.IDs = CStr(intIDXID)
                        objBIDXGroup.ItemIDs = strItemIDs
                        objBIDXGroup.NORs = lngNORs
                        objBIDXGroup.Part_Index = intPart_Index
                        objBIDXGroup.Position = intCurPos
                        objBIDXGroup.QString = strQStringTmp
                        objBIDXGroup.SQLDB = strSQLTmp
                        objBIDXGroup.GroupName = strGroupName
                        objBIDXGroup.GroupID = intGroupIDNew
                        objBIDXGroup.IDXDetailInsert()
                        strSQLTmp = ""
                        strQStringTmp = ""
                        intCurPos = intCurPos + 100
                        intPart_Index = intPart_Index + 1
                    End While
                Else
                    For intCount = 0 To UBound(arrItemID)
                        strItemIDs = strItemIDs & arrItemID(intCount) & ","
                    Next
                    strItemIDs = Left(strItemIDs, Len(strItemIDs) - 1)
                    objBIDXGroup.IDs = CStr(intIDXID)
                    objBIDXGroup.ItemIDs = strItemIDs
                    objBIDXGroup.NORs = lngNORs
                    objBIDXGroup.Part_Index = 1
                    objBIDXGroup.Position = intPositionNew
                    objBIDXGroup.QString = strQString
                    objBIDXGroup.SQLDB = strSQL
                    objBIDXGroup.GroupName = strGroupName
                    objBIDXGroup.GroupID = intGroupIDNew
                    objBIDXGroup.IDXDetailInsert()
                End If
                idxUpdate = lngNORs
            Else
                idxUpdate = 0
                Exit Function
            End If
            ' update LastDateUpdate
            objBIDX.IDs = CStr(intIDXID)
            objBIDX.Title = ""
            objBIDX.TORsAdd = 0
            objBIDX.GroupBy = ""
            objBIDX.IDXUpdate()
        End Function

        ' Release resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                ' Release unmanaged resources.
                If Not objBComDBSys Is Nothing Then
                    objBComDBSys.Dispose(True)
                    objBComDBSys = Nothing
                End If
                If Not objBString Is Nothing Then
                    objBString.Dispose(True)
                    objBString = Nothing
                End If
                If Not objBIDXGroup Is Nothing Then
                    objBIDXGroup.Dispose(True)
                    objBIDXGroup = Nothing
                End If
                If Not objBIDX Is Nothing Then
                    objBIDX.Dispose(True)
                    objBIDX = Nothing
                End If
                If Not objBCataLib Is Nothing Then
                    objBCataLib.Dispose(True)
                    objBCataLib = Nothing
                End If
                If Not objBFormSQL Is Nothing Then
                    objBFormSQL.Dispose(True)
                    objBFormSQL = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace