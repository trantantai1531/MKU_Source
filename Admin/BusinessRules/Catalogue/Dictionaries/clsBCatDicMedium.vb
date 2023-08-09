Imports eMicLibAdmin.DataAccess.Catalogue
Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.BusinessRules.Catalogue
    Public Class clsBCatDicMedium
        Inherits clsBBase

        ' Declare variables
        Private strIDs As String
        Private intID As Integer = 0
        Private strCode As String
        Private strDescription As String

        Private objBCommonDB As New clsBCommonDBSystem
        Private objBString As New clsBCommonStringProc
        Private objDDicMedium As New clsDCatDicMedium

        ' ID property
        Public Property ID() As Integer
            Get
                Return intID
            End Get
            Set(ByVal Value As Integer)
                intID = Value
            End Set
        End Property

        ' IDs Property
        Public Property IDs() As String
            Get
                Return strIDs
            End Get
            Set(ByVal Value As String)
                strIDs = Value
            End Set
        End Property

        ' Code Property
        Public Property Code() As String
            Get
                Return strCode
            End Get
            Set(ByVal Value As String)
                strCode = Value
            End Set
        End Property

        ' Description Property
        Public Property Description() As String
            Get
                Return strDescription
            End Get
            Set(ByVal Value As String)
                strDescription = Value
            End Set
        End Property

        ' Initialize method
        Public Sub Initialize()
            Try
                objBCommonDB.InterfaceLanguage = strInterfaceLanguage
                objBCommonDB.DBServer = strDBServer
                objBCommonDB.ConnectionString = strConnectionString
                objBCommonDB.Initialize()

                objBString.InterfaceLanguage = strInterfaceLanguage
                objBString.DBServer = strDBServer
                objBString.ConnectionString = strConnectionString
                objBString.Initialize()

                objDDicMedium.DBServer = strDBServer
                objDDicMedium.ConnectionString = strConnectionString
                objDDicMedium.Initialize()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Insert method
        Public Sub Insert()
            Dim strTmp As String
            Try
                strTmp = objBString.ConvertItBack(strCode)
                objDDicMedium.Code = strTmp
                objDDicMedium.AccessEntry = objBString.ProcessVal(strTmp)
                objDDicMedium.Description = objBString.ConvertItBack(strDescription)
                objDDicMedium.Insert()
                strErrormsg = objDDicMedium.ErrorMsg
                intErrorcode = objDDicMedium.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Update method
        'PhuongTT 20080821
        'Modify : Replace IDs --> ID
        Public Sub Update()
            Dim strTmp As String
            Try
                strTmp = objBString.ConvertItBack(strCode)
                objDDicMedium.Code = strTmp
                objDDicMedium.AccessEntry = objBString.ProcessVal(strTmp)
                objDDicMedium.Description = objBString.ConvertItBack(strDescription)
                objDDicMedium.ID = intID
                objDDicMedium.Update()
                strErrormsg = objDDicMedium.ErrorMsg
                intErrorcode = objDDicMedium.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Merge method
        Public Sub Merge()
            Try
                objDDicMedium.ID = intID
                objDDicMedium.IDs = strIDs
                objDDicMedium.Merge()
                strErrormsg = objDDicMedium.ErrorMsg
                intErrorcode = objDDicMedium.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Retrieve method
        Public Function Retrieve() As DataTable
            Try
                objDDicMedium.AccessEntry = objBString.ProcessVal(objBString.ConvertItBack(strCode))
                Retrieve = objBCommonDB.ConvertTable(objDDicMedium.Retrieve())
                strErrormsg = objDDicMedium.ErrorMsg
                intErrorcode = objDDicMedium.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Release resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                End If

                If Not objBCommonDB Is Nothing Then
                    objBCommonDB.Dispose(True)
                    objBCommonDB = Nothing
                End If
                If Not objBString Is Nothing Then
                    objBString.Dispose(True)
                    objBString = Nothing
                End If
                If Not objDDicMedium Is Nothing Then
                    objDDicMedium.Dispose(True)
                    objDDicMedium = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace