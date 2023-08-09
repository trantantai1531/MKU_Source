Imports System
Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibOPAC.DataAccess.OPAC
Namespace eMicLibOPAC.BusinessRules.OPAC
    Public Class clsBOPACHelp
        Inherits clsBBase
        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private objDHelp As New clsDOPACHelp
        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        '----
        Private strFileURL As String = ""
        Private strHelpTitle As String = ""
        Private intParentID As Integer = 0
        Private strHelpContent As String = ""
        Private strAccessContent As String = ""
        Private strItemLinkID As String = ""
        Private intCatDicID As Integer = 0
        Private strCatDicID As String = ""
        Private strNotSelectCatDicID As String = ""
        Private inttype As Integer = 0
        Private blnRoot As Integer = 0
        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************
        'file URL help name 
        Public Property FileURL() As String
            Get
                Return strFileURL
            End Get
            Set(ByVal Value As String)
                strFileURL = Value
            End Set
        End Property
        'Title help
        Public Property HelpTitle() As String
            Get
                Return strHelpTitle
            End Get
            Set(ByVal Value As String)
                strHelpTitle = Value
            End Set
        End Property
        'parentID
        Public Property ParentID() As Integer
            Get
                Return intParentID
            End Get
            Set(ByVal Value As Integer)
                intParentID = Value
            End Set
        End Property
        'Help content        
        Public Property HelpContent() As String
            Get
                Return strHelpContent
            End Get
            Set(ByVal Value As String)
                strHelpContent = Value
            End Set
        End Property
        ' help content reject all HTML tag
        Public Property AccessContent() As String
            Get
                Return strAccessContent
            End Get
            Set(ByVal Value As String)
                strAccessContent = Value
            End Set
        End Property
        ' all Help ID link and separate by ","
        Public Property ItemLinkID() As String
            Get
                Return strItemLinkID
            End Get
            Set(ByVal Value As String)
                strItemLinkID = Value
            End Set
        End Property
        '--Help CatDic ID
        Public Property CatDicID() As Integer
            Get
                Return intCatDicID
            End Get
            Set(ByVal Value As Integer)
                intCatDicID = Value
            End Set
        End Property
        '--list help CatDic ID
        Public Property ListCatDicID() As String
            Get
                Return strCatDicID
            End Get
            Set(ByVal Value As String)
                strCatDicID = Value
            End Set
        End Property
        '--list not select help CatDic ID
        Public Property NotSelectCatDicID() As String
            Get
                Return strNotSelectCatDicID
            End Get
            Set(ByVal Value As String)
                strNotSelectCatDicID = Value
            End Set
        End Property
        '--IsRoot
        Public Property Root() As Integer
            Get
                Return blnRoot
            End Get
            Set(ByVal Value As Integer)
                blnRoot = Value
            End Set
        End Property
        '--Type
        Public Property Type() As Integer
            Get
                Return inttype
            End Get
            Set(ByVal Value As Integer)
                inttype = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************
        ' Initialize method
        Public Sub Initialize()
            ' Init objDHoldingCollection object
            objDHelp.DBServer = strDBServer
            objDHelp.ConnectionString = strConnectionString
            objDHelp.Initialize()

            ' Init objBCSP object
            objBCSP.DBServer = strDBServer
            objBCSP.ConnectionString = strConnectionString
            objBCSP.InterfaceLanguage = strInterfaceLanguage
            objBCSP.Initialize()

            ' Init objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.Initialize()
        End Sub

        Public Function GetInforSearch() As DataTable
            Try
                objDHelp.AccessContent = strAccessContent
                objDHelp.HelpTitle = strHelpTitle
                objDHelp.type = inttype

                GetInforSearch = objDHelp.GetInforSearch
            Catch ex As Exception

            End Try
        End Function

        Public Function GetRootDic() As DataTable
            Try
                objDHelp.SQL = "Select * from HELP_CAT_DIC where Root=" & blnRoot & " And Type=" & inttype
                GetRootDic = objDHelp.GetInfor()
            Catch ex As Exception

            End Try
        End Function

        Public Function DeleteHelp() As Boolean
            Try
                Dim dtFile As New DataTable

                objDHelp.ParentID = intCatDicID
                objDHelp.ListCatDicID = intCatDicID
                objDHelp.NotSelectCatDicID = ""
                If objDHelp.GetHepCatDicByID.Rows(0).Item("Level") = 0 Then
                    Return False
                End If
                If objDHelp.GetHepCatDicByParentID.Rows.Count > 0 Then
                    Return False
                Else
                    objDHelp.CatDicID = intCatDicID
                    DeleteHelp = objDHelp.DeleteHelp
                    Return True
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function UpdateHelp() As Integer
            Try
                Dim arrFile() As String
                Dim dtFile As New DataTable
                Dim i, j As Integer
                '--CheckUpdate
                If intParentID = intCatDicID Then
                    Return 1
                    Exit Function
                End If
                If strFileURL.Length > 0 Then
                    arrFile = strFileURL.Split(",")
                    For i = 0 To arrFile.Length - 1
                        objDHelp.FileURL = arrFile(i)
                        dtFile = objDHelp.GetHepCatFileByURL
                        If dtFile.Rows.Count > 1 Then
                            Return 2
                            Exit Function
                        End If
                        If dtFile.Rows.Count > 0 Then
                            If dtFile.Rows(0).Item("CatDicID") <> intCatDicID Then
                                Return 2
                                Exit Function
                            End If
                        End If
                    Next
                End If
                '--Update
                objDHelp.CatDicID = intCatDicID
                objDHelp.FileURL = strFileURL
                objDHelp.HelpTitle = strHelpTitle
                objDHelp.ParentID = intParentID
                objDHelp.HelpContent = strHelpContent
                objDHelp.AccessContent = strAccessContent
                objDHelp.ItemLinkID = strItemLinkID
                objDHelp.type = inttype
                UpdateHelp = objDHelp.UpdatetHelp
                Return 0
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function InsertHelp() As Integer
            Dim arrFile() As String
            Dim i, j As Integer
            ' Try
            If strFileURL <> "" Then
                arrFile = strFileURL.Split(",")
                For i = 0 To arrFile.Length - 1
                    objDHelp.FileURL = arrFile(i)
                    If objDHelp.GetHepCatFileByURL.Rows.Count > 0 Then
                        Return 1
                        Exit For
                    End If
                Next
            End If
            objDHelp.FileURL = strFileURL
            objDHelp.HelpTitle = strHelpTitle
            objDHelp.ParentID = intParentID
            objDHelp.HelpContent = strHelpContent
            objDHelp.AccessContent = strAccessContent
            objDHelp.ItemLinkID = strItemLinkID
            objDHelp.type = inttype
            InsertHelp = objDHelp.InsertHelp
            'Me.ErrorCode = objDHelp.ErrorCode
            'Me.ErrorMsg = objDHelp.ErrorMsg
            Return 0
            'Catch ex As Exception
            '    strErrorMsg = ex.Message
            'End Try
        End Function

        Public Sub GetAllChildHepDicByParentID(ByVal intType As Integer, ByVal intParentID As Integer, ByRef dtSave As DataTable)
            Dim dtTemp As New DataTable
            Dim dtQ As New DataTable
            Dim drTemp As DataRow
            Dim i As Integer
            Try
                If IsNothing(dtSave) Then '--Add parent
                    objDHelp.type = intType
                    objDHelp.ListCatDicID = intParentID
                    objDHelp.NotSelectCatDicID = ""
                    dtSave = objDHelp.GetHepCatDicByID
                End If '--Add children
                objDHelp.ParentID = intParentID
                dtTemp = objDHelp.GetHepCatDicByParentID
                If dtTemp.Rows.Count > 0 Then
                    For i = 0 To dtTemp.Rows.Count - 1
                        dtSave.ImportRow(dtTemp.Rows(i))
                    Next
                    'For Each drTemp In dtTemp.Rows
                    '    GetAllChildHepDicByParentID(drTemp.Item("ID"), dtSave)
                    'Next
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Function GetHepCatDicByParentID() As DataTable
            Try
                objDHelp.ParentID = intParentID
                GetHepCatDicByParentID = objDHelp.GetHepCatDicByParentID
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetHepCatDicByID() As DataTable
            Try
                If IsNothing(strCatDicID) Then strCatDicID = ""
                If IsNothing(NotSelectCatDicID) Then NotSelectCatDicID = ""
                objDHelp.ListCatDicID = strCatDicID
                objDHelp.NotSelectCatDicID = strNotSelectCatDicID
                objDHelp.type = inttype
                GetHepCatDicByID = objDHelp.GetHepCatDicByID

            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetHepDicItemByID() As DataTable
            Try
                objDHelp.CatDicID = intCatDicID
                GetHepDicItemByID = objDHelp.GetHepDicItemByID
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetHepItemLinkByID() As DataTable
            Try
                objDHelp.CatDicID = intCatDicID
                GetHepItemLinkByID = objDHelp.GetHepItemLinkByID
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetHepCatFileByURL() As DataTable
            Try
                If IsNothing(strFileURL) Then strFileURL = ""
                objDHelp.FileURL = strFileURL
                GetHepCatFileByURL = objDHelp.GetHepCatFileByURL
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetHepCatFileByDicID() As DataTable
            Try
                objDHelp.CatDicID = intCatDicID
                GetHepCatFileByDicID = objDHelp.GetHepCatFileByDicID
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function
        'Dispose method
        'Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                End If
                If Not objBCSP Is Nothing Then
                    Call objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    Call objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Dispose()
            End Try
        End Sub
    End Class
End Namespace
