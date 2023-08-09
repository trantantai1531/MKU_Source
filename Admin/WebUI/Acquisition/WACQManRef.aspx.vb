Imports System
Imports System.IO
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WACQManRef
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents imgIconGRit As System.Web.UI.WebControls.Image


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region
        Private objBRef As New clsBReference

        ' init all object
        Private Sub Initialize()
            ' init objBRef object
            objBRef.DBServer = Session("DBServer")
            objBRef.InterfaceLanguage = Session("InterfaceLanguage")
            objBRef.ConnectionString = Session("ConnectionString")
            objBRef.Initialize()
        End Sub

        Private Sub BindJS()
            Dim strJS As String
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language='javascript' src='js/WACQManRef.js'></script>")
        End Sub

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        Private Sub BindData()
            objBRef.UserID = Session("UserID")
            objBRef.ModuleID = 4 ' ACQ Module
            objBRef.ID = 0
            dtgResult.DataSource = objBRef.GetReference()
            dtgResult.DataBind()
        End Sub


        Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
            Dim dtgItem As DataGridItem
            Dim chkSelected As New CheckBox
            Dim strIDs As String = ""

            ' Get ID of selected CheckBox
            For Each dtgItem In dtgResult.Items ' Get Selected chkID
                chkSelected = CType(dtgItem.Cells(0).FindControl("chkID"), CheckBox)
                If chkSelected.Checked Then
                    strIDs = strIDs & CType(dtgItem.Cells(0).FindControl("lblID"), Label).Text & ","
                End If
            Next
            If strIDs <> "" Then
                strIDs = Left(strIDs, Len(strIDs) - 1)
                objBRef.RefIDs = strIDs
                objBRef.UserID = Session("UserID")
                objBRef.ModuleID = 4 ' ACQ Module
                objBRef.Update()
                Call BindData()
                Page.RegisterClientScriptBlock("JsParentLoad", "<script language='javascript'>parent.contents.location.href='WACQRefercence.aspx';</script>")
            End If
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBRef Is Nothing Then
                    objBRef.Dispose(True)
                    objBRef = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub


    End Class
End Namespace