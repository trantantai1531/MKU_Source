' Class WPrintLiq
' Puspose: Excute inventory
' Creator: Tuanhv
' CreatedDate: 09/03/2004
' Modification History:

Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition
Imports eMicLibAdmin.WebUI.Common

Namespace eMicLibAdmin.WebUI.Acquisition
    Public Class WPrintLiq
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents hidLib As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents hidInt As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents hidShelf As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents hidType As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents hidLoc As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents lblLibName As System.Web.UI.WebControls.Label
        Protected WithEvents lblLoction As System.Web.UI.WebControls.Label
        Protected WithEvents lblShelf As System.Web.UI.WebControls.Label
        Protected WithEvents ddlNameNoHave As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlNameFalsePaths As System.Web.UI.WebControls.DropDownList
        Protected WithEvents lblIneventoryName As System.Web.UI.WebControls.Label
        Protected WithEvents lblStartDate As System.Web.UI.WebControls.Label
        Protected WithEvents lblFinishDate As System.Web.UI.WebControls.Label
        Protected WithEvents hidShortView As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents hidPageOneNum As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents hidPageNow As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents ddlLabel As System.Web.UI.WebControls.DropDownList
        Protected WithEvents dtgInventoryLost As System.Web.UI.WebControls.DataGrid
        Protected WithEvents dtgInventoryFalsePath As System.Web.UI.WebControls.DataGrid
        Protected WithEvents lblInventoryName As System.Web.UI.WebControls.Label
        Protected WithEvents lblPage As System.Web.UI.WebControls.Label

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

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckPemissions()
            Call Initialize()
            If Not Page.IsPostBack Then
                hidType.Value = Request("Type")
                hidInt.Value = Request("InventoryID")
                hidLib.Value = Request("LibID")
                hidLoc.Value = Request("LocID")
                hidShelf.Value = Request("Shelf")
                Call BindData()
            End If
            'hidType.Value = 1
            'If Not Page.IsPostBack Then
            '    Try
            '        hidType.Value = Request("hidType")
            '        hidInt.Value = Request("hidInt")
            '        hidLib.Value = Request("hidLib")
            '        hidLoc.Value = Request("hidLoc")
            '        hidShelf.Value = Request("hidShelf")
            '        hidShortView.Value = Request("hidShortView")
            '        hidPageOneNum.Value = Request("hidPageOneNum")
            '        hidPageNow.Value = Request("txtPageIndex")
            '    Catch ex As Exception
            '    End Try
            '    Call BindData()
            'End If
        End Sub

        ' Method: CheckPemissions
        Sub CheckPemissions()
            If CheckPemission(177) Then
            Else
                WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub

        ' Method: AddColumnInTable
        Public Function AddColumnInTableC1(ByVal dvOut As DataView) As DataTable
            Dim inti As Integer
            If Not dvOut Is Nothing Then
                If dvOut.Count > 0 Then
                    For inti = 1 To dvOut.Count - 1
                        dvOut.Item(inti).Item("IDRESERVE") = inti + 1
                    Next inti
                    Return dvOut.Table
                End If
            End If
        End Function

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

        ' Method: BindData
        Sub BindData()
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
            Dim intCopyNum1Page As Integer = CInt(hidPageOneNum.Value)
            Dim intCurrentPage As Integer = CInt(hidPageNow.Value) - 1

            If hidType.Value = 0 Then ' Lost 
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

                strInventory = ddlLabel.Items(7).Text
                tblResult = objBLibrary.GetLibrary()

                If Not tblResult Is Nothing Then
                    If tblResult.Rows.Count > 0 Then
                        strInventory = strInventory + CStr(tblResult.Rows(0).Item("Name")) & "  "
                    End If
                End If

                'Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBLibrary.ErrorMsg, ddlLabel.Items(0).Text, objBLibrary.ErrorCode)

                tblResult = objBLocation.GetLocation

                'Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBLocation.ErrorMsg, ddlLabel.Items(0).Text, objBLocation.ErrorCode)

                If Not tblResult Is Nothing Then
                    If tblResult.Rows.Count > 0 Then
                        strInventory = strInventory + " " + ddlLabel.Items(8).Text + CStr(tblResult.Rows(0).Item("Symbol")) & "  "
                    End If
                End If

                If hidShelf.Value <> "" Then
                    objBInventory.Shelf = hidShelf.Value
                    strInventory = strInventory + ddlLabel.Items(9).Text + hidShelf.Value
                Else
                    objBInventory.Shelf = ""
                End If

                tblResult = Nothing

                tblResult = objBInventory.GetInventory()
                'Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBInventory.ErrorMsg, ddlLabel.Items(0).Text, objBInventory.ErrorCode)

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
                End If

                strInventoryHeader = str & strInventory & "<br>" & strFullName
                ' Show page title
                lblInventoryName.Text = strInventoryHeader

                tblResult = objBInventory.GetItemFalsePaths
                'Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBInventory.ErrorMsg, ddlLabel.Items(0).Text, objBInventory.ErrorCode)

                If Not tblResult Is Nothing Then
                    If tblResult.Rows.Count > 0 Then

                    End If
                End If
                'If Not tblResult Is Nothing Then
                '    If tblResult.Rows.Count > 0 Then
                '        dvResult = tblResult.DefaultView
                '        If CInt(hidShortView.Value) = 0 Then
                '            dvResult.Sort = "Content"
                '        ElseIf CInt(hidShortView.Value) = 1 Then
                '            dvResult.Sort = "Copynumber"
                '        Else
                '            dvResult.Sort = "CallNumber"
                '        End If
                '        tblResult = AddColumnInTableC1(dvResult)
                '        ddlNameNoHave.Visible = False
                '        dtgInventoryLost.Visible = False
                '        dtgInventoryFalsePath.Visible = True
                '        dtgInventoryFalsePath.PageSize = intCopyNum1Page
                '        dtgInventoryFalsePath.CurrentPageIndex = intCurrentPage
                '        dtgInventoryFalsePath.DataSource = dvResult
                '        dtgInventoryFalsePath.DataBind()
                '        dtgInventoryFalsePath.CurrentPageIndex = CInt(hidPageOneNum.Value) - 1
                '        lblPage.Text = "--" & CStr(hidPageOneNum.Value) & "--"
                '    Else
                '    End If
                'Else
                'End If
            Else ' Wrong path
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

                strInventory = ddlLabel.Items(7).Text
                tblResult = objBLibrary.GetLibrary()
                If Not tblResult Is Nothing Then
                    If tblResult.Rows.Count > 0 Then
                        strInventory = strInventory + CStr(tblResult.Rows(0).Item("Name")) & "  "
                    End If
                End If

                'Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBLibrary.ErrorMsg, ddlLabel.Items(0).Text, objBLibrary.ErrorCode)

                tblResult = objBLocation.GetLocation
                'Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBLocation.ErrorMsg, ddlLabel.Items(0).Text, objBLocation.ErrorCode)

                If Not tblResult Is Nothing Then
                    If tblResult.Rows.Count > 0 Then
                        strInventory = strInventory + " " + ddlLabel.Items(8).Text + CStr(tblResult.Rows(0).Item("Symbol")) & "  "
                    End If
                End If

                If hidShelf.Value <> "" Then
                    objBInventory.Shelf = hidShelf.Value
                    strInventory = strInventory + ddlLabel.Items(9).Text + hidShelf.Value
                Else
                    objBInventory.Shelf = ""
                End If

                tblResult = objBInventory.GetInventory()
                'Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBInventory.ErrorMsg, ddlLabel.Items(0).Text, objBInventory.ErrorCode)

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
                End If

                strInventoryHeader = str & strInventory & "<br>" & strFullName
                ' Show page title
                lblInventoryName.Text = strInventoryHeader

                tblResult = objBInventory.GetItemNoHaveReal
                'Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBInventory.ErrorMsg, ddlLabel.Items(0).Text, objBInventory.ErrorCode)


                If Not tblResult Is Nothing Then
                    If tblResult.Rows.Count > 0 Then
                        dvResult = tblResult.DefaultView
                        If CInt(hidShortView.Value) = 0 Then
                            dvResult.Sort = "Content"
                        ElseIf CInt(hidShortView.Value) = 1 Then
                            dvResult.Sort = "Copynumber"
                        Else
                            dvResult.Sort = "CallNumber"
                        End If
                        tblResult = AddColumnInTableC1(dvResult)
                        dtgInventoryFalsePath.Visible = False
                        dtgInventoryLost.Visible = True
                        dtgInventoryLost.PageSize = intCopyNum1Page
                        dtgInventoryLost.CurrentPageIndex = intCurrentPage
                        dtgInventoryLost.DataSource = dvResult
                        dtgInventoryLost.DataBind()
                        dtgInventoryLost.CurrentPageIndex = CInt(hidPageOneNum.Value) - 1
                        lblPage.Text = "--" & CStr(hidPageOneNum.Value) & "--"
                        Call WriteLog(96, ddlLabel.Items(3).Text & ":" & strIntName, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                    Else
                    End If
                Else
                End If
            End If
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