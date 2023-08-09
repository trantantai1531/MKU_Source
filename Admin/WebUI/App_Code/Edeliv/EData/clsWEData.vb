Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Edeliv
Imports System.IO
Imports GflAx193.GflAxClass
Imports MEDIAPROCESSORLib.MediaProcessorClass
Imports DSOleFile.PropertyReaderClass
Imports ABCpdf4

Namespace eMicLibAdmin.WebUI.Edeliv
    Public Class clsWEData
        Inherits clsWBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Protected lngID As Long = 0
        Protected strIDs As String = ""
        Protected strFileLocation As String = ""
        Protected lngFileSize As Long = 0
        Protected strCreatedDate As String = ""
        Protected strNote As String = ""
        Protected intExisted As Integer
        Protected intSecretLevel As Integer = 0
        Protected strLastModifiedBy As String = ""
        Protected intDownloadTime As Integer = 0
        Protected intMediaType As Integer = 0
        Protected strTitle As String = ""
        Protected strAuthor As String = ""
        Protected strDescription As String = ""
        Protected blnLocked As Boolean
        Protected strLockedBy As String = ""
        Protected strLockedDate As String = ""
        Protected intStatus As Integer = 0
        Protected intModifyTime As Integer = 0
        Protected intCollectionID As Integer = 0
        Protected strInputer As String = ""
        Protected dblPrice As Double = 0
        Protected strFormat As String = ""
        Protected intPageCount As Integer = 0
        Protected strCurrency As String = ""
        Protected lngStartID As Long = 0
        Protected intFree As Integer
        Protected intPageSize As Integer = 0
        Protected strParam As String = ""
        Private strCollection As String = ""
        Protected strSysDirs() As String

        Protected objBEData As New clsBEData
        Private objBCDBSYS As New clsBCommonDBSystem
        Private objBCSP As New clsBCommonStringProc

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' Collection property
        Public Property Collection() As String
            Get
                Return strCollection
            End Get
            Set(ByVal Value As String)
                strCollection = Value
            End Set
        End Property

        ' FileID property
        Public Property FileID() As Long
            Get
                Return lngID
            End Get
            Set(ByVal Value As Long)
                lngID = Value
            End Set
        End Property

        ' StartID property
        Public Property StartID() As Long
            Get
                Return lngStartID
            End Get
            Set(ByVal Value As Long)
                lngStartID = Value
            End Set
        End Property

        ' FileIDs property
        Public Property FileIDs() As String
            Get
                Return strIDs
            End Get
            Set(ByVal Value As String)
                strIDs = Value
            End Set
        End Property

        ' FileLocation property
        Public Property FileLocation() As String
            Get
                Return strFileLocation
            End Get
            Set(ByVal Value As String)
                strFileLocation = Value
            End Set
        End Property

        ' FileSize property
        Public Property FileSize() As Long
            Get
                Return lngFileSize
            End Get
            Set(ByVal Value As Long)
                lngFileSize = Value
            End Set
        End Property

        ' CreatedDate property
        Public Property CreatedDate() As String
            Get
                Return strCreatedDate
            End Get
            Set(ByVal Value As String)
                strCreatedDate = Value
            End Set
        End Property

        ' Note property
        Public Property Note() As String
            Get
                Return strNote
            End Get
            Set(ByVal Value As String)
                strNote = Value
            End Set
        End Property

        ' Existed property
        Public Property Existed() As Integer
            Get
                Return intExisted
            End Get
            Set(ByVal Value As Integer)
                intExisted = Value
            End Set
        End Property

        ' SecretLevel property
        Public Property SecretLevel() As Integer
            Get
                Return intSecretLevel
            End Get
            Set(ByVal Value As Integer)
                intSecretLevel = Value
            End Set
        End Property

        ' LastModifiedBy property
        Public Property LastModifiedBy() As String
            Get
                Return strLastModifiedBy
            End Get
            Set(ByVal Value As String)
                strLastModifiedBy = Value
            End Set
        End Property

        ' DownloadTime property
        Public Property DownloadTime() As Integer
            Get
                Return intDownloadTime
            End Get
            Set(ByVal Value As Integer)
                intDownloadTime = Value
            End Set
        End Property

        ' MediaType property
        Public Property MediaType() As Integer
            Get
                Return intMediaType
            End Get
            Set(ByVal Value As Integer)
                intMediaType = Value
            End Set
        End Property

        ' Title property
        Public Property Title() As String
            Get
                Return strTitle
            End Get
            Set(ByVal Value As String)
                strTitle = Value
            End Set
        End Property

        ' Author property
        Public Property Author() As String
            Get
                Return strAuthor
            End Get
            Set(ByVal Value As String)
                strAuthor = Value
            End Set
        End Property

        ' Description property
        Public Property Description() As String
            Get
                Return strDescription
            End Get
            Set(ByVal Value As String)
                strDescription = Value
            End Set
        End Property

        ' Locked property
        Public Property Locked() As Boolean
            Get
                Return blnLocked
            End Get
            Set(ByVal Value As Boolean)
                blnLocked = Value
            End Set
        End Property

        ' LockedBy property
        Public Property LockedBy() As String
            Get
                Return strLockedBy
            End Get
            Set(ByVal Value As String)
                strLockedBy = Value
            End Set
        End Property

        ' LockedDate property
        Public Property LockedDate() As String
            Get
                Return strLockedDate
            End Get
            Set(ByVal Value As String)
                strLockedDate = Value
            End Set
        End Property

        ' Status property
        Public Property Status() As Integer
            Get
                Return intStatus
            End Get
            Set(ByVal Value As Integer)
                intStatus = Value
            End Set
        End Property

        ' ModifyTime property
        Public Property ModifyTime() As Integer
            Get
                Return intModifyTime
            End Get
            Set(ByVal Value As Integer)
                intModifyTime = Value
            End Set
        End Property

        ' CollectionID property
        Public Property CollectionID() As Integer
            Get
                Return intCollectionID
            End Get
            Set(ByVal Value As Integer)
                intCollectionID = Value
            End Set
        End Property

        ' Free property
        Public Property Free() As Integer
            Get
                Return intFree
            End Get
            Set(ByVal Value As Integer)
                intFree = Value
            End Set
        End Property

        ' Inputer property
        Public Property Inputer() As String
            Get
                Return strInputer
            End Get
            Set(ByVal Value As String)
                strInputer = Value
            End Set
        End Property

        ' Price property
        Public Property Price() As Double
            Get
                Return dblPrice
            End Get
            Set(ByVal Value As Double)
                dblPrice = Value
            End Set
        End Property

        ' Format property
        Public Property Format() As String
            Get
                Return strFormat
            End Get
            Set(ByVal Value As String)
                strFormat = Value
            End Set
        End Property

        ' PageCount property
        Public Property PageCount() As Integer
            Get
                Return intPageCount
            End Get
            Set(ByVal Value As Integer)
                intPageCount = Value
            End Set
        End Property

        ' Currency property
        Public Property Currency() As String
            Get
                Return strCurrency
            End Get
            Set(ByVal Value As String)
                strCurrency = Value
            End Set
        End Property

        ' PageSize property
        Public Property PageSize() As Integer
            Get
                Return intPageSize
            End Get
            Set(ByVal Value As Integer)
                intPageSize = Value
            End Set
        End Property

        ' Param property
        Public Property Param() As String
            Get
                Return strParam
            End Get
            Set(ByVal Value As String)
                strParam = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Initialize method
        ' Purpose: Init all neccessary objects
        Public Sub Initialize()
            ' Init objBEData object
            objBEData.DBServer = Session("DBServer")
            objBEData.ConnectionString = Session("ConnectionString")
            objBEData.InterfaceLanguage = Session("InterfaceLanguage")
            objBEData.Initialize()

            ' Init objBCSP object
            objBCDBSYS.DBServer = Session("DBServer")
            objBCDBSYS.ConnectionString = Session("ConnectionString")
            objBCDBSYS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBSYS.Initialize()

            ' Init objBCSP object
            objBCSP.ConnectionString = Session("ConnectionString")
            objBCSP.InterfaceLanguage = Session("InterfaceLanguage")
            objBCSP.Initialize()
        End Sub

        ' CreateCollectionRecord method
        ' Purpose: Create record for Collection
        ' Output: Return 1 if success else return 0
        ' Creator: Tuanhv
        Public Function CreateCollectionRecord() As Integer
            Try
                objBEData.Collection = strCollection
                objBEData.Description = strDescription
                CreateCollectionRecord = objBEData.CreateCollectionRecord(strDescription)
                intErrorCode = objBEData.ErrorCode
                strErrorMsg = objBEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GroupCollection method
        ' Purpose: Create group record for Collection
        ' Output: Return 1 if success else return 0
        ' Creator: Tuanhv
        Public Function GroupCollection(ByVal strCollectionIDs As String) As Integer
            Try
                objBEData.CollectionID = intCollectionID
                GroupCollection = objBEData.GroupCollection(strCollectionIDs)
                intErrorCode = objBEData.ErrorCode
                strErrorMsg = objBEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' UpdateCollection method
        ' Purpose: Create group record for Collection
        ' Output: Return 1 if success else return 0
        ' Creator: Tuanhv
        Public Function UpdateCollection() As Integer
            Try
                objBEData.CollectionID = intCollectionID
                objBEData.Collection = strCollection
                objBEData.Description = strDescription
                UpdateCollection = objBEData.UpdateCollection
                intErrorCode = objBEData.ErrorCode()
                strErrorMsg = objBEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' DownLoad method
        Public Function DownLoad() As Integer
            Try
                objBEData.InitVariablesForEdataFile()
                objBEData.FileIDs = strIDs
                objBEData.DownloadTimes = 0
                objBEData.UpdateFileRecord()
                intErrorCode = objBEData.ErrorCode()
                strErrorMsg = objBEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function Delete(ByVal blnIsPhysicalRemove As Boolean) As Integer
            Dim objDirInfor As DirectoryInfo
            Dim objFileInfor As FileInfo
            Dim tblTemp As DataTable
            Dim intIndex As Integer
            Dim strTabNumb As String

            Try
                objBEData.FileIDs = strIDs
                tblTemp = objBEData.GetGeneralInfor(2, 0, 0, 0)

                If Not tblTemp Is Nothing Then
                    If tblTemp.Rows.Count > 0 Then
                        For intIndex = 0 To tblTemp.Rows.Count - 1
                            If Not IsDBNull(tblTemp.Rows(intIndex).Item("ItemID")) Then
                                If tblTemp.Rows(intIndex).Item("ItemID").ToString <> "" Then
                                    ' DELETE URL
                                    objBEData.FileID = tblTemp.Rows(intIndex).Item("ID")
                                    objBEData.GeneralDelete(0, 0, tblTemp.Rows(intIndex).Item("ItemID"), LCase("%WDownLoad.aspx?FileID=" & tblTemp.Rows(intIndex).Item("ID") & "%"), "", "", "", "")
                                    If Not IsDBNull(tblTemp.Rows(intIndex).Item("FieldCode")) Then
                                        If tblTemp.Rows(intIndex).Item("FieldCode") <> "" Then
                                            strTabNumb = "Field" & Left(tblTemp.Rows(intIndex).Item("FieldCode"), 1) & "00s"
                                            objBEData.FileID = tblTemp.Rows(intIndex).Item("ID")
                                            objBEData.GeneralDelete(1, 1, tblTemp.Rows(intIndex).Item("ItemID"), "", "", strTabNumb, LCase("%WDownLoad.aspx?FileID=" & tblTemp.Rows(intIndex).Item("ID") & "%"), "")
                                        End If
                                    End If
                                End If
                            End If
                            If blnIsPhysicalRemove = True Then
                                objFileInfor = New FileInfo(tblTemp.Rows(intIndex).Item("PhysicalPath"))
                                If objFileInfor.Exists Then
                                    objFileInfor.Delete()
                                End If
                            End If
                            objBEData.FileID = tblTemp.Rows(intIndex).Item("ID")
                            objBEData.GeneralDelete(2, 0, 0, "", "", "", "", "")
                        Next
                    End If
                End If
                intErrorCode = objBEData.ErrorCode
                strErrorMsg = objBEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' CreateMultimedia method
        ' Purpose:
        ' Creator:
        Public Function CreateMultimedia() As Integer
            Try


            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function CreateCollection() As Integer
            Try
                If Not strIDs = "" Then
                    If intCollectionID = 0 Then
                        intCollectionID = -2
                    Else
                        intCollectionID = CInt(CollectionID)
                    End If
                End If
                objBEData.InitVariablesForEdataFile()
                objBEData.FileIDs = strIDs
                objBEData.CollectionID = intCollectionID
                objBEData.UpdateFileRecord()
                intErrorCode = objBEData.ErrorCode
                strErrorMsg = objBEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function ChangeAccessMode() As Integer
            ChangeAccessMode = 0
            Try
                If Not strIDs = "" Then
                    objBEData.InitVariablesForEdataFile()
                    objBEData.FileIDs = strIDs
                    objBEData.Free = intFree
                    objBEData.UpdateFileRecord()
                    intErrorCode = objBEData.ErrorCode
                    strErrorMsg = objBEData.ErrorMsg
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
                ChangeAccessMode = 1
            End Try
        End Function

        Public Function ChangeItemType(ByVal intType As Integer) As Integer
            ChangeItemType = 0
            Try
                objBEData.FileIDs = strIDs
                objBEData.ChangeItemType(intType)
                intErrorCode = objBEData.ErrorCode
                strErrorMsg = objBEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
                ChangeItemType = 1
            End Try
        End Function

        Public Function MakePDF(ByVal strPath As String, ByVal strPdfName As String) As Integer
            'Dim objImage As GflAx193.GflAxClass
            'Dim objTheDoc As ABCpdf4.DocClass
            'Dim objDocImage As ABCpdf4.ImageClass
            'Dim tblTemp As DataTable
            'Dim intIndex As Integer
            'Dim intNewWidth As Integer
            'Dim intNewHeight As Integer
            'Dim intScaleX As Integer
            'Dim intScaleY As Integer
            'Dim blnIsResized As Boolean
            'Dim intCount As Integer

            'MakePDF = 0
            'Try
            '    ' Check the extension of file
            '    If Not Right(LCase(strPdfName), 4) = ".pdf" Then
            '        strPdfName = strPdfName & ".pdf"
            '    End If

            '    ' Check the free docs or not
            '    objBEData.FileIDs = strIDs

            '    tblTemp = objBEData.GetGeneralInfor(6, 0, 0, 0)

            '    If Not tblTemp Is Nothing Then
            '        If tblTemp.Rows.Count > 0 Then
            '            For intIndex = 0 To tblTemp.Rows.Count - 1
            '                objTheDoc.Page = objTheDoc.AddPage()
            '                objImage.EnableLZW = True
            '                If Not IsDBNull(tblTemp.Rows(intIndex).Item("PhysicalPath")) Then
            '                    objImage.LoadBitmap(tblTemp.Rows("intIndex").Item("PhysicalPath"))
            '                End If
            '                intNewWidth = objImage.Width
            '                intNewHeight = objImage.Height
            '                If intNewWidth > intNewHeight Then
            '                    intScaleX = 480
            '                    intScaleY = 650
            '                Else
            '                    intScaleX = 650
            '                    intScaleY = 480
            '                End If
            '                blnIsResized = False
            '                If objImage.Width > intScaleX Then
            '                    blnIsResized = True
            '                    intNewWidth = intScaleX
            '                    intNewHeight = (intNewWidth * objImage.Height) / objImage.Width
            '                End If
            '                If intNewHeight > intScaleY Then
            '                    blnIsResized = True
            '                    intNewWidth = (intNewWidth * intScaleY) / intNewHeight
            '                    intNewHeight = intScaleY
            '                End If
            '                If blnIsResized Then
            '                    objImage.Resize(intNewWidth, intNewHeight) 'Resize the picture
            '                End If
            '                objImage.SaveFormat = 3
            '                objDocImage.SetData(objImage.SendBinary)
            '                objTheDoc.Rect.Bottom = 100
            '                objTheDoc.Rect.Left = 100
            '                objTheDoc.Rect.Width = objImage.Width
            '                objTheDoc.Rect.Height = objImage.Height
            '                If objImage.Width > objImage.Height Then
            '                    objTheDoc.Transform.Rotate(90, 100, 100)
            '                    objTheDoc.Transform.Translate(objDocImage.Height, 0)
            '                End If
            '                objTheDoc.AddImageObject(objImage, False)
            '                If objImage.Width > objImage.Height Then
            '                    objTheDoc.Transform.Reset()
            '                End If
            '                objTheDoc.Rect.Resize(300, 500)
            '            Next
            '            intCount = objTheDoc.PageCount
            '            objTheDoc.HPos = 0.5
            '            objTheDoc.VPos = 0.5
            '            objTheDoc.FontSize = 24
            '            For intIndex = 1 To intCount
            '                objTheDoc.PageNumber = intIndex
            '                objTheDoc.AddText("Libol 6.5 digital image collection")
            '            Next
            '            objTheDoc.HPos = 1.0
            '            objTheDoc.VPos = 0.5
            '            objTheDoc.FontSize = 16
            '            intCount = objTheDoc.PageCount
            '            For intIndex = 1 To intCount
            '                objTheDoc.PageNumber = intIndex
            '                objTheDoc.AddText("Page " & intIndex & " of " & intCount)
            '            Next
            '            objTheDoc.Save(strPath & "\" & strPdfName)
            '            strFileLocation = strPath
            '            strIDs = ""

            '            Call Synchronize(False)
            '        Else
            '            MakePDF = 1
            '        End If
            '    Else
            '        MakePDF = 1
            '    End If
            '    intErrorCode = objBEData.ErrorCode
            '    strErrorMsg = objBEData.ErrorMsg
            'Catch ex As Exception
            '    strErrorMsg = ex.Message
            'End Try
        End Function

        ' UpdateEDataInfor method
        ' Purpose:
        ' Creator:
        Public Function UpdateEDataInfor() As Integer
            Try

            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function SetSecretLevel() As Integer
            Try
                If strIDs <> "" And intSecretLevel >= 0 And intSecretLevel <= 9 Then
                    objBEData.InitVariablesForEdataFile()
                    objBEData.FileIDs = strIDs
                    objBEData.SecretLevel = intSecretLevel
                    objBEData.UpdateFileRecord()
                End If
                intErrorCode = objBEData.ErrorCode
                strErrorMsg = objBEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetTotalOfFiles() As Integer
            Try

            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function ChangeStatus() As Integer
            Try
                If strIDs <> "" And intStatus > 0 And intStatus <= 4 Then
                    objBEData.InitVariablesForEdataFile()
                    objBEData.FileIDs = strIDs
                    objBEData.Status = intStatus
                    objBEData.UpdateFileRecord()
                End If
                intErrorCode = objBEData.ErrorCode
                strErrorMsg = objBEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Synchronize method
        ' Purpose: get the list of file in the input location, then update or insert the right data 
        '           blnIsAll: if all record from database will be checked
        '           UPDATE to not exist = true when "the file in database not existed"
        '           INSERT when "not found file location in the database"
        '           UPDATE the file infor when "find the file location in the database and the physical file is exist"
        Public Function Synchronize(ByVal blnIsAll As Boolean) As Integer
            ' Declare variables
            Dim tblTemp As DataTable
            Dim intIndex As Integer
            Dim objDirInfor As DirectoryInfo
            Dim objFileInfor As FileInfo
            Dim dv As New DataView
            Dim blnToSync As Boolean
            Dim intMediaType As Integer
            Dim strFilename As String
            Dim strFileToSave As String
            Dim strExtension As String
            Dim strBipmapType As String = ""
            Dim strColorModel As String = ""
            Dim intWidth As Integer = 0
            Dim intHeight As Integer = 0
            Dim shtXdpi As Short = 0
            Dim shtYdpi As Short = 0
            Dim dblDuration As Double
            Dim intNoColorUsed As Long = 0
            Dim intPageCount As Integer
            Dim strAlbum As String
            Dim strArtist As String
            Dim strComment As String
            Dim strGenre As String
            Dim intBitRate As Integer

            Synchronize = 0
            Try
                ' Get the file infor (For synchronize)
                objBEData.FileIDs = strIDs
                objBEData.Param = strParam

                tblTemp = objBEData.GetGeneralInfor(5, 0, 0, 0)

                ' Check the data
                If Not tblTemp Is Nothing Then
                    If tblTemp.Rows.Count > 0 Then
                        For intIndex = 0 To tblTemp.Rows.Count - 1
                            ' Check the file is existed or not
                            objFileInfor = New FileInfo(tblTemp.Rows(intIndex).Item("PhysicalPath"))
                            ' If the file is not existed
                            If Not objFileInfor.Exists And Not CBool(tblTemp.Rows(intIndex).Item("Existed")) = False Then
                                objBEData.InitVariablesForEdataFile()
                                objBEData.FileIDs = CStr(tblTemp.Rows(intIndex).Item("ID"))
                                objBEData.Existed = 0
                                objBEData.Status = 4
                                objBEData.UpdateFileRecord()
                            ElseIf objFileInfor.Exists And Not CBool(tblTemp.Rows(intIndex).Item("Existed")) = True Then
                                objBEData.InitVariablesForEdataFile()
                                objBEData.FileIDs = CStr(tblTemp.Rows(intIndex).Item("ID"))
                                objBEData.Existed = 1
                                objBEData.UpdateFileRecord()
                            End If
                        Next
                    End If
                End If

                ' Get the files infor from the input physical directory
                objDirInfor = New DirectoryInfo(strParam)

                For Each objFileInfor In objDirInfor.GetFiles("*.*")
                    blnToSync = False
                    strFilename = objFileInfor.Name
                    strFileToSave = Replace(strParam & "\", "\\", "\") & LCase(strFilename)

                    dv.Table = tblTemp
                    dv.RowFilter = "PhysicalPath='" & objBCSP.ConvertItBack(strFileToSave, True) & "'"
                    If dv.Count > 0 Then
                        lngID = CLng(dv.Item(0).Row("ID"))
                        If blnIsAll = True Then
                            blnToSync = True
                        ElseIf InStr(", " & strIDs & ", ", ", " & CStr(lngID) & ", ") > 0 Then
                            blnToSync = True
                        End If
                        If blnToSync Then
                            objBEData.InitVariablesForEdataFile()
                            objBEData.FileIDs = CStr(lngID)
                            objBEData.FileSize = objFileInfor.Length
                            objBEData.Existed = 1
                            objBEData.FileName = objFileInfor.Name
                            objBEData.UpdateFileRecord()
                            objBEData.FileID = lngID
                            objBEData.GeneralDelete(3, 0, 0, "", "", "", "", "")
                            intMediaType = GetFileMediaType(strFileToSave)
                        End If
                    Else
                        blnToSync = True
                        intMediaType = GetFileMediaType(strFileToSave)
                        lngFileSize = objFileInfor.Length
                        objBEData.InitVariablesForEdataFile()
                        objBEData.PhysicalPath = strFileToSave
                        objBEData.FileLocation = strParam
                        objBEData.FileName = strFilename
                        objBEData.URL = strFileToSave
                        objBEData.FileSize = lngFileSize
                        objBEData.UploadedBy = clsSession.GlbUserFullName
                        objBEData.MediaType = intMediaType
                        objBEData.CreateFileRecord()
                        lngID = objBEData.FileID
                    End If
                    If blnToSync Then
                        Call GetFileInfor(strFileToSave, strBipmapType, strColorModel, intWidth, intHeight, shtXdpi, shtYdpi, intNoColorUsed, dblDuration, strAlbum, strArtist, strComment, strGenre, intPageCount, strTitle, strAuthor, strDescription, intBitRate)
                        Select Case intMediaType
                            Case 1
                                ' Get the image infor
                                objBEData.InitVariablesForMultimedia()
                                objBEData.FileID = lngID
                                objBEData.BitmapType = CInt(strBipmapType)
                                objBEData.ColorModel = strColorModel
                                objBEData.ImgWidth = intWidth
                                objBEData.ImgHeight = intHeight
                                objBEData.Xdpi = shtXdpi
                                objBEData.Ydpi = shtYdpi
                                objBEData.NoColorUsed = intNoColorUsed
                                objBEData.CreateMultimedia()

                            Case 2
                                ' Get the display media infor
                                objBEData.InitVariablesForMultimedia()
                                dblDuration = Math.Round(dblDuration, 2)
                                objBEData.FileID = lngID
                                intMediaType = 2
                                objBEData.ImgWidth = intWidth
                                objBEData.ImgHeight = intHeight
                                objBEData.Duration = dblDuration
                                objBEData.CreateMultimedia()
                            Case 3
                                ' Get the sound media infor
                                dblDuration = Math.Round(dblDuration, 2)
                                If strAlbum = "unknown" Then
                                    strAlbum = ""
                                End If
                                If strArtist = "unknown" Then
                                    strArtist = ""
                                End If
                                If LCase(strAuthor) = "unknown" Then
                                    strAuthor = ""
                                End If
                                If LCase(strComment) = "unknown" Then
                                    strComment = ""
                                End If
                                If LCase(strGenre) = "unknown" Then
                                    strGenre = ""
                                End If
                                If LCase(strDescription) = "unknown" Then
                                    strDescription = ""
                                End If
                                If LCase(strTitle) = "unknown" Then
                                    strTitle = ""
                                End If
                                objBEData.InitVariablesForMultimedia()
                                objBEData.FileID = lngID
                                objBEData.Duration = dblDuration
                                objBEData.Album = strAlbum
                                objBEData.Artist = strArtist
                                objBEData.BitRate = intBitRate
                                objBEData.Genre = strGenre

                                Dim intRetVal As Integer

                                intRetVal = objBEData.CreateMultimedia()
                                If intRetVal = 0 Then
                                    If Not Trim(strTitle) = "" Or Not Trim(strDescription) = "" Or Not Trim(strAuthor) = "" Then
                                        objBEData.InitVariablesForEdataFile()
                                        objBEData.FileIDs = CStr(lngID)
                                        objBEData.Title = strTitle
                                        objBEData.Description = strDescription
                                        objBEData.Author = strAuthor
                                        objBEData.UpdateFileRecord()
                                    End If
                                End If
                            Case 4
                                If Not CStr(intPageCount) = "" Then
                                    objBEData.InitVariablesForMultimedia()
                                    objBEData.FileID = lngID
                                    objBEData.PageCount = intPageCount
                                    objBEData.CreateMultimedia()

                                    objBEData.InitVariablesForEdataFile()
                                    objBEData.FileIDs = CStr(lngID)
                                    If Not Trim(strTitle) = "" Or Not Trim(strDescription) = "" Or Not Trim(strAuthor) = "" Then
                                        objBEData.Title = strTitle
                                        objBEData.Description = strDescription
                                        objBEData.Author = strAuthor
                                    End If
                                    objBEData.Pagination = CStr(intPageCount)
                                    objBEData.UpdateFileRecord()
                                End If
                        End Select
                    End If
                Next
                strErrorMsg = objBEData.ErrorMsg
                intErrorCode = objBEData.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function Move(ByVal strDestloc As String, ByVal blnIsPhysicalMove As Boolean) As Integer
            ' Declare variables
            Dim tblTemp As DataTable
            Dim objDirectoryInfor As DirectoryInfo
            Dim objFileInfor As FileInfo
            Dim i As Integer

            Move = 0
            Try
                If blnIsPhysicalMove = True Then
                    ' Folder is empty
                    If strDestloc = "" Then
                        Move = 1
                        Exit Function
                    End If
                    ' Get the folder URL string
                    If Right(strDestloc, 1) = "\" Then
                        strDestloc = Left(strDestloc, Len(strDestloc) - 1)
                    End If
                    ' Check the existing of folder
                    objDirectoryInfor = New DirectoryInfo(strDestloc)
                    If Not objDirectoryInfor.Exists Then
                        Move = 2
                        Exit Function
                    End If
                    ' Check the folder is belong the system dirs or not
                    If CheckSysDir(strDestloc) = False Then
                        Move = 3
                        Exit Function
                    End If
                    objBEData.FileIDs = strIDs
                    objBEData.Param = strParam

                    tblTemp = objBEData.GetGeneralInfor(1, 0, 0, 0)
                End If

                ' Update
                If Not tblTemp Is Nothing Then
                    If tblTemp.Rows.Count > 0 Then
                        For i = 0 To tblTemp.Rows.Count - 1
                            objFileInfor = New FileInfo(tblTemp.Rows(i).Item("PhysicalPath"))

                            If objFileInfor.Exists Or blnIsPhysicalMove = False Then
                                If blnIsPhysicalMove = True Then
                                    Dim objFileInforDes As New FileInfo(strDestloc & "\" & objFileInfor.Name)
                                    If objFileInforDes.Exists = False Then
                                        objFileInfor.MoveTo(strDestloc & "\" & objFileInfor.Name)
                                    End If
                                End If
                                objBEData.InitVariablesForEdataFile()
                                objBEData.FileIDs = tblTemp.Rows(i).Item("ID")
                                objBEData.PhysicalPath = strDestloc & "\" & objFileInfor.Name
                                objBEData.FileLocation = strDestloc
                                objBEData.URL = strDestloc & "\" & objFileInfor.Name
                                objBEData.UpdateFileRecord()
                            End If
                        Next
                    End If
                End If
                strErrorMsg = objBEData.ErrorMsg
                intErrorCode = objBEData.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function Rename(ByVal strLocation As String, ByVal strFolderName As String, ByRef strNewFolder As String) As Boolean
            Dim objDirInfor As DirectoryInfo
            Dim objDirCheck As DirectoryInfo
            Dim strOldFolder As String

            Rename = False
            Try
                If Trim(strFolderName) = "" Then
                    strFolderName = "NULL"
                End If
                objDirInfor = New DirectoryInfo(strLocation)
                If objDirInfor.Exists Then
                    strOldFolder = objDirInfor.Parent.FullName & "\" & objDirInfor.Name

                    If Right(objDirInfor.FullName, 2) = ":\" Then
                        strNewFolder = LCase(objDirInfor.Parent.FullName & "\" & strFolderName)
                    Else
                        strNewFolder = LCase(objDirInfor.Parent.FullName & "\" & strFolderName)
                    End If

                    objDirCheck = New DirectoryInfo(strNewFolder)
                    If Not objDirCheck.Exists Then
                        objDirInfor.MoveTo(strNewFolder)
                        objBEData.UpdateFileLoc(LCase(strOldFolder), strNewFolder)
                        Rename = True
                    End If
                End If
                strErrorMsg = objBEData.ErrorMsg
                intErrorCode = objBEData.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function DeleteFolder(ByVal strLocation As String, ByVal blnIsLogicalRemove As Boolean) As Integer
            Dim objDirInfor As DirectoryInfo
            Dim objFileInfor As FileInfo
            Dim tblTemp As DataTable
            Dim intIndex As Integer
            Dim strTabNumb As String = ""
            Dim objFile As FileInfo

            DeleteFolder = 0
            Try
                If Trim(strLocation) <> "" Then
                    objDirInfor = New DirectoryInfo(strLocation)

                    If objDirInfor.Exists Then
                        objDirInfor.GetFiles()
                        If objDirInfor.GetFiles.Length > 0 Then
                            For Each objFile In objDirInfor.GetFiles()
                                objFile.Delete()
                            Next
                        End If
                        objDirInfor.Delete()
                        If blnIsLogicalRemove Then
                            objBEData.FileIDs = ""
                            objBEData.Param = strLocation

                            tblTemp = objBEData.GetGeneralInfor(0, 0, 0, 0)

                            If Not tblTemp Is Nothing Then
                                If tblTemp.Rows.Count > 0 Then
                                    For intIndex = 0 To tblTemp.Rows.Count - 1
                                        If Not IsDBNull(tblTemp.Rows(intIndex).Item("FieldCode")) Then
                                            If tblTemp.Rows(intIndex).Item("FieldCode") <> "" Then
                                                strTabNumb = "Field" & Left(tblTemp.Rows(intIndex).Item("FieldCode"), 1) & "00s"
                                            End If
                                        End If
                                        objBEData.FileID = tblTemp.Rows(intIndex).Item("ID")
                                        If Not IsDBNull(tblTemp.Rows(intIndex).Item("ItemID")) Then
                                            objBEData.GeneralDelete(0, 0, tblTemp.Rows(intIndex).Item("ItemID"), LCase("%WDownLoad.aspx?FileID=" & tblTemp.Rows(intIndex).Item("ID") & "%"), strTabNumb, "", "", "")
                                        Else
                                            objBEData.GeneralDelete(0, 0, 0, LCase("%WDownLoad.aspx?FileID=" & tblTemp.Rows(intIndex).Item("ID") & "%"), strTabNumb, "", "", "")
                                        End If
                                    Next
                                End If
                            End If
                        End If
                    Else
                        DeleteFolder = 1
                    End If
                    strErrorMsg = objBEData.ErrorMsg
                    intErrorCode = objBEData.ErrorCode
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' CreateSubFolder method 
        ' Purpose: Create New sub Folder
        Public Function CreateSubFolder(ByVal strPath As String, ByVal strFolderName As String) As Boolean
            Dim objDirInfor As DirectoryInfo
            Dim objExistDir As DirectoryInfo

            CreateSubFolder = False

            Try
                objDirInfor = New DirectoryInfo(strPath)
                objExistDir = New DirectoryInfo(strPath & "\" & strFolderName)
                If objDirInfor.Exists Then
                    If Not objExistDir.Exists Then
                        objDirInfor.CreateSubdirectory(strFolderName)
                        CreateSubFolder = True
                    End If
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Function CheckSysDir(ByVal strLoc) As Boolean
            Dim strURLPaths() As String
            Dim i As Integer

            Try
                CheckSysDir = False
                If Not objSysPara(7).ToString.Trim = "" Then
                    strSysDirs = Split(objSysPara(7).Trim, ";")
                    If Not strSysDirs Is Nothing AndAlso UBound(strSysDirs) > 0 Then
                        For i = LBound(strSysDirs) To UBound(strSysDirs) - 1
                            If InStr(LCase(strLoc & "\"), LCase(Replace(strSysDirs(i), "/", "\"))) > 0 Then
                                CheckSysDir = True
                                Exit Function
                            End If
                        Next
                    End If
                End If
            Catch ex As Exception
                CheckSysDir = False
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Sub GetFileInfor(ByVal strFilePath As String, ByRef strBipmapType As String, ByRef strColorModel As String, ByRef intWidth As Integer, ByRef intHeight As Integer, ByRef shtXdpi As Short, ByRef shtYdpi As Short, ByRef intNoColorUsed As Long, ByRef dblDuration As Double, ByRef strAlbum As String, ByRef strArtist As String, ByRef strComment As String, ByRef strGenre As String, ByRef intPageCount As Integer, ByRef strTitle As String, ByRef strAuthor As String, ByRef strDescription As String, ByRef intBitRate As Integer)
            Dim strFileExtension As String
            strFileExtension = LCase(Right(strFilePath, Len(strFilePath) - InStrRev(strFilePath, ".")))
            Try
                Select Case strFileExtension
                    Case "bmp", "gif", "jpg", "jpeg", "tif", "pcx", "png", "jpe"
                        Call GetImageInfor(strFilePath, strBipmapType, strColorModel, intWidth, intHeight, shtXdpi, shtYdpi, intNoColorUsed)
                    Case "mpg", "avi", "asf", "mpeg", "mov", "flc", "mpv", "swf"
                        Call GetMediaInfor(strFilePath, intWidth, intHeight, dblDuration)
                    Case "mp3", "wav"
                        Call GetSoundInfor(strFilePath, strAlbum, strArtist, dblDuration, strComment, strGenre, intBitRate)
                    Case "pdf"
                        Call GetPdfInfor(strFilePath, intPageCount)
                    Case "doc", "xsl", "ppt", "pps"
                        Call GetDocInfor(strFilePath, strTitle, strAuthor, strDescription, intPageCount)
                    Case "exe"
                    Case Else
                End Select
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Sub ImportEData(ByVal strLocation As String, ByVal strFile As String)
            Try
                ' Get MediaType
                intMediaType = GetFileMediaType(Replace(strLocation & "\", "\\", "\") & strFile)
                Call ImportFile(strLocation, strFile, intMediaType)
                strErrorMsg = objBEData.ErrorMsg
                intErrorCode = objBEData.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
                strErrorMsg = objBEData.ErrorCode
            End Try
        End Sub

        Public Sub ImportFile(ByVal strLocation As String, ByVal strFileName As String, ByVal intMediaType As Integer)
            ' Declare variables
            Dim tblFile As DataTable
            Dim objFileInfor As FileInfo
            Dim strFilePath As String = ""
            Dim lngFileSize As Long = 0
            Dim lngID As Long
            Dim strExtension As String
            Dim strBipmapType As String
            Dim strColorModel As String
            Dim intWidth As Integer
            Dim intHeight As Integer
            Dim shtXdpi As Short
            Dim shtYdpi As Short
            Dim dblDuration As Double
            Dim intNoColorUsed As Long
            Dim intPageCount As Integer
            Dim strAlbum As String
            Dim strArtist As String
            Dim strComment As String
            Dim strGenre As String
            Dim intBitRate As Integer

            Try
                ' Get existed file infor in database

                strFilePath = Replace(strLocation & "\", "\\", "\") & strFileName

                objFileInfor = New FileInfo(strFilePath)
                lngFileSize = objFileInfor.Length
                objBEData.InitVariablesForEdataFile()

                objBEData.Param = strFilePath
                tblFile = objBEData.GetGeneralInfor(5, 0, 0, 0, 3)

                objBEData.FileName = strFileName
                objBEData.PhysicalPath = Replace(strLocation & "\", "\\", "\") & strFileName
                objBEData.URL = Replace(strLocation & "\", "\\", "\") & strFileName
                objBEData.FileLocation = strLocation
                objBEData.FileSize = lngFileSize
                objBEData.UploadedBy = clsSession.GlbUserFullName
                objBEData.FileFormat = Right(strFileName, Len(strFileName) - InStrRev(strFileName, "."))

                If Right(Trim(strLocation), 1) = "\" Then
                    strLocation = Left(Trim(strLocation), Len(Trim(strLocation)) - 1)
                End If

                objBEData.FileLocation = strLocation
                objBEData.MediaType = intMediaType

                ' insert to edata file table
                If Not tblFile Is Nothing Then
                    If tblFile.Rows.Count > 0 Then
                        lngID = tblFile.Rows(0).Item("ID")
                        objBEData.FileID = lngID
                        objBEData.FileIDs = CStr(lngID)
                        objBEData.UpdateFileRecord()
                        objBEData.GeneralDelete(3, 0, 0, "", "", "", "", "")
                    Else
                        objBEData.CreateFileRecord()
                        lngID = objBEData.FileID
                    End If
                Else
                    objBEData.CreateFileRecord()
                    lngID = objBEData.FileID
                End If

                objBEData.InitVariablesForMultimedia()
                ' Get the phisical infor of file
                Call GetFileInfor(strFilePath, strBipmapType, strColorModel, intWidth, intHeight, shtXdpi, shtYdpi, intNoColorUsed, dblDuration, strAlbum, strArtist, strComment, strGenre, intPageCount, strTitle, strAuthor, strDescription, intBitRate)
                Select Case intMediaType
                    Case 1 ' "bmp", "gif", "jpg", "jpeg", "tif", "pcx", "png", "jpe"
                        objBEData.BitmapType = CInt(strBipmapType)
                        objBEData.ColorModel = strColorModel
                        objBEData.ImgWidth = intWidth
                        objBEData.ImgHeight = intHeight
                        objBEData.Xdpi = shtXdpi
                        objBEData.Ydpi = shtYdpi
                        objBEData.NoColorUsed = intNoColorUsed
                    Case 2 ' "mpg", "avi", "asf", "mpeg", "mov", "flc", "mpv", "swf"
                        objBEData.ImgWidth = intWidth
                        objBEData.ImgHeight = intHeight
                        objBEData.Duration = dblDuration
                    Case 3 ' "mp3", "wav"
                        If Not Trim(strTitle) = "" Or Not Trim(strDescription) = "" Or Not Trim(strAuthor) = "" Then
                            objBEData.InitVariablesForEdataFile()
                            objBEData.FileID = lngID
                            objBEData.Title = strTitle
                            objBEData.Description = strDescription
                            objBEData.Author = strAuthor
                            objBEData.UpdateFileRecord()
                        End If
                        objBEData.Duration = dblDuration
                        objBEData.Album = strAlbum
                        objBEData.Artist = strArtist
                        objBEData.BitRate = intBitRate
                        objBEData.Genre = strGenre
                    Case 4 ' "doc", "pdf", "ps", "html", "htm", "rtf", "txt", "ppt", "pps", "xls"
                        If Not Trim(strTitle) = "" Or Not Trim(strDescription) = "" Or Not Trim(strAuthor) = "" Then
                            objBEData.InitVariablesForEdataFile()
                            objBEData.FileIDs = CStr(lngID)
                            objBEData.Title = strTitle
                            objBEData.Description = strDescription
                            objBEData.Author = strAuthor
                            objBEData.UpdateFileRecord()
                        End If
                        objBEData.PageCount = intPageCount
                        objBEData.Pagination = CStr(intPageCount)
                End Select
                ' Create new multimedia record of file
                objBEData.FileID = lngID
                objBEData.CreateMultimedia()
                strErrorMsg = objBEData.ErrorMsg
                intErrorCode = objBEData.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
        End Sub

        ' GetFileMediaType method
        ' Purpose: Get media file type by inputting full file name
        Public Function GetFileMediaType(ByVal strFilePath As String) As Integer
            Dim intMediaType As Integer
            Dim strExtension As String

            strExtension = LCase(Right(strFilePath, Len(strFilePath) - InStrRev(strFilePath, ".")))
            Try
                Select Case strExtension
                    Case "bmp", "gif", "jpg", "jpeg", "tif", "pcx", "png", "jpe"
                        intMediaType = 1
                    Case "mpg", "avi", "asf", "mpeg", "mov", "flc", "mpv", "swf"
                        intMediaType = 2
                    Case "mp3", "wav"
                        intMediaType = 3
                    Case "doc", "pdf", "ps", "html", "htm", "rtf", "txt", "ppt", "pps", "xls"
                        intMediaType = 4
                    Case "exe"
                        intMediaType = 6
                    Case Else
                        intMediaType = 7
                End Select
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                GetFileMediaType = intMediaType
            End Try

        End Function

        Public Sub GetImageInfor(ByVal strFilePath As String, ByRef strBipmapType As String, ByRef strColorModel As String, ByRef intWidth As Integer, ByRef intHeight As Integer, ByRef shtXdpi As Short, ByRef shtYdpi As Short, ByRef intNoColorUsed As Long)
            'Dim objImg As New GflAx193.GflAxClass
            'Try
            '    ' Get the image infor
            '    With objImg
            '        .EnableLZW = True
            '        .LoadBitmap(strFilePath)
            '        strBipmapType = CStr(.BitmapType)
            '        strColorModel = .ColorModel
            '        intWidth = .Width
            '        intHeight = .Height
            '        shtXdpi = .Xdpi
            '        shtYdpi = .Ydpi
            '        intNoColorUsed = .NumberOfColorsUsed
            '    End With
            'Catch ex As Exception
            '    strErrorMsg = ex.Message
            'End Try
        End Sub

        Public Sub GetMediaInfor(ByVal strFilePath As String, ByRef intWidth As Integer, ByRef intHeight As Integer, ByRef dblDuration As Double)
            Dim objInfoRetriever As New MEDIAPROCESSORLib.InfoRetrieverClass
            Try
                ' The display media infor
                objInfoRetriever.RetrieveInfo(strFilePath)
                intWidth = objInfoRetriever.Width
                intHeight = objInfoRetriever.Height
                dblDuration = Math.Round(objInfoRetriever.Duration, 2)
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Sub GetSoundInfor(ByVal strFilePath As String, ByRef strAlbum As String, ByRef strArtist As String, ByRef dblDuration As Double, ByRef strComment As String, ByRef strGenre As String, ByVal intBitRate As Integer)
            Dim objInfoRetriever As New MEDIAPROCESSORLib.InfoRetrieverClass
            Try
                ' The sound media infor
                objInfoRetriever.RetrieveInfo(strFilePath)
                If Not LCase(objInfoRetriever.Album) = "unknown" Then
                    strAlbum = objBCSP.ToUTF8Back(objInfoRetriever.Album)
                End If
                If Not LCase(objInfoRetriever.Artist) = "unknown" Then
                    strArtist = objBCSP.ToUTF8Back(objInfoRetriever.Artist)
                End If
                If Not LCase(objInfoRetriever.Author) = "unknown" Then
                    strAuthor = objBCSP.ToUTF8Back(objInfoRetriever.Author)
                End If
                If Not LCase(objInfoRetriever.Comment) = "unknown" Then
                    strComment = objBCSP.ToUTF8Back(objInfoRetriever.Comment)
                End If
                dblDuration = Math.Round(objInfoRetriever.Duration, 2)
                If Not LCase(objInfoRetriever.Genre) = "unknown" Then
                    strGenre = objBCSP.ToUTF8Back(objInfoRetriever.Genre)
                End If
                If Not LCase(objInfoRetriever.ShortDescr) = "unknown" Then
                    strDescription = objBCSP.ToUTF8Back(objInfoRetriever.ShortDescr)
                End If
                If Not LCase(objInfoRetriever.Title) = "unknown" Then
                    strTitle = objBCSP.ToUTF8Back(objInfoRetriever.Title)
                End If
                intBitRate = objInfoRetriever.BitRate
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Sub GetPdfInfor(ByVal strFilePath As String, ByRef intPageCount As Integer)
            'Dim objDoc As New ABCpdf4.Doc

            '' The PDF infor
            'objDoc.Read(strFilePath)
            'intPageCount = objDoc.PageCount
        End Sub

        Public Sub GetDocInfor(ByVal strFilePath As String, ByRef strTitle As String, ByRef strAuthor As String, ByRef strDescription As String, ByRef intPageCount As Integer)
            Dim objFilePropReader As New DSOleFile.PropertyReaderClass
            Dim objDocProp As DSOleFile.DocumentProperties

            objDocProp = objFilePropReader.GetDocumentProperties(strFilePath)

            If Not Trim(objDocProp.Title) = "" Then
                strTitle = objBCSP.ToUTF8Back(objDocProp.Title)
            End If
            If Not Trim(objDocProp.Author) = "" Then
                strAuthor = objBCSP.ToUTF8Back(objDocProp.Author)
            End If
            If Not Trim(objDocProp.Comments) = "" Then
                strDescription = objBCSP.ToUTF8Back(objDocProp.Comments)
            End If
            If strAuthor = "" And Not Trim(objDocProp.Company) = "" Then
                strAuthor = objBCSP.ToUTF8Back(objDocProp.Company)
            End If
            intPageCount = objDocProp.PageCount
        End Sub

        ' GetGeneraInfor method
        ' Purpose: Get general infor of file (File Name, Size,...)
        ' Output: 
        ' Output: datatable result
        Public Function GetGeneralInfor(ByVal intMode As Int16, ByVal intListType As Int16, ByVal intViewMode As Int16, ByRef lngTotalRec As Long, Optional ByVal intType As Int16 = -1) As DataTable
            Try
                objBEData.FileIDs = strIDs
                objBEData.StartID = lngStartID
                objBEData.PageSize = intPageSize
                objBEData.CollectionID = intCollectionID
                objBEData.Param = strParam
                GetGeneralInfor = objBEData.GetGeneralInfor(intMode, intListType, intViewMode, lngTotalRec, intType)
                intErrorCode = objBEData.ErrorCode
                strErrorMsg = objBEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetMinIDByTopNum method
        ' Purpose: Get the min ID of the page having a top number
        ' Output: datatable result
        ' Creator:
        Public Function GetMaxIDByTopNum(ByVal intListType As Integer, ByVal lngTopNum As Long, Optional ByVal intFree As Integer = -1) As Long
            Dim lngMaxID As Long = 0
            Try
                objBEData.Status = intStatus
                objBEData.Param = strParam
                objBEData.CollectionID = intCollectionID
                lngMaxID = objBEData.GetMaxIDByTopNum(intListType, lngTopNum, intFree).Rows(0).Item(0)
                intErrorCode = objBEData.ErrorCode
                strErrorMsg = objBEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            GetMaxIDByTopNum = lngMaxID
        End Function

        Public Function GetSizeOfDirectory(ByVal strPath As String) As Long
            Dim lngSizeOfDir As Long
            Dim objDir As DirectoryInfo = New DirectoryInfo(strPath)
            Dim objSubDir As DirectoryInfo

            ' Add the size of each file
            Dim objFile As FileInfo
            If objDir.GetFiles.Length > 0 Then
                For Each objFile In objDir.GetFiles()
                    lngSizeOfDir = lngSizeOfDir + objFile.Length
                    ' Add the size of each subdirectory, retrieved by 
                    ' recursively calling this same function
                    For Each objSubDir In objDir.GetDirectories
                        lngSizeOfDir = lngSizeOfDir + GetSizeOfDirectory(objSubDir.FullName)
                    Next
                Next
            Else
                ' Add the size of each subdirectory, retrieved by 
                ' recursively calling this same function
                For Each objSubDir In objDir.GetDirectories
                    lngSizeOfDir = lngSizeOfDir + GetSizeOfDirectory(objSubDir.FullName)
                Next
            End If

            Return lngSizeOfDir
        End Function

        ' FormatSize method
        ' Purpose: show size of file, directory in suite format
        ' Input: FileSize
        ' Output: String value
        Protected Function FormatSize(ByVal dblFileSize As Double) As String
            If dblFileSize < 1024 Then
                Return String.Format("{0:N0} B", dblFileSize)
            ElseIf (dblFileSize < 1024 * 1024) Then
                Return String.Format("{0:N2} KB", dblFileSize / 1024)
            Else
                Return String.Format("{0:N2} MB", dblFileSize / (1024 * 1024))
            End If
        End Function

        ' AttachEdata method
        ' Purpose: Attach file edata 
        ' Output: Return 1 if attach success else return 0
        ' Creator: Tuanhv
        Public Function AttachEdata(ByVal strItemCode As String, ByVal strFileIDSelect As String) As Integer
            Try
                AttachEdata = objBEData.AttachEdata(strItemCode, strFileIDSelect)
                intErrorCode = objBEData.ErrorCode
                strErrorMsg = objBEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function DetachFile(ByVal strFileIDSelect As String) As Integer
            Try
                DetachFile = objBEData.DetachFile(strFileIDSelect)
                intErrorCode = objBEData.ErrorCode
                strErrorMsg = objBEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetEdataSearchCount function
        ' Purpose: Get count of edata searched
        Public Function GetEdataSearchCount(ByVal strSQLStatement As String) As DataTable
            Try
                objBCDBSYS.SQLStatement = strSQLStatement
                GetEdataSearchCount = objBCDBSYS.RetrieveItemInfor
                strErrorMsg = objBCDBSYS.ErrorMsg
                intErrorCode = objBCDBSYS.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' ExportToXmlRecord function
        ' Purpose: Export an duplinco Item to XML string
        Public Function ExportToXmlRecord(ByVal objF As StreamWriter, ByRef intCount As Integer, ByRef intFail As Integer) As Integer
            ' Declare variables
            Dim tblData As DataTable
            Dim tblMetadataDef As DataTable
            Dim dtrow() As DataRow
            Dim intIndex As Integer = 0
            Dim strMetadataDef As String = ""
            Dim intSubIndex As Integer = 0
            Dim strTemp As String = ""
            Dim arrIDs() As String
            Dim inti As Integer

            Try
                intCount = 0
                ExportToXmlRecord = 0
                arrIDs = Split(strIDs, ",")

                ' Begin to export
                If UBound(arrIDs) > 0 Then
                    For inti = 0 To UBound(arrIDs) - 1
                        ' get the medatada fields
                        tblMetadataDef = GetMetadataDef()

                        objBEData.FileID = arrIDs(inti)
                        tblData = objBEData.GetMetadata()

                        ' Begin to parse XML strings
                        If Not tblData Is Nothing Then
                            If tblData.Rows.Count > 0 Then
                                intCount = intCount + 1
                                If intCount = 1 Then
                                    ' Header
                                    strTemp = "<?xml version=""1.0"" encoding=""UTF-8""?>" & vbCrLf
                                    strTemp = strTemp & "<Collection xmlns=""http://www.loc.gov/MARC21/slim"">" & vbCrLf
                                End If

                                ' Begin to write the content
                                strTemp = strTemp & "<Record>" & vbCrLf
                                For intIndex = 0 To tblMetadataDef.Rows.Count - 1
                                    strMetadataDef = tblMetadataDef.Rows(intIndex).Item("Metadata")
                                    dtrow = tblData.Select("MetadataID=" & tblMetadataDef.Rows(intIndex).Item("MetadataID"))
                                    If dtrow.Length > 0 Then
                                        strTemp = strTemp & "<" & EscDoubleQuote(strMetadataDef) & ">"
                                        For intSubIndex = 0 To dtrow.Length - 1
                                            strTemp = strTemp & "<content>" & EscDoubleQuote(dtrow(intSubIndex).Item("DisplayEntry")) & "</content>" & vbCrLf
                                        Next
                                        strTemp = strTemp & "</" & EscDoubleQuote(strMetadataDef) & ">" & vbCrLf
                                    End If
                                Next
                                strTemp = strTemp & "</Record>"
                            End If
                        End If
                    Next
                    If Trim(strTemp) <> "" Then
                        strTemp = strTemp & "</Collection>" & vbCrLf
                    End If
                    intFail = UBound(arrIDs) - intCount
                End If

                ' Write to files
                If Trim(strTemp) <> "" Then
                    ExportToXmlRecord = 0
                    objF.WriteLine(strTemp)
                Else
                    ExportToXmlRecord = 1
                End If

                strErrorMsg = objBEData.ErrorMsg
                intErrorCode = objBEData.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
                ExportToXmlRecord = 1
            End Try
        End Function

        ' ExportXMLToFile method
        ' Purpose: Write the XML record to file
        Public Function ExportXMLToFile(ByRef intCount As Integer, ByRef intFail As Integer, ByRef strFile As String, ByRef strFilePath As String) As Integer
            Dim tblFilePath As DataTable
            Dim strPath As String
            Dim strFileName As String

            ExportXMLToFile = 0
            Try
                ' Get the path of the module to save temp files
                tblFilePath = objBCDBSYS.GetTempFilePath("9")

                If Not tblFilePath Is Nothing Then
                    If tblFilePath.Rows.Count > 0 Then
                        strPath = tblFilePath.Rows(0).Item("TempFilePath")
                        objBCDBSYS.Extension = "xml"
                        strFileName = objBCDBSYS.GenRandomFile
                        strPath = Server.MapPath("../..") & "/" & strPath & "/" & strFileName
                        Dim ObjOut = New StreamWriter(strPath, True)
                        If ExportToXmlRecord(ObjOut, intCount, intFail) = 0 Then
                            ExportXMLToFile = 0
                        Else
                            ExportXMLToFile = 1
                        End If
                        ObjOut.Close()
                        strFile = strFileName
                        strFilePath = strPath
                    Else
                        ExportXMLToFile = 1
                    End If
                Else
                    ExportXMLToFile = 1
                End If
                strErrorMsg = objBCDBSYS.ErrorMsg
                intErrorCode = objBCDBSYS.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
                ExportXMLToFile = 1
            End Try
        End Function

        ' GetMetadataDef method
        ' Purpose: get metadata define
        Private Function GetMetadataDef() As DataTable
            Try
                GetMetadataDef = objBEData.GetMetadataDef
                strErrorMsg = objBEData.ErrorMsg
                intErrorCode = objBEData.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' EscDoubleQuote function
        Public Function EscDoubleQuote(ByVal strIn As String) As String
            EscDoubleQuote = Replace(strIn, "'", "\'")
        End Function

        ' Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBEData Is Nothing Then
                    objBEData.Dispose(True)
                    objBEData = Nothing
                End If
                If Not objBCDBSYS Is Nothing Then
                    objBCDBSYS.Dispose(True)
                    objBCDBSYS = Nothing
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
