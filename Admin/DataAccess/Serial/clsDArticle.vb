' Name: clsDArticle
' Purpose: Management Article of Issue
' Creator: Oanhtn
' Created Date: 20/09/2004
' Modification History:

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Serial
    Public Class clsDArticle
        Inherits clsDBase

        ' *******************************************************************************************************
        ' Declare Private variables
        ' *******************************************************************************************************

        Private intItemID As Integer = 0
        Private intLocationID As Integer = 0
        Private intID As Integer = 0
        Private strIDs As String = ""
        Private intYear As Integer = 0
        Private lngIssueID As Long = 0
        Private strTitle As String = ""
        Private strAuthor As String = ""
        Private strSubject As String = ""
        Private strPage As String = ""
        Private strNote As String = ""
        Private strIssueNo As String = ""
        Private strName As String = ""
        Private lngCurID As Long = 0
        Private intCopyNumberID As Integer = 0
        Private strCreatedDate As String = ""
        Private strFileAttack As String = ""

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        'FileAttack Property
        Public Property FileAttack() As String
            Get
                Return strFileAttack
            End Get
            Set(ByVal Value As String)
                strFileAttack = Value
            End Set
        End Property
        ' Name Property
        Public Property Name() As String
            Get
                Return strName
            End Get
            Set(ByVal Value As String)
                strName = Value
            End Set
        End Property
        'CreatedDate Property
        Public Property CreatedDate() As String
            Get
                Return strCreatedDate
            End Get
            Set(ByVal Value As String)
                strCreatedDate = Value
            End Set
        End Property
        ' IDs Property
        Public Property IDs() As String
            Get
                Return strIDs
            End Get
            Set(ByVal Value As String)
                strIDs = Value
            End Set
        End Property

        'ID Property
        Public Property ID() As Integer
            Get
                Return intID
            End Get
            Set(ByVal Value As Integer)
                intID = Value
            End Set
        End Property

        'LocationID Property
        Public Property LocationID() As Integer
            Get
                Return intLocationID
            End Get
            Set(ByVal Value As Integer)
                intLocationID = Value
            End Set
        End Property

        'CopyNumberID Property
        Public Property CopyNumberID() As Integer
            Get
                Return intCopyNumberID
            End Get
            Set(ByVal Value As Integer)
                intCopyNumberID = Value
            End Set
        End Property

        ' Title Property
        Public Property IssueNo() As String
            Get
                Return strIssueNo
            End Get
            Set(ByVal Value As String)
                strIssueNo = Value
            End Set
        End Property

        'ItemID Property
        Public Property ItemID() As Integer
            Get
                Return intItemID
            End Get
            Set(ByVal Value As Integer)
                intItemID = Value
            End Set
        End Property

        ' PubYear Property
        Public Property Year() As Integer
            Get
                Return intYear
            End Get
            Set(ByVal Value As Integer)
                intYear = Value
            End Set
        End Property

        ' IssueID Property
        Public Property IssueID() As Long
            Get
                Return lngIssueID
            End Get
            Set(ByVal Value As Long)
                lngIssueID = Value
            End Set
        End Property

        ' Title Property
        Public Property Title() As String
            Get
                Return strTitle
            End Get
            Set(ByVal Value As String)
                strTitle = Value
            End Set
        End Property

        ' Author Property
        Public Property Author() As String
            Get
                Return strAuthor
            End Get
            Set(ByVal Value As String)
                strAuthor = Value
            End Set
        End Property

        ' Subject Property
        Public Property Subject() As String
            Get
                Return strSubject
            End Get
            Set(ByVal Value As String)
                strSubject = Value
            End Set
        End Property

        ' Page Property
        Public Property Page() As String
            Get
                Return strPage
            End Get
            Set(ByVal Value As String)
                strPage = Value
            End Set
        End Property

        ' Note Property
        Public Property Note() As String
            Get
                Return strNote
            End Get
            Set(ByVal Value As String)
                strNote = Value
            End Set
        End Property

        ' CurID property
        Public Property CurID() As Long
            Get
                Return lngCurID
            End Get
            Set(ByVal Value As Long)
                lngCurID = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Create method
        ' Purpose: Create new component of Article
        ' Input: some main infor of component
        ' Output: Boolean value (true when success)
        Public Function Create() As Boolean
            Create = True
            Call OpenConnection()

            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_CREATE_ARTICLE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intIssueID", OracleType.Number, 4)).Value = lngIssueID
                                .Add(New OracleParameter("strName", OracleType.VarChar, 100)).Value = strName
                                .Add(New OracleParameter("strAuthor", OracleType.VarChar, 100)).Value = strAuthor
                                .Add(New OracleParameter("strPage", OracleType.VarChar, 50)).Value = strPage
                                .Add(New OracleParameter("strNote", OracleType.VarChar, 1000)).Value = strNote
                                .Add(New OracleParameter("strSubject", OracleType.VarChar, 200)).Value = strSubject
                                .Add(New OracleParameter("strCreatedDate", OracleType.VarChar, 200)).Value = strCreatedDate
                                .Add(New OracleParameter("strFileAttack", OracleType.VarChar, 1000)).Value = strFileAttack
                            End With
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                            Create = False
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ser_spArticle_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intIssueID", SqlDbType.Int, 100)).Value = lngIssueID
                                .Add(New SqlParameter("@strName", SqlDbType.NVarChar, 100)).Value = strName
                                .Add(New SqlParameter("@strAuthor", SqlDbType.NVarChar, 100)).Value = strAuthor
                                .Add(New SqlParameter("@strPage", SqlDbType.NVarChar, 100)).Value = strPage
                                .Add(New SqlParameter("@strNote", SqlDbType.NVarChar, 1000)).Value = strNote
                                .Add(New SqlParameter("@strSubject", SqlDbType.NVarChar, 200)).Value = strSubject
                                .Add(New SqlParameter("@strCreatedDate", SqlDbType.NVarChar, 200)).Value = strCreatedDate
                                .Add(New SqlParameter("@strFileAttack", SqlDbType.NVarChar, 1000)).Value = strFileAttack
                            End With
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                            Create = False
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
        End Function
        'Purpose: INSERT INTO SUBJECT
        'INPUT: STRSUBJECT
        'CREATED BY: TUANNV
        Public Sub AddSubject(ByVal strSubject As String)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_CREATE_SUBJECT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strSubject", OracleType.VarChar, 200)).Value = strSubject
                            End With
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ser_spSubject_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strSubject", SqlDbType.NVarChar, 200)).Value = strSubject
                            End With
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
        End Sub
        ' Update method
        ' Purpose: Update information of the selected component
        ' Input: some main infor of component
        ' Output: Boolean value (true when success)
        Public Function Update() As Boolean
            Update = True
            Call OpenConnection()

            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_UPDATE_ARTICLE"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("intID", OracleType.Number, 4)).Value = intID
                            .Add(New OracleParameter("intIssueID", OracleType.Number, 4)).Value = lngIssueID
                            .Add(New OracleParameter("strName", OracleType.VarChar, 100)).Value = strName
                            .Add(New OracleParameter("strAuthor", OracleType.VarChar, 100)).Value = strAuthor
                            .Add(New OracleParameter("strPage", OracleType.VarChar, 50)).Value = strPage
                            .Add(New OracleParameter("strNote", OracleType.VarChar, 1000)).Value = strNote
                            .Add(New OracleParameter("strSubject", OracleType.VarChar, 200)).Value = strSubject
                            .Add(New OracleParameter("strFileAttack", OracleType.VarChar, 1000)).Value = strFileAttack
                        End With
                        Try
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                            Update = False
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ser_spArticle_Upd2"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intID", SqlDbType.Int, 10)).Value = intID
                            .Add(New SqlParameter("@intIssueID", SqlDbType.Int, 100)).Value = lngIssueID
                            .Add(New SqlParameter("@strName", SqlDbType.NVarChar, 100)).Value = strName
                            .Add(New SqlParameter("@strAuthor", SqlDbType.NVarChar, 100)).Value = strAuthor
                            .Add(New SqlParameter("@strPage", SqlDbType.NVarChar, 100)).Value = strPage
                            .Add(New SqlParameter("@strNote", SqlDbType.NVarChar, 1000)).Value = strNote
                            .Add(New SqlParameter("@strSubject", SqlDbType.NVarChar, 200)).Value = strSubject
                            .Add(New SqlParameter("@strCreatedDate", SqlDbType.NVarChar, 200)).Value = strCreatedDate
                            .Add(New SqlParameter("@strFileAttack", SqlDbType.NVarChar, 1000)).Value = strFileAttack

                        End With
                        Try
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                            Update = False
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
        End Function

        ' Delete method
        ' Purpose: delete the selected component
        ' Input: ID of component
        ' Output: Boolean value (true when success)
        Public Function Delete() As Boolean
            Delete = True
            Call OpenConnection()

            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_DELETE_ARTICLE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strID", OracleType.VarChar, 100)).Value = strIDs
                            End With
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                            Delete = False
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ser_spArticle_DelById"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@strID", SqlDbType.VarChar, 100)).Value = strIDs
                        End With
                        Try
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                            Delete = False
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
        End Function

        ' GetYearsInfor method
        ' Purpose: get year with ItemID help use using year exit Item
        ' Output: datatable result
        Public Function GetYearsInfor() As DataTable
            Call OpenConnection()

            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_GET_YEARITEMPO"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("intItemID", OracleType.Number, 4)).Value = intItemID
                            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        End With
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsdata, "tblResult")
                            GetYearsInfor = dsdata.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ser_spIssue_SelByItemIdOrderYears"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intItemID", SqlDbType.Int, 10)).Value = intItemID
                        End With
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsdata, "tblResult")
                            GetYearsInfor = dsdata.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
        End Function

        ' Method: GetArticleInfor
        ' Purpose: get infor of the current Article
        ' Input: IssueID
        ' Output: datatable result
        Public Function GetArticleInfor() As DataTable
            Call OpenConnection()

            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SERIAL.SP_GET_ARTICLE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intIssueID", OracleType.Number, 10)).Value = lngIssueID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsdata, "tblResult")
                            GetArticleInfor = dsdata.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ser_spArticle_SelByIssueId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intIssueID", SqlDbType.Int, 5)).Value = CInt(lngIssueID)
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsdata, "tblResult")
                            GetArticleInfor = dsdata.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
        End Function

        ' Method: Dispose
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