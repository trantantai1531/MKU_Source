Imports eMicLibAdmin.DataAccess.Acquisition
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.BusinessRules.Acquisition
    Public Class clsBCopyNumber
        Inherits clsBBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************

        Private objBCSP As New clsBCommonStringProc
        Private objDCopyNumber As New clsDCopyNumber
        Private objBCDBS As New clsBCommonDBSystem
        Private objBItem As New clsBItem
        Private objBCommon As New clsBCommonBusiness
        Private objBTemplate As New clsBCommonTemplate
        Private objBLoc As New clsBLocation

        'Private intLibID As Integer = 0
        Private intLocID As Integer = 0
        Private strShelf As String = ""

        Private strToCopyNum As String = ""
        Private strFromCopyNum As String = ""
        Private intOrderby As Integer = 0
        Private intDesc As Integer = 0

        Private strCopyNumber As String = ""

        Private strStartHolding As String = ""
        Private intRange As Integer = 1
        Private intPOID As Integer = 0
        Private strCode As String = ""
        Private strChangeDate As String = ""
        Private intLoanTypeID As Integer = 0
        Private intAcqSourceID As Integer = 0
        Private dblPrice As Double = 0
        Private strNote As String = ""
        Private strRemoveIDs As String = ""
        Private intReasonID As Integer = 0
        Private lngCopyID As Long = 0
        Private strVolume As String = ""
        Private strAcquiredDate As String = ""
        Private strDateLastUsed As String = ""
        Private strCallNumber As String = ""
        Private strCopyIDs As String = ""
        Private intOutPut As Integer = 0
        Private strCurrencyCode As String = ""
        Private intHoLibID As Integer = 0
        Private strBarCode As String = ""
        Private strNumberCopies As String = ""
        Private strStatusCode As String = ""
        Private strStatusNode As String = ""
        Private strDateCreate As Date = Date.Now
        Private strDateUpdate As Date = Date.Now
        Private strAdditionalBy As String = ""

        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************
        ' CurrencyCode property
        Public Property CurrencyCode() As String
            Get
                Return strCurrencyCode
            End Get
            Set(ByVal Value As String)
                strCurrencyCode = Value
            End Set
        End Property

        ' OutPut property
        Public Property OutPut() As Integer
            Get
                Return intOutPut
            End Get
            Set(ByVal Value As Integer)
                intOutPut = Value
            End Set
        End Property
        ' CopyID property
        Public Property CopyIDs() As String
            Get
                Return (strCopyIDs)
            End Get
            Set(ByVal Value As String)
                strCopyIDs = Value
            End Set
        End Property


        ' LocID property
        Public Property LocID() As Integer
            Get
                Return (intLocID)
            End Get
            Set(ByVal Value As Integer)
                intLocID = Value
            End Set
        End Property

        ' Shelf property
        Public Property Shelf() As String
            Get
                Return (strShelf)
            End Get
            Set(ByVal Value As String)
                strShelf = Value
            End Set
        End Property

        ' CallNumber Property
        Public Property CallNumber() As String
            Get
                Return strCallNumber
            End Get
            Set(ByVal Value As String)
                strCallNumber = Value
            End Set
        End Property

        ' AcquiredDate Property
        Public Property AcquiredDate() As String
            Get
                Return strAcquiredDate
            End Get
            Set(ByVal Value As String)
                strAcquiredDate = Value
            End Set
        End Property

        ' ToCopyNum property
        Public Property ToCopyNum() As String
            Get
                Return (strToCopyNum)
            End Get
            Set(ByVal Value As String)
                strToCopyNum = Value
            End Set
        End Property

        ' FromCopyNum property
        Public Property FromCopyNum() As String
            Get
                Return (strFromCopyNum)
            End Get
            Set(ByVal Value As String)
                strFromCopyNum = Value
            End Set
        End Property

        ' Orderby property
        Public Property Orderby() As Integer
            Get
                Return (intOrderby)
            End Get
            Set(ByVal Value As Integer)
                intOrderby = Value
            End Set
        End Property

        ' OrderByDesc property
        Public Property OrderByDesc() As Integer
            Get
                Return (intDesc)
            End Get
            Set(ByVal Value As Integer)
                intDesc = Value
            End Set
        End Property

        ' StartHoolding property
        Public Property StartHolding() As String
            Get
                Return strStartHolding
            End Get
            Set(ByVal Value As String)
                strStartHolding = Value
            End Set
        End Property

        'Range Property
        Public Property Range() As Integer
            Get
                Return intRange
            End Get
            Set(ByVal Value As Integer)
                intRange = Value
            End Set
        End Property

        'POID Property
        Public Property POID() As Integer
            Get
                Return intPOID
            End Get
            Set(ByVal Value As Integer)
                intPOID = Value
            End Set
        End Property

        ' CopyID Property
        Public Property CopyID() As Long
            Get
                Return lngCopyID
            End Get
            Set(ByVal Value As Long)
                lngCopyID = Value
            End Set
        End Property

        ' Volume Property
        Public Property Volume() As String
            Get
                Return strVolume
            End Get
            Set(ByVal Value As String)
                strVolume = Value
            End Set
        End Property

        'Code Property
        Public Property Code() As String
            Get
                Return strCode
            End Get
            Set(ByVal Value As String)
                strCode = Value
            End Set
        End Property

        'LoanTypeID Property
        Public Property LoanTypeID() As Integer
            Get
                Return intLoanTypeID
            End Get
            Set(ByVal Value As Integer)
                intLoanTypeID = Value
            End Set
        End Property

        ' ChangeDate property
        Public Property ChangeDate() As String
            Get
                Return strChangeDate
            End Get
            Set(ByVal Value As String)
                strChangeDate = Value
            End Set
        End Property

        ' AcqSourceID property
        Public Property AcqSourceID() As Integer
            Get
                Return intAcqSourceID
            End Get
            Set(ByVal Value As Integer)
                intAcqSourceID = Value
            End Set
        End Property

        'dblPrice property
        Public Property Price() As Double
            Get
                Return dblPrice
            End Get
            Set(ByVal Value As Double)
                dblPrice = Value
            End Set
        End Property

        ' Note property
        Public Property Note() As String
            Get
                Return strNote
            End Get
            Set(ByVal Value As String)
                strNote = Value
            End Set
        End Property

        ' RemoveIDs property
        Public Property RemoveIDs() As String
            Get
                Return strRemoveIDs
            End Get
            Set(ByVal Value As String)
                strRemoveIDs = Value
            End Set
        End Property

        'ReasonID property
        Public Property ReasonID() As Integer
            Get
                Return intReasonID
            End Get
            Set(ByVal Value As Integer)
                intReasonID = Value
            End Set
        End Property

        ' CopyNumber Property
        Public Property CopyNumber() As String
            Get
                Return strCopyNumber
            End Get
            Set(ByVal Value As String)
                strCopyNumber = Value
            End Set
        End Property


        ' HolLibID property
        Public Property HolLibID() As Integer
            Get
                Return (intHoLibID)
            End Get
            Set(ByVal Value As Integer)
                intHoLibID = Value
            End Set
        End Property

        'BarCode Property
        Public Property BarCode() As String
            Get
                Return strBarCode
            End Get
            Set(ByVal Value As String)
                strBarCode = Value
            End Set
        End Property

        ' NumberCopies Property
        Public Property NumberCopies() As String
            Get
                Return strNumberCopies
            End Get
            Set(ByVal Value As String)
                strNumberCopies = Value
            End Set
        End Property
        ' StatusCode Property
        Public Property StatusCode() As String
            Get
                Return strStatusCode
            End Get
            Set(ByVal Value As String)
                strStatusCode = Value
            End Set
        End Property

        ' StatusNode Property
        Public Property StatusNode() As String
            Get
                Return strStatusNode
            End Get
            Set(ByVal Value As String)
                strStatusNode = Value
            End Set
        End Property

        ' StatusNode Property
        Public Property DateCreate() As Date
            Get
                Return strDateCreate
            End Get
            Set(ByVal Value As Date)
                strDateCreate = Value
            End Set
        End Property

        ' StatusNode Property
        Public Property DateUpdate() As Date
            Get
                Return strDateUpdate
            End Get
            Set(ByVal Value As Date)
                strDateUpdate = Value
            End Set
        End Property
        ' AdditionalBy Property
        Public Property AdditionalBy() As String
            Get
                Return strAdditionalBy
            End Get
            Set(ByVal Value As String)
                strAdditionalBy = Value
            End Set
        End Property

        ' *************************************************************************************************
        ' End declare properties
        ' Declare public function 
        ' *************************************************************************************************

        ' init all objects
        Public Sub Initialize()
            ' Intialize objDCopyNumber object
            objDCopyNumber.DBServer = strDBServer
            objDCopyNumber.ConnectionString = strConnectionString
            objDCopyNumber.Initialize()
            ' Initialise objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.Initialize()

            objBItem.DBServer = strDBServer
            objBItem.ConnectionString = strConnectionString
            objBItem.InterfaceLanguage = strInterfaceLanguage
            objBItem.Initialize()

            objBCommon.DBServer = strDBServer
            objBCommon.ConnectionString = strConnectionString
            objBCommon.InterfaceLanguage = strInterfaceLanguage
            objBCommon.Initialize()

            objBTemplate.DBServer = strDBServer
            objBTemplate.ConnectionString = strConnectionString
            objBTemplate.InterfaceLanguage = strInterfaceLanguage
            objBTemplate.Initialize()

            objBCSP.DBServer = strDBServer
            objBCSP.ConnectionString = strConnectionString
            objBCSP.InterfaceLanguage = strInterfaceLanguage
            objBCSP.Initialize()

            objBLoc.DBServer = strDBServer
            objBLoc.ConnectionString = strConnectionString
            objBLoc.InterfaceLanguage = strInterfaceLanguage
            objBLoc.Initialize()
        End Sub

        Public Function CountCopyNumbers(ByVal ids() As Integer) As Integer
            If ids IsNot Nothing And UBound(ids) >= 0 Then
                Return objDCopyNumber.CountCopyNumbers(ids)
            Else
                Return 0
            End If

        End Function

        Public Function GetLatestCopyNumberCopy(ByVal id As Integer) As String
            Return objDCopyNumber.GetLatestCopyNumberCopy(id)
        End Function

        Private Function GetNumber(ByRef strVCopyNumber) As String
            If strVCopyNumber = "" Then
                GetNumber = ""
            Else
                Dim strTmp As String
                strTmp = ""
                While (IsNumeric(Right(strVCopyNumber, 1)) And Len(strVCopyNumber)) > 0
                    strTmp = Right(strVCopyNumber, 1) & strTmp
                    strVCopyNumber = Left(strVCopyNumber, Len(strVCopyNumber) - 1)
                End While
                GetNumber = strTmp
            End If
        End Function
        Private Function GetNumberKTTC(ByRef strVCopyNumber) As String
            'vd: 1234/2014,1235/2014
            Dim strResult As String = ""
            If strVCopyNumber <> "" Then
                Dim strTmp As String
                Dim a = Right(strVCopyNumber, 1)
                strTmp = ""
                If (IsNumeric(Left(strVCopyNumber, 1)) And Len(strVCopyNumber)) > 0 Then
                    While (IsNumeric(Left(strVCopyNumber, 1)) And Len(strVCopyNumber)) > 0
                        strTmp = strTmp & Left(strVCopyNumber, 1)
                        strVCopyNumber = Right(strVCopyNumber, Len(strVCopyNumber) - 1)
                    End While
                End If
                strResult = strTmp
            End If
            Return strResult
        End Function

        Private Function GetNumberLeft(ByRef strVCopyNumber) As String
            If strVCopyNumber = "" Then
                GetNumberLeft = ""
            Else
                Dim strTmp As String
                strTmp = ""
                While (IsNumeric(Left(strVCopyNumber, 1)) And Len(strVCopyNumber)) > 0
                    strTmp = Right(strVCopyNumber, 1) & strTmp
                    strVCopyNumber = Left(strVCopyNumber, Len(strVCopyNumber) - 1)
                End While
                GetNumberLeft = strTmp
            End If
        End Function

        Public Function CheckExitByCopyNumber(ByVal strCopyNumbers As String, ByVal startPoisition As Integer, ByVal endPoisition As Integer) As Boolean
            Dim result As Integer
            objDCopyNumber.LibID = intLibID

            result = objDCopyNumber.CheckExitByCopyNumber(strCopyNumbers, startPoisition, endPoisition)
            If result = 0 Then
                Return False
            Else
                Return True
            End If
        End Function

        Public Function IsExistHolding(ByVal strCN As String, ByVal intLocationID As Integer, ByVal intLID As Integer, Optional ByVal intCopyID As Integer = -1) As Boolean
            Dim tblExist As New DataTable
            tblExist = objDCopyNumber.GetSumCopyNumber(strCN, intCopyID, intLID, intLocationID)
            If tblExist.Rows.Count > 0 Then
                IsExistHolding = True
            Else
                IsExistHolding = False
            End If
        End Function

        Public Function IsExistCopyNumber(ByVal strCN As String, ByVal intLocationID As Integer, ByVal intLID As Integer, Optional ByVal intCopyID As Integer = -1) As Boolean
            Dim tblExist As New DataTable
            tblExist = objDCopyNumber.CheckExistCopyNumber(strCN, intCopyID, intLID, intLocationID)
            If tblExist.Rows.Count > 0 Then
                IsExistCopyNumber = True
            Else
                IsExistCopyNumber = False
            End If
        End Function

        Public Function Create(Optional ByVal intInCirculation As Integer = 0, Optional ByVal intAcquired As Integer = 0) As Integer
            Dim bytErrorAddHolding As Byte = 0
            Dim strCallNumber As String
            Dim intNumb As Integer
            'Dim intPasreError As Integer
            Dim strCommonCode As String = ""
            Dim strStartNumb As String = ""
            'Dim dblStartNumb As Double
            'Dim intMinLen As Integer
            Dim StrBarCodeNumb As String
            Dim inti, intk As Integer
            Dim TblItem As New DataTable
            Dim intNumRemaining As Integer
            Dim blnOverBook As Boolean = False
            Dim intPO As Integer
            Dim intItemID As Integer

            ' get ItemID AND CallNumber
            Dim tblItems As New DataTable
            objBItem.ItemID = 0
            objBItem.Code = strCode
            tblItems = objBItem.GetItems
            If tblItems.Rows.Count > 0 Then
                intItemID = CInt(tblItems.Rows(0).Item("ID"))
                If Not IsDBNull(tblItems.Rows(0).Item("CallNumber")) Then
                    strCallNumber = tblItems.Rows(0).Item("CallNumber")
                Else
                    strCallNumber = ""
                End If
            Else
                intItemID = 0
                strCallNumber = ""
            End If
            tblItems.Clear()

            'strCommonCode = Trim(strStartHolding)
            'intNumb = 0
            'strStartNumb = Me.GetNumberKTTC(strCommonCode)
            'intMinLen = Len(strStartNumb)

            'strStartNumb = ""

            'If intMinLen = 0 Then
            '    bytErrorAddHolding = 1 ' DKCB khong co so
            '    Exit Function
            'End If
            objBCommon.DeleteSystemCode("")
            If intPOID <> 0 Then
                intPO = intPOID
            Else
                intPO = 0
            End If
            ' kiem tra DCKB ton tai chua
            If Not Me.IsExistHolding(strStartHolding, intLocID, intLibID) Then
                blnOverBook = False
                'Kiem tra so luong
                If intPO <> 0 Then
                    intNumRemaining = objDCopyNumber.GetNumBookNotAccept(strCode, intPO)
                    If intNumRemaining < intNumb Then
                        blnOverBook = True
                    Else
                    End If
                End If 'strPO <> "NULL"
                If Not blnOverBook Then
                    inti = 0
                    intk = 0
                    'If strStartNumb <> "" Then
                    '    dblStartNumb = CDbl(strStartNumb) - 1
                    '    While intk < intNumb
                    '        dblStartNumb = dblStartNumb + 1
                    '        If Len(CStr(dblStartNumb)) <= intMinLen Then
                    '            StrBarCodeNumb = StrDup(intMinLen - Len(CStr(dblStartNumb)), "0") & CStr(dblStartNumb) & strCommonCode
                    '        Else
                    '            StrBarCodeNumb = dblStartNumb & strCommonCode
                    '        End If

                    '        While Me.IsExistHolding(StrBarCodeNumb, intLocID, intLibID)
                    '            inti = inti + 1
                    '            dblStartNumb = dblStartNumb + 1
                    '            If Len(CStr(dblStartNumb)) <= intMinLen Then
                    '                StrBarCodeNumb = StrDup(intMinLen - Len(CStr(dblStartNumb)), "0") & CStr(dblStartNumb) & strCommonCode
                    '            Else
                    '                StrBarCodeNumb = dblStartNumb & strCommonCode
                    '            End If
                    '        End While
                    '        intk = intk + 1
                    '        inti = inti + 1
                    '        objDCopyNumber.ItemID = intItemID
                    '        objDCopyNumber.LocID = intLocID
                    '        objDCopyNumber.HolLibID = intHoLibID

                    '        objDCopyNumber.LibID = intLibID
                    '        objDCopyNumber.UseCount = 0
                    '        objDCopyNumber.Volume = ""
                    '        objDCopyNumber.AcquiredDate = objBCDBS.ConvertDateBack(strChangeDate)
                    '        objDCopyNumber.CopyNumber = strStartHolding
                    '        objDCopyNumber.InUsed = 0
                    '        objDCopyNumber.InCirculation = intInCirculation ' Chua mo khoa
                    '        objDCopyNumber.ILLID = 0
                    '        objDCopyNumber.Price = dblPrice
                    '        objDCopyNumber.Shelf = objBCSP.ConvertItBack(strShelf)
                    '        objDCopyNumber.POID = intPO
                    '        objDCopyNumber.DateLastUsed = ""
                    '        objDCopyNumber.CallNumber = objBCSP.ConvertItBack(strCallNumber)
                    '        objDCopyNumber.Acquired = intAcquired ' Chua kiem nhan
                    '        objDCopyNumber.Note = strNote
                    '        objDCopyNumber.LoanTypeID = intLoanTypeID
                    '        objDCopyNumber.AcquiredSourceID = intAcqSourceID
                    '        objDCopyNumber.CreateHolding()
                    '    End While
                    '    '============
                    '    ' update holding_copy
                    '    objDCopyNumber.ItemID = intItemID
                    '    objDCopyNumber.LoanTypeID = intLoanTypeID
                    '    objDCopyNumber.UpdateHoldingCopy(intNumb, intNumb)
                    '    '============
                    'Else 'strStartNumb = ""
                    StrBarCodeNumb = strStartNumb & strCommonCode
                    intk = intk + 1
                    inti = inti + 1
                    objDCopyNumber.ItemID = intItemID
                    objDCopyNumber.LocID = intLocID
                    objDCopyNumber.LibID = intLibID
                    objDCopyNumber.HolLibID = intHoLibID
                    objDCopyNumber.UseCount = 0
                    objDCopyNumber.Volume = ""
                    objDCopyNumber.AcquiredDate = objBCDBS.ConvertDateBack(strChangeDate)
                    objDCopyNumber.CopyNumber = strStartHolding
                    objDCopyNumber.BarCode = strBarCode
                    objDCopyNumber.InUsed = 0
                    objDCopyNumber.InCirculation = intInCirculation ' Chua mo khoa
                    objDCopyNumber.ILLID = 0
                    objDCopyNumber.Price = dblPrice
                    objDCopyNumber.Shelf = objBCSP.ConvertItBack(strShelf)
                    objDCopyNumber.POID = intPO
                    objDCopyNumber.DateLastUsed = ""
                    objDCopyNumber.CallNumber = objBCSP.ConvertItBack(strCallNumber)
                    objDCopyNumber.Acquired = intAcquired ' Chua kiem nhan
                    objDCopyNumber.Note = strNote
                    objDCopyNumber.LoanTypeID = intLoanTypeID
                    objDCopyNumber.AcquiredSourceID = intAcqSourceID
                    objDCopyNumber.NumberCopies = strNumberCopies
                    objDCopyNumber.StatusCode = strStatusCode
                    objDCopyNumber.StatusNode = strStatusNode
                    objDCopyNumber.DateCreate = strDateCreate
                    objDCopyNumber.DateUpdate = strDateUpdate
                    objDCopyNumber.AdditionalBy = strAdditionalBy
                    objDCopyNumber.CreateHolding()
                    '============
                    ' update holding_copy
                    objDCopyNumber.ItemID = intItemID
                    objDCopyNumber.LoanTypeID = intLoanTypeID
                    objDCopyNumber.UpdateHoldingCopy(1, 1)
                    '============
                    ' End If
                End If
            Else
                bytErrorAddHolding = 2 ' DKCB dang ton tai
            End If
            Return bytErrorAddHolding
        End Function

        Public Function Create(ByVal strNameCreate As String, ByVal strNameUpdate As String, Optional ByVal intInCirculation As Integer = 0, Optional ByVal intAcquired As Integer = 0) As Integer
            Dim bytErrorAddHolding As Byte = 0
            Dim strCallNumber As String
            Dim intNumb As Integer
            'Dim intPasreError As Integer
            Dim strCommonCode As String = ""
            Dim strStartNumb As String = ""
            'Dim dblStartNumb As Double
            'Dim intMinLen As Integer
            Dim StrBarCodeNumb As String
            Dim inti, intk As Integer
            Dim TblItem As New DataTable
            Dim intNumRemaining As Integer
            Dim blnOverBook As Boolean = False
            Dim intPO As Integer
            Dim intItemID As Integer

            ' get ItemID AND CallNumber
            Dim tblItems As New DataTable
            objBItem.ItemID = 0
            objBItem.Code = strCode
            tblItems = objBItem.GetItems
            If tblItems.Rows.Count > 0 Then
                intItemID = CInt(tblItems.Rows(0).Item("ID"))
                If Not IsDBNull(tblItems.Rows(0).Item("CallNumber")) Then
                    strCallNumber = tblItems.Rows(0).Item("CallNumber")
                Else
                    strCallNumber = ""
                End If
            Else
                intItemID = 0
                strCallNumber = ""
            End If
            tblItems.Clear()

            objBCommon.DeleteSystemCode("")
            If intPOID <> 0 Then
                intPO = intPOID
            Else
                intPO = 0
            End If
            ' kiem tra DCKB ton tai chua
            If Not Me.IsExistHolding(strStartHolding, intLocID, intLibID) Then
                blnOverBook = False
                'Kiem tra so luong
                If intPO <> 0 Then
                    intNumRemaining = objDCopyNumber.GetNumBookNotAccept(strCode, intPO)
                    If intNumRemaining < intNumb Then
                        blnOverBook = True
                    Else
                    End If
                End If 'strPO <> "NULL"
                If Not blnOverBook Then
                    inti = 0
                    intk = 0
                    StrBarCodeNumb = strStartNumb & strCommonCode
                    intk = intk + 1
                    inti = inti + 1
                    objDCopyNumber.ItemID = intItemID
                    objDCopyNumber.LocID = intLocID
                    objDCopyNumber.LibID = intLibID
                    objDCopyNumber.HolLibID = intHoLibID
                    objDCopyNumber.UseCount = 0
                    objDCopyNumber.Volume = ""
                    objDCopyNumber.AcquiredDate = objBCDBS.ConvertDateBack(strChangeDate)
                    objDCopyNumber.CopyNumber = strStartHolding
                    objDCopyNumber.BarCode = strBarCode
                    objDCopyNumber.InUsed = 0
                    objDCopyNumber.InCirculation = intInCirculation ' Chua mo khoa
                    objDCopyNumber.ILLID = 0
                    objDCopyNumber.Price = dblPrice
                    objDCopyNumber.Shelf = objBCSP.ConvertItBack(strShelf)
                    objDCopyNumber.POID = intPO
                    objDCopyNumber.DateLastUsed = ""
                    objDCopyNumber.CallNumber = objBCSP.ConvertItBack(strCallNumber)
                    objDCopyNumber.Acquired = intAcquired ' Chua kiem nhan
                    objDCopyNumber.Note = strNote
                    objDCopyNumber.LoanTypeID = intLoanTypeID
                    objDCopyNumber.AcquiredSourceID = intAcqSourceID
                    objDCopyNumber.NumberCopies = strNumberCopies
                    objDCopyNumber.StatusCode = strStatusCode
                    objDCopyNumber.StatusNode = strStatusNode
                    objDCopyNumber.DateCreate = strDateCreate
                    objDCopyNumber.DateUpdate = strDateUpdate
                    objDCopyNumber.AdditionalBy = strAdditionalBy
                    objDCopyNumber.CreateHolding(strNameCreate, strNameUpdate)
                    '============
                    ' update holding_copy
                    objDCopyNumber.ItemID = intItemID
                    objDCopyNumber.LoanTypeID = intLoanTypeID
                    objDCopyNumber.UpdateHoldingCopy(1, 1)
                    '============
                    ' End If
                End If
            Else
                bytErrorAddHolding = 2 ' DKCB dang ton tai
            End If
            Return bytErrorAddHolding
        End Function

