' class WPOPrintSearch
' Puspose: Manager Template
' Creator: Sondp
' CreatedDate: 15/03/2005
' Modification History:

Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition


Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WPOPrintSearch
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents alterInvalidDateFormat As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents alterMissData As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents strSelectSumCurrency As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents strSelectCurrency As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents strSelectMedium As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents strSelectMedia As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents strSelectPublisher As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents strPO As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents lblSelect As System.Web.UI.WebControls.Label
        Protected WithEvents lblFormSelected As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private objBCB As New clsBCommonBusiness
        Private objBT As New clsBTemplate
        Private objBIO As New clsBItemOrder

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call CheckFormPermission()
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                If Request("Found") & "" <> "" Then
                    Page.RegisterClientScriptBlock("ItemNotfoundAlert", "<script language='javascript'>alert('" & ddlLabel.Items(8).Text & "');</script>")
                End If
                Call BindData()
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Initialize objBCB object
            objBCB.InterfaceLanguage = Session("InterfaceLanguage")
            objBCB.DBServer = Session("DBServer")
            objBCB.ConnectionString = Session("ConnectionString")
            objBCB.Initialize()
            ' Initialize objBT object
            objBT.InterfaceLanguage = Session("InterfaceLanguage")
            objBT.DBServer = Session("DBServer")
            objBT.ConnectionString = Session("ConnectionString")
            objBT.Initialize()
            ' Initialize objBIO object
            objBIO.InterfaceLanguage = Session("InterfaceLanguage")
            objBIO.DBServer = Session("DBServer")
            objBIO.ConnectionString = Session("ConnectionString")
            objBIO.Initialize()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WPOPrintSearchJs", "<script language='javascript' src='../Js/PO/WPOPrint.js'></script>")

            ddlSumCurrency.Attributes.Add("OnChange", "return(BindSumCurrency());")
            ddlCurrency.Attributes.Add("OnChange", "return(BindCurrency());")

            optAll.Attributes.Add("OnClick", "document.forms[0].hdAccepted.value='2';")
            optNotAccepted.Attributes.Add("OnClick", "document.forms[0].hdAccepted.value='0';")
            optAccepted.Attributes.Add("OnClick", "document.forms[0].hdAccepted.value='1';")

            btnPreview.Attributes.Add("OnClick", "return(Submit('" & ddlLabel.Items(5).Text & "','Preview'));")
            btnEmail.Attributes.Add("OnClick", "if(GetEmailName('" & ddlLabel.Items(5).Text & "','" & ddlLabel.Items(6).Text & "','" & ddlLabel.Items(7).Text & "')) Submit('" & ddlLabel.Items(5).Text & "','Email');else return false;")
            btnPrint.Attributes.Add("OnClick", "return(Submit('" & ddlLabel.Items(5).Text & "','Print'));")
            btnSaveToFile.Attributes.Add("OnClick", "return(Submit('" & ddlLabel.Items(5).Text & "','File'));")

            Me.RegisterCalendar("../..")
            SetOnclickCalendar(hrfFromDate, txtFromDate, ddlLabel.Items(4).Text.Trim)
            SetOnclickCalendar(hrfToDate, txtToDate, ddlLabel.Items(4).Text.Trim)

        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(39) Then
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub

        ' BindData method
        Private Sub BindData()
            Dim tblData As New DataTable
            Dim inti As Integer
            ' Get currency
            tblData = objBCB.GetCurrency

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCB.ErrorMsg, ddlLabel.Items(0).Text, objBCB.ErrorCode)

            If Not tblData Is Nothing AndAlso tblData.Rows.Count > 0 Then
                ddlSumCurrency.DataSource = InsertOneRow(tblData, ddlLabel.Items(3).Text)
                ddlSumCurrency.DataTextField = "CurrencyCode"
                ddlSumCurrency.DataValueField = "Rate"
                ddlSumCurrency.DataBind()
                For inti = 0 To tblData.Rows.Count - 1
                    If CStr(tblData.Rows(inti).Item("CurrencyCode")).ToLower = "vnd" Then
                        ddlSumCurrency.SelectedIndex = inti + 1
                        Exit For
                    End If
                Next

                ddlCurrency.DataSource = InsertOneRow(tblData, ddlLabel.Items(3).Text)
                ddlCurrency.DataTextField = "CurrencyCode"
                ddlCurrency.DataValueField = "Rate"
                ddlCurrency.DataBind()
                For inti = 0 To tblData.Rows.Count - 1
                    If CStr(tblData.Rows(inti).Item("CurrencyCode")).ToLower = "vnd" Then
                        ddlCurrency.SelectedIndex = inti + 1
                        Exit For
                    End If
                Next

                tblData.Clear()
            End If

            ' Get medium
            tblData = objBCB.GetMediums
            If Not tblData Is Nothing AndAlso tblData.Rows.Count > 0 Then
                ddlMedia.DataSource = InsertOneRow(tblData, ddlLabel.Items(3).Text)
                ddlMedia.DataTextField = "Medium"
                ddlMedia.DataValueField = "ID"
                ddlMedia.DataBind()
                For inti = 0 To tblData.Rows.Count - 1
                    If CStr(tblData.Rows(inti).Item("Code")).ToLower = "g" Then
                        ddlMedia.SelectedIndex = inti + 1
                        Exit For
                    End If
                Next

                tblData.Clear()
            End If

            ' Get itemtype
            tblData = objBCB.GetItemTypes
            If Not tblData Is Nothing AndAlso tblData.Rows.Count > 0 Then
                ddlMedium.DataSource = InsertOneRow(tblData, ddlLabel.Items(3).Text)
                ddlMedium.DataTextField = "Type"
                ddlMedium.DataValueField = "ID"
                ddlMedium.DataBind()
                For inti = 0 To tblData.Rows.Count - 1
                    If CStr(tblData.Rows(inti).Item("TypeCode")).ToLower = "sh" Then
                        ddlMedium.SelectedIndex = inti + 1
                        Exit For
                    End If
                Next

                tblData.Clear()
            End If

            ' Get publisher
            tblData = objBIO.GetAcqPublisher
            If Not tblData Is Nothing AndAlso tblData.Rows.Count > 0 Then
                ddlPublisher.DataSource = InsertOneRow(tblData, ddlLabel.Items(3).Text)
                ddlPublisher.DataTextField = "Publisher"
                ddlPublisher.DataValueField = "Publisher"
                ddlPublisher.DataBind()
                ddlPublisher.Items(0).Value = ""
                tblData.Clear()
            End If

            ' Get Template
            objBT.TemplateID = 0
            objBT.TemplateType = 9
            objBT.LibID = clsSession.GlbSite
            tblData = objBT.GetTemplate
            If Not tblData Is Nothing AndAlso tblData.Rows.Count > 0 Then
                ddlForm.DataSource = InsertOneRow(tblData, ddlLabel.Items(3).Text)
                ddlForm.DataTextField = "Title"
                ddlForm.DataValueField = "ID"
                ddlForm.DataBind()
                tblData.Clear()
            End If
        End Sub

        ' Page_Unload method
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBCB Is Nothing Then
                objBCB.Dispose(True)
                objBCB = Nothing
            End If
            If Not objBT Is Nothing Then
                objBT.Dispose(True)
                objBT = Nothing
            End If
            If Not objBIO Is Nothing Then
                objBIO.Dispose(True)
                objBIO = Nothing
            End If
        End Sub
    End Class
End Namespace