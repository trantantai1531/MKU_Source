' Class: WRasterImage
' Puspose: Show raster image
' Creator: Oanhtn
' CreatedDate: 25/08/2004
' Modification History:

Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.WebUI.Common

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WRasterImage
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

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Response.Expires = 0
            Response.ContentType = "image/jpeg"
            Dim strMapLoc As String = Server.MapPath(Request("map"))

            ' Display image
            Response.BinaryWrite(GetImageImage(strMapLoc))
        End Sub

        ' GetImageImage method
        ' Purpose: Get image information in binary format
        Private Function GetImageImage(ByVal MapLoc)
            'Dim imgImage As New GflAx193.GflAx
            'Dim dblNewWidth As Double
            'Dim dblNewHeight As Double

            'Const AX_JPEG = 3
            'With imgImage
            '    .EnableLZW = True
            '    .LoadBitmap(MapLoc)
            '    'If .Width > 240 Then
            '    '    dblNewWidth = 240
            '    '    dblNewHeight = (dblNewWidth * .Height) / .Width
            '    'End If
            '    'If dblNewHeight > 240 Then
            '    '    dblNewWidth = (dblNewWidth * 240) / dblNewHeight
            '    '    dblNewHeight = 240
            '    'End If
            '    dblNewWidth = 79
            '    dblNewHeight = (dblNewWidth * .Height) / .Width
            '    .Resize(dblNewWidth, dblNewHeight) 'Resize the pciture
            '    .SaveFormat = GflAx193.AX_SaveFormats.AX_JPEG
            '    GetImageImage = .SendBinary
            'End With
            'imgImage = Nothing
        End Function
    End Class
End Namespace