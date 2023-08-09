' Class: WShowRoute
' Puspose: Route for the selected periodical
' Creator: Oanhtn
' CreatedDate: 21/09/2004
' Modification history:
'   21/04/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Serial
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WShowRoute
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblLabel2 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel1 As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBPeriodical As New clsBPeriodical

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            If Not Request("hidLocationID") = "" Then
                Call CreateRoutingRecord()
            Else
                If Not Page.IsPostBack Then
                    Call ShowResult()
                End If
            End If
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            Response.Expires = 0

            ' Init objBPeriodical object
            objBPeriodical.ConnectionString = Session("ConnectionString")
            objBPeriodical.DBServer = Session("DBServer")
            objBPeriodical.InterfaceLanguage = Session("InterfaceLanguage")
            objBPeriodical.ItemID = Session("ItemID")
            Call objBPeriodical.Initialize()
        End Sub

        ' BindJS method
        ' Purpose: include all necessary js functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")

            btnClose.Attributes.Add("OnClick", "self.close(); return false;")
        End Sub

        ' ShowResult method
        ' Purpose: Load form
        Private Sub ShowResult()
            Dim tblTemp As DataTable
            Dim intCount As Int16
            Dim intCopies As Int16 = 0

            If Not Request("ContractCode") = "" Then
                hidContractCode.Value = Request("ContractCode")
            End If

            lblTitle.Text = "<B>" & Session("Title") & "</B>"
            If hidContractCode.Value & "" <> "" Then
                lblContractCode.Text = "<B>" & hidContractCode.Value & "</B>"
            Else
                lblContractCode.Text = ""
                lblContractCodelb.Visible = False
            End If

            tblTemp = objBPeriodical.GetRoutingInfor()

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPeriodical.ErrorMsg, ddlLabel.Items(0).Text, objBPeriodical.ErrorCode)

            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    dtgResult.DataSource = tblTemp
                    dtgResult.DataBind()
                    For intCount = 0 To tblTemp.Rows.Count - 1
                        intCopies = intCopies + CInt(tblTemp.Rows(intCount).Item("Copies"))
                    Next
                    lblTotal.Text = intCopies
                End If
            End If

            ' Release objects
            tblTemp = Nothing
        End Sub

        ' CreateRoutingRecord method
        ' Purpose: Create new routing record
        Private Sub CreateRoutingRecord()
            Dim strBasedDate As String = Trim(Request("txtBasedDate"))
            Dim intCopies As Int16 = Request("txtCopies")
            Dim intLocationID As Int16 = Request("hidLocationID")
            Dim intPOID As Int16 = Request("hidContractID")

            objBPeriodical.POID = intPOID
            objBPeriodical.BasedDate = strBasedDate
            Call objBPeriodical.CreateRoutingRecord(intLocationID, intCopies)

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPeriodical.ErrorMsg, ddlLabel.Items(0).Text, objBPeriodical.ErrorCode)

            ' WriteLog
            Call WriteLog(34, ddlLabel.Items(3).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

            ' Reload opener from
            Page.RegisterClientScriptBlock("LoadbackJs", "<script language = 'javascript'>if (parent.Workform.document.forms[0].txtRemainCopies) {parent.Workform.document.forms[0].txtRemainCopies.value = parseFloat(parent.Workform.document.forms[0].txtRemainCopies.value) - " & intCopies & ";}</script>")
        End Sub

        ' dtgResult_EditCommand event
        Public Sub dtgResult_EditCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgResult.EditCommand
            Try
                dtgResult.EditItemIndex = e.Item.ItemIndex

                ' Show data for editing
                Call ShowResult()

                CType(dtgResult.Items(dtgResult.EditItemIndex).Cells(3).Controls(0), TextBox).Attributes.Add("OnChange", "javascript:CheckDate(this, 'dd/mm/yyyy', '" & ddlLabel.Items(2).Text & "');")
                CType(dtgResult.Items(dtgResult.EditItemIndex).Cells(3).Controls(0), TextBox).Width = Unit.Point(50)
                CType(dtgResult.Items(dtgResult.EditItemIndex).Cells(3).Controls(0), TextBox).CssClass = "lbTextBox"
                CType(dtgResult.Items(dtgResult.EditItemIndex).Cells(2).Controls(0), TextBox).Width = Unit.Pixel(100)
                CType(dtgResult.Items(dtgResult.EditItemIndex).Cells(2).Controls(0), TextBox).CssClass = "lbTextBox"
            Catch ex As Exception
            End Try
        End Sub

        ' dtgResult_CancelCommand event
        Public Sub dtgResult_CancelCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgResult.CancelCommand
            Try
                dtgResult.EditItemIndex = -1
                Call ShowResult()
            Catch ex As Exception
            End Try
        End Sub

        ' dtgResult_DeleteCommand event
        ' Purpose: remove routing record
        Public Sub dtgResult_DeleteCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgResult.DeleteCommand
            Try
                Dim intRouteID As Integer = CLng(CType(e.Item.Cells(0).FindControl("lblID"), Label).Text)

                ' Delete informations of the selected routing record
                Call objBPeriodical.RemoveRoutingRecord(intRouteID)

                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPeriodical.ErrorMsg, ddlLabel.Items(0).Text, objBPeriodical.ErrorCode)

                ' WriteLog
                Call WriteLog(34, ddlLabel.Items(4).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                Call ShowResult()
                dtgResult.EditItemIndex = -1
                ' Reload opener from
                Page.RegisterClientScriptBlock("RefreshOpener", "<script language = 'javascript'>opener.location.href='WAcquire.aspx';</script>")
            Catch ex As Exception
            End Try
        End Sub

        ' dtgResult_UpdateCommand event
        ' Purpose: update information of the selected routing record
        Public Sub dtgResult_UpdateCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgResult.UpdateCommand
            Try
                Dim intRouteID As Integer = CLng(CType(e.Item.Cells(0).FindControl("lblID"), Label).Text)
                ' Update now
                Dim strAppliedDate As String = CStr(CType(dtgResult.Items(dtgResult.EditItemIndex).Cells(3).Controls(0), TextBox).Text)
                Dim intCopies As Int16 = CInt(CType(dtgResult.Items(dtgResult.EditItemIndex).Cells(2).Controls(0), TextBox).Text)

                objBPeriodical.BasedDate = Trim(strAppliedDate)
                objBPeriodical.UpdateRoutingRecord(intRouteID, intCopies)

                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPeriodical.ErrorMsg, ddlLabel.Items(0).Text, objBPeriodical.ErrorCode)

                ' WriteLog
                Call WriteLog(34, ddlLabel.Items(3).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                ' Refresh interface
                dtgResult.EditItemIndex = -1
                Call ShowResult()
                ' Reload opener from
                Page.RegisterClientScriptBlock("RefreshOpenner", "<script language = 'javascript'>opener.location.href='WAcquire.aspx';</script>")
            Catch ex As Exception
            End Try
        End Sub

        ' dtgResult_ItemCreated event
        Private Sub dtgResult_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgResult.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.AlternatingItem, ListItemType.EditItem, ListItemType.Item
                    Dim lnkdtgTemp As LinkButton
                    lnkdtgTemp = CType(e.Item.Cells(5).Controls(0), LinkButton)
                    lnkdtgTemp.Attributes.Add("onclick", "if(confirm('" & ddlLabel.Items(5).Text & "')) return true;else return false;")
            End Select
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBPeriodical Is Nothing Then
                    objBPeriodical.Dispose(True)
                    objBPeriodical = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

    End Class
End Namespace