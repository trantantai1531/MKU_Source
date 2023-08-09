' Class: WStatExpiredDate
' Puspose: Show statistic by expireddate
' Creator: Sondp
' CreatedDate: 21-1-2005
' Modification History:
'   - 02/05/2005 by Oanhtn: review
Imports eMicLibAdmin.BusinessRules.Common
Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WStatExpiredDate
        Inherits clsWBase
        Private objBCommonBusiness As New clsBCommonBusiness
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblYearAlert As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            '' Bind Falculty ddl
            If Not IsPostBack Then
                Dim StrSql = "select * from Cir_tblDicFaculty"
                Dim tblFaculty = objBCommonBusiness.ExcuteQuery(StrSql)
                If Not tblFaculty Is Nothing AndAlso tblFaculty.Rows.Count > 0 Then
                    ddlFaculty.DataSource = InsertOneRow(tblFaculty, ddlLabel.Items(4).Text)
                    ddlFaculty.DataTextField = "Faculty"
                    ddlFaculty.DataValueField = "ID"
                    ddlFaculty.DataBind()
                End If
            End If
            'If Not Page.IsPostBack Then
            '    txtYear.Text = Year(Now)
            'End If
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            If Not CheckPemission(52) Then
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub
        ' Method: Initialize
        Private Sub Initialize()
            ' Initialize objBCommonBusiness object
            objBCommonBusiness.DBServer = Session("DBServer")
            objBCommonBusiness.ConnectionString = Session("ConnectionString")
            objBCommonBusiness.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCommonBusiness.Initialize()
        End Sub
        ' Method: BindJS
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJS", "<script language='javascript' src='../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelJS", "<script language='javascript' src='js/WStatExpiredDate.js'></script>")

            btnStatistic.Attributes.Add("OnClick", "return(CheckValidData('" & ddlLabel.Items(6).Text & "'));")
            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkFromDate, txtFromDate, ddlLabel.Items(5).Text)
            SetOnclickCalendar(lnkToDate, txtToDate, ddlLabel.Items(5).Text)
            'txtYear.Attributes.Add("OnChange", "if (parseFloat(this.value) < 1754) {alert('" & ddlLabel.Items(3).Text & "'); return false;} else {return CheckNumBer(this, '" & ddlLabel.Items(3).Text & "');}")
            'txtYear.Attributes.Add("OnClick", "document.forms[0].optEachYearExpired.checked=true;")
            'optEachYearExpired.Attributes.Add("OnClick", "document.forms[0].txtYear.focus();")

            'btnStatistic.Attributes.Add("OnClick", "return(CheckValidData('" & ddlLabel.Items(3).Text & "'));")
        End Sub

        ' Method: btnStatistic_Click
        Private Sub btnStatistic_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnStatistic.Click
            Dim strURL As String
            strURL = "WStatExpiredDateResult.aspx"
            Session("FacultyID") = CInt(ddlFaculty.SelectedValue)
            Session("DateExpiredFrom") = txtFromDate.Text
            Session("DateExpiredTo") = txtToDate.Text
            'If optEachYearExpired.Checked Then
            '    If IsNumeric(txtYear.Text) Then
            '        strURL = strURL & "?Year=" & txtYear.Text
            '    Else
            '        strURL = strURL & "?Year=0"
            '    End If
            'Else
            '    strURL = strURL & "?Year=0"
            'End If
            Response.Redirect(strURL)
        End Sub
    End Class
End Namespace