Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WShowRec
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblUseRec As System.Web.UI.WebControls.Label
        Protected WithEvents lblUseInfor As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private objBIC As New clsBItemCollection

        ' Method: Initialize
        ' Purpose: Init all object
        Private Sub Initialize()
            ' Init BCommonBusiness object
            objBIC.DBServer = Session("DBServer")
            objBIC.InterfaceLanguage = Session("InterfaceLanguage")
            objBIC.ConnectionString = Session("ConnectionString")
            Call objBIC.Initialize()
        End Sub

        ' Method: LoadData
        Private Sub LoadData()
            Dim strItemIDs As String = Request.QueryString("ItemIDs")
            Dim arrItemID
            Dim tblItem As DataTable
            Dim inti As Integer

            ' declare Table Result
            Dim tblRow As TableRow
            Dim tblCell As TableCell
            Dim lblLabel As Label
            Dim btnUse As Button

            If strItemIDs <> "" Then
                arrItemID = Split(strItemIDs, ",")
            End If
            For inti = 0 To UBound(arrItemID)
                tblRow = New TableRow
                tblRow.VerticalAlign = VerticalAlign.Top
                If inti Mod 2 = 0 Then
                    tblRow.CssClass = "lbGridCell"
                Else
                    tblRow.CssClass = "lbGridAlterCell"
                End If

                tblCell = New TableCell
                tblCell.HorizontalAlign = HorizontalAlign.Right
                lblLabel = New Label
                lblLabel.CssClass = "lbLabel"
                lblLabel.Text = inti + 1
                tblCell.Width = Unit.Percentage(5)

                tblCell.Controls.Add(lblLabel)
                tblRow.Controls.Add(tblCell)

                tblCell = New TableCell
                lblLabel = New Label
                lblLabel.CssClass = "lbLabel"
                objBIC.ItemIDs = arrItemID(inti)
                lblLabel.Text = objBIC.CreateCatalogCard

                tblCell.Controls.Add(lblLabel)
                tblRow.Controls.Add(tblCell)

                tblCell = New TableCell
                tblCell.Width = Unit.Percentage(5)
                btnUse = New Button
                btnUse.Width = Unit.Pixel(130)
                btnUse.CssClass = "lbButton"
                tblItem = New DataTable
                objBIC.Code = ""
                objBIC.ItemID = arrItemID(inti)
                tblItem = objBIC.GetItemMainInfor

                btnUse.Text = ddlLabel.Items(2).Text
                btnUse.Attributes.Add("Onclick", "opener.parent.mainacq.location.href='WCopyNumber.aspx?Code=" & tblItem.Rows(0).Item("Code") & "';self.close();")
                tblCell.Controls.Add(btnUse)
                lblLabel = New Label
                lblLabel.Text = "<BR>"
                tblCell.Controls.Add(lblLabel)
                btnUse = New Button
                btnUse.Width = Unit.Pixel(130)
                btnUse.CssClass = "lbButton"
                btnUse.Text = ddlLabel.Items(3).Text
                btnUse.Attributes.Add("Onclick", "opener.parent.mainacq.location.href='WCataForm.aspx';opener.parent.hiddenbase.location.href='WReUseRec.aspx?ItemID=" & arrItemID(inti) & "';self.close();")
                tblCell.Controls.Add(btnUse)
                tblRow.Controls.Add(tblCell)
                tblResult.Rows.Add(tblRow)
            Next
        End Sub

        ' Method: BindJS
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language='javascript' src='../js/ACQ/WCataForm.js'></script>")
        End Sub

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            Call LoadData()
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBIC Is Nothing Then
                    objBIC.Dispose(True)
                    objBIC = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace