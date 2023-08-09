Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports System.Globalization

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WCopyNumber
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblMsgAlert As System.Web.UI.WebControls.Label
        Protected WithEvents lblExisting As System.Web.UI.WebControls.Label
        Protected WithEvents lblMesErr1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblMesErr2 As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBCB As New clsBCommonBusiness
        Private objBLib As New clsBLibrary
        Private objBLoc As New clsBLocation
        Private objBCopyNumber As New clsBCopyNumber
        Private objBInput As New clsBInput
        Private objBLoanType As New clsBLoanType
        Private objBItem As New clsBItem
        Private objBItemCol As New clsBItemCollection
        Private objBDB As New clsBCommonDBSystem
        Private objBTemplate As New clsBCommonTemplate

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            If Not Request("HoldingsInCatalogNew") Is Nothing AndAlso Request("HoldingsInCatalogNew") = 0 Then
                Session("HoldingsInCatalogNew") = 0
            End If
            If Session("HoldingsInCatalogNew") = 0 Then
                'btnUpdate.Enabled = False
                'lblReasonDel.Visible = False
                'ddlReasonDel.Visible = False
                'btnDelHoding.Visible = False
            Else
                btnUpdate.Enabled = True
                lblReasonDel.Visible = True
                ddlReasonDel.Visible = True
                btnDelHoding.Visible = True
            End If
            If Session("HoldingsInCatalogNew") = 1 Then
                chkAllinLoc.Checked = False
                chkAllinLoc.Enabled = False
                lblReasonDel.Visible = True
                ddlReasonDel.Visible = True
                btnDelHoding.Visible = True
            Else
                lblReasonDel.Visible = False
                ddlReasonDel.Visible = False
                btnDelHoding.Visible = False
                chkAllinLoc.Enabled = True
            End If
            Call BindJS()
            If Not Page.IsPostBack Then
                Call BindData()
                Call BindDataGrid()
                Call ReadTitle()
                Call BindParameter()
            End If
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check form permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(44) Then
                btnUpdate.Enabled = False
                btnDelHoding.Enabled = False
                btnReceiveUnlock.Enabled = False
                btnReceiveDelivered.Enabled = False
            End If
            If Not CheckPemission(103) Then
                btnBarCode.Enabled = False
            End If
            If Not CheckPemission(104) Then
                btnLabel.Enabled = False
            End If
        End Sub

        ' Method: ReadTitle
        Public Sub ReadTitle()
            Dim strTitle As String = ""
            Dim intItemID As Integer
            Dim tblItem As New DataTable
            Dim tblRangeItemID As DataTable
            Dim lngItemID As Integer

            If Request("ItemID") > 0 Then
                lngItemID = Request("ItemID")
            Else
                tblRangeItemID = objBItemCol.GetRangeItemID
                If Not tblRangeItemID Is Nothing AndAlso tblRangeItemID.Rows.Count > 0 Then
                    lngItemID = tblRangeItemID.Rows(0).Item("MaxID")
                Else
                    lngItemID = 0
                End If
            End If

            If lngItemID > 0 Then
                Dim tblPOHolding As DataTable
                objBDB.SQLStatement = "select A.RequestedCopies, A.ReceivedCopies,A.POID,A.UnitPrice,A.AdditionalBy,A.AcqSourceID,A.LoanTypeID,B.ReceiptNo,C.Rate from Acq_tblItem A JOIN Acq_tblPo B ON A.POID=B.ID LEFT JOIN Acq_tblCurrency C ON A.CURRENCY=C.CURRENCYCODE WHERE ITEMID=" & CStr(lngItemID)
                tblPOHolding = objBDB.RetrieveItemInfor
                If Not tblPOHolding Is Nothing AndAlso tblPOHolding.Rows.Count > 0 Then
                    If Not IsDBNull(tblPOHolding.Rows(0).Item("Rate")) Then
                        txtPrice.Text = CDbl(tblPOHolding.Rows(0).Item("Rate")) * CDbl(tblPOHolding.Rows(0).Item("UnitPrice"))
                    Else
                        txtPrice.Text = CDbl(tblPOHolding.Rows(0).Item("UnitPrice"))
                    End If
                    txtPrice.Text = If(Not (txtPrice.Text = "0"), CDbl(txtPrice.Text).ToString("#,##"), "0")
                    If Not IsDBNull(tblPOHolding.Rows(0).Item("AdditionalBy")) Then
                        txtAdditionalBy.Text = tblPOHolding.Rows(0).Item("AdditionalBy") & ""
                    End If
                    If Not IsDBNull(tblPOHolding.Rows(0).Item("AcqSourceID")) Then
                        ddlACQSource.SelectedValue = tblPOHolding.Rows(0).Item("AcqSourceID") & ""
                    End If
                    If Not IsDBNull(tblPOHolding.Rows(0).Item("LoanTypeID")) Then
                        ddlLoanType.SelectedValue = tblPOHolding.Rows(0).Item("LoanTypeID") & ""
                    End If
                    If Not IsDBNull(tblPOHolding.Rows(0).Item("ReceiptNo")) Then
                        txtAcqCode.Text = tblPOHolding.Rows(0).Item("ReceiptNo") & ""
                    End If
                End If

                objBItem.ItemID = lngItemID
                objBItem.Code = ""
                tblItem = objBItem.GetItems
                If Not tblItem Is Nothing AndAlso tblItem.Rows.Count > 0 Then
                    intItemID = tblItem.Rows(0).Item("ID")
                    txtCode.Text = tblItem.Rows(0).Item("Code")
                Else
                    intItemID = 0
                End If
                objBItemCol.ItemIDs = CStr(intItemID)
                'strTitle = objBItemCol.CreateISBDRec()
                strTitle = objBItemCol.CreateISBDAuthor()
                txtDeptTitle.Text = strTitle
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: Init all need objects
        Sub Initialize()
            ' Init objBCB object
            objBCB.InterfaceLanguage = Session("InterfaceLanguage")
            objBCB.DBServer = Session("DBServer")
            objBCB.ConnectionString = Session("ConnectionString")
            Call objBCB.Initialize()

            ' Init objBLib object
            objBLib.InterfaceLanguage = Session("InterfaceLanguage")
            objBLib.DBServer = Session("DBServer")
            objBLib.ConnectionString = Session("ConnectionString")
            Call objBLib.Initialize()

            ' Init objBLoc object
            objBLoc.InterfaceLanguage = Session("InterfaceLanguage")
            objBLoc.DBServer = Session("DBServer")
            objBLoc.ConnectionString = Session("ConnectionString")
            objBLoc.Initialize()

            ' Init objBCopyNumber object
            objBCopyNumber.InterfaceLanguage = Session("InterfaceLanguage")
            objBCopyNumber.DBServer = Session("DBServer")
            objBCopyNumber.ConnectionString = Session("ConnectionString")
            Call objBCopyNumber.Initialize()

            ' Init objBInput object
            objBInput.InterfaceLanguage = Session("InterfaceLanguage")
            objBInput.DBServer = Session("DBServer")
            objBInput.ConnectionString = Session("ConnectionString")
            Call objBInput.Initialize()

            ' Init objBLoanType object
            objBLoanType.InterfaceLanguage = Session("InterfaceLanguage")
            objBLoanType.DBServer = Session("DBServer")
            objBLoanType.ConnectionString = Session("ConnectionString")
            Call objBLoanType.Initialize()

            ' Init objBItem object
            objBItem.InterfaceLanguage = Session("InterfaceLanguage")
            objBItem.DBServer = Session("DBServer")
            objBItem.ConnectionString = Session("ConnectionString")
            Call objBItem.Initialize()

            ' Init objBItemCol object
            objBItemCol.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemCol.DBServer = Session("DBServer")
            objBItemCol.ConnectionString = Session("ConnectionString")
            Call objBItemCol.Initialize()

            ' Init objBDB object
            objBDB.InterfaceLanguage = Session("InterfaceLanguage")
            objBDB.DBServer = Session("DBServer")
            objBDB.ConnectionString = Session("ConnectionString")
            Call objBDB.Initialize()

            'objBTemplate
            objBTemplate.InterfaceLanguage = Session("InterfaceLanguage")
            objBTemplate.DBServer = Session("DBServer")
            objBTemplate.ConnectionString = Session("ConnectionString")
            Call objBTemplate.Initialize()
            ' Set default date
            'PhuongTT
            'Modify : 20081007
            If Not IsPostBack Then
                txtDateChng.Text = Session("ToDay")
            End If
        End Sub
        Private Sub BindParameter()
            Dim tblPara As DataTable
            objBDB.SQLStatement = "SELECT Val FROM Sys_tblParameter  WHERE Name ='ALLOW_MODIFY_HOLDINGS_IN_CATALOG_MODULE'"
            tblPara = objBDB.RetrieveItemInfor
            If tblPara.Rows(0).Item(0) = 1 Then
                Session("ALLOW_MODIFY_HOLDINGS") = 1
            Else
                Session("ALLOW_MODIFY_HOLDINGS") = 0
            End If
        End Sub
        ' Method: BindData
        Public Sub BindData()
            Dim tblTemp As DataTable

            ' Get acquiry source
            tblTemp = objBCB.GetAcqSources
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlACQSource.DataSource = tblTemp
                ddlACQSource.DataTextField = "Source"
                ddlACQSource.DataValueField = "ID"
                ddlACQSource.DataBind()
                'ddlACQSource.SelectedIndex = tblTemp.Rows.Count - 1
                tblTemp.Clear()
            End If
            objBLoanType.LibID = clsSession.GlbSite
            tblTemp = objBLoanType.GetLoanTypes
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlLoanType.DataSource = tblTemp
                ddlLoanType.DataTextField = "LoanType"
                ddlLoanType.DataValueField = "ID"
                ddlLoanType.DataBind()
                tblTemp.Clear()
            End If

            Dim tblLib As New DataTable
            objBLib.UserID = Session("UserID")
            objBLib.LibID = clsSession.GlbSite
            tblLib = objBLib.GetLibrary(1, 1)
            If Not tblLib Is Nothing AndAlso tblLib.Rows.Count > 0 Then
                ddlLibrary.DataSource = tblLib
                ddlLibrary.DataTextField = "Code"
                ddlLibrary.DataValueField = "ID"
                ddlLibrary.DataBind()
            End If

            Dim intLibID As Integer
            If tblLib.Rows.Count > 0 Then
                intLibID = tblLib.Rows(0).Item("ID")
            Else
                intLibID = -1
            End If

            objBLoc.LibID = intLibID
            objBLoc.UserID = Session("UserID")
            tblTemp = objBLoc.GetLocation
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlLocation.DataSource = tblTemp
                ddlLocation.DataTextField = "CodeSymbol"
                ddlLocation.DataValueField = "ID"
                ddlLocation.DataBind()
            End If

            tblTemp = objBCopyNumber.GetRemoveReason
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlReasonDel.DataSource = tblTemp
                ddlReasonDel.DataTextField = "Reason"
                ddlReasonDel.DataValueField = "ID"
                ddlReasonDel.DataBind()
            End If

            tblTemp = objBCopyNumber.GetStatus
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlStatus.DataSource = tblTemp
                ddlStatus.DataTextField = "StatusNote"
                ddlStatus.DataValueField = "StatusCode"
                ddlStatus.DataBind()
                ddlStatus.SelectedValue = "TT001"
            End If

        End Sub

        'Method: Load Dafault value
        'Public Sub LoadDefault()
        '    If txtCode.Text <> "" Then
        '        'Get Default - Tho
        '        objBCopyNumber.Code = txtCode.Text
        '        Dim defaultHolding As DataTable = objBCopyNumber.GetLastRecordHoldingOfItem()
        '        If defaultHolding.Rows.Count <> 0 Then
        '            Dim defaultDate As DateTime = DateTime.Now
        '            If (Not String.IsNullOrEmpty(defaultHolding.Rows(0).Item("AcquiredDate") & "")) Then
        '                defaultDate = DateTime.Parse(defaultHolding.Rows(0).Item("AcquiredDate"))
        '            Else
        '                defaultDate = DateTime.Parse(defaultHolding.Rows(0).Item("CreatedDate"))
        '            End If

        '            Dim defaultAcqSource As String = defaultHolding.Rows(0).Item("AcquiredSourceID") & ""
        '            Try
        '                If (CInt(defaultHolding.Rows(0).Item("AcqSourceID") & "") <> 0) Then
        '                    defaultAcqSource = defaultHolding.Rows(0).Item("AcqSourceID") & ""
        '                End If
        '            Catch
        '            End Try


        '            Dim defaultLoanType As String = defaultHolding.Rows(0).Item("LoanTypeID") & ""
        '            Try
        '                If (CInt(defaultHolding.Rows(0).Item("LoanType") & "") <> 0) Then
        '                    defaultLoanType = defaultHolding.Rows(0).Item("LoanType") & ""
        '                End If
        '            Catch
        '            End Try

        '            Dim defaultPrice As String = defaultHolding.Rows(0).Item("Price") & ""
        '            Try
        '                If (CInt(defaultHolding.Rows(0).Item("UnitPrice") & "") <> 0) Then
        '                    defaultPrice = defaultHolding.Rows(0).Item("UnitPrice") & ""
        '                End If
        '            Catch
        '            End Try

        '            txtDateChng.Text = String.Format("{0:dd/MM/yyyy}", defaultDate)
        '            ddlLoanType.SelectedValue = defaultLoanType
        '            ddlACQSource.SelectedValue = defaultAcqSource
        '            txtPrice.Text = defaultPrice
        '            txtPrice.Text = If(Not (txtPrice.Text = "0"), CDbl(txtPrice.Text).ToString("#,##"), "0")
        '        End If
        '    End If
        'End Sub


        Public Sub LoadDefault()
            Dim tblItem As New DataTable
            'Dim tblRangeItemID As DataTable
            'Dim lngItemID As Integer
            'If Request("ItemID") > 0 Then
            '    lngItemID = Request("ItemID")
            'Else
            '    tblRangeItemID = objBItemCol.GetRangeItemID
            '    If Not tblRangeItemID Is Nothing AndAlso tblRangeItemID.Rows.Count > 0 Then
            '        lngItemID = tblRangeItemID.Rows(0).Item("MaxID")
            '    Else
            '        lngItemID = 0
            '    End If
            'End If

            'If lngItemID > 0 Then
            '    objBItem.ItemID = lngItemID
            '    objBItem.Code = ""
            '    tblItem = objBItem.GetItems
            '    If Not tblItem Is Nothing AndAlso tblItem.Rows.Count > 0 Then
            '        txtCode.Text = tblItem.Rows(0).Item("Code")
            '    End If
            'End If

            If txtCode.Text <> "" Then
                'Get Default - Tho
                'objBCopyNumber.Code = txtCode.Text
                'Dim defaultHolding As DataTable = objBCopyNumber.GetLastRecordHoldingOfItem()

                Dim defaultHolding As DataTable
                objBDB.SQLStatement = "select A.UnitPrice,A.AdditionalBy,A.AcqSourceID,A.LoanTypeID from Lib_tblItem A WHERE A.CODE='" & txtCode.Text & "'"
                defaultHolding = objBDB.RetrieveItemInfor

                If defaultHolding.Rows.Count <> 0 Then
                    'Dim defaultDate As DateTime = DateTime.Now
                    'If (Not String.IsNullOrEmpty(defaultHolding.Rows(0).Item("AcquiredDate") & "")) Then
                    '    defaultDate = DateTime.Parse(defaultHolding.Rows(0).Item("AcquiredDate"))
                    'Else
                    '    defaultDate = DateTime.Parse(defaultHolding.Rows(0).Item("CreatedDate"))
                    'End If

                    Dim defaultAcqSource As String = 0
                    Try
                        If (CInt(defaultHolding.Rows(0).Item("AcqSourceID") & "") <> 0) Then
                            defaultAcqSource = defaultHolding.Rows(0).Item("AcqSourceID") & ""
                        End If
                    Catch
                    End Try


                    Dim defaultLoanType As String = 0
                    Try
                        If (CInt(defaultHolding.Rows(0).Item("LoanTypeID") & "") <> 0) Then
                            defaultLoanType = defaultHolding.Rows(0).Item("LoanTypeID") & ""
                        End If
                    Catch
                    End Try

                    'Dim defaultPrice As String = defaultHolding.Rows(0).Item("UnitPrice") & ""
                    'Try
                    '    If (CInt(defaultHolding.Rows(0).Item("UnitPrice") & "") <> 0) Then
                    '        defaultPrice = defaultHolding.Rows(0).Item("UnitPrice") & ""
                    '    End If
                    'Catch
                    'End Try

                    'Dim defaultPrice As String = ""
                    'If Not IsDBNull(defaultHolding.Rows(0).Item("Rate")) Then
                    '    defaultPrice = CInt(defaultHolding.Rows(0).Item("Rate")) * CInt(defaultHolding.Rows(0).Item("UnitPrice"))
                    'Else
                    '    defaultPrice = CInt(defaultHolding.Rows(0).Item("UnitPrice"))
                    'End If

                    Dim defaultAdditionalBy As String = ""
                    Try
                        If (defaultHolding.Rows(0).Item("AdditionalBy") & "" <> "") Then
                            defaultAdditionalBy = defaultHolding.Rows(0).Item("AdditionalBy") & ""
                        End If
                    Catch
                    End Try

                    'txtDateChng.Text = String.Format("{0:dd/MM/yyyy}", defaultDate)
                    txtDateChng.Text = String.Format("{0:dd/MM/yyyy}", Date.Now)

                    Try
                        ddlLoanType.SelectedValue = defaultLoanType
                        ddlACQSource.SelectedValue = defaultAcqSource
                    Catch ex As Exception

                    End Try

                    txtPrice.Text = "0"
                    txtAdditionalBy.Text = defaultAdditionalBy

                    If txtPrice.Text <> "" Then
                        txtPrice.Text = If(Not (txtPrice.Text = "0"), CDbl(txtPrice.Text).ToString("#,##"), "0")
                    End If
                End If
            End If
        End Sub

        ' Method: BindDataGrid
        ' Purpose: Show data in datagrid
        Public Sub BindDataGrid(Optional ByVal intPage As Integer = 0)
            Dim intItemID As Integer
            Dim tblItem As New DataTable
            Dim row() As DataRow
            If Not Request("CodeCatalog") Is Nothing AndAlso Request("CodeCatalog") <> "" Then
                txtCode.Text = Request("CodeCatalog")
            End If
            txtNumberCopiesStart.Text = "C.1"
            If txtCode.Text <> "" Or Request("ItemID") > 0 Then
                If txtCode.Text <> "" Then
                    objBItem.Code = txtCode.Text.Trim
                    objBItem.ItemID = 0
                    tblItem = objBItem.GetItems
                    If tblItem.Rows.Count > 0 Then
                        intItemID = tblItem.Rows(0).Item("ID")
                    Else
                        intItemID = -1
                    End If
                    tblItem.Clear()
                ElseIf Request("ItemID") > 0 Then
                    intItemID = Request("ItemID")
                Else
                    intItemID = -1
                End If
                txtNumberCopiesStart.Text = IncreaseNumberCopyStart(objBCopyNumber.GetLatestCopyNumberCopy(intItemID))
                tblItem = objBCopyNumber.GetHolding(intItemID)
                lnkCheckAll.NavigateUrl = "javascript:CheckedAllOpt('dtgHoldingInfo', 'chkCopyID', " & tblItem.Rows.Count & ",1)"
                lnkUnCheckAll.NavigateUrl = "javascript:CheckedAllOpt('dtgHoldingInfo', 'chkCopyID', " & tblItem.Rows.Count & ",0)"
                lblSumCopyNumVal.Text = tblItem.Rows.Count

                Dim tableTemp As DataView = tblItem.DefaultView()
                tableTemp.Sort = "Acquired ASC, CopyNumber ASC "
                Dim resultTable As DataTable = tableTemp.ToTable()

                row = resultTable.Select("InUsed=0")
                lblSumFreeCopy.Text = row.Length()

                'Dim resultTemp As String = Replace(objBInput.GenerateCompositeHoldings(intItemID, True, True, True, 0, 0, " /") & "", Chr(9), "; ")
                'GenerateCompositeHoldingsOther
                Dim resultTemp As String = Replace(objBInput.GenerateCompositeHoldingsOther(intItemID, True, True, True, 0, 0, " /") & "", Chr(9), "; ")
                Dim stringDataTemp As String = String.Empty

                If Not resultTemp = Nothing Then
                    Dim splitTemp() As String = resultTemp.Split("<br>")
                    For Each stringTemp As String In splitTemp
                        stringDataTemp = stringDataTemp & "- " & stringTemp.Replace("br>", "") & "<br>"
                    Next
                End If


                'lblCopyDataVal.Text = Replace(objBInput.GenerateCompositeHoldings(intItemID, True, True, True, 0, 0, " /") & "", Chr(9), "; ")
                lblCopyDataVal.Text = stringDataTemp

                If tblItem.Rows.Count > 0 Then
                    lblSumCopyNum.Visible = True
                    lblCopyData.Visible = True
                    lblFreeCopy.Visible = True
                    lblSumFreeCopy.Visible = True
                    lblCopyDataVal.Visible = True
                    lblSumCopyNumVal.Visible = True
                    dtgHoldingInfo.Visible = True
                    lblReasonDel.Visible = True
                    ddlReasonDel.Visible = True
                    btnDelHoding.Visible = True
                    lnkCheckAll.Visible = True
                    lnkUnCheckAll.Visible = True
                    imgLock.Visible = True
                    imgProcess.Visible = True
                    imgLoan.Visible = True
                    lblLock.Visible = True
                    lblLoan.Visible = True
                    lblProcess.Visible = True
                    btnBarCode.Visible = True
                    btnLabel.Visible = True
                    chkAllinLoc.Visible = True
                    btnReceiveUnlock.Visible = True
                    btnReceiveDelivered.Visible = False 'True
                Else
                    chkAllinLoc.Visible = False
                    lblSumCopyNum.Visible = False
                    lblCopyData.Visible = False
                    lblFreeCopy.Visible = False
                    lblSumFreeCopy.Visible = False
                    lblCopyDataVal.Visible = False
                    lblSumCopyNumVal.Visible = False
                    dtgHoldingInfo.Visible = False
                    lblReasonDel.Visible = False
                    ddlReasonDel.Visible = False
                    btnDelHoding.Visible = False
                    lnkCheckAll.Visible = False
                    lnkUnCheckAll.Visible = False
                    imgLock.Visible = False
                    imgProcess.Visible = False
                    imgLoan.Visible = False
                    lblLock.Visible = False
                    lblLoan.Visible = False
                    lblProcess.Visible = False
                    btnBarCode.Visible = False
                    btnLabel.Visible = False
                    btnReceiveUnlock.Visible = False
                    btnReceiveDelivered.Visible = False
                End If
                Dim intCount As Integer
                intCount = Math.Ceiling(tblItem.Rows.Count / dtgHoldingInfo.PageSize)
                If intCount > 0 Then
                    If dtgHoldingInfo.CurrentPageIndex >= intCount Then
                        dtgHoldingInfo.CurrentPageIndex = dtgHoldingInfo.CurrentPageIndex - 1
                    Else
                        dtgHoldingInfo.CurrentPageIndex = intPage
                    End If
                End If
                For index As Integer = 0 To tblItem.Rows.Count - 1
                    Dim valueCallNumber As String = tblItem.Rows(index).Item("CallNumber").ToString()
                    If (valueCallNumber = Nothing) Or (valueCallNumber = "") Then
                        Dim tempValueCallNumber As String = objBInput.GetContentFieldCode("082", intItemID)
                        If (tempValueCallNumber <> "") Then
                            If tempValueCallNumber.Contains("$a") Then
                                Dim split() As String = tempValueCallNumber.Split("$")
                                For Each iSplit As String In split
                                    If Not String.IsNullOrEmpty(iSplit) AndAlso iSplit(0) = "a" Then
                                        tblItem.Rows(index).Item("CallNumber") = iSplit.Substring(1).Trim()
                                        Exit For
                                    End If
                                Next
                            End If
                        End If
                    End If
                Next

                dtgHoldingInfo.DataSource = tblItem
                dtgHoldingInfo.DataBind()

                If intItemID <> 0 Then
                    Dim getHolding As DataTable = objBInput.GetHoldingByItemId(intItemID)
                    If (getHolding.Rows.Count <> 0) Then
                        txtDateChng.Text = String.Format("{0:dd/MM/yyyy}", getHolding.Rows(0).Item("AcquiredDate"))
                        If getHolding.Rows(0).Item("LoanTypeID") & "" <> "" Then
                            ddlLoanType.SelectedValue = getHolding.Rows(0).Item("LoanTypeID")
                        End If
                        If getHolding.Rows(0).Item("AcquiredSourceID") & "" <> "" Then
                            ddlACQSource.SelectedValue = getHolding.Rows(0).Item("AcquiredSourceID")
                        End If
                        txtPrice.Text = getHolding.Rows(0).Item("Price") & ""
                        If txtPrice.Text <> "" Then
                            txtPrice.Text = If(Not (txtPrice.Text = "0"), CDbl(txtPrice.Text).ToString("#,##"), "0")
                        End If
                    End If
                End If
            Else
                chkAllinLoc.Visible = False
                lblSumCopyNum.Visible = False
                lblCopyData.Visible = False
                lblFreeCopy.Visible = False
                lblSumFreeCopy.Visible = False
                lblCopyDataVal.Visible = False
                lblSumCopyNumVal.Visible = False
                dtgHoldingInfo.Visible = False
                lblReasonDel.Visible = False
                ddlReasonDel.Visible = False
                btnDelHoding.Visible = False
                lnkCheckAll.Visible = False
                lnkUnCheckAll.Visible = False
                imgLock.Visible = False
                imgProcess.Visible = False
                imgLoan.Visible = False
                lblLock.Visible = False
                lblLoan.Visible = False
                lblProcess.Visible = False
                btnBarCode.Visible = False
                btnLabel.Visible = False
            End If
            If Session("HoldingsInCatalogNew") = 0 Then
                'lblReasonDel.Visible = False
                'ddlReasonDel.Visible = False
                'btnDelHoding.Visible = False
            End If

            'Load default data
            LoadDefault()
        End Sub

        ' Method: BindJS
        Public Sub BindJS()
            Dim strJS As String
            Dim tblLoc As New DataTable
            Dim inti As Integer

            ClientScript.RegisterClientScriptBlock(Me.GetType(), "CommonJs", "<script type = 'text/javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>", False)
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "selfJs", "<script type = 'text/javascript' src = '../js/Catalogue/WCopyNumber.js?t=" & String.Format("{0:yyyyMMddHHmmss}", Date.Now) & "'></script>", False)

            ddlLibrary.Attributes.Add("onChange", "FilterLocation('ddlLocation');")
            ddlLocation.Attributes.Add("onChange", "SetHidVal();document.forms[0].txtHolding.focus();")

            btnGenHolding.Attributes.Add("onClick", "return GenHolding();")

            btnUpdate.Attributes.Add("onClick", "return ActionUpdate('" & ddlLabel.Items(4).Text & "'); CheckNumberCopies('" & ddlLabel.Items(11).Text & "');")
            btnBarCode.Attributes.Add("onClick", "return OpenBarCode();")
            btnLabel.Attributes.Add("onClick", "return OpenLabel();")

            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkCalendar, txtDateChng, ddlLabel.Items(3).Text)

            txtCode.Attributes.Add("onChange", "ChangeCode();")
            Me.SetCheckNumberCurrency(txtPrice, ddlLabel.Items(2).Text)
            Me.SetCheckNumber(txtQuantity, ddlLabel.Items(2).Text, "1")

            If IsNumeric(ddlLibrary.SelectedValue) Then
                objBLoc.LibID = CInt(ddlLibrary.SelectedValue)
                objBLoc.UserID = Session("UserID")

                Dim tblTemp As DataTable

                tblTemp = objBLoc.GetLocation
                ddlLocation.DataSource = tblTemp
                ddlLocation.DataTextField = "CodeSymbol"
                ddlLocation.DataValueField = "ID"
                ddlLocation.DataBind()
                txtLocID.Value = ddlLocation.SelectedValue
                If Request.Form("ddlLocation") <> "" Then
                    For inti = 0 To ddlLocation.Items.Count - 1
                        If CStr(ddlLocation.Items(inti).Value & "") = CStr(Request.Form("ddlLocation") & "") Then
                            ddlLocation.Items(inti).Selected = True
                            txtLocID.Value = ddlLocation.Items(inti).Value
                        Else
                            ddlLocation.Items(inti).Selected = False
                        End If
                    Next
                End If
            End If
            objBLoc.LibID = 0 'MKU 20220829
            objBLoc.UserID = Session("UserID")
            tblLoc = objBLoc.GetLocation1
            If Not tblLoc Is Nothing AndAlso tblLoc.Rows.Count > 0 Then
                strJS = "LibID = new Array(" & tblLoc.Rows.Count - 1 & ");"
                strJS = strJS & "LocID = new Array(" & tblLoc.Rows.Count - 1 & ");"
                strJS = strJS & "Location = new Array(" & tblLoc.Rows.Count - 1 & ");"
                For inti = 0 To tblLoc.Rows.Count - 1
                    strJS = strJS & "LibID[" & inti & "] = " & tblLoc.Rows(inti).Item("LibID") & ";"
                    strJS = strJS & "LocID[" & inti & "] = " & tblLoc.Rows(inti).Item("ID") & ";"
                    strJS = strJS & "Location[" & inti & "] = """ & tblLoc.Rows(inti).Item("CodeSymbol") & """;"
                Next
                Page.RegisterClientScriptBlock("GenJs", "<script language = 'javascript'>" & strJS & "</script>")
            End If
        End Sub

        Private Function IncreaseNumberCopyStart(ByVal number As String) As String
            If number Is Nothing Then
                Return "C.1"
            End If
            Dim intNumber = number.Trim()
            If intNumber = "" Then
                Return "C.1"
            End If

            Dim size = 2
            Dim length = Len(intNumber)
            If size > length Then
                size = 1
            End If
            Dim low = length - size
            Dim high = length - 1
            Dim sb As New StringBuilder(32)
            For j As Integer = low To high
                If intNumber(j) >= "0" AndAlso intNumber(j) <= "9" Then
                    sb.Append(intNumber(j))
                Else
                    If low < high Then
                        low += 1
                    Else
                        Exit For
                    End If
                End If
            Next
            Dim startNumber = CInt(sb.ToString())
            Dim iNumber As String = CStr(startNumber + 1)
            Dim prev = intNumber.Substring(0, low)
            Return (prev + iNumber.PadLeft(size, "")).Replace(Convert.ToChar(0), "")
        End Function

        Private Function GenNumberCopyStart(ByVal intRange As Integer) As List(Of String)
            Dim listNumber As New List(Of String)

            'Begin algorithm
            Dim intNumber = txtNumberCopiesStart.Text.Trim()
            Dim size = Len(CStr(intRange)) + 1
            Dim length = Len(intNumber)
            Dim low = length - size
            Dim high = length - 1
            Dim sb As New StringBuilder(32)
            For j As Integer = low To high
                If intNumber(j) >= "0" AndAlso intNumber(j) <= "9" Then
                    sb.Append(intNumber(j))
                Else
                    If low < high Then
                        low += 1
                    Else
                        Exit For
                    End If
                End If
            Next
            If sb.Length > 0 Then
                Dim startNumber = CInt(sb.ToString())
                For i As Integer = 0 To intRange - 1
                    Dim prev = intNumber.Substring(0, low)
                    Dim number As String = CStr(startNumber + i)
                    listNumber.Add(prev & number.PadLeft(size, ""))
                Next
            Else
                For i As Integer = 0 To intRange - 1
                    Dim startNumber = 0
                    startNumber += i
                    If startNumber = 0 Then
                        listNumber.Add(intNumber)
                    Else
                        listNumber.Add(intNumber & startNumber)
                    End If
                Next
            End If
            Return listNumber
        End Function

        ' Event: btnUpdate_Click
        ' Purpose: Create copynumbers
        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            objBCopyNumber.Code = txtCode.Text
            objBCopyNumber.HolLibID = CInt(ddlLibrary.SelectedValue)
            objBCopyNumber.LoanTypeID = CInt(ddlLoanType.SelectedValue)
            objBCopyNumber.StartHolding = txtHolding.Text
            Dim intRange = 0
            If txtQuantity.Text.Trim <> "" Then
                objBCopyNumber.Range = txtQuantity.Text.Trim
                intRange = CInt(txtQuantity.Text.Trim)
            End If

            'If txtCodePO.Text.Trim <> "" Then
            '    If IsNumeric(txtCodePO.Text) Then
            '        objBCopyNumber.POID = CInt(txtCodePO.Text.Trim)
            '    End If
            'End If
            objBCopyNumber.LocID = CInt(txtLocID.Value)
            objBCopyNumber.ChangeDate = txtDateChng.Text
            If txtPrice.Text.Trim <> "" Then
                objBCopyNumber.Price = CDbl(txtPrice.Text.Trim.Replace(".", ""))
            Else
            End If
            objBCopyNumber.Shelf = txtShelf.Text
            objBCopyNumber.AcqSourceID = CInt(ddlACQSource.SelectedValue)

            ' Add Holding
            Dim bytErrAddHold As Byte
            'bytErrAddHold = objBCopyNumber.Create(1, 1)
            ' Add Holding
            objBCopyNumber.UserID = CInt(Session("UserID"))
            objBCopyNumber.LibID = clsSession.GlbSite
            Dim currentHolding = objBCopyNumber.GenCopyNumber()
            Dim tblTemp As New DataTable
            ' Retrieve holdingtemplate
            objBTemplate.LibID = clsSession.GlbSite
            tblTemp = objBTemplate.GetHoldingTemplate()
            Dim listStartHolding = New List(Of String)

            'sub number in coppynumber
            Dim sublenght = 0

            'lenght of copy number

            Dim lenght = 0

            'StartPosition of copy number
            Dim startPoisition = 0

            'endPoisition of copy number
            Dim endPoisition = 0
            If currentHolding <> txtHolding.Text.Trim() Then
                'Tự do nhập đăng kí cá biệt
                If cbFreeText.Checked Then
                    Try
                        'Get Last Len Number Corrsponding to Range
                        'What if that length not enough
                        Dim inpHolding = txtHolding.Text.Trim()
                        Dim size = Len(CStr(intRange)) + 1
                        Dim length = Len(inpHolding)
                        Dim low = length - size
                        Dim high = length - 1
                        Dim sb As New StringBuilder(32)
                        For j As Integer = low To high
                            If inpHolding(j) >= "0" AndAlso inpHolding(j) <= "9" Then
                                sb.Append(inpHolding(j))
                            Else
                                If low < high Then
                                    low += 1
                                Else
                                    Exit For
                                End If
                            End If
                        Next
                        If sb.Length > 0 Then
                            Dim startNumber = CInt(sb.ToString())
                            For i As Integer = 0 To intRange - 1
                                Dim prevStartHolding = inpHolding.Substring(0, low)
                                Dim number As String = CStr(startNumber + i)
                                listStartHolding.Add(prevStartHolding & number.PadLeft(size, "0"))
                            Next
                        Else
                            For i As Integer = 0 To intRange - 1
                                Dim startNumber = 0
                                startNumber += i
                                If startNumber = 0 Then
                                    listStartHolding.Add(inpHolding)
                                Else
                                    listStartHolding.Add(inpHolding & startNumber)
                                End If
                            Next
                        End If
                    Catch ex As Exception
                        Dim strJS = "alert('Đăng ký cá biệt không hợp lệ')"
                        Page.RegisterClientScriptBlock("MessageJS", "<script language = 'javascript'>" & strJS & "</script>")
                        Return
                    End Try
                Else 'Nhập theo template có sẵn
                    'sub number in coppynumber
                    If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                        If tblTemp.Rows(0).Item("Enable") = True Then
                            For i As Integer = 0 To intRange - 1
                                If Not tblTemp Is Nothing Then
                                    Try
                                        'sub number in coppynumber
                                        sublenght = tblTemp.Rows(0).Item("EndPosition") - tblTemp.Rows(0).Item("StartPosition") + 1

                                        'lenght of copy number
                                        lenght = tblTemp.Rows(0).Item("Lenght")

                                        'StartPosition of copy number
                                        startPoisition = tblTemp.Rows(0).Item("StartPosition")

                                        'StartPosition of copy number
                                        endPoisition = tblTemp.Rows(0).Item("EndPosition")

                                        'input txt holding 
                                        Dim inpHolding = txtHolding.Text.Trim()
                                        If inpHolding.Length <> lenght Or endPoisition > lenght Or startPoisition <= 0 Then
                                            Dim strJS = "alert('Đăng ký cá biệt không hợp lệ')"
                                            Page.RegisterClientScriptBlock("MessageJS", "<script language = 'javascript'>" & strJS & "</script>")
                                            Return
                                        End If

                                        Dim startNumber = Integer.Parse(inpHolding.Substring(startPoisition, sublenght))
                                        startNumber += i

                                        Dim prevStartHolding = inpHolding.Substring(0, startPoisition)
                                        Dim sufstartHolding = inpHolding.Substring(endPoisition + 1, lenght - endPoisition - 1)

                                        listStartHolding.Add(prevStartHolding & CStr(startNumber).PadLeft(sublenght, "0") & sufstartHolding)

                                    Catch ex As Exception
                                        Dim strJS = "alert('Đăng ký cá biệt không hợp lệ')"
                                        Page.RegisterClientScriptBlock("MessageJS", "<script language = 'javascript'>" & strJS & "</script>")
                                        Return
                                    End Try
                                End If
                            Next
                        End If
                    End If
                    Dim strCopyNumber = String.Join(",", listStartHolding)
                    If listStartHolding.Count() > 0 Then
                        For Each item As String In listStartHolding
                            objBCopyNumber.LibID = clsSession.GlbSite
                            Dim strJS = "alert('" & ddlLabel.Items(5).Text & "')"
                            Dim checkExitCopyNumberByHand = objBCopyNumber.CheckExitByCopyNumber(item, startPoisition, endPoisition)
                            If checkExitCopyNumberByHand Then
                                Page.RegisterClientScriptBlock("MessageJS", "<script language = 'javascript'>" & strJS & "</script>")
                                Return
                            End If
                        Next
                    End If
                End If
            End If

            Dim strNumberCopiesStart As String = txtNumberCopiesStart.Text

            'Dim intNumberCopiesStart As Integer = 1
            'If Not String.IsNullOrEmpty(strNumberCopiesStart) Then
            '    intNumberCopiesStart = CType(strNumberCopiesStart.Substring(2), Integer)
            'End If

            Dim lstNum As List(Of String) = GenNumberCopyStart(intRange)
            For i As Integer = 0 To intRange - 1
                objBCopyNumber.UserID = CInt(Session("UserID"))
                objBCopyNumber.LibID = clsSession.GlbSite
                If currentHolding <> txtHolding.Text.Trim() Then
                    If Not tblTemp Is Nothing Then
                        If listStartHolding.Count > 0 Then
                            objBCopyNumber.StartHolding = listStartHolding(i)
                            objBCopyNumber.BarCode = objBCopyNumber.StartHolding
                            'objBCopyNumber.NumberCopies = strNumberCopiesStart.Substring(0, 2) & intNumberCopiesStart 'strNumberCopiesStart
                            objBCopyNumber.NumberCopies = lstNum(i)
                        Else
                            If i = 0 Then
                                objBCopyNumber.StartHolding = txtHolding.Text.Trim()
                                objBCopyNumber.BarCode = objBCopyNumber.StartHolding
                                'objBCopyNumber.NumberCopies = strNumberCopiesStart.Substring(0, 2) & intNumberCopiesStart 'strNumberCopiesStart
                                objBCopyNumber.NumberCopies = lstNum(i)
                            Else
                                objBCopyNumber.StartHolding = txtHolding.Text.Trim() & (i).ToString()
                                objBCopyNumber.BarCode = objBCopyNumber.StartHolding
                                'objBCopyNumber.NumberCopies = strNumberCopiesStart.Substring(0, 2) & intNumberCopiesStart 'strNumberCopiesStart
                                objBCopyNumber.NumberCopies = lstNum(i)
                            End If
                        End If
                        'intNumberCopiesStart = intNumberCopiesStart + 1
                    End If
                Else
                    objBCopyNumber.StartHolding = objBCopyNumber.GenCopyNumber()
                    objBCopyNumber.BarCode = objBCopyNumber.StartHolding
                    'objBCopyNumber.NumberCopies = strNumberCopiesStart.Substring(0, 2) & intNumberCopiesStart 'strNumberCopiesStart
                    objBCopyNumber.NumberCopies = lstNum(i)
                    'intNumberCopiesStart = intNumberCopiesStart + 1
                End If
                objBCopyNumber.StatusCode = ddlStatus.SelectedItem.Value
                objBCopyNumber.StatusNode = ddlStatus.SelectedItem.Text
                objBCopyNumber.AdditionalBy = txtAdditionalBy.Text
                bytErrAddHold = objBCopyNumber.Create()
                If bytErrAddHold = 2 Then
                    Exit For
                End If
            Next

            ' Writelog
            Call WriteLog(39, ddlLabel.Items(8).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

            If bytErrAddHold <> 0 Then
                Dim strJS = ""
                If bytErrAddHold = 1 Then
                    strJS = "alert('" & ddlLabel.Items(6).Text & "')"
                End If
                If bytErrAddHold = 2 Then
                    strJS = "alert('" & ddlLabel.Items(5).Text & "')"
                End If
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "MessageJS", strJS, True)
            End If
            Call BindDataGrid(dtgHoldingInfo.CurrentPageIndex)

        End Sub

        ' RetrieveLibrary method
        ' Purpose: Retrieve libraries
        ' Input: boolean value of IsSelectAll, true if selelect all data of HOLDING_LIBRARY table
        ' Output: datatable of libraries' information
        Private Function RetrieveLibrary(ByVal IsSelectAll As Boolean) As DataTable
            If Not txtLibID.Value = "" And Not IsSelectAll Then
                objBLib.LibID = CInt(txtLibID.Value)
            End If
            RetrieveLibrary = objBLib.GetLibrary
        End Function

        ' RetrieveLocation
        ' Purpose: retrieve locations
        ' Input: two integer value of LibraryID and LocationID
        ' Output: datatable of locations' information
        Private Function RetrieveLocation(ByVal intLibID As Integer, ByVal intLocID As Integer) As DataTable
            Dim intUserID As Integer = 0
            If IsNumeric(Session("UserID")) Then
                intUserID = CInt(Session("UserID"))
            End If
            objBLoc.LibID = intLibID
            objBLoc.UserID = intUserID
            RetrieveLocation = objBLoc.GetLocation
        End Function

        ' Event: dtgHoldingInfo_ItemDataBound
        Public Sub dtgHoldingInfo_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgHoldingInfo.ItemDataBound
            If e.Item.ItemType = ListItemType.EditItem Then
                ' Declare variables
                Dim intCount As Integer
                Dim intLibID As Integer
                Dim intSelectedLocID As Integer
                Dim intAcqSourceID As Integer
                Dim ddlLib As DropDownList
                Dim tblLibrary As New DataTable
                Dim intSelectedLibID As Integer
                Dim ddlLocationTemp As New DropDownList
                Dim ddlLibraryTemp As New DropDownList
                Dim ddlAcqTemp As New DropDownList
                Dim tblLocation As New DataTable
                Dim tblAcq As New DataTable

                ' Get all libraries
                tblLibrary = RetrieveLibrary(True)

                ' Bind library dropdown list
                intSelectedLibID = CInt(CType(e.Item.FindControl("txtSelectLibID"), TextBox).Text)
                intSelectedLocID = CInt(CType(e.Item.FindControl("txtSelectLocID"), TextBox).Text)
                intAcqSourceID = CInt(CType(e.Item.FindControl("txtAcqSourceID"), TextBox).Text)
                ddlLib = CType(e.Item.FindControl("ddlSelectLibrary"), DropDownList)
                ddlLib.DataTextField = "Code"
                ddlLib.DataValueField = "ID"
                ddlLib.DataSource = tblLibrary
                ddlLib.DataBind()

                For intCount = 0 To tblLibrary.Rows.Count - 1
                    If tblLibrary.Rows(intCount).Item("ID") = intSelectedLibID Then
                        ddlLib.SelectedIndex = intCount
                    End If
                Next

                ' Bind location dropdownlist when the library dropdownlist is selected
                tblLocation = RetrieveLocation(intSelectedLibID, intSelectedLocID)
                ddlLocationTemp = CType(e.Item.FindControl("ddlSelectLocation"), DropDownList)
                ddlLocationTemp.DataSource = tblLocation
                ddlLocationTemp.DataBind()
                For intCount = 0 To tblLocation.Rows.Count - 1
                    If tblLocation.Rows(intCount).Item("ID") = intSelectedLocID Then
                        ddlLocationTemp.SelectedIndex = intCount
                    End If
                Next

                ' Get acquiry source
                tblAcq = objBCB.GetAcqSources
                ddlAcqTemp = CType(e.Item.FindControl("ddlAcqSourceID"), DropDownList)
                ddlAcqTemp.DataSource = tblAcq
                ddlAcqTemp.DataBind()

                For intCount = 0 To tblAcq.Rows.Count - 1
                    If tblAcq.Rows(intCount).Item("ID") = intAcqSourceID Then
                        ddlAcqTemp.SelectedIndex = intCount
                    End If
                Next
            End If
            If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
                'If the first column is a date
                Dim lblPriceDa As Label = e.Item.FindControl("lblPriceDa")
                'lblPriceDa.Text = formatCurrency(lblPriceDa.Text)
                If lblPriceDa.Text <> "" Then
                    lblPriceDa.Text = If(Not (lblPriceDa.Text = "0"), CDbl(lblPriceDa.Text).ToString("#,##"), "0")
                End If
                'Dim txtPriceDa = CType(e.Item.FindControl("txtPriceDa"), TextBox)


            End If
            If e.Item.ItemType = ListItemType.EditItem Then
                Dim txtPriceDa = CType(e.Item.FindControl("txtPriceDa"), TextBox)
                'txtPriceDa.Text = formatCurrency(txtPriceDa.Text)
                If txtPriceDa.Text = "" Then
                    txtPriceDa.Text = "0"
                End If
                txtPriceDa.Text = If(Not (txtPriceDa.Text = "0"), CDbl(txtPriceDa.Text).ToString("#,##"), "0")
            End If
        End Sub

        ' Event: dtgHoldingInfo_UpdateCommand
        Public Sub dtgHoldingInfo_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgHoldingInfo.UpdateCommand
            ' Declare variables
            Dim lngCopyID As Long
            Dim intLibID As Integer
            Dim intLocationID As Integer
            Dim strShelf As String
            Dim strCallNumber As String
            Dim strCopyNumber As String
            Dim strVolume As String
            Dim strNote As String
            Dim dblPrice As Double
            Dim strAcqDate As String
            Dim intAcqSourceID As Integer
            Dim objtmp As Object
            Dim strBarCode As String
            Dim strNumberCopies As String
            Dim strStatusCode As String
            Dim strStatusNode As String
            Dim strAdditionalBy As String

            Dim strJS As String
            Dim objLabel As New Label
            Dim strMark As String = ""

            objLabel = CType(dtgHoldingInfo.Items.Item(dtgHoldingInfo.EditItemIndex).FindControl("lblMark"), Label)
            strMark = Replace(objLabel.Text, "<a name=""", "")
            strMark = Replace(strMark, """>", "")
            strJS = "<script language='JavaScript'>"
            strJS = strJS & "self.location.href='#" & strMark & "';"
            strJS = strJS & "</script>"
            Page.RegisterClientScriptBlock("Bookmark2", strJS)

            ' get value of all control
            lngCopyID = CLng(CType(e.Item.Cells(1).FindControl("lblCopyID"), Label).Text)
            intLibID = CInt(CType(e.Item.Cells(3).FindControl("ddlSelectLibrary"), DropDownList).SelectedValue)
            objtmp = CType(e.Item.Cells(4).FindControl("ddlSelectLocation"), DropDownList).SelectedValue
            If IsNumeric(objtmp) Then
                intLocationID = CInt(objtmp)
            Else
                intLocationID = 0
            End If

            strShelf = CType(e.Item.Cells(5).FindControl("txtShelfDa"), TextBox).Text
            strVolume = CType(e.Item.Cells(6).FindControl("txtVolume"), TextBox).Text
            strCallNumber = CType(e.Item.Cells(7).FindControl("txtCallNumber"), TextBox).Text
            If CType(e.Item.Cells(9).FindControl("txtPriceDa"), TextBox).Text <> "" Then
                dblPrice = CDbl(CType(e.Item.Cells(9).FindControl("txtPriceDa"), TextBox).Text.Replace(",", "").Replace(".", ""))
            Else
                dblPrice = 0
            End If
            strAcqDate = CType(e.Item.Cells(10).FindControl("txtAcquiredDate"), TextBox).Text
            intAcqSourceID = CInt(CType(e.Item.Cells(11).FindControl("ddlAcqSourceID"), DropDownList).SelectedValue)
            strNote = CType(e.Item.Cells(12).FindControl("txtNote"), TextBox).Text
            strCopyNumber = CType(e.Item.Cells(8).FindControl("txtCopyNumber"), TextBox).Text
            strBarCode = CType(e.Item.Cells(13).FindControl("txtBarCode"), TextBox).Text
            strNumberCopies = CType(e.Item.Cells(14).FindControl("txtNumberCopies"), TextBox).Text
            strStatusCode = CType(e.Item.Cells(16).FindControl("ddlStatusNote"), DropDownList).SelectedItem.Value
            strStatusNode = CType(e.Item.Cells(16).FindControl("ddlStatusNote"), DropDownList).SelectedItem.Text
            strAdditionalBy = CType(e.Item.Cells(17).FindControl("txtAdditionalBy"), TextBox).Text


            If objBCopyNumber.IsExistHolding(strCopyNumber, intLocationID, clsSession.GlbSite, lngCopyID) Then
                ' Alert Existing !
                strJS = "<script language='JavaScript'>"
                strJS = strJS & "alert('" & ddlLabel.Items(5).Text & "')"
                strJS = strJS & "</script>"
                Page.RegisterClientScriptBlock("msgAlert", strJS)
            Else
                If chkAllinLoc.Checked = True Then
                    ' Set value of objBHolding' properties
                    objBCopyNumber.CopyID = 0
                    objBCopyNumber.LibID = intLibID
                    objBCopyNumber.LocID = intLocationID
                    objBCopyNumber.Shelf = strShelf
                    objBCopyNumber.Volume = ""
                    objBCopyNumber.CallNumber = strCallNumber
                    objBCopyNumber.Price = 0
                    objBCopyNumber.AcquiredDate = ""
                    objBCopyNumber.AcqSourceID = 0
                    objBCopyNumber.Note = ""
                    objBCopyNumber.CopyNumber = ""
                    objBCopyNumber.BarCode = strBarCode
                    objBCopyNumber.NumberCopies = strNumberCopies
                    objBCopyNumber.StatusCode = strStatusCode
                    objBCopyNumber.StatusNode = strStatusNode
                    objBCopyNumber.AdditionalBy = strAdditionalBy
                    ' Update
                    Call objBCopyNumber.Update()
                    ' Writelog
                    Call WriteLog(39, ddlLabel.Items(6).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                Else
                    ' Set value of objBHolding' properties
                    objBCopyNumber.CopyID = lngCopyID
                    objBCopyNumber.LibID = intLibID
                    objBCopyNumber.LocID = intLocationID
                    objBCopyNumber.Shelf = strShelf
                    objBCopyNumber.Volume = strVolume
                    objBCopyNumber.CallNumber = strCallNumber
                    objBCopyNumber.Price = dblPrice
                    objBCopyNumber.AcquiredDate = strAcqDate
                    objBCopyNumber.AcqSourceID = intAcqSourceID
                    objBCopyNumber.Note = strNote
                    objBCopyNumber.CopyNumber = strCopyNumber
                    objBCopyNumber.BarCode = strBarCode
                    objBCopyNumber.NumberCopies = strNumberCopies
                    objBCopyNumber.StatusCode = strStatusCode
                    objBCopyNumber.StatusNode = strStatusNode
                    objBCopyNumber.AdditionalBy = strAdditionalBy
                    ' Update
                    Call objBCopyNumber.Update()
                    ' Writelog
                    Call WriteLog(39, ddlLabel.Items(6).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                End If
            End If

            dtgHoldingInfo.EditItemIndex = -1
            objBCopyNumber.CopyIDs = lngCopyID
            objBCopyNumber.UpdateStatus(DirectCast(dtgHoldingInfo.Items.Item(e.Item.ItemIndex).FindControl("ddlStatusNote"), DropDownList).SelectedValue, DirectCast(dtgHoldingInfo.Items.Item(e.Item.ItemIndex).FindControl("ddlLoanTypeCurrent"), DropDownList).SelectedValue)
            Call BindDataGrid(dtgHoldingInfo.CurrentPageIndex)
        End Sub

        ' Event: dtgHoldingInfo_CancelCommand
        Public Sub dtgHoldingInfo_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgHoldingInfo.CancelCommand
            Try
                dtgHoldingInfo.EditItemIndex = -1
                Call BindDataGrid(dtgHoldingInfo.CurrentPageIndex)
            Catch ex As Exception
            End Try
        End Sub

        ' Event: dtgHoldingInfo_EditCommand
        Public Sub dtgHoldingInfo_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgHoldingInfo.EditCommand
            Dim lnkCal As New HyperLink
            Dim intIndex As Integer
            intIndex = CInt(e.Item.ItemIndex)
            dtgHoldingInfo.EditItemIndex = intIndex
            Call BindDataGrid(dtgHoldingInfo.CurrentPageIndex)
            lnkCal = CType(dtgHoldingInfo.Items.Item(intIndex).FindControl("lnkCal"), HyperLink)
            lnkCal.NavigateUrl = "javascript:ShowCalendar(" & intIndex & ")"

            Dim ddlStatus As DropDownList = DirectCast(dtgHoldingInfo.Items.Item(intIndex).FindControl("ddlStatusNote"), DropDownList)
            Dim ddlLoanTypeCurrent As DropDownList = DirectCast(dtgHoldingInfo.Items.Item(intIndex).FindControl("ddlLoanTypeCurrent"), DropDownList)
            Dim HiddenFieldStatusCode As HiddenField = DirectCast(dtgHoldingInfo.Items.Item(intIndex).FindControl("HiddenFieldStatusCode"), HiddenField)
            Dim HiddenFieldLoanTypeID As HiddenField = DirectCast(dtgHoldingInfo.Items.Item(intIndex).FindControl("HiddenFieldLoanTypeID"), HiddenField)
            ddlStatus.DataSource = objBCopyNumber.GetStatus
            ddlStatus.DataTextField = "StatusNote"
            ddlStatus.DataValueField = "StatusCode"
            ddlStatus.DataBind()
            ddlStatus.SelectedValue = HiddenFieldStatusCode.Value
            objBLoanType.LibID = clsSession.GlbSite
            Dim tblTemp As DataTable = objBLoanType.GetLoanTypes
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlLoanTypeCurrent.DataSource = tblTemp
                ddlLoanTypeCurrent.DataTextField = "LoanType"
                ddlLoanTypeCurrent.DataValueField = "ID"
                ddlLoanTypeCurrent.DataBind()
                tblTemp.Clear()
            End If
            ddlLoanTypeCurrent.SelectedValue = HiddenFieldLoanTypeID.Value
        End Sub

        ' PopulateLocationDropDownList method
        ' Purpose: create location dropdownlist when library dropdown list is selected
        Public Sub PopulateLocationDropDownList(ByVal sender As Object, ByVal e As System.EventArgs)
            ' Declare variables
            Dim intSelectedLibID As Integer
            Dim ddlLocationTemp As New DropDownList
            Dim ddlLibraryTemp As New DropDownList
            Dim tblLocation As New DataTable

            Dim strJS As String
            Dim objLabel As New Label
            Dim strMark As String = ""

            objLabel = CType(dtgHoldingInfo.Items.Item(dtgHoldingInfo.EditItemIndex).FindControl("lblMark"), Label)
            strMark = Replace(objLabel.Text, "<a name=""", "")
            strMark = Replace(strMark, """>", "")
            strJS = "<script type='text/JavaScript'>"
            strJS = strJS & "self.location.href='#" & strMark & "';"
            strJS = strJS & "</script>"
            Page.RegisterClientScriptBlock("Bookmark1", strJS)

            ' Get ID of the selected library
            ddlLibraryTemp = CType(dtgHoldingInfo.Items.Item(dtgHoldingInfo.EditItemIndex).FindControl("ddlSelectLibrary"), DropDownList)
            intSelectedLibID = ddlLibraryTemp.SelectedValue

            ' Bind location dropdownlist where library dropdownlist is selected
            tblLocation = RetrieveLocation(intSelectedLibID, 0)
            ddlLocationTemp = CType(dtgHoldingInfo.Items.Item(dtgHoldingInfo.EditItemIndex).FindControl("ddlSelectLocation"), DropDownList)
            ddlLocationTemp.DataSource = tblLocation
            ddlLocationTemp.DataBind()
            ddlLocationTemp.SelectedIndex = ddlLocationTemp.Items.IndexOf(ddlLocationTemp.Items.FindByValue(txtLocIDdgr.Value))
            If ddlLibraryTemp.Enabled Then
                ddlLocationTemp.Enabled = True
            End If

            ' Release all objects
            ddlLibraryTemp.Dispose()
            ddlLibraryTemp = Nothing
            ddlLocationTemp.Dispose()
            ddlLocationTemp = Nothing
        End Sub

        ' Event: btnDelHoding_Click
        ' Purpose: remove selected copynumbers
        Private Sub btnDelHoding_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelHoding.Click
            Dim dtgItem As DataGridItem
            Dim chkSelected As HtmlInputCheckBox
            Dim strCopyIDs As String

            ' Get ID of selected receiving copies
            For Each dtgItem In dtgHoldingInfo.Items
                chkSelected = dtgItem.FindControl("chkCopyID")
                If chkSelected.Checked Then
                    strCopyIDs = strCopyIDs & CType(dtgItem.FindControl("lblCopyID"), Label).Text & ","
                End If
            Next
            If strCopyIDs <> "" Then
                strCopyIDs = Left(strCopyIDs, Len(strCopyIDs) - 1)
            Else
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "ReceivedUnLockSuccess", "alert('Chưa chọn ĐKCB cần xóa');", True)

            End If
            If IsNumeric(ddlReasonDel.SelectedValue) Then
                objBCopyNumber.ReasonID = CInt(ddlReasonDel.SelectedValue)
            Else
                objBCopyNumber.ReasonID = 0
            End If
            objBCopyNumber.CopyIDs = strCopyIDs
            objBCopyNumber.Remove()
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "ReceivedUnLockSuccess", "alert('Xóa thành công');", True)
            ' Writelog
            Call WriteLog(39, ddlLabel.Items(7).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

            Call BindDataGrid(dtgHoldingInfo.CurrentPageIndex)
        End Sub

        Private Sub btnReceiveUnlock_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReceiveUnlock.Click
            Dim dtgItem As DataGridItem
            Dim chkSelected As HtmlInputCheckBox
            Dim strCopyIDs As String

            ' Get ID of selected receiving copies
            For Each dtgItem In dtgHoldingInfo.Items
                chkSelected = dtgItem.FindControl("chkCopyID")
                If chkSelected.Checked Then
                    strCopyIDs = strCopyIDs & CType(dtgItem.FindControl("lblCopyID"), Label).Text & ","
                End If
            Next
            If strCopyIDs <> "" Then
                strCopyIDs = Left(strCopyIDs, Len(strCopyIDs) - 1)
                objBCopyNumber.CopyIDs = strCopyIDs
                'PhuongTT 20080906
                'Neu gia tri hang 0 thi LibID va locID khong can thiet nen bo qua
                'B1
                objBCopyNumber.LibID = 0 'ddlLibrary.SelectedValue
                objBCopyNumber.LocID = 0 'ddlLocation.SelectedValue
                objBCopyNumber.StatusCode = "TT007"
                'E1
                objBCopyNumber.ProcessCopyNumber(3, 0)
                Page.RegisterClientScriptBlock("ReceivedUnLockSuccess", "<script>alert('" & ddlLabel.Items(9).Text & "');</script>")
            Else
                Page.RegisterClientScriptBlock("ReceivedUnLockSuccess", "<script>alert('" & ddlLabel.Items(10).Text & "');</script>")
            End If
            Call BindDataGrid(dtgHoldingInfo.CurrentPageIndex)
        End Sub

        ' Event: dtgHoldingInfo_PageIndexChanged
        Private Sub dtgHoldingInfo_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgHoldingInfo.PageIndexChanged
            Try
                Call BindDataGrid(e.NewPageIndex)
            Catch ex As Exception
            End Try
        End Sub

        ' Event: dtgHoldingInfo_ItemCommand
        Private Sub dtgHoldingInfo_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgHoldingInfo.ItemCommand
            Dim strJS As String
            Dim strCmd As String = ""
            Dim objLabel As New Label
            Dim strMark As String = ""

            strCmd = UCase(e.CommandName)
            If strCmd = "EDIT" Or strCmd = "UPDATE" Or strCmd = "CANCEL" Then
                objLabel = CType(e.Item.Cells(14).FindControl("lblMark"), Label)
                strMark = Replace(objLabel.Text, "<a name=""", "")
                strMark = Replace(strMark, """>", "")
                strJS = "<script language='JavaScript'>"
                strJS = strJS & "self.location.href='#" & strMark & "';"
                strJS = strJS & "</script>"
                Page.RegisterClientScriptBlock("Bookmark", strJS)
            End If
        End Sub


        ' Method: Page_Unload
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: Release all object
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCB Is Nothing Then
                    objBCB.Dispose(True)
                    objBCB = Nothing
                End If
                If Not objBLib Is Nothing Then
                    objBLib.Dispose(True)
                    objBLib = Nothing
                End If
                If Not objBLoc Is Nothing Then
                    objBLoc.Dispose(True)
                    objBLoc = Nothing
                End If
                If Not objBCopyNumber Is Nothing Then
                    objBCopyNumber.Dispose(True)
                    objBCopyNumber = Nothing
                End If
                If Not objBInput Is Nothing Then
                    objBInput.Dispose(True)
                    objBInput = Nothing
                End If
                If Not objBLoanType Is Nothing Then
                    objBLoanType.Dispose(True)
                    objBLoanType = Nothing
                End If
                If Not objBItem Is Nothing Then
                    objBItem.Dispose(True)
                    objBItem = Nothing
                End If
                If Not objBItemCol Is Nothing Then
                    objBItemCol.Dispose(True)
                    objBItemCol = Nothing
                End If
            Finally
                MyBase.Dispose()
                Call Dispose()
            End Try
        End Sub

        Public Function formatCurrency(ByVal str As String) As String
            If str <> "" AndAlso Not str Is Nothing Then
                Return Double.Parse(str).ToString("N0", CultureInfo.InvariantCulture)
            Else
                Return 0.ToString("N0", CultureInfo.InvariantCulture)
            End If
        End Function

        'Private Sub btnUpdateStatus_Click(sender As Object, e As EventArgs) Handles btnUpdateStatus.Click
        '    Dim dtgItem As DataGridItem
        '    Dim chkSelected As HtmlInputCheckBox
        '    Dim strCopyIDs As String

        '    ' Get ID of selected receiving copies
        '    For Each dtgItem In dtgHoldingInfo.Items
        '        chkSelected = dtgItem.FindControl("chkCopyID")
        '        If chkSelected.Checked Then
        '            strCopyIDs = strCopyIDs & CType(dtgItem.FindControl("lblCopyID"), Label).Text & ","
        '        End If
        '    Next
        '    If strCopyIDs <> "" Then
        '        strCopyIDs = Left(strCopyIDs, Len(strCopyIDs) - 1)
        '        objBCopyNumber.CopyIDs = strCopyIDs
        '        objBCopyNumber.UpdateStatus(ddlStatus.SelectedValue)
        '        Page.RegisterClientScriptBlock("UpdateStatusSuccess", "<script>alert('" & ddlLabel.Items(12).Text & "');</script>")
        '    Else
        '        Page.RegisterClientScriptBlock("UpdateStatusSuccess", "<script>alert('" & ddlLabel.Items(10).Text & "');</script>")
        '    End If
        '    Call BindDataGrid(dtgHoldingInfo.CurrentPageIndex)
        'End Sub
        Protected Sub btnReceiveDelivered_Click(sender As Object, e As EventArgs) Handles btnReceiveDelivered.Click
            Dim dtgItem As DataGridItem
            Dim chkSelected As HtmlInputCheckBox
            Dim strCopyIDs As String = ""

            ' Get ID of selected receiving copies
            For Each dtgItem In dtgHoldingInfo.Items
                chkSelected = dtgItem.FindControl("chkCopyID")
                If chkSelected.Checked Then
                    strCopyIDs = strCopyIDs & CType(dtgItem.FindControl("lblCopyID"), Label).Text & ","
                End If
            Next
            If strCopyIDs <> "" Then
                strCopyIDs = Left(strCopyIDs, Len(strCopyIDs) - 1)
                objBCopyNumber.LibID = ddlLibrary.SelectedValue
                objBCopyNumber.UpdateholdingDelivered(strCopyIDs)
                If objBCopyNumber.ErrorMsg = "" Then
                    Page.RegisterClientScriptBlock("ReceivedUnLockSuccess", "<script>alert('" & ddlLabel.Items(13).Text & "');</script>")
                Else
                    Page.RegisterClientScriptBlock("ReceivedUnLockSuccess", "<script>alert('" & ddlLabel.Items(14).Text & "');</script>")
                End If
            Else
                Page.RegisterClientScriptBlock("ReceivedUnLockSuccess", "<script>alert('" & ddlLabel.Items(10).Text & "');</script>")
            End If
            Call BindDataGrid(dtgHoldingInfo.CurrentPageIndex)
        End Sub

        Private Sub btnDeletePrevious_Click(sender As Object, e As EventArgs) Handles btnDeletePrevious.Click
            Dim dtgItem As DataGridItem
            Dim chkSelected As HtmlInputCheckBox
            Dim strCopyIDs As String = ""

            ' Get ID of selected receiving copies
            For Each dtgItem In dtgHoldingInfo.Items
                chkSelected = dtgItem.FindControl("chkCopyID")
                If chkSelected.Checked Then
                    strCopyIDs = strCopyIDs & CType(dtgItem.FindControl("lblCopyID"), Label).Text & ","
                End If
            Next
            If strCopyIDs <> "" Then
                strCopyIDs = Left(strCopyIDs, Len(strCopyIDs) - 1)
            Else
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "ReceivedUnLockSuccess", "alert('Chưa chọn ĐKCB cần xóa');", True)

            End If
            If IsNumeric(ddlReasonDel.SelectedValue) Then
                objBCopyNumber.ReasonID = CInt(ddlReasonDel.SelectedValue)
            Else
                objBCopyNumber.ReasonID = 0
            End If
            objBCopyNumber.CopyIDs = strCopyIDs
            objBCopyNumber.Remove()
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "ReceivedUnLockSuccess", "alert('Xóa thành công');", True)
            ' Writelog
            Call WriteLog(39, ddlLabel.Items(7).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

            Call BindDataGrid(dtgHoldingInfo.CurrentPageIndex)
        End Sub
    End Class
End Namespace