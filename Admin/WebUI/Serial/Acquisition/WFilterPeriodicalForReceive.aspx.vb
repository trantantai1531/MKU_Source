' Class: WFilterPeriodicalForReceive
' Puspose: Filter Periodical For Receive
' Creator: Oanhtn
' CreatedDate: 21/09/2004
' Modification history:
'   + 21/04/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Serial
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WFilterPeriodicalForReceive
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
        Private blnFound As Boolean = False

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJavascript()
            If Not Page.IsPostBack Then
                Call LoadLocation()
            End If
        End Sub
        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(218) Then
                Call WriteErrorMssg(ddlLabel.Items(5).Text)
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
        End Sub

        ' BindJavascript method
        ' Purpose: Include all javascript functions
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../Js/Acquisition/WFilterPeriodicalForReceive.js'></script>")
            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkIssuedDate, txtIssuedDate, ddlLabel.Items(2).Text)
            SetOnclickCalendar(lnkReceivedDate, txtReceivedDate, ddlLabel.Items(2).Text)
            btnSearch.Attributes.Add("OnClick", "return CheckSearch('" & ddlLabel.Items(3).Text & "');")
        End Sub

        ' LoadLocation method
        ' Purpose: Load user's locations in right
        Private Sub LoadLocation()
            Dim tblTemp As DataTable

            txtIssuedDate.Text = Session("ToDay")

            ' Get Locations
            tblTemp = objBCommonBusiness.GetLocations(3)

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCommonBusiness.ErrorMsg, ddlLabel.Items(0).Text, objBCommonBusiness.ErrorCode)

            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    ddlLocation.DataSource = tblTemp
                    ddlLocation.DataTextField = "LOCNAME"
                    ddlLocation.DataValueField = "ID"
                    ddlLocation.DataBind()

                    Call ShowData(tblTemp.Rows(0).Item("ID"), txtIssuedDate.Text)
                End If
                ' Release object
                tblTemp = Nothing
            End If
        End Sub

        ' btnSearch_Click event
        ' Purpose: Search now
        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            Call ShowData(ddlLocation.SelectedValue, txtIssuedDate.Text)

            If blnFound = False Then
                Page.RegisterClientScriptBlock("NotFound", "<script language='javascript'>alert('" & ddlLabel.Items(4).Text & "')</script>")
            End If
        End Sub

        ' ShowData method
        ' Purpose: show search result
        Private Sub ShowData(ByVal intLocationID As Integer, ByVal strIssuedDate As String)
            Dim tblTemp As DataTable

            dtgResult.Visible = False

            ' Get Locations
            tblTemp = objBPeriodicalCollection.FilterPeriodicalForReceive(intLocationID, Trim(strIssuedDate), txtReceivedDate.Text.Trim)

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
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
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
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace