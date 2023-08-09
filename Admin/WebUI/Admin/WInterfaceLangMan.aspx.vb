' Class: WInterfaceLangMan
' Puspose: Display language 
' Creator: Tuanhv
' CreatedDate: 10/05/2005
' Modification History:

Imports eMicLibAdmin.BusinessRules.Admin
Imports System.IO

Namespace eMicLibAdmin.WebUI.Admin
    Partial Class WInterfaceLangMan
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents tblResult As System.Web.UI.WebControls.Table


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Dim strFoder As String
        Dim tblFilexml As DataTable
        Dim strFileName As String = ""
        Dim strFilePath As String = ""
        Dim fs As StreamWriter
        Dim tblTest As DataTable

        Dim strSlip As String = "|+|"
        Dim intlenSlip As String = Len(strSlip)
        Dim strSlipTable As String = "|++|"
        Dim intlenSlipTable As String = Len(strSlipTable)

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Call ExportResource()
            strFoder = Request("FormID")
            hidFilexml.Value = Replace(strFoder, "/", "$&")
            If Not Page.IsPostBack Then
                If Not strFoder Is Nothing AndAlso strFoder <> "" Then
                    Call BindLangFromXml()
                    Call BindData()
                End If
            End If
            ' Must put BindScript here
            Call BindScript()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("LoadLangJs", "<script language = 'javascript' src = 'Js/WInterfaceLangMan.js'></script>")

            btnUpdate.Attributes.Add("OnClick", "EncryptionTags('dgrResult','txtdtgSource','txtdtgDes'," & hdMax.Value & "); return true;")
            btnChange.Attributes.Add("OnClick", "EncryptionTags('dgrResult','txtdtgSource','txtdtgDes'," & hdMax.Value & "); return true;")
            btnAddNew.Attributes.Add("OnClick", "if ((CheckLang('hidLanguages','txtLanguageName')) && (!CheckNull('document.forms[0].txtLanguageName'))) {EncryptionTags('dgrResult','txtdtgSource','txtdtgDes'," & hdMax.Value & ");} else {alert('" & ddlLabel.Items(0).Text & "'); return false;}")
            Dim strFormID As String = Server.MapPath("..") & "/Resources/LabelString"
            If Request("Root") & "" <> "" Then
                strFormID = Request("Root")
                lnkGoBack.NavigateUrl = "WManLanguageFrame.aspx" '"WLanguageEditor.aspx?FormID=" & strFormID & "#" & Request("IndexRow")
            Else
                lnkGoBack.NavigateUrl = "WManLanguageFrame.aspx" '"WLanguageEditor.aspx?FormID=" & strFormID
            End If
        End Sub

        ' Method: GetXmlFile
        ' Purpose: Get content file type .xml return DataTable.
        Public Function GetXmlFile(ByVal strFileNameXml As String) As DataTable
            ' Use function ConvertTable
            Dim blnReadyFile As Boolean
            blnReadyFile = False
            Dim strName As String = ""
            Dim dsResource As New DataSet
            Try
                dsResource.ReadXml(strFileNameXml)
                If dsResource.Tables.Count > 0 Then
                    Select Case clsSession.GlbLanguage
                        Case "tcvn", "vni", "unicode"
                            Session("ColLanguage") = "unicode"
                        Case Else
                            Session("ColLanguage") = clsSession.GlbLanguage
                    End Select
                    GetXmlFile = dsResource.Tables(0)
                    dsResource.Tables.Clear()
                    blnReadyFile = True
                End If
            Catch ex As Exception
            Finally
            End Try
        End Function

        ' Method: BindLangFromXml
        ' Purpose: Get all language from file .xml insert in downloadgrid
        Private Sub BindLangFromXml()
            Dim arrText As Object
            Dim tblTemp As DataTable
            strFilePath = Replace(hidFilexml.Value, "$&", "/")
            tblTest = GetXmlFile(strFilePath)
            If tblTest Is Nothing Then
                Exit Sub
            End If
            ReDim arrText(tblTest.Columns.Count - 2)
            Dim inti As Integer
            hidLanguages.Value = ""
            For inti = 1 To tblTest.Columns.Count - 1
                arrText(inti - 1) = tblTest.Columns(inti).ColumnName
                hidLanguages.Value = hidLanguages.Value & tblTest.Columns(inti).ColumnName & ","
            Next
            If Len(hidLanguages.Value) > 0 Then
                hidLanguages.Value = Left(hidLanguages.Value, Len(hidLanguages.Value) - 1)
            End If
            tblTemp = CreateTable(arrText, arrText)
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlSource.DataSource = tblTemp
                ddlSource.DataTextField = "TextField"
                ddlSource.DataValueField = "ValueField"
                ddlSource.DataBind()

                ddlDes.DataSource = tblTemp
                ddlDes.DataTextField = "TextField"
                ddlDes.DataValueField = "ValueField"
                ddlDes.DataBind()
            End If
        End Sub

        ' Method: SubGetFileXml
        ' Popurse: Get all file type .xml in one forder have path is strFoder
        Private Sub SubGetFileAllXml(ByVal strFoder As String)
            Dim objDirInfor As DirectoryInfo
            Dim objFileInfor As FileInfo
            Dim strFoderName As String = ""
            Dim introw As Integer
            Dim tblItem As DataTable
            Dim tblRow As TableRow
            Dim tblCell1 As TableCell
            Dim tblCell2 As TableCell
            Dim dtvTest As DataView

            objDirInfor = New DirectoryInfo(strFoder)
            For Each objFileInfor In objDirInfor.GetFiles("*.xml")
                tblRow = New TableRow
                ' Content Link
                tblCell1 = New TableCell
                tblCell1.HorizontalAlign = HorizontalAlign.Left
                tblCell1.CssClass = "lbLabel"
                tblCell1.Width = Unit.Percentage(30%)
                tblCell1.VerticalAlign = VerticalAlign.Top

                ' Content file name
                tblCell2 = New TableCell
                tblCell2.HorizontalAlign = HorizontalAlign.Left
                tblCell2.CssClass = "lbLabel"

                strFileName = objFileInfor.Name
                strFilePath = objFileInfor.FullName
                hidFilexml.Value = Replace(strFilePath, "/", "$&")

                tblTest = GetXmlFile(strFilePath)
                If tblTest Is Nothing Then
                    Exit Sub
                End If
                dtvTest = tblTest.DefaultView
                Dim arrText As Object
                ReDim arrText(tblTest.Columns.Count - 2)
                Dim inti As Integer
                For inti = 1 To tblTest.Columns.Count - 1
                    arrText(inti - 1) = tblTest.Columns(inti).ColumnName
                Next
                Dim tblTemp As DataTable
                tblTemp = CreateTable(arrText, arrText)
                ddlSource.DataSource = tblTemp
                ddlSource.DataTextField = "TextField"
                ddlSource.DataValueField = "ValueField"
                ddlSource.DataBind()

                ddlDes.DataSource = tblTemp
                ddlDes.DataTextField = "TextField"
                ddlDes.DataValueField = "ValueField"
                ddlDes.DataBind()

                Dim lnkLink As New HyperLink
                lnkLink.NavigateUrl = "WManagementArticle.aspx?FileName=" & Trim(strFilePath)
                lnkLink.Text = "<img src='Images/tra_cuu_log.gif' border=0>"
                lnkLink.CssClass = "lbLinkFunction"
                lnkLink.ToolTip = ""
                tblCell1.Controls.Add(lnkLink)
                tblRow.Cells.Add(tblCell1)
                tblCell2.Controls.Add(New LiteralControl(strFileName))
                tblRow.Cells.Add(tblCell2)

                tblResult.Rows.Add(tblRow)
            Next
        End Sub

        ' Method: AddNewLang
        ' Purpose: Add new language for page.
        Private Sub AddNewLang(ByVal strColLanguageName As String, ByVal tblDataCur As DataTable)
            Dim inti As Integer
            Dim intj As Integer
            fs = File.CreateText(strFilePath)
            fs.WriteLine("<?xml version=""1.0"" encoding=""utf-8""?>")
            fs.WriteLine("<Head>")
            For intj = 0 To tblDataCur.Rows.Count - 1
                fs.WriteLine("<data>")
                For inti = 0 To tblDataCur.Columns.Count - 1
                    fs.WriteLine("<" & tblDataCur.Columns(inti).ColumnName & ">" & Replace(Replace(tblDataCur.Rows(intj).Item(inti), "<", "&lt;"), ">", "&gt;") & "</" & tblDataCur.Columns(inti).ColumnName & ">")
                Next
                fs.WriteLine("<" & strColLanguageName & ">" & "</" & strColLanguageName & ">")
                fs.WriteLine("</data>")
            Next
            fs.WriteLine("</Head>")
            fs.Close()
        End Sub


        ' Method: DelLangFile
        ' Popurse: Delete language for page.
        Private Sub DelLangFile(ByVal strColLanguageName As String, ByVal tblDataCur As DataTable)
            Dim inti As Integer
            Dim intj As Integer
            fs = File.CreateText(strFilePath)
            fs.WriteLine("<?xml version=""1.0"" encoding=""utf-8""?>")
            fs.WriteLine("<Head>")
            For intj = 0 To tblDataCur.Rows.Count - 1
                fs.WriteLine("<data>")
                For inti = 0 To tblDataCur.Columns.Count - 1
                    If tblDataCur.Columns(inti).ColumnName.ToUpper <> strColLanguageName.ToUpper Then
                        fs.WriteLine("<" & tblDataCur.Columns(inti).ColumnName & ">" & Replace(Replace(tblDataCur.Rows(intj).Item(inti), "<", "&lt;"), ">", "&gt;") & "</" & tblDataCur.Columns(inti).ColumnName & ">")
                    End If
                Next
                fs.WriteLine("</data>")
            Next
            fs.WriteLine("</Head>")
            fs.Close()
        End Sub


        ' Method: UpdateLangFile
        ' Popurse: Update language for page.
        Private Sub UpdateLangFile(ByVal strColLanguageNameOld As String, ByVal strColLanguageName As String, ByVal tblDataCur As DataTable)
            Dim inti As Integer
            Dim intj As Integer
            fs = File.CreateText(strFilePath)
            For inti = 0 To tblDataCur.Columns.Count - 1
                If tblDataCur.Columns(inti).ColumnName = strColLanguageNameOld Then
                    tblDataCur.Columns(inti).ColumnName = strColLanguageName
                End If
            Next
            fs.WriteLine("<?xml version=""1.0"" encoding=""utf-8""?>")
            fs.WriteLine("<Head>")
            For intj = 0 To tblDataCur.Rows.Count - 1
                fs.WriteLine("<data>")
                For inti = 0 To tblDataCur.Columns.Count - 1
                    fs.WriteLine("<" & tblDataCur.Columns(inti).ColumnName & ">" & Replace(Replace(tblDataCur.Rows(intj).Item(inti), "<", "&lt;"), ">", "&gt;") & "</" & tblDataCur.Columns(inti).ColumnName & ">")
                Next
                fs.WriteLine("</data>")
            Next
            fs.WriteLine("</Head>")
            fs.Close()
        End Sub

        ' Mwthod: dgrResult_PageIndexChanged
        Private Sub dgrResult_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrResult.PageIndexChanged
            dgrResult.CurrentPageIndex = e.NewPageIndex
            Call BindData()
        End Sub

        'Event: dtgCollection_CancelCommand
        Private Sub dgrResult_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrResult.CancelCommand
            dgrResult.EditItemIndex = -1
            Call BindData()
        End Sub

        'Event: dtgCollection_EditCommand
        Private Sub dgrResult_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrResult.EditCommand
            dgrResult.EditItemIndex = e.Item.ItemIndex
            Call BindData()
        End Sub

        ' Event: btnUpdate_Click
        ' Popurse: Update content view for all control in page.
        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Dim dtgItem As DataGridItem
            Dim lblControlN As Label
            Dim txtSourceN As TextBox
            Dim txtDesN As TextBox
            Dim objControlName As Object
            Dim objText As Object
            Dim objValue As Object
            Dim inti As Integer

            ReDim objControlName(dgrResult.Items.Count)
            ReDim objText(dgrResult.Items.Count)
            ReDim objValue(dgrResult.Items.Count)
            inti = 0
            For Each dtgItem In dgrResult.Items
                objControlName(inti) = dgrResult.Items(inti).Cells(0).Text
                txtSourceN = dtgItem.FindControl("txtdtgSource")
                objText(inti) = txtSourceN.Text
                txtDesN = dtgItem.FindControl("txtdtgDes")
                objValue(inti) = txtDesN.Text
                inti = inti + 1
            Next
            ' Get return 3 array
            Dim ArrTextFieldR As Object
            Dim ArrValueFieldR As Object
            Dim ArrControlNameR As Object

            Call Create3ArrayXml(objText, objValue, objControlName, ArrTextFieldR, ArrValueFieldR, ArrControlNameR)
            Dim strSource As String
            Dim strDes As String
            strSource = Trim(ddlSource.SelectedValue)
            strDes = Trim(ddlDes.SelectedValue)
            strFilePath = Replace(hidFilexml.Value, "$&", "/")
            tblTest = GetXmlFile(strFilePath)
            If tblTest Is Nothing Then
                Exit Sub
            End If
            Call ChangeContentLangXml(tblTest, ArrTextFieldR, ArrValueFieldR, strSource, strDes)
            Call BindData()
        End Sub

        ' Event: btnAddNew_Click
        ' Popurse:  Add new language for page.
        Private Sub btnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
            strFilePath = Replace(hidFilexml.Value, "$&", "/")
            tblTest = GetXmlFile(strFilePath)
            If tblTest Is Nothing Then
                Exit Sub
            End If
            Call AddNewLang(Trim(txtLanguageName.Text), tblTest)
            Call BindLangFromXml()
            Call BindData()
        End Sub


        ' Method: BindData
        ' Popurse: Get data form file type .xml about source language  and target language and content priview for all control with source and target language.
        Private Sub BindData()
            Dim arrText As Object
            Dim arrValue As Object
            Dim strSource As String
            Dim strDes As String
            Dim inti As Integer
            Dim tblTemp As DataTable
            Dim objDirInfor As DirectoryInfo
            Dim arrControl As Object
            Dim arrTextC As Object
            Dim arrValueC As Object
            Dim arrContentID As Object
            Dim intTotal As Integer = 0

            strSource = Trim(ddlSource.SelectedValue)
            strDes = Trim(ddlDes.SelectedValue)
            strFilePath = Replace(hidFilexml.Value, "$&", "/")
            tblTest = GetXmlFile(strFilePath)

            If Not tblTest Is Nothing AndAlso tblTest.Rows.Count > 0 Then
                ReDim arrText(tblTest.Rows.Count)
                ReDim arrValue(tblTest.Rows.Count)
                For inti = 0 To tblTest.Rows.Count - 1
                    ReDim Preserve arrControl(intTotal + 1)
                    Dim objText As Object
                    Dim objValue As Object

                    arrText(inti) = CStr(tblTest.Rows(inti).Item(strSource)).Trim
                    arrValue(inti) = CStr(tblTest.Rows(inti).Item(strDes)).Trim
                    objText = Split(arrText(inti), strSlip)
                    objValue = Split(arrValue(inti), strSlip)


                    If UBound(objText) > 0 Then
                        ReDim Preserve objValue(UBound(objText))
                        ReDim Preserve arrControl(intTotal + 1 + UBound(objText))
                        ReDim Preserve arrTextC(intTotal + 1 + UBound(objText))
                        ReDim Preserve arrValueC(intTotal + 1 + UBound(objText))
                        Dim intj As Integer
                        For intj = intTotal To UBound(arrControl) - 1
                            arrTextC(intj) = objText(intj - intTotal)
                            If IsNumeric(arrTextC(intj)) Then
                                arrValueC(intj) = arrTextC(intj)
                            Else
                                arrValueC(intj) = objValue(intj - intTotal)
                            End If
                            arrControl(intj) = tblTest.Rows(inti).Item("Name")
                        Next
                        intTotal = intTotal + 1 + UBound(objText)
                    Else
                        intTotal = intTotal + 1
                        ReDim Preserve objValue(UBound(objText))
                        ReDim Preserve arrControl(intTotal)
                        ReDim Preserve arrTextC(intTotal)
                        ReDim Preserve arrValueC(intTotal)
                        arrTextC(intTotal - 1) = objText(0)
                        If IsNumeric(arrTextC(intTotal - 1)) Then
                            arrValueC(intTotal - 1) = objText(0)
                        Else
                            arrValueC(intTotal - 1) = objValue(0)
                        End If
                        arrControl(intTotal - 1) = tblTest.Rows(inti).Item("Name")
                    End If
                Next
                ReDim Preserve arrControl(intTotal - 1)
                ReDim Preserve arrTextC(intTotal - 1)
                ReDim Preserve arrValueC(intTotal - 1)
                dgrResult.Visible = False
                tblTemp = CreateTable3Arr(arrTextC, arrValueC, arrControl)
                dgrResult.Visible = True
                dgrResult.DataSource = tblTemp
                dgrResult.DataBind()
                hdMax.Value = dgrResult.Items.Count
            End If
        End Sub

        ' Method: AddContentLangFile
        ' Create data for xml
        Private Sub CreateContentLangXml(ByVal tblDataCur As DataTable)
            Dim inti As Integer
            Dim intj As Integer
            fs = File.CreateText(strFilePath)
            fs.WriteLine("<?xml version=""1.0"" encoding=""utf-8""?>")
            fs.WriteLine("<Head>")
            For intj = 0 To tblDataCur.Rows.Count - 1
                fs.WriteLine("<data>")
                For inti = 0 To tblDataCur.Columns.Count - 1
                    fs.WriteLine("<" & tblDataCur.Columns(inti).ColumnName & ">" & Replace(Replace(tblDataCur.Rows(intj).Item(inti), "<", "&lt;"), ">", "&gt;") & "</" & tblDataCur.Columns(inti).ColumnName & ">")
                Next
                fs.WriteLine("</data>")
            Next
            fs.WriteLine("</Head>")
            fs.Close()
        End Sub

        ' Method: ChangeContentLangXml
        ' Purpose: Change data for file type .xml, content change in two language Source and target
        Private Sub ChangeContentLangXml(ByVal tblDataCur As DataTable, ByVal objSoure As Object, ByVal objDes As Object, ByVal strSource As String, ByVal strDes As String)
            Dim inti As Integer
            Dim intj As Integer
            fs = File.CreateText(strFilePath)
            fs.WriteLine("<?xml version=""1.0"" encoding=""utf-8""?>")
            fs.WriteLine("<Head>")
            For intj = 0 To tblDataCur.Rows.Count - 1
                fs.WriteLine("<data>")
                For inti = 0 To tblDataCur.Columns.Count - 1
                    If tblDataCur.Columns(inti).ColumnName = strSource Then
                        fs.WriteLine("<" & tblDataCur.Columns(inti).ColumnName & ">" & Replace(Replace(objSoure(intj), "<", "&lt;"), ">", "&gt;") & "</" & tblDataCur.Columns(inti).ColumnName & ">")
                    ElseIf tblDataCur.Columns(inti).ColumnName = strDes Then
                        fs.WriteLine("<" & tblDataCur.Columns(inti).ColumnName & ">" & Replace(Replace(objDes(intj), "<", "&lt;"), ">", "&gt;") & "</" & tblDataCur.Columns(inti).ColumnName & ">")
                    Else
                        fs.WriteLine("<" & tblDataCur.Columns(inti).ColumnName & ">" & Replace(Replace(tblDataCur.Rows(intj).Item(inti), "<", "&lt;"), ">", "&gt;") & "</" & tblDataCur.Columns(inti).ColumnName & ">")
                    End If
                Next
                fs.WriteLine("</data>")
            Next
            fs.WriteLine("</Head>")
            fs.Close()
        End Sub


        ' Method: Creat 3 array for File Xml
        ' Purpose: Create 3 array are "name", "Source language" and "Des language" 
        Private Sub Create3ArrayXml(ByVal ArrTextField As Object, ByVal ArrValueField As Object, ByVal ArrControlName As Object, ByRef ArrTextFieldR As Object, ByRef ArrValueFieldR As Object, ByRef ArrControlNameR As Object)
            Dim inti As Integer = 0
            Dim intTotal As Integer = 0
            Dim bolFlag As Boolean = False
            ReDim Preserve ArrControlNameR(1)
            ReDim Preserve ArrTextFieldR(1)
            ReDim Preserve ArrValueFieldR(1)

            While inti < UBound(ArrControlName)
                If ArrControlName(inti) = ArrControlName(inti + 1) Then
                    ReDim Preserve ArrControlNameR(intTotal + 1)
                    ReDim Preserve ArrTextFieldR(intTotal + 1)
                    ReDim Preserve ArrValueFieldR(intTotal + 1)
                    bolFlag = True
                    ArrControlNameR(intTotal) = ArrControlName(inti)
                    ArrTextFieldR(intTotal) = ArrTextFieldR(intTotal) & ArrTextField(inti) & strSlip
                    If Not ArrValueField(inti) Is Nothing AndAlso ArrValueField(inti) = "" Then
                        ArrValueField(inti) = " "
                    End If
                    ArrValueFieldR(intTotal) = ArrValueFieldR(intTotal) & ArrValueField(inti) & strSlip
                Else
                    If bolFlag Then
                        ArrTextFieldR(intTotal) = ArrTextFieldR(intTotal) & ArrTextField(inti) & strSlip
                        ArrControlNameR(intTotal) = ArrControlName(intTotal) & strSlip
                        If Not ArrValueField(inti) Is Nothing AndAlso ArrValueField(inti) = "" Then
                            ArrValueField(inti) = " "
                        End If
                        ArrValueFieldR(intTotal) = ArrValueFieldR(intTotal) & ArrValueField(inti) & strSlip
                        'ArrValueFieldR(intTotal) = ArrValueFieldR(intTotal) & strSlip
                        bolFlag = False
                        intTotal = intTotal + 1
                    Else
                        ReDim Preserve ArrControlNameR(intTotal + 1)
                        ReDim Preserve ArrTextFieldR(intTotal + 1)
                        ReDim Preserve ArrValueFieldR(intTotal + 1)
                        ArrControlNameR(intTotal) = ArrControlName(inti) & strSlip
                        ArrTextFieldR(intTotal) = ArrTextField(inti) & strSlip
                        If Not ArrValueField(inti) Is Nothing AndAlso ArrValueField(inti) = "" Then
                            ArrValueField(inti) = " "
                        End If
                        ArrValueFieldR(intTotal) = ArrValueField(inti) & strSlip
                        intTotal = intTotal + 1
                    End If
                End If
                inti = inti + 1
            End While
            For inti = 0 To UBound(ArrControlNameR) - 1
                If Len(ArrControlNameR(inti)) > 0 Then
                    ArrControlNameR(inti) = Left(ArrControlNameR(inti), Len(ArrControlNameR(inti)) - intlenSlip)
                End If
                If Len(ArrTextFieldR(inti)) > 0 Then
                    ArrTextFieldR(inti) = Left(ArrTextFieldR(inti), Len(ArrTextFieldR(inti)) - intlenSlip)
                End If
                If Len(ArrValueFieldR(inti)) > 0 Then
                    ArrValueFieldR(inti) = Left(ArrValueFieldR(inti), Len(ArrValueFieldR(inti)) - intlenSlip)
                End If
            Next
        End Sub


        ' Method: CreateTable3Arr
        ' Purpose: Create datatable from three array
        Public Function CreateTable3Arr(ByVal ArrTextField As Object, ByVal ArrValueField As Object, ByVal ArrControlName As Object) As DataTable
            Dim TblRet As New DataTable
            If IsArray(ArrTextField) And IsArray(ArrValueField) Then
                If UBound(ArrTextField) = UBound(ArrValueField) Then
                    Dim byti As Integer
                    Dim row As DataRow
                    If System.Type.GetType("System.String").Equals(ArrTextField(0).GetType) Then
                        TblRet.Columns.Add("TextField", System.Type.GetType("System.String"))
                    ElseIf System.Type.GetType("System.Int64").Equals(ArrTextField(0).GetType) Then
                        TblRet.Columns.Add("TextField", System.Type.GetType("System.Int64"))
                    ElseIf System.Type.GetType("System.Int32").Equals(ArrTextField(0).GetType) Then
                        TblRet.Columns.Add("TextField", System.Type.GetType("System.Int32"))
                    ElseIf System.Type.GetType("System.DateTime").Equals(ArrTextField(0).GetType) Then
                        TblRet.Columns.Add("TextField", System.Type.GetType("System.DateTime"))
                    ElseIf System.Type.GetType("System.Decimal").Equals(ArrTextField(0).GetType) Then
                        TblRet.Columns.Add("TextField", System.Type.GetType("System.Decimal"))
                    End If

                    If System.Type.GetType("System.String").Equals(ArrTextField(0).GetType) Then
                        TblRet.Columns.Add("ValueField", System.Type.GetType("System.String"))
                    ElseIf System.Type.GetType("System.Int64").Equals(ArrTextField(0).GetType) Then
                        TblRet.Columns.Add("ValueField", System.Type.GetType("System.Int64"))
                    ElseIf System.Type.GetType("System.Int32").Equals(ArrTextField(0).GetType) Then
                        TblRet.Columns.Add("ValueField", System.Type.GetType("System.Int32"))
                    ElseIf System.Type.GetType("System.DateTime").Equals(ArrTextField(0).GetType) Then
                        TblRet.Columns.Add("ValueField", System.Type.GetType("System.DateTime"))
                    ElseIf System.Type.GetType("System.Decimal").Equals(ArrTextField(0).GetType) Then
                        TblRet.Columns.Add("ValueField", System.Type.GetType("System.Decimal"))
                    End If

                    If System.Type.GetType("System.String").Equals(ArrControlName(0).GetType) Then
                        TblRet.Columns.Add("ControlName", System.Type.GetType("System.String"))
                    ElseIf System.Type.GetType("System.Int64").Equals(ArrControlName(0).GetType) Then
                        TblRet.Columns.Add("ControlName", System.Type.GetType("System.Int64"))
                    ElseIf System.Type.GetType("System.Int32").Equals(ArrControlName(0).GetType) Then
                        TblRet.Columns.Add("ControlName", System.Type.GetType("System.Int32"))
                    ElseIf System.Type.GetType("System.DateTime").Equals(ArrControlName(0).GetType) Then
                        TblRet.Columns.Add("ControlName", System.Type.GetType("System.DateTime"))
                    ElseIf System.Type.GetType("System.Decimal").Equals(ArrControlName(0).GetType) Then
                        TblRet.Columns.Add("ControlName", System.Type.GetType("System.Decimal"))
                    End If

                    For byti = 0 To UBound(ArrTextField)
                        row = TblRet.NewRow
                        row(0) = ArrTextField(byti)
                        row(1) = ArrValueField(byti)
                        row(2) = ArrControlName(byti)
                        TblRet.Rows.Add(row)
                    Next
                    CreateTable3Arr = TblRet
                Else
                    strErrorMsg = "Length of two Parameters not equal"
                    Exit Function
                End If
            Else
                strErrorMsg = "Parameter not an Array"
                Exit Function
            End If
        End Function

        ' Event: btnChange_Click
        Private Sub btnChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChange.Click
            Call BindData()
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
