Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Patron

Namespace eMicLibAdmin.BusinessRules.Patron
    Public Class clsBPatron
        Inherits clsBBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************

        Private strCode As String
        Private strValidDate As String
        Private strExpiredDate As String = ""
        Private strLastIssuedDate As String = ""
        Private strLastName As String
        Private strFirstName As String
        Private strMiddleName As String = ""
        Private blnSex As Boolean
        Private strDOB As String = ""
        Private intEthnicID As Integer = 0
        Private intEducationID As Integer = 0
        Private intOccupationID As Integer = 0
        Private strWorkPlace As String = ""
        Private strTelephone As String = ""
        Private strMobile As String = ""
        'Private strEmail As String = ""
        Private strPortrait As String = ""
        Private intPatronGroupID As Integer
        Private strPassword As String = ""
        Private intStatus As Integer = 0
        Private strNote As String = ""
        Private strIDCard As String = ""
        Private dblDebt As Double = 0
        Private strLastModifiedDate As String = ""
        Private strZalo As String = ""
        'Private intPatronID As Integer = 0
        Private strPatronIDs As String = ""
        Private strFields As String = ""
        Private strAddressInfor As String = ""
        Private strNameCreate As String = ""
        Private strNameUpdate As String = ""

        '  Cir_tblPatronOtherAddr Table
        Private strAddressCPOA As String = ""
        Private strProvinceIDCPOA As String = ""
        Private strCityCPOA As String = ""
        Private strCountryIDCPOA As String = ""
        Private strZipCPOA As String = ""
        Private intActive As Integer = 0

        '  Cir_tblPatronUniversity Table
        Private intCollegeIDCPU As Integer
        Private intFacultyIDCPU As Integer
        Private strGradeCPU As String = ""
        Private strClassCPU As String = ""
        Private strIDs As String = ""

        Private objDPatron As New clsDPatron
        Private objBCDBS As New clsBCommonDBSystem
        Private objBCSP As New clsBCommonStringProc
        Private objBUniversity As New clsBUniversity
        Private objBOtherAddress As New clsBOtherAddress

        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************
        '' Zalo Property
        Public Property Zalo() As String
            Get
                Return strZalo
            End Get
            Set(ByVal Value As String)
                strZalo = Value
            End Set
        End Property
        '  FacultyIDCPU Property
        Public Property FacultyIDCPU() As Integer
            Get
                Return intFacultyIDCPU
            End Get
            Set(ByVal Value As Integer)
                intFacultyIDCPU = Value
            End Set
        End Property

        '  CollegeIDCPU Property
        Public Property CollegeIDCPU() As Integer
            Get
                Return intCollegeIDCPU
            End Get
            Set(ByVal Value As Integer)
                intCollegeIDCPU = Value
            End Set
        End Property

        '  GradeCPU Property
        Public Property GradeCPU() As String
            Get
                Return strGradeCPU
            End Get
            Set(ByVal Value As String)
                strGradeCPU = Value
            End Set
        End Property

        '  ClassCPU Property
        Public Property ClassCPU() As String
            Get
                Return strClassCPU
            End Get
            Set(ByVal Value As String)
                strClassCPU = Value
            End Set
        End Property

        '  AddressCPOA Property
        Property AddressCPOA() As String
            Get
                Return strAddressCPOA
            End Get
            Set(ByVal Value As String)
                strAddressCPOA = Value
            End Set
        End Property

        '  ProvinceIDCPOA Property
        Property ProvinceIDCPOA() As String
            Get
                Return strProvinceIDCPOA
            End Get
            Set(ByVal Value As String)
                strProvinceIDCPOA = Value
            End Set
        End Property

        '  CityCPOA Property
        Property CityCPOA() As String
            Get
                Return strCityCPOA
            End Get
            Set(ByVal Value As String)
                strCityCPOA = Value
            End Set
        End Property

        '  CountryIDCPOA Property
        Property CountryIDCPOA() As String
            Get
                Return strCountryIDCPOA
            End Get
            Set(ByVal Value As String)
                strCountryIDCPOA = Value
            End Set
        End Property

        '  ZipCPOA Property
        Property ZipCPOA() As String
            Get
                Return strZipCPOA
            End Get
            Set(ByVal Value As String)
                strZipCPOA = Value
            End Set
        End Property

        '  Active Property
        Property Active() As Integer
            Get
                Return intActive
            End Get
            Set(ByVal Value As Integer)
                intActive = Value
            End Set
        End Property

        '  Code Property
        Public Property Code() As String
            Get
                Return strCode
            End Get
            Set(ByVal Value As String)
                strCode = Value
            End Set
        End Property

        '  ValidDate Property
        Public Property ValidDate() As String
            Get
                Return strValidDate
            End Get
            Set(ByVal Value As String)
                strValidDate = Value
            End Set
        End Property

        '  ExpiredDate Property
        Public Property ExpiredDate() As String
            Get
                Return strExpiredDate
            End Get
            Set(ByVal Value As String)
                strExpiredDate = Value
            End Set
        End Property

        '  LastIssuedDate Property
        Public Property LastIssuedDate() As String
            Get
                Return strLastIssuedDate
            End Get
            Set(ByVal Value As String)
                strLastIssuedDate = Value
            End Set
        End Property

        '  LastName Property
        Public Property LastName() As String
            Get
                Return strLastName
            End Get
            Set(ByVal Value As String)
                strLastName = Value
            End Set
        End Property

        '  FirstName Property
        Public Property FirstName() As String
            Get
                Return strFirstName
            End Get
            Set(ByVal Value As String)
                strFirstName = Value
            End Set
        End Property

        '  MiddleName Property
        Public Property MiddleName() As String
            Get
                Return strMiddleName
            End Get
            Set(ByVal Value As String)
                strMiddleName = Value
            End Set
        End Property

        '  Sex Property
        Public Property Sex() As Boolean
            Get
                Return blnSex
            End Get
            Set(ByVal Value As Boolean)
                blnSex = Value
            End Set
        End Property

        '  DOB Property
        Public Property DOB() As String
            Get
                Return strDOB
            End Get
            Set(ByVal Value As String)
                strDOB = Value
            End Set
        End Property

        '  EthnicID Property
        Public Property EthnicID() As Integer
            Get
                Return intEthnicID
            End Get
            Set(ByVal Value As Integer)
                intEthnicID = Value
            End Set
        End Property

        '  EducationID Property
        Public Property EducationID() As Integer
            Get
                Return intEducationID
            End Get
            Set(ByVal Value As Integer)
                intEducationID = Value
            End Set
        End Property

        '  OccupationID Property
        Public Property OccupationID() As Integer
            Get
                Return intOccupationID
            End Get
            Set(ByVal Value As Integer)
                intOccupationID = Value
            End Set
        End Property

        '  WorkPlace Property
        Public Property WorkPlace() As String
            Get
                Return strWorkPlace
            End Get
            Set(ByVal Value As String)
                strWorkPlace = Value
            End Set
        End Property

        '  Telephone Property
        Public Property Telephone() As String
            Get
                Return strTelephone
            End Get
            Set(ByVal Value As String)
                strTelephone = Value
            End Set
        End Property

        '  Mobile Property
        Public Property Mobile() As String
            Get
                Return strMobile
            End Get
            Set(ByVal Value As String)
                strMobile = Value
            End Set
        End Property

        '  Portrait Property
        Public Property Portrait() As String
            Get
                Return strPortrait
            End Get
            Set(ByVal Value As String)
                strPortrait = Value
            End Set
        End Property

        '  PatronGroupID Property
        Public Property PatronGroupID() As Integer
            Get
                Return intPatronGroupID
            End Get
            Set(ByVal Value As Integer)
                intPatronGroupID = Value
            End Set
        End Property

        '  Password Property
        Public Property Password() As String
            Get
                Return strPassword
            End Get
            Set(ByVal Value As String)
                strPassword = Value
            End Set
        End Property

        '  Status Property
        Public Property Status() As Integer
            Get
                Return intStatus
            End Get
            Set(ByVal Value As Integer)
                intStatus = Value
            End Set
        End Property

        '  Note Property
        Public Property Note() As String
            Get
                Return strNote
            End Get
            Set(ByVal Value As String)
                strNote = Value
            End Set
        End Property

        ' IDCard property
        Public Property IDCard() As String
            Get
                Return (strIDCard)
            End Get
            Set(ByVal Value As String)
                strIDCard = Value
            End Set
        End Property

        '  Debt Property
        Public Property Debt() As Double
            Get
                Return dblDebt
            End Get
            Set(ByVal Value As Double)
                dblDebt = Value
            End Set
        End Property

        '  LastModifiedDate Property
        Public Property LastModifiedDate() As String
            Get
                Return strLastModifiedDate
            End Get
            Set(ByVal Value As String)
                strLastModifiedDate = Value
            End Set
        End Property

        '  PatronIds Property
        Public Property PatronIDs() As String
            Get
                Return strPatronIDs
            End Get
            Set(ByVal Value As String)
                strPatronIDs = Value
            End Set
        End Property

        '  Fields Property
        Public Property Fields() As String
            Get
                Return strFields
            End Get
            Set(ByVal Value As String)
                strFields = Value
            End Set
        End Property

        ' AddressInfor property
        Public Property AddressInfor() As String
            Get
                Return strAddressInfor
            End Get
            Set(ByVal Value As String)
                strAddressInfor = Value
            End Set
        End Property

        ' strIDs
        Public Property IDs() As String
            Get
                Return strIDs
            End Get
            Set(ByVal Value As String)
                strIDs = Value
            End Set
        End Property

        ' strNameCreate
        Public Property NameCreate() As String
            Get
                Return strNameCreate
            End Get
            Set(ByVal Value As String)
                strNameCreate = Value
            End Set
        End Property

        ' strNameUpdate
        Public Property NameUpdate() As String
            Get
                Return strNameUpdate
            End Get
            Set(ByVal Value As String)
                strNameUpdate = Value
            End Set
        End Property

        ' *************************************************************************************************
        ' End declare properties
        ' Declare public method
        ' *************************************************************************************************

        ' Method: Initialize
        ' Purpose: Init all need objects
        Public Sub Initialize()
            ' Init objDPatronGroup object
            objDPatron.DBServer = strDBServer
            objDPatron.ConnectionString = strConnectionString
            Call objDPatron.Initialize()

            ' Initialize objBCDBS object
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            Call objBCDBS.Initialize()

            ' Initialize objBCSP object
            objBCSP.InterfaceLanguage = strInterfaceLanguage
            objBCSP.DBServer = strDBServer
            objBCSP.ConnectionString = strConnectionString
            Call objBCSP.Initialize()

            ' Init objBUniversity
            objBUniversity.DBServer = strDBServer
            objBUniversity.ConnectionString = strConnectionString
            objBUniversity.InterfaceLanguage = strInterfaceLanguage
            Call objBUniversity.Initialize()

            ' Init objBOtherAddress
            objBOtherAddress.DBServer = strDBServer
            objBOtherAddress.ConnectionString = strConnectionString
            objBOtherAddress.InterfaceLanguage = strInterfaceLanguage
            Call objBOtherAddress.initialize()
        End Sub

        Public Function GetPatron_byPatronGroupID(Optional ByVal intPatronGroupID As Integer = 0) As DataTable
            Dim tblResult As DataTable

            Try
                objDPatron.PatronGroupID = intPatronGroupID
                tblResult = objDPatron.GetPatron_byPatronGroupID(intPatronGroupID)
                GetPatron_byPatronGroupID = tblResult
                strErrorMsg = objDPatron.ErrorMsg
                intErrorCode = objDPatron.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        Public Function GetPatron_byOrder(Optional ByVal intFacultyID As Integer = 0, Optional ByVal intPatronGroupID As Integer = 0, Optional ByVal intYearFrom As Integer = 0, Optional ByVal intYearTo As Integer = 0) As DataTable
            Dim tblResult As DataTable

            Try
                objDPatron.PatronGroupID = intPatronGroupID
                tblResult = objDPatron.GetPatron_byOrder(intFacultyID, intPatronGroupID, intYearFrom, intYearTo)
                GetPatron_byOrder = tblResult
                strErrorMsg = objDPatron.ErrorMsg
                intErrorCode = objDPatron.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        Public Function GetPatron(Optional ByVal strOrder As String = "") As DataTable
            Dim tblResult As DataTable
            Dim intIndex As Integer

            Try
                objDPatron.PatronIDs = strPatronIDs
                objDPatron.Fields = strFields
                tblResult = objBCDBS.ConvertTable(objDPatron.GetPatron(strOrder))
                If Not tblResult Is Nothing Then
                    If tblResult.Rows.Count > 0 Then
                        For intIndex = 0 To tblResult.Rows.Count - 1
                            tblResult.Rows(intIndex).Item("Rownumber") = intIndex + 1
                        Next
                    End If
                End If
                GetPatron = tblResult
                strErrorMsg = objDPatron.ErrorMsg
                intErrorCode = objDPatron.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        Public Function GetMaxCardNo() As String
            Dim tblResult As String = ""
            Try
                Dim dtTemp As DataTable
                dtTemp = objDPatron.GetMaxCardNo()
                If Not IsNothing(dtTemp) AndAlso dtTemp.Rows.Count > 0 Then
                    Dim intMax As Integer = dtTemp.Rows(0).Item("code")
                    Dim intLength As Integer = Len(dtTemp.Rows(0).Item("code"))
                    tblResult = intMax + 1
                    tblResult = tblResult.ToString.PadLeft(intLength, "0")
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
            Return tblResult
        End Function

        Public Function GetPatronByCodeFromTo(Optional ByVal intFrom As Integer = 0, Optional ByVal intTo As Integer = 0) As DataTable
            Dim tblResult As DataTable
            Dim intIndex As Integer

            Try
                objDPatron.PatronIDs = strPatronIDs
                objDPatron.Fields = strFields
                tblResult = objBCDBS.ConvertTable(objDPatron.GetPatronByCodeFromTo(intFrom, intTo))
                If Not tblResult Is Nothing Then
                    If tblResult.Rows.Count > 0 Then
                        For intIndex = 0 To tblResult.Rows.Count - 1
                            tblResult.Rows(intIndex).Item("Rownumber") = intIndex + 1
                        Next
                    End If
                End If
                GetPatronByCodeFromTo = tblResult
                strErrorMsg = objDPatron.ErrorMsg
                intErrorCode = objDPatron.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        ' Purpose: Retrieve a datatable from cir_patron
        ' Intput: 
        ' Output: DataTable for queue
        ' Creator: Lent
        Public Function GetPatronQueue() As DataTable
            Dim tmpResult As DataTable
            Dim intIndex As Integer
            Try
                tmpResult = objBCDBS.ConvertTable(objDPatron.GetPatronQueue)
                For intIndex = 0 To tmpResult.Rows.Count - 1
                    tmpResult.Rows(intIndex).Item("Postion") = CStr(intIndex + 1)
                Next
                GetPatronQueue = tmpResult
            Catch ex As Exception
                strErrorMsg = objDPatron.ErrorMsg
                intErrorCode = objDPatron.ErrorCode
            End Try
        End Function

        ' Purpose: Check exist patron (return patron record is exist)
        ' Intput: strCode, strDOB, strIDCard
        ' Output: DataTable
        ' Creator: Sondp
        Public Function CheckExistPatron() As DataTable
            Dim tblResult As New DataTable
            Try
                objDPatron.Code = strCode
                objDPatron.DOB = strDOB
                objDPatron.IDCard = strIDCard
                tblResult = objBCDBS.ConvertTable(objDPatron.CheckExistPatron)
                CheckExistPatron = tblResult
            Catch ex As Exception
                strErrorMsg = objDPatron.ErrorMsg
                intErrorCode = objDPatron.ErrorCode
            End Try
        End Function

        ' Purpose: Get PatronID from PatronCard
        ' Intput: strCode
        ' Output: DataTable
        ' Creator: Sondp
        Public Function GetPatronIDFromCode() As DataTable
            Dim tblResult As New DataTable
            Try
                objDPatron.Code = strCode
                tblResult = objBCDBS.ConvertTable(objDPatron.GetPatronIDFromCode)
                GetPatronIDFromCode = tblResult
            Catch ex As Exception
                strErrorMsg = objDPatron.ErrorMsg
                intErrorCode = objDPatron.ErrorCode
            End Try
        End Function

        Public Function Create(Optional ByVal intIsQue As Int16 = 0) As Long
            Dim intRetval As Long

            Try
                objDPatron.FirstName = strFirstName
                objDPatron.MiddleName = objBCSP.ConvertItBack(strMiddleName)
                objDPatron.LastName = strLastName
                objDPatron.Sex = blnSex
                objDPatron.DOB = objBCDBS.ConvertDateBack(strDOB)
                objDPatron.EthnicID = intEthnicID
                objDPatron.PatronGroupID = intPatronGroupID
                objDPatron.Code = strCode
                objDPatron.Portrait = strPortrait
                objDPatron.Debt = dblDebt
                objDPatron.LastIssuedDate = objBCDBS.ConvertDateBack(strLastIssuedDate)
                objDPatron.ValidDate = objBCDBS.ConvertDateBack(strValidDate)
                objDPatron.ExpiredDate = objBCDBS.ConvertDateBack(strExpiredDate)
                objDPatron.LastModifiedDate = objBCDBS.ConvertDateBack(strLastModifiedDate)
                objDPatron.EducationID = intEducationID
                objDPatron.OccupationID = intOccupationID
                objDPatron.WorkPlace = objBCSP.ConvertItBack(strWorkPlace)
                objDPatron.Telephone = strTelephone
                objDPatron.Mobile = strMobile
                objDPatron.Email = strEmail
                objDPatron.Facebook = Facebook
                objDPatron.Zalo = strZalo
                objDPatron.Note = objBCSP.ConvertItBack(strNote)
                objDPatron.IDCard = objBCSP.ConvertItBack(strIDCard)
                objDPatron.NameCreate = strNameCreate
                objDPatron.NameUpdate = strNameUpdate
                intRetval = objDPatron.Create(intIsQue)
                Create = intRetval
                If intRetval > 0 Then
                    ' Create patron's university informations
                    If intCollegeIDCPU > 0 Then
                        objBUniversity.CollegeID = intCollegeIDCPU
                        objBUniversity.FacultyID = intFacultyIDCPU
                        objBUniversity.Grade = objBCSP.ConvertItBack(strGradeCPU)
                        objBUniversity.UClass = objBCSP.ConvertItBack(ClassCPU)
                        objBUniversity.PatronID = intRetval
                        objBUniversity.Create()
                    End If
                    ' Create patron's address informations
                    Dim inti As Integer
                    Dim strAddress, strCity, strZip As String
                    Dim intProvinceID, intCountryID, intisActive As Integer
                    Dim arrAdd() As String
                    Dim arrRecord() As String
                    ' Each patron's address
                    If strAddressInfor <> "" Then
                        'arrAdd = Split(strAddressInfor, "##")
                        arrAdd = Split(strAddressInfor, "vbCrLf") '##
                        If UBound(arrAdd) >= 0 Then
                            For inti = 0 To UBound(arrAdd)
                                ' Refresh parameter
                                strAddress = ""
                                strCity = ""
                                strZip = ""
                                intProvinceID = 0
                                intCountryID = 0
                                intisActive = 0
                                ' Each field in a address
                                arrRecord = Split(arrAdd(inti), "$&")
                                If UBound(arrRecord) >= 0 AndAlso IsArray(arrRecord) Then
                                    Try
                                        strAddress = objBCSP.ConvertItBack(arrRecord(1))
                                    Catch ex As Exception
                                        strAddress = ""
                                    End Try
                                    Try
                                        strCity = objBCSP.ConvertItBack(arrRecord(2))
                                    Catch ex As Exception
                                        strCity = ""
                                    End Try
                                    Try
                                        intProvinceID = arrRecord(3)
                                    Catch ex As Exception
                                        intProvinceID = 0
                                    End Try
                                    Try
                                        intCountryID = arrRecord(4)
                                        If intCountryID = 0 Then
                                            intCountryID = 209
                                        End If
                                    Catch ex As Exception
                                        intCountryID = 0
                                    End Try
                                    Try
                                        strZip = objBCSP.ConvertItBack(arrRecord(5))
                                    Catch ex As Exception
                                        strZip = ""
                                    End Try
                                    Try
                                        intisActive = arrRecord(6)
                                    Catch ex As Exception
                                        intisActive = 0
                                    End Try
                                    objBOtherAddress.PatronID = intRetval
                                    objBOtherAddress.Create(strAddress, intProvinceID, strCity, intCountryID, strZip, intisActive)
                                    strErrorMsg = objBOtherAddress.ErrorMsg
                                    intErrorCode = objBOtherAddress.ErrorCode
                                End If
                            Next
                        End If
                    End If
                End If
                strErrorMsg = objDPatron.ErrorMsg
                intErrorCode = objDPatron.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        Public Function CreatePatron(ByVal intFaculty As Integer, ByVal intCollege As Integer) As Long
            Dim intRetval As Long = 0
            Try
                objDPatron.FirstName = strFirstName
                objDPatron.MiddleName = strMiddleName
                objDPatron.LastName = strLastName
                objDPatron.Sex = blnSex
                objDPatron.DOB = strDOB
                objDPatron.EthnicID = intEthnicID
                objDPatron.PatronGroupID = intPatronGroupID
                objDPatron.Code = strCode
                objDPatron.Portrait = strPortrait
                objDPatron.Status = intStatus
                objDPatron.LastIssuedDate = strLastIssuedDate
                objDPatron.ValidDate = strValidDate
                objDPatron.ExpiredDate = strExpiredDate
                objDPatron.LastModifiedDate = strLastModifiedDate
                objDPatron.EducationID = intEducationID
                objDPatron.OccupationID = intOccupationID
                objDPatron.WorkPlace = strWorkPlace
                objDPatron.Telephone = strTelephone
                objDPatron.Mobile = strMobile
                objDPatron.Email = strEmail
                objDPatron.Note = strNote
                objDPatron.LibID = intLibID
                objDPatron.NameCreate = strNameCreate
                objDPatron.NameUpdate = strNameUpdate
                intRetval = objDPatron.CreatePatron(intFaculty, intCollege)
                CreatePatron = intRetval
                strErrorMsg = objDPatron.ErrorMsg
                intErrorCode = objDPatron.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function Update() As Long
            Dim intRetval As Long
            Try
                objDPatron.PatronID = intPatronID
                objDPatron.FirstName = objBCSP.ConvertItBack(strFirstName)
                objDPatron.MiddleName = objBCSP.ConvertItBack(strMiddleName)
                objDPatron.LastName = objBCSP.ConvertItBack(strLastName)
                objDPatron.Sex = blnSex
                objDPatron.DOB = objBCDBS.ConvertDateBack(strDOB)
                objDPatron.EthnicID = intEthnicID
                objDPatron.PatronGroupID = intPatronGroupID
                objDPatron.Code = strCode
                objDPatron.Portrait = strPortrait
                objDPatron.Debt = dblDebt
                objDPatron.LastIssuedDate = objBCDBS.ConvertDateBack(strLastIssuedDate)
                objDPatron.ValidDate = objBCDBS.ConvertDateBack(strValidDate)
                objDPatron.ExpiredDate = objBCDBS.ConvertDateBack(strExpiredDate)
                objDPatron.LastModifiedDate = objBCDBS.ConvertDateBack(strLastModifiedDate)
                objDPatron.EducationID = intEducationID
                objDPatron.OccupationID = intOccupationID
                objDPatron.WorkPlace = objBCSP.ConvertItBack(strWorkPlace)
                objDPatron.Telephone = strTelephone
                objDPatron.Mobile = strMobile
                objDPatron.Email = strEmail
                objDPatron.Facebook = Facebook
                objDPatron.Note = objBCSP.ConvertItBack(strNote)
                objDPatron.IDCard = objBCSP.ConvertItBack(strIDCard)
                objDPatron.AddressInfor = objBCSP.ConvertItBack(strAddressInfor)
                objDPatron.NameUpdate = strNameUpdate
                intRetval = objDPatron.Update
                Update = intRetval
                If intRetval > 0 Then
                    ' Create patron's university informations
                    If intCollegeIDCPU >= 0 Then
                        objBUniversity.PatronID = intPatronID
                        objBUniversity.CollegeID = intCollegeIDCPU
                        objBUniversity.FacultyID = intFacultyIDCPU
                        objBUniversity.Grade = strGradeCPU
                        objBUniversity.UClass = ClassCPU
                        objBUniversity.Update()
                    End If
                    ' Create patron's address informations
                    Dim inti As Integer
                    Dim strAddress, strCity, strZip As String
                    Dim intID, intProvinceID, intCountryID, intisActive As Integer
                    Dim arrAdd() As String
                    Dim arrRecord() As String
                    If strAddressInfor <> "" Then
                        ' Each patron's address
                        arrAdd = Split(strAddressInfor, "vbCrLf") '##
                        If UBound(arrAdd) >= 0 Then
                            ' Delete before insert <-> update
                            objBOtherAddress.PatronID = intPatronID
                            Call objBOtherAddress.Delete()
                            strErrorMsg = objBOtherAddress.ErrorMsg
                            intErrorCode = objBOtherAddress.ErrorCode
                            For inti = 0 To UBound(arrAdd)
                                ' Refresh parameter
                                intID = 0
                                strAddress = ""
                                strCity = ""
                                strZip = ""
                                intProvinceID = 0
                                intCountryID = 0
                                intisActive = 0
                                ' Each field in a address
                                'arrRecord = Split(arrAdd(inti), Chr(9)) '$&
                                arrRecord = Split(arrAdd(inti), "$&") '$&
                                If UBound(arrRecord) >= 0 AndAlso IsArray(arrRecord) Then
                                    Try
                                        intID = arrRecord(0) ' no use
                                    Catch ex As Exception
                                        intID = 0
                                    End Try
                                    Try
                                        strAddress = objBCSP.ConvertItBack(arrRecord(1))
                                    Catch ex As Exception
                                        strAddress = ""
                                    End Try
                                    Try
                                        strCity = objBCSP.ConvertItBack(arrRecord(2))
                                    Catch ex As Exception
                                        strCity = ""
                                    End Try
                                    Try
                                        intProvinceID = arrRecord(3)
                                    Catch ex As Exception
                                        intProvinceID = 0
                                    End Try
                                    Try
                                        intCountryID = arrRecord(4)
                                        If intCountryID = 0 Then
                                            intCountryID = 209
                                        End If
                                    Catch ex As Exception
                                        intCountryID = 0
                                    End Try
                                    Try
                                        strZip = objBCSP.ConvertItBack(arrRecord(5))
                                    Catch ex As Exception
                                        strZip = ""
                                    End Try
                                    Try
                                        intisActive = CInt(Left(arrRecord(6), 1))
                                    Catch ex As Exception
                                        intisActive = 0
                                    End Try
                                    objBOtherAddress.PatronID = intPatronID
                                    objBOtherAddress.Create(strAddress, intProvinceID, strCity, intCountryID, strZip, intisActive)
                                    strErrorMsg = objBOtherAddress.ErrorMsg
                                    intErrorCode = objBOtherAddress.ErrorCode
                                End If
                            Next
                        End If
                    End If
                End If
                strErrorMsg = objDPatron.ErrorMsg
                intErrorCode = objDPatron.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        Public Function Delete() As Integer
            Try
                objDPatron.PatronID = intPatronID
                Delete = objDPatron.Delete
                strErrorMsg = objDPatron.ErrorMsg
                intErrorCode = objDPatron.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        ' Purpose: update status=1 in Cir_Patron table
        Public Sub UpdateQueue()
            Try
                objDPatron.IDs = strIDs
                Call objDPatron.UpdateQueue()
            Catch ex As Exception
                strErrorMsg = objDPatron.ErrorMsg
                intErrorCode = objDPatron.ErrorCode
            End Try
        End Sub

        ' Method: Dispose
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                End If
                If Not objDPatron Is Nothing Then
                    objDPatron.Dispose(True)
                    objDPatron = Nothing
                End If
                If Not objBOtherAddress Is Nothing Then
                    objBOtherAddress.Dispose(True)
                    objBOtherAddress = Nothing
                End If
                If Not objBUniversity Is Nothing Then
                    objBUniversity.Dispose(True)
                    objBUniversity = Nothing
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Dispose()
            End Try
        End Sub
    End Class
End Namespace