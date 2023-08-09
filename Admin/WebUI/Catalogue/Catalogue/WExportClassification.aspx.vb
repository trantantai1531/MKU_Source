Imports System.IO
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WExportClassification
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents ddlFormat As System.Web.UI.WebControls.DropDownList
        Protected WithEvents RadioButton1 As System.Web.UI.WebControls.RadioButton
        Protected WithEvents RadioButton2 As System.Web.UI.WebControls.RadioButton
        Protected WithEvents lblDateCreate As System.Web.UI.WebControls.Label
        Protected WithEvents lblFormatType As System.Web.UI.WebControls.Label
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents txtDisPlayEntry As System.Web.UI.WebControls.TextBox


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBExportRecord As New clsBExportRecord
        Private objBForm As New clsBForm
        Private objBCommonDBSystem As New clsBCommonDBSystem
        Private objBCSP As New clsBCommonStringProc
        Private objBItemCollection As New clsBItemCollection

        Private tblAuthorityMainInFor As New DataTable
        Private tblExportClassification As New DataTable
        Private strPath As String
        Private strFileName As String

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPemission()
            Call Initialize()
            Call BindJS()
        End Sub

        ' Initialize method
        ' Purpose: initialize all objects
        Private Sub Initialize()
            ' Init objBFormingSQL  object
            objBCommonDBSystem.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonDBSystem.DBServer = Session("DBServer")
            objBCommonDBSystem.ConnectionString = Session("ConnectionString")
            Call objBCommonDBSystem.Initialize()

            ' Init objBCSP object
            objBCSP.InterfaceLanguage = Session("InterfaceLanguage")
            objBCSP.DBServer = Session("DBServer")
            objBCSP.ConnectionString = Session("ConnectionString")
            Call objBCSP.Initialize()

            ' Init objBItemCollection object
            objBItemCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemCollection.DBServer = Session("DBServer")
            objBItemCollection.ConnectionString = Session("ConnectionString")
            Call objBItemCollection.Initialize()

            ' Init objBFormingSQL object
            objBForm.InterfaceLanguage = Session("InterfaceLanguage")
            objBForm.DBServer = Session("DBServer")
            objBForm.ConnectionString = Session("ConnectionString")
            Call objBForm.Initialize()

            ' Init objBExportRecord object
            objBExportRecord.InterfaceLanguage = Session("InterfaceLanguage")
            objBExportRecord.DBServer = Session("DBServer")
            objBExportRecord.ConnectionString = Session("ConnectionString")
            Call objBExportRecord.Initialize()
        End Sub

        ' Method: CheckFormPemission
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            If Not CheckPemission(223) Then
                btnExport.Enabled = False
            End If
        End Sub

        ' Method: BindJS
        ' Purpose: bind javascript
        Private Sub BindJS()
            Dim strJS As String

            ' JavaScript            
            Page.RegisterClientScriptBlock("WCommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("selfJs", "<script language = 'javascript' src = '../js/Catalogue/WExportClassification.js'></script>")

            strJS = "javascript: if(!CheckInput('" & ddlLabel.Items(14).Text & "','" & ddlLabel.Items(12).Text & "','" & ddlLabel.Items(11).Text & "','" & ddlLabel.Items(13).Text & "','" & ddlLabel.Items(15).Text & "','" & ddlLabel.Items(16).Text & "')) return false;"
            btnExport.Attributes.Add("Onclick", strJS)
            btnReset.Attributes.Add("OnClick", "return ResetForm();")
            Me.SetCheckNumber(txtIDFrom, ddlLabel.Items(3).Text, "")
            Me.SetCheckNumber(txtIDTo, ddlLabel.Items(3).Text, "")
            Me.SetCheckNumber(txtMaxExp, ddlLabel.Items(3).Text, "")
            chkExpAll.Attributes.Add("onClick", "SetCheckGetAll()")
        End Sub

        ' Page_Unload event: Unload the page and release the methods
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Sub CreateBulkISORec
        ' Purpose: Export data to file ISO
        ' Input : 
        '           + ItemIDs: if ItemIDs='' then no ItemID
        '           + objF As StreamWriter: Object to write  
        '           + strFileName as string: Path
        ' Ouput : File ISO and Progetpar
        Sub CreateBulkISORec(ByVal ItemIDs As String, ByVal objF As StreamWriter, ByVal strFileName As String)
            Dim intTotal As Integer
            Dim intridx As Integer
            Dim strFVal As String
            Dim strIndicators As String
            Dim intPercentage As Integer
            Dim intCurPerc As Integer
            Dim intBaseAdd As Integer
            Dim intFlen As Integer
            Dim intTotalLen As Integer
            Dim strDir As String
            Dim strRecVal As String
            Dim strft As String
            Dim strLeader As String
            Dim strRecord As String
            Dim strRecwbr As String
            Dim strrt As String
            Dim intStartRecord As Integer
            Dim intLineLen As Integer
            Dim intRemainLen As Integer
            Dim strsi As String
            Dim intSum As Integer

            'Define some signs special
            strsi = "$"
            strft = "#"
            strrt = "#"

            If optCheckIso.Checked = False Then
                strft = Chr(30)
                strrt = Chr(29)
                strsi = Chr(31)
            Else
                If Not txtSubField.Text.Trim = "" Then
                    strsi = txtSubField.Text.Trim
                Else
                    strsi = "$"
                End If
                If Not txtFieldTer.Text = "" Then
                    strft = txtFieldTer.Text
                Else
                    strft = "#"
                End If
                If Not txtRecTer.Text = "" Then
                    strrt = txtRecTer.Text
                Else
                    strrt = "#"
                End If
            End If

            tblExportClassification = objBExportRecord.GetClassficationData

            intTotal = tblExportClassification.Rows.Count

            ' Define intTotal
            If Not chkExpAll.Checked Then
                If intTotal > Val(txtMaxExp.Text) And Val(txtMaxExp.Text) <> 0 Then
                    intTotal = Val(txtMaxExp.Text)
                End If
            End If

            If intTotal > 0 Then
                intSum = 1
                Response.Write("<SPAN class='lbLabel' style='position:absolute;top:250;left: 20px'>")
                Response.Write(ddlLabel.Items(0).Text & "<span id='pgbMain_label'>0%</span><br>")
                Response.Write("<table width='0%' border=2 bordercolor='white' id='pgbMain' bgcolor=#669999><tr style='HEIGHT: 18px'><td></td></tr></table>")
                For intridx = 0 To intTotal - 1
                    intTotalLen = 26
                    intBaseAdd = 25
                    strDir = ""
                    strRecVal = ""

                    ' Item Code
                    If Not IsDBNull(tblExportClassification.Rows(intridx).Item("ItemCode")) Then
                        If Not Trim(CStr(tblExportClassification.Rows(intridx).Item("ItemCode").trim)) = "" Then
                            strFVal = objBCSP.ToUTF8(tblExportClassification.Rows(intridx).Item("ItemCode").ToString.Trim)
                            intFlen = Len(strFVal) + 1
                            strDir = strDir & "001" & "0000".Substring(0, 4 - Len(CStr(intFlen))) & intFlen & "00000".Substring(0, 5 - Len(CStr(Len(strRecVal)))) & Len(strRecVal)
                            intBaseAdd = intBaseAdd + 12
                            strRecVal = strRecVal & strFVal & strft
                        End If
                    End If

                    ' Display Entry and caption
                    If Not IsDBNull(tblExportClassification.Rows(intridx).Item("DisplayEntry")) Or Not IsDBNull(tblExportClassification.Rows(intridx).Item("Caption")) Then
                        intBaseAdd = intBaseAdd + 12
                        strFVal = ""
                        ' Display Entry
                        If Not IsDBNull(tblExportClassification.Rows(intridx).Item("DisplayEntry")) Then
                            If Not Trim(CStr(tblExportClassification.Rows(intridx).Item("DisplayEntry"))) = "" Then
                                strFVal = strsi & "a" + tblExportClassification.Rows(intridx).Item("DisplayEntry").ToString.Trim
                            End If
                        End If
                        ' Caption
                        If Not IsDBNull(tblExportClassification.Rows(intridx).Item("Caption")) Then
                            If Not Trim(CStr(tblExportClassification.Rows(intridx).Item("Caption"))) = "" Then
                                strFVal = strFVal & strsi & "j" + tblExportClassification.Rows(intridx).Item("Caption").ToString.Trim
                            End If
                        End If
                        strFVal = objBCSP.ToUTF8(strFVal)
                        intFlen = Len(strFVal) + 1
                        strDir = strDir & "153" & "0000".Substring(0, 4 - Len(CStr(intFlen))) & intFlen & "00000".Substring(0, 5 - Len(CStr(Len(strRecVal)))) & Len(strRecVal)
                        strRecVal = strRecVal & strFVal & strft
                    End If

                    ' Type, version, description
                    If Not IsDBNull(tblExportClassification.Rows(intridx).Item("Type")) Or Not IsDBNull(tblExportClassification.Rows(intridx).Item("Version")) Or Not IsDBNull(tblExportClassification.Rows(intridx).Item("Description")) Then
                        intBaseAdd = intBaseAdd + 12
                        strFVal = ""
                        ' Type
                        If Not IsDBNull(tblExportClassification.Rows(intridx).Item("Type")) Then
                            If Not Trim(CStr(tblExportClassification.Rows(intridx).Item("Type"))) = "" Then
                                strFVal = strsi & "a" + tblExportClassification.Rows(intridx).Item("Type").ToString.Trim
                            End If
                        End If
                        ' Version
                        If Not IsDBNull(tblExportClassification.Rows(intridx).Item("Version")) Then
                            If Not Trim(CStr(tblExportClassification.Rows(intridx).Item("Version"))) = "" Then
                                strFVal = strFVal & strsi & "c" + tblExportClassification.Rows(intridx).Item("Version").ToString.Trim
                            End If
                        End If
                        ' Description
                        If Not IsDBNull(tblExportClassification.Rows(intridx).Item("Description")) Then
                            If Not Trim(CStr(tblExportClassification.Rows(intridx).Item("Description"))) = "" Then
                                strFVal = strFVal & strsi & "h" + tblExportClassification.Rows(intridx).Item("Description").ToString.Trim
                            End If
                        End If
                        strFVal = objBCSP.ToUTF8(strFVal)
                        intFlen = Len(strFVal) + 1
                        strDir = strDir & "084" & "0000".Substring(0, 4 - Len(CStr(intFlen))) & intFlen & "00000".Substring(0, 5 - Len(CStr(Len(strRecVal)))) & Len(strRecVal)
                        strRecVal = strRecVal & strFVal & strft
                    End If

                    intTotalLen = intTotalLen + Len(strDir) + Len(strRecVal)

                    'strLeader = "00000".Substring(0, 5 - Len(CStr(intTotalLen))) & intTotalLen & Mid(tblExportClassification.Rows(intridx).Item("ItemLeader").ToString.Trim, 6, 7) & "00000".Substring(0, 5 - Len(CStr(intBaseAdd))) & intBaseAdd & Right(tblExportClassification.Rows(intridx).Item("ItemLeader").ToString.Trim, 7)
                    strLeader = "00000".Substring(0, 5 - Len(CStr(intTotalLen))) & intTotalLen & "0000000".Substring(0, 7 - Len(Mid(tblExportClassification.Rows(intridx).Item("ItemLeader").ToString.Trim, 6, 7))) & Mid(tblExportClassification.Rows(intridx).Item("ItemLeader").ToString.Trim, 6, 7) & "00000".Substring(0, 5 - Len(CStr(intBaseAdd))) & intBaseAdd & "0000000".Substring(0, 7 - Len(Right(tblExportClassification.Rows(intridx).Item("ItemLeader").ToString.Trim, 7))) & Right(tblExportClassification.Rows(intridx).Item("ItemLeader").ToString.Trim, 7)
                    ' Record string
                    strRecord = strLeader & strDir & strft & strRecVal & strrt
                    strRecwbr = ""
                    intStartRecord = 1

                    If intLineLen > 0 Then
                        While Len(strRecord) > 0
                            If Len(strRecord) > intLineLen Then
                                If intStartRecord = 1 Then
                                    strRecwbr = strRecwbr & Left(strRecord, intLineLen - intRemainLen)
                                    strRecord = Right(strRecord, Len(strRecord) - intLineLen + intRemainLen)
                                    intStartRecord = 0
                                Else
                                    strRecwbr = strRecwbr & Left(strRecord, intLineLen)
                                    strRecord = Right(strRecord, Len(strRecord) - intLineLen)
                                End If
                            Else
                                strRecwbr = strRecwbr & strRecord
                                intRemainLen = Len(strRecord)
                                strRecord = ""
                            End If
                        End While
                    Else
                        strRecwbr = strRecord
                    End If
                    objF.Write(objBCSP.ToUTF8Back(strRecwbr))
                    Call BindPrg(intridx, intTotal)
                    intCurPerc = Int(intridx * 100 / intTotal)
                    If (intCurPerc - intPercentage) >= 5 Then
                        intPercentage = (Int(intCurPerc / 5)) * 5
                        Response.Flush()
                    End If
                    intSum = intSum + 1
                Next

                Call objBCommonDBSystem.InsertSysDownloadFile()
                Response.Write("</SPAN>")
                lblClick.Visible = True
                lnkLink.Visible = True
                lblLinkTail.Visible = True
                lnkLink.Target = "Hiddenbase"
                lnkLink.NavigateUrl = "#"
                lnkLink.Attributes.Add("OnClick", "parent.Hiddenbase.location.href='../../Common/WSaveTempFile.aspx?ModuleID=1&FileName=" & strFileName & "';return false;")
                'lnkLink.NavigateUrl = strPath
                lblResult.Visible = True
                lblCount.Visible = True
                If intSum > 0 Then
                    lblCount.Text = intSum - 1
                Else
                    lblCount.Text = 0
                End If

            Else
                lblCount.Visible = False
                lblResult.Visible = False
                lblClick.Visible = False
                lnkLink.Visible = False
                lblLinkTail.Visible = False
                RegisterClientScriptBlock("SearchFail", "<script language='JavaScript'>alert('" & ddlLabel.Items(2).Text & "')</script>")
            End If
        End Sub

        ' ***************************************************************************************************
        ' BindData sub
        ' Purpose: Bind data for Controls
        ' ***************************************************************************************************
        Public Sub BindPrg(ByVal intCurrent As Integer, ByVal intSum As Integer)
            Dim intCurrentPercent As Integer
            intCurrentPercent = ((intCurrent + 1) * 100) / intSum
            If intCurrentPercent Mod 10 = 0 Then
                'System.Threading.Thread.Sleep(500 / intSum)
                Response.Write("<script>if (pgbObj = document.getElementById('pgbMain')) pgbObj.width =" & intCurrentPercent & " + '%'; if (lblObj = document.getElementById('pgbMain_label')) lblObj.innerHTML =" & intCurrentPercent & " + '%';</script>")
                Response.Flush()
            End If
        End Sub

        ' btnExport_Click event
        Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
            Dim tblTempFile As DataTable

            ' Gioi han ban ghi
            objBExportRecord.AccessEntry = ddlDisPlayEntry.SelectedItem.Text
            If IsNumeric(txtIDFrom.Text.ToString.Trim) Then
                objBExportRecord.FromID = txtIDFrom.Text.ToString.Trim
            Else
                objBExportRecord.FromID = 0
            End If
            If IsNumeric(txtIDTo.Text.ToString.Trim) Then
                objBExportRecord.ToID = txtIDTo.Text.ToString.Trim
            Else
                objBExportRecord.ToID = 0
            End If


            tblTempFile = objBCommonDBSystem.GetTempFilePath(1)
            If Not tblTempFile Is Nothing Then
                If tblTempFile.Rows.Count > 0 Then
                    strPath = tblTempFile.Rows(0).Item("TempFilePath")
                End If
            End If

            objBCommonDBSystem.Extension = "ISO"
            strFileName = objBCommonDBSystem.GenRandomFile
            strPath = Server.MapPath("../..") & strPath & "/" & strFileName

            Dim ObjOut = New StreamWriter(strPath, True)
            Call CreateBulkISORec("strItemIDs", ObjOut, strFileName)
            ObjOut.Close()
        End Sub

        ' Dispose method
        ' Purpose: Release the methods
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCommonDBSystem Is Nothing Then
                    objBCommonDBSystem.Dispose(True)
                    objBCommonDBSystem = Nothing
                End If
                If Not objBItemCollection Is Nothing Then
                    objBItemCollection.Dispose(True)
                    objBItemCollection = Nothing
                End If
                If Not objBExportRecord Is Nothing Then
                    objBExportRecord.Dispose(True)
                    objBExportRecord = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
            Finally
                Call MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace