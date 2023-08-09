' Class: WLabelPrintTaskbar
' Puspose: Print label
' Creator: Sondp
' CreatedDate: 22/02/2005
' Modification History:

Imports eMicLibAdmin.BusinessRules.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WLabelPrintTaskBar
        Inherits clsWBase

        Private objBT As New clsBTemplate

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call BindScript()
            If Not Page.IsPostBack Then
                If Not Session("IDs") Is Nothing And Not Session("ItemIDs") Is Nothing Then
                    If UBound(Session("IDs")) >= 0 And UBound(Session("ItemIDs")) >= 0 Then
                        txtCurrentPage.Text = 1
                        lblMaxPage.Text = Session("MaxPage")
                        hdMaxPage.Value = Session("MaxPage")
                    Else
                        txtCurrentPage.Text = "0"
                        lblMaxPage.Text = "0"
                        hdMaxPage.Value = 0
                    End If
                End If
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Initialize objBT object
            objBT.InterfaceLanguage = Session("InterfaceLanguage")
            objBT.DBServer = Session("DBServer")
            objBT.ConnectionString = Session("ConnectionString")
            objBT.Initialize()
        End Sub

        ' Method: BindScript
        Private Sub BindScript()
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "WLabelPrintTaskBarJs", "<script type='text/javascript' src='../Js/ACQ/WLabelPrintSearch.js'></script>", False)
            btnPrevious.Attributes.Add("OnClick", "PreviousClick(" & Session("MaxPage") & ",document.forms[0].txtCurrentPage.value);return false;")
            btnNext.Attributes.Add("OnClick", "NextClick(" & Session("MaxPage") & ", document.forms[0].txtCurrentPage.value);return false;")
            btnPrint.Attributes.Add("OnClick", "printDocument();return false;")
            txtCurrentPage.Attributes.Add("onKeyDown", "if(event.keyCode == 13 || event.which == 13 ) {CurrentPageChange(" & Session("MaxPage") & ",document.forms[0].txtCurrentPage.value);return false;}")
            hrfRequest.NavigateUrl = "javascript:parent.location.href='WLabelPrintSearch.aspx';"
        End Sub

        Private Sub btnExportCsv_Click(sender As Object, e As EventArgs) Handles btnExportCsv.Click
            Initialize()
            Dim lngStartID As Long
            lngStartID = 0
            If Not Session("ItemIDs") Is Nothing AndAlso Not Session("IDs") Is Nothing Then
                Dim max As Integer = Math.Min(DirectCast(Session("IDs"), Object()).Length, DirectCast(Session("ItemIDs"), Object()).Length) - 1
                Dim sb As StringBuilder = objBT.PrintAcqLabel_CSV(Session("IDs"), Session("ItemIDs"),
                                                                  Session("TemplateID"), Session("LibID"),
                                                                  Session("LocID"), lngStartID,
                                                                  max, 11000)
                StringBuilderToCsv(sb)
            Else
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "NoResultExport", "alert('Không có dữ liệu để xuất!)", True)
            End If
        End Sub

        Public Shared Sub StringBuilderToCsv(ByVal strBuilder As StringBuilder)
            System.Web.HttpContext.Current.Response.Clear()
            System.Web.HttpContext.Current.Response.Buffer = True
            System.Web.HttpContext.Current.Response.ContentType = "text/plain"
            System.Web.HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" & String.Format("{0:ddMMyyyyHHmmssttt}", System.DateTime.Now) & ".csv")

            System.Web.HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8
            System.Web.HttpContext.Current.Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble())
            System.Web.HttpContext.Current.Response.Output.Write(strBuilder.ToString())
            System.Web.HttpContext.Current.Response.Flush()
            System.Web.HttpContext.Current.Response.End()
        End Sub

        ' Page_Unload method
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBT Is Nothing Then
                objBT.Dispose(True)
                objBT = Nothing
            End If
        End Sub
    End Class
End Namespace