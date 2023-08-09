Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WCatawork
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
        Private objBInput As New clsBInput
        Private objBItemOrder As New clsBItemOrder
        Private objBCSP As New clsBCommonStringProc
        Private objBItem As New clsBItem
        Private objBCommon As New clsBCommonBusiness
        Private objBPO As New clsBPurchaseOrder

        ' Method: Initialize
        ' Purpose: init all objects
        Private Sub Initialize()
            ' Init BCommonStringProc object
            objBCSP.DBServer = Session("DBServer")
            objBCSP.InterfaceLanguage = Session("InterfaceLanguage")
            objBCSP.ConnectionString = Session("ConnectionString")
            Call objBCSP.Initialize()

            ' Init objBItem object
            objBInput.DBServer = Session("DBServer")
            objBInput.InterfaceLanguage = Session("InterfaceLanguage")
            objBInput.ConnectionString = Session("ConnectionString")
            Call objBInput.Initialize()

            ' Init objBItemOrder object
            objBItemOrder.DBServer = Session("DBServer")
            objBItemOrder.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemOrder.ConnectionString = Session("ConnectionString")
            Call objBItemOrder.Initialize()

            ' Init objBItem object
            objBItem.DBServer = Session("DBServer")
            objBItem.InterfaceLanguage = Session("InterfaceLanguage")
            objBItem.ConnectionString = Session("ConnectionString")
            Call objBItem.Initialize()

            ' Init objBCommon object
            objBCommon.DBServer = Session("DBServer")
            objBCommon.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommon.ConnectionString = Session("ConnectionString")
            Call objBCommon.Initialize()

            ' Init objBPO object
            objBPO.DBServer = Session("DBServer")
            objBPO.InterfaceLanguage = Session("InterfaceLanguage")
            objBPO.ConnectionString = Session("ConnectionString")
            Call objBPO.Initialize()
        End Sub

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call BindControl()
                Call Catalog_Save()
            End If
        End Sub
        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(44) Then
                btnConUpdate.Enabled = False
            End If
        End Sub
        ' Method: BindControl
        ' Purpose: Bind value for form's controls
        Private Sub BindControl()
            lblCapLeader.Font.Bold = True
            lblCapTitle.Font.Bold = True
            lblTitle.Font.Bold = True
            lblTitle.ForeColor = Color.Red
            lblCapPub.Font.Bold = True
            lblCapQuantity.Font.Bold = True
            lblCapISBN.Font.Bold = True
            lblCapCodeBook.Font.Bold = True
        End Sub

        ' BindControl method
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("selfJs", "<script language = 'javascript' src = '../js/Acq/WCataWork.js'></script>")

            btnBack.Attributes.Add("OnClick", "return Back_cl();")
            btnConUpdate.Attributes.Add("OnClick", "return ConUpdate_cl();")
        End Sub

        Private Sub Catalog_Save()
            Dim intRetVal As Integer
            Dim ArrFieldName()
            Dim ArrFieldValue()
            ReDim ArrFieldName(5)
            ReDim ArrFieldValue(5)
            ArrFieldName(0) = "000"
            ArrFieldValue(0) = "00000n" & Request("ddlRecType") & Request("ddlLevelDir") & " a22        4500"
            ArrFieldName(1) = "927"
            If Request("ddlItemType") <> "" Then
                If InStr(Request("ddlItemType"), ":") <> 0 Then
                    ArrFieldValue(1) = Left(Request("ddlItemType"), InStr(Request("ddlItemType"), ":") - 1)
                Else
                    ArrFieldValue(1) = Request("ddlItemType")
                End If
            Else
                ArrFieldValue(1) = ""
            End If
            ArrFieldName(2) = "925"
            If Request("ddlMedium") <> "" Then
                If InStr(Request("ddlMedium"), ":") <> 0 Then
                    ArrFieldValue(2) = Left(Request("ddlMedium"), InStr(Request("ddlMedium"), ":") - 1)
                Else
                    ArrFieldValue(2) = Request("ddlMedium")
                End If
            Else
                ArrFieldValue(2) = ""
            End If
            ArrFieldName(3) = "926"
            ArrFieldValue(3) = Request("ddlLevelSec")
            ArrFieldName(4) = "900"
            ArrFieldValue(4) = "True"
            ArrFieldName(5) = "911"
            ArrFieldValue(5) = clsSession.GlbUserFullName

            Dim str041_a As String
            Dim str044_a As String
            Dim str020_a As String
            Dim str022_a As String
            Dim str082_a As String
            Dim str100_a As String
            Dim str110_a As String
            Dim str245_a As String
            Dim str245_b_ss As String
            Dim str245_b_pd As String
            Dim str245_c As String
            Dim str245_n As String
            Dim str245_p As String
            Dim str250_a As String
            Dim str260_a As String
            Dim str260_b As String
            Dim str260_c As String
            Dim str300_a As String
            Dim str300_b As String
            Dim str300_c As String
            Dim str300_e As String
            Dim str650_a As String
            Dim str653_a As String
            Dim strLoanType As String = 1
            Dim strAcqSource As String = 1
            Dim strUnitPrice As String = "0"
            Dim strAdditionalBy As String = ""

            str041_a = Request("txt041_a") 'Request("languageID")
            str044_a = Request("CountryPubID")
            str020_a = Request("txt020_a")
            str022_a = Request("txt022_a")
            str082_a = Request("txt082_a")
            str100_a = Request("txt100_a")
            str110_a = Request("txt110_a")
            str245_a = Request("txt245_a")
            str245_b_ss = Request("txt245_b_ss")
            str245_b_pd = Request("txt245_b_pd")
            str245_c = Request("txt245_c")
            str245_n = Request("txt245_n")
            str245_p = Request("txt245_p")
            str250_a = Request("txt250_a")
            str260_a = Request("txt260_a")
            str260_b = Request("txt260_b")
            str260_c = Request("txt260_c")
            str300_a = Request("txt300_a")
            str300_b = Request("txt300_b")
            str300_c = Request("txt300_c")
            str300_e = Request("txt300_e")
            str650_a = Request("txt650_a")
            str653_a = Request("txt653_a")
            strUnitPrice = Request("hidUnitPrice")
            strAdditionalBy = Request("txtAdditionalBy")

            If Request("ddlLoanType") <> "" Then
                strLoanType = Request("ddlLoanType")
            End If

            If Request("ddlAcqSource") <> "" Then
                strAcqSource = Request("ddlAcqSource")
            End If

            If str041_a <> "" Then
                ReDim Preserve ArrFieldName(UBound(ArrFieldName) + 1)
                ReDim Preserve ArrFieldValue(UBound(ArrFieldValue) + 1)
                ArrFieldName(UBound(ArrFieldName)) = "041"
                ArrFieldValue(UBound(ArrFieldName)) = "  ::$a" & str041_a
            End If
            If str044_a <> "" Then
                ReDim Preserve ArrFieldName(UBound(ArrFieldName) + 1)
                ReDim Preserve ArrFieldValue(UBound(ArrFieldValue) + 1)
                ArrFieldName(UBound(ArrFieldName)) = "044"
                ArrFieldValue(UBound(ArrFieldName)) = "  ::$a" & str044_a
            End If

            If str020_a <> "" Then
                ReDim Preserve ArrFieldName(UBound(ArrFieldName) + 1)
                ReDim Preserve ArrFieldValue(UBound(ArrFieldValue) + 1)
                ArrFieldName(UBound(ArrFieldName)) = "020"
                ArrFieldValue(UBound(ArrFieldName)) = "  ::$a" & str020_a
            End If
            If str022_a <> "" Then
                ReDim Preserve ArrFieldName(UBound(ArrFieldName) + 1)
                ReDim Preserve ArrFieldValue(UBound(ArrFieldValue) + 1)
                ArrFieldName(UBound(ArrFieldName)) = "022"
                ArrFieldValue(UBound(ArrFieldName)) = "  ::$a" & str022_a
            End If
            If str082_a <> "" Then
                ReDim Preserve ArrFieldName(UBound(ArrFieldName) + 1)
                ReDim Preserve ArrFieldValue(UBound(ArrFieldValue) + 1)
                ArrFieldName(UBound(ArrFieldName)) = "082"
                ArrFieldValue(UBound(ArrFieldName)) = "  ::$a" & str082_a
            End If
            If str100_a <> "" Then
                ReDim Preserve ArrFieldName(UBound(ArrFieldName) + 1)
                ReDim Preserve ArrFieldValue(UBound(ArrFieldValue) + 1)
                ArrFieldName(UBound(ArrFieldName)) = "100"
                ArrFieldValue(UBound(ArrFieldName)) = "1 ::$a" & str100_a
            End If
            If str110_a <> "" Then
                ReDim Preserve ArrFieldName(UBound(ArrFieldName) + 1)
                ReDim Preserve ArrFieldValue(UBound(ArrFieldValue) + 1)
                ArrFieldName(UBound(ArrFieldName)) = "110"
                ArrFieldValue(UBound(ArrFieldName)) = "1 ::$a" & str110_a
            End If

            Dim str245 As String
            str245 = "00::$a" & str245_a
            If str245_b_ss <> "" Then
                If str245_b_pd <> "" Then
                    'Standard format for Parallel title
                    str245 = str245 & " = $b" & str245_b_ss
                    str245 = str245 & " : " & str245_b_pd
                Else
                    str245 = str245 & " : $b" & str245_b_ss
                End If
            Else
                If str245_b_pd <> "" Then
                    str245 = str245 & " : $b" & str245_b_pd
                End If
            End If

            'If str245_b_pd <> "" Then
            '    str245 = str245 & " :$b" & str245_b_pd
            'End If

            If str245_n <> "" Then
                str245 = str245 & ".$n" & str245_n
            End If
            If str245_p <> "" Then
                str245 = str245 & ",$p" & str245_p
            End If
            If str245_c <> "" Then
                str245 = str245 & " /$c" & str245_c
            End If

            ReDim Preserve ArrFieldName(UBound(ArrFieldName) + 1)
            ReDim Preserve ArrFieldValue(UBound(ArrFieldValue) + 1)
            ArrFieldName(UBound(ArrFieldName)) = "245"
            ArrFieldValue(UBound(ArrFieldValue)) = str245

            If str250_a <> "" Then
                ReDim Preserve ArrFieldName(UBound(ArrFieldName) + 1)
                ReDim Preserve ArrFieldValue(UBound(ArrFieldValue) + 1)
                ArrFieldName(UBound(ArrFieldName)) = "250"
                ArrFieldValue(UBound(ArrFieldValue)) = "  ::$a" & str250_a
            End If

            Dim str260 As String
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
                ReDim Preserve ArrFieldName(UBound(ArrFieldName) + 1)
                ReDim Preserve ArrFieldValue(UBound(ArrFieldValue) + 1)
                ArrFieldName(UBound(ArrFieldName)) = "260"
                ArrFieldValue(UBound(ArrFieldValue)) = "  ::" & str260
            End If
            Dim str300 As String
            str300 = ""
            If str300_a <> "" Then
                str300 = str300 & "$a" & str300_a
            End If
            If str300_b <> "" Then
                str300 = str300 & " :$b" & str300_b
            End If
            If str300_c <> "" Then
                str300 = str300 & " ;$c" & str300_c
            End If
            If str300_e <> "" Then
                str300 = str300 & " +$e" & str300_e
            End If
            If str300 <> "" Then
                ReDim Preserve ArrFieldName(UBound(ArrFieldName) + 1)
                ReDim Preserve ArrFieldValue(UBound(ArrFieldValue) + 1)
                ArrFieldName(UBound(ArrFieldName)) = "300"
                ArrFieldValue(UBound(ArrFieldValue)) = "  ::" & str300
            End If


            If str650_a <> "" Then
                ReDim Preserve ArrFieldName(UBound(ArrFieldName) + 1)
                ReDim Preserve ArrFieldValue(UBound(ArrFieldValue) + 1)
                ArrFieldName(UBound(ArrFieldName)) = "650"
                ArrFieldValue(UBound(ArrFieldName)) = "$a" & str650_a
            End If

            If str653_a <> "" Then
                ReDim Preserve ArrFieldName(UBound(ArrFieldName) + 1)
                ReDim Preserve ArrFieldValue(UBound(ArrFieldValue) + 1)
                ArrFieldName(UBound(ArrFieldName)) = "653"
                ArrFieldValue(UBound(ArrFieldName)) = "$a" & str653_a
            End If


            Dim intFormID As Integer = 0
            If Request("ddlFormID") <> "" Then
                intFormID = CInt(Request("ddlFormID"))
            End If
            ' Create item record

            objBInput.LibID = clsSession.GlbSite
            objBInput.AcqSource = CInt(strAcqSource)
            objBInput.LoanType = CInt(strLoanType)
            objBInput.UnitPrice = CInt(strUnitPrice)
            objBInput.AdditionalBy = strAdditionalBy


            objBInput.FieldName = ArrFieldName
            objBInput.FieldValue = ArrFieldValue
            intRetVal = objBInput.Update(intFormID, 0, False, True)

            Dim intMainID As Integer = 0
            Dim intCount As Integer = 0
            intMainID = objBInput.WorkID

            ' WriteLog
            Call WriteLog(38, ddlLabel.Items(2).Text & ": " & lblCodeBook.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

            ' Update OPAC_COMMENT
            objBItem.ItemID = intMainID
            objBItem.Field912Value = 0
            Call objBItem.UpdateOpacItem(0)

            If intRetVal > 0 Then
                If Request("ddlAcqPO_ITEM") <> 0 Then
                    Call objBItemOrder.SetItemID4AcqItem(intMainID, Request("ddlAcqPO_ITEM"))
                End If
                ' create queue
                objBItem.ItemID = intMainID
                Call objBItem.CreateQueue()
            End If

            '----------------- Set Hidden ----------
            lblLeader.Text = Replace(ArrFieldValue(0), " ", "&nbsp;")
            lblCodeBook.Text = objBInput.CodeOut
            txtCode.Value = objBInput.CodeOut
            '---------------------------------------

            ' doc POcode
            Dim strPOcode As String
            strPOcode = Request("txtCodePO")
            If strPOcode <> "" Then
                If InStr(strPOcode, "(") <> 0 Then
                    txtCodePO.Value = Mid(strPOcode, InStr(strPOcode, "(") + 1, (InStr(strPOcode, ")") - 1) - (InStr(strPOcode, "(") + 1))
                Else
                    txtCodePO.Value = ""
                End If
            Else
                txtCodePO.Value = ""
            End If
            Dim strISBN As String
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
            lblISBN.Text = strISBN
            str245 = objBCSP.ConvertItBack(str245)
            lblTitle.Text = objBCSP.TrimSubFieldCodes(Replace(str245, "00::", ""))
            str260 = objBCSP.ConvertItBack(str260)
            lblPub.Text = objBCSP.TrimSubFieldCodes(Replace(str260, "  ::", ""))
            lblQuantity.Text = objBCSP.TrimSubFieldCodes(Replace(str300, "  ::", ""))
            txtBooksID.Value = Request("ddlAcqPO_ITEM")

            txtPOID.Value = objBPO.GetPOID(CInt(Request("ddlAcqPO_ITEM")))

        End Sub

        ' Event: Page UnLoad
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBInput Is Nothing Then
                    objBInput.Dispose(True)
                    objBInput = Nothing
                End If
                If Not objBInput Is Nothing Then
                    objBInput.Dispose(True)
                    objBInput = Nothing
                End If
                If Not objBCommon Is Nothing Then
                    objBCommon.Dispose(True)
                    objBCommon = Nothing
                End If
                If Not objBPO Is Nothing Then
                    objBPO.Dispose(True)
                    objBPO = Nothing
                End If
                If Not objBItemOrder Is Nothing Then
                    objBItemOrder.Dispose(True)
                    objBItemOrder = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace