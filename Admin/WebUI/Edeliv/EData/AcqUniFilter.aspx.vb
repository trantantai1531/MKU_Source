Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.WebUI.Common

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class Edeliv_EData_AcqUniFilter
        Inherits clsWBase

        ' Declare the class variables
        Private objBCDBS As New clsBCommonDBSystem
        Private objBFormingSQL As New clsBFormingSQL
        Private objBItem As New clsBItem
        Private objBIC As New clsBItemCollection
        Private objBEData As New eMicLibAdmin.BusinessRules.Edeliv.clsBEData

        ' Declare the module variables
        Private intSumFound As Integer = 0

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

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            If Not IsPostBack Then
                BindData()
                Dim intCollection As Integer = 0
                If Not IsNothing(Request("collection")) AndAlso Request("collection") <> "" Then
                    intCollection = Request("collection")
                End If
                If intCollection > 0 Then
                    If Not IsNothing(Request("addCollection")) AndAlso Request("addCollection") <> "1" Then
                        Call loadDataFilter(intCollection)
                    End If
                End If
            End If
            Call BindJS()
            Call BindHyperLink()
        End Sub

        ' Method: Initialize 
        ' Purpose: Init all need objects
        Sub Initialize()
            ' Init objBCSP object
            objBEData.DBServer = Session("DBServer")
            objBEData.ConnectionString = Session("ConnectionString")
            objBEData.InterfaceLanguage = Session("InterfaceLanguage")
            objBEData.Initialize()

            ' Init objBCDBS object
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            Call objBCDBS.Initialize()

            ' Init objBFormingSQL object
            objBFormingSQL.InterfaceLanguage = Session("InterfaceLanguage")
            objBFormingSQL.DBServer = Session("DBServer")
            objBFormingSQL.ConnectionString = Session("ConnectionString")
            Call objBFormingSQL.Initialize()

            ' Init ojbBItem object
            objBItem.InterfaceLanguage = Session("InterfaceLanguage")
            objBItem.DBServer = Session("DBServer")
            objBItem.ConnectionString = Session("ConnectionString")
            Call objBItem.Initialize()

            ' Init objBIC object
            objBIC.InterfaceLanguage = Session("InterfaceLanguage")
            objBIC.DBServer = Session("DBServer")
            objBIC.ConnectionString = Session("ConnectionString")
            Call objBIC.Initialize()
        End Sub

        ' BindJS method
        ' Purpose: Bind the Javascripts
        Private Sub BindJS()
            ' Javascript strings
            Dim strCheckNum1 As String
            Dim strCheckNum2 As String
            Dim strDateCheck1 As String
            Dim strDateCheck2 As String

            ' Register the javascript files
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("JsUnifilter", "<script language = 'javascript' src = '../js/EData/AcqUniFilter.js'></script>")

            SetCheckNumber(txtRecordIDFrom, ddlLabel.Items(3).Text, "")
            SetCheckNumber(txtRecordIDto, ddlLabel.Items(3).Text, "")
            SetOnclickCalendar(lnkFrom, txtTimeFrom, ddlLabel.Items(2).Text)
            SetOnclickCalendar(lnkTo, txtTimeTo, ddlLabel.Items(2).Text)

            ' Add the attributes for the buttons
            btnFilter.Attributes.Add("OnClick", "javascript:if (!CheckAll('" & ddlLabel.Items(1).Text & "','" & ddlLabel.Items(18).Text & "')) return false;" & strCheckNum1 & strCheckNum2 & strDateCheck1 & strDateCheck2)
            btnReset.Attributes.Add("OnClick", "javascript:ResetForm(); return false")

        End Sub

        ' BindHyperLink method
        ' Purpose: Bind the javascripts to the hiperlinks 
        Private Sub BindHyperLink()
            Dim strJavaScript1 As String
            Dim strJavaScript2 As String
            Dim strJavaScript3 As String
            Dim strJavaScript4 As String
            Dim strDicName As String

            strJavaScript1 = "'/Catalogue/Catalogue/WReferenceToFilter.aspx?Frame=txtField1&DicID='+document.Form1.ddlField1.options[document.Form1.ddlField1.options.selectedIndex].value + '&SearchData=' + document.Form1.txtField1.value"
            strJavaScript2 = "'/Catalogue/Catalogue/WReferenceToFilter.aspx?Frame=txtfield2&DicID='+document.Form1.ddlField2.options[document.Form1.ddlField2.options.selectedIndex].value + '&SearchData=' + document.Form1.txtfield2.value"
            strJavaScript3 = "'/Catalogue/Catalogue/WReferenceToFilter.aspx?Frame=txtField3&DicID='+document.Form1.ddlField3.options[document.Form1.ddlField3.options.selectedIndex].value + '&SearchData=' + document.Form1.txtField3.value"
            strJavaScript4 = "'/Catalogue/Catalogue/WReferenceToFilter.aspx?Frame=txtField4&DicID='+document.Form1.ddlField4.options[document.Form1.ddlField4.options.selectedIndex].value + '&SearchData=' + document.Form1.txtField4.value"
            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkFrom, txtTimeFrom, ddlLabel.Items(2).Text)
            SetOnclickCalendar(lnkTo, txtTimeTo, ddlLabel.Items(2).Text)

            lnkDic1.NavigateUrl = "javascript:OpenWindow(" & strJavaScript1 & ",'Dictionary',350,300,150,30)"
            lnkDic2.NavigateUrl = "javascript:OpenWindow(" & strJavaScript2 & ",'Dictionary',350,300,150,30)"
            lnkDic3.NavigateUrl = "javascript:OpenWindow(" & strJavaScript3 & ",'Dictionary',350,300,150,30)"
            lnkDic4.NavigateUrl = "javascript:OpenWindow(" & strJavaScript4 & ",'Dictionary',350,300,150,30)"
        End Sub

        ' BindData method
        ' Purpose: Bind the data for the controls
        Private Sub BindData()
            ' DataTable variables
            Dim tblCatDicList As DataTable
            Dim tblResult As DataTable
            ' integer variables
            Dim intFieldCount As Integer = 0
            Dim inti As Integer
            Dim intk As Integer = 3
            ' Array variables
            Dim arrTextField(2)
            Dim arrValueField(2)

            tblCatDicList = objBItem.GetCatDicList
            If Not tblCatDicList Is Nothing Then
                If tblCatDicList.Rows.Count > 0 Then
                    intFieldCount = tblCatDicList.Rows.Count
                End If
            End If


            arrTextField(0) = ddlLabel.Items(5).Text
            arrTextField(1) = ddlLabel.Items(6).Text
            arrTextField(2) = ddlLabel.Items(7).Text
            arrValueField(0) = "FT"
            arrValueField(1) = "TI"
            arrValueField(2) = "YR"

            If intFieldCount > 0 Then
                For inti = 0 To intFieldCount - 1 Step 1
                    ReDim Preserve arrTextField(intk)
                    ReDim Preserve arrValueField(intk)
                    arrTextField(intk) = tblCatDicList.Rows(inti).Item("Name")
                    arrValueField(intk) = tblCatDicList.Rows(inti).Item("ID")
                    intk = intk + 1
                Next
            End If

            'ReDim Preserve arrTextField(intk + 5)
            'ReDim Preserve arrValueField(intk + 5)
            ReDim Preserve arrTextField(intk + 4)
            ReDim Preserve arrValueField(intk + 4)

            arrTextField(intk) = ddlLabel.Items(13).Text
            arrTextField(intk + 1) = ddlLabel.Items(8).Text
            arrTextField(intk + 2) = ddlLabel.Items(9).Text
            arrTextField(intk + 3) = ddlLabel.Items(10).Text
            'arrTextField(intk + 4) = ddlLabel.Items(11).Text
            arrTextField(intk + 4) = ddlLabel.Items(12).Text

            arrValueField(intk) = "CN"
            arrValueField(intk + 1) = "BN"
            arrValueField(intk + 2) = "IB"
            arrValueField(intk + 3) = "IS"
            'arrValueField(intk + 4) = "IT"
            arrValueField(intk + 4) = "CA"

            tblResult = objBCDBS.CreateTable(arrTextField, arrValueField)

            If Not tblResult Is Nothing Then
                ddlField1.DataSource = tblResult
                ddlField1.DataTextField = "TextField"
                ddlField1.DataValueField = "ValueField"
                ddlField1.DataBind()

                ddlField2.DataSource = tblResult
                ddlField2.DataTextField = "TextField"
                ddlField2.DataValueField = "ValueField"
                ddlField2.DataBind()

                ddlField3.DataSource = tblResult
                ddlField3.DataTextField = "TextField"
                ddlField3.DataValueField = "ValueField"
                ddlField3.DataBind()

                ddlField4.DataSource = tblResult
                ddlField4.DataTextField = "TextField"
                ddlField4.DataValueField = "ValueField"
                ddlField4.DataBind()
            End If
        End Sub

        Private Sub loadDataFilter(ByVal collectionId As Integer)
            Try
                Dim tblData As DataTable
                With objBEData
                    .CollectionID = collectionId
                    tblData = objBEData.getCollectionfilterByCollectionID
                End With
                If Not IsNothing(tblData) AndAlso tblData.Rows.Count > 0 Then
                    Dim strBoolArr As String = ""
                    Dim strFieldArr As String = ""
                    Dim strValArr As String = ""
                    Dim BoolArr() As String = Nothing
                    Dim FieldArr() As String = Nothing
                    Dim ValArr() As String = Nothing
                    For i As Integer = 0 To tblData.Rows.Count - 1

                        If Not IsDBNull(tblData.Rows(i).Item("BoolArr")) AndAlso tblData.Rows(i).Item("BoolArr") <> "" Then
                            strBoolArr = tblData.Rows(i).Item("BoolArr")
                            BoolArr = strBoolArr.Split(",")
                        End If

                        If Not IsDBNull(tblData.Rows(i).Item("FieldArr")) AndAlso tblData.Rows(i).Item("FieldArr") <> "" Then
                            strFieldArr = tblData.Rows(i).Item("FieldArr")
                            FieldArr = strFieldArr.Split(",")
                        End If

                        If Not IsDBNull(tblData.Rows(i).Item("ValArr")) AndAlso tblData.Rows(i).Item("ValArr") <> "" Then
                            strValArr = tblData.Rows(i).Item("ValArr")
                            ValArr = strValArr.Split(",")
                        End If

                        If Not IsDBNull(tblData.Rows(i).Item("FromDate")) AndAlso tblData.Rows(i).Item("FromDate") <> "" Then
                            txtTimeFrom.Text = tblData.Rows(i).Item("FromDate")
                        End If

                        If Not IsDBNull(tblData.Rows(i).Item("ToDate")) AndAlso tblData.Rows(i).Item("ToDate") <> "" Then
                            txtTimeTo.Text = tblData.Rows(i).Item("ToDate")
                        End If

                        'If Not IsDBNull(tblData.Rows(i).Item("Username")) AndAlso tblData.Rows(i).Item("Username") <> "" Then
                        '    txtUserName.Text = tblData.Rows(i).Item("Username")
                        'End If

                        If Not IsDBNull(tblData.Rows(i).Item("DocType")) AndAlso tblData.Rows(i).Item("DocType") <> 0 Then
                            ddlType.SelectedValue = tblData.Rows(i).Item("DocType")
                        End If
                        Exit For
                    Next
                    If Not IsNothing(BoolArr) Then
                        ddlBool1.SelectedIndex = BoolArr(1)
                        ddlBool2.SelectedIndex = BoolArr(2)
                        ddlBool3.SelectedIndex = BoolArr(3)
                    End If
                    If Not IsNothing(FieldArr) Then
                        ddlField1.SelectedIndex = FieldArr(0)
                        ddlField2.SelectedIndex = FieldArr(1)
                        ddlField3.SelectedIndex = FieldArr(2)
                        ddlField4.SelectedIndex = FieldArr(3)
                    End If
                    If Not IsNothing(ValArr) Then
                        txtField1.Text = ValArr(0)
                        txtfield2.Text = ValArr(1)
                        txtField3.Text = ValArr(2)
                        txtField4.Text = ValArr(3)
                    End If
                End If
            Catch ex As Exception

            End Try
        End Sub

        ' SearchItem method. 
        ' Purpose: retrieve the string of IDs after searching for the filterring order
        Private Sub SearchItem()
            Try
                Dim intCollection As Integer = -1
                If Not IsNothing(Request("collection")) AndAlso Request("collection") <> "" Then
                    intCollection = Request("collection")
                End If
                Dim addCollection As Integer = 0
                If Not IsNothing(Request("addCollection")) AndAlso Request("addCollection") <> "" Then
                    addCollection = Request("addCollection")
                End If
                ' DataTable variable
                Dim tblItem As New DataTable
                ' Declare the arrays of operation char (AND, OR, NOT), Values of the search fields, and the fields
                Dim arrBool() As String
                Dim arrVal() As String
                Dim arrField() As String
                ' Declare the integer variables
                Dim intk = 0   ' Array index
                Dim intCount As Integer
                Dim strLog As String

                ' Return the SQL query for the first fields
                If Trim(txtField1.Text) <> "" Then
                    ReDim Preserve arrBool(intk)
                    ReDim Preserve arrField(intk)
                    ReDim Preserve arrVal(intk)
                    arrBool(intk) = "AND"
                    arrField(intk) = ddlField1.SelectedValue
                    arrVal(intk) = Trim(txtField1.Text)
                    intk = intk + 1
                End If
                ' Return the SQL query for the 2nd fields
                If Trim(txtfield2.Text) <> "" Then
                    ReDim Preserve arrBool(intk)
                    ReDim Preserve arrField(intk)
                    ReDim Preserve arrVal(intk)
                    arrBool(intk) = ddlBool1.SelectedValue
                    arrField(intk) = ddlField2.SelectedValue
                    arrVal(intk) = Trim(txtfield2.Text)
                    intk = intk + 1
                End If
                ' Return the SQL query for the 3rd fields
                If Trim(txtField3.Text) <> "" Then
                    ReDim Preserve arrBool(intk)
                    ReDim Preserve arrField(intk)
                    ReDim Preserve arrVal(intk)
                    arrBool(intk) = ddlBool2.SelectedValue
                    arrField(intk) = ddlField3.SelectedValue
                    arrVal(intk) = Trim(txtField3.Text)
                    intk = intk + 1
                End If
                ' Return the SQL query for the 4th fields
                If Trim(txtField4.Text) <> "" Then
                    ReDim Preserve arrBool(intk)
                    ReDim Preserve arrField(intk)
                    ReDim Preserve arrVal(intk)
                    arrBool(intk) = ddlBool3.SelectedValue
                    arrField(intk) = ddlField4.SelectedValue
                    arrVal(intk) = Trim(txtField4.Text)
                    intk = intk + 1
                End If
                ' Return the SQL query for the 5th fields
                If Trim(txtRecordIDFrom.Text) <> "" Then
                    Dim tblLRange As New DataTable
                    ReDim Preserve arrBool(intk)
                    ReDim Preserve arrField(intk)
                    ReDim Preserve arrVal(intk)
                    arrBool(intk) = "AND"
                    arrField(intk) = "FROMID"
                    objBIC.TopNum = CInt(txtRecordIDFrom.Text)
                    tblLRange = objBIC.GetIDByTopNum()
                    If Not tblLRange Is Nothing Then
                        If tblLRange.Rows.Count > 0 Then
                            arrVal(intk) = tblLRange.Rows(0).Item(0)
                        End If
                    End If
                    intk = intk + 1
                End If
                ' Return the SQL query for the 6th fields
                If Trim(txtRecordIDto.Text) <> "" Then
                    Dim tblRRange As New DataTable
                    ReDim Preserve arrBool(intk)
                    ReDim Preserve arrField(intk)
                    ReDim Preserve arrVal(intk)
                    arrBool(intk) = "AND"
                    arrField(intk) = "TOID"
                    objBIC.TopNum = CInt(txtRecordIDto.Text)
                    tblRRange = objBIC.GetIDByTopNum()
                    If Not tblRRange Is Nothing Then
                        If tblRRange.Rows.Count > 0 Then
                            arrVal(intk) = tblRRange.Rows(0).Item(0)
                        End If
                    End If
                    intk = intk + 1
                End If
                ' Return the SQL query for the 7th fields
                If Trim(txtTimeFrom.Text) <> "" Then
                    ReDim Preserve arrBool(intk)
                    ReDim Preserve arrField(intk)
                    ReDim Preserve arrVal(intk)
                    arrBool(intk) = "AND"
                    arrField(intk) = "FROMDTE"
                    arrVal(intk) = txtTimeFrom.Text & " " & "00:00:00"
                    intk = intk + 1
                End If
                ' Return the SQL query for the 7th fields
                If Trim(txtTimeTo.Text) <> "" Then
                    ReDim Preserve arrBool(intk)
                    ReDim Preserve arrField(intk)
                    ReDim Preserve arrVal(intk)
                    arrBool(intk) = "AND"
                    arrField(intk) = "TODTE"
                    arrVal(intk) = txtTimeTo.Text & " " & "23:59:59"
                    intk = intk + 1
                End If

                If ddlType.SelectedValue > 0 Then
                    ReDim Preserve arrBool(intk)
                    ReDim Preserve arrField(intk)
                    ReDim Preserve arrVal(intk)
                    arrBool(intk) = "AND"
                    arrField(intk) = "ITEMFORMAT"
                    arrVal(intk) = ddlType.SelectedValue
                    intk = intk + 1
                End If

                ' Transfer the value for the arrays on the clsBFormingSQL class
                objBFormingSQL.FieldArr = arrField
                objBFormingSQL.ValArr = arrVal
                objBFormingSQL.BoolArr = arrBool

                ' Return the sql statement by implement the method FormingASQL
                If Session("sqlFilterCollection") <> "" And chkMerge.Checked = True Then
                    Dim strMergeSQL As String
                    strMergeSQL = " UNION SELECT ID FROM Item WHERE Item.ID IN (" & Session("sqlFilterCollection") & ")"
                    objBFormingSQL.LibID = clsSession.GlbSite
                    strMergeSQL = objBFormingSQL.FormingASQL
                    If InStr(Session("sqlFilterCollection"), strMergeSQL) > 0 Then
                        Page.RegisterClientScriptBlock("JSAlert", "<script language= 'javascript'>alert('" & ddlLabel.Items(4).Text & "')</script>")
                        Exit Sub
                    Else
                        objBCDBS.SQLStatement = Session("sqlFilterCollection") & " UNION " & strMergeSQL
                    End If
                Else
                    objBFormingSQL.LibID = clsSession.GlbSite
                    objBCDBS.SQLStatement = objBFormingSQL.FormingASQL
                End If

                tblItem = objBCDBS.RetrieveItemInfor()
                If objBCDBS.ErrorCode > 0 Then
                    Page.RegisterClientScriptBlock("JSAlert", "<script language= 'javascript'>alert('" & ddlLabel.Items(4).Text & "')</script>")
                    Exit Sub
                End If
                Dim intCollectionFilter As Integer = 0
                If Not tblItem Is Nothing AndAlso tblItem.Rows.Count > 0 Then
                    intSumFound = tblItem.Rows.Count
                   
                    Session("sqlFilterCollection") = objBCDBS.SQLStatement

                    Dim ArrIDs() As Integer = Nothing
                    Dim _i As Integer = 0
                    For intCount = 0 To intSumFound - 1
                        ReDim Preserve ArrIDs(intCount)
                        ArrIDs(intCount) = tblItem.Rows(intCount).Item(0)
                    Next
                    Session("RecordCollectionIDs") = ArrIDs

                    Dim BoolArrIndex() As String = {"0", ddlBool1.SelectedIndex, ddlBool2.SelectedIndex, ddlBool3.SelectedIndex}
                    Dim FieldArrIndex() As String = {ddlField1.SelectedIndex, ddlField2.SelectedIndex, ddlField3.SelectedIndex, ddlField3.SelectedIndex}
                    Dim ValArrIndex() As String = {txtField1.Text.ToString, txtfield2.Text.ToString, txtField3.Text.ToString, txtField4.Text.ToString}
                    intCollectionFilter = updateCollectionFilter(BoolArrIndex, FieldArrIndex, ValArrIndex, txtTimeFrom.Text, txtTimeTo.Text, "", ddlType.SelectedValue) ' txtUserName.Text.Trim, intDocType)
                    'Session("TotalRecord") = intSumFound
                    'Session("Filter") = 1
                    strLog = ddlLabel.Items(14).Text & " " & intSumFound & " " & ddlLabel.Items(17).Text
                    Call DisplayInfo(1, intSumFound, intCollection, addCollection, intCollectionFilter)

                    'Page.RegisterClientScriptBlock("JSDisplay", "<script language= 'javascript'>parent.Sentform.location.href='WControlBar.aspx'</script>")
                    Call WriteLog(9, strLog, Request.ServerVariables("SCRIPT_NAME"), CStr(Request.ServerVariables("Remote_Addr")), clsSession.GlbUserFullName)
                    tblItem.Clear()
                Else
                    ' No item has found
                    Page.RegisterClientScriptBlock("NotFound", "<script language= 'javascript'>alert('" & ddlLabel.Items(0).Text & "')</script>")
                End If
            Catch ex As Exception
            End Try
        End Sub

        Private Function updateCollectionFilter(ByVal BoolArr() As String, ByVal FieldArr() As String, ByVal ValArr() As String, Optional ByVal _fromDate As String = "", Optional ByVal _toDate As String = "", Optional ByVal userName As String = "", Optional ByVal intDocType As Integer = 0) As Integer
            Dim intResult As Integer = 0
            Try
                Dim strBoolArr As String = ""
                Dim strFieldArr As String = ""
                Dim strValArr As String = ""
                For i As Integer = FieldArr.GetLowerBound(0) To FieldArr.GetUpperBound(0)
                    strBoolArr &= BoolArr(i) & ","
                    strFieldArr &= FieldArr(i) & ","
                    strValArr &= ValArr(i) & ","
                Next
                strBoolArr = Left(strBoolArr, Len(strBoolArr) - 1)
                strFieldArr = Left(strFieldArr, Len(strFieldArr) - 1)
                strValArr = Left(strValArr, Len(strValArr) - 1)

                Dim collFilter As New Collection
                With collFilter
                    '.Add(collectionId, "collectionId")
                    .Add(strBoolArr, "BoolArr")
                    .Add(strFieldArr, "FieldArr")
                    .Add(strValArr, "ValArr")
                    .Add(_fromDate, "fromDate")
                    .Add(_toDate, "toDate")
                    .Add(userName, "userName")
                    .Add(intDocType, "DocType")
                    clsSession.GlbCollectionFilter = collFilter
                End With
                'With objBEData
                '    .CollectionID = collectionId
                '    .CollectionFilterBoolArr = strBoolArr
                '    .CollectionFilterFieldArr = strFieldArr
                '    .CollectionFilterValArr = strValArr
                '    .CollectionFilterFromDate = _fromDate
                '    .CollectionFilterToDate = _toDate
                '    .CollectionFilterUsername = userName
                '    .CollectionFilterDocType = intDocType
                '    intResult = objBEData.insertCollectionFilter
                'End With
                'Dim procs As New BusinessLayer.Acquisition
                'intResult = procs.insertCollectionFilter(collectionId, strBoolArr, strFieldArr, strValArr, txtFrom.Text, txtTo.Text, txtUserName.Text.Trim, intDocType)
                'procs = Nothing
            Catch ex As Exception
            End Try
            Return intResult
        End Function

        Public Sub DisplayInfo(ByVal _min As Integer, ByVal _max As Integer, Optional ByVal intCollection As Integer = -1, Optional ByVal addCollection As Integer = 0, Optional ByVal intCollectionFilter As Integer = 0)
            Dim _strInfo As String = ""
            _strInfo = "OnSubmit(" & _min & "," & _max & "," & intCollection.ToString & "," & addCollection.ToString & "," & intCollectionFilter.ToString & ");"
            clsWCommon.MyMsgBoxInfor(_strInfo, Me.Page)
        End Sub

        ' btnFilter_click action
        Private Sub btnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilter.Click
            Me.SearchItem()
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Release the methods
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not IsNothing(objBEData) Then
                    objBEData.Dispose(True)
                    objBEData = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBFormingSQL Is Nothing Then
                    objBFormingSQL.Dispose(True)
                    objBFormingSQL = Nothing
                End If
                If Not objBItem Is Nothing Then
                    objBItem.Dispose(True)
                    objBItem = Nothing
                End If
                If Not objBIC Is Nothing Then
                    objBIC.Dispose(True)
                    objBIC = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace

