' Class: WSearchItemID
' Puspose: Show item search form
' Creator: Oanhtn
' CreatedDate: 25/05/2005
' Modification History:

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WSearchItemID
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblMsgAlert As System.Web.UI.WebControls.Label
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBCDBS As New clsBCommonDBSystem
        Private objBFormingSQL As New clsBFormingSQL
        Private objBIC As New clsBItemCollection
        Private objBCSP As New clsBCommonStringProc
        Private objBCommon As New clsBCommonBusiness

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call BindItemType()
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: Init all need objects
        Private Sub Initialize()
            ' Init objBCommon object
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            Call objBCDBS.Initialize()

            ' Init objBFormingSQL object
            objBFormingSQL.InterfaceLanguage = Session("InterfaceLanguage")
            objBFormingSQL.DBServer = Session("DBServer")
            objBFormingSQL.ConnectionString = Session("ConnectionString")
            Call objBFormingSQL.Initialize()

            ' Init objBIC object
            objBIC.InterfaceLanguage = Session("InterfaceLanguage")
            objBIC.DBServer = Session("DBServer")
            objBIC.ConnectionString = Session("ConnectionString")
            Call objBIC.Initialize()

            ' Init objBCSP object
            objBCSP.InterfaceLanguage = Session("InterfaceLanguage")
            objBCSP.DBServer = Session("DBServer")
            objBCSP.ConnectionString = Session("ConnectionString")
            Call objBCSP.Initialize()

            ' Init objBCommon object
            objBCommon.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommon.DBServer = Session("DBServer")
            objBCommon.ConnectionString = Session("ConnectionString")
            Call objBCommon.Initialize()
            If Not Request("FieldCode") = "" Then
                hidFieldCode.Value = Trim(Request("FieldCode"))
            End If
        End Sub

        ' BindJS method
        ' Purpose: include all need js functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("CataJs", "<script language = 'javascript' src = '../Js/Catalogue/WCata.js'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../Js/Catalogue/WSearchItemID.js'></script>")

            btnReset.Attributes.Add("onClick", "ClearAll(); return false;")
            btnSearch.Attributes.Add("onClick", "if (!CheckAll('" & ddlLabel.Items(2).Text & "')) {return false;}")
        End Sub
        Private Sub BindItemType()
            Dim tblItem As DataTable
            tblItem = objBCommon.GetItemTypes()
            If Not tblItem Is Nothing AndAlso tblItem.Rows.Count > 0 Then
                ddlItemType.DataSource = tblItem
                ddlItemType.DataTextField = "Type"
                ddlItemType.DataValueField = "ID"
                ddlItemType.DataBind()
            End If
        End Sub
        ' Method: SearchItem
        Sub SearchItem()
            Dim arrBool()
            Dim arrVal()
            Dim arrField()
            Dim arrItemID()
            Dim dtRow() As DataRow
            Dim intk
            Dim intIndex As Integer
            Dim tblTemp As New DataTable
            Dim strIDs As String
            Dim intTotalItem As Integer
            Dim strISBD As String = ""
            Dim strAdded As String = ""
            Dim strTemp As String = ""
            Dim intSubIndex As Integer
            Dim tblRow As TableRow
            Dim tblCell As TableCell
            Dim lblTemp As Label
            Dim imgTemp As System.Web.UI.WebControls.Image
            Dim lnkTemp As System.Web.UI.WebControls.HyperLink

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
            ReDim Preserve arrBool(intk)
            ReDim Preserve arrField(intk)
            ReDim Preserve arrVal(intk)
            arrBool(intk) = "AND"
            arrField(intk) = "ITEMTYPE"
            arrVal(intk) = Trim(ddlItemType.SelectedValue)
            intk = intk + 1

            objBFormingSQL.FieldArr = arrField
            objBFormingSQL.ValArr = arrVal
            objBFormingSQL.BoolArr = arrBool

            objBCDBS.SQLStatement = objBFormingSQL.FormingASQL(100)
            tblTemp = objBCDBS.RetrieveItemInfor()
            intTotalItem = tblTemp.Rows.Count
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                Call ShowControls(True)
                lblResult.Text = intTotalItem
                ' Set the strIDs variables to null
                strIDs = ""

                ' Get the string of ID found separated by the comma character
                For intIndex = 0 To intTotalItem - 1
                    strIDs = strIDs & tblTemp.Rows(intIndex).Item("ID") & ","
                Next
                If strIDs <> "" Then
                    strIDs = Left(strIDs, Len(strIDs) - 1)
                End If

                tblTemp.Clear()

                ' Get the IDs string (objBIC)
                objBIC.ItemIDs = strIDs
                tblTemp = objBIC.GetItemDetailInfor
                ' Get content of record and show in table
                If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                    arrItemID = Split(strIDs, ",")

                    ' Create header of result table
                    ' Add image
                    tblRow = New TableRow
                    tblCell = New TableCell
                    lblTemp = New Label
                    lblTemp.Text = ddlLabel.Items(3).Text.Trim
                    tblCell.Controls.Add(lblTemp)
                    tblCell.Width = Unit.Percentage(7)
                    tblRow.Cells.Add(tblCell)

                    ' Add text
                    tblCell = New TableCell
                    lblTemp = New Label
                    lblTemp.Text = ddlLabel.Items(4).Text.Trim
                    tblCell.Controls.Add(lblTemp)
                    tblRow.Cells.Add(tblCell)

                    tblRow.CssClass = "lbGridHeader"
                    tblResult.Rows.Add(tblRow)

                    For intIndex = LBound(arrItemID) To UBound(arrItemID)
                        strISBD = ""
                        strAdded = ""
                        ' Get author
                        dtRow = tblTemp.Select("ItemID = " & CLng(arrItemID(intIndex)) & " AND FieldCode = '100'")
                        If dtRow.Length > 0 Then
                            strTemp = objBCSP.TheDisplayOne(objBCSP.TrimSubFieldCodes(dtRow(0).Item("Content").ToString.Trim))
                            strISBD = "<B>" & strTemp & "</B>."
                            strAdded = "$a" & strTemp
                        End If
                        tblTemp.Select()

                        ' Get title
                        dtRow = tblTemp.Select("ItemID = " & CLng(arrItemID(intIndex)) & " AND FieldCode = '245'")
                        If dtRow.Length > 0 Then
                            strTemp = objBCSP.ConvertIt(dtRow(0).Item("Content").ToString.Trim)
                            If InStr(strTemp, "/$c") > 0 Then
                                strTemp = Left(strTemp, InStr(strTemp, "/$c") - 1)
                            End If
                            strTemp = objBCSP.TrimSubFieldCodes(objBCSP.TheDisplayOne(strTemp))
                            strISBD = strISBD & strTemp & ". - "
                            strAdded = strAdded & "$t" & strTemp
                        End If
                        tblTemp.Select()

                        ' Get published edition
                        dtRow = tblTemp.Select("ItemID = " & CLng(arrItemID(intIndex)) & " AND FieldCode = '250'")
                        If dtRow.Length > 0 Then
                            strTemp = objBCSP.TheDisplayOne(objBCSP.TrimSubFieldCodes(dtRow(0).Item("Content").ToString.Trim))
                            strISBD = strISBD & strTemp & ". - "
                            strAdded = strAdded & "$b" & strTemp
                        End If
                        tblTemp.Select()

                        ' Get publish informations
                        dtRow = tblTemp.Select("ItemID = " & CLng(arrItemID(intIndex)) & " AND FieldCode = '260'")
                        If dtRow.Length > 0 Then
                            strTemp = objBCSP.TheDisplayOne(objBCSP.TrimSubFieldCodes(dtRow(0).Item("Content").ToString.Trim))
                            strISBD = strISBD & strTemp & ". - "
                            strAdded = strAdded & "$d" & strTemp
                        End If
                        tblTemp.Select()

                        ' Get physical information
                        dtRow = tblTemp.Select("ItemID = " & CLng(arrItemID(intIndex)) & " AND FieldCode = '300'")
                        If dtRow.Length > 0 Then
                            strTemp = objBCSP.TheDisplayOne(objBCSP.TrimSubFieldCodes(dtRow(0).Item("Content").ToString.Trim))
                            strISBD = strISBD & strTemp & ". - "
                            strAdded = strAdded & "$h" & strTemp
                        End If
                        tblTemp.Select()

                        If Not strISBD.Trim = "" Then
                            strISBD = Left(strISBD, strISBD.Length - 4)
                            ' strAdded = Left(strAdded, strAdded.Length - 4)
                        End If

                        strAdded = strAdded & "$w" & arrItemID(intIndex)
                        strAdded = strAdded.Replace("'", "\'")

                        ' Add data to table
                        tblRow = New TableRow
                        tblCell = New TableCell

                        ' Add image
                        'imgTemp = New Web.UI.WebControls.Image
                        'imgTemp.ImageUrl = "../../Images/select.jpg"
                        'imgTemp.Attributes.Add("OnClick", "javascript:ReLoadData('" & hidFieldCode.Value.Trim & "', '" & strAdded & "')")
                        lnkTemp = New Web.UI.WebControls.HyperLink
                        lnkTemp.ImageUrl = "../../Images/select.jpg"
                        lnkTemp.NavigateUrl = "javascript:ReLoadData('" & hidFieldCode.Value.Trim & "', '" & strAdded & "')"
                        tblCell.Controls.Add(lnkTemp)
                        tblCell.HorizontalAlign = HorizontalAlign.Center
                        tblRow.Cells.Add(tblCell)

                        ' Add text
                        tblCell = New TableCell
                        lblTemp = New Label
                        lblTemp.Text = strISBD
                        lblTemp.CssClass = "lbLabel"
                        tblCell.Controls.Add(lblTemp)
                        tblRow.Cells.Add(tblCell)

                        If (intIndex Mod 2) = 1 Then
                            tblRow.CssClass = "lbGridCell"
                        Else
                            tblRow.CssClass = "lbGridAlterCell"
                        End If
                        tblResult.Rows.Add(tblRow)
                    Next
                End If
            Else
                Call ShowControls(False)
                Page.RegisterClientScriptBlock("AlterJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(5).Text.Trim & "');</script>")
            End If
        End Sub

        ' Method: ShowControls
        Private Sub ShowControls(ByVal blnShow As Boolean)
            lblCap.Visible = blnShow
            lblCapResult.Visible = blnShow
            lblResult.Visible = blnShow
            lblCapResult.Visible = blnShow
            tblResult.Visible = blnShow
        End Sub

        ' Event: btnSearch_Click
        ' Purpose: Search items
        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            Call SearchItem()
        End Sub

        ' Page_Unload Method
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Release all object
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBFormingSQL Is Nothing Then
                    objBFormingSQL.Dispose(True)
                    objBFormingSQL = Nothing
                End If
                If Not objBIC Is Nothing Then
                    objBIC.Dispose(True)
                    objBIC = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace