' Class: WMarcWSForm
' Purpose: Show available MarcForm
' Creator: Oanhtn
' CreatedDate: 12/05/2004
' Modification history:
'   - 26/02/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WMarcWSForm
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBForm As New clsBForm

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJavascript()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' BindData method
        ' Purpose: Include all neccessary javascript functions
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("WCataSentJs", "<script language = 'javascript' src = '../Js/Catalogue/WCataSent.js'></script>")
            If Not Page.IsPostBack Then
                Page.RegisterClientScriptBlock("FooterJS", "<script language = 'javascript'>parent.Sentform.location.href='WNothing.htm';</script>")
            End If
            btnNew.Attributes.Add("onClick", "return LoadFormAddnew();")
            'Page.RegisterClientScriptBlock("OnLoad", "<script language = 'javascript'>document.forms[0].target = ""Sentform""; document.forms[0].action = ""WCataSent.aspx"";</script>")
        End Sub

        ' CheckFormPermission method
        ' Purpose: check permission
        Private Sub CheckFormPermission()
            If Session("IsAuthority") = 0 Then 'Thu muc
                If Not CheckPemission(2) Then
                    btnNew.Enabled = False
                End If
            Else 'Tu chuan
                If Not CheckPemission(141) Then
                    btnNew.Enabled = False
                End If
            End If
        End Sub

        ' BindData method
        ' Purpose: load all marc worksheet into listbox lstMarcForm
        Private Sub BindData()
            Dim tblTemp As DataTable

            tblTemp = objBForm.GetForms
            If tblTemp.Rows.Count > 0 Then
                lstMarcForm.DataSource = tblTemp
                lstMarcForm.DataTextField = "Name"
                lstMarcForm.DataValueField = "ID"
                lstMarcForm.DataBind()
                lstMarcForm.SelectedIndex = 0
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            If IsNumeric(Request("Authority")) Then
                Session("IsAuthority") = CInt(Request("Authority"))
            Else
                If Not IsNumeric(Session("IsAuthority")) Then
                    Session("IsAuthority") = 0
                End If
            End If
            If Not IsNothing(Request("FileIds")) Then
                hidFileIds.Value = Request("FileIds")
            End If

            ' Init objBForm object
            objBForm.IsAuthority = Session("IsAuthority")
            objBForm.InterfaceLanguage = Session("InterfaceLanguage")
            objBForm.DBServer = Session("DBServer")
            objBForm.ConnectionString = Session("ConnectionString")
            Call objBForm.Initialize()
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
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