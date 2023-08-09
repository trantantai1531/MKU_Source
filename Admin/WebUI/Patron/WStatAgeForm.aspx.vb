' Class: WStatAgeResult
' Puspose: Show statistic by age
' Creator: Sondp
' CreatedDate: 21-1-2005
' Modification History:
'   - 02/05/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Patron

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WStatAgeForm
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents ddlAlert As System.Web.UI.WebControls.DropDownList


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBPatronCollection As New clsBPatronCollection

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
        End Sub

        ' Method: Initialize
        Private Sub Initialize()
            objBPatronCollection.DBServer = Session("DBServer")
            objBPatronCollection.ConnectionString = Session("ConnectionString")
            objBPatronCollection.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPatronCollection.initialize()
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            If Not CheckPemission(52) Then
                Me.btnStatistic.Enabled = False
            End If
        End Sub

        ' Method: BindJS
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJS", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJS", "<script language = 'javascript' src = 'js/WStatAgeForm.js'></script>")

            optAllAge.Attributes.Add("OnClick", "document.forms[0].hidAllAge.value='0';document.forms[0].txtFromAge.value=''; document.forms[0].txtToAge.value='';")
            optEachAge.Attributes.Add("OnClick", "document.forms[0].hidAllAge.value='1';document.forms[0].txtFromAge.focus();")

            txtFromAge.Attributes.Add("OnFocus", "document.forms[0].optEachAge.checked=1;document.forms[0].optAllAge.checked=0;document.forms[0].hidAllAge.value='1';")
            txtToAge.Attributes.Add("OnFocus", "document.forms[0].optEachAge.checked=1;document.forms[0].optAllAge.checked=0;document.forms[0].hidAllAge.value='1';")
            txtFromAge.Attributes.Add("OnChange", "if (!CheckAge(this, '" & ddlLabel.Items(3).Text & "')){this.value='';this.focus();return false;}")
            txtToAge.Attributes.Add("OnChange", "if (!CheckAge(this, '" & ddlLabel.Items(3).Text & "')){this.value='';this.focus();return false;}")

            btnBack.Attributes.Add("OnClick", "parent.Workform.location.href='WStatIndex.aspx'; return(false);")
            btnStatistic.Attributes.Add("OnClick", "return CheckAll('" & ddlLabel.Items(3).Text & "', '" & ddlLabel.Items(4).Text & "');")
        End Sub

        ' Event: btnStatistic_Click
        Private Sub btnStatistic_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnStatistic.Click
            Dim strURL As String
            strURL = "WStatAgeResult.aspx"
            If optAllAge.Checked Then
                strURL = strURL & "?allage=ok"
            Else
                If Trim(txtFromAge.Text) = "" Or Trim(txtToAge.Text) = "" And Not IsNumeric(txtFromAge.Text) And Not IsNumeric(txtToAge.Text) Then
                    strURL = strURL & "?allage=ok"
                Else
                    If IsNumeric(txtFromAge.Text) And IsNumeric(txtToAge.Text) Then
                        If CInt(txtToAge.Text) > 0 And CInt(txtFromAge.Text) > 0 Then
                            strURL = strURL & "?allage=nok&from=" & txtFromAge.Text & "&to=" & txtToAge.Text
                        Else
                            strURL = strURL & "?allage=ok"
                        End If
                    Else
                        strURL = strURL & "?allage=ok"
                    End If
                End If
            End If
            Response.Redirect(strURL)
        End Sub

        ' Event: Page_Unload
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Me.Dispose(True)
        End Sub

        ' Method: Dispose
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBPatronCollection Is Nothing Then
                    objBPatronCollection.Dispose(True)
                    objBPatronCollection = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace