' Class: WCirculationTemplate
' Puspose: Management patron card template
' Creator: chuyenpt
' CreatedDate: 19/04/07
Imports eMicLibAdmin.BusinessRules.ILL

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WCirculationTemplatePreview
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

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            Call BindScript()
            Call CreateData()
        End Sub
        ' Initialize method
        ' Init all necessary objects
        Private Sub Initialize()
            ' Initialize objBILLTemplate object
            objBILLTemplate.ConnectionString = Session("ConnectionString")
            objBILLTemplate.InterfaceLanguage = Session("InterfaceLanguage")
            objBILLTemplate.DBServer = Session("DBServer")
            Call objBILLTemplate.Initialize()
        End Sub
        ' BindScript method
        ' Purpose: include some necessary javascript functions
        Private Sub BindScript()
            btnClose.Attributes.Add("OnClick", "javascript:self.close(); return(false);")
        End Sub

        ' Method: CreateData
        Private Sub CreateData()
            Dim arrTextField() As String
            Dim arrValueField() As String
            Dim collectionContent As New Collection
            Dim inti As Integer, intIndex As Integer
            Dim strContent As String, str1 As String, str2 As String

            If CInt(Request("hdType")) = 1 Then
                lblMainTitle.Text = ddlLabel.Items(2).Text
            Else
                lblMainTitle.Text = ddlLabel.Items(3).Text
            End If
            Try
                arrTextField = Split(lblContentData.Text, ",")
                arrValueField = Split(lblContentDataValue.Text, ",")
                For inti = 0 To UBound(arrValueField)
                    collectionContent.Add(arrTextField(inti), arrValueField(inti))
                Next
                strContent = Request("txtContent")
                intIndex = InStr(strContent, "&lt;$TITLE:")
                If intIndex > 0 Then
                    str1 = Left(strContent, intIndex + 9)
                    strContent = Right(strContent, Len(strContent) - intIndex)
                    intIndex = InStr(strContent, "$>")
                    str2 = Right(strContent, Len(strContent) - intIndex + 1)
                    strContent = str1 & str2
                End If
                intIndex = InStr(strContent, "&lt;~~>")
                If intIndex > 0 Then
                    str1 = Left(strContent, intIndex - 1)
                    str2 = Right(strContent, Len(strContent) - intIndex - 7)
                    strContent = str1 & str2
                End If
                intIndex = InStr(strContent, "&lt;~~>")

                If intIndex > 0 Then
                    str1 = Left(strContent, intIndex - 1)
                    str2 = Right(strContent, Len(strContent) - intIndex - 7)
                    strContent = str1 & str2
                End If

                objBILLTemplate.ContentData = collectionContent
                objBILLTemplate.Title = Request("txtTitle").Replace("&lt;", "<").Replace("&gt;", ">")
                objBILLTemplate.Content = strContent.Replace("&lt;", "<").Replace("&gt;", ">")
                Dim strHTMLResult As String = objBILLTemplate.GenILLTemplate(1)
                'Dim splitHTMLResult() As String = strHTMLResult.Split(New String() {"<hr/>"}, StringSplitOptions.None)
                'lblPreview.Text = splitHTMLResult(0).Replace("<$DETAILLOAN$>", splitHTMLResult(1))
                lblPreview.Text = strHTMLResult
            Finally
                collectionContent = Nothing
            End Try
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
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
