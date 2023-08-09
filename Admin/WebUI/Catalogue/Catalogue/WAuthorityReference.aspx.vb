' WAuthorityReference class
' Purpose: search authority data for cataloguing
' Creator: Oanhtn
' CreatedDate: 20/05/2004
' Modification history:

Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WAuthorityReference
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
        Private objBAuthority As New clsBAuthority
        Private objBCatalogueForm As New clsBCatalogueForm

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
            Call LoadBackData()
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init objBCatalogueForm object
            objBCatalogueForm.IsAuthority = Session("IsAuthority")
            objBCatalogueForm.InterfaceLanguage = Session("InterfaceLanguage")
            objBCatalogueForm.DBServer = Session("DBServer")
            objBCatalogueForm.ConnectionString = Session("ConnectionString")
            Call objBCatalogueForm.Initialize()

            ' Init objBAuthority object
            objBAuthority.InterfaceLanguage = Session("InterfaceLanguage")
            objBAuthority.DBServer = Session("DBServer")
            objBAuthority.ConnectionString = Session("ConnectionString")
            Call objBAuthority.Initialize()
        End Sub

        ' BindJS method
        ' Purpose: include all necessary javascript functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("WCommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WCataJs", "<script language = 'javascript' src = '../Js/Catalogue/WCata.js'></script>")
            Page.RegisterClientScriptBlock("WAuthorityReferenceJs", "<script language = 'javascript' src = '../Js/Catalogue/WAuthorityReference.js'></script>")

            btnClose.Attributes.Add("OnClick", "javascript:self.close();")
        End Sub

        ' BindData method
        ' Purpose: seach authority data and load back cataloguing form
        Private Sub BindData()
            Dim strDestField As String
            Dim strStoreField As String
            Dim strPattern As String
            Dim strFieldCode As String
            Dim intRepeatable As Integer
            Dim strControlName As String
            Dim lngAuthorityID As Long = 0
            Dim intPos As Integer
            Dim tblTemp As DataTable

            ' Stored QueryString
            If Not Request("Frame") = "" Then
                hidFrame.Value = Trim(Request("Frame"))
                hidStoreFrame.Value = Trim(Request("StoreFrame"))
                hidKeyword.Value = Trim(Request("Keyword"))
                hidTag.Value = Trim(Request("Tag"))

                ' ??? AUTHORITY DATA
                hidBib.Value = Trim(Request("Bib"))
                hidRepeatable.Value = Trim(Request("Repeatable"))
            End If

            ' Get variable
            strDestField = hidFrame.Value
            strStoreField = hidStoreFrame.Value
            strPattern = hidKeyword.Value
            strFieldCode = Trim(Replace(hidTag.Value, "tag", ""))
            intRepeatable = CInt(hidRepeatable.Value)

            ' Process
            intPos = InStr(strPattern, "$a")
            If intPos > 0 Then
                strPattern = Right(strPattern, Len(strPattern) - intPos - 1)
                If InStr(strPattern, "$") > 0 Then
                    strPattern = Left(strPattern, InStr(strPattern, "$") - 1)
                End If
            End If

            lsbAuthorityReference.Enabled = False
            btnSelect.Enabled = False
            If Not strPattern = "" Then
                objBCatalogueForm.FieldCode = strFieldCode

                If Not CInt(hidBib.Value) = 1 Then
                    objBCatalogueForm.IsAuthority = 0
                    tblTemp = objBCatalogueForm.GetProperties
                    If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                        lngAuthorityID = CInt(tblTemp.Rows(0).Item("AuthorityID").ToString)
                    End If
                Else
                    objBCatalogueForm.IsAuthority = 1
                    tblTemp = objBCatalogueForm.GetProperties
                    If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                        Try
                            If Not IsDBNull(tblTemp.Rows(0).Item("DicID")) Then
                                lngAuthorityID = CInt(tblTemp.Rows(0).Item("DicID").ToString)
                            End If
                        Catch ex As Exception
                            lngAuthorityID = 0
                        End Try
                    End If
                End If
                objBCatalogueForm.IsAuthority = 1

                If Not lngAuthorityID = 0 Then
                    ' Get AuthorityReference name
                    Select Case lngAuthorityID
                        Case 1
                            lblAuthorityReference.Text = ddlLabel.Items(1).Text
                        Case 2
                            lblAuthorityReference.Text = ddlLabel.Items(2).Text
                        Case 3
                            lblAuthorityReference.Text = ddlLabel.Items(3).Text
                        Case 4
                            lblAuthorityReference.Text = ddlLabel.Items(4).Text
                        Case 5
                            lblAuthorityReference.Text = ddlLabel.Items(5).Text
                        Case 6
                            lblAuthorityReference.Text = ddlLabel.Items(6).Text
                        Case 7
                            lblAuthorityReference.Text = ddlLabel.Items(7).Text
                        Case 8
                            lblAuthorityReference.Text = ddlLabel.Items(8).Text
                        Case 9
                            lblAuthorityReference.Text = ddlLabel.Items(9).Text
                        Case 10
                            lblAuthorityReference.Text = ddlLabel.Items(10).Text
                        Case 11
                            lblAuthorityReference.Text = ddlLabel.Items(11).Text
                    End Select

                    tblTemp.Clear()

                    ' Bind Dropdownlist
                    objBAuthority.AccessEntry = strPattern
                    objBAuthority.ReferenceID = lngAuthorityID
                    tblTemp = objBAuthority.GetAuthority

                    If tblTemp.Rows.Count = 0 Then
                        lblAuthorityReference.Text = ddlLabel.Items(12).Text
                    Else
                        lsbAuthorityReference.Enabled = True
                        lsbAuthorityReference.DataSource = tblTemp
                        lsbAuthorityReference.DataTextField = "DisplayEntry"
                        lsbAuthorityReference.DataValueField = "ID"
                        lsbAuthorityReference.DataBind()
                        lsbAuthorityReference.Attributes.Add("OnChange", "javascript:document.forms[0].hidAuthorityID.value = this.options[this.options.selectedIndex].value;")

                        btnSelect.Enabled = True
                        tblTemp.Clear()

                        btnSelect.Attributes.Add("OnClick", "javascript:document.forms[0].submit();")
                    End If
                Else
                    lblAuthorityReference.Text = ddlLabel.Items(12).Text
                End If
            End If

            ' Release objects
            Try
                tblTemp.Dispose()
                tblTemp = Nothing
            Catch ex As Exception

            End Try
        End Sub

        ' LoadBackData method
        ' Purpose: 
        Private Sub LoadBackData()
            Dim strIndicatorValue As String
            Dim strFieldValue As String
            Dim lngAuthorityID As Long
            Dim strDestField As String
            Dim strStoreField As String
            Dim strPattern As String
            Dim strFieldCode As String
            Dim intRepeatable As Integer
            Dim tblTemp As DataTable

            ' Get variable
            strDestField = hidFrame.Value
            strStoreField = hidStoreFrame.Value
            strPattern = hidKeyword.Value
            strFieldCode = Trim(Replace(hidTag.Value, "tag", ""))
            intRepeatable = CInt(hidRepeatable.Value)
            lngAuthorityID = CLng(hidAuthorityID.Value)

            If Not lngAuthorityID = 0 Then
                ' Get AuthorityData
                objBCatalogueForm.AuthorityID = lngAuthorityID
                tblTemp = objBCatalogueForm.GetAuthority
                ' Loadback data to cataloguing form
                If Not tblTemp Is Nothing AndAlso Not tblTemp.Rows.Count = 0 Then
                    If Not IsDBNull(tblTemp.Rows(0).Item("Ind1")) Then
                        strIndicatorValue = tblTemp.Rows(0).Item("Ind1")
                    End If
                    If Not IsDBNull(tblTemp.Rows(0).Item("Ind2")) Then
                        strIndicatorValue &= tblTemp.Rows(0).Item("Ind2")
                    End If
                    strFieldValue = tblTemp.Rows(0).Item("Content")
                    If CInt(hidBib.Value) = 0 Then
                        strFieldValue = strFieldValue & "$0" & CStr(lngAuthorityID)
                    End If
                    strFieldValue = Replace(strFieldValue, """", "\""")
                    Page.RegisterClientScriptBlock("LoadBackData", "<script language = 'javascript'>LoadBackAReference('" & strIndicatorValue & "', '" & strFieldValue & "', '" & strFieldCode & "', '" & strDestField & "', '" & strStoreField & "', " & intRepeatable & ");</script>")
                End If
                Try
                    tblTemp.Dispose()
                    tblTemp = Nothing
                Catch ex As Exception

                End Try
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
                If Not objBCatalogueForm Is Nothing Then
                    objBCatalogueForm.Dispose(True)
                    objBCatalogueForm = Nothing
                End If
                If Not objBAuthority Is Nothing Then
                    objBAuthority.Dispose(True)
                    objBAuthority = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace