' Class: WBatchPatronUpdate
' Puspose: Management update batch patron
' Creator: Oanhtn
' CreatedDate: 21/01/2005
' Modification History:

Imports eMicLibAdmin.BusinessRules.Patron
Imports eMicLibAdmin.BusinessRules.Common
Imports Telerik.Web.UI

Namespace eMicLibAdmin.WebUI.Patron

    Partial Class WBatchPatronUpdate
        Inherits clsWBase
        Implements IUCNumberOfRecord

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

        ' Declare variable
        Private objBCDBS As New clsBCommonDBSystem
        Private objBPC As New clsBPatronCollection
        Private objBF As New clsBFaculty
        Private objBC As New clsBCollege
        Private objBED As New clsBEducation
        Private objBO As New clsBOccupation
        Private objBE As New clsBEthnic
        Private objBP As New clsBProvince
        Private objBPG As New clsBPatronGroup
        Private objBPT As New clsBPatron

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckPermissionFrom()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                ' Load Default for ddlOptionFieldValue1, ddlOptionFieldValue1
                Call LoadData(2, 5)
                Call LoadData(7, 6)
                Call LoadData(7, 9)
                btnUpdate.Visible = False
            End If
            Call LoadBackData()
        End Sub

        ' Method: CheckPermissionFrom
        Sub CheckPermissionFrom()
            If Not CheckPemission(48) Then
                btnUpdate.Enabled = False
            End If
        End Sub

        ' Method: Initialize
        Private Sub Initialize()
            ' Initialize  objBCDBS  object
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCDBS.Initialize()

            ' Initialize  objBPC  object
            objBPC.DBServer = Session("DBServer")
            objBPC.ConnectionString = Session("ConnectionString")
            objBPC.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPC.initialize()

            ' Initialize  objBF  object
            objBF.DBServer = Session("DBServer")
            objBF.ConnectionString = Session("ConnectionString")
            objBF.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBF.Initialize()

            ' Initialize  objBC  object
            objBC.DBServer = Session("DBServer")
            objBC.ConnectionString = Session("ConnectionString")
            objBC.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBC.Initialize()

            ' Initialize  objBED  object
            objBED.DBServer = Session("DBServer")
            objBED.ConnectionString = Session("ConnectionString")
            objBED.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBED.Initialize()

            ' Initialize  objBO  object
            objBO.DBServer = Session("DBServer")
            objBO.ConnectionString = Session("ConnectionString")
            objBO.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBO.Initialize()

            ' Initialize  objBE  object
            objBE.DBServer = Session("DBServer")
            objBE.ConnectionString = Session("ConnectionString")
            objBE.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBE.Initialize()

            ' Initialize  objBP  object
            objBP.DBServer = Session("DBServer")
            objBP.ConnectionString = Session("ConnectionString")
            objBP.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBP.Initialize()

            ' Initialize  objBPG  object
            objBPG.DBServer = Session("DBServer")
            objBPG.ConnectionString = Session("ConnectionString")
            objBPG.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPG.Initialize()

            ' Initialize  objBPT  object
            objBPT.DBServer = Session("DBServer")
            objBPT.ConnectionString = Session("ConnectionString")
            objBPT.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPT.Initialize()
        End Sub

        ' Method: LoadBackData
        Private Sub LoadBackData()
            Dim intCount As Integer
            Dim intMax As Integer
            Dim strTempo As String = ""
            Dim strMakeCombo As String = ""
            Dim tblTemp As New DataTable

            Try
                tblTemp = objBPC.RetrieveDicTable

                ' Check Error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPC.ErrorMsg, ddlLabel.Items(0).Text, objBPC.ErrorCode)

                If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                    intMax = tblTemp.Rows.Count + 3
                    strTempo = strTempo & "ArrOptionIndex = new Array(" & intMax & ");" & Chr(10)
                    strTempo = strTempo & "ArrValue = new Array(" & intMax & ");" & Chr(10)
                    strTempo = strTempo & "ArrText = new Array(" & intMax & ");" & Chr(10)
                    ' OPTIONINDEX, Selecteditem.Value, FACULTY AS SELECTEDTEXT
                    For intCount = 0 To intMax - 4
                        strTempo = strTempo & "ArrOptionIndex[" & intCount & "] = " & tblTemp.Rows(intCount).Item("OPTIONINDEX") & ";" & Chr(10)
                        strTempo = strTempo & "ArrValue[" & intCount & "] = " & tblTemp.Rows(intCount).Item("SELECTEDVALUE") & ";" & Chr(10)
                        strTempo = strTempo & "ArrText[" & intCount & "] = '" & tblTemp.Rows(intCount).Item("SELECTEDTEXT").ToString.Replace("'", "\'") & "';" & Chr(10)
                    Next
                    ' ADD SEXddlFieldName5
                    strTempo = strTempo & "ArrOptionIndex[" & intCount + 1 & "] = 8;" & Chr(10)
                    strTempo = strTempo & "ArrValue[" & intCount + 1 & "] = 0;" & Chr(10)
                    strTempo = strTempo & "ArrText[" & intCount + 1 & "] = '" & ddlLabel.Items(13).Text & "';" & Chr(10)
                    strTempo = strTempo & "ArrOptionIndex[" & intCount + 2 & "] = 8;" & Chr(10)
                    strTempo = strTempo & "ArrValue[" & intCount + 2 & "] = 1;" & Chr(10)
                    strTempo = strTempo & "ArrText[" & intCount + 2 & "] = '" & ddlLabel.Items(11).Text & "';" & Chr(10)
                    strTempo = strTempo & "ArrOptionIndex[" & intCount + 3 & "] = 8;" & Chr(10)
                    strTempo = strTempo & "ArrValue[" & intCount + 3 & "] = 2;" & Chr(10)
                    strTempo = strTempo & "ArrText[" & intCount + 3 & "] = '" & ddlLabel.Items(12).Text & "';" & Chr(10)

                    Page.RegisterClientScriptBlock("LoadJs", "<script language = 'javascript'>" & strTempo & "</script>")
                End If
            Catch ex As Exception ' Check Error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, ex.Message.Trim, ddlLabel.Items(0).Text, 0)
            End Try
            ' Load selected value
            Dim ArrSelectedValue() As String
            If Not txtHidden1.Value = "" Then
                Call LoadData(ddlFieldName5.SelectedItem.Value, 5)
                ArrSelectedValue = Split(txtHidden1.Value, "#")
                If CInt(ArrSelectedValue(1)) > 0 Then
                    ddlOptionFieldValue1.SelectedIndex = CInt(ArrSelectedValue(1))
                End If
            End If

            If Not txtHidden2.Value = "" Then
                Call LoadData(ddlFieldName6.SelectedItem.Value, 6)
                ArrSelectedValue = Split(txtHidden2.Value, "#")
                If CInt(ArrSelectedValue(1)) > 0 Then
                    ddlOptionFieldValue2.SelectedIndex = CInt(ArrSelectedValue(1))
                End If
            End If

            If Not txtHidden3.Value = "" Then
                Call LoadData(ddlFieldName9.SelectedItem.Value, 9)
                ArrSelectedValue = Split(txtHidden3.Value, "#")
                If CInt(ArrSelectedValue(1)) > 0 Then
                    ddlOptionFieldValue3.SelectedIndex = CInt(ArrSelectedValue(1))
                End If
            End If

            ' Release object
            tblTemp.Dispose()
            tblTemp = Nothing
        End Sub

        ' BindJS method
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WBatchPatronUpdateJs", "<script language = 'javascript' src='js/WBatchPatronUpdate.js'></script>")

            ddlFieldName5.Attributes.Add("OnChange", "javascript:document.forms[0].txtHidden1.value = ''; LoadBack(this.value, 1, '" & ddlLabel.Items(4).Text & "');")
            ddlFieldName6.Attributes.Add("OnChange", "javascript:document.forms[0].txtHidden2.value = ''; LoadBack(this.value, 2, '" & ddlLabel.Items(4).Text & "');")
            ddlFieldName9.Attributes.Add("OnChange", "javascript:document.forms[0].txtHidden3.value = ''; LoadBack(this.value, 3, '" & ddlLabel.Items(4).Text & "');")
            ddlOptionFieldValue1.Attributes.Add("OnChange", "document.forms[0].txtHidden1.value = this.value + '#' + this.selectedIndex;")
            ddlOptionFieldValue2.Attributes.Add("OnChange", "document.forms[0].txtHidden2.value = this.value + '#' + this.selectedIndex;")
            ddlOptionFieldValue3.Attributes.Add("OnChange", "document.forms[0].txtHidden3.value = this.value + '#' + this.selectedIndex;")

            Me.RegisterCalendar("..")
            SetOnclickCalendar(lnkFromDate1, txtFieldValueFrom1, ddlLabel.Items(5).Text)
            SetOnclickCalendar(lnkFromDate2, txtFieldValueFrom2, ddlLabel.Items(5).Text)
            SetOnclickCalendar(lnkToDate1, txtFieldValueTo1, ddlLabel.Items(5).Text)
            SetOnclickCalendar(lnkToDate2, txtFieldValueTo2, ddlLabel.Items(5).Text)
            SetOnclickCalendar(lnkNewDate, txtNewDateValue, ddlLabel.Items(5).Text)

            btnReset.Attributes.Add("OnClick", "ClearAll(); return false;")
        End Sub

        ' Load Data into option dropdown list
        Private Sub LoadData(ByVal bytOption As Byte, ByVal bytIndex As Byte)
            Dim tblTemp As New DataTable
            Dim strValueField As String
            Dim strTextField As String
            'Set lib 
            objBPG.LibID = clsSession.GlbSite
            Select Case bytOption
                Case 1 ' Faculty
                    objBF.ID = 0
                    objBF.CollegeID = 0
                    tblTemp = objBF.GetFaculty()
                    ' Check error
                    Call WriteErrorMssg(ddlLabel.Items(1).Text, objBF.ErrorMsg, ddlLabel.Items(0).Text, objBF.ErrorCode)
                    strValueField = "ID"
                    strTextField = "FC"
                Case 2 ' College
                    tblTemp = objBC.GetCollege
                    ' Check error
                    Call WriteErrorMssg(ddlLabel.Items(1).Text, objBC.ErrorMsg, ddlLabel.Items(0).Text, objBC.ErrorCode)

                    strValueField = "ID"
                    strTextField = "College"
                Case 3 ' Education
                    tblTemp = objBED.GetEducation
                    ' Check error
                    Call WriteErrorMssg(ddlLabel.Items(1).Text, objBED.ErrorMsg, ddlLabel.Items(0).Text, objBED.ErrorCode)

                    strValueField = "ID"
                    strTextField = "EducationLevel"
                Case 5 ' Occupation
                    tblTemp = objBO.GetOccupation
                    ' Check error
                    Call WriteErrorMssg(ddlLabel.Items(1).Text, objBO.ErrorMsg, ddlLabel.Items(0).Text, objBO.ErrorCode)

                    strValueField = "ID"
                    strTextField = "Occupation"
                Case 4 ' Ethnic
                    tblTemp = objBE.GetEthnic
                    ' Check error
                    Call WriteErrorMssg(ddlLabel.Items(1).Text, objBE.ErrorMsg, ddlLabel.Items(0).Text, objBE.ErrorCode)

                    strValueField = "ID"
                    strTextField = "Ethnic"
                Case 6 ' Province
                    tblTemp = objBP.GetProvince
                    ' Check error
                    Call WriteErrorMssg(ddlLabel.Items(1).Text, objBP.ErrorMsg, ddlLabel.Items(0).Text, objBP.ErrorCode)

                    strValueField = "ID"
                    strTextField = "Province"
                Case 7 ' PatronGroup

                    tblTemp = objBPG.GetPatronGroup
                    ' Check error
                    Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPG.ErrorMsg, ddlLabel.Items(0).Text, objBPG.ErrorCode)

                    strValueField = "ID"
                    strTextField = "Name"
                Case Else ' Sex
                    Dim ArrSexTextField() As String = {ddlLabel.Items(13).Text, ddlLabel.Items(11).Text, ddlLabel.Items(12).Text}
                    Dim ArrSexValueField() As Byte = {0, 1, 2}
                    tblTemp = objBCDBS.CreateTable(ArrSexTextField, ArrSexValueField)
                    strValueField = "ValueField"
                    strTextField = "TextField"
            End Select

            tblTemp = objBCDBS.InsertOneRow(tblTemp, ddlLabel.Items(4).Text)
            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    Select Case bytIndex
                        Case 5
                            ddlOptionFieldValue1.DataSource = tblTemp
                            ddlOptionFieldValue1.DataTextField = strTextField
                            ddlOptionFieldValue1.DataValueField = strValueField
                            ddlOptionFieldValue1.DataBind()
                        Case 6
                            ddlOptionFieldValue2.DataSource = tblTemp
                            ddlOptionFieldValue2.DataTextField = strTextField
                            ddlOptionFieldValue2.DataValueField = strValueField
                            ddlOptionFieldValue2.DataBind()
                        Case 9
                            ddlOptionFieldValue3.DataSource = tblTemp
                            ddlOptionFieldValue3.DataTextField = strTextField
                            ddlOptionFieldValue3.DataValueField = strValueField
                            ddlOptionFieldValue3.DataBind()
                    End Select
                    tblTemp.Clear()
                    tblTemp.Dispose()
                    tblTemp = Nothing
                End If
            End If
        End Sub

        ' dtgResult_PageIndexChanged
        'Public Sub dtgResult_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        '    dtgResult.EditItemIndex = -1
        '    dtgResult.CurrentPageIndex = e.NewPageIndex
        '    Call GridDisplay(CType(Session("strPatronIDs"), Object), Session("strSQLIDs"))
        '    'Call GridDisplay(CType(Session("strPatronIDs"), Object))
        'End Sub

        Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            Dim ArrOptionValue() As String
            ' Text Field
            objBPC.FieldName(1) = ddlFieldName1.SelectedItem.Value
            objBPC.FieldValue(1) = txtFieldValue1.Text
            objBPC.FieldName(2) = ddlFieldName2.SelectedItem.Value
            objBPC.FieldValue(2) = txtFieldValue2.Text

            ' Date Field From
            objBPC.FieldNameDate(1) = ddlFieldName3.SelectedItem.Value
            objBPC.FieldValueFrom(1) = txtFieldValueFrom1.Text
            objBPC.FieldNameDate(2) = ddlFieldName4.SelectedItem.Value
            objBPC.FieldValueFrom(2) = txtFieldValueFrom2.Text

            ' Date To, Operator From
            objBPC.FieldValueTo(1) = txtFieldValueTo1.Text
            objBPC.FieldValueTo(2) = txtFieldValueTo2.Text
            objBPC.FieldOpeFrom(1) = ddlFieldOpeFrom1.SelectedItem.Value
            objBPC.FieldOpeFrom(2) = ddlFieldOpeFrom2.SelectedItem.Value

            ' Logic Operator
            objBPC.[Operator](1) = ddlOperator1.SelectedItem.Value
            objBPC.[Operator](2) = ddlOperator2.SelectedItem.Value
            objBPC.[Operator](3) = ddlOperator3.SelectedItem.Value
            objBPC.[Operator](4) = ddlOperator4.SelectedItem.Value
            objBPC.[Operator](5) = ddlOperator5.SelectedItem.Value

            ' Other Field
            If Not txtHidden1.Value = "" Then
                ArrOptionValue = Split(txtHidden1.Value, "#")
                If CInt(ArrOptionValue(0)) > 0 Then
                    objBPC.FieldNameOther(1) = ddlFieldName5.SelectedItem.Value
                    objBPC.FieldValueOther(1) = CInt(ArrOptionValue(0))
                End If
            End If
            If Not txtHidden2.Value = "" Then
                ArrOptionValue = Split(txtHidden2.Value, "#")
                If CInt(ArrOptionValue(0)) > 0 Then
                    objBPC.FieldNameOther(2) = ddlFieldName6.SelectedItem.Value
                    objBPC.FieldValueOther(2) = CInt(ArrOptionValue(0))
                End If
            End If

            ' Condition
            objBPC.OrderBy = ddlOrderBy.SelectedItem.Value
            objBPC.SelectTop = ddlMaxRecord.SelectedItem.Value
            objBPC.TypeSearch = "ADVANCE"
            objBPC.LibID = clsSession.GlbSite
            Dim strArrResult() As Object
            strArrResult = objBPC.Search()

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPC.ErrorMsg, ddlLabel.Items(0).Text, objBPC.ErrorCode)

            Dim strSQL As String = objBPC.SQL
            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPC.ErrorMsg, ddlLabel.Items(0).Text, objBPC.ErrorCode)

            Dim blnFalg As Boolean = True
            Session("strPatronIDs") = strArrResult
            If strArrResult Is Nothing Then
                blnFalg = False
            ElseIf CInt(strArrResult(0)) = -1 Then
                blnFalg = False
            End If
            If Not blnFalg Then
                'Page.RegisterClientScriptBlock("PatronNotFoundJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(10).Text & "')</script>")
                lblNoData.Visible = True
                dtgResult.Visible = False
                btnUpdate.Visible = False
            Else
                lblNoData.Visible = False
                Session("strPatronIDs") = strArrResult
                Session("strSQLIDs") = strSQL
                Call GridDisplay(strArrResult, strSQL) ' Display data
                dtgResult.Rebind()
                'Call GridDisplay(strArrResult) ' Display data
            End If

        End Sub
        ' Method: GridDisplay
        ' Popurse: This method used to display All of patron have been search
        Private Sub GridDisplay(ByVal objRetValue As Object, ByVal strSQLForming As String)
            If Not objRetValue Is Nothing Then
                Me.ShowWaitingOnPage(ddlLabel.Items(14).Text & " " & CStr(UBound(objRetValue) + 1) & " " & ddlLabel.Items(15).Text, "..")
                Dim tblSearchResult As New DataTable
                Dim tblShowResult As New DataTable
                Dim dtrTmp As DataRow
                Dim intCounter As Integer
                Dim strIDs As String = ""
                Dim intMaxRowsOfPage As Integer
                Dim strValue1 As String = txtFieldValue1.Text.Replace("%", "")
                Dim strValue2 As String = txtFieldValue2.Text.Replace("%", "")

                ' Retrieve Datatable of Patron's infor by IDs
                If strSQLForming <> "" And ddlMaxRecord.SelectedValue = 0 And strValue1 = "" And strValue2 = "" Then
                    strIDs = strSQLForming.Replace(",FirstName", " ").Replace(",LastName", " ").Replace(",ExpiredDate", " ").Replace(",ValidDate", " ").Replace(",DOB", " ").Replace(",Code", " ").Replace(",FIRSTNAME", " ").Replace(",LASTNAME", " ").Replace(",EXPIREDDATE", " ").Replace(",VALIDDATE", " ").Replace(",DOB", " ").Replace(",CODE", " ")
                Else
                    For intCounter = 0 To UBound(objRetValue)
                        strIDs = strIDs & objRetValue(intCounter) & ","
                    Next
                    strIDs = Left(strIDs, Len(strIDs) - 1)
                End If
                objBPT.PatronIDs = strIDs
                objBPT.Fields = ""
                tblSearchResult = objBCDBS.GenTableSort(objRetValue, objBPT.GetPatron)
                ' Datatable of Patron's infor after order by
                tblShowResult = tblSearchResult

                dtgResult.Visible = False
                If Not tblShowResult Is Nothing Then
                    If tblShowResult.Rows.Count > 0 Then
                        For intCounter = 0 To tblShowResult.Rows.Count - 1
                            tblShowResult.Rows(intCounter).Item("Rownumber") = CStr(intCounter + 1)
                        Next
                        'Dim intCount As Integer
                        'Dim intItemCount As Integer

                        'If CInt(tblShowResult.Rows.Count) <= CInt(dtgResult.PageSize) Then
                        '    intCount = 1
                        '    dtgResult.CurrentPageIndex = 0
                        'Else
                        '    intCount = CInt(tblShowResult.Rows.Count / dtgResult.PageSize)
                        'End If
                        'intItemCount = intCount * dtgResult.PageSize
                        'If intItemCount = tblShowResult.Rows.Count Then
                        '    If dtgResult.CurrentPageIndex > intCount - 1 Then
                        '        dtgResult.CurrentPageIndex = dtgResult.CurrentPageIndex - 1
                        '    End If
                        'End If

                        dtgResult.Visible = True
                        dtgResult.DataSource = tblShowResult

                        'dtgResult.DataBind()
                        'If dtgResult.PageCount = 1 Then
                        '    intMaxRowsOfPage = tblShowResult.Rows.Count
                        'Else
                        '    If dtgResult.CurrentPageIndex < dtgResult.PageCount - 1 Then
                        '        intMaxRowsOfPage = dtgResult.PageSize
                        '    Else
                        '        intMaxRowsOfPage = tblShowResult.Rows.Count - dtgResult.PageSize * dtgResult.CurrentPageIndex
                        '    End If
                        'End If
                    End If
                End If
                btnUpdate.Visible = True

                ' Check null value
                btnUpdate.Attributes.Add("OnClick", "javascript: if (!CheckAllUpdate('dtgResult', 'chkSelectedID', " & intMaxRowsOfPage & ", '" & ddlLabel.Items(9).Text & "', '" & ddlLabel.Items(6).Text & "')) {return false;}")

                tblSearchResult.Dispose()
                tblSearchResult = Nothing
                tblShowResult.Dispose()
                tblShowResult = Nothing
                Me.ShowWaitingOnPage("", "", True)
            Else
                dtgResult.Visible = False
                btnUpdate.Visible = False
            End If
            '    btnExtend.Visible = True
            '    ' Check null value
            '    btnExtend.Attributes.Add("OnClick", "javascript:if (!CheckAllExtend('dtgResult', 'chkSelectedID', " & intMaxRowsOfPage & ", '" & ddlLabel.Items(5).Text & "', '" & ddlLabel.Items(6).Text & "')) {return false;}")
            '    tblSearchResult.Dispose()
            '    tblSearchResult = Nothing
            '    tblShowResult.Dispose()
            '    tblShowResult = Nothing
            '    Me.ShowWaitingOnPage("", "", True)
            'Else
            '    dtgResult.Visible = False
            '    btnExtend.Visible = False
            'End If
        End Sub


        Protected Sub dtgResult_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles dtgResult.NeedDataSource
            Dim ArrOptionValue() As String
            objBPC.FieldName(1) = ddlFieldName1.SelectedItem.Value
            objBPC.FieldValue(1) = txtFieldValue1.Text
            objBPC.FieldName(2) = ddlFieldName2.SelectedItem.Value
            objBPC.FieldValue(2) = txtFieldValue2.Text

            ' Date Field From
            objBPC.FieldNameDate(1) = ddlFieldName3.SelectedItem.Value
            objBPC.FieldValueFrom(1) = txtFieldValueFrom1.Text
            objBPC.FieldNameDate(2) = ddlFieldName4.SelectedItem.Value
            objBPC.FieldValueFrom(2) = txtFieldValueFrom2.Text

            ' Date To, Operator From
            objBPC.FieldValueTo(1) = txtFieldValueTo1.Text
            objBPC.FieldValueTo(2) = txtFieldValueTo2.Text
            objBPC.FieldOpeFrom(1) = ddlFieldOpeFrom1.SelectedItem.Value
            objBPC.FieldOpeFrom(2) = ddlFieldOpeFrom2.SelectedItem.Value

            ' Logic Operator
            objBPC.[Operator](1) = ddlOperator1.SelectedItem.Value
            objBPC.[Operator](2) = ddlOperator2.SelectedItem.Value
            objBPC.[Operator](3) = ddlOperator3.SelectedItem.Value
            objBPC.[Operator](4) = ddlOperator4.SelectedItem.Value
            objBPC.[Operator](5) = ddlOperator5.SelectedItem.Value

            ' Other Field
            If Not txtHidden1.Value = "" Then
                ArrOptionValue = Split(txtHidden1.Value, "#")
                If CInt(ArrOptionValue(0)) > 0 Then
                    objBPC.FieldNameOther(1) = ddlFieldName5.SelectedItem.Value
                    objBPC.FieldValueOther(1) = CInt(ArrOptionValue(0))
                End If
            End If
            If Not txtHidden2.Value = "" Then
                ArrOptionValue = Split(txtHidden2.Value, "#")
                If CInt(ArrOptionValue(0)) > 0 Then
                    objBPC.FieldNameOther(2) = ddlFieldName6.SelectedItem.Value
                    objBPC.FieldValueOther(2) = CInt(ArrOptionValue(0))
                End If
            End If

            ' Condition
            objBPC.OrderBy = ddlOrderBy.SelectedItem.Value
            If Not Page.IsPostBack Then
                objBPC.SelectTop = 50
            Else
                objBPC.SelectTop = ddlMaxRecord.SelectedItem.Value
            End If
            objBPC.TypeSearch = "ADVANCE"
            objBPC.LibID = clsSession.GlbSite
            Dim strArrResult() As Object
            strArrResult = objBPC.Search()

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPC.ErrorMsg, ddlLabel.Items(0).Text, objBPC.ErrorCode)

            Dim strSQL As String = objBPC.SQL
            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPC.ErrorMsg, ddlLabel.Items(0).Text, objBPC.ErrorCode)

            Dim blnFalg As Boolean = True
            Session("strPatronIDs") = strArrResult
            If strArrResult Is Nothing Then
                blnFalg = False
            ElseIf CInt(strArrResult(0)) = -1 Then
                blnFalg = False
            End If
            If Not blnFalg Then
                'Page.RegisterClientScriptBlock("PatronNotFoundJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(10).Text & "')</script>")
                lblNoData.Visible = True
                dtgResult.Visible = False
                btnUpdate.Visible = False
            Else
                lblNoData.Visible = False
                Session("strPatronIDs") = strArrResult
                Session("strSQLIDs") = strSQL
                If Not Page.IsPostBack Then
                Else
                    Call GridDisplay(strArrResult, strSQL) ' Display data
                End If
                'Call GridDisplay(strArrResult) ' Display data
            End If


        End Sub

        ' Method: GridDisplay
        'Private Sub GridDisplay(ByVal objRetValue)
        '    If Not objRetValue Is Nothing Then
        '        Dim tblSearchResult As New DataTable
        '        Dim tblShowResult As New DataTable
        '        Dim dtrTmp As DataRow
        '        Dim intCounter As Integer
        '        Dim strIDs As String = ""
        '        Dim intMaxRowsOfPage As Integer
        '        Dim intPagesize As Integer = 10
        '        ' Retrieve Datatable of Patron's infor by IDs
        '        For intCounter = 0 To UBound(objRetValue)
        '            strIDs = strIDs & objRetValue(intCounter) & ","
        '        Next
        '        strIDs = Left(strIDs, Len(strIDs) - 1)
        '        objBPT.PatronIDs = strIDs
        '        objBPT.Fields = ""
        '        tblSearchResult = objBCDBS.GenTableSort(objRetValue, objBPT.GetPatron)
        '        ' Check error
        '        Call WriteErrorMssg(ddlLabel.Items(1).Text, objBF.ErrorMsg, ddlLabel.Items(0).Text, objBF.ErrorCode)

        '        ' Datatable of Patron's infor after order by
        '        tblShowResult = tblSearchResult
        '        dtgResult.Visible = False

        '        If Not tblShowResult Is Nothing Then
        '            If tblShowResult.Rows.Count > 0 Then
        '                For intCounter = 0 To tblShowResult.Rows.Count - 1
        '                    tblShowResult.Rows(intCounter).Item("Rownumber") = CStr(intCounter + 1)
        '                Next
        '                dtgResult.Visible = True
        '                dtgResult.DataSource = tblShowResult
        '                dtgResult.DataBind()
        '                dtgResult.PageSize = intPagesize
        '                If dtgResult.PageCount = 1 Then
        '                    intMaxRowsOfPage = tblShowResult.Rows.Count
        '                Else
        '                    If dtgResult.CurrentPageIndex < dtgResult.PageCount - 1 Then
        '                        intMaxRowsOfPage = dtgResult.PageSize
        '                    Else
        '                        intMaxRowsOfPage = tblShowResult.Rows.Count - dtgResult.PageSize * dtgResult.CurrentPageIndex
        '                    End If
        '                End If
        '            End If
        '        End If


        '        btnUpdate.Visible = True

        '        ' Check null value
        '        btnUpdate.Attributes.Add("OnClick", "javascript:if (!CheckAllUpdate('dtgResult', 'chkSelectedID', " & intMaxRowsOfPage & ", '" & ddlLabel.Items(9).Text & "', '" & ddlLabel.Items(6).Text & "')) {return false;}")

        '        tblSearchResult.Dispose()
        '        tblSearchResult = Nothing
        '        tblShowResult.Dispose()
        '        tblShowResult = Nothing
        '    Else
        '            dtgResult.Visible = False
        '            btnUpdate.Visible = False
        '    End If
        'End Sub

        ' Event: btnUpdate_Click
        Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Dim intRetval As Integer
            Dim dtgItem As GridDataItem
            Dim chkSelected As HtmlInputCheckBox
            Dim strSelectedIDs As String = ""
            Dim lblLastIssuedDate As Label ' ngay cap
            Dim lastIssuedDateValue As DateTime ' value ngay cap
            Dim lblValidDate As Label ' ngay hieu luc
            Dim validDateValue As DateTime 'value ngay hieu luc
            Dim lblExpiredDate As Label ' ngay het han
            Dim expiredDateValue As DateTime 'value ngay het han
            Dim intCheck As Integer = 0
            For Each dtgItem In dtgResult.Items ' Get Selected Patron
                chkSelected = dtgItem.FindControl("chkSelectedID")
                If chkSelected.Checked Then
                    strSelectedIDs = strSelectedIDs & CType(dtgItem.FindControl("lblID"), Label).Text & ","
                End If
            Next
            If txtNewDateValue.Text <> "" Then
                Dim newDateValue = DateTime.ParseExact(txtNewDateValue.Text, "dd/MM/yyyy",
                System.Globalization.DateTimeFormatInfo.InvariantInfo)
                For Each dtgItem In dtgResult.Items ' Get Selected Patron
                    chkSelected = dtgItem.FindControl("chkSelectedID")
                    If chkSelected.Checked Then
                        ' Get value selected ddlFieldName7
                        Dim selection = ddlFieldName7.SelectedValue
                        lblLastIssuedDate = dtgItem.FindControl("lblLastIssuedDate")
                        lblExpiredDate = dtgItem.FindControl("lblExpiredDate")
                        lblValidDate = dtgItem.FindControl("lblValidDate")
                        If lblLastIssuedDate.Text = "" Then
                            lastIssuedDateValue = DateTime.Parse("01/01/1900")

                        Else
                            lastIssuedDateValue = DateTime.ParseExact(lblLastIssuedDate.Text, "dd/MM/yyyy",
            System.Globalization.DateTimeFormatInfo.InvariantInfo)
                        End If
                        If lblValidDate.Text = "" Then
                            validDateValue = DateTime.Parse("01/01/3000")
                        Else
                            validDateValue = DateTime.ParseExact(lblValidDate.Text, "dd/MM/yyyy",
            System.Globalization.DateTimeFormatInfo.InvariantInfo)
                        End If
                        If lblExpiredDate.Text = "" Then
                            expiredDateValue = DateTime.Parse("01/01/3000")
                        Else
                            expiredDateValue = DateTime.ParseExact(lblExpiredDate.Text, "dd/MM/yyyy",
            System.Globalization.DateTimeFormatInfo.InvariantInfo)
                        End If
                        If selection = 2 Then ' update ngay hieu luc
                            If lastIssuedDateValue > newDateValue Or newDateValue >= expiredDateValue Then
                                intCheck += 1
                            End If
                        ElseIf selection = 3 Then 'update Ngày hết hạn thẻ
                            If newDateValue <= validDateValue Then
                                intCheck += 1
                            End If
                        End If
                    End If
                Next
            End If

            If intCheck < 1 Then
                ' Get select id
                If Not strSelectedIDs = "" Then ' Selected Patron
                    strSelectedIDs = Left(strSelectedIDs, strSelectedIDs.Length - 1)
                    objBPC.PatronIDs = strSelectedIDs
                    objBPC.TextFieldIndex = ddlFieldName8.SelectedItem.Value
                    If Not Trim(txtNewTextValue.Text) = "" Then
                        objBPC.NewTextValue = Trim(txtNewTextValue.Text)
                    End If

                    objBPC.DateFieldIndex = ddlFieldName7.SelectedItem.Value
                    If Not Trim(txtNewDateValue.Text) = "" Then
                        objBPC.NewDateValue = Trim(txtNewDateValue.Text)
                    End If
                    Dim strSQL As String
                    Dim tblTemp As DataTable
                    Dim arrIDs() As String
                    If ddlFieldName8.SelectedItem.Value = 1 Then
                        If Not Trim(txtNewTextValue.Text) = "" Then
                            strSQL = "SELECT * FROM Cir_tblPatron WHERE UPPER(CODE)='" & txtNewTextValue.Text.ToUpper & "'"
                            objBCDBS.SQLStatement = strSQL
                            tblTemp = objBCDBS.RetrieveItemInfor
                            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                                Page.RegisterClientScriptBlock("UnSuccess", "<script language = 'javascript'>alert('" & ddlLabel.Items(16).Text & "')</script>")
                                Exit Sub
                            Else
                                arrIDs = strSelectedIDs.Split(",")
                                If arrIDs.Length > 1 Then
                                    Page.RegisterClientScriptBlock("UnSuccess", "<script language = 'javascript'>alert('" & ddlLabel.Items(17).Text & "')</script>")
                                    Exit Sub
                                End If
                            End If
                        End If
                    End If
                    objBPC.OptionFieldIndex = ddlFieldName9.SelectedItem.Value
                    objBPC.NewOptionID = ddlOptionFieldValue3.SelectedItem.Value
                    intRetval = objBPC.UpdateBatchPatrons
                    ' Check error
                    Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPC.ErrorMsg, ddlLabel.Items(0).Text, objBPC.ErrorCode)


                    If intRetval > 0 Then
                        Page.RegisterClientScriptBlock("UpdateSuccess", "<script language = 'javascript'>alert('" & ddlLabel.Items(8).Text & "')</script>")
                        ' WriteLog
                        Call WriteLog(28, ddlLabel.Items(3).Text & " " & strSelectedIDs, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                    Else
                        If InStr(strSelectedIDs, ",") > 0 Then
                            Page.RegisterClientScriptBlock("UpdateFail1", "<script language = 'javascript'>alert('" & ddlLabel.Items(7).Text & "')</script>")
                        Else
                            Page.RegisterClientScriptBlock("UpdateFail2", "<script language = 'javascript'>alert('" & ddlLabel.Items(7).Text & "')</script>")
                        End If
                    End If

                    'Call GridDisplay(CType(Session("strPatronIDs"), Object)) ' Refresh DataGrid
                    Call GridDisplay(CType(Session("strPatronIDs"), Object), Session("strSQLIDs"))
                    dtgResult.Rebind()
                End If
            Else
                If intCheck > 0 AndAlso ddlFieldName7.SelectedValue = 2 Then
                    Page.RegisterClientScriptBlock("UpdateFail2", "<script language = 'javascript'>alert('Ngày hiệu lực không hợp lệ')</script>")
                End If
                If intCheck > 0 AndAlso ddlFieldName7.SelectedValue = 3 Then
                    Page.RegisterClientScriptBlock("UpdateFail2", "<script language = 'javascript'>alert('Ngày hết hạn thẻ không hợp lệ')</script>")
                End If
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
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBPC Is Nothing Then
                    objBPC.Dispose(True)
                    objBPC = Nothing
                End If
                If Not objBF Is Nothing Then
                    objBF.Dispose(True)
                    objBF = Nothing
                End If
                If Not objBC Is Nothing Then
                    objBC.Dispose(True)
                    objBC = Nothing
                End If
                If Not objBED Is Nothing Then
                    objBED.Dispose(True)
                    objBED = Nothing
                End If
                If Not objBO Is Nothing Then
                    objBO.Dispose(True)
                    objBO = Nothing
                End If
                If Not objBE Is Nothing Then
                    objBE.Dispose(True)
                    objBE = Nothing
                End If
                If Not objBP Is Nothing Then
                    objBP.Dispose(True)
                    objBP = Nothing
                End If
                If Not objBPG Is Nothing Then
                    objBPG.Dispose(True)
                    objBPG = Nothing
                End If
                If Not objBPT Is Nothing Then
                    objBPT.Dispose(True)
                    objBPT = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        Public Function NumberOfRecord() As Integer Implements IUCNumberOfRecord.NumberOfRecord
            Return 25
        End Function
    End Class
End Namespace
