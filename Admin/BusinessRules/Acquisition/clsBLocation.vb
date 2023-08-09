' Purpose: process libraries location informations
' Creator: Lent
' Created Date: 17-2-2005
' Last Modified Date: 

Imports eMicLibAdmin.DataAccess.Acquisition
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports System.IO

Namespace eMicLibAdmin.BusinessRules.Acquisition
    Public Class clsBLocation
        Inherits clsBBase
        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private objDLocation As New clsDLocation
        Private objBCDBS As New clsBCommonDBSystem
        Private objBString As New clsBCommonStringProc
        Private objBCSP As New clsBCommonStringProc



        Private intLocID As Integer = 0
        Private strSymbol As String = ""
        Private intSouLocID As Integer = 0
        Private intDesLocID As Integer = 0
        Private intStatus As Integer = 0
        Private strLocIDs As String = ""
        Private strShelf As String = ""
        Private strImgURL As String = ""
        Private intImgWidth As Integer = 0
        Private intImgHeight As Integer = 0
        Private intTopCoor As Integer = 0
        Private intLeftCoor As Integer = 0
        Private dbImgWidthMetter As Single = 0
        Private dbImgHeightMetter As Single = 0
        Private intWidth As Integer = 0
        Private intDepth As Integer = 0
        Private intDirection As Integer = 0
        Private strSelShelf As String = ""
        Private strCodeLoc As String = ""
        Private strImgPath As String = ""


        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************

        ' Location Code property
        Public Property CodeLoc() As String
            Get
                Return (strCodeLoc)
            End Get
            Set(ByVal Value As String)
                strCodeLoc = Value
            End Set
        End Property


        ' intStatus property
        Public Property Status() As Integer
            Get
                Return (intStatus)
            End Get
            Set(ByVal Value As Integer)
                intStatus = Value
            End Set
        End Property

        ' StoreID property
        Public Property LocID() As Integer
            Get
                Return (intLocID)
            End Get
            Set(ByVal Value As Integer)
                intLocID = Value
            End Set
        End Property

        ' Symbol property
        Public Property Symbol() As String
            Get
                Return (strSymbol)
            End Get
            Set(ByVal Value As String)
                strSymbol = Value
            End Set
        End Property

        ' SouLocID property
        Public Property SouLocID() As Integer
            Get
                Return (intSouLocID)
            End Get
            Set(ByVal Value As Integer)
                intSouLocID = Value
            End Set
        End Property

        ' DesLocID property
        Public Property DesLocID() As Integer
            Get
                Return (intDesLocID)
            End Get
            Set(ByVal Value As Integer)
                intDesLocID = Value
            End Set
        End Property
        Public Property LocIDs() As String
            Get
                Return (strLocIDs)
            End Get
            Set(ByVal Value As String)
                strLocIDs = Value
            End Set
        End Property
        Public Property Shelf() As String
            Get
                Return (strShelf)
            End Get
            Set(ByVal Value As String)
                strShelf = Value
            End Set
        End Property
        Public Property ImgURL() As String
            Get
                Return (strImgURL)
            End Get
            Set(ByVal Value As String)
                strImgURL = Value
            End Set
        End Property
        Public Property ImgWidth() As Integer
            Get
                Return (intImgWidth)
            End Get
            Set(ByVal Value As Integer)
                intImgWidth = Value
            End Set
        End Property
        Public Property ImgHeight() As Integer
            Get
                Return (intImgHeight)
            End Get
            Set(ByVal Value As Integer)
                intImgHeight = Value
            End Set
        End Property
        Public Property TopCoor() As Integer
            Get
                Return (intTopCoor)
            End Get
            Set(ByVal Value As Integer)
                intTopCoor = Value
            End Set
        End Property
        Public Property LeftCoor() As Integer
            Get
                Return (intLeftCoor)
            End Get
            Set(ByVal Value As Integer)
                intLeftCoor = Value
            End Set
        End Property
        Public Property ImgWidthMetter() As Single
            Get
                Return (dbImgWidthMetter)
            End Get
            Set(ByVal Value As Single)
                dbImgWidthMetter = Value
            End Set
        End Property
        Public Property ImgHeightMetter() As Single
            Get
                Return (dbImgHeightMetter)
            End Get
            Set(ByVal Value As Single)
                dbImgHeightMetter = Value
            End Set
        End Property
        Public Property Width() As Integer
            Get
                Return (intWidth)
            End Get
            Set(ByVal Value As Integer)
                intWidth = Value
            End Set
        End Property

        Public Property Depth() As Integer
            Get
                Return (intDepth)
            End Get
            Set(ByVal Value As Integer)
                intDepth = Value
            End Set
        End Property

        Public Property Direction() As Integer
            Get
                Return (intDirection)
            End Get
            Set(ByVal Value As Integer)
                intDirection = Value
            End Set
        End Property
        Public Property SelShelf() As String
            Get
                Return (strSelShelf)
            End Get
            Set(ByVal Value As String)
                strSelShelf = Value
            End Set
        End Property

        Public Property ImgPath() As String
            Get
                Return (strImgPath)
            End Get
            Set(ByVal Value As String)
                strImgPath = Value
            End Set
        End Property

        ' *************************************************************************************************
        ' End declare properties
        ' Declare public function 
        ' *************************************************************************************************

        ' init all objects
        Public Sub Initialize()
            ' Intialize objDLib object
            objDLocation.DBServer = strdbserver
            objDLocation.ConnectionString = strConnectionString
            objDLocation.Initialize()
            ' Initialise objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.Initialize()

            objBString.DBServer = strDBServer
            objBString.ConnectionString = strConnectionString
            objBString.InterfaceLanguage = strInterfaceLanguage
            objBString.Initialize()

            ' Initialise objBCSP object
            objBCSP.DBServer = strDBServer
            objBCSP.ConnectionString = strConnectionString
            objBCSP.InterfaceLanguage = strInterfaceLanguage
            Call objBCSP.Initialize()

            intStatus = 1
        End Sub

        ' Purpose: insert and getID one location from library
        ' Input: location informations
        ' Output: Create and get ID
        ' Creator: PhuongTT
        ' CreatedDate: 01-07-2008

        Public Function CreateAndGetID() As Integer
            Try
                objDLocation.LibID = intLibID
                objDLocation.Symbol = objBCSP.ConvertItBack(strSymbol)
                objDLocation.UserID = intUserID
                objDLocation.CodeLoc = strCodeLoc
                CreateAndGetID = objDLocation.CreateAndGetID()
                strErrorMsg = objDLocation.ErrorMsg
                intErrorCode = objDLocation.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose: insert one location into library
        ' Input: location informations
        ' Output: 0 if success
        ' Creator: lent
        ' CreatedDate: 17-2-2005
        Public Function Create() As Integer
            Try
                objDLocation.LibID = intLibID
                objDLocation.Symbol = objBCSP.ConvertItBack(strSymbol)
                objDLocation.UserID = intUserID
                objDLocation.CodeLoc = strCodeLoc
                Create = objDLocation.Create()
                strErrorMsg = objDLocation.ErrorMsg
                intErrorCode = objDLocation.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: Update
        ' Purpose: change information of location into library
        ' Input: sysmbol, status 
        ' Output: 0 if success
        ' Creator: lent
        ' CreatedDate: 17-2-2005
        Public Function Update() As Integer
            Try
                objDLocation.LocID = intLocID
                objDLocation.Symbol = objBCSP.ConvertItBack(strSymbol)
                objDLocation.CodeLoc = objBCSP.ConvertItBack(strCodeLoc)
                Update = objDLocation.Update()
                strErrorMsg = objDLocation.ErrorMsg
                intErrorCode = objDLocation.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose: Get MinID, MaxID from Holding in one Location, for SQL only
        ' Input: LibID, LocID, Shelf
        ' Output: Datatable
        ' Creator: Sondp
        ' CreatedDate: 15-11-2005
        Public Function GetMin_Max_ID() As DataTable
            Try
                objDLocation.LocID = intLocID
                GetMin_Max_ID = objDLocation.GetMin_Max_ID
                strErrorMsg = objDLocation.ErrorMsg
                intErrorCode = objDLocation.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        'purpose: change status of location into library: Close,open location
        'in: 
        'out:
        'creator: lent
        'date : 18-2-2005
        Public Sub UpdateStatusLocation()
            Try

                objDLocation.LocIDs = strLocIDs
                objDLocation.Status = intStatus
                objDLocation.Shelf = objBCSP.ConvertItBack(strShelf)
                Call objDLocation.UpdateStatusLocation()
                strErrorMsg = objDLocation.ErrorMsg
                intErrorCode = objDLocation.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        'purpose: merger one location into other location
        'in: 
        'out:
        'creator: lent
        'date : 17-2-2005
        Public Sub MergeLocation(ByVal strSouLocIDs As String)
            Try
                objDLocation.DesLocID = intDesLocID
                objDLocation.UserID = intUserID
                Call objDLocation.MergeLocation(strSouLocIDs)
                strErrorMsg = objDLocation.ErrorMsg
                intErrorCode = objDLocation.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try

        End Sub

        'purpose: create new position of  location
        'in: 
        'out:
        'creator: lent
        'date : 8-3-2005

        Public Sub CreateLocPosition()
            Try
                Dim picByte() As Byte
                If strImgURL <> "" Then
                    Dim fi As New FileInfo(ImgPath)
                    Dim fs As New FileStream(ImgPath, FileMode.Open, FileAccess.Read, FileShare.Read)
                    Dim imgLen As Long = fi.Length
                    ReDim picByte(imgLen)
                    fs.Read(picByte, 0, imgLen) 'Read file
                End If


                objDLocation.LocID = intLocID
                objDLocation.ImgURL = strImgURL
                objDLocation.ImgWidth = intImgWidth
                objDLocation.ImgHeight = intImgHeight
                objDLocation.TopCoor = intTopCoor
                objDLocation.LeftCoor = intLeftCoor
                objDLocation.ImgWidthMetter = dbImgWidthMetter
                objDLocation.ImgHeightMetter = dbImgHeightMetter
                objDLocation.ImgByte = picByte

                Call objDLocation.CreateLocPosition()
                strErrorMsg = objDLocation.ErrorMsg
                intErrorCode = objDLocation.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try

        End Sub

        'purpose: Update position of  location
        'in: 
        'out:
        'creator: lent
        'date : 8-3-2005
        Public Sub UpdateLocPosition()
            Try
                Dim picByte(1) As Byte
                If strImgURL <> "" Then
                    Dim fi As New FileInfo(ImgPath)
                    Dim fs As New FileStream(ImgPath, FileMode.Open, FileAccess.Read, FileShare.Read)
                    Dim imgLen As Long = fi.Length
                    ReDim picByte(imgLen)
                    fs.Read(picByte, 0, imgLen) 'Read file
                End If

                objDLocation.LocID = intLocID
                objDLocation.ImgURL = strImgURL
                objDLocation.ImgWidth = intImgWidth
                objDLocation.ImgHeight = intImgHeight
                objDLocation.TopCoor = intTopCoor
                objDLocation.LeftCoor = intLeftCoor
                objDLocation.ImgWidthMetter = dbImgWidthMetter
                objDLocation.ImgHeightMetter = dbImgHeightMetter
                objDLocation.ImgByte = picByte

                Call objDLocation.UpdateLocPosition()
                strErrorMsg = objDLocation.ErrorMsg
                intErrorCode = objDLocation.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub
        'purpose: Delete position of  location
        'in: 
        'out:
        'creator: lent
        'date : 8-3-2005
        Public Sub DeleteLocPosition()
            Try
                objDLocation.LocID = intLocID
                Call objDLocation.DeleteLocPosition()
                strErrorMsg = objDLocation.ErrorMsg
                intErrorCode = objDLocation.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Purpose : Get information Location and its schema 
        ' Input: intLibID,intUserID
        ' Output: Datatable
        ' Created by: Lent
        ' date : 8-3-2005
        Public Function GetHoldingLocSchemaImage() As Byte()
            Dim tblResult As DataTable
            Dim intRow As Integer
            Dim picByte() As Byte
            Try
                objBCDBS.SQLStatement = "select imgbyte from holding_location_schema WHERE LocID =" & intLocID
                tblResult = objBCDBS.RetrieveItemInfor
                picByte = tblResult.Rows(0).Item(0)
                GetHoldingLocSchemaImage = picByte
                strErrorMsg = objDLocation.ErrorMsg
                intErrorCode = objDLocation.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose : Get schema image of Location
        ' Input: intLibID,intUserID
        ' Output: Datatable
        ' Created by: Lent
        ' date : 8-3-2005
        Public Function GetHoldingLocSchema(ByVal lblImage As String) As DataTable
            Dim tblResult As DataTable
            Dim intRow As Integer
            Try
                objDLocation.LibID = intLibID
                objDLocation.LocID = intLocID
                objDLocation.UserID = intUserID
                tblResult = objBCDBS.ConvertTable(objDLocation.GetHoldingLocSchema)
                For intRow = 0 To tblResult.Rows.Count - 1
                    If IsDBNull(tblResult.Rows(intRow).Item("LocID")) Then
                        tblResult.Rows(intRow).Item("ShowImg") = "<img src='../../Images/Cancel.gif' title='" & lblImage & "' border='0'><br>" & "0 x 0"
                        tblResult.Rows(intRow).Item("TopCoor") = 0
                        tblResult.Rows(intRow).Item("LeftCoor") = 0
                        tblResult.Rows(intRow).Item("ImgWidthMetter") = 0
                        tblResult.Rows(intRow).Item("ImgHeightMetter") = 0
                        tblResult.Rows(intRow).Item("ImgWidth") = 0
                        tblResult.Rows(intRow).Item("ImgHeight") = 0
                        tblResult.Rows(intRow).Item("ImgURL") = 0
                    Else
                        'tblResult.Rows(intRow).Item("ShowImg") = "<a href='#' onClick=""ShowImg('" & Replace(tblResult.Rows(intRow).Item("ImgURL"), "\", "\\") & "'," & CStr(intRow + 2) & ");"" border='0'><img src='../../Images/showimg.gif' title='" & lblImage & "' border='0'></a><br>" & tblResult.Rows(intRow).Item("ImgWidth") & " x " & tblResult.Rows(intRow).Item("ImgHeight")
                        tblResult.Rows(intRow).Item("ShowImg") = "<a href='#' onClick=""ShowImg('" & tblResult.Rows(intRow).Item("LocID") & "');"" border='0'><img src='../../Images/showimg.gif' title='" & lblImage & "' border='0'></a><br>" & tblResult.Rows(intRow).Item("ImgWidth") & " x " & tblResult.Rows(intRow).Item("ImgHeight")
                    End If
                Next
                GetHoldingLocSchema = tblResult
                strErrorMsg = objDLocation.ErrorMsg
                intErrorCode = objDLocation.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function


        'purpose: create new shelf on position of  location
        'in: 
        'out:
        'creator: lent
        'date : 8-3-2005
        Public Function CreateShelfPosition() As Integer
            Try
                objDLocation.LocID = intLocID
                objDLocation.Shelf = strShelf
                objDLocation.Width = intWidth
                objDLocation.Depth = intDepth
                objDLocation.TopCoor = intTopCoor
                objDLocation.LeftCoor = intLeftCoor
                objDLocation.Direction = intDirection
                CreateShelfPosition = objDLocation.CreateShelfPosition()
                strErrorMsg = objDLocation.ErrorMsg
                intErrorCode = objDLocation.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function
        'purpose: update shelf on position of  location
        'in: 
        'out:
        'creator: lent
        'date : 8-3-2005
        Public Function UpdateShelfPosition() As Integer
            Try
                objDLocation.LocID = intLocID
                objDLocation.Shelf = objBCSP.ConvertItBack(strShelf)
                objDLocation.Width = intWidth
                objDLocation.Depth = intDepth
                objDLocation.TopCoor = intTopCoor
                objDLocation.LeftCoor = intLeftCoor
                objDLocation.Direction = intDirection
                objDLocation.SelShelf = objBCSP.ConvertItBack(strSelShelf)
                UpdateShelfPosition = objDLocation.UpdateShelfPosition()
                strErrorMsg = objDLocation.ErrorMsg
                intErrorCode = objDLocation.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function
        'purpose: delete shelf on position of  location
        'in: 
        'out:
        'creator: lent
        'date : 8-3-2005
        Public Sub DeleteShelfPosition()
            Try
                objDLocation.LocID = intLocID
                objDLocation.Shelf = objBCSP.ConvertItBack(strShelf)
                Call objDLocation.DeleteShelfPosition()
                strErrorMsg = objDLocation.ErrorMsg
                intErrorCode = objDLocation.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Purpose : Get information Location's Shelf and its schema 
        ' Input: intLibID,intUserID
        ' Output: Datatable
        ' Created by: Lent
        ' date : 8-3-2005
        Public Function GetHoldingShelfSchema(ByVal lblDirection1 As String, ByVal lblDirection2 As String) As DataTable
            Dim tblResult As DataTable
            Dim intRow As Integer
            Try
                objDLocation.LocID = intLocID
                tblResult = objBCDBS.ConvertTable(objDLocation.GetHoldingShelfSchema)
                If Not tblResult Is Nothing Then
                    For intRow = 0 To tblResult.Rows.Count - 1
                        If tblResult.Rows(intRow).Item("Direction") = 0 Then
                            tblResult.Rows(intRow).Item("lbDirection") = lblDirection1
                        Else
                            tblResult.Rows(intRow).Item("lbDirection") = lblDirection2
                        End If
                    Next
                End If
                GetHoldingShelfSchema = tblResult
                strErrorMsg = objDLocation.ErrorMsg
                intErrorCode = objDLocation.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose : Get Holding Location of Library
        ' Input: intLibID, intStoreID,intUserID,intStatus
        ' Output: Datatable
        ' Created by: Lent
        ' date : 17-2-2005
        Public Function GetLocation() As DataTable
            Dim tblResult As DataTable
            Dim intRow As Integer

            Try
                objDLocation.LibID = intLibID
                objDLocation.UserID = intUserID
                objDLocation.LocID = intLocID
                objDLocation.Status = intStatus
                tblResult = objBCDBS.ConvertTable(objDLocation.GetLocation)
                If intLibID = 0 Then
                    For intRow = 0 To tblResult.Rows.Count - 1
                        tblResult.Rows(intRow).Item("Symbols") = tblResult.Rows(intRow).Item("Code") & "/" & tblResult.Rows(intRow).Item("Symbol")
                        tblResult.Rows(intRow).Item("Title") = "<B>" & tblResult.Rows(intRow).Item("Name") & "</B>(" & tblResult.Rows(intRow).Item("Code") & ")<br>" & tblResult.Rows(intRow).Item("Address")
                    Next
                End If
                GetLocation = tblResult
                strErrorMsg = objDLocation.ErrorMsg
                intErrorCode = objDLocation.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetLocation1() As DataTable
            Dim tblResult As DataTable
            Dim intRow As Integer

            Try
                If intLibID = 0 Then
                    objDLocation.LibID = 1
                Else
                    objDLocation.LibID = intLibID
                End If
                objDLocation.UserID = intUserID
                objDLocation.LocID = intLocID
                objDLocation.Status = intStatus
                tblResult = objBCDBS.ConvertTable(objDLocation.GetLocation)
                'If intLibID = 0 Then
                '    For intRow = 0 To tblResult.Rows.Count - 1
                '        tblResult.Rows(intRow).Item("Symbols") = tblResult.Rows(intRow).Item("Code") & "/" & tblResult.Rows(intRow).Item("Symbol")
                '        tblResult.Rows(intRow).Item("Title") = "<B>" & tblResult.Rows(intRow).Item("Name") & "</B>(" & tblResult.Rows(intRow).Item("Code") & ")<br>" & tblResult.Rows(intRow).Item("Address")
                '    Next
                'End If
                GetLocation1 = tblResult
                strErrorMsg = objDLocation.ErrorMsg
                intErrorCode = objDLocation.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetLocationBySymbol(ByVal strSymbol As String) As DataTable
            Try
                GetLocationBySymbol = objDLocation.GetLocationBySymbol(strSymbol)
                strErrorMsg = objDLocation.ErrorMsg
                intErrorCode = objDLocation.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetShelf() As DataTable
            Try
                objDLocation.LibID = intLibID
                objDLocation.LocID = intLocID
                GetShelf = objBCDBS.ConvertTable(objDLocation.GetShelf)
                strErrorMsg = objDLocation.ErrorMsg
                intErrorCode = objDLocation.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetGeneralInfor(ByVal bytMode As Byte) As DataTable
            Try
                objDLocation.LibID = intLibID
                objDLocation.LocID = intLocID
                objDLocation.Shelf = objBString.ConvertItBack(strShelf)
                GetGeneralInfor = objBCDBS.ConvertTable(objDLocation.GetGeneralInfor(bytMode))
                strErrorMsg = objDLocation.ErrorMsg
                intErrorCode = objDLocation.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function


        ' Purpose: get image of location and with its shelves 
        ' Output:img
        ' creator: Lent
        ' CreatedDate: 17/3/2005
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
                objC = imgShowLoc.XYChart(intImgWidth, intImgHeight)
                'Call objC.setWallpaper(strImgURL)
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
                        lngWidth = CLng(Math.Round((intImgWidth * CDbl(tblShelf.DefaultView(k).Item("Width"))) / (100 * dbImgWidthMetter)))
                        lngHeight = CLng(Math.Round((intImgHeight * CDbl(tblShelf.DefaultView(k).Item("Depth"))) / (100 * dbImgHeightMetter)))
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
                            objC1 = imgShowLoc.XYChart(intImgWidth, intImgHeight, imgShowLoc.Transparent)
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
                            lngWidth = CLng(Math.Round((intImgWidth * CDbl(tblShelf.DefaultView(k).Item("Width"))) / (100 * dbImgWidthMetter)))
                            lngHeight = CLng(Math.Round((intImgHeight * CDbl(tblShelf.DefaultView(k).Item("Depth"))) / (100 * dbImgHeightMetter)))
                            If Not CInt(tblShelf.DefaultView(k).Item("Direction")) = 0 Then
                                lngTemp = lngWidth
                                lngWidth = lngHeight
                                lngHeight = lngTemp
                            End If

                            ShelfTop = CInt(tblShelf.DefaultView(k).Item("TopCoor"))
                            ShelfLeft = CInt(tblShelf.DefaultView(k).Item("LeftCoor"))
                            ReDim Labels(0)
                            Labels(0) = tblShelf.DefaultView(k).Item("Shelf") & "" 'Split(tblShelf.DefaultView(k).Item("Shelf"), ",")
                            objC2 = imgShowLoc.XYChart(intImgWidth, intImgHeight, imgShowLoc.Transparent)
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

        'purpose: set order number in holding_location table
        'in: strLocIDs, maxNumbers
        'out: 
        'date : 25-3-2005
        Public Sub SetMaxID2Loc(ByVal strMaxNumber As String)
            Try
                objDLocation.LocIDs = strLocIDs
                Call objDLocation.SetMaxID2Loc(strMaxNumber)
                strErrorMsg = objDLocation.ErrorMsg
                intErrorCode = objDLocation.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Release resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                End If
                If Not objDLocation Is Nothing Then
                    objDLocation.Dispose(True)
                    objDLocation = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBString Is Nothing Then
                    objBString.Dispose(True)
                    objBString = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace