' Class: WBatchPatronUpdate
' Puspose: Management delete batch patron
' Creator: Oanhtn
' CreatedDate: 21/01/2005
' Modification History:
'   + 23/08/2005: by Sondp: add method delete patron portrait on disk
Imports System.IO
Imports eMicLibAdmin.BusinessRules.Patron
Imports eMicLibAdmin.BusinessRules.Common
Imports Telerik.Web.UI

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WBatchPatronDelete
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
                Call LoadData(2, 6)
                btnDelete.Visible = True
            End If
            Call LoadBackData()
            lblViewDelLog.Visible = False
            hrfViewLog.Visible = False
            dgrViewDelLog.Visible = False
            btnDelete.Visible = False
        End Sub

        ' Method: CheckPermissionFrom
        Sub CheckPermissionFrom()
            If Not CheckPemission(51) Then
                btnDelete.Enabled = False
            End If
        End Sub

        ' Method: Initialize
        Private Sub Initialize()
            ' Initialize  objBCDBS  object
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.Initialize()

            ' Initialize  objBPC  object
            objBPC.DBServer = Session("DBServer")
            objBPC.ConnectionString = Session("ConnectionString")
            objBPC.InterfaceLanguage = Session("InterfaceLanguage")
            objBPC.initialize()

            ' Initialize  objBF  object
            objBF.DBServer = Session("DBServer")
            objBF.ConnectionString = Session("ConnectionString")
            objBF.InterfaceLanguage = Session("InterfaceLanguage")
            objBF.Initialize()

            ' Initialize  objBC  object
            objBC.DBServer = Session("DBServer")
            objBC.ConnectionString = Session("ConnectionString")
            objBC.InterfaceLanguage = Session("InterfaceLanguage")
            objBC.Initialize()

            ' Initialize  objBED  object
            objBED.DBServer = Session("DBServer")
            objBED.ConnectionString = Session("ConnectionString")
            objBED.InterfaceLanguage = Session("InterfaceLanguage")
            objBED.Initialize()

            ' Initialize  objBO  object
            objBO.DBServer = Session("DBServer")
            objBO.ConnectionString = Session("ConnectionString")
            objBO.InterfaceLanguage = Session("InterfaceLanguage")
            objBO.Initialize()

            ' Initialize  objBE  object
            objBE.DBServer = Session("DBServer")
            objBE.ConnectionString = Session("ConnectionString")
            objBE.InterfaceLanguage = Session("InterfaceLanguage")
            objBE.Initialize()

            ' Initialize  objBP  object
            objBP.DBServer = Session("DBServer")
            objBP.ConnectionString = Session("ConnectionString")
            objBP.InterfaceLanguage = Session("InterfaceLanguage")
            objBP.Initialize()

            ' Initialize  objBPG  object
            objBPG.DBServer = Session("DBServer")
            objBPG.ConnectionString = Session("ConnectionString")
            objBPG.InterfaceLanguage = Session("InterfaceLanguage")
            objBPG.Initialize()

            ' Initialize  objBPT  object
            objBPT.DBServer = Session("DBServer")
            objBPT.ConnectionString = Session("ConnectionString")
            objBPT.InterfaceLanguage = Session("InterfaceLanguage")
            objBPT.Initialize()

            dtgResult.PageSize = 50
        End Sub

        ' BindJS method
        Private Sub BindJS()
            ' Bind sub javascript commond
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WBatchPatronDeleteJs", "<script language = 'javascript' src='js/WBatchPatronDelete.js'></script>")

            ' Load data
            ddlFieldName5.Attributes.Add("OnChange", "javascript:document.forms[0].txtHidden1.value = ''; LoadBack(this.value, 1, '" & ddlLabel.Items(3).Text & "');")
            ddlFieldName6.Attributes.Add("OnChange", "javascript:document.forms[0].txtHidden2.value = ''; LoadBack(this.value, 2, '" & ddlLabel.Items(3).Text & "');")
            ddlOptionFieldValue1.Attributes.Add("OnChange", "document.forms[0].txtHidden1.value = this.value + '#' + this.selectedIndex;")
            ddlOptionFieldValue2.Attributes.Add("OnChange", "document.forms[0].txtHidden2.value = this.value + '#' + this.selectedIndex;")

            ' Check date or number
            txtFieldValueFrom1.Attributes.Add("OnChange", "return CheckDate(this,'" & Session("DateFormat") & "','" & ddlLabel.Items(9).Text & " (" & Session("DateFormat") & ")');")
            txtFieldValueFrom1.ToolTip = Session("DateFormat")
            txtFieldValueTo1.Attributes.Add("OnChange", "return CheckDate(this,'" & Session("DateFormat") & "','" & ddlLabel.Items(9).Text & " (" & Session("DateFormat") & ")');")
            txtFieldValueTo1.ToolTip = Session("DateFormat")
            txtFieldValueFrom2.Attributes.Add("OnChange", "return CheckDate(this,'" & Session("DateFormat") & "','" & ddlLabel.Items(9).Text & " (" & Session("DateFormat") & ")');")
            txtFieldValueFrom2.ToolTip = Session("DateFormat")
            txtFieldValueTo2.Attributes.Add("OnChange", "return CheckDate(this,'" & Session("DateFormat") & "','" & ddlLabel.Items(9).Text & " (" & Session("DateFormat") & ")');")
            txtFieldValueTo2.ToolTip = Session("DateFormat")

            ' Links
            Me.RegisterCalendar("..")
            SetOnclickCalendar(lnkFromDate1, txtFieldValueFrom1, ddlLabel.Items(9).Text)
            SetOnclickCalendar(lnkFromDate2, txtFieldValueFrom2, ddlLabel.Items(9).Text)
            SetOnclickCalendar(lnkToDate1, txtFieldValueTo1, ddlLabel.Items(9).Text)
            SetOnclickCalendar(lnkToDate2, txtFieldValueTo2, ddlLabel.Items(9).Text)

            btnReset.Attributes.Add("OnClick", "ClearAll(); return false;")

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
                    ' ADD SEX
                    strTempo = strTempo & "ArrOptionIndex[" & intCount + 1 & "] = 8;" & Chr(10)
                    strTempo = strTempo & "ArrValue[" & intCount + 1 & "] = 0;" & Chr(10)
                    strTempo = strTempo & "ArrText[" & intCount + 1 & "] = '" & ddlLabel.Items(8).Text & "';" & Chr(10)
                    strTempo = strTempo & "ArrOptionIndex[" & intCount + 2 & "] = 8;" & Chr(10)
                    strTempo = strTempo & "ArrValue[" & intCount + 2 & "] = 1;" & Chr(10)
                    strTempo = strTempo & "ArrText[" & intCount + 2 & "] = '" & ddlLabel.Items(6).Text & "';" & Chr(10)
                    strTempo = strTempo & "ArrOptionIndex[" & intCount + 3 & "] = 8;" & Chr(10)
                    strTempo = strTempo & "ArrValue[" & intCount + 3 & "] = 2;" & Chr(10)
                    strTempo = strTempo & "ArrText[" & intCount + 3 & "] = '" & ddlLabel.Items(7).Text & "';" & Chr(10)

                    Page.RegisterClientScriptBlock("LoadJS", "<script language = 'javascript'>" & strTempo & "</script>")
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
            ' Release object
            tblTemp.Dispose()
            tblTemp = Nothing
        End Sub

        ' Method: LoadData
        Private Sub LoadData(ByVal bytOption As Byte, ByVal bytIndex As Byte)
            Dim tblTemp As New DataTable
            Dim strValueField As String
            Dim strTextField As String
            Try
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
                    Case Else 'Sex
                        Dim ArrSexTextField() As String = {ddlLabel.Items(8).Text, ddlLabel.Items(6).Text, ddlLabel.Items(7).Text}
                        Dim ArrSexValueField() As Byte = {2, 0, 1}
                        tblTemp = objBCDBS.CreateTable(ArrSexTextField, ArrSexValueField)
                        strValueField = "ValueField"
                        strTextField = "TextField"
                End Select
            Catch ex As Exception

            End Try
            tblTemp = objBCDBS.InsertOneRow(tblTemp, ddlLabel.Items(3).Text)
            Try
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
                End Select
            Catch ex As Exception
            Finally
                tblTemp.Clear()
                tblTemp.Dispose()
                tblTemp = Nothing
            End Try
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

                dtgResult.Visible = False

            Else

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
        ' Popurse: This method used to display All of patron have been search
        Private Sub GridDisplay(ByVal objRetValue As Object, ByVal strSQLForming As String)
            If Not objRetValue Is Nothing Then
                Me.ShowWaitingOnPage(ddlLabel.Items(10).Text & " " & CStr(UBound(objRetValue) + 1) & " " & ddlLabel.Items(11).Text, "..")
                Dim tblSearchResult As New DataTable
                Dim tblShowResult As New DataTable
                Dim dtrTmp As DataRow
                Dim intCounter As Integer
                Dim strIDs As String = ""
                Dim intMaxRowsOfPage As Integer
                ' Retrieve Datatable of Patron's infor by IDs
                If strSQLForming <> "" And ddlMaxRecord.SelectedValue = 0 Then
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

                If Not tblSearchResult Is Nothing Then
                    If tblSearchResult.Rows.Count > 0 Then
                        For intIndex = 0 To tblSearchResult.Rows.Count - 1
                            tblSearchResult.Rows(intIndex).Item("Rownumber") = intIndex + 1
                        Next
                    End If
                End If
                dtgResult.Visible = False
                btnDelete.Visible = False
                If Not tblShowResult Is Nothing Then
                    If tblShowResult.Rows.Count > 0 Then
                        dtgResult.Visible = True
                        btnDelete.Visible = True
                        dtgResult.DataSource = tblShowResult
                        'dtgResult.DataBind()
                      
                    Else
                        btnDelete.Visible = False
                    End If
                End If

                'btnDelete.Visible = True

                ' Check null value
                btnDelete.Attributes.Add("OnClick", "javascript:if (!CheckOptionsNullByCssClass('ckb-value', 'cbkOption', 2, 50, '" & ddlLabel.Items(5).Text & "')) {return false;} else { return confirm('Bạn có chắc muốn xóa ?'); }")


                tblSearchResult.Dispose()
                tblSearchResult = Nothing
                tblShowResult.Dispose()
                tblShowResult = Nothing
                Me.ShowWaitingOnPage("", "", True)
                '    Catch ex As Exception
                'dtgResult.Visible = False
                'btnDelete.Visible = False
                'End Try
            Else
                dtgResult.Visible = False
                btnDelete.Visible = False
            End If

        End Sub
       
        ' Event: btnDelete_Click
        Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            Dim dtgItem As GridDataItem
            Dim chkSelected As HtmlInputCheckBox
            Dim strSelectedIDs As String = ""
            Dim tblDeleteResult As New DataTable
            Dim objFile As File
            Dim inti As Integer
            For Each dtgItem In dtgResult.Items ' Get Selected Patron
                chkSelected = dtgItem.FindControl("chkSelectedID")
                If chkSelected.Checked Then
                    strSelectedIDs = strSelectedIDs & CType(dtgItem.FindControl("lblID"), Label).Text & ","
                End If
            Next
            Try
                If Not strSelectedIDs = "" Then
                    strSelectedIDs = Left(strSelectedIDs, strSelectedIDs.Length - 1)
                    ' Before delete patron will delete their portrait
                    objBPC.PatronIDs = strSelectedIDs
                    tblDeleteResult = objBPC.GetPortraitPatronDel
                    If Not tblDeleteResult Is Nothing Then
                        If tblDeleteResult.Rows.Count > 0 Then
                            For inti = 0 To tblDeleteResult.Rows.Count - 1
                                If objFile.Exists(Server.MapPath("../Images/Card/" & tblDeleteResult.Rows(inti).Item("Portrait"))) = True Then
                                    objFile.Delete(Server.MapPath("../Images/Card/" & tblDeleteResult.Rows(inti).Item("Portrait")))
                                End If
                            Next
                        End If
                    End If
                End If
                tblDeleteResult = objBPC.DeletePatrons() ' Delete Batch Patron(s)
                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPC.ErrorMsg, ddlLabel.Items(0).Text, objBPC.ErrorCode)

                If Not tblDeleteResult Is Nothing AndAlso tblDeleteResult.Rows.Count > 0 Then
                    ' WriteLog
                    Call WriteLog(30, ddlLabel.Items(3).Text & " " & strSelectedIDs, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                    lblViewDelLog.Visible = True
                    dgrViewDelLog.Visible = True
                    dgrViewDelLog.DataSource = tblDeleteResult
                    'dgrViewDelLog
                End If

                Page.RegisterClientScriptBlock("PatronAlert", "<script language = 'javascript'>alert('Xóa thành công')</script>")
            Catch ex As Exception ' Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, ex.Message.Trim, ddlLabel.Items(0).Text, 0)
            Finally
                If Not objFile Is Nothing Then
                    objFile = Nothing
                End If
                'Call GridDisplay(CType(Session("strPatronIDs"), Object)) ' Refresh DataGrid
                Call GridDisplay(CType(Session("strPatronIDs"), Object), Session("strSQLIDs"))
                dtgResult.Rebind()

            End Try
        End Sub

        ' Event: btnSearch_Click
        Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            Dim ArrOptionValue() As String
            Dim strSQL As String
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
            Dim strArrResult() As Object
            objBPC.LibID = clsSession.GlbSite
            strArrResult = objBPC.Search()

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPC.ErrorMsg, ddlLabel.Items(0).Text, objBPC.ErrorCode)

            strSQL = objBPC.SQL
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
                Page.RegisterClientScriptBlock("PatronNotFoundJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(4).Text & "')</script>")
                dtgResult.Visible = False
                btnDelete.Visible = False
            Else
                Session("strPatronIDs") = strArrResult
                Session("strSQLIDs") = strSQL
                Call GridDisplay(strArrResult, strSQL) ' Display data
                dtgResult.Rebind()
            End If

            ' Set default value for dropdownload
            'Call LoadData(1, 5)
            ' Call LoadData(1, 6)
            'btnDelete.Visible = True
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