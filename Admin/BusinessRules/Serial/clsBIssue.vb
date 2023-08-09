' Class: clsBBinding
' Purpose: Management issue
' Creator: Oanhtn
' Created Date: 20/09/2004
' Modification History:

Imports System
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Serial

Namespace eMicLibAdmin.BusinessRules.Serial
    Public Class clsBIssue
        Inherits clsBBase

        ' *******************************************************************************************************
        ' Declare Private variables
        ' *******************************************************************************************************

        Private strPhysDetail As String = ""
        Private dblPrice As Double = 0
        Private strIssuedDate As String = ""
        Private strIssueNo As String = ""
        Private strOvIssueNo As String = ""
        Private strVolume As String = ""
        Private strSpecialTitle As String = ""
        Private strSummary As String = ""
        Private intSubscribedCopies As Int16 = 0
        Private intToBindery As Int16 = 0
        Private strNote As String = ""
        Private lngItemID As Long = 0
        Private lngIssueID As Long = 0
        Private intFirstIssueInYear As Int16 = 0
        Private intResetRegularity As Int16 = 1
        Private strVolumeByPublisher As String = ""
        Private intSpecialIssue As Int16 = 0
        Private intClaimCycle1 As Int16 = 0
        Private intClaimCycle2 As Int16 = 0
        Private intClaimCycle3 As Int16 = 0
        Private intDeliveryTime As Int16 = 0

        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        Private objDIssue As New clsDIssue

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' PhysDetail property
        Public Property PhysDetail() As String
            Get
                Return strPhysDetail
            End Get
            Set(ByVal Value As String)
                strPhysDetail = Value
            End Set
        End Property

        ' Price property
        Public Property Price() As Double
            Get
                Return dblPrice
            End Get
            Set(ByVal Value As Double)
                dblPrice = Value
            End Set
        End Property

        ' IssuedDate property
        Public Property IssuedDate() As String
            Get
                Return strIssuedDate
            End Get
            Set(ByVal Value As String)
                strIssuedDate = Value
            End Set
        End Property

        ' IssueNo property
        Public Property IssueNo() As String
            Get
                Return strIssueNo
            End Get
            Set(ByVal Value As String)
                strIssueNo = Value
            End Set
        End Property

        ' OvIssueNo property
        Public Property OvIssueNo() As String
            Get
                Return strOvIssueNo
            End Get
            Set(ByVal Value As String)
                strOvIssueNo = Value
            End Set
        End Property

        ' Volume property
        Public Property Volume() As String
            Get
                Return strVolume
            End Get
            Set(ByVal Value As String)
                strVolume = Value
            End Set
        End Property

        ' SpecialTitle property
        Public Property SpecialTitle() As String
            Get
                Return strSpecialTitle
            End Get
            Set(ByVal Value As String)
                strSpecialTitle = Value
            End Set
        End Property

        ' Summary property
        Public Property Summary() As String
            Get
                Return strSummary
            End Get
            Set(ByVal Value As String)
                strSummary = Value
            End Set
        End Property

        ' SubscribedCopies property
        Public Property SubscribedCopies() As Int16
            Get
                Return intSubscribedCopies
            End Get
            Set(ByVal Value As Int16)
                intSubscribedCopies = Value
            End Set
        End Property

        ' ToBindery property
        Public Property ToBindery() As Int16
            Get
                Return intToBindery
            End Get
            Set(ByVal Value As Int16)
                intToBindery = Value
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

        ' ItemID property
        Public Property ItemID() As Long
            Get
                Return lngItemID
            End Get
            Set(ByVal Value As Long)
                lngItemID = Value
            End Set
        End Property

        ' IssueID property
        Public Property IssueID() As Long
            Get
                Return lngIssueID
            End Get
            Set(ByVal Value As Long)
                lngIssueID = Value
            End Set
        End Property

        ' FirstIssueInYear property
        Public Property FirstIssueInYear() As Int16
            Get
                Return intFirstIssueInYear
            End Get
            Set(ByVal Value As Int16)
                intFirstIssueInYear = Value
            End Set
        End Property

        ' ResetRegularity property
        Public Property ResetRegularity() As Int16
            Get
                Return intResetRegularity
            End Get
            Set(ByVal Value As Int16)
                intResetRegularity = Value
            End Set
        End Property

        ' VolumeByPublisher property
        Public Property VolumeByPublisher() As String
            Get
                Return strVolumeByPublisher
            End Get
            Set(ByVal Value As String)
                strVolumeByPublisher = Value
            End Set
        End Property

        ' SpecialIssue property
        Public Property SpecialIssue() As Int16
            Get
                Return intSpecialIssue
            End Get
            Set(ByVal Value As Int16)
                intSpecialIssue = Value
            End Set
        End Property

        ' ClaimCycle1 property
        Public Property ClaimCycle1() As Int16
            Get
                Return intClaimCycle1
            End Get
            Set(ByVal Value As Int16)
                intClaimCycle1 = Value
            End Set
        End Property

        ' ClaimCycle2 property
        Public Property ClaimCycle2() As Int16
            Get
                Return intClaimCycle2
            End Get
            Set(ByVal Value As Int16)
                intClaimCycle2 = Value
            End Set
        End Property

        ' ClaimCycle3 property
        Public Property ClaimCycle3() As Int16
            Get
                Return intClaimCycle3
            End Get
            Set(ByVal Value As Int16)
                intClaimCycle3 = Value
            End Set
        End Property

        ' DeliveryTime property
        Public Property DeliveryTime() As Int16
            Get
                Return intDeliveryTime
            End Get
            Set(ByVal Value As Int16)
                intDeliveryTime = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Initialize method
        Public Sub Initialize()
            ' Init objBCSP object
            objBCSP.DBServer = strDBServer
            objBCSP.ConnectionString = strConnectionString
            objBCSP.InterfaceLanguage = strInterfaceLanguage
            Call objBCSP.Initialize()

            ' Init objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            Call objBCDBS.Initialize()

            ' Init objDIssue object
            objDIssue.DBServer = strDBServer
            objDIssue.ConnectionString = strConnectionString
            Call objDIssue.Initialize()
        End Sub

        ' Add method
        ' Purpose: Add new Issue
        ' Input: some main infor of Issue
        ' Output: Integer value
        '   0: success
        '   1: exist IssueNo
        '   2: fail
        '	3: exist OvIssueNo
        Public Function Add() As Integer
            Try
                objDIssue.ItemID = lngItemID
                objDIssue.ClaimCycle1 = intClaimCycle1
                objDIssue.ClaimCycle2 = intClaimCycle2
                objDIssue.ClaimCycle3 = intClaimCycle3
                objDIssue.DeliveryTime = intDeliveryTime
                objDIssue.SpecialIssue = intSpecialIssue
                objDIssue.PhysDetail = Trim(objBCSP.ConvertItBack(strPhysDetail))
                objDIssue.Price = dblPrice
                objDIssue.Note = Trim(objBCSP.ConvertItBack(strNote))
                objDIssue.IssuedDate = objBCDBS.ConvertDateBack(Trim(strIssuedDate))
                objDIssue.IssueNo = Trim(strIssueNo)
                objDIssue.OvIssueNo = Trim(strOvIssueNo)
                objDIssue.VolumeByPublisher = Trim(objBCSP.ConvertItBack(VolumeByPublisher))
                objDIssue.SpecialTitle = Trim(objBCSP.ConvertItBack(strSpecialTitle))
                objDIssue.Summary = Trim(objBCSP.ConvertItBack(strSummary))
                objDIssue.FirstIssueInYear = intFirstIssueInYear
                objDIssue.ResetRegularity = intResetRegularity
                objDIssue.SubscribedCopies = intSubscribedCopies
                Add = objDIssue.Add()
                If Add = 0 Then
                    If objBCDBS.DBServer = "ORACLE" Then
                        objBCDBS.SQLStatement = "select id from Ser_tblIssue where itemid=" & lngItemID & " and issueNo='" & Trim(strIssueNo) & "' and IssuedDate=convertdate('" & objDIssue.IssuedDate & "')"
                    Else
                        objBCDBS.SQLStatement = "select id from Ser_tblIssue where itemid=" & lngItemID & " and issueNo='" & Trim(strIssueNo) & "' and IssuedDate='" & objDIssue.IssuedDate & "'"
                    End If
                    lngIssueID = objBCDBS.RetrieveItemInfor.Rows(0).Item(0)
                End If
                intErrorCode = objDIssue.ErrorCode
                strErrorMsg = objDIssue.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Update method
        ' Purpose: Update information of the selected Issue
        ' Input: some main infor of Issue
        ' Output: Integer value
        '   0: success
        '   1: exist IssueNo
        '   2: fail
        '	3: exist OvIssueNo
        Public Function Update() As Int16
            Try
                objDIssue.ItemID = lngItemID
                objDIssue.IssueID = lngIssueID
                objDIssue.ClaimCycle1 = objBCDBS.ConvertDateBack(intClaimCycle1)
                objDIssue.ClaimCycle2 = intClaimCycle2
                objDIssue.ClaimCycle3 = intClaimCycle3
                objDIssue.DeliveryTime = intDeliveryTime
                objDIssue.SpecialIssue = intSpecialIssue
                objDIssue.PhysDetail = Trim(objBCSP.ConvertItBack(strPhysDetail))
                objDIssue.Price = dblPrice
                objDIssue.Note = Trim(objBCSP.ConvertItBack(strNote))
                objDIssue.IssuedDate = objBCDBS.ConvertDateBack(Trim(strIssuedDate))
                objDIssue.IssueNo = Trim(strIssueNo)
                objDIssue.OvIssueNo = Trim(strOvIssueNo)
                objDIssue.VolumeByPublisher = Trim(objBCSP.ConvertItBack(VolumeByPublisher))
                objDIssue.SpecialTitle = Trim(objBCSP.ConvertItBack(strSpecialTitle))
                objDIssue.Summary = Trim(objBCSP.ConvertItBack(strSummary))
                objDIssue.FirstIssueInYear = intFirstIssueInYear
                objDIssue.ResetRegularity = intResetRegularity
                objDIssue.SubscribedCopies = intSubscribedCopies
                Update = objDIssue.Update
                intErrorCode = objDIssue.ErrorCode
                strErrorMsg = objDIssue.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Delete method
        ' Purpose: delete selected Issue
        ' Input: IssueID
        ' Output: Integer value
        '   + 0: Delete successfull
        '   + 1: exist atlease one copy
        Public Function Delete() As Int16
            Try
                objDIssue.IssueID = lngIssueID
                Delete = objDIssue.Delete
                intErrorCode = objDIssue.ErrorCode
                strErrorMsg = objDIssue.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Register method       
        ' Purpose: Auto registe issues
        ' Input: some main infor
        ' Output: 
        '   0 when error
        '   Total issue inserted when success
        Public Function Register(ByVal intStartIssueNo As Integer, ByVal intStartOvIssueNo As Integer, ByVal strStartDate As String, ByVal strEndDate As String) As Integer
            Try
                objDIssue.ItemID = lngItemID
                objDIssue.Price = dblPrice
                objDIssue.VolumeByPublisher = Trim(objBCSP.ConvertItBack(VolumeByPublisher))
                objDIssue.SubscribedCopies = intSubscribedCopies
                Register = objDIssue.Register(intStartIssueNo, intStartOvIssueNo, objBCDBS.ConvertDateBack(strStartDate), objBCDBS.ConvertDateBack(strEndDate))
                intErrorCode = objDIssue.ErrorCode
                strErrorMsg = objDIssue.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetIssueInfor method
        ' Purpose: get infor of the selected issue
        ' Input: IssueID
        ' Output: datatable result
        Public Function GetIssueInfor() As DataTable
            Try
                objDIssue.IssueID = lngIssueID
                GetIssueInfor = objBCDBS.ConvertTable(objDIssue.GetIssueInfor, "FIELD300", False)
                intErrorCode = objDIssue.ErrorCode
                strErrorMsg = objDIssue.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetLastIssueInfor method
        ' Purpose: Get last issue infor
        ' Input: ItemID
        ' Output: datatable result
        Public Function GetLastIssueInfor() As DataTable
            Try
                objDIssue.ItemID = lngItemID
                GetLastIssueInfor = objBCDBS.ConvertTable(objDIssue.GetLastIssueInfor, "FIELD300", False)
                intErrorCode = objDIssue.ErrorCode
                strErrorMsg = objDIssue.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Claim method
        ' Purpose: Update Claim date for issue
        ' Input: ItemIDs, Claim mode (1,2,3)
        Public Sub UpdateClaimDate(ByVal strItemID As String, ByVal intClaimMode As Int16)
            Try
                Call objDIssue.UpdateClaimDate(strItemID, intClaimMode)
                intErrorCode = objDIssue.ErrorCode
                strErrorMsg = objDIssue.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' GetReceivedCopies method
        ' Purpose: Get received copies of the selected issue
        ' Input: IssueID
        ' Output: datatable result, remaincopies
        Public Function GetReceivedCopies(ByRef intRemainCopies As Integer, Optional ByVal intLocationID As Integer = 0) As DataTable
            Try
                objDIssue.IssueID = lngIssueID
                GetReceivedCopies = objBCDBS.ConvertTable(objDIssue.GetReceivedCopies(intRemainCopies, intLocationID), False)
                intErrorCode = objDIssue.ErrorCode
                strErrorMsg = objDIssue.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCSP Is Nothing Then
                    Call objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    Call objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objDIssue Is Nothing Then
                    objDIssue.Dispose(True)
                    objDIssue = Nothing
                End If
            Finally
                Call MyBase.Dispose()
                Call Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace