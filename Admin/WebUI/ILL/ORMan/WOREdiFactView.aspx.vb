Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.ILL

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WOREdiFactView
        Inherits clsWBase

        ' Declare variables
        Private objBILLOutRequest As New clsBILLOutRequest
        Private tblORInfor As DataTable
        Private objBILLLibrary As New clsBILLLibrary
        Private strInterChangeSender As String
        Private strRequesterSymbol As String
        Private strRequesterName As String
        Private strInterchangeRecipient As String
        Private strResponderSymbol As String
        Private strResponderName As String
        Private strPreparationDate As String
        Private strInterchangeControlRef As String
        Private strServiceDate As String
        Private intSegmentNo As Integer
        Private strSCHLine As String
        Private strExpiryDate As String
        Dim strNeedBeforeDate As String

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

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' CheckFormPermission method
        Private Sub CheckFormPermission()
            If Not CheckPemission(154) Then
                Page.RegisterClientScriptBlock("invaliduser", "<script language='javascript'>alert('" & ddlLabel.Items(3).Text & "'); self.close();</script>")
                Response.End()
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBILLOutRequest object 
            objBILLOutRequest.ConnectionString = Session("ConnectionString")
            objBILLOutRequest.DBServer = Session("DBServer")
            objBILLOutRequest.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBILLOutRequest.Initialize()

            ' Init objBILLLibrary object 
            objBILLLibrary.ConnectionString = Session("ConnectionString")
            objBILLLibrary.DBServer = Session("DBServer")
            objBILLLibrary.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBILLLibrary.Initialize()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            btnClose.Attributes.Add("OnClick", "self.close();")
        End Sub

        ' BindData method
        Private Sub BindData()
            ' Declare variables
            Dim blnExist As Boolean = True

            ' Check the existing of request
            If IsNumeric(Request("ILLID")) Then
                objBILLOutRequest.IllID = CLng(Request("ILLID"))
                tblORInfor = objBILLOutRequest.GetORInfor
                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(1).Text, objBILLOutRequest.ErrorCode)

                If Not tblORInfor Is Nothing Then
                    If tblORInfor.Rows.Count > 0 Then
                        Call FormILLREQ()
                    Else
                        blnExist = False
                    End If
                Else
                    blnExist = False
                End If
            Else
                blnExist = False
            End If

            ' The request is not exist or have not been selected requests
            If blnExist = False Then
                Page.RegisterClientScriptBlock("NotExist", "<script language='javascript'>alert('" & ddlLabel.Items(2).Text & "');self.close();</script>")
            End If
        End Sub

        ' FormILLREQ method
        Private Sub FormILLREQ()
            ' Declare variables
            Dim tblLibrary1 As DataTable
            Dim tblLibrary2 As DataTable

            tblLibrary1 = objBILLLibrary.GetLib(1)
            ' Write Error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLLibrary.ErrorMsg, ddlLabel.Items(1).Text, objBILLLibrary.ErrorCode)

            tblLibrary2 = objBILLLibrary.GetLocalLib()
            ' Write Error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLLibrary.ErrorMsg, ddlLabel.Items(1).Text, objBILLLibrary.ErrorCode)

            If Not tblLibrary1 Is Nothing Then
                If tblLibrary1.Rows.Count > 0 Then
                    If Not IsDBNull(tblLibrary1.Rows(0).Item("LibrarySymbol")) Then
                        strInterChangeSender = tblLibrary1.Rows(0).Item("LibrarySymbol")
                        strRequesterSymbol = tblLibrary1.Rows(0).Item("LibrarySymbol")
                    End If
                    If Not IsDBNull(tblLibrary1.Rows(0).Item("LibraryName")) Then
                        strRequesterName = tblLibrary1.Rows(0).Item("LibraryName")
                    End If
                End If
            End If
            If Not IsDBNull(tblORInfor.Rows(0).Item("LibrarySymbol")) Then
                strInterchangeRecipient = tblORInfor.Rows(0).Item("LibrarySymbol")
                strResponderSymbol = tblORInfor.Rows(0).Item("LibrarySymbol")
            End If
            If Not IsDBNull(tblORInfor.Rows(0).Item("LibraryName")) Then
                strResponderName = tblORInfor.Rows(0).Item("LibraryName")
            End If
            strPreparationDate = Right(CStr(Year(Now)), 2) & StrDup(2 - Len(CStr(Month(Now))), "0") & CStr(Month(Now)) & StrDup(2 - Len(CStr(Day(Now))), "0") & CStr(Day(Now)) & ":" & StrDup(2 - Len(CStr(Hour(Now))), "0") & CStr(Hour(Now)) & StrDup(2 - Len(CStr(Minute(Now))), "0") & CStr(Minute(Now))
            strInterchangeControlRef = Right(CStr(Year(Now)), 2) & StrDup(2 - Len(CStr(Month(Now))), "0") & CStr(Month(Now)) & StrDup(2 - Len(CStr(Day(Now))), "0") & CStr(Day(Now)) & StrDup(2 - Len(CStr(Hour(Now))), "0") & CStr(Hour(Now)) & StrDup(2 - Len(CStr(Minute(Now))), "0") & CStr(Minute(Now)) & StrDup(2 - Len(CStr(Second(Now))), "0") & CStr(Second(Now)) & "00"
            strServiceDate = CStr(Year(Now)) & StrDup(2 - Len(CStr(Month(Now))), "0") & CStr(Month(Now)) & StrDup(2 - Len(CStr(Day(Now))), "0") & CStr(Day(Now)) & StrDup(2 - Len(CStr(Hour(Now))), "0") & CStr(Hour(Now)) & StrDup(2 - Len(CStr(Minute(Now))), "0") & CStr(Minute(Now)) & StrDup(2 - Len(CStr(Second(Now))), "0") & CStr(Second(Now))
            intSegmentNo = 17

            lblContent.Text = "UNA:+?'<BR>"
            lblContent.Text = lblContent.Text & "UNB+UNOB:1+" & strInterChangeSender & "+" & strInterchangeRecipient & "+" & strPreparationDate & "+" & strInterchangeControlRef & "+ISO-10161-ILL-1UNH+"
            lblContent.Text = lblContent.Text & strInterchangeControlRef & "+ILLREQ:1'<BR>PVN+1'<BR>TRI+:"
            lblContent.Text = lblContent.Text & strRequesterSymbol & "+:" & strRequesterName & "+" & tblORInfor.Rows(0).Item("RequestID")
            lblContent.Text = lblContent.Text & "+LIBOLILL+'<BR>STD+" & strServiceDate & "'<BR>RQI+:" & strRequesterSymbol & "+:"
            lblContent.Text = lblContent.Text & strRequesterName & "'<BR>RSI+:" & strResponderSymbol & "+:" & strResponderName & "'<BR>"
            lblContent.Text = lblContent.Text & "TRT+1'<BR>"
            If Not IsDBNull(tblORInfor.Rows(0).Item("DeliveryLocID")) Then
                If IsNumeric(tblORInfor.Rows(0).Item("DeliveryLocID")) Then
                    tblLibrary2 = objBILLLibrary.GetLocalLib(CInt(tblORInfor.Rows(0).Item("DeliveryLocID")))
                    If Not tblLibrary2 Is Nothing Then
                        If tblLibrary2.Rows.Count > 0 Then
                            intSegmentNo = intSegmentNo + 2
                            lblContent.Text = lblContent.Text & "DAD+'<BR>PAD+:"
                            If Not IsDBNull(tblLibrary2.Rows(0).Item("Address")) Then
                                lblContent.Text = lblContent.Text & tblLibrary2.Rows(0).Item("Address") & "+"
                            End If
                            If Not IsDBNull(tblLibrary2.Rows(0).Item("XAddress")) Then
                                lblContent.Text = lblContent.Text & tblLibrary2.Rows(0).Item("XAddress") & "+"
                            End If
                            If Not IsDBNull(tblLibrary2.Rows(0).Item("Street")) Then
                                lblContent.Text = lblContent.Text & tblLibrary2.Rows(0).Item("Street") & "+"
                            End If
                            If Not IsDBNull(tblLibrary2.Rows(0).Item("POBox")) Then
                                lblContent.Text = lblContent.Text & tblLibrary2.Rows(0).Item("POBox") & "+"
                            End If
                            If Not IsDBNull(tblLibrary2.Rows(0).Item("City")) Then
                                lblContent.Text = lblContent.Text & tblLibrary2.Rows(0).Item("City") & "+"
                            End If
                            If Not IsDBNull(tblLibrary2.Rows(0).Item("Region")) Then
                                lblContent.Text = lblContent.Text & tblLibrary2.Rows(0).Item("Region") & "+"
                            End If
                            If Not IsDBNull(tblLibrary2.Rows(0).Item("DisplayEntry")) Then
                                lblContent.Text = lblContent.Text & tblLibrary2.Rows(0).Item("DisplayEntry") & "+"
                            End If
                            If Not IsDBNull(tblLibrary2.Rows(0).Item("PostCode")) Then
                                lblContent.Text = lblContent.Text & tblLibrary2.Rows(0).Item("PostCode") & "'<BR>"
                            End If
                        End If
                    End If
                End If
            End If
            If Not IsDBNull(tblORInfor.Rows(0).Item("BillingLocID")) Then
                If IsNumeric(tblORInfor.Rows(0).Item("BillingLocID")) Then
                    tblLibrary2 = objBILLLibrary.GetLocalLib(CInt(tblORInfor.Rows(0).Item("BillingLocID")))
                    If Not tblLibrary2 Is Nothing Then
                        If tblLibrary2.Rows.Count > 0 Then
                            intSegmentNo = intSegmentNo + 2
                            lblContent.Text = lblContent.Text & "BAD+'<BR>PAD+:"
                            If Not IsDBNull(tblLibrary2.Rows(0).Item("Address")) Then
                                lblContent.Text = lblContent.Text & tblLibrary2.Rows(0).Item("Address") & "+"
                            End If
                            If Not IsDBNull(tblLibrary2.Rows(0).Item("XAddress")) Then
                                lblContent.Text = lblContent.Text & tblLibrary2.Rows(0).Item("XAddress") & "+"
                            End If
                            If Not IsDBNull(tblLibrary2.Rows(0).Item("Street")) Then
                                lblContent.Text = lblContent.Text & tblLibrary2.Rows(0).Item("Street") & "+"
                            End If
                            If Not IsDBNull(tblLibrary2.Rows(0).Item("POBox")) Then
                                lblContent.Text = lblContent.Text & tblLibrary2.Rows(0).Item("POBox") & "+"
                            End If
                            If Not IsDBNull(tblLibrary2.Rows(0).Item("City")) Then
                                lblContent.Text = lblContent.Text & tblLibrary2.Rows(0).Item("City") & "+"
                            End If
                            If Not IsDBNull(tblLibrary2.Rows(0).Item("Region")) Then
                                lblContent.Text = lblContent.Text & tblLibrary2.Rows(0).Item("Region") & "+"
                            End If
                            If Not IsDBNull(tblLibrary2.Rows(0).Item("DisplayEntry")) Then
                                lblContent.Text = lblContent.Text & tblLibrary2.Rows(0).Item("DisplayEntry") & "+"
                            End If
                            If Not IsDBNull(tblLibrary2.Rows(0).Item("PostCode")) Then
                                lblContent.Text = lblContent.Text & tblLibrary2.Rows(0).Item("PostCode") & "'<BR>"
                            End If
                        End If
                    End If
                End If
            End If
            If Not IsDBNull(tblORInfor.Rows(0).Item("ServiceType")) Then
                lblContent.Text = lblContent.Text & "ISV+" & tblORInfor.Rows(0).Item("ServiceType") & "'<BR>"
                lblContent.Text = lblContent.Text & "ROM(+0 + 0 + 3 + 3) '<BR>"
            End If
            If Not IsDBNull(tblORInfor.Rows(0).Item("NEEDBEFOREDATE")) Then
                If Not CStr(tblORInfor.Rows(0).Item("NEEDBEFOREDATE")) = "" Then
                    strNeedBeforeDate = Year(CDate(tblORInfor.Rows(0).Item("NEEDBEFOREDATE"))) & _
                    StrDup(2 - Len(CStr(Month(CDate(tblORInfor.Rows(0).Item("NEEDBEFOREDATE"))))), "0") & _
                    CStr(Month(CDate(tblORInfor.Rows(0).Item("NEEDBEFOREDATE")))) & StrDup(2 - Len(CStr(Day(CDate(tblORInfor.Rows(0).Item("NEEDBEFOREDATE"))))), "0") & _
                    CStr(Day(CDate(tblORInfor.Rows(0).Item("NEEDBEFOREDATE"))))
                    strSCHLine = "SCH++" & tblORInfor.Rows(0).Item("NEEDBEFOREDATE")
                    If Not IsDBNull(tblORInfor.Rows(0).Item("EXPIRYDATE")) Then
                        If Not CStr(tblORInfor.Rows(0).Item("EXPIRYDATE")) = "" Then
                            strExpiryDate = Year(CDate(tblORInfor.Rows(0).Item("EXPIRYDATE"))) & _
                            StrDup(2 - Len(CStr(Month(CDate(tblORInfor.Rows(0).Item("EXPIRYDATE"))))), "0") & _
                            CStr(Month(CDate(tblORInfor.Rows(0).Item("EXPIRYDATE")))) & StrDup(2 - Len(CStr(Day(CDate(tblORInfor.Rows(0).Item("NEEDBEFOREDATE"))))), "0") & _
                            CStr(Day(CDate(tblORInfor.Rows(0).Item("EXPIRYDATE"))))
                            strSCHLine = strSCHLine & "+2+" & tblORInfor.Rows(0).Item("EXPIRYDATE") & "'"
                        Else
                            strSCHLine = strSCHLine & "+3+'"
                        End If
                    End If
                    intSegmentNo = intSegmentNo + 1
                    lblContent.Text = lblContent.Text & strSCHLine & "<BR>"
                End If
            End If

            If Not IsDBNull(tblORInfor.Rows(0).Item("Medium")) Then
                lblContent.Text = lblContent.Text & "SMI+" & tblORInfor.Rows(0).Item("Medium") & "'<BR>POH(+2)'<BR>"
            End If
            If Not IsDBNull(tblORInfor.Rows(0).Item("PatronName")) Then
                lblContent.Text = lblContent.Text & "CID+" & tblORInfor.Rows(0).Item("PatronName") & "++'<BR>"
            End If
            If Not IsDBNull(tblORInfor.Rows(0).Item("ItemType")) Then
                lblContent.Text = lblContent.Text & "IID+" & tblORInfor.Rows(0).Item("ItemType") & "+"
            End If
            If Not IsDBNull(tblORInfor.Rows(0).Item("Medium")) Then
                lblContent.Text = lblContent.Text & tblORInfor.Rows(0).Item("Medium") & "+"
            End If
            If Not IsDBNull(tblORInfor.Rows(0).Item("CallNumber")) Then
                lblContent.Text = lblContent.Text & tblORInfor.Rows(0).Item("CallNumber") & "+"
            End If
            If Not IsDBNull(tblORInfor.Rows(0).Item("Author")) Then
                lblContent.Text = lblContent.Text & tblORInfor.Rows(0).Item("Author") & "+"
            End If
            If Not IsDBNull(tblORInfor.Rows(0).Item("Title")) Then
                lblContent.Text = lblContent.Text & tblORInfor.Rows(0).Item("Title") & "++"
            End If
            If Not IsDBNull(tblORInfor.Rows(0).Item("SponsoringBody")) Then
                lblContent.Text = lblContent.Text & tblORInfor.Rows(0).Item("SponsoringBody") & "+"
            End If
            If Not IsDBNull(tblORInfor.Rows(0).Item("PlaceOfPub")) Then
                lblContent.Text = lblContent.Text & tblORInfor.Rows(0).Item("PlaceOfPub") & "+"
            End If
            If Not IsDBNull(tblORInfor.Rows(0).Item("Publisher")) Then
                lblContent.Text = lblContent.Text & tblORInfor.Rows(0).Item("Publisher") & "+"
            End If
            If Not IsDBNull(tblORInfor.Rows(0).Item("SeriesTitleNumber")) Then
                lblContent.Text = lblContent.Text & tblORInfor.Rows(0).Item("SeriesTitleNumber") & "+"
            End If
            If Not IsDBNull(tblORInfor.Rows(0).Item("VolumeIssue")) Then
                lblContent.Text = lblContent.Text & tblORInfor.Rows(0).Item("VolumeIssue") & "+"
            End If
            If Not IsDBNull(tblORInfor.Rows(0).Item("Edition")) Then
                lblContent.Text = lblContent.Text & tblORInfor.Rows(0).Item("Edition") & "+"
            End If
            If Not IsDBNull(tblORInfor.Rows(0).Item("PUBDATE")) Then
                lblContent.Text = lblContent.Text & tblORInfor.Rows(0).Item("PUBDATE") & "+"
            End If
            If Not IsDBNull(tblORInfor.Rows(0).Item("COMPONENTPUBDATE")) Then
                lblContent.Text = lblContent.Text & tblORInfor.Rows(0).Item("COMPONENTPUBDATE") & "+"
            End If
            If Not IsDBNull(tblORInfor.Rows(0).Item("ArticleAuthor")) Then
                lblContent.Text = lblContent.Text & tblORInfor.Rows(0).Item("ArticleAuthor") & "+"
            End If
            If Not IsDBNull(tblORInfor.Rows(0).Item("Pagination")) Then
                lblContent.Text = lblContent.Text & tblORInfor.Rows(0).Item("Pagination") & "+1 2 124 10161"
            End If
            If Not IsDBNull(tblORInfor.Rows(0).Item("NationalBibNumber")) Then
                lblContent.Text = lblContent.Text & "1:3:" & tblORInfor.Rows(0).Item("NationalBibNumber") & "+"
            End If
            If Not IsDBNull(tblORInfor.Rows(0).Item("ISBN")) Then
                lblContent.Text = lblContent.Text & tblORInfor.Rows(0).Item("ISBN") & "+1 2 124 10161"
            End If
            If Not IsDBNull(tblORInfor.Rows(0).Item("SystemNumber")) Then
                lblContent.Text = lblContent.Text & "2:6:" & tblORInfor.Rows(0).Item("SystemNumber") & "+"
            End If
            If Not IsDBNull(tblORInfor.Rows(0).Item("OtherNumbers")) Then
                lblContent.Text = lblContent.Text & tblORInfor.Rows(0).Item("OtherNumbers") & "+"
            End If
            If Not IsDBNull(tblORInfor.Rows(0).Item("Verification")) Then
                lblContent.Text = lblContent.Text & tblORInfor.Rows(0).Item("Verification") & "'<BR>"
            End If
            If Not IsDBNull(tblORInfor.Rows(0).Item("AccountNumber")) Then
                lblContent.Text = lblContent.Text & "CIT+" & tblORInfor.Rows(0).Item("AccountNumber") & "+"
            End If
            If Not IsDBNull(tblORInfor.Rows(0).Item("ReciprocalAgreement")) Then
                lblContent.Text = lblContent.Text & tblORInfor.Rows(0).Item("CurrencyCode") & ":"
            End If
            If Not IsDBNull(tblORInfor.Rows(0).Item("MaxCost")) Then
                lblContent.Text = lblContent.Text & tblORInfor.Rows(0).Item("MaxCost") & "+"
            End If
            If Not IsDBNull(tblORInfor.Rows(0).Item("ReciprocalAgreement")) Then
                lblContent.Text = lblContent.Text & CInt(tblORInfor.Rows(0).Item("ReciprocalAgreement")) & "+"
            End If
            If Not IsDBNull(tblORInfor.Rows(0).Item("WillPayFee")) Then
                lblContent.Text = lblContent.Text & CInt(tblORInfor.Rows(0).Item("WillPayFee")) & "+"
            End If
            If Not IsDBNull(tblORInfor.Rows(0).Item("PaymentProvided")) Then
                lblContent.Text = lblContent.Text & CInt(tblORInfor.Rows(0).Item("PaymentProvided")) & "'<BR>"
            End If
            If Not IsDBNull(tblORInfor.Rows(0).Item("Note")) Then
                lblContent.Text = lblContent.Text & "COC+CCL'<BR>RQN+" & Replace(tblORInfor.Rows(0).Item("Note"), Chr(13), "") & "'<BR>"
            End If

            lblContent.Text = lblContent.Text & "UNT+" & StrDup(6 - Len(CStr(intSegmentNo)), "0") & CStr(intSegmentNo)
            lblContent.Text = lblContent.Text & "+" & strInterchangeControlRef & "'<BR>"
            lblContent.Text = lblContent.Text & "UNZ+000001+" & strInterchangeControlRef & "'<BR>"
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBILLOutRequest Is Nothing Then
                    objBILLOutRequest.Dispose(True)
                    objBILLOutRequest = Nothing
                End If
                If Not objBILLLibrary Is Nothing Then
                    objBILLLibrary.Dispose(True)
                    objBILLLibrary = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
