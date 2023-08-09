' Class: WViewLog
' Puspose: View log informations
' Creator: Oanhtn
' CreatedDate: 18/11/2004
' Modification History:

Imports eMicLibAdmin.WebUI.Common
Imports eMicLibAdmin.BusinessRules.Admin
Imports Telerik.Web.UI

Namespace eMicLibAdmin.WebUI.Admin
    Partial Class WViewLog
        Inherits clsWBase
        Implements IUCNumberOfRecord
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

        Dim objBLog As New clsBLog
        Dim objBEventGroup As New clsBEventGroup
        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                ' Call SearchLog()
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
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
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            'lnkSearch.NavigateUrl = "WSearchForm.aspx"
        End Sub

        ' SearchLog method
        ' Purpose: search log
        Private Sub SearchLog()
            Dim strWord As String
            Dim strFromDate As String
            Dim strToDate As String
            Dim strFromTime As String
            Dim strToTime As String
            Dim strGroupIDs As String
            Dim strUserNames As String
            Dim tblTemp As DataTable
            Dim blnFound As Boolean = False

            If Not Request("txtWord") = "" Then
                hidWord.Value = Request("txtWord")
            End If
            If Not Request("txtFromDate") = "" Then
                hidFromDate.Value = Request("txtFromDate")
            End If
            If Not Request("txtToDate") = "" Then
                hidToDate.Value = Request("txtToDate")
            End If
            If Not Request("txtFromTime") = "" Then
                hidFromTime.Value = Request("txtFromTime")
            End If
            If Not Request("txtToTime") = "" Then
                hidToTime.Value = Request("txtToTime")
            End If
            If Not Request("lsbGroup") = "" Then
                hidGroup.Value = Request("lsbGroup")
            End If
            If Not Request("lsbUser") = "" Then
                hidUser.Value = Request("lsbUser")
            End If

            strWord = hidWord.Value
            strFromDate = hidFromDate.Value
            strToDate = hidToDate.Value
            strFromTime = hidFromTime.Value
            strToTime = hidToTime.Value
            strGroupIDs = hidGroup.Value
            strUserNames = UCase(hidUser.Value)

            ' Incase show detail for statistic
            If Request("FromStat") = "1" Then
                strToDate = strFromDate
                strFromTime = "00:00:00"
                strToTime = "23:59:59"
            End If

            objBLog.Message = strWord
            objBLog.EventGroupIDs = strGroupIDs
            objBLog.UserNames = strUserNames
            If Not strFromDate = "" Then
                objBLog.LogTimeFrom = strFromDate
            End If
            If Not strToDate = "" Then
                objBLog.LogTimeTo = strToDate
            End If

            tblTemp = objBLog.Search(strFromTime, strToTime)
            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    dtgLog.DataSource = tblTemp
                    'dtgLog1.DataBind()
                    blnFound = True
                End If
                tblTemp.Dispose()
                tblTemp = Nothing
            End If
            If Not blnFound Then
                Page.RegisterClientScriptBlock("AlertJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(2).Text & "');location.href='WSearchForm.aspx';</script>")
            End If
        End Sub

        '' dtgLog_SelectedIndexChanged event
        '' Purpose: change page
        'Public Sub dtgLog_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgLog.PageIndexChanged
        '    dtgLog.EditItemIndex = -1
        '    dtgLog.CurrentPageIndex = e.NewPageIndex
        '    Call SearchLog()
        'End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        Public Function GetNumber() As Integer Implements IUCNumberOfRecord.NumberOfRecord
            Return 10
        End Function

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBLog Is Nothing Then
                    objBLog.Dispose(True)
                    objBLog = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        Protected Sub dtgLog_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles dtgLog.NeedDataSource
           SearchLog()

        End Sub
    End Class
End Namespace