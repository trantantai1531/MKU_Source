' Class: WSendPOSearch
' Puspose: Manager send po
' Creator: Sondp
' CreatedDate: 21/03/2005
' Modification History:
'   - 09/04/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WSendPOSearch
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
        Private objBPurchaseOrder As New clsBPurchaseOrder
        Private objBTemplate As New clsBTemplate
        ' Declare variables
        Private objBCommonTemplate As New clsBCommonTemplate

        Dim intMax As Integer = 0

        ' chkType => Need update status for this contract
        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Dim tblPODetail As DataTable
            Dim intStatusID As Integer
            lblMessages.Text = ""
            If Not Page.IsPostBack Then
                Call ShowTemplate()
                If Not Request.QueryString("ContractID") & "" = "" Then
                    hdIDs.Value = Request.QueryString("ContractID")

                    dgrPOList.Visible = False
                    optSelectAll.Visible = False
                    btnEmail.Enabled = False
                    btnFile.Enabled = False
                    btnPreview.Enabled = False
                    btnPrint.Enabled = False
                    If IsNumeric(Request.QueryString("ContractID")) Then
                        objBPurchaseOrder.AcqPOID = Request.QueryString("ContractID")
                        objBPurchaseOrder.Direction = -2
                        tblPODetail = objBPurchaseOrder.GetAcqPoInfor()
                        If Not tblPODetail Is Nothing Then
                            If tblPODetail.Rows.Count > 0 Then
                                intStatusID = tblPODetail.Rows(0).Item("StatusID")
                                If intStatusID = 2 Then
                                    btnEmail.Enabled = True
                                    btnFile.Enabled = True
                                    btnPreview.Enabled = True
                                    btnPrint.Enabled = True

                                Else
                                    dataResult.Visible = False
                                    lblMessages.Text = "Đơn đặt chưa nhập xong"
                                End If

                            End If
                        End If
                    End If
                Else
                    Call BindData()
                End If
            Else
                intMax = dgrPOList.Items.Count
            End If
            ' Must put BindScript method here
            Call BindScript()
        End Sub
        ' CheckFormPermission method
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            ' Gui don dat
            If Not CheckPemission(40) Then
                btnEmail.Enabled = False
            End If
        End Sub
        ' Method: Initialize
        ' Purpose: init all neccessary objects
        Private Sub Initialize()
            ' Initialize objBIO object
            objBIO.InterfaceLanguage = Session("InterfaceLanguage")
            objBIO.DBServer = Session("DBServer")
            objBIO.ConnectionString = Session("ConnectionString")
            Call objBIO.Initialize()

            ' Initialize objBTemplate object
            objBTemplate.InterfaceLanguage = Session("InterfaceLanguage")
            objBTemplate.DBServer = Session("DBServer")
            objBTemplate.ConnectionString = Session("ConnectionString")
            Call objBTemplate.Initialize()

            ' Initialize objBPurchaseOrder object
            objBPurchaseOrder.InterfaceLanguage = Session("InterfaceLanguage")
            objBPurchaseOrder.DBServer = Session("DBServer")
            objBPurchaseOrder.ConnectionString = Session("ConnectionString")
            Call objBPurchaseOrder.Initialize()

            ' Initialize objBCommonTemplate object
            objBCommonTemplate.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonTemplate.DBServer = Session("DBServer")
            objBCommonTemplate.ConnectionString = Session("ConnectionString")
            Call objBCommonTemplate.Initialize()
        End Sub

        ' Method: ShowTemplate
        ' Purpose: show list of available template
        Private Sub ShowTemplate()
            Dim tblTemp As DataTable
            Dim listItem As New listItem
            ' Bind Template
            Dim tblTemplate As New DataTable
            tblTemplate = objBCommonTemplate.GetTemplate
            objBTemplate.TemplateID = 0
            objBTemplate.TemplateType = 7
            objBTemplate.LibID = clsSession.GlbSite
            tblTemp = objBTemplate.GetTemplate
            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    tblTemp = InsertOneRow(tblTemp, ddlLabel.Items(0).Text)
                    ddlTemplate.DataSource = tblTemp
                    ddlTemplate.DataTextField = "Title"
                    ddlTemplate.DataValueField = "ID"
                    ddlTemplate.DataBind()
                Else
                    listItem.Text = ddlLabel.Items(0).Text
                    listItem.Value = 0
                    ddlTemplate.Items.Add(listItem)
                End If
            End If
        End Sub

        ' Method: BindScript
        ' Purpose: include all neccessary javascript functions
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("WCommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WSendPOSearchJs", "<script language='javascript' src='../Js/PO/WSendPO.js'></script>")
            btnPreview.Attributes.Add("OnClick", "return(CheckValidData('" & ddlLabel.Items(1).Text & "','dgrPOList','optChoice'," & intMax & ",'" & ddlLabel.Items(4).Text & "'));")
            btnPrint.Attributes.Add("OnClick", "return(CheckValidData('" & ddlLabel.Items(1).Text & "','dgrPOList','optChoice'," & intMax & ",'" & ddlLabel.Items(4).Text & "'));")
            btnEmail.Attributes.Add("OnClick", "return(CheckValidData('" & ddlLabel.Items(1).Text & "','dgrPOList','optChoice'," & intMax & ",'" & ddlLabel.Items(4).Text & "'));")
            btnFile.Attributes.Add("OnClick", "return(CheckValidData('" & ddlLabel.Items(1).Text & "','dgrPOList','optChoice'," & intMax & ",'" & ddlLabel.Items(4).Text & "'));")

            optSelectAll.Attributes.Add("OnClick", "CheckAllOptions('dgrPOList','optChoice','optSelectAll'," & intMax & ");")
        End Sub

        ' BindData method
        ' Purpose: Show data
        Private Sub BindData()
            Dim tblTemp As New DataTable
            lblMessages.Text = ""
            hdIDs.Value = ""
            objBIO.LibID = clsSession.GlbSite
            tblTemp = objBIO.GetWaittingPO
            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    dgrPOList.DataSource = tblTemp
                    dgrPOList.DataBind()
                    intMax = dgrPOList.Items.Count
                Else
                    dataResult.Visible = False
                    lblMessages.Text = "Không có đơn đặt"
                    '  End If
                End If
                If Not tblTemp Is Nothing Then
                    tblTemp = Nothing
                End If
            End If
        End Sub

        ' Method: GetIDs
        ' Purpose: Get selected ID
        Private Sub GetIDs()
            Dim strIDs As String
            Dim inti As Integer
            Dim dtgItem As DataGridItem

            strIDs = ""
            If Not Request.QueryString("ContractID") & "" = "" Then
                strIDs = Request.QueryString("ContractID")
            Else
                For Each dtgItem In dgrPOList.Items
                    If CType(dtgItem.Cells(1).FindControl("optChoice"), HtmlInputCheckBox).Checked = True Then
                        strIDs = strIDs & dtgItem.Cells(0).Text & ", "
                    End If
                Next
                If strIDs.Length > 1 Then
                    strIDs = Left(strIDs, Len(strIDs) - 2)
                End If
            End If
            hdIDs.Value = strIDs
        End Sub

        ' btnPrint_Click event
        ' Purpose: print data
        Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
            Call GetIDs()
            If Not hdIDs.Value = "" Then
                lblJS.Text = "<script language='javascript'>document.forms[0].action='WSendPO.aspx?Flage=PRINT&Template=" & ddlTemplate.SelectedValue & "'; document.forms[0].submit();</script>"
            End If
        End Sub

        ' btnEmail_Click event
        ' Purpose: Send email
        Private Sub btnEmail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEmail.Click
            Call GetIDs()
            If Not hdIDs.Value = "" Then
                If ckbPOStatus.Checked = True Then
                    lblJS.Text = "<script language='javascript'>document.forms[0].action='WSendPO.aspx?Flage=EMAIL&Template=" & ddlTemplate.SelectedValue & "&ChangeStatus=3'; document.forms[0].submit();</script>"
                Else
                    lblJS.Text = "<script language='javascript'>document.forms[0].action='WSendPO.aspx?Flage=EMAIL&Template=" & ddlTemplate.SelectedValue & "&ChangeStatus=0'; document.forms[0].submit();</script>"
                End If
            End If
        End Sub

        ' btnFile_Click event
        ' Purpose: export to file
        Private Sub btnFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFile.Click
            Call GetIDs()
            If Not hdIDs.Value = "" Then
                lblJS.Text = "<script language='javascript'>document.forms[0].action='WSendPO.aspx?Flage=FILE&Template=" & ddlTemplate.SelectedValue & "'; document.forms[0].submit();</script>"
            End If
        End Sub

        Private Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPreview.Click
            Call GetIDs()
            If Not hdIDs.Value = "" Then
                lblJS.Text = "<script language='javascript'>document.forms[0].action='WSendPO.aspx?Flage=PREVIEW&Template=" & ddlTemplate.SelectedValue & "'; document.forms[0].submit();</script>"
            End If
        End Sub

        ' Method Page_Unload
        ' Purpose: Unload objects
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBIO Is Nothing Then
                objBIO.Dispose(True)
                objBIO = Nothing
            End If
            If Not objBTemplate Is Nothing Then
                objBTemplate.Dispose(True)
                objBTemplate = Nothing
            End If
            If Not objBPurchaseOrder Is Nothing Then
                objBPurchaseOrder.Dispose(True)
                objBPurchaseOrder = Nothing
            End If
            If Not Session("Metric") Is Nothing Then
                Session("Metric") = Nothing
            End If
        End Sub
    End Class
End Namespace