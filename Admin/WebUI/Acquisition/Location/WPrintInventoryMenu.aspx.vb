' class WPrintInventoryMenu
' Puspose: process generation list copynumber
' Creator: Tuanhv
' CreatedDate: 01/04/2005
' Modification History:

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition
Namespace eMicLibAdmin.WebUI.Acquisition
    Public Class WPrintInventoryMenu
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents btnLastPage As System.Web.UI.WebControls.Button
        Protected WithEvents btnNextPage As System.Web.UI.WebControls.Button
        Protected WithEvents lblIndexPage As System.Web.UI.WebControls.Label
        Protected WithEvents lblIndexPage1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblIndexPage2 As System.Web.UI.WebControls.Label
        Protected WithEvents ddlLibrary As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents ddlLocation As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents txtShelf As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents txttoCopyNum As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents txtfromCopyNum As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents txtPageIndex As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblNotNum As System.Web.UI.WebControls.Label
        Protected WithEvents lblNote As System.Web.UI.WebControls.Label
        Protected WithEvents lnkGoBack As System.Web.UI.WebControls.HyperLink
        Protected WithEvents hidNameLocation As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents lblOrderBy As System.Web.UI.WebControls.Label
        Protected WithEvents ddlOrderBy As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ckbDesc As System.Web.UI.WebControls.CheckBox
        Protected WithEvents hidOrderBy As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents hidShortView As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents hidLib As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents hidInt As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents hidShelf As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents hidType As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents hidLoc As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents lblErrorInfor As System.Web.UI.WebControls.Label
        Protected WithEvents lblErrorCode As System.Web.UI.WebControls.Label
        Protected WithEvents hidPageOneNum As System.Web.UI.HtmlControls.HtmlInputHidden

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
        Private intCountPage As Integer

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            If Not Page.IsPostBack Then
                If Not Page.IsPostBack Then
                    Try
                        hidType.Value = Request("Type")
                        hidInt.Value = Request("InventoryID")
                        hidLib.Value = Request("LibID")
                        hidLoc.Value = Request("LocID")
                        hidShelf.Value = Request("Shelf")
                        hidShortView.Value = Request("ShortView")
                        hidPageOneNum.Value = Request("PageOneNum")
                    Catch ex As Exception
                    End Try
                    'hidType.Value = 0
                    'hidInt.Value = 1
                    'hidLib.Value = 16
                    'hidLoc.Value = 22
                    'hidShelf.Value = ""
                    'hidShortView.Value = 0
                    'hidPageOneNum.Value = 10
                    Call BindData()
                End If
            End If
            Call BindJavascript()
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

        ' BindJavascript method
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("SelfJs", "<script language='javascript' src='../JS/Location/WPrintInventoryMenu.js'></script>")
            btnLastPage.Attributes.Add("onClick", "javascript:return(Prev('" & lblNote.Text & "','" & lblNotNum.Text & "'))")
            btnNextPage.Attributes.Add("onClick", "javascript:return(Next(" & CStr(intCountPage) & ",'" & lblNote.Text & "','" & lblNotNum.Text & "'))")
            ddlOrderBy.Attributes.Add("OnChange", "javascript:document.forms[0].hidShortView.value=this.value;GotoSubmit();")
        End Sub

        ' BindData method
        ' Purpose: Load data
        Private Sub BindData()
            Dim tblResult As DataTable
            Dim intCopyNum1Page As Integer
            Dim strInforListCopyNum As String
            Dim arrInforListCopyNum() As String
            Dim strInventory As String = ""
            Dim inti As Integer
            Dim strHeaderRow As String
            Dim strInventoryHeader As String = ""
            Dim dvResult As New DataView
            intCopyNum1Page = CInt(hidPageOneNum.Value)

            'lblTypeInventory.Text = ""
            If hidType.Value = 1 Then
                ' Get Liblary
                If Trim(hidLib.Value) <> "" Then
                    objBLibrary.LibID = CInt(Trim(hidLib.Value))
                    objBLocation.LibID = CInt(Trim(hidLib.Value))
                    objBInventory.LibID = CInt(Trim(hidLib.Value))
                Else
                    objBLibrary.LibID = 0
                    objBLocation.LibID = 0
                    objBInventory.LibID = 0
                End If
                If Trim(hidLoc.Value) <> "" Then
                    objBLocation.LocID = CInt(hidLoc.Value)
                    objBInventory.LocationID = CInt(hidLoc.Value)
                Else
                    objBLocation.LocID = 0
                    objBInventory.LocationID = 0
                End If

                If Trim(hidInt.Value) <> "" Then
                    objBInventory.InventoryID = CInt(hidInt.Value)
                Else
                    objBInventory.InventoryID = 0
                End If


                If hidShelf.Value <> "" Then
                    objBInventory.Shelf = hidShelf.Value
                Else
                    objBInventory.Shelf = ""
                End If

                tblResult = Nothing

                tblResult = objBInventory.GetInventory()

                'Check error
                Call WriteErrorMssg(lblErrorInfor.Text, objBInventory.ErrorMsg, lblErrorCode.Text, objBInventory.ErrorCode)

                tblResult = objBInventory.GetItemFalsePaths
                dvResult = tblResult.DefaultView
                If CInt(hidShortView.Value) = 0 Then
                    dvResult.Sort = "Content"
                ElseIf CInt(hidShortView.Value) = 1 Then
                    dvResult.Sort = "Copynumber"
                Else
                    dvResult.Sort = "CallNumber"
                End If

            Else
                ' Get Liblary
                If Trim(hidLib.Value) <> "" Then
                    objBLibrary.LibID = CInt(Trim(hidLib.Value))
                    objBLocation.LibID = CInt(Trim(hidLib.Value))
                    objBInventory.LibID = CInt(Trim(hidLib.Value))
                Else
                    objBLibrary.LibID = 0
                    objBLocation.LibID = 0
                    objBInventory.LibID = 0
                End If
                If Trim(hidLoc.Value) <> "" Then
                    objBLocation.LocID = CInt(hidLoc.Value)
                    objBInventory.LocationID = CInt(hidLoc.Value)
                Else
                    objBLocation.LocID = 0
                    objBInventory.LocationID = 0
                End If
                If Trim(hidInt.Value) <> "" Then
                    objBInventory.InventoryID = CInt(hidInt.Value)
                Else
                    objBLocation.LocID = 0
                    objBInventory.LocationID = 0
                End If

                If hidShelf.Value <> "" Then
                    objBInventory.Shelf = hidShelf.Value
                Else
                    objBInventory.Shelf = ""
                End If
                tblResult = objBInventory.GetInventory()
                'Check error
                Call WriteErrorMssg(lblErrorInfor.Text, objBInventory.ErrorMsg, lblErrorCode.Text, objBInventory.ErrorCode)

                tblResult = objBInventory.GetItemNoHaveReal
                dvResult = tblResult.DefaultView
                If CInt(hidShortView.Value) = 0 Then
                    dvResult.Sort = "Content"
                ElseIf CInt(hidShortView.Value) = 1 Then
                    dvResult.Sort = "Copynumber"
                Else
                    dvResult.Sort = "CallNumber"
                End If

                'Check error
                Call WriteErrorMssg(lblErrorInfor.Text, objBInventory.ErrorMsg, lblErrorCode.Text, objBInventory.ErrorCode)
            End If
            If Not tblResult Is Nothing Then
                intCountPage = CInt(tblResult.Rows.Count / intCopyNum1Page)
                If intCountPage * intCopyNum1Page < tblResult.Rows.Count Then
                    intCountPage = intCountPage + 1
                End If
            End If
            lblIndexPage1.Text = lblIndexPage1.Text & " " & CStr(intCountPage)
        End Sub

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
