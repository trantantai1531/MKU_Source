Imports System.IO
Imports Aspose.Pdf
Imports eMicLibAdmin.WebUI
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.BusinessRules.Common


Namespace eMicLibAdmin.Serial.Acquisition
    Partial Class WItemDissertationAdd
        Inherits clsWBase
        Private objItemDissertation As New clsBItemDissertation
        Public Sub Initialize()
            objItemDissertation.DBServer = Session("DBServer")
            objItemDissertation.ConnectionString = Session("ConnectionString")
            objItemDissertation.InterfaceLanguage = Session("InterfaceLanguage")
            Call objItemDissertation.Initialize()
        End Sub
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                If Not IsNothing(Request("ItemID")) Then
                    hidItemId.Value = Request("ItemID").ToString()
                End If
            End If
        End Sub

        ' Method: BindJS
        ' Purpose: write need js functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            btnClose.Attributes.Add("OnClick", "self.close(); return false;")
        End Sub

        Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click


            If ((String.IsNullOrEmpty(txtNumber.Text)) Or (String.IsNullOrEmpty(txtYear.Text)) Or (IsDBNull(txtPathImage.PostedFile)) Or (IsDBNull(txtPathFile.PostedFile))) Then
                If (String.IsNullOrEmpty(txtNumber.Text)) Then
                    Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbNumberRequired.Text & "')</script>")
                End If
                If (String.IsNullOrEmpty(txtYear.Text)) Then
                    Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbYearRequired.Text & "')</script>")
                End If
                If (IsDBNull(txtPathImage.PostedFile)) Then
                    Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbPathImageRequired.Text & "')</script>")
                End If
                If (IsDBNull(txtPathFile.PostedFile)) Then
                    Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbPathFileRequired.Text & "')</script>")
                End If
            Else

                Dim validImageTypes As String() = {"bmp", "gif", "png", "jpg", "jpeg"}
                Dim extImage As String = System.IO.Path.GetExtension(txtPathImage.PostedFile.FileName)
                Dim isValidImage As Boolean = False
                For i As Integer = 0 To validImageTypes.Length - 1
                    If extImage = "." & validImageTypes(i) Then
                        isValidImage = True
                        Exit For
                    End If
                Next

                Dim validFileTypes As String() = {"pdf"}
                Dim extFile As String = System.IO.Path.GetExtension(txtPathFile.PostedFile.FileName)
                Dim isValidFile As Boolean = False
                For i As Integer = 0 To validFileTypes.Length - 1
                    If extFile = "." & validFileTypes(i) Then
                        isValidFile = True
                        Exit For
                    End If
                Next

                If isValidImage And isValidFile Then
                    Try
                        objItemDissertation.Number = txtNumber.Text
                        objItemDissertation.Year = CInt(txtYear.Text)
                        objItemDissertation.ItemID = CInt(hidItemId.Value)

                        Dim tblResult As DataTable = objItemDissertation.GetItemDissertationByNumberAndYear()
                        If (Not tblResult Is Nothing) AndAlso (tblResult.Rows.Count > 0) Then
                            Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbValidExist.Text & "');</script>")
                        Else
                        '' Edit file name, not exit special symbol
                            Dim number As String = txtNumber.Text.Replace(" ","")
                            Dim posStar As Integer = 0
                            Dim posEnd As Integer = 0
                            For j As Integer = 0 To number.Length -1
                                If Char.IsNumber( number.Substring(j,1) ) Then
                                    posStar = j
                                    Exit For
                                End If
                            Next
                            For i As Integer = posStar  To number.Length -1 
                                If Not Char.IsNumber( number.Substring(i,1) ) Then
                                    posEnd = i
                                    Exit For
                                End If
                            Next
                            number = number.Substring(posStar, posEnd - posStar )
                            ''
                            Dim strPathRoot As String = lbPathSave.Text
                            Dim strFolderImages As String = lbFolderImages.Text
                            Dim strFolderFiles As String = lbFolderFiles.Text
                            Dim strFileName As String = String.Format("{0}_{1}_{2}{3}", hidItemId.Value, txtYear.Text, number, extFile)
                            Dim strImageName As String = String.Format("{0}_{1}_{2}{3}", hidItemId.Value, txtYear.Text, number, extImage)

                            Dim strPathFolderImages As String = strPathRoot & "\" & strFolderImages & "\" & hidItemId.Value & "\" & txtYear.Text
                            Dim strPathFolderFiles As String = strPathRoot & "\" & strFolderFiles & "\" & hidItemId.Value & "\" & txtYear.Text

                            If (Not System.IO.Directory.Exists(strPathFolderImages)) Then
                                System.IO.Directory.CreateDirectory(strPathFolderImages)
                            End If

                            If (Not System.IO.Directory.Exists(strPathFolderFiles)) Then
                                System.IO.Directory.CreateDirectory(strPathFolderFiles)
                            End If

                            Dim strResultImageName As String = UpLoadFiles(txtPathImage, strPathFolderImages, strImageName)
                            Dim strResultFileName As String = UpLoadFiles(txtPathFile, strPathFolderFiles, strFileName)

                            objItemDissertation.PathImage = strPathFolderImages & "\" & strResultImageName
                            objItemDissertation.PathFile = strPathFolderFiles & "\" & strResultFileName

                            ''  count pages Number  of File
                            Dim licenseFile As String = Path.Combine(Server.MapPath("~") & "\bin\", "Aspose.Pdf.lic")
                            If (File.Exists(licenseFile)) Then
                                Dim pdfDocument As Document
                                pdfDocument = New Document(objItemDissertation.PathFile)
                                If (Not pdfDocument Is Nothing) Then
                                    objItemDissertation.CountPages = pdfDocument.Pages.Count
                                Else
                                    objItemDissertation.CountPages = 0
                                End If
                            End If
                            

                            Dim intResult As Integer = objItemDissertation.CreateItemDissertation()

                            If intResult = 1 Then
                                Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbCreateSusscess.Text & "');</script>")
                                Page.RegisterClientScriptBlock("UpdateGridViewJs", "<script language='javascript'>window.opener.location.reload();</script>")
                            Else
                                Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbCreateError.Text & "');</script>")
                            End If
                        End If
                    Catch ex As Exception
                        Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbCreateError.Text & "');</script>")
                    End Try
                Else

                    If Not isValidImage Then
                        Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbImageNotValid.Text & "');</script>")
                    End If

                    If Not isValidFile Then
                        Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbFileNotValid.Text & "');</script>")
                    End If
                End If

            End If

            

        End Sub
    End Class
End Namespace
