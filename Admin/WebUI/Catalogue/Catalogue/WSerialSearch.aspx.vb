' Class: WSerialSearch
' Puspose: Show serial search form
' Creator: Oanhtn
' CreatedDate: 25/05/2005
' Modification History:

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WSerialSearch
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblRegularity As System.Web.UI.WebControls.Label
        Protected WithEvents txbRegularity As System.Web.UI.WebControls.TextBox


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBCDBS As New clsBCommonDBSystem
        Private objBIC As New clsBItemCollection
        Private objBCSP As New clsBCommonStringProc

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
        End Sub

        ' Method: Initialize
        ' Purpose: Init all need objects
        Private Sub Initialize()
            ' Init objBCommon object
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            Call objBCDBS.Initialize()

            ' Init objBIC object
            objBIC.InterfaceLanguage = Session("InterfaceLanguage")
            objBIC.DBServer = Session("DBServer")
            objBIC.ConnectionString = Session("ConnectionString")
            Call objBIC.Initialize()

            ' Init objBCSP object
            objBCSP.InterfaceLanguage = Session("InterfaceLanguage")
            objBCSP.DBServer = Session("DBServer")
            objBCSP.ConnectionString = Session("ConnectionString")
            Call objBCSP.Initialize()

            If Not Request("FieldCode") = "" Then
                hidFieldCode.Value = Trim(Request("FieldCode"))
            End If
        End Sub

        ' BindJS method
        ' Purpose: include all need js functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("CataJs", "<script language = 'javascript' src = '../Js/Catalogue/WCata.js'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../Js/Catalogue/WSerialSearch.js'></script>")

            btnReset.Attributes.Add("onClick", "ClearAll(); return false;")
            'btnSearch.Attributes.Add("onClick", "if (!CheckAll('" & ddlLabel.Items(2).Text & "')) {return false;}")

            txbFromDate.Attributes.Add("OnChange", "if (!CheckDate(this, '" & Session("DateFormat") & "', '" & ddlLabel.Items(5).Text & " (" & Session("DateFormat") & ")')) {this.value=''; this.focus();}")
            txbFromDate.ToolTip = Session("DateFormat")
            txbToDate.Attributes.Add("OnChange", "if (!CheckDate(this, '" & Session("DateFormat") & "', '" & ddlLabel.Items(5).Text & " (" & Session("DateFormat") & ")')) {this.value=''; this.focus();}")
            txbToDate.ToolTip = Session("DateFormat")
            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkFromDate, txbFromDate, ddlLabel.Items(5).Text)
            SetOnclickCalendar(lnkToDate, txbToDate, ddlLabel.Items(5).Text)
        End Sub

        ' Method: SearchItem
        Sub SearchItem()
            Dim arrBool()
            Dim arrVal()
            Dim arrField()
            Dim arrItemID()
            Dim dtRow() As DataRow
            Dim intk
            Dim intIndex As Integer
            Dim lngItemID As Long
            Dim tblItem As New DataTable
            Dim tblIssue As New DataTable
            Dim strIDs As String
            Dim intTotalItem As Integer
            Dim strISBD As String = ""
            Dim strAdded As String = ""
            Dim strTemp As String = ""
            Dim strSQL As String = ""
            Dim intSubIndex As Integer
            Dim tblRow As TableRow
            Dim tblCell As TableCell
            Dim lblTemp As Label
            Dim imgTemp As System.Web.UI.WebControls.Image

            ' Get periodical list
            tblItem = objBIC.GetPeriodicalList(txbTitle.Text.Trim, txbFromDate.Text.Trim, txbToDate.Text.Trim, txbIssue.Text.Trim, txbVolume.Text.Trim)
            ' Get issues list
            tblIssue = objBIC.GetIssueList(txbTitle.Text.Trim, txbFromDate.Text.Trim, txbToDate.Text.Trim, txbIssue.Text.Trim, txbVolume.Text.Trim)
            intTotalItem = tblIssue.Rows.Count
            If Not tblIssue Is Nothing AndAlso intTotalItem > 0 Then
                Call ShowControls(True)
                lblResult.Text = intTotalItem

                ' Create header of result table
                ' Add image
                tblRow = New TableRow
                tblCell = New TableCell
                lblTemp = New Label
                lblTemp.Text = ddlLabel.Items(3).Text.Trim
                tblCell.Controls.Add(lblTemp)
                tblCell.Width = Unit.Percentage(7)
                tblRow.Cells.Add(tblCell)

                ' Add text
                tblCell = New TableCell
                lblTemp = New Label
                lblTemp.Text = ddlLabel.Items(4).Text.Trim
                tblCell.Controls.Add(lblTemp)
                tblRow.Cells.Add(tblCell)

                tblRow.CssClass = "lbGridHeader"
                tblResult.Rows.Add(tblRow)

                For intIndex = 0 To intTotalItem - 1
                    lngItemID = CLng(tblIssue.Rows(intIndex).Item("ItemID").ToString)
                    strISBD = ""
                    strAdded = ""

                    ' Get title
                    dtRow = tblItem.Select("ItemID = " & lngItemID)
                    If dtRow.Length > 0 Then
                        strTemp = objBCSP.TheDisplayOne(dtRow(0).Item("Content").ToString.Trim)
                        strISBD = strISBD & strTemp
                        strAdded = strAdded & "$t" & strTemp
                    End If
                    tblItem.Select()

                    ' Get physical information
                    strTemp = objBCSP.TheDisplayOne(tblIssue.Rows(intIndex).Item("PhysDetail").ToString)
                    If Not strTemp = "" Then
                        strISBD = strISBD & ". - " & strTemp
                        strAdded = strAdded & "$h" & strTemp
                    End If

                    ' Get IssueNo
                    strTemp = objBCSP.TheDisplayOne(tblIssue.Rows(intIndex).Item("OvIssueNo").ToString)
                    If Not strTemp = "" Then
                        strTemp = objBCSP.TheDisplayOne(tblIssue.Rows(intIndex).Item("IssueNo").ToString) & " (" & strTemp & ")"
                    Else
                        strTemp = objBCSP.TheDisplayOne(tblIssue.Rows(intIndex).Item("IssueNo").ToString)
                    End If

                    strISBD = strISBD & ". - " & ddlLabel.Items(6).Text.Trim & " " & strTemp
                    strAdded = strAdded & "$e" & strTemp

                    ' Get IssuedDate
                    strTemp = objBCSP.TheDisplayOne(tblIssue.Rows(intIndex).Item("ISSUEDDATE").ToString)
                    If Not strTemp = "" Then
                        strISBD = strISBD & ". - " & strTemp
                        strAdded = strAdded & "$f" & strTemp
                    End If

                    strAdded = strAdded & "$w" & lngItemID
                    strAdded = strAdded.Replace("'", "\'")

                    ' Add data to table
                    tblRow = New TableRow
                    tblCell = New TableCell

                    ' Add image
                    imgTemp = New Web.UI.WebControls.Image
                    imgTemp.ImageUrl = "../../Images/select.jpg"
                    imgTemp.Attributes.Add("OnClick", "javascript:ReLoadData('" & hidFieldCode.Value.Trim & "', '" & strAdded & "')")
                    tblCell.Controls.Add(imgTemp)
                    tblCell.HorizontalAlign = HorizontalAlign.Center
                    tblRow.Cells.Add(tblCell)

                    ' Add text
                    tblCell = New TableCell
                    lblTemp = New Label
                    lblTemp.Text = strISBD
                    lblTemp.CssClass = "lbLabel"
                    tblCell.Controls.Add(lblTemp)
                    tblRow.Cells.Add(tblCell)

                    If (intIndex Mod 2) = 1 Then
                        tblRow.CssClass = "lbGridCell"
                    Else
                        tblRow.CssClass = "lbGridAlterCell"
                    End If
                    tblResult.Rows.Add(tblRow)
                Next
            Else
                Call ShowControls(False)
                Page.RegisterClientScriptBlock("AlterJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(7).Text.Trim & "');</script>")
            End If
        End Sub

        ' Method: ShowControls
        Private Sub ShowControls(ByVal blnShow As Boolean)
            lblCap.Visible = blnShow
            lblCapResult.Visible = blnShow
            lblResult.Visible = blnShow
            lblCapResult.Visible = blnShow
            tblResult.Visible = blnShow
        End Sub

        ' Event: btnSearch_Click
        ' Purpose: search item
        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            Call SearchItem()
        End Sub

        ' Page_Unload Method
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Release all object
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBIC Is Nothing Then
                    objBIC.Dispose(True)
                    objBIC = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace