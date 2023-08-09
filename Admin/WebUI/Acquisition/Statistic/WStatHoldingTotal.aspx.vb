Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.WebUI.Common
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.BusinessRules.Common
Imports Service.Excel

Namespace eMicLibAdmin.WebUI.Acquisition

    Partial Class WStatHoldingTotal
        Inherits System.Web.UI.Page

        Private objBHolding As New clsBHolding
        Private objBCDBS As New clsBCommonDBSystem

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialze()
            Call BindJS()
            If Not Page.IsPostBack Then
                txtDateFrom.Text = String.Format("{0:dd/MM/yyyy}", Date.Now)
                txtDateTo.Text = String.Format("{0:dd/MM/yyyy}", Date.Now)
            End If
        End Sub
        Public Function CheckPemission(ByVal intPemission As Integer) As Boolean
            CheckPemission = False
            If clsSession.GlbUser.ToLower() = "Admin".ToLower() Then
                CheckPemission = True
            Else
                If clsSession.ModuleID = 1 And Session("CatModule") = 0 Then
                    Return False
                ElseIf clsSession.ModuleID = 2 And Session("PatModule") = 0 Then
                    Return False
                ElseIf clsSession.ModuleID = 3 And Session("CirModule") = 0 Then
                    Return False
                ElseIf clsSession.ModuleID = 4 And Session("AcqModule") = 0 Then
                    Return False
                ElseIf clsSession.ModuleID = 5 And Session("SerModule") = 0 Then
                    Return False
                ElseIf clsSession.ModuleID = 6 And Session("AdmModule") = 0 Then
                    Return False
                ElseIf clsSession.ModuleID = 8 And Session("ILLModule") = 0 Then
                    Return False
                ElseIf clsSession.ModuleID = 9 And Session("DELModule") = 0 Then
                    Return False
                ElseIf Not Session("UserRights") Is Nothing Then
                    If InStr("," & Session("UserRights"), "," & intPemission & ",") > 0 Then
                        CheckPemission = True
                    End If
                End If
            End If
        End Function

        Public Overloads Sub WriteErrorMssg(ByVal strErrorMsg As String)
            Response.Write("<CENTER><H2><FONT COLOR=""RED"">" & strErrorMsg & "</FONT></H2></CENTER>")
            Response.End()
        End Sub
        Private Sub RegisterCalendar(Optional ByVal strOutPath As String = "..")
            'strOutCalendarPath = strOutPath
            If clsSession.GlbLanguage = "" Or clsSession.GlbLanguage Is Nothing Then
                Page.RegisterClientScriptBlock("SetCalendarLang", "<script language='javascript'>var language = 'vie';var imgDir='" & strOutPath & "/Common/Calendar/'</script>")
            Else
                Page.RegisterClientScriptBlock("SetCalendarLang", "<script language='javascript'>var language = '" & clsSession.GlbLanguage & "';var imgDir='" & strOutPath & "/Common/Calendar/'</script>")
            End If
            Page.RegisterClientScriptBlock("ShowCalendar", "<script language='javascript' src='" & strOutPath & "/Common/Calendar/PopCalendar1.js'></script>")
        End Sub
        Private Sub SetOnclickCalendar(ByRef lnkCalendarTmp As HyperLink, ByRef txtDateTmp As TextBox, ByVal strMsg As String)
            lnkCalendarTmp.NavigateUrl = "#"
            lnkCalendarTmp.Attributes.Add("onClick", "popUpCalendar(this, document.forms[0]." & txtDateTmp.ID & ", '" & Session("DateFormat") & "',26)")
            txtDateTmp.Attributes.Add("OnChange", "if (!CheckDate(this, '" & Session("DateFormat") & "', '" & strMsg & " (" & Session("DateFormat") & ")')) {this.value='';this.focus();return false;}")
            txtDateTmp.Attributes.Add("onkeypress", "if (window.event.keyCode == 13) {if (!CheckDate(this, '" & Session("DateFormat") & "', '" & strMsg & " (" & Session("DateFormat") & ")')) {this.value='';this.focus();return false;}}")
            txtDateTmp.ToolTip = Session("DateFormat")
        End Sub
        Private Sub CheckFormPermission()
            If Not CheckPemission(67) Then
                Call WriteErrorMssg(ddlLabelValue.Items(2).Text)
            End If
        End Sub

        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("StatJs", "<script language = 'javascript' src = '../../Circulation/Js/Statistic/WStatistic.js'></script>")


            Me.RegisterCalendar("../..")

            SetOnclickCalendar(lnkDateFrom, txtDateFrom, ddlLabelValue.Items(4).Text)
            SetOnclickCalendar(lnkDateTo, txtDateTo, ddlLabelValue.Items(4).Text)

            ddlTimes.Attributes.Add("onChange", "change(this);")
        End Sub


        Private Sub Initialze()
            objBHolding.InterfaceLanguage = Session("InterfaceLanguage")
            objBHolding.DBServer = Session("DBServer")
            objBHolding.ConnectionString = Session("ConnectionString")
            Call objBHolding.Initialize()
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            Call objBCDBS.Initialize()
        End Sub

        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBHolding Is Nothing Then
                    objBHolding.Dispose(True)
                    objBHolding = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
            Dim tblResult As New DataTable
            Dim tblDate As DataTable
            Dim tblLocationName As DataTable
            Dim strDateFrom As String = txtDateFrom.Text
            Dim strDateTo As String = txtDateTo.Text

            If ddlTimes.SelectedValue = "-1" Then
                tblResult = objBHolding.GetHoldingLocationNameAndTotalHoldingInDate(strDateFrom, strDateTo)
            Else
                If ddlTimes.SelectedValue = "0" Then
                    tblResult = objBHolding.GetHoldingLocationNameAndTotalHoldingInDate("", "")
                Else
                    Dim countDate As Integer = CType(ddlTimes.SelectedValue, Integer)
                    strDateFrom = String.Format("{0:dd/MM/yyyy}", Date.Now.AddDays(countDate * (-1)))
                    strDateTo = String.Format("{0:dd/MM/yyyy}", Date.Now)
                    tblResult = objBHolding.GetHoldingLocationNameAndTotalHoldingInDate(strDateFrom, strDateTo)
                End If
            End If

            If (Not IsNothing(tblResult)) Then

                If ddlTimes.SelectedValue = "-1" Then
                    tblDate = objBHolding.GetHoldingDate(strDateFrom, strDateTo)
                Else
                    If ddlTimes.SelectedValue = "0" Then
                        tblDate = objBHolding.GetHoldingDate("", "")
                    Else
                        Dim countDate As Integer = CType(ddlTimes.SelectedValue, Integer)
                        strDateFrom = String.Format("{0:dd/MM/yyyy}", Date.Now.AddDays(countDate * (-1)))
                        strDateTo = String.Format("{0:dd/MM/yyyy}", Date.Now)
                        tblDate = objBHolding.GetHoldingDate(strDateFrom, strDateTo)
                    End If
                End If

                Dim arrRowName As String()
                ReDim arrRowName(tblDate.Rows.Count - 1)
                For i As Integer = 0 To tblDate.Rows.Count - 1
                    arrRowName(i) = tblDate.Rows(i).Item("HoldingDate").ToString()
                Next
                tblLocationName = objBHolding.GetHoldingLocationName("", "")
                Dim arrColumnName As String()
                ReDim arrColumnName(tblLocationName.Rows.Count - 1)
                For i As Integer = 0 To tblLocationName.Rows.Count - 1
                    arrColumnName(i) = tblLocationName.Rows(i).Item("LocationName").ToString()
                Next

                Dim sBuilder As StringBuilder = clsBExportHelper.GenToExcel(arrColumnName, arrRowName, tblResult, "LocationName", "HoldingDate", "CountHolding", "CountItem", lblTitle.Text & "<br/>" & strDateFrom & " - " & strDateTo, "Ngày / Kho", True, "Tổng")

                clsExport.StringBuilderToExcel(sBuilder)
            End If

        End Sub
    End Class
End Namespace
