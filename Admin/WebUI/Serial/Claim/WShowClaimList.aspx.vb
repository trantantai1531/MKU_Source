' Class: WShowClaimList
' Puspose: Show claim list
' Creator: Oanhtn
' CreatedDate: 21/09/2004
' Modification history:
'   - 18/10/2004 by Sondp: show all Claim List
'   - 20/04/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Serial
Imports eMicLibAdmin.BusinessRules.Acquisition

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WShowClaimList
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents ClaimReview As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents lblFromDate As System.Web.UI.WebControls.Label
        Protected WithEvents lblSelectVendor As System.Web.UI.WebControls.Label
        Protected WithEvents lblVendorAlert As System.Web.UI.WebControls.Label
        Protected WithEvents lblFromDateAlert As System.Web.UI.WebControls.Label
        Protected WithEvents lblToDateAlert As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBPeriodicalCollection As New clsBPeriodicalCollection
        Private objBVendor As New clsBVendor

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
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            If Not CheckPemission(97) Then
                btnReview.Enabled = False
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init objBPeriodicalCollection object
            objBPeriodicalCollection.ConnectionString = Session("ConnectionString")
            objBPeriodicalCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBPeriodicalCollection.DBServer = Session("DBServer")
            Call objBPeriodicalCollection.Initialize()

            ' Init objBVendor object
            objBVendor.ConnectionString = Session("ConnectionString")
            objBVendor.InterfaceLanguage = Session("InterfaceLanguage")
            objBVendor.DBServer = Session("DBServer")
            Call objBVendor.Initialize()

            dgrClaimReview.Visible = False
        End Sub

        ' Method: Bind Script
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")

            ddlVendor.Attributes.Add("OnChange", "javascript:return false;")
            Me.RegisterCalendar("../..")
            SetOnclickCalendar(hrfFromDate, txtFromDate, ddlLabel.Items(4).Text)
            SetOnclickCalendar(hrfToDate, txtToDate, ddlLabel.Items(4).Text)

            btnReview.Attributes.Add("OnClick", "javascript:if((!CheckDate(document.forms[0].txtFromDate,'dd/mm/yyyy','" & ddlLabel.Items(4).Text & "')) || (!CheckDate(document.forms[0].txtToDate,'dd/mm/yyyy',' " & ddlLabel.Items(4).Text & "'))){return false;}else{return true;}")

            txtFromDate.Attributes.Add("OnChange", "return CheckDate(this, '" & Session("DateFormat") & "', '" & ddlLabel.Items(4).Text & " (" & Session("DateFormat") & ")')")
            txtFromDate.ToolTip = Session("DateFormat")
            txtToDate.Attributes.Add("OnChange", "return CheckDate(this, '" & Session("DateFormat") & "', '" & ddlLabel.Items(4).Text & " (" & Session("DateFormat") & ")')")
            txtToDate.ToolTip = Session("DateFormat")
        End Sub

        ' Method: BindData
        Private Sub BindData()
            Dim tblVendor As DataTable
            Dim item As New ListItem
            Dim blnFound As Boolean = False

            objBVendor.VendorID = 0 ' Get all vendors
            tblVendor = objBVendor.GetVendor

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBVendor.ErrorMsg, ddlLabel.Items(0).Text, objBVendor.ErrorCode)

            If Not tblVendor Is Nothing Then
                If Not tblVendor Is Nothing Then
                    ddlVendor.DataSource = InsertOneRow(tblVendor, ddlLabel.Items(2).Text)
                    ddlVendor.DataTextField = "Name"
                    ddlVendor.DataValueField = "ID"
                    ddlVendor.DataBind()
                    blnFound = True
                End If
                tblVendor = Nothing
            End If
            If Not blnFound Then
                item.Text = ddlLabel.Items(2).Text
                item.Value = 0
                ddlVendor.Items.Add(item)
            End If
        End Sub

        ' Purpose: GetClaimIssueList method
        ' In: VendorID, FromDate, ToDate 
        Private Sub GetData()
            Dim tblData As DataTable = Nothing
            Dim blnFound As Boolean = False

            objBPeriodicalCollection.VendorID = ddlVendor.SelectedValue
            objBPeriodicalCollection.FromDate = txtFromDate.Text.Trim
            objBPeriodicalCollection.ToDate = txtToDate.Text.Trim
            tblData = objBPeriodicalCollection.GetClaimIssueList

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPeriodicalCollection.ErrorMsg, ddlLabel.Items(0).Text, objBPeriodicalCollection.ErrorCode)

            If Not tblData Is Nothing Then
                If tblData.Rows.Count > 0 Then
                    dgrClaimReview.Visible = True
                    dgrClaimReview.DataSource = tblData
                    dgrClaimReview.DataBind()
                    blnFound = True
                End If
            End If

            If blnFound = False Then
                Page.RegisterClientScriptBlock("unsuccess", "<script language='javascript'>alert('" & ddlLabel.Items(5).Text & "');</script>")
            End If
        End Sub

        ' Event: btnReview_Click
        Private Sub btnReview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReview.Click
            Call GetData()
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBPeriodicalCollection Is Nothing Then
                    objBPeriodicalCollection.Dispose(True)
                    objBPeriodicalCollection = Nothing
                End If
                If Not objBVendor Is Nothing Then
                    objBVendor.Dispose(True)
                    objBVendor = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace