' class WGenCopyNumListR
' Puspose: process generation list copynumber
' Creator: lent
' CreatedDate: 21-2-2005
' Modification History:

Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition
Imports eMicLibAdmin.BusinessRules.Common
Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WGenCopyNumListR
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblContent As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBCopyNumber As New clsBCopyNumber

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckPermission()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Method: CheckPermission 
        ' Purpose: Check permission
        Private Sub CheckPermission()
            If Not CheckPemission(120) Then
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: Init all neccessary objects
        Private Sub Initialize()
            ' Initialize objBCopyNumber object
            objBCopyNumber.DBServer = Session("DBServer")
            objBCopyNumber.ConnectionString = Session("ConnectionString")
            objBCopyNumber.InterfaceLanguage = Session("InterfaceLanguage")
            objBCopyNumber.Initialize()
        End Sub

        ' Method: BindJS
        ' Purpose: include need js functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
        End Sub

        ' BindData method
        ' Purpose: Load data
        Private Sub BindData()
            Dim tblResult As DataTable
            Dim intItem As Integer
            Dim intCount As Integer
            Dim intLibrary As Integer
            Dim intLocation As Integer
            Dim strShelf As String
            Dim strToCopyNum As String
            Dim strFromCopyNum As String
            Dim intCopyNum1Page As Integer = 20
            Dim intPageIndex As Integer
            Dim intOrderBy As Integer = 0
            Dim intDesc As Integer = 1
            Dim strContent As String = ""
            Dim intStartPage As Integer
            Dim intLastPage As Integer
            Dim blnNoInfor As Boolean = True
            Dim strTemp As String
            Dim blnFound As Boolean = False

            ' Get data to form menu
            If (Not Request("ddlLibrary") Is Nothing) AndAlso (Request("ddlLibrary") <> "") Then
                intLibrary = CInt(Request("ddlLibrary"))
            End If
            If (Not Request("ddlLocation") Is Nothing) AndAlso (Request("ddlLocation") <> "") Then
                intLocation = CInt(Request("ddlLocation"))
            End If
            strShelf = Request("txtShelf")
            strToCopyNum = Request("txtToCopyNum")
            strFromCopyNum = Request("txtFromCopyNum")
            intCopyNum1Page = CInt(Request("txtCopyNum1Page"))
            intPageIndex = CInt(Request("txtPageIndex"))
            Session("LocationText") = lblLocation.Text & " " & Request("hidNameLocation")
            lblLocation.Text = lblLocation.Text & " " & Request("hidNameLocation")
            lblNumPage.Text = "- " & CStr(intPageIndex) & " -"
            lblDateInventory.Text = lblDateInventory.Text & " " & Day(Now) & "/" & Month(Now) & "/" & Year(Now)

            If Request("hidOrderBy") & "" <> "" Then
                intOrderBy = CInt(Request("hidOrderBy"))
            End If
            If Request("ckbDesc") & "" <> "" Then
                If Request("ckbDesc").ToUpper = "ON" Then
                    intDesc = 0
                End If
            End If

            ' Get list of copynumbers
            objBCopyNumber.LibID = intLibrary
            objBCopyNumber.LocID = intLocation
            objBCopyNumber.Shelf = strShelf
            objBCopyNumber.ToCopyNum = strToCopyNum
            objBCopyNumber.FromCopyNum = strFromCopyNum
            objBCopyNumber.Orderby = intOrderBy
            objBCopyNumber.OrderByDesc = intDesc
            tblResult = objBCopyNumber.GenListCopyNumber
            ' Show list of copynumbers
            If Not tblResult Is Nothing Then
                If tblResult.Rows.Count > 0 Then
                    dtgResult.PageSize = intCopyNum1Page
                    dtgResult.CurrentPageIndex = intPageIndex - 1
                    dtgResult.DataSource = tblResult
                    dtgResult.DataBind()
                    blnFound = True
                End If
            End If

            ' Not found
            If Not blnFound Then
                Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & ddlLabel.Items(3).Text & "');</script>")
            End If
        End Sub
        Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
            Dim tblData As New DataTable("tblResult")
            tblData = Session("tblListCopynumber")

            If Not IsNothing(tblData) AndAlso tblData.Rows.Count > 0 Then

                'tblData.Columns.Add("STT")
                'Dim intSTT As Integer = 1
                'For Each row As DataRow In tblData.Rows
                '    row("STT") = intSTT
                '    intSTT = intSTT + 1
                'Next
                Dim tblConvert As New DataTable("tblConvert")
                ConvertTable(tblData, tblConvert)
                tblConvert.Columns.Add(ddlLabelHeaderTable.Items(5).Text)
                tblConvert.Rows.Add(ddlLabelHeaderTable.Items(0).Text, ddlLabelHeaderTable.Items(1).Text,
                                    ddlLabelHeaderTable.Items(2).Text, ddlLabelHeaderTable.Items(3).Text,
                                    ddlLabelHeaderTable.Items(4).Text, ddlLabelHeaderTable.Items(5).Text)

                Dim strHTMLContent As New StringBuilder()
                strHTMLContent.Append("<html>")
                strHTMLContent.Append("<body>")
                strHTMLContent.Append("<div>")
                strHTMLContent.Append("<h2 align='center'> Danh sách dang ký cá biệt</h2>")
                strHTMLContent.Append("</div>")
                strHTMLContent.Append("<div>")
                strHTMLContent.Append("<label>" & Session("LocationText") & "</label>")
                strHTMLContent.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                strHTMLContent.Append("<label>" & lblDateInventory.Text & " <label>" & " " & Day(Now) & "/" & Month(Now) & "/" & Year(Now) & "</label>")
                strHTMLContent.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                strHTMLContent.Append("<label>" & lblInventor.Text & "</label>")
                strHTMLContent.Append("</div>")
                strHTMLContent.Append(clsBExportHelper.GenDataTableToString(tblConvert))
                strHTMLContent.Append("</body>")
                strHTMLContent.Append("</html>")

                clsExport.StringBuilderToExcel(strHTMLContent)
            End If
        End Sub
        Private Sub ConvertTable(ByVal tblResult As DataTable, ByRef tblConvert As DataTable)
            If (Not IsNothing(tblResult)) AndAlso (tblResult.Rows.Count > 0) Then
                tblConvert.Clear()
                tblConvert.Columns.Add("STT")
                tblConvert.Columns.Add("Content")
                tblConvert.Columns.Add("Shelf")
                tblConvert.Columns.Add("CallNumber")
                tblConvert.Columns.Add("CopyNumber")

                For Each rows As DataRow In tblResult.Rows
                    Dim dtRow As DataRow = tblConvert.NewRow()
                    Dim stt As String = rows.Item("OrderNum") & ""
                    Dim strContent As String = rows.Item("Content") & ""
                    Dim strShelf As String = rows.Item("Shelf") & ""
                    Dim strCallNumber As String = rows.Item("CallNumber") & ""
                    Dim strCopyNumber As String = rows.Item("CopyNumber") & ""

                    dtRow.Item("STT") = stt
                    dtRow.Item("Content") = strContent
                    dtRow.Item("Shelf") = strShelf
                    dtRow.Item("CallNumber") = strCallNumber
                    dtRow.Item("CopyNumber") = strCopyNumber

                    tblConvert.Rows.Add(dtRow)
                Next
            End If
        End Sub
        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
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