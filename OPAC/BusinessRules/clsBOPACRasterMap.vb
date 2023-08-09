
Imports System.Web
Imports System
Imports System.Math
Imports eMicLibOPAC.BusinessRules.Common

Namespace eMicLibOPAC.BusinessRules.OPAC
    Public Class clsBOPACRasterMap
        Inherits clsBBase

        '***************************************************************************************************
        '                                 DECLARE PRIVATE VARIABLES
        '***************************************************************************************************
        Private dblLastRotate As Double = 0
        Private dblLastWidth As Double = 0
        Private dblLastHeight As Double = 0
        Private dblLastX As Double = 0
        Private dblLastY As Double = 0
        Private dblLastZoom As Double = 0
        Private strURL As String = ""
        Private strMode As String = ""
        Private dblZoom As Double = 0
        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        'Dim imgImage As GflAx193.GflAx
        Dim imgImage As Object
        'Thay doi imgImage As GflAx193.GflAx --> imgImage As Object

        Const AX_JPEG = 3

        '***************************************************************************************************
        '                              END DECLARE PRIVATE VARIABLES
        '                               DECLARE PRIVATE PROPARTIES
        '***************************************************************************************************

        'Zoom Property
        Public Property Zoom() As Double
            Get
                Return dblZoom
            End Get
            Set(ByVal Value As Double)
                dblZoom = Value
            End Set
        End Property

        'LastX Property
        Public Property LastX() As Double
            Get
                Return dblLastX
            End Get
            Set(ByVal Value As Double)
                dblLastX = Value
            End Set
        End Property

        'LastY Property
        Public Property LastY() As Double
            Get
                Return dblLastY
            End Get
            Set(ByVal Value As Double)
                dblLastY = Value
            End Set
        End Property

        'LastRotate Property
        Public Property LastRotate() As Double
            Get
                Return dblLastRotate
            End Get
            Set(ByVal Value As Double)
                dblLastRotate = Value
            End Set
        End Property
        'LastLastWidth Property
        Public Property LastWidth() As Double
            Get
                Return dblLastWidth
            End Get
            Set(ByVal Value As Double)
                dblLastWidth = Value
            End Set
        End Property

        'LastLastHeight Property
        Public Property LastHeight() As Double
            Get
                Return dblLastHeight
            End Get
            Set(ByVal Value As Double)
                dblLastHeight = Value
            End Set
        End Property


        'LastZoom Property
        Public Property LastZoom() As Double
            Get
                Return dblLastZoom
            End Get
            Set(ByVal Value As Double)
                dblLastZoom = Value
            End Set
        End Property

        'URL Property
        Public Property URL() As String
            Get
                Return strURL
            End Get
            Set(ByVal Value As String)
                strURL = Value
            End Set
        End Property

        'Mode Property
        Public Property Mode() As String
            Get
                Return strMode
            End Get
            Set(ByVal Value As String)
                strMode = Value
            End Set
        End Property

        '***************************************************************************************************
        '                                          END DECLARE PROPERTIES
        '                                          IMPLEMENT METHODS HERE
        '***************************************************************************************************


        'Initialize method
        Public Sub Initialize()
            'Init objBCSP object
            objBCSP.DBServer = strDBServer
            objBCSP.ConnectionString = strConnectionString
            objBCSP.InterfaceLanguage = strInterfaceLanguage
            objBCSP.Initialize()

            'Init objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.Initialize()
            'Init imgImage
            'imgImage = New GflAx193.GflAx
        End Sub

        'Method: Drowmap
        Public Function DrawMap()
            Dim dblnewWidth As Double
            Dim dblnewHeight As Double
            Dim dblCapturex As Double
            Dim dblCapturey As Double
            Dim dblCropx As Double
            Dim dblCropy As Double
            Dim dblCropw As Double
            Dim dblCroph As Double
            Dim dblTopleft As Double
            Dim intObj As New Object
            Dim int32Color As System.UInt32
            With imgImage
                .EnableLZW = True
                .LoadBitmap(strURL)
                If strMode = "zoom" Or strMode = "nav" Then
                    If IsNumeric(dblLastX) Then
                        If dblZoom > 0 Then
                            dblZoom = CDbl(dblZoom)
                            If dblZoom > 0 Then
                                dblnewWidth = .Width * dblZoom / 100
                                dblnewHeight = .Height * dblZoom / 100
                                dblCapturex = dblLastWidth
                                dblCapturey = dblLastHeight
                                dblCropx = CDbl(dblLastX)
                                dblCropy = CDbl(dblLastY)
                                dblCropw = dblCapturex
                                dblCroph = dblCapturey

                                If dblCropx < 0 Then
                                    dblCropw = dblCapturex + dblCropx
                                    If dblCropw < 0 Then
                                        dblCropw = 1
                                    ElseIf dblCropw > dblnewWidth Then
                                        dblCropw = dblnewWidth
                                    End If
                                    dblCropx = 0
                                ElseIf dblCropx > dblnewWidth Then
                                    dblCropx = dblnewWidth - 1
                                    dblCropw = 1
                                Else
                                    If dblCropx + dblCapturex > dblnewWidth Then
                                        dblCropw = dblnewWidth - dblCropx
                                    End If
                                End If
                                If dblCropy < 0 Then
                                    dblCroph = dblCapturey + dblCropy
                                    If dblCroph < 0 Then
                                        dblCroph = 1
                                    ElseIf dblCroph > dblnewHeight Then
                                        dblCroph = dblnewHeight
                                    End If
                                    dblCropy = 0
                                ElseIf dblCropy > dblnewHeight Then
                                    dblCropy = dblnewHeight - 1
                                    dblCroph = 1
                                Else
                                    If dblCropy + dblCapturey > dblnewHeight Then
                                        dblCroph = dblnewHeight - dblCropy
                                    End If
                                End If
                                If strMode = "zoom" Then
                                    .Crop(dblCropx * 100 / dblZoom, dblCropy * 100 / dblZoom, dblCropw * 100 / dblZoom, dblCroph * 100 / dblZoom)
                                    .Resize(Math.Round(dblCropw), Math.Round(dblCroph))
                                    If IsNumeric(dblLastRotate) Then
                                        intObj = RGB(0, 0, 0)
                                        int32Color = Convert.ToUInt32(intObj)
                                        .Rotate(CInt(dblLastRotate), int32Color)
                                    End If
                                    If dblCroph < dblCapturey Or dblCropw < dblCapturex Then
                                        Dim strDirectionText As String
                                        strDirectionText = ""
                                        If dblCropx = 0 Then
                                            strDirectionText = strDirectionText & "right"
                                        ElseIf dblCropw < dblCapturex Then
                                            strDirectionText = strDirectionText & "left"
                                        End If
                                        If dblCropy = 0 Then
                                            strDirectionText = strDirectionText & "bottom"
                                        ElseIf dblCroph < dblCapturey Then
                                            strDirectionText = strDirectionText & "top"
                                        End If
                                        If dblCropy = dblnewHeight - 1 Then
                                            strDirectionText = strDirectionText & "top"
                                        End If
                                        If dblCropx = dblnewWidth - 1 Then
                                            strDirectionText = strDirectionText & "left"
                                        End If
                                        Dim intDirection As Integer = -1
                                        Select Case strDirectionText
                                            Case "right"
                                                intDirection = 8
                                            Case "left"
                                                intDirection = 7
                                            Case "top"
                                                intDirection = 5
                                            Case "bottom"
                                                intDirection = 6
                                            Case "topleft", "lefttop"
                                                intDirection = 1
                                            Case "topright", "righttop"
                                                intDirection = 2
                                            Case "bottomleft", "leftbottom"
                                                intDirection = 3
                                            Case "rightbottom", "bottomright"
                                                intDirection = 4
                                            Case Else
                                                intDirection = 0
                                        End Select
                                        intObj = RGB(0, 0, 0)
                                        int32Color = Convert.ToUInt32(intObj)
                                        .ResizeCanvas(dblCapturex, dblCapturey, intDirection, int32Color)
                                    End If
                                Else
                                    dblCapturex = 300
                                    dblCapturey = 300
                                    Dim dblnavzoom1 As Double
                                    Dim dblnavzoom2 As Double
                                    Dim dblnavzoom As Double
                                    If .Width > dblCapturex Then
                                        dblnavzoom1 = dblCapturex / .Width
                                        dblnewWidth = .Width * dblnavzoom1
                                        dblnewHeight = .Height * dblnavzoom1
                                    Else
                                        dblnavzoom1 = 1
                                    End If
                                    If dblnewHeight > dblCapturey Then
                                        dblnavzoom2 = dblCapturey / dblnewHeight
                                        dblnewWidth = dblnewWidth * dblnavzoom2
                                        dblnewHeight = dblnewHeight * dblnavzoom2
                                    Else
                                        dblnavzoom2 = 1
                                    End If
                                    dblnavzoom = dblnavzoom1 * dblnavzoom2
                                    dblCropx = dblCropx * dblnavzoom * 100 / CDbl(dblZoom)
                                    dblCropy = dblCropy * dblnavzoom * 100 / CDbl(dblZoom)
                                    dblCropw = dblCropw * dblnavzoom * 100 / CDbl(dblZoom)
                                    dblCroph = dblCroph * dblnavzoom * 100 / CDbl(dblZoom)
                                    If dblnavzoom <> 1 Then
                                        .Resize(dblnewWidth, dblnewHeight)
                                    End If
                                    intObj = RGB(255, 0, 0)
                                    int32Color = Convert.ToUInt32(intObj)
                                    .DrawRectangle(dblCropx, dblCropy, dblCropw, dblCroph, 1, int32Color)
                                End If
                            End If
                        End If
                    End If
                End If
                .SaveFormat = AX_JPEG
                DrawMap = .SendBinary
            End With
            imgImage = Nothing
        End Function

        'Method: Load image
        Public Sub LoadImage(ByVal intChangeMap As Integer, ByVal lngImgTnailzoomX As Long, ByVal lngImgTnailzoomY As Long, ByVal lngImgTnailX As Long, ByVal lngImgTnailY As Long)

            Dim dblThisTopLeftx As Double = 0
            Dim dblThisTopLefty As Double = 0
            Dim dblThisCenterx As Double = 0
            Dim dblThisCentery As Double = 0

            With imgImage
                .EnableLZW = True
                .LoadBitmap(strURL)
                Dim dbloWidth As Double = 0
                Dim dbloHeight As Double = 0
                dbloWidth = .Width
                dbloHeight = .Height

                Dim dbllWidth As Double = 0
                Dim dbllHeight As Double = 0
                dbllWidth = dbloWidth * dblZoom / 100
                dbllHeight = dbloHeight * dblZoom / 100

                If dblLastX = 0 Or intChangeMap = 1 Then
                    dblLastX = dbloWidth * dblLastZoom / 200 - dblLastWidth / 2
                Else
                    dblLastX = dblLastX
                End If
                If dblLastX = 0 Or intChangeMap = 1 Then
                    dblLastY = dbloHeight * dblLastZoom / 200 - dblLastHeight / 2
                Else
                    dblLastY = dblLastY
                End If

                If lngImgTnailzoomX > 0 Then
                    Dim dblAddx As Integer = 0
                    Dim dblAddy As Integer = 0
                    Select Case CStr(dblLastRotate)
                        Case "", "0"
                            dblAddx = lngImgTnailzoomX
                            dblAddy = lngImgTnailzoomY
                        Case "90"
                            dblAddx = CLng(dblLastHeight) - CLng(lngImgTnailzoomY)
                            dblAddy = CLng(lngImgTnailzoomX)
                        Case "180"
                            dblAddx = CLng(dblLastWidth) - CLng(lngImgTnailzoomX)
                            dblAddy = CLng(dblLastHeight) - CLng(lngImgTnailzoomY)
                        Case "270"
                            dblAddx = CLng(lngImgTnailzoomY)
                            dblAddy = CLng(dblLastWidth) - CLng(lngImgTnailzoomX)
                    End Select

                    dblThisCenterx = (dblLastX + dblAddx) * (dblZoom / dblLastZoom)
                    dblThisCentery = (dblLastY + dblAddy) * (dblZoom / dblLastZoom)

                    dblThisTopLeftx = dblThisCenterx - dblLastWidth / 2
                    dblThisTopLefty = dblThisCentery - dblLastHeight / 2
                    If dblThisTopLeftx <= dblLastWidth * (-1) Or dblThisTopLefty <= dblLastHeight * (-1) Or dblThisTopLeftx >= dbllWidth Or dblThisTopLefty >= dbllHeight Then
                        dblThisTopLeftx = dblLastX
                        dblThisTopLefty = dblLastY
                    End If
                ElseIf lngImgTnailX > 0 Then
                    Dim lngFcapTurex As Long = 0
                    Dim lngFcapTurey As Long = 0
                    lngFcapTurex = 300
                    lngFcapTurey = 300
                    Dim dblnavZoom As Double = 0
                    Dim dblnavZoom1 As Double = 0
                    Dim dblnavZoom2 As Double = 0
                    Dim dblNewWidth As Double = 0
                    Dim dblNewHeight As Double = 0
                    If .Width > lngFcapTurex Then
                        dblnavZoom1 = lngFcapTurex / .Width
                        dblNewWidth = .Width * dblnavZoom1
                        dblNewHeight = .Height * dblnavZoom1
                    Else
                        dblnavZoom1 = 1
                    End If
                    If dblNewHeight > lngFcapTurey Then
                        dblnavZoom2 = lngFcapTurey / dblNewHeight
                        dblNewWidth = dblNewWidth * dblnavZoom2
                        dblNewHeight = dblNewHeight * dblnavZoom2
                    Else
                        dblnavZoom2 = 1
                    End If
                    dblnavZoom = dblnavZoom1 * dblnavZoom2
                    dblThisCenterx = lngImgTnailX * dblZoom / (dblnavZoom * 100)
                    dblThisCentery = lngImgTnailY * dblZoom / (dblnavZoom * 100)
                    dblThisTopLeftx = dblThisCenterx - dblLastWidth / 2
                    dblThisTopLefty = dblThisCentery - dblLastHeight / 2
                Else
                    If Not dblLastWidth = 0 And Not dblLastHeight = 0 And Not intChangeMap = 1 Then
                        dblThisCenterx = (dblLastX + dblLastWidth / 2) * (dblZoom / dblLastZoom)
                        dblThisCentery = (dblLastY + CDbl(dblLastHeight) / 2) * (dblZoom / dblLastZoom)
                        dblThisTopLeftx = dblThisCenterx - dblLastWidth / 2
                        dblThisTopLefty = dblThisCentery - dblLastHeight / 2
                        If dblThisTopLeftx <= dblLastWidth * (-1) Or dblThisTopLefty <= dblLastHeight * (-1) Or dblThisTopLeftx >= dbllWidth Or dblThisTopLefty >= dbllHeight Then
                            dblThisTopLeftx = dblLastX * dblZoom / dblLastZoom
                            dblThisTopLefty = dblLastY * dblZoom / dblLastZoom
                        End If
                    Else
                        dblThisTopLeftx = dblLastX
                        dblThisTopLefty = dblLastY
                    End If
                End If
            End With
            dblLastX = dblThisTopLeftx
            dblLastY = dblThisTopLefty
            imgImage = Nothing
        End Sub


        'Dispose method
        'Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                End If
                If Not objBCSP Is Nothing Then
                    Call objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    Call objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not imgImage Is Nothing Then
                    imgImage = Nothing
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Dispose()
            End Try
        End Sub
    End Class
End Namespace