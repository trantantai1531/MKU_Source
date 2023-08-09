' purpose : list of items were saved
' Create Date 4/11/2004
' Creator : lent
Imports eMicLibOPAC.BusinessRules.OPAC
Imports eMicLibOPAC.BusinessRules.Common
Imports System.IO
Namespace eMicLibOPAC.WebUI.OPAC
    Partial Class WSavedListAction
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region
        Private objBItemCollection As New clsBItemCollection
        Private objBCommonDBSystem As New clsBCommonDBSystem
        Private tblContent As New DataTable

        ' Event : Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJavascript()
            Call BindData()
        End Sub
        ' Initialize method
        ' Purpose: Init all necessary objects
        Private Sub Initialize()
            'Initialize objBItemCollection
            objBItemCollection.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBItemCollection.DBServer = Session("DBServer")
            objBItemCollection.ConnectionString = Session("ConnectionString")
            objBItemCollection.Initialize()
            'Initialize objBCommonDBSystem
            objBCommonDBSystem.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBCommonDBSystem.DBServer = Session("DBServer")
            objBCommonDBSystem.ConnectionString = Session("ConnectionString")
            objBCommonDBSystem.Initialize()
        End Sub

        ' Method : BindJavascript
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("MainJs", "<script language='javascript' src='../JS/Item/OpacItem.js'></script>")
            If Request("arrlistsaved") <> "" Then
                arrlistsaved.Value = Request("arrlistsaved")
            End If
            lnkRoot2.NavigateUrl = "javascript:ComeBack();"
            lnkRoot3.NavigateUrl = "javascript:GoSubmit('WSavedFormat.aspx');"
        End Sub

        ' Method : BindData
        Private Sub BindData()
            Dim strDisplay As String = ""
            Dim intDisplay As Integer = 0
            Select Case LCase(Request("optDisplay"))
                Case "optisbd"
                    strDisplay = "ISBD"
                Case "optmarc"
                    strDisplay = "MARC"
                    intDisplay = 1
                Case "optxml"
                    strDisplay = "XML (MARC 21)"
                    intDisplay = 2
                Case "optdcxml"
                    strDisplay = "XML (DCMI)"
                    intDisplay = 3
                Case "optiso"
                    Select Case UCase(Request("optISODisplay"))
                        Case "OPTISOUNIMARC"
                            strDisplay = "ISO - UNIMARC"
                            intDisplay = 4
                        Case "OPTISOUSMARC"
                            strDisplay = "ISO - USMARC"
                            intDisplay = 5
                        Case "OPTISOTVQG"
                            strDisplay = "ISO - CDS/ISIS (TVQG)"
                            intDisplay = 6
                        Case "OPTISONACESTID"
                            strDisplay = "ISO - CDS/ISIS (NACESTID)"
                            intDisplay = 7
                    End Select
            End Select
            ' Get content
            Call GetContents(intDisplay)
            Select Case LCase(Request("optDestination"))
                Case "optdesemail"
                    lblTitle.Text = ddlLabel.Items(5).Text
                    hidAction.Value = 0
                    Call SendEmailToUser(intDisplay)
                Case "optdesfile"
                    hidAction.Value = 1
                    lblTitle.Text = ddlLabel.Items(0).Text
                    Call SavedFileDownLoad(intDisplay)
                Case "optdesscreen"
                    hidAction.Value = 2
                    lblTitle.Text = ddlLabel.Items(1).Text
            End Select
            Call WriteToScreen(strDisplay)
        End Sub

        ' Method : GetContents
        Private Sub GetContents(ByVal intDisplay As Integer)
            objBItemCollection.ItemIDs = arrlistsaved.Value
            Select Case intDisplay
                Case 0 'ISBD
                    tblContent = objBItemCollection.GetInfoISBD
                Case 1 'MARC
                    tblContent = objBItemCollection.GetInfoMARC
                Case 2 'XML (MARC21)
                    tblContent = objBItemCollection.GetInfoXMLMARC21
                Case 3 'XML (DCMI)
                    tblContent = objBItemCollection.GetInfoXMLDCMI
                Case 4 'ISO - UNIMARC
                    tblContent = objBItemCollection.GetInfoISOUNIMARC
                Case 5 'ISO - USMARC
                    tblContent = objBItemCollection.GetInfoISOUSMARC
                Case 6 'ISO - CDS/ISIS (TVQG)
                    tblContent = objBItemCollection.GetInfoISOTVQG
                Case 7 'ISO - CDS/ISIS (NACESTID)
                    tblContent = objBItemCollection.GetInfoISONACESTID
            End Select
        End Sub

        'Method : SendEmailToUser
        Private Sub SendEmailToUser(ByVal intDisplay As Integer)
            Dim strContent As String = ""
            Dim intRow As Integer

            ' get information document
            If Not tblContent Is Nothing AndAlso tblContent.Rows.Count > 0 Then
                For intRow = 0 To tblContent.Rows.Count - 1
                    strContent = strContent & tblContent.Rows(intRow).Item("Content") & Chr(13) & Chr(10)
                Next
            End If
            If strContent <> "" Then
                Select Case intDisplay
                    Case 0, 1
                        strContent = strContent.Replace("<b>", "")
                        strContent = strContent.Replace("</b>", "")
                        strContent = strContent.Replace("<br>", Chr(13) & Chr(10))
                    Case 2, 3
                        strContent = strContent.Replace("&nbsp;", " ")
                        strContent = strContent.Replace("&lt;", "<")
                        strContent = strContent.Replace("&gt;", ">")
                        strContent = strContent.Replace("<br>", Chr(13) & Chr(10))
                End Select
            End If
            Dim intSendMail As Integer = 0
            intSendMail = SendMail(ddlLabel.Items(2).Text, strContent, Trim(Request("txtEmail")), False, "")
            If intSendMail = 0 Then
                Page.RegisterClientScriptBlock("SendErrJS", "<script language='javascript'>alert('" & ddlLabel.Items(3).Text & "');</script>")
            Else
                Page.RegisterClientScriptBlock("SendSuccJS", "<script language='javascript'>alert('" & ddlLabel.Items(4).Text & "');</script>")
            End If
        End Sub
        ' Method : SavedFileDownLoad
        Private Sub SavedFileDownLoad(ByVal intDisplay As Integer)
            Dim strContent As String = ""
            Dim strContentF As String = ""
            Dim intRow As Integer

            ' get information document
            If Not tblContent Is Nothing AndAlso tblContent.Rows.Count > 0 Then
                For intRow = 0 To tblContent.Rows.Count - 1
                    strContent = strContent & tblContent.Rows(intRow).Item("Content") & Chr(13) & Chr(10)
                    strContentF = strContentF & tblContent.Rows(intRow).Item("Content")
                Next
            End If
            If strContent <> "" Then
                Select Case intDisplay
                    Case 0, 1
                        strContent = strContent.Replace("<b>", "")
                        strContent = strContent.Replace("</b>", "")
                        strContent = strContent.Replace("<br>", Chr(13) & Chr(10))
                    Case 2, 3
                        strContent = strContent.Replace("&nbsp;", " ")
                        strContent = strContent.Replace("&lt;", "<")
                        strContent = strContent.Replace("&gt;", ">")
                        strContent = strContent.Replace("<br>", Chr(13) & Chr(10))
                End Select
            End If
            Dim strNameFile As String = SaveToFile(strContentF, "iso", Server.MapPath(".."))
            lnkGetIt.Attributes.Add("OnClick", "parent.Hiddenbase.location.href='../Common/WSaveTempFile.aspx?ModuleID=7&FileName=" & strNameFile & "';return false;")
            lnkGetIt.NavigateUrl = "#"
            Page.RegisterClientScriptBlock("DownLoadExportJs", "<script language='javascript'>parent.Hiddenbase.location.href='../Common/WSaveTempFile.aspx?ModuleID=7&FileName=" & strNameFile & "';</script>")
        End Sub
        ' purpose :  write format data to screen
        ' Creator: dgsoft2016
        Private Sub WriteToScreen(ByVal strdis As String)
            dtgSavedList.Columns(0).HeaderText = dtgSavedList.Columns(0).HeaderText + " " + strdis
            dtgSavedList.DataSource = tblContent
            dtgSavedList.DataBind()
        End Sub
        ' Purpose: Save to file
        ' Input: strContent, strExtendsion, isHTML
        ' Output: Physical path to file
        ' Creator: dgsoft2016
        Public Function SaveToFile(ByVal strContent As String, ByVal strExtendsion As String, Optional ByVal strServerPath As String = "") As String
            Dim intTTL As Integer = 24
            Dim arrValue(0), arrName(0) As String
            Dim tblTempFile As DataTable
            Dim strFileLocation, strFileName, strCondition As String
            Dim objFile As File
            Dim objSw As StreamWriter
            Dim inti As Integer
            Dim strPathfile As String = "\TempFiles\"
            arrName(0) = "TEMPFILE_TTL"
            Try
                tblTempFile = objBCommonDBSystem.GetTempFilePath(7)
                If Not tblTempFile Is Nothing AndAlso tblTempFile.Rows.Count > 0 Then
                    strPathfile = tblTempFile.Rows(0).Item("TempFilePath")
                    If Right(strPathfile, 1) <> "\" AndAlso Right(strPathfile, 1) <> "/" Then
                        strPathfile = strPathfile & "\"
                    End If
                End If

                arrValue = objBCommonDBSystem.GetSystemParameters(arrName)
                If IsArray(arrValue) Then
                    ' get path tempfile
                    If Not IsDBNull(arrValue(0)) And IsNumeric(arrValue(0)) Then
                        intTTL = arrValue(0)
                    End If
                    ' delete file 
                    If Not Session("DBServer") = "ORACLE" Then
                        strCondition = " WHERE DATEDIFF(HOUR, CreatedDate, GetDate()) > " & CStr(intTTL)
                    Else
                        strCondition = " WHERE (SYSDATAE - CreatedDate)*24 > " & CStr(intTTL)
                    End If
                    tblTempFile = objBCommonDBSystem.GetSysDownloadFile(strCondition)
                    If Not tblTempFile Is Nothing AndAlso tblTempFile.Rows.Count > 0 Then
                        For inti = 0 To tblTempFile.Rows.Count - 1
                            strFileName = tblTempFile.Rows(inti).Item("FileName")
                            strFileLocation = strServerPath & strPathfile & strFileName
                            If objFile.Exists(strFileLocation) Then
                                objFile.Delete(strFileLocation)
                            End If
                        Next
                        objBCommonDBSystem.DeleteSysDownloadFile(strCondition)
                    End If
                    ' Ensure don't have atless 2 file has same name in database
                    strFileName = objBCommonDBSystem.GenRandomFile(strExtendsion)
                    ' Write file
                    objSw = File.CreateText(strServerPath & strPathfile & strFileName)
                    objSw.WriteLine(strContent)
                    objSw.Close()
                End If
                SaveToFile = strFileName
            Catch ex As Exception
            Finally
            End Try
        End Function

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBItemCollection Is Nothing Then
                    objBItemCollection.Dispose(True)
                    objBItemCollection = Nothing
                End If
                If Not tblContent Is Nothing Then
                    tblContent = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

    End Class
End Namespace