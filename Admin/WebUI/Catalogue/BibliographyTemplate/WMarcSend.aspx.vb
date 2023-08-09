' WMarcSend class
' Creator: Oanhtn
' CreatedDate: 28/04/2004
' Modification history 
'   - 22/02/2005 by oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WMarcSend
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

        Private objBForm As New clsBForm

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            Call BindData()
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init objBForm object
            objBForm.InterfaceLanguage = Session("InterfaceLanguage")
            objBForm.DBServer = Session("DBServer")
            objBForm.ConnectionString = Session("ConnectionString")
            Call objBForm.Initialize()
        End Sub

        ' BindJS method
        Private Sub BindJS()
            Dim intUTF As Integer = 0
            If UCase(Session("InterfaceLanguage")) = "UNICODE" Then
                intUTF = 1
            End If
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WMarcSend", "<script language = 'javascript' src = '../Js/BibliographyTemplate/WMarcSend.js'></script>")

            btnView.Attributes.Add("OnClick", "javascript:OpenMarcFormViewWin(document.forms[0].txtPickedFields.value, document.forms[0].txtMandatoryFields.value, 'MarcFormWin', 700,360,50,100); return false;")
            btnNew.Attributes.Add("OnClick", "javascript:OpenWindow('WMarcNewFrame.aspx', 'NewField', 700, 360, 50, 100); return false;")
            btnReset.Attributes.Add("OnClick", "document.forms[0].txtPickedFields.value=','; document.forms[0].txtPickedTags.value=','; document.forms[0].txtMandatoryFields.value=',';ResetForm(ddlFormName.options[ddlFormName.options.selectedIndex].value); return false;")
            btnUpdate.Attributes.Add("OnClick", "javascript:CheckValidForm('" & ddlLabel.Items(4).Text & "', '" & ddlLabel.Items(3).Text & "', " & intUTF & "); return false;")

            ddlFormName.Attributes.Add("OnChange", "location.href='WMarcSend.aspx?FormID='+ this.options[this.options.selectedIndex].value;")
        End Sub

        ' BindData method
        ' Purpose: Loaddata into txtPickedFields, txtPickedTags, txtMandatoryFields
        Private Sub BindData()
            ' Declare variables
            Dim tblTemp As New DataTable
            Dim intCount As Integer
            Dim strFieldDefaultValues As String = ""
            Dim strFieldIndicatorValues As String = ""
            Dim strIsTextBox As String = ","
            Dim strPickedFields As String = ","
            Dim strPickedTags As String = ","
            Dim strLoadedFields As String = ","
            Dim strMandatoryFields As String = ","
            Dim strFormName As String
            Dim intCounter As Integer
            Dim intFormID As Integer
            Dim strTemp As String

            ' Get FormID
            If Not Request("FormID") = "" Then ' To update current Form
                txtFormID.Value = Request("FormID")
            End If
            intFormID = CInt(txtFormID.Value)

            ' Check permission
            If Not CheckPemission(19) Then ' new field
                btnNew.Enabled = False
            End If

            If Not intFormID = 0 Then ' update form
                If Not CheckPemission(17) Then
                    btnUpdate.Enabled = False
                End If
            Else ' new form
                If Not CheckPemission(16) Then
                    btnUpdate.Enabled = False
                End If
            End If

            If Not intFormID = 0 Then
                objBForm.IsAuthority = CInt(Session("IsAuthority"))
                objBForm.FormID = intFormID
                objBForm.Creator = clsSession.GlbUserFullName
                tblTemp = objBForm.GetFields
                ' Check error
                If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                    strFormName = tblTemp.Rows(intCount).Item("Name")
                    Dim strFieldCodeTmp As String = ""
                    For intCount = 0 To tblTemp.Rows.Count - 1
                        strPickedFields = strPickedFields & tblTemp.Rows(intCount).Item("FieldCode") & ","
                        If Not IsDBNull(tblTemp.Rows(intCount).Item("FieldCode")) Then
                            If strFieldCodeTmp <> Left(tblTemp.Rows(intCount).Item("FieldCode"), 3) Then
                                strFieldCodeTmp = Left(tblTemp.Rows(intCount).Item("FieldCode"), 3)
                                If Not IsDBNull(tblTemp.Rows(intCount).Item("Mandatory")) AndAlso CBool(tblTemp.Rows(intCount).Item("Mandatory")) Then
                                    strMandatoryFields = strMandatoryFields & strFieldCodeTmp & ","
                                End If
                                If Not IsDBNull(tblTemp.Rows(intCount).Item("DefaultValue")) Then
                                    strFieldDefaultValues = strFieldDefaultValues & strFieldCodeTmp & "::" & tblTemp.Rows(intCount).Item("DefaultValue") & ":::"
                                End If
                                If Not IsDBNull(tblTemp.Rows(intCount).Item("DefaultIndicators")) Then
                                    strFieldIndicatorValues = strFieldIndicatorValues & strFieldCodeTmp & "::" & tblTemp.Rows(intCount).Item("DefaultIndicators") & ":::"
                                End If
                                If Not IsDBNull(tblTemp.Rows(intCount).Item("IsTextBox")) Then
                                    If CInt(tblTemp.Rows(intCount).Item("IsTextBox")) = 1 Or tblTemp.Rows(intCount).Item("IsTextBox").ToString.Trim Then
                                        strIsTextBox = strIsTextBox & strFieldCodeTmp & ","
                                    End If
                                End If
                            End If
                        End If
                    Next
                    txtPickedFields.Value = strPickedFields
                    txtPickedTags.Value = strPickedTags
                    txtLoadedFields.Value = strLoadedFields
                    txtMandatoryFields.Value = strMandatoryFields
                    txtFieldDefaultValues.Value = strFieldDefaultValues
                    txtFieldIndicatorValues.Value = strFieldIndicatorValues
                    txtTextBoxFields.Value = strIsTextBox
                    txtFormName.Text = strFormName
                End If
                tblTemp.Clear()
            End If

            ' Bind FromName dropdownlist
            objBForm.IsAuthority = CInt(Session("IsAuthority"))
            objBForm.FormID = 0
            tblTemp = objBForm.GetForms
            ' Check error
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlFormName.DataSource = InsertOneRow(tblTemp, ddlLabel.Items(2).Text)
                ddlFormName.DataTextField = "Name"
                ddlFormName.DataValueField = "ID"
                ddlFormName.DataBind()
                For intCounter = 0 To tblTemp.Rows.Count - 1
                    If intFormID = CInt(tblTemp.Rows(intCounter).Item("ID")) Then
                        ddlFormName.SelectedIndex = intCounter + 1
                        Exit For
                    End If
                Next
            End If

            ' Customize interface
            If CInt(Session("IsAuthority")) = 0 Then
                btnNew.Visible = True
            Else
                btnNew.Visible = False
            End If

            tblTemp.Dispose()
            tblTemp = Nothing
        End Sub

        ' Page_Unload event
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
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