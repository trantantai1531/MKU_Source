Imports System.IO
Imports eMicLibAdmin.WebUI.Acquisition
Imports eMicLibAdmin.BusinessRules.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WLocTreeView
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblRoot As System.Web.UI.WebControls.Label
        Protected WithEvents lblNoName As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBLib As New clsBLibrary
        Private objBLoc As New clsBLocation
        Private objBCopyNumber As New clsBCopyNumber

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
            Call ShowTreeView()
        End Sub

        ' Initialize method
        ' Purpose: Init all neccessary objects
        Private Sub Initialize()
            ' Init for objBLib
            objBLib.InterfaceLanguage = Session("InterfaceLanguage")
            objBLib.DBServer = Session("DBServer")
            objBLib.ConnectionString = Session("ConnectionString")
            objBLib.Initialize()

            ' Init for objBLoc
            objBLoc.InterfaceLanguage = Session("InterfaceLanguage")
            objBLoc.DBServer = Session("DBServer")
            objBLoc.ConnectionString = Session("ConnectionString")
            objBLoc.Initialize()

            ' Init for objBCopyNumber
            objBCopyNumber.InterfaceLanguage = Session("InterfaceLanguage")
            objBCopyNumber.DBServer = Session("DBServer")
            objBCopyNumber.ConnectionString = Session("ConnectionString")
            objBCopyNumber.Initialize()
        End Sub

        ' BindScript method
        ' Purpose: Include all neccessary javascript functions
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("UaJs", "<script language = 'javascript' src = '../../Js/TreeView/ua.js'></script>")
            Page.RegisterClientScriptBlock("FtiensJs", "<script language = 'javascript' src = '../../Js/TreeView/ftiens4.js'></script>")
        End Sub

        Private Sub ShowTreeView()
            Dim strJs As String = ""
            Dim strBuiltTree As String = ""

            ' Build treeview by javascript code
            strJs = strJs & "<!--" & Chr(10)
            strJs = strJs & "USETEXTLINKS = 1  //replace 0 with 1 for hyperlinks" & Chr(10)
            strJs = strJs & "STARTALLOPEN = 0 //replace 0 with 1 to show the whole tree" & Chr(10)
            strJs = strJs & "HIGHLIGHT = 1" & Chr(10)
            strJs = strJs & "ICONPATH = ""../../Js/TreeView/""" & Chr(10)
            strJs = strJs & "foldersTree = gFldSystemRoot('<b>" & ddlLabel.Items(2).Text & "</b>', '')" & Chr(10)

            strBuiltTree = strBuiltTree & BuildLocationTree() & Chr(10)

            strJs = strJs & strBuiltTree
            strJs = strJs & "//-->" & Chr(10)

            Page.RegisterClientScriptBlock("LoadTreeViewJs", "<script language = ""javascript"" type=""text/JavaScript"">" & strJs & "</script>")
        End Sub

        ' Method: BuildLocationTree
        ' Purpose: build need treeview
        Private Function BuildLocationTree() As String
            Dim tblLib As New DataTable
            Dim tblLoc As New DataTable
            Dim tblShelf As New DataTable
            Dim intCount As Integer
            Dim strTree As String = ""
            Dim intDepth As Integer = 0
            Dim intj As Integer
            Dim intk As Integer
            Dim strShelf As String = ""
            Dim strURL As String = ""
            Dim strURLDefault As String = ""
            Dim bytMode As Byte

            bytMode = Request.QueryString("Mode")
            Select Case bytMode
                Case 0 ' Xep gia chua kiem nhan
                    strURLDefault = "WProcReceive.aspx"
                Case 2 ' Xep gia Da thanh ly/mat
                    strURLDefault = "WProcLost.aspx"
                Case Else '1 Xep gia trong kho
                    strURLDefault = "WProcInventory.aspx"
            End Select

            ' set permission for user
            objBLib.UserID = Session("UserID")
            objBLib.LibID = clsSession.GlbSite
            objBLoc.UserID = Session("UserID")
            objBLoc.LibID = 0
            tblLib = objBLib.GetLibrary(1, 1)
            If Not tblLib Is Nothing Then
                For intCount = 1 To tblLib.Rows.Count
                    ' bind js for Library
                    strURL = strURLDefault & "?LibID=" & tblLib.Rows(intCount - 1).Item("ID")
                    If bytMode <> 0 Then
                        strTree = strTree & "aux1 = insFld(foldersTree, gFld('" & tblLib.Rows(intCount - 1).Item("Code") & "', '" & strURL & "'))" & Chr(10)
                    Else
                        strTree = strTree & "aux1 = insFld(foldersTree, gFld('" & tblLib.Rows(intCount - 1).Item("Code") & "(<b><font color=""red"">" & SearchSumCN(tblLib.Rows(intCount - 1).Item("ID"), 0) & "</font></b>)', ''))" & Chr(10)
                    End If
                    strTree = strTree & "aux1.iconSrc = ICONPATH + 'ftv2folderopen.gif'" & Chr(10)
                    strTree = strTree & "aux1.iconSrcClosed = ICONPATH + 'ftv2folderclosed.gif'" & Chr(10)
                    strTree = strTree & "aux1.targetFrame = ""display""" & Chr(10)
                    objBLoc.LibID = tblLib.Rows(intCount - 1).Item("ID")
                    objBLoc.LocID = 0
                    'QuocDD load tat ca cac kho
                    objBLoc.Status = -1
                    tblLoc = objBLoc.GetLocation
                    If Not tblLoc Is Nothing Then
                        For intj = 1 To tblLoc.Rows.Count
                            ' bind js for Location
                            strURL = strURLDefault & "?LibID=" & tblLib.Rows(intCount - 1).Item("ID") & "&LocID=" & tblLoc.Rows(intj - 1).Item("ID")
                            If bytMode <> 0 Then
                                strTree = strTree & "aux2 = insFld(aux1, gFld('" & tblLoc.Rows(intj - 1).Item("Symbol") & "', '" & strURL & "'))" & Chr(10)
                            Else
                                strTree = strTree & "aux2 = insFld(aux1, gFld('" & tblLoc.Rows(intj - 1).Item("Symbol") & "(<b><font color=""red"">" & SearchSumCN(tblLib.Rows(intCount - 1).Item("ID"), tblLoc.Rows(intj - 1).Item("ID")) & "</font></b>)', '" & strURL & "'))" & Chr(10)
                                'strTree = strTree & "aux2 = insFld(aux1, gFld('" & tblLoc.Rows(intj - 1).Item("Symbol") & "', '" & strURL & "'))" & Chr(10)
                            End If
                            strTree = strTree & "aux2.iconSrc = ICONPATH + 'kho.gif'" & Chr(10)
                            strTree = strTree & "aux2.iconSrcClosed = ICONPATH + 'kho.gif'" & Chr(10)
                            strTree = strTree & "aux2.targetFrame = ""display""" & Chr(10)

                            ' only view shelf in (receive and inventory)
                            If bytMode <> 0 Then
                                objBLoc.LocID = tblLoc.Rows(intj - 1).Item("ID")
                                tblShelf = objBLoc.GetShelf
                                If Not tblShelf Is Nothing Then
                                    For intk = 1 To tblShelf.Rows.Count
                                        ' bind js for Shelf
                                        strURL = strURLDefault & "?LibID=" & tblLib.Rows(intCount - 1).Item("ID") & "&LocID=" & tblLoc.Rows(intj - 1).Item("ID")
                                        If tblShelf.Rows(intk - 1).Item("Shelf") & "" = "" Then
                                            strShelf = ddlLabel.Items(3).Text
                                            strURL = strURL & "&shelf=noname"
                                        Else
                                            strShelf = tblShelf.Rows(intk - 1).Item("Shelf")
                                            strURL = strURL & "&shelf=" & strShelf
                                        End If
                                        strURL = strURL & "&isStart=ok"
                                        strTree = strTree & "aux3 = insFld(aux2, gFld('" & strShelf & "', '" & strURL & "'))" & Chr(10)
                                        strTree = strTree & "aux3.iconSrc = ICONPATH + 'gia.gif'" & Chr(10)
                                        strTree = strTree & "aux3.iconSrcClosed = ICONPATH + 'gia.gif'" & Chr(10)
                                        strTree = strTree & "aux3.targetFrame = ""display""" & Chr(10)
                                    Next
                                    tblShelf.Clear()
                                End If
                            End If
                        Next
                        tblLoc.Clear()
                    End If
                Next
            End If
            Return strTree
        End Function

        ' Method: SearchSumCN
        ' Purpose: seach copynumbers
        Private Function SearchSumCN(ByVal intLibID As Integer, ByVal intLocID As Integer) As Integer
            Dim intRetVal As Integer

            objBCopyNumber.LibID = intLibID
            objBCopyNumber.LocID = intLocID
            objBCopyNumber.Shelf = ""
            'objBCopyNumber.Shelf = "noname"

            ' Search not receive
            intRetVal = objBCopyNumber.SearchHoldingID(3).Rows(0).Item("Total")
            Return intRetVal
        End Function

        ' Event: Page UnLoad
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBLib Is Nothing Then
                    objBLib.Dispose(True)
                    objBLib = Nothing
                End If
                If Not objBLoc Is Nothing Then
                    objBLoc.Dispose(True)
                    objBLoc = Nothing
                End If
                If Not objBCopyNumber Is Nothing Then
                    objBCopyNumber.Dispose(True)
                    objBCopyNumber = Nothing
                End If
                If Not Session("IDs") Is Nothing Then
                    Session("IDs") = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace