' Class: WAcquire
' Puspose: Binding for the selected periodical
' Creator: Oanhtn
' CreatedDate: 21/09/2004
' Modification history:
'   - 08/10/2004 by Oanhtn: write some method

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Serial
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.BusinessRules.Circulation

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WBinding
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
        Private objBPeriodical As New clsBPeriodical
        Private objBCopyNumber As New clsBCopyNumber
        Private objBLoanType As New clsBLoanType
        Private objBBindingVolume As New clsBBindingVolume
        Private objBCommonBusiness As New clsBCommonBusiness

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            Call HideControls()
            If Not Page.IsPostBack Then
                Call BindData()
                Call CheckBindingPeriod()
            End If
            If Not hidCopyNumberID.Value = "0" Then
                Call ChangeYear(ddlYear.SelectedValue, ddlLocation.SelectedValue)
                'Call ShowCopiesOfBind(ddlYear.SelectedValue, ddlLocation.SelectedValue, CLng(hidCopyNumberID.Value))
            End If
            'Call CheckBindingPeriod()
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permissions
        Private Sub CheckFormPermission()
            If Not CheckPemission(196) Then
                btnUpdate.Enabled = False
            End If
        End Sub

        ' Method: CheckBindingPeriod
        ' Purpose: Check binding period for the selected Periodical
        Private Sub CheckBindingPeriod()
            Dim intRetVal As Integer = 0

            If IsNumeric(ddlLocation.SelectedValue) Then
                objBPeriodical.ItemID = Session("ItemID")
                objBPeriodical.LocationID = ddlLocation.SelectedValue
                intRetVal = objBPeriodical.CheckBindingPeriod

                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPeriodical.ErrorMsg, ddlLabel.Items(0).Text, objBPeriodical.ErrorCode)

                If intRetVal > 0 Then
                    Page.RegisterClientScriptBlock("AlertBindingNowJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(4).Text & "');</script>")
                End If
            End If
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            If Not IsNumeric(Session("ItemID")) Then
                Response.Redirect("../WSearch.aspx?URL=Acquisition/WBinding.aspx")
            End If

            ' Init objBCopyNumber object
            objBCopyNumber.InterfaceLanguage = Session("InterfaceLanguage")
            objBCopyNumber.DBServer = Session("DBServer")
            objBCopyNumber.ConnectionString = Session("ConnectionString")
            Call objBCopyNumber.Initialize()

            ' Init objBLoanType object
            objBLoanType.InterfaceLanguage = Session("InterfaceLanguage")
            objBLoanType.DBServer = Session("DBServer")
            objBLoanType.ConnectionString = Session("ConnectionString")
            Call objBLoanType.Initialize()

            ' Init objBBindingVolume object
            objBBindingVolume.InterfaceLanguage = Session("InterfaceLanguage")
            objBBindingVolume.DBServer = Session("DBServer")
            objBBindingVolume.ConnectionString = Session("ConnectionString")
            Call objBBindingVolume.Initialize()

            ' Init objBPeriodical object
            objBPeriodical.InterfaceLanguage = Session("InterfaceLanguage")
            objBPeriodical.DBServer = Session("DBServer")
            objBPeriodical.ConnectionString = Session("ConnectionString")
            objBPeriodical.ItemID = Session("ItemID")
            Call objBPeriodical.Initialize()

            ' Init objBCommonBusiness object
            objBCommonBusiness.ConnectionString = Session("ConnectionString")
            objBCommonBusiness.DBServer = Session("DBServer")
            objBCommonBusiness.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonBusiness.UserID = Session("UserID")
            Call objBCommonBusiness.Initialize()
        End Sub

        ' BindJS method
        ' Purpose: Include all javascript functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../Js/Acquisition/WBinding.js'></script>")

            txtPrice.Attributes.Add("OnChange", "CheckNumBer(this, '" & ddlLabel.Items(5).Text & "');")

            btnUpdate.Attributes.Add("OnClick", "document.forms[0].hidCopyNumberID.value='0'; if (!CheckAll()) {alert('" & ddlLabel.Items(6).Text & "'); return false;}")

            lnkHdAcquire.NavigateUrl = "WAcquire.aspx"
            lnkHdSetRegularity.NavigateUrl = "WSetRegularity.aspx"
            lnkHdRegister.NavigateUrl = "WCreateIssue.aspx"
            lnkHdReceive.NavigateUrl = "WReceive.aspx"
            lnkHdView.NavigateUrl = "WViewInCalendarMode.aspx"
            lnkHdSummary.NavigateUrl = "WSummaryHoldingManagement.aspx"
            lnkBinding.NavigateUrl = "WSetBindRule.aspx"
            btnGenCopyNum.Attributes.Add("Onclick", "parent.Hiddenbase.location.href='WGenCopyNumber.aspx?LocID=' + document.forms[0].ddlLocation.options[document.forms[0].ddlLocation.options.selectedIndex].value; return false;")
            'btnUnBind.Attributes.Add("OnClick", "if (!confirm('" & ddlLabel.Items(9).Text & "')) {return false;}")
        End Sub

        ' BindData method
        ' Purpose: Load form now
        Private Sub BindData()
            Dim intLocationID As Integer
            Dim tblTemp As DataTable

            lblTitle.Text = "<H3>" & Session("Title") & "</H3>"

            ' Get Locations
            objBCommonBusiness.LibID = clsSession.GlbSite
            tblTemp = objBCommonBusiness.GetLocations(3)

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCommonBusiness.ErrorMsg, ddlLabel.Items(0).Text, objBCommonBusiness.ErrorCode)

            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    ddlLocation.DataSource = tblTemp
                    ddlLocation.DataTextField = "LOCNAME"
                    ddlLocation.DataValueField = "ID"
                    ddlLocation.DataBind()
                    intLocationID = tblTemp.Rows(0).Item("ID")
                    tblTemp.Clear()

                    ' Get ReceivedYear
                    Call ChangeLocation(intLocationID)
                End If
                tblTemp.Dispose()
                tblTemp = Nothing
            End If
        End Sub

        ' ChangeLocation method
        ' Purpose: Load form field's value depending on the selected location
        Private Sub ChangeLocation(ByVal intLocationID As Integer)
            Dim tblTemp As DataTable

            ' Get ReceivedYear
            ddlYear.Items.Clear()

            objBPeriodical.LocationID = intLocationID
            tblTemp = objBPeriodical.GetReceivedYear()

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPeriodical.ErrorMsg, ddlLabel.Items(0).Text, objBPeriodical.ErrorCode)

            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    ddlYear.DataSource = tblTemp
                    ddlYear.DataTextField = "Years"
                    ddlYear.DataValueField = "Years"
                    ddlYear.DataBind()
                    Call ChangeYear(tblTemp.Rows(0).Item("Years"), intLocationID)
                End If
                tblTemp.Dispose()
                tblTemp = Nothing
            End If
        End Sub

        ' ChangeYear method
        ' Purpose: Get copies of the selected volume
        Private Sub ChangeYear(ByVal intYear As Integer, ByVal intLocationID As Integer)
            Dim tblTemp As DataTable

            If intYear > 0 Then
                ' View CopiesToBind datagrid
                objBBindingVolume.IssuedYear = intYear
                objBBindingVolume.ItemID = Session("ItemID")
                objBBindingVolume.LocationID = intLocationID
                tblTemp = objBBindingVolume.GetCopiesToBind

                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBBindingVolume.ErrorMsg, ddlLabel.Items(0).Text, objBBindingVolume.ErrorCode)

                If Not tblTemp Is Nothing Then
                    If tblTemp.Rows.Count > 0 Then
                        dtgCopiesToBind.Visible = True
                        dtgCopiesToBind.DataSource = tblTemp
                        dtgCopiesToBind.DataBind()

                        ' Show controls
                        hidPrice.Value = tblTemp.Rows(0).Item("Price")
                        Call ShowControls()
                    End If
                End If
                tblTemp.Clear()

                ' Display all volumes (by library) of the selected periodical in the selected year and location
                tblTemp = objBBindingVolume.GetVolumeByLibrary("", 0)

                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBBindingVolume.ErrorMsg, ddlLabel.Items(0).Text, objBBindingVolume.ErrorCode)


                lblVolumeDetail.Visible = False
                If Not tblTemp Is Nothing Then
                    If tblTemp.Rows.Count > 0 Then
                        Dim intCount As Int16 = 0
                        Dim strVolumeDetail As String = ""
                        Dim tblCopyNumber As DataTable
                        Dim intj As Integer
                        Dim strCopyNumbers As String = ""

                        tblCopyNumber = objBBindingVolume.GetVolumeByLibrary("", 1)

                        For intCount = 0 To tblTemp.Rows.Count - 1
                            strCopyNumbers = ""
                            strCopyNumbers = strCopyNumbers & tblCopyNumber.Rows(intCount).Item("CopyNumber")

                            If strCopyNumbers <> "" Then
                                strVolumeDetail = strVolumeDetail & "<A CLASS=""lbLinkFunction"" HREF='#' onClick=""ShowBinding(" & tblTemp.Rows(intCount).Item("CopyNumberID") & ",'" & tblTemp.Rows(intCount).Item("VolumeByLibrary") & "')"">" & tblTemp.Rows(intCount).Item("VolumeByLibrary") & "(" & strCopyNumbers & ")</A><br>"
                            Else
                                strVolumeDetail = strVolumeDetail & "<A CLASS=""lbLinkFunction"" HREF='#' onClick=""ShowBinding(" & tblTemp.Rows(intCount).Item("CopyNumberID") & ",'" & tblTemp.Rows(intCount).Item("VolumeByLibrary") & "')"">" & tblTemp.Rows(intCount).Item("VolumeByLibrary") & "</A><br>"
                            End If
                            'strVolumeDetail = strVolumeDetail & "<A CLASS=""lbLinkFunction"" HREF='#' onClick=""ShowBinding(" & tblTemp.Rows(intCount).Item("CopyNumberID") & ",'" & tblTemp.Rows(intCount).Item("VolumeByLibrary") & "')"">" & tblTemp.Rows(intCount).Item("VolumeByLibrary") & "</A><br>"
                        Next
                        lblVolumeDetail.Visible = True
                        lblVolumeDetail.Text = Left(strVolumeDetail, Len(strVolumeDetail) - 4)

                        ' Show controls
                        Call ShowControls()
                    End If
                End If
                tblTemp.Dispose()
                tblTemp = Nothing
            End If
        End Sub

        ' HideControls method
        ' Purpose: Hide some form's controls
        Private Sub HideControls()
            lblVolumeDetail.Visible = False
            dtgCopiesToBind.Visible = False
            lblBindingInfor.Visible = False
            lblLoanType.Visible = False
            ddlLoanType.Visible = False
            lblAcqSource.Visible = False
            ddlAcqSource.Visible = False
            lblPrice.Visible = False
            txtPrice.Visible = False
            lblVolume.Visible = False
            txtVolume.Visible = False
            lblShelf.Visible = False
            txtShelf.Visible = False
            lblCopyNumber.Visible = False
            txtCopyNumber.Visible = False
            btnUpdate.Visible = False
            Label1.Visible = False
            Label2.Visible = False
            lblLabel3.Visible = False
            btnGenCopyNum.Visible = False
        End Sub

        ' ShowControls method
        ' Purpose: Show some form's controls
        Private Sub ShowControls()
            Dim tblTemp As DataTable

            lblBindingInfor.Visible = True
            lblLoanType.Visible = True
            ddlLoanType.Visible = True
            lblAcqSource.Visible = True
            ddlAcqSource.Visible = True
            lblPrice.Visible = True
            txtPrice.Visible = True
            lblVolume.Visible = True
            txtVolume.Visible = True
            lblShelf.Visible = True
            txtShelf.Visible = True
            lblCopyNumber.Visible = True
            txtCopyNumber.Visible = True
            btnUpdate.Visible = True
            Label1.Visible = True
            Label2.Visible = True
            lblLabel3.Visible = True
            btnGenCopyNum.Visible = True
            ' Load AcqSource
            tblTemp = objBCommonBusiness.GetAcqSources

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBBindingVolume.ErrorMsg, ddlLabel.Items(0).Text, objBBindingVolume.ErrorCode)

            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    ddlAcqSource.DataSource = tblTemp
                    ddlAcqSource.DataTextField = "Source"
                    ddlAcqSource.DataValueField = "ID"
                    ddlAcqSource.DataBind()
                End If
                tblTemp.Clear()
            End If

            ' Load LoanType
            tblTemp = objBLoanType.GetLoanTypes

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBLoanType.ErrorMsg, ddlLabel.Items(0).Text, objBLoanType.ErrorCode)

            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    ddlLoanType.DataSource = tblTemp
                    ddlLoanType.DataTextField = "LoanType"
                    ddlLoanType.DataValueField = "ID"
                    ddlLoanType.DataBind()
                End If
                tblTemp.Clear()
            End If

            ' Release object
            If Not tblTemp Is Nothing Then
                tblTemp.Dispose()
                tblTemp = Nothing
            End If
        End Sub

        ' btnUpdate_Click event
        ' Purpose: Create new Volume (by library)
        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Dim dtgItem As DataGridItem
            Dim chkCopyID As HtmlInputCheckBox
            Dim strCopyIDs As String = ""
            Dim intCount As Integer = 0
            Dim intResult As Integer = 0

            For Each dtgItem In dtgCopiesToBind.Items
                chkCopyID = dtgItem.FindControl("chkID")
                If chkCopyID.Checked Then
                    strCopyIDs = strCopyIDs & CType(dtgItem.FindControl("lblID"), Label).Text & ","
                    intCount = intCount + 1
                End If
            Next

            ' First, create new copynumber record
            Dim intAcqSourceID As Integer = ddlAcqSource.SelectedValue
            Dim intLocationID As Integer = ddlLocation.SelectedValue
            Dim strShelf As String = Trim(txtShelf.Text)
            Dim strCopyNumber As String = Trim(txtCopyNumber.Text)
            Dim dblPrice As Double = Trim(txtPrice.Text)
            Dim intLoanTypeID As Integer = ddlLoanType.SelectedValue

            ' Then, update CopynumberID for all selected copies
            If Not strCopyIDs = "" Then
                strCopyIDs = Trim(Left(strCopyIDs, Len(strCopyIDs) - 1))
                objBBindingVolume.LocationID = intLocationID
                objBBindingVolume.CopyNumber = strCopyNumber
                objBBindingVolume.Shelf = strShelf
                objBBindingVolume.LoanTypeID = intLoanTypeID
                objBBindingVolume.AcqSourceID = intAcqSourceID
                objBBindingVolume.Price = dblPrice
                objBBindingVolume.ItemID = Session("ItemID")
                objBBindingVolume.VolumeByLibrary = txtVolume.Text.Trim
                objBBindingVolume.CopyIDs = strCopyIDs
                intResult = objBBindingVolume.Bind

                ' Check error
                'Call WriteErrorMssg(ddlLabel.Items(1).Text, objBBindingVolume.ErrorMsg, ddlLabel.Items(0).Text, objBBindingVolume.ErrorCode)

                ' WriteLog
                Call WriteLog(34, ddlLabel.Items(2).Text & " " & txtVolume.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                If intResult = 0 Then
                    If objBBindingVolume.ErrorMsg = "" Then
                        Page.RegisterClientScriptBlock("SuccessJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(7).Text & "');</script>")

                        txtPrice.Text = "0"
                        txtCopyNumber.Text = ""
                        txtShelf.Text = ""
                        txtVolume.Text() = ""
                    Else
                        Page.RegisterClientScriptBlock("ErrorJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(11).Text & "');</script>")
                    End If
                End If
            Else
                Page.RegisterClientScriptBlock("NotSelectedJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(8).Text & "');</script>")
            End If

            ' Refresh
            Call ChangeYear(ddlYear.SelectedValue, ddlLocation.SelectedValue)
        End Sub

        ' ddlLocation_SelectedIndexChanged event
        ' Purpose: Change Location
        Private Sub ddlLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlLocation.SelectedIndexChanged
            Try
                hidCopyNumberID.Value = "0"
                Call ChangeLocation(ddlLocation.SelectedValue)
                CheckBindingPeriod()
            Catch ex As Exception
            End Try
        End Sub

        ' ddlYear_SelectedIndexChanged event
        ' Purpose: change year
        Private Sub ddlYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlYear.SelectedIndexChanged
            Try
                hidCopyNumberID.Value = "0"
                dtgCopiesToBind.Visible = False
                Call ChangeYear(ddlYear.SelectedValue, ddlLocation.SelectedValue)
            Catch ex As Exception
            End Try
        End Sub

        ' btnUnBind_Click event
        ' Purpose: unbind for the selected volume
        Private Sub btnUnBind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            objBBindingVolume.ItemID = Session("ItemID")
            objBBindingVolume.CopyNumberID = CLng(hidCopyNumberID.Value)
            Call objBBindingVolume.UnBind()

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBBindingVolume.ErrorMsg, ddlLabel.Items(0).Text, objBBindingVolume.ErrorCode)

            ' WriteLog
            Call WriteLog(34, ddlLabel.Items(3).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

            ' Success
            Page.RegisterClientScriptBlock("sucess", "<script language='javascript'>alert('" & ddlLabel.Items(10).Text & "');</script>")

            ' Refresh
            hidCopyNumberID.Value = ""
            Call ChangeYear(ddlYear.SelectedValue, ddlLocation.SelectedValue)
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBBindingVolume Is Nothing Then
                    objBBindingVolume.Dispose(True)
                    objBBindingVolume = Nothing
                End If
                If Not objBPeriodical Is Nothing Then
                    objBPeriodical.Dispose(True)
                    objBPeriodical = Nothing
                End If
                If Not objBCommonBusiness Is Nothing Then
                    objBCommonBusiness.Dispose(True)
                    objBCommonBusiness = Nothing
                End If
                If Not objBLoanType Is Nothing Then
                    objBLoanType.Dispose(True)
                    objBLoanType = Nothing
                End If
                If Not objBCopyNumber Is Nothing Then
                    objBCopyNumber.Dispose(True)
                    objBCopyNumber = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        Private Sub dtgCopiesToBind_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgCopiesToBind.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.SelectedItem, ListItemType.AlternatingItem
                    Dim ckbTemp As HtmlInputCheckBox
                    ckbTemp = CType(e.Item.FindControl("chkID"), HtmlInputCheckBox)
                    ckbTemp.Attributes.Add("onClick", "SetPrice(this.checked);")
            End Select
        End Sub
    End Class
End Namespace