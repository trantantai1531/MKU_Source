' Class: WClassificationReference
' Purpose: search classification data for cataloguing
' Creator: Oanhtn
' CreatedDate: 13/06/2005
' Modification history:

Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WClassificationReference
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
        Private objBClassification As New clsBClassification
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
            objBCatalogueForm.InterfaceLanguage = Session("InterfaceLanguage")
            objBCatalogueForm.DBServer = Session("DBServer")
            objBCatalogueForm.ConnectionString = Session("ConnectionString")
            Call objBCatalogueForm.Initialize()

            ' Init objBClassification object
            objBClassification.InterfaceLanguage = Session("InterfaceLanguage")
            objBClassification.DBServer = Session("DBServer")
            objBClassification.ConnectionString = Session("ConnectionString")
            Call objBClassification.Initialize()
        End Sub

        ' BindJS method
        ' Purpose: include all necessary javascript functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("WCommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WCataJs", "<script language = 'javascript' src = '../Js/Catalogue/WCata.js'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../Js/Catalogue/WAuthorityReference.js'></script>")

            btnClose.Attributes.Add("OnClick", "javascript:self.close();")
        End Sub

        ' BindData method
        ' Purpose: seach Classification data and load back cataloguing form
        Private Sub BindData()
            Dim strDestField As String
            Dim strStoreField As String
            Dim strPattern As String
            Dim strFieldCode As String
            Dim intRepeatable As Integer
            Dim strControlName As String
            Dim lngClassificationID As Long = 0
            Dim strClassName As String
            Dim intPos As Integer
            Dim tblTemp As DataTable

            ' Stored QueryString
            If Not Request("Frame") = "" Then
                hidFrame.Value = Trim(Request("Frame"))
                hidStoreFrame.Value = Trim(Request("StoreFrame"))
                hidKeyword.Value = Trim(Request("Keyword"))
                hidTag.Value = Trim(Request("Tag"))
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

            lsbClassificationReference.Enabled = False
            btnSelect.Enabled = False
            If Not strPattern = "" Then
                objBCatalogueForm.FieldCode = strFieldCode
                tblTemp = objBCatalogueForm.GetProperties ' Bibliographic only
                If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                    lngClassificationID = CInt(tblTemp.Rows(0).Item("ClassificationID").ToString)
                End If

                If lngClassificationID > 0 Then
                    ' Get ClassificationReference name
                    Select Case lngClassificationID
                        Case 1
                            lblClassificationReference.Text = ddlLabel.Items(2).Text
                        Case 2
                            lblClassificationReference.Text = ddlLabel.Items(3).Text
                        Case 3
                            lblClassificationReference.Text = ddlLabel.Items(4).Text
                        Case 4
                            lblClassificationReference.Text = ddlLabel.Items(5).Text
                    End Select

                    tblTemp.Clear()

                    ' Bind Dropdownlist
                    objBClassification.DisplayEntry = strPattern.Trim
                    objBClassification.TypeID = lngClassificationID
                    tblTemp = objBClassification.GetClassification

                    If tblTemp Is Nothing Or tblTemp.Rows.Count = 0 Then
                        lblClassificationReference.Text = ddlLabel.Items(7).Text
                    Else
                        lsbClassificationReference.Enabled = True
                        lsbClassificationReference.DataSource = tblTemp
                        lsbClassificationReference.DataTextField = "Classification"
                        lsbClassificationReference.DataValueField = "DisplayEntry"
                        lsbClassificationReference.DataBind()
                        lsbClassificationReference.Attributes.Add("OnChange", "javascript:document.forms[0].hidClassificationID.value = this.options[this.options.selectedIndex].value;")

                        btnSelect.Enabled = True
                        tblTemp.Clear()

                        btnSelect.Attributes.Add("OnClick", "javascript:document.forms[0].submit();")
                    End If
                Else
                    lblClassificationReference.Text = ddlLabel.Items(6).Text
                End If
            End If

            ' Release objects
            tblTemp.Dispose()
            tblTemp = Nothing
        End Sub

        ' LoadBackData method
        ' Purpose: 
        Private Sub LoadBackData_OLD()
            Dim strIndicatorValue As String = ""
            Dim strFieldValue As String = ""
            Dim lngClassificationID As Long = 0
            Dim strDestField As String = ""
            Dim strStoreField As String = ""
            Dim strPattern As String = ""
            Dim strFieldCode As String = ""
            Dim intRepeatable As Integer = 0
            Dim tblTemp As DataTable

            ' Get variable
            strDestField = hidFrame.Value
            strStoreField = hidStoreFrame.Value
            strPattern = hidKeyword.Value
            strFieldCode = Trim(Replace(hidTag.Value, "tag", ""))
            intRepeatable = CInt(hidRepeatable.Value)
            lngClassificationID = CLng(hidClassificationID.Value)

            If Not lngClassificationID = 0 Then
                ' Loadback data to cataloguing form
                strFieldValue = lsbClassificationReference.SelectedItem.Value.Trim
                strFieldValue = "$a" & Replace(strFieldValue, "'", "\'")
                Page.RegisterClientScriptBlock("LoadBackData", "<script language = 'javascript'>LoadBackAReference('" & strIndicatorValue & "', '" & strFieldValue & "', '" & strFieldCode & "', '" & strDestField & "', '" & strStoreField & "', " & intRepeatable & ");</script>")
            End If
        End Sub

        'PHUONG MODIFY : 20081205
        'B1
        Private Sub LoadBackData()
            Dim strIndicatorValue As String = ""
            Dim strFieldValue As String = ""
            Dim lngClassificationID As String = "0"
            Dim strDestField As String = ""
            Dim strStoreField As String = ""
            Dim strPattern As String = ""
            Dim strFieldCode As String = ""
            Dim intRepeatable As Integer = 0
            Dim tblTemp As DataTable

            ' Get variable
            strDestField = hidFrame.Value
            strStoreField = hidStoreFrame.Value
            strPattern = hidKeyword.Value
            strFieldCode = Trim(Replace(hidTag.Value, "tag", ""))
            intRepeatable = CInt(hidRepeatable.Value)
            lngClassificationID = hidClassificationID.Value

            If Not lngClassificationID = "0" Then
                ' Loadback data to cataloguing form
                strFieldValue = lsbClassificationReference.SelectedItem.Value.Trim
                strFieldValue = "$a" & Replace(strFieldValue, "'", "\'")
                Page.RegisterClientScriptBlock("LoadBackData", "<script language = 'javascript'>LoadBackAReference('" & strIndicatorValue & "', '" & strFieldValue & "', '" & strFieldCode & "', '" & strDestField & "', '" & strStoreField & "', " & intRepeatable & ");</script>")
            End If
        End Sub
        'E1

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
                If Not objBClassification Is Nothing Then
                    objBClassification.Dispose(True)
                    objBClassification = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace