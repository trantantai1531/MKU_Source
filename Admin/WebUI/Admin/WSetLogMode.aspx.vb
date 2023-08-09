' Class: WSetLogMode
' Puspose: Set log mode
' Creator: Oanhtn
' CreatedDate: 18/11/2004
' Modification History:

Imports System
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.WebUI.Common
Imports eMicLibAdmin.BusinessRules.Admin
Imports OfficeOpenXml.FormulaParsing.Utilities
Imports Telerik.Web.UI

Namespace eMicLibAdmin.WebUI.Admin
    Partial Class WSetLogMode
        Inherits clsWBase
        Implements IUCNumberOfRecord
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblLabel1 As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Dim objBEventGroup As New clsBEventGroup
        Dim tblEDelMode As New DataTable
        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call LoadGroups()
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBEventGroup object
            objBEventGroup.ConnectionString = Session("ConnectionString")
            objBEventGroup.DBServer = Session("DBServer")
            objBEventGroup.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBEventGroup.Initialize()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = 'Js/WSetLogMode.js'></script>")

            btnUpdate.Attributes.Add("OnClick", "if(!CheckOptionsNullByCssClass('ckb-value', 'chkID', 2, 50, '" & ddlLabel.Items(2).Text & "')) return false;")
        End Sub

        ' LoadGroups method
        ' Purpose: load all eventgroups
        Private Sub LoadGroups()
            Dim tblTemp As DataTable

            tblTemp = objBEventGroup.GetEventGroups
            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    ddlGroup.DataSource = tblTemp
                    ddlGroup.DataTextField = "VietName"
                    ddlGroup.DataValueField = "ID"
                    ddlGroup.DataBind()
                    ddlGroup.SelectedIndex = 0
                    'Call LoadEventsOfGroup()
                End If
                tblTemp.Dispose()
                tblTemp = Nothing
            End If
        End Sub

        ' btnUpdate_Click event
        ' Purpose: Set log mode
        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Dim strEventIDs As String
            Dim intEventID As Integer
            Dim intCount As Integer


            Dim serializer As New JavaScriptSerializer()
            Dim selectedIDs As New Dictionary(Of String, Boolean)()
            ' Find control in datagrid

            For intCount = 0 To dtgEvents.MasterTableView.Items.Count - 1
                If CType(dtgEvents.MasterTableView.Items(intCount).Cells(1).FindControl("chkID"), HtmlInputCheckBox).Checked Then

                    intEventID = CInt(CType(dtgEvents.MasterTableView.Items(intCount).Cells(0).FindControl("lblID"), Label).Text)

                    strEventIDs = strEventIDs & CStr(intEventID) & ","

                End If
            Next
            If Not strEventIDs = "" Then
                strEventIDs = Left(strEventIDs, Len(strEventIDs) - 1)
                objBEventGroup.ParentID = ddlGroup.SelectedValue
                objBEventGroup.EventIDs = strEventIDs
                Call objBEventGroup.SetLogMode()
                Page.RegisterClientScriptBlock("success", "<script language='javascript'>alert('" & ddlLabel.Items(3).Text & "')</script>")
            End If
            'dtgEvents.AllowPaging = True
            'dtgEvents.Rebind()
        End Sub




        Public Function GetNumber() As Integer Implements IUCNumberOfRecord.NumberOfRecord
            Return 25
        End Function

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
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

 

        Protected Sub dtgEvents_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles dtgEvents.NeedDataSource
            Dim tblTemp As DataTable

            objBEventGroup.EventGroupID = ddlGroup.SelectedValue
            tblTemp = objBEventGroup.GetEventsOfGroup
            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    dtgEvents.DataSource = tblTemp

                End If
                tblTemp.Dispose()
                tblTemp = Nothing
            End If

        End Sub

        Protected Sub ddlGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlGroup.SelectedIndexChanged
            Dim tblTemp As DataTable
            objBEventGroup.EventGroupID = ddlGroup.SelectedValue
            tblTemp = objBEventGroup.GetEventsOfGroup
            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    dtgEvents.DataSource = tblTemp
                    dtgEvents.Rebind()
                End If
                tblTemp.Dispose()
                tblTemp = Nothing
            End If
        End Sub

       
    End Class
End Namespace