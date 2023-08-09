' Name: clsBDenyReason
' Purpose: Deny reason
' Creator: Sondp
' Created Date: 25/11/2004
' Modification History: 

Imports System
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.ILL

Namespace eMicLibAdmin.BusinessRules.ILL
    Public Class clsBDenyReason
        Inherits clsBBase

        ' ***********************************************************************************************
        ' Declare Private variables
        ' ***********************************************************************************************

        Private intID As Integer
        Private strCode As String
        Private strEngName As String
        Private strVietName As String

        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        Private objBDenyReason As New clsDDenyReason

        ' ***********************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' ***********************************************************************************************

        ' ID property
        Public Property ID() As Integer
            Get
                Return (intID)
            End Get
            Set(ByVal Value As Integer)
                intID = Value
            End Set
        End Property

        ' Code property 
        Public Property Code() As String
            Get
                Return (strCode)

            End Get
            Set(ByVal Value As String)
                strCode = Value
            End Set
        End Property

        ' Code property 
        Public Property EngName() As String
            Get
                Return (strEngName)

            End Get
            Set(ByVal Value As String)
                strEngName = Value
            End Set
        End Property

        ' Code property 
        Public Property VietName() As String
            Get
                Return (strVietName)

            End Get
            Set(ByVal Value As String)
                strVietName = Value
            End Set
        End Property

        ' ***********************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' ***********************************************************************************************

        ' Initialize method
        ' Purpose: init all neccessary objects
        Public Sub Initialize()
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

            ' Init objBDenyReason object
            objBDenyReason.DBServer = strDBServer
            objBDenyReason.ConnectionString = strConnectionString
            objBDenyReason.Initialize()
        End Sub

        ' Purpose: Get deny reason
        ' Creator: LENTA
        Public Function GetDenyReason() As DataTable
            Dim tblResult As DataTable
            Dim intIndex As Integer

            Try
                objBDenyReason.LibID = intLibID
                tblResult = objBCDBS.ConvertTable(objBDenyReason.GetDenyReason)
                For intIndex = 0 To tblResult.Rows.Count - 1
                    tblResult.Rows(intIndex).Item("idOrder") = CStr(intIndex + 1)
                Next
                strErrorMsg = objBCDBS.ErrorMsg
                intErrorCode = objBCDBS.ErrorCode
                GetDenyReason = tblResult
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose: Generate new ID from table's IDs
        ' Input: 
        ' Output: 
        ' Creator: LENTA
        Public Function GenerateServerID(ByVal tblResult As DataTable) As Integer
            Dim arrID() As Integer
            Dim intIndex As Integer
            ReDim arrID(tblResult.Rows.Count)

            For intIndex = 0 To tblResult.Rows.Count - 1
                arrID(intIndex) = CInt(tblResult.Rows(intIndex).Item("ID"))
            Next

            Array.Sort(arrID, 0, arrID.Length - 1)

            If arrID(0) > 1 Then
                Return 1
            End If
            For intIndex = 1 To arrID.Length - 1
                If arrID(intIndex) - arrID(intIndex - 1) > 1 Then
                    Return arrID(intIndex - 1) + 1
                End If
            Next
            Return arrID(arrID.Length - 2) + 1
        End Function

        ' Method: Create
        ' Purpose: Create deny reason
        ' Input: some main infor
        ' Output: integer value (0 if success, 1 if exist code)
        ' Creator: LENTA
        Public Function Create() As Integer
            Try
                objBDenyReason.Code = strCode
                objBDenyReason.VietName = objBCSP.ConvertItBack(strVietName)
                objBDenyReason.EngName = strEngName
                objBDenyReason.LibID = intLibID
                Create = objBDenyReason.Create()
                strErrorMsg = objBDenyReason.ErrorMsg
                intErrorCode = objBDenyReason.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose: Update deny reason
        ' Input: some main infor
        ' Output: integer value (0 if success, 1 if exist code)
        ' Creator: LENTA
        Public Function Update() As Integer
            Try
                objBDenyReason.ID = intID
                objBDenyReason.Code = strCode
                objBDenyReason.VietName = objBCSP.ConvertItBack(strVietName)
                objBDenyReason.EngName = strEngName
                Update = objBDenyReason.Update()
                strErrorMsg = objBDenyReason.ErrorMsg
                intErrorCode = objBDenyReason.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose: Delete deny reason
        ' Input: intID
        ' Creator: LENTA
        Public Function Delete() As Integer
            Try
                objBDenyReason.ID = intID
                Delete = objBDenyReason.Delete()
                strErrorMsg = objBDenyReason.ErrorMsg
                intErrorCode = objBDenyReason.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not objBCSP Is Nothing Then
                        objBCSP.Dispose(True)
                        objBCSP = Nothing
                    End If
                    If Not objBCSP Is Nothing Then
                        objBCDBS.Dispose(True)
                        objBCDBS = Nothing
                    End If
                    If Not objBCSP Is Nothing Then
                        objBDenyReason.Dispose(True)
                        objBDenyReason = Nothing
                    End If
                End If
            Finally
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace