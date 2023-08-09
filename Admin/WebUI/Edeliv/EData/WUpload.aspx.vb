Imports eMicLibAdmin.WebUI.Edeliv
Imports eMicLibAdmin.BusinessRules.Edeliv
Imports System.IO

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WUpload
        Inherits clsWEData

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents chkKipName As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        'Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPemission()
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                txtFolderWrite.Text = Request("Location")
            End If
        End Sub

        ' CheckFormPemission method
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            If Not CheckPemission(166) Then
                Call WriteErrorMssg(ddlLabel.Items(1).Text)
            End If
        End Sub

        'BindScript method
        'Purpose: Include all neccessary javascript functions
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript'src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            btnClose.Attributes.Add("OnClick", "javascript:self.close();")
        End Sub

        'Upload method
        'Pupose: Upload some file from client to server
        'Note: Max file upload is five
        Private Sub Upload()
            Dim inti As Integer = 0
            Dim strLocation As String = ""
            Dim strFileName As String = ""
            Dim strUpload As String = ""
            Dim strLocationPath As String = ""
            Dim strPath As String = ""
            Dim strFileNameTemp As String = ""
            Dim objFileInfor As FileInfo
            'Dim objFileCheckExist As FileInfo
            Dim strUploaded As String = ""
            Dim strJs As String

            ' Get the location of files
            If txtFolderWrite.Text <> "" And InStr(txtFolderWrite.Text, "\") > 0 Then
                strLocation = txtFolderWrite.Text
            End If

            lblUploaded.Text = ""

            ' Upload 1st file
            If filAttachment1.Value <> "" Then
                'objFileCheckExist = New FileInfo(filAttachment1.Value)
                'If Not objFileCheckExist.Exists Then
                '    strJs = "alert('" & ddlLabel.Items(4).Text & "');"
                '    Page.RegisterClientScriptBlock("File1Js", "<script language='javascript'>" & strJs & "</script>")
                'Else
                Call ProcessFileName(filAttachment1.Value, strFileName)
                strPath = strLocation
                objFileInfor = New FileInfo(Replace(strLocation & "\", "\\", "\") & strFileName)
                If chkWriteForder.Checked = False Then
                    If objFileInfor.Exists = False Then
                        strUpload = UpLoadFiles(filAttachment1, strPath, strFileName)
                        If strUpload <> "Fail" Then
                            Call ImportEData(strLocation, strFileName)
                            Call WriteErrorMssg(ddlLabel.Items(3).Text, objBEData.ErrorMsg, ddlLabel.Items(2).Text, objBEData.ErrorCode)
                            strUploaded = strUploaded & strFileName & ","
                        End If
                    Else ' File alerdy exist 
                        strJs = "alert('" & ddlLabel.Items(9).Text & "');"
                        Page.RegisterClientScriptBlock("File1Js", "<script language='javascript'>" & strJs & "</script>")
                    End If
                Else
                    strUpload = UpLoadFiles(filAttachment1, strPath, strFileName)
                    If strUpload <> "Fail" Then
                        Call ImportEData(strLocation, strFileName)
                        Call WriteErrorMssg(ddlLabel.Items(3).Text, objBEData.ErrorMsg, ddlLabel.Items(2).Text, objBEData.ErrorCode)
                        strUploaded = strUploaded & strFileName & ","
                    End If
                End If
                'End If
            End If

            ' Upload 2nd file
            If filAttachment2.Value <> "" Then
                'objFileCheckExist = New FileInfo(filAttachment2.Value)
                'If Not objFileCheckExist.Exists Then
                '    strJs = "alert('" & ddlLabel.Items(5).Text & "');"
                '    Page.RegisterClientScriptBlock("File2Js", "<script language='javascript'>" & strJs & "</script>")
                'Else
                Call ProcessFileName(filAttachment2.Value, strFileName)
                strPath = strLocation
                objFileInfor = New FileInfo(Replace(strLocation & "\", "\\", "\") & strFileName)
                If chkWriteForder.Checked = False Then
                    If objFileInfor.Exists = False Then
                        strUpload = UpLoadFiles(filAttachment2, strPath, strFileName)
                        If strUpload <> "Fail" Then
                            Call ImportEData(strLocation, strFileName)
                            Call WriteErrorMssg(ddlLabel.Items(3).Text, objBEData.ErrorMsg, ddlLabel.Items(2).Text, objBEData.ErrorCode)
                            strUploaded = strUploaded & strFileName & ","
                        End If
                    Else ' File alerdy exist 
                        strJs = "alert('" & ddlLabel.Items(9).Text & "');"
                        Page.RegisterClientScriptBlock("File12s", "<script language='javascript'>" & strJs & "</script>")
                    End If
                Else
                    strUpload = UpLoadFiles(filAttachment2, strPath, strFileName)
                    If strUpload <> "Fail" Then
                        Call ImportEData(strLocation, strFileName)
                        Call WriteErrorMssg(ddlLabel.Items(3).Text, objBEData.ErrorMsg, ddlLabel.Items(2).Text, objBEData.ErrorCode)
                        strUploaded = strUploaded & strFileName & ","
                    End If
                End If
                'End If
            End If

            ' Upload 3rd file
            If filAttachment3.Value <> "" Then
                'objFileCheckExist = New FileInfo(filAttachment3.Value)
                'If Not objFileCheckExist.Exists Then
                '    strJs = "alert('" & ddlLabel.Items(6).Text & "');"
                '    Page.RegisterClientScriptBlock("File3Js", "<script language='javascript'>" & strJs & "</script>")
                'Else
                Call ProcessFileName(filAttachment3.Value, strFileName)
                strPath = strLocation
                objFileInfor = New FileInfo(Replace(strLocation & "\", "\\", "\") & strFileName)
                If chkWriteForder.Checked = False Then
                    If objFileInfor.Exists = False Then
                        strUpload = UpLoadFiles(filAttachment3, strPath, strFileName)
                        If strUpload <> "Fail" Then
                            Call ImportEData(strLocation, strFileName)
                            Call WriteErrorMssg(ddlLabel.Items(3).Text, objBEData.ErrorMsg, ddlLabel.Items(2).Text, objBEData.ErrorCode)
                            strUploaded = strUploaded & strFileName & ","
                        End If
                    Else ' File alerdy exist 
                        strJs = "alert('" & ddlLabel.Items(9).Text & "');"
                        Page.RegisterClientScriptBlock("File3Js", "<script language='javascript'>" & strJs & "</script>")
                    End If
                Else
                    strUpload = UpLoadFiles(filAttachment3, strPath, strFileName)
                    If strUpload <> "Fail" Then
                        Call ImportEData(strLocation, strFileName)
                        Call WriteErrorMssg(ddlLabel.Items(3).Text, objBEData.ErrorMsg, ddlLabel.Items(2).Text, objBEData.ErrorCode)
                        strUploaded = strUploaded & strFileName & ","
                    End If
                End If
                'End If
            End If

            ' Upload 4th file
            If filAttachment4.Value <> "" Then
                'objFileCheckExist = New FileInfo(filAttachment4.Value)
                'If Not objFileCheckExist.Exists Then
                '    strJs = "alert('" & ddlLabel.Items(7).Text & "');"
                '    Page.RegisterClientScriptBlock("File4Js", "<script language='javascript'>" & strJs & "</script>")
                'Else
                Call ProcessFileName(filAttachment4.Value, strFileName)
                strPath = strLocation
                objFileInfor = New FileInfo(Replace(strLocation & "\", "\\", "\") & strFileName)
                If chkWriteForder.Checked = False Then
                    If objFileInfor.Exists = False Then
                        strUpload = UpLoadFiles(filAttachment4, strPath, strFileName)
                        If strUpload <> "Fail" Then
                            Call ImportEData(strLocation, strFileName)
                            Call WriteErrorMssg(ddlLabel.Items(3).Text, objBEData.ErrorMsg, ddlLabel.Items(2).Text, objBEData.ErrorCode)
                            strUploaded = strUploaded & strFileName & ","
                        End If
                    Else ' File alerdy exist 
                        strJs = "alert('" & ddlLabel.Items(9).Text & "');"
                        Page.RegisterClientScriptBlock("File4Js", "<script language='javascript'>" & strJs & "</script>")
                    End If
                Else
                    strUpload = UpLoadFiles(filAttachment4, strPath, strFileName)
                    If strUpload <> "Fail" Then
                        Call ImportEData(strLocation, strFileName)
                        Call WriteErrorMssg(ddlLabel.Items(3).Text, objBEData.ErrorMsg, ddlLabel.Items(2).Text, objBEData.ErrorCode)
                        strUploaded = strUploaded & strFileName & ","
                    End If
                End If
                'End If
            End If

            ' Upload 5th file
            If filAttachment5.Value <> "" Then
                'objFileCheckExist = New FileInfo(filAttachment5.Value)
                'If Not objFileCheckExist.Exists Then
                '    strJs = "alert('" & ddlLabel.Items(8).Text & "');"
                '    Page.RegisterClientScriptBlock("File5Js", "<script language='javascript'>" & strJs & "</script>")
                'Else
                Call ProcessFileName(filAttachment5.Value, strFileName)
                strPath = strLocation
                objFileInfor = New FileInfo(Replace(strLocation & "\", "\\", "\") & strFileName)
                If chkWriteForder.Checked = False Then
                    If objFileInfor.Exists = False Then
                        strUpload = UpLoadFiles(filAttachment5, strPath, strFileName)
                        If strUpload <> "Fail" Then
                            Call ImportEData(strLocation, strFileName)
                            Call WriteErrorMssg(ddlLabel.Items(3).Text, objBEData.ErrorMsg, ddlLabel.Items(2).Text, objBEData.ErrorCode)
                            strUploaded = strUploaded & strFileName & ","
                        End If
                    Else ' File alerdy exist 
                        strJs = "alert('" & ddlLabel.Items(9).Text & "');"
                        Page.RegisterClientScriptBlock("File5Js", "<script language='javascript'>" & strJs & "</script>")
                    End If
                Else
                    strUpload = UpLoadFiles(filAttachment5, strPath, strFileName)
                    If objFileInfor.Exists = False Then
                        Call ImportEData(strLocation, strFileName)
                        Call WriteErrorMssg(ddlLabel.Items(3).Text, objBEData.ErrorMsg, ddlLabel.Items(2).Text, objBEData.ErrorCode)
                        strUploaded = strUploaded & strFileName & ","
                    End If
                End If
                'End If
            End If
            If Trim(strUploaded) <> "" Then
                lblUploaded.Text = ddlLabel.Items(0).Text & " " & Left(strUploaded, Len(strUploaded) - 1)
                Page.RegisterClientScriptBlock("Refresh", "<script language='javascript'>opener.location.href='WShowDetail.aspx?Loc=" & Replace(txtFolderWrite.Text, "\", "\\") & "';</script>")
            End If
        End Sub

        ' btnImport_Click event
        Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
            Call Upload()
        End Sub

        ' ProcessFileName method
        ' Purpose: Rename the file
        Private Sub ProcessFileName(ByVal strFileAttach As String, ByRef strFileName As String)
            Dim strExtension As String = ""

            While InStr(strFileAttach, " ") > 0
                strFileAttach = Replace(strFileAttach, " ", "")
            End While
            strFileAttach = Replace(strFileAttach, "'", "")
            strExtension = Right(strFileAttach, Len(strFileAttach) - InStrRev(strFileAttach, "."))

            If chkKeepName.Checked = False Then
                Randomize()
                strFileName = "f" & Year(Now) & StrDup(2 - Len(CStr(Month(Now))), "0") & StrDup(2 - Len(CStr(Day(Now))), "0") & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1) + 65)) & "." & strExtension
            Else
                strFileName = Right(strFileAttach, Len(strFileAttach) - InStrRev(strFileAttach, "\"))
            End If
        End Sub

        'Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub
    End Class
End Namespace