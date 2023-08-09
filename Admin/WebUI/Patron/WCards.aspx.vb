' Class: WCards
' Purpose: Print patron card
' Creator: Sondp
' Created Date: 12/1/2005
' Modification History:
'   - 27/04/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Patron
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WCards
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
        Private objBCT As New clsBCommonTemplate
        Private objBPC As New clsBPatronCollection
        Private objBP As New clsBPatron
        Private objBPG As New clsBPatronGroup
        Private objBF As New clsBFaculty

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If Not IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Method: Initialize
        Private Sub Initialize()
            ' Initialize  objBCT object
            objBCT.DBServer = Session("DBServer")
            objBCT.ConnectionString = Session("ConnectionString")
            objBCT.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCT.Initialize()

            ' Initialize  objBPC object
            objBPC.DBServer = Session("DBServer")
            objBPC.ConnectionString = Session("ConnectionString")
            objBPC.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPC.initialize()

            ' Initialize objBP object
            objBP.DBServer = Session("DBServer")
            objBP.ConnectionString = Session("ConnectionString")
            objBP.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBP.Initialize()

            ' Initialize objBPG object
            objBPG.DBServer = Session("DBServer")
            objBPG.ConnectionString = Session("ConnectionString")
            objBPG.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPG.Initialize()
            ' Initialize objBF object
            objBF.DBServer = Session("DBServer")
            objBF.ConnectionString = Session("ConnectionString")
            objBF.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBF.Initialize()
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            If Not CheckPemission(54) Then
                ' Write error
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub

        ' Method: WriteFormLog
        Private Sub WriteFormLog()
            Call WriteLog(32, ddlLabel.Items(4).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
        End Sub

        ' Method: BindJS
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("JScript", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WCardsJs", "<script language='javascript' src='js/WCards.js'></script>")

            optID.Attributes.Add("onClick", "document.forms[0].txtFromID.focus();")
            ' txtFromID.Attributes.Add("OnClick", "document.forms[0].optID.checked=true;")
            'txtToID.Attributes.Add("OnClick", "document.forms[0].optID.checked=true;")
            optValidDate.Attributes.Add("onClick", "document.forms[0].txtFromValidDate.focus();")
            txtFromValidDate.Attributes.Add("OnClick", "document.forms[0].optValidDate.checked=true;")
            txtToValidDate.Attributes.Add("OnClick", "document.forms[0].optValidDate.checked=true;")
            optCode.Attributes.Add("onClick", "document.forms[0].txtCode.focus();")
            txtCode.Attributes.Add("onClick", "document.forms[0].optCode.checked=true;")
            optClass.Attributes.Add("onClick", "document.forms[0].txtClass.focus();")
            txtClass.Attributes.Add("onClick", "document.forms[0].optClass.checked=true;")
            'txtFaculty.Attributes.Add("onClick", "document.forms[0].optClass.checked=true;")
            ddlFaculty.Attributes.Add("OnClick", "document.forms[0].optClass.checked=true;")
            Me.RegisterCalendar("..")
            SetOnclickCalendar(lnkCalFrom, txtFromValidDate, ddlLabel.Items(5).Text)
            SetOnclickCalendar(lnkCalTo, txtToValidDate, ddlLabel.Items(5).Text)
            lnkDetailClass.NavigateUrl = "javascript:OpenDetailClass()"

            'txtFromID.Attributes.Add("OnChange", "if (!CheckInt(this, '" & ddlLabel.Items(3).Text.Trim & "')) {this.focus();this.value=0}")
            'txtToID.Attributes.Add("OnChange", "if (!CheckInt(this, '" & ddlLabel.Items(3).Text.Trim & "')) {this.focus();this.value=0}")
            txtPageSize.Attributes.Add("OnChange", "if (!CheckInt(this, '" & ddlLabel.Items(3).Text.Trim & "')) {this.focus(); this.value=20}")
            txtCollum.Attributes.Add("OnChange", "if (!CheckInt(this, '" & ddlLabel.Items(3).Text.Trim & "')) {this.focus(); this.value=4}")

            btnReset.Attributes.Add("OnClick", "ClearAll(); return false;")
            btnPrint.Attributes.Add("OnClick", "if (!CheckAll('" & ddlLabel.Items(3).Text & "')){return false;}")
        End Sub

        ' BindData method
        Private Sub BindData()
            Dim tblTemplate As New DataTable
            Dim tblPatronGroup As New DataTable
            Dim tblFaculty As New DataTable
            ' Get all patron template card
            objBCT.TemplateID = 0
            objBCT.TemplateType = 5
            tblTemplate = objBCT.GetTemplate()
            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBCT.ErrorMsg, ddlLabel.Items(1).Text, objBCT.ErrorCode)

            If Not tblTemplate Is Nothing Then
                If tblTemplate.Rows.Count > 0 Then
                    ddlFormat.DataSource = tblTemplate
                    ddlFormat.DataTextField = "Title"
                    ddlFormat.DataValueField = "ID"
                    ddlFormat.DataBind()
                    ddlFormat.Items(0).Selected = True
                End If
            End If
            tblTemplate = Nothing
            ' Get all Patron group
            tblPatronGroup = objBPG.GetPatronGroup
            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPG.ErrorMsg, ddlLabel.Items(1).Text, objBPG.ErrorCode)

            If Not tblPatronGroup Is Nothing Then
                If tblPatronGroup.Rows.Count > 0 Then
                    ddlPatronGroup.DataSource = InsertOneRow(tblPatronGroup, "               ")
                    ddlPatronGroup.DataTextField = "Name"
                    ddlPatronGroup.DataValueField = "ID"
                    ddlPatronGroup.DataBind()
                End If
            End If
            tblPatronGroup = Nothing

            tblFaculty = objBF.GetFaculty
            If Not tblFaculty Is Nothing AndAlso tblFaculty.Rows.Count > 0 Then
                ddlFaculty.DataSource = Me.InsertOneRow(tblFaculty, ddlLabel.Items(7).Text)
                ddlFaculty.DataTextField = "Faculty"
                ddlFaculty.DataValueField = "ID"
                ddlFaculty.DataBind()
            End If
            tblFaculty = Nothing
        End Sub

        ' Event: btnPrint_Click
        Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
            Dim blnFound As Boolean = False
            Dim tblFaculty As DataTable
            Call WriteFormLog()

            objBPC.TypeSearch = "Simple"
            If ddlMaxRec.SelectedItem.Value <> 0 Then
                objBPC.SelectTop = ddlMaxRec.SelectedItem.Value
            End If
            If optID.Checked Then
                If Trim(txtFromID.Text) <> "" Then
                    objBPC.FromCode = txtFromID.Text
                End If
                If Trim(txtToID.Text) <> "" Then
                    objBPC.ToCode = txtToID.Text
                End If
            End If
            If optValidDate.Checked Then
                If Trim(txtFromValidDate.Text) <> "" Then
                    objBPC.FromValidDate = txtFromValidDate.Text
                End If
                If Trim(txtToValidDate.Text) <> "" Then
                    objBPC.ToValidDate = txtToValidDate.Text
                End If
            End If
            If optCode.Checked Then
                If Trim(txtCode.Text) <> "" Then
                    objBPC.Code = txtCode.Text
                End If
            End If
            If optClass.Checked Then
                If Trim(txtClass.Text) <> "" Then
                    objBPC.Classs = txtClass.Text
                End If
                'If Trim(txtFaculty.Text) <> "" Then
                '    objBF.Faculty = txtFaculty.Text
                '    tblFaculty = objBF.GetFaculty
                '    If Not tblFaculty Is Nothing AndAlso tblFaculty.Rows.Count > 0 Then
                '        objBPC.Faculty = tblFaculty.Rows(0).Item("ID")
                '    End If
                'End If
                If ddlFaculty.SelectedValue > 0 Then
                    objBPC.Faculty = ddlFaculty.SelectedValue
                End If
            End If
            If ddlPatronGroup.SelectedItem.Value <> 0 Then
                objBPC.PatronGroupID = ddlPatronGroup.SelectedItem.Value.ToString
            End If

            Dim ArrRet()
            ArrRet = objBPC.Search()

            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPC.ErrorMsg, ddlLabel.Items(1).Text, objBPC.ErrorCode)

            Dim strIDs As String
            strIDs = ""
            If Not ArrRet Is Nothing Then
                If IsArray(ArrRet) Then
                    Dim inti As Integer
                    For inti = LBound(ArrRet) To UBound(ArrRet)
                        strIDs = strIDs & CStr(ArrRet(inti)) & ","
                    Next
                    If strIDs <> "" Then
                        strIDs = Left(strIDs, Len(strIDs) - 1)
                    End If
                End If
            End If
            objBP.PatronIDs = strIDs
            Session("strPatronIDs") = Nothing
            Session("strPatronIDs") = strIDs
            ' Get Patron data to generate

            Dim dataTemp As DataTable = objBP.GetPatron
            Dim view As DataView = dataTemp.DefaultView
            view.Sort = "Code ASC"
            Dim dataOrderByPatronCode As DataTable = view.ToTable()

            objBPC.DataToGen = dataOrderByPatronCode

            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBP.ErrorMsg, ddlLabel.Items(1).Text, objBP.ErrorCode)

            objBPC.TemplateID = ddlFormat.SelectedItem.Value
            Session("TemplateID") = Nothing
            Session("TemplateID") = ddlFormat.SelectedItem.Value
            objBPC.Rotate = ddlRotate.SelectedItem.Value
            objBPC.TypeBarcode = ddlFormatBarcode.SelectedItem.Value
            objBPC.TypePic = ddlPicType.SelectedItem.Value
            objBPC.GenDataTemplate()

            Dim ArrBarcode() As Object
            ArrBarcode = objBPC.DataBarCode
            If Not ArrBarcode Is Nothing Then
                If IsArray(ArrBarcode) Then
                    If UBound(ArrBarcode) >= 0 Then
                        Dim inti As Integer
                        For inti = LBound(ArrBarcode) To UBound(ArrBarcode)
                            Session("bc" & inti) = Nothing
                            Session("bc" & inti) = ArrBarcode(inti)
                        Next
                        Session("ArrCards") = Nothing
                        Session("ArrCards") = objBPC.ReturnData()
                        Session("PageSize") = Nothing
                        Session("PageSize") = txtPageSize.Text
                        Session("PgCols") = Nothing
                        Session("PgCols") = txtCollum.Text
                        Response.Redirect("WCardFrame.aspx")
                        blnFound = True
                    End If
                End If
            End If

            If Not blnFound Then
                Page.RegisterClientScriptBlock("AlertJS", "<script language = 'javascript'>alert('" & ddlLabel.Items(6).Text.Trim & "');</script>")
            End If
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBCT Is Nothing Then
                objBCT.Dispose(True)
                objBCT = Nothing
            End If
            If Not objBPC Is Nothing Then
                objBPC.Dispose(True)
                objBPC = Nothing
            End If
            If Not objBPG Is Nothing Then
                objBPG.Dispose(True)
                objBPG = Nothing
            End If
            If Not objBF Is Nothing Then
                objBF.Dispose(True)
                objBF = Nothing
            End If
        End Sub
    End Class
End Namespace