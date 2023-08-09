Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WBarcodesTaskBar
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
        Dim NumPage As Integer
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call BindScript()
            If Not Page.IsPostBack Then
                Dim ArrRet As Object
                Dim NOR As Integer
                Dim PageSize As Integer
                PageSize = CInt(Session("OnPage"))
                ArrRet = Session("BarCode")
                If IsArray(ArrRet) Then
                    Dim PageCount As Double
                    NOR = UBound(ArrRet)
                    PageCount = Math.Round(NOR / PageSize - 0.5)
                    If (NOR) Mod PageSize > 0 Then
                        PageCount = PageCount + 1
                        Session("PageCount") = CInt(PageCount)
                    End If
                End If
                txtCurrentPage.Text = CStr(Session("NumPage"))
            End If
            lblCurrentPage.Text = CStr(Session("PageCount"))
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WBarcodesTaskBarJs", "<script language='javascript' src='js/WBarcodeSearch.js'></script>")
            hrfBarcode.NavigateUrl = "javascript:GoPreviousPage();"
            btnPrint.Attributes.Add("OnClick", "printDocument();return false;")
            SetCheckNumber(txtCurrentPage, lblError.Text, "1")
        End Sub
        Private Sub btnPrevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrevious.Click
            NumPage = CInt(Session("NumPage"))
            If NumPage <= 1 Then
                NumPage = 1
            Else
                NumPage = NumPage - 1
            End If
            Session("NumPage") = NumPage
            txtCurrentPage.Text = CStr(Session("NumPage"))
            lblCurrentPage.Text = CStr(Session("PageCount"))
            Page.RegisterClientScriptBlock("PreviousLoadDataJs", "<script language = 'javascript'>parent.result.location.href='WBarcodes.aspx'</script>")
        End Sub

        Private Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.Click
            NumPage = CInt(Session("NumPage"))
            If NumPage >= CInt(Session("PageCount")) Then
                NumPage = CInt(Session("PageCount"))
            Else
                NumPage = NumPage + 1
            End If
            Session("NumPage") = NumPage
            txtCurrentPage.Text = CStr(Session("NumPage"))
            lblCurrentPage.Text = CStr(Session("PageCount")) & " "
            Page.RegisterClientScriptBlock("NextLoadData", "<script language = 'javascript'>parent.result.location.href='WBarcodes.aspx'</script>")
        End Sub

        Private Sub btnJump_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnJump.Click
            lblCurrentPage.Text = CStr(Session("PageCount")) & " "
            Page.RegisterClientScriptBlock("JumpLoadData", "<script language = 'javascript'>parent.result.location.href='WBarcodes.aspx?i='+GenRanNum(7)</script>")
        End Sub

        Private Sub txtCurrentPage_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCurrentPage.TextChanged
            Dim strID As String
            strID = txtCurrentPage.Text.Trim
            If strID = "" Or Not IsNumeric(strID) Or CInt(strID) < 0 Or CInt(strID) > Session("PageCount") Then
                txtCurrentPage.Text = Session("NumPage")
                Exit Sub
            End If
            Session("NumPage") = txtCurrentPage.Text.Trim
            lblCurrentPage.Text = CStr(Session("PageCount")) & " "
            Page.RegisterClientScriptBlock("NextLoadData", "<script language = 'javascript'>parent.result.location.href='WBarcodes.aspx'</script>")
        End Sub
    End Class
End Namespace