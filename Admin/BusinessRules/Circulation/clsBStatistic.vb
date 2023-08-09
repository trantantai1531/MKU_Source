' Name: clsBStatistic
' Purpose: create some type of statistic
' Creator: Oanhtn
' Created Date: 07/09/2004
' Modification history:

Imports System
Imports System.Data
Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.DataAccess

Namespace eMicLibAdmin.BusinessRules
    Public Class clsBStatistic
        Inherits clsBBase

        ' *****************************************************************************************************
        ' Declare Private variables
        ' *****************************************************************************************************

        Private intStatType As Int16
        Private objStream As Object
        Private objMapImg As Object

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' StatType property
        Public Property StatType() As Int16
            Get
                Return intStatType
            End Get
            Set(ByVal Value As Int16)
                intStatType = Value
            End Set
        End Property

        ' OutPutStreamproperty
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

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Makebarchart method
        ' Purpose: create barchart
        Public Sub Makebarchart(ByVal arrData As Object, ByVal arrLabel As Object, ByVal strHTitle As String, ByVal strVTitle As String, ByVal bytAngle As Byte, ByVal strFullPathImg As String, ByVal strFileChart As String, Optional ByVal strURL As String = "")
            Dim objChartDir As Object
            Dim intHeight As Integer
            Dim intLong As Integer
            Dim intWchart As Integer
            Dim intHchart As Integer
            Dim objChart As Object
            Dim objLayer As Object

            ' Create object
            objChartDir = CreateObject("ChartDirector.API")

            If UBound(arrData) <= 25 Then
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
            Call objChart.yAxis().setTitle(strHTitle, , 15, 128)
            Call objChart.xAxis().setTitle(strVTitle, , 15, 128)
            objLayer = objChart.addBarLayer(arrData, &HC3C3E6)
            Call objLayer.setAggregateLabelStyle("Arial.ttf", 10, 10).setBackground(&HFFCC66, objChartDir.Transparent, 1)
            Call objLayer.set3D()
            Call objChart.xAxis().setLabels(arrLabel)

            ' Rotation
            If bytAngle > 0 Then
                Call objChart.xAxis().setLabelStyle("", 8).setFontAngle(bytAngle)
            End If

            objStream = objChart.makeChart2(objChartDir.GIF)
            objMapImg = objChart.getHTMLImageMap(strFileChart, strURL)

            ' Release object
            objChartDir = Nothing
            objChart = Nothing
        End Sub

        ' Makepiechart method
        ' Purpose: Create piechart
        Public Function Makepiechart(ByVal ArrData As Object, ByVal ArrLabel As Object, ByVal strTitle As String, ByVal strFullPathImg As String)
            Dim objChartDir As Object
            Dim intVHeight As Integer
            Dim intVLong As Integer
            Dim objChart As Object

            objChartDir = CreateObject("ChartDirector.API")
            If UBound(ArrData) <= 26 Then
                intVHeight = 320
                intVLong = 700
            Else
                If UBound(ArrData) <= 60 Then
                    intVHeight = 420
                    intVLong = 700
                Else
                    intVHeight = 660
                    intVLong = 700
                End If
            End If

            objChart = objChartDir.PieChart(intVLong, intVHeight)
            Call objChart.setPieSize(400, 130, 120)
            Call objChart.setWallpaper(strFullPathImg)
            Call objChart.setLabelLayout(objChartDir.SideLayout)
            Call objChart.setLabelStyle().setBackground(objChartDir.SameAsMainColor, objChartDir.Transparent, 1)
            Call objChart.setLineColor(objChartDir.SameAsMainColor, &H0)
            Call objChart.setStartAngle(200)
            Call objChart.addTitle2(2, strTitle, , 15, 128)
            Call objChart.set3D()
            Call objChart.setData(ArrData, ArrLabel)
            Call objChart.sector(0).setExplode()

            objStream = objChart.makeChart2(objChartDir.GIF)

            objChartDir = Nothing
            objChart = Nothing
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
            Finally
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace