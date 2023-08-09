' Class: WPreviewTemplate
' Puspose: Preview Claim template
' Creator: Oanhtn
' CreatedDate: 21/09/2004
' Modification history:
'   + 20/10/2004 by Sondp: PreviewTemplate

Imports eMicLibAdmin.BusinessRules.Serial
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WPreviewTemplate
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents tblPreview As System.Web.UI.HtmlControls.HtmlTable


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBClaimTemplate As New clsBClaimTemplate
        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            If Not Page.IsPostBack Then
                Call SetData()
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()

            'Init objBClaimTemplate object
            objBClaimTemplate.ConnectionString = Session("ConnectionString")
            objBClaimTemplate.InterfaceLanguage = Session("InterfaceLanguage")
            objBClaimTemplate.DBServer = Session("DBServer")
            objBClaimTemplate.Initialize()
            btnClose.Attributes.Add("OnClick", "javascript:self.close();")

        End Sub

        ' SetData for Header, Body, Footer and call GenClaimTemplate() method
        Private Sub SetData()
            Dim inti As Integer
            ' Get submit Information
            objBClaimTemplate.Header = Request("txtHeader").Replace("&lt;", "<").Replace("&gt;", ">")
            objBClaimTemplate.PageHeader = Request("txtPageHeader").Replace("&lt;", "<").Replace("&gt;", ">")
            objBClaimTemplate.Collums = Request("hidCollum").Replace("&lt;", "<").Replace("&gt;", ">")
            objBClaimTemplate.CollumCaption = Request("txtCollumCaption").Replace("&lt;", "<").Replace("&gt;", ">")
            objBClaimTemplate.CollumWidth = Request("txtCollumWidth").Replace("&lt;", "<").Replace("&gt;", ">")
            objBClaimTemplate.CollumAlign = Request("txtAlign").Replace("&lt;", "<").Replace("&gt;", ">")
            objBClaimTemplate.CollumFormat = Request("txtFormat").Replace("&lt;", "<").Replace("&gt;", ">")
            objBClaimTemplate.TableColor = Request("txtTableColor").Replace("&lt;", "<").Replace("&gt;", ">")
            objBClaimTemplate.OddColor = Request("txtOddColor").Replace("&lt;", "<").Replace("&gt;", ">")
            objBClaimTemplate.EventColor = Request("txtEventColor").Replace("&lt;", "<").Replace("&gt;", ">")
            objBClaimTemplate.PageFooter = Request("txtPageFooter").Replace("&lt;", "<").Replace("&gt;", ">")
            objBClaimTemplate.Footer = Request("txtFooter").Replace("&lt;", "<").Replace("&gt;", ">")
            ' Template Header and Footer
            For inti = 0 To ddlHeaderFooter.Items.Count - 1
                Select Case ddlHeaderFooter.Items(inti).Value
                    Case "TODAY"
                        objBClaimTemplate.HeaderData.Add(Day(Now) & "/" & Month(Now) & "/" & Year(Now), ddlHeaderFooter.Items(inti).Value)
                    Case "TODAY:DD"
                        objBClaimTemplate.HeaderData.Add(Day(Now), ddlHeaderFooter.Items(inti).Value)
                    Case "TODAY:MM"
                        objBClaimTemplate.HeaderData.Add(Month(Now), ddlHeaderFooter.Items(inti).Value)
                    Case "TODAY:YYYY"
                        objBClaimTemplate.HeaderData.Add(Year(Now), ddlHeaderFooter.Items(inti).Value)
                    Case "TODAY:YY"
                        objBClaimTemplate.HeaderData.Add(Right(CStr(Year(Now)), 2), ddlHeaderFooter.Items(inti).Value)
                    Case "TODAY:HH"
                        objBClaimTemplate.HeaderData.Add(Hour(Now), ddlHeaderFooter.Items(inti).Value)
                    Case "TODAY:MI"
                        objBClaimTemplate.HeaderData.Add(Minute(Now), ddlHeaderFooter.Items(inti).Value)
                    Case "TODAY:SS"
                        objBClaimTemplate.HeaderData.Add(Second(Now), ddlHeaderFooter.Items(inti).Value)
                    Case Else
                        objBClaimTemplate.HeaderData.Add(ddlHeaderFooter.Items(inti).Text, ddlHeaderFooter.Items(inti).Value)
                End Select
            Next
            ' Column title
            For inti = 0 To ddlCollum.Items.Count - 1
                objBClaimTemplate.ColumnTitle.Add(ddlCollum.Items(inti).Text, ddlCollum.Items(inti).Value)
            Next
            ' Table data
            For inti = 0 To ddlData.Items.Count - 1
                objBClaimTemplate.ContentData.Add(ddlData.Items(inti).Text, ddlData.Items(inti).Value)
            Next
            ' Display ClaimTemplate
            lblOutMsg.Text = objBClaimTemplate.GenClaimTemplate
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBClaimTemplate Is Nothing Then
                    objBClaimTemplate.Dispose(True)
                    objBClaimTemplate = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace