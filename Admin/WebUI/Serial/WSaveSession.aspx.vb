Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WSaveSession
        Inherits clsWBase

        ' Declare variables

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
            Call Initialize()
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()

        End Sub

        ' SaveSession method
        Private Sub SaveSession()
            Dim strItemID As String = ""
            Dim strTitle As String = ""
            strItemID = Trim(CStr(hidItemID.Value))
            strTitle = Trim(CStr(hidTitle.Value))
            If strItemID <> "" And strTitle <> "" Then
                Session("ItemID") = strItemID
                Session("Title") = strTitle
                If Request("FormName") & "" <> "" Then
                    lblChangePage.Text = "<script language= 'javascript'>parent.Workform.location.href='" & Request("FormName") & "';</script>"
                    'Page.RegisterClientScriptBlock("LoadPage", "<script language= 'javascript'>parent.Workform.location.href='" & Request("FormName") & "';</script>")
                End If
            End If
        End Sub

        ' btnSave_Click event
        Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
            SaveSession()
        End Sub

        ' Page_Unload event
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
