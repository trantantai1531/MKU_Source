' Class: clsWTreeView
' Puspose: show treeview
' Creator: Oanhtn
' CreatedDate: 27/12/2004
' Modification History:

Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.IO
Imports eMicLibAdmin.WebUI.Edeliv
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Edeliv

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class clsWTreeView
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

        Dim objBEData As New clsBEData

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPemission()
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call ShowTreeView(1)
            End If
        End Sub

        ' CheckFormPemission method
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            If Not CheckPemission(166) Then
                Call WriteErrorMssg(ddlLabel.Items(16).Text)
            End If
        End Sub

        ' Initialize method
        ' Purpose: Init all neccessary objects
        Private Sub Initialize()
            ' Init for objBEData
            objBEData.InterfaceLanguage = Session("InterfaceLanguage")
            objBEData.DBServer = Session("DBServer")
            objBEData.ConnectionString = Session("ConnectionString")
            objBEData.Initialize()
        End Sub

        ' BindScript method
        ' Purpose: Include all neccessary javascript functions
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("UaJs", "<script language = 'javascript' src = '../../Js/TreeView/ua.js'></script>")
            Page.RegisterClientScriptBlock("FtiensJs", "<script language = 'javascript' src = '../../Js/TreeView/ftiens4.js'></script>")
            txtSize.Attributes.Add("OnChange", "javascript:return CheckNumBer(this,'" & ddlLabel.Items(15).Text & "')")
        End Sub

        ' ddlEdataView_SelectedIndexChanged event
        Private Sub ddlEdataView_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlEdataView.SelectedIndexChanged
            Call ShowTreeView(ddlEdataView.SelectedValue + 1)
            Page.RegisterClientScriptBlock("LoadDetails", "<script language='javascript'>parent.foldercontents.location.href='WShowDetail.aspx';</script>")
        End Sub

        ' ShowTreeView method
        ' Purpose: show treeview
        Private Sub ShowTreeView(ByVal intType As Integer)
            Dim strStatus() As String = {}
            Dim tblTemp As DataTable
            Dim strRootFolders As String = ","
            Dim arrRootFolders() As Object
            Dim arrRootNodes() As Object
            Dim strFileLocation As String
            Dim intMax As Integer
            Dim intIndex As Integer
            Dim strSysDirs() As String
            TRSearch.Visible = False

            Select Case intType
                Case 1
                    ' View by Directory
                    tblTemp = Nothing
                    Call WriteErrorMssg(ddlLabel.Items(18).Text, objBEData.ErrorMsg, ddlLabel.Items(17).Text, objBEData.ErrorCode)
                    lblScript.Visible = True
                Case 2
                    ' View by Status
                    tblTemp = objBEData.GetDisplayTypes(2)
                    Call WriteErrorMssg(ddlLabel.Items(18).Text, objBEData.ErrorMsg, ddlLabel.Items(17).Text, objBEData.ErrorCode)
                    lblScript.Visible = True
                Case 3
                    ' View by File Type
                    tblTemp = objBEData.GetDisplayTypes(3)
                    Call WriteErrorMssg(ddlLabel.Items(18).Text, objBEData.ErrorMsg, ddlLabel.Items(17).Text, objBEData.ErrorCode)
                    lblScript.Visible = True
                Case 4
                    ' View by Collection
                    tblTemp = objBEData.GetDisplayTypes(4)
                    Call WriteErrorMssg(ddlLabel.Items(18).Text, objBEData.ErrorMsg, ddlLabel.Items(17).Text, objBEData.ErrorCode)
                    lblScript.Visible = True
                Case 5
                    ' Search
                    lblScript.Visible = False
                    tblTemp = Nothing
                    TRSearch.Visible = True
                    Call BindCollection()
            End Select

            If intType = 1 Then
                If Not objSysPara(7) Is Nothing Then
                    If Not objSysPara(7) = "" Then
                        strSysDirs = Split(objSysPara(7).Trim, ";")
                        If Not strSysDirs Is Nothing AndAlso UBound(strSysDirs) > 0 Then
                            For intIndex = 0 To UBound(strSysDirs) - 1
                                If InStr(Replace(strSysDirs(intIndex), "/", "\"), ":\") = 0 Then
                                    strFileLocation = Server.MapPath(strSysDirs(intIndex))
                                Else
                                    strFileLocation = Replace(strSysDirs(intIndex), "/", "\")
                                End If
                                arrRootNodes = Split(strFileLocation, "\")
                                If InStr(strRootFolders.ToUpper, "," & CStr(arrRootNodes(0)).ToUpper & ",") = 0 Then
                                    strRootFolders = strRootFolders & arrRootNodes(0) & ","
                                    ReDim Preserve arrRootFolders(intMax)
                                    arrRootFolders(intMax) = arrRootNodes(0)
                                    intMax = intMax + 1
                                End If
                            Next
                        End If
                    End If
                End If
            End If
            ' Reset intIndex to Ubound(strSysDirs)-1
            intIndex = intIndex - 1
            ' Build treeview by javascript code
            strJs = strJs & "<!--" & Chr(10)
            strJs = strJs & "USETEXTLINKS = 1  //replace 0 with 1 for hyperlinks" & Chr(10)
            strJs = strJs & "STARTALLOPEN = 0 //replace 0 with 1 to show the whole tree" & Chr(10)
            strJs = strJs & "HIGHLIGHT = 1" & Chr(10)
            strJs = strJs & "ICONPATH = ""../../Js/TreeView/""" & Chr(10)
            strJs = strJs & "foldersTree = gFld('<b></b>', '')" & Chr(10)

            If intType = 1 Then
                Dim arrTemp() As String

                If Not arrRootFolders Is Nothing AndAlso UBound(arrRootFolders) >= 0 Then
                    For intIndex = LBound(arrRootFolders) To UBound(arrRootFolders)
                        ReDim Preserve arrTemp(intIndex)
                        arrTemp(intIndex) = (intIndex) & BuildDirectoryTree(1, tblTemp, UCase(arrRootFolders(intIndex)), 0) & Chr(10)
                    Next
                End If

                If Not arrTemp Is Nothing AndAlso UBound(arrTemp) >= 0 Then
                    For intIndex = LBound(arrTemp) To UBound(arrTemp)
                        strBuiltTree = strBuiltTree & arrTemp(intIndex)
                    Next
                End If
            Else
                strBuiltTree = strBuiltTree & BuildDirectoryTree(intType, tblTemp) & Chr(10)
            End If

            strJs = strJs & strBuiltTree
            strJs = strJs & "//-->" & Chr(10)
            Page.RegisterClientScriptBlock("LoadTreeViewJs", "<script language = ""javascript"" type=""text/JavaScript"">" & strJs & "</script>")
        End Sub

        ' BuildDirectoryTree method
        ' Purpose: Build directory tree
        Protected Function BuildDirectoryTree(ByVal intType As Integer, ByVal tblSource As DataTable, Optional ByVal strPath As String = "", Optional ByVal intDepth As Integer = 0) As String
            Dim blnFound As Boolean = False
            Dim intIndex As Integer
            Dim strTree = Chr(10)
            Dim strSysDirs() As String

            If intType = 1 Then
                Dim objDirInfor As DirectoryInfo

                If intDepth = 0 Then
                    objDirInfor = New DirectoryInfo(strPath).Root
                Else
                    objDirInfor = New DirectoryInfo(strPath)
                End If

                ' get the valid dirs
                If Not objSysPara(7).ToString.Trim = "" Then
                    strSysDirs = Split(objSysPara(7).Trim, ";")
                End If

                ' Add js for this directory
                If intDepth = 0 Then
                    strTree = strTree & "aux" & intDepth + 1 & " = insFld(foldersTree, gFld('" & Replace(strPath, "\", "\\") & "', 'WShowDetail.aspx?Loc=" & Replace(strPath, "\", "\\") & "'))" & Chr(10)
                    strTree = strTree & "aux" & intDepth + 1 & ".iconSrc = ICONPATH + 'ftv2folderopen.gif'" & Chr(10)
                    strTree = strTree & "aux" & intDepth + 1 & ".iconSrcClosed = ICONPATH + 'ftv2folderclosed.gif'" & Chr(10)
                    strTree = strTree & "aux" & intDepth + 1 & ".targetFrame = ""foldercontents""" & Chr(10)
                Else
                    strTree = strTree & "aux" & intDepth + 1 & " = insFld(aux" & intDepth & ", gFld('" & objDirInfor.Name & "', 'WShowDetail.aspx?Loc=" & Replace(strPath, "\", "\\") & "'))" & Chr(10)
                    strTree = strTree & "aux" & intDepth + 1 & ".iconSrc = ICONPATH + 'ftv2folderopen.gif'" & Chr(10)
                    strTree = strTree & "aux" & intDepth + 1 & ".iconSrcClosed = ICONPATH + 'ftv2folderclosed.gif'" & Chr(10)
                    strTree = strTree & "aux" & intDepth + 1 & ".targetFrame = ""foldercontents""" & Chr(10)
                End If

                ' Build tree by recursively calling this same function
                Dim subDir As DirectoryInfo

                For Each subDir In objDirInfor.GetDirectories
                    Dim i As Integer

                    If Not strSysDirs Is Nothing AndAlso UBound(strSysDirs) > 0 Then
                        For i = LBound(strSysDirs) To UBound(strSysDirs) - 1
                            If InStr(LCase(strPath & "\" & subDir.Name & "\"), LCase(Replace(strSysDirs(i), "/", "\"))) > 0 Then
                                blnFound = True
                                Exit For
                            End If
                        Next
                    End If

                    If blnFound = True Then
                        strTree = strTree & BuildDirectoryTree(1, tblSource, strPath & "\" & subDir.Name, intDepth + 1)
                        BuildDirectoryTree = strBuiltTree & strTree
                        blnFound = False
                    End If
                Next
                ' Incase the current dir has not subdir
                If subDir Is Nothing Then
                    BuildDirectoryTree = strBuiltTree & strTree
                    blnFound = False
                End If
            Else
                Dim strNodeString As String = ""
                Dim strParam As String
                Dim tblRow() As DataRow
                If Not tblSource Is Nothing Then
                    If tblSource.Rows.Count > 0 Then
                        For intIndex = 0 To tblSource.Rows.Count - 1
                            Select Case intType
                                Case 2
                                    Select Case tblSource.Rows(intIndex).Item("Status")
                                        Case 1
                                            strParam = "'" & ddlLabel.Items(8).Text & " (" & tblSource.Rows(intIndex).Item("NOR") & ")','WShowDetail.aspx?ViewType=1&Type=1&Refresh=1&BrowseOnly=" & Request("BrowseOnly") & ")'"
                                        Case 2
                                            strParam = "'" & ddlLabel.Items(9).Text & " (" & tblSource.Rows(intIndex).Item("NOR") & ")','WShowDetail.aspx?ViewType=1&Type=2&Refresh=1&BrowseOnly=" & Request("BrowseOnly") & ")'"
                                        Case 3
                                            strParam = "'" & ddlLabel.Items(10).Text & " (" & tblSource.Rows(intIndex).Item("NOR") & ")','WShowDetail.aspx?ViewType=1&Type=3&Refresh=1&BrowseOnly=" & Request("BrowseOnly") & ")'"
                                        Case 4
                                            strParam = "'" & ddlLabel.Items(11).Text & " (" & tblSource.Rows(intIndex).Item("NOR") & ")','WShowDetail.aspx?ViewType=1&Type=4&Refresh=1&BrowseOnly=" & Request("BrowseOnly") & ")'"
                                    End Select
                                Case 3
                                    Select Case tblSource.Rows(intIndex).Item("MediaType")
                                        Case 1
                                            strParam = "'" & ddlLabel.Items(1).Text & " (" & tblSource.Rows(intIndex).Item("NOR") & ")','WShowDetail.aspx?ViewType=2&Type=1&Refresh=1&BrowseOnly=" & Request("BrowseOnly") & ")'"
                                        Case 2
                                            strParam = "'" & ddlLabel.Items(2).Text & " (" & tblSource.Rows(intIndex).Item("NOR") & ")','WShowDetail.aspx?ViewType=2&Type=2&BrowseOnly=" & Request("BrowseOnly") & ")'"
                                        Case 3
                                            strParam = "'" & ddlLabel.Items(3).Text & " (" & tblSource.Rows(intIndex).Item("NOR") & ")','WShowDetail.aspx?ViewType=2&Type=3&BrowseOnly=" & Request("BrowseOnly") & ")'"
                                        Case 4
                                            strParam = "'" & ddlLabel.Items(4).Text & " (" & tblSource.Rows(intIndex).Item("NOR") & ")','WShowDetail.aspx?ViewType=2&Type=4&BrowseOnly=" & Request("BrowseOnly") & ")'"
                                        Case 5
                                            strParam = "'" & ddlLabel.Items(5).Text & " (" & tblSource.Rows(intIndex).Item("NOR") & ")','WShowDetail.aspx?ViewType=2&Type=5&Refresh=1&BrowseOnly=" & Request("BrowseOnly") & ")'"
                                        Case 6
                                            strParam = "'" & ddlLabel.Items(6).Text & " (" & tblSource.Rows(intIndex).Item("NOR") & ")','WShowDetail.aspx?ViewType=2&Type=6&BrowseOnly=" & Request("BrowseOnly") & ")'"
                                        Case 7
                                            strParam = "'" & ddlLabel.Items(7).Text & " (" & tblSource.Rows(intIndex).Item("NOR") & ")','WShowDetail.aspx?ViewType=2&Type=7&BrowseOnly=" & Request("BrowseOnly") & ")'"
                                    End Select
                                Case 4
                                    ' Declare variables
                                    Dim tblEDataCollection As DataTable
                                    Dim dvCollection As DataView
                                    Dim strCollectionName As String = ""
                                    Dim intCount As Integer = 0

                                    ' Check the collection is null or not - Null - undefine
                                    If IsDBNull(tblSource.Rows(intIndex).Item("CollectionID")) Then
                                        strParam = "'" & ddlLabel.Items(13).Text & " (" & tblSource.Rows(intIndex).Item("NOR") & ")','WShowDetail.aspx?ViewType=3&CollectionID=-1&BrowseOnly=" & Request("BrowseOnly") & ")'"
                                    Else
                                        ' Check the collection is belong to the collection table or not
                                        tblEDataCollection = objBEData.GetDisplayTypes(5)
                                        Call WriteErrorMssg(ddlLabel.Items(18).Text, objBEData.ErrorMsg, ddlLabel.Items(17).Text, objBEData.ErrorCode)

                                        If Not tblEDataCollection Is Nothing Then
                                            If tblEDataCollection.Rows.Count > 0 Then
                                                dvCollection = New DataView
                                                dvCollection.Table = tblEDataCollection
                                                dvCollection.RowFilter = "CollectionID=" & tblSource.Rows(intIndex).Item("CollectionID")
                                                If dvCollection.Count > 0 Then
                                                    strCollectionName = dvCollection.Item(0).Row("Collection")
                                                End If
                                            End If
                                        End If

                                        ' Check exist in collections
                                        If Not strCollectionName = "" Then
                                            strParam = "'" & strCollectionName & " (" & tblSource.Rows(intIndex).Item("NOR") & ")','WShowDetail.aspx?ViewType=3&CollectionID=" & tblSource.Rows(intIndex).Item("CollectionID") & "&BrowseOnly=" & Request("BrowseOnly") & ")'"
                                        Else
                                            strParam = "'" & ddlLabel.Items(12).Text & " (" & tblSource.Rows(intIndex).Item("NOR") & ")','WShowDetail.aspx?ViewType=3&CollectionID=" & tblSource.Rows(intIndex).Item("CollectionID") & "&BrowseOnly=" & Request("BrowseOnly") & ")'"
                                        End If

                                    End If
                            End Select
                            strTree = strTree & "aux" & intDepth + 1 & " = insFld(foldersTree, gFld(" & strParam & "))" & Chr(10)
                            strTree = strTree & "aux" & intDepth + 1 & ".iconSrc = ICONPATH + 'ftv2folderopen.gif'" & Chr(10)
                            strTree = strTree & "aux" & intDepth + 1 & ".iconSrcClosed = ICONPATH + 'ftv2folderclosed.gif'" & Chr(10)
                            strTree = strTree & "aux" & intDepth + 1 & ".targetFrame = ""foldercontents""" & Chr(10)
                        Next
                        BuildDirectoryTree = strTree
                    End If
                End If
            End If
        End Function

        ' BindCollection method
        ' Purpose: Bind the collection
        Private Sub BindCollection()
            Dim tblCollection As DataTable

            tblCollection = objBEData.GetCollection
            Call WriteErrorMssg(ddlLabel.Items(18).Text, objBEData.ErrorMsg, ddlLabel.Items(17).Text, objBEData.ErrorCode)
            If Not tblCollection Is Nothing Then
                If tblCollection.Rows.Count > 0 Then
                    tblCollection = InsertOneRow(tblCollection, ddlLabel.Items(14).Text)
                    ddlCollection.DataSource = tblCollection
                    ddlCollection.DataTextField = "Collection"
                    ddlCollection.DataValueField = "CollectionID"
                    ddlCollection.DataBind()
                End If
            End If
        End Sub

        ' btnSearch_Click event
        ' Purpose: Search the files
        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            Dim inti As Integer
            Dim strPhysicalPath As String = ""
            Dim intStatus As Integer = 0
            Dim strMediaType As String = ""
            Dim intCollectionID As Integer = 0
            Dim strSecretLevel As String = ""
            Dim strFileSize As String = ""
            Dim tblEdataSearch As DataTable
            Dim intIndex As Integer = 0
            Dim strSQL As String = ""
            Dim strSelect As String = ""
            Dim strWhere As String = ""

            strSelect = "SELECT ID FROM Cat_tblEdataFile WHERE 1=1"

            ' Physical path
            If Not Trim(txtPhysicalPath.Text) = "" Then
                strPhysicalPath = txtPhysicalPath.Text
            End If

            ' Status
            If ddlStatus.SelectedValue <> "" Then
                intStatus = CInt(ddlStatus.SelectedValue)
            End If

            ' Media Type
            For inti = 0 To lstMediaType.Items.Count - 1
                If lstMediaType.Items(inti).Selected = True Then
                    strMediaType = strMediaType & lstMediaType.Items(inti).Value & ","
                End If
            Next
            If Trim(strMediaType) <> "" Then
                strMediaType = Left(strMediaType, Len(strMediaType) - 1)
            End If

            ' Collection
            If ddlCollection.SelectedValue <> "" Then
                intCollectionID = ddlCollection.SelectedValue
            End If

            ' SecretLevel
            strSecretLevel = ddlSecretParam.SelectedValue & ddlSecretLevel.SelectedValue

            ' FileSize
            If Trim(txtSize.Text) <> "" Then
                strFileSize = ddlSizePara.SelectedValue & CStr(CDbl(txtSize.Text) * 1024)
            End If

            ' Build the SQL statement
            ' Physical Path
            If Not strPhysicalPath = "" Then
                strWhere = strWhere & " AND upper(FileLocation) like '" & strPhysicalPath.ToUpper & "'"
            End If

            ' Status
            If Not intStatus = 0 Then
                strWhere = strWhere & " AND Status = " & intStatus
            End If

            ' Media type
            If Not strMediaType = "" Then
                strWhere = strWhere & " AND MediaType IN(" & strMediaType & ")"
            End If

            ' CollectionID
            If Not intCollectionID = 0 Then
                strWhere = strWhere & " AND CollectionID = " & intCollectionID
            End If

            ' Secret Level
            If Not strSecretLevel = "" Then
                strWhere = strWhere & " AND SecretLevel " & strSecretLevel
            End If

            ' FileSize
            If Not strFileSize = "" Then
                strWhere = strWhere & " AND FileSize " & strFileSize
            End If

            ' get SQL statement
            If Not strWhere = "" Then
                strSQL = strSelect & strWhere
            End If

            ' Get the session
            If Not strSQL = "" Then
                Session("SQLStatement") = strSQL
            Else
                Session("SQLStatement") = "''''"
            End If

            Page.RegisterClientScriptBlock("LoadSearchResult", "<script language='javascript'>parent.foldercontents.location.href='WShowDetail.aspx?Search=1';</script>")
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBEData Is Nothing Then
                    objBEData.Dispose(True)
                    objBEData = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace