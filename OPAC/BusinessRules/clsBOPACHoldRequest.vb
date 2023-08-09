Imports System
Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibOPAC.DataAccess.OPAC

Namespace eMicLibOPAC.BusinessRules.OPAC
    Public Class clsBOPACHoldRequest
        Inherits clsBBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private strCardNo As String
        Private strPassword As String
        Private strCopyNumber As String
        Private strValidDateReq As String
        Private intItemID As Integer

        Private objDHoldReq As New clsDOPACHoldRequest
        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************

        'ItemID property
        Public Property ItemID() As Integer
            Get
                Return intItemID
            End Get
            Set(ByVal Value As Integer)
                intItemID = Value
            End Set
        End Property
        ' CardNo property
        Public Property CardNo() As String
            Get
                Return strCardNo
            End Get
            Set(ByVal Value As String)
                strCardNo = Value
            End Set
        End Property

        ' Password property
        Public Property Password() As String
            Get
                Return strPassword
            End Get
            Set(ByVal Value As String)
                strPassword = Value
            End Set
        End Property

        ' CopyNumber property
        Public Property CopyNumber() As String
            Get
                Return strCopyNumber
            End Get
            Set(ByVal Value As String)
                strCopyNumber = Value
            End Set
        End Property

        ' ValidDateReq Property
        Public Property ValidDateReq() As String
            Get
                Return strValidDateReq
            End Get
            Set(ByVal Value As String)
                strValidDateReq = Value
            End Set
        End Property
        ' ***********************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' ***********************************************************************************************
        ' Initialize method
        Public Sub Initialize()
            ' Init objDHoldReq object
            objDHoldReq.DBServer = strDBServer
            objDHoldReq.ConnectionString = strConnectionString
            objDHoldReq.Initialize()

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

        ' Purpose: Create Reservation Request
        ' Input: @intItemID,@strCardNo,@strPassWord,@strValidDate,@strCopyNumber
        ' Output: Byte
        ' 0-successfull
        ' 1-Patron is not Exists
        ' 2-Patron card is expired
        ' 3-Patron already request this item
        ' 4-Patron already has a copy on loan
        ' 5-No copy is in patron's accessible locations
        ' Created by: dgsoft
        Public Function CreateReserv() As Byte
            objDHoldReq.CardNo = objBCSP.ConvertItBack(strCardNo)
            objDHoldReq.Password = objBCSP.ConvertItBack(strPassword)
            objDHoldReq.ItemID = intItemID
            objDHoldReq.CopyNumber = objBCSP.ConvertItBack(strCopyNumber)
            objDHoldReq.ValidDateReq = objBCDBS.ConvertDateBack(strValidDateReq)
            Try
                CreateReserv = objDHoldReq.CreateReserv
                intErrorCode = objDHoldReq.ErrorCode
                strErrorMsg = objDHoldReq.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function
        Public Function CreateReserv_Report() As Byte
            objDHoldReq.CardNo = objBCSP.ConvertItBack(strCardNo)
            objDHoldReq.Password = objBCSP.ConvertItBack(strPassword)
            objDHoldReq.ItemID = intItemID
            objDHoldReq.CopyNumber = objBCSP.ConvertItBack(strCopyNumber)
            objDHoldReq.ValidDateReq = objBCDBS.ConvertDateBack(strValidDateReq)
            Try
                CreateReserv_Report = objDHoldReq.CreateReserv_Report()
                intErrorCode = objDHoldReq.ErrorCode
                strErrorMsg = objDHoldReq.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose: Create Holding Request
        ' Input: @intItemID,@strCardNo,@strPassWord,@strValidDate,@strCopyNumber
        ' output: Byte
        ' 0-successfull
        ' 1-Patron is not Exists
        ' 2-Patron card is expired
        ' 3-Patron already request this item
        ' 4-Over Loan
        ' 5-Over Holding
        ' 6- Copynumber is invalid
        ' Created by: dgsoft
        Public Function CreateHolding() As Byte
            objDHoldReq.CardNo = objBCSP.ConvertItBack(strCardNo)
            objDHoldReq.Password = objBCSP.ConvertItBack(strPassword)
            objDHoldReq.ItemID = intItemID
            objDHoldReq.CopyNumber = objBCSP.ConvertItBack(strCopyNumber)
            objDHoldReq.ValidDateReq = objBCDBS.ConvertDateBack(strValidDateReq)
            Try
                Return objDHoldReq.CreateHold
                'Catch ex As Exception
                '    intErrorCode = objDHoldReq.ErrorCode
                '    strErrorMsg = objDHoldReq.ErrorMsg
            Finally

            End Try
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                End If
                If Not objDHoldReq Is Nothing Then
                    Call objDHoldReq.Dispose(True)
                    objDHoldReq = Nothing
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