Imports eMicLibOPAC.BusinessRules.OPAC
Imports eMicLibOPAC.BusinessRules.Common

Namespace eMicLibOPAC.WebUI.OPAC
    Public Class OSearchAdvanced
        Inherits clsWBaseJqueryUI
        Private objBOPACItem As New clsBOPACItem
        Private objBSearchQr As New clsBOPACSearchQuery
        Private objBOPACDictionary As New clsBOPACDictionary
        Private objBDB As New clsBCommonDBSystem
        Private objBSysLibrary As New clsBSysLibrary
        Private objBCommonStringProc As New clsBCommonStringProc


        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Call Initialize()
            Call BindJavascript()
            If Not Page.IsPostBack Then
                Call BindData()
                Call BindDropDowlistSort()
            End If
        End Sub


        ' purpose : Init all objects
        Private Sub Initialize()
            '  Init objBCommonStringProc
            objBCommonStringProc.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBCommonStringProc.ConnectionString = Session("ConnectionString")
            objBCommonStringProc.DBServer = Session("DBServer")
            objBCommonStringProc.Initialize()

            ' Init objBSysLibrary object
            objBSysLibrary.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBSysLibrary.DBServer = Session("DBServer")
            objBSysLibrary.ConnectionString = Session("ConnectionString")
            objBSysLibrary.Initialize()

            ' Init objBOPACDictionary object
            objBOPACDictionary.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBOPACDictionary.DBServer = Session("DBServer")
            objBOPACDictionary.ConnectionString = Session("ConnectionString")
            Call objBOPACDictionary.Initialize()

            ' Init objBOPACItem object
            objBOPACItem.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBOPACItem.DBServer = Session("DBServer")
            objBOPACItem.ConnectionString = Session("ConnectionString")
            Call objBOPACItem.Initialize()

            ' init objBSearchQr object
            objBSearchQr.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBSearchQr.DBServer = Session("DBServer")
            objBSearchQr.ConnectionString = Session("ConnectionString")
            objBSearchQr.Initialize()

            ' Init objBDB object
            objBDB.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBDB.DBServer = Session("DBServer")
            objBDB.ConnectionString = Session("ConnectionString")
            Call objBDB.Initialize()

            If Session("SecuredOPAC") & "" <> "" Then
                objBSearchQr.SecuredOPAC = True
            Else
                objBSearchQr.SecuredOPAC = False
            End If

            If clsSession.GlbUserLevel & "" <> "" Then
                objBSearchQr.AccessLevel = clsSession.GlbUserLevel
            End If
        End Sub

        Private Sub BindDropDowlistSort()
            Dim tblPara As DataTable
            objBDB.SQLStatement = "SELECT Val FROM Sys_tblParameter WHERE Name = 'ALLOW_CUSTOM_SORT_IN_OPAC'"
            tblPara = objBDB.RetrieveItemInfor
            If tblPara.Rows(0).Item(0) = 0 Then
                ddlSort.Visible = False
            Else
                ddlSort.Visible = True
                Dim intSort As Integer = 0
                If Not IsNothing(clsSession.GlbOrderBy) AndAlso clsSession.GlbOrderBy <> "" Then
                    Select Case clsSession.GlbOrderBy
                        Case "TITLE"
                            intSort = 1
                        Case "AUTHOR"
                            intSort = 1
                        Case "YEAR"
                            intSort = 3
                        Case "PUBLISH"
                            intSort = 4
                    End Select
                End If
                ddlSort.SelectedIndex = intSort
            End If
        End Sub

        Private Sub BindJavascript()
            'Page.RegisterClientScriptBlock("SelfJs", "<script language='javascript' src='JS/OSearchAdvanced.js'></script>")
            'ddlFormat.Attributes.Add("OnChange", "document.forms[0].ValDocType.value=GetValueDDL('ddlFormat')")
            'btnReset.Attributes.Add("Onclick", "return ResetAll()")
            ' btnSearch.Attributes.Add("Onclick", "return ValidData()")
        End Sub

        Private Sub BindData()
            Dim inti As Integer

            'set text and value for dropdownlist document type
            Dim strResult As String = ""
            Dim dtTemp As DataTable = objBOPACItem.GetDicItemType(clsSession.GlbSite)
            If Not IsNothing(dtTemp) AndAlso dtTemp.Rows.Count > 0 Then
                For inti = 0 To dtTemp.Rows.Count - 1
                    'strResult &= "<label>"
                    'strResult &= "<input type='checkbox' id='chkMaterialType" & dtTemp.Rows(inti).Item("ID") & "' onclick='setIdFromCheckBoxForMaterialType(this.id)' value='" & dtTemp.Rows(inti).Item("ID") & "'/>"
                    'strResult &= "<span class='check'></span>"
                    'If Not IsDBNull(dtTemp.Rows(inti).Item("TypeName")) Then
                    '    strResult &= dtTemp.Rows(inti).Item("TypeName")
                    'End If
                    'strResult &= "</label>"
                    strResult &= "<div class=""checkbox-control"">"
                    strResult &= "<input type='checkbox' id='chkMaterialType" & dtTemp.Rows(inti).Item("ID") & "'  onclick='setIdFromCheckBoxForMaterialType(this.id)' value='" & dtTemp.Rows(inti).Item("ID") & "'/>"
                    strResult &= "<label for='chkMaterialType" & dtTemp.Rows(inti).Item("ID") & "'>"
                    If Not IsDBNull(dtTemp.Rows(inti).Item("TypeName")) Then
                        strResult &= dtTemp.Rows(inti).Item("TypeName")
                    End If
                    strResult &= "</label>"
                    strResult &= "</div>"
                Next
            End If
            ltrMaterialType.Text = strResult

            strResult = ""
            objBSysLibrary.Language = clsSession.GlbLanguage
            dtTemp = objBSysLibrary.SysGetAllLibrary
            If Not IsNothing(dtTemp) AndAlso dtTemp.Rows.Count > 0 Then
                For inti = 0 To dtTemp.Rows.Count - 1
                    'strResult &= "<label>"
                    'strResult &= "<input type='checkbox' id='chkLibrary" & dtTemp.Rows(inti).Item("LibId") & "'  onclick='setIdFromCheckBoxForLibrary(this.id)' value='" & dtTemp.Rows(inti).Item("LibId") & "'/>"
                    'strResult &= "<span class='check'></span>"
                    'If Not IsDBNull(dtTemp.Rows(inti).Item("LibName")) Then
                    '    strResult &= dtTemp.Rows(inti).Item("LibName")
                    'End If
                    'strResult &= "</label>"
                    strResult &= "<div class=""checkbox-control"">"
                    strResult &= "<input type='checkbox' id='chkLibrary" & dtTemp.Rows(inti).Item("LibId") & "'  onclick='setIdFromCheckBoxForLibrary(this.id)' value='" & dtTemp.Rows(inti).Item("LibId") & "'/>"
                    strResult &= "<label for='chkLibrary" & dtTemp.Rows(inti).Item("LibId") & "'>"
                    If Not IsDBNull(dtTemp.Rows(inti).Item("LibName")) Then
                        strResult &= dtTemp.Rows(inti).Item("LibName")
                    End If
                    strResult &= "</label>"
                    strResult &= "</div>"
                Next
            End If
            ltrLibrary.Text = strResult

            'ddlFormat.DataSource = InsertOneRow(objBOPACItem.GetDicItemType, lblItemType.Text)
            'ddlFormat.DataTextField = "TypeName"
            'ddlFormat.DataValueField = "ID"
            'ddlFormat.DataBind()
            'For inti = 0 To ddlFormat.Items.Count - 1
            '    If ddlFormat.Items(inti).Value = ValDocType.Value Then
            '        ddlFormat.Items(inti).Selected = True
            '        Exit For
            '    End If
            'Next

            ddlFieldName1.DataSource = objBOPACDictionary.GetCatDicList2Field
            ddlFieldName1.DataTextField = "Name"
            ddlFieldName1.DataValueField = "ID"
            ddlFieldName1.DataBind()
            ddlFieldName1.Items.Insert(0, lbAllField.Text)
            ddlFieldName1.Items.Insert(1, lbTitleInDDL.Text)
            ddlFieldName1.Items.Insert(3, lblNamXuatBan.Text)
            ddlFieldName1.Items.Insert(6, lblDangTaiLieu.Text)
            ddlFieldName1.Items.Insert(2, lblISBN.Text)
            'ddlFieldName1.Items.Insert(3, lblISSN.Text)
            ddlFieldName1.Items.Insert(4, lblMXG.Text)
            ddlFieldName1.Items(0).Value = "fulltext"
            ddlFieldName1.Items(1).Value = "title"
            ddlFieldName1.Items(3).Value = "author"
            ddlFieldName1.Items(6).Value = "publisher"
            ddlFieldName1.Items(2).Value = "ISBN"
            'ddlFieldName1.Items(3).Value = "ISSN"
            ddlFieldName1.Items(4).Value = "copynumber"

            For i As Integer = 14 To 7 Step -1
                ddlFieldName1.Items.RemoveAt(i)
            Next

            ddlFieldName1.SelectedIndex = 0


            ddlFieldName2.DataSource = ddlFieldName1.DataSource
            ddlFieldName2.DataTextField = "Name"
            ddlFieldName2.DataValueField = "ID"
            ddlFieldName2.DataBind()
            ddlFieldName2.Items.Insert(0, lbAllField.Text)
            ddlFieldName2.Items.Insert(1, lbTitleInDDL.Text)
            ddlFieldName2.Items.Insert(3, lblNamXuatBan.Text)
            ddlFieldName2.Items.Insert(6, lblDangTaiLieu.Text)
            ddlFieldName2.Items.Insert(2, lblISBN.Text)
            'ddlFieldName2.Items.Insert(3, lblISSN.Text)
            ddlFieldName2.Items.Insert(4, lblMXG.Text)
            ddlFieldName2.Items(0).Value = "fulltext"
            ddlFieldName2.Items(1).Value = "title"
            ddlFieldName2.Items(3).Value = "author"
            ddlFieldName2.Items(6).Value = "publisher"
            ddlFieldName2.Items(2).Value = "ISBN"
            'ddlFieldName2.Items(3).Value = "ISSN"
            ddlFieldName2.Items(4).Value = "copynumber"

            For i As Integer = 14 To 7 Step -1
                ddlFieldName2.Items.RemoveAt(i)
            Next

            ddlFieldName2.SelectedIndex = 0

            ddlFieldName3.DataSource = ddlFieldName1.DataSource
            ddlFieldName3.DataTextField = "Name"
            ddlFieldName3.DataValueField = "ID"
            ddlFieldName3.DataBind()
            ddlFieldName3.Items.Insert(0, lbAllField.Text)
            ddlFieldName3.Items.Insert(1, lbTitleInDDL.Text)
            ddlFieldName3.Items.Insert(3, lblNamXuatBan.Text)
            ddlFieldName3.Items.Insert(6, lblDangTaiLieu.Text)
            ddlFieldName3.Items.Insert(2, lblISBN.Text)
            'ddlFieldName3.Items.Insert(3, lblISSN.Text)
            ddlFieldName3.Items.Insert(4, lblMXG.Text)
            ddlFieldName3.Items(0).Value = "fulltext"
            ddlFieldName3.Items(1).Value = "title"
            ddlFieldName3.Items(3).Value = "author"
            ddlFieldName3.Items(6).Value = "publisher"
            ddlFieldName3.Items(2).Value = "ISBN"
            'ddlFieldName3.Items(3).Value = "ISSN"
            ddlFieldName3.Items(4).Value = "copynumber"

            For i As Integer = 14 To 7 Step -1
                ddlFieldName3.Items.RemoveAt(i)
            Next

            ddlFieldName3.SelectedIndex = 0


            'ddlFieldName4.DataSource = ddlFieldName1.DataSource
            'ddlFieldName4.DataTextField = "Name"
            'ddlFieldName4.DataValueField = "ID"
            'ddlFieldName4.DataBind()
            'ddlFieldName4.Items.Insert(0, lbAllField.Text)
            'ddlFieldName4.Items.Insert(1, lbTitleInDDL.Text)
            'ddlFieldName4.Items.Insert(2, lblISBN.Text)
            'ddlFieldName4.Items.Insert(3, lblISSN.Text)
            'ddlFieldName4.Items.Insert(4, lblMXG.Text)
            'ddlFieldName4.Items(0).Value = "FullText"
            'ddlFieldName4.Items(1).Value = "Title"
            'ddlFieldName4.Items(2).Value = "ISBN"
            'ddlFieldName4.Items(3).Value = "ISSN"
            'ddlFieldName4.Items(4).Value = "copynumber"
            'ddlFieldName4.SelectedIndex = 0

        End Sub

        ' Purpose: form data to array
        ' In: all Input data
        ' Creator : PhuongTT-2014.10.10
        Private Sub CreateArray()
            Dim arrValue() As String
            Dim arrName() As String
            Dim arrBool() As String
            Dim intCount As Integer
            Dim colData As New Collection
            Dim strSort As String = ""
            Dim intMutiLibrary As Integer = 0

            intCount = 0
            If txtFieldValue1.Value <> "" Then
                ReDim Preserve arrValue(intCount)
                ReDim Preserve arrName(intCount)
                ReDim Preserve arrBool(intCount)

                Select Case ddlPrefix1.SelectedValue
                    Case 0
                        'arrValue(intCount) = "%" & txtFieldValue1.Value & "%"
                        arrValue(intCount) = txtFieldValue1.Value.Trim()
                        arrValue(intCount) = objBCommonStringProc.ProcessVal(arrValue(intCount))
                        arrValue(intCount) = Replace(arrValue(intCount), "'", "''")
                    Case 1
                        arrValue(intCount) = "$*" & txtFieldValue1.Value & "*$"
                    Case 2
                        arrValue(intCount) = txtFieldValue1.Value & "%"
                    Case 3
                        arrValue(intCount) = "%" & txtFieldValue1.Value
                        'Case 4
                        '    arrValue(intCount) = ">=" & txtFieldValue1.Value
                        'Case 5
                        '    arrValue(intCount) = "<=" & txtFieldValue1.Value
                        'Case 6
                        '    arrValue(intCount) = ">=" & txtFieldValue1.Value
                        'Case 7
                        '    arrValue(intCount) = "<=" & txtFieldValue1.Value
                End Select
                arrName(intCount) = ddlFieldName1.SelectedValue
                arrBool(intCount) = "AND"
                intCount = intCount + 1
            End If
            If txtFieldValue2.Value <> "" Then
                ReDim Preserve arrValue(intCount)
                ReDim Preserve arrName(intCount)
                ReDim Preserve arrBool(intCount)
                Select Case ddlPrefix2.SelectedValue
                    Case 0
                        'arrValue(intCount) = "%" & txtFieldValue2.Value & "%"
                        arrValue(intCount) = txtFieldValue2.Value.Trim()
                        arrValue(intCount) = objBCommonStringProc.ProcessVal(arrValue(intCount))
                        arrValue(intCount) = Replace(arrValue(intCount), "'", "''")
                    Case 1
                        arrValue(intCount) = "$*" & txtFieldValue2.Value & "*$"
                    Case 2
                        arrValue(intCount) = txtFieldValue2.Value & "%"
                    Case 3
                        arrValue(intCount) = "%" & txtFieldValue2.Value
                        'Case 4
                        '    arrValue(intCount) = ">=" & txtFieldValue2.Value
                        'Case 5
                        '    arrValue(intCount) = "<=" & txtFieldValue2.Value
                        'Case 6
                        '    arrValue(intCount) = ">=" & txtFieldValue2.Value
                        'Case 7
                        '    arrValue(intCount) = "<=" & txtFieldValue2.Value
                End Select
                arrName(intCount) = ddlFieldName2.SelectedValue
                arrBool(intCount) = ddlOperator2.SelectedValue
                intCount = intCount + 1
            End If
            If txtFieldValue3.Value <> "" Then
                ReDim Preserve arrValue(intCount)
                ReDim Preserve arrName(intCount)
                ReDim Preserve arrBool(intCount)
                Select Case ddlPrefix3.SelectedValue
                    Case 0
                        'arrValue(intCount) = "%" & txtFieldValue3.Value & "%"
                        arrValue(intCount) = txtFieldValue3.Value.Trim()
                        arrValue(intCount) = objBCommonStringProc.ProcessVal(arrValue(intCount))
                        arrValue(intCount) = Replace(arrValue(intCount), "'", "''")
                    Case 1
                        arrValue(intCount) = "$*" & txtFieldValue3.Value & "*$"
                    Case 2
                        arrValue(intCount) = txtFieldValue3.Value & "%"
                    Case 3
                        arrValue(intCount) = "%" & txtFieldValue3.Value
                        'Case 4
                        '    arrValue(intCount) = ">=" & txtFieldValue3.Value
                        'Case 5
                        '    arrValue(intCount) = "<=" & txtFieldValue3.Value
                        'Case 6
                        '    arrValue(intCount) = ">=" & txtFieldValue3.Value
                        'Case 7
                        '    arrValue(intCount) = "<=" & txtFieldValue3.Value
                End Select
                arrName(intCount) = ddlFieldName3.SelectedValue
                arrBool(intCount) = ddlOperator3.SelectedValue
                intCount = intCount + 1
            End If
            'If txtFieldValue4.Text <> "" Then
            '    ReDim Preserve arrValue(intCount)
            '    ReDim Preserve arrName(intCount)
            '    ReDim Preserve arrBool(intCount)
            '    Select Case ddlPrefix4.SelectedValue
            '        Case 0
            '            arrValue(intCount) = "%" & txtFieldValue4.Text & "%"
            '        Case 1
            '            arrValue(intCount) = "$*" & txtFieldValue4.Text & "*$"
            '        Case 2
            '            arrValue(intCount) = txtFieldValue4.Text & "%"
            '        Case 3
            '            arrValue(intCount) = "%" & txtFieldValue4.Text
            '            'Case 4
            '            '    arrValue(intCount) = ">=" & txtFieldValue4.Text
            '            'Case 5
            '            '    arrValue(intCount) = "<=" & txtFieldValue4.Text
            '            'Case 6
            '            '    arrValue(intCount) = ">=" & txtFieldValue4.Text
            '            'Case 7
            '            '    arrValue(intCount) = "<=" & txtFieldValue4.Text
            '    End Select
            '    arrName(intCount) = ddlFieldName4.SelectedValue
            '    arrBool(intCount) = ddlOperator4.SelectedValue
            '    intCount = intCount + 1
            'End If
            'If Trim(ddlFormat.SelectedValue & "") <> "" Then
            '    ReDim Preserve arrValue(intCount)
            '    ReDim Preserve arrName(intCount)
            '    ReDim Preserve arrBool(intCount)
            '    arrValue(intCount) = ddlFormat.SelectedValue
            '    arrName(intCount) = "ItemType"
            '    arrBool(intCount) = "AND"
            '    intCount = intCount + 1
            '    colData.Add(ddlFormat.SelectedValue, "ItemType")
            'End If

            If chkPublisherYear1.Checked Then
                Dim intYear As Integer = Now.Year
                intYear -= ddlPublisherYear.SelectedValue
                ReDim Preserve arrValue(intCount)
                ReDim Preserve arrName(intCount)
                ReDim Preserve arrBool(intCount)
                arrValue(intCount) = intYear
                arrName(intCount) = "PublishYear"
                arrBool(intCount) = "AND"
                intCount = intCount + 1
                colData.Add(intYear, "PublishYear")
            ElseIf chkPublisherYear2.Checked Then
                Dim intYearFrom As Integer = 0
                Dim intYearTo As Integer = Now.Year
                If txtPublisherYearFrom.Value.Trim <> "" Then
                    intYearFrom = txtPublisherYearFrom.Value.Trim
                End If
                If txtPublisherYearTo.Value.Trim <> "" Then
                    intYearTo = txtPublisherYearTo.Value.Trim
                End If
                Dim strYear As String = intYearFrom.ToString & "-" & intYearTo.ToString
                ReDim Preserve arrValue(intCount)
                ReDim Preserve arrName(intCount)
                ReDim Preserve arrBool(intCount)
                arrValue(intCount) = strYear
                arrName(intCount) = "PublishYear"
                arrBool(intCount) = "AND"
                intCount = intCount + 1
                colData.Add(strYear, "PublishYear")
            End If

            If hdMaterialType.Value <> "" Then
                Dim strMaterialTypeIds As String = objBCommonStringProc.getIdsSring(hdMaterialType.Value)
                ReDim Preserve arrValue(intCount)
                ReDim Preserve arrName(intCount)
                ReDim Preserve arrBool(intCount)
                arrValue(intCount) = strMaterialTypeIds
                arrName(intCount) = "ItemType"
                arrBool(intCount) = "AND"
                intCount = intCount + 1
                colData.Add(strMaterialTypeIds, "ItemType")
            End If

            If hdLibraryIds.Value <> "" Then
                Dim strLibIds As String = objBCommonStringProc.getIdsSring(hdLibraryIds.Value)
                ReDim Preserve arrValue(intCount)
                ReDim Preserve arrName(intCount)
                ReDim Preserve arrBool(intCount)
                arrValue(intCount) = strLibIds
                arrName(intCount) = "LibraryType"
                arrBool(intCount) = "AND"
                intCount = intCount + 1
                colData.Add(strLibIds, "LibraryType")
                intMutiLibrary = 1
            End If

            If Trim(ddlSort.SelectedValue & "") <> "" Then
                strSort = ddlSort.SelectedValue
                colData.Add(ddlSort.SelectedValue, "SortBy")
                clsSession.GlbOrderBy = strSort
            Else
                strSort = ""
                colData.Add("", "SortBy")
            End If
            objBSearchQr.SortBy = strSort
            objBSearchQr.NameArray = arrName
            objBSearchQr.ValueArray = arrValue
            objBSearchQr.BoolArray = arrBool
            objBSearchQr.SearchMode = "ADVANCE"
            colData.Add("ADVANCE", "SearchMode")
            'If optISBD.Checked Then
            '    colData.Add("ISBD", "Display")
            'Else
            '    colData.Add("Simple", "Display")
            'End If
            colData.Add("Simple", "Display")
            Session("colSearch") = colData
            'clsSession.GlbIds = objBSearchQr.ExecuteQueryOPAC()
            clsSession.GlbSQLStatement = objBSearchQr.FormingSQL
            If Not clsSession.GlbSQLStatement Is Nothing AndAlso clsSession.GlbSQLStatement <> "" Then
                Response.Redirect("OShow.aspx?searchAdvanced=1&MutiLibrary=" & intMutiLibrary)
            Else
                Page.RegisterClientScriptBlock("AlertMsg", "<script language='javascript'>alert('" & lblMsgNotFound.Text & "')</script>")
            End If
        End Sub

        ' Search action
        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            Call CreateArray()
        End Sub


        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: Release all object
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCommonStringProc Is Nothing Then
                    objBCommonStringProc.Dispose(True)
                    objBCommonStringProc = Nothing
                End If
                If Not objBOPACItem Is Nothing Then
                    objBOPACItem.Dispose(True)
                    objBOPACItem = Nothing
                End If
                If Not objBOPACDictionary Is Nothing Then
                    objBOPACDictionary.Dispose(True)
                    objBOPACDictionary = Nothing
                End If
                If Not objBSearchQr Is Nothing Then
                    objBSearchQr.Dispose(True)
                    objBSearchQr = Nothing
                End If
                If Not objBSysLibrary Is Nothing Then
                    objBSysLibrary.Dispose(True)
                    objBSysLibrary = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

    End Class
End Namespace
