' Class: WMarcFieldsDefault
' Purpose: Set default value for some fields
' Creator: KhoaNA
' CreatedDate: 16/03/2004
' Modification Historiy
'   - 22/02/2005 by Tuanhv: Repaid form

Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WMarcFieldsDefault
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Button1 As System.Web.UI.WebControls.Button


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Private variable
        Private strSeparate As String = ":::"
        Private strIDs As String
        Private strTmpFieldCode As String
        Private strTmpIndicator As String
        Private strTmpFieldValue As String
        Private strCellText As String

        Dim tblTable As DataTable
        Dim dvDefaultView As DataView
        Dim strPrefix As String = ""

        ' Private objBValidate As New clsBCataDefault
        Private objBValidate As New clsBValidate
        Private objBField As New clsBField

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim tblFields As DataTable
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call DoAction("", "", "", "") ' Show in the first time
            End If
            If Not txtFieldCode.Text = "" Then
                objBField.FieldCode = txtFieldCode.Text.Trim
                tblFields = objBField.GetProperties()
                Call WriteErrorMssg(ddlLabel.Items(6).Text, objBField.ErrorMsg, ddlLabel.Items(5).Text, objBField.ErrorCode)
                If Not tblFields Is Nothing And tblFields.Rows.Count > 0 Then
                    txtFieldName.Text = tblFields.Rows(0).Item("VietFieldName").ToString.Trim
                End If
            End If
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(1) Then
                Call WriteErrorMssg(ddlLabel.Items(8).Text.Trim)
            End If
        End Sub

        ' BindJS method
        ' Purpose: include all neccessary javascript functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")

            txtFieldName.Attributes.Add("onfocus", "this.blur();")
            txtFieldCode.Attributes.Add("onchange", "parent.Hiddenbase.location.href='WMarcFieldsDefaultHidden.aspx?FieldCode=' + this.value ; document.forms[0].txtIndicator.focus(); return false;")
            txtFieldValue.Attributes.Add("onKeyDown", "if(event.keyCode == 13 || event.which == 13 ){ document.forms[0].action='WMarcFieldsDefault.aspx'; document.forms[0].submit();}")
            btnUpdate.Attributes.Add("onclick", "if (CheckNull(document.forms[0].txtFieldValue)) {document.forms[0].txtFieldValue.focus(); alert('" & ddlLabel.Items(4).Text & "'); return false;}")

            lnkLabel.NavigateUrl = "javascript:OpenWindow('WFindFieldByName.aspx','',520,350,50,50)"
        End Sub

        ' Method: CancelAction
        Sub CancelAction()
            grdDefault.EditItemIndex = -1

            ' Assign value from Sessions to variables
            strIDs = Session(strPrefix & "IDs")
            strTmpFieldCode = Session(strPrefix & "FieldCode")
            strTmpIndicator = Session(strPrefix & "Indicator")
            strTmpFieldValue = Session(strPrefix & "FieldValue")

            objBValidate.Action = "VIEW"
            tblTable = objBValidate.MakeDataTable(strTmpFieldCode, strTmpIndicator, strTmpFieldValue, strIDs)

            dvDefaultView = tblTable.DefaultView
            dvDefaultView.Sort = "FieldCode"
            grdDefault.DataSource = dvDefaultView
            grdDefault.DataBind()
        End Sub

        ' Initialize Method
        ' Popurse: Init all object using in form
        Private Sub Initialize()
            If IsNumeric(Request("Authority")) Then
                Session("IsAuthority") = CInt(Request("Authority"))
            Else
                If Not IsNumeric(Session("IsAuthority")) Then
                    Session("IsAuthority") = 0
                End If
            End If

            If Session("IsAuthority") = 1 Then
                strPrefix = "a"
            End If

            ' Init objBValidate object
            objBValidate.IsAuthority = Session("IsAuthority")
            objBValidate.ConnectionString = Session("ConnectionString")
            objBValidate.InterfaceLanguage = Session("InterfaceLanguage")
            objBValidate.DBServer = Session("DBServer")
            objBValidate.Separate = strSeparate
            objBValidate.Initialize()

            ' Init objBField object
            objBField.IsAuthority = Session("IsAuthority")
            objBField.ConnectionString = Session("ConnectionString")
            objBField.InterfaceLanguage = Session("InterfaceLanguage")
            objBField.DBServer = Session("DBServer")
            objBField.Initialize()
        End Sub

        ' InsertSession method
        ' Purpose: Get content for field name, field value
        Sub InsertSession()
            Dim intRepeatable As Integer
            Dim tblFields As DataTable

            If Not txtFieldCode.Text = "" Then
                objBField.FieldCode = CStr(txtFieldCode.Text)
                tblFields = objBField.GetProperties()
                Page.RegisterClientScriptBlock("SuccessJs", "<script language='javascript'>alert('" & ddlLabel.Items(9).Text & "');</script>")

                If Not tblFields Is Nothing Then
                    If tblFields.Rows.Count > 0 Then
                        If tblFields.Rows(0).Item("Repeatable") Or tblFields.Rows(0).Item("Repeatable") = "1" Then
                            intRepeatable = 1
                        Else
                            intRepeatable = 0
                        End If
                        If Not Session(strPrefix & "AllFields") Is Nothing Then
                            If Not InStr("," & Session(strPrefix & "AllFields") + ",", "," & Trim(txtFieldCode.Text) & ",") > 0 Then
                                Session(strPrefix & "AllFields") = Session(strPrefix & "AllFields") & Trim(txtFieldCode.Text) & ","
                                If Not tblFields.Rows(0).Item("Indicators") Is Nothing Or Not tblFields.Rows(0).Item("VietIndicators") Is Nothing Then
                                    Session(strPrefix & Trim(txtFieldCode.Text)) = txtIndicator.Text & "::" & txtFieldValue.Text
                                Else
                                    Session(strPrefix & Trim(txtFieldCode.Text)) = txtFieldValue.Text
                                End If
                            Else
                                If intRepeatable = 0 Then
                                    If Not tblFields.Rows(0).Item("Indicators") Is Nothing Or Not tblFields.Rows(0).Item("VietIndicators") Is Nothing Then
                                        Session(strPrefix & Trim(txtFieldCode.Text)) = txtIndicator.Text & "::" & txtFieldValue.Text
                                    Else
                                        Session(strPrefix & Trim(txtFieldCode.Text)) = txtFieldValue.Text
                                    End If
                                Else
                                    If Not tblFields.Rows(0).Item("Indicators") Is Nothing Or Not tblFields.Rows(0).Item("VietIndicators") Is Nothing Then
                                        Session(strPrefix & Trim(txtFieldCode.Text)) = Session(strPrefix & Trim(txtFieldCode.Text)) & "$&" & txtIndicator.Text & "::" & txtFieldValue.Text
                                    Else
                                        Session(strPrefix & Trim(txtFieldCode.Text)) = Session(strPrefix & Trim(txtFieldCode.Text)) & "$&" & txtFieldValue.Text
                                    End If
                                End If
                            End If
                        Else
                            If intRepeatable = 0 Then
                                If Not tblFields.Rows(0).Item("Indicators") Is Nothing Or Not tblFields.Rows(0).Item("VietIndicators") Is Nothing Then
                                    Session(strPrefix & Trim(txtFieldCode.Text)) = txtIndicator.Text & "::" & txtFieldValue.Text
                                Else
                                    Session(strPrefix & Trim(txtFieldCode.Text)) = txtFieldValue.Text
                                End If
                            Else
                                If Not tblFields.Rows(0).Item("Indicators") Is Nothing Or Not tblFields.Rows(0).Item("VietIndicators") Is Nothing Then
                                    Session(strPrefix & Trim(txtFieldCode.Text)) = Session(strPrefix & Trim(txtFieldCode.Text)) & "$&" & txtIndicator.Text & "::" & txtFieldValue.Text
                                Else
                                    Session(strPrefix & Trim(txtFieldCode.Text)) = Session(strPrefix & Trim(txtFieldCode.Text)) & "$&" & txtFieldValue.Text
                                End If
                            End If
                            Session(strPrefix & "AllFields") = Trim(txtFieldCode.Text) & ","
                        End If
                    End If
                End If
            End If
            txtFieldCode.Text = ""
            txtIndicator.Text = ""
            txtFieldValue.Text = ""
        End Sub

        ' btnUpdate_Click event
        ' Purpose: update default value for the selected field
        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Dim intDoAction As Integer
            intDoAction = DoAction(txtFieldCode.Text, txtIndicator.Text, txtFieldValue.Text, "ADD")
            If intDoAction = 1 Then
                Exit Sub
            Else
                Call InsertSession()
            End If
        End Sub

        ' DoAction method
        Private Function DoAction(ByVal strFieldCode As String, ByVal strIndicator As String, ByVal strFieldValue As String, ByVal strAction As String) As Integer
            Dim strJs As String = ""

            DoAction = 0
            hidError.Value = DoAction

            objBValidate.FieldCode = strFieldCode
            objBValidate.Indicator = strIndicator
            objBValidate.FieldValue = strFieldValue

            ' Check field's indicator
            If objBValidate.CheckIndicators(strIndicator) > 0 Then
                Select Case objBValidate.CheckIndicators(strIndicator)
                    Case 1
                        strJs = ddlLabel.Items(1).Text
                    Case 2
                        strJs = ddlLabel.Items(2).Text
                    Case 3
                        strJs = ddlLabel.Items(3).Text
                End Select
                'Page.RegisterClientScriptBlock("CheckIndicator", "<script language='javascript'>alert('" & strJs & "');document.forms[0].txtIndicator.txtIndicator.value='';document.forms[0].txtIndicator.focus();</script>")
                Page.RegisterClientScriptBlock("CheckIndicator", "<script language='javascript'>alert('" & strJs & "');</script>")
                txtIndicator.Text = ""
                DoAction = 1
                hidError.Value = DoAction
                Call CancelAction()
                Exit Function
            End If

            ' Check field's value
            strJs = ""
            strJs = objBValidate.CheckTag(ddlLabel.Items(7).Text)
            If (Len(Trim(strJs)) > 0) Then
                'If Trim(txtFieldValue.Text) <> "" Then
                Page.RegisterClientScriptBlock("CheckValue", "<script language='javascript'>alert('" & strJs & "');</script>")
                'End If
                DoAction = 1
                hidError.Value = DoAction
                Call CancelAction()
                Exit Function
            End If

            ' Assign value from Sessions to variables
            If Not Session("IDs") Is Nothing AndAlso IsArray(Session("IDs")) Then
                Session("IDs") = Nothing
            End If
            strIDs = Session(strPrefix & "IDs") & ""
            strTmpFieldCode = Session(strPrefix & "FieldCode")
            strTmpIndicator = Session(strPrefix & "Indicator")
            strTmpFieldValue = Session(strPrefix & "FieldValue")
            objBValidate.FieldCode = strFieldCode
            objBValidate.Indicator = strIndicator
            objBValidate.FieldValue = strFieldValue

            objBValidate.Repeat = objBValidate.Repeat
            objBValidate.Separate = strSeparate
            objBValidate.Action = strAction

            tblTable = objBValidate.MakeDataTable(strTmpFieldCode, strTmpIndicator, strTmpFieldValue, strIDs)

            If Not tblTable Is Nothing Then
                If tblTable.Rows.Count > 0 Then
                    grdDefault.Visible = True
                    lblTitle5.Visible = True
                    dvDefaultView = tblTable.DefaultView

                    dvDefaultView.Sort = "FieldCode"
                    grdDefault.DataSource = dvDefaultView
                    grdDefault.DataBind()
                Else
                    grdDefault.Visible = False
                    lblTitle5.Visible = False
                End If
            Else
                grdDefault.Visible = False
                lblTitle5.Visible = False
            End If

            ' Get value form variables to Sessions
            Session(strPrefix & "IDs") = strIDs
            Session(strPrefix & "FieldCode") = strTmpFieldCode
            Session(strPrefix & "Indicator") = strTmpIndicator
            Session(strPrefix & "FieldValue") = strTmpFieldValue
        End Function

        ' grdDefault_EditCommand event
        Private Sub grdDefault_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdDefault.EditCommand
            grdDefault.EditItemIndex = e.Item.ItemIndex

            ' Assign value from Sessions to variables
            strIDs = Session(strPrefix & "IDs")
            strTmpFieldCode = Session(strPrefix & "FieldCode")
            strTmpIndicator = Session(strPrefix & "Indicator")
            strTmpFieldValue = Session(strPrefix & "FieldValue")

            objBValidate.Action = "VIEW"
            tblTable = objBValidate.MakeDataTable(strTmpFieldCode, strTmpIndicator, strTmpFieldValue, strIDs)

            dvDefaultView = tblTable.DefaultView

            dvDefaultView.Sort = "FieldCode"
            grdDefault.DataSource = dvDefaultView
            grdDefault.DataBind()
        End Sub

        ' grdDefault_CancelCommand event
        Private Sub grdDefault_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdDefault.CancelCommand
            Call CancelAction()
        End Sub

        ' UpdateSession method
        ' Purpose: Get content for field name, field value if you update one field
        Sub UpdateSession(ByVal strFieldName As String, ByVal strInd As String, ByVal strFieldValueNew As String, ByVal strFieldValueOld As String, ByVal intCheckInd As Integer)
            Dim arrValues As Object

            If intCheckInd = 1 Then
                strFieldValueNew = strInd & "::" & strFieldValueNew
            End If
            If InStr("," & Session(strPrefix & "AllFields"), "," & strFieldName & ",") > 0 Then
                Session(strPrefix & strFieldName) = Replace(Session(strPrefix & strFieldName) & "$&", strFieldValueOld & "$&", strFieldValueNew & "$&")
                Session(strPrefix & strFieldName) = Left(Session(strPrefix & strFieldName), Len(Session(strPrefix & strFieldName)) - 2)
                If Not Session(strPrefix & strFieldName) Is Nothing Then
                    If Len(CStr(Session(strPrefix & strFieldName))) > 0 Then
                        If Left(CStr(Session(strPrefix & strFieldName)), 2) = "$&" Then
                            Session(strPrefix & strFieldName) = Right(Session(strPrefix & strFieldName), Len(Session(strPrefix & strFieldName)) - 2)
                        End If
                    End If
                End If
            End If
        End Sub

        ' grdDefault_UpdateCommand event
        Private Sub grdDefault_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdDefault.UpdateCommand
            Dim strFieldName As String = ""
            Dim strInd As String = ""
            Dim strFieldValueNew As String = ""
            Dim strFieldValueOld As String = ""
            Dim intCheckInd As Integer

            Dim IndicatorText As TextBox = e.Item.FindControl("txtdtgIndicator")
            Dim FieldValueText As TextBox = e.Item.FindControl("txtdtgFieldValue")

            strFieldName = e.Item.Cells(3).Text()
            strInd = e.Item.Cells(1).Text()
            strFieldValueOld = e.Item.Cells(2).Text()
            strFieldValueNew = FieldValueText.Text

            If Len(IndicatorText.Text) > 2 Then
                IndicatorText.Text = Left(IndicatorText.Text, 2)
            End If
            grdDefault.EditItemIndex = -1

            objBValidate.ID = e.Item.Cells(0).Text
            Session(strPrefix & "Undo") = Session(strPrefix & "FieldCode")
            If DoAction(e.Item.Cells(3).Text, IndicatorText.Text, FieldValueText.Text, "MODIFY") = 1 Then
                Exit Sub
            End If
            Session(strPrefix & "FieldCode") = Session(strPrefix & "Undo")
            Call UpdateSession(strFieldName, strInd, strFieldValueNew, strFieldValueOld, intCheckInd)
        End Sub

        ' DeleteSession
        ' Purpose: Get content for field name, field value if you delete one field
        Sub DeleteSession(ByVal strFieldName As String, ByVal strFieldValue As String)
            If InStr("," & Session(strPrefix & "AllFields"), "," & strFieldName & ",") > 0 Then
                Session(strPrefix & strFieldName) = Replace(Session(strPrefix & strFieldName) & "$&", strFieldValue & "$&", "$&")
                Session(strPrefix & strFieldName) = Replace(Session(strPrefix & strFieldName), "$&$&", "$&")
                If Not Session(strPrefix & strFieldName) Is Nothing Then
                    If Len(CStr(Session(strPrefix & strFieldName))) > 0 Then
                        If Left(CStr(Session(strPrefix & strFieldName)), 2) = "$&" Then
                            Session(strPrefix & strFieldName) = Right(Session(strPrefix & strFieldName), Len(Session(strPrefix & strFieldName)) - 2)
                        End If
                        If Right(CStr(Session(strPrefix & strFieldName)), 2) = "$&" Then
                            Session(strPrefix & strFieldName) = Left(Session(strPrefix & strFieldName), Len(Session(strPrefix & strFieldName)) - 2)
                        End If
                    End If
                End If
            End If
        End Sub

        ' grdDefault_DeleteCommand event
        Private Sub grdDefault_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdDefault.DeleteCommand
            Dim strFieldName As String = ""
            Dim strFieldValue As String = ""

            If CInt(hidError.Value) = 0 Then
                objBValidate.ID = e.Item.Cells(0).Text
                strFieldName = e.Item.Cells(3).Text()
                strFieldValue = e.Item.Cells(2).Text()
                If grdDefault.EditItemIndex = -1 Then
                    If UCase(e.Item.Cells(2).Text) <> "&NBSP;" Then
                        DoAction(e.Item.Cells(1).Text, e.Item.Cells(2).Text, e.Item.Cells(3).Text, "DELETE")
                    Else
                        DoAction(e.Item.Cells(1).Text, " ", e.Item.Cells(3).Text, "DELETE")
                    End If
                Else
                    DoAction(e.Item.Cells(1).Text, " ", "$a", "DELETE")
                End If
                Try
                    DeleteSession(strFieldName, strFieldValue)
                    Page.RegisterClientScriptBlock("UpdateFail2", "<script language = 'javascript'>alert('Xóa giá trị ngầm định  thành công')</script>")
                Catch ex As Exception

                End Try

            Else
                hidError.Value = 0
                Call CancelAction()
            End If
        End Sub

        ' Page Unload Method
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Me.Dispose(True)
        End Sub

        ' Dispose Method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not objBValidate Is Nothing Then
                        objBValidate.Dispose(True)
                        objBValidate = Nothing
                    End If
                    If Not objBField Is Nothing Then
                        objBField.Dispose(True)
                        objBField = Nothing
                    End If
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace