' Propose: Create fich pattern
' Class: WAdvIDXViewForm
' CreatedDate: 30/08/2005
' Creator: Sondp.
'  Modification history 

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Namespace eMicLibAdmin.WebUI.Catalogue
    Public Class WAdvIDXViewForm
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblMainTitle As System.Web.UI.WebControls.Label
        Protected WithEvents lblExtendsion As System.Web.UI.WebControls.Label
        Protected WithEvents ddlExtendsion As System.Web.UI.WebControls.DropDownList
        Protected WithEvents lblUbound As System.Web.UI.WebControls.Label
        Protected WithEvents ddlUbound As System.Web.UI.WebControls.DropDownList
        Protected WithEvents btnDo As System.Web.UI.WebControls.Button
        Protected WithEvents btnReset As System.Web.UI.WebControls.Button
        Protected WithEvents hrfFileLink As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lblLabel As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel2 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel3 As System.Web.UI.WebControls.Label
        Protected WithEvents lblDownload As System.Web.UI.WebControls.Label
        Protected WithEvents CrystalReportViewer1 As CrystalDecisions.Web.CrystalReportViewer
        Protected WithEvents CrystalReportViewer2 As CrystalDecisions.Web.CrystalReportViewer

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private objBGenIdx As New clsBGenIdx
        Private objBIDx As New clsBIDX
        Private objBCDBS As New clsBCommonDBSystem
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            hrfFileLink.Visible = False
        End Sub

        ' Method: Initialize
        ' Purpose: Init all object use form
        Public Sub Initialize()
            'Object objBGenIdx
            objBGenIdx.InterfaceLanguage = Session("InterfaceLanguage")
            objBGenIdx.DBServer = Session("DbServer")
            objBGenIdx.ConnectionString = Session("ConnectionString")
            objBGenIdx.Initialize()
            'Object objBIDx
            objBIDx.InterfaceLanguage = Session("InterfaceLanguage")
            objBIDx.DBServer = Session("DbServer")
            objBIDx.ConnectionString = Session("ConnectionString")
            objBIDx.Initialize()
            'Object objBCDBS
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DbServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            objBCDBS.Initialize()
        End Sub

        ' Purpose: GetIDX
        ' In: boolReformat
        ' Out: Object
        Private Function GetIDX(Optional ByVal boolReformat As Boolean = False) As Object
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

            ArrIDX = objBGenIdx.GenerateDataForReport(intCurPg, ddlUbound.SelectedValue)

            'Check error
            Call WriteErrorMssg(lblLabel2.Text, objBGenIdx.ErrorMsg, lblLabel3.Text, objBGenIdx.ErrorCode)
            ' Depend on ArrIDX build datatable have only one collunm
            Dim tblView As New DataTable
            Dim row As DataRow

            tblView.Columns.Add("Content", System.Type.GetType("System.String"))
            For intCount = 0 To UBound(ArrIDX)
                row = tblView.NewRow
                row(0) = ArrIDX(intCount)
                If boolReformat Then
                    row(0) = Reformat(row(0))
                End If
                tblView.Rows.Add(row)
            Next
            GetIDX = Nothing
            If Not tblView Is Nothing Then
                If tblView.Rows.Count > 0 Then
                    GetIDX = tblView
                End If
            End If
        End Function

        ' Export method
        ' In: intExportMode
        ' Out: Logical pathu
        Private Function Export(ByVal intExportMode As Integer) As String
            Dim objOptions As New CrystalDecisions.Shared.DiskFileDestinationOptions
            Dim objcryAdvIDViewForm As New cryAdvIDXViewForm
            Dim strFileName As String
            Dim strPath As String
            Dim tblIDX As New DataTable
            Dim strContent As String = ""

            If ddlExtendsion.SelectedValue = 1 Or ddlExtendsion.SelectedValue = 3 Then
                tblIDX = GetIDX(True)
            Else
                tblIDX = GetIDX()
            End If
            ' objcryAdvIDViewForm.EnableEventLog(EventLogLevel.NoLogging)
            objcryAdvIDViewForm.SetDataSource(tblIDX)
            Select Case intExportMode
                Case 1 ' pdf
0:                  objBCDBS.Extension = "pdf"
                    strFileName = objBCDBS.GenRandomFile
                    If objBCDBS.GetTempFilePath(1).Rows.Count > 0 Then
                        strPath = Server.MapPath("../..") & objBCDBS.GetTempFilePath(1).Rows(0).Item("TempFilePath") & "\" & strFileName
                    End If
                    objOptions = New CrystalDecisions.Shared.DiskFileDestinationOptions
                    objcryAdvIDViewForm.ExportOptions.ExportDestinationType = CrystalDecisions.[Shared].ExportDestinationType.DiskFile
                    objcryAdvIDViewForm.ExportOptions.ExportFormatType = CrystalDecisions.[Shared].ExportFormatType.PortableDocFormat ' Pdf type
                    objOptions.DiskFileName = strPath
                    objcryAdvIDViewForm.ExportOptions.DestinationOptions = objOptions
                    objcryAdvIDViewForm.Export()
                Case 2 ' doc
                    Dim inti As Integer
                    If Not tblIDX Is Nothing Then
                        If tblIDX.Rows.Count > 0 Then
                            For inti = 0 To tblIDX.Rows.Count - 1
                                strContent &= tblIDX.Rows(inti).Item("Content")
                            Next
                        End If
                    End If
                    strFileName = objBIDx.SaveFile(strContent, Server.MapPath("../.."), False)
                Case 3 ' excel
                    objBCDBS.Extension = "xls"
                    strFileName = objBCDBS.GenRandomFile
                    If objBCDBS.GetTempFilePath(1).Rows.Count > 0 Then
                        strPath = Server.MapPath("../..") & objBCDBS.GetTempFilePath(1).Rows(0).Item("TempFilePath") & "\" & strFileName
                    End If
                    objOptions = New CrystalDecisions.Shared.DiskFileDestinationOptions
                    objcryAdvIDViewForm.ExportOptions.ExportDestinationType = CrystalDecisions.[Shared].ExportDestinationType.DiskFile
                    objcryAdvIDViewForm.ExportOptions.ExportFormatType = CrystalDecisions.[Shared].ExportFormatType.Excel
                    objOptions.DiskFileName = strPath
                    objcryAdvIDViewForm.ExportOptions.DestinationOptions = objOptions
                    objcryAdvIDViewForm.Export()
                Case Else ' html 
                    Dim inti As Integer
                    If Not tblIDX Is Nothing Then
                        If tblIDX.Rows.Count > 0 Then
                            For inti = 0 To tblIDX.Rows.Count - 1
                                strContent &= tblIDX.Rows(inti).Item("Content")
                            Next
                        End If
                    End If
                    strFileName = objBIDx.SaveFile(strContent, Server.MapPath("../.."), True)
            End Select
            Export = strFileName
        End Function

        Private Function Reformat(ByVal strIn As Object) As Object
            If Not strIn = "" Then
                Reformat = strIn.Replace("<CENTER>", "").Replace("</CENTER>", "").Replace("<H2>", "").Replace("</H2>", "").Replace("&nbsp;", " ").Replace(Chr(9), "    ").Replace("<BR>", vbCrLf).Replace("<bR>", vbCrLf).Replace("<Br>", vbCrLf).Replace("<br>", vbCrLf).replace("<B>", "").replace("</B", "")
            End If
        End Function

        Private Sub btnDo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDo.Click
            Dim strFileName As String = ""
            hrfFileLink.NavigateUrl = ""
            strFileName = Export(ddlExtendsion.SelectedValue)
            If Not strFileName = "" Then
                hrfFileLink.Visible = True
                hrfFileLink.Text = "<B>" & lblDownload.Text & "</B>"
                hrfFileLink.NavigateUrl = "#"
                hrfFileLink.Attributes.Add("OnClick", "javascript:parent.Hiddenbase.location.href='../../Common/WSaveTempFile.aspx?ModuleID=1&FileName=" & strFileName & "';")
            End If
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
                    If Not objBIDx Is Nothing Then
                        objBIDx.Dispose(True)
                        objBIDx = Nothing
                    End If
                    If Not objBCDBS Is Nothing Then
                        objBCDBS.Dispose(True)
                        objBCDBS = Nothing
                    End If
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace