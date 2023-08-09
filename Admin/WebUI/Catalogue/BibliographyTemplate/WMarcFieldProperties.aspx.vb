' WMarcFieldProperties class: display all properties of the selected Marc field
' Creator: Oanhtn
' CreatedDate: 28/04/2004
' Modification history
'   - 15/07/2004 by Oanhtn: allow working with both of bibliography & authority data

Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WMarcFieldProperties
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
            Call ShowProperties()
            If Not Page.IsPostBack Then
                lblTitle.Text = lblTitle.Text & " " & Request("FieldCode")
            End If
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init for objBField
            objBField.InterfaceLanguage = Session("InterfaceLanguage")
            objBField.DBServer = Session("DBServer")
            objBField.ConnectionString = Session("ConnectionString")
            objBField.IsAuthority = Session("IsAuthority")
            Call objBField.Initialize()

            ' Write javascript functions
            btnClose.Attributes.Add("OnClick", "javascript:self.close();")
        End Sub

        ' ShowMarcFieldsDetail method
        ' Purpose: Show detail informations of this Marc field
        Private Sub ShowProperties()
            Dim strFieldCode As String
            Dim strField As String ' tempo
            Dim tblTemp As New DataTable
            Dim intIndex As Integer

            ' Get detail infor of this field
            strFieldCode = Request("FieldCode").Trim
            objBField.FieldCode = strFieldCode
            tblTemp = objBField.GetProperties
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                lblFieldCode.Text = tblTemp.Rows(0).Item("FieldCode")
                lblDescription.Text = tblTemp.Rows(0).Item("Description").ToString.Trim
                lblFieldFunction.Text = tblTemp.Rows(0).Item("FieldFunction").ToString.Trim
                If Not IsDBNull(tblTemp.Rows(0).Item("Repeatable")) Then
                    lblRepeatable.Text = tblTemp.Rows(0).Item("Repeatable")
                End If
                If Not IsDBNull(tblTemp.Rows(0).Item("Mandatory")) Then
                    lblMandatory.Text = tblTemp.Rows(0).Item("Mandatory")
                End If
                If Not IsDBNull(tblTemp.Rows(0).Item("FieldType")) Then
                    lblFieldType.Text = tblTemp.Rows(0).Item("FieldType")
                End If
                lblLength.Text = tblTemp.Rows(0).Item("Length").ToString.Trim
                If UCase(Session("InterfaceLanguage")) = "ENGLISH" Then
                    lblFieldName.Text = tblTemp.Rows(0).Item("FieldName")
                    lblVietFieldName.Visible = False
                    lblVietFieldNameText.Visible = False
                    If Not IsDBNull(tblTemp.Rows(0).Item("Indicators")) Then
                        lblIndicators.Text = Replace(tblTemp.Rows(0).Item("Indicators"), Chr(13), "<br>")
                    End If
                Else
                    lblFieldName.Visible = False
                    lblFieldNameText.Visible = False
                    lblVietFieldName.Text = tblTemp.Rows(0).Item("VietFieldName")
                    If Not IsDBNull(tblTemp.Rows(0).Item("Indicators")) Then
                        lblIndicators.Text = Replace(tblTemp.Rows(0).Item("VietIndicators"), Chr(13), "<br>")
                    End If
                End If
            End If

            ' Dispaly subfields
            strField = ""
            tblTemp.Clear()
            objBField.FieldCode = Left(strFieldCode, 3)
            If Len(strFieldCode) > 3 Then
                tblTemp = objBField.GetProperties
                If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                    lblField.Text = Left(strFieldCode, 3) & ": " & tblTemp.Rows(0).Item("VietFieldName")
                    lblField.Visible = True
                    lblFieldText.Visible = True
                End If
            Else
                tblTemp = objBField.GetSubFields
                If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                    For intIndex = 0 To tblTemp.Rows.Count - 1
                        If tblTemp.Rows(intIndex).Item("FieldCode") <> Request("FieldCode") Then
                            strField = strField & tblTemp.Rows(intIndex).Item("FieldCode") & ": "
                            strField = strField & tblTemp.Rows(intIndex).Item("VietFieldName") & " / "
                            strField = strField & tblTemp.Rows(intIndex).Item("FieldName") & "<br>"
                        End If
                    Next
                End If
                If Len(strField.Trim) > 0 Then
                    lblFieldChild.Text = strField
                    lblFieldChild.Visible = True
                    lblFieldChildText.Visible = True
                End If
            End If
        End Sub

        ' Page_Unload event
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
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