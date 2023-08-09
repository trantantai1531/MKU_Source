Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.Edeliv
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WCheckDebt
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

        ' Declare variables
        Private objBAccountTrans As New clsBAccountTransaction

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPemission()
            Call Initialize()
            Call BindScript()
            Call BindEdelivUserDebt()
            hidIDs.Value = ""
        End Sub

        ' CheckFormPemission method
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            If Not CheckPemission(162) Then
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBAccountTrans
            objBAccountTrans.InterfaceLanguage = Session("InterfaceLanguage")
            objBAccountTrans.DBServer = Session("DBServer")
            objBAccountTrans.ConnectionString = Session("ConnectionString")
            objBAccountTrans.Initialize()
        End Sub

        ' BindEdelivUserDebt method
        Private Sub BindEdelivUserDebt()
            Dim tblUserDebt As DataTable
            Dim dblDebt As Double
            Dim intOutPut As Int16

            If Trim(Request("CustomerCode")) <> "" Then
                objBAccountTrans.CustomerCode = Request("CustomerCode")
                tblUserDebt = objBAccountTrans.CheckDebt(dblDebt, intOutPut)
                Call WriteErrorMssg(ddlLabel.Items(4).Text, objBAccountTrans.ErrorMsg, ddlLabel.Items(3).Text, objBAccountTrans.ErrorCode)
                If intOutPut = 0 Then
                    TR1.Visible = True
                    TR2.Visible = False
                    TR3.Visible = False
                    lblInValidUser.Visible = True
                    lblTitle.Visible = False
                    btnAdd.Visible = False
                Else
                    If Not tblUserDebt Is Nothing Then
                        If tblUserDebt.Rows.Count > 0 Then
                            TR1.Visible = True
                            TR2.Visible = True
                            TR3.Visible = True
                            lblInValidUser.Visible = False
                            lblTitle.Visible = True
                            dgrResult.DataSource = tblUserDebt
                            dgrResult.DataBind()
                            If dblDebt <= 0 Then
                                lblUserDebt.Text = lblTemp1.Text
                                lblDebt.Text = dblDebt * (-1) & " VND"
                            Else
                                lblUserDebt.Text = lblTemp2.Text
                                lblDebt.Text = dblDebt & " VND"
                            End If
                            hidRecordNum.Value = tblUserDebt.Rows.Count
                            btnAdd.Visible = True
                        Else
                            TR1.Visible = False
                            TR2.Visible = False
                            TR3.Visible = True
                            If dblDebt <= 0 Then
                                lblUserDebt.Text = lblTemp1.Text
                                lblDebt.Text = dblDebt * (-1) & " VND"
                            Else
                                lblUserDebt.Text = lblTemp2.Text
                                lblDebt.Text = dblDebt & " VND"
                            End If
                            btnAdd.Visible = False
                        End If
                    Else
                        TR1.Visible = False
                        TR2.Visible = False
                        TR3.Visible = True
                        If dblDebt <= 0 Then
                            lblUserDebt.Text = lblTemp1.Text
                            lblDebt.Text = dblDebt * (-1) & " VND"
                        Else
                            lblUserDebt.Text = lblTemp2.Text
                            lblDebt.Text = dblDebt & " VND"
                        End If
                        btnAdd.Visible = False
                    End If
                End If
            Else
                TR1.Visible = True
                TR2.Visible = False
                TR3.Visible = False
                lblInValidUser.Visible = True
                lblTitle.Visible = False
                btnAdd.Visible = False
            End If
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/Account/WCheckDebt.js'></script>")

            btnAdd.Attributes.Add("OnClick", "javascript:if (CheckNull(document.forms[0].hidIDs)) {alert('" & ddlLabel.Items(1).Text & "');return false;} else{PostBackData('" & ddlLabel.Items(0).Text & "');}")
            btnClose.Attributes.Add("Onclick", "javascript:self.close();")
        End Sub

        ' DgrResult_ItemCreated event
        Private Sub DgrResult_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrResult.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                    ' Declare variables
                    Dim tblCell As TableCell
                    Dim chk As CheckBox

                    tblCell = e.Item.Cells(1)

                    chk = CType(tblCell.FindControl("chkID"), CheckBox)
                    chk.Attributes.Add("OnClick", "CheckBoxClick('dgrResult','chkID'," & e.Item.ItemIndex + 2 & ",'" & DataBinder.Eval(e.Item.DataItem, "ID") & "','" & DataBinder.Eval(e.Item.DataItem, "Price") & "','" & DataBinder.Eval(e.Item.DataItem, "FileName") & "','" & DataBinder.Eval(e.Item.DataItem, "FILESIZE") & "','" & DataBinder.Eval(e.Item.DataItem, "Currency") & "');")
            End Select

            Dim inti As Integer
            For inti = 1 To e.Item.Cells.Count - 1
                e.Item.Cells(inti).Attributes.Add("onClick", "javascript:CheckOptionVisible('dgrResult','chkID'," & e.Item.ItemIndex + 2 & ");")
            Next
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBAccountTrans Is Nothing Then
                    objBAccountTrans.Dispose(True)
                    objBAccountTrans = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

    End Class
End Namespace

