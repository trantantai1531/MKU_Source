Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WIDXView
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

        Private objBGenIdx As New clsBGenIdx

        'Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Init all object use in form
            Call Initialize()
            'Bind javascript for all control need
            Call BindJavascript()
            'View data
            Call WriteIDX()
        End Sub

        'Methord: Initialize
        'Popurse: Init all object use in form
        Private Sub Initialize()
            'Object objBGenIdx
            objBGenIdx.InterfaceLanguage = Session("InterfaceLanguage")
            objBGenIdx.DBServer = Session("DbServer")
            objBGenIdx.ConnectionString = Session("ConnectionString")
            objBGenIdx.Initialize()
        End Sub

        'Methord: BindJavascript
        'Popurse: Bind javascript for all control need
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("JSCommon", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("JSSelf", "<script language = 'javascript' src = '../js/Bibliography/WIDXView.js'></script>")
        End Sub

        'Methord: WriteIDX
        Private Sub WriteIDX()
            Dim ArrIDX()
            Dim intCount As Integer
            Dim intCurPg As Integer
            Dim arrLabel()
            Dim colPara As New Collection

            colPara = Session("colPara")
            arrLabel = Split(lblLabel.Text, ";")
            intCurPg = Request.QueryString("intPg")
            objBGenIdx.PageSize = colPara.Item("intPageSize")
            objBGenIdx.GroupBy = colPara.Item("strGrpBy")
            objBGenIdx.IdxID = colPara.Item("intIDXID")
            objBGenIdx.TemplateID = colPara.Item("intTemplateID")
            objBGenIdx.TypeView = colPara.Item("intTypeView")
            objBGenIdx.TypeViewVal = colPara.Item("strTypeViewVal")
            objBGenIdx.Label = arrLabel
            objBGenIdx.TitleArr = colPara.Item("TitleArr")
            objBGenIdx.ItemIDArr = colPara.Item("ItemIDArr")
            objBGenIdx.IndexArr = colPara.Item("IndexArr")

            ArrIDX = objBGenIdx.GenerateData(intCurPg)
            For intCount = 0 To ArrIDX.Length - 1
                Response.Write(ArrIDX(intCount))
            Next intCount
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not objBGenIdx Is Nothing Then
                        objBGenIdx.Dispose(True)
                        objBGenIdx = Nothing
                    End If
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace