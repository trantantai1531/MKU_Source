Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WCardTaskBar
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

        Dim intSumrec As Integer

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call BindData()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call ShowResult()
            End If
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("JScriptSelf", "<script language = 'javascript' src = 'js/WCards.js'></script>")

            btnNext.Attributes.Add("OnClick", "NextAction(" & CStr(intSumrec) & ");return false;")
            btnBack.Attributes.Add("OnClick", "BackAction(" & CStr(intSumrec) & ");return false;")
            btnFirst.Attributes.Add("OnClick", "FirstAction(" & CStr(intSumrec) & ");return false;")
            btnEnd.Attributes.Add("OnClick", "EndAction(" & CStr(intSumrec) & ");return false;")

            txtRec.Attributes.Add("OnChange", "Action(" & CStr(intSumrec) & ");return false;")

            btnConfirm.Attributes.Add("OnClick", "ConfirmPrint();return false;")
            btnRePrint.Attributes.Add("OnClick", "Rechoose();return false;")
            btnPrint.Attributes.Add("OnClick", "printDocument();return false;")
        End Sub

        ' BindData method
        Private Sub BindData()
            Dim ArrCard()
            ArrCard = Session("ArrCards")
            If Not (ArrCard Is Nothing) Then
                If IsNumeric(Session("PageSize")) Then
                    intSumrec = (UBound(ArrCard) + 1) \ CInt(Session("PageSize"))
                    If ((UBound(ArrCard) + 1) Mod CInt(Session("Pagesize"))) <> 0 Then
                        intSumrec = intSumrec + 1
                    End If
                Else
                    intSumrec = 1
                End If
            Else
                intSumrec = 1
            End If
        End Sub

        ' ShowResult method
        Private Sub ShowResult()
            Dim ArrCard()
            ArrCard = Session("ArrCards")
            If Not (ArrCard Is Nothing) Then
                If UBound(ArrCard) = -1 Then
                    txtRec.Text = "0"
                    lblSumRec.Text = "0"
                Else
                    txtRec.Text = "1"
                    If IsNumeric(Session("Pagesize")) Then
                        If ((UBound(ArrCard) + 1) Mod CInt(Session("Pagesize"))) <> 0 Then
                            lblSumRec.Text = CStr((UBound(ArrCard) + 1) \ CInt(Session("Pagesize")) + 1)
                        Else
                            lblSumRec.Text = CStr((UBound(ArrCard) + 1) \ CInt(Session("Pagesize")))
                        End If
                    Else
                        lblSumRec.Text = "1"
                    End If
                End If
            End If
        End Sub
    End Class
End Namespace