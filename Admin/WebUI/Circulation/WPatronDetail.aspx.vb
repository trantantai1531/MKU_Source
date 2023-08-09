' Class: WPatronDetail
' Purpose: Get Item information (Main infor and holding infor)
' Creater: Tuanhv
' CreatedDate: 26/8/2004
' Modify history:
'   17/04/2005 by Oanhtn: review & update

Imports eMicLibAdmin.WebUI.Common
Imports eMicLibAdmin.BusinessRules.Circulation

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WPatronDetail
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblSex As System.Web.UI.WebControls.Label
        Protected WithEvents lblEducationLevel As System.Web.UI.WebControls.Label
        Protected WithEvents lblAddress As System.Web.UI.WebControls.Label
        Protected WithEvents lblTelePhone As System.Web.UI.WebControls.Label
        Protected WithEvents lblMobile As System.Web.UI.WebControls.Label

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBPatron As New clsBPatron
        Private arrLabel(30) As String

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call BindScript()
            Call Initialize()
            Call BindData()
        End Sub

        ' Method: Initialize
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            Response.Expires = 0

            ' Init objBPatron object
            objBPatron.InterfaceLanguage = Session("InterfaceLanguage")
            objBPatron.DBServer = Session("DBServer")
            objBPatron.ConnectionString = Session("ConnectionString")
            Call objBPatron.Initialize()
        End Sub

        ' Method: BindScript
        ' Purpose: Bind javascript
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
        End Sub

        ' Method: BindData
        Private Sub BindData()
            ' Declare variables
            Dim intItemID As Integer
            Dim intCount As Integer = 0
            Dim intIndex As Integer
            Dim tblTemp As DataTable
            Dim tblItem As DataTable
            Call GetDataToArr()

            ' Retrieve all Item infor
            If Request("PatronCode") <> "" Then
                tblMainInfor.CellSpacing = 0
                tblMainInfor.CellPadding = 2
                objBPatron.PatronCode = Trim(Request("PatronCode"))
                objBPatron.FullName = ""
                tblTemp = objBPatron.GetPatronInfor
                'Chinhnh modify 20080822
                tblTemp.Columns.Remove("ExpDate")
                ' End modify by Chinhnh
                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPatron.ErrorMsg, ddlLabel.Items(0).Text, objBPatron.ErrorCode)

                If Not tblTemp Is Nothing Then
                    intCount = tblTemp.Columns.Count
                End If
            End If

            ' Draw the table
            If intCount > 0 Then
                Dim tblRow As TableRow
                Dim tblCell1 As TableCell
                Dim tblCell2 As TableCell
                For intIndex = 0 To 19
                    If intIndex = 0 Then
                        tblRow = New TableRow
                        tblCell1 = New TableCell
                        tblCell1.ColumnSpan = 3
                        tblCell1.HorizontalAlign = HorizontalAlign.Left
                        tblCell1.CssClass = "lbSubFormTitle"
                        tblCell1.Width = Unit.Percentage(100%)
                        tblCell1.Controls.Add(New LiteralControl(Label2.Text))
                        tblRow.Cells.Add(tblCell1)
                        tblMainInfor.Rows.Add(tblRow)
                    End If

                    If intIndex = 9 Then
                        tblRow = New TableRow
                        tblCell1 = New TableCell
                        tblCell1.ColumnSpan = 3
                        tblCell1.HorizontalAlign = HorizontalAlign.Left
                        tblCell1.CssClass = "lbSubFormTitle"
                        tblCell1.Width = Unit.Percentage(100%)
                        tblCell1.Controls.Add(New LiteralControl(Label3.Text))
                        tblRow.Cells.Add(tblCell1)
                        tblMainInfor.Rows.Add(tblRow)
                    End If
                    If intIndex = 16 Then
                        tblRow = New TableRow
                        tblCell1 = New TableCell
                        tblCell1.ColumnSpan = 3
                        tblCell1.HorizontalAlign = HorizontalAlign.Left
                        tblCell1.CssClass = "lbSubFormTitle"
                        tblCell1.Width = Unit.Percentage(100%)
                        tblCell1.Controls.Add(New LiteralControl(Label4.Text))
                        tblRow.Cells.Add(tblCell1)
                        tblMainInfor.Rows.Add(tblRow)
                    End If
                    tblRow = New TableRow
                    tblCell1 = New TableCell
                    tblCell1.ColumnSpan = 1
                    tblCell1.HorizontalAlign = HorizontalAlign.Right
                    tblCell1.CssClass = "lbLabel"
                    tblCell1.Width = Unit.Percentage(30%)
                    tblCell2 = New TableCell
                    tblCell2.ColumnSpan = 1
                    tblCell2.CssClass = "lbLabel"
                    tblCell2.Width = Unit.Percentage(70%)
                    If Not (tblTemp.Rows(0).Item(intIndex)) Is DBNull.Value Then
                        If CStr(tblTemp.Rows(0).Item(intIndex)) <> "" And CStr(tblTemp.Rows(0).Item(intIndex)) <> " " Then
                            Dim obj As New Label
                            Dim str As String
                            str = CStr(tblTemp.Rows(0).Item(intIndex))

                            If intIndex = 3 Then
                                If CInt(tblTemp.Rows(0).Item(intIndex)) = 1 Then
                                    str = Label5.Text
                                Else
                                    str = Label6.Text
                                End If
                            End If
                            tblCell1.Controls.Add(New LiteralControl(arrLabel(intIndex + 1)))
                            tblRow.Cells.Add(tblCell1)
                            tblCell2.Controls.Add(New LiteralControl(str))
                            tblCell2.Width = Unit.Percentage(40%)
                            tblCell2.Font.Bold = True
                            tblRow.Cells.Add(tblCell2)

                            Dim tblCell3 As New TableCell
                            If intIndex = 0 Then
                                If Not tblTemp.Rows(0).Item("Portrait") Is DBNull.Value Then
                                    Dim strURL As String = "../Images/Card/" & Trim(CStr(tblTemp.Rows(0).Item("Portrait")))
                                    tblCell3.Controls.Add(New LiteralControl("<img src='../Common/ShowPic.aspx?intw=90&inth=120&Url=" & strURL & "'>"))
                                Else
                                    tblCell3.Controls.Add(New LiteralControl("<img src='../Images/Card/Empty.gif'>"))
                                End If

                            End If
                            tblCell3.HorizontalAlign = HorizontalAlign.Center
                            tblCell3.RowSpan = 7
                            tblRow.Cells.Add(tblCell3)
                            tblCell3.VerticalAlign = VerticalAlign.Top

                        End If
                    End If
                    tblMainInfor.Rows.Add(tblRow)
                Next
                'Page.RegisterClientScriptBlock("setBackPatronCode", "<script language='javascript'>opener.parent." & Session("CheckForm") & ".document.forms[0].txtPatronCode.value= '" & objBPatron.PatronCode & "' </script>")
            End If
        End Sub

        ' Method: GetDataToArr
        ' Purpose: Get data from controls Label to arrLabel()
        Sub GetDataToArr()
            arrLabel(1) = Trim(lbl1.Text)
            arrLabel(2) = Trim(lbl2.Text)
            arrLabel(3) = Trim(lbl3.Text)
            arrLabel(4) = Trim(lbl4.Text)
            arrLabel(5) = Trim(lbl5.Text)
            arrLabel(6) = Trim(lbl6.Text)
            arrLabel(7) = Trim(lbl7.Text)
            arrLabel(8) = Trim(lbl8.Text)
            arrLabel(9) = Trim(lbl9.Text)
            arrLabel(10) = Trim(lbl10.Text)
            arrLabel(11) = Trim(lbl11.Text)
            arrLabel(12) = Trim(lbl12.Text)
            arrLabel(13) = Trim(lbl13.Text)
            arrLabel(14) = Trim(lbl14.Text)
            arrLabel(15) = Trim(lbl15.Text)
            arrLabel(16) = Trim(lbl16.Text)
            arrLabel(17) = Trim(lbl17.Text)
            arrLabel(17) = Trim(lbl17.Text)
            arrLabel(18) = Trim(lbl18.Text)
            arrLabel(19) = Trim(lbl19.Text)
            arrLabel(20) = Trim(lbl20.Text)
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBPatron Is Nothing Then
                    objBPatron.Dispose(True)
                    objBPatron = Nothing
                End If
                arrLabel = Nothing
            Finally
                MyBase.Dispose()
            End Try
        End Sub
    End Class
End Namespace