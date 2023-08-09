' WMarcFieldLoad class
' Purpose: load infortion of the selected user's field
' Creator: Oanhtn
' CreatedDate: 11/05/2004
' Modification history
'    - 01/03/2005 by Tuanhv: review

Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WMarcFieldLoad
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

        Private objBField As New clsBField
        Private objBEData As New clsBEData
        Private intUTF As Integer = 0

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call LoadMarcFieldInfor()
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init for objBField
            objBField.InterfaceLanguage = Session("InterfaceLanguage")
            objBField.DBServer = Session("DBServer")
            objBField.ConnectionString = Session("ConnectionString")
            Call objBField.Initialize()

            ' Init objBEData object
            objBEData.InterfaceLanguage = Session("InterfaceLanguage")
            objBEData.DBServer = Session("DBServer")
            objBEData.ConnectionString = Session("ConnectionString")
            Call objBEData.Initialize()
        End Sub

        ' LoadMarcFieldInfor method
        ' Purpose: load information of the selected field
        Private Sub LoadMarcFieldInfor()
            Dim strFieldCode As String = Request("FieldCode")
            Dim strJavaScript As String = ""
            Dim strMess0 As String = ddlLabel.Items(0).Text
            Dim tblTemp As New DataTable
            Dim tblEDataParam As New DataTable

            ' Get all properties of the selected field
            objBField.FieldCode = strFieldCode
            tblTemp = objBField.GetProperties
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                If Not CInt(tblTemp.Rows(0).Item("IsMarcField")) = 0 And False Then ' Marc field
                    'not check Marc's field, all field can be modify 
                    'by lenta 7-9-2006
                    strJavaScript = "alert('" & ddlLabel.Items(1).Text & "'); parent.Workform.document.forms[0].txtFieldCode.value = ''; parent.Workform.document.forms[0].txtFieldCode.focus();"
                Else ' user defined field
                    ' FieldCode
                    If Not IsDBNull(tblTemp.Rows(0).Item("FieldCode")) Then
                        strJavaScript = strJavaScript & "parent.Workform.document.forms[0].txtFieldCode.value = '" & Replace(tblTemp.Rows(0).Item("FieldCode"), """", "\""") & "';"
                    End If
                    ' FieldName
                    If Not IsDBNull(tblTemp.Rows(0).Item("FieldName")) Then
                        strJavaScript = strJavaScript & "parent.Workform.document.forms[0].txtFieldName.value = '" & Replace(Replace(tblTemp.Rows(0).Item("FieldName"), """", "\"""), "'", "") & "';"
                    Else
                        strJavaScript = strJavaScript & "parent.Workform.document.forms[0].txtFieldName.value = '';"
                    End If
                    ' VietFieldName
                    If Not IsDBNull(tblTemp.Rows(0).Item("VietFieldName")) Then
                        strJavaScript = strJavaScript & "parent.Workform.document.forms[0].txtVietFieldName.value = '" & Replace(tblTemp.Rows(0).Item("VietFieldName"), """", "\""") & "';"
                    Else
                        strJavaScript = strJavaScript & "parent.Workform.document.forms[0].txtVietFieldName.value = '';"
                    End If
                    ' Repeatable
                    If Not CInt(tblTemp.Rows(0).Item("Repeatable")) = 0 Then
                        strJavaScript = strJavaScript & "parent.Workform.document.forms[0].chkRepeatable.checked = true;"
                    Else
                        strJavaScript = strJavaScript & "parent.Workform.document.forms[0].chkRepeatable.checked = false;"
                    End If
                    ' Mandatory
                    If Not CInt(tblTemp.Rows(0).Item("Mandatory")) = 0 Then
                        strJavaScript = strJavaScript & "parent.Workform.document.forms[0].chkMandatory.checked = true;"
                    Else
                        strJavaScript = strJavaScript & "parent.Workform.document.forms[0].chkMandatory.checked = false;"
                    End If
                    ' Description
                    If Not IsDBNull(tblTemp.Rows(0).Item("Description")) Then
                        strJavaScript = strJavaScript & "parent.Workform.document.forms[0].txtDescription.value = '" & Replace(Replace(Replace(tblTemp.Rows(0).Item("Description"), """", "\"""), Chr(13), "\n"), Chr(10), "") & "';"
                    Else
                        strJavaScript = strJavaScript & "parent.Workform.document.forms[0].txtDescription.value = '';"
                    End If
                    ' Indicators
                    If Not IsDBNull(tblTemp.Rows(0).Item("Indicators")) Then
                        strJavaScript = strJavaScript & "parent.Workform.document.forms[0].txtIndicators.value = '" & Replace(Replace(Replace(tblTemp.Rows(0).Item("Indicators"), """", "\"""), Chr(13), "\n"), Chr(10), "") & "';"
                    Else
                        strJavaScript = strJavaScript & "parent.Workform.document.forms[0].txtIndicators.value = '';"
                    End If
                    ' VietIndicators
                    If Not IsDBNull(tblTemp.Rows(0).Item("VietIndicators")) Then
                        strJavaScript = strJavaScript & "parent.Workform.document.forms[0].txtVietIndicators.value = '" & Replace(Replace(Replace(tblTemp.Rows(0).Item("VietIndicators"), """", "\"""), Chr(13), "\n"), Chr(10), "") & "';"
                    Else
                        strJavaScript = strJavaScript & "parent.Workform.document.forms[0].txtVietIndicators.value = '';"
                    End If
                    ' Length
                    strJavaScript = strJavaScript & "parent.Workform.document.forms[0].txtLength.value = " & tblTemp.Rows(0).Item("Length") & ";"
                    ' AuthorityControl
                    If Not IsDBNull(tblTemp.Rows(0).Item("DicID")) Then
                        strJavaScript = strJavaScript & "for (i = 0; i < parent.Workform.document.forms[0].ddlAuthorityControl.options.length; i++) {"
                        strJavaScript = strJavaScript & "if (parent.Workform.document.forms[0].ddlAuthorityControl.options[i].value == " & tblTemp.Rows(0).Item("DicID") & ") {"
                        strJavaScript = strJavaScript & "parent.Workform.document.forms[0].ddlAuthorityControl.selectedIndex = i;"
                        strJavaScript = strJavaScript & "break;"
                        strJavaScript = strJavaScript & "}"
                        strJavaScript = strJavaScript & "}"
                    Else
                        strJavaScript = strJavaScript & "parent.Workform.document.forms[0].ddlAuthorityControl.selectedIndex = 0;"
                    End If
                    ' Type of field
                    strJavaScript = strJavaScript & "for (i = 0; i < parent.Workform.document.forms[0].ddlMarcFieldTypes.options.length; i++) {"
                    strJavaScript = strJavaScript & "if (parent.Workform.document.forms[0].ddlMarcFieldTypes.options[i].value == " & tblTemp.Rows(0).Item("FieldTypeID") & ") {"
                    strJavaScript = strJavaScript & "parent.Workform.document.forms[0].ddlMarcFieldTypes.selectedIndex = i;"
                    strJavaScript = strJavaScript & "break;"
                    strJavaScript = strJavaScript & "}"
                    strJavaScript = strJavaScript & "}"
                    ' FunctionID
                    If Not IsDBNull(tblTemp.Rows(0).Item("FunctionID")) Then
                        strJavaScript = strJavaScript & "for (i = 0; i < parent.Workform.document.forms[0].ddlMarcFunctions.options.length; i++) {"
                        strJavaScript = strJavaScript & "if (parent.Workform.document.forms[0].ddlMarcFunctions.options[i].value == " & tblTemp.Rows(0).Item("FunctionID") & ") {"
                        strJavaScript = strJavaScript & "parent.Workform.document.forms[0].ddlMarcFunctions.selectedIndex = i;"
                        strJavaScript = strJavaScript & "break;"
                        strJavaScript = strJavaScript & "}"
                        strJavaScript = strJavaScript & "};"
                        strJavaScript = strJavaScript & "parent.Workform.document.forms[0].txtFunctionID.value = " & tblTemp.Rows(0).Item("FunctionID") & ";"
                    Else
                        strJavaScript = strJavaScript & "parent.Workform.document.forms[0].ddlMarcFunctions.selectedIndex = 0;"
                        strJavaScript = strJavaScript & "parent.Workform.document.forms[0].txtFunctionID.value = 0;"
                    End If
                    If CInt(tblTemp.Rows(0).Item("FieldTypeID")) = 4 Then
                        objBEData.FieldCode = strFieldCode
                        tblEDataParam = objBEData.GetEDataParams
                        If Not tblEDataParam.Rows.Count = 0 Then
                            strJavaScript = strJavaScript & "parent.Workform.document.forms[0].txtPhysicalPath.value = '" & Replace(tblEDataParam.Rows(0).Item("PhysicalPath"), "\", "\\") & "';"
                            strJavaScript = strJavaScript & "parent.Workform.document.forms[0].txtURL.value = '" & Replace(tblEDataParam.Rows(0).Item("URL"), "\", "\\") & "';"
                            If Not IsDBNull(tblEDataParam.Rows(0).Item("AllowedFileExt")) Then
                                strJavaScript = strJavaScript & "parent.Workform.document.forms[0].txtAllowedFileExt.value = '" & tblEDataParam.Rows(0).Item("AllowedFileExt") & "';"
                            Else
                                strJavaScript = strJavaScript & "parent.Workform.document.forms[0].txtAllowedFileExt.value = '';"
                            End If
                            If Not IsDBNull(tblEDataParam.Rows(0).Item("DeniedFileExt")) Then
                                strJavaScript = strJavaScript & "parent.Workform.document.forms[0].txtDeniedFileExt.value = '" & tblEDataParam.Rows(0).Item("DeniedFileExt") & "';"
                            Else
                                strJavaScript = strJavaScript & "parent.Workform.document.forms[0].txtDeniedFileExt.value = '';"
                            End If
                            If Not IsDBNull(tblEDataParam.Rows(0).Item("MaxSize")) Then
                                strJavaScript = strJavaScript & "parent.Workform.document.forms[0].txtMaxsize.value = " & tblEDataParam.Rows(0).Item("MaxSize") & ";"
                            Else
                                strJavaScript = strJavaScript & "parent.Workform.document.forms[0].txtMaxsize.value = 0;"
                            End If
                            If Not IsDBNull(tblEDataParam.Rows(0).Item("Prefix")) Then
                                strJavaScript = strJavaScript & "parent.Workform.document.forms[0].txtPrefix.value = '" & tblEDataParam.Rows(0).Item("Prefix") & "';"
                            Else
                                strJavaScript = strJavaScript & "parent.Workform.document.forms[0].txtPrefix.value = '';"
                            End If
                            If Not IsDBNull(tblEDataParam.Rows(0).Item("Logo")) Then
                                strJavaScript = strJavaScript & "parent.Workform.document.forms[0].txtLogo.value = '" & tblEDataParam.Rows(0).Item("Logo") & "';"
                            Else
                                strJavaScript = strJavaScript & "parent.Workform.document.forms[0].txtLogo.value = '';"
                            End If
                        End If
                    End If
                End If
            Else
                strJavaScript = strJavaScript & "alert('" & strMess0 & "');"
                strJavaScript = strJavaScript & "parent.Workform.document.forms[0].reset();parent.Workform.document.forms[0].txtFieldCode.value='';"
            End If
            If Not strJavaScript = "" Then
                Page.RegisterClientScriptBlock("LoadFieldInfor", "<script language = 'javascript'>" & strJavaScript & "</script>")
            End If

            ' Release all objects
            tblTemp.Dispose()
            tblTemp = Nothing
            tblEDataParam.Dispose()
            tblEDataParam = Nothing
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBEData Is Nothing Then
                    objBEData.Dispose(True)
                    objBEData = Nothing
                End If
                If Not objBField Is Nothing Then
                    objBField.Dispose(True)
                    objBField = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace