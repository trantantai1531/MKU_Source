Imports System
Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibOPAC.DataAccess.OPAC
Imports System.Collections.Generic

Namespace eMicLibOPAC.BusinessRules.OPAC
    Public Class clsBOPACSearchQuery
        Inherits clsBBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private strSortBy As String
        Private strSearchMode As String
        Private intSelectTop As Integer = 0
        Private blnSecuredOPAC As Boolean = False
        Private bytAccessLevel As Byte = 0
        Private strItemType As String
        Private strTitle As String
        Private strSeries As String
        Private strAuthor As String
        Private strISBN As String
        Private strLanguage As String
        Private strCallNumber As String
        Private strISSN As String
        Private strKeyWord As String
        Private strDDC_BBK As String
        Private strBBK As String
        Private strDDC As String
        Private strUDC As String
        Private strNSC As String
        Private strSubjectHeading As String
        Private strPublishYear As String
        Private strPublisher As String
        Private intBitmapType As Integer
        Private strColorMode As String
        Private intMinWidthImage As Integer
        Private intMaxWidthImage As Integer
        Private intMinHeigthImage As Integer
        Private intMaxHeigthImage As Integer
        Private intMinSizeImage As Integer
        Private intMaxSizeImage As Integer
        Private intMinResImage As Integer
        Private intMaxResImage As Integer
        Private intTop As Integer
        Private strThesisSubject As String
        Private strFromEdeliveryDate As String
        Private strToEdeliveryDate As String
        Private strCataFrom As String
        Private strCataTo As String
        Private strVol As String
        Private strIssueNo As String
        Private strTabOfContents As String
        Private strFullText As String

        Private arrName() As String
        Private arrValue() As String
        Private arrBool() As String

        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        Private objBDic As New clsBOPACDictionary

        Public strSQLS As String

        Public strItemIDs As String

        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************

        ' ItemIDs property
        Public Property ItemIDs() As String
            Get
                Return strItemIDs
            End Get
            Set(ByVal Value As String)
                strItemIDs = Value
            End Set
        End Property

        ' NameArray property
        Public WriteOnly Property NameArray() As Object
            Set(ByVal Value As Object)
                arrName = Value
            End Set
        End Property
        ' ValueArray property
        Public WriteOnly Property ValueArray() As Object
            Set(ByVal Value As Object)
                arrValue = Value
            End Set
        End Property
        ' BoolArray property
        Public WriteOnly Property BoolArray() As Object
            Set(ByVal Value As Object)
                arrBool = Value
            End Set
        End Property

        ' SelectTop property
        Public Property SelectTop() As Integer
            Get
                Return intSelectTop
            End Get
            Set(ByVal Value As Integer)
                intSelectTop = Value
            End Set
        End Property

        ' SecuredOPAC property
        Public WriteOnly Property SecuredOPAC() As Boolean
            Set(ByVal Value As Boolean)
                blnSecuredOPAC = Value
            End Set
        End Property

        ' AccessLevel property
        Public WriteOnly Property AccessLevel() As Byte
            Set(ByVal Value As Byte)
                bytAccessLevel = Value
            End Set
        End Property

        ' ItemType property 
        Public Property ItemType() As String
            Get
                Return strItemType
            End Get
            Set(ByVal Value As String)
                strItemType = Value
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
        ' Series property_ added by dgsoft2016       
        Public Property Series() As String
            Get
                Return strSeries
            End Get
            Set(ByVal Value As String)
                strSeries = Value
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

        ' Fulltext property
        Public Property Fulltext() As String
            Get
                Return strFullText
            End Get
            Set(ByVal Value As String)
                strFullText = Value
            End Set
        End Property

        ' CataFrom property
        Public Property CataFrom() As String
            Get
                Return strCataFrom
            End Get
            Set(ByVal Value As String)
                strCataFrom = Value
            End Set
        End Property

        ' CataTo property
        Public Property CataTo() As String
            Get
                Return strCataTo
            End Get
            Set(ByVal Value As String)
                strCataTo = Value
            End Set
        End Property

        ' SortBy property
        Public Property SortBy() As String
            Get
                Return strSortBy
            End Get
            Set(ByVal Value As String)
                strSortBy = Value
            End Set
        End Property

        ' TabOfContents property
        Public Property TabOfContents() As String
            Get
                Return strTabOfContents
            End Get
            Set(ByVal Value As String)
                strTabOfContents = Value
            End Set
        End Property

        ' ISBN property
        Public Property ISBN() As String
            Get
                Return strISBN
            End Get
            Set(ByVal Value As String)
                strISBN = Value
            End Set
        End Property

        ' Language property
        Public Property Language() As String
            Get
                Return strLanguage
            End Get
            Set(ByVal Value As String)
                strLanguage = Value
            End Set
        End Property

        ' CallNumber property
        Public Property CallNumber() As String
            Get
                Return strCallNumber
            End Get
            Set(ByVal Value As String)
                strCallNumber = Value
            End Set
        End Property

        ' ISSN property
        Public Property ISSN() As String
            Get
                Return strISSN
            End Get
            Set(ByVal Value As String)
                strISSN = Value
            End Set
        End Property

        ' KeyWord property
        Public Property KeyWord() As String
            Get
                Return strKeyWord
            End Get
            Set(ByVal Value As String)
                strKeyWord = Value
            End Set
        End Property

        ' DDC_BBK  property
        Public Property DDC_BBK() As String
            Get
                Return strDDC_BBK
            End Get
            Set(ByVal Value As String)
                strDDC_BBK = Value
            End Set
        End Property
        ' BBK  property
        Public Property BBK() As String
            Get
                Return strBBK
            End Get
            Set(ByVal Value As String)
                strBBK = Value
            End Set
        End Property
        ' DDC  property
        Public Property DDC() As String
            Get
                Return strDDC
            End Get
            Set(ByVal Value As String)
                strDDC = Value
            End Set
        End Property

        ' UDC property 
        Public Property UDC() As String
            Get
                Return strUDC
            End Get
            Set(ByVal Value As String)
                strUDC = Value
            End Set
        End Property

        ' NSC property
        Public Property NSC() As String
            Get
                Return strNSC
            End Get
            Set(ByVal Value As String)
                strNSC = Value
            End Set
        End Property

        ' SubjectHeading property
        Public Property SubjectHeading() As String
            Get
                Return strSubjectHeading
            End Get
            Set(ByVal Value As String)
                strSubjectHeading = Value
            End Set
        End Property

        ' PublishYear property
        Public Property PublishYear() As String
            Get
                Return strPublishYear
            End Get
            Set(ByVal Value As String)
                strPublishYear = Value
            End Set
        End Property

        ' Publisher property
        Public Property Publisher() As String
            Get
                Return strPublisher
            End Get
            Set(ByVal Value As String)
                strPublisher = Value
            End Set
        End Property

        ' SearchMode property
        Public Property SearchMode() As String
            Get
                Return strSearchMode
            End Get
            Set(ByVal Value As String)
                strSearchMode = Value
            End Set
        End Property

        ' BitmapType property 
        Public Property BitmapType() As Integer
            Get
                Return intBitmapType
            End Get
            Set(ByVal Value As Integer)
                intBitmapType = Value
            End Set
        End Property

        ' ColorMode property 
        Public Property ColorMode() As String
            Get
                Return strColorMode
            End Get
            Set(ByVal Value As String)
                strColorMode = Value
            End Set
        End Property

        ' MinWidthImage property
        Public Property MinWidthImage() As Integer
            Get
                Return intMinWidthImage
            End Get
            Set(ByVal Value As Integer)
                intMinWidthImage = Value
            End Set
        End Property

        ' MaxWidthImage property
        Public Property MaxWidthImage() As Integer
            Get
                Return intMaxWidthImage
            End Get
            Set(ByVal Value As Integer)
                intMaxWidthImage = Value
            End Set
        End Property

        ' MinHeigthImage property
        Public Property MinHeigthImage() As Integer
            Get
                Return intMinHeigthImage
            End Get
            Set(ByVal Value As Integer)
                intMinHeigthImage = Value
            End Set
        End Property

        ' MaxHeigthImage property
        Public Property MaxHeigthImage() As Integer
            Get
                Return intMaxHeigthImage
            End Get
            Set(ByVal Value As Integer)
                intMaxHeigthImage = Value
            End Set
        End Property

        ' MinSizeImage property
        Property MinSizeImage() As Integer
            Get
                Return intMinSizeImage
            End Get
            Set(ByVal Value As Integer)
                intMinSizeImage = Value
            End Set
        End Property

        ' MaxSizeImage property
        Property MaxSizeImage() As Integer
            Get
                Return intMaxSizeImage
            End Get
            Set(ByVal Value As Integer)
                intMaxSizeImage = Value
            End Set
        End Property

        ' MaxSizeImage property
        Property MaxResImage() As Integer
            Get
                Return intMaxResImage
            End Get
            Set(ByVal Value As Integer)
                intMaxResImage = Value
            End Set
        End Property

        ' MaxSizeImage property
        Property MinResImage() As Integer
            Get
                Return intMinResImage
            End Get
            Set(ByVal Value As Integer)
                intMinResImage = Value
            End Set
        End Property


        ' ThesisSubject Property
        Public Property ThesisSubject() As String
            Get
                Return strThesisSubject
            End Get
            Set(ByVal Value As String)
                strThesisSubject = Value
            End Set
        End Property

        ' FromEdeliveryDate property
        Public Property FromEdeliveryDate() As String
            Get
                Return strFromEdeliveryDate
            End Get
            Set(ByVal Value As String)
                strFromEdeliveryDate = Value
            End Set
        End Property

        ' ToEdeliveryDate property
        Public Property ToEdeliveryDate() As String
            Get
                Return strToEdeliveryDate
            End Get
            Set(ByVal Value As String)
                strToEdeliveryDate = Value
            End Set
        End Property

        ' Vol property
        Public Property Vol() As String
            Get
                Return strVol
            End Get
            Set(ByVal Value As String)
                strVol = Value
            End Set
        End Property

        ' IssueNo property
        Public Property IssueNo() As String
            Get
                Return strIssueNo
            End Get
            Set(ByVal Value As String)
                strIssueNo = Value
            End Set
        End Property

        ' Select top property
        Public Property Top() As Integer
            Get
                Return (intTop)
            End Get
            Set(ByVal Value As Integer)
                intTop = Value
            End Set
        End Property

        ' Initialize method
        ' Purpose: Init all necessary objects
        Public Overloads Sub Initialize()
            Try
                ' Init objBCDBS object
                objBCDBS.DBServer = strDBServer
                objBCDBS.InterfaceLanguage = strInterfaceLanguage
                objBCDBS.ConnectionString = strConnectionString
                Call objBCDBS.Initialize()

                ' Init objBCSP object
                objBCSP.DBServer = strDBServer
                objBCSP.InterfaceLanguage = strInterfaceLanguage
                objBCSP.ConnectionString = strConnectionString
                Call objBCSP.Initialize()

                objBDic.DBServer = strDBServer
                objBDic.InterfaceLanguage = strInterfaceLanguage
                objBDic.ConnectionString = strConnectionString
                objBDic.Initialize()
                'Catch ex As Exception
                '    strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        ' purpose : Generate 3 array not use for advance search
        ' in: all properties of this
        ' out : 3 array
        ' Creator : dgsoft
        Private Sub Generate3Array()
            Dim intCount As Integer = 0
            ReDim arrBool(0)
            ReDim arrName(0)
            ReDim arrValue(0)
            Dim strPercent As String = ""

            If strTitle <> "" Then
                arrBool(intCount) = "AND"
                arrName(intCount) = "Title"
                arrValue(intCount) = strPercent & objBCSP.ConvertItBack(strTitle, True) & strPercent
                intCount = intCount + 1
            End If
            If strItemType <> "" Then
                ReDim Preserve arrBool(intCount)
                ReDim Preserve arrName(intCount)
                ReDim Preserve arrValue(intCount)
                arrBool(intCount) = "AND"
                arrName(intCount) = "ItemType"
                arrValue(intCount) = objBCSP.ConvertItBack(strItemType, True)
                intCount = intCount + 1
            End If
            If strSeries <> "" Then
                ReDim Preserve arrBool(intCount)
                ReDim Preserve arrName(intCount)
                ReDim Preserve arrValue(intCount)
                arrBool(intCount) = "AND"
                arrName(intCount) = "series"
                arrValue(intCount) = strPercent & objBCSP.ConvertItBack(strSeries, True) & strPercent
                intCount = intCount + 1
            End If
            If strAuthor <> "" Then
                ReDim Preserve arrBool(intCount)
                ReDim Preserve arrName(intCount)
                ReDim Preserve arrValue(intCount)
                arrBool(intCount) = "AND"
                arrName(intCount) = "Author"
                arrValue(intCount) = strPercent & objBCSP.ConvertItBack(strAuthor, True) & strPercent
                intCount = intCount + 1
            End If
            If strISBN <> "" Then
                ReDim Preserve arrBool(intCount)
                ReDim Preserve arrName(intCount)
                ReDim Preserve arrValue(intCount)
                arrBool(intCount) = "AND"
                arrName(intCount) = "ISBN"
                arrValue(intCount) = strPercent & objBCSP.ConvertItBack(strISBN, True) & strPercent
                intCount = intCount + 1
            End If
            If strISSN <> "" Then
                ReDim Preserve arrBool(intCount)
                ReDim Preserve arrName(intCount)
                ReDim Preserve arrValue(intCount)
                arrBool(intCount) = "AND"
                arrName(intCount) = "ISSN"
                arrValue(intCount) = strPercent & objBCSP.ConvertItBack(strISSN, True) & strPercent
                intCount = intCount + 1
            End If
            If strLanguage <> "" Then
                ReDim Preserve arrBool(intCount)
                ReDim Preserve arrName(intCount)
                ReDim Preserve arrValue(intCount)
                arrBool(intCount) = "AND"
                arrName(intCount) = "Language"
                arrValue(intCount) = strPercent & objBCSP.ConvertItBack(strLanguage, True) & strPercent
                intCount = intCount + 1
            End If
            If strCallNumber <> "" Then
                ReDim Preserve arrBool(intCount)
                ReDim Preserve arrName(intCount)
                ReDim Preserve arrValue(intCount)
                arrBool(intCount) = "AND"
                arrName(intCount) = "CallNumber"
                arrValue(intCount) = strPercent & objBCSP.ConvertItBack(strCallNumber, True) & strPercent
                intCount = intCount + 1
            End If
            If strKeyWord <> "" Then
                ReDim Preserve arrBool(intCount)
                ReDim Preserve arrName(intCount)
                ReDim Preserve arrValue(intCount)
                arrBool(intCount) = "AND"
                arrName(intCount) = "KeyWord"
                arrValue(intCount) = objBCSP.ConvertItBack(strKeyWord, True)
                intCount = intCount + 1
            End If
            If strDDC_BBK <> "" Then
                ReDim Preserve arrBool(intCount)
                ReDim Preserve arrName(intCount)
                ReDim Preserve arrValue(intCount)
                arrBool(intCount) = "AND"
                arrName(intCount) = "BBK/DDC"
                arrValue(intCount) = strPercent & objBCSP.ConvertItBack(strDDC_BBK, True) & strPercent
                intCount = intCount + 1
            End If
            If strBBK <> "" Then
                ReDim Preserve arrBool(intCount)
                ReDim Preserve arrName(intCount)
                ReDim Preserve arrValue(intCount)
                arrBool(intCount) = "AND"
                arrName(intCount) = "BBK"
                arrValue(intCount) = strPercent & objBCSP.ConvertItBack(strBBK, True) & strPercent
                intCount = intCount + 1
            End If
            If strDDC <> "" Then
                ReDim Preserve arrBool(intCount)
                ReDim Preserve arrName(intCount)
                ReDim Preserve arrValue(intCount)
                arrBool(intCount) = "AND"
                arrName(intCount) = "DDC"
                arrValue(intCount) = strPercent & objBCSP.ConvertItBack(strDDC, True) & strPercent
                intCount = intCount + 1
            End If
            If strUDC <> "" Then
                ReDim Preserve arrBool(intCount)
                ReDim Preserve arrName(intCount)
                ReDim Preserve arrValue(intCount)
                arrBool(intCount) = "AND"
                arrName(intCount) = "UDC"
                arrValue(intCount) = strPercent & objBCSP.ConvertItBack(strUDC, True) & strPercent
                intCount = intCount + 1
            End If
            If strNSC <> "" Then
                ReDim Preserve arrBool(intCount)
                ReDim Preserve arrName(intCount)
                ReDim Preserve arrValue(intCount)
                arrBool(intCount) = "AND"
                arrName(intCount) = "NSC"
                arrValue(intCount) = strPercent & objBCSP.ConvertItBack(strNSC, True) & strPercent
                intCount = intCount + 1
            End If
            If strSubjectHeading <> "" Then
                ReDim Preserve arrBool(intCount)
                ReDim Preserve arrName(intCount)
                ReDim Preserve arrValue(intCount)
                arrBool(intCount) = "AND"
                arrName(intCount) = "SubjectHeading"
                arrValue(intCount) = strPercent & objBCSP.ConvertItBack(strSubjectHeading, True) & strPercent
                intCount = intCount + 1
            End If
            If strPublishYear <> "" Then
                ReDim Preserve arrBool(intCount)
                ReDim Preserve arrName(intCount)
                ReDim Preserve arrValue(intCount)
                arrBool(intCount) = "AND"
                arrName(intCount) = "PublishYear"
                arrValue(intCount) = objBCSP.ConvertItBack(strPublishYear, True)
                intCount = intCount + 1
            End If
            If strPublisher <> "" Then
                ReDim Preserve arrBool(intCount)
                ReDim Preserve arrName(intCount)
                ReDim Preserve arrValue(intCount)
                arrBool(intCount) = "AND"
                arrName(intCount) = "Publisher"
                arrValue(intCount) = strPercent & objBCSP.ConvertItBack(strPublisher, True) & strPercent
                intCount = intCount + 1
            End If
            If strThesisSubject <> "" Then
                ReDim Preserve arrBool(intCount)
                ReDim Preserve arrName(intCount)
                ReDim Preserve arrValue(intCount)
                arrBool(intCount) = "AND"
                arrName(intCount) = "ThesisSubject"
                arrValue(intCount) = strPercent & objBCSP.ConvertItBack(strThesisSubject, True) & strPercent
                intCount = intCount + 1
            End If
            If strFromEdeliveryDate <> "" Then
                ReDim Preserve arrBool(intCount)
                ReDim Preserve arrName(intCount)
                ReDim Preserve arrValue(intCount)
                arrBool(intCount) = "AND"
                arrName(intCount) = "FromIssuedDate"
                arrValue(intCount) = objBCSP.ConvertItBack(strFromEdeliveryDate, True)
                intCount = intCount + 1
            End If
            If strToEdeliveryDate <> "" Then
                ReDim Preserve arrBool(intCount)
                ReDim Preserve arrName(intCount)
                ReDim Preserve arrValue(intCount)
                arrBool(intCount) = "AND"
                arrName(intCount) = "ToIssuedDate"
                arrValue(intCount) = objBCSP.ConvertItBack(strToEdeliveryDate, True)
                intCount = intCount + 1
            End If
            If strVol <> "" Then
                ReDim Preserve arrBool(intCount)
                ReDim Preserve arrName(intCount)
                ReDim Preserve arrValue(intCount)
                arrBool(intCount) = "AND"
                arrName(intCount) = "Volume"
                arrValue(intCount) = objBCSP.ConvertItBack(strVol, True)
                intCount = intCount + 1
            End If
            If strIssueNo <> "" Then
                ReDim Preserve arrBool(intCount)
                ReDim Preserve arrName(intCount)
                ReDim Preserve arrValue(intCount)
                arrBool(intCount) = "AND"
                arrName(intCount) = "IssueNo"
                arrValue(intCount) = objBCSP.ConvertItBack(strIssueNo, True)
                intCount = intCount + 1
            End If
            If strTabOfContents <> "" Then
                ReDim Preserve arrBool(intCount)
                ReDim Preserve arrName(intCount)
                ReDim Preserve arrValue(intCount)
                arrBool(intCount) = "AND"
                arrName(intCount) = "TabOfContents"
                arrValue(intCount) = objBCSP.ConvertItBack(strTabOfContents, True)
                intCount = intCount + 1
            End If
            If strCataFrom <> "" Then
                ReDim Preserve arrBool(intCount)
                ReDim Preserve arrName(intCount)
                ReDim Preserve arrValue(intCount)
                arrBool(intCount) = "AND"
                arrName(intCount) = "catafrom"
                arrValue(intCount) = objBCDBS.ConvertDateBack(strCataFrom)
                intCount = intCount + 1
            End If
            If strCataTo <> "" Then
                ReDim Preserve arrBool(intCount)
                ReDim Preserve arrName(intCount)
                ReDim Preserve arrValue(intCount)
                arrBool(intCount) = "AND"
                arrName(intCount) = "catato"
                arrValue(intCount) = objBCDBS.ConvertDateBack(strCataTo)
                intCount = intCount + 1
            End If
            If strFullText <> "" Then
                ReDim Preserve arrBool(intCount)
                ReDim Preserve arrName(intCount)
                ReDim Preserve arrValue(intCount)
                arrBool(intCount) = "AND"
                arrName(intCount) = "fulltext"
                arrValue(intCount) = objBCSP.ConvertItBack(strFullText, True)
            End If
        End Sub

        Public Function FormingEbooksSearch(ByVal strWord As String) As String
            Dim strResult As String = ""
            Try
                ' if intTop <=0 select Ubound_search from sys_parameter table
                If intTop <= 0 Then
                    Dim arrName(0) As String
                    arrName(0) = "SEARCH_UBOUND"
                    intTop = objBCDBS.GetSystemParameters(arrName)(0)
                End If
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        strResult = "SELECT DISTINCT TOP " & intTop & " IT.ID,' ' AS Content  FROM Lib_tblItemFileFulltextPage IFFP JOIN Lib_tblItemFile IFS ON IFFP.FileId = IFS.ID JOIN Lib_tblItem IT ON IFS.ItemID = IT.ID WHERE CONTAINS(IFFP.Contents,'""" & strWord.Trim & """')"
                    Case "ORACLE"
                        strResult = "SELECT DISTINCT TOP " & intTop & " IT.ID,' ' AS Content  FROM Lib_tblItemFileFulltextPage IFFP JOIN Lib_tblItemFile IFS ON IFFP.FileId = IFS.ID JOIN Lib_tblItem IT ON IFS.ItemID = IT.ID WHERE CONTAINS(IFFP.Contents,'""" & strWord.Trim & """') > 0"
                End Select
            Catch ex As Exception
            End Try
            Return strResult
        End Function

        ' Purpose: FormingSQL
        ' Input: 3 array: Name, Bool, Value
        ' Output: string
        ' Created by: dgsoft
        Public Function FormingSQL() As String
            Dim strFinalSQL As String
            Dim strUnionSQL As String
            Dim strMySQL As String
            Dim intCount As Integer
            Dim blnUseFulltextIndex As Boolean
            Dim blnSearchExact As Boolean
            Dim strTitle As String
            Dim strStartYr As String
            Dim strEndYr As String
            Dim strSQLRet As String
            Dim strSQLNext As String

            Dim TblCatDicList As New DataTable
            Dim strval1 As String
            strFinalSQL = ""
            strUnionSQL = ""
            If UCase(strSearchMode) <> "ADVANCE" Then
                Me.Generate3Array()
            End If
            If Not arrName Is Nothing AndAlso UBound(arrName) >= 0 Then
                For intCount = LBound(arrName) To UBound(arrName)
                    If Not Trim(arrValue(intCount)) = "" Then
                        strMySQL = ""

                        If Left(arrValue(intCount), 2) = "$*" AndAlso Right(arrValue(intCount), 2) = "*$" Then
                            blnSearchExact = True
                            arrValue(intCount) = Right(arrValue(intCount), Len(arrValue(intCount)) - 2)
                            arrValue(intCount) = Left(arrValue(intCount), Len(arrValue(intCount)) - 2)
                        End If

                        Select Case LCase(arrName(intCount))
                            Case "fulltext" ' moi truong
                                'arrValue(intCount) = Replace(objBCSP.ProcessVal(arrValue(intCount)), "'", "''")
                                Dim strKeyword As String = ""
                                arrValue(intCount) = Replace(arrValue(intCount), "'", "''")
                                strKeyword = Replace(arrValue(intCount), """", "")
                                If InStr(arrValue(intCount), """") = 0 Then
                                    arrValue(intCount) = """" & arrValue(intCount) & """"
                                End If
                                Select Case UCase(strDBServer)
                                    Case "SQLSERVER"

                                        strMySQL = "SELECT Lib_tblItemFulltext.ItemID AS ID FROM Lib_tblItemFulltext WHERE CONTAINS(Lib_tblItemFulltext.Contents, '" & arrValue(intCount) & "')"

                                        strMySQL &= " And ItemID in "
                                        strMySQL &= "("
                                        strMySQL &= " Select ItemID from Lib_tblField200S where FieldCode='245' or FieldCode='260'"
                                        strMySQL &= " UNION "
                                        strMySQL &= " Select ItemID from Lib_tblField000S where FieldCode='082'"
                                        strMySQL &= " UNION "
                                        strMySQL &= "Select ItemID from Lib_tblField500S where FieldCode='520'"
                                        strMySQL &= " UNION "
                                        strMySQL &= "select ItemID from Lib_tblField600S where FieldCode='653'"
                                        strMySQL &= " UNION "
                                        strMySQL &= "select ItemID from Lib_tblHolding"
                                        strMySQL &= ")"

                                        ''strMySQL = "SELECT Lib_tblItemFulltext.ItemID AS ID FROM Lib_tblItemFulltext WHERE CONTAINS(Lib_tblItemFulltext.Contents, '" & arrValue(intCount) & "')"
                                        'strMySQL = ""
                                        'strMySQL = strMySQL & " SELECT Lib_tblItemTitle.ItemID AS ID "
                                        'strMySQL = strMySQL & " FROM Lib_tblItemTitle"
                                        'strMySQL = strMySQL & " WHERE 1=1 "
                                        ''strMySQL = strMySQL & " AND Lib_tblField200S.Content LIKE N'%" & arrValue(intCount) & "%' "
                                        'strMySQL = strMySQL & " AND CHARINDEX('" & strKeyword & "',CAST(Lib_tblItemTitle.Title COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) > 0 "
                                        'strMySQL = strMySQL & " UNION SELECT Lib_tblField000S.ItemID AS ID "
                                        'strMySQL = strMySQL & " FROM Lib_tblField000S "
                                        'strMySQL = strMySQL & " WHERE Lib_tblField000S.FieldCode='082' "
                                        ''strMySQL = strMySQL & " AND Lib_tblField000S.Content LIKE N'%" & arrValue(intCount) & "%' "
                                        'strMySQL = strMySQL & " AND CHARINDEX('" & strKeyword & "',CAST(Lib_tblField000S.Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) > 0 "
                                        'strMySQL = strMySQL & " UNION SELECT Lib_tblField200S.ItemID AS ID "
                                        'strMySQL = strMySQL & " FROM Lib_tblField200S "
                                        'strMySQL = strMySQL & " WHERE Lib_tblField200S.FieldCode='260' "
                                        ''strMySQL = strMySQL & " AND Lib_tblField200S.Content LIKE N'%" & arrValue(intCount) & "%' "
                                        'strMySQL = strMySQL & " AND CHARINDEX('" & strKeyword & "',CAST(Lib_tblField200S.Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) > 0 "
                                        'strMySQL = strMySQL & " UNION SELECT Lib_tblField500S.ItemID AS ID "
                                        'strMySQL = strMySQL & " FROM Lib_tblField500S "
                                        'strMySQL = strMySQL & " WHERE Lib_tblField500S.FieldCode='520' "
                                        ''strMySQL = strMySQL & " AND Lib_tblField500S.Content LIKE N'%" & arrValue(intCount) & "%' "
                                        'strMySQL = strMySQL & " AND CHARINDEX('" & strKeyword & "',CAST(Lib_tblField500S.Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) > 0 "
                                        'strMySQL = strMySQL & " UNION SELECT Lib_tblField600S.ItemID AS ID "
                                        'strMySQL = strMySQL & " FROM Lib_tblField600S "
                                        'strMySQL = strMySQL & " WHERE Lib_tblField600S.FieldCode='653' "
                                        ''strMySQL = strMySQL & " AND Lib_tblField600S.Content LIKE N'%" & arrValue(intCount) & "%' "
                                        'strMySQL = strMySQL & " AND CHARINDEX('" & strKeyword & "',CAST(Lib_tblField600S.Content COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max))) > 0 "
                                        ''strMySQL = strMySQL & " UNION SELECT Lib_tblHolding.ItemID AS ID "
                                        ''strMySQL = strMySQL & " FROM Lib_tblHolding "
                                        ''strMySQL = strMySQL & " WHERE Lib_tblHolding.CopyNumber Like N'%" & strKeyword & "%' "
                                    Case "ORACLE"
                                        strMySQL = "SELECT Lib_tblItemFulltext.ItemID AS ID FROM Lib_tblItemFulltext WHERE CONTAINS(Lib_tblItemFulltext.Contents, '" & arrValue(intCount) & "') > 0"
                                End Select
                            Case "title" ' nhan de
                                If (Left(arrValue(intCount), 1) = "%" Or Right(arrValue(intCount), 1) = "%") AndAlso InStr(arrValue(intCount), "'") = 0 Then
                                    blnUseFulltextIndex = False
                                Else
                                    If blnSearchExact = True Then
                                        blnUseFulltextIndex = False
                                    Else
                                        blnUseFulltextIndex = True
                                    End If
                                End If
                                If UCase(strSearchMode) = "ADVANCE" Then
                                    strTitle = Replace(objBCSP.ProcessVal(arrValue(intCount)), "'", "''")
                                Else
                                    strTitle = objBCSP.ProcessVal(arrValue(intCount))
                                End If
                                If blnUseFulltextIndex Then
                                    If InStr(strTitle, """") = 0 Then
                                        strTitle = """" & strTitle & """"
                                    End If
                                    Select Case UCase(strDBServer)
                                        Case "SQLSERVER"
                                            strMySQL = "SELECT Lib_tblItemTitle.ItemID AS ID FROM Lib_tblItemTitle WHERE CONTAINS(Lib_tblItemTitle.Title, '" & strTitle & "')"
                                        Case "ORACLE"
                                            strMySQL = "SELECT Lib_tblItemTitle.ItemID AS ID FROM Lib_tblItemTitle WHERE CONTAINS(Lib_tblItemTitle.Title, '" & strTitle & "') > 0"
                                    End Select
                                Else
                                    Select Case UCase(strDBServer)
                                        Case "SQLSERVER"
                                            strMySQL = "SELECT Lib_tblItemTitle.ItemID as ID FROM Lib_tblItemTitle WHERE Lib_tblItemTitle.Title LIKE N'%" & strTitle & "%'"
                                        Case "ORACLE"
                                            strMySQL = "SELECT Lib_tblItemTitle.ItemID as ID FROM Lib_tblItemTitle WHERE Lib_tblItemTitle.Title LIKE '" & strTitle & "'"
                                    End Select
                                End If
                                If LCase(arrName(intCount)) = "maintitle" Then
                                    strMySQL = strMySQL & " AND Lib_tblItemTitle.FieldCode = '245$a'"
                                End If
                            Case "series" ' Tung thu
                                strMySQL = " SELECT Lib_tblItemSeries.ItemID as ID FROM Cat_tblDicSeries, Lib_tblItemSeries WHERE Cat_tblDicSeries.ID = Lib_tblItemSeries.seriesID AND "
                                Select Case UCase(strDBServer)
                                    Case "SQLSERVER"
                                        strMySQL = strMySQL & " (Cat_tblDicSeries.AccessEntry LIKE N'%" & objBCSP.ProcessVal(arrValue(intCount)) & "%' OR Cat_tblDicSeries.VietnameseAccent LIKE '%" & objBCSP.CutVietnameseAccent(objBCSP.ProcessVal(arrValue(intCount))) & "%' )"
                                    Case "ORACLE"
                                        strMySQL = strMySQL & " (Cat_tblDicSeries.AccessEntry LIKE '" & objBCSP.ProcessVal(arrValue(intCount)) & "' OR Cat_tblDicSeries.VietnameseAccent LIKE '" & objBCSP.CutVietnameseAccent(objBCSP.ProcessVal(arrValue(intCount))) & "' )"
                                End Select
                            Case "publisher" ' NXB
                                strMySQL = " SELECT Lib_tblItemPublisher.ItemID AS ID FROM Lib_tblItemPublisher, Cat_tblDicPublisher, Lib_tblField200S WHERE Cat_tblDicPublisher.ID = Lib_tblItemPublisher.PublisherID AND Lib_tblField200S.ItemID = Lib_tblItemPublisher.ItemID AND Lib_tblField200S.FieldCode = '260' AND Lib_tblField200S.Content <> '' AND "
                                Select Case UCase(strDBServer)
                                    Case "SQLSERVER"
                                        strMySQL = strMySQL & " (Cat_tblDicPublisher.AccessEntry LIKE N'%" & objBCSP.ProcessVal(arrValue(intCount)) & "%' OR Cat_tblDicPublisher.VietnameseAccent LIKE '%" & objBCSP.CutVietnameseAccent(objBCSP.ProcessVal(arrValue(intCount))) & "%' )"
                                    Case "ORACLE"
                                        strMySQL = strMySQL & " (Cat_tblDicPublisher.AccessEntry LIKE '" & objBCSP.ProcessVal(arrValue(intCount)) & "' OR Cat_tblDicPublisher.VietnameseAccent LIKE '" & objBCSP.CutVietnameseAccent(objBCSP.ProcessVal(arrValue(intCount))) & "' )"
                                End Select
                            Case "author" ' tac gia
                                Select Case UCase(strDBServer)
                                    Case "SQLSERVER"
                                        strMySQL = " SELECT Lib_tblItem_Author.ItemID  AS ID FROM Lib_tblItem_Author, Cat_tblDicAuthor WHERE Cat_tblDicAuthor.ID = Lib_tblItem_Author.AuthorID AND "
                                        strMySQL = strMySQL & " (Cat_tblDicAuthor.AccessEntry LIKE N'%" & objBCSP.ProcessVal(arrValue(intCount)) & "%' OR Cat_tblDicAuthor.VietnameseAccent LIKE '%" & objBCSP.CutVietnameseAccent(objBCSP.ProcessVal(arrValue(intCount))) & "%' )"
                                        'strMySQL = strMySQL & " (Cat_tblDicAuthor.AccessEntry LIKE N'%" & objBCSP.ProcessVal(arrValue(intCount)) & "%' OR Cat_tblDicAuthor.VietnameseAccent LIKE '%" & objBCSP.CutVietnameseAccent(objBCSP.ProcessVal(arrValue(intCount))) & "%') " & _
                                        '    " AND CHARINDEX('" & objBCSP.ProcessVal(arrValue(intCount)) & "', CAST(UPPER(Content) COLLATE SQL_Latin1_General_CP1_CI_AI AS nvarchar(max)))  > 0"
                                    Case "ORACLE"
                                        strMySQL = " SELECT Lib_tblItem_Author.ItemID AS ID FROM Lib_tblItem_Author, Cat_tblDicAuthor WHERE Cat_tblDicAuthor.ID = Lib_tblItem_Author.AuthorID AND "
                                        strMySQL = strMySQL & " (Cat_tblDicAuthor.AccessEntry LIKE '" & objBCSP.ProcessVal(arrValue(intCount)) & "' OR Cat_tblDicAuthor.VietnameseAccent LIKE '" & objBCSP.CutVietnameseAccent(objBCSP.ProcessVal(arrValue(intCount))) & "' )"
                                End Select
                            Case "tabofcontents" ' muc luc (Bao, tap chi)
                                arrValue(intCount) = objBCSP.ProcessVal(arrValue(intCount))
                                If InStr(arrValue(intCount), """") = 0 Then
                                    arrValue(intCount) = """" & arrValue(intCount) & """"
                                End If
                                strMySQL = " SELECT Ser_tblIssue.ItemID  AS ID FROM Ser_tblArticle, Ser_tblIssue WHERE Ser_tblArticle.IssueID = Ser_tblIssue.ID AND "
                                Select Case UCase(strDBServer)
                                    Case "SQLSERVER"
                                        strMySQL = strMySQL & " CONTAINS(Ser_tblArticle.Contents,'" & arrValue(intCount) & "')"
                                    Case "ORACLE"
                                        strMySQL = strMySQL & " CONTAINS(Ser_tblArticle.Contents,'" & arrValue(intCount) & "')>0 "
                                End Select
                            Case "publishyear" ' nam XB
                                'If InStr(arrValue(intCount), "-") = 0 Then
                                '    strMySQL = strMySQL & " AND Cat_tblDicYear.Year LIKE '" & arrValue(intCount) & "'"
                                'Else
                                '    strStartYr = Trim(Left(arrValue(intCount), InStr(arrValue(intCount), "-") - 1))
                                '    strEndYr = Trim(Right(arrValue(intCount), Len(arrValue(intCount)) - InStr(arrValue(intCount), "-")))
                                '    If Not strStartYr = "" Then
                                '        strMySQL = strMySQL & " AND Cat_tblDicYear.Year >= '" & strStartYr & "'"
                                '    End If
                                '    If Not strEndYr = "" Then
                                '        If Len(strStartYr) > Len(strEndYr) Then
                                '            strEndYr = Left(strStartYr, Len(strStartYr) - Len(strEndYr)) & strEndYr
                                '        End If
                                '        strMySQL = strMySQL & " AND Cat_tblDicYear.Year <= '" & strEndYr & "'"
                                '    End If
                                'End If
                                ' strMySQL = " SELECT Cat_tblDicYear.ItemID AS ID FROM Cat_tblDicYear WHERE " & Right(strMySQL, Len(strMySQL) - 5)
                                If InStr(arrValue(intCount), "-") = 0 Then
                                    strMySQL = strMySQL & " AND Cat_tblDicYear.Year <= '" & arrValue(intCount) & "'"
                                Else
                                    strStartYr = Trim(Left(arrValue(intCount), InStr(arrValue(intCount), "-") - 1))
                                    strEndYr = Trim(Right(arrValue(intCount), Len(arrValue(intCount)) - InStr(arrValue(intCount), "-")))
                                    If Not strStartYr = "" Then
                                        strMySQL = strMySQL & " AND Cat_tblDicYear.Year >= '" & strStartYr & "'"
                                    End If
                                    If Not strEndYr = "" Then
                                        If Len(strStartYr) > Len(strEndYr) Then
                                            strEndYr = Left(strStartYr, Len(strStartYr) - Len(strEndYr)) & strEndYr
                                        End If
                                        strMySQL = strMySQL & " AND Cat_tblDicYear.Year <= '" & strEndYr & "'"
                                    End If
                                End If
                                strMySQL = " SELECT Cat_tblDicYear.ItemID AS ID FROM Cat_tblDicYear WHERE (1=1) " & strMySQL
                            Case "callnumber" ' Call Number
                                strMySQL = " SELECT Lib_tblItem.ID FROM Lib_tblItem WHERE Lib_tblItem.CallNumber LIKE '%" & arrValue(intCount) & "%'"
                            Case "catafrom" ' Cata From
                                strMySQL = " SELECT Lib_tblItem.ID FROM Lib_tblItem WHERE Lib_tblItem.CreatedDate >= '" & arrValue(intCount) & "'"
                            Case "catato" ' Cata To
                                strMySQL = " SELECT Lib_tblItem.ID FROM Lib_tblItem WHERE Lib_tblItem.CreatedDate <=  '" & arrValue(intCount) & "'"
                            Case "itemcode" ' Ma tai lieu
                                strMySQL = " SELECT Lib_tblItem.ID FROM Lib_tblItem WHERE Lib_tblItem.Code LIKE '%" & arrValue(intCount) & "%'"
                            Case "issueno" ' so tap chi
                                strMySQL = " SELECT Ser_tblIssue.ItemID as ID FROM Ser_tblIssue WHERE Ser_tblIssue.IssueNo LIKE '%" & arrValue(intCount) & "%'"
                            Case "volume" ' tap
                                Select Case UCase(strDBServer)
                                    Case "SQLSERVER"
                                        strMySQL = " SELECT Ser_tblIssue.ItemID AS ID FROM Ser_tblIssue WHERE Ser_tblIssue.VolumeByPublisher LIKE N'%" & arrValue(intCount) & "%'"
                                    Case "ORACLE"
                                        strMySQL = " SELECT Ser_tblIssue.ItemID AS ID FROM Ser_tblIssue WHERE Ser_tblIssue.VolumeByPublisher LIKE '" & arrValue(intCount) & "'"
                                End Select
                            Case "fromid" ' from ID
                                strMySQL = " SELECT Lib_tblItem.ID FROM Lib_tblItem WHERE Lib_tblItem.ID >= " & arrValue(intCount)
                            Case "toid" ' to ID
                                strMySQL = " SELECT Lib_tblItem.ID FROM Lib_tblItem WHERE Lib_tblItem.ID <= " & arrValue(intCount)
                            Case "reviewer" ' nguoi kiem tra
                                Select Case UCase(strDBServer)
                                    Case "SQLSERVER"
                                        strMySQL = " SELECT Lib_tblItem.ID FROM Lib_tblItem WHERE Lib_tblItem.Reviewer LIKE N'%" & arrValue(intCount) & "%'"
                                    Case "ORACLE"
                                        strMySQL = " SELECT Lib_tblItem.ID FROM Lib_tblItem WHERE Lib_tblItem.Reviewer LIKE '" & arrValue(intCount) & "'"
                                End Select
                            Case "fromissueddate" 'from ngay phat hanh
                                strMySQL = " SELECT Ser_tblIssue.ItemID as ID FROM Ser_tblIssue WHERE Ser_tblIssue.IssuedDate >= "
                                Select Case UCase(strDBServer)
                                    Case "SQLSERVER"
                                        strMySQL = strMySQL & "CONVERT(datetime, '" & arrValue(intCount) & "', 103)"
                                    Case "ORACLE"
                                        strMySQL = strMySQL & "To_Date('" & arrValue(intCount) & "', 'dd/mm/yyyy')"
                                End Select
                            Case "toissueddate" ' to ngay phat hanh
                                strMySQL = " SELECT Ser_tblIssue.ItemID as ID FROM Ser_tblIssue WHERE Ser_tblIssue.IssuedDate <= "
                                Select Case UCase(strDBServer)
                                    Case "SQLSERVER"
                                        strMySQL = strMySQL & "CONVERT(datetime, '" & arrValue(intCount) & "', 103)"
                                    Case "ORACLE"
                                        strMySQL = strMySQL & "To_Date('" & arrValue(intCount) & "', 'dd/mm/yyyy')"
                                End Select
                            Case "copynumber" ' ma xep gia
                                strMySQL = " SELECT Lib_tblHolding.ItemID as ID FROM Lib_tblHolding WHERE Lib_tblHolding.CopyNumber LIKE '%" & arrValue(intCount) & "%'"
                            Case "isbn" ' ISBN
                                strMySQL = " SELECT Cat_tblDicNumber.ItemID FROM Cat_tblDicNumber WHERE Cat_tblDicNumber.Number LIKE '%" & arrValue(intCount) & "%' AND Cat_tblDicNumber.FieldCode = '020$a'"
                            Case "issn" ' ISSN
                                strMySQL = " SELECT Cat_tblDicNumber.ItemID FROM Cat_tblDicNumber WHERE Cat_tblDicNumber.Number LIKE '%" & arrValue(intCount) & "%' AND Cat_tblDicNumber.FieldCode = '022$a'"
                            Case "itemtype" ' dang tai lieu
                                'If Not IsNumeric(arrValue(intCount)) Then
                                '    Select Case UCase(strDBServer)
                                '        Case "SQLSERVER"
                                '            strMySQL = " SELECT ITEM.ID FROM ITEM, Cat_tblDic_ItemType WHERE ITEM.TypeID = Cat_tblDic_ItemType.ID AND Cat_tblDic_ItemType.TypeCode IN (N'" & Replace(arrValue(intCount), "''", "'") & "')"
                                '        Case "ORACLE"
                                '            strMySQL = " SELECT ITEM.ID FROM ITEM, Cat_tblDic_ItemType WHERE ITEM.TypeID = Cat_tblDic_ItemType.ID AND Cat_tblDic_ItemType.TypeCode IN ('" & Replace(arrValue(intCount), "''", "'") & "')"
                                '    End Select
                                'Else
                                '    If arrValue(intCount) > 0 Then
                                '        strMySQL = "SELECT ITEM.ID FROM Lib_tblItem WHERE ITEM.TypeID = " & arrValue(intCount)
                                '    End If
                                'End If
                                strMySQL = "SELECT Lib_tblItem.ID FROM Lib_tblItem INNER JOIN Lib_tblItemFile on Lib_tblItem.ID = Lib_tblItemFile.ItemID WHERE Lib_tblItemFile.Status = 0 AND Lib_tblItem.TypeID IN (" & arrValue(intCount) & ")"
                            Case "librarytype" ' thu vien
                                If Not arrValue(intCount) Is Nothing AndAlso arrValue(intCount) <> "" Then
                                    strMySQL = "SELECT Lib_tblItem.ID FROM Lib_tblItem WHERE Lib_tblItem.LibId IN (" & arrValue(intCount) & ",9999)"
                                Else
                                    strMySQL = "SELECT Lib_tblItem.ID FROM Lib_tblItem WHERE Lib_tblItem.LibId IN (" & arrValue(intCount) & ")"
                                End If
                            Case "formattype" ' thu vien
                                strMySQL = "SELECT Lib_tblItem.ID FROM Lib_tblItem WHERE Lib_tblItem.FormatID IN (" & arrValue(intCount) & ")"
                            Case "cataloguer" ' nguoi biem muc
                                Select Case UCase(strDBServer)
                                    Case "SQLSERVER"
                                        strMySQL = " SELECT Lib_tblItem.ID FROM Lib_tblItem WHERE Lib_tblItem.Cataloguer LIKE N'%" & arrValue(intCount) & "%'"
                                    Case "ORACLE"
                                        strMySQL = " SELECT Lib_tblItem.ID FROM Lib_tblItem WHERE Lib_tblItem.Cataloguer LIKE '" & arrValue(intCount) & "'"
                                End Select
                            Case "bbk/ddc" ' chi so phan loai
                                strMySQL = " SELECT Lib_tblItemDDC.ItemID as ID FROM Lib_tblItemDDC, Cat_tblDic_ClassDDC WHERE Cat_tblDic_ClassDDC.ID = Lib_tblItemDDC.DDCID AND Lib_tblItemDDC.FieldCode = '082$a' AND "
                                Select Case UCase(strDBServer)
                                    Case "SQLSERVER"
                                        strMySQL = strMySQL & " (Cat_tblDic_ClassDDC.AccessEntry LIKE N'%" & objBCSP.ProcessVal(arrValue(intCount)) & "%' OR Cat_tblDic_ClassDDC.VietnameseAccent LIKE '%" & objBCSP.CutVietnameseAccent(objBCSP.ProcessVal(arrValue(intCount))) & "%' )"
                                    Case "ORACLE"
                                        strMySQL = strMySQL & " (Cat_tblDic_ClassDDC.AccessEntry LIKE '" & objBCSP.ProcessVal(arrValue(intCount)) & "' OR Cat_tblDic_ClassDDC.VietnameseAccent LIKE '" & objBCSP.CutVietnameseAccent(objBCSP.ProcessVal(arrValue(intCount))) & "' )"
                                End Select
                            Case "bbk" ' chi so phan loai
                                strMySQL = " SELECT Lib_tblItemBBK.ItemID as ID FROM Lib_tblItemBBK, Cat_tblDic_ClassBBK WHERE Cat_tblDic_ClassBBK.ID = Lib_tblItemBBK.BBKID AND Cat_tblDic_ClassBBK.FieldCode = '094$a' AND Cat_tblDic_ClassBBK.AccessEntry"
                                Select Case UCase(strDBServer)
                                    Case "SQLSERVER"
                                        strMySQL = strMySQL & " LIKE N'%" & objBCSP.ProcessVal1(arrValue(intCount)) & "%'"
                                    Case "ORACLE"
                                        strMySQL = strMySQL & " LIKE '" & objBCSP.ProcessVal1(arrValue(intCount)) & "'"
                                End Select
                            Case "ddc" ' chi so phan loai
                                strMySQL = " SELECT Lib_tblItemDDC.ItemID as ID FROM Lib_tblItemDDC, Cat_tblDic_ClassDDC WHERE Cat_tblDic_ClassDDC.ID = Lib_tblItemDDC.DDCID AND Cat_tblDic_ClassDDC.FieldCode = '082$a' AND Cat_tblDic_ClassDDC.AccessEntry"
                                Select Case UCase(strDBServer)
                                    Case "SQLSERVER"
                                        strMySQL = strMySQL & " LIKE N'%" & objBCSP.ProcessVal1(arrValue(intCount)) & "%'"
                                    Case "ORACLE"
                                        strMySQL = strMySQL & " LIKE '" & objBCSP.ProcessVal1(arrValue(intCount)) & "'"
                                End Select
                            Case "keyword" ' tu khoa
                                Select Case UCase(strDBServer)
                                    Case "SQLSERVER"
                                        strMySQL = " SELECT Lib_tblItemKeyword.ItemID as ID FROM Lib_tblItemKeyword, Cat_tblDicKeyword WHERE Cat_tblDicKeyword.ID = Lib_tblItemKeyword.KeyWordID AND Lib_tblItemKeyword.FieldCode = '653$a' AND "
                                        strMySQL = strMySQL & " (Cat_tblDicKeyword.AccessEntry LIKE N'%" & objBCSP.ProcessVal(arrValue(intCount)) & "%' OR Cat_tblDicKeyword.VietnameseAccent LIKE '%" & objBCSP.CutVietnameseAccent(objBCSP.ProcessVal(arrValue(intCount))) & "%' )"
                                    Case "ORACLE"
                                        strMySQL = " SELECT Lib_tblItemKeyword.ItemID as ID FROM Lib_tblItemKeyword, Cat_tblDicKeyword WHERE Cat_tblDicKeyword.ID = Lib_tblItemKeyword.KeyWordID AND Lib_tblItemKeyword.FieldCode = '653$a' AND "
                                        strMySQL = strMySQL & " (Cat_tblDicKeyword.AccessEntry LIKE '" & objBCSP.ProcessVal(arrValue(intCount)) & "' OR Cat_tblDicKeyword.VietnameseAccent LIKE '" & objBCSP.CutVietnameseAccent(objBCSP.ProcessVal(arrValue(intCount))) & "' )"
                                End Select
                            Case "udc" ' chi so phan loai udc
                                strMySQL = " SELECT Lib_tblItemUDC.ItemID as ID FROM Lib_tblItemUDC, Cat_tblDic_ClassUDC WHERE Cat_tblDic_ClassUDC.ID = Lib_tblItemUDC.UDCID AND Lib_tblItemUDC.FieldCode = '080$a' AND "
                                Select Case UCase(strDBServer)
                                    Case "SQLSERVER"
                                        strMySQL = strMySQL & " (Cat_tblDic_ClassUDC.AccessEntry LIKE N'%" & objBCSP.ProcessVal(arrValue(intCount)) & "%' OR Cat_tblDic_ClassUDC.VietnameseAccent LIKE '%" & objBCSP.CutVietnameseAccent(objBCSP.ProcessVal(arrValue(intCount))) & "%' )"
                                    Case "ORACLE"
                                        strMySQL = strMySQL & " (Cat_tblDic_ClassUDC.AccessEntry LIKE '" & objBCSP.ProcessVal(arrValue(intCount)) & "' OR Cat_tblDic_ClassUDC.VietnameseAccent LIKE '" & objBCSP.CutVietnameseAccent(objBCSP.ProcessVal(arrValue(intCount))) & "' )"
                                End Select
                            Case "nsc" ' chi so phan loai nsc
                                strMySQL = " SELECT Lib_tblItemNSC.ItemID as ID FROM Lib_tblItemNSC, Cat_tblDic_ClassNSC WHERE Cat_tblDic_ClassNSC.ID = Lib_tblItemNSC.NSCID AND Lib_tblItemNSC.FieldCode='084$a' AND "
                                Select Case UCase(strDBServer)
                                    Case "SQLSERVER"
                                        strMySQL = strMySQL & " LIKE N'%" & objBCSP.ProcessVal(arrValue(intCount)) & "%'"
                                    Case "ORACLE"
                                        strMySQL = strMySQL & " LIKE '" & objBCSP.ProcessVal(arrValue(intCount)) & "'"
                                End Select
                            Case "subjectheading" ' tieu de de muc
                                strMySQL = " SELECT Lib_tblItemSH.ItemID as ID FROM Lib_tblItemSH, Cat_tblDicSH WHERE Cat_tblDicSH.DicItemID = Lib_tblItemSH.SHID AND Lib_tblItemSH.FieldCode = '650$a' AND "
                                Select Case UCase(strDBServer)
                                    Case "SQLSERVER"
                                        strMySQL = strMySQL & " (Cat_tblDicSH.AccessEntry LIKE N'%" & objBCSP.ProcessVal(arrValue(intCount)) & "%' OR Cat_tblDicSH.VietnameseAccent LIKE '%" & objBCSP.CutVietnameseAccent(objBCSP.ProcessVal(arrValue(intCount))) & "%' )"
                                    Case "ORACLE"
                                        strMySQL = strMySQL & " (Cat_tblDicSH.AccessEntry LIKE '" & objBCSP.ProcessVal(arrValue(intCount)) & "' OR Cat_tblDicSH.VietnameseAccent LIKE '" & objBCSP.CutVietnameseAccent(objBCSP.ProcessVal(arrValue(intCount))) & "' )"
                                End Select
                            Case "thesissubject" ' Chuyen nganh luan an
                                strMySQL = " SELECT Lib_tblItemThesisSubject.ItemID as ID FROM Cat_tblDicThesisSubject, Lib_tblItemThesisSubject WHERE Cat_tblDicThesisSubject.ID = Lib_tblItemThesisSubject.SubjectID AND Lib_tblItemThesisSubject.FieldCode = '915$b' AND "
                                Select Case UCase(strDBServer)
                                    Case "SQLSERVER"
                                        strMySQL = strMySQL & " (Cat_tblDicThesisSubject.AccessEntry LIKE N'%" & objBCSP.ProcessVal(arrValue(intCount)) & "%' OR Cat_tblDicThesisSubject.VietnameseAccent LIKE '%" & objBCSP.CutVietnameseAccent(objBCSP.ProcessVal(arrValue(intCount))) & "%' )"
                                    Case "ORACLE"
                                        strMySQL = strMySQL & " (Cat_tblDicThesisSubject.AccessEntry LIKE '" & objBCSP.ProcessVal(arrValue(intCount)) & "' OR Cat_tblDicThesisSubject.VietnameseAccent LIKE '" & objBCSP.CutVietnameseAccent(objBCSP.ProcessVal(arrValue(intCount))) & "' )"
                                End Select
                            Case "language" ' ngon ngu 041$a
                                strMySQL = " SELECT Lib_tblItemLanguage.ItemID as ID FROM Cat_tblDic_Language, Lib_tblItemLanguage WHERE Cat_tblDic_Language.ID = Lib_tblItemLanguage.LanguageID AND Lib_tblItemLanguage.FieldCode = '041$a' AND "
                                Select Case UCase(strDBServer)
                                    Case "SQLSERVER"
                                        strMySQL = strMySQL & " (Cat_tblDic_Language.AccessEntry LIKE N'%" & objBCSP.ProcessVal(arrValue(intCount)) & "%' OR Cat_tblDic_Language.VietnameseAccent LIKE '%" & objBCSP.CutVietnameseAccent(objBCSP.ProcessVal(arrValue(intCount))) & "%' )"
                                    Case "ORACLE"
                                        strMySQL = strMySQL & " (Cat_tblDic_Language.AccessEntry LIKE '" & objBCSP.ProcessVal(arrValue(intCount)) & "' OR Cat_tblDic_Language.VietnameseAccent LIKE '" & objBCSP.CutVietnameseAccent(objBCSP.ProcessVal(arrValue(intCount))) & "' )"
                                End Select
                            Case Else ' cac truong hop con lai -- dung tu dien tham chieu
                                If IsNumeric(arrName(intCount)) Then
                                    TblCatDicList = objBDic.GetCatDicList(arrName(intCount))
                                    strval1 = objBCSP.ProcessVal(arrValue(intCount))
                                    If TblCatDicList.Rows.Count > 0 Then
                                        'Alter by chuyenpt(22/08/07): tim kiem khong dau
                                        strMySQL = " SELECT ItemID AS ID FROM " & Trim(TblCatDicList.Rows(0).Item("DicTable") & "") & ", " & Trim(TblCatDicList.Rows(0).Item("IndexTable") & "") & " WHERE " & Trim(TblCatDicList.Rows(0).Item("DicTable") & "") & "." & Trim(TblCatDicList.Rows(0).Item("DicIDField") & "") & " = " & Trim(TblCatDicList.Rows(0).Item("IndexTable") & "") & "." & Trim(TblCatDicList.Rows(0).Item("IndexIDField") & "")
                                        strSQLNext = CStr(TblCatDicList.Rows(0).Item("SearchFields")).Trim
                                        strSQLNext = Trim(TblCatDicList.Rows(0).Item("DicTable")) & "." & strSQLNext.Replace(",", "," & Trim(TblCatDicList.Rows(0).Item("DicTable")) & ".")
                                        strSQLNext = " AND (" & strSQLNext
                                        If Right(strSQLNext, 1) <> "," Then
                                            strSQLNext = strSQLNext & ","
                                        End If
                                        Select Case UCase(strDBServer)
                                            Case "SQLSERVER"
                                                strMySQL = strMySQL & strSQLNext.Replace(",", " LIKE N'%" & strval1 & "%' OR ")
                                                strMySQL = Left(strMySQL, Len(strMySQL) - 3) & ")"
                                            Case "ORACLE"
                                                strMySQL = strMySQL & strSQLNext.Replace(",", " LIKE '" & strval1 & "' OR ")
                                                strMySQL = Left(strMySQL, Len(strMySQL) - 3) & ")"
                                        End Select
                                        TblCatDicList.Clear()
                                    End If
                                Else
                                    strMySQL = ""
                                End If
                        End Select
                        If strMySQL <> "" Then
                            Select Case arrBool(intCount)
                                Case "AND"
                                    strFinalSQL = strFinalSQL & " AND Lib_tblItem.ID IN (" & strMySQL & ")"
                                Case "OR"
                                    strUnionSQL = strUnionSQL & " UNION " & strMySQL
                                Case "NOT"
                                    strFinalSQL = strFinalSQL & " AND Lib_tblItem.ID NOT IN (" & strMySQL & ")"
                            End Select

                            'Select Case UCase(strDBServer)
                            '    Case "SQLSERVER"
                            '        Select Case arrBool(intCount)
                            '            Case "AND"
                            '                strFinalSQL = strFinalSQL & " AND ITEM.ID IN (" & strMySQL & ")"
                            '            Case "OR"
                            '                strUnionSQL = strUnionSQL & " UNION " & strMySQL
                            '            Case "NOT"
                            '                strFinalSQL = strFinalSQL & " AND ITEM.ID NOT IN (" & strMySQL & ")"
                            '        End Select
                            '    Case "ORACLE"
                            '        Select Case arrBool(intCount)
                            '            Case "AND"
                            '                strFinalSQL = strFinalSQL & " INTERSECT " & strMySQL
                            '            Case "OR"
                            '                strUnionSQL = strUnionSQL & " UNION " & strMySQL
                            '            Case "NOT"
                            '                strFinalSQL = strFinalSQL & " MINUS " & strMySQL
                            '        End Select
                            'End Select
                        End If
                    End If
                Next
            End If


            ' add more field to sort
            Select Case UCase(strSortBy)
                Case "TITLE" ' sap xep theo nhan de 245 --> ITEM_TILE
                    Select Case strDBServer
                        Case "SQLSERVER"
                            strSQLRet = "SELECT DISTINCT Lib_tblItem.ID,Lib_tblField200S.Content FROM Lib_tblItem LEFT JOIN Lib_tblField200S ON Lib_tblItem.ID = Lib_tblField200S.ItemID AND Lib_tblField200S.FieldCode='245' LEFT JOIN Lib_tblItemFile ON Lib_tblItem.ID = Lib_tblItemFile.ItemID AND Lib_tblItemFile.Status = 0 WHERE Lib_tblItem.OPAC = 1 "
                        Case Else
                            strSQLRet = "SELECT DISTINCT Lib_tblItem.ID,Lib_tblField200S.Content FROM Lib_tblItem, Lib_tblField200S WHERE Lib_tblItem.ID = Lib_tblField200S.ItemID AND Lib_tblField200S.FieldCode='245' AND OPAC = 1 "
                    End Select
                Case "AUTHOR" ' sap xep theo tac gia 100$a --> Cat_tblDicAuthor
                    Select Case strDBServer
                        Case "SQLSERVER"
                            strSQLRet = "SELECT DISTINCT Lib_tblItem.ID,Cat_tblDicAuthor.DisplayEntry AS Content FROM Lib_tblItem LEFT JOIN Lib_tblItem_Author ON Lib_tblItem.ID = Lib_tblItem_Author.ItemID AND Lib_tblItem_Author.FieldCode='100$a' LEFT JOIN Cat_tblDicAuthor ON Lib_tblItem_Author.AuthorID = Cat_tblDicAuthor.ID LEFT JOIN Lib_tblItemFile ON Lib_tblItem.ID = Lib_tblItemFile.ItemID AND Lib_tblItemFile.Status = 0 WHERE Lib_tblItem.OPAC = 1 "
                        Case Else
                            strSQLRet = "SELECT DISTINCT Lib_tblItem.ID,Cat_tblDicAuthor.DisplayEntry AS Content FROM Lib_tblItem, Cat_tblDicAuthor, Lib_tblItem_Author WHERE Lib_tblItem.ID = Lib_tblItem_Author.ItemID AND Lib_tblItem_Author.AuthorID = Cat_tblDicAuthor.ID AND Lib_tblItem_Author.FieldCode='100$a' AND OPAC = 1"
                    End Select
                Case "YEAR" ' sap xep theo nam xuat ban 260$c --> Cat_tblDicYear
                    Select Case strDBServer
                        Case "SQLSERVER"
                            strSQLRet = "SELECT DISTINCT Lib_tblItem.ID, Cat_tblDicYear.Year AS Content FROM Lib_tblItem LEFT JOIN Cat_tblDicYear ON Lib_tblItem.ID = Cat_tblDicYear.ItemID AND Cat_tblDicYear.FieldCode='260$c' LEFT JOIN Lib_tblItemFile ON Lib_tblItem.ID = Lib_tblItemFile.ItemID AND Lib_tblItemFile.Status = 0 WHERE Lib_tblItem.OPAC = 1"
                        Case Else
                            strSQLRet = "SELECT DISTINCT Lib_tblItem.ID, Cat_tblDicYear.Year AS Content FROM Lib_tblItem, Cat_tblDicYear WHERE Lib_tblItem.ID = Cat_tblDicYear.ItemID AND Cat_tblDicYear.FieldCode='260$c' AND OPAC = 1"
                    End Select
                Case "PUBLISH" ' sap xep theo nha xuat ban --> Cat_tblDicPublisher
                    Select Case strDBServer
                        Case "SQLSERVER"
                            strSQLRet = "SELECT DISTINCT Lib_tblItem.ID, Cat_tblDicPublisher.DisplayEntry AS Content FROM Lib_tblItem LEFT JOIN Lib_tblItemPublisher ON Lib_tblItem.ID = Lib_tblItemPublisher.ItemID AND Lib_tblItemPublisher.FieldCode = '260$b' LEFT JOIN Cat_tblDicPublisher ON Lib_tblItemPublisher.PublisherID = Cat_tblDicPublisher.ID LEFT JOIN Lib_tblItemFile ON Lib_tblItem.ID = Lib_tblItemFile.ItemID AND Lib_tblItemFile.Status = 0 WHERE Lib_tblItem.OPAC = 1"
                        Case Else
                            strSQLRet = "SELECT DISTINCT Lib_tblItem.ID, Cat_tblDicPublisher.DisplayEntry AS Content FROM Lib_tblItem, Cat_tblDicPublisher, Lib_tblItemPublisher WHERE Lib_tblItem.ID = Lib_tblItemPublisher.ItemID AND Lib_tblItemPublisher.PublisherID = Cat_tblDicPublisher.ID AND Lib_tblItemPublisher.FieldCode = '260$b' AND OPAC = 1"
                    End Select
                Case Else
                    strSQLRet = "SELECT DISTINCT Lib_tblItem.ID,' ' AS Content FROM Lib_tblItem WHERE OPAC = 1 "
            End Select
            If blnSecuredOPAC Then
                strSQLRet = strSQLRet & " AND AccessLevel <= " & bytAccessLevel
            End If
            If strUnionSQL <> "" Then
                strUnionSQL = Right(strUnionSQL, strUnionSQL.Length - 6)
                strUnionSQL = "AND Lib_tblItem.ID IN (" & strUnionSQL & ")"
                strSQLRet = "(" & strSQLRet & " " & strFinalSQL & ") UNION (" & strSQLRet & " " & strUnionSQL & ")"
            Else
                'strFinalSQL = strFinalSQL & " AND Lib_tblItem.ID NOT IN (SELECT ItemID FROM Lib_tblItemFile)"
                'strSQLRet = strSQLRet & " " & strFinalSQL & " AND Lib_tblItem.ID NOT IN (SELECT ItemID FROM Lib_tblItemFile)"
                'SonPQ 20180726, check loi khong tim duoc TLDT khi search fulltext
                strSQLRet = strSQLRet & " " & strFinalSQL '& " AND Lib_tblItem.ID NOT IN (SELECT ItemID FROM Lib_tblItemFile)"
            End If

            ' if intTop <=0 select Ubound_search from sys_parameter table
            If intTop <= 0 Then
                Dim arrName(0) As String
                arrName(0) = "SEARCH_UBOUND"
                intTop = objBCDBS.GetSystemParameters(arrName)(0)
                If intTop = 0 Then
                    intTop = 1000000000
                End If
            End If

            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    FormingSQL = "SELECT TOP " & intTop & " eMicLib6x.* FROM(" & strSQLRet & ") eMicLib6x"
                    If Me.ItemIDs <> "" Then
                        FormingSQL &= " WHERE eMicLib6x.ID IN (" & Me.ItemIDs & ")"
                    End If


                    'If Me.ItemIDs <> "" Then
                    '    FormingSQL &= " WHERE eMicLib6x.ID IN (" & Me.ItemIDs & ")"
                    'End If


                Case "ORACLE"
                    FormingSQL = "SELECT eMicLib6x.* FROM(" & strSQLRet & ")eMicLib6x WHERE ROWNUM <= " & intTop
                    If Me.ItemIDs <> "" Then
                        FormingSQL &= " AND eMicLib6x.ID IN (" & Me.ItemIDs & ")"
                    End If
            End Select
        End Function

        ' Purpose: FormmingSQLImage
        ' Input: 
        ' Output: 
        ' Created by:
        Public Function FormmingSQLImage() As String
            Dim strSQL As String
            Dim strTable As String
            Dim strSQLRet As String
            strTable = "Cat_tblEdataFile A"
            If strTitle <> "" Then
                strTable = strTable & ", Lib_tblItemTitle B"
                strSQL = strSQL & " AND B.ITEMID = A.ITEMID AND B.TITLE Like N'%" & strTitle & "%'"
            End If
            If strAuthor <> "" Then
                strTable = strTable & ", Lib_tblItem_Author C, Cat_tblDicAuthor D"
                strSQL = strSQL & " AND C.AUTHORID = D.ID AND C.ITEMID = A.ITEMID AND D.ACCESSENTRY = LIKE N'%" & strAuthor & "%'"
            End If
            If strKeyWord <> "" Then
                strTable = strTable & ", Lib_tblItemKeyword E, Cat_tblDicKeyword F"
                strSQL = strSQL & " AND E.KEYWORDID = F.ID AND F.ACCESSENTRY LIKE N'%" & strKeyWord & "%'"
            End If
            'If intBitmapType <> 0 Then
            '    strSQL = strSQL & " AND BitmapType = " & intBitmapType
            'End If
            'If strColorMode <> "" Then
            '    strSQL = strSQL & " AND ColorModel = '" & strColorMode & "'"
            'End If
            'If intMinWidthImage <> 0 Then
            '    strSQL = strSQL & " AND ImgWidth >= " & intMinWidthImage
            'End If
            'If intMaxWidthImage <> 0 Then
            '    strSQL = strSQL + " AND ImgWidth <= " & intMaxWidthImage
            'End If
            'If intMinHeigthImage <> 0 Then
            '    strSQL = strSQL & " AND ImgHeight >= " & intMinHeigthImage
            'End If
            'If intMaxHeigthImage <> 0 Then
            '    strSQL = strSQL & " AND ImgHeight >= " & intMaxHeigthImage
            'End If
            'If intMinResImage <> 0 Then
            '    strSQL = strSQL & " AND Xdpi >= " & intMinResImage
            'End If
            'If intMaxResImage <> 0 Then
            '    strSQL = strSQL & " AND Xdpi >= " & intMaxResImage
            'End If
            'If intMinSizeImage <> 0 Then
            '    strSQL = strSQL & " AND FileSize >= " & intMinSizeImage
            'End If
            'If intMaxSizeImage <> 0 Then
            '    strSQL = strSQL & " AND FileSize >= " & intMaxSizeImage
            'End If
            If strSQL <> "" Then
                strSQL = Right(strSQL, Len(strSQL) - 5)
                strSQL = "SELECT  A.ID FROM " & strTable & " WHERE " & strSQL
            End If

            ' add more field to sort
            Select Case UCase(strSortBy)
                Case "TITLE" ' sap xep theo nhan de 245 --> ITEM_TILE
                    strSQLRet = "SELECT DISTINCT Lib_tblItem.ID, Lib_tblField200S.Content FROM Lib_tblItem, Lib_tblField200S WHERE Lib_tblItem.ID = Lib_tblField200S.ItemID AND Lib_tblField200S.FieldCode = '245' AND OPAC = 1 "
                Case "AUTHOR" ' sap xep theo tac gia 100$a --> Cat_tblDicAuthor
                    strSQLRet = "SELECT DISTINCT Lib_tblItem.ID, Cat_tblDicAuthor.DisplayEntry AS Content FROM Lib_tblItem, Cat_tblDicAuthor, Lib_tblItem_Author WHERE Lib_tblItem.ID = Lib_tblItem_Author.ItemID AND Lib_tblItem_Author.AuthorID = Cat_tblDicAuthor.ID AND Lib_tblItem_Author.FieldCode = '100$a' AND OPAC = 1 "
                Case "YEAR" ' sap xep theo nam xuat ban 260$c --> Cat_tblDicYear
                    strSQLRet = "SELECT DISTINCT Lib_tblItem.ID, Cat_tblDicYear.Year AS Content FROM Lib_tblItem, Cat_tblDicYear WHERE Lib_tblItem.ID = Cat_tblDicYear.ItemID AND Cat_tblDicYear.FieldCode = '260$c' AND OPAC = 1 "
                Case "PUBLISH" ' sap xep theo nha xuat ban --> Cat_tblDicPublisher
                    strSQLRet = "SELECT DISTINCT Lib_tblItem.ID, Cat_tblDicPublisher.DisplayEntry AS Content FROM Lib_tblItem, Cat_tblDicPublisher, Lib_tblItemPublisher WHERE Lib_tblItem.ID = Lib_tblItemPublisher.ItemID AND Lib_tblItemPublisher.PublisherID = Cat_tblDicPublisher.ID AND Lib_tblItemPublisher.FieldCode = '260$b' AND OPAC = 1 "
                Case Else
                    strSQLRet = "SELECT DISTINCT Lib_tblItem.ID FROM Lib_tblItem WHERE OPAC = 1 "
            End Select
            If blnSecuredOPAC Then
                strSQLRet = strSQLRet & " AND AccessLevel <= " & bytAccessLevel
            End If
            strSQLRet = strSQLRet & " AND Item.ID IN (" & strSQL & ")"

            FormmingSQLImage = strSQLRet
        End Function
        Public Function ExecuteQuery(Optional ByVal blnIsImage As Boolean = False) As DataTable
            Dim tblResult As New DataTable
            Dim tbl As New DataTable
            ' Dim dtvSorted As New DataView
            Dim dtrow As DataRow
            Dim inti As Integer
            Dim strIDSort As String = ""
            If Not blnIsImage Then
                objBCDBS.SQLStatement = FormingSQL()
            Else
                objBCDBS.SQLStatement = FormmingSQLImage()
            End If
            strSQLS = objBCDBS.SQLStatement

            Dim objParseSQL As New clsBParseSQL
            strSQLS = objParseSQL.ParseSQL(strSQLS)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SQL = strSQLS

            tblResult = Nothing
            tblResult = objBCDBS.RetrieveItemInfor(False)
            strErrorMsg = strErrorMsg & objBCDBS.ErrorMsg
            If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                If strSortBy <> "" Then
                    Dim sortDic As New SortedDictionary(Of String, Integer)
                    tblResult = objBCDBS.ConvertTable(tblResult, "Content", False)
                    Dim strKey As String = ""
                    Dim intValue As Integer = 0
                    For inti = 0 To tblResult.Rows.Count - 1
                        Try
                            strKey = ""
                            If Not IsDBNull(tblResult.Rows(inti).Item("Content")) Then
                                strKey = Trim(tblResult.Rows(inti).Item("Content"))
                            Else
                                'Neu gia tri rong thi sap xep nam o cuoi cung
                                If strSortBy = "YEAR" Then
                                    strKey &= "@"
                                Else
                                    strKey &= "z"
                                End If
                            End If
                            strKey &= tblResult.Rows(inti).Item("ID")
                            intValue = tblResult.Rows(inti).Item("ID")
                            sortDic.Add(strKey, intValue)
                        Catch ex As Exception
                            'pass duplicate record
                        End Try
                    Next

                    tbl.Columns.Add("ID")
                    For Each kvp As KeyValuePair(Of String, Integer) In sortDic
                        dtrow = tbl.NewRow
                        dtrow.Item(0) = kvp.Value
                        tbl.Rows.Add(dtrow)
                    Next kvp

                    If strErrorMsg = "" Then
                        If intSelectTop = 0 Then
                            intTop = tblResult.Rows.Count
                        Else
                            intTop = intSelectTop
                            If intSelectTop > tblResult.Rows.Count Then
                                intTop = tblResult.Rows.Count
                            End If
                        End If
                        ' tblResult = dtvSorted.Table
                        tblResult = tbl
                    End If
                End If
            End If
            Return tblResult
        End Function


        ' Purpose: Execute Query
        ' Input: Query string,TopRow
        ' Output: String IDs have been sorted
        ' Created by: PhuongTT
        Public Function ExecuteQueryOPAC(Optional ByVal blnIsImage As Boolean = False) As DataTable
            Dim tblResult As New DataTable
            Dim tbl As New DataTable
            Dim dtrow As DataRow
            Dim inti As Integer
            Dim strIDSort As String = ""
            If Not blnIsImage Then
                objBCDBS.SQLStatement = FormingSQL()
            Else
                objBCDBS.SQLStatement = FormmingSQLImage()
            End If
            strSQLS = objBCDBS.SQLStatement

            Dim objParseSQL As New clsBParseSQL
            strSQLS = objParseSQL.ParseSQL(strSQLS)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SQL = strSQLS

            tblResult = Nothing
            tblResult = objBCDBS.RetrieveItemInfor(False)
            strErrorMsg = strErrorMsg & objBCDBS.ErrorMsg
            If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                If strSortBy <> "" Then
                    Dim sortDic As New SortedDictionary(Of String, Integer)
                    tblResult = objBCDBS.ConvertTable(tblResult, "Content", False)
                    Dim strKey As String = ""
                    Dim intValue As Integer = 0
                    For inti = 0 To tblResult.Rows.Count - 1
                        Try
                            strKey = ""
                            If Not IsDBNull(tblResult.Rows(inti).Item("Content")) Then
                                strKey = Trim(tblResult.Rows(inti).Item("Content"))
                            Else
                                'Neu gia tri rong thi sap xep nam o cuoi cung
                                If strSortBy = "YEAR" Then
                                    strKey &= "@"
                                Else
                                    strKey &= "z"
                                End If
                            End If
                            strKey &= tblResult.Rows(inti).Item("ID")
                            intValue = tblResult.Rows(inti).Item("ID")
                            sortDic.Add(strKey, intValue)
                        Catch ex As Exception
                            'pass duplicate record
                        End Try
                    Next

                    tbl.Columns.Add("ID")
                    For Each kvp As KeyValuePair(Of String, Integer) In sortDic
                        dtrow = tbl.NewRow
                        dtrow.Item(0) = kvp.Value
                        tbl.Rows.Add(dtrow)
                    Next kvp
                    If strErrorMsg = "" Then
                        If intSelectTop = 0 Then
                            intTop = tblResult.Rows.Count
                        Else
                            intTop = intSelectTop
                            If intSelectTop > tblResult.Rows.Count Then
                                intTop = tblResult.Rows.Count
                            End If
                        End If
                        If strSortBy = "YEAR" Then 'sort by desc
                            Dim tblTemp As New DataTable
                            tblTemp.Columns.Add("ID")
                            For i As Integer = tbl.Rows.Count - 1 To 0 Step -1
                                dtrow = tblTemp.NewRow
                                dtrow.Item(0) = tbl.Rows(i).Item(0)
                                tblTemp.Rows.Add(dtrow)
                            Next
                            tblResult = tblTemp
                        Else 'sort by asc
                            tblResult = tbl
                        End If
                    End If
                End If
            End If
            Return tblResult
        End Function

        Public Function ExecuteQuerySQL(ByVal strQSQL As String) As DataTable
            Dim tblResult As New DataTable
            Dim tbl As New DataTable
            ' Dim dtvSorted As New DataView
            Dim dtrow As DataRow
            Dim arrContent() As Object
            Dim intCount As Integer
            Dim inti As Integer
            Dim strIDSort As String = ""

            Dim objParseSQL As New clsBParseSQL
            strQSQL = objParseSQL.ParseSQL(strQSQL)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''
            objBCDBS.SQLStatement = strQSQL
            strSQLS = objBCDBS.SQLStatement
            Me.SQL = strSQLS
            tblResult = Nothing
            tblResult = objBCDBS.RetrieveItemInfor(False)
            strErrorMsg = strErrorMsg & objBCDBS.ErrorMsg
            If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                If strSortBy <> "" Then
                    Dim sortDic As New SortedDictionary(Of String, Integer)
                    tblResult = objBCDBS.ConvertTable(tblResult, "Content", False)
                    Dim strKey As String = ""
                    Dim intValue As Integer = 0
                    For inti = 0 To tblResult.Rows.Count - 1
                        Try
                            strKey = ""
                            If Not IsDBNull(tblResult.Rows(inti).Item("Content")) Then
                                strKey = Trim(tblResult.Rows(inti).Item("Content"))
                            Else
                                'Neu gia tri rong thi sap xep nam o cuoi cung
                                If strSortBy = "YEAR" Then
                                    strKey &= "@"
                                Else
                                    strKey &= "z"
                                End If
                            End If
                            strKey &= tblResult.Rows(inti).Item("ID")
                            intValue = tblResult.Rows(inti).Item("ID")
                            sortDic.Add(strKey, intValue)
                        Catch ex As Exception
                            'pass duplicate record
                        End Try
                    Next

                    tbl.Columns.Add("ID")
                    For Each kvp As KeyValuePair(Of String, Integer) In sortDic
                        dtrow = tbl.NewRow
                        dtrow.Item(0) = kvp.Value
                        tbl.Rows.Add(dtrow)
                    Next kvp

                    If strErrorMsg = "" Then
                        If intSelectTop = 0 Then
                            intTop = tblResult.Rows.Count
                        Else
                            intTop = intSelectTop
                            If intSelectTop > tblResult.Rows.Count Then
                                intTop = tblResult.Rows.Count
                            End If
                        End If
                        ' tblResult = dtvSorted.Table
                        tblResult = tbl
                    End If
                End If
            End If
            Return tblResult
        End Function


        Public Function eExecuteQuerySQL(ByVal strQSQL As String) As DataTable
            Dim tblResult As New DataTable
            Dim tbl As New DataTable
            Dim dtrow As DataRow
            Dim inti As Integer
            Try
                objBCDBS.SQLStatement = strQSQL
                strSQLS = objBCDBS.SQLStatement
                Me.SQL = strSQLS
                tblResult = Nothing
                tblResult = objBCDBS.RetrieveItemInfor(False)
                strErrorMsg = strErrorMsg & objBCDBS.ErrorMsg
                If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                    If strSortBy <> "" Then
                        Dim sortDic As New SortedDictionary(Of String, Integer)
                        'tblResult = objBCDBS.ConvertTable(tblResult, "Content", False)
                        Dim strKey As String = ""
                        Dim intValue As Integer = 0
                        For inti = 0 To tblResult.Rows.Count - 1
                            Try
                                strKey = ""
                                If Not IsDBNull(tblResult.Rows(inti).Item("Content")) Then
                                    strKey = Trim(tblResult.Rows(inti).Item("Content"))
                                Else
                                    'Neu gia tri rong thi sap xep nam o cuoi cung
                                    If strSortBy = "YEAR" Then
                                        strKey &= "@"
                                    Else
                                        strKey &= "z"
                                    End If
                                End If
                                strKey &= tblResult.Rows(inti).Item("ID")
                                intValue = tblResult.Rows(inti).Item("ID")
                                sortDic.Add(strKey, intValue)
                            Catch ex As Exception
                                'pass duplicate record
                            End Try
                        Next

                        tbl.Columns.Add("ID")
                        For Each kvp As KeyValuePair(Of String, Integer) In sortDic
                            dtrow = tbl.NewRow
                            dtrow.Item(0) = kvp.Value
                            tbl.Rows.Add(dtrow)
                        Next kvp

                        If strErrorMsg = "" Then
                            If intSelectTop = 0 Then
                                intTop = tblResult.Rows.Count
                            Else
                                intTop = intSelectTop
                                If intSelectTop > tblResult.Rows.Count Then
                                    intTop = tblResult.Rows.Count
                                End If
                            End If
                            If strSortBy = "YEAR" Then 'sort by desc
                                Dim tblTemp As New DataTable
                                tblTemp.Columns.Add("ID")
                                For i As Integer = tbl.Rows.Count - 1 To 0 Step -1
                                    dtrow = tblTemp.NewRow
                                    dtrow.Item(0) = tbl.Rows(i).Item(0)
                                    tblTemp.Rows.Add(dtrow)
                                Next
                                tblResult = tblTemp
                            Else 'sort by asc
                                tblResult = tbl
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
            End Try
            Return tblResult
        End Function


        ' Dispose sortByListIds
        ' Purpose: order by fields
        Public Function sortByListIds(ByVal IDs As String) As String
            Dim strMySQL As String = ""
            Select Case UCase(strSortBy)
                Case "TITLE" ' sap xep theo nhan de 245 --> ITEM_TILE
                    Select Case strDBServer
                        Case "SQLSERVER"
                            strMySQL = "SELECT DISTINCT Lib_tblItem.ID, Lib_tblField200S.Content FROM Lib_tblItem, Lib_tblField200S WHERE Lib_tblItem.ID = Lib_tblField200S.ItemID AND Lib_tblField200S.FieldCode = '245' AND Lib_tblItem.ID IN (" & IDs & ")"
                        Case Else
                            strMySQL = "SELECT DISTINCT Lib_tblItem.ID, Lib_tblField200S.Content FROM Lib_tblItem, Lib_tblField200S WHERE Lib_tblItem.ID = Lib_tblField200S.ItemID AND Lib_tblField200S.FieldCode = '245' AND INSTR(" & IDs & ",',' + CAST(Lib_tblItem.ID as nvarchar) +',') > 0"
                    End Select
                Case "AUTHOR" ' sap xep theo tac gia 100$a --> Cat_tblDicAuthor
                    Select Case strDBServer
                        Case "SQLSERVER"
                            strMySQL = "SELECT DISTINCT Lib_tblItem.ID, ISNULL(Cat_tblDicAuthor.DisplayEntry,'') AS Content FROM Lib_tblItem LEFT JOIN Lib_tblItem_Author ON Lib_tblItem.ID = Lib_tblItem_Author.ItemID AND Lib_tblItem_Author.FieldCode='100$a' LEFT JOIN Cat_tblDicAuthor ON Lib_tblItem_Author.AuthorID = Cat_tblDicAuthor.ID WHERE Lib_tblItem.ID IN (" & IDs & ")"
                        Case Else
                            strMySQL = "SELECT DISTINCT Lib_tblItem.ID, ISNULL(Cat_tblDicAuthor.DisplayEntry,'') AS Content FROM Lib_tblItem LEFT JOIN Lib_tblItem_Author ON Lib_tblItem.ID = Lib_tblItem_Author.ItemID AND Lib_tblItem_Author.FieldCode='100$a' LEFT JOIN Cat_tblDicAuthor ON Lib_tblItem_Author.AuthorID = Cat_tblDicAuthor.ID WHERE INSTR(" & IDs & ",',' + CAST(Lib_tblItem.ID as nvarchar) +',') > 0"
                    End Select
                Case "YEAR" ' sap xep theo nam xuat ban 260$c --> Cat_tblDicYear
                    Select Case strDBServer
                        Case "SQLSERVER"
                            strMySQL = "SELECT DISTINCT Lib_tblItem.ID, ISNULL(Cat_tblDicYear.Year,'') AS Content FROM Lib_tblItem LEFT JOIN Cat_tblDicYear ON Lib_tblItem.ID = Cat_tblDicYear.ItemID AND Cat_tblDicYear.FieldCode='260$c' WHERE Lib_tblItem.ID IN (" & IDs & ")"
                        Case Else
                            strMySQL = "SELECT DISTINCT Lib_tblItem.ID, ISNULL(Cat_tblDicYear.Year,'') AS Content FROM Lib_tblItem LEFT JOIN Cat_tblDicYear ON Lib_tblItem.ID = Cat_tblDicYear.ItemID AND Cat_tblDicYear.FieldCode='260$c' WHERE INSTR(" & IDs & ",',' + CAST(Lib_tblItem.ID as nvarchar) +',') > 0"
                    End Select
                Case "PUBLISH" ' sap xep theo nha xuat ban --> Cat_tblDicPublisher
                    Select Case strDBServer
                        Case "SQLSERVER"
                            strMySQL = "SELECT DISTINCT Lib_tblItem.ID, ISNULL(Cat_tblDicPublisher.DisplayEntry,'') AS Content FROM Lib_tblItem LEFT JOIN Lib_tblItemPublisher ON Lib_tblItem.ID = Lib_tblItemPublisher.ItemID AND Lib_tblItemPublisher.FieldCode = '260$b' LEFT JOIN Cat_tblDicPublisher ON Lib_tblItemPublisher.PublisherID=Cat_tblDicPublisher.ID WHERE Lib_tblItem.ID IN (" & IDs & ")"
                        Case Else
                            strMySQL = "SELECT DISTINCT Lib_tblItem.ID, ISNULL(Cat_tblDicPublisher.DisplayEntry,'') AS Content FROM Lib_tblItem LEFT JOIN Lib_tblItemPublisher ON Lib_tblItem.ID = Lib_tblItemPublisher.ItemID AND Lib_tblItemPublisher.FieldCode = '260$b' LEFT JOIN Cat_tblDicPublisher ON Lib_tblItemPublisher.PublisherID=Cat_tblDicPublisher.ID WHERE INSTR(" & IDs & ",',' + CAST(Lib_tblItem.ID as nvarchar) +',') > 0"
                    End Select
                Case "MXG"
                    Select Case strDBServer
                        Case "SQLSERVER"
                            strMySQL = "SELECT DISTINCT Lib_tblItem.ID, ISNULL((SELECT TOP 1 ISNULL(CopyNumber,'') FROM Lib_tblHolding WHERE Lib_tblItem.ID = Lib_tblHolding.ItemID AND InUsed = 0 AND Acquired = 1 AND InCirculation = 1 ),'') AS Content FROM Lib_tblItem WHERE Lib_tblItem.ID IN (" & IDs & ")"
                        Case Else
                            strMySQL = "SELECT DISTINCT Lib_tblItem.ID, ISNULL((SELECT TOP 1 ISNULL(CopyNumber,'') FROM Lib_tblHolding WHERE Lib_tblItem.ID = Lib_tblHolding.ItemID AND InUsed = 0 AND Acquired = 1 AND InCirculation = 1 ),'') AS Content FROM Lib_tblItem WHERE INSTR(" & IDs & ",',' + CAST(Lib_tblItem.ID as nvarchar) +',') > 0"
                    End Select
            End Select

            Return strMySQL
        End Function

        ' Dispose FormingFilterSQL
        ' Purpose: Get filter string 
        Public Function FormingFilterSQL(ByVal strFilterCondition As String, ByVal IDs As String, Optional ByVal strDelimiter1 As String = ",", Optional ByVal strDelimiter2 As String = "-") As String
            Dim strMySQL As String = ""

            Select Case strDBServer
                Case "SQLSERVER"
                    strMySQL = "SELECT Lib_tblItem.ID FROM Lib_tblItem WHERE Lib_tblItem.ID IN (" & IDs & ")"
                Case Else
                    strMySQL = "SELECT Lib_tblItem.ID FROM Lib_tblItem WHERE INSTR(" & IDs & ",',' + CAST(Lib_tblItem.ID as nvarchar) +',') > 0"
            End Select

            Select Case UCase(strSortBy)
                Case "TITLE" ' sap xep theo nhan de 245 --> ITEM_TILE
                    Select Case strDBServer
                        Case "SQLSERVER"
                            strMySQL = "SELECT DISTINCT Lib_tblItem.ID, Lib_tblField200S.Content FROM Lib_tblItem, Lib_tblField200S WHERE Lib_tblItem.ID = Lib_tblField200S.ItemID AND Lib_tblField200S.FieldCode = '245' AND Lib_tblItem.ID IN (" & IDs & ")"
                        Case Else
                            strMySQL = "SELECT DISTINCT Lib_tblItem.ID, Lib_tblField200S.Content FROM Lib_tblItem, Lib_tblField200S WHERE Lib_tblItem.ID = Lib_tblField200S.ItemID AND Lib_tblField200S.FieldCode = '245' AND INSTR(" & IDs & ",',' + CAST(Lib_tblItem.ID as nvarchar) +',') > 0"
                    End Select
                Case "AUTHOR" ' sap xep theo tac gia 100$a --> Cat_tblDicAuthor
                    Select Case strDBServer
                        Case "SQLSERVER"
                            strMySQL = "SELECT DISTINCT Lib_tblItem.ID, ISNULL(Cat_tblDicAuthor.DisplayEntry,'') AS Content FROM Lib_tblItem LEFT JOIN Lib_tblItem_Author ON Lib_tblItem.ID = Lib_tblItem_Author.ItemID  AND Lib_tblItem_Author.FieldCode = '100$a' LEFT JOIN Cat_tblDicAuthor ON Lib_tblItem_Author.AuthorID = Cat_tblDicAuthor.ID WHERE Lib_tblItem.ID IN (" & IDs & ")"
                        Case Else
                            strMySQL = "SELECT DISTINCT Lib_tblItem.ID, ISNULL(Cat_tblDicAuthor.DisplayEntry,'') AS Content FROM Lib_tblItem LEFT JOIN Lib_tblItem_Author ON Lib_tblItem.ID = Lib_tblItem_Author.ItemID  AND Lib_tblItem_Author.FieldCode = '100$a' LEFT JOIN Cat_tblDicAuthor ON Lib_tblItem_Author.AuthorID = Cat_tblDicAuthor.ID WHERE INSTR(" & IDs & ",',' + CAST(Lib_tblItem.ID as nvarchar) +',') > 0"
                    End Select
                Case "YEAR" ' sap xep theo nam xuat ban 260$c --> Cat_tblDicYear
                    Select Case strDBServer
                        Case "SQLSERVER"
                            strMySQL = "SELECT DISTINCT Lib_tblItem.ID, ISNULL(Cat_tblDicYear.Year,'') AS Content FROM Lib_tblItem LEFT JOIN Cat_tblDicYear ON Lib_tblItem.ID = Cat_tblDicYear.ItemID AND Cat_tblDicYear.FieldCode = '260$c' WHERE Lib_tblItem.ID IN (" & IDs & ")"
                        Case Else
                            strMySQL = "SELECT DISTINCT Lib_tblItem.ID, ISNULL(Cat_tblDicYear.Year,'') AS Content FROM Lib_tblItem LEFT JOIN Cat_tblDicYear ON Lib_tblItem.ID = Cat_tblDicYear.ItemID AND Cat_tblDicYear.FieldCode = '260$c' WHERE INSTR(" & IDs & ",',' + CAST(Lib_tblItem.ID as nvarchar) +',') > 0"
                    End Select
                Case "PUBLISH" ' sap xep theo nha xuat ban --> Cat_tblDicPublisher
                    Select Case strDBServer
                        Case "SQLSERVER"
                            strMySQL = "SELECT DISTINCT Lib_tblItem.ID, ISNULL(Cat_tblDicPublisher.DisplayEntry,'') AS Content FROM Lib_tblItem LEFT JOIN Lib_tblItemPublisher ON Lib_tblItem.ID = Lib_tblItemPublisher.ItemID AND Lib_tblItemPublisher.FieldCode = '260$b' LEFT JOIN Cat_tblDicPublisher ON Lib_tblItemPublisher.PublisherID = Cat_tblDicPublisher.ID WHERE Lib_tblItem.ID IN (" & IDs & ")"
                        Case Else
                            strMySQL = "SELECT DISTINCT Lib_tblItem.ID, ISNULL(Cat_tblDicPublisher.DisplayEntry,'') AS Content FROM Lib_tblItem LEFT JOIN Lib_tblItemPublisher ON Lib_tblItem.ID = Lib_tblItemPublisher.ItemID AND Lib_tblItemPublisher.FieldCode = '260$b' LEFT JOIN Cat_tblDicPublisher ON Lib_tblItemPublisher.PublisherID = Cat_tblDicPublisher.ID WHERE INSTR(" & IDs & ",',' + CAST(Lib_tblItem.ID as nvarchar) +',') > 0"
                    End Select
            End Select

            Dim strArray1() As String
            Dim strArray2() As String
            Dim intId As String = 0
            Dim intDicId As Integer = 0
            strArray1 = Split(strFilterCondition, strDelimiter1)
            For i As Integer = 0 To UBound(strArray1)
                strArray2 = Split(strArray1(i), strDelimiter2)
                If UBound(strArray2) = 1 Then
                    intDicId = strArray2(0)
                    intId = strArray2(1)
                    Select Case intDicId
                        Case 1 'Author
                            strMySQL &= " AND Lib_tblItem.ID IN (SELECT A.ItemID FROM Lib_tblItem_Author A WHERE A.AuthorID = " & intId & ")"
                        Case 2 'Publisher
                            strMySQL &= " AND Lib_tblItem.ID IN (SELECT A.ItemID FROM Lib_tblItemPublisher A WHERE A.PublisherID = " & intId & ")"
                        Case 3 'KeyWord
                            strMySQL &= " AND Lib_tblItem.ID IN (SELECT A.ItemID FROM Lib_tblItemKeyword A WHERE A.KeyWordID = " & intId & ")"
                        Case 4 'Series
                            strMySQL &= " AND Lib_tblItem.ID IN (SELECT A.ItemID FROM Lib_tblItemSeries A WHERE A.SeriesID = " & intId & ")"
                        Case 5 'SubjectHeading
                            strMySQL &= " AND Lib_tblItem.ID IN (SELECT A.ItemID FROM Lib_tblItemSH A WHERE A.SHID = " & intId & ")"
                        Case 6 'Language
                            strMySQL &= " AND Lib_tblItem.ID IN (SELECT A.ItemID FROM Lib_tblItemLanguage A WHERE A.LanguageID = " & intId & ")"
                        Case 7 'NLM
                            strMySQL &= " AND Lib_tblItem.ID IN (SELECT A.ItemID FROM Lib_tblItemNLM A WHERE A.NLMID = " & intId & ")"
                        Case 8 'DDC
                            strMySQL &= " AND Lib_tblItem.ID IN (SELECT A.ItemID FROM Lib_tblItemDDC A WHERE A.DDCID = " & intId & ")"
                        Case 9 'publisher year
                            strMySQL &= " AND Lib_tblItem.ID IN (SELECT A.ItemID FROM Cat_tblDicYear A WHERE Cast(A.Year as nvarchar) = Cast(" & intId & " as nvarchar))"
                        Case 10 'Item Type
                            'strMySQL &= " AND I.TypeID IN (SELECT A.ID FROM Cat_tblDic_ItemType A WHERE A.ID=" & intId & ")"
                            strMySQL &= " AND Lib_tblItem.TypeID = " & intId
                        Case 11 'Item Format
                            'strMySQL &= " AND I.TypeID IN (SELECT A.ID FROM Cat_tblDic_ItemType A WHERE A.ID=" & intId & ")"
                            strMySQL &= " AND Lib_tblItem.FormatID = " & intId
                        Case 12 'DDC
                            '082$- 082$a
                            'strMySQL &= " AND ITEM.ID IN (SELECT A.ItemID FROM Lib_tblItemDDC A JOIN Cat_tblDic_ClassDDC B ON B.ID = A.DDCID WHERE len(A.FieldCode)>3 And CHARINDEX('DDC'+Cast('" & intId.ToString & "' as nvarchar),'DDC'+" & "B.DisplayEntry)>0)"
                            strMySQL &= " AND Lib_tblItem.ID IN (SELECT A.ItemID FROM Lib_tblItemDDC A JOIN Cat_tblDic_ClassDDC B ON B.ID = A.DDCID WHERE A.FieldCode = '082$a' And '" & intId.ToString & "' = Left(B.DisplayEntry,Len('" & intId.ToString & "')))"
                    End Select
                End If
            Next
            Return strMySQL
        End Function

        Public Function getSQLSearchByBrowseID(ByVal intDicType As Integer, ByVal strDicID As String, Optional ByVal intLibID As Integer = 0) As String
            Dim strResult As String = ""
            Try
                Dim ConditionLibrary As String = ""
                ConditionLibrary = " And b.ItemID in (Select ID From Lib_tblItem Where LibID = 0 or LibId = " & intLibID & ")"
                Select Case intDicType
                    Case 1 'Author
                        strResult = "SELECT distinct b.ItemID as ID	FROM Cat_tblDicAuthor a INNER JOIN (SELECT distinct c.ItemID,c.AuthorID FROM Lib_tblItem_Author c where len(c.FieldCode) > 3) b on a.ID = b.AuthorID WHERE b.AuthorID  = " & strDicID
                        strResult &= ConditionLibrary
                    Case 2 'publisher
                        strResult = "SELECT  distinct b.ItemID as ID FROM Cat_tblDicPublisher a INNER JOIN (SELECT distinct c.ItemID,c.PublisherID FROM Lib_tblItemPublisher c where len(c.FieldCode) > 3) b on a.ID = b.PublisherID WHERE b.PublisherID = " & strDicID
                        strResult &= ConditionLibrary
                    Case 3 'KeyWord
                        strResult = "SELECT distinct b.ItemID as ID FROM Cat_tblDicKeyword a INNER JOIN (SELECT distinct c.ItemID,c.KeyWordID FROM Lib_tblItemKeyword c where len(c.FieldCode) > 3) b on a.ID = b.KeyWordID	WHERE b.KeyWordID = " & strDicID
                        strResult &= ConditionLibrary
                    Case 4 'Series
                        strResult = "SELECT distinct b.ItemID as ID FROM Cat_tblDicSeries a INNER JOIN (SELECT distinct c.ItemID,c.SeriesID FROM Lib_tblItemSeries c where len(c.FieldCode) > 3) b on a.ID = b.SeriesID	WHERE b.SeriesID = " & strDicID
                        strResult &= ConditionLibrary
                    Case 5 'Subjectheading
                        strResult = "SELECT  distinct b.ItemID as ID FROM Cat_tblDicSH a INNER JOIN (SELECT distinct c.ItemID,c.SHID FROM Lib_tblItemSH c where len(c.FieldCode) > 3) b on a.ID = b.SHID WHERE b.SHID = " & strDicID
                        strResult &= ConditionLibrary
                    Case 6 'Language
                        strResult = "SELECT distinct b.ItemID as ID FROM Cat_tblDic_Language a INNER JOIN (SELECT distinct c.ItemID,c.LanguageID FROM Lib_tblItemLanguage c where len(c.FieldCode) > 3) b on a.ID = b.LanguageID WHERE b.LanguageID = " & strDicID
                        strResult &= ConditionLibrary
                    Case 7 'NLM
                        strResult = "SELECT distinct b.ItemID as ID FROM Cat_tblDic_ClassNLM a INNER JOIN (SELECT distinct c.ItemID,c.NLMID FROM Lib_tblItemNLM c where len(c.FieldCode) > 3) b	on a.ID = b.NLMID WHERE b.NLMID = " & strDicID
                        strResult &= ConditionLibrary
                    Case 8 'DDC
                        strResult = "SELECT distinct b.ItemID as ID FROM Cat_tblDic_ClassDDC a INNER JOIN (SELECT distinct c.ItemID,c.DDCID FROM Lib_tblItemDDC c where len(c.FieldCode) > 3) b on a.ID = b.DDCID WHERE b.DDCID = " & strDicID
                        strResult &= ConditionLibrary
                    Case 9 'publisher years
                        ConditionLibrary = " And a.ItemID in (Select ID From Lib_tblItem Where LibID = 0 or LibId = " & intLibID & ")"
                        strResult = "SELECT distinct a.ItemID as ID	FROM Cat_tblDicYear a WHERE a.Year = '" & strDicID & "'"
                        strResult &= ConditionLibrary
                    Case 10 'Item Type
                        ConditionLibrary = " And ( b.LibId = " & intLibID & " or b.LibID = 0)"
                        If strDicID = "32" Then
                            strResult = "SELECT b.ID FROM  Cat_tblDic_ItemType a INNER JOIN Lib_tblItem b on a.ID = b.TypeID LEFT JOIN Lib_tblItemFile c on b.ID = c.ItemID WHERE c.Status = 0 And a.ID = " & strDicID
                        Else
                            strResult = "SELECT b.ID FROM  Cat_tblDic_ItemType a INNER JOIN Lib_tblItem b on a.ID = b.TypeID WHERE a.ID = " & strDicID
                        End If
                        strResult &= ConditionLibrary
                    Case 11 'electronic data
                        ConditionLibrary = " And (b.LibId = " & intLibID & " or b.LibID = 0)"
                        strResult = "SELECT distinct b.ID FROM Cat_tblDicFormat a JOIN Lib_tblItem b on a.ID = b.FormatID WHERE a.ID = " & strDicID
                        strResult &= ConditionLibrary
                    Case 12 'DDC TREEVIEW
                        ConditionLibrary = " And b.ItemID in (Select ID From Lib_tblItem Where LibID = 0 or LibId = " & intLibID & ")"
                        'strResult = "SELECT distinct  b.ItemID as ID FROM  Cat_tblDic_ClassDDC a JOIN (SELECT distinct c.ItemID,c.DDCID FROM Lib_tblItemDDC c where len(c.FieldCode)>3) b on a.ID = b.DDCID WHERE a.AccessEntry like '" & strDicID & "%'"
                        strResult = "SELECT distinct  b.ItemID as ID FROM  Cat_tblDic_ClassDDC a JOIN (SELECT distinct c.ItemID,c.DDCID FROM Lib_tblItemDDC c where c.FieldCode = '082$a') b on a.ID = b.DDCID WHERE '" & strDicID.ToString & "' = Left(a.DisplayEntry,Len('" & strDicID.ToString & "'))"
                        strResult &= ConditionLibrary
                    Case 13 'Title
                        ConditionLibrary = " And ( b.LibId = " & intLibID & " or b.LibID = 0)"
                        strResult = "SELECT distinct  b.ID FROM Lib_tblItem b INNER JOIN (SELECT distinct c.ItemID, c.Title FROM Lib_tblItemTitle c where c.FieldCode = '245') a on a.ItemID = b.ID WHERE b.ID = " & strDicID
                        strResult &= ConditionLibrary
                    Case 14 'Collection
                        ConditionLibrary = " And a.ItemID in (Select ID From Lib_tblItem Where LibID = 0 or LibId = " & intLibID & ")"
                        strResult = "SELECT distinct a.ItemID as ID FROM Cat_tblDic_Collection a JOIN Lib_tblItemCollection b on a.COLLECTIONID = b.ID WHERE b.ID = " & strDicID
                        strResult &= ConditionLibrary
                End Select
                Select Case UCase(strSortBy)
                    Case "TITLE" ' sap xep theo nhan de 245 --> ITEM_TILE
                        Select Case strDBServer
                            Case "SQLSERVER"
                                strResult = "SELECT DISTINCT Lib_tblItem.ID, Lib_tblField200S.Content FROM Lib_tblItem, Lib_tblField200S WHERE Lib_tblItem.ID = Lib_tblField200S.ItemID AND Lib_tblField200S.FieldCode = '245' AND Lib_tblItem.ID IN (" & strResult & ")"
                            Case Else
                                strResult = "SELECT DISTINCT Lib_tblItem.ID, Lib_tblField200S.Content FROM Lib_tblItem, Lib_tblField200S WHERE Lib_tblItem.ID = Lib_tblField200S.ItemID AND Lib_tblField200S.FieldCode = '245' AND INSTR(" & strResult & ",',' + CAST(Lib_tblItem.ID as nvarchar) +',') > 0"
                        End Select
                    Case "AUTHOR" ' sap xep theo tac gia 100$a --> Cat_tblDicAuthor
                        Select Case strDBServer
                            Case "SQLSERVER"
                                strResult = "SELECT DISTINCT Lib_tblItem.ID, ISNULL(Cat_tblDicAuthor.DisplayEntry,'') AS Content FROM Lib_tblItem LEFT JOIN Lib_tblItem_Author ON Lib_tblItem.ID = Lib_tblItem_Author.ItemID AND Lib_tblItem_Author.FieldCode = '100$a' LEFT JOIN Cat_tblDicAuthor ON Lib_tblItem_Author.AuthorID = Cat_tblDicAuthor.ID WHERE Lib_tblItem.ID IN (" & strResult & ")"
                            Case Else
                                strResult = "SELECT DISTINCT Lib_tblItem.ID, ISNULL(Cat_tblDicAuthor.DisplayEntry,'') AS Content FROM Lib_tblItem LEFT JOIN Lib_tblItem_Author ON Lib_tblItem.ID = Lib_tblItem_Author.ItemID AND Lib_tblItem_Author.FieldCode = '100$a' LEFT JOIN Cat_tblDicAuthor ON Lib_tblItem_Author.AuthorID = Cat_tblDicAuthor.ID WHERE INSTR(" & strResult & ",',' + CAST(Lib_tblItem.ID as nvarchar) +',') > 0"
                        End Select
                    Case "YEAR" ' sap xep theo nam xuat ban 260$c --> Cat_tblDicYear
                        Select Case strDBServer
                            Case "SQLSERVER"
                                strResult = "SELECT DISTINCT Lib_tblItem.ID, ISNULL(Cat_tblDicYear.Year,'') AS Content FROM Lib_tblItem LEFT JOIN Cat_tblDicYear ON Lib_tblItem.ID = Cat_tblDicYear.ItemID AND Cat_tblDicYear.FieldCode = '260$c' WHERE Lib_tblItem.ID IN (" & strResult & ")"
                            Case Else
                                strResult = "SELECT DISTINCT Lib_tblItem.ID, ISNULL(Cat_tblDicYear.Year,'') AS Content FROM Lib_tblItem LEFT JOIN Cat_tblDicYear ON Lib_tblItem.ID = Cat_tblDicYear.ItemID AND Cat_tblDicYear.FieldCode = '260$c' WHERE INSTR(" & strResult & ",',' + CAST(Lib_tblItem.ID as nvarchar) +',') > 0"
                        End Select
                    Case "PUBLISH" ' sap xep theo nha xuat ban --> Cat_tblDicPublisher
                        Select Case strDBServer
                            Case "SQLSERVER"
                                strResult = "SELECT DISTINCT Lib_tblItem.ID, ISNULL(Cat_tblDicPublisher.DisplayEntry,'') AS Content FROM Lib_tblItem LEFT JOIN Lib_tblItemPublisher ON Lib_tblItem.ID = Lib_tblItemPublisher.ItemID AND Lib_tblItemPublisher.FieldCode = '260$b' LEFT JOIN Cat_tblDicPublisher ON Lib_tblItemPublisher.PublisherID = Cat_tblDicPublisher.ID WHERE Lib_tblItem.ID IN (" & strResult & ")"
                            Case Else
                                strResult = "SELECT DISTINCT Lib_tblItem.ID, ISNULL(Cat_tblDicPublisher.DisplayEntry,'') AS Content FROM Lib_tblItem LEFT JOIN Lib_tblItemPublisher ON Lib_tblItem.ID = Lib_tblItemPublisher.ItemID AND Lib_tblItemPublisher.FieldCode = '260$b' LEFT JOIN Cat_tblDicPublisher ON Lib_tblItemPublisher.PublisherID = Cat_tblDicPublisher.ID WHERE INSTR(" & strResult & ",',' + CAST(Lib_tblItem.ID as nvarchar) +',') > 0"
                        End Select
                End Select
                'strResult = Replace(strResult, "'", "''")
            Catch ex As Exception
            End Try
            Return strResult
        End Function

        'Public Function getFormingSQL() As String
        '    Dim strResult As String = ""
        '    Try
        '        Dim strFinalSQL As String
        '        Dim strUnionSQL As String
        '        Dim strMySQL As String
        '        Dim intCount As Integer
        '        Dim blnUseFulltextIndex As Boolean
        '        Dim blnSearchExact As Boolean
        '        Dim strTitle As String
        '        Dim strStartYr As String
        '        Dim strEndYr As String
        '        Dim strSQLRet As String
        '        Dim strSQLNext As String

        '        Dim TblCatDicList As New DataTable
        '        Dim strval1 As String
        '        strFinalSQL = ""
        '        strUnionSQL = ""
        '        If UCase(strSearchMode) <> "ADVANCE" Then
        '            Me.Generate3Array()
        '        End If
        '        If Not arrName Is Nothing AndAlso UBound(arrName) >= 0 Then
        '            For intCount = LBound(arrName) To UBound(arrName)
        '                If Not Trim(arrValue(intCount)) = "" Then
        '                    strMySQL = ""

        '                    If Left(arrValue(intCount), 2) = "$*" AndAlso Right(arrValue(intCount), 2) = "*$" Then
        '                        blnSearchExact = True
        '                        arrValue(intCount) = Right(arrValue(intCount), Len(arrValue(intCount)) - 2)
        '                        arrValue(intCount) = Left(arrValue(intCount), Len(arrValue(intCount)) - 2)
        '                    End If

        '                    Select Case LCase(arrName(intCount))
        '                        Case "fulltext" ' moi truong
        '                            'arrValue(intCount) = Replace(objBCSP.ProcessVal(arrValue(intCount)), "'", "''")
        '                            arrValue(intCount) = Replace(arrValue(intCount), "'", "''")
        '                            If InStr(arrValue(intCount), """") = 0 Then
        '                                arrValue(intCount) = """" & arrValue(intCount) & """"
        '                            End If
        '                            Select Case UCase(strDBServer)
        '                                Case "SQLSERVER"
        '                                    strMySQL = "SELECT Lib_tblItemFulltext.ItemID AS ID FROM Lib_tblItemFulltext WHERE CONTAINS(Lib_tblItemFulltext.Contents, '" & arrValue(intCount) & "')"
        '                                Case "ORACLE"
        '                                    strMySQL = "SELECT Lib_tblItemFulltext.ItemID AS ID FROM Lib_tblItemFulltext WHERE CONTAINS(Lib_tblItemFulltext.Contents, '" & arrValue(intCount) & "') > 0"
        '                            End Select
        '                        Case "title" ' nhan de
        '                            If (Left(arrValue(intCount), 1) = "%" Or Right(arrValue(intCount), 1) = "%") AndAlso InStr(arrValue(intCount), "'") = 0 Then
        '                                blnUseFulltextIndex = False
        '                            Else
        '                                If blnSearchExact = True Then
        '                                    blnUseFulltextIndex = False
        '                                Else
        '                                    blnUseFulltextIndex = True
        '                                End If
        '                            End If
        '                            If UCase(strSearchMode) = "ADVANCE" Then
        '                                strTitle = Replace(objBCSP.ProcessVal(arrValue(intCount)), "'", "''")
        '                            Else
        '                                strTitle = objBCSP.ProcessVal(arrValue(intCount))
        '                            End If
        '                            If blnUseFulltextIndex Then
        '                                If InStr(strTitle, """") = 0 Then
        '                                    strTitle = """" & strTitle & """"
        '                                End If
        '                                Select Case UCase(strDBServer)
        '                                    Case "SQLSERVER"
        '                                        strMySQL = "SELECT Lib_tblItemTitle.ItemID AS ID FROM Lib_tblItemTitle WHERE CONTAINS(Lib_tblItemTitle.Title, '" & strTitle & "')"
        '                                    Case "ORACLE"
        '                                        strMySQL = "SELECT Lib_tblItemTitle.ItemID AS ID FROM Lib_tblItemTitle WHERE CONTAINS(Lib_tblItemTitle.Title, '" & strTitle & "') > 0"
        '                                End Select
        '                            Else
        '                                Select Case UCase(strDBServer)
        '                                    Case "SQLSERVER"
        '                                        strMySQL = "SELECT Lib_tblItemTitle.ItemID as ID FROM Lib_tblItemTitle WHERE Lib_tblItemTitle.Title LIKE N'" & strTitle & "'"
        '                                    Case "ORACLE"
        '                                        strMySQL = "SELECT Lib_tblItemTitle.ItemID as ID FROM Lib_tblItemTitle WHERE Lib_tblItemTitle.title LIKE '" & strTitle & "'"
        '                                End Select
        '                            End If
        '                            If LCase(arrName(intCount)) = "maintitle" Then
        '                                strMySQL = strMySQL & " AND Lib_tblItemTitle.FieldCode = '245$a'"
        '                            End If
        '                        Case "series" ' Tung thu
        '                            strMySQL = " SELECT Lib_tblItemSeries.ItemID as ID FROM Cat_tblDicSeries,Lib_tblItemSeries WHERE Cat_tblDicSeries.ID=Lib_tblItemSeries.seriesID AND "
        '                            Select Case UCase(strDBServer)
        '                                Case "SQLSERVER"
        '                                    strMySQL = strMySQL & " (Cat_tblDicSeries.AccessEntry LIKE N'" & objBCSP.ProcessVal(arrValue(intCount)) & "' OR Cat_tblDicSeries.VietnameseAccent LIKE '" & objBCSP.CutVietnameseAccent(objBCSP.ProcessVal(arrValue(intCount))) & "' )"
        '                                Case "ORACLE"
        '                                    strMySQL = strMySQL & " (Cat_tblDicSeries.AccessEntry LIKE '" & objBCSP.ProcessVal(arrValue(intCount)) & "' OR Cat_tblDicSeries.VietnameseAccent LIKE '" & objBCSP.CutVietnameseAccent(objBCSP.ProcessVal(arrValue(intCount))) & "' )"
        '                            End Select
        '                        Case "publisher" ' NXB
        '                            strMySQL = " SELECT Lib_tblItemPublisher.ItemID AS ID FROM Lib_tblItemPublisher,Cat_tblDicPublisher WHERE Cat_tblDicPublisher.ID=Lib_tblItemPublisher.PublisherID AND "
        '                            Select Case UCase(strDBServer)
        '                                Case "SQLSERVER"
        '                                    strMySQL = strMySQL & " (Cat_tblDicPublisher.AccessEntry LIKE N'" & objBCSP.ProcessVal(arrValue(intCount)) & "' OR Cat_tblDicPublisher.VietnameseAccent LIKE '" & objBCSP.CutVietnameseAccent(objBCSP.ProcessVal(arrValue(intCount))) & "' )"
        '                                Case "ORACLE"
        '                                    strMySQL = strMySQL & " (Cat_tblDicPublisher.AccessEntry LIKE '" & objBCSP.ProcessVal(arrValue(intCount)) & "' OR Cat_tblDicPublisher.VietnameseAccent LIKE '" & objBCSP.CutVietnameseAccent(objBCSP.ProcessVal(arrValue(intCount))) & "' )"
        '                            End Select
        '                        Case "author" ' tac gia
        '                            Select Case UCase(strDBServer)
        '                                Case "SQLSERVER"
        '                                    strMySQL = " SELECT Lib_tblItem_Author.ItemID  AS ID FROM Lib_tblItem_Author,Cat_tblDicAuthor WHERE Cat_tblDicAuthor.ID=Lib_tblItem_Author.AuthorID AND "
        '                                    strMySQL = strMySQL & " (Cat_tblDicAuthor.AccessEntry LIKE N'" & objBCSP.ProcessVal(arrValue(intCount)) & "' OR Cat_tblDicAuthor.VietnameseAccent LIKE '" & objBCSP.CutVietnameseAccent(objBCSP.ProcessVal(arrValue(intCount))) & "' )"
        '                                Case "ORACLE"
        '                                    strMySQL = " SELECT Lib_tblItem_Author.ItemID AS ID FROM Lib_tblItem_Author,Cat_tblDicAuthor WHERE Cat_tblDicAuthor.ID=Lib_tblItem_Author.AuthorID AND "
        '                                    strMySQL = strMySQL & " (Cat_tblDicAuthor.AccessEntry LIKE '" & objBCSP.ProcessVal(arrValue(intCount)) & "' OR Cat_tblDicAuthor.VietnameseAccent LIKE '" & objBCSP.CutVietnameseAccent(objBCSP.ProcessVal(arrValue(intCount))) & "' )"
        '                            End Select
        '                        Case "tabofcontents" ' muc luc (Bao, tap chi)
        '                            arrValue(intCount) = objBCSP.ProcessVal(arrValue(intCount))
        '                            If InStr(arrValue(intCount), """") = 0 Then
        '                                arrValue(intCount) = """" & arrValue(intCount) & """"
        '                            End If
        '                            strMySQL = " SELECT SER_ISSUE.ItemID  AS ID FROM SER_ARTICLE,SER_ISSUE WHERE SER_ARTICLE.IssueID=SER_ISSUE.ID AND "
        '                            Select Case UCase(strDBServer)
        '                                Case "SQLSERVER"
        '                                    strMySQL = strMySQL & " CONTAINS(SER_ARTICLE.Contents,'" & arrValue(intCount) & "')"
        '                                Case "ORACLE"
        '                                    strMySQL = strMySQL & " CONTAINS(SER_ARTICLE.Contents,'" & arrValue(intCount) & "')>0 "
        '                            End Select
        '                        Case "publishyear" ' nam XB
        '                            'If InStr(arrValue(intCount), "-") = 0 Then
        '                            '    strMySQL = strMySQL & " AND Cat_tblDicYear.Year LIKE '" & arrValue(intCount) & "'"
        '                            'Else
        '                            '    strStartYr = Trim(Left(arrValue(intCount), InStr(arrValue(intCount), "-") - 1))
        '                            '    strEndYr = Trim(Right(arrValue(intCount), Len(arrValue(intCount)) - InStr(arrValue(intCount), "-")))
        '                            '    If Not strStartYr = "" Then
        '                            '        strMySQL = strMySQL & " AND Cat_tblDicYear.Year >= '" & strStartYr & "'"
        '                            '    End If
        '                            '    If Not strEndYr = "" Then
        '                            '        If Len(strStartYr) > Len(strEndYr) Then
        '                            '            strEndYr = Left(strStartYr, Len(strStartYr) - Len(strEndYr)) & strEndYr
        '                            '        End If
        '                            '        strMySQL = strMySQL & " AND Cat_tblDicYear.Year <= '" & strEndYr & "'"
        '                            '    End If
        '                            'End If
        '                            ' strMySQL = " SELECT Cat_tblDicYear.ItemID AS ID FROM Cat_tblDicYear WHERE " & Right(strMySQL, Len(strMySQL) - 5)
        '                            If InStr(arrValue(intCount), "-") = 0 Then
        '                                strMySQL = strMySQL & " AND Cat_tblDicYear.Year <= '" & arrValue(intCount) & "'"
        '                            Else
        '                                strStartYr = Trim(Left(arrValue(intCount), InStr(arrValue(intCount), "-") - 1))
        '                                strEndYr = Trim(Right(arrValue(intCount), Len(arrValue(intCount)) - InStr(arrValue(intCount), "-")))
        '                                If Not strStartYr = "" Then
        '                                    strMySQL = strMySQL & " AND Cat_tblDicYear.Year >= '" & strStartYr & "'"
        '                                End If
        '                                If Not strEndYr = "" Then
        '                                    If Len(strStartYr) > Len(strEndYr) Then
        '                                        strEndYr = Left(strStartYr, Len(strStartYr) - Len(strEndYr)) & strEndYr
        '                                    End If
        '                                    strMySQL = strMySQL & " AND Cat_tblDicYear.Year <= '" & strEndYr & "'"
        '                                End If
        '                            End If
        '                            strMySQL = " SELECT Cat_tblDicYear.ItemID AS ID FROM Cat_tblDicYear WHERE (1=1) " & strMySQL
        '                        Case "callnumber" ' Call Number
        '                            strMySQL = " SELECT ITEM.ID FROM ITEM WHERE ITEM.CallNumber LIKE '" & arrValue(intCount) & "'"
        '                        Case "catafrom" ' Cata From
        '                            strMySQL = " SELECT ITEM.ID FROM ITEM WHERE ITEM.CreatedDate >= '" & arrValue(intCount) & "'"
        '                        Case "catato" ' Cata To
        '                            strMySQL = " SELECT ITEM.ID FROM ITEM WHERE ITEM.CreatedDate <=  '" & arrValue(intCount) & "'"
        '                        Case "itemcode" ' Ma tai lieu
        '                            strMySQL = " SELECT ITEM.ID FROM ITEM WHERE ITEM.Code LIKE '" & arrValue(intCount) & "'"
        '                        Case "issueno" ' so tap chi
        '                            strMySQL = " SELECT SER_ISSUE.ItemID as ID FROM SER_ISSUE WHERE SER_ISSUE.IssueNo LIKE '" & arrValue(intCount) & "'"
        '                        Case "volume" ' tap
        '                            Select Case UCase(strDBServer)
        '                                Case "SQLSERVER"
        '                                    strMySQL = " SELECT SER_ISSUE.ItemID AS ID FROM SER_ISSUE WHERE SER_ISSUE.VolumeByPublisher LIKE N'" & arrValue(intCount) & "'"
        '                                Case "ORACLE"
        '                                    strMySQL = " SELECT SER_ISSUE.ItemID AS ID FROM SER_ISSUE WHERE SER_ISSUE.VolumeByPublisher LIKE '" & arrValue(intCount) & "'"
        '                            End Select
        '                        Case "fromid" ' from ID
        '                            strMySQL = " SELECT ITEM.ID FROM ITEM WHERE ITEM.ID >= " & arrValue(intCount)
        '                        Case "toid" ' to ID
        '                            strMySQL = " SELECT ITEM.ID FROM ITEM WHERE ITEM.ID <= " & arrValue(intCount)
        '                        Case "reviewer" ' nguoi kiem tra
        '                            Select Case UCase(strDBServer)
        '                                Case "SQLSERVER"
        '                                    strMySQL = " SELECT ITEM.ID FROM ITEM WHERE ITEM.Reviewer LIKE N'" & arrValue(intCount) & "'"
        '                                Case "ORACLE"
        '                                    strMySQL = " SELECT ITEM.ID FROM ITEM WHERE ITEM.Reviewer LIKE '" & arrValue(intCount) & "'"
        '                            End Select
        '                        Case "fromissueddate" 'from ngay phat hanh
        '                            strMySQL = " SELECT SER_ISSUE.ItemID  as ID FROM SER_ISSUE WHERE SER_ISSUE.IssuedDate >= "
        '                            Select Case UCase(strDBServer)
        '                                Case "SQLSERVER"
        '                                    strMySQL = strMySQL & "CONVERT(datetime, '" & arrValue(intCount) & "', 103)"
        '                                Case "ORACLE"
        '                                    strMySQL = strMySQL & "To_Date('" & arrValue(intCount) & "', 'dd/mm/yyyy')"
        '                            End Select
        '                        Case "toissueddate" ' to ngay phat hanh
        '                            strMySQL = " SELECT SER_ISSUE.ItemID as ID FROM SER_ISSUE WHERE  SER_ISSUE.IssuedDate <= "
        '                            Select Case UCase(strDBServer)
        '                                Case "SQLSERVER"
        '                                    strMySQL = strMySQL & "CONVERT(datetime, '" & arrValue(intCount) & "', 103)"
        '                                Case "ORACLE"
        '                                    strMySQL = strMySQL & "To_Date('" & arrValue(intCount) & "', 'dd/mm/yyyy')"
        '                            End Select
        '                        Case "copynumber" ' ma xep gia
        '                            strMySQL = " SELECT HOLDING.ItemID as ID FROM HOLDING WHERE HOLDING.CopyNumber LIKE '" & arrValue(intCount) & "'"
        '                        Case "isbn" ' ISBN
        '                            strMySQL = " SELECT CAT_DIC_NUMBER.ItemID FROM CAT_DIC_NUMBER WHERE CAT_DIC_NUMBER.Number LIKE '" & arrValue(intCount) & "' AND CAT_DIC_NUMBER.FieldCode = '020$a'"
        '                        Case "issn" ' ISSN
        '                            strMySQL = " SELECT CAT_DIC_NUMBER.ItemID FROM CAT_DIC_NUMBER WHERE CAT_DIC_NUMBER.Number LIKE '" & arrValue(intCount) & "' AND CAT_DIC_NUMBER.FieldCode = '022$a'"
        '                        Case "itemtype" ' dang tai lieu
        '                            'If Not IsNumeric(arrValue(intCount)) Then
        '                            '    Select Case UCase(strDBServer)
        '                            '        Case "SQLSERVER"
        '                            '            strMySQL = " SELECT ITEM.ID FROM ITEM, Cat_tblDic_ItemType WHERE ITEM.TypeID = Cat_tblDic_ItemType.ID AND Cat_tblDic_ItemType.TypeCode IN (N'" & Replace(arrValue(intCount), "''", "'") & "')"
        '                            '        Case "ORACLE"
        '                            '            strMySQL = " SELECT ITEM.ID FROM ITEM, Cat_tblDic_ItemType WHERE ITEM.TypeID = Cat_tblDic_ItemType.ID AND Cat_tblDic_ItemType.TypeCode IN ('" & Replace(arrValue(intCount), "''", "'") & "')"
        '                            '    End Select
        '                            'Else
        '                            '    If arrValue(intCount) > 0 Then
        '                            '        strMySQL = "SELECT ITEM.ID FROM ITEM WHERE ITEM.TypeID = " & arrValue(intCount)
        '                            '    End If
        '                            'End If
        '                            strMySQL = "SELECT ITEM.ID FROM ITEM WHERE ITEM.TypeID IN (" & arrValue(intCount) & ")"
        '                        Case "librarytype" ' thu vien
        '                            strMySQL = "SELECT ITEM.ID FROM ITEM WHERE ITEM.LibId IN (" & arrValue(intCount) & ")"
        '                        Case "formattype" ' thu vien
        '                            strMySQL = "SELECT ITEM.ID FROM ITEM WHERE ITEM.FormatID IN (" & arrValue(intCount) & ")"
        '                        Case "cataloguer" ' nguoi biem muc
        '                            Select Case UCase(strDBServer)
        '                                Case "SQLSERVER"
        '                                    strMySQL = " SELECT ITEM.ID FROM ITEM WHERE ITEM.Cataloguer LIKE N'" & arrValue(intCount) & "'"
        '                                Case "ORACLE"
        '                                    strMySQL = " SELECT ITEM.ID FROM ITEM WHERE ITEM.Cataloguer LIKE '" & arrValue(intCount) & "'"
        '                            End Select
        '                        Case "bbk/ddc" ' chi so phan loai
        '                            strMySQL = " SELECT Lib_tblItemDDC.ItemID as ID FROM Lib_tblItemDDC,Cat_tblDic_ClassDDC WHERE  Cat_tblDic_ClassDDC.ID=Lib_tblItemDDC.DDCID AND Lib_tblItemDDC.FieldCode='082$a' AND "
        '                            Select Case UCase(strDBServer)
        '                                Case "SQLSERVER"
        '                                    strMySQL = strMySQL & " (Cat_tblDic_ClassDDC.AccessEntry LIKE N'" & objBCSP.ProcessVal(arrValue(intCount)) & "' OR Cat_tblDic_ClassDDC.VietnameseAccent LIKE '" & objBCSP.CutVietnameseAccent(objBCSP.ProcessVal(arrValue(intCount))) & "' )"
        '                                Case "ORACLE"
        '                                    strMySQL = strMySQL & " (Cat_tblDic_ClassDDC.AccessEntry LIKE '" & objBCSP.ProcessVal(arrValue(intCount)) & "' OR Cat_tblDic_ClassDDC.VietnameseAccent LIKE '" & objBCSP.CutVietnameseAccent(objBCSP.ProcessVal(arrValue(intCount))) & "' )"
        '                            End Select
        '                        Case "bbk" ' chi so phan loai
        '                            strMySQL = " SELECT ITEM_BBK.ItemID as ID FROM ITEM_BBK,CAT_DIC_CLASS_BBK WHERE CAT_DIC_CLASS_BBK.ID=ITEM_BBK.BBKID AND CAT_DIC_CLASS_BBK.FieldCode='094$a' AND CAT_DIC_CLASS_BBK.AccessEntry"
        '                            Select Case UCase(strDBServer)
        '                                Case "SQLSERVER"
        '                                    strMySQL = strMySQL & " LIKE N'" & objBCSP.ProcessVal1(arrValue(intCount)) & "'"
        '                                Case "ORACLE"
        '                                    strMySQL = strMySQL & " LIKE '" & objBCSP.ProcessVal1(arrValue(intCount)) & "'"
        '                            End Select
        '                        Case "ddc" ' chi so phan loai
        '                            strMySQL = " SELECT Lib_tblItemDDC.ItemID as ID FROM Lib_tblItemDDC,Cat_tblDic_ClassDDC WHERE  Cat_tblDic_ClassDDC.ID=Lib_tblItemDDC.DDCID AND Cat_tblDic_ClassDDC.FieldCode='082$a' AND Cat_tblDic_ClassDDC.AccessEntry"
        '                            Select Case UCase(strDBServer)
        '                                Case "SQLSERVER"
        '                                    strMySQL = strMySQL & " LIKE N'" & objBCSP.ProcessVal1(arrValue(intCount)) & "'"
        '                                Case "ORACLE"
        '                                    strMySQL = strMySQL & " LIKE '" & objBCSP.ProcessVal1(arrValue(intCount)) & "'"
        '                            End Select
        '                        Case "keyword" ' tu khoa
        '                            Select Case UCase(strDBServer)
        '                                Case "SQLSERVER"
        '                                    strMySQL = " SELECT Lib_tblItemKeyword.ItemID as ID FROM Lib_tblItemKeyword,Cat_tblDicKeyword WHERE Cat_tblDicKeyword.ID=Lib_tblItemKeyword.KeyWordID AND Lib_tblItemKeyword.FieldCode='653$a' AND "
        '                                    strMySQL = strMySQL & " (Cat_tblDicKeyword.AccessEntry LIKE N'" & objBCSP.ProcessVal(arrValue(intCount)) & "' OR Cat_tblDicKeyword.VietnameseAccent LIKE '" & objBCSP.CutVietnameseAccent(objBCSP.ProcessVal(arrValue(intCount))) & "' )"
        '                                Case "ORACLE"
        '                                    strMySQL = " SELECT Lib_tblItemKeyword.ItemID as ID FROM Lib_tblItemKeyword,Cat_tblDicKeyword WHERE Cat_tblDicKeyword.ID=Lib_tblItemKeyword.KeyWordID AND Lib_tblItemKeyword.FieldCode='653$a' AND "
        '                                    strMySQL = strMySQL & " (Cat_tblDicKeyword.AccessEntry LIKE '" & objBCSP.ProcessVal(arrValue(intCount)) & "' OR Cat_tblDicKeyword.VietnameseAccent LIKE '" & objBCSP.CutVietnameseAccent(objBCSP.ProcessVal(arrValue(intCount))) & "' )"
        '                            End Select
        '                        Case "udc" ' chi so phan loai udc
        '                            strMySQL = " SELECT ITEM_UDC.ItemID as ID FROM ITEM_UDC,CAT_DIC_CLASS_UDC WHERE CAT_DIC_CLASS_UDC.ID=ITEM_UDC.UDCID AND ITEM_UDC.FieldCode='080$a' AND "
        '                            Select Case UCase(strDBServer)
        '                                Case "SQLSERVER"
        '                                    strMySQL = strMySQL & " (CAT_DIC_CLASS_UDC.AccessEntry LIKE N'" & objBCSP.ProcessVal(arrValue(intCount)) & "' OR CAT_DIC_CLASS_UDC.VietnameseAccent LIKE '" & objBCSP.CutVietnameseAccent(objBCSP.ProcessVal(arrValue(intCount))) & "' )"
        '                                Case "ORACLE"
        '                                    strMySQL = strMySQL & " (CAT_DIC_CLASS_UDC.AccessEntry LIKE '" & objBCSP.ProcessVal(arrValue(intCount)) & "' OR CAT_DIC_CLASS_UDC.VietnameseAccent LIKE '" & objBCSP.CutVietnameseAccent(objBCSP.ProcessVal(arrValue(intCount))) & "' )"
        '                            End Select
        '                        Case "nsc" ' chi so phan loai nsc
        '                            strMySQL = " SELECT ITEM_NSC.ItemID as ID FROM ITEM_UDC,CAT_DIC_CLASS_NSC WHERE CAT_DIC_CLASS_NSC.ID=ITEM_NSC.NSCID AND ITEM_NSC.FieldCode='084$a' AND "
        '                            Select Case UCase(strDBServer)
        '                                Case "SQLSERVER"
        '                                    strMySQL = strMySQL & " LIKE N'" & objBCSP.ProcessVal(arrValue(intCount)) & "'"
        '                                Case "ORACLE"
        '                                    strMySQL = strMySQL & " LIKE '" & objBCSP.ProcessVal(arrValue(intCount)) & "'"
        '                            End Select
        '                        Case "subjectheading" ' tieu de de muc
        '                            strMySQL = " SELECT Lib_tblItemSH.ItemID as ID FROM Lib_tblItemSH,Cat_tblDicSH WHERE Cat_tblDicSH.DicItemID=Lib_tblItemSH.SHID AND DicItemID.FieldCode='650$a' AND "
        '                            Select Case UCase(strDBServer)
        '                                Case "SQLSERVER"
        '                                    strMySQL = strMySQL & " (Cat_tblDicSH.AccessEntry LIKE N'" & objBCSP.ProcessVal(arrValue(intCount)) & "' OR Cat_tblDicSH.VietnameseAccent LIKE '" & objBCSP.CutVietnameseAccent(objBCSP.ProcessVal(arrValue(intCount))) & "' )"
        '                                Case "ORACLE"
        '                                    strMySQL = strMySQL & " (Cat_tblDicSH.AccessEntry LIKE '" & objBCSP.ProcessVal(arrValue(intCount)) & "' OR Cat_tblDicSH.VietnameseAccent LIKE '" & objBCSP.CutVietnameseAccent(objBCSP.ProcessVal(arrValue(intCount))) & "' )"
        '                            End Select
        '                        Case "thesissubject" ' Chuyen nganh luan an
        '                            strMySQL = " SELECT ITEM_THESIS_SUBJECT.ItemID as ID FROM CAT_DIC_THESIS_SUBJECT,ITEM_THESIS_SUBJECT WHERE CAT_DIC_THESIS_SUBJECT.ID=ITEM_THESIS_SUBJECT.SubjectID AND ITEM_THESIS_SUBJECT.FieldCode='915$b' AND "
        '                            Select Case UCase(strDBServer)
        '                                Case "SQLSERVER"
        '                                    strMySQL = strMySQL & " (CAT_DIC_THESIS_SUBJECT.AccessEntry LIKE N'" & objBCSP.ProcessVal(arrValue(intCount)) & "' OR CAT_DIC_THESIS_SUBJECT.VietnameseAccent LIKE '" & objBCSP.CutVietnameseAccent(objBCSP.ProcessVal(arrValue(intCount))) & "' )"
        '                                Case "ORACLE"
        '                                    strMySQL = strMySQL & " (CAT_DIC_THESIS_SUBJECT.AccessEntry LIKE '" & objBCSP.ProcessVal(arrValue(intCount)) & "' OR CAT_DIC_THESIS_SUBJECT.VietnameseAccent LIKE '" & objBCSP.CutVietnameseAccent(objBCSP.ProcessVal(arrValue(intCount))) & "' )"
        '                            End Select
        '                        Case "language" ' ngon ngu 041$a
        '                            strMySQL = " SELECT Lib_tblItemLanguage.ItemID as ID FROM Cat_tblDic_Language,Lib_tblItemLanguage WHERE Cat_tblDic_Language.ID=Lib_tblItemLanguage.LanguageID AND Lib_tblItemLanguage.FieldCode='041$a' AND "
        '                            Select Case UCase(strDBServer)
        '                                Case "SQLSERVER"
        '                                    strMySQL = strMySQL & " (Cat_tblDic_Language.AccessEntry LIKE N'" & objBCSP.ProcessVal(arrValue(intCount)) & "' OR Cat_tblDic_Language.VietnameseAccent LIKE '" & objBCSP.CutVietnameseAccent(objBCSP.ProcessVal(arrValue(intCount))) & "' )"
        '                                Case "ORACLE"
        '                                    strMySQL = strMySQL & " (Cat_tblDic_Language.AccessEntry LIKE '" & objBCSP.ProcessVal(arrValue(intCount)) & "' OR Cat_tblDic_Language.VietnameseAccent LIKE '" & objBCSP.CutVietnameseAccent(objBCSP.ProcessVal(arrValue(intCount))) & "' )"
        '                            End Select
        '                        Case Else ' cac truong hop con lai -- dung tu dien tham chieu
        '                            If IsNumeric(arrName(intCount)) Then
        '                                TblCatDicList = objBDic.GetCatDicList(arrName(intCount))
        '                                strval1 = objBCSP.ProcessVal(arrValue(intCount))
        '                                If TblCatDicList.Rows.Count > 0 Then
        '                                    'Alter by chuyenpt(22/08/07): tim kiem khong dau
        '                                    strMySQL = " SELECT ItemID AS ID FROM " & Trim(TblCatDicList.Rows(0).Item("DicTable") & "") & ", " & Trim(TblCatDicList.Rows(0).Item("IndexTable") & "") & " WHERE " & Trim(TblCatDicList.Rows(0).Item("DicTable") & "") & "." & Trim(TblCatDicList.Rows(0).Item("DicIDField") & "") & " = " & Trim(TblCatDicList.Rows(0).Item("IndexTable") & "") & "." & Trim(TblCatDicList.Rows(0).Item("IndexIDField") & "")
        '                                    strSQLNext = CStr(TblCatDicList.Rows(0).Item("SearchFields")).Trim
        '                                    strSQLNext = Trim(TblCatDicList.Rows(0).Item("DicTable")) & "." & strSQLNext.Replace(",", "," & Trim(TblCatDicList.Rows(0).Item("DicTable")) & ".")
        '                                    strSQLNext = " AND (" & strSQLNext
        '                                    If Right(strSQLNext, 1) <> "," Then
        '                                        strSQLNext = strSQLNext & ","
        '                                    End If
        '                                    Select Case UCase(strDBServer)
        '                                        Case "SQLSERVER"
        '                                            strMySQL = strMySQL & strSQLNext.Replace(",", " LIKE N'" & strval1 & "' OR ")
        '                                            strMySQL = Left(strMySQL, Len(strMySQL) - 3) & ")"
        '                                        Case "ORACLE"
        '                                            strMySQL = strMySQL & strSQLNext.Replace(",", " LIKE '" & strval1 & "' OR ")
        '                                            strMySQL = Left(strMySQL, Len(strMySQL) - 3) & ")"
        '                                    End Select
        '                                    TblCatDicList.Clear()
        '                                End If
        '                            Else
        '                                strMySQL = ""
        '                            End If
        '                    End Select
        '                    If strMySQL <> "" Then
        '                        Select Case arrBool(intCount)
        '                            Case "AND"
        '                                strFinalSQL = strFinalSQL & " AND ITEM.ID IN (" & strMySQL & ")"
        '                            Case "OR"
        '                                strUnionSQL = strUnionSQL & " UNION " & strMySQL
        '                            Case "NOT"
        '                                strFinalSQL = strFinalSQL & " AND ITEM.ID NOT IN (" & strMySQL & ")"
        '                        End Select

        '                        'Select Case UCase(strDBServer)
        '                        '    Case "SQLSERVER"
        '                        '        Select Case arrBool(intCount)
        '                        '            Case "AND"
        '                        '                strFinalSQL = strFinalSQL & " AND ITEM.ID IN (" & strMySQL & ")"
        '                        '            Case "OR"
        '                        '                strUnionSQL = strUnionSQL & " UNION " & strMySQL
        '                        '            Case "NOT"
        '                        '                strFinalSQL = strFinalSQL & " AND ITEM.ID NOT IN (" & strMySQL & ")"
        '                        '        End Select
        '                        '    Case "ORACLE"
        '                        '        Select Case arrBool(intCount)
        '                        '            Case "AND"
        '                        '                strFinalSQL = strFinalSQL & " INTERSECT " & strMySQL
        '                        '            Case "OR"
        '                        '                strUnionSQL = strUnionSQL & " UNION " & strMySQL
        '                        '            Case "NOT"
        '                        '                strFinalSQL = strFinalSQL & " MINUS " & strMySQL
        '                        '        End Select
        '                        'End Select
        '                    End If
        '                End If
        '            Next
        '        End If

        '        ' add more field to sort
        '        Select Case UCase(strSortBy)
        '            Case "TITLE" ' sap xep theo nhan de 245 --> ITEM_TILE
        '                Select Case strDBServer
        '                    Case "SQLSERVER"
        '                        strSQLRet = "SELECT DISTINCT Item.ID,Lib_tblField200S.Content FROM ITEM,Lib_tblField200S WHERE ITEM.ID=Lib_tblField200S.ItemID AND Lib_tblField200S.FieldCode='245' AND OPAC = 1 "
        '                    Case Else
        '                        strSQLRet = "SELECT DISTINCT Item.ID,Lib_tblField200S.Content FROM ITEM,Lib_tblField200S WHERE ITEM.ID=Lib_tblField200S.ItemID AND Lib_tblField200S.FieldCode='245' AND OPAC = 1 "
        '                End Select
        '            Case "AUTHOR" ' sap xep theo tac gia 100$a --> Cat_tblDicAuthor
        '                Select Case strDBServer
        '                    Case "SQLSERVER"
        '                        strSQLRet = "SELECT DISTINCT Item.ID,Cat_tblDicAuthor.DisplayEntry AS Content FROM ITEM,Cat_tblDicAuthor,Lib_tblItem_Author WHERE ITEM.ID=Lib_tblItem_Author.ItemID AND Lib_tblItem_Author.AuthorID=Cat_tblDicAuthor.ID AND Lib_tblItem_Author.FieldCode='100$a' AND OPAC = 1"
        '                    Case Else
        '                        strSQLRet = "SELECT DISTINCT Item.ID,Cat_tblDicAuthor.DisplayEntry AS Content FROM ITEM,Cat_tblDicAuthor,Lib_tblItem_Author WHERE ITEM.ID=Lib_tblItem_Author.ItemID AND Lib_tblItem_Author.AuthorID=Cat_tblDicAuthor.ID AND Lib_tblItem_Author.FieldCode='100$a' AND OPAC = 1"
        '                End Select
        '            Case "YEAR" ' sap xep theo nam xuat ban 260$c --> Cat_tblDicYear
        '                Select Case strDBServer
        '                    Case "SQLSERVER"
        '                        strSQLRet = "SELECT DISTINCT Item.ID,Cat_tblDicYear.Year AS Content FROM ITEM,Cat_tblDicYear WHERE ITEM.ID=Cat_tblDicYear.ItemID AND Cat_tblDicYear.FieldCode='260$c' AND OPAC = 1"
        '                    Case Else
        '                        strSQLRet = "SELECT DISTINCT Item.ID,Cat_tblDicYear.Year AS Content FROM ITEM,Cat_tblDicYear WHERE ITEM.ID=Cat_tblDicYear.ItemID AND Cat_tblDicYear.FieldCode='260$c' AND OPAC = 1"
        '                End Select
        '            Case "PUBLISH" ' sap xep theo nha xuat ban --> Cat_tblDicPublisher
        '                Select Case strDBServer
        '                    Case "SQLSERVER"
        '                        strSQLRet = "SELECT DISTINCT Item.ID,Cat_tblDicPublisher.DisplayEntry AS Content FROM ITEM,Cat_tblDicPublisher,Lib_tblItemPublisher WHERE ITEM.ID=Lib_tblItemPublisher.ItemID AND Lib_tblItemPublisher.PublisherID=Cat_tblDicPublisher.ID AND Lib_tblItemPublisher.FieldCode='260$b' AND OPAC = 1"
        '                    Case Else
        '                        strSQLRet = "SELECT DISTINCT Item.ID,Cat_tblDicPublisher.DisplayEntry AS Content FROM ITEM,Cat_tblDicPublisher,Lib_tblItemPublisher WHERE ITEM.ID=Lib_tblItemPublisher.ItemID AND Lib_tblItemPublisher.PublisherID=Cat_tblDicPublisher.ID AND Lib_tblItemPublisher.FieldCode='260$b' AND OPAC = 1"
        '                End Select
        '            Case Else
        '                strSQLRet = "SELECT DISTINCT Item.ID,' ' AS Content FROM ITEM WHERE OPAC = 1 "
        '        End Select
        '        If blnSecuredOPAC Then
        '            strSQLRet = strSQLRet & " AND AccessLevel <= " & bytAccessLevel
        '        End If
        '        If strUnionSQL <> "" Then
        '            strUnionSQL = Right(strUnionSQL, strUnionSQL.Length - 6)
        '            strUnionSQL = "AND ITEM.ID IN (" & strUnionSQL & ")"
        '            strSQLRet = "(" & strSQLRet & " " & strFinalSQL & ") UNION (" & strSQLRet & " " & strUnionSQL & ")"
        '        Else
        '            strSQLRet = strSQLRet & " " & strFinalSQL
        '        End If

        '        ' if intTop <=0 select Ubound_search from sys_parameter table
        '        If intTop <= 0 Then
        '            Dim arrName(0) As String
        '            arrName(0) = "SEARCH_UBOUND"
        '            intTop = objBCDBS.GetSystemParameters(arrName)(0)
        '        End If

        '        Select Case UCase(strDBServer)
        '            Case "SQLSERVER"
        '                strResult = "SELECT TOP " & intTop & " eMicLib6x.* FROM(" & strSQLRet & ")eMicLib6x"
        '                If Me.ItemIDs <> "" Then
        '                    strResult &= " WHERE eMicLib6x.ID IN (" & Me.ItemIDs & ")"
        '                End If
        '            Case "ORACLE"
        '                strResult = "SELECT eMicLib6x.ID FROM(" & strSQLRet & ")eMicLib6x WHERE ROWNUM<=" & intTop
        '                If Me.ItemIDs <> "" Then
        '                    strResult &= " AND eMicLib6x.* IN (" & Me.ItemIDs & ")"
        '                End If
        '        End Select
        '        'strResult = Replace(strResult, "'", "''")
        '    Catch ex As Exception
        '    End Try
        '    Return strResult
        'End Function

        Public Function getFormingSQLForID(ByVal strSQL As String) As String
            Dim strResult As String = strSQL
            Try
                'If Not IsNothing(strSortBy) AndAlso strSortBy <> "" Then
                '    strResult = "SELECT DISTINCT EMIL.ID FROM (" & strSQL & ") EMIL"
                'End If
                strResult = "SELECT DISTINCT EMIL.ID FROM (" & strSQL & ") EMIL"
            Catch ex As Exception
            End Try
            Return strResult
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBDic Is Nothing Then
                    objBDic.Dispose(True)
                    objBDic = Nothing
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Dispose()
            End Try
        End Sub
    End Class
End Namespace
