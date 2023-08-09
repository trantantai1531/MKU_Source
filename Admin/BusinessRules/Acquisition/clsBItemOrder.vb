Imports eMicLibAdmin.DataAccess.Acquisition
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports System.Math
Imports System.IO
Imports Aspose.Words
Imports System.Web

Namespace eMicLibAdmin.BusinessRules.Acquisition
    Public Class clsBItemOrder
        Inherits clsBBase

        ' *****************************************************************************************************
        ' Declare Private variables
        ' *****************************************************************************************************

        Private intRequestID As Integer = 0
        Private chrRegularityCode As String = ""
        Private intTypeID As Integer = 0
        Private decUnitPrice As Decimal = 0
        Private strCurrency As String = ""
        Private strCreatedDate As String = ""
        Private bytAccepted As Byte = 0
        Private strNote As String = ""
        Private bytRenewed As Byte = 0
        Private decIssuePrice As Decimal = 0
        Private strISBN As String = ""
        Private strISSN As String = ""
        Private strEdition As String = ""
        Private intUrgency As Integer = 0
        Private strSerialCode As String = ""
        Private strPubYear As String = ""
        Private strValidSubscribedDate As String = ""
        Private strExpiredSubscribedDate As String = ""
        Private intLanguageID As Integer = 0
        Private strRequester As String = ""
        Private bytAcquired As Byte = 0
        Private intCountryID As Integer = 0
        Private strPublisher As String = ""
        Private intIssues As Integer = 0
        Private intAcceptedCopies As Integer = 0
        Private intReceivedCopies As Integer = 0
        Private intRequestedCopies As Integer = 0
        Private strAuthor As String = ""
        Private intItemID As Integer = 0
        Private strTitle As String = ""
        Private intMediumID As Integer = 0
        Private collecCollumTitle As Collection
        Private collecHeaderFooter As Collection
        Private strFromDate As String = ""
        Private strToDate As String = ""
        Private strHaveFields As String = ""
        Private strSumCurrency As String = ""
        Private dblSumCurrencyRate As Double = 0
        Private dblCurrencyRate As Double = 0
        Private intTemplateID As Integer = 0
        Private intPOID As Integer = 0
        Private intStatusID As Integer = 0
        Private strSetDate As String = ""
        Private intItemTypeID As Integer = 0
        Private strAdditionalBy As String
        Private intAcqSourceID As Integer
        Private intLoanTypeID As Integer

        ' User object define
        Private objDItemOrder As New clsDItemOrder
        Private objBCB As New clsBCommonBusiness
        Private objBCDBS As New clsBCommonDBSystem
        Private objBCSP As New clsBCommonStringProc
        Private objBT As New clsBTemplate
        Private objBVendor As New clsBVendor
        Private objBCT As New clsBCommonTemplate

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' POID property
        Public Property POID() As Integer
            Get
                Return (intPOID)
            End Get
            Set(ByVal Value As Integer)
                intPOID = Value
            End Set
        End Property

        ' StatusID property
        Public Property StatusID() As Integer
            Get
                Return (intStatusID)
            End Get
            Set(ByVal Value As Integer)
                intStatusID = Value
            End Set
        End Property

        ' SetDate property 
        Public Property SetDate() As String
            Get
                Return (strSetDate)
            End Get
            Set(ByVal Value As String)
                strSetDate = Value
            End Set
        End Property

        ' ItemTypeID property
        Public Property ItemTypeID() As Integer
            Get
                Return intItemTypeID
            End Get
            Set(ByVal Value As Integer)
                intItemTypeID = Value
            End Set
        End Property

        ' TemplateID property
        Public Property TemplateID() As Integer
            Get
                Return (intTemplateID)
            End Get
            Set(ByVal Value As Integer)
                intTemplateID = Value
            End Set
        End Property

        ' Currency Rate property
        Public Property CurrencyRate() As Double
            Get
                Return (dblCurrencyRate)
            End Get
            Set(ByVal Value As Double)
                dblCurrencyRate = Value
            End Set
        End Property

        ' SumCurrencyRate property
        Public Property SumCurrencyRate() As Double
            Get
                Return (dblSumCurrencyRate)
            End Get
            Set(ByVal Value As Double)
                dblSumCurrencyRate = Value
            End Set
        End Property

        ' SumCurrency property
        Public Property SumCurrency() As String
            Get
                Return (strSumCurrency)
            End Get
            Set(ByVal Value As String)
                strSumCurrency = Value
            End Set
        End Property

        ' FromDate property
        Public Property FromDate() As String
            Get
                Return (strFromDate)
            End Get
            Set(ByVal Value As String)
                strFromDate = Value
            End Set
        End Property

        ' ToDate property
        Public Property ToDate() As String
            Get
                Return (strToDate)
            End Get
            Set(ByVal Value As String)
                strToDate = Value
            End Set
        End Property

        ' HaveFields property
        Public Property HaveFields() As String
            Get
                Return (strHaveFields)
            End Get
            Set(ByVal Value As String)
                strHaveFields = Value
            End Set
        End Property

        ' CollumTitle property
        Public Property CollumTitle() As Collection
            Get
                Return (collecCollumTitle)
            End Get
            Set(ByVal Value As Collection)
                collecCollumTitle = Value
            End Set
        End Property

        ' CollumHeaderFooter property
        Public Property CollumHeaderFooter() As Collection
            Get
                Return (collecHeaderFooter)
            End Get
            Set(ByVal Value As Collection)
                collecHeaderFooter = Value
            End Set
        End Property

        ' RequestID property
        Public Property RequestID() As Integer
            Get
                Return intRequestID
            End Get
            Set(ByVal Value As Integer)
                intRequestID = Value
            End Set
        End Property

        ' RegularityCode property
        Public Property RegularityCode() As String
            Get
                Return chrRegularityCode
            End Get
            Set(ByVal Value As String)
                chrRegularityCode = Value
            End Set
        End Property

        ' TypeID property
        Public Property TypeID() As Integer
            Get
                Return intTypeID
            End Get
            Set(ByVal Value As Integer)
                intTypeID = Value
            End Set
        End Property

        ' UnitPrice property
        Public Property UnitPrice() As Decimal
            Get
                Return decUnitPrice
            End Get
            Set(ByVal Value As Decimal)
                decUnitPrice = Value
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

        ' CreatedDate property
        Public Property CreatedDate() As String
            Get
                Return strCreatedDate
            End Get
            Set(ByVal Value As String)
                strCreatedDate = Value
            End Set
        End Property

        ' Accepted property
        Public Property Accepted() As Byte
            Get
                Return bytAccepted
            End Get
            Set(ByVal Value As Byte)
                bytAccepted = Value
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

        ' Renewed property
        Public Property Renewed() As Byte
            Get
                Return bytRenewed
            End Get
            Set(ByVal Value As Byte)
                bytRenewed = Value
            End Set
        End Property

        ' decIssuePrice property
        Public Property IssuePrice() As Decimal
            Get
                Return decIssuePrice
            End Get
            Set(ByVal Value As Decimal)
                decIssuePrice = Value
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

        ' ISSN property
        Public Property ISSN() As String
            Get
                Return strISSN
            End Get
            Set(ByVal Value As String)
                strISSN = Value
            End Set
        End Property

        ' Edition property
        Public Property Edition() As String
            Get
                Return strEdition
            End Get
            Set(ByVal Value As String)
                strEdition = Value
            End Set
        End Property

        ' Urgency property
        Public Property Urgency() As Integer
            Get
                Return intUrgency
            End Get
            Set(ByVal Value As Integer)
                intUrgency = Value
            End Set
        End Property

        ' SerialCode property
        Public Property SerialCode() As String
            Get
                Return strSerialCode
            End Get
            Set(ByVal Value As String)
                strSerialCode = Value
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

        ' ValidSubscribedDate property
        Public Property ValidSubscribedDate() As String
            Get
                Return strValidSubscribedDate
            End Get
            Set(ByVal Value As String)
                strValidSubscribedDate = Value
            End Set
        End Property

        ' ExpiredSubscribedDate property
        Public Property ExpiredSubscribedDate() As String
            Get
                Return strExpiredSubscribedDate
            End Get
            Set(ByVal Value As String)
                strExpiredSubscribedDate = Value
            End Set
        End Property

        ' LanguageID property
        Public Property LanguageID() As Integer
            Get
                Return intLanguageID
            End Get
            Set(ByVal Value As Integer)
                intLanguageID = Value
            End Set
        End Property

        ' Requester property
        Public Property Requester() As String
            Get
                Return strRequester
            End Get
            Set(ByVal Value As String)
                strRequester = Value
            End Set
        End Property

        ' Acquired property
        Public Property Acquired() As Byte
            Get
                Return bytAcquired
            End Get
            Set(ByVal Value As Byte)
                bytAcquired = Value
            End Set
        End Property

        ' CountryID property
        Public Property CountryID() As Integer
            Get
                Return intCountryID
            End Get
            Set(ByVal Value As Integer)
                intCountryID = Value
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

        ' Issues property
        Public Property Issues() As Integer
            Get
                Return intIssues
            End Get
            Set(ByVal Value As Integer)
                intIssues = Value
            End Set
        End Property

        ' AcceptedCopies property
        Public Property AcceptedCopies() As Integer
            Get
                Return intAcceptedCopies
            End Get
            Set(ByVal Value As Integer)
                intAcceptedCopies = Value
            End Set
        End Property

        ' ReceivedCopies property
        Public Property ReceivedCopies() As Integer
            Get
                Return intReceivedCopies
            End Get
            Set(ByVal Value As Integer)
                intReceivedCopies = Value
            End Set
        End Property

        ' RequestedCopies property
        Public Property RequestedCopies() As Integer
            Get
                Return intRequestedCopies
            End Get
            Set(ByVal Value As Integer)
                intRequestedCopies = Value
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

        ' ItemID property
        Public Property ItemID() As Integer
            Get
                Return intItemID
            End Get
            Set(ByVal Value As Integer)
                intItemID = Value
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

        ' MediumID property
        Public Property MediumID() As Integer
            Get
                Return intMediumID
            End Get
            Set(ByVal Value As Integer)
                intMediumID = Value
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
        ' LoanTypeID property
        Public Property LoanTypeID() As Integer
            Get
                Return intLoanTypeID
            End Get
            Set(ByVal Value As Integer)
                intLoanTypeID = Value
            End Set
        End Property

        ' AdditionalBy property
        Public Property AdditionalBy() As String
            Get
                Return strAdditionalBy
            End Get
            Set(value As String)
                strAdditionalBy = value
            End Set
        End Property
        ' Purpose: define new structure like metric 2 vector
        Structure Metric
            Dim objData As Object
            Dim objEmail As Object
        End Structure

        ' Method: Initialize
        ' Purpose: Init all objects
        Public Sub Initialize()
            ' Init objDItemOrder object
            objDItemOrder.ConnectionString = strConnectionString
            objDItemOrder.DBServer = strDBServer
            objDItemOrder.Initialize()

            ' Init objBCDBS object
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.DBServer = strDBServer
            objBCDBS.Initialize()

            ' Init objBT object
            objBT.ConnectionString = strConnectionString
            objBT.InterfaceLanguage = strInterfaceLanguage
            objBT.DBServer = strDBServer
            objBT.Initialize()

            ' Init objBCSP object
            objBCSP.ConnectionString = strConnectionString
            objBCSP.InterfaceLanguage = strInterfaceLanguage
            objBCSP.DBServer = strDBServer
            objBCSP.Initialize()

            ' Init objBVendor object
            objBVendor.ConnectionString = strConnectionString
            objBVendor.InterfaceLanguage = strInterfaceLanguage
            objBVendor.DBServer = strDBServer
            objBVendor.Initialize()

            ' Init objBCB objectobjBCB
            objBCB.ConnectionString = strConnectionString
            objBCB.InterfaceLanguage = strInterfaceLanguage
            objBCB.DBServer = strDBServer
            objBCB.Initialize()

            ' Init objBCT object
            objBCT.ConnectionString = strConnectionString
            objBCT.DBServer = strDBServer
            objBCT.InterfaceLanguage = strInterfaceLanguage
            Call objBCT.Initialize()
        End Sub

        Public Function Create() As Long
            Try
                objDItemOrder.RegularityCode = chrRegularityCode
                objDItemOrder.TypeID = intTypeID
                objDItemOrder.UnitPrice = decUnitPrice
                objDItemOrder.Currency = strCurrency
                objDItemOrder.Accepted = bytAccepted
                objDItemOrder.Note = objBCSP.ConvertItBack(strNote)
                objDItemOrder.Renewed = bytRenewed
                objDItemOrder.IssuePrice = decIssuePrice
                objDItemOrder.ISBN = strISBN
                objDItemOrder.ISSN = strISSN
                objDItemOrder.Edition = objBCSP.ConvertItBack(strEdition)
                objDItemOrder.Urgency = intUrgency
                objDItemOrder.SerialCode = strSerialCode
                objDItemOrder.PubYear = strPubYear
                objDItemOrder.ValidSubscribedDate = objBCDBS.ConvertDateBack(strValidSubscribedDate)
                objDItemOrder.ExpiredSubscribedDate = objBCDBS.ConvertDateBack(strExpiredSubscribedDate)
                objDItemOrder.LanguageID = intLanguageID
                objDItemOrder.Requester = strRequester
                objDItemOrder.Acquired = bytAcquired
                objDItemOrder.CountryID = intCountryID
                objDItemOrder.Publisher = objBCSP.ConvertItBack(strPublisher)
                objDItemOrder.Issues = intIssues
                objDItemOrder.AcceptedCopies = intAcceptedCopies
                objDItemOrder.ReceivedCopies = intReceivedCopies
                objDItemOrder.RequestedCopies = intRequestedCopies
                objDItemOrder.Author = objBCSP.ConvertItBack(strAuthor)
                objDItemOrder.ItemID = intItemID
                objDItemOrder.Title = objBCSP.ConvertItBack(strTitle)
                objDItemOrder.MediumID = intMediumID
                objDItemOrder.ItemTypeID = intItemTypeID
                objDItemOrder.LibID = intLibID
                objDItemOrder.AdditionalBy = strAdditionalBy
                objDItemOrder.AcqSourceID = intAcqSourceID
                objDItemOrder.LoanTypeID = intLoanTypeID
                ' Create
                Create = objDItemOrder.Create
                strErrorMsg = objDItemOrder.ErrorMsg
                intErrorCode = objDItemOrder.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        ' Method: Update
        ' Purpose: Pick items for the selected contract
        ' Input: ContractID, ItemIDs
        ' Creator: Sondp
        Public Sub Update(ByVal intContractID As Integer, ByVal strItemIDs As String)
            Try
                Call objDItemOrder.Update(intContractID, strItemIDs)
                intErrorCode = objDItemOrder.ErrorCode
                strErrorMsg = objDItemOrder.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Function Update() As Integer
            Try
                objDItemOrder.RequestID = intRequestID
                objDItemOrder.RegularityCode = chrRegularityCode
                objDItemOrder.TypeID = intTypeID
                objDItemOrder.UnitPrice = decUnitPrice
                objDItemOrder.Currency = strCurrency
                objDItemOrder.Accepted = bytAccepted
                objDItemOrder.Note = objBCSP.ConvertItBack(strNote)
                objDItemOrder.Renewed = bytRenewed
                objDItemOrder.IssuePrice = decIssuePrice
                objDItemOrder.ISBN = strISBN
                objDItemOrder.ISSN = strISSN
                objDItemOrder.Edition = strEdition
                objDItemOrder.Urgency = intUrgency
                objDItemOrder.SerialCode = strSerialCode
                objDItemOrder.PubYear = strPubYear
                objDItemOrder.ValidSubscribedDate = objBCDBS.ConvertDateBack(strValidSubscribedDate)
                objDItemOrder.ExpiredSubscribedDate = objBCDBS.ConvertDateBack(strExpiredSubscribedDate)
                objDItemOrder.LanguageID = intLanguageID
                objDItemOrder.Requester = strRequester
                objDItemOrder.Acquired = bytAcquired
                objDItemOrder.CountryID = intCountryID
                objDItemOrder.Publisher = strPublisher
                objDItemOrder.Issues = intIssues
                objDItemOrder.AcceptedCopies = intAcceptedCopies
                objDItemOrder.ReceivedCopies = intReceivedCopies
                objDItemOrder.RequestedCopies = intRequestedCopies
                objDItemOrder.Author = objBCSP.ConvertItBack(strAuthor)
                objDItemOrder.ItemID = intItemID
                objDItemOrder.Title = objBCSP.ConvertItBack(strTitle)
                objDItemOrder.MediumID = intMediumID
                objDItemOrder.ItemTypeID = intItemTypeID
                objDItemOrder.AdditionalBy = strAdditionalBy
                objDItemOrder.AcqSourceID = intAcqSourceID
                objDItemOrder.LoanTypeID = intLoanTypeID

                ' Update
                Update = objDItemOrder.Update
                strErrorMsg = objDItemOrder.ErrorMsg
                intErrorCode = objDItemOrder.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        ' Purpose:
        ' Input:
        ' Output:
        ' Creator:
        Public Function Delete() As Integer
            objDItemOrder.RequestID = intRequestID
            Return objDItemOrder.Delete
        End Function

        ' Method: GetOrderItemsList
        ' Purpose: Get list of ordered items
        ' Output: datatable result
        ' Creator: Sondp
        'Public Function GetOrderItemsList() As DataTable
        '    Try
        '        GetOrderItemsList = objBCDBS.ConvertTable(objDItemOrder.GetOrderItemsList)
        '        strErrorMsg = objDItemOrder.ErrorMsg
        '        intErrorCode = objDItemOrder.ErrorCode
        '    Catch ex As Exception
        '        strErrorMsg = ex.Message
        '    End Try
        'End Function

        ' Method: AcceptedItemOrder
        ' Purpose: Update ItemOrder
        ' Input: srtIDs, strAccepted
        ' Creator: Sondp
        Public Sub AcceptedItemOrder(ByVal strIDs As String, ByVal strAccepted As String)
            Try
                objDItemOrder.AcceptedItemOrder(strIDs, strAccepted)
                strErrorMsg = objDItemOrder.ErrorMsg
                intErrorCode = objDItemOrder.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Method: Delete selected ItemOrders
        ' Purpose: Delete ItemOrder
        ' Input: strIDs
        ' Creator: Sondp
        Public Sub DeleteItemOrder(ByVal strIDs As String)
            Try
                objDItemOrder.DeleteItemOrder(strIDs)
                strErrorMsg = objDItemOrder.ErrorMsg
                intErrorCode = objDItemOrder.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Method: GetAcqPublisher
        ' Purpose: Get all publisher from Acq_tblItem
        ' Output: Datatable result
        ' Creator: Sondp
        Public Function GetAcqPublisher() As DataTable
            Try
                GetAcqPublisher = objBCDBS.ConvertTable(objDItemOrder.GetAcqPublisher)
                strErrorMsg = objDItemOrder.ErrorMsg
                intErrorCode = objDItemOrder.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose:
        ' Input:
        ' Output:
        ' Creator:
        Public Sub CheckItem()

        End Sub

        ' Method: GetOrderItems
        ' Purpose: get list of items order
        ' Input: TypeID, RequestID
        ' Output: Datatable result
        ' Creator:  Oanhtn
        Public Function GetOrderItems() As DataTable
            Dim tblResult As DataTable
            Dim inti As Integer
            Try
                objDItemOrder.RequestID = intRequestID
                objDItemOrder.TypeID = intTypeID
                objDItemOrder.LibID = intLibID
                tblResult = objBCDBS.SortTable(objBCDBS.ConvertTable(objDItemOrder.GetOrderItems), "MainTitle")
                If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                    For inti = 0 To tblResult.Rows.Count - 1
                        If Not IsDBNull(tblResult.Rows(inti).Item("Amount")) Then
                            tblResult.Rows(inti).Item("Amount") = CStr(CLng(tblResult.Rows(inti).Item("Amount"))) & " (VND)"
                        End If
                    Next
                End If
                GetOrderItems = tblResult
                strErrorMsg = objDItemOrder.ErrorMsg
                intErrorCode = objDItemOrder.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
        End Function

        ' Purpose: Generate acquisition items to print
        ' Input: Some informations
        ' Output: string
        ' Creator: Sondp
        Public Function POPrint() As String
            Dim strTitle, strHeader, strPageHeader, strCollums, strCollumCaptions, strCollumWidths, strCollumAligns, strCollumFormats, strPageFooter, strTableColor, strOddColor, strEventColor, strFooter, strItem, strStream, strmw, strma, strmf, strChangeColor, arrItems(), UserColLabel(), UserColWidth(), Cols(), ColLabel(), UserColAligns(), UserColFormats() As String
            'Dim objTemplate As New TVCOMLib.LibolTemplate
            'Dim objSort As New TVCOMLib.utf8
            Dim objFields, objData, objTitle, objDisp As Object
            Dim tblTemplate As New DataTable
            Dim tblData As New DataTable
            Dim inti, intj, intk As Integer
            Dim dblSumVol, dblSumAmount, dblSumPVol As Double
            Dim boolUseSum, boolmf As Boolean
            boolUseSum = False
            intk = 0
            dblSumVol = 0
            dblSumAmount = 0
            dblSumPVol = 0
            Try
                objBT.TemplateID = intTemplateID
                objBT.TemplateType = 9
                tblTemplate = objBT.GetTemplate
                strErrorMsg = objBT.ErrorMsg
                intErrorCode = objBT.ErrorCode
                If tblTemplate Is Nothing Or tblTemplate.Rows.Count <= 0 Then
                    POPrint = ""
                    Exit Function
                End If
                strTitle = tblTemplate.Rows(0).Item("Title")
                arrItems = Split(tblTemplate.Rows(0).Item("Content"), Chr(9))
                strHeader = objBCSP.ToUTF8(Replace(arrItems(0), "<~>", vbCrLf))
                strPageHeader = arrItems(1)
                strCollums = arrItems(2)
                strCollumCaptions = arrItems(3)
                strCollumWidths = arrItems(4)
                strCollumAligns = arrItems(5)
                strCollumFormats = arrItems(6)
                ' Table color
                If Not arrItems(7) & "" = "" Then
                    strTableColor = arrItems(7)
                Else
                    strTableColor = "#FFFFFF"
                End If
                ' Event color
                If Not arrItems(8) & "" = "" Then
                    strEventColor = arrItems(8)
                Else
                    strEventColor = "#FFFFFF"
                End If
                ' Odd color
                If Not arrItems(9) & "" = "" Then
                    strOddColor = arrItems(9)
                Else
                    strOddColor = "#FFFFFF"
                End If
                strPageFooter = arrItems(10)
                strFooter = objBCSP.ToUTF8(Replace(arrItems(11), "<~>", vbCrLf))
                ' Process here
                'objTemplate.Template = strHeader & "@@@@@" & strFooter
                'objFields = objTemplate.Fields
                Dim strContentTemp As String = strHeader & "@@@@@" & strFooter
                objFields = objBCT.getArrayFromTemplate(strContentTemp)
                'ReDim objData(UBound(objTemplate.Fields))
                If Not IsNothing(objFields) AndAlso IsArray(objFields) Then
                    ReDim objData(UBound(objFields))
                    For inti = LBound(objFields) To UBound(objFields)
                        strItem = "" & "" & objFields(inti) & "" & ""
                        Select Case Len(strItem)
                            Case Is > 0
                                objData(inti) = collecHeaderFooter.Item(strItem) & Chr(9)
                                strContentTemp = Replace(strContentTemp, "<$" & objFields(inti) & "$>", objData(inti))
                            Case Else
                                objData(inti) = "" & Chr(9)
                        End Select
                    Next
                End If

                'strStream = objTemplate.Generate(objData)
                strStream = strContentTemp
                strStream = Replace(strStream, "  ", "&nbsp;&nbsp;")
                strHeader = objBCSP.ToUTF8Back(Left(strStream, InStr(strStream, "@@@@@") - 1))
                strFooter = objBCSP.ToUTF8Back(Right(strStream, Len(strStream) - InStr(strStream, "@@@@@") - 4))
                Cols = Split(strCollums, "<~>")
                UserColLabel = Split(strCollumCaptions, "<~>")
                UserColWidth = Split(strCollumWidths, "<~>")
                UserColAligns = Split(strCollumAligns, "<~>")
                UserColFormats = Split(strCollumFormats, "<~>")
                strStream = strHeader & strPageHeader
                ' Get data from datatabase
                objDItemOrder.Accepted = bytAccepted
                objDItemOrder.Publisher = strPublisher
                objDItemOrder.TypeID = intTypeID
                objDItemOrder.MediumID = intMediumID
                objDItemOrder.Urgency = intUrgency
                objDItemOrder.FromDate = strFromDate
                objDItemOrder.ToDate = strToDate
                objDItemOrder.Currency = strCurrency
                objDItemOrder.HaveFields = GetListFields(strCollums, "<~>")
                objDItemOrder.LibID = intLibID
                tblData = objBCDBS.ConvertTable(objDItemOrder.GetAcqItems)
                strErrorMsg = objDItemOrder.ErrorMsg
                intErrorCode = objDItemOrder.ErrorCode
                If Not tblData Is Nothing AndAlso tblData.Rows.Count > 0 Then
                    ReDim objTitle(tblData.Rows.Count - 1)
                    ReDim objDisp(tblData.Rows.Count - 1)
                    strStream = strStream & "<TABLE WIDTH=100% CELLPADDING=3 CELLSPACING=0 BORDER=1 BORDERCOLOR=""" & strTableColor & """ BGCOLOR=" & strTableColor & ">"
                    strStream = strStream & "<TR BGCOLOR=""DDDDDD"">"
                    ' Get collum title
                    For inti = LBound(Cols) To UBound(Cols)
                        Select Case Cols(inti)
                            Case Is <> ""
                                If Cols(inti) = "<$MONEY$>" Then
                                    boolUseSum = True
                                End If
                                strItem = "" & "" & Cols(inti) & "" & ""
                                ReDim Preserve ColLabel(intk)
                                If UBound(UserColLabel) >= inti Then
                                    If Not Trim(UserColLabel(inti)) = "" Then
                                        ColLabel(intk) = UserColLabel(inti)
                                    Else
                                        ColLabel(intk) = collecCollumTitle.Item(strItem)
                                    End If
                                Else
                                    ColLabel(intk) = collecCollumTitle.Item(strItem)
                                End If
                                intk = intk + 1
                        End Select
                    Next
                    ' Attact collumtitle on table
                    For intj = LBound(ColLabel) To UBound(ColLabel)
                        strmw = ""
                        If UBound(UserColWidth) >= intj Then
                            If Not Trim(UserColWidth(intj)) = "" Then
                                strmw = " WIDTH=""" & Trim(UserColWidth(intj)) & """"
                            End If
                        End If
                        strStream = strStream & "<TH VALIGN=TOP" & strmw & ">" & ColLabel(intj) & "</TH>"
                    Next
                    strStream = strStream & "</TR>"
                    ' BindData into each row in table
                    For intj = 0 To tblData.Rows.Count - 1
                        If intj Mod 2 = 0 Then
                            strChangeColor = strEventColor
                        Else
                            strChangeColor = strOddColor
                        End If
                        objTitle(intj) = objBCSP.ToUTF8(tblData.Rows(intj).Item("Title"))
                        objDisp(intj) = "<TR BGCOLOR=""" & strChangeColor & """>"
                        For inti = 0 To UBound(Cols)
                            ' Collum width
                            strmw = ""
                            If UBound(UserColWidth) >= inti Then
                                If Not Trim(UserColWidth(inti)) = "" Then
                                    strmw = " WIDTH=""" & Trim(UserColWidth(inti)) & """"
                                End If
                            End If
                            ' Collum align
                            strma = " ALIGN=CENTER "
                            If UBound(UserColAligns) >= inti Then
                                If Not Trim(UserColAligns(inti)) = "" Then
                                    strma = " ALIGN=""" & Trim(UserColAligns(inti)) & """"
                                End If
                            End If
                            ' Collum format
                            strmf = ""
                            If UBound(UserColFormats) >= inti Then
                                If Not Trim(UserColFormats(inti)) = "" Then
                                    strmf = UserColFormats(inti).Replace("<$DATA$>", ColLabel(inti))
                                End If
                            End If
                            ' Data detail
                            Try
                                strItem = ""
                                Select Case Cols(inti)
                                    Case "<$SEQUENCY$>"
                                        strItem = "<$@$>"
                                    Case "<$UNITPRICE$>"
                                        If Not IsDBNull(tblData.Rows(intj).Item("Currency")) Then
                                            If Not tblData.Rows(intj).Item("Currency") = strSumCurrency Then
                                                strItem = tblData.Rows(intj).Item("" & "" & Replace(Replace(Cols(inti), "<$", ""), "$>", "") & "" & "")
                                            Else
                                                strItem = strSumCurrency
                                            End If
                                        Else
                                            strItem = strSumCurrency
                                        End If
                                    Case "<$MONEY$>"
                                        If Not IsDBNull(tblData.Rows(intj).Item("Amount")) Then
                                            dblSumAmount = dblSumAmount + CDbl(tblData.Rows(intj).Item("Amount") * (dblCurrencyRate / dblSumCurrencyRate))
                                            strItem = Round(tblData.Rows(intj).Item("Amount"), 2)
                                        Else
                                            strItem = 0
                                        End If
                                    Case "<$REQUESTEDCOPIES$>"
                                        If Not IsDBNull(tblData.Rows(intj).Item("" & "" & Replace(Replace(Cols(inti), "<$", ""), "$>", "") & "" & "")) Then
                                            dblSumPVol = dblSumPVol + CInt(tblData.Rows(intj).Item("" & "" & Replace(Replace(Cols(inti), "<$", ""), "$>", "") & "" & ""))
                                            strItem = tblData.Rows(intj).Item("" & "" & Replace(Replace(Cols(inti), "<$", ""), "$>", "") & "" & "")
                                        End If
                                    Case "<$ACCEPTEDCOPIES$>"
                                        If Not IsDBNull(tblData.Rows(intj).Item("" & "" & Replace(Replace(Cols(inti), "<$", ""), "$>", "") & "" & "")) Then
                                            dblSumVol = dblSumVol + CDbl(tblData.Rows(intj).Item("" & "" & Replace(Replace(Cols(inti), "<$", ""), "$>", "") & "" & ""))
                                            strItem = tblData.Rows(intj).Item("" & "" & Replace(Replace(Cols(inti), "<$", ""), "$>", "") & "" & "")
                                        End If
                                    Case Else
                                        If Not IsDBNull(tblData.Rows(intj).Item("" & "" & Replace(Replace(Cols(inti), "<$", ""), "$>", "") & "" & "")) Then
                                            strItem = tblData.Rows(intj).Item("" & "" & Replace(Replace(Cols(inti), "<$", ""), "$>", "") & "" & "")
                                        End If
                                End Select
                                If Not strmf = "" Then
                                    objDisp(intj) = objDisp(intj) & "<TD VALIGN=TOP " & strmw & strma & ">" & UserColFormats(inti).Replace("<$DATA$>", strItem) & "</TD>"
                                Else
                                    objDisp(intj) = objDisp(intj) & "<TD VALIGN=TOP " & strmw & strma & ">" & strItem & "</TD>"
                                End If
                            Catch ex As Exception
                                strErrorMsg = ex.Message
                            End Try
                        Next
                        objDisp(intj) = objDisp(intj) & "</TR>" & Chr(10)
                    Next
                    ' Sort data
                    'objSort.SortBy(objDisp, objTitle, 1)
                    objBCSP.SortByDictionary(objDisp, objTitle, 1)
                    For inti = LBound(objDisp) To UBound(objDisp)
                        strStream = strStream & Replace(objDisp(inti), "<$@$>", inti + 1)
                    Next
                    If boolUseSum = True Then
                        strStream = strStream & "<TR BGCOLOR=DDDDDD>"
                        intk = 0
                        For inti = LBound(Cols) To UBound(Cols)
                            If Cols(inti) = "<$REQUESTEDCOPIES$>" Then
                                If intk > 0 Then
                                    strStream = strStream & "<TD COLSPAN=" & intk & ">&nbsp</TD>"
                                End If
                                intk = 0
                                strStream = strStream & "<TD ALIGN=""right""><B>" & dblSumPVol & "</B></TD>"
                            ElseIf Cols(inti) = "<$ACCEPTEDCOPIES$>" Then
                                If intk > 0 Then
                                    strStream = strStream & "<TD COLSPAN=" & intk & ">&nbsp</TD>"
                                End If
                                intk = 0
                                strStream = strStream & "<TD ALIGN=""right""><B>" & dblSumVol & "</B></TD>"
                            ElseIf Cols(inti) = "<$MONEY$>" Then
                                If intk > 0 Then
                                    strStream = strStream & "<TD COLSPAN=" & intk & ">&nbsp</TD>"
                                End If
                                intk = 0
                                strStream = strStream & "<TD ALIGN=""right""><B>" & dblSumAmount & "</B></TD>"
                            ElseIf Not Cols(inti) = "" Then
                                intk = intk + 1
                            End If
                        Next
                        If intk > 0 Then
                            strStream = strStream & "<TD COLSPAN=" & intk & ">&nbsp</TD>"
                        End If
                        strStream = strStream & "</TR>"
                    End If
                    strStream = strStream & "</TABLE>"
                Else
                    POPrint = ""
                    Exit Function
                End If
                strStream = strStream & strPageFooter & strFooter
                POPrint = strStream
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                'If Not objTemplate Is Nothing Then
                '    objTemplate = Nothing
                'End If
                'If Not objSort Is Nothing Then
                '    objSort = Nothing
                'End If
            End Try
        End Function

        ' Purpose: Get Acq_tblItem dependon strPOIDs
        ' Input: strPOIDs
        ' Output: Datatable
        ' Creator: Sondp
        Private Function GetACQITEMbyPOID(ByVal strPOIDs As String) As DataTable
            Try
                GetACQITEMbyPOID = objBCDBS.ConvertTable(objDItemOrder.GetACQITEMbyPOID(strPOIDs))
                strErrorMsg = objDItemOrder.ErrorMsg
                intErrorCode = objDItemOrder.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose: Generate PO informations
        ' Input: some infor
        ' Output: metric
        ' Creator: Sondp
        Public Function GenSendPO(ByVal strIDs As String) As Metric
            Dim tblTemplate As New DataTable
            Dim dtvVendor, dtvWaittingPO, dtvData As DataView
            Dim objMetric As New Metric
            'Dim objTemplate As New TVCOMLib.LibolTemplate
            Dim objFields As New Object
            Dim objData As New Object
            Dim arrContent(), arrPOIDs(), collums(), collumCaptions(), collumWidths(), collumAligns(), collumFormats(), collumUserLabel(), strHeader, strPageHeader, strCollums, strCollumCaptions, strCollumWidths, strCollumAligns, strCollumFormats, strTableColor, strOddColor, strEventColor, strPageFooter, strFooter, strItem, strOutMsg, strmf, strma, strmw, strChangeRowColor As String
            Dim inti, intj, intk, intVendorCount, intWaittingPOCount As Integer
            Dim boolLJ As Boolean
            boolLJ = False
            GenSendPO = Nothing
            If intTemplateID = 0 Then
                Exit Function
            End If
            ' Get template
            objBT.TemplateID = intTemplateID
            tblTemplate = objBT.GetTemplate
            If Not tblTemplate Is Nothing Then
                If tblTemplate.Rows.Count > 0 Then
                    arrContent = Split(tblTemplate.Rows(0).Item("Content"), Chr(9))
                    strHeader = objBCSP.ToUTF8(arrContent(0).Replace("<~>", "<BR>"))
                    strPageHeader = arrContent(1).Replace("<~>", "<BR>")
                    strCollums = arrContent(2)
                    strCollumCaptions = arrContent(3)
                    strCollumWidths = arrContent(4)
                    strCollumAligns = arrContent(5)
                    strCollumFormats = arrContent(6)
                    strTableColor = arrContent(7)
                    If strTableColor & "" = "" Then
                        strTableColor = "#000000"
                    End If
                    strOddColor = arrContent(8)
                    If strOddColor & "" = "" Then
                        strOddColor = "#F0F3F4"
                    End If
                    strEventColor = arrContent(9)
                    If strEventColor & "" = "" Then
                        strEventColor = "#c0c0c0"
                    End If
                    strPageFooter = arrContent(10).Replace("<~>", "<BR>")
                    strFooter = objBCSP.ToUTF8(arrContent(11).Replace("<~>", "<BR>"))
                    arrPOIDs = Split(strIDs, ",")
                    strChangeRowColor = strOddColor
                    collums = Split(strCollums, "<~>")
                    collumCaptions = Split(strCollumCaptions, "<~>")
                    collumWidths = Split(strCollumWidths, "<~>")
                    collumAligns = Split(strCollumAligns, "<~>")
                    collumFormats = Split(strCollumFormats, "<~>")
                    ReDim objMetric.objData(UBound(arrPOIDs))
                    ReDim objMetric.objEmail(UBound(arrPOIDs))
                    'objTemplate.Template = strHeader & "@@@@@" & strFooter
                    'objFields = objTemplate.Fields
                    Dim strContentTemp As String = strHeader & "@@@@@" & strFooter
                    objFields = objBCT.getArrayFromTemplate(strContentTemp)
                    ' Get Vendor
                    objBVendor.VendorID = 0
                    ReDim objData(0)
                    dtvVendor = objBVendor.GetVendorSendPO.DefaultView
                    ' Get Waitting PO list
                    dtvWaittingPO = GetWaittingPO.DefaultView
                    For inti = LBound(arrPOIDs) To UBound(arrPOIDs)
                        intVendorCount = 0
                        intWaittingPOCount = 0
                        dtvWaittingPO.RowFilter = "ID=" & arrPOIDs(inti)
                        intWaittingPOCount = dtvWaittingPO.Count
                        If intWaittingPOCount > 0 Then
                            dtvVendor.RowFilter = "ID=" & dtvWaittingPO.Item(0).Item("VendorID")
                            intVendorCount = dtvVendor.Count
                            If Not intVendorCount = 0 Then
                                objMetric.objEmail(inti) = ""
                                If Not (dtvVendor.Item(0).Item("Email")) Is Nothing Then
                                    If Not IsDBNull(dtvVendor.Item(0).Item("Email")) Then
                                        objMetric.objEmail(inti) = dtvVendor.Item(0).Item("Email")
                                    End If
                                End If
                                If Not objFields Is Nothing Then



                                    For intj = LBound(objFields) To UBound(objFields)
                                        ReDim Preserve objData(intj)
                                        objData(intj) = ""
                                        Select Case UCase(objFields(intj)) ' Header and Footer data standard
                                            Case "TITLE", "TITLE:UPPER", "TODAY", "TODAY:DD", "TODAY:MM", "TODAY:YYYY", "TODAY:HH", "TODAY:MI", "TODAY:SS"
                                                If Not collecHeaderFooter.Item("" & "" & objFields(intj) & "" & "") Is Nothing Then
                                                    If Not IsDBNull(collecHeaderFooter.Item("" & "" & objFields(intj) & "" & "")) Then
                                                        objData(intj) = collecHeaderFooter.Item("" & "" & objFields(intj) & "" & "")
                                                    End If
                                                End If
                                            Case "CONTRACTNAME", "CONTRACTVALIDDATE", "CONTRACTEXPIREDDATE", "SUM", "CURRENCY", "CONTRACTCODE" ' For Waitting PO data
                                                If Not dtvWaittingPO.Item(0).Item("" & "" & objFields(intj) & "" & "") Is Nothing Then
                                                    If Not IsDBNull(dtvWaittingPO.Item(0).Item("" & "" & objFields(intj) & "" & "")) Then
                                                        objData(intj) = objBCSP.ToUTF8(dtvWaittingPO.Item(0).Item("" & "" & objFields(intj) & "" & ""))
                                                    End If
                                                End If
                                            Case "USERFULLNAME"
                                                objData(intj) = HttpContext.Current.Session("UFULLNAME") & ""
                                            Case Else ' For Vendor data
                                                If Not dtvVendor.Item(0).Item("" & "" & objFields(intj) & "" & "") Is Nothing Then
                                                    If Not IsDBNull(dtvVendor.Item(0).Item("" & "" & objFields(intj) & "" & "")) Then
                                                        objData(intj) = objBCSP.ToUTF8(dtvVendor.Item(0).Item("" & "" & objFields(intj) & "" & ""))
                                                    End If
                                                End If
                                        End Select
                                        strContentTemp = Replace(strContentTemp, "<$" & objFields(intj) & "$>", objData(intj))
                                    Next
                                End If
                            End If
                        End If
                        'strOutMsg = objTemplate.Generate(objData)
                        strOutMsg = strContentTemp
                        strHeader = objBCSP.ToUTF8Back(Left(strOutMsg, InStr(strOutMsg, "@@@@@") - 1)).Replace("  ", "&nbsp;&nbsp;")
                        strFooter = objBCSP.ToUTF8Back(Right(strOutMsg, Len(strOutMsg) - InStr(strOutMsg, "@@@@@") - 4)).Replace("  ", "&nbsp;&nbsp;")
                        strOutMsg = strHeader & strPageHeader
                        ' Gen data collum title                           
                        intk = 0
                        For intj = LBound(collums) To UBound(collums)
                            ReDim Preserve collumUserLabel(intk)
                            Try
                                Select Case collums(intj)
                                    Case ""
                                        collumUserLabel(intk) = ""
                                    Case Else
                                        If UBound(collumCaptions) >= intj Then
                                            If Not Trim(collumCaptions(intj)) = "" Then
                                                collumUserLabel(intk) = collumCaptions(intj)
                                            Else
                                                collumUserLabel(intk) = collecCollumTitle.Item("" & "" & collums(intj) & "" & "")
                                            End If
                                        Else
                                            collumUserLabel(intk) = collecCollumTitle.Item("" & "" & collums(intj) & "" & "")
                                        End If
                                        intk = intk + 1
                                End Select
                            Catch ex As Exception
                                collumUserLabel(intk) = ""
                                strErrorMsg = ex.Message
                            End Try
                        Next
                        ' Get data to bind into table
                        dtvData = GetACQITEMbyPOID(CStr(arrPOIDs(inti))).DefaultView
                        If dtvData.Count > 0 Then
                            strOutMsg = strOutMsg & "<TABLE WIDTH=100% CELLPADDING=3 CELLSPACING=0 BORDER=1 BORDERCOLOR=""#000000"">"
                            strOutMsg = strOutMsg & "<TR BGCOLOR=""#DDDDDD"">"
                            For intj = LBound(collumUserLabel) To UBound(collumUserLabel)
                                strmw = ""
                                If UBound(collumWidths) >= intj Then
                                    If Not Trim(collumWidths(intj)) = "" Then
                                        strmw = " WIDTH=""" & Trim(collumWidths(intj)) & """"
                                    End If
                                End If
                                ' Collum align
                                strma = " ALIGN=CENTER"
                                If UBound(collumAligns) >= intj Then
                                    If Not Trim(collumAligns(intj)) = "" Then
                                        strma = " ALIGN=""" & Trim(collumAligns(intj)) & """"
                                    End If
                                End If
                                ' Collum format
                                strmf = collumUserLabel(intj)
                                If UBound(collumFormats) >= intj Then
                                    If Not Trim(collumFormats(intj)) = "" Then
                                        strmf = collumFormats(intj).Replace("<$DATA$>", collumUserLabel(intj))
                                    End If
                                End If
                                strOutMsg = strOutMsg & "<TH VALIGN=TOP" & strmw & strma & ">" & strmf & "</TH>"
                            Next
                            strOutMsg = strOutMsg & "</TR>"
                            ' Bind data to each cells and rows
                            For intj = 0 To dtvData.Count - 1
                                If intj Mod 2 = 0 Then
                                    strChangeRowColor = strEventColor
                                Else
                                    strChangeRowColor = strOddColor
                                End If
                                strOutMsg = strOutMsg & "<TR BGCOLOR=" & "" & strChangeRowColor & "" & "> "
                                For intk = LBound(collums) To UBound(collums)
                                    ' Collum width
                                    strmw = ""
                                    If UBound(collumWidths) >= intk Then
                                        If Not Trim(collumWidths(intk)) = "" Then
                                            strmw = " WIDTH=""" & Trim(collumWidths(intk)) & """"
                                        End If
                                    End If
                                    ' Collum Align
                                    strma = " ALIGN=LEFT "
                                    If UBound(collumAligns) >= intk Then
                                        If Not Trim(collumAligns(intk)) = "" Then
                                            strma = " ALIGN=""" & Trim(collumAligns(intk)) & """"
                                        End If
                                    End If
                                    ' Collum Format
                                    strmf = ""
                                    If UBound(collumFormats) >= intk Then
                                        If Not Trim(collumFormats(intk)) = "" Then
                                            strmf = Trim(collumFormats(intk))
                                        End If
                                    End If
                                    Try
                                        Select Case collums(intk)
                                            Case ""
                                                strOutMsg = strOutMsg & "<TD VALIGN=TOP " & strmw & strma & ">&nbsp;" & "</TD>"
                                            Case Else
                                                strItem = Replace(Replace(collums(intk), "<$", ""), "$>", "")
                                                If Not strmf = "" Then
                                                    strOutMsg = strOutMsg & "<TD VALIGN=TOP " & strmw & strma & ">&nbsp;" & collumFormats(intk).Replace("<$DATA$>", dtvData.Item(intj).Item(strItem)) & "</TD>"
                                                Else
                                                    strOutMsg = strOutMsg & "<TD VALIGN=TOP " & strmw & strma & ">&nbsp;" & dtvData.Item(intj).Item(strItem) & "</TD>"
                                                End If
                                        End Select
                                    Catch ex As Exception
                                        strOutMsg = strOutMsg & "<TD VALIGN=TOP " & strmw & strma & ">&nbsp;" & "</TD>"
                                        strErrorMsg = ex.Message
                                    End Try
                                Next
                                strOutMsg = strOutMsg & "</TR>"
                            Next
                        End If
                        strOutMsg = strOutMsg & "</TABLE>" & strPageFooter & strFooter & "<BR>"
                        objMetric.objData(inti) = strOutMsg
                        strOutMsg = ""
                    Next
                End If
            End If
            GenSendPO = objMetric
            'If Not objTemplate Is Nothing Then
            '    objTemplate = Nothing
            'End If
        End Function

        ' Purpose: Generate Separeted Store 
        ' Input: intTop, intPOID, intTemplate
        ' Output: Metric
        ' Creator: Sondp
        Public Function GenSeparetedStore(ByVal intTop As Integer, ByVal intPOID As Integer, ByVal intTemplateID As Integer) As Metric
            Dim tblTemplate As New DataTable
            Dim tblVendor, tblItems, tblHolLibLoc As DataTable
            Dim objMetric As New Metric
            'Dim objTemplate As New TVCOMLib.LibolTemplate
            Dim objFields As New Object
            Dim objData As New Object
            'Dim objSort As New TVCOMLib.utf8
            Dim arrContent(), collums(), collumCaptions(), collumWidths(), collumAligns(), collumFormats(), collumUserLabel(), strHeader, strPageHeader, strCollums, strCollumCaptions, strCollumWidths, strCollumAligns, strCollumFormats, strTableColor, strOddColor, strEventColor, strPageFooter, strFooter, strItem, strOutMsg, strmf, strma, strmw, strChangeRowColor, arrLocationsName() As String
            Dim arrTotPricInLoc() As Long
            Dim arrTotRecInLoc() As Integer
            Dim inti, intj, intk As Integer

            GenSeparetedStore = Nothing
            Try
                If intTemplateID = 0 Then
                    Exit Function
                End If
                objBT.TemplateID = intTemplateID
                tblTemplate = objBT.GetTemplate
                If Not tblTemplate Is Nothing Then
                    If tblTemplate.Rows.Count > 0 Then
                        ReDim objMetric.objData(0)
                        ReDim objMetric.objEmail(0)
                        objMetric.objData(0) = ""
                        objMetric.objEmail(0) = ""
                        arrContent = Split(tblTemplate.Rows(0).Item("Content"), Chr(9))
                        strHeader = objBCSP.ToUTF8(arrContent(0).Replace("<~>", "<BR>"))
                        strPageHeader = arrContent(1).Replace("<~>", "<BR>")
                        strCollums = arrContent(2)
                        strCollumCaptions = arrContent(3)
                        strCollumWidths = arrContent(4)
                        strCollumAligns = arrContent(5)
                        strCollumFormats = arrContent(6)
                        strTableColor = arrContent(7)
                        If strTableColor & "" = "" Then
                            strTableColor = "#000000"
                        End If
                        strOddColor = arrContent(8)
                        If strOddColor & "" = "" Then
                            strOddColor = "#F0F3F4"
                        End If
                        strEventColor = arrContent(9)
                        If strEventColor & "" = "" Then
                            strEventColor = "#c0c0c0"
                        End If
                        strPageFooter = arrContent(10).Replace("<~>", "<BR>")
                        strFooter = objBCSP.ToUTF8(arrContent(11).Replace("<~>", "<BR>"))
                        strChangeRowColor = strOddColor
                        collums = Split(strCollums, "<~>")
                        collumCaptions = Split(strCollumCaptions, "<~>")
                        collumWidths = Split(strCollumWidths, "<~>")
                        collumAligns = Split(strCollumAligns, "<~>")
                        collumFormats = Split(strCollumFormats, "<~>")
                        'objTemplate.Template = strHeader & "@@@@@" & strFooter
                        'objFields = objTemplate.Fields
                        Dim strContentTemp As String = strHeader & "@@@@@" & strFooter
                        objFields = objBCT.getArrayFromTemplate(strContentTemp)
                        ' Get PO and Vendor infor
                        objDItemOrder.HaveFields = ""
                        For inti = LBound(objFields) To UBound(objFields)
                            objDItemOrder.HaveFields &= objFields(inti) & ", "
                        Next
                        If objDItemOrder.HaveFields.Length > 2 Then
                            objDItemOrder.HaveFields = Left(objDItemOrder.HaveFields, objDItemOrder.HaveFields.Length - 2)
                        End If
                        tblVendor = objDItemOrder.GetPOandVendorInfor(intPOID)
                        ReDim objData(0)
                        If Not tblVendor Is Nothing Then
                            If tblVendor.Rows.Count > 0 Then
                                ReDim objMetric.objData(tblVendor.Rows.Count - 1)
                                ReDim objMetric.objEmail(tblVendor.Rows.Count - 1)
                                objMetric.objEmail(0) = tblVendor.Rows(0).Item("Email")
                                If Not IsNothing(objFields) AndAlso IsArray(objFields) Then
                                    ReDim objData(UBound(objFields))
                                    For inti = LBound(objFields) To UBound(objFields)
                                        Try
                                            Select Case UCase(objFields(inti))
                                                Case "TODAY"
                                                    objData(inti) = Now & Chr(9)
                                                Case "TODAY:YYYY"
                                                    objData(inti) = Now & Chr(9)
                                                Case "TODAY:MM"
                                                    objData(inti) = Month(Now) & Chr(9)
                                                Case "TODAY:DD"
                                                    objData(inti) = Day(Now) & Chr(9)
                                                Case "TODAY:HH"
                                                    objData(inti) = Hour(Now) & Chr(9)
                                                Case "TODAY:MI"
                                                    objData(inti) = Minute(Now) & Chr(9)
                                                Case "TODAY:SS"
                                                    objData(inti) = Second(Now) & Chr(9)
                                                Case "TITLE"
                                                    objData(inti) = objBCSP.ToUTF8(tblVendor.Rows(0).Item("CONTRACTNAME")) & Chr(9)
                                                Case "TODAY:UPPER"
                                                    'objData(inti) = objSort.Upper(objBCSP.ToUTF8(tblVendor.Rows(0).Item("CONTRACTNAME"))) & Chr(9)
                                                    objData(inti) = UCase(objBCSP.ToUTF8(tblVendor.Rows(0).Item("CONTRACTNAME"))) & Chr(9)
                                                Case Else
                                                    objData(inti) = objBCSP.ToUTF8(tblVendor.Rows(0).Item("" & objFields(inti) & "")) & Chr(9)
                                            End Select
                                            strContentTemp = Replace(strContentTemp, "<$" & objFields(inti) & "$>", objData(inti))
                                        Catch ex As Exception
                                            strErrorMsg = ex.Message
                                            objData(inti) = "" & Chr(9)
                                        End Try
                                    Next
                                End If

                                'strOutMsg = objTemplate.Generate(objData)
                                strOutMsg = strContentTemp
                                strHeader = objBCSP.ToUTF8Back(Left(strOutMsg, InStr(strOutMsg, "@@@@@") - 1))
                                strFooter = objBCSP.ToUTF8Back(Right(strOutMsg, Len(strOutMsg) - InStr(strOutMsg, "@@@@@") - 4))
                                strHeader = Replace(strHeader, "<~>", vbCrLf)
                                strFooter = Replace(strFooter, "<~>", vbCrLf)
                            End If
                        End If
                        strOutMsg = strPageHeader & strHeader
                        'If UBound(objData) > 0 Then
                        '    strOutMsg = strOutMsg & strHeader
                        'Else
                        '    strOutMsg = strOutMsg & objBCSP.ToUTF8Back(strHeader)
                        'End If
                        ' Gen data collum title
                        intk = 0
                        For intj = LBound(collums) To UBound(collums)
                            ReDim Preserve collumUserLabel(intk)
                            Try
                                Select Case collums(intj)
                                    Case ""
                                        collumUserLabel(intk) = ""
                                    Case Else
                                        If UBound(collumCaptions) >= intj Then
                                            If Not Trim(collumCaptions(intj)) = "" Then
                                                collumUserLabel(intk) = collumCaptions(intj)
                                            Else
                                                collumUserLabel(intk) = collecCollumTitle.Item("" & collums(intj) & "")
                                            End If
                                        Else
                                            collumUserLabel(intk) = collecCollumTitle.Item("" & collums(intj) & "")
                                        End If
                                        intk = intk + 1
                                End Select
                            Catch ex As Exception
                                collumUserLabel(intk) = ""
                                strErrorMsg = ex.Message
                            End Try
                        Next
                        objDItemOrder.HaveFields = GetListFields(strCollums, "<~>")
                        tblItems = objDItemOrder.GetSeperatedStoreItems(intTop, intPOID)
                        Dim arrTitles(), arrDisplays(), arrNames(), arrLocations() As String
                        Dim arrValue(), intLocCount, intTmpID As Integer
                        Dim arrItemCopies(), arrPrices() As Long
                        Dim dtrows(), dtrow As DataRow
                        intLocCount = 0
                        If Not tblItems Is Nothing Then
                            If tblItems.Rows.Count > 0 Then
                                ReDim arrTitles(tblItems.Rows.Count - 1)
                                ReDim arrDisplays(tblItems.Rows.Count - 1)
                                tblHolLibLoc = objDItemOrder.GetHolLibLoc(0, intPOID)
                                If Not tblHolLibLoc Is Nothing Then
                                    If tblHolLibLoc.Rows.Count > 0 Then
                                        intLocCount = tblHolLibLoc.Rows.Count
                                        'Lay mang chuc ten kho va khoi tao tong gia tri cho tung kho
                                        ReDim arrLocationsName(tblHolLibLoc.Rows.Count - 1)
                                        ReDim arrTotPricInLoc(tblHolLibLoc.Rows.Count - 1)
                                        ReDim arrTotRecInLoc(tblHolLibLoc.Rows.Count - 1)
                                        For inti = 0 To intLocCount - 1
                                            arrLocationsName(inti) = tblHolLibLoc.Rows(inti).Item("Symbol")
                                            arrTotPricInLoc(inti) = 0
                                            arrTotRecInLoc(inti) = 0
                                        Next

                                        ReDim arrValue(0)
                                        ReDim arrNames(0)
                                        arrNames(0) = tblHolLibLoc.Rows(0).Item("Code")
                                        arrValue(0) = 1
                                        intTmpID = CLng(tblHolLibLoc.Rows(0).Item("ID"))
                                        For inti = 1 To tblHolLibLoc.Rows.Count - 1
                                            If CLng(tblHolLibLoc.Rows(inti).Item("ID")) = intTmpID Then
                                                arrValue(UBound(arrValue)) = arrValue(UBound(arrValue)) + 1
                                            Else
                                                ReDim Preserve arrNames(UBound(arrNames) + 1)
                                                ReDim Preserve arrValue(UBound(arrValue) + 1)
                                                intTmpID = CLng(tblHolLibLoc.Rows(inti).Item("ID"))
                                                arrNames(UBound(arrNames)) = tblHolLibLoc.Rows(inti).Item("Code")
                                                arrValue(UBound(arrValue)) = 1
                                            End If
                                        Next
                                        ReDim arrLocations(tblHolLibLoc.Rows.Count - 1)
                                    End If
                                End If
                                strCurrency = objDItemOrder.GetAcqPO(intPOID).Rows(0).Item("Currency")
                                strOutMsg = strOutMsg & "<TABLE WIDTH=100% HEIGHT = 100% CELLSPACING=1 BORDER=1 CELLPADDING=1 CELLSPACING=1 CELLPADDING = 3>"
                                strOutMsg = strOutMsg & "<TR BGCOLOR=""FFFFFF"">"
                                For intj = LBound(collums) To UBound(collums)
                                    strmw = ""
                                    If UBound(collumWidths) >= intj Then
                                        If Not Trim(collumWidths(intj)) = "" Then
                                            strmw = " WIDTH=""" & Trim(collumWidths(intj)) & """"
                                        End If
                                    End If
                                    ' Collum align
                                    strma = " ALIGN=CENTER"
                                    If UBound(collumAligns) >= intj Then
                                        If Not Trim(collumAligns(intj)) = "" Then
                                            strma = " ALIGN=""" & Trim(collumAligns(intj)) & """"
                                        End If
                                    End If
                                    ' Collum format
                                    strmf = collumUserLabel(intj)
                                    If UBound(collumFormats) >= intj Then
                                        If Not Trim(collumFormats(intj)) = "" Then
                                            strmf = collumFormats(intj).Replace("<$DATA$>", collumUserLabel(intj))
                                        End If
                                    End If
                                    strOutMsg = strOutMsg & "<TH VALIGN=TOP" & strmw & strma & " ROWSPAN = 4>" & strmf & "</TH>"
                                Next
                                'strOutMsg = strOutMsg & "<TH BGCOLOR=""#E0E0E0"" ROWSPAN = 4>" & collecCollumTitle.Item("<$SLG$>") & "</TH>"
                                strOutMsg = strOutMsg & "<TH BGCOLOR=""#E0E0E0"" ROWSPAN = 4>" & collecCollumTitle.Item(21) & "</TH>"
                                'strOutMsg = strOutMsg & "<TH BGCOLOR=""#E0E0E0"" ROWSPAN = 4>" & collecCollumTitle.Item("<$SUMAMOUNT$>") & "<BR>(" & strCurrency & ")</TH>"
                                strOutMsg = strOutMsg & "<TH BGCOLOR=""#E0E0E0"" ROWSPAN = 4>" & collecCollumTitle.Item(19) & "<BR>(" & strCurrency & ")</TH>"
                                'strOutMsg = strOutMsg & "<TH BGCOLOR=""#E0E0E0"" ROWSPAN = 4>" & collecCollumTitle.Item("<$SUMAMOUNT$>") & "<BR>(" & strCurrency & ")</TH>"
                                If tblHolLibLoc.Rows.Count > 0 Then
                                    strOutMsg = strOutMsg & "<TH BGCOLOR=""#E0E0E0"" Colspan = " & 2 * tblHolLibLoc.Rows.Count & ">" & collecCollumTitle.Item("<$STORE$>") & "</TH>"
                                End If
                                'strOutMsg = strOutMsg & "<TH BGCOLOR=""#E0E0E0"" ROWSPAN = 4>" & collecCollumTitle.Item("<$SLG$>") & "</TH>"
                                strOutMsg = strOutMsg & "<TH BGCOLOR=""#E0E0E0"" ROWSPAN = 4>" & collecCollumTitle.Item("<$SUMAMOUNT$>") & "<BR>(" & strCurrency & ")</TH>"
                                strOutMsg = strOutMsg & "</TR>"
                                strOutMsg = strOutMsg & "<TR BGCOLOR=""FFFFFF"">"
                                If tblHolLibLoc.Rows.Count > 0 Then
                                    For intj = 0 To UBound(arrValue)
                                        strOutMsg = strOutMsg & "<TH BGCOLOR=""#E0E0E0"" Colspan = " & 2 * arrValue(intj) & ">" & arrNames(intj) & "</TH>"
                                    Next
                                End If
                                strOutMsg = strOutMsg & "</TR>"
                                strOutMsg = strOutMsg & "<TR BGCOLOR=""FFFFFF"">"
                                For inti = 0 To tblHolLibLoc.Rows.Count - 1
                                    strOutMsg = strOutMsg & "<TH BGCOLOR=""#E0E0E0"" Colspan = 2>" & tblHolLibLoc.Rows(inti).Item("Symbol") & "</TH>"
                                    arrLocations(inti) = tblHolLibLoc.Rows(inti).Item("Code") & ":" & tblHolLibLoc.Rows(inti).Item("Symbol")
                                Next
                                strOutMsg = strOutMsg & "</TR>"
                                strOutMsg = strOutMsg & "<TR BGCOLOR=""FFFFFF"">"
                                For inti = 0 To tblHolLibLoc.Rows.Count - 1
                                    strOutMsg = strOutMsg & "<TH VALIGN=TOP BGCOLOR=""#E0E0E0"">" & collecCollumTitle.Item("<$SLG$>") & "</TH>"
                                    strOutMsg = strOutMsg & "<TH VALIGN=TOP BGCOLOR=""#E0E0E0"">" & collecCollumTitle.Item("<$SUMAMOUNT$>") & "</TH>"
                                Next
                                strOutMsg = strOutMsg & "</TR>"
                                Dim intSumAmount, intSumItem, intTotal, intStoreTotal As Integer
                                Dim intSumVol As Long
                                Dim dblFixedRate, dblTotal, dblFixedRate1, dblFixedRate2, dblTotalUnitPrice, dblStoreTotal As Double
                                Dim tblFixedRate As New DataTable
                                Dim strTitle As String
                                Dim DivNum As Integer = 1
                                intSumVol = 0
                                intSumAmount = 0
                                intSumItem = 0
                                dblFixedRate = 1 ' Ty gia hach toan
                                dblTotal = 0
                                dblTotalUnitPrice = 0 ' Tong so tien trong ca hop dong
                                dblStoreTotal = 0
                                intStoreTotal = 0
                                Dim arrStoreTotal() As Integer      'Tong tien của tưng kho
                                Dim arrdblStoreTotal() As Integer
                                tblHolLibLoc = Nothing
                                tblHolLibLoc = objDItemOrder.GetHolLibLoc(1, intPOID)
                                objBCB.CurrencyCode = ""
                                tblFixedRate = objBCB.GetCurrency
                                For intj = 0 To tblItems.Rows.Count - 1
                                    If intj Mod 2 = 0 Then
                                        strChangeRowColor = strOddColor
                                    Else
                                        strChangeRowColor = strEventColor
                                    End If
                                    'Ty gia hoach toan
                                    Try
                                        If Not strCurrency = tblItems.Rows(intj).Item("Currency") Then
                                            If strCurrency = "VND" Then
                                                tblFixedRate.DefaultView.RowFilter = "CurrencyCode= '" & tblItems.Rows(intj).Item("Currency") & "'"
                                                If tblItems.Rows.Count > 0 Then
                                                    dblFixedRate = CDbl(tblFixedRate.Rows(0).Item("Rate"))
                                                Else
                                                    dblFixedRate = 1
                                                End If
                                            Else
                                                tblFixedRate.DefaultView.RowFilter = "CurrencyCode = '" & tblItems.Rows(intj).Item("Currency") & "'"
                                                If tblFixedRate.Rows.Count > 0 Then
                                                    dblFixedRate1 = CDbl(tblFixedRate.Rows(0).Item("Rate"))
                                                Else
                                                    dblFixedRate1 = 1
                                                End If
                                                tblFixedRate.DefaultView.RowFilter = 0
                                                tblFixedRate.DefaultView.RowFilter = "CurrencyCode = '" & tblItems.Rows(intj).Item("Currency") & "'"
                                                If tblFixedRate.Rows.Count > 0 Then
                                                    dblFixedRate2 = CDbl(tblFixedRate.Rows(0).Item("Rate"))
                                                Else
                                                    dblFixedRate2 = 1
                                                End If
                                                dblFixedRate = dblFixedRate1 / dblFixedRate2
                                            End If
                                        Else
                                            dblFixedRate = 1
                                        End If
                                    Catch ex As Exception
                                        strErrorMsg = ex.Message
                                    End Try
                                    ' Get title 
                                    arrTitles(intj) = tblItems.Rows(intj).Item("Title")
                                    arrDisplays(intj) = "<TR BGCOLOR=" & strChangeRowColor & ">"
                                    For inti = LBound(collums) To UBound(collums)
                                        ' Collum width
                                        strmw = ""
                                        If UBound(collumWidths) >= inti Then
                                            If Not Trim(collumWidths(inti)) = "" Then
                                                strmw = " WIDTH=""" & Trim(collumWidths(inti)) & """"
                                            End If
                                        End If
                                        ' Collum Align
                                        strma = " ALIGN=LEFT "
                                        If UBound(collumAligns) >= inti Then
                                            If Not Trim(collumAligns(inti)) = "" Then
                                                strma = " ALIGN=""" & Trim(collumAligns(inti)) & """"
                                            End If
                                        End If
                                        ' Collum Format
                                        strmf = ""
                                        If UBound(collumFormats) >= inti Then
                                            If Not Trim(collumFormats(inti)) = "" Then
                                                strmf = Trim(collumFormats(inti))
                                            End If
                                        End If
                                        Try
                                            Select Case collums(inti)
                                                Case "<$SEQUENCY$>"
                                                    If Not strmf = "" Then
                                                        arrDisplays(intj) = arrDisplays(intj) & "<TD VALIGN=TOP " & strmw & strma & ">" & collumFormats(inti).Replace("<$DATA$>", intj + 1) & "</TD>"
                                                    Else
                                                        arrDisplays(intj) = arrDisplays(intj) & "<TD VALIGN=TOP " & strmw & strma & ">" & intj + 1 & "</TD>"
                                                    End If
                                                Case "<$TITLE$>"
                                                    If Not IsDBNull(tblItems.Rows(intj).Item("Title")) Then
                                                        If Len(tblItems.Rows(intj).Item("Title")) > 20 Then
                                                            tblItems.Rows(intj).Item("Title") = Left(tblItems.Rows(intj).Item("Title"), 17)
                                                            tblItems.Rows(intj).Item("Title") = Left(tblItems.Rows(intj).Item("Title"), InStrRev(tblItems.Rows(intj).Item("Title"), " ") - 1) & " ..."

                                                        End If
                                                    End If
                                                    If Not strmf = "" Then
                                                        arrDisplays(intj) = arrDisplays(intj) & "<TD VALIGN=TOP " & strmw & strma & ">" & collumFormats(inti).Replace("<$DATA$>", tblItems.Rows(intj).Item("Title")) & "</TD>"
                                                    Else
                                                        arrDisplays(intj) = arrDisplays(intj) & "<TD VALIGN=TOP " & strmw & strma & ">" & tblItems.Rows(intj).Item("Title") & "</TD>"
                                                    End If
                                                Case "<$UNITPRICE$>"
                                                    Dim strUnitPrice As String
                                                    If Not tblItems.Rows(intj).Item("Currency") = objBCSP.ConvertItBack(strCurrency) Then
                                                        strUnitPrice = tblItems.Rows(intj).Item("UnitPrice") & " " & tblItems.Rows(intj).Item("Currency")
                                                    Else
                                                        strUnitPrice = tblItems.Rows(intj).Item("UnitPrice") & " " & strCurrency
                                                    End If
                                                    If Not IsDBNull(tblItems.Rows(intj).Item("UnitPrice")) Then
                                                        If IsNumeric(tblItems.Rows(intj).Item("UnitPrice")) Then
                                                            dblTotalUnitPrice = dblTotalUnitPrice + CDbl(tblItems.Rows(intj).Item("UnitPrice"))
                                                        End If

                                                    End If
                                                    If Not strmf = "" Then
                                                        arrDisplays(intj) = arrDisplays(intj) & "<TD VALIGN=TOP " & strmw & strma & ">" & collumFormats(inti).Replace("<$DATA$>", strUnitPrice) & "</TD>"
                                                    Else
                                                        arrDisplays(intj) = arrDisplays(intj) & "<TD VALIGN=TOP " & strmw & strma & ">" & strUnitPrice & "</TD>"
                                                    End If
                                                Case Else
                                                    strItem = Replace(Replace(collums(inti), "<$", ""), "$>", "")
                                                    If Not strmf = "" Then
                                                        arrDisplays(intj) = arrDisplays(intj) & "<TD VALIGN=TOP " & strmw & strma & ">" & collumFormats(inti).Replace("<$DATA$>", tblItems.Rows(intj).Item(strItem)) & "</TD>"
                                                    Else
                                                        arrDisplays(intj) = arrDisplays(intj) & "<TD VALIGN=TOP " & strmw & strma & ">" & tblItems.Rows(intj).Item(strItem) & "</TD>"
                                                    End If
                                            End Select
                                        Catch ex As Exception
                                            strErrorMsg = ex.Message
                                            arrDisplays(intj) = arrDisplays(intj) & "<TD VALIGN=TOP " & strmw & strma & ">" & "</TD>"
                                        End Try
                                    Next ' collums
                                    arrDisplays(intj) = arrDisplays(intj) & "<TD ALIGN=RIGHT>" & tblItems.Rows(intj).Item("ReceivedCopies") & "</TD>"
                                    If Not IsDBNull(tblItems.Rows(intj).Item("ReceivedCopies")) Then
                                        If tblItems.Rows(intj).Item("ReceivedCopies") > 0 Then
                                            intSumVol = intSumVol + CLng(tblItems.Rows(intj).Item("ReceivedCopies"))
                                        End If
                                    End If
                                    arrDisplays(intj) = arrDisplays(intj) & "<TD ALIGN=RIGHT>" & Round(CDbl(tblItems.Rows(intj).Item("UnitPrice")) * dblFixedRate / DivNum, 3) & "</TD>"
                                    Dim dblAmount As Double
                                    If tblItems.Rows(intj).Item("ReceivedCopies") > 0 Then
                                        dblAmount = CLng(tblItems.Rows(intj).Item("ReceivedCopies")) * CDbl(tblItems.Rows(intj).Item("UnitPrice")) * dblFixedRate
                                        intSumAmount = intSumAmount + dblAmount
                                    Else
                                        dblAmount = 0
                                    End If
                                    'arrDisplays(intj) = arrDisplays(intj) & "<TD ALIGN=RIGHT>" & Round(dblAmount / DivNum, 3) & "</TD>"
                                    ' Phan Kho
                                    Dim mTotal As Double
                                    Dim strLib, strStore As String
                                    mTotal = 0
                                    If Not IsDBNull(tblItems.Rows(0).Item("ItemID")) AndAlso tblItems.Rows(0).Item("ItemID") > 0 Then
                                        For intk = 0 To intLocCount - 1
                                            strLib = Left(arrLocations(intk), InStr(arrLocations(intk), ":") - 1)
                                            strStore = Right(arrLocations(intk), Len(arrLocations(intk)) - InStr(arrLocations(intk), ":"))
                                            tblHolLibLoc.DefaultView.RowFilter = "ItemID = " & tblItems.Rows(intj).Item("ItemID") & " AND Symbol = '" & strStore & "' AND Code = '" & strLib & "'"
                                            If tblHolLibLoc.DefaultView.Count > 0 Then
                                                ReDim Preserve arrItemCopies(intk)
                                                ReDim Preserve arrPrices(intk)
                                                ReDim Preserve arrStoreTotal(intk)
                                                ReDim Preserve arrdblStoreTotal(intk)
                                                arrItemCopies(intk) = arrItemCopies(intk) + CLng(tblHolLibLoc.Rows(intk).Item("ItemPerLoc"))
                                                dblAmount = CLng(tblHolLibLoc.Rows(intk).Item("ItemPerLoc")) * CDbl(tblItems.Rows(intj).Item("UnitPrice")) * dblFixedRate
                                                arrPrices(intk) = arrPrices(intk) + dblAmount
                                                mTotal = mTotal + dblAmount
                                                'intStoreTotal = intStoreTotal + tblHolLibLoc.Rows(0).Item("ItemPerLoc")
                                                '-
                                                arrStoreTotal(intk) = arrStoreTotal(intk) + tblHolLibLoc.Rows(intk).Item("ItemPerLoc")
                                                If arrLocationsName(intk) = strStore Then
                                                    arrTotPricInLoc(intk) = arrTotPricInLoc(intk) + dblAmount
                                                    arrTotRecInLoc(intk) = arrTotRecInLoc(intk) + tblHolLibLoc.Rows(intk).Item("ItemPerLoc")
                                                End If

                                                'dblStoreTotal = dblStoreTotal + Round(dblAmount / DivNum, 3)
                                                '-
                                                arrdblStoreTotal(intk) = arrdblStoreTotal(intk) + Round(dblAmount / DivNum, 3)

                                                arrDisplays(intj) = arrDisplays(intj) & "<TD ALIGN=RIGHT>" & tblHolLibLoc.Rows(intk).Item("ItemPerLoc") & "</TD>"
                                                arrDisplays(intj) = arrDisplays(intj) & "<TD ALIGN=RIGHT>" & "&nbsp;" & Round(dblAmount / DivNum, 3) & "</TD>"
                                            Else
                                                arrDisplays(intj) = arrDisplays(intj) & "<TD>&nbsp;</TD>"
                                                arrDisplays(intj) = arrDisplays(intj) & "<TD>&nbsp;</TD>"
                                            End If
                                        Next
                                    Else
                                        For intk = 0 To intLocCount - 1
                                            arrDisplays(intj) = arrDisplays(intj) & "<TD>&nbsp;</TD>"
                                            arrDisplays(intj) = arrDisplays(intj) & "<TD>&nbsp;</TD>"
                                        Next
                                    End If
                                    dblTotal = dblTotal + mTotal
                                    arrDisplays(intj) = arrDisplays(intj) & "<TD ALIGN=RIGHT>" & Round(mTotal / DivNum, 3) & "</TD>"
                                Next
                                ' co the phat sinh loi o day, can kiem tra
                                ' objSort.SortBy(arrTitles, arrDisplays, 1)
                                Dim intz As Integer
                                intz = 1
                                For intj = LBound(arrDisplays) To UBound(arrDisplays)
                                    strOutMsg = strOutMsg & arrDisplays(intj)
                                    '    intz = intz + 1
                                Next
                                strOutMsg = strOutMsg & "</TR><TR BGCOLOR=" & strChangeRowColor & ">"
                                strOutMsg = strOutMsg & "<TD ALIGN = RIGHT Colspan =" & UBound(collums) + 1 & " ><B>" & collecCollumTitle.Item("<$SUMLABEL$>") & "</B></TD>"
                                strOutMsg = strOutMsg & "<TD ALIGN=RIGHT><B>" & intSumVol & "</B></TD>"
                                strOutMsg = strOutMsg & "<TD ALIGN = RIGHT><B>" & dblTotalUnitPrice & "</B></TD>"

                                'strOutMsg = strOutMsg & "<TD ALIGN = RIGHT><B>" & Round(intSumAmount / DivNum, 3) & "</B></TD>"
                                Dim intSum As Integer
                                Dim dblTT As Double
                                intSum = 0
                                dblTT = 0
                                For intj = 0 To intLocCount - 1
                                    'strOutMsg = strOutMsg & "<TD ALIGN = RIGHT><B>" & intStoreTotal & "</B></TD>"
                                    'strOutMsg = strOutMsg & "<TD ALIGN = RIGHT><B>" & dblStoreTotal & "</B></TD>"
                                    strOutMsg = strOutMsg & "<TD ALIGN = RIGHT><B>" & arrTotRecInLoc(intj) & "</B></TD>"
                                    strOutMsg = strOutMsg & "<TD ALIGN = RIGHT><B>" & arrTotPricInLoc(intj) & "</B></TD>"
                                    'strOutMsg = strOutMsg & "<TD ALIGN = RIGHT><B>" & arrdblStoreTotal(intj) & "</B></TD>"
                                Next
                                strOutMsg = strOutMsg & "<TD ALIGN = RIGHT><B>" & Round(dblTotal / DivNum, 3) & "</B></TD>"
                                strOutMsg = strOutMsg & "</TR> </TABLE>"
                                strOutMsg = strOutMsg & strFooter & strPageFooter
                            End If ' tblItems
                        End If
                    End If ' TemplateID
                End If
                objMetric.objData(0) = strOutMsg
                GenSeparetedStore = objMetric
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                'If Not objTemplate Is Nothing Then
                '    objTemplate = Nothing
                'End If
                'If Not objSort Is Nothing Then
                '    objSort = Nothing
                'End If
            End Try
        End Function
        ' Purpose: Get some special fields in Template
        ' Input: strContent, strSplit
        ' Output: string
        ' Creator: Sondp
        Private Function GetListFields(ByVal strContent As String, ByVal strSplit As String) As String
            Dim objFieldItems As New Object
            Dim strFieldReturn As String
            Dim inti As Integer
            objFieldItems = Nothing
            strFieldReturn = ""
            objFieldItems = Split(strContent, strSplit)
            If IsArray(objFieldItems) Then
                If UBound(objFieldItems) > 0 Then
                    For inti = LBound(objFieldItems) To UBound(objFieldItems)
                        strFieldReturn &= objFieldItems(inti)
                    Next
                End If
            End If
            GetListFields = strFieldReturn
        End Function

        ' Purpose: Save to file
        ' Input: strContent, strExtendsion, isHTML
        ' Output: Physical path to file
        ' Creator: Sondp
        Public Function SaveToFile(ByVal strContent As String, ByVal strExtendsion As String, ByVal isHTML As Boolean, Optional ByVal strServerPath As String = "") As String
            Dim intTTL As Integer = 24
            Dim arrValue(0), arrName(0) As String
            Dim tblTempFile As DataTable
            Dim strContentType, strFileLocation, strFileName, strCondition As String
            Dim objFile As File
            Dim objSw As StreamWriter
            ' Dim objDoc2html As New DOC2HTMLLib.Converter
            Dim inti As Integer
            Dim strPathfile As String = "\Acquisition\TempFiles\"

            arrName(0) = "TEMPFILE_TTL"
            Try
                tblTempFile = objBCDBS.GetTempFilePath(4)
                If Not tblTempFile Is Nothing AndAlso tblTempFile.Rows.Count > 0 Then
                    strPathfile = tblTempFile.Rows(0).Item("TempFilePath")
                    If Right(strPathfile, 1) <> "\" AndAlso Right(strPathfile, 1) <> "/" Then
                        strPathfile = strPathfile & "\"
                    End If
                End If

                arrValue = objBCDBS.GetSystemParameters(arrName)
                If IsArray(arrValue) Then
                    ' get path tempfile
                    If Not IsDBNull(arrValue(0)) And IsNumeric(arrValue(0)) Then
                        intTTL = arrValue(0)
                    End If
                    ' delete file 
                    If Not strDBServer = "ORACLE" Then
                        strCondition = " WHERE DATEDIFF(HOUR, CreatedDate, GetDate()) > " & CStr(intTTL)
                    Else
                        strCondition = " WHERE (SYSDATE - CreatedDate)*24 > " & CStr(intTTL)
                    End If
                    objBCDBS.Condition = strCondition
                    tblTempFile = objBCDBS.GetSysDownloadFile
                    If Not tblTempFile Is Nothing AndAlso tblTempFile.Rows.Count > 0 Then
                        For inti = 0 To tblTempFile.Rows.Count - 1
                            strFileName = tblTempFile.Rows(inti).Item("FileName")
                            strFileLocation = strServerPath & strPathfile & strFileName
                            If objFile.Exists(strFileLocation) Then
                                objFile.Delete(strFileLocation)
                            End If
                        Next
                        objBCDBS.Condition = strCondition
                        objBCDBS.DeleteSysDownloadFile()
                    End If
                    ' start generate random file
                    objBCDBS.Extension = strExtendsion
                    strFileName = objBCDBS.GenRandomFile
                    strFileName = Left(strFileName, InStr(strFileName, ".") - 1)
                    ' Write file
                    strContentType = "<META HTTP-EQUIV=" & "Content-Type"" CONTENT=" & "text/html; charset=utf-8" & ">"
                    SaveToFile = SaveFileAspose(strFileName, "<HTML><HEAD>" & strContentType & "<TITLE> LIBOL " & "</TITLE></HEAD>" & "<BODY>" & strContent & "</BODY></HTML>", strServerPath)
                    'If isHTML = True Then
                    '    objSw = File.CreateText(strServerPath & strPathfile & strFileName & ".htm")
                    'Else
                    '    objSw = File.CreateText(strServerPath & strPathfile & strFileName & ".doc")
                    'End If
                    'objSw.WriteLine("<HTML><HEAD>" & strContentType & "<TITLE> LIBOL " & "</TITLE></HEAD>")
                    'objSw.WriteLine("<BODY>" & strContent & "</BODY></HTML>")
                    'objSw.Close()
                    'objDoc2html.HtmlToDocFile(strServerPath & strPathfile & strFileName & ".htm", strServerPath & strPathfile & strFileName & ".doc", 1)
                    ' intErrorCode = objDoc2html.ErrorCode
                    'If intErrorCode <> 0 Then
                    '    strErrorMsg = objDoc2html.ErrorMessage
                    'End If
                End If

            Catch ex As Exception
                strErrorMsg = ex.Message
                SaveToFile = ex.Message
            Finally

            End Try
        End Function


        '  Save data to file .htm and convert to .doc
        Public Function SaveFileAspose(ByVal strFileName As String, ByVal strContent As String, Optional ByVal strServerRootPath As String = "") As String
            Try
                Dim strPath, strPathHtm, strPathDoc As String

                strFileName &= Format(Now, "yyyyMMddhhmmssfff") & ".doc"
                If Not strServerRootPath.EndsWith("\") Then
                    strServerRootPath = strServerRootPath + "\"
                End If
                Dim licenseFile As String = Path.Combine(strServerRootPath, "bin\Aspose.Words.lic")
                If (File.Exists(licenseFile)) Then
                    Dim license As Aspose.Words.License = New Aspose.Words.License()
                    license.SetLicense(licenseFile)
                    Dim strDocFile As String = strServerRootPath & "Template\documentList.doc"
                    Dim doc As Aspose.Words.Document = New Aspose.Words.Document(strDocFile)
                    Dim builder As DocumentBuilder = New DocumentBuilder(doc)
                    builder.MoveToMergeField("HTMLValue")

                    builder.InsertHtml("<span style='font-size:10pt; font-family:Arial;text-align:justify;'>" & strContent & "</span>")
                    Dim strFile As String = ""
                    strFile = strServerRootPath & "Acquisition\TempFiles\" & strFileName
                    doc.Save(strFile, Aspose.Words.SaveFormat.Doc)

                    If Not IsNothing(doc) Then
                        doc = Nothing
                        SaveFileAspose = strFileName
                    End If
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function


        ' Purpose: Get list of waitting PO
        ' Output: Datatable result
        ' Creator:  Sondp
        Public Function GetWaittingPO() As DataTable
            Dim inti As Integer
            Dim tblWaittingPO As New DataTable

            Try
                objDItemOrder.LibID = intLibID
                tblWaittingPO = objBCDBS.ConvertTable(objDItemOrder.GetWaittingPO)
                strErrorMsg = objDItemOrder.ErrorMsg
                intErrorCode = objDItemOrder.ErrorCode
                If Not tblWaittingPO Is Nothing Then
                    If tblWaittingPO.Rows.Count > 0 Then
                        For inti = 0 To tblWaittingPO.Rows.Count - 1
                            ' Bind URL to view information detail if user lick on this URL
                            tblWaittingPO.Rows(inti).Item("URL") = "<A HREF='WContractDetail.aspx?ContractID=" & tblWaittingPO.Rows(inti).Item("ID") & "&Type=" & tblWaittingPO.Rows(inti).Item("POType") & "'><B>" & tblWaittingPO.Rows(inti).Item("ReceiptNo") & "</B></A>" & ": " & tblWaittingPO.Rows(inti).Item("POName")
                        Next
                    End If
                End If
                GetWaittingPO = tblWaittingPO
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                tblWaittingPO = Nothing
            End Try
        End Function

        ' Purpose: Get Acq status
        ' Input: 
        ' Output: Datatable
        ' Creator: Sondp
        Public Function GetAcqStatus() As DataTable
            Try
                GetAcqStatus = objBCDBS.ConvertTable(objDItemOrder.GetAcqStatus)
                strErrorMsg = objDItemOrder.ErrorMsg
                intErrorCode = objDItemOrder.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose: Insert one record into Acq_tblPo_Status table
        ' Input: Some infor
        ' Creator: Sondp
        ' CreatedDate: 07/04/2005
        Public Sub InsertAcqPoStatus()
            Try
                If Trim(strSetDate) = "" Then
                    strSetDate = Day(Now) & "/" & Month(Now) & "/" & Year(Now)
                End If
                objDItemOrder.SetDate = Trim(objBCDBS.ConvertDateBack(strSetDate))
                objDItemOrder.POID = intPOID
                objDItemOrder.StatusID = intStatusID
                objDItemOrder.Note = Trim(strNote)
                Call objDItemOrder.InsertAcqPoStatus()
                strErrorMsg = objDItemOrder.ErrorMsg
                intErrorCode = objDItemOrder.ErrorCode
            Catch Exp As Exception
                strErrorMsg = Exp.Message.ToString
            End Try
        End Sub

        Public Sub SetItemID4AcqItem(ByVal intItemID As Integer, ByVal intACQID As Integer)
            Try
                Call objDItemOrder.SetItemID4AcqItem(intItemID, intACQID)
                strErrorMsg = objDItemOrder.ErrorMsg
                intErrorCode = objDItemOrder.ErrorCode
            Catch Exp As Exception
                strErrorMsg = Exp.Message.ToString
            End Try
        End Sub

        ' ****************************************************************************
        ' Serial
        ' ****************************************************************************

        ' Method: GetSerialRequestList
        ' Purpose: get list of acqire requests
        ' Output: datatable result
        Public Function GetSerialRequestList(ByVal intType As Integer) As DataTable
            Try
                GetSerialRequestList = objBCDBS.ConvertTable(objDItemOrder.GetSerialRequestList(intType))
                intErrorCode = objDItemOrder.ErrorCode
                strErrorMsg = objDItemOrder.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Release resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                End If
                If Not objDItemOrder Is Nothing Then
                    objDItemOrder.Dispose(True)
                    objDItemOrder = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBT Is Nothing Then
                    objBT.Dispose(True)
                    objBT = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBVendor Is Nothing Then
                    objBVendor.Dispose(True)
                    objBVendor = Nothing
                End If
                If Not objBCT Is Nothing Then
                    objBCT.Dispose(True)
                    objBCT = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace