' Name: WCalendar
' Purpose: Show calendar
' Creator: Oanhtn
' CreatedDate: 25/08/2004
' Modification History:

Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WCalendar
        Inherits clsWBase


#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Protected WithEvents lblSelectedDate As System.Web.UI.WebControls.Label

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = 'eMicLibCommon.js'></script>")

            If Not Page.IsPostBack Then
                Dim id As String = Request.QueryString("id")
                Dim postBack As String = Request.QueryString("postBack")

                ' Cast first day of the week from web.config file.  Set it to the calendar
                dgtCalendar.FirstDayOfWeek = CType(1, System.Web.UI.WebControls.FirstDayOfWeek)

                ' Select the Correct date for Calendar from query string
                ' If fails, pick the current date on Calendar
                Try
                    ' dgtCalendar.SelectedDate = CDate(selected)
                    dgtCalendar.VisibleDate = dgtCalendar.SelectedDate
                Catch
                    dgtCalendar.SelectedDate = DateTime.Today
                    dgtCalendar.VisibleDate = dgtCalendar.SelectedDate
                End Try

                ' Fills in correct values for the dropdown menus
                FillCalendarChoices()
                SelectCorrectValues()

                ' Add JScript to the OK button so that when the user clicks on it, the selected date
                ' is passed back to the calling page.
                btnCancel.Attributes.Add("onClick", "CloseWindow()")
            End If

            ' Set Current Date
            If InStr(lblDate.Text, "1/1/0001") > 0 Then
                lblDate.Text = CStr(DateTime.Today.Month) & "/" & CStr(DateTime.Today.Day) & "/" & CStr(DateTime.Today.Year)
                Dim x As Integer
                For x = 0 To 11
                    If x = CInt(DateTime.Today.Month) - 1 Then
                        ddlMonthSelect.SelectedIndex = x
                    End If
                Next x
                For x = 0 To CInt(DateTime.Today.Year) - 1992
                    If x = CInt(DateTime.Today.Year) - 1994 Then
                        ddlYearSelect.SelectedIndex = x
                    End If
                Next x
                ' Convertdate depend on 
                lblDate.Text = lblDate.Text
                Try
                    If lblDate.Text <> "" Then
                        lblDate.Text = Trim(Left(lblDate.Text, InStr(lblDate.Text, " ") - 1))
                    End If
                Catch ex As Exception

                End Try
                txtdatechosen.Value = lblDate.Text
            End If
        End Sub 'Page_Load


        '***************************************************************
        '
        ' FillCalendarChoices method is used to fill dropdowns with month and year values 
        ' 
        '***************************************************************
        Public Sub FillCalendarChoices()
            Dim thisdate As New DateTime(DateTime.Today.Year, 1, 1)
            ' Fills in month values
            Dim x As Integer
            For x = 0 To 11
                ' Loops through 12 months of the year and fills in each month value
                Dim li As New ListItem(thisdate.ToString("MMMM"), thisdate.Month.ToString())
                ddlMonthSelect.Items.Add(li)
                thisdate = thisdate.AddMonths(1)
            Next x

            ' Fills in year values and change y value to other years if necessary
            Dim y As Integer
            For y = 1994 To thisdate.Year + 2
                ddlYearSelect.Items.Add(y.ToString())
            Next y
        End Sub 'FillCalendarChoices

        '***************************************************************************
        '
        ' The SelectCorrectValues method is used to select the correct values in dropdowns 
        ' according to the selected date on Calendar
        '
        '***************************************************************************

        Public Sub SelectCorrectValues()
            Dim strTemp As String
            strTemp = dgtCalendar.SelectedDate.ToShortDateString()
            strTemp = strTemp
            If InStr(strTemp, " ") > 0 Then
                strTemp = Trim(Left(strTemp, InStr(strTemp, " ") - 1))
            End If
            If strTemp = "01/01/0001" Then
                strTemp = Day(Now) & "/" & Month(Now) & "/" & Year(Now)
            End If
            lblDate.Text = strTemp
            txtdatechosen.Value = strTemp
            ddlMonthSelect.SelectedIndex = ddlMonthSelect.Items.IndexOf(ddlMonthSelect.Items.FindByValue(dgtCalendar.SelectedDate.Month.ToString()))
            ddlYearSelect.SelectedIndex = ddlYearSelect.Items.IndexOf(ddlYearSelect.Items.FindByValue(dgtCalendar.SelectedDate.Year.ToString()))
        End Sub 'SelectCorrectValues

        '**************************************************************************
        '
        ' Cal_SelectionChanged event handler highlights the selected date on the Calendar and
        ' calls SelectCorrectValues() to synchronize to correct values on dropdowns.
        '
        '**************************************************************************

        Public Sub Cal_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            dgtCalendar.VisibleDate = dgtCalendar.SelectedDate
            SelectCorrectValues()
        End Sub 'Cal_SelectionChanged

        '**************************************************************************
        '
        ' MonthSelect_SelectedIndexChanged event handler selects the first day of the month when
        ' a month selection has being changed.
        '
        '**************************************************************************

        Public Sub MonthSelect_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            dgtCalendar.VisibleDate = New DateTime(Convert.ToInt32(ddlYearSelect.SelectedItem.Value), Convert.ToInt32(ddlMonthSelect.SelectedItem.Value), 1)
            dgtCalendar.SelectedDate = dgtCalendar.VisibleDate
            SelectCorrectValues()
        End Sub 'MonthSelect_SelectedIndexChanged

        '**************************************************************************
        '
        ' YearSelect_SelectedIndexChanged event handler selects a year value on the Calendar control
        ' when a year selection has being changed.
        '
        '**************************************************************************

        Public Sub YearSelect_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            dgtCalendar.VisibleDate = New DateTime(Convert.ToInt32(ddlYearSelect.SelectedItem.Value), Convert.ToInt32(ddlMonthSelect.SelectedItem.Value), 1)
            dgtCalendar.SelectedDate = dgtCalendar.VisibleDate
            SelectCorrectValues()
        End Sub 'YearSelect_SelectedIndexChanged

        Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
            ' Insert data 
            If txtdatechosen.Value <> "" Then
                Page.RegisterClientScriptBlock("AddDate", "<script language = 'javascript'>SetText('" & txtdatechosen.Value & "','" & Request.QueryString("id") & "');</script>")
            End If
        End Sub
    End Class
End Namespace