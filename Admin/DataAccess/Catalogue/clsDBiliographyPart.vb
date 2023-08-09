' Purpose: process form
' Creator: Oanhtn
' Created Date: 15/04/2004
' Modification history:

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Catalogue
    Public Class clsDBiliographyPart
        Inherits clsDBiliographic

        ' *****************************************************************************************************
        ' Declare Private variables
        ' *****************************************************************************************************

        Private intBibliographyPartID As Integer
        Private strItemIDs As String
        Private lngNORs As Long
        Private intPart_Index As Integer
        Private lngPosition As Long
        Private strQString As String
        Private strSQL As String
        Private strGroupName As String
        Private intGroupID As Integer

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' BibliographyPartID property
        Public Property BibliographyPartID() As Integer
            Get
                Return intBibliographyPartID
            End Get
            Set(ByVal Value As Integer)
                intBibliographyPartID = Value
            End Set
        End Property

        ' ItemIDs property
        Public Property ItemIDs() As String
            Get
                Return strItemIDs
            End Get
            Set(ByVal Value As String)
                strItemIDs = Value
            End Set
        End Property

        ' NORs property
        Public Property NORs() As Long
            Get
                Return lngNORs
            End Get
            Set(ByVal Value As Long)
                lngNORs = Value
            End Set
        End Property

        ' Part_Index property
        Public Property Part_Index() As Integer
            Get
                Return intPart_Index
            End Get
            Set(ByVal Value As Integer)
                intPart_Index = Value
            End Set
        End Property

        ' Position property
        Public Property Position() As Long
            Get
                Return lngPosition
            End Get
            Set(ByVal Value As Long)
                lngPosition = Value
            End Set
        End Property

        ' QString property
        Public Property QString() As String
            Get
                Return strQString
            End Get
            Set(ByVal Value As String)
                strQString = Value
            End Set
        End Property

        ' SQL property
        Public Property SQL() As String
            Get
                Return strSQL
            End Get
            Set(ByVal Value As String)
                strSQL = Value
            End Set
        End Property

        ' GroupName property
        Public Property GroupName() As String
            Get
                Return strGroupName
            End Get
            Set(ByVal Value As String)
                strGroupName = Value
            End Set
        End Property

        ' GroupID property
        Public Property GroupID() As Integer
            Get
                Return intGroupID
            End Get
            Set(ByVal Value As Integer)
                intGroupID = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Create method
        ' Purpose: Create new biliographypart
        ' Output: int value of created biliographypart
        Public Overridable Overloads Function Create() As Integer
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CAT_BIBLIOGRAPHYPART_INS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strItemIDs", OracleType.VarChar, 2000)).Value = strItemIDs
                            .Parameters.Add(New OracleParameter("lngNORs", OracleType.Number)).Value = lngNORs
                            .Parameters.Add(New OracleParameter("intPart_Index", OracleType.Number)).Value = intPart_Index
                            .Parameters.Add(New OracleParameter("lngPosition", OracleType.Number)).Value = lngPosition
                            .Parameters.Add(New OracleParameter("strQString", OracleType.VarChar, 2000)).Value = strQString
                            .Parameters.Add(New OracleParameter("strSQL", OracleType.VarChar, 2000)).Value = strSQL
                            .Parameters.Add(New OracleParameter("strGroupName", OracleType.VarChar, 200)).Value = strGroupName
                            .Parameters.Add(New OracleParameter("intGroupID", OracleType.Number)).Value = intGroupID
                            .Parameters.Add(New OracleParameter("intBibliographyPartID", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            intBibliographyPartID = .Parameters("intBibliographyPartID").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spBibliographyPart_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("strItemIDs", SqlDbType.VarChar, 2000)).Value = strItemIDs
                            .Parameters.Add(New SqlParameter("lngNORs", SqlDbType.Int)).Value = lngNORs
                            .Parameters.Add(New SqlParameter("intPart_Index", SqlDbType.Int)).Value = intPart_Index
                            .Parameters.Add(New SqlParameter("lngPosition", SqlDbType.Int)).Value = lngPosition
                            .Parameters.Add(New SqlParameter("strQString", SqlDbType.NVarChar, 2000)).Value = strQString
                            .Parameters.Add(New SqlParameter("strSQL", SqlDbType.NVarChar, 2000)).Value = strSQL
                            .Parameters.Add(New SqlParameter("strGroupName", SqlDbType.NVarChar, 200)).Value = strGroupName
                            .Parameters.Add(New SqlParameter("intGroupID", SqlDbType.Int)).Value = intGroupID
                            .Parameters.Add(New SqlParameter("intBibliographyPartID", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            intBibliographyPartID = .Parameters("intBibliographyPartID").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
        End Function

        ' Modify method
        ' Purpose: Modify the information if the current biliographypart
        Public Overridable Overloads Sub Modify()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CAT_BIBLIOGRAPHYPART_UPD"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intType", OracleType.Number)).Value = intType
                            .Parameters.Add(New OracleParameter("intBibliographicID", OracleType.Number)).Value = intBibliographicID
                            .Parameters.Add(New OracleParameter("intGroupID", OracleType.Number)).Value = intGroupID
                            .Parameters.Add(New OracleParameter("lngPosition", OracleType.Number)).Value = lngPosition
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
                        .CommandText = "SP_CAT_BIBLIOGRAPHYPART_UPD"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intType", SqlDbType.Int)).Value = intType
                            .Parameters.Add(New SqlParameter("@intBibliographicID", SqlDbType.Int)).Value = intBibliographicID
                            .Parameters.Add(New SqlParameter("@intGroupID", SqlDbType.Int)).Value = intGroupID
                            .Parameters.Add(New SqlParameter("@lngPosition", SqlDbType.Int)).Value = lngPosition
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

        ' Delete method
        ' Purpose: Delete the selected biliographypart
        ' Output: int value of the selected biliographypart
        Public Overridable Overloads Sub Delete()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CAT_BIBLIOGRAPHYPART_DEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intBibliographyPartID", OracleType.Number)).Value = intBibliographyPartID
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
                        .CommandText = "SP_CAT_BIBLIOGRAPHYPART_DEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("intBibliographyPartID", SqlDbType.Int)).Value = intBibliographyPartID
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
    End Class
End Namespace