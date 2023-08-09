' class 
' Puspose: Manager send po
' Creator: Sondp
' CreatedDate: 21/03/2005
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
    Partial Class WSendPO
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
        Private objBPO As New clsBPurchaseOrder

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
            hidAction.Value = ""
            If Not Page.IsPostBack Then
                Dim objMetric As New Metric
                hdIDs.Value = Request("hdIDs")
                hdTemplate.Value = Request("ddlTemplate")
                objMetric = GenSendPO()
                If Not objMetric.Equals(Nothing) Then
                    Session("Metric") = objMetric
                    Select Case UCase(Request.QueryString("Flage")) & ""
                        Case "PRINT"
                            lblDisplay.Text = Preview(objMetric, True)
                            Page.RegisterClientScriptBlock("PrintActionJs", "<script language='javascript'>self.focus();setTimeout('self.print()', 1);</script>")
                        Case "FILE"
                            Dim strFileName As String
                            strFileName = objBIO.SaveToFile(Preview(objMetric, True), "doc", True, Server.MapPath("../.."))
                            If objBIO.ErrorMsg <> "" Then
                                Page.RegisterClientScriptBlock("ErrrExportJs", "<script language='javascript'>alert('" & ddlLabel.Items(7).Text & "');</script>")
                            Else
                                hidNameFile.Value = strFileName
                                hidAction.Value = "FILE"
                                lblDisplay.Text = Preview(objMetric, True)
                                lblDownload1.Visible = True
                                lblDownload2.Visible = True
                                lnkGetIt.Visible = True
                                lnkGetIt.Attributes.Add("OnClick", "parent.hiddenbase.location.href='../../Common/WSaveTempFile.aspx?ModuleID=4&FileName=" & strFileName & "';return false;")
                                lnkGetIt.NavigateUrl = "#"
                            End If
                        Case "EMAIL"
                            If SendEmail(objMetric) = True Then
                                Page.RegisterClientScriptBlock("SendEmailSuccessfulJs", "<script language='javascript'>alert('" & ddlLabel.Items(2).Text & "');</script>")
                            Else
                                Page.RegisterClientScriptBlock("SendEmailUnSuccessfulJs", "<script language='javascript'>alert('" & ddlLabel.Items(3).Text & "');</script>")
                            End If
                            hidAction.Value = "EMAIL"
                        Case "PREVIEW"
                            lblDisplay.Text = Preview(objMetric, False)
                        Case Else
                            lblDisplay.Text = Preview(objMetric, True)
                    End Select
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
            ' Initialize objBPO object
            objBPO.InterfaceLanguage = Session("InterfaceLanguage")
            objBPO.DBServer = Session("DBServer")
            objBPO.ConnectionString = Session("ConnectionString")
            objBPO.Initialize()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("WSendPOJs", "<script language='javascript' src='../Js/PO/WSendPO.js'></script>")
        End Sub

        ' Initdata method
        Private Sub InitData()
            Dim collecHeaderFooter As New Collection
            Dim collecCollumCaption As New Collection
            Dim inti As Integer
            ' For Header and Footer data
            For inti = 0 To ddlHeaderFooter.Items.Count - 1
                Select Case ddlHeaderFooter.Items(inti).Value
                    Case "TODAY"
                        collecHeaderFooter.Add(Now, ddlHeaderFooter.Items(inti).Value)
                    Case "TODAY:DD"
                        collecHeaderFooter.Add(Day(Now), ddlHeaderFooter.Items(inti).Value)
                    Case "TODAY:MM"
                        collecHeaderFooter.Add(Month(Now), ddlHeaderFooter.Items(inti).Value)
                    Case "TODAY:YYYY"
                        collecHeaderFooter.Add(Year(Now), ddlHeaderFooter.Items(inti).Value)
                    Case "TODAY:HH"
                        collecHeaderFooter.Add(Hour(Now), ddlHeaderFooter.Items(inti).Value)
                    Case "TODAY:MI"
                        collecHeaderFooter.Add(Minute(Now), ddlHeaderFooter.Items(inti).Value)
                    Case "TODAY:SS"
                        collecHeaderFooter.Add(Second(Now), ddlHeaderFooter.Items(inti).Value)
                    Case Else
                        collecHeaderFooter.Add(ddlHeaderFooter.Items(inti).Text, ddlHeaderFooter.Items(inti).Value)
                End Select
            Next
            For inti = 0 To ddlCollumCaption.Items.Count - 1
                collecCollumCaption.Add(ddlCollumCaption.Items(inti).Text, ddlCollumCaption.Items(inti).Value)
            Next
            objBIO.CollumHeaderFooter = collecHeaderFooter
            objBIO.CollumTitle = collecCollumCaption
            objBIO.TemplateID = Request("ddlTemplate")
        End Sub

        ' GenSendPO method
        ' In: some informations
        ' Out: string
        Private Function GenSendPO() As Metric
            Call InitData()
            GenSendPO = objBIO.GenSendPO(hdIDs.Value)
        End Function

        ' Preview method
        ' In: objMetric, boolPrint
        ' Out: string
        Private Function Preview(ByVal objMetric As Metric, Optional ByVal boolPrint As Boolean = False) As String
            Dim inti As Integer
            Dim strOutMsg As String
            strOutMsg = ""
            For inti = LBound(objMetric.objData) To UBound(objMetric.objData)
                strOutMsg = strOutMsg & objMetric.objData(inti)
                If boolPrint = False Then
                    ' Edit button
                    strOutMsg = strOutMsg & "<P><TABLE CELLPADDING=2 CELLSPACING=0 BORDER=0 WIDTH=100% ><TR><TD ALIGN=""CENTER""><input type=""button"" class='lbButton'  name=""btnModify" & inti & """  value=""" & ddlPad.Items(1).Text & """ id=""btnModify"" OnClick=""javascript: Action('Edit'," & inti & ")""/>&nbsp; "
                    ' Print button
                    strOutMsg = strOutMsg & "<input type=""button"" class='lbButton' name=""btnPrint" & inti & """ value=""" & ddlPad.Items(0).Text & """ id=""btnPrint"" OnClick=""javascript: Action('Print'," & inti & ")""/>&nbsp;"
                    ' Send email button
                    strOutMsg = strOutMsg & "<input type=""button""  class='lbButton' name=""btnSendEmail" & inti & """ value=""" & ddlPad.Items(2).Text & """ id=""btnSendEmail"" OnClick=""Action('Email'," & inti & ")""/>&nbsp;</TD></TR></TABLE><P>"
                End If
            Next
            Preview = strOutMsg
        End Function

        ' Send email method
        ' In: objMetric
        ' Out: boolean
        Private Function SendEmail(ByVal objMetric As Metric) As Boolean
            Dim inti As Integer
            Dim intSuccess As Integer

            Call ChangePOStatus(hdIDs.Value, Request.QueryString("ChangeStatus"))
            For inti = LBound(objMetric.objEmail) To UBound(objMetric.objEmail)
                If Not objMetric.objEmail(inti) & "" = "" Then
                    intSuccess = SendMail(ddlLabel.Items(4).Text, objMetric.objData(inti), objMetric.objEmail(inti), True)
                    If intSuccess = 1 Then
                        SendEmail = True
                    Else
                        SendEmail = False
                    End If
                End If
            Next
        End Function

        ' Change PO Status method
        ' Purpose: Change PO status
        ' Input: POIDs, StatusID
        Public Sub ChangePOStatus(ByVal strPOIDs As String, ByVal intStatusID As Integer)

            If hdIDs.Value.Contains(",") Then
                Dim listID = hdIDs.Value.Split(",")
                For Each item As String In listID
                    objBPO.AcqPOID = item
                    objBPO.StatusID = intStatusID
                    objBPO.ChangePOStatus(strPOIDs)
                Next
            Else
                objBPO.AcqPOID = hdIDs.Value
                objBPO.StatusID = intStatusID
                objBPO.ChangePOStatus(strPOIDs)
            End If
            
           
        End Sub

        ' Page_Unload method
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
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