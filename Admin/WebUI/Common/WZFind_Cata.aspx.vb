Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Common
    Partial Class WZFind_Cata
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents hidRecStart As System.Web.UI.HtmlControls.HtmlInputHidden



        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBCSP As New clsBCommonStringProc
        Private objBCDB As New clsBCommonDBSystem
        Private objBZ3950 As New clsBZ3950
        Private objBInput As New clsBInput
        Private ProccessedQuery As Boolean
        Private intPage As Integer = 9

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()

            If Not Page.IsPostBack Then
                Session("VietUSMARC") = False
                If Request("search") & "" <> "" Then
                    Call ProcessZQuery(1)
                    ShowResult(1)
                End If
            End If
            If hidImport.Value <> -1 Then
                If hidImport.Value = 1 Then
                    Me.ImportAllField(hidImportID.Value)
                Else
                    Me.ImportOneRec(hidImportID.Value)
                End If
                Exit Sub
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
            If Not Page.IsPostBack Then
                '
                If Request.QueryString("opener") = "WCataForm.aspx" Then
                    hidFormID.Value = Request.QueryString("FormID")
                    hidMedium.Value = Request.QueryString("Medium")
                    hidLevel.Value = Request.QueryString("Level")
                    hidTypeCode.Value = Request.QueryString("TypeCode")
                End If
            End If
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
            'objBCDB
            objBCDB.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDB.DBServer = Session("DBServer")
            objBCDB.ConnectionString = Session("ConnectionString")
            Call objBCDB.Initialize()

            objBInput.InterfaceLanguage = Session("InterfaceLanguage")
            objBInput.DBServer = Session("DBServer")
            objBInput.ConnectionString = Session("ConnectionString")
            Call objBInput.Initialize()

        End Sub

        ' Method: BindJS
        Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = 'eMicLibCommon.js'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = 'WZFind.js'></script>")
            btnNext.Attributes.Add("onClick", "return ViewRecord(1,'" & ddlLabel.Items(7).Text & "','" & ddlLabel.Items(8).Text & "','" & ddlLabel.Items(9).Text & "');")
            txtNext.Attributes.Add("OnChange", "ViewRecord(0,'" & ddlLabel.Items(7).Text & "','" & ddlLabel.Items(8).Text & "','" & ddlLabel.Items(9).Text & "');")
            txtNext.Attributes.Add("onKeyDown", "if(event.keyCode == 13 || event.which == 13 ) return(ViewRecord(0,'" & ddlLabel.Items(7).Text & "','" & ddlLabel.Items(8).Text & "','" & ddlLabel.Items(9).Text & "'));")

            ddlDisplay.Attributes.Add("OnChange", "return ViewRecord(2,'" & ddlLabel.Items(7).Text & "','" & ddlLabel.Items(8).Text & "','" & ddlLabel.Items(9).Text & "');")

            btnClose.Attributes.Add("Onclick", "self.close()")
            btnBack.Attributes.Add("onClick", "window.location.href='WZForm.aspx';return false;")
        End Sub

        Private Sub ProcessZQuery(ByVal intStart As Integer)
            'process query
            ShowWaitingOnPage(ddlLabel.Items(6).Text, "..")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''
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
            objBZ3950.Start = intStart
            objBZ3950.Howmany = 50 'Select 50 records/transaction
            'Process ZQuery
            Call objBZ3950.ProccessQuery()
            ProccessedQuery = False
            hidCountRec.Value = 0
            If objBZ3950.ErrorMsg = "" Then
                hidCountRec.Value = objBZ3950.Hits
                ProccessedQuery = True
                Session("objBZ3950Record") = objBZ3950.Record
                Session("RecZ3950Start") = intStart
                txtNext.Text = intStart + intPage
            Else
                Session("objBZ3950Record") = Nothing
                NotFound.Text = objBZ3950.ZError
            End If
            'hidden progess bar
            ShowWaitingOnPage("", "", True)
        End Sub

        Private Sub ShowResult(ByVal intStart As Integer)
            ' Declare variables
            'Dim objResult As Object

            Dim intCounter As Integer
            Dim objResult As Object = Session("objBZ3950Record")
            If intStart <= 0 Then intStart = 1
            ' Process
            If objResult Is Nothing Or IIf(hidCountRec.Value = "", 0, hidCountRec.Value) = 0 Then
                ' Error
                NotFound.Visible = True
            Else

                Call ShowHeader()
                'Dim intEnd As Integer
                'intEnd = intStart + 9
                'If txtNext.Text < hidCountRec.Value - 10 Then
                '    txtNext.Text = intEnd + Session("RecZ3950Start")
                'End If
                '' check for get Session("objBZ3950Record") < 50 result
                'If objResult.length < 100 Then
                '    If 2 * intEnd > objResult.length Then
                '        intEnd = objResult.length / 2
                '        txtNext.Text = intEnd + Session("RecZ3950Start") - 1
                '    End If
                'End If
                'If intEnd > hidCountRec.Value Then intEnd = hidCountRec.Value

                'hidPosRec.Value = intStart
                'intStart = intStart - 1
                Dim intEnd As Integer = 0
                intEnd = intStart + intPage
                If intEnd >= hidCountRec.Value Then
                    intEnd = hidCountRec.Value + 1
                End If
                txtNext.Text = intEnd + 1

                If intEnd > hidCountRec.Value Then intEnd = hidCountRec.Value
                hidPosRec.Value = intStart
                intStart = intStart - 1

                For intCounter = intStart To intEnd - 1 'Display 10 records begin intStart for each view

                    'ShowTable(intCounter, objResult(intCounter, 0))
                    ShowTable(intCounter, objResult(intCounter))
                Next

            End If
        End Sub
        Private Sub ViewNextRecord()
            Dim intNext As Integer = CInt(txtNext.Text) '+ intPage
            If intNext < UBound(Session("objBZ3950Record")) Then
                Me.ShowResult(intNext)
            End If
            'Dim intNext As Integer = CInt(txtNext.Text)
            'If (intNext > Session("RecZ3950Start") + 40) Or (intNext < Session("RecZ3950Start")) Then
            '    Call ProcessZQuery(CInt(txtNext.Text))
            '    ShowResult(1)
            'Else
            '    Me.ShowResult(CInt(txtNext.Text) - Session("RecZ3950Start") + 1)
            'End If
        End Sub
        ' Import selected record
        Public Sub ImportOneRec(ByVal intID As Integer)
            ' Declare variables
            'Dim objResult As Object
            Dim objTagName() As String
            Dim objTagValue() As String
            ReDim objTagName(0)
            ReDim objTagValue(0)
            Dim objSubRecs As Object = Nothing
            Dim intIndex As Integer
            Dim strContent As String = ""

            ' Process
            Dim objResult As Object = Session("objBZ3950Record")
            strContent = objResult(intID)
            Call objBZ3950.FillValueFieldsToArray(strContent, objTagName, objTagValue, "$")

            Dim strTemp As String = ""
            'ISBN
            strTemp = objBZ3950.FindField(objTagName, objTagValue, "020")
            If strTemp <> "" Then
                Call objBCSP.ParseField("$a", strTemp, "nc;", objSubRecs)
                If Not objSubRecs(0) = "" Then
                    hidTag020.Value = objBCSP.GEntryTrim(objSubRecs(0) & "")
                End If
            End If

            'ISSN
            strTemp = objBZ3950.FindField(objTagName, objTagValue, "022")
            If strTemp <> "" Then
                Call objBCSP.ParseField("$a", strTemp, "nc;", objSubRecs)
                If Not objSubRecs(0) = "" Then
                    hidTag022.Value = objBCSP.GEntryTrim(objSubRecs(0) & "")
                End If
            End If

            'Language
            strTemp = objBZ3950.FindField(objTagName, objTagValue, "041")
            If strTemp <> "" Then
                Call objBCSP.ParseField("$a", strTemp, "nc;", objSubRecs)
                If Not objSubRecs(0) = "" Then
                    hidTag041.Value = objBCSP.GEntryTrim(objSubRecs(0) & "")
                End If
            End If

            '044
            strTemp = objBZ3950.FindField(objTagName, objTagValue, "044")
            If strTemp <> "" Then
                Call objBCSP.ParseField("$a", strTemp, "nc;", objSubRecs)
                If Not objSubRecs(0) = "" Then
                    hidTag044.Value = objBCSP.GEntryTrim(objSubRecs(0) & "")
                End If
            End If

            '082
            strTemp = objBZ3950.FindField(objTagName, objTagValue, "082")
            If strTemp <> "" Then
                Call objBCSP.ParseField("$a", strTemp, "nc;", objSubRecs)
                If Not objSubRecs(0) = "" Then
                    hidTag082.Value = objBCSP.GEntryTrim(objSubRecs(0) & "")
                End If
            End If

            'Author
            strTemp = objBZ3950.FindField(objTagName, objTagValue, "100")
            If strTemp <> "" Then
                Call objBCSP.ParseField("$a", strTemp, "nc ", objSubRecs)
                If Not objSubRecs(0) = "" Then
                    hidTag100.Value = objBCSP.GEntryTrim(objSubRecs(0) & "")
                End If
            End If

            'Author
            strTemp = objBZ3950.FindField(objTagName, objTagValue, "110")
            If strTemp <> "" Then
                Call objBCSP.ParseField("$a", strTemp, "nc ", objSubRecs)
                If Not objSubRecs(0) = "" Then
                    hidTag110.Value = objBCSP.GEntryTrim(objSubRecs(0) & "")
                End If
            End If

            ' Main title
            strTemp = objBZ3950.FindField(objTagName, objTagValue, "245")
            If strTemp <> "" Then
                Call objBCSP.ParseField("$a,$b,$c,$n,$p", strTemp, "nc ", objSubRecs)
                If Not objSubRecs(0) = "" Then
                    hidTag245a.Value = objBCSP.GEntryTrim(objSubRecs(0) & "")
                End If
                If Not objSubRecs(1) = "" Then
                    hidTag245b.Value = objBCSP.GEntryTrim(objSubRecs(1) & "")
                End If
                If Not objSubRecs(2) = "" Then
                    hidTag245c.Value = objBCSP.GEntryTrim(objSubRecs(2) & "")
                End If
                If Not objSubRecs(3) = "" Then
                    hidTag245n.Value = objBCSP.GEntryTrim(objSubRecs(3) & "")
                End If
                If Not objSubRecs(4) = "" Then
                    hidTag245p.Value = objBCSP.GEntryTrim(objSubRecs(4) & "")
                End If
            End If

            ' Publish edition 
            strTemp = objBZ3950.FindField(objTagName, objTagValue, "250")
            If strTemp <> "" Then
                Call objBCSP.ParseField("$a", strTemp, "nc ", objSubRecs)
                If Not objSubRecs(0) = "" Then
                    hidTag250.Value = objBCSP.GEntryTrim(objSubRecs(0) & "")
                End If
            End If


            'Pulish information
            strTemp = objBZ3950.FindField(objTagName, objTagValue, "260")
            If strTemp <> "" Then
                Call objBCSP.ParseField("$a,$b,$c", strTemp, "nc ", objSubRecs)
                If Not objSubRecs(0) = "" Then
                    hidTag260a.Value = objBCSP.GEntryTrim(objSubRecs(0) & "")
                End If
                If Not objSubRecs(1) = "" Then
                    hidTag260b.Value = objBCSP.GEntryTrim(objSubRecs(1) & "")
                End If
                If Not objSubRecs(2) = "" Then
                    hidTag260c.Value = objBCSP.GEntryTrim(objSubRecs(2) & "")
                End If
            End If

            'Pulish information
            strTemp = objBZ3950.FindField(objTagName, objTagValue, "300")
            If strTemp <> "" Then
                Call objBCSP.ParseField("$a,$b,$c,$e", strTemp, "nc ", objSubRecs)
                If Not objSubRecs(0) = "" Then
                    hidTag300a.Value = objBCSP.GEntryTrim(objSubRecs(0) & "")
                End If
                If Not objSubRecs(1) = "" Then
                    hidTag300b.Value = objBCSP.GEntryTrim(objSubRecs(1) & "")
                End If
                If Not objSubRecs(2) = "" Then
                    hidTag300c.Value = objBCSP.GEntryTrim(objSubRecs(2) & "")
                End If
                If Not objSubRecs(3) = "" Then
                    hidTag300e.Value = objBCSP.GEntryTrim(objSubRecs(3) & "")
                End If
            End If

            ' Execute
            lblJS.Text = "<script language = 'javascript'>ImportToCataForm();</script>"
            'Response.Flush()
        End Sub

        ' Import all field of selected record
        Public Sub ImportAllField(ByVal intID As Integer)
            Dim strRecordContent As String
            Dim objResult() As String = Session("objBZ3950Record")
            Dim arrFieldName() As Object
            Dim arrFieldValue() As Object
            ReDim arrFieldName(0)
            ReDim arrFieldValue(0)
            Dim intStatus As Integer
            Dim intFormID As Integer
            Dim strCode As String


            strRecordContent = objResult(intID)

            ' Replace some control charaters
            'strRecordContent = Replace(strRecordContent, Chr(31), "$")
            'strRecordContent = Replace(strRecordContent, Chr(30), "#")
            'strRecordContent = Replace(strRecordContent, Chr(29), "#")

            ' Parse string input into 2 array (fieldname & fieldvalue)
            Call objBInput.ParseISORec(strRecordContent, arrFieldName, arrFieldValue)
            'Call objBInput.ParseTaggedRecord(Chr(10), " ", strRecordContent, arrFieldName, arrFieldValue, "$", False)

            ' Add field 911
            ReDim Preserve arrFieldName(UBound(arrFieldName) + 1)
            ReDim Preserve arrFieldValue(UBound(arrFieldValue) + 1)
            arrFieldName(UBound(arrFieldName)) = "911"
            arrFieldValue(UBound(arrFieldValue)) = clsSession.GlbUserFullName

            ' Add field 925
            ReDim Preserve arrFieldName(UBound(arrFieldName) + 1)
            ReDim Preserve arrFieldValue(UBound(arrFieldValue) + 1)
            arrFieldName(UBound(arrFieldName)) = "925"
            arrFieldValue(UBound(arrFieldValue)) = hidMedium.Value

            ' Add field 926
            ReDim Preserve arrFieldName(UBound(arrFieldName) + 1)
            ReDim Preserve arrFieldValue(UBound(arrFieldValue) + 1)
            arrFieldName(UBound(arrFieldName)) = "926"
            arrFieldValue(UBound(arrFieldValue)) = hidLevel.Value

            ' Add field 927
            ReDim Preserve arrFieldName(UBound(arrFieldName) + 1)
            ReDim Preserve arrFieldValue(UBound(arrFieldValue) + 1)
            arrFieldName(UBound(arrFieldName)) = "927"
            arrFieldValue(UBound(arrFieldValue)) = hidTypeCode.Value

            ' Add field 900
            ReDim Preserve arrFieldName(UBound(arrFieldName) + 1)
            ReDim Preserve arrFieldValue(UBound(arrFieldValue) + 1)
            arrFieldName(UBound(arrFieldName)) = "900"
            arrFieldValue(UBound(arrFieldValue)) = "True"

            ' Get FormID
            intFormID = CInt(hidFormID.Value)

            ' Insert new record
            objBInput.FieldName = arrFieldName
            objBInput.FieldValue = arrFieldValue
            intStatus = objBInput.Update(intFormID, 1)
            If intStatus = 0 Then
                'Error
                'objBInput.ErrorCode = 0
                'objBInput.ErrorMsg = ""
            Else
                strCode = objBInput.CodeOut
                ' Execute
                lblJS.Text = "<script language = 'javascript'>opener.location.href='../Acquisition/ACQ/WCopyNumber.aspx?Code=" & strCode & "'; self.close();</script>"
            End If


        End Sub

        'Show table method
        Public Sub ShowTable(ByVal intCurRec As Integer, ByVal strRec As String)
            Dim tblRow As TableRow
            Dim tblCell As TableCell
            Dim lblLabel As Label
            Dim btnButton As Button

            Dim objTagName() As String
            Dim objTagValue() As String
            ReDim objTagName(0)
            ReDim objTagValue(0)

            Dim intIndex As Integer = 0

            tblRow = New TableRow
            tblRow.VerticalAlign = VerticalAlign.Top

            If intCurRec Mod 2 = 0 Then
                tblRow.CssClass = "lbGridCell"
            Else
                tblRow.CssClass = "lbGridAlterCell"
            End If

            'Add order number
            tblCell = New TableCell
            tblCell.Width = Unit.Percentage(5)
            tblCell.HorizontalAlign = HorizontalAlign.Right
            lblLabel = New Label
            lblLabel.CssClass = "lbLabel"
            lblLabel.Text = CInt(Session("RecZ3950Start")) + intCurRec
            tblCell.Controls.Add(lblLabel)
            tblRow.Controls.Add(tblCell)

            'Add content cell
            tblCell = New TableCell
            lblLabel = New Label
            lblLabel.CssClass = "lbLabel"
            Select Case Trim(Session("Display") & "")

                Case "ISBD"
                    ddlDisplay.SelectedIndex = 1
                    'show ISBD
                    'Call objBZ3950.ParseTaggedRecord(strRec, objTagName, objTagValue, "$")
                    'strRec = ISBDDisplay(objTagName, objTagValue)

                    Call objBZ3950.FillValueFieldsToArray(strRec, objTagName, objTagValue, "$")
                    strRec = getISBD(objTagName, objTagValue)

                    lblLabel.Text = strRec

                Case "MARC"
                    ddlDisplay.SelectedIndex = 0
                    'show MARC
                    'strRec = Replace(strRec, Chr(10), "<BR>")
                    'strRec = Replace(strRec, " ", "&nbsp;")
                    Call objBZ3950.FillValueFieldsToArray(strRec, objTagName, objTagValue, "$", True)
                    strRec = getMARC(objTagName, objTagValue)
                    lblLabel.Text = strRec

                Case "SIMPLE"
                    ddlDisplay.SelectedIndex = 2
                    'show Simple
                    'Call objBZ3950.ParseTaggedRecord(strRec, objTagName, objTagValue, "$")
                    'intIndex = objBZ3950.FindIndex(objTagName, "100")
                    'strRec = ""
                    'If intIndex >= 0 Then
                    '    strRec = "<B>" & ddlLabel.Items(2).Text & "</B>: " & objBCSP.TrimSubFieldCodes(objTagValue(intIndex)) & "<BR>"
                    'End If
                    'intIndex = objBZ3950.FindIndex(objTagName, "245")
                    'If intIndex >= 0 Then
                    '    strRec = strRec & "<B>" & ddlLabel.Items(3).Text & "</B>: " & objBCSP.TrimSubFieldCodes(objTagValue(intIndex)) & "<BR>"
                    'End If
                    'intIndex = objBZ3950.FindIndex(objTagName, "260")
                    'If intIndex >= 0 Then
                    '    strRec = strRec & "<B>" & ddlLabel.Items(4).Text & "</B>: " & objBCSP.TrimSubFieldCodes(objTagValue(intIndex)) & "<BR>"
                    'End If
                    'intIndex = objBZ3950.FindIndex(objTagName, "300")
                    'If intIndex >= 0 Then
                    '    strRec = strRec & "<B>" & ddlLabel.Items(5).Text & "</B>: " & objBCSP.TrimSubFieldCodes(objTagValue(intIndex)) & "<BR>"
                    'End If
                    Call objBZ3950.FillValueFieldsToArray(strRec, objTagName, objTagValue, "$")
                    strRec = getSimple(objTagName, objTagValue)

                    lblLabel.Text = strRec

            End Select

            tblCell.Controls.Add(lblLabel)
            tblRow.Controls.Add(tblCell)
            tblResult.Rows.Add(tblRow)

            'Add button
            tblRow = New TableRow
            tblCell = New TableCell
            tblCell.Width = Unit.Percentage(5)
            tblRow.Controls.Add(tblCell)

            tblCell = New TableCell
            btnButton = New Button
            btnButton.Text = ddlLabel.Items(10).Text
            btnButton.Attributes.Add("onClick", "CataSubmit(" & intCurRec & ",0);")
            tblCell.Controls.Add(btnButton)
            btnButton = New Button
            btnButton.Text = ddlLabel.Items(11).Text
            btnButton.Attributes.Add("onClick", "CataSubmit(" & intCurRec & ",1);")
            tblCell.Controls.Add(btnButton)

            tblRow.Controls.Add(tblCell)
            tblResult.Rows.Add(tblRow)

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

        ' ISBDDisplay method
        Public Function ISBDDisplay(ByVal Array1() As String, ByVal Array2() As String) As String
            'Dim strResult As String
            'Dim intIndex As Integer
            'intIndex = objBZ3950.FindIndex(Array1, "100")
            'If intIndex >= 0 Then
            '    strResult = strResult & "<B>" & objBCSP.TrimSubFieldCodes(Array2(intIndex)) & ". </B>"
            'End If
            'intIndex = objBZ3950.FindIndex(Array1, "245")
            'If intIndex >= 0 Then
            '    strResult = strResult & objBCSP.TrimSubFieldCodes(Array2(intIndex))
            'End If
            'intIndex = objBZ3950.FindIndex(Array1, "260")
            'If intIndex >= 0 Then
            '    strResult = strResult & ". - " & objBCSP.TrimSubFieldCodes(Array2(intIndex))
            'End If
            'intIndex = objBZ3950.FindIndex(Array1, "300")
            'If intIndex >= 0 Then
            '    strResult = strResult & ". - " & objBCSP.TrimSubFieldCodes(Array2(intIndex))
            'End If
            'Return strResult
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

        ' ShowHeader method
        Private Sub ShowHeader()
            Dim tblRow As TableRow
            Dim tblCell As TableCell
            ' remove all row in Table
            tblResult.Controls.Clear()

            '            If objBZ3950.Hits - objBZ3950.Howmany > 0 Then
            'Show Pager of Table
            If hidCountRec.Value > 9 Then
                lblNext.Visible = True
                txtNext.Visible = True
                btnNext.Visible = True
            End If
            ddlDisplay.Visible = True
            lblDisplay.Visible = True
            '           End If

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
            tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(3).Text & "-&nbsp;&nbsp;" & ddlLabel.Items(0).Text & " : " & hidCountRec.Value & "(" & ddlLabel.Items(1).Text & ")"))
            tblRow.Cells.Add(tblCell)

            tblResult.Rows.Add(tblRow)
        End Sub

        ' Page_Unload Method
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Get the most used cataloguing form by booktype
        Public Function GetFormID(ByVal intBookTypeID As Integer) As Integer
            If Not Session("DBServer") = "ORACLE" Then
                Me.objBCDB.SQLStatement = "SELECT TOP 1 FormID FROM Item WHERE TypeID = " & intBookTypeID & " AND FormID IS NOT NULL GROUP BY FormID ORDER BY Count(ID) DESC"
            Else
                Me.objBCDB.SQLStatement = "select * from (SELECT FormID FROM Item WHERE TypeID = " & intBookTypeID & " AND FormID IS NOT NULL GROUP BY FormID ORDER BY Count(ID) DESC) where ROWNUM <=1"
            End If
            Dim tblTemp As DataTable
            tblTemp = Me.objBCDB.RetrieveItemInfor
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                GetFormID = tblTemp.Rows(0).Item(0)
            Else
                Me.objBCDB.SQLStatement = "SELECT min(ID) FROM Lib_tblMARCWorksheet"
                tblTemp = Me.objBCDB.RetrieveItemInfor
                GetFormID = tblTemp.Rows(0).Item(0)
            End If
        End Function


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
                If Not objBCDB Is Nothing Then
                    objBCDB.Dispose(True)
                    objBCDB = Nothing
                End If
                If Not objBInput Is Nothing Then
                    objBInput.Dispose(True)
                    objBInput = Nothing
                End If

            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

    End Class
End Namespace