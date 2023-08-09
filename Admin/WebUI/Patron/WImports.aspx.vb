' Class: WImports
' Puspose: Import data
' Creator: Sondp
' CreatedDate: 21-1-2005
' Modification History:
'   - 13/05/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Patron
Imports System.IO

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WImports
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblPickTemplate As System.Web.UI.WebControls.Label
        Protected WithEvents lblPickTemplateAlert As System.Web.UI.WebControls.Label
        Protected WithEvents lblSeperatorAlert As System.Web.UI.WebControls.Label
        Protected WithEvents lblSourceFile As System.Web.UI.WebControls.Label
        Protected WithEvents lblImportSuccessful As System.Web.UI.WebControls.Label
        Protected WithEvents lblImportUnsuccessful As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBPT As New clsBPatronTemplate
        Private objBPC As New clsBPatronCollection

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            lblViewLog.Visible = False
            If Not Page.IsPostBack Then
                Call BindData()
                Call SetDefaultValue()
            End If
        End Sub
        ' CheckFormPermission method
        ' Purpose: check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(216) Then
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub
        ' Method: Initialize
        Private Sub Initialize()
            ' Initialize objBPT object
            objBPT.DBServer = Session("DBServer")
            objBPT.ConnectionString = Session("ConnectionString")
            objBPT.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPT.Initialize()

            ' Initialize objBPC object
            objBPC.DBServer = Session("DBServer")
            objBPC.ConnectionString = Session("ConnectionString")
            objBPC.InterfaceLanguage = Session("InterfaceLanguage")
            objBPC.initialize()
        End Sub

        ' BindJS method
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("WImportJs", "<script language = 'javascript' src = 'js/WImport.js'></script>")

            btnImport.Attributes.Add("OnClick", "return(CheckImport('" & ddlLabel.Items(4).Text & "','" & ddlLabel.Items(5).Text & "'));")
            btnReset.Attributes.Add("OnClick", "document.forms[0].reset();return(false);")
            btnSetDefaultvalue.Attributes.Add("OnClick", "SetDefaultValue();return(false);")
        End Sub

        ' Method: SetDefaultValue
        ' Purpose: Set Default value
        Private Sub SetDefaultValue()
            hdValidDate.Value = Session("ToDay")
            hdLastModifiedDate.Value = Session("ToDay")
            hdExpiredDate.Value = Session("ToDay")
            hdPatronGroupID.Value = 1
        End Sub

        ' BindData method
        Private Sub BindData()
            Dim tblTemplate As New DataTable
            Dim lsItem As New ListItem

            objBPT.TemplateID = 0
            objBPT.TemplateType = 30
            tblTemplate = objBPT.GetPatronTemplate

            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPC.ErrorMsg, ddlLabel.Items(1).Text, objBPC.ErrorCode)

            If Not tblTemplate Is Nothing AndAlso tblTemplate.Rows.Count > 0 Then
                ddlTemplate.DataSource = InsertOneRow(tblTemplate, ddlLabel.Items(3).Text)
                ddlTemplate.DataTextField = "Title"
                ddlTemplate.DataValueField = "ID"
                ddlTemplate.DataBind()
            Else
                lsItem.Value = "0"
                lsItem.Text = ddlLabel.Items(3).Text
                ddlTemplate.Items.Add(lsItem)
            End If
            lsItem = Nothing
            tblTemplate = Nothing
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
            Randomize()
            strFileName = "f" & Year(Now) & StrDup(2 - Len(CStr(Month(Now))), "0") & StrDup(2 - Len(CStr(Day(Now))), "0") & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1) + 65)) & "." & strExtension
        End Sub

        ' Method: UploadPatronFile
        Private Function UploadPatronFile() As String
            Dim strFileName As String = ""
            Dim strPath As String = ""
            Dim strLocation As String = ""
            Dim strUploaded As String = ""
            Dim objFileInfor As FileInfo
            Dim strUpload As String = ""
            Call ProcessFileName(filImport.Value, strFileName)
            strLocation = Server.MapPath("Attach")
            strPath = strLocation
            objFileInfor = New FileInfo(Replace(strLocation & "\", "\\", "\") & strFileName)
            If objFileInfor.Exists = False Then
                strUpload = UpLoadFiles(filImport, strPath, strFileName)
                If strUpload <> "Fail" Then
                    UploadPatronFile = strPath & "/" & strFileName
                End If
            End If

            If Len(UploadPatronFile) < 2 Then
                Page.RegisterClientScriptBlock("NoCopynumber", "<script language='javascript'> alert('" & ddlLabel.Items(10).Text & "');</script>")
                Exit Function
            End If
        End Function

        ' Event: btnImport_Click
        Private Sub btnImport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImport.Click
            Dim objPatron()
            Dim intCounter As Integer
            Dim strFilename, strMessageResultJs As String
            Dim intRetVal, inti As Integer

            objBPC.TemplateID = ddlTemplate.SelectedItem.Value()
            objBPC.TemplateType = 30
            objBPC.Seperator = txtSeperator.Text.Trim

            If Me.filImport.PostedFile.FileName.ToString = "" Then
                Exit Sub
            Else
                Try
                    If optXML.Checked Then
                        objBPC.FileTypeID = 1
                        If chkOverwrite.Checked Then
                            intRetVal = objBPC.ImportFromXMLFile(UploadPatronFile, hdValidDate.Value, hdExpiredDate.Value, hdLastModifiedDate.Value, hdPatronGroupID.Value, True)
                        Else
                            intRetVal = objBPC.ImportFromXMLFile(UploadPatronFile, hdValidDate.Value, hdExpiredDate.Value, hdLastModifiedDate.Value, hdPatronGroupID.Value)
                        End If
                    Else
                        objBPC.FileTypeID = 0
                        If chkOverwrite.Checked Then
                            intRetVal = objBPC.ImportFromTextFile(UploadPatronFile, hdValidDate.Value, hdExpiredDate.Value, hdLastModifiedDate.Value, hdPatronGroupID.Value, True)
                        Else
                            intRetVal = objBPC.ImportFromTextFile(UploadPatronFile, hdValidDate.Value, hdExpiredDate.Value, hdLastModifiedDate.Value, hdPatronGroupID.Value)
                        End If
                    End If
                    dgrResult.Visible = False
                    If Not objBPC.ExistPatron Is Nothing Then
                        If objBPC.ExistPatron.Rows.Count > 0 Then
                            For inti = 0 To objBPC.ExistPatron.Rows.Count - 1
                                objBPC.ExistPatron.Rows(inti).Item("STT") = inti + 1
                            Next
                            dgrResult.Visible = True
                            dgrResult.DataSource = objBPC.ExistPatron
                            dgrResult.DataBind()
                        End If
                    End If
                    ' Write error
                    If objBPC.ErrorMsg <> "" Then
                        Page.RegisterClientScriptBlock("ImportDataUnSuccessfulExJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(8).Text & "');</script>")
                        lblViewLog.Visible = True
                        Exit Sub
                    Else
                        Call WriteLog(119, ddlLabel.Items(9).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                        strMessageResultJs &= ddlLabel.Items(7).Text & CStr(intRetVal)
                        If Not objBPC.ExistPatron Is Nothing Then
                            If objBPC.ExistPatron.Rows.Count > 0 Then
                                strMessageResultJs &= ddlLabel.Items(11).Text & objBPC.ExistPatron.Rows.Count
                            End If
                        End If
                        Page.RegisterClientScriptBlock("MessageResultJs", "<script language = 'javascript'>alert('" & strMessageResultJs & "');</script>")
                    End If
                    'Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPC.ErrorMsg, ddlLabel.Items(1).Text, objBPC.ErrorCode)
                    'If intRetVal > 0 Then
                    '    ' WriteLog
                    '    Call WriteLog(119, ddlLabel.Items(9).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                    '    Page.RegisterClientScriptBlock("ImportDataSuccessfulJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(7).Text & CStr(intRetVal) & "');</script>")
                    'Else
                    '    Page.RegisterClientScriptBlock("ImportDataUnSuccessfulJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(8).Text & "');</script>")
                    '    lblViewLog.Visible = True
                    '    lblViewLog.Text = Left(objBPC.ErrorMsg, Len(objBPC.ErrorMsg - 1))
                    'End If
                Catch ex As Exception
                    Page.RegisterClientScriptBlock("ImportDataUnSuccessfulExJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(8).Text & "');</script>")
                    lblViewLog.Visible = True
                    lblViewLog.Text = ex.Message
                End Try
            End If
        End Sub

        ' Page_Unload method
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBPT Is Nothing Then
                objBPT.Dispose(True)
                objBPT = Nothing
            End If
            If Not objBPC Is Nothing Then
                objBPC.Dispose(True)
                objBPC = Nothing
            End If
        End Sub
    End Class
End Namespace