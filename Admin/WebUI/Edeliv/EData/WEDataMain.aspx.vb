Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WEDataMain
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

        Private objBCDBS As New eMicLibAdmin.BusinessRules.Common.clsBCommonDBSystem
        Dim strServerUniVis, strUniVisPort As String
        Dim arrName(1), arrValue(1) As String
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not CheckPemission() Then
                Call WritePermErrorMssg()
            End If
            Call Initialize()
            ' Bind script
            If Not Page.IsPostBack Then
                'Dim strScript As String
                'lnkOutEditor.Attributes.Add("OnClick", "javascript:parent.Sentform.location.href='../../Common/WSaveTempFile.aspx?ModuleID=10&FileName=liboledit-setup.zip';")
                'arrName(0) = "UNIVIS_SERVER"
                'arrName(1) = "UNIVIS_PORT"
                'arrValue = objBCDBS.GetSystemParameters(arrName)
                'strServerUniVis = arrValue(0)
                'strUniVisPort = arrValue(1)
                'strScript = "function LoadUnivisCenter(){"
                'strScript = strScript & "self.location.href='http://" & strServerUniVis & ":" & strUniVisPort & "';"
                'strScript = strScript & "}"
                'Page.RegisterClientScriptBlock("ShelfJs", "<script language='javascript'>" & strScript & "</script>")
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBCDBS
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            Call objBCDBS.Initialize()
        End Sub

        'Private Sub imgEdata_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgEdata.Click
        '    Response.Redirect("WEDataManager.aspx")
        'End Sub

        'Private Sub imgOutEditor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgOutEditor.Click
        '    Page.RegisterClientScriptBlock("FileDownActionJs", "<script language='javascript'>parent.Sentform.location.href='../../Common/WSaveTempFile.aspx?ModuleID=10&FileName=liboledit-setup.exe';</script>")
        'End Sub

        'Private Sub imgUnivis_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgUnivis.Click
        '    Response.Redirect("http://" & strServerUniVis & ":" & strUniVisPort)
        'End Sub

        'Private Sub imgCollection_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgCollection.Click
        '    Response.Redirect("WEdataCollection.aspx")
        'End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
