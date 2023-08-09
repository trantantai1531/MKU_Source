' Name: clsBPatron
' Purpose: allow all action relate Patron
' Creator: Tuanhv
' CreatedDate: 19/08/2004
' Modification History:24/08/2004

Imports System
Imports System.Data
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.DataAccess.Circulation

Namespace eMicLibAdmin.BusinessRules.Circulation
    Public Class clsBPatron
        Inherits clsBBase

        ' *****************************************************************************************************
        ' Declare member variables
        ' *****************************************************************************************************

        Private strFullName As String = ""
        Private strLastName As String = ""
        Private strFirstName As String = ""
        Private strMiddleName As String = ""
        Private strDOB As String = ""
        Private strValidDate As String = ""
        Private strExpiredDate As String = ""
        Private intPatronGroupID As Int16 = 0
        Private intStatus As Int16 = 0
        Private intLockDays As Int16 = 0

        Private objBCDBS As New clsBCommonDBSystem
        Private objBCSP As New clsBCommonStringProc
        Private objDPatron As New clsDPatron
        Private tblGetPatronInfor As New DataTable
        Private intPatronID As Int16
        Private strWorkplace As String
        Private strTelephone As String
        Private strMobile As String
        Private strEmail As String
        Private strPatronCode As String
        Private intLockedDays As Integer
        Private strStartedDate As String
        Private strNote As String
        Private intOutValue As Integer
        Private intUser_ID As Integer
        Private intID As Integer
        Private strCreateDate As String
        Private intLocationID As Integer
        Private intMonth As Integer
        Private intYear As Integer
        Private strFromDate As String
        Private strToDate As String
        Private intFilter As Integer
        Private objArrLabelChart As Object
        Private objArrDataChart As Object
        Private intLibID As Integer
        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************
        'OutValue property
        Public Property OutValue() As Integer
            Get
                Return intOutValue
            End Get
            Set(ByVal Value As Integer)
                intOutValue = Value
            End Set
        End Property
        'PatronCode property
        Public Property PatronCode() As String
            Get
                Return strPatronCode
            End Get
            Set(ByVal Value As String)
                strPatronCode = Value
            End Set
        End Property

        'LockedDays property
        Public Property LockedDays() As Integer
            Get
                Return intLockedDays
            End Get
            Set(ByVal Value As Integer)
                intLockedDays = Value
            End Set
        End Property

        'StartedDate property
        Public Property StartedDate() As String
            Get
                Return strStartedDate
            End Get
            Set(ByVal Value As String)
                strStartedDate = Value
            End Set
        End Property
        'Note property
        Public Property Note() As String
            Get
                Return strNote
            End Get
            Set(ByVal Value As String)
                strNote = Value
            End Set
        End Property

        ' PatronID property
        Public Property PatronID() As Integer
            Get
                Return intPatronID
            End Get
            Set(ByVal Value As Integer)
                intPatronID = Value
            End Set
        End Property

        ' Email property
        Public Property Email() As String
            Get
                Return strEmail
            End Get
            Set(ByVal Value As String)
                strEmail = Value
            End Set
        End Property

        ' Mobile property
        Public Property Mobile() As String
            Get
                Return strMobile
            End Get
            Set(ByVal Value As String)
                strMobile = Value
            End Set
        End Property

        ' Telephone property
        Public Property Telephone() As String
            Get
                Return strTelephone
            End Get
            Set(ByVal Value As String)
                strTelephone = Value
            End Set
        End Property

        ' Workplace property
        Public Property Workplace() As String
            Get
                Return strWorkplace
            End Get
            Set(ByVal Value As String)
                strWorkplace = Value
            End Set
        End Property

        ' FullName property
        Public Property FullName() As String
            Get
                Return strFullName
            End Get
            Set(ByVal Value As String)
                strFullName = Value
            End Set
        End Property

        ' FirstName property
        Public Property FirstName() As String
            Get
                Return strFirstName
            End Get
            Set(ByVal Value As String)
                strFirstName = Value
            End Set
        End Property

        ' LastName property
        Public Property LastName() As String
            Get
                Return strLastName
            End Get
            Set(ByVal Value As String)
                strLastName = Value
            End Set
        End Property

        ' MiddleName property
        Public Property MiddleName() As String
            Get
                Return strMiddleName
            End Get
            Set(ByVal Value As String)
                strMiddleName = Value
            End Set
        End Property

        ' DOB property
        Public Property DOB() As String
            Get
                Return strDOB
            End Get
            Set(ByVal Value As String)
                strDOB = Value
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

        ' ExpiredDate property
        Public Property ExpiredDate() As String
            Get
                Return strExpiredDate
            End Get
            Set(ByVal Value As String)
                strExpiredDate = Value
            End Set
        End Property

        ' PatronGroupID property
        Public Property PatronGroupID() As Int16
            Get
                Return intPatronGroupID
            End Get
            Set(ByVal Value As Int16)
                intPatronGroupID = Value
            End Set
        End Property

        ' Status property
        Public Property Status() As Int16
            Get
                Return intStatus
            End Get
            Set(ByVal Value As Int16)
                intStatus = Value
            End Set
        End Property

        'User_ID property
        Public Property User_ID() As Integer
            Get
                Return intUser_ID
            End Get
            Set(ByVal Value As Integer)
                intUser_ID = Value
            End Set
        End Property
        'ID property
        'Public Property ID() As Integer
        '    Get
        '        Return intID
        '    End Get
        '    Set(ByVal Value As Integer)
        '        intID = Value
        '    End Set
        'End Property
        'CreateDate property
        Public Property CreateDate() As String
            Get
                Return strCreateDate
            End Get
            Set(ByVal Value As String)
                strCreateDate = Value
            End Set
        End Property
        'DepartmentID property
        Public Property LocationID() As Integer
            Get
                Return intLocationID
            End Get
            Set(ByVal Value As Integer)
                intLocationID = Value
            End Set
        End Property
        ' Month property
        Public Property Month() As Integer
            Get
                Return intMonth
            End Get
            Set(ByVal Value As Integer)
                intMonth = Value
            End Set
        End Property
        ' Year Property
        Public Property Year() As Integer
            Get
                Return intYear
            End Get
            Set(ByVal Value As Integer)
                intYear = Value
            End Set
        End Property
        ' Lay mang du lieu de hien thi
        Public ReadOnly Property ArrDataChart() As Object
            Get
                Return objArrDataChart
            End Get
        End Property

        ' Lay mang nhan de hien thi
        Public ReadOnly Property ArrLabelChart() As Object
            Get
                Return objArrLabelChart
            End Get
        End Property
        ' FromDate
        Public Property FromDate() As String
            Get
                Return strFromDate
            End Get
            Set(ByVal Value As String)
                strFromDate = Value
            End Set
        End Property
        ' ToDate
        Public Property ToDate() As String
            Get
                Return strToDate
            End Get
            Set(ByVal Value As String)
                strToDate = Value
            End Set
        End Property
        ' Filter property
        Public Property Filter() As Integer
            Get
                Return intFilter
            End Get
            Set(ByVal Value As Integer)
                intFilter = Value
            End Set
        End Property

        'Lib ID property
        Public Property LibID() As Integer
            Get
                Return intLibID
            End Get
            Set(ByVal Value As Integer)
                intLibID = Value
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

                objDPatron.ConnectionString = strConnectionString
                objDPatron.DBServer = strDBServer
                Call objDPatron.Initialize()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' AddPatron method
        ' Purpose: Addnew PatronRecord
        ' Input: some main infor of Patron
        Public Sub AddPatron()
            Try
                objDPatron.PatronCode = strPatronCode
                objDPatron.ValidDate = objBCDBS.ConvertDateBack(strValidDate)
                objDPatron.ExpiredDate = objBCDBS.ConvertDateBack(strExpiredDate)
                objDPatron.FirstName = objBCSP.ConvertItBack(strFirstName)
                objDPatron.LastName = objBCSP.ConvertItBack(strLastName)
                objDPatron.MiddleName = objBCSP.ConvertItBack(strMiddleName)
                objDPatron.PatronGroupID = intPatronGroupID
                objDPatron.Workplace = objBCSP.ConvertItBack(strWorkplace)
                objDPatron.Telephone = strTelephone
                objDPatron.Email = strEmail
                objDPatron.AddPatron()
                strErrorMsg = objDPatron.ErrorMsg
                intErrorCode = objDPatron.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        'AddRegularity_out method
        'Purpose: INSERT INTO regularity_out
        'Creater: Tuannv
        Public Sub AddRegularity_out()
            Try
                objDPatron.UserID = intUser_ID
                'objDPatron.CreateDate = objBCDBS.ConvertDateBack(strCreateDate)
                objDPatron.PatronCode = strPatronCode
                objDPatron.LocationID = intLocationID
                objDPatron.Note = strNote
                objDPatron.AddRegularity_out()
                strErrorMsg = objDPatron.ErrorMsg
                intErrorCode = objDPatron.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' GetPatronGroup method
        ' Purpose: get information Name of Patron
        ' Ouput: datatable result
        Public Function GetPatronGroup() As DataTable
            Try
                GetPatronGroup = objDPatron.GetPatronGroup()
                strErrorMsg = objDPatron.ErrorMsg
                intErrorCode = objDPatron.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetPatronInfor method
        ' Purpose: Get information of the selected Patron
        ' Input: strFullName
        ' Output: datatable result
        Public Function GetPatronInfor(Optional ByVal strFixDueDate As String = "") As DataTable
            Try
                objDPatron.FullName = Trim(objBCSP.ConvertItBack(strFullName))
                objDPatron.LibID = intLibID

                objDPatron.PatronCode = Trim(objBCSP.ConvertItBack(strPatronCode))

                GetPatronInfor = objBCDBS.ConvertTable(objDPatron.GetPatronInfor(objBCDBS.ConvertDateBack(strFixDueDate)))
                strErrorMsg = objDPatron.ErrorMsg
                intErrorCode = objDPatron.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetPatron() As DataTable
            Try
                objDPatron.FullName = Trim(strFullName)
                objDPatron.PatronCode = Trim(strPatronCode)
                objDPatron.Email = Trim(strEmail)
                objDPatron.Telephone = Trim(strTelephone)
                objDPatron.PatronGroupID = intPatronGroupID
                objDPatron.LibID = intLibID


                'GetPatron = objBCDBS.ConvertTable(objDPatron.GetPatron())
                GetPatron = objDPatron.GetPatron()
                strErrorMsg = objDPatron.ErrorMsg
                intErrorCode = objDPatron.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        'Purpose: Get Department_ID
        'Input: User_ID
        'Output: Datatable result
        'Creater: Tuannv
        Public Function GetLocationID(Optional ByVal intSubsystemID As Integer = 1) As DataTable
            Try
                objDPatron.User_ID = intUser_ID
                GetLocationID = objBCDBS.ConvertTable(objDPatron.GetLocationID(2))
                strErrorMsg = objDPatron.ErrorMsg
                intErrorCode = objDPatron.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        'Purpose: get PatronID
        'Input: PatronCode
        'Output: datatable
        'Creater: Tuannv
        Public Function GetPatronID() As DataTable
            Try
                objDPatron.PatronCode = strPatronCode
                GetPatronID = objBCDBS.ConvertTable(objDPatron.GetPatronID, "ID")
                strErrorMsg = objDPatron.ErrorMsg
                intErrorCode = objDPatron.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function


        Public Function GetPatronByPatronCode() As DataTable
            Try
                objDPatron.PatronCode = strPatronCode
                GetPatronByPatronCode = objDPatron.GetPatronByPatronCode()
                strErrorMsg = objDPatron.ErrorMsg
                intErrorCode = objDPatron.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function


        ' GetPatronInLib method
        ' Purpose: Get information of Patron in Libary
        ' Output: datatable result
        Public Function GetPatronInLib() As DataTable
            Try
                GetPatronInLib = objBCDBS.ConvertTable(objDPatron.GetPatronInLib)
                strErrorMsg = objDPatron.ErrorMsg
                intErrorCode = objDPatron.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetLockedPatrons method
        ' Purpose: get information of LockedCardPatron
        ' Input:
        ' Ouput: datatable result
        ' Modification History: by chuyenpt(15/01/2007)
        '                       : insert Optional strPatronCode into Function GetLockedPatrons
        Public Function GetLockedPatrons(Optional ByVal strPatronCode As String = "", Optional ByVal strLockDateTo As String = "", Optional ByVal strLockDateFrom As String = "", Optional ByVal intLibID As Integer = 0) As DataTable
            Try
                'strLockDateTo = objBCDBS.ConvertDateBack(strLockDateTo)
                'strLockDateFrom = objBCDBS.ConvertDateBack(strLockDateFrom)

                objDPatron.PatronCode = strPatronCode
                objDPatron.LibID = intLibID
                GetLockedPatrons = objBCDBS.ConvertTable(objDPatron.GetLockedPatrons(strPatronCode, strLockDateTo, strLockDateFrom))
                strErrorMsg = objDPatron.ErrorMsg
                intErrorCode = objDPatron.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' LockPatronCard method
        ' Purpose: lock PatronCard because of some reason
        ' Input: strPatronCode, intLockDays
        Public Sub LockPatronCard(Optional ByVal intType As Integer = 0)
            Try
                objDPatron.PatronCode = strPatronCode
                objDPatron.LockedDays = intLockedDays
                objDPatron.StartedDate = objBCDBS.ConvertDateBack(strStartedDate)
                objDPatron.Note = Trim(objBCSP.ConvertItBack(strNote))
                objDPatron.LockPatronCard(intType)
                strErrorMsg = objDPatron.ErrorMsg
                intErrorCode = objDPatron.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' UnLockPatronCard method
        ' Purpose: Unlock PatronCard because of some reason
        ' Input:
        Public Function UnLockPatronCard(Optional intAccept As Integer = 0) As Integer
            Try
                objDPatron.PatronCode = strPatronCode
                UnLockPatronCard = objDPatron.UnLockPatronCard(intAccept)
                strErrorMsg = objDPatron.ErrorMsg
                intErrorCode = objDPatron.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function
        ' Delete photocopy
        Public Sub DelPatronPhotocopy()
            Try
                objDPatron.PatronCode = strPatronCode
                objDPatron.DelPtronPhotocopy()
                strErrorMsg = objDPatron.ErrorMsg
                intErrorCode = objDPatron.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' RenewPatronCard method
        ' Purpose: Renew for expired patron card
        ' Input: PatronCode, NewExpiredDate
        Public Sub RenewPatronCard(ByVal strNewDate As String)
            Try
                objDPatron.PatronCode = strPatronCode
                objDPatron.RenewPatronCard(Trim(objBCDBS.ConvertDateBack(strNewDate)))
                strErrorMsg = objDPatron.ErrorMsg
                intErrorCode = objDPatron.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        ' IncreCountOfPatron method
        ' Purpose:
        Public Sub IncreCountOfPatron()
            Try

            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' GetCountOfPatron function
        ' Purpose:
        Public Function GetCountOfPatron() As DataTable
            Try

            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function
        ' Get PatronMax
        ' Input: FromDate, ToDate, Filter, LocationID
        ' Created by: Tuannv
        Public Sub GetPatronMax()
            objArrDataChart = Nothing
            objArrLabelChart = Nothing
            Dim ArrData() As Integer
            Dim ArrLabel() As String
            Dim tblPatron As DataTable
            Dim i As Integer
            Try
                'objDPatron.FromDate = objBCDBS.ConvertDateBack(strFromDate)
                objDPatron.FromDate = objBCDBS.ConvertDateBack(strFromDate)
                objDPatron.ToDate = objBCDBS.ConvertDateBack(strToDate)
                'objDPatron.ToDate = objBCDBS.ConvertDateBack(strToDate)
                objDPatron.Filter = intFilter
                objDPatron.LocationID = intLocationID
                objDPatron.User_ID = intUser_ID
                tblPatron = objBCDBS.ConvertTable(objDPatron.GetPatronMax)
                strErrorMsg = objDPatron.ErrorMsg
                intErrorCode = objDPatron.ErrorCode
                If tblPatron.Rows.Count <= 0 Then
                    ReDim ArrData(0)
                    ReDim ArrLabel(0)
                    ArrData(0) = 0
                    ArrLabel(0) = "Not found"
                    objArrDataChart = ArrData
                    objArrLabelChart = ArrLabel
                Else
                    ReDim ArrData(tblPatron.Rows.Count - 1)
                    ReDim ArrLabel(tblPatron.Rows.Count - 1)
                    For i = 0 To tblPatron.Rows.Count - 1
                        ArrData(i) = tblPatron.Rows(i).Item("total")
                        ArrLabel(i) = tblPatron.Rows(i).Item("PatronCode")
                    Next
                    objArrDataChart = ArrData
                    objArrLabelChart = ArrLabel
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Function GetPatronMaxDetail() As DataTable
            Try
                'objDPatron.FromDate = objBCDBS.ConvertDateBack(strFromDate)
                'objDPatron.ToDate = objBCDBS.ConvertDateBack(strToDate)
                objDPatron.FromDate = strFromDate
                objDPatron.ToDate = strToDate
                objDPatron.Filter = intFilter
                objDPatron.LocationID = intLocationID
                objDPatron.User_ID = intUser_ID
                GetPatronMaxDetail = objDPatron.GetPatronMaxDetail()
                strErrorMsg = objDPatron.ErrorMsg
                intErrorCode = objDPatron.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        Public Function GetPatronLockInfo() As DataTable
            Dim strSQL As String
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    strSQL = "SELECT CPL.PatronCode,CPL.StartedDate,CPL.Note,CP.FirstName ||' '||CP.MiddleName ||' '||CP.LastName as FullName,CPL.StartedDate + CPL.LockedDays as FinishDate,CPL.LockedDays" & _
                                     " FROM Cir_tblPatronLock CPL,CIR_PATRON CP " & _
                                     " WHERE CPL.PatronCode=CP.Code and Upper(CP.Code)='" & strPatronCode.ToUpper & "'"
                Case Else
                    strSQL = "SELECT CPL.PatronCode,CPL.StartedDate,CPL.Note,CP.FirstName +' '+ CP.MiddleName +' '+ CP.LastName as FullName,CPL.StartedDate + CPL.LockedDays as FinishDate,CPL.LockedDays" & _
                             " FROM Cir_tblPatronLock CPL,CIR_PATRON CP " & _
                             " WHERE CPL.PatronCode=CP.Code and Upper(CP.Code)='" & strPatronCode.ToUpper & "'"

            End Select
            objBCDBS.SQLStatement = strSQL
            GetPatronLockInfo = objBCDBS.ConvertTable(objBCDBS.RetrieveItemInfor())
        End Function
        ' Get PatronTotal
        ' Input: Month,Year,LocationID
        ' Created by: Tuannv
        Public Sub GetPatronTotal()
            objArrDataChart = Nothing
            objArrLabelChart = Nothing
            Dim ArrData() As Integer
            Dim ArrLabel() As String
            Dim tblPatron As DataTable
            Dim i As Integer
            Try
                objDPatron.Month = intMonth
                objDPatron.Year = intYear
                objDPatron.LocationID = intLocationID
                objDPatron.User_ID = intUser_ID
                tblPatron = objBCDBS.ConvertTable(objDPatron.GetPatronTotal)
                strErrorMsg = objDPatron.ErrorMsg
                intErrorCode = objDPatron.ErrorCode
                If tblPatron.Rows.Count <= 0 Then
                    ReDim ArrData(0)
                    ReDim ArrLabel(0)
                    ArrData(0) = 0
                    ArrLabel(0) = "Not found"
                    objArrDataChart = ArrData
                    objArrLabelChart = ArrLabel
                Else
                    ReDim ArrData(tblPatron.Rows.Count - 1)
                    ReDim ArrLabel(tblPatron.Rows.Count - 1)
                    For i = 0 To tblPatron.Rows.Count - 1
                        ArrData(i) = tblPatron.Rows(i).Item("total")
                        ArrLabel(i) = tblPatron.Rows(i).Item("days")
                    Next
                    objArrDataChart = ArrData
                    objArrLabelChart = ArrLabel
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub
        Public Function GetPatronTotalDetail() As DataTable
            Try
                'objDPatron.Month = intMonth
                'objDPatron.Year = intYear
                objDPatron.FromDate = strFromDate
                objDPatron.ToDate = strToDate
                objDPatron.LocationID = intLocationID
                objDPatron.User_ID = intUser_ID
                GetPatronTotalDetail = objDPatron.GetPatronTotalDetail()
                strErrorMsg = objDPatron.ErrorMsg
                intErrorCode = objDPatron.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        Public Function CreditPatronDownLoadFile(ByVal intIsDownLoad As Boolean) As Integer
            Try
                objDPatron.PatronGroupID = intPatronGroupID
                CreditPatronDownLoadFile = objDPatron.CreditPatronDownLoadFile(intIsDownLoad)
                strErrorMsg = objDPatron.ErrorMsg
                intErrorCode = objDPatron.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        Public Function GetIsDownLoad_ByPatronGroup() As Integer
            Try
                objDPatron.PatronGroupID = intPatronGroupID
                GetIsDownLoad_ByPatronGroup = objDPatron.GetIsDownLoad_ByPatronGroup()
                strErrorMsg = objDPatron.ErrorMsg
                intErrorCode = objDPatron.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function


        Public Function GetIsDownLoad_ByPatronCode() As Integer
            Try
                objDPatron.PatronCode = strPatronCode
                GetIsDownLoad_ByPatronCode = objDPatron.GetIsDownLoad_ByPatronCode()
                strErrorMsg = objDPatron.ErrorMsg
                intErrorCode = objDPatron.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

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
                If Not objDPatron Is Nothing Then
                    objDPatron.Dispose(True)
                    objDPatron = Nothing
                End If
            End If
            MyBase.Dispose()
            Me.Dispose()
        End Sub
    End Class
End Namespace
