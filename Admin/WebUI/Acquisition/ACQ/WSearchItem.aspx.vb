Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.BusinessRules.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WSearchItem
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

        ' Declare variables
        Private objBFormingSQL As New clsBFormingSQL
        Private objBDB As New clsBCommonDBSystem
        Private objBItem As New clsBItem

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                If Not Request.QueryString("ControlName") & "" = "" Then
                    hdControlName.Value = Request.QueryString("ControlName")
                End If
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: Init all need objects
        Sub Initialize()
            objBFormingSQL.InterfaceLanguage = Session("InterfaceLanguage")
            objBFormingSQL.DBServer = Session("DBServer")
            objBFormingSQL.ConnectionString = Session("ConnectionString")
            Call objBFormingSQL.Initialize()

            objBDB.InterfaceLanguage = Session("InterfaceLanguage")
            objBDB.DBServer = Session("DBServer")
            objBDB.ConnectionString = Session("ConnectionString")
            Call objBDB.Initialize()

            objBItem.InterfaceLanguage = Session("InterfaceLanguage")
            objBItem.DBServer = Session("DBServer")
            objBItem.ConnectionString = Session("ConnectionString")
            Call objBItem.Initialize()
        End Sub

        ' Method: BindJS
        ' Purpose: Include all need js functions
        Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("selfJs", "<script language = 'javascript' src = '../js/Acq/WSearchItem.js'></script>")

            btnReset.Attributes.Add("OnClick", "document.forms[0].reset(); return false;")
            btnSearch.Attributes.Add("OnClick", "return CheckAll('" & ddlLabel.Items(2).Text & "');")
            btnClose.Attributes.Add("OnClick", "self.close();")
        End Sub

        Sub SearchItem()
            Dim arrBool()
            Dim arrVal()
            Dim arrField()
            Dim intk
            intk = 0
            If Not Trim(txtTitle.Text) = "" Then
                ReDim Preserve arrBool(intk)
                ReDim Preserve arrField(intk)
                ReDim Preserve arrVal(intk)
                arrBool(intk) = "AND"
                arrField(intk) = "TI"
                arrVal(intk) = Trim(txtTitle.Text)
                intk = intk + 1
            End If
            If Not Trim(txtPublisher.Text) = "" Then
                ReDim Preserve arrBool(intk)
                ReDim Preserve arrField(intk)
                ReDim Preserve arrVal(intk)
                arrBool(intk) = "AND"
                arrField(intk) = "2"
                arrVal(intk) = Trim(txtPublisher.Text)
                intk = intk + 1
            End If
            If Not Trim(txtAuthor.Text) = "" Then
                ReDim Preserve arrBool(intk)
                ReDim Preserve arrField(intk)
                ReDim Preserve arrVal(intk)
                arrBool(intk) = "AND"
                arrField(intk) = "1"
                arrVal(intk) = Trim(txtAuthor.Text)
                intk = intk + 1
            End If
            If Not Trim(txtYear.Text) = "" Then
                ReDim Preserve arrBool(intk)
                ReDim Preserve arrField(intk)
                ReDim Preserve arrVal(intk)
                arrBool(intk) = "AND"
                arrField(intk) = "YR"
                arrVal(intk) = Trim(txtYear.Text)
                intk = intk + 1
            End If
            If Not Trim(txtCopyNumber.Text) = "" Then
                ReDim Preserve arrBool(intk)
                ReDim Preserve arrField(intk)
                ReDim Preserve arrVal(intk)
                arrBool(intk) = "AND"
                arrField(intk) = "BN"
                arrVal(intk) = Trim(txtCopyNumber.Text)
                intk = intk + 1
            End If
            If Not Trim(txtISBN.Text) = "" Then
                ReDim Preserve arrBool(intk)
                ReDim Preserve arrField(intk)
                ReDim Preserve arrVal(intk)
                arrBool(intk) = "AND"
                arrField(intk) = "IB"
                arrVal(intk) = Trim(txtISBN.Text)
                intk = intk + 1
            End If
            objBFormingSQL.FieldArr = arrField
            objBFormingSQL.ValArr = arrVal
            objBFormingSQL.BoolArr = arrBool

            Dim tblItem As New DataTable
            Dim strIDs As String
            Dim intSumFound As Integer = 100

            ' Get informations of selected item
            objBFormingSQL.LibID = clsSession.GlbSite
            'objBDB.LibID = clsSession.GlbSite
            objBDB.SQLStatement = objBFormingSQL.FormingASQL()
            tblItem = objBDB.RetrieveItemInfor()
            If Not tblItem Is Nothing Then
                If tblItem.Rows.Count > 0 Then
                    intSumFound = tblItem.Rows.Count
                    'If tblItem.Rows.Count < intSumFound Then
                    '    intSumFound = tblItem.Rows.Count
                    'End If

                    If intSumFound > 0 Then
                        lblCap.Visible = True
                        lblCapResult.Visible = True
                        lblResult.Visible = True
                        lblResult.Text = intSumFound
                        lblCapResult.Visible = True
                    Else
                        lblCap.Visible = False
                        lblCapResult.Visible = False
                        lblResult.Visible = False
                        lblCapResult.Visible = False
                    End If

                    'PhuongTT M:20081217
                    'B1
                    'strIDs = ""
                    'For intk = 0 To intSumFound - 1
                    '    strIDs = strIDs & tblItem.Rows(intk).Item("ID") & ","
                    'Next
                    'If strIDs <> "" Then
                    '    strIDs = Left(strIDs, Len(strIDs) - 1)
                    'End If
                    'E1

                    objBItem.ItemIDs = objBDB.SQLStatement 'strIDs
                    objBItem.ControlName = hdControlName.Value

                    Dim tblTemp As DataTable
                    tblTemp = objBItem.GetTitlesAndCode
                    If Not tblTemp Is Nothing Then
                        If tblTemp.Rows.Count > 0 Then
                            DgrResult.DataSource = tblTemp
                            DgrResult.DataBind()
                        End If
                        tblTemp = Nothing
                    Else
                        DgrResult.DataSource = Nothing
                        DgrResult.DataBind()
                    End If
                Else
                    lblCap.Visible = False
                    lblCapResult.Visible = False
                    lblResult.Visible = False
                    lblCapResult.Visible = False

                    DgrResult.DataSource = Nothing
                    DgrResult.DataBind()
                End If
            Else
                lblCap.Visible = False
                lblCapResult.Visible = False
                lblResult.Visible = False
                lblCapResult.Visible = False

                DgrResult.DataSource = Nothing
                DgrResult.DataBind()
            End If
        End Sub

        ' Event: btnSearch_Click
        ' Purpose: Execute searching data
        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            Me.ShowWaitingOnPage(ddlLabel.Items(3).Text, "..\..")
            Call SearchItem()
            Me.ShowWaitingOnPage("", "", True)

        End Sub

        ' Page_Unload Method
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Release all object
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBFormingSQL Is Nothing Then
                    objBFormingSQL.Dispose(True)
                    objBFormingSQL = Nothing
                End If
                If Not objBDB Is Nothing Then
                    objBDB.Dispose(True)
                    objBDB = Nothing
                End If
                If Not objBItem Is Nothing Then
                    objBItem.Dispose(True)
                    objBItem = Nothing
                End If
            Finally
                MyBase.Dispose()
                Call Dispose()
            End Try
        End Sub

        Private Sub DgrResult_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DgrResult.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.SelectedItem
                    Dim lnkTemp As HyperLink
                    lnkTemp = e.Item.FindControl("lnkCode")
                    lnkTemp.CssClass = "lbLinkFunction"
                    lnkTemp.Attributes.Add("onClick", "LoadBack('" & hdControlName.Value & "','" & DataBinder.Eval(e.Item.DataItem, "code") & "')")
            End Select
        End Sub
    End Class
End Namespace