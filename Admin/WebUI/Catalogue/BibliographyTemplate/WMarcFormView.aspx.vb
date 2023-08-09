' WMarcSend class
' Creator: Oanhtn
' CreatedDate: 04/05/2004
' Modification history:
'   - 23/02/2005 by oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WMarcFormView
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
            If Not Page.IsPostBack Then
                Call BindData()
            End If
            Call BindJS()
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
            Page.RegisterClientScriptBlock("WMarcFormView", "<script language = 'javascript' src = '../Js/BibliographyTemplate/WMarcFormView.js'></script>")
            btnUpdate.Attributes.Add("OnClick", "javascript:UpdateForm(); alert('" & ddlLabel.Items(2).Text & "');self.close();return false;")
            btnClose.Attributes.Add("OnClick", "javascript:self.close();")
        End Sub

        ' BindData method
        ' Purpose: Loaddata into txtPickedFields, txtPickedTags, txtMandatoryFields
        ' Creator:  Sondp
        Private Sub BindData()
            Dim tblTemp As DataTable
            Dim intFormID As Integer
            Dim strPickedFields As String
            Dim strMandatoryFields As String
            Dim strDefaultFieldValues As String
            Dim strFieldProperties As String = "javascript:OpenWindow(""WMarcFieldProperties.aspx?FieldCode=FIELDVALUE"",""WMarcFieldProperties"",700,360,50,100);"
            Dim strFieldDefaultValue As String = "<input type=""Text"" id=""txtFieldDefault"" name=""txtFieldDefault"">"
            Dim strIndicatorValue As String = "<input type=""Text"" id=""txtFieldIndicators"" name=""txtFieldIndicators"" size=""7"" maxlength=""2"">"
            Dim strMandatoryField As String = "<input type=""Checkbox"" name=""chkMandatoryFieldCode"" id=""chkMandatoryFieldCode"" value=""PARAM"">"
            Dim strIsTextBox As String = "<input type=""Checkbox"" name=""chkIsTextBox"" id=""chkIsTextBox"" value=""PARAM"" ISCHECK>"
            Dim strPickedField As String = "<input type=""Checkbox"" name=""chkPickedFieldCode"" id=""chkPickedFieldCode"" value=""PARAM"">"
            Dim strFieldIndicators As String = "<input type=""Text"" id=""txtFieldIndicator"" name=""txtFieldIndicator"" size=""1"">"
            Dim arrTemp()
            Dim strTemp As String
            Dim intCount As Integer

            If Not Request("txtFormID") = "" Then
                intFormID = CInt(Request("txtFormID"))
            End If
            If Not Request("txtPickedFields") = "" Then
                txtPickedFields.Value = Request("txtPickedFields")
            End If
            If Not Request("txtMandatoryFields") = "" Then
                txtMandatoryFields.Value = Request("txtMandatoryFields")
            End If
            If Not Request("txtDefaultFieldValues") = "" Then
                txtFieldDefaultValues.Value = Request("txtDefaultFieldValues")
            End If
            If Not Request("txtTextBoxFields") = "" Then
                txtTextBoxFields.Value = Request("txtTextBoxFields")
            End If
            If Not Request("txtFieldIndicatorValues") = "" Then
                txtFieldIndicatorValues.Value = Request("txtFieldIndicatorValues")
            End If
            strPickedFields = txtPickedFields.Value
            strMandatoryFields = txtMandatoryFields.Value

            ' Get strPickedFields (only parent fields)
            If Len(strMandatoryFields) > 3 Then
                arrTemp = Split(strMandatoryFields, ",")
                strMandatoryFields = ","
                For intCount = 0 To UBound(arrTemp) - 1
                    strTemp = Left(arrTemp(intCount), 3)
                    If Not InStr(strMandatoryFields, strTemp) > 0 Then
                        strMandatoryFields = strMandatoryFields & strTemp & ","
                    End If
                Next
            End If
            txtPickedFields.Value = strPickedFields
            txtMandatoryFields.Value = strMandatoryFields
            objBForm.IsAuthority = CInt(Session("IsAuthority"))
            objBForm.FCURL1 = strFieldProperties
            objBForm.FCURL2 = strMandatoryField
            objBForm.FCURL3 = strPickedField
            objBForm.FCURL4 = strFieldDefaultValue
            objBForm.FCURL5 = strIsTextBox
            objBForm.FCURL6 = strIndicatorValue
            objBForm.PickedFieldCodes = strPickedFields
            objBForm.FormID = intFormID
            tblTemp = objBForm.GetPickedFieldView()
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                dtgMarcFields.DataSource = tblTemp
                dtgMarcFields.DataBind()
                ' Customize interface
                dtgMarcFields.Columns(3).Visible = False
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