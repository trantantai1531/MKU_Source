'  Class: clsBInventory
'  Purpose:
'  Creator: Tuanhv
'  Created date: 09/03/2004
'  Modification history:

Imports eMicLibAdmin.DataAccess.Acquisition
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.BusinessRules.Acquisition
    Public Class clsBInventory
        Inherits clsBBase

        Private strShelf As String = ""
        Private strCopyIDs As String = ""
        Private strCopyNumbers As String = ""
        Private intLibID As Integer = 0
        Private intLocationID As Integer = 0
        Private intInventoryID As Integer = 0
        Private intType As Integer = 0
        Private intPurpose As Integer = 0
        Private objCopyIDs As Object
        Private strReason As String = ""
        Private strOnLoan As String = ""
        Private strInputDate As String = ""
        Private intIsFromHolding As Integer = 0
        Private intReasonID As Integer = 0
        Private strInventoryName As String = ""
        Private strInputer As String = ""
        Private strInventoryDate As String = ""
        Private strLocationIDs As String = ""
        Private strOrderField As String = ""
        Private strDirection As String = ""
        Private intOptInventory As Integer = 0
        Private strFromOpenDate As String = ""
        Private strToOpenDate As String = ""

        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        Private objDInventory As New clsDInventory

        '  *****************************************************************************************************
        Public Property OptInventory() As Integer
            Get
                Return intOptInventory
            End Get
            Set(ByVal Value As Integer)
                intOptInventory = Value
            End Set
        End Property
        Public Property FromOpenDate() As String
            Get
                FromOpenDate = strFromOpenDate
            End Get
            Set(ByVal Value As String)
                strFromOpenDate = Value
            End Set
        End Property
        Public Property ToOpenDate() As String
            Get
                ToOpenDate = strToOpenDate
            End Get
            Set(ByVal Value As String)
                strToOpenDate = Value
            End Set
        End Property
        '  InventoryDate property
        Public Property InventoryDate() As String
            Get
                InventoryDate = strInventoryDate
            End Get
            Set(ByVal Value As String)
                strInventoryDate = Value
            End Set
        End Property

        '  InventoryName property 
        Public Property InventoryName() As String
            Get
                InventoryName = strInventoryName
            End Get
            Set(ByVal Value As String)
                strInventoryName = Value
            End Set
        End Property

        '  Inputer property
        Public Property Inputer() As String
            Get
                Inputer = strInputer
            End Get
            Set(ByVal Value As String)
                strInputer = Value
            End Set
        End Property


        '  Shelf property
        Public Property Shelf() As String
            Get
                Return strShelf
            End Get
            Set(ByVal Value As String)
                strShelf = Value
            End Set
        End Property

        '  strCopyIDs property
        Public Property CopyIDs() As String
            Get
                Return strCopyIDs
            End Get
            Set(ByVal Value As String)
                strCopyIDs = Value
            End Set
        End Property

        '  strCopyNumbers property
        Public Property CopyNumbers() As String
            Get
                Return strCopyNumbers
            End Get
            Set(ByVal Value As String)
                strCopyNumbers = Value
            End Set
        End Property

        '  LibID property
        Public Property LibID() As Integer
            Get
                Return intLibID
            End Get
            Set(ByVal Value As Integer)
                intLibID = Value
            End Set
        End Property

        '  LocationID property
        Public Property LocationID() As Integer
            Get
                Return intLocationID
            End Get
            Set(ByVal Value As Integer)
                intLocationID = Value
            End Set
        End Property

        '  InventoryID property
        Public Property InventoryID() As Integer
            Get
                Return intInventoryID
            End Get
            Set(ByVal Value As Integer)
                intInventoryID = Value
            End Set
        End Property

        '  Type property
        Public Property Type() As Integer
            Get
                Return intType
            End Get
            Set(ByVal Value As Integer)
                intType = Value
            End Set
        End Property

        '  Purpose property
        Public Property Purpose() As Integer
            Get
                Return intPurpose
            End Get
            Set(ByVal Value As Integer)
                intPurpose = Value
            End Set
        End Property

        '  ArrCopyIDs property
        Public Property ArrCopyIDs() As Object
            Get
                Return objCopyIDs
            End Get
            Set(ByVal Value As Object)
                objCopyIDs = Value
            End Set
        End Property

        '  Reason property
        Public Property Reason() As String
            Get
                Return strReason
            End Get
            Set(ByVal Value As String)
                strReason = Value
            End Set
        End Property

        '  OnLoan property
        Public Property OnLoan() As String
            Get
                Return strOnLoan
            End Get
            Set(ByVal Value As String)
                strOnLoan = Value
            End Set
        End Property

        '  InputDate property
        Public Property InputDate() As String
            Get
                Return strInputDate
            End Get
            Set(ByVal Value As String)
                strInputDate = Value
            End Set
        End Property


        '  IsFromHolding property
        Public Property IsFromHolding() As Integer
            Get
                Return intIsFromHolding
            End Get
            Set(ByVal Value As Integer)
                intIsFromHolding = Value
            End Set
        End Property

        '  ReasonID property
        Public Property ReasonID() As Integer
            Get
                Return intReasonID
            End Get
            Set(ByVal Value As Integer)
                intReasonID = Value
            End Set
        End Property

        '  LocationIDs property
        Public Property LocationIDs() As String
            Get
                Return strLocationIDs
            End Get
            Set(ByVal Value As String)
                strLocationIDs = Value
            End Set
        End Property

        ' OrderField property
        Public Property OrderField() As String
            Get
                Return (strOrderField)
            End Get
            Set(ByVal Value As String)
                strOrderField = Value
            End Set
        End Property

        ' Direction property
        Public Property Direction() As String
            Get
                Return (strDirection)
            End Get
            Set(ByVal Value As String)
                strDirection = Value
            End Set
        End Property

        ' Init all objects
        Public Sub Initialize()
            ' Init objDInventory object
            objDInventory.DBServer = strdbserver
            objDInventory.ConnectionString = strConnectionString
            Call objDInventory.Initialize()

            ' Init objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            Call objBCDBS.Initialize()

            ' Init objBCSP object
            objBCSP.DBServer = strDBServer
            objBCSP.ConnectionString = strConnectionString
            objBCSP.InterfaceLanguage = strInterfaceLanguage
            Call objBCSP.Initialize()
        End Sub

        'purpose:
        'in:
        'out:
        'Creator:
        Public Sub OpenInventory()

        End Sub

        ' Method: CloseInventory
        Public Sub CloseInventory()
            Try
                objDInventory.InventoryID = intInventoryID
                Call objDInventory.CloseInventory()
                strErrorMsg = objDInventory.ErrorMsg
                intErrorCode = objDInventory.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Method: NewInventory
        ' Purpose: Insert new record int Inventory table 
        ' Input: strInventoryDate, strInventoryName, strInputer
        ' Output: int value (0 if success)
        Public Function NewInventory() As Integer
            Try
                objDInventory.InventoryName = objBCSP.ConvertItBack(strInventoryName)
                objDInventory.InventoryDate = objBCDBS.ConvertDateBack(strInventoryDate)
                objDInventory.Inputer = strInputer
                objDInventory.LibID = intLibID
                NewInventory = objDInventory.NewInventory
                strErrorMsg = objDInventory.ErrorMsg
                intErrorCode = objDInventory.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetInventory method
        ' Purpose: Get inventory
        Public Function GetInventory(Optional ByVal intStatus As Integer = 0) As DataTable
            Try
                objDInventory.InventoryID = intInventoryID
                objDInventory.LibID = intLibID
                GetInventory = objBCDBS.ConvertTable(objDInventory.GetInventory(intStatus))
                strErrorMsg = objDInventory.ErrorMsg
                intErrorCode = objDInventory.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetInventoryInfor method
        ' Purpose: Get lib and loc
        Public Function GetInventoryInfor() As DataTable
            Try
                objDInventory.LibID = intLibID
                objDInventory.LocationID = intLocationID
                GetInventoryInfor = objBCDBS.ConvertTable(objDInventory.GetInventoryInfor)
                strErrorMsg = objDInventory.ErrorMsg
                intErrorCode = objDInventory.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function


        ' GetmaxInventoryTime method
        ' Purpose: Get max inventorytime
        ' Input: Location, liblary, shelf and purpose 
        Public Function GetmaxInventoryTime() As Integer
            Try
                GetmaxInventoryTime = objDInventory.GetmaxInventoryTime
                strErrorMsg = objDInventory.ErrorMsg
                intErrorCode = objDInventory.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' RunInventory method
        ' Purpose: run inventory
        ' Input: Location, liblary, shelf and purpose 
        Public Sub RunInventory(ByVal intInventoryTime As Integer, ByVal intIsFirstTimeInventory As Integer, ByVal intSessionID As Integer)
            Try
                objDInventory.LibID = intLibID
                objDInventory.LocationID = intLocationID
                objDInventory.Purpose = intPurpose
                objDInventory.InventoryID = intInventoryID
                objDInventory.Shelf = Trim(strShelf)
                objDInventory.RunInventory(intInventoryTime, intIsFirstTimeInventory, intSessionID)
                strErrorMsg = objDInventory.ErrorMsg
                intErrorCode = objDInventory.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Init Inventory method
        ' Purpose: Init Inventory
        ' In: intSessionID
        ' Input: strCopyNumbers
        Public Sub InitInventory(ByRef intSessionID As Integer)
            Try
                objDInventory.CopyNumbers = Trim(strCopyNumbers)
                objDInventory.InitInventory(intSessionID)
                strErrorMsg = objDInventory.ErrorMsg
                intErrorCode = objDInventory.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Clear Inventory method
        ' Purpose: Clear Init_Inventory table
        ' Input: intSessionID
        Public Sub ClearInventory(ByRef intSessionID As Integer)
            Try
                objDInventory.ClearInventory(intSessionID)
                strErrorMsg = objDInventory.ErrorMsg
                intErrorCode = objDInventory.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Purpose: Get total copynumber false path
        ' Input:    intInventoryID
        ' Output:   Datatable
        Public Function GetCNsFalsePath() As DataTable
            Try
                objDInventory.InventoryID = intInventoryID
                objDInventory.LibID = intLibID
                objDInventory.LocationID = intLocationID
                GetCNsFalsePath = objDInventory.GetCNsFalsePath()
                strErrorMsg = objDInventory.ErrorMsg
                intErrorCode = objDInventory.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: GetItemNoHaveReal
        ' Puporse: Get all item no have real in lib, loc and shelf
        Public Function GetItemNoHaveReal() As DataTable
            Dim inti As Integer
            Try
                objDInventory.LibID = intLibID
                objDInventory.LocationID = intLocationID
                objDInventory.InventoryID = intInventoryID
                objDInventory.Shelf = strShelf
                objDInventory.OrderField = strOrderField
                objDInventory.Direction = strDirection
                objDInventory.FromOpenDate = strFromOpenDate
                objDInventory.ToOpenDate = strToOpenDate
                objDInventory.OptInventory = intOptInventory

                GetItemNoHaveReal = objBCDBS.ConvertTable(objDInventory.GetItemNoHaveReal(), "Title")
                If Not GetItemNoHaveReal Is Nothing Then
                    If GetItemNoHaveReal.Rows.Count > 0 Then
                        For inti = 0 To GetItemNoHaveReal.Rows.Count - 1
                            GetItemNoHaveReal.Rows(inti).Item("IDRESERVE") = inti + 1
                        Next
                    End If
                End If
                strErrorMsg = objDInventory.ErrorMsg
                intErrorCode = objDInventory.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        '  DeleteInventory method
        '  Purpose: Delete from holding inventory
        '  Input: string of CopyIDs
        '  Output: DataTable
        Public Function DeleteInventory()
            Try
                objDInventory.InventoryID = intInventoryID
                objDInventory.CopyNumbers = Trim(strCopyNumbers)
                objDInventory.DeleteInventory()
                strErrorMsg = objDInventory.ErrorMsg
                intErrorCode = objDInventory.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: GetItemFalsePaths
        ' Puporse: Get item exits holding and exit intventory but false paths
        Public Function GetItemFalsePaths() As DataTable
            Dim inti As Integer
            Try
                objDInventory.LibID = intLibID
                objDInventory.LocationID = intLocationID
                objDInventory.InventoryID = intInventoryID
                objDInventory.Shelf = Trim(strShelf)
                objDInventory.OrderField = Trim(strOrderField)
                objDInventory.Direction = Trim(strDirection)
                objDInventory.FromOpenDate = strFromOpenDate
                objDInventory.ToOpenDate = strToOpenDate
                objDInventory.OptInventory = intOptInventory

                GetItemFalsePaths = objBCDBS.ConvertTable(objDInventory.GetItemFalsePaths(), "Title")
                strErrorMsg = objDInventory.ErrorMsg
                intErrorCode = objDInventory.ErrorCode
                If Not GetItemFalsePaths Is Nothing Then
                    If GetItemFalsePaths.Rows.Count > 0 Then
                        For inti = 0 To GetItemFalsePaths.Rows.Count - 1
                            GetItemFalsePaths.Rows(inti).Item("IDRESERVE") = inti + 1
                        Next
                    End If
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: CheckCopynumberNotExits
        ' Puporse: Check exits copynumber
        ' Ham nay lay ra cac dang ky ca biet ton tai trong CSDL nam trong mot sau vao.
        Public Function CheckCopynumberNotExits(ByVal intSessionID As Integer) As DataTable
            Try
                CheckCopynumberNotExits = objBCDBS.ConvertTable(objDInventory.CheckCopynumberNotExits(intSessionID))
                strErrorMsg = objDInventory.ErrorMsg
                intErrorCode = objDInventory.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' CheckCopynumberWrong method
        ' Purpose: run inventory
        ' Input: Location, liblary, shelf and purpose 
        Public Function CheckCopynumberWrong(ByVal intSessionID As Integer) As DataTable
            Try
                objDInventory.LibID = intLibID
                objDInventory.LocationID = intLocationID
                objDInventory.InventoryID = intInventoryID
                objDInventory.Shelf = Trim(strShelf)
                ' For Oracle running only 
                If strDBServer = "ORACLE" Then
                    objDInventory.CopyNumbers = Trim(strCopyNumbers)
                End If
                CheckCopynumberWrong = objDInventory.CheckCopynumberWrong(intSessionID)
                strErrorMsg = objDInventory.ErrorMsg
                intErrorCode = objDInventory.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' UpdateInventoryRe method
        ' Purpose: Update holding changer Lockreason
        ' Input: strInventoryDate, strInventoryName, strInputer
        Public Function UpdateInventoryRe() As Integer
            Try
                objDInventory.Reason = Trim(strReason)
                objDInventory.CopyNumbers = Trim(strCopyNumbers)
                objDInventory.InventoryID = intInventoryID
                UpdateInventoryRe = objDInventory.UpdateInventoryRe()
                strErrorMsg = objDInventory.ErrorMsg
                intErrorCode = objDInventory.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' RemoveHoldingNoHave method
        ' Purpose: Update holding changer Lockreason
        ' Input: strInventoryDate, strInventoryName, strInputer
        Public Function RemoveHoldingNoHave(Optional ByVal intHoldingInventoryID As Integer = 0) As Integer
            Try
                objDInventory.UserID = intUserID
                objDInventory.CopyNumbers = Trim(strCopyNumbers)
                RemoveHoldingNoHave = objDInventory.RemoveHoldingNoHave()
                strErrorMsg = objDInventory.ErrorMsg
                intErrorCode = objDInventory.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' RemoveHoldingNoHave method
        ' Purpose: delete some infor from Holding_Inventory
        ' Input: strCopyNumbers, intUserID, intInventoryID
        Public Function RemoveHoldingInvNoHave() As Integer
            Try
                objDInventory.UserID = intUserID
                objDInventory.CopyNumbers = Trim(strCopyNumbers)
                objDInventory.InventoryID = intInventoryID
                RemoveHoldingInvNoHave = objDInventory.RemoveHoldingInvNoHave()
                strErrorMsg = objDInventory.ErrorMsg
                intErrorCode = objDInventory.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function


        ' PendingLocation method
        ' Purpose: Pending insert into location
        ' Input: strInventoryDate, strInventoryName, strInputer
        Public Function PendingLocation() As Integer
            Try
                PendingLocation = objDInventory.PendingLocation()
                strErrorMsg = objDInventory.ErrorMsg
                intErrorCode = objDInventory.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose:  Inser all loss item in this inventory to HOLDING_INVENTORY table
        ' Input:    some infor
        ' Creator:  Sondp
        Public Sub Insert_HolInv_LossItem(ByVal intInventoryTime As Integer)
            Try
                objDInventory.InventoryID = intInventoryID
                objDInventory.LibID = intLibID
                objDInventory.LocationID = intLocationID
                objDInventory.Shelf = strShelf
                Call objDInventory.Insert_HolInv_LossItem(intInventoryTime)
                strErrorMsg = objDInventory.ErrorMsg
                intErrorCode = objDInventory.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Methord: Get Inventory Reason
        ' Puporse: Get all reason
        Public Function GetInventoryReason() As DataTable
            Try
                GetInventoryReason = objBCDBS.ConvertTable(objDInventory.GetInventoryReason)
                strErrorMsg = objDInventory.ErrorMsg
                intErrorCode = objDInventory.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Release resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objDInventory Is Nothing Then
                    objDInventory.Dispose(True)
                    objDInventory = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace