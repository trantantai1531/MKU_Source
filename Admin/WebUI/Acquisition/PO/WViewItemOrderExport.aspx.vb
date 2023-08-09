Imports System.Data
Imports System.IO
Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WViewItemOrderExport
        Inherits System.Web.UI.Page

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
            If Not Page.IsPostBack Then
                If Not Session("Export") Is Nothing Then
                    Dim tbl As New DataTable
                    Select Case Request.QueryString("xType") & ""
                        Case 0 ' Excel
                            tbl = Session("Export")
                            If Not tbl Is Nothing Then
                                dgr.DataSource = tbl
                                dgr.DataBind()
                            End If
                        Case 1 ' DOC
                    End Select
                End If
            End If

        End Sub

        Private Sub btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn.Click

            Dim stringWrite As New StringWriter
            Dim htmlWrite As New HtmlTextWriter(stringWrite)
            Response.Clear()
            Response.Buffer = False
            Me.EnableViewState = False
            Response.AddHeader("content-disposition", "attachment;filename=FileName.xls")
            Response.Charset = ""
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Response.ContentType = "application/vnd.xls"
            Try
                dgr.RenderControl(htmlWrite)
                Response.Write(stringWrite)
            Catch ex As Exception
            End Try
        End Sub
    End Class
End Namespace