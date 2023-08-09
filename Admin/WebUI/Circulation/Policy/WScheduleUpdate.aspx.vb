Imports System.Threading
Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WScheduleUpdate
        Inherits clsWBase

        ' Declare variables
        Private objBSchedule As New clsBSchedule
        Private objBUserLocation As New clsBUserLocation

#Region " Web Form Designer Generated Code "
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label
        Protected WithEvents Label4 As System.Web.UI.WebControls.Label
        Protected WithEvents Label5 As System.Web.UI.WebControls.Label
        Protected WithEvents Label6 As System.Web.UI.WebControls.Label
        Protected WithEvents Label7 As System.Web.UI.WebControls.Label
        Protected WithEvents Label8 As System.Web.UI.WebControls.Label
        Protected WithEvents Label9 As System.Web.UI.WebControls.Label
        Protected WithEvents Label10 As System.Web.UI.WebControls.Label
        Protected WithEvents Label11 As System.Web.UI.WebControls.Label
        Protected WithEvents Label12 As System.Web.UI.WebControls.Label
        Protected WithEvents Label13 As System.Web.UI.WebControls.Label
        Protected WithEvents Label14 As System.Web.UI.WebControls.Label
        Protected WithEvents Label15 As System.Web.UI.WebControls.Label
        Protected WithEvents Label16 As System.Web.UI.WebControls.Label
        Protected WithEvents Label17 As System.Web.UI.WebControls.Label
        Protected WithEvents Label18 As System.Web.UI.WebControls.Label
        Protected WithEvents Label19 As System.Web.UI.WebControls.Label
        Protected WithEvents Label20 As System.Web.UI.WebControls.Label
        Protected WithEvents Label21 As System.Web.UI.WebControls.Label
        Protected WithEvents Label22 As System.Web.UI.WebControls.Label
        Protected WithEvents Label23 As System.Web.UI.WebControls.Label
        Protected WithEvents Label24 As System.Web.UI.WebControls.Label
        Protected WithEvents Label25 As System.Web.UI.WebControls.Label
        Protected WithEvents Label26 As System.Web.UI.WebControls.Label
        Protected WithEvents Label27 As System.Web.UI.WebControls.Label
        Protected WithEvents Label28 As System.Web.UI.WebControls.Label
        Protected WithEvents Label29 As System.Web.UI.WebControls.Label
        Protected WithEvents Label30 As System.Web.UI.WebControls.Label
        Protected WithEvents Label31 As System.Web.UI.WebControls.Label
        Protected WithEvents Label32 As System.Web.UI.WebControls.Label
        Protected WithEvents Label33 As System.Web.UI.WebControls.Label
        Protected WithEvents Label34 As System.Web.UI.WebControls.Label
        Protected WithEvents Label35 As System.Web.UI.WebControls.Label
        Protected WithEvents Label36 As System.Web.UI.WebControls.Label
        Protected WithEvents Label37 As System.Web.UI.WebControls.Label
        Protected WithEvents Label38 As System.Web.UI.WebControls.Label
        Protected WithEvents Label39 As System.Web.UI.WebControls.Label
        Protected WithEvents Label40 As System.Web.UI.WebControls.Label
        Protected WithEvents Label41 As System.Web.UI.WebControls.Label
        Protected WithEvents Label42 As System.Web.UI.WebControls.Label
        Protected WithEvents Label43 As System.Web.UI.WebControls.Label
        Protected WithEvents Label44 As System.Web.UI.WebControls.Label
        Protected WithEvents Label45 As System.Web.UI.WebControls.Label
        Protected WithEvents Label46 As System.Web.UI.WebControls.Label
        Protected WithEvents Label47 As System.Web.UI.WebControls.Label
        Protected WithEvents Label48 As System.Web.UI.WebControls.Label
        Protected WithEvents Label49 As System.Web.UI.WebControls.Label
        Protected WithEvents Label50 As System.Web.UI.WebControls.Label
        Protected WithEvents Label51 As System.Web.UI.WebControls.Label
        Protected WithEvents Label52 As System.Web.UI.WebControls.Label
        Protected WithEvents Label53 As System.Web.UI.WebControls.Label
        Protected WithEvents Label54 As System.Web.UI.WebControls.Label
        Protected WithEvents Label55 As System.Web.UI.WebControls.Label
        Protected WithEvents Label56 As System.Web.UI.WebControls.Label
        Protected WithEvents Label57 As System.Web.UI.WebControls.Label
        Protected WithEvents Label58 As System.Web.UI.WebControls.Label
        Protected WithEvents Label59 As System.Web.UI.WebControls.Label
        Protected WithEvents Label60 As System.Web.UI.WebControls.Label
        Protected WithEvents Label61 As System.Web.UI.WebControls.Label
        Protected WithEvents Label62 As System.Web.UI.WebControls.Label
        Protected WithEvents Label63 As System.Web.UI.WebControls.Label
        Protected WithEvents Label64 As System.Web.UI.WebControls.Label
        Protected WithEvents Label65 As System.Web.UI.WebControls.Label
        Protected WithEvents Label66 As System.Web.UI.WebControls.Label
        Protected WithEvents Label67 As System.Web.UI.WebControls.Label
        Protected WithEvents Label68 As System.Web.UI.WebControls.Label
        Protected WithEvents Label69 As System.Web.UI.WebControls.Label
        Protected WithEvents Label70 As System.Web.UI.WebControls.Label
        Protected WithEvents Label71 As System.Web.UI.WebControls.Label
        Protected WithEvents Label72 As System.Web.UI.WebControls.Label
        Protected WithEvents Label73 As System.Web.UI.WebControls.Label
        Protected WithEvents Label74 As System.Web.UI.WebControls.Label
        Protected WithEvents Label75 As System.Web.UI.WebControls.Label
        Protected WithEvents Label76 As System.Web.UI.WebControls.Label
        Protected WithEvents Label77 As System.Web.UI.WebControls.Label
        Protected WithEvents Label78 As System.Web.UI.WebControls.Label
        Protected WithEvents Label79 As System.Web.UI.WebControls.Label
        Protected WithEvents Label80 As System.Web.UI.WebControls.Label
        Protected WithEvents Label81 As System.Web.UI.WebControls.Label
        Protected WithEvents Label82 As System.Web.UI.WebControls.Label
        Protected WithEvents Label83 As System.Web.UI.WebControls.Label
        Protected WithEvents Label84 As System.Web.UI.WebControls.Label
        Protected WithEvents Label85 As System.Web.UI.WebControls.Label
        Protected WithEvents Label86 As System.Web.UI.WebControls.Label
        Protected WithEvents Label87 As System.Web.UI.WebControls.Label
        Protected WithEvents Label88 As System.Web.UI.WebControls.Label
        Protected WithEvents Label89 As System.Web.UI.WebControls.Label
        Protected WithEvents Label90 As System.Web.UI.WebControls.Label
        Protected WithEvents Label91 As System.Web.UI.WebControls.Label
        Protected WithEvents Label92 As System.Web.UI.WebControls.Label
        Protected WithEvents Label93 As System.Web.UI.WebControls.Label
        Protected WithEvents Label94 As System.Web.UI.WebControls.Label
        Protected WithEvents Label95 As System.Web.UI.WebControls.Label
        Protected WithEvents Label96 As System.Web.UI.WebControls.Label
        Protected WithEvents lblMon1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblMon2 As System.Web.UI.WebControls.Label
        Protected WithEvents lblMon3 As System.Web.UI.WebControls.Label
        Protected WithEvents lblMon4 As System.Web.UI.WebControls.Label
        Protected WithEvents lblMon5 As System.Web.UI.WebControls.Label
        Protected WithEvents lblMon6 As System.Web.UI.WebControls.Label
        Protected WithEvents lblMon7 As System.Web.UI.WebControls.Label
        Protected WithEvents lblMon8 As System.Web.UI.WebControls.Label
        Protected WithEvents lblMon9 As System.Web.UI.WebControls.Label
        Protected WithEvents lblMon10 As System.Web.UI.WebControls.Label
        Protected WithEvents lblMon11 As System.Web.UI.WebControls.Label
        Protected WithEvents lblMon12 As System.Web.UI.WebControls.Label
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
            Call CheckFormPermission()
            Call Initialize()
            If Not IsPostBack Then
                Call BindData()
                Call LoadLocation()
                Call BindCalendar()
                Call LoadLocationShedule()
            End If
            Call BindJS()
        End Sub
        ' Method: CheckFormPermission
        ' Purpose: Check permissions
        Private Sub CheckFormPermission()
            If Not CheckPemission(68) Then
                btnUpdate.Enabled = False
            End If
        End Sub
        ' Initialize method
        Private Sub Initialize()
            ' Init objBUserLocation object
            objBUserLocation.InterfaceLanguage = Session("InterfaceLanguage")
            objBUserLocation.ConnectionString = Session("ConnectionString")
            objBUserLocation.DBServer = Session("DBServer")
            objBUserLocation.UserID = Session("UserID")
            Call objBUserLocation.Initialize()

            ' Init objBSchedule object
            objBSchedule.InterfaceLanguage = Session("InterfaceLanguage")
            objBSchedule.ConnectionString = Session("ConnectionString")
            objBSchedule.DBServer = Session("DBServer")
            Call objBSchedule.Initialize()
        End Sub

        ' Method: BindJS
        ' Purpose: Include all need js functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("Common", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("Private", "<script language = 'javascript' src = '../Js/Policy/WWorkingUpdate.js'></script>")

            lnkNext.Attributes.Add("onclick", "JavaScript:if (document.forms[0].ddlYear.selectedIndex == 15) return false; ")
            lnkPrevious.Attributes.Add("onclick", "JavaScript:if (document.forms[0].ddlYear.selectedIndex == 0) return false; ")

            btnUpdate.Attributes.Add("OnClick", "if (document.forms[0].ddlLocation.options[document.forms[0].ddlLocation.options.selectedIndex].value == '') {alert('" & ddlLabel.Items(3).Text & "'); return false;}")
            btnReset.Attributes.Add("OnClick", "document.forms[0].reset(); return false;")
        End Sub

        ' Method: BindData
        Private Sub BindData()
            Dim tblTemp As DataTable
            Dim intCount As Integer

            ' Get locations
            tblTemp = objBUserLocation.GetUserLocations(2)
            If Not tblTemp Is Nothing Then
                tblTemp = InsertOneRow(tblTemp, ddlLabel.Items(2).Text)
            End If
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlLocation.DataSource = tblTemp
                ddlLocation.DataTextField = "LOCNAME"
                ddlLocation.DataValueField = "ID"
                ddlLocation.DataBind()
                ddlLocation.SelectedIndex = 0

                For intCount = Now.Year - 5 To Now.Year - 1
                    ddlYear.Items.Add(intCount)
                Next
                For intCount = Now.Year To Now.Year + 10
                    ddlYear.Items.Add(intCount)
                Next
                ddlYear.SelectedIndex = 5
            End If
        End Sub

        ' Method: LoadLocation
        Private Sub LoadLocation()
            Dim intLocationID As Integer = 0
            Dim intCount As Integer
            Dim tblUserLocation As DataTable

            If IsNumeric(ddlLocation.SelectedValue) Then
                intLocationID = ddlLocation.SelectedValue
            End If

            ' get user location
            tblUserLocation = objBUserLocation.GetUserLocations(2)
            If Not tblUserLocation Is Nothing AndAlso tblUserLocation.Rows.Count > 0 Then
                lstLocation.DataSource = tblUserLocation
                lstLocation.DataTextField = "LOCNAME"
                lstLocation.DataValueField = "ID"
                lstLocation.DataBind()
                For intCount = 0 To lstLocation.Items.Count - 1
                    If intLocationID = lstLocation.Items(intCount).Value Then
                        lstLocation.Items.RemoveAt(intCount)
                        Exit For
                    End If
                Next
            End If
        End Sub

        ' Method: LoadLocationShedule
        Private Sub LoadLocationShedule()
            Dim intLocationID As Integer = 0
            Dim intYear As Integer = ddlYear.SelectedItem.Text
            Dim dtbSchedule As New DataTable
            Dim ctlItem, ctl, ctlFind As Control
            Dim CheckBoxFind As CheckBox

            If IsNumeric(ddlLocation.SelectedValue) Then
                intLocationID = ddlLocation.SelectedValue
            End If

            ' Set default checked = false for all CheckBox
            For Each ctlItem In Page.Controls
                If TypeOf (ctlItem) Is System.Web.UI.HtmlControls.HtmlForm Then
                    For Each ctl In ctlItem.Controls
                        If TypeOf (ctl) Is WebControl Then
                            If ctl.GetType.ToString = "System.Web.UI.WebControls.CheckBox" Then
                                CheckBoxFind = CType(ctl, CheckBox)
                                CheckBoxFind.Checked = False
                            End If
                        End If
                    Next
                End If
            Next

            Dim dtDate As Date
            Dim intFirstWeekDay As Integer
            Dim dtOffday As Date
            Dim intCount, intMon, intDay, intWeekDay As Integer
            objBSchedule.LocationID = intLocationID
            dtbSchedule = objBSchedule.GetSchedule(False)
            If Not dtbSchedule Is Nothing AndAlso dtbSchedule.Rows.Count > 0 Then
                For intCount = 0 To dtbSchedule.Rows.Count - 1
                    dtOffday = dtbSchedule.Rows(intCount).Item("OffDay")
                    If Year(dtOffday) = intYear Then
                        intMon = Month(dtOffday)
                        intDay = Day(dtOffday)
                        Try
                            dtDate = "1/" & intMon & "/" & intYear
                        Catch ex As Exception
                            dtDate = intMon & "/1/" & intYear
                        End Try
                        intFirstWeekDay = Weekday(dtDate)
                        ' Set checked = true for CheckBox that is offday
                        ctlFind = ctlItem.FindControl("CHECKBOX" & CStr(intFirstWeekDay + intDay - 1 + ((intMon - 1) * 42)))
                        CheckBoxFind = CType(ctlFind, CheckBox)
                        CheckBoxFind.Checked = True
                    End If
                Next
                dtbSchedule = Nothing
            End If
        End Sub

        ' Method: BindCalendar
        Private Sub BindCalendar()
            Dim intYear As Integer = ddlYear.SelectedItem.Text
            Dim ctlItem, ctl, ctlFind As Control
            Dim CheckBoxFind As CheckBox

            ' Set default visible, checked = false for all CheckBox
            For Each ctlItem In Page.Controls
                If TypeOf (ctlItem) Is System.Web.UI.HtmlControls.HtmlForm Then
                    For Each ctl In ctlItem.Controls
                        If TypeOf (ctl) Is WebControl Then
                            If ctl.GetType.ToString = "System.Web.UI.WebControls.CheckBox" Then
                                CheckBoxFind = CType(ctl, CheckBox)
                                CheckBoxFind.Visible = False
                                CheckBoxFind.Checked = False
                            End If
                        End If
                    Next
                End If
            Next
            Dim dtDate As Date
            Dim intWeekDay, intFirstWeekDay As Integer
            Dim i, j As Integer
            For i = 1 To 12
                For j = 1 To GetDaysInMonth(i, intYear)
                    Try
                        dtDate = j & "/" & i & "/" & intYear
                    Catch ex As Exception
                        dtDate = i & "/" & j & "/" & intYear
                    End Try
                    intWeekDay = Weekday(dtDate)
                    If j = 1 Then
                        intFirstWeekDay = intWeekDay
                    End If
                    ' Set visible = true for CheckBox that is really day
                    ctlFind = ctlItem.FindControl("CHECKBOX" & CStr(intFirstWeekDay + j - 1 + ((i - 1) * 42)))
                    CheckBoxFind = CType(ctlFind, CheckBox)
                    CheckBoxFind.Visible = True
                    CheckBoxFind.Text = j
                    If intWeekDay = 1 Then
                        CheckBoxFind.ForeColor = Color.Red
                    ElseIf intWeekDay = 7 Then
                        CheckBoxFind.ForeColor = Color.Blue
                    End If
                Next
            Next
        End Sub

        ' Method: GetDaysInMonth
        Function GetDaysInMonth(ByVal intMonth As Integer, ByVal intYear As Integer)
            Select Case intMonth
                Case 1, 3, 5, 7, 8, 10, 12
                    GetDaysInMonth = 31
                Case 4, 6, 9, 11
                    GetDaysInMonth = 30
                Case 2
                    If IsDate("February 29, " & intYear) Then
                        GetDaysInMonth = 29
                    Else
                        GetDaysInMonth = 28
                    End If
            End Select
        End Function

        ' ddlYear_SelectedIndexChanged event
        Private Sub ddlYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlYear.SelectedIndexChanged
            Call BindCalendar()
            Call LoadLocationShedule()
        End Sub

        ' ddlLocation_SelectedIndexChanged event
        Private Sub ddlLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlLocation.SelectedIndexChanged
            Call LoadLocation()
            Call LoadLocationShedule()
        End Sub

        ' btnUpdate_Click event
        Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Dim intYear As Integer = ddlYear.SelectedItem.Text
            Dim ctlItem, ctlFind As Control
            Dim CheckBoxFind As CheckBox
            Dim dtDate As Date
            Dim intWeekDay, intFirstWeekDay As Integer
            Dim intLocationID As Integer = 0
            Dim i, j, intLstCount As Integer
            Dim ctl As Control

            For Each ctlItem In Page.Controls
            Next

            If IsNumeric(ddlLocation.SelectedValue) Then
                intLocationID = ddlLocation.SelectedValue
            End If

            objBSchedule.LocationID = intLocationID
            objBSchedule.OffYear = intYear
            objBSchedule.DeleteSchedule()

            For intLstCount = 0 To lstLocation.Items.Count - 1
                If lstLocation.Items(intLstCount).Selected Then
                    objBSchedule.LocationID = lstLocation.Items(intLstCount).Value
                    objBSchedule.OffYear = intYear
                    objBSchedule.DeleteSchedule()
                End If
            Next
            For i = 1 To 12
                For j = 1 To GetDaysInMonth(i, intYear)
                    Try
                        dtDate = j & "/" & i & "/" & intYear
                    Catch ex As Exception
                        dtDate = i & "/" & j & "/" & intYear
                    End Try
                    intWeekDay = Weekday(dtDate)
                    If j = 1 Then
                        intFirstWeekDay = intWeekDay
                    End If

                    ' Set visible = true for CheckBox that is really day
                    ctlFind = ctlItem.FindControl("CHECKBOX" & CStr(intFirstWeekDay + j - 1 + ((i - 1) * 42)))
                    CheckBoxFind = CType(ctlFind, CheckBox)
                    If CheckBoxFind.Checked Then
                        objBSchedule.LocationID = intLocationID
                        objBSchedule.OffDay = i & "/" & j & "/" & intYear
                        objBSchedule.UpdateSchedule()
                        For intLstCount = 0 To lstLocation.Items.Count - 1
                            If InStr("," & Request.Form("lstLocation") & ",", "," & lstLocation.Items(intLstCount).Value & ",") > 0 Then
                                objBSchedule.LocationID = lstLocation.Items(intLstCount).Value
                                objBSchedule.OffDay = i & "/" & j & "/" & intYear
                                objBSchedule.UpdateSchedule()
                            End If
                        Next
                    End If
                Next
            Next
        End Sub

        ' btnUpdate_Click event
        Private Sub lnkNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkNext.Click
            ddlYear.SelectedIndex = ddlYear.SelectedIndex + 1
            Call BindCalendar()
            Call LoadLocationShedule()
        End Sub

        ' lnkPrevious_Click event
        Private Sub lnkPrevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkPrevious.Click
            ddlYear.SelectedIndex = ddlYear.SelectedIndex - 1
            Call BindCalendar()
            Call LoadLocationShedule()
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBSchedule Is Nothing Then
                    objBSchedule.Dispose(True)
                    objBSchedule = Nothing
                End If
                If Not objBUserLocation Is Nothing Then
                    objBUserLocation.Dispose(True)
                    objBUserLocation = Nothing
                End If
            Finally
                MyBase.Dispose()
            End Try
        End Sub
    End Class
End Namespace