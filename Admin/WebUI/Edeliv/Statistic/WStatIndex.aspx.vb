Imports eMicLibAdmin.BusinessRules.Edeliv
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WStatIndex
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
            Call CheckFormPemission()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/Statistic/WStatIndex.js'></script>")
        End Sub


        ' CheckFormPemission method
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            'If Not CheckPemission(163) Then
            '    Call WriteErrorMssg(ddlLabel.Items(0).Text)
            'End If
            Try
                If clsSession.ModuleID = 9 And CInt(Session("DELModule")) = 0 Then
                    CheckPemission(-9999)
                    Call WriteErrorMssg(ddlLabel.Items(0).Text)
                End If
            Catch ex As Exception
                Call WriteErrorMssg(ddlLabel.Items(0).Text)
            End Try
        End Sub

        ' Initialize method
        Private Sub Initialize()

        End Sub

        Private Sub imgStatYear_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgStatYear.Click
            Response.Redirect("WStatYear.aspx")
        End Sub

        Private Sub imgStatDay_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgStatDay.Click
            Response.Redirect("WStatDay.aspx")
        End Sub

        Private Sub imgStatMonth_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgStatMonth.Click
            Response.Redirect("WStatMonth.aspx")
        End Sub

        Private Sub imgStatTop20_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgStatTop20.Click
            Response.Redirect("WStatTop20.aspx")
        End Sub

        Private Sub imgStatTopItem_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgStatTopItem.Click
            Response.Redirect("WStatTopItem.aspx")
        End Sub

        Private Sub imgStatTopCustomer_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgStatTopCustomer.Click
            Response.Redirect("WStatTopCustomer.aspx")
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try

            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

    End Class

End Namespace
