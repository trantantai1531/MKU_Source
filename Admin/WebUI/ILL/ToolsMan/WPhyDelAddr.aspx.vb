' Class: WPhyDelAddr.aspx
' Puspose: management physical delivery address
' Creator: Sondp
' CreatedDate: 25/11/2004
' Modification History:
'   - 23/04/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.ILL

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WPhyDelAddr
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
        Private objBPhyDelAddr As New clsBPhyDelAddress
        Private objBCB As New clsBCommonBusiness

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            'Quan ly danh muc
            If Not CheckPemission(155) Then
                btnUpdate.Enabled = False
                btnDelete.Enabled = False
                btnUpdate.Enabled = False
            End If
            'Nhap moi
            If CheckPemission(207) Then
                btnUpdate.Enabled = True
            End If
            'Xoa
            If CheckPemission(210) Then
                btnDelete.Enabled = True
            End If
            'Sua
            If CheckPemission(209) Then
                btnUpdate.Enabled = True
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: Init all need objects
        Private Sub Initialize()
            ' Initilaize objBPhyDelAddr object
            objBPhyDelAddr.ConnectionString = Session("ConnectionString")
            objBPhyDelAddr.InterfaceLanguage = Session("InterfaceLanguage")
            objBPhyDelAddr.DBServer = Session("DBServer")
            Call objBPhyDelAddr.Initialize()

            ' Init objBCB object
            objBCB.ConnectionString = Session("ConnectionString")
            objBCB.InterfaceLanguage = Session("InterfaceLanguage")
            objBCB.DBServer = Session("DBServer")
            Call objBCB.Initialize()
        End Sub

        ' Method: BindData
        Private Sub BindData()
            Dim tblPhyDelAddr As New DataTable
            Dim tblCountry As New DataTable
            Dim lsitem As New ListItem
            Dim blnFound As Boolean = False
            Dim inti As Integer

            hdAddressIndex.Value = ""
            objBPhyDelAddr.ID = 0
            objBPhyDelAddr.LibID = clsSession.GlbSite
            tblPhyDelAddr = objBPhyDelAddr.GetPhyDelAddr(True)

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPhyDelAddr.ErrorMsg, ddlLabel.Items(0).Text, objBPhyDelAddr.ErrorCode)

            ' Catch error
            If Not tblPhyDelAddr Is Nothing Then
                If tblPhyDelAddr.Rows.Count > 0 Then
                    lsbAddressIndex.DataSource = InsertOneRow(tblPhyDelAddr, ddlLabel.Items(3).Text)
                    lsbAddressIndex.DataValueField = "splittor"
                    lsbAddressIndex.DataTextField = "Address"
                    lsbAddressIndex.DataBind()
                    lsbAddressIndex.SelectedIndex = 0
                    blnFound = True
                End If
            End If

            If Not blnFound Then
                lsitem.Value = "0"
                lsitem.Text = ddlLabel.Items(3).Text
                lsbAddressIndex.Items.Add(lsitem)
                lsbAddressIndex.SelectedIndex = 0
            End If

            tblCountry = objBCB.GetCountries

            ' Catch error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCB.ErrorMsg, ddlLabel.Items(0).Text, objBCB.ErrorCode)

            If Not tblCountry Is Nothing Then
                If tblCountry.Rows.Count > 0 Then
                    ddlCountry.DataSource = InsertOneRow(tblCountry, ddlLabel.Items(2).Text)
                    ddlCountry.DataTextField = "DisplayEntry"
                    ddlCountry.DataValueField = "ID"
                    ddlCountry.DataBind()
                    For inti = 0 To tblCountry.Rows.Count - 1
                        If CStr(tblCountry.Rows(inti).Item("ISOCode")).ToLower = "vm" Then
                            ddlCountry.SelectedIndex = inti + 1
                            Exit For
                        End If
                    Next

                End If
            End If
        End Sub

        ' Method: BindScript
        ' Purpose: Include all need js functions
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("TempalteJs", "<script language='javascript' src='../JS/ToolsMan/WPhyDelAddr.js'></script>")

            lsbAddressIndex.Attributes.Add("OnClick", "javascript:SplitIt();return(false);")

            btnClose.Attributes.Add("OnClick", "javascript:self.close();")
            btnUpdate.Attributes.Add("OnClick", "javascript:return(CheckUpdate('" & ddlLabel.Items(4).Text & "'));")
            btnDelete.Attributes.Add("OnClick", "javascript:return(CheckDelete('" & ddlLabel.Items(5).Text & "', '" & ddlLabel.Items(10).Text & "'));")
        End Sub

        ' Method: ResetForm
        ' Purpose: Reset form
        Private Sub ResetForm()
            hdAddressIndex.Value = ""
            txtAddress.Text = ""
            txtXAddress.Text = ""
            txtStreet.Text = ""
            txtPOBox.Text = ""
            txtCity.Text = ""
            txtRegion.Text = ""
            ddlCountry.Items(0).Selected = True
            txtPostCode.Text = ""
            lsbAddressIndex.Items(0).Selected = True
        End Sub

        ' Event: btnAddnew_Click
        ' Purpose: Create new PhyDelAddr method
        Private Sub btnAddnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim intOut As Integer = 0
            If txtAddress.Text.Trim <> "" Then
                objBPhyDelAddr.Address = txtAddress.Text.Trim
                objBPhyDelAddr.City = txtCity.Text.Trim
                objBPhyDelAddr.CountryID = ddlCountry.SelectedValue
                objBPhyDelAddr.POBox = txtPOBox.Text.Trim
                objBPhyDelAddr.PostCode = txtPostCode.Text.Trim
                objBPhyDelAddr.Region = txtRegion.Text.Trim
                objBPhyDelAddr.Street = txtStreet.Text.Trim
                objBPhyDelAddr.XAddress = txtXAddress.Text.Trim
                objBPhyDelAddr.LibID = clsSession.GlbSite
                Call ResetForm()
                Call BindData()
            End If
        End Sub

        ' Event: btnDelete_Click
        ' Purpose: Delete PhyDelAddr
        Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            Dim intOut As Integer

            If hdAddressIndex.Value <> "" Then
                objBPhyDelAddr.ID = hdAddressIndex.Value.Split("<$#$>")(0)
                intOut = objBPhyDelAddr.Delete()

                ' Catch error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPhyDelAddr.ErrorMsg, ddlLabel.Items(0).Text, objBPhyDelAddr.ErrorCode)
                If intOut > 0 Then
                    Page.RegisterClientScriptBlock("Alert6Msg", "<script language='javascript'>alert('" & ddlLabel.Items(12).Text & "');</script>")
                Else
                    Page.RegisterClientScriptBlock("Alert6Msg", "<script language='javascript'>alert('" & ddlLabel.Items(13).Text & "');</script>")
                End If

                ' WriteLog
                Call WriteLog(67, ddlLabel.Items(7).Text & ": " & txtAddress.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                ' Refresh data
                Call ResetForm()
                Call BindData()
            End If
        End Sub

        ' Event: btnUpdate_Click
        ' Purpose: Update PhyDelAddr
        Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Dim intOut As Integer = 0
            If txtAddress.Text.Trim <> "" Then
                objBPhyDelAddr.Address = txtAddress.Text.Trim
                objBPhyDelAddr.City = txtCity.Text.Trim
                objBPhyDelAddr.CountryID = ddlCountry.SelectedValue
                objBPhyDelAddr.POBox = txtPOBox.Text.Trim
                objBPhyDelAddr.PostCode = txtPostCode.Text.Trim
                objBPhyDelAddr.Region = txtRegion.Text.Trim
                objBPhyDelAddr.Street = txtStreet.Text.Trim
                objBPhyDelAddr.XAddress = txtXAddress.Text.Trim
                objBPhyDelAddr.LibID = clsSession.GlbSite
                If lsbAddressIndex.SelectedIndex > 0 Then
                    If hdAddressIndex.Value <> "" Then
                        objBPhyDelAddr.ID = hdAddressIndex.Value.Split("<$#$>")(0) 'lsbAddressIndex.SelectedValue.Split("<$#$>")(0)
                        intOut = objBPhyDelAddr.Update()

                        ' Catch error
                        Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPhyDelAddr.ErrorMsg, ddlLabel.Items(0).Text, objBPhyDelAddr.ErrorCode)

                        ' WriteLog
                        Call WriteLog(67, ddlLabel.Items(6).Text & ": " & txtAddress.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                        If intOut = 0 Then
                            Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(6).Text & " " & txtAddress.Text.Trim & " " & ddlLabel.Items(8).Text & "');</script>")
                        Else
                            Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(9).Text & "');</script>")
                        End If
                    End If
                Else
                    intOut = objBPhyDelAddr.Create()

                    ' Catch error
                    Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPhyDelAddr.ErrorMsg, ddlLabel.Items(0).Text, objBPhyDelAddr.ErrorCode)

                    ' WriteLog
                    Call WriteLog(67, ddlLabel.Items(6).Text & ": " & txtAddress.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                    If intOut = 0 Then
                        Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(6).Text & " " & txtAddress.Text.Trim & " " & ddlLabel.Items(8).Text & "');</script>")
                    Else
                        Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(9).Text & "');</script>")
                    End If
                End If

                Call ResetForm()
                Call BindData()
            End If
        End Sub

        ' Event: Page UnLoad
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBPhyDelAddr Is Nothing Then
                    objBPhyDelAddr.Dispose(True)
                    objBPhyDelAddr = Nothing
                End If
                If Not objBCB Is Nothing Then
                    objBCB.Dispose(True)
                    objBCB = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace