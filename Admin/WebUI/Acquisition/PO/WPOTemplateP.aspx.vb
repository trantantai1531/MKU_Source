' Class: WPOTemplateP
' Puspose: Preview template
' Creator: Sondp
' CreatedDate: 10/03/2005
' Modification History:
'   - 08/06/2005 by oanhtn: fix error

Imports eMicLibAdmin.BusinessRules.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WPOTemplateP
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

        ' Declare variables
        Private objBT As New clsBTemplate

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            If Not Page.IsPostBack Then
                If Not Request.QueryString("TemplateType") & "" = "" Then
                    hdTemplateType.Value = Request.QueryString("TemplateType")
                    Call InitializeData()
                    lblPageHeader.Text = Replace(Replace(Request("txtPageHeader"), "&lt;", "<"), "&gt;", ">")
                    lblDisplay.Text = objBT.GenPOTemplate(Request.QueryString("TemplateType"))
                    lblPageFooter.Text = Replace(Replace(Request("txtPageFooter"), "&lt;", "<"), "&gt;", ">")
                End If
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

            btnClose.Attributes.Add("OnClick", "self.close();return(false);")
        End Sub

        ' Method: Initialize
        ' Purpose: Initialize data method
        Private Sub InitializeData()
            Dim collecCollumTitle As New Collection
            Dim collecCollumData As New Collection
            Dim collecHeaderFooter As New Collection
            'Dim objSort As New TVCOMLib.utf8
            Dim inti As Integer

            ' For CollumTitle(s)
            For inti = 0 To ddlCollumTitle.Items.Count - 1
                collecCollumTitle.Add(ddlCollumTitle.Items(inti).Text, ddlCollumTitle.Items(inti).Value)
            Next
            ' For CollumData
            For inti = 0 To ddlCollumData.Items.Count - 1
                Select Case ddlCollumData.Items(inti).Value
                    Case "<$VALDSUBSCRIBEDDATE$>"
                        collecCollumData.Add(Now, ddlCollumData.Items(inti).Value)
                    Case "<$EXPIRESUBSCRIBEDDATE$>"
                        collecCollumData.Add(Day(Now) & "/" & Month(Now) & "/" & Year(Now) + 1, ddlCollumData.Items(inti).Value)
                    Case Else
                        collecCollumData.Add(ddlCollumData.Items(inti).Text, ddlCollumData.Items(inti).Value)
                End Select
            Next
            ' For CollumHeaderFooter data
            For inti = 0 To ddlHeaderFooterData.Items.Count - 1
                Select Case ddlHeaderFooterData.Items(inti).Value
                    Case "TITLE:UPPER"
                        'collecHeaderFooter.Add(objSort.Upper(ddlHeaderFooterData.Items(inti).Text), ddlHeaderFooterData.Items(inti).Value)
                        collecHeaderFooter.Add(UCase(ddlHeaderFooterData.Items(inti).Text), ddlHeaderFooterData.Items(inti).Value)
                    Case "TODAY"
                        collecHeaderFooter.Add(Now, ddlHeaderFooterData.Items(inti).Value)
                    Case "TODAY:DD"
                        collecHeaderFooter.Add(Day(Now), ddlHeaderFooterData.Items(inti).Value)
                    Case "TODAY:MM"
                        collecHeaderFooter.Add(Month(Now), ddlHeaderFooterData.Items(inti).Value)
                    Case "TODAY:YYYY"
                        collecHeaderFooter.Add(Year(Now), ddlHeaderFooterData.Items(inti).Value)
                    Case "TODAY:HH"
                        collecHeaderFooter.Add(Hour(Now), ddlHeaderFooterData.Items(inti).Value)
                    Case "TODAY:MI"
                        collecHeaderFooter.Add(Minute(Now), ddlHeaderFooterData.Items(inti).Value)
                    Case "TODAY:SS"
                        collecHeaderFooter.Add(Second(Now), ddlHeaderFooterData.Items(inti).Value)
                    Case "CONTRACTVALIDDATE"
                        collecHeaderFooter.Add(Now, ddlHeaderFooterData.Items(inti).Value)
                    Case "CONTRACTEXPIREDDATE"
                        collecHeaderFooter.Add(Day(Now) & "/" & Month(Now) & "/" & Year(Now) + 1, ddlHeaderFooterData.Items(inti).Value)
                    Case Else
                        collecHeaderFooter.Add(ddlHeaderFooterData.Items(inti).Text, ddlHeaderFooterData.Items(inti).Value)
                End Select
            Next
            objBT.CollumsTitle = collecCollumTitle
            objBT.CollumsData = collecCollumData
            objBT.HeaderFooter = collecHeaderFooter
            objBT.Header = Replace(Replace(Request("txtHeader"), "&lt;", "<"), "&gt;", ">")
            objBT.PageHeader = Replace(Replace(Request("txtPageHeader"), "&lt;", "<"), "&gt;", ">")
            objBT.Collum = Replace(Replace(Request("txtCollum"), "&lt;", "<"), "&gt;", ">")
            objBT.CollumCaption = Replace(Replace(Request("txtCollumCaption"), "&lt;", "<"), "&gt;", ">")
            objBT.CollumWidth = Replace(Replace(Request("txtCollumWidth"), "&lt;", "<"), "&gt;", ">")
            objBT.CollumAlign = Replace(Replace(Request("txtAlign"), "&lt;", "<"), "&gt;", ">")
            objBT.CollumFormat = Replace(Replace(Request("txtFormat"), "&lt;", "<"), "&gt;", ">")
            objBT.TableColor = Replace(Replace(Request("txtTableColor"), "&lt;", "<"), "&gt;", ">")
            objBT.OddColor = Replace(Replace(Request("txtOddColor"), "&lt;", "<"), "&gt;", ">")
            objBT.EventColor = Replace(Replace(Request("txtEventColor"), "&lt;", "<"), "&gt;", ">")
            objBT.PageFooter = Replace(Replace(Request("txtPageFooter"), "&lt;", "<"), "&gt;", ">")
            objBT.Footer = Replace(Replace(Request("txtFooter"), "&lt;", "<"), "&gt;", ">")
            'If Not objSort Is Nothing Then
            '    objSort = Nothing
            'End If
        End Sub

        ' Page_Unload method
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose()
        End Sub
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBT Is Nothing Then
                    objBT.Dispose(True)
                    objBT = Nothing
                End If
            Catch ex As Exception
            End Try
        End Sub
    End Class
End Namespace