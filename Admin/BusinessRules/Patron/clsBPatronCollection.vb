Imports System.IO
Imports System.Data
Imports System.Xml
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Patron
Imports System.Collections.Generic

Namespace eMicLibAdmin.BusinessRules.Patron

    Public Class clsBPatronCollection
        Inherits clsBBase
        Private objDPatronCollection As New clsDPatronCollection
        Private objBCChart As New clsBCommonChart
        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        Private objBCT As New clsBCommonTemplate
        Private objBP As New clsBPatron
        Private objBPro As New clsBProvince
        Private objBO As New clsBOccupation
        Private objBE As New clsBEthnic
        Private objBC As New clsBCollege
        Private objBPG As New clsBPatronGroup
        Private objBF As New clsBFaculty
        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private strTypeSearch As String
        Private objArrLabelChart As Object
        Private objArrDataChart As Object
        ' Declare varables for objSearch
        'Private TvSort As New TVCOMLib.utf8
        'Private TvFont As New TVCOMLib.fonts

        Private lngSelectTop As Long
        Private strOperator1 As String ' AND, OR ,NOT
        Private strOperator2 As String
        Private strOperator3 As String
        Private strOperator4 As String
        Private strOperator5 As String

        'Code,FN,Workplace,Email,Class,Grade,Address
        Private bytFieldName1 As Byte
        Private bytFieldName2 As Byte

        ' Faculty,College,Education,Ethnic,
        'Occupation,Province,PatronGroup,Sex
        Private bytFieldNameOther1 As Byte
        Private bytFieldNameOther2 As Byte

        'DOB,ValidDate,ExpireDate
        Private bytFieldNameDate1 As Byte
        Private bytFieldNameDate2 As Byte

        '= , >=
        Private bytFieldOpeFrom1 As Byte
        Private bytFieldOpeFrom2 As Byte

        'Code,FN,Workplace,Email,Class,Grade,Address
        Private strFieldValue1 As String
        Private strFieldValue2 As String

        ' FacultyID,CollegeID,EducationID,EthnicID,
        ' OccupationID,ProvinceID,PatronGroupID,Sex
        Private intFieldValueOther1 As Integer
        Private intFieldValueOther2 As Integer

        'DOB,ValidDate,ExpireDate
        Private strFieldValueFrom1 As String
        Private strFieldValueFrom2 As String

        'DOB,ValidDate,ExpireDate
        Private strFieldValueTo1 As String
        Private strFieldValueTo2 As String

        Private bytSex As Byte = 2
        Private strPatronGroupID As String

        Private lngFromID As Long = 0
        Private lngToID As Long = 0
        Private strFromCode As String
        Private strToCode As String
        Private strFromValidDate As String = ""
        Private strToValidDate As String = ""
        Private strCode As String
        Private strValidDate As String
        Private strExpiredDate As String
        Private strLastIssuedDate As String
        Private strFullName As String
        Private strDOB As String
        Private intEthnicID As Integer
        Private intEducationID As Integer
        Private intOccupationID As Integer
        Private strWorkPlace As String
        Private strMobile As String
        Private strEmail As String
        Private strLastModifiedDate As String
        Private strCollege As String = ""
        Private intFaculty As Integer
        Private strGrade As String = ""
        Private strClass As String = ""
        Private strAddress As String = ""
        Private bytOrderBy As Byte
        Private TblDataToGen As DataTable
        Private intTemplateID As Integer
        Private intRotate As Integer
        Private bytTypeBarcode As Byte = 0
        Private intTemplateType As Integer
        Private bytTypePic As Byte
        Private strSeperator As String
        Private objDataBarCode As Object
        Private objReturnData As Object
        ' Renew Card Patron(s) variable
        Private strNewExpiredDate As String
        Private bytPrintCard As Byte = 0
        Private intYears As Integer
        Private intMonths As Integer
        Private strPatronIDs As String
        Private bytTextFieldIndex As Byte = 0
        Private strNewTextValue As String
        Private bytDateFieldIndex As Byte
        Private strNewDateValue As String
        Private bytOptionFieldIndex As Byte
        Private intNewOptionID As Integer
        Private intFileTypeID As Integer
        Private intLibID As Integer

        '' patronGroupID int


        Protected arrField() ' store all field of template
        'Protected strTags As String = "CODE,CLASS,FULLNAME,DOB,OCUPATION,WORKPLACE,ADDRESS,TELEPHONE,CARDVALIDDATE,CARDEXPIREDDATE,EMAIL,PICTURE,BARCODE,ETHNIC,OCCUPATION,COLLEGE,FACULTY,EDUCATIONLEVEL,PATRONGROUPNAME,PROVINCE,GRADE,CLASS,ZIP,NOTE,SEX,MOBILE,LASTISSUEDDATE,LASTMODIFIEDDATE,COUNTRY,FIRSTNAME,LASTNAME,IDCARD,"
        Protected strTags As String = "CODE,VALIDDATE,EXPIREDDATE,LASTISSUEDDATE,FULLNAME,SEX,DOB,ETHNIC,TELEPHONE,MOBILE,EMAIL,BARCODE,GRADE,COLLEGE,OCCUPATION,FACULTY,CLASS,PROVINCE,ADDRESS,CITY,ZIP,ACTIVE,LASTMODIFIEDDATE,EDUCATIONLEVEL,PATRONGROUPNAME,NOTE,FIRSTNAME,LASTNAME,IDCARD,CARDVALIDDATE,CARDEXPIREDDATE,PICTURE,WORKPLACE,"
        Private tblExistPatron As New DataTable

        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties 
        ' *************************************************************************************************
        ' FileTypeID Property
        Public Property FileTypeID() As Integer
            Get
                FileTypeID = intFileTypeID
            End Get
            Set(ByVal Value As Integer)
                intFileTypeID = Value
            End Set
        End Property
        ' NewOptionID Property
        Public Property NewOptionID() As Integer
            Get
                Return intNewOptionID
            End Get
            Set(ByVal Value As Integer)
                intNewOptionID = Value
            End Set
        End Property
        ' Option value (DIC, PatronGroup, Sex)
        ' OptionFieldIndex Property
        Public Property OptionFieldIndex() As Byte
            Get
                Return bytOptionFieldIndex
            End Get
            Set(ByVal Value As Byte)
                bytOptionFieldIndex = Value
            End Set
        End Property
        ' NewDateValue Property
        Public Property NewDateValue() As String
            Get
                Return strNewDateValue
            End Get
            Set(ByVal Value As String)
                strNewDateValue = Value
            End Set
        End Property
        ' DateFieldIndex Property
        Public Property DateFieldIndex() As Byte
            Get
                Return bytDateFieldIndex
            End Get
            Set(ByVal Value As Byte)
                bytDateFieldIndex = Value
            End Set
        End Property
        ' NewTextValue Property
        Public Property NewTextValue() As String
            Get
                Return strNewTextValue
            End Get
            Set(ByVal Value As String)
                strNewTextValue = Value
            End Set
        End Property
        ' TextFieldIndex Property
        Public Property TextFieldIndex() As Byte
            Get
                Return bytTextFieldIndex
            End Get
            Set(ByVal Value As Byte)
                bytTextFieldIndex = Value
            End Set
        End Property
        ' Years Property
        Public Property Years() As Int16
            Get
                Return intYears
            End Get
            Set(ByVal Value As Int16)
                intYears = Value
            End Set
        End Property
        Public Property PrintCard() As Byte
            Get
                Return bytPrintCard
            End Get
            Set(ByVal Value As Byte)
                bytPrintCard = Value
            End Set
        End Property
        ' Months Property
        Public Property Months() As Int16
            Get
                Return intMonths
            End Get
            Set(ByVal Value As Int16)
                intMonths = Value
            End Set
        End Property
        ' NewExpiredDate Property
        Public Property NewExpiredDate() As String
            Get
                Return strNewExpiredDate
            End Get
            Set(ByVal Value As String)
                strNewExpiredDate = Value
            End Set
        End Property
        ' PatronIDs Property
        Public Property PatronIDs() As String
            Get
                Return strPatronIDs
            End Get
            Set(ByVal Value As String)
                strPatronIDs = Value
            End Set
        End Property
        Public ReadOnly Property ReturnData() As Object
            Get
                Return objReturnData
            End Get
        End Property
        Public ReadOnly Property DataBarCode() As Object
            Get
                Return objDataBarCode
            End Get
        End Property
        ' Seperator 
        Public Property Seperator() As String
            Get
                Return strSeperator
            End Get
            Set(ByVal Value As String)
                strSeperator = Value
            End Set
        End Property
        ' Type of picture property
        Public Property TypePic() As Byte
            Get
                Return bytTypePic
            End Get
            Set(ByVal Value As Byte)
                bytTypePic = Value
            End Set
        End Property
        ' Type of Barcode
        Public Property TypeBarcode() As Byte
            Get
                Return (bytTypeBarcode)
            End Get
            Set(ByVal Value As Byte)
                bytTypeBarcode = Value
            End Set
        End Property

        ' Type of template
        Public Property TemplateType() As Integer
            Get
                Return intTemplateType
            End Get
            Set(ByVal Value As Integer)
                intTemplateType = Value
            End Set
        End Property
        ' Barcode's rotation property
        Public Property Rotate() As Integer
            Get
                Return intRotate
            End Get
            Set(ByVal Value As Integer)
                intRotate = Value
            End Set
        End Property
        ' TemplateID property
        Public Property TemplateID() As Integer
            Get
                Return intTemplateID
            End Get
            Set(ByVal Value As Integer)
                intTemplateID = Value
            End Set
        End Property
        ' DataToGen property
        Public Property DataToGen() As DataTable
            Get
                Return TblDataToGen
            End Get
            Set(ByVal Value As DataTable)
                TblDataToGen = Value
            End Set
        End Property
        Public Property OrderBy() As Byte
            Get
                OrderBy = bytOrderBy
            End Get
            Set(ByVal Value As Byte)
                bytOrderBy = Value
            End Set
        End Property
        Public Property SelectTop() As Long
            Get
                SelectTop = lngSelectTop
            End Get
            Set(ByVal Value As Long)
                lngSelectTop = Value
            End Set
        End Property
        Public Property FromCode() As String
            Get
                Return strFromCode
            End Get
            Set(ByVal Value As String)
                strFromCode = Value
            End Set
        End Property

        Public Property ToCode() As String
            Get
                Return strToCode
            End Get
            Set(ByVal Value As String)
                strToCode = Value
            End Set
        End Property
        Public Property FromID() As Long
            Get
                FromID = lngFromID
            End Get
            Set(ByVal Value As Long)
                lngFromID = Value
            End Set
        End Property

        Public Property ToID() As Long
            Get
                FromID = lngToID
            End Get
            Set(ByVal Value As Long)
                lngToID = Value
            End Set
        End Property
        Public Property FromValidDate() As String
            Get
                FromValidDate = strFromValidDate
            End Get
            Set(ByVal Value As String)
                strFromValidDate = Value
            End Set
        End Property

        Public Property ToValidDate() As String
            Get
                ToValidDate = strToValidDate
            End Get
            Set(ByVal Value As String)
                strToValidDate = Value
            End Set
        End Property

        Public Property [Operator](ByVal bytIndex As Byte) As String
            Get
                Select Case bytIndex
                    Case 1
                        [Operator] = strOperator1
                    Case 2
                        [Operator] = strOperator2
                    Case 3
                        [Operator] = strOperator3
                    Case 4
                        [Operator] = strOperator4
                    Case 5
                        [Operator] = strOperator5
                End Select
            End Get
            Set(ByVal Value As String)
                Select Case bytIndex
                    Case 1
                        strOperator1 = Value
                    Case 2
                        strOperator2 = Value
                    Case 3
                        strOperator3 = Value
                    Case 4
                        strOperator4 = Value
                    Case 5
                        strOperator5 = Value
                End Select
            End Set
        End Property

        Public Property FieldName(ByVal bytIndex As Byte) As Byte
            Get
                Select Case bytIndex
                    Case 1
                        FieldName = bytFieldName1
                    Case 2
                        FieldName = bytFieldName2
                End Select
            End Get
            Set(ByVal Value As Byte)
                Select Case bytIndex
                    Case 1
                        bytFieldName1 = Value
                    Case 2
                        bytFieldName2 = Value
                End Select
            End Set
        End Property

        Public Property FieldNameDate(ByVal bytIndex As Byte) As Byte
            Get
                Select Case bytIndex
                    Case 1
                        FieldNameDate = bytFieldNameDate1
                    Case 2
                        FieldNameDate = bytFieldNameDate2
                End Select
            End Get
            Set(ByVal Value As Byte)
                Select Case bytIndex
                    Case 1
                        bytFieldNameDate1 = Value
                    Case 2
                        bytFieldNameDate2 = Value
                End Select
            End Set
        End Property

        Public Property FieldOpeFrom(ByVal bytIndex As Byte) As Byte
            Get
                Select Case bytIndex
                    Case 1
                        FieldOpeFrom = bytFieldOpeFrom1
                    Case 2
                        FieldOpeFrom = bytFieldOpeFrom2
                End Select
            End Get
            Set(ByVal Value As Byte)
                Select Case bytIndex
                    Case 1
                        bytFieldOpeFrom1 = Value
                    Case 2
                        bytFieldOpeFrom2 = Value
                End Select
            End Set
        End Property

        Public Property FieldNameOther(ByVal bytIndex As Byte) As Byte
            Get
                Select Case bytIndex
                    Case 1
                        FieldNameOther = bytFieldNameOther1
                    Case 2
                        FieldNameOther = bytFieldNameOther2
                End Select
            End Get
            Set(ByVal Value As Byte)
                Select Case bytIndex
                    Case 1
                        bytFieldNameOther1 = Value
                    Case 2
                        bytFieldNameOther2 = Value
                End Select
            End Set
        End Property

        Public Property FieldValueOther(ByVal bytIndex As Byte) As Integer
            Get
                Select Case bytIndex
                    Case 1
                        FieldValueOther = intFieldValueOther1
                    Case 2
                        FieldValueOther = intFieldValueOther2
                End Select
            End Get
            Set(ByVal Value As Integer)
                Select Case bytIndex
                    Case 1
                        intFieldValueOther1 = Value
                    Case 2
                        intFieldValueOther2 = Value
                End Select
            End Set
        End Property

        Public Property FieldValue(ByVal bytIndex As Byte) As String
            Get
                Select Case bytIndex
                    Case 1
                        FieldValue = strFieldValue1
                    Case 2
                        FieldValue = strFieldValue2
                End Select
            End Get
            Set(ByVal Value As String)
                Select Case bytIndex
                    Case 1
                        strFieldValue1 = Value
                    Case 2
                        strFieldValue2 = Value
                End Select
            End Set
        End Property

        Public Property FieldValueFrom(ByVal bytIndex As Byte) As String
            Get
                Select Case bytIndex
                    Case 1
                        FieldValueFrom = strFieldValueFrom1
                    Case 2
                        FieldValueFrom = strFieldValueFrom2
                End Select
            End Get
            Set(ByVal Value As String)
                Select Case bytIndex
                    Case 1
                        strFieldValueFrom1 = Value
                    Case 2
                        strFieldValueFrom2 = Value
                End Select
            End Set
        End Property

        Public Property FieldValueTo(ByVal bytIndex As Byte) As String
            Get
                Select Case bytIndex
                    Case 1
                        FieldValueTo = strFieldValueTo1
                    Case 2
                        FieldValueTo = strFieldValueTo2
                End Select
            End Get
            Set(ByVal Value As String)
                Select Case bytIndex
                    Case 1
                        strFieldValueTo1 = Value
                    Case 2
                        strFieldValueTo2 = Value
                End Select
            End Set
        End Property

        Public Property Sex() As Byte
            Get
                Sex = bytSex
            End Get
            Set(ByVal Value As Byte)
                bytSex = Value
            End Set
        End Property

        Public Property PatronGroupID() As String
            Get
                PatronGroupID = strPatronGroupID
            End Get
            Set(ByVal Value As String)
                strPatronGroupID = Value
            End Set
        End Property

        Public Property Code() As String
            Get
                Code = strCode
            End Get
            Set(ByVal Value As String)
                strCode = Value
            End Set
        End Property

        Public Property ValidDate() As String
            Get
                ValidDate = strValidDate
            End Get
            Set(ByVal Value As String)
                strValidDate = Value
            End Set
        End Property

        Public Property ExpiredDate() As String
            Get
                ExpiredDate = strExpiredDate
            End Get
            Set(ByVal Value As String)
                strExpiredDate = Value
            End Set
        End Property

        Public Property LastIssuedDate() As String
            Get
                LastIssuedDate = strLastIssuedDate
            End Get
            Set(ByVal Value As String)
                strLastIssuedDate = Value
            End Set
        End Property

        Public Property FullName() As String
            Get
                FullName = strFullName
            End Get
            Set(ByVal Value As String)
                strFullName = Value
            End Set
        End Property

        Public Property DOB() As String
            Get
                DOB = strDOB
            End Get
            Set(ByVal Value As String)
                strDOB = Value
            End Set
        End Property

        Public Property EthnicID() As Integer
            Get
                EthnicID = intEthnicID
            End Get
            Set(ByVal Value As Integer)
                intEthnicID = Value
            End Set
        End Property

        Public Property EducationID() As Integer
            Get
                EducationID = intEducationID
            End Get
            Set(ByVal Value As Integer)
                intEducationID = Value
            End Set
        End Property

        Public Property OccupationID() As Integer
            Get
                OccupationID = intOccupationID
            End Get
            Set(ByVal Value As Integer)
                intOccupationID = Value
            End Set
        End Property

        Public Property WorkPlace() As String
            Get
                WorkPlace = strWorkPlace
            End Get
            Set(ByVal Value As String)
                strWorkPlace = Value
            End Set
        End Property

        Public Property Mobile() As String
            Get
                Mobile = strMobile
            End Get
            Set(ByVal Value As String)
                strMobile = Value
            End Set
        End Property

        Public Property Email() As String
            Get
                Email = strEmail
            End Get
            Set(ByVal Value As String)
                strEmail = Value
            End Set
        End Property

        Public Property LastModifiedDate() As String
            Get
                LastModifiedDate = strLastModifiedDate
            End Get
            Set(ByVal Value As String)
                strLastModifiedDate = Value
            End Set
        End Property
        Public Property College() As String
            Get
                College = strCollege
            End Get
            Set(ByVal Value As String)
                strCollege = Value
            End Set
        End Property

        Public Property Faculty() As Integer
            Get
                Faculty = intFaculty
            End Get
            Set(ByVal Value As Integer)
                intFaculty = Value
            End Set
        End Property

        Public Property Grade() As String
            Get
                Grade = strGrade
            End Get
            Set(ByVal Value As String)
                strGrade = Value
            End Set
        End Property

        Public Property Classs() As String
            Get
                Classs = strClass
            End Get
            Set(ByVal Value As String)
                strClass = Value
            End Set
        End Property

        Public Property Address() As String
            Get
                Address = strAddress
            End Get
            Set(ByVal Value As String)
                strAddress = Value
            End Set
        End Property
        ' TypeSearch Property
        Public Property TypeSearch() As String
            Get
                Return strTypeSearch
            End Get
            Set(ByVal Value As String)
                strTypeSearch = Value
            End Set
        End Property

        ' Readonly arrDataChar property for 2 chartdirector only
        Public ReadOnly Property ArrDataChart() As Object
            Get
                Return objArrDataChart
            End Get
        End Property

        ' Readonly arrLabelChart property for 2 chartdirector only
        Public ReadOnly Property ArrLabelChart() As Object
            Get
                Return objArrLabelChart
            End Get
        End Property

        ' Exist patron property
        Public Property ExistPatron() As DataTable
            Get
                Return (tblExistPatron)
            End Get
            Set(ByVal Value As DataTable)
                tblExistPatron = Value
            End Set
        End Property

        ' LibID Property
        Public Property LibID() As Integer
            Get
                Return intLibID
            End Get
            Set(ByVal Value As Integer)
                intLibID = Value
            End Set
        End Property

        ' *************************************************************************************************
        ' End declare properties
        ' Declare public method 
        ' *************************************************************************************************
        Public Sub initialize()
            ' Initialize objDPatronCollection object
            objDPatronCollection.DBServer = strDBServer
            objDPatronCollection.ConnectionString = strConnectionString
            objDPatronCollection.Initialize()
            ' Initialize objBCChart object
            objBCChart.InterfaceLanguage = strinterfacelanguage
            objBCChart.DBServer = strDBServer
            objBCChart.ConnectionString = strConnectionString
            objBCChart.Initialize()
            ' Initialize objBCSP object
            objBCSP.InterfaceLanguage = strinterfacelanguage
            objBCSP.DBServer = strDBServer
            objBCSP.ConnectionString = strConnectionString
            objBCSP.Initialize()
            ' Initialize objBCDBS object
            objBCDBS.InterfaceLanguage = strinterfacelanguage
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.Initialize()
            ' Initialize objBCT object
            objBCT.InterfaceLanguage = strinterfacelanguage
            objBCT.DBServer = strDBServer
            objBCT.ConnectionString = strConnectionString
            objBCT.Initialize()
            ' Initialize objBP object
            objBP.InterfaceLanguage = strinterfacelanguage
            objBP.DBServer = strDBServer
            objBP.ConnectionString = strConnectionString
            objBP.Initialize()
            ' Initialise objBPro object
            objBPro.InterfaceLanguage = strinterfacelanguage
            objBPro.DBServer = strDBServer
            objBPro.ConnectionString = strConnectionString
            objBPro.Initialize()
            ' Initialize objBO object
            objBO.InterfaceLanguage = strinterfacelanguage
            objBO.DBServer = strDBServer
            objBO.ConnectionString = strConnectionString
            objBO.Initialize()
            ' Initialize objBE object
            objBE.InterfaceLanguage = strinterfacelanguage
            objBE.DBServer = strDBServer
            objBE.ConnectionString = strConnectionString
            objBE.Initialize()
            ' Initialize objBC object
            objBC.InterfaceLanguage = strinterfacelanguage
            objBC.DBServer = strDBServer
            objBC.ConnectionString = strConnectionString
            objBC.Initialize()
            ' Initialize objBPG object
            objBPG.InterfaceLanguage = strinterfacelanguage
            objBPG.DBServer = strDBServer
            objBPG.ConnectionString = strConnectionString
            objBPG.Initialize()
            ' Initialize objBF object
            objBF.InterfaceLanguage = strinterfacelanguage
            objBF.DBServer = strDBServer
            objBF.ConnectionString = strConnectionString
            objBF.Initialize()
        End Sub

        Public Sub AgeStat(Optional ByVal bollFlage As Boolean = False, Optional ByVal intFromAge As Integer = 0, Optional ByVal intToAge As Integer = 0)
            Dim TblAge As New DataTable
            Dim ArrDataRet() As Integer
            Dim ArrLabelRet() As String
            Dim byti As Byte
            Dim inti, introw As Integer
            ReDim ArrDataRet(0)
            ReDim ArrLabelRet(0)
            ArrDataRet(0) = 0
            ArrLabelRet(0) = "NOT FOUND"
            ' Get data
            objDPatronCollection.LibID = intLibID
            TblAge = objBCDBS.ConvertTable(objDPatronCollection.AgeStat(intFromAge, intToAge))
            strErrorMsg = objDPatronCollection.ErrorMsg
            intErrorCode = objDPatronCollection.ErrorCode
            ' Statistic here
            If bollFlage = False Then ' Statistic All Age
                ReDim ArrLabelRet(6)
                ReDim ArrDataRet(6)
                Try
                    ArrLabelRet(0) = "<=18"
                    ArrLabelRet(1) = "18-30"
                    ArrLabelRet(2) = "30-40"
                    ArrLabelRet(3) = "40-50"
                    ArrLabelRet(4) = "50-60"
                    ArrLabelRet(5) = "60-70"
                    ArrLabelRet(6) = ">=70"
                    For introw = 0 To 6
                        ArrDataRet(introw) = 0
                    Next
                    If TblAge.Rows.Count > 0 Then
                        For introw = 0 To TblAge.Rows.Count - 1
                            If Not IsDBNull(TblAge.Rows(introw).Item(0)) Then
                                If ((TblAge.Rows(introw).Item(0))) <= 18 Then
                                    ArrDataRet(0) += 1
                                Else
                                    If ((TblAge.Rows(introw).Item(0))) <= 30 Then
                                        ArrDataRet(1) += 1
                                    Else
                                        If ((TblAge.Rows(introw).Item(0))) <= 40 Then
                                            ArrDataRet(2) += 1
                                        Else
                                            If ((TblAge.Rows(introw).Item(0))) <= 50 Then
                                                ArrDataRet(3) += 1
                                            Else
                                                If ((TblAge.Rows(introw).Item(0))) <= 60 Then
                                                    ArrDataRet(4) += 1
                                                Else
                                                    If ((TblAge.Rows(introw).Item(0))) <= 70 Then
                                                        ArrDataRet(5) += 1
                                                    Else
                                                        ArrDataRet(6) += 1
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            Else ' tuoi bang null
                                ArrDataRet(0) += 1 ' default null la <=18 tuoi
                            End If
                        Next
                    End If
                    objArrLabelChart = ArrLabelRet
                    objArrDataChart = ArrDataRet
                Catch ex As Exception
                    strErrorMsg = ex.Message
                End Try
            Else ' Statistic Each Age
                Try
                    ReDim ArrLabelRet(intToAge - intFromAge)
                    ReDim ArrDataRet(intToAge - intFromAge)
                    For byti = 0 To intToAge - intFromAge
                        ArrDataRet(byti) = 0
                        ArrLabelRet(byti) = byti + intFromAge
                    Next
                    If Not TblAge Is Nothing Then
                        If TblAge.Rows.Count > 0 Then
                            ReDim ArrLabelRet(TblAge.Rows.Count - 1)
                            ReDim ArrDataRet(TblAge.Rows.Count - 1)
                            For inti = 0 To TblAge.Rows.Count - 1
                                ArrLabelRet(inti) = objBCSP.UCS2DataLabel(TblAge.Rows(inti).Item(0))
                                ArrDataRet(inti) = TblAge.Rows(inti).Item(1)
                            Next
                        End If
                        objArrLabelChart = ArrLabelRet
                        objArrDataChart = ArrDataRet
                    End If
                Catch ex As Exception
                    strErrorMsg = ex.Message
                End Try
            End If
        End Sub

        Public Function AgeStatDetail(ByVal intFromAge As Integer, ByVal intToAge As Integer) As DataTable
            Try
                objDPatronCollection.LibID = intLibID
                AgeStatDetail = objDPatronCollection.AgeStatDetail(intFromAge, intToAge)
                ErrorCode = objDPatronCollection.ErrorCode
                ErrorMsg = objDPatronCollection.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
        End Function
        Public Function CreatedDateStatDetail(ByVal intCreatedDate As Integer) As DataTable
            Try
                objDPatronCollection.FacultyID = intFaculty
                objDPatronCollection.LibID = intLibID
                CreatedDateStatDetail = objDPatronCollection.CreatedDateStatDetail(intCreatedDate)
                ErrorCode = objDPatronCollection.ErrorCode
                ErrorMsg = objDPatronCollection.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
        End Function
        Public Function CreatedDateStatDetailDHVL(ByVal strDateFrom As String, ByVal strDateTo As String) As DataTable
            Try
                objDPatronCollection.FacultyID = intFaculty
                objDPatronCollection.LibID = intLibID
                CreatedDateStatDetailDHVL = objDPatronCollection.CreatedDateStatDetailDHVL(strDateFrom, strDateTo)
                ErrorCode = objDPatronCollection.ErrorCode
                ErrorMsg = objDPatronCollection.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
        End Function

        Public Function PatronGroupStatDetail() As DataTable
            Try
                objDPatronCollection.PatronGroupID = strPatronGroupID
                objDPatronCollection.LibID = intLibID
                PatronGroupStatDetail = objDPatronCollection.PatronGroupStatDetail()
                ErrorCode = objDPatronCollection.ErrorCode
                ErrorMsg = objDPatronCollection.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
        End Function
        Public Function ExpiredDateStatDetail(ByVal intExpiredDate As Integer) As DataTable
            Try
                objDPatronCollection.FacultyID = intFaculty
                objDPatronCollection.LibID = intLibID
                ExpiredDateStatDetail = objDPatronCollection.ExpiredDateStatDetail(intExpiredDate)
                ErrorCode = objDPatronCollection.ErrorCode
                ErrorMsg = objDPatronCollection.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
        End Function
        Public Function ExpiredDateStatDetailDHVL(ByVal strDateFrom As String, ByVal strDateTo As String) As DataTable
            Try
                objDPatronCollection.FacultyID = intFaculty
                objDPatronCollection.LibID = intLibID
                ExpiredDateStatDetailDHVL = objDPatronCollection.ExpiredDateStatDetailDHVL(strDateFrom, strDateTo)
                ErrorCode = objDPatronCollection.ErrorCode
                ErrorMsg = objDPatronCollection.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
        End Function

        Public Sub PatronGroupStat(ByVal strNoname As String)
            Dim TblGroup As New DataTable
            Dim ArrDataRet() As Integer
            Dim ArrLabelRet() As String
            Dim inti As Integer
            Dim intCount As Integer = 0
            Try
                objDPatronCollection.LibID = intLibID
                TblGroup = objBCDBS.ConvertTable(objDPatronCollection.PatronGroupStat)
                strErrorMsg = objDPatronCollection.ErrorMsg
                intErrorCode = objDPatronCollection.ErrorCode
                If Not TblGroup Is Nothing Then
                    If TblGroup.Rows.Count > 0 Then
                        'ReDim ArrDataRet(TblGroup.Rows.Count - 1)
                        'ReDim ArrLabelRet(TblGroup.Rows.Count - 1)
                        intCount = 0
                        For inti = 0 To TblGroup.Rows.Count - 1
                            If CStr(TblGroup.Rows(inti).Item(0) & "") = "Noname" Then
                                'ArrLabelRet(inti) = strNoname
                            Else
                                ReDim Preserve ArrDataRet(intCount)
                                ReDim Preserve ArrLabelRet(intCount)
                                'ArrLabelRet(inti) = objBCSP.UCS2DataLabel(TblGroup.Rows(inti).Item(0) & "")
                                ArrDataRet(intCount) = TblGroup.Rows(inti).Item(1)
                                ArrLabelRet(intCount) = TblGroup.Rows(inti).Item(0) & ""
                                intCount += 1
                            End If
                        Next
                    Else
                        ReDim ArrDataRet(0)
                        ReDim ArrLabelRet(0)
                        ArrDataRet(0) = 0
                        ArrLabelRet(0) = "NOT FOUND"
                    End If
                    objArrLabelChart = ArrLabelRet
                    objArrDataChart = ArrDataRet
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Sub CreatedDateStat(ByVal intCreatedDate As Integer)
            Dim TblCreaDate As New DataTable
            Dim ArrDataRet() As Integer
            Dim ArrLabelRet() As String
            Dim inti As Integer
            Try
                objDPatronCollection.LibID = intLibID
                TblCreaDate = objBCDBS.ConvertTable(objDPatronCollection.CreatedDateStat(intCreatedDate))
                strErrorMsg = objDPatronCollection.ErrorMsg
                intErrorCode = objDPatronCollection.ErrorCode
                If Not TblCreaDate Is Nothing Then
                    If TblCreaDate.Rows.Count > 0 Then
                        ReDim ArrLabelRet(TblCreaDate.Rows.Count - 1)
                        ReDim ArrDataRet(TblCreaDate.Rows.Count - 1)
                        For inti = 0 To TblCreaDate.Rows.Count - 1
                            ArrDataRet(inti) = TblCreaDate.Rows(inti).Item(0)
                            ArrLabelRet(inti) = TblCreaDate.Rows(inti).Item(1)
                        Next
                    Else
                        ReDim ArrDataRet(0)
                        ReDim ArrLabelRet(0)
                        ArrDataRet(0) = 0
                        ArrLabelRet(0) = "NOT FOUND"
                    End If
                End If
                objArrLabelChart = ArrLabelRet
                objArrDataChart = ArrDataRet
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Sub ExpiredDateStat(Optional ByVal intExpiredDate As Integer = 0)
            Dim TblExpDate As New DataTable
            Dim ArrDataRet() As Integer
            Dim ArrLabelRet() As String
            Dim inti As Integer
            Try
                objDPatronCollection.LibID = intLibID
                TblExpDate = objBCDBS.ConvertTable(objDPatronCollection.ExpiredDateStat(intExpiredDate))
                strErrorMsg = objDPatronCollection.ErrorMsg
                intErrorCode = objDPatronCollection.ErrorCode
                If Not TblExpDate Is Nothing Then
                    If TblExpDate.Rows.Count > 0 Then
                        ReDim ArrLabelRet(TblExpDate.Rows.Count - 1)
                        ReDim ArrDataRet(TblExpDate.Rows.Count - 1)
                        For inti = 0 To TblExpDate.Rows.Count - 1
                            ArrDataRet(inti) = TblExpDate.Rows(inti).Item(0)
                            If Not IsDBNull(TblExpDate.Rows(inti).Item(1)) Then
                                ArrLabelRet(inti) = TblExpDate.Rows(inti).Item(1)
                            Else
                                ArrLabelRet(inti) = "không thời hạn"
                            End If
                        Next
                    Else
                        ReDim ArrDataRet(0)
                        ReDim ArrLabelRet(0)
                        ArrDataRet(0) = 0
                        ArrLabelRet(0) = "NOT FOUND"
                    End If
                End If
                objArrLabelChart = ArrLabelRet
                objArrDataChart = ArrDataRet
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Sub OccupationStat(ByVal strNoname As String, Optional ByVal strOccupationIDs As String = "")
            Dim TblOccupation As New DataTable
            Dim ArrDataRet() As Integer
            Dim ArrLabelRet() As String
            Dim inti As Integer
            Try
                TblOccupation = objDPatronCollection.OccupationStat(strOccupationIDs)
                strErrorMsg = objDPatronCollection.ErrorMsg
                intErrorCode = objDPatronCollection.ErrorCode
                If Not TblOccupation Is Nothing Then
                    If TblOccupation.Rows.Count > 0 Then
                        ReDim ArrDataRet(TblOccupation.Rows.Count - 1)
                        ReDim ArrLabelRet(TblOccupation.Rows.Count - 1)
                        For inti = 0 To TblOccupation.Rows.Count - 1
                            ArrDataRet(inti) = TblOccupation.Rows(inti).Item(1)
                            If CStr(TblOccupation.Rows(inti).Item(0) & "") = "Noname" Then
                                ArrLabelRet(inti) = objBCSP.UCS2Title(strNoname)
                            Else
                                ArrLabelRet(inti) = objBCSP.UCS2DataLabel(TblOccupation.Rows(inti).Item(0) & "")
                            End If
                        Next
                    Else
                        ReDim ArrDataRet(0)
                        ReDim ArrLabelRet(0)
                        ArrDataRet(0) = 0
                        ArrLabelRet(0) = "NOT FOUND"
                    End If
                End If
                objArrLabelChart = ArrLabelRet
                objArrDataChart = ArrDataRet
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Sub CollegeStat(ByVal strNoname As String)
            Dim TblCollege As New DataTable
            Dim ArrDataRet() As Integer
            Dim ArrLabelRet() As String
            Dim inti As Integer
            Try
                objDPatronCollection.LibID = intLibID
                TblCollege = objBCDBS.ConvertTable(objDPatronCollection.CollegeStat)
                strErrorMsg = objDPatronCollection.ErrorMsg
                intErrorCode = objDPatronCollection.ErrorCode
                If Not TblCollege Is Nothing Then
                    If TblCollege.Rows.Count > 0 Then
                        ReDim ArrDataRet(TblCollege.Rows.Count - 1)
                        ReDim ArrLabelRet(TblCollege.Rows.Count - 1)
                        For inti = 0 To TblCollege.Rows.Count - 1
                            ArrDataRet(inti) = TblCollege.Rows(inti).Item(1)
                            If CStr(TblCollege.Rows(inti).Item(0) & "") = "Noname" Then
                                ArrLabelRet(inti) = objBCSP.UCS2Title(strNoname)
                            Else
                                ArrLabelRet(inti) = objBCSP.UCS2DataLabel(TblCollege.Rows(inti).Item(0) & "")
                            End If
                        Next
                    Else
                        ReDim ArrDataRet(0)
                        ReDim ArrLabelRet(0)
                        ArrDataRet(0) = 0
                        ArrLabelRet(0) = "NOT FOUND"
                    End If
                End If
                objArrLabelChart = ArrLabelRet
                objArrDataChart = ArrDataRet
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Sub FacultyStat(ByVal strNoname As String, Optional ByVal intCollegeID As Integer = 0)
            Dim TblFaculty As New DataTable
            Dim ArrDataRet() As Integer
            Dim ArrLabelRet() As String
            Dim inti As Integer
            Try
                ' Get data to statistic
                TblFaculty = objBCDBS.ConvertTable(objDPatronCollection.FacultyStat(intCollegeID))
                strErrorMsg = objDPatronCollection.ErrorMsg
                intErrorCode = objDPatronCollection.ErrorCode
                If Not TblFaculty Is Nothing Then
                    If TblFaculty.Rows.Count > 0 Then
                        ReDim ArrDataRet(TblFaculty.Rows.Count - 1)
                        ReDim ArrLabelRet(TblFaculty.Rows.Count - 1)
                        For inti = 0 To TblFaculty.Rows.Count - 1
                            ArrDataRet(inti) = TblFaculty.Rows(inti).Item(1)
                            If CStr(TblFaculty.Rows(inti).Item(0) & "") = "Noname" Then
                                ArrLabelRet(inti) = objBCSP.UCS2Title(strNoname)
                            Else
                                ArrLabelRet(inti) = objBCSP.UCS2DataLabel(TblFaculty.Rows(inti).Item(0) & "")
                            End If
                        Next
                    Else
                        ReDim ArrDataRet(0)
                        ReDim ArrLabelRet(0)
                        ArrDataRet(0) = 0
                        ArrLabelRet(0) = "NOT FOUND"
                    End If
                End If
                objArrLabelChart = ArrLabelRet
                objArrDataChart = ArrDataRet
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Function FacultyStat(ByVal strNoname As String, Optional ByVal intDicFacultyID As Integer = 0, Optional ByVal intGroup As Integer = 0, Optional ByVal intYearFrom As Integer = 0, Optional ByVal intYearTo As Integer = 0) As DataTable
            Dim TblFaculty As New DataTable
            Dim ArrDataRet() As Integer
            Dim ArrLabelRet() As String
            Dim inti As Integer
            Try
                ' Get data to statistic
                objDPatronCollection.LibID = intLibID
                TblFaculty = objBCDBS.ConvertTable(objDPatronCollection.FacultyStat(intDicFacultyID, intGroup, intYearFrom, intYearTo))
                strErrorMsg = objDPatronCollection.ErrorMsg
                intErrorCode = objDPatronCollection.ErrorCode
                If Not TblFaculty Is Nothing Then
                    If TblFaculty.Rows.Count > 0 Then
                        ReDim ArrDataRet(TblFaculty.Rows.Count - 1)
                        ReDim ArrLabelRet(TblFaculty.Rows.Count - 1)
                        For inti = 0 To TblFaculty.Rows.Count - 1
                            ArrDataRet(inti) = TblFaculty.Rows(inti).Item(1)
                            If CStr(TblFaculty.Rows(inti).Item(0) & "") = "Noname" Then
                                ArrLabelRet(inti) = objBCSP.UCS2Title(strNoname)
                            Else
                                ArrLabelRet(inti) = objBCSP.UCS2DataLabel(TblFaculty.Rows(inti).Item(0) & "")
                            End If
                        Next
                    Else
                        ReDim ArrDataRet(0)
                        ReDim ArrLabelRet(0)
                        ArrDataRet(0) = 0
                        ArrLabelRet(0) = "NOT FOUND"
                    End If
                End If
                objArrLabelChart = ArrLabelRet
                objArrDataChart = ArrDataRet
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function
        Public Function FacultyStatDetail(ByVal intDicFacultyID As Integer, Optional ByVal intGroup As Integer = 0, Optional ByVal intYearFrom As Integer = 0, Optional ByVal intYearTo As Integer = 0) As DataTable
            Try
                objDPatronCollection.LibID = intLibID
                FacultyStatDetail = objDPatronCollection.FacultyStatDetail(intDicFacultyID, intGroup, intYearFrom, intYearTo)
                ErrorCode = objDPatronCollection.ErrorCode
                ErrorMsg = objDPatronCollection.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
        End Function

        Public Sub GradeStat(ByVal strNoname As String, Optional ByVal intCollegeID As Integer = 0)
            Dim TblGrade As New DataTable
            Dim ArrDataRet() As Integer
            Dim ArrLabelRet() As String
            Dim inti As Integer
            Try
                TblGrade = objBCDBS.ConvertTable(objDPatronCollection.GradeStat(intCollegeID))
                strErrorMsg = objDPatronCollection.ErrorMsg
                intErrorCode = objDPatronCollection.ErrorCode
                If TblGrade.Rows.Count > 0 Then
                    ReDim ArrDataRet(TblGrade.Rows.Count - 1)
                    ReDim ArrLabelRet(TblGrade.Rows.Count - 1)
                    For inti = 0 To TblGrade.Rows.Count - 1
                        ArrDataRet(inti) = TblGrade.Rows(inti).Item(1)
                        If CStr(TblGrade.Rows(inti).Item(0) & "") = "Noname" Then
                            ArrLabelRet(inti) = objBCSP.UCS2Title(strNoname)
                        Else
                            ArrLabelRet(inti) = objBCSP.UCS2DataLabel(TblGrade.Rows(inti).Item(0) & "")
                        End If
                    Next
                Else
                    ReDim ArrDataRet(0)
                    ReDim ArrLabelRet(0)
                    ArrDataRet(0) = 0
                    ArrLabelRet(0) = "NOT FOUND"
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            objArrLabelChart = ArrLabelRet
            objArrDataChart = ArrDataRet
        End Sub

        Public Sub ClassStat(ByVal strNoname As String, Optional ByVal intFacultyID As Integer = 0)
            Dim TblClass As New DataTable
            Dim ArrDataRet() As Integer
            Dim ArrLabelRet() As String
            Dim inti As Integer
            Try
                TblClass = objBCDBS.ConvertTable(objDPatronCollection.ClassStat(intFacultyID))
                strErrorMsg = objDPatronCollection.ErrorMsg
                intErrorCode = objDPatronCollection.ErrorCode
                If Not TblClass Is Nothing Then
                    If TblClass.Rows.Count > 0 Then
                        ReDim ArrDataRet(TblClass.Rows.Count - 1)
                        ReDim ArrLabelRet(TblClass.Rows.Count - 1)
                        For inti = 0 To TblClass.Rows.Count - 1
                            ArrDataRet(inti) = TblClass.Rows(inti).Item(1)
                            If CStr(TblClass.Rows(inti).Item(0) & "") = "Noname" Then
                                ArrLabelRet(inti) = objBCSP.UCS2Title(strNoname)
                            Else
                                ArrLabelRet(inti) = objBCSP.UCS2DataLabel(TblClass.Rows(inti).Item(0) & "")
                            End If
                        Next
                    Else
                        ReDim ArrDataRet(0)
                        ReDim ArrLabelRet(0)
                        ArrDataRet(0) = 0
                        ArrLabelRet(0) = "NOT FOUND"
                    End If
                End If
                objArrLabelChart = ArrLabelRet
                objArrDataChart = ArrDataRet
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Sub Top20Stat(ByVal strTypeStatistic As String, ByVal strNoname As String)
            Dim tblTop20Stat As New DataTable
            Dim ArrDataRet() As Integer
            Dim ArrLabelRet() As String
            Dim inti As Integer
            Try
                objDPatronCollection.LibID = intLibID
                tblTop20Stat = objBCDBS.ConvertTable(objDPatronCollection.Top20Stat(strTypeStatistic))
                strErrorMsg = objDPatronCollection.ErrorMsg
                intErrorCode = objDPatronCollection.ErrorCode
                If Not tblTop20Stat Is Nothing Then
                    If tblTop20Stat.Rows.Count > 0 Then
                        ReDim ArrDataRet(tblTop20Stat.Rows.Count - 1)
                        ReDim ArrLabelRet(tblTop20Stat.Rows.Count - 1)
                        For inti = 0 To tblTop20Stat.Rows.Count - 1
                            ArrDataRet(inti) = tblTop20Stat.Rows(inti).Item(1)
                            If CStr(tblTop20Stat.Rows(inti).Item(0) & "") = "" Or CStr(tblTop20Stat.Rows(inti).Item(0) & "") = "Noname" Then
                                ArrLabelRet(inti) = strNoname 'objBCSP.UCS2Title(strNoname)
                            Else
                                ArrLabelRet(inti) = objBCSP.UCS2DataLabel(tblTop20Stat.Rows(inti).Item(0) & "")
                            End If
                        Next
                    Else
                        ReDim ArrDataRet(0)
                        ReDim ArrLabelRet(0)
                        ArrDataRet(0) = 0
                        ArrLabelRet(0) = "NOT FOUND"
                    End If
                End If
                objArrLabelChart = ArrLabelRet
                objArrDataChart = ArrDataRet
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Function Top20StatDetail(ByVal strTypeStatistic As String) As DataTable
            Try
                objDPatronCollection.LibID = intLibID
                Top20StatDetail = objDPatronCollection.Top20StatDetail(strTypeStatistic)
                ErrorCode = objDPatronCollection.ErrorCode
                ErrorMsg = objDPatronCollection.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
        End Function

        Public Sub GenDataTemplate()
            Dim ArrReturnGen() 'store data after use tvtemplate generate.
            Dim ArrOutBarcode() 'store barcode to print
            Dim ArrDataToBarCode() 'store code to gen barcode
            'Dim TvTemp As New TVCOMLib.LibolTemplate
            Dim TblRet As New DataTable ' store content about Template
            ReDim ArrDataToBarCode(-1)
            Dim introw As Integer
            Dim inti As Integer
            Try
                objBCT.TemplateID = CStr(intTemplateID)
                objBCT.TemplateType = intTemplateType
                TblRet = objBCT.GetTemplate
                strErrorMsg = objBCT.ErrorMsg
                intErrorCode = objBCT.ErrorCode
                If TblRet.Rows.Count > 0 Then
                    'TvTemp.Template = objBCSP.ToUTF8(TblRet.Rows(0).Item("Content"))
                    'arrField = TvTemp.Fields()
                    'Dim strContentTemp As String = objBCSP.ToUTF8(TblRet.Rows(0).Item("Content"))
                    Dim strContentTemp As String = TblRet.Rows(0).Item("Content")
                    arrField = objBCT.getArrayFromTemplate(strContentTemp)
                    Dim Data() ' store input for Generate of TvTemplate
                    ReDim ArrOutBarcode(TblDataToGen.Rows.Count - 1)
                    ReDim ArrDataToBarCode(TblDataToGen.Rows.Count - 1)
                    Dim strContent As String = strContentTemp
                    For introw = 0 To TblDataToGen.Rows.Count - 1
                        If TblDataToGen.Rows.Count > 0 Then

                            If Not (IsNothing(arrField)) Then
                                ReDim Data(UBound(arrField))
                                ArrDataToBarCode(introw) = ""
                                strContent = strContentTemp
                                For inti = 0 To UBound(arrField)
                                    If InStr(strTags, arrField(inti) & ",") > 0 Then
                                        Data(inti) = ""
                                        Try
                                            Select Case UCase(arrField(inti))
                                                Case "NAME", "FULLNAME"
                                                    'Data(inti) = objBCSP.ToUTF8(TblDataToGen.Rows(introw).Item("FULLNAME") & "")
                                                    Data(inti) = TblDataToGen.Rows(introw).Item("FULLNAME") & ""
                                                Case "BARCODE"
                                                    Data(inti) = "..\Common\WPrintBarCode.aspx?i=" & introw
                                                    ArrDataToBarCode(introw) = TblDataToGen.Rows(introw).Item("Code") & ""
                                                Case "PICTURE"
                                                    If IsDBNull(TblDataToGen.Rows(introw).Item("Portrait")) Then
                                                        Data(inti) = "..\Images\Card\empty.gif"
                                                    Else
                                                        'Data(inti) = "..\Images\Card\" & TblDataToGen.Rows(introw).Item("Portrait")
                                                        Dim strURL As String = "../Images/Card/" & TblDataToGen.Rows(introw).Item("Portrait")
                                                        Data(inti) = "../Common/ShowPic.aspx?intw=90&inth=120&Url=" & strURL
                                                    End If
                                                Case Else
                                                    'Data(inti) = objBCSP.ToUTF8(TblDataToGen.Rows(introw).Item("" & arrField(inti) & "") & "")
                                                    Data(inti) = TblDataToGen.Rows(introw).Item("" & arrField(inti) & "") & ""
                                            End Select
                                        Catch ex As Exception
                                            strErrorMsg = ex.Message
                                            Data(inti) = " "
                                        End Try
                                        If Not strSeperator = "" Then
                                            Data(inti) = Data(inti) & strSeperator
                                        End If
                                    End If
                                    strContent = Replace(strContent, "<$" & arrField(inti) & "$>", Data(inti))
                                Next ' UBound(ArrField)
                                ReDim Preserve ArrReturnGen(introw)
                                'ArrReturnGen(introw) = objBCSP.ToUTF8Back(TvTemp.Generate(Data))
                                ArrReturnGen(introw) = strContent
                            End If
                            
                        End If
                    Next ' TblDataToGen.Rows.Count - 1
                    If UBound(ArrDataToBarCode) >= 0 Then
                        objBCChart.MakeImgBarcode(ArrDataToBarCode, bytTypePic, 1, 50, bytTypeBarcode, "", "", "", intRotate)
                        objDataBarCode = objBCChart.BarCodeImg ' mang cac anh barcode
                    End If
                    objReturnData = ArrReturnGen ' mang cac du lieu tao theo mau
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                'TvTemp = Nothing
            End Try
        End Sub

        Public Function Search() As Object
            Dim ArrID()
            Dim ArrText()
            Dim ArrIndex()
            Dim ArrRetID()
            Dim strTemp As String

            objDPatronCollection.OrderBy = bytOrderBy
            objDPatronCollection.SelectTop = lngSelectTop
            objDPatronCollection.OccupationID = intOccupationID
            objDPatronCollection.PatronGroupID = strPatronGroupID
            objDPatronCollection.EducationID = intEducationID
            objDPatronCollection.EthnicID = intEthnicID
            objDPatronCollection.FacultyID = intFaculty
            objDPatronCollection.Sex = bytSex
            objDPatronCollection.FromID = lngFromID
            objDPatronCollection.ToID = lngToID
            objDPatronCollection.FromCode = strFromCode
            objDPatronCollection.ToCode = strToCode
            objDPatronCollection.Code = Replace(Replace(objBCSP.ConvertItBack(strCode), "''", ""), "'", "")
            objDPatronCollection.Email = objBCSP.ConvertItBack(strEmail)
            objDPatronCollection.FullName = Replace(Replace(objBCSP.ConvertItBack(strFullName), "''", ""), "'", "")
            objDPatronCollection.Mobile = objBCSP.ConvertItBack(strMobile)
            objDPatronCollection.WorkPlace = objBCSP.ConvertItBack(strWorkPlace)
            objDPatronCollection.Classs = Replace(Replace(objBCSP.ConvertItBack(strClass), "''", ""), "'", "")
            objDPatronCollection.Grade = Replace(Replace(objBCSP.ConvertItBack(strGrade), "''", ""), "'", "")
            objDPatronCollection.PrintCard = bytPrintCard
            objDPatronCollection.LibID = intLibID
            strTemp = objBCDBS.ConvertDateBack(strFromValidDate)
            If strTemp <> "" Then
                objDPatronCollection.FromValidDate = Left(strTemp, InStr(strTemp, " ") - 1)
            Else
                objDPatronCollection.FromValidDate = ""
            End If
            strTemp = ""
            strTemp = objBCDBS.ConvertDateBack(strToValidDate)
            If strTemp <> "" Then
                objDPatronCollection.ToValidDate = Left(strTemp, InStr(strTemp, " ") - 1)
            Else
                objDPatronCollection.ToValidDate = ""
            End If
            strTemp = ""
            strTemp = objBCDBS.ConvertDateBack(strValidDate)
            If strTemp <> "" Then
                objDPatronCollection.ValidDate = Left(strTemp, InStr(strTemp, " ") - 1)
            Else
                objDPatronCollection.ValidDate = ""
            End If
            strTemp = ""
            strTemp = objBCDBS.ConvertDateBack(strDOB)
            If strTemp <> "" Then
                objDPatronCollection.DOB = Left(strTemp, InStr(strTemp, " ") - 1)
            Else
                objDPatronCollection.DOB = ""
            End If
            strTemp = ""
            strTemp = objBCDBS.ConvertDateBack(ExpiredDate)
            If strTemp <> "" Then
                objDPatronCollection.ExpiredDate = Left(strTemp, InStr(strTemp, " ") - 1)
            Else
                objDPatronCollection.ExpiredDate = ""
            End If
            strTemp = ""
            strTemp = objBCDBS.ConvertDateBack(strLastIssuedDate)
            If strTemp <> "" Then
                objDPatronCollection.LastIssuedDate = Left(strTemp, InStr(strTemp, " ") - 1)
            Else
                objDPatronCollection.LastIssuedDate = ""
            End If
            strTemp = ""
            strTemp = objBCDBS.ConvertDateBack(strLastModifiedDate)
            If strTemp <> "" Then
                objDPatronCollection.LastModifiedDate = Left(strTemp, InStr(strTemp, " ") - 1)
            Else
                objDPatronCollection.LastModifiedDate = ""
            End If

            objDPatronCollection.TypeSearch = strTypeSearch

            objDPatronCollection.FieldName(1) = bytFieldName1
            objDPatronCollection.FieldName(2) = bytFieldName2

            objDPatronCollection.FieldNameDate(1) = bytFieldNameDate1
            objDPatronCollection.FieldNameDate(2) = bytFieldNameDate2

            objDPatronCollection.FieldOpeFrom(1) = bytFieldOpeFrom1
            objDPatronCollection.FieldOpeFrom(2) = bytFieldOpeFrom2

            objDPatronCollection.[Operator](1) = strOperator1
            objDPatronCollection.[Operator](2) = strOperator2
            objDPatronCollection.[Operator](3) = strOperator3
            objDPatronCollection.[Operator](4) = strOperator4
            objDPatronCollection.[Operator](5) = strOperator5

            objDPatronCollection.FieldNameOther(1) = bytFieldNameOther1
            objDPatronCollection.FieldNameOther(2) = bytFieldNameOther2

            objDPatronCollection.FieldValueOther(1) = intFieldValueOther1
            objDPatronCollection.FieldValueOther(2) = intFieldValueOther2

            objDPatronCollection.FieldValue(1) = objBCSP.ConvertItBack(strFieldValue1)
            objDPatronCollection.FieldValue(2) = objBCSP.ConvertItBack(strFieldValue2)
            strTemp = ""
            strTemp = objBCDBS.ConvertDateBack(strFieldValueFrom1)
            If strTemp <> "" Then
                objDPatronCollection.FieldValueFrom(1) = Left(strTemp, InStr(strTemp, " ") - 1)
            Else
                objDPatronCollection.FieldValueFrom(1) = ""
            End If
            strTemp = ""
            strTemp = objBCDBS.ConvertDateBack(strFieldValueFrom2)
            If strTemp <> "" Then
                objDPatronCollection.FieldValueFrom(2) = Left(strTemp, InStr(strTemp, " ") - 1)
            Else
                objDPatronCollection.FieldValueFrom(2) = ""
            End If
            strTemp = ""
            strTemp = objBCDBS.ConvertDateBack(strFieldValueTo1)
            If strTemp <> "" Then
                objDPatronCollection.FieldValueTo(1) = Left(strTemp, InStr(strTemp, " ") - 1)
            Else
                objDPatronCollection.FieldValueTo(1) = ""
            End If
            strTemp = ""
            strTemp = objBCDBS.ConvertDateBack(strFieldValueTo2)
            If strTemp <> "" Then
                objDPatronCollection.FieldValueTo(2) = Left(strTemp, InStr(strTemp, " ") - 1)
            Else
                objDPatronCollection.FieldValueTo(2) = ""
            End If
            Try
                Dim tblSearch As New DataTable

                tblSearch = objDPatronCollection.Search()
                strSQL = objDPatronCollection.SQL
                If tblSearch.Rows.Count > 0 Then
                    ReDim ArrID(tblSearch.Rows.Count - 1)
                    Dim inti As Integer
                    For inti = 0 To tblSearch.Rows.Count - 1
                        ' Bind Array of PatronID
                        ArrID(inti) = tblSearch.Rows(inti).Item("ID")
                    Next
                    Select Case bytOrderBy
                        Case 0, 1, 2, 3, 4 ' Order in Query SQL
                            ArrRetID = ArrID
                        Case 5, 6 ' First Name,LastName
                            '' must use other Tools (tvcom) to Order
                            'ReDim ArrText(tblSearch.Rows.Count - 1)
                            'For inti = 0 To tblSearch.Rows.Count - 1
                            '    ' Bind Array of Text
                            '    ArrText(inti) = TvFont.Convert("ucs2", "unicode1", tblSearch.Rows(inti).Item(1))
                            'Next
                            'If UBound(ArrID) >= 0 Then
                            '    ' Use tvcom to sort utf8 encode
                            '    ArrIndex = TvSort.SortIndex(ArrText, 1)
                            '    ArrRetID = objBCDBS.SortByIndex(ArrID, ArrIndex)
                            'End If

                            'Comment 2019.05.10
                            'Sap xep
                            'B1
                            'PhuongTT -  2014.11.19
                            'ReDim ArrText(tblSearch.Rows.Count - 1)
                            'For inti = 0 To tblSearch.Rows.Count - 1
                            '    ' Bind Array of Text
                            '    ArrText(inti) = ""
                            '    If Not IsDBNull(tblSearch.Rows(inti).Item(0)) Then
                            '        ArrText(inti) = Trim(tblSearch.Rows(inti).Item(0))
                            '    End If
                            'Next
                            'If UBound(ArrID) >= 0 Then
                            '    ' Use tvcom to sort utf8 encode
                            '    ArrIndex = objBCSP.SortIndexDictionary(ArrText, 1)
                            '    ArrRetID = objBCDBS.SortByIndex(ArrID, ArrIndex)
                            'End If
                            'end comment

                            ArrRetID = ArrID

                            'objBCSP.SortIndexDictionary(,
                            'Dim sortDic As New SortedDictionary(Of String, Integer)
                            'Dim strKey As String = ""
                            'Dim intValue As Integer = 0
                            'For inti = 0 To tblSearch.Rows.Count - 1
                            '    Try
                            '        strKey = ""
                            '        If Not IsDBNull(tblSearch.Rows(inti).Item(inti).Item(1)) Then
                            '            strKey = Trim(tblSearch.Rows(inti).Item(inti).Item(1))
                            '        Else
                            '            'Neu gia tri rong thi sap xep nam o cuoi cung
                            '            strKey &= "z"
                            '        End If
                            '        strKey &= tblSearch.Rows(inti).Item(inti).Item(0)
                            '        intValue = tblSearch.Rows(inti).Item(inti).Item(0)
                            '        sortDic.Add(strKey, intValue)
                            '    Catch ex As Exception
                            '        'pass duplicate record
                            '    End Try
                            'Next
                            'inti = 0
                            'For Each kvp As KeyValuePair(Of String, Integer) In sortDic
                            '    ReDim Preserve ArrRetID(inti)
                            '    ArrRetID(inti) = kvp.Value
                            '    inti += 1
                            'Next
                            'E1
                    End Select
                Else
                    'Not Found
                    ReDim ArrRetID(0)
                    ArrRetID(0) = -1
                End If
                strErrorMsg = objDPatronCollection.ErrorMsg
                intErrorCode = objDPatronCollection.ErrorCode
                Search = ArrRetID
                tblSearch.Clear()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function UpdatePatrons() As Integer
            Try
                objDPatronCollection.PatronIDs = strPatronIDs
                objDPatronCollection.TextFieldIndex = bytTextFieldIndex
                objDPatronCollection.NewTextValue = objBCSP.ConvertItBack(strNewTextValue)
                objDPatronCollection.DateFieldIndex = bytDateFieldIndex
                objDPatronCollection.NewDateValue = objBCDBS.ConvertDateBack(strNewDateValue)
                objDPatronCollection.OptionFieldIndex = bytOptionFieldIndex
                objDPatronCollection.NewOptionID = intNewOptionID
                UpdatePatrons = objDPatronCollection.UpdatePatrons
                strErrorMsg = objDPatronCollection.ErrorMsg
                intErrorCode = objDPatronCollection.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function UpdateBatchPatrons() As Integer
            Try
                objDPatronCollection.PatronIDs = strPatronIDs
                objDPatronCollection.TextFieldIndex = bytTextFieldIndex
                objDPatronCollection.NewTextValue = Replace(Replace(objBCSP.ConvertItBack(strNewTextValue), "''", ""), "'", "")
                objDPatronCollection.DateFieldIndex = bytDateFieldIndex
                Select Case strDBServer
                    Case "ORACLE"
                        objDPatronCollection.NewDateValue = strNewDateValue ' objBCDBS.ConvertDateBack(strNewDateValue)
                    Case Else
                        objDPatronCollection.NewDateValue = objBCDBS.ConvertDateBack(strNewDateValue)
                End Select
                objDPatronCollection.OptionFieldIndex = bytOptionFieldIndex
                objDPatronCollection.NewOptionID = intNewOptionID
                UpdateBatchPatrons = objDPatronCollection.UpdateBatchPatrons
                strErrorMsg = objDPatronCollection.ErrorMsg
                intErrorCode = objDPatronCollection.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function UpdateDic() As Integer
        End Function

        Public Function GetPortraitPatronDel() As DataTable
            Try
                ' Before delete patron in database will delete Portrai on disk
                objDPatronCollection.PatronIDs = strPatronIDs
                GetPortraitPatronDel = objBCDBS.ConvertTable(objDPatronCollection.GetPortraitPatronDel)
                ErrorCode = objDPatronCollection.ErrorCode
                ErrorMsg = objDPatronCollection.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
        End Function

        Public Function DeletePatrons() As DataTable
            Try
                objDPatronCollection.PatronIDs = strPatronIDs
                DeletePatrons = objBCDBS.ConvertTable(objDPatronCollection.DeletePatrons())
                ErrorCode = objDPatronCollection.ErrorCode
                ErrorMsg = objDPatronCollection.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
        End Function

        Public Function ReNew()
            Try
                objDPatronCollection.NewExpiredDate = objBCDBS.ConvertDateBack(strNewExpiredDate)
                objDPatronCollection.Years = intYears
                objDPatronCollection.Months = intMonths
                objDPatronCollection.PatronIDs = strPatronIDs
                If strPatronIDs <> "" Then
                    objDPatronCollection.ReNew()
                End If
                ErrorCode = objDPatronCollection.ErrorCode
                ErrorMsg = objDPatronCollection.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
        End Function

        Public Function Export(ByVal intTempID As Integer, ByVal intTempType As Integer, ByVal intFromID As Integer, ByVal intToID As Integer, ByVal strSeperator As String, ByVal strServerMap As String, ByVal intFileTypeID As Integer) As String
            Dim objPatron()
            Dim intCounter As Integer
            Dim strStreamData As String
            Try
                'If intFileTypeID = 1 Then
                '    strSeperator = ""
                'End If
                TblDataToGen = objBCDBS.ConvertTable(objDPatronCollection.Export(intFromID, intToID))
                ErrorCode = objDPatronCollection.ErrorCode
                ErrorMsg = objDPatronCollection.ErrorMsg
                ' Gen to array data
                objPatron = GenExportData(TblDataToGen, intTempID, intTempType, strSeperator, intFileTypeID)
                'If UBound(objPatron) > 0 Then
                If objPatron.Length > 0 Then
                    For intCounter = 0 To UBound(objPatron)
                        strStreamData = strStreamData & objPatron(intCounter) & vbCrLf
                    Next
                    Export = WriteDataFile(intFileTypeID, strServerMap, strStreamData)
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
        End Function
        Private Function GenExportData(ByVal tblData As DataTable, ByVal intTempID As Integer, ByVal intTempType As Integer, ByVal strSeperator As String, Optional ByVal intFileTypeID As Integer = 0) As Object
            'Dim TvTemp As New TVCOMLib.LibolTemplate
            Dim ArrReturnGen() 'store data after use tvtemplate generate.
            Dim ArrOutBarcode() 'store barcode to print
            Dim ArrDataToBarCode() 'store code to gen barcode
            Dim TblRet As New DataTable ' store content about Template
            Dim ArrField() ' store all field of template
            Dim Data() ' store input for Generate of TvTemplate
            Dim introw As Integer
            Try
                ReDim ArrDataToBarCode(0)
                ArrDataToBarCode(0) = ""
                'strTags = "CODE,CLSS,NAME,DOB,OCUPATION,WORKPLACE,ADDRESS,TELEPHONE,VALIDDATE,EXPIREDDATE,EMAIL,PORTRAIT,BARCODE,ETHNIC,OCCUPATION,COLLEGE,FACULTY,EDUCATIONLEVEL,PATRONGROUPNAME,PROVINCE,GRADE,CLASS,ZIP,NOTE,SEX,MOBILE,LASTISSUEDDATE,LASTMODIFIEDDATE,COUNTRY,FULLNAME,FIRSTNAME,MIDDLENAME,LASTNAME,IDCARD,CITY,ACTIVE,"
                strTags = "CODE,VALIDDATE,EXPIREDDATE,LASTISSUEDDATE,FULLNAME,SEX,DOB,ETHNIC,TELEPHONE,MOBILE,EMAIL,PORTRAIT,GRADE,COLLEGE,OCCUPATION,FACULTY,CLASS,PROVINCE,ADDRESS,CITY,ZIP,ACTIVE,LASTMODIFIEDDATE,EDUCATIONLEVEL,PATRONGROUPNAME,NOTE,FIRSTNAME,LASTNAME,IDCARD,COUNTRY,"

                objBCT.TemplateID = intTempID
                objBCT.TemplateType = intTempType
                TblRet = objBCT.GetTemplate
                If TblRet.Rows.Count > 0 Then
                    'TvTemp.Template = objBCSP.ToUTF8(TblRet.Rows(0).Item("Content"))
                    'ArrField = TvTemp.Fields()
                    Dim strContentTemp As String = TblRet.Rows(0).Item("Content") ' objBCSP.ToUTF8(TblRet.Rows(0).Item("Content"))
                    ArrField = objBCT.getArrayFromTemplate(strContentTemp)
                    ReDim ArrOutBarcode(TblDataToGen.Rows.Count - 1)
                    ReDim ArrDataToBarCode(TblDataToGen.Rows.Count - 1)
                    Dim strContent As String = strContentTemp
                    For introw = 0 To TblDataToGen.Rows.Count - 1
                        If TblDataToGen.Rows.Count > 0 Then
                            ReDim Data(UBound(ArrField))
                            Dim inti As Integer
                            strContent = strContentTemp
                            For inti = 0 To UBound(ArrField)
                                If InStr(strTags, ArrField(inti) & ",") > 0 Then
                                    Data(inti) = ""
                                    Try
                                        Select Case UCase(ArrField(inti))
                                            Case "NAME", "FULLNAME"
                                                If Not IsDBNull(TblDataToGen.Rows(introw).Item("FULLNAME")) Then
                                                    Data(inti) = TblDataToGen.Rows(introw).Item("FULLNAME") & "" 'objBCSP.ToUTF8(TblDataToGen.Rows(introw).Item("FULLNAME") & "")
                                                Else
                                                    Data(inti) = ""
                                                End If
                                            Case "BARCODE"
                                                Data(inti) = "..\Common\WPrintBarCode.aspx?i=" & introw
                                                ArrDataToBarCode(introw) = TblDataToGen.Rows(introw).Item("Code") & ""
                                            Case "PORTRAIT"
                                                If IsDBNull(TblDataToGen.Rows(introw).Item("Portrait")) Then
                                                    Data(inti) = "Images\Card\empty.gif"
                                                Else
                                                    Dim strURL As String = "Images\Card\" & TblDataToGen.Rows(introw).Item("Portrait")
                                                    'Data(inti) = "..\..\Common/ShowPic.aspx?intw=80&inth=120&Url=" & strURL
                                                    Data(inti) = TblDataToGen.Rows(introw).Item("Portrait")

                                                End If
                                            Case Else
                                                If Not IsDBNull(TblDataToGen.Rows(introw).Item("" & ArrField(inti) & "")) Then
                                                    Data(inti) = TblDataToGen.Rows(introw).Item("" & ArrField(inti) & "") & "" 'objBCSP.ToUTF8(TblDataToGen.Rows(introw).Item("" & ArrField(inti) & "") & "")
                                                Else
                                                    Data(inti) = ""
                                                End If
                                        End Select
                                    Catch ex As Exception
                                        Data(inti) = ""
                                    End Try
                                    If Not strSeperator = "" Then
                                        Data(inti) = Data(inti) & strSeperator
                                    End If
                                End If
                                strContent = Replace(strContent, "<$" & ArrField(inti) & "$>", Data(inti))
                            Next ' UBound(ArrField)
                            ReDim Preserve ArrReturnGen(introw)
                            If intFileTypeID = 0 Then 'txt
                                'ArrReturnGen(introw) = objBCSP.ToUTF8Back(TvTemp.Generate(Data))
                                ArrReturnGen(introw) = strContent
                            Else    'xml
                                'ArrReturnGen(introw) = "<DATA>" & vbCrLf & objBCSP.ToUTF8Back(TvTemp.Generate(Data)) & vbCrLf & "</DATA>"
                                ArrReturnGen(introw) = "<DATA>" & vbCrLf & strContent & vbCrLf & "</DATA>"
                            End If
                        End If
                    Next
                    If Not ArrDataToBarCode(0) = "" Then
                        objBCChart.MakeImgBarcode(ArrDataToBarCode, bytTypePic, 1, 50, bytTypeBarcode, "", "", "", intRotate)
                        objDataBarCode = objBCChart.BarCodeImg ' mang cac anh barcode
                    End If
                    objReturnData = ArrReturnGen ' mang cac du lieu tao theo mau
                    ' return data here
                    GenExportData = objReturnData
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                'TvTemp = Nothing
            End Try
        End Function

        Public Function WriteDataFile(ByVal intFileTypeID As Integer, ByVal strServerMap As String, ByVal strData As String) As String
            Dim strFileName, strExtension, strTimeStamp As String
            Dim objDirectory As Directory
            Try
                If intFileTypeID = 0 Then
                    strExtension = ".txt"
                Else
                    strExtension = ".xml"
                    'strData = "<?xml version=""" & "1.0" & """ ?>" & vbCrLf & "<Head>" & vbCrLf & "<DATA>" & vbCrLf & strData & "</DATA>" & vbCrLf & "</Head>"
                    strData = "<?xml version=""" & "1.0" & """ ?>" & vbCrLf & "<Head>" & vbCrLf & strData & vbCrLf & "</Head>"
                End If
                ' Map path
                If Not objDirectory.Exists(strServerMap & "\Attach") Then
                    objDirectory.CreateDirectory(strServerMap & "\Attach")
                End If
                If Not objDirectory.Exists(strServerMap & "\Attach\Data") Then
                    objDirectory.CreateDirectory(strServerMap & "\Attach\Data")
                End If
                strServerMap = strServerMap & "\Attach\Data\"
                strTimeStamp = CStr(Year(Now)) & CStr(Day(Now)).PadLeft(2, "0") & CStr(Month(Now)).PadLeft(2, "0") & CStr(Hour(Now)).PadLeft(2, "0") & CStr(Minute(Now)).PadLeft(2, "0") & CStr(Second(Now)).PadLeft(2, "0")
                ' sau se su dung phan nay
                'Dim tblTemp As DataTable
                'tblTemp = objBCDBS.GetTempFilePath(1)
                'If Not tblTemp Is Nothing Then
                '    If tblTemp.Rows.Count > 0 Then
                '        strFileName = tblTemp.Rows(0).Item("TempFilePath") & strTimeStamp & strExtension
                '    End If
                'End If
                strFileName = strServerMap & strTimeStamp & strExtension ' va bo cai nay di
                Dim fsData As New FileStream(strFileName, FileMode.OpenOrCreate)
                Dim fwData As New StreamWriter(fsData)
                fwData.Write(strData)
                fwData.Close()
                ' Sondp comment  
                ' WriteDataFile =strFileName -- strTimeStamp & strExtension
                WriteDataFile = strFileName
                fsData = Nothing
                fwData = Nothing
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function Import(ByVal intFromID As Integer, ByVal intToID As Integer)
            Try
                Import = objBCDBS.ConvertTable(objDPatronCollection.Import(intFromID, intToID))
                ErrorCode = objDPatronCollection.ErrorCode
                ErrorMsg = objDPatronCollection.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
        End Function

        Public Function GenerateCards(ByVal strContent As String, ByVal collecContent As Collection) As String
            'Dim objTemplate As New TVCOMLib.LibolTemplate
            Dim Fields As New Object
            Dim Data() As Object
            Dim inti As Integer
            ReDim Data(0)
            Try
                'objTemplate.Template = objBCSP.ToUTF8(strContent)
                'Fields = objTemplate.Fields
                Dim strContentTemp As String = strContent 'objBCSP.ToUTF8(strContent)
                Fields = objBCT.getArrayFromTemplate(strContentTemp)
                ReDim Data(UBound(Fields))
                For inti = LBound(Fields) To UBound(Fields)
                    Select Case UCase(Fields(inti))
                        Case "BARCODE"
                            Dim ArrRet As Object
                            Dim ArrStrData(0) As String
                            ArrStrData(0) = collecContent.Item("BARCODE")
                            objBCChart.MakeImgBarcode(ArrStrData, 3, 1, 50, 6, "", "", "", 0)
                        Case Else
                    End Select
                Next
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                'objTemplate = Nothing
            End Try
        End Function

        Public Function GenerateExImportTemplate(ByVal strContent As String, ByVal collecContent As Collection) As String
            'Dim objTemplate As New TVCOMLib.LibolTemplate
            Dim Fields As New Object
            Dim objData() As Object
            Dim objStream As New Object
            Dim inti As Integer
            ReDim objData(0)
            objStream = Nothing
            'objTemplate.Template = objBCSP.ToUTF8(strContent.Replace("&lt;", "<").Replace("&gt;", ">"))
            'Fields = objTemplate.Fields
            Dim strContentTemp As String = strContent.Replace("&lt;", "<").Replace("&gt;", ">")
            Fields = objBCT.getArrayFromTemplate(strContentTemp)
            ReDim objData(UBound(Fields))
            For inti = LBound(Fields) To UBound(Fields)
                Try
                    objData(inti) = collecContent.Item(UCase(Fields(inti)))
                Catch ex As Exception
                    objData(inti) = " "
                End Try
                strContentTemp = Replace(strContentTemp, "<$" & Fields(inti) & "$>", objData(inti))
            Next
            'objStream = objBCSP.ToUTF8Back(objTemplate.Generate(objData).ToString)
            objStream = strContentTemp
            GenerateExImportTemplate = objStream
            'objTemplate = Nothing
            collecContent = Nothing
        End Function

        Public Function GetPatronGroup() As DataTable
            Try
                GetPatronGroup = objBCDBS.ConvertTable(objDPatronCollection.GetPatronGroup)
                strErrorMsg = objDPatronCollection.ErrorMsg
                intErrorCode = objDPatronCollection.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetCardNotPrinted(ByVal strID As String) As DataTable
            Try
                GetCardNotPrinted = objBCDBS.ConvertTable(objDPatronCollection.GetCardNotPrinted(strID))
                strErrorMsg = objDPatronCollection.ErrorMsg
                intErrorCode = objDPatronCollection.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetCardPrinted(ByVal strIDs As String, Optional ByVal selectTop As Integer = 0) As DataTable
            Try
                GetCardPrinted = objBCDBS.ConvertTable(objDPatronCollection.GetCardPrinted(strIDs, selectTop))
                strErrorMsg = objDPatronCollection.ErrorMsg
                intErrorCode = objDPatronCollection.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Sub InsertPatronPrintCard(ByVal strPatronIDs As String, ByVal intTemplateID As Integer, ByVal intIssueLibraryID As Integer)
            Try
                objDPatronCollection.InsertPatronPrintCard(strPatronIDs, intTemplateID, intIssueLibraryID)
                strErrorMsg = objDPatronCollection.ErrorMsg
                intErrorCode = objDPatronCollection.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Retrieve from all dictionary table
        ' Output: Datatable
        Public Function RetrieveDicTable() As DataTable
            Try
                RetrieveDicTable = objBCDBS.ConvertTable(objDPatronCollection.RetrieveDicTable)
                strErrorMsg = objDPatronCollection.ErrorMsg
                intErrorCode = objDPatronCollection.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function
        Private Function ImportFaculty(ByVal intCollegeID As Integer, ByVal strFaculty As String) As Integer
            Try
                objBF.Faculty = strFaculty
                objBF.CollegeID = intCollegeID
                ImportFaculty = objBF.Create
                strErrorMsg = objBPro.ErrorMsg
                intErrorCode = objBPro.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' ImportProvince method
        Private Function ImportProvince(ByVal strProvince As String) As Integer
            Try
                objBPro.Province = strProvince
                ImportProvince = objBPro.ImportProvince
                strErrorMsg = objBPro.ErrorMsg
                intErrorCode = objBPro.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Private Function ImportCountry(ByVal strCountry As String) As Integer
            Dim tblCountry As New DataTable
            Dim dtrows() As DataRow
            Dim dtrow As DataRow
            Try
                tblCountry = objDPatronCollection.GetCountry()
                If Not tblCountry Is Nothing Then
                    If tblCountry.Rows.Count > 0 Then
                        dtrows = tblCountry.Select("DisplayEntry=" & strCountry)
                        If dtrows.Length > 0 Then
                            For Each dtrow In dtrows
                                ImportCountry = dtrow.Item("ID")
                            Next
                        Else
                            ' Default Viet Nam
                            dtrows = tblCountry.Select("ISOCode='vn'")
                            For Each dtrow In dtrows
                                ImportCountry = dtrow.Item("ID")
                            Next
                        End If
                    End If
                End If
            Catch ex As Exception
                strErrorMsg = objBPro.ErrorMsg
                intErrorCode = objBPro.ErrorCode
            End Try
        End Function

        Private Function ImportEducation(ByVal strEducationLevel As String) As Integer
            Try
                ImportEducation = objDPatronCollection.ImportEducation(strEducationLevel)
            Catch ex As Exception
                strErrorMsg = objDPatronCollection.ErrorMsg
                intErrorCode = objDPatronCollection.ErrorCode
            End Try
        End Function

        Private Function ImportOccupation(ByVal strImportOccupation As String) As Integer
            Try
                ImportOccupation = objBO.ImportOccupation(strImportOccupation)
                strErrorMsg = objDPatronCollection.ErrorMsg
                intErrorCode = objDPatronCollection.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Private Function ImportEthnic(ByVal strImportEthnic As String) As Integer
            Try
                ImportEthnic = objBE.ImportEthnic(strImportEthnic)
                strErrorMsg = objBE.ErrorMsg
                intErrorCode = objBE.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Private Function ImportCollege(ByVal strImportCollege As String) As Integer
            Try
                ImportCollege = objBC.ImportCollect(strImportCollege)
                strErrorMsg = objBC.ErrorMsg
                intErrorCode = objBC.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Private Function ImportPatronGroup(ByVal strImportPatronGroupName As String) As Integer
            Try
                ImportPatronGroup = objBPG.ImportPatronGroup(strImportPatronGroupName)
                strErrorMsg = objBPG.ErrorMsg
                intErrorCode = objBPG.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetTotalPatrons() As DataTable
            Try
                objDPatronCollection.LibID = intLibID
                GetTotalPatrons = objDPatronCollection.GetTotalPatrons
                strErrorMsg = objBPG.ErrorMsg
                intErrorCode = objBPG.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose: ImportFromXMLFile
        Public Function ImportFromXMLFile(ByVal strFileName As String, Optional ByVal strhdValidDate As String = "", Optional ByVal strhdExpiredDate As String = "", Optional ByVal strhdLastModifiedDate As String = "", Optional ByVal strhdPatronGroupID As String = "", Optional ByVal boolOverwrite As Boolean = False) As Long
            ' Declare variables for Patron's objects
            Dim lngReturnValue As Long = 0
            Dim ArrName() As String
            Dim strCode As String = ""
            Dim strFullName As String
            Dim strFirstName As String = ""
            Dim strMiddleName As String = ""
            Dim strLastName As String = ""
            Dim strValidDate As String = ""
            Dim strExpiredDate As String = ""
            Dim strLastIssuedDate As String = ""
            Dim boolSex As Boolean = False
            Dim strDOB As String = ""
            Dim strWorkPlace As String = ""
            Dim strTelephone As String = ""
            Dim strMobile As String = ""
            Dim strEmail As String = ""
            Dim strPortrait As String = ""
            Dim strPassword As String = ""
            Dim intStatus As Integer
            Dim strNote As String = ""
            Dim curDebt As Decimal
            Dim strLastModifiedDate As String = ""
            Dim intPatronID As Integer

            Dim strCountry As String = ""
            Dim strFaculty As String = ""
            Dim strCollege As String = ""
            Dim strPatronGroupName As String = ""

            Dim intPatronGroupID As Integer
            Dim intProvinceID As Integer
            Dim intCountryID As Integer
            Dim intEthnicID As Integer
            Dim intEducationID As Integer
            Dim intOccupationID As Integer
            Dim intCollegeID As Integer
            Dim intFacultyID As Integer

            Dim strGrade As String = ""
            Dim strClass As String = ""
            Dim strAddress As String = ""
            Dim strAddressCPOA As String = ""
            Dim strCity As String = ""
            Dim strZip As String = ""
            Dim strIDCard As String = ""

            Dim cltField As New Collection ' Collection of (FieldName, TagName-Key)
            Dim doc As New XmlDocument
            Dim ds As New DataSet
            Dim dtlData As New DataTable
            Dim tblFormat As New DataTable
            Dim intRowIndex As Integer
            Dim intColIndex, intj As Integer
            Dim strFormat As String
            Dim strTempo As String
            Dim strTags As String = ""
            Dim intIndex As Integer
            Dim lngTempID As Long

            Dim boolExist As Boolean = False
            Dim tblCheck As New DataTable
            Dim dtrow As DataRow

            tblExistPatron.Columns.Add("STT", GetType(System.Int16))
            tblExistPatron.Columns.Add("FullName", GetType(System.String))
            tblExistPatron.Columns.Add("Code", GetType(System.String))
            tblExistPatron.Columns.Add("DOB", GetType(System.String))
            tblExistPatron.Columns.Add("IDCard", GetType(System.String))
            ' Read import format from Database
            objBCT.TemplateID = intTemplateID
            objBCT.TemplateType = intTemplateType
            tblFormat = objBCT.GetTemplate
            strFormat = tblFormat.Rows(0).Item("Content")
            strFormat = Replace(strFormat, "<$", "")
            strFormat = Replace(strFormat, "$>", "")
            doc.LoadXml(strFormat)
            Dim rdFormat As New XmlNodeReader(doc)
            ds.ReadXml(rdFormat)
            rdFormat.Close()
            tblFormat = ds.Tables(0)
            ImportFromXMLFile = 0
            For intColIndex = 0 To tblFormat.Columns.Count - 1
                cltField.Add(Trim(tblFormat.Rows(0).Item(intColIndex)), tblFormat.Columns(intColIndex).ColumnName)
                strTags = strTags & Trim(tblFormat.Rows(0).Item(intColIndex)) & ", "
            Next
            ' Read import data from XML File
            doc.Load(strFileName)
            Dim rdData As New XmlNodeReader(doc)
            ds.ReadXml(rdData)
            rdData.Close()
            dtlData = ds.Tables(0)
            If dtlData.Rows.Count >= 1 Then ' have atlease one record
                For intRowIndex = 0 To dtlData.Rows.Count - 1
                    For intColIndex = 0 To dtlData.Columns.Count - 1
                        'Try
                        If InStr(strTags, Trim(dtlData.Columns(intColIndex).ColumnName) & ", ") > 0 Then
                            Select Case UCase(cltField(dtlData.Columns(intColIndex).ColumnName))
                                Case "CODE"
                                    strCode = Trim(dtlData.Rows(intRowIndex).Item(intColIndex))
                                Case "FIRSTNAME"
                                    strFirstName = Trim(dtlData.Rows(intRowIndex).Item(intColIndex))
                                Case "MIDDLENAME"
                                    strMiddleName = Trim(dtlData.Rows(intRowIndex).Item(intColIndex))
                                Case "LASTNAME"
                                    strLastName = Trim(dtlData.Rows(intRowIndex).Item(intColIndex))
                                Case "FULLNAME"
                                    strFullName = dtlData.Rows(intRowIndex).Item(intColIndex).ToString.Trim
                                    If Not strFullName = "" Then
                                        strFullName = Replace(strFullName, "  ", " ")
                                        ArrName = Split(strFullName, " ")
                                        If UBound(ArrName) > 1 Then
                                            strFirstName = Trim(ArrName(0))
                                            strMiddleName = ""
                                            For intIndex = 1 To UBound(ArrName) - 1
                                                strMiddleName = strMiddleName & " " & ArrName(intIndex)
                                            Next
                                            strMiddleName = Trim(strMiddleName)
                                            strLastName = Trim(ArrName(UBound(ArrName)))
                                        ElseIf UBound(ArrName) = 1 Then
                                            strFirstName = Trim(ArrName(0))
                                            strLastName = Trim(ArrName(UBound(ArrName)))
                                        End If
                                    End If
                                Case "SEX"
                                    boolSex = CBool(Trim(dtlData.Rows(intRowIndex).Item(intColIndex)))
                                Case "LASTISSUEDDATE"
                                    If strhdValidDate <> "" Then
                                        strLastIssuedDate = strhdValidDate
                                    Else
                                        strLastIssuedDate = Trim(dtlData.Rows(intRowIndex).Item(intColIndex))
                                    End If
                                    'strValidDate = Trim(dtlData.Rows(intRowIndex).Item(intColIndex))
                                Case "EXPIREDDATE"
                                    If strhdExpiredDate <> "" Then
                                        strExpiredDate = strhdExpiredDate
                                    Else
                                        strExpiredDate = Trim(dtlData.Rows(intRowIndex).Item(intColIndex))
                                    End If
                                    'strExpiredDate = Trim(dtlData.Rows(intRowIndex).Item(intColIndex))
                                Case "DOB"
                                    strDOB = Trim(dtlData.Rows(intRowIndex).Item(intColIndex))
                                Case "LASTMODIFIEDDATE"
                                    If strhdLastModifiedDate <> "" Then
                                        strLastModifiedDate = strhdLastModifiedDate
                                    Else
                                        strLastModifiedDate = Trim(dtlData.Rows(intRowIndex).Item(intColIndex))
                                    End If
                                    'strLastModifiedDate = Trim(dtlData.Rows(intRowIndex).Item(intColIndex))
                                Case "VALIDDATE"
                                    strValidDate = Trim(dtlData.Rows(intRowIndex).Item(intColIndex))
                                Case "WORKPLACE"
                                    strWorkPlace = Trim(dtlData.Rows(intRowIndex).Item(intColIndex))
                                Case "TELEPHONE"
                                    strTelephone = Trim(dtlData.Rows(intRowIndex).Item(intColIndex))
                                Case "MOBILE"
                                    strMobile = Trim(dtlData.Rows(intRowIndex).Item(intColIndex))
                                Case "EMAIL"
                                    strEmail = Trim(dtlData.Rows(intRowIndex).Item(intColIndex))
                                Case "PORTRAIT"
                                    strPortrait = Trim(dtlData.Rows(intRowIndex).Item(intColIndex))
                                Case "PASSWORD"
                                    strPassword = Trim(dtlData.Rows(intRowIndex).Item(intColIndex))
                                Case "NOTE"
                                    strNote = Trim(dtlData.Rows(intRowIndex).Item(intColIndex))
                                Case "PROVINCE"
                                    intProvinceID = ImportProvince(Trim(dtlData.Rows(intRowIndex).Item(intColIndex)))
                                Case "COUNTRY"
                                    intCountryID = ImportCountry(Trim(dtlData.Rows(intRowIndex).Item(intColIndex)))
                                Case "ADDRESS"
                                    strAddress = Trim(dtlData.Rows(intRowIndex).Item(intColIndex))
                                Case "CITY"
                                    strCity = Trim(dtlData.Rows(intRowIndex).Item(intColIndex))
                                Case "ZIP"
                                    strZip = Trim(dtlData.Rows(intRowIndex).Item(intColIndex))
                                Case "EDUCATIONLEVEL"
                                    intEducationID = ImportEducation(Trim(dtlData.Rows(intRowIndex).Item(intColIndex)))
                                Case "OCCUPATION"
                                    intOccupationID = ImportOccupation(Trim(dtlData.Rows(intRowIndex).Item(intColIndex)))
                                Case "ETHNIC"
                                    intEthnicID = ImportEthnic(Trim(dtlData.Rows(intRowIndex).Item(intColIndex)))
                                Case "COLLEGE"
                                    intCollegeID = ImportCollege(Trim(dtlData.Rows(intRowIndex).Item(intColIndex)))
                                Case "FACULTY"
                                    'strFaculty = Trim(dtlData.Rows(intRowIndex).Item(intColIndex))
                                    intFacultyID = ImportFaculty(intCollegeID, Trim(dtlData.Rows(intRowIndex).Item(intColIndex)))
                                Case "GRADE"
                                    strGrade = Trim(dtlData.Rows(intRowIndex).Item(intColIndex))
                                Case "CLASS"
                                    strClass = Trim(dtlData.Rows(intRowIndex).Item(intColIndex))
                                Case "PATRONGROUPNAME"
                                    If CInt(strhdPatronGroupID) > 0 Then
                                        intPatronGroupID = CInt(strhdPatronGroupID)
                                    Else
                                        intPatronGroupID = ImportPatronGroup(Trim(dtlData.Rows(intRowIndex).Item(intColIndex)))
                                    End If
                                    'intPatronGroupID = ImportPatronGroup(Trim(dtlData.Rows(intRowIndex).Item(intColIndex)))
                                Case "IDCARD"
                                    strIDCard = Trim(dtlData.Rows(intRowIndex).Item(intColIndex))
                            End Select
                        End If
                        'Catch ex As Exception
                        'End Try
                    Next
                    boolExist = False
                    ' Before insert check exist
                    If Not boolOverwrite Then
                        ' Check exist before insert
                        objBP.Code = strCode
                        objBP.DOB = strDOB
                        objBP.IDCard = strIDCard
                        tblCheck = objBP.CheckExistPatron
                        If Not tblCheck Is Nothing Then
                            If tblCheck.Rows.Count > 0 Then
                                boolExist = True
                                dtrow = tblExistPatron.NewRow
                                dtrow.Item("STT") = "1"
                                dtrow.Item("FullName") = strFirstName & " " & strMiddleName & " " & strLastName
                                dtrow.Item("Code") = strCode
                                dtrow.Item("DOB") = strDOB
                                dtrow.Item("IDCard") = strIDCard
                                tblExistPatron.Rows.Add(dtrow)
                            End If
                        End If
                    End If
                    ' Assign properties's value for objPatron
                    ' Fields must have value
                    If Not boolExist Then ' Don't exist
                        objBP.Code = strCode
                        objBP.FirstName = strFirstName
                        objBP.MiddleName = strMiddleName
                        objBP.LastName = strLastName
                        If IsDBNull(boolSex) Then
                            objBP.Sex = False ' default
                        Else
                            objBP.Sex = boolSex
                        End If
                        If strLastIssuedDate = "" Then
                            objBP.LastIssuedDate = Day(Now) & "/" & Month(Now) & "/" & Year(Now) ' default now
                        Else
                            objBP.LastIssuedDate = strLastIssuedDate
                        End If
                        If strExpiredDate = "" Then
                            objBP.ExpiredDate = Day(Now) & "/" & Month(Now) & "/" & CStr(CInt(Year(Now)) + 4) ' default
                        Else
                            objBP.ExpiredDate = strExpiredDate
                        End If
                        If intPatronGroupID = 0 Then
                            objBP.PatronGroupID = 1 ' default
                        Else
                            objBP.PatronGroupID = intPatronGroupID
                        End If
                        objBP.Debt = 0
                        If strLastModifiedDate = "" Then
                            objBP.LastModifiedDate = Day(Now) & "/" & Month(Now) & "/" & Year(Now) ' default now
                        Else
                            objBP.LastModifiedDate = strLastModifiedDate
                        End If
                        ' End fields must have value
                        objBP.DOB = strDOB
                        objBP.ValidDate = strValidDate
                        objBP.WorkPlace = strWorkPlace
                        objBP.Telephone = strTelephone
                        objBP.Mobile = strMobile
                        objBP.Email = strEmail
                        objBP.Portrait = strPortrait
                        objBP.Password = strPassword
                        objBP.Note = strNote
                        objBP.IDCard = strIDCard
                        objBP.ProvinceIDCPOA = intProvinceID
                        objBP.CountryIDCPOA = intProvinceID
                        objBP.AddressCPOA = strAddress
                        objBP.CityCPOA = strCity
                        objBP.ZipCPOA = strZip
                        objBP.Active = 1
                        objBP.EducationID = intEducationID
                        objBP.OccupationID = intOccupationID
                        objBP.EthnicID = intEthnicID
                        If Not strGrade = "" Or Not strClass = "" Or Not intCollegeID = 0 Or Not intFacultyID = 0 Then
                            objBP.CollegeIDCPU = intCollegeID
                            objBP.FacultyIDCPU = intFacultyID
                            objBP.GradeCPU = strGrade
                            objBP.ClassCPU = strClass
                        End If
                        Try
                            If boolOverwrite Then ' Update
                                ' Get PatronID from PatronCode to update patron record
                                objBP.PatronID = objBP.GetPatronIDFromCode.Rows(0).Item(0)
                                lngTempID = objBP.Update
                            Else ' Create new
                                lngTempID = objBP.Create()
                            End If
                            If objBP.ErrorMsg & "" <> "" Then
                                strErrorMsg = objBP.ErrorMsg & "$"
                                intErrorCode = objBP.ErrorCode
                            End If
                            If lngTempID > 0 Then
                                ImportFromXMLFile = ImportFromXMLFile + 1
                                lngReturnValue = lngTempID
                            End If
                        Catch ex As Exception
                            strErrorMsg &= ex.Message & "$"
                        Finally
                            ' Reset default value
                            strCode = ""
                            strFirstName = ""
                            strMiddleName = ""
                            strLastName = ""
                            strValidDate = ""
                            strExpiredDate = ""
                            strDOB = ""
                            strLastModifiedDate = ""
                            strLastIssuedDate = ""
                            strWorkPlace = ""
                            strTelephone = ""
                            strMobile = ""
                            strEmail = ""
                            strPortrait = ""
                            strPassword = ""
                            strNote = ""
                            strIDCard = ""
                            intProvinceID = 0
                            intProvinceID = 0
                            strAddress = ""
                            strCity = ""
                            strZip = ""
                            intEducationID = 0
                            intOccupationID = 0
                            intEthnicID = 0
                            intCollegeID = 0
                            intFacultyID = 0
                            strGrade = ""
                            strClass = ""
                            intPatronGroupID = 0
                        End Try
                    End If
                Next
            End If
            tblFormat.Dispose()
            dtlData.Dispose()
            ds.Dispose()
            'If Len(strErrorMsg) < 2 Then
            '    ImportFromXMLFile = 1 ' Successful (100%)
            'Else
            '    ImportFromXMLFile = 0 ' UnSuccessful (<100%)
            'End If
        End Function

        ' Import current patron
        Public Function ImportDataFromText(ByVal strCurrentLine As String, Optional ByVal strhdValidDate As String = "", Optional ByVal strhdExpiredDate As String = "", Optional ByVal strhdLastModifiedDate As String = "", Optional ByVal strhdPatronGroupID As String = "", Optional ByVal boolOverwrite As Boolean = False) As Integer
            ' Declare variables
            Dim intReturnValue As Integer = 0
            Dim arrData() ' store input for Generate of tvTemplatelate
            Dim strCode As String = ""
            Dim strFirstName As String = ""
            Dim strMiddleName As String = ""
            Dim strLastName As String = ""
            Dim strValidDate As String = ""
            Dim strExpiredDate As String = ""
            Dim strLastIssuedDate As String = ""
            Dim boolSex As Boolean = False
            Dim strDOB As String = ""
            Dim strWorkPlace As String = ""
            Dim strTelephone As String = ""
            Dim strMobile As String = ""
            Dim strEmail As String = ""
            Dim strPortrait As String = ""
            Dim strPassword As String = ""
            Dim intStatus As Integer
            Dim strNote As String = ""
            Dim strIDCard As String = ""
            Dim curDebt As Decimal
            Dim strLastModifiedDate As String = ""
            Dim intPatronID As Integer

            Dim strCountry As String = ""
            Dim strFaculty As String = ""
            Dim strCollege As String = ""
            Dim strPatronGroupName As String = ""

            Dim intPatronGroupID As Integer
            Dim intProvinceID As Integer
            Dim intCountryID As Integer
            Dim intEthnicID As Integer
            Dim intEducationID As Integer
            Dim intOccupationID As Integer
            Dim intCollegeID As Integer
            Dim intFacultyID As Integer

            Dim strGrade As String = ""
            Dim strClass As String = ""
            Dim strAddress As String = ""
            Dim strCity As String = ""
            Dim strZip As String = ""

            Dim ArrarrData()
            Dim ArrName() As String
            Dim strFullName As String
            Dim intIndex As Integer
            Dim inti, intj As Integer
            Dim boolExist As Boolean = False

            Dim tblCheck As New DataTable
            Dim dtrow As DataRow
            ' process one line 
            arrData = Split(strCurrentLine, strSeperator)
            If UBound(arrData) > 0 Then
                For inti = 0 To UBound(arrField)
                    If InStr(strTags, arrField(inti) & ",") > 0 Then
                        Select Case UCase(arrField(inti))
                            Case "CODE"
                                strCode = Trim(arrData(inti))
                            Case "FIRSTNAME"
                                strFirstName = Trim(arrData(inti))
                            Case "MIDDLENAME"
                                strMiddleName = Trim(arrData(inti))
                            Case "LASTNAME"
                                strLastName = Trim(arrData(inti))
                            Case "FULLNAME"
                                strFullName = Trim(arrData(inti))
                                strFullName = Replace(strFullName, "  ", " ")
                                ArrName = Split(strFullName, " ")
                                If UBound(ArrName) > 1 Then
                                    strFirstName = Trim(ArrName(0))
                                    strMiddleName = ""
                                    For intIndex = 1 To UBound(ArrName) - 1
                                        strMiddleName = strMiddleName & " " & ArrName(intIndex)
                                    Next
                                    strMiddleName = Trim(strMiddleName)
                                    strLastName = Trim(ArrName(UBound(ArrName)))
                                ElseIf UBound(ArrName) = 1 Then
                                    strFirstName = Trim(ArrName(0))
                                    strLastName = Trim(ArrName(UBound(ArrName)))
                                End If
                            Case "SEX"
                                boolSex = CBool(Trim(arrData(inti)))
                            Case "LASTISSUEDDATE"
                                If strhdValidDate <> "" Then
                                    strLastIssuedDate = strhdValidDate
                                Else
                                    strLastIssuedDate = Trim(arrData(inti))
                                End If
                                'strValidDate = Trim(arrData(inti))
                            Case "EXPIREDDATE"
                                If strhdExpiredDate <> "" Then
                                    strExpiredDate = strhdExpiredDate
                                Else
                                    strExpiredDate = Trim(arrData(inti))
                                End If
                                'strExpiredDate = Trim(arrData(inti))
                            Case "DOB"
                                strDOB = Trim(arrData(inti))
                            Case "LASTMODIFIEDDATE"
                                If strhdLastModifiedDate <> "" Then
                                    strLastModifiedDate = strhdLastModifiedDate
                                Else
                                    strLastModifiedDate = Trim(arrData(inti))
                                End If
                                'strLastModifiedDate = Trim(arrData(inti))
                            Case "VALIDDATE"
                                strValidDate = Trim(arrData(inti))
                            Case "WORKPLACE"
                                strWorkPlace = Trim(arrData(inti))
                            Case "TELEPHONE"
                                strTelephone = Trim(arrData(inti))
                            Case "MOBILE"
                                strMobile = Trim(arrData(inti))
                            Case "EMAIL"
                                strEmail = Trim(arrData(inti))
                            Case "PORTRAIT"
                                strPortrait = Trim(arrData(inti))
                            Case "PASSWORD"
                                strPassword = Trim(arrData(inti))
                            Case "NOTE"
                                strNote = Trim(arrData(inti))
                            Case "PROVINCE"
                                intProvinceID = ImportProvince(Trim(arrData(inti)))
                            Case "COUNTRY"
                                intCountryID = ImportCountry(Trim(arrData(inti)))
                            Case "ADDRESS"
                                strAddress = Trim(arrData(inti))
                            Case "CITY"
                                strCity = Trim(arrData(inti))
                            Case "ZIP"
                                strZip = Trim(arrData(inti))
                            Case "EDUCATIONLEVEL"
                                intEducationID = ImportEducation(Trim(arrData(inti)))
                            Case "OCCUPATION"
                                intOccupationID = ImportOccupation(Trim(arrData(inti)))
                            Case "ETHNIC"
                                intEthnicID = ImportEthnic(Trim(arrData(inti)))
                            Case "COLLEGE"
                                intCollegeID = ImportCollege(Trim(arrData(inti)))
                            Case "FACULTY"
                                'strFaculty = Trim(arrData(inti))
                                intFacultyID = ImportFaculty(intCollegeID, Trim(arrData(inti)))
                            Case "GRADE"
                                strGrade = Trim(arrData(inti))
                            Case "CLASS"
                                strClass = Trim(arrData(inti))
                            Case "PATRONGROUPNAME"
                                If CInt(strhdPatronGroupID) > 0 Then
                                    intPatronGroupID = CInt(strhdPatronGroupID)
                                Else
                                    intPatronGroupID = ImportPatronGroup(Trim(arrData(inti)))
                                End If
                                'intPatronGroupID = ImportPatronGroup(Trim(arrData(inti)))
                            Case "IDCARD"
                                strIDCard = Trim(arrData(inti))
                        End Select
                    End If
                Next
                Try
                    If Not boolOverwrite Then
                        ' Check exist before insert
                        objBP.Code = strCode
                        objBP.DOB = strDOB
                        objBP.IDCard = strIDCard
                        tblCheck = objBP.CheckExistPatron
                        If Not tblCheck Is Nothing Then
                            ' Return this patron
                            If tblCheck.Rows.Count > 0 Then
                                boolExist = True
                                dtrow = tblExistPatron.NewRow
                                dtrow.Item("STT") = "0"
                                dtrow.Item("FullName") = strFirstName & " " & strMiddleName & " " & strLastName
                                dtrow.Item("Code") = strCode
                                dtrow.Item("DOB") = strDOB
                                dtrow.Item("IDCard") = strIDCard
                                tblExistPatron.Rows.Add(dtrow)
                            End If
                        End If
                    End If
                    If Not boolExist Then ' Don't exist
                        ' Assign properties's value for objPatron
                        ' Fields must have
                        objBP.Code = strCode
                        objBP.FirstName = strFirstName
                        objBP.MiddleName = strMiddleName
                        objBP.LastName = strLastName
                        If IsDBNull(boolSex) Then
                            objBP.Sex = False ' default
                        Else
                            objBP.Sex = boolSex
                        End If
                        If strLastIssuedDate = "" Then
                            objBP.LastIssuedDate = Day(Now) & "/" & Month(Now) & "/" & Year(Now) ' default now
                        Else
                            objBP.LastIssuedDate = strLastIssuedDate
                        End If
                        If strExpiredDate = "" Then
                            objBP.ExpiredDate = Day(Now) & "/" & Month(Now) & "/" & CStr(CInt(Year(Now)) + 4) ' default
                        Else
                            objBP.ExpiredDate = strExpiredDate
                        End If
                        If intPatronGroupID = 0 Then
                            objBP.PatronGroupID = 1 ' default
                        Else
                            objBP.PatronGroupID = intPatronGroupID
                        End If
                        If strLastModifiedDate = "" Then
                            objBP.LastModifiedDate = Day(Now) & "/" & Month(Now) & "/" & Year(Now) ' default now
                        Else
                            objBP.LastModifiedDate = strLastModifiedDate
                        End If
                        objBP.Debt = 0
                        ' End fields must have
                        objBP.DOB = strDOB
                        objBP.ValidDate = strValidDate
                        objBP.WorkPlace = strWorkPlace
                        objBP.Telephone = strTelephone
                        objBP.Mobile = strMobile
                        objBP.Email = strEmail
                        objBP.Portrait = strPortrait
                        objBP.Password = strPassword
                        objBP.Note = strNote
                        objBP.IDCard = strIDCard
                        objBP.ProvinceIDCPOA = intProvinceID
                        objBP.CountryIDCPOA = intCountryID
                        objBP.AddressCPOA = strAddress
                        objBP.CityCPOA = strCity
                        objBP.ZipCPOA = strZip
                        objBP.Active = 1
                        Dim strOtherAddress As String
                        strOtherAddress = "$&" & strAddress & "$&" & strCity & "$&" & intProvinceID & "$&" & intCountryID & "$&" & strZip & "$&1##"
                        objBP.AddressInfor = strOtherAddress
                        objBP.EducationID = intEducationID
                        objBP.OccupationID = intOccupationID
                        objBP.EthnicID = intEthnicID
                        objBP.CollegeIDCPU = intCollegeID
                        objBP.FacultyIDCPU = intFacultyID
                        objBP.GradeCPU = strGrade
                        objBP.ClassCPU = strClass
                        If boolOverwrite Then ' Update
                            ' Get PatronID from PatronCode to update patron record
                            objBP.PatronID = objBP.GetPatronIDFromCode.Rows(0).Item(0)
                            intReturnValue = objBP.Update
                        Else ' Create new
                            intReturnValue = objBP.Create
                        End If

                        If objBP.ErrorMsg & "" <> "" Then
                            strErrorMsg &= objBP.ErrorMsg & "$"
                            intErrorCode = objBP.ErrorCode
                        End If
                    End If
                Catch ex As Exception
                    strErrorMsg &= ex.Message & "$"
                End Try
            End If
            ImportDataFromText = intReturnValue
        End Function

        Public Function ImportFromXMLFile1(ByVal FileName As String, Optional ByVal strhdValidDate As String = "", Optional ByVal strhdExpiredDate As String = "", Optional ByVal strhdLastModifiedDate As String = "", Optional ByVal strhdPatronGroupID As String = "", Optional ByVal boolOverwrite As Boolean = False) As Integer
            Dim intTemp As Integer
            Dim srText As StreamReader = New StreamReader(FileName)
            Dim tblRet As New DataTable
            'Dim tvTemplate As New TVCOMLib.LibolTemplate
            Dim strLine As String
            Dim doc As New XmlDocument
            Dim ds As New DataSet
            Dim dtlData As New DataTable
            Dim intRowIndex As Integer

            tblExistPatron.Columns.Add("STT", GetType(System.Int16))
            tblExistPatron.Columns.Add("FullName", GetType(System.String))
            tblExistPatron.Columns.Add("Code", GetType(System.String))
            tblExistPatron.Columns.Add("DOB", GetType(System.String))
            tblExistPatron.Columns.Add("IDCard", GetType(System.String))
            objBCT.TemplateID = intTemplateID
            objBCT.TemplateType = intTemplateType
            tblRet = objBCT.GetTemplate
            ImportFromXMLFile1 = tblRet.Rows.Count
            'tvTemplate.Template = objBCSP.ToUTF8(tblRet.Rows(0).Item("Content"))
            'arrField = tvTemplate.Fields()
            Dim strContentTemp As String = tblRet.Rows(0).Item("Content") 'objBCSP.ToUTF8(tblRet.Rows(0).Item("Content"))
            arrField = objBCT.getArrayFromTemplate(strContentTemp)
            ImportFromXMLFile1 = 0
            Try
                doc.Load(FileName)
                Dim rdData As New XmlNodeReader(doc)
                ds.ReadXml(rdData)
                rdData.Close()
                dtlData = ds.Tables(0)
                If dtlData.Rows.Count >= 1 Then ' have atlease one record
                    For intRowIndex = 0 To dtlData.Rows.Count - 1
                        strLine = CStr(dtlData.Rows(intRowIndex).Item(0)).Trim
                        intTemp = ImportDataFromText(strLine, strhdValidDate, strhdExpiredDate, strhdLastModifiedDate, strhdPatronGroupID, boolOverwrite)
                        If intTemp > 0 Then ' Insert successful
                            ImportFromXMLFile1 = ImportFromXMLFile1 + 1
                        End If
                    Next
                End If
            Catch ex As Exception
                strErrorMsg &= ex.Message & "/"
            End Try
            srText.Close()
            'If Len(strErrorMsg) < 2 Then
            '    ImportFromTextFile = 1 ' Successful 100%
            'Else
            '    ImportFromTextFile = 0 ' UnSuccessful 100%
            'End If
            'tvTemplate = Nothing
        End Function
        ' Read text file method
        Public Function ImportFromTextFile(ByVal FileName As String, Optional ByVal strhdValidDate As String = "", Optional ByVal strhdExpiredDate As String = "", Optional ByVal strhdLastModifiedDate As String = "", Optional ByVal strhdPatronGroupID As String = "", Optional ByVal boolOverwrite As Boolean = False) As Integer
            Dim intTemp As Integer
            Dim srText As StreamReader = New StreamReader(FileName)
            Dim tblRet As New DataTable
            'Dim tvTemplate As New TVCOMLib.LibolTemplate
            Dim strLine As String

            tblExistPatron.Columns.Add("STT", GetType(System.Int16))
            tblExistPatron.Columns.Add("FullName", GetType(System.String))
            tblExistPatron.Columns.Add("Code", GetType(System.String))
            tblExistPatron.Columns.Add("DOB", GetType(System.String))
            tblExistPatron.Columns.Add("IDCard", GetType(System.String))
            objBCT.TemplateID = intTemplateID
            objBCT.TemplateType = intTemplateType
            tblRet = objBCT.GetTemplate
            ImportFromTextFile = tblRet.Rows.Count
            'tvTemplate.Template = objBCSP.ToUTF8(tblRet.Rows(0).Item("Content"))
            'arrField = tvTemplate.Fields()
            Dim strContentTemp As String = tblRet.Rows(0).Item("Content") 'objBCSP.ToUTF8(tblRet.Rows(0).Item("Content"))
            arrField = objBCT.getArrayFromTemplate(strContentTemp)
            ImportFromTextFile = 0
            Do
                Try
                    strLine = srText.ReadLine()
                    intTemp = ImportDataFromText(strLine, strhdValidDate, strhdExpiredDate, strhdLastModifiedDate, strhdPatronGroupID, boolOverwrite)
                    If intTemp > 0 Then ' Insert successful
                        ImportFromTextFile = ImportFromTextFile + 1
                    End If
                Catch ex As Exception
                    strErrorMsg &= ex.Message & "/"
                End Try
            Loop Until strLine Is Nothing
            srText.Close()
            'If Len(strErrorMsg) < 2 Then
            '    ImportFromTextFile = 1 ' Successful 100%
            'Else
            '    ImportFromTextFile = 0 ' UnSuccessful 100%
            'End If
            'tvTemplate = Nothing
        End Function
        Public Function CheckRenewDate(ByVal intPatronID As Integer) As DataTable
            Try
                objDPatronCollection.NewExpiredDate = objBCDBS.ConvertDateBack(strNewExpiredDate)
                CheckRenewDate = objDPatronCollection.CheckRenewDate(intPatronID)
                strErrorMsg = objBC.ErrorMsg
                intErrorCode = objBC.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function
        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                End If
                If Not objDPatronCollection Is Nothing Then
                    objDPatronCollection.Dispose(True)
                    objDPatronCollection = Nothing
                End If
                If Not objBCChart Is Nothing Then
                    objBCChart.Dispose(True)
                    objBCChart = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBCT Is Nothing Then
                    objBCT.Dispose(True)
                    objBCT = Nothing
                End If
                If Not objBP Is Nothing Then
                    objBP.Dispose(True)
                    objBP = Nothing
                End If
                If Not objBPro Is Nothing Then
                    objBPro.Dispose(True)
                    objBPro = Nothing
                End If
                If Not objBO Is Nothing Then
                    objBO.Dispose(True)
                    objBO = Nothing
                End If
                If Not objBE Is Nothing Then
                    objBE.Dispose(True)
                    objBE = Nothing
                End If
                If Not objBC Is Nothing Then
                    objBC.Dispose(True)
                    objBC = Nothing
                End If
                If Not objBPG Is Nothing Then
                    objBPG.Dispose(True)
                    objBPG = Nothing
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Dispose()
            End Try
        End Sub
    End Class
End Namespace