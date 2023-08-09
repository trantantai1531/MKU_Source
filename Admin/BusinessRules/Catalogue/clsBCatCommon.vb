Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Catalogue

Namespace eMicLibAdmin.BusinessRules.Catalogue
    Public Class clsBCatCommon
        Inherits clsBBase

        ' Declare variables
        Private objBCommonDBSystem As New clsBCommonDBSystem
        Private objBCommonStringProc As New clsBCommonStringProc
        Private objDCatCommon As New clsDCatCommon
        Private strItemTypeID As String
        Private intIDUser As Integer

        ' ***************************************************************************************************
        ' Public Properties
        ' ***************************************************************************************************

        'Dictionary
        Private intDicID As Integer
        Private strMethodSort As String
        Private strDicVal As String
        Private intDicTop As Integer

        ' ---- DicID Property
        Public Property DicID() As Integer
            Get
                DicID = intDicID
            End Get
            Set(ByVal Value As Integer)
                intDicID = Value
            End Set
        End Property

        ' ---- MethodSort Property
        Public Property MethodSort() As String
            Get
                MethodSort = strMethodSort
            End Get
            Set(ByVal Value As String)
                strMethodSort = Value
            End Set
        End Property

        ' ---- DicVal Property
        Public Property DicVal() As String
            Get
                DicVal = strDicVal
            End Get
            Set(ByVal Value As String)
                strDicVal = Value
            End Set
        End Property

        ' ---- DicID Property
        Public Property DicTop() As Integer
            Get
                DicTop = intDicTop
            End Get
            Set(ByVal Value As Integer)
                intDicTop = Value
            End Set
        End Property

        ' ---- ItemType
        Public Property ItemType() As String
            Get
                Return strItemTypeID
            End Get
            Set(ByVal Value As String)
                strItemTypeID = Value
            End Set
        End Property

        ' ---- IDUser Property
        Public Property IDUser() As Integer
            Get
                IDUser = intIDUser
            End Get
            Set(ByVal Value As Integer)
                intIDUser = Value
            End Set
        End Property

        ' ***************************************************************************************************
        ' Initialize method
        ' ***************************************************************************************************
        Public Sub Initialize()
            ' ---- Init objBCommonStringProc
            objBCommonStringProc.DBServer = strDBServer
            objBCommonStringProc.ConnectionString = strConnectionString
            objBCommonStringProc.InterfaceLanguage = strInterfaceLanguage
            Call objBCommonStringProc.Initialize()

            ' ---- Init objBCommonDBSystem
            objBCommonDBSystem.DBServer = strDBServer
            objBCommonDBSystem.ConnectionString = strConnectionString
            objBCommonDBSystem.InterfaceLanguage = strInterfaceLanguage
            Call objBCommonDBSystem.Initialize()

            ' ---- Init objDCatCommon
            objDCatCommon.DBServer = strDBServer
            objDCatCommon.ConnectionString = strConnectionString
            objDCatCommon.Initialize()
        End Sub

        ' ***************************************************************************************************
        ' Retrieve ItemType
        ' In: strItemType
        ' Output: DataTable
        ' ***************************************************************************************************
        Public Function RetrieveItemType() As DataTable
            Try
                objDCatCommon.ItemTypeId = strItemTypeID
                RetrieveItemType = objBCommonDBSystem.ConvertTable(objDCatCommon.RetrieveItemType)
                strErrorMsg = objDCatCommon.ErrorMsg
                intErrorCode = objDCatCommon.ErrorCode
            Catch Ex As Exception
                strErrorMsg = Ex.Message
            Finally
            End Try
        End Function

        ' ***************************************************************************************************
        ' Get User
        ' In: strItemType
        ' Output: DataTable
        ' ***************************************************************************************************
        Public Function GetUsers() As DataTable
            Try
                objDCatCommon.IDUser = intIDUser
                objDCatCommon.LibID = intLibID
                GetUsers = objBCommonDBSystem.ConvertTable(objDCatCommon.GetUsers)
                strErrorMsg = objDCatCommon.ErrorMsg
                intErrorCode = objDCatCommon.ErrorCode
            Catch Ex As Exception
                strErrorMsg = Ex.Message
            Finally
            End Try
        End Function

        ' ***************************************************************************************************
        'getAutocompleteDictionary method
        ' Retrieve dictionary
        ' In: intDicID,strMethodSort,strDicVal,intDicTop
        ' Output: DataTable
        ' ***************************************************************************************************
        Public Function getAutocompleteDictionary() As DataTable
            Try
                objDCatCommon.DicID = DicID
                objDCatCommon.MethodSort = MethodSort
                objDCatCommon.DicVal = DicVal
                objDCatCommon.DicTop = DicTop
                getAutocompleteDictionary = objBCommonDBSystem.ConvertTable(objDCatCommon.getAutocompleteDictionary)
                strErrorMsg = objDCatCommon.ErrorMsg
                intErrorCode = objDCatCommon.ErrorCode
            Catch Ex As Exception
                strErrorMsg = Ex.Message
            Finally
            End Try
        End Function

        ' ***************************************************************************************************
        ' Release resource
        ' ***************************************************************************************************
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objDCatCommon Is Nothing Then
                    objDCatCommon.Dispose(True)
                    objDCatCommon = Nothing
                End If
                If Not objBCommonStringProc Is Nothing Then
                    objBCommonStringProc.Dispose(True)
                    objBCommonStringProc = Nothing
                End If
                If Not objBCommonDBSystem Is Nothing Then
                    objBCommonDBSystem.Dispose(True)
                    objBCommonDBSystem = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

    End Class
End Namespace