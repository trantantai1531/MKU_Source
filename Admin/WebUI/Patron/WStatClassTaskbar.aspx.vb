' Class: WStatClassTaskbar
' Puspose: Show statistic by class
' Creator: Sondp
' CreatedDate: 21-1-2005
' Modification History:
'   - 02/05/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Patron
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WStatClassTaskbar
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
        Private objBCollege As New clsBCollege

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            If Not IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Method: Initialize
        Private Sub Initialize()
            ' Initialize objBCollege object
            objBCollege.DBServer = Session("DBServer")
            objBCollege.ConnectionString = Session("ConnectionString")
            objBCollege.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCollege.Initialize()
        End Sub

        ' Method: BindJS
        Private Sub BindJS()
            ddlCollege.Attributes.Add("OnChange", "parent.Hidden.location.href='WStatClassHidden.aspx?CollegeID=' + document.forms[0].ddlCollege.options[forms[0].ddlCollege.selectedIndex].value;return false;")
            ddlFaculty.Attributes.Add("OnChange", "parent.Display.location.href='WStatClassResult.aspx?FacultyID=' + document.forms[0].ddlFaculty.options[forms[0].ddlFaculty.selectedIndex].value;return false;")
            btnBack.Attributes.Add("OnClick", "parent.parent.Workform.location.href='WStatColleFaculGraClass.aspx';return(false);")
        End Sub

        ' Method: BindData
        Private Sub BindData()
            Dim tblCollege As New DataTable

            ' Get all college
            tblCollege = objBCollege.GetCollege

            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(2).Text, objBCollege.ErrorMsg, ddlLabel.Items(1).Text, objBCollege.ErrorCode)

            If Not tblCollege Is Nothing Then
                If tblCollege.Rows.Count > 0 Then
                    ddlCollege.DataSource = InsertOneRow(tblCollege, ddlLabel.Items(0).Text)
                    ddlCollege.DataTextField = "College"
                    ddlCollege.DataValueField = "ID"
                    ddlCollege.DataBind()
                End If
            End If
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBCollege Is Nothing Then
                objBCollege.Dispose(True)
                objBCollege = Nothing
            End If
        End Sub
    End Class
End Namespace