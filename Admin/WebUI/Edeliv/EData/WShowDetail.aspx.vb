Imports System
Imports System.Math
Imports System.IO
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.WebUI.Edeliv
Imports eMicLibAdmin.BusinessRules.Edeliv
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WShowDetail
        Inherits clsWEData

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents hidID As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents hidAlertJS As System.Web.UI.HtmlControls.HtmlInputHidden


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

#Region "Declare class variables"
        Private strLocation As String
        Private objDirInfor As DirectoryInfo
        Private objSubDirInfor As DirectoryInfo
        Private objFileInfor As FileInfo

        Private tblRow As TableRow
        Private tblCell As TableCell
        Private chkEData As HtmlInputCheckBox
        Private rdoEData As HtmlInputRadioButton
        Private lnkEData As HyperLink
        Private btnEData As Button
        Private lblEData As Label
        Private ddlEData As DropDownList
        Dim ddlItem As ListItem
        Private intMax As Integer = 0
        Private intIndex As Integer = 0
        Private blnFound As Boolean = False
        Private bnlIsAlterRow As Boolean = False
        Private imgIcon As Image
        Private strType As String
        Private strFileFormat As String
        Private strFileFullName As String
        Private strFileName As String
        Private strFileExt As String
        Private strStatusComment As String
        Private strTemp As String = ""

        Private intMode As Integer = 0
        Private intListType As Integer = 0
        Private intViewMode As Integer = 0
        Private intCount As Integer
        Private tblEData As DataTable
        Private lngTotalRec As Long = 0
        Private intNumOfPages As Integer
        Private intCurrPage As Integer = 1
        Private strURL As String
#End Region

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If hidLocCur.Value = "" Then
                hidLocCur.Value = Request("Loc")
            End If
            strURL = Request.ServerVariables("SCRIPT_NAME")
            Call CheckFormPemission()
            Call Initialize()
            hidAttachedIDs.Value = ","
            lblAlertJS.Text = ""
            ' Do the actions
            Select Case hidFunc.Value
                Case ""
                    hidAction.Value = 0
                    hidChanged.Value = 0
                Case "SetAttributes" ' Set attributes
                    Call SetAttributes()
                    Call WriteErrorMssg(ddlLabel.Items(83).Text, strErrorMsg, ddlLabel.Items(82).Text, intErrorCode)
                    Call BindData()
                    ' Create folder
                Case "CreateFolder"
                    hidAction.Value = 2
                    hidChanged.Value = 0
                    If CreateSubFolder(hidLoc.Value, hidFolder.Value) Then
                        hidChanged.Value = 1
                    End If
                    Call WriteErrorMssg(ddlLabel.Items(83).Text, strErrorMsg, ddlLabel.Items(82).Text, intErrorCode)
                    Call WriteLog(78, ddlLabel.Items(42).Text & ": " & hidLoc.Value & "\" & hidFolder.Value, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                    Call BindData()
                    ' Rename folder
                Case "RenameFolder"
                    hidAction.Value = 1
                    hidChanged.Value = 0
                    Dim strNewFoders As String
                    If Rename(hidLoc.Value, hidFolder.Value, strNewFoders) Then
                        hidChanged.Value = 1
                        hidLocCur.Value = strNewFoders
                        objDirInfor = Nothing
                        objDirInfor = New DirectoryInfo(strNewFoders)
                    End If
                    Call WriteErrorMssg(ddlLabel.Items(83).Text, strErrorMsg, ddlLabel.Items(82).Text, intErrorCode)
                    Call WriteLog(78, ddlLabel.Items(43).Text & ": " & hidLoc.Value & " -> " & strNewFoders, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                    Call BindData()
                    ' DownLoad
                Case "DownLoad"
                    strIDs = hidLoc.Value
                    Call DownLoad()
                    Call WriteErrorMssg(ddlLabel.Items(83).Text, strErrorMsg, ddlLabel.Items(82).Text, intErrorCode)
                    Call BindData()
                    ' Synchronize
                Case "Synchronize"
                    strIDs = ""
                    strParam = hidLoc.Value
                    Call Synchronize(True)
                    If objBEData.ErrorMsg = "" Then
                        lblAlertJS.Text = "<script language=javascript> alert('" & ddlLabel.Items(50).Text & " " & Replace(hidLocCur.Value, "\", "\\") & " ') </script>"
                    End If

                    Call WriteErrorMssg(ddlLabel.Items(83).Text, strErrorMsg, ddlLabel.Items(82).Text, intErrorCode)
                    Call WriteLog(78, ddlLabel.Items(40).Text & ": " & hidLoc.Value, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                    Call BindData()


                    ' Remove Folder
                Case "RemoveFolder"
                    Call DeleteFolder(hidLoc.Value, True)
                    Call WriteErrorMssg(ddlLabel.Items(83).Text, strErrorMsg, ddlLabel.Items(82).Text, intErrorCode)
                    Call WriteLog(78, ddlLabel.Items(44).Text & ": " & hidLoc.Value, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                    Call BindData()
                    ' Import Files
                Case "ImportFiles"
                    Dim strFileNames As String()
                    Dim strLocation As String = hidLoc.Value
                    Dim intIndex As Integer
                    Dim objFileInfor As FileInfo
                    Dim objFileInfor1 As FileInfo

                    If Trim(hidIDs.Value) <> "" Or Trim(hidIDs.Value) <> "," Then
                        strFileNames = Split(hidIDs.Value, ",")
                        If UBound(strFileNames) > 1 Then
                            For intIndex = 1 To UBound(strFileNames) - 1
                                objFileInfor = New FileInfo(Replace(strLocation & "\", "\\", "\") & strFileNames(intIndex))
                                objFileInfor1 = New FileInfo(Replace(hidLocCur.Value & "\", "\\", "\") & strFileNames(intIndex))
                                hidOverWrite.Value = 0
                                If objFileInfor.Exists Then
                                    ' Exists file
                                    If objFileInfor1.Exists = True Then
                                        Page.RegisterClientScriptBlock("ConfirmJs" & intIndex, "<script language='javascript'>if(confirm('" & ddlLabel.Items(105).Text & " ')){ document.forms[0].hidOverWrite.value=1;}</script>")
                                    End If
                                    ' Overwrite
                                    If (objFileInfor1.Exists = True AndAlso hidOverWrite.Value = 1) Or objFileInfor1.Exists = False Then
                                        objFileInfor.CopyTo(Replace(hidLocCur.Value & "\", "\\", "\") & strFileNames(intIndex), True)
                                        Call ImportEData(hidLocCur.Value, strFileNames(intIndex))
                                        Call WriteErrorMssg(ddlLabel.Items(83).Text, strErrorMsg, ddlLabel.Items(82).Text, intErrorCode)
                                    End If
                                End If
                            Next
                            Page.RegisterClientScriptBlock("AlertUploadJs", "<script language='javascript'>alert('" & ddlLabel.Items(106).Text & "');</script>")
                            Call WriteLog(78, ddlLabel.Items(39).Text & ": " & hidLoc.Value, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                        End If
                    End If
                    Call BindData()
                    ' Delete Logical folder
                Case "DeleteLogical"
                    If Trim(hidIDs.Value) <> "" Or Trim(hidIDs.Value) <> "," Then
                        strIDs = Right(Left(hidIDs.Value, Len(hidIDs.Value) - 1), Len(Left(hidIDs.Value, Len(hidIDs.Value) - 1)) - 1)
                        If Trim(strIDs) <> "" Then
                            strIDs = Trim(strIDs)
                            Call Delete(False)
                            Call WriteErrorMssg(ddlLabel.Items(83).Text, strErrorMsg, ddlLabel.Items(82).Text, intErrorCode)
                            Call WriteLog(78, btnDeleteLogical.Text & " (FileIDs: " & strIDs & ")", Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                        End If
                    End If
                    Call BindData()
                    ' Delete file(s)
                Case "Delete"
                    If Trim(hidIDs.Value) <> "" Or Trim(hidIDs.Value) <> "," Then
                        strIDs = Right(Left(hidIDs.Value, Len(hidIDs.Value) - 1), Len(Left(hidIDs.Value, Len(hidIDs.Value) - 1)) - 1)
                        If Trim(strIDs) <> "" Then
                            strIDs = Trim(strIDs)
                            Call Delete(True)
                            Call WriteErrorMssg(ddlLabel.Items(83).Text, strErrorMsg, ddlLabel.Items(82).Text, intErrorCode)
                            Call WriteLog(78, ddlLabel.Items(93).Text & " (FileIDs: " & strIDs & ")", Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                        End If
                    End If
                    Call BindData()
                    ' Change the exploiting mode to free
                Case "ChangeFree"
                    If Trim(hidIDs.Value) <> "" Or Trim(hidIDs.Value) <> "," Then
                        strIDs = Right(Left(hidIDs.Value, Len(hidIDs.Value) - 1), Len(Left(hidIDs.Value, Len(hidIDs.Value) - 1)) - 1)
                        If Trim(strIDs) <> "" Then
                            strIDs = Trim(strIDs)
                            intFree = 1
                            Call ChangeAccessMode()
                            Call WriteErrorMssg(ddlLabel.Items(83).Text, strErrorMsg, ddlLabel.Items(82).Text, intErrorCode)
                            Call WriteLog(78, ddlLabel.Items(94).Text & " (FileIDs: " & strIDs & ")", Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                        End If
                    End If
                    Call BindData()
                    ' Change the exploiting mode to cost
                Case "ChangeCost"
                    If Trim(hidIDs.Value) <> "" Or Trim(hidIDs.Value) <> "," Then
                        strIDs = Right(Left(hidIDs.Value, Len(hidIDs.Value) - 1), Len(Left(hidIDs.Value, Len(hidIDs.Value) - 1)) - 1)
                        If Trim(strIDs) <> "" Then
                            strIDs = Trim(strIDs)
                            intFree = 0
                            Call ChangeAccessMode()
                            Call WriteErrorMssg(ddlLabel.Items(83).Text, strErrorMsg, ddlLabel.Items(82).Text, intErrorCode)
                            Call WriteLog(78, ddlLabel.Items(95).Text & " (FileIDs: " & strIDs & ")", Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                        End If
                    End If
                    Call BindData()
                    ' Set Secret Level
                Case "SetSecretLevel"
                    If Trim(hidIDs.Value) <> "" Or Trim(hidIDs.Value) <> "," Then
                        strIDs = Right(Left(hidIDs.Value, Len(hidIDs.Value) - 1), Len(Left(hidIDs.Value, Len(hidIDs.Value) - 1)) - 1)
                        If Trim(strIDs) <> "" Then
                            strIDs = Trim(strIDs)
                            intSecretLevel = CInt(hidSecretLevel.Value)
                            Call SetSecretLevel()
                            Page.RegisterClientScriptBlock("SecretJs", "<script language='javascript'>alert('" & ddlLabel.Items(108).Text & "');</script>")
                            Call WriteErrorMssg(ddlLabel.Items(83).Text, strErrorMsg, ddlLabel.Items(82).Text, intErrorCode)
                            Call WriteLog(78, ddlLabel.Items(96).Text & " (FileIDs: " & strIDs & ")", Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                        End If
                    End If
                    Call BindData()
                    ' Change Status of file(s)
                Case "ChangeStatus"
                    If Trim(hidIDs.Value) <> "" Or Trim(hidIDs.Value) <> "," Then
                        strIDs = Right(Left(hidIDs.Value, Len(hidIDs.Value) - 1), Len(Left(hidIDs.Value, Len(hidIDs.Value) - 1)) - 1)
                        If Trim(strIDs) <> "" Then
                            strIDs = Trim(strIDs)
                            intStatus = CInt(hidStatus.Value)
                            Call ChangeStatus()
                            Call WriteErrorMssg(ddlLabel.Items(83).Text, strErrorMsg, ddlLabel.Items(82).Text, intErrorCode)
                            Call WriteLog(78, ddlLabel.Items(97).Text & " (FileIDs: " & strIDs & ")", Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                        End If
                    End If

                    If Request("Refresh") = "1" Then
                        Page.RegisterClientScriptBlock("RefreshForm", "<script language='javascript'>parent.top.main.Workform.location.href='WEDataManager.aspx';</script>")
                    Else
                        Call BindData()
                    End If
                    ' Move files
                Case "Move"
                    If Trim(hidIDs.Value) <> "" Or Trim(hidIDs.Value) <> "," Then
                        strIDs = Right(Left(hidIDs.Value, Len(hidIDs.Value) - 1), Len(Left(hidIDs.Value, Len(hidIDs.Value) - 1)) - 1)
                        If Trim(strIDs) <> "" And Trim(hidLoc.Value) <> "" Then
                            strIDs = Trim(strIDs)
                            Dim intResult As Integer

                            strParam = hidLoc.Value
                            intResult = Move(hidFolder.Value, True)
                            Call WriteErrorMssg(ddlLabel.Items(83).Text, strErrorMsg, ddlLabel.Items(82).Text, intErrorCode)
                            Select Case intResult
                                Case 0
                                    Page.RegisterClientScriptBlock("Success", "<script language = 'javascript'>alert('" & ddlLabel.Items(63).Text & "');</script>")
                                    Call WriteLog(78, ddlLabel.Items(98).Text & " (Folder: " & hidFolder.Value & "; FileIDs: " & strIDs & ")", Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                                Case 2
                                    Page.RegisterClientScriptBlock("InvalidPath", "<script language = 'javascript'>alert('" & ddlLabel.Items(62).Text & "');</script>")
                                Case 3
                                    Page.RegisterClientScriptBlock("InValidDir", "<script language = 'javascript'>alert('" & ddlLabel.Items(85).Text & "');</script>")
                            End Select
                        End If
                    End If
                    Call BindData()
                    ' Attach
                Case "Attach"
                    If Trim(hidIDs.Value) <> "" Or Trim(hidIDs.Value) <> "," Then
                        Dim intResult As Integer
                        Dim strFileIDSelect As String
                        Dim strItemCode As String

                        strIDs = Right(Left(hidIDs.Value, Len(hidIDs.Value) - 1), Len(Left(hidIDs.Value, Len(hidIDs.Value) - 1)) - 1)
                        strFileIDSelect = strIDs
                        strItemCode = hidFolder.Value
                        If Trim(strIDs) <> "" Then
                            strIDs = Trim(strIDs)
                            intResult = AttachEdata(strItemCode, strFileIDSelect)
                            Call WriteErrorMssg(ddlLabel.Items(83).Text, strErrorMsg, ddlLabel.Items(82).Text, intErrorCode)
                            Call WriteLog(78, ddlLabel.Items(99).Text & " (ItemCode: " & hidFolder.Value & "; FileIDs: " & strIDs & ")", Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                            Page.RegisterClientScriptBlock("AtachFileSucc", "<script language='javascript'>alert('" & btnAttach.Text & " " & ddlLabel.Items(90).Text & "');</script>")
                        End If
                    End If
                    Call BindData()
                    ' Detach
                Case "Detach"
                    If Trim(hidIDs.Value) <> "" Or Trim(hidIDs.Value) <> "," Then
                        Dim intResult As Integer
                        Dim strFileIDSelect As String

                        strIDs = Right(Left(hidIDs.Value, Len(hidIDs.Value) - 1), Len(Left(hidIDs.Value, Len(hidIDs.Value) - 1)) - 1)
                        strFileIDSelect = strIDs
                        If Trim(strIDs) <> "" Then
                            strIDs = Trim(strIDs)
                            intResult = DetachFile(strFileIDSelect)
                            Call WriteErrorMssg(ddlLabel.Items(83).Text, strErrorMsg, ddlLabel.Items(82).Text, intErrorCode)
                            Call WriteLog(78, ddlLabel.Items(100).Text & " (FileIDs: " & strIDs & ")", Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                            Page.RegisterClientScriptBlock("DetachFileSucc", "<script language='javascript'>alert('" & btnRemoveAttach.Text & " " & ddlLabel.Items(90).Text & "');</script>")
                        End If
                    End If
                    Call BindData()
                    ' ChangeToMap
                Case "ChangeToMap"
                    If Trim(hidIDs.Value) <> "" Or Trim(hidIDs.Value) <> "," Then
                        strIDs = Right(Left(hidIDs.Value, Len(hidIDs.Value) - 1), Len(Left(hidIDs.Value, Len(hidIDs.Value) - 1)) - 1)
                        If Trim(strIDs) <> "" Then
                            strIDs = Trim(strIDs)
                            Call ChangeItemType(1)
                            Call WriteErrorMssg(ddlLabel.Items(83).Text, strErrorMsg, ddlLabel.Items(82).Text, intErrorCode)
                            Call WriteLog(78, ddlLabel.Items(101).Text & " (FileIDs: " & strIDs & ")", Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                        End If
                    End If
                    If Request("Refresh") = "1" Then
                        Page.RegisterClientScriptBlock("RefreshForm", "<script language='javascript'>parent.top.main.Workform.location.href='WEDataManager.aspx';</script>")
                    Else
                        Call BindData()
                    End If
                    ' ChangeToImage
                Case "ChangeToImage"
                    If Trim(hidIDs.Value) <> "" Or Trim(hidIDs.Value) <> "," Then
                        strIDs = Right(Left(hidIDs.Value, Len(hidIDs.Value) - 1), Len(Left(hidIDs.Value, Len(hidIDs.Value) - 1)) - 1)
                        If Trim(strIDs) <> "" Then
                            strIDs = Trim(strIDs)
                            Call ChangeItemType(2)
                            Call WriteErrorMssg(ddlLabel.Items(83).Text, strErrorMsg, ddlLabel.Items(82).Text, intErrorCode)
                            Call WriteLog(78, ddlLabel.Items(102).Text & " (FileIDs: " & strIDs & ")", Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                        End If
                    End If
                    If Request("Refresh") = "1" Then
                        Page.RegisterClientScriptBlock("RefreshForm", "<script language='javascript'>parent.top.main.Workform.location.href='WEDataManager.aspx';</script>")
                    Else
                        Call BindData()
                    End If
            End Select

            ' Check the display is files import or not
            If hidFunc.Value = "ImportFromFS" Then
                objDirInfor = New DirectoryInfo(hidFolder.Value)
                If objDirInfor.Exists = False Then
                    hidFolder.Value = ""
                    Page.RegisterClientScriptBlock("InvalidImportPath", "<script language = 'javascript'>alert('" & ddlLabel.Items(62).Text & "');</script>")

                    lblFolder.Visible = False
                    lblCurrentFolder.Visible = False
                    lblImportFolder.Visible = False
                    ddlView.Visible = True
                    lblView.Visible = True

                    Call ResetValue()
                    Call BindData()
                Else
                    Call ListFile2Import(hidFolder.Value)
                    lblView.Visible = False
                    ddlView.Visible = False
                    lblImportFolder.Visible = True
                    lblCurrentFolder.Visible = False
                    lblFolder.Visible = True
                    lblFolder.Text = hidFolder.Value
                End If
            Else
                lblFolder.Visible = False
                lblCurrentFolder.Visible = False
                lblImportFolder.Visible = False
                ddlView.Visible = True
                lblView.Visible = True

                ' Check the display type by directories or not
                If Not hidLocCur.Value & "" = "" Then
                    lblCurrentFolder.Visible = True
                    lblFolder.Visible = True
                    lblFolder.Text = hidLocCur.Value
                    lblImportFolder.Visible = False
                    Call CheckDirectories(hidLocCur.Value)
                Else
                    lblFolder.Visible = False
                    lblCurrentFolder.Visible = False
                    lblImportFolder.Visible = False
                End If
            End If

            Call BindScript()
            Call ResetValue()

            If Not Page.IsPostBack Then
                Call BindData()
            End If


        End Sub

        ' CheckFormPemission method
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            If Not CheckPemission(166) Then
                Call WriteErrorMssg(ddlLabel.Items(81).Text)
            End If
        End Sub

        ' CheckDirectories method
        ' Purpose: check directories is belog the system dirs or not
        Public Sub CheckDirectories(ByVal strLoc As String, Optional ByVal blnAlert As Boolean = False)
            If CheckSysDir(strLoc) = False Then
                If blnAlert = True Then
                    Page.RegisterClientScriptBlock("InValidDir", "<script language = 'javascript'>alert('" & ddlLabel.Items(85).Text & "');</script>")
                Else
                    'Response.Write("<CENTER><H2><FONT COLOR=""RED"">" & ddlLabel.Items(85).Text & "</FONT></H2></CENTER>")
                    Response.End()
                End If
            End If
        End Sub

        ' BindData method
        Private Sub BindData()
            Call PrepareVariables()

            ddlView.Visible = True
            lblView.Visible = True

            If Session("ViewMode") = 0 Then
                ddlView.SelectedIndex = 0
                Call ShowFilesInListMode()
                Session("ViewMode") = 0
            Else
                ddlView.SelectedIndex = 1
                Call ShowFilesInThumbnailMode()
                Session("ViewMode") = 1
            End If

            ' Show the navigator
            If Not hidLocCur.Value & "" = "" Then
                Call ShowNavigator()
            End If
        End Sub

        ' ResetValue method
        ' Purpose: Reset the value for the controls
        Private Sub ResetValue()
            hidFunc.Value = ""
            hidLoc.Value = ""
            hidAttr.Value = ""
            hidIDs.Value = ","
            hidFolder.Value = ""
            hidSecretLevel.Value = ""
            hidStatus.Value = ""
        End Sub

        ' BindScript method
        ' Purpose: Include all neccessary javascript functions
        Private Sub BindScript()
            Dim strJS As String
            Page.RegisterClientScriptBlock("CommonJs", "<script language = ""javascript"" src = ""../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & """></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/EData/WShowDetail.js'></script>")
            btnDeleteLogical.Attributes.Add("OnClick", "return DeleteLogical('" & ddlLabel.Items(54).Text & "','" & ddlLabel.Items(55).Text & "');")
            btnDeleteLogical2.Attributes.Add("OnClick", "return DeleteLogical('" & ddlLabel.Items(54).Text & "','" & ddlLabel.Items(55).Text & "');")
            btnSetSecretLevel.Attributes.Add("OnClick", "return SetSecretLevel('" & ddlLabel.Items(57).Text & "','" & ddlLabel.Items(58).Text & "','" & ddlLabel.Items(109).Text & "');")
            btnSetSecretLevel2.Attributes.Add("OnClick", "return SetSecretLevel('" & ddlLabel.Items(57).Text & "','" & ddlLabel.Items(58).Text & "','" & ddlLabel.Items(109).Text & "');")
            btnDelete.Attributes.Add("OnClick", "return Delete('" & ddlLabel.Items(60).Text & "','" & ddlLabel.Items(59).Text & "');")
            btnDelete2.Attributes.Add("OnClick", "return Delete('" & ddlLabel.Items(60).Text & "','" & ddlLabel.Items(59).Text & "');")
            btnFree.Attributes.Add("OnClick", "return ChangeFree('" & ddlLabel.Items(78).Text & "','" & ddlLabel.Items(77).Text & "');")
            btnFree2.Attributes.Add("OnClick", "return ChangeFree('" & ddlLabel.Items(78).Text & "','" & ddlLabel.Items(77).Text & "');")
            btnCost.Attributes.Add("OnClick", "return ChangeCost('" & ddlLabel.Items(80).Text & "','" & ddlLabel.Items(79).Text & "');")
            btnCost2.Attributes.Add("OnClick", "return ChangeCost('" & ddlLabel.Items(80).Text & "','" & ddlLabel.Items(79).Text & "');")
            btnMove.Attributes.Add("OnClick", "return Move('" & Replace(hidLocCur.Value, "\", "\\") & "','" & ddlLabel.Items(61).Text & "','" & ddlLabel.Items(64).Text & "');")
            btnMove2.Attributes.Add("OnClick", "return Move('" & Replace(hidLocCur.Value, "\", "\\") & "','" & ddlLabel.Items(61).Text & "','" & ddlLabel.Items(64).Text & "');")
            btnCatalogue.Attributes.Add("OnClick", "Catalogue('" & ddlLabel.Items(71).Text & "');return false;")
            btnCatalogue2.Attributes.Add("OnClick", "Catalogue('" & ddlLabel.Items(71).Text & "');return false;")
            btnAttach.Attributes.Add("OnClick", "if (SetCollection('" & ddlLabel.Items(65).Text & "')){OpenWindow('WSearchCopyNumber.aspx','WSearchCopyNumber',700,500,50,50);}return false;")
            btnAttach2.Attributes.Add("OnClick", "if (SetCollection('" & ddlLabel.Items(65).Text & "')){OpenWindow('WSearchCopyNumber.aspx','WSearchCopyNumber',700,500,50,50);}return false;")
            btnRemoveAttach.Attributes.Add("OnClick", "return Detach('" & ddlLabel.Items(67).Text & "','" & ddlLabel.Items(66).Text & "','" & ddlLabel.Items(92).Text & "');")
            btnRemoveAttach2.Attributes.Add("OnClick", "return Detach('" & ddlLabel.Items(67).Text & "','" & ddlLabel.Items(66).Text & "','" & ddlLabel.Items(92).Text & "');")
            If Request("ViewType") = "3" Then
                btnSetCollection.Attributes.Add("OnClick", "javascript:if (SetCollection('" & ddlLabel.Items(70).Text & "')) {OpenWindow('WEdataCollectionView.aspx?Refresh=1&FileIDsSelect='+ eval(document.forms[0].hidIDs).value,'WEdataCollectionView',400,120,50,50);};return false;")
                btnSetCollection2.Attributes.Add("OnClick", "javascript:if (SetCollection('" & ddlLabel.Items(70).Text & "')) {OpenWindow('WEdataCollectionView.aspx?Refresh=1&FileIDsSelect='+ eval(document.forms[0].hidIDs).value,'WEdataCollectionView',400,120,50,50);};return false;")
            Else
                btnSetCollection.Attributes.Add("OnClick", "javascript:if (SetCollection('" & ddlLabel.Items(70).Text & "')) {OpenWindow('WEdataCollectionView.aspx?FileIDsSelect='+ eval(document.forms[0].hidIDs).value,'WEdataCollectionView',400,120,50,50);};return false;")
                btnSetCollection2.Attributes.Add("OnClick", "javascript:if (SetCollection('" & ddlLabel.Items(70).Text & "')) {OpenWindow('WEdataCollectionView.aspx?FileIDsSelect='+ eval(document.forms[0].hidIDs).value,'WEdataCollectionView',400,120,50,50);};return false;")
            End If

            btnChangeStat.Attributes.Add("OnClick", "return ChangeStat('" & ddlLabel.Items(73).Text & "','" & ddlLabel.Items(74).Text & "','" & ddlLabel.Items(110).Text & "','" & ddlLabel.Items(111).Text & "');")
            btnChangeStat2.Attributes.Add("OnClick", "return ChangeStat('" & ddlLabel.Items(73).Text & "','" & ddlLabel.Items(74).Text & "');")
            btnExport.Attributes.Add("OnClick", "javascript:if (Export('" & ddlLabel.Items(84).Text & "')) {OpenWindow('WExportToXML.aspx?FileIDs='+ eval(document.forms[0].hidIDs).value,'WExportToXML',400,180,50,50);};return false;")
            btnExport2.Attributes.Add("OnClick", "javascript:if (Export('" & ddlLabel.Items(84).Text & "')) {OpenWindow('WExportToXML.aspx?FileIDs='+ eval(document.forms[0].hidIDs).value,'WExportToXML',400,180,50,50);};return false;")
            btnChangeMap.Attributes.Add("OnClick", "return ChangeToMap('" & ddlLabel.Items(87).Text & "','" & ddlLabel.Items(88).Text & "');")
            btnChangeMap2.Attributes.Add("OnClick", "return ChangeToMap('" & ddlLabel.Items(87).Text & "','" & ddlLabel.Items(88).Text & "');")
            btnChangeImage.Attributes.Add("OnClick", "return ChangeToImage('" & ddlLabel.Items(89).Text & "','" & ddlLabel.Items(88).Text & "');")
            btnChangeImage2.Attributes.Add("OnClick", "return ChangeToImage('" & ddlLabel.Items(89).Text & "','" & ddlLabel.Items(88).Text & "');")
        End Sub

        ' ddlView_SelectedIndexChangedevent
        ' Change the view mode
        Private Sub ddlView_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlView.SelectedIndexChanged
            Session("ViewMode") = ddlView.SelectedValue
            strURL = Request.ServerVariables("SCRIPT_NAME")
            Call Initialize()
            Call BindScript()
            Call BindData()
        End Sub

        ' ListFile2Import method
        ' Purpose: show list files of the selected directory to import
        Private Sub ListFile2Import(ByVal strLocation As String)
            Dim objDirInfor As DirectoryInfo = New DirectoryInfo(strLocation)
            Dim objFileInfor As FileInfo

            Dim tblRow As TableRow
            Dim tblCell As TableCell
            Dim chkEData As HtmlInputCheckBox
            Dim lnkEData As HyperLink
            Dim btnEData As Button
            Dim lblEData As Label
            Dim intMax As Integer
            Dim intIndex As Integer = 0
            Dim bnlIsAlterRow As Boolean = False
            Dim imgIcon As Image
            Dim strType As String
            Dim strTotalFilesInFS As String = ddlLabel.Items(36).Text

            ' Víible = false for the control bar
            TRFunc1.Visible = False
            TRFunc2.Visible = False

            ' Get total of files in this dir
            intMax = objDirInfor.GetFiles("*.*").Length

            If intMax > 0 Then
                ' Show header
                tblRow = New TableRow

                ' Show total of files (in FileSystem)
                strTemp = strTemp & "<UL>" & Chr(13)
                strTemp = strTemp & "<LI>" & strTotalFilesInFS & ": <B>" & intMax & "</B></LI>" & Chr(13)
                strTemp = strTemp & "</UL>" & Chr(13)

                lblEData = New Label
                lblEData.ID = "lblTotalFiles"
                lblEData.Text = strTemp
                lblEData.CssClass = "lbLabel"

                tblCell = New TableCell
                tblCell.HorizontalAlign = HorizontalAlign.Left
                tblCell.VerticalAlign = VerticalAlign.Bottom
                tblCell.Width = Unit.Percentage(45)
                tblCell.Controls.Add(lblEData)
                tblRow.Cells.Add(tblCell)

                ' Add to current row
                tblHeader.Rows.Add(tblRow)

                tblRow = New TableRow
                ' Add select column
                ' Fisrt, new checkbox
                chkEData = New HtmlInputCheckBox
                chkEData.ID = "chkCheckAll"
                chkEData.Attributes.Add("Class", "lbCheckBox")
                chkEData.Attributes.Add("OnClick", "MarkAll(this, " & intMax & ");")
                tblCell = New TableCell
                tblCell.HorizontalAlign = HorizontalAlign.Center
                tblCell.Controls.Add(chkEData)
                tblRow.Cells.Add(tblCell)

                ' Add FileName Column
                tblCell = New TableCell
                tblCell.HorizontalAlign = HorizontalAlign.Center
                tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(0).Text))
                tblRow.Cells.Add(tblCell)

                ' Add FileType Column
                tblCell = New TableCell
                tblCell.HorizontalAlign = HorizontalAlign.Center
                tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(1).Text))
                tblRow.Cells.Add(tblCell)

                ' Add FileSize Column
                tblCell = New TableCell
                tblCell.HorizontalAlign = HorizontalAlign.Center
                tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(2).Text))
                tblRow.Cells.Add(tblCell)

                ' Add CreatedDate Column
                tblCell = New TableCell
                tblCell.HorizontalAlign = HorizontalAlign.Center
                tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(3).Text))
                tblRow.Cells.Add(tblCell)

                ' Add LastModifiedDate Column
                tblCell = New TableCell
                tblCell.HorizontalAlign = HorizontalAlign.Center
                tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(4).Text))
                tblRow.Cells.Add(tblCell)

                ' Add header row to table
                tblRow.CssClass = "lbGridHeader"
                tblResult.Rows.Add(tblRow)

                ' Show file infor
                For Each objFileInfor In objDirInfor.GetFiles("*.*")
                    ' Get Icon of file
                    Select Case Replace(objFileInfor.Extension, ".", "")
                        Case "jpg", "bmp", "png", "jpeg", "jpe"
                            strType = "jpg"
                        Case "gif"
                            strType = "gif"
                        Case "txt"
                            strType = "txt"
                        Case "doc"
                            strType = "doc"
                        Case "pdf"
                            strType = "pdf"
                        Case "html", "htm"
                            strType = "htm"
                        Case Else
                            strType = "oth"
                    End Select
                    imgIcon = New Image
                    imgIcon.ImageUrl = "../../Images/Icons/" & strType & ".gif"

                    ' Show header
                    tblRow = New TableRow

                    ' Add select column
                    ' Fisrt, new checkbox
                    chkEData = New HtmlInputCheckBox
                    chkEData.ID = "chkFile" & intIndex
                    chkEData.Value = objFileInfor.Name
                    chkEData.Attributes.Add("Class", "lbCheckBox")
                    chkEData.Attributes.Add("OnClick", "ClickMe(this);")

                    tblCell = New TableCell
                    tblCell.HorizontalAlign = HorizontalAlign.Center
                    tblCell.Controls.Add(chkEData)
                    tblRow.Cells.Add(tblCell)

                    ' Add FileName Column
                    lnkEData = New HyperLink
                    lnkEData.NavigateUrl = strLocation & "\" & objFileInfor.Name
                    lnkEData.Text = objFileInfor.Name
                    lnkEData.CssClass = "lbLinkFunction"

                    tblCell = New TableCell
                    tblCell.HorizontalAlign = HorizontalAlign.Left
                    tblCell.Controls.Add(imgIcon)
                    tblCell.Controls.Add(lnkEData)
                    tblRow.Cells.Add(tblCell)

                    ' Add FileType Column
                    lblEData = New Label
                    lblEData.Text = objFileInfor.Extension
                    lblEData.CssClass = "lbLabel"

                    tblCell = New TableCell
                    tblCell.HorizontalAlign = HorizontalAlign.Left
                    tblCell.Controls.Add(lblEData)
                    tblRow.Cells.Add(tblCell)

                    ' Add FileSize Column
                    lblEData = New Label
                    lblEData.Text = objFileInfor.Length
                    lblEData.CssClass = "lbLabel"

                    tblCell = New TableCell
                    tblCell.HorizontalAlign = HorizontalAlign.Right
                    tblCell.Controls.Add(lblEData)
                    tblRow.Cells.Add(tblCell)

                    ' Add CreatedDate Column
                    lblEData = New Label
                    lblEData.ID = ""
                    lblEData.Text = CStr(objFileInfor.CreationTime)
                    lblEData.CssClass = "lbLabel"

                    tblCell = New TableCell
                    tblCell.HorizontalAlign = HorizontalAlign.Center
                    tblCell.Controls.Add(lblEData)
                    tblRow.Cells.Add(tblCell)

                    ' Add LastModifiedDate Column
                    lblEData = New Label
                    lblEData.ID = ""
                    lblEData.Text = CStr(objFileInfor.LastWriteTime)
                    lblEData.CssClass = "lbLabel"

                    tblCell = New TableCell
                    tblCell.HorizontalAlign = HorizontalAlign.Center
                    tblCell.Controls.Add(lblEData)
                    tblRow.Cells.Add(tblCell)

                    ' Add this row to table
                    If bnlIsAlterRow Then
                        bnlIsAlterRow = False
                        tblRow.CssClass = "lbGridAlterCell"
                    Else
                        bnlIsAlterRow = True
                    End If
                    tblResult.Rows.Add(tblRow)

                    intIndex = intIndex + 1
                Next

                ' Add footer row
                tblRow = New TableRow
                tblCell = New TableCell

                btnEData = New Button
                btnEData.ID = "btnImport"
                btnEData.Attributes.Add("OnClick", "return ImportToFS('" & Replace(strLocation, "\", "\\") & "','" & ddlLabel.Items(53).Text & "','" & ddlLabel.Items(56).Text & "');")
                btnEData.CssClass = "lbButton"
                btnEData.Text = ddlLabel.Items(5).Text
                btnEData.Width = Unit.Pixel(90)

                tblCell.ColumnSpan = 5
                tblCell.HorizontalAlign = HorizontalAlign.Left
                tblCell.Controls.Add(btnEData)
                tblRow.Cells.Add(tblCell)
                tblRow.CssClass = "lbGridFooter"
                tblResult.Rows.Add(tblRow)
            End If
        End Sub

        ' PrepareVariables method
        ' Purpose: prepare class variables & get data
        Private Sub PrepareVariables()
            If Not hidLocCur.Value = "" Then
                strParam = hidLocCur.Value
                strLocation = strParam
                If Not InStr(strURL, "?") > 0 Then
                    strURL = strURL & "?Loc=" & strParam
                Else
                    strURL = strURL & "&Loc=" & strParam
                End If
                intListType = 4
            End If

            If Not Request("ViewType") = "" Then
                intListType = CInt(Request("ViewType"))
                If Not InStr(strURL, "?") > 0 Then
                    strURL = strURL & "?ViewType=" & intListType
                Else
                    strURL = strURL & "&ViewType=" & intListType
                End If
            End If

            If Not Request("Type") = "" Then
                strParam = Request("Type")
                If Not InStr(strURL, "?") > 0 Then
                    strURL = strURL & "?Type=" & strParam
                Else
                    strURL = strURL & "&Type=" & strParam
                End If
            End If

            If Not Request("CollectionID") = "" Then
                intCollectionID = CInt(Request("CollectionID"))
                If Not InStr(strURL, "?") > 0 Then
                    strURL = strURL & "?CollectionID=" & intCollectionID
                Else
                    strURL = strURL & "&CollectionID=" & intCollectionID
                End If
                intListType = 3
            End If

            strIDs = ""
            intPageSize = 50

            If Not Request("Search") & "" = "" Then
                If Not Session("SQLStatement") = "" Then
                    intListType = 5
                    strParam = Session("SQLStatement")
                End If
            End If

            If Request("CurrPage") = "" Then
                lngStartID = 0
            Else
                lngStartID = GetMaxIDByTopNum(intListType, 50 * (CInt(Request("CurrPage")) - 1))
                Call WriteErrorMssg(ddlLabel.Items(83).Text, strErrorMsg, ddlLabel.Items(82).Text, intErrorCode)
            End If

            ' Get data
            intViewMode = Session("ViewMode")
            tblEData = GetGeneralInfor(intMode, intListType, intViewMode, lngTotalRec)
            Call WriteErrorMssg(ddlLabel.Items(83).Text, strErrorMsg, ddlLabel.Items(82).Text, intErrorCode)

            If Not Request("Search") & "" = "" Then
                Dim tblSearch As DataTable
                Dim strSQLStatement As String
                If Not Session("SQLStatement") = "" Then
                    strSQLStatement = "SELECT COUNT(*) FROM Cat_tblEdataFile WHERE ID IN(" & Session("SQLStatement") & ")"
                    tblSearch = GetEdataSearchCount(strSQLStatement)
                    Call WriteErrorMssg(ddlLabel.Items(83).Text, strErrorMsg, ddlLabel.Items(82).Text, intErrorCode)
                    If Not tblSearch Is Nothing Then
                        If tblSearch.Rows.Count > 0 Then
                            lngTotalRec = tblSearch.Rows(0).Item(0)
                        End If
                    End If
                End If
            End If

            If Not strLocation = "" Then
                objDirInfor = New DirectoryInfo(strLocation)
            End If

            ' Check data to show
            If Not tblEData Is Nothing Then
                If tblEData.Rows.Count > 0 Then
                    blnFound = True
                    intMax = tblEData.Rows.Count

                    TRFunc1.Visible = True
                    TRFunc2.Visible = True

                    If hidLocCur.Value & "" <> "" Then
                        btnMove.Visible = True
                        btnMove2.Visible = True
                    Else
                        btnMove.Visible = False
                        btnMove2.Visible = False
                    End If
                Else
                    TRFunc1.Visible = False
                    TRFunc2.Visible = False
                    If Not Request("Search") & "" = "" Then
                        Page.RegisterClientScriptBlock("NotFound", "<script language='javascript'>alert('" & ddlLabel.Items(86).Text & "');</script>")
                    End If
                End If
            Else
                TRFunc1.Visible = False
                TRFunc2.Visible = False
                If Not Request("Search") & "" = "" Then
                    Page.RegisterClientScriptBlock("NotFound", "<script language='javascript'>alert('" & ddlLabel.Items(86).Text & "');</script>")
                End If
            End If

            ' Get subfolder
            If Not objDirInfor Is Nothing Then
                If objDirInfor.GetDirectories.Length > 0 Then
                    blnFound = True
                End If

                ' Get total of files in this dir
                If objDirInfor.GetFiles("*.*").Length > 0 Then
                    blnFound = True
                End If
            End If
        End Sub

        ' ShowNavigator method
        ' Purpose: show header of page
        Private Sub ShowNavigator()
            tblRow = New TableRow

            ' Add Import from file system icon
            lnkEData = New HyperLink
            lnkEData.Text = "<Img src=""../../Images/Icons/Import.gif"" border=0 alt=""" & ddlLabel.Items(39).Text & """>"
            lnkEData.NavigateUrl = "#"

            lnkEData.Attributes.Add("OnClick", "ImportFromFS('" & Replace(hidLocCur.Value, "\", "\\") & "','" & ddlLabel.Items(52).Text & "');")

            tblCell = New TableCell
            tblCell.HorizontalAlign = HorizontalAlign.Left
            tblCell.Width = Unit.Pixel(32)
            tblCell.Controls.Add(lnkEData)
            tblRow.Controls.Add(tblCell)

            ' Add synchronize icon
            lnkEData = New HyperLink
            lnkEData.Text = "<Img src=""../../Images/Icons/Sync.gif"" border=0 alt=""" & ddlLabel.Items(40).Text & """>"
            lnkEData.NavigateUrl = "#"

            lnkEData.Attributes.Add("OnClick", "Synchronize('" & Replace(hidLocCur.Value, "\", "\\") & "','" & ddlLabel.Items(50).Text & "');")

            tblCell = New TableCell
            tblCell.Width = Unit.Pixel(32)
            tblCell.HorizontalAlign = HorizontalAlign.Left
            tblCell.Controls.Add(lnkEData)
            tblRow.Controls.Add(tblCell)

            ' Add upload icon
            lnkEData = New HyperLink
            lnkEData.Text = "<Img src=""../../Images/Icons/Upload.gif"" border=0 alt=""" & ddlLabel.Items(41).Text & """>"
            lnkEData.NavigateUrl = "#"

            Dim strLoc As String
            strLoc = Replace(hidLocCur.Value, "\", "\\")

            lnkEData.Attributes.Add("OnClick", "javascript:OpenWindow('WUpload.aspx?Location=" & strLoc & "',50,400,300,50)")

            tblCell = New TableCell
            tblCell.Width = Unit.Pixel(32)
            tblCell.HorizontalAlign = HorizontalAlign.Left
            tblCell.Controls.Add(lnkEData)
            tblRow.Controls.Add(tblCell)


            ' Add Create folder icon
            lnkEData = New HyperLink
            lnkEData.Text = "<Img src=""../../Images/Icons/createfolder.gif"" border=0 alt=""" & ddlLabel.Items(42).Text & """>"
            lnkEData.NavigateUrl = "#"

            lnkEData.Attributes.Add("OnClick", "CreateFolder('" & Replace(hidLocCur.Value, "\", "\\") & "', '" & ddlLabel.Items(46).Text & "','" & ddlLabel.Items(47).Text & "','" & ddlLabel.Items(112).Text & "');")

            tblCell = New TableCell
            tblCell.Width = Unit.Pixel(32)
            tblCell.HorizontalAlign = HorizontalAlign.Left
            tblCell.Controls.Add(lnkEData)
            tblRow.Controls.Add(tblCell)

            ' Add Rename folder icon
            lnkEData = New HyperLink
            lnkEData.Text = "<Img src=""../../Images/Icons/RenameFolder.gif"" border=0 alt=""" & ddlLabel.Items(43).Text & """>"
            lnkEData.NavigateUrl = "#"

            lnkEData.Attributes.Add("OnClick", "RenameFolder('" & Replace(hidLocCur.Value, "\", "\\") & "', '" & ddlLabel.Items(48).Text & "','" & ddlLabel.Items(49).Text & "','" & ddlLabel.Items(112).Text & "');")

            tblCell = New TableCell
            tblCell.Width = Unit.Pixel(32)
            tblCell.HorizontalAlign = HorizontalAlign.Left
            tblCell.Controls.Add(lnkEData)
            tblRow.Controls.Add(tblCell)

            ' Add Delete folder icon
            lnkEData = New HyperLink
            lnkEData.Text = "<Img src=""../../Images/Icons/deletefolder.gif"" border=0 alt=""" & ddlLabel.Items(44).Text & """>"
            lnkEData.NavigateUrl = "#"

            lnkEData.Attributes.Add("OnClick", "RemoveFolder('" & Replace(hidLocCur.Value, "\", "\\") & "','" & ddlLabel.Items(51).Text & "');")
            tblCell = New TableCell
            tblCell.Width = Unit.Pixel(32)
            tblCell.HorizontalAlign = HorizontalAlign.Left
            tblCell.Controls.Add(lnkEData)
            tblRow.Controls.Add(tblCell)

            ' Add Update Path icon
            imgIcon = New Image
            imgIcon.ImageUrl = "../../Images/Icons/update.gif"
            imgIcon.ToolTip = ddlLabel.Items(45).Text
            tblCell = New TableCell
            tblCell.Width = Unit.Pixel(32)
            tblCell.HorizontalAlign = HorizontalAlign.Left
            tblCell.Controls.Add(imgIcon)
            tblRow.Controls.Add(tblCell)

            ' Add to row
            tblNavigator.Controls.Add(tblRow)
        End Sub

        ' ShowListOfFiles method
        ' Purpose: show list of files
        Private Sub ShowFilesInListMode()
            If blnFound Then
                ' Show header
                Call ShowHeader()

                ' Show detail
                tblRow = New TableRow

                ' Add select column
                ' Fisrt, new checkbox
                chkEData = New HtmlInputCheckBox
                chkEData.ID = "chkCheckAll"
                chkEData.Attributes.Add("Class", "lbCheckBox")
                chkEData.Attributes.Add("OnClick", "MarkAll(this, " & intMax & ");")

                tblCell = New TableCell
                tblCell.HorizontalAlign = HorizontalAlign.Center
                tblCell.Width = Unit.Percentage(5)
                tblCell.Controls.Add(chkEData)
                tblRow.Cells.Add(tblCell)

                ' Add FileName Column
                tblCell = New TableCell
                tblCell.HorizontalAlign = HorizontalAlign.Center
                tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(0).Text))
                tblRow.Cells.Add(tblCell)

                ' Add Download Column
                tblCell = New TableCell
                tblCell.HorizontalAlign = HorizontalAlign.Center
                tblCell.Width = Unit.Percentage(5)
                tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(17).Text))
                tblRow.Cells.Add(tblCell)

                ' Add FileType Column
                tblCell = New TableCell
                tblCell.HorizontalAlign = HorizontalAlign.Center
                tblCell.Width = Unit.Percentage(9)
                tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(1).Text))
                tblRow.Cells.Add(tblCell)

                ' Add FileSize Column
                tblCell = New TableCell
                tblCell.HorizontalAlign = HorizontalAlign.Center
                tblCell.Width = Unit.Percentage(15)
                tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(2).Text))
                tblRow.Cells.Add(tblCell)

                ' Add attributes Column
                tblCell = New TableCell
                tblCell.HorizontalAlign = HorizontalAlign.Center
                tblCell.Width = Unit.Percentage(12)
                tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(12).Text))
                tblRow.Cells.Add(tblCell)

                ' Add CreatedDate Column
                tblCell = New TableCell
                tblCell.HorizontalAlign = HorizontalAlign.Center
                tblCell.Width = Unit.Percentage(8)
                tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(3).Text))
                tblRow.Cells.Add(tblCell)

                ' Add Status Column
                tblCell = New TableCell
                tblCell.HorizontalAlign = HorizontalAlign.Center
                tblCell.Width = Unit.Percentage(7)
                tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(7).Text))
                tblRow.Cells.Add(tblCell)

                ' Add SecretLevel Column
                tblCell = New TableCell
                tblCell.HorizontalAlign = HorizontalAlign.Center
                tblCell.Width = Unit.Percentage(7)
                tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(8).Text))
                tblRow.Cells.Add(tblCell)

                ' Add DownloadTime Column
                tblCell = New TableCell
                tblCell.HorizontalAlign = HorizontalAlign.Center
                tblCell.Width = Unit.Percentage(7)
                tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(9).Text))
                tblRow.Cells.Add(tblCell)

                ' Add Catalogue details Column
                tblCell = New TableCell
                tblCell.HorizontalAlign = HorizontalAlign.Center
                tblCell.Width = Unit.Percentage(7)
                tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(68).Text))
                tblRow.Cells.Add(tblCell)

                ' Add Free (Or Not Free) Column
                tblCell = New TableCell
                tblCell.HorizontalAlign = HorizontalAlign.Center
                tblCell.Width = Unit.Percentage(7)
                tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(69).Text))
                tblRow.Cells.Add(tblCell)

                ' Add header row to table
                tblRow.CssClass = "lbGridHeader"
                tblResult.Rows.Add(tblRow)

                ' Show back row
                If Not objDirInfor Is Nothing Then
                    If Not objDirInfor.Parent.FullName = "" Then
                        ' Show header
                        tblRow = New TableRow

                        tblCell = New TableCell
                        tblCell.HorizontalAlign = HorizontalAlign.Center
                        tblCell.Controls.Add(New LiteralControl(""))
                        tblRow.Cells.Add(tblCell)

                        ' Add FileName Column
                        lnkEData = New HyperLink
                        lnkEData.NavigateUrl = "WShowDetail.aspx?Loc=" & Trim(objDirInfor.Parent.FullName)
                        lnkEData.Text = "<Img src=""../../Images/Icons/ParentFolder.gif"" border=0> ..."
                        lnkEData.CssClass = "lbLinkFunction"

                        ' Add FolderName Column
                        tblCell = New TableCell
                        tblCell.HorizontalAlign = HorizontalAlign.Left
                        tblCell.Controls.Add(lnkEData)
                        tblCell.ColumnSpan = 12
                        tblRow.Cells.Add(tblCell)

                        ' Add this row to table
                        If bnlIsAlterRow Then
                            bnlIsAlterRow = False
                            tblRow.CssClass = "lbGridAlterCell"
                        Else
                            bnlIsAlterRow = True
                        End If
                        tblResult.Rows.Add(tblRow)
                    End If
                End If

                ' Show subfolder informations
                If Not objDirInfor Is Nothing Then
                    For Each objSubDirInfor In objDirInfor.GetDirectories
                        imgIcon = New Image
                        imgIcon.ImageUrl = "../../Images/Icons/folder.gif"

                        ' Show header
                        tblRow = New TableRow

                        tblCell = New TableCell
                        tblCell.HorizontalAlign = HorizontalAlign.Center
                        tblCell.Controls.Add(New LiteralControl(""))
                        tblRow.Cells.Add(tblCell)

                        ' Add Name Column
                        lnkEData = New HyperLink
                        lnkEData.NavigateUrl = "WShowDetail.aspx?Loc=" & Trim(objSubDirInfor.FullName)
                        lnkEData.Text = objSubDirInfor.Name
                        lnkEData.CssClass = "lbLinkFunction"

                        tblCell = New TableCell
                        tblCell.HorizontalAlign = HorizontalAlign.Left
                        tblCell.Controls.Add(imgIcon)
                        tblCell.Controls.Add(lnkEData)
                        tblRow.Cells.Add(tblCell)

                        ' Add Format Column
                        tblCell = New TableCell
                        tblCell.HorizontalAlign = HorizontalAlign.Left
                        tblCell.Controls.Add(New LiteralControl(""))
                        tblRow.Cells.Add(tblCell)

                        ' Add Type Column
                        tblCell = New TableCell
                        tblCell.HorizontalAlign = HorizontalAlign.Left
                        tblCell.Controls.Add(New LiteralControl(""))
                        tblRow.Cells.Add(tblCell)

                        ' Add Size Column
                        lblEData = New Label
                        lblEData.Text = ""
                        lblEData.CssClass = "lbLabel"

                        tblCell = New TableCell
                        tblCell.HorizontalAlign = HorizontalAlign.Right
                        tblCell.Controls.Add(lblEData)
                        tblRow.Cells.Add(tblCell)

                        ' Add Attribute Column
                        lnkEData = New HyperLink
                        lnkEData.Text = "<Img src=""../../Images/Icons/Edit.gif"" border=0 alt=""" & ddlLabel.Items(19).Text & """>"
                        lnkEData.NavigateUrl = "#"

                        lblEData = New Label
                        lblEData.Text = " " & GetAttributesDescription(objSubDirInfor.Attributes)
                        lblEData.CssClass = "lbLabelSpec"

                        tblCell = New TableCell
                        tblCell.HorizontalAlign = HorizontalAlign.Left
                        tblCell.Controls.Add(lnkEData)
                        tblCell.Controls.Add(lblEData)
                        tblCell.Attributes.Add("OnClick", "SetAttributes('" & EscDoubleQuote(Replace(objSubDirInfor.FullName, "\", "\\")) & "', '" & ddlLabel.Items(20).Text & "');")
                        tblRow.Cells.Add(tblCell)

                        ' Add CreatedDate Column
                        lblEData = New Label
                        lblEData.ID = ""
                        lblEData.Text = Left(CStr(objDirInfor.CreationTime), 10)
                        lblEData.CssClass = "lbLabel"

                        tblCell = New TableCell
                        tblCell.HorizontalAlign = HorizontalAlign.Center
                        tblCell.Controls.Add(lblEData)
                        tblRow.Cells.Add(tblCell)

                        ' Add Status Column
                        tblCell = New TableCell
                        tblCell.HorizontalAlign = HorizontalAlign.Center
                        tblCell.Controls.Add(New LiteralControl(""))
                        tblRow.Cells.Add(tblCell)

                        ' Add SecretLevel Column
                        tblCell = New TableCell
                        tblCell.HorizontalAlign = HorizontalAlign.Center
                        tblCell.Controls.Add(New LiteralControl(""))
                        tblRow.Cells.Add(tblCell)

                        ' Add DownloadTime Column
                        tblCell = New TableCell
                        tblCell.HorizontalAlign = HorizontalAlign.Center
                        tblCell.Controls.Add(New LiteralControl(""))
                        tblRow.Cells.Add(tblCell)

                        ' Add View Catalogue Detail Column
                        tblCell = New TableCell
                        tblCell.HorizontalAlign = HorizontalAlign.Center
                        tblCell.Controls.Add(New LiteralControl(""))
                        tblRow.Cells.Add(tblCell)

                        ' Add View Free or not Column
                        tblCell = New TableCell
                        tblCell.HorizontalAlign = HorizontalAlign.Center
                        tblCell.Controls.Add(New LiteralControl(""))
                        tblRow.Cells.Add(tblCell)

                        ' Add this row to table
                        If bnlIsAlterRow Then
                            bnlIsAlterRow = False
                            tblRow.CssClass = "lbGridAlterCell"
                        Else
                            bnlIsAlterRow = True
                        End If
                        tblResult.Rows.Add(tblRow)
                    Next
                End If

                ' Show file informations
                If Not tblEData Is Nothing Then
                    If tblEData.Rows.Count > 0 Then
                        For intCount = 0 To tblEData.Rows.Count - 1
                            Dim strItemID As String = ""
                            Dim strFileID As String = ""

                            strFileFullName = Trim(tblEData.Rows(intCount).Item("PhysicalPath"))
                            strFileName = Right(strFileFullName, Len(strFileFullName) - InStrRev(strFileFullName, "\"))
                            strFileExt = Right(strFileName, Len(strFileName) - InStrRev(strFileName, "."))
                            If Not IsDBNull(tblEData.Rows(intCount).Item("ItemID")) Then
                                strItemID = CStr(tblEData.Rows(intCount).Item("ItemID"))
                            End If

                            strFileID = CStr(tblEData.Rows(intCount).Item("ID"))

                            objFileInfor = New FileInfo(strFileFullName)

                            ' Get icon of the file extention
                            imgIcon = New Image
                            imgIcon.ImageUrl = "../../Images/Icons/" & LCase(strFileExt) & ".gif"

                            ' Show header
                            tblRow = New TableRow

                            ' Add select column
                            ' Fisrt, new checkbox
                            chkEData = New HtmlInputCheckBox
                            chkEData.ID = "chkFile" & intCount
                            chkEData.Value = tblEData.Rows(intCount).Item("ID")
                            chkEData.Attributes.Add("Class", "lbCheckBox")
                            chkEData.Attributes.Add("OnClick", "ClickMe(this);")

                            tblCell = New TableCell
                            tblCell.HorizontalAlign = HorizontalAlign.Center
                            tblCell.Controls.Add(chkEData)
                            tblRow.Cells.Add(tblCell)

                            ' Add name(download & edit) column
                            strTemp = "WDownload.aspx?FileID=" & tblEData.Rows(intCount).Item("ID")
                            lnkEData = New HyperLink

                            If CBool(tblEData.Rows(intCount).Item("Existed")) Then
                                lnkEData.Text = "<img src='../Js/jsmenu/transparent.gif' border=0 name=imgdoc" & tblEData.Rows(intCount).Item("ID") & " id=imgdoc" & tblEData.Rows(intCount).Item("ID") & ">"
                                lnkEData.Text = lnkEData.Text & "<A href='#' TARGET=""_new"" onmouseover=""ShowContextMenu(" & tblEData.Rows(intCount).Item("ID") & ")"" onmouseout=popdown()>"
                                lnkEData.Text = lnkEData.Text & strFileName & "</A>"
                                lnkEData.CssClass = "lbLinkFunction"
                                lnkEData.NavigateUrl = "#"
                                lnkEData.Attributes.Add("Onclick", "javascript:parent.HiddenDownload.location.href='" & strTemp & "';DownLoad('" & tblEData.Rows(intCount).Item("ID") & "');return false;")
                            Else
                                lnkEData.Text = strFileName
                                lnkEData.CssClass = "lbLinkFunction"
                            End If


                            tblCell = New TableCell
                            tblCell.HorizontalAlign = HorizontalAlign.Left
                            tblCell.Controls.Add(imgIcon)
                            tblCell.Controls.Add(lnkEData)
                            tblCell.ToolTip = ddlLabel.Items(18).Text
                            tblCell.Attributes.Add("Onclick", "javascript:parent.HiddenDownload.location.href='" & strTemp & "';DownLoad('" & tblEData.Rows(intCount).Item("ID") & "');return false;")
                            tblRow.Cells.Add(tblCell)

                            ' Add download column
                            lnkEData = New HyperLink
                            lnkEData.Text = "<Img src=""../../Images/Icons/Download.gif"" border=0>"
                            lnkEData.NavigateUrl = "#"
                            lnkEData.Attributes.Add("Onclick", "javascript:parent.HiddenDownload.location.href='" & strTemp & "';DownLoad('" & tblEData.Rows(intCount).Item("ID") & "');return false;")
                            tblCell = New TableCell
                            tblCell.HorizontalAlign = HorizontalAlign.Center
                            tblCell.ToolTip = ddlLabel.Items(17).Text
                            tblCell.Attributes.Add("OnClick", "javascript:parent.HiddenDownload.location.href='" & strTemp & "';DownLoad('" & tblEData.Rows(intCount).Item("ID") & "');return false;")
                            tblCell.Controls.Add(lnkEData)
                            tblRow.Cells.Add(tblCell)

                            ' Add Type Column
                            lblEData = New Label
                            lblEData.Text = strFileExt
                            lblEData.CssClass = "lbLabel"

                            ' MediaType
                            Select Case CInt(tblEData.Rows(intCount).Item("MediaType"))
                                Case 1
                                    strFileFormat = "image"
                                Case 2
                                    strFileFormat = "video"
                                Case 3
                                    strFileFormat = "sound"
                                Case 4
                                    strFileFormat = "document"
                                Case 5
                                    strFileFormat = "raster map"
                                Case 6
                                    strFileFormat = "program"
                                Case 7
                                    strFileFormat = "unknown"
                            End Select

                            ' Add Format Column
                            lblEData = New Label
                            lblEData.Text = strFileExt & "/" & strFileFormat
                            lblEData.CssClass = "lbLabel"

                            tblCell = New TableCell
                            tblCell.HorizontalAlign = HorizontalAlign.Left
                            tblCell.Controls.Add(lblEData)
                            tblRow.Cells.Add(tblCell)

                            ' Add Size Column
                            lblEData = New Label
                            lblEData.Text = FormatSize(tblEData.Rows(intCount).Item("FileSize"))
                            lblEData.CssClass = "lbLabel"

                            tblCell = New TableCell
                            tblCell.HorizontalAlign = HorizontalAlign.Right
                            tblCell.Controls.Add(lblEData)
                            tblRow.Cells.Add(tblCell)

                            ' Add Attribute Column
                            lnkEData = New HyperLink
                            lnkEData.Text = "<Img src=""../../Images/Icons/Edit.gif"" border=0>"
                            lnkEData.NavigateUrl = "#"
                            lblEData = New Label
                            lblEData.CssClass = "lbLabelSpec"

                            If objFileInfor.Exists Then
                                imgIcon.ToolTip = ddlLabel.Items(19).Text
                                strTemp = "SetAttributes('" & EscDoubleQuote(Replace(objFileInfor.FullName, "\", "\\")) & "', '" & ddlLabel.Items(20).Text & "');"
                                lblEData.Text = " " & GetAttributesDescription(objFileInfor.Attributes)
                            Else
                                imgIcon.Visible = False
                                strTemp = ""
                            End If

                            'imgIcon.Attributes.Add("OnClick", strTemp)
                            tblCell = New TableCell
                            tblCell.HorizontalAlign = HorizontalAlign.Left
                            tblCell.Controls.Add(lnkEData)
                            tblCell.Controls.Add(lblEData)
                            tblCell.Attributes.Add("OnClick", strTemp)
                            tblCell.ToolTip = imgIcon.ToolTip
                            tblRow.Cells.Add(tblCell)

                            ' Add CreatedDate Column
                            lblEData = New Label
                            lblEData.ID = ""
                            lblEData.Text = CStr(tblEData.Rows(intCount).Item("UPLOADEDDATE"))
                            lblEData.CssClass = "lbLabel"

                            tblCell = New TableCell
                            tblCell.HorizontalAlign = HorizontalAlign.Center
                            tblCell.Controls.Add(lblEData)
                            tblRow.Cells.Add(tblCell)

                            ' Add Status Column
                            strStatusComment = Trim(tblEData.Rows(intCount).Item("Status"))
                            imgIcon = New Image
                            imgIcon.ImageUrl = "../../Images/Icons/estat" & strStatusComment & ".gif"
                            Select Case CInt(strStatusComment)
                                Case 1
                                    imgIcon.ToolTip = ddlLabel.Items(13).Text
                                Case 2
                                    imgIcon.ToolTip = ddlLabel.Items(14).Text
                                Case 3
                                    imgIcon.ToolTip = ddlLabel.Items(15).Text
                                Case 4
                                    imgIcon.ToolTip = ddlLabel.Items(16).Text
                            End Select

                            tblCell = New TableCell
                            tblCell.HorizontalAlign = HorizontalAlign.Center
                            tblCell.Controls.Add(imgIcon)
                            tblCell.ToolTip = imgIcon.ToolTip
                            tblRow.Cells.Add(tblCell)

                            ' Add SecretLevel Column
                            tblCell = New TableCell
                            tblCell.HorizontalAlign = HorizontalAlign.Center
                            tblCell.Controls.Add(New LiteralControl(tblEData.Rows(intCount).Item("SecretLevel")))
                            tblRow.Cells.Add(tblCell)

                            ' Add DownloadTime Column
                            tblCell = New TableCell
                            tblCell.HorizontalAlign = HorizontalAlign.Center
                            tblCell.Controls.Add(New LiteralControl(tblEData.Rows(intCount).Item("DownloadTimes")))
                            tblRow.Cells.Add(tblCell)

                            ' Add View catalogue  details column
                            If Trim(strItemID) <> "" Then
                                lnkEData = New HyperLink
                                lnkEData.Text = "<Img src=""../../Images/Icons/details.gif"" border=0>"
                                lnkEData.NavigateUrl = "#"

                                tblCell = New TableCell
                                tblCell.HorizontalAlign = HorizontalAlign.Center
                                tblCell.ToolTip = ddlLabel.Items(72).Text
                                tblCell.Attributes.Add("OnClick", "javascript:openModal('" & "WCatalogueDetails.aspx?ItemID=" & strItemID & "','CatalogueDetails',700,500,100,50,'',';status=no',1)")
                                tblCell.Controls.Add(lnkEData)
                                tblRow.Cells.Add(tblCell)
                                hidAttachedIDs.Value = hidAttachedIDs.Value & tblEData.Rows(intCount).Item("ID") & ","
                            Else
                                tblCell = New TableCell
                                tblCell.HorizontalAlign = HorizontalAlign.Center
                                tblCell.Controls.Add(New LiteralControl(""))
                                tblRow.Cells.Add(tblCell)
                            End If

                            ' Add Show used mode
                            If CBool(tblEData.Rows(intCount).Item("Free")) = True Then
                                imgIcon = New Image
                                imgIcon.ImageUrl = "../../Images/Icons/free.gif"
                                tblCell = New TableCell
                                tblCell.HorizontalAlign = HorizontalAlign.Center
                                tblCell.ToolTip = ddlLabel.Items(76).Text
                                tblCell.Controls.Add(imgIcon)
                                tblRow.Cells.Add(tblCell)
                            Else
                                lnkEData = New HyperLink
                                lnkEData.Text = "<Img src=""../../Images/Icons/buy.jpg"" border=0>"
                                lnkEData.NavigateUrl = "#"
                                lnkEData.Attributes.Add("OnClick", "javascript:OpenWindow('WUpdateEdata.aspx?objID=" & strFileID & "','UpdateEdelivFile',600,250,50,50);")
                                tblCell = New TableCell
                                tblCell.HorizontalAlign = HorizontalAlign.Center
                                tblCell.ToolTip = ddlLabel.Items(75).Text
                                tblCell.Attributes.Add("OnClick", "javascript:OpenWindow('WUpdateEdata.aspx?objID=" & strFileID & "','UpdateEdelivFile',600,250,50,50);")
                                tblCell.Controls.Add(lnkEData)
                                tblRow.Cells.Add(tblCell)
                            End If

                            ' Add this row to table
                            If bnlIsAlterRow Then
                                bnlIsAlterRow = False
                                tblRow.CssClass = "lbGridAlterCell"
                            Else
                                bnlIsAlterRow = True
                            End If
                            tblResult.Rows.Add(tblRow)

                            intIndex = intIndex + 1
                        Next
                    End If
                End If
            End If
        End Sub

        ' ShowFilesInThumbnailMode method
        ' Purpose: show files in thumbnail mode
        Private Sub ShowFilesInThumbnailMode()
            Dim intPos1 As Integer = 0
            Dim intPos2 As Integer = 0
            Dim blnHasFiles As Boolean = False

            If Not tblEData Is Nothing Then
                If tblEData.Rows.Count > 0 Then
                    blnHasFiles = True
                End If
            End If

            If blnFound Then
                ' Show page header
                Call ShowHeader()
                ' Show folder informations

                tblResult.Width = Unit.Percentage(100)

                If Not objDirInfor Is Nothing Then
                    intPos1 = 1

                    ' Show back row
                    If Not objDirInfor.Parent.FullName = "" Then
                        If (intPos1 Mod 3) = 1 Then
                            If intPos1 = 1 Then ' new row
                                tblRow = New TableRow
                            Else
                                tblResult.Rows.Add(tblRow)
                                tblRow = New TableRow
                            End If
                        End If
                        intPos1 = intPos1 + 1

                        ' Show header

                        ' Add FileName Column
                        lnkEData = New HyperLink
                        lnkEData.NavigateUrl = "WShowDetail.aspx?Loc=" & Trim(objDirInfor.Parent.FullName)
                        lnkEData.Text = "<img src=""../../Images/Icons/ParentFolder.gif"" border=0> ..."
                        lnkEData.CssClass = "lbLinkFunction"

                        ' Add FolderName Column
                        tblCell = New TableCell
                        tblCell.Width = Unit.Percentage(100 / 3)
                        tblCell.HorizontalAlign = HorizontalAlign.Center
                        tblCell.Controls.Add(lnkEData)
                        tblRow.Cells.Add(tblCell)
                    End If

                    For Each objSubDirInfor In objDirInfor.GetDirectories
                        ' Add this row to table
                        If bnlIsAlterRow Then
                            bnlIsAlterRow = False
                            tblRow.CssClass = "lbGridAlterCell"
                        Else
                            bnlIsAlterRow = True
                        End If

                        imgIcon = New Image
                        imgIcon.ImageUrl = "../../Images/Icons/folder.gif"
                        If (intPos1 Mod 3) = 1 Then
                            If intPos1 = 1 Then ' new row
                                tblRow = New TableRow
                            Else
                                tblResult.Rows.Add(tblRow)
                                tblRow = New TableRow
                            End If
                        End If
                        intPos1 = intPos1 + 1

                        tblCell = New TableCell
                        tblCell.Width = Unit.Percentage(100 / 3)
                        tblCell.HorizontalAlign = HorizontalAlign.Center

                        ' Add folder's name 
                        lnkEData = New HyperLink
                        lnkEData.NavigateUrl = "WShowDetail.aspx?Loc=" & Trim(objSubDirInfor.FullName)
                        lnkEData.Text = objSubDirInfor.Name
                        lnkEData.CssClass = "lbLinkFunction"
                        lblEData = New Label
                        lblEData.Text = "<BR><BR>" & Left(CStr(objDirInfor.CreationTime), 15)
                        lblEData.CssClass = "lbLabel"

                        tblCell.Controls.Add(imgIcon)
                        tblCell.Controls.Add(lnkEData)
                        tblCell.Controls.Add(lblEData)
                        tblRow.Cells.Add(tblCell)
                    Next

                    If intPos1 > 3 And blnHasFiles Then
                        While Not (intPos1 Mod 3) = 1
                            If bnlIsAlterRow Then
                                bnlIsAlterRow = False
                                tblRow.CssClass = "lbGridAlterCell"
                            Else
                                bnlIsAlterRow = True
                            End If
                            tblCell = New TableCell
                            tblCell.Width = Unit.Percentage(100 / 3)
                            tblRow.Cells.Add(tblCell)
                            tblResult.Rows.Add(tblRow)
                            intPos1 = intPos1 + 1
                        End While
                    End If
                End If

                If intPos1 = 0 Then
                    intPos1 = 1
                End If

                ' Show file informations
                If blnHasFiles Then
                    ' For intCount = 0 + intPos2 To tblEData.Rows.Count - 1 + intPos2
                    For intCount = 0 To tblEData.Rows.Count - 1
                        If (intPos1 Mod 3) = 1 Then
                            If intPos1 = 1 Then ' new row
                                tblRow = New TableRow
                            Else
                                tblResult.Rows.Add(tblRow)
                                tblRow = New TableRow
                            End If
                        End If

                        strFileFullName = Trim(tblEData.Rows(intCount).Item("PhysicalPath"))
                        strFileName = " " & Right(strFileFullName, Len(strFileFullName) - InStrRev(strFileFullName, "\"))
                        strFileExt = Right(strFileName, Len(strFileName) - InStrRev(strFileName, "."))
                        objFileInfor = New FileInfo(strFileFullName)

                        ' Show header
                        tblCell = New TableCell
                        tblCell.Width = Unit.Percentage(100 / 3)
                        tblCell.HorizontalAlign = HorizontalAlign.Center

                        ' Show image or first frame of video
                        Select Case LCase(strFileExt)
                            Case "jpg", "bmp", "png", "jpeg", "gif", "pcx", "tif", "jpe"
                                imgIcon = New Image
                                imgIcon.ImageUrl = "WShowImage.aspx?ShowPic=1&FileID=" & tblEData.Rows(intCount).Item("ID")
                                tblCell.Controls.Add(imgIcon)
                                tblCell.Controls.Add(New LiteralControl("<BR>"))
                            Case "mpg", "avi", "asf", "mpeg", "mov", "flc", "mpv", "swf"
                                imgIcon = New Image
                                imgIcon.ImageUrl = "WShowImage.aspx?FileID=" & tblEData.Rows(intCount).Item("ID")
                                tblCell.Controls.Add(imgIcon)
                                tblCell.Controls.Add(New LiteralControl("<BR>"))
                        End Select

                        ' Get icon of the file extention
                        imgIcon = New Image
                        imgIcon.ImageUrl = "../../Images/Icons/" & LCase(strFileExt) & ".gif"

                        ' Add select column
                        ' Fisrt, new checkbox
                        chkEData = New HtmlInputCheckBox
                        chkEData.ID = "chkFile" & intCount
                        'chkEData.Value = strFileName
                        chkEData.Value = tblEData.Rows(intCount).Item("ID")
                        chkEData.Attributes.Add("Class", "lbCheckBox")
                        chkEData.Attributes.Add("OnClick", "ClickMe(this);")

                        tblCell.Controls.Add(chkEData)

                        ' Add name(download & edit)
                        strTemp = "WDownload.aspx?FileID=" & tblEData.Rows(intCount).Item("ID")
                        lnkEData = New HyperLink
                        lnkEData.NavigateUrl = "#"
                        lnkEData.Attributes.Add("Onclick", "javascript:parent.HiddenDownload.location.href='" & strTemp & "';DownLoad('" & tblEData.Rows(intCount).Item("ID") & "');return false;")
                        'lnkEData.NavigateUrl = "javascript:OpenWindow('" & strTemp & "','DownloadFile',800,600,0,0);DownLoad('" & tblEData.Rows(intCount).Item("ID") & "');"
                        lnkEData.Text = strFileName
                        lnkEData.CssClass = "lbLinkFunction"

                        tblCell.Controls.Add(imgIcon)
                        tblCell.Controls.Add(lnkEData)
                        tblCell.ToolTip = ddlLabel.Items(18).Text

                        ' Add relate item
                        If Not IsDBNull(tblEData.Rows(intCount).Item("ItemID")) Then
                            strTemp = strTemp & "<BR>" & ddlLabel.Items(30).Text & ": " & tblEData.Rows(intCount).Item("ItemID")
                            imgIcon = New Image

                            lnkEData = New HyperLink
                            lnkEData.Text = "<Img src=""../../Images/Icons/details.gif"" border=0 alt="" & ddlLabel.Items(72).Text & "">"
                            lnkEData.NavigateUrl = "#"

                            lnkEData.Attributes.Add("OnClick", "javascript:openModal('" & "WCatalogueDetails.aspx?ItemID=" & tblEData.Rows(intCount).Item("ItemID") & "','CatalogueDetails',700,500,100,50,'',';status=no',1)")
                            tblCell.Controls.Add(lnkEData)
                            hidAttachedIDs.Value = hidAttachedIDs.Value & tblEData.Rows(intCount).Item("ID") & ","
                        End If

                        strTemp = ""
                        ' Add Size
                        strTemp = strTemp & "<BR>" & ddlLabel.Items(2).Text & ": " & FormatSize(tblEData.Rows(intCount).Item("FileSize"))
                        ' Add CreatedDate
                        strTemp = strTemp & "<BR>" & ddlLabel.Items(3).Text & ": " & CStr(tblEData.Rows(intCount).Item("UPLOADEDDATE"))
                        ' Add Creator
                        strTemp = strTemp & "<BR>" & ddlLabel.Items(33).Text & ": " & CStr(tblEData.Rows(intCount).Item("UPLOADEDBY"))

                        ' Add multimedia data
                        Select Case CInt(tblEData.Rows(intCount).Item("MediaType"))
                            Case 1, 5 ' Image, map
                                If Not IsDBNull(tblEData.Rows(intCount).Item("BitmapType")) Then
                                    strTemp = strTemp & "<BR>" & ddlLabel.Items(22).Text & ": " & CStr(tblEData.Rows(intCount).Item("BitmapType"))
                                End If
                                If Not IsDBNull(tblEData.Rows(intCount).Item("ColorModel")) Then
                                    strTemp = strTemp & "<BR>" & ddlLabel.Items(23).Text & ": " & CStr(tblEData.Rows(intCount).Item("ColorModel"))
                                End If
                                If Not IsDBNull(tblEData.Rows(intCount).Item("ImgWidth")) Then
                                    strTemp = strTemp & "<BR>" & ddlLabel.Items(24).Text & ": " & CStr(tblEData.Rows(intCount).Item("ImgWidth")) & " x " & CStr(tblEData.Rows(intCount).Item("ImgHeight")) & " px"
                                End If
                                If Not IsDBNull(tblEData.Rows(intCount).Item("Xdpi")) Then
                                    strTemp = strTemp & "<BR>" & ddlLabel.Items(25).Text & ": " & CStr(tblEData.Rows(intCount).Item("Xdpi")) & " x " & CStr(tblEData.Rows(intCount).Item("Ydpi")) & " dpi"
                                End If
                                If Not IsDBNull(tblEData.Rows(intCount).Item("NoColorUsed")) Then
                                    strTemp = strTemp & "<BR>" & ddlLabel.Items(26).Text & ": " & CStr(tblEData.Rows(intCount).Item("NoColorUsed"))
                                End If
                            Case 2 ' video
                                If Not IsDBNull(tblEData.Rows(intCount).Item("ImgWidth")) Then
                                    strTemp = strTemp & "<BR>" & ddlLabel.Items(24).Text & ": " & CStr(tblEData.Rows(intCount).Item("ImgWidth")) & " x " & CStr(tblEData.Rows(intCount).Item("ImgHeight")) & " px"
                                End If
                                If Not IsDBNull(tblEData.Rows(intCount).Item("Duration")) Then
                                    strTemp = strTemp & "<BR>" & ddlLabel.Items(27).Text & ": " & CStr(tblEData.Rows(intCount).Item("Duration"))
                                End If
                            Case 3 ' audio
                                If Not IsDBNull(tblEData.Rows(intCount).Item("Album")) Then
                                    strTemp = strTemp & "<BR>" & ddlLabel.Items(28).Text & ": " & CStr(tblEData.Rows(intCount).Item("Album"))
                                End If
                                If Not IsDBNull(tblEData.Rows(intCount).Item("Artist")) Then
                                    strTemp = strTemp & "<BR>" & ddlLabel.Items(29).Text & ": " & CStr(tblEData.Rows(intCount).Item("Artist"))
                                End If
                                If Not IsDBNull(tblEData.Rows(intCount).Item("BitRate")) Then
                                    strTemp = strTemp & "<BR>" & ddlLabel.Items(30).Text & ": " & CStr(tblEData.Rows(intCount).Item("BitRate"))
                                End If
                                If Not IsDBNull(tblEData.Rows(intCount).Item("Duration")) Then
                                    strTemp = strTemp & "<BR>" & ddlLabel.Items(27).Text & ": " & CStr(tblEData.Rows(intCount).Item("Duration"))
                                End If
                                If Not IsDBNull(tblEData.Rows(intCount).Item("Genre")) Then
                                    strTemp = strTemp & "<BR>" & ddlLabel.Items(31).Text & ": " & CStr(tblEData.Rows(intCount).Item("Genre"))
                                End If
                            Case 4 ' Doc
                                If Not IsDBNull(tblEData.Rows(intCount).Item("PageCount")) Then
                                    strTemp = strTemp & "<BR>" & ddlLabel.Items(32).Text & ": " & CStr(tblEData.Rows(intCount).Item("PageCount"))
                                End If
                        End Select

                        lblEData = New Label
                        lblEData.Text = strTemp
                        lblEData.CssClass = "lbLabel"

                        ' Add above string to cell
                        tblCell.Controls.Add(lblEData)

                        ' Add Free Or Not
                        ' Add Show circulation mode
                        If CBool(tblEData.Rows(intCount).Item("Free")) = True Then
                            imgIcon = New Image
                            imgIcon.ImageUrl = "../../Images/Icons/free.gif"
                            imgIcon.ToolTip = ddlLabel.Items(76).Text
                            lblEData = New Label
                            lblEData.Text = "<BR>" & ddlLabel.Items(69).Text & ": "
                            lblEData.CssClass = "lbLabel"
                            tblCell.Controls.Add(lblEData)
                            tblCell.Controls.Add(imgIcon)
                        Else
                            lnkEData = New HyperLink
                            lnkEData.Text = "<Img src=""../../Images/Icons/buy.jpg"" border=0>"
                            lnkEData.NavigateUrl = "#"
                            lnkEData.Attributes.Add("OnClick", "javascript:OpenWindow('WUpdateEdata.aspx?objID=" & tblEData.Rows(intCount).Item("ID") & "','UpdateEdelivFile',600,250,50,50);")
                            lblEData = New Label
                            lblEData.Text = "<BR>" & ddlLabel.Items(75).Text & ": "
                            lblEData.CssClass = "lbLabel"
                            tblCell.Controls.Add(lblEData)
                            tblCell.Controls.Add(lnkEData)
                        End If

                        tblRow.Cells.Add(tblCell)

                        ' Add this row to table
                        If bnlIsAlterRow Then
                            bnlIsAlterRow = False
                            tblRow.CssClass = "lbGridAlterCell"
                        Else
                            bnlIsAlterRow = True
                        End If
                        intPos1 = intPos1 + 1
                    Next

                    If bnlIsAlterRow Then
                        bnlIsAlterRow = False
                        tblCell.CssClass = "lbGridAlterCell"
                    Else
                        bnlIsAlterRow = True
                    End If

                    tblResult.Rows.Add(tblRow)
                End If
            End If
        End Sub

        Private Sub ShowHeader()
            Dim strTotalFilesInDB As String = ddlLabel.Items(35).Text
            Dim strTotalFilesInFS As String = ddlLabel.Items(36).Text

            strTemp = ""
            If lngTotalRec > 0 Then
                tblRow = New TableRow

                ' Show total of files (in DataBase & FileSystem)
                strTemp = strTemp & "<UL>" & Chr(13)
                strTemp = strTemp & "<LI>" & strTotalFilesInDB & ": <B>" & lngTotalRec & "</B></LI>" & Chr(13)
                If Not objDirInfor Is Nothing Then
                    strTemp = strTemp & "<LI>" & strTotalFilesInFS & ": <B>" & objDirInfor.GetFiles.Length & "</B></LI>" & Chr(13)
                End If
                strTemp = strTemp & "</UL>" & Chr(13)

                lblEData = New Label
                lblEData.ID = "lblTotalFiles"
                lblEData.Text = strTemp
                lblEData.CssClass = "lbLabel"

                tblCell = New TableCell
                tblCell.HorizontalAlign = HorizontalAlign.Left
                tblCell.VerticalAlign = VerticalAlign.Bottom
                tblCell.Width = Unit.Percentage(45)
                tblCell.Controls.Add(lblEData)
                tblRow.Cells.Add(tblCell)

                ' Add to current row
                tblHeader.Rows.Add(tblRow)

                ' Show page links
                intNumOfPages = Ceiling(lngTotalRec / 50)
                If Not Request("CurrPage") = "" Then
                    intCurrPage = CInt(Request("CurrPage"))
                    If intCurrPage > intNumOfPages Then
                        If Not InStr(strURL, "?") > 0 Then
                            If Request("Search") & "" <> "" Then
                                If intNumOfPages > 1 Then
                                    Response.Redirect(strURL & "?CurrPage=" & intCurrPage - 1 & "&Search=1")
                                Else
                                    Response.Redirect(strURL & "?Search=1")
                                End If
                            Else
                                If intNumOfPages > 1 Then
                                    Response.Redirect(strURL & "?CurrPage=" & intCurrPage - 1)
                                Else
                                    Response.Redirect(strURL)
                                End If

                            End If
                        Else
                            If Request("Search") & "" <> "" Then
                                If intNumOfPages > 1 Then
                                    Response.Redirect(strURL & "&CurrPage=" & intCurrPage - 1 & "&Search=1")
                                Else
                                    Response.Redirect(strURL & "&Search=1")
                                End If
                            Else
                                If intNumOfPages > 1 Then
                                    Response.Redirect(strURL & "&CurrPage=" & intCurrPage - 1)
                                Else
                                    Response.Redirect(strURL)
                                End If
                            End If
                        End If
                    End If
                End If

                lblEData = New Label
                lblEData.ID = "lblPages"
                lblEData.Text = ddlLabel.Items(21).Text & ": "
                lblEData.CssClass = "lbLabel"

                ' Show page links
                tblRow = New TableRow
                tblCell = New TableCell
                tblCell.HorizontalAlign = HorizontalAlign.Left
                tblCell.Controls.Add(lblEData)
                For intIndex = 1 To intNumOfPages
                    tblCell.Controls.Add(New LiteralControl(" "))
                    If intCurrPage = intIndex Then
                        lblEData = New Label
                        lblEData.ID = "lblPage" & intIndex
                        lblEData.Text = intIndex
                        lblEData.CssClass = "lbLabel"
                        tblCell.Controls.Add(lblEData)
                    Else
                        lnkEData = New HyperLink
                        lnkEData.ID = "lnkPage" & intIndex
                        lnkEData.Text = intIndex
                        If Not InStr(strURL, "?") > 0 Then
                            If Request("Search") & "" <> "" Then
                                If intNumOfPages < intCurrPage Then
                                    If intNumOfPages > 1 Then
                                        Response.Redirect(strURL & "?CurrPage=" & intCurrPage - 1 & "&Search=1")
                                    Else
                                        Response.Redirect(strURL & "?Search=1")
                                    End If
                                Else
                                    lnkEData.NavigateUrl = strURL & "?CurrPage=" & intIndex & "&Search=1"
                                End If
                            Else
                                If intNumOfPages < intCurrPage Then
                                    If intNumOfPages > 1 Then
                                        Response.Redirect(strURL & "?CurrPage=" & intCurrPage - 1)
                                    Else
                                        Response.Redirect(strURL)
                                    End If
                                Else
                                    lnkEData.NavigateUrl = strURL & "?CurrPage=" & intIndex
                                End If
                            End If
                        Else
                            If Request("Search") & "" <> "" Then
                                If intNumOfPages < intCurrPage Then
                                    If intNumOfPages > 1 Then
                                        Response.Redirect(strURL & "&CurrPage=" & intCurrPage - 1 & "&Search=1")
                                    Else
                                        Response.Redirect(strURL & "&Search=1")
                                    End If
                                Else
                                    lnkEData.NavigateUrl = strURL & "&CurrPage=" & intIndex & "&Search=1"
                                End If
                            Else
                                If intNumOfPages < intCurrPage Then
                                    If intNumOfPages > 1 Then
                                        Response.Redirect(strURL & "&CurrPage=" & intCurrPage - 1)
                                    Else
                                        Response.Redirect(strURL)
                                    End If
                                Else
                                    lnkEData.NavigateUrl = strURL & "&CurrPage=" & intIndex
                                End If
                            End If
                        End If
                        lnkEData.CssClass = "lbLinkFunction"
                        tblCell.Controls.Add(lnkEData)
                    End If
                    tblRow.Cells.Add(tblCell)
                Next
                ' Add to current row
                tblPaging.Rows.Add(tblRow)
            Else
                tblRow = New TableRow

                ' Show total of files (in DataBase & FileSystem)
                strTemp = strTemp & "<UL>" & Chr(13)
                strTemp = strTemp & "<LI>" & strTotalFilesInDB & ": <B>0</B></LI>" & Chr(13)
                If Not objDirInfor Is Nothing Then
                    strTemp = strTemp & "<LI>" & strTotalFilesInFS & ": <B>" & objDirInfor.GetFiles.Length & "</B></LI>" & Chr(13)
                End If
                strTemp = strTemp & "</UL>" & Chr(13)

                lblEData = New Label
                lblEData.ID = "lblTotalFiles"
                lblEData.Text = strTemp
                lblEData.CssClass = "lbLabel"

                tblCell = New TableCell
                tblCell.HorizontalAlign = HorizontalAlign.Left
                tblCell.VerticalAlign = VerticalAlign.Bottom
                tblCell.Width = Unit.Percentage(45)
                tblCell.Controls.Add(lblEData)
                tblRow.Cells.Add(tblCell)

                ' Add to current row
                tblHeader.Rows.Add(tblRow)
            End If

            strTemp = ""
        End Sub

        ' SetAttributes method
        Protected Sub SetAttributes()
            Dim strLoc As String = hidLoc.Value
            Dim strAttributes As String = hidAttr.Value.ToUpper()
            Dim fileAttributes As fileAttributes = fileAttributes.Normal

            ' Search the 'A' (Archive) attribute in the descriptive string
            If strAttributes.IndexOf("A") > -1 Then
                fileAttributes = fileAttributes Or fileAttributes.Archive
            End If

            ' Search the 'R' (ReadOnly) attribute in the descriptive string
            If strAttributes.IndexOf("R") > -1 Then
                fileAttributes = fileAttributes Or fileAttributes.ReadOnly
            End If

            ' Search the 'H' (Archive) attribute in the descriptive string
            If strAttributes.IndexOf("H") > -1 Then
                fileAttributes = fileAttributes Or fileAttributes.Hidden
            End If

            ' Search the 'S' (ReadOnly) attribute in the descriptive string
            If strAttributes.IndexOf("S") > -1 Then
                fileAttributes = fileAttributes Or fileAttributes.System
            End If

            ' Set the new strAttributes. This works with directories as well.
            File.SetAttributes(strLoc, fileAttributes)
        End Sub

        ' GetAttributesDescription method
        ' Purpose: get strAttributes
        ' Input: strAttributes
        Protected Function GetAttributesDescription(ByVal attributes As FileAttributes) As String
            Dim strAttributes As String = ""

            ' Check if the 'Archive' attribute is set 
            If ((attributes And FileAttributes.Archive) = FileAttributes.Archive) Then
                strAttributes = strAttributes & "A"
            Else
                strAttributes = strAttributes & "&nbsp;"
            End If

            ' Check if the 'ReadOnly' attribute is set 
            If ((attributes And FileAttributes.ReadOnly) = FileAttributes.ReadOnly) Then
                strAttributes = strAttributes & "R"
            Else
                strAttributes = strAttributes & "&nbsp;"
            End If

            ' Check if the 'Hidden' attribute is set 
            If ((attributes And FileAttributes.Hidden) = FileAttributes.Hidden) Then
                strAttributes = strAttributes & "H"
            Else
                strAttributes = strAttributes & "&nbsp;"
            End If

            ' Check if the 'System' attribute is set 
            If ((attributes And FileAttributes.System) = FileAttributes.System) Then
                strAttributes = strAttributes & "S"
            Else
                strAttributes = strAttributes & "&nbsp;"
            End If

            Return strAttributes

        End Function

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub
    End Class
End Namespace