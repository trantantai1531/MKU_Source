' Class: WStatDayTaskbar
' Puspose: Create statistic by acqday
' Creator: Sondp
' CreatedDate: 01/04/2005
' Modification History:
'   - 13/04/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WStatDayTaskbar
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
        Private objBS As New clsBStatistic

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
            ' Initialize objBS object
            objBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBS.DBServer = Session("DBServer")
            objBS.ConnectionString = Session("ConnectionString")
            objBS.Initialize()
        End Sub

        ' Method: BindScript
        ' Purpose: include all need js functions
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("WStatDayTaskbarJs", "<script language='javascript' src='../Js/Statistic/WStatDay.js'></script>")
            btnClose.Attributes.Add("OnClick", "parent.parent.mainacq.location.href='WStatIndex.aspx';return(false);")
            btnStatistic.Attributes.Add("OnClick", "TransferData();return(false);")
            btnExport.Attributes.Add("OnClick", "TransferDataExport();return(false);")
        End Sub

        ' Method: BindScript
        ' Purpose: include all need js functions
        Private Sub BindData()
            Dim tblAcqYear As New DataTable
            Dim listItem As New listItem
            Dim inti As Integer

            Try
                tblAcqYear = objBS.GetAcqYear
                If Not tblAcqYear Is Nothing Then
                    If tblAcqYear.Rows.Count > 0 Then
                        ddlYear.DataSource = tblAcqYear
                        ddlYear.DataTextField = "Year"
                        ddlYear.DataValueField = "Year"
                        ddlYear.DataBind()
                    End If
                Else
                    listItem.Text = Year(Now)
                    listItem.Value = Year(Now)
                    ddlYear.Items.Add(listItem)
                End If

                If Not Session("year") Is Nothing Then
                    For inti = 0 To ddlYear.Items.Count - 1
                        If ddlYear.Items(inti).Value = CStr(Session("year")) Then
                            ddlYear.Items(inti).Selected = True
                            Exit For
                        End If
                    Next
                Else
                    ddlYear.Items(ddlYear.Items.Count - 1).Selected = True
                End If
            Catch ex As Exception ' Catch errors
            End Try
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBS Is Nothing Then
                objBS.Dispose(True)
                objBS = Nothing
            End If
        End Sub
    End Class
End Namespace