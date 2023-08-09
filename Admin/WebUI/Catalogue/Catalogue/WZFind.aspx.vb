' WZFind class
' Purpose: search data by z3950
' Creator: Oanhtn
' CreatedDate: 12/08/2004
' Modification history:
'   + 23/02/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WZFind
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblLabel1 As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBCSP As New clsBCommonStringProc
        Private objBZ3950 As New clsBZ3950
        Private objBForm As New clsBForm
        Private ProccessedQuery As Boolean
        Private intPage As Integer = 9

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Me.SetResourceForControls()
            Call Initialize()
            Call BindJavascript()
            Call BindData()
            If Not Page.IsPostBack Then
                Call ProcessZQuery(1)
                Call ShowResult(1)
            End If
            If Page.IsPostBack Then
                Select Case hidAction.Value
                    Case 0, 1 'txtNext change or btnNext click
                        ViewNextRecord()
                    Case 2 'ddlDisplay selectedindex change
                        Session("Display") = ddlDisplay.SelectedValue
                        Me.ShowResult(hidPosRec.Value)
                End Select
            End If
        End Sub

        ' Initialize method
        ' Purpose: Init all objects
        Private Sub Initialize()
            ' Init objBForm object 
            objBForm.InterfaceLanguage = Session("InterfaceLanguage")
            objBForm.DBServer = Session("DBServer")
            objBForm.ConnectionString = Session("ConnectionString")
            Call objBForm.Initialize()

            ' Init objBCSP object
            objBCSP.InterfaceLanguage = Session("InterfaceLanguage")
            objBCSP.DBServer = Session("DBServer")
            objBCSP.ConnectionString = Session("ConnectionString")
            Call objBCSP.Initialize()

            ' Init objBZ3950 object
            objBZ3950.InterfaceLanguage = Session("InterfaceLanguage")
            objBZ3950.DBServer = Session("DBServer")
            objBZ3950.ConnectionString = Session("ConnectionString")
            Call objBZ3950.Initialize()
        End Sub

        ' BindData method
        ' Purpose: create Form dropdownlist
        Public Sub BindData()
            Dim tblTemp As DataTable

            If Not Session("Hits") Is Nothing Then
                lblSumrec.Text = Session("Hits")
            End If
            ' Get list of forms
            tblTemp = objBForm.GetForms

            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    ddlForm.DataSource = tblTemp
                    ddlForm.DataTextField = "Name"
                    ddlForm.DataValueField = "ID"
                    ddlForm.DataBind()
                End If
            End If

            If Not Page.IsPostBack Then
                If UCase(CStr(Request("chkVietUSMARC") & "")) = "ON" Then
                    Session("VietUSMARC") = True
                Else
                    Session("VietUSMARC") = False
                End If
                If Not Request("txtZServer") = "" Then
                    Session("zServer") = Request("txtZServer")
                End If
                If Not Request("txtzPort") = "" Then
                    Session("zPort") = Request("txtzPort")
                End If
                If Not Request("txtzDatabase") = "" Then
                    Session("zDatabase") = Request("txtzDatabase")
                End If
                If Not Request("ddlFieldName1") = "" Then
                    Session("FieldName1") = Request("ddlFieldName1")
                End If
                If Not Request("ddlFieldName2") = "" Then
                    Session("FieldName2") = Request("ddlFieldName2")
                End If
                If Not Request("ddlFieldName3") = "" Then
                    Session("FieldName3") = Request("ddlFieldName3")
                End If
                If Not Request("txtFieldValue1") = "" Then
                    Session("FieldValue1") = Request("txtFieldValue1")
                End If
                If Not Request("txtFieldValue2") = "" Then
                    Session("FieldValue2") = Request("txtFieldValue2")
                End If
                If Not Request("txtFieldValue3") = "" Then
                    Session("FieldValue3") = Request("txtFieldValue3")
                End If
                If Not Request("ddlOperatorI") = "" Then
                    Session("Operator2") = Request("ddlOperatorI")
                End If
                If Not Request("ddlOperatorII") = "" Then
                    Session("Operator3") = Request("ddlOperatorII")
                End If
                If Request("optChoice") = "optNotImport" Then
                    Session("Choice") = 0
                Else
                    Session("Choice") = 1
                End If
                Select Case LCase(Request("optDisplay"))
                    Case "optmarc"
                        Session("Display") = 1
                    Case "optisbn"
                        Session("Display") = 0
                    Case "optsimple"
                        Session("Display") = 2
                End Select
            End If

            If Session("Overlay") = 1 Then
                lblForm.Visible = False
                ddlForm.Visible = False
                btnImport.Visible = False
            End If
        End Sub
        Private Sub ViewNextRecord()
            Dim intNext As Integer = CInt(txtStart.Text) '+ intPage
            If intNext < UBound(Session("objBZ3950Record")) Then
                Me.ShowResult(intNext)
            End If
            'If (intNext > Session("RecZ3950Start") + 40) Or (intNext < Session("RecZ3950Start")) Then
            '    Call ProcessZQuery(CInt(txtStart.Text))
            '    ShowResult(1)
            'Else
            '    Me.ShowResult(CInt(txtStart.Text) - Session("RecZ3950Start") + 1)
            'End If
        End Sub
        ' BindJavascript method
        ' Include all neccessary javascript function
        Public Sub BindJavascript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WZFindJs", "<script language = 'javascript' src = '../Js/Catalogue/WZFind.js'></script>")
            btnImport.Attributes.Add("OnClick", "document.forms[0].action='WZImport.aspx'; document.forms[0].submit(); return false;")
            btnBack.Attributes.Add("OnClick", "self.history.go(-1);return false;")
            btnView.Attributes.Add("onClick", "return ViewRecord(1,'" & ddlLabel.Items(9).Text & "','" & ddlLabel.Items(9).Text & "','" & ddlLabel.Items(9).Text & "');")
            txtStart.Attributes.Add("OnChange", "ViewRecord(0,'" & ddlLabel.Items(9).Text & "','" & ddlLabel.Items(9).Text & "','" & ddlLabel.Items(9).Text & "');")
            ddlDisplay.Attributes.Add("OnChange", "return ViewRecord(2,'" & ddlLabel.Items(9).Text & "','" & ddlLabel.Items(9).Text & "','" & ddlLabel.Items(9).Text & "');")
        End Sub

        ' ProcessZQuery method
        Public Sub ProcessZQuery(ByVal intStart As Integer)
            Session("Hits") = Nothing

            'process query
            ShowWaitingOnPage(ddlLabel.Items(10).Text, "../..")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim intImportID As Integer
            Dim blnToCat As Boolean = False
            If Not Trim(Request.QueryString("tocat")) = "" Then
                blnToCat = True
            End If
            objBZ3950.zServer = Session("zServer")
            objBZ3950.zPort = Session("zPort")
            objBZ3950.zDatabase = Session("zDatabase")
            objBZ3950.FieldName1 = Session("FieldName1")
            objBZ3950.FieldValue1 = Session("FieldValue1")
            objBZ3950.FieldName2 = Session("FieldName2")
            objBZ3950.FieldValue2 = Session("FieldValue2")
            objBZ3950.FieldName3 = Session("FieldName3")
            objBZ3950.FieldValue3 = Session("FieldValue3")
            objBZ3950.Operator2 = Session("Operator2")
            objBZ3950.Operator3 = Session("Operator3")
            objBZ3950.VietUSMARC = Session("VietUSMARC")
            objBZ3950.Start = intStart
            objBZ3950.Howmany = 50 'Select 50 records/transaction
            ' Show search result
            Call objBZ3950.ProccessQuery()
            ProccessedQuery = False
            hidCountRec.Value = 0
            If objBZ3950.ErrorMsg = "" Then
                hidCountRec.Value = objBZ3950.Hits
                lblSumrec.Text = CStr(objBZ3950.Hits)
                Session("Hits") = CStr(objBZ3950.Hits)
                ProccessedQuery = True
                Session("objBZ3950Record") = objBZ3950.Record
                Session("RecZ3950Start") = intStart
                txtStart.Text = intStart + intPage
            Else
                Session("objBZ3950Record") = Nothing
                NotFound.Text = objBZ3950.ZError
            End If
            'hidden progess bar
            ShowWaitingOnPage("", "", True)
        End Sub

        ' ShowResult method 
        ' Purpose: show search result
        Public Sub ShowResult(ByVal intStart As Integer)
            ' Declare variables
            Dim objTagName() As String
            Dim objTagValue() As String
            Dim intCounter As Integer
            Dim strQrytocat As String = ""
            Dim objResult() As String = Session("objBZ3950Record")
            If Not Trim(Request.QueryString("tocat") & "") = "" Then
                strQrytocat = "&tocat=1"
            End If
            If intStart <= 0 Then intStart = 1
            If objResult Is Nothing Or IIf(hidCountRec.Value = "", 0, hidCountRec.Value) = 0 Then
                NotFound.Visible = True
            Else
                ReDim objTagName(0)
                ReDim objTagValue(0)
                ddlDisplay.Visible = True
                lblDisplay.Visible = True
                Dim intEnd As Integer = 0
                intEnd = intStart + intPage
                If intEnd >= hidCountRec.Value Then
                    intEnd = hidCountRec.Value + 1
                End If
                txtStart.Text = intEnd + 1
                'If txtStart.Text < hidCountRec.Value - 10 Then
                '    txtStart.Text = intEnd + Session("RecZ3950Start")
                'End If
                ' check for get Session("objBZ3950Record") < 50 result
                'If objResult.length < 100 Then
                '    If 2 * intEnd > objResult.length Then
                '        intEnd = objResult.length / 2
                '        txtStart.Text = intEnd + Session("RecZ3950Start") - 1
                '    End If
                'End If
                If intEnd > hidCountRec.Value Then intEnd = hidCountRec.Value
                hidPosRec.Value = intStart
                intStart = intStart - 1
                ' Show result
                Dim tblRow As TableRow
                Dim tblCell As TableCell
                Dim chkTemp As CheckBox
                Dim lblTemp As Label
                Dim imgTemp As System.Web.UI.WebControls.Image
                Dim intPOC ' position of checkbox

                'Show header of this table
                tblRow = New TableRow
                tblRow.CssClass = "lbGridHeader"

                'STT
                tblCell = New TableCell
                tblCell.Width = Unit.Percentage(7)
                tblCell.HorizontalAlign = HorizontalAlign.Center
                lblTemp = New Label
                lblTemp.Text = ddlLabel.Items(11).Text
                tblCell.Controls.Add(lblTemp)
                tblRow.Cells.Add(tblCell)

                'Chon
                tblCell = New TableCell
                tblCell.Width = Unit.Percentage(7)
                tblCell.HorizontalAlign = HorizontalAlign.Center
                lblTemp = New Label
                lblTemp.Text = ddlLabel.Items(7).Text
                tblCell.Controls.Add(lblTemp)
                tblRow.Cells.Add(tblCell)

                'Danh sach bieu ghi tim duoc
                tblCell = New TableCell
                tblCell.HorizontalAlign = HorizontalAlign.Center
                lblTemp = New Label
                lblTemp.Text = ddlLabel.Items(8).Text
                tblCell.Controls.Add(lblTemp)
                tblRow.Cells.Add(tblCell)
                tblResult.Rows.Add(tblRow)

                For intCounter = intStart To intEnd - 1 'Display 10 records begin intStart for each view
                    tblRow = New TableRow
                    tblRow.CssClass = "lbGridHeader"

                    'Add order number
                    tblCell = New TableCell
                    tblCell.HorizontalAlign = HorizontalAlign.Center
                    lblTemp = New Label
                    lblTemp.CssClass = "lbLabel"
                    lblTemp.Text = CInt(Session("RecZ3950Start")) + intCounter
                    tblCell.Controls.Add(lblTemp)
                    tblRow.Cells.Add(tblCell)

                    'Add check button
                    tblCell = New TableCell
                    tblCell.HorizontalAlign = HorizontalAlign.Center
                    If Session("Overlay") = 1 Then
                        imgTemp = New System.Web.UI.WebControls.Image
                        imgTemp.ImageUrl = "../../Images/select.jpg"
                        imgTemp.Attributes.Add("OnClick", "opener.document.forms[0].tag.checked=true; opener.document.forms[0].txtContent.value='" & Replace(Replace(objResult(intCounter), Chr(10), "\n"), "'", "\'") & "';self.close();")
                        tblCell.Controls.Add(imgTemp)
                    Else
                        chkTemp = New CheckBox
                        chkTemp.CssClass = "lbCheckbox"
                        intPOC = CInt(Session("RecZ3950Start")) + intCounter
                        chkTemp.ID = "chk" & intCounter
                        'chkTemp.Attributes.Add("onClick", "chkEvent(" & intPOC & ");")
                        chkTemp.Attributes.Add("onClick", "chkEvent(" & intCounter & ");")
                        tblCell.Controls.Add(chkTemp)
                    End If
                    tblRow.Cells.Add(tblCell)

                    Dim strValue = ""
                    Select Case Session("Display")
                        Case 0 ' ISBD
                            Call objBZ3950.FillValueFieldsToArray(objResult(intCounter), objTagName, objTagValue, "$")
                            strValue = getISBD(objTagName, objTagValue)
                            'Call objBZ3950.ParseTaggedRecord(objResult(intCounter, 0), objTagName, objTagValue, "$")
                            'strValue = GenISBD(objTagName, objTagValue)
                        Case 1 ' MARC
                            'strValue = Replace(objResult(intCounter, 0), Chr(10), "<BR>")
                            Call objBZ3950.FillValueFieldsToArray(objResult(intCounter), objTagName, objTagValue, "$", True)
                            strValue = getMARC(objTagName, objTagValue)
                        Case 2 ' Simple
                            'Call objBZ3950.ParseTaggedRecord(objResult(intCounter, 0), objTagName, objTagValue, "$")
                            'strValue = GenSimple(objTagName, objTagValue)
                            Call objBZ3950.FillValueFieldsToArray(objResult(intCounter), objTagName, objTagValue, "$")
                            strValue = getSimple(objTagName, objTagValue)
                    End Select

                    tblCell = New TableCell
                    tblCell.HorizontalAlign = HorizontalAlign.Left
                    lblTemp = New Label
                    lblTemp.Text = Trim(strValue)
                    tblCell.Controls.Add(lblTemp)
                    tblRow.Cells.Add(tblCell)
                    If intCounter Mod 2 = 1 Then
                        tblRow.CssClass = "lbGridCell"
                    Else
                        tblRow.CssClass = "lbGridAlterCell"
                    End If
                    tblResult.Rows.Add(tblRow)
                Next
            End If
        End Sub

        ' getISBD method
        Public Function getISBD(ByVal Array1() As String, ByVal Array2() As String) As String
            Dim strResult As String = ""
            Dim strTemp As String = ""
            For i As Integer = 0 To UBound(Array1)
                If Not Array1(i) Is Nothing AndAlso Not Array2(i) Is Nothing Then
                    Select Case Array1(i)
                        Case "100", "110", "111"
                            strTemp = objBZ3950.ConvertUTF8toUni(Array2(i))
                            strResult &= "<B>" & objBCSP.TrimSubFieldCodes(strTemp) & ". </B>"
                        Case "245"
                            strTemp = objBZ3950.ConvertUTF8toUni(Array2(i))
                            strResult &= objBCSP.TrimSubFieldCodes(strTemp)
                        Case "260"
                            strTemp = objBZ3950.ConvertUTF8toUni(Array2(i))
                            strResult &= ". - " & objBCSP.TrimSubFieldCodes(strTemp)
                        Case "300"
                            strTemp = objBZ3950.ConvertUTF8toUni(Array2(i))
                            strResult &= ". - " & objBCSP.TrimSubFieldCodes(strTemp)
                    End Select
                End If
            Next
            Return strResult
        End Function

        Private Function getMARC(ByVal Array1() As String, ByVal Array2() As String) As String
            Dim strResult As String = ""
            Dim strTemp As String = ""
            For i As Integer = 0 To UBound(Array1)
                If Not Array1(i) Is Nothing AndAlso Not Array2(i) Is Nothing Then
                    strTemp = Array1(i) & Space(1) & objBZ3950.ConvertUTF8toUni(Array2(i)) & "<BR />"
                    strResult &= strTemp
                End If
            Next
            Return strResult
        End Function

        ' ISBDDisplay method
        Public Function getSimple(ByVal Array1() As String, ByVal Array2() As String) As String
            Dim strResult As String = ""
            Dim strTemp As String = ""
            For i As Integer = 0 To UBound(Array1)
                If Not Array1(i) Is Nothing AndAlso Not Array2(i) Is Nothing Then
                    Select Case Array1(i)
                        Case "100", "110", "111"
                            strTemp = objBZ3950.ConvertUTF8toUni(Array2(i))
                            strResult &= "<B>" & ddlLabel.Items(2).Text & "</B>: " & objBCSP.TrimSubFieldCodes(strTemp) & "<BR>"
                        Case "245"
                            strTemp = objBZ3950.ConvertUTF8toUni(Array2(i))
                            strResult &= "<B>" & ddlLabel.Items(3).Text & "</B>: " & objBCSP.TrimSubFieldCodes(strTemp) & "<BR>"
                        Case "260"
                            strTemp = objBZ3950.ConvertUTF8toUni(Array2(i))
                            strResult &= "<B>" & ddlLabel.Items(4).Text & "</B>: " & objBCSP.TrimSubFieldCodes(strTemp) & "<BR>"
                        Case "300"
                            strTemp = objBZ3950.ConvertUTF8toUni(Array2(i))
                            strResult &= "<B>" & ddlLabel.Items(5).Text & "</B>: " & objBCSP.TrimSubFieldCodes(strTemp) & "<BR>"
                    End Select
                End If
            Next
            Return strResult
        End Function

        ' GenSimple method
        ' Purpose: Genarate Simple format method.
        Public Function GenSimple(ByVal Array1 As Object, ByVal Array2 As Object) As String
            Dim strOut As String = ""
            Dim intIndex As Integer
            Dim strAuthor As String = ddlLabel.Items(3).Text
            Dim strTitle As String = ddlLabel.Items(4).Text
            Dim strPublisher As String = ddlLabel.Items(5).Text
            Dim strPhysicalInfor As String = ddlLabel.Items(6).Text

            intIndex = objBZ3950.FindIndex(Array1, "100")
            If intIndex >= 0 Then
                strOut = strOut & "<B>" & strAuthor & ": </B>" & objBCSP.TrimSubFieldCodes(Array2(intIndex)) & "<BR>"
            End If
            intIndex = objBZ3950.FindIndex(Array1, "245")
            If intIndex >= 0 Then
                strOut = strOut & "<B>" & strTitle & ": </B>" & objBCSP.TrimSubFieldCodes(Array2(intIndex)) & "<BR>"
            End If
            intIndex = objBZ3950.FindIndex(Array1, "260")
            If intIndex >= 0 Then
                strOut = strOut & "<B>" & strPublisher & ": </B>" & objBCSP.TrimSubFieldCodes(Array2(intIndex)) & "<BR>"
            End If
            intIndex = objBZ3950.FindIndex(Array1, "300")
            If intIndex >= 0 Then
                strOut = strOut & "<B>" & strPhysicalInfor & ": </B>" & objBCSP.TrimSubFieldCodes(Array2(intIndex)) & "<BR>"
            End If
            If Not strOut = "" Then
                strOut = Left(strOut, Len(strOut) - 4)
            End If
            GenSimple = strOut
        End Function

        ' GenISBD method
        ' Purpose: Genarate ISBD format method.
        Public Function GenISBD(ByVal Array1, ByVal Array2) As String
            Dim strResult As String = ""
            Dim intIndex As Integer

            intIndex = objBZ3950.FindIndex(Array1, "100")
            If intIndex >= 0 Then
                strResult = "<B>" & objBCSP.TrimSubFieldCodes(Array2(intIndex)) & ". </B>"
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
            GenISBD = strResult
        End Function

        ' Page_Unload event
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: Release all object
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
                If Not objBForm Is Nothing Then
                    objBForm.Dispose(True)
                    objBForm = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace