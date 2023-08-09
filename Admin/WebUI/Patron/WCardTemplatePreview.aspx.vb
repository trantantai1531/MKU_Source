' Class: WCardTemplatePreview
' Puspose: preview patron card
' Creator: Sondp
' CreatedDate: 21-1-2005
' Modification History:
'   - 25/04/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Patron
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WCardTemplatePreview
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
        Private objBCSP As New clsBCommonStringProc
        Private objBPC As New clsBPatronCollection
        Private objBCChart As New clsBCommonChart

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call PreviewCardTemplate()
        End Sub

        ' Method: Initialize
        Private Sub Initialize()
            ' Initialize objBPC object
            objBPC.DBServer = Session("DBServer")
            objBPC.ConnectionString = Session("ConnectionString")
            objBPC.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPC.initialize()

            ' Initialize objBCSP object
            objBCSP.DBServer = Session("DBServer")
            objBCSP.ConnectionString = Session("ConnectionString")
            objBCSP.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCSP.Initialize()

            ' Initialize objBCChart object
            objBCChart.DBServer = Session("DBServer")
            objBCChart.ConnectionString = Session("ConnectionString")
            objBCChart.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCChart.Initialize()

            ' BindScript
            btnClose.Attributes.Add("OnClick", "javascript:self.close();return(false);")
        End Sub

        ' Method: PreviewCardTemplate
        ' Purpose: Preview Patron Card Template
        Private Sub PreviewCardTemplate()
            If Not Request("fckContent") & "" = "" Then
                Dim objStream As New Object
                Dim strContent As String = Request("fckContent").Trim
                For inti = 0 To ddlContent.Items.Count - 1
                    Select Case ddlContent.Items(inti).Value
                        Case "NAME"
                            strContent = Replace(strContent, "&amp;lt;$NAME$&amp;gt;", ddlContent.Items(inti).Text)
                        Case "CODE"
                            strContent = Replace(strContent, "&amp;lt;$CODE$&amp;gt;", ddlContent.Items(inti).Text)
                        Case "DOB"
                            strContent = Replace(strContent, "&amp;lt;$DOB$&amp;gt;", ddlContent.Items(inti).Text)
                        Case "OCCUPATION"
                            strContent = Replace(strContent, "&amp;lt;$OCCUPATION$&amp;gt;", ddlContent.Items(inti).Text)
                        Case "WORKPLACE"
                            strContent = Replace(strContent, "&amp;lt;$WORKPLACE$&amp;gt;", ddlContent.Items(inti).Text)
                        Case "ADDRESS"
                            strContent = Replace(strContent, "&amp;lt;$ADDRESS$&amp;gt;", ddlContent.Items(inti).Text)
                        Case "TELEPHONE"
                            strContent = Replace(strContent, "&amp;lt;$TELEPHONE$&amp;gt;", ddlContent.Items(inti).Text)
                        Case "GRADE"
                            strContent = Replace(strContent, "&amp;lt;$GRADE$&amp;gt;", ddlContent.Items(inti).Text)
                        Case "CLASS"
                            strContent = Replace(strContent, "&amp;lt;$CLASS$&amp;gt;", ddlContent.Items(inti).Text)
                        Case "FACULTY"
                            strContent = Replace(strContent, "&amp;lt;$FACULTY$&amp;gt;", ddlContent.Items(inti).Text)
                        Case "CARDVALIDDATE"
                            strContent = Replace(strContent, "&amp;lt;$CARDVALIDDATE$&amp;gt;", ddlContent.Items(inti).Text)
                        Case "CARDEXPIREDDATE"
                            strContent = Replace(strContent, "&amp;lt;$CARDEXPIREDDATE$&amp;gt;", ddlContent.Items(inti).Text)
                        Case "EMAIL"
                            strContent = Replace(strContent, "&amp;lt;$EMAIL$&amp;gt;", ddlContent.Items(inti).Text)
                        Case "ETHINIC"
                            strContent = Replace(strContent, "&amp;lt;$ETHINIC$&amp;gt;", ddlContent.Items(inti).Text)
                        Case "BARCODE"
                            Dim ArrStrData(0) As String
                            ArrStrData(0) = ddlContent.Items(inti).Text
                            Dim arrImg() As Object
                            objBCChart.MakeImgBarcode(ArrStrData, objBCChart.objImageType.Png, 120, 30, objBCChart.objBarcodeType.CODE93, "", "", "", 0)
                            Session("bc" & CStr(inti)) = Nothing
                            arrImg = objBCChart.BarCodeImg()
                            If UBound(arrImg) >= 0 Then
                                Session("bc" & CStr(inti)) = arrImg(0)
                            End If
                            Session("ImgType") = 1
                            strContent = Replace(strContent, "&amp;lt;$BARCODE$&amp;gt;", "../Common/WPrintBarCode.aspx?i=" & inti)
                            Session("ImgType") = Nothing
                        Case "PICTURE"
                            strContent = Replace(strContent, "&amp;lt;$PICTURE$&amp;gt;", ddlContent.Items(inti).Text)
                        Case Else
                    End Select
                Next
                strContent = strContent.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">")
                lblPreview.Text = strContent

                'Dim objTemplate As New TVCOMLib.LibolTemplate
                'Dim Fields As New Object
                'Dim objData() As Object
                'Dim objStream As New Object
                'Dim collecContent As New Collection
                'Dim inti As Integer
                'ReDim objData(0)

                'For inti = 0 To ddlContent.Items.Count - 1
                '    collecContent.Add(ddlContent.Items(inti).Text, ddlContent.Items(inti).Value)
                'Next
                'objTemplate.Template = objBCSP.ToUTF8(Request("fckContent").Trim.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">")) 'objBCSP.ToUTF8(Request("fckContent").Replace("&lt;", "<").Replace("&gt;", ">"))
                'Fields = objTemplate.Fields
                'ReDim objData(UBound(Fields))
                'For inti = LBound(Fields) To UBound(Fields)
                '    Select Case UCase(Fields(inti))
                '        Case "BARCODE"
                '            Dim ArrRet As New Object
                '            Dim ArrStrData(0) As String
                '            Dim arrImg() As Object
                '            ArrStrData(0) = collecContent.Item("BARCODE")
                '            objBCChart.MakeImgBarcode(ArrStrData, objBCChart.objImageType.Png, 120, 30, objBCChart.objBarcodeType.CODE93, "", "", "", 0)
                '            Session("bc" & CStr(inti)) = Nothing
                '            arrImg = objBCChart.BarCodeImg()
                '            If UBound(arrImg) >= 0 Then
                '                Session("bc" & CStr(inti)) = arrImg(0)
                '            End If
                '            Session("ImgType") = 1
                '            objData(inti) = "../Common/WPrintBarCode.aspx?i=" & inti
                '            Session("ImgType") = Nothing
                '        Case Else
                '            Try
                '                objData(inti) = objBCSP.ToUTF8(collecContent.Item(UCase(Fields(inti)))) & Chr(9)
                '            Catch ex As Exception
                '                objData(inti) = "" & Chr(9)
                '            End Try
                '    End Select
                'Next
                'objStream = objBCSP.ToUTF8Back(objTemplate.Generate(objData).ToString)
                'lblPreview.Text = objStream
                'objTemplate = Nothing
                'collecContent = Nothing
            End If
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBPC Is Nothing Then
                objBPC.Dispose(True)
                objBPC = Nothing
            End If
            If Not objBCSP Is Nothing Then
                objBCSP.Dispose(True)
                objBCSP = Nothing
            End If
            If Not objBCChart Is Nothing Then
                objBCChart.Dispose(True)
                objBCChart = Nothing
            End If
        End Sub
    End Class
End Namespace