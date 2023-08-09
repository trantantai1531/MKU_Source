Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WSearchItemByPO
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

        Private objBPO As New clsBPurchaseOrder

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: Init objects
        Sub Initialize()
            objBPO.InterfaceLanguage = Session("InterfaceLanguage")
            objBPO.DBServer = Session("DBServer")
            objBPO.ConnectionString = Session("ConnectionString")
            Call objBPO.Initialize()
        End Sub

        ' Method: BindJS
        Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("selfJs", "<script language = 'javascript' src = '../js/Acq/WSearchItemByPO.js'></script>")

            btnClose.Attributes.Add("onClick", "self.close()")
            btnSelect.Attributes.Add("onClick", "return SelectCode()")
        End Sub

        ' Method: BindData
        Sub BindData()
            Dim tblResult As DataTable

            ' Get PO
            Dim strReceiptPO As String
            strReceiptPO = Trim(Request("ReceiptPO"))

            objBPO.AcqPOID = 0
            objBPO.LibID = clsSession.GlbSite
            tblResult = objBPO.GetPO(strReceiptPO)
            If Not tblResult Is Nothing Then
                If tblResult.Rows.Count > 0 Then
                    ddlPO.DataSource = tblResult
                    ddlPO.DataTextField = "ReceiptNo"
                    ddlPO.DataValueField = "ReceiptNo"
                    ddlPO.DataBind()

                    tblResult = Nothing
                    tblResult = objBPO.GetItemCodeByPO(ddlPO.SelectedValue)
                    If Not tblResult Is Nothing Then
                        If tblResult.Rows.Count > 0 Then
                            ddlCode.DataSource = tblResult
                            ddlCode.DataValueField = "Code"
                            ddlCode.DataTextField = "Code"
                            ddlCode.DataBind()
                        Else
                            ddlCode.DataSource = ""
                            ddlCode.DataBind()
                        End If
                        tblResult = Nothing
                    Else
                        ddlCode.DataSource = ""
                        ddlCode.DataBind()
                    End If
                End If
                tblResult = Nothing
            End If
        End Sub

        ' Event: ddlPO_SelectedIndexChanged
        Private Sub ddlPO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlPO.SelectedIndexChanged
            Dim tblResult As DataTable

            tblResult = objBPO.GetItemCodeByPO(ddlPO.SelectedValue)
            If Not tblResult Is Nothing Then
                If tblResult.Rows.Count > 0 Then
                    ddlCode.DataSource = tblResult
                    ddlCode.DataValueField = "Code"
                    ddlCode.DataTextField = "Code"
                    ddlCode.DataBind()
                Else
                    ddlCode.DataSource = ""
                    ddlCode.DataBind()
                End If
                tblResult = Nothing
            Else
                ddlCode.DataSource = ""
                ddlCode.DataBind()
            End If
        End Sub

        ' Method: Page_Unload
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Release all object
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBPO Is Nothing Then
                    objBPO.Dispose(True)
                    objBPO = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace