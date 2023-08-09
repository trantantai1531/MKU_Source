' Class: WCloseInventory
' Puspose: Close inventory
' Creator: Tuanhv
' CreatedDate: 09/03/2004
' Modification History:

Imports eMicLibAdmin.BusinessRules.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WCloseInventory
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
        Private objBInventory As New clsBInventory

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call LoadInventories()
            End If
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            'If Not CheckPemission(41) Then
            '    btnClose.Enabled = False
            'End If
            If Not CheckPemission(41) And Not CheckPemission(117) Then
                btnClose.Enabled = False
            End If
        End Sub
        ' BindJS method
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
        End Sub

        ' Method: Initialize
        ' Purpose: Init all neccessary objects
        Private Sub Initialize()
            ' Init objBLibrary object
            objBInventory.DBServer = Session("DBServer")
            objBInventory.ConnectionString = Session("ConnectionString")
            objBInventory.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBInventory.Initialize()

            txtDateClose.Text = Session("ToDay")
            txtDateClose.ToolTip = Session("DateFormat")
            txtDateClose.Attributes.Add("OnChange", "if (!CheckDate(this, '" & Session("DateFormat") & "', '" & ddlLabel.Items(0).Text.Trim & " (" & Session("DateFormat") & ")')) {}")
        End Sub

        ' Method: LoadInventories
        ' Purpose: Load list of inventories
        Private Sub LoadInventories()
            Dim tblResult As DataTable

            ' Get Inventory
            objBInventory.LibID = clsSession.GlbSite
            tblResult = objBInventory.GetInventory(0)
            txtDateClose.Visible = False
            lblDateClose.Visible = False
            lblInventoryName.Visible = False
            btnClose.Visible = False
            ddlInventory.Visible = False
            ' Bind inventory
            If Not tblResult Is Nothing Then
                If tblResult.Rows.Count > 0 Then
                    txtDateClose.Visible = True
                    lblDateClose.Visible = True
                    lblInventoryName.Visible = True
                    ddlInventory.Visible = True
                    btnClose.Visible = True
                    ddlInventory.DataValueField = "ID"
                    ddlInventory.DataTextField = "Name"
                    ddlInventory.DataSource = tblResult
                    ddlInventory.DataBind()
                    ddlInventory.Items(0).Selected = True
                    Session("InventoryID") = ddlInventory.SelectedValue
                    tblResult = Nothing
                Else
                    tblResult = objBInventory.GetInventory(1)
                    txtDateClose.Visible = False
                    lblDateClose.Visible = False
                    lblInventoryName.Visible = True
                    btnClose.Visible = False
                    ddlInventory.Visible = True
                    ddlInventory.DataValueField = "ID"
                    ddlInventory.DataTextField = "Name"
                    ddlInventory.DataSource = tblResult
                    ddlInventory.DataBind()
                    ddlInventory.Items(0).Selected = True
                    Session("InventoryID") = ddlInventory.SelectedValue
                    tblResult = Nothing
                End If
            End If
        End Sub

        ' Event: btnClose_Click
        ' Purpose: Close the current inventory
        Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Try
                objBInventory.InventoryID = CInt(ddlInventory.SelectedValue)
                Call objBInventory.CloseInventory()

                ' Alert mess
                Page.RegisterClientScriptBlock("JSSucc", "<script language='javascript'>alert('" & ddlLabel.Items(2).Text & "');</script>")

                ' Reload data
                Call LoadInventories()
            Catch ex As Exception
                Call WriteErrorMssg(ddlLabel.Items(1).Text, ex.Message.Trim, ddlLabel.Items(0).Text, 0)
            End Try
        End Sub

        ' Event: ddlInventory_SelectedIndexChanged
        Private Sub ddlInventory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlInventory.SelectedIndexChanged
            Session("InventoryID") = ddlInventory.SelectedValue
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBInventory Is Nothing Then
                    objBInventory.Dispose(True)
                    objBInventory = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
