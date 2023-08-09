Imports eMicLibAdmin.BusinessRules.Edeliv
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WStatTopCustomer
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
        Private objBRequestCollection As New clsBERequestCollection
        Private objBCommonChart As New clsBCommonChart

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPemission()
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call BindData()
                ' WriteLog
                Call WriteLog(76, lblTitle.Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
            End If
        End Sub

        ' CheckFormPemission method
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            If Not CheckPemission(163) Then
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/Statistic/WStatic.js'></script>")

            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkTimeFrom, txtTimeFrom, ddlLabel.Items(4).Text)
            SetOnclickCalendar(lnkTimeTo, txtTimeTo, ddlLabel.Items(4).Text)
            Dim strResetForm As String
            strResetForm = "document.forms[0].txtTimeFrom.value='';"
            strResetForm = strResetForm & "document.forms[0].txtTimeTo.value='';"
            strResetForm = strResetForm & "document.forms[0].ddlTopNum.options.selectedIndex=4;"
            strResetForm = strResetForm & "document.forms[0].ddlMinTurn.options.selectedIndex=5;return false;"
            btnCancel.Attributes.Add("OnClick", strResetForm)
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBCommonChart object
            objBCommonChart.ConnectionString = Session("ConnectionString")
            objBCommonChart.DBServer = Session("DBServer")
            objBCommonChart.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCommonChart.Initialize()

            ' Init objBRequestCollection object
            objBRequestCollection.ConnectionString = Session("ConnectionString")
            objBRequestCollection.DBServer = Session("DBServer")
            objBRequestCollection.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBRequestCollection.Initialize()
        End Sub

        ' BindData method
        ' Purpose: Bind the data for drawing statistic
        Private Sub BindData()
            Dim strTimeFrom As String = ""
            Dim strTimeTo As String = ""
            Dim intTopNum As Integer = 0
            Dim intMinTurn As Integer = 0

            strTimeFrom = Trim(txtTimeFrom.Text)
            strTimeTo = Trim(txtTimeTo.Text)
            intTopNum = ddlTopNum.SelectedValue
            intMinTurn = ddlMinTurn.SelectedValue

            Call DrawTopItemStat(strTimeFrom, strTimeTo, intTopNum, intMinTurn)
        End Sub

        ' DrawTopItemStat method
        ' Purpose: View the top Item statistic by time, top number and minimum of reservation time 
        Private Sub DrawTopItemStat(ByVal strTimeFrom As String, ByVal strTimeTo As String, ByVal intTopNum As Integer, ByVal intMinTurn As Long)
            Dim arrData As Object
            Dim arrLabel As Object
            Dim strImage As String
            Dim strVTitle As String
            Dim strHTitle1 As String
            Dim strHTitle2 As String
            Dim strOutput As String

            ' ***************** Get the top Item statistic **************
            strImage = Server.MapPath("..\..\Images\bground.gif")
            strVTitle = ddlLabel.Items(3).Text
            strHTitle1 = ddlLabel.Items(7).Text
            strHTitle2 = ddlLabel.Items(5).Text

            arrData = Nothing
            arrLabel = Nothing
            objBRequestCollection.TimeFrom = Trim(strTimeFrom)
            objBRequestCollection.TimeTo = Trim(strTimeTo)
            objBRequestCollection.TopNum = intTopNum
            objBRequestCollection.CreateTopCustomersStat(intMinTurn)
            ' Check Error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBRequestCollection.ErrorMsg, ddlLabel.Items(0).Text, objBRequestCollection.ErrorCode)

            arrData = objBRequestCollection.arrData
            arrLabel = objBRequestCollection.arrLabel
            image1.Visible = False
            image2.Visible = False
            If Not arrData Is Nothing AndAlso UBound(arrData) > -1 Then
                image1.Visible = True
                image2.Visible = True
                Session("chart1") = Nothing
                Session("chart2") = Nothing

                ' Bar chart
                Call objBCommonChart.MakebarchartLarge(arrData, arrLabel, strVTitle, strHTitle1, 1, strImage, "javascript:OpenWindow('WCustomerDetails.aspx")
                Session("chart1") = objBCommonChart.OutPutStream
                strOutput = objBCommonChart.OutMapImg
                strOutput = Replace(strOutput, "xLabel", "CustomerCode")
                strOutput = Replace(strOutput, "dataSet", "ds")
                strOutput = Replace(strOutput, "dataSetName", "dsn")
                strOutput = Replace(strOutput, """>", "','WCustomerDetails',700,500,50,50)" & """>")
                Response.Write("<MAP NAME=""map1"">" & strOutput & "</MAP>")
                ' Pie chart
                Call objBCommonChart.MakepiechartMiddle(arrData, arrLabel, strHTitle2, strImage)
                Session("chart2") = objBCommonChart.OutPutStream
            Else
                Page.RegisterClientScriptBlock("NotFoundJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(8).Text & "');</script>")
            End If
        End Sub

        ' Event: btnStatic_Click
        Private Sub btnStatic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStatic.Click
            Call BindData()
        End Sub

        ' Event: Page_UnLoad
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCommonChart Is Nothing Then
                    objBCommonChart.Dispose(True)
                    objBCommonChart = Nothing
                End If
                If Not objBRequestCollection Is Nothing Then
                    objBRequestCollection.Dispose(True)
                    objBRequestCollection = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
