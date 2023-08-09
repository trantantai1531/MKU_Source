' Class: WFilterPeriodicalForRegister
' Puspose: Filter Periodical For Register
' Creator: Oanhtn
' CreatedDate: 21/09/2004
' Modification history:
'   21/04/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Serial
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WFilterPeriodicalForRegister
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
        Private objBCommonBusiness As New clsBCommonBusiness
        Private objBPeriodicalCollection As New clsBPeriodicalCollection
        Private objBItemCollection As New clsBItemCollection

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJavascript()
            Call BindHyperLink()
            If Not Page.IsPostBack Then
                Call BindDropDownList()
            End If
        End Sub
        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(83) Then
                Call WriteErrorMssg(ddlLabel.Items(6).Text)
            End If
        End Sub
        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init objBCommonBusiness object
            objBCommonBusiness.ConnectionString = Session("ConnectionString")
            objBCommonBusiness.DBServer = Session("DBServer")
            objBCommonBusiness.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonBusiness.UserID = Session("UserID")
            Call objBCommonBusiness.Initialize()

            ' Init objBPeriodicalCollection object 
            objBPeriodicalCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBPeriodicalCollection.DBServer = Session("DBServer")
            objBPeriodicalCollection.ConnectionString = Session("ConnectionString")
            Call objBPeriodicalCollection.Initialize()

            ' Init for objBPeriodicalCollection
            objBItemCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemCollection.DBServer = Session("DBServer")
            objBItemCollection.ConnectionString = Session("ConnectionString")
            objBItemCollection.Initialize()
        End Sub

        ' BindJavascript method
        ' Purpose: Include all javascript functions
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../Js/Acquisition/WFilterPeriodicalForRegister.js'></script>")
            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkIssuedDate, txtIssuedDate, ddlLabel.Items(2).Text)

            btnSearch.Attributes.Add("OnClick", "if (!CheckAll()) {alert('" & ddlLabel.Items(3).Text & "'); return false;}")
            btnReset.Attributes.Add("OnClick", "document.forms[0].reset(); return false;")
        End Sub

        ' BindDropDownList method
        ' Purpose: Load user's locations in right amd the system view of user
        Private Sub BindDropDownList()
            Dim tblTemp As DataTable
            Dim tblSysView As DataTable
            Dim lsItem As New ListItem

            ' Set default IssuedDate
            txtIssuedDate.Text = Session("ToDay")

            ' Get Regularity
            tblTemp = objBCommonBusiness.GetRegularity

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCommonBusiness.ErrorMsg, ddlLabel.Items(0).Text, objBCommonBusiness.ErrorCode)

            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    tblTemp = InsertOneRow(tblTemp, ddlLabel.Items(4).Text)
                    ddlRegularity.DataSource = tblTemp
                    ddlRegularity.DataTextField = "DisplayEntry"
                    ddlRegularity.DataValueField = "RegularityCode"
                    ddlRegularity.DataBind()
                End If

                ' Release object
                tblTemp = Nothing
            End If

            ' Get the list of user views
            tblSysView = objBItemCollection.GetSysUserViews(clsSession.GlbUser)
            ' Write Error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBItemCollection.ErrorMsg, ddlLabel.Items(0).Text, objBItemCollection.ErrorCode)

            If Not tblSysView Is Nothing Then
                tblSysView = InsertOneRow(tblSysView, Trim(ddlLabel.Items(4).Text))
                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, ErrorMsg, ddlLabel.Items(0).Text, ErrorCode)
            End If

            ' Bind the user views in the drop down list
            If Not tblSysView Is Nothing Then
                If tblSysView.Rows.Count > 0 Then
                    ddlGroup.DataSource = tblSysView
                    ddlGroup.DataTextField = "ViewName"
                    ddlGroup.DataValueField = "ViewCode"
                    ddlGroup.DataBind()
                Else
                    ddlGroup.Items.Clear()
                    lsItem.Text = ddlLabel.Items(4).Text
                    lsItem.Value = 0
                    ddlGroup.Items.Add(lsItem)
                End If
            Else
                ddlGroup.Items.Clear()
                lsItem.Text = ddlLabel.Items(4).Text
                lsItem.Value = 0
                ddlGroup.Items.Add(lsItem)
            End If
        End Sub

        ' btnSearch_Click event
        ' Purpose: search now
        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            Dim tblTemp As DataTable
            Dim chrRegularityCode As String = ""
            Dim blnFound As Boolean = False

            dtgResult.Visible = False

            If Not Len(ddlRegularity.SelectedValue) > 1 AndAlso ddlRegularity.SelectedIndex > 0 Then
                chrRegularityCode = ddlRegularity.SelectedValue
            End If
            objBPeriodicalCollection.LibID = clsSession.GlbSite
            ' Show data
            If ddlGroup.SelectedIndex = 0 Then
                tblTemp = objBPeriodicalCollection.FilterPeriodicalForRegister(Trim(txtIssuedDate.Text), Trim(txtPubCountry.Text), Trim(txtPubLanguage.Text), chrRegularityCode, "")
            Else
                tblTemp = objBPeriodicalCollection.FilterPeriodicalForRegister(Trim(txtIssuedDate.Text), Trim(txtPubCountry.Text), Trim(txtPubLanguage.Text), chrRegularityCode, ddlGroup.SelectedValue)
            End If


            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPeriodicalCollection.ErrorMsg, ddlLabel.Items(0).Text, objBPeriodicalCollection.ErrorCode)

            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    blnFound = True
                    dtgResult.Visible = True
                    dtgResult.DataSource = tblTemp
                    dtgResult.DataBind()
                End If

                ' Release object
                tblTemp = Nothing
            End If

            If blnFound = False Then
                Page.RegisterClientScriptBlock("NotFound", "<script>alert('" & ddlLabel.Items(5).Text & "')</script>")
            End If

        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' BindHyperLink method
        ' Purpose: Bind the javascripts to the hiperlinks 
        Private Sub BindHyperLink()
            ' Declare variables
            Dim strJavaScript1 As String
            Dim strJavaScript2 As String

            ' Get the string of javascripts
            strJavaScript1 = "'../WGetReferences.aspx?Frame=txtPubCountry&DicID=11&SearchData=' + document.forms[0].txtPubCountry.value"
            strJavaScript2 = "'../WGetReferences.aspx?Frame=txtPubLanguage&DicID=10&SearchData=' + document.forms[0].txtPubLanguage.value"

            lnkPubCountry.NavigateUrl = "javascript:OpenWindow(" & strJavaScript1 & ",'Dictionary',350,300,150,30)"
            lnkPubLanguage.NavigateUrl = "javascript:OpenWindow(" & strJavaScript2 & ",'Dictionary',350,300,150,30)"
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCommonBusiness Is Nothing Then
                    objBCommonBusiness.Dispose(True)
                    objBCommonBusiness = Nothing
                End If
                If Not objBPeriodicalCollection Is Nothing Then
                    objBPeriodicalCollection.Dispose(True)
                    objBPeriodicalCollection = Nothing
                End If
                If Not objBItemCollection Is Nothing Then
                    objBItemCollection.Dispose(True)
                    objBItemCollection = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace