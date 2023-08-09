Imports eMicLibAdmin.BusinessRules.Patron

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WBarcodes
        Inherits clsWBase
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblDisplay As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region


        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Dim objArrRet As Object
            Dim inti As Integer
            Dim intNOR As Integer
            Dim intStartID As Integer
            Dim intStopID As Integer
            Dim NumPage As Integer
            Dim ImgType As Integer
            Dim rotate As Short
            Dim intPageSize As Integer
            Dim PageCount As Integer
            Dim intCol As Integer
            Dim tblRow As TableRow
            Dim tblCell() As TableCell
            intPageSize = CInt(Session("OnPage"))
            ImgType = CInt(Session("ImgType"))
            rotate = CInt(Session("rotate"))
            NumPage = CInt(Session("NumPage"))
            intCol = CInt(Session("Col"))
            objArrRet = Session("BarCode")
            If IsArray(objArrRet) Then
                intNOR = UBound(objArrRet)
                PageCount = Math.Round(intNOR / intPageSize - 0.5)
                If (intNOR) Mod intPageSize > 0 Then
                    PageCount = PageCount + 1
                    Session("PageCount") = CInt(PageCount)
                End If
                If NumPage > PageCount Then
                    NumPage = PageCount
                End If
                If NumPage < 1 Then
                    NumPage = 1
                End If
                intStartID = (NumPage - 1) * intPageSize
                intStopID = NumPage * intPageSize - 1
                If intStartID > intNOR Then
                    intStartID = intNOR
                    intStopID = intNOR
                End If
                If intStopID > intNOR Then
                    intStopID = intNOR
                End If
                ReDim tblCell(intStopID - intStartID)
                For inti = intStartID To intStopID
                    If (inti - intStartID) Mod intCol = 0 Then
                        tblRow = New TableRow
                    End If
                    tblCell(inti - intStartID) = New TableCell
                    tblCell(inti - intStartID).HorizontalAlign = HorizontalAlign.Left
                    tblCell(inti - intStartID).CssClass = "lbLabel"
                    Session("bc" & inti) = Nothing
                    Session("bc" & inti) = objArrRet(inti)
                    'Chinhnh modify 13-08-2008: Border=0 => Border=1
                    tblCell(inti - intStartID).Text = "<IMG src=""../Common/WPrintBarCode.aspx?i=" & inti & "&ImgType=" & ImgType & " &rotate=" & rotate & """ Border=1>"
                    Try
                        tblRow.Cells.Add(tblCell(inti - intStartID))
                        If inti = intStopID Or (inti - intStartID) Mod intCol = intCol - 1 Then
                            tblView.Rows.Add(tblRow)
                        End If
                    Catch ex As Exception
                    End Try
                Next
            Else
                lblNotFound.Visible = True
            End If
        End Sub
    End Class
End Namespace