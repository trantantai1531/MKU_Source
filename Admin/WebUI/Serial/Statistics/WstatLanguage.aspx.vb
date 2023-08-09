' Class: WstatLanguage
' Puspose: create statistic by language
' Creator: Tuanhv
' CreatedDate: 05/10/2004
' Modification history:
'   Date: 20/04/2005
'       Modify by: Tuanhv
'           Works: View code & Update

Imports eMicLibAdmin.BusinessRules.Serial
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WstatLanguage
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblHTitle As System.Web.UI.WebControls.Label
        Protected WithEvents lblVTitle As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBPC As New clsBPeriodicalCollection
        Private objBCC As New clsBCommonChart


        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindScript()
            'Statistic allow language
            Call EventStatic()
        End Sub

        ' CheckFormPermission method
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            ' Statistic Year
            If Not CheckPemission(98) Then
                ' Write error
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init objBPC object
            objBPC.InterfaceLanguage = Session("InterfaceLanguage")
            objBPC.DBServer = Session("DBServer")
            objBPC.ConnectionString = Session("ConnectionString")
            objBPC.Initialize()

            ' Init objBCC object
            objBCC.Initialize()
        End Sub

        Sub EventStatic()
            'Delacre variable using in sub
            Dim arrData As Object
            Dim arrLabel As Object
            Dim strImage As String
            Dim strVTitle As String
            Dim strHTitle As String
            Try
                strImage = Server.MapPath("../Images/bground.gif")
                strVTitle = ddlLabel.Items(4).Text
                strHTitle = ddlLabel.Items(3).Text

                ' Static on language
                objBPC.LibID = clsSession.GlbSite
                Call objBPC.StatByLanguage()
                ' Write error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPC.ErrorMsg, ddlLabel.Items(1).Text, objBPC.ErrorCode)

                arrData = objBPC.arrData
                arrLabel = objBPC.arrLabel
                anh1.Visible = False
                anh2.Visible = False
                lblNostatic.Visible = True
                lblNostatic1.Visible = True
                If Not arrData Is Nothing Then
                    If UBound(arrData) > -1 Then
                        anh1.Visible = True
                        anh2.Visible = True
                        Call objBCC.Makebarchart(arrData, arrLabel, strVTitle, strHTitle, 45, strImage, "javascript:OpenWindow('WReportDetailInfor.aspx")
                        ' Write error
                        Call WriteErrorMssg(ddlLabel.Items(0).Text, objBCC.ErrorMsg, ddlLabel.Items(1).Text, objBCC.ErrorCode)

                        Session("chart1") = Nothing
                        Session("chart1") = objBCC.OutPutStream
                        Dim strOutput As String = ""
                        strOutput = objBCC.OutMapImg
                        strOutput = Replace(strOutput, "xLabel", "Language")
                        strOutput = Replace(strOutput, "dataSet", "ds")
                        strOutput = Replace(strOutput, "dataSetName", "dsn")
                        Dim arrAuput() As String
                        strOutput = Replace(strOutput, """>", "','ReportDetailInfor',600,400,50,50)" & """>")
                        Response.Write("<MAP NAME=""map1"">" & strOutput & "</MAP>")
                        Call objBCC.Makepiechart(arrData, arrLabel, strHTitle, strImage)
                        ' Write error
                        Call WriteErrorMssg(ddlLabel.Items(0).Text, objBCC.ErrorMsg, ddlLabel.Items(1).Text, objBCC.ErrorCode)

                        Session("chart2") = Nothing
                        Session("chart2") = objBCC.OutPutStream
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
            Catch
            End Try
        End Sub

        ' Bindjavascript
        Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("StatJs", "<script language = 'javascript' src = '../Js/Statistics/WStatistic.js'></script>")
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBPC Is Nothing Then
                    objBPC.Dispose(True)
                    objBPC = Nothing
                End If
                If Not objBCC Is Nothing Then
                    objBCC.Dispose(True)
                    objBCC = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace