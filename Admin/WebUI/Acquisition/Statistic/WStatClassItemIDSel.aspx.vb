' Class: WStatClassItemIDSel
' Puspose: Create statistic
' Creator: Sondp
' CreatedDate: 01/04/2005
' Modification History:
'   - 13/04/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WStatClassItemIDSel
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents StatisticAcqDAP As System.Web.UI.HtmlControls.HtmlTable


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBCB As New clsBCommonBusiness
        Private objBCDBS As New clsBCommonDBSystem

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: init all objects
        Private Sub Initialize()
            ' Initialize objBCB object
            objBCB.InterfaceLanguage = Session("InterfaceLanguage")
            objBCB.DBServer = Session("DBServer")
            objBCB.ConnectionString = Session("ConnectionString")
            Call objBCB.Initialize()

            ' Initialize objBCDBS object
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            Call objBCDBS.Initialize()
        End Sub

        ' Method: BindScript
        ' Purpose: include all need js functions
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("LibolCommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WStatClassItemIDJs", "<script language='javascript' src='../Js/Statistic/WStatClassItemIDSel.js'></script>")

            btnReset.Attributes.Add("onclick", "javascript:document.forms[0].reset(); return false;")
            btnStatistic.Attributes.Add("onclick", "javascript:return(TransferData('" & ddlLabel.Items(3).Text & "','" & ddlLabel.Items(3).Text & "','WStatClassItemID.aspx'));")
            btnExport.Attributes.Add("onclick", "javascript:return(TransferExport('" & ddlLabel.Items(3).Text & "','" & ddlLabel.Items(3).Text & "','WStatClassItemID.aspx'));")
            Me.RegisterCalendar("../..")
            SetOnclickCalendar(hrfTimeFrom, txtTimeFrom, ddlLabel.Items(3).Text)
            SetOnclickCalendar(hrfTimeTo, txtTimeTo, ddlLabel.Items(3).Text)

            txtTimeTo.Text = Session("ToDay")
        End Sub

        ' Method: GenChartDirector
        ' Purpose: generate charts here
        Private Sub BindData()
            Dim tblItemType As New DataTable
            Dim listItem As New listItem

            Try
                tblItemType = objBCB.GetItemTypes

                If Not tblItemType Is Nothing AndAlso tblItemType.Rows.Count > 0 Then
                    tblItemType = InsertOneRow(tblItemType, ddlLabel.Items(2).Text)

                    ddlItemType.DataSource = tblItemType
                    ddlItemType.DataValueField = "ID"
                    ddlItemType.DataTextField = "TypeCode"
                    ddlItemType.DataBind()
                Else
                    listItem.Text = ddlLabel.Items(2).Text
                    listItem.Value = 0
                    ddlItemType.Items.Add(listItem)
                End If
            Catch ex As Exception ' Catch errors
            End Try
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBCB Is Nothing Then
                objBCB.Dispose(True)
                objBCB = Nothing
            End If
            If Not objBCDBS Is Nothing Then
                objBCDBS.Dispose(True)
                objBCDBS = Nothing
            End If
        End Sub
    End Class
End Namespace