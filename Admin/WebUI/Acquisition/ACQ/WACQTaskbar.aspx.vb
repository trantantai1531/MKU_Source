' class WACQTaskBar
' Puspose: Display Taskbar to control display label
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

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WACQTaskbar
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
        Private objBT As New clsBTemplate
        Private objBCopyNumber As New clsBCopyNumber
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Initialize()
            If Not Page.IsPostBack Then
                If Not Session("IDs") Is Nothing Then
                    If UBound(Session("IDs")) >= 0 Then
                        Dim collAcq As New Collection
                        collAcq = Session("collAcq")
                        txtCurrentPage.Text = 1
                        lblMaxPage.Text = collAcq.Item("maxpage")
                        Dim ids() As String = Session("IDs")
                        Dim arr() As Integer = ids.Where(Function(x) x IsNot Nothing AndAlso x <> "").Select(Function(x) Integer.Parse(x)).ToArray()
                        If arr.Length > 0 Then
                            lblCopyNumberCount.Text = arr.Length
                            lblItemCount.Text = objBCopyNumber.CountCopyNumbers(arr) 'String[] to Int[]
                        Else
                            txtCurrentPage.Text = 0
                            lblMaxPage.Text = 0
                            lblItemCount.Text = 0
                            lblCopyNumberCount.Text = 0
                        End If

                    Else
                        txtCurrentPage.Text = 0
                        lblMaxPage.Text = 0
                        lblItemCount.Text = 0
                        lblCopyNumberCount.Text = 0
                    End If
                Else
                    txtCurrentPage.Text = 0
                    lblMaxPage.Text = 0
                    lblItemCount.Text = 0
                    lblCopyNumberCount.Text = 0
                End If
            End If
            ' Must put BindScript method here
            Call BindScript()
        End Sub

        Private Sub Initialize()
            ' Init objBT object
            objBT.InterfaceLanguage = Session("InterfaceLanguage")
            objBT.DBServer = Session("DBServer")
            objBT.ConnectionString = Session("ConnectionString")
            Call objBT.Initialize()

            ' Init objBCopyNumber object
            objBCopyNumber.InterfaceLanguage = Session("InterfaceLanguage")
            objBCopyNumber.DBServer = Session("DBServer")
            objBCopyNumber.ConnectionString = Session("ConnectionString")
            Call objBCopyNumber.Initialize()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "WAcqTaskbarJs", "<script type='text/javascript' src='../Js/ACQ/WAcqForm.js'></script>", False)
            btnPrevious.Attributes.Add("OnClick", "javascript:PreviousClick(" & lblMaxPage.Text & ",document.forms[0].txtCurrentPage.value);return false;")
            btnNext.Attributes.Add("OnClick", "javascript:NextClick(" & lblMaxPage.Text & ", document.forms[0].txtCurrentPage.value);return false;")
            txtCurrentPage.Attributes.Add("onKeyDown", "javascript:if(event.keyCode == 13 || event.which == 13 ) {CurrentPageChange(" & lblMaxPage.Text & ",document.forms[0].txtCurrentPage.value);return false;}")
            hrfReChoice.NavigateUrl = "javascript:parent.parent.mainacq.location.href='WACQForm.aspx';"
        End Sub

        Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
            Try
                If Not Session("IDs") Is Nothing Then
                    'Me.ShowWaitingOnPage(ddlLabel.Items(0).Text, "..\..")
                    Dim lngStartID, lngStopID, lngi As Long
                    Dim collAcq As New Collection
                    Dim strIDs As String = ""
                    Dim arrIDs As Object

                    collAcq = Session("collAcq")
                    arrIDs = Session("IDs")
                    lngStartID = 0
                    lngStopID = Session("CountIDs")

                    If UBound(arrIDs) < lngStopID Then
                        lngStopID = UBound(arrIDs)
                    End If
                    For lngi = lngStartID To lngStopID
                        strIDs &= arrIDs(lngi) & ", "
                    Next
                    If Not strIDs & "" = "" Then
                        Response.ClearContent()
                        Response.AppendHeader("content-disposition", "attachment;filename=export_" & DateTime.Now.Year.ToString() & DateTime.Now.Month.ToString() & DateTime.Now.Day.ToString() & DateTime.Now.Hour.ToString() & DateTime.Now.Minute.ToString() & DateTime.Now.Second.ToString() & DateTime.Now.Millisecond.ToString() & ".doc")
                        Response.Charset = "UTF-8"
                        Response.Cache.SetCacheability(HttpCacheability.NoCache)
                        Response.ContentType = "application/msword"
                        Response.ContentEncoding = Encoding.Unicode
                        Response.BinaryWrite(Encoding.Unicode.GetPreamble())

                        strIDs = Left(strIDs, strIDs.Length - 2)
                        Dim OutMsg = objBT.GenACQReport(collAcq.Item("formal"), lngStartID, lngStopID, strIDs, collAcq)
                        Dim header = objBT.PageHeader
                        Dim footer = objBT.PageFooter
                        '' gen data to Word 
                        Dim wordHelper As New clsBExportHelper
                        Dim strHTMLContent As New StringBuilder()


                        strHTMLContent.Append("<html xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:w='urn:schemas-microsoft-com:office:word' xmlns='www.w3.org/TR/REC-html40'>")
                        strHTMLContent.Append("<head>")
                        strHTMLContent.Append("<title></title>")
                        strHTMLContent.Append("<!--[if gte mso 9]>")
                        strHTMLContent.Append("<xml>" & clsBExportHelper.Xml_Word() & "</xml>")
                        strHTMLContent.Append("<![endif]-->")
                        strHTMLContent.Append("<style>" & clsBExportHelper.css_word("2cm", "1cm", "2cm", "1cm", False) & "</style>")
                        strHTMLContent.Append("</head>")
                        strHTMLContent.Append("<body lang=EN-US style='tab-interval:.5in'>")
                        strHTMLContent.Append("<div class=Section1>")
                        strHTMLContent.Append("<p>" & clsBExportHelper.GenHeader(hidLeftTable.Value, hidRightTable.Value, hidTitleTable.Value) & "</p>")
                        '& ": " & ddlKeyword.SelectedItem.Text.ToUpper
                        strHTMLContent.Append("<br/>")
                        strHTMLContent.Append("<tr><td width='100%' align='left'><Label  Width='100%'>" & OutMsg.ToString() & "</Label></td></tr>")
                        strHTMLContent.Append("<tr><td width='100%' align='left'><Label  Width='100%'>" & footer & "</Label></td></tr>")
                        strHTMLContent.Append("</body></html>")

                        Response.Write(strHTMLContent)
                        Response.End()
                        Response.Flush()
                        'Page.RegisterClientScriptBlock("", "<script language='javascript'>parent.Display.Printvalue(" & strHTMLContent.ToString() & ");</script>")
                    End If

                End If

            Catch ex As Exception

            End Try
            'Me.ShowWaitingOnPage("", "", True)
        End Sub

        Private Sub btnExportExcell_Click(sender As Object, e As EventArgs) Handles btnExportExcell.Click
            Try
                If Not Session("IDs") Is Nothing Then
                    Dim lngStartID, lngStopID, lngi As Long
                    Dim collAcq As New Collection
                    Dim strIDs As String = ""
                    Dim arrIDs As Object

                    collAcq = Session("collAcq")
                    arrIDs = Session("IDs")
                    lngStartID = 0
                    lngStopID = Session("CountIDs")

                    If UBound(arrIDs) < lngStopID Then
                        lngStopID = UBound(arrIDs)
                    End If
                    For lngi = lngStartID To lngStopID
                        strIDs &= arrIDs(lngi) & ", "
                    Next
                    If Not strIDs & "" = "" Then
                        strIDs = Left(strIDs, strIDs.Length - 2)
                        clsExport.StringToExcel(objBT.GenACQReport(collAcq.Item("formal"), lngStartID, lngStopID, strIDs, collAcq))
                    End If
                End If
            Catch ex As Exception
            End Try
        End Sub
    End Class
End Namespace