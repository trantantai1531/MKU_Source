Imports System.IO
Imports Aspose.Pdf
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.WebUI

Namespace eMicLibAdmin.Serial.Acquisition
    Partial Class WItemDissertationDetail
        Inherits clsWBase

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
        Private Sub BindJS(ByVal intItemId As String)
            'Page.RegisterClientScriptBlock("JSCommon", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            'Page.RegisterClientScriptBlock("JSSelf", "<script language = 'javascript' src = '../js/Policy/WPolicyManagement.js'></script>")

            btnAdd.Attributes.Add("onClick", "OpenWindow(" & intItemId & ")")
        End Sub
        Private Sub BindData()
            Try

                Dim intYear As Integer = CInt(If(txtYear.Text = "", "0", txtYear.Text))
                Dim strNumber As String = txtNumber.Text

                objItemDissertation.ItemID = CInt(If(hidItemId.Value = "", "0", hidItemId.Value))
                objItemDissertation.Number = strNumber
                objItemDissertation.Year = intYear
                Dim tblResult As DataTable = objItemDissertation.GetItemDissertationByNumberAndYear()
                If (Not tblResult Is Nothing) AndAlso (tblResult.Rows.Count > 0) Then
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
                If Not IsNothing(Request("ItemID")) Then
                    hidItemId.Value = Request("ItemID").ToString()
                End If
                If Not IsNothing(Request.QueryString("DeleteId")) Then
                    Dim intId As Integer = CInt(Request.QueryString("DeleteId"))
                    Try
                        objItemDissertation.ItemDissertationID = CInt(Request.QueryString("DeleteId"))
                        objItemDissertation.DeleteItemDissertation()

                        Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbDeleteSuccess.Text & "')</script>")
                    Catch ex As Exception
                        Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbDeleteError.Text & "')</script>")
                    End Try
                End If
                Call BindJS(hidItemId.Value)
                Session("pageIndex") = 0
                Call BindData()
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

        Protected Sub dtgPolicy_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles dtgPolicy.RowEditing
            dtgPolicy.EditIndex = e.NewEditIndex
            BindData()

            Dim hidID As Integer = CInt(dtgPolicy.DataKeys(e.NewEditIndex).Value.ToString())
            objItemDissertation.ItemDissertationID = CInt(hidID)
            Dim dtResult As DataTable = objItemDissertation.GetItemDissertationById()
            Dim txtNumberGridView As TextBox = CType(dtgPolicy.Rows(e.NewEditIndex).FindControl("txtNumber"), TextBox)
            Dim txtYearGridView As TextBox = CType(dtgPolicy.Rows(e.NewEditIndex).FindControl("txtYear"), TextBox)

            txtNumberGridView.Text = dtResult.Rows(0).Item("Number")
            txtYearGridView.Text = dtResult.Rows(0).Item("Year")
        End Sub
        Protected Sub dtgPolicy_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles dtgPolicy.RowUpdating
            Dim hidID As Integer = CInt(dtgPolicy.DataKeys(e.RowIndex).Value.ToString())

            Dim txtNumberGridView As TextBox = CType(dtgPolicy.Rows(e.RowIndex).FindControl("txtNumber"), TextBox)
            Dim txtYearGridView As TextBox = CType(dtgPolicy.Rows(e.RowIndex).FindControl("txtYear"), TextBox)
            Dim txtPathImageGridView As HtmlInputFile = CType(dtgPolicy.Rows(e.RowIndex).FindControl("txtPathImage"), HtmlInputFile)
            Dim txtPathFileGridView As HtmlInputFile = CType(dtgPolicy.Rows(e.RowIndex).FindControl("txtPathFile"), HtmlInputFile)

            Try
                If ((String.IsNullOrEmpty(txtNumberGridView.Text)) Or (String.IsNullOrEmpty(txtYearGridView.Text))) Then
                    If (String.IsNullOrEmpty(txtNumberGridView.Text)) Then
                        Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbNumberRequired.Text & "')</script>")
                    End If
                    If (String.IsNullOrEmpty(txtYearGridView.Text)) Then
                        Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbYearRequired.Text & "')</script>")
                    End If
                Else
                    objItemDissertation.ItemDissertationID = hidID
                    objItemDissertation.ItemID = CInt(hidItemId.Value)
                    objItemDissertation.Number = txtNumberGridView.Text
                    objItemDissertation.Year = CInt(txtYearGridView.Text)

                    Dim tblCheck As DataTable = objItemDissertation.CheckItemDissertationByNumberAndYear()
                    If (Not tblCheck Is Nothing) AndAlso (tblCheck.Rows.Count > 0) Then
                        Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbValidExist.Text & "')</script>")
                    Else
                        objItemDissertation.ItemDissertationID = hidID
                        Dim tblResult As DataTable = objItemDissertation.GetItemDissertationById()

                        Dim strResultImageName As String = tblResult.Rows(0).Item("PathImage").ToString()
                        Dim strResultFileName As String = tblResult.Rows(0).Item("PathFile").ToString()
                        objItemDissertation.PathImage = strResultImageName
                        objItemDissertation.PathFile = strResultFileName

                        Dim strPathRoot As String = lbPathSave.Text
                        Dim strFolderImages As String = lbFolderImages.Text
                        Dim strFolderFiles As String = lbFolderFiles.Text

                        Dim isValidImage As Boolean = False
                        Dim isValidFile As Boolean = False

                        Dim extImage As String = "jpg"
                        Dim extFile As String = "pdf"

                        If (Not IsDBNull(txtPathImageGridView.PostedFile)) And (txtPathImageGridView.PostedFile.FileName.Length > 0) Then
                            Dim validImageTypes As String() = {"bmp", "gif", "png", "jpg", "jpeg"}
                            extImage = System.IO.Path.GetExtension(txtPathImageGridView.PostedFile.FileName)
                            For i As Integer = 0 To validImageTypes.Length - 1
                                If extImage = "." & validImageTypes(i) Then
                                    isValidImage = True
                                    Exit For
                                End If
                            Next
                        Else
                            isValidImage = True
                        End If

                        If (Not IsDBNull(txtPathFileGridView.PostedFile)) And (txtPathFileGridView.PostedFile.FileName.Length > 0) Then
                            Dim validFileTypes As String() = {"pdf"}
                            extFile = System.IO.Path.GetExtension(txtPathFileGridView.PostedFile.FileName)
                            For i As Integer = 0 To validFileTypes.Length - 1
                                If extFile = "." & validFileTypes(i) Then
                                    isValidFile = True
                                    Exit For
                                End If
                            Next
                        Else
                            isValidFile = True
                        End If

                        If isValidImage And isValidFile Then

                            Dim pdfDocument As Aspose.Pdf.Document                        
                            ''
                            If (Not IsDBNull(txtPathImageGridView.PostedFile)) And (txtPathImageGridView.PostedFile.FileName.Length > 0) Then

                                Dim strImageName As String = String.Format("{0}_{1}_{2}{3}", hidItemId.Value, txtYearGridView.Text, txtNumberGridView.Text, extImage)
                                Dim strPathFolderImages As String = strPathRoot & "\" & strFolderImages & "\" & hidItemId.Value & "\" & txtYearGridView.Text
                                If (Not System.IO.Directory.Exists(strPathFolderImages)) Then
                                    System.IO.Directory.CreateDirectory(strPathFolderImages)
                                End If
                                If (System.IO.File.Exists(strResultImageName)) Then
                                    System.IO.File.Delete(strResultImageName)
                                End If

                                strResultImageName = UpLoadFiles(txtPathImageGridView, strPathFolderImages, strImageName)
                                objItemDissertation.PathImage = strPathFolderImages & "\" & strResultImageName
                            End If

                            If (Not IsDBNull(txtPathFileGridView.PostedFile)) And (txtPathFileGridView.PostedFile.FileName.Length > 0) Then
                                Dim strFileName As String = String.Format("{0}_{1}_{2}{3}", hidItemId.Value, txtYearGridView.Text, txtNumberGridView.Text, extFile)
                                Dim strPathFolderFiles As String = strPathRoot & "\" & strFolderFiles & "\" & hidItemId.Value & "\" & txtYearGridView.Text
                                If (Not System.IO.Directory.Exists(strPathFolderFiles)) Then
                                    System.IO.Directory.CreateDirectory(strPathFolderFiles)
                                End If
                                If (System.IO.File.Exists(strResultFileName)) Then
                                    System.IO.File.Delete(strResultFileName)
                                End If

                                strResultFileName = UpLoadFiles(txtPathFileGridView, strPathFolderFiles, strFileName)

                                objItemDissertation.PathFile = strPathFolderFiles & "\" & strResultFileName
                                pdfDocument = New Document(objItemDissertation.PathFile)
                                ''  count pages Number  of File
                                Dim licenseFile As String = Path.Combine(Server.MapPath("~") & "\bin\", "Aspose.Pdf.lic")
                                If (File.Exists(licenseFile)) Then
                                    If (Not pdfDocument Is Nothing) Then
                                        objItemDissertation.CountPages = pdfDocument.Pages.Count
                                    Else
                                        objItemDissertation.CountPages = 0
                                    End If
                                End If
                            End If

                            Dim intResult As Integer = objItemDissertation.UpdateItemDissertation()

                            If intResult = 1 Then
                                Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbUpdateSuccess.Text & "');</script>")
                            Else
                                Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbUpdateError.Text & "');</script>")
                            End If
                            dtgPolicy.EditIndex = -1
                            BindData()
                        Else

                            If Not isValidImage Then
                                Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbImageNotValid.Text & "');</script>")
                            End If

                            If Not isValidFile Then
                                Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbFileNotValid.Text & "');</script>")
                            End If
                        End If

                        End If
                End If
            Catch ex As Exception
                Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbUpdateError.Text & "');</script>")
            End Try


        End Sub
        Protected Sub dtgPolicy_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles dtgPolicy.RowCancelingEdit
            dtgPolicy.EditIndex = -1
            BindData()
        End Sub
        Protected Sub dtgPolicyt_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles dtgPolicy.RowDataBound
            For i = 0 To dtgPolicy.Rows.Count - 1
                Dim hidID As Integer = CInt(dtgPolicy.DataKeys(i).Value.ToString())
                Dim linkDelete As HyperLink = CType(dtgPolicy.Rows(i).Cells(5).FindControl("linkDelete"), HyperLink)
                linkDelete.Attributes.Add("onclick", "DeleteItem('" & hidItemId.Value & "','" & hidID & "')")
                linkDelete.Attributes.Add("href", "javascript:void('" & hidID & "')")
            Next
        End Sub

        Protected Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
            Response.Redirect("WItemDissertation.aspx")
        End Sub
    End Class
End Namespace
