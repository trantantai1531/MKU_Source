Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WFeesReport
        Inherits clsWBase

        ' Declare variables
        Private objBAccounting As New clsBAccounting
        Private objBBudget As New clsBBudget

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
            If Not Page.IsPostBack Then
                Call BindData()
            End If
            Page.RegisterClientScriptBlock("PrintActionJs", "<script language='javascript'>self.focus();setTimeout('self.print()', 1);</script>")
        End Sub

        ' Initialize method
        ' Purpose: Init all object
        Private Sub Initialize()
            ' Init for objBAccounting
            objBAccounting.InterfaceLanguage = Session("InterfaceLanguage")
            objBAccounting.DBServer = Session("DBServer")
            objBAccounting.ConnectionString = Session("ConnectionString")
            objBAccounting.Initialize()

            ' Init for objBBudget
            objBBudget.InterfaceLanguage = Session("InterfaceLanguage")
            objBBudget.DBServer = Session("DBServer")
            objBBudget.ConnectionString = Session("ConnectionString")
            objBBudget.Initialize()
        End Sub

        ' BindData method
        ' Purpose: Bind the account data
        Private Sub BindData()
            ' Declare variable
            Dim tblAccount As DataTable
            Dim intMonth As Integer = 0
            Dim intYear As Integer = 0
            Dim strBudget As String = ""
            Dim intDisplay As Int16 = 1
            Dim tblBudget As DataTable

            ' Display the pay fees list
            If Trim(Request("Display")) = "1" Or Trim(Request("Display")) = Nothing Then
                intDisplay = 1
                lblSpendTitle.Visible = True
                lblReceivedTitle.Visible = False
            ElseIf Trim(Request("Display")) = "2" Then
                intDisplay = 2
                lblSpendTitle.Visible = False
                lblReceivedTitle.Visible = True
            End If

            ' Month
            If Not Request("Month") & "" = "" Then
                intMonth = Request("Month")
            End If

            ' Year
            If Not Request("Year") & "" = "" Then
                intYear = Request("Year")
            End If

            If Not Request("BudgetID") & "" = "" Then
                objBAccounting.BudgetID = CInt(Request("BudgetID"))
                objBBudget.BudID = CInt(Request("BudgetID"))
                tblBudget = objBBudget.GetBudget
                ' Write the error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBBudget.ErrorMsg, ddlLabel.Items(0).Text, objBBudget.ErrorCode)
                If Not tblBudget Is Nothing Then
                    If tblBudget.Rows.Count > 0 Then
                        strBudget = tblBudget.Rows(0).Item("BudgetName")
                    End If
                End If
            End If

            tblAccount = objBAccounting.GetAccountInfor(intDisplay, intMonth, intYear)

            dgtResult.DataSource = tblAccount
            dgtResult.DataBind()

            ' Get the SubTitle
            If Not strBudget = "" Then
                lblSubTitle.Text = lblSubTitle.Text & ddlLabel.Items(2).Text & " " & strBudget
            End If

            If intMonth = 0 Then
                lblSubTitle.Text = lblSubTitle.Text & " " & ddlLabel.Items(4).Text & " " & intYear
            Else
                lblSubTitle.Text = lblSubTitle.Text & " " & ddlLabel.Items(3).Text & " " & intMonth
                lblSubTitle.Text = lblSubTitle.Text & " " & ddlLabel.Items(4).Text & " " & intYear
            End If

            If Trim(lblSubTitle.Text) <> "" Then
                lblSubTitle.Visible = True
            Else
                lblSubTitle.Visible = False
            End If
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBAccounting Is Nothing Then
                    objBAccounting.Dispose(True)
                    objBAccounting = Nothing
                End If
                If Not objBBudget Is Nothing Then
                    objBBudget.Dispose(True)
                    objBBudget = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
