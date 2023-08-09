Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.WebUI.Common
Imports eMicLibAdmin.BusinessRules.ILL

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WORDetail
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
        Dim objBPhyDelAddress As New clsBPhyDelAddress
        Dim objBILLOutRequest As New clsBILLOutRequest

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call LoadForm()
            End If
        End Sub

        ' CheckFormPermission method
        Private Sub CheckFormPermission()
            If Not CheckPemission(154) Then
                Call WriteErrorMssg(ddlLabel.Items(23).Text)
            End If
        End Sub

        ' Initialize method
        ' Purpose: init all neccessary objects
        Private Sub Initialize()
            ' Init objBPhyDelAddress object 
            objBPhyDelAddress.ConnectionString = Session("ConnectionString")
            objBPhyDelAddress.DBServer = Session("DBServer")
            objBPhyDelAddress.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPhyDelAddress.Initialize()

            ' Init objBILLOutRequest object
            objBILLOutRequest.ConnectionString = Session("ConnectionString")
            objBILLOutRequest.DBServer = Session("DBServer")
            objBILLOutRequest.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBILLOutRequest.Initialize()
        End Sub

        ' BindScript method
        ' Purpose: include all neccessary javascript functions
        Private Sub BindScript()
            Dim strJS As String
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../Js/ORMan/WORDetail.js'></script>")

            btnMoveFirst.Attributes.Add("OnClick", "if (parseFloat(document.forms[0].txtCurrentRec.value)<=1) {alert('" & ddlLabel6.Items(0).Text & "'); return false;} else {document.forms[0].txtCurrentRec.value = 1; document.forms[0].submit();}")
            btnMovePrev.Attributes.Add("OnClick", "if (parseFloat(document.forms[0].txtCurrentRec.value)<=1) {alert('" & ddlLabel6.Items(0).Text & "'); return false;} else {document.forms[0].txtCurrentRec.value = parseFloat(document.forms[0].txtCurrentRec.value) - 1; document.forms[0].submit();}")
            btnMoveNext.Attributes.Add("OnClick", "if (parseFloat(document.forms[0].txtCurrentRec.value)>=parseFloat(document.forms[0].txtTotalRec.value)) {alert('" & ddlLabel6.Items(1).Text & "'); return false;} else {document.forms[0].txtCurrentRec.value = parseFloat(document.forms[0].txtCurrentRec.value) + 1; document.forms[0].submit();}")
            btnMoveLast.Attributes.Add("OnClick", "if (parseFloat(document.forms[0].txtCurrentRec.value)>=parseFloat(document.forms[0].txtTotalRec.value)) {alert('" & ddlLabel6.Items(1).Text & "'); return false;} else {document.forms[0].txtCurrentRec.value = document.forms[0].txtTotalRec.value; document.forms[0].submit();}")

            strJS = "<script language='javascript'>" & Chr(10)
            strJS = strJS & "ActID = new Array(20);" & Chr(10)
            strJS = strJS & "ActName = new Array(20);" & Chr(10)
            strJS = strJS & "for (i = 0; i <= 20; i++) {" & Chr(10)
            strJS = strJS & "ActID[i] = i + 1;}" & Chr(10)
            strJS = strJS & "ActName[0] = '" & ddlLabel.Items(2).Text & "'" & Chr(10)
            strJS = strJS & "ActName[1] = '" & ddlLabel.Items(3).Text & "'" & Chr(10)
            strJS = strJS & "ActName[2] = '" & ddlLabel.Items(4).Text & "'" & Chr(10)
            strJS = strJS & "ActName[3] = '" & ddlLabel.Items(5).Text & "'" & Chr(10)
            strJS = strJS & "ActName[4] = '" & ddlLabel.Items(6).Text & "'" & Chr(10)
            strJS = strJS & "ActName[5] = '" & ddlLabel.Items(7).Text & "'" & Chr(10)
            strJS = strJS & "ActName[6] = '" & ddlLabel.Items(8).Text & "'" & Chr(10)
            strJS = strJS & "ActName[7] = '" & ddlLabel.Items(9).Text & "'" & Chr(10)
            strJS = strJS & "ActName[8] = '" & ddlLabel.Items(10).Text & "'" & Chr(10)
            strJS = strJS & "ActName[9] = '" & ddlLabel.Items(11).Text & "'" & Chr(10)
            strJS = strJS & "ActName[10] = '" & ddlLabel.Items(12).Text & "'" & Chr(10)
            strJS = strJS & "ActName[11] = '" & ddlLabel.Items(13).Text & "'" & Chr(10)
            strJS = strJS & "ActName[12] = '" & ddlLabel.Items(14).Text & "'" & Chr(10)
            strJS = strJS & "ActName[13] = '" & ddlLabel.Items(15).Text & "'" & Chr(10)
            strJS = strJS & "ActName[14] = '" & ddlLabel.Items(16).Text & "'" & Chr(10)
            strJS = strJS & "ActName[15] = '" & ddlLabel.Items(17).Text & "'" & Chr(10)
            strJS = strJS & "ActName[16] = '" & ddlLabel.Items(18).Text & "'" & Chr(10)
            strJS = strJS & "ActName[17] = '" & ddlLabel.Items(19).Text & "'" & Chr(10)
            strJS = strJS & "ActName[18] = '" & ddlLabel.Items(20).Text & "'" & Chr(10)
            strJS = strJS & "ActName[19] = '" & ddlLabel.Items(21).Text & "'" & Chr(10)
            strJS = strJS & "ActName[20] = '" & ddlLabel.Items(22).Text & "'" & Chr(10)
            strJS = strJS & "</script>"
            Page.RegisterClientScriptBlock("LoadArray", strJS)
        End Sub

        ' LoadForm method
        ' Purpose: show detail infor of the selected request
        Private Sub LoadForm()
            Dim lngRequestID As Long
            Dim intCount As Integer
            Dim arrRequestID() As String
            Dim lngTopNum As Integer
            Dim tblTemp As DataTable
            Dim lngTotalRec As Long
            Dim lngCurrentPos As Long

            ' Get RequestID by Index
            If Not Session("ORIDs") Is Nothing Then
                ' Filter
                arrRequestID = Split(Session("ORIDs"), ",")
                If Not Request("ILLID") = "" Then
                    ' Set text for txtCurrentRec
                    If Not Page.IsPostBack Then
                        If Not Request("ILLID") Is Nothing Then
                            For intCount = 0 To UBound(arrRequestID)
                                If (arrRequestID(intCount)) = Request("ILLID") Then
                                    txtCurrentRec.Text = intCount + 1
                                    Exit For
                                End If
                            Next
                        End If
                    End If
                End If
                If CLng(txtCurrentRec.Text) >= 1 Then
                    lngRequestID = arrRequestID(CLng(txtCurrentRec.Text) - 1)
                Else
                    txtCurrentRec.Text = "1"
                    lngRequestID = 1
                End If
                txtTotalRec.Text = UBound(arrRequestID) + 1
            Else
                If Not Request("ILLID") Is Nothing Then
                    If Not Page.IsPostBack Then
                        objBILLOutRequest.IllID = CLng(Request("ILLID"))
                    End If
                End If
                If CLng(txtCurrentRec.Text) > 0 Then
                    lngTopNum = CLng(txtCurrentRec.Text)
                End If
                tblTemp = objBILLOutRequest.GetILLOutRequestNum(lngTopNum, lngTotalRec, lngCurrentPos)
                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(1).Text, objBILLOutRequest.ErrorCode)
                If lngTotalRec > 0 Then
                    If Not Page.IsPostBack Then
                        txtCurrentRec.Text = CStr(lngCurrentPos)
                    End If
                    lngRequestID = CLng(tblTemp.Rows(0).Item("MAXID"))
                    txtTotalRec.Text = lngTotalRec
                    tblTemp.Dispose()
                    tblTemp = Nothing
                End If
            End If
            tblInfor1.Rows.Clear()
            tblInfor2.Rows.Clear()
            Call BindData(lngRequestID)
        End Sub

        Private Sub AddInfor(ByVal indextb As Integer, ByVal strLabel As String, ByVal objValue As Object, Optional ByVal blnShowEmpty As Boolean = False)
            ' Add library infor row
            Dim tblRow As TableRow
            Dim tblCell As TableCell

            tblRow = New TableRow
            ' New cell
            tblCell = New TableCell
            tblCell.HorizontalAlign = HorizontalAlign.Left
            tblCell.CssClass = "lbLabel"
            strLabel = "<img src='../images/bulet.gif' border=0>&nbsp;" & strLabel
            If Not IsDBNull(objValue) AndAlso Not Trim(objValue) = "" Then
                tblCell.Controls.Add(New LiteralControl(strLabel & ": <B>" & objValue & "</B>"))
                tblRow.Cells.Add(tblCell)
                If indextb = 1 Then
                    tblInfor1.Rows.Add(tblRow)
                Else
                    tblInfor2.Rows.Add(tblRow)
                End If
            Else
                If blnShowEmpty Then
                    tblCell.Controls.Add(New LiteralControl(strLabel & ":"))
                    tblRow.Cells.Add(tblCell)
                    If indextb = 1 Then
                        tblInfor1.Rows.Add(tblRow)
                    Else
                        tblInfor2.Rows.Add(tblRow)
                    End If
                End If
            End If
        End Sub

        Private Sub AddInforYesNo(ByVal indextb As Integer, ByVal strLabel As String, ByVal objValue As Object, Optional ByVal blnShowEmpty As Boolean = False)
            ' Add library infor row
            Dim tblRow As TableRow
            Dim tblCell As TableCell
            Dim strLabel1 As String

            tblRow = New TableRow
            ' New cell
            tblCell = New TableCell
            tblCell.HorizontalAlign = HorizontalAlign.Left
            tblCell.CssClass = "lbLabel"
            strLabel = "<img src='../images/bulet.gif' border=0>&nbsp;" & strLabel
            If Not IsDBNull(objValue) AndAlso Not Trim(objValue) = "" Then
                Select Case objValue
                    Case "1"
                        strLabel1 = ddlLabel1.Items(24).Text
                    Case Else
                        strLabel1 = ddlLabel1.Items(25).Text
                End Select
                tblCell.Controls.Add(New LiteralControl(strLabel & ": <B>" & strLabel1 & "</B>"))
                tblRow.Cells.Add(tblCell)
                If indextb = 1 Then
                    tblInfor1.Rows.Add(tblRow)
                Else
                    tblInfor2.Rows.Add(tblRow)
                End If
            ElseIf blnShowEmpty Then
                tblCell.Controls.Add(New LiteralControl(strLabel & ":"))
                tblRow.Cells.Add(tblCell)
                If indextb = 1 Then
                    tblInfor1.Rows.Add(tblRow)
                Else
                    tblInfor2.Rows.Add(tblRow)
                End If
            End If
        End Sub

        Private Sub AddTitle(ByVal indextb As Integer, ByVal strLabel As String)
            ' Add library infor row
            Dim tblRow As TableRow
            Dim tblCell As TableCell
            Dim lblLabel As Label

            tblRow = New TableRow
            ' New cell
            lblLabel = New Label
            lblLabel.Text = strLabel
            lblLabel.Width = Unit.Percentage(100)

            tblCell = New TableCell
            tblCell.HorizontalAlign = HorizontalAlign.Left
            tblCell.Controls.Add(lblLabel)
            tblCell.CssClass = "lbGroupTitle"
            tblRow.Cells.Add(tblCell)
            If indextb = 1 Then
                tblInfor1.Rows.Add(tblRow)
            Else
                tblInfor2.Rows.Add(tblRow)
            End If
        End Sub

        Private Sub AddSubTitle(ByVal indextb As Integer, ByVal strLabel As String)
            ' Add library infor row
            Dim tblRow As TableRow
            Dim tblCell As TableCell
            Dim lblLabel As Label

            tblRow = New TableRow
            ' New cell
            lblLabel = New Label
            lblLabel.Text = strLabel
            lblLabel.Width = Unit.Percentage(100)

            tblCell = New TableCell
            tblCell.HorizontalAlign = HorizontalAlign.Left
            tblCell.Controls.Add(lblLabel)
            tblCell.CssClass = "lbSubFormTitle"
            tblRow.Cells.Add(tblCell)
            If indextb = 1 Then
                tblInfor1.Rows.Add(tblRow)
            Else
                tblInfor2.Rows.Add(tblRow)
            End If
        End Sub

        ' BindData method
        ' Purpose: BindData
        Private Sub BindData(ByVal lngRequestID As Long)
            Dim tblRow As TableRow
            Dim tblCell As TableCell
            Dim tblTemp As DataTable
            Dim lblLabel As Label
            Dim intCount As Integer
            Dim strLabel As String

            ' Get detail infor of request
            objBILLOutRequest.IllID = lngRequestID
            tblTemp = objBILLOutRequest.GetORInfor
            ' Write Error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(1).Text, objBILLOutRequest.ErrorCode)

            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then

                    Page.RegisterClientScriptBlock("LoadRegID", "<script language='javascript'>LoadToSentForm(" & lngRequestID & "," & tblTemp.Rows(0).Item("Status") & ")</script>")
                    Dim intStatusReq As Integer = tblTemp.Rows(0).Item("Status")
                    Dim strStatusReq As String
                    Select Case intStatusReq
                        Case Is <= 22
                            strStatusReq = "<img src=""../images/stat" & Trim(intStatusReq) & ".gif""> (" & ddlStatusToolTip.Items(CInt(intStatusReq) - 1).Text & ")"
                        Case Else
                            strStatusReq = ""
                    End Select
                    ' Show request infor
                    AddTitle(1, ddlLabel1.Items(0).Text)
                    ' Add status request
                    AddInfor(1, ddlLabel1.Items(26).Text, strStatusReq)
                    ' Add library infor row
                    AddInfor(1, ddlLabel1.Items(1).Text, tblTemp.Rows(0).Item("LibrarySymbol") & ": " & tblTemp.Rows(0).Item("LibraryName"))
                    ' Add EmailReplyAddress row
                    AddInfor(1, ddlLabel1.Items(2).Text, tblTemp.Rows(0).Item("EmailReplyAddress"))
                    ' Add AccountNumber row
                    AddInfor(1, ddlLabel1.Items(3).Text, tblTemp.Rows(0).Item("AccountNumber"))
                    ' Add requestdate row
                    AddInfor(1, ddlLabel1.Items(4).Text, tblTemp.Rows(0).Item("DREQUESTDATE"))
                    ' Add NeedBeforeDate row
                    AddInfor(1, ddlLabel1.Items(5).Text, tblTemp.Rows(0).Item("DNEEDBEFOREDATE"))
                    ' Add dExpiryDate row
                    AddInfor(1, ddlLabel1.Items(6).Text, tblTemp.Rows(0).Item("DEXPIRYDATE"))
                    ' Add RequestID row
                    AddInfor(1, ddlLabel1.Items(7).Text, tblTemp.Rows(0).Item("RequestID"))
                    ' Add dServiceType row
                    AddInfor(1, ddlLabel1.Items(8).Text, tblTemp.Rows(0).Item("dServiceType"))
                    ' Add Priority row
                    If Not IsDBNull(tblTemp.Rows(intCount).Item("Priority")) Then
                        If Not Trim(tblTemp.Rows(intCount).Item("Priority")) = "" Then
                            Select Case tblTemp.Rows(0).Item("Priority")
                                Case "2"
                                    strLabel = ddlLabel1.Items(20).Text
                                Case Else
                                    strLabel = ddlLabel1.Items(19).Text
                            End Select
                            AddInfor(1, ddlLabel1.Items(9).Text, strLabel)
                        End If
                    End If
                    ' Add dCopyrightCompliance row
                    AddInfor(1, ddlLabel1.Items(10).Text, tblTemp.Rows(0).Item("dCopyrightCompliance"))
                    ' Add MaxCost row
                    If Not IsDBNull(tblTemp.Rows(0).Item("MaxCost")) AndAlso Trim(tblTemp.Rows(0).Item("MaxCost")) <> "" Then
                        AddInfor(1, ddlLabel1.Items(11).Text, CLng(tblTemp.Rows(0).Item("MaxCost")) & " " & tblTemp.Rows(0).Item("CurrencyCode"))
                    End If
                    ' Add dPaymentType row
                    AddInfor(1, ddlLabel1.Items(12).Text, tblTemp.Rows(0).Item("dPaymentType"))
                    ' Add ItempType row
                    AddInfor(1, ddlLabel1.Items(13).Text, tblTemp.Rows(0).Item("ItemTypeName"))
                    ' Add MediumDisplay row
                    AddInfor(1, ddlLabel1.Items(14).Text, tblTemp.Rows(0).Item("MediumDisplay"))
                    ' Add ReciprocalAgreement row
                    AddInforYesNo(1, ddlLabel1.Items(15).Text, tblTemp.Rows(0).Item("ReciprocalAgreement"))
                    ' Add WillPayFee row
                    AddInforYesNo(1, ddlLabel1.Items(16).Text, tblTemp.Rows(0).Item("WillPayFee"))
                    ' Add PaymentProvided row
                    AddInforYesNo(1, ddlLabel1.Items(17).Text, tblTemp.Rows(0).Item("PaymentProvided"))
                    ' Add Note row
                    AddInfor(1, ddlLabel1.Items(18).Text, tblTemp.Rows(0).Item("Note"))

                    ' Show process infor

                    AddTitle(1, ddlLabel2.Items(0).Text)
                    ' Add RespondDate row
                    AddInfor(1, ddlLabel2.Items(1).Text, tblTemp.Rows(0).Item("RESPONDDATE"), True)
                    ' Add ShippedDate row
                    AddInfor(1, ddlLabel2.Items(2).Text, tblTemp.Rows(0).Item("SHIPPEDDATE"), True)
                    ' Add ReceivedDate row
                    AddInfor(1, ddlLabel2.Items(3).Text, tblTemp.Rows(0).Item("RECEIVEDDATE"), True)
                    ' Add ReturnedDate row
                    AddInfor(1, ddlLabel2.Items(4).Text, tblTemp.Rows(0).Item("RETURNEDDATE"), True)
                    ' Add CheckedInDate row
                    AddInfor(1, ddlLabel2.Items(5).Text, tblTemp.Rows(0).Item("CHECKEDINDATE"), True)
                    ' Add CancelledDate row
                    AddInfor(1, ddlLabel2.Items(6).Text, tblTemp.Rows(0).Item("CANCELLEDDATE"), True)
                    ' Add LoanTypeID row
                    'AddInfor(1, ddlLabel2.Items(7).Text, tblTemp.Rows(0).Item("LoanType"), True)
                    ' Add DueDate row
                    AddInfor(1, ddlLabel2.Items(8).Text, tblTemp.Rows(0).Item("DUEDATE"), True)
                    ' Add LocalDueDate row
                    AddInfor(1, ddlLabel2.Items(9).Text, tblTemp.Rows(0).Item("LOCALDUEDATE"), True)
                    ' Add LocalCheckedOutDate row
                    'AddInfor(1, ddlLabel2.Items(10).Text, tblTemp.Rows(0).Item("LOCALCHECKEDOUTDATE"), True)
                    ' Add LocalCheckedInDate row
                    'AddInfor(1, ddlLabel2.Items(11).Text, tblTemp.Rows(0).Item("LOCALCHECKEDINDATE"), True)
                    ' Add Renewals row
                    AddInfor(1, ddlLabel2.Items(12).Text, tblTemp.Rows(0).Item("Renewals"), True)

                    ' Show item
                    AddTitle(2, ddlLabel3.Items(0).Text)
                    ' Add title row
                    AddInfor(2, ddlLabel3.Items(1).Text, tblTemp.Rows(0).Item("TITLE"))
                    ' Add Edition row
                    AddInfor(2, ddlLabel3.Items(2).Text, tblTemp.Rows(0).Item("Edition"))
                    ' Add Author row
                    AddInfor(2, ddlLabel3.Items(3).Text, tblTemp.Rows(0).Item("Author"))
                    ' Add SponsoringBody row
                    AddInfor(2, ddlLabel3.Items(4).Text, tblTemp.Rows(0).Item("SponsoringBody"))
                    ' Add PlaceOfPub row
                    AddInfor(2, ddlLabel3.Items(5).Text, tblTemp.Rows(0).Item("PlaceOfPub"))
                    ' Add Publisher row
                    AddInfor(2, ddlLabel3.Items(6).Text, tblTemp.Rows(0).Item("Publisher"))
                    ' Add PubDate row
                    AddInfor(2, ddlLabel3.Items(7).Text, tblTemp.Rows(0).Item("PUBDATE"))
                    ' Add SystemNumber row
                    AddInfor(2, ddlLabel3.Items(8).Text, tblTemp.Rows(0).Item("SystemNumber"))
                    ' Add ArticleTitle row
                    AddInfor(2, ddlLabel3.Items(9).Text, tblTemp.Rows(0).Item("ArticleTitle"))
                    ' Add ArticleAuthor row
                    AddInfor(2, ddlLabel3.Items(10).Text, tblTemp.Rows(0).Item("ArticleAuthor"))
                    ' Add VolumeIssue row
                    AddInfor(2, ddlLabel3.Items(11).Text, tblTemp.Rows(0).Item("VolumeIssue"))
                    ' Add ComponentPubDate row
                    AddInfor(2, ddlLabel3.Items(12).Text, tblTemp.Rows(0).Item("COMPONENTPUBDATE"))
                    ' Add Pagination row
                    AddInfor(2, ddlLabel3.Items(13).Text, tblTemp.Rows(0).Item("Pagination"))
                    ' Add CallNumber row
                    AddInfor(2, ddlLabel3.Items(14).Text, tblTemp.Rows(0).Item("CallNumber"))
                    ' Add ISBN row
                    AddInfor(2, ddlLabel3.Items(15).Text, tblTemp.Rows(0).Item("ISBN"))
                    ' Add ISSN row
                    AddInfor(2, ddlLabel3.Items(16).Text, tblTemp.Rows(0).Item("ISSN"))
                    ' Add SeriesTitleNumber row
                    AddInfor(2, ddlLabel3.Items(17).Text, tblTemp.Rows(0).Item("SeriesTitleNumber"))
                    ' Add OtherNumbers row
                    AddInfor(2, ddlLabel3.Items(18).Text, tblTemp.Rows(0).Item("OtherNumbers"))
                    ' Add Verification row
                    AddInfor(2, ddlLabel3.Items(19).Text, tblTemp.Rows(0).Item("Verification"))

                    ' Show patron infor
                    AddTitle(2, ddlLabel3.Items(20).Text)
                    ' Add PatronName row
                    AddInfor(2, ddlLabel3.Items(21).Text, tblTemp.Rows(0).Item("PatronName"))
                    ' Add PatronCode row
                    AddInfor(2, ddlLabel3.Items(22).Text, tblTemp.Rows(0).Item("PatronCode"))
                    ' Add PatronName row
                    AddInfor(2, ddlLabel3.Items(23).Text, tblTemp.Rows(0).Item("PATRONGROUP"))

                    ' Show delivery infor
                    AddTitle(2, ddlLabel4.Items(0).Text)
                    Select Case tblTemp.Rows(0).Item("DelivMode")
                        Case "1"
                            ' add title
                            AddSubTitle(2, ddlLabel4.Items(10).Text)
                            ' Add EDelivMode row
                            AddInfor(2, ddlLabel4.Items(11).Text, tblTemp.Rows(0).Item("EDELIVMODE"))
                            ' Add EDelivTSAddr row
                            AddInfor(2, ddlLabel4.Items(12).Text, tblTemp.Rows(0).Item("EDELIVTSADDR"))
                        Case Else
                            AddSubTitle(2, ddlLabel4.Items(9).Text)
                            ' Add Address row
                            AddInfor(2, ddlLabel4.Items(1).Text, tblTemp.Rows(0).Item("PostDelivName"))
                            ' Add XAddress row
                            AddInfor(2, ddlLabel4.Items(2).Text, tblTemp.Rows(0).Item("PostDelivXAddr"))
                            ' Add Street row
                            AddInfor(2, ddlLabel4.Items(3).Text, tblTemp.Rows(0).Item("PostDelivStreet"))
                            ' Add POBox row
                            AddInfor(2, ddlLabel4.Items(4).Text, tblTemp.Rows(0).Item("PostDelivBox"))
                            ' Add City row
                            AddInfor(2, ddlLabel4.Items(5).Text, tblTemp.Rows(0).Item("PostDelivCity"))
                            ' Add Region row
                            AddInfor(2, ddlLabel4.Items(6).Text, tblTemp.Rows(0).Item("PostDelivRegion"))
                            ' Add Country row
                            AddInfor(2, ddlLabel4.Items(7).Text, tblTemp.Rows(0).Item("PostCountry"))
                            ' Add PostCode row
                            AddInfor(2, ddlLabel4.Items(8).Text, tblTemp.Rows(0).Item("PostDelivCode"))
                    End Select

                    ' Show payment infor
                    AddTitle(2, ddlLabel5.Items(0).Text)
                    ' Add ChargeableUnits row
                    AddInfor(2, ddlLabel5.Items(1).Text, tblTemp.Rows(0).Item("ChargeableUnits"), True)
                    ' Add Cost row
                    If Not IsDBNull(tblTemp.Rows(0).Item("Cost")) AndAlso Trim(tblTemp.Rows(0).Item("Cost")) <> "" Then
                        AddInfor(2, ddlLabel5.Items(2).Text, tblTemp.Rows(0).Item("Cost") & " " & tblTemp.Rows(0).Item("CurrencyCode1"), True)
                    Else
                        AddInfor(2, ddlLabel5.Items(2).Text, "", True)
                    End If
                    ' Add InsuredForCost row
                    If Not IsDBNull(tblTemp.Rows(0).Item("InsuredForCost")) AndAlso Trim(tblTemp.Rows(0).Item("InsuredForCost")) <> "" Then
                        AddInfor(2, ddlLabel5.Items(3).Text, tblTemp.Rows(0).Item("InsuredForCost") & " " & tblTemp.Rows(0).Item("CurrencyCode2"), True)
                    Else
                        AddInfor(2, ddlLabel5.Items(3).Text, "", True)
                    End If
                    ' Add ReturnInsuranceCost row
                    If Not IsDBNull(tblTemp.Rows(0).Item("ReturnInsuranceCost")) AndAlso Trim(tblTemp.Rows(0).Item("ReturnInsuranceCost")) <> "" Then
                        AddInfor(2, ddlLabel5.Items(4).Text, tblTemp.Rows(0).Item("ReturnInsuranceCost") & " " & tblTemp.Rows(0).Item("CurrencyCode3"), True)
                    Else
                        AddInfor(2, ddlLabel5.Items(4).Text, "", True)
                    End If

                    ' Show address payment infor
                    AddSubTitle(2, ddlLabel5.Items(5).Text)
                    ' Add Address row
                    AddInfor(2, ddlLabel5.Items(6).Text, tblTemp.Rows(0).Item("BillDelivName"))
                    ' Add XAddress row
                    AddInfor(2, ddlLabel5.Items(7).Text, tblTemp.Rows(0).Item("BillDelivXAddr"))
                    ' Add Street row
                    AddInfor(2, ddlLabel5.Items(8).Text, tblTemp.Rows(0).Item("BillDelivStreet"))
                    ' Add POBox row
                    AddInfor(2, ddlLabel5.Items(9).Text, tblTemp.Rows(0).Item("BillDelivBox"))
                    ' Add City row
                    AddInfor(2, ddlLabel5.Items(10).Text, tblTemp.Rows(0).Item("BillDelivCity"))
                    ' Add Region row
                    AddInfor(2, ddlLabel5.Items(11).Text, tblTemp.Rows(0).Item("BillDelivRegion"))
                    ' Add Country row
                    AddInfor(2, ddlLabel5.Items(12).Text, tblTemp.Rows(0).Item("BillCountry"))
                    ' Add PostCode row
                    AddInfor(2, ddlLabel5.Items(13).Text, tblTemp.Rows(0).Item("BillDelivCode"))
                End If
            End If
        End Sub

        ' btnMoveFirst_Click event
        Private Sub btnMoveFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveFirst.Click
            Call LoadForm()
        End Sub

        ' btnMovePrev_Click event
        Private Sub btnMovePrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMovePrev.Click
            Call LoadForm()
        End Sub

        ' btnMoveNext_Click event
        Private Sub btnMoveNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveNext.Click
            Call LoadForm()
        End Sub

        ' btnMoveLast_Click event
        Private Sub btnMoveLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveLast.Click
            Call LoadForm()
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBPhyDelAddress Is Nothing Then
                    objBPhyDelAddress.Dispose(True)
                    objBPhyDelAddress = Nothing
                End If
                If Not objBILLOutRequest Is Nothing Then
                    objBILLOutRequest.Dispose(True)
                    objBILLOutRequest = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace