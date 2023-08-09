' Class: WStatTop20
' Puspose: Show statistic by top 20 entries
' Creator: Sondp
' CreatedDate: 21-1-2005
' Modification History:
'   - 02/05/2005 by Oanhtn: review

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WStatTop20
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

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call BindJS()
        End Sub

        ' Method: BindJS
        Private Sub BindJS()
            btnBack.Attributes.Add("OnClick", "parent.Workform.location.href='WStatIndex.aspx'; return(false);")
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            If Not CheckPemission(52) Then
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub

        ' Method: btnStatistic_Click
        Private Sub btnStatistic_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnStatistic.Click
            Response.Redirect("WStatTop20Result.aspx?sign=" & ddlTop20.SelectedValue)
        End Sub
    End Class
End Namespace