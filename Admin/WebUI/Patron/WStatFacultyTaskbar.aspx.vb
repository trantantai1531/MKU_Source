' Class: WStatFacultyTaskbar
' Puspose: Show statistic by faculty
' Creator: Sondp
' CreatedDate: 21-1-2005
' Modification History:
'   - 02/05/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Patron

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WStatFacultyTaskbar
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
        'Private objBCollege As New clsBCollege
        'Private objBGroup As New clsBPatronGroup

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Call Initialize()
            'Call BindScript()
            'If Not IsPostBack Then
            '    txtYearFrom.Text = DateTime.Now.Year.ToString()
            '    txtYearTo.Text = (DateTime.Now.Year - 4).ToString()
            '    Call BindData()
            'End If
        End Sub

        ' Method: Initialize
        Private Sub Initialize()
            '' Initialize object objBCollege
            'objBCollege.DBServer = Session("DBServer")
            'objBCollege.ConnectionString = Session("ConnectionString")
            'objBCollege.InterfaceLanguage = Session("InterfaceLanguage")
            'Call objBCollege.Initialize()

            '' Initialize object objBGroup
            'objBGroup.DBServer = Session("DBServer")
            'objBGroup.ConnectionString = Session("ConnectionString")
            'objBGroup.InterfaceLanguage = Session("InterfaceLanguage")
            'Call objBGroup.Initialize()
        End Sub

        ' Method: BindScript
        Private Sub BindScript()
            'Dim getId As String = "document.forms[0].ddlCollege.options[document.forms[0].ddlCollege.selectedIndex].value"
            'Dim getIntYearFrom As String = "document.forms[0].txtYearFrom.value"
            'Dim getIntYearTo As String = "document.forms[0].txtYearTo.value"
            'ddlCollege.Attributes.Add("OnChange", "parent.Display.location.href='WStatFacultyResult.aspx?ID=' + " & getId & " + '&intYearFrom=" & getIntYearFrom & "' + '&intYearTo=" & getIntYearTo & "';return false;")
            ''btnBack.Attributes.Add("OnClick", "parent.parent.Workform.location.href='WStatColleFaculGraClass.aspx';return(false);")


            'btnBack.Attributes.Add("OnClick", "parent.parent.Workform.location.href='WStatIndex.aspx';return(false);")
            'Page.RegisterClientScriptBlock("OnLoad", "<script language='javascript'>parent.Display.location.href='WStatFacultyResult.aspx?ID=' + " & getId & " + '&intYearFrom=" & getIntYearFrom & "' + '&intYearTo=" & getIntYearTo & "';</script>")
        End Sub

        ' Method: BindData
        Private Sub BindData()
            'Dim tblCollege As New DataTable

            'tblCollege = objBCollege.GetCollege

            'Dim tblGroupPatron As New DataTable
            ''objBGroup.LibID = clsSession.GlbSite
            'tblGroupPatron = objBGroup.GetPatronGroup()

            '' Write error
            'Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCollege.ErrorMsg, ddlLabel.Items(0).Text, objBCollege.ErrorCode)

            'If Not tblCollege Is Nothing Then
            '    If tblCollege.Rows.Count > 0 Then
            '        ddlCollege.DataSource = tblCollege
            '        ddlCollege.DataTextField = "College"
            '        ddlCollege.DataValueField = "ID"
            '        ddlCollege.DataBind()
            '    End If
            'End If

            'If Not tblGroupPatron Is Nothing Then
            '    If tblGroupPatron.Rows.Count > 0 Then
            '        ddlGroupPatron.DataSource = tblGroupPatron
            '        ddlGroupPatron.DataTextField = "Name"
            '        ddlGroupPatron.DataValueField = "ID"
            '        ddlGroupPatron.DataBind()
            '    End If
            'End If
        End Sub

        ' Method: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            'If Not objBCollege Is Nothing Then
            '    objBCollege.Dispose(True)
            '    objBCollege = Nothing
            'End If
        End Sub
    End Class
End Namespace