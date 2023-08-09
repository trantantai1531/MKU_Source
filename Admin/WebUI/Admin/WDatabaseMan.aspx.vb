Imports eMicLibAdmin.BusinessRules.Admin
Imports eMicLibLogin
Namespace eMicLibAdmin.WebUI.Admin
    Partial Class WDatabaseMan
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
            Call BindScript()
            Call LoadUserInfor()
        End Sub


        ' BindScript method
        ' Purpose: Include all neccessary javascript functions
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = 'Js/WDatabaseMan.js'></script>")
        End Sub

        ' LoadUserInfor method
        ' Purpose: get user information for showing
        Private Sub LoadUserInfor()
            Dim tblConn As DataTable
            Dim intConnID As Integer = 0
            Dim strConnectionName As String = ""
            Dim strUserName As String = ""
            Dim strPassWordOld As String = ""
            Dim strDataSource As String = ""
            Dim strServerIP As String
            Dim intDatabase As Integer
            Dim strJS As String
            Dim i As Integer
            Dim intRun As Integer
            Dim objLblg As New clseMicLibLogin
            Try
                tblConn = objLblg.GetDBConnection
                If tblConn Is Nothing Then
                    Exit Sub
                End If
                If Not Request.QueryString("ConnID") Is Nothing Then
                    intConnID = CInt(Request.QueryString("ConnID"))
                End If
                For i = 0 To tblConn.Rows.Count - 1
                    If tblConn.Rows(i).Item("ID") = intConnID Then
                        strConnectionName = tblConn.Rows(i).Item("ConnectionName")
                        strUserName = tblConn.Rows(i).Item("UserName")
                        strPassWordOld = tblConn.Rows(i).Item("PassWord")
                        strDataSource = tblConn.Rows(i).Item("DataSource")
                        strServerIP = tblConn.Rows(i).Item("ServerIP")
                        intRun = tblConn.Rows(i).Item("Run")
                        If tblConn.Rows(i).Item("DBServer") = "SQLSERVER" Then
                            intDatabase = 0
                        Else
                            intDatabase = 1
                        End If
                        strJS = "<script language='javascript'>LoadUserInfor('" & intConnID & "','" & strConnectionName & "','" & strUserName & "','" & strPassWordOld & "','" & strDataSource & "','" & strServerIP & "','" & intDatabase & "','" & intRun & "');</script>"
                        Page.RegisterClientScriptBlock("LoadUserInfor", strJS)
                        Exit For
                    End If
                Next
            Catch ex As Exception
            End Try
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