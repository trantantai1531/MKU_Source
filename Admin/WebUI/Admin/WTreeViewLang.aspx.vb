' Class: WTreeViewLang
' Puspose: 
' Creator: Tuanhv
' CreatedDate: 10/05/2005
' Modification History:

Imports eMicLibAdmin.BusinessRules.Admin
Imports System.IO

Namespace eMicLibAdmin.WebUI.Admin
    Partial Class WTreeViewLang
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
        Dim strJs As String = ""
        Dim strBuiltTree As String = ""

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Session("UserID") = 1 Then
                Call WriteErrorMssg(ddlLabel.Items(1).Text)
            End If
            Call BindScript()
            If Not Page.IsPostBack Then
                Call ShowTreeView()
            End If
        End Sub

        ' BindScript method
        ' Purpose: Include all neccessary javascript functions
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("UaJs", "<script language = 'javascript' src = '../Js/TreeView/ua.js'></script>")
            Page.RegisterClientScriptBlock("FtiensJs", "<script language = 'javascript' src = '../Js/TreeView/ftiens4.js'></script>")
        End Sub

        ' ShowTreeView method
        ' Purpose: show treeview
        Private Sub ShowTreeView()
            Dim arrRootFolders() As Object
            Dim arrRootNodes() As Object
            Dim intIndex As Integer

            ' Build treeview by javascript code
            strJs = strJs & "<!--" & Chr(10)
            strJs = strJs & "USETEXTLINKS = 1  //replace 0 with 1 for hyperlinks" & Chr(10)
            strJs = strJs & "STARTALLOPEN = 0 //replace 0 with 1 to show the whole tree" & Chr(10)
            strJs = strJs & "HIGHLIGHT = 1" & Chr(10)
            strJs = strJs & "ICONPATH = ""../Js/TreeView/""" & Chr(10)
            strJs = strJs & "foldersTree = gFld('<b>" & ddlLabel.Items(0).Text & "</b>', '')" & Chr(10)

            strBuiltTree = strBuiltTree & BuildDirectoryTree(Server.MapPath("~/Resources/LabelString"), 0, ddlLabel.Items(2).Text) & Chr(10)
            strBuiltTree = strBuiltTree & BuildDirectoryTree(Server.MapPath("~/Resources/LabelString"), 0, ddlLabel.Items(3).Text) & Chr(10)

            strJs = strJs & strBuiltTree
            strJs = strJs & "//-->" & Chr(10)

            Page.RegisterClientScriptBlock("LoadTreeViewJs", "<script language = ""javascript"" type=""text/JavaScript"">" & strJs & "</script>")
        End Sub

        ' BuildDirectoryTree method
        ' Purpose: Build directory tree
        Protected Function BuildDirectoryTree(Optional ByVal strPath As String = "", Optional ByVal intDepth As Integer = 0, Optional ByVal strTitleRoot As String = "") As String
            Dim blnFound As Boolean = False
            Dim intIndex As Integer
            Dim strTree = Chr(10)

            Dim objDirInfor As DirectoryInfo = New DirectoryInfo(strPath)
            Dim objFileInfor As FileInfo

            ' Add js for this directory
            If intDepth = 0 Then
                strTree = strTree & "aux" & intDepth + 1 & " = insFld(foldersTree, gFld('" & strTitleRoot & "', 'WViewFileXml.aspx?FormID=" & Replace(strPath, "\", "\\") & "'))" & Chr(10)
                strTree = strTree & "aux" & intDepth + 1 & ".iconSrc = ICONPATH + 'ftv2folderopen.gif'" & Chr(10)
                strTree = strTree & "aux" & intDepth + 1 & ".iconSrcClosed = ICONPATH + 'ftv2folderclosed.gif'" & Chr(10)
                strTree = strTree & "aux" & intDepth + 1 & ".targetFrame = ""main""" & Chr(10)
            Else
                strTree = strTree & "aux" & intDepth + 1 & " = insFld(aux" & intDepth & ", gFld('" & objDirInfor.Name & "', 'WViewFileXml.aspx?FormID=" & Replace(strPath, "\", "\\") & "'))" & Chr(10)
                strTree = strTree & "aux" & intDepth + 1 & ".iconSrc = ICONPATH + 'ftv2folderopen.gif'" & Chr(10)
                strTree = strTree & "aux" & intDepth + 1 & ".iconSrcClosed = ICONPATH + 'ftv2folderclosed.gif'" & Chr(10)
                strTree = strTree & "aux" & intDepth + 1 & ".targetFrame = ""main""" & Chr(10)
            End If

            Dim strFileName As String
            Dim strFilePath As String
            Dim intCount As Integer = 0

            ' Build tree by recursively calling this same function
            Dim subDir As DirectoryInfo
            Dim dtrow() As DataRow
            For Each subDir In objDirInfor.GetDirectories
                strTree = strTree & BuildDirectoryTree(strPath & "\" & subDir.Name, intDepth + 1)
            Next

            BuildDirectoryTree = strTree
        End Function
    End Class
End Namespace

