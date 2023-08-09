Imports System
Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibOPAC.DataAccess.OPAC


Namespace eMicLibOPAC.BusinessRules.OPAC
    Public Class clsBOPACFilterBrowse
        Inherits clsBBase
        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private intIDDic As Integer
        Private intID As Integer
        Private intItemID As Integer
        Private strIds As String
        Private strWords As String
        Private objDFilterBrowse As New clsDOPACFilterBrowse
        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem

        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************
        Public Property ItemID() As Integer
            Get
                Return intItemID
            End Get
            Set(ByVal Value As Integer)
                intItemID = Value
            End Set
        End Property
        Public Property ID() As Integer
            Get
                Return intID
            End Get
            Set(ByVal Value As Integer)
                intID = Value
            End Set
        End Property
        Public Property DicID() As Integer
            Get
                Return intIDDic
            End Get
            Set(ByVal Value As Integer)
                intIDDic = Value
            End Set
        End Property
        Public Property Ids() As String
            Get
                Return strIds
            End Get
            Set(ByVal Value As String)
                strIds = Value
            End Set
        End Property
        Public Property Words() As String
            Get
                Return strWords
            End Get
            Set(ByVal Value As String)
                strWords = Value
            End Set
        End Property
        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************
        ' Initialize method
        Public Sub Initialize()
            ' Init objDHoldingCollection object
            objDFilterBrowse.DBServer = strDBServer
            objDFilterBrowse.ConnectionString = strConnectionString
            objDFilterBrowse.Initialize()

            ' Init objBCSP object
            objBCSP.DBServer = strDBServer
            objBCSP.ConnectionString = strConnectionString
            objBCSP.InterfaceLanguage = strInterfaceLanguage
            objBCSP.Initialize()

            ' Init objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.Initialize()
        End Sub
        ' Purpose: Get information depend on @strWord input and intIDDIc
        ' Input: intIDDic, @strWord
        ' Output: Datatable 
        ' Created by: 
        Public Function GetAllBrowseByWord(ByVal strSort As String, Optional ByVal strSortMethod As String = "ASC", Optional ByVal intTop As Integer = 50, Optional ByVal intLibID As Integer = 0) As DataView
            Dim dvResult As DataView = Nothing

            Try
                objDFilterBrowse.DicID = intIDDic
                objDFilterBrowse.Words = Words
                dvResult = objDFilterBrowse.GetAllBrowseByWord(strSort, strSortMethod, intTop, intLibID).DefaultView
                'End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return dvResult
        End Function

        ' Purpose: Get information depend on @strWord input and intIDDIc
        ' Input: intIDDic, @strWord
        ' Output: Datatable 
        ' Created by: 
        Public Function GetAllBrowseMoreByWord(ByVal strSort As String, Optional ByVal strSortMethod As String = "ASC", Optional ByVal intTop As Integer = 50) As DataView
            Dim dvResult As DataView = Nothing

            Try
                objDFilterBrowse.DicID = intIDDic
                objDFilterBrowse.Words = Words
                objDFilterBrowse.IDs = strIds
                dvResult = objDFilterBrowse.GetAllBrowseMoreByWord(strSort, strSortMethod, intTop).DefaultView
                'End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return dvResult
        End Function

        ' Purpose: Get information depend on strIds input and intIDDIc
        ' Input: intIDDic, strIds
        ' Output: Datatable 
        ' Created by: 
        Public Function GetFilterBrowse(ByVal strSort As String, Optional ByVal strSortMethod As String = "ASC", Optional ByVal intTop As Integer = 50) As DataView
            Dim dvResult As DataView = Nothing

            Try
                objDFilterBrowse.DicID = intIDDic
                objDFilterBrowse.IDs = strIds
                'If intIDDic = 6 Then
                '    GetSubjBrowse = objBCDBS.SortTable(objBCDBS.ConvertTable(objDFilterBrowse.GetSubjBrowse(), "DisplayEntry"), "DisplayEntry")
                'Else
                'dvResult = objBCDBS.eSortTable(objBCDBS.ConvertTable(objDFilterBrowse.GetFilterBrowse()), strSort, strSortMethod)
                dvResult = objDFilterBrowse.GetFilterBrowse(strSort, strSortMethod, intTop).DefaultView
                'End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return dvResult
        End Function


        ' Purpose: Get information depend on strIds input and intIDDIc
        ' Input: intIDDic, strIds
        ' Output: Datatable 
        ' Created by: 
        Public Function GetFilterBrowseByMerge(Optional ByVal intTop As Integer = 50) As DataView
            Dim dvResult As DataView = Nothing
            Try

                objDFilterBrowse.IDs = strIds
                dvResult = objDFilterBrowse.GetFilterBrowseByMerge(intTop).DefaultView
                'Dim dtResult As DataTable = objDFilterBrowse.RunQuerySql(strIds)
                'Dim arrIDs As String = objBCSP.getiTemString(dtResult)
                'objDFilterBrowse.IDs = arrIDs
                'dvResult = objDFilterBrowse.GetFilterBrowseByMerge(intTop).DefaultView
                'End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return dvResult
        End Function

        ' Purpose: Get information depend on strWord input and intIDDIc
        ' Input: intIDDic, intID
        ' Output: Datatable 
        ' Created by: phuongtt 2014.08.14
        Public Function GetFilterBrowseByID() As DataTable
            Dim dvResult As DataTable = Nothing
            Try
                objDFilterBrowse.ID = intID
                objDFilterBrowse.DicID = intIDDic
                objDFilterBrowse.IDs = strIds
                dvResult = objDFilterBrowse.GetFilterBrowseByID()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return dvResult
        End Function

        ' ' Purpose: Get treeview DDC data
        ' Input: strIds
        ' Output: Datatable 
        ' Created by: Phuongtt 2014.08.27
        Public Function GetTreeviewDDC() As DataTable
            Dim dvResult As DataTable = Nothing

            Try
                objDFilterBrowse.IDs = strIds
                'If intIDDic = 6 Then
                '    GetSubjBrowse = objBCDBS.SortTable(objBCDBS.ConvertTable(objDFilterBrowse.GetSubjBrowse(), "DisplayEntry"), "DisplayEntry")
                'Else
                dvResult = objDFilterBrowse.GetTreeviewDDC
                'End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return dvResult
        End Function

        ' ' Purpose: Get treeview DDC data
        ' Input: Words
        ' Output: Datatable 
        ' Created by: Phuongtt 2014.11.07
        Public Function GetTBrowseTreeviewDDC(Optional ByVal intLibID As Integer = 0) As DataTable
            Dim dvResult As DataTable = Nothing

            Try
                objDFilterBrowse.Words = Words
                dvResult = objDFilterBrowse.GetTBrowseTreeviewDDC(intLibID)
                'End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return dvResult
        End Function

        ' Purpose: Get ItemIDs from Browse
        ' Input: intIDDic, @strIds
        ' Output: Datatable 
        ' Created by: PhuongTT - 2014.11.07
        Public Function GetItemIdsFromBrowse() As DataTable
            Dim dvResult As DataTable = Nothing
            Try
                objDFilterBrowse.DicID = DicID
                objDFilterBrowse.IDs = strIds
                dvResult = objDFilterBrowse.GetItemIdsFromBrowse
                'End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return dvResult
        End Function

        ' getBrowseByCollection method
        ' Purpose: Get collection by parentID
        ' Creator: PhuongTT
        ' CreatedDate: 2014.11.07
        Public Function getBrowseByCollection() As DataTable
            Dim dvResult As DataTable = Nothing
            Try
                objDFilterBrowse.ID = ID
                dvResult = objDFilterBrowse.getBrowseByCollection
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return dvResult
        End Function

        ' getRelatedWords method
        ' Purpose: Get dictionary word by itemID
        ' Creator: PhuongTT
        ' CreatedDate: 2014.11.18
        Public Function getRelatedWords() As DataTable
            Dim dvResult As DataTable = Nothing
            Try
                objDFilterBrowse.ItemID = ItemID
                dvResult = objDFilterBrowse.getRelatedWords
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return dvResult
        End Function
        Public Function RunQuerySql(ByVal strSql As String) As DataTable
            Dim dvResult As DataTable = Nothing
            Try
                dvResult = objDFilterBrowse.RunQuerySql(strSql)
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return dvResult
        End Function
        'Dispose method
        'Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                End If
                If Not objBCSP Is Nothing Then
                    Call objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    Call objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Dispose()
            End Try
        End Sub

    End Class
End Namespace

