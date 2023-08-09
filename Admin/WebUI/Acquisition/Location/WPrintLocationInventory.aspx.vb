' Puspose: Print location inventory
' Creator: Sondp
' CreatedDate: 03/11/2005
' Modification History:

Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition
Imports eMicLibAdmin.WebUI.Common

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WPrintLocationInventory
        Inherits clswbase

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
        Private objBLocation As New clsBLocation
        Private objBLibrary As New clsBLibrary
        Private colInfor As Collection

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            Call CheckPemissions()
            If Not Page.IsPostBack AndAlso Not Session("ColInfor") Is Nothing Then
                colInfor = Session("ColInfor")
                Call BindData(colInfor.Item("Type"))
                Call BindDataInventory(colInfor.Item("Type"))
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

        ' Method: CheckPemissions
        Sub CheckPemissions()
            If Not CheckPemission(177) Then
                WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub
        Private Sub BindDataInventory(ByVal intType As Integer)
            Dim tblTemp As DataTable
            Dim inti As Integer

            dtgInventoryLost.Visible = False
            dtgInventoryFalsePath.Visible = False
            objBInventory.InventoryID = colInfor.Item("InventoryID")
            objBInventory.LibID = colInfor.Item("LibID")
            objBInventory.LocationID = colInfor.Item("LocID")
            objBInventory.Shelf = colInfor.Item("Shelf")
            objBInventory.OrderField = colInfor.Item("OrderField")
            objBInventory.Direction = colInfor.Item("Direction")
            objBInventory.FromOpenDate = colInfor.Item("FromOpenDate")
            objBInventory.ToOpenDate = colInfor.Item("ToOpenDate")
            objBInventory.OptInventory = colInfor.Item("OptInventoryType")
            ''
            If intType = 0 Then ' Lost
                tblTemp = objBInventory.GetItemNoHaveReal()
                If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                    dtgInventoryLost.Visible = True
                    dtgInventoryLost.DataSource = tblTemp
                    dtgInventoryLost.DataBind()
                    Page.RegisterClientScriptBlock("PrintJs", "<script language='javascript'>self.focus();setTimeout('self.print()', 1);</script>")
                End If
            Else ' Wrong path
                tblTemp = objBInventory.GetItemFalsePaths()
                If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                    dtgInventoryFalsePath.Visible = True
                    dtgInventoryFalsePath.DataSource = tblTemp
                    dtgInventoryFalsePath.DataBind()
                    Page.RegisterClientScriptBlock("PrintJs", "<script language='javascript'>self.focus();setTimeout('self.print()', 1);</script>")
                End If
            End If
        End Sub

        Private Sub BindDataGrid(ByVal intType As Integer, ByVal intInventoryID As Integer, ByVal intLibID As Integer, ByVal intLocID As Integer, ByVal strShelf As String, ByVal strOrderField As String, ByVal strDirection As String)
            Dim tblTemp As DataTable
            objBInventory.InventoryID = intInventoryID
            objBInventory.LibID = intLibID
            objBInventory.LocationID = intLocID
            objBInventory.Shelf = strShelf
            objBInventory.OrderField = strOrderField
            objBInventory.Direction = strDirection
            If intType = 0 Then ' Lost
                tblTemp = objBInventory.GetItemNoHaveReal
                If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                    dtgInventoryLost.DataSource = tblTemp
                    dtgInventoryLost.DataBind()
                End If
            Else ' Wrong path
                tblTemp = objBInventory.GetItemFalsePaths
                If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                    dtgInventoryFalsePath.DataSource = tblTemp
                    dtgInventoryFalsePath.DataBind()
                End If
            End If
        End Sub

        Private Sub BindData(ByVal intType As Integer)
            Dim tblResult As DataTable
            Dim strInventory As String = ""
            Dim inti As Integer
            Dim strHeaderRow As String
            Dim strInventoryHeader As String = ""
            Dim dvResult As New DataView
            Dim intStart As Integer
            Dim intStop As Integer
            Dim strIntName As String = ""
            Dim str As String = ""
            Dim strFullName As String
            ' Get Liblary
            objBLibrary.LibID = CInt(colInfor.Item("LibID"))
            objBLocation.LibID = CInt(colInfor.Item("LibID"))
            objBInventory.LibID = CInt(colInfor.Item("LibID"))
            objBLocation.LocID = CInt(colInfor.Item("LocID"))
            objBInventory.LocationID = CInt(colInfor.Item("LocID"))

            objBInventory.InventoryID = CInt(colInfor.Item("InventoryID"))

            strInventory = ddlLabel.Items(7).Text
            strInventory = strInventory + CStr(colInfor.Item("LibName")) & "  "

            'tblResult = objBLibrary.GetLibrary()

            'If Not tblResult Is Nothing Then
            '    If tblResult.Rows.Count > 0 Then
            '        If Not IsDBNull(tblResult.Rows(0).Item("Name")) Then
            '            strInventory = strInventory + CStr(tblResult.Rows(0).Item("Name")) & "  "
            '        End If
            '    End If
            'End If

            tblResult = objBLocation.GetLocation
            If Not tblResult Is Nothing Then
                If tblResult.Rows.Count > 0 Then
                    Dim intj As Integer
                    Dim strLocations As String = ""
                    For intj = 0 To tblResult.Rows.Count - 1
                        strLocations = strLocations & CStr(tblResult.Rows(intj).Item("Symbol")) & ","
                    Next
                    'strInventory = strInventory + " " + ddlLabel.Items(8).Text + CStr(tblResult.Rows(0).Item("Symbol")) & "  "
                    strInventory = strInventory + " " + ddlLabel.Items(8).Text + strLocations & "  "
                End If
            End If

            If colInfor.Item("Shelf") & "" <> "" Then
                objBInventory.Shelf = colInfor.Item("Shelf")
                hidShelf.Value = colInfor.Item("Shelf")
                strInventory = strInventory + ddlLabel.Items(9).Text + hidShelf.Value
            Else
                objBInventory.Shelf = ""
            End If

            tblResult = Nothing

            tblResult = objBInventory.GetInventory()
            If Not tblResult Is Nothing Then
                If tblResult.Rows.Count > 0 Then
                    If Not IsDBNull(tblResult.Rows(0).Item("Doneby")) Then
                        strFullName = ddlLabel.Items(10).Text & tblResult.Rows(0).Item("Doneby")
                    Else
                        strFullName = ddlLabel.Items(10).Text
                    End If
                    str = ddlLabel.Items(4).Text & tblResult.Rows(0).Item("Name") & "<br>"
                    strIntName = tblResult.Rows(0).Item("Name")
                    str = str & ddlLabel.Items(5).Text & tblResult.Rows(0).Item("OPENEDDATE") & "<br>"
                    If Not IsDBNull(tblResult.Rows(0).Item("CLOSEDDATE")) Then
                        str = str & ddlLabel.Items(6).Text & tblResult.Rows(0).Item("CLOSEDDATE") & "<br>"
                    End If
                End If
            Else
                Page.RegisterClientScriptBlock("NothingJs", "<script language='javascript'>alert('" & ddlLabel.Items(10).Text & "');</script>")
            End If
            strInventoryHeader = str & strInventory & "<br>" & strFullName
            ' Show page title
            lblInventoryName.Text = strInventoryHeader

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