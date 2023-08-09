Imports eMicLibAdmin.BusinessRules.Edeliv
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WRequestFilter
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

        Dim objBERequestCollection As New clsBERequestCollection

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPemission()
            Call Initialize()
            Call BindJS()
        End Sub

        ' CheckFormPemission method
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            If Not CheckPemission(159) Then
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBERequestCollection object
            objBERequestCollection.ConnectionString = Session("ConnectionString")
            objBERequestCollection.DBServer = Session("DBServer")
            objBERequestCollection.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBERequestCollection.Initialize()
        End Sub

        ' BindJS method
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../Js/Request/WRequestFilter.js'></script>")
            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkTimeFrom, txtTimeFrom, ddlLabel.Items(5).Text)
            SetOnclickCalendar(lnkTimeTo, txtTimeTo, ddlLabel.Items(5).Text)

            btnReset.Attributes.Add("OnClick", "ClearContent(); return false;")
            btnFilter.Attributes.Add("OnClick", "javascript:if (!CheckAll()) {alert('" & ddlLabel.Items(0).Text & "'); return false;} else{Filter();}")
            btnBack.Attributes.Add("OnClick", "javascript:Filter();")

            txtPriceOfFileFrom.Attributes.Add("onChange", "javascript:if (!CheckNumBer(this, '" & ddlLabel.Items(7).Text & "' ,0)) { this.value=''; this.focus();}")
            txtPriceOfFileTo.Attributes.Add("onChange", "javascript:if (!CheckNumBer(this, '" & ddlLabel.Items(7).Text & "' ,0)) { this.value=''; this.focus();}")
            txtSizeOfFileFrom.Attributes.Add("onChange", "javascript:if (!CheckNumBer(this, '" & ddlLabel.Items(6).Text & "' ,0)) {this.value=''; this.focus(); }")
            txtSizeOfFileTo.Attributes.Add("onChange", "javascript:if (!CheckNumBer(this, '" & ddlLabel.Items(6).Text & "' ,0)) { this.value=''; this.focus();}")
        End Sub

        ' btnFilter_Click event
        Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
            Dim tblTemp As DataTable
            Dim intRowCount As Integer = 0
            Dim intCount As Integer
            Dim strRequestIDs As String = ""

            objBERequestCollection.CustomerName = txtCustomerName.Text.Trim
            objBERequestCollection.NameOfFile = txtNameOfFile.Text.Trim
            If Not txtPriceOfFileFrom.Text = "" Then
                objBERequestCollection.PriceOfFileFrom = CDbl(txtPriceOfFileFrom.Text)
            End If
            If Not txtPriceOfFileTo.Text = "" Then
                objBERequestCollection.PriceOfFileTo = CDbl(txtPriceOfFileTo.Text)
            End If
            objBERequestCollection.SizeOfFileFrom = txtSizeOfFileFrom.Text.Trim
            objBERequestCollection.SizeOfFileTo = txtSizeOfFileTo.Text.Trim
            objBERequestCollection.TimeMode = ddlTimeMode.SelectedValue
            objBERequestCollection.TimeFrom = txtTimeFrom.Text.Trim
            objBERequestCollection.TimeTo = txtTimeTo.Text.Trim
            tblTemp = objBERequestCollection.Filter
            Call WriteErrorMssg(ddlLabel.Items(4).Text, objBERequestCollection.ErrorMsg, ddlLabel.Items(3).Text, objBERequestCollection.ErrorCode)
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                intRowCount = tblTemp.Rows.Count
                For intCount = 0 To intRowCount - 1
                    strRequestIDs = strRequestIDs & tblTemp.Rows(intCount).Item("RequestID") & ","
                Next
                Session("ERequestIDs") = Left(strRequestIDs, Len(strRequestIDs) - 1)
            End If

            If intRowCount > 0 Then
                Response.Redirect("WRequestList.aspx")
            Else
                Page.RegisterClientScriptBlock("NotFoundJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(1).Text & "');</script>")
            End If
        End Sub

        ' btnBack_Click event
        Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
            Response.Redirect("WRequestList.aspx")
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBERequestCollection Is Nothing Then
                    objBERequestCollection.Dispose(True)
                    objBERequestCollection = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace