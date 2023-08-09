Imports System.Math
Imports System.IO
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WShowDetail
        Inherits clsWEData

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

        Private objBCDBS As New clsBCommonDBSystem

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            strURL = Request.ServerVariables("SCRIPT_NAME")
            Call Initialize()
            Call Inti_Edata()
            Call BindScript()

            ' Do the actions
            Select Case hidFunc.Value
                Case "DownLoad"
                    strIDs = hidLoc.Value
                    Call DownLoad()
                    Call BindData()
                    hidFunc.Value = ""
                    hidLoc.Value = ""
            End Select

            ddlView.Visible = True
            lblView.Visible = True

            ' Check the display type by directories or not
            If Not Request("Loc") & "" = "" Then
                Call CheckDirectories(Request("Loc"))
            End If

            If Not Page.IsPostBack Then
                If Request("FieldCode") = 856 Then
                    lblFreePageTitle.Visible = True
                    lblNotFreePageTitle.Visible = False
                Else
                    lblFreePageTitle.Visible = False
                    lblNotFreePageTitle.Visible = True
                End If
                Call BindData()
            End If
        End Sub

        Public Sub Inti_Edata()
            ' Init objBCommon object
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.Initialize()
        End Sub
        ' CheckDirectories method
        ' Purpose: check directories is belog the system dirs or not
        Public Sub CheckDirectories(ByVal strLoc As String, Optional ByVal blnAlert As Boolean = False)
            If CheckSysDir(strLoc) = False Then
                If blnAlert = True Then
                    Page.RegisterClientScriptBlock("InValidDir", "<script language = 'javascript'>alert('" & ddlLabel.Items(43).Text & "');</script>")
                Else
                    Response.Write("<CENTER><H2><FONT COLOR=""RED"">" & ddlLabel.Items(43).Text & "</FONT></H2></CENTER>")
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
        End Sub

        ' BindScript method
        ' Purpose: Include all neccessary javascript functions
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/Catalogue/WShowDetail.js'></script>")
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

        ' PrepareVariables method
        ' Purpose: prepare class variables & get data
        Private Sub PrepareVariables()
            If Not Request("Loc") = "" Then
                strParam = Trim(Request.Params("Loc"))
                strLocation = strParam
                If Not InStr(strURL, "?") > 0 Then
                    strURL = strURL & "?Loc=" & strParam & "&FieldCode=" & Request("FieldCode") & "&Repeatable=" & Request("Repeatable") & "&WField=" & Request("WField") & "&SField=" & Request("SField")
                Else
                    strURL = strURL & "&Loc=" & strParam & "&FieldCode=" & Request("FieldCode") & "&Repeatable=" & Request("Repeatable") & "&WField=" & Request("WField") & "&SField=" & Request("SField")
                End If
                intListType = 4
            End If

            If Not Request("ViewType") = "" Then
                intListType = CInt(Request("ViewType"))
                If Not InStr(strURL, "?") > 0 Then
                    strURL = strURL & "?ViewType=" & strParam & "&FieldCode=" & Request("FieldCode") & "&Repeatable=" & Request("Repeatable") & "&WField=" & Request("WField") & "&SField=" & Request("SField")
                Else
                    strURL = strURL & "&ViewType=" & strParam & "&FieldCode=" & Request("FieldCode") & "&Repeatable=" & Request("Repeatable") & "&WField=" & Request("WField") & "&SField=" & Request("SField")
                End If
            End If

            If Not Request("Type") = "" Then
                strParam = Request("Type")
                If Not InStr(strURL, "?") > 0 Then
                    strURL = strURL & "?Type=" & strParam & "&FieldCode=" & Request("FieldCode") & "&Repeatable=" & Request("Repeatable") & "&WField=" & Request("WField") & "&SField=" & Request("SField")
                Else
                    strURL = strURL & "&Type="
                End If
            End If

            If Not Request("CollectionID") = "" Then
                intCollectionID = CInt(Request("CollectionID"))
                If Not InStr(strURL, "?") > 0 Then
                    strURL = strURL & "?CollectionID=" & intCollectionID & "&FieldCode=" & Request("FieldCode") & "&Repeatable=" & Request("Repeatable") & "&WField=" & Request("WField") & "&SField=" & Request("SField")
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

            Dim intFree As Integer = 1

            If Request("CurrPage") = "" Then
                lngStartID = 0
            Else
                'If Request("FieldCode") = 856 Then
                '    intFree = 1
                'Else
                '    intFree = 0
                'End If
                lngStartID = GetMaxIDByTopNum(intListType, 50 * (CInt(Request("CurrPage")) - 1), intFree)
            End If

            ' Get data
            intViewMode = Session("ViewMode")

            'If Request("FieldCode") = 856 Then
            '    intFree = 1
            'Else
            '    intFree = 0
            'End If

            tblEData = GetGeneralInfor(intMode, intListType, intViewMode, lngTotalRec, intFree)

            If Not Request("Search") & "" = "" Then
                Dim tblSearch As DataTable
                Dim strSQLStatement As String
                If Not Session("SQLStatement") = "" Then
                    strSQLStatement = "SELECT COUNT(*) FROM CAT_EDATA_FILE WHERE ID IN(" & Session("SQLStatement") & ")"
                    tblSearch = GetEdataSearchCount(strSQLStatement)
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
                Else
                    If Not Request("Search") & "" = "" Then
                        Page.RegisterClientScriptBlock("NotFound", "<script language='javascript'>alert('" & ddlLabel.Items(5).Text & "');</script>")
                    End If
                End If
            Else
                If Not Request("Search") & "" = "" Then
                    Page.RegisterClientScriptBlock("NotFound", "<script language='javascript'>alert('" & ddlLabel.Items(5).Text & "');</script>")
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

        ' ShowListOfFiles method
        ' Purpose: show list of files
        Private Sub ShowFilesInListMode()
            If blnFound Then
                ' Show header
                Call ShowHeader()

                ' Show detail
                tblRow = New TableRow

                ' Add select column
                tblCell = New TableCell
                tblCell.HorizontalAlign = HorizontalAlign.Center
                tblCell.Width = Unit.Percentage(5)
                tblCell.Controls.Add(New LiteralControl(""))
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
                tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(39).Text))
                tblRow.Cells.Add(tblCell)

                ' Add Free (Or Not Free) Column
                tblCell = New TableCell
                tblCell.HorizontalAlign = HorizontalAlign.Center
                tblCell.Width = Unit.Percentage(7)
                tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(40).Text))
                tblRow.Cells.Add(tblCell)

                ' Add header row to table
                tblRow.CssClass = "lbGridHeader"
                tblResult.Rows.Add(tblRow)

                ' Show back row
                If Not objDirInfor Is Nothing Then
                    If Not objDirInfor.Parent.FullName = "" Then
                        imgIcon = New Image
                        imgIcon.ImageUrl = "../../Images/Icons/ParentFolder.gif"

                        ' Show header
                        tblRow = New TableRow

                        tblCell = New TableCell
                        tblCell.HorizontalAlign = HorizontalAlign.Center
                        tblCell.Controls.Add(New LiteralControl(""))
                        tblRow.Cells.Add(tblCell)

                        ' Add FileName Column
                        lnkEData = New HyperLink
                        lnkEData.NavigateUrl = "WShowDetail.aspx?Loc=" & Trim(objDirInfor.Parent.FullName) & strParam & "&FieldCode=" & Request("FieldCode") & "&Repeatable=" & Request("Repeatable") & "&WField=" & Request("WField") & "&SField=" & Request("SField")
                        lnkEData.Text = " ..."
                        lnkEData.CssClass = "lbLinkFunction"

                        ' Add FolderName Column
                        tblCell = New TableCell
                        tblCell.HorizontalAlign = HorizontalAlign.Left
                        tblCell.Controls.Add(imgIcon)
                        tblCell.Controls.Add(lnkEData)
                        tblCell.ColumnSpan = 11
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
                        lnkEData.NavigateUrl = "WShowDetail.aspx?Loc=" & Trim(objSubDirInfor.FullName) & "&FieldCode=" & Request("FieldCode") & "&Repeatable=" & Request("Repeatable") & "&WField=" & Request("WField") & "&SField=" & Request("SField")
                        lnkEData.Text = objSubDirInfor.Name
                        lnkEData.CssClass = "lbLinkFunction"

                        tblCell = New TableCell
                        tblCell.HorizontalAlign = HorizontalAlign.Left
                        tblCell.Controls.Add(imgIcon)
                        tblCell.Controls.Add(lnkEData)
                        tblRow.Cells.Add(tblCell)

                        ' Add Download Column
                        tblCell = New TableCell
                        tblCell.HorizontalAlign = HorizontalAlign.Left
                        tblCell.Controls.Add(New LiteralControl(""))
                        tblRow.Cells.Add(tblCell)

                        ' Add File Type Column
                        tblCell = New TableCell
                        tblCell.HorizontalAlign = HorizontalAlign.Left
                        tblCell.Controls.Add(New LiteralControl(""))
                        tblRow.Cells.Add(tblCell)

                        ' Add Size Column
                        lblEData = New Label
                        lblEData.Text = ""
                        lblEData.CssClass = "lbLabel"

                        tblCell = New TableCell
                        tblCell.HorizontalAlign = HorizontalAlign.Center
                        tblCell.Controls.Add(lblEData)
                        tblRow.Cells.Add(tblCell)

                        ' Add CreatedDate Column
                        tblCell = New TableCell
                        tblCell.HorizontalAlign = HorizontalAlign.Left
                        tblCell.Controls.Add(New LiteralControl(""))
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
                            ' Select the Item
                            Dim lnk As New HyperLink
                            lnk.Text = "<img src=""../../Images/select.jpg"" border=""0"">"
                            lnk.ToolTip = ddlLabel.Items(42).Text
                            Dim strJS As String = ""
                            Dim strFieldCode As String = ""
                            Dim strURLShowOpac As String = "WDownLoad.aspx?FileID="
                            If Request("FieldCode") = "907" Then
                                strURLShowOpac = "ShowContent.aspx?FileID="
                            Else
                                Dim tblAttFile As New DataTable
                                Select Case Session("DBServer")
                                    Case "SQLSERVER"
                                        objBCDBS.SQLStatement = "SELECT CASE LEN(FieldCode)WHEN 3 THEN FieldCode + '##'	ELSE FieldCode	END AS FieldCode FROM Lib_tblMARCBibField WHERE FieldTypeID = 4 AND (FieldCode = '" & Request("FieldCode") & " ' OR ParentFieldCode IN (SELECT FieldCode FROM Lib_tblMARCBibField WHERE FieldCode = '" & Request("FieldCode") & "'))"
                                    Case Else
                                        objBCDBS.SQLStatement = "SELECT CASE LENGTH(FieldCode)WHEN 3 THEN FieldCode || '##'	ELSE FieldCode	END AS FieldCode FROM Lib_tblMARCBibField WHERE FieldTypeID = 4 AND (FieldCode = '" & Request("FieldCode") & "' OR ParentFieldCode IN (SELECT FieldCode FROM Lib_tblMARCBibField WHERE FieldCode = '" & Request("FieldCode") & "'))"
                                End Select
                                tblAttFile = objBCDBS.RetrieveItemInfor
                                If Not tblAttFile Is Nothing AndAlso tblAttFile.Rows.Count > 0 Then
                                    strFieldCode = Right(tblAttFile.Rows(0).Item(0), 2).Replace("##", "")
                                End If

                                Dim strTempURLOpac As String = GetOneParaSystem("OPAC_URL")
                                If Not Right(strTempURLOpac, 1) = "/" Then
                                    strTempURLOpac = strTempURLOpac & "/"
                                End If
                                strURLShowOpac = strTempURLOpac & strURLShowOpac
                            End If

                            ' Request("Repeatable")
                            If Request.QueryString("Repeatable") = 1 Then
                                strJS = strJS & "if (confirm('" & ddlLabel.Items(38).Text & "')) {parent.opener.top.main." & Request("WField") & ".value = '" & strFieldCode & strURLShowOpac & tblEData.Rows(intCount).Item("ID") & "';" & Chr(13)
                                strJS = strJS & "ud('" & Request("FieldCode") & "');" & Chr(13)
                                If Not Request("SField") = "" Then
                                    strJS = strJS & "parent.opener.top.main." & Request("SField") & ".value = '" & strFieldCode & strURLShowOpac & tblEData.Rows(intCount).Item("ID") & "';" & Chr(13)
                                End If
                                strJS = strJS & "parent.self.close();}"
                            Else
                                strJS = strJS & "if (confirm('" & ddlLabel.Items(38).Text & "')) {parent.opener.top.main." & Request("WField") & ".value = '" & strFieldCode & strURLShowOpac & tblEData.Rows(intCount).Item("ID") & "';" & Chr(13)
                                strJS = strJS & "ud('" & Request("FieldCode") & "');" & Chr(13)
                                If Not Request("SField") = "" Then
                                    strJS = strJS & "parent.opener.top.main." & Request("SField") & ".value = '" & strFieldCode & strURLShowOpac & tblEData.Rows(intCount).Item("ID") & "';" & Chr(13)
                                End If
                                strJS = strJS & "myUpdateRecord('" & Request("FieldCode") & "');" & Chr(13)
                                strJS = strJS & "parent.self.close();}"
                            End If
                            lnk.NavigateUrl = "#"
                            lnk.Attributes.Add("OnClick", strJS)

                            tblCell = New TableCell
                            tblCell.HorizontalAlign = HorizontalAlign.Center
                            tblCell.Controls.Add(lnk)
                            tblRow.Cells.Add(tblCell)

                            ' Add name(download & edit) column
                            strTemp = "../../Common/WDownload.aspx?FileID=" & tblEData.Rows(intCount).Item("ID")
                            lnkEData = New HyperLink
                            lnkEData.NavigateUrl = "#"
                            lnkEData.Attributes.Add("Onclick", "javascript:parent.HiddenDownload.location.href='" & strTemp & "';DownLoad('" & tblEData.Rows(intCount).Item("ID") & "');return false;")
                            lnkEData.Text = strFileName
                            lnkEData.CssClass = "lbLinkFunction"

                            tblCell = New TableCell
                            tblCell.HorizontalAlign = HorizontalAlign.Left
                            tblCell.Controls.Add(imgIcon)
                            tblCell.Controls.Add(lnkEData)
                            tblCell.ToolTip = ddlLabel.Items(18).Text
                            tblCell.Attributes.Add("Onclick", "javascript:parent.HiddenDownload.location.href='" & strTemp & "';DownLoad('" & tblEData.Rows(intCount).Item("ID") & "');return false;")
                            tblRow.Cells.Add(tblCell)

                            ' Add download column
                            imgIcon = New Image
                            imgIcon.ImageUrl = "../../Images/Icons/Download.gif"
                            imgIcon.Attributes.Add("Onclick", "javascript:parent.HiddenDownload.location.href='" & strTemp & "';DownLoad('" & tblEData.Rows(intCount).Item("ID") & "');return false;")
                            tblCell = New TableCell
                            tblCell.HorizontalAlign = HorizontalAlign.Center
                            tblCell.ToolTip = ddlLabel.Items(17).Text
                            tblCell.Attributes.Add("Onclick", "javascript:parent.HiddenDownload.location.href='" & strTemp & "';DownLoad('" & tblEData.Rows(intCount).Item("ID") & "');return false;")
                            tblCell.Controls.Add(imgIcon)
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
                                imgIcon = New Image
                                imgIcon.ImageUrl = "../../Images/Icons/details.gif"
                                tblCell = New TableCell
                                tblCell.HorizontalAlign = HorizontalAlign.Center
                                tblCell.ToolTip = ddlLabel.Items(44).Text
                                tblCell.Attributes.Add("OnClick", "javascript:openModal('" & "WCatalogueDetails.aspx?ItemID=" & strItemID & "','CatalogueDetails',700,500,100,50,'',';status=no',1)")
                                tblCell.Controls.Add(imgIcon)
                                tblRow.Cells.Add(tblCell)
                            Else
                                tblCell = New TableCell
                                tblCell.HorizontalAlign = HorizontalAlign.Center
                                tblCell.Controls.Add(New LiteralControl(""))
                                tblRow.Cells.Add(tblCell)
                            End If

                            ' Add Show used mode
                            If CBool(tblEData.Rows(intCount).Item("Free")) = 1 Then
                                imgIcon = New Image
                                imgIcon.ImageUrl = "../../Images/Icons/free.gif"
                                tblCell = New TableCell
                                tblCell.HorizontalAlign = HorizontalAlign.Center
                                tblCell.ToolTip = ddlLabel.Items(41).Text
                                tblCell.Controls.Add(imgIcon)
                                tblRow.Cells.Add(tblCell)
                            Else
                                imgIcon = New Image
                                imgIcon.ImageUrl = "../../Images/Icons/buy.jpg"
                                tblCell = New TableCell
                                tblCell.HorizontalAlign = HorizontalAlign.Center
                                tblCell.Controls.Add(imgIcon)
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
                        imgIcon = New Image
                        imgIcon.ImageUrl = "../../Images/Icons/ParentFolder.gif"

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
                        lnkEData.NavigateUrl = "WShowDetail.aspx?Loc=" & Trim(objDirInfor.Parent.FullName) & "&FieldCode=" & Request("FieldCode") & "&Repeatable=" & Request("Repeatable") & "&WField=" & Request("WField") & "&SField=" & Request("SField")
                        lnkEData.Text = " ..."
                        lnkEData.CssClass = "lbLinkFunction"

                        ' Add FolderName Column
                        tblCell = New TableCell
                        tblCell.Width = Unit.Percentage(100 / 3)
                        tblCell.HorizontalAlign = HorizontalAlign.Center
                        tblCell.Controls.Add(imgIcon)
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
                        lnkEData.NavigateUrl = "WShowDetail.aspx?Loc=" & Trim(objSubDirInfor.FullName) & "&FieldCode=" & Request("FieldCode") & "&Repeatable=" & Request("Repeatable") & "&WField=" & Request("WField") & "&SField=" & Request("SField")
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
                        strFileName = Right(strFileFullName, Len(strFileFullName) - InStrRev(strFileFullName, "\"))
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
                        ' Fisrt, new RadioButton
                        Dim lnk As New HyperLink
                        lnk.Text = "<img src=""../../Images/select.jpg"" border=""0"">"
                        lnk.ToolTip = ddlLabel.Items(42).Text
                        Dim strJS As String = ""

                        ' Request("Repeatable")
                        If Request.QueryString("Repeatable") = 1 Then
                            strJS = strJS & "if (confirm('" & ddlLabel.Items(38).Text & "')) {parent.opener.top.main." & Request("WField") & ".value = 'DownLoad.aspx?FileID=" & tblEData.Rows(intCount).Item("ID") & "';" & Chr(13)
                            strJS = strJS & "ud('" & Request("FieldCode") & "');" & Chr(13)
                            If Not Request("SField") = "" Then
                                strJS = strJS & "parent.opener.top.main." & Request("SField") & ".value = 'WDownLoad.aspx?FileID=" & tblEData.Rows(intCount).Item("ID") & "';" & Chr(13)
                            End If
                            strJS = strJS & "parent.self.close();}"
                        Else
                            strJS = strJS & "if (confirm('" & ddlLabel.Items(38).Text & "')) {parent.opener.top.main." & Request("WField") & ".value = 'WDownLoad.aspx?FileID=" & tblEData.Rows(intCount).Item("ID") & "';" & Chr(13)
                            strJS = strJS & "ud('" & Request("FieldCode") & "');" & Chr(13)
                            If Not Request("SField") = "" Then
                                strJS = strJS & "parent.opener.top.main." & Request("SField") & ".value = 'WDownLoad.aspx?FileID=" & tblEData.Rows(intCount).Item("ID") & "';" & Chr(13)
                            End If
                            strJS = strJS & "myUpdateRecord('" & Request("FieldCode") & "');" & Chr(13)
                            strJS = strJS & "parent.self.close();}"
                        End If
                        lnk.NavigateUrl = "#"
                        lnk.Attributes.Add("OnClick", strJS)

                        ' tblCell.Controls.Add(optEData)
                        tblCell.Controls.Add(lnk)

                        ' Add name(download & edit)
                        strTemp = "../../Common/WDownload.aspx?FileID=" & tblEData.Rows(intCount).Item("ID")
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

                            imgIcon.ImageUrl = "../../Images/Icons/details.gif"
                            imgIcon.ToolTip = ddlLabel.Items(44).Text
                            imgIcon.Attributes.Add("OnClick", "javascript:openModal('" & "WCatalogueDetails.aspx?ItemID=" & tblEData.Rows(intCount).Item("ItemID") & "','CatalogueDetails',700,500,100,50,'',';status=no',1)")
                            tblCell.Controls.Add(imgIcon)
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
                        If CBool(tblEData.Rows(intCount).Item("Free")) = 1 Then
                            imgIcon = New Image
                            imgIcon.ImageUrl = "../../Images/Icons/free.gif"
                            imgIcon.ToolTip = ddlLabel.Items(41).Text
                            lblEData = New Label
                            lblEData.Text = "<BR>" & ddlLabel.Items(40).Text & ": "
                            lblEData.CssClass = "lbLabel"
                            tblCell.Controls.Add(lblEData)
                            tblCell.Controls.Add(imgIcon)
                        Else
                            imgIcon = New Image
                            imgIcon.ImageUrl = "../../Images/Icons/buy.jpg"
                            lblEData = New Label
                            lblEData.Text = "<BR>" & ddlLabel.Items(40).Text & ": "
                            lblEData.CssClass = "lbLabel"
                            tblCell.Controls.Add(lblEData)
                            tblCell.Controls.Add(imgIcon)
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

        ' ShowHeader method
        ' Purpose: show page links
        ' CreatedDate: 31/01/2004
        ' Creator: Oanhtn
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
                                lnkEData.NavigateUrl = strURL & "?CurrPage=" & intIndex & "&Search=1"
                            Else
                                lnkEData.NavigateUrl = strURL & "?CurrPage=" & intIndex
                            End If
                        Else
                            If Request("Search") & "" <> "" Then
                                lnkEData.NavigateUrl = strURL & "&CurrPage=" & intIndex & "&Search=1"
                            Else
                                lnkEData.NavigateUrl = strURL & "&CurrPage=" & intIndex
                            End If
                        End If
                        lnkEData.CssClass = "lbLinkFunction"
                        tblCell.Controls.Add(lnkEData)
                    End If
                Next
                tblRow.Cells.Add(tblCell)
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

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Release all object
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace