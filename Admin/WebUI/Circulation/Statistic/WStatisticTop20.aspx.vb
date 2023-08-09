' class  WStatisticPatronGroup
' Puspose: Static allow patron group
' Creator: Tuanhv
' CreatedDate: 12/09/2004
' Modification History:
'   + 17/04/2005 by Sondp: update and review

Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WStatisticTop20
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents RbtCopynumber As System.Web.UI.WebControls.RadioButton
        Protected WithEvents RbtItem As System.Web.UI.WebControls.RadioButton
        Protected WithEvents lblLevel As System.Web.UI.WebControls.Label
        Protected WithEvents rbtLibLevel As System.Web.UI.WebControls.RadioButton
        Protected WithEvents rbtLocLevel As System.Web.UI.WebControls.RadioButton
        Protected WithEvents lblLibs As System.Web.UI.WebControls.Label
        Protected WithEvents lstLib As System.Web.UI.WebControls.ListBox
        Protected WithEvents lblLevelStatic As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBCommonChart As New clsBCommonChart
        Private objBLoanTransaction As New clsBLoanTransaction

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call BindDataLocation()
            End If
            Call BindStatic()
        End Sub

        ' Initialize method
        Private Sub Initialize()
            'Init clsBLoanTransaction object
            objBLoanTransaction.ConnectionString = Session("ConnectionString")
            objBLoanTransaction.DBServer = Session("DBServer")
            objBLoanTransaction.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBLoanTransaction.Initialize()

            'Init objBCommonChart object
            objBCommonChart.ConnectionString = Session("ConnectionString")
            objBCommonChart.DBServer = Session("DBServer")
            objBCommonChart.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCommonChart.Initialize()
        End Sub

        ' BindJS method
        ' Purpose: Bind javascript
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("StatJs", "<script language = 'javascript' src = '../Js/Statistic/WStatistic.js'></script>")

            btnStatic.Attributes.Add("OnClick", "javascript:document.forms[0].action='WStatisticTop20.aspx?x=" & GenRandomNumber(10) & "'; document.forms[0].submit();")
        End Sub

        'BindDataLocation method
        'Purpose: Bind location 
        Sub BindDataLocation()
            Dim tblUserLocations As DataTable
            lstName.Items.Clear()
            objBLoanTransaction.Simple = 1
            lstName.DataSource = objBLoanTransaction.GetDisList
            lstName.DataTextField = "Name"
            lstName.DataValueField = "ID"
            lstName.DataBind()
            If lstName.Items.Count > 0 Then
                lstName.Items(0).Selected = True
            End If
        End Sub

        ' CheckFormPermission method
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            ' Statistic Top 20
            If Not CheckPemission(67) Then
                ' Write error
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub

        ' BindStatic method
        Private Sub BindStatic()
            Dim arrData As Object
            Dim arrLabel As Object
            Dim strImage As String
            Dim strVTitle As String
            Dim strHTitle As String
            Dim intID As Integer
            Dim intUserID As Integer

            Try
                strImage = "../Images/bground.gif"
                strVTitle = lblTotalLoan.Text
                strHTitle = lblGroupName.Text + lstName.SelectedItem.Text
                intID = CInt(lstName.SelectedValue)
                objBLoanTransaction.UserID = Session("UserID")
                ' Static Top 20
                objBLoanTransaction.CreateTop20Statistic(intID, 0)
                arrData = objBLoanTransaction.arrData
                arrLabel = objBLoanTransaction.arrLabel
                image1.Visible = False
                image2.Visible = False
                hidHave.Value = 0
                hidHave1.Value = 0
                lblNostatic.Visible = True
                lblNostatic1.Visible = True
                lblNostatic2.Visible = True
                lblNostatic3.Visible = True

                If Not arrData Is Nothing And Not arrLabel Is Nothing Then
                    If UBound(arrData) > -1 Then
                        image1.Visible = True
                        image2.Visible = True
                        Call objBCommonChart.Makebarchart(arrData, arrLabel, strVTitle, strHTitle, 45, strImage, "")
                        Session("chart1") = Nothing
                        Session("chart1") = objBCommonChart.OutPutStream

                        Call objBCommonChart.Makepiechart(arrData, arrLabel, strHTitle, strImage)
                        Session("chart2") = Nothing
                        Session("chart2") = objBCommonChart.OutPutStream
                        hidHave.Value = 1
                        lblNostatic.Visible = False
                        lblNostatic1.Visible = False
                    Else
                        Session("chart1") = Nothing
                        Session("chart2") = Nothing
                    End If
                Else
                    Session("chart1") = Nothing
                    Session("chart2") = Nothing
                End If
                objBLoanTransaction.CreateTop20Statistic(intID, 1)
                arrData = objBLoanTransaction.arrData
                arrLabel = objBLoanTransaction.arrLabel
                image3.Visible = False
                image4.Visible = False
                If Not arrData Is Nothing And Not arrLabel Is Nothing Then
                    If UBound(arrData) > -1 Then
                        image3.Visible = True
                        image4.Visible = True
                        Call objBCommonChart.Makebarchart(arrData, arrLabel, strVTitle, strHTitle, 45, strImage, "")
                        Session("chart3") = Nothing
                        Session("chart3") = objBCommonChart.OutPutStream
                        Call objBCommonChart.Makepiechart(arrData, arrLabel, strHTitle, strImage)
                        Session("chart4") = Nothing
                        Session("chart4") = objBCommonChart.OutPutStream
                        hidHave1.Value = 1
                        lblNostatic2.Visible = False
                        lblNostatic3.Visible = False
                    Else
                        Session("chart3") = Nothing
                        Session("chart4") = Nothing
                    End If
                Else
                    Session("chart3") = Nothing
                    Session("chart4") = Nothing
                End If
            Catch
            End Try
        End Sub

        ' Page_Unload event
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
                If Not objBLoanTransaction Is Nothing Then
                    objBLoanTransaction.Dispose(True)
                    objBLoanTransaction = Nothing
                End If
            Finally
                MyBase.Dispose()
            End Try
        End Sub

        Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
            Try
                Dim strTitle As String = lblTitle.Text
                Dim intID As Integer = CInt(lstName.SelectedValue)
                objBLoanTransaction.UserID = Session("UserID")
                ' Static Top 20
                objBLoanTransaction.CreateTop20Statistic(intID, 0)

                Dim sBuilder1 As StringBuilder = clsBExportHelper.GenToExcel(objBLoanTransaction.arrLabel, objBLoanTransaction.arrData, lblTitle.Text & " : " & lstName.SelectedItem.Text & " - " & lblStringBuilder1.Text)

                objBLoanTransaction.CreateTop20Statistic(intID, 1)

                Dim sBuilder2 As StringBuilder = clsBExportHelper.GenToExcel(objBLoanTransaction.arrLabel, objBLoanTransaction.arrData, lblTitle.Text & " : " & lstName.SelectedItem.Text & " - " & lblStringBuilder2.Text)

                clsExport.StringBuilderToExcel(sBuilder1.Append("<br/>" & sBuilder2.ToString()))
            Catch ex As Exception

            End Try
        End Sub
    End Class
End Namespace
