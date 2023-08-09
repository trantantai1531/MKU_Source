Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WBookChanged
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
        Private objBItem As New clsBItemCollection
        Private objBForming As New clsBFormingSQL
        Private objBPO As New clsBPurchaseOrder

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Inititalize()
            Call BindJS()
            Call BindData()
        End Sub

        ' Method: Inititalize
        ' Purpose: init all objects
        Private Sub Inititalize()
            ' Init objBItem object
            objBItem.ConnectionString = Session("ConnectionString")
            objBItem.DBServer = Session("DBServer")
            objBItem.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBItem.Initialize()

            ' Init objBForming object
            objBForming.ConnectionString = Session("ConnectionString")
            objBForming.DBServer = Session("DBServer")
            objBForming.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBForming.Initialize()

            ' Init objBPO object
            objBPO.ConnectionString = Session("ConnectionString")
            objBPO.DBServer = Session("DBServer")
            objBPO.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPO.Initialize()
        End Sub

        ' Method: BindJS
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("selfJs", "<script language = 'javascript' src = '../js/Acq/WCataForm.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
        End Sub
        ' Event: BindData
        Private Sub BindData()
            Dim intBookID As Integer
            Dim strISOCode As String
            Dim intPOID As Integer
            Dim intAcceptedCopies As Integer
            Dim intUnitPrice As Integer
            Dim strTitle As String = Trim(Request.QueryString("str245") & "")
            Dim strPubYear As String
            Dim strPublisher As String
            Dim strISSN As String
            Dim strISBN As String = Trim(Request.QueryString("strISBN") & "")
            Dim strItemType As String
            Dim strMedium As String
            Dim strAuthor As String
            Dim strEdition As String
            Dim strISOCodeLang As String
            Dim strLanguage As String
            Dim strCountry As String
            Dim intLoanType As Integer
            Dim intAcqSource As Integer
            Dim strAdditionalBy As String

            If Request.QueryString("BookID") <> "" Then
                intBookID = CLng(Request.QueryString("BookID"))
                Dim tblTemp As New DataTable
                tblTemp = objBPO.GetAcqItemInfor(intBookID)

                If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                    intPOID = CInt(tblTemp.Rows(0).Item("POID").ToString.Trim)
                    If (Not IsDBNull(tblTemp.Rows(0).Item("UnitPrice"))) And (Not IsDBNull(tblTemp.Rows(0).Item("Rate"))) Then
                        intUnitPrice = CSng(tblTemp.Rows(0).Item("UnitPrice")) * CSng(tblTemp.Rows(0).Item("Rate"))
                    End If
                    strTitle = tblTemp.Rows(0).Item("Title").ToString.Trim
                    strPubYear = tblTemp.Rows(0).Item("PubYear").ToString.Trim
                    strPublisher = tblTemp.Rows(0).Item("Publisher").ToString.Trim
                    strISSN = tblTemp.Rows(0).Item("ISSN").ToString.Trim
                    strISBN = tblTemp.Rows(0).Item("ISBN").ToString.Trim
                    strItemType = tblTemp.Rows(0).Item("ItemType").ToString.Trim
                    strMedium = tblTemp.Rows(0).Item("Medium").ToString.Trim
                    strAuthor = tblTemp.Rows(0).Item("Author").ToString.Trim
                    strEdition = tblTemp.Rows(0).Item("Edition").ToString.Trim
                    strISOCodeLang = tblTemp.Rows(0).Item("ISOCodeLanguage").ToString.Trim
                    strISOCode = tblTemp.Rows(0).Item("ISOCodeCountry").ToString.Trim
                    strLanguage = tblTemp.Rows(0).Item("Language").ToString.Trim
                    strCountry = tblTemp.Rows(0).Item("Country").ToString.Trim
                    intLoanType = tblTemp.Rows(0).Item("LoanTypeID").ToString.Trim
                    intAcqSource = tblTemp.Rows(0).Item("AcqSourceID").ToString.Trim
                    strAdditionalBy = tblTemp.Rows(0).Item("AdditionalBy").ToString.Trim

                    Page.RegisterClientScriptBlock("FunctionJs", "<script language = 'javascript'>UpData(" & intPOID & "," & intUnitPrice & ",'" & strTitle & "','" & strPubYear & "','" & strPublisher & "','" & strISSN & "','" & strISBN & "','" & strItemType & "','" & strMedium & "','" & strAuthor & "','" & strEdition & "','" & strISOCodeLang & "','" & strISOCode & "'," & intBookID & ",'" & strLanguage & "','" & strCountry & "', '" & intLoanType & "', '" & intAcqSource & "','" & strAdditionalBy & "');</script>")
                End If
            Else
                ' Kiem tra su ton cua sach
                Dim blnHave As Boolean
                blnHave = SearchItem(strTitle, strISBN)
                'If blnHave = False Then
                '    Page.RegisterClientScriptBlock("LoadForm", "<script language = 'javascript'>parent.mainacq.document.forms[0].txt245_a.value='" & strTitle & "';</script>")
                'End If
            End If
        End Sub

        ' Method: SearchItem
        ' Purpose: Check item 
        Function SearchItem(ByVal strTitle As String, ByVal strISBN As String) As Boolean
            Dim arrBool()
            Dim arrVal()
            Dim arrField()
            Dim intk
            intk = 0
            If Trim(strTitle) <> "" Then
                ReDim Preserve arrBool(intk)
                ReDim Preserve arrField(intk)
                ReDim Preserve arrVal(intk)
                arrBool(intk) = "AND"
                arrField(intk) = "TI"
                arrVal(intk) = Trim(strTitle)
                intk = intk + 1
            End If
            If Trim(strISBN) <> "" Then
                ReDim Preserve arrBool(intk)
                ReDim Preserve arrField(intk)
                ReDim Preserve arrVal(intk)
                arrBool(intk) = "AND"
                arrField(intk) = "IB"
                arrVal(intk) = Trim(strISBN)
                intk = intk + 1
            End If
            objBForming.FieldArr = arrField
            objBForming.ValArr = arrVal
            objBForming.BoolArr = arrBool

            Dim strIDs As String
            Dim tblItem As New DataTable
            Dim strTitleShow As String

            strIDs = objBForming.ExecuteQuery(10)

            ' Check error
            Call WriteErrorMssg(objBForming.ErrorCode, objBForming.ErrorMsg)

            If strIDs & "" = "" Then
                strIDs = "-1"
            End If
            objBItem.ItemIDs = strIDs

            tblItem = objBItem.GetItemDetailInfor

            tblItem.DefaultView.RowFilter = "FieldCode='245'"

            If Not tblItem Is Nothing AndAlso tblItem.DefaultView.Count > 0 Then
                For intk = 0 To tblItem.DefaultView.Count - 1
                    strTitleShow = strTitleShow & "- " & tblItem.DefaultView(intk).Item("Content") & "\n"
                Next
                If strTitleShow <> "" Then
                    strTitleShow = Replace(strTitleShow, """", "\""")
                    strTitleShow = Replace(strTitleShow, "'", "\'")
                End If
                If strTitleShow <> "" Then
                    Dim strJs As String = ""
                    Dim strmsg As String
                    If strISBN <> "" Then
                        strmsg = ddlLabel.Items(2).Text
                    Else
                        strmsg = ddlLabel.Items(0).Text
                    End If
                    strJs = "if (confirm('" & strmsg & "\n\n"
                    strJs = strJs & strTitleShow
                    strJs = strJs & "\n" & ddlLabel.Items(1).Text & "')){ openModal('WShowRec.aspx?ItemIDs=" & strIDs & "','BookExist',600,350,100,150,'yes','',0); }"

                    Page.RegisterClientScriptBlock("ConfirmJS", "<script language = 'javascript'>" & strJs & "</script>")
                    SearchItem = True
                Else
                    SearchItem = False
                End If
            Else
                SearchItem = False
            End If
        End Function

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Me.Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: Release all object
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBItem Is Nothing Then
                    objBItem.Dispose(True)
                    objBItem = Nothing
                End If
                If Not objBForming Is Nothing Then
                    objBForming.Dispose(True)
                    objBForming = Nothing
                End If
                If Not objBPO Is Nothing Then
                    objBPO.Dispose(True)
                    objBPO = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace