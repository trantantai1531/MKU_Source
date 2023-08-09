Imports eMicLibAdmin.DataAccess.Catalogue
Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.BusinessRules.Catalogue
    Public Class clsBCatDicList
        Inherits clsBBase

        ' *****************************************************************************************************
        ' Declare Private variables
        ' *****************************************************************************************************

        Private objDCatDiclist As New clsDCatDicList
        Private objBString As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem

        Private strIDs As String = ""
        Private bytSystemDic As Byte = 2
        Private intIsClassifiCation As Integer = -1
        Private intIsAuthority As Integer = -1
        Private strFieldCode As String = ""
        Private bytIsDic As Byte = 1

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************
        ' IsDic property
        Public Property IsDic() As Byte
            Get
                Return bytIsDic
            End Get
            Set(ByVal Value As Byte)
                bytIsDic = Value
            End Set
        End Property

        ' IsAuthority property
        Public Property IsAuthority() As Integer
            Get
                Return intIsAuthority
            End Get
            Set(ByVal Value As Integer)
                intIsAuthority = Value
            End Set
        End Property

        ' IsClassifiCation property
        Public Property IsClassifiCation() As Integer
            Get
                Return intIsClassifiCation
            End Get
            Set(ByVal Value As Integer)
                intIsClassifiCation = Value
            End Set
        End Property

        ' SystemDic property
        Public Property SystemDic() As Byte
            Get
                Return bytSystemDic
            End Get
            Set(ByVal Value As Byte)
                bytSystemDic = Value
            End Set
        End Property

        ' IDs property
        Public Property IDs() As String
            Get
                Return strIDs
            End Get
            Set(ByVal Value As String)
                strIDs = Value
            End Set
        End Property

        ' FieldCode property
        Public Property FieldCode() As String
            Get
                Return strFieldCode
            End Get
            Set(ByVal Value As String)
                strFieldCode = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************
        Public Sub Initialize()
            Try
                objDCatDiclist.ConnectionString = strConnectionString
                objDCatDiclist.DBServer = strDBServer
                objDCatDiclist.Initialize()

                objBCDBS.InterfaceLanguage = strInterfaceLanguage
                objBCDBS.DBServer = strDBServer
                objBCDBS.ConnectionString = strConnectionString
                objBCDBS.Initialize()

                objBString.InterfaceLanguage = strInterfaceLanguage
                objBString.DBServer = strDBServer
                objBString.ConnectionString = strConnectionString
                objBString.Initialize()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Retrieve function
        ' Purpose: get list of dictionaries
        Public Function Retrieve() As DataTable
            Try
                objDCatDiclist.IsAuthority = intIsAuthority
                objDCatDiclist.IsClassifiCation = intIsClassifiCation
                objDCatDiclist.SystemDic = bytSystemDic
                objDCatDiclist.IDs = strIDs
                objDCatDiclist.IsDic = bytIsDic
                objDCatDiclist.LibID = intLibID
                Retrieve = objBCDBS.ConvertTable(objDCatDiclist.Retrieve)
                strErrorMsg = objDCatDiclist.ErrorMsg
                intErrorCode = objDCatDiclist.FieldCode
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
        End Function

        ' GetReferenceByFieldCode method
        ' Purpose: get reference infor by FieldCode
        ' Input: string value of FieldCode
        ' Output: datatable
        Public Function GetReferenceByFieldCode() As DataTable
            Try
                objDCatDiclist.FieldCode = strFieldCode
                GetReferenceByFieldCode = objBCDBS.ConvertTable(objDCatDiclist.GetReferenceByFieldCode())
                strErrorMsg = objDCatDiclist.ErrorMsg
                intErrorCode = objDCatDiclist.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' Purpose : Get ID, Name from Cat_tblDicList table
        ' In: intID
        ' Out: Datatable
        ' Created by: Sondp
        Public Function GetCatDicList(Optional ByVal intID As Integer = 0) As DataTable
            Try
                GetCatDicList = objBCDBS.ConvertTable(objDCatDiclist.GetCatDicList(intID))
                strErrorMsg = objDCatDiclist.ErrorMsg
                intErrorCode = objDCatDiclist.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Release resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                End If
                If Not objDCatDiclist Is Nothing Then
                    objDCatDiclist.Dispose(True)
                    objDCatDiclist = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBString Is Nothing Then
                    objBString.Dispose(True)
                    objBString = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace