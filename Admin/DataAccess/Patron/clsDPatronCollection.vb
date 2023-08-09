Imports System.Data
Imports System.Data.sqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Patron
    Public Class clsDPatronCollection
        Inherits clsDBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private strTypeSearch As String
        ' Declare variable for objSearch
        Private lngSelectTop As Long
        Private strOperator1 As String = "" ' AND, OR ,NOT
        Private strOperator2 As String = ""
        Private strOperator3 As String = ""
        Private strOperator4 As String = ""
        Private strOperator5 As String = ""

        'Code,FN,Workplace,Email,Class,Grade,Address
        Private bytFieldName1 As Byte
        Private bytFieldName2 As Byte

        ' Faculty,College,Education,Ethnic,
        'Occupation,Province,PatronGroup,Sex
        Private bytFieldNameOther1 As Byte
        Private bytFieldNameOther2 As Byte

        Private bytFieldNameDate1 As Byte 'DOB,ValidDate,ExpireDate
        Private bytFieldNameDate2 As Byte
        Private bytFieldOpeFrom1 As Byte '= , >=
        Private bytFieldOpeFrom2 As Byte

        'Code,FN,Workplace,Email,Class,Grade,Address
        Private strFieldValue1 As String = ""
        Private strFieldValue2 As String = ""

        ' FacultyID,CollegeID,EducationID,EthnicID,
        ' OccupationID,ProvinceID,PatronGroupID,Sex
        Private intFieldValueOther1 As Integer
        Private intFieldValueOther2 As Integer

        Private strFieldValueFrom1 As String = "" 'DOB,ValidDate,ExpireDate
        Private strFieldValueFrom2 As String = ""
        Private strFieldValueTo1 As String = "" 'DOB,ValidDate,ExpireDate
        Private strFieldValueTo2 As String = ""

        Private bytSex As Byte = 2
        Private strPatronGroupID As String = ""

        Private lngFromID As Long = 0
        Private lngToID As Long = 0
        Private strFromCode As String
        Private strToCode As String
        Private strFromValidDate As String = ""
        Private strToValidDate As String = ""
        Private strCode As String = ""
        Private strValidDate As String = ""
        Private strExpiredDate As String = ""
        Private strLastIssuedDate As String = ""
        Private strFullName As String = ""
        Private strDOB As String = ""
        Private intEthnicID As Integer = 0
        Private intEducationID As Integer = 0
        Private intOccupationID As Integer = 0
        Private strWorkPlace As String = ""
        Private strMobile As String = ""
        Private strEmail As String = ""
        Private strLastModifiedDate As String = ""
        Private strCollege As String = ""
        Private intFaculty As Integer
        Private strGrade As String = ""
        Private strClass As String = ""
        Private strAddress As String = ""
        Private bytOrderBy As Byte
        Private strSQL As String = ""
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
        Private intNumOfPatron As Integer = 1
        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************
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
        Public ReadOnly Property SQL() As String
            Get
                Return strSQL
            End Get
        End Property

        Public Property SelectTop() As Long
            Get
                SelectTop = lngSelectTop
            End Get
            Set(ByVal Value As Long)
                lngSelectTop = Value
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
                Return (lngToID)
            End Get
            Set(ByVal Value As Long)
                lngToID = Value
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

        Public Property ExpiredDate() As String
            Get
                ExpiredDate = strExpiredDate
            End Get
            Set(ByVal Value As String)
                strExpiredDate = Value
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

        Public Property FacultyID() As Integer
            Get
                FacultyID = intFaculty
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

        ' *************************************************************************************************
        ' End declare properties
        ' Declare public method
        ' *************************************************************************************************

        ' Purpose : AgeStat
        ' Input: intFromAge, intToAge
        ' Output: Datatable
        ' Created by: Sondp
        Public Function AgeStat(ByVal intFromAge As Integer, ByVal intToAge As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatron_StatAge"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intFromAge", SqlDbType.Int)).Value = intFromAge
                                .Add(New SqlParameter("@intToAge", SqlDbType.Int)).Value = intToAge
                                .Add(New SqlParameter("@intLibId", SqlDbType.Int)).Value = intLibID
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "SP_CIR_PATRON_STARTAGE")
                            AgeStat = dsData.Tables("SP_CIR_PATRON_STARTAGE")
                            dsdata.Tables.Remove("SP_CIR_PATRON_STARTAGE")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "PATRON.SP_CIR_PATRON_STARTAGE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intFromAge", OracleType.Number)).Value = intFromAge
                                .Add(New OracleParameter("intToAge", OracleType.Number)).Value = intToAge
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "SP_CIR_PATRON_STARTAGE")
                            AgeStat = dsData.Tables("SP_CIR_PATRON_STARTAGE")
                            dsData.Tables.Remove("SP_CIR_PATRON_STARTAGE")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function AgeStatDetail(ByVal intFromAge As Integer, ByVal intToAge As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spPatron_StatAge_Detail"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intFromAge", SqlDbType.Int)).Value = intFromAge
                                .Add(New SqlParameter("@intToAge", SqlDbType.Int)).Value = intToAge
                                .Add(New SqlParameter("@intLibId", SqlDbType.Int)).Value = intLibID
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            AgeStatDetail = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function CreatedDateStatDetail(ByVal intCreatedDate As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spPatron_StatCreateDate_Detail"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intCreatedDate", SqlDbType.Int)).Value = intCreatedDate
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                                .Add(New SqlParameter("@intFacultyID", SqlDbType.Int)).Value = intFaculty
                            End With
                            .ExecuteNonQuery()
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            CreatedDateStatDetail = dsData.Tables("tblResult")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function
        Public Function CreatedDateStatDetailDHVL(ByVal strDateFrom As String, ByVal strDateTo As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spPatron_StatCreateDate_Detail"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strDateFrom", SqlDbType.VarChar, 30)).Value = strDateFrom
                                .Add(New SqlParameter("@strDateTo", SqlDbType.VarChar, 30)).Value = strDateTo
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                                .Add(New SqlParameter("@intFacultyID", SqlDbType.Int)).Value = intFaculty
                            End With
                            .ExecuteNonQuery()
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            CreatedDateStatDetailDHVL = dsData.Tables("tblResult")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function
        Public Function PatronGroupStatDetail() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spPatronGroup_StatGroup_Detail"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intLibId", SqlDbType.Int)).Value = intLibID
                                .Add(New SqlParameter("@intPatronGroupID", SqlDbType.Int)).Value = CInt(strPatronGroupID)
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            PatronGroupStatDetail = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function
        Public Function ExpiredDateStatDetail(ByVal intExpiredDate As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spPatron_StatExpiredDate_Detail"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intExpiredDate", SqlDbType.Int)).Value = intExpiredDate
                                .Add(New SqlParameter("@intLibId", SqlDbType.Int)).Value = intLibID
                                .Add(New SqlParameter("@intFacultyID", SqlDbType.Int)).Value = intFaculty
                            End With
                            .ExecuteNonQuery()
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "Cir_spPatron_StatExpiredDate")
                            ExpiredDateStatDetail = dsData.Tables("Cir_spPatron_StatExpiredDate")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("Cir_spPatron_StatExpiredDate")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function
        Public Function ExpiredDateStatDetailDHVL(ByVal strDateFrom As String, ByVal strDateTo As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spPatron_StatExpiredDate_Detail"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                '.Add(New SqlParameter("@intExpiredDate", SqlDbType.Int)).Value = intExpiredDate
                                .Add(New SqlParameter("@strDateFrom", SqlDbType.VarChar, 10)).Value = strDateFrom
                                .Add(New SqlParameter("@strDateTo", SqlDbType.VarChar, 10)).Value = strDateTo
                                .Add(New SqlParameter("@intLibId", SqlDbType.Int)).Value = intLibID
                                .Add(New SqlParameter("@intFacultyID", SqlDbType.Int)).Value = intFaculty
                            End With
                            .ExecuteNonQuery()
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "Cir_spPatron_StatExpiredDate")
                            ExpiredDateStatDetailDHVL = dsData.Tables("Cir_spPatron_StatExpiredDate")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("Cir_spPatron_StatExpiredDate")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose : PatronGroupStat
        ' Output: Datatable
        ' Created by: Sondp
        Public Function PatronGroupStat() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatronGroup_StatGroup"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters

                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "Cir_spPatronGroup_StatGroup")
                            PatronGroupStat = dsData.Tables("Cir_spPatronGroup_StatGroup")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            dsData.Tables.Remove("Cir_spPatronGroup_StatGroup")
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "PATRON.SP_CIR_PATRON_STARTGRP"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "SP_CIR_PATRON_STARTGRP")
                            PatronGroupStat = dsData.Tables("SP_CIR_PATRON_STARTGRP")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("SP_CIR_PATRON_STARTGRP")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose : get total patrons
        ' Output: Datatable
        ' Created by: Sondp
        Public Function GetTotalPatrons() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
               Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spPatron_SelTotalPatron"
                        .CommandType = CommandType.StoredProcedure
                        Try
                           
                            .ExecuteNonQuery()
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "Cir_spPatron_SelTotalPatron")
                            GetTotalPatrons = dsData.Tables("Cir_spPatron_SelTotalPatron")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            dsData.Tables.Remove("Cir_spPatron_SelTotalPatron")
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "PATRON.SP_GET_TOTAL_PATRONS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetTotalPatrons = dsData.Tables("tblResult")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose: FacultyStat
        ' Input: intCollegeID
        ' Created by: Sondp
        Public Function FacultyStat(ByVal intCollegeID As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spDicFaculty_StatFaculty"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intCollegeID", SqlDbType.Int)).Value = intCollegeID
                                .Add(New SqlParameter("@intLibId", SqlDbType.Int)).Value = intLibID
                            End With
                            .ExecuteNonQuery()
                            SqlDataAdapter.SelectCommand = SqlCommand
                            sqlDataAdapter.Fill(dsData, "Cir_spDicFaculty_StatFaculty")
                            FacultyStat = dsData.Tables("Cir_spDicFaculty_StatFaculty")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("Cir_spDicFaculty_StatFaculty")
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "PATRON.SP_CIR_PATRON_STATFACULTY"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intCollegeID", OracleType.Number)).Value = intCollegeID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "SP_CIR_PATRON_STATFACULTY")
                            FacultyStat = dsData.Tables("SP_CIR_PATRON_STATFACULTY")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("SP_CIR_PATRON_STATFACULTY")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function FacultyStat(ByVal intDicFacultyID As Integer, Optional ByVal intGroup As Integer = 0, Optional ByVal intYearFrom As Integer = 0, Optional ByVal intYearTo As Integer = 0) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spDicFaculty_StatFacultyOther"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intDicFacultyID", SqlDbType.Int)).Value = intDicFacultyID
                                .Add(New SqlParameter("@intGroupPatron", SqlDbType.Int)).Value = intGroup
                                .Add(New SqlParameter("@YearFrom", SqlDbType.Int)).Value = intYearFrom
                                .Add(New SqlParameter("@YearTo", SqlDbType.Int)).Value = intYearTo
                                .Add(New SqlParameter("@intLibId", SqlDbType.Int)).Value = intLibID
                            End With
                            .ExecuteNonQuery()
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            FacultyStat = dsData.Tables("tblResult")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"
                    'With oraCommand
                    '    .CommandText = "PATRON.SP_CIR_PATRON_STATFACULTY"
                    '    .CommandType = CommandType.StoredProcedure
                    '    Try
                    '        With .Parameters
                    '            .Add(New OracleParameter("intCollegeID", OracleType.Number)).Value = intCollegeID
                    '            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                    '        End With
                    '        .ExecuteNonQuery()
                    '        oraDataAdapter.SelectCommand = oraCommand
                    '        oraDataAdapter.Fill(dsData, "SP_CIR_PATRON_STATFACULTY")
                    '        FacultyStat = dsData.Tables("SP_CIR_PATRON_STATFACULTY")
                    '    Catch ex As OracleException
                    '        strErrorMsg = ex.Message.ToString
                    '        intErrorCode = ex.Code
                    '    Finally
                    '        .Parameters.Clear()
                    '        dsData.Tables.Remove("SP_CIR_PATRON_STATFACULTY")
                    '    End Try
                    'End With
            End Select
            Call CloseConnection()
        End Function

        Public Function FacultyStatDetail(ByVal intDicFacultyID As Integer, Optional ByVal intGroup As Integer = 0, Optional ByVal intYearFrom As Integer = 0, Optional ByVal intYearTo As Integer = 0) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spDicFaculty_StatFacultyOther_Detail"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intDicFacultyID", SqlDbType.Int)).Value = intDicFacultyID
                                .Add(New SqlParameter("@intGroupPatron", SqlDbType.Int)).Value = intGroup
                                .Add(New SqlParameter("@YearFrom", SqlDbType.Int)).Value = intYearFrom
                                .Add(New SqlParameter("@YearTo", SqlDbType.Int)).Value = intYearTo
                                .Add(New SqlParameter("@intLibId", SqlDbType.Int)).Value = intLibID
                            End With
                            .ExecuteNonQuery()
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            FacultyStatDetail = dsData.Tables("tblResult")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose : CreatedDateStat
        ' Input: intCreatedDate
        ' Output: Datatable
        ' Created by: Sondp
        Public Function CreatedDateStat(ByVal intCreatedDate As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatron_StatCreateDate"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intCreatedDate", SqlDbType.Int)).Value = intCreatedDate
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            End With
                            .ExecuteNonQuery()
                            SqlDataAdapter.SelectCommand = SqlCommand
                            sqlDataAdapter.Fill(dsData, "Cir_spPatron_StatCreateDate")
                            CreatedDateStat = dsData.Tables("Cir_spPatron_StatCreateDate")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("Cir_spPatron_StatCreateDate")
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "PATRON.SP_CIR_PATRON_STATCREATEDDATE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intCreatedDate", OracleType.Number)).Value = intCreatedDate
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "SP_CIR_PATRON_STATCREATEDDATE")
                            CreatedDateStat = dsData.Tables("SP_CIR_PATRON_STATCREATEDDATE")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("SP_CIR_PATRON_STATCREATEDDATE")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose : ExpiredDateStat
        ' Input: intExpriedDate
        ' Output: Datatable
        ' Created by: Sondp
        Public Function ExpiredDateStat(ByVal intExpiredDate As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatron_StatExpiredDate"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intExpiredDate", SqlDbType.Int)).Value = intExpiredDate
                                .Add(New SqlParameter("@intLibId", SqlDbType.Int)).Value = intLibID
                            End With
                            .ExecuteNonQuery()
                            SqlDataAdapter.SelectCommand = SqlCommand
                            sqlDataAdapter.Fill(dsData, "Cir_spPatron_StatExpiredDate")
                            ExpiredDateStat = dsData.Tables("Cir_spPatron_StatExpiredDate")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("Cir_spPatron_StatExpiredDate")
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "PATRON.SP_CIR_PATRON_STATEXPIREDDATE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intExpiredDate", OracleType.Number)).Value = intExpiredDate
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "SP_CIR_PATRON_STATEXPIREDDATE")
                            ExpiredDateStat = dsData.Tables("SP_CIR_PATRON_STATEXPIREDDATE")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("SP_CIR_PATRON_STATEXPIREDDATE")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose : OccupationStat
        ' Input: strOccupationIDs
        ' Output: Datatable
        ' Created by: Sondp
        Public Function OccupationStat(ByVal strOccupationIDs As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatron_StatOccupation"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strOccupationIDs", SqlDbType.VarChar, 200)).Value = strOccupationIDs
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            sqlDataAdapter.Fill(dsData, "Cir_spPatron_StatOccupation")
                            OccupationStat = dsData.Tables("Cir_spPatron_StatOccupation")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("Cir_spPatron_StatOccupation")
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "PATRON.SP_CIR_PATRON_STATOCCUPATION"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strOccupationIDs", OracleType.VarChar, 200)).Value = strOccupationIDs
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "SP_CIR_PATRON_STATOCCUPATION")
                            OccupationStat = dsData.Tables("SP_CIR_PATRON_STATOCCUPATION")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("SP_CIR_PATRON_STATOCCUPATION")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose : CollegeStat
        ' Created by: Sondp
        Public Function CollegeStat() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spDicCollege_StatCollege"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intLibId", SqlDbType.Int)).Value = intLibID
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "Cir_spDicCollege_StatCollege")
                            CollegeStat = dsData.Tables("Cir_spDicCollege_StatCollege")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            dsData.Tables.Remove("Cir_spDicCollege_StatCollege")
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "PATRON.SP_CIR_PATRON_STATCOLLEGE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "SP_CIR_PATRON_STATCOLLEGE")
                            CollegeStat = dsData.Tables("SP_CIR_PATRON_STATCOLLEGE")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("SP_CIR_PATRON_STATCOLLEGE")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose: GradeStat
        ' Input: intCollegeID
        ' Output: Datatable
        ' Created by: Sondp
        Public Function GradeStat(ByVal intCollegeID As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatronUniversity_StatGrade"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intCollegeID", SqlDbType.Int)).Value = intCollegeID
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            sqlDataAdapter.Fill(dsData, "Cir_spPatronUniversity_StatGrade")
                            GradeStat = dsData.Tables("Cir_spPatronUniversity_StatGrade")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("Cir_spPatronUniversity_StatGrade")
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "PATRON.SP_CIR_PATRON_STATGRADE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intCollegeID", OracleType.Number)).Value = intCollegeID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "SP_CIR_PATRON_STATGRADE")
                            GradeStat = dsData.Tables("SP_CIR_PATRON_STATGRADE")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("SP_CIR_PATRON_STATGRADE")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose: ClassStat
        ' Input: intFacultyID
        ' Output: Datatable
        ' Creator: Sondp
        Public Function ClassStat(ByVal intFacultyID As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatronUniversity_StatClass"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intFacultyID", SqlDbType.Int)).Value = intFacultyID
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            ClassStat = dsData.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "PATRON.SP_CIR_PATRON_STATCLASS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intFacultyID", OracleType.Number)).Value = intFacultyID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            ClassStat = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose : Top20Stat
        ' Input: strTypeStatistic
        ' Created by: Sondp
        Public Function Top20Stat(ByVal strTypeStatistic As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatron_StatisticTop20"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strTypeStatistic", SqlDbType.VarChar, 20)).Value = strTypeStatistic
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            sqlDataAdapter.Fill(dsData, "Cir_spPatron_StatisticTop20")
                            Top20Stat = dsData.Tables("Cir_spPatron_StatisticTop20")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("Cir_spPatron_StatisticTop20")
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "PATRON.SP_CIR_PATRON_STATISTIC_TOP20"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strTypeStatistic", OracleType.VarChar, 20)).Value = strTypeStatistic
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "SP_CIR_PATRON_STATISTIC_TOP20")
                            Top20Stat = dsData.Tables("SP_CIR_PATRON_STATISTIC_TOP20")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("SP_CIR_PATRON_STATISTIC_TOP20")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function Top20StatDetail(ByVal strTypeStatistic As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spPatron_StatisticTop20_Detail"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strTypeStatistic", SqlDbType.VarChar, 20)).Value = strTypeStatistic
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "Cir_spPatron_StatisticTop20_Detail")
                            Top20StatDetail = dsData.Tables("Cir_spPatron_StatisticTop20_Detail")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("Cir_spPatron_StatisticTop20_Detail")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Private Sub FormSQLSimple()
            Dim strWhere As String
            Dim strFrom As String
            Dim strTop As String
            Dim strTmp As String

            strFrom = " Cir_tblPatron "
            If lngSelectTop <> 0 Then
                Select Case UCase(strDBServer)
                    Case "ORACLE"
                        strTop = ""
                    Case Else
                        strTop = " TOP " & CStr(lngSelectTop)
                End Select
            Else
                strTop = ""
            End If
            strWhere = ""
            strSQL = "SELECT " & strTop & " Cir_tblPatron.ID FROM "


            ' so the
            If Trim(strCode) <> "" Then
                '//Chinhnh modify ngay 08-08-2008
                If InStr(Trim(strCode), "-") > 0 Then
                    strCode = XuLyChuoi(Trim(strCode))
                End If
                strCode = UCase(strCode)
                strCode = Replace(strCode, ",", "' OR UPPER(Code)='")
                strWhere = strWhere & " AND (UPPER(Code)='" & Trim(strCode) & "') "


                '//Het (Chinhnh modify ngay 08-08-2008)
            End If
            ' tu ID
            If strFromCode <> "" Then
                strWhere = strWhere & " AND UPPER(Code) >= UPPER('" & strFromCode & "') "
            End If
            ' den ID
            If strToCode <> "" Then
                strWhere = strWhere & " AND UPPER(Code) <= UPPER('" & strToCode & "') "
            End If
            ' tu ngay cap
            If Trim(strFromValidDate) <> "" Then
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        strWhere = strWhere & " AND ValidDate >= '" & strFromValidDate & "'"
                    Case "ORACLE"
                        strWhere = strWhere & " AND ValidDate >= TO_DATE('" & strFromValidDate & "','mm/dd/yyyy')"
                End Select
            End If
            ' den ngay cap
            If Trim(strToValidDate) <> "" Then
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        strWhere = strWhere & " AND ValidDate <= '" & strToValidDate & "'"
                    Case "ORACLE"
                        strWhere = strWhere & " AND ValidDate <= TO_DATE('" & strToValidDate & "','mm/dd/yyyy')"
                End Select
            End If
            ' ngay cap
            If Trim(strValidDate) <> "" Then
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        strWhere = strWhere & " AND ValidDate='" & strValidDate & "'"
                    Case "ORACLE"
                        strWhere = strWhere & " AND ValidDate= TO_DATE('" & strValidDate & "','mm/dd/yyyy')"
                End Select
            End If
            ' ngay het han
            If Trim(strExpiredDate) <> "" Then
                Select Case strDBServer.ToUpper
                    Case "SQLSERVER"
                        strWhere = strWhere & " AND ExpiredDate='" & Trim(strExpiredDate) & "'"
                    Case "ORACLE"
                        strWhere = strWhere & " AND ExpiredDate= TO_DATE('" & Trim(strExpiredDate) & "','mm/dd/yyyy')"
                End Select
            End If
            ' 
            If Trim(strLastIssuedDate) <> "" Then
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        strWhere = strWhere & " AND LastIssuedDate='" & strLastIssuedDate & "'"
                    Case "ORACLE"
                        strWhere = strWhere & " AND LastIssuedDate=TO_DATE('" & strLastIssuedDate & "','mm/dd/yyyy')"
                End Select
            End If
            ' ho va ten
            If Trim(strFullName) <> "" Then
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        strWhere = strWhere & " AND Lower (FirstName  + Case When (MiddleName is null or RTrim(MiddleName)  = '') Then '' Else ' ' +  MiddleName END + Case When (LastName is null) Then '' Else ' ' + LastName END )" & Me.GenOpeAbsolute(2) & "'%" & Trim(strFullName.ToLower()) & "%'"
                    Case "ORACLE"
                        strWhere = strWhere & " AND Upper(FirstName || ' ' || case nvl(MiddleName,'0') when '0' then '' else  (MiddleName  || ' ') end || LastName) " & Me.GenOpeAbsolute(2) & "Upper('" & Trim(strFullName) & "')"
                End Select
            End If
            ' ngay sinh
            If Trim(strDOB) <> "" Then
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        strWhere = strWhere & " AND DOB='" & strDOB & "'"
                    Case "ORACLE"
                        strWhere = strWhere & " AND DOB=TO_DATE('" & strDOB & "','mm/dd/yyyy')"
                End Select
            End If
            ' dan toc
            If intEthnicID <> 0 Then
                strWhere = strWhere & " AND EthnicID=" & intEthnicID
            End If
            ' trinh do
            If intEducationID <> 0 Then
                strWhere = strWhere & " AND EducationID=" & intEducationID
            End If
            ' nghe nghiep
            If intOccupationID <> 0 Then
                strWhere = strWhere & " AND OccupationID=" & intOccupationID
            End If
            ' dia chi CQ
            If Trim(strWorkPlace) <> "" Then
                Select Case strDBServer
                    Case "SQLSERVER"
                        strWhere = strWhere & " AND WorkPlace " & Me.GenOpeAbsolute(3) & "'" & Trim(strWorkPlace) & "'"
                    Case Else
                        strWhere = strWhere & " AND UPPER(WorkPlace) " & Me.GenOpeAbsolute(3) & "'" & Trim(UCase(strWorkPlace)) & "'"
                End Select
            End If
            ' so di dong
            If Trim(strMobile) <> "" Then
                strWhere = strWhere & " AND Mobile " & Me.GenOpeAbsolute(4) & " '" & Trim(strMobile) & "'"
            End If
            ' dia chi email
            If Trim(strEmail) <> "" Then
                strWhere = strWhere & " AND Email " & Me.GenOpeAbsolute(5) & " '" & Trim(strEmail) & "'"
            End If
            ' ngay sua cuoi cung
            If Trim(strLastModifiedDate) <> "" Then
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        strWhere = strWhere & " AND LastModifiedDate='" & strLastModifiedDate & "'"
                    Case "ORACLE"
                        strWhere = strWhere & " AND LastModifiedDate=TO_DATE('" & strLastModifiedDate & "','mm/dd/yyyy')"
                End Select
            End If
            ' loc theo nhom ban doc
            If strPatronGroupID <> "" Then
                strWhere = strWhere & " AND PatronGroupID IN(" & strPatronGroupID & ")"
            End If
            'loc theo gioi tinh
            If bytSex = 0 Or bytSex = 1 Then
                strWhere = strWhere & " AND Sex=" & bytSex
            End If
            ' loc theo truong
            If Trim(strCollege) <> "" Then
                strFrom = strFrom & ",CIR_DIC_COLLEGE,Cir_tblPatronUniversity "
                Select Case strDBServer
                    Case "SQLSERVER"
                        strWhere = strWhere & " AND CIR_DIC_COLLEGE.College " & Me.GenOpeAbsolute(2) & "'" & Trim(strCollege) & "' AND CIR_DIC_COLLEGE.ID=Cir_tblPatronUniversity.CollegeID AND Cir_tblPatronUniversity.PatronID=Cir_tblPatron.ID"
                    Case Else
                        strWhere = strWhere & " AND UPPER(CIR_DIC_COLLEGE.College) " & Me.GenOpeAbsolute(2) & "'" & Trim(UCase(strCollege)) & "' AND CIR_DIC_COLLEGE.ID=Cir_tblPatronUniversity.CollegeID AND Cir_tblPatronUniversity.PatronID=Cir_tblPatron.ID"
                End Select
            End If
            ' loc theo khoa
            If Trim(intFaculty) <> 0 Then
                If InStr(strFrom, "Cir_tblPatronUniversity") = 0 Then
                    strFrom = strFrom & ",Cir_tblPatronUniversity "
                End If
                strWhere = strWhere & " AND Cir_tblPatronUniversity.FacultyID=" & intFaculty
                If InStr(strWhere, "Cir_tblPatronUniversity.PatronID=Cir_tblPatron.ID") = 0 Then
                    strWhere = strWhere & "  AND Cir_tblPatronUniversity.PatronID=Cir_tblPatron.ID"
                End If
            End If
            ' loc theo khoas
            If Trim(strGrade) <> "" Then
                If InStr(strFrom, "Cir_tblPatronUniversity") = 0 Then
                    strFrom = strFrom & ",Cir_tblPatronUniversity "
                End If
                Select Case strDBServer
                    Case "SQLSERVER"
                        strWhere = strWhere & " AND Cir_tblPatronUniversity.Grade " & Me.GenOpeAbsolute(2) & "'" & Trim(strGrade) & "'"
                    Case Else
                        strWhere = strWhere & " AND UPPER(Cir_tblPatronUniversity.Grade) " & Me.GenOpeAbsolute(2) & "'" & Trim(UCase(strGrade)) & "'"
                End Select
                If InStr(strWhere, "Cir_tblPatronUniversity.PatronID=Cir_tblPatron.ID") = 0 Then
                    strWhere = strWhere & " AND Cir_tblPatronUniversity.PatronID=Cir_tblPatron.ID"
                End If
            End If
            ' loc theo lop
            If Trim(strClass) <> "" Then
                strTmp = ""
                If InStr(strFrom, "Cir_tblPatronUniversity") = 0 Then
                    strFrom = strFrom & ",Cir_tblPatronUniversity "
                End If
                Select Case strDBServer
                    Case "SQLSERVER"
                        strWhere = strWhere & " AND Cir_tblPatronUniversity.Class " & Me.GenOpeAbsolute(2) & "'" & Trim(strClass) & "'"
                    Case Else
                        strWhere = strWhere & " AND UPPER(Cir_tblPatronUniversity.Class) " & Me.GenOpeAbsolute(2) & "'" & UCase(Trim(strClass)) & "'"
                End Select
                If InStr(strWhere, "Cir_tblPatronUniversity.PatronID=Cir_tblPatron.ID") = 0 Then
                    strWhere = strWhere & " AND Cir_tblPatronUniversity.PatronID=Cir_tblPatron.ID"
                End If
            End If
            ' loc theo dia chi
            If Trim(strAddress) <> "" Then
                strFrom = strFrom & ",Cir_tblPatronOtherAddr "
                Select Case strDBServer
                    Case "SQLSERVER"
                        strWhere = strWhere & " AND Cir_tblPatronOtherAddr.Address " & Me.GenOpeAbsolute(2) & "'" & Trim(strAddress) & "' AND Cir_tblPatronOtherAddr.PatronID=Cir_tblPatron.ID"
                    Case Else
                        strWhere = strWhere & " AND UPPER(Cir_tblPatronOtherAddr.Address) " & Me.GenOpeAbsolute(2) & "'" & UCase(Trim(strAddress)) & "' AND Cir_tblPatronOtherAddr.PatronID=Cir_tblPatron.ID"
                End Select
            End If

            If Len(Trim(strWhere)) >= 4 Then
                strWhere = Right(Trim(strWhere), Len(Trim(strWhere)) - 4)
            End If
            If bytPrintCard = 1 Then
                If Trim(strWhere) <> "" Then
                    strWhere &= " AND ID IN(SELECT PATRONID FROM CIR_PRINTED_CARD)"
                Else
                    strWhere &= " 1=1 AND ID IN(SELECT PATRONID FROM CIR_PRINTED_CARD)"
                End If

            End If
            strSQL = strSQL & strFrom
            If Trim(strWhere) <> "" Then
                strSQL = strSQL & " WHERE " & strWhere & " and ( LibId = " + intLibID.ToString() + " or LibId = 0 )"
                Select Case UCase(strDBServer)
                    Case "ORACLE"
                        If lngSelectTop = 0 Then
                        Else
                            strSQL = strSQL & " AND ROWNUM<=" & CStr(lngSelectTop)
                        End If
                    Case Else
                End Select
            Else
                strSQL = strSQL & " WHERE (  LibId = " + intLibID.ToString() + " or LibId = 0 )"
                Select Case UCase(strDBServer)
                    Case "ORACLE"
                        If lngSelectTop = 0 Then
                        Else
                            strSQL = strSQL & " WHERE ROWNUM<=" & CStr(lngSelectTop)
                        End If
                    Case Else
                End Select
            End If

            Select Case bytOrderBy
                Case 1
                    strSQL = strSQL & " ORDER BY Cir_tblPatron.ValidDate "
                Case 2
                    strSQL = strSQL & " ORDER BY Cir_tblPatron.ExpiredDate "
                Case 4
                    strSQL = strSQL & " ORDER BY Cir_tblPatron.Code "
                Case 5 'First Name
                    strSQL = strSQL & " ORDER BY Cir_tblPatron.FirstName "
                Case 6 'Last Name
                    strSQL = strSQL & " ORDER BY Cir_tblPatron.LastName "
                Case Else
                    strSQL = strSQL & " ORDER BY Cir_tblPatron.ID "
            End Select

            'strSQL = strSQL & " " & Me.GenOrderBy
        End Sub
        Function XuLyChuoi(ByVal str As String) As String
            Dim arr() As String
            arr = Split(str, "-")
            If arr.Length < 1 Then
                Exit Function
            End If
            Dim strEnd As String = arr(1).Trim
            Dim strStart As String = arr(0).Trim
            Dim strStartSimple As String = strStart.Remove(strStart.Length - strEnd.Length, strEnd.Length)

            Dim IntEnd As Int32 = 0
            Dim IntStart As Int32 = 0
            Try
                IntEnd = CInt(strEnd)
                IntStart = CInt(strStart.Remove(0, strStart.Length - strEnd.Length))
            Catch ex As Exception
                'Exit Function
            End Try
            Dim strReturn As String = strStart
            For i As Int32 = IntStart + 1 To IntEnd
                strReturn += "," + FullText(strStart, strStartSimple, i)
            Next
            Return strReturn
        End Function
        Function FullText(ByVal str As String, ByVal strSimple As String, ByVal i As Int32) As String
            FullText = strSimple + i.ToString
            If (FullText.Length < str.Length) Then
                While ((strSimple + i.ToString).Length < str.Length)
                    strSimple += "0"
                End While
            End If
            Return strSimple + i.ToString
        End Function
        Private Sub FormSQLAdvance()
            Dim strWhere As String
            Dim strFrom As String
            Dim strTop As String
            Dim strJoin As String
            strJoin = ""
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    strTop = ""
                Case Else
                    If lngSelectTop > 0 Then
                        strTop = " TOP " & CStr(lngSelectTop)
                    Else
                        strTop = ""
                    End If
            End Select
            strWhere = " "
            strFrom = ""
            Select Case bytOrderBy
                Case 1 ' ValidDate
                    strSQL = "SELECT DISTINCT " & strTop & " Cir_tblPatron.ID,ValidDate FROM Cir_tblPatron "
                Case 2 ' ExpiredDate
                    strSQL = "SELECT DISTINCT " & strTop & " Cir_tblPatron.ID,ExpiredDate FROM Cir_tblPatron "
                Case 3 ' DOB
                    strSQL = "SELECT DISTINCT " & strTop & " Cir_tblPatron.ID,DOB FROM Cir_tblPatron"
                Case 4 ' Code
                    strSQL = "SELECT DISTINCT " & strTop & " Cir_tblPatron.ID,Code FROM Cir_tblPatron"
                Case 5 'First Name
                    strSQL = "SELECT DISTINCT " & strTop & " Cir_tblPatron.ID,FirstName FROM Cir_tblPatron "
                Case 6 'Last Name
                    strSQL = "SELECT DISTINCT " & strTop & " Cir_tblPatron.ID,LastName FROM Cir_tblPatron "
                Case Else
                    strSQL = "SELECT DISTINCT " & strTop & " Cir_tblPatron.ID FROM Cir_tblPatron "
            End Select

            ' text thu nhat------------------------
            If Trim(strFieldValue1) <> "" Then
                strWhere = strWhere & " " & Me.GenFieldNameText(bytFieldName1) & " "
                If UCase(strDBServer) = "ORACLE" Then
                    strWhere = "UPPER(" & strWhere & ")"
                End If
                strWhere = strWhere & Me.GenOpeAbsolute(bytFieldName1)
                If Trim(strWhere) <> "" Then

                    strWhere = strWhere & "'" & strFieldValue1 & "'"
                End If
                strJoin = Me.GenExpWhereText(strWhere, bytFieldName1)
                strFrom = strFrom & " " & Me.GenSQLFromText(strFrom, bytFieldName1)
            End If
            ' text thu 2------------------------
            If Trim(strFieldValue2) <> "" Then
                If Trim(strWhere) <> "" Then
                    strWhere = strWhere & " " & strOperator1
                End If
                strWhere = strWhere & " " & Me.GenFieldNameText(bytFieldName2) & " "
                strWhere = strWhere & Me.GenOpeAbsolute(bytFieldName2)
                If Trim(strWhere) <> "" Then
                    strWhere = strWhere & "'" & strFieldValue2 & "'"
                End If
                If strJoin = "" Then
                    strJoin = Me.GenExpWhereText(strWhere, bytFieldName2)
                Else
                    If strJoin <> Me.GenExpWhereText(strWhere, bytFieldName2) Then
                        strJoin = strJoin & Me.GenExpWhereText(strWhere, bytFieldName2)
                    End If
                End If
                strFrom = strFrom & " " & Me.GenSQLFromText(strFrom, bytFieldName2)
            End If
            ' date thu nhat------------------------
            If Trim(strFieldValueFrom1) = "" And Trim(strFieldValueTo1) = "" Then
                ' truong hop nay khong xly
            Else
                ' lay dieu kien =, >=
                Select Case bytFieldOpeFrom1
                    Case 1 ' =
                        If Trim(strFieldValueFrom1) <> "" Then
                            If Trim(strWhere) <> "" Then
                                strWhere = strWhere & " " & strOperator2
                            End If
                            strWhere = strWhere & " " & Me.GenFieldNameDate(bytFieldNameDate1) & " =" & Me.GenFormatDateTime(strFieldValueFrom1)
                        End If
                    Case 2 ' >=
                        Dim strAddSQL As String
                        If Trim(strFieldValueFrom1) <> "" Then
                            strAddSQL = " (" & Me.GenFieldNameDate(bytFieldNameDate1) & " >=" & Me.GenFormatDateTime(strFieldValueFrom1)
                        End If
                        If Trim(strFieldValueTo1) <> "" Then
                            If strAddSQL <> "" Then
                                strAddSQL = strAddSQL & " AND "
                            Else
                                strAddSQL = " ("
                            End If
                            strAddSQL = strAddSQL & Me.GenFieldNameDate(bytFieldNameDate1) & " <=" & Me.GenFormatDateTime(strFieldValueTo1) & ")"
                        Else
                            If strAddSQL <> "" Then
                                strAddSQL = strAddSQL & ") "
                            End If
                        End If
                        If strAddSQL <> "" And Trim(strWhere) <> "" Then
                            strWhere = strWhere & " " & strOperator2 & " " & strAddSQL
                        Else
                            strWhere = strWhere & " 1=1 " & strOperator2 & " " & strAddSQL
                        End If
                End Select
            End If
            ' date thu 2 ------------------------
            If Trim(strFieldValueFrom2) = "" And Trim(strFieldValueTo2) = "" Then
                ' truong hop nay khong xly
            Else
                ' lay dieu kien =, >=
                Select Case bytFieldOpeFrom2
                    Case 1 ' =
                        If Trim(strFieldValueFrom2) <> "" Then
                            If Trim(strWhere) <> "" Then
                                strWhere = strWhere & " " & strOperator3
                            End If
                            strWhere = strWhere & " " & Me.GenFieldNameDate(bytFieldNameDate2) & " =" & Me.GenFormatDateTime(strFieldValueFrom2)
                        End If
                    Case 2 ' >=
                        Dim strAddSQL As String
                        If Trim(strFieldValueFrom2) <> "" Then
                            strAddSQL = " (" & Me.GenFieldNameDate(bytFieldNameDate2) & " >=" & Me.GenFormatDateTime(strFieldValueFrom2)
                        End If
                        If Trim(strFieldValueTo2) <> "" Then
                            If strAddSQL <> "" Then
                                strAddSQL = strAddSQL & " AND "
                            Else
                                strAddSQL = " ("
                            End If
                            strAddSQL = strAddSQL & Me.GenFieldNameDate(bytFieldNameDate2) & " <=" & Me.GenFormatDateTime(strFieldValueTo2) & ")"
                        Else
                            If strAddSQL <> "" Then
                                strAddSQL = strAddSQL & ") "
                            End If
                        End If
                        If strAddSQL <> "" And Trim(strWhere) <> "" Then
                            strWhere = strWhere & " " & strOperator3 & " " & strAddSQL
                        Else
                            strWhere = strWhere & " 1=1 " & strOperator3 & " " & strAddSQL
                        End If
                End Select
            End If
            ' dieu kien option thu 1---------------------
            If intFieldValueOther1 <> 0 Then
                If Trim(strWhere) <> "" Then
                    strWhere = strWhere & " " & strOperator4
                End If
                If bytFieldNameOther1 = 8 Then ' truong hop selection=SEX
                    strWhere = strWhere & " Sex=" & intFieldValueOther1 - 1
                Else
                    strWhere = strWhere & " " & Me.GenFieldNameOther(bytFieldNameOther1) & "=" & intFieldValueOther1
                End If
                If strJoin = "" Then
                    strJoin = Me.GenExpWhereOther(strWhere, bytFieldNameOther1)
                Else
                    If strJoin <> Me.GenExpWhereOther(strWhere, bytFieldNameOther1) Then
                        strJoin = strJoin & Me.GenExpWhereOther(strWhere, bytFieldNameOther1)
                    End If
                End If
                strFrom = strFrom & " " & Me.GenSQLFromOther(strFrom, bytFieldNameOther1)
            End If
            ' dieu kien option thu 2---------------------
            If intFieldValueOther2 <> 0 Then
                If Trim(strWhere) <> "" Then
                    strWhere = strWhere & " " & strOperator5
                End If
                If bytFieldNameOther2 = 8 Then ' truong hop selection=SEX
                    strWhere = strWhere & " " & Me.GenFieldNameOther(bytFieldNameOther2) & "=" & intFieldValueOther2 - 1
                Else
                    strWhere = strWhere & " " & Me.GenFieldNameOther(bytFieldNameOther2) & "=" & intFieldValueOther2
                End If
                If strJoin = "" Then
                    strJoin = Me.GenExpWhereOther(strWhere, bytFieldNameOther2)
                Else
                    If strJoin <> Me.GenExpWhereOther(strWhere, bytFieldNameOther2) Then
                        strJoin = strJoin & Me.GenExpWhereOther(strWhere, bytFieldNameOther2)
                    End If
                End If
                strFrom = strFrom & " " & Me.GenSQLFromOther(strFrom, bytFieldNameOther2)
            End If
            strSQL = strSQL & " " & strFrom
            If strWhere.Trim <> "" Then
                strSQL = strSQL & " WHERE " & strWhere & strJoin & " and ( LibId = " + intLibID.ToString() + " or " & intLibID.ToString() & " = 0 )"
                If lngSelectTop > 0 Then
                    Select Case UCase(strDBServer)
                        Case "ORACLE"
                            strSQL = strSQL & " AND ROWNUM<=" & CStr(lngSelectTop)
                        Case Else
                    End Select
                End If
            Else
                If lngSelectTop > 0 Then
                    Select Case UCase(strDBServer)
                        Case "ORACLE"
                            strSQL = strSQL & " WHERE ROWNUM<=" & CStr(lngSelectTop)
                        Case Else
                            strSQL = strSQL & " WHERE  ( LibId = " + intLibID.ToString() + " or " & intLibID.ToString() & " = 0 )"

                    End Select
                End If
            End If
            If bytOrderBy > 0 Then
                strSQL = strSQL & " " & Me.GenOrderBy
            End If
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    strSQL = UCase(strSQL)
            End Select
        End Sub

        Private Function GenOrderBy() As String
            Select Case bytOrderBy
                Case 0 ' No Order
                    GenOrderBy = ""
                Case 1 ' ValidDate
                    GenOrderBy = " ORDER BY ValidDate"
                Case 2 ' ExpiredDate
                    GenOrderBy = " ORDER BY ExpiredDate"
                Case 3 ' DOB
                    GenOrderBy = " ORDER BY DOB"
                Case 4 ' Code
                    GenOrderBy = " ORDER BY Code"
                Case 5 'First Name
                    GenOrderBy = " ORDER BY FirstName"
                Case 6 'Last Name
                    GenOrderBy = " ORDER BY LastName"
            End Select
        End Function

        Private Function GenSQLFromOther(ByVal strFrom As String, ByVal bytFieldNameOther As Byte) As String
            Dim strTmp As String
            strTmp = ""
            Select Case bytFieldNameOther
                Case 1 'faculty
                    If InStr(strFrom, "Cir_tblPatronUniversity") = 0 Then
                        strTmp = ",Cir_tblPatronUniversity "
                    End If
                Case 2 'College
                    If InStr(strFrom, "Cir_tblPatronUniversity") = 0 Then
                        strTmp = ",Cir_tblPatronUniversity "
                    End If
                Case 3 'Education
                    strTmp = ""
                Case 4 'Ethnic
                    strTmp = ""
                Case 5 'Occupation
                    strTmp = ""
                Case 6 'Province
                    If InStr(strFrom, "Cir_tblPatronOtherAddr") = 0 Then
                        strTmp = ",Cir_tblPatronOtherAddr "
                    End If
                Case 7 'PatronGroup
                    strTmp = ""
                Case 8 'Sex
                    strTmp = ""
                Case Else
                    strTmp = ""
            End Select
            GenSQLFromOther = strTmp
        End Function
        Private Function GenExpWhereOther(ByVal strwhere As String, ByVal bytFieldOther As Byte) As String
            Dim strTmp As String
            strTmp = ""
            Select Case bytFieldOther
                Case 1 'faculty
                    If InStr(strwhere, "(Cir_tblPatron.ID=Cir_tblPatronUniversity.PATRONID)") = 0 Then
                        strTmp = " And (Cir_tblPatron.ID=Cir_tblPatronUniversity.PATRONID) "
                    End If
                Case 2 ' college
                    If InStr(strwhere, "(Cir_tblPatron.ID=Cir_tblPatronUniversity.PATRONID)") = 0 Then
                        strTmp = " And (Cir_tblPatron.ID=Cir_tblPatronUniversity.PATRONID) "
                    End If
                Case 3 ' education
                    strTmp = ""
                Case 4 ' Ethnic
                    strTmp = ""
                Case 5 ' Occupation
                    strTmp = ""
                Case 6 ' Province
                    If InStr(strwhere, "(Cir_tblPatron.ID=Cir_tblPatronOtherAddr.PATRONID)") = 0 Then
                        strTmp = " And (Cir_tblPatron.ID=Cir_tblPatronOtherAddr.PATRONID) "
                    End If
                Case 7 ' PatronGroup
                    strTmp = ""
                Case 8 ' Sex
                    strTmp = ""
                Case Else
                    strTmp = ""
            End Select
            GenExpWhereOther = strTmp
        End Function
        Private Function GenFieldNameOther(ByVal bytFieldNameOther As Byte) As String
            Select Case bytFieldNameOther
                Case 1 ' faculty
                    GenFieldNameOther = "Cir_tblPatronUniversity.FacultyID"
                Case 2 ' college
                    GenFieldNameOther = "Cir_tblPatronUniversity.CollegeID"
                Case 3 ' education
                    GenFieldNameOther = "EducationID"
                Case 4 ' ethnic
                    GenFieldNameOther = "EthnicID"
                Case 5 'occupation
                    GenFieldNameOther = "OccupationID"
                Case 6 ' province
                    GenFieldNameOther = "Cir_tblPatronOtherAddr.ProvinceID"
                Case 7 ' PatronGroup
                    GenFieldNameOther = "PatronGroupID"
                Case 8 ' sex
                    GenFieldNameOther = "Sex"
            End Select
        End Function

        Private Function GenFieldNameDate(ByVal bytFieldNameDate As Byte) As String
            Select Case bytFieldNameDate
                Case 1
                    GenFieldNameDate = "DOB"
                Case 2
                    GenFieldNameDate = "ValidDate"
                Case 3
                    GenFieldNameDate = "ExpiredDate"
            End Select
        End Function

        Private Function GenFieldNameText(ByVal bytFieldNameText As Byte) As String
            Select Case bytFieldNameText
                Case 1
                    GenFieldNameText = "Code"
                Case 2
                    Select Case UCase(strDBServer)
                        Case "SQLSERVER"
                            GenFieldNameText = "FirstName + ' ' + ISNULL(MiddleName  + ' ','') + LastName"
                        Case "ORACLE"
                            GenFieldNameText = "Upper(FirstName || ' ' || NVL(MiddleName  || ' ','') || LastName)"
                    End Select
                Case 3
                    GenFieldNameText = "WorkPlace"
                Case 4
                    GenFieldNameText = "Mobile"
                Case 5
                    GenFieldNameText = "Email"
                Case 6
                    GenFieldNameText = "Class"
                Case 7
                    GenFieldNameText = "Grade"
                Case 8
                    GenFieldNameText = "Address"
            End Select
        End Function

        Private Function GenSQLFromText(ByVal strFrom As String, ByVal bytFieldNameText As Byte) As String
            Dim strTmp As String
            strTmp = ""
            Select Case bytFieldNameText
                Case 6 ' Class
                    If InStr(strFrom, "Cir_tblPatronUniversity") = 0 Then
                        strTmp = ",Cir_tblPatronUniversity "
                    End If
                Case 7 ' Grade
                    If InStr(strFrom, "Cir_tblPatronUniversity") = 0 Then
                        strTmp = ",Cir_tblPatronUniversity "
                    End If
                Case 8 ' Address
                    If InStr(strFrom, "Cir_tblPatronOtherAddr") = 0 Then
                        strTmp = ",Cir_tblPatronOtherAddr "
                    End If
                Case Else
                    strTmp = ""
            End Select
            GenSQLFromText = strTmp
        End Function

        Private Function GenExpWhereText(ByVal strWhere As String, ByVal bytFieldNameText As Byte) As String
            Dim strTmp As String
            strTmp = ""
            Select Case bytFieldNameText
                Case 7 ' Grade
                    If InStr(strWhere, "(Cir_tblPatron.ID=Cir_tblPatronUniversity.PATRONID)") = 0 Then
                        strTmp = " AND (Cir_tblPatron.ID=Cir_tblPatronUniversity.PATRONID) "
                    End If
                Case 6 ' Class
                    If InStr(strWhere, "(Cir_tblPatron.ID=Cir_tblPatronUniversity.PATRONID)") = 0 Then
                        strTmp = " AND (Cir_tblPatron.ID=Cir_tblPatronUniversity.PATRONID) "
                    End If
                Case 8 ' Address
                    If InStr(strWhere, "(Cir_tblPatron.ID=Cir_tblPatronOtherAddr.PATRONID)") = 0 Then
                        strTmp = " AND (Cir_tblPatron.ID=Cir_tblPatronOtherAddr.PATRONID) "
                    End If
                Case Else
                    strTmp = ""
            End Select
            GenExpWhereText = strTmp
        End Function

        Private Function GenFormatDateTime(ByVal strValue As String) As String
            If Trim(strValue) <> "" Then
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        GenFormatDateTime = "'" & strValue & "'"
                    Case "ORACLE"
                        GenFormatDateTime = "TO_DATE('" & strValue & "','mm/dd/yyyy')"
                End Select
            Else
                GenFormatDateTime = strValue
            End If
        End Function

        Private Function GenOpeAbsolute(ByVal bytFieldNameText As Byte) As String
            Dim blnUNI As Boolean
            Select Case bytFieldNameText
                Case 1 ' code
                    blnUNI = False
                Case 2 'FullName
                    blnUNI = True
                Case 3 'WorkPlace
                    blnUNI = True
                Case 4 'Mobile
                    blnUNI = False
                Case 5 'Email
                    blnUNI = False
                Case 7 'Grade
                    blnUNI = True
                Case 6 'Class
                    blnUNI = True
                Case 8 'Address
                    blnUNI = True
            End Select
            Dim strTmp As String
            strTmp = ""
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    If blnUNI Then
                        strTmp = " LIKE N"
                    Else
                        strTmp = " LIKE "
                    End If
                Case "ORACLE"
                    strTmp = " LIKE "
            End Select
            GenOpeAbsolute = strTmp
        End Function

        Public Function Search() As DataTable
            Call OpenConnection()
            Select Case UCase(strTypeSearch)
                Case "ADVANCE"
                    FormSQLAdvance()
                Case Else
                    FormSQLSimple()
            End Select
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    Try
                        oraCommand.CommandText = strSQL
                        oraCommand.CommandType = CommandType.Text
                        oraDataAdapter = New OracleDataAdapter(oraCommand)
                        oraDataAdapter.Fill(dsData, "TblResultSearch")
                        Search = dsData.Tables("TblResultSearch")
                        dsData.Tables.Remove("TblResultSearch")
                    Catch ex As OracleException
                        intErrorCode = ex.Code
                        strErrorMsg = ex.Message.ToString
                    End Try
                Case "SQLSERVER"
                    Try
                        SqlCommand.CommandText = strSQL
                        SqlCommand.CommandType = CommandType.Text
                        SqlDataAdapter.SelectCommand = SqlCommand
                        sqlDataAdapter.Fill(dsData, "TblResultSearch")
                        Search = dsData.Tables("TblResultSearch")
                        dsData.Tables.Remove("TblResultSearch")
                    Catch ex As SqlException
                        intErrorCode = ex.Number
                        strErrorMsg = ex.Message.ToString
                    End Try
            End Select
            Call CloseConnection()
        End Function

        ' FormingSQL method
        ' This method used to forming update statement
        ' INPUT: from properties
        ' OUTPUT: update statement
        Public Function FormingSQL() As String
            Dim strSQLPatron As String = ""
            Dim strSQLAddress As String = ""
            Dim strSQLUniversity As String = ""
            Dim strArr() As String
            Dim strFirstName As String = ""
            Dim strLastName As String = ""
            Dim strMiddleName As String = ""
            Dim strTableCP As String = ""
            Dim strTableCPU As String = ""
            Dim strTableCPOA As String = ""
            Dim strTemp As String = ""
            Dim strWHERE As String = ""

            Dim intCount As Int16
            ' Update Text Field
            If Not strNewTextValue = "" Then
                Select Case bytTextFieldIndex
                    Case 6, 7
                        strTableCPU = "Cir_tblPatronUniversity"
                    Case 8
                        strTableCPOA = "Cir_tblPatronOtherAddr"
                    Case Else
                        strTableCP = "Cir_tblPatron"
                End Select
                Select Case UCase(strDBServer)
                    Case "ORACLE"
                        Select Case bytTextFieldIndex
                            Case 1 ' Code
                                strSQLPatron = " Code = '" & strNewTextValue & "'"
                                strCode = strNewTextValue
                                If InStr(strPatronIDs, ",") > 0 Then
                                    intNumOfPatron = 2
                                End If
                            Case 2 ' Parse strNewTextValue to get LastName, FirstName, MiddleName from FullName
                                strArr = Split(strNewTextValue, " ")
                                strFirstName = strArr(0)
                                strLastName = strArr(UBound(strArr))
                                strSQLPatron = " FirstName = '" & strFirstName & "', "
                                strSQLPatron = strSQLPatron & " LastName = '" & strLastName & "'"
                                If UBound(strArr) > 1 Then
                                    For intCount = 1 To UBound(strArr) - 1
                                        strMiddleName = strMiddleName & Trim(strArr(intCount)) & " "
                                    Next
                                    If Not strMiddleName = "" Then
                                        strSQLPatron = strSQLPatron & ", MiddleName = '" & Trim(strMiddleName) & "'"
                                    End If
                                End If
                            Case 3 ' WorkPlace
                                strSQLPatron = " WorkPlace = '" & strNewTextValue & "'"
                            Case 4 ' Mobile
                                strSQLPatron = " Mobile = '" & strNewTextValue & "'"
                            Case 5 ' Email
                                strSQLPatron = " Email = '" & strNewTextValue & "'"
                            Case 6 ' Class
                                strSQLUniversity = " Class = '" & strNewTextValue & "'"
                            Case 7 ' Grade
                                strSQLUniversity = " Grade = '" & strNewTextValue & "'"
                            Case Else ' Address
                                strSQLAddress = " Address = '" & strNewTextValue & "'"
                        End Select
                    Case "SQLSERVER"
                        Select Case bytTextFieldIndex
                            Case 1 ' Code
                                strSQLPatron = " Code = '" & strNewTextValue & "'"
                                strCode = strNewTextValue
                                If InStr(strPatronIDs, ",") > 0 Then
                                    intNumOfPatron = 2
                                End If
                            Case 2 ' Parse strNewTextValue to get LastName, FirstName, MiddleName from FullName
                                strArr = Split(strNewTextValue, " ")
                                strFirstName = strArr(0)
                                strLastName = strArr(UBound(strArr))
                                strMiddleName = ""
                                strSQLPatron = " FirstName = N'" & Trim(strFirstName) & "', "
                                strSQLPatron = strSQLPatron & " LastName = N'" & Trim(strLastName) & "'"
                                If UBound(strArr) > 1 Then
                                    For intCount = 1 To UBound(strArr) - 1
                                        strMiddleName = strMiddleName & Trim(strArr(intCount)) & " "
                                    Next
                                End If
                                If strMiddleName.Trim = "" Then
                                    strSQLPatron = strSQLPatron & ", MiddleName = NULL"
                                Else
                                    strSQLPatron = strSQLPatron & ", MiddleName = N'" & Trim(strMiddleName) & "'"
                                End If
                            Case 3 ' WorkPlace
                                strSQLPatron = " WorkPlace = N'" & strNewTextValue & "'"
                            Case 4 ' Mobile
                                strSQLPatron = " Mobile = '" & strNewTextValue & "'"
                            Case 5 ' Email
                                strSQLPatron = " Email = '" & strNewTextValue & "'"
                            Case 6 ' Class
                                strSQLUniversity = " Class = N'" & strNewTextValue & "'"
                            Case 7 ' Grade
                                strSQLUniversity = " Grade = N'" & strNewTextValue & "'"
                            Case Else ' Address
                                strSQLAddress = " Address = N'" & strNewTextValue & "'"
                        End Select
                End Select
            End If
            ' Update Date Field
            If Not strNewDateValue = "" Then
                strTableCP = "Cir_tblPatron"
                Select Case UCase(strDBServer)
                    Case "ORACLE"
                        Select Case bytDateFieldIndex
                            Case 1 ' DOB
                                strSQLPatron = " DOB = TO_DATE('" & strNewDateValue & "', 'dd/mm/yyyy hh24:mi:ss')" & ", " & strSQLPatron
                            Case 2 ' Validate
                                strSQLPatron = " ValidDate = TO_DATE('" & strNewDateValue & "', 'dd/mm/yyyy hh24:mi:ss')" & ", " & strSQLPatron
                            Case Else ' ExpiredDate
                                strSQLPatron = " ExpiredDate = TO_DATE('" & strNewDateValue & "', 'dd/mm/yyyy hh24:mi:ss')" & ", " & strSQLPatron
                        End Select
                    Case "SQLSERVER"
                        Select Case bytDateFieldIndex
                            Case 1 ' DOB
                                strSQLPatron = " DOB = '" & strNewDateValue & "', " & strSQLPatron
                            Case 2 ' Validate
                                strSQLPatron = " ValidDate = '" & strNewDateValue & "', " & strSQLPatron
                                strWHERE = strWHERE & " AND ISNULL(ExpiredDate,Cast('7/7/3000' as datetime)) > '" & strNewDateValue & "' AND ISNULL(LASTISSUEDDATE,Cast('09/10/1912' as datetime)) <= '" & strNewDateValue & "'"

                            Case Else ' ExpiredDate
                                strSQLPatron = " ExpiredDate = '" & strNewDateValue & "', " & strSQLPatron
                                strWHERE = strWHERE & " AND ISNULL(ValidDate,Cast('09/10/1912' as datetime)) < '" & strNewDateValue & "'"
                        End Select
                End Select
            End If
            ' Update Option Field
            If Not intNewOptionID = 0 Then
                Select Case bytOptionFieldIndex
                    Case 1, 2
                        strTableCPU = "Cir_tblPatronUniversity"
                    Case 6
                        strTableCPOA = "Cir_tblPatronOtherAddr"
                    Case Else
                        strTableCP = "Cir_tblPatron"
                End Select
                Select Case bytOptionFieldIndex
                    Case 1 ' Faculty
                        strSQLUniversity = " FacultyID = " & intNewOptionID & ", " & strSQLUniversity
                    Case 2 ' College
                        strSQLUniversity = " CollegeID = " & intNewOptionID & ", " & strSQLUniversity
                    Case 3 ' Education
                        strSQLPatron = " EducationID = " & intNewOptionID & ", " & strSQLPatron
                    Case 4 ' Ethnic
                        strSQLPatron = " EthnicID = " & intNewOptionID & ", " & strSQLPatron
                    Case 5 ' Occupation
                        strSQLPatron = " OccupationID = " & intNewOptionID & ", " & strSQLPatron
                    Case 6 ' Province
                        strSQLAddress = " ProvinceID = " & intNewOptionID & ", " & strSQLAddress
                    Case 7 ' PatronGroup
                        strSQLPatron = " PatronGroupID = " & intNewOptionID & ", " & strSQLPatron
                    Case Else ' Sex
                        strSQLPatron = " Sex = '" & intNewOptionID & "', " & strSQLPatron
                End Select
            End If

            ' Add Where clause
            If Not strTableCP = "" Then
                If Right(strSQLPatron, 2) = ", " Then
                    strSQLPatron = Left(strSQLPatron, Len(strSQLPatron) - 2)
                End If
                strSQLPatron = "UPDATE Cir_tblPatron SET " & strSQLPatron & " WHERE ID IN (" & strPatronIDs & ")"
                If strWHERE <> "" Then
                    FormingSQL = strSQLPatron & strWHERE
                Else
                    FormingSQL = strSQLPatron
                End If
                'FormingSQL = strSQLPatron
            End If
            If Not strTableCPU = "" Then
                If Right(strSQLUniversity, 2) = ", " Then
                    strSQLUniversity = Left(strSQLUniversity, Len(strSQLUniversity) - 2)
                End If
                strSQLUniversity = "UPDATE Cir_tblPatronUniversity SET " & strSQLUniversity & " WHERE PatronID IN (" & strPatronIDs & ")"
                Select Case UCase(strDBServer)
                    Case "ORACLE"
                        FormingSQL = FormingSQL & ";  " & strSQLUniversity
                    Case "SQLSERVER"
                        FormingSQL = FormingSQL & "  " & strSQLUniversity
                End Select
            End If
            If Not strTableCPOA = "" Then
                If Right(strSQLAddress, 2) = ", " Then
                    strSQLAddress = Left(strSQLAddress, Len(strSQLAddress) - 2)
                End If
                strSQLAddress = "UPDATE Cir_tblPatronOtherAddr SET " & strSQLAddress & " WHERE PatronID IN (" & strPatronIDs & ")"
                Select Case UCase(strDBServer)
                    Case "ORACLE"
                        FormingSQL = FormingSQL & ";  " & strSQLAddress
                    Case "SQLSERVER"
                        FormingSQL = FormingSQL & "  " & strSQLAddress
                End Select
            End If
        End Function

        ' Purpose : UpdatePatrons
        ' Input:  strSQL: string of Update Statement
        '      strCode: string of Patron's Code
        '      intNumOfPatron: integer value
        ' Output: intRetval: integer return value
        '   + 0 if update fail
        '   + 1 if update successfull
        ' Created by: Oanhtn
        Public Function UpdatePatrons() As Integer
            Dim intRetVal As Integer = 0
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatronBatchUpdate"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strSQL", Data.SqlDbType.NVarChar)).Value = FormingSQL()
                                .Add(New SqlParameter("@strCode", Data.SqlDbType.VarChar)).Value = strCode
                                .Add(New SqlParameter("@intNumOfPatron", Data.SqlDbType.Int)).Value = intNumOfPatron
                                .Add(New SqlParameter("@intRetval", Data.SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRetVal = .Parameters("@intRetval").Value
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                            UpdatePatrons = intRetVal
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "PATRON.SP_PATRON_BATCH_UPDATE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strSQL", OracleType.VarChar, 4000)).Value = FormingSQL()
                                .Add(New OracleParameter("strCode", OracleType.VarChar, 20)).Value = strCode
                                .Add(New OracleParameter("intNumOfPatron", OracleType.Number)).Value = intNumOfPatron
                                .Add(New OracleParameter("intRetval", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRetVal = .Parameters("intRetval").Value
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                            UpdatePatrons = intRetVal
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose : UpdateBatchPatrons
        ' Input:  strSQL: string of Update Statement
        '      strCode: string of Patron's Code
        '      intNumOfPatron: integer value
        ' Output: intRetval: integer return value
        '   + 0 if update fail
        '   + 1 if update successfull
        ' Created by: Sondp
        Public Function UpdateBatchPatrons() As Integer
            Dim intRetVal As Integer = 0
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatBatchUpdate"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strSQL", Data.SqlDbType.NVarChar)).Value = FormingSQL()
                                .Add(New SqlParameter("@intRetval", Data.SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRetVal = .Parameters("@intRetval").Value
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                            UpdateBatchPatrons = intRetVal
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "PATRON.SP_PAT_BATCH_UPDATE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strSQL", OracleType.VarChar, 4000)).Value = FormingSQL()
                                .Add(New OracleParameter("intRetval", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRetVal = .Parameters("intRetval").Value
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                            UpdateBatchPatrons = intRetVal
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function


        ' Purpose : Get patron portrait will delete
        ' Input: strPatronIDs
        ' Output: Datatable
        ' Created by: Sondp
        Public Function GetPortraitPatronDel() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "PATRON.SP_GET_PORTRAIT_PATRON_DEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strPatronIDs", OracleType.VarChar, 500)).Value = strPatronIDs
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetPortraitPatronDel = dsData.Tables("tblResult")
                        Catch OraExc As OracleException
                            strErrorMsg = OraExc.Message.ToString
                            intErrorCode = OraExc.Code
                        Finally
                            .Parameters.Clear()
                            dsdata.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatron_SelPortrait"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@strPatronIDs", SqlDbType.VarChar, 500)).Value = strPatronIDs
                        End With
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetPortraitPatronDel = dsData.Tables("tblResult")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                            dsdata.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose : Delete batch Patrons
        ' Input: strPatronIDs
        ' Output: PatronCode,ID, FullName not delete
        ' Created by: Sondp
        Public Function DeletePatrons() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "PATRON.SP_PATRON_BATCH_DELETE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strPatronIDs", OracleType.VarChar, 500)).Value = strPatronIDs
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "Cir_spPatronBatchDelete")
                            DeletePatrons = dsData.Tables("Cir_spPatronBatchDelete")
                        Catch OraExc As OracleException
                            strErrorMsg = OraExc.Message.ToString
                            intErrorCode = OraExc.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("Cir_spPatronBatchDelete")
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatronBatchDelete"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@strPatronIDs", SqlDbType.VarChar, 500)).Value = strPatronIDs
                        End With
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            sqlDataAdapter.Fill(dsData, "Cir_spPatronBatchDelete")
                            DeletePatrons = dsData.Tables("Cir_spPatronBatchDelete")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("Cir_spPatronBatchDelete")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose : This method used to Extend the ExpiredDate of some Patrons
        ' Input: string of PatronIDs, string NewExpiredDate....
        ' Created by: Oanhtn
        Public Function ReNew()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatronBatchExtend"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                If intMonths + intYears > 0 Then
                                    strSQL = "UPDATE Cir_tblPatron SET ExpiredDate = DATEADD(MONTH, " & CStr(intMonths + intYears * 12) & ", ExpiredDate) WHERE ID IN (" & strPatronIDs & ")"
                                Else
                                    strSQL = "UPDATE Cir_tblPatron SET ExpiredDate = '" & strNewExpiredDate & "' WHERE ID IN (" & strPatronIDs & ")"
                                End If
                                .Add(New SqlParameter("@strSQL", Data.SqlDbType.VarChar)).Value = strSQL
                            End With
                            .ExecuteNonQuery()
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "PATRON.SP_PATRON_BATCH_EXTEND"
                        .CommandType = CommandType.StoredProcedure
                        If intMonths + intYears > 0 Then
                            strSQL = "UPDATE Cir_tblPatron SET EXPIREDDATE = ADD_MONTHS(ExpiredDate, " & CStr(intMonths + intYears * 12) & ") WHERE ID IN (" & strPatronIDs & ")"
                        Else
                            strSQL = "UPDATE Cir_tblPatron SET ExpiredDate = TO_DATE('" & strNewExpiredDate & "', 'dd/mm/yyyy HH24:MI:SS') WHERE ID IN (" & strPatronIDs & ")"
                        End If
                        .Parameters.Add(New OracleParameter("strSQL", OracleType.VarChar, 8000)).Value = strSQL
                        Try
                            .ExecuteNonQuery()
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose : Export
        ' Input: intFromID, intToID
        ' Output: Datatable
        ' Created by: Sondp
        Public Function Export(ByVal intFromID As Integer, ByVal intToID As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "PATRON.SP_PATRON_IEXPORT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intFromID", OracleType.Number)).Value = intFromID
                                .Add(New OracleParameter("intToID", OracleType.Number)).Value = intToID
                                .Add(New OracleParameter("strSQL", OracleType.VarChar, 2000)).Direction = ParameterDirection.Output
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            Export = dsData.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch OraExc As OracleException
                            strErrorMsg = OraExc.Message.ToString
                            intErrorCode = OraExc.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatronIExport"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intFromID", Data.SqlDbType.Int)).Value = intFromID
                            .Add(New SqlParameter("@intToID", Data.SqlDbType.Int)).Value = intToID
                            .Add(New SqlParameter("@strSQL", Data.SqlDbType.VarChar, 2000)).Direction = ParameterDirection.Output
                        End With
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            Export = dsData.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose : Export
        ' Input: intFromID, intToID
        ' Output: Datatable
        ' Created by: Sondp
        Public Function Import(ByVal intFromID As Integer, ByVal intToID As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "PATRON.SP_PATRON_IEXPORT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intFromID", OracleType.Number)).Value = intFromID
                                .Add(New OracleParameter("intToID", OracleType.Number)).Value = intToID
                                .Add(New OracleParameter("strSQL", OracleType.VarChar, 2000)).Direction = ParameterDirection.Output
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            Import = dsData.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                            strSQL = .Parameters("strSQL").Value
                        Catch OraExc As OracleException
                            strErrorMsg = OraExc.Message.ToString
                            intErrorCode = OraExc.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatronIExport"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intFromID", Data.SqlDbType.Int)).Value = intFromID
                            .Add(New SqlParameter("@intToID", Data.SqlDbType.Int)).Value = intToID
                            .Add(New SqlParameter("@strSQL", Data.SqlDbType.VarChar, 2000)).Direction = ParameterDirection.Output
                        End With
                        Try
                            .ExecuteNonQuery()
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            Import = dsData.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                            strSQL = .Parameters("@strSQL").Value
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function


        ' Purpose : Get all patron group
        ' Output: Datatable
        ' Created by: Sondp
        Public Function GetPatronGroup() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatGetPatronGroup"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetPatronGroup = dsData.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "PATRON.SP_PAT_GET_PATRONGROUP"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetPatronGroup = dsData.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose: Get patroncards haven't been printed yet
        ' Output: datatable result
        ' Input: strID
        ' Output: Datatable
        ' Creator: Sondp
        Public Function GetCardNotPrinted(ByVal strID As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatGetNotPrintedCard"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strID", SqlDbType.VarChar)).Value = strID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetCardNotPrinted = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "PATRON.SP_PAT_GET_NOTPRINTED_CARD"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strID", OracleType.VarChar, 4000)).Value = strID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetCardNotPrinted = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose: Get patroncards haven been printed yet
        ' Output: datatable result
        ' Input: strIDs
        ' Output: Datatable
        ' Creator: Sondp
        Public Function GetCardPrinted(ByVal strIDs As String, Optional ByVal selectTop As Integer = 0) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatGetPrintedCard"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strIDs", SqlDbType.VarChar)).Value = strIDs
                            .Parameters.Add(New SqlParameter("@selectTop", SqlDbType.Int)).Value = selectTop
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetCardPrinted = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "PATRON.SP_PAT_GET_PRINTED_CARD"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strIDs", OracleType.VarChar, 8000)).Value = strIDs
                                .Add(New OracleParameter("selectTop", OracleType.VarChar.Number)).Value = selectTop
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetCardPrinted = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Sub InsertPatronPrintCard(ByVal strPatronIDs As String, ByVal intTemplateID As Integer, ByVal intIssueLibraryID As Integer)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "PATRON.SP_PAT_PRINTED_CARD_INSERT"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("strPatronIDs", OracleType.VarChar, 500)).Value = strPatronIDs
                            .Add(New OracleParameter("intTemplateID", OracleType.Number)).Value = intTemplateID
                            .Add(New OracleParameter("intIssueLibraryID", OracleType.Number)).Value = intIssueLibraryID
                        End With
                        Try
                            .ExecuteNonQuery()
                        Catch OraExc As OracleException
                            strErrorMsg = OraExc.Message.ToString
                            intErrorCode = OraExc.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spPatPrintedCardInsert"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@strPatronIDs", SqlDbType.VarChar, 500)).Value = strPatronIDs
                            .Add(New SqlParameter("@intTemplateID", SqlDbType.Int)).Value = intTemplateID
                            .Add(New SqlParameter("@intIssueLibraryID", SqlDbType.Int)).Value = intIssueLibraryID
                        End With
                        Try
                            .ExecuteNonQuery()
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        ' Purpose: Get all country
        ' Input: 
        ' Output: Datatable
        ' Creator: Sondp
        Public Function GetCountry() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spDic_Country_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "SP_CAT_DIC_COUNTRY_SELECT")
                            GetCountry = dsData.Tables("SP_CAT_DIC_COUNTRY_SELECT")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                            dsdata.Tables.Remove("SP_CAT_DIC_COUNTRY_SELECT")
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "PATRON.SP_CAT_DIC_COUNTRY_SELECT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "SP_CAT_DIC_COUNTRY_SELECT")
                            GetCountry = dsData.Tables("SP_CAT_DIC_COUNTRY_SELECT")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("SP_CAT_DIC_COUNTRY_SELECT")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose: Insert EducationLevel
        ' Input: strEducationLevel
        ' Output: intEducationID
        ' Creator: Sondp
        Public Function ImportEducation(ByVal strEducationLevel As String) As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_splDicEducation_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strEducationLevel", SqlDbType.NVarChar)).Value = strEducationLevel
                                .Add(New SqlParameter("@intEducationID", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            ImportEducation = .Parameters("@intEducationID").Value()
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "PATRON.SP_CIR_DIC_EDUCATION_IMPORT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strEducationLevel", OracleType.VarChar, 50)).Value = strEducationLevel
                                .Add(New OracleParameter("intEducationID", OracleType.Number, 4)).Direction = ParameterDirection.InputOutput
                            End With
                            .ExecuteNonQuery()
                            ImportEducation = .Parameters("intEducationID").Value()
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Retrieve from all dictionary table
        ' Output: Datatable
        Public Function RetrieveDicTable() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatronSelectAllDic"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            RetrieveDicTable = dsData.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "PATRON.SP_PATRON_SELECT_ALLDIC"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            RetrieveDicTable = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function
        ' Check RenewDate for Patron
        ' Create by chuyenpt(7/5/07)
        Public Function CheckRenewDate(ByVal intPatronID As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatron_CheckRenewDate"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intPatronID", SqlDbType.Int)).Value = intPatronID
                            .Parameters.Add(New SqlParameter("@strNewExpiredDate", SqlDbType.VarChar)).Value = strNewExpiredDate
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            CheckRenewDate = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
            End Select
            Call CloseConnection()
        End Function
        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                Call MyBase.Dispose(isDisposing)
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Dispose()
            End Try
        End Sub
    End Class
End Namespace