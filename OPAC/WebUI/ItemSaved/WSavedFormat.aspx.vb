' purpose : list of items were saved
' Create Date 4/11/2004
' Creator : lent

Imports eMicLibOPAC.BusinessRules.OPAC

Namespace eMicLibOPAC.WebUI.OPAC
    Partial Class WSavedFormat
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            Call BindJavascript()
        End Sub
        ' Initialize method
        ' Purpose: Init all necessary objects
        Private Sub Initialize()
            'Initialize objBItemCollection
        End Sub
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../Common/eMicLibCommon.js'></script>")
            Page.RegisterClientScriptBlock("MainJs", "<script language='javascript' src='../JS/Item/OpacItem.js'></script>")
            arrlistsaved.Value = ""
            If Request("arrlistsaved") <> "" Then
                arrlistsaved.Value = Request("arrlistsaved")
            End If
            optISBD.Attributes.Add("onClick", "javascript:ShowHideTable(tboptISO,0);")
            optMARC.Attributes.Add("onClick", "javascript:ShowHideTable(tboptISO,0);")
            optXML.Attributes.Add("onClick", "javascript:ShowHideTable(tboptISO,0);")
            optDCXML.Attributes.Add("onClick", "javascript:ShowHideTable(tboptISO,0);")
            optISO.Attributes.Add("onClick", "javascript:ShowHideTable(tboptISO,1);")
            btnAction.Attributes.Add("onClick", "javascript:if(CheckEmail('" & ddlLabel.Items(0).Text & "','" & ddlLabel.Items(1).Text & "')) GoSubmit('WSavedListAction.aspx'); else return false;")
            lnkRoot2.NavigateUrl = "javascript:ComeBack();"
            optDesEmail.Attributes.Add("onClick", "document.forms[0].txtEmail.focus();")
        End Sub
        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace