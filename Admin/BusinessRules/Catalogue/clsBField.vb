' Purpose: process fiels
' Creator: Oanhtn
' Created Date: 26/04/2004
' Modification history:
'   - 07/05/2004 by Oanhtn: get all none marc fields
'       + Add new method: GetUserFields to get all none marc fields
'   - 11/05/2004 by Oanhtn: get all of linktypes
'       + Add new method: GetLinkTypes to get all of linktypes 
'   - 03/06/2004 by Oanhtn: support authority data
'       + Modify all function to support authority data

Imports System
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Catalogue

Namespace eMicLibAdmin.BusinessRules.Catalogue
    Public Class clsBField
        Inherits clsBBase

        ' *****************************************************************************************************
        ' Declare Private variables
        ' *****************************************************************************************************

        Protected strFieldCode As String = ""
        Private strFieldName As String = ""
        Private strVietFieldName As String = ""
        Private strIndicators As String = ""
        Private strVietIndicators As String = ""
        Private intRepeatable As Integer = 0
        Private intMandatory As Integer = 0
        Private strDescription As String = ""
        Private intDicID As Integer = 0
        Private intFieldTypeID As Integer = 0
        Private intLength As Integer = 0
        Private intFunctionID As Integer = 0
        Private intLinkTypeID As Integer = 0
        Private intBlockID As Integer = 0
        Protected strFCURL1 As String = ""
        Protected strFCURL2 As String = ""
        Protected strFCURL3 As String = ""
        Protected strFCURL4 As String = ""
        Protected strFCURL5 As String = ""
        Protected strFCURL6 As String = ""
        Protected strPickedFieldCodes As String = ""
        Protected strMandatoryFieldCodes As String = ""
        Private intHaveParentFieldCode As Integer = 0
        Protected intIsAuthority As Integer = 0
        Private strPattern As String = ""

        Private objDField As New clsDField
        Private objBCatDicList As New clsBCatDicList
        Private objBCDBS As New clsBCommonDBSystem
        Private objBCSP As New clsBCommonStringProc

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' FieldCode property
        Public Property FieldCode() As String
            Get
                Return strFieldCode
            End Get
            Set(ByVal Value As String)
                strFieldCode = Value
            End Set
        End Property

        ' FieldName property
        Public Property FieldName() As String
            Get
                Return strFieldName
            End Get
            Set(ByVal Value As String)
                strFieldName = Value
            End Set
        End Property

        ' VietFieldName property
        Public Property VietFieldName() As String
            Get
                Return strVietFieldName
            End Get
            Set(ByVal Value As String)
                strVietFieldName = Value
            End Set
        End Property

        ' Indicators property
        Public Property Indicators() As String
            Get
                Return strIndicators
            End Get
            Set(ByVal Value As String)
                strIndicators = Value
            End Set
        End Property

        ' VietIndicators property
        Public Property VietIndicators() As String
            Get
                Return strVietIndicators
            End Get
            Set(ByVal Value As String)
                strVietIndicators = Value
            End Set
        End Property

        ' Repeatable property
        Public Property Repeatable() As Integer
            Get
                Return intRepeatable
            End Get
            Set(ByVal Value As Integer)
                intRepeatable = Value
            End Set
        End Property

        ' Mandatory property
        Public Property Mandatory() As Integer
            Get
                Return intMandatory
            End Get
            Set(ByVal Value As Integer)
                intMandatory = Value
            End Set
        End Property

        ' Length property
        Public Property Length() As Integer
            Get
                Return intLength
            End Get
            Set(ByVal Value As Integer)
                intLength = Value
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

        ' LinkTypeID property
        Public Property LinkTypeID() As Integer
            Get
                Return intLinkTypeID
            End Get
            Set(ByVal Value As Integer)
                intLinkTypeID = Value
            End Set
        End Property

        ' FunctionID property
        Public Property FunctionID() As Integer
            Get
                Return intFunctionID
            End Get
            Set(ByVal Value As Integer)
                intFunctionID = Value
            End Set
        End Property

        ' FieldTypeID property
        Public Property FieldTypeID() As Integer
            Get
                Return intFieldTypeID
            End Get
            Set(ByVal Value As Integer)
                intFieldTypeID = Value
            End Set
        End Property

        ' DicID property
        Public Property DicID() As Integer
            Get
                Return intDicID
            End Get
            Set(ByVal Value As Integer)
                intDicID = Value
            End Set
        End Property

        ' BlockID property
        Public Property BlockID() As Integer
            Get
                Return intBlockID
            End Get
            Set(ByVal Value As Integer)
                intBlockID = Value
            End Set
        End Property

        ' FCURL1 property
        Public Property FCURL1() As String
            Get
                Return strFCURL1
            End Get
            Set(ByVal Value As String)
                strFCURL1 = Value
            End Set
        End Property

        ' FCURL2 property
        Public Property FCURL2() As String
            Get
                Return strFCURL2
            End Get
            Set(ByVal Value As String)
                strFCURL2 = Value
            End Set
        End Property

        ' FCURL3 property
        Public Property FCURL3() As String
            Get
                Return strFCURL3
            End Get
            Set(ByVal Value As String)
                strFCURL3 = Value
            End Set
        End Property

        ' FCURL4 property
        Public Property FCURL4() As String
            Get
                Return strFCURL4
            End Get
            Set(ByVal Value As String)
                strFCURL4 = Value
            End Set
        End Property

        ' FCURL5 property
        Public Property FCURL5() As String
            Get
                Return strFCURL5
            End Get
            Set(ByVal Value As String)
                strFCURL5 = Value
            End Set
        End Property

        ' FCURL6 property
        Public Property FCURL6() As String
            Get
                Return strFCURL6
            End Get
            Set(ByVal Value As String)
                strFCURL6 = Value
            End Set
        End Property

        'HaveParentFieldCode property
        Public Property HaveParentFieldCode() As Integer
            Get
                Return intHaveParentFieldCode
            End Get
            Set(ByVal Value As Integer)
                intHaveParentFieldCode = Value
            End Set
        End Property

        ' Pattern property
        Public Property Pattern() As String
            Get
                Return strPattern
            End Get
            Set(ByVal Value As String)
                strPattern = Value
            End Set
        End Property

        ' IsAuthority property
        Public Property IsAuthority() As Integer
            Get
                Return intIsAuthority
            End Get
            Set(ByVal Value As Integer)
                intIsAuthority = Value
            End Set
        End Property

        ' PickedFieldCodes property
        Public Property PickedFieldCodes() As String
            Get
                Return strPickedFieldCodes
            End Get
            Set(ByVal Value As String)
                strPickedFieldCodes = Value
            End Set
        End Property

        ' MandatoryFieldCodes property
        Public Property MandatoryFieldCodes() As String
            Get
                Return strMandatoryFieldCodes
            End Get
            Set(ByVal Value As String)
                strMandatoryFieldCodes = Value
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
                ' Init objDField
                objDField.DBServer = strDBserver
                objDField.ConnectionString = strConnectionString
                Call objDField.Initialize()

                ' Init objBCDBS
                objBCDBS.DBServer = strDBServer
                objBCDBS.InterfaceLanguage = strInterfaceLanguage
                objBCDBS.ConnectionString = strConnectionString
                Call objBCDBS.Initialize()

                ' Init objBCatDicList
                objBCatDicList.DBServer = strDBServer
                objBCatDicList.InterfaceLanguage = strInterfaceLanguage
                objBCatDicList.ConnectionString = strConnectionString
                Call objBCatDicList.Initialize()

                ' Init objBCSP object
                objBCSP.DBServer = strDBServer
                objBCSP.InterfaceLanguage = strInterfaceLanguage
                objBCSP.ConnectionString = strConnectionString
                Call objBCSP.Initialize()
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        ' Create method
        ' Purpose: Create new field (user define)
        ' Input: all properties of field
        ' Output: int value (0 when fail)   
        Public Function Create() As Integer
            Try
                objDField.FieldCode = Trim(strFieldCode)
                objDField.FieldName = Trim(strFieldName)
                objDField.VietFieldName = Trim(objBCSP.ConvertItBack(strVietFieldName))
                objDField.Indicators = Trim(strIndicators)
                objDField.VietIndicators = Trim(objBCSP.ConvertItBack(strVietIndicators))
                objDField.Repeatable = intRepeatable
                objDField.Mandatory = intMandatory
                objDField.Length = intLength
                objDField.Description = Trim(objBCSP.ConvertItBack(strDescription))
                objDField.LinkTypeID = intLinkTypeID
                objDField.FunctionID = intFunctionID
                objDField.FieldTypeID = intFieldTypeID
                objDField.DicID = intDicID
                Create = objDField.Create()
                strErrorMsg = objDField.ErrorMsg
                intErrorCode = objDField.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' Modify method
        ' Purpose: Modify the information of the user define field
        Public Sub Modify()
            Try
                objDField.FieldCode = Trim(strFieldCode)
                objDField.FieldName = Trim(strFieldName)
                objDField.VietFieldName = Trim(objBCSP.ConvertItBack(strVietFieldName))
                objDField.Indicators = Trim(strIndicators)
                objDField.VietIndicators = Trim(objBCSP.ConvertItBack(strVietIndicators))
                objDField.Repeatable = intRepeatable
                objDField.Mandatory = intMandatory
                objDField.Length = intLength
                objDField.Description = Trim(objBCSP.ConvertItBack(strDescription))
                objDField.LinkTypeID = intLinkTypeID
                objDField.FunctionID = intFunctionID
                objDField.FieldTypeID = intFieldTypeID
                objDField.DicID = intDicID
                Call objDField.Modify()
                strSQL = objDField.SQLStatement
                strErrorMsg = objDField.ErrorMsg
                intErrorCode = objDField.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        ' Delete method
        ' Purpose: Delete the selected user define fied
        Public Sub Delete()
            Try
                objDField.FieldCode = Trim(strFieldCode)
                Call objDField.Delete()
                strErrorMsg = objDField.ErrorMsg
                intErrorCode = objDField.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        ' GetProperties method
        ' Purpose: Get all properties of the selected field
        Public Function GetProperties() As DataTable
            Try
                objDField.IsAuthority = intIsAuthority
                objDField.FieldCode = Trim(strFieldCode)
                GetProperties = objDField.GetProperties()
                strErrorMsg = objDField.ErrorMsg
                intErrorCode = objDField.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' GetSubFields method
        ' Purpose: Get all subfield of the selected field
        Public Function GetSubFields() As DataTable
            Try
                objDField.IsAuthority = intIsAuthority
                objDField.FCURL1 = strFCURL1
                objDField.FCURL2 = strFCURL2
                objDField.FieldCode = Trim(strFieldCode)
                GetSubFields = objDField.GetSubFields()
                strErrorMsg = objDField.ErrorMsg
                intErrorCode = objDField.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' GetIndicatorValues method
        ' Purpose: Get value of indicators of the selected field
        Public Function GetIndicatorValues() As DataTable
            Try
                objDField.IsAuthority = intIsAuthority
                objDField.FieldCode = Trim(strFieldCode)
                GetIndicatorValues = objDField.GetIndicatorValues()
                strErrorMsg = objDField.ErrorMsg
                intErrorCode = objDField.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' GetBlockFields method
        ' Purpose: Get all blocks of sysfields
        Public Function GetBlockFields() As DataTable
            Try
                objDField.IsAuthority = intIsAuthority
                GetBlockFields = objDField.GetBlockFields
                intErrorCode = objDField.ErrorCode
                strErrorMsg = objDField.ErrorMsg()
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' GetFieldsOfBlock method
        ' Purpose: Get all fields of the selected block
        Public Function GetFieldsOfBlock() As DataTable
            Try
                objDField.IsAuthority = intIsAuthority
                objDField.FCURL1 = strFCURL1
                objDField.FCURL2 = strFCURL2
                objDField.BlockID = intBlockID
                GetFieldsOfBlock = objDField.GetFieldsOfBlock
                intErrorCode = objDField.ErrorCode
                strErrorMsg = objDField.ErrorMsg()
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' SearchField method
        ' Purpose: search by fieldcode
        ' Input: search pattern
        ' Output: datatable
        Public Function SearchField() As DataTable
            Try
                objDField.Pattern = objBCSP.ConvertItBack(strPattern)
                objDField.HaveParentFieldCode = intHaveParentFieldCode
                objDField.IsAuthority = intIsAuthority
                objDField.FCURL1 = strFCURL1
                objDField.FCURL2 = strFCURL2
                SearchField = objDField.SearchField
                intErrorCode = objDField.ErrorCode
                strErrorMsg = objDField.ErrorMsg()
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' GetFields method
        ' Purpose: Get all fields of the selected catalogue form
        'Public Function GetFieldsToView() As DataTable
        '    Try
        '        objDField.IsAuthority = intIsAuthority
        '        objDField.FCURL1 = strFCURL1
        '        objDField.FCURL2 = strFCURL2
        '        objDField.FCURL3 = strFCURL3
        '        objDField.FCURL4 = strFCURL4
        '        objDField.FCURL5 = strFCURL5
        '        objDField.PickedFieldCodes = strPickedFieldCodes
        '        objDField.MandatoryFieldCodes = strMandatoryFieldCodes
        '        GetFieldsToView = objDField.GetFieldsToView
        '        intErrorCode = objDField.ErrorCode
        '        strErrorMsg = objDField.ErrorMsg
        '        'Catch ex As Exception
        '        '    strErrorMsg = ex.Message
        '    Finally
        '    End Try
        'End Function

        ' GetUserFields method
        ' Purpose: Get all user define fields
        ' Output: datatable
        Public Function GetUserFields() As DataTable
            Try
                objDField.IsAuthority = intIsAuthority
                GetUserFields = objBCDBS.ConvertTable(objDField.GetUserFields)
                intErrorCode = objDField.ErrorCode
                strErrorMsg = objDField.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' RetrieveMarcFieldTypes method
        ' Purpose: Get all types of marcfields
        ' Output: datatable
        Public Function RetrieveMarcFieldTypes() As DataTable
            Try
                RetrieveMarcFieldTypes = objDField.RetrieveMarcFieldTypes
                intErrorCode = objDField.ErrorCode
                strErrorMsg = objDField.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' RetrieveMarcFunctions method
        ' Purpose: Get all functions of marcfields
        ' Output: datatable
        Public Function RetrieveMarcFunctions() As DataTable
            Try
                RetrieveMarcFunctions = objDField.RetrieveMarcFunctions
                intErrorCode = objDField.ErrorCode
                strErrorMsg = objDField.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' RetrieveCatDicList method
        ' Purpose: Get all of sys dic
        ' Output: datatable
        Public Function RetrieveCatDicList() As DataTable
            Try
                RetrieveCatDicList = objBCatDicList.Retrieve
                intErrorCode = objBCatDicList.ErrorCode
                strErrorMsg = objBCatDicList.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' GetLinkTypes method
        ' Purpose: get all type of links
        ' Output: Datatable
        Public Function GetLinkTypes() As DataTable
            Try
                GetLinkTypes = objDField.GetLinkTypes
                intErrorCode = objDField.ErrorCode
                strErrorMsg = objDField.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objDField Is Nothing Then
                    objDField.Dispose(True)
                    objDField = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBCatDicList Is Nothing Then
                    objBCatDicList.Dispose(True)
                    objBCatDicList = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
            Finally
                Me.Dispose()
                MyBase.Dispose()
            End Try
        End Sub
    End Class
End Namespace