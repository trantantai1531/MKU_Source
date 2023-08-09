' Class: WSendPOSeperatedSearch
' Puspose: Send PO Seperated Store
' Creator: Sondp
' CreatedDate: 29/03/2005
' Modification History:
'   - 09/04/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WSendPOSeperatedSearch
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

        Private objBTemplate As New clsBTemplate
        Private objBPO As New clsBPurchaseOrder

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                If Not Request.QueryString("POID") & "" = "" Then
                    hdPOID.Value = Request.QueryString("POID")
                    ddlPOCode.Visible = False
                    lblPOCode.Visible = False
                    boxPOCode.Visible = False
                    Call BindData(False)
                Else
                    Call BindData()
                End If
            End If
        End Sub
        ' CheckFormPermission method
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            ' Gui don dat
            If Not CheckPemission(135) Then
                WriteErrorMssg(ddlLabel.Items(4).Text)
            End If
        End Sub
        ' Initialize method
        ' Purpose: init all neccessary objects
        Private Sub Initialize()
            ' Initialize objBTemplate object
            objBTemplate.InterfaceLanguage = Session("InterfaceLanguage")
            objBTemplate.DBServer = Session("DBServer")
            objBTemplate.ConnectionString = Session("ConnectionString")
            Call objBTemplate.Initialize()

            ' Initialize objBPO object
            objBPO.InterfaceLanguage = Session("InterfaceLanguage")
            objBPO.DBServer = Session("DBServer")
            objBPO.ConnectionString = Session("ConnectionString")
            Call objBPO.Initialize()
        End Sub

        ' BindScript method
        ' Purpose: Include all neccessary js functions
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("WSendPOSeperatedSearchJs", "<script language='javascript' src='../Js/PO/WSendPOSeperated.js'></script>")
            ddlPOCode.Attributes.Add("OnChange", "document.forms[0].hdPOID.value=this.value;return(false);")
            btnPreview.Attributes.Add("OnClick", "CheckValidData('Preview','" & ddlLabel.Items(0).Text & "');return(false);")
            btnPrint.Attributes.Add("OnClick", "CheckValidData('Print','" & ddlLabel.Items(0).Text & "');return(false);")
            btnEmail.Attributes.Add("OnClick", "CheckValidData('Email','" & ddlLabel.Items(0).Text & "');return(false);")
            btnFile.Attributes.Add("OnClick", "CheckValidData('File','" & ddlLabel.Items(0).Text & "');return(false);")
        End Sub
        Private Sub VisiableControls(ByVal boolValue As Boolean)
            btnFile.Visible = boolValue
            btnPreview.Visible = boolValue
            btnPrint.Visible = boolValue
            btnEmail.Visible = boolValue
        End Sub
        'Private Sub Print(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        '    VisiableControls(False)
        '    Page.RegisterClientScriptBlock("PrintActionJs", "<script language='javascript'>self.focus();setTimeout('self.print()', 1);</script>")
        'End Sub


        ' BindData method
        ' Purpose: bind data
        ' In: boolFlage (=true: Load all infor)
        Private Sub BindData(Optional ByVal boolFalge As Boolean = True)
            Dim tblTemp As New DataTable
            Dim listItem As New listItem
            If boolFalge = True Then
                ' Bind PO
                objBPO.AcqPOID = 0
                objBPO.LibID = clsSession.GlbSite
                tblTemp = objBPO.GetPO

                If Not tblTemp Is Nothing Then
                    If tblTemp.Rows.Count > 0 Then
                        tblTemp = InsertOneRow(tblTemp, ddlLabel.Items(1).Text)

                        ddlPOCode.DataSource = tblTemp
                        ddlPOCode.DataTextField = "ReceiptNo_POName"
                        ddlPOCode.DataValueField = "ID"
                        ddlPOCode.DataBind()
                        tblTemp.Clear()
                    End If
                Else
                    listItem.Text = ddlLabel.Items(1).Text
                    listItem.Value = 0
                    ddlPOCode.Items.Add(listItem)
                End If
            End If

            ' Bind Template
            objBTemplate.TemplateID = 0
            objBTemplate.TemplateType = 10
            objBTemplate.LibID = clsSession.GlbSite
            tblTemp = objBTemplate.GetTemplate
            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    tblTemp = InsertOneRow(tblTemp, ddlLabel.Items(1).Text)
                    ddlTemplate.DataSource = tblTemp
                    ddlTemplate.DataTextField = "Title"
                    ddlTemplate.DataValueField = "ID"
                    ddlTemplate.DataBind()
                    tblTemp.Clear()
                Else
                    listItem.Text = ddlLabel.Items(1).Text
                    listItem.Value = 0
                    ddlTemplate.Items.Add(listItem)
                End If
            End If
            If Not tblTemp Is Nothing Then
                tblTemp = Nothing
            End If
        End Sub

        ' Page_Unload method
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBTemplate Is Nothing Then
                objBTemplate.Dispose(True)
                objBTemplate = Nothing
            End If
            If Not objBPO Is Nothing Then
                objBPO.Dispose(True)
                objBPO = Nothing
            End If
            If Not Session("Metric") Is Nothing Then
                Session("Metric") = Nothing
            End If
        End Sub
    End Class
End Namespace