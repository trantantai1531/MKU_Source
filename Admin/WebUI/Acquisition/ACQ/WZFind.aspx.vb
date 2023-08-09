Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Acquisition
    Public Class WZFind
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblNext As System.Web.UI.WebControls.Label
        Protected WithEvents txtNext As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnNext As System.Web.UI.WebControls.Button
        Protected WithEvents tblResult As System.Web.UI.WebControls.Table
        Protected WithEvents NotFound As System.Web.UI.WebControls.Label
        Protected WithEvents btnClose As System.Web.UI.WebControls.Button
        Protected WithEvents lblJS As System.Web.UI.WebControls.Label
        Protected WithEvents ddlLabel As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtHidTitle As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents txtHidAuthor As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents txtHidISBN As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents txtHidISSN As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents txtHidPublisher As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents txtHidPublishYear As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents txtHidPublishOrder As System.Web.UI.HtmlControls.HtmlInputHidden


        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBCSP As New clsBCommonStringProc
        Private objBZ3950 As New clsBZ3950

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            If Not Page.IsPostBack Then
                Session("VietUSMARC") = False
                Call ProcessZQuery()
            End If
            Call BindJS()
        End Sub

        ' Method: Initialize
        ' This method used to init all objects
        Private Sub Initialize()
            objBZ3950.InterfaceLanguage = Session("InterfaceLanguage")
            objBZ3950.DBServer = Session("DBServer")
            objBZ3950.ConnectionString = Session("ConnectionString")
            Call objBZ3950.Initialize()

            objBCSP.InterfaceLanguage = Session("InterfaceLanguage")
            objBCSP.DBServer = Session("DBServer")
            objBCSP.ConnectionString = Session("ConnectionString")
            Call objBCSP.Initialize()
        End Sub

        ' Method: BindJS
        Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/ACQ/WZFind.js'></script>")

            btnClose.Attributes.Add("Onclick", "self.close()")
        End Sub

        ' ProcessZQuery method
        Public Sub ProcessZQuery()
            Dim intStart As Integer
            Dim intImportID As Integer

            If Trim(txtNext.Text) = "" Or Not IsNumeric(txtNext.Text) Then
                intStart = 1
            Else
                intStart = CInt(Trim(txtNext.Text))
            End If

            If Not Trim(Request("ID")) = "" Then
                intImportID = CInt(Trim(Request("ID")))
            End If
            objBZ3950.zServer = Session("zServer")
            objBZ3950.zPort = Session("zPort")
            objBZ3950.zDatabase = Session("zDatabase")
            objBZ3950.FieldName1 = Session("ddlFieldName1")
            objBZ3950.FieldValue1 = Session("txtFieldValue1")
            objBZ3950.FieldName2 = Session("ddlFieldName2")
            objBZ3950.FieldValue2 = Session("txtFieldValue2")
            objBZ3950.FieldName3 = Session("ddlFieldName3")
            objBZ3950.FieldValue3 = Session("txtFieldValue3")
            objBZ3950.Operator2 = Session("ddlOperator2")
            objBZ3950.Operator3 = Session("ddlOperator3")

            objBZ3950.VietUSMARC = Session("VietUSMARC")
            If intImportID > 0 Then
                objBZ3950.Start = intImportID
                objBZ3950.Howmany = 1
            Else
                objBZ3950.Start = intStart
                objBZ3950.Howmany = 10
            End If

            txtNext.Text = intStart + objBZ3950.Howmany

            ' Process ZQuery
            Call objBZ3950.ProccessQuery()

            ' Import selected record or show search result
            If intImportID > 0 Then ' Import selected record
                Call ImportOneRec()
            Else ' Show search result
                Call ShowResult()
            End If
        End Sub

        ' Import selected record
        Public Sub ImportOneRec()
            ' Declare variables
            Dim objResult As Object
            Dim objTagName As Object
            Dim objTagValue As Object
            Dim objSubRecs As Object
            Dim intIndex As Integer
            ' Process
            objResult = objBZ3950.Record
            Call objBZ3950.ParseTaggedRecord(objResult(UBound(objResult), 0), objTagName, objTagValue, "$")

            ' Main title
            intIndex = objBZ3950.FindIndex(objTagName, "245")
            If intIndex >= 0 Then
                Call objBCSP.ParseField("$a", objTagValue(intIndex), "nc ", objSubRecs)
                If Not objSubRecs(0) = "" Then
                    txtHidTitle.Value = Trim(objSubRecs(0) & "")
                End If
            End If

            ' Author
            intIndex = objBZ3950.FindIndex(objTagName, "100")
            If intIndex < 0 Then
                intIndex = objBZ3950.FindIndex(objTagName, "110")
            End If
            If intIndex >= 0 Then
                Call objBCSP.ParseField("$a", objTagValue(intIndex), "nc ", objSubRecs)
                If Not objSubRecs(0) = "" Then
                    txtHidAuthor.Value = Trim(objSubRecs(0) & "")
                End If
            End If

            ' Pulish information
            intIndex = objBZ3950.FindIndex(objTagName, "260")
            If intIndex >= 0 Then
                Call objBCSP.ParseField("$b,$c", objTagValue(intIndex), "nc ", objSubRecs)
                If Not objSubRecs(0) = "" Then
                    txtHidPublisher.Value = Trim(objSubRecs(0) & "")
                End If
                If Not objSubRecs(1) = "" Then
                    txtHidPublishYear.Value = Trim(objSubRecs(1) & "")
                End If
            End If

            ' ISSN
            intIndex = objBZ3950.FindIndex(objTagName, "022")
            If intIndex >= 0 Then
                Call objBCSP.ParseField("$a", objTagValue(intIndex), "nc;", objSubRecs)
                If Not objSubRecs(0) = "" Then
                    txtHidISSN.Value = Trim(objSubRecs(0) & "")
                End If
            End If

            ' ISBN
            intIndex = objBZ3950.FindIndex(objTagName, "020")
            If intIndex >= 0 Then
                Call objBCSP.ParseField("$a", objTagValue(intIndex), "nc;", objSubRecs)
                If Not objSubRecs(0) = "" Then
                    txtHidISBN.Value = Trim(objSubRecs(0) & "")
                End If
            End If

            ' Publish edition 
            intIndex = objBZ3950.FindIndex(objTagName, "250")
            If intIndex >= 0 Then
                Call objBCSP.ParseField("$a", objTagValue(intIndex), "nc ", objSubRecs)
                If Not objSubRecs(0) = "" Then
                    txtHidPublishOrder.Value = Trim(objSubRecs(0) & "")
                End If
            End If
            ' Execute
            lblJS.Text = "<script language = 'javascript'>ImportToCataForm();</script>"
        End Sub

        ' ShowResult method
        Public Sub ShowResult()
            ' Declare variables
            Dim objResult As Object
            Dim objTagName As Object
            Dim objTagValue As Object
            Dim intCounter As Integer
            ' Process
            objResult = objBZ3950.Record
            If Not objBZ3950.ZError = "" Then
                ' Error
                NotFound.Visible = True
                NotFound.Text = objBZ3950.ZError
            Else
                If objBZ3950.Hits = 0 Then
                    ' No data found
                    NotFound.Visible = True
                Else
                    ReDim objTagName(0)
                    ReDim objTagValue(0)
                    Call ShowHeader()
                    For intCounter = LBound(objResult) To UBound(objResult)
                        Select Case Trim(Session("Display") & "")
                            Case "ISBD"
                                Call objBZ3950.ParseTaggedRecord(objResult(intCounter, 0), objTagName, objTagValue, "$")
                                Call ShowTableISBD(intCounter + objBZ3950.Start, ISBDDisplay(objTagName, objTagValue))
                            Case "MARC"
                                Call ShowTableMARC(intCounter + objBZ3950.Start, objResult(intCounter, 0))
                            Case "SIMPLE"
                                Call objBZ3950.ParseTaggedRecord(objResult(intCounter, 0), objTagName, objTagValue, "$")
                                Call ShowTableSimple(intCounter + objBZ3950.Start, objTagName, objTagValue)
                        End Select
                    Next
                End If
            End If
        End Sub

        ' ShowTableSimple method
        Public Function ShowTableMARC(ByVal intCurRec As Integer, ByVal strRec As String)
            Dim tblRow As TableRow
            Dim tblCell As TableCell
            Dim lblLabel As Label
            Dim img As ImageButton
            Dim intIndex As Integer
            strRec = Replace(strRec, Chr(10), "<BR>")
            strRec = Replace(strRec, " ", "&nbsp;")

            tblRow = New TableRow
            tblRow.VerticalAlign = VerticalAlign.Top

            If intCurRec Mod 2 = 0 Then
                tblRow.CssClass = "lbGridCell"
            Else
                tblRow.CssClass = "lbGridAlterCell"
            End If
            tblCell = New TableCell
            tblCell.Width = Unit.Percentage(5)
            tblCell.HorizontalAlign = HorizontalAlign.Right
            lblLabel = New Label
            lblLabel.CssClass = "lbLabel"
            lblLabel.Text = CStr(intCurRec)
            tblCell.Controls.Add(lblLabel)
            tblRow.Controls.Add(tblCell)

            tblCell = New TableCell
            tblCell.Width = Unit.Percentage(5)
            tblCell.HorizontalAlign = HorizontalAlign.Center
            lblLabel = New Label
            lblLabel.CssClass = "lbLabel"
            lblLabel.Text = "<a href='WZFind.aspx?ID=" & CStr(intCurRec) & "'><IMG SRC='../../images/select.jpg' border='0'></a>"
            tblCell.Controls.Add(lblLabel)
            tblRow.Controls.Add(tblCell)

            tblCell = New TableCell
            lblLabel = New Label
            lblLabel.CssClass = "lbLabel"
            lblLabel.Text = strRec
            tblCell.Controls.Add(lblLabel)
            tblRow.Controls.Add(tblCell)

            tblResult.Rows.Add(tblRow)
        End Function

        ' ShowTableSimple method
        Public Sub ShowTableSimple(ByVal intCurRec As Integer, ByVal Array1 As Object, ByVal Array2 As Object)
            Dim tblRow As TableRow
            Dim tblCell As TableCell
            Dim lblLabel As Label
            Dim img As ImageButton
            Dim intIndex As Integer
            Dim strVal As String = ""


            tblRow = New TableRow
            tblRow.VerticalAlign = VerticalAlign.Top

            If intCurRec Mod 2 = 0 Then
                tblRow.CssClass = "lbGridCell"
            Else
                tblRow.CssClass = "lbGridAlterCell"
            End If
            tblCell = New TableCell
            tblCell.Width = Unit.Percentage(5)
            tblCell.HorizontalAlign = HorizontalAlign.Right
            lblLabel = New Label
            lblLabel.CssClass = "lbLabel"
            lblLabel.Text = CStr(intCurRec)
            tblCell.Controls.Add(lblLabel)
            tblRow.Controls.Add(tblCell)

            tblCell = New TableCell
            tblCell.Width = Unit.Percentage(5)
            tblCell.HorizontalAlign = HorizontalAlign.Center
            lblLabel = New Label
            lblLabel.CssClass = "lbLabel"
            lblLabel.Text = "<a href='WZFind.aspx?ID=" & CStr(intCurRec) & "'><IMG SRC='../../images/select.jpg' border='0'></a>"
            tblCell.Controls.Add(lblLabel)
            tblRow.Controls.Add(tblCell)

            intIndex = objBZ3950.FindIndex(Array1, "100")
            If intIndex >= 0 Then
                strVal = "<B>" & ddlLabel.Items(2).Text & "</B>: " & objBCSP.TrimSubFieldCodes(Array2(intIndex)) & "<BR>"
            End If
            intIndex = objBZ3950.FindIndex(Array1, "245")
            If intIndex >= 0 Then
                strVal = strVal & "<B>" & ddlLabel.Items(3).Text & "</B>: " & objBCSP.TrimSubFieldCodes(Array2(intIndex)) & "<BR>"
            End If
            intIndex = objBZ3950.FindIndex(Array1, "260")
            If intIndex >= 0 Then
                strVal = strVal & "<B>" & ddlLabel.Items(4).Text & "</B>: " & objBCSP.TrimSubFieldCodes(Array2(intIndex)) & "<BR>"
            End If
            intIndex = objBZ3950.FindIndex(Array1, "300")
            If intIndex >= 0 Then
                strVal = strVal & "<B>" & ddlLabel.Items(5).Text & "</B>: " & objBCSP.TrimSubFieldCodes(Array2(intIndex)) & "<BR>"
            End If

            tblCell = New TableCell
            lblLabel = New Label
            lblLabel.CssClass = "lbLabel"
            lblLabel.Text = strVal
            tblCell.Controls.Add(lblLabel)
            tblRow.Controls.Add(tblCell)

            tblResult.Rows.Add(tblRow)
        End Sub

        ' ISBDDisplay method
        Public Function ISBDDisplay(ByVal Array1, ByVal Array2) As String
            Dim strResult As String
            Dim intIndex As Integer
            intIndex = objBZ3950.FindIndex(Array1, "100")
            If intIndex >= 0 Then
                strResult = strResult & "<B>" & objBCSP.TrimSubFieldCodes(Array2(intIndex)) & ". </B>"
            End If
            intIndex = objBZ3950.FindIndex(Array1, "245")
            If intIndex >= 0 Then
                strResult = strResult & objBCSP.TrimSubFieldCodes(Array2(intIndex))
            End If
            intIndex = objBZ3950.FindIndex(Array1, "260")
            If intIndex >= 0 Then
                strResult = strResult & ". - " & objBCSP.TrimSubFieldCodes(Array2(intIndex))
            End If
            intIndex = objBZ3950.FindIndex(Array1, "300")
            If intIndex >= 0 Then
                strResult = strResult & ". - " & objBCSP.TrimSubFieldCodes(Array2(intIndex))
            End If
            Return strResult
        End Function

        ' ShowHeader method
        Private Sub ShowHeader()
            Dim tblRow As TableRow
            Dim tblCell As TableCell
            ' remove all row in Table
            tblResult.Controls.Clear()

            If objBZ3950.Hits - objBZ3950.Howmany > 0 Then
                'Show Pager of Table
                lblNext.Visible = True
                txtNext.Visible = True
                btnNext.Visible = True
            End If

            tblResult.GridLines = GridLines.Both
            tblResult.CellSpacing = 0
            tblResult.CellPadding = 2
            tblResult.BorderWidth = Unit.Pixel(1)

            ' show header og table
            tblRow = New TableRow
            tblRow.HorizontalAlign = HorizontalAlign.Center
            tblRow.CssClass = "lbGridHeader"
            tblCell = New TableCell
            tblCell.ColumnSpan = 3
            tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(3).Text & "-&nbsp;&nbsp;" & ddlLabel.Items(0).Text & " : " & objBZ3950.Hits & "(" & ddlLabel.Items(1).Text & ")"))
            tblRow.Cells.Add(tblCell)

            tblResult.Rows.Add(tblRow)
        End Sub

        Private Sub ShowTableISBD(ByVal strCell1 As String, ByVal strCell2 As String)
            Dim tblRow As TableRow
            Dim tblCell As TableCell
            Dim lblLabel As Label
            Dim img As ImageButton
            tblRow = New TableRow
            tblRow.VerticalAlign = VerticalAlign.Top

            If CLng(strCell1) Mod 2 = 0 Then
                tblRow.CssClass = "lbGridCell"
            Else
                tblRow.CssClass = "lbGridAlterCell"
            End If
            tblCell = New TableCell
            tblCell.Width = Unit.Percentage(5)
            tblCell.HorizontalAlign = HorizontalAlign.Right
            lblLabel = New Label
            lblLabel.CssClass = "lbLabel"
            lblLabel.Text = strCell1
            tblCell.Controls.Add(lblLabel)
            tblRow.Controls.Add(tblCell)

            tblCell = New TableCell
            tblCell.Width = Unit.Percentage(5)
            tblCell.HorizontalAlign = HorizontalAlign.Center
            lblLabel = New Label
            lblLabel.CssClass = "lbLabel"
            lblLabel.Text = "<a href='WZFind.aspx?ID=" & strCell1 & "'><IMG SRC='../../images/select.jpg' border='0'></a>"
            tblCell.Controls.Add(lblLabel)
            tblRow.Controls.Add(tblCell)

            tblCell = New TableCell
            lblLabel = New Label
            lblLabel.CssClass = "lbLabel"
            lblLabel.Text = strCell2
            tblCell.Controls.Add(lblLabel)
            tblRow.Controls.Add(tblCell)


            tblResult.Rows.Add(tblRow)
        End Sub

        Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
            Call ProcessZQuery()
        End Sub
        Private Sub txtNext_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNext.TextChanged
            Call ProcessZQuery()
        End Sub

        ' Page_Unload Method
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Release all object
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBZ3950 Is Nothing Then
                    objBZ3950.Dispose(True)
                    objBZ3950 = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace