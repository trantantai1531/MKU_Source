Imports eMicLibAdmin.BusinessRules.Circulation
Imports Telerik.Web.UI

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WRenew
        Inherits clsWBase
        Implements IUCNumberOfRecord

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
        Private objBLoanTrans As New clsBLoanTransaction
        Private objBPatron As New clsBPatron

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialze()
            Call BindJS()
            If Not Page.IsPostBack Then
                'Call BindData()
            End If
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(149) Then
                WriteErrorMssg(ddlLabel.Items(8).Text)
                btnRenew.Enabled = False
            End If
        End Sub

        Private Sub Initialze()
            objBLoanTrans.InterfaceLanguage = Session("InterfaceLanguage")
            objBLoanTrans.DBServer = Session("DBServer")
            objBLoanTrans.ConnectionString = Session("ConnectionString")
            Call objBLoanTrans.Initialize()

            ' Init objBPatron object
            objBPatron.InterfaceLanguage = Session("InterfaceLanguage")
            objBPatron.DBServer = Session("DBServer")
            objBPatron.ConnectionString = Session("ConnectionString")
            Call objBPatron.Initialize()
        End Sub

        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("JSSelf", "<script language = 'javascript' src = '../js/Policy/WRenew.js'></script>")
            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lblFixDueDate, txtFixDueDate, ddlLabel.Items(4).Text)
            txtFixDueDate.Attributes.Add("onChange", "javascript:CheckDate(this,'" & Session("DateFormat") & "','" & ddlLabel.Items(4).Text & " (" & Session("DateFormat") & ")');")
            txtFixDueDate.ToolTip = Session("DateFormat")
        End Sub

        Private Sub BindData()
            Dim tblRenew As New DataTable
            Dim bytType As Byte
            Dim strTypeVal As String
            Dim arrLabel()
            Dim blnFound As Boolean = False

            arrLabel = Split(ddlLabel.Items(2).Text, "|")

            If optCardNo.Checked Then
                bytType = 1
            ElseIf optHolding.Checked Then
                bytType = 3
            Else
                bytType = 2
            End If

            strTypeVal = txtTypeVal.Text
            objBLoanTrans.UserID = Session("UserID")
            tblRenew = objBLoanTrans.GetRenewInfor(bytType, strTypeVal, arrLabel)
            txthidRenewalPeriod.Value = 0
            If Not tblRenew Is Nothing Then
                If tblRenew.Rows.Count > 0 Then
                    txthidRenewalPeriod.Value = tblRenew.Rows(0).Item("RenewalPeriod")
                    dtgReNewInfor.DataSource = tblRenew
                    'dtgReNewInfor.DataBind()
                    dtgReNewInfor.Visible = True
                    btnRenew.Visible = True
                    blnFound = True
                End If
                If Not blnFound Then
                    dtgReNewInfor.Visible = False
                    btnRenew.Visible = False
                End If
            End If
        End Sub

        Protected Sub dtgReNewInfor_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles dtgReNewInfor.NeedDataSource
            BindData()
        End Sub

        Private Sub btnRenew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRenew.Click
            Dim strID As String = ""
            Dim intID As Integer
            Dim intCount As Integer = 0
            Dim bytRenewalPeriod As Byte
            Dim tblPatronInfor As DataTable
            Dim strDueDate As String
            Dim _lblDueDate As String = ""

            bytRenewalPeriod = CByte(txthidRenewalPeriod.Value)
            For intCount = 0 To dtgReNewInfor.Items.Count - 1
                If CType(dtgReNewInfor.Items(intCount).FindControl("chkID"), HtmlInputCheckBox).Checked Then
                    'Check Renew
                    If CInt(CType(dtgReNewInfor.Items(intCount).Cells(6).FindControl("lblRenewCount"), Label).Text) >= CInt(CType(dtgReNewInfor.Items(intCount).Cells(7).FindControl("lblRenewals"), Label).Text) Then
                        Page.RegisterClientScriptBlock("ErrJS", "<script language='javascript'>alert('" & ddlLabel.Items(6).Text & "');</script>")
                    Else
                        If txtFixDueDate.Text <> "" Then
                            'Check(ExpiredDate And txtFixDueDate)
                            objBPatron.PatronCode = CStr(CType(dtgReNewInfor.Items(intCount).FindControl("lblPatronCode"), Label).Text)
                            tblPatronInfor = objBPatron.GetPatronInfor(txtFixDueDate.Text)
                            If Not tblPatronInfor Is Nothing Then
                                If tblPatronInfor.Rows.Count > 0 Then
                                    If CInt(tblPatronInfor.Rows(0).Item("intByte")) = 1 Then
                                        Page.RegisterClientScriptBlock("ErrJS", "<script language='javascript'>alert('" & ddlLabel.Items(5).Text & "');</script>")
                                    Else
                                        'If ngay gia han nho hon ngay hien tai
                                        'lblDueDate
                                        strDueDate = CStr(CType(dtgReNewInfor.Items(intCount).FindControl("lblToday"), Label).Text)
                                        _lblDueDate = CStr(CType(dtgReNewInfor.Items(intCount).FindControl("lblDueDate"), Label).Text)
                                        If CDate(txtFixDueDate.Text) < CDate(strDueDate) Then
                                            Page.RegisterClientScriptBlock("ErrJS", "<script language='javascript'>alert('" & ddlLabel.Items(7).Text & "');</script>")
                                        ElseIf CDate(txtFixDueDate.Text) < CDate(_lblDueDate) Then
                                            Page.RegisterClientScriptBlock("ErrJS", "<script language='javascript'>alert('" & ddlLabel.Items(7).Text & "');</script>")
                                        ElseIf DateDiff("d", Now, CDate(_lblDueDate)) < 0 Then
                                            Page.RegisterClientScriptBlock("ErrJS", "<script language='javascript'>alert('" & ddlLabel.Items(10).Text & "');</script>")
                                        Else
                                            strID = CType(dtgReNewInfor.Items(intCount).FindControl("lblID"), Label).Text
                                            If strID <> "" Then
                                                intID = CInt(strID)
                                            Else
                                                intID = 0
                                            End If
                                            objBLoanTrans.Renew(intID, bytRenewalPeriod, 1, txtFixDueDate.Text)
                                            ' Msg OK
                                            Page.RegisterClientScriptBlock("SucJS", "<script language='javascript'>alert('" & ddlLabel.Items(9).Text & "');</script>")
                                            ' WriteLog
                                            Call WriteLog(107, ddlLabel.Items(3).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                                        End If
                                    End If
                                End If
                            End If
                        Else
                            _lblDueDate = CStr(CType(dtgReNewInfor.Items(intCount).FindControl("lblDueDate"), Label).Text)
                            If DateDiff("d", Now, CDate(_lblDueDate)) < 0 Then
                                Page.RegisterClientScriptBlock("ErrJS", "<script language='javascript'>alert('" & ddlLabel.Items(10).Text & "');</script>")
                            Else
                                strID = CType(dtgReNewInfor.Items(intCount).FindControl("lblID"), Label).Text
                                If strID <> "" Then
                                    intID = CInt(strID)
                                Else
                                    intID = 0
                                End If
                                objBLoanTrans.Renew(intID, bytRenewalPeriod, 1, txtFixDueDate.Text)
                                ' Msg OK
                                Page.RegisterClientScriptBlock("SucJS", "<script language='javascript'>alert('" & ddlLabel.Items(9).Text & "');</script>")
                                ' WriteLog
                                Call WriteLog(107, ddlLabel.Items(3).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                            End If
                        End If
                    End If
                End If
            Next intCount
            Call BindData()
            dtgReNewInfor.Rebind()

        End Sub

        Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
            Call BindData()
            dtgReNewInfor.Rebind()
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBLoanTrans Is Nothing Then
                    objBLoanTrans.Dispose(True)
                    objBLoanTrans = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        Public Function NumberOfRecord() As Integer Implements IUCNumberOfRecord.NumberOfRecord
            Return 25
        End Function
    End Class
End Namespace