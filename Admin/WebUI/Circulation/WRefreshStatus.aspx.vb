Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WRefreshStatus
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

        Private objRsvTrans As New clsBReservationTransaction
        Public intInterval As Integer

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            Call BindScript()

            Dim tblRsvInfor As DataTable
            Dim strJS As String

            intInterval = Session("RefreshInterval")
            If intInterval = 0 Then
                intInterval = 60
            End If

            objRsvTrans.UserID = Session("UserID")
            tblRsvInfor = objRsvTrans.GetReservationPatronInfor()
            Call WriteErrorMssg(objRsvTrans.ErrorCode, objRsvTrans.ErrorMsg)

            If Not tblRsvInfor Is Nothing Then
                If CInt(tblRsvInfor.Rows.Count) > 0 Then
                    If Session("OrderMode") = "on" Then
                        strJS = "<SCRIPT LANGUAGE='JavaScript'>"
                        strJS = strJS & "OpenWindow('WReservations.aspx?OrderMode=0','Reservation',600,400,150,50);"
                        strJS = strJS & "</SCRIPT>"
                        Page.RegisterClientScriptBlock("ShowOrder", strJS)
                    End If
                End If
                tblRsvInfor = Nothing
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: initialize components
        Private Sub Initialize()
            'Init objRsvTrans
            objRsvTrans.ConnectionString = Session("ConnectionString")
            objRsvTrans.DBServer = Session("DBServer")
            objRsvTrans.InterfaceLanguage = Session("InterfaceLanguage")
            objRsvTrans.Initialize()
        End Sub

        ' Method: BindScript
        ' Purpose: Bind javascript
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: Release the objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objRsvTrans Is Nothing Then
                    objRsvTrans.Dispose(True)
                    objRsvTrans = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

    End Class
End Namespace
