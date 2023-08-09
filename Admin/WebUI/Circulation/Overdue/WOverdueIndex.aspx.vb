' Class: WOverdueIndex
' Puspose: Show overdue index page
' Creator: Oanhtn
' CreatedDate: 27/05/2005
' Modification History:

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WOverdueIndex
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

        ' Event: imgOverdueTemplate_Click
        ' Purpose: Management OverdueTemplate
        'Private Sub imgOverdueTemplate_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgOverdueTemplate.Click
        '    Response.Redirect("WOverdueTemplate.aspx")
        'End Sub

        '' Event: imgOverdueList_Click
        '' Purpose: Show overdue items list
        'Private Sub imgOverdueList_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgOverdueList.Click
        '    Response.Redirect("WOverdueList.aspx")
        'End Sub

        '' Event: imgOverduePrintLetter_Click
        '' Purpose: Print overdue letter
        'Private Sub imgOverduePrintLetter_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgOverduePrintLetter.Click
        '    Response.Redirect("WOverduePrintLetter.aspx")
        'End Sub

        '' Event: imgOrverdueSendMail_Click
        '' Purpose: Send overdue email
        'Private Sub imgOrverdueSendMail_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgOrverdueSendMail.Click
        '    Response.Redirect("WOrverdueSendMail.aspx")
        'End Sub
    End Class
End Namespace