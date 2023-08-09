Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WCardDisplay
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

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call LoadDataPatronCard()
        End Sub

        ' Method: LoadDataPatronCard
        ' Popurse: Load data for print card of patron
        Sub LoadDataPatronCard()
            Dim tblRow As TableRow
            Dim tblCell() As TableCell
            Dim inti As Integer
            Dim intStart As Integer
            Dim intEnd As Integer
            Dim intPgCur As Integer
            Dim intPgSize As Integer

            lblNotFound.Visible = False
            Dim ArrCard()
            ArrCard = Session("ArrCards")

            If Not (ArrCard Is Nothing) Then
                Dim intPgCol As Byte
                If IsNumeric(Session("PgCols")) Then
                    intPgCol = CInt(Session("PgCols"))
                Else
                    intPgCol = 1
                End If
                If IsNumeric(Session("PageSize")) Then
                    intPgSize = CInt(Session("PageSize"))
                Else
                    intPgSize = 5
                End If
                If IsNumeric(Request.QueryString("PgCur")) Then
                    intPgCur = CInt(Request.QueryString("PgCur")) - 1
                Else
                    intPgCur = 0
                End If
                intStart = (intPgCur * intPgSize)
                intEnd = (intStart + intPgSize) - 1
                If intStart > UBound(ArrCard) Then
                    intStart = UBound(ArrCard)
                    intEnd = UBound(ArrCard)
                End If
                If (intEnd > UBound(ArrCard)) Then
                    intEnd = UBound(ArrCard)
                End If
                ReDim tblCell(intEnd - intStart + 1)
                For inti = intStart To intEnd
                    If (inti - intStart) Mod intPgCol = 0 Then
                        tblRow = New TableRow
                    End If
                    tblCell(inti - intStart) = New TableCell
                    tblCell(inti - intStart).HorizontalAlign = If((inti - intStart) Mod intPgCol = intPgCol - 1, HorizontalAlign.Right, HorizontalAlign.Left)
                    tblCell(inti - intStart).CssClass = "lbLabel"
                    tblCell(inti - intStart).Text = ArrCard(inti)
                    Try
                        tblRow.Cells.Add(tblCell(inti - intStart))
                        If inti = intEnd Or (inti - intStart) Mod intPgCol = intPgCol - 1 Then
                            tblResult.Rows.Add(tblRow)
                        End If
                    Catch ex As Exception
                        Page.RegisterClientScriptBlock("JSNoData", "<script language='javascript'>alert('" & lblNote.Text & "');</script>")
                    End Try
                Next
            Else
                lblNotFound.Visible = True
            End If
        End Sub
    End Class
End Namespace