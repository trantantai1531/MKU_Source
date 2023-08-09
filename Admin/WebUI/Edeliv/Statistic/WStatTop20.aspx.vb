Imports eMicLibAdmin.BusinessRules.Edeliv
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WStatTop20
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
        Private objBCDBS As New clsBCommonDBSystem
        Private objBRequestCollection As New clsBERequestCollection
        Private objBCommonChart As New clsBCommonChart

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPemission()
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call BindDropDownList()
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
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/Statistic/WStatic.js'></script>")
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBCommonChart object
            objBCommonChart.ConnectionString = Session("ConnectionString")
            objBCommonChart.DBServer = Session("DBServer")
            objBCommonChart.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonChart.Initialize()

            ' Init objBRequestCollection object
            objBRequestCollection.ConnectionString = Session("ConnectionString")
            objBRequestCollection.DBServer = Session("DBServer")
            objBRequestCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBRequestCollection.Initialize()

            Table2.Visible = False
            Table3.Visible = False

        End Sub

        ' BindDropDownList method
        ' Purpose: List the property of Item
        Private Sub BindDropDownList()
            Dim tblTemp As DataTable
            tblTemp = objBRequestCollection.GetCatDicList2Field
            Call WriteErrorMssg(ddlLabel.Items(4).Text, objBRequestCollection.ErrorMsg, ddlLabel.Items(3).Text, objBRequestCollection.ErrorCode)

            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    tblTemp = InsertOneRow(objBRequestCollection.GetCatDicList2Field, ddlLabel.Items(1).Text)
                    Call WriteErrorMssg(ddlLabel.Items(4).Text, ErrorMsg, ddlLabel.Items(3).Text, ErrorCode)
                    ddlPropertyType.DataSource = tblTemp
                    ddlPropertyType.DataTextField = "Name"
                    ddlPropertyType.DataValueField = "ID"
                    ddlPropertyType.SelectedIndex = 0
                    ddlPropertyType.DataBind()
                End If
            End If
        End Sub

        ' BindData method
        ' Purpose: Get data and display the top 20 statistic
        Private Sub BindData()
            ' Declare variables
            Dim intPropertyID As Integer = 0
            Dim strPropertyName As String = ""

            intPropertyID = CInt(ddlPropertyType.SelectedValue)
            strPropertyName = ddlPropertyType.SelectedItem.Text

            ' Draw the data
            If intPropertyID <> 0 Then
                DrawTop20Stat(intPropertyID, strPropertyName)
                ' WriteLog
                Call WriteLog(76, lblHeader.Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
            End If
        End Sub

        ' DrawTopItemStat method
        ' Purpose: View the top 20 statistic by property ID
        Private Sub DrawTop20Stat(ByVal intPropertyID As Long, ByVal strPropertyName As String)
            Dim arrData As Object
            Dim arrLabel As Object
            Dim strImage As String
            Dim strVTitle As String
            Dim strHTitle1 As String
            Dim strHTitle2 As String

            ' ***************** Get the top Item statistic **************
            strImage = Server.MapPath("..\..\Images\bground.gif")
            strVTitle = ddlLabel.Items(0).Text
            strHTitle1 = lblPropertier.Text & " " & strPropertyName
            strHTitle2 = ddlLabel.Items(0).Text & " " & strPropertyName

            arrData = Nothing
            arrLabel = Nothing
            objBRequestCollection.CreateTop20Stat(intPropertyID)
            Call WriteErrorMssg(ddlLabel.Items(4).Text, objBRequestCollection.ErrorMsg, ddlLabel.Items(3).Text, objBRequestCollection.ErrorCode)

            arrData = objBRequestCollection.arrData
            arrLabel = objBRequestCollection.arrLabel

            If Not arrData Is Nothing Then
                If UBound(arrData) > -1 Then
                    Try
                        Call objBCommonChart.MakebarchartLarge(arrData, arrLabel, strVTitle, strHTitle1, 15, strImage, "", "")
                        Call WriteErrorMssg(ddlLabel.Items(4).Text, objBCommonChart.ErrorMsg, ddlLabel.Items(3).Text, objBCommonChart.ErrorCode)

                        Session("chart1") = Nothing
                        Session("chart1") = objBCommonChart.OutPutStream

                        Dim strOutput As String
                        strOutput = objBCommonChart.OutMapImg
                        strOutput = Replace(strOutput, "xLabel", "")

                        Response.Write("<MAP NAME=""map1"">" & strOutput & "</MAP>")

                        Call objBCommonChart.MakepiechartMiddle(arrData, arrLabel, strHTitle2, strImage)
                        Call WriteErrorMssg(ddlLabel.Items(4).Text, objBCommonChart.ErrorMsg, ddlLabel.Items(3).Text, objBCommonChart.ErrorCode)
                        Session("chart2") = Nothing
                        Session("chart2") = objBCommonChart.OutPutStream
                    Catch
                    End Try
                Else
                    Session("chart1") = Nothing
                    Session("chart2") = Nothing

                End If
            Else
                Session("chart1") = Nothing
                Session("chart2") = Nothing
            End If

        End Sub

        ' btnStatistic_Click event
        ' Purpose: Bind the data
        Private Sub btnStatistic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStatistic.Click
            If ddlPropertyType.SelectedIndex <> 0 Then
                Call BindData()
                If Not objBRequestCollection.arrData Is Nothing Then
                    Table2.Visible = True
                    Table3.Visible = False
                Else
                    Table2.Visible = False
                    Table3.Visible = True
                End If
            Else
                Table3.Visible = False
                Table2.Visible = False
            End If
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
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
