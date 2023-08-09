' Class: WEPTemplate
' Puspose: preview export template
' Creator: Sondp
' CreatedDate: 21-1-2005
' Modification History:
'   - 13/05/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Patron

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WEPTemplate
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
        Private objBPC As New clsBPatronCollection

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            Call GenerateExportTemplate()
        End Sub

        ' Method: Initialize
        Private Sub Initialize()
            ' Initialize objBPC object
            objBPC.DBServer = Session("DBServer")
            objBPC.ConnectionString = Session("ConnectionString")
            objBPC.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPC.initialize()
        End Sub

        ' Method: BindJS
        Private Sub BindJS()
            btnClose.Attributes.Add("OnClick", "self.close();return(false);")
        End Sub

        ' Preview Export Template method
        Private Sub GenerateExportTemplate()
            If Not Request("txtContent") & "" = "" Then
                Dim collecContent As New Collection
                Dim inti As Integer
                For inti = 0 To ddlInf.Items.Count - 1
                    collecContent.Add(ddlInf.Items(inti).Text, ddlInf.Items(inti).Value)
                Next
                lblDisplay.Text = objBPC.GenerateExImportTemplate(Request("txtContent"), collecContent)

                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPC.ErrorMsg, ddlLabel.Items(1).Text, objBPC.ErrorCode)
            End If
        End Sub

        ' Page_Unload method
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBPC Is Nothing Then
                objBPC.Dispose(True)
                objBPC = Nothing
            End If
        End Sub
    End Class
End Namespace