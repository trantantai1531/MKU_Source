Imports eMicLibAdmin.DataAccess.Catalogue
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.BusinessRules.Catalogue
    Public Class clsBClassification
        Inherits clsBBase

        ' *******************************************************************************************************
        ' Declare Private variables
        ' *******************************************************************************************************
        Private objDClassification As New clsDClassification
        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem

        Private strIDs As String = ""
        Private strItemLeader As String = ""
        Private strItemCode As String = ""
        Private strDisplayEntry As String = ""
        Private intTypeID As Integer = 0
        Private strCaption As String = ""
        Private strVietCaption As String = ""
        Private strDescription As String = ""
        Private strVersion As String = ""
        Private strIDNew As String

        ' *******************************************************************************************************
        ' End declare variables
        ' Declare properties here
        ' *******************************************************************************************************
        ' IDs property
        Public Property IDs() As String
            Get
                Return strIDs
            End Get
            Set(ByVal Value As String)
                strIDs = Value
            End Set
        End Property

        ' IDNew property
        Public Property IDNew() As String
            Get
                Return strIDNew
            End Get
            Set(ByVal Value As String)
                strIDNew = Value
            End Set
        End Property

        ' ItemLeader property
        Public Property ItemLeader() As String
            Get
                Return strItemLeader
            End Get
            Set(ByVal Value As String)
                strItemLeader = Value
            End Set
        End Property

        ' ItemCode property
        Public Property ItemCode() As String
            Get
                Return strItemCode
            End Get
            Set(ByVal Value As String)
                strItemCode = Value
            End Set
        End Property

        ' DisplayEntry property
        Public Property DisplayEntry() As String
            Get
                Return strDisplayEntry
            End Get
            Set(ByVal Value As String)
                strDisplayEntry = Value
            End Set
        End Property

        ' TypeID property
        Public Property TypeID() As Integer
            Get
                Return intTypeID
            End Get
            Set(ByVal Value As Integer)
                intTypeID = Value
            End Set
        End Property

        ' Caption property
        Public Property Caption() As String
            Get
                Return strCaption
            End Get
            Set(ByVal Value As String)
                strCaption = Value
            End Set
        End Property

        ' VietCaption property
        Public Property VietCaption() As String
            Get
                Return strVietCaption
            End Get
            Set(ByVal Value As String)
                strVietCaption = Value
            End Set
        End Property

        ' Description property
        Public Property Description() As String
            Get
                Return strDescription
            End Get
            Set(ByVal Value As String)
                strDescription = Value
            End Set
        End Property

        ' Version property
        Public Property Version() As String
            Get
                Return strVersion
            End Get
            Set(ByVal Value As String)
                strVersion = Value
            End Set
        End Property

        ' *******************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *******************************************************************************************************

        ' Initialize method
        ' Purpose: init all neccessary objects
        Public Sub Initialize()
            Try
                objDClassification.ConnectionString = strConnectionString
                objDClassification.DBServer = strDBServer
                Call objDClassification.Initialize()

                objBCDBS.InterfaceLanguage = strInterfaceLanguage
                objBCDBS.DBServer = strDBServer
                objBCDBS.ConnectionString = strConnectionString
                Call objBCDBS.Initialize()

                objBCSP.InterfaceLanguage = strInterfaceLanguage
                objBCSP.DBServer = strDBServer
                objBCSP.ConnectionString = strConnectionString
                Call objBCSP.Initialize()
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        '' Method: Insert
        'Public Sub Insert1()
        '    Try
        '        Dim strTmp As String
        '        strTmp = objBCSP.ConvertItBack(strDisplayEntry)
        '        objDClassification.IDs = strIDs
        '        objDClassification.ItemLeader = objBCSP.ConvertItBack(strItemLeader)
        '        objDClassification.ItemCode = objBCSP.ConvertItBack(strItemCode)
        '        objDClassification.DisplayEntry = strTmp
        '        objDClassification.AccessEntry = objBCSP.ProcessVal(strTmp)
        '        objDClassification.TypeID = intTypeID
        '        objDClassification.Description = objBCSP.ConvertItBack(strDescription)
        '        objDClassification.Caption = objBCSP.ConvertItBack(strCaption)
        '        objDClassification.VietCaption = objBCSP.ConvertItBack(strVietCaption)
        '        objDClassification.Version = objBCSP.ConvertItBack(strVersion)
        '        objDClassification.Insert()
        '        strErrorMsg = objDClassification.ErrorMsg
        '        intErrorCode = objDClassification.ErrorCode
        '    Catch ex As Exception
        '        strErrorMsg = ex.Message
        '    Finally
        '    End Try
        'End Sub

        ' Method: Update
        'Public Sub Update()
        '    Try
        '        Dim strTmp As String
        '        strTmp = objBCSP.ConvertItBack(strDisplayEntry)
        '        objDClassification.IDs = strIDs
        '        objDClassification.ItemLeader = objBCSP.ConvertItBack(strItemLeader)
        '        objDClassification.ItemCode = objBCSP.ConvertItBack(strItemCode)
        '        objDClassification.DisplayEntry = strTmp
        '        objDClassification.AccessEntry = objBCSP.ProcessVal(strTmp)
        '        objDClassification.Caption = objBCSP.ConvertItBack(strCaption)
        '        objDClassification.VietCaption = objBCSP.ConvertItBack(strVietCaption)
        '        objDClassification.Version = objBCSP.ConvertItBack(strVersion)
        '        objDClassification.Description = objBCSP.ConvertItBack(strDescription)
        '        objDClassification.Update()
        '        strErrorMsg = objDClassification.ErrorMsg
        '        intErrorCode = objDClassification.ErrorCode
        '    Catch ex As Exception
        '        strErrorMsg = ex.Message
        '    Finally
        '    End Try
        'End Sub

        '' Method: Delete
        'Public Sub Delete()
        '    Try
        '        objDClassification.IDs = strIDs
        '        Call objDClassification.Delete()
        '        strErrorMsg = objDClassification.ErrorMsg
        '        intErrorCode = objDClassification.ErrorCode
        '    Catch ex As Exception
        '        strErrorMsg = ex.Message
        '    Finally
        '    End Try
        'End Sub

        '' Method: Retrieve
        'Public Function Retrieve() As DataTable
        '    Try
        '        objDClassification.IDs = strIDs
        '        objDClassification.AccessEntry = objBCSP.ProcessVal(objBCSP.ConvertItBack(strDisplayEntry))
        '        objDClassification.TypeID = intTypeID
        '        Retrieve = objBCDBS.ConvertTable(objDClassification.Retrieve)
        '        strErrorMsg = objDClassification.ErrorMsg
        '        intErrorCode = objDClassification.ErrorCode
        '    Catch ex As Exception
        '        strErrorMsg = ex.Message
        '    Finally
        '    End Try
        'End Function

        ' Method: GetClassification
        ' Purpose: Get classification data
        ' Input: ClassificationID, AccessEntry
        ' Output: Datatable result
        Public Function GetClassification() As DataTable
            Try
                objDClassification.AccessEntry = objBCSP.ProcessVal(objBCSP.ConvertItBack(strDisplayEntry))
                objDClassification.TypeID = intTypeID
                GetClassification = objBCDBS.ConvertTable(objDClassification.GetClassification)
                strErrorMsg = objDClassification.ErrorMsg
                intErrorCode = objDClassification.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' Method: Dispose
        ' Purpose: Release resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objDClassification Is Nothing Then
                    objDClassification.Dispose(True)
                    objDClassification = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace