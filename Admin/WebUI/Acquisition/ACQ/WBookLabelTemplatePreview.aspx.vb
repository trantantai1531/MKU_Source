' class 
' Puspose:View BookLabelTemplate
' Creator: Sondp
' CreatedDate: 20/02/2005
' Modification History:

Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WBookLabelTemplatePreview
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

        Private objBT As New clsBTemplate
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                lblDisplay.Text = GenBookLabel(Request("fckContent"))
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

        ' BindScript method
        Private Sub BindScript()
            btnClose.Attributes.Add("OnClick", "javascript:self.close();return(false);")
        End Sub

        ' GenBookLabel method
        ' In: strContent
        Private Function GenBookLabel(ByVal strContent As String) As String
            Dim collecData As New Collection
            Dim inti As Integer
            GenBookLabel = ""
            Try
                'strContent = strContent.Replace("&lt;", "<").Replace("&gt;", ">").Replace("'", "")

                '---Thay the bang editor
                strContent = strContent.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("'", "")
                '---
                ' Init some value in objBCT object
                For inti = 0 To ddlBookLabelTemplate.Items.Count - 1
                    Select Case ddlBookLabelTemplate.Items(inti).Value
                        Case "curday"
                            collecData.Add(Now, ddlBookLabelTemplate.Items(inti).Value)
                        Case "curmonth"
                            collecData.Add(Month(Now), ddlBookLabelTemplate.Items(inti).Value)
                        Case "curyear"
                            collecData.Add(Year(Now), ddlBookLabelTemplate.Items(inti).Value)
                        Case Else
                            collecData.Add(ddlBookLabelTemplate.Items(inti).Text, ddlBookLabelTemplate.Items(inti).Value)
                    End Select
                Next
                GenBookLabel = objBT.GenBookLabelTemplate(strContent, collecData)
            Catch ex As Exception
                Response.Write(ex.Message)
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