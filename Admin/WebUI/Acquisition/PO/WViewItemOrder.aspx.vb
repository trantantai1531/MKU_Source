' Class: WViewItemOrder
' Puspose: Accepted ItemOrder
' Creator: Sondp
' CreatedDate: 15/03/2005
' Modification History:
'   - 10/04/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition
Imports System.IO
Imports System.Data
Imports Telerik.Web.UI

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WViewItemOrder
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

        Private objBIO As New clsBItemOrder

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call BindData(1)
                Call BindData(0)
            End If
        End Sub
        ' CheckFormPermission method
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            ' Gui don dat
            If Not CheckPemission(33) Then
                Call WriteErrorMssg(ddlLabel.Items(9).Text)
            End If
        End Sub
        ' Method: Initialize
        ' Purpose: Init all neccessary objects
        Private Sub Initialize()
            ' Initialize objBIO object
            objBIO.InterfaceLanguage = Session("InterfaceLanguage")
            objBIO.DBServer = Session("DBServer")
            objBIO.ConnectionString = Session("ConnectionString")
            Call objBIO.Initialize()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("ShelfJs", "<script language='javascript' src='../Js/PO/WViewItemOrder.js'></script>")


            btnAccepted.Attributes.Add("OnClick", "if(!CheckOptionsNullByCssClass('ckb-value', 'chkID', 2, 50, Chưa chọn yêu cầu đặt mua ấn phẩm')) return false;")
        End Sub


        Private Sub BindJS()

          
            'hrfTemplate.Attributes.Add("OnClick", "parent.Workform.location.href='WClaimTemplateManagement.aspx';return false;")

            '   btnCheck.Attributes.Add("OnClick", "if (CheckNull(document.forms[0].txtAcqYear)) {alert('" & ddlLabel.Items(9).Text & "'); return false;}")
        End Sub

        ' Method: BindScript
        ' Purpose: Include all neccessary javascript functions
        ' Method: BindData
        Private Sub BindData(ByVal intType As Integer)
            Dim tblItemOrder As DataTable
            Dim tblCell As New TableCell
            Dim color As System.Drawing.Color
            Dim inti As Integer

            Try
                objBIO.TypeID = -1 ' Get all type of items
                objBIO.LibID = clsSession.GlbSite
                tblItemOrder = objBIO.GetOrderItems
                If Not tblItemOrder Is Nothing Then
                    tblItemOrder.DefaultView.RowFilter = "TypeID=" & intType
                    If intType = 0 Then
                        dtgBOAccepted2.DataSource = tblItemOrder.DefaultView.ToTable
                    Else
                        dtgBOAccepted.DataSource = tblItemOrder.DefaultView.ToTable
                    End If
                    'dtgBOAccepted.DataBind()
                    'For inti = 0 To tblItemOrder.Rows.Count - 1
                    '    Select Case CInt(tblItemOrder.Rows(inti).Item("Urgency"))
                    '        Case 1
                    '            dtgBOAccepted.Items(inti).BackColor = System.Drawing.Color.Ivory
                    '            color = System.Drawing.Color.Ivory
                    '        Case 2
                    '            dtgBOAccepted.Items(inti).BackColor = System.Drawing.Color.Khaki
                    '            color = System.Drawing.Color.Khaki
                    '        Case 3
                    '            dtgBOAccepted.Items(inti).BackColor = System.Drawing.Color.Gold
                    '            color = System.Drawing.Color.Gold
                    '    End Select
                    '    If CBool(tblItemOrder.Rows(inti).Item("Accepted")) = True Then
                    '        CType(dtgBOAccepted.Items(inti).Cells(2).FindControl("lblAccepted"), Label).ForeColor = System.Drawing.Color.Firebrick
                    '        CType(dtgBOAccepted.Items(inti).Cells(2).FindControl("lblAccepted"), Label).Text = "."
                    '        CType(dtgBOAccepted.Items(inti).Cells(2).FindControl("lblAccepted"), Label).BackColor = System.Drawing.Color.Firebrick
                    '    Else
                    '        CType(dtgBOAccepted.Items(inti).Cells(2).FindControl("lblAccepted"), Label).ForeColor = color
                    '        CType(dtgBOAccepted.Items(inti).Cells(2).FindControl("lblAccepted"), Label).Text = "."
                    '        CType(dtgBOAccepted.Items(inti).Cells(2).FindControl("lblAccepted"), Label).BackColor = color
                    '    End If
                    'Next

                End If
            Catch ex As Exception
            End Try
        End Sub

        ' Method: GetAcqItemIDs
        ' Purpose: Get all ID value splited by ","
        ' Output: String
        Public Function GetAcqItemIDs(ByVal intType As Integer) As String
            Dim strIDs As String = ""
            Dim inti As Integer

            If intType = 1 Then
                For inti = 0 To dtgBOAccepted.Items.Count - 1
                    If CType(dtgBOAccepted.Items(inti).FindControl("optChoice"), CheckBox).Checked = True Then
                        'strIDs = strIDs & dtgBOAccepted.Items(inti).Cells(12).Text.ToString & ", "
                        strIDs = strIDs & dtgBOAccepted.Items(inti).GetDataKeyValue("ID").ToString() & ", "
                    End If
                Next
            Else
                For inti = 0 To dtgBOAccepted2.Items.Count - 1
                    If CType(dtgBOAccepted2.Items(inti).FindControl("optChoice"), CheckBox).Checked = True Then
                        'strIDs = strIDs & dtgBOAccepted2.Items(inti).Cells(12).Text.ToString & ", "
                        strIDs = strIDs & dtgBOAccepted2.Items(inti).GetDataKeyValue("ID").ToString() & ", "
                    End If
                Next
            End If



            If strIDs.Length > 1 Then
                strIDs = Left(strIDs, Len(strIDs) - 2)
            End If

            GetAcqItemIDs = strIDs
        End Function

        ' btnAccepted_Click event
        ' Purpose: accept the selected itemorders
        Private Sub btnAccepted_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAccepted.Click
            If dtgBOAccepted.Items.Count > 0 Then
                ' Accept this order
                If GetAcqItemIDs(1) = "" Then
                Else
                    objBIO.AcceptedItemOrder(GetAcqItemIDs(1), "1")
                    'Message OK
                    Page.RegisterClientScriptBlock("SuccessJs", "<script language='javascript'>alert('" & ddlLabel.Items(5).Text & "');</script>")
                    ' Writelog
                    Call WriteLog(38, ddlLabel.Items(3).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                    ' Reload form
                    Call BindData(1)
                    dtgBOAccepted.Rebind()
                End If
            End If
        End Sub

        ' btnStop_Click event
        ' Purpose: UnAccept the selected itemorders
        Private Sub btnStop_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnStop.Click
            If dtgBOAccepted.Items.Count > 0 Then
                ' UnAccept this order
                If GetAcqItemIDs(1) = "" Then
                    'Message Error
                    Page.RegisterClientScriptBlock("ErrorJs", "<script language='javascript'>alert('" & ddlLabel.Items(6).Text & "');</script>")
                Else

                    objBIO.AcceptedItemOrder(GetAcqItemIDs(1), "0")
                    'Message OK
                    Page.RegisterClientScriptBlock("SuccessJs", "<script language='javascript'>alert('" & ddlLabel.Items(7).Text & "');</script>")

                    ' Writelog
                    Call WriteLog(38, ddlLabel.Items(4).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                    ' Reload form
                    Call BindData(1)
                    dtgBOAccepted.Rebind()
                End If
            End If
        End Sub

        ' btnDelete_Click event
        ' Purpose: delete this item order
        Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            If dtgBOAccepted.Items.Count > 0 Then
                ' Delete
                If GetAcqItemIDs(1) = "" Then
                    'Message Error
                    Page.RegisterClientScriptBlock("ErrorJs", "<script language='javascript'>alert('" & ddlLabel.Items(6).Text & "');</script>")
                Else
                    Call objBIO.DeleteItemOrder(GetAcqItemIDs(1))
                    'Message OK
                    Page.RegisterClientScriptBlock("SuccessJs", "<script language='javascript'>alert('" & ddlLabel.Items(8).Text & "');</script>")

                    ' Writelog
                    Call WriteLog(38, ddlLabel.Items(2).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                    ' Reload form
                    Call BindData(1)
                    dtgBOAccepted.Rebind()
                End If
            End If
        End Sub

        ' Page_Unload method
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBIO Is Nothing Then
                objBIO.Dispose(True)
                objBIO = Nothing
            End If
        End Sub


        Protected Sub dtgBOAccepted_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles dtgBOAccepted.NeedDataSource
            BindData(1)

        End Sub
        Protected Sub dtgBOAccepted2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles dtgBOAccepted2.NeedDataSource
            BindData(0)

        End Sub



        Protected Sub dtgBOAccepted_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles dtgBOAccepted.ItemDataBound
            Dim color As System.Drawing.Color
            For inti = 0 To dtgBOAccepted.MasterTableView.Items.Count - 1
                Select Case CInt(dtgBOAccepted.DataSource.Rows(inti).Item("Urgency"))
                    Case 1
                        dtgBOAccepted.Items(inti).BackColor = System.Drawing.Color.Ivory
                        color = System.Drawing.Color.Ivory
                    Case 2
                        dtgBOAccepted.Items(inti).BackColor = System.Drawing.Color.Khaki
                        color = System.Drawing.Color.Khaki
                    Case 3
                        dtgBOAccepted.Items(inti).BackColor = System.Drawing.Color.Gold
                        color = System.Drawing.Color.Gold
                End Select
                If CBool(dtgBOAccepted.DataSource.Rows(inti).Item("Accepted")) = True Then
                    CType(dtgBOAccepted.Items(CType(inti, Integer)).Cells(2).FindControl("lblAccepted"), Label).ForeColor = System.Drawing.Color.Firebrick
                    CType(dtgBOAccepted.Items(inti).Cells(2).FindControl("lblAccepted"), Label).Text = "."
                    CType(dtgBOAccepted.Items(inti).Cells(2).FindControl("lblAccepted"), Label).BackColor = System.Drawing.Color.Firebrick
                Else
                    CType(dtgBOAccepted.Items(inti).Cells(2).FindControl("lblAccepted"), Label).ForeColor = color
                    CType(dtgBOAccepted.Items(inti).Cells(2).FindControl("lblAccepted"), Label).Text = "."
                    CType(dtgBOAccepted.Items(inti).Cells(2).FindControl("lblAccepted"), Label).BackColor = color
                End If
            Next
        End Sub
        Protected Sub dtgBOAccepted2_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles dtgBOAccepted2.ItemDataBound
            Dim color As System.Drawing.Color
            For inti = 0 To dtgBOAccepted2.MasterTableView.Items.Count - 1
                Select Case CInt(dtgBOAccepted2.DataSource.Rows(inti).Item("Urgency"))
                    Case 1
                        dtgBOAccepted2.Items(inti).BackColor = System.Drawing.Color.Ivory
                        color = System.Drawing.Color.Ivory
                    Case 2
                        dtgBOAccepted2.Items(inti).BackColor = System.Drawing.Color.Khaki
                        color = System.Drawing.Color.Khaki
                    Case 3
                        dtgBOAccepted2.Items(inti).BackColor = System.Drawing.Color.Gold
                        color = System.Drawing.Color.Gold
                End Select
                If CBool(dtgBOAccepted2.DataSource.Rows(inti).Item("Accepted")) = True Then
                    CType(dtgBOAccepted2.Items(CType(inti, Integer)).Cells(2).FindControl("lblAccepted"), Label).ForeColor = System.Drawing.Color.Firebrick
                    CType(dtgBOAccepted2.Items(inti).Cells(2).FindControl("lblAccepted"), Label).Text = "."
                    CType(dtgBOAccepted2.Items(inti).Cells(2).FindControl("lblAccepted"), Label).BackColor = System.Drawing.Color.Firebrick
                Else
                    CType(dtgBOAccepted2.Items(inti).Cells(2).FindControl("lblAccepted"), Label).ForeColor = color
                    CType(dtgBOAccepted2.Items(inti).Cells(2).FindControl("lblAccepted"), Label).Text = "."
                    CType(dtgBOAccepted2.Items(inti).Cells(2).FindControl("lblAccepted"), Label).BackColor = color
                End If
            Next
        End Sub
        Protected Sub btnAccepted2_Click(sender As Object, e As EventArgs) Handles btnAccepted2.Click
            If dtgBOAccepted2.Items.Count > 0 Then
                ' Accept this order
                If GetAcqItemIDs(0) = "" Then
                Else
                    objBIO.AcceptedItemOrder(GetAcqItemIDs(0), "1")
                    'Message OK
                    Page.RegisterClientScriptBlock("SuccessJs", "<script language='javascript'>alert('" & ddlLabel.Items(5).Text & "');</script>")
                    ' Writelog
                    Call WriteLog(38, ddlLabel.Items(3).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                    ' Reload form
                    Call BindData(0)
                    dtgBOAccepted2.Rebind()
                End If
            End If
        End Sub

        Protected Sub btnStop2_Click(sender As Object, e As EventArgs) Handles btnStop2.Click
            If dtgBOAccepted2.Items.Count > 0 Then
                ' UnAccept this order
                If GetAcqItemIDs(0) = "" Then
                    'Message Error
                    Page.RegisterClientScriptBlock("ErrorJs", "<script language='javascript'>alert('" & ddlLabel.Items(6).Text & "');</script>")
                Else

                    objBIO.AcceptedItemOrder(GetAcqItemIDs(0), "0")
                    'Message OK
                    Page.RegisterClientScriptBlock("SuccessJs", "<script language='javascript'>alert('" & ddlLabel.Items(7).Text & "');</script>")

                    ' Writelog
                    Call WriteLog(38, ddlLabel.Items(4).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                    ' Reload form
                    Call BindData(0)
                    dtgBOAccepted2.Rebind()
                End If
            End If
        End Sub
        Protected Sub btnDelete2_Click(sender As Object, e As EventArgs) Handles btnDelete2.Click
            If dtgBOAccepted2.Items.Count > 0 Then
                ' Delete
                If GetAcqItemIDs(0) = "" Then
                    'Message Error
                    Page.RegisterClientScriptBlock("ErrorJs", "<script language='javascript'>alert('" & ddlLabel.Items(6).Text & "');</script>")
                Else
                    Call objBIO.DeleteItemOrder(GetAcqItemIDs(0))
                    'Message OK
                    Page.RegisterClientScriptBlock("SuccessJs", "<script language='javascript'>alert('" & ddlLabel.Items(8).Text & "');</script>")

                    ' Writelog
                    Call WriteLog(38, ddlLabel.Items(2).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                    ' Reload form
                    Call BindData(0)
                    dtgBOAccepted2.Rebind()
                End If
            End If
        End Sub

    End Class
End Namespace