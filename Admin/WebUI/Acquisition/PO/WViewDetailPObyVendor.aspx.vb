' Class: WViewDetailPObyVendor
' Puspose: View all contracts excuted by this vendor
' Creator: Sondp
' CreatedDate: 07/04/2005
' Modification History:
'   - 10/04/2005 by Oanhtn: review & update

Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WViewDetailPObyVendor
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblPOList As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private objBV As New clsBVendor

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Me.ShowWaitingOnPage("", "../..")
            Call BindJS()
            If Not Page.IsPostBack Then
                If Not Request.QueryString("VendorID") & "" = "" Then
                    If IsNumeric(Request.QueryString("VendorID")) Then
                        Call BindData(CInt(Request.QueryString("VendorID")))
                    End If
                End If
            End If
            Me.ShowWaitingOnPage("", "", True)
        End Sub

        ' Method: Initialize
        ' Purpose: init all neccessary objects
        Private Sub Initialize()
            ' Initialize objBV object
            objBV.InterfaceLanguage = Session("InterfaceLanguage")
            objBV.DBServer = Session("DBServer")
            objBV.ConnectionString = Session("ConnectionString")
            Call objBV.Initialize()
        End Sub

        ' Method: BindJS
        ' Purpose: include js functions
        Private Sub BindJS()
            btnClose.Attributes.Add("OnClick", "self.close(); return false;")
        End Sub

        ' Method: BindDate
        ' Purpose: binddata
        ' Input: intVendorID
        Private Sub BindData(ByVal intVendorID As Integer)
            Dim tblTemp As DataTable
            Dim intCount, intStatus, intSTK, intDTK, intHTDH, intHTKDH, intKN, intHB, intGG As Integer
            Dim dblSumValue As Double = 0
            Dim row As TableRow
            Dim col As TableCell

            objBV.VendorID = intVendorID
            tblTemp = objBV.GetContract
            If Not tblTemp Is Nothing Then
                For intCount = 0 To tblTemp.Rows.Count - 1
                    row = New TableRow
                    If (intCount Mod 2) = 0 Then
                        row.CssClass = "lbGridCell"
                    Else
                        row.CssClass = "lbGridAlterCell"
                    End If
                    intStatus = CInt(tblTemp.Rows(intCount).Item("StatusID"))
                    If Not IsDBNull(tblTemp.Rows(intCount).Item("TotalAmount")) Then
                        dblSumValue = dblSumValue + CDbl(tblTemp.Rows(intCount).Item("TotalAmount"))
                    End If
                    col = New TableCell
                    col.HorizontalAlign = HorizontalAlign.Center
                    col.Controls.Add(New LiteralControl(tblTemp.Rows(intCount).Item("POName")))
                    row.Cells.Add(col)
                    col = New TableCell
                    col.HorizontalAlign = HorizontalAlign.Right
                    col.Controls.Add(New LiteralControl(CDbl(tblTemp.Rows(intCount).Item("TotalAmount"))))
                    row.Cells.Add(col)
                    Dim imgStatus As Image

                    ' PrepareDeploy
                    If intStatus < 3 Then
                        intSTK = intSTK + 1
                        col = New TableCell
                        col.HorizontalAlign = HorizontalAlign.Center
                        imgStatus = New Image
                        imgStatus.ImageUrl = "../images/icons/trang_thai_quy.gif"
                        imgStatus.Width = System.Web.UI.WebControls.Unit.Pixel(20)
                        imgStatus.Height = System.Web.UI.WebControls.Unit.Pixel(20)
                        col.Controls.Add(imgStatus)
                        row.Cells.Add(col)
                    Else
                        col = New TableCell
                        col.Controls.Add(New LiteralControl("&nbsp;"))
                        row.Cells.Add(col)
                    End If
                    ' Deploying
                    If intStatus = 3 Or (intStatus >= 6 And intStatus <= 15) Then
                        intDTK = intDTK + 1
                        col = New TableCell
                        col.HorizontalAlign = HorizontalAlign.Center
                        imgStatus = New Image
                        imgStatus.ImageUrl = "../images/icons/duyet_yeu_cau.gif"
                        imgStatus.Width = System.Web.UI.WebControls.Unit.Pixel(20)
                        imgStatus.Height = System.Web.UI.WebControls.Unit.Pixel(20)
                        col.Controls.Add(imgStatus)
                        row.Cells.Add(col)
                    Else
                        col = New TableCell
                        col.Controls.Add(New LiteralControl("&nbsp;"))
                        row.Cells.Add(col)
                    End If

                    ' Accomplish OnTime
                    If intStatus = 17 Then
                        intHTDH = intHTDH + 1
                        col = New TableCell
                        col.HorizontalAlign = HorizontalAlign.Center
                        imgStatus = New Image
                        imgStatus.ImageUrl = "../images/icons/bao_cao_quy.gif"
                        imgStatus.Width = System.Web.UI.WebControls.Unit.Pixel(20)
                        imgStatus.Height = System.Web.UI.WebControls.Unit.Pixel(20)
                        col.Controls.Add(imgStatus)
                        row.Cells.Add(col)
                    Else
                        col = New TableCell
                        col.Controls.Add(New LiteralControl("&nbsp;"))
                        row.Cells.Add(col)
                    End If

                    ' Accomplish OverTime
                    If intStatus = 18 Then
                        intHTKDH = intHTKDH + 1
                        col = New TableCell
                        col.HorizontalAlign = HorizontalAlign.Center
                        imgStatus = New Image
                        imgStatus.ImageUrl = "../images/icons/thanh_ly.gif"
                        imgStatus.Width = System.Web.UI.WebControls.Unit.Pixel(20)
                        imgStatus.Height = System.Web.UI.WebControls.Unit.Pixel(20)
                        col.Controls.Add(imgStatus)
                        row.Cells.Add(col)
                    Else
                        col = New TableCell
                        col.Controls.Add(New LiteralControl("&nbsp;"))
                        row.Cells.Add(col)
                    End If

                    ' Claim
                    If intStatus = 5 Then
                        intKN = intKN + 1
                        col = New TableCell
                        col.HorizontalAlign = HorizontalAlign.Center
                        imgStatus.ImageUrl = "../images/icons/gui_don_dat.gif"
                        imgStatus.Width = System.Web.UI.WebControls.Unit.Pixel(20)
                        imgStatus.Height = System.Web.UI.WebControls.Unit.Pixel(20)
                        col.Controls.Add(imgStatus)
                        row.Cells.Add(col)
                    Else
                        col = New TableCell
                        col.Controls.Add(New LiteralControl("&nbsp;"))
                        row.Cells.Add(col)
                    End If

                    ' Dispose
                    If intStatus = 6 Then
                        intHB = intHB + 1
                        col = New TableCell
                        col.HorizontalAlign = HorizontalAlign.Center
                        imgStatus.ImageUrl = "../images/icons/xep_gia_da_thanh_ly.gif"
                        imgStatus.Width = System.Web.UI.WebControls.Unit.Pixel(20)
                        imgStatus.Height = System.Web.UI.WebControls.Unit.Pixel(20)
                        col.Controls.Add(imgStatus)
                        row.Cells.Add(col)
                    Else
                        col = New TableCell
                        col.Controls.Add(New LiteralControl("&nbsp;"))
                        row.Cells.Add(col)
                    End If
                    ' DisCount
                    col = New TableCell
                    col.HorizontalAlign = HorizontalAlign.Center
                    If Not IsDBNull(tblTemp.Rows(intCount).Item("DisCount")) Then
                        intGG = intGG + CDbl(tblTemp.Rows(intCount).Item("DisCount"))
                        col.Controls.Add(New LiteralControl(CDbl(tblTemp.Rows(intCount).Item("DisCount")) & "%"))
                    Else
                        col.Controls.Add(New LiteralControl("0%"))
                    End If
                    row.Cells.Add(col)
                    col = New TableCell
                    col.HorizontalAlign = HorizontalAlign.Center
                    col.Controls.Add(New LiteralControl("0"))
                    row.Cells.Add(col)
                    tblPODetail.Rows.Add(row)
                Next
            End If

            ' Debt
            row = New TableRow
            row.CssClass = "lbGridHeader"
            col = New TableCell
            col.HorizontalAlign = HorizontalAlign.Right
            col.Font.Bold = True
            col.Controls.Add(New LiteralControl(ddlLabel.Items(2).Text))
            col.Controls.Add(New LiteralControl(tblTemp.Rows.Count))
            row.Cells.Add(col)

            col = New TableCell
            col.HorizontalAlign = HorizontalAlign.Right
            col.Font.Bold = True
            col.Controls.Add(New LiteralControl(dblSumValue))
            row.Cells.Add(col)

            col = New TableCell
            col.HorizontalAlign = HorizontalAlign.Center
            col.Font.Bold = True
            col.Controls.Add(New LiteralControl(intSTK))
            row.Cells.Add(col)

            col = New TableCell
            col.HorizontalAlign = HorizontalAlign.Center
            col.Font.Bold = True
            col.Controls.Add(New LiteralControl(intDTK))
            row.Cells.Add(col)

            col = New TableCell
            col.HorizontalAlign = HorizontalAlign.Center
            col.Font.Bold = True
            col.Controls.Add(New LiteralControl(intHTDH))
            row.Cells.Add(col)

            col = New TableCell
            col.HorizontalAlign = HorizontalAlign.Center
            col.Font.Bold = True
            col.Controls.Add(New LiteralControl(intHTKDH))
            row.Cells.Add(col)

            col = New TableCell
            col.HorizontalAlign = HorizontalAlign.Center
            col.Font.Bold = True
            col.Controls.Add(New LiteralControl(intKN))
            row.Cells.Add(col)

            col = New TableCell
            col.HorizontalAlign = HorizontalAlign.Center
            col.Font.Bold = True
            col.Controls.Add(New LiteralControl(intHB))
            row.Cells.Add(col)

            col = New TableCell
            col.HorizontalAlign = HorizontalAlign.Center
            col.Font.Bold = True
            col.Controls.Add(New LiteralControl(intGG & "%"))
            row.Cells.Add(col)

            col = New TableCell
            col.HorizontalAlign = HorizontalAlign.Center
            col.Font.Bold = True
            col.Controls.Add(New LiteralControl("0"))
            row.Cells.Add(col)
            tblPODetail.Rows.Add(row)

            Dim dtvVendor As DataView
            objBV.VendorID = CInt(intVendorID)
            dtvVendor = objBV.GetVendor.DefaultView
            dtvVendor.RowFilter = "ID=" & objBV.VendorID
            If dtvVendor.Count > 0 Then
                If Not IsDBNull(dtvVendor.Item(0).Item("Name")) Then
                    lblMainTitle.Text &= dtvVendor.Item(0).Item("Name")
                    lblNameV.Text = dtvVendor.Item(0).Item("Name")
                Else
                    lblNameV.Text = ""
                End If
                If Not IsDBNull(dtvVendor.Item(0).Item("Address")) Then
                    lblAddressV.Text = dtvVendor.Item(0).Item("Address")
                Else
                    lblAddressV.Text = ""
                End If
                If Not IsDBNull(dtvVendor.Item(0).Item("ContactPerson")) Then
                    lblContactPersonV.Text = dtvVendor.Item(0).Item("ContactPerson")
                Else
                    lblContactPersonV.Text = ""
                End If
                If Not IsDBNull(dtvVendor.Item(0).Item("Tel")) Then
                    lblTelephoneV.Text = dtvVendor.Item(0).Item("Tel")
                Else
                    lblTelephoneV.Text = ""
                End If
                If Not IsDBNull(dtvVendor.Item(0).Item("Fax")) Then
                    lblFaxV.Text = dtvVendor.Item(0).Item("Fax")
                Else
                    lblFaxV.Text = ""
                End If
                If Not IsDBNull(dtvVendor.Item(0).Item("Email")) Then
                    lblEmailV.Text = dtvVendor.Item(0).Item("Email")
                Else
                    lblEmailV.Text = ""
                End If
                If Not IsDBNull(dtvVendor.Item(0).Item("Note")) Then
                    lblNoteV.Text = dtvVendor.Item(0).Item("Note")
                Else
                    lblNoteV.Text = ""
                End If
            End If

            ' Release
            dtvVendor.Dispose()
            dtvVendor = Nothing
        End Sub

        ' Page_Unload event
        ' Purpose: release all objects
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBV Is Nothing Then
                objBV.Dispose(True)
                objBV = Nothing
            End If
        End Sub
    End Class
End Namespace