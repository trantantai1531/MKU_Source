Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WIdxTaskBar
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        'Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call BindJavascript()
            If Not Page.IsPostBack Then
                ProcessPage()
            End If
        End Sub

        ' Method: BindJavascript
        ' Purpose: Bind javascript foa all control need
        Private Sub BindJavascript()
            Dim TblLoc As New DataTable
            Dim colBibliography As New Collection
            Dim intIDIDX As Integer

            colBibliography = Session("colPara")

            If CStr(Request.QueryString("intIDXID")) & "" <> "" Then
                intIDIDX = CInt(Request.QueryString("intIDXID"))
            Else
                intIDIDX = 0
            End If

            Page.RegisterClientScriptBlock("JSCommon", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("JSSelf", "<script language = 'javascript' src = '../js/Bibliography/WIDXTaskbar.js'></script>")

            lnkOtherPrint.NavigateUrl = "javascript:parent.Workform.location.href='WIDXViewForm.aspx?intIDXID=" & intIDIDX & "';parent.Sentform.location.href='../WNothing.htm';"

            btnIdx.Attributes.Add("onclick", "javascript:parent.Workform.location.href='WIDXIdx.aspx?FieldSToIndex='  + document.forms[0].txtFieldSToIndex.value + '&BibliographyCode=" & colBibliography.Item("intIDXID") & "'; return false;")

            btnFirst.Attributes.Add("OnClick", "MoveFirst('" & ddlLabel.Items(1).Text & "'); return false;")
            btnBack.Attributes.Add("OnClick", "MovePrev('" & ddlLabel.Items(1).Text & "'); return false;")
            btnNext.Attributes.Add("OnClick", "MoveNext('" & ddlLabel.Items(2).Text & "'); return false;")
            btnLast.Attributes.Add("OnClick", "MoveLast('" & ddlLabel.Items(2).Text & "'); return false;")

            txtCurrentpage.Attributes.Add("OnChange", "Goto('" & ddlLabel.Items(3).Text & "', '" & ddlLabel.Items(0).Text & "');")
        End Sub

        ' ProcessPage method
        ' Purpose: Draw process in page
        Private Sub ProcessPage()
            Dim colPara As New Collection
            Dim intTotalPage As Integer

            colPara = Session("colPara")
            If IsArray(colPara.Item("ItemIDArr")) Then
                intTotalPage = Math.Ceiling(UBound(colPara.Item("ItemIDArr")) / colPara.Item("intPageSize"))
            Else
                intTotalPage = 0
            End If
            lblTotal.Text = "0"
            If intTotalPage <> 0 Then
                hidMaxId.Value = intTotalPage
                lblTotal.Text = intTotalPage
                txtCurrentpage.Text = 1
                Page.RegisterClientScriptBlock("JSGo", "<script language = 'javascript'>parent.Workform.location.href='WIDXView.aspx?intPg=1';</script>")
            Else
                btnFirst.Enabled = False
                btnBack.Enabled = False
                btnIdx.Enabled = False
                btnLast.Enabled = False
                btnNext.Enabled = False
            End If
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace