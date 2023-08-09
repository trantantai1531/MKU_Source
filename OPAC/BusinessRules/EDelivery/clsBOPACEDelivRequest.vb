Imports eMicLibOPAC.BusinessRules
Imports eMicLibOPAC.BusinessRules.OPAC
Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibOPAC.DataAccess
Imports eMicLibOPAC.DataAccess.OPAC

Namespace eMicLibOPAC.BusinessRules.OPAC
    Public Class clsBOPACEDelivRequest
        Inherits clsBBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private objDEDeReq As New clsDOPACEDelivRequest
        Private objBSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem

        Private lngItemID As Long
        Private strItemIDs As String
        Private intModeID As Integer = 0
        Private strExpireDate As String = ""
        Private lngEDelivUserID As Long = 0
        Private lngFileID As Long = 0
        Private strCurrency As String = ""
        Private dblAmount As Double = 0
        Private dblDebt As Double = 0
        Private strNote As String = ""
        Private dblRate As Double = 0
        Private lngRequestGroupID As Long = 0

        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************

        ' ItemID property
        Public Property ItemID() As Long
            Get
                Return lngItemID
            End Get
            Set(ByVal Value As Long)
                lngItemID = Value
            End Set
        End Property

        ' ItemIDs property 
        Public Property ItemIDs() As String
            Get
                Return strItemIDs
            End Get
            Set(ByVal Value As String)
                strItemIDs = Value
            End Set
        End Property

        ' ModeID property
        ' Mode receive E-Delivery
        Public Property ModeID() As Integer
            Get
                Return intModeID
            End Get
            Set(ByVal Value As Integer)
                intModeID = Value
            End Set
        End Property

        ' EDelivUserID property
        Public Property EDelivUserID() As Long
            Get
                Return lngEDelivUserID
            End Get
            Set(ByVal Value As Long)
                lngEDelivUserID = Value
            End Set
        End Property

        ' FileID property
        Public Property FileID() As Long
            Get
                Return lngFileID
            End Get
            Set(ByVal Value As Long)
                lngFileID = Value
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

        ' Amount property
        Public Property Amount() As Double
            Get
                Return dblAmount
            End Get
            Set(ByVal Value As Double)
                dblAmount = Value
            End Set
        End Property

        ' Debt property
        Public Property Debt() As Double
            Get
                Return dblDebt
            End Get
            Set(ByVal Value As Double)
                dblDebt = Value
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

        ' Rate property
        Public Property Rate() As Double
            Get
                Return dblRate
            End Get
            Set(ByVal Value As Double)
                dblRate = Value
            End Set
        End Property

        ' RequestGroupID property
        Public Property RequestGroupID() As Long
            Get
                Return lngRequestGroupID
            End Get
            Set(ByVal Value As Long)
                lngRequestGroupID = Value
            End Set
        End Property

        ' ExpireDate property 
        Public Property ExpireDate() As String
            Get
                Return strExpireDate
            End Get
            Set(ByVal Value As String)
                strExpireDate = Value
            End Set
        End Property

        ' purpose : Create one E-Delivery Request
        ' Created by: dgsoft
        Public Sub CreateRequest()
            Try
                objDEDeReq.ExpireDate = objBCDBS.ConvertDateBack(strExpireDate)
                objDEDeReq.EDelivUserID = lngEDelivUserID
                objDEDeReq.FileID = lngFileID
                objDEDeReq.ModeID = intModeID
                objDEDeReq.Currency = strCurrency
                objDEDeReq.Amount = dblAmount
                objDEDeReq.Note = objBSP.ConvertItBack(strNote)
                objDEDeReq.Rate = dblRate
                objDEDeReq.RequestGroupID = lngRequestGroupID
                objDEDeReq.CreateRequest()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' purpose : Update EDELIV_DEBT of an e-delevery user
        Public Sub UpdateUserDebt()
            Try
                objDEDeReq.Debt = dblDebt
                objDEDeReq.UpdateUserDebt()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub


        ' Initialize method
        Public Sub Initialize()
            ' Init objBCSP object
            objBSP.DBServer = strDBServer
            objBSP.ConnectionString = strConnectionString
            objBSP.InterfaceLanguage = strInterfaceLanguage
            objBSP.Initialize()

            ' Init objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.Initialize()

            ' Init objDAcqPurchaseOrder object
            objDEDeReq.DBServer = strDBServer
            objDEDeReq.ConnectionString = strConnectionString
            objDEDeReq.Initialize()
        End Sub


        ' purpose : Create new E-Delivery account
        ' Created by: dgsoft
        Public Sub CreateAccount()

        End Sub

        ' purpose : Read information of E-Delivery account
        ' Created by: dgsoft
        Public Function GetAccount() As DataTable

        End Function

        ' GetEDelivInfor function
        ' purpose: Get the e delevery item infor that user selected
        Public Function GetEDelivInfor() As DataTable
            Try
                objDEDeReq.ItemIDs = strItemIDs
                GetEDelivInfor = objBCDBS.ConvertTable(objDEDeReq.GetEDelivInfor(), "Title")
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetNewRequestgroupID function
        Public Function GetNewRequestgroupID() As Long
            Try
                GetNewRequestgroupID = objDEDeReq.GetNewRequestgroupID
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetEDelivInforByRequest function
        ' purpose: Get the e delevery item infor by the user request
        Public Function GetEDelivInforByRequest(ByRef dblTotal As Double) As DataTable
            Try
                objDEDeReq.RequestGroupID = lngRequestGroupID
                GetEDelivInforByRequest = objBCDBS.ConvertTable(objDEDeReq.GetEDelivInforByRequest(dblTotal), "Title")
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetRequestGroup fucntion
        ' Purpose: Get the distinct request group
        Public Function GetRequestGroup(ByVal strRequestGroupID As String, ByVal strCreatedDate As String) As DataTable
            Try
                objDEDeReq.EDelivUserID = lngEDelivUserID
                strRequestGroupID = objBSP.ConvertItBack(strRequestGroupID)
                strCreatedDate = objBSP.ConvertItBack(strCreatedDate)
                GetRequestGroup = objBCDBS.ConvertTable(objDEDeReq.GetRequestGroup(strRequestGroupID, strCreatedDate))
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetRequestGroupCount function
        ' Purpose: Get the number of distinct request groups of an user
        Public Function GetRequestGroupCount() As Integer
            Try
                objDEDeReq.EDelivUserID = lngEDelivUserID
                GetRequestGroupCount = objDEDeReq.GetRequestGroupCount
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' CheckEdelivUser method
        ' Purpose: Check the username and password of edeliv user
        Public Function CheckEdelivUser(ByVal strUserName As String, ByVal strPassword As String) As DataTable
            Try
                CheckEdelivUser = objBCDBS.ConvertTable(objDEDeReq.CheckEdelivUser(objBSP.ConvertItBack(strUserName), objBSP.ConvertItBack(strPassword)))
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' CheckEdelivUserDownload method
        ' Purpose: Check the username and password of edeliv user
        Public Function CheckEdelivUserDownload(ByVal intUserID As Integer, ByVal intFileID As Integer) As DataTable
            Try
                CheckEdelivUserDownload = objBCDBS.ConvertTable(objDEDeReq.CheckEdelivUserDownload(intUserID, intFileID))
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' CancelPendingERequest method
        ' Purpose: Change the status of request to Cancel pending
        Public Sub CancelPendingERequest(ByVal lngRequestID As Long)
            Try
                objDEDeReq.CancelPendingERequest(lngRequestID)
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBSP Is Nothing Then
                    objBSP.Dispose(True)
                    objBSP = Nothing
                End If
                If Not objDEDeReq Is Nothing Then
                    objDEDeReq.Dispose(True)
                    objDEDeReq = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

    End Class
End Namespace