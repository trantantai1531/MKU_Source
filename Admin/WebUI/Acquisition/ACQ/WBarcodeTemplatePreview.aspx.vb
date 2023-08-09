' class WBarcodeTemplatePreview
' Puspose:View Barcode Template
' Creator: Sondp
' CreatedDate: 11/02/2006
' Modification History:

Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WBarcodeTemplatePreview
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

        Private objBCSP As New clsBCommonStringProc

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            btnClose.Attributes.Add("OnClick", "javascript:self.close();return(false);")
            If Not Page.IsPostBack AndAlso Request("txtContent") & "" <> "" Then
                lblDisplay.Text = GenBarCode(Request("txtContent"))
            End If
        End Sub
        ' Initialize method
        Private Sub Initialize()
            ' Initialize objBCSP object
            objBCSP.InterfaceLanguage = Session("InterfaceLanguage")
            objBCSP.DBServer = Session("DBServer")
            objBCSP.ConnectionString = Session("ConnectionString")
            objBCSP.Initialize()
        End Sub

        ' GenBookLabel method
        ' In: strContent
        Private Function GenBarCode(ByVal strContent As String) As String
            Dim strResult As String = ""
            Try
                For inti = 0 To ddlBarcodeTemplate.Items.Count - 1
                    Try
                        Select Case ddlBarcodeTemplate.Items(inti).Value
                            Case "COPYNUMBER"
                                strContent = Replace(strContent, "&lt;$COPYNUMBER$&gt;", ddlBarcodeTemplate.Items(inti).Text)
                            Case "ITEMCODE"
                                strContent = Replace(strContent, "&lt;$ITEMCODE$&gt;", ddlBarcodeTemplate.Items(inti).Text)
                            Case "SHELF"
                                strContent = Replace(strContent, "&lt;$SHELF$&gt;", ddlBarcodeTemplate.Items(inti).Text)
                        End Select
                    Catch ex As Exception
                        strContent = Replace(strContent, "&lt;$NOMATCH$&gt;", ddlBarcodeTemplate.Items(inti).Text)
                    End Try
                Next
                strContent = strContent.Replace("&lt;", "<").Replace("&gt;", ">")
            Catch ex As Exception
            End Try
            strResult = strContent
            Return strResult
            'Dim objTemplate As New TVCOMLib.LibolTemplate
            'Dim Fields As New Object
            'Dim objData() As Object
            'Dim objStream As New Object
            'Dim collecContent As New Collection
            'Dim inti As Integer
            'ReDim objData(0)

            'GenBarCode = ""
            'Try
            '    strContent = strContent.Replace("&lt;", "<").Replace("&gt;", ">")
            '    ' Init some value in objBCT object
            '    For inti = 0 To ddlBarcodeTemplate.Items.Count - 1
            '        collecContent.Add(ddlBarcodeTemplate.Items(inti).Text, ddlBarcodeTemplate.Items(inti).Value)
            '    Next
            '    objTemplate.Template = objBCSP.ToUTF8(strContent.Replace("&lt;", "<").Replace("&gt;", ">"))
            '    Fields = objTemplate.Fields
            '    ReDim objData(UBound(Fields))
            '    For inti = LBound(Fields) To UBound(Fields)
            '        Try
            '            objData(inti) = objBCSP.ToUTF8(collecContent.Item(UCase(Fields(inti))))
            '        Catch ex As Exception
            '            objData(inti) = objBCSP.ToUTF8(collecContent.Item("NOMATCH"))
            '        End Try
            '    Next
            '    objStream = objBCSP.ToUTF8Back(objTemplate.Generate(objData).ToString)
            '    GenBarCode = objStream
            'Catch ex As Exception
            '    Response.Write(ex.Message)
            'End Try
        End Function



        ' Page_Unload method
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBCSP Is Nothing Then
                objBCSP.Dispose(True)
                objBCSP = Nothing
            End If
        End Sub
    End Class
End Namespace