' WPickedMarcFields class
' Creator: Oanhtn
' CreatedDate: 28/04/2004
' Modification history

Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WPickedMarcFields
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
            If Not Page.IsPostBack Then
                Call BindJavascripts()
                Call ShowDetail()
            End If
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

        ' BindJavascripts method
        ' Purpose: Load all necessary javascript functions
        Private Sub BindJavascripts()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WPickedMarcFields", "<script language = 'javascript' src = '../Js/BibliographyTemplate/WPickedMarcFields.js'></script>")
            btnRemove.Attributes.Add("OnClick", "javascript:RemovePickedFields(); return false;")
        End Sub

        ' ShowDetail method
        ' Purpose: Show detail of all selected MARC fields
        Private Sub ShowDetail()
            Dim tblPickedFields As DataTable
            Dim strPickedFieldCodes As String
            Dim strMarcFieldDetail As String = "javascript:OpenWindow(""WMarcFieldDetail.aspx?FieldID=FIELDVALUE"",""MarcFieldDetail"",700,360,50,100);"

            ' Retrieve two input params FieldIDs & MandatoryFieldIDs
            strPickedFieldCodes = Request("txtPickedFields")
            If Replace(Trim(strPickedFieldCodes), ",", "") = "" Then
                Response.Write("No picked field")
                Response.End()
            End If

            ' dtgMarcFields.Columns(1).Visible = False
            dtgMarcFields.Columns(2).Visible = False
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