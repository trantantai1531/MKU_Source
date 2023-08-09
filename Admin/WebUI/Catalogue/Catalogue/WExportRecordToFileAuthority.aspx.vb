Imports System.IO
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WExportRecordToFileAuthority
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents ddlReferenceID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents RadioButton1 As System.Web.UI.WebControls.RadioButton
        Protected WithEvents RadioButton2 As System.Web.UI.WebControls.RadioButton


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBER As New clsBExportRecord
        Private objBCDBS As New clsBCommonDBSystem
        Private objBCSP As New clsBCommonStringProc
        Private objBIC As New clsBItemCollection

        Private tblAuthorityMainInFor As New DataTable
        Private tblAuthorityDetailInFor As New DataTable

        Private strPath As String = ""
        Private strFileName As String

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPemission()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                BindDataAuthorityID()
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: Init all need objects
        Private Sub Initialize()
            Session("IsAuthority") = 1

            ' Init objBFormingSQL object
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            Call objBCDBS.Initialize()

            ' Init objBCSP object
            objBCSP.InterfaceLanguage = Session("InterfaceLanguage")
            objBCSP.DBServer = Session("DBServer")
            objBCSP.ConnectionString = Session("ConnectionString")
            Call objBCSP.Initialize()

            ' Init objBIC object
            objBIC.IsAuthority = Session("IsAuthority")
            objBIC.InterfaceLanguage = Session("InterfaceLanguage")
            objBIC.DBServer = Session("DBServer")
            objBIC.ConnectionString = Session("ConnectionString")
            Call objBIC.Initialize()

            ' Init objBER object
            objBER.InterfaceLanguage = Session("InterfaceLanguage")
            objBER.DBServer = Session("DBServer")
            objBER.ConnectionString = Session("ConnectionString")
            Call objBER.Initialize()
        End Sub

        ' Method: CheckFormPemission
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            If Not CheckPemission(146) Then
                btnExport.Enabled = False
            End If
        End Sub

        ' Method: BindJS
        ' Purpose: bind javascript
        Private Sub BindJS()
            Dim strJS As String

            ' JavaScript            
            Page.RegisterClientScriptBlock("WCommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("selfJs", "<script language = 'javascript' src = '../js/Catalogue/WExportRecordToFileAuthority.js'></script>")

            Me.SetCheckNumber(txtIDFrom, ddlLabel.Items(3).Text, "")
            Me.SetCheckNumber(txtIDTo, ddlLabel.Items(3).Text, "")
            Me.SetCheckNumber(txtMaxExp, ddlLabel.Items(3).Text, "")

            strJS = "javascript: if(!CheckInput('" & ddlLabel.Items(6).Text & "','" & ddlLabel.Items(4).Text & "','" & ddlLabel.Items(3).Text & "','" & ddlLabel.Items(5).Text & "','" & ddlLabel.Items(7).Text & "','" & ddlLabel.Items(8).Text & "','" & ddlLabel.Items(13).Text & "')) return false;"
            btnExport.Attributes.Add("Onclick", strJS)
            btnReset.Attributes.Add("OnClick", "return ResetForm();")
            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkCalFrom, txtCataFrom, ddlLabel.Items(9).Text)
            SetOnclickCalendar(lnkCalTo, txtCataTo, ddlLabel.Items(9).Text)
            chkExpAll.Attributes.Add("onClick", "SetCheckGetAll()")
        End Sub

        ' Find Id of liblary where Id exits in Authority
        Sub BindDataAuthorityID()
            Dim tblTemp As DataTable

            tblTemp = objBER.GetSourceAuthority
            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    ddlSourceID.DataSource = tblTemp
                    ddlSourceID.DataTextField = "Code"
                    ddlSourceID.DataValueField = "ID"
                    ddlSourceID.DataBind()
                End If
            End If
        End Sub

        ' Page_Unload event: Unload the page and release the methods
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Sub CreateBulkMARCRec
        ' Purpose: Export data to file ISO
        ' Input : 
        '           + ItemIDs: if ItemIDs='' then no ItemID
        '           + objF As StreamWriter: Object to write  
        '           + strFileName as string: Path
        ' Ouput : File MARC and Progetpar
        Sub CreateBulkMARCRec(ByVal ItemIDs As String, ByVal objF As StreamWriter, ByVal strFileName As String)
            Dim intIndex As Integer
            Dim intTotal As Integer
            Dim intRidx As Integer
            Dim strFVal As String
            Dim strIndicators As String
            Dim intPercentage As Integer
            Dim intCurPerc As Integer
            Dim intSum As Integer = 0

            tblAuthorityDetailInFor = objBER.GetAuthorityDetailInfor
            tblAuthorityMainInFor = objBER.GetAuthorityMainInfor

            ' get the total of IDs found
            If Not tblAuthorityMainInFor Is Nothing Then
                If tblAuthorityMainInFor.Rows.Count > 0 Then
                    intTotal = tblAuthorityMainInFor.Rows.Count
                End If
            End If

            intIndex = 1

            If intTotal > Val(txtMaxExp.Text) And Val(txtMaxExp.Text) <> 0 Then
                intTotal = Val(txtMaxExp.Text)
            End If

            ' If more or equal 1 Id found
            If intTotal > 0 Then
                intSum = 0
                Response.Write("<SPAN class='lbLabel' style='position:absolute;top:350;left: 20px'>")
                Response.Write(ddlLabel.Items(0).Text & "<span id='pgbMain_label'>0%</span><br>")
                Response.Write("<table width='0%' border=2 bordercolor='white' id='pgbMain' bgcolor=#669999><tr style='HEIGHT: 18px'><td></td></tr></table>")

                For intRidx = 0 To intTotal - 1
                    objF.WriteLine("Ldr " & tblAuthorityMainInFor.Rows(intRidx).Item("Leader"))
                    ' Item Code
                    If Not IsDBNull(tblAuthorityMainInFor.Rows(intRidx).Item("Code")) Then
                        objF.WriteLine("#001 " & tblAuthorityMainInFor.Rows(intRidx).Item("Code"))
                    End If
                    ' TDate
                    If Not IsDBNull(tblAuthorityMainInFor.Rows(intRidx).Item("TDATE")) Then
                        strFVal = Year(tblAuthorityMainInFor.Rows(intRidx).Item("TDATE")) & "00".Substring(0, 2 - Month(tblAuthorityMainInFor.Rows(intRidx).Item("TDATE")).ToString.Trim.Length) & Month(tblAuthorityMainInFor.Rows(intRidx).Item("TDATE")) & _
                                              "00".Substring(0, 2 - Day(tblAuthorityMainInFor.Rows(intRidx).Item("TDATE")).ToString.Trim.Length) & _
                                              Day(tblAuthorityMainInFor.Rows(intRidx).Item("TDATE")) & "00".Substring(0, 2 - Hour(tblAuthorityMainInFor.Rows(intRidx).Item("TDATE")).ToString.Trim.Length) & _
                                              Hour(tblAuthorityMainInFor.Rows(intRidx).Item("TDATE")) & "00".Substring(0, 2 - Minute(tblAuthorityMainInFor.Rows(intRidx).Item("TDATE")).ToString.Trim.Length) & Minute(tblAuthorityMainInFor.Rows(intRidx).Item("TDATE")) & _
                                              "00".Substring(0, 2 - Second(tblAuthorityMainInFor.Rows(intRidx).Item("TDATE")).ToString.Trim.Length) & Second(tblAuthorityMainInFor.Rows(intRidx).Item("TDATE")) & ".0"
                        objF.WriteLine("#005 " & strFVal)
                    End If

                    If Not tblAuthorityDetailInFor Is Nothing Then
                        If tblAuthorityDetailInFor.Rows.Count > 0 Then
                            For intIndex = 0 To tblAuthorityDetailInFor.Rows.Count - 1
                                If Not CLng(tblAuthorityDetailInFor.Rows(intIndex).Item("AuthorityID")) = CLng(tblAuthorityMainInFor.Rows(intRidx).Item("ID")) Then
                                    'Exit For
                                Else
                                    ' Indicators
                                    If Not IsDBNull(tblAuthorityDetailInFor.Rows(intIndex).Item("Indicators")) Or Not IsDBNull(tblAuthorityDetailInFor.Rows(intIndex).Item("VietIndicators")) Then
                                        If Not IsDBNull(tblAuthorityDetailInFor.Rows(intIndex).Item("Ind1")) AndAlso tblAuthorityDetailInFor.Rows(intIndex).Item("Ind1") <> "" Then
                                            strIndicators = tblAuthorityDetailInFor.Rows(intIndex).Item("Ind1").ToString.Trim
                                        Else
                                            strIndicators = " "
                                        End If
                                        If Not IsDBNull(tblAuthorityDetailInFor.Rows(intIndex).Item("Ind2")) AndAlso tblAuthorityDetailInFor.Rows(intIndex).Item("Ind2") <> "" Then
                                            strIndicators = strIndicators & tblAuthorityDetailInFor.Rows(intIndex).Item("Ind2").ToString.Trim
                                        Else
                                            strIndicators = strIndicators & " "
                                        End If
                                    End If
                                    objF.WriteLine("#" & tblAuthorityDetailInFor.Rows(intIndex).Item("FieldCode").ToString.Trim & " " & strIndicators & tblAuthorityDetailInFor.Rows(intIndex).Item("Content"))     'Thieu, chua lay du thong tin.
                                End If
                            Next
                        End If
                    End If

                    ' Cataloguer
                    If Not IsDBNull(tblAuthorityMainInFor.Rows(intRidx).Item("Cataloguer")) Then
                        If Not tblAuthorityMainInFor.Rows(intRidx).Item("Cataloguer").ToString.Trim = "" Then
                            objF.WriteLine("#911 " & tblAuthorityMainInFor.Rows(intRidx).Item("Cataloguer").ToString.Trim)
                        End If
                    End If

                    ' Reviewer
                    If Not IsDBNull(tblAuthorityMainInFor.Rows(intRidx).Item("Reviewer")) Then
                        If Not tblAuthorityMainInFor.Rows(intRidx).Item("Cataloguer").ToString.Trim = "" Then
                            objF.WriteLine("#912 " & tblAuthorityMainInFor.Rows(intRidx).Item("Reviewer").ToString.Trim)
                        End If
                    End If

                    objF.WriteLine("##")

                    ' Calculate Percentage
                    intCurPerc = Int(intRidx * 100 / intTotal)
                    If (intCurPerc - intPercentage) >= 5 Then
                        intPercentage = (Int(intCurPerc / 5)) * 5
                        Response.Flush()
                    End If
                    Call BindPrg(intRidx, tblAuthorityMainInFor.Rows.Count)
                    intSum = intSum + 1
                Next
                objF.Close()
                Response.Write("</SPAN>")
                lblClick.Visible = True
                lnkLink.Visible = True
                lblLinkTail.Visible = True
                lnkLink.Target = "Hiddenbase"
                lnkLink.NavigateUrl = "#"
                lnkLink.Attributes.Add("onClick", "parent.Hiddenbase.location.href='../../Common/WSaveTempFile.aspx?ModuleID=1&FileName=" & strFileName & "';return false;")
                lblResult.Visible = True
                lblCount.Visible = True
                lblCount.Text = intSum
            Else
                lblCount.Visible = False
                lblResult.Visible = False
                lblClick.Visible = False
                lnkLink.Visible = False
                lblLinkTail.Visible = False
                RegisterClientScriptBlock("SearchFail", "<script language='JavaScript'>alert('" & ddlLabel.Items(2).Text & "')</script>")
            End If

        End Sub


        ' Sub CreateBulkISORec
        ' Purpose: Export data to file ISO
        ' Input : 
        '           + ItemIDs: if ItemIDs='' then no ItemID
        '           + objF As StreamWriter: Object to write  
        '           + strFileName as string: Path
        ' Ouput : File ISO and Progetpar
        Sub CreateBulkISORec(ByVal ItemIDs As String, ByVal objF As StreamWriter, ByVal strFileName As String)
            ' Declare variables
            Dim intIndex As Integer
            ' intTotal is total records need to export
            Dim intTotal As Integer = 0
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
            Dim intSum As Integer = 0
            'Define some signs special
            strsi = "$"
            strft = "#"
            strrt = "#"

            ' Indicate parameters
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

            tblAuthorityDetailInFor = objBER.GetAuthorityDetailInfor
            tblAuthorityMainInFor = objBER.GetAuthorityMainInfor
            If Not tblAuthorityMainInFor Is Nothing Then
                If tblAuthorityMainInFor.Rows.Count > 0 Then
                    intTotal = tblAuthorityMainInFor.Rows.Count
                End If
            End If

            ' Define intTotal
            If Not chkExpAll.Checked Then
                If intTotal > Val(txtMaxExp.Text) And Val(txtMaxExp.Text) <> 0 Then
                    intTotal = Val(txtMaxExp.Text)
                End If
            End If

            intIndex = 1

            If intTotal > 0 Then
                intSum = 0
                Response.Write("<SPAN class='lbLabel' style='position:absolute;top:350;left: 20px'>")
                Response.Write(ddlLabel.Items(0).Text & "<span id='pgbMain_label'>0%</span><br>")
                Response.Write("<table width='0%' border=2 bordercolor='white' id='pgbMain' bgcolor=#669999><tr style='HEIGHT: 18px'><td></td></tr></table>")
                For intridx = 0 To intTotal - 1
                    intTotalLen = 26
                    intBaseAdd = 25
                    strDir = ""
                    strRecVal = ""

                    ' Item Code
                    If Not IsDBNull(tblAuthorityMainInFor.Rows(intridx).Item("Code")) Then
                        If Not tblAuthorityMainInFor.Rows(intridx).Item("Code").ToString.Trim = "" Then
                            strFVal = objBCSP.ToUTF8(tblAuthorityMainInFor.Rows(intridx).Item("Code").ToString.Trim)
                            intFlen = Len(strFVal) + 1
                            strDir = strDir & "001" & "0000".Substring(0, 4 - Len(CStr(intFlen))) & intFlen & "00000"
                            intBaseAdd = intBaseAdd + 12
                            strRecVal = strRecVal & strFVal & strft
                        End If
                    End If

                    ' TDate
                    If Not IsDBNull(tblAuthorityMainInFor.Rows(intridx).Item("TDATE")) Then
                        If Not tblAuthorityMainInFor.Rows(intridx).Item("TDATE").ToString.Trim = "" Then
                            strFVal = Year(tblAuthorityMainInFor.Rows(intridx).Item("TDATE").ToString.Trim) & "00".Substring(0, 2 - Month(tblAuthorityMainInFor.Rows(intridx).Item("TDATE")).ToString.Trim.Length) & Month(tblAuthorityMainInFor.Rows(intridx).Item("TDATE").ToString.Trim) & "00".Substring(0, 2 - Day(tblAuthorityMainInFor.Rows(intridx).Item("TDATE")).ToString.Trim.Length) & Day(tblAuthorityMainInFor.Rows(intridx).Item("TDATE").ToString.Trim) & "00".Substring(0, 2 - Hour(tblAuthorityMainInFor.Rows(intridx).Item("TDATE")).ToString.Trim.Length) & Hour(tblAuthorityMainInFor.Rows(intridx).Item("TDATE").ToString.Trim) & "00".Substring(0, 2 - Minute(tblAuthorityMainInFor.Rows(intridx).Item("TDATE")).ToString.Trim.Length) & Minute(tblAuthorityMainInFor.Rows(intridx).Item("TDATE").ToString.Trim) & "00".Substring(0, 2 - Second(tblAuthorityMainInFor.Rows(intridx).Item("TDATE")).ToString.Trim.Length) & Second(tblAuthorityMainInFor.Rows(intridx).Item("TDATE").ToString.Trim) & ".0"
                            intFlen = Len(strFVal) + 1
                            strDir = strDir & "005" & "0000".Substring(0, 4 - Len(CStr(intFlen))) & intFlen & "00000".Substring(0, 5 - Len(CStr(Len(strRecVal)))) & Len(strRecVal)
                            intBaseAdd = intBaseAdd + 12
                            strRecVal = strRecVal & strFVal & strft
                        End If
                    End If

                    If Not tblAuthorityDetailInFor Is Nothing Then
                        If tblAuthorityDetailInFor.Rows.Count > 0 Then
                            For intIndex = 0 To tblAuthorityDetailInFor.Rows.Count - 1
                                If Not CLng(tblAuthorityDetailInFor.Rows(intIndex).Item("AuthorityID")) = CLng(tblAuthorityMainInFor.Rows(intridx).Item("ID")) Then
                                    'Exit For
                                Else
                                    ' Indicators
                                    If Not IsDBNull(tblAuthorityDetailInFor.Rows(intIndex).Item("Indicators")) Or Not IsDBNull(tblAuthorityDetailInFor.Rows(intIndex).Item("VietIndicators")) Then
                                        If Not IsDBNull(tblAuthorityDetailInFor.Rows(intIndex).Item("Ind1")) AndAlso tblAuthorityDetailInFor.Rows(intIndex).Item("Ind1") <> "" Then
                                            strIndicators = tblAuthorityDetailInFor.Rows(intIndex).Item("Ind1").ToString.Trim
                                        Else
                                            strIndicators = " "
                                        End If
                                        If Not IsDBNull(tblAuthorityDetailInFor.Rows(intIndex).Item("Ind2")) AndAlso tblAuthorityDetailInFor.Rows(intIndex).Item("Ind2") <> "" Then
                                            strIndicators = strIndicators & tblAuthorityDetailInFor.Rows(intIndex).Item("Ind2").ToString.Trim
                                        Else
                                            strIndicators = strIndicators & " "
                                        End If
                                    End If
                                    'strFVal = objBCSP.ToUTF8(strIndicators & Replace(tblAuthorityDetailInFor.Rows(intIndex).Item("Content").ToString.Trim, "$", strsi))
                                    strFVal = strIndicators & objBCSP.ToUTF8(tblAuthorityDetailInFor.Rows(intIndex).Item("Content").ToString.Trim)
                                    intFlen = Len(strFVal) + 1
                                    strDir = strDir & tblAuthorityDetailInFor.Rows(intIndex).Item("FieldCode").ToString.Trim & "0000".Substring(0, 4 - Len(CStr(intFlen))) & intFlen & "00000".Substring(0, 5 - Len(CStr(Len(strRecVal)))) & Len(strRecVal)
                                    intBaseAdd = intBaseAdd + 12
                                    strRecVal = strRecVal & strFVal & strft
                                End If
                            Next
                        End If
                    End If

                    ' Cataloguer
                    If Not IsDBNull(tblAuthorityMainInFor.Rows(intridx).Item("Cataloguer")) Then
                        If Not tblAuthorityMainInFor.Rows(intridx).Item("Cataloguer").ToString.Trim = "" Then
                            strFVal = objBCSP.ToUTF8(tblAuthorityMainInFor.Rows(intridx).Item("Cataloguer").ToString.Trim)
                            intFlen = Len(strFVal) + 1
                            strDir = strDir & "911" & "0000".Substring(0, 4 - Len(CStr(intFlen))) & intFlen & "00000".Substring(0, 5 - Len(CStr(Len(strRecVal)))) & Len(strRecVal)
                            intBaseAdd = intBaseAdd + 12
                            strRecVal = strRecVal & strFVal & strft
                        End If
                    End If

                    ' Reviewer
                    If Not IsDBNull(tblAuthorityMainInFor.Rows(intridx).Item("Reviewer")) Then
                        If Not tblAuthorityMainInFor.Rows(intridx).Item("Reviewer").ToString.Trim = "" Then
                            strFVal = objBCSP.ToUTF8(tblAuthorityMainInFor.Rows(intridx).Item("Reviewer").ToString.Trim)
                            intFlen = Len(strFVal) + 1
                            strDir = strDir & "912" & "0000".Substring(0, 4 - Len(CStr(intFlen))) & intFlen & "00000".Substring(0, 5 - Len(CStr(Len(strRecVal)))) & Len(strRecVal)
                            intBaseAdd = intBaseAdd + 12
                            strRecVal = strRecVal & strFVal & strft
                        End If
                    End If

                    intTotalLen = intTotalLen + Len(strDir) + Len(strRecVal)
                    strLeader = "00000".Substring(0, 5 - Len(CStr(intTotalLen))) & intTotalLen & Mid(tblAuthorityMainInFor.Rows(intridx).Item("Leader").ToString.Trim, 6, 7) & "00000".Substring(0, 5 - Len(CStr(intBaseAdd))) & intBaseAdd & Right(tblAuthorityMainInFor.Rows(intridx).Item("Leader").ToString.Trim, 7)
                    strRecord = strLeader & strDir & strft & strRecVal & strrt
                    strRecwbr = ""
                    intStartRecord = 1

                    If intLineLen > 0 Then
                        While Len(strRecord) > 0
                            If Len(strRecord) > intLineLen Then
                                If intStartRecord = 1 Then
                                    strRecwbr = strRecwbr & Left(strRecord, intLineLen - intRemainLen) & Chr(13)
                                    strRecord = Right(strRecord, Len(strRecord) - intLineLen + intRemainLen)
                                    intStartRecord = 0
                                Else
                                    strRecwbr = strRecwbr & Left(strRecord, intLineLen) & Chr(13)
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
                Response.Write("</SPAN>")
                lblClick.Visible = True
                lnkLink.Visible = True
                lblLinkTail.Visible = True
                lnkLink.NavigateUrl = "#"
                lnkLink.Attributes.Add("onClick", "parent.Hiddenbase.location.href='../../Common/WSaveTempFile.aspx?ModuleID=1&FileName=" & strFileName & "';return false;")
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
                System.Threading.Thread.Sleep(500 / intSum)
                Response.Write("<script>if (pgbObj = document.getElementById('pgbMain')) pgbObj.width =" & intCurrentPercent & " + '%'; if (lblObj = document.getElementById('pgbMain_label')) lblObj.innerHTML =" & intCurrentPercent & " + '%';</script>")
                Response.Flush()
            End If
        End Sub

        ' btnExport_Click
        Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
            Dim tblTemp As DataTable
            Dim tblAuthorID As DataTable
            Dim intFromID As Integer = 0
            Dim intToID As Integer = 0

            ' Search the Authority data
            objBER.Term = txtTerm.Text
            objBER.ReferenceID = ddlReference.SelectedValue
            If Not ddlSourceID Is Nothing AndAlso ddlSourceID.Items.Count > 0 Then
                objBER.SourceID = ddlSourceID.SelectedValue
            Else
                objBER.SourceID = 0
            End If

            objBER.CataFrom = txtCataFrom.Text
            objBER.CataTo = txtCataTo.Text
            If txtIDFrom.Text <> "" Then
                intFromID = CInt(txtIDFrom.Text)
            End If
            ' Get the authority ID (From) by Top Number
            'If Not txtIDFrom.Text = "" Then
            '    If Not tblAuthorID Is Nothing Then
            '        If tblAuthorID.Rows.Count > 0 Then
            '            objBIC.IsAuthority = 1
            '            objBIC.TopNum = CInt(Trim(txtIDFrom.Text))
            '            tblAuthorID = objBIC.GetIDByTopNum()
            '            intFromID = CInt(tblAuthorID.Rows(0).Item(0))
            '        End If
            '    End If
            'End If

            objBER.FromID = intFromID

            ' Get the authority ID (To) by Top Number
            'If Not Trim(txtIDTo.Text) = "" Then
            '    objBIC.IsAuthority = 1
            '    objBIC.TopNum = CInt(Trim(txtIDTo.Text))
            '    tblAuthorID = objBIC.GetIDByTopNum()
            '    If Not tblAuthorID Is Nothing Then
            '        If tblAuthorID.Rows.Count > 0 Then
            '            intToID = CInt(tblAuthorID.Rows(0).Item(0))
            '        End If
            '    End If
            'End If
            If txtIDTo.Text <> "" Then
                intToID = CInt(txtIDTo.Text)
            End If

            objBER.ToID = intToID

            tblTemp = objBCDBS.GetTempFilePath(1)
            strPath = ""
            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    strPath = Server.MapPath("../..") & tblTemp.Rows(0).Item("TempFilePath")
                End If
            End If

            objBCDBS.Extension = "ISO"
            strFileName = objBCDBS.GenRandomFile
            strPath = strPath & "/" & strFileName
            Dim ObjOut = New StreamWriter(strPath, True)
            If CInt(ddlFormat.SelectedValue) = 1 Then
                Call CreateBulkISORec("strItemIDs", ObjOut, strFileName)
            Else
                Call CreateBulkMARCRec("strItemIDs", ObjOut, strFileName)
            End If
            If Not IsNothing(ObjOut) Then
                ObjOut.Close()
            End If
        End Sub

        ' Dispose method
        ' Purpose: Release the methods
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBIC Is Nothing Then
                    objBIC.Dispose(True)
                    objBIC = Nothing
                End If
                If Not objBER Is Nothing Then
                    objBER.Dispose(True)
                    objBER = Nothing
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