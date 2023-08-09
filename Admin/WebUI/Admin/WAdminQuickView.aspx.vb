Imports eMicLibAdmin.BusinessRules.Admin
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Admin
    Partial Class WAdminQuickView
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

        Dim objBCommonChart As New clsBCommonChart
        Dim objBLog As New clsBLog
        Dim objBEventGroup As New clsBEventGroup
        Dim objBUser As New clsBUser
        Dim objBPara As New clsBParameter

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call CreateStatistic()
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            Response.Expires = 0

            ' Init objBCommonChart object
            objBCommonChart.ConnectionString = Session("ConnectionString")
            objBCommonChart.DBServer = Session("DBServer")
            objBCommonChart.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCommonChart.Initialize()

            ' Init objBLog object
            objBLog.ConnectionString = Session("ConnectionString")
            objBLog.DBServer = Session("DBServer")
            objBLog.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBLog.Initialize()

            ' Init objBEventGroup object
            objBEventGroup.ConnectionString = Session("ConnectionString")
            objBEventGroup.DBServer = Session("DBServer")
            objBEventGroup.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBEventGroup.Initialize()

            ' Init objBUser object
            objBUser.ConnectionString = Session("ConnectionString")
            objBUser.DBServer = Session("DBServer")
            objBUser.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBUser.Initialize()


            ' Init objBPara object
            objBPara.ConnectionString = Session("ConnectionString")
            objBPara.DBServer = Session("DBServer")
            objBPara.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPara.Initialize()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = 'Js/WMainMenu.js'></script>")


            lnkDatabase.Attributes.Add("Onclick", "OpenDatabase();")
            lnkLanguage.Attributes.Add("Onclick", "OpenLangMan();")
            lnkParametter.Attributes.Add("Onclick", "OpenParametter();")
            lnkSystemLog.Attributes.Add("Onclick", "OpenLog();")
            lnkUser.Attributes.Add("Onclick", "OpenUser();")
            lnkChangePass.Attributes.Add("Onclick", "ChangePass();")
            lnkPerm.Attributes.Add("Onclick", "OpenPerm();")
        End Sub

        ' CreateStatistic method
        ' Purpose: show statistic
        Private Sub CreateStatistic()
            Dim arrLabel As Object
            Dim arrData As Object
            Dim strImage As String = Server.MapPath("../Images/bground.gif")
            Dim strVTitle As String = ""
            Dim strHTitle As String = ""
            Dim intYear, intMonth, intDay, inti As Integer

            intYear = Year(Now)
            intMonth = Month(Now)
            intDay = Day(Now)
            Call objBLog.StatQuickView(intDay, intMonth, intYear, arrLabel, arrData)
            anh1.Visible = False
            If Not arrData(0) = "-1" Then
                hidControl.Value = 1
                anh1.Visible = True
                Call objBCommonChart.Makebarchart(arrData, arrLabel, strVTitle, strHTitle, 45, strImage, "WAdminQuickView.aspx", "", 1)
                Session("chart1") = Nothing
                Session("chart1") = objBCommonChart.OutPutStream
            End If

            lblUserCount.Text &= Space(1) & "<b>" & FormatNumber(objBUser.GetUserCount.Rows(0).Item(0), 0) & "</b>"
            ' Get database size
            Dim tblData As DataTable
            Dim tblRow As New TableRow

            tblData = objBPara.GetDatabaseSize
            If Not tblData Is Nothing AndAlso tblData.Rows.Count > 0 Then
                If Not objBPara.DBServer = "ORACLE" Then
                    Dim dvData As DataView
                    dvData = New DataView
                    dvData.Table = tblData
                    'Data Source=192.168.50.199;Initial Catalog=libol601m;UID=sa;PWD=sa;
                    Dim strConntemp As String = Session("ConnectionString")
                    strConntemp = strConntemp.Substring(InStr(strConntemp, ";"))
                    strConntemp = strConntemp.Substring(0, InStr(strConntemp, ";") - 1)
                    strConntemp = strConntemp.Substring(InStr(strConntemp, "="))
                    dvData.RowFilter = "DATABASE_NAME = '" & strConntemp & "'"

                    If dvData.Count > 0 Then
                        lblDataSize.Text &= Space(1) & "<b>" & FormatNumber(CDbl(dvData.Item(0).Row("DATABASE_SIZE")) / 1024, 0) & " MB" & "</b>"
                    End If
                Else
                    lblDataSize.Text &= Space(1) & "<b>" & FormatNumber(tblData.Rows(0).Item("TotalSize"), 0) & " MB" & "</b>"
                End If
            End If

            lblOnlineUsers.Text &= Space(1) & "<b>" & FormatNumber(Application("UserCount"), 0) & "</b>"
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBLog Is Nothing Then
                    objBLog.Dispose(True)
                    objBLog = Nothing
                End If
                If Not objBCommonChart Is Nothing Then
                    objBCommonChart.Dispose(True)
                    objBCommonChart = Nothing
                End If
                If Not objBEventGroup Is Nothing Then
                    objBEventGroup.Dispose(True)
                    objBEventGroup = Nothing
                End If
                If Not objBUser Is Nothing Then
                    objBUser.Dispose(True)
                    objBUser = Nothing
                End If
                If Not objBPara Is Nothing Then
                    objBPara.Dispose(True)
                    objBPara = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
