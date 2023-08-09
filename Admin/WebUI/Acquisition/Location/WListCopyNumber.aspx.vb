' class WListCopyNumber
' Puspose: generate list copynumber for user select to do move or remove item in location
' Creator: lent
' CreatedDate: 21-2-2005
' Modification History:

Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition
Imports Telerik.Web.UI

Namespace eMicLibAdmin.WebUI.Acquisition

    Partial Class WListCopyNumber
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
        Private objBCopyNumber As New clsBCopyNumber

        ' Page_load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Initialize method
        ' Purpose: Init all neccessary objects
        Private Sub Initialize()
            ' Initialize objBCopyNumber object
            objBCopyNumber.DBServer = Session("DBServer")
            objBCopyNumber.ConnectionString = Session("ConnectionString")
            objBCopyNumber.InterfaceLanguage = Session("InterfaceLanguage")
            objBCopyNumber.Initialize()
        End Sub

        ' BindScript method
        ' Purpose: Bindjavascript
        Private Sub BindScript()
            Dim strJSCheckNull As String

            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/Location/WListCopyNumber.js'></script>")

            strJSCheckNull = "if(!CheckOptionsNullByCssClass('ckb-value', 'ckbdtgCopyNumber', 2, 50, '" & ddlLabelNote.Items(2).Text & "')) return false;"
            btnCopyNumber.Attributes.Add("onClick", strJSCheckNull)

            btnClose.Attributes.Add("onClick", "self.close();return false;")
        End Sub

        ' BindData method
        ' Purpose: Load data
        Private Sub BindData()
            Dim tblResult As DataTable
            Dim intLibrary As Integer
            Dim intLocation As Integer
            Dim strShelf As String

            'get data to form menu
            intLibrary = CInt(Request("LibID"))
            intLocation = CInt(Request("LocID"))
            strShelf = Request("Shelf")
            lblLibName.Text = Request.QueryString("LibName")
            lblLocName.Text = Request.QueryString("LocName")
            lblShelfName.Text = strShelf
            hidLibID.Value = intLibrary
            hidLocID.Value = intLocation
            hidTypeSort.Value = 0

            objBCopyNumber.LibID = intLibrary
            objBCopyNumber.LocID = intLocation
            objBCopyNumber.Shelf = strShelf
            objBCopyNumber.ToCopyNum = ""
            objBCopyNumber.FromCopyNum = ""
            objBCopyNumber.Orderby = 0
            objBCopyNumber.OrderByDesc = 0
            tblResult = objBCopyNumber.GenListCopyNumber
            dtgCopyNumber.DataSource = tblResult
            'dtgCopyNumber.DataBind()
            tblResult = Nothing
        End Sub

        ' ReBindData method
        Private Sub ReBindData()
            Dim tblResult As DataTable
            'get data to form menu
            objBCopyNumber.LibID = hidLibID.Value
            objBCopyNumber.LocID = hidLocID.Value
            objBCopyNumber.Shelf = lblShelfName.Text
            objBCopyNumber.ToCopyNum = ""
            objBCopyNumber.FromCopyNum = ""
            objBCopyNumber.Orderby = hidTypeSort.Value
            objBCopyNumber.OrderByDesc = 0
            tblResult = objBCopyNumber.GenListCopyNumber
            dtgCopyNumber.DataSource = tblResult
            dtgCopyNumber.Rebind()
            tblResult = Nothing
        End Sub

        ' dtgCopyNumber_PageIndexChanged event
        'Private Sub dtgCopyNumber_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgCopyNumber.PageIndexChanged
        '    dtgCopyNumber.CurrentPageIndex = e.NewPageIndex
        '    Call ReBindData()
        'End Sub

        ' dtgCopyNumber_SortCommand event
        'Private Sub dtgCopyNumber_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dtgCopyNumber.SortCommand
        '    hidTypeSort.Value = e.SortExpression
        '    Call ReBindData()
        'End Sub

        ' btnCopyNumber_Click event
        Private Sub btnCopyNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyNumber.Click
            Dim itemdtg As GridDataItem
            Dim ckbItemdtg As HtmlInputCheckBox
            Dim strScript As String
            Dim strCopyNumber As String = ""

            For Each itemdtg In dtgCopyNumber.Items
                ckbItemdtg = itemdtg.FindControl("ckbdtgCopyNumber")
                If ckbItemdtg.Checked Then
                    strCopyNumber = strCopyNumber & itemdtg.Cells(6).Text & "\n"
                End If
            Next
            strScript = "<script language='javascript'>"
            If strCopyNumber <> "" Then
                strScript = strScript & "opener.document.forms[0].txtCopyNumManual.value=opener.document.forms[0].txtCopyNumManual.value+'" & strCopyNumber & "';"
            End If
            strScript = strScript & "self.close();</script>"
            Page.RegisterClientScriptBlock("LoadJS", strScript)
        End Sub

        ' dtgCopyNumber_ItemCreated event
        ' Purpose: Add the javascript for each table row
        'Private Sub dtgCopyNumber_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgCopyNumber.ItemCreated
        '    Dim intIndex As Int16 = e.Item.ItemIndex + 3
        '    Dim inti As Integer
        '    For inti = 0 To e.Item.Cells.Count - 2
        '        e.Item.Cells(inti).Attributes.Add("onClick", "javascript:CheckOptionVisible('dtgCopyNumber','ckbdtgCopyNumber'," & e.Item.ItemIndex + 3 & ");")
        '    Next
        'End Sub


        Protected Sub dtgCopyNumber_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles dtgCopyNumber.NeedDataSource
            
            BindData()
        End Sub


        Public Function GetNumber() As Integer Implements IUCNumberOfRecord.NumberOfRecord
            Return 25
        End Function


        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCopyNumber Is Nothing Then
                    objBCopyNumber.Dispose(True)
                    objBCopyNumber = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace