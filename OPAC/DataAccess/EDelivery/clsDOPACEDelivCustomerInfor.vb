Imports System.Data
Imports System.Data.sqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibOPAC.DataAccess.OPAC
    Public Class clsDOPACEDelivCustomerInfor
        Inherits clsDBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private strUserName As String
        Private strFullName As String
        Private strContacter As String
        Private strEmail As String
        Private strTel As String
        Private strFax As String
        Private strPassword As String
        Private strCompany As String
        Private intCountryID As Integer
        Private strDepartment As String
        Private strStreet As String
        Private strBox As String
        Private strCity As String
        Private strRegion As String
        Private strCode As String
        Private strPhone As String
        Private intSecretLevel As Integer = 0

        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************
        'SecretLevel Property
        Public Property SecretLevel() As Integer
            Get
                Return intSecretLevel
            End Get
            Set(ByVal Value As Integer)
                intSecretLevel = Value
            End Set
        End Property
        'User  of Acccount
        Public Property UserName() As String
            Get
                Return strUserName
            End Get
            Set(ByVal Value As String)
                strUserName = Value
            End Set
        End Property

        'FullName  of Acccount
        Public Property FullName() As String
            Get
                Return strFullName
            End Get
            Set(ByVal Value As String)
                strFullName = Value
            End Set
        End Property

        ' Contacter of Acccount
        Public Property Contacter() As String
            Get
                Return strContacter
            End Get
            Set(ByVal Value As String)
                strContacter = Value
            End Set
        End Property

        'Email of Acccount
        Public Property Email() As String
            Get
                Return strEmail
            End Get
            Set(ByVal Value As String)
                strEmail = Value
            End Set
        End Property

        'Tel of Acccount
        Public Property Tel() As String
            Get
                Return strTel
            End Get
            Set(ByVal Value As String)
                strTel = Value
            End Set
        End Property

        'Fax of Acccount
        Public Property Fax() As String
            Get
                Return strFax
            End Get
            Set(ByVal Value As String)
                strFax = Value
            End Set
        End Property

        'Password of Acccount
        Public Property Password() As String
            Get
                Return strPassword
            End Get
            Set(ByVal Value As String)
                strPassword = Value
            End Set
        End Property

        'Company of Acccount
        Public Property Company() As String
            Get
                Return strCompany
            End Get
            Set(ByVal Value As String)
                strCompany = Value
            End Set
        End Property

        'CountryID of Acccount
        Public Property CountryID() As Integer
            Get
                Return intCountryID
            End Get
            Set(ByVal Value As Integer)
                intCountryID = Value
            End Set
        End Property

        ' Department property
        Public Property Department() As String
            Get
                Return strDepartment
            End Get
            Set(ByVal Value As String)
                strDepartment = Value
            End Set
        End Property

        ' Street property
        Public Property Street() As String
            Get
                Return strStreet
            End Get
            Set(ByVal Value As String)
                strStreet = Value
            End Set
        End Property

        ' Box property
        Public Property Box() As String
            Get
                Return strBox
            End Get
            Set(ByVal Value As String)
                strBox = Value
            End Set
        End Property

        ' City property
        Public Property City() As String
            Get
                Return strCity
            End Get
            Set(ByVal Value As String)
                strCity = Value
            End Set
        End Property

        ' Region property
        Public Property Region() As String
            Get
                Return strRegion
            End Get
            Set(ByVal Value As String)
                strRegion = Value
            End Set
        End Property

        ' Code property
        Public Property Code() As String
            Get
                Return strCode
            End Get
            Set(ByVal Value As String)
                strCode = Value
            End Set
        End Property

        ' Phone property
        Public Property Phone() As String
            Get
                Return strPhone
            End Get
            Set(ByVal Value As String)
                strPhone = Value
            End Set
        End Property

        ' purpose : Create new E-Delivery account
        ' Created by: dgsoft
        Public Sub CreateAccount(ByRef intOutPut As Int16)
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spEdlAccount_Create"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strUserName", SqlDbType.VarChar, 16)).Value = strUserName
                                .Add(New SqlParameter("@strName", SqlDbType.NVarChar, 100)).Value = strFullName
                                .Add(New SqlParameter("@strDelivName", SqlDbType.NVarChar, 100)).Value = strCompany
                                .Add(New SqlParameter("@strDelivXAddr", SqlDbType.NVarChar, 100)).Value = strDepartment
                                .Add(New SqlParameter("@strDelivStreet", SqlDbType.NVarChar, 50)).Value = strStreet
                                .Add(New SqlParameter("@strDelivBox", SqlDbType.NVarChar, 50)).Value = strBox
                                .Add(New SqlParameter("@strDelivCity", SqlDbType.NVarChar, 50)).Value = strCity
                                .Add(New SqlParameter("@strDelivRegion", SqlDbType.NVarChar, 30)).Value = strRegion
                                .Add(New SqlParameter("@intDelivCountry", SqlDbType.TinyInt)).Value = intCountryID
                                .Add(New SqlParameter("@strDelivCode", SqlDbType.VarChar, 10)).Value = strCode
                                .Add(New SqlParameter("@strTelephone", SqlDbType.VarChar, 14)).Value = strPhone
                                .Add(New SqlParameter("@strEmailAddress", SqlDbType.VarChar, 50)).Value = strEmail
                                .Add(New SqlParameter("@strPassword", SqlDbType.VarChar, 20)).Value = strPassword
                                .Add(New SqlParameter("@strFax", SqlDbType.VarChar, 20)).Value = strFax
                                .Add(New SqlParameter("@strContactPerson", SqlDbType.NVarChar, 50)).Value = strContacter
                                .Add(New SqlParameter("@intSecretLevel", SqlDbType.Int)).Value = intSecretLevel
                                .Add(New SqlParameter("@intOutPut", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intOutPut = .Parameters("@intOutPut").Value
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.Opac_spEdlAccount_Create"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strUserName", OracleType.VarChar, 16)).Value = strUserName
                                .Add(New OracleParameter("strName", OracleType.VarChar, 100)).Value = strFullName
                                .Add(New OracleParameter("strDelivName", OracleType.VarChar, 100)).Value = strCompany
                                .Add(New OracleParameter("strDelivXAddr", OracleType.VarChar, 100)).Value = strDepartment
                                .Add(New OracleParameter("strDelivStreet", OracleType.VarChar, 50)).Value = strStreet
                                .Add(New OracleParameter("strDelivBox", OracleType.VarChar, 50)).Value = strBox
                                .Add(New OracleParameter("strDelivCity", OracleType.VarChar, 50)).Value = strCity
                                .Add(New OracleParameter("strDelivRegion", OracleType.VarChar, 30)).Value = strRegion
                                .Add(New OracleParameter("intDelivCountry", OracleType.Number)).Value = intCountryID
                                .Add(New OracleParameter("strDelivCode", OracleType.VarChar, 10)).Value = strCode
                                .Add(New OracleParameter("strTelephone", OracleType.VarChar, 14)).Value = strPhone
                                .Add(New OracleParameter("strEmailAddress", OracleType.VarChar, 50)).Value = strEmail
                                .Add(New OracleParameter("strPassword", OracleType.VarChar, 20)).Value = strPassword
                                .Add(New OracleParameter("strFax", OracleType.VarChar, 20)).Value = strFax
                                .Add(New OracleParameter("strContactPerson", OracleType.VarChar, 50)).Value = strContacter
                                .Add(New OracleParameter("intSecretLevel", OracleType.Number)).Value = intSecretLevel
                                .Add(New OracleParameter("intOutPut", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intOutPut = .Parameters("intOutPut").Value
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With

            End Select
            Me.CloseConnection()
        End Sub

        ' purpose : Read information of E-Delivery account
        ' Created by: dgsoft
        Public Function GetAccount() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"

                Case "ORACLE"

            End Select
            Me.CloseConnection()
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not oraConnection Is Nothing Then
                        oraConnection.Dispose()
                        oraConnection = Nothing
                    End If
                    If Not oraCommand Is Nothing Then
                        oraCommand.Dispose()
                        oraCommand = Nothing
                    End If
                    If Not oraDataAdapter Is Nothing Then
                        oraDataAdapter.Dispose()
                        oraDataAdapter = Nothing
                    End If
                    If Not SqlConnection Is Nothing Then
                        SqlConnection.Dispose()
                        SqlConnection = Nothing
                    End If
                    If Not SqlCommand Is Nothing Then
                        SqlCommand.Dispose()
                        SqlCommand = Nothing
                    End If
                    If Not SqlDataAdapter Is Nothing Then
                        SqlDataAdapter.Dispose()
                        SqlDataAdapter = Nothing
                    End If
                    If Not dsData Is Nothing Then
                        dsData.Dispose()
                        dsData = Nothing
                    End If
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Dispose()
            End Try
        End Sub
    End Class
End Namespace