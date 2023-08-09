Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WFicheForm
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblValid As System.Web.UI.WebControls.Label
        Protected WithEvents lblMsgNotFound As System.Web.UI.WebControls.Label
        Protected WithEvents lblSelType As System.Web.UI.WebControls.Label
        Protected WithEvents lblSelLib As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel0 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel2 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel3 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel4 As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBCatDicItemType As New clsBCatDicItemType
        Private objBTemplate As New clsBCommonTemplate
        Private objBFiche As New clsBFiche
        Private objBItemCollection As New clsBItemCollection
        Private objBLibrary As New clsBLibrary
        Private objBLocation As New clsBLocation

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialze()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call LoadData()
            End If
        End Sub

        ' Method: CheckFormPermission
        Private Sub CheckFormPermission()
            If Not CheckPemission(139) Then
                btnPrint.Enabled = False
            End If
        End Sub

        ' Method: Initialze
        ' Purpose: Init all object use in form
        Private Sub Initialze()
            ' Init objBCatDicItemType object
            objBCatDicItemType.InterfaceLanguage = Session("InterfaceLanguage")
            objBCatDicItemType.DBServer = Session("DbServer")
            objBCatDicItemType.ConnectionString = Session("ConnectionString")
            Call objBCatDicItemType.Initialize()

            ' Init objBTemplate object
            objBTemplate.InterfaceLanguage = Session("InterfaceLanguage")
            objBTemplate.DBServer = Session("DbServer")
            objBTemplate.ConnectionString = Session("ConnectionString")
            Call objBTemplate.Initialize()

            ' Init objBLibrary object
            objBLibrary.InterfaceLanguage = Session("InterfaceLanguage")
            objBLibrary.DBServer = Session("DbServer")
            objBLibrary.ConnectionString = Session("ConnectionString")
            Call objBLibrary.Initialize()

            ' Init objBLocation object
            objBLocation.InterfaceLanguage = Session("InterfaceLanguage")
            objBLocation.DBServer = Session("DbServer")
            objBLocation.ConnectionString = Session("ConnectionString")
            Call objBLocation.Initialize()

            ' Init objBFiche object
            objBFiche.InterfaceLanguage = Session("InterfaceLanguage")
            objBFiche.DBServer = Session("DbServer")
            objBFiche.ConnectionString = Session("ConnectionString")
            Call objBFiche.Initialize()

            ' Init objBItemCollection object
            objBItemCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemCollection.DBServer = Session("DBServer")
            objBItemCollection.ConnectionString = Session("ConnectionString")
            Call objBItemCollection.Initialize()
        End Sub

        ' Method: BindJS
        ' Purpose: Bind Javascript for all control need
        Private Sub BindJS()
            ' Declare variables
            Dim tblLoc As New DataTable
            Dim strJS As String
            Dim inti As Integer

            Page.RegisterClientScriptBlock("JSCommon", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("JSSelf", "<script language = 'javascript' src = '../js/Bibliography/WFicheForm.js'></script>")

            ' Get locations
            objBLocation.UserID = Session("UserID")
            tblLoc = objBLocation.GetLocation

            If Not tblLoc Is Nothing Then
                strJS = "LibID = new Array(" & tblLoc.Rows.Count - 1 & ");" & Chr(10)
                strJS = strJS & "LocID = new Array(" & tblLoc.Rows.Count - 1 & ");" & Chr(10)
                strJS = strJS & "Location = new Array(" & tblLoc.Rows.Count - 1 & ");" & Chr(10)

                For inti = 0 To tblLoc.Rows.Count - 1
                    strJS = strJS & "LibID[" & inti & "] = " & tblLoc.Rows(inti).Item("LibID") & ";" & Chr(10)
                    strJS = strJS & "LocID[" & inti & "] = " & tblLoc.Rows(inti).Item("ID") & ";" & Chr(10)
                    strJS = strJS & "Location[" & inti & "] = """ & tblLoc.Rows(inti).Item("Symbol") & """;" & Chr(10)
                Next
            End If

            Page.RegisterClientScriptBlock("GenJs", "<script language = 'javascript'>" & strJS & "</script>")

            ddlLib.Attributes.Add("onChange", "FilterLocation();")
            ddlLoc.Attributes.Add("onChange", "SetHidVal();")

            btnPrint.Attributes.Add("onClick", "return FichePrint('" & ddlLabel.Items(6).Text & "');")
            btnReset.Attributes.Add("onClick", "return ResetAll();")
            'Me.SetCheckNumber(txtItemIDFrom, ddlLabel.Items(6).Text, ">0")
            'Me.SetCheckNumber(txtItemIDTo, ddlLabel.Items(6).Text, ">0")
        End Sub

        ' Method: LoadData
        Private Sub LoadData()
            Dim tblTemp As DataTable

            tblTemp = objBCatDicItemType.Retrieve
            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    ddlItemType.DataSource = InsertOneRow(tblTemp, ddlLabel.Items(4).Text)
                    ddlItemType.DataTextField = "strView"
                    ddlItemType.DataValueField = "ID"
                    ddlItemType.DataBind()
                End If
            End If

            objBTemplate.TemplateType = 15
            objBTemplate.LibID = clsSession.GlbSite
            tblTemp = objBTemplate.GetTemplate
            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    ddlTempate.DataSource = tblTemp
                    ddlTempate.DataValueField = "ID"
                    ddlTempate.DataTextField = "Title"
                    ddlTempate.DataBind()
                End If
            End If

            ' Get library
            objBLibrary.UserID = Session("UserID")
            objBLibrary.LibID = clsSession.GlbSite
            tblTemp = objBLibrary.GetLibrary(1)
            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    ddlLib.DataSource = InsertOneRow(tblTemp, ddlLabel.Items(5).Text)
                    ddlLib.DataTextField = "FullName"
                    ddlLib.DataValueField = "ID"
                    ddlLib.DataBind()
                End If
            End If
        End Sub

        ' btnPrint_Click event
        'Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        '    ' Declare variables
        '    Dim arrID()
        '    Dim colPara As New Collection
        '    Dim intItemIDFrom As Integer
        '    Dim intItemIDTo As Integer
        '    Dim strIDTemplate As String
        '    Dim strTagSort As String
        '    Dim strCopyNumFrom As String
        '    Dim strCopyNumTo As String
        '    Dim intItemType As Integer
        '    Dim intLibID As Integer
        '    Dim intLocID As Integer
        '    Dim bytMultiFiche As Byte = 0
        '    Dim bytNewItemOnly As Byte = 0
        '    Dim intPageSize As Integer
        '    Dim strJS As String

        '    If chkNewRec.Checked Then
        '        bytNewItemOnly = 1
        '    End If
        '    If chkLoc.Checked Then
        '        bytMultiFiche = 1
        '    End If
        '    strCopyNumFrom = txtCopyNumberFrom.Text
        '    strCopyNumTo = txtCopyNumberTo.Text
        '    If txtFichePerPage.Text <> "" Then
        '        intPageSize = CInt(txtFichePerPage.Text)
        '    Else
        '        intPageSize = 5
        '    End If
        '    If txtItemIDFrom.Text <> "" Then
        '        Dim tblLRange As New DataTable
        '        objBItemCollection.TopNum = CInt(txtItemIDFrom.Text)
        '        tblLRange = objBItemCollection.GetIDByTopNum()
        '        If Not tblLRange Is Nothing Then
        '            If tblLRange.Rows.Count > 0 Then
        '                intItemIDFrom = tblLRange.Rows(0).Item(0)
        '            End If
        '        End If
        '    Else
        '        intItemIDFrom = 0
        '    End If
        '    If txtItemIDTo.Text <> "" Then
        '        Dim tblRRange As New DataTable
        '        objBItemCollection.TopNum = CInt(txtItemIDTo.Text)
        '        tblRRange = objBItemCollection.GetIDByTopNum()
        '        If Not tblRRange Is Nothing Then
        '            If tblRRange.Rows.Count > 0 Then
        '                intItemIDTo = tblRRange.Rows(0).Item(0)
        '            End If
        '        End If
        '    Else
        '        intItemIDTo = 0
        '    End If
        '    If txtLocID.Value <> "" Then
        '        intLocID = CInt(txtLocID.Value)
        '    Else
        '        intLocID = 0
        '    End If
        '    If ddlItemType.SelectedValue <> "" Then
        '        intItemType = CInt(ddlItemType.SelectedValue)
        '    Else
        '        intItemType = 0
        '    End If
        '    If ddlLib.SelectedValue <> "" Then
        '        intLibID = CInt(ddlLib.SelectedValue)
        '    Else
        '        intLibID = 0
        '    End If
        '    If ddlTempate.SelectedValue <> "" Then
        '        strIDTemplate = CStr(ddlTempate.SelectedValue)
        '    Else
        '        strIDTemplate = ""
        '    End If
        '    strTagSort = txtSortBy.Text
        '    If Trim(strTagSort) = "" Then
        '        strTagSort = "245$a"
        '    End If

        '    ' Add to collection
        '    'colPara.Add(intItemIDFrom, "ItemIDFrom")
        '    'colPara.Add(intItemIDTo, "ItemIDto")
        '    colPara.Add(intItemIDFrom, "ItemIDFrom")
        '    colPara.Add(intItemIDTo, "ItemIDto")
        '    colPara.Add(strIDTemplate, "IDTemplate")
        '    colPara.Add(strTagSort, "TagSort")
        '    colPara.Add(strCopyNumFrom, "CopyNumFrom")
        '    colPara.Add(strCopyNumTo, "CopyNumTo")
        '    colPara.Add(intItemType, "ItemType")
        '    colPara.Add(intLibID, "LibID")
        '    colPara.Add(intLocID, "LocID")
        '    colPara.Add(bytMultiFiche, "MultiFiche")
        '    colPara.Add(bytNewItemOnly, "NewItemOnly")
        '    colPara.Add(intPageSize, "PageSize")

        '    ' Set to clsBFiche
        '    objBFiche.ItemIDFrom = colPara.Item("ItemIDFrom")
        '    objBFiche.ItemIDTo = colPara.Item("ItemIDTo")
        '    objBFiche.IDTempate = colPara.Item("IDTemplate")
        '    objBFiche.TagSort = colPara.Item("TagSort")
        '    objBFiche.CopyNumFrom = colPara.Item("CopyNumFrom")
        '    objBFiche.CopyNumTo = colPara.Item("CopyNumTo")
        '    objBFiche.ItemType = colPara.Item("ItemType")
        '    objBFiche.LibID = colPara.Item("LibID")
        '    objBFiche.LocID = colPara.Item("LocID")
        '    objBFiche.MultiFiche = colPara.Item("MultiFiche")
        '    objBFiche.NewItemOnly = colPara.Item("NewItemOnly")
        '    objBFiche.UserID = Session("UserID")
        '    objBFiche.PageSize = colPara.Item("PageSize")

        '    arrID = objBFiche.Generate_IDSort

        '    If Not arrID Is Nothing AndAlso arrID.Length > 0 Then
        '        Session("colPara") = ""
        '        Session("FicheID") = ""
        '        Session("FicheID") = arrID
        '        Session("colPara") = colPara

        '        If chkExportToMSWord.Checked Then
        '            strJS = "parent.Workform.location.href='WFicheSaveFile.aspx';parent.Sentform.location.href='../WNothing.htm';"
        '            ' Work Print 
        '            Call WriteLog(79, ddlLabel.Items(3).Text & ddlAboutAction.Items(1).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
        '        Else
        '            strJS = "parent.Workform.location.href='WFichePrint.aspx?intPage=1';parent.Sentform.location.href='WFicheTaskBar.aspx';"
        '            ' Work Print 
        '            Call WriteLog(79, ddlLabel.Items(3).Text & ddlAboutAction.Items(0).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
        '        End If
        '    Else
        '        strJS = "alert('" & ddlLabel.Items(7).Text & "');"
        '        ddlLib.SelectedValue = 0
        '    End If
        '    Page.RegisterClientScriptBlock("JSRedirect", "<script language = 'javascript'>" & strJS & "</script>")
        'End Sub

        ' Page_Unload event

        Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
            ' Declare variables
            Dim arrID()
            Dim colPara As New Collection
            Dim strItemCodeFrom As String = ""
            Dim strItemCodeTo As String = ""
            Dim strIDTemplate As String
            Dim strTagSort As String
            Dim strCopyNumFrom As String
            Dim strCopyNumTo As String
            Dim intItemType As Integer
            Dim intLibID As Integer
            Dim intLocID As Integer
            Dim bytMultiFiche As Byte = 0
            Dim bytNewItemOnly As Byte = 0
            Dim intPageSize As Integer
            Dim strJS As String

            Dim strItemCodes As String = ""

            If chkNewRec.Checked Then
                bytNewItemOnly = 1
            End If
            If chkLoc.Checked Then
                bytMultiFiche = 1
            End If
            strCopyNumFrom = txtCopyNumberFrom.Text
            strCopyNumTo = txtCopyNumberTo.Text
            If txtFichePerPage.Text <> "" Then
                intPageSize = CInt(txtFichePerPage.Text)
            Else
                intPageSize = 4
            End If
            'If txtItemIDFrom.Text <> "" Then
            '    Dim tblLRange As New DataTable
            '    objBItemCollection.TopNum = CInt(txtItemIDFrom.Text)
            '    tblLRange = objBItemCollection.GetIDByTopNum()
            '    If Not tblLRange Is Nothing Then
            '        If tblLRange.Rows.Count > 0 Then
            '            intItemIDFrom = tblLRange.Rows(0).Item(0)
            '        End If
            '    End If
            'Else
            '    intItemIDFrom = 0
            'End If
            'If txtItemIDTo.Text <> "" Then
            '    Dim tblRRange As New DataTable
            '    objBItemCollection.TopNum = CInt(txtItemIDTo.Text)
            '    tblRRange = objBItemCollection.GetIDByTopNum()
            '    If Not tblRRange Is Nothing Then
            '        If tblRRange.Rows.Count > 0 Then
            '            intItemIDTo = tblRRange.Rows(0).Item(0)
            '        End If
            '    End If
            'Else
            '    intItemIDTo = 0
            'End If
            If txtItemIDFrom.Text <> "" Then
                strItemCodeFrom = txtItemIDFrom.Text
            End If
            If txtItemIDTo.Text <> "" Then
                strItemCodeTo = txtItemIDTo.Text
            End If
            If txtItemCode.Text <> "" Then
                Dim arrCodes() As String = txtItemCode.Text.Split(",")
                Dim index As Integer = 0
                For Each codes As String In arrCodes
                    If (index = 0) Then
                        strItemCodes = strItemCodes & "Code='" & codes & "' "
                    Else
                        strItemCodes = strItemCodes & "OR Code='" & codes & "' "
                    End If
                    index = index + 1
                Next

            End If
            If txtLocID.Value <> "" Then
                intLocID = CInt(txtLocID.Value)
            Else
                intLocID = 0
            End If
            If ddlItemType.SelectedValue <> "" Then
                intItemType = CInt(ddlItemType.SelectedValue)
            Else
                intItemType = 0
            End If
            If ddlLib.SelectedValue <> "" Then
                intLibID = CInt(ddlLib.SelectedValue)
            Else
                intLibID = 0
            End If
            If ddlTempate.SelectedValue <> "" Then
                strIDTemplate = CStr(ddlTempate.SelectedValue)
            Else
                strIDTemplate = ""
            End If
            strTagSort = txtSortBy.Text
            If Trim(strTagSort) = "" Then
                strTagSort = "245$a"
            End If

            ' Add to collection
            'colPara.Add(intItemIDFrom, "ItemIDFrom")
            'colPara.Add(intItemIDTo, "ItemIDto")strItemCodes
            colPara.Add(strItemCodeFrom, "ItemCodeFrom")
            colPara.Add(strItemCodeTo, "ItemCodeTo")
            colPara.Add(strItemCodes, "ItemCodes")
            colPara.Add(strIDTemplate, "IDTemplate")
            colPara.Add(strTagSort, "TagSort")
            colPara.Add(strCopyNumFrom, "CopyNumFrom")
            colPara.Add(strCopyNumTo, "CopyNumTo")
            colPara.Add(intItemType, "ItemType")
            colPara.Add(intLibID, "LibID")
            colPara.Add(intLocID, "LocID")
            colPara.Add(bytMultiFiche, "MultiFiche")
            colPara.Add(bytNewItemOnly, "NewItemOnly")
            colPara.Add(intPageSize, "PageSize")

            ' Set to clsBFiche
            'objBFiche.ItemIDFrom = colPara.Item("ItemIDFrom")
            'objBFiche.ItemIDTo = colPara.Item("ItemIDTo")
            objBFiche.ItemCodeFrom = colPara.Item("ItemCodeFrom")
            objBFiche.ItemCodeTo = colPara.Item("ItemCodeTo")
            objBFiche.ItemCodes = colPara.Item("ItemCodes")
            objBFiche.IDTempate = colPara.Item("IDTemplate")
            objBFiche.TagSort = colPara.Item("TagSort")
            objBFiche.CopyNumFrom = colPara.Item("CopyNumFrom")
            objBFiche.CopyNumTo = colPara.Item("CopyNumTo")
            objBFiche.ItemType = colPara.Item("ItemType")
            objBFiche.LibID = colPara.Item("LibID")
            objBFiche.LocID = colPara.Item("LocID")
            objBFiche.MultiFiche = colPara.Item("MultiFiche")
            objBFiche.NewItemOnly = colPara.Item("NewItemOnly")
            objBFiche.UserID = Session("UserID")
            objBFiche.PageSize = colPara.Item("PageSize")

            arrID = objBFiche.Generate_CodeSort

            If Not arrID Is Nothing AndAlso arrID.Length > 0 Then
                Session("colPara") = ""
                Session("FicheID") = ""
                Session("FicheID") = arrID
                Session("colPara") = colPara

                If chkExportToMSWord.Checked Then
                    strJS = "parent.Workform.location.href='WFicheSaveFile.aspx';parent.Sentform.location.href='../WNothing.htm';"
                    ' Work Print 
                    Call WriteLog(79, ddlLabel.Items(3).Text & ddlAboutAction.Items(1).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                Else
                    strJS = "parent.Workform.location.href='WFichePrint.aspx?intPage=1';parent.Sentform.location.href='WFicheTaskBar.aspx';"
                    ' Work Print 
                    Call WriteLog(79, ddlLabel.Items(3).Text & ddlAboutAction.Items(0).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                End If
            Else
                strJS = "alert('" & ddlLabel.Items(7).Text & "');"
                ddlLib.SelectedValue = 0
            End If
            Page.RegisterClientScriptBlock("JSRedirect", "<script language = 'javascript'>" & strJS & "</script>")
        End Sub
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not objBCatDicItemType Is Nothing Then
                        objBCatDicItemType.Dispose(True)
                        objBCatDicItemType = Nothing
                    End If
                    If Not objBTemplate Is Nothing Then
                        objBTemplate.Dispose(True)
                        objBTemplate = Nothing
                    End If
                    If Not objBFiche Is Nothing Then
                        objBFiche.Dispose(True)
                        objBFiche = Nothing
                    End If
                    If Not objBItemCollection Is Nothing Then
                        objBItemCollection.Dispose(True)
                        objBItemCollection = Nothing
                    End If
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace