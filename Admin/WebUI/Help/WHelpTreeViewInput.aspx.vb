' Purpose: Manage HelpInfor
' Creator: thaott
' Created Date: 30/Aug/2006
' Modification History: 
Imports eMicLibAdmin.BusinessRules
Namespace eMicLibAdmin.WebUI
    Partial Class WHelpTreeViewInput
        Inherits clsWHelpBase

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
        Private objBHelp As New clsBHelp
        Private intType As String
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim intparentID As Integer
            Dim intlevel As Integer
            Dim intTypeHelp As Integer
            intTypeHelp = 0
            intparentID = 0
            intlevel = 1
            intType = Request.QueryString("Type")
            If intType = "" Then intType = 0
            Call Initialize()
            Call BindScript()
            Call ShowTreeView(intparentID, intlevel, intTypeHelp)
        End Sub

        ' Initialize method
        ' Purpose: Init all neccessary objects
        Private Sub Initialize()
            ' Init objBHoldingInfo object
            objBHelp.InterfaceLanguage = Session("InterfaceLanguage")
            objBHelp.DBServer = Session("DBServer")
            objBHelp.ConnectionString = Session("ConnectionString")
            Call objBHelp.Initialize()
        End Sub

        ' BindScript method
        ' Purpose: Include all neccessary javascript functions
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("UaJs", "<script language = 'javascript' src = 'TreeView/ua.js'></script>")
            Page.RegisterClientScriptBlock("FtiensJs", "<script language = 'javascript' src = 'TreeView/ftiens4.js'></script>")
        End Sub
        '
        ' Name: ShowTreeView
        ' Purpose: Show tree view
        ' Input: intParentID,intLevel
        ' Creator: thaott
        ' Created Date: 30/Aug/2006
        ' Modification History: 
        Private Sub ShowTreeView(ByVal intParentID As Integer, ByVal intLevel As Integer, ByVal intTypeHelp As Integer)
            Dim strJs As String
            Dim strBuiltTree As String
            Dim strTemp As String
            Dim dtTemp As New DataTable
            Dim strRoot As String
            ' Build treeview by javascript code
            strJs = strJs & "<!--" & Chr(10)
            strJs = strJs & "USETEXTLINKS = 1  //replace 0 with 1 for hyperlinks" & Chr(10)
            strJs = strJs & "STARTALLOPEN = 0 //replace 0 with 1 to show the whole tree" & Chr(10)
            strJs = strJs & "HIGHLIGHT = 1" & Chr(10)
            strJs = strJs & "ICONPATH = ""TreeView/""" & Chr(10)
            Call Initialize()
            objBHelp.Root = 1
            objBHelp.Type = Session("HelpLibolType")
            dtTemp = objBHelp.GetRootDic
            If dtTemp.Rows.Count > 0 Then
                intParentID = dtTemp.Rows(0).Item("ID")
                strRoot = dtTemp.Rows(0).Item("HelpTitle")
                strJs = strJs & "foldersTree = gFldSystemRoot('<b>" & strRoot & "</b>', '')" & Chr(10)
            Else
                strJs = strJs & "foldersTree = gFldSystemRoot('<b>Trợ giúp</b>', '')" & Chr(10)
            End If
            If intType = 0 Then ' Build tree selecl item link
                strBuiltTree = strBuiltTree & BuildLocationTree("WHelpInputDetail.aspx", "right", intParentID, intLevel) & Chr(10)
            End If
            If intType = 1 Then ' Buid tree input help
                strBuiltTree = strBuiltTree & BuildLocationTree("WHelpItemLink.aspx", "linkright", intParentID, intLevel) & Chr(10)
            End If
            If intType = 3 Then ' Buid tree view help
                strBuiltTree = strBuiltTree & BuildLocationTree("WHelpOverViewDetail.aspx", "right", intParentID, intLevel) & Chr(10)
            End If
            strJs = strJs & strBuiltTree
            strJs = strJs & "//-->" & Chr(10)
            Page.RegisterClientScriptBlock("LoadTreeViewJs" & intType, "<script language = ""javascript"" type=""text/JavaScript"">" & strJs & "</script>")
            'Page.RegisterClientScriptBlock("LoadRightEdit", "<script language = ""javascript"" type=""text/JavaScript"">parent.right.location.href='WHelpInputDetail.aspx?DicID=1';</script>")
            Session("ParentID") = intParentID
        End Sub
        '
        ' Name: BuildLocationTree
        ' Purpose: Buid location tree view
        ' Input: intParentID,intLevel,strURL,
        ' Creator: thaott
        ' Created Date: 30/Aug/2006
        ' Modification History: 
        Private Function BuildLocationTree(ByVal strURLDefault As String, ByVal frameName As String, ByVal intParentID As Integer, ByVal intLevel As Integer) As String
            Dim tblLib As New DataTable
            Dim intCount As Integer
            Dim strTree As String
            Dim intDepth As Integer
            Dim intj As Integer
            Dim intk As Integer
            Dim strShelf As String = ""
            Dim strURL As String = ""
            Dim bytMode As Byte
            Dim arrChildID() As Integer
            objBHelp.ParentID = intParentID
            tblLib = objBHelp.GetHepCatDicByParentID
            If Not tblLib Is Nothing Then
                ReDim arrChildID(tblLib.Rows.Count - 1)
                For intCount = 0 To tblLib.Rows.Count - 1
                    strURL = strURLDefault & "?DicID=" & tblLib.Rows(intCount).Item("ID")
                    If intLevel = 1 Then
                        strTree = strTree & "aux" & intLevel & " = insFld(foldersTree, gFld('" & tblLib.Rows(intCount).Item("HelpTitle") & "', '" & strURL & "'))" & Chr(10)
                    Else
                        strTree = strTree & "aux" & intLevel & " = insFld(aux" & intLevel - 1 & ", gFld('" & tblLib.Rows(intCount).Item("HelpTitle") & "', '" & strURL & "'))" & Chr(10)
                    End If
                    strTree = strTree & "aux" & intLevel & ".iconSrc = ICONPATH + 'ftv2folderopen.gif'" & Chr(10)
                    strTree = strTree & "aux" & intLevel & ".iconSrcClosed = ICONPATH + 'ftv2folderclosed.gif'" & Chr(10)
                    strTree = strTree & "aux" & intLevel & ".targetFrame = """ & frameName & """" & Chr(10)
                    strTree = strTree & BuildLocationTree(strURLDefault, frameName, tblLib.Rows(intCount).Item("ID"), intLevel + 1)
                Next
            End If
            Return strTree
        End Function
    End Class
End Namespace
