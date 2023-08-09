Imports System.IO
Imports Aspose.Pdf
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.WebUI.Common

Namespace eMicLibAdmin.Serial.Acquisition
    Partial Class WItemDissertation
        Inherits System.Web.UI.Page
        Private objItemDissertation As New clsBItemDissertation
        Private objBCDBS As New clsBCommonDBSystem
        Public Sub Initialize()
            objItemDissertation.DBServer = Session("DBServer")
            objItemDissertation.ConnectionString = Session("ConnectionString")
            objItemDissertation.InterfaceLanguage = Session("InterfaceLanguage")
            Call objItemDissertation.Initialize()

            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCDBS.Initialize()
        End Sub
        Private Sub BindData()
            Try

                Dim strTitle As String = txtTitle.Text
                Dim intYear As Integer = CInt(If(txtYear.Text = "", "0", txtYear.Text))
                Dim strNumber As String = txtNumber.Text

                Dim tblResult As DataTable = objItemDissertation.GetListItemDissertation(strTitle, strNumber, intYear)
                If (Not tblResult Is Nothing) AndAlso (tblResult.Rows.Count > 0) Then
                    tblResult = objBCDBS.ConvertTable(tblResult, "Content")
                    Dim newColumn As New Data.DataColumn("STT", GetType(System.String))
                    newColumn.DefaultValue = "1"
                    tblResult.Columns.Add(newColumn)

                    Dim indexRows As Integer = 1
                    For Each rows As DataRow In tblResult.Rows
                        If (Not (rows.RowState = DataRowState.Deleted)) AndAlso (Not (String.IsNullOrEmpty(rows.Item("STT")))) Then
                            rows.Item("STT") = indexRows.ToString()
                            indexRows = indexRows + 1
                        End If

                    Next

                    dtgPolicy.PageIndex = CType(Session("pageIndex").ToString(), Integer)
                    dtgPolicy.DataSource = tblResult
                    dtgPolicy.DataBind()
                    dtgPolicy.Visible = True
                Else
                    dtgPolicy.PageIndex = 0
                    dtgPolicy.DataSource = Nothing
                    dtgPolicy.DataBind()
                    dtgPolicy.Visible = False
                End If
            Catch ex As Exception
                Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbInputValid.Text & "')</script>")
            End Try
        End Sub
        Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            Call Initialize()
            If Not Page.IsPostBack Then

                Session("pageIndex") = 0
                'Call BindData()
            End If
        End Sub
        Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
            Session("pageIndex") = 0
            BindData()
        End Sub

        Protected Sub dtgPolicy_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles dtgPolicy.PageIndexChanging
            Session("pageIndex") = e.NewPageIndex
            BindData()
        End Sub

        Protected Sub btnUpdateCountPage_Click(sender As Object, e As EventArgs) Handles btnUpdateCountPage.Click
            Dim tblResult As DataTable
            tblResult = objItemDissertation.GetListItemDissertation()

            Dim licenseFile As String = Path.Combine(Server.MapPath("~") & "\bin\", "Aspose.Pdf.lic")

            Dim indexRows As Integer = 1
            If (File.Exists(licenseFile)) Then
                Dim pdfDocument As Document
                For Each rows As DataRow In tblResult.Rows
                    If (rows.Item("CountPages").ToString() = "0") Or IsDBNull(rows.Item("CountPages")) Then
                        'Dim countPage As Integer = clsWCommon.GetCountPageFile(rows.Item("PathFile").ToString, ".pdf")
                        'rows.Item("CountPages") = countPage
                        'objBItem.UpdateCountPage(CInt(rows.Item("ID")), countPage)

                        If (File.Exists(rows.Item("PathFile").ToString())) Then
                            pdfDocument = New Document(rows.Item("PathFile").ToString())
                            objItemDissertation.CountPages = pdfDocument.Pages.Count
                        Else
                            objItemDissertation.CountPages = 0
                        End If


                        'If (Not pdfDocument Is Nothing) Then
                        '    objItemDissertation.CountPages = pdfDocument.Pages.Count
                        'Else
                        '    objItemDissertation.CountPages = 0
                        'End If
                        objItemDissertation.ItemDissertationID = CType(rows.Item("ID"), Int16)
                        objItemDissertation.UpdateItemDissertation_CountPage()
                    End If
                Next
            End If
            Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbUpdateSusscess.Text & "');</script>")
        End Sub
    End Class
End Namespace
