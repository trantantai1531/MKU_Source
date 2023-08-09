' Class: WHoldingLocRemove
' Puspose: remove compynumbers
' Creator: Lent
' CreatedDate: 03/03/2005
' Modification History:
'   - 13/04/2005 by Oanhtn: review

Imports System.IO
Imports System.IO.File
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition
Imports eMicLibAdmin.WebUI.Common

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WHoldingLocRemove
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblMoveSucc As System.Web.UI.WebControls.Label
        Protected WithEvents lblRéul As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBLibrary As New clsBLibrary
        Private objBLocation As New clsBLocation
        Private objBCopyNumber As New clsBCopyNumber

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
            If Not CheckPemission(125) Then
                Call WriteErrorMssg(ddlLabelNote.Items(7).Text)
            End If
            txtDateRemove.Text = Session("ToDay")
        End Sub

        ' Initialize method
        ' Purpose: Init all neccessary objects
        Private Sub Initialize()
            ' Initialize objBLibrary object
            objBLibrary.DBServer = Session("DBServer")
            objBLibrary.ConnectionString = Session("ConnectionString")
            objBLibrary.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBLibrary.Initialize()

            ' Initialize objBLocation object
            objBLocation.DBServer = Session("DBServer")
            objBLocation.ConnectionString = Session("ConnectionString")
            objBLocation.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBLocation.Initialize()

            ' Initialize objBCopyNumber object
            objBCopyNumber.DBServer = Session("DBServer")
            objBCopyNumber.ConnectionString = Session("ConnectionString")
            objBCopyNumber.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCopyNumber.Initialize()
        End Sub

        ' Method: BindJS
        ' Purpose: include all need js function
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language='javascript' src='../JS/Location/WHoldingLocRemove.js'></script>")

            rdbCodeDoc.Attributes.Add("OnClick", "javascript:SwitchEnable(0);")
            rdbCopyNum.Attributes.Add("OnClick", "javascript:SwitchEnable(1);")
            rdbCopyNumFile.Attributes.Add("OnClick", "javascript:SwitchCopyNum(0);")
            rdbCopyNumManual.Attributes.Add("OnClick", "javascript:SwitchCopyNum(1);")

            ddlLibSource.Attributes.Add("OnChange", "javascript:return(LoadLocation());")

            btnLocRemove.Attributes.Add("Onclick", "javascript:return(CheckReMoveLoc('" & ddlLabelNote.Items(0).Text & "'));")
            btnFindCode.Attributes.Add("OnClick", "javascript:return(OpenSearchForm());")

            txtDateRemove.Attributes.Add("onChange", "if (!CheckDate(this,'" & Session("DateFormat") & "','" & ddlLabelNote.Items(2).Text & " (" & Session("DateFormat") & ")')) {alert('" & ddlLabelNote.Items(2).Text & " (" & Session("DateFormat") & ")'); this.value=''; this.focus(); return false;}")
            lnkShowCopyNum.Attributes.Add("Onclick", "javascript:return(ShowCopyNumber('" & ddlLabelNote.Items(3).Text & "'));")
        End Sub

        ' Method: BindData
        Private Sub BindData()
            Dim intUserID As Integer
            Dim tblResult As New DataTable
            Dim listItem As New listItem

            'txtDateRemove.Text = CStr(Now.Day) & "/" & CStr(Now.Month) & "/" & CStr(Now.Year)
            intUserID = Session("UserID")
            If Not Page.IsPostBack Then
                objBLibrary.UserID = Session("UserID")
                objBLibrary.LibID = clsSession.GlbSite
                tblResult = objBLibrary.GetLibrary(1)
                ' Bind data for dropdownlist library
                If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                    ddlLibSource.DataSource = tblResult
                    ddlLibSource.DataTextField = "FullName"
                    ddlLibSource.DataValueField = "ID"
                    ddlLibSource.DataBind()
                Else
                    listItem.Text = ddlLabelNote.Items(10).Text
                    listItem.Value = 0
                    ddlLibSource.Items.Add(listItem)
                    btnFindCode.Enabled = False
                    btnLocRemove.Enabled = False
                End If
                ddlLibSource.SelectedIndex = 0
                tblResult.Clear()

                ' Bind data for dropdownlist reason
                tblResult = objBCopyNumber.GetRemoveReason
                If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                    ddlReason.DataSource = tblResult
                    ddlReason.DataTextField = "Reason"
                    ddlReason.DataValueField = "ID"
                    ddlReason.DataBind()
                    ddlReason.SelectedIndex = 0
                Else
                    btnFindCode.Enabled = False
                    btnLocRemove.Enabled = False
                End If
            End If
            ' Bind data for dropdownlist
            objBLocation.UserID = intUserID
            objBLocation.LibID = ddlLibSource.SelectedValue
            objBLocation.Status = -1
            objBLocation.LocID = 0

            tblResult = objBLocation.GetLocation
            If Not tblResult Is Nothing Then
                If tblResult.Rows.Count > 0 Then
                    ddlLocSource.DataSource = tblResult
                    ddlLocSource.DataTextField = "Symbol"
                    ddlLocSource.DataValueField = "ID"
                    ddlLocSource.DataBind()
                    hidFormAction.Value = 0
                End If
            End If

            If Not tblResult Is Nothing Then
                tblResult = Nothing
            End If
        End Sub

        ' Event: btnLocRemove_Click
        ' Purpose: Execute now
        Private Sub btnLocRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocRemove.Click
            Dim strPath As String
            Dim strItemCode As String = ""
            Dim strListCopyNum As String = ""
            Dim arrCopyNum() As String
            Dim arrCopyNums() As String
            Dim inti As Integer
            Dim intk As Integer = 0
            Dim intLengCopyNum = 100 ' Number of copynumber for update
            Dim intTotalItem As Integer = 0
            Dim intOnLoan As Integer = 0
            Dim intReasonID As Integer = 0
            Dim inttOnLoan As Integer = 0
            Dim inttTotalItem As Integer = 0
            Dim intOnInventory As Integer = 0
            Dim inttOnInventory As Integer = 0
            Dim strHtml As String = ""
            Dim strLiquidCode As String = txtCodeRemove.Text.Trim
            Dim intTotalItems As Integer = 0
            Dim objDirInfor As DirectoryInfo
            Dim strRemovedDate As String = ""

            If rdbCodeDoc.Checked Then
                strItemCode = txtCodeDoc.Text
            Else
                'get list copynumber
                If rdbCopyNumFile.Checked Then
                    'get from file
                    strPath = Server.MapPath("") & "/UploadRemove"
                    objDirInfor = New DirectoryInfo(strPath)
                    If Not objDirInfor.Exists Then
                        Call objDirInfor.Create()
                    End If
                    Dim strNamefile As String = "tmp" & Now.Year & CStr(Now.Month).PadLeft(2, "0") & CStr(Now.Day).PadLeft(2, "0") & CStr(Now.Hour).PadLeft(2, "0") & CStr(Now.Minute).PadLeft(2, "0") & CStr(Now.Second).PadLeft(2, "0") & CStr(Now.Millisecond).PadLeft(3, "0") & ".txt"
                    UpLoadFiles(FileCopyNum, strPath, strNamefile)
                    If Not FileCopyNum.Value = "" Then
                        strListCopyNum = Trim(ReadFromFile(strPath & "\" & strNamefile))
                    End If
                Else
                    'get list form
                    strListCopyNum = Trim(txtCopyNumManual.Text)
                End If
                ' repair strListCopyNum
                If strListCopyNum <> "" Then
                    strListCopyNum = strListCopyNum.Replace(Chr(10), "")
                    strListCopyNum = strListCopyNum.Replace(Chr(13), ",")
                    strListCopyNum = strListCopyNum.Replace(Chr(9), ",")
                    strListCopyNum = strListCopyNum.Replace(";", ",")
                    If Right(strListCopyNum, 1) = "," Then
                        strListCopyNum = Left(strListCopyNum, Len(strListCopyNum) - 1)
                    End If
                    arrCopyNum = Split(strListCopyNum, ",")
                    strListCopyNum = ""
                    intTotalItem = arrCopyNum.Length
                    'gen arrCopyNum
                    For inti = 0 To arrCopyNum.Length - 1
                        strListCopyNum = strListCopyNum & Trim(arrCopyNum(inti)) & ","
                        If inti + 1 >= (intk + 1) * intLengCopyNum Then
                            ReDim Preserve arrCopyNums(intk)
                            strListCopyNum = Left(strListCopyNum, strListCopyNum.Length - 1)
                            arrCopyNums(intk) = strListCopyNum
                            intk = intk + 1
                            strListCopyNum = ""
                        End If
                    Next
                    If inti > intk * intLengCopyNum Then
                        If (2 * (inti - intk * intLengCopyNum) >= intLengCopyNum) Or (intk = 0) Then
                            ReDim Preserve arrCopyNums(intk)
                            strListCopyNum = Left(strListCopyNum, strListCopyNum.Length - 1)
                            arrCopyNums(intk) = strListCopyNum
                        Else
                            arrCopyNums(intk - 1) = arrCopyNums(intk - 1) & "," & strListCopyNum
                        End If
                    End If
                End If
            End If

            lblLibName.Text = lblLibName.Text & " " & ddlLibSource.SelectedItem.Text
            lblLocName.Text = lblLocName.Text & " " & hidLocSourceName.Value
            lblReasonR.Text = lblReasonR.Text & " " & ddlReason.SelectedItem.Text

            intReasonID = ddlReason.SelectedValue
            strRemovedDate = txtDateRemove.Text
            objBCopyNumber.ReasonID = intReasonID

            ' Display the progress bar

            strHtml = "<span id='spnMain' style='height: 60px; COLOR: #3333ff'	class='lblLabel'>"
            If strItemCode = "" Then
                strHtml = strHtml & "<span id='spnPecent' style=' COLOR: #FFFFFF;FONT-WEIGHT: bold;'>0%</span>"
            Else
                strHtml = strHtml & "<span id='spnPecent' style=' COLOR: #FFFFFF; FONT-WEIGHT: bold;'>100%</span>"
            End If

            strHtml = strHtml & "<span id='spnlbProcessing' style='LEFT: 250px; TOP: 60px;TEXT-ALIGN: center;'>" & ddlLabelNote.Items(9).Text & "</span>"
            If strItemCode = "" Then
                strHtml = strHtml & lblLibName.Text & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
                strHtml = strHtml & lblLocName.Text & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
            Else
                strHtml = strHtml & ddlLabelNote.Items(11).Text & " " & strItemCode & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
            End If
            strHtml = strHtml & lblReasonR.Text
            strHtml = strHtml & "<table height=10px cellspacing=0 cellpadding=0><tr><td></td><tr></table>"

            If strItemCode <> "" Then
                objBCopyNumber.CopyIDs = ""

                ' Start liquidate
                Call objBCopyNumber.Liquidate(intOnLoan, intTotalItem, intOnInventory, strRemovedDate, intReasonID, strItemCode, strLiquidCode)

                ' Display the progress bar
                strHtml = strHtml & "<table width=100% border=1 bgcolor=#999966 height=30px cellspacing=0 cellpadding=0><tr><td>"
                strHtml = strHtml & "<table id='spnProgess' width=100% border=0 bgcolor=#006291 height=100%><tr><td></td></tr></table></td></tr></table></span>"
                Response.Write(strHtml)
            Else
                strHtml = strHtml & "<table width=100% border=1 bgcolor=#999966 height=30px cellspacing=0 cellpadding=0><tr><td>"
                strHtml = strHtml & "<table id='spnProgess' width=0% border=0 bgcolor=#006291 height=100%><tr><td></td></tr></table></td></tr></table></span>"

                Response.Write(strHtml)
                intTotalItems = intTotalItem
                intTotalItem = 0
                For inti = 0 To arrCopyNums.Length - 1

                    ' Start liquidate
                    objBCopyNumber.CopyIDs = arrCopyNums(inti)
                    Call objBCopyNumber.Liquidate(inttOnLoan, inttTotalItem, intOnInventory, strRemovedDate, intReasonID, strItemCode, strLiquidCode)

                    ' Display the progress bar
                    Call BindPrg(inti, arrCopyNums.Length)
                    intOnLoan = intOnLoan + inttOnLoan
                    intTotalItem = intTotalItem + inttTotalItem
                    intOnInventory = intOnInventory + inttOnInventory
                Next
            End If

            Response.Write("<script language='javascript'>spnlbProcessing.innerHTML ='" & ddlLabelNote.Items(1).Text & "';</script>")

            ' Write log
            Call WriteLog(94, ddlLabelNote.Items(6).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
            If intTotalItems > intTotalItem Then
                lblTotalRemove.Text = lblTotalRemove.Text & " " & CStr(intTotalItems) & " (" & ddlLabelNote.Items(12).Text & " " & CStr(intTotalItem) & ")"
            Else
                lblTotalRemove.Text = lblTotalRemove.Text & " " & CStr(intTotalItem)
            End If
            lblNumRemove.Text = lblNumRemove.Text & " " & CStr(intTotalItem - intOnLoan - intOnInventory)
            lblNumNoRemove.Text = lblNumNoRemove.Text & " " & CStr(intOnLoan + intOnInventory)
            lblNumNoRemove1.Text = lblNumNoRemove1.Text & " " & CStr(intOnLoan)
            lblNumNoRemove2.Text = lblNumNoRemove2.Text & " " & CStr(intOnInventory)
            hidFormAction.Value = 1
        End Sub

        ' BindPrg method 
        ' Purpose: Bind data for Controls
        Public Sub BindPrg(ByVal intCurrent As Integer, ByVal intSum As Integer)
            Dim intCurrentPercent As Integer
            intCurrentPercent = ((intCurrent + 1) * 100) / intSum
            System.Threading.Thread.Sleep(50 / intSum)
            Response.Write("<script language='javascript'>spnProgess.width =" & intCurrentPercent & " + '%'; spnPecent.innerHTML =" & intCurrentPercent & " + '%';</script>")
            Response.Flush()
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBLibrary Is Nothing Then
                    objBLibrary.Dispose(True)
                    objBLibrary = Nothing
                End If
                If Not objBLocation Is Nothing Then
                    objBLocation.Dispose(True)
                    objBLocation = Nothing
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