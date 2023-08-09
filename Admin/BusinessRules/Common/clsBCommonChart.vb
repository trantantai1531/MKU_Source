Imports System.Drawing

Namespace eMicLibAdmin.BusinessRules.Common
    Public Class clsBCommonChart
        Inherits clsBBase

        Private objStream As Object
        Private objMapImg As Object
        Private ObjBarCodeImg As Object
        Private intVHeight As Integer
        Private intVLong As Integer
        Private intWchart As Integer
        Private intHchart As Integer
        Private objChartDir As Object

        Public Enum objImageType
            Gif = 1
            Jpeg = 2
            Png = 3
            Bmp = 4
            Tiff = 5
        End Enum

        Public Enum objBarcodeType
            UPCA = 1
            UPCE = 2
            UPC_SUPPLEMENTAL_2DIGIT = 3
            UPC_SUPPLEMENTAL_5DIGIT = 4
            EAN13 = 5
            JAN13 = 6
            EAN8 = 7
            ITF14 = 8
            Interleaved2of5 = 9
            Standard2of5 = 10
            Codabar = 11
            PostNet = 12
            BOOKLAND = 13
            CODE11 = 14
            CODE39 = 15
            CODE39Extended = 16
            CODE93 = 17
            CODE128 = 18
            CODE128A = 19
            CODE128B = 20
            CODE128C = 21
            LOGMARS = 22
            MSI_Mod10 = 23
            TELEPEN = 24
            FIM = 25
        End Enum


        ' ChartDir property 
        Public ReadOnly Property ChartDir() As Object
            Get
                Return objChartDir
            End Get
        End Property

        ' BarCodeImg property 
        Public ReadOnly Property BarCodeImg() As Object
            Get
                BarCodeImg = ObjBarCodeImg
            End Get
        End Property


        ' OutPutStream property 
        Public ReadOnly Property OutPutStream() As Object
            Get
                Return objStream
            End Get
        End Property

        ' OutMapImg property 
        Public ReadOnly Property OutMapImg() As Object
            Get
                Return objMapImg
            End Get
        End Property

        ' VHeight property 
        Public Property VHeight() As Integer
            Get
                Return (intVHeight)
            End Get
            Set(ByVal Value As Integer)
                intVHeight = Value
            End Set
        End Property

        ' VLong prot
        Public Property VLong() As Integer
            Get
                Return (intVLong)
            End Get
            Set(ByVal Value As Integer)
                intVLong = Value
            End Set
        End Property
        ' Wchart property 
        Public Property Wchart() As Integer
            Get
                Return (intWchart)
            End Get
            Set(ByVal Value As Integer)
                intWchart = Value
            End Set
        End Property
        '-----------------------------------------
        ' This property use get/set Height for PieChart
        '-----------------------------------------
        Public Property Hchart() As Integer
            Get
                Return (intHchart)
            End Get
            Set(ByVal Value As Integer)
                intHchart = Value
            End Set
        End Property

        Public Sub Initialize()
            objChartDir = CreateObject("ChartDirector.API")
        End Sub

        Public Function Makepiechart(ByVal ArrData As Object, ByVal ArrLabel As Object, ByVal strTitle As String, ByVal strFullPathImg As String)
            'Dim objChartDir As Object
            Dim intVHeight As Integer
            Dim intVLong As Integer
            Dim objChart As Object

            'objChartDir = CreateObject("ChartDirector.API")
            If Not ArrData Is Nothing AndAlso UBound(ArrData) <= 26 Then
                intVHeight = 250
                intVLong = 550
            Else
                If Not ArrData Is Nothing AndAlso UBound(ArrData) <= 60 Then
                    'intVHeight = 400
                    intVHeight = 700
                    intVLong = 550
                Else
                    intVHeight = 660
                    intVLong = 550
                End If
            End If
            objChart = objChartDir.PieChart(intVLong, intVHeight)
            Call objChart.setPieSize(300, 120, 75)
            Call objChart.setWallpaper(strFullPathImg)
            Call objChart.setLabelLayout(objChartDir.SideLayout)
            Call objChart.setLabelStyle().setBackground(objChartDir.SameAsMainColor, objChartDir.Transparent, 1)
            Call objChart.setLineColor(objChartDir.SameAsMainColor, &H0)
            Call objChart.setStartAngle(200)
            Call objChart.addTitle2(7, strTitle, , 9, 128)
            Call objChart.set3D()
            If Not ArrData Is Nothing AndAlso Not ArrLabel Is Nothing Then
                Call objChart.setData(ArrData, ArrLabel)

                Call objChart.sector(0).setExplode()
                objStream = objChart.makeChart2(objChartDir.GIF)
            End If
            'objChartDir = Nothing
            objChart = Nothing
        End Function

        Public Function MakepiechartLarge(ByVal ArrData As Object, ByVal ArrLabel As Object, ByVal strTitle As String, ByVal strFullPathImg As String)
            'Dim objChartDir As Object
            Dim intVHeight As Integer
            Dim intVLong As Integer
            Dim objChart As Object

            'objChartDir = CreateObject("ChartDirector.API")
            If Not ArrData Is Nothing AndAlso UBound(ArrData) <= 26 Then
                intVHeight = 350
                intVLong = 500
            Else
                If Not ArrData Is Nothing AndAlso UBound(ArrData) <= 20 Then
                    intVHeight = 320
                    intVLong = 600
                Else
                    intVHeight = 460
                    intVLong = 600
                End If
            End If
            objChart = objChartDir.PieChart(intVLong, intVHeight)
            Call objChart.setPieSize(250, 150, 110)
            Call objChart.setWallpaper(strFullPathImg)
            Call objChart.setLabelLayout(objChartDir.SideLayout)
            Call objChart.setLabelStyle().setBackground(objChartDir.SameAsMainColor, objChartDir.Transparent, 1)
            Call objChart.setLineColor(objChartDir.SameAsMainColor, &H0)
            Call objChart.setStartAngle(200)
            Call objChart.addTitle2(2, strTitle, , 12, 128)
            Call objChart.set3D()
            Call objChart.setData(ArrData, ArrLabel)
            Call objChart.sector(0).setExplode()
            objStream = objChart.makeChart2(objChartDir.GIF)
            'objChartDir = Nothing
            objChart = Nothing
        End Function

        Public Function MakepiechartMiddle(ByVal ArrData As Object, ByVal ArrLabel As Object, ByVal strTitle As String, ByVal strFullPathImg As String)
            'Dim objChartDir As Object
            Dim intVHeight As Integer
            Dim intVLong As Integer
            Dim objChart As Object

            'objChartDir = CreateObject("ChartDirector.API")
            If Not ArrData Is Nothing AndAlso UBound(ArrData) <= 26 Then
                intVHeight = 350
                intVLong = 600
            Else
                intVHeight = 460
                intVLong = 700
            End If
            objChart = objChartDir.PieChart(intVLong, intVHeight)
            Call objChart.setPieSize(300, 170, 90)
            Call objChart.setWallpaper(strFullPathImg)
            Call objChart.setLabelLayout(objChartDir.SideLayout)
            Call objChart.setLabelStyle().setBackground(objChartDir.SameAsMainColor, objChartDir.Transparent, 1)
            Call objChart.setLineColor(objChartDir.SameAsMainColor, &H0)
            Call objChart.setStartAngle(200)
            Call objChart.addTitle2(2, strTitle, , 12, 128)
            Call objChart.set3D()
            Call objChart.setData(ArrData, ArrLabel)
            Call objChart.sector(0).setExplode()
            objStream = objChart.makeChart2(objChartDir.GIF)
            'objChartDir = Nothing
            objChart = Nothing
        End Function

        '------------------------------------------------------------------------
        Public Sub Makebarchartsub(ByVal ArrData As Object, ByVal ArrLabel As Object, ByVal strHtitle As String, ByVal strVtitle As String, ByVal bytAngle As Byte, ByVal strFullPathImg As String, ByVal strFileChart As String, Optional ByVal strURL As String = "")
            'Dim objChartDir As Object
            Dim intHeight As Integer
            Dim intLong As Integer
            Dim intWchart As Integer
            Dim intHchart As Integer
            Dim objChart As Object
            ' objChartDir = CreateObject("ChartDirector.API")

            If Not ArrData Is Nothing AndAlso UBound(ArrData) <= 20 Then
                intHeight = 320
                intLong = 400
                intWchart = 280
                intHchart = 230
            Else
                intHeight = 320
                intLong = 660
                intWchart = 580
                intHchart = 230
            End If
            If bytAngle = 0 Then
            Else
                intHeight = 420
            End If
            objChart = objChartDir.XYChart(intLong, intHeight)

            Call objChart.setPlotArea(60, 10, intWchart, intHchart)
            Call objChart.setWallpaper(strFullPathImg)
            Call objChart.yAxis().setTitle(strHtitle, , 15, 128)
            Call objChart.xAxis().setTitle(strVtitle, , 15, 128)
            Dim layer As Object
            layer = objChart.addBarLayer(ArrData, &HC3C3E6)
            Call layer.setAggregateLabelStyle("Arial.ttf", 10, 10).setBackground(&HFFCC66, objChartDir.Transparent, 1)
            Call layer.set3D()
            Call objChart.xAxis().setLabels(ArrLabel)

            If bytAngle > 0 Then
                Call objChart.xAxis().setLabelStyle("", 8).setFontAngle(bytAngle)
            End If

            objStream = objChart.makeChart2(objChartDir.GIF) '
            objMapImg = objChart.getHTMLImageMap(strFileChart, strURL)        '
            'objChartDir = Nothing
            objChart = Nothing
        End Sub


        '------------------------------------------------------------------------
        Public Sub Makebarchart(ByVal ArrData As Object, ByVal ArrLabel As Object, ByVal strHtitle As String, ByVal strVtitle As String, ByVal bytAngle As Byte, ByVal strFullPathImg As String, ByVal strFileChart As String, Optional ByVal strURL As String = "", Optional ByVal intOption As Integer = 0)
            'Dim objChartDir As Object
            Dim intHeight As Integer
            Dim intLong As Integer
            Dim intWchart As Integer
            Dim intHchart As Integer
            Dim objChart As Object

            If Not ArrData Is Nothing AndAlso UBound(ArrData) <= 13 Then
                If intOption > 0 Then
                    intHeight = 300
                    intLong = 350
                    intWchart = 250
                    intHchart = 200
                Else
                    intHeight = 340
                    intLong = 550
                    intWchart = 400
                    intHchart = 230
                End If
            Else
                If intOption > 0 Then
                    If UBound(ArrData) <= 13 Then
                        intHeight = 390
                        intLong = 450
                        intWchart = 400
                        intHchart = 340
                    Else
                        intHeight = 400
                        intLong = 450
                        intWchart = 400
                        intHchart = 340
                    End If
                Else
                    intHeight = 420
                    intLong = 1200
                    intWchart = 1120
                    intHchart = 340
                End If
            End If
            If bytAngle > 0 And intOption = 0 Then
                If intHeight > 400 Then
                    'intHeight = 500
                    intHeight = 550
                Else
                    intHeight = 400
                End If
            End If
            objChart = objChartDir.XYChart(intLong, intHeight)
            If intOption > 0 Then
                Call objChart.setPlotArea(70, 30, intWchart, intHchart)
            Else
                Call objChart.setPlotArea(70, 30, intWchart, intHchart)
            End If
            Call objChart.setWallpaper(strFullPathImg)
            If intOption > 0 Then
                Call objChart.yAxis().setTitle(strHtitle, , 10, 80)
                Call objChart.xAxis().setTitle(strVtitle, , 10, 80)
            Else
                Call objChart.yAxis().setTitle(strHtitle, , 10, 128)
                Call objChart.xAxis().setTitle(strVtitle, , 10, 128)
            End If
            Dim layer As Object
            If Not ArrData Is Nothing Then
                layer = objChart.addBarLayer(ArrData, &H25A0DA)
                Call layer.setAggregateLabelStyle("Arial.ttf", 10, 10).setBackground(&HFFFFFF, objChartDir.Transparent, 1)
                Call layer.set3D()
            End If
            If Not ArrLabel Is Nothing Then
                Call objChart.xAxis().setLabels(ArrLabel)
            End If
            If bytAngle > 0 Then
                Call objChart.xAxis().setLabelStyle("", 8).setFontAngle(bytAngle)
            End If

            objStream = objChart.makeChart2(objChartDir.GIF)
            If strFileChart <> "" Then
                objMapImg = objChart.getHTMLImageMap(strFileChart, strURL, "title='{xLabel}: {value|0}'")
            End If
            objChart = Nothing
        End Sub


        Public Sub MakebarchartLarge(ByVal ArrData As Object, ByVal ArrLabel As Object, ByVal strHtitle As String, ByVal strVtitle As String, ByVal bytAngle As Byte, ByVal strFullPathImg As String, ByVal strFileChart As String, Optional ByVal strURL As String = "")
            'Dim objChartDir As Object
            Dim intHeight As Integer
            Dim intLong As Integer
            Dim intWchart As Integer
            Dim intHchart As Integer
            Dim objChart As Object
            'objChartDir = CreateObject("ChartDirector.API")

            If Not ArrData Is Nothing AndAlso UBound(ArrData) <= 15 Then
                intHeight = 300
                intLong = 600
                intWchart = 500
                intHchart = 250
            Else
                intHeight = 420
                intLong = 700
                intWchart = 600
                intHchart = 410
            End If
            If bytAngle = 0 Then
            Else
                intHeight = 400
            End If
            objChart = objChartDir.XYChart(intLong, intHeight)

            Call objChart.setPlotArea(70, 30, intWchart, intHchart)
            Call objChart.setWallpaper(strFullPathImg)
            Call objChart.yAxis().setTitle(strHtitle, , 12, 128)
            Call objChart.xAxis().setTitle(strVtitle, , 12, 128)
            Dim layer As Object
            layer = objChart.addBarLayer(ArrData, &HC3C3E6)
            Call layer.setAggregateLabelStyle("Arial.ttf", 12, 12).setBackground(&HFFCC66, objChartDir.Transparent, 1)
            Call layer.set3D()
            Call objChart.xAxis().setLabels(ArrLabel)

            If bytAngle > 0 Then
                Call objChart.xAxis().setLabelStyle("", 8).setFontAngle(bytAngle)
            End If

            objStream = objChart.makeChart2(objChartDir.GIF) '
            objMapImg = objChart.getHTMLImageMap(strFileChart, strURL)        '
            'objChartDir = Nothing
            objChart = Nothing
        End Sub

        '------------------------------------------------------------------------
        'Purpose: make barchart, with no display data on top taskbar
        'in: arrData,arrLabel,...
        'out: 2 objData,objLabel
        'creator: sondp
        '------------------------------------------------------------------------
        Public Sub MakeBarChartWal(ByVal ArrData As Object, ByVal ArrLabel As Object, ByVal strHtitle As String, ByVal strVtitle As String, ByVal bytAngle As Byte, ByVal strFullPathImg As String, ByVal strFileChart As String, ByVal Color As String)
            'Dim objChartDir As Object
            Dim intHeight As Integer
            Dim intLong As Integer
            Dim intWchart As Integer
            Dim intHchart As Integer
            Dim objChart As Object
            'objChartDir = CreateObject("ChartDirector.API")

            If Not ArrData Is Nothing AndAlso UBound(ArrData) <= 15 Then
                intHeight = 420
                intLong = 500
                intWchart = 380
                intHchart = 330
            Else
                intHeight = 420
                intLong = 760
                intWchart = 680
                intHchart = 330
            End If
            If bytAngle = 0 Then
            Else
                intHeight = 520
            End If
            objChart = objChartDir.XYChart(intLong, intHeight)

            Call objChart.setPlotArea(70, 30, intWchart, intHchart)
            Call objChart.setWallpaper(strFullPathImg)
            Call objChart.yAxis().setTitle(strHtitle, , 15, 128)
            Call objChart.xAxis().setTitle(strVtitle, , 15, 128)
            Dim layer As Object
            layer = objChart.addBarLayer(ArrData, Color)

            Call layer.set3D()
            Call objChart.xAxis().setLabels(ArrLabel)
            If bytAngle > 0 Then
                Call objChart.xAxis().setLabelStyle("", 8).setFontAngle(bytAngle)
            End If

            objStream = objChart.makeChart2(objChartDir.GIF) '
            objMapImg = objChart.getHTMLImageMap(strFileChart, "")        '
            'objChartDir = Nothing
            objChart = Nothing
        End Sub

        Function GenRanNum(ByVal i As Integer) As String
            Dim str As String
            str = ""
            Dim inti As Integer
            Randomize()
            For inti = 0 To i
                str = str & CStr(CByte(9 * Rnd() + 48))
            Next
            GenRanNum = str
        End Function

        '--------------------------------------------------------
        ' purpose : Tao Mang cac Image Barcode
        ' in: Data array content data, bytImageType 1: png(), : jpeg,  intBarWidth: width of barcode image, intHeight: height of barcode image, intRotate rotate image intRotate angle.
        ' out: barcode image(s)
        '--------------------------------------------------------
        Public Sub MakeImgBarcode(ByVal Data As Object, ByVal bytImageType As Byte, ByVal intBarWidth As Integer, ByVal intHeight As Integer, ByVal intType As Integer, ByVal strAddondata As String, ByVal strCaption As String, ByVal strAddOnCaption As String, ByVal intRotate As Integer, Optional ByVal strBarcodeColor As String = "000000", Optional ByVal bolShowData As Boolean = False, Optional ByVal strFontFamily As String = "Arial", Optional ByVal intFontSize As Integer = 9, Optional ByVal intFontStyle As FontStyle = FontStyle.Regular)
            'Dim ArrRet() As Object
            'If IsArray(Data) Then
            '    ReDim ArrRet(UBound(Data))
            '    Dim objBarCode As EASYBAROLib.Barcode
            '    objBarCode = New EASYBAROLib.Barcode
            '    objBarCode.ThrowDataError = False
            '    objBarCode.InvalidDataAction = 3
            '    objBarCode.BarcodeType = intType
            '    objBarCode.AddOnData = strAddondata
            '    objBarCode.Caption = strCaption
            '    objBarCode.AddOnCaption = strAddOnCaption
            '    objBarCode.Orientation = CShort(intRotate)
            '    objBarCode.StretchText = False
            '    Dim inti As Integer
            '    For inti = 0 To UBound(Data)
            '        objBarCode.Data = Data(inti)
            '        If objBarCode.Orientation = 0 Or objBarCode.Orientation = 2 Then
            '            ArrRet(inti) = objBarCode.MakeImage(bytImageType, intBarWidth, intHeight, True)
            '        Else
            '            ArrRet(inti) = objBarCode.MakeImage(bytImageType, intHeight, intBarWidth, True)
            '        End If
            '    Next
            '    ObjBarCodeImg = ArrRet
            'End If
            Dim ArrRet() As Object
            Dim Forecolor As String = strBarcodeColor
            Dim Backcolor As String = "FFFFFF"
            Dim barcodeImage As System.Drawing.Image = Nothing
            Dim MemStream As System.IO.MemoryStream = Nothing
            Dim imageType As System.Drawing.Imaging.ImageFormat = System.Drawing.Imaging.ImageFormat.Png
            Dim barcodeType As BarcodeLib.TYPE
            If IsArray(Data) Then
                Select Case bytImageType
                    Case objImageType.Gif
                        imageType = System.Drawing.Imaging.ImageFormat.Gif
                    Case objImageType.Jpeg
                        imageType = System.Drawing.Imaging.ImageFormat.Jpeg
                    Case objImageType.Png
                        imageType = System.Drawing.Imaging.ImageFormat.Png
                    Case objImageType.Bmp
                        imageType = System.Drawing.Imaging.ImageFormat.Bmp
                    Case objImageType.Tiff
                        imageType = System.Drawing.Imaging.ImageFormat.Tiff
                End Select

                Select Case intType
                    Case objBarcodeType.UPCA
                        barcodeType = BarcodeLib.TYPE.UPCA
                    Case objBarcodeType.UPCE
                        barcodeType = BarcodeLib.TYPE.UPCE
                    Case objBarcodeType.UPC_SUPPLEMENTAL_2DIGIT
                        barcodeType = BarcodeLib.TYPE.UPC_SUPPLEMENTAL_2DIGIT
                    Case objBarcodeType.UPC_SUPPLEMENTAL_5DIGIT
                        barcodeType = BarcodeLib.TYPE.UPC_SUPPLEMENTAL_5DIGIT
                    Case objBarcodeType.EAN13
                        barcodeType = BarcodeLib.TYPE.EAN13
                    Case objBarcodeType.JAN13
                        barcodeType = BarcodeLib.TYPE.JAN13
                    Case objBarcodeType.EAN8
                        barcodeType = BarcodeLib.TYPE.EAN8
                    Case objBarcodeType.ITF14
                        barcodeType = BarcodeLib.TYPE.ITF14
                    Case objBarcodeType.Interleaved2of5
                        barcodeType = BarcodeLib.TYPE.Interleaved2of5
                    Case objBarcodeType.Standard2of5
                        barcodeType = BarcodeLib.TYPE.Standard2of5
                    Case objBarcodeType.Codabar
                        barcodeType = BarcodeLib.TYPE.Codabar
                    Case objBarcodeType.PostNet
                        barcodeType = BarcodeLib.TYPE.PostNet
                    Case objBarcodeType.BOOKLAND
                        barcodeType = BarcodeLib.TYPE.BOOKLAND
                    Case objBarcodeType.CODE11
                        barcodeType = BarcodeLib.TYPE.CODE11
                    Case objBarcodeType.CODE39
                        barcodeType = BarcodeLib.TYPE.CODE39
                    Case objBarcodeType.CODE39Extended
                        barcodeType = BarcodeLib.TYPE.CODE39Extended
                    Case objBarcodeType.CODE93
                        barcodeType = BarcodeLib.TYPE.CODE93
                    Case objBarcodeType.CODE128
                        barcodeType = BarcodeLib.TYPE.CODE128
                    Case objBarcodeType.CODE128A
                        barcodeType = BarcodeLib.TYPE.CODE128A
                    Case objBarcodeType.CODE128B
                        barcodeType = BarcodeLib.TYPE.CODE128B
                    Case objBarcodeType.CODE128C
                        barcodeType = BarcodeLib.TYPE.CODE128C
                    Case objBarcodeType.LOGMARS
                        barcodeType = BarcodeLib.TYPE.LOGMARS
                    Case objBarcodeType.MSI_Mod10
                        barcodeType = BarcodeLib.TYPE.MSI_Mod10
                    Case objBarcodeType.TELEPEN
                        barcodeType = BarcodeLib.TYPE.TELEPEN
                    Case objBarcodeType.FIM
                        barcodeType = BarcodeLib.TYPE.FIM
                    Case Else
                        barcodeType = BarcodeLib.TYPE.CODE11
                End Select

                If (intBarWidth = 1) Then
                    intBarWidth = 200
                End If

                ReDim ArrRet(UBound(Data))
                Dim b As BarcodeLib.Barcode
                Dim inti As Integer
                'objBarcode.LabelFont = new System.Drawing.Font("Arial", 18, FontStyle.Regular);
                Dim fontbarcode As New Font(strFontFamily, intFontSize, intFontStyle)
                For inti = 0 To UBound(Data)
                    b = New BarcodeLib.Barcode
                    With b
                        '.EncodedType = intType
                        .Alignment = BarcodeLib.AlignmentPositions.CENTER
                        .IncludeLabel = bolShowData
                        '.RawData = Data(inti).ToString
                        .Width = intBarWidth
                        .Height = intHeight
                        '.Width = 170
                        '.Height = 40
                        .RotateFlipType = RotateFlipType.RotateNoneFlipNone
                        .LabelFont = fontbarcode
                    End With
                    If Not IsNothing(Data(inti)) AndAlso Data(inti).ToString.Trim = "" Then
                        Data(inti) = "empty"
                    End If
                    Try
                        barcodeImage = b.Encode(barcodeType, If(IsNothing(Data(inti).ToString.Trim), "", Data(inti).ToString.Trim), System.Drawing.ColorTranslator.FromHtml("#" + Forecolor), System.Drawing.ColorTranslator.FromHtml("#" + Backcolor), intBarWidth, intHeight)
                        'barcodeImage = b.Encode(barcodeType, If(IsNothing(Data(inti).ToString.Trim), "", Data(inti).ToString.Trim), System.Drawing.ColorTranslator.FromHtml("#" + Forecolor), System.Drawing.ColorTranslator.FromHtml("#" + Backcolor), 170, 40)
                    Catch ex As Exception
                        barcodeType = BarcodeLib.TYPE.CODE93
                        barcodeImage = b.Encode(barcodeType, Data(inti).ToString.Trim, System.Drawing.ColorTranslator.FromHtml("#" + Forecolor), System.Drawing.ColorTranslator.FromHtml("#" + Backcolor), intBarWidth, intHeight)
                        'barcodeImage = b.Encode(barcodeType, Data(inti).ToString.Trim, System.Drawing.ColorTranslator.FromHtml("#" + Forecolor), System.Drawing.ColorTranslator.FromHtml("#" + Backcolor), 170, 40)
                    End Try

                    MemStream = New System.IO.MemoryStream()
                    barcodeImage.Save(MemStream, imageType)
                    ArrRet(inti) = MemStream.ToArray()

                    'MemStream.Dispose()
                    barcodeImage.Dispose()
                    b.Dispose()
                Next
                ObjBarCodeImg = ArrRet
            End If
        End Sub


        'Purpose: MultiBarChart, with no display data on top taskbar,allow many Column
        'In: objData,objLabels,...
        'Out: 2 objData,objLabel
        'Creator: Tuanhv
        'Date: 25/11/2004
        Public Sub MultiBarChart(ByVal intVwidth As Integer, ByVal intVheight As Integer, ByVal objData As Object, ByVal objLabels As Object, ByVal objLegends As Object, ByVal strTitle As String, ByVal strScale As String, ByVal imgpath As String, ByVal noi As Integer)
            Dim objlayer As Object
            Dim objChart As Object
            Dim inti As Integer
            Dim arrColors(10)

            objChartDir = CreateObject("ChartDirector.API")
            arrColors(0) = &HFF
            arrColors(1) = &HFF3333
            arrColors(2) = &H80FF80
            arrColors(3) = &HCCCC99
            arrColors(4) = &H33CC99
            arrColors(5) = &H6699CC
            arrColors(6) = &HCCCC00
            arrColors(7) = &H330099
            arrColors(8) = &H6600CC
            arrColors(9) = &H670000

            objChart = objChartDir.XYChart(intVwidth, intVheight)
            Call objChart.addTitle(strTitle, "", 10)
            Call objChart.setPlotArea(50, 30, intVwidth - 80, intVheight - 80)
            Call objChart.setWallpaper(imgpath)
            Call objChart.addLegend(70, 26, 0, "", 8).setBackground(objChartDir.Transparent)
            Call objChart.yAxis().setTitle(strScale)
            Call objChart.yAxis().setTopMargin(20)
            Call objChart.xAxis().setLabels(objLabels)

            objlayer = objChart.addBarLayer2(objChartDir.Side, UBound(objData) + 1)
            For inti = LBound(objData) To UBound(objData)
                Call objlayer.addDataSet(objData(inti), arrColors(inti Mod 10), objLegends(inti))
            Next
            objStream = objChart.makeChart2(objChartDir.PNG)

            objChartDir = Nothing
            objChart = Nothing
        End Sub

        'Purpose: StackBarChart, with no display data on top taskbar,drow allow PileColumn
        'in: arrData,arrLabel,...
        'out: 2 objData,objLabel
        'creator: Tuanhv
        'Date: 25/11/2004
        Public Sub StackBarChart(ByVal intVwidth As Integer, ByVal intVheight As Integer, ByVal objData As Object, ByVal objLabels As Object, ByVal objLegends As Object, ByVal strTitlePic As String, ByVal strScale As String, ByVal imgpath As String, ByVal noi As Integer)
            Dim objLayer As Object
            Dim objChart As Object
            Dim inti As Integer

            objChartDir = CreateObject("ChartDirector.API")
            objChart = objChartDir.XYChart(intVwidth, intVheight)
            Call objChart.setPlotArea(50, 50, intVwidth - 350, intVheight - 80).setBackground(&HFFFFC0, &HFFFFE0)
            Call objChart.addLegend(intVwidth - 260, 100)
            Call objChart.addTitle(strTitlePic, "arialbd.ttf", 12)
            Call objChart.setWallpaper(imgpath)
            Call objChart.yAxis().setTitle(strScale)
            Call objChart.xAxis().setLabels(objLabels)
            objLayer = objChart.addBarLayer2(objChartDir.Stack, 8)
            Call objLayer.setAggregateLabelstyle()
            Call objLayer.setAggregateLabelstyle("timesbi.ttf", 10).setBackground( _
               &HFFCC66, objChartDir.Transparent, 1)

            For inti = LBound(objData) To UBound(objData)
                Call objLayer.addDataSet(objData(inti), -1, objLegends(inti))
            Next

            objStream = objChart.makeChart2(objChartDir.PNG)
            objChartDir = Nothing
            objChart = Nothing
        End Sub

        ' Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                objChartDir = Nothing
            Finally
                Call MyBase.Dispose()
                Call Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace