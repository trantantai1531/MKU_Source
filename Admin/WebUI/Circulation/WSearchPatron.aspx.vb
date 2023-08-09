' Class: WSearchPatron  
' Puspose:Tim kiem thong tin ban don, theo ma ban doc(BD) hoac theo ten BD 
' Creator: Tuanhv
' CreatedDate: 19/08/2004
' Modification History:
'   - 17/04/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.WebUI.Common
Imports Telerik.Web.UI

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WSearchPatron
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

        ' Declare variables
        Private objBPatron As New clsBPatron
        Private objBPatronGroup As New BusinessRules.Patron.clsBPatronGroup

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
            If Page.IsPostBack = False Then
                Call BindDLL()
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            'Init objBPatron
            objBPatron.InterfaceLanguage = Session("InterfaceLanguage")
            objBPatron.DBServer = Session("DBServer")
            objBPatron.ConnectionString = Session("ConnectionString")
            Call objBPatron.Initialize()
            ' Init objBPatronGroup object
            objBPatronGroup.DBServer = Session("DBServer")
            objBPatronGroup.ConnectionString = Session("ConnectionString")
            objBPatronGroup.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPatronGroup.Initialize()
        End Sub

        ' BindScript method
        ' Purpose: Bind javascript
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = 'js/WSearchPatron.js'></script>")
            'btnSearch.Attributes.Add("onClick", "if(trim(document.forms[0].txtFullName.value)=='') {alert('" & ddlLabel.Items(3).Text & "');document.forms[0].txtFullName.focus();return false;} return true;")
            'txtFullName.Attributes.Add("onkeypress", "EventKeyPress();")
        End Sub

        ''DgdGetPatronInfor_PageIndexChanged
        'Private Sub DgdGetPatronInfor_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DgdGetPatronInfor.PageIndexChanged
        '    Try
        '        DgdGetPatronInfor.CurrentPageIndex = e.NewPageIndex
        '        BindData()
        '    Catch ex As Exception
        '    End Try
        'End Sub

        ' btnSearch_Click event
        ' Purpose: Find patron allow id of patron or name patron
        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            Try
                DgdGetPatronInfor.CurrentPageIndex = 0
                BindData()
                DgdGetPatronInfor.Rebind()
            Catch ex As Exception
            End Try
        End Sub

        Private Sub BindDLL()
            Dim tblTemp As DataTable = objBPatronGroup.GetPatronGroup()

            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlPatronGroup.DataSource = InsertOneRow(tblTemp, LabelSelect.Text)
                ddlPatronGroup.DataTextField = "Name"
                ddlPatronGroup.DataValueField = "ID"
                ddlPatronGroup.DataBind()
            Else
                ddlPatronGroup.DataSource = Nothing
                ddlPatronGroup.DataBind()
            End If
        End Sub

        Private Sub BindData()
            Dim tblResult As DataTable
            Dim blnFound As Boolean = False

            ' Seach & show result
            objBPatron.PatronCode = txtPatronCode.Text.Trim
            objBPatron.FullName = txtFullName.Text.Trim
            objBPatron.PatronGroupID = ddlPatronGroup.SelectedValue
            objBPatron.Email = txtEmail.Text.Trim
            objBPatron.Telephone = txtTelephone.Text.Trim
            objBPatron.LibID = clsSession.GlbSite
            tblResult = objBPatron.GetPatron()

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPatron.ErrorMsg, ddlLabel.Items(0).Text, objBPatron.ErrorCode)

            If Not tblResult Is Nothing Then
                If tblResult.Rows.Count > 0 Then
                    DgdGetPatronInfor.DataSource = tblResult
                    'DgdGetPatronInfor.DataBind()
                    blnFound = True
                End If
            End If

            If blnFound Then
                DgdGetPatronInfor.Visible = True
                lnkAddPatron.Visible = False
            Else
                Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript'>alert('" & ddlLabel.Items("2").Text & "');</script>")
                DgdGetPatronInfor.Visible = False
                lnkAddPatron.Visible = True
                lnkAddPatron.NavigateUrl = "WAddPatron.aspx"
            End If

        End Sub


        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBPatron Is Nothing Then
                    objBPatron.Dispose(True)
                    objBPatron = Nothing
                End If
                If Not objBPatronGroup Is Nothing Then
                    objBPatronGroup.Dispose(True)
                    objBPatronGroup = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        Protected Sub DgdGetPatronInfor_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles DgdGetPatronInfor.NeedDataSource
            If txtFullName.Text.Trim <> "" Then
                BindData()
            End If
        End Sub

        Public Function NumberOfRecord() As Integer Implements IUCNumberOfRecord.NumberOfRecord
            Return 25
        End Function
    End Class
End Namespace