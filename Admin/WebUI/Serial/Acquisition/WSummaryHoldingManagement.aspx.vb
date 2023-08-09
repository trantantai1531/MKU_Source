Imports eMicLibAdmin.BusinessRules.Serial
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WSummaryHoldingManagement
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
        Private objBPeriodical As New clsBPeriodical

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            If Not Page.IsPostBack Then
                If Trim(CStr(Request("Update"))) <> "" Then
                    Call BindAcqData()
                Else
                    Call GetSummaryHolding()
                End If
            End If
            lblTitle.Text = Session("Title")
        End Sub

        ' CheckFormPermission method
        ' Purpose: check the user permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(93) Then
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            If Not Session("ItemID") Is Nothing Then
                If Not IsNumeric(Session("ItemID")) Then
                    Response.Redirect("../WSearch.aspx?URL=Acquisition/WSummaryHoldingManagement.aspx")
                End If
            End If

            ' Init for objBPeriodical
            objBPeriodical.InterfaceLanguage = Session("InterfaceLanguage")
            objBPeriodical.DBServer = Session("DBServer")
            objBPeriodical.ConnectionString = Session("ConnectionString")
            objBPeriodical.ItemID = CInt(Session("ItemID"))
            objBPeriodical.Initialize()
        End Sub

        ' BindAcqData method
        Private Sub BindAcqData()
            ' Declare variables
            Dim tblYear As DataTable
            Dim intCount As Integer
            Dim intYearCount As Integer
            Dim intYear As Integer
            Dim intResetReg As Integer
            Dim strMonths As String
            Dim strHavingYearIssue As String
            Dim strFirstIssueInYear As String
            Dim strHas, strLost As String

            ' Get the years that Item has been registered
            objBPeriodical.ItemID = Session("ItemID")
            objBPeriodical.LocationID = 0
            tblYear = objBPeriodical.GetReceivedYear()

            ' Write Error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPeriodical.ErrorMsg, ddlLabel.Items(1).Text, objBPeriodical.ErrorCode)

            ' Get the summary holding of each year
            If Not tblYear Is Nothing AndAlso tblYear.Rows.Count > 0 Then
                intYearCount = tblYear.Rows.Count - 1
                txtAcqData.Text = ""
                For intCount = 0 To intYearCount
                    ' Declare variable 
                    intYear = CInt(tblYear.Rows(intCount).Item(0))
                    Call objBPeriodical.GetReceiveIssueNums(intYear, intResetReg, strMonths, strHavingYearIssue, strFirstIssueInYear)
                    clsGetIssueNos.GetHasLostIssueNo(intResetReg, strMonths, strHavingYearIssue, strFirstIssueInYear, ddlLabel.Items(7).Text, ddlLabel.Items(5).Text, "", strHas, strLost)
                    strHas = strHas.Replace("<br>", vbCrLf)
                    If txtAcqData.Text = "" Then
                        txtAcqData.Text = intYear & ":" & vbCrLf & strHas
                    Else
                        txtAcqData.Text &= vbCrLf & intYear & ":" & vbCrLf & strHas
                    End If
                Next
            End If
        End Sub

        ' btnUpdate_Click event
        ' Purpose: Update the summary holding for the issue 
        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Dim strSumarryHolding As String
            strSumarryHolding = Replace(txtAcqData.Text, vbCrLf, "<BR>")
            objBPeriodical.SummaryHolding = strSumarryHolding
            objBPeriodical.Note = Replace(txtNote.Text, vbCrLf, "<BR>")
            objBPeriodical.UpdateSummaryHolding()

            ' Write Error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPeriodical.ErrorMsg, ddlLabel.Items(1).Text, objBPeriodical.ErrorCode)

            ' WriteLog
            Call WriteLog(34, ddlLabel.Items(3).Text & " (ItemID:" & Session("ItemID") & ", " & ddlLabel.Items(4).Text & ": " & Session("Title") & ")", Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

            Page.RegisterClientScriptBlock("Success", "<script>alert('" & ddlLabel.Items(6).Text & "')</script>")
        End Sub

        ' GetSummaryHolding method
        ' Get the Summary Holding of an Item
        Private Sub GetSummaryHolding()
            Dim tblSummaryHolding As DataTable
            tblSummaryHolding = objBPeriodical.GetSummaryHolding

            ' Write Error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPeriodical.ErrorMsg, ddlLabel.Items(1).Text, objBPeriodical.ErrorCode)

            If Not tblSummaryHolding Is Nothing Then
                If tblSummaryHolding.Rows.Count > 0 Then
                    If Not IsDBNull(tblSummaryHolding.Rows(0).Item(0)) Then
                        txtAcqData.Text = Replace(CStr(tblSummaryHolding.Rows(0).Item(0)), "<BR>", vbCrLf)
                    End If
                Else
                    txtAcqData.Text = ""
                End If
            Else
                txtAcqData.Text = ""
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
                If Not objBPeriodical Is Nothing Then
                    objBPeriodical.Dispose(True)
                    objBPeriodical = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace