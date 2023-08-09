Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WAddCopyNumber
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtCode As System.Web.UI.HtmlControls.HtmlInputHidden


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare BusinessRules and clsWCommon class variables
        Private objBCommonBusiness As New clsBCommonBusiness
        Private objBloanType As New clsBLoanType
        Private objBCopyNumber As New clsBCopyNumber
        Private objBInput As New clsBInput
        Private objBDB As New clsBCommonDBSystem

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindScript()
            If Not IsPostBack Then
                Call BindDropdownList()
                If CStr(Trim(Request("ItemCode"))) & "" <> "" Then
                    txtItemCode.Text = CStr(Trim(Request("ItemCode")))
                End If
            End If
            BinDropDownListPostBack()
            If (Not Page.IsPostBack) And CInt(Request("Update")) = 1 And Request("hidAddCopyNumber") & "" = "1" Then
                Call Catalog_Save()
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
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

            ' Init for objBCopyNumber
            objBCopyNumber.InterfaceLanguage = Session("InterfaceLanguage")
            objBCopyNumber.DBServer = Session("DBServer")
            objBCopyNumber.ConnectionString = Session("ConnectionString")
            objBCopyNumber.Initialize()

            ' Init for objBInput
            objBInput.InterfaceLanguage = Session("InterfaceLanguage")
            objBInput.DBServer = Session("DBServer")
            objBInput.ConnectionString = Session("ConnectionString")
            objBInput.Initialize()

            ' Init objBDB object
            objBDB.InterfaceLanguage = Session("InterfaceLanguage")
            objBDB.DBServer = Session("DBServer")
            objBDB.ConnectionString = Session("ConnectionString")
            Call objBDB.Initialize()
        End Sub

        ' CheckFormPermission method
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            ' Add new copy number right
            If Not CheckPemission(189) Then
                btnAdd.Enabled = False
            End If
            ' Add new Item
            If Not CheckPemission(188) Then
                lnkAdd.Visible = False
            End If
        End Sub

        ' BindScript method
        ' Purpose: Bind JAVASCRIPTS
        Private Sub BindScript()
            Dim strItemCode As String
            Dim strIf As String

            strIf = "if (eval(document.forms[0].txtItemCode).value!=""""){"
            strItemCode = "itemcode = eval(document.forms[0].txtItemCode).value;"
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = 'js/WAddCopyNumber.js'></script>")

            Dim tblPara As DataTable
            'Them nhanh bien muc so luoc 1 AP
            objBDB.SQLStatement = "SELECT Val FROM Sys_tblParameter  WHERE Name = 'QUICK_ADD_ITEM'"
            tblPara = objBDB.RetrieveItemInfor
            If tblPara.Rows(0).Item(0) = 1 Then
                lnkAdd.NavigateUrl = "WAddItem.aspx"
            Else
                lnkAdd.Visible = False
            End If
            'Them nhan ÐKCB
            tblPara.Clear()
            objBDB.SQLStatement = "SELECT Val FROM Sys_tblParameter  WHERE Name = 'QUICK_ADD_COPY'"
            tblPara = objBDB.RetrieveItemInfor
            If tblPara.Rows(0).Item(0) = 0 Then
                lnkSearch.Visible = False
                lnkView.Visible = False
            End If

            ' Add the attributes for the buttons
            btnReset.Attributes.Add("OnClick", "javascript:document.forms[0].reset(); document.forms[0].txtTitle.focus(); return false")
            lnkSearch.NavigateUrl = "javascript:OpenWindow('WSearchCopyNumber.aspx?SearchType=1','SearchCopyNumber',600,400,150,50)"
            lnkView.NavigateUrl = "javascript:var itemcode;" & strIf & strItemCode & "OpenWindow('WItemDetails.aspx?ItemType=1&ItemCode='+itemcode,'ViewItem',600,400,150,50);}"

            ddlLocation.Attributes.Add("OnChange", "document.forms[0].txtLocID.value=this.options[this.options.selectedIndex].value;")
            btnAdd.Attributes.Add("OnClick", "javascript:if(!CheckAll('" & LblMsg3.Text & "','" & LblMsg4.Text & "','" & LblMsg5.Text & "','" & lblMsg7.Text & "')) return false;")
            btnReset.Attributes.Add("OnClick", "javascript:document.forms[0].reset(); document.forms[0].txtItemCode.focus(); return false")
        End Sub

        ' BindDropDownList method
        ' Purpose: Get the Currency and LoanType
        Private Sub BindDropdownList()
            ' Declare variables
            Dim tblCurrency As DataTable
            Dim tblLoanType As DataTable

            objBCommonBusiness.CurrencyCode = ""
            tblCurrency = objBCommonBusiness.GetCurrency()
            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBCommonBusiness.ErrorMsg, ddlLabel.Items(1).Text, objBCommonBusiness.ErrorCode)

            objBloanType.LoanTypeID = 0
            objBloanType.LibID = clsSession.GlbSite
            tblLoanType = objBloanType.GetLoanTypes

            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBloanType.ErrorMsg, ddlLabel.Items(1).Text, objBloanType.ErrorCode)

            If Not tblCurrency Is Nothing Then
                If tblCurrency.Rows.Count > 0 Then
                    ' Currency Data
                    With ddlCurrency
                        .DataSource = tblCurrency
                        .DataTextField = "CurrencyCode"
                        .DataValueField = "CurrencyCode"
                        .DataBind()
                    End With
                End If
            End If

            If Not tblLoanType Is Nothing Then
                If tblLoanType.Rows.Count > 0 Then
                    ' Loan type data
                    With ddlLoanType
                        .DataSource = tblLoanType
                        .DataTextField = "LoanType"
                        .DataValueField = "ID"
                        .DataBind()
                    End With
                End If
            End If
        End Sub

        ' BinDropDownListPostBack method
        ' Purpose: Get the Holding Library and Holding Location that user manage
        Private Sub BinDropDownListPostBack()
            Dim intLibLocCount As Integer
            Dim tblUserLibrary As DataTable
            Dim tblUserLocation As DataTable
            Dim strScript As String = ""
            Dim intIndex As Integer
            objBCommonBusiness.LibID = clsSession.GlbSite
            tblUserLocation = objBCommonBusiness.GetLocations
            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBCommonBusiness.ErrorMsg, ddlLabel.Items(1).Text, objBCommonBusiness.ErrorCode)

            objBCommonBusiness.LibID = clsSession.GlbSite
            tblUserLibrary = objBCommonBusiness.GetLibraries(clsSession.GlbSite, -1, -1, Session("UserID"))
            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBCommonBusiness.ErrorMsg, ddlLabel.Items(1).Text, objBCommonBusiness.ErrorCode)

            tblUserLibrary = InsertOneRow(tblUserLibrary, lblSelectLib.Text)
            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, ErrorMsg, ddlLabel.Items(1).Text, ErrorCode)

            If Not tblUserLocation Is Nothing Then
                If tblUserLocation.Rows.Count > 0 Then
                    intLibLocCount = tblUserLocation.Rows.Count
                End If
            End If

            If Not tblUserLibrary Is Nothing Then
                If tblUserLibrary.Rows.Count > 0 Then
                    ' library data
                    With ddlLibrary
                        .DataSource = tblUserLibrary
                        .DataTextField = "FullName"
                        .DataValueField = "ID"
                        .DataBind()
                    End With
                End If
            End If

            ' bind javascript
            If intLibLocCount > 0 Then
                strScript = "<script Language='JavaScript'>"
                strScript = strScript & "InvName = new Array(" & intLibLocCount & ");" & Chr(10)
                strScript = strScript & "InvID = new Array(" & intLibLocCount & ");" & Chr(10)
                strScript = strScript & "LibID = new Array(" & intLibLocCount & ");" & Chr(10)
                For intIndex = 0 To intLibLocCount - 1
                    strScript = strScript & "LibID[" & intIndex & "] = " _
                    & tblUserLocation.Rows(intIndex).Item("LibID") & ";" & Chr(10)
                    strScript = strScript & "InvID[" & intIndex & "] = " _
                    & tblUserLocation.Rows(intIndex).Item("ID") & ";" & Chr(10)
                    strScript = strScript & "InvName[" & intIndex & "] = '" _
                    & tblUserLocation.Rows(intIndex).Item("Symbol") & "';" & Chr(10)
                Next
                strScript = strScript & "function FilterStore(lib) {" & Chr(10)
                strScript = strScript & "if (lib==0) {document.forms[0].txtLocID.value='';document.forms[0].txtLibID.value='';}else{document.forms[0].txtLibID.value=document.forms[0].ddlLibrary.options[document.forms[0].ddlLibrary.options.selectedIndex].value}" & Chr(10)
                strScript = strScript & "document.forms[0].ddlLocation.options.length = 0;" & Chr(10)
                strScript = strScript & "for (j = 0; j < LibID.length; j++) {" & Chr(10)
                strScript = strScript & "if (LibID[j] == lib) {" & Chr(10)
                strScript = strScript & "document.forms[0].ddlLocation.options.length = document.forms[0].ddlLocation.options.length + 1;" & Chr(10)
                strScript = strScript & "document.forms[0].ddlLocation.options[document.forms[0].ddlLocation.options.length - 1].value = InvID[j];" & Chr(10)
                strScript = strScript & "document.forms[0].ddlLocation.options[document.forms[0].ddlLocation.options.length - 1].text = InvName[j];" & Chr(10)
                strScript = strScript & "document.forms[0].txtLocID.value = document.forms[0].ddlLocation.options[0].value;" & Chr(10)
                strScript = strScript & "}}}" & Chr(10)
                strScript = strScript & "</script>" & Chr(10)
            End If

            Page.RegisterClientScriptBlock("ChangeLib", strScript)
            ddlLibrary.Attributes.Add("OnChange", "FilterStore(this.options[this.options.selectedIndex].value);")
        End Sub

        ' Catalog_Save method
        ' Purpose: Save the new Item
        Private Sub Catalog_Save()
            Dim intRetVal As Integer
            Dim ArrFieldName()
            Dim ArrFieldValue()
            ReDim ArrFieldName(4)
            ReDim ArrFieldValue(4)
            Dim dtvItem As DataView
            Dim tblType As DataTable
            Dim tblMedium As DataTable
            Dim tblForm As New DataTable
            Dim blnFound As Boolean
            Dim str020_a As String
            Dim str022_a As String
            Dim str245_a As String
            Dim str260_a As String
            Dim str260_b As String
            Dim str260_c As String
            Dim str300_a As String
            Dim intMainID As Integer
            Dim intCount As Integer
            Dim strISBN As String
            Dim str260 As String
            Dim str300 As String
            Dim intIndex As Integer

            ArrFieldName(0) = "000"
            ArrFieldValue(0) = "00000n" & Request("ddlRecType") & Request("ddlLevelDir") & " a22        4500"

            ' Item type
            If Request("ddlItemType") & "" <> "" Then
                tblType = objBCommonBusiness.GetItemTypes
                ' Write error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBCommonBusiness.ErrorMsg, ddlLabel.Items(1).Text, objBCommonBusiness.ErrorCode)
                If Not tblType Is Nothing Then
                    If tblType.Rows.Count > 0 Then
                        dtvItem = New DataView
                        dtvItem = tblType.DefaultView
                        dtvItem.RowFilter = "ID = " & Request("ddlItemType")
                        If dtvItem.Count > 0 Then
                            ' Type Code
                            If Not IsDBNull(dtvItem.Item(0).Item("TypeCode")) Then
                                ArrFieldName(1) = "927"
                                ArrFieldValue(1) = dtvItem.Item(0).Item("TypeCode")
                            End If
                        End If
                    End If
                End If
            End If

            ' Medium
            If Request("ddlMedium") & "" <> "" Then
                tblMedium = objBCommonBusiness.GetMediums
                ' Write error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBCommonBusiness.ErrorMsg, ddlLabel.Items(1).Text, objBCommonBusiness.ErrorCode)
                If Not tblMedium Is Nothing Then
                    If tblMedium.Rows.Count > 0 Then
                        dtvItem = New DataView
                        dtvItem = tblMedium.DefaultView
                        dtvItem.RowFilter = "ID = " & Request("ddlMedium")
                        If dtvItem.Count > 0 Then
                            ' Type Code
                            If Not IsDBNull(dtvItem.Item(0).Item("Code")) Then
                                ArrFieldName(2) = "925"
                                ArrFieldValue(2) = dtvItem.Item(0).Item("Code")
                            End If
                        End If
                    End If
                End If
            End If

            ArrFieldName(3) = "926"
            ArrFieldValue(3) = Request("ddlSecLevel")
            ArrFieldName(4) = "900"
            ArrFieldValue(4) = "True"

            str020_a = Request("txt020_a")
            str022_a = Request("txt022_a")
            str245_a = Request("txt245_a")
            str260_a = Request("txt260_a")
            str260_b = Request("txt260_b")
            str260_c = Request("txt260_c")
            str300_a = Request("txt300_a")

            ' 020 string
            If str020_a <> "" Then
                ReDim Preserve ArrFieldName(UBound(ArrFieldName) + 1)
                ReDim Preserve ArrFieldValue(UBound(ArrFieldValue) + 1)
                ArrFieldName(UBound(ArrFieldName)) = "020"
                ArrFieldValue(UBound(ArrFieldName)) = "  ::$a" & str020_a
            End If
            ' 022 string
            If str022_a <> "" Then
                ReDim Preserve ArrFieldName(UBound(ArrFieldName) + 1)
                ReDim Preserve ArrFieldValue(UBound(ArrFieldValue) + 1)
                ArrFieldName(UBound(ArrFieldName)) = "022"
                ArrFieldValue(UBound(ArrFieldName)) = "  ::$a" & str022_a
            End If

            ' Title
            str245_a = "00::$a" & str245_a

            ReDim Preserve ArrFieldName(UBound(ArrFieldName) + 1)
            ReDim Preserve ArrFieldValue(UBound(ArrFieldValue) + 1)

            ArrFieldName(UBound(ArrFieldName)) = "245"
            ArrFieldValue(UBound(ArrFieldValue)) = str245_a

            ' 260 string
            str260 = ""
            If str260_a <> "" Then
                str260 = str260 & "$a" & str260_a
            End If
            If str260_b <> "" Then
                str260 = str260 & " :$b" & str260_b
            End If
            If str260_c <> "" Then
                str260 = str260 & ",$c" & str260_c
            End If
            If str260 <> "" Then
                str260 = Trim(str260)
                If Not Left(str260, 1) = "" Then
                    str260 = Right(str260, Len(str260) - 1)
                End If
                ReDim Preserve ArrFieldName(UBound(ArrFieldName) + 1)
                ReDim Preserve ArrFieldValue(UBound(ArrFieldValue) + 1)
                ArrFieldName(UBound(ArrFieldName)) = "260"
                ArrFieldValue(UBound(ArrFieldValue)) = "  ::" & str260
            End If
            ' 300 string
            str300 = ""
            If str300_a <> "" Then
                str300 = str300 & "$a" & str300_a
            End If

            If str300 <> "" Then
                ReDim Preserve ArrFieldName(UBound(ArrFieldName) + 1)
                ReDim Preserve ArrFieldValue(UBound(ArrFieldValue) + 1)
                ArrFieldName(UBound(ArrFieldName)) = "300"
                ArrFieldValue(UBound(ArrFieldValue)) = "  ::" & str300
            End If

            ' Update
            objBInput.FieldName = ArrFieldName
            objBInput.FieldValue = ArrFieldValue

            If Not Request("ddlForm") & "" = "" Then
                If IsNumeric(Request("ddlForm")) Then
                    intRetVal = objBInput.Update(Request("ddlForm"), 0)
                End If
            End If

            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBInput.ErrorMsg, ddlLabel.Items(1).Text, objBInput.ErrorCode)

            If intRetVal = 1 Then
                Dim strCode As String
                strCode = objBInput.CodeOut
                txtItemCode.Text = Trim(strCode)
                Page.RegisterClientScriptBlock("jsConfirm1", "<script language='javascript'>alert('" & lblResult.Text & "');</script>")
                ' Write log
                WriteLog(114, ddlLabel.Items(2).Text & ": " & ddlLabel.Items(4).Text & ": " & Trim(txtItemCode.Text), Request.ServerVariables("SCRIPT_NAME"), CStr(Request.ServerVariables("Remote_Addr")), clsSession.GlbUserFullName)
            Else
                Page.RegisterClientScriptBlock("jsConfirm2", "<script language='javascript'>alert('" & lblFail.Text & "');</script>")
            End If


            intMainID = objBInput.WorkID

            strISBN = ""
            If str020_a <> "" Then
                strISBN = "ISSN:" & str020_a
            End If
            If str022_a <> "" Then
                If strISBN <> "" Then
                    strISBN = strISBN & " "
                End If
                strISBN = strISBN & "ISBN:" & str022_a
            End If
            tblForm.Dispose()
        End Sub

        ' Add new copy number
        Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
            Dim intOutPut As Int16

            objBCopyNumber.Code = Trim(txtItemCode.Text)
            objBCopyNumber.UserID = Trim(Session("UserID"))
            objBCopyNumber.CopyNumber = Trim(txtCopyNumber.Text)
            objBCopyNumber.Shelf = Trim(txtShelf.Text)
            objBCopyNumber.CallNumber = Trim(txtCallNumber.Text)
            objBCopyNumber.Price = Trim(txtCost.Text)
            objBCopyNumber.LibID = CInt(txtLibID.Value)
            objBCopyNumber.LocID = CInt(txtLocID.Value)
            objBCopyNumber.CurrencyCode = Trim(CStr(ddlCurrency.SelectedValue))
            If CInt(ddlLoanType.SelectedValue) = 0 Then
                objBCopyNumber.LoanTypeID = 1
            Else
                objBCopyNumber.LoanTypeID = CInt(ddlLoanType.SelectedValue)
            End If
            objBCopyNumber.AddCopyNumber()
            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBCopyNumber.ErrorMsg, ddlLabel.Items(1).Text, objBCopyNumber.ErrorCode)
            intOutPut = objBCopyNumber.OutPut

            ' Didplay the result
            If intOutPut = 0 Then
                Page.RegisterClientScriptBlock("jsAlert1", "<script language='javascript'>alert('" & LblMsg6.Text & "');parent.CheckOut.document.forms[0].txtCopyNumber.value='" & txtCopyNumber.Text & "';</script>")
                ' Write log
                WriteLog(113, ddlLabel.Items(3).Text & " (" & ddlLabel.Items(4).Text & ": " & Trim(txtItemCode.Text) & " - " & ddlLabel.Items(5).Text & ": " & Trim(txtCopyNumber.Text) & ")", Request.ServerVariables("SCRIPT_NAME"), CStr(Request.ServerVariables("Remote_Addr")), clsSession.GlbUserFullName)
            ElseIf intOutPut = 1 Then
                Page.RegisterClientScriptBlock("jsAlert2", "<script language='javascript'>alert('" & LblMsg1.Text & "');</script>")
            ElseIf intOutPut = 2 Then
                Page.RegisterClientScriptBlock("jsAlert3", "<script language='javascript'>alert('" & LblMsg2.Text & "');</script>")
            End If
            txtLocID.Value = ""
            txtLibID.Value = ""
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCommonBusiness Is Nothing Then
                    objBCommonBusiness.Dispose(True)
                    objBCommonBusiness = Nothing
                End If
                If Not objBloanType Is Nothing Then
                    objBloanType.Dispose(True)
                    objBloanType = Nothing
                End If
                If Not objBInput Is Nothing Then
                    objBInput.Dispose(True)
                    objBInput = Nothing
                End If
                If Not objBCopyNumber Is Nothing Then
                    objBCopyNumber.Dispose(True)
                    objBCopyNumber = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace