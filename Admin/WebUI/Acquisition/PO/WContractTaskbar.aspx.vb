' Class: WContractTaskbar
' Purpose: Navigator
' Creator: Oanhtn
' CreatedDate: 31/03/2005
' Modification history:

Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.WebUI

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WContractTaskbar
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
        Private objBPO As New clsBPurchaseOrder
        Private intCurrentID As Integer

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJavascript()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub
        ' CheckFormPermission method
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            ' Duyet don dat
            If Not CheckPemission(180) Then
                btnBrowse.Enabled = False
            End If
            'Tim kiem don dat
            If Not CheckPemission(181) Then
                btnFilter.Enabled = False
            End If
            'Quan ly don dat
            If Not CheckPemission(136) Then
                btnNew.Enabled = False
            End If
        End Sub
        ' Initialize method
        ' Purpose: Init all need objects
        Private Sub Initialize()
            ' Init objBPO object
            objBPO.InterfaceLanguage = Session("InterfaceLanguage")
            objBPO.DBServer = Session("DBServer")
            objBPO.ConnectionString = Session("ConnectionString")
            Call objBPO.Initialize()

            Session("FilterIDs") = Nothing
        End Sub

        ' BindJavascript method
        ' Purpose: include all neccessary objects
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("TaskbarJs", "<script language = 'javascript' src = '../Js/Po/WContract.js'></script>")

            btnNew.Attributes.Add("OnClick", "NewContract(); return false;")
            btnFilter.Attributes.Add("OnClick", "Filter(); return false;")
            btnMoveFirst.Attributes.Add("OnClick", "MoveFirst('" & ddlLabel.Items(2).Text & "'); return false;")
            btnMovePrev.Attributes.Add("OnClick", "MovePrev('" & ddlLabel.Items(2).Text & "'); return false;")
            btnMoveNext.Attributes.Add("OnClick", "MoveNext('" & ddlLabel.Items(3).Text & "'); return false;")
            btnMoveLast.Attributes.Add("OnClick", "MoveLast('" & ddlLabel.Items(3).Text & "'); return false;")
            btnBrowse.Attributes.Add("OnClick", "Browse(); return false;")

            txtCurrentID.Attributes.Add("OnChange", "Goto('" & ddlLabel.Items(4).Text & "', '" & ddlLabel.Items(5).Text & "');")
            txtCurrentID.Attributes.Add("onKeyDown", "if(event.keyCode == 13 || event.which == 13 ) { Goto('" & ddlLabel.Items(4).Text & "', '" & ddlLabel.Items(5).Text & "');return false;}")
        End Sub

        ' Method: BindData
        Private Sub BindData()
            Dim intTotalContracts As Integer
            objBPO.LibID = clsSession.GlbSite
            intTotalContracts = objBPO.GetTotalContracts

            If intTotalContracts > 0 Then
                txtMaxID.Text = intTotalContracts
                txtCurrentID.Text = 1
                If Request.QueryString("isContract") & "" <> "" Then
                    Page.RegisterClientScriptBlock("LoadWorkForm", "<script language='javascript'>parent.workform.location.href='WContractDetail.aspx?ContractID=" & Request.QueryString("ContractID") & "'</script>")
                Else
                    Page.RegisterClientScriptBlock("LoadWorkForm", "<script language='javascript'>parent.workform.location.href='WContractDetail.aspx?POS=" & Trim(txtCurrentID.Text) & "'</script>")
                End If
            Else
                btnMoveFirst.Enabled = False
                btnMovePrev.Enabled = False
                btnMoveNext.Enabled = False
                btnMoveLast.Enabled = False
            End If
        End Sub

        ' BindData method
        'Private Sub BindData()
        '    Dim intFilterOn As Integer = 0
        '    Dim strPoName As String
        '    Dim strReceiptNo As String
        '    Dim strValidDateFrom As String
        '    Dim strValidDateTo As String
        '    Dim dblAmountFrom As Double
        '    Dim dblAmountTo As Double
        '    Dim strTitle As String
        '    Dim strAuthor As String
        '    Dim strPublisher As String
        '    Dim strPubYear As String
        '    Dim strISBN As String
        '    Dim strCurrency As String
        '    Dim intVendor As Integer
        '    Dim intBudget As Integer
        '    Dim intMaxID As Integer
        '    Dim intMinID As Integer
        '    Dim tblTemp As New DataTable

        '    ' Filter PO
        '    If Not Request("txtFilterOn") = "" Then
        '        strPoName = Request("txtPoName")
        '        strReceiptNo = Request("txtReceiptNo")
        '        strValidDateFrom = Request("txtValidDateFrom")
        '        strValidDateTo = Request("txtValidDateTo")
        '        If Not Trim(Request("txtAmountFrom")) = "" Then
        '            dblAmountFrom = CDbl(Request("txtAmountFrom"))
        '        Else
        '            dblAmountFrom = 0
        '        End If
        '        If Not Trim(Request("txtAmountFrom")) = "" Then
        '            dblAmountTo = CDbl(Request("txtAmountTo"))
        '        Else
        '            dblAmountTo = 0
        '        End If
        '        strCurrency = Request("ddlCurrency")
        '        If Len(strCurrency) > 3 Then
        '            strCurrency = ""
        '        End If
        '        strTitle = Request("txtTitle")
        '        strAuthor = Request("txtAuthor")
        '        strPublisher = Request("txtPublisher")
        '        strPubYear = Request("txtPubYear")
        '        strISBN = Request("txtISBN")
        '        intVendor = Request("ddlVendor")
        '        intBudget = Request("ddlBudget")

        '        objBPO.PoName = strPoName
        '        objBPO.ReceiptNo = strReceiptNo
        '        objBPO.ValidDateFrom = strValidDateFrom
        '        objBPO.ValidDateTo = strValidDateTo
        '        objBPO.AmountFrom = dblAmountFrom
        '        objBPO.AmountTo = dblAmountTo
        '        objBPO.Title = strTitle
        '        objBPO.Author = strAuthor
        '        objBPO.Publisher = strPublisher
        '        objBPO.PubYear = strPubYear
        '        objBPO.ISBN = strISBN
        '        objBPO.Currency = strCurrency
        '        objBPO.VendorID = intVendor
        '        objBPO.BudgetID = intBudget

        '        Dim arrContract() = objBPO.SearchContract
        '        ' Check error 
        '        Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPO.ErrorMsg, ddlLabel.Items(0).Text, objBPO.ErrorCode)

        '        If UBound(arrContract) >= 0 Then
        '            If CInt(arrContract(0)) = -1 Then
        '                txtCurrentID.Text = 0
        '                txtMaxID.Text = 0
        '            Else
        '                txtCurrentID.Text = 1
        '                txtMaxID.Text = UBound(arrContract) + 1
        '                Dim intIndex As Integer
        '                Dim strJavaScript As String = ""
        '                ' Forming Javascript string
        '                strJavaScript = "arrPoID = new Array(" & UBound(arrContract) & ");"
        '                For intIndex = 0 To UBound(arrContract)
        '                    strJavaScript = strJavaScript & "arrPoID[" & intIndex & "]=" & arrContract(intIndex) & ";"
        '                Next
        '                ' Load
        '                Page.RegisterClientScriptBlock("JavaScrips", "<script language = 'javascript'>" & strJavaScript & "</script>")
        '                ' Move to the first record after filter
        '                Page.RegisterClientScriptBlock("LoadFirstContract", "<script language = 'javascript'>parent.workwin.location.href='WProcessContract.aspx?FilterOn=1&PoID=' + arrPoID[0];</script>")
        '                ' MoveFirst
        '                btnMoveFirst.Attributes.Add("OnClick", "Go(0, " & UBound(arrContract) & "); return false;")
        '                ' MovePrev
        '                btnMovePrev.Attributes.Add("OnClick", "Go(1, " & UBound(arrContract) & "); return false;")
        '                ' MoveNext
        '                btnMoveNext.Attributes.Add("OnClick", "Go(2, " & UBound(arrContract) & "); return false;")
        '                ' MoveLast
        '                btnMoveLast.Attributes.Add("OnClick", "Go(3, " & UBound(arrContract) & "); return false;")
        '                ' MoveTo
        '                txtCurrentID.Attributes.Add("OnChange", "Go(4, " & UBound(arrContract) & "); return false;")
        '            End If
        '        End If
        '    Else ' Not Filter

        '        objBPO.Direction = 0
        '        objBPO.AcqPOID = -1
        '        tblTemp = objBPO.GetAcqPoInfor
        '        ' Check error 
        '        Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPO.ErrorMsg, ddlLabel.Items(0).Text, objBPO.ErrorCode)

        '        intMinID = CInt(tblTemp.Rows(0).Item("MinID"))
        '        intMaxID = CInt(tblTemp.Rows(0).Item("MaxID"))
        '        If intMinID > 0 Then
        '            txtMaxID.Text = intMaxID
        '            If txtCurrentID.Text = "" Then
        '                txtCurrentID.Text = intMinID
        '            End If
        '            intCurrentID = CInt(txtCurrentID.Text)
        '            ' Move to the first record after filter
        '            Page.RegisterClientScriptBlock("JavaScrips", "<script language = 'javascript'>parent.workwin.location.href ='WProcessContract.aspx?direction=0&PoID=" & intMinID & "';</script>")
        '            ' MoveFirst
        '            btnMoveFirst.Attributes.Add("OnClick", "GoTo(0); return false;")
        '            ' MovePrev
        '            btnMovePrev.Attributes.Add("OnClick", "GoTo(1); return false;")
        '            ' MoveNext
        '            btnMoveNext.Attributes.Add("OnClick", "GoTo(2); return false;")
        '            ' MoveLast
        '            btnMoveLast.Attributes.Add("OnClick", "GoTo(3); return false;")
        '            ' MoveTo
        '            txtCurrentID.Attributes.Add("OnChange", "GoTo(4); return false;")
        '        End If
        '    End If
        '    ' Release object
        '    tblTemp.Dispose()
        '    tblTemp = Nothing
        'End Sub

        ' Event: btnUnFilter_Click
        ' Purpose: unfilter data
        Private Sub btnUnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnFilter.Click
            Session("FilterIDs") = Nothing
            Call BindData()
        End Sub

        ' Page_Unload event
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Dispose method
        ' Release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                Call objBPO.Dispose(True)
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace