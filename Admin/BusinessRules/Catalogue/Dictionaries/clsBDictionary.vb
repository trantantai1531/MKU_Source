Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.DataAccess.Catalogue

Namespace eMicLibAdmin.BusinessRules.Catalogue
    Public Class clsBDictionary
        Inherits clsBBase

        ' Declare variable
        Private objDDictionary As New clsDDictionary
        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem

        Private strIDs As String = ""
        Private strItemLeader As String = ""
        Private strItemCode As String = ""
        Private strDisplayEntry As String = ""
        Private strAccessEntry As String = ""
        Private strSearchFields As String = ""
        Private strISOCode As String = ""
        Private strName As String = ""
        Private strNameViet As String = ""
        Private strNote As String = ""
        Private lngParentID As Long = 0
        Private intTypeID As Integer = 0
        Private strCaption As String = ""
        Private strVietCaption As String = ""
        Private strDescription As String = ""
        Private strVersion As String = ""
        Private strTableDic As String = ""
        Private strIDNew As String = ""
        Private intIDTableDic As Integer = 0
        Private intTopNumber As Integer = 0
        Private strType As String = ""
        Private lngID As Long = 0

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

        ' DicIndexID property
        Public Property DicIndexID() As Integer
            Get
                Return intIDTableDic
            End Get
            Set(ByVal Value As Integer)
                intIDTableDic = Value
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

        ' AccessEntry property
        Public Property AccessEntry() As String
            Get
                Return strAccessEntry
            End Get
            Set(ByVal Value As String)
                strAccessEntry = Value
            End Set
        End Property

        ' SearchFields property
        Public Property SearchFields() As String
            Get
                Return strSearchFields
            End Get
            Set(ByVal Value As String)
                strSearchFields = Value
            End Set
        End Property

        ' IsoCode property
        Public Property IsoCode() As String
            Get
                Return strISOCode
            End Get
            Set(ByVal Value As String)
                strISOCode = Value
            End Set
        End Property

        ' Name property
        Public Property Name() As String
            Get
                Return strName
            End Get
            Set(ByVal Value As String)
                strName = Value
            End Set
        End Property

        ' NameViet property
        Public Property NameViet() As String
            Get
                Return strNameViet
            End Get
            Set(ByVal Value As String)
                strNameViet = Value
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

        ' Note property
        Public Property ParentID() As Long
            Get
                Return lngParentID
            End Get
            Set(ByVal Value As Long)
                lngParentID = Value
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

        ' TableDicName property
        Public Property TableDicName() As String
            Get
                Return strTableDic
            End Get
            Set(ByVal Value As String)
                strTableDic = Value
            End Set
        End Property

        ' TopNumber property
        Public Property TopNumber() As Integer
            Get
                Return intTopNumber
            End Get
            Set(ByVal Value As Integer)
                intTopNumber = Value
            End Set
        End Property

        ' Type property
        Public Property Type() As String
            Get
                Return strType
            End Get
            Set(ByVal Value As String)
                strType = Value
            End Set
        End Property

        ' ID property
        Public Property ID() As Long
            Get
                Return lngID
            End Get
            Set(ByVal Value As Long)
                lngID = Value
            End Set
        End Property

        ' Method: Initialize
        Public Sub Initialize()
            Try
                objDDictionary.ConnectionString = strConnectionString
                objDDictionary.DBServer = strDBServer
                objDDictionary.Initialize()

                objBCDBS.InterfaceLanguage = strInterfaceLanguage
                objBCDBS.DBServer = strDBServer
                objBCDBS.ConnectionString = strConnectionString
                objBCDBS.Initialize()

                objBCSP.InterfaceLanguage = strInterfaceLanguage
                objBCSP.DBServer = strDBServer
                objBCSP.ConnectionString = strConnectionString
                objBCSP.Initialize()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Method: Insert
        Public Function Insert() As Integer
            Try
                strDisplayEntry = objBCSP.ConvertItBack(strDisplayEntry)

                objDDictionary.ItemLeader = objBCSP.ConvertItBack(strItemLeader)
                objDDictionary.ItemCode = strItemCode
                objDDictionary.DisplayEntry = strDisplayEntry
                objDDictionary.AccessEntry = objBCSP.ProcessVal(strDisplayEntry)
                objDDictionary.Type = strType
                objDDictionary.Caption = objBCSP.ConvertItBack(strCaption)
                objDDictionary.VietCaption = objBCSP.ConvertItBack(strVietCaption)
                objDDictionary.Version = objBCSP.ConvertItBack(strVersion)
                objDDictionary.Description = objBCSP.ConvertItBack(strDescription)
                Insert = objDDictionary.Insert()
                strErrorMsg = objDDictionary.ErrorMsg
                intErrorCode = objDDictionary.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' Method: Update
        Public Function Update() As Integer
            Try
                strDisplayEntry = objBCSP.ConvertItBack(strDisplayEntry)

                objDDictionary.ID = lngID
                objDDictionary.ItemLeader = objBCSP.ConvertItBack(strItemLeader)
                objDDictionary.DisplayEntry = objBCSP.ConvertItBack(strDisplayEntry)
                objDDictionary.AccessEntry = objBCSP.ProcessVal(strDisplayEntry)
                objDDictionary.Type = strType
                objDDictionary.Caption = objBCSP.ConvertItBack(strCaption)
                objDDictionary.VietCaption = objBCSP.ConvertItBack(strVietCaption)
                objDDictionary.Version = objBCSP.ConvertItBack(strVersion)
                objDDictionary.Description = objBCSP.ConvertItBack(strDescription)
                Update = objDDictionary.Update()
                strErrorMsg = objDDictionary.ErrorMsg
                intErrorCode = objDDictionary.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' Method: UpdateDicIndex
        Public Sub UpdateDicIndex()
            Try
                strDisplayEntry = objBCSP.ConvertItBack(strDisplayEntry)

                objDDictionary.DisplayEntry = Replace(strDisplayEntry, "'", "''")
                objDDictionary.AccessEntry = objBCSP.ProcessVal(Replace(strDisplayEntry, "'", "''"))
                objDDictionary.IsoCode = Replace(strISOCode, "'", "''") & ""
                objDDictionary.Name = objBCSP.ConvertItBack(Replace(strName, "'", "''"))
                objDDictionary.NameViet = objBCSP.ConvertItBack(Replace(strNameViet, "'", "''"))
                objDDictionary.Note = objBCSP.ConvertItBack(Replace(strNote, "'", "''"))
                objDDictionary.ParentID = lngParentID
                objDDictionary.TableDicName = Trim(strTableDic)
                objDDictionary.IDs = strIDs
                Call objDDictionary.UpdateDicIndex()
                strErrorMsg = objDDictionary.ErrorMsg
                intErrorCode = objDDictionary.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        ' Method: MergeDicIndex
        Public Sub MergeDicIndex()
            Try
                objDDictionary.IDNew = strIDNew
                objDDictionary.IDs = strIDs
                objDDictionary.DicIndexID = intIDTableDic
                objDDictionary.MergeDicIndex()
                strErrorMsg = objDDictionary.ErrorMsg
                intErrorCode = objDDictionary.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        ' Method: Delete
        Public Sub Delete()
            Try
                objDDictionary.IDs = strIDs
                objDDictionary.Delete()
                strErrorMsg = objDDictionary.ErrorMsg
                intErrorCode = objDDictionary.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        ' Method: Retrieve
        Public Function Retrieve() As DataTable
            Try
                objDDictionary.Type = Trim(UCase(strType))
                Retrieve = objBCDBS.ConvertTable(objDDictionary.Retrieve)
                strErrorMsg = objDDictionary.ErrorMsg
                intErrorCode = objDDictionary.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' Method: RetrieveDicIndex
        Public Function RetrieveDicIndex() As DataTable
            Try
                objDDictionary.TableDicName = strTableDic
                objDDictionary.AccessEntry = objBCSP.ProcessVal(objBCSP.ConvertItBack(strDisplayEntry))
                objDDictionary.TopNumber = intTopNumber
                objDDictionary.SearchFields = strSearchFields
                RetrieveDicIndex = objBCDBS.ConvertTable(objDDictionary.RetrieveDicInfor)
                strErrorMsg = objDDictionary.ErrorMsg
                intErrorCode = objDDictionary.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
        End Function

        ' RetrieveDicAuthor method
        ' Purpose: Retrieve the details of a Authority Dictionary table
        ' Input: TableDicName, AccessEntry
        ' Out put: Datatable
        Public Function RetrieveDicAuthor() As DataTable
            Try
                objDDictionary.TableDicName = strTableDic
                objDDictionary.AccessEntry = objBCSP.ProcessVal(objBCSP.ConvertItBack(strAccessEntry))
                objDDictionary.SearchFields = strSearchFields

                Return objBCDBS.ConvertTable(objDDictionary.RetrieveDicAuthor)
                strErrorMsg = objDDictionary.ErrorMsg
                intErrorCode = objDDictionary.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        Public Function GetPublisher() As DataTable
            objDDictionary.DisplayEntry = objBCSP.ProcessVal(objBCSP.ConvertItBack(strDisplayEntry))
            GetPublisher = objBCDBS.ConvertTable(objDDictionary.GetPublisher)
        End Function

        Public Function GetCatDicList(Optional ByVal intID As Integer = 0) As DataTable
            GetCatDicList = objBCDBS.ConvertTable(objDDictionary.GetCatDicList(intID))
        End Function

        ' Dispose method
        ' Purpose: Realease the objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objDDictionary Is Nothing Then
                    objDDictionary.Dispose(True)
                    objDDictionary = Nothing
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