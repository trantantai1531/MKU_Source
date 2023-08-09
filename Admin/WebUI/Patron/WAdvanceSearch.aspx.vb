Imports eMicLibAdmin.BusinessRules.Patron
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WAdvanceSearch
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

        ' Declare variables
        Private objBPC As New clsBPatronCollection
        Private objBF As New clsBFaculty
        Private objBC As New clsBCollege
        Private objBED As New clsBEducation
        Private objBO As New clsBOccupation
        Private objBE As New clsBEthnic
        Private objBP As New clsBProvince
        Private objBPG As New clsBPatronGroup
        Private objBPT As New clsBPatron

        ' Page_Load method
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If Not IsPostBack Then
                Call LoadData(1, 5) ' Default
                Call LoadData(1, 6) ' Default
            End If
            Call LoadBackData()
        End Sub

        ' Method: Initialize
        Private Sub Initialize()
            ' Init objBPC object
            objBPC.DBServer = Session("DBServer")
            objBPC.ConnectionString = Session("ConnectionString")
            objBPC.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPC.initialize()

            ' Init objBF object
            objBF.DBServer = Session("DBServer")
            objBF.ConnectionString = Session("ConnectionString")
            objBF.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBF.Initialize()

            ' Init objBC object
            objBC.DBServer = Session("DBServer")
            objBC.ConnectionString = Session("ConnectionString")
            objBC.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBC.Initialize()

            ' Init objBED object
            objBED.DBServer = Session("DBServer")
            objBED.ConnectionString = Session("ConnectionString")
            objBED.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBED.Initialize()

            ' Init objBO object
            objBO.DBServer = Session("DBServer")
            objBO.ConnectionString = Session("ConnectionString")
            objBO.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBO.Initialize()

            ' Init objBE object
            objBE.DBServer = Session("DBServer")
            objBE.ConnectionString = Session("ConnectionString")
            objBE.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBE.Initialize()

            ' Init objBP object
            objBP.DBServer = Session("DBServer")
            objBP.ConnectionString = Session("ConnectionString")
            objBP.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBP.Initialize()

            ' Init objBPG object
            objBPG.DBServer = Session("DBServer")
            objBPG.ConnectionString = Session("ConnectionString")
            objBPG.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPG.Initialize()

            ' Init objBPT object
            objBPT.DBServer = Session("DBServer")
            objBPT.ConnectionString = Session("ConnectionString")
            objBPT.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPT.Initialize()
        End Sub

        ' CheckFormPermission method
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            If Not CheckPemission(45) Then
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub

        ' Write log
        Private Sub WriteFormLog()
            Call WriteLog(27, ddlLabel.Items(5).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
        End Sub

        ' Method: BindJS
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WAdvanceSearchJs", "<script language = 'javascript' src = 'js/WAdvanceSearch.js'></script>")

            ddlFieldName5.Attributes.Add("OnChange", "document.forms[0].txtHidden1.value = ''; LoadBack(this.value, 1, '" & ddlLabel.Items(4).Text & "');")
            ddlFieldName6.Attributes.Add("OnChange", "document.forms[0].txtHidden2.value = ''; LoadBack(this.value, 2, '" & ddlLabel.Items(4).Text & "');")
            ddlOptionFieldValue1.Attributes.Add("OnChange", "document.forms[0].txtHidden1.value = this.value + '#' + this.selectedIndex;")
            ddlOptionFieldValue2.Attributes.Add("OnChange", "document.forms[0].txtHidden2.value = this.value + '#' + this.selectedIndex;")

            btnSetFieldShow.Attributes.Add("OnClick", "SetFieldShow('" & ddlLabel.Items(7).Text & "'); return false;")
            btnReset.Attributes.Add("OnClick", "ClearAll(); document.forms[0].txtFieldValue1.focus(); return false;")
            btnSearchSimp.Attributes.Add("OnClick", "self.location.href='WSimpleSearch.aspx';return false;")

            Me.RegisterCalendar("..")
            SetOnclickCalendar(lnkFromDate1, txtFieldValueFrom1, ddlLabel.Items(6).Text)
            SetOnclickCalendar(lnkFromDate2, txtFieldValueFrom2, ddlLabel.Items(6).Text)
            SetOnclickCalendar(lnkToDate1, txtFieldValueTo1, ddlLabel.Items(6).Text)
            SetOnclickCalendar(lnkToDate2, txtFieldValueTo2, ddlLabel.Items(6).Text)

            txtFieldValueFrom1.Attributes.Add("onChange", "if (!CheckDate(" & txtFieldValueFrom1.ClientID & ",'dd/mm/yyyy','" & ddlLabel.Items(6).Text & "')){return false;}")
            txtFieldValueFrom2.Attributes.Add("onChange", "if (!CheckDate(" & txtFieldValueFrom2.ClientID & ",'dd/mm/yyyy','" & ddlLabel.Items(6).Text & "')){return false;}")
            txtFieldValueTo1.Attributes.Add("onChange", "if (!CheckDate(" & txtFieldValueTo1.ClientID & ",'dd/mm/yyyy','" & ddlLabel.Items(6).Text & "')){return false;}")
            txtFieldValueTo2.Attributes.Add("onChange", "if (!CheckDate(" & txtFieldValueTo2.ClientID & ",'dd/mm/yyyy','" & ddlLabel.Items(6).Text & "')){return false;}")
        End Sub

        ' LoadData method
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
                        strValueField = "ID"
                        strTextField = "FC"
                    Case 2 ' College
                        tblTemp = objBC.GetCollege
                        strValueField = "ID"
                        strTextField = "College"
                    Case 3 ' Education
                        tblTemp = objBED.GetEducation
                        strValueField = "ID"
                        strTextField = "EducationLevel"
                    Case 4 ' Occupation
                        tblTemp = objBO.GetOccupation
                        strValueField = "ID"
                        strTextField = "Occupation"
                    Case 5 ' Ethnic
                        tblTemp = objBE.GetEthnic
                        strValueField = "ID"
                        strTextField = "Ethnic"
                    Case 6 ' Province
                        tblTemp = objBP.GetProvince
                        strValueField = "ID"
                        strTextField = "Province"
                    Case 7 ' PatronGroup
                        tblTemp = objBPG.GetPatronGroup
                        strValueField = "ID"
                        strTextField = "Name"
                    Case Else ' Sex
                        Dim ArrSexTextField() As String = Split(ddlLabel.Items(3).Text, ",")
                        Dim ArrSexValueField() As Byte = {0, 1, 2}
                        tblTemp = CreateTable(ArrSexTextField, ArrSexValueField)
                        strValueField = "ValueField"
                        strTextField = "TextField"
                End Select
            Catch ex As Exception
                Call WriteErrorMssg(ex.Message)
            End Try

            tblTemp = InsertOneRow(tblTemp, ddlLabel.Items(4).Text)
            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, ErrorMsg, ddlLabel.Items(1).Text, ErrorCode)

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
            tblTemp.Clear()
            tblTemp.Dispose()
            tblTemp = Nothing
        End Sub

        ' This method used to Init 3 javascript Array and load back data into suite dropdonwlist
        Private Sub LoadBackData()
            Dim intCount As Integer
            Dim intMax As Integer
            Dim strTempo As String = ""
            Dim strMakeCombo As String = ""
            Dim tblTemp As New DataTable
            Try
                tblTemp = objBPC.RetrieveDicTable
                intMax = tblTemp.Rows.Count + 3
                strTempo = strTempo & "ArrOptionIndex = new Array(" & intMax & ");"
                strTempo = strTempo & "ArrValue = new Array(" & intMax & ");"
                strTempo = strTempo & "ArrText = new Array(" & intMax & ");"
                ' OPTIONINDEX, Selecteditem.Value, FACULTY AS SELECTEDTEXT
                For intCount = 0 To intMax - 4
                    strTempo = strTempo & "ArrOptionIndex[" & intCount & "] = " & tblTemp.Rows(intCount).Item("OPTIONINDEX") & ";"
                    strTempo = strTempo & "ArrValue[" & intCount & "] = " & tblTemp.Rows(intCount).Item("SELECTEDVALUE") & ";"
                    strTempo = strTempo & "ArrText[" & intCount & "] = '" & Replace(tblTemp.Rows(intCount).Item("SELECTEDTEXT"), "'", "\'") & "';"
                Next
                ' ADD SEX
                strTempo = strTempo & "ArrOptionIndex[" & intCount + 1 & "] = 8;"
                strTempo = strTempo & "ArrValue[" & intCount + 1 & "] = 0;"
                strTempo = strTempo & "ArrText[" & intCount + 1 & "] = '" & ddlLabel.Items(4).Text & "';"
                strTempo = strTempo & "ArrOptionIndex[" & intCount + 2 & "] = 8;"
                strTempo = strTempo & "ArrValue[" & intCount + 2 & "] = 1;"
                strTempo = strTempo & "ArrText[" & intCount + 2 & "] = '" & ddlLabel.Items(4).Text & "';"
                strTempo = strTempo & "ArrOptionIndex[" & intCount + 3 & "] = 8;"
                strTempo = strTempo & "ArrValue[" & intCount + 3 & "] = 2;"
                strTempo = strTempo & "ArrText[" & intCount + 3 & "] = '" & ddlLabel.Items(4).Text & "';"

                Page.RegisterClientScriptBlock("BindDataJs", "<script language = 'javascript'>" & strTempo & "</script>")
            Catch ex As Exception

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

        ' Search method
        Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            ' Text Field
            objBPC.FieldName(1) = ddlFieldName1.SelectedValue
            objBPC.FieldValue(1) = txtFieldValue1.Text
            objBPC.FieldName(2) = ddlFieldName2.SelectedValue
            objBPC.FieldValue(2) = txtFieldValue2.Text
            ' Date Field From
            objBPC.FieldNameDate(1) = ddlFieldName3.SelectedValue
            objBPC.FieldValueFrom(1) = txtFieldValueFrom1.Text
            objBPC.FieldNameDate(2) = ddlFieldName4.SelectedValue
            objBPC.FieldValueFrom(2) = txtFieldValueFrom2.Text
            ' Date To, Operator From
            objBPC.FieldValueTo(1) = txtFieldValueTo1.Text
            objBPC.FieldValueTo(2) = txtFieldValueTo2.Text
            objBPC.FieldOpeFrom(1) = ddlFieldOpeFrom1.SelectedValue
            objBPC.FieldOpeFrom(2) = ddlFieldOpeFrom2.SelectedValue
            ' Logic Operator
            objBPC.[Operator](1) = ddlOperator1.SelectedValue
            objBPC.[Operator](2) = ddlOperator2.SelectedValue
            objBPC.[Operator](3) = ddlOperator3.SelectedValue
            objBPC.[Operator](4) = ddlOperator4.SelectedValue
            objBPC.[Operator](5) = ddlOperator5.SelectedValue
            ' Other Field
            objBPC.FieldNameOther(1) = ddlFieldName5.SelectedValue
            objBPC.FieldValueOther(1) = ddlOptionFieldValue1.SelectedValue
            objBPC.FieldNameOther(2) = ddlFieldName6.SelectedValue
            objBPC.FieldValueOther(2) = ddlOptionFieldValue2.SelectedValue

            objBPC.OrderBy = ddlOrderBy.SelectedValue
            objBPC.SelectTop = ddlMaxRecord.SelectedValue
            objBPC.LibID = clsSession.GlbSite
            objBPC.TypeSearch = "ADVANCE"
            Session("PatronIDs") = Nothing
            Dim ArrRetID()
            ArrRetID = objBPC.Search
            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPC.ErrorMsg, ddlLabel.Items(1).Text, objBPC.ErrorCode)

            Session("PatronIDs") = ArrRetID
            Session("FieldShow") = Nothing
            Session("FieldShow") = txtFieldShow.Value
            Session("Pagesize") = Nothing
            Session("Pagesize") = txtPageSize.Value
            ' Write log
            Call WriteFormLog()

            If IsArray(ArrRetID) AndAlso Not ArrRetID(0) = -1 Then
                Select Case ddlDisplayMode.SelectedValue
                    Case 0 ' Document type
                        Response.Redirect("WSimpleSearchResultFrame.aspx")
                    Case 1 ' Table type
                        Response.Redirect("WSearchTableResult.aspx")
                End Select
            Else
                Page.RegisterClientScriptBlock("AlertJS", "<script language = 'javascript'>alert('" & ddlLabel.Items(8).Text.Trim & "');</script>")
            End If
        End Sub

        ' Page_Unload method
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
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
        End Sub
    End Class
End Namespace