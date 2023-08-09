' class WLabelPrintDisplay
' Puspose: Display Label
' Creator: Sondp
' CreatedDate: 22/02/2005
' Modification History:

Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WLabelPrintDisplay
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents hdHagPage As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents hdColsPage As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents hdLibID As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents hdLocID As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents hdItemType As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents hdMaxPage As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents hdTemplateID As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents hdUbound As System.Web.UI.HtmlControls.HtmlInputHidden


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private objBT As New clsBTemplate
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            If Not Page.IsPostBack Then
                Dim lngStartID As Long
                Dim lngStopID As Long
                lngStartID = 0
                lngStopID = 0
                If Not Session("ItemIDs") Is Nothing And Not Session("IDs") Is Nothing Then
                    If Request.QueryString("CurrentPage") & "" = "" Then
                        lngStartID = 0
                        lngStopID = CLng(Session("ColPage") * Session("HagPage")) - 1
                    Else
                        If CInt(Request.QueryString("CurrentPage") > 0) Then
                            lngStartID = CLng(Request.QueryString("CurrentPage") - 1) * CLng(Session("ColPage") * Session("HagPage"))
                            lngStopID = CLng(Request.QueryString("CurrentPage")) * CLng(Session("ColPage")) * CLng(Session("HagPage")) - 1
                        Else
                            Exit Sub
                        End If
                    End If
                    lblDisplay.Text = objBT.PrintAcqLabel_DHKTTC(Session("IDs"), Session("ItemIDs"), Session("TemplateID"), Session("LibID"), Session("LocID"), Session("HagPage"), Session("ColPage"), lngStartID, lngStopID, Session("Ubound") - 1)
                    ' WriteLog
                    Call WriteLog(39, ddlLog.Items(0).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
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
        End Sub

        ' Page_Unload method
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBT Is Nothing Then
                objBT.Dispose(True)
                objBT = Nothing
            End If
        End Sub
    End Class
End Namespace