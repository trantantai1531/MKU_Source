' Puspose: form set ordinal number
' Creator: Lent 
' CreatedDate: 16/2/2005
' Modification History:

Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition
Imports Telerik.Web.UI

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WOrdinalNumberChange
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
        Private objLocation As New clsBLocation

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Check permisssion
            Call CheckFormPermission()
            Call Initialize()
            Call BindJavascript()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Initialize method
        ' Purpose: Init all neccessary objects
        Private Sub Initialize()
            ' Initialize objLocation object
            objLocation.DBServer = Session("DBServer")
            objLocation.ConnectionString = Session("ConnectionString")
            objLocation.InterfaceLanguage = Session("InterfaceLanguage")
            objLocation.Initialize()
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(101) Then
                Call WriteErrorMssg(ddlLabelNote.Items(2).Text)
            End If
        End Sub

        ' BindJavascript method
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language='javascript' src='../JS/ACQ/WOrdinalNumberChange.js'></script>")
        End Sub

        ' BindData method
        ' Purpose: Load data
        Private Sub BindData()
            Dim tblResult As DataTable
            Dim intCount As Integer = 0

            'bind data for datagrid
            objLocation.LibID = 0
            objLocation.UserID = Session("UserID")
            objLocation.Status = -1
            objLocation.LocID = 0
            tblResult = objLocation.GetLocation
            If Not tblResult Is Nothing Then
                dtgContent.DataSource = tblResult
                'dtgContent.DataBind()
                intCount = tblResult.Rows.Count + 2
            End If
            btnUpdateAll.Attributes.Add("onclick", "return(CheckUpdate(" & CStr(intCount) & ",'" & ddlLabelNote.Items(3).Text & "','" & ddlLabelNote.Items(4).Text & "'))")
        End Sub
        Private Sub btnUpdateAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateAll.Click
            Dim dtgItem As GridDataItem
            Dim txtItemMaxNumber As TextBox
            Dim strStoreIDs As String = ""
            Dim strMaxNumbers As String = ""

            For Each dtgItem In dtgContent.Items
                txtItemMaxNumber = dtgItem.FindControl("txtdtgMaxNumber")
                strMaxNumbers = strMaxNumbers & txtItemMaxNumber.Text & ","
                strStoreIDs = strStoreIDs & dtgItem.GetDataKeyValue("ID").ToString() & ","
            Next
            ' Set max number
            objLocation.LocIDs = strStoreIDs
            Call objLocation.SetMaxID2Loc(strMaxNumbers)
            Page.RegisterClientScriptBlock("UpdateSuccessfull", "<script language='javascript'>alert('" & ddlLabelNote.Items(5).Text & "');</script>")
            ' Write log
            Call WriteLog(100, lblMainTitle.Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
            ' Refresh data
            Call BindData()
        End Sub

        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objLocation Is Nothing Then
                    objLocation.Dispose(True)
                    objLocation = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub




        Protected Sub dtgContent_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles dtgContent.NeedDataSource
           
            BindData()
        End Sub

    End Class
End Namespace