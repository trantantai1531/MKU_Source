' Class WExecuteInventory
' Puspose: Excute inventory
' Creator: Tuanhv
' CreatedDate: 09/03/2004
' Modification History:

Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition
Imports eMicLibAdmin.WebUI.Common

Namespace eMicLibAdmin.WebUI.Acquisition
    Public Class WSearchFrintInventory
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblMainTitle As System.Web.UI.WebControls.Label
        Protected WithEvents lblInventory As System.Web.UI.WebControls.Label
        Protected WithEvents ddlInventory As System.Web.UI.WebControls.DropDownList
        Protected WithEvents lblInventoryBound As System.Web.UI.WebControls.Label
        Protected WithEvents lblLibraryName As System.Web.UI.WebControls.Label
        Protected WithEvents ddlLibrary As System.Web.UI.WebControls.DropDownList
        Protected WithEvents lblLocation As System.Web.UI.WebControls.Label
        Protected WithEvents ddlLocation As System.Web.UI.WebControls.DropDownList
        Protected WithEvents lblShelf As System.Web.UI.WebControls.Label
        Protected WithEvents txtShelf As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblInventoryForm As System.Web.UI.WebControls.Label
        Protected WithEvents optPurpose As System.Web.UI.WebControls.RadioButtonList
        Protected WithEvents btnInventory As System.Web.UI.WebControls.Button
        Protected WithEvents btnViewResult As System.Web.UI.WebControls.Button
        Protected WithEvents lblLiblaryInv As System.Web.UI.WebControls.Label
        Protected WithEvents lblLocationInv As System.Web.UI.WebControls.Label
        Protected WithEvents lblShelfInv As System.Web.UI.WebControls.Label
        Protected WithEvents lblErrorInfor As System.Web.UI.WebControls.Label
        Protected WithEvents lblErrorCode As System.Web.UI.WebControls.Label
        Protected WithEvents lblTotalNoLoop1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblTotalWrong1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblWrongDetail1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblTotalNo1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblNoDetail1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblNoFile As System.Web.UI.WebControls.Label
        Protected WithEvents lblNoCopynumber As System.Web.UI.WebControls.Label
        Protected WithEvents txtHiddenPathFile As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents txtLibraryID As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents txtLocationID As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents txtInventoryID As System.Web.UI.HtmlControls.HtmlInputHidden

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region
        Private objBInventory As New clsBInventory
        Private objBLocation As New clsBLocation
        Private objBLibrary As New clsBLibrary

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ' Init all object use form
            Call Initialize()

            If Not Page.IsPostBack Then
                Call BindData()
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

            ' Init objBLocation object
            objBLocation.DBServer = Session("DBServer")
            objBLocation.ConnectionString = Session("ConnectionString")
            objBLocation.InterfaceLanguage = Session("InterfaceLanguage")
            objBLocation.Initialize()

            ' Init objBLibrary object
            objBLibrary.DBServer = Session("DBServer")
            objBLibrary.ConnectionString = Session("ConnectionString")
            objBLibrary.InterfaceLanguage = Session("InterfaceLanguage")
            objBLibrary.Initialize()
        End Sub

        ' Methord: BindData
        Private Sub BindData()
            Dim tblResult As DataTable
            ' Get Inventory
            tblResult = objBInventory.GetInventory(-1)
            'Check error
            Call WriteErrorMssg(lblErrorInfor.Text, objBInventory.ErrorMsg, lblErrorCode.Text, objBInventory.ErrorCode)
            ' Bind inventory
            If Not tblResult Is Nothing Then
                If tblResult.Rows.Count > 0 Then
                    ddlInventory.DataValueField = "ID"
                    ddlInventory.DataTextField = "Name"
                    ddlInventory.DataSource = tblResult
                    ddlInventory.DataBind()
                End If
            End If
            tblResult = Nothing

            ' Get Liblary
            objBLibrary.LibID = 0
            'objBLibrary.LocalLib = 0
            tblResult = objBLibrary.GetLibrary(0)
            'Check error
            Call WriteErrorMssg(lblErrorInfor.Text, objBLibrary.ErrorMsg, lblErrorCode.Text, objBLibrary.ErrorCode)
            ' Bind liblary
            If Not tblResult Is Nothing Then
                If tblResult.Rows.Count > 0 Then
                    ddlLibrary.DataValueField = "ID"
                    ddlLibrary.DataTextField = "Code"
                    ddlLibrary.DataSource = tblResult
                    ddlLibrary.DataBind()
                    tblResult = Nothing
                    ' Get Location
                    objBLocation.UserID = Session("UserID")
                    objBLocation.LibID = CInt(ddlLibrary.Items(0).Value)
                    'tblResult = objBLocation.GetLocation(0)
                    tblResult = objBLocation.GetLocation()
                    'Check error
                    Call WriteErrorMssg(lblErrorInfor.Text, objBLocation.ErrorMsg, lblErrorCode.Text, objBLocation.ErrorCode)
                    ' Bind location
                    If Not tblResult Is Nothing Then
                        If tblResult.Rows.Count > 0 Then
                            ddlLocation.DataValueField = "ID"
                            ddlLocation.DataTextField = "Symbol"
                            ddlLocation.DataSource = tblResult
                            ddlLocation.DataBind()
                        End If
                    End If
                End If
                tblResult = Nothing
            End If
        End Sub

        ' Event ddlLibrary_SelectedIndexChanged
        Private Sub ddlLibrary_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlLibrary.SelectedIndexChanged
            Dim tblResult As DataTable
            ' Get Location
            objBLocation.UserID = Session("UserID")
            Try
                objBLocation.LibID = CInt(ddlLibrary.SelectedValue)
            Catch ex As Exception
                objBLocation.LibID = 0
            End Try

            tblResult = objBLocation.GetLocation
            'Check error
            Call WriteErrorMssg(lblErrorInfor.Text, objBLocation.ErrorMsg, lblErrorCode.Text, objBLocation.ErrorCode)
            ' Bind location
            If Not tblResult Is Nothing Then
                ddlLocation.DataValueField = "ID"
                ddlLocation.DataTextField = "Symbol"
                ddlLocation.DataSource = tblResult
                ddlLocation.DataBind()
            End If
            tblResult = Nothing
        End Sub

        ' Event: btnInventory_Click
        Private Sub btnInventory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInventory.Click
            Dim intInventoryID As Integer = 0
            Dim intLibID As Integer = 0
            Dim intLocID As Integer = 0
            Dim strShelf As String = ""
            Try
                If CInt(ddlInventory.SelectedValue) > 0 Then
                    intInventoryID = CInt(ddlInventory.SelectedValue)
                End If
                If CInt(ddlLibrary.SelectedValue) > 0 Then
                    intLibID = CInt(ddlLibrary.SelectedValue)
                End If
                If CInt(ddlLocation.SelectedValue) > 0 Then
                    intLocID = CInt(ddlLocation.SelectedValue)
                End If
                If Trim(txtShelf.Text) <> "" Then
                    strShelf = Trim(txtShelf.Text)
                End If
            Catch ex As Exception
            End Try
            Response.Redirect("WPrintLocationInventory.aspx.aspx?Type=" & optPurpose.SelectedValue & "&InventoryID=" & intInventoryID & "&LibID=" & intLibID & "&LocID=" & intLocID & "&Shelf=" & strShelf)
            'Response.Redirect("btnInventory_Click?InventoryID=" & intInventoryID & "&LibID=" & intLibID & " &LocID=" & intLocID & " &Shelf=" & strShelt)
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
                If Not objBLocation Is Nothing Then
                    objBLocation.Dispose(True)
                    objBLocation = Nothing
                End If
                If Not objBLibrary Is Nothing Then
                    objBLibrary.Dispose(True)
                    objBLibrary = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub


    End Class
End Namespace
