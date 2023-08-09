' Class: WACQRequest
' Puspose: process request
' Creator: Oanhtn
' CreatedDate: 10/04/2005
' Modification History:

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports OfficeOpenXml
Imports eMicLibAdmin.BusinessRules.Circulation
Imports System.Data
Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WACQRequest
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
        Private objBCommonBusiness As New clsBCommonBusiness
        Private objBItemOrder As New clsBItemOrder
        Private objBLoanType As New clsBLoanType
        Private objBCheckExistItem As New clsBCheckExistItem1
        Private intRequestID As Integer = 0
        Private List3Match As ArrayList = New ArrayList()
        Private List2Match As ArrayList = New ArrayList()
        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
            BindJS()
        End Sub
        ' CheckFormPermission method
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            ' Gui don dat
            If Not CheckPemission(32) Then
                Call WriteErrorMssg(ddlLabel.Items(7).Text)
            End If
        End Sub
        ' Method: Initialize
        ' Purpose: init all objects
        Private Sub Initialize()
            ' Init for objBItemOrder
            objBItemOrder.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemOrder.DBServer = Session("DBServer")
            objBItemOrder.ConnectionString = Session("ConnectionString")
            Call objBItemOrder.Initialize()

            ' Init objBCommonBusiness object
            objBCommonBusiness.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonBusiness.DBServer = Session("DBServer")
            objBCommonBusiness.ConnectionString = Session("ConnectionString")
            Call objBCommonBusiness.Initialize()

            ' Init objBLoanType object
            objBLoanType.InterfaceLanguage = Session("InterfaceLanguage")
            objBLoanType.DBServer = Session("DBServer")
            objBLoanType.ConnectionString = Session("ConnectionString")
            Call objBLoanType.Initialize()

            objBCheckExistItem.InterfaceLanguage = Session("InterfaceLanguage")
            objBCheckExistItem.DBServer = Session("DBServer")
            objBCheckExistItem.ConnectionString = Session("ConnectionString")
            Call objBCheckExistItem.Initialize()

            txtRequester.Text = clsSession.GlbUserFullName
        End Sub

        ' Method: BindJS
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("AcqRequestJs", "<script language = 'javascript' src = '../Js/PO/WAcqRequest.js'></script>")

            lnkCheckExists.NavigateUrl = "javascript:if (!CheckNull(document.forms[0].txtTitle)) {OpenWindow('WCheckExistItem.aspx?Title='+ Esc(document.forms[0].txtTitle.value" & ",'" & Session("InterfaceLanguage") & "') + '&Single=true','CheckItem',565,456,20,40);}"
            'lnkRequest.NavigateUrl = "WAcqSRequest.aspx"

            'Me.SetOnclickZ3950(btnZ3950, "../..")
            btnZ3950.Attributes.Add("OnClick", "OpenWindow('../../Common/WZForm.aspx','ZWin',700,360,50,100); return false;")
            btnInsert.Attributes.Add("OnClick", "if (!CheckRequest()) {alert('" & ddlLabel.Items(4).Text & "'); return false;}")
            btnReset.Attributes.Add("OnClick", "document.forms[0].txtRequester.value='" & clsSession.GlbUserFullName & "';")
            Me.SetCheckNumber(txtRequestedCopies, ddlLabel.Items(5).Text)
            Me.SetCheckNumberCurrency(txtUnitPrice, ddlLabel.Items(5).Text)
        End Sub

        ' Method: BindData
        Private Sub BindData()
            ' Get ID
            If Not Request("ID") = "" Then
                intRequestID = Request("ID")
                txtRequestID.Value = Request("ID")
            Else
                If Not txtRequestID.Value = "" Then
                    intRequestID = txtRequestID.Value
                End If
            End If

            Dim tblTemp As New DataTable
            Dim dblUnitPrice As Double
            Dim strCurrency As String
            Dim strNote As String
            Dim strISBN As String
            Dim strEdition As String
            Dim strPubYear As String
            Dim strPublisher As String
            Dim strRequestedCopies As String
            Dim strAuthor As String
            Dim strRequester As String
            Dim intUrgency As Integer
            Dim intLanguageID As Integer
            Dim intCountryID As Integer
            Dim intMediumID As Integer
            Dim inti As Integer

            ' Language dropdownlist
            tblTemp = objBCommonBusiness.GetLanguages
            ddlLanguage.DataSource = tblTemp
            ddlLanguage.DataTextField = "Language"
            ddlLanguage.DataValueField = "ID"
            ddlLanguage.DataBind()
            For inti = 0 To tblTemp.Rows.Count - 1
                If CStr(tblTemp.Rows(inti).Item("ISOCode")).ToLower = "vi" Then
                    ddlLanguage.SelectedIndex = inti
                    Exit For
                End If
            Next
            ddlLanguageFind.DataSource = tblTemp
            ddlLanguageFind.DataTextField = "DisplayEntry"
            ddlLanguageFind.DataValueField = "ID"
            ddlLanguageFind.DataBind()
            tblTemp.Clear()

            ' Country dropdownlist
            tblTemp = objBCommonBusiness.GetCountries
            ddlCountry.DataSource = tblTemp
            ddlCountry.DataTextField = "Country"
            ddlCountry.DataValueField = "ID"
            ddlCountry.DataBind()
            For inti = 0 To tblTemp.Rows.Count - 1
                If CStr(tblTemp.Rows(inti).Item("ISOCode")).ToLower = "vm" Or CStr(tblTemp.Rows(inti).Item("ISOCode")).ToLower = "vn" Then
                    ddlCountry.SelectedIndex = inti
                    Exit For
                End If
            Next
            ddlCountryFind.DataSource = tblTemp
            ddlCountryFind.DataTextField = "DisplayEntry"
            ddlCountryFind.DataValueField = "ID"
            ddlCountryFind.DataBind()

            tblTemp.Clear()

            ' ItemType dropdownlist
            tblTemp = objBCommonBusiness.GetItemTypes
            ddlItemType.DataSource = tblTemp
            ddlItemType.DataTextField = "Type"
            ddlItemType.DataValueField = "ID"
            ddlItemType.DataBind()
            For inti = 0 To tblTemp.Rows.Count - 1
                If CStr(tblTemp.Rows(inti).Item("TypeCode")).ToLower = "sh" Then
                    ddlItemType.SelectedIndex = inti
                    Exit For
                End If
            Next
            ddlItemTypeFind.DataSource = tblTemp
            ddlItemTypeFind.DataTextField = "TypeName"
            ddlItemTypeFind.DataValueField = "ID"
            ddlItemTypeFind.DataBind()

            tblTemp.Clear()

            objBLoanType.LibID = clsSession.GlbSite
            tblTemp = objBLoanType.GetLoanTypes
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlLoanType.DataSource = tblTemp
                ddlLoanType.DataTextField = "LoanType"
                ddlLoanType.DataValueField = "ID"
                ddlLoanType.DataBind()
                tblTemp.Clear()
            End If

            tblTemp.Clear()

            ' Medium dropdownlist
            tblTemp = objBCommonBusiness.GetMediums
            ddlMedium.DataSource = tblTemp
            ddlMedium.DataTextField = "Medium"
            ddlMedium.DataValueField = "ID"
            ddlMedium.DataBind()
            For inti = 0 To tblTemp.Rows.Count - 1
                If CStr(tblTemp.Rows(inti).Item("Code")).ToLower = "g" Then
                    ddlMedium.SelectedIndex = inti
                    Exit For
                End If
            Next
            ddlMediumFind.DataSource = tblTemp
            ddlMediumFind.DataTextField = "Description"
            ddlMediumFind.DataValueField = "ID"
            ddlMediumFind.DataBind()
            tblTemp.Clear()

            ' AcqSource ddropdownlist
            tblTemp = objBCommonBusiness.GetAcqSources
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlAcqSource.DataSource = tblTemp
                ddlAcqSource.DataTextField = "Source"
                ddlAcqSource.DataValueField = "ID"
                ddlAcqSource.DataBind()
                tblTemp.Clear()
            End If
            tblTemp.Clear()

            ' Currency dropdownlist
            tblTemp = objBCommonBusiness.GetCurrency
            ddlCurrency.DataSource = tblTemp
            ddlCurrency.DataTextField = "CurrencyCode"
            ddlCurrency.DataValueField = "CurrencyCode"
            ddlCurrency.DataBind()
            For inti = 0 To tblTemp.Rows.Count - 1
                If CStr(tblTemp.Rows(inti).Item("CurrencyCode")).ToLower = "vnd" Then
                    ddlCurrency.SelectedIndex = inti
                    Exit For
                End If
            Next
            tblTemp.Clear()

            ' Load Po's information to update
            If intRequestID > 0 Then
                objBItemOrder.RequestID = intRequestID
                tblTemp = objBItemOrder.GetOrderItems()
                If Not tblTemp Is Nothing Then
                    If tblTemp.Rows.Count > 0 Then
                        txtTitle.Text = tblTemp.Rows(0).Item("Title")
                        If Not IsDBNull(tblTemp.Rows(0).Item("Author")) Then
                            txtAuthor.Text = tblTemp.Rows(0).Item("Author")
                        End If
                        If Not IsDBNull(tblTemp.Rows(0).Item("Edition")) Then
                            txtEdition.Text = tblTemp.Rows(0).Item("Edition")
                        End If
                        If Not IsDBNull(tblTemp.Rows(0).Item("Publisher")) Then
                            txtPublisher.Text = tblTemp.Rows(0).Item("Publisher")
                        End If
                        If Not IsDBNull(tblTemp.Rows(0).Item("ISBN")) Then
                            txtISBN.Text = tblTemp.Rows(0).Item("ISBN")
                        End If
                        If Not IsDBNull(tblTemp.Rows(0).Item("Requester")) Then
                            txtRequester.Text = tblTemp.Rows(0).Item("Requester")
                        End If
                        If Not IsDBNull(tblTemp.Rows(0).Item("Note")) Then
                            txtNote.Text = tblTemp.Rows(0).Item("Note")
                        End If
                        If Not IsDBNull(tblTemp.Rows(0).Item("RequestedCopies")) Then
                            txtRequestedCopies.Text = tblTemp.Rows(0).Item("RequestedCopies")
                        End If
                        If Not IsDBNull(tblTemp.Rows(0).Item("UnitPrice")) Then
                            txtUnitPrice.Text = Trim(Str(tblTemp.Rows(0).Item("UnitPrice")))
                            txtUnitPrice.Text = If(Not (txtUnitPrice.Text = "0"), CDbl(txtUnitPrice.Text).ToString("#,##"), "0")
                        End If
                        If Not IsDBNull(tblTemp.Rows(0).Item("PubYear")) Then
                            txtPubYear.Text = tblTemp.Rows(0).Item("PubYear")
                        End If
                        If Not IsDBNull(tblTemp.Rows(0).Item("AdditionalBy")) Then
                            txtAdditionalBy.Text = tblTemp.Rows(0).Item("AdditionalBy")
                        End If
                        Call BindLanguage(CInt(tblTemp.Rows(0).Item("LanguageID")))
                        Call BindCountry(CInt(tblTemp.Rows(0).Item("CountryID")))
                        Call BindItemType(CInt(tblTemp.Rows(0).Item("ItemTypeID")))
                        Call BindMedium(CInt(tblTemp.Rows(0).Item("MediumID")))
                        Call BindCurrency(CStr(tblTemp.Rows(0).Item("Currency")))
                        Call BindUrgency(CInt(tblTemp.Rows(0).Item("Urgency")))
                    End If
                End If
            End If

            ' Release object
            tblTemp.Dispose()
            tblTemp = Nothing
        End Sub

        ' Method: BindCurrency
        Private Sub BindCurrency(ByVal strInput As String)
            Dim intIndex As Integer
            Dim tblTemp As New DataTable

            tblTemp = objBCommonBusiness.GetCurrency
            For intIndex = 0 To tblTemp.Rows.Count - 1
                If Trim(tblTemp.Rows(intIndex).Item("CurrencyCode")) = Trim(strInput) Then
                    ddlCurrency.SelectedIndex = intIndex
                    Exit For
                End If
            Next
            ' Release objects
            tblTemp.Dispose()
            tblTemp = Nothing
        End Sub

        ' Bind Urgency
        Private Sub BindUrgency(ByVal intUrgency As Integer)
            ddlUrgency.SelectedIndex = intUrgency - 1
        End Sub

        ' Method: BindLanguage
        Private Sub BindLanguage(ByVal intLanguageID As Integer)
            Dim intIndex As Integer
            Dim tblTemp As New DataTable

            tblTemp = objBCommonBusiness.GetLanguages
            For intIndex = 0 To tblTemp.Rows.Count - 1
                If CInt(tblTemp.Rows(intIndex).Item("ID")) = intLanguageID Then
                    ddlLanguage.SelectedIndex = intIndex
                    Exit For
                End If
            Next
            ' Release objects
            tblTemp.Dispose()
            tblTemp = Nothing
        End Sub

        ' Method: BindCountry
        Private Sub BindCountry(ByVal intCountryID As Integer)
            Dim intIndex As Integer
            Dim tblTemp As New DataTable

            tblTemp = objBCommonBusiness.GetCountries
            For intIndex = 0 To tblTemp.Rows.Count - 1
                If CInt(tblTemp.Rows(intIndex).Item("ID")) = intCountryID Then
                    ddlCountry.SelectedIndex = intIndex
                    Exit For
                End If
            Next
            ' Release objects
            tblTemp.Dispose()
            tblTemp = Nothing
        End Sub

        ' Method: BindMedium
        Private Sub BindMedium(ByVal intMediumID As Integer)
            Dim intIndex As Integer
            Dim tblTemp As New DataTable

            tblTemp = objBCommonBusiness.GetMediums
            For intIndex = 0 To tblTemp.Rows.Count - 1
                If CInt(tblTemp.Rows(intIndex).Item("ID")) = intMediumID Then
                    ddlMedium.SelectedIndex = intIndex
                    Exit For
                End If
            Next
            ' Release objects
            tblTemp.Dispose()
            tblTemp = Nothing
        End Sub

        ' Method: BindItemType
        Private Sub BindItemType(ByVal intTypeID As Integer)
            Dim intIndex As Integer
            Dim tblTemp As New DataTable

            tblTemp = objBCommonBusiness.GetItemTypes
            For intIndex = 0 To tblTemp.Rows.Count - 1
                If Trim(tblTemp.Rows(intIndex).Item("ID")) = intTypeID Then
                    ddlItemType.SelectedIndex = intIndex
                    Exit For
                End If
            Next
            ' Release objects
            tblTemp.Dispose()
            tblTemp = Nothing
        End Sub

        ' Event: btnInsert_Click
        ' Purpose: Insert/Update request
        Private Sub btnInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsert.Click
            Dim intRetVal As Integer
            Dim decUnitPrice As Decimal = 0
            Dim intRequestedCopies As Integer = 0
            Dim strInsertStatement As String

            If Not Trim(txtUnitPrice.Text) = "" Then
                If IsNumeric(txtUnitPrice.Text) Then decUnitPrice = CDec(txtUnitPrice.Text.Trim.Replace(".", ""))
                'decUnitPrice = CDec(Trim(txtUnitPrice.Text))
            End If
            If Not Trim(txtRequestedCopies.Text) = "" Then
                intRequestedCopies = CInt(txtRequestedCopies.Text)
            End If

            ' Get ID
            If Not Request("ID") = "" Then
                intRequestID = Request("ID")
                txtRequestID.Value = Request("ID")
            Else
                If Not txtRequestID.Value = "" Then
                    intRequestID = txtRequestID.Value
                End If
            End If

            objBItemOrder.RequestID = intRequestID
            objBItemOrder.UnitPrice = decUnitPrice
            objBItemOrder.Note = txtNote.Text
            objBItemOrder.ISBN = txtISBN.Text
            objBItemOrder.Edition = txtEdition.Text
            objBItemOrder.PubYear = txtPubYear.Text
            objBItemOrder.Requester = txtRequester.Text
            objBItemOrder.Publisher = txtPublisher.Text
            objBItemOrder.RequestedCopies = intRequestedCopies
            objBItemOrder.Author = txtAuthor.Text
            objBItemOrder.Title = txtTitle.Text
            objBItemOrder.MediumID = ddlMedium.SelectedValue
            objBItemOrder.Urgency = ddlUrgency.SelectedValue
            objBItemOrder.Currency = ddlCurrency.SelectedValue
            objBItemOrder.TypeID = 1 ' Not Searials
            objBItemOrder.LanguageID = ddlLanguage.SelectedValue
            objBItemOrder.CountryID = ddlCountry.SelectedValue
            objBItemOrder.ItemTypeID = ddlItemType.SelectedValue
            objBItemOrder.AdditionalBy = txtAdditionalBy.Text
            objBItemOrder.AcqSourceID = ddlAcqSource.SelectedValue
            objBItemOrder.LoanTypeID = ddlLoanType.SelectedValue
            objBItemOrder.LibID = clsSession.GlbSite

            If intRequestID > 0 Then
                intRetVal = objBItemOrder.Update
                ' WriteLog
                Call WriteLog(38, ddlLabel.Items(6).Text & " " & txtTitle.Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                If intRetVal = 0 Then
                    Page.RegisterClientScriptBlock("Success", "<Script language='JavaScript'>alert('" & ddlLabel.Items(3).Text & "'); opener.location.href=opener.location.href; self.close();</Script>")
                Else
                    Page.RegisterClientScriptBlock("Fail", "<Script language='JavaScript'>alert('" & ddlLabel.Items(2).Text & "'); opener.location.href=opener.location.href; self.close();</Script>")
                End If
                'Call BindData()
            Else
                intRetVal = objBItemOrder.Create
                ' WriteLog
                Call WriteLog(38, ddlLabel.Items(6).Text & " " & txtTitle.Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                If intRetVal = 0 Then
                    Page.RegisterClientScriptBlock("Success", "<Script language='JavaScript'>alert('" & ddlLabel.Items(3).Text & "');</Script>")
                Else
                    Page.RegisterClientScriptBlock("Fail", "<Script language='JavaScript'>alert('" & ddlLabel.Items(2).Text & "');</Script>")
                End If
            End If
            strInsertStatement = objBItemOrder.SQL
            Call Reset()
        End Sub
        Private Sub Reset()
            txtTitle.Text = ""
            txtAuthor.Text = ""
            txtEdition.Text = ""
            txtPublisher.Text = ""
            txtISBN.Text = ""
            txtNote.Text = ""
            txtPubYear.Text = ""
            txtRequestedCopies.Text = 1
            txtUnitPrice.Text = 0
        End Sub

        ' Event: btnReset_Click
        ' Purpose: Reset form's data
        Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
            txtTitle.Text = ""
            txtAuthor.Text = ""
            txtEdition.Text = ""
            txtPublisher.Text = ""
            txtISBN.Text = ""
            txtNote.Text = ""
            txtRequestedCopies.Text = 1
            txtUnitPrice.Text = 0
            txtPubYear.Text = ""
            BindData()
        End Sub

        ' Page_Unload Method
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: Release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCommonBusiness Is Nothing Then
                    objBCommonBusiness.Dispose(True)
                    objBCommonBusiness = Nothing
                End If
                If Not objBItemOrder Is Nothing Then
                    objBItemOrder.Dispose(True)
                    objBItemOrder = Nothing
                End If
                If Not objBLoanType Is Nothing Then
                    objBLoanType.Dispose(True)
                    objBLoanType = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub


        Protected Sub btnImportData_Click(sender As Object, e As EventArgs) Handles btnImportData.Click
            Try
                If (FileUpload1.HasFile AndAlso (IO.Path.GetExtension(FileUpload1.FileName) = ".xlsx" Or IO.Path.GetExtension(FileUpload1.FileName) = ".xls")) Then
                    Using excel = New ExcelPackage(FileUpload1.PostedFile.InputStream)
                        Dim tbl = New DataTable()
                        Dim ws = excel.Workbook.Worksheets.First()
                        Dim hasHeader = True ' change it if required '


                        ' create DataColumns '
                        For Each firstRowCell In ws.Cells(1, 1, 1, ws.Dimension.End.Column)
                            Dim itemDDL As ListItem = ddlColumnFileImport.Items.FindByText(firstRowCell.Text)

                            tbl.Columns.Add(If(hasHeader, itemDDL.Value, String.Format("Column {0}", firstRowCell.Start.Column)))
                        Next

                        ' add rows to DataTable '
                        Dim startRow As Integer = If(hasHeader, 1, 1)
                        For rowNum = startRow To ws.Dimension.End.Row
                            Dim wsRow = ws.Cells(rowNum, 1, rowNum, ws.Dimension.End.Column)
                            Dim row = tbl.NewRow()

                            Dim isAdd As Boolean = True
                            Dim intIndex As Integer = 0

                            For Each cell In wsRow
                                If (intIndex = 0) AndAlso (cell.Text = "") Then
                                    isAdd = False
                                    Exit For
                                Else
                                    row(cell.Start.Column - 1) = cell.Text
                                End If
                                intIndex = intIndex + 1
                            Next
                            If isAdd Then
                                tbl.Rows.Add(row)
                            End If
                        Next

                        'Dim i = 0
                        Dim listError As New List(Of String) ' Danh sách insert ko được

                        Dim countTotalRecordInput As Integer = If(tbl.Rows.Count - 1 <= 0, 0, tbl.Rows.Count - 1) 'Tổng dòng nhập từ file excel
                        Dim countSusscess As Integer = 0  'Tổng dòng thực hiện thành công

                        lbTotalInput.Text = "<i>" & ddlLabelImport.Items(0).Text & "</i><b><u>" & countTotalRecordInput & "</u></b>"

                        Response.Write("<div class='lbLabel' style=' margin:0;top:250;left:0; width:100%;'>")
                        Response.Write("<p style='position:absolute; left:45%;'>" & ddlLabelImport.Items(1).Text & "<span id='pgbMain_label'>0%</span></p>")
                        Response.Write("<p style='padding-top:35px;'><table width='0%' border=2 bordercolor='white' id='pgbMain' bgcolor=blue><tr style='HEIGHT: 18px'><td></td></tr></table></p>")
                        Response.Write("</div>")

                        For i As Integer = 1 To tbl.Rows.Count - 1
                            Try
                                Dim row As DataRow = tbl.Rows(i)

                                Dim decUnitPrice As Decimal = 0
                                If Not Trim(row("UnitPrice") & "") = "" Then
                                    decUnitPrice = CDec(Trim(row("UnitPrice")))
                                End If

                                Dim intRequestedCopies As Integer = 0
                                If Not Trim(row("RequestedCopies") & "") = "" Then
                                    intRequestedCopies = CInt(row("RequestedCopies"))
                                End If

                                Dim strNote As String = ""
                                If Not Trim(row("Note") & "") = "" Then
                                    strNote = row("Note")
                                End If

                                Dim strRequester As String = ""
                                If Not Trim(row("Requester") & "") = "" Then
                                    strRequester = row("Requester")
                                End If

                                Dim strISBN As String = ""
                                If Not Trim(row("ISBN") & "") = "" Then
                                    strISBN = row("ISBN")
                                End If

                                Dim strEdition As String = ""
                                If Not Trim(row("Edition") & "") = "" Then
                                    strEdition = row("Edition")
                                End If

                                Dim strPubYear As String = ""
                                If Not Trim(row("PubYear") & "") = "" Then
                                    strPubYear = row("PubYear")
                                End If

                                Dim strPublisher As String = ""
                                If Not Trim(row("Publisher") & "") = "" Then
                                    strPublisher = row("Publisher")
                                End If

                                Dim strAuthor As String = ""
                                If Not Trim(row("Author") & "") = "" Then
                                    strAuthor = row("Author")
                                End If

                                Dim strTitle As String = ""
                                If Not Trim(row("Title") & "") = "" Then
                                    strTitle = row("Title")
                                End If

                                Dim strAdditionalBy As String = ""
                                If Not Trim(row("AdditionalBy") & "") = "" Then
                                    strAdditionalBy = row("AdditionalBy")
                                End If

                                Dim itemDDL As New ListItem()

                                Dim strMedium As String = "Giấy"
                                If Not Trim(row("Medium") & "") = "" Then
                                    strMedium = row("Medium")
                                End If
                                itemDDL = ddlMediumFind.Items.FindByText(strMedium)
                                Dim intMediumID As Integer = 3 '- Vat mang tin
                                If Not IsNothing(itemDDL) Then
                                    intMediumID = itemDDL.Value
                                End If

                                Dim strUrgency As String = ""
                                If Not Trim(row("Urgency") & "") = "" Then
                                    strUrgency = row("Urgency")
                                End If
                                itemDDL = ddlUrgency.Items.FindByText(strUrgency)
                                Dim intUrgency As Integer = 1 '- Muc do quan trong
                                If Not IsNothing(itemDDL) Then
                                    intUrgency = itemDDL.Value
                                End If

                                Dim strCurrency As String = "VND" '- Don vi tinh
                                If Not Trim(row("Currency") & "") = "" Then
                                    strCurrency = row("Currency")
                                End If
                                itemDDL = ddlCurrency.Items.FindByText(strCurrency)
                                If Not IsNothing(itemDDL) Then
                                    strCurrency = itemDDL.Value
                                End If

                                Dim strLanguage As String = ""
                                If Not Trim(row("Language") & "") = "" Then
                                    strLanguage = row("Language")
                                End If
                                itemDDL = ddlLanguageFind.Items.FindByText(strLanguage)
                                Dim intLanguage As Integer = 22 '- Ngon ngu
                                If Not IsNothing(itemDDL) Then
                                    intLanguage = itemDDL.Value
                                End If

                                Dim strCountry As String = ""
                                If Not Trim(row("Country") & "") = "" Then
                                    strCountry = row("Country")
                                End If
                                itemDDL = ddlCountryFind.Items.FindByText(strCountry)
                                Dim intCountry As Integer = 209 '- Nuoc xuat ban
                                If Not IsNothing(itemDDL) Then
                                    intCountry = itemDDL.Value
                                End If

                                Dim strItemType As String = ""
                                If Not Trim(row("ItemType") & "") = "" Then
                                    strItemType = row("ItemType")
                                End If
                                itemDDL = ddlItemTypeFind.Items.FindByText(strItemType)
                                Dim intItemType As Integer = 1 '- Dang tai lieu
                                If Not IsNothing(itemDDL) Then
                                    intItemType = itemDDL.Value
                                End If

                                Dim strLoanType As String = ""
                                If Not Trim(row("LoanType") & "") = "" Then
                                    strLoanType = row("LoanType")
                                End If
                                itemDDL = ddlLoanType.Items.FindByText(strLoanType)
                                Dim intLoanType As Integer = 1 '- Kieu tu lieu
                                If Not IsNothing(itemDDL) Then
                                    intLoanType = itemDDL.Value
                                End If

                                objBItemOrder.UnitPrice = decUnitPrice
                                objBItemOrder.Note = strNote
                                objBItemOrder.ISBN = strISBN
                                objBItemOrder.Edition = strEdition
                                objBItemOrder.PubYear = strPubYear
                                objBItemOrder.Requester = strRequester
                                objBItemOrder.Publisher = strPublisher
                                objBItemOrder.RequestedCopies = intRequestedCopies
                                objBItemOrder.Author = strAuthor
                                objBItemOrder.Title = strTitle
                                objBItemOrder.MediumID = intMediumID
                                objBItemOrder.Urgency = intUrgency
                                objBItemOrder.Currency = strCurrency
                                objBItemOrder.TypeID = 1 ' Not Searials
                                objBItemOrder.LanguageID = intLanguage
                                objBItemOrder.CountryID = intCountry
                                objBItemOrder.ItemTypeID = intItemType
                                objBItemOrder.LoanTypeID = intLoanType
                                objBItemOrder.AdditionalBy = strAdditionalBy
                                objBItemOrder.LibID = clsSession.GlbSite

                                Dim intRetVal As String = objBItemOrder.Create

                                If intRetVal = 0 Then

                                    countSusscess = countSusscess + 1

                                    lbSuccess.Text = "<i>" & ddlLabelImport.Items(2).Text & "</i><b><u>" & countSusscess & "</u></b>"

                                End If

                                Call BindPrg(i, tbl.Rows.Count)
                            Catch ex As Exception
                                listError.Add((i).ToString())
                            End Try
                        Next

                        If listError.Count > 0 Then
                            lblErrorDataCat.Text = ddlLabelImport.Items(3).Text
                            For Each item As String In listError
                                lblErrorDataCat.Text += item.ToString() + "; "
                            Next
                        Else
                            lblErrorDataCat.Text = ""
                        End If

                    End Using
                Else
                    lblErrorDataCat.Text = ddlLabelImport.Items(4).Text
                    lbSuccess.Text = ""
                    lbTotalInput.Text = ""
                    Return
                End If
            Catch ex As Exception

                lblErrorDataCat.Text = ddlLabelImport.Items(4).Text
                lbSuccess.Text = ""
                lbTotalInput.Text = ""
            End Try
        End Sub

        Private Function BindProgress(ByVal valueTimeLoop As String) As String
            Dim resultText As String = "<script type='text/javascript'> "
            resultText = resultText & "function move() {"
            resultText = resultText & "var elem = document.getElementById('myBar'); "
            resultText = resultText & "var width = 0; "
            resultText = resultText & "var id = setInterval(frame, " & valueTimeLoop & "); "
            resultText = resultText & "function frame() { "
            resultText = resultText & "if (width >= 100) { "
            resultText = resultText & "clearInterval(id); "
            resultText = resultText & "} else { "
            resultText = resultText & "width++; "
            resultText = resultText & "elem.style.width = width + '%'; "
            resultText = resultText & "elem.style.width = width + '%'; "
            resultText = resultText & "document.getElementById('label').innerHTML = width * 1 + '%'; "
            resultText = resultText & "}}} "
            resultText = resultText & "document.getElementById('myProgress').style.display = 'inherit'; "
            resultText = resultText & "move(); "
            resultText = resultText & "</script>"

            Return resultText
        End Function

        Public Sub BindPrg(ByVal intCurrent As Integer, ByVal intSum As Integer)
            Dim intCurrentPercent As Integer
            intCurrentPercent = ((intCurrent + 1) * 100) / intSum
            'System.Threading.Thread.Sleep(850)
            Response.Write("<script>if (pgbObj = document.getElementById('pgbMain')) pgbObj.width =" & intCurrentPercent & " + '%'; if (lblObj = document.getElementById('pgbMain_label')) lblObj.innerHTML =" & intCurrentPercent & " + '%';</script>")
            Response.Flush()
        End Sub

        Protected Sub btnDownloadFile_Click(sender As Object, e As EventArgs) Handles btnDownloadFile.Click
            Dim strTime As String = DateAndTime.Now.Year & DateAndTime.Now.Month & DateAndTime.Now.Day & DateAndTime.Now.Hour & DateAndTime.Now.Minute & DateAndTime.Now.Second & DateAndTime.Now.Millisecond
            Response.Clear()
            Response.AddHeader("content-disposition", "attachment;filename=Template_Import_BoSung_AnPhamDonBang" & strTime & ".xlsx")
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            Response.WriteFile(Server.MapPath("../../Template/Template_Import_BoSung_AnPhamDonBang.xlsx"))
            Response.Flush()
            Response.End()
        End Sub
        Protected Sub btnCheckFile_Click(sender As Object, e As EventArgs) Handles btnCheckFile.Click
            If (FileUpload1.HasFile AndAlso (IO.Path.GetExtension(FileUpload1.FileName) = ".xlsx" Or IO.Path.GetExtension(FileUpload1.FileName) = ".xls")) Then
                Dim tbl = New DataTable()
                Using excel = New ExcelPackage(FileUpload1.PostedFile.InputStream)

                    Dim ws = excel.Workbook.Worksheets.First()
                    Dim hasHeader = True ' change it if required '
                    ' create DataColumns '
                    For Each firstRowCell In ws.Cells(1, 1, 1, ws.Dimension.End.Column)
                        Dim itemDDL As ListItem = ddlColumnFileImport.Items.FindByText(firstRowCell.Text)
                        tbl.Columns.Add(If(hasHeader, itemDDL.Value, String.Format("Column {0}", firstRowCell.Start.Column)))
                    Next
                    ' add rows to DataTable '
                    Dim startRow As Integer = If(hasHeader, 1, 1)
                    For rowNum = startRow To ws.Dimension.End.Row
                        Dim wsRow = ws.Cells(rowNum, 1, rowNum, ws.Dimension.End.Column)
                        Dim row = tbl.NewRow()

                        Dim isAdd As Boolean = True
                        Dim intIndex As Integer = 0

                        For Each cell In wsRow
                            If (intIndex = 0) AndAlso (cell.Text = "") Then
                                isAdd = False
                                Exit For
                            Else
                                row(cell.Start.Column - 1) = cell.Text
                            End If
                            intIndex = intIndex + 1
                        Next
                        If isAdd Then
                            tbl.Rows.Add(row)
                        End If
                    Next

                End Using

                Call getRowsDuplicate(tbl)
                If List3Match.Count > 0 OrElse List2Match.Count > 0 Then
                    Dim strHTMLContent As New StringBuilder()
                    strHTMLContent.Append("<html xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:w='urn:schemas-microsoft-com:office:excel' xmlns='www.w3.org/TR/REC-html40'>")
                    strHTMLContent.Append("<head>")
                    strHTMLContent.Append("</head>")
                    strHTMLContent.Append("<body lang=EN-US style='tab-interval:.5in'>")
                    strHTMLContent.Append("<p>" & clsBExportHelper.GenToStringBuilderHighlightRowDuplicate(tbl, List3Match, List2Match).ToString() & "</p>")
                    strHTMLContent.Append("</div></body></html>")
                    clsExport.StringBuilderToExcel(strHTMLContent)
                Else
                    Page.RegisterClientScriptBlock("Message", "<Script language='JavaScript'>alert('Không có dữ liệu trùng!');</Script>")
                End If

            Else
                Page.RegisterClientScriptBlock("Warning!", "<Script language='JavaScript'>alert('Vui lòng chọn file cần kiểm tra!');</Script>")
            End If

        End Sub
        Public Function getRowsDuplicate(ByVal dTable As DataTable)
            Dim tableCopy As DataTable = dTable

            For i As Integer = 1 To dTable.Rows.Count - 1
                Dim drow As DataRow = dTable.Rows(i)
                Dim title = drow.Item("Title").ToString.Trim()
                Dim author = drow.Item("Author").ToString.Trim()
                Dim pubYear = drow.Item("PubYear").ToString.Trim()
                Dim stt = drow.Item("STT").ToString.Trim()
                Dim ItemID = objBCheckExistItem.CheckExitItem(title, author, CInt(pubYear))
                If ItemID > 0 Then
                    List3Match.Add(stt)
                ElseIf ItemID < 0 Then
                    List2Match.Add(stt)
                End If
                'For j As Integer = i + 1 To dTable.Rows.Count - 1
                '    Dim rowNext As DataRow = dTable.Rows(j)
                '    Dim titleNext = rowNext.Item("Title").ToString.Trim()
                '    Dim authorNext = rowNext.Item("Author").ToString.Trim()
                '    Dim pubYearNext = rowNext.Item("PubYear").ToString.Trim()

                '    If title = titleNext AndAlso author = authorNext AndAlso pubYear = pubYearNext Then
                '        Dim stt = drow.Item("STT").ToString.Trim()
                '        Dim sttNext = rowNext.Item("STT").ToString.Trim()
                '        If Not duplicateList.Contains(stt) Then
                '            duplicateList.Add(stt)
                '        End If
                '        If Not duplicateList.Contains(sttNext) Then
                '            duplicateList.Add(sttNext)
                '        End If
                '    End If
                'Next
            Next
        End Function
    End Class
End Namespace