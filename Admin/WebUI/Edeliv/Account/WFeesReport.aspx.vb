Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.Edeliv
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WFeesReport
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

        ' Declare variable
        Private objBAccountTrans As New clsBAccountTransaction

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPemission()
            Call Initialize()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
            Page.RegisterClientScriptBlock("PrintActionJs", "<script language='javascript'>self.focus();setTimeout('self.print()', 1);</script>")
        End Sub

        ' CheckFormPemission method
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            If Not CheckPemission(162) Then
                Call WriteErrorMssg(ddlLabel.Items(5).Text)
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBAccountTrans
            objBAccountTrans.InterfaceLanguage = Session("InterfaceLanguage")
            objBAccountTrans.DBServer = Session("DBServer")
            objBAccountTrans.ConnectionString = Session("ConnectionString")
            objBAccountTrans.Initialize()
        End Sub

        ' BindData method
        Private Sub BindData()
            ' Declare variables
            Dim strYear As String
            Dim strMonth As String
            Dim strCustomerCode As String
            Dim tblAccount As DataTable
            Dim intDisplay As Integer
            Dim dblSeetled As Double
            Dim dblUnSeetled As Double
            Dim dblRemain As Double

            ' Get the type of display mode (seetled, unseetled or report)
            If Trim(Request("Display")) = "1" Or Trim(Request("Display")) = Nothing Then
                intDisplay = 1
            ElseIf Trim(Request("Display")) = "2" Then
                intDisplay = 2
            End If

            ' Get the Customer code
            If Trim(Request("CustomerCode")) = "0" Or Trim(Request("CustomerCode")) = Nothing Then
                strCustomerCode = ""
            Else
                strCustomerCode = Trim(Request("CustomerCode"))
            End If

            ' Get the month value
            If Trim(Request("Month")) = "0" Or Trim(Request("Month")) = Nothing Then
                strMonth = "0"
            Else
                strMonth = Trim(Request("Month"))
            End If

            ' Get the year value
            If Trim(Request("Year")) = "0" Or Trim(Request("Year")) = Nothing Then
                strYear = "0"
            Else
                strYear = Trim(Request("Year"))
            End If

            ' Get the type of display mode (seetled, unseetled)
            If Trim(Request("Display")) = "1" Then
                intDisplay = 1
                lblSettledTitle.Visible = True
                lblUnsettledTitle.Visible = False
            ElseIf Trim(Request("Display")) = "2" Then
                intDisplay = 2
                lblSettledTitle.Visible = False
                lblUnsettledTitle.Visible = True
            End If

            ' Get the SubTitle
            If strCustomerCode <> "" Then
                lblSubTitle.Text = lblSubTitle.Text & ddlLabel.Items(0).Text & " " & strCustomerCode
                If strMonth <> "0" Then
                    lblSubTitle.Text = lblSubTitle.Text & " " & ddlLabel.Items(2).Text & " " & strMonth
                    If strYear <> "0" Then
                        lblSubTitle.Text = lblSubTitle.Text & " " & ddlLabel.Items(4).Text & " " & strYear
                    End If
                Else
                    If strYear <> "0" Then
                        lblSubTitle.Text = lblSubTitle.Text & " " & ddlLabel.Items(4).Text & " " & strYear
                    End If
                End If
            Else
                If strMonth <> "0" Then
                    lblSubTitle.Text = lblSubTitle.Text & ddlLabel.Items(1).Text & " " & strMonth
                    If strYear <> "0" Then
                        lblSubTitle.Text = lblSubTitle.Text & " " & ddlLabel.Items(4).Text & " " & strYear
                    End If
                Else
                    If strYear <> "0" Then
                        lblSubTitle.Text = lblSubTitle.Text & ddlLabel.Items(3).Text & " " & strYear
                    End If
                End If
            End If

            If Trim(lblSubTitle.Text) <> "" Then
                lblSubTitle.Visible = True
            Else
                lblSubTitle.Visible = False
            End If

            ' Transfer the properties for class B
            objBAccountTrans.Year = CInt(strYear)
            objBAccountTrans.CustomerCode = strCustomerCode
            objBAccountTrans.Month = CInt(strMonth)
            tblAccount = objBAccountTrans.GetAccInfor(intDisplay, dblSeetled, dblUnSeetled, dblRemain)  ' Get the data
            Call WriteErrorMssg(ddlLabel.Items(7).Text, objBAccountTrans.ErrorMsg, ddlLabel.Items(6).Text, objBAccountTrans.ErrorCode)


            ' Display the sum of seetled, unseetled and remain amount
            If Not tblAccount Is Nothing Then
                Select Case intDisplay
                    Case 1
                        lblSumary.Text = dblSeetled
                        If tblAccount.Rows.Count > 0 Then
                            TRSumary.Visible = True
                        Else
                            TRSumary.Visible = False
                        End If
                    Case 2
                        lblSumary.Text = dblUnSeetled
                        If tblAccount.Rows.Count > 0 Then
                            TRSumary.Visible = True
                        Else
                            TRSumary.Visible = False
                        End If
                End Select
            End If

            ' Display the result (For each display mode)
            If intDisplay = 1 Or intDisplay = 2 Then
                dgtResult.DataSource = tblAccount
                dgtResult.DataBind()
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
                If Not objBAccountTrans Is Nothing Then
                    objBAccountTrans.Dispose(True)
                    objBAccountTrans = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace