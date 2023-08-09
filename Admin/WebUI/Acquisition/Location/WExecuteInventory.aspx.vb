' Class: WExecuteInventory
' Puspose: Excute inventory
' Creator: Tuanhv
' CreatedDate: 09/03/2004
' Modification History:

Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition
Imports eMicLibAdmin.WebUI.Common
Imports eMicLibAdmin.BusinessRules.Common
Imports System.IO

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WExecuteInventory
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblResultInv As System.Web.UI.WebControls.Label
        Protected WithEvents lblTotalInventory1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblTotalNoLoop1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblTotalWrong1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblWrongDetail1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblTotalNo1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblNoDetail1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblNoFile As System.Web.UI.WebControls.Label
        Protected WithEvents lblNoCopynumber As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBInventory As New clsBInventory
        Private objBLocation As New clsBLocation
        Private objBLibrary As New clsBLibrary
        Private objBCDBS As New clsBCommonDBSystem

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(177) Then
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: Init all neccessary objects
        Private Sub Initialize()
            ' Init objBLibrary object
            objBInventory.DBServer = Session("DBServer")
            objBInventory.ConnectionString = Session("ConnectionString")
            objBInventory.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBInventory.Initialize()

            ' Init objBLocation object
            objBLocation.DBServer = Session("DBServer")
            objBLocation.ConnectionString = Session("ConnectionString")
            objBLocation.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBLocation.Initialize()

            ' Init objBLibrary object
            objBLibrary.DBServer = Session("DBServer")
            objBLibrary.ConnectionString = Session("ConnectionString")
            objBLibrary.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBLibrary.Initialize()

            ' Init objBCDBS object
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCDBS.Initialize()

        End Sub

        ' BindJS method
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            txtCopyNumbers.Attributes.Add("OnClick", "document.forms[0].optList.checked = true ;document.forms[0].optFile.checked = false;")
            filAttachment.Attributes.Add("OnClick", "document.forms[0].optList.checked = false ;document.forms[0].optFile.checked = true;")
        End Sub

        ' Method: AddColumnInTable
        Public Function AddColumnInTable(ByVal tblOut As DataTable) As DataTable
            Dim tblResult As New DataTable
            Dim inti As Integer
            Dim intj As Integer
            Dim row As DataRow

            If Not tblOut Is Nothing Then
                If tblOut.Rows.Count > 0 Then
                    For inti = 0 To tblOut.Columns.Count - 1
                        tblResult.Columns.Add(tblOut.Columns(inti).ColumnName, tblOut.Columns(inti).DataType)
                    Next
                    For inti = 0 To tblOut.Rows.Count - 1
                        row = tblResult.NewRow
                        row(0) = intj + 1
                        For intj = 1 To tblOut.Columns.Count - 1
                            row(intj) = tblOut.Rows(inti).Item(intj)
                        Next intj
                        tblResult.Rows.Add(row)
                    Next inti
                    AddColumnInTable = tblResult
                End If
            End If
        End Function

        ' ProcessFileName method
        ' Purpose: Rename the file
        Private Sub ProcessFileName(ByVal strFileAttach As String, ByRef strFileName As String)
            Dim strExtension As String = ""

            While InStr(strFileAttach, " ") > 0
                strFileAttach = Replace(strFileAttach, " ", "")
            End While
            strFileAttach = Replace(strFileAttach, "'", "")
            strExtension = Right(strFileAttach, Len(strFileAttach) - InStrRev(strFileAttach, "."))
            Randomize()
            strFileName = "f" & Year(Now) & StrDup(2 - Len(CStr(Month(Now))), "0") & StrDup(2 - Len(CStr(Day(Now))), "0") & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1) + 65)) & "." & strExtension
        End Sub

        Private Function UploadInventory() As String
            Dim strFileName As String = ""
            Dim strPath As String = ""
            Dim strLocation As String = ""
            Dim strUploaded As String = ""
            Dim strUpload As String = ""
            Dim objDirInfor As DirectoryInfo

            If Not optList.Checked Then
                strPath = Server.MapPath("") & "/UploadInvent"
                objDirInfor = New DirectoryInfo(strPath)
                If Not objDirInfor.Exists Then
                    Call objDirInfor.Create()
                End If
                Dim strNamefile As String = "tmp" & Now.Year & CStr(Now.Month).PadLeft(2, "0") & CStr(Now.Day).PadLeft(2, "0") & CStr(Now.Hour).PadLeft(2, "0") & CStr(Now.Minute).PadLeft(2, "0") & CStr(Now.Second).PadLeft(2, "0") & CStr(Now.Millisecond).PadLeft(3, "0") & ".txt"
                UpLoadFiles(filAttachment, strPath, strNamefile)
                If Not filAttachment.Value = "" Then
                    UploadInventory = Trim(ReadFromFile(strPath & "/" & strNamefile))
                End If
            Else
                UploadInventory = Trim(txtCopyNumbers.Text)
            End If
            UploadInventory = Replace(UploadInventory, "'", "")
            UploadInventory = Replace(UploadInventory, " ", "")
            UploadInventory = Replace(UploadInventory, vbCrLf, ",")
            If ddlLocation.SelectedIndex < 0 Then
                Call CloseLabel(False)
                Page.RegisterClientScriptBlock("NLocation", "<script language='javascript'> alert('Chưa chọn kho đã đóng');</script>")
                Exit Function
            End If
            If Len(UploadInventory) < 2 Then
                Call CloseLabel(False)
                Page.RegisterClientScriptBlock("NoCopynumber", "<script language='javascript'> alert('" & ddlLabel.Items(11).Text & "');</script>")
                Exit Function
            End If
         
        End Function

        ' Method: BindData
        Private Sub BindData()
            Dim tblResult As DataTable

            ' Get Inventory
            objBInventory.LibID = clsSession.GlbSite
            tblResult = objBInventory.GetInventory()
            ' Bind inventory
            If Not tblResult Is Nothing Then
                If tblResult.Rows.Count > 0 Then
                    ddlInventory.DataValueField = "ID"
                    ddlInventory.DataTextField = "Name"
                    ddlInventory.DataSource = tblResult
                    ddlInventory.DataBind()
                    tblResult.Clear()
                End If
            End If

            ' Get Liblary
            objBLibrary.LibID = clsSession.GlbSite
            objBLibrary.UserID = CInt(Session("UserID"))
            tblResult = objBLibrary.GetLibrary(0)
            ' Bind liblary
            If Not tblResult Is Nothing Then
                If tblResult.Rows.Count > 0 Then
                    ddlLibrary.DataValueField = "ID"
                    ddlLibrary.DataTextField = "Code"
                    ddlLibrary.DataSource = tblResult
                    ddlLibrary.DataBind()
                    tblResult.Clear()

                    ' Get Location
                    objBLocation.UserID = Session("UserID")
                    objBLocation.LibID = CInt(ddlLibrary.Items(0).Value)
                    objBLocation.Status = 0
                    objBLocation.LocID = 0
                    tblResult = objBLocation.GetLocation
                    ' Bind location
                    If Not tblResult Is Nothing Then
                        If tblResult.Rows.Count > 0 Then
                            ddlLocation.DataValueField = "ID"
                            ddlLocation.DataTextField = "Symbol"
                            ddlLocation.DataSource = tblResult
                            ddlLocation.DataBind()
                            tblResult.Clear()
                        End If
                    End If
                Else
                    Page.RegisterClientScriptBlock("NothingJS", "<script language='javascript'>alert('" & ddlLabel.Items(19).Text & "');self.close();</script>")
                    btnInventory.Enabled = False
                    btnViewResult.Enabled = False
                End If
            End If
            hidFormAction.Value = 0
            ' Release object
            If Not tblResult Is Nothing Then
                tblResult = Nothing
            End If
        End Sub

        ' Event: ddlLibrary_SelectedIndexChanged
        ' Purpose: load all stores of the selected library
        Private Sub ddlLibrary_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlLibrary.SelectedIndexChanged
            Dim tblResult As DataTable
            ' Get Location
            objBLocation.UserID = Session("UserID")
            Try
                objBLocation.LibID = CInt(ddlLibrary.SelectedValue)
            Catch ex As Exception
                objBLocation.LibID = 0
            End Try
            objBLocation.Status = 0
            tblResult = objBLocation.GetLocation
            If Not tblResult Is Nothing Then
                ddlLocation.DataValueField = "ID"
                ddlLocation.DataTextField = "Symbol"
                ddlLocation.DataSource = tblResult
                ddlLocation.DataBind()
                tblResult.Clear()
            End If

            ' Release object
            If Not tblResult Is Nothing Then
                tblResult = Nothing
            End If
        End Sub

        ' Method: ReadFile
        ' Popurse: Read file from 
        Sub ReadFile(ByRef StrOut As String)
            Dim strFileName As String = ""
            Dim myUpload As Object
            Dim strImport As String = ""

            If optFile.Checked Then
                strFileName = filAttachment.Value
                If Len(strFileName) < 2 Then
                    Call CloseLabel(False)
                    Page.RegisterClientScriptBlock("NoCopynumber", "<script language='javascript'> alert('" & ddlLabel.Items(10).Text & "');</script>")
                    Exit Sub
                End If
                ' Read from file and get the import string
                Try
                    StrOut = ReadFromFile(strFileName)
                Catch ex As Exception
                    Call CloseLabel(False)
                    Page.RegisterClientScriptBlock("NoCopynumber", "<script language='javascript'> alert('" & ddlLabel.Items(10).Text & "');</script>")
                    Exit Sub
                End Try
            Else
                StrOut = txtCopyNumbers.Text
            End If
            StrOut = Replace(StrOut, "'", "")
            StrOut = Replace(StrOut, " ", "")
            StrOut = Replace(StrOut, vbCrLf, ",")
            If Len(StrOut) < 2 Then
                Call CloseLabel(False)
                Page.RegisterClientScriptBlock("NoCopynumber", "<script language='javascript'> alert('" & ddlLabel.Items(11).Text & "');</script>")
                Exit Sub
            End If
        End Sub

        ' BindPrg method 
        ' Purpose: Bind data for Controls
        Public Sub BindPrg(ByVal intCurrent As Integer, ByVal intSum As Integer)
            Dim intCurrentPercent As Integer
            intCurrentPercent = ((intCurrent + 1) * 100) / intSum
            'System.Threading.Thread.Sleep(50 / intSum)
            Response.Write("<script language='javascript'>spnProgess.width =" & intCurrentPercent & " + '%'; spnPecent.innerHTML =" & intCurrentPercent & " + '%';</script>")
            Response.Flush()
        End Sub

        ' Event: btnInventory_Click
        ' Purpose: execute immediate
        Private Sub btnInventory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInventory.Click
            Dim i, j As Integer
            Dim intSessionID As Integer = 0
            Dim intTotal As Integer
            Dim intTotalLoop As Long = 0
            Dim intTotalNoLoop As Integer = 0
            Dim intTotalYes As Integer = 0
            Dim intTotalNo As Integer = 0
            Dim intSplitCopynumber As Integer = 0
            Dim strCopyNumbers As String
            Dim arrCopyNumber() As String
            Dim tblResult As DataTable
            Dim intTongDKCBKoCo As Integer = 0
            Dim intTongDKCBNham As Integer = 0
            Dim intTongDKCBDung As Integer = 0
            Dim strNoExitsCopynumberTotal As String = ""
            Dim strExitsCopynumberTotal As String = ""
            Dim strTrueCopynumberTotal As String = ""
            Dim strExitsCopynumberTrue As String = ""
            Dim intSplit As Integer = 300
            Dim intInventoryTime As Integer
            Dim intIsFirstTimeInventory As Integer = 1 ' Default first time inventory not change this value

            Dim strNoExitsCopynumber As String = ""
            Dim strExitsCopynumber As String = ""
            Dim strHtml As String
            Dim intTotalExitsCopynumber As Integer
            Dim intPercentCur As Integer = 0
            Dim intTotalPercent As Integer = 0
            Dim inti As Integer
            Dim intj As Integer
            Dim intdanhdau As Integer = 0
            Dim intUBoundarrCopyNum As Integer = 0
            Dim tblTotalLost As DataTable

            'get time to exec inventory
            Dim intTotalTime As Integer = Now.Hour * 3600 + Now.Minute * 60 + Now.Second

            If ddlLocation.SelectedIndex < 0 Then
                Page.RegisterClientScriptBlock("ReceivedUnLockSuccess", "<script>alert('Chưa chọn kho kiểm kê');</script>")
                Return
            End If
            ' Read copynumber form form into strCopyNumbers
            strCopyNumbers = UploadInventory()
            strCopyNumbers = Replace(strCopyNumbers, ";", ",")
            While Right(strCopyNumbers, 1) = ","
                strCopyNumbers = Left(strCopyNumbers, Len(strCopyNumbers) - 1)
            End While
            If Len(strCopyNumbers) > 2 Then
                arrCopyNumber = Split(strCopyNumbers, ",")

                intTotal = UBound(arrCopyNumber) + 1

                'Loc bo cac DKCB trung nhau
                Dim strCopyNum As String = arrCopyNumber(0) & ","
                For inti = 1 To arrCopyNumber.Length - 1
                    If InStr(strCopyNum, arrCopyNumber(inti) & ",") = 0 Then
                        strCopyNum &= arrCopyNumber(inti) & ","
                    End If
                Next
                strCopyNum = Left(strCopyNum, Len(strCopyNum) - 1)
                arrCopyNumber = strCopyNum.Split(",")
                intTongDKCBDung = CInt(arrCopyNumber.Length)

                intTotalNoLoop = 0
                If intTotal < intSplit Then
                    intSplit = intTotal
                End If
                If intSplit = 0 Then
                    intSplit = 1
                End If
                '''''''''''' Init progress bar
                intPercentCur = 0
                intTotalPercent = Math.Ceiling(intTotal / intSplit)
                lblLibName.Text = lblLibName.Text & " " & ddlLibrary.SelectedItem.Text
                lblLocName.Text = lblLocName.Text & " " & ddlLocation.SelectedItem.Text
                lblShelfInv.Text = lblShelfInv.Text & " " & txtShelf.Text

                strHtml = "<span id='spnMain' style='  height:112px; COLOR: #3333ff; TOP: 60px'	class='lblLabel'>"
                strHtml = strHtml & "<span id='spnPecent' style=' COLOR: #FFFFFF;  FONT-WEIGHT: bold;'>0%</span>"
                strHtml = strHtml & "<span id='spnlbProcessing' style='TEXT-ALIGN: center;'>" & ddlLabel.Items(13).Text & "</span>"
                strHtml = strHtml & lblLibName.Text & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
                strHtml = strHtml & lblLocName.Text & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
                strHtml = strHtml & lblShelfInv.Text
                strHtml = strHtml & "<table height=10px cellspacing=0 cellpadding=0><tr><td></td><tr></table>"
                strHtml = strHtml & "<table width=100% border=1 bgcolor=#999966 height=30px cellspacing=0 cellpadding=0 bordercolor=#FF9900><tr><td>"
                strHtml = strHtml & "<table id='spnProgess' width=0% border=0 bgcolor=#006291 height=100%><tr><td></td></tr></table></td></tr></table></span>"
                Response.Write(strHtml)

                'While UBound(arrCopyNumber) > intSplitCopynumber
                While arrCopyNumber.Length > intSplitCopynumber
                    strCopyNumbers = ""
                    ' Thuc hien kiem nhan tai day cho tung 300 dang ky ca biet 
                    If UBound(arrCopyNumber) > intSplitCopynumber + intSplit Then
                        For i = intSplitCopynumber To intSplitCopynumber + intSplit - 1
                            If arrCopyNumber(i) <> "" Then
                                strCopyNumbers = strCopyNumbers & Trim(arrCopyNumber(i)) & ","
                            End If
                        Next
                        If strCopyNumbers <> "" Then
                            strCopyNumbers = Left(strCopyNumbers, Len(strCopyNumbers) - 1)
                        End If
                        ' Insert into init_inventory table
                        objBInventory.CopyNumbers = strCopyNumbers
                        Call objBInventory.InitInventory(intSessionID)
                        intTotalNoLoop = UBound(arrCopyNumber) + 1
                        intTotalLoop = intTotal - intTotalNoLoop ' Total loop in data input
                        intInventoryTime = objBInventory.GetmaxInventoryTime
                        tblResult = objBInventory.CheckCopynumberNotExits(intSessionID)
                        Call FindNotExits(strCopyNumbers, tblResult, strNoExitsCopynumber, strExitsCopynumber, intTotalExitsCopynumber)
                        strNoExitsCopynumberTotal = strNoExitsCopynumberTotal & strNoExitsCopynumber & ","
                        strExitsCopynumberTotal = strExitsCopynumberTotal & strExitsCopynumber & ","
                        'Check error
                        Call WriteErrorMssg(ddlLabel.Items(1).Text, objBInventory.ErrorMsg, ddlLabel.Items(0).Text, objBInventory.ErrorCode)
                        objBInventory.LibID = CInt(ddlLibrary.SelectedValue)
                        objBInventory.LocationID = CInt(ddlLocation.SelectedValue)
                        objBInventory.InventoryID = CInt(ddlInventory.SelectedValue)
                        objBInventory.Purpose = CInt(optPurpose.SelectedIndex)
                        objBInventory.Shelf = txtShelf.Text
                        objBInventory.CopyNumbers = strCopyNumbers ' Parameter for Oracle running only
                        objBInventory.RunInventory(intInventoryTime, intIsFirstTimeInventory, intSessionID) ' Run inventory
                        intIsFirstTimeInventory = intIsFirstTimeInventory + 1 ' Never this value = 1 two times
                        strTrueCopynumberTotal = strTrueCopynumberTotal & strExitsCopynumberTrue & ","
                        intSplitCopynumber = intSplitCopynumber + intSplit
                    Else ' Kiem ke not phan con lai
                        For i = intSplitCopynumber To UBound(arrCopyNumber)
                            If arrCopyNumber(i) <> "" Then
                                strCopyNumbers = strCopyNumbers & Trim(arrCopyNumber(i)) & ","
                            End If
                        Next
                        ' Insert into inti_inventory table
                        objBInventory.CopyNumbers = strCopyNumbers ' For SQL server + Oracle running
                        Call objBInventory.InitInventory(intSessionID)

                        If strCopyNumbers <> "" Then
                            strCopyNumbers = Left(strCopyNumbers, Len(strCopyNumbers) - 1)
                        End If

                        intTotalNoLoop = UBound(arrCopyNumber) + 1
                        intTotalLoop = intTotal - intTotalNoLoop ' Total loop in data input
                        intInventoryTime = objBInventory.GetmaxInventoryTime
                        tblResult = objBInventory.CheckCopynumberNotExits(intSessionID)
                        Call FindNotExits(strCopyNumbers, tblResult, strNoExitsCopynumber, strExitsCopynumber, intTotalExitsCopynumber)
                        strNoExitsCopynumberTotal = strNoExitsCopynumberTotal & strNoExitsCopynumber & ","
                        strExitsCopynumberTotal = strExitsCopynumberTotal & strExitsCopynumber & ","
                        objBInventory.LibID = CInt(ddlLibrary.SelectedValue)
                        objBInventory.LocationID = CInt(ddlLocation.SelectedValue)
                        objBInventory.InventoryID = CInt(ddlInventory.SelectedValue)
                        objBInventory.Purpose = CInt(optPurpose.SelectedIndex)
                        objBInventory.Shelf = txtShelf.Text
                        objBInventory.RunInventory(intInventoryTime, intIsFirstTimeInventory, intSessionID) ' Run inventory
                        intIsFirstTimeInventory = intIsFirstTimeInventory + 1 ' Never this value = 1 two times
                        strNoExitsCopynumber = ""
                        intTotalExitsCopynumber = 0
                        strTrueCopynumberTotal = strTrueCopynumberTotal & strExitsCopynumberTrue & ","
                        intSplitCopynumber = UBound(arrCopyNumber) + 1 ' Exit while
                    End If

                    ' Display the progress bar
                    Call BindPrg(intPercentCur, intTotalPercent)

                    intPercentCur = intPercentCur + 1
                End While

                ' Clear Init_Inventory table 
                Call objBInventory.ClearInventory(intSessionID)
                ' Display information

                Dim strCNsFalsePath As String
                Dim tblCNsFalsePath As DataTable
                Dim intk As Integer
                strCNsFalsePath = ""
                objBInventory.LibID = CInt(ddlLibrary.SelectedValue)
                objBInventory.LocationID = CInt(ddlLocation.SelectedValue)
                objBInventory.InventoryID = CInt(ddlInventory.SelectedValue)
                'tblCNsFalsePath = objBInventory.GetCNsFalsePath
                tblCNsFalsePath = objBInventory.GetItemFalsePaths
                If Not tblCNsFalsePath Is Nothing AndAlso tblCNsFalsePath.Rows.Count > 0 Then
                    For intk = 0 To tblCNsFalsePath.Rows.Count - 1
                        strCNsFalsePath = strCNsFalsePath & tblCNsFalsePath.Rows(intk).Item("CopyNumber") & ", "
                    Next
                    strCNsFalsePath = Left(strCNsFalsePath, Len(strCNsFalsePath) - 2)
                End If
                Response.Write("<script language='javascript'>spnlbProcessing.innerHTML ='" & ddlLabel.Items(14).Text & "';</script>")

                lblTotalInventory.Text = ddlLabel.Items(18).Text & "<b>" & CStr(intTotal) & "</b>"
                'lblTotalNoLoop.Text = ddlLabel.Items(5).Text & "<b>" & CStr(intTotalNoLoop + 1) & "</b>"
                lblTotalNoLoop.Text = ddlLabel.Items(5).Text & "<b>" & CStr(intTongDKCBDung) & "</b>"
                'If UBound(Split(strCNsFalsePath, ",")) > 0 Then
                If tblCNsFalsePath.Rows.Count > 0 Then
                    lblTotalWrong.Text = ddlLabel.Items(6).Text & "<b>" & tblCNsFalsePath.Rows.Count & "</b>"
                Else
                    lblTotalWrong.Text = ddlLabel.Items(6).Text & "<b>0</b>"
                End If

                If strCNsFalsePath.Length > 500 Then
                    lnkFileStoreCN.Visible = True
                    lblLnkWrongDetail1.Visible = True
                    lblLnkWrongDetail2.Visible = True
                    Dim strFileName As String = SaveToFile(Replace(strCNsFalsePath, ",", ", "), "txt", Server.MapPath("../.."))
                    lnkFileStoreCN.Attributes.Add("OnClick", "parent.hiddenbase.location.href='../../Common/WSaveTempFile.aspx?ModuleID=4&FileName=" & strFileName & "';return false;")
                    lnkFileStoreCN.NavigateUrl = "#"
                Else
                    If strCNsFalsePath <> "" Then
                        lblWrongDetail.Text = ddlLabel.Items(7).Text & "<b>" & strCNsFalsePath & "</b>"
                    Else
                        lblWrongDetail.Text = ddlLabel.Items(7).Text & "<b>" & ddlLabel.Items(12).Text & "</b>"
                    End If
                End If
                If strNoExitsCopynumberTotal.IndexOf(",") > 0 Then
                    strNoExitsCopynumberTotal = Replace(strNoExitsCopynumberTotal, ",,", "").Trim
                End If
                If strNoExitsCopynumberTotal <> "" AndAlso Right(strNoExitsCopynumberTotal, 1) = "," Then
                    strNoExitsCopynumberTotal = Left(strNoExitsCopynumberTotal, strNoExitsCopynumberTotal.Length - 1)
                End If
                '    If strNoExitsCopynumberTotal.Trim = "" Then
                '        strNoExitsCopynumberTotal = ddlLabel.Items(12).Text
                '    End If
                'Else
                '    strNoExitsCopynumberTotal = ddlLabel.Items(12).Text
                'End If
                'If UBound(Split(strNoExitsCopynumberTotal, ",")) > 0 Then
                If Split(strNoExitsCopynumberTotal, ",").Length > 0 Then
                    If strNoExitsCopynumberTotal.Trim <> "" Then
                        lblTotalNo.Text = ddlLabel.Items(8).Text & "<b>" & UBound(Split(strNoExitsCopynumberTotal, ",")) + 1 & "</b>"
                        lblNoDetail.Text = ddlLabel.Items(9).Text & "<b>" & Replace(strNoExitsCopynumberTotal, ",", ", ") & "</b>"
                    Else
                        lblTotalNo.Text = ddlLabel.Items(8).Text & "<b>0</b>"
                        lblNoDetail.Text = ddlLabel.Items(9).Text & " <b>" & ddlLabel.Items(12).Text & "</b>"
                    End If
                End If
                Dim intTotalTimed As Integer = Now.Hour * 3600 + Now.Minute * 60 + Now.Second
                intTotalTime = intTotalTimed - intTotalTime
                Dim intTimeHour As Integer = Math.Floor(intTotalTime / 3600)
                intTotalTime = intTotalTime - intTimeHour * 3600
                Dim intTimeMin As Integer = Math.Floor(intTotalTime / 60)
                intTotalTime = intTotalTime - intTimeMin * 60
                If intTimeHour > 0 Then
                    lblDetailResult.Text = lblDetailResult.Text & " " & CStr(intTimeHour) & " " & ddlLabel.Items(15).Text & " : " & CStr(intTimeMin) & " " & ddlLabel.Items(16).Text & " : " & CStr(intTotalTime) & " " & ddlLabel.Items(17).Text & ")"
                Else
                    If intTimeMin > 0 Then
                        lblDetailResult.Text = lblDetailResult.Text & " " & CStr(intTimeMin) & " " & ddlLabel.Items(16).Text & " : " & CStr(intTotalTime) & " " & ddlLabel.Items(17).Text & ")"
                    Else
                        lblDetailResult.Text = lblDetailResult.Text & " " & CStr(intTotalTime) & " " & ddlLabel.Items(17).Text & ")"
                    End If
                End If
                objBInventory.InventoryID = ddlInventory.SelectedValue
                objBInventory.LibID = ddlLibrary.SelectedValue
                objBInventory.LocationID = ddlLocation.SelectedValue
                objBInventory.Shelf = txtShelf.Text
                Call objBInventory.Insert_HolInv_LossItem(intInventoryTime)
                'TotalLost
                If CInt(ddlInventory.SelectedValue) > 0 Then
                    objBInventory.InventoryID = CInt(ddlInventory.SelectedValue)
                End If
                If CInt(ddlLibrary.SelectedValue) > 0 Then
                    objBInventory.LibID = CInt(ddlLibrary.SelectedValue)
                End If
                If CInt(ddlLocation.SelectedValue) > 0 Then
                    objBInventory.LocationID = CInt(ddlLocation.SelectedValue)
                End If
                tblTotalLost = objBInventory.GetItemNoHaveReal()
                If tblTotalLost.Rows.Count > 0 Then
                    lblTotalLost.Text = ddlLabel.Items(20).Text & "<b>" & CStr(tblTotalLost.Rows.Count) & "</b>"
                Else
                    lblTotalLost.Text = ddlLabel.Items(20).Text & "<b>0</b>"
                End If
                '''''''''''''''''''''''''''
                hidFormAction.Value = 1
            End If
            Call WriteLog(96, ddlLabel.Items(3).Text & ":" & ddlInventory.Items(ddlInventory.SelectedIndex).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

        End Sub
        ' Purpose: Save to file
        ' Input: strContent, strExtendsion, isHTML
        ' Output: Physical path to file
        ' Creator: Sondp
        Public Function SaveToFile(ByVal strContent As String, ByVal strExtendsion As String, Optional ByVal strServerPath As String = "") As String
            Dim intTTL As Integer = 24
            Dim arrValue(0), arrName(0) As String
            Dim tblTempFile As DataTable
            Dim strContentType, strFileLocation, strFileName, strCondition As String
            Dim objFile As File
            Dim objSw As StreamWriter
            Dim inti As Integer
            Dim strPathfile As String = "\Acquistion\TempFiles\"

            arrName(0) = "TEMPFILE_TTL"
            Try
                tblTempFile = objBCDBS.GetTempFilePath(4)
                If Not tblTempFile Is Nothing AndAlso tblTempFile.Rows.Count > 0 Then
                    strPathfile = tblTempFile.Rows(0).Item("TempFilePath")
                    If Right(strPathfile, 1) <> "\" AndAlso Right(strPathfile, 1) <> "/" Then
                        strPathfile = strPathfile & "\"
                    End If
                End If

                arrValue = objBCDBS.GetSystemParameters(arrName)
                If IsArray(arrValue) Then
                    ' get path tempfile
                    If Not IsDBNull(arrValue(0)) And IsNumeric(arrValue(0)) Then
                        intTTL = arrValue(0)
                    End If
                    ' delete file 
                    If Not Session("DBServer") = "ORACLE" Then
                        strCondition = " WHERE DATEDIFF(HOUR, CreatedDate, GetDate()) > " & CStr(intTTL)
                    Else
                        strCondition = " WHERE (SYSDATE - CreatedDate)*24 > " & CStr(intTTL)
                    End If
                    objBCDBS.Condition = strCondition
                    tblTempFile = objBCDBS.GetSysDownloadFile
                    If Not tblTempFile Is Nothing AndAlso tblTempFile.Rows.Count > 0 Then
                        For inti = 0 To tblTempFile.Rows.Count - 1
                            strFileName = tblTempFile.Rows(inti).Item("FileName")
                            strFileLocation = strServerPath & strPathfile & strFileName
                            If objFile.Exists(strFileLocation) Then
                                objFile.Delete(strFileLocation)
                            End If
                        Next
                        objBCDBS.Condition = strCondition
                        objBCDBS.DeleteSysDownloadFile()
                    End If
                    ' start generate random file
                    objBCDBS.Extension = strExtendsion
                    strFileName = objBCDBS.GenRandomFile
                    strFileName = Left(strFileName, InStr(strFileName, ".") - 1)
                    ' Write file
                    objSw = File.CreateText(strServerPath & strPathfile & strFileName & "." & strExtendsion)
                    objSw.WriteLine(strContent)
                    objSw.Close()
                End If
                SaveToFile = strFileName & "." & strExtendsion
            Catch ex As Exception
                strErrorMsg = ex.Message
                SaveToFile = ex.Message
            End Try
        End Function

        ' Method: CloseLabel
        ' Puporse: Visiable(open or close) label result
        Sub CloseLabel(ByVal btnVisiable As Boolean)
            lblTotalInventory.Visible = btnVisiable
            lblTotalNoLoop.Visible = btnVisiable
            lblTotalWrong.Visible = btnVisiable
            lblWrongDetail.Visible = btnVisiable
            lblTotalNo.Visible = btnVisiable
            lblNoDetail.Visible = btnVisiable
        End Sub

        ' Method: FindNotExitCopynumber
        Public Sub FindNotExits(ByVal strCopynumberInput As String, ByVal tblDataInput As DataTable, ByRef strNoExitsCopynumber As String, ByRef strExitsCopynumber As String, ByRef intTotalExitsCopynumber As Integer)
            Dim inti As Integer = 0
            Dim intj As Integer = 0
            Dim arr1() As String
            Dim dvCopy As DataRow
            Dim strOutput As String = ""
            arr1 = Split(strCopynumberInput, ",")
            intTotalExitsCopynumber = 0
            strExitsCopynumber = ""
            If Not tblDataInput Is Nothing Then
                If tblDataInput.Rows.Count > 0 Then
                    intTotalExitsCopynumber = tblDataInput.Rows.Count
                    For inti = 0 To UBound(arr1)
                        tblDataInput.DefaultView.RowFilter = "Copynumber='" & arr1(inti) & "'"
                        If Not tblDataInput.DefaultView Is Nothing Then
                            If tblDataInput.DefaultView.Count > 0 Then
                                strExitsCopynumber = strExitsCopynumber & arr1(inti) & ","
                                arr1(inti) = ""
                            End If
                        End If
                    Next
                End If
            End If
            For inti = 0 To UBound(arr1)
                If arr1(inti) <> "" Then
                    strOutput = strOutput & arr1(inti) & ","
                End If
            Next
            If Len(strOutput) > 1 Then
                strOutput = Left(strOutput, Len(strOutput) - 1)
            End If
            If Len(strExitsCopynumber) > 1 Then
                strExitsCopynumber = Left(strExitsCopynumber, Len(strExitsCopynumber) - 1)
            End If
            strNoExitsCopynumber = strOutput
        End Sub

        ' Method: btnViewResult_Click
        ' Purpose: view result in another page
        Private Sub btnViewResult_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewResult.Click
            Dim intInventoryID As Integer = 0
            Dim intLibID As Integer = 0
            Dim intLocID As Integer = 0
            Dim strShelt As String = ""

            If ddlLocation.SelectedIndex < 0 Then
                Page.RegisterClientScriptBlock("ReceivedUnLockSuccess", "<script>alert('Chưa chọn kho kiểm kê');</script>")
                Return
            End If
            Try
                If CInt(ddlInventory.SelectedValue) > 0 Then
                    intInventoryID = CInt(ddlInventory.SelectedValue)
                End If
                If CInt(ddlLibrary.SelectedValue) > 0 Then
                    intLibID = CInt(ddlLibrary.SelectedValue)
                End If
                If CInt(ddlLocation.SelectedValue) > 0 Then
                    intLocID = CInt(ddlLocation.SelectedValue)
                End If
                If Trim(txtShelf.Text) <> "" Then
                    strShelt = Trim(txtShelf.Text)
                End If
                Response.Redirect("WViewLiq.aspx?InventoryID=" & intInventoryID & "&LibID=" & intLibID & " &LocID=" & intLocID & " &Shelf=" & strShelt)
            Catch ex As Exception ' Error occured
                Call WriteErrorMssg(ddlLabel.Items(4).Text)
            End Try
        End Sub

        ' Event: Page_Unload
        ' Purpose: release objects
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBInventory Is Nothing Then
                    objBInventory.Dispose(True)
                    objBInventory = Nothing
                End If
                If Not objBLocation Is Nothing Then
                    objBLocation.Dispose(True)
                    objBLocation = Nothing
                End If
                If Not objBLibrary Is Nothing Then
                    objBLibrary.Dispose(True)
                    objBLibrary = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace