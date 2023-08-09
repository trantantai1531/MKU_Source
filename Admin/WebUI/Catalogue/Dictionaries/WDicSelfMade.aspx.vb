Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WDicSelfMade
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblMsgEmpty As System.Web.UI.WebControls.Label
        Protected WithEvents lblMsgExist As System.Web.UI.WebControls.Label
        Protected WithEvents lblMsgEmptyFN As System.Web.UI.WebControls.Label
        Protected WithEvents lblAlert1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblAlert2 As System.Web.UI.WebControls.Label
        Protected WithEvents lblAlert3 As System.Web.UI.WebControls.Label
        Protected WithEvents Hidden1 As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents lblReIndex As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel0 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel2 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel3 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel4 As System.Web.UI.WebControls.Label
        Protected WithEvents hidFormAction As System.Web.UI.HtmlControls.HtmlInputHidden


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private objBDictionary As New clsBDictionarySelfMade
        Private objBCatDicList As New clsBCatDicList
        Private objBCSP As New clsBCommonStringProc

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ' Check permisssion
            Call CheckFormPermission()
            Call Initialze()
            Call BindJavascript()
            If Not Page.IsPostBack Then
                Call BindData("")
            End If
            Call LoadHeader()
        End Sub

        ' CheckFormPermission method
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(147) Then
                'Sua chua muc tu tu dien tu tao
                If Not CheckPemission(225) Then
                    DtgDicSelfMade.Columns(3).Visible = False
                End If
                'Gop-Xoa muc tu tu dien tu tao
                If Not CheckPemission(226) Then
                    DtgDicSelfMade.Columns(1).Visible = False
                    btnGroup.Enabled = False
                End If
                'Tao moi muc tu tu dien tu tao
                If Not CheckPemission(172) Then
                    btnInsertFromSource.Enabled = False
                    btnNewDictionary.Enabled = False
                End If
            End If
        End Sub

        ' Method: BindJavascript
        ' Popurse: Bind javascript for all control need.
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("JSCommon", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("JSSelf", "<script language = 'javascript' src = '../js/Dictionaries/WDicSelfMade.js'></script>")

            btnNewDictionary.Attributes.Add("onClick", "return CheckInput('" & ddlAboutAction.Items(9).Text & "');")
            btnInsertFromSource.Attributes.Add("onClick", "return CheckNameField('" & ddlAboutAction.Items(14).Text & "');")
        End Sub

        ' Method: LoadHeader
        Private Sub LoadHeader()
            Dim tblTemp As New DataTable
            Dim strNameDic As String

            objBCatDicList.IDs = Trim(Request.QueryString("intDicID"))
            tblTemp = objBCatDicList.Retrieve()
            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    strNameDic = tblTemp.Rows(0).Item("Name")
                    lblHeader.Text = Replace(lblHeader.Text, strNameDic, "") & " " & strNameDic
                    txtNewDictionary.MaxLength = tblTemp.Rows(0).Item("FieldSize")
                End If
            End If
        End Sub

        ' Method: Initialze
        Private Sub Initialze()
            ' Init objBDictionary object
            objBDictionary.InterfaceLanguage = Session("InterfaceLanguage")
            objBDictionary.DBServer = Session("DbServer")
            objBDictionary.ConnectionString = Session("ConnectionString")
            Call objBDictionary.Initialize()

            ' Init objBCatDicList object
            objBCatDicList.InterfaceLanguage = Session("InterfaceLanguage")
            objBCatDicList.DBServer = Session("DbServer")
            objBCatDicList.ConnectionString = Session("ConnectionString")
            Call objBCatDicList.Initialize()

            ' Init objBCSP object
            objBCSP.InterfaceLanguage = Session("InterfaceLanguage")
            objBCSP.DBServer = Session("DbServer")
            objBCSP.ConnectionString = Session("ConnectionString")
            Call objBCSP.Initialize()
        End Sub

        ' Method: BindData
        Private Sub BindData(ByVal strFilter As String, Optional ByVal intPage As Integer = 0)
            Dim tblDic As DataTable
            Dim blnFound As Boolean = False

            If IsNumeric(Request.QueryString("intDicID")) Then
                objBDictionary.DicID = CInt(Request.QueryString("intDicID"))
            End If
            objBDictionary.Dictionary = strFilter
            tblDic = objBDictionary.GetEntries
            If Not tblDic Is Nothing Then
                If tblDic.Rows.Count > 0 Then
                    DtgDicSelfMade.DataSource = tblDic
                    blnFound = True
                End If
            End If
            DtgDicSelfMade.CurrentPageIndex = intPage
            DtgDicSelfMade.DataBind()

            If Not blnFound Then
                divDictionary.Visible = False
                txtNewDictionary.Visible = False
                btnNewDictionary.Visible = False
                lblFilterDrop.Visible = False
                txtGroup.Visible = False
                ddlDic.Visible = False
                btnGroup.Visible = False
            Else
                divDictionary.Visible = True
                txtNewDictionary.Visible = True
                btnNewDictionary.Visible = True
                lblFilterDrop.Visible = True
                txtGroup.Visible = True
                ddlDic.Visible = True
                btnGroup.Visible = True
                ddlDic.DataSource = tblDic
                ddlDic.DataTextField = "Dictionary"
                ddlDic.DataValueField = "ID"
                ddlDic.DataBind()
            End If
        End Sub

        ' Method: InsertFromSource
        Private Sub InsertFromSource(ByVal intAlertID As Integer, ByVal strLabelField As String, ByVal intDicID As Integer)
            Dim strTableName As String
            Dim strMainTag As String
            Dim strSubTag As String = ""
            Dim tblSourceDic As New DataTable
            Dim strFieldName As String
            Dim strDicSourceName As String
            Dim intFieldSize As Integer
            Dim tblCatDic As New DataTable
            Dim arrDic()
            Dim arrSubRec()
            Dim intCount As Integer
            Dim strContent, strHtml As String
            Dim inti As Integer
            Dim tblFilterDic As New DataTable
            Dim strVal As String
            Dim strDictionary As String
            Dim intIDCreate As Integer
            Dim intj As Integer
            Dim lngTotal As Long
            Dim intPercentage As Integer
            Dim intID

            ' Genarate Table DicName
            strTableName = "DICTIONARY" & Trim(CStr(intDicID))
            If InStr(strLabelField, "$") > 0 Then
                strMainTag = Left(strLabelField, 3)
                strSubTag = Right(strLabelField, 2)
            End If

            If intAlertID = 1 Then
                objBDictionary.TableName = strTableName
                objBDictionary.FieldCode = strLabelField
                Call objBDictionary.RemoveAllEntries()
            End If

            ' Create new ID int Dictionary
            objBDictionary.TableName = strTableName
            objBDictionary.FieldID = "ID"
            intIDCreate = 0
            intIDCreate = objBDictionary.CreateID()
            ' Read Source Dictionary
            objBDictionary.FieldCode = strLabelField
            tblSourceDic = objBDictionary.Retrieve_Source_Dic
            strFieldName = objBDictionary.FieldName
            strDicSourceName = objBDictionary.TableName
            ' Read FieldSize of Dictionay
            objBCatDicList.IDs = CStr(intDicID)
            tblCatDic = objBCatDicList.Retrieve
            If tblCatDic.Rows.Count > 0 Then
                intFieldSize = CInt(tblCatDic.Rows(0).Item("FieldSize"))
            End If

            lngTotal = tblSourceDic.Rows.Count
            ' Init progress bar
            strHtml = "<span id='spnMain' style='LEFT: 100px; WIDTH: 600px; COLOR: #3333ff; POSITION: absolute; TOP: 60px'	class='lblLabel'>"
            strHtml = strHtml & "<span id='spnPecent' style='LEFT: 300px; COLOR: #FFFFFF; POSITION: absolute; TOP: 15px;FONT-WEIGHT: bold;'>0%</span>"
            strHtml = strHtml & "<span id='spnlbProcessing' style='LEFT: 250px; POSITION: absolute; TOP: 60px;TEXT-ALIGN: center;'>" & ddlAboutAction.Items(22).Text & "</span>"
            strHtml = strHtml & "<table height=10px cellspacing=0 cellpadding=0><tr><td></td><tr></table>"
            strHtml = strHtml & "<table width=100% border=1 bgcolor=#999966 height=30px cellspacing=0 cellpadding=0 bordercolor=#FF9900><tr><td>"
            strHtml = strHtml & "<table id='spnProgess' width=0% border=0 bgcolor=#006291 height=100%><tr><td></td></tr></table></td></tr></table></span>"
            Response.Write(strHtml)
            Response.Write(Hour(Now) & ":" & Minute(Now) & ":" & Second(Now) & "<br>")
            ' Start Process Insert to Dictionary self made
            For intCount = 0 To lngTotal - 1
                If intCount Mod 100 = 0 Or intCount = lngTotal - 1 Then
                    ' Display the progress bar
                    Call BindPrg(intCount, lngTotal)
                End If
                strContent = tblSourceDic.Rows(intCount).Item("Value")
                If strContent <> "" Then
                    If strSubTag <> "" Then
                        ' if have subfield
                        ' Read Sub field
                        objBCSP.ParseField(strSubTag, strContent, Chr(9), arrDic)
                    Else
                        ' if have not subfield
                        ReDim arrDic(1)
                        arrDic(0) = strContent
                    End If

                    'Read ItemID by Content
                    arrSubRec = Split(arrDic(0), Chr(9))
                    objBDictionary.Content = strContent
                    objBDictionary.FieldName = strFieldName
                    objBDictionary.TableName = strDicSourceName
                    tblFilterDic = objBDictionary.Retrieve_Source_Dic_byVal

                    ' Check error
                    ' Call WriteErrorMssg(ddlAboutAction.Items(12).Text, objBDictionary.ErrorMsg, ddlAboutAction.Items(11).Text, objBDictionary.ErrorCode)

                    For inti = LBound(arrSubRec) To UBound(arrSubRec)
                        strVal = objBCSP.GEntryTrim(arrSubRec(inti).ToString.Trim).Trim
                        If strVal <> "" Then
                            If Len(strVal) > intFieldSize Then
                                strDictionary = Left(strVal, intFieldSize)
                            Else
                                strDictionary = strVal
                            End If
                            If strDictionary <> "" Then
                                Try
                                    ' Insert into Dictionary
                                    objBDictionary.Dictionary = strDictionary
                                    objBDictionary.TableName = strTableName
                                    intID = objBDictionary.CreateEntry()
                                    ' Insert Into Item_dicionary for each ItemID, have it from Source Dic
                                    If Not tblFilterDic Is Nothing AndAlso tblFilterDic.Rows.Count > 0 Then
                                        For intj = 0 To tblFilterDic.Rows.Count - 1
                                            objBDictionary.ItemID = tblFilterDic.Rows(intj).Item("ItemID")
                                            objBDictionary.FieldCode = strLabelField
                                            objBDictionary.DicID = intID
                                            objBDictionary.TableName = strTableName
                                            objBDictionary.Insert_Item_Dic()
                                        Next
                                    End If
                                Catch ex As Exception
                                End Try
                            End If
                        End If
                    Next
                End If
            Next
            Response.Write(Hour(Now) & ":" & Minute(Now) & ":" & Second(Now))
            Response.Write("<script language='javascript'>spnMain.style.display='none';</script>")
            Call BindData(txtFilter.TextMode)
        End Sub

        ' BindPrg method 
        ' Purpose: Bind data for Controls
        Public Sub BindPrg(ByVal intCurrent As Integer, ByVal intSum As Integer)
            Dim intCurrentPercent As Integer
            intCurrentPercent = ((intCurrent + 1) * 100) / intSum
            'System.Threading.Thread.Sleep(50 / intSum)
            Response.Write("<script language='javascript'>spnProgess.width =" & intCurrentPercent & " + '%'; spnPecent.innerHTML =" & intCurrentPercent & " + '%';</script>")
            Response.Flush()
        End Sub

        ' btnInsertFromSource_Click event
        ' Purpose: Create index by import data from database
        Private Sub btnInsertFromSource_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertFromSource.Click
            Dim intAlertID As Integer
            Dim intDicID As Integer
            Dim strFieldCode As String
            Dim strJS As String

            strFieldCode = txtFieldCode.Text

            If IsNumeric(Request.QueryString("intDicID")) Then
                intDicID = CInt(Request.QueryString("intDicID"))
            End If
            objBDictionary.FieldCode = strFieldCode
            intAlertID = objBDictionary.CheckDicID(intDicID)
            Select Case intAlertID
                Case 1 ' FieldCode doesn't exist
                    strJS = "alert('" & ddlAboutAction.Items(16).Text & "')"
                Case 2 ' FieldCode are used by another index
                    strJS = "alert('" & ddlAboutAction.Items(15).Text & "')"
                Case 3 ' OK (Field900s)
                    ' strJS = "if( confirm('" & ddlAboutAction.Items(17).Text & "')){document.forms[0].txtReIndex.value='1'}"
                    'If Trim(txtReIndex.Value) = "1" Then
                    '    Call InsertFromSource(1, strFieldCode, intDicID)
                    'Else
                    '    Call InsertFromSource(0, strFieldCode, intDicID)
                    'End If
                    Call InsertFromSource(1, strFieldCode, intDicID)
                    Call WriteLog(14, ddlAboutAction.Items(18).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                Case 4 ' Is Marc field
                    strJS = "alert('" & ddlAboutAction.Items(14).Text & "')"
                Case 5 ' Is Marc field
                    strJS = ""
                Case 6 ' OK
                    strJS = ""
                    Call InsertFromSource(0, strFieldCode, intDicID)
                    objBDictionary.DicID = intDicID
                    objBDictionary.FieldCode = strFieldCode
                    Call objBDictionary.SetDicIDForField()
            End Select

            If strJS <> "" Then
                Page.RegisterClientScriptBlock("JsAlert", "<script language = 'javascript'>" & strJS & ";</script>")
            End If
            Call BindData(txtFilter.Text)
        End Sub

        ' Event: DtgDicSelfMade_PageIndexChanged
        Private Sub DtgDicSelfMade_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DtgDicSelfMade.PageIndexChanged
            Call BindData(txtFilter.Text, e.NewPageIndex)
        End Sub

        ' Event: DtgDicSelfMade_EditCommand
        Private Sub DtgDicSelfMade_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DtgDicSelfMade.EditCommand
            DtgDicSelfMade.EditItemIndex = e.Item.ItemIndex
            Call BindData(txtFilter.Text, DtgDicSelfMade.CurrentPageIndex)
        End Sub

        ' Event: DtgDicSelfMade_CancelCommand
        Private Sub DtgDicSelfMade_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DtgDicSelfMade.CancelCommand
            DtgDicSelfMade.EditItemIndex = -1
            Call BindData(txtFilter.Text, DtgDicSelfMade.CurrentPageIndex)
        End Sub

        ' Event: DtgDicSelfMade_CancelCommand
        Private Sub DtgDicSelfMade_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DtgDicSelfMade.UpdateCommand
            Dim intIDUpd As Integer
            Dim strDictionary As String

            intIDUpd = CInt(CType(e.Item.Cells(0).FindControl("lblID"), Label).Text)
            strDictionary = CType(e.Item.Cells(1).FindControl("txtDictionary"), TextBox).Text

            objBDictionary.ID = intIDUpd
            objBDictionary.Dictionary = strDictionary
            objBDictionary.DicID = CInt(Request.QueryString("intDicID"))
            objBDictionary.UpdateEntry()
            ' Write log
            Call WriteLog(15, ddlAboutAction.Items(19).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

            DtgDicSelfMade.EditItemIndex = -1
            Call BindData(txtFilter.Text, DtgDicSelfMade.CurrentPageIndex)
        End Sub

        ' Event: btnFilter_Click
        Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
            Call BindData(txtFilter.Text)
        End Sub

        ' Event: txtGroup_TextChanged
        Private Sub txtGroup_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGroup.TextChanged
            Dim tblDicIndex As New DataTable
            If Trim(txtGroup.Text) <> "" Then
                objBDictionary.DicID = CInt(Request.QueryString("intDicID"))
                objBDictionary.Dictionary = txtGroup.Text
                tblDicIndex = objBDictionary.GetEntries
                If Not tblDicIndex Is Nothing Then
                    If tblDicIndex.Rows.Count > 0 Then
                        ddlDic.DataSource = tblDicIndex
                        ddlDic.DataTextField = "Dictionary"
                        ddlDic.DataValueField = "ID"
                        ddlDic.DataBind()
                    End If
                End If
            End If
        End Sub

        ' Event: btnGroup_Click
        Private Sub btnGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroup.Click
            Dim dtgItem As DataGridItem
            Dim strIDs As String
            Dim blnMerge As Boolean = False

            For Each dtgItem In DtgDicSelfMade.Items
                If CType(dtgItem.Cells(1).FindControl("chkID"), CheckBox).Checked Then
                    strIDs = strIDs & CType(dtgItem.Cells(0).FindControl("lblID"), Label).Text & ","
                End If
            Next
            If Not strIDs = "" Then
                strIDs = Left(strIDs, Len(strIDs) - 1)
            End If

            If IsNumeric(ddlDic.SelectedValue & "") Then
                If strIDs <> "" Then
                    objBDictionary.DicID = CInt(Request.QueryString("intDicID"))
                    objBDictionary.IDMerge = strIDs
                    objBDictionary.IDNew = CInt(ddlDic.SelectedValue)
                    Call objBDictionary.MergeEntries()
                    Page.RegisterClientScriptBlock("InputErrorJs", "<script language = 'javascript'>alert('Gộp thành công');</script>")
                    ' Write log
                    Call WriteLog(15, ddlAboutAction.Items(20).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                    blnMerge = True
                End If
            End If
            If Not blnMerge Then
                Page.RegisterClientScriptBlock("InputErrorJs", "<script language = 'javascript'>alert('" & ddlAboutAction.Items(21).Text & "');</script>")
            End If
            Call BindData(txtFilter.Text)
        End Sub

        ' btnNewDictionary_Click event
        ' Purpose: Create new entry 
        Private Sub btnNewDictionary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewDictionary.Click
            Dim bytRet As Byte

            objBDictionary.DicID = CInt(Request.QueryString("intDicID"))
            objBDictionary.Dictionary = txtNewDictionary.Text
            bytRet = objBDictionary.NewEntry()
            ' Write log
            Call WriteLog(14, ddlAboutAction.Items(22).Text & txtNewDictionary.Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

            Select Case bytRet
                Case 1 ' Exist entry
                    Page.RegisterClientScriptBlock("JSAlert", "<script language = 'javascript'>alert('" & ddlAboutAction.Items(13).Text & "');</script>")
                Case Else
                    txtNewDictionary.Text = ""
            End Select
            Call BindData(txtFilter.Text, DtgDicSelfMade.CurrentPageIndex)
        End Sub

        ' Draw progress bar for populate-index process
        Private Sub DrawProgressBar(ByVal lngTotal As Long, ByVal intDone As Integer, ByRef intPercentage As Integer)
            Dim intCurPerc As Integer
            Dim strJS As String
            intCurPerc = Int(intDone) * 100 / lngTotal
            If intCurPerc - intPercentage >= 5 Then
                intPercentage = (Int(intCurPerc / 5)) * 5
            End If
        End Sub

        '' Event: txtNewDictionary_TextChanged
        'Private Sub txtNewDictionary_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNewDictionary.TextChanged
        '    Dim bytRet As Byte
        '    objBDictionary.DicID = CInt(Request.QueryString("intDicID"))
        '    objBDictionary.Dictionary = txtNewDictionary.Text
        '    bytRet = objBDictionary.NewEntry()

        '    ' Check error
        '    Call WriteErrorMssg(ddlAboutAction.Items(12).Text, objBCatDicList.ErrorMsg, ddlAboutAction.Items(11).Text, objBCatDicList.ErrorCode)

        '    Select Case bytRet
        '        Case 1 ' dang ton tai
        '            Page.RegisterClientScriptBlock("JSAlert", "<script language = 'javascript'>alert('" & ddlAboutAction.Items(13).Text & "');</script>")
        '        Case Else
        '            txtNewDictionary.Text = ""
        '    End Select
        '    Call BindData(txtFilter.Text, DtgDicSelfMade.CurrentPageIndex)
        'End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not objBDictionary Is Nothing Then
                        objBDictionary.Dispose(True)
                        objBDictionary = Nothing
                    End If
                    If Not objBCatDicList Is Nothing Then
                        objBCatDicList.Dispose(True)
                        objBCatDicList = Nothing
                    End If
                    If Not objBCSP Is Nothing Then
                        objBCSP.Dispose(True)
                        objBCSP = Nothing
                    End If
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace