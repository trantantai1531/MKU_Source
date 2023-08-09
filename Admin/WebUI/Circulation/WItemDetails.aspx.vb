Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.BusinessRules.Circulation
Imports Telerik.Web.UI

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WItemDetails
        Inherits clsWBase
        Implements IUCNumberOfRecord

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblISBN As System.Web.UI.WebControls.Label
        Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
        Protected WithEvents lblPublish As System.Web.UI.WebControls.Label
        Protected WithEvents lblPhysical As System.Web.UI.WebControls.Label
        Protected WithEvents lblAuthor As System.Web.UI.WebControls.Label
        Protected WithEvents lbPatronHistory As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBCommonStringProc As New clsBCommonStringProc
        Private objBItem As New clsBItem
        Private objBCommonBusiness As New clsBCommonBusiness
        Private objBloanType As New clsBLoanType
        Private objBLoanTransaction As New clsBLoanTransaction

        Private tblItem As DataTable
        Private tblCode As DataTable
        Private intItemID As Integer

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJavaScript()

            ' Display the controls
            If Request("CheckIn") = 1 Then
                btnStatus.Text = lblCheckIn.Text
                ' Check user right
                If Not CheckPemission(58) Then
                    btnStatus.Enabled = False
                Else
                    btnStatus.Enabled = True
                End If

                btnStatus.Attributes.Add("OnClick", "CheckIn('" & ddlLabel.Items(3).Text & "'); return false;")
            Else
                ' Check User right
                If Not CheckPemission(57) Then
                    btnStatus.Enabled = False
                Else
                    btnStatus.Enabled = True
                End If
                btnStatus.Text = lblCheckOut.Text
                btnStatus.Attributes.Add("OnClick", "CheckOut('" & ddlLabel.Items(2).Text & "');return false;")
            End If

            'Call BindData()
            Call BindOnLoanInfor()
        End Sub

        ' Initialze method 
        ' Purpose: Initialize all objects
        Private Sub Initialize()
            ' Init for objBItem
            objBItem.InterfaceLanguage = Session("InterfaceLanguage")
            objBItem.DBServer = Session("DBServer")
            objBItem.ConnectionString = Session("ConnectionString")
            objBItem.Initialize()

            ' Init for objBCommonStringProc
            objBCommonStringProc.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonStringProc.DBServer = Session("DBServer")
            objBCommonStringProc.ConnectionString = Session("ConnectionString")
            objBCommonStringProc.Initialize()

            ' Init for objBCommonBusiness
            objBCommonBusiness.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonBusiness.DBServer = Session("DBServer")
            objBCommonBusiness.ConnectionString = Session("ConnectionString")
            objBCommonBusiness.UserID = Session("UserID")
            objBCommonBusiness.Initialize()

            ' Init for objBLoanType
            objBloanType.InterfaceLanguage = Session("InterfaceLanguage")
            objBloanType.DBServer = Session("DBServer")
            objBloanType.ConnectionString = Session("ConnectionString")
            objBloanType.Initialize()

            ' Init for objBLoanType
            objBLoanTransaction.InterfaceLanguage = Session("InterfaceLanguage")
            objBLoanTransaction.DBServer = Session("DBServer")
            objBLoanTransaction.ConnectionString = Session("ConnectionString")
            objBLoanTransaction.Initialize()

            ' Init the style for the elements of datagrid
            dtgResult.HeaderStyle.CssClass = "lbGridHeader"
            dtgResult.PagerStyle.CssClass = "lbGridPager"
            dtgResult.AlternatingItemStyle.CssClass = "lbGridAlterCell"
            dtgResult.ItemStyle.CssClass = "lbGridCell"
            dtgResult.EditItemStyle.CssClass = "lbGridEdit"
        End Sub

        ' BindJavaScript method
        Private Sub BindJavaScript()
            Page.RegisterClientScriptBlock("CommonJS", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJS", "<script language = 'javascript' src = 'Js/WItemDetails.js'></script>")
        End Sub

        ' BindData method
        ' Purpose: Display the Item details
        Private Sub BindData()
            ' Declare variables
            Dim intCount As Integer
            Dim intIndex As Integer
            Dim strContent As String
            Dim arrItemVal()
            Dim strEdition As String

            ' Retrieve all Item infor
            Call BindItemID()

            objBItem.ItemID = intItemID
            tblItem = objBItem.GetItemInfor

            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBItem.ErrorMsg, ddlLabel.Items(1).Text, objBItem.ErrorCode)

            If Not tblItem Is Nothing Then
                intCount = tblItem.Rows.Count
            End If

            ' Draw the table
            If intCount > 0 Then
                Dim tblRow As TableRow
                Dim tblCell1 As TableCell
                Dim tblCell2 As TableCell
                For intIndex = 0 To intCount - 1
                    strContent = ""
                    tblRow = New TableRow

                    tblCell1 = New TableCell
                    tblCell1.ColumnSpan = 1
                    tblCell1.HorizontalAlign = HorizontalAlign.Right
                    tblCell1.CssClass = "lbLabel"
                    tblCell1.Width = Unit.Percentage(40%)

                    tblCell2 = New TableCell
                    tblCell2.ColumnSpan = 1
                    tblCell2.CssClass = "lbLabel"
                    tblCell2.Width = Unit.Percentage(60%)

                    If Not IsDBNull(tblItem.Rows(intIndex).Item("FieldCode")) Then
                        Select Case CStr(tblItem.Rows(intIndex).Item("FieldCode"))
                            Case "020" ' ISBN
                                If Not IsDBNull(tblItem.Rows(intIndex).Item("Content")) Then
                                    If Not tblItem.Rows(intIndex).Item("Content") = "" Then
                                        tblCell1.Controls.Add(New LiteralControl(lblFieldLabel1.Text))
                                        Call objBCommonStringProc.ParseField("$a", Replace(tblItem.Rows(intIndex).Item("Content"), """", "&quot;"), "tr", arrItemVal)
                                        If Not arrItemVal(0) = "" Then
                                            strContent = arrItemVal(0)
                                        End If
                                    End If
                                End If
                            Case "022" ' ISSN
                                If Not IsDBNull(tblItem.Rows(intIndex).Item("Content")) Then
                                    If Not tblItem.Rows(intIndex).Item("Content") = "" Then
                                        tblCell1.Controls.Add(New LiteralControl(lblFieldLabel2.Text))
                                        Call objBCommonStringProc.ParseField("$a", Replace(tblItem.Rows(intIndex).Item("Content"), """", "&quot;"), "tr", arrItemVal)
                                        If Not arrItemVal(0) = "" Then
                                            strContent = arrItemVal(0)
                                        End If
                                    End If
                                End If
                            Case "100" ' Author
                                If Not IsDBNull(tblItem.Rows(intIndex).Item("Content")) Then
                                    If Not tblItem.Rows(intIndex).Item("Content") = "" Then
                                        tblCell1.Controls.Add(New LiteralControl(lblFieldLabel3.Text))
                                        Call objBCommonStringProc.ParseField("$a", Replace(tblItem.Rows(intIndex).Item("Content"), """", "&quot;"), "tr", arrItemVal)
                                        If Not arrItemVal(0) = "" Then
                                            strContent = arrItemVal(0)
                                        End If
                                    End If
                                End If
                            Case "110" ' Group author
                                If Not IsDBNull(tblItem.Rows(intIndex).Item("Content")) Then
                                    If Not tblItem.Rows(intIndex).Item("Content") = "" Then
                                        tblCell1.Controls.Add(New LiteralControl(lblFieldLabel4.Text))
                                        Call objBCommonStringProc.ParseField("$a", Replace(tblItem.Rows(intIndex).Item("Content"), """", "&quot;"), "tr", arrItemVal)
                                        If Not arrItemVal(0) = "" Then
                                            strContent = arrItemVal(0)
                                        End If
                                    End If
                                End If
                            Case "111" ' Ten hoi nghi
                                If Not IsDBNull(tblItem.Rows(intIndex).Item("Content")) Then
                                    If Not tblItem.Rows(intIndex).Item("Content") = "" Then
                                        tblCell1.Controls.Add(New LiteralControl(lblFieldLabel5.Text))
                                        Call objBCommonStringProc.ParseField("$a", Replace(tblItem.Rows(intIndex).Item("Content"), """", "&quot;"), "tr", arrItemVal)
                                        If Not arrItemVal(0) = "" Then
                                            strContent = arrItemVal(0)
                                        End If
                                    End If
                                End If
                            Case "245" ' Title
                                If Not IsDBNull(tblItem.Rows(intIndex).Item("Content")) Then
                                    If Not tblItem.Rows(intIndex).Item("Content") = "" Then
                                        tblCell1.Controls.Add(New LiteralControl(lblFieldLabel6.Text))
                                        tblCell2.ForeColor = SystemColors.InfoText
                                        Call objBCommonStringProc.ParseField("$a", Replace(tblItem.Rows(intIndex).Item("Content"), """", "&quot;"), "tr", arrItemVal)
                                        If Not arrItemVal(0) = "" Then
                                            strContent = arrItemVal(0)
                                        End If
                                    End If
                                End If
                            Case "260" ' Edition, publisher and pub year
                                If Not IsDBNull(tblItem.Rows(intIndex).Item("Content")) Then
                                    If Not tblItem.Rows(intIndex).Item("Content") = "" Then
                                        tblCell1.Controls.Add(New LiteralControl(lblFieldLabel7.Text))
                                        strContent = objBCommonStringProc.TrimSubFieldCodes(tblItem.Rows(intIndex).Item("Content"))
                                    End If
                                End If
                            Case "300" ' Physical charactor
                                If Not IsDBNull(tblItem.Rows(intIndex).Item("Content")) Then
                                    If Not tblItem.Rows(intIndex).Item("Content") = "" Then
                                        tblCell1.Controls.Add(New LiteralControl(lblFieldLabel8.Text))
                                        strContent = objBCommonStringProc.TrimSubFieldCodes(tblItem.Rows(intIndex).Item("Content"))
                                    End If
                                End If
                        End Select

                        ' Display the Item details
                        If Not strContent = "" Then
                            tblRow.Cells.Add(tblCell1)
                            tblCell2.Controls.Add(New LiteralControl(strContent))
                            tblCell2.Font.Bold = True
                            tblRow.Cells.Add(tblCell2)
                            tblMainInfor.Rows.Add(tblRow)
                        End If
                    End If
                Next
                BindGrid()
            End If
        End Sub

        ' BindGrid method
        ' Purpose: Bind data grid (Holding data)
        Private Sub BindGrid()
            ' Declare variables
            Dim dtgItem As DataGridItem
            Dim lblStatus As Label
            Dim lblRadio As Label
            Dim strInused As String
            Dim strAcquired As String
            Dim strInCirculation As String
            Dim strCopyNumber As String
            Dim intCount As Integer = 0
            Dim intFreeCount As Integer = 0
            Dim intIndex As Integer = 0
            Dim inti As Integer = 0

            ' Retrieve all Item infor
            'Call BindItemID()

            If intItemID > 0 Then
                objBItem.ItemID = intItemID
                tblItem = objBItem.GetCopyNumbers

                ' Write error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBItem.ErrorMsg, ddlLabel.Items(1).Text, objBItem.ErrorCode)

                If Not tblItem Is Nothing Then
                    If tblItem.Rows.Count > 0 Then
                        btnStatus.Visible = True

                        ' Count the free copy number
                        For intIndex = 0 To tblItem.Rows.Count - 1
                            If CBool(tblItem.Rows(intIndex).Item("InUsed")) = False _
                                And CBool(tblItem.Rows(intIndex).Item("InCirculation")) = True _
                                And CBool(tblItem.Rows(intIndex).Item("Acquired")) = True Then
                                intFreeCount = intFreeCount + 1
                            End If
                        Next
                        hidControl.Value = intFreeCount
                        lblFreeCount.Text = CStr(intFreeCount)

                        dtgResult.DataSource = tblItem
                        ' dtgResult.DataBind()
                        hidCopyNum.Value = ""

                    Else
                        btnStatus.Visible = False
                    End If
                Else
                    btnStatus.Visible = False
                End If
            End If
        End Sub

        ' BindItemID method
        ' Purpose: Get the ItemID
        Private Sub BindItemID()
            Dim strDisplay As String
            Dim blnFound As Boolean

            If Trim(CStr(Request("ItemID")) & "" <> "") Then
                intItemID = CInt(Request("ItemID"))
            ElseIf Trim(CStr(Request("ItemCode")) & "" <> "") Then
                objBItem.Code = Trim(CStr(Request("ItemCode")))
                tblCode = objBItem.GetItemIDByItemCode

                ' Write error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBItem.ErrorMsg, ddlLabel.Items(1).Text, objBItem.ErrorCode)

                If Not tblCode Is Nothing Then
                    If tblCode.Rows.Count > 0 Then
                        intItemID = CInt(tblCode.Rows(0).Item(0))
                        blnFound = True
                    Else
                        blnFound = False
                    End If
                Else
                    blnFound = False
                End If

                If blnFound = False Then
                    strDisplay = "<P align=""center"">"
                    strDisplay = strDisplay & "<font family=Arial Unicode MS, Times New Roman, Verdana size=2pt color=#000080>"
                    strDisplay = strDisplay & lblMsg.Text
                    strDisplay = strDisplay & "</font>"
                    strDisplay = strDisplay & "<B><font family=Arial Unicode MS, Times New Roman, Verdana size=2pt color=990000>"
                    strDisplay = strDisplay & Trim(CStr(Request("ItemCode"))) & "</font></B>"
                    Response.Write(strDisplay)
                    Response.End()
                End If
            ElseIf Trim(CStr(Request("ItemCode"))) & "" = "" And Trim(CStr(Request("ItemID"))) & "" = "" Then
                Response.Write("")
                Response.End()
            End If
        End Sub

        ' BindOnLoanInfor method
        ' Purpose: Get the loanning patron and copy number infor of item is used
        Private Sub BindOnLoanInfor()
            ' Declare variables
            Dim tblOnLoan As DataTable
            Dim intLoanCount As Integer = 0
            Dim intIndex As Integer
            Dim strContent As String
            Dim strPatronName As String
            Dim strPatronCode As String
            Dim strCopyNumber As String
            Dim strCOD As String
            Dim strCID As String

            If intItemID > 0 Then
                objBLoanTransaction.ItemID = intItemID
                tblOnLoan = objBLoanTransaction.GetOnLoanCopies

                ' Write error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBLoanTransaction.ErrorMsg, ddlLabel.Items(1).Text, objBLoanTransaction.ErrorCode)

                If Not tblOnLoan Is Nothing Then
                    If tblOnLoan.Rows.Count > 0 Then
                        intLoanCount = CInt(tblOnLoan.Rows.Count)
                    End If
                End If

                ' Draw the table
                If intLoanCount > 0 Then
                    lblPatronHistory.Visible = True
                    Dim tblRow As TableRow
                    Dim tblCell As TableCell

                    For intIndex = 0 To intLoanCount - 1
                        tblRow = New TableRow

                        tblCell = New TableCell
                        tblCell.ColumnSpan = 2
                        tblCell.CssClass = "lbLabel"
                        If Not IsDBNull(tblOnLoan.Rows(intIndex).Item("FullName")) Then
                            strPatronName = CStr(tblOnLoan.Rows(intIndex).Item("FullName"))
                        Else
                            strPatronName = ""
                        End If
                        If Not IsDBNull(tblOnLoan.Rows(intIndex).Item("Code")) Then
                            strPatronCode = CStr(tblOnLoan.Rows(intIndex).Item("Code"))
                        Else
                            strPatronCode = ""
                        End If
                        If Not IsDBNull(tblOnLoan.Rows(intIndex).Item("CopyNumber")) Then
                            strCopyNumber = CStr(tblOnLoan.Rows(intIndex).Item("CopyNumber"))
                        Else
                            strCopyNumber = ""
                        End If
                        strCOD = ""
                        strCID = ""
                        If Session("DBServer") = "ORACLE" Then
                            If Not IsDBNull(tblOnLoan.Rows(intIndex).Item("COD")) Then
                                strCOD = CStr(tblOnLoan.Rows(intIndex).Item("COD"))
                            End If
                            If Not IsDBNull(tblOnLoan.Rows(intIndex).Item("CID")) Then
                                strCID = CStr(tblOnLoan.Rows(intIndex).Item("CID"))
                            End If
                        Else
                            If Not IsDBNull(tblOnLoan.Rows(intIndex).Item("cod")) Then
                                strCOD = CStr(tblOnLoan.Rows(intIndex).Item("cod"))
                            End If
                            If Not IsDBNull(tblOnLoan.Rows(intIndex).Item("cid")) Then
                                strCID = CStr(tblOnLoan.Rows(intIndex).Item("cid"))
                            End If
                        End If
                        strContent = "+ " & strPatronName & " / " & lblPatronCode.Text & " " & strPatronCode & "<BR>"
                        strContent = strContent & "(" & lblCopyNum.Text & " " & strCopyNumber & " " & lblCod.Text & " " & strCOD
                        strContent = strContent & " " & lblCid.Text & " " & strCID & ")"
                        tblCell.Controls.Add(New LiteralControl(strContent))
                        tblCell.CssClass = "lbSubformTitle"
                        tblRow.Cells.Add(tblCell)
                        tblOnLoanInfor.Rows.Add(tblRow)
                    Next
                End If
            End If
        End Sub

        ' DgrResult_PageIndexChanged event
        ' Purpose: Change the page index
        'Private Sub DgrResult_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgResult.PageIndexChanged
        '    dtgResult.CurrentPageIndex = e.NewPageIndex
        '    Call BindGrid()
        'End Sub

        ' Page_UnLoad event    
        ' Purpose: Unload the page and dispose the elements
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: Release all object
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBItem Is Nothing Then
                    objBItem.Dispose(True)
                    objBItem = Nothing
                End If
                If Not objBCommonBusiness Is Nothing Then
                    objBCommonBusiness.Dispose(True)
                    objBCommonBusiness = Nothing
                End If
                If Not objBloanType Is Nothing Then
                    objBloanType.Dispose(True)
                    objBloanType = Nothing
                End If
                If Not objBLoanTransaction Is Nothing Then
                    objBLoanTransaction.Dispose(True)
                    objBLoanTransaction = Nothing
                End If
                If Not objBCommonStringProc Is Nothing Then
                    objBCommonStringProc.Dispose(True)
                    objBCommonStringProc = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        Public Function NumberOfRecord() As Integer Implements IUCNumberOfRecord.NumberOfRecord
            Return 25
        End Function



        Protected Sub dtgResult_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles dtgResult.NeedDataSource
            BindData()

        End Sub

        Protected Sub dtgResult_ItemCreated(sender As Object, e As GridItemEventArgs) Handles dtgResult.ItemCreated
            Dim dtgItem As GridDataItem
            Dim lblStatus As Label
            Dim lblRadio As Label
            Dim strInused As String
            Dim strAcquired As String
            Dim strInCirculation As String
            Dim strCopyNumber As String
            Dim intCount As Integer = 0
            Dim intFreeCount As Integer = 0
            Dim intIndex As Integer = 0
            Dim inti As Integer = 0

            ' Display the images(not free) and the radio button (free) in the rows of data grid
            For Each dtgItem In dtgResult.MasterTableView.Items
                strInused = CStr(CType(dtgItem.FindControl("lblInUsed"), Label).Text)
                strAcquired = CStr(CType(dtgItem.FindControl("lblAcquired"), Label).Text)
                strInCirculation = CStr(CType(dtgItem.FindControl("lblInCirculation"), Label).Text)

                lblStatus = dtgItem.FindControl("lblStatus")
                lblRadio = dtgItem.FindControl("lblRadio")

                If CStr(Trim(Request("CheckIn"))) = "1" Then
                    If CStr(Request("ItemType")) <> "" Then
                        lblRadio.Visible = False
                        btnStatus.Visible = False
                    Else
                        btnStatus.Visible = True
                        lblRadio.Visible = False
                        If CBool(strInused) = True Then
                            lblStatus.Text = "<img src=""../images/loan.gif"">"
                            lblRadio.Visible = True
                            strCopyNumber = CStr(CType(dtgItem.FindControl("lblCopyNumber"), Label).Text)
                            dtgItem.Attributes.Add("onclick", "javascript:rdoEvent('" & strCopyNumber & "'," & intCount & ");")
                            intCount = intCount + 1
                        ElseIf CBool(strAcquired) = False Then ' Not acquired
                            lblStatus.Text = "<img src=""../images/process.gif"">"
                            lblRadio.Visible = False
                        ElseIf CBool(strInCirculation) = False Then 'Locked
                            lblStatus.Text = "<img src=""../images/lock.gif"">"
                            lblRadio.Visible = False
                        Else
                            lblRadio.Visible = False
                        End If
                    End If
                Else
                    If CBool(strInused) = True Then
                        lblStatus.Text = "<img src=""../images/loan.gif"">"
                        lblRadio.Visible = False
                    ElseIf CBool(strAcquired) = False Then  ' Not acquired
                        lblStatus.Text = "<img src=""../images/process.gif"">"
                        lblRadio.Visible = False
                    ElseIf CBool(strInCirculation) = False Then ' Locked
                        lblStatus.Text = "<img src=""../images/lock.gif"">"
                        lblRadio.Visible = False
                    Else
                        If CStr(Request("ItemType")) & "" <> "" Then
                            lblRadio.Visible = False
                            btnStatus.Visible = False
                        Else
                            btnStatus.Visible = True
                            strCopyNumber = CStr(CType(dtgItem.FindControl("lblCopyNumber"), Label).Text)
                            dtgItem.Attributes.Add("onclick", "javascript:rdoEvent('" & strCopyNumber & "'," & intCount & ");")
                            intCount = intCount + 1
                        End If
                    End If
                End If
            Next
        End Sub
    End Class
End Namespace

