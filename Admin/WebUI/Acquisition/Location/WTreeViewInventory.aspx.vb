' Class: WTreeViewInventory
' Puspose: show treeview for Loaction
' Creator: tuanhv
' CreatedDate: 28/3/2005
' Modification history:
'   - 13/04/2005 by Oanhtn: review & update

Imports eMicLibAdmin.WebUI.Acquisition
Imports eMicLibAdmin.BusinessRules.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WTreeViewInventory
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub


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
            Call CheckFormPermission()
            Call Initialize()
            Call BindScript()
            Call ShowTreeView()
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(179) AndAlso Not CheckPemission(117) Then
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub

        ' Method: Initialize
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

        ' Method: ShowTreeView
        ' Purpose: Show need treeview
        Private Sub ShowTreeView()
            Dim strJs As String
            Dim strBuiltTree As String

            ' Build treeview by javascript code
            strJs = strJs & "<!--" & Chr(10)
            strJs = strJs & "USETEXTLINKS = 1  //replace 0 with 1 for hyperlinks" & Chr(10)
            strJs = strJs & "STARTALLOPEN = 0 //replace 0 with 1 to show the whole tree" & Chr(10)
            strJs = strJs & "HIGHLIGHT = 1" & Chr(10)

            strJs = strJs & "ICONPATH = ""../../Js/TreeView/""" & Chr(10)
            strJs = strJs & "foldersTree = gFldSystemRoot('<b>" & lblRoot.Text & "</b>', '')" & Chr(10)
            strBuiltTree = BuildLocationTree() & Chr(10)

            strJs = strJs & strBuiltTree
            strJs = strJs & "//-->" & Chr(10)

            Page.RegisterClientScriptBlock("LoadTreeViewJs", "<script language = ""javascript"" type=""text/JavaScript"">" & strJs & "</script>")
        End Sub

        ' Method: BuildLocationTree
        ' Purpose: build location treeview
        Private Function BuildLocationTree() As String
            Dim tblLib As New DataTable
            Dim tblLoc As New DataTable
            Dim tblShelf As New DataTable
            Dim intCount As Integer
            Dim strTree As String
            Dim intDepth As Integer
            Dim intj As Integer
            Dim intk As Integer
            Dim strShelf As String = ""
            Dim strURL As String = ""
            Dim strURLDefault As String = ""
            Dim bytMode As Byte

            strURLDefault = "WViewLiq.aspx"

            ' set permission for user
            objBLib.UserID = Session("UserID")
            objBLoc.LibID = 0
            objBLib.LibID = clsSession.GlbSite
            If CheckPemission(179) Then ' Xem ket qua nhieu ky kiem ke
                tblLib = objBLib.GetLibrary
            Else                        ' Xem va dong ky kiem ke
                tblLib = objBLib.GetLibrary(0, -1, 1)
            End If
            If Not tblLib Is Nothing Then
                For intCount = 1 To tblLib.Rows.Count
                    ' bind js for Library
                    If Not IsDBNull(tblLib.Rows(intCount - 1).Item("Code")) Then
                        strURL = strURLDefault & "?LibID=" & tblLib.Rows(intCount - 1).Item("ID")
                        strTree = strTree & "aux1 = insFld(foldersTree, gFld('" & Trim(tblLib.Rows(intCount - 1).Item("Code") & "") & "', '" & strURL & "'))" & Chr(10)
                        strTree = strTree & "aux1.iconSrc = ICONPATH + 'ftv2folderopen.gif'" & Chr(10)
                        strTree = strTree & "aux1.iconSrcClosed = ICONPATH + 'ftv2folderclosed.gif'" & Chr(10)
                        strTree = strTree & "aux1.targetFrame = ""main""" & Chr(10)
                    End If

                    objBLoc.LibID = tblLib.Rows(intCount - 1).Item("ID")
                    objBLoc.LocID = 0
                    If CheckPemission(179) Then
                        objBLoc.Status = -1
                    Else
                        objBLoc.Status = 0
                    End If
                    tblLoc = objBLoc.GetLocation
                    If Not tblLoc Is Nothing Then
                        For intj = 1 To tblLoc.Rows.Count
                            ' bind js for Location
                            strURL = strURLDefault & "?LibID=" & tblLib.Rows(intCount - 1).Item("ID") & "&LocID=" & tblLoc.Rows(intj - 1).Item("ID")
                            strTree = strTree & "aux2 = insFld(aux1, gFld('" & tblLoc.Rows(intj - 1).Item("Symbol") & "', '" & strURL & "'))" & Chr(10)
                            strTree = strTree & "aux2.iconSrc = ICONPATH + 'kho.gif'" & Chr(10)
                            strTree = strTree & "aux2.iconSrcClosed = ICONPATH + 'kho.gif'" & Chr(10)
                            strTree = strTree & "aux2.targetFrame = ""main""" & Chr(10)

                            ' only view shelf in (receive and inventory)
                            objBLoc.LocID = tblLoc.Rows(intj - 1).Item("ID")
                            tblShelf = objBLoc.GetShelf
                            If Not tblShelf Is Nothing Then
                                For intk = 1 To tblShelf.Rows.Count
                                    ' bind js for Shelf
                                    strURL = strURLDefault & "?LibID=" & tblLib.Rows(intCount - 1).Item("ID") & "&LocID=" & tblLoc.Rows(intj - 1).Item("ID")
                                    If tblShelf.Rows(intk - 1).Item("Shelf") & "" = "" Then
                                        strShelf = lblNoName.Text
                                        strURL = strURL & "&shelf=noname"
                                    Else
                                        strShelf = tblShelf.Rows(intk - 1).Item("Shelf")
                                        strURL = strURL & "&shelf=" & strShelf
                                    End If
                                    strTree = strTree & "aux3 = insFld(aux2, gFld('" & strShelf & "', '" & strURL & "'))" & Chr(10)
                                    strTree = strTree & "aux3.iconSrc = ICONPATH + 'gia.gif'" & Chr(10)
                                    strTree = strTree & "aux3.iconSrcClosed = ICONPATH + 'gia.gif'" & Chr(10)
                                    strTree = strTree & "aux3.targetFrame = ""main""" & Chr(10)
                                Next
                                tblShelf.Clear()
                            End If
                        Next
                        tblLoc.Clear()
                    End If
                Next
            End If
            Return strTree
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
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace