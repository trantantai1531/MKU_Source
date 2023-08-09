' Class: clsBPurchaseOrder
' Purpose: Management order informations
' Creator:
' Created Date:
' History update:

Imports eMicLibAdmin.DataAccess.Acquisition
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.BusinessRules.Acquisition.clsBItemOrder

Namespace eMicLibAdmin.BusinessRules.Acquisition
    Public Class clsBPurchaseOrder
        Inherits clsBBase

        ' *****************************************************************************************************
        ' Declare Private variables
        ' *****************************************************************************************************

        Private intAcqPOID As Integer = 0
        Private strReceiptNo As String = ""
        Private strPoName As String = ""
        Private intVendorID As Integer = 0
        Private intPoType As Integer = 0
        Private strValidDate As String = ""
        Private strFilledDate As String = ""
        Private strSetDate As String = ""
        Private intStatusID As Integer = 0
        Private dblTotalAmount As Double = 0
        Private dblPrepaidAmount As Double = 0
        Private dblFixedRate As Double = 0
        Private dblDiscount As Double = 0
        Private strCurrency As String = ""

        Private strValidDateFrom As String = ""
        Private strValidDateTo As String = ""
        Private dblAmountFrom As Double = 0
        Private dblAmountTo As Double = 0
        Private strItemTypeID As String = ""
        Private strMediumID As String = ""
        Private intBudgetID As Integer = 0
        Private strItemIDs As String = ""
        Private strModeSelect As String = ""
        Private strTitle As String = ""
        Private strAuthor As String = ""
        Private strPublisher As String = ""
        Private intDirection As Integer = 0
        Private strPubYear As String = ""
        Private strISBN As String = ""
        Private intInDex As Integer = 0
        Private objarrData() As Integer
        Private objarrLabel() As String

        Private objBCDBS As New clsBCommonDBSystem
        Private objDPO As New clsDPurchaseOrder
        Private objBCSP As New clsBCommonStringProc
        Private objBCT As New clsBCommonTemplate

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' Direction property
        Public Property Direction() As Integer
            Get
                Return intDirection
            End Get
            Set(ByVal Value As Integer)
                intDirection = Value
            End Set
        End Property

        ' ISBN property
        Public Property ISBN() As String
            Get
                Return strISBN
            End Get
            Set(ByVal Value As String)
                strISBN = Value
            End Set
        End Property

        ' PubYear property
        Public Property PubYear() As String
            Get
                Return strPubYear
            End Get
            Set(ByVal Value As String)
                strPubYear = Value
            End Set
        End Property

        ' Publisher property
        Public Property Publisher() As String
            Get
                Return strPublisher
            End Get
            Set(ByVal Value As String)
                strPublisher = Value
            End Set
        End Property

        ' Author property
        Public Property Author() As String
            Get
                Return strAuthor
            End Get
            Set(ByVal Value As String)
                strAuthor = Value
            End Set
        End Property

        ' Title property
        Public Property Title() As String
            Get
                Return strTitle
            End Get
            Set(ByVal Value As String)
                strTitle = Value
            End Set
        End Property

        ' ValidDateFrom property
        Public Property ValidDateFrom() As String
            Get
                Return strValidDateFrom
            End Get
            Set(ByVal Value As String)
                strValidDateFrom = Value
            End Set
        End Property

        ' ValidDateTo property
        Public Property ValidDateTo() As String
            Get
                Return strValidDateTo
            End Get
            Set(ByVal Value As String)
                strValidDateTo = Value
            End Set
        End Property

        ' BudgetID property
        Public Property BudgetID() As Integer
            Get
                Return intBudgetID
            End Get
            Set(ByVal Value As Integer)
                intBudgetID = Value
            End Set
        End Property

        ' AmountFrom property
        Public Property AmountFrom() As Double
            Get
                Return dblAmountFrom
            End Get
            Set(ByVal Value As Double)
                dblAmountFrom = Value
            End Set
        End Property

        ' AmountTo property
        Public Property AmountTo() As Double
            Get
                Return dblAmountTo
            End Get
            Set(ByVal Value As Double)
                dblAmountTo = Value
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

        ' AcqPOID property
        Public Property AcqPOID() As Integer
            Get
                Return intAcqPOID
            End Get
            Set(ByVal Value As Integer)
                intAcqPOID = Value
            End Set
        End Property

        ' ReceiptNo property
        Public Property ReceiptNo() As String
            Get
                Return strReceiptNo
            End Get
            Set(ByVal Value As String)
                strReceiptNo = Value
            End Set
        End Property

        ' PoName property
        Public Property PoName() As String
            Get
                Return strPoName
            End Get
            Set(ByVal Value As String)
                strPoName = Value
            End Set
        End Property

        ' VendorID property
        Public Property VendorID() As Integer
            Get
                Return intVendorID
            End Get
            Set(ByVal Value As Integer)
                intVendorID = Value
            End Set
        End Property

        ' PoType property
        Public Property PoType() As Integer
            Get
                Return intPoType
            End Get
            Set(ByVal Value As Integer)
                intPoType = Value
            End Set
        End Property

        ' ValidDate property
        Public Property ValidDate() As String
            Get
                Return strValidDate
            End Get
            Set(ByVal Value As String)
                strValidDate = Value
            End Set
        End Property

        ' FilledDate property
        Public Property FilledDate() As String
            Get
                Return strFilledDate
            End Get
            Set(ByVal Value As String)
                strFilledDate = Value
            End Set
        End Property

        ' SetDate property
        Public Property SetDate() As String
            Get
                Return strSetDate
            End Get
            Set(ByVal Value As String)
                strSetDate = Value
            End Set
        End Property

        ' StatusID property
        Public Property StatusID() As Integer
            Get
                Return intStatusID
            End Get
            Set(ByVal Value As Integer)
                intStatusID = Value
            End Set
        End Property

        ' TotalAmount property
        Public Property TotalAmount() As Double
            Get
                Return dblTotalAmount
            End Get
            Set(ByVal Value As Double)
                dblTotalAmount = Value
            End Set
        End Property

        ' PrepaidAmount property
        Public Property PrepaidAmount() As Double
            Get
                Return dblPrepaidAmount
            End Get
            Set(ByVal Value As Double)
                dblPrepaidAmount = Value
            End Set
        End Property

        ' FixedRate property
        Public Property FixedRate() As Double
            Get
                Return dblFixedRate
            End Get
            Set(ByVal Value As Double)
                dblFixedRate = Value
            End Set
        End Property

        ' Discount property
        Public Property Discount() As Double
            Get
                Return dblDiscount
            End Get
            Set(ByVal Value As Double)
                dblDiscount = Value
            End Set
        End Property

        ' Currency property
        Public Property Currency() As String
            Get
                Return strCurrency
            End Get
            Set(ByVal Value As String)
                strCurrency = Value
            End Set
        End Property
        Public Property arrData() As Integer()
            Get
                Return objarrData
            End Get
            Set(ByVal Value As Integer())
                objarrData = Value
            End Set
        End Property

        ' arrLabel property
        Public Property arrLabel() As String()
            Get
                Return objarrLabel
            End Get
            Set(ByVal Value As String())
                objarrLabel = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' init all objects
        Public Sub Initialize()
            ' Init objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.Initialize()

            ' Init objDCommonBusiness object
            objDPO.DBServer = strDBServer
            objDPO.ConnectionString = strConnectionString
            objDPO.Initialize()

            ' Init objBCSP object
            objBCSP.DBServer = strDBServer
            objBCSP.ConnectionString = strConnectionString
            objBCSP.InterfaceLanguage = strInterfaceLanguage
            objBCSP.Initialize()

            ' Init objBCT object
            objBCT.DBServer = strDBServer
            objBCT.ConnectionString = strConnectionString
            objBCT.InterfaceLanguage = strInterfaceLanguage
            objBCT.Initialize()
        End Sub

        ' Method: Create
        ' Purpose: create new contract
        ' Input: contract's information
        ' Output: integer value (0 if success)
        ' Creator: Oanhtn
        Public Function Create() As Integer
            Try
                objDPO.ReceiptNo = objBCSP.ConvertItBack(strReceiptNo)
                objDPO.PoName = objBCSP.ConvertItBack(strPoName)
                objDPO.VendorID = intVendorID
                objDPO.PoType = intPoType
                objDPO.ValidDate = objBCDBS.ConvertDateBack(strValidDate)
                objDPO.FilledDate = objBCDBS.ConvertDateBack(strFilledDate)
                objDPO.StatusID = 1 ' default
                objDPO.TotalAmount = dblTotalAmount
                objDPO.PrepaidAmount = dblPrepaidAmount
                objDPO.FixedRate = dblFixedRate
                objDPO.Discount = dblDiscount
                objDPO.Currency = Trim(strCurrency)
                objDPO.LibID = intLibID
                ' Execute
                Create = objDPO.Create
                strErrorMsg = objDPO.ErrorMsg
                intErrorCode = objDPO.ErrorCode
            Catch Ex As Exception
                strErrorMsg = Ex.Message.ToString
            Finally
            End Try
        End Function

        ' Method: Update
        ' Purpose: Update information of the selected contract
        ' Input: contract's information
        ' Output: integer value (0 if success)
        ' Creator: Oanhtn
        Public Function Update(ByVal strStatusNote As String) As Integer
            Try
                objDPO.ACQPOID = intAcqPOID
                objDPO.ReceiptNo = objBCSP.ConvertItBack(strReceiptNo)
                objDPO.PoName = objBCSP.ConvertItBack(strPoName)
                objDPO.VendorID = intVendorID
                objDPO.PoType = intPoType
                objDPO.StatusID = intStatusID
                objDPO.ValidDate = objBCDBS.ConvertDateBack(strValidDate)
                objDPO.FilledDate = objBCDBS.ConvertDateBack(strFilledDate)
                objDPO.TotalAmount = dblTotalAmount
                objDPO.PrepaidAmount = dblPrepaidAmount
                objDPO.FixedRate = dblFixedRate
                objDPO.Discount = dblDiscount
                objDPO.Currency = Trim(strCurrency)
                Update = objDPO.Update(objBCDBS.ConvertDateBack(strStatusNote))
                strErrorMsg = objDPO.ErrorMsg
                intErrorCode = objDPO.ErrorCode
            Catch Exp As Exception
                strErrorMsg = Exp.Message.ToString
            Finally
            End Try
        End Function

        Public Function Delete() As Integer
            Try
                objDPO.ACQPOID = intAcqPOID
                Delete = objDPO.Delete
                strErrorMsg = objDPO.ErrorMsg
                intErrorCode = objDPO.ErrorCode
            Catch Exp As Exception
                strErrorMsg = Exp.Message.ToString
            End Try
        End Function

        Public Function GetPO(Optional ByVal strReceiptPO As String = "") As DataTable
            Try
                objDPO.ACQPOID = intAcqPOID
                objDPO.LibID = intLibID
                GetPO = objBCDBS.ConvertTable(objDPO.GetPO(strReceiptPO))
                strErrorMsg = objDPO.ErrorMsg
                intErrorCode = objDPO.ErrorCode
            Catch Exp As Exception
                strErrorMsg = Exp.Message.ToString
            End Try
        End Function
        Public Function GetPO(ByVal strReceiptPO As String, Optional intStatus As Integer = 0) As DataTable
            Try
                objDPO.ACQPOID = intAcqPOID
                objDPO.LibID = intLibID
                GetPO = objBCDBS.ConvertTable(objDPO.GetPO(strReceiptPO, intStatus))
                strErrorMsg = objDPO.ErrorMsg
                intErrorCode = objDPO.ErrorCode
            Catch Exp As Exception
                strErrorMsg = Exp.Message.ToString
            End Try
        End Function

        Public Function GetItemCodeByPO(ByVal strPOCode As String) As DataTable
            Try
                strPOCode = objBCSP.ConvertItBack(strPOCode)
                GetItemCodeByPO = objBCDBS.ConvertTable(objDPO.GetItemCodeByPO(strPOCode))
                strErrorMsg = objDPO.ErrorMsg
                intErrorCode = objDPO.ErrorCode
            Catch Exp As Exception
                strErrorMsg = Exp.Message.ToString
            End Try
        End Function

        Public Function GetPOID(ByVal intACQITEMID As Integer) As Integer
            Dim tblTmp As New DataTable
            Try
                tblTmp = objDPO.GetPOID(intACQITEMID)
                If Not tblTmp Is Nothing AndAlso tblTmp.Rows.Count > 0 Then
                    GetPOID = tblTmp.Rows(0).Item(0)
                Else
                    GetPOID = 0
                End If
                strErrorMsg = objDPO.ErrorMsg
                intErrorCode = objDPO.ErrorCode
            Catch Exp As Exception
                strErrorMsg = Exp.Message.ToString
            End Try
        End Function

        Public Function GetAcqItemInfor(ByVal intACQITEMID As Integer) As DataTable
            Try
                GetAcqItemInfor = objBCDBS.ConvertTable(objDPO.GetAcqItemInfor(intACQITEMID))
                strErrorMsg = objDPO.ErrorMsg
                intErrorCode = objDPO.ErrorCode
            Catch Exp As Exception
                strErrorMsg = Exp.Message.ToString
            End Try
        End Function

        ' Method: GetListPOs
        ' Purpose: Get list of ordered items
        ' Output: Datatable result
        Public Function GetListPOs() As DataTable
            Try
                objDPO.LibID = intLibID
                GetListPOs = objBCDBS.ConvertTable(objDPO.GetListPOs())
                intErrorCode = objDPO.ErrorCode
                strErrorMsg = objDPO.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose: Get CheckingReceived Item
        ' Input: intPOID
        ' Output: Datatable 
        ' Creator: Sondp
        Public Function GetCheckingReceived() As DataTable
            Try
                objDPO.ACQPOID = intAcqPOID
                GetCheckingReceived = objBCDBS.ConvertTable(objDPO.GetCheckingReceived)
                intErrorCode = objDPO.ErrorCode
                strErrorMsg = objDPO.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose: Update ReceivedCopies
        ' Input: strIDs, strReceivedCopies, strNoties
        ' Creator: Sondp
        Public Sub UpdateCheckingReceived(ByVal strIDs As String, ByVal strReceivedCopies As String, ByVal strNoties As String)
            Dim arrID(), arrReceivedCopy(), arrNote() As String
            Dim inti As Integer
            Dim strUpdateSQL As String
            strUpdateSQL = ""

            Try
                arrID = Split(strIDs, ",")
                arrReceivedCopy = Split(strReceivedCopies, ",")
                arrNote = Split(strNoties, ",")

                For inti = LBound(arrID) To UBound(arrID)
                    Select Case strDBServer
                        Case "ORACLE"
                            strUpdateSQL = " UPDATE Acq_tblItem SET ReceivedCopies =" & arrReceivedCopy(inti) & ", Note='" & objBCSP.ConvertItBack(arrNote(inti)) & "' WHERE ID=" & arrID(inti)
                        Case Else
                            strUpdateSQL = " UPDATE Acq_tblItem SET ReceivedCopies =" & arrReceivedCopy(inti) & ", Note=N'" & objBCSP.ConvertItBack(arrNote(inti)) & "' WHERE ID=" & arrID(inti)
                    End Select
                    objBCDBS.SQLStatement = strUpdateSQL
                    objBCDBS.ProcessItem()
                Next
                strErrorMsg = objBCDBS.ErrorMsg
                intErrorCode = objBCDBS.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Purpose:
        ' Input:
        ' Output:
        ' Creator:
        Public Sub SendOrder()

        End Sub

        ' Class: GetStatusLog
        ' Purpose: Get status log of the selected contract
        ' Input: contractID
        ' Output: datatable result
        ' Creator: Oanhtn
        Public Function GetStatusLog() As DataTable
            Try
                objDPO.ACQPOID = intAcqPOID
                GetStatusLog = objBCDBS.ConvertTable(objDPO.GetStatusLog)
                strErrorMsg = objDPO.ErrorMsg
                intErrorCode = objDPO.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
        End Function

        ' Purpose:
        ' Input:
        ' Output:
        ' Creator:
        Public Function GetSumariesOfItemOrdered() As DataTable

        End Function

        ' Purpose: Get ContractID
        ' Input: intPOS
        ' Output: integer value
        ' Creator: Oanhtn
        ' CreatedDate: 04/03/2005
        Public Function GetContractID(ByVal intPOS As Integer) As Integer
            Try
                objDPO.LibID = intLibID
                GetContractID = objDPO.GetContractID(intPOS)

                intErrorCode = objDPO.ErrorCode
                strErrorMsg = objDPO.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetAcqPoStatus() As DataTable
            Try
                objDPO.ACQPOID = intAcqPOID
                objDPO.StatusID = intStatusID
                GetAcqPoStatus = objDPO.GetAcqPoStatus()

                intErrorCode = objDPO.ErrorCode
                strErrorMsg = objDPO.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose: Get finacial information of the selected contract
        ' Input: contractID
        ' Output: datatable result
        ' Creator: Oanhtn
        ' CreatedDate: 02/04/2005
        Public Function GetFinacialInfor(Optional ByVal strMsg1 As String = "", Optional ByVal strMsg2 As String = "", Optional ByVal strMsg3 As String = "") As DataTable
            Dim inti As Integer
            Dim tblFinacialInfor As New DataTable
            Try
                objDPO.ACQPOID = intAcqPOID
                tblFinacialInfor = objBCDBS.ConvertTable(objDPO.GetFinacialInfor)
                If Not strMsg1 = "" And Not strMsg2 = "" And Not strMsg3 = "" Then
                    If Not tblFinacialInfor Is Nothing AndAlso tblFinacialInfor.Rows.Count > 0 Then
                        For inti = 0 To tblFinacialInfor.Rows.Count - 1
                            Select Case CStr(tblFinacialInfor.Rows(inti).Item("Commited") & "")
                                Case "1"
                                    tblFinacialInfor.Rows(inti).Item("Commited") = strMsg1
                                Case "0"
                                    tblFinacialInfor.Rows(inti).Item("Commited") = strMsg2
                                Case Else
                                    tblFinacialInfor.Rows(inti).Item("Commited") = strMsg3
                            End Select
                        Next
                    End If
                End If
                GetFinacialInfor = tblFinacialInfor
                intErrorCode = objDPO.ErrorCode
                strErrorMsg = objDPO.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function


        ' Forming select statement
        Public Function FormingSQL() As String
            Dim strFromClause As String = ""
            Dim strWhereClause As String = " 1=1"
            Dim strSelectStatement As String

            ' Forming FromClause
            If (Not strPoName = "") Or (Not strReceiptNo = "") Or (Not intVendorID = 0) Or (Not strCurrency = "") Or (Not strValidDateTo = "") Or (Not strValidDateTo = "") Or (Not dblAmountFrom = 0) Or (Not dblAmountTo = 0) Or (Not intBudgetID = 0) Then
                strFromClause = "Acq_tblPo A"
            End If
            If (Not strTitle = "") Or (Not strAuthor = "") Or (Not strPublisher = "") Or (Not strPubYear = "") Or (Not strISBN = "") Then
                If strFromClause = "" Then
                    strFromClause = " Acq_tblPo A, Acq_tblItem B"
                Else
                    strFromClause = strFromClause & ", Acq_tblItem B, Acq_tblPo_Item C"
                End If
            End If
            If Not intBudgetID = 0 Then
                strFromClause = strFromClause & ", ACQ_BUDGET E, ACQ_BUDGET_DEBIT F"
            End If

            ' Forming WhereClause
            ' PoName
            If Not strPoName = "" Then
                strWhereClause = strWhereClause & " AND PoName LIKE N'" & strPoName & "'"
            End If
            ' ReceiptNo
            If Not strReceiptNo = "" Then
                strWhereClause = strWhereClause & " AND ReceiptNo LIKE N'" & strReceiptNo & "'"
            End If
            ' Title
            If Not strTitle = "" Then
                strWhereClause = strWhereClause & " AND A.ID=B.POID"
                strWhereClause = strWhereClause & " AND B.Title LIKE N'" & strTitle & "'"
            End If
            ' Author
            If Not strAuthor = "" Then
                strWhereClause = strWhereClause & " AND A.ID=B.POID"
                strWhereClause = strWhereClause & " AND B.Author LIKE N'" & strAuthor & "'"
            End If
            ' Publisher
            If Not strPublisher = "" Then
                strWhereClause = strWhereClause & " AND A.ID=B.POID"
                strWhereClause = strWhereClause & " AND B.Publisher LIKE N'" & strPublisher & "'"
            End If
            ' PubYear
            If Not strPubYear = "" Then
                strWhereClause = strWhereClause & " AND A.ID=B.POID"
                strWhereClause = strWhereClause & " AND B.PubYear LIKE N'" & strPubYear & "'"
            End If
            ' ISBN
            If Not strISBN = "" Then
                strWhereClause = strWhereClause & " AND A.ID=B.POID"
                strWhereClause = strWhereClause & " AND B.ISBN LIKE N'" & strISBN & "'"
            End If
            ' Currency
            If Not strCurrency = "" Then
                strWhereClause = strWhereClause & " AND A.Currency ='" & strCurrency & "'"
            End If
            ' Amount
            If Not dblAmountFrom = 0 Then
                strWhereClause = strWhereClause & " AND TotalAmount >= " & dblAmountFrom
            End If
            If Not dblAmountTo = 0 Then
                strWhereClause = strWhereClause & " AND TotalAmount <= " & dblAmountTo
            End If
            ' VendorID
            If Not intVendorID = 0 Then
                strWhereClause = strWhereClause & " AND VendorID =" & intVendorID
            End If
            ' BudgetID
            If Not intBudgetID = 0 Then
                strWhereClause = strWhereClause & " AND F.POID = A.ID AND E.ID = F.BudgetID "
                strWhereClause = strWhereClause & " AND F.BudgetID =" & intBudgetID
            End If
            ' ValidDate
            If Not strValidDateFrom = "" Then
                If strDBServer = "ORACLE" Then
                    strWhereClause = strWhereClause & " AND ValidDate >= ConvertDate('" & strValidDateFrom & "')"
                Else
                    strWhereClause = strWhereClause & " AND ValidDate >= '" & strValidDateFrom & "'"
                End If

            End If
            If Not strValidDateTo = "" Then
                If strDBServer = "ORACLE" Then
                    strWhereClause = strWhereClause & " AND ValidDate <=ConvertDate('" & strValidDateTo & "')"
                Else
                    strWhereClause = strWhereClause & " AND ValidDate <='" & strValidDateTo & "'"
                End If

            End If

            ' Forming SelectStatement
            If strFromClause = "" Then
                strFromClause = "Acq_tblPo"
            End If
            strSelectStatement = "SELECT DISTINCT A.ID FROM " & strFromClause & " WHERE " & strWhereClause & " and ( LibID = " & intLibID & " or  " & intLibID & " = " & " 0 ) "
            FormingSQL = strSelectStatement
        End Function

        ' Method: BrowseContract
        ' Purpose: browse contract list
        ' Input: some main infor
        ' Output: DataTable result
        ' Creator: Tuanhv
        Public Function BrowseContract(ByVal intParameter1 As Integer, ByVal intParameter2 As Integer, ByVal intOption As Integer, ByVal intLibID As Integer) As DataTable
            Try
                objBCDBS.LibID = intLibID
                BrowseContract = objBCDBS.ConvertTable(objDPO.BrowseContract(intParameter1, intParameter2, intOption, intLibID))
                strErrorMsg = objDPO.ErrorMsg
                intErrorCode = objDPO.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
        End Function

        ' Method: FilterContract
        ' Purpose: filter contract depending on some conditions
        ' Input: filter conditions
        ' Output: Datatable result
        Public Function FilterContract() As DataTable
            Try
                strPoName = Trim(objBCSP.ConvertItBack(strPoName))
                strReceiptNo = Trim(objBCSP.ConvertItBack(strReceiptNo))
                strValidDateFrom = Trim(objBCDBS.ConvertDateBack(strValidDateFrom))
                strValidDateTo = Trim(objBCDBS.ConvertDateBack(strValidDateTo))
                strTitle = Trim(objBCSP.ConvertItBack(strTitle))
                strAuthor = Trim(objBCSP.ConvertItBack(strAuthor))
                strPublisher = Trim(objBCSP.ConvertItBack(strPublisher))
                strPubYear = Trim(objBCSP.ConvertItBack(strPubYear))
                LibID = intLibID
                objDPO.SQLStatement = FormingSQL()
                ' Search
                FilterContract = objDPO.SearchContract
                strErrorMsg = objDPO.ErrorMsg
                intErrorCode = objDPO.ErrorCode
            Catch Ex As Exception
                strErrorMsg = Ex.Message
            End Try
        End Function

        ' Method: SearchContract
        ' Purpose: filter contract
        ' Output: array data
        Public Function SearchContract() As Object
            Dim tblResult As DataTable
            Dim intIndex As Integer
            Dim intCount As Integer
            Dim arrIDs()

            Try
                tblResult = FilterContract()
                If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                    intCount = tblResult.Rows.Count - 1
                    If intCount >= 0 Then
                        ReDim arrIDs(intCount)
                        For intIndex = 0 To intCount
                            arrIDs(intIndex) = tblResult.Rows(intIndex).Item("ID")
                        Next
                    End If
                End If
                strErrorMsg = objDPO.ErrorMsg
                intErrorCode = objDPO.ErrorCode
            Catch Ex As Exception
                strErrorMsg = Ex.Message
            End Try
            SearchContract = arrIDs
        End Function

        ' Methrod: GetAcqPoInfor
        ' Input: integer value of PoID
        ' Output: DataTable
        Public Function GetAcqPoInfor() As DataTable
            Try
                objDPO.ACQPOID = intAcqPOID
                objDPO.Direction = intDirection
                GetAcqPoInfor = objBCDBS.ConvertTable(objDPO.GetAcqPoInfor)
                strErrorMsg = objDPO.ErrorMsg
                intErrorCode = objDPO.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
        End Function



        ' Purpose: Get Items to display on table collums title
        ' In: intPOID, strHaveFields
        ' Out: Datatable
        ' Creator: Sondp
        ' CreatedDate" 06/04/2005
        Public Function GetPOClaimHeader(ByVal intPOID As Integer, ByVal strHaveFields As String) As DataTable
            Try
                GetPOClaimHeader = objBCDBS.ConvertTable(objDPO.GetPOClaimHeader(intPOID, strHaveFields))
                strErrorMsg = objDPO.ErrorMsg
                intErrorCode = objDPO.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose: Get Items to display on table
        ' In: intPOID
        ' Out: Datatable
        ' Creator: Sondp
        ' CreatedDate" 06/04/2005
        Public Function GetPOClaimItems(ByVal intPOID As Integer) As DataTable
            Try
                GetPOClaimItems = objBCDBS.ConvertTable(objDPO.GetPOClaimItems(intPOID))
                strErrorMsg = objDPO.ErrorMsg
                intErrorCode = objDPO.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose: Generate PO Claim
        ' In: intPOID, intTemplateID, intUbound, collectCollumHeader
        ' Out: metric
        ' Creator: Sondp
        Public Function GenPOClaim(ByVal intPOID As Integer, ByVal intTemplateID As Integer, ByVal intUbound As Integer, ByVal collectCollumHeader As Collection) As Metric
            Dim tblTemplate As New DataTable
            Dim tblContact As New DataTable
            Dim tblData As New DataTable
            Dim dtrows() As DataRow
            'Dim objTemplate As New TVCOMLib.LibolTemplate
            Dim objMetric As New Metric
            Dim objFields As New Object
            Dim objData As New Object
            Dim arrContent() As String
            Dim Cols() As String
            Dim ColLabel() As String
            Dim ColLabel2() As String
            Dim UserColLabel() As String
            Dim UserColWidth() As String
            Dim UserColAlign() As String
            Dim UserColFormat() As String
            Dim strHeader, strPageHeader, strCollum, strCollumCaption, strCollumWidth, strCollumAlign, strCollumFormat, strPageFooter, strFooter, strTableColor, strOddColor, strEventColor, strChangeRowColor, strOutMsg, strmw, strma, strmf As String
            Dim inti, intj, intk As Integer
            Dim boolFlage As Boolean
            objMetric = Nothing
            boolFlage = False
            Try
                objBCT.TemplateID = intTemplateID
                objBCT.TemplateType = 8
                tblTemplate = objBCT.GetTemplate
                If Not tblTemplate Is Nothing AndAlso tblTemplate.Rows.Count > 0 Then
                    ReDim objMetric.objData(0)
                    ReDim objMetric.objEmail(0)
                    arrContent = Split(tblTemplate.Rows(0).Item("Content"), Chr(9))
                    strHeader = arrContent(0).Replace("<~>", vbCrLf)
                    strPageHeader = arrContent(1).Replace("<~>", vbCrLf)
                    strCollum = arrContent(2)
                    strCollumCaption = arrContent(3)
                    strCollumWidth = arrContent(4)
                    strCollumAlign = arrContent(5)
                    strCollumFormat = arrContent(6)
                    If arrContent(7) & "" = "" Then
                        strTableColor = "#F0F3F4"
                    Else
                        strTableColor = arrContent(7)
                    End If
                    If arrContent(8) & "" = "" Then
                        strOddColor = "#C0C0C0"
                    Else
                        strOddColor = arrContent(8)
                    End If
                    If arrContent(9) & "" = "" Then
                        strEventColor = "#FFFFFF"
                    Else
                        strEventColor = arrContent(9)
                    End If
                    strPageFooter = arrContent(10).Replace("<~>", vbCrLf)
                    strFooter = arrContent(11).Replace("<~>", vbCrLf)
                    'objTemplate.Template = objBCSP.ToUTF8(strHeader) & "@@@@@" & objBCSP.ToUTF8(strFooter)
                    'objFields = objTemplate.Fields
                    Dim strContentTemp As String = objBCSP.ToUTF8(strHeader) & "@@@@@" & objBCSP.ToUTF8(strFooter)
                    objFields = objBCT.getArrayFromTemplate(strContentTemp)
                    ' Get Contact information
                    tblContact = GetPOClaimHeader(intPOID, strCollum)
                    ' Get vendor email
                    objMetric.objEmail(0) = tblContact.Rows(0).Item("Email")
                    Cols = Split(strCollum, "<~>")
                    UserColWidth = Split(strCollumWidth, "<~>")
                    UserColAlign = Split(strCollumAlign, "<~>")
                    UserColFormat = Split(strCollumFormat, "<~>")
                    UserColLabel = Split(strCollumCaption, "<~>")
                    intk = 0
                    For inti = 0 To UBound(Cols)
                        Try
                            ReDim Preserve ColLabel(intk)
                            ReDim Preserve ColLabel2(intk)
                            Select Case UCase(Cols(inti))
                                Case "<$ERRONEUOS$>"
                                    boolFlage = True
                                    If UBound(UserColLabel) >= inti Then
                                        If Not Trim(UserColLabel(inti)) = "" Then
                                            If InStr(UserColLabel(inti), "|") = 0 Then
                                                ColLabel(intk) = UserColLabel(inti)
                                                ColLabel2(intk) = UserColLabel(inti)
                                            Else
                                                ColLabel(intk) = Left(UserColLabel(inti), InStr(UserColLabel(inti), "|") - 1)
                                                ColLabel2(intk) = Right(UserColLabel(inti), Len(UserColLabel(inti)) - InStr(UserColLabel(inti), "|"))
                                            End If
                                        Else
                                            ColLabel(intk) = collectCollumHeader.Item("<$LESS$>")
                                            ColLabel2(intk) = collectCollumHeader.Item("<$MUCH$>")
                                        End If
                                    Else
                                        ColLabel(intk) = collectCollumHeader.Item("<$LESS$>")
                                        ColLabel2(intk) = collectCollumHeader.Item("<$MUCH$>")
                                    End If
                                Case Else
                                    If UBound(UserColLabel) >= inti Then
                                        If Not Trim(UserColLabel(inti)) = "" Then
                                            ColLabel(intk) = UserColLabel(inti)
                                            ColLabel2(intk) = UserColLabel(inti)
                                        Else
                                            ColLabel(intk) = collectCollumHeader.Item("" & UCase(Cols(inti)) & "")
                                            ColLabel2(intk) = collectCollumHeader.Item("" & UCase(Cols(inti)) & "")
                                        End If
                                    Else
                                        ColLabel(intk) = collectCollumHeader.Item("" & UCase(Cols(inti)) & "")
                                        ColLabel2(intk) = collectCollumHeader.Item("" & UCase(Cols(inti)) & "")
                                    End If
                            End Select
                        Catch ex As Exception
                            ColLabel(intk) = ""
                            ColLabel2(intk) = ""
                            strErrorMsg = ex.Message
                        Finally
                            intk = intk + 1
                        End Try
                    Next
                    ' Collum header title
                    'ReDim objData(UBound(objTemplate.Fields))
                    If Not IsNothing(objFields) AndAlso IsArray(objFields) Then
                        ReDim objData(UBound(objFields))
                        For inti = LBound(objFields) To UBound(objFields)
                            Try
                                Select Case UCase(objFields(inti))
                                    Case "TITLE"
                                        objData(inti) = objBCSP.ToUTF8(collectCollumHeader.Item("TITLE")) & Chr(9)
                                    Case "TITLE:UPPER"
                                        objData(inti) = objBCSP.ToUTF8(collectCollumHeader.Item("TITLE:UPPER")) & Chr(9)
                                    Case "TODAY"
                                        objData(inti) = collectCollumHeader.Item("TODAY") & Chr(9)
                                    Case "TODAY:DD"
                                        objData(inti) = collectCollumHeader.Item("TODAY:DD") & Chr(9)
                                    Case "TODAY:MM"
                                        objData(inti) = collectCollumHeader.Item("TODAY:MM") & Chr(9)
                                    Case "TODAY:YYYY"
                                        objData(inti) = collectCollumHeader.Item("TODAY:YYYY") & Chr(9)
                                    Case "TODAY:HH"
                                        objData(inti) = collectCollumHeader.Item("TODAY:HH") & Chr(9)
                                    Case "TODAY:MI"
                                        objData(inti) = collectCollumHeader.Item("TODAY:MI") & Chr(9)
                                    Case "TODAY:SS"
                                        objData(inti) = collectCollumHeader.Item("TODAY:SS") & Chr(9)
                                    Case Else
                                        objData(inti) = objBCSP.ToUTF8(tblContact.Rows(0).Item("" & "" & objFields(inti) & "" & "")) & Chr(9)
                                End Select
                                strContentTemp = Replace(strContentTemp, "<$" & objFields(inti) & "$>", objData(inti))
                            Catch ex As Exception
                                objData(inti) = "" & Chr(9)
                                strErrorMsg = ex.Message
                            End Try
                        Next
                    End If
                    
                    'strOutMsg = objTemplate.Generate(objData)
                    strOutMsg = strContentTemp
                    strOutMsg = Replace(strOutMsg, "  ", "&nbsp;&nbsp;")
                    strHeader = Left(strOutMsg, InStr(strOutMsg, "@@@@@") - 1)
                    strFooter = Right(strOutMsg, Len(strOutMsg) - InStr(strOutMsg, "@@@@@") - 4)
                    strOutMsg = strPageHeader & objBCSP.ToUTF8Back(strHeader.Replace("<~>", vbCrLf))
                    ' Get Data
                    tblData = GetPOClaimItems(intPOID)
                    If Not tblData Is Nothing Then
                        If tblData.Rows.Count > 0 Then
                            strOutMsg = strOutMsg & "<TABLE WIDTH=100% CELLPADDING=3 CELLSPACING=0 BORDER=1 BORDERCOLOR=""000000"">"
                            ' Much erroueuos
                            dtrows = tblData.Select("Erroneuos > 0")
                            If dtrows.Length > 0 Then
                                strOutMsg = strOutMsg & "<TR BGCOLOR=" & strTableColor & ">"
                                For intj = 0 To UBound(ColLabel)
                                    ' Collum width
                                    strmw = ""
                                    If UBound(UserColWidth) >= intj Then
                                        If Not Trim(UserColWidth(intj)) = "" Then
                                            strmw = " WIDTH=""" & Trim(UserColWidth(intj)) & """"
                                        End If
                                    End If
                                    ' Collum align
                                    strma = ""
                                    If UBound(UserColAlign) >= intj Then
                                        If Not Trim(UserColAlign(intj)) = "" Then
                                            strma = " ALIGN=" & Trim(UserColAlign(intj)) & " "
                                        End If
                                    End If
                                    ' Collum format
                                    strmf = ColLabel(intj)
                                    If UBound(UserColFormat) >= intj Then
                                        If Not Trim(UserColFormat(intj)) = "" Then
                                            strmf = Replace(UserColFormat(intj), "<$DATA$>", ColLabel(intj))
                                        End If
                                    End If
                                    strOutMsg = strOutMsg & "<TH VALIGN=TOP BGCOLOR=" & strTableColor & "  " & strmw & "  " & strma & ">" & strmf & "</TH>"
                                Next
                                strOutMsg = strOutMsg & "</TR>"
                                If dtrows.Length < intUbound Or intUbound = -1 Then
                                    intUbound = dtrows.Length
                                End If
                                For intj = 0 To intUbound - 1
                                    If intj Mod 2 = 0 Then ' Change row color
                                        strChangeRowColor = strEventColor
                                    Else
                                        strChangeRowColor = strOddColor
                                    End If
                                    strOutMsg = strOutMsg & "<TR BGCOLOR=""" & strChangeRowColor & """>"
                                    ' Get data for each row ( collums data )
                                    For inti = LBound(Cols) To UBound(Cols)
                                        ' Collum Width
                                        strmw = ""
                                        If UBound(UserColWidth) >= inti Then
                                            If Not Trim(UserColWidth(inti)) = "" Then
                                                strmw = " WIDTH=""" & Trim(UserColWidth(inti)) & """"
                                            End If
                                        End If
                                        ' Collum Align
                                        strma = ""
                                        If UBound(UserColAlign) >= inti Then
                                            If Not Trim(UserColAlign(inti)) = "" Then
                                                strma = " ALIGN=" & Trim(UserColAlign(inti)) & " "
                                            End If
                                        End If
                                        ' Collum Format
                                        strmf = ""
                                        If UBound(UserColFormat) >= inti Then
                                            If Not Trim(UserColFormat(inti)) = "" Then
                                                strmf = UserColFormat(inti)
                                            End If
                                        End If
                                        Try
                                            Select Case Cols(inti)
                                                Case Else
                                                    If Not strmf = "" Then
                                                        strOutMsg = strOutMsg & "<TD VALIGN=TOP " & strmw & " " & strma & " BGCOLOR=" & strChangeRowColor & ">" & UserColFormat(inti).Replace("<$DATA$>", dtrows(intj).Item("" & Cols(inti).Replace("<$", "").Replace("$>", "") & "")) & "</TD>"
                                                    Else
                                                        strOutMsg = strOutMsg & "<TD VALIGN=TOP " & strmw & " " & strma & " BGCOLOR=" & strChangeRowColor & ">" & dtrows(intj).Item("" & Cols(inti).Replace("<$", "").Replace("$>", "") & "") & "</TD>"
                                                    End If
                                            End Select
                                        Catch ex As Exception
                                            strOutMsg = strOutMsg & "<TD VALIGN=TOP " & strmw & " " & strma & " BGCOLOR=" & strChangeRowColor & ">&nbsp;</TD>"
                                            strErrorMsg = ex.Message
                                        End Try
                                    Next
                                    strOutMsg = strOutMsg & "</TR>" & Chr(10)
                                Next
                            End If
                            dtrows = tblData.Select()
                            strOutMsg = strOutMsg & "<BR>"
                            ' Less erroueous
                            dtrows = tblData.Select("Erroneuos < 0")
                            If dtrows.Length > 0 Then
                                strOutMsg = strOutMsg & "<TR BGCOLOR=" & strTableColor & ">"
                                For intj = LBound(ColLabel2) To UBound(ColLabel2)
                                    ' Collum width
                                    strmw = ""
                                    If UBound(UserColWidth) >= intj Then
                                        If Not Trim(UserColWidth(intj)) = "" Then
                                            strmw = " WIDTH=""" & Trim(UserColWidth(intj)) & """"
                                        End If
                                    End If
                                    ' Collum align
                                    strma = ""
                                    If UBound(UserColAlign) >= intj Then
                                        If Not Trim(UserColAlign(intj)) = "" Then
                                            strma = " ALIGN=" & Trim(UserColAlign(intj)) & " "
                                        End If
                                    End If
                                    ' Collum format
                                    strmf = ColLabel2(intj)
                                    If UBound(UserColFormat) >= intj Then
                                        If Not Trim(UserColFormat(intj)) = "" Then
                                            strmf = UserColFormat(intj).Replace("<$DATA$>", ColLabel2(intj))
                                        End If
                                    End If
                                    strOutMsg = strOutMsg & "<TH VALIGN=TOP  " & strmw & " " & strma & ">" & strmf & "</TH>"
                                Next
                                strOutMsg = strOutMsg & "</TR>"
                                If dtrows.Length < intUbound Or intUbound = -1 Then
                                    intUbound = dtrows.Length
                                End If
                                For intj = 0 To intUbound - 1
                                    ' Change row color
                                    If intj Mod 2 = 0 Then
                                        strChangeRowColor = strEventColor
                                    Else
                                        strChangeRowColor = strOddColor
                                    End If
                                    strOutMsg = strOutMsg & "<TR>"
                                    For inti = LBound(Cols) To UBound(Cols)
                                        ' Collum width
                                        strmw = ""
                                        If UBound(UserColWidth) >= inti Then
                                            If Not Trim(UserColWidth(inti)) = "" Then
                                                strmw = " WIDTH=""" & Trim(UserColWidth(inti)) & """"
                                            End If
                                        End If
                                        ' Collum align
                                        strma = ""
                                        If UBound(UserColAlign) >= inti Then
                                            If Not Trim(UserColAlign(inti)) = "" Then
                                                strma = " ALIGN=" & Trim(UserColAlign(inti)) & " "
                                            End If
                                        End If
                                        ' Collum format
                                        strmf = ""
                                        If UBound(UserColFormat) >= inti Then
                                            If Not Trim(UserColFormat(inti)) = "" Then
                                                strmf = UserColFormat(inti)
                                            End If
                                        End If
                                        ' Bind data into each collum
                                        Try
                                            Select Case Cols(inti)
                                                Case "<$ERRONEUOS$>"
                                                    If Not strmf = "" Then
                                                        strOutMsg = strOutMsg & "<TD VALIGN=TOP " & strma & " " & strmw & " BGCOLOR=" & strChangeRowColor & ">" & UserColFormat(inti).Replace("<$DATA$>", -1 * CInt(dtrows(intj).Item("" & Cols(inti).Replace("<$", "").Replace("$>", "") & ""))) & "&nbsp;</TD>"
                                                    Else
                                                        strOutMsg = strOutMsg & "<TD VALIGN=TOP " & strma & " " & strmw & " BGCOLOR=" & strChangeRowColor & ">" & -1 * CInt(dtrows(intj).Item("" & Cols(inti).Replace("<$", "").Replace("$>", "") & "")) & "&nbsp;</TD>"
                                                    End If
                                                Case Else
                                                    If Not strmf = "" Then
                                                        strOutMsg = strOutMsg & "<TD VALIGN=TOP " & strma & " " & strmw & " BGCOLOR=" & strChangeRowColor & ">" & UserColFormat(inti).Replace("<$DATA$>", dtrows(intj).Item("" & Cols(inti).Replace("<$", "").Replace("$>", "") & "")) & "&nbsp;</TD>"
                                                    Else
                                                        strOutMsg = strOutMsg & "<TD VALIGN=TOP " & strma & " " & strmw & " BGCOLOR=" & strChangeRowColor & ">" & dtrows(intj).Item("" & Cols(inti).Replace("<$", "").Replace("$>", "") & "") & "&nbsp;</TD>"
                                                    End If
                                            End Select
                                        Catch ex As Exception
                                            strOutMsg = strOutMsg & "<TD VALIGN=TOP " & strma & " " & strmw & " BGCOLOR=" & strChangeRowColor & ">&nbsp;</TD>"
                                        End Try
                                    Next
                                    strOutMsg = strOutMsg & "</TR>"
                                Next
                            End If
                            strOutMsg = strOutMsg & "</TABLE>"
                        End If
                    End If
                    strOutMsg = strOutMsg & objBCSP.ToUTF8Back(strFooter) & strPageFooter
                    objMetric.objData(0) = strOutMsg
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                'objTemplate = Nothing
            End Try
            GenPOClaim = objMetric
        End Function

        ' Class: GetOrderedItems
        ' Purpose: Get ordered items of this cotract
        ' Input: AcqPOID
        ' Output: datatable result
        ' Creator: Oanhtn
        Public Function GetOrderedItems() As DataTable
            Try
                objDPO.ACQPOID = intAcqPOID
                GetOrderedItems = objBCDBS.ConvertTable(objDPO.GetOrderedItems)
                strErrorMsg = objDPO.ErrorMsg
                intErrorCode = objDPO.ErrorCode
            Catch Exp As Exception
                strErrorMsg = Exp.Message.ToString
            End Try
        End Function

        ' Purpose: Remove items of the selected contract
        ' Input: Source ItemID
        ' Creator: Oanhtn
        ' CreatedDate: 09/04/2005
        Public Sub RemoveItems(ByVal strItemIDs As String)
            Try
                Call objDPO.RemoveItems(strItemIDs)
                strErrorMsg = objDPO.ErrorMsg
                intErrorCode = objDPO.ErrorCode
            Catch Exp As Exception
                strErrorMsg = Exp.Message.ToString
            End Try
        End Sub

        ' Method: GetTotalContracts
        ' Purpose: Get total of contracts
        ' Output: integer value
        ' Creator: Oanhtn
        ' CreatedDate: 11/04/2005
        Public Function GetTotalContracts() As Integer
            Try
                objDPO.LibID = intLibID
                GetTotalContracts = objDPO.GetTotalContracts
                strErrorMsg = objDPO.ErrorMsg
                intErrorCode = objDPO.ErrorCode
            Catch Exp As Exception
                strErrorMsg = Exp.Message.ToString
            End Try
        End Function

        ' ****************************************************************************
        ' SERIAL
        ' ****************************************************************************

        ' GetContractList method
        ' Purpose: get list of contracts
        ' Input: some main infor of contract and it's request
        ' Output: datatable result
        Public Function GetContractList(ByVal strValidDateFrom As String, ByVal strValidDateTo As String, ByVal intBudgetID As Integer) As DataTable
            Try
                objDPO.PoType = intPoType
                objDPO.PoName = Trim(objBCSP.ConvertItBack(strPoName))
                objDPO.ReceiptNo = Trim(objBCSP.ConvertItBack(strReceiptNo))
                objDPO.VendorID = intVendorID
                GetContractList = objBCDBS.ConvertTable(objDPO.GetContractList(Trim(objBCDBS.ConvertDateBack(strValidDateFrom)), Trim(objBCDBS.ConvertDateBack(strValidDateTo)), intBudgetID), False)
                strErrorMsg = objDPO.ErrorMsg
                intErrorCode = objDPO.ErrorCode
            Catch Ex As Exception
                strErrorMsg = Ex.Message
            Finally
            End Try
        End Function

        ' Change PO Status method
        ' Purpose: Change PO status
        ' Input: POIDs, StatusID
        Public Sub ChangePOStatus(ByVal strPOIDs As String)
            Try
                objDPO.ACQPOID = intAcqPOID
                objDPO.StatusID = intStatusID
                objDPO.ChangePOStatus(strPOIDs)
                strErrorMsg = objDPO.ErrorMsg
                intErrorCode = objDPO.ErrorCode
            Catch Ex As Exception
                strErrorMsg = Ex.Message
            End Try
        End Sub

        Public Function StatAcqPOStatus(Optional ByVal strDateSetFrom As String = "", Optional ByVal strDateSetTo As String = "", Optional ByVal intAcqSourceID As Integer = 0) As DataTable
            Dim intRowIndex As Integer = 0
            Dim intTotalRecords As Integer = 0
            Dim tblData As DataTable

            Try
                strDateSetFrom = objBCDBS.ConvertDateBack(strDateSetFrom, False)
                strDateSetTo = objBCDBS.ConvertDateBack(strDateSetTo, False)
                tblData = objDPO.StatAcqPOStatus(strDateSetFrom, strDateSetTo, intAcqSourceID)

                If Not IsNothing(tblData) AndAlso tblData.Rows.Count Then
                    intTotalRecords = tblData.Rows.Count
                    ReDim arrData(intTotalRecords - 1)
                    ReDim arrLabel(intTotalRecords - 1)
                    For intRowIndex = 0 To intTotalRecords - 1
                        arrData(intRowIndex) = tblData.Rows(intRowIndex).Item("Count")
                        arrLabel(intRowIndex) = tblData.Rows(intRowIndex).Item("Status")
                    Next
                Else
                    ReDim arrData(0)
                    ReDim arrLabel(0)
                    arrData(0) = -1
                    arrLabel(0) = ""
                End If

                intErrorCode = objDPO.ErrorCode
                strErrorMsg = objDPO.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function
        Public Function StatAcqPOStatusDetail(Optional ByVal strDateSetFrom As String = "", Optional ByVal strDateSetTo As String = "", Optional ByVal intAcqSourceID As Integer = 0) As DataTable
            strDateSetFrom = objBCDBS.ConvertDateBack(strDateSetFrom, False)
            strDateSetTo = objBCDBS.ConvertDateBack(strDateSetTo, False)
            Dim tblData As New DataTable()
            Try
                tblData = objDPO.StatAcqPOStatusDetail(strDateSetFrom, strDateSetTo, intAcqSourceID)
                strErrorMsg = objDPO.ErrorMsg
                intErrorCode = objDPO.ErrorCode
            Catch ex As Exception
                strErrorMsg = objDPO.ErrorMsg
                intErrorCode = objDPO.ErrorCode
            End Try
            Return tblData
        End Function

        ' Method: Dispose
        ' Purpose: Release resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not objBCDBS Is Nothing Then
                        objBCDBS.Dispose(True)
                        objBCDBS = Nothing
                    End If
                    If Not objDPO Is Nothing Then
                        objDPO.Dispose(True)
                        objDPO = Nothing
                    End If
                    If Not objBCSP Is Nothing Then
                        objBCSP.Dispose(True)
                        objBCSP = Nothing
                    End If
                    If Not objBCT Is Nothing Then
                        objBCT.Dispose(True)
                        objBCT = Nothing
                    End If
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace