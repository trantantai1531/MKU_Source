
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Patron

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WRequestCataloguer
        Inherits clsWBase

        Private objBRequestCataloguer As New clsBRequestCataloguer
        Private objBCDBS As New clsBCommonDBSystem

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJavascript()
            If Not IsPostBack Then
                If Not IsNothing(Request.QueryString("DeleteId")) Then
                    Dim intId As Integer = CInt(Request.QueryString("DeleteId"))
                    Try
                        Dim intResultDelete As Integer = objBRequestCataloguer.Delete(intId)

                        If intResultDelete = 1 Then
                            Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & ddlLabel.Items(5).Text & "')</script>")
                        Else
                            Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & ddlLabel.Items(6).Text & "')</script>")
                        End If
                    Catch ex As Exception
                        Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & ddlLabel.Items(6).Text & "')</script>")
                    End Try

                    If Not IsNothing(Request.QueryString("strDateFrom")) Then
                        txtDateFrom.Text = Request.QueryString("strDateFrom").ToString()
                    End If

                    If Not IsNothing(Request.QueryString("strDateTo")) Then
                        txtDateTo.Text = Request.QueryString("strDateTo").ToString()
                    End If

                    If Not IsNothing(Request.QueryString("strFullName")) Then
                        txtName.Text = Request.QueryString("strFullName").ToString()
                    End If

                    If Not IsNothing(Request.QueryString("strPatronCode")) Then
                        txtPatronCode.Text = Request.QueryString("strPatronCode").ToString()
                    End If

                    If Not IsNothing(Request.QueryString("strTitle")) Then
                        txtTitle.Text = Request.QueryString("strTitle").ToString()
                    End If

                    Call BindData()
                Else

                End If
                ' Call BindData()
            End If
        End Sub

        ' Initialize method
        ' Purpose: Init all neccessary objects
        Private Sub Initialize()
            objBRequestCataloguer.DBServer = Session("DBServer")
            objBRequestCataloguer.ConnectionString = Session("ConnectionString")
            objBRequestCataloguer.InterfaceLanguage = Session("InterfaceLanguage")
            objBRequestCataloguer.Initialize()

            ' Initialize objBCC object
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            Call objBCDBS.Initialize()
        End Sub

        ' BindJavascript method
        Private Sub BindJavascript()
            Me.RegisterCalendar("../..")

            SetOnclickCalendar(lnkDateFrom, txtDateFrom, ddlLabel.Items(2).Text)
            SetOnclickCalendar(lnkDateTo, txtDateTo, ddlLabel.Items(2).Text)
        End Sub

        Private Sub BindData()
            objBRequestCataloguer.FullName = txtName.Text
            objBRequestCataloguer.PatronCode = txtPatronCode.Text
            objBRequestCataloguer.Title = txtTitle.Text

            Dim strDateFrom As String = ""
            Dim strDateTo As String = ""
            If Not txtDateFrom.Text = "" Then
                strDateFrom = txtDateFrom.Text
            End If
            If Not txtDateTo.Text = "" Then
                strDateTo = txtDateTo.Text
            End If

            If strDateFrom <> "" Then strDateFrom = objBCDBS.ConvertDateBack(strDateFrom + " 00:00:00")
            If strDateTo <> "" Then strDateTo = objBCDBS.ConvertDateBack(strDateTo + " 23:59:59")

            Dim tblData As DataTable = objBRequestCataloguer.GetRequestCataloguerFill(strDateFrom, strDateTo)

            If (Not IsNothing(tblData)) AndAlso tblData.Rows.Count > 0 Then
                tblData.Columns.Add("STT")
                tblData.Columns.Add("Content")

                Dim intSTT As Integer = 1
                For Each row As DataRow In tblData.Rows
                    Dim strContent As String = ""
                    If row.Item("Title") & "" <> "" Then
                        strContent = strContent & ddlLabel.Items(7).Text & row.Item("Title") & "<br/>"
                    End If
                    If row.Item("Author") & "" <> "" Then
                        strContent = strContent & ddlLabel.Items(8).Text & row.Item("Author") & "<br/>"
                    End If
                    If row.Item("Publisher") & "" <> "" Then
                        strContent = strContent & ddlLabel.Items(9).Text & row.Item("Publisher") & "<br/>"
                    End If
                    If row.Item("PublishYear") & "" <> "" Then
                        strContent = strContent & ddlLabel.Items(10).Text & row.Item("PublishYear") & "<br/>"
                    End If
                    If row.Item("Information") & "" <> "" Then
                        strContent = strContent & ddlLabel.Items(11).Text & " " & row.Item("Information") & "<br/>"
                    End If

                    row.Item("STT") = intSTT
                    row.Item("Content") = strContent

                    intSTT = intSTT + 1
                Next

                dtgResult.DataSource = tblData
                dtgResult.DataBind()
            Else
                dtgResult.DataSource = Nothing
                dtgResult.DataBind()
            End If

        End Sub

        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBRequestCataloguer Is Nothing Then
                    objBRequestCataloguer.Dispose(True)
                    objBRequestCataloguer = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
        Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
            BindData()
        End Sub

        Protected Sub dtgResult_DataBound(sender As Object, e As EventArgs) Handles dtgResult.DataBound
            For i = 0 To dtgResult.Rows.Count - 1
                Dim hidID As Integer = CInt(dtgResult.DataKeys(i).Value.ToString())
                Dim linkDelete As HyperLink = CType(dtgResult.Rows(i).Cells(6).FindControl("linkDelete"), HyperLink)
                linkDelete.Attributes.Add("onclick", "DeleteItem('" & hidID & "')")
                linkDelete.Attributes.Add("href", "javascript:void('" & hidID & "')")
                Dim linkDetail As HyperLink = CType(dtgResult.Rows(i).Cells(0).FindControl("linkDetail"), HyperLink)
                If Not (IsNothing(linkDetail)) Then
                    linkDetail.Attributes.Add("onclick", "OpenWindow('WRequestCataloguerDetail.aspx?intID=" & hidID.ToString() & "', 'WRequestCataloguerDetail',1024,768,100,100)")
                End If
            Next
        End Sub
    End Class
End Namespace

