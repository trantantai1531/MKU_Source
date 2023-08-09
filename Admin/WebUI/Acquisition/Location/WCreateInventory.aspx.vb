' Class WCreateInventory
' Puspose: Create inventory
' Creator: Tuanhv
' CreatedDate: 23/03/2004
' Modification History:

Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WCreateInventory
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

        Private objBInventory As New clsBInventory

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(176) Then
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub

        ' Initialize method
        ' Purpose: Init all neccessary objects
        Private Sub Initialize()
            ' Init objBLibrary object
            objBInventory.DBServer = Session("DBServer")
            objBInventory.ConnectionString = Session("ConnectionString")
            objBInventory.InterfaceLanguage = Session("InterfaceLanguage")
            objBInventory.Initialize()

            txtInputer.Text = clsSession.GlbUserFullName
            txtInputer.Enabled = False

            txtStartDate.Text = Session("ToDay")
        End Sub

        ' BindJS method
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkDate, txtStartDate, ddlLabel.Items(5).Text)

            btnReset.Attributes.Add("OnClick", "document.forms[0].reset(); return false;")
            btnInit.Attributes.Add("OnClick", "if ((CheckNull(document.forms[0].txtInventoryName)) || (CheckNull(document.forms[0].txtStartDate))) {alert('" & ddlLabel.Items(4).Text & "'); return false;}")
        End Sub

        ' Method: ClearTextBox
        Sub ClearTextBox()
            txtInventoryName.Text = ""
        End Sub

        ' Method: btnInit_Click
        Private Sub btnInit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInit.Click
            Dim intRetVal As Integer

            ' Create inventory
            objBInventory.InventoryName = txtInventoryName.Text.Trim
            objBInventory.InventoryDate = txtStartDate.Text.Trim
            objBInventory.Inputer = clsSession.GlbUserFullName
            objBInventory.LibID = clsSession.GlbSite
            intRetVal = objBInventory.NewInventory
            If intRetVal > 0 Then
                Page.RegisterClientScriptBlock("SuccessJs", "<script language='javascript'>alert('" & ddlLabel.Items(7).Text & "');</script>")
                Call ClearTextBox()
            Else
                Page.RegisterClientScriptBlock("SuccessJs", "<script language='javascript'>alert('" & ddlLabel.Items(6).Text & "');</script>")
                ' Write log
                Call WriteLog(95, ddlLabel.Items(3).Text & ":" & objBInventory.InventoryName, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName & "," & objBInventory.Inputer)
            End If
            Call ClearTextBox()
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