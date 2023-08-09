' WMarcFieldHelp class
' Purpose: Display helpwin window 
' Creator: Oanhtn
' CreatedDate: 16/05/2004
' Modification history:
'   - 15/07/2004 by Oanhtn: allow working with both of bibliography & authority data
'   - 02/03/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WMarcFieldHelp
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
        Private objBField As New clsBField
        Private objBCatalogueForm As New clsBCatalogueForm
        Private strSubFields As String

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJavascripts()
            Call DisplayHelpWin()
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init objBField object
            objBField.InterfaceLanguage = Session("InterfaceLanguage")
            objBField.DBServer = Session("DBServer")
            objBField.ConnectionString = Session("ConnectionString")
            objBField.IsAuthority = Session("IsAuthority")
            Call objBField.Initialize()

            ' Init objBCatalogueForm object
            objBCatalogueForm.InterfaceLanguage = Session("InterfaceLanguage")
            objBCatalogueForm.DBServer = Session("DBServer")
            objBCatalogueForm.ConnectionString = Session("ConnectionString")
            Call objBCatalogueForm.Initialize()
        End Sub

        ' BindJavascripts method
        ' Purpose: Include all neccessary javascript functions
        Private Sub BindJavascripts()
            Page.RegisterClientScriptBlock("WCommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WMarcFieldHelpJs", "<script language = 'javascript' src = '../Js/Catalogue/WMarcFieldHelp.js'></script>")
            Page.RegisterClientScriptBlock("WCataJs", "<script language = 'javascript' src = '../Js/Catalogue/WCata.js'></script>")

            'btnClose.Attributes.Add("OnClick", "self.close()")
            btnClose.Attributes.Add("OnClick", "javascript:top.closeDialog('Dialog_content');")
        End Sub

        ' DisplayHelpWin method
        ' Purpose: Display help window
        Private Sub DisplayHelpWin()
            ' Declare variables
            Dim intTagCount As Integer
            Dim intCounter As Integer
            Dim strTableData As String = ""
            Dim strValue As String = Request("Val")
            Dim tblFieldProperties As DataTable
            Dim tblSubFields As DataTable
            Dim strSubField As String
            Dim strJavascript As String = ""
            Dim strTagName As String = ""
            Dim intTagRepeat As Integer = 0
            Dim strTagCode As String = ""
            Dim intTagMand As Integer = 0
            Dim intDicID As Integer = 0

            ' Get some varables from QueryString
            If Not Request("FieldCode") = "" Then
                txtFieldCode.Value = Request("FieldCode")
            End If
            If Not Request("FormID") = "" Then
                txtFormID.Value = Request("FormID")
            End If
            If Not Request("Indicator") = "" Then
                txtIndicator.Value = Request("Indicator")
            End If

            ' Get name of this field
            objBField.FieldCode = txtFieldCode.Value.Trim
            tblFieldProperties = objBField.GetProperties

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBField.ErrorMsg, ddlLabel.Items(0).Text, objBField.ErrorCode)

            If Not tblFieldProperties Is Nothing Then
                If tblFieldProperties.Rows.Count > 0 Then
                    lblMainTitle.Text = txtFieldCode.Value & ": " & tblFieldProperties.Rows(0).Item("VietFieldName")
                End If
            End If

            ' Get subfields of the selected field
            objBField.FieldCode = txtFieldCode.Value.Trim
            tblSubFields = objBField.GetSubFields
            strSubFields = ""
            If Not tblSubFields Is Nothing Then
                If tblSubFields.Rows.Count > 0 Then
                    ' Create javascript code
                    strJavascript = strJavascript & "function Tag(taglabel, tagname, tagrepeat, tagmand, taglen, tagtype, tagref, tagcode) {" & Chr(13)
                    strJavascript = strJavascript & "this.taglabel = taglabel;" & Chr(13)
                    strJavascript = strJavascript & "this.tagname  = tagname;" & Chr(13)
                    strJavascript = strJavascript & "this.tagrepeat = tagrepeat;" & Chr(13)
                    strJavascript = strJavascript & "this.tagmand = tagmand;" & Chr(13)
                    strJavascript = strJavascript & "this.taglen = taglen;" & Chr(13)
                    strJavascript = strJavascript & "this.tagtype = tagtype;" & Chr(13)
                    strJavascript = strJavascript & "this.tagref = tagref;" & Chr(13)
                    strJavascript = strJavascript & "this.tagcode = tagcode;" & Chr(13)
                    strJavascript = strJavascript & "}" & Chr(13)
                    strJavascript = strJavascript & "Tags = new Array(" & tblSubFields.Rows.Count - 1 & ");" & Chr(13)
                    For intCounter = 0 To tblSubFields.Rows.Count - 1
                        strSubField = Right(tblSubFields.Rows(intCounter).Item("FieldCode"), 2)
                        strSubFields = strSubFields & strSubField & ","
                        ' Javascript code
                        If Not LCase(Session("InterfaceLanguage")) = "english" Then
                            strTagName = tblSubFields.Rows(intCounter).Item("VietFieldName").ToString.Trim
                        Else
                            strTagName = tblSubFields.Rows(intCounter).Item("FieldName").ToString.Trim
                        End If
                        If Not CInt(tblSubFields.Rows(intCounter).Item("Repeatable")) = 0 Then
                            intTagRepeat = 1
                        Else
                            intTagRepeat = 0
                        End If
                        If Not CInt(tblSubFields.Rows(intCounter).Item("Coded")) = 0 Then
                            strTagCode = 1
                        Else
                            strTagCode = 0
                        End If
                        If Not CInt(tblSubFields.Rows(intCounter).Item("Mandatory")) = 0 Then
                            intTagMand = 1
                        Else
                            intTagMand = 0
                        End If
                        If Not IsDBNull(tblSubFields.Rows(intCounter).Item("DicID")) Then
                            intDicID = CInt(tblSubFields.Rows(intCounter).Item("DicID"))
                        Else
                            intDicID = 0
                        End If
                        strJavascript = strJavascript & "Tags[" & intCounter & "] = new Tag(""" & strSubField & """, """ & strTagName & """, " & intTagRepeat & ", " & intTagMand & ", " & tblSubFields.Rows(intCounter).Item("Length") & ", " & tblSubFields.Rows(intCounter).Item("FieldTypeID") & ", " & intDicID & ", """ & strTagCode & """);" & Chr(13)
                    Next
                    strSubFields = Left(strSubFields, Len(strSubFields) - 1)
                    Page.RegisterClientScriptBlock("MainJs", "<script language = 'javascript'>" & strJavascript & "</script>")
                End If
            End If

            ' Parse input value into three array
            Dim arr1()
            Dim arr2()
            Dim arr3()
            Dim blnUpdate = False

            If Not txtValue.Value = "" Then
                Call objBCatalogueForm.ParseTag(strValue, arr1, arr2, arr3, intTagCount)
                txtFieldCount.Value = intTagCount

                If txtFieldCount.Value = "0" Then
                    txtFieldCount.Value = 5
                    blnUpdate = False
                Else
                    blnUpdate = True
                End If
                txtValue.Value = ""
            End If

            intTagCount = CInt(txtFieldCount.Value)

            ' Create view form
            strTableData = strTableData & "<TABLE Width=""100%"" cellpadding=""0"" cellspacing=""4"" border=""0"">" & Chr(10)
            intCounter = 1

            ' Body
            If txtBreakType.Value = "add" Then
                For intCounter = 1 To CInt(txtBreakPoint.Value)
                    strTableData = strTableData & DisplayField(intCounter, Request("TPick" & intCounter), Request("TVal" & intCounter))
                Next
                strTableData = strTableData & DisplayField(CInt(txtBreakPoint.Value) + 1, "", "")
                For intCounter = CInt(txtBreakPoint.Value) + 2 To intTagCount
                    strTableData = strTableData & DisplayField(intCounter, Request("TPick" & intCounter - 1), Request("TVal" & intCounter - 1))
                Next
            ElseIf txtBreakType.Value = "rem" Then
                For intCounter = 1 To CInt(txtBreakPoint.Value) - 1
                    strTableData = strTableData & DisplayField(intCounter, Request("TPick" & intCounter), Request("TVal" & intCounter))
                Next
                For intCounter = CInt(txtBreakPoint.Value) To intTagCount
                    strTableData = strTableData & DisplayField(intCounter, Request("TPick" & intCounter + 1), Request("TVal" & intCounter + 1))
                Next
            Else
                For intCounter = 1 To intTagCount
                    strTableData = strTableData & DisplayField(intCounter, "", "")
                Next
            End If

            Dim strJS As String = "maxtab = " & intTagCount & ";" & Chr(13)
            For intCounter = 1 To intTagCount
                strJS = strJS & "PickTag(document.forms[0].TPick" & intCounter & ".options[document.forms[0].TPick" & intCounter & ".selectedIndex].value, " & intCounter & ", '" & Request("TSign" & intCounter) & "', '" & ddlLabel.Items(2).Text & "');" & Chr(13)
            Next
            If blnUpdate Then
                Dim intIndex As Integer
                For intIndex = 0 To UBound(arr1)
                    strJS = strJS & "for (i = 0; i < document.forms[0].TPick" & intIndex + 1 & ".options.length; i++) {" & Chr(13)
                    strJS = strJS & "if (document.forms[0].TPick" & intIndex + 1 & ".options[i].value == """ & arr1(intIndex) & """) {" & Chr(13)
                    strJS = strJS & "document.forms[0].TPick" & intIndex + 1 & ".selectedIndex = i;" & Chr(13)
                    strJS = strJS & "break;	" & Chr(13)
                    strJS = strJS & "}" & Chr(13)
                    strJS = strJS & "}" & Chr(13)
                    strJS = strJS & "document.forms[0].TVal" & intIndex + 1 & ".value = """ & arr2(intIndex) & """;" & Chr(13)
                    strJS = strJS & "document.forms[0].TSign" & intIndex + 1 & ".value = """ & arr3(intIndex) & """;" & Chr(13)
                Next
                For intIndex = 0 To UBound(arr1)
                    strJS = strJS & "PickTag(document.forms[0].TPick" & intIndex + 1 & ".options[document.forms[0].TPick" & intIndex + 1 & ".options.selectedIndex].value, " & intIndex + 1 & ", '', '" & ddlLabel.Items(2).Text & "');" & Chr(13)
                Next
            End If

            strTableData = strTableData & "</TABLE>" & Chr(10)
            strTableData = strTableData & "<script language = 'javascript'>" & strJS & "</script>"
            lblDetail.Text = strTableData
            btnUpdate.Attributes.Add("OnClick", "newMergeRecord('" & txtFieldCode.Value & "', " & intTagCount & "); top.closeDialog('Dialog_content');")

            ' Focus
            Dim strFocusJs As String

            If txtBreakType.Value = "add" Then
                strFocusJs = "if (document.forms[0].TVal" & (txtBreakPoint.Value + 1) & ") {document.forms[0].TPick" & (txtBreakPoint.Value + 1) & ".focus();}"
            ElseIf txtBreakType.Value = "rem" Then
                strFocusJs = "if (document.forms[0].TVal" & (txtBreakPoint.Value - 1) & ") {document.forms[0].TPick" & (txtBreakPoint.Value - 1) & ".focus();}"
            Else
                strFocusJs = "if (document.forms[0].TVal1) {document.forms[0].TPick1.focus();}"
            End If
            Page.RegisterClientScriptBlock("Focus", "<script language = 'javascript'>" & strFocusJs & "</script>")

            ' Release objects
            tblFieldProperties.Dispose()
            tblFieldProperties = Nothing
            tblSubFields.Dispose()
            tblSubFields = Nothing
        End Sub

        ' DisplayField method
        ' Purpose: Display informations if the selected field
        Function DisplayField(ByVal intIndex As Integer, ByVal strValue1 As String, ByVal strValue2 As String) As String
            Dim strResult As String
            Dim intCounter As Integer
            Dim arrSubTags()
            Dim strJavascript As String
            arrSubTags = Split(strSubFields, ",")

            If UBound(arrSubTags) > 0 Then
                strResult = strResult & "<TR BGCOLOR=""CCCCCC"">" & Chr(10)
                strResult = strResult & "<TD COLSPAN=""2"">" & Chr(10)
                strResult = strResult & "<INPUT RUNAT=""server"" TYPE""Text"" name=""TName" & intIndex & """ id=""TName" & intIndex & """ value="""" style=""background:#CCCCCC;border-top:none;border-right:none;border-left:none;border-bottom:none"" SIZE=70 onFocus=""this.blur()"">" & Chr(10)
                strResult = strResult & "</TD>" & Chr(10)
                strResult = strResult & "</TR>" & Chr(10)
                strResult = strResult & "<TR onMouseOver=""mOvr(this,'#FFCC99');"" onMouseOut=""mOut(this,'#EEEECC');""  onFocus=""mOvr(this,'#FFCC99');"" BGCOLOR=""EEEECC"">" & Chr(10)
                strResult = strResult & "<TD VALIGN=""TOP"">" & Chr(10)
                strResult = strResult & "<NOBR>" & Chr(10)
                strResult = strResult & "<INPUT RUNAT=""server"" TYPE""Text"" value="""" SIZE=1 MAXLENGTH=1 name=""TSign" & intIndex & """ id=""TSign" & intIndex & """ onFocus=""curtab = " & intIndex & """>" & Chr(10)
                strResult = strResult & "<SELECT RUNAT=""server"" name=""TPick" & intIndex & """ id=""TPick" & intIndex & """ onChange=""if (this.options[this.selectedIndex].value != '') {PickTag(this.options[this.selectedIndex].value, " & intIndex & ", '', '" & ddlLabel.Items(2).Text & "')}"" onFocus=""curtab = " & intIndex & """>" & Chr(10)
                strResult = strResult & "<OPTION value="""">" & Chr(10)
                For intCounter = LBound(arrSubTags) To UBound(arrSubTags)
                    strResult = strResult & "<OPTION value=" & arrSubTags(intCounter) & ">" & Right(arrSubTags(intCounter), 1) & Chr(10)
                Next
                strResult = strResult & "</SELECT>" & Chr(10)
                strResult = strResult & "</TD>" & Chr(10)
                strResult = strResult & "<TD VALIGN=""TOP""><NOBR>" & Chr(10)
                strResult = strResult & "<INPUT RUNAT=""server"" TYPE""Text"" SIZE=""85"" Class=""lbTextBox"" name=""TVal" & intIndex & """ id=""TVal" & intIndex & """ onFocus=""curtab = " & intIndex & """>" & Chr(10)
                strResult = strResult & "<INPUT RUNAT=""server"" TYPE=""button"" Class=""lbButton"" name=""AddTagButtn" & intIndex & """ id=""AddTagButtn" & intIndex & """ value=""+"" onClick=""AddTag(" & intIndex & ")"" onFocus=""curtab = " & intIndex & """ accesskey=""a"">" & Chr(10)
                strResult = strResult & "<INPUT RUNAT=""server"" TYPE=""button"" Class=""lbButton"" name=""RemTagButtn" & intIndex & """ id=""RemTagButtn" & intIndex & """ value="" - "" onClick=""RemoveTag(" & intIndex & ")"" onFocus=""curtab = " & intIndex & """ accesskey=""r"">" & Chr(10)
                strResult = strResult & "</TD>" & Chr(10)
                strResult = strResult & "</TR>" & Chr(10)
                strJavascript = ""
                If Not strValue1 = "" And Not strValue2 = "" Then
                    strJavascript = strJavascript & "for (i = 0; i < document.forms[0].TPick" & intIndex & ".options.length; i++) {" & Chr(13)
                    strJavascript = strJavascript & "if (document.forms[0].TPick" & intIndex & ".options[i].value == """ & strValue1 & """) {" & Chr(13)
                    strJavascript = strJavascript & "document.forms[0].TPick" & intIndex & ".selectedIndex = i;" & Chr(13)
                    strJavascript = strJavascript & "break;	" & Chr(13)
                    strJavascript = strJavascript & "}" & Chr(13)
                    strJavascript = strJavascript & "}" & Chr(13)
                    strJavascript = strJavascript & "document.forms[0].TVal" & intIndex & ".value = """ & strValue2 & """;" & Chr(13)
                    strResult = strResult & "<script language = 'javascript'>" & strJavascript & "</script>" & Chr(13)
                End If
                Return strResult
            End If
        End Function

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBField Is Nothing Then
                    objBField.Dispose(True)
                    objBField = Nothing
                End If
                If Not objBCatalogueForm Is Nothing Then
                    objBCatalogueForm.Dispose(True)
                    objBCatalogueForm = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace