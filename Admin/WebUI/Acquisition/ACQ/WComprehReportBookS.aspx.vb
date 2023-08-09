' Class: WComprehReportBookS
' Puspose: generate Comprehensive Report Book
' Creator: Sondp
' CreatedDate: 11/04/2005
' Modification History:

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports System.Math

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WComprehReportBookS
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblSelect As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private ojbBT As New clsBTemplate
        Private objBCB As New clsBCommonBusiness
        Private objBCDBS As New clsBCommonDBSystem

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckPemissions()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call DisposeSession()
                Call BindData()
            End If
        End Sub
        ' CheckPemission method
        Private Sub CheckPemissions()
            ' Check permisssion
            If Not CheckPemission(217) Then
                btnPrint.Enabled = False
            End If
        End Sub
        ' Method: Initialize
        ' Purpose: Init all need objects
        Private Sub Initialize()
            ' Initialize ojbBT object
            ojbBT.InterfaceLanguage = Session("InterfaceLanguage")
            ojbBT.DBServer = Session("DBServer")
            ojbBT.ConnectionString = Session("ConnectionString")
            Call ojbBT.Initialize()

            ' Initialize objBCB object
            objBCB.InterfaceLanguage = Session("InterfaceLanguage")
            objBCB.DBServer = Session("DBServer")
            objBCB.ConnectionString = Session("ConnectionString")
            Call objBCB.Initialize()

            ' Initialize objBCDBS object
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            Call objBCDBS.Initialize()
        End Sub

        ' BindData method
        Private Sub BindData()
            Dim tblLib As New DataTable
            Dim listItem As New listItem

            ddlLibrary.Items.Clear()

            ' Get Library
            tblLib = objBCB.GetLibraries(0, 1, , Session("UserID"))
            If Not tblLib Is Nothing AndAlso tblLib.Rows.Count > 0 Then
                ddlLibrary.DataSource = InsertOneRow(tblLib, ddlLog.Items(3).Text)
                ddlLibrary.DataTextField = "Code"
                ddlLibrary.DataValueField = "ID"
                ddlLibrary.DataBind()
            Else
                listItem.Text = ddlLog.Items(3).Text
                listItem.Value = 0
                ddlLibrary.Items.Add(listItem)
            End If
            'Tulnn edit 10/9
            If Not Request.QueryString("ItemCode") & "" = "" Then
                txtFromCodeItem.Text = Request.QueryString("ItemCode")
                txtToCodeItem.Text = Request.QueryString("ItemCode")
                optCodeItem.Checked = True
            End If
        End Sub

        ' BindJS method
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language='javascript' src='../Js/ACQ/WComprehReportBook.js'></script>")
            Me.RegisterCalendar("../..")
            SetOnclickCalendar(hrfFromTime, txtFromTime, ddlLog.Items(2).Text)
            SetOnclickCalendar(hrfToTime, txtToTime, ddlLog.Items(2).Text)
            Me.SetCheckNumber(txtItemsOnPage, ddlLog.Items(2).Text, 20)
            Me.SetCheckNumber(txtSequency, ddlLog.Items(2).Text)
            btnReset.Attributes.Add("OnClick", "ResetForm(); return false;")
            'Tulnn edit 10/9
            optCodeItem.Attributes.Add("OnClick", "document.forms[0].txtFromCodeItem.focus();")
            txtFromCodeItem.Attributes.Add("OnClick", "document.forms[0].optCodeItem.checked=true;")
            txtToCodeItem.Attributes.Add("OnClick", "document.forms[0].optCodeItem.checked=true;")
            optCopyNumber.Attributes.Add("OnClick", "document.forms[0].txtFromCopyNumber.focus();")
            txtFromCopyNumber.Attributes.Add("OnClick", "document.forms[0].optCopyNumber.checked=true;")
            txtToCopyNumber.Attributes.Add("OnClick", "document.forms[0].optCopyNumber.checked=true;")
            optElse.Attributes.Add("OnClick", "document.forms[0].txtElse.focus();")
            txtElse.Attributes.Add("OnClick", "document.forms[0].optElse.checked=true;")
        End Sub

        ' Event: btnPrint_Click
        Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
            Call GetData("PRINT")
        End Sub

        ' Event: btnSaveToFile_Click
        Private Sub btnSaveToFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveToFile.Click
            Call GetData("FILE")
        End Sub

        ' Event: btnPreview_Click
        Private Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPreview.Click
            Call GetData("PREVIEW")
        End Sub

        ' GetData method
        ' Purpose: Get ItemID before submit page
        ' In: strSign
        Private Sub GetData(ByVal strSign As String)
            Dim tblItems As New DataTable
            Dim collectReport As New Collection
            Dim arrItemIDs(), strSQL As String
            Dim lngi As Long
            Dim inti As Integer
            ReDim arrItemIDs(0)
            If txtSequency.Text = "" Or Not IsNumeric(txtSequency.Text) Then
                txtSequency.Text = 1
            End If
            If txtItemsOnPage.Text = "" Or Not IsNumeric(txtItemsOnPage.Text) Then
                txtItemsOnPage.Text = 25
            End If
            collectReport.Add(txtFromTime.Text, "<$FROMTIME$>")
            collectReport.Add(txtToTime.Text, "<$TOTIME$>")

            objBCDBS.SQLStatement = FormingSQLComprehensiveReportBookCondition(False)
            tblItems = objBCDBS.RetrieveItemInfor
            If Not tblItems Is Nothing Then
                If tblItems.Rows.Count > 0 Then
                    ReDim arrItemIDs(tblItems.Rows.Count - 1)
                    For lngi = 0 To tblItems.Rows.Count - 1
                        arrItemIDs(lngi) = tblItems.Rows(lngi).Item("ItemID")
                    Next
                    For inti = 0 To ddlInfor.Items.Count - 1
                        collectReport.Add(ddlInfor.Items(inti).Text, ddlInfor.Items(inti).Value)
                    Next
                    collectReport.Add(strSign, "<$SIGN$>")
                    collectReport.Add(1, "<$CURRENTPAGE$>")
                    collectReport.Add(arrItemIDs, "<$ITEMIDS$>")
                    collectReport.Add(ddlLibrary.SelectedValue, "<$LIBRARY$>")
                    collectReport.Add(tblItems.Rows.Count, "<$UBOUND$>")
                    collectReport.Add(txtSequency.Text, "<$SEQUENCY$>")
                    collectReport.Add(txtItemsOnPage.Text, "<$ITEMSONPAGE$>")
                    collectReport.Add(Math.Ceiling(tblItems.Rows.Count / CInt(txtItemsOnPage.Text)), "<$MAXPAGE$>")
                    Session("Report") = collectReport
                    Response.Redirect("WComprehReportBookF.aspx?Sign=" & strSign)
                End If
                Call DisposeSession()
                Page.RegisterClientScriptBlock("NotFoundData1", "<script language='javascript'>alert('" & ddlLog.Items(4).Text & "');</script>")
            Else
                Call DisposeSession()
                Page.RegisterClientScriptBlock("NotFoundData2", "<script language='javascript'>alert('" & ddlLog.Items(4).Text & "');</script>")
            End If
        End Sub
        ' Purpoose: Forming search SQL for Gen ComprehensiveReportBook
        ' In: some infor
        ' Out: String
        ' Creator: Tulnn base on FormingSQLComprehensiveReportBook
        Public Function FormingSQLComprehensiveReportBookCondition(Optional ByVal boolWhere As Boolean = False) As String
            Dim intLibID As Integer = ddlLibrary.SelectedValue
            Dim strFromAcqTime As String = txtFromTime.Text
            Dim strToAcqTime As String = txtToTime.Text
            Dim strWhere As String
            Dim strSelectSQL As String
            strWhere = ""
            strSelectSQL = ""
            ' Select Library
            If intLibID > 0 Then
                strWhere = strWhere & " AND LibID=" & intLibID
            End If
            'Tulnn edit 10/9
            If optCodeItem.Checked = True Then
                If txtFromCodeItem.Text <> "" Then
                    strWhere = strWhere & " AND ItemID >=" & txtFromCodeItem.Text & ""
                End If
                If txtToCodeItem.Text <> "" Then
                    strWhere = strWhere & " AND ItemID <=" & txtToCodeItem.Text & ""
                End If
            ElseIf optCopyNumber.Checked = True Then
                If txtFromCopyNumber.Text <> "" Then
                    strWhere = strWhere & " AND UPPER(CopyNumber)>='" & txtFromCopyNumber.Text & "'"
                End If
                If txtToCopyNumber.Text <> "" Then
                    strWhere = strWhere & " AND UPPER(CopyNumber)<='" & txtToCopyNumber.Text & "'"
                End If
            ElseIf optElse.Checked = True Then
                If txtElse.Text.Trim <> "" Then
                    Dim arr() As String = Split(ojbBT.SplitCopyNumber(txtElse.Text, ";", True), ",")
                    Dim strid As String
                    For i As Integer = 0 To arr.Length - 1
                        If strid = "" Then
                            strid = "'" & arr(i) & "'"
                        Else
                            strid &= ",'" & arr(i) & "'"
                        End If
                    Next
                    strWhere = strWhere & " AND CopyNumber IN (" & strid & ")"
                End If
            End If
            'End edit 10/9
            'From Acq time
            If strFromAcqTime <> "" Then
                'If strDBServer.ToUpper = "ORACLE" Then
                '    strWhere = strWhere & " AND AcquiredDate>=TO_DATE('" & objBCDBS.ConvertDateBack(strFromAcqTime) & "','MM/DD/YYYY HH24:MI:SS')"
                'Else
                strWhere = strWhere & " AND AcquiredDate>='" & objBCDBS.ConvertDateBack(strFromAcqTime) & "'"
                'End If
            End If
            ' To Acq time
            If strToAcqTime <> "" Then
                'If strDBServer.ToUpper = "ORACLE" Then
                '    strWhere = strWhere & " AND AcquiredDate<=TO_DATE('" & objBCDBS.ConvertDateBack(strToAcqTime) & "','MM/DD/YYYY HH24:MI:SS')"
                'Else
                strWhere = strWhere & " AND AcquiredDate<='" & objBCDBS.ConvertDateBack(strToAcqTime) & "'"
                'End If
            End If
            strWhere = " 1=1" & strWhere
            If Not boolWhere Then ' Return full select command
                If Not strWhere = "" Then
                    strSelectSQL = "SELECT ItemID FROM HOLDING WHERE" & strWhere & " GROUP BY ItemID"
                Else
                    strSelectSQL = "SELECT TOP 1000 ItemID FROM HOLDING GROUP BY ItemID"
                End If
            Else ' Return cordition select only
                strSelectSQL = strWhere
            End If
            ' Return value
            FormingSQLComprehensiveReportBookCondition = strSelectSQL
        End Function

        ' Dispose Session method
        Private Sub DisposeSession()
            If Not Session("Report") Is Nothing Then
                Session("Report") = Nothing
            End If
        End Sub

        ' Page_Unload method
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not ojbBT Is Nothing Then
                ojbBT.Dispose(True)
                ojbBT = Nothing
            End If
            If Not objBCB Is Nothing Then
                objBCB.Dispose(True)
                objBCB = Nothing
            End If
            If Not objBCDBS Is Nothing Then
                objBCDBS.Dispose(True)
                objBCDBS = Nothing
            End If
        End Sub
    End Class
End Namespace