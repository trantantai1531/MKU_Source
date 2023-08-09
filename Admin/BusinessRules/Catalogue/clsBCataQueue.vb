Imports System
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Catalogue

Namespace eMicLibAdmin.BusinessRules.Catalogue
    Public Class clsBCataQueue
        Inherits clsBBase

        ' *****************************************************************************************************
        ' Declare Private variables
        ' *****************************************************************************************************

        ' Private members variables
        Private strAll As String
        Private strMonth As String
        Private strDash As String
        Private strNotCatalog As String
        Private strCatalog As String
        Private strInputDate As String
        Private intReviewed As Integer
        Private strSort As String

        Private objBCDBS As New clsBCommonDBSystem
        Private objDCataQueue As New clsDCataQueue

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' Sort property 
        Public Property Sort() As String
            Get
                Sort = strSort
            End Get
            Set(ByVal Value As String)
                strSort = Value
            End Set
        End Property

        ' InputDate Reviewed property 
        Public Property Reviewed() As Integer
            Get
                Reviewed = intReviewed
            End Get
            Set(ByVal Value As Integer)
                intReviewed = Value
            End Set
        End Property

        ' InputDate property
        Public Property InputDate() As String
            Get
                InputDate = strInputDate
            End Get
            Set(ByVal Value As String)
                strInputDate = Value
            End Set
        End Property

        ' Catalog property
        Public Property Catalog() As String
            Get
                Catalog = strCatalog
            End Get
            Set(ByVal Value As String)
                strCatalog = Value
            End Set
        End Property

        ' NotCatalog property
        Public Property NotCatalog() As String
            Get
                NotCatalog = strNotCatalog
            End Get
            Set(ByVal Value As String)
                strNotCatalog = Value
            End Set
        End Property

        ' Dash property
        Public Property Dash() As String
            Get
                Dash = strDash
            End Get
            Set(ByVal Value As String)
                strDash = Value
            End Set
        End Property

        ' Month property
        Public Property Month() As String
            Get
                Month = strMonth
            End Get
            Set(ByVal Value As String)
                strMonth = Value
            End Set
        End Property

        ' All property
        Public Property All() As String
            Get
                All = strAll
            End Get
            Set(ByVal Value As String)
                strAll = Value
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
                ' Init objBCDBS
                objBCDBS.InterfaceLanguage = strInterfaceLanguage
                objBCDBS.ConnectionString = strConnectionString
                objBCDBS.DBServer = strDBserver
                Call objBCDBS.Initialize()

                ' init objDCataQueue
                objDCataQueue.DBServer = strDBServer
                objDCataQueue.ConnectionString = strConnectionString
                Call objDCataQueue.Initialize()
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        ' RetrieveInputTime method
        Public Function RetrieveInputTime(ByVal intReviewed As Integer, Optional ByRef intTotals As Integer = 0) As DataTable
            ' Declare varibles
            Dim tblItemCat As New DataTable
            Dim strCurMon As String
            Dim inti As Integer
            Dim intTotal As Long
            Dim tblTmp As DataTable = New DataTable
            Dim dtcCols As DataColumn
            Dim dtrRow As DataRow
            Dim intj As Integer

            Try
                intTotal = 0

                ' Get the Catalogue time
                objDCataQueue.LibID = intLibID
                tblItemCat = objDCataQueue.RetrieveInputTime(intReviewed)

                ' Create the first collumn and add to tblTmp
                dtcCols = New DataColumn
                dtcCols.DataType = System.Type.GetType("System.String")
                dtcCols.ColumnName = "ID"
                tblTmp.Columns.Add(dtcCols)

                ' Create the second column and add to tblTmp
                dtcCols = New DataColumn
                dtcCols.DataType = System.Type.GetType("System.String")
                dtcCols.ColumnName = "Text"
                tblTmp.Columns.Add(dtcCols)

                ' Add the first row (Total record)            
                For inti = 0 To tblItemCat.Rows.Count - 1
                    intTotal = intTotal + tblItemCat.Rows(inti).Item("NOR")
                Next inti
                intTotals = intTotal
                ' Add the details in to the first row
                dtrRow = tblTmp.NewRow()
                dtrRow("ID") = ""
                dtrRow("Text") = strAll + CStr(intTotal)
                tblTmp.Rows.Add(dtrRow)

                ' Add two datarow collection to the tblTemp
                strCurMon = ""
                For inti = 0 To tblItemCat.Rows.Count - 1
                    Dim blnFound As Boolean = False

                    ' YYYYMM -> MM/YYYY
                    tblItemCat.Rows(inti).Item("DT") = Right(CStr(tblItemCat.Rows(inti).Item("DT")), 2) & "/" & Left(CStr(tblItemCat.Rows(inti).Item("DT")), 4)
                    If Not strCurMon = tblItemCat.Rows(inti).Item("DT") Then
                        For intj = 0 To tblTmp.Rows.Count - 1
                            If tblTmp.Rows(intj).Item("ID") = tblItemCat.Rows(inti).Item("DT") Then
                                blnFound = True
                            End If
                        Next
                        If blnFound = False Then
                            'dtrRow = tblTmp.NewRow()
                            'dtrRow("ID") = tblItemCat.Rows(inti).Item("DT")
                            'dtrRow("Text") = strMonth & tblItemCat.Rows(inti).Item("DT") & strDash
                            'tblTmp.Rows.Add(dtrRow)
                        End If
                    End If
                    ' Reviewed or not
                    If CStr(tblItemCat.Rows(inti).Item("Reviewed")) = "0" Then
                        dtrRow = tblTmp.NewRow()
                        dtrRow("ID") = tblItemCat.Rows(inti).Item("DT") & ":0"
                        dtrRow("Text") = strMonth & tblItemCat.Rows(inti).Item("DT") & "(" & CStr(tblItemCat.Rows(inti).Item("NOR")) & ")"
                        tblTmp.Rows.Add(dtrRow)
                    Else
                        dtrRow = tblTmp.NewRow()
                        dtrRow("ID") = tblItemCat.Rows(inti).Item("DT") & ":1"
                        dtrRow("Text") = strMonth & tblItemCat.Rows(inti).Item("DT") & "(" & CStr(tblItemCat.Rows(inti).Item("NOR")) & ")"
                        tblTmp.Rows.Add(dtrRow)
                    End If
                Next inti
                RetrieveInputTime = tblTmp
                strErrorMsg = objDCataQueue.ErrorMsg
                intErrorCode = objDCataQueue.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose: Get quick view for main catalogue page
        ' Creator: Sondp
        ' CreatedData: 05/11/2005
        ' Out: Datatable
        Public Function GetQuickView() As DataTable
            Try
                objDCataQueue.LibID = intLibID
                GetQuickView = objDCataQueue.GetQuickView
                strErrorMsg = objDCataQueue.ErrorMsg
                intErrorCode = objDCataQueue.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' RetrieveItemCatQueueField method
        Public Function RetrieveItemCatQueueField(ByVal intModeSort As Integer) As DataTable
            ' Declare variable
            Dim tbl As New DataTable
            Try
                If Trim(strInputDate) <> "" Then
                    objDCataQueue.InputDate = objBCDBS.ConvertDateBack("01/" & strInputDate)
                Else
                    objDCataQueue.InputDate = strInputDate
                End If
                objDCataQueue.Reviewed = intReviewed
                objDCataQueue.LibID = intLibID
                tbl = objBCDBS.ConvertTable(objDCataQueue.RetrieveItemCatQueueField(intModeSort), "Content")
                strErrorMsg = objDCataQueue.ErrorMsg
                intErrorCode = objDCataQueue.ErrorCode
                If intModeSort = 0 Then ' Sort by Title
                    'Dim dv As New DataView(tbl)
                    'dv = objBCDBS.SortTable(tbl, "Content")
                    Return objBCDBS.SortTable(tbl, "Content")
                Else
                    Return tbl
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose: danh sach bien muc so luoc theo Inputdate(like as RetrieveItemCatQueueField defirrent at sort field)
        ' Input: intReviewed, Inputdate, intModeSort(0: Title, 1: CreatedDate, 2: Code)
        ' Output: DataTable have sorted
        Public Function GetItemCatQueueField(ByVal intModeSort As Integer) As DataTable
            ' Declare variable
            Dim TblRet As New DataTable
            Dim tbl As New DataTable
            objDCataQueue.LibID = intLibID
            Try
                If Trim(strInputDate) <> "" Then
                    objDCataQueue.InputDate = objBCDBS.ConvertDateBack("01/" & strInputDate)
                Else
                    objDCataQueue.InputDate = strInputDate
                End If
                objDCataQueue.Reviewed = intReviewed

                tbl = objBCDBS.ConvertTable(objDCataQueue.GetItemCatQueueField(intModeSort), "Content")
                strErrorMsg = objDCataQueue.ErrorMsg
                intErrorCode = objDCataQueue.ErrorCode
                If intModeSort = 0 Then
                    'Dim dv As New DataView
                    'dv = objBCDBS.SortTable(tbl, "Content")
                    Return objBCDBS.SortTable(tbl, "Content")
                Else
                    Return (tbl)
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function
        Public Function GetItemCatQueueFieldPaging(ByVal intModeSort As Integer, ByVal offset As Integer, ByVal take As Integer, ByRef total As Integer) As DataTable
            ' Declare variable
            Dim TblRet As New DataTable
            Dim tbl As New DataTable
            objDCataQueue.LibID = intLibID
            Try
                If Trim(strInputDate) <> "" Then
                    objDCataQueue.InputDate = objBCDBS.ConvertDateBack("01/" & strInputDate)
                Else
                    objDCataQueue.InputDate = strInputDate
                End If
                objDCataQueue.Reviewed = intReviewed

                tbl = objBCDBS.ConvertTable(objDCataQueue.GetItemCatQueueFieldPaging(intModeSort, offset, take, total), "Content")
                strErrorMsg = objDCataQueue.ErrorMsg
                intErrorCode = objDCataQueue.ErrorCode
                If intModeSort = 0 Then
                    'Dim dv As New DataView
                    'dv = objBCDBS.SortTable(tbl, "Content")
                    Return objBCDBS.SortTable(tbl, "Content")
                Else
                    Return (tbl)
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                ' Release unmanaged resources.               
                If isDisposing Then
                    If Not objDCataQueue Is Nothing Then
                        objDCataQueue.Dispose(True)
                        objDCataQueue = Nothing
                    End If
                    If Not objBCDBS Is Nothing Then
                        objBCDBS.Dispose(True)
                        objBCDBS = Nothing
                    End If
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