#Region "FPT"
        Public Function Create_FPT(Optional ByVal intInCirculation As Integer = 0, Optional ByVal intAcquired As Integer = 0) As Byte
            Dim bytErrorAddHolding As Byte = 0
            Dim strCallNumber As String
            Dim intNumb As Integer
            Dim intPasreError As Integer
            Dim strCommonCode As String
            Dim strStartNumb As String
            Dim dblStartNumb As Double
            Dim intMinLen As Integer
            Dim StrBarCodeNumb As String
            Dim inti, intk As Integer
            Dim TblItem As New DataTable
            Dim intNumRemaining As Integer
            Dim blnOverBook As Boolean = False
            Dim intPO As Integer
            Dim intItemID As Integer

            ' get ItemID AND CallNumber
            Dim tblItems As New DataTable
            objBItem.ItemID = 0
            objBItem.Code = strCode
            tblItems = objBItem.GetItems
            If tblItems.Rows.Count > 0 Then
                intItemID = CInt(tblItems.Rows(0).Item("ID"))
                If Not IsDBNull(tblItems.Rows(0).Item("CallNumber")) Then
                    strCallNumber = tblItems.Rows(0).Item("CallNumber")
                Else
                    strCallNumber = ""
                End If
            Else
                intItemID = 0
                strCallNumber = ""
            End If
            tblItems.Clear()

            'strCommonCode = Trim(strStartHolding)
            'intNumb = intRange
            'strStartNumb = Me.GetNumberKTTC(strCommonCode)
            'intMinLen = Len(strStartNumb)
            'If intMinLen = 0 Then
            '    bytErrorAddHolding = 1 ' DKCB khong co so
            '    Exit Function
            'End If
            Dim arrDKCB() As String
            If strStartHolding.IndexOf("-") < 1 Then
                If Not Me.IsExistHolding(strStartHolding, intLocID, intLibID) Then
                    objDCopyNumber.ItemID = intItemID
                    objDCopyNumber.LocID = intLocID
                    objDCopyNumber.LibID = intLibID
                    objDCopyNumber.UseCount = 0
                    objDCopyNumber.Volume = ""
                    objDCopyNumber.AcquiredDate = objBCDBS.ConvertDateBack(strChangeDate)
                    objDCopyNumber.CopyNumber = strStartHolding
                    objDCopyNumber.InUsed = 0
                    objDCopyNumber.InCirculation = intInCirculation ' Chua mo khoa
                    objDCopyNumber.ILLID = 0
                    objDCopyNumber.Price = dblPrice
                    objDCopyNumber.Shelf = objBCSP.ConvertItBack(strShelf)
                    objDCopyNumber.POID = intPO
                    objDCopyNumber.DateLastUsed = ""
                    objDCopyNumber.CallNumber = objBCSP.ConvertItBack(strCallNumber)
                    objDCopyNumber.Acquired = intAcquired ' Chua kiem nhan
                    objDCopyNumber.Note = strNote
                    objDCopyNumber.LoanTypeID = intLoanTypeID
                    objDCopyNumber.AcquiredSourceID = intAcqSourceID
                    objDCopyNumber.NumberCopies = strNumberCopies
                    objDCopyNumber.CreateHolding()

                End If
            Else
                arrDKCB = XuLyChuoi(strStartHolding).Split(",")
                For i As Int32 = 0 To UBound(arrDKCB)
                    strCommonCode = arrDKCB(i)
                    If Not Me.IsExistHolding(strCommonCode, intLocID, intLibID) Then
                        objDCopyNumber.ItemID = intItemID
                        objDCopyNumber.LocID = intLocID
                        objDCopyNumber.LibID = intLibID
                        objDCopyNumber.UseCount = 0
                        objDCopyNumber.Volume = ""
                        objDCopyNumber.AcquiredDate = objBCDBS.ConvertDateBack(strChangeDate)
                        objDCopyNumber.CopyNumber = strCommonCode
                        objDCopyNumber.InUsed = 0
                        objDCopyNumber.InCirculation = intInCirculation ' Chua mo khoa
                        objDCopyNumber.ILLID = 0
                        objDCopyNumber.Price = dblPrice
                        objDCopyNumber.Shelf = objBCSP.ConvertItBack(strShelf)
                        objDCopyNumber.POID = intPO
                        objDCopyNumber.DateLastUsed = ""
                        objDCopyNumber.CallNumber = objBCSP.ConvertItBack(strCallNumber)
                        objDCopyNumber.Acquired = intAcquired ' Chua kiem nhan
                        objDCopyNumber.Note = strNote
                        objDCopyNumber.LoanTypeID = intLoanTypeID
                        objDCopyNumber.AcquiredSourceID = intAcqSourceID
                        objDCopyNumber.NumberCopies = strNumberCopies
                        objDCopyNumber.CreateHolding()

                    End If
                Next
            End If

            objDCopyNumber.ItemID = intItemID
            objDCopyNumber.LoanTypeID = intLoanTypeID
            objDCopyNumber.UpdateHoldingCopy(intNumb, intNumb)
            'end chinhnh add
            Return bytErrorAddHolding
        End Function
        Function XuLyChuoi(ByVal str As String) As String
            If str.IndexOf("-") < 1 Then
                Return str
                Exit Function
            End If
            Dim arr() As String
            arr = Split(str, "-")

            Dim strEnd As String = arr(1).Trim
            Dim strStart As String = arr(0).Trim
            Dim strStartSimple As String = strStart.Remove(strStart.Length - strEnd.Length, strEnd.Length)

            Dim IntEnd As Int32 = 0
            Dim IntStart As Int32 = 0
            Try
                IntEnd = CInt(strEnd)
                IntStart = CInt(strStart.Remove(0, strStart.Length - strEnd.Length))
            Catch ex As Exception
                'Exit Function
            End Try
            Dim strReturn As String = strStart
            For i As Int32 = IntStart + 1 To IntEnd
                strReturn += "," + FullText(strStart, strStartSimple, i)
            Next
            Return strReturn
        End Function
        Function FullText(ByVal str As String, ByVal strSimple As String, ByVal i As Int32) As String
            FullText = strSimple + i.ToString
            If (FullText.Length < str.Length) Then
                While ((strSimple + i.ToString).Length < str.Length)
                    strSimple += "0"
                End While
            End If
            Return strSimple + i.ToString
        End Function
