Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.ILL
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.BusinessRules.Serial

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WIRSetItemLocation
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
        Private objBILLInRequest As New clsBILLInRequest
        Private objBItemCollection As New clsBItemCollection
        Private objBFormingSQL As New clsBFormingSQL
        Private objBPeriodical As New clsBPeriodical
        Private objBCDBS As New clsBCommonDBSystem

        Private intItemType As Integer = 0
        Private tblItem As DataTable

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindData()
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBILLInRequest object 
            objBILLInRequest.ConnectionString = Session("ConnectionString")
            objBILLInRequest.DBServer = Session("DBServer")
            objBILLInRequest.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBILLInRequest.Initialize()

            ' Init objBItemCollection object 
            objBItemCollection.ConnectionString = Session("ConnectionString")
            objBItemCollection.DBServer = Session("DBServer")
            objBItemCollection.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBItemCollection.Initialize()

            ' Init objBCDBS object
            objBCDBS.ConnectionString = Session("ConnectionString")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.Initialize()

            ' Init objBPeriodical object
            objBPeriodical.ConnectionString = Session("ConnectionString")
            objBPeriodical.DBServer = Session("DBServer")
            objBPeriodical.InterfaceLanguage = Session("InterfaceLanguage")
            objBPeriodical.Initialize()

            ' Init objBFormingSQL object
            objBFormingSQL.ConnectionString = Session("ConnectionString")
            objBFormingSQL.DBServer = Session("DBServer")
            objBFormingSQL.InterfaceLanguage = Session("InterfaceLanguage")
            objBFormingSQL.Initialize()
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(153) Then
                Page.RegisterClientScriptBlock("AccessDeniedJS", "<script language = 'javascript'>alert('" & ddlLabel.Items(2).Text & "');self.close();</script>")
                Response.End()
            End If
        End Sub

        ' BindData method
        Private Sub BindData()
            ' Declare variables
            Dim tblRequest As DataTable
            Dim intItemID As Integer = 0
            ' Get the request details 
            If IsNumeric(Request("ILLID")) Then
                objBILLInRequest.ILLID = CInt(Request("ILLID"))
                tblRequest = objBILLInRequest.GetIRItem
                ' Write Error
                Call WriteErrorMssg(ddlLabelNote.Items(0).Text, objBILLInRequest.ErrorMsg, ddlLabelNote.Items(1).Text, objBILLInRequest.ErrorCode)

                If Not tblRequest Is Nothing Then
                    If tblRequest.Rows.Count > 0 Then
                        lblContent.Text = ""
                        If Not IsDBNull(tblRequest.Rows(0).Item("Title")) Then
                            lblContent.Text = lblContent.Text & "<TR><TD ALIGN=""right"" WIDTH=80>"
                            lblContent.Text = lblContent.Text & "<INPUT TYPE=""checkbox"" NAME=""Fields"" VALUE=""Title""></TD><TD>"
                            lblContent.Text = lblContent.Text & "<span class=""lbLabel"">" & "<span class=""lbLabel"">" & ddlLabel.Items(0).Text & ":</span></TD><TD><INPUT TYPE=""TEXT"" class=""lbTextBox"" NAME=""Title"" VALUE="""
                            lblContent.Text = lblContent.Text & Replace(tblRequest.Rows(0).Item("Title"), """", "&quot;") & """ SIZE=35></TD></TR>"
                        End If
                        If Not IsDBNull(tblRequest.Rows(0).Item("Edition")) Then
                            lblContent.Text = lblContent.Text & "<TR><TD><TD>"
                            lblContent.Text = lblContent.Text & "<span class=""lbLabel"">" & "<span class=""lbLabel"">" & ddlLabel.Items(1).Text & ":</span></TD><TD><B>"
                            lblContent.Text = lblContent.Text & "<span class=""lbLabel"">" & Replace(tblRequest.Rows(0).Item("Edition"), """", "&quot;") & "</span></TD></TR>"
                        End If
                        If Not IsDBNull(tblRequest.Rows(0).Item("Author")) Then
                            lblContent.Text = lblContent.Text & "<TR><TD ALIGN=""right"" WIDTH=80>"
                            lblContent.Text = lblContent.Text & "<INPUT TYPE=""checkbox"" NAME=""Fields"" VALUE=""Author""></TD><TD>"
                            lblContent.Text = lblContent.Text & "<span class=""lbLabel"">" & ddlLabel.Items(2).Text & ":</span></TD><TD><INPUT TYPE=""TEXT"" class=""lbTextBox"" NAME=""Author"" VALUE="""
                            lblContent.Text = lblContent.Text & Replace(tblRequest.Rows(0).Item("Author"), """", "&quot;") & """ SIZE=35></TD></TR>"
                        End If
                        If Not IsDBNull(tblRequest.Rows(0).Item("SponsoringBody")) Then
                            lblContent.Text = lblContent.Text & "<TR><TD><TD>"
                            lblContent.Text = lblContent.Text & "<span class=""lbLabel"">" & ddlLabel.Items(3).Text & ":</span></TD><TD><B>"
                            lblContent.Text = lblContent.Text & "<span class=""lbLabel"">" & Replace(tblRequest.Rows(0).Item("SponsoringBody"), """", "&quot;") & "</span></TD></TR>"
                        End If
                        If Not IsDBNull(tblRequest.Rows(0).Item("PlaceOfPub")) Then
                            lblContent.Text = lblContent.Text & "<TR><TD><TD>"
                            lblContent.Text = lblContent.Text & "<span class=""lbLabel"">" & ddlLabel.Items(4).Text & ":</span></TD><TD><B>"
                            lblContent.Text = lblContent.Text & "<span class=""lbLabel"">" & Replace(tblRequest.Rows(0).Item("PlaceOfPub"), """", "&quot;") & "</span></TD></TR>"
                        End If
                        If Not IsDBNull(tblRequest.Rows(0).Item("Publisher")) Then
                            lblContent.Text = lblContent.Text & "<TR><TD ALIGN=""right"" WIDTH=80>"
                            lblContent.Text = lblContent.Text & "<INPUT TYPE=""checkbox"" NAME=""Fields"" VALUE=""Publisher""></TD><TD>"
                            lblContent.Text = lblContent.Text & "<span class=""lbLabel"">" & ddlLabel.Items(5).Text & ":</span></TD><TD><INPUT TYPE=""TEXT"" class=""lbTextBox"" NAME=""Publisher"" VALUE="""
                            lblContent.Text = lblContent.Text & Replace(tblRequest.Rows(0).Item("Publisher"), """", "&quot;") & """ SIZE=35></TD></TR>"
                        End If
                        If Not IsDBNull(tblRequest.Rows(0).Item("PUBDATE")) Then
                            lblContent.Text = lblContent.Text & "<TR><TD ALIGN=""right"" WIDTH=80>"
                            lblContent.Text = lblContent.Text & "<INPUT TYPE=""checkbox"" NAME=""Fields"" VALUE=""PUBDATE""></TD><TD>"
                            lblContent.Text = lblContent.Text & "<span class=""lbLabel"">" & ddlLabel.Items(6).Text & ":</span></TD><TD><INPUT TYPE=""TEXT"" class=""lbTextBox"" NAME=""PUBDATE"" VALUE="""
                            lblContent.Text = lblContent.Text & Replace(Right(Trim(tblRequest.Rows(0).Item("PUBDATE")), 4), """", "&quot;") & """ SIZE=35></TD></TR>"
                        End If
                        If Not IsDBNull(tblRequest.Rows(0).Item("SystemNumber")) Then
                            lblContent.Text = lblContent.Text & "<TR><TD ALIGN=""right"" WIDTH=80>"
                            lblContent.Text = lblContent.Text & "<INPUT TYPE=""checkbox"" NAME=""Fields"" VALUE=""SystemNumber""></TD><TD>"
                            lblContent.Text = lblContent.Text & "<span class=""lbLabel"">" & ddlLabel.Items(7).Text & ":</span></TD><TD><INPUT TYPE=""TEXT"" class=""lbTextBox"" NAME=""SystemNumber"" VALUE="""
                            lblContent.Text = lblContent.Text & Replace(tblRequest.Rows(0).Item("SystemNumber"), """", "&quot;") & """ SIZE=35></TD></TR>"
                        End If

                        If Not IsDBNull(tblRequest.Rows(0).Item("ArticleTitle")) Then
                            lblContent.Text = lblContent.Text & "<TR><TD ALIGN=""right"" WIDTH=80>"
                            lblContent.Text = lblContent.Text & "<INPUT TYPE=""checkbox"" NAME=""Fields"" VALUE=""ArticleTitle""></TD><TD>"
                            lblContent.Text = lblContent.Text & "<span class=""lbLabel"">" & ddlLabel.Items(8).Text & ":</span></TD><TD><INPUT TYPE=""TEXT"" class=""lbTextBox"" NAME=""ArticleTitle"" VALUE="""
                            lblContent.Text = lblContent.Text & Replace(tblRequest.Rows(0).Item("ArticleTitle"), """", "&quot;") & """ SIZE=35></TD></TR>"
                        End If
                        If Not IsDBNull(tblRequest.Rows(0).Item("ArticleAuthor")) Then
                            lblContent.Text = lblContent.Text & "<TR><TD ALIGN=""right"" WIDTH=80>"
                            lblContent.Text = lblContent.Text & "<INPUT TYPE=""checkbox"" NAME=""Fields"" VALUE=""ArticleAuthor""></TD><TD>"
                            lblContent.Text = lblContent.Text & "<span class=""lbLabel"">" & ddlLabel.Items(9).Text & ":</span></TD><TD><INPUT TYPE=""TEXT"" class=""lbTextBox"" NAME=""ArticleAuthor"" VALUE="""
                            lblContent.Text = lblContent.Text & Replace(tblRequest.Rows(0).Item("ArticleAuthor"), """", "&quot;") & """ SIZE=35></TD></TR>"
                        End If
                        If Not IsDBNull(tblRequest.Rows(0).Item("VolumeIssue")) Then
                            lblContent.Text = lblContent.Text & "<TR><TD ALIGN=""right"" WIDTH=80>"
                            lblContent.Text = lblContent.Text & "<INPUT TYPE=""checkbox"" NAME=""Fields"" VALUE=""VolumeIssue""></TD><TD>"
                            lblContent.Text = lblContent.Text & "<span class=""lbLabel"">" & ddlLabel.Items(10).Text & ":</span></TD><TD><INPUT TYPE=""TEXT"" class=""lbTextBox"" NAME=""VolumeIssue"" VALUE="""
                            lblContent.Text = lblContent.Text & Replace(tblRequest.Rows(0).Item("VolumeIssue"), """", "&quot;") & """ SIZE=35></TD></TR>"
                        End If
                        If Not IsDBNull(tblRequest.Rows(0).Item("COMPONENTPUBDATE")) Then
                            lblContent.Text = lblContent.Text & "<TR><TD><TD>"
                            lblContent.Text = lblContent.Text & "<span class=""lbLabel"">" & ddlLabel.Items(11).Text & ":</span></TD><TD><B>"
                            lblContent.Text = lblContent.Text & "<span class=""lbLabel"">" & Replace(tblRequest.Rows(0).Item("COMPONENTPUBDATE"), """", "&quot;") & "</span></TD></TR>"
                        End If
                        If Not IsDBNull(tblRequest.Rows(0).Item("Pagination")) Then
                            lblContent.Text = lblContent.Text & "<TR><TD><TD>"
                            lblContent.Text = lblContent.Text & "<span class=""lbLabel"">" & ddlLabel.Items(12).Text & ":</span></TD><TD><B>"
                            lblContent.Text = lblContent.Text & Replace(tblRequest.Rows(0).Item("Pagination"), """", "&quot;") & "</TD></TR>"
                        End If
                        If Not IsDBNull(tblRequest.Rows(0).Item("CallNumber")) Then
                            lblContent.Text = lblContent.Text & "<TR><TD ALIGN=""right"" WIDTH=80>"
                            lblContent.Text = lblContent.Text & "<INPUT TYPE=""checkbox"" NAME=""Fields"" VALUE=""CallNumber""></TD><TD>"
                            lblContent.Text = lblContent.Text & "<span class=""lbLabel"">" & ddlLabel.Items(13).Text & ":</span></TD><TD><INPUT TYPE=""TEXT"" class=""lbTextBox"" NAME=""CallNumber"" VALUE="""
                            lblContent.Text = lblContent.Text & Replace(tblRequest.Rows(0).Item("CallNumber"), """", "&quot;") & """ SIZE=35></TD></TR>"
                        End If
                        If Not IsDBNull(tblRequest.Rows(0).Item("ISBN")) Then
                            lblContent.Text = lblContent.Text & "<TR><TD ALIGN=""right"" WIDTH=80>"
                            lblContent.Text = lblContent.Text & "<INPUT TYPE=""checkbox"" NAME=""Fields"" VALUE=""ISBN""></TD><TD>"
                            lblContent.Text = lblContent.Text & "<span class=""lbLabel"">" & ddlLabel.Items(14).Text & ":</span></TD><TD><INPUT TYPE=""TEXT"" class=""lbTextBox"" NAME=""ISBN"" VALUE="""
                            lblContent.Text = lblContent.Text & Replace(tblRequest.Rows(0).Item("ISBN"), """", "&quot;") & """ SIZE=35></TD></TR>"
                        End If
                        If Not IsDBNull(tblRequest.Rows(0).Item("ISSN")) Then
                            lblContent.Text = lblContent.Text & "<TR><TD ALIGN=""right"" WIDTH=80>"
                            lblContent.Text = lblContent.Text & "<INPUT TYPE=""checkbox"" NAME=""Fields"" VALUE=""ISSN""></TD><TD>"
                            lblContent.Text = lblContent.Text & "<span class=""lbLabel"">" & ddlLabel.Items(15).Text & ":</span></TD><TD><INPUT TYPE=""TEXT"" class=""lbTextBox"" NAME=""ISSN"" VALUE="""
                            lblContent.Text = lblContent.Text & Replace(tblRequest.Rows(0).Item("ISSN"), """", "&quot;") & """ SIZE=35></TD></TR>"
                        End If
                        If Not IsDBNull(tblRequest.Rows(0).Item("NationalBibNumber")) Then
                            lblContent.Text = lblContent.Text & "<TR><TD><TD>"
                            lblContent.Text = lblContent.Text & "<span class=""lbLabel"">" & ddlLabel.Items(16).Text & ":</span></TD><TD><B>"
                            lblContent.Text = lblContent.Text & "<span class=""lbLabel"">" & Replace(tblRequest.Rows(0).Item("NationalBibNumber"), """", "&quot;") & "</span></TD></TR>"
                        End If
                        If Not IsDBNull(tblRequest.Rows(0).Item("SeriesTitleNumber")) Then
                            lblContent.Text = lblContent.Text & "<TR><TD><TD>"
                            lblContent.Text = lblContent.Text & "<span class=""lbLabel"">" & ddlLabel.Items(17).Text & ":</span></TD><TD><B>"
                            lblContent.Text = lblContent.Text & Replace(tblRequest.Rows(0).Item("SeriesTitleNumber"), """", "&quot;") & "</TD></TR>"
                        End If
                        If Not IsDBNull(tblRequest.Rows(0).Item("OtherNumbers")) Then
                            lblContent.Text = lblContent.Text & "<TR><TD ALIGN=""right"" WIDTH=80>"
                            lblContent.Text = lblContent.Text & "<INPUT TYPE=""checkbox"" NAME=""Fields"" VALUE=""OtherNumbers""></TD><TD>"
                            lblContent.Text = lblContent.Text & "<span class=""lbLabel"">" & ddlLabel.Items(18).Text & ":</span></TD><TD><INPUT TYPE=""TEXT"" class=""lbTextBox"" NAME=""OtherNumbers"" VALUE="""
                            lblContent.Text = lblContent.Text & Replace(tblRequest.Rows(0).Item("OtherNumbers"), """", "&quot;") & """ SIZE=35></TD></TR>"
                        End If
                        If Not IsDBNull(tblRequest.Rows(0).Item("Verification")) Then
                            lblContent.Text = lblContent.Text & "<TR><TD ALIGN=""right"" WIDTH=80>"
                            lblContent.Text = lblContent.Text & "<INPUT TYPE=""checkbox"" NAME=""Fields"" VALUE=""Verification""></TD><TD>"
                            lblContent.Text = lblContent.Text & "<span class=""lbLabel"">" & "<span class=""lbLabel"">" & ddlLabel.Items(19).Text & ":</span></TD><TD><INPUT TYPE=""TEXT"" class=""lbTextBox"" NAME=""Verification"" VALUE="""
                            lblContent.Text = lblContent.Text & Replace(tblRequest.Rows(0).Item("Verification"), """", "&quot;") & """ SIZE=35></TD></TR>"
                        End If
                        If Not IsDBNull(tblRequest.Rows(0).Item("ItemType")) Then
                            If CInt(tblRequest.Rows(0).Item("ItemType")) = 2 Then
                                chkPerIssue.Visible = True
                                intItemType = 2
                            Else
                                chkPerIssue.Visible = False
                            End If
                            If CInt(tblRequest.Rows(0).Item("ItemType")) = 9 Then
                                intItemType = 9
                            End If
                        End If
                    End If
                End If
            End If
        End Sub

        ' Search method
        Private Sub Search()
            ' Array variables
            Dim BoolArr()
            Dim FieldArr()
            Dim ValArr()
            Dim intk As Integer = 0
            Dim strTitle As String = ""
            Dim strAuthor As String = ""
            Dim strPublisher As String = ""
            Dim strPubDate As String = ""
            Dim strSystemNumber As String = ""
            Dim strISBN As String = ""
            Dim strISSN As String = ""
            Dim strItemType As String = ""
            Dim strFormedSql As String = ""

            If Trim(Request("Fields") <> "") Then
                ' Title
                If InStr(", " & Request("Fields") & ",", ", ArticleTitle,") > 0 Then
                    strTitle = Trim(Request("ArticleTitle"))
                ElseIf InStr(", " & Request("Fields") & ",", ", Title,") > 0 Then
                    strTitle = Trim(Request("Title"))
                Else
                    strTitle = ""
                End If

                If Not Trim(strTitle) = "" Then
                    ReDim Preserve BoolArr(intk)
                    ReDim Preserve FieldArr(intk)
                    ReDim Preserve ValArr(intk)
                    BoolArr(intk) = "AND"
                    FieldArr(intk) = "TI"
                    ValArr(intk) = strTitle
                    intk = intk + 1
                End If

                ' Author
                If InStr(", " & Request("Fields") & ",", ", ArticleAuthor,") > 0 Then
                    strAuthor = Trim(Request("ArticleAuthor"))
                ElseIf InStr(", " & Request("Fields") & ",", ", Author,") > 0 Then
                    strAuthor = Trim(Request("Author"))
                Else
                    strAuthor = ""
                End If

                If Not Trim(strAuthor) = "" Then
                    ReDim Preserve BoolArr(intk)
                    ReDim Preserve FieldArr(intk)
                    ReDim Preserve ValArr(intk)
                    BoolArr(intk) = "AND"
                    FieldArr(intk) = "1"
                    ValArr(intk) = strAuthor
                    intk = intk + 1
                End If

                ' Publisher
                If InStr(", " & Request("Fields") & ",", ", Publisher,") > 0 Then
                    strPublisher = Trim(Request("Publisher"))
                    ReDim Preserve BoolArr(intk)
                    ReDim Preserve FieldArr(intk)
                    ReDim Preserve ValArr(intk)
                    BoolArr(intk) = "AND"
                    FieldArr(intk) = "1"
                    ValArr(intk) = strPublisher
                    intk = intk + 1
                End If

                ' PubDate
                If InStr(", " & Request("Fields") & ",", ", PUBDATE,") > 0 Then
                    strPubDate = Trim((Request("PUBDATE")))
                    ReDim Preserve BoolArr(intk)
                    ReDim Preserve FieldArr(intk)
                    ReDim Preserve ValArr(intk)
                    BoolArr(intk) = "AND"
                    FieldArr(intk) = "YR"
                    ValArr(intk) = strPubDate
                    intk = intk + 1
                End If

                ' SystemNumber
                If InStr(", " & Request("Fields") & ",", ", SystemNumber,") > 0 Then
                    strSystemNumber = Trim(Request("SystemNumber"))
                    ReDim Preserve BoolArr(intk)
                    ReDim Preserve FieldArr(intk)
                    ReDim Preserve ValArr(intk)
                    BoolArr(intk) = "AND"
                    FieldArr(intk) = "BI"
                    ValArr(intk) = strSystemNumber
                    intk = intk + 1
                End If

                ' ISBN
                If InStr(", " & Request("Fields") & ",", ", ISBN,") > 0 Then
                    strISBN = Trim(Request("ISBN"))
                    ReDim Preserve BoolArr(intk)
                    ReDim Preserve FieldArr(intk)
                    ReDim Preserve ValArr(intk)
                    BoolArr(intk) = "AND"
                    FieldArr(intk) = "IB"
                    ValArr(intk) = strISBN
                    intk = intk + 1
                End If

                ' ISSN
                If InStr(", " & Request("Fields") & ",", ", ISSN,") > 0 Then
                    strISSN = Trim(Request("ISSN"))
                    ReDim Preserve BoolArr(intk)
                    ReDim Preserve FieldArr(intk)
                    ReDim Preserve ValArr(intk)
                    BoolArr(intk) = "AND"
                    FieldArr(intk) = "IS"
                    ValArr(intk) = strISSN
                    intk = intk + 1
                End If

                ' ItemType
                If InStr(", " & Request("Fields") & ",", ", ArticleTitle,") > 0 Or InStr(", " & Request("Fields") & ",", ", ArticleAuthor,") > 0 Then
                    strItemType = "BB"
                End If

                If Not strItemType = "" Then
                    ReDim Preserve BoolArr(intk)
                    ReDim Preserve FieldArr(intk)
                    ReDim Preserve ValArr(intk)
                    BoolArr(intk) = "AND"
                    FieldArr(intk) = "IT"
                    ValArr(intk) = strItemType
                    intk = intk + 1
                End If

                ' Forming SQL
                objBFormingSQL.BoolArr = BoolArr
                objBFormingSQL.FieldArr = FieldArr
                objBFormingSQL.ValArr = ValArr

                If Not BoolArr Is Nothing And Not FieldArr Is Nothing And Not ValArr Is Nothing Then
                    strFormedSql = objBFormingSQL.FormingASQL(100)
                    ' Write Error
                    Call WriteErrorMssg(ddlLabelNote.Items(0).Text, objBFormingSQL.ErrorMsg, ddlLabelNote.Items(1).Text, objBFormingSQL.ErrorCode)
                End If

                If intItemType <> 9 Then
                    If strFormedSql <> "" Then
                        objBCDBS.SQLStatement = strFormedSql
                        tblItem = objBCDBS.RetrieveItemInfor
                    End If
                Else
                    Dim strSQL As String
                    If strFormedSql <> "" Then
                        strSQL = "select ItemID as ID, IssueNo, OvIssueNo, IssuedDate, " & _
                                                               "VolumeByPublisher, Series, SpecialTitle FROM Ser_tblIssue where ItemID IN(" & _
                                                               strFormedSql & ")"
                        If Not Request("VolumeIssue") = "" And InStr(", " & Request("Fields") & ",", ", VolumeIssue,") > 0 Then
                            strSQL = strSQL & " AND IssueNo = '" & Request("VolumeIssue") & "'"
                        End If
                    End If

                    If strSQL <> "" Then
                        objBCDBS.SQLStatement = strSQL
                        tblItem = objBCDBS.RetrieveItemInfor
                    End If
                End If

                If Not tblItem Is Nothing Then
                    If tblItem.Rows.Count > 0 Then
                        dgtItem.Visible = True
                        dgtItem.DataSource = tblItem
                        dgtItem.DataBind()
                        Call CreateContent()
                    Else
                        dgtItem.Visible = False
                        Page.RegisterClientScriptBlock("NotFound", "<script language='javascript'>alert('" & ddlLabel.Items(26).Text & "');</script>")
                    End If
                Else
                    dgtItem.Visible = False
                    Page.RegisterClientScriptBlock("NotFound", "<script language='javascript'>alert('" & ddlLabel.Items(26).Text & "');</script>")
                End If
            End If
        End Sub

        ' dgtItem_PageIndexChanged event
        Private Sub dgtItem_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgtItem.PageIndexChanged
            dgtItem.CurrentPageIndex = e.NewPageIndex
        End Sub

        'CreateContent
        Private Sub CreateContent()
            ' Declare variables
            Dim dtgItem As DataGridItem
            Dim lblStatus As Label
            Dim lblDes As Label
            Dim lblID As Label
            Dim lnkSelect As HyperLink
            Dim strID As String
            Dim intIndex As Integer = 0

            Dim tblTemp As DataTable
            Dim tblSum As DataTable

            Dim strServiceType As String
            Dim strPriority As String
            Dim strHistory As String
            Dim lngRequestID As Long

            For Each dtgItem In dgtItem.Items
                strID = CStr(CType(dtgItem.FindControl("lblItemID"), Label).Text)

                lblID = dtgItem.FindControl("lblItemID")
                lblStatus = dtgItem.FindControl("lblStatus")
                lblDes = dtgItem.FindControl("lblDescription")
                lnkSelect = dtgItem.FindControl("lnkSelect")

                objBItemCollection.ItemID = CLng(strID)
                objBItemCollection.ItemIDs = CStr(strID)
                lblDes.Text = objBItemCollection.CreateISBDRec
                ' Write Error
                Call WriteErrorMssg(ddlLabelNote.Items(0).Text, objBItemCollection.ErrorMsg, ddlLabelNote.Items(1).Text, objBItemCollection.ErrorCode)

                tblTemp = objBItemCollection.GetFreeItemNum
                ' Write Error
                Call WriteErrorMssg(ddlLabelNote.Items(0).Text, objBItemCollection.ErrorMsg, ddlLabelNote.Items(1).Text, objBItemCollection.ErrorCode)

                If intItemType = 2 And chkPerIssue.Checked Then
                    objBPeriodical.ItemID = CLng(strID)
                    tblSum = objBPeriodical.GetSummaryHolding

                    ' Write Error
                    Call WriteErrorMssg(ddlLabelNote.Items(0).Text, objBPeriodical.ErrorMsg, ddlLabelNote.Items(1).Text, objBPeriodical.ErrorCode)

                    If Not tblSum Is Nothing Then
                        If tblSum.Rows.Count > 0 Then
                            lblDes.Text = lblDes.Text & "<BR>" & tblSum.Rows(0).Item("SummaryHolding")
                        End If
                    End If
                End If

                If intItemType = 9 Then
                    If Not IsDBNull(tblItem.Rows(intIndex).Item("SpecialTitle")) Then
                        lblDes.Text = lblDes.Text & tblItem.Rows(intIndex).Item("SpecialTitle") & "."
                    End If
                    If Not IsDBNull(tblItem.Rows(intIndex).Item("IssueNo")) Then
                        lblDes.Text = lblDes.Text & " " & tblItem.Rows(dtgItem.ItemIndex).Item("IssueNo")
                    End If
                    If Not IsDBNull(tblItem.Rows(intIndex).Item("OvIssueNo")) Then
                        lblDes.Text = lblDes.Text & "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")"
                    End If
                    If Not IsDBNull(tblItem.Rows(intIndex).Item("VolumeByPublisher")) Then
                        lblDes.Text = lblDes.Text & ", " & tblItem.Rows(intIndex).Item("VolumeByPublisher")
                    End If
                    If Not IsDBNull(tblItem.Rows(intIndex).Item("ISSUEDDATE")) Then
                        lblDes.Text = lblDes.Text & ", " & tblItem.Rows(intIndex).Item("ISSUEDDATE")
                    End If
                    If Not IsDBNull(tblItem.Rows(intIndex).Item("IssueNo")) Then
                        lnkSelect.NavigateUrl = "javascript:opener.top.main.Hiddenbase.location.href='WSetItemResult.aspx?ILLID=" & Request("ILLID") & "&ItemID=" & strID & "&IssueID=" & tblItem.Rows(dtgItem.ItemIndex).Item("IssueNo") & "';self.close();"
                    End If
                Else
                    lnkSelect.NavigateUrl = "javascript:opener.top.main.Hiddenbase.location.href='WSetItemResult.aspx?ILLID=" & Request("ILLID") & "&ItemID=" & strID & "';self.close();"
                End If

                If Not tblTemp Is Nothing Then
                    If tblTemp.Rows.Count > 0 Then
                        If CInt(tblTemp.Rows(0).Item("NOR")) = 0 Then
                            lblStatus.Text = "<B>" & ddlLabel.Items(22).Text & "</B>"
                        Else
                            lblStatus.Text = "<B><font color=""990000"">" & ddlLabel.Items(21).Text & "</font></B>"
                        End If
                    End If
                End If
                intIndex = intIndex + 1
            Next
        End Sub

        ' btnSearch_Click event
        Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            Call Search()
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBILLInRequest Is Nothing Then
                    objBILLInRequest.Dispose(True)
                    objBILLInRequest = Nothing
                End If

                If Not objBItemCollection Is Nothing Then
                    objBItemCollection.Dispose(True)
                    objBItemCollection = Nothing
                End If

                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBPeriodical Is Nothing Then
                    objBPeriodical.Dispose(True)
                    objBPeriodical = Nothing
                End If
                If Not objBFormingSQL Is Nothing Then
                    objBFormingSQL.Dispose(True)
                    objBFormingSQL = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace