' Class: WCataAttachFile 
' Purpose: allow user upload electronic data files
' Creator: Oanhtn
' CreatedDate: 22/06/2004
' Modification history:
'   - 04/03/2005 by Oanhtn: review & update

Imports System.IO
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WCataAttachFile
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

        ' Declare variables
        Private objWEData As New clsWEData
        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJavascript()
            If Not Page.IsPostBack Then
                Call Process()
            End If
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init objWEData object
            Call objWEData.Initialize()

            ' Init objBCSP object
            objBCSP.ConnectionString = Session("ConnectionString")
            objBCSP.DBServer = Session("DBServer")
            objBCSP.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCSP.Initialize()
            ' Init objBCDBS object
            objBCDBS.ConnectionString = Session("ConnectionString")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCDBS.Initialize()
        End Sub

        ' BindJavascript method
        ' Purpose: include all neccessary javascript function
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("WCommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WCataJs", "<script language = 'javascript' src = '../Js/Catalogue/WCata.js'></script>")
            Page.RegisterClientScriptBlock("WCataAttachFileJs", "<script language = 'javascript' src = '../Js/Catalogue/WCataAttachFile.js'></script>")

            btnClose.Attributes.Add("OnClick", "javascript:self.close();")
            btnUpload.Attributes.Add("OnClick", "javascript:if (!CheckFileExt()) {alert('" & ddlLabel.Items(3).Text & "'); return false;};")
        End Sub

        ' Process method
        ' Purpose: execute all process now
        Private Sub Process()
            Dim strFieldCode As String = Trim(Request("FieldCode"))
            Dim tblEDataParameters As DataTable

            ' Reserv
            If Not strFieldCode = "" Then
                hidFieldCode.Value = strFieldCode
            End If
            If Not Request("Repeatable") = "" Then
                hidRepeatable.Value = Request("Repeatable")
            End If
            If Not Request("WField") = "" Then
                hidWField.Value = Request("WField")
            End If
            If Not Request("SField") = "" Then
                hidSField.Value = Request("SField")
            End If
            If Not Request("SFile") = "" Then
                hidSFile.Value = Request("SFile")
            End If

            ' Get some information: allowed, dennied types of fiel, max value of file' size
            objWEData.FieldCode = strFieldCode
            tblEDataParameters = objWEData.GetEDataParams
            If Not tblEDataParameters Is Nothing Then
                If tblEDataParameters.Rows.Count > 0 Then
                    lblShowFieldCode.Text = tblEDataParameters.Rows(0).Item("FieldCode") & " - " & tblEDataParameters.Rows(0).Item("FieldCodeName")
                    If Not IsDBNull(tblEDataParameters.Rows(0).Item("AllowedFileExt")) Then
                        lblAllowedFileNames.Text = CStr(tblEDataParameters.Rows(0).Item("AllowedFileExt"))
                    End If
                    If Not IsDBNull(tblEDataParameters.Rows(0).Item("DeniedFileExt")) AndAlso tblEDataParameters.Rows(0).Item("DeniedFileExt") <> "" Then
                        lblDenniedFileNames.Visible = True
                        lblDenniedFiles.Visible = True
                        lblDenniedFileNames.Text = CStr(tblEDataParameters.Rows(0).Item("DeniedFileExt"))
                    Else
                        lblDenniedFileNames.Visible = False
                        lblDenniedFiles.Visible = False
                    End If
                    If Not IsDBNull(tblEDataParameters.Rows(0).Item("Maxsize")) Then
                        lblMaxSizeDetail.Text = CStr(tblEDataParameters.Rows(0).Item("Maxsize"))
                    End If
                    If Not IsDBNull(tblEDataParameters.Rows(0).Item("AllowedFileExt")) Then
                        hidAllowedFiles.Value = CStr(tblEDataParameters.Rows(0).Item("AllowedFileExt"))
                    End If
                    If Not IsDBNull(tblEDataParameters.Rows(0).Item("DeniedFileExt")) Then
                        hidDenniedFiles.Value = CStr(tblEDataParameters.Rows(0).Item("DeniedFileExt").GetType.ToString).Trim
                    End If
                    If Not IsDBNull(tblEDataParameters.Rows(0).Item("Maxsize")) Then
                        hidFileSize.Value = CStr(tblEDataParameters.Rows(0).Item("Maxsize"))
                    End If
                    If Not IsDBNull(tblEDataParameters.Rows(0).Item("PhysicalPath")) Then
                        hidPath.Value = CStr(tblEDataParameters.Rows(0).Item("PhysicalPath"))
                    End If
                    'If Not IsDBNull(tblEDataParameters.Rows(0).Item("URL")) Then
                    '    hidURL.Value = CStr(tblEDataParameters.Rows(0).Item("URL"))
                    'End If
                    If Not IsDBNull(tblEDataParameters.Rows(0).Item("Prefix")) Then
                        hidPrefix.Value = tblEDataParameters.Rows(0).Item("Prefix")
                    End If
                End If
            End If
            hidURL.Value = GetOneParaSystem("OPAC_URL")
        End Sub

        ' btnUpload_Click
        ' Purpose: upload data
        Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
            Dim strPath As String
            Dim strFileExt As String
            Dim strFileName As String
            Dim strFileNameTemp As String
            Dim strURL As String
            Dim lngMaxsize As Long
            Dim lngFileSize As Long
            Dim strInputer As String
            Dim intBitmapType As Integer
            Dim strColorModel As String
            Dim intImgWidth As Integer
            Dim intImgHeight As Integer
            Dim intXdpi As Integer
            Dim intYdpi As Integer
            Dim intNoColorUsed As Integer
            Dim strFullFileName As String
            Dim lngFileID As Long
            Dim strFieldValue As String = hidSFile.Value
            Dim strJS As String = ""
            Dim objDirInfor As DirectoryInfo

            SizeFile = CLng(hidFileSize.Value)
            TypeFile = hidAllowedFiles.Value

            ' Check size of file
            If Not CheckSize(CLng(hidFileSize.Value)) Then
                Page.RegisterClientScriptBlock("Excess", "<script language = 'javascript'>alert('" & ddlLabel.Items(0).Text & "');</script>")
            Else
                Randomize()
                strPath = Trim(hidPath.Value)
                objDirInfor = New DirectoryInfo(strPath)
                If Not objDirInfor.Exists Then
                    Call objDirInfor.Create()
                End If
                If Not Right(strPath, 1) = "\" Then
                    strPath = strPath & "\"
                End If
                strURL = Trim(hidURL.Value)

                If Not Right(strURL, 1) = "/" Then
                    strURL = strURL & "/"
                End If
                'add by lent
                strURL &= "WDownLoad.aspx?FileID="
                ''''''''''''''''''''''''''''
                strFileNameTemp = hidPrefix.Value & Year(Now) & CStr(Month(Now)).PadLeft(2, "0") & Month(Now) & CStr(Day(Now)).PadLeft(2, "0") & Day(Now) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65)
                strFileName = UpLoadFiles(filAttach, strPath, strFileNameTemp)
                Call WriteErrorMssg(ddlLabel.Items(4).Text, ErrorMsg, ddlLabel.Items(5).Text, ErrorCode)
                strFullFileName = strPath & strFileName
                If Not LCase(strFileName) = "fail" Then ' Successful
                    lngFileID = objWEData.ImportEData(strPath, strFileName)
                    Call WriteErrorMssg(ddlLabel.Items(4).Text, objWEData.ErrorMsg, ddlLabel.Items(5).Text, objWEData.ErrorCode)

                    Dim strSubField As String = "$a"
                    If Left(hidFieldCode.Value, 3) = "856" Then
                        strSubField = "$u"
                    End If
                    If hidRepeatable.Value = "1" Then
                        Dim arrSubVal()
                        Dim arrSubRec()
                        Dim intCounter As Integer
                        Dim strCurrFileName As String
                        Call objBCSP.ParseField(strSubField, strFieldValue, "##", arrSubVal)
                        If Not arrSubVal(0) = "" Then
                            Call objBCSP.ParseFieldValue(arrSubVal(0), "##", arrSubRec)
                            For intCounter = 0 To UBound(arrSubRec)
                                If Not arrSubRec(intCounter) = "" Then
                                    ' Get name of the file for delete
                                    strCurrFileName = arrSubRec(intCounter)
                                    strCurrFileName = Replace(strCurrFileName, "\", "/")
                                    strCurrFileName = strPath & Mid(strCurrFileName, InStrRev(strCurrFileName, "/") + 1)

                                    ' Check exists file
                                    strCurrFileName = Replace(strCurrFileName, "\", "\\")
                                    If File.Exists(strCurrFileName) Then
                                        File.Delete(strCurrFileName)
                                    End If
                                End If
                            Next
                        End If
                        Dim strTempSubVal As String = ""
                        If arrSubVal.Length > 1 Then
                            strTempSubVal = arrSubVal(1)
                        End If
                        If Not Left(hidFieldCode.Value, 3) = "956" Then
                            strFieldValue = strTempSubVal & strSubField & strURL & lngFileID
                        Else
                            strFieldValue = strTempSubVal & strSubField & lngFileID
                        End If
                    Else
                        If Not Left(hidFieldCode.Value, 3) = "956" Then
                            strFieldValue = strFieldValue & strSubField & strURL & lngFileID
                        Else
                            strFieldValue = strFieldValue & strSubField & lngFileID
                        End If

                        If Left(hidFieldCode.Value, 3) = "907" Then
                            strFieldValue = "WShowContent.aspx?FileID=" & lngFileID
                        End If

                    End If

                    strFieldValue = Replace(strFieldValue, "\", "\\")
                    ' None repeatable
                    If Not hidRepeatable.Value = "1" Then
                        strJS = strJS & "opener.top.main." & hidWField.Value & ".value = '';" & "opener.top.main." & hidWField.Value & ".value = '" & strFieldValue & "';" & Chr(13)
                        'strJS = strJS & "ud('" & hidFieldCode.Value & "');" & Chr(13)
                        If Not hidSField.Value = "" Then
                            strJS = strJS & "opener.top.main." & hidSField.Value & ".value = '';" & "opener.top.main." & hidSField.Value & ".value = '" & strFieldValue & "';" & Chr(13)
                        End If
                    Else
                        strJS = strJS & "opener.top.main." & hidWField.Value & ".value = '';" & "opener.top.main." & hidWField.Value & ".value = '" & strFieldValue & "';" & Chr(13)
                        'strJS = strJS & "ud('" & hidFieldCode.Value & "');" & Chr(13)
                        strJS = strJS & "myUpdateRecord('" & hidFieldCode.Value & "');" & Chr(13)
                    End If

                    Page.RegisterClientScriptBlock("LoadBack", "<script language = 'javascript'>" & strJS & ";</script>")
                    Page.RegisterClientScriptBlock("UploadSuccess", "<script language = 'javascript'>alert('" & ddlLabel.Items(2).Text & " " & strFileName & "');self.close();</script>")
                Else ' Fail
                    Page.RegisterClientScriptBlock("UploadFail", "<script language = 'javascript'>alert('" & ddlLabel.Items(1).Text & "');</script>")
                End If
            End If
            hidSFile.Value = strFieldValue
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objWEData Is Nothing Then
                    objWEData.Dispose(True)
                    objWEData = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace