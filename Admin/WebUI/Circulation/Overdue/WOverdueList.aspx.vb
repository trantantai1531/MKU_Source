' Class: WOverdueList
' Puspose: List all Patron Overdue 
' Creator: Sondp
' CreatedDate: 28/8/2004
' Modification History:
'   - 18/04/2005 by Oanhtn: review 

Imports eMicLibAdmin.WebUI.Common
Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Common

Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Telerik.Web.UI
Imports eMicLibAdmin.BusinessRules.Patron

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WOverdueList
        Inherits clsWBase
        Implements IUCNumberOfRecord

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents OverdueList As System.Web.UI.HtmlControls.HtmlTable


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBOverdueTransaction As New clsBOverdueTransaction
        Private objBFaculty As New clsBFaculty
        Private objBPatronGroup As New clsBPatronGroup

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call BindDLL()
            End If
        End Sub

        ' Initialize method
        ' Init all necessary objects
        Private Sub Initialize()
            ' Init objBOverdueTransaction object
            objBOverdueTransaction.ConnectionString = Session("ConnectionString")
            objBOverdueTransaction.DBServer = Session("DBServer")
            objBOverdueTransaction.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBOverdueTransaction.Initialize()
            ' Initialize objBFaculty object
            objBFaculty.DBServer = Session("DBServer")
            objBFaculty.ConnectionString = Session("ConnectionString")
            objBFaculty.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBFaculty.Initialize()
            ' Initialize objBFaculty object
            objBPatronGroup.DBServer = Session("DBServer")
            objBPatronGroup.ConnectionString = Session("ConnectionString")
            objBPatronGroup.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPatronGroup.Initialize()
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(60) Then
                Call WritePermErrorMssg()
            End If
        End Sub

        ' BindScript method
        ' Purpose: include some necessary javascript functions
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
        End Sub

        Private Sub BindDLL()

            Dim tblFaculty As New DataTable

            tblFaculty = objBFaculty.GetFaculty()
            If Not tblFaculty Is Nothing Then
                If tblFaculty.Rows.Count > 0 Then
                    tblFaculty = InsertOneRow(tblFaculty, ddlLabel.Items(2).Text)
                    ddlFaculty.DataSource = tblFaculty
                    ddlFaculty.DataTextField = "Faculty"
                    ddlFaculty.DataValueField = "ID"
                    ddlFaculty.DataBind()
                End If
            End If

            Dim tblPatronGroup As DataTable = objBPatronGroup.GetPatronGroup()
            If Not tblPatronGroup Is Nothing AndAlso tblPatronGroup.Rows.Count > 0 Then
                ddlPatronGroup.DataSource = InsertOneRow(tblPatronGroup, ddlLabel.Items(2).Text)
                ddlPatronGroup.DataTextField = "Name"
                ddlPatronGroup.DataValueField = "ID"
                ddlPatronGroup.DataBind()
            End If

        End Sub

        ' Method: BindData
        ' Purpose: Bind Data to datagrid
        Private Sub BindData(Optional ByVal strSort As String = "", Optional ByVal intFacultyID As Integer = 0, Optional ByVal intPatronGroupID As Integer = 0)
            Dim tblOverdueList As New DataTable
            Dim inti As Integer
            objBOverdueTransaction.UserID = Session("UserID")
            objBOverdueTransaction.PatronIDs = ""
            tblOverdueList = objBOverdueTransaction.GetOverdueListAuthority(intFacultyID, intPatronGroupID)

            If Not tblOverdueList Is Nothing AndAlso tblOverdueList.Rows.Count > 0 Then

                'Dim dvOverdueList As DataView = New DataView(tblOverdueList)
                'If Not String.IsNullOrEmpty(strSort) Then
                '    dvOverdueList.Sort = strSort
                'End If
                'tblOverdueList = dvOverdueList.ToTable()

                Dim dcIndex = New DataColumn("Index", GetType(Int32))
                tblOverdueList.Columns.Add(dcIndex)

                For inti = 0 To tblOverdueList.Rows.Count - 1
                    tblOverdueList.Rows(inti).Item("Index") = inti + 1
                    tblOverdueList.Rows(inti).Item("PatronCode") = "<A href='#' OnClick=javascript:OpenWindow('../WPatronDetail.aspx?PatronCode=" & tblOverdueList.Rows(inti).Item("PatronCode") & "','PatronDetails',600,450,110,50);>" & tblOverdueList.Rows(inti).Item("PatronCode") & "</A>"
                Next
                dgrOverdue.DataSource = tblOverdueList
                'dgrOverdue.DataBind()
                btnExport.Visible = True
                lblNoListOverdue.Visible = False
                dgrOverdue.Visible = True
            Else
                dgrOverdue.DataSource = Nothing
                'dgrOverdue.DataBind()
                lblNoListOverdue.Visible = True
                dgrOverdue.Visible = False
                btnExport.Visible = False
            End If
            tblOverdueList = Nothing
        End Sub

        ' dgrOverdue_PageIndexChanged event
        ' Purpose: for change page index
        'Private Sub dgrOverdue_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrOverdue.PageIndexChanged
        '    Try
        '        dgrOverdue.CurrentPageIndex = e.NewPageIndex
        '        Call BindData()
        '    Catch ex As Exception
        '    End Try
        'End Sub

        Protected Sub dgrOverdue_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles dgrOverdue.NeedDataSource
            BindData("", CInt(ddlFaculty.SelectedItem.Value), CInt(ddlPatronGroup.SelectedItem.Value))
        End Sub

        ' dgrOverdue_SortCommand event
        ' Purpose: sort data
        'Protected Sub dgrOverdue_SortCommand(sender As Object, e As GridSortCommandEventArgs) Handles dgrOverdue.SortCommand
        '    BindData(e.SortExpression, CInt(ddlFaculty.SelectedItem.Value))
        '    'Dim tblOverdueList As DataTable
        '    'Dim dvOverdueList As DataView

        '    'tblOverdueList = Nothing
        '    ''tblOverdueList = objBOverdueTransaction.GetOverdueList
        '    'objBOverdueTransaction.UserID = Session("UserID")
        '    'objBOverdueTransaction.PatronIDs = ""
        '    'tblOverdueList = objBOverdueTransaction.GetOverdueListAuthority

        '    'If Not tblOverdueList Is Nothing AndAlso tblOverdueList.Rows.Count > 0 Then
        '    '    dvOverdueList = New DataView(tblOverdueList)
        '    '    dvOverdueList.Sort = e.SortExpression
        '    '    tblOverdueList = dvOverdueList.ToTable()

        '    '    Dim dcIndex = New DataColumn("Index", GetType(Int32))
        '    '    tblOverdueList.Columns.Add(dcIndex)
        '    '    For inti = 0 To tblOverdueList.Rows.Count - 1
        '    '        tblOverdueList.Rows(inti).Item("Index") = inti + 1
        '    '        tblOverdueList.Rows(inti).Item("PatronCode") = "<A href='#' OnClick=javascript:OpenWindow('../WPatronDetail.aspx?PatronCode=" & tblOverdueList.Rows(inti).Item("PatronCode") & "','PatronDetails',600,450,110,50);>" & tblOverdueList.Rows(inti).Item("PatronCode") & "</A>"
        '    '    Next

        '    '    dgrOverdue.DataSource = tblOverdueList
        '    '    dgrOverdue.Rebind()

        '    '    dvOverdueList = Nothing
        '    '    tblOverdueList = Nothing
        '    'End If
        'End Sub
        'Private Sub dgrOverdue_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgrOverdue.SortCommand
        '    Dim tblOverdueList As DataTable
        '    Dim dvOverdueList As DataView

        '    tblOverdueList = Nothing
        '    tblOverdueList = objBOverdueTransaction.GetOverdueList
        '    If Not tblOverdueList Is Nothing Then
        '        If tblOverdueList.Rows.Count > 0 Then
        '            dvOverdueList = New DataView(tblOverdueList)
        '            dvOverdueList.Sort = e.SortExpression
        '            dgrOverdue.DataSource = dvOverdueList
        '            dgrOverdue.DataBind()
        '        End If
        '        dvOverdueList = Nothing
        '        tblOverdueList = Nothing
        '    End If
        'End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBOverdueTransaction Is Nothing Then
                    objBOverdueTransaction.Dispose(True)
                    objBOverdueTransaction = Nothing
                End If
                If Not objBFaculty Is Nothing Then
                    objBFaculty.Dispose(True)
                    objBFaculty = Nothing
                End If
                If Not objBPatronGroup Is Nothing Then
                    objBPatronGroup.Dispose(True)
                    objBPatronGroup = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        Public Function NumberOfRecord() As Integer Implements IUCNumberOfRecord.NumberOfRecord
            Return 25
        End Function

        Private Sub ConvertTable(ByVal tblResult As DataTable, ByRef tblConvert As DataTable)
            If (Not IsNothing(tblResult)) AndAlso (tblResult.Rows.Count > 0) Then
                tblConvert.Clear()
                tblConvert.Columns.Add("STT")
                tblConvert.Columns.Add("FullName")
                tblConvert.Columns.Add("PatronCode")
                tblConvert.Columns.Add("MainTitle")
                tblConvert.Columns.Add("CopyNumber")
                tblConvert.Columns.Add("CheckOutDate")
                tblConvert.Columns.Add("CataloguerName")
                tblConvert.Columns.Add("CheckInDate")
                tblConvert.Columns.Add("OverdueDate")
                tblConvert.Columns.Add("Mobile")
                tblConvert.Columns.Add("Email")
                tblConvert.Columns.Add("Class")
                tblConvert.Columns.Add("Facebook")
                tblConvert.Columns.Add("GroupName")
                tblConvert.Columns.Add("Note")
                For Each rows As DataRow In tblResult.Rows
                    Dim dtRow As DataRow = tblConvert.NewRow()
                    Dim stt As String = rows.Item("Index") & ""
                    Dim strFullName As String = rows.Item("Name") & ""
                    Dim strPatronCode As String = rows.Item("PatronCode") & ""
                    Dim strMainTitle As String = rows.Item("MainTitle") & ""
                    Dim strCopyNumber As String = rows.Item("CopyNumber") & ""
                    Dim strCheckOutDate As String = rows.Item("CheckOutDate") & ""
                    Dim strCataloguerName As String = rows.Item("CataloguerName") & ""
                    Dim strCheckInDate As String = rows.Item("CheckInDate") & ""
                    Dim strOverdueDate As String = rows.Item("OverdueDate") & ""
                    Dim strMobile As String = rows.Item("Mobile") & ""
                    Dim strEmail As String = rows.Item("Email") & ""
                    Dim strClass As String = rows.Item("Class") & ""
                    Dim strFacebook As String = rows.Item("Facebook") & ""
                    Dim strGroupName As String = rows.Item("GroupName") & ""
                    Dim strNote As String = rows.Item("Note") & ""

                    dtRow.Item("STT") = stt
                    dtRow.Item("FullName") = strFullName
                    dtRow.Item("PatronCode") = strPatronCode
                    dtRow.Item("MainTitle") = strMainTitle
                    dtRow.Item("CopyNumber") = strCopyNumber
                    dtRow.Item("CheckOutDate") = String.Format("{0:dd/MM/yyyy}", strCheckOutDate)
                    dtRow.Item("CataloguerName") = strCataloguerName
                    dtRow.Item("CheckInDate") = String.Format("{0:dd/MM/yyyy}", strCheckInDate)
                    dtRow.Item("OverdueDate") = strOverdueDate
                    dtRow.Item("Mobile") = strMobile
                    dtRow.Item("Email") = strEmail
                    dtRow.Item("Class") = strClass
                    dtRow.Item("Facebook") = strFacebook
                    dtRow.Item("GroupName") = strGroupName
                    dtRow.Item("Note") = strNote

                    tblConvert.Rows.Add(dtRow)
                Next
            End If
        End Sub

        Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
            Dim tblOverdueList As New DataTable
            Dim inti As Integer
            objBOverdueTransaction.UserID = Session("UserID")
            objBOverdueTransaction.PatronIDs = ""
            tblOverdueList = objBOverdueTransaction.GetOverdueListAuthority(CInt(ddlFaculty.SelectedItem.Value))
            Dim dcIndex = New DataColumn("Index", GetType(Int32))
            tblOverdueList.Columns.Add(dcIndex)
            If Not tblOverdueList Is Nothing AndAlso tblOverdueList.Rows.Count > 0 Then
                For inti = 0 To tblOverdueList.Rows.Count - 1
                    tblOverdueList.Rows(inti).Item("Index") = inti + 1
                Next

                Dim tblConvert As New DataTable("tblConvert")
                ConvertTable(tblOverdueList, tblConvert)
                tblConvert.Rows.Add(ddlLabelHeaderTable.Items(0).Text, ddlLabelHeaderTable.Items(1).Text, ddlLabelHeaderTable.Items(2).Text, ddlLabelHeaderTable.Items(3).Text, ddlLabelHeaderTable.Items(4).Text, ddlLabelHeaderTable.Items(5).Text,
                                    ddlLabelHeaderTable.Items(6).Text, ddlLabelHeaderTable.Items(7).Text, ddlLabelHeaderTable.Items(8).Text, ddlLabelHeaderTable.Items(9).Text, ddlLabelHeaderTable.Items(10).Text, ddlLabelHeaderTable.Items(11).Text,
                                    ddlLabelHeaderTable.Items(12).Text, ddlLabelHeaderTable.Items(13).Text, ddlLabelHeaderTable.Items(14).Text)

                Dim strHTMLContent As New StringBuilder()
                strHTMLContent.Append(clsBExportHelper.GenDataTableToString(tblConvert))

                clsExport.StringBuilderToExcel(strHTMLContent)

                'Dim tblExport As DataTable = TableExport(tblOverdueList)

                'Dim filename As String = String.Format("Report_{0}.xls", DateAndTime.Now.Ticks)

                'Response.Clear()
                'Response.ClearContent()
                'Response.ClearHeaders()
                'Response.Buffer = True
                'Response.ContentType = "application/ms-excel"
                'Response.AddHeader("Content-Disposition", "attachment;filename=" & filename)

                'Response.Charset = Encoding.UTF8.EncodingName
                'Response.ContentEncoding = System.Text.Encoding.Unicode
                'Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble())
                'Response.Write("<Table border='1' borderColor='#000000' cellSpacing='0' cellPadding='0'><TR>")
                'Dim columnscount As Integer = tblExport.Columns.Count

                'For i As Integer = 0 To columnscount - 1
                '    Response.Write("<Td>")
                '    Response.Write("<B>")
                '    Select Case tblExport.Columns(i).ColumnName.ToString()
                '        Case "PatronCode"
                '            Response.Write("Số thẻ")
                '        Case "Name"
                '            Response.Write("Bạn đọc")
                '        Case "MainTitle"
                '            Response.Write("Nhan đề")
                '        Case "Email"
                '            Response.Write("Email")
                '        Case "Mobile"
                '            Response.Write("Số điện thoại")
                '        Case "CheckOutDate"
                '            Response.Write("Ngày mượn")
                '        Case "CheckInDate"
                '            Response.Write("Ngày trả")
                '        Case "CopyNumber"
                '            Response.Write("ĐKCB")
                '        Case "OverdueDate"
                '            Response.Write("Quá hạn (ngày)")
                '        Case Else
                '            Response.Write(tblExport.Columns(i).ColumnName.ToString())
                '    End Select

                '    Response.Write("</B>")
                '    Response.Write("</Td>")
                'Next

                'Response.Write("</TR>")
                'For Each Row As DataRow In tblExport.Rows
                '    Response.Write("<TR>")
                '    For i As Integer = 0 To columnscount - 1
                '        Response.Write("<Td>")
                '        Dim gType As System.Type = Row(i).GetType()
                '        If gType.ToString() = "System.DateTime" Then
                '            Response.Write(String.Format("{0:dd/MM/yyyy}", CType(Row(i).ToString(), Date)))
                '        Else
                '            Response.Write(Row(i).ToString())
                '        End If
                '        Response.Write("</Td>")
                '    Next
                '    Response.Write("</TR>")
                'Next
                'Response.Write("</Table>")
                'Response.Write("</font>")
                'Response.Flush()
                'Response.End()
            Else
            End If
        End Sub

        Private Function TableExport(ByVal tblData As DataTable) As DataTable
            Dim tblResult As New DataTable("tblResult")
            tblResult.Columns.Add("STT")
            tblResult.Columns.Add("PatronCode")
            tblResult.Columns.Add("Name")
            tblResult.Columns.Add("MainTitle")
            tblResult.Columns.Add("Email")
            tblResult.Columns.Add("Mobile")
            tblResult.Columns.Add("CheckOutDate")
            tblResult.Columns.Add("CheckInDate")
            tblResult.Columns.Add("CopyNumber")
            tblResult.Columns.Add("OverdueDate")

            For Each rows As DataRow In tblData.Rows
                Dim dtRow As DataRow = tblResult.NewRow()
                dtRow.Item("STT") = rows.Item("Index")
                dtRow.Item("PatronCode") = rows.Item("PatronCode")
                dtRow.Item("Name") = rows.Item("Name")
                dtRow.Item("MainTitle") = rows.Item("MainTitle")
                dtRow.Item("Email") = rows.Item("Email")
                dtRow.Item("Mobile") = rows.Item("Mobile")
                dtRow.Item("CheckOutDate") = rows.Item("CheckOutDate")
                dtRow.Item("CheckInDate") = rows.Item("CheckInDate")
                dtRow.Item("CopyNumber") = rows.Item("CopyNumber")
                dtRow.Item("OverdueDate") = rows.Item("OverdueDate")
                tblResult.Rows.Add(dtRow)
            Next

            Return tblResult
        End Function
        Protected Sub btnStatis_Click(sender As Object, e As EventArgs) Handles btnStatis.Click
            BindData("", CInt(ddlFaculty.SelectedItem.Value), CInt(ddlPatronGroup.SelectedItem.Value))
            dgrOverdue.Rebind()
        End Sub

    End Class
End Namespace