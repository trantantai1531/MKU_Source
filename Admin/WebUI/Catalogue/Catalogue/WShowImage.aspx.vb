' Class: WShowDetail
' Puspose: Show detail infor of edata
' Creator: Oanhtn
' CreatedDate: 06/01/2005
' Modification History:

Imports System.IO
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.Edeliv

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WShowImage
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

        Const intMAX_SIZE = 200
        Const intAX_JPEG = 3
        Private blnIsResized As Boolean
        'Private objImage As New GflAx193.GflAx
        Private dblNewWidth As Double
        Private dblNewHeight As Double
        Private strURL As String
        Private objBEData As New clsBEData

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call CheckFormPemission()
            Dim tblEdata As DataTable
            Response.ClearContent()
            Response.Expires = 0
            Response.ContentType = "image/jpeg"

            If IsNumeric(Request("FileID") & "") Then
                objBEData.FileIDs = Request("FileID")
                tblEdata = objBEData.GetGeneralInfor(7, 0, 0, 0)

                If Not tblEdata Is Nothing Then
                    If tblEdata.Rows.Count > 0 Then
                        strURL = tblEdata.Rows(0).Item("PhysicalPath").ToString.Trim
                    End If
                End If
            End If

            If Not strURL = "" Then
                If Not Request("ShowPic") & "" = "" Then
                    Call ShowImage()
                Else
                    Call ShowFirstFrame()
                End If
            End If
        End Sub

        ' Initialize method
        ' Purpose: Init all neccessary objects
        Public Sub Initialize()
            ' Init objBEData object
            objBEData.DBServer = Session("DBServer")
            objBEData.ConnectionString = Session("ConnectionString")
            objBEData.InterfaceLanguage = Session("InterfaceLanguage")
            objBEData.Initialize()
        End Sub

        ' CheckFormPemission method
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            If Not CheckPemission(166) Then
                Call WriteErrorMssg(ddlLabel.Items(0).Text)
            End If
        End Sub

        ' ShowImage method
        ' Purpose: show image in detail
        Private Sub ShowImage()
            ' Show image
            'With objImage
            '    .EnableLZW = True
            '    .LoadBitmap(strURL)
            '    dblNewWidth = .Width
            '    dblNewHeight = .Height

            '    blnIsResized = False
            '    If dblNewWidth > intMAX_SIZE Then
            '        blnIsResized = True
            '        dblNewWidth = intMAX_SIZE
            '        dblNewHeight = (dblNewWidth * .Height) / .Width
            '    End If
            '    If dblNewHeight > intMAX_SIZE Then
            '        blnIsResized = True
            '        dblNewWidth = (dblNewWidth * intMAX_SIZE) / dblNewHeight
            '        dblNewHeight = intMAX_SIZE
            '    End If

            '    If blnIsResized Then
            '        .Resize(dblNewWidth, dblNewHeight) 'Resize the picture
            '    End If
            '    .SaveFormat = intAX_JPEG
            '    Response.BinaryWrite(.SendBinary)
            'End With

            '' Release objects
            'objImage = Nothing
        End Sub

        ' ShowFirstFrame method
        ' Purpose: show first frame of the selected video clip
        Private Sub ShowFirstFrame()
            Dim objMediaProcessor
            objMediaProcessor = Server.CreateObject("COMobjectsNET.MediaProcessor")

            With objMediaProcessor
                .LoadFromFile(strURL)
                .SmoothFactor = 50
                .OptimizationOn = True
                .Quality = 70
                dblNewWidth = .Width
                dblNewHeight = .Height
                blnIsResized = False
                If .Width > 200 Then
                    blnIsResized = True
                    dblNewWidth = 200
                    dblNewHeight = Int((dblNewWidth * .Height) / .Width)
                End If
                If dblNewHeight > 200 Then
                    blnIsResized = True
                    dblNewWidth = Int((dblNewWidth * 200) / dblNewHeight)
                    dblNewHeight = 200
                End If
                If blnIsResized Then
                    .FastResize(dblNewWidth, dblNewHeight)
                End If
                Response.ContentType = "image/jpeg"
                Response.Clear()
                .SaveToASPDocumentAsJpeg()
            End With

            ' Release objects
            objMediaProcessor = Nothing
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBEData Is Nothing Then
                    objBEData.Dispose(True)
                    objBEData = Nothing
                End If
            Finally
                MyBase.Dispose()
                Call Dispose()
            End Try
        End Sub
    End Class
End Namespace