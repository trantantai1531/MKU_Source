Imports System
Imports System.Data
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Circulation

Namespace eMicLibAdmin.BusinessRules.Circulation
    Public Class clsBCirCommon
        Inherits clsBBase

        ' *****************************************************************************************************
        ' Declare member variables
        ' *****************************************************************************************************

        Private objBCDBS As New clsBCommonDBSystem
        Private objDCirCommon As New clsDCirCommon

        Private strCurrencyCode As String = ""
        Private strItemTypeID As String = ""
        Private strMediumID As String = ""


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

        ' ItemTypeID property
        Public Property ItemType() As String
            Get
                Return strItemTypeID
            End Get
            Set(ByVal Value As String)
                strItemTypeID = Value
            End Set
        End Property

        ' MediumID property
        Public Property MediumID() As String
            Get
                Return strMediumID
            End Get
            Set(ByVal Value As String)
                strMediumID = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Initialize method
        ' Purpose: Init all necessary objects
        Public Sub Initialize()
            Try
                ' Init objBCDBS object
                objBCDBS.ConnectionString = strConnectionString
                objBCDBS.DBServer = strDBServer
                objBCDBS.InterfaceLanguage = strInterfaceLanguage
                Call objBCDBS.Initialize()

                ' Init objDCirCommon object
                objDCirCommon.ConnectionString = strConnectionString
                objDCirCommon.DBServer = strDBServer
                Call objDCirCommon.Initialize()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' GetCurrency method
        ' Purpose: Get currency exchange
        ' Input: strCurrencyCode
        ' Output: datatable result
        Public Function GetCurrency() As DataTable
            Try
                GetCurrency = objBCDBS.ConvertTable(objDCirCommon.GetCurrency())
                strErrorMsg = objBCDBS.ErrorMsg
                intErrorCode = objBCDBS.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetMediumInfor method
        ' Purpose: Retrieve medium from Cat_tblDicMedium
        ' Input: strCurrencyCode
        ' Output: DataTable
        Public Function GetMediumInfor() As DataTable
            Try
                objDCirCommon.MediumID = strMediumID
                GetMediumInfor = objBCDBS.ConvertTable(objDCirCommon.GetMediumInfor)
                strErrorMsg = objBCDBS.ErrorMsg
                intErrorCode = objBCDBS.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetItemType method 
        ' purpose: Retrieve medium from Cat_tblDic_ItemType
        ' Input: strItemTypeID
        ' Output: DataTable
        Public Function GetItemType() As DataTable
            Try
                objDCirCommon.ItemType = strItemTypeID
                GetItemType = objBCDBS.ConvertTable(objDCirCommon.GetItemType)
                strErrorMsg = objBCDBS.ErrorMsg
                intErrorCode = objBCDBS.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetFormID(ByVal intBookType As Integer) As DataTable
            Try
                GetFormID = objBCDBS.ConvertTable(objDCirCommon.GetFormID(intBookType))
                strErrorMsg = objDCirCommon.ErrorMsg
                intErrorCode = objDCirCommon.ErrorCode
            Catch Ex As Exception
                strErrorMsg = Ex.Message
            Finally
            End Try
        End Function

        Public Function Get_Marc_WS_MinID() As DataTable
            Try
                Get_Marc_WS_MinID = objBCDBS.ConvertTable(objDCirCommon.Get_Marc_WS_MinID())
                strErrorMsg = objDCirCommon.ErrorMsg
                intErrorCode = objDCirCommon.ErrorCode
            Catch Ex As Exception
                strErrorMsg = Ex.Message
            Finally
            End Try
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            If isDisposing Then
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objDCirCommon Is Nothing Then
                    objDCirCommon.Dispose(True)
                    objDCirCommon = Nothing
                End If
            End If
            MyBase.Dispose()
            Me.Dispose()
        End Sub
    End Class
End Namespace