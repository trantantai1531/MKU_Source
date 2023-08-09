' Class: WPreviewTemplate
' Puspose: All puspose for ILL Template
' Creator: Sondp
' CreatedDate: 25/11/2004
' Modification History:
'   - 24/04/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.ILL

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WPreviewTemplate
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
        Private objBILLTemplate As New clsBILLTemplate

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindData()
            Call BindJS()
        End Sub

        ' Method: Initialize
        ' Purpose: Init all need objects
        Private Sub Initialize()
            ' Initialize objBILLTemplate object
            objBILLTemplate.ConnectionString = Session("ConnectionString")
            objBILLTemplate.InterfaceLanguage = Session("InterfaceLanguage")
            objBILLTemplate.DBServer = Session("DBServer")
            Call objBILLTemplate.Initialize()
        End Sub

        ' Method: BindJS
        ' Purpose: Include all need js functions
        Private Sub BindJS()
            btnClose.Attributes.Add("OnClick", "javascript:self.close(); return false;")
        End Sub

        ' Method: BindData
        ' Purpose: Show data
        Private Sub BindData()
            Dim arrTextField() As String
            Dim arrValueField() As String
            Dim collectionContent As New Collection
            Dim inti As Integer

            Try
                'arrTextField = Split(lblContentDataText.Text, ",")
                arrTextField = Split(lblContentData.Text, ",")
                arrValueField = Split(lblContentDataValue.Text, ",")
                For inti = 0 To UBound(arrValueField)
                    collectionContent.Add(arrTextField(inti), arrValueField(inti))
                Next
                objBILLTemplate.ContentData = collectionContent
                objBILLTemplate.Title = Request("txtCaption").Replace("&lt;", "<").Replace("&gt;", ">")
                objBILLTemplate.Content = Request("txtContent").Replace("&lt;", "<").Replace("&gt;", ">")

                Select Case Request("hdType")
                    Case "12" ' Pack template
                        lblMainTitle.Text = lblPackTemplate.Text
                    Case "13" ' Denied template
                        lblMainTitle.Text = lblDeniedTemplate.Text
                    Case "14" ' Notice template
                        lblMainTitle.Text = lblNoticeTemplate.Text
                    Case "16" ' Overdue template                
                        lblMainTitle.Text = lblOverdueTemplate.Text
                End Select
                lblOutMsg.Text = objBILLTemplate.GenILLTemplate(Request("hdType"))

                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBILLTemplate.ErrorMsg, ddlLabel.Items(0).Text, objBILLTemplate.ErrorCode)
            Finally
                collectionContent = Nothing
            End Try
        End Sub

        ' Event: Page UnLoad
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBILLTemplate Is Nothing Then
                    objBILLTemplate.Dispose(True)
                    objBILLTemplate = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace