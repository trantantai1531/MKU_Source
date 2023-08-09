' Class: WAccountIndex
' Puspose: Show Accounting index page
' Creator: Oanhtn
' CreatedDate: 27/05/2005
' Modification History:

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WAccountIndex
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

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            If Not CheckPemission() Then
                Call WritePermErrorMssg()
            End If
        End Sub

        ' Paid
        '    Private Sub imgPaid_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgPaid.Click
        '        Response.Redirect("WAccountManagement.aspx?Display=0")
        '    End Sub

        '    ' MustPaid
        '    Private Sub imgMustPaid_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgMustPaid.Click
        '        Response.Redirect("WAccountManagement.aspx?Display=1")
        '    End Sub

        '    ' Report
        '    Private Sub imgReport_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgReport.Click
        '        Response.Redirect("WAccountManagement.aspx?Display=2")
        '    End Sub
    End Class
End Namespace