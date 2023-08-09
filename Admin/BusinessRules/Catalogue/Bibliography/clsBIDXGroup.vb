Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.DataAccess
Imports eMicLibAdmin.DataAccess.Catalogue

Namespace eMicLibAdmin.BusinessRules.Catalogue
    Public Class clsBIDXGroup
        Inherits clsBBase

        ' Declare variables
        Private objBString As New clsBCommonStringProc
        Private objBComDBSys As New clsBCommonDBSystem
        Private objDIDXGroup As New clsDIDXGroup

        Private strIDs As String = ""
        Private strItemIDs As String = ""
        Private intNORs As Integer = 0
        Private intPart_Index As Integer = 0
        Private intPosition As Integer = 0
        Private strQString As String = ""
        Private strSQLDB As String = ""
        Private strGroupName As String = ""
        Private intGroupID As Integer = 0

        ' IDs property
        Public Property IDs() As String
            Get
                Return strIDs
            End Get
            Set(ByVal Value As String)
                strIDs = Value
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

        ' NORs property
        Public Property NORs() As Integer
            Get
                Return intNORs
            End Get
            Set(ByVal Value As Integer)
                intNORs = Value
            End Set
        End Property

        ' QString property
        Public Property QString() As String
            Get
                Return strQString
            End Get
            Set(ByVal Value As String)
                strQString = Value
            End Set
        End Property

        ' GroupID property
        Public Property GroupID() As Integer
            Get
                Return intGroupID
            End Get
            Set(ByVal Value As Integer)
                intGroupID = Value
            End Set
        End Property

        ' GroupName property
        Public Property GroupName() As String
            Get
                Return strGroupName
            End Get
            Set(ByVal Value As String)
                strGroupName = Value
            End Set
        End Property

        ' SQLDB property
        Public Property SQLDB() As String
            Get
                Return strSQLDB
            End Get
            Set(ByVal Value As String)
                strSQLDB = Value
            End Set
        End Property

        ' Position property
        Public Property Position() As Integer
            Get
                Return intPosition
            End Get
            Set(ByVal Value As Integer)
                intPosition = Value
            End Set
        End Property

        ' Part_Index property
        Public Property Part_Index() As Integer
            Get
                Return intPart_Index
            End Get
            Set(ByVal Value As Integer)
                intPart_Index = Value
            End Set
        End Property

        ' Initialize method
        ' Purpose: Init the objects
        Public Sub Initialize()
            objBComDBSys.ConnectionString = strConnectionstring
            objBComDBSys.DBServer = strDBServer
            objBComDBSys.InterfaceLanguage = strInterfaceLanguage
            objBComDBSys.Initialize()

            objDIDXGroup.ConnectionString = strConnectionstring
            objDIDXGroup.DBServer = strDBServer
            objDIDXGroup.Initialize()

            objBString.InterfaceLanguage = strInterfaceLanguage
            objBString.ConnectionString = strConnectionstring
            objBString.DBServer = strDBServer
            objBString.Initialize()
        End Sub

        ' IDXDetailInsert method
        Public Sub IDXDetailInsert()
            Try
                objDIDXGroup.IDs = strIDs
                objDIDXGroup.ItemIDs = strItemIDs
                objDIDXGroup.NORs = intNORs
                objDIDXGroup.Part_Index = intPart_Index
                objDIDXGroup.Position = intPosition
                objDIDXGroup.QString = objBString.ConvertItBack(strQString)
                objDIDXGroup.SQL = objBString.ConvertItBack(strSQLDB)
                objDIDXGroup.GroupName = objBString.ConvertItBack(strGroupName)
                objDIDXGroup.GroupID = intGroupID
                objDIDXGroup.IDXDetailInsert()
                strErrorMsg = objDIDXGroup.ErrorMsg
                intErrorCode = objDIDXGroup.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' IDXDetailDelete method
        Public Sub IDXDetailDelete()
            Try
                objDIDXGroup.IDs = strIDs
                objDIDXGroup.GroupID = intGroupID
                objDIDXGroup.IDXDetailDelete()
                strErrorMsg = objDIDXGroup.ErrorMsg
                intErrorCode = objDIDXGroup.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' IDXDetailRetrieve fucntion
        Public Function IDXDetailRetrieve() As DataTable
            Try
                objDIDXGroup.IDs = strIDs
                objDIDXGroup.GroupID = intGroupID
                objDIDXGroup.LibID = intLibID
                IDXDetailRetrieve = objBComDBSys.ConvertTable(objDIDXGroup.IDXDetailRetrieve())
                strErrorMsg = objDIDXGroup.ErrorMsg
                intErrorCode = objDIDXGroup.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' IDXDetailRetrieveDist function
        Public Function IDXDetailRetrieveDist() As DataTable
            Try
                objDIDXGroup.IDs = strIDs
                objDIDXGroup.GroupID = intGroupID
                IDXDetailRetrieveDist = objBComDBSys.ConvertTable(objDIDXGroup.IDXDetailRetrieveDist())
                strErrorMsg = objDIDXGroup.ErrorMsg
                intErrorCode = objDIDXGroup.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' IDXDetailRetrieveDistLink function
        Public Function IDXDetailRetrieveDistLink() As DataTable
            Try
                objDIDXGroup.IDs = strIDs
                objDIDXGroup.GroupID = intGroupID
                IDXDetailRetrieveDistLink = objBComDBSys.ConvertTable(objDIDXGroup.IDXDetailRetrieveDistLink())
                strErrorMsg = objDIDXGroup.ErrorMsg
                intErrorCode = objDIDXGroup.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' ProcessTable function
        Public Function ProcessTable(ByVal tblScr As DataTable) As DataTable
            Try
                Dim intCount As Integer
                Dim lngSum As Long
                Dim intStart As Integer
                If tblScr.Rows.Count > 0 Then
                    intCount = 0
                    lngSum = tblScr.Rows(intCount).Item("NORs")
                    While intCount < tblScr.Rows.Count - 1
                        If lngSum > 100 Then
                            For intStart = 1 To lngSum \ 100 + 1
                                tblScr.Rows(intCount).Item("strView") = tblScr.Rows(intCount).Item("GroupName") & "(" & tblScr.Rows(intCount).Item("Position") + 1 & "-->"
                                If 100 * intStart > lngSum Then
                                    tblScr.Rows(intCount).Item("strView") = tblScr.Rows(intCount).Item("strView") & lngSum & ")"
                                Else
                                    tblScr.Rows(intCount).Item("strView") = tblScr.Rows(intCount).Item("strView") & 100 * intStart & ")"
                                End If
                                tblScr.Rows(intCount).Item("strViewLink") = "<a href='javascript:ViewGroup(" & tblScr.Rows(intCount).Item("GroupID") & "," & tblScr.Rows(intCount).Item("ID") & ")' class='lblinkFunction'>" & tblScr.Rows(intCount).Item("strView") & "</a>"
                                intCount = intCount + 1
                                If intCount >= tblScr.Rows.Count Then
                                    Exit For
                                End If
                            Next
                        Else
                            tblScr.Rows(intCount).Item("strView") = tblScr.Rows(intCount).Item("GroupName") & " (1 --> " & lngSum & " )"
                            tblScr.Rows(intCount).Item("strViewLink") = "<a href='javascript:ViewGroup(" & tblScr.Rows(intCount).Item("GroupID") & "," & tblScr.Rows(intCount).Item("ID") & ")' class='lblinkFunction'>" & tblScr.Rows(intCount).Item("GroupName") & " (1 --> " & lngSum & " ) </a>"
                            intCount = intCount + 1
                        End If
                        If intCount >= tblScr.Rows.Count Then
                            Exit While
                        End If
                        lngSum = tblScr.Rows(intCount).Item("NORs")
                    End While
                End If
                Return tblScr
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
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
                If Not objDIDXGroup Is Nothing Then
                    objDIDXGroup.Dispose(True)
                    objDIDXGroup = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace