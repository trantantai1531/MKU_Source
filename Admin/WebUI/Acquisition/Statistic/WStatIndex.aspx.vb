' class : StatisticIndex
' Puspose: View Statistic Index
' Creator: Sondp
' CreatedDate: 02/02/2005
' Modification History:

Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WStatIndex
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents imgWStatisticAcqDAPDisplay As System.Web.UI.WebControls.ImageButton
        Protected WithEvents lnkWStatisticAcqDAPDisplay As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lblWStatisticAcqDAPDisplay As System.Web.UI.WebControls.Label
        Protected WithEvents imgWStatisticAcqBAPDisplay As System.Web.UI.WebControls.ImageButton
        Protected WithEvents lnkWStatisticAcqBAPDisplay As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lblWStatisticAcqBAPDisplay As System.Web.UI.WebControls.Label
        Protected WithEvents imgWStatisticLocationFrame As System.Web.UI.WebControls.ImageButton
        Protected WithEvents lnkWStatisticLocationFrame As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lblWStatisticLocationFrame As System.Web.UI.WebControls.Label
        Protected WithEvents imgWStatisticLanguage As System.Web.UI.WebControls.ImageButton
        Protected WithEvents lnkWStatisticLanguage As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lblWStatisticLanguage As System.Web.UI.WebControls.Label
        Protected WithEvents imgWStatisticAcqSource As System.Web.UI.WebControls.ImageButton
        Protected WithEvents lnkWStatisticAcqSource As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lblWStatisticAcqSource As System.Web.UI.WebControls.Label
        Protected WithEvents imgWStatisticPublishedCountry As System.Web.UI.WebControls.ImageButton
        Protected WithEvents lnkWStatisticPublishedCountry As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lblWStatisticPublishedCountry As System.Web.UI.WebControls.Label
        Protected WithEvents imgWStatisticAcqTop20Frame As System.Web.UI.WebControls.ImageButton
        Protected WithEvents lnkWStatisticAcqTop20Frame As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lblWStatisticAcqTop20Frame As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            'Check permission
            If Not CheckPemission(127) Then
                Call WriteErrorMssg(ddlLog.Items(0).Text)
            End If
        End Sub

        ' Page_Unload method
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not Session("month") Is Nothing Then
                Session("month") = Nothing
            End If
            If Not Session("year") Is Nothing Then
                Session("year") = Nothing
            End If
        End Sub

        'Private Sub imgWStatisticItemType_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgWStatisticItemType.Click
        '    Response.Redirect("WStatItemType.aspx")
        'End Sub

        'Private Sub imgWStatisticMedium_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgWStatisticMedium.Click
        '    Response.Redirect("WStatMedium.aspx")
        'End Sub

        'Private Sub imgStatLocationFrame_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgStatLocationFrame.Click
        '    Response.Redirect("WStatLocationFrame.aspx")
        'End Sub

        'Private Sub imgStatSource_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgStatSource.Click
        '    Response.Redirect("WStatSourceSelect.aspx")
        'End Sub

        'Private Sub imgWStatYear_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgWStatYear.Click
        '    Response.Redirect("WStatYear.aspx")
        'End Sub

        'Private Sub imgStatMonth_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgStatMonth.Click
        '    Response.Redirect("WStatMonthFrame.aspx")
        'End Sub

        'Private Sub imgStatDay_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgStatDay.Click
        '    Response.Redirect("WStatDayFrame.aspx")
        'End Sub

        'Private Sub imgStatClassCopyNumberSel_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgStatClassCopyNumberSel.Click
        '    Response.Redirect("WStatClassCopyNumberSel.aspx")
        'End Sub

        'Private Sub imgWStatClassItemIDSel_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgWStatClassItemIDSel.Click
        '    Response.Redirect("WStatClassItemIDSel.aspx")
        'End Sub

        'Private Sub imgStatLanguage_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgStatLanguage.Click
        '    Response.Redirect("WStatLanguage.aspx")
        'End Sub

        'Private Sub imgNationPub_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgNationPub.Click
        '    Response.Redirect("WStatNationPub.aspx")
        'End Sub

        'Private Sub imgStatTop20Frame_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgStatTop20Frame.Click
        '    Response.Redirect("WStatTop20Frame.aspx")
        'End Sub
    End Class
End Namespace