' Class: WSearchForm
' Puspose: Display log search form
' Creator: Oanhtn
' CreatedDate: 18/11/2004
' Modification History:

Imports eMicLibAdmin.BusinessRules.Admin

Namespace eMicLibAdmin.WebUI.Admin
    Partial Class WSearchForm
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

        Dim objBEventGroup As New clsBEventGroup
        Dim objBUser As New clsBUser

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            Call LoadForm()
        End Sub

        ' Initialize method
        Private Sub Initialize()
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
        End Sub

        ' BindJS method
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = 'Js/WSearchForm.js'></script>")
            Me.RegisterCalendar("..")
            SetOnclickCalendar(lnkFromDate, txtFromDate, ddlLabel.Items(2).Text.Trim)
            SetOnclickCalendar(lnkToDate, txttodate, ddlLabel.Items(2).Text.Trim)

            txtFromTime.Attributes.Add("onChange", "javascript:CheckTime(this,'" & ddlLabel.Items(3).Text & "');")
            txtToTime.Attributes.Add("onChange", "javascript:CheckTime(this,'" & ddlLabel.Items(3).Text & "');")
            btnReset.Attributes.Add("OnClick", "document.forms[0].reset();")
            btnSearch.Attributes.Add("OnClick", "document.forms[0].action='WViewLog.aspx'; document.forms[0].submit(); return false;")
        End Sub

        ' LoadForm method
        ' Purpose: load form
        Private Sub LoadForm()
            Dim tblTemp As DataTable
            Dim intIndex As Integer

            ' Create event listbox
            tblTemp = objBEventGroup.GetEventsOfGroup()
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                lsbGroup.DataSource = tblTemp
                lsbGroup.DataTextField = "VietName"
                lsbGroup.DataValueField = "ID"
                lsbGroup.DataBind()

                For intIndex = 0 To tblTemp.Rows.Count - 1
                    If tblTemp.Rows(intIndex).Item("ParentID") = tblTemp.Rows(intIndex).Item("ID") Then
                        lsbGroup.Items(intIndex).Attributes.Add("style", "color:red")
                   
                    End If
                Next
                tblTemp.Clear()
            End If

            ' Create user listbox

            objBUser.ParentID = Session("UserID")
            tblTemp = objBUser.GetUsers
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                lsbUser.DataSource = tblTemp
                lsbUser.DataTextField = "NameU"
                lsbUser.DataValueField = "UserName"
                lsbUser.DataBind()
            End If

            If Not tblTemp Is Nothing Then
                tblTemp.Dispose()
                tblTemp = Nothing
            End If
        End Sub

        ' btnSearch_Click event
        ' Purpose: search events
        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBEventGroup Is Nothing Then
                    objBEventGroup.Dispose(True)
                    objBEventGroup = Nothing
                End If
                If Not objBUser Is Nothing Then
                    objBUser.Dispose(True)
                    objBUser = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace