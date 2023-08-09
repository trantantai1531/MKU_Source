' Class: WViewFileXml
' Puspose: Display user index page 
' Creator: Tuanhv
' CreatedDate: 10/05/2005
' Modification History:

Imports eMicLibAdmin.BusinessRules.Admin
Imports System.IO

Namespace eMicLibAdmin.WebUI.Admin
    Partial Class WViewFileXml
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

        Dim strFoder As String
        Dim tblFilexml As DataTable
        Dim strFileName As String = ""
        Dim strFilePath As String = ""
        Dim fs As StreamWriter
        Dim tblTest As DataTable

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Session("UserID") = 1 And Not CheckPemission(238) Then
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
            strFoder = Server.MapPath("..") & "/Resources/LabelString"
            hidFilexml.Value = strFoder

            If Not Page.IsPostBack Then
                If Not strFoder Is Nothing AndAlso strFoder <> "" Then
                    Call SubGetFileAllXml(strFoder)
                End If
                lnkLanguageEditor.NavigateUrl = "WLanguageEditor.aspx?FormID=" & strFoder
            End If
        End Sub

        ' Method: GetXmlFile
        Public Function GetXmlFile(ByVal strFileNameXml As String) As DataTable
            ' Use function ConvertTable
            Dim blnReadyFile As Boolean
            blnReadyFile = False
            Dim strName As String = ""
            Dim dsResource As New DataSet
            Try
                dsResource.ReadXml(strFileNameXml)
                If dsResource.Tables.Count > 0 Then
                    Select Case clsSession.GlbLanguage
                        Case "tcvn", "vni", "unicode"
                            Session("ColLanguage") = "unicode"
                        Case Else
                            Session("ColLanguage") = clsSession.GlbLanguage
                    End Select
                    GetXmlFile = dsResource.Tables(0)
                    dsResource.Tables.Clear()
                    blnReadyFile = True
                End If
            Catch ex As Exception
            Finally
            End Try
        End Function

        ' Method: SubGetFileXml
        Private Sub SubGetFileAllXml(ByVal strFoder As String)
            Dim objDirInfor As DirectoryInfo
            Dim objFileInfor As FileInfo
            Dim strFoderName As String = ""
            Dim introw As Integer
            Dim tblItem As DataTable
            Dim tblRow As TableRow
            Dim tblCell1 As TableCell
            Dim tblCell2 As TableCell
            Dim intIndex As Integer = 0

            objDirInfor = New DirectoryInfo(strFoder)
            If objDirInfor.GetFiles("*.xml").Length > 0 Then
                tblRow = New TableRow
                tblRow.CssClass = "lbGridHeader"

                ' Content Link
                tblCell1 = New TableCell
                tblCell1.HorizontalAlign = HorizontalAlign.Left
                tblCell1.Text = ddlLabel.Items(0).Text
                tblCell1.Width = Unit.Percentage(10)

                tblRow.Controls.Add(tblCell1)

                ' Content file name
                tblCell2 = New TableCell
                tblCell2.HorizontalAlign = HorizontalAlign.Left
                tblCell2.Text = ddlLabel.Items(1).Text

                tblRow.Controls.Add(tblCell2)
                tblResult.Controls.Add(tblRow)
            End If

            For Each objFileInfor In objDirInfor.GetFiles("*.xml")
                tblRow = New TableRow
                ' Content Link
                tblCell1 = New TableCell
                tblCell1.HorizontalAlign = HorizontalAlign.Center
                tblCell1.CssClass = ""

                tblCell1.VerticalAlign = VerticalAlign.Top

                ' Content file name
                tblCell2 = New TableCell
                tblCell2.HorizontalAlign = HorizontalAlign.Left
                tblCell2.CssClass = ""

                strFileName = objFileInfor.Name
                strFilePath = objFileInfor.FullName
                hidFilexml.Value = Replace(strFilePath, "/", "$&")

                tblTest = GetXmlFile(strFilePath)

                If Not tblTest Is Nothing AndAlso tblTest.Rows.Count > 0 Then
                    Dim arrText As Object
                    ReDim arrText(tblTest.Columns.Count - 2)
                    Dim inti As Integer
                    For inti = 1 To tblTest.Columns.Count - 1
                        arrText(inti - 1) = tblTest.Columns(inti).ColumnName
                    Next
                    Dim tblTemp As DataTable
                    tblTemp = CreateTable(arrText, arrText)

                    Dim lnkLink As New HyperLink
                    lnkLink.NavigateUrl = "WInterfaceLangMan.aspx?FormID=" & Trim(strFilePath)
                    lnkLink.Text = "<img src='Images/tra_cuu_log.gif' border=0>"
                    lnkLink.CssClass = "lbLinkFunction"
                    lnkLink.ToolTip = ddlLabel.Items(3).Text.Trim
                    tblCell1.Controls.Add(lnkLink)
                    tblRow.Cells.Add(tblCell1)
                    tblCell2.Controls.Add(New LiteralControl(strFileName))
                    tblRow.Cells.Add(tblCell2)

                    If (intIndex Mod 2) = 1 Then
                        tblRow.CssClass = "lbGridCell"
                    Else
                        tblRow.CssClass = "lbGridAlterCell"
                    End If
                    tblResult.Rows.Add(tblRow)
                End If
                intIndex = intIndex + 1
            Next
        End Sub
    End Class
End Namespace