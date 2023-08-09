' WMarcFieldNew class
' Creator: Oanhtn
' CreatedDate: 11/05/2004
' Modification history 
'   - 13/05/2004 by Oanhtn
'   - 01/03/2005 by Tuanhv: review

Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WCheckAttachField
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
            Call CheckField()
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init objBField object
            objBField.InterfaceLanguage = Session("InterfaceLanguage")
            objBField.DBServer = Session("DBServer")
            objBField.ConnectionString = Session("ConnectionString")
            Call objBField.Initialize()
        End Sub

        ' CheckField method
        ' Purpose: Check attach field
        Private Sub CheckField()
            Dim strFieldCode As String = Left(Trim(Request("FieldCode")), 3)
            Dim intFieldType As Integer = CInt(Request("TypeID"))
            Dim intCounter As Integer
            Dim tblTemp As DataTable
            Dim strJavascript As String = ""

            Dim strMess0 As String = ddlLabel.Items(0).Text
            Dim strMess1 As String = ddlLabel.Items(1).Text
            Dim strMess3 As String = ddlLabel.Items(2).Text
            Dim strMess4 As String = ddlLabel.Items(3).Text

            ' Check type of parent field
            objBField.FieldCode = strFieldCode
            tblTemp = objBField.GetProperties()
            If CInt(tblTemp.Rows(0).Item("FieldTypeID")) = 4 Then
                strJavascript = "alert('" & strMess0 & " " & strFieldCode & " " & strMess1 & "');"
                strJavascript = strJavascript & "parent.Workform.document.forms[0].ddlMarcFieldTypes.options.selectedIndex = 0;"
            ElseIf intFieldType = 4 Then ' Check type of cosubfield
                objBField.FieldCode = strFieldCode
                tblTemp = objBField.GetSubFields
                If Not tblTemp Is Nothing Then
                    For intCounter = 0 To tblTemp.Rows.Count - 1
                        If CInt(tblTemp.Rows(0).Item("FieldTypeID")) = 4 Then
                            strJavascript = "alert('" & strMess0 & " " & strFieldCode & " " & strMess3 & " " & tblTemp.Rows(intCounter).Item("FieldCode") & " " & strMess4 & "');"
                            strJavascript = strJavascript & "parent.Workform.document.forms[0].ddlMarcFieldTypes.options.selectedIndex = 0;"
                            Exit For
                        End If
                    Next
                End If
            End If
            If Not strJavascript = "" Then
                Page.RegisterClientScriptBlock("AlertJS", "<script language = 'javascript'>" & strJavascript & "</script>")
            End If
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