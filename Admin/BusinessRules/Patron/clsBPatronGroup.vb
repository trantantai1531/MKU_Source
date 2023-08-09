Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Patron

Namespace eMicLibAdmin.BusinessRules.Patron
    Public Class clsBPatronGroup
        Inherits clsBBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************

        Private intID As Integer
        Private strName As String
        Private intInLibraryQuota As Integer
        Private intLoanQuota As Integer
        Private intHoldQuota As Integer
        Private intHoldTurnTimeOut As Integer
        Private intPriority As Integer
        Private intILLQuota As Integer
        Private intAccessLevel As Integer
        Private strStoreIDs As String
        'Private intLibID As Integer
        Private intLoanDayPeriod As Integer

        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        Private objDPatronGroup As New clsDPatronGroup

        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************

        ' ID Property 
        Public Property ID() As Integer
            Get
                Return intID
            End Get
            Set(ByVal Value As Integer)
                intID = Value
            End Set
        End Property

        Public Property Name() As String
            Get
                Return strName
            End Get
            Set(ByVal Value As String)
                strName = Value
            End Set
        End Property

        Public Property InLibraryQuota() As Integer
            Get
                Return intInLibraryQuota
            End Get
            Set(ByVal Value As Integer)
                intInLibraryQuota = Value
            End Set
        End Property

        Public Property LoanQuota() As Integer
            Get
                Return intLoanQuota
            End Get
            Set(ByVal Value As Integer)
                intLoanQuota = Value
            End Set
        End Property

        Public Property HoldQuota() As Integer
            Get
                Return intHoldQuota
            End Get
            Set(ByVal Value As Integer)
                intHoldQuota = Value
            End Set
        End Property

        Public Property HoldTurnTimeOut() As Integer
            Get
                Return intHoldTurnTimeOut
            End Get
            Set(ByVal Value As Integer)
                intHoldTurnTimeOut = Value
            End Set
        End Property

        Public Property Priority() As Integer
            Get
                Return intPriority
            End Get
            Set(ByVal Value As Integer)
                intPriority = Value
            End Set
        End Property

        Public Property ILLQuota() As Integer
            Get
                Return intILLQuota
            End Get
            Set(ByVal Value As Integer)
                intILLQuota = Value
            End Set
        End Property

        Public Property AccessLevel() As Integer
            Get
                Return intAccessLevel
            End Get
            Set(ByVal Value As Integer)
                intAccessLevel = Value
            End Set
        End Property

        Public Property StoreIDs() As String
            Get
                Return strStoreIDs
            End Get
            Set(ByVal Value As String)
                strStoreIDs = Value
            End Set
        End Property

        ' LIBID 
        'Public Property LibID() As Integer
        '    Get
        '        Return intLibID
        '    End Get
        '    Set(ByVal Value As Integer)
        '        intLibID = Value
        '    End Set
        'End Property

        'LoanDayPeriod
        Public Property LoanDayPeriod() As Integer
            Get
                Return intLoanDayPeriod
            End Get
            Set(ByVal Value As Integer)
                intLoanDayPeriod = Value
            End Set
        End Property

        ' *************************************************************************************************
        ' End declare properties
        ' Declare public method
        ' *************************************************************************************************

        ' Method: Initialize
        ' Purpose: Init all need objects
        Public Sub Initialize()
            ' Init objDPatronGroup object
            objDPatronGroup.DBServer = strDBServer
            objDPatronGroup.ConnectionString = strConnectionString
            Call objDPatronGroup.Initialize()

            ' Initialize objBCSP object
            objBCSP.InterfaceLanguage = strinterfacelanguage
            objBCSP.DBServer = strDBServer
            objBCSP.ConnectionString = strConnectionString
            Call objBCSP.Initialize()

            ' Initialize objBCDBS object
            objBCDBS.InterfaceLanguage = strinterfacelanguage
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            Call objBCDBS.Initialize()
        End Sub

        ' Method: GetPatronGroup
        ' Purpose: GetPatronGroup
        ' Output: Datatable
        ' Created by: Sondp
        Public Function GetAllPatronGroup() As DataTable
            Try
                GetAllPatronGroup = objDPatronGroup.GetAllPatronGroup()
                strErrorMsg = objDPatronGroup.ErrorMsg
                intErrorCode = objDPatronGroup.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function
        Public Function GetPatronGroup() As DataTable
            Try
                objDPatronGroup.LibID = intLibID
                GetPatronGroup = objDPatronGroup.GetPatronGroup()
                strErrorMsg = objDPatronGroup.ErrorMsg
                intErrorCode = objDPatronGroup.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetPatronGroupByPatronCode(ByVal strPatronCode As String) As DataTable
            Try
                GetPatronGroupByPatronCode = objDPatronGroup.GetPatronGroupByPatronCode(strPatronCode)
                strErrorMsg = objDPatronGroup.ErrorMsg
                intErrorCode = objDPatronGroup.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetPatronGroupByName(strName As String) As DataTable
            Try
                objDPatronGroup.LibID = intLibID
                GetPatronGroupByName = objDPatronGroup.GetPatronGroupByName(strName)
                strErrorMsg = objDPatronGroup.ErrorMsg
                intErrorCode = objDPatronGroup.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: GetLocation
        ' Purpose: Get available locations
        ' Output: Datatable
        ' Created by: lent
        Public Function GetLocation() As DataTable
            Try
                objDPatronGroup.LibID = intLibID
                GetLocation = objBCDBS.ConvertTable(objDPatronGroup.GetLocation)
                strErrorMsg = objDPatronGroup.ErrorMsg
                intErrorCode = objDPatronGroup.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: GetLocationOfGroup
        ' Purpose: Get all locations of the selected group
        ' Input: GroupID
        ' Output: Datatable
        ' Created by: lent
        Public Function GetLocationOfGroup() As DataTable
            Try
                objDPatronGroup.ID = intID
                objDPatronGroup.LibID = intLibID
                GetLocationOfGroup = objBCDBS.ConvertTable(objDPatronGroup.GetLocationOfGroup)
                strErrorMsg = objDPatronGroup.ErrorMsg
                intErrorCode = objDPatronGroup.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: Create
        ' Purpose: Create one PatronGroup
        ' Input: patrongoup information
        ' Output: -1 if exists
        ' Created by: Lent
        Public Function Create() As Integer
            Try
                objDPatronGroup.Name = objBCSP.ConvertItBack(strName)
                objDPatronGroup.InLibraryQuota = intInLibraryQuota
                objDPatronGroup.LoanQuota = intLoanQuota
                objDPatronGroup.HoldQuota = intHoldQuota
                objDPatronGroup.HoldTurnTimeOut = intHoldTurnTimeOut
                objDPatronGroup.Priority = intPriority
                objDPatronGroup.ILLQuota = intILLQuota
                objDPatronGroup.AccessLevel = intAccessLevel
                objDPatronGroup.StoreIDs = strStoreIDs
                objDPatronGroup.LibID = intLibID
                objDPatronGroup.LoanDayPeriod = intLoanDayPeriod
                Create = objDPatronGroup.Create()
                strErrorMsg = objDPatronGroup.ErrorMsg
                intErrorCode = objDPatronGroup.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose : Import one PatronGroup
        ' In: strName
        ' Out: intPatronGroupID
        ' Created by: Sondp
        Public Function ImportPatronGroup(ByVal strImportPatronGroupName As String) As Integer
            Try
                objDPatronGroup.Name = objBCSP.ConvertItBack(strImportPatronGroupName)
                objDPatronGroup.InLibraryQuota = 5
                objDPatronGroup.LoanQuota = 5
                objDPatronGroup.HoldQuota = 5
                objDPatronGroup.HoldTurnTimeOut = 5
                objDPatronGroup.Priority = 1
                objDPatronGroup.ILLQuota = 5
                objDPatronGroup.AccessLevel = 0
                objDPatronGroup.StoreIDs = "1"
                objDPatronGroup.LoanDayPeriod = 7
                ImportPatronGroup = objDPatronGroup.Create
                strErrorMsg = objDPatronGroup.ErrorMsg
                intErrorCode = objDPatronGroup.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: Update
        ' Purpose : Update one patron group
        ' Input: ID, name
        ' Output: 0 if success, 1 if exists
        ' Created by: LENT
        Public Function Update() As Integer
            Try
                objDPatronGroup.ID = intID
                objDPatronGroup.Name = objBCSP.ConvertItBack(strName)
                objDPatronGroup.InLibraryQuota = intInLibraryQuota
                objDPatronGroup.LoanQuota = intLoanQuota
                objDPatronGroup.HoldQuota = intHoldQuota
                objDPatronGroup.HoldTurnTimeOut = intHoldTurnTimeOut
                objDPatronGroup.Priority = intPriority
                objDPatronGroup.ILLQuota = intILLQuota
                objDPatronGroup.AccessLevel = intAccessLevel
                objDPatronGroup.StoreIDs = strStoreIDs
                objDPatronGroup.LoanDayPeriod = intLoanDayPeriod
                Update = objDPatronGroup.Update()
                strErrorMsg = objDPatronGroup.ErrorMsg
                intErrorCode = objDPatronGroup.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: Delete
        ' Purpose: Delete selected patrongroup
        ' Input: GroupID
        ' Created by: Lent

        'PhuongTT Add  a para of Output
        Public Function Delete() As Integer
            Try
                objDPatronGroup.ID = intID
                Delete = objDPatronGroup.Delete()
                strErrorMsg = objDPatronGroup.ErrorMsg
                intErrorCode = objDPatronGroup.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: Dispose
        ' Purpose: Release resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objDPatronGroup Is Nothing Then
                    objDPatronGroup.Dispose(True)
                    objDPatronGroup = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace