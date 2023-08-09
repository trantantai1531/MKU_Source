' class WBarcodeForm
' Puspose: BarCode search
' Creator: Sondp
' CreatedDate: 
' Modification History:

Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition
Imports System.Math

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WBarcodeForm
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtCodeItem As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtCopyNumber As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtoptElse As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtckbShelf As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtckbItemCode As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtckbCopyNumber As System.Web.UI.WebControls.TextBox
        Protected WithEvents FilterTable As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents ContentPrint As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents BarCodeFormal As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents ab As System.Web.UI.WebControls.Button


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private objBLoc As New clsBLocation
        Private objBLib As New clsBLibrary
        Private objBFSQL As New clsBFormingSQL
        Private objBCT As New clsBCommonTemplate
        Private objBT As New clsBTemplate

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ' Put user code to initialize the page here
            Call CheckPemissions()
            Call Initialize()
            Call InitialThreeArrays()
            If Not Page.IsPostBack Then
                Call BindData()
                Call DisposeSession()
            End If
            ' Note: must put BindScript here
            Call BindScript()
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Initialize objBLoc object
            objBLoc.InterfaceLanguage = Session("InterfaceLanguage")
            objBLoc.DBServer = Session("DBServer")
            objBLoc.ConnectionString = Session("ConnectionString")
            objBLoc.Initialize()
            ' Initialize objBLib object
            objBLib.InterfaceLanguage = Session("InterfaceLanguage")
            objBLib.DBServer = Session("DBServer")
            objBLib.ConnectionString = Session("ConnectionString")
            objBLib.Initialize()
            ' Initialize objBFSQL object
            objBFSQL.InterfaceLanguage = Session("InterfaceLanguage")
            objBFSQL.DBServer = Session("DBServer")
            objBFSQL.ConnectionString = Session("ConnectionString")
            objBFSQL.Initialize()
            ' Initialize objBCT object
            objBCT.InterfaceLanguage = Session("InterfaceLanguage")
            objBCT.DBServer = Session("DBServer")
            objBCT.ConnectionString = Session("ConnectionString")
            objBCT.Initialize()
            ' Initialize objBT object
            objBT.InterfaceLanguage = Session("InterfaceLanguage")
            objBT.DBServer = Session("DBServer")
            objBT.ConnectionString = Session("ConnectionString")
            objBT.Initialize()
        End Sub

        ' CheckPemission method
        Private Sub CheckPemissions()
            ' Check permisssion
            If Not CheckPemission(103) Then
                Call WriteErrorMssg(ddlLog.Items(2).Text)
            End If
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            'PhuongTT 20080820
            'Modify ACQ-->Catalogue
            'B1
            Page.RegisterClientScriptBlock("WBarcodeFormJs", "<script language='javascript' src='../Js/Catalogue/WBarCodePrint.js'></script>")
            'E1
            ddlLibrary.Attributes.Add("OnChange", "BindStoreData(this.options[this.selectedIndex].value);return(false);")
            ddlStore.Attributes.Add("OnChange", "document.forms[0].hdStore.value=this.options[this.options.selectedIndex].value;return false;")
            hrfFromCodeItem.NavigateUrl = "javascript:OpenWindow('../../Acquisition/ACQ/WSearchItem.aspx?ControlName=txtFromCodeItem','SearchWindow',600,400,10,20);"
            hrfToCodeItem.NavigateUrl = "javascript:OpenWindow('../../Acquisition/ACQ/WSearchItem.aspx?ControlName=txtToCodeItem','SearchWindow',600,400,10,20);"
            btnReset.Attributes.Add("OnClick", "ResetForm();return false;")
            optCodeItem.Attributes.Add("OnClick", "document.forms[0].txtFromCodeItem.focus();document.forms[0].hdChoice.value=0;")
            optCopyNumber.Attributes.Add("OnClick", "document.forms[0].txtFromCopyNumber.focus();document.forms[0].hdChoice.value=1;")
            optElse.Attributes.Add("OnClick", "document.forms[0].txtElse.focus();document.forms[0].hdChoice.value=2;")
        End Sub

        ' BindData method
        Private Sub BindData()
            Dim tblTem As New DataTable
            Dim listItem As New listItem
            ' Bind Library
            objBLib.LibID = clsSession.GlbSite
            tblTem = InsertOneRow(objBLib.GetLibrary, ddlLog.Items(5).Text)
            If tblTem.Rows.Count > 0 Then
                ddlLibrary.DataSource = tblTem
                ddlLibrary.DataTextField = "Code"
                ddlLibrary.DataValueField = "ID"
                ddlLibrary.DataBind()
            End If
            tblTem = Nothing
            ' Bind Tempalte
            objBCT.TemplateID = 0
            objBCT.TemplateType = 79
            objBCT.LibID = clsSession.GlbSite
            tblTem = objBCT.GetTemplate
            If Not tblTem Is Nothing AndAlso tblTem.Rows.Count > 0 Then
                ddlBarCodeType.DataSource = tblTem
                ddlBarCodeType.DataValueField = "ID"
                ddlBarCodeType.DataTextField = "Title"
                ddlBarCodeType.DataBind()
                ddlBarCodeType.SelectedIndex = 0
            End If
            tblTem = Nothing
            If Not Request.QueryString("ItemCode") & "" = "" Then
                txtFromCodeItem.Text = Request.QueryString("ItemCode")
                txtToCodeItem.Text = Request.QueryString("ItemCode")
                optCodeItem.Checked = True
                hdChoice.Value = 0
            End If
        End Sub

        ' Initial 3 java script arrays use for load location method
        Public Sub InitialThreeArrays()
            Dim strScript As String
            Dim tblLoc As New DataTable
            Dim inti As Integer

            strScript = ""
            ' Select all locations
            objBLoc.UserID = Session("UserID")
            tblLoc = objBLoc.GetLocation()
            If Not tblLoc Is Nothing Then
                If tblLoc.Rows.Count > 0 Then
                    ' Init three arrays content ID, Symbol, LibID
                    strScript = "ID=new Array(" & tblLoc.Rows.Count - 1 & ");"
                    strScript &= "Symbol=new Array(" & tblLoc.Rows.Count - 1 & ");"
                    strScript &= "LibID=new Array(" & tblLoc.Rows.Count - 1 & ");"
                    For inti = 0 To tblLoc.Rows.Count - 1
                        strScript &= "ID[" & inti & "]=" & tblLoc.Rows(inti).Item("ID") & ";"
                        strScript &= "Symbol[" & inti & "]='" & tblLoc.Rows(inti).Item("Symbol") & "';"
                        strScript &= "LibID[" & inti & "]=" & tblLoc.Rows(inti).Item("LibID") & ";"
                    Next
                End If
            End If
            Page.RegisterClientScriptBlock("InitialThreeArraysJs", "<script language='javascript'>" & strScript & "</script>")
        End Sub

        ' Print Barcode from lazer printer
        Private Sub btnBarCode_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBarCode.Click
            Session("lazerprinter") = True
            Call GetDataToPrint()
        End Sub

        Private Sub btnBarCodePrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBarCodePrint.Click
            Session("lazerprinter") = False
            Call GetDataToPrint()
        End Sub

        ' GetDataToPrint method
        ' In: Some infor
        ' Out: Datatable
        Private Function GetHoldingInfor() As DataTable
            ' Search by ItemCode
            Select Case hdChoice.Value
                Case 2 ' user input data
                    If txtElse.Text.Trim <> "" Then
                        Session("Else") = Split(objBT.SplitCopyNumber(txtElse.Text, ";", True), ",")
                    Else
                        Session("Else") = Nothing
                    End If
                Case Else
                    GetHoldingInfor = objBT.GetIDforBarCode(hdChoice.Value, 0, hdStore.Value, txtFromCodeItem.Text, txtToCodeItem.Text, txtFromCopyNumber.Text, txtToCopyNumber.Text)
            End Select
        End Function

        ' Purpose: Initalize data 
        Private Sub IntiCollection(ByRef collecBarCode As Collection)
            collecBarCode.Add(True, "printmode") ' Print from lazer printer
            collecBarCode.Add(ddlImageType.SelectedValue, "imagetype")
            collecBarCode.Add(ddlBarCodeType.SelectedValue, "barcodetype")
            If txtHeight.Text & "" = "" Or Not IsNumeric(txtHeight.Text) Then
                txtHeight.Text = 70
            End If
            collecBarCode.Add(txtHeight.Text, "height")
            If txtWidth.Text & "" = "" Or Not IsNumeric(txtWidth.Text) Then
                txtWidth.Text = 1
            End If
            collecBarCode.Add(txtWidth.Text, "width")
            collecBarCode.Add(ddlType.SelectedValue, "type")
            collecBarCode.Add(ddlRotation.SelectedValue, "rotation")
            If txtColSpace.Text & "" = "" Or Not IsNumeric(txtColSpace.Text) Then
                txtColSpace.Text = 0
            End If
            collecBarCode.Add(txtColSpace.Text, "colspace")
            If txtRowSpace.Text & "" = "" Or Not IsNumeric(txtRowSpace.Text) Then
                txtRowSpace.Text = 0
            End If
            collecBarCode.Add(txtRowSpace.Text, "rowspace")
            If txtColNumber.Text & "" = "" Or Not IsNumeric(txtColNumber.Text) Then
                txtColNumber.Text = 1
            End If
            collecBarCode.Add(txtColNumber.Text, "colnumber")
            If txtPage.Text & "" = "" Or Not IsNumeric(txtPage.Text) Then
                txtPage.Text = 20
            End If
            collecBarCode.Add(txtPage.Text, "page")
            ' Check select CopyNumber
            If ckbCopyNumber.Checked = True Then
                collecBarCode.Add("CopyNumber", "copynumber")
                collecBarCode.Add(True, "barcodeGenerateLabel")
            Else
                collecBarCode.Add("", "copynumber")

            End If
            ' Check select ItemCode
            If ckbItemCode.Checked = True Then
                collecBarCode.Add("Code", "itemcode")
            Else
                collecBarCode.Add("", "itemcode")
            End If
            ' Check select Shelf
            If ckbShelf.Checked = True Then
                collecBarCode.Add("Shelf", "shelf")
                collecBarCode.Add(True, "barcodeGenerateLabel")
            Else
                collecBarCode.Add("", "shelf")
            End If
            Try
                If optElse.Checked Then
                    collecBarCode.Add(True, "else")
                    collecBarCode.Add(True, "barcodeGenerateLabel")
                Else
                    collecBarCode.Add(False, "else")
                End If
            Catch ex As Exception

            End Try
           


        End Sub

        ' Get data to print
        Private Sub GetDataToPrint()
            Dim tblHoldingInfor As New DataTable
            Dim arrHoldingIDs() As String
            Dim lngi As Long
            Dim collecBarCode As New Collection
            Call IntiCollection(collecBarCode)
            arrHoldingIDs = Nothing
            Select Case hdChoice.Value
                Case 2
                    GetHoldingInfor()
                    If Not Session("Else") Is Nothing Then
                        Session("BarCodeChoice") = collecBarCode '--> Content all user selected and some informations
                        Page.RegisterClientScriptBlock("WBarCodePrintJs", "<script language='javascript'>self.location.href='WBarcodePrint.aspx';</script>")
                    Else
                        Call DisposeSession()
                        Page.RegisterClientScriptBlock("NotFoundData0", "<script language='javascript'>alert('" & ddlLog.Items(4).Text & "');</script>")
                    End If
                Case Else
                    tblHoldingInfor = GetHoldingInfor()
                    If Not tblHoldingInfor Is Nothing Then
                        If tblHoldingInfor.Rows.Count > 0 Then
                            ReDim arrHoldingIDs(tblHoldingInfor.Rows.Count - 1)
                            For lngi = 0 To tblHoldingInfor.Rows.Count - 1
                                arrHoldingIDs(lngi) = tblHoldingInfor.Rows(lngi).Item("ID")
                            Next
                            collecBarCode.Add(Math.Ceiling(tblHoldingInfor.Rows.Count / collecBarCode.Item("page")), "maxpage")
                        End If
                    End If
                    If Not arrHoldingIDs Is Nothing Then
                        If UBound(arrHoldingIDs) > 0 Then
                            Session("IDs") = arrHoldingIDs
                            Session("BarCodeChoice") = collecBarCode '--> Content all user selected and some informations
                            Page.RegisterClientScriptBlock("WBarCodeFrameJs", "<script language='javascript'>self.location.href='WBarcodeFrame.aspx';</script>")
                        Else
                            Call DisposeSession()
                            Page.RegisterClientScriptBlock("NotFoundData1", "<script language='javascript'>alert('" & ddlLog.Items(4).Text & "');</script>")
                        End If
                    Else
                        Call DisposeSession()
                        Page.RegisterClientScriptBlock("NotFoundData2", "<script language='javascript'>alert('" & ddlLog.Items(4).Text & "');</script>")
                    End If
            End Select
        End Sub

        ' Dispose Sessions
        Private Sub DisposeSession()
            ' Dispose all Session 
            If Not Session("IDs") Is Nothing Then
                Session("IDs") = Nothing
            End If
            If Not Session("BarCodeChoice") Is Nothing Then
                Session("BarCodeChoice") = Nothing
            End If
            If Not Session("Else") Is Nothing Then
                Session("Else") = Nothing
            End If
            If Not Session("lazerprinter") Is Nothing Then
                Session("lazerprinter") = Nothing
            End If
        End Sub

        ' Page_Unload method
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBLoc Is Nothing Then
                objBLoc.Dispose(True)
                objBLoc = Nothing
            End If
            If Not objBLib Is Nothing Then
                objBLib.Dispose(True)
                objBLib = Nothing
            End If
            If Not objBFSQL Is Nothing Then
                objBFSQL.Dispose(True)
                objBFSQL = Nothing
            End If
            If Not objBCT Is Nothing Then
                objBCT.Dispose(True)
                objBCT = Nothing
            End If
        End Sub
    End Class
End Namespace