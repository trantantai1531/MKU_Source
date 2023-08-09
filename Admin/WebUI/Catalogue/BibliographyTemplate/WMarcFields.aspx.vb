' WMarcSubFields class: allow user select suite Marc fields
' Creator: Oanhtn
' CreatedDate: 26/04/2004
' Modification history 
'   - 23/02/2005 by Oanhtn: review & update

Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WMarcFields
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lnkABC As System.Web.UI.WebControls.HyperLink


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
                Call BindJS()
                Call ShowMarcFieldsInfor()
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

        ' BindJS method
        ' Purpose: include all necessary javascript functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
        End Sub

        ' ShowMarcFieldsInfor method
        ' Purpose: Display infor of fields of the selected block
        Private Sub ShowMarcFieldsInfor()
            Dim intBlockID As Integer
            Dim tblMarcFieldsOfBlock As DataTable
            Dim strFieldProperties As String = "javascript:OpenWindow(""WMarcFieldProperties.aspx?FieldCode=FIELDVALUE"",""WMarcFieldProperties"",700,360,50,100);"
            Dim strGetSubFields As String = "javascript:self.location.href=""WMarcSubFields.aspx?FieldCode=FIELDVALUE"";"

            ' Get BlockID
            intBlockID = CInt(Request("BlockID"))
            If intBlockID = 0 Then
                intBlockID = 1
            End If

            objBField.IsAuthority = CInt(Session("IsAuthority"))
            objBField.FCURL1 = strFieldProperties
            objBField.FCURL2 = strGetSubFields
            objBField.BlockID = intBlockID
            tblMarcFieldsOfBlock = objBField.GetFieldsOfBlock
            If Not tblMarcFieldsOfBlock Is Nothing AndAlso tblMarcFieldsOfBlock.Rows.Count > 0 Then
                dtgMarcFields.DataSource = tblMarcFieldsOfBlock
                dtgMarcFields.DataBind()
                ' Customize display
                dtgMarcFields.Columns(2).Visible = False
            End If

            ' Release object
            tblMarcFieldsOfBlock = Nothing
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