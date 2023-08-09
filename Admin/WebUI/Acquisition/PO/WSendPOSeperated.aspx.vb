' class 
' Puspose: Send PO Seperated Store
' Creator: Sondp
' CreatedDate: 29/03/2005
' Modification History:

Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.BusinessRules.Acquisition.clsBItemOrder

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WSendPOSeperated
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

        Private objBIO As New clsBItemOrder

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                VisiableControls(True)
                Call InitializeData()
                Dim objmetric As New Metric
                Dim strDisplay As String
                objmetric = objBIO.GenSeparetedStore(Request.QueryString("Top"), Request.QueryString("POID"), Request.QueryString("TemplateID"))
                If Not objmetric.Equals(Nothing) Then
                    'If IsArray(objmetric) Then
                    Session("Metric") = objmetric
                    If Not objmetric.objData Is Nothing Then


                        strDisplay = objmetric.objData(0)
                        lblDisplay.Text = strDisplay
                        Select Case UCase(Request.QueryString("Flage"))
                            Case "PRINT"
                                VisiableControls(False)
                                Page.RegisterClientScriptBlock("PrintActionJs", "<script language='javascript'>self.focus();setTimeout('self.print()', 1);</script>")
                            Case "FILE"
                                Dim strFileName As String
                                VisiableControls(False)
                                strFileName = objBIO.SaveToFile(strDisplay, "doc", True, Server.MapPath("../.."))
                                If objBIO.ErrorMsg <> "" Then
                                    Page.RegisterClientScriptBlock("ErrrExportJs", "<script language='javascript'>alert('" & ddlLabel.Items(6).Text & "');</script>")
                                Else
                                    Page.RegisterClientScriptBlock("FileDownActionJs", "<script language='javascript'>parent.hiddenbase.location.href='../../Common/WSaveTempFile.aspx?ModuleID=4&FileName=" & strFileName & "';</script>")
                                    lblDownload1.Visible = True
                                    lblDownload2.Visible = True
                                    lnkGetIt.Visible = True
                                    lnkGetIt.Attributes.Add("OnClick", "parent.hiddenbase.location.href='../../Common/WSaveTempFile.aspx?ModuleID=4&FileName=" & strFileName & "';return false;")
                                    lnkGetIt.NavigateUrl = "#"
                                End If

                            Case "EMAIL"
                                If SendEmailPO(objmetric) Then
                                    Page.RegisterClientScriptBlock("SendEmailSuccessfulJs", "<script language='javascript'>alert('" & ddlLabel.Items(2).Text & "');</script>")
                                Else
                                    Page.RegisterClientScriptBlock("SendEmailUnSuccessfulJs", "<script language='javascript'>alert('" & ddlLabel.Items(3).Text & "');</script>")
                                End If
                        End Select
                    End If
                    'End  If
                End If
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Initialize objBIO object
            objBIO.InterfaceLanguage = Session("InterfaceLanguage")
            objBIO.DBServer = Session("DBServer")
            objBIO.ConnectionString = Session("ConnectionString")
            objBIO.Initialize()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            btnEdit.Attributes.Add("OnClick", "self.location.href='WSendPOSeperatedAction.aspx?action=EDIT';return false;")
        End Sub

        ' Initialize data method
        Private Sub InitializeData()
            Dim collecCollumTitle As New Collection
            Dim inti As Integer
            ' For CollumTitle(s)
            For inti = 0 To ddlCollumTitle.Items.Count - 1
                collecCollumTitle.Add(ddlCollumTitle.Items(inti).Text, ddlCollumTitle.Items(inti).Value)
            Next
            objBIO.TemplateID = Request.QueryString("TemplateID")
            objBIO.CollumTitle = collecCollumTitle
        End Sub

        ' Send email method
        ' In: objMetric
        ' Out: boolean
        Private Function SendEmailPO(ByVal objMetric As Metric) As Boolean
            Dim inti As Integer
            Dim intSuccess As Integer
            Try
                For inti = LBound(objMetric.objEmail) To UBound(objMetric.objEmail)
                    If Not objMetric.objEmail(inti) & "" = "" Then
                        intSuccess = SendMail(ddlLabel.Items(5).Text, objMetric.objData(inti), objMetric.objEmail(inti), True)
                        If intSuccess = 1 Then
                            SendEmailPO = True
                        Else
                            SendEmailPO = False
                        End If
                    End If
                Next
            Catch ex As Exception
                SendEmailPO = False
            End Try
        End Function

        ' Visiable controls method
        Private Sub VisiableControls(ByVal boolValue As Boolean)
            btnEdit.Visible = boolValue
            btnSaveToFile.Visible = boolValue
            btnPrint.Visible = boolValue
            btnEmail.Visible = boolValue
        End Sub

        Private Sub btnSaveToFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveToFile.Click
            Dim strFileName As String
            strFileName = objBIO.SaveToFile(lblDisplay.Text, "doc", True, Server.MapPath("../.."))
            If objBIO.ErrorMsg <> "" Then
                Page.RegisterClientScriptBlock("ErrrExportJs", "<script language='javascript'>alert('" & ddlLabel.Items(6).Text & "');</script>")
            Else
                Page.RegisterClientScriptBlock("FileDownActionJs1", "<script language='javascript'>parent.hiddenbase.location.href='../../Common/WSaveTempFile.aspx?ModuleID=4&FileName=" & strFileName & "';</script>")
            End If
        End Sub

        ' SaveToFile method
        Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
            VisiableControls(False)
            Page.RegisterClientScriptBlock("PrintActionJs1", "<script language='javascript'>self.focus();setTimeout('self.print()', 1);</script>")
        End Sub

        ' SendEmail method
        Private Sub btnEmail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEmail.Click
            Dim objMetric As New Metric
            objMetric = Session("Metric")
            If Not objMetric.Equals(Nothing) Then
                If SendEmailPO(objMetric) Then
                    Page.RegisterClientScriptBlock("SendEmailSuccessfulJs", "<script language='javascript'>alert('" & ddlLabel.Items(2).Text & "');</script>")
                Else
                    Page.RegisterClientScriptBlock("SendEmailUnSuccessfulJs", "<script language='javascript'>alert('" & ddlLabel.Items(3).Text & "');</script>")
                End If
            End If
        End Sub

        ' Page_Unload method
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBIO Is Nothing Then
                objBIO.Dispose(True)
                objBIO = Nothing
            End If
        End Sub
    End Class
End Namespace