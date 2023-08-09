Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType
Namespace eMicLibAdmin.DataAccess.Catalogue
    Public Class clsDGenIdx
        Inherits clsDBase
        ' Declare variables
        Private strIDs As String
        Private intGroupIDFrom As Integer
        Private intGroupIDTo As Integer
        Private bytTypeSel As Byte
        Private strGroupName As String

        ' IDs property 
        Public Property IDs() As String
            Get
                Return strIDs
            End Get
            Set(ByVal Value As String)
                strIDs = Value
            End Set
        End Property

        ' GroupIDFrom property
        Public Property GroupIDFrom() As Integer
            Get
                Return intGroupIDFrom
            End Get
            Set(ByVal Value As Integer)
                intGroupIDFrom = Value
            End Set
        End Property

        ' GroupIDTo property
        Public Property GroupIDTo() As Integer
            Get
                Return intGroupIDTo
            End Get
            Set(ByVal Value As Integer)
                intGroupIDTo = Value
            End Set
        End Property

        ' TypeSel property
        Public Property TypeSel() As Byte
            Get
                Return bytTypeSel
            End Get
            Set(ByVal Value As Byte)
                bytTypeSel = Value
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

        ' Retrieve_CustomIdx method
        Public Function Retrieve_CustomIdx() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_splBibliography_SelCustomIDX"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intID", SqlDbType.Int)).Value = CInt(strIDs)
                            .Add(New SqlParameter("@intTypeSelect", SqlDbType.Int)).Value = bytTypeSel
                            .Add(New SqlParameter("@intGroupIDFrom", SqlDbType.Int)).Value = intGroupIDFrom
                            .Add(New SqlParameter("@intGroupIDTo", SqlDbType.Int)).Value = intGroupIDTo
                            .Add(New SqlParameter("@strGroupName", SqlDbType.NVarChar)).Value = strGroupName
                        End With
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblICUSTOMIDX")
                            Retrieve_CustomIdx = dsData.Tables("tblICUSTOMIDX")
                            dsData.Tables.Remove("tblICUSTOMIDX")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_IDX_CUSTOM_SEL"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("intID", OracleType.Number)).Value = CInt(strIDs)
                            .Add(New OracleParameter("intTypeSelect", OracleType.Number)).Value = bytTypeSel
                            .Add(New OracleParameter("intGroupIDFrom", OracleType.Number)).Value = intGroupIDFrom
                            .Add(New OracleParameter("intGroupIDTo", OracleType.Number)).Value = intGroupIDTo
                            .Add(New OracleParameter("strGroupName", OracleType.VarChar, 100)).Value = strGroupName
                            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        End With
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblICUSTOMIDX")
                            Retrieve_CustomIdx = dsData.Tables("tblICUSTOMIDX")
                            dsData.Tables.Remove("tblICUSTOMIDX")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                Call MyBase.Dispose(True)
            Finally
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace