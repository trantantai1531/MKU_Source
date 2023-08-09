' class WSetDefaultValue
' Puspose: Set default value 
' Creator: Sondp
' CreatedDate: 28-01-2005
' Modification History:

Imports eMicLibAdmin.BusinessRules.Patron

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WSetDefaultValue
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblCode As System.Web.UI.WebControls.Label
        Protected WithEvents txtCode As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblFirstName As System.Web.UI.WebControls.Label
        Protected WithEvents txtFirstName As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblLastName As System.Web.UI.WebControls.Label
        Protected WithEvents txtLastName As System.Web.UI.WebControls.TextBox


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBPatronGroup As New clsBPatronGroup

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
            Call BindData()
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Initialize objBPatronGroup object
            objBPatronGroup.DBServer = Session("DBServer")
            objBPatronGroup.ConnectionString = Session("ConnectionString")
            objBPatronGroup.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPatronGroup.Initialize()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WSetDefaultValueJs", "<script language='javascript' src='js/WSetDefaultValue.js'></script>")
            Me.RegisterCalendar("..")
            SetOnclickCalendar(hrfExpiredDate, txtExpiredDate, ddlLabel.Items(3).Text)
            SetOnclickCalendar(hrfLastModifiedDate, txtLastModifiedDate, ddlLabel.Items(3).Text)
            SetOnclickCalendar(hrfValidDate, txtValidDate, ddlLabel.Items(3).Text)

            btnReset.Attributes.Add("OnClick", "ResetForm();return false;")
            btnSetUp.Attributes.Add("OnClick", "SetUpValue();self.close();return false;")
            btnClose.Attributes.Add("OnClick", "self.close();return false;")
        End Sub

        ' BindData method
        Private Sub BindData()
            Dim tblTemp As DataTable

            ' Get data for PatronGroup
            tblTemp = objBPatronGroup.GetPatronGroup

            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlPatronGroupID.DataSource = InsertOneRow(tblTemp, ddlLabel.Items(4).Text)
                ddlPatronGroupID.DataTextField = "Name"
                ddlPatronGroupID.DataValueField = "ID"
                ddlPatronGroupID.DataBind()
            End If

            txtValidDate.Text = Session("ToDay")
            txtExpiredDate.Text = Session("ToDay")
            txtLastModifiedDate.Text = Session("ToDay")
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBPatronGroup Is Nothing Then
                    objBPatronGroup.Dispose(True)
                    objBPatronGroup = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace