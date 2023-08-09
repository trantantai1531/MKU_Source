Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports System.IO

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WBarcodeLazerPrint
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
        Private objBT As New clsBTemplate
        Private objBCC As New clsBCommonChart
        Private objBDBS As New clsBCommonDBSystem

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            Dim lngStartID, lngStopID As Long
            Dim collecBarCodeChoice As New Collection
            collecBarCodeChoice = Session("BarCodeChoice")
            hrf.Visible = False
            If Request.QueryString("CurrentPage") & "" = "" Then ' First time display
                lngStartID = 0
                lngStopID = CLng(collecBarCodeChoice.Item("page")) - 1
            Else
                lngStartID = (CInt(Request.QueryString("CurrentPage")) - 1) * CInt(collecBarCodeChoice.Item("page"))
                lngStopID = CInt(Request.QueryString("CurrentPage")) * CInt(collecBarCodeChoice.Item("page")) - 1
            End If
            If Session("lazerprinter") Then
                lblDisplay.Text = Display(collecBarCodeChoice.Item("printmode"), collecBarCodeChoice.Item("else"), lngStartID, lngStopID, collecBarCodeChoice)
                'Page.RegisterClientScriptBlock("PrintJs", "<script language='javascript'>self.focus();setTimeout('self.print()', 1);</script>")
            Else
                lblDisplay.Text = Display(collecBarCodeChoice.Item("printmode"), collecBarCodeChoice.Item("else"), lngStartID, lngStopID, collecBarCodeChoice)
            End If
        End Sub
        ' Initialize methods
        Private Sub Initialize()
            ' Initialize objBT object
            objBT.InterfaceLanguage = Session("InterfaceLanguage")
            objBT.DBServer = Session("DBServer")
            objBT.ConnectionString = Session("ConnectionString")
            objBT.Initialize()
            ' Initialize objBCC object
            objBCC.InterfaceLanguage = Session("InterfaceLanguage")
            objBCC.DBServer = Session("DBServer")
            objBCC.ConnectionString = Session("ConnectionString")
            objBCC.Initialize()
            ' Initialize objBDBS object
            objBDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBDBS.DBServer = Session("DBServer")
            objBDBS.ConnectionString = Session("ConnectionString")
            objBDBS.Initialize()
        End Sub

        ' Purpose: Gen BarCode image method
        ' In: boolPrintMode, boolElse, lngStartID, lngStopID, collecBarCodeChoice
        ' Out: string
        Private Function Display(ByVal boolPrintMode As Boolean, ByVal boolElse As Boolean, ByVal lngStartID As Long, ByVal lngStopID As Long, ByVal collecBarCodeChoice As Collection) As String
            Dim strResult As String = ""
            Dim objData As Object
            Dim lngi As Long
            Dim strDisplay As String
            Dim strPhysicalPath As String
            Dim boolSaveToFile, boolHave As Boolean
            Dim tblTemplate As New DataTable
            ' Get Data to print
            If boolElse = False Then  ' Print from Database
                objData = objBT.GetBarCodeData(lngStartID, lngStopID, collecBarCodeChoice, Session("IDs"))
            Else ' Print from input user data
                objData = Session("Else")
            End If
            If Session("lazerprinter") = False Then ' Barcode printer
                strDisplay = objBT.GenBarcodeString(collecBarCodeChoice.Item("barcodetype"), objData)
                If Not strDisplay & "" = "" Then
                    strPhysicalPath = CreateFile()
                    boolSaveToFile = SaveToFile(strPhysicalPath.Replace("/", "\"), collecBarCodeChoice.Item("barcodetype"), strDisplay)
                    If boolSaveToFile Then
                        If boolElse = False Then
                            Page.RegisterClientScriptBlock("ShowContentJs", "<script language='javascript'> parent.Content.location.href='" & strPhysicalPath.Substring(1) & "';setTimeout('parent.Content.print()', 1); </script>")
                        Else
                            Page.RegisterClientScriptBlock("ShowContentJs", "<script language='javascript'> self.location.href='" & strPhysicalPath.Substring(1) & "';setTimeout('self.print()', 1); </script>")
                        End If

                        'hrf.Visible = True
                        'hrf.NavigateUrl = Left(Request.Url.AbsoluteUri(), InStr(UCase(Request.Url.AbsoluteUri()), "ACQ", CompareMethod.Text) + 2) & strPhysicalPath.Replace("\", "/")
                        'lblDisplay.Text = strDisplay
                    End If
                    strResult = strDisplay
                End If

            Else ' Lazer printer
                If UBound(objData) >= 0 Then
                    Dim bolBarcodeGenerateLabel As Boolean = False
                    If Not IsNothing(collecBarCodeChoice.Item("barcodeGenerateLabel")) Then
                        bolBarcodeGenerateLabel = collecBarCodeChoice.Item("barcodeGenerateLabel")
                    End If
                    Dim strBarcodeColor As String = "000000"
                    If Not IsNothing(collecBarCodeChoice.Item("barcodeColor")) Then
                        strBarcodeColor = collecBarCodeChoice.Item("barcodeColor")
                    End If
                    objBCC.MakeImgBarcode(objData, collecBarCodeChoice.Item("imagetype"), collecBarCodeChoice.Item("width"), collecBarCodeChoice.Item("height"), collecBarCodeChoice.Item("type"), "", "", "", collecBarCodeChoice.Item("rotation"), strBarcodeColor, bolBarcodeGenerateLabel, "Arial", 13, FontStyle.Regular)
                    objData = objBCC.BarCodeImg
                    strResult = GenBarCodeImg(boolPrintMode, lngStartID, objData, collecBarCodeChoice.Item("colnumber"), collecBarCodeChoice.Item("colspace"), collecBarCodeChoice.Item("rowspace"), collecBarCodeChoice.Item("rotation"), collecBarCodeChoice.Item("imagetype"), collecBarCodeChoice.Item("marginTop"), collecBarCodeChoice.Item("marginLeft"), collecBarCodeChoice.Item("border"))
                End If
                'WriteLog()
                'Call WriteLog(39, ddlLog.Items(0).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
            End If
            Return strResult
        End Function

        ' GenBarCodeImage method
        ' In: some infor
        ' Out: string
        Private Function GenBarCodeImg(ByVal boolPrintMode As Boolean, ByVal lngStartPosition As Long, ByVal objDataToGen As Object, ByVal intColNumber As Integer, ByVal intColSpace As Integer, ByVal intRowSpace As Integer, ByVal intRotation As Integer, ByVal intImageType As Integer, ByVal intMarginTop As Integer, ByVal intMarginLeft As Integer, ByVal border As Boolean) As String
            Dim lngi, lngj, lngk As Long
            Dim strDisplay As String
            strDisplay = ""
            Dim collecBarCodeChoice As New Collection
            collecBarCodeChoice = Session("BarCodeChoice")
            If Not objDataToGen Is Nothing Then
                If UBound(objDataToGen) >= 0 Then ' Have data to gen barcode image                  
                    If boolPrintMode = True Then  ' Print from lazer printer
                        strDisplay = "<TABLE border='0' style='margin-top: " & intMarginTop & "px; margin-left: " & intMarginLeft & "px;' cellpadding=0 cellspacing='" & intColSpace & "'>"
                        'Dim intWidth As Integer = 100 \ intColNumber
                        lngk = 0
                        For lngi = LBound(objDataToGen) To UBound(objDataToGen) 'lngStopID
                            lngk = lngi + 1
                            lngj = lngStartPosition + 1
                            If Not Session("bc" & lngi + lngStartPosition) Is Nothing Then
                                Session("bc" & lngi + lngStartPosition) = Nothing
                            End If
                            Session("bc" & lngi + lngStartPosition) = objDataToGen(lngi)
                            If lngk = intColNumber + 1 Then
                                strDisplay &= "</TR><TR>"
                            Else
                                If lngk Mod intColNumber = 1 And lngk > intColNumber Then
                                    strDisplay &= "<TR>"
                                End If
                            End If
                            If border = True Then
                                If collecBarCodeChoice.Item("barcodeGenerateLabel") Then
                                    strDisplay &= "<TD valign='middle' style='border:1.5px solid black; padding-top:10px; border-color:#000000; width:167px; height:51px;'>"
                                Else
                                    strDisplay &= "<TD valign='middle' style='border:1.5px solid black; padding-top:10px; padding-bottom:5px; border-color:#000000; width:170px; height:51px;'>"
                                End If
                                strDisplay &= "<div style='width: 100%; overflow: hidden;'><div style='text-align:center;'><IMG style='width:164px; height:38px;' src=../../Common/WPrintBarCode.aspx?i=" & lngi + lngStartPosition & "&ImgType=" & intImageType & "&rotate=" & intRotation & "></div></div></TD>"
                            Else
                                strDisplay &= "<TD valign='middle' style=' width:167px; height:53px;'>"
                                strDisplay &= "<div style='width: 100%; overflow: hidden;'><div style='text-align:center;'><IMG style='width:164px; height:38px;' src=../../Common/WPrintBarCode.aspx?i=" & lngi + lngStartPosition & "&ImgType=" & intImageType & "&rotate=" & intRotation & "></div></div></TD>"
                            End If

                            'If intColSpace > 0 Then
                            '    strDisplay &= "<TD style=' width:167px; height:53px;'><IMG SRC=../images/bg.gif WIDTH=" & intColSpace & " HEIGHT=1></TD>"
                            'End If

                            'If intRowSpace > 0 Then
                            '    If intColSpace = 0 Then
                            '        strDisplay &= "<TR><TD COLSPAN=" & intColNumber & "><IMG SRC=""../images/bg.gif"" WIDTH=1 HEIGHT=" & intRowSpace & "></TD></TR>"
                            '    Else
                            '        strDisplay &= "<TR><TD COLSPAN=" & 2 * intColNumber & "><IMG SRC=""../images/bg.gif"" WIDTH=1 HEIGHT=" & intRowSpace & "></TD></TR>"
                            '    End If
                            'End If
                            If lngk Mod intColNumber = 0 And lngk >= intColNumber Then
                                strDisplay &= "</TR>"
                                If intRowSpace > 0 Then
                                    strDisplay &= " <tr><td  COLSPAN=" & intColNumber & " height='" & intRowSpace & "'>&nbsp;</td></tr>"
                                End If
                            End If
                        Next
                        For i As Integer = (lngi Mod intColNumber) + 1 To intColNumber
                            strDisplay &= "<TD valign='middle' style='width:170px; height:53px;'><div style='width: 100%; overflow: hidden;'><div style='text-align: center;'><IMG SRC=../images/bg.gif style='width:170px;height:0px;'></div></div></TD>"
                        Next
                        strDisplay &= "</TABLE>"
                        GenBarCodeImg = strDisplay
                    End If
                Else
                    Return (Nothing)
                End If
            End If
        End Function

        ' Purpose: Save to file
        ' In: some infor
        ' Out: boolean
        ' Creator: Sondp
        Private Function SaveToFile(ByVal strFileName As String, ByVal intTemplate As Integer, ByVal strData As String) As Boolean
            Dim fs As StreamWriter
            Try
                SaveToFile = False
                fs = File.CreateText(Server.MapPath("") & strFileName)
                fs.Write(strData)
                fs.Close()
                SaveToFile = True
            Catch ex As Exception
                Response.Write(ex.Message)
                SaveToFile = False
            Finally
                If Not fs Is Nothing Then
                    fs = Nothing
                End If
            End Try
        End Function

        ' Purpose: Create file content barcode
        ' In: 
        ' Out: strPhysicalPath
        ' Creator: Sondp
        Private Function CreateFile() As String
            Dim intTTL As Integer = 24 ' Time to live
            Dim arrName(0) As String
            Dim arrVal(0) As String
            Dim tblSaveToFile As New DataTable
            Dim fs As FileStream
            Dim FileLoc As Object
            Dim tblTempFile As DataTable = Nothing
            Dim FileName As String
            Dim FileLocation As String
            Dim inti As Integer
            Dim Extension As String = "txt" ' Extension of file to save
            Try
                arrName(0) = "TEMPFILE_TTL"
                arrVal = objBDBS.GetSystemParameters(arrName)
                If UBound(arrVal) >= 0 Then
                    intTTL = arrVal(0)
                    FileLoc = Request.ServerVariables("SCRIPT_NAME")
                    FileLoc = Left(Trim(FileLoc), Len(FileLoc) - 4)
                    FileLoc = Left(FileLoc, InStrRev(FileLoc, "/")) & "BarCode/"
                    Dim strWhere As String
                    If Session("DBServer") = "SQLSERVER" Then
                        strWhere = " WHERE DATEDIFF(hour, CreatedDate, GetDate()) > " & intTTL
                    Else
                        strWhere = " WHERE (sysdate - CreatedDate)*24 > " & intTTL
                    End If
                    If Not tblTempFile Is Nothing Then
                        ' Delete temporary file
                        For inti = 0 To tblTempFile.Rows.Count - 1
                            FileName = tblTempFile.Rows(inti).Item("FileName")
                            FileLocation = Server.MapPath(FileLoc & FileName)
                            If File.Exists(FileLocation) = True Then
                                File.Delete(FileLocation)
                            End If
                            objBDBS.Condition = " WHERE FileName='" & FileName & "'"
                            objBDBS.DeleteSysDownloadFile()
                        Next
                    End If
                    Randomize()
                    ' Init file name
                    FileName = Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65)
                    tblTempFile = Nothing
                    objBDBS.Condition = " WHERE FileName='" & FileName & "." & Extension & "'"
                    tblTempFile = objBDBS.GetSysDownloadFile
                    While tblTempFile.Rows.Count > 0
                        FileName = Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65)
                        objBDBS.Condition = " WHERE FileName='" & FileName & "." & Extension & "'"
                        tblTempFile = objBDBS.GetSysDownloadFile
                    End While
                    ' Insert information about this file into table SYS_PARAMETER
                    objBDBS.FileName = FileName & "." & Extension
                    objBDBS.CreatedDate = Now()
                    objBDBS.InsertSysDownloadFile()
                    ' Catch errors
                    ' Call WriteErrorMssg(ddlLog.Items(2).Text, objBT.ErrorMsg, ddlLog.Items(3).Text, objBT.ErrorCode)
                    fs = File.Create(Server.MapPath("") & "/BarCode/" & FileName & ".txt")
                    fs.Close()
                    ' WriteLog
                    ' Call WriteLog(39, ddlLog.Items(1).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                    'Return (Server.MapPath("") & "/BarCode/" & FileName & ".txt")
                    Return ("/BarCode/" & FileName & ".txt")
                End If
            Catch ex As Exception
                Response.Write(ex.Message)
            Finally
            End Try
        End Function

        ' Page_Unload method
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBT Is Nothing Then
                objBT.Dispose(True)
                objBT = Nothing
            End If
            If Not objBCC Is Nothing Then
                objBCC.Dispose(True)
                objBCC = Nothing
            End If
            If Not objBDBS Is Nothing Then
                objBDBS.Dispose(True)
                objBDBS = Nothing
            End If
        End Sub
    End Class
End Namespace