Imports eMicLibAdmin.WebUI.Common
Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WGenCopyNumber
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

        Private objBCopyNumer As New clsBCopyNumber

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Dim strJS As String
            strJS = ""
            If Trim(Request.QueryString("caller") & "") <> "" Then
                If IsNumeric(Request.QueryString("LocID")) And Trim(Request.QueryString("LocID") & "") <> "" Then
                    objBCopyNumer.LocID = CInt(Request.QueryString("LocID"))
                Else
                    objBCopyNumer.LocID = 0
                End If
                If Trim(Request.QueryString("Shelf") & "") <> "" Then
                    objBCopyNumer.Shelf = Request.QueryString("Shelf")
                End If
                objBCopyNumer.UserID = CInt(Session("UserID"))
                objBCopyNumer.LibID = clsSession.GlbSite

                strJS = Request.QueryString("caller") & ".value=""" & objBCopyNumer.GenCopyNumber() & """"
            End If
            Page.RegisterClientScriptBlock("selfJs", "<script language = 'javascript' >" & strJS & ";</script>")
        End Sub

        ' Initialize method 
        Sub Initialize()
            ' Init for objBCommon
            objBCopyNumer.InterfaceLanguage = Session("InterfaceLanguage")
            objBCopyNumer.DBServer = Session("DBServer")
            objBCopyNumer.ConnectionString = Session("ConnectionString")
            objBCopyNumer.Initialize()
        End Sub

        ' Page_Unload Method
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Release all object
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCopyNumer Is Nothing Then
                    objBCopyNumer.Dispose(True)
                    objBCopyNumer = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace