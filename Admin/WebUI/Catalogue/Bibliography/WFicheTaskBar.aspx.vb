Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WFicheTaskBar
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

        'Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Bind javascript for all control need
            Call BindJavascript()
            If Not Page.IsPostBack Then
                Call ProcessPage()
            End If
        End Sub

        'Methord: BindJavascript
        Private Sub BindJavascript()
            Dim TblLoc As New DataTable
            Page.RegisterClientScriptBlock("JSCommon", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("JSSelf", "<script language = 'javascript' src = '../js/Bibliography/WFicheTaskbar.js'></script>")
            lnkOtherPrint.NavigateUrl = "javascript:parent.Workform.location.href='WFicheForm.aspx';parent.Sentform.location.href='../WNothing.htm';"

            btnFirst.Attributes.Add("OnClick", "MoveFirst('" & ddlLabel.Items(1).Text & "'); return false;")
            btnBack.Attributes.Add("OnClick", "MovePrev('" & ddlLabel.Items(1).Text & "'); return false;")
            btnNext.Attributes.Add("OnClick", "MoveNext('" & ddlLabel.Items(2).Text & "'); return false;")
            btnLast.Attributes.Add("OnClick", "MoveLast('" & ddlLabel.Items(2).Text & "'); return false;")

            btnPrint.Attributes.Add("OnClick", "printDocument();return false;")

            txtCurrentpage.Attributes.Add("OnChange", "Goto('" & ddlLabel.Items(3).Text & "', '" & ddlLabel.Items(0).Text & "');")

        End Sub

        'Methor: ProcessPage
        Private Sub ProcessPage()
            Dim colPara As New Collection
            Dim intTotalPage As Integer
            Dim strJs As String
            colPara = Session("colPara")
            If IsArray(Session("FicheID")) Then
                intTotalPage = Math.Ceiling(UBound(Session("FicheID")) / colPara.Item("PageSize"))
            Else
                intTotalPage = 0
            End If
            If intTotalPage <> 0 Then
                lblTotal.Text = intTotalPage
                hidMaxId.Value = intTotalPage
                Page.RegisterClientScriptBlock("JSGo", "<script language = 'javascript'>parent.Workform.location.href='WFichePrint.aspx?intPage=1';</script>")
            Else
                btnFirst.Enabled = False
                btnBack.Enabled = False
                btnLast.Enabled = False
                btnNext.Enabled = False
                txtCurrentpage.Enabled = False
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
                If isDisposing Then
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace