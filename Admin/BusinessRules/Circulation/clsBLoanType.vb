Imports System
Imports System.Data
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.DataAccess.Circulation

Namespace eMicLibAdmin.BusinessRules.Circulation
    Public Class clsBLoanType
        Inherits clsBBase

        ' ***************************************************************************************************
        ' Declare member variables
        ' ***************************************************************************************************
        Private intLoanTypeID As Int16 = 0
        Private dblOverdueFine As Double = 0
        Private dblFee As Double = 0
        Private intFixedFee As Integer = 0
        Private strLoanType As String = ""
        Private bytTimeUnit As Integer = 0
        Private bytRenewals As Integer = 0
        Private bytRenewPeriod As Integer = 0
        Private bytLoanPeriod As Integer = 0
        Private strGroupLoanTypeIDs As String = ""
        Private strLoanTypeCode As String = ""
        Private strPatronGroupIDs As String = ""

        Private objBCSP As New clsBCommonStringProc
        Private objDLoanType As New clsDLoanType
        Private objBCDBS As New clsBCommonDBSystem

        ' ***************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' ***************************************************************************************************
        Public Property PatronGroupIDs() As String
            Get
                Return strPatronGroupIDs
            End Get
            Set(ByVal Value As String)
                strPatronGroupIDs = Value
            End Set
        End Property
        'strGroupLoanTypeIDs
        Public Property GroupLoanTypeIDs() As String
            Get
                Return strGroupLoanTypeIDs
            End Get
            Set(ByVal Value As String)
                strGroupLoanTypeIDs = Value
            End Set
        End Property

        ' LoanTypeID property
        Public Property LoanTypeID() As Int16
            Get
                Return intLoanTypeID
            End Get
            Set(ByVal Value As Int16)
                intLoanTypeID = Value
            End Set
        End Property

        ' OverdueFine property
        Public Property OverdueFine() As Double
            Get
                Return dblOverdueFine
            End Get
            Set(ByVal Value As Double)
                dblOverdueFine = Value
            End Set
        End Property

        ' Fee property
        Public Property Fee() As Double
            Get
                Return dblFee
            End Get
            Set(ByVal Value As Double)
                dblFee = Value
            End Set
        End Property

        ' FixedFee property
        Public Property FixedFee() As Integer
            Get
                Return intFixedFee
            End Get
            Set(ByVal Value As Integer)
                intFixedFee = Value
            End Set
        End Property

        ' LoanType property
        Public Property LoanType() As String
            Get
                Return strLoanType
            End Get
            Set(ByVal Value As String)
                strLoanType = Value
            End Set
        End Property

        ' TimeUnit property
        Public Property TimeUnit() As Integer
            Get
                Return bytTimeUnit
            End Get
            Set(ByVal Value As Integer)
                bytTimeUnit = Value
            End Set
        End Property

        ' Renewals property
        Public Property Renewals() As Integer
            Get
                Return bytRenewals
            End Get
            Set(ByVal Value As Integer)
                bytRenewals = Value
            End Set
        End Property

        ' RenewPeriod property
        Public Property RenewPeriod() As Integer
            Get
                Return bytRenewPeriod
            End Get
            Set(ByVal Value As Integer)
                bytRenewPeriod = Value
            End Set
        End Property

        ' LoanPeriod property
        Public Property LoanPeriod() As Integer
            Get
                Return bytLoanPeriod
            End Get
            Set(ByVal Value As Integer)
                bytLoanPeriod = Value
            End Set
        End Property

        ' LoanTypeCode property
        Public Property LoanTypeCode() As String
            Get
                Return strLoanTypeCode
            End Get
            Set(ByVal Value As String)
                strLoanTypeCode = Value
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
                ' Init objBCSP object
                objBCSP.ConnectionString = strConnectionString
                objBCSP.DBServer = strDBServer
                objBCSP.InterfaceLanguage = strInterfaceLanguage
                Call objBCSP.Initialize()

                ' Init objBCDBS object
                objBCDBS.ConnectionString = strConnectionString
                objBCDBS.DBServer = strDBServer
                objBCDBS.InterfaceLanguage = strInterfaceLanguage
                Call objBCDBS.Initialize()

                ' Init objDLoanType object
                objDLoanType.ConnectionString = strConnectionString
                objDLoanType.DBServer = strDBServer
                Call objDLoanType.Initialize()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' GetLoanTypes method
        ' Purpose: Get LoanType information
        ' Input: LoanTypeID
        ' Output: datatable result
        Public Function GetLoanTypes() As DataTable
            Dim tblResult As DataTable
            Dim inti As Integer
            Try
                objDLoanType.LoanTypeID = intLoanTypeID
                objDLoanType.LibID = intLibID
                tblResult = objBCDBS.ConvertTable(objDLoanType.GetLoanTypes)
                If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                    For inti = 0 To tblResult.Rows.Count - 1
                        tblResult.Rows(inti).Item("Fee") = CInt(tblResult.Rows(inti).Item("Fee"))
                        tblResult.Rows(inti).Item("OverdueFine") = CInt(tblResult.Rows(inti).Item("OverdueFine"))
                    Next
                End If
                GetLoanTypes = tblResult
                strErrorMsg = objBCDBS.ErrorMsg
                intErrorCode = objBCDBS.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        Public Function GetLoanTypesByLoanTypeCode() As DataTable
            Try
                objDLoanType.LoanTypeCode = strLoanTypeCode
                GetLoanTypesByLoanTypeCode = objDLoanType.GetLoanTypesByLoanTypeCode()
                strErrorMsg = objBCDBS.ErrorMsg
                intErrorCode = objBCDBS.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        Public Function GetTotal_HoldingCopies(Optional ByVal intUserID As Integer = 0) As DataTable
            Try
                objDLoanType.LoanTypeID = intLoanTypeID
                GetTotal_HoldingCopies = objBCDBS.ConvertTable(objDLoanType.GetTotal_HoldingCopies(intUserID))
                strErrorMsg = objBCDBS.ErrorMsg
                intErrorCode = objBCDBS.ErrorCode
                'Catch ex As Exception
                '    strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' CreateLoanType method
        ' Purpose: Create new LoanType
        ' Input: some main information
        Public Function CreateLoanType() As Integer
            Try
                objDLoanType.Fee = dblFee
                objDLoanType.FixedFee = intFixedFee
                objDLoanType.LoanPeriod = bytLoanPeriod
                objDLoanType.LoanType = objBCSP.ConvertItBack(strLoanType)
                objDLoanType.LoanTypeCode = strLoanTypeCode
                objDLoanType.OverdueFine = dblOverdueFine
                objDLoanType.Renewals = bytRenewals
                objDLoanType.RenewPeriod = bytRenewPeriod
                objDLoanType.TimeUnit = bytTimeUnit
                objDLoanType.LibID = intLibID
                objDLoanType.PatronGroupIDs = strPatronGroupIDs
                CreateLoanType = objDLoanType.CreateLoanType()
                'Catch ex As Exception
                '    strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' UpdateLoanType method
        ' Purpose: information of the selected LoanType
        ' Input: intLoanTypeID
        Public Sub UpdateLoanType()
            Try
                objDLoanType.LoanTypeID = intLoanTypeID
                objDLoanType.Fee = dblFee
                objDLoanType.FixedFee = intFixedFee
                objDLoanType.LoanPeriod = bytLoanPeriod
                objDLoanType.LoanType = objBCSP.ConvertItBack(strLoanType)
                objDLoanType.LoanTypeCode = strLoanTypeCode
                objDLoanType.OverdueFine = dblOverdueFine
                objDLoanType.Renewals = bytRenewals
                objDLoanType.RenewPeriod = bytRenewPeriod
                objDLoanType.TimeUnit = bytTimeUnit
                objDLoanType.PatronGroupIDs = strPatronGroupIDs
                objDLoanType.UpdateLoanType()
                'Catch ex As Exception
                '    strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        Public Sub MergeLoanType()
            objDLoanType.LoanTypeID = intLoanTypeID
            objDLoanType.GroupLoanTypeIDs = strGroupLoanTypeIDs
            objDLoanType.MergeLoanType()
        End Sub

        ' DeleteLoanType method
        ' Purpose: delete information of the selected LoanType
        ' Input: intLoanTypeID
        Public Sub DeleteLoanType()
            Try

            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            If isDisposing Then
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objDLoanType Is Nothing Then
                    objDLoanType.Dispose(True)
                    objDLoanType = Nothing
                End If
            End If
            MyBase.Dispose()
            Me.Dispose()
        End Sub
    End Class
End Namespace