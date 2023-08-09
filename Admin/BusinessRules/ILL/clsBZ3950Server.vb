' Name: clsBZ3950Server
' Purpose: Z3950 purpose
' Creator: Sondp
' Created Date: 25/11/2004
' Modification History: 
'   - 05/01/2005 by Oanhtn: review

Imports System
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.ILL

Namespace eMicLibAdmin.BusinessRules.ILL
    Public Class clsBZ3950Server
        Inherits clsBBase

        ' ***********************************************************************************************
        ' Declare Private variables
        ' ***********************************************************************************************

        Private intServerID As Integer
        Private strName As String
        Private strHost As String
        Private intPort As Integer
        Private strAccount As String
        Private strPassword As String
        Private bytPrefer As Byte
        Private intDBID As Integer
        Private strDBName As String
        Private strDescription As String

        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        Private objDZ3950Sever As New clsDZ3950Server

        ' ***********************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' ***********************************************************************************************

        ' ServerID property
        Public Property ServerID() As Integer
            Get
                Return (intServerID)
            End Get
            Set(ByVal Value As Integer)
                intServerID = Value
            End Set
        End Property

        ' Port property
        Public Property Port() As Integer
            Get
                Return (intPort)
            End Get
            Set(ByVal Value As Integer)
                intPort = Value
            End Set
        End Property

        ' Name property
        Public Property Name() As String
            Get
                Return (strName)
            End Get
            Set(ByVal Value As String)
                strName = Value
            End Set
        End Property

        ' Host property
        Public Property Host() As String
            Get
                Return (strHost)
            End Get
            Set(ByVal Value As String)
                strHost = Value
            End Set
        End Property

        ' Account property
        Public Property Account() As String
            Get
                Return (strAccount)
            End Get
            Set(ByVal Value As String)
                strAccount = Value
            End Set
        End Property

        ' Password property
        Public Property Password() As String
            Get
                Return (strPassword)
            End Get
            Set(ByVal Value As String)
                strPassword = Value
            End Set
        End Property

        ' Prefer property
        Public Property Prefer() As Byte
            Get
                Return (bytPrefer)
            End Get
            Set(ByVal Value As Byte)
                bytPrefer = Value
            End Set
        End Property

        ' DBID property
        Public Property DBID() As Integer
            Get
                Return (intDBID)
            End Get
            Set(ByVal Value As Integer)
                intDBID = Value
            End Set
        End Property

        ' Description property
        Public Property Description() As String
            Get
                Return (strDescription)
            End Get
            Set(ByVal Value As String)
                strDescription = Value
            End Set
        End Property

        ' DBName property
        Public Property DBName() As String
            Get
                Return (strDBName)
            End Get
            Set(ByVal Value As String)
                strDBName = Value
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

            ' Init objDZ3950Sever object
            objDZ3950Sever.DBServer = strDBServer
            objDZ3950Sever.ConnectionString = strConnectionString
            objDZ3950Sever.Initialize()
        End Sub

        ' Create Z3950 method
        ' Purpose: Create Z3950
        ' Input: main informations
        ' Creator: lent
        Public Function CreateNew() As Integer
            Try
                objDZ3950Sever.Name = objBCSP.ConvertItBack(strName)
                objDZ3950Sever.Host = strHost
                objDZ3950Sever.Port = intPort
                objDZ3950Sever.Account = strAccount
                objDZ3950Sever.Password = strPassword
                objDZ3950Sever.Prefer = bytPrefer
                CreateNew = objDZ3950Sever.CreateNew()
                intErrorCode = objDZ3950Sever.ErrorCode
                strErrorMsg = objDZ3950Sever.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Update Z3950 method
        ' Purpose: Update Z3950
        ' Input: main informations
        ' Creator: lent
        Public Function Update() As Integer
            Try
                objDZ3950Sever.ServerID = intServerID
                objDZ3950Sever.Name = objBCSP.ConvertItBack(strName)
                objDZ3950Sever.Host = strHost
                objDZ3950Sever.Port = intPort
                objDZ3950Sever.Account = strAccount
                objDZ3950Sever.Password = strPassword
                objDZ3950Sever.Prefer = bytPrefer
                Update = objDZ3950Sever.Update()
                intErrorCode = objDZ3950Sever.ErrorCode
                strErrorMsg = objDZ3950Sever.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Delete Z3950 method
        ' Purpose: Delete Z3950
        ' Input: ServerID
        ' Creator: lent
        Public Function Delete() As Integer
            Try
                objDZ3950Sever.ServerID = intServerID
                Delete = objDZ3950Sever.Delete()
                intErrorCode = objDZ3950Sever.ErrorCode
                strErrorMsg = objDZ3950Sever.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' AddDB method
        ' Purpose: AddDB in select Z3950 selected
        ' Input: some main informations
        ' Creator: lent
        Public Function AddNewDB() As Integer
            Try
                objDZ3950Sever.ServerID = intServerID
                objDZ3950Sever.DBName = strDBName
                objDZ3950Sever.Description = objBCSP.ConvertItBack(strDescription)
                AddNewDB = objDZ3950Sever.AddNewDB()
                intErrorCode = objDZ3950Sever.ErrorCode
                strErrorMsg = objDZ3950Sever.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' UpdateDB method
        ' Purpose: UpdateDB in select Z3950 selected
        ' Input: main informations
        ' Creator: lent
        Public Function UpdateDB() As Integer
            Try
                objDZ3950Sever.DBID = intDBID
                objDZ3950Sever.ServerID = intServerID
                objDZ3950Sever.DBName = strDBName
                objDZ3950Sever.Description = objBCSP.ConvertItBack(strDescription)
                UpdateDB = objDZ3950Sever.UpdateDB()
                intErrorCode = objDZ3950Sever.ErrorCode
                strErrorMsg = objDZ3950Sever.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' DeleteDB method
        ' Purpose: DeleteDB in select Z3950 selected
        ' Input: ID
        ' Creator: lent
        Public Sub DeleteDB()
            Try
                objDZ3950Sever.DBID = intDBID
                Call objDZ3950Sever.DeleteDB()
                intErrorCode = objDZ3950Sever.ErrorCode
                strErrorMsg = objDZ3950Sever.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' GetZServerList method
        ' Purpose: Get list of ZServer
        ' Create : lent
        Public Function GetZServerList(ByVal lblink As String) As DataTable
            Dim tblResult As DataTable
            Dim intIndex As Integer

            Try
                tblResult = objBCDBS.ConvertTable(objDZ3950Sever.GetZServerList)
                For intIndex = 0 To tblResult.Rows.Count - 1
                    tblResult.Rows(intIndex).Item("idOrder") = CStr(intIndex + 1)
                    If tblResult.Rows(intIndex).Item("Prefer") = "1" Then
                        tblResult.Rows(intIndex).Item("Prefer") = "<Image src ='../Images/check.gif'>"
                    Else
                        tblResult.Rows(intIndex).Item("Prefer") = "<Image src ='../Images/uncheck.gif'>"
                    End If
                    tblResult.Rows(intIndex).Item("Link") = "<a href='javascript:GotoPageCSDL(" + CStr(tblResult.Rows(intIndex).Item("ID")) + ");' title='" + lblink + "'><img border='0' src='../Images/database.gif'></a>"
                Next
                strErrorMsg = objBCDBS.ErrorMsg
                intErrorCode = objBCDBS.ErrorCode
                GetZServerList = tblResult
                intErrorCode = objDZ3950Sever.ErrorCode
                strErrorMsg = objDZ3950Sever.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetZServerList method
        ' Purpose: Get list of ZServer' Database
        ' Create : lent
        Public Function GetZServerDB() As DataTable
            Dim tblResult As DataTable
            Dim intIndex As Integer
            Try
                objDZ3950Sever.ServerID = intServerID
                tblResult = objBCDBS.ConvertTable(objDZ3950Sever.GetZServerDB(0))
                For intIndex = 0 To tblResult.Rows.Count - 1
                    tblResult.Rows(intIndex).Item("idOrder") = CStr(intIndex + 1)
                Next
                GetZServerDB = tblResult
                intErrorCode = objDZ3950Sever.ErrorCode
                strErrorMsg = objDZ3950Sever.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GenerateServerID method
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

        ' Dispose method
        ' Purpose: Release all resource
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
                If Not objDZ3950Sever Is Nothing Then
                    objDZ3950Sever.Dispose(True)
                    objDZ3950Sever = Nothing
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Dispose()
            End Try
        End Sub
    End Class
End Namespace