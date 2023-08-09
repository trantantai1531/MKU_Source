' WMarcFieldNew class
' Creator: Oanhtn
' CreatedDate: 11/05/2004
' Modification history 
'    - 01/03/2005 by Tuanhv: review

Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WMarcFieldCheck
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
        Private objBField As New clsBField

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call CheckMarcField()
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init for objBField
            objBField.InterfaceLanguage = Session("InterfaceLanguage")
            objBField.DBServer = Session("DBServer")
            objBField.ConnectionString = Session("ConnectionString")
            Call objBField.Initialize()
        End Sub

        ' CheckMarcField method
        ' Purpose: Check exist field in MARC_BIB_FIELD table
        Private Sub CheckMarcField()
            Dim strFieldCode As String = Request("FieldCode")
            Dim strFieldName As String = ""
            Dim strJavaScript As String = ""
            Dim strMess1 As String = ddlLabel.Items(0).Text
            Dim strMess2 As String = ddlLabel.Items(1).Text
            Dim strMess3 As String = ddlLabel.Items(2).Text
            Dim strMess4 As String = ddlLabel.Items(3).Text
            Dim strMess5 As String = ddlLabel.Items(4).Text
            Dim strMess6 As String = ddlLabel.Items(5).Text

            Dim tblTemp As New DataTable

            ' refresh workform
            strJavaScript = strJavaScript & "parent.Workform.document.forms[0].txtFieldName.value = '';"
            strJavaScript = strJavaScript & "parent.Workform.document.forms[0].txtVietFieldName.value = '';"
            strJavaScript = strJavaScript & "parent.Workform.document.forms[0].txtIndicators.value = '';"
            strJavaScript = strJavaScript & "parent.Workform.document.forms[0].txtVietIndicators.value = '';"
            strJavaScript = strJavaScript & "parent.Workform.document.forms[0].txtDescription.value = '';"
            strJavaScript = strJavaScript & "parent.Workform.document.forms[0].txtLength.value = '0';"
            strJavaScript = strJavaScript & "parent.Workform.document.forms[0].chkMandatory.checked = false;"
            strJavaScript = strJavaScript & "parent.Workform.document.forms[0].chkRepeatable.checked = false;"
            strJavaScript = strJavaScript & "parent.Workform.document.forms[0].ddlAuthorityControl.selectedIndex = 0;"
            strJavaScript = strJavaScript & "parent.Workform.document.forms[0].ddlMarcFieldTypes.selectedIndex = 0;"
            strJavaScript = strJavaScript & "parent.Workform.document.forms[0].ddlMarcFunctions.selectedIndex = 0;"
            Page.RegisterClientScriptBlock("refresh", "<script language = 'javascript'>" & strJavaScript & "</script>")
            strJavaScript = ""

            ' search in MARC_BIB_FIELD table by FieldCode
            objBField.FieldCode = strFieldCode
            tblTemp = objBField.GetProperties
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                If Not UCase(Session("InterfaceLanguage")) = "ENGLISH" Then
                    strFieldName = CStr(tblTemp.Rows(0).Item("VietFieldName").ToString.Trim)
                Else
                    strFieldName = CStr(tblTemp.Rows(0).Item("FieldName").ToString.Trim)
                End If
                If InStr(strFieldCode, "$") Then
                    strJavaScript = "alert('" & strMess1 & " " & strFieldCode & strMess2 & " " & strFieldName & "');"
                Else
                    strJavaScript = "alert('" & strMess1 & " " & strFieldCode & strMess2 & " " & strFieldName & ".\n\n" & strMess3 & "');"
                End If
            ElseIf InStr(strFieldCode, "$") > 0 Then ' Check field is subfield
                objBField.FieldCode = Left(strFieldCode, 3)
                tblTemp = objBField.GetProperties
                If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                    If tblTemp.Rows(0).Item("FieldTypeID") = 4 Then
                        strJavaScript = "alert('" & strMess5 & " " & strFieldCode & " " & strMess6 & "');"
                    End If
                Else
                    strJavaScript = "alert('" & strMess4 & "');"
                End If
            End If
            If Not strJavaScript = "" Then
                strJavaScript = strJavaScript & " parent.Workform.document.forms[0].txtFieldCode.value = ''; parent.Workform.document.forms[0].txtFieldCode.focus();"
                Page.RegisterClientScriptBlock("Alert", "<script language = 'javascript'>" & strJavaScript & "</script>")
            End If

            ' Release tblTemp
            tblTemp.Dispose()
            tblTemp = Nothing
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
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