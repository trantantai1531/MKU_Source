' Class: WAcqReportTemplatePreview
' Puspose: Preview AcqTemplate
' Creator: Sondp
' CreatedDate: 20/02/2005
' Modification History:

Imports eMicLibAdmin.BusinessRules.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WAcqReportTemplatePreview
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents ddlData As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlCollum As System.Web.UI.WebControls.DropDownList


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBT As New clsBTemplate

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                lblDisplay.Text = GenACQReport(Request("txtHeader"), Request("txtPageHeader"), Request("txtCollum"), Request("txtCollumCaption"), Request("txtCollumWidth"), Request("txtAlign"), Request("txtFormat"), Request("txtTableColor"), Request("txtOddColor"), Request("txtEventColor"), Request("txtPageFooter"), Request("txtFooter"))
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: Init all need objects
        Private Sub Initialize()
            ' Initialize objBT object
            objBT.InterfaceLanguage = Session("InterfaceLanguage")
            objBT.DBServer = Session("DBServer")
            objBT.ConnectionString = Session("ConnectionString")
            Call objBT.Initialize()
        End Sub

        ' Method: BindJS
        Private Sub BindJS()
            btnClose.Attributes.Add("OnClick", "javascript:self.close();return(false);")
        End Sub

        ' Gen Report method
        ' In: Some infor
        ' Out: string
        ' Creator: Sondp
        Private Function GenACQReport(ByVal strHeader As String, ByVal strPageHeader As String, ByVal strCollum As String, ByVal strCollumCaption As String, ByVal strCollumWidth As String, ByVal strCollumAlign As String, ByVal strCollumFormat As String, ByVal strTableColor As String, ByVal strOddColor As String, ByVal strEventColor As String, ByVal strPageFooter As String, ByVal strFooter As String) As String
            Dim inti As Integer

            Try
                ' Initialize some objBT's collections
                ' Header and Footer
                For inti = 0 To ddlHeaderFooter.Items.Count - 1
                    Select Case ddlHeaderFooter.Items(inti).Value
                        Case "TODAY"
                            objBT.HeaderFooter.Add(Now, ddlHeaderFooter.Items(inti).Value)
                        Case "TODAY:DD"
                            objBT.HeaderFooter.Add(Day(Now), ddlHeaderFooter.Items(inti).Value)
                        Case "TODAY:MM"
                            objBT.HeaderFooter.Add(Month(Now), ddlHeaderFooter.Items(inti).Value)
                        Case "TODAY:YYYY"
                            objBT.HeaderFooter.Add(Year(Now), ddlHeaderFooter.Items(inti).Value)
                        Case "TODAY:HH"
                            objBT.HeaderFooter.Add(Hour(Now), ddlHeaderFooter.Items(inti).Value)
                        Case "TODAY:MI"
                            objBT.HeaderFooter.Add(Minute(Now), ddlHeaderFooter.Items(inti).Value)
                        Case "TODAY:SS"
                            objBT.HeaderFooter.Add(Second(Now), ddlHeaderFooter.Items(inti).Value)
                        Case Else
                            objBT.HeaderFooter.Add(ddlHeaderFooter.Items(inti).Text, ddlHeaderFooter.Items(inti).Value)
                    End Select
                Next
                ' Collums 
                For inti = 0 To ddlCollumsTitle.Items.Count - 1
                    objBT.CollumsTitle.Add(ddlCollumsTitle.Items(inti).Text, ddlCollumsTitle.Items(inti).Value)
                Next
                For inti = 0 To ddlCollumsData.Items.Count - 1
                    objBT.CollumsData.Add(ddlCollumsData.Items(inti).Text, ddlCollumsData.Items(inti).Value)
                Next
                objBT.Header = strHeader.Replace("&lt;", "<").Replace("&gt;", ">")
                lblPageHeader.Text = strPageHeader.Replace("&lt;", "<").Replace("&gt;", ">")
                objBT.PageHeader = strPageHeader.Replace("&lt;", "<").Replace("&gt;", ">")
                objBT.Collum = strCollum.Replace("&lt;", "<").Replace("&gt;", ">")
                objBT.CollumCaption = strCollumCaption.Replace("&lt;", "<").Replace("&gt;", ">")
                objBT.CollumWidth = strCollumWidth
                objBT.CollumAlign = strCollumAlign
                objBT.CollumFormat = strCollumFormat.Replace("&lt;", "<").Replace("&gt;", ">")
                objBT.TableColor = strTableColor
                objBT.OddColor = strOddColor
                objBT.EventColor = strEventColor
                lblPageFooter.Text = strPageFooter.Replace("&lt;", "<").Replace("&gt;", ">")
                objBT.PageFooter = strPageFooter.Replace("&lt;", "<").Replace("&gt;", ">")
                objBT.Footer = strFooter.Replace("&lt;", "<").Replace("&gt;", ">")
                GenACQReport = objBT.GenACQReport
            Catch ex As Exception
                Response.Write(ex.Message)
                GenACQReport = Nothing
            End Try
        End Function

        ' Page_Unload method
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBT Is Nothing Then
                objBT.Dispose(True)
                objBT = Nothing
            End If
        End Sub
    End Class
End Namespace