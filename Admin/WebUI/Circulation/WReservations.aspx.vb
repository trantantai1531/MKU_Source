' Class WReservations
' Puspose: Tìm kiếm các về các ấn phẩm được đặt chỗ, nhưng chưa sử lý
'          Xoá các đơn đặt chỗ.
' Creator: Tuanhv
' CreatedDate: 26/08/2004
' Modification History:
'   - 18/04/2005 by Oanhtn: Review

Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.WebUI.Common


Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WReservations
        'Inherits System.Web.UI.Page
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents dgdGetCopyNumber As System.Web.UI.WebControls.DataGrid
        Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblMsgTotal As System.Web.UI.WebControls.Label
        Protected WithEvents lblTotal As System.Web.UI.WebControls.Label
        Protected WithEvents lblMsg As System.Web.UI.WebControls.Label



        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBRT As New clsBReservationTransaction

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Call Initialize()
            Call BindJS()
            If Not IsPostBack Then
                Call GetReservList()
            End If

        End Sub

        ' Method: Initialize
        ' Purpose: Initialize all objects
        Private Sub Initialize()
            ' Init objBRT object
            objBRT.ConnectionString = Session("ConnectionString")
            objBRT.DBServer = Session("DBServer")
            objBRT.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBRT.Initialize()
        End Sub

        'Method: BindJS
        'Purpose: Bind javascript
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = 'Js/WReservations.js'></script>")

            btnClose.Attributes.Add("OnClick", "javascript:self.close(); return false;")

            'If Session("OrderMode") = Nothing Then
            '    Session("OrderMode") = "off"
            'Else
            '    If Request("OrderMode") = "on" Then
            '        Session("OrderMode") = "on"
            '    ElseIf Request("OrderMode") = "off" Then
            '        Session("OrderMode") = "off"
            '    End If
            'End If
            'If Session("OrderMode") = "off" Or Session("OrderMode") Is Nothing Then
            '    If Not Session("RefreshInterval") Is Nothing AndAlso Session("RefreshInterval") <> 0 Then
            '        txtTime.Text = Session("RefreshInterval")
            '    Else
            '        txtTime.Text = "120"
            '    End If
            '    lnkOn.NavigateUrl = "#"
            '    lnkOn.Attributes.Add("OnClick", "javascript:location.href='WReservations.aspx?OrderMode=on&Refval=' + document.forms[0].txtTime.value")
            '    txtTime.Attributes.Add("OnChange", "javascript:if(!CheckNumber('document.forms[0].txtTime','" & ddlLabel.Items(4).Text & "')) return false;else if(CheckNull(this)) {alert('" & ddlLabel.Items(5).Text & "');return false;}")
            '    'Session("RefreshInterval") = 0
            'Else
            '    lnkOff.NavigateUrl = "WReservations.aspx?OrderMode=off"
            '    If Request("Refval") <> "" Then
            '        Session("RefreshInterval") = Request("Refval")
            '        Page.RegisterClientScriptBlock("RefreshForm", "<script language='javascript'>opener.top.main.Refreshform.location.href='WRefreshStatus.aspx';</script>")
            '    End If
            'End If
        End Sub

        'Method: GetReservList
        'Purpose: Get the Reservations Information 
        Sub GetReservList()
            Dim tblReservList As DataTable
            Dim tblGetRstCopyNumber As DataTable
            Dim tblRowRstInfor() As DataRow
            Dim tblRowRstCopynumber() As DataRow
            Dim intCountInfor As Integer
            Dim intIndex As Integer
            Dim arrIndex()
            Dim tblRowCopyNumber() As DataRow
            Dim tblRow As DataRow

            objBRT.UserID = Session("UserID")

            dgrOrderResult.Visible = False
            btnDeleteOrder.Visible = False

            tblReservList = objBRT.GetReservationPatronInfor()

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBRT.ErrorMsg, ddlLabel.Items(0).Text, objBRT.ErrorCode)

            objBRT.LibID = clsSession.GlbSite
            tblGetRstCopyNumber = objBRT.GetReservationInfor()

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBRT.ErrorMsg, ddlLabel.Items(0).Text, objBRT.ErrorCode)

            If Not tblReservList Is Nothing And Not tblGetRstCopyNumber Is Nothing AndAlso tblReservList.Rows.Count > 0 Then

                intCountInfor = tblReservList.Rows.Count - 1

                ReDim arrIndex(intCountInfor + 1)
                dgrOrderResult.Visible = True
                btnDeleteOrder.Visible = True
                dgrOrderResult.DataSource = tblReservList
                dgrOrderResult.DataBind()

                For intIndex = 0 To intCountInfor
                    arrIndex(intIndex) = ""

                    If tblReservList.Rows(intIndex).Item("CopyNumber") <> "" Then
                        tblRowCopyNumber = tblGetRstCopyNumber.Select("CRR_ID=" & tblReservList.Rows(intIndex).Item("CRR_ID") & " AND CopyNumber= '" & tblReservList.Rows(intIndex).Item("CopyNumber") & "'")
                    Else
                        tblRowCopyNumber = tblGetRstCopyNumber.Select("CRR_ID=" & tblReservList.Rows(intIndex).Item("CRR_ID"))
                    End If
                    tblGetRstCopyNumber.Select()

                    If tblRowCopyNumber.Length > 0 Then
                        arrIndex(intIndex) = "<BR><B>" & ddlLabel.Items(2).Text & "</B>"
                        For Each tblRow In tblRowCopyNumber
                            arrIndex(intIndex) = arrIndex(intIndex) & "<BR>" & tblRow.Item("CopyNumber") & "( " & tblRow.Item("Symbol") & " @ " & tblRow.Item("Shelf") & " ) "
                        Next
                    Else
                        arrIndex(intIndex) = arrIndex(intIndex) & "<BR><B>" & ddlLabel.Items(3).Text & "</B>"
                    End If

                    CType(dgrOrderResult.Items(intIndex).Cells(1).FindControl("lblItemTitle"), Label).Text = CType(dgrOrderResult.Items(intIndex).Cells(1).FindControl("lblItemTitle"), Label).Text + arrIndex(intIndex)
                Next
                tblReservList = Nothing
                tblGetRstCopyNumber = Nothing
            End If
        End Sub

        'Event: btnDeleteOrder_Click
        'Purpose: Delete the selected orders
        Private Sub btnDeleteOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteOrder.Click
            Dim dgrItem As DataGridItem
            Dim lblHidden As Label
            Dim strCrr_IDs As String
            Dim strCrr_ID As String
            Dim intCount As Integer

            ' Find control in datagrid
            For intCount = 0 To dgrOrderResult.Items.Count - 1
                If CType(dgrOrderResult.Items(intCount).Cells(0).FindControl("chkCheck"), HtmlInputCheckBox).Checked Then
                    strCrr_ID = CType(dgrOrderResult.Items(intCount).Cells(5).FindControl("lblHidden"), Label).Text
                    strCrr_IDs = strCrr_IDs & ", " & strCrr_ID
                End If
            Next
            If Len(strCrr_IDs) <> 0 Then
                strCrr_IDs = Right(strCrr_IDs, Len(strCrr_IDs) - 2)
                ' Delete the selected request
                If strCrr_IDs <> "" Then
                    objBRT.CRR_ID = strCrr_IDs
                    objBRT.RemoveReservation()

                    ' Check error
                    Call WriteErrorMssg(ddlLabel.Items(1).Text, objBRT.ErrorMsg, ddlLabel.Items(0).Text, objBRT.ErrorCode)

                    ' Reload form
                    Call GetReservList()
                End If
            End If
        End Sub

        'Method: BindOrderStatus
        'Purpose: Get the session Order mode and get the status
        'Private Sub BindOrderStatus()
        '    If Session("OrderMode") = "on" Then
        '        lblOn.Visible = True
        '        lblOff.Visible = False
        '        lnkOn.Visible = False
        '        lnkOff.Visible = True
        '        txtTime.Visible = False
        '        lblTime.Visible = False
        '        lblAfter.Visible = False
        '    Else
        '        lblOn.Visible = False
        '        lblOff.Visible = True
        '        lnkOn.Visible = True
        '        lnkOff.Visible = False
        '        txtTime.Visible = True
        '        lblTime.Visible = True
        '        lblAfter.Visible = True
        '    End If
        'End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: Realease the objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBRT Is Nothing Then
                    objBRT.Dispose(True)
                    objBRT = Nothing
                End If
            Finally
                Call MyBase.Dispose()
                Call Me.Dispose()
            End Try
        End Sub


    End Class
End Namespace