' Class: clsBBinding
' Purpose: Management sysbinding
' Creator: Oanhtn
' Created Date: 20/09/2004
' Modification History:

Imports System
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Serial

Namespace eMicLibAdmin.BusinessRules.Serial
    Public Class clsBBindingVolume
        Inherits clsBBase

        ' *******************************************************************************************************
        ' Declare Private variables
        ' *******************************************************************************************************

        Private intAcqSourceID As Integer = 0
        Private intLoanTypeID As Integer = 0
        Private dblPrice As Double = 0
        Private strShelf As String = ""
        Private strCopyNumber As String = ""
        Private strCopyIDs As String = ""
        Private intBindingMode As Int16 = 0
        Private intBindingRule As Integer = 0
        Private intIssuedYear As Integer = 0
        Private lngCopyNumberID As Long = 0
        Private lngItemID As Long = 0
        Private strVolumeByLibrary As String = ""
        Private intLocationID As Integer = 0

        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        Private objDBindingVolume As New clsDBindingVolume

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' AcqSourceID Property
        Public Property AcqSourceID() As Integer
            Get
                Return intAcqSourceID
            End Get
            Set(ByVal Value As Integer)
                intAcqSourceID = Value
            End Set
        End Property

        ' LoanTypeID Property
        Public Property LoanTypeID() As Integer
            Get
                Return intLoanTypeID
            End Get
            Set(ByVal Value As Integer)
                intLoanTypeID = Value
            End Set
        End Property

        ' Price Property
        Public Property Price() As Integer
            Get
                Return dblPrice
            End Get
            Set(ByVal Value As Integer)
                dblPrice = Value
            End Set
        End Property

        ' Shelf Property
        Public Property Shelf() As String
            Get
                Return strShelf
            End Get
            Set(ByVal Value As String)
                strShelf = Value
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

        ' CopyIDs Property
        Public Property CopyIDs() As String
            Get
                Return strCopyIDs
            End Get
            Set(ByVal Value As String)
                strCopyIDs = Value
            End Set
        End Property

        ' BindingMode Property
        Public Property BindingMode() As Integer
            Get
                Return intBindingMode
            End Get
            Set(ByVal Value As Integer)
                intBindingMode = Value
            End Set
        End Property

        ' BindingRule Property
        Public Property BindingRule() As Integer
            Get
                Return intBindingRule
            End Get
            Set(ByVal Value As Integer)
                intBindingRule = Value
            End Set
        End Property

        ' IssuedYear Property
        Public Property IssuedYear() As Integer
            Get
                Return intIssuedYear
            End Get
            Set(ByVal Value As Integer)
                intIssuedYear = Value
            End Set
        End Property

        ' CopyNumberID property
        Public Property CopyNumberID() As Long
            Get
                Return lngCopyNumberID
            End Get
            Set(ByVal Value As Long)
                lngCopyNumberID = Value
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

        ' VolumeByLibrary property
        Public Property VolumeByLibrary() As String
            Get
                Return strVolumeByLibrary
            End Get
            Set(ByVal Value As String)
                strVolumeByLibrary = Value
            End Set
        End Property

        ' LocationID property
        Public Property LocationID() As Integer
            Get
                Return intLocationID
            End Get
            Set(ByVal Value As Integer)
                intLocationID = Value
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

            ' Init objDBindingVolume object
            objDBindingVolume.DBServer = strDBServer
            objDBindingVolume.ConnectionString = strConnectionString
            Call objDBindingVolume.Initialize()
        End Sub

        ' Bind method
        ' Purpose: Binding
        ' Input: ID of Periodical, CopyIDs, CopyNumber, LocationID, LibID...
        ' Output: 0 when success
        Public Function Bind() As Integer
            Try
                objDBindingVolume.LocationID = intLocationID
                objDBindingVolume.CopyNumber = Trim(objBCSP.ConvertItBack(strCopyNumber))
                objDBindingVolume.Shelf = Trim(objBCSP.ConvertItBack(strShelf))
                objDBindingVolume.LoanTypeID = intLoanTypeID
                objDBindingVolume.AcqSourceID = intAcqSourceID
                objDBindingVolume.Price = dblPrice
                objDBindingVolume.ItemID = lngItemID
                objDBindingVolume.VolumeByLibrary = Replace(Replace(Trim(objBCSP.ConvertItBack(strVolumeByLibrary)), "''", ""), "'", "")
                objDBindingVolume.CopyIDs = Trim(strCopyIDs)
                Bind = objDBindingVolume.Bind
                intErrorCode = objDBindingVolume.ErrorCode
                strErrorMsg = objDBindingVolume.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' UnBind method
        ' Purpose: Unbind now
        ' Input: CopyNumberID
        Public Sub UnBind()
            Try
                objDBindingVolume.ItemID = lngItemID
                objDBindingVolume.CopyNumberID = lngCopyNumberID
                Call objDBindingVolume.UnBind()
                intErrorCode = objDBindingVolume.ErrorCode
                strErrorMsg = objDBindingVolume.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' GetCopiesOfBind method
        ' Purpose: Get issues of the selected bind (for unbind)
        ' Input: IssuedYear, ItemID, LocationID
        ' Output: datatable result
        Public Function GetCopiesOfBind() As DataTable
            Try
                objDBindingVolume.IssuedYear = intIssuedYear
                objDBindingVolume.ItemID = lngItemID
                objDBindingVolume.LocationID = intLocationID
                objDBindingVolume.CopyNumberID = lngCopyNumberID
                GetCopiesOfBind = objBCDBS.ConvertTable(objDBindingVolume.GetCopiesOfBind, False)
                intErrorCode = objDBindingVolume.ErrorCode
                strErrorMsg = objDBindingVolume.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetCopiesToBind method
        ' Purpose: Get copies of the selected periodical to bind
        ' Input: IssuedYear, ItemID, LocationID
        ' Output: datatable result
        Public Function GetCopiesToBind(Optional ByVal intIssueID As Integer = 0) As DataTable
            Try
                objDBindingVolume.IssuedYear = intIssuedYear
                objDBindingVolume.ItemID = lngItemID
                objDBindingVolume.LocationID = intLocationID
                GetCopiesToBind = objBCDBS.ConvertTable(objDBindingVolume.GetCopiesToBind(intIssueID), False)
                intErrorCode = objDBindingVolume.ErrorCode
                strErrorMsg = objDBindingVolume.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetVolumeByLibrary method
        ' Purpose: Get issues of the selected bind (for unbind)
        ' Input: ItemID, IssuedYear, LocationID
        ' Output: datatable result
        ' Modify by chuyenpt(strVolumeByLibrary:Tim kiem ÐKCB theo tap,intIndex=1:lay ra cac tap cua mot an pham)
        Public Function GetVolumeByLibrary(Optional ByVal strVolumeByLibrary As String = "", Optional ByVal intIndex As Integer = 0) As DataTable
            Try
                objDBindingVolume.IssuedYear = intIssuedYear
                objDBindingVolume.ItemID = lngItemID
                objDBindingVolume.LocationID = intLocationID
                GetVolumeByLibrary = objBCDBS.ConvertTable(objDBindingVolume.GetVolumeByLibrary(strVolumeByLibrary, intIndex), False)
                intErrorCode = objDBindingVolume.ErrorCode
                strErrorMsg = objDBindingVolume.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: Dispose
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
                If Not objDBindingVolume Is Nothing Then
                    objDBindingVolume.Dispose(True)
                    objDBindingVolume = Nothing
                End If
            Finally
                Call MyBase.Dispose()
                Call Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace