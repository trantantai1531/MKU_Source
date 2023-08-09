' class: WComprehReportBookTaskBar
' Puspose: Control show page
' Creator: Sondp
' CreatedDate: 11/04/2005
' Modification History:

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WComprehReportBookT
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
            If Not Session("Report") Is Nothing Then
                Dim collectReport As New Collection
                collectReport = Session("Report")
                hdMaxPage.Value = collectReport.Item("<$MAXPAGE$>")
                lblMaxPage.Text = hdMaxPage.Value
                txtCurrentPage.Text = 1
                collectReport = Nothing
            End If
            ' Must put BindScript methord here
            Call BindScript()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WComprehensiveReportBookTJs", "<script language='javascript' src='../Js/ACQ/WComprehReportBook.js'></script>")
            btnPrevious.Attributes.Add("OnClick", "PreviousClick(" & hdMaxPage.Value & ",document.forms[0].txtCurrentPage.value,'" & ddlLabel.Items(1).Text & "');return(false);")
            btnNext.Attributes.Add("OnClick", "NextClick(" & hdMaxPage.Value & ", document.forms[0].txtCurrentPage.value,'" & ddlLabel.Items(2).Text & "');return(false);")
            txtCurrentPage.Attributes.Add("onChange", "CurrentPageChange(" & hdMaxPage.Value & ",document.forms[0].txtCurrentPage.value,'" & ddlLabel.Items(0).Text & "','" & ddlLabel.Items(3).Text & "');")
            'txtCurrentPage.Attributes.Add("onKeyDown", "if(event.keyCode == 13 || event.which == 13 ) {CurrentPageChange(" & hdMaxPage.Value & ",document.forms[0].txtCurrentPage.value,'" & ddlLabel.Items(0).Text & "','" & ddlLabel.Items(3).Text & "');}")
            hrfRequest.NavigateUrl = "javascript:parent.parent.mainacq.location.href='WComprehReportBookS.aspx';"
        End Sub
    End Class
End Namespace