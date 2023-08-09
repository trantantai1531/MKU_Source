' Class: WFilter
' Puspose: Filter requests
' Creator: Sondp
' CreatedDate: 25/11/2004
' Modification History:
'   - 24/04/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.ILL

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WFilter
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblMsg1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel2 As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBILLLibrary As New clsBILLLibrary
        Private objBILLInRequestCollection As New clsBILLInRequestCollection
        Private objBILLOutRequestCollection As New clsBILLOutRequestCollection

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call BindAllLibrary()
                If Not Request.QueryString("Type") Is Nothing Then
                    Select Case Request.QueryString("Type")
                        Case "1"
                            lblInPageTitle.Visible = True
                            lblOutPageTitle.Visible = False
                            lblSentPlace.Visible = True
                            lblReceivePlace.Visible = False
                            ddlInTimeMode.Visible = True
                            ddlInTimeMode.SelectedIndex = 0
                            ddlOutTimeMode.Visible = False
                        Case "2"
                            lblInPageTitle.Visible = False
                            lblOutPageTitle.Visible = True
                            lblSentPlace.Visible = True
                            lblReceivePlace.Visible = False
                            ddlInTimeMode.Visible = False
                            ddlOutTimeMode.Visible = True
                            ddlOutTimeMode.SelectedIndex = 0
                    End Select
                End If
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: Init all need objects
        Private Sub Initialize()
            ' Init for objBILLLibrary
            objBILLLibrary.InterfaceLanguage = Session("InterfaceLanguage")
            objBILLLibrary.DBServer = Session("DBServer")
            objBILLLibrary.ConnectionString = Session("ConnectionString")
            Call objBILLLibrary.Initialize()

            ' Init for objBILLInRequestCollection
            objBILLInRequestCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBILLInRequestCollection.DBServer = Session("DBServer")
            objBILLInRequestCollection.ConnectionString = Session("ConnectionString")
            Call objBILLInRequestCollection.Initialize()

            ' Init for objBILLOutRequestCollection
            objBILLOutRequestCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBILLOutRequestCollection.DBServer = Session("DBServer")
            objBILLOutRequestCollection.ConnectionString = Session("ConnectionString")
            Call objBILLOutRequestCollection.Initialize()
        End Sub

        ' Method: BindScript
        ' Purpose: Include all need js functions
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = 'Js/WFilter.js'></script>")

            If Not Request.QueryString("Type") Is Nothing Then
                Select Case Request.QueryString("Type")
                    Case "1"
                        btnFilter.Attributes.Add("OnClick", "javascript:if (!CheckAllIn()) {alert('" & ddlLabel.Items(2).Text & "'); return false;}")
                    Case "2"
                        btnFilter.Attributes.Add("OnClick", "javascript:if (!CheckAllOut()) {alert('" & ddlLabel.Items(2).Text & "'); return false;}")
                End Select
                Me.RegisterCalendar("..")
                SetOnclickCalendar(lnkFromDate, txtFromDate, ddlLabel.Items(3).Text)
                SetOnclickCalendar(lnkToDate, txtToDate, ddlLabel.Items(3).Text)

                btnReset.Attributes.Add("OnClick", "ResetForm(); return false;")
                btnBack.Attributes.Add("OnClick", "javascript:Filter();")
            End If
        End Sub

        ' Event: btnFilter_Click
        Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
            ' Declare variables
            Dim inti As Integer = 0
            Dim strLibIDs As String = ""
            Dim tblTemp As DataTable
            Dim intRowCount As Integer = 0
            Dim intIndex As Integer = 0
            Dim strRequestIDs As String

            If Not Request.QueryString("Type") Is Nothing Then
                strLibIDs = hidIDs.Value
                If Trim(strLibIDs) <> "" Then
                    strLibIDs = Left(strLibIDs, Len(strLibIDs) - 1)
                End If
                Select Case Request.QueryString("Type")
                    Case "1"
                        objBILLInRequestCollection.LibIDs = strLibIDs
                        objBILLInRequestCollection.TimeMode = ddlInTimeMode.SelectedValue
                        objBILLInRequestCollection.TimeFrom = txtFromDate.Text.Trim
                        objBILLInRequestCollection.TimeTo = txtToDate.Text.Trim
                        objBILLInRequestCollection.Title = txtTitle.Text.Trim
                        objBILLInRequestCollection.Author = txtAuthor.Text.Trim
                        objBILLInRequestCollection.PatronName = txtPatronName.Text.Trim
                        objBILLInRequestCollection.PatronCode = txtPatronCode.Text.Trim
                        objBILLInRequestCollection.DocType = ddlDocType.SelectedValue
                        tblTemp = objBILLInRequestCollection.FilterIRList

                        ' Check error
                        Call WriteErrorMssg(ddlLabel.Items(1).Text, objBILLInRequestCollection.ErrorMsg, ddlLabel.Items(0).Text, objBILLInRequestCollection.ErrorCode)

                        If Not tblTemp Is Nothing Then
                            If tblTemp.Rows.Count > 0 Then
                                intRowCount = tblTemp.Rows.Count
                                For intIndex = 0 To intRowCount - 1
                                    strRequestIDs = strRequestIDs & tblTemp.Rows(intIndex).Item("ID") & ","
                                Next
                                Session("IRIDs") = Left(strRequestIDs, Len(strRequestIDs) - 1)
                            End If
                        End If

                        If intRowCount > 0 Then
                            Page.RegisterClientScriptBlock("OkFoundJs", "<script language = 'javascript'>Filter();window.location.href='IRMan/WIRMan.aspx';</script>")
                        Else
                            Page.RegisterClientScriptBlock("NotFoundJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(4).Text & "');</script>")
                        End If
                    Case "2"
                        objBILLOutRequestCollection.LibIDs = strLibIDs
                        objBILLOutRequestCollection.TimeMode = ddlOutTimeMode.SelectedValue
                        objBILLOutRequestCollection.TimeFrom = txtFromDate.Text.Trim
                        objBILLOutRequestCollection.TimeTo = txtToDate.Text.Trim
                        objBILLOutRequestCollection.Title = txtTitle.Text.Trim
                        objBILLOutRequestCollection.Author = txtAuthor.Text.Trim
                        objBILLOutRequestCollection.PatronName = txtPatronName.Text.Trim
                        objBILLOutRequestCollection.PatronCode = txtPatronCode.Text.Trim
                        objBILLOutRequestCollection.DocType = ddlDocType.SelectedValue
                        tblTemp = objBILLOutRequestCollection.FilterORList

                        ' Check error
                        Call WriteErrorMssg(ddlLabel.Items(1).Text, objBILLOutRequestCollection.ErrorMsg, ddlLabel.Items(0).Text, objBILLOutRequestCollection.ErrorCode)

                        If Not tblTemp Is Nothing Then
                            If tblTemp.Rows.Count > 0 Then
                                intRowCount = tblTemp.Rows.Count
                                For intIndex = 0 To intRowCount - 1
                                    strRequestIDs = strRequestIDs & tblTemp.Rows(intIndex).Item("ID") & ","
                                Next
                                Session("ORIDs") = Left(strRequestIDs, Len(strRequestIDs) - 1)
                            End If
                        End If

                        If intRowCount > 0 Then
                            Page.RegisterClientScriptBlock("OkFoundJs", "<script language = 'javascript'>Filter();window.location.href='ORMan/WORMan.aspx';</script>")
                        Else
                            Page.RegisterClientScriptBlock("NotFoundJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(4).Text & "');</script>")
                        End If
                End Select
            End If
        End Sub

        ' Event: btnBack_Click
        Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
            If Not Request.QueryString("Type") Is Nothing Then
                Select Case Request.QueryString("Type")
                    Case "1"
                        Response.Redirect("IRMan/WIRMan.aspx")
                    Case "2"
                        Response.Redirect("ORMan/WORMan.aspx")
                End Select
            End If
        End Sub

        ' Method: BindAllLibrary
        Private Sub BindAllLibrary()
            Dim tblLibrary As DataTable
            Dim intIndex As Integer

            ' bind the library
            objBILLLibrary.LibID = 0
            tblLibrary = objBILLLibrary.GetLib

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBILLLibrary.ErrorMsg, ddlLabel.Items(0).Text, objBILLLibrary.ErrorCode)

            If Not tblLibrary Is Nothing Then
                If tblLibrary.Rows.Count > 0 Then
                    lsbLib.DataSource = tblLibrary
                    lsbLib.DataTextField = "LibName"
                    lsbLib.DataValueField = "ID"
                    lsbLib.DataBind()
                End If
            End If
        End Sub

        ' Event: Page UnLoad
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBILLLibrary Is Nothing Then
                    objBILLLibrary.Dispose(True)
                    objBILLLibrary = Nothing
                End If
                If Not objBILLInRequestCollection Is Nothing Then
                    objBILLInRequestCollection.Dispose(True)
                    objBILLInRequestCollection = Nothing
                End If
                If Not objBILLOutRequestCollection Is Nothing Then
                    objBILLOutRequestCollection.Dispose(True)
                    objBILLOutRequestCollection = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace