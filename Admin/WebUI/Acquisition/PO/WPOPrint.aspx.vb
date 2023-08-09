' class 
' Puspose: 
' Creator: 
' CreatedDate: 
' Modification History:

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WPOPrint
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

        Private objBIO As New clsBItemOrder
        Dim strDisplay As String
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                strDisplay = GenPOPrint()
                VisiableControls(True)
                If strDisplay = "" Then
                    Response.Redirect("WPOPrintSearch.aspx?Found=0")
                    Exit Sub
                End If
                lblDisplay.Text = strDisplay
                Select Case UCase(Request.QueryString("Flage"))
                    Case "PRINT"
                        VisiableControls(False)
                        Page.RegisterClientScriptBlock("PrintJs", "<script language='javascript'>Print();</script>")
                    Case "EMAIL"
                        hidToEmail.Value = Request("hidToEmail")
                        If SendEmailPO(strDisplay, True) Then
                            Page.RegisterClientScriptBlock("SendEmailSuccessfulJs", "<script language='javascript'>alert('" & ddlLabel.Items(4).Text & "');</script>")
                        Else
                            Page.RegisterClientScriptBlock("SendEmailUnSuccessfulJs", "<script language='javascript'>alert('" & ddlLabel.Items(5).Text & "');</script>")
                        End If
                    Case "FILE"
                        Dim strFileName As String
                        strFileName = objBIO.SaveToFile(strDisplay, "doc", True, Server.MapPath("../.."))
                        If objBIO.ErrorMsg <> "" Then
                            Page.RegisterClientScriptBlock("ErrrExportJs", "<script language='javascript'>alert('" & ddlLabel.Items(7).Text & "');</script>")
                        Else
                            Page.RegisterClientScriptBlock("DownLoadExportJs", "<script language='javascript'>parent.hiddenbase.location.href='../../Common/WSaveTempFile.aspx?ModuleID=4&FileName=" & strFileName & "';</script>")
                            lblDownload1.Visible = True
                            lblDownload2.Visible = True
                            lnkGetIt.Visible = True
                            lnkGetIt.Attributes.Add("OnClick", "parent.hiddenbase.location.href='../../Common/WSaveTempFile.aspx?ModuleID=4&FileName=" & strFileName & "';return false;")
                            lnkGetIt.NavigateUrl = "#"
                        End If
                End Select
                strDisplay = Replace(strDisplay, "<", "&lt;")
                strDisplay = Replace(strDisplay, ">", "&gt;")
                hdDisplay.Value = strDisplay
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            objBIO.InterfaceLanguage = Session("InterfaceLanguage")
            objBIO.DBServer = Session("DBServer")
            objBIO.ConnectionString = Session("ConnectionString")
            objBIO.Initialize()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("WCommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WPOPrintJs", "<script language='javascript' src='../Js/PO/WPOPrint.js'></script>")
            btnEdit.Attributes.Add("OnClick", "EncryptionTags('document.forms[0].hdDisplay');return(EditSubmit());")
            'btnPrint.Attributes.Add("OnClick", "Print();return(false);")
            btnEmail.Attributes.Add("OnClick", "if(!GetEmailName('','" & ddlLabel.Items(7).Text & "','" & ddlLabel.Items(8).Text & "'))return false;")
        End Sub

        ' Generate PO to print
        Private Function GenPOPrint() As String
            'Dim objTVCom As New TVCOMLib.utf8
            Dim collecHeaderFooter As New Collection
            Dim collecCollumTitle As New Collection
            Dim inti As Integer

            ' For Header and Footer
            collecHeaderFooter.Add(Request("txtCaption"), "TITLE")
            'collecHeaderFooter.Add(UCase(objTVCom.Upper(Request("txtCaption"))), "TITLE:UPPER")
            collecHeaderFooter.Add(UCase(Request("txtCaption")), "TITLE:UPPER")
            collecHeaderFooter.Add(Now(), "TODAY")
            collecHeaderFooter.Add(Day(Now()), "TODAY:DD")
            collecHeaderFooter.Add(Month(Now()), "TODAY:MM")
            collecHeaderFooter.Add(Year(Now()), "TODAY:YYYY")
            collecHeaderFooter.Add(Hour(Now()), "TODAY:HH")
            collecHeaderFooter.Add(Minute(Now()), "TODAY:MI")
            collecHeaderFooter.Add(Second(Now()), "TODAY:SS")
            objBIO.CollumHeaderFooter = collecHeaderFooter
            ' For Collum title
            For inti = 0 To ddlCollumTitle.Items.Count - 1
                collecCollumTitle.Add(ddlCollumTitle.Items(inti).Text, ddlCollumTitle.Items(inti).Value)
            Next
            objBIO.CollumTitle = collecCollumTitle
            objBIO.SumCurrency = Request("txtSumCurrency")
            objBIO.SumCurrencyRate = Request("ddlSumCurrency")
            If objBIO.SumCurrencyRate = 0 Then
                objBIO.SumCurrencyRate = 1.0
            End If
            objBIO.Accepted = Request("hdAccepted")
            objBIO.Publisher = Request("ddlPublisher")
            objBIO.TypeID = Request("ddlMedium")
            objBIO.MediumID = Request("ddlMedia")
            objBIO.Urgency = Request("ddlUrgency")
            objBIO.FromDate = Request("txtFromDate")
            objBIO.ToDate = Request("txtToDate")
            objBIO.Currency = Request("txtCurrency")
            objBIO.CurrencyRate = Request("ddlCurrency")
            If objBIO.CurrencyRate = 0 Then
                objBIO.CurrencyRate = 1.0
            End If
            objBIO.TemplateID = Request("ddlForm")
            objBIO.LibID = clsSession.GlbSite
            GenPOPrint = objBIO.POPrint
            'If Not objTVCom Is Nothing Then
            '    objTVCom = Nothing
            'End If
        End Function

        ' SendEmail method
        Private Function SendEmailPO(ByVal strContent As String, ByVal isHTML As Boolean) As Boolean
            Dim intSuccess As Integer

            intSuccess = SendMail(ddlLabel.Items(6).Text, strContent, hidToEmail.Value, isHTML)
            If intSuccess = 1 Then
                SendEmailPO = True
            Else
                SendEmailPO = False
            End If
        End Function

        ' SaveToFile method
        ' In: strContent
        ' Out: strFileName
        ' Creator: Sondp
        Private Function SaveToFile(ByVal strContent As String)
            SaveToFile = objBIO.SaveToFile(strContent, "doc", True, Server.MapPath("../.."))
        End Function

        ' Visiable controls method
        Private Sub VisiableControls(ByVal boolValue As Boolean)
            btnEdit.Visible = boolValue
            btnEmail.Visible = boolValue
            btnPrint.Visible = boolValue
        End Sub
        Private Sub Print(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
            strDisplay = GenPOPrint()
            VisiableControls(False)
            If strDisplay = "" Then
                Response.Redirect("WPOPrintSearch.aspx?Found=0")
                Exit Sub
            End If
            lblDisplay.Text = strDisplay
            VisiableControls(False)
            Page.RegisterClientScriptBlock("PrintJs", "<script language='javascript'>Print();</script>")
            strDisplay = Replace(strDisplay, "<", "&lt;")
            strDisplay = Replace(strDisplay, ">", "&gt;")
            hdDisplay.Value = strDisplay
        End Sub
        Private Sub btnEmail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEmail.Click
            Dim strDisplay As String = hdDisplay.Value
            strDisplay = Replace(strDisplay, "&lt;", "<")
            strDisplay = Replace(strDisplay, "&gt;", ">")

            If SendEmailPO(strDisplay, True) Then
                Page.RegisterClientScriptBlock("SendEmailSuccessfulJs", "<script language='javascript'>alert('" & ddlLabel.Items(4).Text & "');</script>")
            Else
                Page.RegisterClientScriptBlock("SendEmailUnSuccessfulJs", "<script language='javascript'>alert('" & ddlLabel.Items(5).Text & "');</script>")
            End If
        End Sub

        ' Page_Unload method
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBIO Is Nothing Then
                objBIO.Dispose(True)
                objBIO = Nothing
            End If
        End Sub
    End Class
End Namespace