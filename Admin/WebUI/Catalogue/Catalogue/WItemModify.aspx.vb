' Class: WSearchItemCode
' Purpose: Search an Item's code title to delete
' Creater: lenta
' CreatedDate: 7/6/2006
' Modify history:
Imports eMicLibAdmin.BusinessRules.Common
Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WItemModify
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
        Private objBCDBS As New clsBCommonDBSystem

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            CheckFormPermission()
            Call Initialize()
            Call BindJavascripts()
            If Request("txtItemCode") <> "" Then
                ToModify()
            End If
        End Sub
        ' CheckFormPermission method
        ' Purpose: check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(3) Then
                Me.WriteErrorMssg(ddlLabel.Items(1).Text)
            End If
        End Sub
        ' Method: Initialize
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init objBCDBS object
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            Call objBCDBS.Initialize()
        End Sub
        ' BindJavascripts method
        ' Purpose: include all necessary javascript Functions
        Private Sub BindJavascripts()
            Page.RegisterClientScriptBlock("WCommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WItemModifyJs", "<script language = 'javascript' src = '../Js/Catalogue/WItemModify.js'></script>")
            btnModify.Attributes.Add("OnClick", "if(trim(document.forms[0].txtItemCode.value)=='') {alert('" & ddlLabel.Items(0).Text & "');document.forms[0].txtItemCode.focus();return false;} return true;")
            txtItemCode.Attributes.Add("onkeypress", "KeyPress();")
        End Sub
        Private Sub btnModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModify.Click
            ToModify()
        End Sub
        Private Sub ToModify()
            Dim strItemcode As String = txtItemCode.Text.Trim
            Dim tblTemp As DataTable
            objBCDBS.SQLStatement = "select ID from Lib_tblItem where LibId = " & clsSession.GlbSite & " and upper(code)='" & strItemcode & "'"
            tblTemp = objBCDBS.RetrieveItemInfor
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                Page.RegisterClientScriptBlock("GotoModifyForm", "<script language = 'javascript'>parent.Sentform.location.href='WCataModify.aspx?ItemID=" & tblTemp.Rows(0).Item("ID") & "&CurrentID=0';</script>")
            Else
                Page.RegisterClientScriptBlock("NotFoundItemCode", "<script language = 'javascript'>alert('" & ddlLabel.Items(2).Text & "');</script>")
            End If
        End Sub
        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace