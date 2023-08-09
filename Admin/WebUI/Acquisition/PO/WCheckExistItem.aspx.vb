Imports System
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.WebUI.Common

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WCheckExistItem
        Inherits clsWBase

        ' Declare variables
        Private objBCommonDBSystem As New clsBCommonDBSystem
        Private objBCommonStringProc As New clsBCommonStringProc
        Private objBItemCollection As New clsBItemCollection
        Private objBFormingSQL As New clsBFormingSQL


#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Protected WithEvents lblSequency As System.Web.UI.WebControls.Label
        Protected WithEvents lblItemType As System.Web.UI.WebControls.Label
        Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
        Protected WithEvents lblAccCopies As System.Web.UI.WebControls.Label
        Protected WithEvents lblPO As System.Web.UI.WebControls.Label
        Protected WithEvents lblAvailable As System.Web.UI.WebControls.Label
        Protected WithEvents lblFree As System.Web.UI.WebControls.Label
        Protected WithEvents lblBorrow As System.Web.UI.WebControls.Label
        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindData()
            Call BindScript()
        End Sub

        ' Initialize method
        ' Purpose: Initialize components
        Private Sub Initialize()
            ' Init for objBCommonDBSystem
            objBCommonDBSystem.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonDBSystem.DBServer = Session("DBServer")
            objBCommonDBSystem.ConnectionString = Session("ConnectionString")
            objBCommonDBSystem.Initialize()

            ' Init for objBCommonStringProc
            objBCommonStringProc.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonStringProc.DBServer = Session("DBServer")
            objBCommonStringProc.ConnectionString = Session("ConnectionString")
            objBCommonStringProc.Initialize()

            ' Init for objBFormingSQL
            objBFormingSQL.InterfaceLanguage = Session("InterfaceLanguage")
            objBFormingSQL.DBServer = Session("DBServer")
            objBFormingSQL.ConnectionString = Session("ConnectionString")
            objBFormingSQL.Initialize()

            ' Init for objBItemCollection
            objBItemCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemCollection.DBServer = Session("DBServer")
            objBItemCollection.ConnectionString = Session("ConnectionString")
            objBItemCollection.Initialize()
        End Sub

        ' BindScript method
        ' Purpose: Bind javascript
        Private Sub BindScript()
            btnClose.Attributes.Add("onclick", "self.close()")
        End Sub

        ' BindAvailableItemHeader method
        ' Bind the header of available Item table header
        Private Sub BindAvailableItemHeader()
            Dim tblRows As TableRow
            Dim tblCells As TableCell

            tblRows = New TableRow
            tblRows.CssClass = "lbTrPageTitle"
            tblCells = New TableCell
            tblCells.HorizontalAlign = HorizontalAlign.Center
            tblCells.Width = Unit.Percentage(10)
            tblCells.Controls.Add(New LiteralControl(ddlLabel.Items(3).Text))
            tblRows.Cells.Add(tblCells)
            tblCells = New TableCell
            tblCells.HorizontalAlign = HorizontalAlign.Center
            tblCells.Width = Unit.Percentage(10)
            tblCells.Controls.Add(New LiteralControl(ddlLabel.Items(4).Text))
            tblRows.Cells.Add(tblCells)
            tblCells = New TableCell
            tblCells.HorizontalAlign = HorizontalAlign.Center
            tblCells.Width = Unit.Percentage(50)
            tblCells.Controls.Add(New LiteralControl(ddlLabel.Items(5).Text))
            tblRows.Cells.Add(tblCells)
            tblCells = New TableCell
            tblCells.HorizontalAlign = HorizontalAlign.Center
            tblCells.Width = Unit.Percentage(10)
            tblCells.Controls.Add(New LiteralControl(ddlLabel.Items(8).Text))
            tblRows.Cells.Add(tblCells)
            tblCells = New TableCell
            tblCells.HorizontalAlign = HorizontalAlign.Center
            tblCells.Width = Unit.Percentage(10)
            tblCells.Controls.Add(New LiteralControl(ddlLabel.Items(9).Text))
            tblRows.Cells.Add(tblCells)
            tblCells = New TableCell
            tblCells.HorizontalAlign = HorizontalAlign.Center
            tblCells.Width = Unit.Percentage(10)
            tblCells.Controls.Add(New LiteralControl(ddlLabel.Items(10).Text))
            tblRows.Cells.Add(tblCells)
            tblItemAvailable.Rows.Add(tblRows)
        End Sub

        ' BindOrderdItemHeader method
        ' Purpose: Draw the header by ordered Item table
        Private Sub BindOrderdItemHeader()
            Dim tblRows As TableRow
            Dim tblCells As TableCell

            tblRows = New TableRow
            tblRows.CssClass = "lbTrPageTitle"
            tblCells = New TableCell
            tblCells.HorizontalAlign = HorizontalAlign.Center
            tblCells.Width = Unit.Percentage(10)
            tblCells.Controls.Add(New LiteralControl(ddlLabel.Items(3).Text))
            tblRows.Cells.Add(tblCells)
            tblCells = New TableCell
            tblCells.HorizontalAlign = HorizontalAlign.Center
            tblCells.Width = Unit.Percentage(10)
            tblCells.Controls.Add(New LiteralControl(ddlLabel.Items(4).Text))
            tblRows.Cells.Add(tblCells)
            tblCells = New TableCell
            tblCells.HorizontalAlign = HorizontalAlign.Center
            tblCells.Width = Unit.Percentage(60)
            tblCells.Controls.Add(New LiteralControl(ddlLabel.Items(5).Text))
            tblRows.Cells.Add(tblCells)
            tblCells = New TableCell
            tblCells.HorizontalAlign = HorizontalAlign.Center
            tblCells.Width = Unit.Percentage(10)
            tblCells.Controls.Add(New LiteralControl(ddlLabel.Items(6).Text))
            tblRows.Cells.Add(tblCells)
            tblCells = New TableCell
            tblCells.HorizontalAlign = HorizontalAlign.Center
            tblCells.Width = Unit.Percentage(10)
            tblCells.Controls.Add(New LiteralControl(ddlLabel.Items(7).Text))
            tblRows.Cells.Add(tblCells)
            tblItemOrdered.Rows.Add(tblRows)
        End Sub

        ' BindData method
        ' Purpose: Display the Items is found by Item Title
        Private Sub BindData()
            ' Declare variables
            Dim tblRows As TableRow
            Dim tblCells As TableCell
            Dim intCount As Integer
            Dim strTitle As String
            Dim TypeCode As String
            Dim blnSingle As Boolean
            Dim tblItem As New DataTable
            Dim blnNotExist As Boolean = False
            Dim BoolArr()
            Dim FieldArr()
            Dim ValArr()
            Dim k As Integer = 0
            Dim strSql As String
            Dim strIDs As String
            Dim arrItemID() As Integer
            Dim intCountItem As Integer = 0
            Dim tblItemCount As New DataTable
            Dim tblLoanning As New DataTable
            Dim dtvItem As DataView
            Dim dtvItemCount As DataView
            Dim dtvLoanning As DataView


            lnkOrdered1.NavigateUrl = "#ordered"
            lnkAvailable2.NavigateUrl = "#avail"

            ' Get the Title from the openner
            strTitle = Request("Title")
            blnSingle = Request("Single")

            ' Title
            If strTitle <> "" Then
                ReDim Preserve BoolArr(k)
                ReDim Preserve FieldArr(k)
                ReDim Preserve ValArr(k)
                BoolArr(k) = "AND"
                FieldArr(k) = "TI"
                ValArr(k) = strTitle
                k = k + 1
            End If

            ' Serial Type
            If Not blnSingle Then
                ReDim Preserve BoolArr(k)
                ReDim Preserve FieldArr(k)
                ReDim Preserve ValArr(k)
                BoolArr(k) = "AND"
                FieldArr(k) = "IT"
                ValArr(k) = "TT"
                k = k + 1
            End If

            ' Form the sql string and get Items
            objBFormingSQL.BoolArr = BoolArr
            objBFormingSQL.FieldArr = FieldArr
            objBFormingSQL.ValArr = ValArr
            objBFormingSQL.LibID = clsSession.GlbSite
            strSql = objBFormingSQL.FormingASQL()
            objBCommonDBSystem.SQLStatement = strSql
            tblItem = objBCommonDBSystem.RetrieveItemInfor()

            ' Display the Item availables details
            If Not tblItem Is Nothing Then
                If tblItem.Rows.Count > 0 Then
                    ' Candidate the range of item (100)
                    If tblItem.Rows.Count > 100 Then
                        intCountItem = 99
                    Else
                        intCountItem = tblItem.Rows.Count - 1
                    End If

                    ReDim arrItemID(intCountItem)

                    ' Get the item ID string and each item id to add to the Item ID array
                    strIDs = ""
                    For intCount = 0 To intCountItem
                        arrItemID(intCount) = tblItem.Rows(intCount).Item("ID")
                        strIDs = strIDs & tblItem.Rows(intCount).Item("ID") & ","
                    Next

                    If strIDs <> "" Then
                        strIDs = Left(strIDs, Len(strIDs) - 1)
                    End If

                    ' Get the details information of items
                    objBItemCollection.ItemIDs = strIDs
                    tblItem = objBItemCollection.GetAvailableItems

                    ' Retrieve the copy of items
                    tblItemCount = objBItemCollection.GetItemCount

                    tblLoanning = objBItemCollection.GetLoanHistory

                    dtvItem = tblItem.DefaultView
                    dtvItemCount = tblItemCount.DefaultView
                    dtvLoanning = tblLoanning.DefaultView

                    ' Draw the Item Title (Available at the moment)
                    Call BindAvailableItemHeader()

                    ' Begin to draw the table and display the Items's detail
                    For intCount = 0 To UBound(arrItemID)
                        dtvItem = New DataView
                        dtvItemCount = New DataView
                        dtvLoanning = New DataView

                        ' Data view of item infor
                        If Not tblItem Is Nothing Then
                            If tblItem.Rows.Count > 0 Then
                                dtvItem = tblItem.DefaultView
                                lblAvailable1.Visible = True
                                lnkOrdered1.Visible = True
                                lnkAvailable2.Visible = True
                            Else
                                ' No Item is available now
                                lblAvailable1.Visible = False
                                lnkOrdered1.Visible = True
                                lnkAvailable2.Visible = False
                            End If
                        Else
                            ' No Item is available now
                            lblAvailable1.Visible = False
                            lnkOrdered1.Visible = True
                            lnkAvailable2.Visible = False
                        End If

                        ' Data view of Item's Holding copies
                        If Not tblItemCount Is Nothing Then
                            If tblItemCount.Rows.Count > 0 Then
                                dtvItemCount = tblItemCount.DefaultView
                            End If
                        End If

                        ' Data view of Item's Loanning infor
                        dtvLoanning = tblLoanning.DefaultView

                        ' Item information
                        dtvItem.RowFilter = "ItemID = " & arrItemID(intCount)
                        ' Holding copies
                        dtvItemCount.RowFilter = "ID = " & arrItemID(intCount)
                        ' Loan copies
                        dtvLoanning.RowFilter = "ItemID= " & arrItemID(intCount)

                        ' Display the results
                        tblRows = New TableRow
                        tblCells = New TableCell
                        tblCells.HorizontalAlign = HorizontalAlign.Center
                        tblCells.Controls.Add(New LiteralControl(intCount + 1))
                        tblRows.Cells.Add(tblCells)
                        tblCells = New TableCell
                        tblCells.HorizontalAlign = HorizontalAlign.Center

                        ' Item details infor
                        If dtvItemCount.Count > 0 Then
                            ' Type Code
                            If Not IsDBNull(dtvItemCount.Item(0).Item("TypeCode")) Then
                                tblCells.Controls.Add(New LiteralControl(dtvItemCount.Item(0).Item("TypeCode")))
                            Else
                                tblCells.Controls.Add(New LiteralControl(""))
                            End If
                        End If

                        tblRows.Cells.Add(tblCells)

                        Dim strISBD As String
                        Dim intj As Integer

                        strISBD = ""

                        ' ISBD
                        For intj = 0 To dtvItem.Count - 1
                            strISBD = strISBD & dtvItem.Item(intj).Item("Content") & " . - "
                        Next

                        tblCells = New TableCell
                        tblCells.HorizontalAlign = HorizontalAlign.Center

                        ' Display the ISBD
                        If Len(strISBD) > 5 Then
                            tblCells.Controls.Add(New LiteralControl(objBCommonStringProc.TrimSubFieldCodes(Left(strISBD, Len(strISBD) - 5)) & _
                            "<BR>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" & _
                            "<A class=""lbLinkFunction"" HREF=""javascript:opener.parent.hiddenbase.location.href = 'WAcqRequestHidden.aspx?ID=" & arrItemID(intCount) & "' ; self.close();"">" & ddlLabel.Items(2).Text & " </A>"))
                        Else
                            tblCells.Controls.Add(New LiteralControl(""))
                        End If

                        ' Display the Total copies of item
                        tblRows.Cells.Add(tblCells)
                        tblCells = New TableCell
                        tblCells.HorizontalAlign = HorizontalAlign.Center
                        If dtvItemCount.Count > 0 Then
                            If Not IsDBNull(dtvItemCount.Item(0).Item("TotalCopies")) Then
                                tblCells.Controls.Add(New LiteralControl(dtvItemCount.Item(0).Item("TotalCopies")))
                            End If
                        Else
                            tblCells.Controls.Add(New LiteralControl(""))
                        End If

                        ' Display the Total free copies of item
                        tblRows.Cells.Add(tblCells)
                        tblCells = New TableCell
                        tblCells.HorizontalAlign = HorizontalAlign.Center
                        If dtvItemCount.Count > 0 Then
                            If Not IsDBNull(dtvItemCount.Item(0).Item("FreeCopies")) Then
                                tblCells.Controls.Add(New LiteralControl(dtvItemCount.Item(0).Item("FreeCopies")))
                            End If
                        Else
                            tblCells.Controls.Add(New LiteralControl(""))
                        End If
                        tblRows.Cells.Add(tblCells)
                        tblCells = New TableCell

                        ' Display the loanning copies of item
                        tblCells.HorizontalAlign = HorizontalAlign.Center
                        If dtvLoanning.Count > 0 Then
                            If Not IsDBNull(dtvLoanning.Item(0).Item("NockOut")) Then
                                tblCells.Controls.Add(New LiteralControl(dtvLoanning.Item(0).Item("NockOut")))
                            End If
                        Else
                            tblCells.Controls.Add(New LiteralControl(""))
                        End If
                        tblRows.Cells.Add(tblCells)
                        tblItemAvailable.Rows.Add(tblRows)
                        dtvItem = Nothing
                        dtvItemCount = Nothing
                        dtvLoanning = Nothing
                    Next
                Else
                    ' Not exist Item in the database
                    lblAvailable1.Visible = False
                    lnkOrdered1.Visible = False
                    lnkAvailable2.Visible = False
                    blnNotExist = True
                End If
            Else
                ' Not exist Item in the database
                lblAvailable1.Visible = False
                lnkOrdered1.Visible = False
                lnkAvailable2.Visible = False
                blnNotExist = True
            End If

            ' ***************************************************
            ' **** Retrieve the PO information by Item Title ****
            ' ***************************************************
            objBItemCollection.Title = strTitle
            objBItemCollection.LibID = clsSession.GlbSite
            tblItem = objBItemCollection.GetOrderedItems

            If Not tblItem Is Nothing Then
                If tblItem.Rows.Count > 0 Then
                    lblOrdered2.Visible = True

                    ' Load the ordered Item information
                    Call BindOrderdItemHeader()

                    For intCount = 0 To tblItem.Rows.Count - 1
                        tblRows = New TableRow
                        tblCells = New TableCell
                        tblCells.HorizontalAlign = HorizontalAlign.Center
                        tblCells.Controls.Add(New LiteralControl(intCount + 1))
                        tblRows.Cells.Add(tblCells)
                        tblCells = New TableCell
                        tblCells.HorizontalAlign = HorizontalAlign.Center
                        tblCells.Controls.Add(New LiteralControl(tblItem.Rows(intCount).Item("TypeCode")))
                        tblRows.Cells.Add(tblCells)

                        ' Display the ISBD
                        Dim strISBD As String
                        strISBD = ""

                        ' Author
                        If Not IsDBNull(tblItem.Rows(intCount).Item("Author")) Then
                            If Not tblItem.Rows(intCount).Item("Author") = "" Then
                                strISBD = strISBD & tblItem.Rows(intCount).Item("Author") & ". "
                            End If
                        End If

                        ' Title
                        If Not IsDBNull(tblItem.Rows(intCount).Item("Title")) Then
                            strISBD = strISBD & tblItem.Rows(intCount).Item("Title")
                        End If

                        ' Edition
                        If Not IsDBNull(tblItem.Rows(intCount).Item("Edition")) Then
                            If Not tblItem.Rows(intCount).Item("Edition") = "" Then
                                strISBD = strISBD & ". - " & tblItem.Rows(intCount).Item("Edition")
                            End If
                        End If

                        ' Publisher and Pub Year
                        If Not IsDBNull(tblItem.Rows(intCount).Item("Publisher")) Then
                            strISBD = strISBD & ". - "
                            If Not tblItem.Rows(intCount).Item("Publisher") = "" Then
                                strISBD = strISBD & tblItem.Rows(intCount).Item("Publisher")
                            End If
                            If Not IsDBNull(tblItem.Rows(intCount).Item("PubYear")) Then
                                If Not tblItem.Rows(intCount).Item("PubYear") = "" Then
                                    strISBD = strISBD & ", " & tblItem.Rows(intCount).Item("PubYear")
                                End If
                            End If
                        End If

                        ' Display the ISBD
                        tblCells = New TableCell
                        tblCells.HorizontalAlign = HorizontalAlign.Center
                        tblCells.Controls.Add(New LiteralControl(objBCommonStringProc.ConvertIt(strISBD)))
                        tblRows.Cells.Add(tblCells)
                        tblCells = New TableCell
                        tblCells.HorizontalAlign = HorizontalAlign.Center

                        ' AcceptedCopies
                        If Not IsDBNull(tblItem.Rows(intCount).Item("AcceptedCopies")) Then
                            tblCells.Controls.Add(New LiteralControl(tblItem.Rows(intCount).Item("AcceptedCopies")))
                        Else
                            tblCells.Controls.Add(New LiteralControl(""))
                        End If

                        tblRows.Cells.Add(tblCells)
                        tblCells = New TableCell
                        tblCells.HorizontalAlign = HorizontalAlign.Center

                        ' ReceiptNo
                        If Not IsDBNull(tblItem.Rows(intCount).Item("ReceiptNo")) Then
                            tblCells.Controls.Add(New LiteralControl(objBCommonStringProc.ConvertIt(tblItem.Rows(intCount).Item("ReceiptNo"))))
                        Else
                            tblCells.Controls.Add(New LiteralControl(objBCommonStringProc.ConvertIt("")))
                        End If
                        tblRows.Cells.Add(tblCells)
                        tblItemOrdered.Rows.Add(tblRows)
                    Next
                Else
                    lnkAvailable2.Visible = False
                    lblOrdered2.Visible = False
                    lnkOrdered1.Visible = False
                    ' Not exist item
                    If blnNotExist Then
                        lblNotExist.Visible = True
                        lblAvailable1.Visible = False
                        lnkAvailable2.Visible = False
                        lnkOrdered1.Visible = False
                        lblOrdered2.Visible = False
                    End If
                End If
            Else
                lnkAvailable2.Visible = False
                lblOrdered2.Visible = False
                lnkOrdered1.Visible = False
                ' Not exist item
                If blnNotExist Then
                    lblNotExist.Visible = True
                    lblAvailable1.Visible = False
                    lnkAvailable2.Visible = False
                    lnkOrdered1.Visible = False
                    lblOrdered2.Visible = False
                End If
            End If
        End Sub

        ' Page_Unload event
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Me.Dispose(True)
        End Sub

        ' Dispose Method
        ' Purpose: Release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    ' Dispose manage resource                 
                End If
                If Not objBCommonDBSystem Is Nothing Then
                    objBCommonDBSystem.Dispose(True)
                    objBCommonDBSystem = Nothing
                End If
                If Not objBItemCollection Is Nothing Then
                    objBItemCollection.Dispose(True)
                    objBItemCollection = Nothing
                End If
                If Not objBFormingSQL Is Nothing Then
                    objBFormingSQL.Dispose(True)
                    objBFormingSQL = Nothing
                End If
                If Not objBCommonStringProc Is Nothing Then
                    objBCommonStringProc.Dispose(True)
                    objBCommonStringProc = Nothing
                End If
                ' Call Dispose on your base class.
            Finally
                Me.Dispose()
                MyBase.Dispose()
            End Try
        End Sub

        ' ********************* Finally method
        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub
    End Class
End Namespace