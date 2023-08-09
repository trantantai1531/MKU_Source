Imports eMicLibAdmin.DataAccess.Catalogue
Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue
Namespace eMicLibAdmin.BusinessRules.Catalogue
    Public Class clsBCatDicItemType
        Inherits clsBBase

        ' Declare variables
        Private strIDs As String = ""
        Private strTypeCode As String = ""
        Private strTypeName As String = ""
        Private intID As Integer = 0

        Private objBCommonDB As New clsBCommonDBSystem
        Private objBString As New clsBCommonStringProc
        Private objDDicItemType As New clsDCatDicItemType

        ' IDs property
        Public Property ID() As Integer
            Get
                Return intID
            End Get
            Set(ByVal Value As Integer)
                intID = Value
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

        ' TypeCode property
        Public Property TypeCode() As String
            Get
                Return strTypeCode
            End Get
            Set(ByVal Value As String)
                strTypeCode = Value
            End Set
        End Property

        ' TypeName property
        Public Property TypeName() As String
            Get
                Return strTypeName
            End Get
            Set(ByVal Value As String)
                strTypeName = Value
            End Set
        End Property

        ' Initialize method
        Public Sub Initialize()
            Try
                objBCommonDB.InterfaceLanguage = strInterfaceLanguage
                objBCommonDB.DBServer = strDBServer
                objBCommonDB.ConnectionString = strConnectionString
                objBCommonDB.Initialize()

                objBString.InterfaceLanguage = strInterfaceLanguage
                objBString.DBServer = strDBServer
                objBString.ConnectionString = strConnectionString
                objBString.Initialize()

                objDDicItemType.DBServer = strDBServer
                objDDicItemType.ConnectionString = strConnectionString
                objDDicItemType.Initialize()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Insert method
        Public Function Insert() As Integer
            Dim StrTmp As String
            Try
                StrTmp = objBString.ConvertItBack(strTypeCode)
                objDDicItemType.TypeCode = StrTmp
                objDDicItemType.TypeName = objBString.ConvertItBack(strTypeName)
                objDDicItemType.AccessEntry = objBString.ProcessVal(StrTmp)
                Insert = objDDicItemType.Insert()
                strErrormsg = objDDicItemType.ErrorMsg
                intErrorcode = objDDicItemType.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Update method
        Public Function Update() As Integer
            Dim StrTmp As String
            Try
                StrTmp = objBString.ConvertItBack(strTypeCode)
                objDDicItemType.TypeCode = StrTmp
                objDDicItemType.TypeName = objBString.ConvertItBack(strTypeName)
                objDDicItemType.AccessEntry = objBString.ProcessVal(StrTmp)
                objDDicItemType.ID = intID
                Update = objDDicItemType.Update()
                strErrormsg = objDDicItemType.ErrorMsg
                intErrorcode = objDDicItemType.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Merge method
        Public Sub Merge()
            Try
                objDDicItemType.IDs = strIDs
                objDDicItemType.ID = intID
                objDDicItemType.Merge()
                strerrormsg = objDDicItemType.ErrorMsg
                interrorcode = objDDicItemType.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Retrieve method
        Public Function Retrieve() As DataTable
            Try
                objDDicItemType.AccessEntry = objBString.ProcessVal(objBString.ConvertItBack(strTypeCode))
                Retrieve = objBCommonDB.ConvertTable(objDDicItemType.Retrieve)
                strerrormsg = objDDicItemType.ErrorMsg
                interrorcode = objDDicItemType.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetAll() As DataTable
            Try
                GetAll = objDDicItemType.GetAll()
                strErrorMsg = objDDicItemType.ErrorMsg
                intErrorCode = objDDicItemType.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Release resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCommonDB Is Nothing Then
                    objBCommonDB.Dispose(True)
                    objBCommonDB = Nothing
                End If
                If Not objBString Is Nothing Then
                    objBString.Dispose(True)
                    objBString = Nothing
                End If
                If Not objDDicItemType Is Nothing Then
                    objDDicItemType.Dispose(True)
                    objDDicItemType = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
