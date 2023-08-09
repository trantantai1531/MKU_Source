' class WComprehReportBookD
' Puspose: Generate Comprehensive Report Book
' Creator: Sondp
' CreatedDate: 11/04/2005
' Modification History:

Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WComprehReportBookD
        ' Inherits System.Web.UI.Page
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblHeader As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private objBT As New clsBTemplate
        Private objBIO As New clsBItemOrder
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            'Call BindScript()
            hidAction.Value = ""
            If Not Page.IsPostBack Then
                If Not Session("Report") Is Nothing Then
                    Dim collectReport As New Collection
                    Dim inti As Integer
                    Dim lngStartID, lngStopID As Long
                    Dim strDisplay, strPhysicalPath As String
                    strDisplay = ""
                    collectReport = Session("Report")
                    If Not collectReport.Item("<$CURRENTPAGE$>") Is Nothing Then
                        collectReport.Remove("<$CURRENTPAGE$>")
                    End If
                    If Request.QueryString("CurrentPage") & "" = "" Then
                        collectReport.Add(collectReport.Item("<$SEQUENCY$>"), "<$CURRENTPAGE$>")
                        lngStartID = 0
                        lngStopID = collectReport.Item("<$ITEMSONPAGE$>") - 1
                    Else
                        If CInt(Request.QueryString("CurrentPage")) > 0 Then
                            collectReport.Add(CInt(Request.QueryString("CurrentPage")) - 1 + CInt(collectReport.Item("<$SEQUENCY$>")), "<$CURRENTPAGE$>")
                            lngStartID = CLng(Request.QueryString("CurrentPage") - 1) * CLng(collectReport.Item("<$ITEMSONPAGE$>"))
                            lngStopID = CLng(Request.QueryString("CurrentPage")) * CLng(collectReport.Item("<$ITEMSONPAGE$>")) - 1
                        End If
                    End If
                    ' Gen ComprehensiveReportBook
                    strDisplay = objBT.GenComprehReportBook(lngStartID, lngStopID, collectReport("<$ITEMIDS$>"), Session("UserID"), collectReport)
                    lblDisplay.Text = strDisplay
                    Select Case UCase(collectReport.Item("<$SIGN$>"))
                        Case "PRINT"
                            VisiblePrint(False)
                            Page.RegisterClientScriptBlock("PrintJs", "<script language='javascript'>self.focus();setTimeout('self.print()', 1);</script>")
                        Case "FILE"
                            strPhysicalPath = objBIO.SaveToFile(strDisplay, "doc", True, Server.MapPath("../.."))
                            If objBIO.ErrorCode = -13 Then
                                Page.RegisterClientScriptBlock("AlertSaveFileErrJs", "<script language=javascript>alert('" & lblNote.Text & "');</script>")
                            End If
                            If objBIO.ErrorCode = 0 Then
                                hidAction.Value = "FILE"
                                hidFileName.Value = strPhysicalPath
                            End If
                    End Select
                End If
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Initialize objBT object
            objBT.InterfaceLanguage = Session("InterfaceLanguage")
            objBT.DBServer = Session("DBServer")
            objBT.ConnectionString = Session("ConnectionString")
            objBT.Initialize()
            ' Initialize objBIO object
            objBIO.InterfaceLanguage = Session("InterfaceLanguage")
            objBIO.DBServer = Session("DBServer")
            objBIO.ConnectionString = Session("ConnectionString")
            objBIO.Initialize()
        End Sub
        Private Sub VisiblePrint(ByVal bol As Boolean)
            btnPrint.Visible = bol
            btnSaveToFile.Visible = bol
            btnEdit.Visible = bol
        End Sub
        Private Sub btnSaveToFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveToFile.Click
            Dim strPhysicalPath As String
            hplLink.Visible = False
            strPhysicalPath = objBIO.SaveToFile(lblDisplay.Text, "doc", True, Server.MapPath("../.."))
            If objBIO.ErrorCode = -13 Then
                Page.RegisterClientScriptBlock("AlertSaveFileErrJs", "<script language=javascript>alert('" & lblNote.Text & "');</script>")
            End If
            If objBIO.ErrorCode = 0 Then
                hidAction.Value = "FILE"
                hplLink.Visible = True
                Dim physicalname$ = "../TempFiles" & "/" & strPhysicalPath
                'hplLink.Attributes.Add("OnClick", "window.open('" & physicalname & "')")
                'hplLink.NavigateUrl = "../TempFiles" & " / " & strPhysicalPath
                Page.RegisterClientScriptBlock("AlertSaveFileErrJs", "<script language=javascript>alert('" & lblError.Text & "');</script>")
                hidFileName.Value = strPhysicalPath
                Page.RegisterClientScriptBlock("FileDownActionJs", "<script language=javascript>window.open('../../Common/WSaveTempFile.aspx?ModuleID=4&FileName=" & strPhysicalPath & "';</script>")
                hplLink.Attributes.Add("OnClick", "parent.hiddenbase.location.href='../../Common/WSaveTempFile.aspx?ModuleID=4&FileName=" & strPhysicalPath & "';return false;")
                hplLink.NavigateUrl = "#"
            End If
        End Sub

        Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
            If Not lblDisplay.Text = "" Then
                Session("EditComprehendsiveReportBook") = lblDisplay.Text
                Response.Redirect("WComprehReportBookE.aspx")
            End If
        End Sub

        ' Page_Unload method
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBT Is Nothing Then
                objBT.Dispose(True)
                objBT = Nothing
            End If
            If Not objBIO Is Nothing Then
                objBIO.Dispose(True)
                objBIO = Nothing
            End If
        End Sub

        Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
            VisiblePrint(False)
            Page.RegisterClientScriptBlock("FileDownActionJs", "<script language=javascript>self.focus();setTimeout('self.print()', 1);return(false);</script>")
        End Sub
    End Class
End Namespace