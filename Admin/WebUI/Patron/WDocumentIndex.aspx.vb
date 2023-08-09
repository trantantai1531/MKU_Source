Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WDocumentIndex
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents ImageButton1 As System.Web.UI.WebControls.ImageButton


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not CheckPemission() Then
                Call WritePermErrorMssg()
            End If
        End Sub

        ' Managerment College
        'Private Sub ImgCollege_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgCollege.Click
        '    Response.Redirect("WCollege.aspx")
        'End Sub

        '' Managerment Export
        'Private Sub ImgExport_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgExport.Click
        '    Response.Redirect("WExport.aspx")
        'End Sub

        '' Managerment Falculty
        'Private Sub ImgFaculty_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgFaculty.Click
        '    Response.Redirect("WFaculty.aspx")
        'End Sub

        '' Managerment Import
        'Private Sub ImgImport_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgImport.Click
        '    Response.Redirect("WImports.aspx")
        'End Sub

        '' Managerment Jobs
        'Private Sub ImgJobs_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgJobs.Click
        '    Response.Redirect("WOccupation.aspx")
        'End Sub

        '' Managerment Level
        'Private Sub ImgLevel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgLevel.Click
        '    Response.Redirect("WEducation.aspx")
        'End Sub

        '' Managerment Potron CV
        'Private Sub ImgManDocs_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgManDocs.Click
        '    Response.Redirect("WPatron.aspx")
        'End Sub

        '' Managerment Ethnic
        'Private Sub ImgNation_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgNation.Click
        '    Response.Redirect("WEthnic.aspx")
        'End Sub

        '' Managerment Province
        'Private Sub ImgProvince_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgProvince.Click
        '    Response.Redirect("WProvince.aspx")
        'End Sub

        '' Managerment Patron Group
        'Private Sub ImgReaders_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgReaders.Click
        '    Response.Redirect("WPatronGroup.aspx")
        'End Sub

        '' Managerment Simple Search
        'Private Sub ImgSearch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgSearch.Click
        '    Response.Redirect("WSimpleSearch.aspx")
        'End Sub

        '' Managerment ShapeExport
        'Private Sub ImgShapeExport_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgShapeExport.Click
        '    Response.Redirect("WEETemplate.aspx")
        'End Sub

        '' Managerment ShapeImport
        'Private Sub ImgShapeImport_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgShapeImport.Click
        '    Response.Redirect("WIETemplate.aspx")
        'End Sub

        '' Managerment Queue Patron
        'Private Sub ImgQueue_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgQueue.Click
        '    Response.Redirect("WQueuList.aspx")
        'End Sub
    End Class
End Namespace