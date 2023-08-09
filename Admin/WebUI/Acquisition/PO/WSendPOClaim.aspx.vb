' class 
' Puspose: Send PO claim
' Creator: Sondp
' CreatedDate: 07/04/2005
' Modification History:

Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.BusinessRules.Acquisition.clsBItemOrder
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WSendPOClaim
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

        Private objBV As New clsBVendor
        Private objBIO As New clsBItemOrder
        Private objBPO As New clsBPurchaseOrder
        Dim objMetric As New Metric

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                hdPOID.Value = Request.QueryString("POID")
                hdTemplateID.Value = Request.QueryString("TemplateID")
                hdUbound.Value = Request.QueryString("Ubound")
                objMetric = GenClaimDate()
                If Not objMetric.Equals(Nothing) Then
                    lblDisplay.Text = objMetric.objData(0)
                    Session("Metric") = objMetric
                    Select Case UCase(Request.QueryString("Action"))
                        Case "PRINT"
                            VisiableControls(False)
                            Page.RegisterClientScriptBlock("PrintActionJs", "<script language='javascript'>self.focus();setTimeout('self.print()', 1);</script>")
                        Case "EMAIL"
                            If SendEmail(objMetric) Then
                                Page.RegisterClientScriptBlock("SendEmailSuccessfulJs", "<script language='javascript'>alert('" & ddlLabel.Items(2).Text & "');</script>")
                            Else
                                Page.RegisterClientScriptBlock("SendEmailUnSuccessfulJs", "<script language='javascript'>alert('" & ddlLabel.Items(3).Text & "');</script>")
                            End If
                        Case "FILE"
                            Dim strFileName As String
                            VisiableControls(False)
                            strFileName = objBIO.SaveToFile(lblDisplay.Text, "doc", True, Server.MapPath("../.."))
                            If objBIO.ErrorMsg <> "" Then
                                Page.RegisterClientScriptBlock("ErrrExportJs", "<script language='javascript'>alert('" & ddlLabel.Items(6).Text & "');</script>")
                            Else
                                Page.RegisterClientScriptBlock("FileDownActionJs", "<script language='javascript'>parent.hiddenbase.location.href='../../Common/WSaveTempFile.aspx?ModuleID=4&FileName=" & strFileName & "';</script>")
                            End If
                    End Select
                End If
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Initialize objBV object
            objBV.InterfaceLanguage = Session("InterfaceLanguage")
            objBV.DBServer = Session("DBServer")
            objBV.ConnectionString = Session("ConnectionString")
            objBV.Initialize()
            ' Initialize objBIO object
            objBIO.InterfaceLanguage = Session("InterfaceLanguage")
            objBIO.DBServer = Session("DBServer")
            objBIO.ConnectionString = Session("ConnectionString")
            objBIO.Initialize()
            ' Initialize objBPO object
            objBPO.InterfaceLanguage = Session("InterfaceLanguage")
            objBPO.DBServer = Session("DBServer")
            objBPO.ConnectionString = Session("ConnectionString")
            objBPO.Initialize()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            'btnPrint.Attributes.Add("OnClick", "javascript:self.focus();setTimeout('self.print()', 1);return(false);")
            btnEdit.Attributes.Add("OnClick", "javascript:self.location.href='WSendPOClaimAction.aspx';return(false);")
        End Sub

        ' GenClaimDate method
        Private Function GenClaimDate() As Metric
            Dim collecCollumHeader As New Collection
            'Dim objTvfont As New TVCOMLib.utf8
            Dim inti As Integer

            ' For Header and Footer data
            For inti = 0 To ddlHeaderFooter.Items.Count - 1
                Select Case ddlHeaderFooter.Items(inti).Value
                    Case "TITLE:UPPER"
                        'collecCollumHeader.Add(objTvfont.Upper(ddlHeaderFooter.Items(0).Text), ddlHeaderFooter.Items(inti).Value)
                        collecCollumHeader.Add(UCase(ddlHeaderFooter.Items(0).Text), ddlHeaderFooter.Items(inti).Value)
                    Case "TODAY"
                        collecCollumHeader.Add(Now, ddlHeaderFooter.Items(inti).Value)
                    Case "TODAY:DD"
                        collecCollumHeader.Add(Day(Now), ddlHeaderFooter.Items(inti).Value)
                    Case "TODAY:MM"
                        collecCollumHeader.Add(Month(Now), ddlHeaderFooter.Items(inti).Value)
                    Case "TODAY:YYYY"
                        collecCollumHeader.Add(Year(Now), ddlHeaderFooter.Items(inti).Value)
                    Case "TODAY:HH"
                        collecCollumHeader.Add(Hour(Now), ddlHeaderFooter.Items(inti).Value)
                    Case "TODAY:MI"
                        collecCollumHeader.Add(Minute(Now), ddlHeaderFooter.Items(inti).Value)
                    Case "TODAY:SS"
                        collecCollumHeader.Add(Second(Now), ddlHeaderFooter.Items(inti).Value)
                    Case Else
                        collecCollumHeader.Add(ddlHeaderFooter.Items(inti).Text, ddlHeaderFooter.Items(inti).Value)
                End Select
            Next

            ' For Collum title data
            For inti = 0 To ddlCollumCaption.Items.Count - 1
                collecCollumHeader.Add(ddlCollumCaption.Items(inti).Text, ddlCollumCaption.Items(inti).Value)
            Next
            ' Call gen claim data here
            GenClaimDate = objBPO.GenPOClaim(hdPOID.Value, hdTemplateID.Value, hdUbound.Value, collecCollumHeader)
            'If Not objTvfont Is Nothing Then
            '    objTvfont = Nothing
            'End If
        End Function

        ' Send email method
        ' In: objMetric
        ' Out: boolean
        Private Function SendEmail(ByVal objMetric As Metric) As Boolean
            Dim inti As Integer
            Dim intSuccess As Integer

            For inti = LBound(objMetric.objEmail) To UBound(objMetric.objEmail)
                If Not objMetric.objEmail(inti) & "" = "" Then
                    intSuccess = SendMail(ddlLabel.Items(6).Text, objMetric.objData(inti), objMetric.objEmail(inti), True)
                    If intSuccess = 1 Then
                        SendEmail = True
                    Else
                        SendEmail = False
                    End If
                End If
            Next
        End Function

        ' Visiable controls method
        Private Sub VisiableControls(ByVal boolValue As Boolean)
            btnEdit.Visible = boolValue
            btnSaveToFile.Visible = boolValue
            btnPrint.Visible = boolValue
            btnEmail.Visible = boolValue
        End Sub

        Private Sub btnEmail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEmail.Click
            objMetric = Session("Metric")
            If SendEmail(objMetric) = True Then
                Page.RegisterClientScriptBlock("SendEmailSuccessfulJs", "<script language='javascript'>alert('" & ddlLabel.Items(2).Text & "');</script>")
            Else
                Page.RegisterClientScriptBlock("SendEmailUnSuccessfulJs", "<script language='javascript'>alert('" & ddlLabel.Items(3).Text & "');</script>")
            End If
        End Sub

        Private Sub btnSaveToFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveToFile.Click
            Dim strFileName As String
            VisiableControls(False)
            strFileName = objBIO.SaveToFile(lblDisplay.Text, "doc", True, Server.MapPath("../.."))
            If objBIO.ErrorMsg <> "" Then
                Page.RegisterClientScriptBlock("ErrrExportJs1", "<script language='javascript'>alert('" & ddlLabel.Items(7).Text & "');</script>")
            Else
                Page.RegisterClientScriptBlock("FileDownActionJs1", "<script language='javascript'>parent.hiddenbase.location.href='../../Common/WSaveTempFile.aspx?ModuleID=4&FileName=" & strFileName & "';</script>")
            End If
        End Sub
        Private Sub Print_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
            VisiableControls(False)
            Page.RegisterClientScriptBlock("PrintActionJs", "<script language='javascript'>self.focus();setTimeout('self.print()', 1);</script>")
        End Sub

        ' Page_Unload method
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBV Is Nothing Then
                objBV.Dispose(True)
                objBV = Nothing
            End If
            If Not objBIO Is Nothing Then
                objBIO.Dispose(True)
                objBIO = Nothing
            End If
            If Not objBPO Is Nothing Then
                objBPO.Dispose(True)
                objBPO = Nothing
            End If
        End Sub


    End Class
End Namespace