#End Region

        Public Sub Update()
            Try
                objDCopyNumber.CopyID = lngCopyID
                objDCopyNumber.LocID = intLocID
                objDCopyNumber.LibID = intLibID
                objDCopyNumber.Volume = objBCSP.ConvertItBack(strVolume)
                objDCopyNumber.AcquiredDate = objBCDBS.ConvertDateBack(strAcquiredDate)
                objDCopyNumber.CopyNumber = strCopyNumber
                objDCopyNumber.Price = dblPrice
                objDCopyNumber.Shelf = objBCSP.ConvertItBack(strShelf)
                objDCopyNumber.CallNumber = objBCSP.ConvertItBack(strCallNumber)
                objDCopyNumber.Note = strNote
                objDCopyNumber.AcquiredSourceID = intAcqSourceID
                objDCopyNumber.BarCode = strBarCode
                objDCopyNumber.NumberCopies = strNumberCopies
                objDCopyNumber.StatusCode = strStatusCode
                objDCopyNumber.StatusNode = strStatusNode
                objDCopyNumber.DateCreate = strDateCreate
                objDCopyNumber.DateUpdate = strDateUpdate
                objDCopyNumber.AdditionalBy = strAdditionalBy
                objDCopyNumber.Update()
                intErrorCode = objDCopyNumber.ErrorCode
                strErrorMsg = objDCopyNumber.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Sub

        Public Sub Remove()
            Dim strDate As String

            Try
                objDCopyNumber.CopyIDs = strCopyIDs
                objDCopyNumber.Remove(intReasonID)
                intErrorCode = objDCopyNumber.ErrorCode
                strErrorMsg = objDCopyNumber.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Sub

        Public Sub DeleteDKCB()
            Try
                objDCopyNumber.CopyIDs = strCopyIDs
                objDCopyNumber.DeleteDKCB()
                intErrorCode = objDCopyNumber.ErrorCode
                strErrorMsg = objDCopyNumber.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Sub

        Public Sub Delete()
            Try
                objDCopyNumber.CopyIDs = strCopyIDs
                objDCopyNumber.Delete()
                intErrorCode = objDCopyNumber.ErrorCode
                strErrorMsg = objDCopyNumber.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Sub

        Public Sub Liquidate(ByRef intOnLoan As Integer, ByRef intTotalItem As Integer, ByRef intOnInventory As Integer, ByVal strRemovedDate As String, ByVal intReasonID As Integer, ByVal strItemCode As String, ByVal strLiquidCode As String)
            Try
                objDCopyNumber.CopyIDs = strCopyIDs
                Call objDCopyNumber.Liquidate(intOnLoan, intTotalItem, intOnInventory, objBCDBS.ConvertDateBack(strRemovedDate), intReasonID, strItemCode, strLiquidCode)
                strErrorMsg = objDCopyNumber.ErrorMsg
                intErrorCode = objDCopyNumber.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Function MoveLocation(ByVal intLibID2 As Integer, ByVal intLocID2 As Integer, ByVal strShelf2 As String) As String
            Try
                objDCopyNumber.LibID = intLibID
                objDCopyNumber.LocID = intLocID
                objDCopyNumber.Shelf = objBCSP.ConvertItBack(strShelf)
                objDCopyNumber.CopyNumber = strCopyNumber
                objDCopyNumber.Code = strCode
                MoveLocation = objDCopyNumber.MoveLocation(intLibID2, intLocID2, strShelf2)
                strErrorMsg = objDCopyNumber.ErrorMsg
                intErrorCode = objDCopyNumber.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Sub RestoreCopyNumber(ByVal bytMode As Byte, ByVal bytUnlock As Byte, ByRef strCopyNumbers As String)
            Try
                objDCopyNumber.CopyIDs = strCopyIDs
                objDCopyNumber.LibID = intLibID
                objDCopyNumber.LocID = intLocID
                objDCopyNumber.Shelf = objBCSP.ConvertItBack(strShelf)
                objDCopyNumber.RestoreCopyNumber(bytMode, bytUnlock, strCopyNumbers)
                intErrorCode = objDCopyNumber.ErrorCode
                strErrorMsg = objDCopyNumber.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Sub

        Public Function GetAcqSource(ByVal strSource As String) As DataTable
            Try
                GetAcqSource = objDCopyNumber.GetAcqSource(strSource)
                intErrorCode = objDCopyNumber.ErrorCode
                strErrorMsg = objDCopyNumber.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        Public Function GetHoldingDevered(Optional strIDs As String = "", Optional strCopyNumber As String = "", Optional strTitle As String = "", Optional strAuthor As String = "", Optional strClassification As String = "", Optional intAcquiredSource As Integer = 0,
                                          Optional strAdditionalBy As String = "", Optional strDateFrom As String = "", Optional strDateTo As String = "") As DataTable
            Try
                objDCopyNumber.LibID = intLibID
                GetHoldingDevered = objDCopyNumber.GetHoldingDevered(strIDs, strCopyNumber, strTitle, strAuthor, strClassification, intAcquiredSource, strAdditionalBy, strDateFrom, strDateTo)
                intErrorCode = objDCopyNumber.ErrorCode
                strErrorMsg = objDCopyNumber.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        Public Function GetHoldingDeveredDetailStatis(Optional strDateFrom As String = "", Optional strDateTo As String = "") As DataTable
            Try
                objDCopyNumber.LibID = intLibID
                GetHoldingDeveredDetailStatis = objDCopyNumber.GetHoldingDeveredDetailStatis(strDateFrom, strDateTo)
                intErrorCode = objDCopyNumber.ErrorCode
                strErrorMsg = objDCopyNumber.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        Public Sub UpdateholdingDelivered(ByVal strIDs As String)
            Try
                objDCopyNumber.LibID = intLibID
                objDCopyNumber.UpdateholdingDelivered(strIDs)
                intErrorCode = objDCopyNumber.ErrorCode
                strErrorMsg = objDCopyNumber.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Sub

        Public Sub UpdateholdingDeliveredSuccess(ByVal strIDs As String, ByVal strUserCreate As String, ByVal strDateDelivered As String, ByVal strSenderDelivered As String, ByVal strReceiverDelivered As String)
            Try
                objDCopyNumber.LibID = intLibID
                objDCopyNumber.UpdateholdingDeliveredSuccess(strIDs, strUserCreate, strDateDelivered, strSenderDelivered, strReceiverDelivered)
                intErrorCode = objDCopyNumber.ErrorCode
                strErrorMsg = objDCopyNumber.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Sub

        Public Function GetHolding(ByVal intItemID As Integer) As DataTable
            Try
                objDCopyNumber.ItemID = intItemID
                GetHolding = objBCDBS.ConvertTable(objDCopyNumber.GetHolding())
                intErrorCode = objDCopyNumber.ErrorCode
                strErrorMsg = objDCopyNumber.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        Public Function GetHoldingByCopyNumber() As DataTable
            objDCopyNumber.CopyNumber = strCopyNumber
            GetHoldingByCopyNumber = objDCopyNumber.GetHoldingByCopyNumber()
        End Function
        Public Function GetLastRecordHoldingOfItem() As DataTable
            Try
                objDCopyNumber.Code = strCode
                GetLastRecordHoldingOfItem = objBCDBS.ConvertTable(objDCopyNumber.GetLastRecordHoldingOfItem())
                intErrorCode = objDCopyNumber.ErrorCode
                strErrorMsg = objDCopyNumber.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        Public Function GetNumberRowOfCopyNumber(strCopyNumber As String) As DataTable
            Try

                GetNumberRowOfCopyNumber = objBCDBS.ConvertTable(objDCopyNumber.GetNumberRowOfCopyNumber(strCopyNumber))
                intErrorCode = objDCopyNumber.ErrorCode
                strErrorMsg = objDCopyNumber.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        Public Function GenListCopyNumber() As DataTable
            Dim tblResult As DataTable
            Dim intRows As Integer

            Try
                objDCopyNumber.LibID = intLibID
                objDCopyNumber.LocID = intLocID
                objDCopyNumber.Shelf = objBCSP.ConvertItBack(strShelf)
                objDCopyNumber.ToCopyNum = strToCopyNum
                objDCopyNumber.FromCopyNum = strFromCopyNum
                objDCopyNumber.Orderby = intOrderby
                objDCopyNumber.OrderByDesc = intDesc
                tblResult = objBCDBS.ConvertTable(objDCopyNumber.GenListCopyNumber, "Content")
                If intOrderby = 0 Then
                    tblResult = objBCDBS.SortTable(tblResult, "Content", 1 - intDesc)
                End If
                If Not tblResult Is Nothing Then
                    For intRows = 0 To tblResult.Rows.Count - 1
                        tblResult.Rows(intRows).Item("OrderNum") = CStr(intRows + 1)
                    Next
                End If
                GenListCopyNumber = tblResult
                strErrorMsg = objDCopyNumber.ErrorMsg
                intErrorCode = objDCopyNumber.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function SearchReceiveSegment(ByVal bytMode As Byte, ByVal strTitle As String, ByVal intNextID As Integer, ByRef intSaveID As Integer, Optional ByVal isUpdate As Boolean = True) As DataTable
            Try
                objDCopyNumber.LibID = intLibID
                objDCopyNumber.LocID = intLocID
                objDCopyNumber.Shelf = objBCSP.ConvertItBack(strShelf)
                objDCopyNumber.CopyNumber = objBCSP.ConvertItBack(strCopyNumber)
                objDCopyNumber.CallNumber = objBCSP.ConvertItBack(strCallNumber)
                objDCopyNumber.Volume = objBCSP.ConvertItBack(strVolume)
                strTitle = objBCSP.ProcessVal(strTitle)
                SearchReceiveSegment = objBCDBS.ConvertTable(objDCopyNumber.SearchReceiveSegment(bytMode, strTitle, intNextID, intSaveID, isUpdate), "Content")
                intErrorCode = objDCopyNumber.ErrorCode
                strErrorMsg = objDCopyNumber.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        Public Function SearchCopyNumber(ByVal bytMode As Byte, ByVal strTitle As String, ByVal strIDs As String, Optional ByVal isHaveLibLoc As Boolean = False, Optional ByVal strItemCode As String = "") As DataTable
            Dim tblResult As DataTable
            Dim inti As Integer
            Try
                strTitle = objBCSP.ProcessVal(strTitle)
                objDCopyNumber.LibID = intLibID
                objDCopyNumber.LocID = intLocID
                objDCopyNumber.CopyNumber = objBCSP.ConvertItBack(strCopyNumber)
                objDCopyNumber.CallNumber = objBCSP.ConvertItBack(strCallNumber)
                objDCopyNumber.Shelf = objBCSP.ConvertItBack(strShelf)
                objDCopyNumber.Volume = objBCSP.ConvertItBack(strVolume)
                tblResult = objBCDBS.ConvertTable(objDCopyNumber.SearchCopyNumber(bytMode, strTitle, strIDs, isHaveLibLoc, strItemCode), "Content")
                If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                    For inti = 0 To tblResult.Rows.Count - 1
                        If Not IsDBNull(tblResult.Rows(inti).Item("Price")) Then
                            tblResult.Rows(inti).Item("Price") = CInt(tblResult.Rows(inti).Item("Price"))
                        End If
                        If Not IsDBNull(tblResult.Rows(inti).Item("UseCount")) AndAlso CInt(tblResult.Rows(inti).Item("UseCount")) = 0 Then
                            tblResult.Rows(inti).Item("DATELASTUSED") = DBNull.Value
                        End If
                    Next
                End If
                SearchCopyNumber = tblResult
                intErrorCode = objDCopyNumber.ErrorCode
                strErrorMsg = objDCopyNumber.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        Public Function SearchCopyNumber2(ByVal bytMode As Byte, ByVal strTitle As String, ByVal strIDs As String, Optional ByVal isHaveLibLoc As Boolean = False, Optional ByVal strItemCode As String = "") As DataTable
            Dim tblResult As DataTable
            Dim inti As Integer
            Try
                strTitle = objBCSP.ProcessVal(strTitle)
                objDCopyNumber.LibID = intLibID
                objDCopyNumber.LocID = intLocID
                objDCopyNumber.CopyNumber = objBCSP.ConvertItBack(strCopyNumber)
                objDCopyNumber.CallNumber = objBCSP.ConvertItBack(strCallNumber)
                objDCopyNumber.Shelf = objBCSP.ConvertItBack(strShelf)
                objDCopyNumber.Volume = objBCSP.ConvertItBack(strVolume)
                tblResult = objDCopyNumber.SearchCopyNumber(bytMode, strTitle, strIDs, isHaveLibLoc, strItemCode)
                'If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                '    For inti = 0 To tblResult.Rows.Count - 1
                '        If Not IsDBNull(tblResult.Rows(inti).Item("Price")) Then
                '            tblResult.Rows(inti).Item("Price") = CInt(tblResult.Rows(inti).Item("Price"))
                '        End If
                '        If Not IsDBNull(tblResult.Rows(inti).Item("UseCount")) AndAlso CInt(tblResult.Rows(inti).Item("UseCount")) = 0 Then
                '            tblResult.Rows(inti).Item("DATELASTUSED") = ""
                '        End If
                '    Next
                'End If
                SearchCopyNumber2 = tblResult
                intErrorCode = objDCopyNumber.ErrorCode
                strErrorMsg = objDCopyNumber.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        Public Function GetTotalSearch(ByVal bytMode As Byte) As DataTable
            Try
                objDCopyNumber.LibID = intLibID
                objDCopyNumber.LocID = intLocID
                objDCopyNumber.Shelf = objBCSP.ConvertItBack(strShelf)
                GetTotalSearch = objDCopyNumber.GetTotalSearch(bytMode)
                intErrorCode = objDCopyNumber.ErrorCode
                strErrorMsg = objDCopyNumber.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        Public Function SearchHoldingID(ByVal bytMode As Byte) As DataTable
            Try
                objDCopyNumber.LibID = intLibID
                objDCopyNumber.LocID = intLocID
                objDCopyNumber.Shelf = objBCSP.ConvertItBack(strShelf)
                SearchHoldingID = objDCopyNumber.SearchHoldingID(bytMode)
                intErrorCode = objDCopyNumber.ErrorCode
                strErrorMsg = objDCopyNumber.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        Public Function SearchSummary(ByVal bytMode As Byte) As DataTable
            Try
                objDCopyNumber.LibID = intLibID
                objDCopyNumber.LocID = intLocID
                SearchSummary = objDCopyNumber.SearchSummary(bytMode)
                intErrorCode = objDCopyNumber.ErrorCode
                strErrorMsg = objDCopyNumber.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        Public Function GetCopyNumberRemoveds(ByVal strTitle As String) As DataTable
            Try
                strTitle = objBCSP.ProcessVal(strTitle)
                objDCopyNumber.LibID = intLibID
                objDCopyNumber.LocID = intLocID
                objDCopyNumber.CopyNumber = objBCSP.ConvertItBack(strCopyNumber)
                objDCopyNumber.CallNumber = objBCSP.ConvertItBack(strCallNumber)
                objDCopyNumber.Shelf = objBCSP.ConvertItBack(strShelf)
                objDCopyNumber.Volume = objBCSP.ConvertItBack(strVolume)
                GetCopyNumberRemoveds = objBCDBS.ConvertTable(objDCopyNumber.SearchCopyNumberRemoved(strTitle), "Content")
                intErrorCode = objDCopyNumber.ErrorCode
                strErrorMsg = objDCopyNumber.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        Public Function GetCopyNumberRemovedIDs(ByVal strTitle As String, Optional ByVal strItemCode As String = "") As DataTable
            Try
                strTitle = objBCSP.ProcessVal(strTitle)
                objDCopyNumber.LibID = intLibID
                objDCopyNumber.LocID = intLocID
                objDCopyNumber.CopyNumber = objBCSP.ConvertItBack(strCopyNumber)
                objDCopyNumber.CallNumber = objBCSP.ConvertItBack(strCallNumber)
                objDCopyNumber.Shelf = objBCSP.ConvertItBack(strShelf)
                objDCopyNumber.Volume = objBCSP.ConvertItBack(strVolume)
                GetCopyNumberRemovedIDs = objDCopyNumber.SearchCopyNumberRemovedIDs(strTitle, strItemCode)
                intErrorCode = objDCopyNumber.ErrorCode
                strErrorMsg = objDCopyNumber.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function
        Public Sub ReceiveUnlock()
            Try
                objDCopyNumber.LibID = intLibID
                objDCopyNumber.LocID = intLocID
                objDCopyNumber.FromCopyNum = objBCSP.ConvertItBack(strFromCopyNum).ToUpper
                objDCopyNumber.ToCopyNum = objBCSP.ConvertItBack(strToCopyNum).ToUpper
                objDCopyNumber.ReceiveUnlock()
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Sub

        Public Function SearchCopyNumberRemovedOnIDs(ByVal strIDs As String) As DataTable
            Dim tblResult As DataTable
            Dim inti As Integer
            Try
                tblResult = objBCDBS.ConvertTable(objDCopyNumber.SearchCopyNumberRemovedOnIDs(strIDs), "Content")
                If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                    For inti = 0 To tblResult.Rows.Count - 1
                        If Not IsDBNull(tblResult.Rows(inti).Item("Price")) Then
                            tblResult.Rows(inti).Item("Price") = CInt(tblResult.Rows(inti).Item("Price"))
                        End If
                        If Not IsDBNull(tblResult.Rows(inti).Item("UseCount")) AndAlso CInt(tblResult.Rows(inti).Item("UseCount")) = 0 Then
                            tblResult.Rows(inti).Item("DATELASTUSED") = ""
                        End If
                    Next
                End If
                SearchCopyNumberRemovedOnIDs = tblResult
                intErrorCode = objDCopyNumber.ErrorCode
                strErrorMsg = objDCopyNumber.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        Public Sub ProcessCopyNumber(ByVal bytMode As Byte, ByVal bytNewLocation As Byte)
            Try
                objDCopyNumber.LibID = intLibID
                objDCopyNumber.LocID = intLocID
                objDCopyNumber.Shelf = objBCSP.ConvertItBack(strShelf)
                objDCopyNumber.CopyIDs = strCopyIDs
                objDCopyNumber.StatusCode = StatusCode
                Call objDCopyNumber.ProcessCopyNumber(bytMode, bytNewLocation)
                intErrorCode = objDCopyNumber.ErrorCode
                strErrorMsg = objDCopyNumber.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Sub

        Public Sub UpdateStatus(ByVal statusCode As String, ByVal loanTypeID As String)
            Try
                objDCopyNumber.LibID = intLibID
                objDCopyNumber.LocID = intLocID
                objDCopyNumber.Shelf = objBCSP.ConvertItBack(strShelf)
                objDCopyNumber.CopyIDs = strCopyIDs
                Call objDCopyNumber.UpdateStatus(statusCode, loanTypeID)
                intErrorCode = objDCopyNumber.ErrorCode
                strErrorMsg = objDCopyNumber.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Sub

        Public Function GetRemoveReason(Optional ByVal intReasonID As Integer = 0) As DataTable
            Try
                GetRemoveReason = objBCDBS.ConvertTable(objDCopyNumber.GetRemoveReason(intReasonID))
                intErrorCode = objDCopyNumber.ErrorCode
                strErrorMsg = objDCopyNumber.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        Public Function GetStatus() As DataTable
            Try
                GetStatus = objDCopyNumber.GetStatus
                intErrorCode = objDCopyNumber.ErrorCode
                strErrorMsg = objDCopyNumber.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function
        Public Function GetStatusByNote(ByVal strStatusNote As String) As DataTable
            Try
                GetStatusByNote = objDCopyNumber.GetStatusByNote(strStatusNote)
                intErrorCode = objDCopyNumber.ErrorCode
                strErrorMsg = objDCopyNumber.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function
        Public Function GetStatusByCode(ByVal strStatusCode As String) As DataTable
            Try
                GetStatusByCode = objDCopyNumber.GetStatusByCode(strStatusCode)
                intErrorCode = objDCopyNumber.ErrorCode
                strErrorMsg = objDCopyNumber.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        Private Function MakeCopyNumberByTemplate(ByVal strLocationName As String, ByVal intSeriNum As Integer) As String
            Dim blnHaveFormat As Boolean
            Dim tblTemp As New DataTable
            Dim strContents As String
            ' Retrieve Systemplate
            objBTemplate.TemplateID = 0
            objBTemplate.TemplateType = 3
            objBTemplate.LibID = intLibID
            tblTemp = objBTemplate.GetTemplate
            If tblTemp.Rows.Count > 0 Then
                blnHaveFormat = True
                strContents = CStr(tblTemp.Rows(0).Item("Content"))
            Else
                blnHaveFormat = False
                strContents = ""
            End If
            If blnHaveFormat Then
                Dim ArrField()
                Dim ArrData()
                Dim intCount As Integer
                Dim strSeri As String
                Dim intCutLen As Integer
                'Dim TvTemp As New TVCOMLib.LibolTemplate

                'Dim intYear As Integer
                'TvTemp.Template = strContents
                'ArrField = TvTemp.Fields

                Dim strContentTemp As String = strContents
                ArrField = objBTemplate.getArrayFromTemplate(strContentTemp)

                ReDim ArrData(UBound(ArrField))
                For intCount = 0 To UBound(ArrField)
                    ArrData(intCount) = ""
                    If InStr(ArrField(intCount), "YR") > 0 Then
                        ArrData(intCount) = CStr(Year(Now))
                        If InStr(ArrField(intCount), ":") > 0 Then
                            ArrData(intCount) = Right(ArrData(intCount), CInt(Right(ArrField(intCount), Len(ArrField(intCount)) - InStr(ArrField(intCount), ":"))))
                            'intYear = CInt(Right(ArrField(intCount), Len(ArrField(intCount)) - InStr(ArrField(intCount), ":")))
                        End If
                    End If

                    If InStr(ArrField(intCount), "INV") > 0 Then
                        ArrData(intCount) = objBCSP.ToUTF8(strLocationName)
                    End If

                    If InStr(ArrField(intCount), "SERINUM") > 0 Then
                        strSeri = CStr(intSeriNum)
                        If InStr(ArrField(intCount), ":") > 0 Then
                            intCutLen = CInt(Right(ArrField(intCount), Len(ArrField(intCount)) - InStr(ArrField(intCount), ":")))
                            If intCutLen > Len(CStr(intSeriNum)) Then
                                'strSeri = CStr(intSeriNum).PadLeft(intCutLen - Len(CStr(intSeriNum)), "0")
                                strSeri = CStr(intSeriNum).PadLeft(intCutLen, "0")
                            End If
                        End If
                        ArrData(intCount) = strSeri
                    End If
                    strContentTemp = Replace(strContentTemp, "<$" & ArrField(intCount) & "$>", ArrData(intCount))
                Next intCount
                'MakeCopyNumberByTemplate = objBCSP.ToUTF8Back(TvTemp.Generate(ArrData))
                MakeCopyNumberByTemplate = strContentTemp
                'TvTemp = Nothing
            Else
                MakeCopyNumberByTemplate = StrDup(6 - Len(CStr(intSeriNum)), "0") & CStr(intSeriNum)
            End If
        End Function

        Public Function GenCopyNumber() As String
            Dim TblTmp As New DataTable
            Dim strCodeLoc As String
            Dim intMaxNumber As Integer
            Dim strReturn As String

            ' DEL SysTempCode
            objBCommon.DeleteSystemCode("")
            ' Retrieve HoldingLocation
            'objBLoc.LibID = intLibID
            objBLoc.LocID = intLocID
            objBLoc.UserID = intUserID
            TblTmp = objBLoc.GetLocation1()
            TblTmp.DefaultView.RowFilter = "ID=" & intLocID
            If TblTmp.DefaultView.Count > 0 Then
                strCodeLoc = TblTmp.DefaultView(0).Item("Symbol")
                intMaxNumber = CInt(TblTmp.DefaultView(0).Item("MaxNumber")) + 1
            Else
                strCodeLoc = ""
                intMaxNumber = 1
            End If

            'Use to update new MaxNumber if it difference with our calculation
            Dim locMaxNumber As Integer = intMaxNumber
            TblTmp.Clear()

            strReturn = Me.MakeCopyNumberByTemplate(strCodeLoc, intMaxNumber)
            'Check Unique
            Dim intCheckLoop As Integer = 0
            While IsExistHolding(strReturn, intLocID, intLibID)
                intMaxNumber = intMaxNumber + 1
                strReturn = Me.MakeCopyNumberByTemplate(strCodeLoc, intMaxNumber)
                intCheckLoop = intCheckLoop + 1
                If intCheckLoop > 50 Then
                    locMaxNumber = 0
                    strReturn = "Invalid Format's CN"
                    Exit While
                End If
            End While

            'Check if our previous locMaxNumber so much different with our calculation intMaxNumber 
            'If so we must update our new calculation value
            If locMaxNumber <> 0 AndAlso locMaxNumber <> intMaxNumber Then
                objDCopyNumber.UpdateLocationMaxNumber(intLocID, intMaxNumber - 1)
            End If
            ' return Value Genarated
            GenCopyNumber = strReturn
        End Function

        ' AddCopyNumber method
        ' Purpose: Add one CopyNumber
        ' Input: some main information of CopyNumber
        Public Sub AddCopyNumber()
            Try
                objDCopyNumber.Code = strCode
                objDCopyNumber.LibID = intLibID
                objDCopyNumber.LocID = intLocID
                objDCopyNumber.Shelf = strShelf
                objDCopyNumber.CallNumber = strCallNumber
                objDCopyNumber.CopyNumber = strCopyNumber
                objDCopyNumber.Price = dblPrice
                objDCopyNumber.CurrencyCode = strCurrencyCode
                objDCopyNumber.LoanTypeID = intLoanTypeID
                objDCopyNumber.UserID = intUserID
                objDCopyNumber.AddCopyNumber()
                intOutPut = objDCopyNumber.OutPut
                strErrorMsg = objDCopyNumber.ErrorMsg
                intErrorCode = objDCopyNumber.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        ' GetCopyNumberInfor method
        ' Purpose: Get all information of the selected copynumber
        ' Input: CopyNumber
        ' Output: datatable result
        Public Function GetCopyNumberInfor() As DataTable
            Try
                objDCopyNumber.CopyNumber = strCopyNumber
                GetCopyNumberInfor = objDCopyNumber.GetCopyNumberInfor
                strErrorMsg = objDCopyNumber.ErrorMsg
                intErrorCode = objDCopyNumber.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: Dispose
        ' Purpose: Release resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objDCopyNumber Is Nothing Then
                    objDCopyNumber.Dispose(True)
                    objDCopyNumber = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBCommon Is Nothing Then
                    objBCommon.Dispose(True)
                    objBCommon = Nothing
                End If
                If Not objBTemplate Is Nothing Then
                    objBTemplate.Dispose(True)
                    objBTemplate = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBLoc Is Nothing Then
                    objBLoc.Dispose(True)
                    objBLoc = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace