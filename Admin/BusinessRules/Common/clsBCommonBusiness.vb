Imports System
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Common

Namespace eMicLibAdmin.BusinessRules.Common
    Public Class clsBCommonBusiness
        Inherits clsBBase

        ' *******************************************************************************************************
        ' Declare Private variables
        ' *******************************************************************************************************

        Private strCurrencyCode As String = ""
        Private lngItemID As Long = 0

        Private objBCDBS As New clsBCommonDBSystem
        Private objDCommonBusiness As New clsDCommonBusiness
        Private objDCommon As New clsDCommon


        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' CurrencyCode property
        Public Property CurrencyCode() As String
            Get
                Return strCurrencyCode
            End Get
            Set(ByVal Value As String)
                strCurrencyCode = Value
            End Set
        End Property

        ' ItemID property
        Public Property ItemID() As Long
            Get
                Return lngItemID
            End Get
            Set(ByVal Value As Long)
                lngItemID = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Initialize method
        Public Sub Initialize()
            ' Init objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.Initialize()

            'Init objDCommon object
            objDCommon.DBServer = strDBServer
            objDCommon.ConnectionString = strConnectionString
            objDCommon.Initialize()

            ' Init objDCommonBusiness object
            objDCommonBusiness.DBServer = strDBServer
            objDCommonBusiness.ConnectionString = strConnectionString
            objDCommonBusiness.Initialize()
        End Sub

        ' GetRegularity method
        ' Purpose: Get Regularity
        ' Output: Datatable result
        Public Function GetRegularity() As DataTable
            Try
                GetRegularity = objBCDBS.ConvertTable(objDCommonBusiness.GetRegularity, False, True)
                intErrorCode = objDCommonBusiness.ErrorCode
                strErrorMsg = objDCommonBusiness.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function ExcuteQuery(ByVal stringQuery As String) As DataTable
            Try
                ExcuteQuery = objDCommonBusiness.ExcuteQuery(stringQuery)
                strErrorMsg = objDCommonBusiness.ErrorMsg
                intErrorCode = objDCommonBusiness.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        Public Function ExcuteQueryToDatatable(ByVal stringQuery As String) As DataTable
            Try
                ExcuteQueryToDatatable = objDCommonBusiness.ExcuteQueryToDatatable(stringQuery)
                strErrorMsg = objDCommonBusiness.ErrorMsg
                intErrorCode = objDCommonBusiness.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        ' GetCategories method
        ' Purpose: Get Categories
        ' Output: Datatable result
        Public Function GetCategories() As DataTable
            Try
                GetCategories = objBCDBS.ConvertTable(objDCommonBusiness.GetCategories, False, True)
                intErrorCode = objDCommonBusiness.ErrorCode
                strErrorMsg = objDCommonBusiness.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetLanguages method
        ' Purpose: Get Languages
        ' Output: Datatable result
        Public Function GetLanguages() As DataTable
            Try
                GetLanguages = objBCDBS.ConvertTable(objDCommonBusiness.GetLanguages, False, True)
                intErrorCode = objDCommonBusiness.ErrorCode
                strErrorMsg = objDCommonBusiness.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetMediums method
        ' Purpose: Get mediums
        ' Output: Datatable result
        Public Function GetMediums() As DataTable
            Try
                GetMediums = objBCDBS.ConvertTable(objDCommonBusiness.GetMediums, False, True)
                intErrorCode = objDCommonBusiness.ErrorCode
                strErrorMsg = objDCommonBusiness.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetCountries method
        ' Purpose: Get Countries
        ' Output: Datatable result
        Public Function GetCountries() As DataTable
            Try
                GetCountries = objBCDBS.ConvertTable(objDCommonBusiness.GetCountries, False, True)
                intErrorCode = objDCommonBusiness.ErrorCode
                strErrorMsg = objDCommonBusiness.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetAcqSources method
        ' Purpose: Get Sources
        ' Output: Datatable result
        Public Function GetAcqSources() As DataTable
            Try
                GetAcqSources = objBCDBS.ConvertTable(objDCommonBusiness.GetAcqSources, False, True)
                intErrorCode = objDCommonBusiness.ErrorCode
                strErrorMsg = objDCommonBusiness.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetCurrencyByID(ByVal intID As Integer) As DataTable
            Try
                GetCurrencyByID = objDCommonBusiness.GetCurrencyByID(intID)
                intErrorCode = objDCommonBusiness.ErrorCode
                strErrorMsg = objDCommonBusiness.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetCurrency method
        ' Purpose: Get Currency
        ' Output: Datatable result
        Public Function GetCurrency() As DataTable
            Try
                objDCommonBusiness.CurrencyCode = strCurrencyCode
                GetCurrency = objDCommonBusiness.GetCurrency
                intErrorCode = objDCommonBusiness.ErrorCode
                strErrorMsg = objDCommonBusiness.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetAcqStatus method
        ' Purpose: Get acquire status
        ' Output: Datatable result
        Public Function GetAcqStatus() As DataTable
            Try
                GetAcqStatus = objBCDBS.ConvertTable(objDCommonBusiness.GetAcqStatus, False, True)
                intErrorCode = objDCommonBusiness.ErrorCode
                strErrorMsg = objDCommonBusiness.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetRecordTypes method
        ' Purpose: Get all recordtypes
        ' Output: Datatable result
        Public Function GetRecordTypes() As DataTable
            Try
                GetRecordTypes = objBCDBS.ConvertTable(objDCommonBusiness.GetRecordTypes, False, True)
                intErrorCode = objDCommonBusiness.ErrorCode
                strErrorMsg = objDCommonBusiness.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetDirLevels method
        ' Purpose: Get all dirlevels
        ' Output: Datatable result
        Public Function GetDirLevels() As DataTable
            Try
                GetDirLevels = objBCDBS.ConvertTable(objDCommonBusiness.GetDirLevels, False, True)
                intErrorCode = objDCommonBusiness.ErrorCode
                strErrorMsg = objDCommonBusiness.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetUserLocations method
        ' Purpose: Get valid locations of the SelectedUser
        ' Input: intUserID
        ' Output: datatable result
        Public Function GetLocations(Optional ByVal intSubsystemID As Integer = 1) As DataTable
            Try
                objDCommonBusiness.UserID = intUserID
                objDCommonBusiness.LibID = intLibID
                GetLocations = objBCDBS.ConvertTable(objDCommonBusiness.GetLocations(intSubsystemID))
                strErrorMsg = objBCDBS.ErrorMsg
                intErrorCode = objBCDBS.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetRoutingLocations method
        ' Purpose: Get valid routing locations of the SelectedUser and selected ItemID
        ' Input: intUserID, lngItemID
        ' Output: datatable result
        Public Function GetRoutingLocations() As DataTable
            Try
                objDCommonBusiness.UserID = intUserID
                objDCommonBusiness.ItemID = lngItemID
                GetRoutingLocations = objBCDBS.ConvertTable(objDCommonBusiness.GetRoutingLocations())
                strErrorMsg = objBCDBS.ErrorMsg
                intErrorCode = objBCDBS.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetLibraries method
        ' Purpose: Get all libraries
        ' Input : some information
        ' Output: datatable result
        ' Modify : Lent
        Public Function GetLibraries(Optional ByVal intLibID As Integer = 0, Optional ByVal intLocalLib As Integer = -1, Optional ByVal intStatus As Integer = -1, Optional ByVal intUserID As Integer = 0, Optional ByVal intType As Integer = 1) As DataTable
            Try
                GetLibraries = objBCDBS.ConvertTable(objDCommonBusiness.GetLibraries(intLibID, intLocalLib, intStatus, intUserID, intType))
                strErrorMsg = objBCDBS.ErrorMsg
                intErrorCode = objBCDBS.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetGenClassification method
        ' Purpose: Get all general classifications
        ' Output: Datatable result
        Public Function GetGenClassification() As DataTable
            Try
                GetGenClassification = objBCDBS.ConvertTable(objDCommonBusiness.GetGenClassification)
                strErrorMsg = objBCDBS.ErrorMsg
                intErrorCode = objBCDBS.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function


        ' GetRightUserInfor
        ' Input: int UserID
        ' Output: DataTable content Right this user
        Public Function GetUserRight() As DataTable
            Try
                objDCommon.UserID = intUserID
                GetUserRight = objDCommon.GetUserRight
                strErrorMsg = objBCDBS.ErrorMsg
                intErrorCode = objBCDBS.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Sub DeleteSystemCode(ByVal strWhere As String)
            objDCommonBusiness.DeleteSystemCode(strWhere)
            strSQL = objDCommonBusiness.SQLStatement
        End Sub

        Public Function GetItemTypes() As DataTable
            Try
                GetItemTypes = objBCDBS.ConvertTable(objDCommonBusiness.GetItemTypes, False, True)
                strErrorMsg = objBCDBS.ErrorMsg
                intErrorCode = objBCDBS.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCDBS Is Nothing Then
                    Call objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objDCommon Is Nothing Then
                    objDCommon.Dispose(True)
                    objDCommon = Nothing
                End If
                If Not objDCommonBusiness Is Nothing Then
                    objDCommonBusiness.Dispose(True)
                    objDCommonBusiness = Nothing
                End If
            Finally
                Call MyBase.Dispose()
                Call Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace