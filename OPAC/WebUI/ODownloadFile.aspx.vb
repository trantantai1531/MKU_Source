Imports eMicLibOPAC.BusinessRules.OPAC
Imports System.Net
Imports System.IO

Namespace eMicLibOPAC.WebUI.OPAC
    Public Class ODownloadFile
        Inherits clsWBaseJqueryUI
        Private objBItemDissertation As New clsBItemDissertation

        Private Sub Initialize()
            objBItemDissertation.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemDissertation.DBServer = Session("DBServer")
            objBItemDissertation.ConnectionString = Session("ConnectionString")
            objBItemDissertation.Initialize()
        End Sub
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                'Call Initialize()
                'objBItemDissertation.ItemID = CInt(Request("intItemId"))
                'objBItemDissertation.Year = CInt(Request("intYear"))
                'objBItemDissertation.Number = CInt(Request("intNumber"))
                'Call DownloadFile(CInt(Request("intItemId")), CInt(Request("intYear")), Request("strNumber"))
                If clsUICommon.checkPermission() Then
                    Call Initialize()
                    Call DownloadFile(CInt(Request("intItemId")), CInt(Request("intYear")), Request("strNumber"))
                    'Page.ClientScript.RegisterStartupScript(Page.GetType, "scriptName_FreeText", "<script type=""text/javascript"">close()</script>") 
                Else
                    Response.Redirect("OLoginRequest.aspx?RequestLogin=1", True)
                End If
            End If
            
        End Sub

        Protected Sub DownloadFile(ByVal intItemId As Integer, ByVal intYear As Integer, ByVal intNumber As String)
            objBItemDissertation.ItemID = intItemId
            objBItemDissertation.Year = intYear
            objBItemDissertation.Number = intNumber
            Dim item As DataTable = objBItemDissertation.GetItemDissertation()
            If Not IsNothing(item) Then
                Dim strTime As String = DateAndTime.Now.Year & DateAndTime.Now.Month & DateAndTime.Now.Day & DateAndTime.Now.Hour & DateAndTime.Now.Minute & DateAndTime.Now.Second & DateAndTime.Now.Millisecond

                Response.Clear()
                Response.AddHeader("content-disposition", "attachment;filename=File_" & strTime & ".pdf")
                Response.ContentType = "application/pdf"
                Response.WriteFile(item.Rows(0).Item("PathFile").ToString())
                Response.Flush()
                Response.End()
            End If

        End Sub
    End Class
End Namespace
