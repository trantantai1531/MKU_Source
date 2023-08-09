
Imports System.Web
Imports System
Imports System.Math
Imports eMicLibOPAC.BusinessRules.Common

Namespace eMicLibOPAC.BusinessRules.OPAC
    Public Class clsBOPACShowLocation
        Inherits clsBBase
        '***************************************************************************************************
        '                                 DECLARE PRIVATE VARIABLES
        '***************************************************************************************************
        Private lngImgWidth As Long = 0
        Private lngImgHeight As Long = 0
        Private dblImgWidthMetter As Double = 0
        Private dblImgHeightMetter As Double = 0
        Private strShelf As String = ""
        Private strImgURL As String = ""
        Private strImgPath As String = ""
        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem

        '***************************************************************************************************
        '                              END DECLARE PRIVATE VARIABLES
        '                               DECLARE PRIVATE PROPARTIES
        '***************************************************************************************************
        ' ImgWidth property
        Public Property ImgWidth() As Long
            Get
                Return lngImgWidth
            End Get
            Set(ByVal Value As Long)
                lngImgWidth = Value
            End Set
        End Property
        ' ImgHeight property
        Public Property ImgHeight() As Long
            Get
                Return lngImgHeight
            End Get
            Set(ByVal Value As Long)
                lngImgHeight = Value
            End Set
        End Property

        ' ImgWidthMetter property
        Public Property ImgWidthMetter() As Double
            Get
                Return dblImgWidthMetter
            End Get
            Set(ByVal Value As Double)
                dblImgWidthMetter = Value
            End Set
        End Property

        ' ImgHeightMetter property
        Public Property ImgHeightMetter() As Double
            Get
                Return dblImgHeightMetter
            End Get
            Set(ByVal Value As Double)
                dblImgHeightMetter = Value
            End Set
        End Property

        ' ImgURL property
        Public Property ImgURL() As String
            Get
                Return strImgURL
            End Get
            Set(ByVal Value As String)
                strImgURL = Value
            End Set
        End Property

        ' ImgPath property
        Public Property ImgPath() As String
            Get
                Return strImgPath
            End Get
            Set(ByVal Value As String)
                strImgPath = Value
            End Set
        End Property
        ' Shelf property
        Public Property Shelf() As String
            Get
                Return strShelf
            End Get
            Set(ByVal Value As String)
                strShelf = Value
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
            'imgShowLoc = New ChartDirector.API

        End Sub
        Public Function ImageOfLocation(ByVal tblShelf As DataTable) As Object
            Dim objC As Object
            Dim objC1 As Object
            Dim objC2 As Object
            Dim Filter1 As String = ""
            Dim Filter2 As String = ""
            Dim Shelves() As String
            Dim k As Integer
            Dim lngWidth As Long
            Dim lngHeight As Long
            Dim lngTemp As Long
            Dim TopCoor As Integer = 0
            Dim LeftCoor As Integer = 0
            Dim ShelfTop As Integer = 0
            Dim ShelfLeft As Integer = 0
            Dim ShelfWidth As Integer = 0
            Dim ShelfDepth As Integer = 0
            Dim Labels()
            Dim objTextbox As Object
            Dim objDrawarea As Object
            Dim imgShowLoc As Object

            Try
                imgShowLoc = CreateObject("ChartDirector.API")
                objC = imgShowLoc.XYChart(lngImgWidth, lngImgHeight)
                Call objC.setWallpaper(strImgPath)
                If strShelf <> "" Then
                    Shelves = strShelf.Split(",")
                    For k = 0 To UBound(Shelves)
                        If Shelves(k) <> "" Then
                            Filter1 = Filter1 & " OR Shelf = '" & Shelves(k) & "'"
                            Filter2 = Filter2 & " AND Shelf <> '" & Shelves(k) & "'"
                        End If
                    Next
                    Filter1 = Right(Filter1, Len(Filter1) - 4)
                    Filter2 = Right(Filter2, Len(Filter2) - 5)
                Else
                    Filter1 = "Shelf = ''"
                    Filter2 = "Shelf <> ''"
                End If
                tblShelf.DefaultView.RowFilter = Filter1
                If tblShelf.DefaultView.Count > 0 Then
                    For k = 0 To tblShelf.DefaultView.Count - 1
                        lngWidth = CLng(Math.Round((lngImgWidth * CDbl(tblShelf.DefaultView(k).Item("Width"))) / (100 * dblImgWidthMetter)))
                        lngHeight = CLng(Math.Round((lngImgHeight * CDbl(tblShelf.DefaultView(k).Item("Depth"))) / (100 * dblImgHeightMetter)))
                        If Not CInt(tblShelf.DefaultView(k).Item("Direction")) = 0 Then
                            lngTemp = lngWidth
                            lngWidth = lngHeight
                            lngHeight = lngTemp
                        End If
                        ShelfTop = CInt(tblShelf.DefaultView(k).Item("TopCoor"))
                        ShelfLeft = CInt(tblShelf.DefaultView(k).Item("LeftCoor"))

                        'Labels = tblShelf.DefaultView(k).Item("Shelf")
                        ReDim Labels(0)
                        Labels(0) = tblShelf.DefaultView(k).Item("Shelf") & "" 'Split(tblShelf.DefaultView(k).Item("Shelf"), ",")
                        If k = 0 Then
                            Call objC.setPlotArea(ShelfLeft, ShelfTop, lngWidth, lngHeight, &H990000, &H990000, _
                            &H0, &H990000, &H990000)
                            objTextbox = objC.xAxis().setLabels(Labels)
                            Call objTextbox.setFontStyle("arialb.ttf")
                            Call objTextbox.setFontSize(10)
                            Call objC.xAxis().setColors(imgShowLoc.Transparent, &H660000)
                            Call objC.yAxis().setColors(imgShowLoc.Transparent, imgShowLoc.Transparent)
                            objDrawarea = objC.makeChart3()
                        Else
                            objC1 = imgShowLoc.XYChart(lngImgWidth, lngImgHeight, imgShowLoc.Transparent)
                            Call objC1.setPlotArea(ShelfLeft, ShelfTop, lngWidth, lngHeight, &H990000, &H990000, _
                            &H0, &H990000, &H990000)
                            objTextbox = objC1.xAxis().setLabels(Labels)
                            Call objTextbox.setFontStyle("arialb.ttf")
                            Call objTextbox.setFontSize(10)
                            Call objC1.xAxis().setColors(imgShowLoc.Transparent, &H660000)
                            Call objC1.yAxis().setColors(imgShowLoc.Transparent, imgShowLoc.Transparent)
                            Call objDrawarea.merge(objC1.makeChart3(), 0, 0, imgShowLoc.TopLeft, 0)
                        End If
                    Next
                Else
                    Call objC.setPlotArea(0, 0, 0, 0, &H990000, &H990000, _
        &H990000, &H990000, &H990000)
                    objDrawarea = objC.makeChart3()
                End If

                tblShelf.DefaultView.RowFilter = Filter2
                If Not tblShelf.DefaultView Is Nothing Then
                    If tblShelf.DefaultView.Count > 0 Then
                        For k = 0 To tblShelf.DefaultView.Count - 1
                            lngWidth = CLng(Math.Round((lngImgWidth * CDbl(tblShelf.DefaultView(k).Item("Width"))) / (100 * dblImgWidthMetter)))
                            lngHeight = CLng(Math.Round((lngImgHeight * CDbl(tblShelf.DefaultView(k).Item("Depth"))) / (100 * dblImgHeightMetter)))
                            If Not CInt(tblShelf.DefaultView(k).Item("Direction")) = 0 Then
                                lngTemp = lngWidth
                                lngWidth = lngHeight
                                lngHeight = lngTemp
                            End If

                            ShelfTop = CInt(tblShelf.DefaultView(k).Item("TopCoor"))
                            ShelfLeft = CInt(tblShelf.DefaultView(k).Item("LeftCoor"))
                            ReDim Labels(0)
                            Labels(0) = tblShelf.DefaultView(k).Item("Shelf") & "" 'Split(tblShelf.DefaultView(k).Item("Shelf"), ",")
                            objC2 = imgShowLoc.XYChart(lngImgWidth, lngImgHeight, imgShowLoc.Transparent)
                            Call objC2.setPlotArea(ShelfLeft, ShelfTop, lngWidth, lngHeight, &H99, &H99, &H0, &H99, &H99)
                            objTextbox = objC2.xAxis().setLabels(Labels)
                            Call objTextbox.setFontStyle("arialb.ttf")
                            Call objTextbox.setFontSize(10)
                            Call objC2.xAxis().setColors(imgShowLoc.Transparent, &H66)
                            Call objC2.yAxis().setColors(imgShowLoc.Transparent, imgShowLoc.Transparent)
                            Call objDrawarea.merge(objC2.makeChart3(), 0, 0, imgShowLoc.TopLeft, 0)
                        Next
                    End If
                Else
                    objC = imgShowLoc.XYChart(400, 50)
                    Call objC.setPlotArea(0, 0, 400, 50, &HEEEECC, &HEEEECC, &HEEEECC, &HEEEECC, &HEEEECC)
                    Call objC.addTitle("Image of the shelving location is unavailable", "timesb.ttf", 14)
                End If
                ImageOfLocation = objC.makeChart2(imgShowLoc.PNG)
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function
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
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Dispose()
            End Try
        End Sub

    End Class
End Namespace