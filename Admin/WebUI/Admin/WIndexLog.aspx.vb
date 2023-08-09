' Class: WDeleteLog
' Puspose: Display log index page 
' Creator: Oanhtn
' CreatedDate: 18/11/2004
' Modification History:
'   + 24/11/2004 by Oanhtn: create interface

Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.WebUI.Common
Imports eMicLibAdmin.BusinessRules.Admin

Namespace eMicLibAdmin.WebUI.Admin
    Partial Class WIndexLog
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

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Session("UserID") = 1 And Not CheckPemission(238) Then
                Call WriteErrorMssg(ddlLabel.Items(0).Text)
            End If
            Call BindScript()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
        End Sub


        'Private Sub imgSetLogMode_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgSetLogMode.Click
        '    Response.Redirect("WSetLogMode.aspx")
        'End Sub

        'Private Sub imgSearchLog_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgSearchLog.Click
        '    Response.Redirect("WSearchForm.aspx")
        'End Sub

        'Private Sub imgDeleteLog_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgDeleteLog.Click
        '    Response.Redirect("WDeleteLog.aspx")
        'End Sub

        'Private Sub imgWeekStat_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgWeekStat.Click
        '    Response.Redirect("WStatWeek.aspx")
        'End Sub

        'Private Sub imgMonthStat_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgMonthStat.Click
        '    Response.Redirect("WStatMonth.aspx")
        'End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            MyBase.Dispose()
            Me.Dispose()
        End Sub
    End Class
End Namespace