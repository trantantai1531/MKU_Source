Imports eMicLibAdmin.BusinessRules.Patron
Imports eMicLibAdmin.BusinessRules.Common
Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WSearchTableResult
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

        Private objBPT As New clsBPatron
        Private objBCDBS As New clsBCommonDBSystem
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            If Not Page.IsPostBack Then
                If Session("Pagesize") & "" <> "" Then
                    DgrResult.PageSize = Session("Pagesize")
                End If
                Call BindData()
            End If
            If Session("ResultTabDataSource") Is Nothing Then
                btnExport.Visible = False
            Else
                btnExport.Visible = True
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Initialize  objBPT  object
            objBPT.DBServer = Session("DBServer")
            objBPT.ConnectionString = Session("ConnectionString")
            objBPT.InterfaceLanguage = Session("InterfaceLanguage")
            objBPT.Initialize()
            ' Initialize  objBCDBS  object
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.Initialize()
        End Sub

        ' BindData method
        Private Sub BindData()
            Dim ArrID()
            Dim strIDs As String
            Dim inti As Integer
            Dim tblPatron As New DataTable
            ArrID = Session("PatronIDs")
            If IsArray(ArrID) Then
                For inti = 0 To UBound(ArrID)
                    strIDs = strIDs & CStr(ArrID(inti)) & ","
                Next
            End If
            If strIDs <> "" Then
                objBPT.PatronIDs = Left(strIDs, Len(strIDs) - 1)
            End If
            Dim TblCP As New DataTable
            If Session("ResultTabDataSource") Is Nothing Then
                tblPatron = objBPT.GetPatron
                For inti = 0 To tblPatron.Rows.Count - 1
                    If Not IsDBNull(tblPatron.Rows(inti).Item("Sex")) Then
                        If CStr(tblPatron.Rows(inti).Item("Sex")) = "1" Then
                            tblPatron.Rows(inti).Item("Sex") = ddlLabel.Items(3).Text
                        Else
                            tblPatron.Rows(inti).Item("Sex") = ddlLabel.Items(4).Text
                        End If
                    End If
                Next
                Session("ResultTabDataSource") = objBCDBS.GenTableSort(ArrID, tblPatron)
            End If
            Dim ArrShow
            Dim ArrHide
            Dim strHide As String = ""
            If Session("FieldShow") & "" <> "" Then
                ArrShow = Split(Session("FieldShow"), ",")
                Dim blnExit As Boolean
                Dim bytj As Byte
                For inti = 0 To 17
                    bytj = 0
                    blnExit = False
                    While (bytj <= UBound(ArrShow)) And (Not blnExit)
                        If CByte(ArrShow(bytj)) = inti Then
                            blnExit = True
                        Else
                            bytj = bytj + 1
                        End If
                    End While
                    If Not blnExit Then
                        strHide = strHide & CStr(inti) & ","
                    End If
                Next
                If strHide <> "" Then
                    strHide = Left(strHide, Len(strHide) - 1)
                    ArrHide = Split(strHide, ",")
                End If
                If IsArray(ArrHide) Then
                    For inti = UBound(ArrHide) To 0 Step -1
                        DgrResult.Columns.RemoveAt(ArrHide(inti))
                    Next
                    DgrResult.DataSource = Session("ResultTabDataSource")
                    DgrResult.DataBind()
                End If
            End If
        End Sub

        Private Sub DgrResult_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DgrResult.PageIndexChanged
            DgrResult.CurrentPageIndex = e.NewPageIndex
            Call BindData()
        End Sub

        ' Page_Unload method
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBPT Is Nothing Then
                objBPT.Dispose(True)
                objBPT = Nothing
            End If
            If Not objBCDBS Is Nothing Then
                objBCDBS.Dispose(True)
                objBCDBS = Nothing
            End If
        End Sub
        Private Sub ConvertTable(ByVal tblResult As DataTable, ByRef tblConvert As DataTable)
            If (Not IsNothing(tblResult)) AndAlso (tblResult.Rows.Count > 0) Then
                tblConvert.Clear()
                tblConvert.Columns.Add("STT")
                tblConvert.Columns.Add("Code")
                tblConvert.Columns.Add("FullName")
                tblConvert.Columns.Add("DOB")
                tblConvert.Columns.Add("ValidDate")
                tblConvert.Columns.Add("ExpiredDate")
                tblConvert.Columns.Add("Sex")
                tblConvert.Columns.Add("Ethnic")
                tblConvert.Columns.Add("College")
                tblConvert.Columns.Add("Faculty")
                tblConvert.Columns.Add("Grade")
                tblConvert.Columns.Add("Class")
                tblConvert.Columns.Add("Address")
                tblConvert.Columns.Add("Telephone")
                tblConvert.Columns.Add("Mobile")
                tblConvert.Columns.Add("Email")
                tblConvert.Columns.Add("Note")
                tblConvert.Columns.Add("Occupation")
                tblConvert.Columns.Add("Name")

                For Each rows As DataRow In tblResult.Rows
                    Dim dtRow As DataRow = tblConvert.NewRow()
                    Dim stt As String = rows.Item("STT") & ""
                    Dim strCode As String = rows.Item("Code") & ""
                    Dim strFullName As String = rows.Item("FullName") & ""
                    Dim strDOB As String = rows.Item("DOB") & ""
                    Dim strValidDate As String = rows.Item("ValidDate") & ""
                    Dim strExpiredDate As String = rows.Item("ExpiredDate") & ""
                    Dim strSex As String = rows.Item("Sex") & ""
                    Dim strEthnic As String = rows.Item("Ethnic") & ""
                    Dim strCollege As String = rows.Item("College") & ""
                    Dim strFaculty As String = rows.Item("Faculty") & ""
                    Dim strGrade As String = rows.Item("Grade") & ""
                    Dim strClass As String = rows.Item("Class") & ""
                    Dim strAddress As String = rows.Item("Address") & ""
                    Dim strTelephone As String = rows.Item("Telephone") & ""
                    Dim strMobile As String = rows.Item("Mobile") & ""
                    Dim strEmail As String = rows.Item("Email") & ""
                    Dim strNote As String = rows.Item("Note") & ""
                    Dim strOccupation As String = rows.Item("Occupation") & ""
                    Dim strName As String = rows.Item("Name") & ""

                    dtRow.Item("STT") = stt
                    dtRow.Item("Code") = strCode
                    dtRow.Item("FullName") = strFullName
                    dtRow.Item("DOB") = If(Not strDOB = String.Empty, String.Format("{0:dd/MM/yyyy}", strDOB).Substring(0, 10), "")
                    dtRow.Item("ValidDate") = If(Not strValidDate = String.Empty, String.Format("{0:dd/MM/yyyy}", strValidDate).Substring(0, 10), "")
                    dtRow.Item("ExpiredDate") = If(Not strExpiredDate = String.Empty, String.Format("{0:dd/MM/yyyy}", strExpiredDate).Substring(0, 10), "")
                    dtRow.Item("Sex") = strSex
                    dtRow.Item("Ethnic") = strEthnic
                    dtRow.Item("College") = strCollege
                    dtRow.Item("Faculty") = strFaculty
                    dtRow.Item("Grade") = strGrade
                    dtRow.Item("Class") = strClass
                    dtRow.Item("Address") = strAddress
                    dtRow.Item("Telephone") = strTelephone
                    dtRow.Item("Mobile") = strMobile
                    dtRow.Item("Email") = strEmail
                    dtRow.Item("Note") = strNote
                    dtRow.Item("Occupation") = strOccupation
                    dtRow.Item("Name") = strName

                    tblConvert.Rows.Add(dtRow)
                Next
            End If
        End Sub
        Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
            If Not Session("ResultTabDataSource") Is Nothing Then
                Dim tblData As DataTable = CType(Session("ResultTabDataSource"), DataTable)
                tblData.Columns.Add("STT")
                Dim intSTT As Integer = 1
                For Each row As DataRow In tblData.Rows
                    row("STT") = intSTT
                    intSTT = intSTT + 1
                Next
                Dim tblConvert As New DataTable("tblConvert")
                ConvertTable(tblData, tblConvert)
                tblConvert.Rows.Add(ddlLabelHeaderTable.Items(0).Text, ddlLabelHeaderTable.Items(1).Text, ddlLabelHeaderTable.Items(2).Text,
                                        ddlLabelHeaderTable.Items(3).Text, ddlLabelHeaderTable.Items(4).Text, ddlLabelHeaderTable.Items(5).Text,
                                        ddlLabelHeaderTable.Items(6).Text, ddlLabelHeaderTable.Items(7).Text, ddlLabelHeaderTable.Items(8).Text,
                                        ddlLabelHeaderTable.Items(9).Text, ddlLabelHeaderTable.Items(10).Text, ddlLabelHeaderTable.Items(11).Text,
                                        ddlLabelHeaderTable.Items(12).Text, ddlLabelHeaderTable.Items(13).Text, ddlLabelHeaderTable.Items(14).Text,
                                        ddlLabelHeaderTable.Items(15).Text, ddlLabelHeaderTable.Items(16).Text, ddlLabelHeaderTable.Items(17).Text, ddlLabelHeaderTable.Items(18).Text)

                Dim strHTMLContent As New StringBuilder()
                strHTMLContent.Append("<html xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:w='urn:schemas-microsoft-com:office:excel' xmlns='www.w3.org/TR/REC-html40'>")
                strHTMLContent.Append("<head>")
                strHTMLContent.Append("</head>")
                strHTMLContent.Append("<body lang=EN-US style='tab-interval:.5in'>")
                strHTMLContent.Append("<p>" & clsBExportHelper.GenDataTableToString(tblConvert) & "</p>")
                strHTMLContent.Append("</div></body></html>")
                clsExport.StringBuilderToExcel(strHTMLContent)
            End If
        End Sub

    End Class
End Namespace