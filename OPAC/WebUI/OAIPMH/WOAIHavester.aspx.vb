' purpose : Show detail one record
' Create Date 22/10/2004
' Creator : Vantd

Imports eMicLibOPAC.BusinessRules.OPAC

Namespace eMicLibOPAC.WebUI.OPAC
    Partial Class WOAIHavester
        Inherits clsWBase
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents tblIdentify As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents Table1 As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents tblListIdentifiers As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox
        Protected WithEvents ListBox1 As System.Web.UI.WebControls.ListBox
        Protected WithEvents HyperLink3 As System.Web.UI.WebControls.HyperLink
        Protected WithEvents HyperLink4 As System.Web.UI.WebControls.HyperLink
        Protected WithEvents HyperLink5 As System.Web.UI.WebControls.HyperLink
        Protected WithEvents HyperLink6 As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lnkListMetadata As System.Web.UI.WebControls.HyperLink
        Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
        Protected WithEvents lblcontentval As System.Web.UI.WebControls.Label
        Protected WithEvents lngListRecord As System.Web.UI.WebControls.Label

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private objBOAIHavester As New clsBOAIHavester
        Private dsOAI As New DataSet

        ' Event : Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
            Call ShowResult()
        End Sub

        'Purpose: show information Request
        'Creator : Vantd
        Private Sub ShowInforRequest(ByVal dsData As DataSet)
            lblHead.Visible = False
            lblHeadDes.Visible = False
            If optXML.Checked = False Then
                txtShowInforReq.Value = 1
            End If
            lblURLH.Visible = True
            lblVerbH.Visible = True
            lblReponseH.Visible = True
            lblResponseVal.Visible = True
            lblURLReVal.Visible = True
            lblVerbVal.Visible = True
            lblHeadResult.Visible = True
            lblVerbVal.Text = txtVerb.Value
            lblURLReVal.Text = txtURLReSource.Text
            If dsData.Tables.Count > 0 Then
                lblResponseVal.Text = dsData.Tables(0).Rows(0).Item(0)
            End If
            If dsData.Tables.IndexOf("error") <> -1 Then
                txtError.Value = 1
                lblErrorCodeval.Text = dsData.Tables("error").Rows(0).Item("code")
                lblErrorDetailVal.Text = dsData.Tables("error").Rows(0).Item("error_Text")
            Else
                txtError.Value = 0
            End If
        End Sub

        'Purpose: show result OAIConnect with verbs
        'Creator : Vantd
        Private Sub ShowResult()
            Dim strVerb As String
            Dim dsTmp As New DataSet
            Dim strXMLError As String

            strVerb = txtVerb.Value
            objBOAIHavester.URLResource = txtURLReSource.Text
            objBOAIHavester.Verb = strVerb
            objBOAIHavester.Identifier = txtidentifier.Text
            If txtmetadataPrefix.Text = "" Then
                objBOAIHavester.MetadataPrefix = "oai_dc"
            Else
                objBOAIHavester.MetadataPrefix = txtmetadataPrefix.Text
            End If
            objBOAIHavester.FromDate = txtfrom.Text
            objBOAIHavester.ToDate = txtUntil.Text
            objBOAIHavester.OAISet = txtSET.Text
            objBOAIHavester.ResumptionToken = txtresumptionToken.Text
            dsTmp = objBOAIHavester.ReadXMLRecords
            strXMLError = DumpXML(objBOAIHavester.XMLReturn)
            dtgListMetadataFormats.Visible = False
            dtgListIdentifiers.Visible = False
            txtRecordDetail.Value = 0
            dtgListSets.Visible = False
            lblHead.Visible = True
            lblHeadDes.Visible = True
            txtShowInforReq.Value = 0
            lblURLH.Visible = False
            lblVerbH.Visible = False
            lblReponseH.Visible = False
            lblResponseVal.Visible = False
            lblURLReVal.Visible = False
            lblVerbVal.Visible = False
            lblHeadResult.Visible = False

            txtError.Value = 0
            Try
                If strVerb <> "" Then
                    Call ShowInforRequest(dsTmp)
                End If
                If dsTmp.Tables.IndexOf("error") <> -1 Then
                    Exit Sub
                End If
                If optParse.Checked Then
                    lblXML.Visible = False
                    Select Case strVerb
                        Case "Identify"
                            Call GetInIdentify(dsTmp, strXMLError)
                        Case "ListIdentifiers"
                            Call GetListIdentifiers(dsTmp, strXMLError)
                        Case "ListRecords"
                            Call GetListRecords(dsTmp, strXMLError)
                        Case "GetRecord"
                            Call GetRecords(dsTmp, strXMLError)
                        Case "ListMetadataFormats"
                            Call GetListMetadataFormats(dsTmp, strXMLError)
                        Case "ListSets"
                            dsOAI = dsTmp
                            Call GetListSets(dsTmp, strXMLError)
                    End Select
                Else
                    lblXML.Visible = True
                    If strXMLError <> "" Then
                        lblXML.Text = strXMLError
                    Else
                        lblXML.Text = DumpXML(dsTmp.GetXml())
                    End If
                End If
                'Catch ex As Exception
            Finally
            End Try

        End Sub

        ' purpose: Convert XML record to string (view by WebBrowser)
        ' Creator : Vantd
        Private Function DumpXML(ByVal strXML As String) As String
            strXML = Replace(strXML, "<", "&lt;")
            strXML = Replace(strXML, ">", "&gt;")
            strXML = Replace(strXML, Chr(10), "<br>")
            Return strXML
        End Function

        ' purpose : Load URL Data to list box
        ' Creator: Vantd
        Public Sub BindData()
            Dim tblURL As New DataTable
            tblURL = objBOAIHavester.GetURLResource()
            If Not tblURL Is Nothing AndAlso tblURL.Rows.Count > 0 Then
                lstURLResource.DataSource = tblURL
                lstURLResource.DataTextField = "Name"
                lstURLResource.DataValueField = "URL"
                lstURLResource.DataBind()
            End If
        End Sub

        ' purpose: Parse Message With verb InIdentify
        ' Creator : Vantd 
        ' OK
        Private Sub GetInIdentify(ByVal dsData As DataSet, ByVal strXML As String)
            Dim tblTmp As New DataTable
            Dim intCount As Integer
            Dim intj As Integer
            Dim blnDescription As Boolean
            Dim strTmp As String

            'tblIdentify.Visible = True
            If strXML <> "" Then
                lblXML.Text = strXML
            Else
                strTmp = ""
                For intCount = 0 To dsData.Tables.Count - 1
                    Select Case dsData.Tables(intCount).TableName
                        Case "adminEmail"
                            blnDescription = True
                            lbladminEmail.Visible = True
                            lbladminEmailVal.Visible = True
                            For intj = 0 To dsData.Tables(intCount).Rows.Count - 1
                                strTmp = strTmp & "<A HREF=""mailto:" & dsData.Tables(intCount).Rows(intj).Item("adminEmail_Text") & """>" & dsData.Tables(intCount).Rows(intj).Item("adminEmail_Text") & "</A>;"
                            Next
                            lbladminEmailVal.Text = strTmp
                        Case "oai-identifier"
                            blnDescription = True
                            lbloai_identifier.Visible = True

                            lblscheme.Visible = True
                            lblschemeVal.Visible = True
                            lblschemeVal.Text = dsData.Tables(intCount).Rows(0).Item("scheme") & ""

                            lblrepositoryIdentifier.Visible = True
                            lblrepositoryIdentifierVal.Visible = True
                            lblrepositoryIdentifierVal.Text = dsData.Tables(intCount).Rows(0).Item("repositoryIdentifier") & ""

                            lbldelimiter.Visible = True
                            lbldelimiterVal.Visible = True
                            lbldelimiterVal.Text = dsData.Tables(intCount).Rows(0).Item("delimiter") & ""

                            lblsampleIdentifier.Visible = True
                            lblsampleIdentifierVal.Visible = True
                            lblsampleIdentifierVal.Text = dsData.Tables(intCount).Rows(0).Item("sampleIdentifier") & ""
                        Case "content" '
                            blnDescription = True
                            lblcontent.Visible = True
                            lblURLCon.Visible = True
                            lblURLConVal.Visible = True
                            lblURLConVal.Text = "<A HREF=""" & dsData.Tables(intCount).Rows(0).Item("URL") & """>" & dsData.Tables(intCount).Rows(0).Item("URL") & "</A>"
                            lblTextCon.Visible = True
                            lblTextConVal.Visible = True
                            lblTextConVal.Text = dsData.Tables(intCount).Rows(0).Item("Text") & ""
                        Case "collectionIcon" '
                            blnDescription = True
                            lblcollectionIcon.Visible = True
                            lblLinkCol.Visible = True
                            lblLinkColVal.Visible = True
                            lblLinkColVal.Text = "<A HREF=""" & dsData.Tables(intCount).Rows(0).Item("Link") & """>" & dsData.Tables(intCount).Rows(0).Item("Link") & "</A>"

                            lblurlCol.Visible = True
                            lblurlColVal.Visible = True
                            lblurlColVal.Text = "<A HREF=""" & dsData.Tables(intCount).Rows(0).Item("url") & """>" & dsData.Tables(intCount).Rows(0).Item("url") & "</A>"

                            lblTitleCol.Visible = True
                            lblTitleColVal.Visible = True
                            lblTitleColVal.Text = dsData.Tables(intCount).Rows(0).Item("title") & ""

                            lblWidthCol.Visible = True
                            lblWidthColVal.Visible = True
                            lblWidthColVal.Text = dsData.Tables(intCount).Rows(0).Item("width") & ""

                            lblHeightCol.Visible = True
                            lblHeightColVal.Visible = True
                            lblHeightColVal.Text = dsData.Tables(intCount).Rows(0).Item("height") & ""
                        Case "metadataRendering"
                            blnDescription = True
                            For intj = 0 To dsData.Tables(intCount).Rows.Count - 1
                                strTmp = strTmp & "<A HREF=""" & dsData.Tables(intCount).Rows(intj).Item("metadataRendering_Text") & """>" & dsData.Tables(intCount).Rows(intj).Item("metadataRendering_Text") & "</A>;"
                            Next
                            lblmetadataRendering.Visible = True
                            lblmetadataRenderingVal.Visible = True
                            lblmetadataRenderingVal.Text = strTmp
                    End Select
                Next
                If blnDescription Then
                    lbldescription.Visible = True
                    lbldescriptionVal.Visible = True
                End If
                If dsData.Tables.IndexOf("Identify") = -1 Then
                    Exit Sub
                End If
                tblTmp = dsData.Tables("Identify")
                If tblTmp.Rows.Count > 0 Then
                    For intCount = 0 To tblTmp.Columns.Count - 1
                        Select Case tblTmp.Columns(intCount).ColumnName
                            Case "repositoryName"
                                lblrepositoryName.Visible = True
                                lblrepositoryNameVal.Visible = True
                                lblrepositoryNameVal.Text = tblTmp.Rows(0).Item(intCount) & ""
                            Case "baseURL"
                                lblbaseURL.Visible = True
                                lblbaseURLVal.Visible = True
                                lblbaseURLVal.Text = tblTmp.Rows(0).Item(intCount) & ""
                            Case "protocolVersion"
                                lblprotocolVersion.Visible = True
                                lblprotocolVersionVal.Visible = True
                                lblprotocolVersionVal.Text = tblTmp.Rows(0).Item(intCount) & ""
                            Case "adminEmail"
                                lbladminEmail.Visible = True
                                lbladminEmailVal.Visible = True
                                lbladminEmailVal.Text = "<A HREF=""mailto:" & tblTmp.Rows(0).Item(intCount) & """>" & tblTmp.Rows(0).Item(intCount) & "</A>"
                            Case "earliestDatestamp"
                                lblearliestDatestamp.Visible = True
                                lblearliestDatestampVal.Visible = True
                                lblearliestDatestampVal.Text = tblTmp.Rows(0).Item(intCount) & ""
                            Case "deletedRecord"
                                lbldeleteRecord.Visible = True
                                lbldeleteRecordVal.Visible = True
                                lbldeleteRecordVal.Text = tblTmp.Rows(0).Item(intCount) & ""
                            Case "granularity"
                                lblgranularity.Visible = True
                                lblgranularityVal.Visible = True
                                lblgranularityVal.Text = tblTmp.Rows(0).Item(intCount) & ""
                            Case "compression"
                                lblcompression.Visible = True
                                lblcompressionVal.Visible = True
                                lblcompressionVal.Text = tblTmp.Rows(0).Item(intCount) & ""
                            Case "description"
                                lbldescription.Visible = True
                                lbldescriptionVal.Visible = True
                                lbldescriptionVal.Text = tblTmp.Rows(0).Item(intCount) & ""
                        End Select
                    Next
                End If
            End If
        End Sub

        ' purpose: Parse Message With verb ListIdentifiers
        ' Creator : Vantd
        ' OK
        Private Sub GetListIdentifiers(ByVal dsData As DataSet, ByVal strXML As String)
            Dim tblTmp As New DataTable
            Dim intCount As Integer

            If strXML <> "" Then
                lblXML.Text = strXML
            Else
                txtidentifier.Text = ""
                txtSET.Text = ""
                txtresumptionToken.Text = ""
                If dsData.Tables.IndexOf("Header") >= 0 Then
                    tblTmp = dsData.Tables("Header")
                    dtgListIdentifiers.Visible = True
                    If tblTmp.Columns.IndexOf("identifier") = -1 Then
                        tblTmp.Columns.Add("identifier")
                    End If
                    If tblTmp.Columns.IndexOf("datestamp") = -1 Then
                        tblTmp.Columns.Add("datestamp")
                    End If
                    For intCount = 0 To tblTmp.Rows.Count - 1
                        If tblTmp.Rows(intCount).Item("identifier") & "" <> "" Then
                            tblTmp.Rows(intCount).Item("identifier") = "<A HREF=""javascript:GetRecord('" & tblTmp.Rows(intCount).Item("identifier") & "');"">" & tblTmp.Rows(intCount).Item("identifier") & "<A>"
                        End If
                    Next
                    dtgListIdentifiers.DataSource = tblTmp
                    dtgListIdentifiers.DataBind()
                End If
                If dsData.Tables.IndexOf("resumptionToken") >= 0 Then
                    If dsData.Tables("resumptionToken").Rows.Count > 0 Then
                        If dsData.Tables("resumptionToken").Columns.IndexOf("completeListSize") >= 0 Then
                            txtToken1.Value = 1
                            lblToltalRec.Visible = True
                            lblToltalRecVal.Visible = True
                            lblToltalRecVal.Text = dsData.Tables("resumptionToken").Rows(0).Item("completeListSize")
                        End If
                        If dsData.Tables("resumptionToken").Columns.IndexOf("cursor") >= 0 Then
                            txtToken2.Value = 1
                            lblCurrentRec.Visible = True
                            lblCurrentRecVal.Visible = True
                            lblCurrentRecVal.Text = CInt("0" & dsData.Tables("resumptionToken").Rows(0).Item("cursor")) + 1
                        End If
                        If dsData.Tables("resumptionToken").Columns.IndexOf("resumptionToken_Text") >= 0 Then
                            txtToken3.Value = 1
                            lnkNextRec.Visible = True
                            lnkNextRec.NavigateUrl = "javascript:ListIdentifiersNext('" & dsData.Tables("resumptionToken").Rows(0).Item("resumptionToken_Text") & "')"
                        End If
                    End If
                End If
            End If
        End Sub

        ' purpose: Parse Message With verb ListSets
        ' Creator : Vantd
        ' OK
        Private Sub GetListSets(ByVal dsData As DataSet, ByVal strXML As String)
            Dim tblTmp As New DataTable
            Dim intIndex As Integer

            If strXML <> "" Then
                lblXML.Text = strXML
            Else
                txtidentifier.Text = ""
                'txtSET.Text = ""
                txtresumptionToken.Text = ""
                If dsData.Tables.IndexOf("Set") <> -1 Then
                    dtgListSets.Visible = True
                    tblTmp = dsData.Tables("Set")
                    If tblTmp.Columns.IndexOf("set_Id") = -1 Then
                        tblTmp.Columns.Add("set_Id")
                    End If
                    If tblTmp.Columns.IndexOf("setSpec") = -1 Then
                        tblTmp.Columns.Add("setSpec")
                    End If
                    If tblTmp.Columns.IndexOf("setName") = -1 Then
                        tblTmp.Columns.Add("setName")
                    End If
                    If Not tblTmp Is Nothing AndAlso tblTmp.Rows.Count > 0 Then
                        lblListSet.Text = "<OL>"
                        For intIndex = 0 To tblTmp.Rows.Count - 1
                            lblListSet.Text = lblListSet.Text & "<LI>" & "<A name=""" & tblTmp.Rows(intIndex).Item("setSpec") & "></A>" & "<A class=""lbLinkFunction"" Href=""Javascript:ListSet(" & tblTmp.Rows(intIndex).Item("setSpec") & ")""></A>" & ": " & tblTmp.Rows(intIndex).Item("setName") & "</LI>"
                        Next
                        lblListSet.Text = "</OL>"
                    End If
                    'dtgListSets.DataSource = tblTmp
                    'dtgListSets.DataBind()
                End If
            End If
        End Sub

        ' purpose: Parse Message With verb ListSets  and set value
        ' Creator : Vantd
        ' OK
        Private Sub GetListSetsDetail(ByVal dsData As DataSet, ByVal intListSetID As Integer)
            Dim tblTmp As New DataTable
            Dim intCount As Integer
            Dim intj As Integer
            Dim strTmp As String
            Dim strVal As String
            Dim dtvTmp As New DataView

            txtidentifier.Text = ""
            txtSET.Text = ""
            txtresumptionToken.Text = ""
            For intCount = 0 To dsData.Tables.Count - 1
                strTmp = ""
                strVal = ""
                If dsData.Tables(intCount).Rows.Count > 0 Then
                    If InStr(",title,creator,description,type,coverage,subject,contributor,relation,", "," & dsData.Tables(intCount).TableName & ",") > 0 Then
                        strVal = dsData.Tables(intCount).TableName & "_Text"
                        dtvTmp = dsData.Tables(intCount).DefaultView
                        dtvTmp.RowFilter = "dc_Id=" & CStr(intListSetID)
                        For intj = 0 To dtvTmp.Count - 1
                            strTmp = strTmp & dtvTmp.Item(intj).Item(strVal) & ";"
                        Next
                        If strTmp <> "" Then
                            strTmp = Left(strTmp, Len(strTmp) - 1)
                        End If
                    End If
                End If
                If strTmp <> "" Then
                    txtListSetsDetail.Value = 1
                    Select Case dsData.Tables(intCount).TableName
                        Case "title"
                            lblTitle.Visible = True
                            lblTitleVal.Visible = True
                            lblTitleVal.Text = strTmp
                        Case "creator"
                            lblAuthor.Visible = True
                            lblAuthorVal.Visible = True
                            lblAuthorVal.Text = strTmp
                        Case "description"
                            lblDescriptionSet.Visible = True
                            lblDescriptionSetVal.Visible = True
                            lblDescriptionSetVal.Text = strTmp
                        Case "type"
                            lblType.Visible = True
                            lblTypeVal.Visible = True
                            lblTypeVal.Text = strTmp
                        Case "coverage"
                            lblcoverage.Visible = True
                            lblcoverageVal.Visible = True
                            lblcoverageVal.Text = strTmp
                        Case "subject"
                            lblSubject.Visible = True
                            lblSubjectVal.Visible = True
                            lblSubjectVal.Text = strTmp
                        Case "contributor"
                            lblcontributor.Visible = True
                            lblcontributorVal.Visible = True
                            lblcontributorVal.Text = strTmp
                        Case "relation"
                            lblrelation.Visible = True
                            lblrelationVal.Visible = True
                            lblrelationVal.Text = strTmp
                    End Select
                Else
                    txtListSetsDetail.Value = 0
                End If
            Next
        End Sub

        ' purpose: Parse Message With verb ListMetadataFormats
        ' Creator : Vantd
        ' OK
        Private Sub GetListMetadataFormats(ByVal dsData As DataSet, ByVal strXML As String)
            Dim tblTmp As New DataTable
            Dim intCount As Integer
            If strXML <> "" Then
                lblXML.Text = strXML
            Else
                txtidentifier.Text = ""
                txtSET.Text = ""
                txtresumptionToken.Text = ""
                If dsData.Tables.IndexOf("metadataFormat") >= 0 Then
                    tblTmp = dsData.Tables("metadataFormat")
                    If tblTmp.Columns.IndexOf("metadataPrefix") = -1 Then
                        tblTmp.Columns.Add("metadataPrefix")
                    End If
                    If tblTmp.Columns.IndexOf("schema") = -1 Then
                        tblTmp.Columns.Add("schema")
                    End If
                    If tblTmp.Columns.IndexOf("metadataNamespace") = -1 Then
                        tblTmp.Columns.Add("metadataNamespace")
                    End If
                    For intCount = 0 To tblTmp.Rows.Count - 1
                        If InStr(tblTmp.Rows(intCount).Item(1) & "", "http://") > 0 Then
                            tblTmp.Rows(intCount).Item(1) = "<A HREF=""" & tblTmp.Rows(intCount).Item(1) & """>" & tblTmp.Rows(intCount).Item(1) & "</A>"
                        End If
                        If InStr(tblTmp.Rows(intCount).Item(2) & "", "http://") > 0 Then
                            tblTmp.Rows(intCount).Item(2) = "<A HREF=""" & tblTmp.Rows(intCount).Item(2) & """>" & tblTmp.Rows(intCount).Item(2) & "</A>"
                        End If
                    Next
                    dtgListMetadataFormats.Visible = True
                    dtgListMetadataFormats.DataSource = tblTmp
                    dtgListMetadataFormats.DataBind()
                End If
            End If
        End Sub

        ' purpose: Parse Message With verb ListRecords and value of metadataPrefix
        ' Creator : Vantd
        ' OK
        Private Sub GetListRecords(ByVal dsData As DataSet, ByVal strXML As String)
            Dim tblTmp As New DataTable
            Dim dtvTmp As New DataView
            Dim intCount As Integer
            Dim intj As Integer
            Dim strTmp As String
            Dim intIndex As Integer

            If strXML <> "" Then
                lblXML.Text = strXML
            Else
                txtidentifier.Text = ""
                txtSET.Text = ""
                txtresumptionToken.Text = ""
                If dsData.Tables.IndexOf("dc") = -1 Then
                    Exit Sub
                End If
                If dsData.Tables.IndexOf("resumptionToken") >= 0 Then
                    If dsData.Tables("resumptionToken").Rows.Count > 0 Then
                        If dsData.Tables("resumptionToken").Columns.IndexOf("completeListSize") >= 0 Then
                            txtToken1.Value = 1
                            lblToltalRec.Visible = True
                            lblToltalRecVal.Visible = True
                            lblToltalRecVal.Text = dsData.Tables("resumptionToken").Rows(0).Item("completeListSize")
                        End If
                        If dsData.Tables("resumptionToken").Columns.IndexOf("cursor") >= 0 Then
                            txtToken2.Value = 1
                            lblCurrentRec.Visible = True
                            lblCurrentRecVal.Visible = True
                            lblCurrentRecVal.Text = CInt("0" & dsData.Tables("resumptionToken").Rows(0).Item("cursor")) + 1
                        End If
                        If dsData.Tables("resumptionToken").Columns.IndexOf("resumptionToken_Text") >= 0 Then
                            txtToken3.Value = 1
                            lnkNextRec.Visible = True
                            lnkNextRec.NavigateUrl = "javascript:ListRecordNext('" & dsData.Tables("resumptionToken").Rows(0).Item("resumptionToken_Text") & "')"
                        End If
                    End If
                End If
                tblTmp = dsData.Tables("dc")
                tblTmp.Columns.Add("descriptionF", System.Type.GetType("System.String"))
                tblTmp.Columns.Add("creatorF", System.Type.GetType("System.String"))
                tblTmp.Columns.Add("coverageF", System.Type.GetType("System.String"))
                tblTmp.Columns.Add("subjectF", System.Type.GetType("System.String"))
                tblTmp.Columns.Add("IDF", System.Type.GetType("System.String"))
                tblTmp.Columns.Add("datestampF", System.Type.GetType("System.String"))
                If tblTmp.Columns.IndexOf("Title") = -1 Then
                    tblTmp.Columns.Add("Title")
                End If
                If tblTmp.Columns.IndexOf("Identifier") = -1 Then
                    tblTmp.Columns.Add("Identifier")
                End If
                If tblTmp.Columns.IndexOf("Publisher") = -1 Then
                    tblTmp.Columns.Add("Publisher")
                End If
                If tblTmp.Columns.IndexOf("Date") = -1 Then
                    tblTmp.Columns.Add("Date")
                End If
                If tblTmp.Columns.IndexOf("Type") = -1 Then
                    tblTmp.Columns.Add("Type")
                End If
                If tblTmp.Columns.IndexOf("Language") = -1 Then
                    tblTmp.Columns.Add("Language")
                End If
                For intCount = 0 To tblTmp.Rows.Count - 1
                    'description
                    If dsData.Tables.IndexOf("description") >= 0 Then
                        strTmp = ""
                        dtvTmp = dsData.Tables("description").DefaultView
                        dtvTmp.RowFilter = "dc_Id=" & tblTmp.Rows(intCount).Item("metadata_Id")
                        For intj = 0 To dtvTmp.Count - 1
                            strTmp = strTmp & dtvTmp.Item(intj).Item("description_Text") & ";"
                        Next
                        If strTmp <> "" Then
                            strTmp = Left(strTmp, Len(strTmp) - 1)
                        End If
                        tblTmp.Rows(intCount).Item("descriptionF") = strTmp
                    End If
                    'creator
                    If dsData.Tables.IndexOf("creator") >= 0 Then
                        strTmp = ""
                        dtvTmp = dsData.Tables("creator").DefaultView
                        dtvTmp.RowFilter = "dc_Id=" & tblTmp.Rows(intCount).Item("metadata_Id")
                        For intj = 0 To dtvTmp.Count - 1
                            strTmp = strTmp & dtvTmp.Item(intj).Item("creator_Text") & ";"
                        Next
                        If strTmp <> "" Then
                            strTmp = Left(strTmp, Len(strTmp) - 1)
                        End If
                        tblTmp.Rows(intCount).Item("creatorF") = strTmp
                    End If
                    'coverage
                    If dsData.Tables.IndexOf("coverage") >= 0 Then
                        strTmp = ""
                        dtvTmp = dsData.Tables("coverage").DefaultView
                        dtvTmp.RowFilter = "dc_Id=" & tblTmp.Rows(intCount).Item("metadata_Id")
                        For intj = 0 To dtvTmp.Count - 1
                            strTmp = strTmp & dtvTmp.Item(intj).Item("coverage_Text") & ";"
                        Next
                        If strTmp <> "" Then
                            strTmp = Left(strTmp, Len(strTmp) - 1)
                        End If
                        tblTmp.Rows(intCount).Item("coverageF") = strTmp
                    End If
                    'subject
                    If dsData.Tables.IndexOf("subject") >= 0 Then
                        strTmp = ""
                        dtvTmp = dsData.Tables("subject").DefaultView
                        dtvTmp.RowFilter = "dc_Id=" & tblTmp.Rows(intCount).Item("metadata_Id")
                        For intj = 0 To dtvTmp.Count - 1
                            strTmp = strTmp & dtvTmp.Item(intj).Item("subject_Text") & ";"
                        Next
                        If strTmp <> "" Then
                            strTmp = Left(strTmp, Len(strTmp) - 1)
                        End If
                        tblTmp.Rows(intCount).Item("subjectF") = strTmp
                    End If
                    'header
                    If dsData.Tables.IndexOf("header") >= 0 Then
                        dtvTmp = dsData.Tables("header").DefaultView
                        dtvTmp.RowFilter = "record_Id=" & tblTmp.Rows(intCount).Item("metadata_Id")
                        ' ID
                        tblTmp.Rows(intCount).Item("IDF") = dtvTmp.Item(0).Item("identifier") & ""
                        ' ngay cap nhat
                        tblTmp.Rows(intCount).Item("datestampF") = dtvTmp.Item(0).Item("datestamp") & ""
                    End If
                Next

                ' Bind the data for the List record details
                lblListRecord.Text = "<OL>"
                If Not tblTmp Is Nothing AndAlso tblTmp.Rows.Count > 0 Then
                    For intIndex = 0 To tblTmp.Rows.Count - 1
                        lblListRecord.Text = lblListRecord.Text & "<li><B>" & tblTmp.Rows(intIndex).Item("Title") & "</B>"
                        lblListRecord.Text = lblListRecord.Text & "<ul>"
                        lblListRecord.Text = lblListRecord.Text & "<li><B>" & ddlLabel.Items("0").Text & "</B> " & tblTmp.Rows(intIndex).Item("IDF") & "</li>"
                        lblListRecord.Text = lblListRecord.Text & "<li><B>" & ddlLabel.Items("1").Text & "</B> " & tblTmp.Rows(intIndex).Item("datestampF") & "</li>"

                        If tblTmp.Columns.IndexOf("creatorF") <> -1 Then
                            If Not Trim(tblTmp.Rows(intIndex).Item("creatorF").ToString) = "" Then
                                lblListRecord.Text = lblListRecord.Text & "<li><B>" & ddlLabel.Items("2").Text & "</B> " & "<BR>" & tblTmp.Rows(intIndex).Item("creatorF") & "</li>"
                            End If
                        End If

                        If tblTmp.Columns.IndexOf("subjectF") <> -1 Then
                            If Not Trim(tblTmp.Rows(intIndex).Item("subjectF").ToString) = "" Then
                                lblListRecord.Text = lblListRecord.Text & "<li><B>" & ddlLabel.Items("3").Text & "</B> " & "<BR>" & tblTmp.Rows(intIndex).Item("subjectF") & "</li>"
                            End If
                        End If

                        If tblTmp.Columns.IndexOf("Identifier") <> -1 Then
                            If Not Trim(tblTmp.Rows(intIndex).Item("Identifier").ToString) = "" Then
                                lblListRecord.Text = lblListRecord.Text & "<li><B>" & ddlLabel.Items("4").Text & "</B> " & "<BR><A Class=""lbLinkFunction"" TARGET=""newin"" href=""" & tblTmp.Rows(intIndex).Item("Identifier") & """>" & tblTmp.Rows(intIndex).Item("Identifier") & "</A></li>"
                            End If
                        End If


                        If tblTmp.Columns.IndexOf("Publisher") <> -1 Then
                            If Not Trim(tblTmp.Rows(intIndex).Item("Publisher").ToString) = "" Then
                                lblListRecord.Text = lblListRecord.Text & "<li><B>" & ddlLabel.Items("5").Text & "</B> " & "<BR>" & tblTmp.Rows(intIndex).Item("Publisher").ToString & "</li>"
                            End If
                        End If

                        If tblTmp.Columns.IndexOf("Date") <> -1 Then
                            If Not Trim(tblTmp.Rows(intIndex).Item("Date").ToString) = "" Then
                                lblListRecord.Text = lblListRecord.Text & "<li><B>" & ddlLabel.Items("6").Text & "</B> " & "<BR>" & tblTmp.Rows(intIndex).Item("date") & "</li>"
                            End If
                        End If

                        If tblTmp.Columns.IndexOf("type") <> -1 Then
                            If Not Trim(tblTmp.Rows(intIndex).Item("type").ToString) = "" Then
                                lblListRecord.Text = lblListRecord.Text & "<li><B>" & ddlLabel.Items("7").Text & "</B> " & "<BR>" & tblTmp.Rows(intIndex).Item("type") & "</li>"
                            End If
                        End If

                        If tblTmp.Columns.IndexOf("Format") <> -1 Then
                            If Not Trim(tblTmp.Rows(intIndex).Item("Format").ToString) = "" Then
                                lblListRecord.Text = lblListRecord.Text & "<li><B>" & ddlLabel.Items("8").Text & "</B> " & "<BR>" & tblTmp.Rows(intIndex).Item("Format") & "</li>"
                            End If
                        End If

                        If tblTmp.Columns.IndexOf("source") <> -1 Then
                            If Not Trim(tblTmp.Rows(intIndex).Item("source").ToString) = "" Then
                                lblListRecord.Text = lblListRecord.Text & "<li><B>" & ddlLabel.Items("9").Text & "</B> " & "<BR>" & tblTmp.Rows(intIndex).Item("source") & "</li>"
                            End If
                        End If

                        If tblTmp.Columns.IndexOf("language") <> -1 Then
                            If Not Trim(tblTmp.Rows(intIndex).Item("language").ToString) = "" Then
                                lblListRecord.Text = lblListRecord.Text & "<li><B>" & ddlLabel.Items("10").Text & "</B> " & "<BR>" & tblTmp.Rows(intIndex).Item("language") & "</li>"
                            End If
                        End If

                        If tblTmp.Columns.IndexOf("rights") <> -1 Then
                            If Not Trim(tblTmp.Rows(intIndex).Item("rights").ToString) = "" Then
                                lblListRecord.Text = lblListRecord.Text & "<li><B>" & ddlLabel.Items("11").Text & "</B> " & "<BR>" & tblTmp.Rows(intIndex).Item("rights") & "</li>"
                            End If
                        End If

                        If tblTmp.Columns.IndexOf("Metadata_ID") <> -1 Then
                            If Not Trim(tblTmp.Rows(intIndex).Item("Metadata_ID").ToString) = "" Then
                                lblListRecord.Text = lblListRecord.Text & "<li><B>" & ddlLabel.Items("12").Text & "</B> " & "<BR>" & tblTmp.Rows(intIndex).Item("Metadata_ID") & "</li>"
                            End If
                        End If


                        If tblTmp.Columns.IndexOf("Contributor") <> -1 Then
                            If Not Trim(tblTmp.Rows(intIndex).Item("Contributor").ToString) = "" Then
                                lblListRecord.Text = lblListRecord.Text & "<li><B>" & ddlLabel.Items("13").Text & "</B> " & "<BR>" & tblTmp.Rows(intIndex).Item("contributor") & "</li>"
                            End If
                        End If


                        If tblTmp.Columns.IndexOf("descriptionF") <> -1 Then
                            If Not Trim(tblTmp.Rows(intIndex).Item("descriptionF").ToString) = "" Then
                                lblListRecord.Text = lblListRecord.Text & "<li><B>" & ddlLabel.Items("14").Text & "</B>  " & "<BR>" & tblTmp.Rows(intIndex).Item("descriptionF") & "</li>"
                            End If
                        End If

                        If tblTmp.Columns.IndexOf("coverageF") <> -1 Then
                            If Not Trim(tblTmp.Rows(intIndex).Item("coverageF").ToString) = "" Then
                                lblListRecord.Text = lblListRecord.Text & "<li><B>" & ddlLabel.Items("15").Text & "</B> " & "<BR>" & tblTmp.Rows(intIndex).Item("coverageF") & "</li>"
                            End If
                        End If

                        lblListRecord.Text = lblListRecord.Text & "</ul>"
                        lblListRecord.Text = lblListRecord.Text & "</li>"
                    Next
                End If
            End If
        End Sub

        ' purpose: Parse Message With verb GetRecord and value of metadataPrefix,identifier 
        ' Creator : Vantd
        ' OK
        Private Sub GetRecords(ByVal dsData As DataSet, ByVal strXML As String)
            Dim tblTmp As New DataTable
            Dim intCount As Integer
            Dim strTmp As String
            If strXML <> "" Then
                lblXML.Text = strXML
            Else
                'txtidentifier.Text = ""
                txtSET.Text = ""
                txtresumptionToken.Text = ""
                txtRecordDetail.Value = 1
                If dsData.Tables.IndexOf("header") >= 0 Then
                    tblTmp = dsData.Tables("header")
                    If tblTmp.Rows.Count > 0 Then
                        lblIDR.Visible = True
                        lblIDRVal.Visible = True
                        lblIDRVal.Text = tblTmp.Rows(0).Item("identifier")
                        lbldatestampR.Visible = True
                        lbldatestampRVal.Visible = True
                        lbldatestampRVal.Text = tblTmp.Rows(0).Item("datestamp")
                    End If
                End If
                If dsData.Tables.IndexOf("setSpec") >= 0 Then
                    tblTmp = dsData.Tables("setSpec")
                    If tblTmp.Rows.Count > 0 Then
                        lblsetSpecR.Visible = True
                        lblsetSpecRVal.Visible = True
                        For intCount = 0 To tblTmp.Rows.Count - 1
                            strTmp = strTmp & tblTmp.Rows(intCount).Item("setSpec_Text") & ","
                        Next
                        If strTmp <> "" Then
                            strTmp = Left(strTmp, Len(strTmp) - 1)
                        End If
                        lblsetSpecRVal.Text = strTmp
                    End If
                End If
                If dsData.Tables.IndexOf("dc") >= 0 Then
                    tblTmp = dsData.Tables("dc")
                    For intCount = 0 To tblTmp.Columns.Count - 1
                        Select Case tblTmp.Columns(intCount).ColumnName
                            Case "title"
                                lblTitleR.Visible = True
                                lblTitleRVal.Visible = True
                                lblTitleRVal.Text = tblTmp.Rows(0).Item("title") & ""
                            Case "description"

                                lbldescriptionR.Visible = True
                                lbldescriptionRVal.Visible = True
                                lbldescriptionRVal.Text = tblTmp.Rows(0).Item("description") & ""
                            Case "publisher"
                                lblPublisherRVal.Visible = True
                                lblPublisherR.Visible = True
                                lblPublisherRVal.Text = tblTmp.Rows(0).Item("publisher") & ""
                            Case "date"
                                lbldateRVal.Visible = True
                                lbldateR.Visible = True
                                lbldateRVal.Text = tblTmp.Rows(0).Item("date") & ""
                            Case "type"
                                lblTypeRVal.Visible = True
                                lblTypeR.Visible = True
                                lblTypeRVal.Text = tblTmp.Rows(0).Item("type") & ""
                            Case "identifier"
                                lblidentifierRVal.Visible = True
                                lblidentifierR.Visible = True
                                lblidentifierRVal.Text = tblTmp.Rows(0).Item("identifier") & ""
                            Case "language"
                                lbllanguageR.Visible = True
                                lbllanguageRVal.Visible = True
                                lbllanguageRVal.Text = tblTmp.Rows(0).Item("language") & ""
                            Case "coverage"
                                lblcoverageRVal.Visible = True
                                lblcoverageR.Visible = True
                                lblcoverageRVal.Text = tblTmp.Rows(0).Item("coverage") & ""
                        End Select
                    Next
                End If
            End If
        End Sub

        ' Init method
        ' purpose initialize all components
        ' Creator : vantd
        Private Sub Initialize()
            ' init OPACItem object
            objBOAIHavester.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBOAIHavester.DBServer = Session("DBServer")
            objBOAIHavester.ConnectionString = Session("ConnectionString")
            objBOAIHavester.Initialize()
        End Sub

        ' BindScript method
        ' Purpose: Bind JAVASCRIPTS
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/OAI/WOAIHavester.js'></script>")
            lnkIdentify.NavigateUrl = "javascript:OAIConnect('Identify','" & lblMsg.Text & "')"
            lnkListMetadataFormats.NavigateUrl = "javascript:OAIConnect('ListMetadataFormats','" & lblMsg.Text & "')"
            lnkGetRecord.NavigateUrl = "javascript:OAIConnect('GetRecord','" & lblMsg.Text & "')"
            lnkListIdentifiers.NavigateUrl = "javascript:OAIConnect('ListIdentifiers','" & lblMsg.Text & "')"
            lnkListRecords.NavigateUrl = "javascript:OAIConnect('ListRecords','" & lblMsg.Text & "')"
            lnkListSets.NavigateUrl = "javascript:OAIConnect('ListSets','" & lblMsg.Text & "')"
            lstURLResource.Attributes.Add("onChange", "SelectList()")
        End Sub

        Private Sub dtgListSets_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgListSets.ItemCommand
            Dim lblID As New Label
            If UCase(e.CommandName) = "SELECT" Then
                lblID = CType(e.Item.FindControl("lblIDSet"), Label)
                If IsNumeric(lblID.Text & "") Then
                    Call GetListSetsDetail(dsOAI, lblID.Text)
                    Page.RegisterClientScriptBlock("MARK", "<script language = 'javascript'>self.location.href='#Detail'</script>")
                End If
            End If
        End Sub
        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBOAIHavester Is Nothing Then
                    objBOAIHavester.Dispose(True)
                    objBOAIHavester = Nothing
                End If
                If Not dsOAI Is Nothing Then
                    dsOAI = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
