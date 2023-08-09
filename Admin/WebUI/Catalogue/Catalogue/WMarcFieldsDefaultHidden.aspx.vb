' Class: WMarcFieldsDefaultHidden
' Puspose: Check & load information of the selected field
' Creator: KhoaNA
' CreatedDate:
' Modification history:
'   - 08/03/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WMarcFieldsDefaultHidden
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

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call LoadFieldCode()
        End Sub

        ' Initialize objects's Property
        Public Sub Initialize()
            ' Init objBField object
            objBField.IsAuthority = Session("IsAuthority")
            objBField.ConnectionString = Session("ConnectionString")
            objBField.DBServer = Session("DBServer")
            objBField.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBField.Initialize()
        End Sub

        ' LoadFieldCode method
        ' Purpose: load field's information
        Private Sub LoadFieldCode()
            If Not Request("FieldCode") = "" Then
                Dim strScript As String
                Dim tblTemp As New DataTable
                Dim blnFound As Boolean = False

                objBField.FieldCode = Request("FieldCode")
                tblTemp = objBField.GetProperties
                Call WriteErrorMssg(ddlLabel.Items(2).Text, objBField.ErrorMsg, ddlLabel.Items(1).Text, objBField.ErrorCode)

                strScript = ""
                If Not tblTemp Is Nothing Then
                    If tblTemp.Rows.Count > 0 Then
                        blnFound = True
                        strScript = strScript & " parent.Workform.document.forms[0].txtFieldName.value='" & tblTemp.Rows(0).Item("VietFieldName") & "';"
                    End If
                End If
                If Not blnFound Then
                    strScript = strScript & " alert('" & ddlLabel.Items(0).Text & "');"
                    strScript = strScript & " parent.Workform.document.forms[0].txtFieldName.value='';"
                    strScript = strScript & " parent.Workform.document.forms[0].txtFieldCode.value='';"
                    strScript = strScript & " parent.Workform.document.forms[0].txtFieldCode.focus();"
                End If
                Page.RegisterClientScriptBlock("LoadFieldCode", "<script language='javascript'>" & strScript & "</script>")
            End If
        End Sub

        ' Page unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Me.Dispose(True)
        End Sub

        ' Dispose method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
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