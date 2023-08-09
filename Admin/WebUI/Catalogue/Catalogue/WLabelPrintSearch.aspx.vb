' class WLabelPrintSearch
' Puspose: Print label
' Creator: Sondp
' CreatedDate: 22/02/2005
' Modification History:

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports System.Math

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WLabelPrintSearch
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents hdStore As System.Web.UI.HtmlControls.HtmlInputHidden


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBLoc As New clsBLocation
        Private objBLib As New clsBLibrary
        Private objBFSQL As New clsBFormingSQL
        Private objBCB As New clsBCommonBusiness
        Private objBCT As New clsBCommonTemplate
        Private objBT As New clsBTemplate

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
            Call InitialThreeArrays()
            Call BindJS()
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(104) Then
                Call WriteErrorMssg(ddlLog.Items(2).Text)
            End If
        End Sub

        ' Method: Initialize
        Private Sub Initialize()
            ' Initialize objBLoc object
            objBLoc.InterfaceLanguage = Session("InterfaceLanguage")
            objBLoc.DBServer = Session("DBServer")
            objBLoc.ConnectionString = Session("ConnectionString")
            Call objBLoc.Initialize()

            ' Initialize objBLib object
            objBLib.InterfaceLanguage = Session("InterfaceLanguage")
            objBLib.DBServer = Session("DBServer")
            objBLib.ConnectionString = Session("ConnectionString")
            Call objBLib.Initialize()

            ' Initialize objBFSQL object
            objBFSQL.InterfaceLanguage = Session("InterfaceLanguage")
            objBFSQL.DBServer = Session("DBServer")
            objBFSQL.ConnectionString = Session("ConnectionString")
            Call objBFSQL.Initialize()

            ' Initialize objBCB object
            objBCB.InterfaceLanguage = Session("InterfaceLanguage")
            objBCB.DBServer = Session("DBServer")
            objBCB.ConnectionString = Session("ConnectionString")
            Call objBCB.Initialize()

            ' Initialize objBCT object
            objBCT.InterfaceLanguage = Session("InterfaceLanguage")
            objBCT.DBServer = Session("DBServer")
            objBCT.ConnectionString = Session("ConnectionString")
            Call objBCT.Initialize()

            ' Initialize objBT object
            objBT.InterfaceLanguage = Session("InterfaceLanguage")
            objBT.DBServer = Session("DBServer")
            objBT.ConnectionString = Session("ConnectionString")
            Call objBT.Initialize()
        End Sub

        ' Method: BindJS
        Private Sub BindJS()
            'PhuongTT 20080820
            'Modify ACQ-->Catalogue
            'B1
            Page.RegisterClientScriptBlock("WLabelPrintSearchJs", "<script language='javascript' src='../Js/Catalogue/WLabelPrintSearch.js'></script>")
            'E1

            ddlLibrary.Attributes.Add("OnChange", "BindStoreData(this.options[this.selectedIndex].value);return(false);")
            ddlStore.Attributes.Add("OnChange", "document.forms[0].txtStore.value=this.options[this.options.selectedIndex].value;return false;")

            optCodeItem.Attributes.Add("OnClick", "document.forms[0].txtFromCodeItem.focus();")
            optCopyNumber.Attributes.Add("OnClick", "document.forms[0].txtFromCopyNumber.focus();")
            optElse.Attributes.Add("OnClick", "document.forms[0].txtElse.focus();")

            txtFromCodeItem.Attributes.Add("OnClick", "document.forms[0].optCodeItem.checked=1;document.forms[0].optCopyNumber.checked=0;document.forms[0].optElse.checked=0;")
            txtToCodeItem.Attributes.Add("OnClick", "document.forms[0].optCodeItem.checked=1;document.forms[0].optCopyNumber.checked=0;document.forms[0].optElse.checked=0;")
            txtFromCopyNumber.Attributes.Add("OnClick", "document.forms[0].optCodeItem.checked=0;document.forms[0].optCopyNumber.checked=1;document.forms[0].optElse.checked=0;")
            txtToCopyNumber.Attributes.Add("OnClick", "document.forms[0].optCodeItem.checked=0;document.forms[0].optCopyNumber.checked=1;document.forms[0].optElse.checked=0;")
            txtElse.Attributes.Add("OnClick", "document.forms[0].optCodeItem.checked=0;document.forms[0].optCopyNumber.checked=0;document.forms[0].optElse.checked=1;")
            Me.SetCheckNumber(txtColPage, ddlLog.Items(3).Text, "5")
            Me.SetCheckNumber(txtHagPage, ddlLog.Items(3).Text, "4")
            btnPrint.Attributes.Add("OnClick", "return(PrintLabel());")
            btnReset.Attributes.Add("OnClick", "Resetform();return(false);")

            hrfFromCodeItem.NavigateUrl = "javascript:openSearchItem=window.open('../../Acquisition/ACQ/WSearchItem.aspx?ControlName=txtFromCodeItem','SearchCode', 'width=600,height=400,left=100,top=20,resizable=yes,scrollbars=yes');openSearchItem.focus();"
            hrfToCodeItem.NavigateUrl = "javascript:openSearchItem=window.open('../../Acquisition/ACQ/WSearchItem.aspx?ControlName=txtToCodeItem','SearchCode', 'width=600,height=400,left=100,top=20,resizable=yes,scrollbars=yes');openSearchItem.focus();"
        End Sub

        ' Method: BindData
        Private Sub BindData()
            Dim tblTem As New DataTable
            Dim listItem As New listItem

            ' Bind Library
            objBLib.LibID = clsSession.GlbSite
            tblTem = objBLib.GetLibrary
            If Not tblTem Is Nothing Then
                If tblTem.Rows.Count > 0 Then
                    ddlLibrary.DataSource = InsertOneRow(tblTem, "------ Chọn ------")
                    ddlLibrary.DataTextField = "Code"
                    ddlLibrary.DataValueField = "ID"
                    ddlLibrary.DataBind()
                Else
                    listItem.Text = "      "
                    listItem.Value = 0
                    ddlLibrary.Items.Add(listItem)
                End If
            End If
            tblTem = Nothing
            ' Bind ItemType
            objBCB.LibID = clsSession.GlbSite
            tblTem = objBCB.GetItemTypes
            If Not tblTem Is Nothing Then
                If tblTem.Rows.Count > 0 Then
                    ddlItemType.DataSource = InsertOneRow(tblTem, "     ")
                    ddlItemType.DataTextField = "TypeCode"
                    ddlItemType.DataValueField = "ID"
                    ddlItemType.DataBind()
                Else
                    listItem.Value = 0
                    listItem.Text = " "
                    ddlItemType.Items.Add(listItem)
                End If
            End If
            tblTem = Nothing

            ' Bind Tempalte
            objBCT.TemplateID = 0
            objBCT.TemplateType = 4
            objBCT.LibID = clsSession.GlbSite
            tblTem = objBCT.GetTemplate
            If Not tblTem Is Nothing Then
                If tblTem.Rows.Count > 0 Then
                    ddlFormal.DataSource = tblTem
                    ddlFormal.DataValueField = "ID"
                    ddlFormal.DataTextField = "Title"
                    ddlFormal.DataBind()
                    ddlFormal.Items(0).Selected = True
                End If
            End If

            tblTem = Nothing
            If Not Request.QueryString("ItemCode") & "" = "" Then
                txtFromCodeItem.Text = Request.QueryString("ItemCode")
                txtToCodeItem.Text = Request.QueryString("ItemCode")
                optCodeItem.Checked = True
                optCopyNumber.Checked = False
            End If
        End Sub

        ' Initial 3 java script arrays use for load location method
        Public Sub InitialThreeArrays()
            Dim strScript As String
            Dim tblLoc As DataTable
            Dim inti As Integer

            ' Select all locations
            objBLoc.LibID = 0
            objBLoc.UserID = Session("UserID")
            tblLoc = objBLoc.GetLocation()
            If Not tblLoc Is Nothing Then
                If tblLoc.Rows.Count > 0 Then
                    ' Init three arrays content ID, Symbol, LibID
                    strScript = "ID=new Array(" & tblLoc.Rows.Count - 1 & ");"
                    strScript &= "Symbol=new Array(" & tblLoc.Rows.Count - 1 & ");"
                    strScript &= "LibID=new Array(" & tblLoc.Rows.Count - 1 & ");"
                    For inti = 0 To tblLoc.Rows.Count - 1
                        strScript &= "ID[" & inti & "]=" & tblLoc.Rows(inti).Item("ID") & ";"
                        strScript &= "Symbol[" & inti & "]='" & tblLoc.Rows(inti).Item("Symbol") & "';"
                        strScript &= "LibID[" & inti & "]=" & tblLoc.Rows(inti).Item("LibID") & ";"
                    Next
                End If
            End If
            Page.RegisterClientScriptBlock("InitialThreeArraysJs", "<script language='javascript'>" & strScript & "</script>")
        End Sub

        ' Event: btnPrint_Click
        Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
            Dim arrItemIDs() As String
            Dim arrIDs() As String
            Dim inti As Integer
            Dim tblIDs As New DataTable
            If txtHagPage.Text = "" Or Not IsNumeric(txtHagPage.Text) Then
                txtHagPage.Text = 4
            End If
            If txtColPage.Text = "" Or Not IsNumeric(txtColPage.Text) Then
                txtColPage.Text = 5
            End If
            'PhuongTT 20080820
            'Modify --> GetIDsItemIDs(,,,,,,,,True)
            'B2
            ' Search by ItemCode
            If optCodeItem.Checked Then
                tblIDs = objBT.GetIDsItemIDs(0, ddlLibrary.SelectedValue, txtStore.Value, txtFromCodeItem.Text, txtToCodeItem.Text, txtFromCopyNumber.Text, txtToCopyNumber.Text, txtElse.Text, ddlItemType.SelectedValue, True)
            End If
            ' Search by CopyNumber 
            If optCopyNumber.Checked Then
                tblIDs = objBT.GetIDsItemIDs(1, ddlLibrary.SelectedValue, txtStore.Value, txtFromCodeItem.Text, txtToCodeItem.Text, txtFromCopyNumber.Text, txtToCopyNumber.Text, txtElse.Text, ddlItemType.SelectedValue, True)
            End If
            ' Search by user input
            If optElse.Checked Then
                tblIDs = objBT.GetIDsItemIDs(2, ddlLibrary.SelectedValue, txtStore.Value, txtFromCodeItem.Text, txtToCodeItem.Text, txtFromCopyNumber.Text, txtToCopyNumber.Text, txtElse.Text, ddlItemType.SelectedValue, True)
            End If
            'B2
            ' Process selected data
            If Not tblIDs Is Nothing Then
                If tblIDs.Rows.Count > 0 Then
                    ReDim arrItemIDs(tblIDs.Rows.Count - 1)
                    ReDim arrIDs(tblIDs.Rows.Count - 1)
                    For inti = 0 To tblIDs.Rows.Count - 1
                        arrIDs(inti) = tblIDs.Rows(inti).Item("ID")
                        arrItemIDs(inti) = tblIDs.Rows(inti).Item("ItemID")
                    Next
                    Session("MaxPage") = Math.Ceiling(tblIDs.Rows.Count / (CInt(txtColPage.Text) * CInt(txtHagPage.Text)))
                    Session("Ubound") = tblIDs.Rows.Count
                    Session("LibID") = ddlLibrary.SelectedValue
                    Session("LocID") = txtStore.Value
                    Session("TemplateID") = ddlFormal.SelectedValue
                    Session("HagPage") = txtHagPage.Text
                    Session("ColPage") = txtColPage.Text
                    Session("ItemIDs") = arrItemIDs
                    Session("IDs") = arrIDs
                    Page.RegisterClientScriptBlock("WLabelPrintFrameJs", "<script language='javascript'>self.location.href='WLabelPrintFrame.aspx';</script>")
                Else
                    Call DisposeSession()
                    Page.RegisterClientScriptBlock("AlertNotFoundData1", "<script language='javascript'>alert('" & ddlLog.Items(4).Text & "') ;</script>")
                End If
            Else
                Call DisposeSession()
                Page.RegisterClientScriptBlock("AlertNotFoundData2", "<script language='javascript'>alert('" & ddlLog.Items(4).Text & "') ;</script>")
            End If
        End Sub

        ' Method: DisposeSession
        Private Sub DisposeSession()
            'giai phong cac Session se su dung o form sau
            If Not Session("ItemIDs") Is Nothing Then
                Session("ItemIDs") = Nothing
            End If
            If Not Session("IDs") Is Nothing Then
                Session("IDs") = Nothing
            End If
            If Not Session("MaxPage") Is Nothing Then
                Session("MaxPage") = Nothing
            End If
            If Not Session("Ubound") Is Nothing Then
                Session("Ubound") = Nothing
            End If
            If Not Session("ColPage") Is Nothing Then
                Session("ColPage") = Nothing
            End If
            If Not Session("HagPage") Is Nothing Then
                Session("HagPage") = Nothing
            End If
            If Not Session("TemplateID") Is Nothing Then
                Session("TemplateID") = Nothing
            End If
        End Sub

        ' Page_Unload method
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBLoc Is Nothing Then
                objBLoc.Dispose(True)
                objBLoc = Nothing
            End If
            If Not objBLib Is Nothing Then
                objBLib.Dispose(True)
                objBLib = Nothing
            End If
            If Not objBFSQL Is Nothing Then
                objBFSQL.Dispose(True)
                objBFSQL = Nothing
            End If
            If Not objBCB Is Nothing Then
                objBCB.Dispose(True)
                objBCB = Nothing
            End If
            If Not objBCT Is Nothing Then
                objBCT.Dispose(True)
                objBCT = Nothing
            End If
            If Not objBT Is Nothing Then
                objBT.Dispose(True)
                objBT = Nothing
            End If
        End Sub
    End Class
End Namespace