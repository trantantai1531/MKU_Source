' Class: WStatCreatedDate
' Puspose: Show statistic by validdate
' Creator: Sondp
' CreatedDate: 21-1-2005
' Modification History:
'   - 02/05/2005 by Oanhtn: review
Imports eMicLibAdmin.BusinessRules.Common
Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WStatCreatedExpired
        Inherits clsWBase
        Private objBCommonBusiness As New clsBCommonBusiness
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
            'If Not IsPostBack Then
            '    txtYear.Text = Year(Now)
            'End If
        End Sub
        ' Method: Initialize
        Private Sub Initialize()
            ' Initialize objBCommonBusiness object
            objBCommonBusiness.DBServer = Session("DBServer")
            objBCommonBusiness.ConnectionString = Session("ConnectionString")
            objBCommonBusiness.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCommonBusiness.Initialize()
        End Sub
        ' Method: CheckFormPermission
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            If Not CheckPemission(52) Then
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub

        ' Method: BindJS
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJS", "<script language='javascript' src='../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJS", "<script language='javascript' src='js/WStatCreatedDate.js'></script>")

            'optEachYearExpired.Attributes.Add("OnClick", "document.forms[0].txtYear.focus();")
            'txtYear.Attributes.Add("OnChange", "if (!CheckYear(this, '" & ddlLabel.Items(3).Text & "')){this.focus();this.value=0;};")
            'txtYear.Attributes.Add("OnClick", "document.forms[0].optEachYearExpired.checked=true;")

            btnStatistic.Attributes.Add("OnClick", "return(CheckValidData('" & ddlLabel.Items(6).Text & "'));")
            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkFromDate, txtFromDate, ddlLabel.Items(5).Text)
            SetOnclickCalendar(lnkToDate, txtToDate, ddlLabel.Items(5).Text)

        End Sub

        ' Method: btnStatistic_Click
        Private Sub btnStatistic_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnStatistic.Click
            Dim strURL As String
            strURL = "WStatCreatedExpiredResult.aspx"
            Session("FacultyID") = CInt(ddlFaculty.SelectedValue)

            Session("DateFrom") = txtFromDate.Text
            Session("DateTo") = txtToDate.Text
            'If optEachYearExpired.Checked And txtYear.Text & "" <> "" Then
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