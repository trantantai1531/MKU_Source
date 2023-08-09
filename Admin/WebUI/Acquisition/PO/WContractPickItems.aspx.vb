' Class: WContractPickItems
' Puspose: Allow pick items for the selected contract
' Creator: Sondp
' CreatedDate: 07/04/2005
' Modification History:

Imports eMicLibAdmin.BusinessRules.Acquisition
Imports Telerik.Web.UI

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WContractPickItems
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

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                txbContractID.Value = Request.QueryString("ContractID")
                txbTypeID.Value = Request.QueryString("TypeID")
                'Call BindData()
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
        End Sub

        ' Method: BindJS
        ' Purpose: Include all neccessary javascript functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")

            Page.RegisterClientScriptBlock("wContractPickItem", "<script language = 'javascript' src = ' ../Js/PO/wContractPickItem.js'></script>")
            btnClose.Attributes.Add("OnClick", "opener.document.forms[0].txbFunc.value='PICK'; opener.document.forms[0].submit(); self.close(); return false;")
        End Sub

        ' BindData method
        Private Sub BindData()
            Dim tblItems As New DataTable
            Dim inti As Integer
            Dim intItemTypeID As Integer = CInt(txbTypeID.Value)
            objBIO.LibID = clsSession.GlbSite
            objBIO.TypeID = intItemTypeID
            tblItems = objBIO.GetOrderItems
            If Not tblItems Is Nothing AndAlso tblItems.Rows.Count > 0 Then
                For inti = 0 To tblItems.Rows.Count - 1
                    tblItems.Rows(inti).Item("UnitPrice") = Round(tblItems.Rows(inti).Item("UnitPrice"))
                Next
                dtgItem.DataSource = tblItems
                ' dtgItem.DataBind()
                btnSelect.Visible = True
                btnCheckAll.Visible = True
                btnUnCheckAll.Visible = True
            End If

            ' Release objects
            If Not tblItems Is Nothing Then
                tblItems.Dispose()
                tblItems = Nothing
            End If
        End Sub

        ' btnSelect_Click event
        Private Sub btnSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect.Click
            Dim dtgTemp As GridDataItem
            Dim chkSelected As HtmlInputCheckBox
            Dim strSelectedIDs As String = ""

            For Each dtgTemp In dtgItem.Items
                chkSelected = dtgTemp.FindControl("chkSelectedID")
                If chkSelected.Checked Then
                    strSelectedIDs = strSelectedIDs & CType(dtgTemp.FindControl("lblID"), Label).Text & ","
                End If
            Next

            If Not strSelectedIDs = "" Then
                strSelectedIDs = Left(Trim(strSelectedIDs), Len(Trim(strSelectedIDs)) - 1)
                Call objBIO.Update(txbContractID.Value, strSelectedIDs)
                Page.RegisterClientScriptBlock("SelectedJs", "<script language = 'javascript'>opener.document.forms[0].txbFunc.value='PICK'; opener.document.forms[0].submit(); self.close();</script>")
            End If
            Call BindData()
        End Sub

        ' Page_Unload method
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBIO Is Nothing Then
                objBIO.Dispose(True)
                objBIO = Nothing
            End If
        End Sub


        Protected Sub dtgItem_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles dtgItem.NeedDataSource

            BindData()
        End Sub


    End Class
End Namespace